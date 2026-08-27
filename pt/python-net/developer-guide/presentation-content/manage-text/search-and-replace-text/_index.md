---
title: Pesquisar e Substituir Texto em Apresentações PowerPoint em Python
linktitle: Pesquisar e Substituir Texto
type: docs
weight: 55
url: /pt/python-net/search-and-replace-text/
keywords:
- pesquisar texto
- destacar texto
- substituir texto
- expressão regular
- quadro de texto
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Pesquise, destaque e substitua texto em apresentações PowerPoint com Aspose.Slides para Python via .NET."
---
## **Visão geral**

Aspose.Slides for Python via .NET pode pesquisar, destacar e substituir texto em um quadro de texto individual ou em toda a apresentação. Esses recursos são úteis para revisão, redação, verificação de terminologia, limpeza de modelos e outros fluxos de trabalho automatizados de processamento de documentos.

Nos primeiros exemplos abaixo, usamos um arquivo chamado "sample.pptx", que contém uma única caixa de texto no primeiro slide com o seguinte conteúdo:

![Texto de exemplo](sample_text.png)

## **Escolher o Escopo da Pesquisa**

Use métodos em [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/) para limitar uma operação a um quadro de texto. Use métodos em [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) para processar todo o texto aplicável na apresentação.

| Operação | Um quadro de texto | Apresentação inteira |
|---|---|---|
| Destacar texto literal | [TextFrame.highlight_text](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/highlight_text/) | [Presentation.highlight_text](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/highlight_text/) |
| Destacar correspondências de expressão regular | [TextFrame.highlight_regex](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/highlight_regex/) | [Presentation.highlight_regex](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/highlight_regex/) |
| Substituir texto literal | [TextFrame.replace_text](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/replace_text/) | [Presentation.replace_text](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/replace_text/) |
| Substituir correspondências de expressão regular | [TextFrame.replace_regex](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/replace_regex/) | [Presentation.replace_regex](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/replace_regex/) |

## **Configurar Correspondência de Texto**

Para operações de texto literal, use [TextSearchOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textsearchoptions/) para controlar a correspondência:

- [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textsearchoptions/whole_words_only/) limita as correspondências a palavras completas.
- [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textsearchoptions/case_sensitive/) controla se a diferenciação entre maiúsculas e minúsculas deve ser considerada.
- [TextSearchOptions.include_notes](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textsearchoptions/include_notes/) inclui as notas dos slides nas operações de pesquisa, substituição e destaque em nível de apresentação.

Operações de expressão regular usam uma cadeia de padrão, de modo que regras de correspondência como sensibilidade a maiúsculas e limites de palavra são definidas pela própria expressão.

## **Identificar o Proprietário de um Quadro de Texto**

Fluxos de trabalho genéricos de processamento de texto frequentemente recebem um [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/) enquanto pesquisam, substituem, validam ou exportam texto. Use [TextFrame.parent_shape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/parent_shape/) e [TextFrame.parent_cell](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/parent_cell/) para determinar qual objeto da apresentação possui o quadro de texto.

Os valores esperados dependem do proprietário:

| Proprietário do quadro de texto | `parent_shape` | `parent_cell` |
|---|---|---|
| Um AutoShape ou outra forma que contenha texto | A [Shape] proprietária | `None` |
| Uma célula de tabela | `None` | A [Cell] proprietária |

Ambas as propriedades são somente leitura. Ler elas não move o quadro de texto nem altera seu proprietário. O código genérico deve verificar ambos os valores para `None` e lidar com a possibilidade de que nenhum proprietário esteja disponível.

```python
import aspose.slides as slides


def get_slide_label(base_slide):
    if isinstance(base_slide, slides.Slide):
        return f"slide {base_slide.slide_number}"

    if isinstance(base_slide, slides.NotesSlide):
        return f"notes for slide {base_slide.parent_slide.slide_number}"

    return type(base_slide).__name__


with slides.Presentation("presentation.pptx") as presentation:
    text_frames = slides.util.SlideUtil.get_all_text_frames(presentation, False)

    for text_frame in text_frames:
        owner_shape = text_frame.parent_shape
        if owner_shape is not None:
            shape_name = owner_shape.name or "(unnamed)"
            shape_type = type(owner_shape).__name__
            slide_label = get_slide_label(owner_shape.slide)
            print(f"Shape: {shape_name}; type: {shape_type}; {slide_label}")
            continue

        owner_cell = text_frame.parent_cell
        if owner_cell is not None:
            slide_label = get_slide_label(owner_cell.slide)
            print(f"Table cell: column {owner_cell.first_column_index}, row {owner_cell.first_row_index}; {slide_label}")
            continue

        print("The text frame owner is not available as a shape or table cell.")
```

Para conteúdo SmartArt, percorra as formas em [SmartArtNode.shapes](https://reference.aspose.com/slides/pt/python-net/aspose.slides.smartart/smartartnode/shapes/) e acesse cada [ISmartArtShape.text_frame](https://reference.aspose.com/slides/pt/python-net/aspose.slides.smartart/ismartartshape/text_frame/). O quadro de texto pode ser rastreado até sua forma associada por meio de [TextFrame.parent_shape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/parent_shape/), enquanto [TextFrame.parent_cell](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/parent_cell/) é `None`. Portanto, o ramo de forma no exemplo também trata texto de nós SmartArt.

## **Destacar Texto**

Use o método [TextFrame.highlight_text](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/highlight_text/) para destacar correspondências de texto literal em um quadro de texto. Passe [TextSearchOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textsearchoptions/) para controlar a pesquisa.

O exemplo de código abaixo destaca todas as ocorrências dos caracteres **"try"** e depois destaca somente a palavra completa **"to"**.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    substring_search_options = slides.TextSearchOptions()
    substring_search_options.case_sensitive = False

    # Destacar cada ocorrência de "try" no quadro de texto.
    shape.text_frame.highlight_text(
        "try", draw.Color.light_blue, substring_search_options, None
    )

    whole_word_search_options = slides.TextSearchOptions()
    whole_word_search_options.whole_words_only = True
    whole_word_search_options.case_sensitive = False

    # Destacar somente a palavra completa "to".
    shape.text_frame.highlight_text(
        "to", draw.Color.violet, whole_word_search_options, None
    )

    presentation.save("highlighted_text.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![O texto destacado](highlighted_text.png)

## **Destacar Texto Usando Expressões Regulares**

O método [TextFrame.highlight_regex](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/highlight_regex/) destaca correspondências de texto encontradas por uma expressão regular em um quadro de texto.

O código a seguir destaca todas as palavras que contêm sete ou mais caracteres:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    word_pattern = r"\b[^\s]{7,}\b"

    shape.text_frame.highlight_regex(word_pattern, draw.Color.yellow, None)

    presentation.save(
        "highlighted_text_using_regex.pptx", slides.export.SaveFormat.PPTX
    )
```

O resultado:

![O texto destaque usando a expressão regular](highlighted_text_using_regex.png)

## **Destacar Texto em Toda a Apresentação**

Use [Presentation.highlight_text](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/highlight_text/) e [Presentation.highlight_regex](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/highlight_regex/) para pesquisar todos os quadros de texto aplicáveis em uma apresentação. O exemplo a seguir destaca um termo literal e todos os endereços de e‑mail:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = False

    presentation.highlight_text(
        "confidential", draw.Color.orange, search_options, None
    )

    email_pattern = r"(?i)\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}\b"
    presentation.highlight_regex(email_pattern, draw.Color.yellow)

    presentation.save(
        "highlighted_presentation.pptx", slides.export.SaveFormat.PPTX
    )
```

## **Substituir Texto em um Quadro de Texto**

Use [TextFrame.replace_text](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/replace_text/) para texto literal e [TextFrame.replace_regex](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/replace_regex/) para substituição baseada em padrão. Esses métodos atualizam o texto correspondente dentro do quadro de texto existente, preservando a formatação das partes ao redor em vez de reconstruir o quadro a partir de uma string simples.

O exemplo a seguir padroniza uma variante ortográfica e depois substitui rótulos de versão:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = False

    shape.text_frame.replace_text(
        "colour", "color", search_options, None
    )

    version_pattern = r"(?i)\bv\d+(?:\.\d+)*\b"
    shape.text_frame.replace_regex(version_pattern, "current version")

    presentation.save(
        "updated_text_frame.pptx", slides.export.SaveFormat.PPTX
    )
```

Se uma correspondência abranger partes com formatação diferente, revise a saída para confirmar qual formatação deve ser aplicada ao texto substituto.

## **Substituir Texto em Toda a Apresentação**

Use [Presentation.replace_text](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/replace_text/) e [Presentation.replace_regex](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/replace_regex/) para aplicar as mesmas operações em toda a apresentação. Isso é útil para limpeza de modelos, atualizações de terminologia e redação.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = True

    presentation.replace_text(
        "Contoso", "Example Corp", search_options, None
    )

    account_number_pattern = r"\bACCT-\d{6}\b"
    presentation.replace_regex(account_number_pattern, "ACCT-REDACTED")

    presentation.save(
        "updated_presentation.pptx", slides.export.SaveFormat.PPTX
    )
```

## **Perguntas Frequentes**

**Como posso pesquisar apenas uma caixa de texto em vez de toda a apresentação?**

Obtenha o quadro de texto da forma e chame [TextFrame.highlight_text](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/highlight_text/), [TextFrame.highlight_regex](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/highlight_regex/), [TextFrame.replace_text](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/replace_text/) ou [TextFrame.replace_regex](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/replace_regex/) nesse quadro de texto. Os métodos em nível de apresentação processam todos os quadros de texto aplicáveis.

**Como posso corresponder palavras completas com a capitalização correta?**

Defina [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textsearchoptions/whole_words_only/) e [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textsearchoptions/case_sensitive/) como `True` e passe as opções para um método de destaque ou substituição de texto literal. Para expressões regulares, defina limites de palavra e sensibilidade a maiúsculas/minúsculas diretamente no padrão.

**A pesquisa e substituição podem incluir texto nas notas dos slides?**

Sim. Defina [TextSearchOptions.include_notes](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textsearchoptions/include_notes/) como `True` ao usar uma operação literal em nível de apresentação.

**A substituição de texto preserva sua formatação?**

[TextFrame.replace_text](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/replace_text/) e [TextFrame.replace_regex](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/replace_regex/) modificam o texto correspondido dentro do quadro de texto existente e mantêm a formatação das partes ao redor. Se uma correspondência abranger trechos com formatação diferente, inspecione o resultado para garantir que a substituição use o estilo desejado.