---
title: Gerenciar Temas de Apresentação em JavaScript
linktitle: Tema de Apresentação
type: docs
weight: 10
url: /pt/nodejs-java/presentation-theme/
keywords:
- tema PowerPoint
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Domine os temas de apresentação em JavaScript com Aspose.Slides para Node.js para criar, personalizar e converter arquivos PowerPoint com identidade visual consistente."
---
## **Introdução**

Um tema de apresentação define as propriedades dos elementos de design. Quando você seleciona um tema de apresentação, está essencialmente escolhendo um conjunto específico de elementos visuais e suas propriedades.

No PowerPoint, um tema compreende cores, [fontes](/slides/pt/nodejs-java/powerpoint-fonts/), [estilos de plano de fundo](/slides/pt/nodejs-java/presentation-background/), e efeitos.

![theme-constituents](theme-constituents.png)

## **Alterar cor do tema**

Um tema do PowerPoint usa um conjunto específico de cores para diferentes elementos em um slide. Se você não gostar das cores, pode alterá‑las aplicando novas cores ao tema. Para permitir que você selecione uma nova cor de tema, o Aspose.Slides fornece valores na enumeração [SchemeColor](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SchemeColor).

Este código JavaScript mostra como alterar a cor de destaque de um tema:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Você pode determinar o valor efetivo da cor resultante desta forma:

```javascript
var fillEffective = shape.getFillFormat().getEffective();
var effectiveColor = fillEffective.getSolidFillColor();
console.log(java.callStaticMethodSync("java.lang.String", "format", "Color [A=%d, R=%d, G=%d, B=%d]", effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```

Para demonstrar ainda mais a operação de alteração de cor, criamos outro elemento e atribuímos a cor de destaque (da operação inicial) a ele. Em seguida, alteramos a cor no tema:

```javascript
var otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 120, 100, 100);
otherShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
otherShape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
pres.getMasterTheme().getColorScheme().getAccent4().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
```

A nova cor é aplicada automaticamente em ambos os elementos.

### **Definir cor do tema a partir de paleta adicional**

Quando você aplica transformações de luminância à cor principal do tema(1), são formadas cores da paleta adicional(2). Você pode então definir e obter essas cores de tema.

![additional-palette-colors](additional-palette-colors.png)

**1** - Cores principais do tema  
**2** - Cores da paleta adicional.

Este código JavaScript demonstra uma operação onde cores da paleta adicional são obtidas a partir da cor principal do tema e então usadas em formas:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    // Accent 4
    var shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    // Accent 4, Mais claro 80%
    var shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.2);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.8);
    // Accent 4, Mais claro 60%
    var shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.6);
    // Accent 4, Mais claro 40%
    var shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.6);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.4);
    // Accent 4, Mais escuro 25%
    var shape5 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.75);
    // Accent 4, Mais escuro 50%
    var shape6 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.5);
    presentation.save(path + "example_accent4.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

### **Mapear `SchemeColor` para cores `ColorScheme`**

Ao trabalhar com [SchemeColor](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/schemecolor/), você pode notar que ele contém os seguintes valores de cor de tema:

`Background1`, `Background2`, `Text1` e `Text2`.

No entanto, `Presentation.getMasterTheme().getColorScheme()` retorna [ColorScheme](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/colorscheme/), que expõe as cores correspondentes como:

`Dark1`, `Dark2`, `Light1` e `Light2`.

Essa diferença está apenas nos nomes. Esses valores referem‑se aos mesmos slots de cor de tema e o mapeamento é fixo:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Não há conversão dinâmica entre `Text`/`Background` e `Dark`/`Light`. Eles são simplesmente nomes alternativos para as mesmas cores de tema.

Essa diferença de nomenclatura vem da terminologia do Microsoft Office. Versões antigas do Office usavam `Dark 1`, `Light 1`, `Dark 2` e `Light 2`, enquanto versões mais recentes da interface exibem os mesmos slots como `Text 1`, `Background 1`, `Text 2` e `Background 2`.

## **Alterar fonte do tema**

Para permitir que você selecione fontes para temas e outros fins, o Aspose.Slides usa esses identificadores especiais (semelhantes aos usados no PowerPoint):

* **+mn-lt** - Fonte do corpo Latin (Minor Latin Font)
* **+mj-lt** - Fonte de título Latin (Major Latin Font)
* **+mn-ea** - Fonte do corpo East Asian (Minor East Asian Font)
* **+mj-ea** - Fonte do corpo East Asian (Major East Asian Font)

Este código JavaScript mostra como atribuir a fonte Latin a um elemento de tema:

```javascript
var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
var paragraph = new aspose.slides.Paragraph();
var portion = new aspose.slides.Portion("Theme text format");
paragraph.getPortions().add(portion);
shape.getTextFrame().getParagraphs().add(paragraph);
portion.getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));
```

Este código JavaScript mostra como alterar a fonte do tema da apresentação:

```javascript
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Arial"));
```

A fonte em todas as caixas de texto será atualizada.

{{% alert color="primary" title="DICA" %}} 
Você pode querer ver [fontes do PowerPoint](/slides/pt/nodejs-java/powerpoint-fonts/).
{{% /alert %}}

## **Alterar estilo de plano de fundo do tema**

Por padrão, o aplicativo PowerPoint fornece 12 planos de fundo predefinidos, mas apenas 3 desses 12 são salvos em uma apresentação típica.

![todo:image_alt_text](presentation-design_8.png)

Por exemplo, depois de salvar uma apresentação no aplicativo PowerPoint, você pode executar este código JavaScript para descobrir o número de planos de fundo predefinidos na apresentação:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();
    console.log("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="warning" %}} 
Usando a propriedade [BackgroundFillStyles](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) da classe [FormatScheme](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/FormatScheme), você pode adicionar ou acessar o estilo de plano de fundo em um tema do PowerPoint.
{{% /alert %}} 

Este código JavaScript mostra como definir o plano de fundo para uma apresentação:

```javascript
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**Guia de índices**: 0 é usado para sem preenchimento. O índice começa em 1.

{{% alert color="primary" title="DICA" %}} 
Você pode querer ver [plano de fundo do PowerPoint](/slides/pt/nodejs-java/presentation-background/).
{{% /alert %}}

## **Alterar efeito do tema**

Um tema do PowerPoint geralmente contém 3 valores para cada array de estilo. Esses arrays são combinados nesses 3 efeitos: sutil, moderado e intenso. Por exemplo, este é o resultado quando os efeitos são aplicados a uma forma específica:

![todo:image_alt_text](presentation-design_10.png)

Usando 3 propriedades ([FillStyles](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/FormatScheme#getEffectStyles--)) da classe [FormatScheme](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/FormatScheme) você pode alterar os elementos em um tema (ainda mais flexivelmente que as opções no PowerPoint).

Este código JavaScript mostra como alterar um efeito de tema alterando partes dos elementos:

```javascript
var pres = new aspose.slides.Presentation("Subtle_Moderate_Intense.pptx");
try {
    pres.getMasterTheme().getFormatScheme().getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).setFillType(java.newByte(aspose.slides.FillType.Solid));
    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    pres.getMasterTheme().getFormatScheme().getEffectStyles().get_Item(2).getEffectFormat().getOuterShadowEffect().setDistance(10.0);
    pres.save("Design_04_Subtle_Moderate_Intense-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

As alterações resultantes em cor de preenchimento, tipo de preenchimento, efeito de sombra, etc.:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**Posso aplicar um tema a um único slide sem mudar o mestre?**

Sim. O Aspose.Slides suporta substituições de tema em nível de slide, de modo que você pode aplicar um tema local apenas àquele slide enquanto mantém o tema mestre intacto (via o [SlideThemeManager](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slidethememanager/)).

**Qual é a maneira mais segura de transferir um tema de uma apresentação para outra?**

[Clone slides](/slides/pt/nodejs-java/clone-slides/) junto com seu mestre para a apresentação de destino. Isso preserva o mestre original, layouts e o tema associado para que a aparência permaneça consistente.

**Como posso ver os valores "efetivos" após toda a herança e substituições?**

Use as visualizações ["efetivas"](/slides/pt/nodejs-java/shape-effective-properties/) para tema/cor/fonte/efeito. Essas retornam as propriedades resolvidas, finais após aplicar o mestre mais quaisquer substituições locais.