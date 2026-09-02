---
title: "Automatizar a localização de apresentações com Python"
linktitle: "Localização de Apresentação"
type: docs
weight: 100
url: /pt/python-net/presentation-localization/
keywords:
  - "alterar idioma"
  - "verificação ortográfica"
  - "suprimir verificação ortográfica"
  - "idioma de revisão"
  - "id do idioma"
  - "texto multilíngue"
  - "PowerPoint"
  - "apresentação"
  - "Python"
  - "Aspose.Slides"
description: "Defina idiomas de revisão para texto de apresentações PowerPoint e OpenDocument em Python com Aspose.Slides, incluindo padrões e parágrafos multilíngues."
---
## **Visão geral**

Aspose.Slides for Python via .NET permite que você configure metadados de revisão para porções individuais de texto. Use [BasePortionFormat.language_id](https://reference.aspose.com/slides/pt/python-net/aspose.slides/baseportionformat/language_id/) para identificar o idioma de revisão, [BasePortionFormat.spell_check](https://reference.aspose.com/slides/pt/python-net/aspose.slides/baseportionformat/spell_check/) para permitir ou suprimir verificações ortográficas e [BasePortionFormat.proof_disabled](https://reference.aspose.com/slides/pt/python-net/aspose.slides/baseportionformat/proof_disabled/) para controlar o estado geral de “não revisar”. Como essas definições são aplicadas ao nível da porção, um parágrafo pode conter vários idiomas e diferentes regras de revisão.

Este artigo explica como atribuir um idioma a um texto específico, definir o idioma padrão para novo texto com [LoadOptions.default_text_language](https://reference.aspose.com/slides/pt/python-net/aspose.slides/loadoptions/default_text_language/), criar parágrafos multilíngues, escolher entre `spell_check` e `proof_disabled` e preservar as configurações pretendidas ao usar [Presentation.join_portions_with_same_formatting](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/join_portions_with_same_formatting/). Essas propriedades armazenam metadados para aplicativos de apresentação; elas não traduzem texto, não realizam verificação ortográfica baseada em dicionário nem retornam palavras incorretas.

## **Definir o idioma de revisão para o texto**

Crie ou carregue uma [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/), acesse a porção de texto necessária através de [Portion.portion_format](https://reference.aspose.com/slides/pt/python-net/aspose.slides/portion/portion_format/), e atribua seu identificador de idioma. O exemplo a seguir cria uma forma, define o Inglês Britânico como idioma de revisão e salva o resultado com [Presentation.save](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/save/):

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 320, 80)
    shape.text_frame.text = "Set the proofing language for this text."

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.language_id = "en-GB"

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Definir o idioma padrão para novo texto**

Use [LoadOptions.default_text_language](https://reference.aspose.com/slides/pt/python-net/aspose.slides/loadoptions/default_text_language/) para especificar o idioma de revisão que Aspose.Slides atribui ao texto recém‑criado. Essa configuração é útil quando a maior parte ou todo o novo texto em uma apresentação usa o mesmo idioma. Ela não altera os metadados de idioma do texto que já possui um idioma explícito.

O exemplo a seguir cria uma apresentação cujo novo texto usa regras de revisão em Alemão:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "de-DE"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 320, 80)
    shape.text_frame.text = "Willkommen zur Präsentung"

    presentation.save("default_text_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Usar vários idiomas em um parágrafo**

Um [Paragraph](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraph/) contém uma coleção de porções de texto. Crie uma [Portion](https://reference.aspose.com/slides/pt/python-net/aspose.slides/portion/) separada para cada idioma e defina seu `language_id` independentemente.

Este exemplo cria um parágrafo com porções em Inglês e Francês:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 80)
    paragraph = shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    english_portion = slides.Portion("Welcome")
    english_portion.portion_format.language_id = "en-US"
    paragraph.portions.add(english_portion)

    french_portion = slides.Portion(" — Bienvenue")
    french_portion.portion_format.language_id = "fr-FR"
    paragraph.portions.add(french_portion)

    presentation.save("multilingual_text.pptx", slides.export.SaveFormat.PPTX)
```

## **Habilitar ou suprimir a verificação ortográfica para porções individuais**

[PortionFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/portionformat/) herda as propriedades de texto comuns definidas por [BasePortionFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/baseportionformat/). Acesse o formato de uma porção através de [Portion.portion_format](https://reference.aspose.com/slides/pt/python-net/aspose.slides/portion/portion_format/) e defina [BasePortionFormat.spell_check](https://reference.aspose.com/slides/pt/python-net/aspose.slides/baseportionformat/spell_check/) para controlar se um aplicativo de apresentação pode verificar a ortografia daquela porção. O valor padrão é `False`: `True` permite a verificação ortográfica, enquanto `False` a suprime.

A configuração se aplica a porções individuais de texto. Porções diferentes no mesmo parágrafo podem, portanto, usar valores distintos. [BasePortionFormat.language_id](https://reference.aspose.com/slides/pt/python-net/aspose.slides/baseportionformat/language_id/) e `spell_check` atendem a propósitos complementares: `language_id` identifica o idioma de revisão, enquanto `spell_check` determina se as verificações ortográficas são permitidas para a porção.

[BasePortionFormat.proof_disabled](https://reference.aspose.com/slides/pt/python-net/aspose.slides/baseportionformat/proof_disabled/) também controla a revisão, mas representa o estado mais amplo de “não revisar” como um [NullableBool](https://reference.aspose.com/slides/pt/python-net/aspose.slides/nullablebool/). Use `spell_check` quando precisar de um interruptor booleano direto especificamente para verificações ortográficas. Use `proof_disabled` quando precisar preservar ou controlar explicitamente os metadados de “não revisar” da apresentação, incluindo seu estado `NOT_DEFINED`. Se você definir ambas as propriedades, mantenha seus valores consistentes; não combine `spell_check = True` com `proof_disabled = slides.NullableBool.TRUE`.

Essas propriedades configuram metadados de revisão usados pelo PowerPoint e outros aplicativos de apresentação. Aspose.Slides não os utiliza para executar verificação ortográfica baseada em dicionário ou para devolver uma lista de palavras incorretas.

O exemplo completo a seguir cria uma apresentação de entrada, a carrega, atribui diferentes configurações de verificação ortográfica e idiomas de revisão a duas porções no mesmo parágrafo, salva o resultado, reabre‑o e verifica os valores armazenados:

```python
import aspose.slides as slides

input_file = "spell_check_input.pptx"
output_file = "spell_check_settings.pptx"

with slides.Presentation() as source_presentation:
    source_slide = source_presentation.slides[0]
    source_shape = source_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 80)
    source_paragraph = source_shape.text_frame.paragraphs[0]
    source_paragraph.portions.clear()

    source_english_portion = slides.Portion("Check this text. ")
    source_english_portion.portion_format.language_id = "en-US"
    source_paragraph.portions.add(source_english_portion)

    source_french_portion = slides.Portion("Ignorer ce code : ZX-81.")
    source_french_portion.portion_format.language_id = "fr-FR"
    source_paragraph.portions.add(source_french_portion)

    source_presentation.save(input_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(input_file) as presentation:
    shape = presentation.slides[0].shapes[0]
    portions = shape.text_frame.paragraphs[0].portions

    checked_portion = portions[0]
    checked_portion.portion_format.language_id = "en-US"
    checked_portion.portion_format.spell_check = True

    suppressed_portion = portions[1]
    suppressed_portion.portion_format.language_id = "fr-FR"
    suppressed_portion.portion_format.spell_check = False

    presentation.save(output_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(output_file) as reopened_presentation:
    reopened_shape = reopened_presentation.slides[0].shapes[0]
    stored_portions = reopened_shape.text_frame.paragraphs[0].portions

    has_two_portions = stored_portions.count == 2

    first_portion_stored = (
        has_two_portions 
        and stored_portions[0].portion_format.language_id == "en-US" 
        and stored_portions[0].portion_format.spell_check
    )

    second_portion_stored = (
        has_two_portions
        and stored_portions[1].portion_format.language_id == "fr-FR" 
        and not stored_portions[1].portion_format.spell_check
    )

    if first_portion_stored and second_portion_stored:
        print("The proofing settings were stored correctly.")
    else:
        print("The proofing settings could not be verified.")
```

[Presentation.join_portions_with_same_formatting](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/join_portions_with_same_formatting/) combina porções adjacentes que têm a mesma formatação. Uma diferença apenas em `spell_check` não mantém essas porções separadas; após a junção, a porção resultante retém o valor `spell_check` da primeira porção. Se as porções precisarem de configurações de verificação ortográfica diferentes, chame `join_portions_with_same_formatting` antes de atribuir essas configurações, ou inspecione os limites da porção resultante e reaplique as configurações depois. Porções com valores diferentes de `language_id` permanecem separadas porque a formatação do idioma de revisão difere.

## **Perguntas frequentes**

**O ID de idioma traduz o texto?**

Não. [BasePortionFormat.language_id](https://reference.aspose.com/slides/pt/python-net/aspose.slides/baseportionformat/language_id/) armazena metadados de revisão para ortografia e gramática; ele não altera o conteúdo do texto. Traduza o texto separadamente e, em seguida, defina o identificador de idioma adequado para cada porção traduzida.

**O idioma de revisão controla fontes, hifenização ou quebra de linha?**

Não. O identificador de idioma serve apenas para revisão. A renderização e o layout do texto dependem principalmente das [fonts](/slides/pt/python-net/powerpoint-fonts/) disponíveis, do sistema de escrita e das configurações da caixa de texto. Para uma renderização confiável, forneça as fontes necessárias, configure a [substituição de fontes](/slides/pt/python-net/font-substitution/) ou [incorpore fontes](/slides/pt/python-net/embedded-font/) na apresentação.

**Um parágrafo pode usar vários idiomas de revisão?**

Sim. Atribua cada idioma a uma porção separada, como mostra o exemplo de parágrafo multilíngue.

**Devo usar `default_text_language` ou `language_id`?**

Use [LoadOptions.default_text_language](https://reference.aspose.com/slides/pt/python-net/aspose.slides/loadoptions/default_text_language/) quando quiser um padrão para textos recém‑criados. Use [BasePortionFormat.language_id](https://reference.aspose.com/slides/pt/python-net/aspose.slides/baseportionformat/language_id/) quando uma porção específica precisar de um idioma de revisão explícito ou quando um parágrafo contiver múltiplos idiomas.