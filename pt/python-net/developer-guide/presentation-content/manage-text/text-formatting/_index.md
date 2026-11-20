---
title: Formatar Texto da Apresentação em Python
linktitle: Formatação de Texto
type: docs
weight: 50
url: /pt/python-net/text-formatting/
keywords:
- alinhar parágrafo
- estilo de texto
- fundo de texto
- transparência do texto
- espaçamento entre caracteres
- propriedades da fonte
- família da fonte
- rotação do texto
- ângulo de rotação
- quadro de texto
- espaçamento entre linhas
- propriedade de ajuste automático
- âncora do quadro de texto
- tabulação de texto
- idioma padrão
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Formatar e estilizar texto em apresentações PowerPoint e OpenDocument usando Aspose.Slides para Python via .NET. Personalize fontes, cores, alinhamento e muito mais."
---
## **Visão geral**

Este artigo mostra como formatar texto em apresentações PowerPoint e OpenDocument usando Aspose.Slides para Python via .NET. Ele abrange cores de fundo, transparência, espaçamento entre caracteres, propriedades de fonte, rotação, espaçamento de parágrafo, comportamento de ajuste automático, ancoragem de texto, tabulações e configurações de idioma.

Salvo indicação em contrário, os exemplos usam [sample.pptx](sample.pptx). A primeira forma no seu primeiro slide é uma caixa de texto, e seu primeiro parágrafo contém o texto mostrado abaixo. Tanto os índices de slide quanto de forma são baseados em zero. Exemplos que selecionam trechos em negrito usam formatação efetiva, incluindo formatação negrito herdada:

![Texto de exemplo](sample_text.png)

Para encontrar e realçar texto literal ou correspondências de expressão regular, veja [Pesquisar e Substituir Texto](/slides/pt/python-net/search-and-replace-text/).

## **Definir cor de fundo do texto**

Use [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) para definir a cor de realce padrão para um parágrafo, ou use [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/highlight_color/) para porções de texto individuais.

O exemplo a seguir define um realce cinza claro como padrão para o primeiro parágrafo. Cores de realce explícitas em porções individuais têm precedência sobre esse padrão:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Defina a cor de realce para todo o parágrafo.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![O parágrafo cinza](gray_paragraph.png)

O exemplo de código abaixo demonstra como definir a cor de fundo para **porções de texto com fonte em negrito**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Defina a cor de realce para a porção de texto.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![As porções de texto cinzas](gray_text_portions.png)

## **Alinhar parágrafos de texto**

Use [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) para definir o alinhamento do parágrafo dentro de um quadro de texto. O valor pode ser centralizado, alinhado à esquerda, à direita, justificado etc.

O exemplo de código a seguir mostra como alinhar o parágrafo ao **centro**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Defina o alinhamento do parágrafo para o centro.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![O parágrafo alinhado](aligned_paragraph.png)

## **Alinhar fontes dentro de uma linha**

Use [ParagraphFormat.font_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/font_alignment/) para alinhar verticalmente porções de texto com tamanhos de fonte diferentes dentro de uma linha. Essa configuração se aplica a todo o parágrafo e controla o alinhamento em cada uma de suas linhas.

O exemplo a seguir cria quatro caixas de texto rotuladas em um slide. Cada parágrafo contém o mesmo texto em 18, 36 e 54 pontos, com um alinhamento de fonte diferente. Usa Arial, desabilita ajuste automático e quebra de linha, e mantém os quadros de texto grandes o suficiente para uma única linha.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    alignments = [slides.FontAlignment.BASELINE, slides.FontAlignment.TOP, slides.FontAlignment.CENTER, slides.FontAlignment.BOTTOM]
    font_sizes = [18, 36, 54]

    for i, alignment in enumerate(alignments):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 20 + i * 130, 660, 120)
        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        text_frame = shape.text_frame
        text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
        text_frame.text_frame_format.wrap_text = slides.NullableBool.FALSE

        label = text_frame.paragraphs[0]
        label.text = alignment.name.title()
        label.paragraph_format.alignment = slides.TextAlignment.LEFT
        label.paragraph_format.default_portion_format.font_height = 14
        label.paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
        label.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        label.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.gray

        paragraph = slides.Paragraph()
        paragraph.paragraph_format.font_alignment = alignment
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
        paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black

        for font_size in font_sizes:
            portion = slides.Portion("Ag ")
            portion.portion_format.font_height = font_size
            paragraph.portions.add(portion)

        text_frame.paragraphs.add(paragraph)

    presentation.save("font_alignment.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![Comparação de alinhamento de fonte Baseline, Topo, Centro e Base com tamanhos de fonte misturados](font_alignment.png)

O alinhamento de fonte usa métricas tipográficas, portanto as bordas visíveis de letras individuais nem sempre se alinham exatamente. O exemplo inclui uma letra maiúscula e um descendente para ajudar a mostrar a diferença entre alinhamento de baseline e base. A disponibilidade e substituição de fontes, os caracteres usados e a diferença nos tamanhos de fonte afetam o resultado. As dimensões do quadro, margens, espaçamento entre linhas, quebra de linha e ajuste automático também influenciam o layout; use as mesmas fontes e configurações ao comparar modos.

Essa configuração difere de [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/), que controla o alinhamento horizontal do parágrafo, e de [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/), que posiciona o bloco de texto verticalmente dentro da forma. Formatação de sobrescrito e subscrito via [BasePortionFormat.escapement](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/escapement/) desloca porções individuais em relação ao baseline em vez de definir o alinhamento de fonte para as linhas do parágrafo.

## **Definir transparência para texto**

A transparência do texto é controlada pelo componente alfa da cor atribuída a [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/). Nos exemplos abaixo, `alpha = 50` é um valor de canal alfa ARGB na escala 0–255, não uma porcentagem de transparência.

O exemplo de código abaixo mostra como aplicar transparência ao **parágrafo inteiro**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Defina um preenchimento preto semitransparente para o texto.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![O parágrafo transparente](transparent_paragraph.png)

O exemplo de código a seguir mostra como aplicar transparência a **porções de texto com fonte em negrito**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Defina a transparência da porção de texto.
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![As porções de texto transparentes](transparent_text_portions.png)

## **Definir espaçamento entre caracteres para texto**

Use [BasePortionFormat.spacing](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/spacing/) para expandir ou condensar o espaçamento entre caracteres em uma caixa de texto. Os exemplos adicionam 3 pontos de espaçamento; valores negativos condensam o texto.

O código Python a seguir mostra como expandir o espaçamento entre caracteres no **parágrafo inteiro**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Nota: Use valores negativos para comprimir o espaçamento entre caracteres.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # Expandir espaçamento entre caracteres.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![O espaçamento entre caracteres no parágrafo](character_spacing_in_paragraph.png)

O exemplo de código abaixo mostra como expandir o espaçamento entre caracteres em **porções de texto com fonte em negrito**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Nota: Use valores negativos para comprimir o espaçamento entre caracteres.
            portion.portion_format.spacing = 3  # Expandir espaçamento entre caracteres.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![O espaçamento entre caracteres nas porções de texto](character_spacing_in_text_portions.png)

### **Desativar Kerning para fontes específicas**

Em alguns casos, o texto renderizado por Aspose.Slides pode parecer ligeiramente mais apertado que o mesmo texto exibido no PowerPoint. Isso pode acontecer porque o PowerPoint pode ignorar os dados de kerning para determinadas fontes, mesmo quando a fonte contém informações de kerning válidas e o kerning está habilitado nas configurações do PowerPoint.

Para tornar a saída renderizada mais próxima do PowerPoint nesses casos, você pode desativar o kerning para as porções de texto que usam a fonte afetada. Defina [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) para um valor maior que o tamanho real da fonte. Este exemplo requer “presentation.pptx” com uma caixa de texto como primeira forma no primeiro slide. Ele verifica os nomes de fontes efetivas, incluindo fontes herdadas, e define um limite de 100 pontos para as porções que usam Roboto. Isso desativa o kerning para as porções correspondentes com tamanho de fonte abaixo de 100 pontos:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    target_font = "Roboto"

    for paragraph in auto_shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            text_format = portion.portion_format.get_effective()
            fonts = (text_format.latin_font, text_format.east_asian_font, text_format.complex_script_font)
            uses_target_font = any(font is not None and font.font_name == target_font for font in fonts)

            if uses_target_font:
                portion.portion_format.kerning_minimal_size = 100

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Gerenciar propriedades de fonte do texto**

As propriedades de fonte podem ser definidas no nível do parágrafo através de [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) ou em porções individuais através de [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/).

O exemplo a seguir define a fonte padrão do primeiro parágrafo para Times New Roman 12 pontos com negrito, itálico e sublinhado pontilhado. Formatação explícita em porções individuais tem precedência sobre esses padrões:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Defina as propriedades da fonte para o parágrafo.
    portion_format = paragraph.paragraph_format.default_portion_format
    portion_format.font_height = 12
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_italic = slides.NullableBool.TRUE
    portion_format.font_underline = slides.TextUnderlineType.DOTTED
    portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![As propriedades de fonte do parágrafo](font_properties_for_paragraph.png)

O exemplo a seguir aplica Times New Roman 13 pontos, formatação itálica e sublinhado pontilhado a porções cuja formatação efetiva é negrito:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Defina as propriedades da fonte para a porção de texto.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![As propriedades de fonte das porções de texto](font_properties_for_text_portions.png)

## **Controlar a normalização da altura do texto**

Use [BasePortionFormat.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/normalise_height/) ao reproduzir tipografia de modelo ou investigar diferenças na altura dos caracteres. No PowerPoint, habilitar a normalização estica ou comprime verticalmente caracteres individuais para dar a eles uma altura visível uniforme dentro da porção de texto. Não garante alturas de texto iguais entre fontes diferentes.

Defina a propriedade para [NullableBool.TRUE or FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) para habilitar ou desabilitar explicitamente a normalização. `NullableBool.NOT_DEFINED` deixa a configuração local indefinida, permitindo que a porção herde seu valor, por exemplo, do [default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) do parágrafo. Não significa `False`. Use [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) e leia [IBasePortionFormatEffectiveData.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseportionformateffectivedata/normalise_height/) para obter o valor booleano resolvido.

O exemplo a seguir requer **Arial** instalado. Ele cria dois blocos de texto contendo as mesmas letras maiúsculas, minúsculas, descendentes e caracteres acentuados em 54 pontos. Ambos os parágrafos habilitam a normalização por padrão. A porção superior a desabilita explicitamente; a inferior a herda. As dimensões do quadro, margens e espaçamento de parágrafo são idênticos, com quebra de linha e ajuste automático desativados para manter a comparação consistente. O exemplo imprime `FALSE: False` e `NOT_DEFINED: True`, depois salva “text_height_normalization.pptx”.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    settings = [slides.NullableBool.FALSE, slides.NullableBool.NOT_DEFINED]

    for i, setting in enumerate(settings):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 60 + i * 200, 660, 150)
        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        text_frame = shape.text_frame
        text_frame.text = "Hxgjpq ÅÉ 0123"
        text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
        text_frame.text_frame_format.wrap_text = slides.NullableBool.FALSE
        text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        text_frame.text_frame_format.margin_top = 0
        text_frame.text_frame_format.margin_left = 0

        paragraph = text_frame.paragraphs[0]
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.space_before = 0
        paragraph.paragraph_format.space_after = 0
        paragraph.paragraph_format.space_within = 100
        paragraph.paragraph_format.default_portion_format.normalise_height = slides.NullableBool.TRUE

        portion = paragraph.portions[0]
        portion.portion_format.latin_font = slides.FontData("Arial")
        portion.portion_format.font_height = 54
        portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
        portion.portion_format.fill_format.solid_fill_color.color = "black"
        portion.portion_format.normalise_height = setting

        print(f"{setting.name}: {portion.portion_format.get_effective().normalise_height}")

    presentation.save("text_height_normalization.pptx", slides.export.SaveFormat.PPTX)
```

A comparação abaixo foi exportada da apresentação salva. A linha superior tem a normalização desativada (`FALSE`); a linha inferior herda a configuração habilitada (`NOT_DEFINED` → `True`). Mantenha Arial instalado para reproduzir esta aparência.

![Texto Arial de 54 pontos com normalização desativada acima e normalização herdada ativada abaixo](text_height_normalization.png)

A normalização altera a altura dos caracteres sem mudar o valor atribuído a [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/), que especifica o tamanho da fonte em pontos. O [space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) do parágrafo controla o espaçamento entre linhas, enquanto o [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) do quadro de texto controla como o texto ou seu contêiner se ajusta. Essas configurações servem a propósitos diferentes e podem afetar o layout geral de forma independente. Para mais informações sobre formatação de parágrafo e herança, veja [Manage Paragraph](/slides/pt/python-net/manage-paragraph/).

## **Aplicar e remover tachado**

Use [BasePortionFormat.strikethrough_type](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/strikethrough_type/) em uma porção de texto para exibir correções, termos cancelados ou preços anteriores sem excluir o texto original. Defina para [TextStrikethroughType.SINGLE or DOUBLE](https://reference.aspose.com/slides/python-net/aspose.slides/textstrikethroughtype/) para uma ou duas linhas sobre o texto.

Para remover o tachado, atribua `TextStrikethroughType.NONE`. Isso desabilita explicitamente o efeito, mesmo que a formatação ao redor especifique tachado. Em contraste, `TextStrikethroughType.NOT_DEFINED` deixa a configuração local indefinida, permitindo que a porção herde a formatação, por exemplo, do parágrafo. Não garante que o tachado seja removido. Use [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) para ler a formatação resultante, incluindo valores herdados.

O exemplo a seguir cria três comparações de preço. Cada parágrafo tem porções separadas para o rótulo, preço anterior e preço atual, de modo que apenas o preço anterior é afetado. A primeira linha aplica e depois remove o tachado; as demais linhas mantêm tachado simples e duplo. Alterar essa propriedade preserva o texto e sua outra formatação, incluindo o preço anterior em negrito:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 620, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.paragraphs.clear()

    labels = ["None: ", "Single: ", "Double: "]

    for label in labels:
        paragraph = slides.Paragraph()
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.space_after = 20

        portion_format = paragraph.paragraph_format.default_portion_format
        portion_format.font_height = 28
        portion_format.latin_font = slides.FontData("Arial")
        portion_format.fill_format.fill_type = slides.FillType.SOLID
        portion_format.fill_format.solid_fill_color.color = draw.Color.black

        paragraph.portions.add(slides.Portion(label))

        previous_price = slides.Portion("$100")
        previous_price.portion_format.font_bold = slides.NullableBool.TRUE
        paragraph.portions.add(previous_price)
        paragraph.portions.add(slides.Portion(" → $80"))

        shape.text_frame.paragraphs.add(paragraph)

    paragraphs = shape.text_frame.paragraphs

    # Aplique tachado, então remova‑o explicitamente do primeiro preço anterior.
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.NONE

    paragraphs[1].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[2].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.DOUBLE

    presentation.save("strikethrough.pptx", slides.export.SaveFormat.PPTX)
```

O resultado, de cima para baixo: sem tachado, tachado simples e tachado duplo.

![Preços anteriores sem tachado, com tachado simples e com tachado duplo](strikethrough.png)

## **Definir rotação de texto**

Use [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) para definir uma orientação de texto predefinida dentro de uma forma.

O exemplo de código a seguir define a orientação do texto na forma para [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/), que gira o texto **90 graus no sentido anti‑horário**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![A rotação do texto](text_rotation.png)

## **Definir rotação personalizada para quadros de texto**

Use [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) para definir um ângulo de rotação personalizado para um [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).

O exemplo de código abaixo gira o quadro de texto em 3 graus no sentido horário dentro da forma:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![A rotação personalizada do texto](custom_text_rotation.png)

## **Definir espaçamento entre linhas dos parágrafos**

Aspose.Slides fornece [ParagraphFormat.space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/), e [ParagraphFormat.space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) para controlar o espaçamento de parágrafos. Essas propriedades são usadas da seguinte forma:

* Use um valor positivo para especificar o espaçamento entre linhas como porcentagem da altura da linha.
* Use um valor negativo para especificar o espaçamento entre linhas em pontos.

O exemplo a seguir define o espaçamento interno do primeiro parágrafo para 200 % da altura da linha (espaçamento duplo):

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![O espaçamento entre linhas dentro do parágrafo](line_spacing.png)

## **Controlar quebra de linha**

As regras de quebra de linha de parágrafos são úteis em blocos de texto estreitos e apresentações que misturam texto latino e asiático oriental. As propriedades a seguir pertencem a [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/), portanto se aplicam a um parágrafo inteiro:

- [latin_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/latin_line_break/) controla as regras de quebra de linha latinas. Em texto misto, alterá‑la também pode mudar onde o texto e pontuação asiáticos adjacentes são quebrados.
- [east_asian_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/east_asian_line_break/) controla as regras de quebra de linha asiáticas orientais, incluindo restrições a caracteres no início ou no fim de uma linha.

Essas regras não substituem [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/), que habilita a quebra automática dentro de um quadro de texto. Elas influenciam o layout quando a quebra ocorre; não inserem caracteres de quebra de linha. Uma quebra de linha explícita força uma nova linha dentro do parágrafo independentemente da largura disponível.

O exemplo a seguir cria um bloco de texto estreito contendo chinês e texto latino. Define ambas as propriedades de quebra de linha explicitamente e salva “line_breaking.pptx”. Para experimentar cada regra, altere o valor da propriedade mantendo as demais configurações fixas. O exemplo usa Arial 24 pt e SimSun com largura de quadro de 160 pt e margens horizontais zero. [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) está definido como [TextAutofitType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/textautofittype/) para que o tamanho do texto e as dimensões do quadro permaneçam fixos.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 160, 300)
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame.text_frame_format.margin_left = 0
    text_frame.text_frame_format.margin_right = 0

    paragraph = text_frame.paragraphs[0]
    paragraph.text = "中文排版测试，PowerPoint 中文演示。"

    paragraph_format = paragraph.paragraph_format
    paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph_format.default_portion_format.font_height = 24
    paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
    paragraph_format.default_portion_format.east_asian_font = slides.FontData("SimSun")
    paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph_format.latin_line_break = slides.NullableBool.FALSE
    paragraph_format.east_asian_line_break = slides.NullableBool.TRUE

    presentation.save("line_breaking.pptx", slides.export.SaveFormat.PPTX)
```

## **Controlar pontuação suspensa**

[ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/hanging_punctuation/) permite que pontuação elegível se estenda além da borda direita da linha de texto em vez de ocupar a linha seguinte. Aplica‑se a todo o parágrafo e difere de uma indentação suspensa.

O exemplo a seguir habilita pontuação suspensa em um quadro de texto de 100 pt de largura e salva “hanging_punctuation.pptx”. Com Arial 24 pt e margens horizontais zero, o ponto final permanece após “sentence” e se estende além da borda direita do texto. Defina a propriedade para [NullableBool.FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) para comparar: com essas configurações, o ponto ocupa uma linha separada. A quebra de linha está habilitada e o ajuste automático desativado para manter a largura disponível fixa.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 200)
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame.text_frame_format.margin_left = 0
    text_frame.text_frame_format.margin_right = 0

    paragraph = text_frame.paragraphs[0]
    paragraph.text = "Simple text, next sentence."

    paragraph_format = paragraph.paragraph_format
    paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph_format.default_portion_format.font_height = 24
    paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
    paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph_format.hanging_punctuation = slides.NullableBool.TRUE

    presentation.save("hanging_punctuation.pptx", slides.export.SaveFormat.PPTX)
```

Nem toda pontuação pode ser suspensa. O resultado visível depende das [condições de fonte e layout](#control-line-breaking): mudar a fonte, a largura disponível, margens ou configurações de ajuste automático pode eliminar a diferença visível.

## **Definir tipo de ajuste automático para quadros de texto**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) determina como o texto se comporta quando excede os limites de seu contêiner. Use‑a para controlar se o texto diminui, transborda ou redimensiona a forma automaticamente. O exemplo a seguir configura a forma para redimensionar e caber seu texto e salva o resultado em “autofit_type.pptx”.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

Para contar linhas após a quebra automática e ver como a largura do texto ou da forma altera o resultado, veja [Count Rendered Lines](/slides/pt/python-net/manage-paragraph/). A contagem de linhas por si só não indica se o texto transborda seu contêiner.

## **Definir âncora dos quadros de texto**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) define como o texto é posicionado verticalmente dentro de uma forma, por exemplo, no topo, meio ou base. O exemplo a seguir ancora o texto na parte inferior da primeira forma e salva o resultado em “text_anchor.pptx”.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Definir tabulação de texto**

Use [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_tab_size/) e [ParagraphFormat.tabs](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/tabs/) para configurar tabulações em um parágrafo. O exemplo a seguir define o intervalo padrão de tabulação para 100 pt e adiciona uma tabulação alinhada à esquerda em 30 pt. Essas configurações afetam texto que contém caracteres de tabulação.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.default_tab_size = 100
    paragraph.paragraph_format.tabs.add(30, slides.TabAlignment.LEFT)

    presentation.save("paragraph_tabs.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![As tabulações do parágrafo](paragraph_tabs.png)

## **Definir idioma de revisão**

Aspose.Slides fornece [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/), que permite definir o idioma de revisão para uma porção de texto. O idioma de revisão determina o idioma usado para verificação ortográfica e gramatical no PowerPoint.

O exemplo a seguir requer “presentation.pptx” com uma caixa de texto como primeira forma no primeiro slide e ao menos um parágrafo. Substitui o conteúdo do primeiro parágrafo por “1。”, define SimSun como fonte e atribui o idioma de revisão Chinês Simplificado (`zh-CN`). Salva o resultado em “proofing_language.pptx”:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    font = slides.FontData("SimSun")

    text_portion = slides.Portion()
    text_portion.portion_format.complex_script_font = font
    text_portion.portion_format.east_asian_font = font
    text_portion.portion_format.latin_font = font

    # Defina o idioma de revisão para Chinês Simplificado.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

### **Copiar metadados de idioma**

Ao copiar texto multilíngue de um modelo, preserve tanto [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/) quanto [BasePortionFormat.alternative_language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/alternative_language_id/). O exemplo a seguir cria uma porção fonte com inglês dos EUA como idioma e francês como idioma alternativo e copia o texto e os identificadores para uma porção em uma nova apresentação.

```python
import aspose.slides as slides

source = slides.Portion("Hello! Bonjour!")
source.portion_format.language_id = "en-US"
source.portion_format.alternative_language_id = "fr-FR"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 80)
    paragraph = shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    destination = slides.Portion()
    destination.text = source.text
    destination.portion_format.language_id = source.portion_format.language_id
    # Se a origem não tem idioma alternativo, None limpa o valor de destino.
    destination.portion_format.alternative_language_id = source.portion_format.alternative_language_id
    paragraph.portions.add(destination)

    presentation.save("copied_language_metadata.pptx", slides.export.SaveFormat.PPTX)
```

Para testar uma fonte sem idioma alternativo, omita a atribuição de `"fr-FR"`. O identificador alternativo será então `None`, e a mesma instrução de cópia preserva sua ausência sem introduzir um valor padrão, mesmo que o destino já tivesse um idioma alternativo atribuído.

Esses identificadores são armazenados como metadados de idioma. Preservá‑los não define qual dicionário o PowerPoint seleciona para verificação ortográfica ou gramatical.

## **Definir idioma padrão**

Use [LoadOptions.default_text_language](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/default_text_language/) para definir o idioma padrão para texto criado ao carregar ou criar uma apresentação. O exemplo a seguir cria uma apresentação com inglês dos EUA como idioma padrão de texto, adiciona uma caixa de texto e imprime `en-US` para sua primeira porção de texto.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # Adicione uma nova forma retangular com texto.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # Verifique o idioma da primeira porção.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **Definir estilo de texto padrão**

Para aplicar formatação de texto padrão ao nível da apresentação, use [Presentation.default_text_style](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/default_text_style/).

O exemplo a seguir define uma fonte negrito de 14 pt como padrão para parágrafos de nível superior em uma nova apresentação e salva em “default_text_style.pptx”. O texto pode herdar esses padrões, a menos que formatações mais específicas os sobrescrevam.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Obtenha o formato de parágrafo de nível superior.
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **Extrair texto com o efeito tudo em maiúsculas**

No PowerPoint, aplicar o efeito de fonte **All Caps** faz o texto aparecer em maiúsculas no slide mesmo quando foi originalmente digitado em minúsculas. Quando você recupera tal porção de texto com Aspose.Slides, a biblioteca devolve o texto exatamente como foi inserido. Para corresponder ao texto exibido, verifique [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/) e converta a string retornada para maiúsculas quando o valor for `ALL`.

Este exemplo requer “sample2.pptx” com uma caixa de texto como primeira forma no primeiro slide. A primeira porção do primeiro parágrafo contém “Hello, Aspose!” com o efeito All Caps aplicado, como mostrado abaixo.

![O efeito Tudo em Maiúsculas](all_caps_effect.png)

O exemplo de código abaixo mostra como extrair o texto com o **All Caps** aplicado:

```python
import aspose.slides as slides

with slides.Presentation("sample2.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    text_portion = auto_shape.text_frame.paragraphs[0].portions[0]

    print("Original text:", text_portion.text)

    text_format = text_portion.portion_format.get_effective()
    if text_format.text_cap_type == slides.TextCapType.ALL:
        text = text_portion.text.upper()
        print("All-Caps effect:", text)
```

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Como modificar texto em uma tabela em um slide?**

Para modificar texto em uma tabela em um slide, use [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/). Itere pelas células e atualize cada célula através de [Cell.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) e a formatação de parágrafo através de [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/).

**Como aplicar cor em degradê ao texto em um slide do PowerPoint?**

Para aplicar uma cor em degradê ao texto, use [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/). Defina [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) como [FillType.GRADIENT](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) e configure as paradas do degradê, direção e transparência.

Recurso relacionado: [Formatar texto em slides](/slides/pt/features/text-formatting/).