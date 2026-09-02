---
title: Gerenciar Temas de Apresentação em JavaScript
linktitle: Tema de Apresentação
type: docs
weight: 10
url: /pt/nodejs-java/presentation-theme/
keywords:
- Tema PowerPoint
- Tema de apresentação
- Tema de slide
- Definir tema
- Alterar tema
- Gerenciar tema
- Tema externo
- THMX
- Cor do tema
- Paleta adicional
- Fonte do tema
- Estilo do tema
- Efeito do tema
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Domine temas de apresentação em JavaScript com Aspose.Slides para Node.js para criar, personalizar e converter arquivos PowerPoint com identidade visual consistente."
---
## **Introdução**

Um tema de apresentação define um conjunto coordenado de cores, fontes, estilos de plano de fundo, preenchimentos, linhas e efeitos. Objetos sensíveis ao tema referem‑se a essas definições compartilhadas em vez de armazenar cada propriedade visual como um valor fixo, de modo que uma alteração de tema pode atualizar muitos objetos de uma só vez.

No Aspose.Slides, o tema ao nível da apresentação está disponível por meio de [Presentation.getMasterTheme](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/getmastertheme/). Uma apresentação também pode conter substituições de tema em níveis inferiores. Um mestre pode substituir o tema da apresentação através de [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/masterthememanager/), enquanto um layout ou um slide individual pode substituir seu tema herdado através de [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseoverridethememanager/). Na prática, o tema efetivo de um slide é resolvido por meio desta cadeia de herança: tema da apresentação, substituição do mestre, substituição do layout e substituição do slide.

![Componentes do tema: cores, fontes, estilos de plano de fundo e efeitos](theme-constituents.png)

As seções abaixo mostram os fluxos de trabalho de tema mais comuns: inspecionar um tema, alterar cores e fontes, copiar ou aplicar um tema, atualizar estilos de plano de fundo e efeitos, e ler valores efetivos após a herança e substituições terem sido resolvidas.

## **Inspecionar um Tema**

O objeto [MasterTheme](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mastertheme/) expõe o esquema de cores, o esquema de fontes e o esquema de formatos do tema por meio de [MasterTheme.getColorScheme](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mastertheme/) e [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mastertheme/). Inspecionar essas coleções antes de alterá‑las é especialmente útil quando uma apresentação provém de uma fonte externa, porque o número e o conteúdo das entradas de estilo podem variar.

O exemplo a seguir lê as propriedades principais do tema e relata quantos estilos de plano de fundo, preenchimento, linha e efeito estão armazenados no tema:

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

Se um arquivo usar vários mestres, não presuma que cada slide possui o mesmo tema efetivo. Inspecione o mestre associado ao slide e use o fluxo de trabalho de tema efetivo mostrado mais adiante neste artigo quando substituições de layout ou slide puderem estar presentes.

## **Alterar Cores do Tema**

Preenchimentos, linhas e textos sensíveis ao tema podem referir‑se a uma cor lógica da enumeração [SchemeColor](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/schemecolor/). Quando você altera a entrada correspondente em [ColorScheme](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/colorscheme/), todos os objetos que ainda referenciam aquela cor de tema são resolvidos contra o novo valor. Objetos que usam uma cor RGB direta não são alterados por uma atualização de cor de tema.

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

Como o retângulo permanece vinculado a `Accent4`, sua cor visível torna‑se vermelha após a alteração do tema. Se você substituir a cor do esquema por uma cor direta na forma, alterações posteriores em `Accent4` não afetarão mais esse preenchimento.

### **Usar Cores da Paleta Adicional**

O PowerPoint gera variantes mais claras e mais escuras de uma cor de tema aplicando transformações de cor. O Aspose.Slides expõe essas transformações por meio da enumeração [ColorTransformOperation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/colortransformoperation/).

![Cores principais do tema e cores mais claras e mais escuras geradas a partir da paleta adicional](additional-palette-colors.png)

**1** – Cores principais do tema.  
**2** – Variantes mais claras e mais escuras produzidas a partir das cores principais do tema.

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

Essas variantes permanecem baseadas na cor do tema. Se `Accent4` mudar mais tarde, as cores transformadas são recalculadas a partir do novo valor de `Accent4`.

### **Mapear Valores `SchemeColor` para Slots `ColorScheme`**

A enumeração [SchemeColor](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/schemecolor/) usa `Text1`, `Background1`, `Text2` e `Background2`, enquanto [ColorScheme](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/colorscheme/) expõe os mesmos slots de tema como `Dark1`, `Light1`, `Dark2` e `Light2`. O mapeamento é fixo:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Esses são nomes alternativos para os mesmos slots de tema; não são valores convertidos dinamicamente de uma forma para outra.

## **Alterar Fontes do Tema**

Um esquema de fontes do tema contém um conjunto principal de fontes para títulos e um conjunto secundário para o corpo do texto. Os métodos [FontScheme.getMajor](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontscheme/) e [FontScheme.getMinor](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontscheme/) expõem esses conjuntos.

Identificadores de fontes de tema compatíveis com PowerPoint podem ser usados na formatação de texto:

* `+mn-lt` – Fonte do Corpo Latin (Minor Latin Font)
* `+mj-lt` – Fonte de Título Latin (Major Latin Font)
* `+mn-ea` – Fonte do Corpo East Asian (Minor East Asian Font)
* `+mj-ea` – Fonte de Título East Asian (Major East Asian Font)

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

O título segue a fonte principal e o texto do corpo segue a fonte secundária. Texto que possui um nome de fonte explícito em vez de um identificador de tema não mudará automaticamente quando o esquema de fontes do tema for alterado.

As coleções de fontes principais e secundárias também podem conter mapeamentos de fontes para sistemas de escrita individuais, como Cirílico, Árabe, Japonês, Georgiano e Thaana. Para inspecionar, adicionar, substituir ou remover esses mapeamentos, veja [Script-Specific Theme Fonts](/slides/pt/nodejs-java/script-specific-font-mappings/).

{{% alert color="info" title="Dica" %}}
Para mais informações sobre fontes de apresentação, veja [PowerPoint Fonts](/slides/pt/nodejs-java/powerpoint-fonts/).
{{% /alert %}}

## **Copiar ou Aplicar um Tema**

Os fluxos de trabalho abaixo resolvem diferentes problemas relacionados a temas.

### **Aplicar um Tema Externo a Slides Dependentes de um Mestre**

Use [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/masterslide/) quando você tem um arquivo de tema PowerPoint (`.thmx`) e deseja restilizar todos os slides que dependem de um mestre específico. Selecione o mestre da coleção [Presentation.getMasters](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/), representada por [MasterSlideCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/masterslidecollection/), e passe o caminho do arquivo de tema para o método.

O método executa as seguintes operações:

1. Cria um novo slide mestre baseado no mestre selecionado.
1. Aplica o tema externo ao novo mestre.
1. Atribui o novo mestre a todos os slides que anteriormente dependiam do mestre selecionado.
1. Retorna o recém‑criado [MasterSlide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/masterslide/).

O exemplo a seguir aplica um tema externo aos slides que dependem do primeiro mestre e salva a apresentação:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const selectedMaster = presentation.getMasters().get_Item(0);
    const themedMaster = selectedMaster.applyExternalThemeToDependingSlides("corporate-theme.thmx");

    console.log("Created master: " + themedMaster.getName());
    presentation.save("presentation-with-external-theme.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Um tema inválido, corrompido ou não suportado pode causar [PptxReadException](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pptxreadexception/). Valide os caminhos fornecidos pelos usuários, trate falhas de acesso ao sistema de arquivos e salve a apresentação somente após o tema ter sido aplicado com sucesso.

Só os slides que dependiam do mestre selecionado são realocados. Slides associados a outros mestres mantêm seus mestres e temas existentes. Cores, fontes, preenchimentos, linhas, planos de fundo e efeitos sensíveis ao tema são resolvidos em relação ao tema externo. Cores, fontes, preenchimentos e outras formatações atribuídas diretamente podem permanecer inalterados. Substituições em nível de layout e slide também podem ter precedência sobre valores herdados do novo mestre.

O tema pode referir‑se a fontes que não estão disponíveis no ambiente de tempo de execução. Para renderização e exportação consistentes, instale as fontes necessárias, forneça‑as por meio de [fontes personalizadas](/slides/pt/nodejs-java/custom-font/), ou configure [substituição de fontes](/slides/pt/nodejs-java/font-substitution/).

Este é um fluxo de trabalho direto ao nível do mestre: o método aceita um caminho de arquivo `.thmx` e não requer a criação manual de substituições de tema em nível de slide ou layout.

### **Aplicar Temas Externos Diferentes em uma Apresentação com Múltiplos Mestres**

Quando o mestre relevante não é conhecido antecipadamente, obtenha‑o a partir de um slide representativo por meio de [Slide.getLayoutSlide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slide/) e [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/layoutslide/). Armazene as referências originais dos mestres antes de aplicar quaisquer temas, pois cada chamada cria outro mestre na apresentação.

O exemplo a seguir usa slides de duas seções para localizar seus mestres e aplica um tema externo diferente a cada grupo:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("multi-master-presentation.pptx");
try {
    if (presentation.getSlides().size() < 5) {
        console.log("The presentation does not contain the expected representative slides.");
    } else {
        const firstGroupMaster = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide();
        const secondGroupMaster = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide();

        if (firstGroupMaster.getSlideId() === secondGroupMaster.getSlideId()) {
            console.log("The representative slides use the same master.");
        } else {
            const firstThemedMaster = firstGroupMaster.applyExternalThemeToDependingSlides("blue-theme.thmx");
            const secondThemedMaster = secondGroupMaster.applyExternalThemeToDependingSlides("green-theme.thmx");

            console.log("First themed master: " + firstThemedMaster.getName());
            console.log("Second themed master: " + secondThemedMaster.getName());
            presentation.save("multi-master-with-external-themes.pptx", aspose.slides.SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

A primeira chamada afeta somente os slides que dependiam de `firstGroupMaster`, e a segunda chamada afeta somente os slides que dependiam de `secondGroupMaster`. Slides pertencentes a qualquer outro mestre não são restilizados.

### **Preservar um Tema de Origem ao Mover Slides**

Se você quiser mover um slide para outra apresentação e preservar seu design original, clone o mestre de origem na apresentação de destino com [MasterSlideCollection.addClone](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/masterslidecollection/), então clone o slide com [SlideCollection.addClone](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slidecollection/) e o mestre clonado. Isso transporta o mestre, seus layouts e o tema associado juntos.

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

Este é o fluxo de trabalho recomendado quando o slide de origem deve ter a mesma aparência no destino. Clonar apenas o conteúdo em um mestre de destino não relacionado pode alterar cores, fontes, planos de fundo e efeitos conduzidos pelo tema.

### **Aplicar Valores de Tema a um Slide Existente**

Se o slide de destino precisar permanecer no seu mestre e layout atuais, inicialize uma substituição ao nível do slide a partir do tema de origem. Os métodos [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/overridetheme/) e [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/overridetheme/) copiam os três principais componentes do tema para a substituição.

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

Isso altera o tema usado por aquele slide sem mudar o tema herdado pelos outros slides. Para remover a substituição local e retornar aos valores herdados, chame [OverrideTheme.clear](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/overridetheme/).

### **Aplicar uma Substituição de Tema a um Layout**

Uma substituição ao nível de layout se aplica aos slides que usam esse layout, a menos que um slide específico tenha sua própria substituição. Os mesmos métodos de inicialização podem ser usados por meio do [LayoutSlideThemeManager](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/layoutslidethememanager/):

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

Use um tema ao nível de mestre ou apresentação quando muitos layouts e slides devem compartilhar o mesmo design base, uma substituição de layout quando uma família de layouts precisa de um estilo diferente, e uma substituição de slide apenas para exceções reais. Substituições excessivas ao nível de slide dificultam a previsão de mudanças globais de tema posteriores.

## **Atualizar Estilos de Plano de Fundo do Tema**

Os preenchimentos de plano de fundo do tema são armazenados em [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/formatscheme/). O PowerPoint pode apresentar mais opções de plano de fundo em sua interface do que o número de definições de preenchimento fisicamente armazenadas nesta coleção, pois a UI pode combinar preenchimentos de tema com cores de tema e outras referências de estilo.

![Galeria de estilos de plano de fundo do PowerPoint para um tema de apresentação](presentation-design_8.png)

Antes de usar um estilo de plano de fundo, inspecione a coleção armazenada e o índice de estilo atual de [Background.getStyleIndex](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/background/). Um índice de estilo `0` significa que não há preenchimento temático; valores positivos são referências a estilos de plano de fundo do tema. Isso difere da indexação direta da coleção JavaScript, onde o índice `0` representa o primeiro item armazenado. Não presuma que toda apresentação contenha o mesmo número de estilos de preenchimento de plano de fundo.

O exemplo a seguir relata a contagem de preenchimentos de plano de fundo disponíveis, atribui uma referência de plano de fundo temático ao primeiro mestre e salva a apresentação:

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

O resultado visível depende da entrada de tema referenciada pelo mestre e de quaisquer substituições de plano de fundo no nível de layout ou slide. Se um slide usa seu próprio plano de fundo, alterar apenas o plano de fundo do mestre pode não afetar esse slide. Use [Background.getEffective](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/background/) quando precisar saber o plano de fundo final após a aplicação da herança.

{{% alert color="warning" title="Aviso" %}}
Não trate o índice de estilo como um índice de coleção baseado em zero. Também evite codificar um número de estilo de um arquivo e presumir que ele terá a mesma aparência em outro arquivo; definições de estilo de tema são específicas da apresentação.
{{% /alert %}}

{{% alert color="info" title="Dica" %}}
Para formatação direta de plano de fundo e herança de plano de fundo, veja [Presentation Background](/slides/pt/nodejs-java/presentation-background/).
{{% /alert %}}

## **Atualizar Efeitos do Tema**

Um esquema de formato de tema contém coleções separadas de estilos de preenchimento, linha e efeito expostas por meio de [FormatScheme.getFillStyles](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/formatscheme/) e [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/formatscheme/). Temas típicos do Office costumam conter três entradas de estilo principais que correspondem visualmente a formatações sutil, moderada e intensa, mas o código deve inspecionar cada coleção em vez de assumir uma contagem fixa.

![Efeitos de tema sutis, moderados e intensos aplicados ao mesmo formato](presentation-design_10.png)

Ao acessar essas coleções em JavaScript, o índice da coleção é baseado em zero: índice `0` é o primeiro estilo armazenado e índice `2` é o terceiro. Os índices de referência de estilo de uma forma são um conceito separado, exposto por meio de [ShapeStyle](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shapestyle/). Modificar um estilo de tema afeta as formas que referenciam esse estilo; formas com formatação direta podem permanecer inalteradas.

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

Para as formas que referenciam esses slots, o primeiro estilo de linha do tema torna‑se vermelho, o terceiro estilo de preenchimento do tema torna‑se verde floresta sólido, e o terceiro estilo de efeito ganha uma sombra externa com distância de 10 pontos. O resultado visual exato ainda depende de quais slots de estilo cada forma referencia e se a formatação direta sobrescreve o tema.

![Estilos de efeito do tema após alterar configurações de linha, preenchimento e sombra](presentation-design_11.png)

## **Ler Valores Efetivos do Tema**

Objetos de tema brutos informam o que está definido em um determinado nível. Valores efetivos informam o que um slide ou forma realmente usa após a herança e substituições locais serem resolvidas. Para um slide, chame [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseoverridethememanager/). Para um plano de fundo, use [Background.getEffective](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/background/), e para um preenchimento, use [FillFormat.getEffective](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fillformat/).

O exemplo a seguir lê o tema efetivo, o plano de fundo e o preenchimento da primeira forma de um slide:

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

Use dados efetivos para diagnósticos de renderização, validação e comparações. Se você inspecionar apenas [Presentation.getMasterTheme](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/getmastertheme/), pode perder um mestre, layout, slide ou substituição de forma que altere a aparência final.

## **FAQ**

**Aplicar um tema externo afeta todos os slides da apresentação?**

Não. [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/masterslide/) realoca apenas os slides que dependem do mestre selecionado. Slides que usam outros mestres mantêm seus temas existentes.

**Posso aplicar um tema a um único slide sem mudar o mestre?**

Sim. Use o [SlideThemeManager](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slidethememanager/) do slide e inicialize seu tema de substituição. A alteração permanece local ao slide; os demais slides continuam a herdar seus temas atuais.

**Qual é a maneira mais segura de transportar um tema de uma apresentação para outra?**

Ao mover um slide e preservar sua aparência de origem, clone o mestre de origem na apresentação de destino e clone o slide com esse mestre usando [MasterSlideCollection.addClone](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/masterslidecollection/) e [SlideCollection.addClone](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slidecollection/). Isso mantém o mestre, os layouts e o tema juntos.

**Como posso ver os valores efetivos após herança e substituições?**

Use [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseoverridethememanager/) para um tema de slide ou layout e os métodos de dados efetivos correspondentes para objetos de formato, como [Background.getEffective](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/background/) e [FillFormat.getEffective](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fillformat/). Essas APIs retornam os valores resolvidos após a aplicação de herança e substituições.