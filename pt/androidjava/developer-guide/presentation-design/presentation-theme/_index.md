---
title: Gerenciar Temas de Apresentação no Android
linktitle: Tema de Apresentação
type: docs
weight: 10
url: /pt/androidjava/presentation-theme/
keywords:
- tema do PowerPoint
- tema da apresentação
- tema do slide
- definir tema
- alterar tema
- gerenciar tema
- tema externo
- THMX
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
description: "Domine temas de apresentação no Aspose.Slides para Android via Java para criar, personalizar e converter arquivos PowerPoint com branding consistente."
---
## **Introdução**

Um tema de apresentação define um conjunto coordenado de cores, fontes, estilos de fundo, preenchimentos, linhas e efeitos. Objetos compatíveis com tema referem‑se a essas definições compartilhadas em vez de armazenar cada propriedade visual como um valor fixo, de modo que uma alteração de tema possa atualizar muitos objetos de uma só vez.

No Aspose.Slides, o tema ao nível da apresentação está disponível através de [Presentation.getMasterTheme](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/). Uma apresentação também pode conter substituições de tema em níveis inferiores. Um master pode substituir o tema da apresentação através de [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/masterthememanager/), enquanto um layout ou um slide individual pode substituir seu tema herdado através de [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/baseoverridethememanager/). Na prática, o tema efetivo para um slide é resolvido por essa cadeia de herança: tema da apresentação, substituição do master, substituição do layout e substituição do slide.

![Componentes do tema: cores, fontes, estilos de fundo e efeitos](theme-constituents.png)

As seções a seguir mostram os fluxos de trabalho de tema mais comuns: inspeção de um tema, alteração de cores e fontes, cópia ou aplicação de um tema, atualização de estilos de fundo e efeito, e leitura de valores efetivos após a herança e as substituições terem sido resolvidas.

## **Inspecionar um Tema**

O objeto [MasterTheme](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/mastertheme/) expõe o esquema de cores, o esquema de fontes e o esquema de formatos do tema por meio de [MasterTheme.getColorScheme](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/mastertheme/) e [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/mastertheme/). Inspecionar essas coleções antes de alterá‑las é especialmente útil quando uma apresentação provém de uma fonte externa, pois o número e o conteúdo das entradas de estilo podem variar.

O exemplo a seguir lê as principais propriedades do tema e relata quantos estilos de fundo, preenchimento, linha e efeito estão armazenados no tema:

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

Se um arquivo usar vários masters, não presuma que cada slide tenha o mesmo tema efetivo. Inspecione o master associado ao slide e use o fluxo de trabalho de tema efetivo mostrado mais adiante neste artigo quando substituições de layout ou slide puderem estar presentes.

## **Alterar Cores do Tema**

Preenchimentos, linhas e texto compatíveis com tema podem referir‑se a uma cor lógica da enumeração [SchemeColor](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/schemecolor/). Quando você altera a entrada correspondente em [IColorScheme](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/icolorscheme/), todos os objetos que ainda referenciam aquela cor de tema são resolvidos com o novo valor. Objetos que usam uma cor RGB direta não são alterados por uma atualização de cor de tema.

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

Como o retângulo continua ligado a `Accent4`, sua cor visível torna‑se vermelha após a alteração do tema. Se você substituir a cor do esquema por uma cor direta na forma, alterações posteriores em `Accent4` não afetarão mais esse preenchimento.

### **Usar Cores da Paleta Adicional**

O PowerPoint deriva variantes mais claras e mais escuras de uma cor de tema aplicando transformações de cor. O Aspose.Slides expõe essas transformações por meio da enumeração [ColorTransformOperation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/colortransformoperation/).

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

Essas variantes permanecem baseadas na cor do tema. Se `Accent4` mudar mais tarde, as cores transformadas são recalculadas a partir do novo valor de `Accent4`.

### **Mapear Valores de `SchemeColor` para Slots de `IColorScheme`**

A enumeração [SchemeColor](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/schemecolor/) usa `Text1`, `Background1`, `Text2` e `Background2`, enquanto [IColorScheme](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/icolorscheme/) expõe os mesmos slots de tema como `Dark1`, `Light1`, `Dark2` e `Light2`. O mapeamento é fixo:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Esses são nomes alternativos para os mesmos slots de tema; não são valores convertidos dinamicamente de uma forma para outra.

## **Alterar Fontes do Tema**

Um esquema de fontes de tema contém um conjunto de fontes principal para títulos e um conjunto secundário para texto de corpo. Os métodos [IFontScheme.getMajor](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ifontscheme/) e [IFontScheme.getMinor](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ifontscheme/) expõem esses conjuntos.

Identificadores de fontes de tema compatíveis com PowerPoint podem ser usados na formatação de texto:

* `+mn-lt` - Fonte do Corpo em Latim (Minor Latin Font)
* `+mj-lt` - Fonte de Título em Latim (Major Latin Font)
* `+mn-ea` - Fonte do Corpo em Leste Asiático (Minor East Asian Font)
* `+mj-ea` - Fonte de Título em Leste Asiático (Major East Asian Font)

O exemplo a seguir cria um título que usa a fonte latina principal do tema e uma linha de corpo que usa a fonte latina secundária do tema. Em seguida altera as fontes do tema e salva o resultado:

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

O título segue a fonte principal e o texto de corpo segue a fonte secundária. Texto que possui um nome de fonte explícito em vez de um identificador de tema não mudará automaticamente quando o esquema de fontes do tema for alterado.

As coleções de fontes principal e secundária também podem conter mapeamentos de fontes para sistemas de escrita individuais, como Cirílico, Árabe, Japonês, Georgiano e Thaana. Para inspecionar, adicionar, substituir ou remover esses mapeamentos, veja [Script-Specific Theme Fonts](/slides/pt/androidjava/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Para mais informações sobre fontes em apresentações, consulte [PowerPoint Fonts](/slides/pt/androidjava/powerpoint-fonts/).
{{% /alert %}}

## **Copiar ou Aplicar um Tema**

Os fluxos de trabalho abaixo resolvem diferentes problemas relacionados a temas.

### **Aplicar um Tema Externo a Slides Dependentes de um Master**

Use [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/imasterslide/) quando você possui um arquivo de tema do PowerPoint (`.thmx`) e deseja restilizar cada slide que depende de um master específico. Selecione o master da coleção [Presentation.getMasters](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/) que implementa [IMasterSlideCollection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/imasterslidecollection/), e passe o caminho do arquivo de tema para o método.

O método realiza as seguintes operações:

1. Cria um novo master slide baseado no master selecionado.
1. Aplica o tema externo ao novo master.
1. Atribui o novo master a todos os slides que anteriormente dependiam do master selecionado.
1. Retorna o recém‑criado [IMasterSlide](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/imasterslide/).

O exemplo a seguir aplica um tema externo aos slides que dependem do primeiro master e salva a apresentação:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide selectedMaster = presentation.getMasters().get_Item(0);
    IMasterSlide themedMaster = selectedMaster.applyExternalThemeToDependingSlides("corporate-theme.thmx");

    System.out.println("Created master: " + themedMaster.getName());
    presentation.save("presentation-with-external-theme.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Um tema inválido, corrompido ou não suportado pode causar [PptxReadException](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/pptxreadexception/). Valide caminhos fornecidos pelos usuários, trate falhas de acesso ao sistema de arquivos e salve a apresentação somente após a aplicação bem‑sucedida do tema.

Somente os slides que dependiam do master selecionado são reatribuídos. Slides associados a outros masters mantêm seus masters e temas existentes. Cores, fontes, preenchimentos, linhas, fundos e efeitos compatíveis com tema são resolvidos em relação ao tema externo. Cores, fontes, preenchimentos e outras formatações atribuídas diretamente podem permanecer inalterados. Substituições ao nível de layout e de slide também podem ter precedência sobre valores herdados do novo master.

O tema pode referir‑se a fontes que não estão disponíveis no ambiente de tempo de execução. Para renderização e exportação consistentes, instale as fontes necessárias, forneça‑as através de [fontes personalizadas](/slides/pt/androidjava/custom-font/), ou configure [substituição de fontes](/slides/pt/androidjava/font-substitution/).

Este é um fluxo de trabalho direto ao nível de master: o método aceita um caminho de arquivo `.thmx` e não requer a criação manual de substituições de tema ao nível de slide ou layout.

### **Aplicar Temas Externos Diferentes em uma Apresentação com Múltiplos Masters**

Quando o master relevante não é conhecido antecipadamente, obtenha‑o a partir de um slide representativo usando [ISlide.getLayoutSlide](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islide/) e [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ilayoutslide/). Armazene as referências originais dos masters antes de aplicar quaisquer temas, pois cada chamada cria outro master na apresentação.

O exemplo a seguir usa slides de duas seções para localizar seus masters e aplica um tema externo diferente a cada grupo:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("multi-master-presentation.pptx");
try {
    if (presentation.getSlides().size() < 5) {
        System.out.println("The presentation does not contain the expected representative slides.");
    } else {
        IMasterSlide firstGroupMaster = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide();
        IMasterSlide secondGroupMaster = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide();

        if (firstGroupMaster.getSlideId() == secondGroupMaster.getSlideId()) {
            System.out.println("The representative slides use the same master.");
        } else {
            IMasterSlide firstThemedMaster = firstGroupMaster.applyExternalThemeToDependingSlides("blue-theme.thmx");
            IMasterSlide secondThemedMaster = secondGroupMaster.applyExternalThemeToDependingSlides("green-theme.thmx");

            System.out.println("First themed master: " + firstThemedMaster.getName());
            System.out.println("Second themed master: " + secondThemedMaster.getName());
            presentation.save("multi-master-with-external-themes.pptx", SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

A primeira chamada afeta apenas os slides que dependiam de `firstGroupMaster`, e a segunda chamada afeta apenas os slides que dependiam de `secondGroupMaster`. Slides pertencentes a qualquer outro master não são restilizados.

### **Preservar um Tema de Origem ao Mover Slides**

Se você quiser mover um slide para outra apresentação preservando seu design original, clone o master de origem na apresentação de destino com [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/imasterslidecollection/), depois clone o slide com [ISlideCollection.addClone](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islidecollection/) e o master clonado. Isso transporta o master, seus layouts e o tema associado juntos.

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

Este é o fluxo de trabalho preferido quando o slide de origem deve ter a mesma aparência no destino. Simplesmente clonar o conteúdo sobre um master de destino não relacionado pode alterar cores, fontes, fundos e efeitos dirigidos pelo tema.

### **Aplicar Valores de Tema a um Slide Existente**

Se o slide de destino precisar permanecer em seu master e layout atuais, inicialize uma substituição ao nível de slide a partir do tema de origem. Os métodos [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/overridetheme/) e [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/overridetheme/) copiam os três principais componentes do tema para a substituição.

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

Uma substituição ao nível de layout aplica‑se a slides que usam esse layout, a menos que um slide específico possua sua própria substituição. Os mesmos métodos de inicialização podem ser usados através de [LayoutSlideThemeManager](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/layoutslidethememanager/):

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

Use um tema ao nível de master ou apresentação quando muitos layouts e slides devem compartilhar o mesmo design base, uma substituição de layout quando uma família de layouts precisa de estilização diferente, e uma substituição de slide apenas para exceções reais. Substituições excessivas ao nível de slide dificultam a previsão de alterações globais de tema posteriores.

## **Atualizar Estilos de Fundo do Tema**

Os preenchimentos de fundo do tema são armazenados em [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iformatscheme/). O PowerPoint pode apresentar mais opções de fundo em sua UI do que o número de definições de preenchimento fisicamente armazenadas nessa coleção, pois a UI pode combinar preenchimentos de tema com cores de tema e outras referências de estilo.

![Galeria de estilos de fundo do PowerPoint para um tema de apresentação](presentation-design_8.png)

Antes de usar um estilo de fundo, inspecione a coleção armazenada e o índice de estilo atual em [Background.getStyleIndex](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/background/). Um índice de estilo `0` significa nenhum preenchimento temático; valores positivos são referências a estilos de fundo temáticos. Isso difere da indexação direta da coleção Java, onde `get_Item(0)` indica o primeiro item armazenado. Não presuma que cada apresentação contenha o mesmo número de estilos de preenchimento de fundo.

O exemplo a seguir relata a contagem de preenchimentos de fundo disponíveis, atribui uma referência de fundo temático ao primeiro master e salva a apresentação:

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

O resultado visível depende da entrada de tema referenciada pelo master e de quaisquer substituições de fundo no layout ou nível de slide. Se um slide usar seu próprio fundo, alterar apenas o fundo do master pode não afetar esse slide. Use [Background.getEffective](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/background/) quando precisar conhecer o fundo final após a aplicação da herança.

{{% alert color="warning" title="Warning" %}}
Não trate o índice de estilo como um índice de coleção baseado em zero. Também evite codificar um número de estilo de um arquivo e presumir que ele terá a mesma aparência em outro arquivo; definições de estilo de tema são específicas da apresentação.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Para formatação direta de fundo e herança de fundo, veja [Presentation Background](/slides/pt/androidjava/presentation-background/).
{{% /alert %}}

## **Atualizar Efeitos do Tema**

Um esquema de formato de tema contém coleções separadas de preenchimento, linha e efeito expostas por [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iformatscheme/) e [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iformatscheme/). Temas típicos do Office costumam conter três entradas principais que correspondem visualmente a formatações sutil, moderada e intensa, mas o código deve inspecionar cada coleção em vez de presumir uma contagem fixa.

![Efeitos de tema sutis, moderados e intensos aplicados ao mesmo forma](presentation-design_10.png)

Ao acessar essas coleções em Java, o índice da coleção é baseado em zero: `get_Item(0)` é o primeiro estilo armazenado e `get_Item(2)` é o terceiro. Os índices de referência de estilo de uma forma são um conceito separado, exposto por [IShapeStyle](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishapestyle/). Modificar um estilo de tema afeta formas que referenciam esse estilo; formas com formatação direta podem permanecer inalteradas.

O exemplo a seguir verifica a existência das entradas de estilo necessárias, altera o primeiro estilo de linha, altera o terceiro estilo de preenchimento, habilita uma sombra externa no terceiro estilo de efeito e salva o resultado:

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

Para formas que referenciam esses slots, o primeiro estilo de linha do tema torna‑se vermelho, o terceiro estilo de preenchimento do tema torna‑se verde floresta sólido e o terceiro estilo de efeito ganha uma sombra externa com distância de 10 pontos. O resultado visual exato ainda depende de quais slots cada forma referencia e se a formatação direta sobrescreve o tema.

![Estilos de efeito do tema após alterar linhas, preenchimento e sombra](presentation-design_11.png)

## **Ler Valores Efetivos do Tema**

Objetos de tema bruto informam o que está definido em um determinado nível. Valores efetivos informam o que um slide ou forma realmente usa após a herança e substituições locais serem resolvidas. Para um slide, chame [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/baseoverridethememanager/). Para um fundo, use [Background.getEffective](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/background/), e para um preenchimento, use [FillFormat.getEffective](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/fillformat/).

O exemplo a seguir lê o tema efetivo, o fundo e o primeiro preenchimento de forma de um slide:

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

Use dados efetivos para diagnósticos de renderização, validação e comparações. Se você inspecionar apenas [Presentation.getMasterTheme](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/), pode perder um master, layout, slide ou substituição de forma que altere a aparência final.

## **FAQ**

**Aplicar um tema externo afeta todos os slides da apresentação?**

Não. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/imasterslide/) reatribui somente os slides que dependem do master selecionado. Slides que usam outros masters mantêm seus temas existentes.

**Posso aplicar um tema a um único slide sem mudar o master?**

Sim. Use o [SlideThemeManager](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/slidethememanager/) do slide e inicialize sua substituição de tema. A alteração permanece local a esse slide; os demais slides continuam a herdar seus temas atuais.

**Qual é a maneira mais segura de transportar um tema de uma apresentação para outra?**

Ao mover um slide preservando sua aparência original, clone o master de origem na apresentação de destino e clone o slide com esse master usando [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/imasterslidecollection/) e [ISlideCollection.addClone](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islidecollection/). Isso mantém o master, layouts e tema juntos.

**Como posso ver os valores efetivos após herança e substituições?**

Use [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/baseoverridethememanager/) para um slide ou tema de layout e os métodos de dados efetivos correspondentes para objetos de formato, como [Background.getEffective](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/background/) e [FillFormat.getEffective](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/fillformat/). Essas APIs retornam os valores resolvidos após a aplicação de herança e substituições.