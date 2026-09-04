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
- propriedades embutidas
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
description: "Domine as propriedades de apresentação no Aspose.Slides for Python via .NET e otimize a pesquisa, branding e fluxo de trabalho em seus arquivos PowerPoint."
---
## **Introdução**

Aspose.Slides oferece dois tipos de propriedades de documento: **Built-in** e **Custom**. Ambos os tipos de propriedade podem ser acessados e gerenciados facilmente usando a API Aspose.Slides.

Aspose.Slides permite trabalhar com propriedades de documento de apresentação através da classe [DocumentProperties](https://reference.aspose.com/slides/pt/python-net/aspose.slides/documentproperties/). Uma instância desta classe é retornada pela propriedade [Presentation.document_properties](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/document_properties/). Os exemplos a seguir mostram como ler, modificar e gerenciar essas propriedades.

{{% alert color="info" title="Nota" %}}
Por favor, note que não é possível definir valores nos campos **Application** e **Producer**, pois Aspose Ltd. e Aspose.Slides for Python via .NET x.x.x serão exibidos nesses campos.
{{% /alert %}}

## **Gerenciar Propriedades da Apresentação**

O Microsoft PowerPoint oferece um recurso para adicionar algumas propriedades aos arquivos de apresentação. Essas propriedades de documento permitem que informações úteis sejam armazenadas junto com os documentos (arquivos de apresentação). Existem dois tipos de propriedades de documento:

- Propriedades Definidas pelo Sistema (Built-in)
- Propriedades Definidas pelo Usuário (Custom)

As propriedades **Built-in** contêm informações gerais sobre o documento, como título do documento, nome do autor, estatísticas do documento etc. As propriedades **Custom** são aquelas definidas pelos usuários como pares **Nome/Valor**, onde tanto o nome quanto o valor são definidos pelo usuário. Usando Aspose.Slides for Python via .NET, os desenvolvedores podem acessar e modificar os valores das propriedades built-in assim como das propriedades custom. O Microsoft PowerPoint 2007 permite gerenciar as propriedades de documento dos arquivos de apresentação. Basta clicar no ícone do Office e, em seguida, no item de menu **Prepare | Properties | Advanced Properties** do Microsoft PowerPoint 2007. Após selecionar **Advanced Properties**, um diálogo será exibido permitindo gerenciar as propriedades de documento do arquivo PowerPoint. Na **Properties Dialog**, você pode ver várias abas como **General, Summary, Statistics, Contents e Custom**. Todas essas abas permitem configurar diferentes tipos de informação relacionadas aos arquivos PowerPoint. A aba **Custom** é usada para gerenciar as propriedades custom dos arquivos PowerPoint.

## **Ler Propriedades Públicas de uma Apresentação Criptografada**

Uma senha de abertura normalmente protege tanto o conteúdo da apresentação quanto as propriedades do documento. Quando uma apresentação é criptografada com [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/pt/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) definido como `False`, suas propriedades de documento permanecem públicas. Uma aplicação pode então definir [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/pt/python-net/aspose.slides/loadoptions/only_load_document_properties/) como `True` e ler os metadados públicos sem fornecer a senha de abertura.

`only_load_document_properties` controla o que Aspose.Slides carrega; não descriptografa nada. Se as propriedades estiverem incluídas na criptografia, carregá‑las sem a senha falha. Se a apresentação não estiver criptografada, a opção é ignorada e a apresentação completa é carregada.

O exemplo a seguir verifica o modo de carregamento por meio de [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/pt/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) e, então, lê as propriedades built‑in através de [Presentation.document_properties](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/document_properties/):

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("public-properties-encrypted.pptx", load_options) as presentation:
    if presentation.protection_manager.is_only_document_properties_loaded:
        properties = presentation.document_properties

        print("Author: " + properties.author)
        print("Title: " + properties.title)
        print("Keywords: " + properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

Nesse modo, o conteúdo dos slides não é carregado. Slides, masters, layouts, shapes, mídia e outros objetos da apresentação ficam indisponíveis. As aplicações devem sempre verificar `is_only_document_properties_loaded` antes de executar uma operação que exija o modelo completo de objetos da apresentação.

{{% alert color="warning" title="Segurança" %}}
Metadados públicos podem expor nomes de autores, títulos, assuntos, palavras‑chave, informações da empresa, comentários e valores custom. Criptografe propriedades sensíveis juntamente com a apresentação. Deixe‑as públicas apenas quando sistemas de indexação, classificação, busca ou gerenciamento de documentos tiverem um requisito específico para acessá‑las sem senha.
{{% /alert %}}

## **Atualizar Propriedades de uma Apresentação Criptografada**

Para um arquivo PPTX criptografado, uma apresentação carregada com `only_load_document_properties` destina‑se à leitura de metadados públicos. Aspose.Slides não pode salvar propriedades alteradas desse objeto somente‑metadados porque as propriedades públicas devem permanecer consistentes com os dados correspondentes dentro da apresentação criptografada. Atualizá‑las, portanto, requer a senha de abertura correta e um carregamento completo.

O exemplo a seguir abre a apresentação com [LoadOptions.password](https://reference.aspose.com/slides/pt/python-net/aspose.slides/loadoptions/password/), atualiza as propriedades built‑in públicas e salva o resultado. Em seguida, usa [PresentationInfo.is_encrypted](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentationinfo/is_encrypted/) para verificar que a criptografia foi preservada e reabre os metadados públicos sem senha para validar os novos valores:

```python
import aspose.slides as slides

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation(input_path, load_options) as presentation:
    presentation.document_properties.title = "Updated Product Roadmap"
    presentation.document_properties.keywords = "roadmap, planning, indexed"
    presentation.save(output_path, slides.export.SaveFormat.PPTX)

presentation_info = slides.PresentationFactory.instance.get_presentation_info(output_path)
print("The presentation is encrypted: " + str(presentation_info.is_encrypted))

metadata_load_options = slides.LoadOptions()
metadata_load_options.only_load_document_properties = True

with slides.Presentation(output_path, metadata_load_options) as metadata_presentation:
    if metadata_presentation.protection_manager.is_only_document_properties_loaded:
        print("Title: " + metadata_presentation.document_properties.title)
        print("Keywords: " + metadata_presentation.document_properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

Se uma aplicação não tem permissão para descriptografar ou carregar o conteúdo da apresentação, ela deve tratar as propriedades públicas de um arquivo PPTX criptografado como somente‑leitura.

## **Acessar Propriedades Built‑in**
Essas propriedades expostas pelo objeto **IDocumentProperties** incluem: **Creator(Author)**, **Description**, **Keywords**, **Created** (Data de Criação), **Modified** (Data de Modificação), **Printed** (Data da Última Impressão), **LastModifiedBy**, **SharedDoc** (É compartilhado entre diferentes produtores?), **PresentationFormat**, **Subject** e **Title**
```py
import aspose.slides as slides

# Instanciar a classe Presentation que representa a apresentação
with slides.Presentation("AccessBuiltin Properties.pptx") as pres:
    # Criar uma referência ao objeto associado ao Presentation
    documentProperties = pres.document_properties

    # Exibir as propriedades incorporadas
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

## **Modificar Propriedades Built‑in**

Modificar as propriedades built‑in de arquivos de apresentação é tão simples quanto acessá‑las. Basta atribuir um valor string a qualquer propriedade desejada e o valor será alterado. No exemplo abaixo, demonstramos como modificar as propriedades built‑in do documento da apresentação.

```py
import aspose.slides as slides

# Instanciar a classe Presentation que representa a Apresentação
with slides.Presentation("ModifyBuiltinProperties.pptx") as presentation:
    # Criar uma referência ao objeto associado ao Presentation
    documentProperties = presentation.document_properties

    # Definir as propriedades incorporadas
    documentProperties.author = "Aspose.Slides for .NET"
    documentProperties.title = "Modifying Presentation Properties"
    documentProperties.subject = "Aspose Subject"
    documentProperties.comments = "Aspose Description"
    documentProperties.manager = "Aspose Manager"

    # salvar sua apresentação em um arquivo
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Adicionar Propriedades Custom à Apresentação**

Aspose.Slides for Python via .NET também permite que desenvolvedores adicionem valores custom às propriedades de documento da apresentação. O exemplo abaixo mostra como definir propriedades custom para uma apresentação.

```py
import aspose.slides as slides

# Instanciar a classe Presentation
with slides.Presentation() as presentation:
    # Obtendo Propriedades do Documento
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

Aspose.Slides for Python via .NET também permite que desenvolvedores acessem os valores de propriedades custom. O exemplo abaixo mostra como acessar e modificar todas essas propriedades custom para uma apresentação.

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

`get_custom_property_value` devolve o valor por meio da lista de um elemento passada como segundo argumento, e o valor armazenado é convertido para o tipo do elemento já presente nessa lista. O exemplo acima usa `[""]`, portanto lê propriedades string; para ler uma propriedade armazenada como número, passe um placeholder numérico como `[0]` — caso contrário a chamada gera uma `InvalidCastException`.

## **Definir Idioma de Revisão**

Aspose.Slides fornece a propriedade `Language_Id` (exposta pela classe [PortionFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/portionformat/)) para permitir que você defina o idioma de revisão de um documento PowerPoint. O idioma de revisão é o idioma para o qual a ortografia e a gramática no PowerPoint são verificadas.

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

## **Exemplo Interativo**

Experimente o aplicativo online [**Metadados do Aspose.Slides**](https://products.aspose.app/slides/pt/metadata) para ver como trabalhar com propriedades de documento via API Aspose.Slides:

[![Visualizar e Editar Metadados do PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/pt/metadata)

## **Perguntas Frequentes**

**Como posso remover uma propriedade built‑in de uma apresentação?**

Propriedades built‑in são parte integrante da apresentação e não podem ser removidas completamente. No entanto, você pode alterar seus valores ou defini‑las como vazias, se a propriedade específica permitir.

**O que acontece se eu adicionar uma propriedade custom que já existe?**

Se você adicionar uma propriedade custom que já existe, seu valor atual será sobrescrito pelo novo. Não é necessário remover ou verificar a propriedade antes, pois Aspose.Slides atualiza automaticamente o valor da propriedade.

**Posso acessar propriedades da apresentação sem carregar a apresentação completa?**

Sim. Use [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentationfactory/get_presentation_info/) e então [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentationinfo/read_document_properties/) para ler os metadados armazenados do documento sem criar uma instância [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/). Consulte [Build a Lightweight Presentation Inventory](/slides/pt/python-net/examine-presentation/) para um exemplo completo de relatório e limitações específicas por formato.

**Posso ler propriedades públicas de uma apresentação criptografada sem sua senha de abertura?**

Sim. A apresentação deve ter sido criptografada com `encrypt_document_properties` definido como `False` e deve ser carregada com `only_load_document_properties` definido como `True`.

**Posso atualizar um arquivo PPTX criptografado no modo somente‑propriedades‑de‑documento?**

Não. Dados de propriedades públicas e criptografadas devem permanecer consistentes, portanto atualizar um arquivo PPTX criptografado exige o carregamento completo da apresentação com a senha de abertura correta.