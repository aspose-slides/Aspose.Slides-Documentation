---
title: Formatar texto de apresentação em Python via Java
linktitle: Formatação de texto
type: docs
weight: 50
url: /pt/python-java/text-formatting/
keywords:
- alinhar parágrafo
- estilo de texto
- fundo de texto
- transparência de texto
- espaçamento de caracteres
- propriedades de fonte
- família de fonte
- rotação de texto
- ângulo de rotação
- quadro de texto
- espaçamento entre linhas
- propriedade autofit
- âncora do quadro de texto
- tabulação de texto
- idioma padrão
- PowerPoint
- OpenDocument
- apresentação
- Python
- Java
- Aspose.Slides
description: "Formate e estilize texto em apresentações PowerPoint e OpenDocument usando Aspose.Slides para Python via Java. Personalize fontes, cores, alinhamento e muito mais."
---
## **Visão geral**

Este artigo mostra como formatar texto em apresentações PowerPoint e OpenDocument usando Aspose.Slides para Python via Java. Ele aborda cores de fundo, transparência, espaçamento entre caracteres, propriedades de fonte, rotação, espaçamento de parágrafos, comportamento de ajuste automático, ancoragem de texto, tabulações e configurações de idioma.

Salvo indicação em contrário, os exemplos usam [sample.pptx](sample.pptx). A primeira forma em seu primeiro slide é uma caixa de texto, e seu primeiro parágrafo contém o texto mostrado abaixo. Tanto os índices de slide quanto de forma são baseados em zero. Exemplos que selecionam trechos em negrito usam formatação efetiva, incluindo formatação negrito herdada:

![Texto de exemplo](sample_text.png)

Para encontrar e realçar texto literal ou correspondências de expressões regulares, veja [Search and Replace Text](/slides/pt/python-java/search-and-replace-text/).

## **Definir cor de fundo do texto**

Use [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) para definir a cor de realce padrão para um parágrafo, ou use [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getHighlightColor) para trechos individuais de texto.

O exemplo a seguir define um realce cinza claro como padrão para o primeiro parágrafo. Cores de realce explícitas em trechos individuais prevalecem sobre esse padrão:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Defina a cor de destaque para todo o parágrafo.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O resultado:

![O parágrafo cinza](gray_paragraph.png)

O exemplo de código abaixo demonstra como definir a cor de fundo para **trechos de texto com fonte em negrito**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Defina a cor de destaque para o trecho de texto.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O resultado:

![Os trechos de texto cinza](gray_text_portions.png)

## **Alinhar parágrafos de texto**

Use [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) para definir o alinhamento de parágrafo dentro de uma caixa de texto. O valor pode ser centralizado, alinhado à esquerda, à direita, justificado etc.

O exemplo de código a seguir mostra como alinhar o parágrafo ao **centro**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAlignment

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Defina o alinhamento do parágrafo para o centro.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center)

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O resultado:

![O parágrafo alinhado](aligned_paragraph.png)

## **Alinhar fontes dentro de uma linha**

Use [ParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setFontAlignment) para alinhar verticalmente trechos de texto com tamanhos de fonte diferentes dentro de uma linha. Essa configuração se aplica a todo o parágrafo e controla o alinhamento dentro de cada uma de suas linhas.

O exemplo autocontido a seguir cria quatro caixas de texto rotuladas em um slide. Cada parágrafo contém o mesmo texto em 18, 36 e 54 pontos, com um alinhamento de fonte diferente. Ele usa Arial, desativa ajuste automático e quebra de linha, e mantém as caixas de texto grandes o suficiente para uma única linha.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontAlignment, FontData, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    alignments = [FontAlignment.Baseline, FontAlignment.Top, FontAlignment.Center, FontAlignment.Bottom]
    alignment_names = ["Baseline", "Top", "Center", "Bottom"]
    font_sizes = [18.0, 36.0, 54.0]
    font = FontData("Arial")

    for i, alignment in enumerate(alignments):
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20 + i * 130, 660, 120)
        shape.getFillFormat().setFillType(FillType.NoFill)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

        text_frame = shape.getTextFrame()
        text_frame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
        text_frame.getTextFrameFormat().setWrapText(NullableBool.False_)

        label = text_frame.getParagraphs().get_Item(0)
        label.setText(alignment_names[i])
        label.getParagraphFormat().setAlignment(TextAlignment.Left)
        label.getParagraphFormat().getDefaultPortionFormat().setFontHeight(14)
        label.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)

        paragraph = Paragraph()
        paragraph.getParagraphFormat().setFontAlignment(alignment)
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left)
        paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        for font_size in font_sizes:
            portion = Portion("Ag ")
            portion.getPortionFormat().setFontHeight(font_size)
            paragraph.getPortions().add(portion)

        text_frame.getParagraphs().add(paragraph)

    presentation.save("font_alignment.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O resultado:

![Comparação de alinhamento de fonte Baseline, Top, Center e Bottom com tamanhos de fonte misturados](font_alignment.png)

O alinhamento de fonte usa métricas de fonte, de modo que as bordas visíveis de cada letra nem sempre se alinham exatamente. O exemplo inclui tanto uma letra maiúscula quanto um descendente para mostrar a diferença entre alinhamento de linha de base e inferior. A disponibilidade e substituição de fontes, os caracteres usados e a diferença nos tamanhos de fonte afetam o resultado. As dimensões da moldura, margens, espaçamento entre linhas, quebra de linha e ajuste automático também influenciam o layout; use as mesmas fontes e configurações de layout ao comparar os modos.

Essa configuração difere de [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment), que controla o alinhamento horizontal do parágrafo, e de [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAnchoringType), que posiciona o bloco de texto verticalmente dentro de sua forma. A formatação de sobrescrito e subscrito por meio de [BasePortionFormat.setEscapement](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setEscapement) desloca trechos individuais em relação à linha de base em vez de definir o alinhamento de fonte para as linhas do parágrafo.

## **Definir transparência para texto**

A transparência do texto é controlada através do componente alfa da cor atribuída a [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFillFormat). Nos exemplos abaixo, `alpha = 50` é um valor de canal alfa ARGB na escala de 0–255, não uma porcentagem de transparência.

O exemplo de código abaixo mostra como aplicar transparência ao **parágrafo inteiro**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

alpha = 50
text_color = Color(0, 0, 0, alpha)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Defina a cor de preenchimento do texto como cor transparente.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O resultado:

![O parágrafo transparente](transparent_paragraph.png)

O exemplo de código a seguir mostra como aplicar transparência a **trechos de texto com fonte em negrito**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

alpha = 50
text_color = Color(0, 0, 0, alpha)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Defina a transparência do trecho de texto.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O resultado:

![Os trechos de texto transparentes](transparent_text_portions.png)

## **Definir espaçamento de caracteres para texto**

Use [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setSpacing) para expandir ou condensar o espaçamento entre caracteres em uma caixa de texto. Os exemplos adicionam 3 pontos de espaçamento; valores negativos condensam o texto.

O código Python a seguir mostra como expandir o espaçamento de caracteres no **parágrafo inteiro**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Nota: Use valores negativos para comprimir o espaçamento de caracteres.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3) # Expanda o espaçamento de caracteres.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O resultado:

![O espaçamento de caracteres no parágrafo](character_spacing_in_paragraph.png)

O exemplo de código abaixo mostra como expandir o espaçamento de caracteres em **trechos de texto com fonte em negrito**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Observação: Use valores negativos para comprimir o espaçamento de caracteres.
            portion.getPortionFormat().setSpacing(3) # Expanda o espaçamento de caracteres.

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O resultado:

![O espaçamento de caracteres nos trechos de texto](character_spacing_in_text_portions.png)

### **Desativar kerning para fontes específicas**

Em alguns casos, o texto renderizado por Aspose.Slides pode parecer ligeiramente mais apertado que o mesmo texto exibido no PowerPoint. Isso pode acontecer porque o PowerPoint pode ignorar os dados de kerning para certas fontes, mesmo quando a fonte contém informações de kerning válidas e o kerning está habilitado nas configurações do PowerPoint.

Para aproximar a saída renderizada do PowerPoint nesses casos, você pode desativar o kerning para trechos de texto que usam a fonte afetada. Defina [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setKerningMinimalSize) para um valor maior que o tamanho real da fonte. Esse exemplo requer “presentation.pptx” com uma caixa de texto como a primeira forma no primeiro slide. Ele verifica os nomes de fontes efetivas, incluindo fontes herdadas, e define um limite de 100 pontos para trechos que usam Roboto. Isso desativa o kerning para trechos correspondentes com tamanho de fonte abaixo de 100 pontos:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    target_font = "Roboto"

    for paragraph in auto_shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            portion_format = portion.getPortionFormat().getEffective()
            fonts = (portion_format.getLatinFont(), portion_format.getEastAsianFont(), portion_format.getComplexScriptFont())
            if any(font is not None and font.getFontName() == target_font for font in fonts):
                portion.getPortionFormat().setKerningMinimalSize(100)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Para texto correspondente abaixo do limite, essa configuração impede o kerning e pode ajudar a alinhar a renderização do Aspose.Slides ao resultado visual do PowerPoint para fontes afetadas por esse comportamento específico do PowerPoint.

## **Gerenciar propriedades de fonte do texto**

As propriedades de fonte podem ser definidas ao nível do parágrafo através de [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) ou em trechos individuais através de [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/).

O exemplo a seguir define a fonte padrão do primeiro parágrafo como Times New Roman 12 pontos com negrito, itálico e sublinhado pontilhado. Formatação explícita em trechos individuais tem precedência sobre esses padrões:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, NullableBool, Presentation, SaveFormat, TextUnderlineType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Defina as propriedades de fonte para o parágrafo.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(12)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontBold(NullableBool.True_)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontItalic(NullableBool.True_)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontUnderline(TextUnderlineType.Dotted)
    font = FontData("Times New Roman")
    paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)

    presentation.save("font_properties_for_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O resultado:

![As propriedades de fonte do parágrafo](font_properties_for_paragraph.png)

O exemplo a seguir aplica Times New Roman 13 pontos, formatação itálica e sublinhado pontilhado a trechos cuja formatação efetiva é negrito:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, NullableBool, Presentation, SaveFormat, TextUnderlineType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Defina as propriedades de fonte para o trecho de texto.
            portion.getPortionFormat().setFontHeight(13)
            portion.getPortionFormat().setFontItalic(NullableBool.True_)
            portion.getPortionFormat().setFontUnderline(TextUnderlineType.Dotted)
            font = FontData("Times New Roman")
            portion.getPortionFormat().setLatinFont(font)

    presentation.save("font_properties_for_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O resultado:

![As propriedades de fonte dos trechos de texto](font_properties_for_text_portions.png)

## **Controlar normalização da altura do texto**

Use [BasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setNormaliseHeight) ao reproduzir tipografia de modelo ou investigar diferenças na altura dos caracteres. No PowerPoint, habilitar a normalização estica ou comprime individualmente os caracteres verticalmente para dar a eles uma altura visível uniforme dentro do trecho de texto. Isso não garante alturas de texto iguais entre fontes diferentes.

Defina a propriedade para [NullableBool.True_ or False_](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) para habilitar ou desabilitar explicitamente a normalização. `NullableBool.NotDefined` deixa a configuração local indefinida, de modo que o trecho herda seu valor, por exemplo, do [getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) do parágrafo. Não significa `False`. Use [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective) e leia `getNormaliseHeight` na formatação efetiva retornada para obter o valor booleano resolvido.

O exemplo autocontido a seguir requer **Arial** instalado. Ele cria dois blocos de texto contendo as mesmas letras maiúsculas, minúsculas, descendentes e caracteres acentuados em 54 pontos. Ambos os parágrafos habilitam a normalização por padrão. O trecho superior desabilita explicitamente; o inferior a herda. Os tamanhos da moldura, margens e espaçamento de parágrafo são idênticos, com quebra de linha e ajuste automático desativados para manter a comparação consistente. O exemplo imprime `False: False` e `NotDefined: True`, depois salva “text_height_normalization.pptx”.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    settings = [NullableBool.False_, NullableBool.NotDefined]
    setting_names = ["False", "NotDefined"]

    for i, setting in enumerate(settings):
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 60 + i * 200, 660, 150)
        shape.getFillFormat().setFillType(FillType.NoFill)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

        text_frame = shape.getTextFrame()
        text_frame.setText("Hxgjpq ÅÉ 0123")
        text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
        text_frame.getTextFrameFormat().setWrapText(NullableBool.False_)
        text_frame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        text_frame.getTextFrameFormat().setMarginTop(0)
        text_frame.getTextFrameFormat().setMarginLeft(0)

        paragraph = text_frame.getParagraphs().get_Item(0)
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left)
        paragraph.getParagraphFormat().setSpaceBefore(0)
        paragraph.getParagraphFormat().setSpaceAfter(0)
        paragraph.getParagraphFormat().setSpaceWithin(100)
        paragraph.getParagraphFormat().getDefaultPortionFormat().setNormaliseHeight(NullableBool.True_)

        portion = paragraph.getPortions().get_Item(0)
        font = FontData("Arial")
        portion.getPortionFormat().setLatinFont(font)
        portion.getPortionFormat().setFontHeight(54)
        portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
        portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
        portion.getPortionFormat().setNormaliseHeight(setting)

        print(f"{setting_names[i]}: {bool(portion.getPortionFormat().getEffective().getNormaliseHeight())}")

    presentation.save("text_height_normalization.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A comparação abaixo foi exportada da apresentação salva. A linha superior tem a normalização desativada (`False`); a linha inferior herda a configuração habilitada (`NotDefined` → `True`). Mantenha Arial instalado para reproduzir essa aparência.

![Texto Arial 54 pt com normalização desativada acima e normalização herdada habilitada abaixo](text_height_normalization.png)

A normalização altera a altura dos caracteres sem mudar o valor atribuído a [getFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFontHeight), que especifica o tamanho da fonte em pontos. [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceWithin) controla o espaçamento entre linhas, enquanto [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) controla como o texto ou seu contêiner se ajusta. Essas configurações servem a propósitos diferentes e podem afetar o layout geral de forma independente. Para mais detalhes sobre formatação de parágrafos e herança, veja [Manage Paragraph](/slides/pt/python-java/manage-paragraph/).

## **Aplicar e remover tachado**

Use [BasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setStrikethroughType) em um trecho de texto para exibir correções, termos cancelados ou preços anteriores sem excluir o texto original. Defina como [TextStrikethroughType.Single or Double](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/) para uma ou duas linhas sobre o texto.

Para remover o tachado, passe [TextStrikethroughType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/#None). Isso desabilita explicitamente o efeito, mesmo que a formatação circundante especifique tachado. Em contraste, [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/#NotDefined) deixa a configuração local indefinida, permitindo que o trecho herde a formatação, por exemplo, do parágrafo. Não garante que o tachado seja removido. Use [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective) para ler a formatação resultante, incluindo valores herdados.

O exemplo autocontido a seguir cria três comparações de preço. Cada parágrafo tem trechos separados para o rótulo, preço anterior e preço atual, de modo que somente o preço anterior é afetado. A primeira linha aplica e depois remove o tachado; as demais linhas mantêm tachado simples e duplo. Alterar essa configuração preserva o texto e sua outra formatação, incluindo o preço anterior em negrito.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType, TextAlignment, TextStrikethroughType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 620, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().getParagraphs().clear()

    labels = ["None: ", "Single: ", "Double: "]

    for label in labels:
        paragraph = Paragraph()
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left)
        paragraph.getParagraphFormat().setSpaceAfter(20)

        portion_format = paragraph.getParagraphFormat().getDefaultPortionFormat()
        portion_format.setFontHeight(28)
        font = FontData("Arial")
        portion_format.setLatinFont(font)
        portion_format.getFillFormat().setFillType(FillType.Solid)
        portion_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        label_portion = Portion(label)
        paragraph.getPortions().add(label_portion)

        previous_price = Portion("$100")
        previous_price.getPortionFormat().setFontBold(NullableBool.True_)
        paragraph.getPortions().add(previous_price)
        current_price = Portion(" → $80")
        paragraph.getPortions().add(current_price)

        shape.getTextFrame().getParagraphs().add(paragraph)

    paragraphs = shape.getTextFrame().getParagraphs()

    # Aplicar tachado, então remover explicitamente do primeiro preço anterior.
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single)
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.None_)

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single)
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Double)

    presentation.save("strikethrough.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O resultado, de cima para baixo: sem tachado, tachado simples e tachado duplo.

![Preços anteriores sem tachado, com tachado simples e com tachado duplo](strikethrough.png)

## **Definir rotação do texto**

Use [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) para definir uma orientação de texto predefinida dentro de uma forma.

O exemplo de código a seguir define a orientação do texto na forma para [TextVerticalType.Vertical270](https://reference.aspose.com/slides/python-java/aspose.slides/textverticaltype/), que gira o texto **90 graus no sentido anti‑horário**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextVerticalType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270)

    presentation.save("text_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O resultado:

![A rotação do texto](text_rotation.png)

## **Exibir dígitos lado a lado em texto vertical**

Para manter os dígitos de um número de dois algarismos lado a lado em um rótulo vertical japonês, coloque ambos os dígitos em um único trecho de texto e chame [BasePortionFormat.setKumimoji](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setKumimoji) nesse trecho. Ambos os rótulos neste exemplo usam [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/python-java/aspose.slides/textverticaltype/#EastAsianVertical) e MS Gothic 40 pt. Apenas a configuração [NullableBool](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) para os dígitos difere.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Portion, Presentation, SaveFormat, ShapeType, TextVerticalType

Color = jpype.JClass("java.awt.Color")
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    font = FontData("MS Gothic")

    for x, kumimoji in [(120, NullableBool.True_), (360, NullableBool.False_)]:
        label = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, 48, 120, 420)
        label.getFillFormat().setFillType(FillType.NoFill)
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

        frame = label.addTextFrame("")
        frame.getTextFrameFormat().setTextVerticalType(TextVerticalType.EastAsianVertical)

        paragraph = frame.getParagraphs().get_Item(0)
        default_format = paragraph.getParagraphFormat().getDefaultPortionFormat()
        default_format.setLatinFont(font)
        default_format.setEastAsianFont(font)
        default_format.setFontHeight(40)
        default_format.getFillFormat().setFillType(FillType.Solid)
        default_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        digits = Portion("12")
        digits.getPortionFormat().setKumimoji(kumimoji)
        
        portions = paragraph.getPortions()
        portions.clear()
        portions.add(Portion("令和"))
        portions.add(digits)
        portions.add(Portion("年"))

    presentation.save("vertical_date.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

No PowerPoint, o rótulo da esquerda (`True`) mostra os dígitos na vertical e lado a lado entre 和 e 年. No rótulo da direita (`False`), o par é girado 90 graus no sentido horário. Os caracteres japoneses ao redor permanecem na vertical em ambos os rótulos.

![Comparação no PowerPoint de rótulos de data vertical com dígitos na vertical à esquerda e dígitos girados à direita.](vertical_date.png)

## **Definir rotação personalizada para quadros de texto**

Use [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setRotationAngle) para definir um ângulo de rotação personalizado para um [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/).

O exemplo de código abaixo gira o quadro de texto em 3 graus no sentido horário dentro da forma:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setRotationAngle(3)

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O resultado:

![A rotação personalizada do texto](custom_text_rotation.png)

## **Definir espaçamento entre linhas de parágrafos**

Aspose.Slides fornece [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceBefore) e [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceWithin) para controlar o espaçamento de parágrafos. Essas propriedades são usadas da seguinte forma:

* Use um valor positivo para especificar o espaçamento entre linhas como porcentagem da altura da linha.
* Use um valor negativo para especificar o espaçamento entre linhas em pontos.

O exemplo a seguir define o espaçamento interno do primeiro parágrafo em 200 % da altura da linha (espaçamento duplo):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().setSpaceWithin(200)

    presentation.save("line_spacing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O resultado:

![O espaçamento entre linhas dentro do parágrafo](line_spacing.png)

## **Controlar quebra de linha**

As regras de quebra de linha de parágrafo são úteis em blocos de texto estreitos e apresentações que misturam texto latino e oriental. Os métodos a seguir pertencem a [ParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/), portanto aplicam‑se a um parágrafo inteiro:

- [setLatinLineBreak](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setLatinLineBreak) controla as regras de quebra de linha latinas. Em texto misto, alterá‑la também pode mudar onde o texto e pontuação orientais adjacentes se ajustam.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) controla as regras de quebra de linha orientais, incluindo restrições a caracteres no início e no fim de uma linha.

Essas regras não substituem [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setWrapText), que habilita a quebra automática dentro de um quadro de texto. Elas influenciam o layout quando a quebra ocorre; não inserem caracteres de quebra de linha. Uma quebra de linha explícita força uma nova linha dentro do parágrafo independentemente da largura disponível.

O exemplo autocontido a seguir cria um bloco de texto estreito contendo texto chinês e latino. Ele define ambas as opções de quebra de linha explicitamente e salva “line_breaking.pptx”. Para experimentar cada regra, altere o valor correspondente mantendo a outra configuração fixa. O exemplo usa Arial 24 pt e SimSun com largura de quadro de 160 pt e margens horizontais do quadro de texto zeradas. [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) é chamado com [TextAutofitType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/textautofittype/) para que o tamanho do texto e as dimensões do quadro permaneçam fixos.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 160, 300)
    shape.getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
    text_frame.getTextFrameFormat().setMarginLeft(0)
    text_frame.getTextFrameFormat().setMarginRight(0)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.setText("中文排版测试，PowerPoint 中文演示。")

    paragraph_format = paragraph.getParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Left)
    paragraph_format.getDefaultPortionFormat().setFontHeight(24)
    latin_font = FontData("Arial")
    paragraph_format.getDefaultPortionFormat().setLatinFont(latin_font)
    east_asian_font = FontData("SimSun")
    paragraph_format.getDefaultPortionFormat().setEastAsianFont(east_asian_font)
    paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph_format.setLatinLineBreak(NullableBool.False_)
    paragraph_format.setEastAsianLineBreak(NullableBool.True_)

    presentation.save("line_breaking.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Controlar pontuação suspensa**

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setHangingPunctuation) permite que pontuação elegível se estenda além da borda direita da linha de texto em vez de ocupar a linha seguinte. Aplica‑se a todo o parágrafo e difere de uma indentação suspensa.

O exemplo autocontido a seguir habilita pontuação suspensa em um quadro de texto de 100 pt de largura e salva “hanging_punctuation.pptx”. Com Arial 24 pt e margens horizontais do quadro de texto zeradas, o ponto final final permanece após “sentence” e se estende além da borda direita do texto. Defina a propriedade para [NullableBool.False_](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) para comparar: com essas configurações, o ponto ocupa uma linha separada. A quebra de linha está habilitada e o ajuste automático está desabilitado para manter a largura disponível fixa.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 200)
    shape.getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
    text_frame.getTextFrameFormat().setMarginLeft(0)
    text_frame.getTextFrameFormat().setMarginRight(0)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.setText("Simple text, next sentence.")

    paragraph_format = paragraph.getParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Left)
    paragraph_format.getDefaultPortionFormat().setFontHeight(24)
    latin_font = FontData("Arial")
    paragraph_format.getDefaultPortionFormat().setLatinFont(latin_font)
    paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph_format.setHangingPunctuation(NullableBool.True_)

    presentation.save("hanging_punctuation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Nem toda marca de pontuação pode ser suspensa. As [condições de fonte e layout descritas acima](#control-line-breaking) também se aplicam a esta comparação: mudar a fonte, largura disponível, margens ou configurações de ajuste automático pode remover a diferença visível.

## **Definir tipo de ajuste automático para quadros de texto**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) determina como o texto se comporta quando excede os limites de seu contêiner. Use‑o para controlar se o texto encolhe, transborda ou redimensiona a forma automaticamente. O exemplo a seguir configura a forma para redimensionar e ajustar seu texto e salva o resultado em “autofit_type.pptx”.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAutofitType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape)

    presentation.save("autofit_type.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Para contar linhas após quebra automática e ver como a largura do texto ou da forma altera o resultado, veja [Count Rendered Lines](/slides/pt/python-java/manage-paragraph/). A contagem de linhas por si só não indica se o texto transborda seu contêiner.

## **Definir âncora dos quadros de texto**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAnchoringType) define como o texto é posicionado verticalmente dentro de uma forma, por exemplo, no topo, meio ou base. O exemplo a seguir ancora o texto na base da primeira forma e salva o resultado em “text_anchor.pptx”.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAnchorType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom)

    presentation.save("text_anchor.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Definir tabulação de texto**

Use [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDefaultTabSize) e [ParagraphFormat.getTabs](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getTabs) para configurar tabulações em um parágrafo. O exemplo a seguir define o intervalo de tabulação padrão para 100 pt e adiciona uma tabulação alinhada à esquerda em 30 pt. Essas configurações afetam texto contendo caracteres de tabulação.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TabAlignment

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().setDefaultTabSize(100)
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left)

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O resultado:

![As tabulações do parágrafo](paragraph_tabs.png)

## **Definir idioma de revisão**

Aspose.Slides fornece [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLanguageId), que permite definir o idioma de revisão para um trecho de texto. O idioma de revisão determina o idioma usado para verificações ortográficas e gramaticais no PowerPoint.

O exemplo a seguir requer “presentation.pptx” com uma caixa de texto como a primeira forma no primeiro slide e ao menos um parágrafo. Ele substitui o conteúdo do primeiro parágrafo por “1。”, define SimSun como sua fonte e atribui o idioma de revisão Chinês Simplificado (`zh-CN`). Salva o resultado em “proofing_language.pptx”:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Portion, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    font = FontData("SimSun")

    text_portion = Portion()
    text_portion.getPortionFormat().setComplexScriptFont(font)
    text_portion.getPortionFormat().setEastAsianFont(font)
    text_portion.getPortionFormat().setLatinFont(font)

    # Defina o Id de um idioma de revisão.
    text_portion.getPortionFormat().setLanguageId("zh-CN")

    text_portion.setText("1。")
    paragraph.getPortions().add(text_portion)

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Copiar metadados de idioma**

Ao copiar texto multilíngue de um modelo, preserve tanto [BasePortionFormat.getLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getLanguageId) quanto [BasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getAlternativeLanguageId). O exemplo autocontido a seguir cria um trecho de origem com inglês dos EUA como idioma e francês como idioma alternativo e copia o texto e os identificadores para um trecho em uma nova apresentação.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

source = Portion("Hello! Bonjour!")
source.getPortionFormat().setLanguageId("en-US")
source.getPortionFormat().setAlternativeLanguageId("fr-FR")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 80)
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    destination = Portion()
    destination.setText(source.getText())
    destination.getPortionFormat().setLanguageId(source.getPortionFormat().getLanguageId())
    # Se a origem não tem idioma alternativo, None limpa o valor de destino.
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId())
    paragraph.getPortions().add(destination)

    presentation.save("copied_language_metadata.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Para testar uma origem sem idioma alternativo, omita a atribuição de `"fr-FR"`. O identificador alternativo será então `None`, e a mesma instrução de cópia preserva sua ausência sem introduzir um valor padrão, mesmo que o destino já possua um idioma alternativo atribuído.

Esses identificadores armazenam metadados de idioma. Preservá‑los não determina qual dicionário o PowerPoint seleciona para verificações ortográficas ou gramaticais.

## **Definir idioma padrão**

Use [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) para definir o idioma padrão para texto criado ao carregar ou criar uma apresentação. O exemplo a seguir cria uma apresentação com inglês dos EUA como idioma padrão de texto, adiciona uma caixa de texto e imprime `en-US` para seu primeiro trecho de texto.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("en-US")

presentation = Presentation(load_options)
try:
    slide = presentation.getSlides().get_Item(0)

    # Adicione uma forma retângulo com texto.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50)
    shape.getTextFrame().setText("Sample text")

    # Verifique o idioma da primeira porção.
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    print(portion.getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **Definir estilo de texto padrão**

Para aplicar formatação de texto padrão ao nível da apresentação, use [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDefaultTextStyle).

O exemplo a seguir define uma fonte negrito de 14 pt como padrão para parágrafos de nível superior em uma nova apresentação e salva em “default_text_style.pptx”. O texto pode herdar esses padrões a menos que uma formatação mais específica os sobrescreva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    # Obtenha o formato de parágrafo de nível superior.
    paragraph_format = presentation.getDefaultTextStyle().getLevel(0)

    if paragraph_format is not None:
        paragraph_format.getDefaultPortionFormat().setFontHeight(14)
        paragraph_format.getDefaultPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("default_text_style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Extrair texto com efeito de caixa alta**

No PowerPoint, aplicar o efeito de fonte **All Caps** faz o texto aparecer em maiúsculas no slide mesmo quando foi originalmente digitado em minúsculas. Quando você recupera tal trecho de texto com Aspose.Slides, a biblioteca devolve o texto exatamente como foi inserido. Para coincidir com o texto exibido, verifique [TextCapType](https://reference.aspose.com/slides/python-java/aspose.slides/textcaptype/) e converta a string retornada para maiúsculas quando o valor for `All`.

Este exemplo requer “sample2.pptx” com uma caixa de texto como a primeira forma no primeiro slide. Seu primeiro parágrafo contém “Hello, Aspose!” com o efeito All Caps aplicado, como mostrado abaixo.

![O efeito All Caps](all_caps_effect.png)

O exemplo de código abaixo mostra como extrair o texto com o efeito **All Caps** aplicado:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TextCapType

presentation = Presentation("sample2.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    auto_shape = slide.getShapes().get_Item(0)
    text_portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)

    print("Original text: " + str(text_portion.getText()))

    text_format = text_portion.getPortionFormat().getEffective()
    if text_format.getTextCapType() == TextCapType.All:
        text = str(text_portion.getText()).upper()
        print("All-Caps effect: " + text)
finally:
    presentation.dispose()
```

Saída:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Como modifico texto em uma tabela em um slide?**

Para modificar texto em uma tabela em um slide, use [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/). Percorra as células e atualize cada célula através de [Cell.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame) e a formatação de parágrafo através de [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getParagraphFormat).

**Como aplico uma cor de gradiente ao texto em um slide PowerPoint?**

Para aplicar uma cor de gradiente ao texto, use [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFillFormat). Defina [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) para [FillType.Gradient](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) e configure as paradas de gradiente, direção e transparência.