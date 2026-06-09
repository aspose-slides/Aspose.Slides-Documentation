---
title: Adicionando Moldura de Imagem com Animação em VSTO e Aspose.Slides
type: docs
weight: 20
url: /pt/net/adding-picture-frame-with-animation-in-vsto-and-aspose-slides/
---
Os exemplos de código abaixo criam uma apresentação com um slide, adicionam uma imagem com uma moldura de foto e aplicam animação a ela.
## **VSTO**
Usando VSTO, siga as etapas a seguir:

1. Crie uma apresentação.
1. Adicione um slide vazio.
1. Adicione uma forma de imagem ao slide.
1. Aplique animação à imagem.
1. Grave a apresentação no disco.

``` csharp

 //Criando apresentação vazia
PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Adicionar slide em branco
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Adicionar moldura de imagem
PowerPoint.Shape PicFrame = sld.Shapes.AddPicture("pic.jpeg",

Microsoft.Office.Core.MsoTriState.msoTriStateMixed,

Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//Aplicando animação na moldura de imagem
PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//Salvando apresentação
pres.SaveAs("VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

Microsoft.Office.Core.MsoTriState.msoFalse);

``` 
## **Aspose.Slides**
Usando Aspose.Slides para .NET, execute as etapas a seguir:

1. Crie uma apresentação.
1. Acesse o primeiro slide.
1. Adicione uma imagem a uma coleção de imagens.
1. Adicione uma forma de imagem ao slide.
1. Aplique animação à imagem.
1. Grave a apresentação no disco.

``` csharp

 //Criando apresentação vazia
Presentation pres = new Presentation();
//Acessando o primeiro slide
Slide slide = pres.GetSlideByPosition(1);
//Adicionando o objeto de imagem à coleção de imagens da apresentação
Picture pic = new Picture(pres, "pic.jpeg");
//Depois que o objeto de imagem é adicionado, a imagem recebe um Id de imagem único
int picId = pres.Pictures.Add(pic);
//Adicionando moldura de imagem
Shape PicFrame = slide.Shapes.AddPictureFrame(picId, 1450, 1100, 2500, 2200);
//Aplicando animação na moldura de imagem
PicFrame.AnimationSettings.EntryEffect = ShapeEntryEffect.BoxIn;
//Salvando apresentação
pres.Write("AsposeAnim.ppt");
``` 
## **Baixar Código de Exemplo**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Adding.Picture.Frame.with.Animation.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Picture%20Frame%20with%20Animation%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Picture%20Frame%20with%20Animation/)