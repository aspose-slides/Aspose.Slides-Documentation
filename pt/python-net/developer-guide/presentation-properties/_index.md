---
title: Gerenciar propriedades de apresentação com Python
linktitle: Propriedades da Apresentação
type: docs
weight: 70
url: /pt/python-net/presentation-properties/
keywords:
- Propriedades do PowerPoint
- Propriedades de apresentação
- Propriedades de documento
- Propriedades integradas
- Propriedades personalizadas
- Propriedades avançadas
- Gerenciar propriedades
- Modificar propriedades
- Metadados de documento
- Editar metadados
- Idioma de revisão
- Idioma padrão
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Domine as propriedades de apresentação no Aspose.Slides for Python via .NET e otimize a pesquisa, a identidade visual e o fluxo de trabalho em seus arquivos PowerPoint."
---
## **Introdução**

Aspose.Slides oferece suporte a dois tipos de propriedades de documento: **Built-in** e **Custom**. Ambos os tipos de propriedade podem ser acessados e gerenciados facilmente usando a API do Aspose.Slides.

Aspose.Slides permite que você trabalhe com propriedades de documento de apresentações através da classe [DocumentProperties](https://reference.aspose.com/slides/pt/python-net/aspose.slides/documentproperties/). Uma instância desta classe é retornada pela propriedade [Presentation.document_properties](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/document_properties/). Os exemplos a seguir mostram como ler, modificar e gerenciar essas propriedades.

{{% alert color="primary" %}} 
Observe que você não pode definir valores nos campos **Application** e **Producer**, pois Aspose Ltd. e Aspose.Slides for Python via .NET x.x.x serão exibidos nesses campos.
{{% /alert %}} 

## **Gerenciar Propriedades da Apresentação**

O Microsoft PowerPoint fornece um recurso para adicionar algumas propriedades aos arquivos de apresentação. Essas propriedades de documento permitem que informações úteis sejam armazenadas junto com os documentos (arquivos de apresentação). Existem dois tipos de propriedades de documento, conforme segue

- Propriedades Definidas pelo Sistema (Built-in)
- Propriedades Definidas pelo Usuário (Custom)

**Built-in** properties contêm informações gerais sobre o documento, como título do documento, nome do autor, estatísticas do documento etc. As propriedades **Custom** são aquelas definidas pelos usuários como pares **Name/Value**, onde tanto o nome quanto o valor são definidos pelo usuário. Usando Aspose.Slides for Python via .NET, os desenvolvedores podem acessar e modificar os valores das propriedades built-in e também as propriedades custom. O Microsoft PowerPoint 2007 permite gerenciar as propriedades de documento dos arquivos de apresentação. Tudo o que você precisa fazer é clicar no ícone do Office e, em seguida, no item de menu **Prepare | Properties | Advanced Properties** do Microsoft PowerPoint 2007. Depois de selecionar o item de menu **Advanced Properties**, aparecerá uma caixa de diálogo que permite gerenciar as propriedades de documento do arquivo PowerPoint. Na **Properties Dialog**, você pode ver que há várias abas, como **General, Summary, Statistics, Contents and Custom**. Todas essas abas permitem configurar diferentes tipos de informações relacionadas aos arquivos PowerPoint. A aba **Custom** é usada para gerenciar as propriedades custom dos arquivos PowerPoint.

## **Acessar Propriedades Built-in**

Essas propriedades expostas pelo objeto **IDocumentProperties** incluem: **Creator(Author)**, **Description**, **Keywords**, **Created** (Data de Criação), **Modified** (Data de Modificação), **Printed** (Data da Última Impressão), **LastModifiedBy**, **Keywords**, **SharedDoc** (Está compartilhado entre diferentes produtores?), **PresentationFormat**, **Subject** e **Title**
```py
import aspose.slides as slides

# Instanciar a classe Presentation que representa a apresentação
with slides.Presentation(path + "AccessBuiltin Properties.pptx") as pres:
    # Criar uma referência ao objeto associado à Presentation
    documentProperties = pres.document_properties

    # Exibir as propriedades integradas
    print("category : " + documentProperties.category)
    print("Current Status : " + documentProperties.content_status)
    print("Creation Date : " + str(documentProperties.created_time))
    print("Author : " + documentProperties.author)
    print("Description : " + documentProperties.comments)
    print("KeyWords : " + documentProperties.keywords)
    print("Last Modified By : " + documentProperties.last_saved_by)
    print("Supervisor : " + documentProperties.manager)
    print("Modified Date : " + str(documentProperties.last_saved_time))
    print("Presentation Format : " + documentProperties.presentation_format)
    print("Last Print Date : " + str(documentProperties.last_printed))
    print("Is Shared between producers : " + str(documentProperties.shared_doc))
    print("Subject : " + documentProperties.subject)
    print("Title : " + documentProperties.title)
```

## **Modificar Propriedades Built-in**

Modificar as propriedades built-in dos arquivos de apresentação é tão fácil quanto acessá‑las. Você pode simplesmente atribuir um valor de string a qualquer propriedade desejada e o valor da propriedade será modificado. No exemplo abaixo, demonstramos como podemos modificar as propriedades de documento built-in do arquivo de apresentação.
```py
import aspose.slides as slides

# Instanciar a classe Presentation que representa a Presentation
with slides.Presentation(path + "ModifyBuiltinProperties.pptx") as presentation:
    # Criar uma referência ao objeto associado à Presentation
    documentProperties = presentation.document_properties

    # Definir as propriedades integradas
    documentProperties.author = "Aspose.Slides for .NET"
    documentProperties.title = "Modifying Presentation Properties"
    documentProperties.subject = "Aspose Subject"
    documentProperties.comments = "Aspose Description"
    documentProperties.manager = "Aspose Manager"

    # salvar sua apresentação em um arquivo
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Adicionar Propriedades Custom à Apresentação**

Aspose.Slides for Python via .NET também permite que os desenvolvedores adicionem valores custom às propriedades de documento da apresentação. Um exemplo é apresentado abaixo, mostrando como definir as propriedades custom para uma apresentação.
```py
import aspose.slides as slides

# Instanciar a classe Presentation
with slides.Presentation() as presentation:
    # Obtendo as Propriedades do Documento
    documentProperties = presentation.document_properties

    # Adicionando propriedades Personalizadas
    documentProperties.set_custom_property_value("New Custom", 12)
    documentProperties.set_custom_property_value("My Nam", "Mudassir")
    documentProperties.set_custom_property_value("Custom", 124)

    # Obtendo o nome da propriedade em um índice específico
    getPropertyName = documentProperties.get_custom_property_name(2)

    # Removendo a propriedade selecionada
    documentProperties.remove_custom_property(getPropertyName)

    # Salvando a apresentação
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Acessar e Modificar Propriedades Custom**

Aspose.Slides for Python via .NET também permite que os desenvolvedores acessem os valores das propriedades custom. Um exemplo é apresentado abaixo, mostrando como você pode acessar e modificar todas essas propriedades custom para uma apresentação.
```py
import aspose.slides as slides

# Instanciar a classe Presentation que representa o PPTX
with slides.Presentation(path + "AccessModifyingProperties.pptx") as presentation:
    # Criar uma referência ao objeto document_properties associado à Presentation
    documentProperties = presentation.document_properties

    # Acessar e modificar propriedades personalizadas
    for i in range(documentProperties.count_of_custom_properties):
        # Exibir nomes e valores das propriedades personalizadas
        print("Custom Property Name : " + documentProperties.get_custom_property_name(i))
        print("Custom Property Value : " + documentProperties.get_custom_property_value[documentProperties.get_custom_property_name(i)])

        # Modificar valores das propriedades personalizadas
        documentProperties.set_custom_property_value(documentProperties.get_custom_property_name(i), "New Value " + str(i + 1))
    # salvar sua apresentação em um arquivo
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Definir Idioma de Revisão**

Aspose.Slides fornece a propriedade `Language_Id` (exposta pela classe [PortionFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/portionformat/)) para permitir que você defina o idioma de revisão para um documento PowerPoint. O idioma de revisão é o idioma para o qual a ortografia e a gramática no PowerPoint são verificadas.

Este código Python mostra como definir o idioma de revisão para um PowerPoint:
```python
import aspose.slides as slides

with slides.Presentation(path + "SetProofingLanguage.pptx") as pres:
    auto_shape = pres.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    new_portion = slides.Portion()
    font = slides.FontData("SimSun")
    portion_format = new_portion.portion_format
    portion_format.complex_script_font = font
    portion_format.east_asian_font = font
    portion_format.latin_font = font

    # definir o Id de um idioma de revisão
    portion_format.language_id = "zh-CN"
    new_portion.text = "1。"

    paragraph.portions.add(new_portion)
```

## **Definir Idioma Padrão**

Este código Python mostra como definir o idioma padrão para toda a apresentação PowerPoint:
```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en_US"

with slides.Presentation(load_options) as pres:
    shp = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 150)
    text_frame = shp.text_frame
    text_frame.text = "New Text"

    print(text_frame.paragraphs[0].portions[0].portion_format.language_id)
```

## **Exemplo ao Vivo**

Experimente o aplicativo online [**Aspose.Slides Metadata**](https://products.aspose.app/slides/pt/metadata) para ver como trabalhar com propriedades de documento via API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/pt/metadata)

## **FAQ**

**Como posso remover uma propriedade built-in de uma apresentação?**

As propriedades built-in são parte integrante da apresentação e não podem ser removidas completamente. No entanto, você pode mudar seus valores ou defini‑‑las como vazias, se a propriedade específica permitir.

**O que acontece se eu adicionar uma propriedade custom que já existe?**

Se você adicionar uma propriedade custom que já existe, seu valor existente será sobrescrito pelo novo. Não é necessário remover ou verificar a propriedade antes, pois o Aspose.Slides atualiza automaticamente o valor da propriedade.

**Posso acessar as propriedades da apresentação sem carregar a apresentação completamente?**

Sim, você pode acessar as propriedades da apresentação sem carregá‑la completamente usando o método [get_presentation_info](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentationfactory/get_presentation_info/) da classe [PresentationFactory](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentationfactory/). Em seguida, utilize o método [read_document_properties](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentationinfo/read_document_properties/) fornecido pela classe [PresentationInfo](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentationinfo/) para ler as propriedades de forma eficiente, economizando memória e melhorando o desempenho.