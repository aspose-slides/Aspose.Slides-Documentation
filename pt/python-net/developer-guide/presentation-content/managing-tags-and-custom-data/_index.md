---
title: Gerenciar Tags e Dados Personalizados em Apresentações com Python
linktitle: Tags e Dados Personalizados
type: docs
weight: 300
url: /pt/python-net/managing-tags-and-custom-data/
keywords:
- propriedades de documento
- etiqueta
- dados personalizados
- XML personalizado
- parte XML personalizada
- metadados XML
- ItemId
- adicionar etiqueta
- valores de pares
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Aprenda a gerenciar tags e dados XML personalizados em apresentações PowerPoint com Aspose.Slides para Python via .NET, incluindo adicionar, ler, atualizar, auditar e remover partes XML personalizadas."
---
## **Visão geral**

Este artigo explica como o Aspose.Slides funciona com tags e dados personalizados em apresentações do PowerPoint. Dados específicos da apresentação podem ser armazenados como tags ou partes XML personalizadas. Tags são pares simples de string chave-valor, enquanto partes XML personalizadas podem armazenar metadados estruturados e cargas XML específicas de aplicativos.

O Aspose.Slides fornece APIs para adicionar, ler, atualizar, auditar e remover partes XML personalizadas nos níveis de apresentação, slide e forma. As partes XML personalizadas são úteis para integrações que armazenam informações como identificadores de gerenciamento de documentos, estado de fluxo de trabalho, metadados de conformidade, dados de vinculação de modelo ou outros dados de aplicação estruturados dentro de uma apresentação.

## **Armazenamento de Dados em Arquivos de Apresentação**

Arquivos PPTX — arquivos com a extensão `.pptx` — são armazenados no formato PresentationML, que faz parte da especificação Office Open XML. O Office Open XML define a estrutura de pacotes e os relacionamentos usados para armazenar o conteúdo da apresentação e dados relacionados.

Uma apresentação contém várias partes conectadas por relacionamentos. Por exemplo, uma parte de slide contém o conteúdo de um único slide e pode ter relacionamentos explícitos com outras partes definidos pela ISO/IEC 29500.

Dados personalizados podem ser armazenados como tags ([TagCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/tagcollection/)) ou partes XML personalizadas ([CustomXmlPartCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/customxmlpartcollection/)). Ambos estão disponíveis através da classe [`CustomData`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/customdata/).

{{% alert color="primary" %}}
Tags armazenam pares simples de string chave-valor. Partes XML personalizadas armazenam dados XML estruturados e podem ser associadas a uma apresentação, slide ou forma.
{{% /alert %}}

## **Trabalhar com Partes XML Personalizadas**

A propriedade [`CustomData.custom_xml_parts`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/customdata/custom_xml_parts/) retorna a coleção de partes XML personalizadas associadas a um determinado objeto de apresentação. Por exemplo:

- `presentation.custom_data.custom_xml_parts` contém partes XML personalizadas associadas à própria apresentação.
- `slide.custom_data.custom_xml_parts` contém partes XML personalizadas associadas a um slide específico.
- `shape.custom_data.custom_xml_parts` contém partes XML personalizadas associadas a uma forma específica.

Use [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/all_custom_xml_parts/) quando precisar inspecionar todas as partes XML personalizadas na apresentação, independentemente de onde estejam associadas.

### **Adicionar uma Parte XML Personalizada a uma Apresentação**

Use [`CustomXmlPartCollection.add`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/customxmlpartcollection/add/) para adicionar dados XML a uma coleção de partes XML personalizadas. O XML deve ser válido e não vazio.

O exemplo a seguir adiciona metadados estruturados à coleção de dados personalizados no nível da apresentação:

```py
import uuid
import aspose.slides as slides

custom_xml_content = (
    '<?xml version="1.0" encoding="UTF-8"?>'
    '<metadata xmlns="urn:example:metadata">'
    '<documentId>DOC-1001</documentId>'
    '<workflowState>Draft</workflowState>'
    '</metadata>'
)

with slides.Presentation() as presentation:
    custom_xml_part = presentation.custom_data.custom_xml_parts.add(custom_xml_content)

    # add atribui um identificador automaticamente. Defina um GUID específico somente quando necessário.
    custom_xml_part.item_id = uuid.uuid4()

    presentation.save("presentation_with_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

O método `add` também pode aceitar XML como array de bytes ou stream, o que é útil quando o conteúdo XML já está disponível em forma binária.

### **Adicionar uma Parte XML Personalizada a um Slide ou Forma**

Dados XML personalizados podem ser associados a um slide ou forma específicos em vez de toda a apresentação. Isso é útil quando os metadados descrevem apenas um objeto, como uma chave de modelo, identificador de registro externo ou informações de vinculação.

O exemplo a seguir adiciona uma parte XML personalizada a um slide e outra a uma forma:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.custom_data.custom_xml_parts.add(
        '<slideMetadata xmlns="urn:example:slides">'
        '<templateKey>TitleSlide</templateKey>'
        '</slideMetadata>'
    )

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 250, 80)

    shape.text_frame.text = "Customer data"
    shape.custom_data.custom_xml_parts.add(
        '<shapeMetadata xmlns="urn:example:shapes">'
        '<recordId>CRM-4281</recordId>'
        '</shapeMetadata>'
    )

    presentation.save("object_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

O nível em que uma parte é adicionada determina qual coleção `custom_data.custom_xml_parts` do objeto contém o relacionamento com aquela parte. Dados no nível da apresentação são adequados para metadados de todo o documento, dados no nível do slide para informações que pertencem a um slide específico, e dados no nível da forma para metadados vinculados a uma forma individual.

### **Listar e Auditar Todas as Partes XML Personalizadas**

Use [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/all_custom_xml_parts/) para recuperar todas as partes XML personalizadas de uma apresentação. Cada [`CustomXmlPart`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/customxmlpart/) expõe seu identificador, conteúdo XML e esquemas de namespace associados.

O exemplo a seguir lista todas as partes XML personalizadas e seus esquemas de namespace:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for custom_xml_part in presentation.all_custom_xml_parts:
        print("ItemId: " + str(custom_xml_part.item_id))
        print("XML:")
        print(custom_xml_part.xml_as_string)

        for namespace_schema in custom_xml_part.namespace_schemas:
            print("Namespace schema: " + namespace_schema)

        print()
```

`CustomXmlPart.namespace_schemas` retorna os esquemas XML associados à parte XML personalizada. Essa informação pode ser útil ao auditar apresentações que contêm XML produzido por sistemas externos.

### **Ler e Atualizar o Conteúdo XML e o ItemId**

Use [`CustomXmlPart.xml_as_string`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/customxmlpart/xml_as_string/) para trabalhar com XML como string UTF-8, ou [`CustomXmlPart.xml_data`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/customxmlpart/xml_data/) para trabalhar com os bytes brutos do XML. Ambas as propriedades podem ser lidas e atualizadas.

A propriedade [`CustomXmlPart.item_id`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/customxmlpart/item_id/) contém o GUID que identifica a parte XML personalizada no documento Office Open XML. Ela também pode ser alterada quando uma integração requer um novo identificador.

O exemplo a seguir atualiza o conteúdo XML e o identificador:

```py
import uuid
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    custom_xml_part = presentation.all_custom_xml_parts[0]

    # Leia o XML atual como texto.
    current_xml_content = custom_xml_part.xml_as_string
    print(current_xml_content)

    # Atualize o XML como uma string UTF-8.
    custom_xml_part.xml_as_string = (
        '<metadata xmlns="urn:example:metadata">'
        '<documentId>DOC-1001</documentId>'
        '<workflowState>Approved</workflowState>'
        '</metadata>'
    )

    # xml_data fornece o mesmo conteúdo XML como bytes brutos.
    custom_xml_data = custom_xml_part.xml_data
    print(custom_xml_data.decode("utf-8"))

    # Substitua o identificador quando necessário pela integração.
    custom_xml_part.item_id = uuid.uuid4()

    presentation.save("updated_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

Ao atribuir `xml_as_string` ou `xml_data`, forneça XML válido e não vazio. Use uma representação ou outra dependendo se a aplicação trabalha principalmente com strings ou dados de byte.

### **Remover uma Parte XML Personalizada**

O Aspose.Slides oferece várias maneiras de remover dados XML personalizados:

- [`CustomXmlPart.remove`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/customxmlpart/remove/) remove a parte XML personalizada da apresentação.
- [`CustomXmlPartCollection.remove`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/customxmlpartcollection/remove/) remove uma parte específica de uma coleção de partes XML personalizadas.
- [`CustomXmlPartCollection.remove_at`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/customxmlpartcollection/remove_at/) remove a parte no índice especificado da coleção.
- [`CustomXmlPartCollection.clear`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/customxmlpartcollection/clear/) remove todas as partes de uma coleção específica.

O exemplo a seguir remove uma parte XML personalizada ao nível da apresentação por referência:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    custom_xml_parts = presentation.custom_data.custom_xml_parts

    if len(custom_xml_parts) > 0:
        custom_xml_part = custom_xml_parts[0]
        custom_xml_parts.remove(custom_xml_part)

    presentation.save("custom_xml_removed.pptx", slides.export.SaveFormat.PPTX)
```

Se você já possui um `CustomXmlPart` e deseja remover essa parte da apresentação em vez de direcionar uma coleção específica, chame `custom_xml_part.remove()`.

Você também pode remover um item por índice:

```py
presentation.custom_data.custom_xml_parts.remove_at(0)
```

### **Limpar Todas as Partes XML Personalizadas de uma Coleção**

Use `clear` quando todas as partes XML personalizadas associadas a um determinado objeto de apresentação devem ser removidas.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.slides[0].custom_data.custom_xml_parts.clear()

    presentation.save("slide_custom_xml_cleared.pptx", slides.export.SaveFormat.PPTX)
```

`clear` afeta apenas a coleção selecionada. Por exemplo, limpar a coleção de um slide não limpa as coleções ao nível da apresentação ou da forma.

Para remover todas as partes XML personalizadas na apresentação, percorra `all_custom_xml_parts` e remova cada parte:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for custom_xml_part in presentation.all_custom_xml_parts:
        custom_xml_part.remove()

    presentation.save("all_custom_xml_removed.pptx", slides.export.SaveFormat.PPTX)
```

### **Manipular Partes XML Personalizadas Vinculadas ou Compartilhadas**

Em uma apresentação Office Open XML, a mesma parte XML personalizada pode ser referenciada por mais de um objeto da apresentação. Por exemplo, um arquivo existente pode conter relacionamentos de vários slides ou formas para a mesma parte XML personalizada subjacente.

Uma parte compartilhada deve ser tratada como um único objeto de dados com múltiplas referências:

- Atualizar seu `xml_as_string`, `xml_data` ou `item_id` altera a parte XML personalizada subjacente, de modo que a mudança se aplica onde quer que essa parte seja referenciada.
- `item_id` pode ser usado para identificar a mesma parte XML personalizada ao auditar coleções ao nível do objeto.
- Remover uma parte de uma coleção `custom_xml_parts` específica a remove dessa coleção. Use `CustomXmlPart.remove()` quando a própria parte deve ser removida da apresentação.
- Antes de excluir ou substituir uma parte compartilhada, inspecione as coleções ao nível do objeto para determinar se outros slides ou formas ainda a referenciam.

As sobrecargas `add` criam uma nova parte XML personalizada a partir do conteúdo XML; elas não aceitam um `CustomXmlPart` existente. Portanto, relacionamentos compartilhados são mais comumente encontrados ao carregar apresentações que já os contêm.

O exemplo a seguir audita coleções ao nível de apresentação, slide e forma por `item_id` e relata partes referenciadas a partir de mais de um local:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    references_by_item_id = {}

    def register_custom_xml_parts(owner_name, custom_xml_parts):
        for custom_xml_part in custom_xml_parts:
            references_by_item_id.setdefault(custom_xml_part.item_id, []).append(owner_name)

    register_custom_xml_parts("Presentation", presentation.custom_data.custom_xml_parts)

    for slide_index, slide in enumerate(presentation.slides):
        register_custom_xml_parts(
            "Slide " + str(slide_index + 1),
            slide.custom_data.custom_xml_parts
        )

        for shape_index, shape in enumerate(slide.shapes):
            register_custom_xml_parts(
                "Slide " + str(slide_index + 1) + ", shape " + str(shape_index),
                shape.custom_data.custom_xml_parts
            )

    for item_id, owner_names in references_by_item_id.items():
        if len(owner_names) > 1:
            print("Shared custom XML part: " + str(item_id))

            for owner_name in owner_names:
                print("  Referenced by: " + owner_name)
```

Esse tipo de auditoria é útil antes de modificar ou excluir dados XML personalizados em apresentações criadas por sistemas externos, pois a mesma parte de metadados pode participar de mais de um relacionamento.

## **Obter Valores das Tags**

Nos slides, uma tag corresponde à propriedade `DocumentProperties.keywords`. Este código de exemplo mostra como obter o valor de uma tag com Aspose.Slides for Python via .NET para [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/):

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    keywords = presentation.document_properties.keywords
```

## **Adicionar Tags a Apresentações**

O Aspose.Slides permite adicionar tags a apresentações. Uma tag tipicamente consiste em dois itens:

- o nome de uma propriedade personalizada, por exemplo, `MyTag`;
- o valor da propriedade personalizada, por exemplo, `My Tag Value`.

Se precisar classificar apresentações com base em uma regra ou propriedade específica, você pode adicionar tags para esse fim. Por exemplo, se quiser categorizar apresentações de países da América do Norte, pode criar uma tag North American e atribuir o país relevante como seu valor.

Este código de exemplo mostra como adicionar uma tag a uma [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) usando Aspose.Slides for Python via .NET:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    tags = presentation.custom_data.tags
    tags.add("MyTag", "My Tag Value")
```

Tags também podem ser definidas para um [Slide](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slide/):

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.custom_data.tags.add("tag", "value")
```

Ou para uma [Shape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/):

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```

### **Limitações**

Tags adicionadas via a coleção `custom_data.tags` são armazenadas apenas no arquivo PowerPoint. Elas **não** são transferidas para a estrutura de tags PDF quando a apresentação é exportada para PDF. Consequentemente, um identificador personalizado atribuído como tag não pode ser recuperado do PDF com tags.

**Solução alternativa**: Você pode armazenar um identificador personalizado no **Alt Text** do objeto (por exemplo, `shape.alternative_text = "MyId"`). Após exportar para PDF, o Alt Text pode aparecer na estrutura de tags do PDF.

## **Perguntas Frequentes**

**Posso remover todas as tags de uma apresentação, slide ou forma em uma única operação?**  
Sim. A [tag collection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/tagcollection/) suporta uma operação [clear](https://reference.aspose.com/slides/pt/python-net/aspose.slides/tagcollection/clear/) que exclui todos os pares chave‑valor de uma vez.

**Como excluir uma única tag pelo seu nome sem iterar sobre toda a coleção?**  
Use [remove(name)](https://reference.aspose.com/slides/pt/python-net/aspose.slides/tagcollection/remove/) em [TagCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/tagcollection/) para excluir a tag pela sua chave.

**Como posso recuperar a lista completa de nomes de tags para análise ou filtragem?**  
Use [get_names_of_tags](https://reference.aspose.com/slides/pt/python-net/aspose.slides/tagcollection/get_names_of_tags/) na [tag collection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/tagcollection/); ela retorna um array com todos os nomes de tags.

**Como posso encontrar todas as partes XML personalizadas independentemente de onde estejam armazenadas?**  
Use [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/all_custom_xml_parts/) para recuperar todas as partes XML personalizadas na apresentação.

**Devo usar `xml_as_string` ou `xml_data` para atualizar uma parte XML personalizada?**  
Use `xml_as_string` quando a aplicação trabalha com texto XML UTF-8. Use `xml_data` quando o XML já está disponível como array de bytes ou quando o processamento orientado a binários for mais conveniente. Ambas as propriedades representam o conteúdo XML da mesma parte XML personalizada.