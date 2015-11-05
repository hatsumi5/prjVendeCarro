<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="prjVendeCarro._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%--<div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>--%>
    <br />
    <a id="news" href="#">
        <img id="imgNews" src="Images/news1.png" />
        <%--<img id="imgAnuncieAqui" src="Images/anuncieaqui.png" />--%>
        <%--<div id="imgNews" class="container-fluid">
            <div id="imgAnuncieAqui">

            </div>
        </div>--%>
    </a>
    <div class="body">
        <div class="row">
            <div class="col-md-4">
                <h2>Últimos veículos</h2>
                <div id="ultimos">
                    <div class="bg-card marg-t-20">
                       
                        <a href="https://www.meucarronovo.com.br/detalhe/volkswagen-parati-city-16mi-4p-2008-vermelho-flex-0-mcn-5898505">
                        <div class="w-50pc padd-r-10 pull-left">
                        <div class="thumbVeiculos" style="box-shadow: rgba(50, 50, 50, 0) 0px 0px 5px 0px;"><img class="w-100pc" src="https://d1x1xhcjqq6e69.cloudfront.net/imagens-dinamicas/home-cards/images_old/static/img/veic/rev/24/24483/5898505/g1.jpg?201510151842" width="155px" height="103px" style="transform: matrix(1, 0, 0, 1, 0, 0);"></div>
                        </div>
                        </a>

                        <a href="https://www.meucarronovo.com.br/detalhe/chevrolet-omega-gls-22-mpfi-4p-1995-preto-gasolina-0-mcn-6754031">
                        <div class="w-50pc padd-r-10 pull-left">
                        <div class="thumbVeiculos" style="box-shadow: rgba(50, 50, 50, 0) 0px 0px 5px 0px;"><img class="w-100pc" src="https://d1x1xhcjqq6e69.cloudfront.net/imagens-dinamicas/home-cards/images_old/static/img/veic/rev/34/34807/6754031/g1.jpg?201510151842" width="155px" height="103px" style="transform: matrix(1, 0, 0, 1, 0, 0);"></div>
                        </div>
                        </a>

                        <div class="clearfix"></div><div class="marg-t-20"></div><a href="https://www.meucarronovo.com.br/detalhe/volkswagen-santana-cl-18-2p-1991-branco-gasolina-1000-mcn-7468274">
                        <div class="w-50pc padd-r-10 pull-left">
                        <div class="thumbVeiculos" style="box-shadow: rgba(50, 50, 50, 0) 0px 0px 5px 0px;"><img class="w-100pc" src="https://d1x1xhcjqq6e69.cloudfront.net/imagens-dinamicas/home-cards/fotos/veiculos/1011314/7468274/132303fc2e94dfd2cf36a043e7ee705e.jpg?201510151842" width="155px" height="103px" style="transform: matrix(1, 0, 0, 1, 0, 0);"></div>
                        </div>
                        </a>

                        <a href="https://www.meucarronovo.com.br/detalhe/ford-f250-xlt-39-2p-1999-vermelho-gasolina-1-mcn-7404191">
                        <div class="w-50pc padd-r-10 pull-left">
                        <div class="thumbVeiculos" style="box-shadow: rgba(50, 50, 50, 0) 0px 0px 5px 0px;"><img class="w-100pc" src="https://d1x1xhcjqq6e69.cloudfront.net/imagens-dinamicas/home-cards/fotos/veiculos/14236/7404191/1d9cbf167a85cc7f18b06dc197244370.jpg?201510151842" width="155px" height="103px" style="transform: matrix(1, 0, 0, 1, 0, 0);"></div>
                        </div>
                        </a>
                        </center>


                    <div class="clearfix"></div>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                 <h2>Mais buscados</h2>
                <div id="maisbuscados"> 
                    <div class="bg-card marg-t-20">
                       
                        <a href="https://www.meucarronovo.com.br/detalhe/volkswagen-parati-city-16mi-4p-2008-vermelho-flex-0-mcn-5898505">
                        <div class="w-50pc padd-r-10 pull-left">
                        <div class="thumbVeiculos" style="box-shadow: rgba(50, 50, 50, 0) 0px 0px 5px 0px;"><img class="w-100pc" src="https://d1x1xhcjqq6e69.cloudfront.net/imagens-dinamicas/home-cards/images_old/static/img/veic/rev/24/24483/5898505/g1.jpg?201510151842" width="155px" height="103px" style="transform: matrix(1, 0, 0, 1, 0, 0);"></div>
                        </div>
                        </a>

                        <a href="https://www.meucarronovo.com.br/detalhe/chevrolet-omega-gls-22-mpfi-4p-1995-preto-gasolina-0-mcn-6754031">
                        <div class="w-50pc padd-r-10 pull-left">
                        <div class="thumbVeiculos" style="box-shadow: rgba(50, 50, 50, 0) 0px 0px 5px 0px;"><img class="w-100pc" src="https://d1x1xhcjqq6e69.cloudfront.net/imagens-dinamicas/home-cards/images_old/static/img/veic/rev/34/34807/6754031/g1.jpg?201510151842" width="155px" height="103px" style="transform: matrix(1, 0, 0, 1, 0, 0);"></div>
                        </div>
                        </a>

                        <div class="clearfix"></div><div class="marg-t-20"></div><a href="https://www.meucarronovo.com.br/detalhe/volkswagen-santana-cl-18-2p-1991-branco-gasolina-1000-mcn-7468274">
                        <div class="w-50pc padd-r-10 pull-left">
                        <div class="thumbVeiculos" style="box-shadow: rgba(50, 50, 50, 0) 0px 0px 5px 0px;"><img class="w-100pc" src="https://d1x1xhcjqq6e69.cloudfront.net/imagens-dinamicas/home-cards/fotos/veiculos/1011314/7468274/132303fc2e94dfd2cf36a043e7ee705e.jpg?201510151842" width="155px" height="103px" style="transform: matrix(1, 0, 0, 1, 0, 0);"></div>
                        </div>
                        </a>

                        <a href="https://www.meucarronovo.com.br/detalhe/ford-f250-xlt-39-2p-1999-vermelho-gasolina-1-mcn-7404191">
                        <div class="w-50pc padd-r-10 pull-left">
                        <div class="thumbVeiculos" style="box-shadow: rgba(50, 50, 50, 0) 0px 0px 5px 0px;"><img class="w-100pc" src="https://d1x1xhcjqq6e69.cloudfront.net/imagens-dinamicas/home-cards/fotos/veiculos/14236/7404191/1d9cbf167a85cc7f18b06dc197244370.jpg?201510151842" width="155px" height="103px" style="transform: matrix(1, 0, 0, 1, 0, 0);"></div>
                        </div>
                        </a>
                        </center>
                    <div class="clearfix"></div>


                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div id="acoes">
                    <a class="btn btn-primary btn-lg btn-block" href="/Pesquisar">Encontrar</a>
                    <a class="btn btn-primary btn-lg btn-block" href="/Anunciar">Anuncie Aqui</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
