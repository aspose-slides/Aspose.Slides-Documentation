---
title: Gerenciar tags e dados personalizados em apresentações usando PHP
linktitle: Tags e dados personalizados
type: docs
weight: 300
url: /pt/php-java/managing-tags-and-custom-data/
keywords:
- propriedades do documento
- etiqueta
- dados personalizados
- XML personalizado
- parte XML personalizada
- metadados XML
- ItemId
- adicionar tag
- pares de valores
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Aprenda a gerenciar tags e dados XML personalizados em apresentações PowerPoint com Aspose.Slides para PHP via Java, incluindo a adição, leitura, atualização, auditoria e remoção de partes XML personalizadas."
---
## **Visão geral**

Este artigo explica como o Aspose.Slides lida com tags e dados personalizados em apresentações do PowerPoint. Dados específicos da apresentação podem ser armazenados como tags ou partes XML personalizadas. Tags são pares simples de string chave‑valor, enquanto partes XML personalizadas podem armazenar metadados estruturados e cargas XML específicas de aplicativo.

Aspose.Slides fornece APIs para adicionar, ler, atualizar, auditar e remover partes XML personalizadas nos níveis de apresentação, slide e forma. Partes XML personalizadas são úteis para integrações que armazenam informações como identificadores de gerenciamento de documentos, estado de fluxo de trabalho, metadados de conformidade, dados de vinculação de modelo ou outros dados estruturados de aplicação dentro de uma apresentação.

## **Armazenamento de dados em arquivos de apresentação**

Arquivos PPTX — arquivos com a extensão `.pptx` — são armazenados no formato PresentationML, que faz parte da especificação Office Open XML. Office Open XML define a estrutura de pacotes e relacionamentos usados para armazenar o conteúdo da apresentação e dados relacionados.

Uma apresentação contém múltiplas partes conectadas por relacionamentos. Por exemplo, uma parte de slide contém o conteúdo de um único slide e pode ter relacionamentos explícitos com outras partes definidas pela ISO/IEC 29500.

Dados personalizados podem ser armazenados como tags ([TagCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/tagcollection/)) ou partes XML personalizadas ([CustomXmlPartCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/customxmlpartcollection/)). Ambos estão disponíveis através da classe [`CustomData`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/customdata/).

{{% alert color="primary" %}}
Tags armazenam pares simples de string chave‑valor. Partes XML personalizadas armazenam dados XML estruturados e podem ser associadas a uma apresentação, slide ou forma.
{{% /alert %}}

## **Trabalhar com partes XML personalizadas**

O método [`CustomData::getCustomXmlParts()`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/customdata/#getCustomXmlParts) retorna a coleção de partes XML personalizadas associadas a um determinado objeto de apresentação. Por exemplo:

- `$presentation->getCustomData()->getCustomXmlParts()` contém partes XML personalizadas associadas à própria apresentação.
- `$slide->getCustomData()->getCustomXmlParts()` contém partes XML personalizadas associadas a um slide específico.
- `$shape->getCustomData()->getCustomXmlParts()` contém partes XML personalizadas associadas a uma forma específica.

Use [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#getAllCustomXmlParts) quando precisar inspecionar todas as partes XML personalizadas na apresentação, independentemente de onde estejam associadas.

### **Adicionar uma parte XML personalizada a uma apresentação**

Use [`CustomXmlPartCollection::add`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/customxmlpartcollection/#add) para adicionar dados XML a uma coleção de partes XML personalizadas. O XML deve ser válido e não vazio.

O exemplo a seguir adiciona metadados estruturados à coleção de dados personalizados no nível da apresentação:

```php
$customXmlContent =
    '<?xml version="1.0" encoding="UTF-8"?>' .
    '<metadata xmlns="urn:example:metadata">' .
        '<documentId>DOC-1001</documentId>' .
        '<workflowState>Draft</workflowState>' .
    '</metadata>';

$presentation = new Presentation();
try {
    $customXmlPart = $presentation->getCustomData()->getCustomXmlParts()->add($customXmlContent);

    // add atribui um identificador automaticamente. Defina um UUID específico apenas quando necessário.
    $UUID = new JavaClass("java.util.UUID");
    $customXmlPart->setItemId($UUID->randomUUID());

    $presentation->save("presentation_with_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

O método `add` também pode aceitar XML como um array de bytes ou fluxo de entrada, o que é útil quando o conteúdo XML já está disponível em forma binária.

### **Adicionar uma parte XML personalizada a um slide ou forma**

Dados XML personalizados podem ser associados a um slide ou forma específicos em vez de à apresentação inteira. Isso é útil quando os metadados descrevem apenas um objeto, como uma chave de modelo, identificador de registro externo ou informação de vínculo.

O exemplo a seguir adiciona uma parte XML personalizada a um slide e outra a uma forma:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getCustomData()->getCustomXmlParts()->add(
        '<slideMetadata xmlns="urn:example:slides">' .
            '<templateKey>TitleSlide</templateKey>' .
        '</slideMetadata>'
    );

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 250, 80);

    $shape->getTextFrame()->setText("Customer data");
    $shape->getCustomData()->getCustomXmlParts()->add(
        '<shapeMetadata xmlns="urn:example:shapes">' .
            '<recordId>CRM-4281</recordId>' .
        '</shapeMetadata>'
    );

    $presentation->save("object_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

O nível em que a parte é adicionada determina qual coleção `getCustomData()->getCustomXmlParts()` do objeto contém o relacionamento com essa parte. Dados no nível da apresentação são adequados para metadados de todo o documento, dados no nível do slide para informações que pertencem a um slide específico e dados no nível da forma para metadados vinculados a uma forma individual.

### **Listar e auditar todas as partes XML personalizadas**

Use [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#getAllCustomXmlParts) para recuperar todas as partes XML personalizadas de uma apresentação. Cada [`CustomXmlPart`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/customxmlpart/) expõe seu identificador, conteúdo XML e esquemas de namespaces associados.

O exemplo a seguir lista todas as partes XML personalizadas e seus esquemas de namespace:

```php
$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getAllCustomXmlParts() as $customXmlPart) {
        echo "ItemId: " . $customXmlPart->getItemId() . PHP_EOL;
        echo "XML:" . PHP_EOL;
        echo $customXmlPart->getXmlAsString() . PHP_EOL;

        foreach ($customXmlPart->getNamespaceSchemas() as $namespaceSchema) {
            echo "Namespace schema: " . $namespaceSchema . PHP_EOL;
        }

        echo PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

[`CustomXmlPart::getNamespaceSchemas()`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/customxmlpart/#getNamespaceSchemas) devolve os esquemas XML associados à parte XML personalizada. Essa informação pode ser útil ao auditar apresentações que contêm XML produzido por sistemas externos.

### **Ler e atualizar conteúdo XML e ItemId**

Use [`CustomXmlPart::getXmlAsString()`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/customxmlpart/#getXmlAsString) e [`setXmlAsString()`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/customxmlpart/#setXmlAsString) para trabalhar com XML como string UTF‑8, ou [`getXmlData()`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/customxmlpart/#getXmlData) e [`setXmlData()`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/customxmlpart/#setXmlData) para trabalhar com os bytes brutos do XML.

O método [`CustomXmlPart::getItemId()`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/customxmlpart/#getItemId) devolve o UUID que identifica a parte XML personalizada no documento Office Open XML. Use [`setItemId()`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/customxmlpart/#setItemId) quando uma integração exigir um novo identificador.

O exemplo a seguir atualiza o conteúdo XML e o identificador:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $customXmlPart = $presentation->getAllCustomXmlParts()[0];

    // Lê o XML atual como texto.
    $currentXmlContent = $customXmlPart->getXmlAsString();
    echo $currentXmlContent . PHP_EOL;

    // Atualiza o XML como uma string UTF-8.
    $customXmlPart->setXmlAsString(
        '<metadata xmlns="urn:example:metadata">' .
            '<documentId>DOC-1001</documentId>' .
            '<workflowState>Approved</workflowState>' .
        '</metadata>'
    );

    // getXmlData fornece o mesmo conteúdo XML como bytes brutos.
    $customXmlData = $customXmlPart->getXmlData();

    // Substitui o identificador quando exigido pela integração.
    $UUID = new JavaClass("java.util.UUID");
    $customXmlPart->setItemId($UUID->randomUUID());

    $presentation->save("updated_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ao chamar `setXmlAsString` ou `setXmlData`, forneça XML válido e não vazio. Use uma representação ou outra dependendo se a aplicação trabalha principalmente com strings ou com dados binários.

### **Remover uma parte XML personalizada**

Aspose.Slides oferece diversas maneiras de remover dados XML personalizados:

- [`CustomXmlPart::remove`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/customxmlpart/#remove) remove a parte XML personalizada da apresentação.
- [`CustomXmlPartCollection::remove`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/customxmlpartcollection/#remove) remove uma parte específica de uma coleção de partes XML personalizadas.
- [`CustomXmlPartCollection::removeAt`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/customxmlpartcollection/#removeAt) remove a parte no índice de coleção especificado.
- [`CustomXmlPartCollection::clear`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/customxmlpartcollection/#clear) remove todas as partes de uma coleção específica.

O exemplo a seguir remove uma parte XML personalizada no nível da apresentação por referência:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $customXmlParts = $presentation->getCustomData()->getCustomXmlParts();

    if (java_values($customXmlParts->size()) > 0) {
        $customXmlPart = $customXmlParts->get_Item(0);
        $customXmlParts->remove($customXmlPart);
    }

    $presentation->save("custom_xml_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Se você já possui um `CustomXmlPart` e deseja remover essa parte da apresentação em vez de endereçar uma coleção específica, chame `$customXmlPart->remove()`.

Você também pode remover um item por índice:

```php
$presentation->getCustomData()->getCustomXmlParts()->removeAt(0);
```

### **Limpar todas as partes XML personalizadas de uma coleção**

Use `clear` quando todas as partes XML personalizadas associadas a um determinado objeto de apresentação devem ser removidas.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getSlides()->get_Item(0)->getCustomData()->getCustomXmlParts()->clear();

    $presentation->save("slide_custom_xml_cleared.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`clear` afeta somente a coleção selecionada. Por exemplo, limpar a coleção de um slide não limpa as coleções nos níveis de apresentação ou forma.

Para remover todas as partes XML personalizadas da apresentação, itere sobre `getAllCustomXmlParts()` e remova cada parte:

```php
$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getAllCustomXmlParts() as $customXmlPart) {
        $customXmlPart->remove();
    }

    $presentation->save("all_custom_xml_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Manipular partes XML personalizadas vinculadas ou compartilhadas**

Em uma apresentação Office Open XML, a mesma parte XML personalizada pode ser referenciada por mais de um objeto de apresentação. Por exemplo, um arquivo existente pode conter relacionamentos de vários slides ou formas para a mesma parte XML subjacente.

Uma parte compartilhada deve ser tratada como um único objeto de dados com múltiplas referências:

- Atualizá‑la com `setXmlAsString`, `setXmlData` ou `setItemId` altera a parte XML subjacente, de modo que a mudança se aplique onde quer que a parte seja referenciada.
- `getItemId()` pode ser usado para identificar a mesma parte XML personalizada ao auditar coleções de nível de objeto.
- Remover uma parte de uma coleção `getCustomXmlParts()` específica a remove apenas daquela coleção. Use `CustomXmlPart::remove()` quando a própria parte deve ser removida da apresentação.
- Antes de excluir ou substituir uma parte compartilhada, inspecione as coleções de nível de objeto para determinar se outros slides ou formas ainda a referenciam.

As sobrecargas de `add` criam uma nova parte XML personalizada a partir do conteúdo XML; elas não aceitam um `CustomXmlPart` existente. Portanto, relacionamentos compartilhados são mais frequentemente encontrados ao carregar apresentações que já os contêm.

O exemplo a seguir audita coleções nos níveis de apresentação, slide e forma por `ItemId` e relata partes referenciadas em mais de um local:

```php
function registerCustomXmlParts($ownerName, $customXmlParts, &$referencesByItemId) {
    $partCount = java_values($customXmlParts->size());

    for ($i = 0; $i < $partCount; $i++) {
        $customXmlPart = $customXmlParts->get_Item($i);
        $itemId = java_values($customXmlPart->getItemId()->toString());

        if (!isset($referencesByItemId[$itemId])) {
            $referencesByItemId[$itemId] = [];
        }

        $referencesByItemId[$itemId][] = $ownerName;
    }
}

$presentation = new Presentation("presentation.pptx");
try {
    $referencesByItemId = [];

    registerCustomXmlParts(
        "Presentation",
        $presentation->getCustomData()->getCustomXmlParts(),
        $referencesByItemId
    );

    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        registerCustomXmlParts(
            "Slide " . ($slideIndex + 1),
            $slide->getCustomData()->getCustomXmlParts(),
            $referencesByItemId
        );

        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            registerCustomXmlParts(
                "Slide " . ($slideIndex + 1) . ", shape " . $shapeIndex,
                $shape->getCustomData()->getCustomXmlParts(),
                $referencesByItemId
            );
        }
    }

    foreach ($referencesByItemId as $itemId => $owners) {
        if (count($owners) > 1) {
            echo "Shared custom XML part: " . $itemId . PHP_EOL;

            foreach ($owners as $ownerName) {
                echo "  Referenced by: " . $ownerName . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Esse tipo de auditoria é útil antes de modificar ou excluir dados XML personalizados em apresentações criadas por sistemas externos, pois a mesma parte de metadados pode participar de mais de um relacionamento.

## **Obter valores de tags**

Em slides, uma tag corresponde ao método `DocumentProperties::getKeywords()`. Este código de exemplo mostra como obter o valor de uma tag com Aspose.Slides para PHP via Java para [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/):

```php
$presentation = new Presentation("presentation.pptx");
try {
    $keywords = $presentation->getDocumentProperties()->getKeywords();
} finally {
    $presentation->dispose();
}
```

## **Adicionar tags a apresentações**

Aspose.Slides permite adicionar tags a apresentações. Uma tag normalmente consiste em dois itens:

- o nome de uma propriedade personalizada, por exemplo, `MyTag`;
- o valor da propriedade personalizada, por exemplo, `My Tag Value`.

Se precisar classificar apresentações com base em uma regra ou propriedade específica, pode adicionar tags para esse fim. Por exemplo, se quiser categorizar apresentações de países da América do Norte, pode criar uma tag “North American” e atribuir o país relevante como seu valor.

Este código de exemplo mostra como adicionar uma tag a uma [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) usando Aspose.Slides para PHP via Java:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $tags = $presentation->getCustomData()->getTags();
    $tags->set_Item("MyTag", "My Tag Value");
} finally {
    $presentation->dispose();
}
```

Tags também podem ser definidas para um [Slide](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slide/):

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getCustomData()->getTags()->set_Item("tag", "value");
} finally {
    $presentation->dispose();
}
```

Ou para uma [Shape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/) individual:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 50);
    $shape->getTextFrame()->setText("My text");
    $shape->getCustomData()->getTags()->set_Item("tag", "value");
} finally {
    $presentation->dispose();
}
```

### **Limitações**

Tags adicionadas através da coleção `getCustomData()->getTags()` são armazenadas apenas no arquivo PowerPoint. Elas **não** são transferidas para a estrutura de tags do PDF quando a apresentação é exportada para PDF. Consequentemente, um identificador customizado atribuído como tag não pode ser recuperado a partir do PDF marcado.

**Solução alternativa**: você pode armazenar um identificador customizado no **Texto alternativo** do objeto (por exemplo, `$shape->setAlternativeText("MyId")`). Após a exportação para PDF, o Texto alternativo pode aparecer na estrutura de tags do PDF.

## **FAQ**

**Posso remover todas as tags de uma apresentação, slide ou forma em uma única operação?**

Sim. A [coleção de tags](https://reference.aspose.com/slides/pt/php-java/aspose.slides/tagcollection/) oferece uma operação de [clear](https://reference.aspose.com/slides/pt/php-java/aspose.slides/tagcollection/#clear) que exclui todos os pares chave‑valor de uma vez.

**Como excluir uma única tag pelo nome sem iterar por toda a coleção?**

Use [remove(name)](https://reference.aspose.com/slides/pt/php-java/aspose.slides/tagcollection/#remove) na [coleção de tags](https://reference.aspose.com/slides/pt/php-java/aspose.slides/tagcollection/) para excluir a tag pela sua chave.

**Como obter a lista completa de nomes de tags para análise ou filtragem?**

Use [getNamesOfTags](https://reference.aspose.com/slides/pt/php-java/aspose.slides/tagcollection/#getNamesOfTags) na [coleção de tags](https://reference.aspose.com/slides/pt/php-java/aspose.slides/tagcollection/); ela devolve um array com todos os nomes de tags.

**Como encontrar todas as partes XML personalizadas independentemente de onde estejam armazenadas?**

Use [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#getAllCustomXmlParts) para recuperar todas as partes XML personalizadas na apresentação.

**Devo usar `getXmlAsString`/`setXmlAsString` ou `getXmlData`/`setXmlData` para atualizar uma parte XML personalizada?**

Use `getXmlAsString` e `setXmlAsString` quando a aplicação trabalhar com texto XML UTF‑8. Use `getXmlData` e `setXmlData` quando o XML já estiver disponível como array de bytes ou quando o processamento binário for mais conveniente. Ambas as representações referem‑se ao conteúdo XML da mesma parte XML personalizada.