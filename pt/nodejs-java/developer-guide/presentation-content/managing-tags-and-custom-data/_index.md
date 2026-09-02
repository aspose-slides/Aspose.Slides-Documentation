---
title: Gerenciar tags e dados personalizados em apresentações usando JavaScript
linktitle: Tags e Dados Personalizados
type: docs
weight: 300
url: /pt/nodejs-java/managing-tags-and-custom-data/
keywords:
- propriedades do documento
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda como gerenciar tags e dados XML personalizados em apresentações PowerPoint com Aspose.Slides para Node.js via Java, incluindo adição, leitura, atualização, auditoria e remoção de partes XML personalizadas."
---
## **Visão geral**

Este artigo explica como o Aspose.Slides trabalha com tags e dados personalizados em apresentações do PowerPoint. Dados específicos da apresentação podem ser armazenados como tags ou partes XML personalizadas. Tags são pares simples de strings chave‑valor, enquanto partes XML personalizadas podem armazenar metadados estruturados e cargas XML específicas de aplicativos.

Aspose.Slides fornece APIs para adicionar, ler, atualizar, auditar e remover partes XML personalizadas nos níveis de apresentação, slide e forma. Partes XML personalizadas são úteis para integrações que armazenam informações como identificadores de gerenciamento de documentos, estado de fluxo de trabalho, metadados de conformidade, dados de vinculação de modelo ou outros dados estruturados de aplicação dentro de uma apresentação.

## **Armazenamento de dados em arquivos de apresentação**

Arquivos PPTX — arquivos com a extensão `.pptx` — são armazenados no formato PresentationML, que faz parte da especificação Office Open XML. Office Open XML define a estrutura de pacotes e relacionamentos usados para armazenar o conteúdo da apresentação e dados relacionados.

Uma apresentação contém várias partes conectadas por relacionamentos. Por exemplo, uma parte de slide contém o conteúdo de um único slide e pode ter relacionamentos explícitos com outras partes definidos pela ISO/IEC 29500.

Dados personalizados podem ser armazenados como tags ([TagCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/tagcollection/)) ou partes XML personalizadas ([CustomXmlPartCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/customxmlpartcollection/)). Ambas estão disponíveis através da classe [`CustomData`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/customdata/).

{{% alert color="primary" %}}

Tags armazenam pares simples de string chave‑valor. Partes XML personalizadas armazenam dados XML estruturados e podem ser associadas a uma apresentação, slide ou forma.

{{% /alert %}}

## **Trabalhar com partes XML personalizadas**

O método `getCustomXmlParts()` de [`CustomData`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/customdata/) devolve a coleção de partes XML personalizadas associadas a um determinado objeto de apresentação. Por exemplo:

- `presentation.getCustomData().getCustomXmlParts()` contém partes XML personalizadas associadas à própria apresentação.
- `slide.getCustomData().getCustomXmlParts()` contém partes XML personalizadas associadas a um slide específico.
- `shape.getCustomData().getCustomXmlParts()` contém partes XML personalizadas associadas a uma forma específica.

Use [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) quando precisar inspecionar todas as partes XML personalizadas na apresentação, independentemente de onde estejam associadas.

### **Adicionar uma parte XML personalizada à apresentação**

Use o método `add` de [`CustomXmlPartCollection`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/customxmlpartcollection/) para acrescentar dados XML a uma coleção de partes XML personalizadas. O XML deve ser válido e não vazio.

O exemplo a seguir adiciona metadados estruturados à coleção de dados personalizados no nível da apresentação:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const customXmlContent =
    '<?xml version="1.0" encoding="UTF-8"?>' +
    '<metadata xmlns="urn:example:metadata">' +
        '<documentId>DOC-1001</documentId>' +
        '<workflowState>Draft</workflowState>' +
    '</metadata>';

const presentation = new aspose.slides.Presentation();
try {
    const customXmlPart = presentation.getCustomData().getCustomXmlParts().add(customXmlContent);

    // add atribui um identificador automaticamente. Defina um UUID específico apenas quando necessário.
    const itemId = java.callStaticMethodSync("java.util.UUID", "randomUUID");
    customXmlPart.setItemId(itemId);

    presentation.save("presentation_with_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O método `add` também pode aceitar XML como um array de bytes, o que é útil quando o conteúdo XML já está disponível em forma binária.

### **Adicionar uma parte XML personalizada a um slide ou forma**

Dados XML personalizados podem ser associados a um slide ou forma específico em vez de toda a apresentação. Isso é útil quando os metadados descrevem apenas um objeto, como uma chave de modelo, identificador de registro externo ou informações de vinculação.

O exemplo a seguir adiciona uma parte XML personalizada a um slide e outra a uma forma:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getCustomData().getCustomXmlParts().add(
        '<slideMetadata xmlns="urn:example:slides">' +
            '<templateKey>TitleSlide</templateKey>' +
        '</slideMetadata>');

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 250, 80);

    shape.getTextFrame().setText("Customer data");
    shape.getCustomData().getCustomXmlParts().add(
        '<shapeMetadata xmlns="urn:example:shapes">' +
            '<recordId>CRM-4281</recordId>' +
        '</shapeMetadata>');

    presentation.save("object_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O nível em que a parte é adicionada determina qual coleção `getCustomData().getCustomXmlParts()` do objeto contém o relacionamento com essa parte. Dados no nível da apresentação são adequados para metadados de todo o documento, dados no nível do slide para informações que pertencem a um slide específico e dados no nível da forma para metadados vinculados a uma forma individual.

### **Listar e auditar todas as partes XML personalizadas**

Use [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) para recuperar todas as partes XML personalizadas de uma apresentação. Cada [`CustomXmlPart`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/customxmlpart/) expõe seu identificador, conteúdo XML e esquemas de namespace associados.

O exemplo a seguir lista todas as partes XML personalizadas e seus esquemas de namespace:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getAllCustomXmlParts();

    for (let partIndex = 0; partIndex < customXmlParts.length; partIndex++) {
        const customXmlPart = customXmlParts[partIndex];

        console.log("ItemId: " + customXmlPart.getItemId());
        console.log("XML:");
        console.log(customXmlPart.getXmlAsString());

        const namespaceSchemas = customXmlPart.getNamespaceSchemas();
        for (let schemaIndex = 0; schemaIndex < namespaceSchemas.length; schemaIndex++) {
            console.log("Namespace schema: " + namespaceSchemas[schemaIndex]);
        }

        console.log();
    }
} finally {
    presentation.dispose();
}
```

[`CustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/customxmlpart/) devolve os esquemas XML associados à parte XML personalizada. Essa informação pode ser útil ao auditar apresentações que contêm XML produzido por sistemas externos.

### **Ler e atualizar conteúdo XML e ItemId**

Use `getXmlAsString()` e `setXmlAsString()` de [`CustomXmlPart`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/customxmlpart/) para trabalhar com XML como string UTF‑8, ou `getXmlData()` e `setXmlData()` para trabalhar com os bytes brutos do XML.

O método `getItemId()` devolve o UUID que identifica a parte XML personalizada no documento Office Open XML. Use `setItemId()` quando uma integração requer um novo identificador.

O exemplo a seguir atualiza o conteúdo XML e o identificador:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlPart = presentation.getAllCustomXmlParts()[0];

    // Leia o XML atual como texto.
    const currentXmlContent = customXmlPart.getXmlAsString();
    console.log(currentXmlContent);

    // Atualize o XML como uma string UTF-8.
    customXmlPart.setXmlAsString(
        '<metadata xmlns="urn:example:metadata">' +
            '<documentId>DOC-1001</documentId>' +
            '<workflowState>Approved</workflowState>' +
        '</metadata>');

    // getXmlData fornece o mesmo conteúdo XML como bytes brutos.
    const customXmlData = customXmlPart.getXmlData();
    console.log(Buffer.from(customXmlData).toString("utf8"));

    // Substitua o identificador quando necessário pela integração.
    const itemId = java.callStaticMethodSync("java.util.UUID", "randomUUID");
    customXmlPart.setItemId(itemId);

    presentation.save("updated_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ao chamar `setXmlAsString` ou `setXmlData`, forneça XML válido e não vazio. Use uma representação ou outra dependendo se a aplicação trabalha principalmente com strings ou com dados binários.

### **Remover uma parte XML personalizada**

Aspose.Slides oferece várias maneiras de remover dados XML personalizados:

- [`CustomXmlPart.remove`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/customxmlpart/) remove a parte XML personalizada da apresentação.
- [`CustomXmlPartCollection.remove`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/customxmlpartcollection/) remove uma parte específica de uma coleção de partes XML personalizadas.
- [`CustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/customxmlpartcollection/) remove a parte no índice especificado da coleção.
- [`CustomXmlPartCollection.clear`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/customxmlpartcollection/) remove todas as partes de uma coleção específica.

O exemplo a seguir remove uma parte XML personalizada no nível da apresentação por referência:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getCustomData().getCustomXmlParts();

    if (customXmlParts.size() > 0) {
        const customXmlPart = customXmlParts.get_Item(0);
        customXmlParts.remove(customXmlPart);
    }

    presentation.save("custom_xml_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Se já possuir um `CustomXmlPart` e quiser remover essa parte da apresentação em vez de endereçar uma coleção específica, chame `customXmlPart.remove()`.

Você também pode remover um item por índice:

```javascript
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **Limpar todas as partes XML personalizadas de uma coleção**

Use `clear` quando todas as partes XML personalizadas associadas a um determinado objeto de apresentação precisarem ser removidas.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear();

    presentation.save("slide_custom_xml_cleared.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`clear` afeta apenas a coleção selecionada. Por exemplo, limpar a coleção de um slide não limpa as coleções no nível da apresentação ou da forma.

Para remover todas as partes XML personalizadas da apresentação, itere sobre `getAllCustomXmlParts()` e remova cada parte:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getAllCustomXmlParts();

    for (let partIndex = 0; partIndex < customXmlParts.length; partIndex++) {
        customXmlParts[partIndex].remove();
    }

    presentation.save("all_custom_xml_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Manipular partes XML personalizadas vinculadas ou compartilhadas**

Em uma apresentação Office Open XML, a mesma parte XML personalizada pode ser referenciada a partir de mais de um objeto da apresentação. Por exemplo, um arquivo existente pode conter relacionamentos de vários slides ou formas para a mesma parte XML subjacente.

Uma parte compartilhada deve ser tratada como um único objeto de dados com múltiplas referências:

- Atualizá‑la com `setXmlAsString`, `setXmlData` ou `setItemId` altera a parte XML subjacente, de modo que a mudança se aplica onde quer que a parte seja referenciada.
- `getItemId()` pode ser usado para identificar a mesma parte XML personalizada ao auditar coleções ao nível do objeto.
- Remover uma parte de uma coleção `getCustomXmlParts()` específica a remove dessa coleção. Use `CustomXmlPart.remove()` quando a própria parte deve ser removida da apresentação.
- Antes de excluir ou substituir uma parte compartilhada, inspecione as coleções ao nível do objeto para determinar se outros slides ou formas ainda a referenciam.

As sobrecargas do `add` criam uma nova parte XML personalizada a partir de conteúdo XML; elas não aceitam um `CustomXmlPart` existente. Portanto, relacionamentos compartilhados são mais comuns ao carregar apresentações que já os contêm.

O exemplo a seguir audita coleções no nível da apresentação, slide e forma por `ItemId` e relata partes referenciadas a partir de mais de um local:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const referencesByItemId = new Map();

    const registerCustomXmlParts = (ownerName, customXmlParts) => {
        for (let partIndex = 0; partIndex < customXmlParts.size(); partIndex++) {
            const customXmlPart = customXmlParts.get_Item(partIndex);
            const itemId = customXmlPart.getItemId().toString();

            if (!referencesByItemId.has(itemId)) {
                referencesByItemId.set(itemId, []);
            }

            referencesByItemId.get(itemId).push(ownerName);
        }
    };

    registerCustomXmlParts("Presentation", presentation.getCustomData().getCustomXmlParts());

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);

        registerCustomXmlParts("Slide " + (slideIndex + 1), slide.getCustomData().getCustomXmlParts());

        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);

            registerCustomXmlParts("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.getCustomData().getCustomXmlParts());
        }
    }

    for (const [itemId, owners] of referencesByItemId) {
        if (owners.length > 1) {
            console.log("Shared custom XML part: " + itemId);

            for (const ownerName of owners) {
                console.log("  Referenced by: " + ownerName);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Esse tipo de auditoria é útil antes de modificar ou excluir dados XML personalizados em apresentações criadas por sistemas externos, pois a mesma parte de metadados pode participar de mais de um relacionamento.

## **Obter valores de tags**

Em slides, uma tag corresponde ao método `DocumentProperties.getKeywords()`. Este código de exemplo mostra como obter o valor de uma tag com Aspose.Slides for Node.js via Java para [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **Adicionar tags a apresentações**

Aspose.Slides permite adicionar tags a apresentações. Uma tag normalmente consiste em dois itens:

- o nome de uma propriedade personalizada, por exemplo, `MyTag`;
- o valor da propriedade personalizada, por exemplo, `My Tag Value`.

Se precisar classificar apresentações com base em uma regra ou propriedade específica, pode adicionar tags para esse fim. Por exemplo, se desejar categorizar apresentações de países da América do Norte, pode criar uma tag “NorthAmerican” e atribuir o país relevante como seu valor.

Este código de exemplo mostra como adicionar uma tag a uma [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) usando Aspose.Slides for Node.js via Java:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const tags = presentation.getCustomData().getTags();
    tags.set_Item("MyTag", "My Tag Value");
} finally {
    presentation.dispose();
}
```

Tags também podem ser definidas para um [Slide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slide/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

Ou para uma [Shape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/) individual:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 50);

    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

### **Limitações**

Tags adicionadas através da coleção `getCustomData().getTags()` são armazenadas apenas no arquivo PowerPoint. Elas **não** são transferidas para a estrutura de tags PDF quando a apresentação é exportada para PDF. Consequentemente, um identificador personalizado atribuído como tag não pode ser recuperado do PDF marcado.

**Solução alternativa**: você pode armazenar um identificador personalizado no **Alt Text** do objeto (por exemplo, `shape.setAlternativeText("MyId")`). Após a exportação para PDF, o Alt Text pode aparecer na estrutura de tags do PDF.

## **FAQ**

**Posso remover todas as tags de uma apresentação, slide ou forma em uma única operação?**

Sim. A [coleção de tags](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/tagcollection/) oferece uma operação [clear](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/tagcollection/) que exclui todos os pares chave‑valor de uma vez.

**Como excluir uma única tag pelo nome sem iterar sobre toda a coleção?**

Use `remove(name)` na [coleção de tags](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/tagcollection/) para deletar a tag pela sua chave.

**Como recuperar a lista completa de nomes de tags para análise ou filtragem?**

Use `getNamesOfTags()` na [coleção de tags](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/tagcollection/); ela retorna um array com todos os nomes de tags.

**Como encontrar todas as partes XML personalizadas independentemente de onde estejam armazenadas?**

Use [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) para recuperar todas as partes XML personalizadas na apresentação.

**Devo usar `getXmlAsString`/`setXmlAsString` ou `getXmlData`/`setXmlData` para atualizar uma parte XML personalizada?**

Use `getXmlAsString` e `setXmlAsString` quando a aplicação trabalha com texto XML UTF‑8. Use `getXmlData` e `setXmlData` quando o XML já está disponível como array de bytes ou quando o processamento binário for mais conveniente. Ambas as representações referem‑se ao conteúdo XML da mesma parte XML personalizada.