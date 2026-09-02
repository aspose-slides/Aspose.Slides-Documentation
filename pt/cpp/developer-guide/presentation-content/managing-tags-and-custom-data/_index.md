---
title: Gerenciar Tags e Dados Personalizados em Apresentações Usando C++
linktitle: Tags e Dados Personalizados
type: docs
weight: 300
url: /pt/cpp/managing-tags-and-custom-data/
keywords:
- propriedades do documento
- tag
- dados personalizados
- XML personalizado
- parte XML personalizada
- metadados XML
- ItemId
- adicionar tag
- pares de valores
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Aprenda como gerenciar tags e dados XML personalizados em apresentações PowerPoint com Aspose.Slides para C++, incluindo adicionar, ler, atualizar, auditar e remover partes XML personalizadas."
---
## **Visão Geral**

Este artigo explica como o Aspose.Slides funciona com tags e dados personalizados em apresentações do PowerPoint. Dados específicos de uma apresentação podem ser armazenados como tags ou partes XML personalizadas. Tags são pares simples de string chave‑valor, enquanto partes XML personalizadas podem armazenar metadados estruturados e cargas XML específicas da aplicação.

Aspose.Slides fornece APIs para adicionar, ler, atualizar, auditar e remover partes XML personalizadas nos níveis de apresentação, slide e forma. Partes XML personalizadas são úteis para integrações que armazenam informações como identificadores de gerenciamento de documentos, estado de fluxo de trabalho, metadados de conformidade, dados de vínculo de modelo ou outros dados de aplicação estruturados dentro de uma apresentação.

## **Armazenamento de Dados em Arquivos de Apresentação**

Arquivos PPTX — arquivos com a extensão `.pptx` — são armazenados no formato PresentationML, que faz parte da especificação Office Open XML. Office Open XML define a estrutura de pacotes e relacionamentos usados para armazenar o conteúdo da apresentação e dados relacionados.

Uma apresentação contém múltiplas partes conectadas por relacionamentos. Por exemplo, uma parte de slide contém o conteúdo de um único slide e pode ter relacionamentos explícitos com outras partes definidas pela ISO/IEC 29500.

Dados personalizados podem ser armazenados como tags ([ITagCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itagcollection/)) ou partes XML personalizadas ([ICustomXmlPartCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/icustomxmlpartcollection/)). Ambos estão disponíveis através da interface [`ICustomData`](https://reference.aspose.com/slides/pt/cpp/aspose.slides/icustomdata/).

{{% alert color="primary" %}}
Tags armazenam pares simples de string chave‑valor. Partes XML personalizadas armazenam dados XML estruturados e podem ser associadas a uma apresentação, slide ou forma.
{{% /alert %}}

## **Trabalhar com Partes XML Personalizadas**

O método [`ICustomData::get_CustomXmlParts`](https://reference.aspose.com/slides/pt/cpp/aspose.slides/icustomdata/get_customxmlparts/) retorna a coleção de partes XML personalizadas associadas a um determinado objeto de apresentação. Por exemplo:

- `presentation->get_CustomData()->get_CustomXmlParts()` contém as partes XML personalizadas associadas à própria apresentação.
- `slide->get_CustomData()->get_CustomXmlParts()` contém as partes XML personalizadas associadas a um slide específico.
- `shape->get_CustomData()->get_CustomXmlParts()` contém as partes XML personalizadas associadas a uma forma específica.

Use [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/get_allcustomxmlparts/) quando precisar inspecionar todas as partes XML personalizadas na apresentação, independentemente de onde estejam associadas.

### **Adicionar uma Parte XML Personalizada a uma Apresentação**

Use [`ICustomXmlPartCollection::Add`](https://reference.aspose.com/slides/pt/cpp/aspose.slides/icustomxmlpartcollection/add/) para adicionar dados XML a uma coleção de partes XML personalizadas. O XML deve ser válido e não vazio.

O exemplo a seguir adiciona metadados estruturados à coleção de dados personalizados ao nível da apresentação:

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPart.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/guid.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::String customXmlContent =
    u"<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
    u"<metadata xmlns=\"urn:example:metadata\">"
        u"<documentId>DOC-1001</documentId>"
        u"<workflowState>Draft</workflowState>"
    u"</metadata>";

auto presentation = System::MakeObject<Presentation>();
auto customXmlPart = presentation->get_CustomData()->get_CustomXmlParts()->Add(customXmlContent);

// Add atribui um identificador automaticamente. Defina um GUID específico somente quando necessário.
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"presentation_with_custom_xml.pptx", SaveFormat::Pptx);
```

O método `Add` também pode aceitar XML como um array de bytes ou fluxo, o que é útil quando o conteúdo XML já está disponível em forma binária.

### **Adicionar uma Parte XML Personalizada a um Slide ou Forma**

Dados XML personalizados podem ser associados a um slide ou forma específico em vez de toda a apresentação. Isso é útil quando os metadados descrevem apenas um objeto, como uma chave de modelo, identificador de registro externo ou informação de vínculo.

O exemplo a seguir adiciona uma parte XML personalizada a um slide e outra a uma forma:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

slide->get_CustomData()->get_CustomXmlParts()->Add(
    u"<slideMetadata xmlns=\"urn:example:slides\">"
        u"<templateKey>TitleSlide</templateKey>"
    u"</slideMetadata>");

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 250.0f, 80.0f);

shape->get_TextFrame()->set_Text(u"Customer data");
shape->get_CustomData()->get_CustomXmlParts()->Add(
    u"<shapeMetadata xmlns=\"urn:example:shapes\">"
        u"<recordId>CRM-4281</recordId>"
    u"</shapeMetadata>");

presentation->Save(u"object_custom_xml.pptx", SaveFormat::Pptx);
```

O nível no qual a parte é adicionada determina qual coleção `get_CustomData()->get_CustomXmlParts()` do objeto contém o relacionamento com essa parte. Dados ao nível da apresentação são adequados para metadados de todo o documento, dados ao nível do slide para informações que pertencem a um slide específico, e dados ao nível da forma para metadados vinculados a uma forma individual.

### **Listar e Auditar Todas as Partes XML Personalizadas**

Use [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/get_allcustomxmlparts/) para obter todas as partes XML personalizadas de uma apresentação. Cada [`ICustomXmlPart`](https://reference.aspose.com/slides/pt/cpp/aspose.slides/icustomxmlpart/) expõe seu identificador, conteúdo XML e esquemas de namespace associados.

O exemplo a seguir lista todas as partes XML personalizadas e seus esquemas de namespace:

```cpp
#include <DOM/ICustomXmlPart.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (auto customXmlPart : presentation->get_AllCustomXmlParts())
{
    System::Console::WriteLine(System::String(u"ItemId: ") + customXmlPart->get_ItemId().ToString());
    System::Console::WriteLine(u"XML:");
    System::Console::WriteLine(customXmlPart->get_XmlAsString());

    for (auto namespaceSchema : customXmlPart->get_NamespaceSchemas())
    {
        System::Console::WriteLine(System::String(u"Namespace schema: ") + namespaceSchema);
    }

    System::Console::WriteLine();
}
```

`[ICustomXmlPart::get_NamespaceSchemas](https://reference.aspose.com/slides/pt/cpp/aspose.slides/icustomxmlpart/get_namespaceschemas/)` retorna os esquemas XML associados à parte XML personalizada. Esta informação pode ser útil ao auditar apresentações que contêm XML produzido por sistemas externos.

### **Ler e Atualizar o Conteúdo XML e ItemId**

Use [`ICustomXmlPart::get_XmlAsString`](https://reference.aspose.com/slides/pt/cpp/aspose.slides/icustomxmlpart/get_xmlasstring/) e `set_XmlAsString` para trabalhar com XML como uma string UTF‑8, ou [`ICustomXmlPart::get_XmlData`](https://reference.aspose.com/slides/pt/cpp/aspose.slides/icustomxmlpart/get_xmldata/) e `set_XmlData` para trabalhar com os bytes brutos do XML. Ambas as representações podem ser lidas e atualizadas.

O método [`ICustomXmlPart::get_ItemId`](https://reference.aspose.com/slides/pt/cpp/aspose.slides/icustomxmlpart/get_itemid/) retorna o GUID que identifica a parte XML personalizada no documento Office Open XML. O identificador também pode ser alterado com `set_ItemId` quando uma integração requer um novo identificador.

O exemplo a seguir atualiza o conteúdo XML e o identificador:

```cpp
#include <DOM/ICustomXmlPart.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/guid.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto customXmlPart = presentation->get_AllCustomXmlParts()->idx_get(0);

// Leia o XML atual como texto.
auto currentXmlContent = customXmlPart->get_XmlAsString();
System::Console::WriteLine(currentXmlContent);

// Atualize o XML como uma string UTF-8.
customXmlPart->set_XmlAsString(
    u"<metadata xmlns=\"urn:example:metadata\">"
        u"<documentId>DOC-1001</documentId>"
        u"<workflowState>Approved</workflowState>"
    u"</metadata>");

// XmlData fornece o mesmo conteúdo XML como bytes brutos.
auto customXmlData = customXmlPart->get_XmlData();
System::Console::WriteLine(System::Text::Encoding::get_UTF8()->GetString(customXmlData));

// Substitua o identificador quando necessário pela integração.
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"updated_custom_xml.pptx", SaveFormat::Pptx);
```

Ao atribuir XML com `set_XmlAsString` ou `set_XmlData`, forneça XML válido e não vazio. Use uma representação ou outra dependendo se a aplicação trabalha principalmente com strings ou dados em bytes.

### **Remover uma Parte XML Personalizada**

Aspose.Slides fornece várias maneiras de remover dados XML personalizados:

- `[ICustomXmlPart::Remove](https://reference.aspose.com/slides/pt/cpp/aspose.slides/icustomxmlpart/remove/)` remove a parte XML personalizada da apresentação.
- `[ICustomXmlPartCollection::Remove](https://reference.aspose.com/slides/pt/cpp/aspose.slides/icustomxmlpartcollection/remove/)` remove uma parte específica de uma coleção de partes XML personalizadas.
- `[ICustomXmlPartCollection::RemoveAt](https://reference.aspose.com/slides/pt/cpp/aspose.slides/icustomxmlpartcollection/removeat/)` remove a parte em um índice especificado da coleção.
- `[ICustomXmlPartCollection::Clear](https://reference.aspose.com/slides/pt/cpp/aspose.slides/icustomxmlpartcollection/clear/)` remove todas as partes de uma coleção específica.

O exemplo a seguir remove uma parte XML personalizada ao nível da apresentação por referência:

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto customXmlParts = presentation->get_CustomData()->get_CustomXmlParts();

if (customXmlParts->get_Count() > 0)
{
    auto customXmlPart = customXmlParts->idx_get(0);
    customXmlParts->Remove(customXmlPart);
}

presentation->Save(u"custom_xml_removed.pptx", SaveFormat::Pptx);
```

Se você já possui um `ICustomXmlPart` e deseja remover essa parte da apresentação em vez de acessar uma coleção específica, chame `customXmlPart->Remove()`.

Você também pode remover um item por índice:

```cpp
presentation->get_CustomData()->get_CustomXmlParts()->RemoveAt(0);
```

### **Limpar Todas as Partes XML Personalizadas de uma Coleção**

Use `Clear` quando todas as partes XML personalizadas associadas a um determinado objeto de apresentação devem ser removidas.

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->get_Slides()->idx_get(0)->get_CustomData()->get_CustomXmlParts()->Clear();

presentation->Save(u"slide_custom_xml_cleared.pptx", SaveFormat::Pptx);
```

`Clear` afeta apenas a coleção selecionada. Por exemplo, limpar a coleção de um slide não limpa as coleções ao nível da apresentação ou da forma.

Para remover todas as partes XML personalizadas na apresentação, itere através de `get_AllCustomXmlParts()` e remova cada parte:

```cpp
#include <DOM/ICustomXmlPart.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (auto customXmlPart : presentation->get_AllCustomXmlParts())
{
    customXmlPart->Remove();
}

presentation->Save(u"all_custom_xml_removed.pptx", SaveFormat::Pptx);
```

### **Manipular Partes XML Personalizadas Vinculadas ou Compartilhadas**

Em uma apresentação Office Open XML, a mesma parte XML personalizada pode ser referenciada por mais de um objeto da apresentação. Por exemplo, um arquivo existente pode conter relacionamentos de múltiplos slides ou formas para a mesma parte XML personalizada subjacente.

Uma parte compartilhada deve ser tratada como um único objeto de dados com múltiplas referências:

- Atualizá‑la com `set_XmlAsString`, `set_XmlData` ou `set_ItemId` altera a parte XML personalizada subjacente, de modo que a mudança se aplica onde quer que essa parte seja referenciada.
- `get_ItemId()` pode ser usado para identificar a mesma parte XML personalizada ao auditar coleções em nível de objeto.
- Remover uma parte de uma coleção específica `get_CustomXmlParts()` a remove daquela coleção. Use `ICustomXmlPart::Remove()` quando a própria parte deve ser removida da apresentação.
- Antes de excluir ou substituir uma parte compartilhada, inspecione as coleções em nível de objeto para determinar se outros slides ou formas ainda a referenciam.

As sobrecargas `Add` criam uma nova parte XML personalizada a partir do conteúdo XML; elas não aceitam um `ICustomXmlPart` existente. Portanto, relacionamentos compartilhados são mais comumente encontrados ao carregar apresentações que já os contêm.

O exemplo a seguir audita coleções ao nível de apresentação, slide e forma por `ItemId` e relata partes referenciadas em mais de um local:

```cpp
#include <algorithm>
#include <vector>
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPart.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/guid.h>
#include <system/string.h>

using namespace Aspose::Slides;

struct CustomXmlReferenceEntry
{
    System::Guid itemId;
    std::vector<System::String> owners;
};

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
std::vector<CustomXmlReferenceEntry> referencesByItemId;

auto registerCustomXmlParts = [&referencesByItemId](
    const System::String& ownerName,
    const System::SharedPtr<ICustomXmlPartCollection>& customXmlParts)
{
    for (int32_t partIndex = 0; partIndex < customXmlParts->get_Count(); ++partIndex)
    {
        auto customXmlPart = customXmlParts->idx_get(partIndex);
        auto itemId = customXmlPart->get_ItemId();

        auto entry = std::find_if(
            referencesByItemId.begin(),
            referencesByItemId.end(),
            [&itemId](const CustomXmlReferenceEntry& referenceEntry)
            {
                return referenceEntry.itemId == itemId;
            });

        if (entry == referencesByItemId.end())
        {
            referencesByItemId.push_back({ itemId, { ownerName } });
        }
        else
        {
            entry->owners.push_back(ownerName);
        }
    }
};

registerCustomXmlParts(u"Presentation", presentation->get_CustomData()->get_CustomXmlParts());

for (int32_t slideIndex = 0; slideIndex < presentation->get_Slides()->get_Count(); ++slideIndex)
{
    auto slide = presentation->get_Slides()->idx_get(slideIndex);
    registerCustomXmlParts(
        System::String::Format(u"Slide {0}", slideIndex + 1),
        slide->get_CustomData()->get_CustomXmlParts());

    for (int32_t shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
    {
        auto shape = slide->get_Shapes()->idx_get(shapeIndex);
        registerCustomXmlParts(
            System::String::Format(u"Slide {0}, shape {1}", slideIndex + 1, shapeIndex),
            shape->get_CustomData()->get_CustomXmlParts());
    }
}

for (const auto& referenceEntry : referencesByItemId)
{
    if (referenceEntry.owners.size() > 1)
    {
        System::Console::WriteLine(
            System::String(u"Shared custom XML part: ") + referenceEntry.itemId.ToString());

        for (const auto& ownerName : referenceEntry.owners)
        {
            System::Console::WriteLine(System::String(u"  Referenced by: ") + ownerName);
        }
    }
}
```

Esse tipo de auditoria é útil antes de modificar ou excluir dados XML personalizados em apresentações criadas por sistemas externos, pois a mesma parte de metadados pode participar de mais de um relacionamento.

## **Obter Valores das Tags**

Nos slides, uma tag corresponde à propriedade `IDocumentProperties::get_Keywords`. Este código de exemplo mostra como obter o valor de uma tag com Aspose.Slides for C++ para [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/):

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto keywords = presentation->get_DocumentProperties()->get_Keywords();
```

## **Adicionar Tags a Apresentações**

Aspose.Slides permite adicionar tags a apresentações. Uma tag normalmente consiste em dois itens:

- o nome de uma propriedade personalizada, por exemplo, `MyTag`;
- o valor da propriedade personalizada, por exemplo, `My Tag Value`.

Se precisar classificar apresentações com base em uma regra ou propriedade específica, você pode adicionar tags para esse propósito. Por exemplo, se quiser categorizar apresentações de países da América do Norte, pode criar uma tag da América do Norte e atribuir o país relevante como seu valor.

Este código de exemplo mostra como adicionar uma tag a uma [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) usando Aspose.Slides for C++:

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ITagCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto tags = presentation->get_CustomData()->get_Tags();
tags->idx_set(u"MyTag", u"My Tag Value");
```

Tags também podem ser definidas para um [Slide](https://reference.aspose.com/slides/pt/cpp/aspose.slides/slide/):

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITagCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

Ou para uma [Shape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/shape/) individual:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICustomData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITagCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

### **Limitações**

Tags adicionadas através da coleção `get_CustomData()->get_Tags()` são armazenadas apenas no arquivo PowerPoint. Elas **não** são transferidas para a estrutura de tags do PDF quando a apresentação é exportada para PDF. Consequentemente, um identificador personalizado atribuído como tag não pode ser recuperado do PDF com tags.

**Solução alternativa**: Você pode armazenar um identificador personalizado no **Texto Alternativo** do objeto (por exemplo, `shape->set_AlternativeText(u"MyId")`). Após exportar para PDF, o Texto Alternativo pode aparecer na estrutura de tags do PDF.

## **FAQ**

**Posso remover todas as tags de uma apresentação, slide ou forma em uma única operação?**  
Sim. A [tag collection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/tagcollection/) suporta uma operação [Clear](https://reference.aspose.com/slides/pt/cpp/aspose.slides/tagcollection/clear/) que exclui todos os pares chave‑valor de uma vez.

**Como excluir uma única tag pelo nome sem iterar sobre toda a coleção?**  
Use [Remove(name)](https://reference.aspose.com/slides/pt/cpp/aspose.slides/tagcollection/remove/) em [TagCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/tagcollection/) para excluir a tag pela sua chave.

**Como posso recuperar a lista completa de nomes de tags para análise ou filtragem?**  
Use [GetNamesOfTags](https://reference.aspose.com/slides/pt/cpp/aspose.slides/tagcollection/getnamesoftags/) na [tag collection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/tagcollection/); ela retorna um array com todos os nomes de tags.

**Como posso encontrar todas as partes XML personalizadas, independentemente de onde estejam armazenadas?**  
Use [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/get_allcustomxmlparts/) para obter todas as partes XML personalizadas na apresentação.

**Devo usar `get_XmlAsString`/`set_XmlAsString` ou `get_XmlData`/`set_XmlData` para atualizar uma parte XML personalizada?**  
Use `get_XmlAsString` e `set_XmlAsString` quando a aplicação trabalha com texto XML UTF‑8. Use `get_XmlData` e `set_XmlData` quando o XML já está disponível como um array de bytes ou quando o processamento binário for mais conveniente. Ambas as representações referem‑se ao conteúdo XML da mesma parte XML personalizada.