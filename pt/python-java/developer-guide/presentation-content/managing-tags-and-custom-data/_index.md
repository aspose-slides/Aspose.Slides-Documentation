---
title: Gerenciar tags e dados personalizados em apresentações usando Python
linktitle: Tags e Dados Personalizados
type: docs
weight: 300
url: /pt/python-java/managing-tags-and-custom-data/
keywords:
- propriedades do documento
- tag
- dados personalizados
- XML personalizado
- parte XML personalizada
- metadados XML
- ItemId
- adicionar tag
- valores de pares
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Aprenda a gerenciar tags e dados XML personalizados em apresentações do PowerPoint com Aspose.Slides para Python via Java, incluindo adicionar, ler, atualizar, auditar e remover partes XML personalizadas."
---
## **Visão geral**

Este artigo explica como o Aspose.Slides trabalha com tags e dados personalizados em apresentações do PowerPoint. Dados específicos da apresentação podem ser armazenados como tags ou partes XML personalizadas. As tags são pares simples de strings chave‑valor, enquanto as partes XML personalizadas podem armazenar metadados estruturados e cargas úteis XML específicas de aplicativos.

O Aspose.Slides fornece APIs para adicionar, ler, atualizar, auditar e remover partes XML personalizadas nos níveis de apresentação, slide e forma. As partes XML personalizadas são úteis para integrações que armazenam informações como identificadores de gerenciamento de documentos, estado de fluxo de trabalho, metadados de conformidade, dados de vinculação de modelo ou outros dados de aplicação estruturados dentro de uma apresentação.

## **Armazenamento de Dados em Arquivos de Apresentação**

Os arquivos PPTX — arquivos com a extensão `.pptx` — são armazenados no formato PresentationML, que faz parte da especificação Office Open XML. O Office Open XML define a estrutura de pacotes e os relacionamentos usados para armazenar o conteúdo da apresentação e dados relacionados.

Uma apresentação contém várias partes conectadas por relacionamentos. Por exemplo, uma parte de slide contém o conteúdo de um único slide e pode ter relacionamentos explícitos com outras partes definidos pela ISO/IEC 29500.

Dados personalizados podem ser armazenados como tags ([TagCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/tagcollection/)) ou partes XML personalizadas ([CustomXmlPartCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/customxmlpartcollection/)). Ambos estão disponíveis através da classe [CustomData](https://reference.aspose.com/slides/pt/python-java/aspose.slides/customdata/) .

{{% alert color="info" title="Nota" %}}
As tags armazenam pares simples de strings chave‑valor. As partes XML personalizadas armazenam dados XML estruturados e podem ser associadas a uma apresentação, slide ou forma.
{{% /alert %}}

## **Trabalhar com Partes XML Personalizadas**

O método [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/pt/python-java/aspose.slides/customdata/#getCustomXmlParts) retorna a coleção de partes XML personalizadas associadas a um determinado objeto de apresentação. Por exemplo:

- A coleção [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/pt/python-java/aspose.slides/customdata/#getCustomXmlParts) da apresentação contém partes XML personalizadas associadas à própria apresentação.
- A coleção [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/pt/python-java/aspose.slides/customdata/#getCustomXmlParts) do slide contém partes XML personalizadas associadas a um slide específico.
- A coleção [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/pt/python-java/aspose.slides/customdata/#getCustomXmlParts) da forma contém partes XML personalizadas associadas a uma forma específica.

Use [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getAllCustomXmlParts) quando precisar inspecionar todas as partes XML personalizadas na apresentação, independentemente de onde estejam associadas.

### **Adicionar uma Parte XML Personalizada a uma Apresentação**

Use [CustomXmlPartCollection.add](https://reference.aspose.com/slides/pt/python-java/aspose.slides/customxmlpartcollection/#add) para adicionar dados XML a uma coleção de partes XML personalizadas. O XML deve ser válido e não vazio.

O exemplo a seguir adiciona metadados estruturados à coleção de dados personalizados no nível da apresentação:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.util import UUID

presentation = Presentation()
try:
    custom_xml_content = '<?xml version="1.0" encoding="UTF-8"?><metadata xmlns="urn:example:metadata"><documentId>DOC-1001</documentId><workflowState>Draft</workflowState></metadata>'
    custom_xml_part = presentation.getCustomData().getCustomXmlParts().add(custom_xml_content)

    # add atribui um identificador automaticamente. Defina um UUID específico somente quando necessário.
    item_id = UUID.randomUUID()
    custom_xml_part.setItemId(item_id)

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O método [add](https://reference.aspose.com/slides/pt/python-java/aspose.slides/customxmlpartcollection/#add) também pode aceitar XML como um array de bytes ou fluxo de entrada, o que é útil quando o conteúdo XML já está disponível em forma binária.

### **Adicionar uma Parte XML Personalizada a um Slide ou Forma**

Dados XML personalizados podem ser associados a um slide ou forma específicos em vez de toda a apresentação. Isso é útil quando os metadados descrevem apenas um objeto, como uma chave de modelo, identificador de registro externo ou informações de vínculo.

O exemplo a seguir adiciona uma parte XML personalizada a um slide e outra a uma forma:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide_xml_content = '<slideMetadata xmlns="urn:example:slides"><templateKey>TitleSlide</templateKey></slideMetadata>'
    slide.getCustomData().getCustomXmlParts().add(slide_xml_content)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 250, 80)
    shape.getTextFrame().setText("Customer data")
    shape_xml_content = '<shapeMetadata xmlns="urn:example:shapes"><recordId>CRM-4281</recordId></shapeMetadata>'
    shape.getCustomData().getCustomXmlParts().add(shape_xml_content)

    presentation.save("object_custom_xml.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O nível no qual uma parte é adicionada determina qual coleção [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/pt/python-java/aspose.slides/customdata/#getCustomXmlParts) do objeto contém o relacionamento com essa parte. Dados no nível da apresentação são apropriados para metadados de documento inteiro, dados no nível do slide para informações que pertencem a um slide específico, e dados no nível da forma para metadados vinculados a uma forma individual.

### **Listar e Auditar Todas as Partes XML Personalizadas**

Use [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getAllCustomXmlParts) para recuperar todas as partes XML personalizadas de uma apresentação. Cada [CustomXmlPart](https://reference.aspose.com/slides/pt/python-java/aspose.slides/customxmlpart/) expõe seu identificador, conteúdo XML e esquemas de namespace associados.

O exemplo a seguir lista todas as partes XML personalizadas e seus esquemas de namespace:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    for custom_xml_part in presentation.getAllCustomXmlParts():
        print("ItemId:", custom_xml_part.getItemId())
        print("XML:")
        print(custom_xml_part.getXmlAsString())

        for namespace_schema in custom_xml_part.getNamespaceSchemas():
            print("Namespace schema:", namespace_schema)

        print()
finally:
    presentation.dispose()
```

[CustomXmlPart.getNamespaceSchemas](https://reference.aspose.com/slides/pt/python-java/aspose.slides/customxmlpart/#getNamespaceSchemas) retorna os esquemas XML associados à parte XML personalizada. Essas informações podem ser úteis ao auditar apresentações que contêm XML produzido por sistemas externos.

### **Ler e Atualizar o Conteúdo XML e ItemId**

Use [CustomXmlPart.getXmlAsString](https://reference.aspose.com/slides/pt/python-java/aspose.slides/customxmlpart/#getXmlAsString) e [setXmlAsString](https://reference.aspose.com/slides/pt/python-java/aspose.slides/customxmlpart/#setXmlAsString) para trabalhar com XML como uma string UTF‑8, ou [getXmlData](https://reference.aspose.com/slides/pt/python-java/aspose.slides/customxmlpart/#getXmlData) e [setXmlData](https://reference.aspose.com/slides/pt/python-java/aspose.slides/customxmlpart/#setXmlData) para trabalhar com os bytes brutos do XML.

O método [CustomXmlPart.getItemId](https://reference.aspose.com/slides/pt/python-java/aspose.slides/customxmlpart/#getItemId) retorna o UUID que identifica a parte XML personalizada no documento Office Open XML. Use [setItemId](https://reference.aspose.com/slides/pt/python-java/aspose.slides/customxmlpart/#setItemId) quando uma integração requer um novo identificador.

O exemplo a seguir atualiza o conteúdo XML e o identificador:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.util import UUID

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getAllCustomXmlParts()
    if len(custom_xml_parts) > 0:
        custom_xml_part = custom_xml_parts[0]

        # Leia o XML atual como texto.
        current_xml_content = custom_xml_part.getXmlAsString()
        print(current_xml_content)

        # Atualize o XML como uma string UTF-8.
        custom_xml_content = '<metadata xmlns="urn:example:metadata"><documentId>DOC-1001</documentId><workflowState>Approved</workflowState></metadata>'
        custom_xml_part.setXmlAsString(custom_xml_content)

        # getXmlData fornece o mesmo conteúdo XML como bytes brutos.
        custom_xml_data = custom_xml_part.getXmlData()
        print(bytes(custom_xml_data).decode("utf-8"))

        # Substitua o identificador quando exigido pela integração.
        item_id = UUID.randomUUID()
        custom_xml_part.setItemId(item_id)

        presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx)
    else:
        print("No custom XML parts found.")
finally:
    presentation.dispose()
```

Ao chamar [setXmlAsString](https://reference.aspose.com/slides/pt/python-java/aspose.slides/customxmlpart/#setXmlAsString) ou [setXmlData](https://reference.aspose.com/slides/pt/python-java/aspose.slides/customxmlpart/#setXmlData), forneça XML válido e não vazio. Use uma representação ou a outra dependendo se a aplicação trabalha principalmente com strings ou dados de byte.

### **Remover uma Parte XML Personalizada**

O Aspose.Slides oferece várias maneiras de remover dados XML personalizados:

- [CustomXmlPart.remove](https://reference.aspose.com/slides/pt/python-java/aspose.slides/customxmlpart/#remove) remove a parte XML personalizada da apresentação.
- [CustomXmlPartCollection.remove](https://reference.aspose.com/slides/pt/python-java/aspose.slides/customxmlpartcollection/#remove) remove uma parte específica de uma coleção de partes XML personalizadas.
- [CustomXmlPartCollection.removeAt](https://reference.aspose.com/slides/pt/python-java/aspose.slides/customxmlpartcollection/#removeAt) remove a parte em um índice de coleção especificado.
- [CustomXmlPartCollection.clear](https://reference.aspose.com/slides/pt/python-java/aspose.slides/customxmlpartcollection/#clear) remove todas as partes de uma coleção específica.

O exemplo a seguir remove uma parte XML personalizada no nível da apresentação por referência:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getCustomData().getCustomXmlParts()
    if custom_xml_parts.size() > 0:
        custom_xml_part = custom_xml_parts.get_Item(0)
        custom_xml_parts.remove(custom_xml_part)

    presentation.save("custom_xml_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Se você já possui um [CustomXmlPart](https://reference.aspose.com/slides/pt/python-java/aspose.slides/customxmlpart/) e deseja remover essa parte da apresentação ao invés de acessar uma coleção específica, chame [CustomXmlPart.remove](https://reference.aspose.com/slides/pt/python-java/aspose.slides/customxmlpart/#remove).

Você também pode remover um item por índice:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getCustomData().getCustomXmlParts()
    if custom_xml_parts.size() > 0:
        custom_xml_parts.removeAt(0)
finally:
    presentation.dispose()
```

### **Limpar Todas as Partes XML Personalizadas de uma Coleção**

Use [clear](https://reference.aspose.com/slides/pt/python-java/aspose.slides/customxmlpartcollection/#clear) quando todas as partes XML personalizadas associadas a um determinado objeto de apresentação devem ser removidas.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear()

    presentation.save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[clear](https://reference.aspose.com/slides/pt/python-java/aspose.slides/customxmlpartcollection/#clear) afeta apenas a coleção selecionada. Por exemplo, limpar a coleção de um slide não limpa as coleções no nível da apresentação ou da forma.

Para remover todas as partes XML personalizadas na apresentação, itere através de [getAllCustomXmlParts](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getAllCustomXmlParts) e remova cada parte:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    for custom_xml_part in presentation.getAllCustomXmlParts():
        custom_xml_part.remove()

    presentation.save("all_custom_xml_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Manipular Partes XML Personalizadas Vinculadas ou Compartilhadas**

Em uma apresentação Office Open XML, a mesma parte XML personalizada pode ser referenciada por mais de um objeto da apresentação. Por exemplo, um arquivo existente pode conter relacionamentos de vários slides ou formas para a mesma parte XML personalizada subjacente.

Uma parte compartilhada deve ser tratada como um único objeto de dados com múltiplas referências:

- Atualizá‑la com [setXmlAsString](https://reference.aspose.com/slides/pt/python-java/aspose.slides/customxmlpart/#setXmlAsString), [setXmlData](https://reference.aspose.com/slides/pt/python-java/aspose.slides/customxmlpart/#setXmlData) ou [setItemId](https://reference.aspose.com/slides/pt/python-java/aspose.slides/customxmlpart/#setItemId) altera a parte XML personalizada subjacente, de modo que a mudança se aplica onde quer que essa parte seja referenciada.
- [getItemId](https://reference.aspose.com/slides/pt/python-java/aspose.slides/customxmlpart/#getItemId) pode ser usado para identificar a mesma parte XML personalizada ao auditar coleções em nível de objeto.
- Remover uma parte de uma coleção específica [getCustomXmlParts](https://reference.aspose.com/slides/pt/python-java/aspose.slides/customdata/#getCustomXmlParts) a remove dessa coleção. Use [CustomXmlPart.remove](https://reference.aspose.com/slides/pt/python-java/aspose.slides/customxmlpart/#remove) quando a própria parte deve ser removida da apresentação.
- Antes de excluir ou substituir uma parte compartilhada, inspecione as coleções em nível de objeto para determinar se outros slides ou formas ainda a referenciam.

As sobrecargas de [add](https://reference.aspose.com/slides/pt/python-java/aspose.slides/customxmlpartcollection/#add) criam uma nova parte XML personalizada a partir do conteúdo XML; elas não aceitam um [CustomXmlPart](https://reference.aspose.com/slides/pt/python-java/aspose.slides/customxmlpart/) existente. Portanto, relacionamentos compartilhados são mais comumente encontrados ao carregar apresentações que já os contêm.

O exemplo a seguir audita coleções nos níveis de apresentação, slide e forma por `ItemId` e relata partes referenciadas em mais de um local:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    references_by_item_id = {}

    def register_custom_xml_parts(owner_name, custom_xml_parts):
        for i in range(custom_xml_parts.size()):
            custom_xml_part = custom_xml_parts.get_Item(i)
            item_id = str(custom_xml_part.getItemId())
            references_by_item_id.setdefault(item_id, []).append(owner_name)

    register_custom_xml_parts("Presentation", presentation.getCustomData().getCustomXmlParts())

    for slide_index in range(presentation.getSlides().size()):
        slide = presentation.getSlides().get_Item(slide_index)
        register_custom_xml_parts(f"Slide {slide_index + 1}", slide.getCustomData().getCustomXmlParts())

        for shape_index in range(slide.getShapes().size()):
            shape = slide.getShapes().get_Item(shape_index)
            register_custom_xml_parts(f"Slide {slide_index + 1}, shape {shape_index}", shape.getCustomData().getCustomXmlParts())

    for item_id, owner_names in references_by_item_id.items():
        if len(owner_names) > 1:
            print("Shared custom XML part:", item_id)
            for owner_name in owner_names:
                print("  Referenced by:", owner_name)
finally:
    presentation.dispose()
```

Esse tipo de auditoria é útil antes de modificar ou excluir dados XML personalizados em apresentações criadas por sistemas externos, pois a mesma parte de metadados pode participar de mais de um relacionamento.

## **Obter Valores das Tags**

Nos slides, uma tag corresponde ao método [DocumentProperties.getKeywords](https://reference.aspose.com/slides/pt/python-java/aspose.slides/documentproperties/#getKeywords). Este código de exemplo mostra como obter o valor de uma tag com Aspose.Slides para Python via Java para [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    keywords = presentation.getDocumentProperties().getKeywords()
finally:
    presentation.dispose()
```

## **Adicionar Tags a Apresentações**

O Aspose.Slides permite adicionar tags a apresentações. Uma tag geralmente consiste em dois itens:

- o nome de uma propriedade personalizada, por exemplo, `MyTag`;
- o valor da propriedade personalizada, por exemplo, `My Tag Value`.

Se precisar classificar apresentações com base em uma regra ou propriedade específica, você pode adicionar tags para esse fim. Por exemplo, se quiser categorizar apresentações de países da América do Norte, pode criar uma tag América do Norte e atribuir o país relevante como seu valor.

Este código de exemplo mostra como adicionar uma tag a uma [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) usando Aspose.Slides para Python via Java:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    tags = presentation.getCustomData().getTags()
    tags.set_Item("MyTag", "My Tag Value")
finally:
    presentation.dispose()
```

Tags também podem ser definidas para um [Slide](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slide/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide.getCustomData().getTags().set_Item("tag", "value")
finally:
    presentation.dispose()
```

Ou para uma [Shape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/) individual:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50)
    shape.getTextFrame().setText("My text")
    shape.getCustomData().getTags().set_Item("tag", "value")
finally:
    presentation.dispose()
```

### **Limitações**

Tags adicionadas através da coleção [CustomData.getTags](https://reference.aspose.com/slides/pt/python-java/aspose.slides/customdata/#getTags) são armazenadas apenas no arquivo PowerPoint. Elas **não** são transferidas para a estrutura de tags do PDF quando a apresentação é exportada para PDF. Consequentemente, um identificador personalizado atribuído como tag não pode ser recuperado do PDF marcado.

**Solução alternativa**: Você pode armazenar um identificador personalizado no **Alt Text** do objeto (por exemplo, [Shape.setAlternativeText](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#setAlternativeText) com o valor `"MyId"`). Após exportar para PDF, o Alt Text pode aparecer na estrutura de tags do PDF.

## **FAQ**

**Posso remover todas as tags de uma apresentação, slide ou forma em uma única operação?**

Sim. A [tag collection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/tagcollection/) suporta uma operação [clear](https://reference.aspose.com/slides/pt/python-java/aspose.slides/tagcollection/#clear) que exclui todos os pares chave‑valor de uma só vez.

**Como excluo uma única tag pelo seu nome sem iterar sobre toda a coleção?**

Use [remove](https://reference.aspose.com/slides/pt/python-java/aspose.slides/tagcollection/#remove) na [tag collection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/tagcollection/) para excluir a tag pela sua chave.

**Como posso recuperar a lista completa de nomes de tags para análise ou filtragem?**

Use [getNamesOfTags](https://reference.aspose.com/slides/pt/python-java/aspose.slides/tagcollection/#getNamesOfTags) na [tag collection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/tagcollection/); ele retorna um array com todos os nomes de tags.

**Como posso encontrar todas as partes XML personalizadas independentemente de onde estejam armazenadas?**

Use [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getAllCustomXmlParts) para recuperar todas as partes XML personalizadas na apresentação.

**Devo usar [getXmlAsString]/[setXmlAsString] ou [getXmlData]/[setXmlData] para atualizar uma parte XML personalizada?**

Use [getXmlAsString] e [setXmlAsString] quando a aplicação trabalha com texto XML UTF‑8. Use [getXmlData] e [setXmlData] quando o XML já está disponível como um array de bytes ou quando o processamento orientado a binário for mais conveniente. Ambas as representações referem‑se ao conteúdo XML da mesma parte XML personalizada.