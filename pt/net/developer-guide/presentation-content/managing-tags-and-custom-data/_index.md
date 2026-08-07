---
title: Gerenciar Tags e Dados Personalizados em Apresentações no .NET
linktitle: Tags e Dados Personalizados
type: docs
weight: 300
url: /pt/net/managing-tags-and-custom-data/
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
- .NET
- C#
- Aspose.Slides
description: "Saiba como gerenciar tags e dados XML personalizados em apresentações PowerPoint com Aspose.Slides para .NET, incluindo adição, leitura, atualização, auditoria e remoção de partes XML personalizadas."
---
## **Visão geral**

Este artigo explica como o Aspose.Slides trabalha com tags e dados personalizados em apresentações do PowerPoint. Dados específicos da apresentação podem ser armazenados como tags ou partes XML personalizadas. Tags são pares simples de string chave‑valor, enquanto partes XML personalizadas podem armazenar metadados estruturados e cargas úteis XML específicas da aplicação.

O Aspose.Slides fornece APIs para adicionar, ler, atualizar, auditar e remover partes XML personalizadas nos níveis de apresentação, slide e forma. Partes XML personalizadas são úteis para integrações que armazenam informações como identificadores de gerenciamento de documentos, estado de fluxo de trabalho, metadados de conformidade, dados de vinculação de modelo ou outros dados de aplicação estruturados dentro de uma apresentação.

## **Armazenamento de Dados em Arquivos de Apresentação**

Arquivos PPTX — arquivos com a extensão `.pptx` — são armazenados no formato PresentationML, que faz parte da especificação Office Open XML. O Office Open XML define a estrutura de pacotes e relacionamentos usados para armazenar o conteúdo da apresentação e os dados relacionados.

Uma apresentação contém várias partes conectadas por relacionamentos. Por exemplo, uma parte de slide contém o conteúdo de um único slide e pode ter relacionamentos explícitos com outras partes definidos pela ISO/IEC 29500.

Dados personalizados podem ser armazenados como tags ([ITagCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/itagcollection)) ou partes XML personalizadas ([ICustomXmlPartCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/icustomxmlpartcollection)). Ambas estão disponíveis através da interface [`ICustomData`](https://reference.aspose.com/slides/pt/net/aspose.slides/icustomdata/) .

{{% alert color="primary" %}}

Tags armazenam pares simples de string chave‑valor. Partes XML personalizadas armazenam dados XML estruturados e podem ser associadas a uma apresentação, slide ou forma.

{{% /alert %}}

## **Trabalhar com Partes XML Personalizadas**

A propriedade [`ICustomData.CustomXmlParts`](https://reference.aspose.com/slides/pt/net/aspose.slides/icustomdata/customxmlparts/) devolve a coleção de partes XML personalizadas associadas a um determinado objeto de apresentação. Por exemplo:

- `presentation.CustomData.CustomXmlParts` contém partes XML personalizadas associadas à própria apresentação.
- `slide.CustomData.CustomXmlParts` contém partes XML personalizadas associadas a um slide específico.
- `shape.CustomData.CustomXmlParts` contém partes XML personalizadas associadas a uma forma específica.

Use [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/allcustomxmlparts/) quando precisar inspecionar todas as partes XML personalizadas na apresentação, independentemente de onde estejam associadas.

### **Adicionar uma Parte XML Personalizada a uma Apresentação**

Use [`ICustomXmlPartCollection.Add`](https://reference.aspose.com/slides/pt/net/aspose.slides/icustomxmlpartcollection/add/) para adicionar dados XML a uma coleção de partes XML personalizadas. O XML deve ser válido e não vazio.

O exemplo a seguir adiciona metadados estruturados à coleção de dados personalizados no nível da apresentação:

```csharp
using System;
using Aspose.Slides;

var customXmlContent =
    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Draft</workflowState>" +
    "</metadata>";

using var presentation = new Presentation();
var customXmlPart = presentation.CustomData.CustomXmlParts.Add(customXmlContent);

// Add atribui um identificador automaticamente. Defina um GUID específico apenas quando necessário.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
```

O método `Add` também pode aceitar XML como um array de bytes ou fluxo, o que é útil quando o conteúdo XML já está disponível em forma binária.

### **Adicionar uma Parte XML Personalizada a um Slide ou Forma**

Dados XML personalizados podem ser associados a um slide específico ou a uma forma em vez de toda a apresentação. Isso é útil quando os metadados descrevem apenas um objeto, como uma chave de modelo, identificador de registro externo ou informação de vínculo.

O exemplo a seguir adiciona uma parte XML personalizada a um slide e outra a uma forma:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.CustomData.CustomXmlParts.Add(
    "<slideMetadata xmlns=\"urn:example:slides\">" +
        "<templateKey>TitleSlide</templateKey>" +
    "</slideMetadata>");

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 250, 80);

shape.TextFrame.Text = "Customer data";
shape.CustomData.CustomXmlParts.Add(
    "<shapeMetadata xmlns=\"urn:example:shapes\">" +
        "<recordId>CRM-4281</recordId>" +
    "</shapeMetadata>");

presentation.Save("object_custom_xml.pptx", SaveFormat.Pptx);
```

O nível em que a parte é adicionada determina qual coleção `CustomData.CustomXmlParts` do objeto contém o relacionamento com essa parte. Dados no nível da apresentação são adequados para metadados de todo o documento, dados no nível do slide para informações que pertencem a um slide específico e dados no nível da forma para metadados vinculados a uma forma individual.

### **Listar e Auditar Todas as Partes XML Personalizadas**

Use [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/allcustomxmlparts/) para recuperar todas as partes XML personalizadas de uma apresentação. Cada [`ICustomXmlPart`](https://reference.aspose.com/slides/pt/net/aspose.slides/icustomxmlpart/) expõe seu identificador, conteúdo XML e esquemas de namespace associados.

O exemplo a seguir lista todas as partes XML personalizadas e seus esquemas de namespace:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    Console.WriteLine("ItemId: " + customXmlPart.ItemId);
    Console.WriteLine("XML:");
    Console.WriteLine(customXmlPart.XmlAsString);

    foreach (var namespaceSchema in customXmlPart.NamespaceSchemas)
    {
        Console.WriteLine("Namespace schema: " + namespaceSchema);
    }

    Console.WriteLine();
}
```

[`ICustomXmlPart.NamespaceSchemas`](https://reference.aspose.com/slides/pt/net/aspose.slides/icustomxmlpart/namespaceschemas/) devolve os esquemas XML associados à parte XML personalizada. Essas informações podem ser úteis ao auditar apresentações que contêm XML produzido por sistemas externos.

### **Ler e Atualizar o Conteúdo XML e o ItemId**

Use [`ICustomXmlPart.XmlAsString`](https://reference.aspose.com/slides/pt/net/aspose.slides/icustomxmlpart/xmlasstring/) para trabalhar com XML como uma string UTF‑8, ou [`ICustomXmlPart.XmlData`](https://reference.aspose.com/slides/pt/net/aspose.slides/icustomxmlpart/xmldata/) para trabalhar com os bytes brutos do XML. Ambas as propriedades podem ser lidas e atualizadas.

A propriedade [`ICustomXmlPart.ItemId`](https://reference.aspose.com/slides/pt/net/aspose.slides/icustomxmlpart/itemid/) contém o GUID que identifica a parte XML personalizada no documento Office Open XML. Ele também pode ser alterado quando uma integração requer um novo identificador.

O exemplo a seguir atualiza o conteúdo XML e o identificador:

```csharp
using System;
using System.Text;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var customXmlPart = presentation.AllCustomXmlParts[0];

// Leia o XML atual como texto.
var currentXmlContent = customXmlPart.XmlAsString;
Console.WriteLine(currentXmlContent);

// Atualize o XML como uma string UTF-8.
customXmlPart.XmlAsString =
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Approved</workflowState>" +
    "</metadata>";

// XmlData fornece o mesmo conteúdo XML como bytes brutos.
var customXmlData = customXmlPart.XmlData;
Console.WriteLine(Encoding.UTF8.GetString(customXmlData));

// Substitua o identificador quando exigido pela integração.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("updated_custom_xml.pptx", SaveFormat.Pptx);
```

Ao atribuir `XmlAsString` ou `XmlData`, forneça XML válido e não vazio. Use uma representação ou outra dependendo se a aplicação trabalha principalmente com strings ou com dados binários.

### **Remover uma Parte XML Personalizada**

O Aspose.Slides oferece várias maneiras de remover dados XML personalizados:

- [`ICustomXmlPart.Remove`](https://reference.aspose.com/slides/pt/net/aspose.slides/icustomxmlpart/remove/) remove a parte XML personalizada da apresentação.
- [`ICustomXmlPartCollection.Remove`](https://reference.aspose.com/slides/pt/net/aspose.slides/icustomxmlpartcollection/remove/) remove uma parte específica de uma coleção de partes XML personalizadas.
- [`ICustomXmlPartCollection.RemoveAt`](https://reference.aspose.com/slides/pt/net/aspose.slides/icustomxmlpartcollection/removeat/) remove a parte no índice especificado da coleção.
- [`ICustomXmlPartCollection.Clear`](https://reference.aspose.com/slides/pt/net/aspose.slides/icustomxmlpartcollection/clear/) remove todas as partes de uma coleção específica.

O exemplo a seguir remove uma parte XML personalizada no nível da apresentação por referência:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var customXmlParts = presentation.CustomData.CustomXmlParts;

if (customXmlParts.Count > 0)
{
    var customXmlPart = customXmlParts[0];
    customXmlParts.Remove(customXmlPart);
}

presentation.Save("custom_xml_removed.pptx", SaveFormat.Pptx);
```

Se já possui um `ICustomXmlPart` e deseja remover essa parte da apresentação em vez de endereçar uma coleção específica, chame `customXmlPart.Remove()`.

Você também pode remover um item por índice:

```csharp
presentation.CustomData.CustomXmlParts.RemoveAt(0);
```

### **Limpar Todas as Partes XML Personalizadas de uma Coleção**

Use `Clear` quando todas as partes XML personalizadas associadas a um determinado objeto de apresentação devem ser removidas.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
presentation.Slides[0].CustomData.CustomXmlParts.Clear();

presentation.Save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
```

`Clear` afeta apenas a coleção selecionada. Por exemplo, limpar a coleção de um slide não limpa as coleções no nível da apresentação ou da forma.

Para remover cada parte XML personalizada na apresentação, itere por `AllCustomXmlParts` e remova cada parte:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    customXmlPart.Remove();
}

presentation.Save("all_custom_xml_removed.pptx", SaveFormat.Pptx);
```

### **Manipular Partes XML Personalizadas Vinculadas ou Compartilhadas**

Em uma apresentação Office Open XML, a mesma parte XML personalizada pode ser referenciada por mais de um objeto da apresentação. Por exemplo, um arquivo existente pode conter relacionamentos de vários slides ou formas para a mesma parte XML subjacente.

Uma parte compartilhada deve ser tratada como um único objeto de dados com múltiplas referências:

- Atualizar seu `XmlAsString`, `XmlData` ou `ItemId` altera a parte XML subjacente, de modo que a mudança se aplique onde quer que a parte seja referenciada.
- `ItemId` pode ser usado para identificar a mesma parte XML personalizada ao auditar coleções ao nível do objeto.
- Remover uma parte de uma coleção `CustomXmlParts` específica a remove apenas dessa coleção. Use `ICustomXmlPart.Remove()` quando a própria parte deve ser removida da apresentação.
- Antes de excluir ou substituir uma parte compartilhada, inspecione as coleções ao nível do objeto para determinar se outros slides ou formas ainda a referenciam.

As sobrecargas de `Add` criam uma nova parte XML personalizada a partir do conteúdo XML; elas não aceitam um `ICustomXmlPart` já existente. Portanto, relacionamentos compartilhados são mais frequentemente encontrados ao carregar apresentações que já os contêm.

O exemplo a seguir audita as coleções nos níveis de apresentação, slide e forma pelo `ItemId` e relata partes referenciadas a partir de mais de um local:

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var referencesByItemId = new Dictionary<Guid, List<string>>();

var registerCustomXmlParts = (string ownerName, ICustomXmlPartCollection customXmlParts) =>
    {
        foreach (var customXmlPart in customXmlParts)
        {
            if (!referencesByItemId.ContainsKey(customXmlPart.ItemId))
            {
                referencesByItemId[customXmlPart.ItemId] = new List<string>();
            }

            referencesByItemId[customXmlPart.ItemId].Add(ownerName);
        }
    };

registerCustomXmlParts("Presentation", presentation.CustomData.CustomXmlParts);

for (var slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];
    registerCustomXmlParts("Slide " + (slideIndex + 1), slide.CustomData.CustomXmlParts);

    for (var shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
    {
        var shape = slide.Shapes[shapeIndex];
        registerCustomXmlParts("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.CustomData.CustomXmlParts);
    }
}

foreach (var referenceEntry in referencesByItemId)
{
    if (referenceEntry.Value.Count > 1)
    {
        Console.WriteLine("Shared custom XML part: " + referenceEntry.Key);

        foreach (var ownerName in referenceEntry.Value)
        {
            Console.WriteLine("  Referenced by: " + ownerName);
        }
    }
}
```

Esse tipo de auditoria é útil antes de modificar ou excluir dados XML personalizados em apresentações criadas por sistemas externos, porque a mesma parte de metadados pode participar de mais de um relacionamento.

## **Obter Valores de Tags**

Em slides, uma tag corresponde à propriedade `IDocumentProperties.Keywords`. Este código de exemplo mostra como obter o valor de uma tag com Aspose.Slides para .NET para [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation):

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var keywords = presentation.DocumentProperties.Keywords;
```

## **Adicionar Tags a Apresentações**

O Aspose.Slides permite adicionar tags a apresentações. Uma tag normalmente consiste em dois itens:

- o nome de uma propriedade personalizada, por exemplo, `MyTag`;
- o valor da propriedade personalizada, por exemplo, `My Tag Value`.

Se precisar classificar apresentações com base em uma regra ou propriedade específica, pode adicionar tags para esse fim. Por exemplo, se quiser categorizar apresentações de países da América do Norte, pode criar uma tag “NorthAmerican” e atribuir o país relevante como seu valor.

Este código de exemplo mostra como adicionar uma tag a uma [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) usando Aspose.Slides para .NET:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var tags = presentation.CustomData.Tags;
tags["MyTag"] = "My Tag Value";
```

Tags também podem ser definidas para um [Slide](https://reference.aspose.com/slides/pt/net/aspose.slides/slide):

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
slide.CustomData.Tags["tag"] = "value";
```

Ou para uma [Shape](https://reference.aspose.com/slides/pt/net/aspose.slides/shape) individual:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
shape.TextFrame.Text = "My text";
shape.CustomData.Tags["tag"] = "value";
```

### **Limitações**

Tags adicionadas através da coleção `CustomData.Tags` são armazenadas apenas no arquivo PowerPoint. Elas **não** são transferidas para a estrutura de tags PDF quando a apresentação é exportada para PDF. Consequentemente, um identificador personalizado atribuído como tag não pode ser recuperado a partir do PDF tagueado.

**Solução alternativa**: você pode armazenar um identificador personalizado no **Texto Alternativo** do objeto (por exemplo, `shape.AlternativeText = "MyId"`). Após a exportação para PDF, o Texto Alternativo pode aparecer na estrutura de tags do PDF.

## **Perguntas Frequentes**

**Posso remover todas as tags de uma apresentação, slide ou forma em uma única operação?**

Sim. A [coleção de tags](https://reference.aspose.com/slides/pt/net/aspose.slides/tagcollection/) suporta uma operação [Clear](https://reference.aspose.com/slides/pt/net/aspose.slides/tagcollection/clear/) que exclui todos os pares chave‑valor de uma vez.

**Como excluir uma única tag pelo seu nome sem iterar sobre toda a coleção?**

Use [Remove(name)](https://reference.aspose.com/slides/pt/net/aspose.slides/tagcollection/remove/) em [TagCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/tagcollection/) para excluir a tag pela sua chave.

**Como recuperar a lista completa de nomes de tags para análise ou filtragem?**

Use [GetNamesOfTags](https://reference.aspose.com/slides/pt/net/aspose.slides/tagcollection/getnamesoftags/) na [coleção de tags](https://reference.aspose.com/slides/pt/net/aspose.slides/tagcollection/); ela devolve um array com todos os nomes de tags.

**Como encontrar todas as partes XML personalizadas independentemente de onde estejam armazenadas?**

Use [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/allcustomxmlparts/) para recuperar todas as partes XML personalizadas na apresentação.

**Devo usar `XmlAsString` ou `XmlData` para atualizar uma parte XML personalizada?**

Use `XmlAsString` quando a aplicação trabalha com texto XML UTF‑8. Use `XmlData` quando o XML já está disponível como um array de bytes ou quando o processamento orientado a binário for mais conveniente. Ambas as propriedades representam o conteúdo XML da mesma parte XML personalizada.