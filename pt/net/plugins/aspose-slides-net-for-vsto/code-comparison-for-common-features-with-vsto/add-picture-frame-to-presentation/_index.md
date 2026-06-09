---
title: Adicionar Quadro de Imagem à Apresentação
type: docs
weight: 50
url: /pt/net/add-picture-frame-to-presentation/
---
## **VSTO**
Abaixo está o código para adicionar uma imagem em uma apresentação VSTO:

``` csharp

  string ImageFilePath="AddPicture.jpg";

 Slide slide = Application.ActivePresentation.Slides[1];

 slide.Shapes.AddPicture(ImageFilePath, Microsoft.Office.Core.MsoTriState.msoFalse,

 Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0);

``` 
## **Aspose.Slides**
Para adicionar um quadro de imagem simples ao seu slide, siga as etapas abaixo:

1. Crie uma instância da classe Presentation.
1. Obtenha a referência de um slide usando seu índice.
1. Crie um objeto Image adicionando uma imagem à coleção Images associada ao objeto Presentation que será usada para preencher a Shape.
1. Calcule a largura e a altura da imagem.
1. Crie um PictureFrame com base na largura e altura da imagem usando o método AddPictureFrame exposto pelo objeto Shapes associado ao slide referenciado.
1. Adicione um quadro de imagem (contendo a imagem) ao slide.
1. Grave a apresentação modificada como um arquivo PPTX.

As etapas acima são implementadas no exemplo abaixo.

``` csharp

   string ImageFilePath = "AddPicture.jpg";

  //Instanciar a classe Presentation que representa o PPTX
  Presentation pres = new Presentation();

  //Obter o primeiro slide
  ISlide sld = pres.Slides[0];

  //Instanciar a classe ImageEx
  using IImage img = Images.FromFile(ImageFilePath);

  IPPImage imgx = pres.Images.AddImage(img);

  //Adicionar quadro de imagem com altura e largura equivalentes à imagem
  sld.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, imgx.Width, imgx.Height, imgx);

``` 
## **Baixar Código em Execução**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Baixar Código de Exemplo**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Add%20Picture%20Frame)