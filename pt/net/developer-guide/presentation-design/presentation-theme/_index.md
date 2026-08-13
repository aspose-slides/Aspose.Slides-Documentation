---
title: Gerenciar Temas de Apresentação em .NET
linktitle: Tema de Apresentação
type: docs
weight: 10
url: /pt/net/presentation-theme/
keywords:
- Tema PowerPoint
- tema de apresentação
- tema de slide
- definir tema
- alterar tema
- gerenciar tema
- cor do tema
- paleta adicional
- fonte do tema
- estilo do tema
- efeito do tema
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Domine os temas de apresentação no Aspose.Slides para .NET para criar, personalizar e converter arquivos PowerPoint com identidade visual consistente."
---
## **Introdução**

Um tema de apresentação define as propriedades dos elementos de design. Quando você seleciona um tema de apresentação, está essencialmente escolhendo um conjunto específico de elementos visuais e suas propriedades.

No PowerPoint, um tema compreende cores, [fonts](/slides/pt/net/powerpoint-fonts/), [background styles](/slides/pt/net/presentation-background/), e efeitos.

![theme-constituents](theme-constituents.png)

## **Alterar Cor do Tema**

Um tema do PowerPoint usa um conjunto específico de cores para diferentes elementos em um slide. Se você não gosta das cores, pode alterá‑las aplicando novas cores ao tema. Para permitir que você selecione uma nova cor de tema, o Aspose.Slides fornece valores na enumeração [SchemeColor](https://reference.aspose.com/slides/pt/net/aspose.slides/schemecolor/).

Este código C# mostra como alterar a cor de destaque de um tema:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
    
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
}
```

Você pode determinar o valor efetivo da cor resultante desta forma:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    var fillEffective = shape.FillFormat.GetEffective();

    Console.WriteLine($"{fillEffective.SolidFillColor.Name} ({fillEffective.SolidFillColor})"); // ff8064a2 (Cor [A=255, R=128, G=100, B=162])
}
```

Para demonstrar ainda mais a operação de mudança de cor, criamos outro elemento e atribuímos a cor de destaque (da operação inicial) a ele. Em seguida, alteramos a cor no tema:

```c#
using System.Drawing;
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IAutoShape otherShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

    otherShape.FillFormat.FillType = FillType.Solid;

    otherShape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    pres.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
}
```

A nova cor é aplicada automaticamente em ambos os elementos.

### **Definir Cor do Tema a partir de Uma Paleta Adicional**

Quando você aplica transformações de luminância à cor principal do tema(1), são formadas cores da paleta adicional(2). Você pode então definir e obter essas cores de tema.

![additional-palette-colors](additional-palette-colors.png)

**1** - Cores principais do tema

**2** - Cores da paleta adicional.

Este código C# demonstra uma operação em que as cores da paleta adicional são obtidas a partir da cor principal do tema e, em seguida, usadas em formas:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Acento 4
    IShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    // Acento 4, mais claro 80%
    IShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

    // Acento 4, mais claro 60%
    IShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

    // Acento 4, mais claro 40%
    IShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.FillFormat.FillType = FillType.Solid;
    shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

    // Acento 4, mais escuro 25%
    IShape shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.FillFormat.FillType = FillType.Solid;
    shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Acento 4, mais escuro 50%
    IShape shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.FillFormat.FillType = FillType.Solid;
    shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.Save("example.pptx", SaveFormat.Pptx);
}
```

### **Mapear `SchemeColor` para Cores `IColorScheme`**

Quando você trabalha com [SchemeColor](https://reference.aspose.com/slides/pt/net/aspose.slides/schemecolor/), pode notar que ele contém os seguintes valores de cor de tema: `Background1`, `Background2`, `Text1` e `Text2`.

No entanto, `Presentation.MasterTheme.ColorScheme` retorna [IColorScheme](https://reference.aspose.com/slides/pt/net/aspose.slides.theme/icolorscheme/), que expõe as cores correspondentes como: `Dark1`, `Dark2`, `Light1` e `Light2`.

Essa diferença está apenas no nome. Esses valores referem‑se aos mesmos slots de cores de tema e o mapeamento é fixo:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Não há conversão dinâmica entre `Text`/`Background` e `Dark`/`Light`. Elas são simplesmente nomes alternativos para as mesmas cores de tema.

Essa diferença de nomenclatura vem da terminologia do Microsoft Office. Versões antigas do Office usavam `Dark 1`, `Light 1`, `Dark 2` e `Light 2`, enquanto versões mais recentes da interface exibem os mesmos slots como `Text 1`, `Background 1`, `Text 2` e `Background 2`.

## **Alterar Fonte do Tema**

Para permitir que você selecione fontes para temas e outros propósitos, o Aspose.Slides utiliza esses identificadores especiais (semelhantes aos usados no PowerPoint):

* **+mn-lt** - Fonte do Corpo Latin (Minor Latin Font)
* **+mj-lt** - Fonte de Cabeçalho Latin (Major Latin Font)
* **+mn-ea** - Fonte do Corpo East Asian (Minor East Asian Font)
* **+mj-ea** - Fonte do Corpo East Asian (Minor East Asian Font)

Este código C# mostra como atribuir a fonte Latin a um elemento do tema:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    Paragraph paragraph = new Paragraph();

    Portion portion = new Portion("Theme text format");

    paragraph.Portions.Add(portion);

    shape.TextFrame.Paragraphs.Add(paragraph);

    portion.PortionFormat.LatinFont = new FontData("+mn-lt");
}
```

Este código C# mostra como alterar a fonte do tema da apresentação:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    pres.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");
}
```

A fonte em todas as caixas de texto será atualizada.

{{% alert color="info" title="TIP" %}} 
Talvez você queira ver [PowerPoint fonts](/slides/pt/net/powerpoint-fonts/).
{{% /alert %}}

## **Alterar Estilo de Fundo do Tema**

Por padrão, o aplicativo PowerPoint fornece 12 fundos predefinidos, mas apenas 3 desses 12 fundos são salvos em uma apresentação típica.

![todo:image_alt_text](presentation-design_8.png)

Por exemplo, depois de salvar uma apresentação no aplicativo PowerPoint, você pode executar este código C# para descobrir o número de fundos predefinidos na apresentação:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))

{
    int numberOfBackgroundFills = pres.MasterTheme.FormatScheme.BackgroundFillStyles.Count;

    Console.WriteLine($"Number of background fill styles for theme is {numberOfBackgroundFills}");
}
```

{{% alert color="warning" %}} 
Usando a propriedade [BackgroundFillStyles](https://reference.aspose.com/slides/pt/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) da classe [FormatScheme](https://reference.aspose.com/slides/pt/net/aspose.slides.theme/formatscheme/), você pode adicionar ou acessar o estilo de fundo em um tema do PowerPoint. 
{{% /alert %}}

Este código C# mostra como definir o fundo para uma apresentação:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Masters[0].Background.StyleIndex = 2;
}
```

**Guia de índices**: 0 é usado para sem preenchimento. O índice começa em 1.

{{% alert color="info" title="TIP" %}} 
Talvez você queira ver [PowerPoint Background](/slides/pt/net/presentation-background/).
{{% /alert %}}

## **Alterar Efeito do Tema**

Um tema do PowerPoint geralmente contém 3 valores para cada matriz de estilo. Essas matrizes são combinadas nesses 3 efeitos: sutil, moderado e intenso. Por exemplo, este é o resultado quando os efeitos são aplicados a uma forma específica:

![todo:image_alt_text](presentation-design_10.png)

Usando 3 propriedades ([FillStyles](https://reference.aspose.com/slides/pt/net/aspose.slides.theme/formatscheme/fillstyles), [LineStyles](https://reference.aspose.com/slides/pt/net/aspose.slides.theme/formatscheme/linestyles), [EffectStyles](https://reference.aspose.com/slides/pt/net/aspose.slides.theme/formatscheme/effectstyles)) da classe [FormatScheme](https://reference.aspose.com/slides/pt/net/aspose.slides.theme/formatscheme) você pode alterar os elementos em um tema (de forma ainda mais flexível que as opções no PowerPoint).

Este código C# mostra como alterar um efeito de tema alterando partes dos elementos:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx"))
{
    pres.MasterTheme.FormatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;

    pres.MasterTheme.FormatScheme.FillStyles[2].FillType = FillType.Solid;

    pres.MasterTheme.FormatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;

    pres.MasterTheme.FormatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

    pres.Save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
}
```

As mudanças resultantes em cor de preenchimento, tipo de preenchimento, efeito de sombra, etc:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

### Posso aplicar um tema a um único slide sem alterar o mestre?

Sim. O Aspose.Slides oferece substituições de tema a nível de slide, permitindo que você aplique um tema local apenas a esse slide enquanto mantém o tema mestre intacto (através do [SlideThemeManager](https://reference.aspose.com/slides/pt/net/aspose.slides.theme/slidethememanager/)).

### Qual é a maneira mais segura de transferir um tema de uma apresentação para outra?

[Clone slides](/slides/pt/net/clone-slides/) junto com seu mestre na apresentação de destino. Isso preserva o mestre original, os layouts e o tema associado, de modo que a aparência permaneça consistente.

### Como posso ver os valores "efetivos" após toda a herança e substituições?

Use as ["effective" views](/slides/pt/net/shape-effective-properties/) da API para tema/cor/fonte/efeito. Elas retornam as propriedades resolvidas e finais após a aplicação do mestre mais quaisquer substituições locais.