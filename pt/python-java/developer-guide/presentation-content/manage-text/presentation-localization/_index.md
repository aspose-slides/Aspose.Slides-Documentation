---
title: Automatizar a Localização de Apresentações em Python via Java
linktitle: Localização de Apresentação
type: docs
weight: 100
url: /pt/python-java/presentation-localization/
keywords:
- alterar idioma
- verificação ortográfica
- suprimir verificação ortográfica
- idioma de revisão
- id do idioma
- texto multilíngue
- PowerPoint
- apresentação
- Python
- Java
- Aspose.Slides
description: "Defina idiomas de revisão para texto de apresentações PowerPoint e OpenDocument em Python via Java com Aspose.Slides, incluindo padrões e parágrafos multilíngues."
---
## **Visão Geral**

O Aspose.Slides para Python via Java permite que você configure metadados de revisão para trechos individuais de texto. Use [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseportionformat/#setLanguageId) para identificar o idioma de revisão, [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseportionformat/#setSpellCheck) para permitir ou suprimir a verificação ortográfica e [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseportionformat/#setProofDisabled) para controlar o estado mais amplo de não‑revisão. Como essas configurações são aplicadas ao nível do trecho, um parágrafo pode conter vários idiomas e diferentes regras de revisão.

Este artigo explica como atribuir um idioma a um texto específico, definir o idioma padrão para novo texto com [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage), criar parágrafos multilíngues, escolher entre [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseportionformat/#setSpellCheck) e [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseportionformat/#setProofDisabled) e preservar as configurações desejadas ao usar [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting). Essas propriedades armazenam metadados para aplicativos de apresentação; não traduzem texto, nem realizam verificação ortográfica baseada em dicionário, ou retornam palavras incorretas.

## **Definir o Idioma de Revisão para Texto**

Crie ou carregue uma [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/), acesse o trecho de texto necessário através de [Portion.getPortionFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/portion/#getPortionFormat) e atribua seu identificador de idioma. O exemplo a seguir cria uma forma, define o inglês britânico como idioma de revisão e salva o resultado com [Presentation.save](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#save):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80)
    shape.getTextFrame().setText("Set the proofing language for this text.")

    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().setLanguageId("en-GB")

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Definir o Idioma Padrão para Novo Texto**

Use [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) para especificar o idioma de revisão que o Aspose.Slides atribui ao texto recém‑criado. Essa configuração é útil quando a maior parte ou todo o novo texto em uma apresentação usa o mesmo idioma. Ela não altera os metadados de idioma de textos que já possuam um idioma explícito.

O exemplo a seguir cria uma apresentação cujo novo texto utiliza as regras de revisão em alemão:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("de-DE")

presentation = Presentation(load_options)
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80)
    shape.getTextFrame().setText("Willkommen zur Präsentation")

    presentation.save("default_text_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Usar Vários Idiomas em Um Parágrafo**

Um [Paragraph](https://reference.aspose.com/slides/pt/python-java/aspose.slides/paragraph/) contém uma coleção de trechos de texto. Crie um [Portion](https://reference.aspose.com/slides/pt/python-java/aspose.slides/portion/) separado para cada idioma e defina seu [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseportionformat/#setLanguageId) de forma independente.

Este exemplo cria um parágrafo com trechos em inglês e francês:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80)
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    english_portion = Portion("Welcome")
    english_portion.getPortionFormat().setLanguageId("en-US")
    paragraph.getPortions().add(english_portion)

    french_portion = Portion(" — Bienvenue")
    french_portion.getPortionFormat().setLanguageId("fr-FR")
    paragraph.getPortions().add(french_portion)

    presentation.save("multilingual_text.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ativar ou Suprimir a Verificação Ortográfica para Trechos Individuais**

[PortionFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/portionformat/) herda as propriedades de texto comuns definidas por [BasePortionFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseportionformat/). Acesse o formato de um trecho através de [Portion.getPortionFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/portion/#getPortionFormat) e use [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseportionformat/#setSpellCheck) para controlar se um aplicativo de apresentação pode verificar a ortografia desse trecho. O valor padrão é `False`: `True` permite a verificação ortográfica, enquanto `False` a suprime.

A configuração se aplica a trechos individuais de texto. Diferentes trechos no mesmo parágrafo podem, portanto, usar valores diferentes. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseportionformat/#setLanguageId) e [setSpellCheck](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseportionformat/#setSpellCheck) têm propósitos complementares: [setLanguageId](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseportionformat/#setLanguageId) identifica o idioma de revisão, enquanto [setSpellCheck](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseportionformat/#setSpellCheck) determina se a verificação ortográfica é permitida para o trecho.

[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseportionformat/#setProofDisabled) também controla a revisão, mas representa o estado mais amplo de “não revisar” como um [NullableBool](https://reference.aspose.com/slides/pt/python-java/aspose.slides/nullablebool/). Use [setSpellCheck](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseportionformat/#setSpellCheck) quando precisar de um interruptor booleano direto especificamente para verificações ortográficas. Use [setProofDisabled](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseportionformat/#setProofDisabled) quando precisar preservar ou controlar explicitamente os metadados de não‑revisão da apresentação, inclusive seu estado [NullableBool.NotDefined](https://reference.aspose.com/slides/pt/python-java/aspose.slides/nullablebool/#NotDefined). Se definir ambas as propriedades, mantenha seus valores consistentes; não combine [setSpellCheck](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseportionformat/#setSpellCheck) definido como `True` com [setProofDisabled](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseportionformat/#setProofDisabled) definido como o estado [NullableBool.True](https://reference.aspose.com/slides/pt/python-java/aspose.slides/nullablebool/#True).

Essas propriedades configuram metadados de revisão usados pelo PowerPoint e outros aplicativos de apresentação. O Aspose.Slides não os utiliza para executar verificações ortográficas baseadas em dicionário ou para retornar uma lista de palavras incorretas.

O exemplo completo a seguir cria uma apresentação de entrada, a carrega, atribui diferentes configurações de verificação ortográfica e idiomas de revisão a dois trechos no mesmo parágrafo, salva o resultado, reabre‑o e verifica os valores armazenados:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

input_file = "spell_check_input.pptx"
output_file = "spell_check_settings.pptx"

source_presentation = Presentation()
try:
    source_slide = source_presentation.getSlides().get_Item(0)
    source_shape = source_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80)
    source_paragraph = source_shape.getTextFrame().getParagraphs().get_Item(0)
    source_paragraph.getPortions().clear()

    source_english_portion = Portion("Check this text. ")
    source_english_portion.getPortionFormat().setLanguageId("en-US")
    source_paragraph.getPortions().add(source_english_portion)

    source_french_portion = Portion("Ignorer ce code : ZX-81.")
    source_french_portion.getPortionFormat().setLanguageId("fr-FR")
    source_paragraph.getPortions().add(source_french_portion)

    source_presentation.save(input_file, SaveFormat.Pptx)
finally:
    source_presentation.dispose()

presentation = Presentation(input_file)
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions()

    checked_portion = portions.get_Item(0)
    checked_portion.getPortionFormat().setLanguageId("en-US")
    checked_portion.getPortionFormat().setSpellCheck(True)

    suppressed_portion = portions.get_Item(1)
    suppressed_portion.getPortionFormat().setLanguageId("fr-FR")
    suppressed_portion.getPortionFormat().setSpellCheck(False)

    presentation.save(output_file, SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation(output_file)
try:
    reopened_shape = reopened_presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    stored_portions = reopened_shape.getTextFrame().getParagraphs().get_Item(0).getPortions()

    first_portion_stored = stored_portions.getCount() == 2 and stored_portions.get_Item(0).getPortionFormat().getLanguageId() == "en-US" and stored_portions.get_Item(0).getPortionFormat().getSpellCheck()

    second_portion_stored = stored_portions.getCount() == 2 and stored_portions.get_Item(1).getPortionFormat().getLanguageId() == "fr-FR" and not stored_portions.get_Item(1).getPortionFormat().getSpellCheck()

    if first_portion_stored and second_portion_stored:
        print("The proofing settings were stored correctly.")
    else:
        print("The proofing settings could not be verified.")

finally:
    reopened_presentation.dispose()
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) combina trechos adjacentes que possuem o mesmo formato. Uma diferença em [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseportionformat/#setSpellCheck) sozinha não mantém esses trechos separados; após a junção, o trecho resultante retém o valor de [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseportionformat/#setSpellCheck) do primeiro trecho. Se os trechos precisarem de configurações de verificação ortográfica diferentes, chame [joinPortionsWithSameFormatting](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) antes de atribuir essas configurações, ou inspecione os limites do trecho resultante e reaplique as configurações posteriormente. Trechos com valores diferentes de [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseportionformat/#setLanguageId) permanecem separados porque a formatação de idioma de revisão difere.

## **FAQ**

**O ID do idioma traduz o texto?**

Não. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseportionformat/#setLanguageId) armazena metadados de revisão para ortografia e gramática; não altera o conteúdo do texto. Traduza o texto separadamente e, em seguida, defina o identificador de idioma apropriado para cada trecho traduzido.

**O idioma de revisão controla fontes, hifenização ou quebra de linha?**

Não. O identificador de idioma serve apenas para revisão. A renderização e o layout do texto dependem principalmente das [fonts](/slides/pt/python-java/powerpoint-fonts/), do sistema de escrita e das configurações da caixa de texto. Para renderização confiável, forneça as fontes necessárias, configure a [font substitution](/slides/pt/python-java/font-substitution/) ou [embed fonts](/slides/pt/python-java/embedded-font/) na apresentação.

**Um parágrafo pode usar vários idiomas de revisão?**

Sim. Atribua cada idioma a um trecho separado, como demonstrado no exemplo de parágrafo multilíngue.

**Devo usar [setDefaultTextLanguage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) ou [setLanguageId](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseportionformat/#setLanguageId)?**

Use [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) quando quiser um padrão para textos recém‑criados. Use [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseportionformat/#setLanguageId) quando um trecho específico precisar de um idioma de revisão explícito ou quando um parágrafo contiver vários idiomas.