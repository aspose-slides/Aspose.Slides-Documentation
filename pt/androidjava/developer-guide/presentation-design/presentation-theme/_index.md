---
title: Gerenciar Temas de Apresentação no Android
linktitle: Tema da Apresentação
type: docs
weight: 10
url: /pt/androidjava/presentation-theme/
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
- Android
- Java
- Aspose.Slides
description: "Domine os temas de apresentação no Aspose.Slides para Android via Java para criar, personalizar e converter arquivos PowerPoint com identidade visual consistente."
---
## **Introdução**

Um tema de apresentação define um conjunto coordenado de cores, fontes, estilos de plano de fundo, preenchimentos, linhas e efeitos. Objetos compatíveis com temas referem‑se a essas definições compartilhadas em vez de armazenar cada propriedade visual como um valor fixo, de modo que uma mudança de tema possa atualizar muitos objetos de uma vez.

No Aspose.Slides, o tema de nível de apresentação está disponível através de [Presentation.getMasterTheme](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/). Uma apresentação também pode conter substituições de tema em níveis mais baixos. Um mestre pode substituir o tema da apresentação através de [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/masterthememanager/), enquanto um layout ou um slide individual pode substituir o tema herdado através de [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/baseoverridethememanager/). Na prática, o tema efetivo para um slide é resolvido por meio desta cadeia de herança: tema da apresentação, substituição do mestre, substituição do layout e substituição do slide.

![Componentes do tema: cores, fontes, estilos de plano de fundo e efeitos](theme-constituents.png)

As seções abaixo mostram os fluxos de trabalho de tema mais comuns: inspeccionar um tema, alterar cores e fontes, copiar ou aplicar um tema, atualizar estilos de plano de fundo e efeitos, e ler valores efetivos após a herança e as substituições serem resolvidas.

## **Inspecionar um Tema**

O objeto [MasterTheme](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/mastertheme/) expõe o esquema de cores, o esquema de fontes e o esquema de formatos do tema por meio de [MasterTheme.getColorScheme](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/mastertheme/) e [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/mastertheme/). Inspecionar essas coleções antes de alterá‑las é especialmente útil quando uma apresentação vem de uma fonte externa, pois o número e o conteúdo das entradas de estilo podem variar.

O exemplo a seguir lê as principais propriedades do tema e relata quantos estilos de plano de fundo, preenchimento, linha e efeito estão armazenados no tema:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterTheme theme = presentation.getMasterTheme();
    int accent1 = theme.getColorScheme().getAccent1().getColor();
    System.out.println("Theme name: " + theme.getName());
    System.out.println(String.format("Accent 1: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(accent1), Color.red(accent1), Color.green(accent1), Color.blue(accent1)));
    System.out.println("Major Latin font: " + theme.getFontScheme().getMajor().getLatinFont().getFontName());
    System.out.println("Minor Latin font: " + theme.getFontScheme().getMinor().getLatinFont().getFontName());
    System.out.println("Background fill styles: " + theme.getFormatScheme().getBackgroundFillStyles().size());
    System.out.println("Fill styles: " + theme.getFormatScheme().getFillStyles().size());
    System.out.println("Line styles: " + theme.getFormatScheme().getLineStyles().size());
    System.out.println("Effect styles: " + theme.getFormatScheme().getEffectStyles().size());
} finally {
    presentation.dispose();
}
```

Se um arquivo usa vários mestres, não presuma que cada slide tem o mesmo tema efetivo. Inspecione o mestre associado ao slide e use o fluxo de trabalho de tema efetivo mostrado mais adiante neste artigo quando substituições de layout ou slide puderem estar presentes.

## **Alterar Cores do Tema**

Preenchimentos, linhas e texto compatíveis com tema podem referir‑se a uma cor lógica da enumeração [SchemeColor](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/schemecolor/). Quando você altera a entrada correspondente em [IColorScheme](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/icolorscheme/), todos os objetos que ainda referenciam aquela cor de tema são resolvidos contra o novo valor. Objetos que utilizam uma cor RGB direta não são alterados por uma atualização de cor de tema.

O exemplo completo a seguir cria uma forma que usa `Accent4`, altera a cor `Accent4` do tema para vermelho, salva a apresentação, reabre‑a e imprime a cor de preenchimento efetiva:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
    presentation.save("theme-color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation savedPresentation = new Presentation("theme-color.pptx");
try {
    ISlide savedSlide = savedPresentation.getSlides().get_Item(0);
    IShape savedShape = savedSlide.getShapes().get_Item(0);
    IFillFormatEffectiveData effectiveFill = savedShape.getFillFormat().getEffective();
    int effectiveColor = effectiveFill.getSolidFillColor();
    System.out.println(String.format("Effective fill color: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(effectiveColor), Color.red(effectiveColor), Color.green(effectiveColor), Color.blue(effectiveColor)));
} finally {
    savedPresentation.dispose();
}
```

Como o retângulo permanece vinculado a `Accent4`, sua cor visível torna‑se vermelha após a mudança do tema. Se você substituir a cor do esquema por uma cor direta na forma, alterações posteriores em `Accent4` não afetarão mais esse preenchimento.

### **Usar Cores da Paleta Adicional**

O PowerPoint deriva variantes mais claras e mais escuras a partir de uma cor de tema aplicando transformações de cor. O Aspose.Slides expõe essas transformações por meio da enumeração [ColorTransformOperation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/colortransformoperation/).

![Cores principais do tema e cores mais claras e mais escuras geradas a partir da paleta adicional](additional-palette-colors.png)

**1** - Cores principais do tema.

**2** - Variantes mais claras e mais escuras produzidas a partir das cores principais do tema.

O exemplo a seguir cria seis retângulos baseados em `Accent4`, aplica transformações de luminância a cinco deles e salva o resultado:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save("theme-color-palette.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Essas variantes permanecem baseadas na cor do tema. Se `Accent4` for alterado posteriormente, as cores transformadas são recalculadas a partir do novo valor de `Accent4`.

### **Mapear Valores `SchemeColor` para Slots `IColorScheme`**

A enumeração [SchemeColor](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/schemecolor/) usa `Text1`, `Background1`, `Text2` e `Background2`, enquanto [IColorScheme](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/icolorscheme/) expõe os mesmos slots de tema como `Dark1`, `Light1`, `Dark2` e `Light2`. O mapeamento é fixo:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Esses são nomes alternativos para os mesmos slots de tema; não são valores convertidos dinamicamente de uma forma para outra.

## **Alterar Fontes do Tema**

Um esquema de fontes do tema contém um conjunto de fontes principal para títulos e um conjunto menor para texto de corpo. Os métodos [IFontScheme.getMajor](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ifontscheme/) e [IFontScheme.getMinor](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ifontscheme/) expõem esses conjuntos.

Identificadores de fontes de tema compatíveis com PowerPoint podem ser usados na formatação de texto:

* `+mn-lt` - Fonte do Corpo Latin (Minor Latin Font)
* `+mj-lt` - Fonte de Título Latin (Major Latin Font)
* `+mn-ea` - Fonte do Corpo East Asian (Minor East Asian Font)
* `+mj-ea` - Fonte de Título East Asian (Major East Asian Font)

O exemplo a seguir cria um título que usa a fonte Latin principal do tema e uma linha de corpo que usa a fonte Latin menor do tema. Em seguida, altera as fontes do tema e salva o resultado:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 500, 60);
    heading.getTextFrame().setText("Theme heading");
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData("+mj-lt"));

    IAutoShape body = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 120, 500, 60);
    body.getTextFrame().setText("Theme body text");
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData("+mn-lt"));

    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(new FontData("Aptos Display"));
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
    presentation.save("theme-fonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O título segue a fonte principal e o texto do corpo segue a fonte menor. Texto que tem um nome de fonte explícito em vez de um identificador de tema não mudará automaticamente quando o esquema de fontes do tema mudar.

{{% alert color="info" title="Tip" %}}
Para mais informações sobre fontes em apresentações, veja [PowerPoint Fonts](/slides/pt/androidjava/powerpoint-fonts/).
{{% /alert %}}

## **Copiar ou Aplicar um Tema**

Existem dois fluxos de trabalho comuns, e eles resolvem problemas diferentes.

### **Preservar um Tema de Origem ao Mover Slides**

Se você quiser mover um slide para outra apresentação e preservar seu design original, clone o mestre de origem na apresentação de destino com [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/imasterslidecollection/), depois clone o slide com [ISlideCollection.addClone](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islidecollection/) e o mestre clonado. Isso transporta o mestre, seus layouts e o tema associado juntos.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide sourceSlide = source.getSlides().get_Item(0);
        IMasterSlide sourceMaster = sourceSlide.getLayoutSlide().getMasterSlide();
        IMasterSlide clonedMaster = target.getMasters().addClone(sourceMaster);
        target.getSlides().addClone(sourceSlide, clonedMaster, true);
        target.save("theme-preserved.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Este é o fluxo de trabalho preferido quando o slide de origem deve ter a mesma aparência no destino. simplesmente clonar conteúdo em um mestre de destino não relacionado pode mudar cores, fontes, planos de fundo e efeitos acionados por tema.

### **Aplicar Valores de Tema a um Slide Existente**

Se o slide de destino deve permanecer no seu mestre e layout atuais, inicialize uma substituição de nível de slide a partir do tema de origem. Os métodos [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/overridetheme/) e [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/overridetheme/) copiam os três principais componentes do tema para a substituição.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = target.getSlides().get_Item(0);
        IOverrideTheme overrideTheme = targetSlide.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(source.getMasterTheme().getColorScheme());
        overrideTheme.initFontSchemeFrom(source.getMasterTheme().getFontScheme());
        overrideTheme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme());
        target.save("theme-applied-to-slide.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Isso altera o tema usado por esse slide sem mudar o tema herdado por outros slides. Para remover a substituição local e retornar aos valores herdados, chame [OverrideTheme.clear](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/overridetheme/).

### **Aplicar uma Substituição de Tema a um Layout**

Uma substituição de nível de layout aplica‑se a slides que usam esse layout, a menos que um slide específico tenha sua própria substituição. Os mesmos métodos de inicialização podem ser usados através de [LayoutSlideThemeManager](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/layoutslidethememanager/):

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = target.getSlides().get_Item(0);
        ILayoutSlide targetLayout = targetSlide.getLayoutSlide();
        IOverrideTheme overrideTheme = targetLayout.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(source.getMasterTheme().getColorScheme());
        overrideTheme.initFontSchemeFrom(source.getMasterTheme().getFontScheme());
        overrideTheme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme());
        target.save("theme-applied-to-layout.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Use um tema de nível de mestre ou apresentação quando muitos layouts e slides devem compartilhar o mesmo design base, uma substituição de layout quando uma família de layouts precisa de estilização diferente e uma substituição de slide apenas para exceções reais. Substituições excessivas de nível de slide dificultam a previsão de alterações globais de tema posteriores.

## **Atualizar Estilos de Plano de Fundo do Tema**

Os preenchimentos de plano de fundo do tema são armazenados em [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iformatscheme/). O PowerPoint pode apresentar mais opções de plano de fundo em sua interface do que o número de definições de preenchimento fisicamente armazenadas nesta coleção, pois a UI pode combinar preenchimentos de tema com cores de tema e outras referências de estilo.

![Galeria de estilos de plano de fundo do PowerPoint para um tema de apresentação](presentation-design_8.png)

Antes de usar um estilo de plano de fundo, inspecione a coleção armazenada e o índice de estilo atual em [Background.getStyleIndex](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/background/). Um índice de estilo `0` significa que não há preenchimento temático; valores positivos são referências a estilos de plano de fundo do tema. Isso difere da indexação direta da coleção Java, onde `get_Item(0)` significa o primeiro item armazenado. Não presuma que cada apresentação contenha o mesmo número de estilos de preenchimento de plano de fundo.

O exemplo a seguir relata a contagem de preenchimentos de plano de fundo disponíveis, atribui uma referência de plano de fundo temático ao primeiro mestre e salva a apresentação:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IFillFormatCollection backgroundStyles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles();
    System.out.println("Background fill styles: " + backgroundStyles.size());
    if (backgroundStyles.size() == 0) {
        throw new IllegalStateException("The presentation theme does not contain background fill styles.");
    }

    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    masterSlide.getBackground().setType(BackgroundType.Themed);
    masterSlide.getBackground().setStyleIndex(1);
    presentation.save("theme-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado visível depende da entrada de tema referenciada pelo mestre e de quaisquer substituições de plano de fundo no nível de layout ou slide. Se um slide usar seu próprio plano de fundo, alterar somente o plano de fundo do mestre pode não mudar esse slide. Use [Background.getEffective](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/background/) quando precisar conhecer o plano de fundo final após a herança ser aplicada.

{{% alert color="warning" title="Warning" %}}
Não trate o índice de estilo como um índice de coleção baseado em zero. Também evite codificar um número de estilo a partir de um arquivo e presumir que ele terá a mesma aparência em outro arquivo; definições de estilo de tema são específicas da apresentação.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Para formatação direta de plano de fundo e herança de plano de fundo, veja [Presentation Background](/slides/pt/androidjava/presentation-background/).
{{% /alert %}}

## **Atualizar Efeitos do Tema**

Um esquema de formatos do tema contém coleções separadas de preenchimento, linha e efeito expostas através de [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iformatscheme/) e [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iformatscheme/). Temas típicos do Office costumam conter três entradas principais que correspondem visualmente a formatações sutil, moderada e intensa, mas o código deve inspecionar cada coleção em vez de presumir uma contagem fixa.

![Efeitos sutis, moderados e intensos do tema aplicados à mesma forma](presentation-design_10.png)

Ao acessar essas coleções em Java, o índice da coleção é baseado em zero: `get_Item(0)` é o primeiro estilo armazenado e `get_Item(2)` é o terceiro. Os índices de referência de estilo de uma forma são um conceito separado, exposto através de [IShapeStyle](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishapestyle/). Modificar um estilo de tema afeta as formas que referenciam esse estilo; formas com formatação direta podem permanecer inalteradas.

O exemplo a seguir verifica se as entradas de estilo necessárias existem, altera o primeiro estilo de linha, altera o terceiro estilo de preenchimento, habilita uma sombra externa no terceiro estilo de efeito e salva o resultado:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    IFormatScheme formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new IllegalStateException("The theme does not contain the style entries required by this example.");
    }
    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid);
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);
    formatScheme.getFillStyles().get_Item(2).setFillType(FillType.Solid);
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(Color.rgb(34, 139, 34));
    IEffectFormat effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10f);
    presentation.save("theme-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para formas que referenciam esses slots, o primeiro estilo de linha do tema torna‑se vermelho, o terceiro estilo de preenchimento do tema torna‑se verde floresta sólido e o terceiro estilo de efeito ganha uma sombra externa com distância de 10 pontos. O resultado visual exato ainda depende de quais slots de estilo cada forma referencia e se a formatação direta substitui o tema.

![Estilos de efeito do tema após alterar configurações de linha, preenchimento e sombra](presentation-design_11.png)

## **Ler Valores Efetivos do Tema**

Objetos de tema brutos mostram o que está definido em um nível específico. Valores efetivos mostram o que um slide ou forma realmente usa após a herança e as substituições locais serem resolvidas. Para um slide, chame [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/baseoverridethememanager/). Para um plano de fundo, use [Background.getEffective](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/background/), e para um preenchimento, use [FillFormat.getEffective](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/fillformat/).

O exemplo a seguir lê o tema efetivo, o plano de fundo e o primeiro preenchimento de forma de um slide:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IThemeEffectiveData effectiveTheme = slide.getThemeManager().createThemeEffective();
    IBackgroundEffectiveData effectiveBackground = slide.getBackground().getEffective();
    System.out.println("Effective major Latin font: " + effectiveTheme.getFontScheme().getMajor().getLatinFont().getFontName());
    System.out.println("Effective minor Latin font: " + effectiveTheme.getFontScheme().getMinor().getLatinFont().getFontName());
    System.out.println("Effective background fill type: " + effectiveBackground.getFillFormat().getFillType());
    if (slide.getShapes().size() > 0) {
        IFillFormatEffectiveData effectiveFill = slide.getShapes().get_Item(0).getFillFormat().getEffective();
        System.out.println("First shape effective fill type: " + effectiveFill.getFillType());
        if (effectiveFill.getFillType() == FillType.Solid) {
            int effectiveColor = effectiveFill.getSolidFillColor();
            System.out.println(String.format("First shape effective fill color: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(effectiveColor), Color.red(effectiveColor), Color.green(effectiveColor), Color.blue(effectiveColor)));
        }
    }
} finally {
    presentation.dispose();
}
```

Use dados efetivos para diagnósticos de renderização, validação e comparações. Se você inspecionar apenas [Presentation.getMasterTheme](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/), pode perder um mestre, layout, slide ou substituição de forma que altera a aparência final.

## **FAQ**

**Posso aplicar um tema a um único slide sem alterar o mestre?**

Sim. Use o [SlideThemeManager](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/slidethememanager/) do slide e inicialize seu tema de substituição. A alteração permanece local a esse slide; os demais slides continuam a herdar seus temas atuais.

**Qual é a maneira mais segura de transportar um tema de uma apresentação para outra?**

Ao mover um slide e preservar sua aparência original, clone o mestre de origem na apresentação de destino e clone o slide com esse mestre usando [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/imasterslidecollection/) e [ISlideCollection.addClone](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islidecollection/). Isso mantém o mestre, os layouts e o tema juntos.

**Como posso ver os valores efetivos após a herança e as substituições?**

Use [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/baseoverridethememanager/) para um tema de slide ou layout e os métodos de dados efetivos correspondentes para objetos de formato, como [Background.getEffective](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/background/) e [FillFormat.getEffective](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/fillformat/). Essas APIs retornam os valores resolvidos após a aplicação da herança e das substituições.