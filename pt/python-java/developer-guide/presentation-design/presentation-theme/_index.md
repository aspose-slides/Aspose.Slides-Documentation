---
title: Gerenciar Temas de Apresentação em Python via Java
linktitle: Tema de Apresentação
type: docs
weight: 10
url: /pt/python-java/presentation-theme/
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
- Apresentação
- Python
- Java
- Aspose.Slides
description: "Domine os temas de apresentação no Aspose.Slides para Python via Java para criar, personalizar e converter arquivos PowerPoint com branding consistente."
---
## **Introdução**

Um tema de apresentação define um conjunto coordenado de cores, fontes, estilos de plano de fundo, preenchimentos, linhas e efeitos. Objetos compatíveis com temas referem‑se a essas definições compartilhadas em vez de armazenar cada propriedade visual como um valor fixo, de modo que uma mudança de tema possa atualizar muitos objetos de uma só vez.

No Aspose.Slides, o tema de nível de apresentação está disponível através de [Presentation.getMasterTheme](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getMasterTheme). Uma apresentação também pode conter substituições de tema em níveis mais baixos. Um mestre pode substituir o tema da apresentação através de [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masterthememanager/#getOverrideTheme), enquanto um layout ou um slide individual pode substituir seu tema herdado através de [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseoverridethememanager/#getOverrideTheme). Na prática, o tema efetivo para um slide é resolvido por esta cadeia de herança: tema da apresentação, substituição do mestre, substituição do layout e substituição do slide.

![Componentes do tema: cores, fontes, estilos de plano de fundo e efeitos](theme-constituents.png)

As seções abaixo mostram os fluxos de trabalho de tema mais comuns: inspecionar um tema, alterar cores e fontes, copiar ou aplicar um tema, atualizar estilos de plano de fundo e efeitos, e ler valores efetivos após a herança e as substituições terem sido resolvidas.

## **Inspecionar um Tema**

O objeto [MasterTheme](https://reference.aspose.com/slides/pt/python-java/aspose.slides/mastertheme/) expõe o esquema de cores, o esquema de fontes e o esquema de formatos do tema através de [MasterTheme.getColorScheme](https://reference.aspose.com/slides/pt/python-java/aspose.slides/mastertheme/#getColorScheme), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/pt/python-java/aspose.slides/mastertheme/#getFontScheme) e [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/pt/python-java/aspose.slides/mastertheme/#getFormatScheme). Inspecionar essas coleções antes de modificá‑las é especialmente útil quando uma apresentação vem de uma fonte externa, pois o número e o conteúdo das entradas de estilo podem variar.

O exemplo a seguir lê as principais propriedades do tema e informa quantos estilos de plano de fundo, preenchimento, linha e efeito estão armazenados no tema:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    theme = presentation.getMasterTheme()
    print("Theme name:", theme.getName())
    print("Accent 1:", theme.getColorScheme().getAccent1().getColor())
    print("Major Latin font:", theme.getFontScheme().getMajor().getLatinFont().getFontName())
    print("Minor Latin font:", theme.getFontScheme().getMinor().getLatinFont().getFontName())
    print("Background fill styles:", theme.getFormatScheme().getBackgroundFillStyles().size())
    print("Fill styles:", theme.getFormatScheme().getFillStyles().size())
    print("Line styles:", theme.getFormatScheme().getLineStyles().size())
    print("Effect styles:", theme.getFormatScheme().getEffectStyles().size())
finally:
    presentation.dispose()
```

Se um arquivo usar vários mestres, não presuma que todo slide tem o mesmo tema efetivo. Inspecione o mestre associado ao slide e use o fluxo de trabalho de tema efetivo mostrado mais adiante neste artigo quando substituições de layout ou slide puderem estar presentes.

## **Alterar Cores do Tema**

Preenchimentos, linhas e texto compatíveis com tema podem referir‑se a uma cor lógica da enumeração [SchemeColor](https://reference.aspose.com/slides/pt/python-java/aspose.slides/schemecolor/). Quando você altera a entrada correspondente no [ColorScheme](https://reference.aspose.com/slides/pt/python-java/aspose.slides/colorscheme/), todos os objetos que ainda referenciam aquela cor de tema são resolvidos contra o novo valor. Objetos que utilizam uma cor RGB direta não são alterados por uma atualização de cor de tema.

O exemplo completo a seguir cria uma forma que usa `Accent4`, altera a cor `Accent4` do tema para vermelho, salva a apresentação, reabre‑a e imprime a cor de preenchimento efetiva:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, SchemeColor, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED)
    presentation.save("theme-color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

saved_presentation = Presentation("theme-color.pptx")
try:
    saved_slide = saved_presentation.getSlides().get_Item(0)
    saved_shape = saved_slide.getShapes().get_Item(0)
    effective_fill = saved_shape.getFillFormat().getEffective()
    print("Effective fill color:", effective_fill.getSolidFillColor())
finally:
    saved_presentation.dispose()
```

Como o retângulo continua vinculado a `Accent4`, sua cor visível torna‑se vermelha após a mudança de tema. Se você substituir a cor do esquema por uma cor direta na forma, alterações posteriores em `Accent4` não afetarão mais esse preenchimento.

### **Usar Cores da Paleta Adicional**

O PowerPoint deriva variantes mais claras e mais escuras de uma cor de tema aplicando transformações de cor. O Aspose.Slides expõe essas transformações através da enumeração [ColorTransformOperation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/colortransformoperation/).

![Cores principais do tema e cores mais claras e mais escuras geradas a partir da paleta adicional](additional-palette-colors.png)

**1** – Cores principais do tema.  
**2** – Variantes mais claras e mais escuras produzidas a partir das cores principais do tema.

O exemplo a seguir cria seis retângulos baseados em `Accent4`, aplica transformações de luminância a cinco deles e salva o resultado:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, FillType, Presentation, SaveFormat, SchemeColor, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    base_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50)
    base_shape.getFillFormat().setFillType(FillType.Solid)
    base_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)

    lightest_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50)
    lightest_shape.getFillFormat().setFillType(FillType.Solid)
    lightest_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    lightest_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2)
    lightest_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8)

    lighter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50)
    lighter_shape.getFillFormat().setFillType(FillType.Solid)
    lighter_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    lighter_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4)
    lighter_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6)

    light_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50)
    light_shape.getFillFormat().setFillType(FillType.Solid)
    light_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    light_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6)
    light_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4)

    dark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50)
    dark_shape.getFillFormat().setFillType(FillType.Solid)
    dark_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    dark_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75)

    darker_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50)
    darker_shape.getFillFormat().setFillType(FillType.Solid)
    darker_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    darker_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5)

    presentation.save("theme-color-palette.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Essas variantes permanecem baseadas na cor do tema. Se `Accent4` mudar depois, as cores transformadas são recalculadas a partir do novo valor de `Accent4`.

### **Mapear Valores de `SchemeColor` para Slots de `ColorScheme`**

A enumeração [SchemeColor](https://reference.aspose.com/slides/pt/python-java/aspose.slides/schemecolor/) usa `Text1`, `Background1`, `Text2` e `Background2`, enquanto o [ColorScheme](https://reference.aspose.com/slides/pt/python-java/aspose.slides/colorscheme/) expõe os mesmos slots do tema como `Dark1`, `Light1`, `Dark2` e `Light2`. O mapeamento é fixo:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Esses são nomes alternativos para os mesmos slots de tema; não são valores convertidos dinamicamente de uma forma para outra.

## **Alterar Fontes do Tema**

Um esquema de fontes de tema contém um conjunto de fontes principal para títulos e um conjunto de fontes secundário para o corpo do texto. Os métodos [FontScheme.getMajor](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontscheme/#getMajor) e [FontScheme.getMinor](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontscheme/#getMinor) expõem esses conjuntos.

Identificadores de fonte de tema compatíveis com PowerPoint podem ser usados na formatação de texto:

* `+mn-lt` – Fonte do Corpo Latin (Minor Latin Font)
* `+mj-lt` – Fonte do Título Latin (Major Latin Font)
* `+mn-ea` – Fonte do Corpo East Asian (Minor East Asian Font)
* `+mj-ea` – Fonte do Título East Asian (Major East Asian Font)

O exemplo a seguir cria um título que usa a fonte latina principal do tema e uma linha de corpo que usa a fonte latina secundária do tema. Em seguida, altera as fontes do tema e salva o resultado:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 500, 60)
    heading.getTextFrame().setText("Theme heading")
    font_data = FontData("+mj-lt")
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(font_data)

    body = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 120, 500, 60)
    body.getTextFrame().setText("Theme body text")
    font_data = FontData("+mn-lt")
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(font_data)

    font_data = FontData("Aptos Display")
    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(font_data)
    font_data = FontData("Arial")
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(font_data)
    presentation.save("theme-fonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O título segue a fonte principal e o texto do corpo segue a fonte secundária. Texto que possui um nome de fonte explícito em vez de um identificador de tema não mudará automaticamente quando o esquema de fontes do tema mudar.

As coleções principal e secundária de fontes também podem conter mapeamentos de fontes para sistemas de escrita individuais, como Cirílico, Árabe, Japonês, Georgiano e Thaana. Para inspecionar, adicionar, substituir ou remover esses mapeamentos, veja [Script-Specific Theme Fonts](/slides/pt/python-java/script-specific-font-mappings/).

{{% alert color="success" title="Dica" %}}
Para mais informações sobre fontes em apresentações, veja [PowerPoint Fonts](/slides/pt/python-java/powerpoint-fonts/).
{{% /alert %}}

## **Copiar ou Aplicar um Tema**

Os fluxos de trabalho abaixo resolvem diferentes problemas relacionados a temas.

### **Aplicar um Tema Externo aos Slides Dependentes de um Mestre**

Use [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides) quando você tem um arquivo de tema do PowerPoint (`.thmx`) e quer restilizar cada slide que depende de um mestre específico. Selecione o mestre da coleção [Presentation.getMasters](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getMasters), representada por [MasterSlideCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masterslidecollection/), e passe o caminho do arquivo de tema para o método.

O método realiza as seguintes operações:

1. Cria um novo slide mestre baseado no mestre selecionado.  
1. Aplica o tema externo ao novo mestre.  
1. Atribui o novo mestre a todos os slides que anteriormente dependiam do mestre selecionado.  
1. Retorna o recém‑criado [MasterSlide](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masterslide/).

O exemplo a seguir aplica um tema externo aos slides que dependem do primeiro mestre e salva a apresentação:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    selected_master = presentation.getMasters().get_Item(0)
    themed_master = selected_master.applyExternalThemeToDependingSlides("corporate-theme.thmx")

    print("Created master:", themed_master.getName())
    presentation.save("presentation-with-external-theme.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Um tema inválido, corrompido ou não suportado pode causar [PptxReadException](https://reference.aspose.com/slides/pt/python-java/aspose.slides/pptxreadexception/). Valide os caminhos fornecidos pelos usuários, trate falhas de acesso ao sistema de arquivos e salve a apresentação somente depois que o tema for aplicado com sucesso.

Apenas os slides que dependiam do mestre selecionado são reatribuidos. Slides associados a outros mestres mantêm seus mestres e temas existentes. Cores, fontes, preenchimentos, linhas, planos de fundo e efeitos compatíveis com tema são resolvidos contra o tema externo. Cores, fontes, preenchimentos e outras formatações atribuídas diretamente podem permanecer inalterados. Substituições em nível de layout e de slide também podem ter precedência sobre valores herdados do novo mestre.

O tema pode referenciar fontes que não estão disponíveis no ambiente de tempo de execução. Para renderização e exportação consistentes, instale as fontes necessárias, disponibilize‑as através de [fontes personalizadas](/slides/pt/python-java/custom-font/), ou configure [substituição de fontes](/slides/pt/python-java/font-substitution/).

Este é um fluxo de trabalho direto em nível de mestre: o método aceita um caminho de arquivo `.thmx` e não requer a criação manual de substituições de tema em nível de layout ou slide.

### **Aplicar Temas Externos Diferentes em uma Apresentação com Múltiplos Mestres**

Quando o mestre relevante não é conhecido antecipadamente, obtenha‑o a partir de um slide representativo através de [Slide.getLayoutSlide](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slide/#getLayoutSlide) e [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/pt/python-java/aspose.slides/layoutslide/#getMasterSlide). Armazene as referências originais dos mestres antes de aplicar quaisquer temas, pois cada chamada cria outro mestre na apresentação.

O exemplo a seguir usa slides de duas seções para localizar seus mestres e aplica um tema externo diferente a cada grupo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("multi-master-presentation.pptx")
try:
    if presentation.getSlides().size() < 5:
        print("The presentation does not contain the expected representative slides.")
    else:
        first_group_master = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide()
        second_group_master = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide()

        if first_group_master.getSlideId() == second_group_master.getSlideId():
            print("The representative slides use the same master.")
        else:
            first_themed_master = first_group_master.applyExternalThemeToDependingSlides("blue-theme.thmx")
            second_themed_master = second_group_master.applyExternalThemeToDependingSlides("green-theme.thmx")

            print("First themed master:", first_themed_master.getName())
            print("Second themed master:", second_themed_master.getName())
            presentation.save("multi-master-with-external-themes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A primeira chamada afeta apenas os slides que dependiam de `first_group_master`, e a segunda chamada afeta apenas os slides que dependiam de `second_group_master`. Slides pertencentes a qualquer outro mestre não são restilizados.

### **Preservar um Tema de Origem ao Mover Slides**

Se você deseja mover um slide para outra apresentação preservando seu design original, clone o mestre de origem na apresentação de destino com [MasterSlideCollection.addClone](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masterslidecollection/#addClone), então clone o slide com [SlideCollection.addClone](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slidecollection/#addClone) e o mestre clonado. Isso transporta o mestre, seus layouts e o tema associado juntos.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source = Presentation("source-theme.pptx")
try:
    target = Presentation("target.pptx")
    try:
        source_slide = source.getSlides().get_Item(0)
        source_master = source_slide.getLayoutSlide().getMasterSlide()
        cloned_master = target.getMasters().addClone(source_master)
        target.getSlides().addClone(source_slide, cloned_master, True)
        target.save("theme-preserved.pptx", SaveFormat.Pptx)
    finally:
        target.dispose()
finally:
    source.dispose()
```

Este é o fluxo de trabalho recomendado quando o slide de origem deve ter a mesma aparência no destino. Simplesmente clonar o conteúdo para um mestre de destino não relacionado pode alterar cores, fontes, fundos e efeitos controlados por tema.

### **Aplicar Valores de Tema a um Slide Existente**

Se o slide de destino deve permanecer no mestre e layout atuais, inicialize uma substituição em nível de slide a partir do tema de origem. Os métodos [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/pt/python-java/aspose.slides/overridetheme/#initColorSchemeFrom), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/pt/python-java/aspose.slides/overridetheme/#initFontSchemeFrom) e [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/pt/python-java/aspose.slides/overridetheme/#initFormatSchemeFrom) copiam os três principais componentes do tema para a substituição.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source = Presentation("source-theme.pptx")
try:
    target = Presentation("target.pptx")
    try:
        target_slide = target.getSlides().get_Item(0)
        override_theme = target_slide.getThemeManager().getOverrideTheme()
        override_theme.initColorSchemeFrom(source.getMasterTheme().getColorScheme())
        override_theme.initFontSchemeFrom(source.getMasterTheme().getFontScheme())
        override_theme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme())
        target.save("theme-applied-to-slide.pptx", SaveFormat.Pptx)
    finally:
        target.dispose()
finally:
    source.dispose()
```

Isso altera o tema usado por esse slide sem mudar o tema herdado por outros slides. Para remover a substituição local e retornar aos valores herdados, chame [OverrideTheme.clear](https://reference.aspose.com/slides/pt/python-java/aspose.slides/overridetheme/#clear).

### **Aplicar uma Substituição de Tema a um Layout**

Uma substituição em nível de layout aplica‑se aos slides que utilizam esse layout, a menos que um slide específico tenha sua própria substituição. Os mesmos métodos de inicialização podem ser usados através de [LayoutSlideThemeManager](https://reference.aspose.com/slides/pt/python-java/aspose.slides/layoutslidethememanager/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source = Presentation("source-theme.pptx")
try:
    target = Presentation("target.pptx")
    try:
        target_slide = target.getSlides().get_Item(0)
        target_layout = target_slide.getLayoutSlide()
        override_theme = target_layout.getThemeManager().getOverrideTheme()
        override_theme.initColorSchemeFrom(source.getMasterTheme().getColorScheme())
        override_theme.initFontSchemeFrom(source.getMasterTheme().getFontScheme())
        override_theme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme())
        target.save("theme-applied-to-layout.pptx", SaveFormat.Pptx)
    finally:
        target.dispose()
finally:
    source.dispose()
```

Use um tema em nível de mestre ou apresentação quando muitos layouts e slides devem compartilhar o mesmo design base, uma substituição de layout quando uma família de layouts precisa de estilo diferente, e uma substituição de slide apenas para exceções reais. Substituições excessivas em nível de slide tornam mudanças globais de tema posteriores mais difíceis de prever.

## **Atualizar Estilos de Plano de Fundo do Tema**

Os preenchimentos de plano de fundo do tema são armazenados em [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/pt/python-java/aspose.slides/formatscheme/#getBackgroundFillStyles). O PowerPoint pode apresentar mais opções de plano de fundo em sua UI do que o número de definições de preenchimento realmente armazenadas nesta coleção, pois a UI pode combinar preenchimentos de tema com cores de tema e outras referências de estilo.

![Galeria de estilos de plano de fundo do PowerPoint para um tema de apresentação](presentation-design_8.png)

Antes de usar um estilo de plano de fundo, inspecione a coleção armazenada e o índice atual de estilo obtido por [Background.getStyleIndex](https://reference.aspose.com/slides/pt/python-java/aspose.slides/background/#getStyleIndex). Um índice de estilo `0` significa que não há preenchimento temático; valores positivos são referências a estilos de plano de fundo temáticos. Isto difere de indexar a coleção diretamente, onde `get_Item(0)` significa o primeiro item armazenado. Não presuma que toda apresentação contenha o mesmo número de estilos de preenchimento de plano de fundo.

O exemplo a seguir relata a contagem de preenchimentos de plano de fundo disponíveis, atribui uma referência de plano de fundo temático ao primeiro mestre e salva a apresentação:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    background_styles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles()
    print("Background fill styles:", background_styles.size())
    if background_styles.size() == 0:
        print("The presentation theme does not contain background fill styles.")
    else:
        master_slide = presentation.getMasters().get_Item(0)
        master_slide.getBackground().setType(BackgroundType.Themed)
        master_slide.getBackground().setStyleIndex(1)
        presentation.save("theme-background.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O resultado visível depende da entrada de tema referenciada pelo mestre e de quaisquer substituições de plano de fundo no layout ou no slide. Se um slide usar seu próprio plano de fundo, mudar apenas o plano de fundo do mestre pode não alterar esse slide. Use [Background.getEffective](https://reference.aspose.com/slides/pt/python-java/aspose.slides/background/#getEffective) quando precisar conhecer o plano de fundo final após a aplicação da herança.

{{% alert color="warning" title="Aviso" %}}
Não trate o índice de estilo como um índice de coleção baseado em zero. Também evite codificar um número de estilo de um arquivo e presumir que ele terá a mesma aparência em outro arquivo; definições de estilo de tema são específicas da apresentação.
{{% /alert %}}

{{% alert color="success" title="Dica" %}}
Para formatação direta de plano de fundo e herança de plano de fundo, veja [Presentation Background](/slides/pt/python-java/presentation-background/).
{{% /alert %}}

## **Atualizar Efeitos do Tema**

Um esquema de formatos de tema contém coleções separadas de preenchimento, linha e efeito expostas através de [FormatScheme.getFillStyles](https://reference.aspose.com/slides/pt/python-java/aspose.slides/formatscheme/#getFillStyles), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/pt/python-java/aspose.slides/formatscheme/#getLineStyles) e [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/pt/python-java/aspose.slides/formatscheme/#getEffectStyles). Temas típicos do Office frequentemente contêm três entradas principais que correspondem visualmente a formatações sutil, moderada e intensa, mas o código deve inspecionar cada coleção em vez de assumir uma contagem fixa.

![Efeitos sutis, moderados e intensos do tema aplicados à mesma forma](presentation-design_10.png)

Ao acessar essas coleções em Python via Java, o índice da coleção é baseado em zero: `get_Item(0)` é o primeiro estilo armazenado e `get_Item(2)` é o terceiro. Os índices de referência de estilo de uma forma são um conceito separado, exposto através de [ShapeStyle](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapestyle/). Modificar um estilo de tema afeta formas que referenciam esse estilo; formas com formatação direta podem permanecer inalteradas.

O exemplo a seguir verifica se as entradas de estilo necessárias existem, altera o primeiro estilo de linha, altera o terceiro estilo de preenchimento, habilita uma sombra externa no terceiro estilo de efeito e salva o resultado:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("Subtle_Moderate_Intense.pptx")
try:
    format_scheme = presentation.getMasterTheme().getFormatScheme()
    if format_scheme.getLineStyles().size() < 1 or format_scheme.getFillStyles().size() < 3 or format_scheme.getEffectStyles().size() < 3:
        print("The theme does not contain the style entries required by this example.")
    else:
        format_scheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid)
        format_scheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED)
        format_scheme.getFillStyles().get_Item(2).setFillType(FillType.Solid)
        forest_green = Color(34, 139, 34)
        format_scheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(forest_green)
        effect_format = format_scheme.getEffectStyles().get_Item(2).getEffectFormat()
        effect_format.enableOuterShadowEffect()
        effect_format.getOuterShadowEffect().setDistance(10)
        presentation.save("theme-effects.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Para formas que referenciam esses slots, o primeiro estilo de linha do tema torna‑se vermelho, o terceiro estilo de preenchimento do tema torna‑se verde floresta sólido e o terceiro estilo de efeito ganha uma sombra externa com distância de 10 pontos. O resultado visual exato ainda depende de quais slots de estilo cada forma referencia e se a formatação direta sobrescreve o tema.

![Estilos de efeito do tema após alterar linha, preenchimento e configuração de sombra](presentation-design_11.png)

## **Determinar se um Preenchimento Sólido Efetivo Usa uma Cor de Tema**

Um preenchimento pode ser armazenado diretamente em um objeto ou herdado de um parágrafo, layout, mestre, estilo de tema ou outro nível de formatação. Chame [FillFormat.getEffective](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fillformat/#getEffective) para resolver essa hierarquia em dados de preenchimento efetivos imutáveis. Primeiro verifique `getFillType` no objeto de dados efetivo. Só quando for `FillType.Solid` você deve ler as propriedades de preenchimento sólido.

Para um preenchimento sólido, `getSolidFillColor` retorna o valor RGB final renderizado após herança, busca no tema e aplicação de transformações de cor. `getSolidFillSchemeColor` devolve o slot lógico correspondente da enumeração [SchemeColor](https://reference.aspose.com/slides/pt/python-java/aspose.slides/schemecolor/), como `Text1` ou `Accent6`. Um valor de `SchemeColor.NotDefined` indica que o preenchimento sólido efetivo não se baseia em uma cor de esquema. Em um fluxo de trabalho onde preenchimentos são cores de tema ou RGB direto, esse valor identifica um preenchimento RGB direto.

Não use apenas o valor local de [ColorFormat.getSchemeColor](https://reference.aspose.com/slides/pt/python-java/aspose.slides/colorformat/#getSchemeColor) para classificar um preenchimento. Por exemplo, uma porção de texto pode não ter cor de esquema definida localmente, logo seu valor local é `NotDefined`, enquanto seu preenchimento efetivo herda uma cor de tema e resolve para `Text1` ou `Accent6`. Por outro lado, `getSolidFillSchemeColor` informa qual slot lógico do tema gerou a cor efetiva, mas não indica se esse slot veio do objeto, parágrafo, layout, mestre ou outro nível da hierarquia.

O exemplo a seguir carrega uma apresentação, audita preenchimentos de formas e de porções de texto, imprime cada valor RGB final e a cor de esquema associada, e sinaliza preenchimentos sólidos que não acompanharão alterações de cor de tema:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, FillType, Presentation, SchemeColor

def audit_fill(object_name, local_fill):
    effective_fill = local_fill.getEffective()
    if effective_fill.getFillType() != FillType.Solid:
        print(f"{object_name}: fill type = {effective_fill.getFillType()}; not a solid fill.")
        return

    rgb = effective_fill.getSolidFillColor()
    effective_scheme_color = effective_fill.getSolidFillSchemeColor()
    local_scheme_color = local_fill.getSolidFillColor().getSchemeColor()
    print(f"{object_name}: RGB = #{rgb.getRed():02X}{rgb.getGreen():02X}{rgb.getBlue():02X}")
    print(f"{object_name}: local scheme = {local_scheme_color}, effective scheme = {effective_scheme_color}")
    if effective_scheme_color == SchemeColor.NotDefined:
        print(f"{object_name}: direct RGB or another non-scheme fill; audit as theme-independent.")
    else:
        print(f"{object_name}: theme-dependent through {effective_scheme_color}.")


presentation = Presentation("input.pptx")
try:
    for slide_index, slide in enumerate(presentation.getSlides()):
        for shape_index, shape in enumerate(slide.getShapes()):
            shape_name = f"Slide {slide_index + 1}, shape {shape_index + 1}"
            audit_fill(shape_name, shape.getFillFormat())
            if isinstance(shape, AutoShape):
                for paragraph_index, paragraph in enumerate(shape.getTextFrame().getParagraphs()):
                    for portion_index, portion in enumerate(paragraph.getPortions()):
                        portion_name = f"{shape_name}, paragraph {paragraph_index + 1}, portion {portion_index + 1}"
                        audit_fill(portion_name, portion.getPortionFormat().getFillFormat())
finally:
    presentation.dispose()
```

O ramo `NotDefined` fornece uma lista de auditoria de preenchimentos sólidos que não responderão a mudanças nos slots de cor de tema. Revise esses objetos quando uma apresentação precisar seguir uma nova paleta de marca. O valor RGB relatado ainda mostra a aparência corrente, enquanto o valor de esquema explica se essa aparência está conectada ao tema.

Objetos de formato efetivo são instantâneos. Após mudar o tema da apresentação, uma substituição de tema ou qualquer formatação herdada, chame `getEffective` novamente e leia um novo objeto de dados de preenchimento efetivo antes de comparar ou relatar cores.

## **Ler Valores Efetivos do Tema**

Objetos de tema brutos informam o que está definido em um nível específico. Valores efetivos informam o que um slide ou forma realmente usa após herança e substituições locais serem resolvidas. Para um slide, chame [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective). Para um plano de fundo, use [Background.getEffective](https://reference.aspose.com/slides/pt/python-java/aspose.slides/background/#getEffective), e para um preenchimento, use [FillFormat.getEffective](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fillformat/#getEffective).

O exemplo a seguir lê o tema efetivo, o plano de fundo e o primeiro preenchimento de forma de um slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    effective_theme = slide.getThemeManager().createThemeEffective()
    effective_background = slide.getBackground().getEffective()
    print("Effective major Latin font:", effective_theme.getFontScheme().getMajor().getLatinFont().getFontName())
    print("Effective minor Latin font:", effective_theme.getFontScheme().getMinor().getLatinFont().getFontName())
    print("Effective background fill type:", effective_background.getFillFormat().getFillType())
    if slide.getShapes().size() > 0:
        effective_fill = slide.getShapes().get_Item(0).getFillFormat().getEffective()
        print("First shape effective fill type:", effective_fill.getFillType())
        if effective_fill.getFillType() == FillType.Solid:
            print("First shape effective fill color:", effective_fill.getSolidFillColor())
finally:
    presentation.dispose()
```

Use dados efetivos para diagnóstico de renderização, validação e comparações. Se você inspecionar apenas [Presentation.getMasterTheme](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getMasterTheme), pode perder um mestre, layout, slide ou substituição de forma que altere a aparência final.

## **FAQ**

**Aplicar um tema externo afeta todos os slides da apresentação?**

Não. [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides) reatribui apenas os slides que dependem do mestre selecionado. Slides que usam outros mestres mantêm seus temas existentes.

**Posso aplicar um tema a um único slide sem mudar o mestre?**

Sim. Use o [SlideThemeManager](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slidethememanager/) do slide e inicialize sua substituição de tema. A mudança permanece local ao slide; outros slides continuam a herdar seus temas atuais.

**Qual a forma mais segura de transportar um tema de uma apresentação para outra?**

Ao mover um slide e preservar sua aparência original, clone o mestre de origem para o destino e clone o slide com esse mestre usando [MasterSlideCollection.addClone](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masterslidecollection/#addClone) e [SlideCollection.addClone](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slidecollection/#addClone). Isso mantém o mestre, layouts e tema together.

**Como posso ver os valores efetivos após herança e substituições?**

Use [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective) para um slide ou tema de layout e os métodos de dados efetivos correspondentes para objetos de formato, como [Background.getEffective](https://reference.aspose.com/slides/pt/python-java/aspose.slides/background/#getEffective) e [FillFormat.getEffective](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fillformat/#getEffective). Essas APIs retornam os valores resolvidos após a aplicação de herança e substituições.