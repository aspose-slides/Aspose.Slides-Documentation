---
title: Gerenciar Fundos de Apresentação em .NET
linktitle: Fundo do Slide
type: docs
weight: 20
url: /pt/net/presentation-background/
keywords:
- fundo da apresentação
- fundo do slide
- cor sólida
- cor em gradiente
- fundo de imagem
- transparência do fundo
- propriedades do fundo
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Aprenda como definir fundos dinâmicos em arquivos PowerPoint e OpenDocument usando Aspose.Slides para .NET, com dicas de código para aprimorar suas apresentações."
---
## **Introdução**

Cores sólidas, gradientes e imagens são comumente usadas como fundos de slides. Você pode definir o fundo para um **slide normal** (um único slide) ou um **slide mestre** (aplica-se a vários slides de uma vez).

![PowerPoint background](powerpoint-background.png)

## **Definir um Fundo de Cor Sólida para um Slide Normal**

Aspose.Slides permite definir uma cor sólida como fundo de um slide específico em uma apresentação — mesmo que a apresentação use um slide mestre. A alteração se aplica apenas ao slide selecionado.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/).
2. Defina o [BackgroundType](https://reference.aspose.com/slides/pt/net/aspose.slides/backgroundtype/) do slide como `OwnBackground`.
3. Defina o [FillType](https://reference.aspose.com/slides/pt/net/aspose.slides/filltype/) do fundo do slide como `Solid`.
4. Use a propriedade [SolidFillColor](https://reference.aspose.com/slides/pt/net/aspose.slides/fillformat/solidfillcolor/) em [FillFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/fillformat/) para especificar a cor de fundo sólida.
5. Salve a apresentação modificada.

O exemplo C# a seguir mostra como definir uma cor sólida azul como fundo de um slide normal:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Crie uma instância da classe Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Defina a cor de fundo do slide como azul.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Blue;

    // Salve a apresentação no disco.
    presentation.Save("SolidColorBackground.pptx", SaveFormat.Pptx);
}
```

## **Definir um Fundo de Cor Sólida para um Slide Mestre**

Aspose.Slides permite definir uma cor sólida como fundo do slide mestre em uma apresentação. O slide mestre funciona como um modelo que controla a formatação de todos os slides, portanto, quando você escolhe uma cor sólida para o fundo do slide mestre, ela se aplica a todos os slides.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/).
2. Defina o [BackgroundType](https://reference.aspose.com/slides/pt/net/aspose.slides/backgroundtype/) do slide mestre (via `masters`) como `OwnBackground`.
3. Defina o [FillType](https://reference.aspose.com/slides/pt/net/aspose.slides/filltype/) do fundo do slide mestre como `Solid`.
4. Use o [SolidFillColor](https://reference.aspose.com/slides/pt/net/aspose.slides/fillformat/solidfillcolor/) para especificar a cor de fundo sólida.
5. Salve a apresentação modificada.

O exemplo C# a seguir mostra como definir uma cor sólida (verde floresta) como fundo de um slide mestre:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Crie uma instância da classe Presentation.
using (Presentation presentation = new Presentation())
{
    IMasterSlide masterSlide = presentation.Masters[0];

    // Defina a cor de fundo do slide Mestre como Verde Floresta.
    masterSlide.Background.Type = BackgroundType.OwnBackground;
    masterSlide.Background.FillFormat.FillType = FillType.Solid;
    masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

    // Salve a apresentação no disco.
    presentation.Save("MasterSlideBackground.pptx", SaveFormat.Pptx);
}
```

## **Definir um Fundo em Gradiente para um Slide**

Um gradiente é um efeito gráfico criado por uma mudança gradual de cor. Quando usado como fundo de slide, gradientes podem tornar as apresentações mais artísticas e profissionais. Aspose.Slides permite definir uma cor em gradiente como fundo dos slides.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/).
2. Defina o [BackgroundType](https://reference.aspose.com/slides/pt/net/aspose.slides/backgroundtype/) do slide como `OwnBackground`.
3. Defina o [FillType](https://reference.aspose.com/slides/pt/net/aspose.slides/filltype/) do fundo do slide como `Gradient`.
4. Use a propriedade [GradientFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/fillformat/gradientformat/) em [FillFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/fillformat/) para configurar as definições de gradiente desejadas.
5. Salve a apresentação modificada.

O exemplo C# a seguir mostra como definir uma cor em gradiente como fundo de um slide:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Crie uma instância da classe Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Aplique um efeito de gradiente ao fundo.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Gradient;
    slide.Background.FillFormat.GradientFormat.TileFlip = TileFlip.FlipBoth;

    // Salve a apresentação no disco.
    presentation.Save("GradientBackground.pptx", SaveFormat.Pptx);
}
```

## **Definir uma Imagem como Fundo de Slide**

Além de preenchimentos sólidos e em gradiente, Aspose.Slides permite usar imagens como fundos de slide.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/).
2. Defina o [BackgroundType](https://reference.aspose.com/slides/pt/net/aspose.slides/backgroundtype/) do slide como `OwnBackground`.
3. Defina o [FillType](https://reference.aspose.com/slides/pt/net/aspose.slides/filltype/) do fundo do slide como `Picture`.
4. Carregue a imagem que você deseja usar como fundo do slide.
5. Adicione a imagem à coleção de imagens da apresentação.
6. Use o [PictureFillFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/fillformat/picturefillformat/) em [FillFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/fillformat/) para atribuir a imagem como fundo.
7. Salve a apresentação modificada.

O exemplo C# a seguir mostra como definir uma imagem como fundo de um slide:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Crie uma instância da classe Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Defina as propriedades da imagem de fundo.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Picture;
    slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

    // Carregue a imagem.
    IImage image = Images.FromFile("Tulips.jpg");
    // Adicione a imagem à coleção de imagens da apresentação.
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    slide.Background.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // Salve a apresentação no disco.
    presentation.Save("ImageAsBackground.pptx", SaveFormat.Pptx);
}
```

O exemplo de código a seguir mostra como definir o tipo de preenchimento de fundo como uma imagem em mosaico e modificar as propriedades de repetição:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide firstSlide = presentation.Slides[0];

    IBackground background = firstSlide.Background;

    background.Type = BackgroundType.OwnBackground;
    background.FillFormat.FillType = FillType.Picture;

    IPPImage ppImage;
    using (IImage newImage = Aspose.Slides.Images.FromFile("image.png"))
        ppImage = presentation.Images.AddImage(newImage);

    // Defina a imagem usada para o preenchimento de fundo.
    IPictureFillFormat backPictureFillFormat = background.FillFormat.PictureFillFormat;
    backPictureFillFormat.Picture.Image = ppImage;

    // Defina o modo de preenchimento da imagem como Tile e ajuste as propriedades do tile.
    backPictureFillFormat.PictureFillMode = PictureFillMode.Tile;
    backPictureFillFormat.TileOffsetX = 15f;
    backPictureFillFormat.TileOffsetY = 15f;
    backPictureFillFormat.TileScaleX = 46f;
    backPictureFillFormat.TileScaleY = 87f;
    backPictureFillFormat.TileAlignment = RectangleAlignment.Center;
    backPictureFillFormat.TileFlip = TileFlip.FlipY;

    presentation.Save("TileBackground.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}}
Leia mais: [**Tile Picture As Texture**](/slides/pt/net/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Alterar a Transparência da Imagem de Fundo**

Você pode querer ajustar a transparência da imagem de fundo de um slide para fazer o conteúdo do slide se destacar. O código C# a seguir mostra como alterar a transparência de uma imagem de fundo de slide:

```cs
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

var transparencyValue = 30; // Por exemplo.

using (Presentation presentation = new Presentation("ImageAsBackground.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Obtenha a coleção de operações de transformação de imagem.
    var imageTransform = slide.Background.FillFormat.PictureFillFormat.Picture.ImageTransform;

    // Encontre um efeito de transparência de porcentagem fixa existente.
    var transparencyOperation = null as IAlphaModulateFixed;
    foreach (var operation in imageTransform)
    {
        if (operation is IAlphaModulateFixed alphaModulateFixed)
        {
            transparencyOperation = alphaModulateFixed;
            break;
        }
    }

    // Defina o novo valor de transparência.
    if (transparencyOperation == null)
    {
        imageTransform.AddAlphaModulateFixedEffect(100 - transparencyValue);
    }
    else
    {
        transparencyOperation.Amount = (100 - transparencyValue);
    }

    presentation.Save("ImageBackgroundTransparency.pptx", SaveFormat.Pptx);
}
```

## **Obter o Valor do Fundo do Slide**

Aspose.Slides fornece a interface [IBackgroundEffectiveData](https://reference.aspose.com/slides/pt/net/aspose.slides/ibackgroundeffectivedata/) para recuperar os valores efetivos de fundo de um slide. Essa interface expõe o [FillFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/ibackgroundeffectivedata/fillformat/) e o [EffectFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/ibackgroundeffectivedata/effectformat/) efetivos.

Usando a propriedade `background` da classe [BaseSlide](https://reference.aspose.com/slides/pt/net/aspose.slides/baseslide/), você pode obter o fundo efetivo de um slide.

O exemplo C# a seguir mostra como obter o valor do fundo efetivo de um slide:

```cs
using Aspose.Slides;

// Crie uma instância da classe Presentation.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    ISlide slide = presentation.Slides[0];  

    // Recupere o fundo efetivo, levando em conta mestre, layout e tema.
    IBackgroundEffectiveData effBackground = slide.Background.GetEffective();

    if (effBackground.FillFormat.FillType == FillType.Solid)
        Console.WriteLine("Fill color: " + effBackground.FillFormat.SolidFillColor);
    else
        Console.WriteLine("Fill type: " + effBackground.FillFormat.FillType);
}
```

## **Perguntas Frequentes**

### Posso redefinir um fundo personalizado e restaurar o fundo do tema/layout?

Sim. Remova o preenchimento personalizado do slide, e o fundo será herdado novamente do slide de [layout](/slides/pt/net/slide-layout/)/[master](/slides/pt/net/slide-master/) correspondente (ou seja, o [fundo do tema](/slides/pt/net/presentation-theme/)).

### O que acontece com o fundo se eu mudar o tema da apresentação mais tarde?

Se um slide tem seu próprio preenchimento, ele permanecerá inalterado. Se o fundo for herdado do [layout](/slides/pt/net/slide-layout/)/[master](/slides/pt/net/slide-master/), ele será atualizado para corresponder ao [novo tema](/slides/pt/net/presentation-theme/).