---
title: Gerenciar Temas de Apresentação em JavaScript
linktitle: Tema de Apresentação
type: docs
weight: 10
url: /pt/nodejs-java/presentation-theme/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Domine os temas de apresentação em JavaScript com Aspose.Slides para Node.js para criar, personalizar e converter arquivos PowerPoint com identidade visual consistente."
---
## **Introdução**

Um tema de apresentação define um conjunto coordenado de cores, fontes, estilos de fundo, preenchimentos, linhas e efeitos. Objetos sensíveis ao tema referem‑se a essas definições compartilhadas em vez de armazenar cada propriedade visual como um valor fixo, de modo que uma alteração de tema pode atualizar muitos objetos de uma só vez.

No Aspose.Slides, o tema ao nível da apresentação está disponível através de [Presentation.getMasterTheme](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/getmastertheme/). Uma apresentação também pode conter sobrescritas de tema em níveis mais baixos. Um master pode sobrescrever o tema da apresentação através de [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/masterthememanager/), enquanto um layout ou um slide individual pode sobrescrever seu tema herdado através de [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseoverridethememanager/). Na prática, o tema efetivo para um slide é resolvido através desta cadeia de herança: tema da apresentação, sobrescrita do master, sobrescrita do layout e sobrescrita do slide.

![Componentes do tema: cores, fontes, estilos de fundo e efeitos](theme-constituents.png)

As seções abaixo mostram os fluxos de trabalho mais comuns de tema: inspecionar um tema, alterar cores e fontes, copiar ou aplicar um tema, atualizar estilos de fundo e efeitos, e ler valores efetivos após a herança e sobrescritas serem resolvidas.

## **Inspecionar um Tema**

O objeto [MasterTheme](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mastertheme/) expõe o esquema de cores, esquema de fontes e esquema de formato do tema através de [MasterTheme.getColorScheme](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mastertheme/) e [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mastertheme/). Inspecionar essas coleções antes de alterá‑las é especialmente útil quando uma apresentação vem de uma fonte externa, pois o número e o conteúdo das entradas de estilo podem variar.

O exemplo a seguir lê as propriedades principais do tema e relata quantos estilos de fundo, preenchimento, linha e efeito estão armazenados no tema:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const theme = presentation.getMasterTheme();
    console.log("Theme name: " + theme.getName());
    console.log("Accent 1: " + theme.getColorScheme().getAccent1().getColor());
    console.log("Major Latin font: " + theme.getFontScheme().getMajor().getLatinFont().getFontName());
    console.log("Minor Latin font: " + theme.getFontScheme().getMinor().getLatinFont().getFontName());
    console.log("Background fill styles: " + theme.getFormatScheme().getBackgroundFillStyles().size());
    console.log("Fill styles: " + theme.getFormatScheme().getFillStyles().size());
    console.log("Line styles: " + theme.getFormatScheme().getLineStyles().size());
    console.log("Effect styles: " + theme.getFormatScheme().getEffectStyles().size());
} finally {
    presentation.dispose();
}
```

Se um arquivo usa vários masters, não presuma que cada slide tenha o mesmo tema efetivo. Inspecione o master associado ao slide e use o fluxo de trabalho de tema efetivo mostrado mais adiante neste artigo quando sobrescritas de layout ou slide puderem estar presentes.

## **Alterar Cores do Tema**

Preenchimentos, linhas e texto sensíveis ao tema podem referir‑se a uma cor lógica do enum [SchemeColor](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/schemecolor/). Quando você altera a entrada correspondente no [ColorScheme](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/colorscheme/), todos os objetos que ainda referenciam aquela cor do tema são resolvidos contra o novo valor. Objetos que usam uma cor RGB direta não são alterados por uma atualização de cor de tema.

O exemplo completo a seguir cria uma forma que usa `Accent4`, altera a cor `Accent4` do tema para vermelho, salva a apresentação, reabre‑a e imprime a cor de preenchimento efetiva:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    presentation.save("theme-color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const savedPresentation = new aspose.slides.Presentation("theme-color.pptx");
try {
    const savedSlide = savedPresentation.getSlides().get_Item(0);
    const savedShape = savedSlide.getShapes().get_Item(0);
    const effectiveFill = savedShape.getFillFormat().getEffective();
    console.log("Effective fill color: " + effectiveFill.getSolidFillColor());
} finally {
    savedPresentation.dispose();
}
```

Como o retângulo permanece vinculado ao `Accent4`, sua cor visível torna‑se vermelha após a mudança do tema. Se você substituir a cor do esquema por uma cor direta na forma, alterações posteriores ao `Accent4` não afetarão mais esse preenchimento.

### **Usar Cores da Paleta Adicional**

O PowerPoint deriva variantes mais claras e mais escuras de uma cor de tema aplicando transformações de cor. O Aspose.Slides expõe essas transformações através do enum [ColorTransformOperation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/colortransformoperation/).

![Cores principais do tema e cores mais claras e mais escuras geradas a partir da paleta adicional](additional-palette-colors.png)

**1** - Cores principais do tema.  
**2** - Variantes mais claras e mais escuras produzidas a partir das cores principais do tema.

O exemplo a seguir cria seis retângulos baseados em `Accent4`, aplica transformações de luminância a cinco deles e salva o resultado:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);

    const shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.2));
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.8));

    const shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.4));
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.6));

    const shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.6));
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.4));

    const shape5 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.75));

    const shape6 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.5));

    presentation.save("theme-color-palette.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Essas variantes permanecem baseadas na cor do tema. Se `Accent4` mudar posteriormente, as cores transformadas são recalculadas a partir do novo valor de `Accent4`.

### **Mapear Valores de `SchemeColor` para Slots de `ColorScheme`**

O enum [SchemeColor](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/schemecolor/) usa `Text1`, `Background1`, `Text2` e `Background2`, enquanto o [ColorScheme](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/colorscheme/) expõe os mesmos slots do tema como `Dark1`, `Light1`, `Dark2` e `Light2`. O mapeamento é fixo:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Esses são nomes alternativos para os mesmos slots de tema; não são valores convertidos dinamicamente de uma forma para outra.

## **Alterar Fontes do Tema**

Um esquema de fontes do tema contém um conjunto de fontes principal para títulos e um conjunto de fontes secundário para o corpo do texto. Os métodos [FontScheme.getMajor](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontscheme/) e [FontScheme.getMinor](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontscheme/) expõem esses conjuntos.

Identificadores de fontes de tema compatíveis com PowerPoint podem ser usados na formatação de texto:

* `+mn‑lt` – Fonte do Corpo Latin (Minor Latin Font)
* `+mj‑lt` – Fonte do Título Latin (Major Latin Font)
* `+mn‑ea` – Fonte do Corpo East Asian (Minor East Asian Font)
* `+mj‑ea` – Fonte do Título East Asian (Major East Asian Font)

O exemplo a seguir cria um título que usa a fonte Latin principal do tema e uma linha de corpo que usa a fonte Latin secundária do tema. Em seguida, altera as fontes do tema e salva o resultado:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const heading = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 500, 60);
    heading.getTextFrame().setText("Theme heading");
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new aspose.slides.FontData("+mj-lt"));

    const body = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 120, 500, 60);
    body.getTextFrame().setText("Theme body text");
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));

    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(new aspose.slides.FontData("Aptos Display"));
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Arial"));
    presentation.save("theme-fonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O título segue a fonte principal e o texto do corpo segue a fonte secundária. Texto que possui um nome de fonte explícito em vez de um identificador de tema não mudará automaticamente quando o esquema de fontes do tema mudar.

As coleções de fontes principal e secundária também podem conter mapeamentos de fontes para sistemas de escrita individuais, como cirílico, árabe, japonês, georgiano e thaana. Para inspecionar, adicionar, substituir ou remover esses mapeamentos, veja [Script‑Specific Theme Fonts](/slides/pt/nodejs-java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Para mais informações sobre fontes de apresentação, veja [PowerPoint Fonts](/slides/pt/nodejs-java/powerpoint-fonts/).
{{% /alert %}}

## **Copiar ou Aplicar um Tema**

Existem dois fluxos de trabalho comuns, e eles resolvem problemas diferentes.

### **Preservar um Tema de Origem ao Mover Slides**

Se você quiser mover um slide para outra apresentação e preservar seu design original, clone o master de origem na apresentação de destino com [MasterSlideCollection.addClone](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/masterslidecollection/), então clone o slide com [SlideCollection.addClone](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slidecollection/) e o master clonado. Isso transporta o master, seus layouts e o tema associado juntos.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceSlide = source.getSlides().get_Item(0);
        const clonedMaster = target.getMasters().addClone(sourceSlide.getLayoutSlide().getMasterSlide());
        target.getSlides().addClone(sourceSlide, clonedMaster, true);
        target.save("theme-preserved.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Este é o fluxo de trabalho preferido quando o slide de origem deve ter a mesma aparência no destino. Clonar simplesmente o conteúdo em um master de destino não relacionado pode alterar cores, fontes, fundos e efeitos controlados por tema.

### **Aplicar Valores de Tema a um Slide Existente**

Se o slide de destino deve permanecer no seu master e layout atuais, inicialize uma sobrescrita ao nível do slide a partir do tema de origem. Os métodos [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/overridetheme/) e [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/overridetheme/) copiam os três componentes principais do tema para a sobrescrita.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceTheme = source.getMasterTheme();
        const targetSlide = target.getSlides().get_Item(0);
        const overrideTheme = targetSlide.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(sourceTheme.getColorScheme());
        overrideTheme.initFontSchemeFrom(sourceTheme.getFontScheme());
        overrideTheme.initFormatSchemeFrom(sourceTheme.getFormatScheme());
        target.save("theme-applied-to-slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Isso altera o tema usado por esse slide sem mudar o tema herdado pelos demais slides. Para remover a sobrescrita local e voltar aos valores herdados, chame [OverrideTheme.clear](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/overridetheme/).

### **Aplicar uma Sobrescrita de Tema a um Layout**

Uma sobrescrita ao nível de layout aplica‑se aos slides que usam esse layout, a menos que um slide específico tenha sua própria sobrescrita. Os mesmos métodos de inicialização podem ser usados através do [LayoutSlideThemeManager](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/layoutslidethememanager/):

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceTheme = source.getMasterTheme();
        const targetSlide = target.getSlides().get_Item(0);
        const overrideTheme = targetSlide.getLayoutSlide().getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(sourceTheme.getColorScheme());
        overrideTheme.initFontSchemeFrom(sourceTheme.getFontScheme());
        overrideTheme.initFormatSchemeFrom(sourceTheme.getFormatScheme());
        target.save("theme-applied-to-layout.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Use um tema ao nível de master ou de apresentação quando muitos layouts e slides devem compartilhar o mesmo design base, uma sobrescrita de layout quando uma família de layouts precisar de estilo diferente, e uma sobrescrita de slide apenas para exceções reais. Sobrescritas excessivas ao nível de slide tornam mudanças globais de tema posteriores mais difíceis de prever.

## **Atualizar Estilos de Fundo do Tema**

Os preenchimentos de fundo do tema são armazenados em [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/formatscheme/). O PowerPoint pode apresentar mais opções de fundo em sua interface do que o número de definições de preenchimento armazenadas fisicamente nesta coleção, pois a UI pode combinar preenchimentos de tema com cores de tema e outras referências de estilo.

![Galeria de estilos de fundo do PowerPoint para um tema de apresentação](presentation-design_8.png)

Antes de usar um estilo de fundo, inspecione a coleção armazenada e o índice de estilo atual obtido via [Background.getStyleIndex](httpshttps://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/background/). Um índice de estilo `0` significa que não há preenchimento temático; valores positivos são referências a estilos de fundo temáticos. Isso difere da indexação direta da coleção JavaScript, onde o índice `0` representa o primeiro item armazenado. Não presuma que cada apresentação contenha o mesmo número de estilos de preenchimento de fundo.

O exemplo a seguir relata a quantidade de preenchimentos de fundo disponíveis, atribui uma referência de fundo temático ao primeiro master e salva a apresentação:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const backgroundStyles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles();
    console.log("Background fill styles: " + backgroundStyles.size());
    if (backgroundStyles.size() === 0) {
        throw new Error("The presentation theme does not contain background fill styles.");
    }

    const masterSlide = presentation.getMasters().get_Item(0);
    masterSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.Themed));
    masterSlide.getBackground().setStyleIndex(1);
    presentation.save("theme-background.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado visível depende da entrada de tema referenciada pelo master e de quaisquer sobrescritas de fundo no layout ou no nível do slide. Se um slide usar seu próprio fundo, mudar apenas o fundo do master pode não afetar esse slide. Use [Background.getEffective](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/background/) quando precisar saber o fundo final após a aplicação da herança.

{{% alert color="warning" title="Warning" %}}
Não trate o índice de estilo como um índice de coleção baseado em zero. Também evite codificar um número de estilo de um arquivo e presumir que ele terá a mesma aparência em outro arquivo; definições de estilo de tema são específicas da apresentação.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Para formatação direta de fundo e herança de fundo, veja [Presentation Background](/slides/pt/nodejs-java/presentation-background/).
{{% /alert %}}

## **Atualizar Efeitos do Tema**

Um esquema de formato de tema contém coleções separadas de estilos de preenchimento, linha e efeito expostas através de [FormatScheme.getFillStyles](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/formatscheme/) e [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/formatscheme/). Temas típicos do Office costumam conter três entradas principais de estilo que correspondem visualmente a formatações sutil, moderada e intensa, mas o código deve inspecionar cada coleção em vez de assumir um número fixo.

![Efeitos de tema sutis, moderados e intensos aplicados à mesma forma](presentation-design_10.png)

Ao acessar essas coleções em JavaScript, o índice da coleção é baseado em zero: índice `0` é o primeiro estilo armazenado e índice `2` é o terceiro. Os índices de referência de estilo de uma forma são um conceito separado, exposto via [ShapeStyle](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shapestyle/). Modificar um estilo de tema afeta formas que referenciam esse estilo; formas com formatação direta podem permanecer inalteradas.

O exemplo a seguir verifica se as entradas de estilo necessárias existem, altera o primeiro estilo de linha, altera o terceiro estilo de preenchimento, habilita uma sombra externa no terceiro estilo de efeito e salva o resultado:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("Subtle_Moderate_Intense.pptx");
try {
    const formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new Error("The theme does not contain the style entries required by this example.");
    }

    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    formatScheme.getFillStyles().get_Item(2).setFillType(java.newByte(aspose.slides.FillType.Solid));
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 34, 139, 34));
    const effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10);
    presentation.save("theme-effects.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para formas que referenciam esses slots, o primeiro estilo de linha do tema torna‑se vermelho, o terceiro estilo de preenchimento do tema torna‑se verde floresta sólido, e o terceiro estilo de efeito ganha uma sombra externa com distância de 10 pontos. O resultado visual exato ainda depende de quais slots de estilo cada forma referencia e se a formatação direta sobrescreve o tema.

![Estilos de efeito de tema após alterar linhas, preenchimento e configurações de sombra](presentation-design_11.png)

## **Ler Valores Efetivos do Tema**

Objetos de tema brutos informam o que está definido em um determinado nível. Valores efetivos informam o que um slide ou forma realmente usa após a herança e sobrescritas locais serem resolvidas. Para um slide, chame [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseoverridethememanager/). Para um fundo, use [Background.getEffective](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/background/), e para um preenchimento, use [FillFormat.getEffective](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fillformat/).

O exemplo a seguir lê o tema efetivo, o fundo e o primeiro preenchimento da forma de um slide:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const effectiveTheme = slide.getThemeManager().createThemeEffective();
    const effectiveBackground = slide.getBackground().getEffective();
    console.log("Effective major Latin font: " + effectiveTheme.getFontScheme().getMajor().getLatinFont().getFontName());
    console.log("Effective minor Latin font: " + effectiveTheme.getFontScheme().getMinor().getLatinFont().getFontName());
    console.log("Effective background fill type: " + effectiveBackground.getFillFormat().getFillType());
    if (slide.getShapes().size() > 0) {
        const effectiveFill = slide.getShapes().get_Item(0).getFillFormat().getEffective();
        console.log("First shape effective fill type: " + effectiveFill.getFillType());
        if (effectiveFill.getFillType() === aspose.slides.FillType.Solid) {
            console.log("First shape effective fill color: " + effectiveFill.getSolidFillColor());
        }
    }
} finally {
    presentation.dispose();
}
```

Use dados efetivos para diagnósticos de renderização, validação e comparações. Se você inspecionar apenas [Presentation.getMasterTheme](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/getmastertheme/), pode perder um master, layout, slide ou sobrescrita de forma que altere a aparência final.

## **FAQ**

**Posso aplicar um tema a um único slide sem mudar o master?**

Sim. Use o [SlideThemeManager](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slidethememanager/) do slide e inicialize seu tema de sobrescrita. A mudança permanece local a esse slide; os demais slides continuam a herdar seus temas atuais.

**Qual é a maneira mais segura de transportar um tema de uma apresentação para outra?**

Ao mover um slide e preservar sua aparência original, clone o master de origem na apresentação de destino e clone o slide com esse master usando [MasterSlideCollection.addClone](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/masterslidecollection/) e [SlideCollection.addClone](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slidecollection/). Isso mantém o master, os layouts e o tema juntos.

**Como posso ver os valores efetivos após a herança e sobrescritas?**

Use [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseoverridethememanager/) para um tema de slide ou layout e os métodos de dados efetivos correspondentes para objetos de formato, como [Background.getEffective](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/background/) e [FillFormat.getEffective](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fillformat/). Essas APIs retornam os valores resolvidos após a aplicação de herança e sobrescritas.