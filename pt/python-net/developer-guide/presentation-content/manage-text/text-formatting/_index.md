---
title: Formatar Texto da Apresentação em Python
linktitle: Formatação de Texto
type: docs
weight: 50
url: /pt/python-net/text-formatting/
keywords:
- realçar texto
- expressão regular
- alinhar parágrafo
- estilo de texto
- fundo do texto
- transparência do texto
- espaçamento entre caracteres
- propriedades da fonte
- família de fontes
- rotação do texto
- ângulo de rotação
- quadro de texto
- espaçamento entre linhas
- propriedade de ajuste automático
- ancoragem do quadro de texto
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

Este artigo mostra como formatar texto em apresentações PowerPoint e OpenDocument usando Aspose.Slides para Python via .NET. Ele abrange realce, cores de fundo, transparência, espaçamento entre caracteres, propriedades de fonte, rotação, espaçamento de parágrafo, comportamento de ajuste automático, ancoragem de texto, tabulações e configurações de idioma.

Nos exemplos abaixo, usaremos um arquivo chamado "sample.pptx", que contém uma única caixa de texto no primeiro slide com o seguinte conteúdo:

![Texto de exemplo](sample_text.png)

## **Realçar texto**

Use o [TextFrame.highlight_text](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/highlight_text/) quando precisar realçar texto que corresponda a uma amostra específica dentro de um quadro de texto. O método aplica uma cor de realce aos fragmentos de texto correspondentes e pode ser usado com [TextSearchOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textsearchoptions/) para controlar como a busca é realizada, por exemplo, para corresponder apenas a palavras inteiras.

O exemplo de código abaixo realça todas as ocorrências dos caracteres **"try"** e depois realça apenas a palavra completa **"to"**.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Obter a primeira forma do primeiro slide.
    shape = presentation.slides[0].shapes[0]

    # Realçar a palavra "try" na forma.
    shape.text_frame.highlight_text("try", draw.Color.light_blue)

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True

    # Realçar a palavra "to" na forma.
    shape.text_frame.highlight_text("to", draw.Color.violet, search_options, None)

    presentation.save("highlighted_text.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![O texto realçado](highlighted_text.png)

## **Realçar texto usando expressões regulares**

O [TextFrame.highlight_regex](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/highlight_regex/) realça correspondências de texto encontradas por uma expressão regular. Em Python, essa API é exposta em [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/).

O exemplo de código abaixo realça todas as palavras que contêm **sete ou mais caracteres**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    regex = r"\b[^\s]{7,}\b"

    # Realçar todas as palavras com sete ou mais caracteres.
    shape.text_frame.highlight_regex(regex, draw.Color.yellow, None)

    presentation.save("highlighted_text_using_regex.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![O texto realçado usando expressão regular](highlighted_text_using_regex.png)

## **Definir cor de fundo do texto**

Use [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraphformat/default_portion_format/) para definir a cor de realce padrão para um parágrafo, ou use [PortionFormat.highlight_color](https://reference.aspose.com/slides/pt/python-net/aspose.slides/portionformat/highlight_color/) para porções de texto individuais.

O exemplo de código a seguir mostra como definir a cor de fundo para o **parágrafo inteiro**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Definir a cor de realce para todo o parágrafo.
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
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Definir a cor de realce para a porção de texto.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![As porções de texto cinzas](gray_text_portions.png)

## **Alinhar parágrafos de texto**

Use [ParagraphFormat.alignment](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraphformat/alignment/) para definir o alinhamento do parágrafo dentro de um quadro de texto. O valor pode ser centralizado, alinhado à esquerda, à direita, justificado etc.

O exemplo de código a seguir mostra como alinhar o parágrafo ao **centro**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Definir o alinhamento do parágrafo para o centro.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![O parágrafo alinhado](aligned_paragraph.png)

## **Definir transparência para o texto**

A transparência do texto é controlada por meio do componente alfa da cor atribuído a [PortionFormat.fill_format](https://reference.aspose.com/slides/pt/python-net/aspose.slides/portionformat/fill_format/). Nos exemplos abaixo, `alpha = 50` é um valor de canal alfa ARGB na escala 0‑255, não uma porcentagem de transparência.

O exemplo de código abaixo mostra como aplicar transparência ao **parágrafo inteiro**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Definir a cor de preenchimento do texto para cor transparente.
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
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Definir a transparência da porção de texto.
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![As porções de texto transparentes](transparent_text_portions.png)

## **Definir espaçamento entre caracteres para o texto**

Use [BasePortionFormat.spacing](https://reference.aspose.com/slides/pt/python-net/aspose.slides/baseportionformat/spacing/) para expandir ou condensar o espaçamento entre caracteres em uma caixa de texto.

O código Python a seguir mostra como expandir o espaçamento entre caracteres no **parágrafo inteiro**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
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
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Nota: Use valores negativos para comprimir o espaçamento entre caracteres.
            portion.portion_format.spacing = 3  # Expandir o espaçamento entre caracteres.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![O espaçamento entre caracteres nas porções de texto](character_spacing_in_text_portions.png)

### **Desativar kerning para fontes específicas**

Em alguns casos, o texto renderizado pelo Aspose.Slides pode parecer ligeiramente mais apertado que o mesmo texto exibido no PowerPoint. Isso pode acontecer porque o PowerPoint pode ignorar os dados de kerning para certas fontes, mesmo quando a fonte contém informações de kerning válidas e o kerning está habilitado nas configurações do PowerPoint.

Para que a saída renderizada fique mais próxima do PowerPoint nesses casos, você pode desativar o kerning para as porções de texto que utilizam a fonte afetada. Defina [PortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/pt/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) para um valor significativamente maior que o tamanho real da fonte:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    target_font = "Roboto"

    for paragraph in auto_shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            latin_font = portion.portion_format.latin_font
            east_asian_font = portion.portion_format.east_asian_font
            complex_script_font = portion.portion_format.complex_script_font

            if ((latin_font is not None and latin_font.font_name == target_font) or
                    (east_asian_font is not None and east_asian_font.font_name == target_font) or
                    (complex_script_font is not None and complex_script_font.font_name == target_font)):
                portion.portion_format.kerning_minimal_size = 100

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Essa configuração impede que o kerning seja aplicado às porções de texto correspondentes e pode ajudar a alinhar a renderização do Aspose.Slides com a saída visual do PowerPoint para fontes afetadas por esse comportamento específico do PowerPoint.

## **Gerenciar propriedades de fonte do texto**

As propriedades de fonte podem ser definidas no nível do parágrafo através de [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraphformat/default_portion_format/) ou em porções individuais através de [PortionFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/portionformat/).

O código a seguir define a fonte e o estilo de texto para o parágrafo inteiro: ele aplica tamanho de fonte, negrito, itálico, sublinhado pontilhado e a fonte Times New Roman a todas as porções do parágrafo.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Definir as propriedades da fonte para o parágrafo.
    paragraph.paragraph_format.default_portion_format.font_height = 12
    paragraph.paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE
    paragraph.paragraph_format.default_portion_format.font_italic = slides.NullableBool.TRUE
    paragraph.paragraph_format.default_portion_format.font_underline = slides.TextUnderlineType.DOTTED
    paragraph.paragraph_format.default_portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![As propriedades de fonte do parágrafo](font_properties_for_paragraph.png)

O exemplo de código abaixo aplica propriedades semelhantes a **porções de texto com fonte em negrito**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Definir as propriedades da fonte para a porção de texto.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![As propriedades de fonte das porções de texto](font_properties_for_text_portions.png)

## **Definir rotação do texto**

Use [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframeformat/text_vertical_type/) para definir uma orientação de texto predefinida dentro de uma forma.

O exemplo de código a seguir define a orientação do texto na forma como `VERTICAL270`, que gira o texto **90 graus no sentido anti‑horário**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![A rotação do texto](text_rotation.png)

## **Definir rotação personalizada para quadros de texto**

Use [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframeformat/rotation_angle/) para definir um ângulo de rotação personalizado para um [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/).

O exemplo de código abaixo gira o quadro de texto em 3 graus no sentido horário dentro da forma:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![A rotação personalizada do texto](custom_text_rotation.png)

## **Definir espaçamento entre linhas dos parágrafos**

Aspose.Slides fornece [ParagraphFormat.space_after](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraphformat/space_before/) e [ParagraphFormat.space_within](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraphformat/space_within/) para controlar o espaçamento dos parágrafos. Essas propriedades são usadas da seguinte forma:

* Use um valor positivo para especificar o espaçamento entre linhas como porcentagem da altura da linha.
* Use um valor negativo para especificar o espaçamento entre linhas em pontos.

O exemplo de código a seguir mostra como especificar o espaçamento entre linhas dentro do parágrafo:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![O espaçamento entre linhas dentro do parágrafo](line_spacing.png)

## **Definir tipo de ajuste automático para quadros de texto**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframeformat/autofit_type/) determina como o texto se comporta quando excede os limites de seu contêiner. Use‑o para controlar se o texto encolhe, transborda ou redimensiona a forma automaticamente.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

## **Definir ancoragem de quadros de texto**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframeformat/anchoring_type/) define como o texto é posicionado verticalmente dentro de uma forma, por exemplo no topo, meio ou fundo.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Definir tabulação de texto**

Use [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraphformat/default_tab_size/) e [ParagraphFormat.tabs](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraphformat/tabs/) para configurar as tabulações em um parágrafo.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.default_tab_size = 100
    paragraph.paragraph_format.tabs.add(30, slides.TabAlignment.LEFT)

    presentation.save("paragraph_tabs.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![As tabulações do parágrafo](paragraph_tabs.png)

## **Definir idioma de revisão**

Aspose.Slides fornece [PortionFormat.language_id](https://reference.aspose.com/slides/pt/python-net/aspose.slides/portionformat/language_id/), que permite definir o idioma de revisão para uma porção de texto. O idioma de revisão determina o idioma usado para verificação ortográfica e gramatical no PowerPoint.

O exemplo de código a seguir mostra como definir o idioma de revisão para uma porção de texto:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    font = slides.FontData("SimSun")

    text_portion = slides.Portion()
    text_portion.portion_format.complex_script_font = font
    text_portion.portion_format.east_asian_font = font
    text_portion.portion_format.latin_font = font

    # Definir o Id de um idioma de revisão.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1."
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Definir idioma padrão**

Use [LoadOptions.default_text_language](https://reference.aspose.com/slides/pt/python-net/aspose.slides/loadoptions/default_text_language/) para definir o idioma padrão para textos criados ao carregar ou criar uma apresentação.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # Adicionar uma nova forma retangular com texto.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # Verificar o idioma da primeira porção.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **Definir estilo de texto padrão**

Para aplicar formatação de texto padrão ao nível da apresentação, use [Presentation.default_text_style](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/default_text_style/).

O exemplo de código a seguir mostra como definir uma fonte padrão em negrito com tamanho 14 pt para todo o texto em todas as slides de uma nova apresentação.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Obter o formato de parágrafo de nível superior.
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **Extrair texto com o efeito de “todas as maiúsculas”**

No PowerPoint, aplicar o efeito de fonte **All Caps** faz com que o texto apareça em maiúsculas no slide mesmo quando foi originalmente digitado em minúsculas. Ao recuperar tal porção de texto com Aspose.Slides, a biblioteca devolve o texto exatamente como foi inserido. Para corresponder ao texto exibido, verifique [TextCapType](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textcaptype/) e converta a string retornada para maiúsculas quando o valor for `ALL`.

Suponha que temos a seguinte caixa de texto no primeiro slide do arquivo sample2.pptx.

![O efeito All Caps](all_caps_effect.png)

O exemplo de código abaixo mostra como extrair o texto com o efeito **All Caps** aplicado:

```python
import aspose.slides as slides

with slides.Presentation("sample2.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    text_portion = auto_shape.text_frame.paragraphs[0].portions[0]

    print("Original text:", text_portion.text)

    text_format = text_portion.portion_format.get_effective()
    if text_format.text_cap_type == slides.TextCapType.ALL:
        text = text_portion.text.upper()
        print("All-Caps effect:", text)
```

Saída:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Como modificar texto em uma tabela em um slide?**

Para modificar texto em uma tabela em um slide, use [Table](https://reference.aspose.com/slides/pt/python-net/aspose.slides/table/). Percorra as células e atualize cada célula através de [Cell.text_frame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/cell/text_frame/) e a formatação de parágrafo via [Paragraph.paragraph_format](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraph/paragraph_format/).

**Como aplicar cor degradê ao texto em um slide do PowerPoint?**

Para aplicar uma cor degradê ao texto, use [PortionFormat.fill_format](https://reference.aspose.com/slides/pt/python-net/aspose.slides/portionformat/fill_format/). Defina [FillFormat.fill_type](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fillformat/fill_type/) como [FillType.GRADIENT](https://reference.aspose.com/slides/pt/python-net/aspose.slides/filltype/) e configure as paradas do degradê, a direção e a transparência.