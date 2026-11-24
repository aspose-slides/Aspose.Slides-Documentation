---
title: Gerenciar temas de apresentação no Android
linktitle: Tema de apresentação
type: docs
weight: 10
url: /pt/androidjava/presentation-theme/
keywords:
- tema PowerPoint
- tema de apresentação
- tema de slide
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
description: "Gerenciar temas de apresentação no Aspose.Slides para Android via Java para criar, personalizar e converter arquivos PowerPoint com identidade visual consistente."
---
## **Introdução**

Um tema de apresentação define um conjunto coordenado de cores, fontes, estilos de plano de fundo, preenchimentos, linhas e efeitos. Objetos compatíveis com temas referem‑se a essas definições compartilhadas em vez de armazenar cada propriedade visual como um valor fixo, de modo que uma alteração de tema pode atualizar muitos objetos de uma vez.

No Aspose.Slides, o tema ao nível da apresentação está disponível através de [Presentation.getMasterTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/). Uma apresentação também pode conter substituições de tema em níveis inferiores. Um mestre pode substituir o tema da apresentação por meio de [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/masterthememanager/), enquanto um layout ou um slide individual pode substituir seu tema herdado por meio de [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseoverridethememanager/). Na prática, o tema efetivo de um slide é resolvido por esta cadeia de herança: tema da apresentação, substituição do mestre, substituição do layout e substituição do slide.

![Componentes do tema: cores, fontes, estilos de plano de fundo e efeitos](theme-constituents.png)

As seções abaixo mostram os fluxos de trabalho de tema mais comuns: inspecionar um tema, alterar cores e fontes, copiar ou aplicar um tema, atualizar estilos de plano de fundo e efeitos, e ler valores efetivos após a herança e as substituições serem resolvidas.

## **Inspecionar um Tema**

O objeto [MasterTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/) expõe o esquema de cores, o esquema de fontes e o esquema de formatos do tema por meio de [MasterTheme.getColorScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/) e [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/). Inspecionar essas coleções antes de alterá‑las é especialmente útil quando a apresentação provém de uma fonte externa, pois o número e o conteúdo das entradas de estilo podem variar.

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

Se um arquivo usar vários mestres, não presuma que cada slide tenha o mesmo tema efetivo. Inspecione o mestre associado ao slide e use o fluxo de trabalho de tema efetivo mostrado mais adiante neste artigo quando substituições de layout ou slide puderem estar presentes.

## **Alterar Cores do Tema**

Preenchimentos, linhas e texto compatíveis com tema podem referir‑se a uma cor lógica da enumeração [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/schemecolor/). Quando você altera a entrada correspondente em [IColorScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorscheme/), todos os objetos que ainda referenciam aquela cor de tema são resolvidos com base no novo valor. Objetos que usam uma cor RGB direta não são alterados por uma atualização de cor de tema.

O exemplo de ponta a ponta a seguir cria uma forma que usa `Accent4`, altera a cor `Accent4` do tema para vermelho, salva a apresentação, reabre‑a e imprime a cor de preenchimento efetiva:

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

Como o retângulo permanece vinculado a `Accent4`, sua cor visível torna‑se vermelha após a alteração do tema. Se você substituir a cor do esquema por uma cor direta na forma, alterações posteriores em `Accent4` não afetarão mais esse preenchimento.

### **Usar Cores da Paleta Adicional**

O PowerPoint gera variantes mais claras e mais escuras a partir de uma cor de tema aplicando transformações de cor. O Aspose.Slides expõe essas transformações por meio da enumeração [ColorTransformOperation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/colortransformoperation/).

![Cores principais do tema e cores mais claras e mais escuras geradas a partir da paleta adicional](additional-palette-colors.png)

**1** – Cores principais do tema.

**2** – Variantes mais claras e mais escuras produzidas a partir das cores principais do tema.

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

Essas variantes permanecem baseadas na cor do tema. Se `Accent4` mudar posteriormente, as cores transformadas são recalculadas a partir do novo valor de `Accent4`.

### **Mapear Valores de `SchemeColor` para Slots de `IColorScheme`**

A enumeração [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/schemecolor/) usa `Text1`, `Background1`, `Text2` e `Background2`, enquanto [IColorScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorscheme/) expõe os mesmos slots de tema como `Dark1`, `Light1`, `Dark2` e `Light2`. O mapeamento é fixo:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Esses são nomes alternativos para os mesmos slots de tema; não são valores convertidos dinamicamente de uma forma para outra.

## **Alterar Fontes do Tema**

Um esquema de fontes do tema contém um conjunto de fontes principal para títulos e um conjunto de fontes secundário para o corpo do texto. Os métodos [IFontScheme.getMajor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontscheme/) e [IFontScheme.getMinor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontscheme/) expõem esses conjuntos.

Identificadores de fontes de tema compatíveis com PowerPoint podem ser usados na formatação de texto:

* `+mn-lt` – Fonte do corpo Latin (Fonte Latin Secundária)
* `+mj-lt` – Fonte do título Latin (Fonte Latin Principal)
* `+mn-ea` – Fonte do corpo East Asian (Fonte East Asian Secundária)
* `+mj-ea` – Fonte do título East Asian (Fonte East Asian Principal)
* `+mn-cs` – Fonte do corpo Complex Script (Fonte Complex Script Secundária)
* `+mj-cs` – Fonte do título Complex Script (Fonte Complex Script Principal)

O exemplo a seguir cria um título que usa a fonte Latin principal do tema e uma linha de corpo que usa a fonte Latin secundária do tema. Em seguida altera as fontes do tema e salva o resultado:

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

O título segue a fonte principal e o texto do corpo segue a fonte secundária. Texto que possui um nome de fonte explícito em vez de um identificador de tema não mudará automaticamente quando o esquema de fontes do tema mudar.

As coleções de fontes principal e secundária também podem conter mapeamentos de fontes para sistemas de escrita individuais, como cirílico, árabe, japonês, georgiano e thaana. Para inspecionar, adicionar, substituir ou remover esses mapeamentos, consulte [Script-Specific Theme Fonts](/slides/pt/androidjava/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}

Para mais informações sobre fontes de apresentação, veja [PowerPoint Fonts](/slides/pt/androidjava/powerpoint-fonts/).

{{% /alert %}}

### **Resolver Referências de Fonte do Tema**

Ao inspecionar texto, [IFontData.getFontName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontdata/#getFontName--) pode retornar uma referência de tema como `+mn-lt` em vez de um nome de família de fonte. Chame [IFontData.getFontName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontdata/#getFontName-com.aspose.slides.IThemeEffectiveData-) com o [IThemeEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithemeeffectivedata/) apropriado para resolver essa referência. Os prefixos `+mj` e `+mn` selecionam os conjuntos de fontes principal e secundário; os sufixos `-lt`, `-ea` e `-cs` selecionam suas fontes Latin, East Asian e Complex Script, respectivamente.

Obtenha o tema efetivo por meio de [IThemeable.createThemeEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithemeable/#createThemeEffective--) no objeto cujo tema se aplica ao texto inspecionado. Para texto comum em um slide, chame esse método no slide para que o contexto inclua o tema herdado desse slide e as substituições locais. Ao inspecionar um layout ou mestre, use o seu próprio tema efetivo. Não presuma que o tema do primeiro mestre se aplique a todos os slides.

O exemplo a seguir cria uma porção de texto que referencia explicitamente a fonte Latin secundária. Ele inicializa um esquema de fontes de slide por meio de [IOverrideTheme.initFontSchemeFromInherited](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioverridetheme/#initFontSchemeFromInherited--) e define as famílias Latin principal e secundária para `Arial` e `Calibri`, tornando o resultado reproduzível sem um arquivo de entrada.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IOverrideTheme theme = slide.getThemeManager().getOverrideTheme();
    theme.initFontSchemeFromInherited();
    theme.getFontScheme().getMajor().setLatinFont(new FontData("Arial"));
    theme.getFontScheme().getMinor().setLatinFont(new FontData("Calibri"));

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Text using the minor theme font");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));

    IFontData font = portion.getPortionFormat().getLatinFont();
    IThemeEffectiveData effectiveTheme = slide.createThemeEffective();
    System.out.println(font.getFontName() + " -> " + font.getFontName(effectiveTheme));

    FontData explicitFont = new FontData("Verdana");
    System.out.println(explicitFont.getFontName() + " -> " + explicitFont.getFontName(effectiveTheme));
} finally {
    presentation.dispose();
}
```

A saída é `+mn-lt -> Calibri` seguida por `Verdana -> Verdana`. A referência armazenada permanece inalterada, enquanto um nome de família explícito é retornado como‑está. Se a porção usasse `+mj-lt`, ela seria resolvida para `Arial` neste tema.

Resolver uma referência de tema identifica a família de fontes especificada pelo tema. Não verifica a disponibilidade da fonte nem determina o arquivo de fonte realmente usado após substituição ou fallback de glifos durante a renderização. Consulte [Font Selection Sequence](/slides/pt/androidjava/font-selection-sequence/) e [Font Substitution](/slides/pt/androidjava/font-substitution/) para essas etapas separadas.

## **Copiar ou Aplicar um Tema**

Os fluxos de trabalho abaixo resolvem diferentes problemas relacionados a temas.

### **Aplicar um Tema Externo aos Slides Dependentes de um Mestre**

Use [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/) quando você possui um arquivo de tema PowerPoint (`.thmx`) e deseja restilizar todos os slides que dependem de um mestre específico. Selecione o mestre da coleção [Presentation.getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/), que implementa [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/), e passe o caminho do arquivo de tema para o método.

O método executa as seguintes operações:

1. Cria um novo slide mestre baseado no mestre selecionado.  
2. Aplica o tema externo ao novo mestre.  
3. Atribui o novo mestre a todos os slides que anteriormente dependiam do mestre selecionado.  
4. Retorna o recém‑criado [IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/).

O exemplo a seguir aplica um tema externo aos slides que dependem do primeiro mestre e salva a apresentação:

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

Um tema inválido, corrompido ou não suportado pode causar [PptxReadException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxreadexception/). Valide os caminhos fornecidos pelos usuários, trate falhas de acesso ao sistema de arquivos e salve a apresentação somente após o tema ter sido aplicado com sucesso.

Somente os slides que dependiam do mestre selecionado são reatribuídos. Slides associados a outros mestres mantêm seus mestres e temas existentes. Cores, fontes, preenchimentos, linhas, planos de fundo e efeitos compatíveis com tema são resolvidos em relação ao tema externo. Cores, fontes, preenchimentos e outras formatações atribuídas diretamente podem permanecer inalteradas. Substituições ao nível de layout e slide também podem ter precedência sobre valores herdados do novo mestre.

O tema pode referenciar fontes que não estão disponíveis no ambiente de tempo de execução. Para renderização e exportação consistentes, instale as fontes necessárias, forneça‑as através de [custom font sources](/slides/pt/androidjava/custom-font/) ou configure [font substitution](/slides/pt/androidjava/font-substitution/).

Este é um fluxo de trabalho direto ao nível do mestre: o método aceita um caminho de arquivo `.thmx` e não requer a criação manual de substituições de tema ao nível de slide ou layout.

### **Aplicar Temas Externos Diferentes em uma Apresentação com Múltiplos Mestres**

Quando o mestre relevante não é conhecido previamente, obtenha‑o a partir de um slide representativo por meio de [ISlide.getLayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) e [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutslide/). Armazene as referências originais dos mestres antes de aplicar quaisquer temas, pois cada chamada cria outro mestre na apresentação.

O exemplo a seguir usa slides de duas seções para localizar seus mestres e aplica um tema externo diferente a cada grupo:

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

A primeira chamada afeta apenas os slides que dependiam de `firstGroupMaster`, e a segunda chamada afeta apenas os slides que dependiam de `secondGroupMaster`. Slides pertencentes a qualquer outro mestre não são restilizados.

### **Preservar um Tema de Origem ao Mover Slides**

Se você quiser mover um slide para outra apresentação e preservar seu design original, clone o mestre de origem na apresentação de destino com [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/), então clone o slide com [ISlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/) e o mestre clonado. Isso transporta o mestre, seus layouts e o tema associado juntos.

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

Este é o fluxo de trabalho recomendado quando o slide de origem deve ter a mesma aparência no destino. Clonar apenas o conteúdo em um mestre de destino não relacionado pode alterar cores, fontes, planos de fundo e efeitos controlados por tema.

### **Aplicar Valores de Tema a um Slide Existente**

Se o slide de destino deve permanecer no seu mestre e layout atuais, inicialize uma substituição ao nível do slide a partir do tema de origem. Os métodos [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/) e [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/) copiam os três principais componentes do tema para a substituição.

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

Isso altera o tema usado por aquele slide sem mudar o tema herdado por outros slides. Para remover a substituição local e retornar aos valores herdados, chame [OverrideTheme.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/).

### **Aplicar uma Substituição de Tema a um Layout**

Uma substituição ao nível de layout aplica‑se aos slides que usam esse layout, a menos que um slide específico possua sua própria substituição. Os mesmos métodos de inicialização podem ser usados por meio do [LayoutSlideThemeManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/layoutslidethememanager/):

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

Use um tema ao nível de mestre ou apresentação quando muitos layouts e slides devem compartilhar o mesmo design base, uma substituição de layout quando uma família de layouts precisa de estilização diferente e uma substituição de slide apenas para exceções reais. Substituições excessivas ao nível de slide tornam alterações globais de tema posteriores mais difíceis de prever.


<!-- visual-explanation:presentation-theme:start -->
[![Um tema mestre alimenta dois layouts; uma substituição de layout afeta seus slides, exceto um slide com uma substituição mais local.](visual-presentation-theme-20ad12f2193b.svg)](visual-presentation-theme-20ad12f2193b.svg)

*Uma substituição de layout aplica‑se aos slides que usam esse layout, a menos que um slide forneça sua própria substituição. Valores baseados em tema seguem seu esquema resolvido; objetos formatados explicitamente podem manter sua aparência local. Mantenha as substituições tão restritas quanto a exceção de design pretendida.*
<!-- visual-explanation:presentation-theme:end -->

## **Atualizar Estilos de Plano de Fundo do Tema**

Os preenchimentos de plano de fundo do tema são armazenados em [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/). O PowerPoint pode apresentar mais opções de plano de fundo em sua interface do que o número de definições de preenchimento fisicamente armazenadas nesta coleção, pois a UI pode combinar preenchimentos de tema com cores de tema e outras referências de estilo.

![Galeria de estilos de plano de fundo do PowerPoint para um tema de apresentação](presentation-design_8.png)

Antes de usar um estilo de plano de fundo, inspecione a coleção armazenada e o [Background.getStyleIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/) atual. Um índice de estilo `0` significa nenhum preenchimento temático; valores positivos são referências de estilo de plano de fundo de tema. Isso difere da indexação direta da coleção Java, onde `get_Item(0)` significa o primeiro item armazenado. Não presuma que toda apresentação contenha o mesmo número de estilos de preenchimento de plano de fundo.

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

O resultado visível depende da entrada do tema referenciada pelo mestre e de quaisquer substituições de plano de fundo no layout ou nível de slide. Se um slide usar seu próprio plano de fundo, alterar apenas o plano de fundo do mestre pode não mudar esse slide. Use [Background.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/) quando precisar saber o plano de fundo final após a herança ser aplicada.

{{% alert color="warning" title="Warning" %}}

Não trate o índice de estilo como um índice de coleção zero‑based. Também evite codificar um número de estilo de um arquivo e presumir que ele tenha a mesma aparência em outro arquivo; definições de estilo de tema são específicas da apresentação.

{{% /alert %}}

{{% alert color="info" title="Tip" %}}

Para formatação direta de plano de fundo e herança de plano de fundo, veja [Presentation Background](/slides/pt/androidjava/presentation-background/).

{{% /alert %}}

## **Atualizar Efeitos do Tema**

Um esquema de formatos de tema contém coleções separadas de estilos de preenchimento, linha e efeito expostas por meio de [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/) e [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/). Temas típicos do Office geralmente contêm três entradas de estilo principais que correspondem visualmente a formatação sutil, moderada e intensa, mas o código deve inspecionar cada coleção em vez de presumir uma contagem fixa.

![Efeitos de tema sutil, moderado e intenso aplicados à mesma forma](presentation-design_10.png)

Ao acessar essas coleções em Java, o índice da coleção é zero‑based: `get_Item(0)` é o primeiro estilo armazenado e `get_Item(2)` é o terceiro. Os índices de referência de estilo de uma forma são um conceito separado, exposto por [IShapeStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapestyle/). Modificar um estilo de tema afeta formas que referenciam esse estilo de tema; formas com formatação direta podem permanecer inalteradas.

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

Para formas que referenciam esses slots, o primeiro estilo de linha do tema torna‑se vermelho, o terceiro estilo de preenchimento do tema torna‑se verde floresta sólido, e o terceiro estilo de efeito ganha uma sombra externa com distância de 10 pontos. O resultado visual exato ainda depende de quais slots de estilo cada forma referencia e se a formatação direta substitui o tema.

![Estilos de efeito de tema após alterar linha, preenchimento e configurações de sombra](presentation-design_11.png)

## **Selecionar Estilos de Preenchimento e Linha do Tema para uma Forma**

Uma forma pode selecionar seu preenchimento e contorno independentemente por meio de [IShapeStyle.setFillStyleIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapestyle/#setFillStyleIndex-short-) e [IShapeStyle.setLineStyleIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapestyle/#setLineStyleIndex-int-). Para ambos os métodos, o índice `1` seleciona a primeira entrada na coleção de tema correspondente (`get_Item(0)`) e o índice `2` seleciona a segunda (`get_Item(1)`).

O exemplo a seguir configura dois estilos de preenchimento (ouro e azul celeste) e dois estilos de linha (azul escuro a 6 pt e vermelho escuro a 12 pt) no tema padrão de uma nova apresentação. Ele salva o slide em três etapas para que você possa comparar os resultados no PowerPoint.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IFormatScheme styles = presentation.getMasterTheme().getFormatScheme();

    IFillFormat goldFill = styles.getFillStyles().get_Item(0);
    goldFill.setFillType(FillType.Solid);
    goldFill.getSolidFillColor().setColor(Color.rgb(255, 215, 0));
    IFillFormat blueFill = styles.getFillStyles().get_Item(1);
    blueFill.setFillType(FillType.Solid);
    blueFill.getSolidFillColor().setColor(Color.rgb(135, 206, 235));

    ILineFormat thinLine = styles.getLineStyles().get_Item(0);
    thinLine.getFillFormat().setFillType(FillType.Solid);
    thinLine.getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
    thinLine.setWidth(6);
    ILineFormat thickLine = styles.getLineStyles().get_Item(1);
    thickLine.getFillFormat().setFillType(FillType.Solid);
    thickLine.getFillFormat().getSolidFillColor().setColor(Color.rgb(139, 0, 0));
    thickLine.setWidth(12);

    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();
    IAutoShape left = shapes.addAutoShape(ShapeType.Rectangle, 100, 205, 200, 130);
    IAutoShape right = shapes.addAutoShape(ShapeType.Rectangle, 420, 205, 200, 130);
    left.getShapeStyle().setFillStyleIndex((short) 1);
    right.getShapeStyle().setFillStyleIndex((short) 2);
    left.getShapeStyle().setLineStyleIndex(1);
    right.getShapeStyle().setLineStyleIndex(1);
    presentation.save("01-initial.pptx", SaveFormat.Pptx);

    right.getShapeStyle().setLineStyleIndex(2);
    presentation.save("02-line-changed.pptx", SaveFormat.Pptx);

    goldFill.getSolidFillColor().setColor(Color.rgb(46, 139, 87));
    presentation.save("03-theme-changed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Estilos iniciais | Alterar o contorno da direita | Editar o primeiro preenchimento do tema |
|:---:|:---:|:---:|
| ![Retângulos dourados e azul‑celeste com contornos finos azul‑escuros correspondentes](theme-style-initial.png) | ![O retângulo azul‑celeste agora tem um contorno vermelho escuro grosso](theme-style-line-changed.png) | ![O retângulo esquerdo agora está verde e ambos os contornos permanecem inalterados](theme-style-fill-changed.png) |

Selecionar um estilo de linha diferente altera apenas o contorno do retângulo da direita. Editar o primeiro preenchimento do tema atualiza todas as formas que o utilizam. Aqui, somente o retângulo esquerdo fica verde.

Em uma forma existente, uma cor de preenchimento local, cor de linha ou espessura de linha pode sobrescrever essa parte do estilo de tema. Se a alteração de um índice de estilo não produzir efeito visível, verifique a [formatação direta](/slides/pt/androidjava/shape-formatting/) da forma.

## **Determinar se um Preenchimento Sólido Efetivo Usa uma Cor de Tema**

Um preenchimento pode ser armazenado diretamente em um objeto ou herdado de um parágrafo, layout, mestre, estilo de tema ou outro nível de formatação. Chame [IFillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/) para resolver essa hierarquia em um [IFillFormatEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/) imutável. Primeiro verifique [IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/). Só quando for `FillType.Solid` você deve ler as propriedades de preenchimento sólido.

Para um preenchimento sólido, [IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/) devolve o valor RGB final renderizado após herança, busca no tema e aplicação de transformações de cor. [IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/) devolve o slot lógico correspondente de [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/schemecolor/), como `Text1` ou `Accent6`. Um valor `SchemeColor.NotDefined` indica que o preenchimento sólido efetivo não se baseia em uma cor de esquema. Em um fluxo onde preenchimentos são ou cores de tema ou cores RGB diretas, esse valor identifica um preenchimento RGB direto.

Não use apenas o valor local de [IColorFormat.getSchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/) para classificar um preenchimento. Por exemplo, uma porção de texto pode não ter cor de esquema definida localmente, portanto seu valor local é `NotDefined`, enquanto seu preenchimento efetivo herda uma cor de tema e resolve para `Text1` ou `Accent6`. Por outro lado, `getSolidFillSchemeColor` indica qual slot lógico de tema produziu a cor efetiva, mas não informa se esse slot veio do objeto, parágrafo, layout, mestre ou outro nível da hierarquia.

O exemplo a seguir carrega uma apresentação, audita os preenchimentos de formas e de porções de texto, imprime cada valor RGB final e o esquema associado, e sinaliza preenchimentos sólidos que não acompanharão mudanças nas cores de tema:

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.util.function.BiConsumer;

BiConsumer<String, IFillFormat> auditFill = (objectName, localFill) -> {
    IFillFormatEffectiveData effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() != FillType.Solid) {
        System.out.println(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    int rgb = effectiveFill.getSolidFillColor();
    int effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    int localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    System.out.printf("%s: RGB = #%02X%02X%02X%n", objectName, Color.red(rgb), Color.green(rgb), Color.blue(rgb));
    System.out.println(objectName + ": local scheme = " + localSchemeColor + ", effective scheme = " + effectiveSchemeColor);

    if (effectiveSchemeColor == SchemeColor.NotDefined) {
        System.out.println(objectName + ": direct RGB or another non-scheme fill; audit as theme-independent.");
    } else {
        System.out.println(objectName + ": theme-dependent through " + effectiveSchemeColor + ".");
    }
};

Presentation presentation = new Presentation("input.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);

        int shapeCount = slide.getShapes().size();
        for (int shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
            IShape shape = slide.getShapes().get_Item(shapeIndex);
            String shapeName = "Slide " + (slideIndex + 1) + ", shape " + (shapeIndex + 1);
            auditFill.accept(shapeName, shape.getFillFormat());

            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                int paragraphCount = autoShape.getTextFrame().getParagraphs().getCount();
                for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

                    int portionCount = paragraph.getPortions().getCount();
                    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                        IPortion portion = paragraph.getPortions().get_Item(portionIndex);
                        String portionName = shapeName + ", paragraph " + (paragraphIndex + 1) + ", portion " + (portionIndex + 1);
                        auditFill.accept(portionName, portion.getPortionFormat().getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

O ramo `NotDefined` fornece uma lista de auditoria de preenchimentos sólidos que não responderão a alterações nos slots de cor de tema. Revise esses objetos quando uma apresentação precisar seguir uma nova paleta de marca. O valor RGB reportado ainda mostra a aparência atual, enquanto o valor de esquema explica se essa aparência está conectada ao tema.

Objetos de formato efetivo são instantâneos. Após mudar o tema da apresentação, uma substituição de tema ou qualquer formatação herdada, chame `getEffective` novamente e leia um novo objeto `IFillFormatEffectiveData` antes de comparar ou relatar cores.

## **Ler Valores Efetivos do Tema**

Objetos de tema bruto informam o que está definido em um determinado nível. Valores efetivos informam o que um slide ou forma realmente usa após herança e substituições locais serem resolvidas. Para um slide, chame [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseoverridethememanager/). Para um plano de fundo, use [Background.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/), e para um preenchimento, use [FillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/).

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

Use dados efetivos para diagnóstico de renderização, validação e comparações. Se você inspecionar apenas [Presentation.getMasterTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/), pode perder um mestre, layout, slide ou substituição de forma que altere a aparência final.

## **FAQ**

**Aplicar um tema externo afeta todos os slides da apresentação?**

Não. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/) reatribui somente os slides que dependem do mestre selecionado. Slides que usam outros mestres mantêm seus temas existentes.

**Posso aplicar um tema a um único slide sem mudar o mestre?**

Sim. Use o [SlideThemeManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidethememanager/) do slide e inicialize sua substituição de tema. A alteração permanece local a esse slide; os demais slides continuam herdando seus temas atuais.

**Qual é a maneira mais segura de transportar um tema de uma apresentação para outra?**

Ao mover um slide preservando sua aparência de origem, clone o mestre de origem no destino e clone o slide com esse mestre usando [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/) e [ISlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/). Isso mantém o mestre, os layouts e o tema juntos.

**Como posso ver os valores efetivos após herança e substituições?**

Use [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseoverridethememanager/) para um slide ou tema de layout e os métodos de dados efetivos correspondentes para objetos de formato, como [Background.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/) e [FillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/). Essas APIs retornam os valores resolvidos após herança e substituições serem aplicadas.