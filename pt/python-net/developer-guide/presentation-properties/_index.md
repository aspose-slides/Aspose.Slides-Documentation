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
description: "Domine as propriedades de apresentação no Aspose.Slides for Python via .NET e simplifique a pesquisa, a marcação e o fluxo de trabalho em seus arquivos PowerPoint."
---
## **Introdução**

Aspose.Slides for Python via .NET suporta **integradas** e **personalizadas** propriedades de documento. Use estas propriedades para ler e atualizar os metadados da apresentação, como autor, título e valores definidos pelo usuário.

Aspose.Slides permite trabalhar com propriedades de documento de apresentação através da classe [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/). Uma instância desta classe é retornada por [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/). Os exemplos a seguir mostram como ler, modificar e gerenciar essas propriedades.

{{% alert color="info" title="Note" %}}
Aspose.Slides gerencia os metadados de aplicação e produtor ao salvar apresentações; esses campos identificam o software que criou a saída.
{{% /alert %}}

## **Gerenciar Propriedades da Apresentação**

As propriedades de documento armazenam informações descritivas ao lado do conteúdo da apresentação. Elas se dividem em duas categorias:

- **Propriedades integradas** contêm metadados padrão, como título, autor e estatísticas do documento.
- **Propriedades personalizadas** armazenam pares nome/valor definidos pelo usuário.

Aspose.Slides for Python via .NET fornece acesso a ambas as categorias. No PowerPoint, selecione **File → Info → Properties → Advanced Properties** para inspecionar os metadados do documento. A caixa de diálogo agrupa as informações em abas como **Summary**, **Statistics**, **Contents** e **Custom**. Use a aba **Custom** para gerenciar propriedades definidas pelo usuário.

## **Ler Propriedades Públicas de uma Apresentação Criptografada**

Uma senha de abertura normalmente protege tanto o conteúdo da apresentação quanto as propriedades do documento. Quando uma apresentação é criptografada com [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) definido como `False`, suas propriedades de documento permanecem públicas. Uma aplicação pode então definir [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) como `True` e ler os metadados públicos sem fornecer a senha de abertura.

[LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) controla o que o Aspose.Slides carrega; ele não descriptografa nada. Se as propriedades foram incluídas na criptografia, carregá‑las sem a senha falha. Se a apresentação não estiver criptografada, a opção é ignorada e a apresentação completa é carregada.

O exemplo requer uma apresentação criptografada cujas propriedades de documento foram deixadas públicas. Ele verifica o modo de carregamento através de [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) e então lê propriedades integradas através de [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/):

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("public-properties-encrypted.pptx", load_options) as presentation:
    if presentation.protection_manager.is_only_document_properties_loaded:
        document_properties = presentation.document_properties

        print("Author: " + document_properties.author)
        print("Title: " + document_properties.title)
        print("Keywords: " + document_properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

Neste modo, o conteúdo dos slides não é carregado. Slides, mestres, layouts, formas, mídia e outros objetos da apresentação ficam indisponíveis. As aplicações devem sempre verificar [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) antes de executar uma operação que exija o modelo de objeto completo da apresentação.

{{% alert color="warning" title="Security" %}}
Metadados públicos podem expor nomes de autores, títulos, assuntos, palavras‑chave, informações da empresa, comentários e valores personalizados. Criptografe propriedades sensíveis junto com a apresentação. Deixe‑as públicas somente quando sistemas de indexação, classificação, busca ou gestão de documentos tenham um requisito específico para acessá‑las sem senha.
{{% /alert %}}

## **Atualizar Propriedades de uma Apresentação Criptografada**

Para um arquivo PPTX criptografado, uma apresentação carregada com [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) destina‑se à leitura de metadados públicos. Aspose.Slides não pode salvar propriedades alteradas desse objeto somente‑metadados porque as propriedades públicas devem permanecer consistentes com os dados correspondentes dentro da apresentação criptografada. Atualizá‑las, portanto, requer a senha de abertura correta e um carregamento completo.

O exemplo requer uma apresentação PPTX criptografada com propriedades de documento públicas e uma senha de abertura conhecida. Ele abre a apresentação completa com [LoadOptions.password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/), atualiza propriedades integradas públicas e salva o resultado. Em seguida, usa [PresentationInfo.is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/is_encrypted/) para verificar que a criptografia foi preservada e reabre os metadados públicos sem senha para verificar os novos valores:

```python
import aspose.slides as slides

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation(input_path, load_options) as presentation:
    document_properties = presentation.document_properties
    document_properties.title = "Updated Product Roadmap"
    document_properties.keywords = "roadmap, planning, indexed"
    
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

Se uma aplicação não estiver autorizada a descriptografar ou carregar o conteúdo da apresentação, ela deve tratar as propriedades públicas de um arquivo PPTX criptografado como somente leitura.

## **Acessar Propriedades Integradas**

A classe [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) expõe metadados integrados por meio de propriedades tipadas, incluindo [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/), [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/) e [DocumentProperties.created_time](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/created_time/). Este exemplo abre uma apresentação existente e imprime seus metadados armazenados no console. Os valores dependem da apresentação de entrada; alguns campos podem estar vazios.

```python
import aspose.slides as slides

with slides.Presentation("AccessBuiltInProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    print("Category:", document_properties.category)
    print("Content status:", document_properties.content_status)
    print("Creation date:", document_properties.created_time)
    print("Author:", document_properties.author)
    print("Comments:", document_properties.comments)
    print("Keywords:", document_properties.keywords)
    print("Last modified by:", document_properties.last_saved_by)
    print("Manager:", document_properties.manager)
    print("Modified date:", document_properties.last_saved_time)
    print("Presentation format:", document_properties.presentation_format)
    print("Last print date:", document_properties.last_printed)
    print("Is shared between producers:", document_properties.shared_doc)
    print("Subject:", document_properties.subject)
    print("Title:", document_properties.title)
```

## **Modificar Propriedades Integradas**

Para atualizar metadados integrados, atribua valores às propriedades graváveis expostas por [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/). Este exemplo abre uma apresentação existente, define [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/), [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/), [DocumentProperties.subject](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/subject/), [DocumentProperties.comments](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/comments/) e [DocumentProperties.manager](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/manager/), então salva a apresentação atualizada com [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). O PPTX salvo contém os novos metadados.

```python
import aspose.slides as slides

with slides.Presentation("ModifyBuiltInProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    document_properties.author = "Aspose.Slides for Python via .NET"
    document_properties.title = "Manage PowerPoint Presentation Properties"
    document_properties.subject = "Modify Built-in Properties"
    document_properties.comments = "Aspose description"
    document_properties.manager = "Aspose manager"

    presentation.save("DocumentProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

## **Gerenciar a Base de Hyperlink**

[DocumentProperties.hyperlink_base](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/hyperlink_base/) armazena a base ao nível do documento para hyperlinks relativos. Isso é útil ao mover uma apresentação e seus arquivos vinculados para outra localização. É separada do [Hyperlink.external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/) de um hyperlink individual: alterar a base não reescreve os endereços de link armazenados nem muda destinos absolutos.

O exemplo requer uma apresentação contendo tanto um link relativo, como `target.html`, quanto um link absoluto para um arquivo ou site. Ele lê a base existente, atribui um novo endereço de base e salva e reabre a apresentação para verificar o valor. Em seguida, limpa a base com `""` e verifica o valor vazio em um arquivo salvo separado. Substitua o endereço base de exemplo pela localização dos seus arquivos vinculados.

```python
import aspose.slides as slides

with slides.Presentation("hyperlinks.pptx") as presentation:
    print("Original base:", presentation.document_properties.hyperlink_base)

    new_base = "https://example.com/new/"
    presentation.document_properties.hyperlink_base = new_base
    presentation.save("hyperlinks-updated.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlinks-updated.pptx") as updated_presentation:
    print("Base preserved:", updated_presentation.document_properties.hyperlink_base == new_base)

    updated_presentation.document_properties.hyperlink_base = ""
    updated_presentation.save("hyperlinks-cleared.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlinks-cleared.pptx") as cleared_presentation:
    print("Base cleared:", cleared_presentation.document_properties.hyperlink_base == "")
```

As duas mensagens de verificação devem imprimir `True`. Limpar a base deixa os endereços individuais dos hyperlinks intactos.

Um link relativo para `target.pptx` abriu `old/target.pptx` quando a base apontava para a pasta `old`. Depois de mudar a base para a pasta `new`, salvar e reabrir a apresentação, o mesmo link abriu `new/target.pptx`. Um link absoluto continuou a abrir o mesmo arquivo. Teste seus links relativos no PowerPoint antes e depois de mover a apresentação ou mudar sua base.

## **Adicionar Propriedades Personalizadas à Apresentação**

Propriedades personalizadas armazenam metadados que não têm um campo integrado correspondente. O método [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/) permite atribuir um valor pelo nome da propriedade. Este exemplo cria uma apresentação, adiciona dois valores de texto e um valor inteiro de versão, e salva a apresentação com [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). Atribuir um valor a um nome existente substitui o valor daquela propriedade.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    document_properties = presentation.document_properties

    document_properties.set_custom_property_value("Reviewed by", "John Smith")
    document_properties.set_custom_property_value("Confidentiality level", "Internal")
    document_properties.set_custom_property_value("Document version", 2)

    presentation.save("CustomDocumentProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

## **Acessar e Modificar Propriedades Personalizadas**

Este exemplo abre uma apresentação contendo propriedades personalizadas e usa [DocumentProperties.count_of_custom_properties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/count_of_custom_properties/) para iterar sobre elas. [DocumentProperties.get_custom_property_name](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_name/) aceita um índice baseado em zero e retorna o nome usado por [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/). O exemplo requer uma apresentação cujas propriedades personalizadas sejam todas strings. Ele imprime cada nome e valor originais, substitui cada valor por uma string numerada e salva as alterações. Se não houver propriedades personalizadas, o loop não faz alterações.

```python
import aspose.slides as slides

with slides.Presentation("AccessAndModifyProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    for i in range(document_properties.count_of_custom_properties):
        property_name = document_properties.get_custom_property_name(i)
        property_value = [""]
        document_properties.get_custom_property_value(property_name, property_value)

        print("Custom property name:", property_name)
        print("Custom property value:", property_value[0])

        document_properties.set_custom_property_value(property_name, "New Value " + str(i + 1))

    presentation.save("CustomProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

[DocumentProperties.get_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_value/) devolve o valor através da lista de um elemento passada como segundo argumento. O placeholder deve corresponder ao tipo da propriedade armazenada: use `[""]` para uma string ou `[0]` para um inteiro. Um tipo incompatível gera uma `InvalidCastException`; escolha o placeholder de acordo com o esquema da sua propriedade personalizada.

## **Exemplo ao Vivo**

Experimente o aplicativo online [**Visualizar e Editar Metadados do PowerPoint**](https://products.aspose.app/slides/metadata) para ver como trabalhar com propriedades de documento usando a API do Aspose.Slides:

[![Visualizar e Editar Metadados do PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **Perguntas Frequentes**

**Como posso remover uma propriedade integrada de uma apresentação?**

Propriedades integradas são parte integrante da apresentação e não podem ser removidas completamente. Contudo, você pode alterar seus valores ou defini‑las como vazias, se a propriedade específica permitir.

**O que acontece se eu adicionar uma propriedade personalizada que já existe?**

Se você adicionar uma propriedade personalizada que já existe, o valor existente será sobrescrito pelo novo. Não é necessário remover ou verificar a propriedade antes, pois o Aspose.Slides atualiza automaticamente o valor da propriedade.

**Posso acessar propriedades da apresentação sem carregar totalmente a apresentação?**

Sim. Use [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/get_presentation_info/) e então [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) para ler os metadados do documento armazenados sem criar uma instância de [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). Veja [Construa um Inventário de Apresentação Leve](/slides/pt/python-net/examine-presentation/) para um exemplo completo de relatório e limitações específicas de formato.

**Posso ler propriedades públicas de uma apresentação criptografada sem sua senha de abertura?**

Sim. A apresentação deve ter sido criptografada com [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) definido como `False`, e deve ser carregada com [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) definido como `True`.

**Posso atualizar um arquivo PPTX criptografado no modo apenas‑propriedades‑do‑documento?**

Não. Dados de propriedades públicas e criptografadas devem permanecer consistentes, portanto, atualizar um arquivo PPTX criptografado requer carregar a apresentação completa com a senha de abertura correta.