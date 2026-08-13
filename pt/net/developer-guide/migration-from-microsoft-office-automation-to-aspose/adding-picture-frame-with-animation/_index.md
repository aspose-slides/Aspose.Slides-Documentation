---
title: Adicionando Quadros de Imagem com Animação Usando VSTO e Aspose.Slides para .NET
linktitle: Quadros de Imagem com Animação
type: docs
weight: 60
url: /pt/net/adding-picture-frame-with-animation/
keywords:
- quadro de imagem
- adicionar imagem
- adicionar foto
- imagem com animação
- foto com animação
- migração
- VSTO
- automação Office
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Migre da automação Microsoft Office para Aspose.Slides para .NET e anime quadros de imagem no PowerPoint (PPT, PPTX) em slides com código C# limpo."
---
{{% alert color="info" %}} 

Os quadros de imagem são aplicados a formas ou imagens no Microsoft PowerPoint para enquadrar imagens em uma apresentação. Este artigo mostra como criar um quadro de imagem e aplicar animação nele programaticamente usando primeiro [VSTO 2008](/slides/pt/net/adding-picture-frame-with-animation/) e depois [Aspose.Slides for .NET](/slides/pt/net/adding-picture-frame-with-animation/). Primeiro, mostramos como aplicar um quadro e animação usando VSTO 2008. Em seguida, mostramos como executar as mesmas etapas usando Aspose.Slides for .NET.

{{% /alert %}} 
## **Adicionando Quadros de Imagem com Animação**
The code samples below create a presentation with a slide, add an image with a picture frame and applies animation to it.
### **Exemplo VSTO 2008**
Using VSTO 2008, take the following steps:

1. Crie uma apresentação.
1. Adicione um slide em branco.
1. Adicione uma forma de imagem ao slide.
1. Aplique animação à imagem.
1. Salve a apresentação no disco.

**A apresentação de saída, criada com VSTO** 

![todo:image_alt_text](adding-picture-frame-with-animation_1.png)



```c#
//Criando apresentação vazia
PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Adicionar slide em branco
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Adicionar quadro de imagem
PowerPoint.Shape PicFrame = sld.Shapes.AddPicture(@"D:\Aspose Data\Desert.jpg",
Microsoft.Office.Core.MsoTriState.msoTriStateMixed,
Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//Aplicando animação no quadro de imagem
PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//Salvando apresentação
pres.SaveAs("d:\\ VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Exemplo Aspose.Slides para .NET**
Using Aspose.Slides for .NET, perform the following steps:

1. Crie uma apresentação.
1. Acesse o primeiro slide.
1. Adicione uma imagem a uma coleção de imagens.
1. Adicione uma forma de imagem ao slide.
1. Aplique animação à imagem.
1. Salve a apresentação no disco.

**A apresentação de saída, criada com Aspose.Slides** 

![todo:image_alt_text](adding-picture-frame-with-animation_2.png)



```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Cria uma apresentação vazia
using (Presentation pres = new Presentation())
{
    // Acessa o primeiro slide
    ISlide slide = pres.Slides[0];

    // Adiciona uma imagem à coleção de imagens da apresentação
    IImage image = Images.FromFile("aspose.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Adiciona um quadro de imagem cuja altura e largura correspondem à altura e largura da imagem
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Obtém a sequência principal de animação do slide
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Adiciona o efeito de animação Voo da Esquerda ao quadro de imagem
    IEffect effect = sequence.AddEffect(pictureFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Salva a apresentação
    pres.Save("AsposeAnim.ppt", SaveFormat.Ppt);
}
```