---
title: Gerenciar temas de apresentação em Java
linktitle: Tema de Apresentação
type: docs
weight: 10
url: /pt/java/presentation-theme/
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
- Java
- Aspose.Slides
description: "Domine temas de apresentação no Aspose.Slides para Java para criar, personalizar e converter arquivos PowerPoint com identidade visual consistente."
---
## **Introdução**

Um tema de apresentação define um conjunto coordenado de cores, fontes, estilos de plano de fundo, preenchimentos, linhas e efeitos. Objetos sensíveis ao tema referem‑se a essas definições compartilhadas em vez de armazenar cada propriedade visual como um valor fixo, de modo que a alteração de um tema pode atualizar muitos objetos de uma só vez.

No Aspose.Slides, o tema ao nível da apresentação está disponível através de [Presentation.getMasterTheme](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/). Uma apresentação também pode conter substituições de tema em níveis inferiores. Um mestre pode substituir o tema da apresentação por meio de [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/pt/java/com.aspose.slides/masterthememanager/), enquanto um layout ou um slide individual pode substituir seu tema herdado por meio de [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/pt/java/com.aspose.slides/baseoverridethememanager/). Na prática, o tema efetivo de um slide é resolvido por meio desta cadeia de herança: tema da apresentação, substituição do mestre, substituição do layout e substituição do slide.

![Componentes do tema: cores, fontes, estilos de plano de fundo e efeitos](theme-constituents.png)

As seções abaixo mostram os fluxos de trabalho de tema mais comuns: inspecionar um tema, alterar cores e fontes, copiar ou aplicar um tema, atualizar estilos de plano de fundo e efeitos, e ler valores efetivos após a herança e substituições serem resolvidas.

## **Inspecionar um Tema**

O objeto [MasterTheme](https://reference.aspose.com/slides/pt/java/com.aspose.slides/mastertheme/) expõe o esquema de cores, o esquema de fontes e o esquema de formatos do tema por meio de [MasterTheme.getColorScheme](https://reference.aspose.com/slides/pt/java/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/pt/java/com.aspose.slides/mastertheme/) e [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/pt/java/com.aspose.slides/mastertheme/). Inspecionar essas coleções antes de modificá‑las é especialmente útil quando uma apresentação provém de uma fonte externa, pois o número e o conteúdo das entradas de estilo podem variar.

O exemplo a seguir lê as propriedades principais do tema e relata quantos estilos de plano de fundo, preenchimento, linha e efeito estão armazenados no tema:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterTheme theme = presentation.getMasterTheme();
    System.out.println("Theme name: " + theme.getName());
    System.out.println("Accent 1: " + theme.getColorScheme().getAccent1().getColor());
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

Se um arquivo usa vários mestres, não presuma que cada slide possui o mesmo tema efetivo. Inspecione o mestre associado ao slide e use o fluxo de trabalho de tema efetivo mostrado mais adiante neste artigo quando houver substituições de layout ou slide.

## **Alterar Cores do Tema**

Preenchimentos, linhas e texto sensíveis ao tema podem referir‑se a uma cor lógica da enumeração [SchemeColor](https://reference.aspose.com/slides/pt/java/com.aspose.slides/schemecolor/). Quando você altera a entrada correspondente em [IColorScheme](https://reference.aspose.com/slides/pt/java/com.aspose.slides/icolorscheme/), todos os objetos que ainda referenciam essa cor do tema são resolvidos contra o novo valor. Objetos que usam uma cor RGB direta não são alterados por uma atualização de cor do tema.

O exemplo completo a seguir cria uma forma que usa `Accent4`, altera a cor `Accent4` do tema para vermelho, salva a apresentação, reabre‑a e imprime a cor de preenchimento efetiva:

```java
import com.aspose.slides.*;
import java.awt.Color;

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
    System.out.println("Effective fill color: " + effectiveFill.getSolidFillColor());
} finally {
    savedPresentation.dispose();
}
```

Como o retângulo continua vinculado a `Accent4`, sua cor visível torna‑se vermelha após a mudança do tema. Se você substituir a cor do esquema por uma cor direta na forma, alterações posteriores em `Accent4` não afetarão mais esse preenchimento.

### **Usar Cores da Paleta Adicional**

O PowerPoint deriva variantes mais claras e mais escuras a partir de uma cor de tema aplicando transformações de cor. O Aspose.Slides expõe essas transformações por meio da enumeração [ColorTransformOperation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/colortransformoperation/).

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

### **Mapear Valores `SchemeColor` para Slots `IColorScheme`**

A enumeração [SchemeColor](https://reference.aspose.com/slides/pt/java/com.aspose.slides/schemecolor/) usa `Text1`, `Background1`, `Text2` e `Background2`, enquanto [IColorScheme](https://reference.aspose.com/slides/pt/java/com.aspose.slides/icolorscheme/) expõe os mesmos slots de tema como `Dark1`, `Light1`, `Dark2` e `Light2`. O mapeamento é fixo:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Estes são nomes alternativos para os mesmos slots de tema; não são valores convertidos dinamicamente de uma forma para outra.

## **Alterar Fontes do Tema**

Um esquema de fontes do tema contém um conjunto de fontes principal para títulos e um conjunto de fontes secundário para o corpo do texto. Os métodos [IFontScheme.getMajor](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ifontscheme/) e [IFontScheme.getMinor](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ifontscheme/) expõem esses conjuntos.

Identificadores de fontes de tema compatíveis com PowerPoint podem ser usados na formatação de texto:

* `+mn-lt` - Fonte do Corpo Latim (Fonte Menor Latim)
* `+mj-lt` - Fonte de Cabeçalho Latim (Fonte Maior Latim)
* `+mn-ea` - Fonte do Corpo Leste Asiático (Fonte Menor Leste Asiático)
* `+mj-ea` - Fonte de Cabeçalho Leste Asiático (Fonte Maior Leste Asiático)

O exemplo a seguir cria um título que usa a fonte latina maior do tema e uma linha de corpo que usa a fonte latina menor do tema. Em seguida, altera as fontes do tema e salva o resultado:

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

O título segue a fonte maior e o texto do corpo segue a fonte menor. Texto que possui um nome de fonte explícito em vez de um identificador de tema não trocará automaticamente quando o esquema de fontes do tema mudar.

As coleções de fontes maior e menor também podem conter mapeamentos de fontes para sistemas de escrita individuais, como cirílico, árabe, japonês, georgiano e thaana. Para inspecionar, adicionar, substituir ou remover esses mapeamentos, veja [Script-Specific Theme Fonts](/slides/pt/java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Para obter mais informações sobre fontes de apresentação, consulte [PowerPoint Fonts](/slides/pt/java/powerpoint-fonts/).
{{% /alert %}}

## **Copiar ou Aplicar um Tema**

Os fluxos de trabalho abaixo resolvem diferentes problemas relacionados a temas.

### **Aplicar um Tema Externo aos Slides Dependentes de um Mestre**

Use [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imasterslide/) quando você possui um arquivo de tema PowerPoint (`.thmx`) e deseja restilizar todos os slides que dependem de um mestre específico. Selecione o mestre da coleção [Presentation.getMasters](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/), que implementa [IMasterSlideCollection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imasterslidecollection/), e passe o caminho do arquivo de tema para o método.

O método executa as seguintes operações:

1. Cria um novo slide mestre baseado no mestre selecionado.  
2. Aplica o tema externo ao novo mestre.  
3. Atribui o novo mestre a todos os slides que anteriormente dependiam do mestre selecionado.  
4. Retorna o [IMasterSlide](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imasterslide/) recém‑criado.

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

Um tema inválido, corrompido ou não suportado pode causar [PptxReadException](https://reference.aspose.com/slides/pt/java/com.aspose.slides/pptxreadexception/). Valide os caminhos fornecidos pelos usuários, trate falhas de acesso ao sistema de arquivos e salve a apresentação somente após o tema ter sido aplicado com sucesso.

Apenas os slides que dependiam do mestre selecionado são reatribuidos. Slides associados a outros mestres mantêm seus mestres e temas existentes. Cores, fontes, preenchimentos, linhas, planos de fundo e efeitos sensíveis ao tema são resolvidos em relação ao tema externo. Cores, fontes, preenchimentos e outras formatações atribuídas diretamente podem permanecer inalteradas. Substituições ao nível de layout e de slide também podem ter precedência sobre valores herdados do novo mestre.

O tema pode referir‑se a fontes que não estão disponíveis no ambiente de execução. Para renderização e exportação consistentes, instale as fontes necessárias, forneça‑as por meio de [fontes personalizadas](/slides/pt/java/custom-font/), ou configure [substituição de fontes](/slides/pt/java/font-substitution/).

Este é um fluxo de trabalho direto ao nível do mestre: o método aceita um caminho de arquivo `.thmx` e não requer a criação manual de substituições de tema ao nível de slide ou de layout.

### **Aplicar Temas Externos Diferentes em uma Apresentação Multi‑Mestre**

Quando o mestre relevante não é conhecido previamente, obtenha‑o a partir de um slide representativo por meio de [ISlide.getLayoutSlide](https://reference.aspose.com/slides/pt/java/com.aspose.slides/islide/) e [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ilayoutslide/). Armazene as referências originais dos mestres antes de aplicar quaisquer temas, pois cada chamada cria outro mestre na apresentação.

O exemplo a seguir usa slides de duas seções para localizar seus mestres e aplicar um tema externo diferente a cada grupo:

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

### **Preservar um Tema Fonte ao Mover Slides**

Se você deseja mover um slide para outra apresentação e preservar seu design original, clone o mestre fonte na apresentação de destino com [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imasterslidecollection/), depois clone o slide com [ISlideCollection.addClone](https://reference.aspose.com/slides/pt/java/com.aspose.slides/islidecollection/) e o mestre clonado. Isso transporta o mestre, seus layouts e o tema associado juntos.

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

Este é o fluxo de trabalho preferido quando o slide fonte deve permanecer visualmente igual no destino. Simplesmente clonar o conteúdo sobre um mestre de destino não relacionado pode alterar cores, fontes, planos de fundo e efeitos controlados pelo tema.

### **Aplicar Valores de Tema a um Slide Existente**

Se o slide de destino deve permanecer no seu mestre e layout atuais, inicialize uma substituição ao nível de slide a partir do tema fonte. Os métodos [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/pt/java/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/pt/java/com.aspose.slides/overridetheme/) e [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/pt/java/com.aspose.slides/overridetheme/) copiam os três principais componentes do tema para a substituição.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = presentation.getSlides().get_Item(0);
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

Isso altera o tema usado por esse slide sem mudar o tema herdado pelos demais slides. Para remover a substituição local e retornar aos valores herdados, chame [OverrideTheme.clear](https://reference.aspose.com/slides/pt/java/com.aspose.slides/overridetheme/).

### **Aplicar uma Substituição de Tema a um Layout**

Uma substituição ao nível de layout aplica‑se aos slides que usam esse layout, salvo se um slide específico possuir sua própria substituição. Os mesmos métodos de inicialização podem ser usados através do [LayoutSlideThemeManager](https://reference.aspose.com/slides/pt/java/com.aspose.slides/layoutslidethememanager/):

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = presentation.getSlides().get_Item(0);
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

Use um tema ao nível do mestre ou da apresentação quando muitos layouts e slides devem compartilhar o mesmo design base, uma substituição de layout quando uma família de layouts precisa de estilização diferente, e uma substituição de slide apenas para exceções reais. Substituições excessivas ao nível de slide dificultam a previsão de mudanças globais de tema posteriores.

## **Atualizar Estilos de Plano de Fundo do Tema**

Os preenchimentos de plano de fundo do tema são armazenados em [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iformatscheme/). O PowerPoint pode apresentar mais opções de plano de fundo em sua interface do que o número de definições de preenchimento realmente armazenadas nessa coleção, pois a UI pode combinar preenchimentos de tema com cores de tema e outras referências de estilo.

![Galeria de estilos de plano de fundo do PowerPoint para um tema de apresentação](presentation-design_8.png)

Antes de usar um estilo de plano de fundo, inspecione a coleção armazenada e o [Background.getStyleIndex](https://reference.aspose.com/slides/pt/java/com.aspose.slides/background/) atual. Um índice de estilo `0` significa nenhum preenchimento temático; valores positivos são referências de estilo de plano de fundo do tema. Isso difere da indexação direta da coleção Java, onde `get_Item(0)` representa o primeiro item armazenado. Não presuma que toda apresentação contenha o mesmo número de estilos de preenchimento de plano de fundo.

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

O resultado visível depende da entrada de tema referenciada pelo mestre e de quaisquer substituições de plano de fundo no layout ou no slide. Se um slide usa seu próprio plano de fundo, alterar apenas o plano de fundo do mestre pode não alterar esse slide. Use [Background.getEffective](https://reference.aspose.com/slides/pt/java/com.aspose.slides/background/) quando precisar saber o plano de fundo final após a aplicação da herança.

{{% alert color="warning" title="Warning" %}}
Não trate o índice de estilo como um índice de coleção baseado em zero. Também evite codificar um número de estilo de um arquivo e supor que ele terá a mesma aparência em outro arquivo; definições de estilo de tema são específicas da apresentação.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Para formatação direta de plano de fundo e herança de plano de fundo, veja [Presentation Background](/slides/pt/java/presentation-background/).
{{% /alert %}}

## **Atualizar Efeitos do Tema**

Um esquema de formatos de tema contém coleções separadas de preenchimento, linha e efeito expostas por meio de [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iformatscheme/) e [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iformatscheme/). Temas de Office típicos costumam conter três entradas principais que correspondem visualmente a formatações sutil, moderada e intensa, mas o código deve inspecionar cada coleção em vez de presumir uma contagem fixa.

![Efeitos de tema sutis, moderados e intensos aplicados ao mesmo objeto](presentation-design_10.png)

Ao acessar essas coleções em Java, o índice da coleção é baseado em zero: `get_Item(0)` é o primeiro estilo armazenado e `get_Item(2)` é o terceiro. Os índices de referência de estilo de uma forma são um conceito separado, exposto por meio de [IShapeStyle](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ishapestyle/). Modificar um estilo de tema afeta as formas que referenciam esse estilo; formas com formatação direta podem permanecer inalteradas.

O exemplo a seguir verifica se as entradas de estilo necessárias existem, altera o primeiro estilo de linha, altera o terceiro estilo de preenchimento, habilita uma sombra externa no terceiro estilo de efeito e salva o resultado:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    IFormatScheme formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new IllegalStateException("The theme does not contain the style entries required by this example.");
    }
    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid);
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);
    formatScheme.getFillStyles().get_Item(2).setFillType(FillType.Solid);
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(new Color(34, 139, 34));
    IEffectFormat effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10f);
    presentation.save("theme-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para formas que referenciam esses slots, o primeiro estilo de linha do tema torna‑se vermelho, o terceiro estilo de preenchimento do tema torna‑se verde floresta sólido, e o terceiro estilo de efeito ganha uma sombra externa com distância de 10 pontos. O resultado visual exato ainda depende de quais slots de estilo cada forma referencia e se formatação direta substitui o tema.

![Estilos de efeito do tema após alterar as configurações de linha, preenchimento e sombra](presentation-design_11.png)

## **Ler Valores Efetivos do Tema**

Objetos de tema brutos informam o que está definido em um nível específico. Valores efetivos informam o que um slide ou forma realmente usa após a herança e substituições locais serem resolvidas. Para um slide, chame [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/pt/java/com.aspose.slides/baseoverridethememanager/). Para um plano de fundo, use [Background.getEffective](https://reference.aspose.com/slides/pt/java/com.aspose.slides/background/), e para um preenchimento, use [FillFormat.getEffective](https://reference.aspose.com/slides/pt/java/com.aspose.slides/fillformat/).

O exemplo a seguir lê o tema efetivo, o plano de fundo e o primeiro preenchimento de forma de um slide:

```java
import com.aspose.slides.*;

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
            System.out.println("First shape effective fill color: " + effectiveFill.getSolidFillColor());
        }
    }
} finally {
    presentation.dispose();
}
```

Use dados efetivos para diagnósticos de renderização, validação e comparações. Se você inspecionar apenas [Presentation.getMasterTheme](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/), pode perder um mestre, layout, slide ou substituição de forma que altere a aparência final.

## **FAQ**

**Aplicar um tema externo afeta todos os slides da apresentação?**

Não. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imasterslide/) reatribui apenas os slides que dependem do mestre selecionado. Slides que utilizam outros mestres mantêm seus temas existentes.

**Posso aplicar um tema a um único slide sem alterar o mestre?**

Sim. Use o [SlideThemeManager](https://reference.aspose.com/slides/pt/java/com.aspose.slides/slidethememanager/) do slide e inicialize seu tema de substituição. A mudança permanece local a esse slide; os demais slides continuam a herdar seus temas atuais.

**Qual é a maneira mais segura de levar um tema de uma apresentação para outra?**

Ao mover um slide e preservar sua aparência original, clone o mestre fonte na apresentação de destino e clone o slide com esse mestre usando [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imasterslidecollection/) e [ISlideCollection.addClone](https://reference.aspose.com/slides/pt/java/com.aspose.slides/islidecollection/). Isso mantém o mestre, layouts e tema juntos.

**Como posso ver os valores efetivos após herança e substituições?**

Use [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/pt/java/com.aspose.slides/baseoverridethememanager/) para um tema de slide ou layout e os métodos de dados efetivos correspondentes para objetos de formato, como [Background.getEffective](https://reference.aspose.com/slides/pt/java/com.aspose.slides/background/) e [FillFormat.getEffective](https://reference.aspose.com/slides/pt/java/com.aspose.slides/fillformat/). Essas APIs retornam os valores resolvidos após a aplicação de herança e substituições.