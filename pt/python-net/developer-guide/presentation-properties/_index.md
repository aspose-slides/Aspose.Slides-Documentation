---
title: Gerenciar Propriedades da Apresentação com Python
linktitle: Propriedades da Apresentação
type: docs
weight: 70
url: /pt/python-net/presentation-properties/
keywords:
- Propriedades do PowerPoint
- propriedades da apresentação
- propriedades do documento
- propriedades integradas
- propriedades personalizadas
- propriedades avançadas
- gerenciar propriedades
- modificar propriedades
- metadados do documento
- editar metadados
- idioma de revisão
- idioma padrão
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Domine as propriedades de apresentação no Aspose.Slides for Python via .NET e otimize pesquisa, branding e fluxo de trabalho nos seus arquivos PowerPoint."
---
## **Introdução**

Aspose.Slides oferece dois tipos de propriedades de documento: **Integradas** e **Personalizadas**. Ambos os tipos de propriedades podem ser acessados e gerenciados facilmente usando a API do Aspose.Slides.

Aspose.Slides permite que você trabalhe com propriedades de documento de apresentação através da classe [DocumentProperties](https://reference.aspose.com/slides/pt/python-net/aspose.slides/documentproperties/). Uma instância dessa classe é retornada pela propriedade [Presentation.document_properties](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/document_properties/). Os exemplos a seguir mostram como ler, modificar e gerenciar essas propriedades.

{{% alert color="info" title="Nota" %}}
Por favor, note que você não pode definir valores para os campos **Application** e **Producer**, pois Aspose Ltd. e Aspose.Slides for Python via .NET x.x.x serão exibidos nesses campos.
{{% /alert %}} 

## **Gerenciar Propriedades da Apresentação**

O Microsoft PowerPoint fornece um recurso para adicionar algumas propriedades aos arquivos de apresentação. Essas propriedades de documento permitem que informações úteis sejam armazenadas junto com os documentos (arquivos de apresentação). Existem dois tipos de propriedades de documento:

- Propriedades Definidas pelo Sistema (Integradas)
- Propriedades Definidas pelo Usuário (Personalizadas)

As propriedades **Integradas** contêm informações gerais sobre o documento, como título, nome do autor, estatísticas do documento etc. As propriedades **Personalizadas** são aquelas definidas pelos usuários como pares **Nome/Valor**, onde tanto o nome quanto o valor são definidos pelo usuário. Usando Aspose.Slides for Python via .NET, os desenvolvedores podem acessar e modificar os valores das propriedades integradas assim como das propriedades personalizadas. O Microsoft PowerPoint 2007 permite gerenciar as propriedades de documento dos arquivos de apresentação. Basta clicar no ícone do Office e, em seguida, na opção **Prepare | Properties | Advanced Properties** do Microsoft PowerPoint 2007. Após selecionar **Advanced Properties**, será exibida uma caixa de diálogo que permite gerenciar as propriedades do arquivo PowerPoint. Na **Properties Dialog**, você pode ver várias guias como **General, Summary, Statistics, Contents e Custom**. Todas essas guias permitem configurar diferentes tipos de informações relacionadas aos arquivos PowerPoint. A guia **Custom** é usada para gerenciar as propriedades personalizadas dos arquivos PowerPoint.

## **Acessar Propriedades Integradas**
Essas propriedades expostas pelo objeto **IDocumentProperties** incluem: **Creator(Author)**, **Description**, **Keywords**, **Created** (Data de Criação), **Modified** (Data de Modificação), **Printed** (Data da Última Impressão), **LastModifiedBy**, **Keywords**, **SharedDoc** (É compartilhado entre diferentes produtores?), **PresentationFormat**, **Subject** e **Title**
```py
import aspose.slides as slides

# Instanciar a classe Presentation que representa a apresentação
with slides.Presentation("AccessBuiltin Properties.pptx") as pres:
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

## **Modificar Propriedades Integradas**

Modificar as propriedades integradas de arquivos de apresentação é tão simples quanto acessá‑las. Basta atribuir um valor de string a qualquer propriedade desejada e o valor será alterado. No exemplo abaixo, demonstramos como modificar as propriedades de documento integradas do arquivo de apresentação.

```py
import aspose.slides as slides

# Instanciar a classe Presentation que representa a Apresentação
with slides.Presentation("ModifyBuiltinProperties.pptx") as presentation:
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

## **Adicionar Propriedades Personalizadas à Apresentação**

Aspose.Slides for Python via .NET também permite que os desenvolvedores adicionem valores personalizados às propriedades de documento da apresentação. O exemplo a seguir mostra como definir propriedades personalizadas para uma apresentação.

```py
import aspose.slides as slides

# Instanciar a classe Presentation
with slides.Presentation() as presentation:
    # Obter propriedades do documento
    documentProperties = presentation.document_properties

    # Adicionar propriedades personalizadas
    documentProperties.set_custom_property_value("New Custom", 12)
    documentProperties.set_custom_property_value("My Nam", "Mudassir")
    documentProperties.set_custom_property_value("Custom", 124)

    # Obter o nome da propriedade em um índice específico
    getPropertyName = documentProperties.get_custom_property_name(2)

    # Remover a propriedade selecionada
    documentProperties.remove_custom_property(getPropertyName)

    # Salvar a apresentação
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Acessar e Modificar Propriedades Personalizadas**

Aspose.Slides for Python via .NET também permite que os desenvolvedores acessem os valores das propriedades personalizadas. O exemplo a seguir mostra como você pode acessar e modificar todas essas propriedades personalizadas de uma apresentação.

```py
import aspose.slides as slides

# Instanciar a classe Presentation que representa o PPTX
with slides.Presentation("AccessModifyingProperties.pptx") as presentation:
    # Criar uma referência ao objeto document_properties associado à Presentation
    documentProperties = presentation.document_properties

    # Acessar e modificar propriedades personalizadas
    for i in range(documentProperties.count_of_custom_properties):
        property_name = documentProperties.get_custom_property_name(i)

        # Exibir nomes e valores das propriedades personalizadas
        property_value = [""]
        documentProperties.get_custom_property_value(property_name, property_value)
        print("Custom Property Name : " + property_name)
        print("Custom Property Value : " + property_value[0])

        # Modificar valores das propriedades personalizadas
        documentProperties.set_custom_property_value(property_name, "New Value " + str(i + 1))
    # salvar sua apresentação em um arquivo
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

`get_custom_property_value` retorna o valor através da lista de um elemento passada como segundo argumento, e o valor armazenado é convertido para o tipo do elemento já presente nessa lista. O exemplo acima usa `[""]`, portanto lê propriedades de string; para ler uma propriedade armazenada como número, passe um marcador numérico como `[0]` — caso contrário a chamada gera uma `InvalidCastException`.

## **Definir Idioma de Revisão**

Aspose.Slides fornece a propriedade `Language_Id` (exposta pela classe [PortionFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/portionformat/)) para que você possa definir o idioma de revisão de um documento PowerPoint. O idioma de revisão é o idioma para o qual a ortografia e a gramática do PowerPoint são verificadas.

Este código Python mostra como definir o idioma de revisão para um PowerPoint:

```python
import aspose.slides as slides

with slides.Presentation("SetProofingLanguage.pptx") as pres:
    auto_shape = pres.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    new_portion = slides.Portion()
    font = slides.FontData("SimSun")
    portion_format = new_portion.portion_format
    portion_format.complex_script_font = font
    portion_format.east_asian_font = font
    portion_format.latin_font = font

    # defina o Id de um idioma de revisão
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

## **Exemplo Interativo**

Experimente o aplicativo online [**Metadados do Aspose.Slides**](https://products.aspose.app/slides/pt/metadata) para ver como trabalhar com propriedades de documento via API do Aspose.Slides:

[![Visualizar & Editar Metadados do PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/pt/metadata)

## **Perguntas Frequentes**

**Como remover uma propriedade integrada de uma apresentação?**

As propriedades integradas fazem parte integrante da apresentação e não podem ser removidas totalmente. Porém, você pode alterar seus valores ou defini‑las como vazias, se a propriedade específica permitir.

**O que acontece se eu adicionar uma propriedade personalizada que já existe?**

Se você adicionar uma propriedade personalizada que já existe, o valor existente será sobrescrito pelo novo. Não é necessário remover ou verificar a propriedade previamente, pois o Aspose.Slides atualiza automaticamente o valor da propriedade.

**Posso acessar as propriedades da apresentação sem carregar completamente a apresentação?**

Sim. Use [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentationfactory/get_presentation_info/) e depois [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentationinfo/read_document_properties/) para ler os metadados de documento armazenados sem criar uma instância de [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/). Consulte [Build a Lightweight Presentation Inventory](/slides/pt/python-net/examine-presentation/) para um exemplo completo de relatório e limitações específicas de formatos.