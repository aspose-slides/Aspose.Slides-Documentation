---
title: Gerenciar Temas de Apresentação em Java
linktitle: Tema de Apresentação
type: docs
weight: 10
url: /pt/java/presentation-theme/
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
- Java
- Aspose.Slides
description: "Domine os temas de apresentação no Aspose.Slides para Java para criar, personalizar e converter arquivos PowerPoint com identidade visual consistente."
---
## **Introdução**

Um tema de apresentação define as propriedades dos elementos de design. Ao selecionar um tema de apresentação, você está essencialmente escolhendo um conjunto específico de elementos visuais e suas propriedades.

No PowerPoint, um tema compreende cores, [fontes](/slides/pt/java/powerpoint-fonts/), [estilos de plano de fundo](/slides/pt/java/presentation-background/) e efeitos.

![componentes-do-tema](theme-constituents.png)

## **Alterar Cor do Tema**

Um tema do PowerPoint usa um conjunto específico de cores para diferentes elementos em um slide. Se você não gostar das cores, pode alterá‑las aplicando novas cores ao tema. Para permitir que você selecione uma nova cor de tema, o Aspose.Slides fornece valores na enumeração [SchemeColor](https://reference.aspose.com/slides/pt/java/com.aspose.slides/SchemeColor).

Este código Java mostra como alterar a cor de destaque de um tema:

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
} finally {
    if (pres != null) pres.dispose();
}
```

Você pode determinar o valor efetivo da cor resultante desta forma:

```java
IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

Color effectiveColor = fillEffective.getSolidFillColor();

System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d]", 
        effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```

Para demonstrar ainda mais a operação de alteração de cor, criamos outro elemento e atribuimos a ele a cor de destaque (da operação inicial). Em seguida, alteramos a cor no tema:

```java
IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.getFillFormat().setFillType(FillType.Solid);

otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
```

A nova cor é aplicada automaticamente em ambos os elementos.

### **Definir Cor do Tema a partir de uma Paleta Adicional**

Ao aplicar transformações de luminância à cor principal do tema(1), são formadas cores da paleta adicional(2). Você pode então definir e obter essas cores do tema. 

![cores-da-paleta-adicional](additional-palette-colors.png)

**1** - Cores principais do tema  
**2** - Cores da paleta adicional.

Este código Java demonstra uma operação em que cores da paleta adicional são obtidas a partir da cor principal do tema e então usadas em formas:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Acento 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // Acento 4, mais claro 80%
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // Acento 4, mais claro 60%
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // Acento 4, mais claro 40%
    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    // Acento 4, mais escuro 25%
    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Acento 4, mais escuro 50%
    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save(path + "example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **Mapear `SchemeColor` para Cores `IColorScheme`**

Quando você trabalha com [SchemeColor](https://reference.aspose.com/slides/pt/java/com.aspose.slides/schemecolor/), pode notar que ele contém os seguintes valores de cor de tema: `Background1`, `Background2`, `Text1` e `Text2`.

Entretanto, `Presentation.getMasterTheme().getColorScheme()` retorna [IColorScheme](https://reference.aspose.com/slides/pt/java/com.aspose.slides/icolorscheme/), que expõe as cores correspondentes como: `Dark1`, `Dark2`, `Light1` e `Light2`.

Essa diferença está apenas no nome. Esses valores referem‑se aos mesmos slots de cor do tema e o mapeamento é fixo:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Não há conversão dinâmica entre `Text`/`Background` e `Dark`/`Light`. Elas são simplesmente nomes alternativos para as mesmas cores do tema.

Essa diferença de nomenclatura vem da terminologia do Microsoft Office. Versões antigas do Office usavam `Dark 1`, `Light 1`, `Dark 2` e `Light 2`, enquanto versões mais recentes da interface exibem os mesmos slots como `Text 1`, `Background 1`, `Text 2` e `Background 2`.

## **Alterar Fonte do Tema**

Para permitir que você selecione fontes para temas e outros fins, o Aspose.Slides usa esses identificadores especiais (semelhantes aos usados no PowerPoint):

* **+mn-lt** - Fonte Corporal Latin (Fonte Latin Menor)
* **+mj-lt** - Fonte de Título Latin (Fonte Latin Maior)
* **+mn-ea** - Fonte Corporal East Asian (Fonte East Asian Menor)
* **+mj-ea** - Fonte de Título East Asian (Fonte East Asian Maior)

Este código Java mostra como atribuir a fonte Latin a um elemento do tema:

```java
IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.getPortions().add(portion);

shape.getTextFrame().getParagraphs().add(paragraph);

portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
```

Este código Java mostra como alterar a fonte do tema da apresentação:

```java
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
```

A fonte em todas as caixas de texto será atualizada.

{{% alert color="primary" title="TIP" %}} 
Você pode querer ver [fontes do PowerPoint](/slides/pt/java/powerpoint-fonts/).
{{% /alert %}}

## **Alterar Estilo de Fundo do Tema**

Por padrão, o aplicativo PowerPoint fornece 12 fundos predefinidos, mas apenas 3 desses 12 fundos são salvos em uma apresentação típica. 

![todo:image_alt_text](presentation-design_8.png)

Por exemplo, depois de salvar uma apresentação no aplicativo PowerPoint, você pode executar este código Java para descobrir o número de fundos predefinidos na apresentação:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    int numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();

    System.out.println("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 
Usando a propriedade [BackgroundFillStyles](https://reference.aspose.com/slides/pt/java/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) da classe [FormatScheme](https://reference.aspose.com/slides/pt/java/com.aspose.slides/FormatScheme), você pode adicionar ou acessar o estilo de fundo em um tema do PowerPoint. 
{{% /alert %}} 

Este código Java mostra como definir o fundo para uma apresentação:

```java
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**Guia de Índice**: 0 é usado para sem preenchimento. O índice começa em 1.

{{% alert color="primary" title="TIP" %}} 
Você pode querer ver [Fundo do PowerPoint](/slides/pt/java/presentation-background/).
{{% /alert %}}

## **Alterar Efeito do Tema**

Um tema do PowerPoint geralmente contém 3 valores para cada matriz de estilo. Essas matrizes são combinadas nesses 3 efeitos: sutil, moderado e intenso. Por exemplo, este é o resultado quando os efeitos são aplicados a uma forma específica:

![todo:image_alt_text](presentation-design_10.png)

Usando 3 propriedades ([FillStyles](https://reference.aspose.com/slides/pt/java/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/pt/java/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/pt/java/com.aspose.slides/FormatScheme#getEffectStyles--)) da classe [FormatScheme](https://reference.aspose.com/slides/pt/java/com.aspose.slides/FormatScheme), você pode alterar os elementos de um tema (de forma ainda mais flexível que as opções do PowerPoint).

Este código Java mostra como alterar um efeito de tema alterando partes dos elementos:

```java
Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    pres.getMasterTheme().getFormatScheme().getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);

    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).setFillType(FillType.Solid);

    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).getSolidFillColor().setColor(Color.GREEN);

    pres.getMasterTheme().getFormatScheme().getEffectStyles().get_Item(2).getEffectFormat().getOuterShadowEffect().setDistance(10f);

    pres.save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

As mudanças resultantes na cor de preenchimento, tipo de preenchimento, efeito de sombra, etc:

![todo:image_alt_text](presentation-design_11.png)

## **Perguntas Frequentes**

**Posso aplicar um tema a um único slide sem alterar o mestre?**

Sim. O Aspose.Slides suporta substituições de tema ao nível do slide, permitindo que você aplique um tema local apenas a esse slide enquanto mantém o tema mestre intacto (por meio do [SlideThemeManager](https://reference.aspose.com/slides/pt/java/com.aspose.slides/slidethememanager/)).

**Qual é a maneira mais segura de transferir um tema de uma apresentação para outra?**

[Clonar slides](/slides/pt/java/clone-slides/) junto com seu mestre na apresentação de destino. Isso preserva o mestre original, os layouts e o tema associado, de modo que a aparência permaneça consistente.

**Como posso ver os valores "efetivos" após toda a herança e sobrescritas?**

Use as [visões efetivas](/slides/pt/java/shape-effective-properties/) da API para tema/cor/fonte/efeito. Elas retornam as propriedades resolvidas e finais após a aplicação do mestre e quaisquer sobrescritas locais.