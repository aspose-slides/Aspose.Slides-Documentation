---
title: Gerenciar Propriedades de Apresentação em Python
linktitle: Propriedades de Apresentação
type: docs
weight: 70
url: /pt/python-java/presentation-properties/
keywords:
- Propriedades do PowerPoint
- Propriedades da apresentação
- Propriedades do documento
- Propriedades integradas
- Propriedades personalizadas
- Propriedades avançadas
- Gerenciar propriedades
- Modificar propriedades
- Metadados do documento
- Editar metadados
- Idioma de revisão
- Idioma padrão
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Domine as propriedades de apresentação no Aspose.Slides para Python via Java e simplifique a pesquisa, branding e fluxo de trabalho em seus arquivos PowerPoint e OpenDocument."
---
## **Introdução**

Aspose.Slides suporta dois tipos de propriedades de documento: **Integradas** e **Personalizadas**. Ambos os tipos de propriedade podem ser facilmente acessados e gerenciados usando a API Aspose.Slides.

Aspose.Slides permite que você trabalhe com as propriedades de documento de apresentações através da classe [DocumentProperties](https://reference.aspose.com/slides/pt/python-java/aspose.slides/documentproperties/). Uma instância dessa classe é retornada por [Presentation.getDocumentProperties](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getDocumentProperties). Os exemplos a seguir mostram como ler, modificar e gerenciar essas propriedades.

{{% alert color="info" title="Note" %}}
Observe que os campos **Application** e **AppVersion** não podem ser modificados. O Aspose.Slides os reescreve a cada gravação, portanto, uma apresentação salva sempre reporta "Aspose.Slides for Java" e a versão da biblioteca que a produziu. Qualquer valor passado para [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/pt/python-java/aspose.slides/documentproperties/#setNameOfApplication) é descartado quando a apresentação é gravada.
{{% /alert %}}

## **Propriedades de Documento no PowerPoint**

O Microsoft PowerPoint 2007 permite que você gerencie as propriedades de documento de arquivos de apresentação. Clique no ícone Office e selecione **Prepare | Properties | Advanced Properties**, como mostrado abaixo:

|**Selecionando item de menu Propriedades Avançadas**|
| :- |
|![Propriedades de documento do PowerPoint](https://i.imgur.com/ZrmuCD6.jpg)|

Após selecionar **Advanced Properties**, uma caixa de diálogo aparece onde você pode gerenciar as propriedades de documento do arquivo PowerPoint:

|**Caixa de Diálogo de Propriedades**|
| :- |
|![Propriedades de documento do PowerPoint](https://i.imgur.com/LibmdQd.jpg)|

A **Caixa de Diálogo de Propriedades** contém abas como **General**, **Summary**, **Statistics**, **Contents** e **Custom**. Essas abas permitem configurar diferentes tipos de informações sobre arquivos PowerPoint. Use a aba **Custom** para gerenciar propriedades personalizadas.

## **Trabalhar com Propriedades de Documento Usando Aspose.Slides para Python via Java**

Conforme descrito anteriormente, Aspose.Slides para Python via Java suporta tanto propriedades **Integradas** quanto **Personalizadas**. A classe [DocumentProperties](https://reference.aspose.com/slides/pt/python-java/aspose.slides/documentproperties/) representa as propriedades de documento associadas a um arquivo de apresentação.

Use [Presentation.getDocumentProperties](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getDocumentProperties) para acessar essas propriedades conforme descrito abaixo.

## **Ler Propriedades Públicas de uma Apresentação Criptografada**

Uma senha de abertura normalmente protege tanto o conteúdo da apresentação quanto as propriedades de documento. Quando uma apresentação é criptografada ao passar `false` para [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/pt/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties), suas propriedades de documento permanecem públicas. Uma aplicação pode então passar `true` para [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/pt/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) e ler os metadados públicos sem fornecer a senha de abertura.

A opção de carregar apenas propriedades de documento controla o que o Aspose.Slides carrega; não descriptografa nada. Se as propriedades foram incluídas na criptografia, carregá‑las sem a senha falha. Se a apresentação não estiver criptografada, a opção é ignorada e a apresentação completa é carregada.

O exemplo a seguir verifica o modo de carregamento através de [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/pt/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) e então lê propriedades integradas através de [Presentation.getDocumentProperties](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getDocumentProperties):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions

load_options = LoadOptions()
load_options.setOnlyLoadDocumentProperties(True)

presentation = Presentation("public-properties-encrypted.pptx", load_options)
try:
    if presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded():
        properties = presentation.getDocumentProperties()

        print("Author: ", properties.getAuthor())
        print("Title: ", properties.getTitle())
        print("Keywords: ", properties.getKeywords())
    else:
        print("The presentation was not loaded in document-properties-only mode.")

finally:
    presentation.dispose()
```

Nesse modo, o conteúdo dos slides não é carregado. Slides, masters, layouts, formas, mídia e outros objetos da apresentação ficam indisponíveis. As aplicações devem sempre verificar [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/pt/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) antes de executar uma operação que requer o modelo de objeto completo da apresentação.

{{% alert color="warning" title="Warning" %}}
Metadados públicos podem expor nomes de autores, títulos, assuntos, palavras‑chave, informações da empresa, comentários e valores personalizados. Criptografe propriedades sensíveis juntamente com a apresentação. Deixe-as públicas apenas quando sistemas de indexação, classificação, busca ou gerenciamento de documentos tiverem necessidade específica de acessá‑las sem senha.
{{% /alert %}}

## **Atualizar Propriedades de uma Apresentação Criptografada**

Para um arquivo PPTX criptografado, uma apresentação carregada no modo somente propriedades de documento destina‑se à leitura de metadados públicos. O Aspose.Slides não pode salvar propriedades alteradas desse objeto somente‑metadados porque as propriedades públicas devem permanecer consistentes com os dados correspondentes dentro da apresentação criptografada. Atualizá‑las, portanto, requer a senha de abertura correta e um carregamento completo.

O exemplo a seguir abre a apresentação com [LoadOptions.setPassword](https://reference.aspose.com/slides/pt/python-java/aspose.slides/loadoptions/#setPassword), atualiza propriedades integradas públicas e salva o resultado. Em seguida, usa [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentationinfo/#isEncrypted) para verificar que a criptografia foi preservada e reabre os metadados públicos sem senha para verificar os novos valores:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions, PresentationFactory, SaveFormat

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation(input_path, load_options)
try:
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap")
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed")
    presentation.save(output_path, SaveFormat.Pptx)
finally:
    presentation.dispose()

presentation_info = PresentationFactory.getInstance().getPresentationInfo(output_path)
print("The presentation is encrypted: ", presentation_info.isEncrypted())

metadata_load_options = LoadOptions()
metadata_load_options.setOnlyLoadDocumentProperties(True)

metadata_presentation = Presentation(output_path, metadata_load_options)
try:
    if metadata_presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded():
        print("Title: ", metadata_presentation.getDocumentProperties().getTitle())
        print("Keywords: ", metadata_presentation.getDocumentProperties().getKeywords())
    else:
        print("The presentation was not loaded in document-properties-only mode.")

finally:
    metadata_presentation.dispose()
```

Se uma aplicação não tem permissão para descriptografar ou carregar o conteúdo da apresentação, deve tratar as propriedades públicas de um arquivo PPTX criptografado como somente‑leitura.

## **Acessar Propriedades Integradas**

As propriedades integradas expostas por [DocumentProperties](https://reference.aspose.com/slides/pt/python-java/aspose.slides/documentproperties/) incluem: **Creator** (Autor), **Description**, **Created** (Data de Criação), **Modified** (Data de Modificação), **Printed** (Data da Última Impressão), **LastModifiedBy**, **Keywords**, **SharedDoc** (É compartilhado entre diferentes produtores?), **PresentationFormat**, **Subject** e **Title**.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, DocumentProperties

# Instanciar a classe Presentation que representa a apresentação
presentation = Presentation("Presentation.pptx")
try:
    # Criar uma referência ao objeto DocumentProperties associado à Presentation
    properties = presentation.getDocumentProperties()

    # Exibir as propriedades integradas
    print("Category : ", properties.getCategory())
    print("Current Status : ", properties.getContentStatus())
    print("Creation Date : ", properties.getCreatedTime())
    print("Author : ", properties.getAuthor())
    print("Description : ", properties.getComments())
    print("KeyWords : ", properties.getKeywords())
    print("Last Modified By : ", properties.getLastSavedBy())
    print("Supervisor : ", properties.getManager())
    print("Modified Date : ", properties.getLastSavedTime())
    print("Presentation Format : ", properties.getPresentationFormat())
    print("Last Print Date : ", properties.getLastPrinted())
    print("Is Shared between producers : ", properties.getSharedDoc())
    print("Subject : ", properties.getSubject())
    print("Title : ", properties.getTitle())
finally:
    presentation.dispose()
```

## **Modificar Propriedades Integradas**

Modificar propriedades integradas é tão simples quanto acessá‑las. Use o setter correspondente para atribuir um novo valor. O exemplo a seguir modifica propriedades integradas de documento usando Aspose.Slides para Python via Java.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, DocumentProperties

presentation = Presentation("Presentation.pptx")
try:
    # Criar uma referência ao objeto DocumentProperties associado à Presentation
    properties = presentation.getDocumentProperties()

    # Definir as propriedades integradas
    properties.setAuthor("Aspose.Slides for Python via Java")
    properties.setTitle("Modifying Presentation Properties")
    properties.setSubject("Aspose Subject")
    properties.setComments("Aspose Description")
    properties.setManager("Aspose Manager")

    # Salvar sua apresentação em um arquivo
    presentation.save("DocProps.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Este exemplo modifica as propriedades integradas da apresentação, que podem ser visualizadas como mostrado abaixo:

|**Propriedades de documento integradas após modificação**|
| :- |
|![Propriedades de documento do PowerPoint](https://i.imgur.com/zz1N9de.jpg)|

## **Adicionar Propriedades de Documento Personalizadas**

Aspose.Slides para Python via Java também permite que desenvolvedores adicionem propriedades de documento personalizadas às apresentações. O exemplo abaixo adiciona três propriedades personalizadas, então procura o nome armazenado no índice 2 e remove essa propriedade, de modo que a apresentação salva mantém duas delas. As propriedades personalizadas são indexadas em ordem alfabética, não na ordem em que foram adicionadas.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Obtendo propriedades do documento
    properties = presentation.getDocumentProperties()

    # Adicionando propriedades customizadas
    properties.set_Item("New Custom", jpype.JInt(12))
    properties.set_Item("My Name", "Mudassir")
    properties.set_Item("Custom", jpype.JInt(124))

    # Obtendo o nome da propriedade em um índice específico
    property_name = properties.getCustomPropertyName(2)

    # Removendo a propriedade selecionada
    properties.removeCustomProperty(property_name)

    # Salvando a apresentação
    presentation.save("CustomDemo.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|**Propriedades de Documento Personalizadas Adicionadas**|
| :- |
|![Propriedades de documento do PowerPoint](https://i.imgur.com/HdKcxI9.png)|

## **Acessar e Modificar Propriedades Personalizadas**

Aspose.Slides para Python via Java também permite que desenvolvedores acessem os valores das propriedades personalizadas. O exemplo a seguir mostra como acessar e modificar todas as propriedades personalizadas em uma apresentação.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, DocumentProperties

presentation = Presentation("Presentation.pptx")
try:
    # Criar uma referência ao objeto DocumentProperties associado à Presentation
    properties = presentation.getDocumentProperties()

    # Acessar e modificar propriedades personalizadas
    for i in range(properties.getCountOfCustomProperties()):
        property_name = properties.getCustomPropertyName(i)
        # Exibir nomes e valores das propriedades personalizadas
        print("Custom Property Name : ", property_name)
        print("Custom Property Value : ", properties.get_Item(property_name))

        # Modificar valores das propriedades personalizadas
        properties.set_Item(property_name, f"New Value {i + 1}")

    # Salvar sua apresentação em um arquivo
    presentation.save("CustomDemoModified.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Este exemplo modifica as propriedades personalizadas da apresentação [PPTX](https://docs.fileformat.com/presentation/pptx/). As figuras a seguir mostram as propriedades personalizadas da apresentação antes e depois da modificação:

|**Propriedades Personalizadas antes da Modificação**|
| :- |
|![Propriedades de documento do PowerPoint](https://i.imgur.com/Ze7YHvi.jpg)|

|**Propriedades Personalizadas após Modificação**|
| :- |
|![Propriedades de documento do PowerPoint](https://i.imgur.com/Tofu0CL.jpg)|

## **Propriedades Avançadas de Documento**

{{% alert color="info" title="Note" %}}
Novos métodos [readDocumentProperties](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentationinfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) e [writeBindedPresentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentationinfo/#writeBindedPresentation) foram adicionados à classe [PresentationInfo](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentationinfo/), e o comportamento do método [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/pt/python-java/aspose.slides/documentproperties/#setLastSavedTime) foi alterado.
{{% /alert %}}

Os dois novos métodos [readDocumentProperties](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentationinfo/#readDocumentProperties) e [updateDocumentProperties](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) foram adicionados à classe [PresentationInfo](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentationinfo/). Eles fornecem acesso rápido às propriedades de documento e permitem alterar e atualizar propriedades sem carregar toda a apresentação.

O fluxo de trabalho típico de carregar propriedades, mudar seus valores e atualizar o documento pode ser implementado da seguinte forma:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

# Ler as informações da apresentação
presentation_info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx")

# Obter as propriedades atuais
properties = presentation_info.readDocumentProperties()

# Definir os novos valores dos campos Author e Title
properties.setAuthor("New Author")
properties.setTitle("New Title")

# Atualizar a apresentação com os novos valores
presentation_info.updateDocumentProperties(properties)
presentation_info.writeBindedPresentation("presentation.pptx")
```

Há outra maneira de usar as propriedades de uma apresentação específica como modelo para atualizar propriedades em outras apresentações:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("template.pptx")
template = presentation_info.readDocumentProperties()

template.setAuthor("Template Author")
template.setTitle("Template Title")
template.setCategory("Template Category")
template.setKeywords("Keyword1, Keyword2, Keyword3")
template.setCompany("Our Company")
template.setComments("Created from template")
template.setContentType("Template Content")
template.setSubject("Template Subject")

for path in ["doc1.pptx", "doc2.odp", "doc3.ppt"]:
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

def update_by_template(path, template):
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

Um novo modelo pode ser criado do zero e então usado para atualizar várias apresentações:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory, DocumentProperties

template = DocumentProperties()

template.setAuthor("Template Author")
template.setTitle("Template Title")
template.setCategory("Template Category")
template.setKeywords("Keyword1, Keyword2, Keyword3")
template.setCompany("Our Company")
template.setComments("Created from template")
template.setContentType("Template Content")
template.setSubject("Template Subject")

for path in ["doc1.pptx", "doc2.odp", "doc3.ppt"]:
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

## **Definir Idioma de Revisão**

Aspose.Slides fornece o método [PortionFormat.setLanguageId](https://reference.aspose.com/slides/pt/python-java/aspose.slides/portionformat/#setLanguageId) para permitir que você defina o idioma de revisão para um documento PowerPoint. O idioma de revisão é o idioma para o qual ortografia e gramática na apresentação são verificados.

Este código Python mostra como definir o idioma de revisão para um PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Portion, FontData

pptx_file_name = "presentation.pptx"

presentation = Presentation(pptx_file_name)
try:
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    new_portion = Portion()

    font = FontData("SimSun")
    portion_format = new_portion.getPortionFormat()
    portion_format.setComplexScriptFont(font)
    portion_format.setEastAsianFont(font)
    portion_format.setLatinFont(font)

    portion_format.setLanguageId("zh-CN") # definir o ID de um idioma de revisão

    new_portion.setText("1。")
    paragraph.getPortions().add(new_portion)
finally:
    presentation.dispose()
```

## **Definir Idioma Padrão**

Este código Python mostra como definir o idioma padrão para toda a apresentação PowerPoint:

```python
import jpype
import asposeslides

if not jpake.isJVMStarted():
    jpake.startJVM()

from asposeslides.api import Presentation, LoadOptions, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("en-US")

presentation = Presentation(load_options)
try:
    # Adiciona uma forma retangular com texto
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("New Text")

    # Verifica o idioma da primeira porção
    print(shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **Exemplo ao Vivo**

Experimente o aplicativo online [**Aspose.Slides Metadata**](https://products.aspose.app/slides/pt/metadata) para ver como trabalhar com propriedades de documento através da API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/pt/metadata)

## **Perguntas Frequentes**

**Como posso remover uma propriedade integrada de uma apresentação?**

Propriedades integradas são parte integrante da apresentação e não podem ser removidas completamente. Entretanto, você pode alterar seus valores ou defini‑las como vazias, se o específico permitir.

**O que acontece se eu adicionar uma propriedade personalizada que já existe?**

Se você adicionar uma propriedade personalizada que já existe, seu valor atual será sobrescrito pelo novo. Não é necessário remover ou verificar a propriedade anteriormente, pois o Aspose.Slides atualiza automaticamente o valor da propriedade.

**Posso acessar as propriedades da apresentação sem carregar completamente a apresentação?**

Sim. Use [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentationfactory/#getPresentationInfo) e depois [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentationinfo/#readDocumentProperties) para ler os metadados de documento armazenados sem criar uma instância de [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/). Consulte [Build a Lightweight Presentation Inventory](/slides/pt/python-java/examine-presentation/) para um exemplo completo de relatório e limitações específicas de formato.

**Posso ler propriedades públicas de uma apresentação criptografada sem sua senha de abertura?**

Sim. A criptografia de propriedades de documento deve ter sido desativada antes da apresentação ser criptografada, e a apresentação deve ser carregada no modo somente propriedades de documento.

**Posso atualizar um arquivo PPTX criptografado no modo somente propriedades de documento?**

Não. Dados de propriedades públicas e criptografadas devem permanecer consistentes, portanto, atualizar um arquivo PPTX criptografado requer o carregamento completo da apresentação com a senha de abertura correta.