---
title: Gerenciar tags e dados personalizados em apresentações usando Java
linktitle: Tags e Dados Personalizados
type: docs
weight: 300
url: /pt/java/managing-tags-and-custom-data/
keywords:
- propriedades de documento
- tag
- dados personalizados
- XML personalizado
- parte XML personalizada
- metadados XML
- ItemId
- adicionar tag
- valores de par
- PowerPoint
- apresentação
- Java
- Aspose.Slides
description: "Aprenda como gerenciar tags e dados XML personalizados em apresentações PowerPoint com Aspose.Slides para Java, incluindo adição, leitura, atualização, auditoria e remoção de partes XML personalizadas."
---
## **Visão geral**

Este artigo explica como o Aspose.Slides trabalha com tags e dados personalizados em apresentações do PowerPoint. Dados específicos da apresentação podem ser armazenados como tags ou partes XML personalizadas. Tags são pares simples de string chave‑valor, enquanto partes XML personalizadas podem armazenar metadados estruturados e cargas úteis XML específicas da aplicação.

O Aspose.Slides fornece APIs para adicionar, ler, atualizar, auditar e remover partes XML personalizadas nos níveis de apresentação, slide e forma. Partes XML personalizadas são úteis para integrações que armazenam informações como identificadores de gerenciamento de documentos, estado de fluxo de trabalho, metadados de conformidade, dados de vinculação de modelo ou outros dados de aplicação estruturados dentro de uma apresentação.

## **Armazenamento de Dados em Arquivos de Apresentação**

Arquivos PPTX — arquivos com a extensão `.pptx` — são armazenados no formato PresentationML, que faz parte da especificação Office Open XML. Office Open XML define a estrutura de pacotes e relacionamentos usados para armazenar o conteúdo da apresentação e os dados relacionados.

Uma apresentação contém várias partes conectadas por relacionamentos. Por exemplo, uma parte de slide contém o conteúdo de um único slide e pode ter relacionamentos explícitos com outras partes definidos pela ISO/IEC 29500.

Dados personalizados podem ser armazenados como tags ([ITagCollection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ITagCollection)) ou partes XML personalizadas ([ICustomXmlPartCollection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ICustomXmlPartCollection)). Ambos estão disponíveis através da interface [`ICustomData`](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ICustomData/) .

{{% alert color="primary" %}}
Tags armazenam pares simples de string chave‑valor. Partes XML personalizadas armazenam dados XML estruturados e podem ser associadas a uma apresentação, slide ou forma.
{{% /alert %}}

## **Trabalhar com Partes XML Personalizadas**

O método [`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ICustomData#getCustomXmlParts--) retorna a coleção de partes XML personalizadas associadas a um determinado objeto de apresentação. Por exemplo:

- `presentation.getCustomData().getCustomXmlParts()` contém partes XML personalizadas associadas à própria apresentação.
- `slide.getCustomData().getCustomXmlParts()` contém partes XML personalizadas associadas a um slide específico.
- `shape.getCustomData().getCustomXmlParts()` contém partes XML personalizadas associadas a uma forma específica.

Use [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) quando precisar inspecionar todas as partes XML personalizadas na apresentação, independentemente de onde estejam associadas.

### **Adicionar uma Parte XML Personalizada a uma Apresentação**

Use [`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) para adicionar dados XML a uma coleção de partes XML personalizadas. O XML deve ser válido e não vazio.

O exemplo a seguir adiciona metadados estruturados à coleção de dados personalizados no nível da apresentação:

```java
import com.aspose.slides.*;
import java.util.UUID;

String customXmlContent =
    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Draft</workflowState>" +
    "</metadata>";

Presentation presentation = new Presentation();
try {
    ICustomXmlPart customXmlPart = presentation.getCustomData().getCustomXmlParts().add(customXmlContent);

    // add atribui um identificador automaticamente. Defina um UUID específico apenas quando necessário.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O método `add` também pode aceitar XML como um array de bytes ou fluxo de entrada, o que é útil quando o conteúdo XML já está disponível em forma binária.

### **Adicionar uma Parte XML Personalizada a um Slide ou Forma**

Dados XML personalizados podem ser associados a um slide ou forma específicos em vez de toda a apresentação. Isso é útil quando os metadados descrevem apenas um objeto, como uma chave de modelo, identificador de registro externo ou informações de vinculação.

O exemplo a seguir adiciona uma parte XML personalizada a um slide e outra a uma forma:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getCustomData().getCustomXmlParts().add(
        "<slideMetadata xmlns=\"urn:example:slides\">" +
            "<templateKey>TitleSlide</templateKey>" +
        "</slideMetadata>");

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 250, 80);

    shape.getTextFrame().setText("Customer data");
    shape.getCustomData().getCustomXmlParts().add(
        "<shapeMetadata xmlns=\"urn:example:shapes\">" +
            "<recordId>CRM-4281</recordId>" +
        "</shapeMetadata>");

    presentation.save("object_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O nível em que uma parte é adicionada determina qual coleção `getCustomData().getCustomXmlParts()` do objeto contém o relacionamento com essa parte. Dados no nível da apresentação são adequados para metadados de todo o documento, dados no nível do slide para informações que pertencem a um slide específico e dados no nível da forma para metadados vinculados a uma forma individual.

### **Listar e Auditar Todas as Partes XML Personalizadas**

Use [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) para recuperar todas as partes XML personalizadas de uma apresentação. Cada [`ICustomXmlPart`](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ICustomXmlPart/) expõe seu identificador, conteúdo XML e esquemas de namespace associados.

O exemplo a seguir lista todas as partes XML personalizadas e seus esquemas de namespace:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ICustomXmlPart customXmlPart : presentation.getAllCustomXmlParts()) {
        System.out.println("ItemId: " + customXmlPart.getItemId());
        System.out.println("XML:");
        System.out.println(customXmlPart.getXmlAsString());

        for (String namespaceSchema : customXmlPart.getNamespaceSchemas()) {
            System.out.println("Namespace schema: " + namespaceSchema);
        }

        System.out.println();
    }
} finally {
    presentation.dispose();
}
```

`ICustomXmlPart.getNamespaceSchemas()` retorna os esquemas XML associados à parte XML personalizada. Essa informação pode ser útil ao auditar apresentações que contêm XML produzido por sistemas externos.

### **Ler e Atualizar o Conteúdo XML e ItemId**

Use [`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ICustomXmlPart#getXmlAsString--) e [`setXmlAsString()`](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) para trabalhar com XML como uma string UTF-8, ou [`getXmlData()`](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ICustomXmlPart#getXmlData--) e [`setXmlData()`](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) para trabalhar com os bytes brutos do XML.

O método [`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ICustomXmlPart#getItemId--) retorna o UUID que identifica a parte XML personalizada no documento Office Open XML. Use [`setItemId()`](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-) quando uma integração requer um novo identificador.

O exemplo a seguir atualiza o conteúdo XML e o identificador:

```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.util.UUID;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ICustomXmlPart customXmlPart = presentation.getAllCustomXmlParts()[0];

    // Ler o XML atual como texto.
    String currentXmlContent = customXmlPart.getXmlAsString();
    System.out.println(currentXmlContent);

    // Atualizar o XML como uma string UTF-8.
    customXmlPart.setXmlAsString(
        "<metadata xmlns=\"urn:example:metadata\">" +
            "<documentId>DOC-1001</documentId>" +
            "<workflowState>Approved</workflowState>" +
        "</metadata>");

    // getXmlData fornece o mesmo conteúdo XML como bytes brutos.
    byte[] customXmlData = customXmlPart.getXmlData();
    System.out.println(new String(customXmlData, StandardCharsets.UTF_8));

    // Substituir o identificador quando exigido pela integração.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ao chamar `setXmlAsString` ou `setXmlData`, forneça XML válido e não vazio. Use uma representação ou outra dependendo se a aplicação trabalha principalmente com strings ou com dados em bytes.

### **Remover uma Parte XML Personalizada**

O Aspose.Slides fornece várias maneiras de remover dados XML personalizados:

- `ICustomXmlPart.remove` remove a parte XML personalizada da apresentação.
- `ICustomXmlPartCollection.remove` remove uma parte específica de uma coleção de partes XML personalizadas.
- `ICustomXmlPartCollection.removeAt` remove a parte em um índice especificado da coleção.
- `ICustomXmlPartCollection.clear` remove todas as partes de uma coleção específica.

O exemplo a seguir remove uma parte XML personalizada no nível da apresentação por referência:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ICustomXmlPartCollection customXmlParts = presentation.getCustomData().getCustomXmlParts();

    if (customXmlParts.size() > 0) {
        ICustomXmlPart customXmlPart = customXmlParts.get_Item(0);
        customXmlParts.remove(customXmlPart);
    }

    presentation.save("custom_xml_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Se você já possui um `ICustomXmlPart` e deseja remover essa parte da apresentação em vez de direcionar uma coleção específica, chame `customXmlPart.remove()`.

Você também pode remover um item por índice:

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **Limpar Todas as Partes XML Personalizadas de uma Coleção**

Use `clear` quando todas as partes XML personalizadas associadas a um determinado objeto de apresentação devem ser removidas.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear();

    presentation.save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`clear` afeta apenas a coleção selecionada. Por exemplo, limpar a coleção de um slide não limpa as coleções no nível da apresentação ou da forma.

Para remover todas as partes XML personalizadas na apresentação, itere através de `getAllCustomXmlParts()` e remova cada parte:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ICustomXmlPart customXmlPart : presentation.getAllCustomXmlParts()) {
        customXmlPart.remove();
    }

    presentation.save("all_custom_xml_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Manipular Partes XML Personalizadas Vinculadas ou Compartilhadas**

Em uma apresentação Office Open XML, a mesma parte XML personalizada pode ser referenciada por mais de um objeto da apresentação. Por exemplo, um arquivo existente pode conter relacionamentos de múltiplos slides ou formas para a mesma parte XML personalizada subjacente.

Uma parte compartilhada deve ser tratada como um único objeto de dados com múltiplas referências:

- Atualizá‑la com `setXmlAsString`, `setXmlData` ou `setItemId` altera a parte XML personalizada subjacente, de modo que a alteração se aplica onde quer que essa parte seja referenciada.
- `getItemId()` pode ser usado para identificar a mesma parte XML personalizada ao auditar coleções em nível de objeto.
- Remover uma parte de uma coleção específica `getCustomXmlParts()` remove-a dessa coleção. Use `ICustomXmlPart.remove()` quando a própria parte deve ser removida da apresentação.
- Antes de excluir ou substituir uma parte compartilhada, inspeção as coleções em nível de objeto para determinar se outros slides ou formas ainda a referenciam.

As sobrecargas de `add` criam uma nova parte XML personalizada a partir do conteúdo XML; elas não aceitam um `ICustomXmlPart` existente. Portanto, relacionamentos compartilhados são mais frequentemente encontrados ao carregar apresentações que já os contêm.

O exemplo a seguir audita as coleções nos níveis de apresentação, slide e forma por `ItemId` e relata partes referenciadas a partir de mais de um local:

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.UUID;
import java.util.function.BiConsumer;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Map<UUID, List<String>> referencesByItemId = new HashMap<>();

    BiConsumer<String, ICustomXmlPartCollection> registerCustomXmlParts =
        (ownerName, customXmlParts) -> {
            for (int i = 0; i < customXmlParts.size(); i++) {
                ICustomXmlPart customXmlPart = customXmlParts.get_Item(i);
                UUID itemId = customXmlPart.getItemId();

                if (!referencesByItemId.containsKey(itemId)) {
                    referencesByItemId.put(itemId, new ArrayList<>());
                }

                referencesByItemId.get(itemId).add(ownerName);
            }
        };

    registerCustomXmlParts.accept("Presentation", presentation.getCustomData().getCustomXmlParts());

    for (int slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        registerCustomXmlParts.accept("Slide " + (slideIndex + 1), slide.getCustomData().getCustomXmlParts());

        for (int shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            IShape shape = slide.getShapes().get_Item(shapeIndex);
            registerCustomXmlParts.accept("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.getCustomData().getCustomXmlParts());
        }
    }

    for (Map.Entry<UUID, List<String>> referenceEntry : referencesByItemId.entrySet()) {
        if (referenceEntry.getValue().size() > 1) {
            System.out.println("Shared custom XML part: " + referenceEntry.getKey());

            for (String ownerName : referenceEntry.getValue()) {
                System.out.println("  Referenced by: " + ownerName);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Esse tipo de auditoria é útil antes de modificar ou excluir dados XML personalizados em apresentações criadas por sistemas externos, pois a mesma parte de metadados pode participar de mais de um relacionamento.

## **Obter Valores das Tags**

Em slides, uma tag corresponde ao método `IDocumentProperties.getKeywords()`. Este código de exemplo mostra como obter o valor de uma tag com Aspose.Slides para Java para [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    String keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **Adicionar Tags a Apresentações**

O Aspose.Slides permite adicionar tags a apresentações. Uma tag normalmente consiste em dois itens:

- o nome de uma propriedade personalizada, por exemplo, `MyTag`;
- o valor da propriedade personalizada, por exemplo, `My Tag Value`.

Se precisar classificar apresentações com base em uma regra ou propriedade específica, você pode adicionar tags para esse fim. Por exemplo, se quiser categorizar apresentações de países da América do Norte, pode criar uma tag da América do Norte e atribuir o país relevante como seu valor.

Este código de exemplo mostra como adicionar uma tag a uma [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation) usando Aspose.Slides para Java:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ITagCollection tags = presentation.getCustomData().getTags();
    tags.set_Item("MyTag", "My Tag Value");
} finally {
    presentation.dispose();
}
```

Tags também podem ser definidas para um [Slide](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ISlide):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

Ou para uma [Shape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IAutoShape):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

### **Limitações**

Tags adicionadas através da coleção `getCustomData().getTags()` são armazenadas apenas no arquivo PowerPoint. Elas **não** são transferidas para a estrutura de tags PDF quando a apresentação é exportada para PDF. Consequentemente, um identificador personalizado atribuído como tag não pode ser recuperado do PDF marcado.

**Solução alternativa**: Você pode armazenar um identificador personalizado no **Alt Text** do objeto (por exemplo, `shape.setAlternativeText("MyId")`). Após exportar para PDF, o Alt Text pode aparecer na estrutura de tags do PDF.

## **FAQ**

**Posso remover todas as tags de uma apresentação, slide ou forma em uma única operação?**

Sim. A [coleção de tags](https://reference.aspose.com/slides/pt/java/com.aspose.slides/tagcollection/) suporta a operação [clear](https://reference.aspose.com/slides/pt/java/com.aspose.slides/tagcollection/#clear--) que exclui todos os pares chave‑valor de uma vez.

**Como excluir uma única tag pelo seu nome sem iterar sobre toda a coleção?**

Use [remove(name)](https://reference.aspose.com/slides/pt/java/com.aspose.slides/tagcollection/#remove-java.lang.String-) na [coleção de tags](https://reference.aspose.com/slides/pt/java/com.aspose.slides/tagcollection/) para excluir a tag pela sua chave.

**Como posso recuperar a lista completa de nomes de tags para análise ou filtragem?**

Use [getNamesOfTags](https://reference.aspose.com/slides/pt/java/com.aspose.slides/tagcollection/#getNamesOfTags--) na [coleção de tags](https://reference.aspose.com/slides/pt/java/com.aspose.slides/tagcollection/); ele retorna um array com todos os nomes de tags.

**Como posso encontrar todas as partes XML personalizadas, independentemente de onde estejam armazenadas?**

Use [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) para recuperar todas as partes XML personalizadas na apresentação.

**Devo usar `getXmlAsString`/`setXmlAsString` ou `getXmlData`/`setXmlData` para atualizar uma parte XML personalizada?**

Use `getXmlAsString` e `setXmlAsString` quando a aplicação trabalha com texto XML UTF‑8. Use `getXmlData` e `setXmlData` quando o XML já está disponível como um array de bytes ou quando o processamento orientado a binários for mais conveniente. Ambas as representações referem‑se ao conteúdo XML da mesma parte XML personalizada.