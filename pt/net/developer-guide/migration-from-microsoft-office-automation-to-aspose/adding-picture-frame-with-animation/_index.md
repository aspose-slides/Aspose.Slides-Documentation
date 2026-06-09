---
title: Adicionar Quadros de Imagem com Animação Usando VSTO e Aspose.Slides para .NET
linktitle: Quadros de Imagem com Animação
type: docs
weight: 60
url: /pt/net/adding-picture-frame-with-animation/
keywords:
- quadro de imagem
- adicionar imagem
- adicionar foto
- imagem com animação
- quadro com animação
- migração
- VSTO
- automação do Office
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Migre da automação do Microsoft Office para Aspose.Slides para .NET e anime quadros de imagem no PowerPoint (PPT, PPTX) slides com código C# limpo."
---
{{% alert color="primary" %}} 

Os quadros de imagem são aplicados a formas ou imagens no Microsoft PowerPoint para enquadrar imagens em uma apresentação. Este artigo demonstra como criar um quadro de imagem e aplicar animação nele programaticamente usando primeiro [VSTO 2008](/slides/pt/net/adding-picture-frame-with-animation/) e depois [Aspose.Slides for .NET](/slides/pt/net/adding-picture-frame-with-animation/). Primeiro, mostramos como aplicar um quadro e animação usando VSTO 2008. Em seguida, mostramos como executar as mesmas etapas usando Aspose.Slides for .NET.

{{% /alert %}} 
## **Adicionando Quadros de Imagem com Animação**
Os exemplos de código abaixo criam uma apresentação com um slide, adicionam uma imagem com um quadro de imagem e aplicam animação a ela.
### **Exemplo VSTO 2008**
Usando VSTO 2008, siga as etapas a seguir:

1. Crie uma apresentação.
1. Adicione um slide em branco.
1. Adicione uma forma de imagem ao slide.
1. Aplique animação à imagem.
1. Grave a apresentação no disco.

**A apresentação de saída, criada com VSTO** 

![todo:image_alt_text](adding-picture-frame-with-animation_1.png)



```c#
//Criando apresentação vazia
PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Adicionar um slide em branco
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Adicionar quadro de imagem
PowerPoint.Shape PicFrame = sld.Shapes.AddPicture(@"D:\Aspose Data\Desert.jpg",
Microsoft.Office.Core.MsoTriState.msoTriStateMixed,
Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//Aplicando animação no quadro de imagem
PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//Salvar apresentação
pres.SaveAs("d:\\ VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Exemplo Aspose.Slides for .NET**
Usando Aspose.Slides for .NET, execute as etapas a seguir:

1. Crie uma apresentação.
1. Acesse o primeiro slide.
1. Adicione uma imagem a uma coleção de imagens.
1. Adicione uma forma de imagem ao slide.
1. Aplique animação à imagem.
1. Grave a apresentação no disco.

**A apresentação de saída, criada com Aspose.Slides** 

![todo:image_alt_text](adding-picture-frame-with-animation_2.png)



```c#
// Criar uma apresentação vazia
using (Presentation pres = new Presentation())
{
    // Acessar o primeiro slide
    ISlide slide = pres.Slides[0];

    // Adicionar uma imagem à coleção de imagens da apresentação
    IImage image = Images.FromFile("aspose.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Adicionar um quadro de imagem cuja altura e largura correspondem à altura e largura da imagem
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Obter a sequência principal de animação do slide
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Adicionar o efeito de animação Voar da Esquerda ao quadro de imagem
    IEffect effect = sequence.AddEffect(pictureFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Salvar a apresentação
    pres.Save("AsposeAnim.ppt", SaveFormat.Ppt);
}
```