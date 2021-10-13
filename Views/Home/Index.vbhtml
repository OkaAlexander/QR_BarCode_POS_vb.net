﻿@Code
    ViewData("Title") = "Home Page"
End Code

<div class="container">
    <div class="content-container container">
        <div class="left-panel">
            <div class="form-container">
                <form class="form-block" method="post" enctype="multipart/form-data">
                    <div class="form-group">
                        <div class="image-container">
                            <img src="https://cdn5.vectorstock.com/i/1000x1000/18/69/blue-qr-code-scanning-icon-or-design-logo-vector-18861869.jpg" class="image" id="image" alt="qr-image" />
                        </div>
                        <div class="input-group label-group">
                            <label class="btn btn-sm btn-danger btn-block" for="file">Choode QR image</label>
                            <input type="file" hidden id="file" name="file" onformchange="return handlefile()" />
                        </div>
                        <div class="input-group">
                            <input type="text" name="productID" id="productID" placeholder="enter product id" class="form-control" />
                            <input type="hidden" value="search" id="hiddens" name="hidden" class="form-control" />
                        </div>
                        <button type="submit" class="btn mt-2 btn-sm btn-block btn-primary" id="DecodebyProductId">Decode</button>
                    </div>
                </form>
            </div>
        </div>
        <div class="right-panel">
            <form method="post" class="form-body">
                <div class="form-group">
                    <div class="input-group">
                        <label for="pname">Product Name</label>
                        <input type="text" value="@ViewBag.pname" placeholder="Product Name" id="pname" name="pname" class="form-control" />
                    </div>

                    <div class="input-group">
                        <label for="psp">Cost Price</label>
                        <input type="text" value="@ViewBag.psp" placeholder="Selling Price" id="psp" name="psp" class="form-control" />
                    </div>
                    <div class="input-group">
                        <label for="pcp">Selling Price</label>
                        <input type="text" value="@ViewBag.pcp" placeholder="Cost Price" id="pcp" name="pcp" class="form-control" />
                    </div>
                    <div class="input-group">
                        <label for="pid">Product ID</label>
                        <input type="text" value="@ViewBag.pid" readonly placeholder="Product ID" id="pid" name="pid" class="form-control" />
                        <input type="hidden" value="register" id="hidden" name="hidden" class="form-control" />
                    </div>

                    <button type="submit" class="btn btn-primary btn-block btn-sm mt-4 RegisterProductbtn" id="RegisterProductbtn" name="RegisterProductbtn">Register Product</button>
                    <p class="errorlbl mt-5">@ViewBag.results</p>
                </div>
            </form>

        </div>
    </div>
</div>
