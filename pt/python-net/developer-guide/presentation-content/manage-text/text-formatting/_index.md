---
title: Formatar texto de apresentação em Python
linktitle: Formatação de texto
type: docs
weight: 50
url: /pt/python-net/text-formatting/
keywords:
- alinhar parágrafo
- estilo de texto
- fundo de texto
- transparência de texto
- espaçamento entre caracteres
- propriedades de fonte
- família de fonte
- rotação de texto
- ângulo de rotação
- quadro de texto
- espaçamento entre linhas
- propriedade de ajuste automático
- âncora de quadro de texto
- tabulação de texto
- idioma padrão
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Formate e estilize texto em apresentações PowerPoint e OpenDocument usando Aspose.Slides para Python via .NET. Personalize fontes, cores, alinhamento e muito mais."
---
## **Visão geral**

Este artigo mostra como formatar texto em apresentações PowerPoint e OpenDocument usando Aspose.Slides para Python via .NET. Ele abrange cores de fundo, transparência, espaçamento entre caracteres, propriedades de fonte, rotação, espaçamento de parágrafos, comportamento de ajuste automático, ancoragem de texto, tabulações e configurações de idioma.

A menos que indicado de outra forma, os exemplos usam [sample.pptx](sample.pptx). A primeira forma no seu primeiro slide é uma caixa de texto, e seu primeiro parágrafo contém o texto mostrado abaixo. Tanto os índices de slides quanto de formas são baseados em zero. Exemplos que selecionam trechos em negrito utilizam formatação efetiva, incluindo formatação de negrito herdada:

![Texto de exemplo](sample_text.png)

Para encontrar e destacar texto literal ou correspondências de expressão regular, veja [Search and Replace Text](/slides/pt/python-net/search-and-replace-text/).

## **Definir cor de fundo do texto**

Use [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraphformat/default_portion_format/) para definir a cor de destaque padrão de um parágrafo, ou use [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/pt/python-net/aspose.slides/baseportionformat/highlight_color/) para porções de texto individuais.

O exemplo a seguir define um destaque cinza‑claro como padrão para o primeiro parágrafo. Cores de destaque explícitas em porções individuais têm precedência sobre esse padrão:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Defina a cor de destaque para todo o parágrafo.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![O parágrafo cinza](gray_paragraph.png)

O exemplo de código abaixo demonstra como definir a cor de fundo para **trechos de texto com fonte em negrito**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Defina a cor de destaque para a porção de texto.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![Os trechos de texto cinza](gray_text_portions.png)

## **Alinhar parágrafos de texto**

Use [ParagraphFormat.alignment](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraphformat/alignment/) para definir o alinhamento de parágrafo dentro de um quadro de texto. O valor pode ser centrado, alinhado à esquerda, à direita, justificado etc.

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

## **Definir transparência para texto**

A transparência do texto é controlada através do componente alfa da cor atribuída a [BasePortionFormat.fill_format](https://reference.aspose.com/slides/pt/python-net/aspose.slides/baseportionformat/fill_format/). Nos exemplos abaixo, `alpha = 50` é um valor de canal alfa ARGB na escala 0–255, não uma porcentagem de transparência.

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

O exemplo de código a seguir mostra como aplicar transparência a **trechos de texto com fonte em negrito**:

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

![Os trechos de texto transparentes](transparent_text_portions.png)

## **Definir espaçamento entre caracteres para texto**

Use [BasePortionFormat.spacing](https://reference.aspose.com/slides/pt/python-net/aspose.slides/baseportionformat/spacing/) para expandir ou condensar o espaçamento entre caracteres em uma caixa de texto. Os exemplos adicionam 3 pontos de espaçamento; valores negativos condensam o texto.

O código Python a seguir mostra como expandir o espaçamento entre caracteres no **parágrafo inteiro**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Observação: Use valores negativos para comprimir o espaçamento entre caracteres.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # Expanda o espaçamento entre caracteres.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![O espaçamento entre caracteres no parágrafo](character_spacing_in_paragraph.png)

O exemplo de código abaixo mostra como expandir o espaçamento entre caracteres em **trechos de texto com fonte em negrito**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Observação: Use valores negativos para comprimir o espaçamento entre caracteres.
            portion.portion_format.spacing = 3  # Expanda o espaçamento entre caracteres.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![O espaçamento entre caracteres nos trechos de texto](character_spacing_in_text_portions.png)

### **Desativar kerning para fontes específicas**

Em alguns casos, o texto renderizado pelo Aspose.Slides pode parecer ligeiramente mais apertado que o mesmo texto exibido no PowerPoint. Isso pode acontecer porque o PowerPoint pode ignorar dados de kerning para determinadas fontes, mesmo quando a fonte contém informações válidas de kerning e o kerning está habilitado nas configurações do PowerPoint.

Para aproximar a saída renderizada do PowerPoint nesses casos, você pode desativar o kerning para trechos de texto que utilizam a fonte afetada. Defina [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/pt/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) para um valor maior que o tamanho real da fonte. Este exemplo requer "presentation.pptx" com uma caixa de texto como primeira forma no primeiro slide. Ele verifica nomes de fontes efetivas, incluindo fontes herdadas, e define um limite de 100 pontos para trechos que usam Roboto. Isso desativa o kerning para trechos correspondentes com tamanho de fonte abaixo de 100 pontos:

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

Para texto correspondente abaixo do limite, essa configuração impede o kerning e pode ajudar a alinhar a renderização do Aspose.Slides ao resultado visual do PowerPoint para fontes afetadas por esse comportamento específico do PowerPoint.

## **Gerenciar propriedades de fonte do texto**

As propriedades de fonte podem ser definidas ao nível de parágrafo através de [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraphformat/default_portion_format/) ou em porções individuais através de [PortionFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/portionformat/).

O exemplo a seguir define a fonte padrão do primeiro parágrafo como Times New Roman 12 pt com negrito, itálico e sublinhado pontilhado. Formatação explícita em porções individuais tem precedência sobre esses padrões:

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

O exemplo a seguir aplica Times New Roman 13 pt, formatação itálica e sublinhado pontilhado a porções cuja formatação efetiva é negrito:

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

![As propriedades de fonte dos trechos de texto](font_properties_for_text_portions.png)

## **Definir rotação do texto**

Use [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframeformat/text_vertical_type/) para definir uma orientação de texto predefinida dentro de uma forma.

O exemplo de código a seguir define a orientação do texto na forma como [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textverticaltype/), que gira o texto **90 graus no sentido anti‑horário**:

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

Use [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframeformat/rotation_angle/) para definir um ângulo de rotação personalizado para um [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/).

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

## **Definir espaçamento entre linhas de parágrafos**

Aspose.Slides fornece [ParagraphFormat.space_after](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraphformat/space_before/) e [ParagraphFormat.space_within](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraphformat/space_within/) para controlar o espaçamento de parágrafos. Essas propriedades são usadas da seguinte forma:

* Use um valor positivo para especificar o espaçamento como porcentagem da altura da linha.
* Use um valor negativo para especificar o espaçamento em pontos.

O exemplo a seguir define o espaçamento interno do primeiro parágrafo em 200 % da altura da linha (espaçamento duplo):

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

As regras de quebra de linha de parágrafos são úteis em blocos de texto estreitos e apresentações que mesclam texto latino e de Leste Asiático. As propriedades a seguir pertencem a [ParagraphFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraphformat/), portanto aplicam‑se a um parágrafo inteiro:

- [latin_line_break](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraphformat/latin_line_break/) controla as regras de quebra de linha latinas. Em texto misto, alterá‑la também pode mudar onde o texto e a pontuação do Leste Asiático adjacentes são envoltos.
- [east_asian_line_break](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraphformat/east_asian_line_break/) controla as regras de quebra de linha do Leste Asiático, incluindo restrições de caracteres no início e no fim de uma linha.

Essas regras não substituem [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframeformat/wrap_text/), que habilita a quebra automática dentro de um quadro de texto. Elas influenciam o layout quando a quebra ocorre; não inserem caracteres de quebra de linha. Uma quebra de linha explícita força uma nova linha dentro do parágrafo independentemente da largura disponível.

O exemplo autocontido a seguir cria um bloco de texto estreito contendo chinês e texto latino. Define ambas as propriedades de quebra de linha explicitamente e salva "line_breaking.pptx". Para experimentar cada regra, altere o valor dessa propriedade mantendo as outras configurações fixas. O exemplo usa Arial 24 pt e SimSun com largura de quadro de 160 pt e margens horizontais do quadro de texto zeradas. [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframeformat/autofit_type/) está definido como [TextAutofitType.NONE](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textautofittype/) para que o tamanho do texto e as dimensões do quadro permaneçam fixos.

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

[ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraphformat/hanging_punctuation/) permite que pontuação elegível se estenda além da borda direita da linha de texto em vez de ocupar a linha seguinte. Aplica‑se a todo o parágrafo e difere de uma indentação suspensa.

O exemplo autocontido a seguir habilita pontuação suspensa em um quadro de texto de 100 pt de largura e salva "hanging_punctuation.pptx". Com Arial 24 pt e margens horizontais do quadro zeradas, o ponto final final permanece após "sentence" e se estende além da borda direita do texto. Defina a propriedade como [NullableBool.FALSE](https://reference.aspose.com/slides/pt/python-net/aspose.slides/nullablebool/) para comparar: com essas configurações, o ponto final ocupa uma linha separada. A quebra automática está habilitada e o ajuste automático está desativado para manter a largura disponível fixa.

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

Nem toda marca de pontuação pode ser suspensa. O resultado visível depende da fonte e das condições de layout: alterar a fonte, a largura disponível, as margens ou as configurações de ajuste automático pode remover a diferença visível.

## **Definir tipo de ajuste automático para quadros de texto**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframeformat/autofit_type/) determina como o texto se comporta quando excede os limites de seu contêiner. Use‑o para controlar se o texto encolhe, transborda ou redimensiona a forma automaticamente. O exemplo a seguir configura a forma para redimensionar de modo a caber seu texto e salva o resultado em "autofit_type.pptx".

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

Para contar linhas após a quebra automática e ver como a largura do texto ou da forma altera o resultado, veja [Count Rendered Lines](/slides/pt/python-net/manage-paragraph/). A contagem de linhas por si só não indica se o texto transborda seu contêiner.

## **Definir âncora de quadros de texto**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframeformat/anchoring_type/) define como o texto é posicionado verticalmente dentro de uma forma, por exemplo, no topo, meio ou base. O exemplo a seguir ancora o texto na base da primeira forma e salva o resultado em "text_anchor.pptx".

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Definir tabulação de texto**

Use [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraphformat/default_tab_size/) e [ParagraphFormat.tabs](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraphformat/tabs/) para configurar tabulações em um parágrafo. O exemplo a seguir define o intervalo padrão de tabulação como 100 pontos e adiciona uma tabulação à esquerda em 30 pontos. Essas configurações afetam texto que contém caracteres de tabulação.

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

![As tabu­lações do parágrafo](paragraph_tabs.png)

## **Definir idioma de revisão**

Aspose.Slides fornece [BasePortionFormat.language_id](https://reference.aspose.com/slides/pt/python-net/aspose.slides/baseportionformat/language_id/), que permite definir o idioma de revisão para uma porção de texto. O idioma de revisão determina o idioma usado para verificação ortográfica e gramatical no PowerPoint.

O exemplo a seguir requer "presentation.pptx" com uma caixa de texto como primeira forma no primeiro slide e pelo menos um parágrafo. Ele substitui o conteúdo do primeiro parágrafo por "1。", define SimSun como sua fonte e atribui o idioma de revisão Chinês Simplificado (`zh-CN`). Salva o resultado em "proofing_language.pptx":

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

## **Definir idioma padrão**

Use [LoadOptions.default_text_language](https://reference.aspose.com/slides/pt/python-net/aspose.slides/loadoptions/default_text_language/) para definir o idioma padrão para texto criado ao carregar ou criar uma apresentação. O exemplo a seguir cria uma apresentação com inglês dos EUA como idioma padrão de texto, adiciona uma caixa de texto e imprime `en-US` para sua primeira porção de texto.

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

Para aplicar formatação de texto padrão ao nível da apresentação, use [Presentation.default_text_style](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/default_text_style/).

O exemplo a seguir define uma fonte em negrito de 14 pontos como padrão para parágrafos de nível superior em uma nova apresentação e salva em "default_text_style.pptx". O texto pode herdar esses padrões, a menos que formatações mais específicas os sobrescrevam.

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

## **Extrair texto com efeito de todas as letras maiúsculas**

No PowerPoint, aplicar o efeito de fonte **All Caps** faz com que o texto apareça em maiúsculas no slide mesmo quando foi digitado originalmente em minúsculas. Ao recuperar tal porção de texto com Aspose.Slides, a biblioteca devolve o texto exatamente como foi inserido. Para corresponder ao texto exibido, verifique [TextCapType](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textcaptype/) e converta a string retornada para maiúsculas quando o valor for `ALL`.

Este exemplo requer "sample2.pptx" com uma caixa de texto como primeira forma no primeiro slide. Sua primeira porção do primeiro parágrafo contém "Hello, Aspose!" com o efeito All Caps aplicado, como mostrado abaixo.

![O efeito All Caps](all_caps_effect.png)

O exemplo de código abaixo mostra como extrair o texto com o efeito **All Caps** aplicado:

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

Saída:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Como modifico texto em uma tabela em um slide?**

Para modificar texto em uma tabela em um slide, use [Table](https://reference.aspose.com/slides/pt/python-net/aspose.slides/table/). Percorra as células e atualize cada célula através de [Cell.text_frame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/cell/text_frame/) e formatação de parágrafo via [Paragraph.paragraph_format](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraph/paragraph_format/).

**Como aplico uma cor gradiente ao texto em um slide do PowerPoint?**

Para aplicar uma cor gradiente ao texto, use [BasePortionFormat.fill_format](https://reference.aspose.com/slides/pt/python-net/aspose.slides/baseportionformat/fill_format/). Defina [FillFormat.fill_type](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fillformat/fill_type/) como [FillType.GRADIENT](https://reference.aspose.com/slides/pt/python-net/aspose.slides/filltype/) e configure as paradas de gradiente, direção e transparência.