---
title: 使用 PHP 对演示文稿中的标签和自定义数据进行管理
linktitle: 标签和自定义数据
type: docs
weight: 300
url: /zh/php-java/managing-tags-and-custom-data/
keywords:
- 文档属性
- 标签
- 自定义数据
- 自定义 XML
- 自定义 XML 部分
- XML 元数据
- ItemId
- 添加标签
- 键值对
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP via Java 管理 PowerPoint 演示文稿中的标签和自定义 XML 数据，包括添加、读取、更新、审计和删除自定义 XML 部分。"
---
## **概述**

本文说明 Aspose.Slides 如何在 PowerPoint 演示文稿中使用标签和自定义数据。演示文稿特定的数据可以存储为标签或自定义 XML 部分。标签是简单的键值字符串对，而自定义 XML 部分可以存储结构化的元数据和应用程序特定的 XML 负载。

Aspose.Slides 提供用于在演示文稿、幻灯片和形状级别添加、读取、更新、审计和删除自定义 XML 部分的 API。自定义 XML 部分对于需要在演示文稿中存储文档管理标识符、工作流状态、合规性元数据、模板绑定数据或其他结构化应用程序数据的集成非常有用。

## **演示文稿文件中的数据存储**

PPTX 文件——扩展名为 `.pptx` 的文件——采用 PresentationML 格式存储，这是 Office Open XML 规范的一部分。Office Open XML 定义了用于存储演示文稿内容和相关数据的包结构和关系。

一个演示文稿包含通过关系连接的多个部件。例如，幻灯片部件包含单个幻灯片的内容，并且可以拥有由 ISO/IEC 29500 定义的对其他部件的显式关系。

自定义数据可以存储为标签（[TagCollection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/tagcollection/)）或自定义 XML 部件（[CustomXmlPartCollection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/customxmlpartcollection/)）。两者均通过 [`CustomData`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/customdata/) 类提供。

{{% alert color="primary" %}}
标签存储简单的字符串键值对。自定义 XML 部件存储结构化的 XML 数据，并且可以关联到演示文稿、幻灯片或形状。
{{% /alert %}}

## **使用自定义 XML 部分**

[`CustomData::getCustomXmlParts()`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/customdata/#getCustomXmlParts) 方法返回与特定演示文稿对象关联的自定义 XML 部件集合。例如：

- `$presentation->getCustomData()->getCustomXmlParts()` 包含与演示文稿本身关联的自定义 XML 部件。
- `$slide->getCustomData()->getCustomXmlParts()` 包含与特定幻灯片关联的自定义 XML 部件。
- `$shape->getCustomData()->getCustomXmlParts()` 包含与特定形状关联的自定义 XML 部件。

需要检查演示文稿中所有自定义 XML 部件（无论其关联对象）时，请使用 [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#getAllCustomXmlParts)。

### **向演示文稿添加自定义 XML 部分**

使用 [`CustomXmlPartCollection::add`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/customxmlpartcollection/#add) 向自定义 XML 部件集合添加 XML 数据。XML 必须有效且非空。

以下示例向演示文稿级别的自定义数据集合添加结构化元数据：

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

    // add 会自动分配标识符。仅在需要时才设置特定的 UUID。
    $UUID = new JavaClass("java.util.UUID");
    $customXmlPart->setItemId($UUID->randomUUID());

    $presentation->save("presentation_with_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`add` 方法也可以接受字节数组或输入流形式的 XML，这在 XML 内容已经以二进制形式可用时非常有用。

### **向幻灯片或形状添加自定义 XML 部分**

自定义 XML 数据可以关联到特定幻灯片或形状，而不是整个演示文稿。当元数据仅描述单个对象（如模板键、外部记录标识符或绑定信息）时，这很有用。

以下示例向一个幻灯片添加一个自定义 XML 部分，并向一个形状添加另一个：

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

添加部件的级别决定了哪个对象的 `getCustomData()->getCustomXmlParts()` 集合中包含对该部件的关系。演示文稿级别的数据适用于文档范围的元数据，幻灯片级别的数据适用于特定幻灯片的信息，形状级别的数据适用于绑定到单个形状的元数据。

### **列出并审计所有自定义 XML 部分**

使用 [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#getAllCustomXmlParts) 检索演示文稿中的所有自定义 XML 部件。每个 [`CustomXmlPart`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/customxmlpart/) 都会公开其标识符、XML 内容和关联的命名空间模式。

以下示例列出所有自定义 XML 部件及其命名空间模式：

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

[`CustomXmlPart::getNamespaceSchemas()`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/customxmlpart/#getNamespaceSchemas) 返回与该自定义 XML 部分关联的 XML 模式。在审计包含外部系统生成的 XML 的演示文稿时，此信息可能非常有用。

### **读取并更新 XML 内容和 ItemId**

使用 [`CustomXmlPart::getXmlAsString()`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/customxmlpart/#getXmlAsString) 和 [`setXmlAsString()`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/customxmlpart/#setXmlAsString) 以 UTF-8 字符串形式处理 XML，或使用 [`getXmlData()`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/customxmlpart/#getXmlData) 和 [`setXmlData()`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/customxmlpart/#setXmlData) 以原始字节形式处理。

[`CustomXmlPart::getItemId()`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/customxmlpart/#getItemId) 方法返回在 Office Open XML 文档中标识该自定义 XML 部分的 UUID。需要新标识符时，请使用 [`setItemId()`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/customxmlpart/#setItemId)。

以下示例更新 XML 内容和标识符：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $customXmlPart = $presentation->getAllCustomXmlParts()[0];

    // 读取当前 XML 为文本。
    $currentXmlContent = $customXmlPart->getXmlAsString();
    echo $currentXmlContent . PHP_EOL;

    // 以 UTF-8 字符串更新 XML。
    $customXmlPart->setXmlAsString(
        '<metadata xmlns="urn:example:metadata">' .
            '<documentId>DOC-1001</documentId>' .
            '<workflowState>Approved</workflowState>' .
        '</metadata>'
    );

    // getXmlData 提供相同的 XML 内容，以原始字节形式。
    $customXmlData = $customXmlPart->getXmlData();

    // 在集成需要时替换标识符。
    $UUID = new JavaClass("java.util.UUID");
    $customXmlPart->setItemId($UUID->randomUUID());

    $presentation->save("updated_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

调用 `setXmlAsString` 或 `setXmlData` 时，请提供有效且非空的 XML。根据应用主要使用字符串还是字节数据，选择相应的表示方式。

### **删除自定义 XML 部分**

Aspose.Slides 提供多种方式删除自定义 XML 数据：

- [`CustomXmlPart::remove`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/customxmlpart/#remove) 从演示文稿中删除该自定义 XML 部分。
- [`CustomXmlPartCollection::remove`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/customxmlpartcollection/#remove) 从自定义 XML 部件集合中删除指定部件。
- [`CustomXmlPartCollection::removeAt`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/customxmlpartcollection/#removeAt) 删除集合中指定索引处的部件。
- [`CustomXmlPartCollection::clear`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/customxmlpartcollection/#clear) 删除特定集合中的所有部件。

以下示例通过引用删除一个演示文稿级别的自定义 XML 部分：

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

如果已经拥有 `CustomXmlPart` 实例并希望直接从演示文稿中删除该部件，而不是操作特定集合，可调用 `$customXmlPart->remove()`。

也可以通过索引删除：

```php
$presentation->getCustomData()->getCustomXmlParts()->removeAt(0);
```

### **清除集合中的所有自定义 XML 部分**

当需要移除与特定演示文稿对象关联的所有自定义 XML 部分时，使用 `clear`。

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getSlides()->get_Item(0)->getCustomData()->getCustomXmlParts()->clear();

    $presentation->save("slide_custom_xml_cleared.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`clear` 仅影响所选集合。例如，清除幻灯片的集合并不会清除演示文稿级别或形状级别的集合。

要删除演示文稿中的所有自定义 XML 部分，可遍历 `getAllCustomXmlParts()` 并逐个删除：

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

### **处理链接或共享的自定义 XML 部分**

在 Office Open XML 演示文稿中，同一自定义 XML 部分可以被多个演示文稿对象引用。例如，现有文件可能包含多个幻灯片或形状指向同一底层自定义 XML 部分的关系。

共享部件应视为一个数据对象，拥有多个引用：

- 使用 `setXmlAsString`、`setXmlData` 或 `setItemId` 更新时，会修改底层自定义 XML 部分，因而所有引用该部件的地方都会同步更改。
- `getItemId()` 可用于在审计对象级别的集合时识别相同的自定义 XML 部分。
- 从特定 `getCustomXmlParts()` 集合中删除部件，仅从该集合中移除。若需从演示文稿中彻底删除该部件，请使用 `CustomXmlPart::remove()`。
- 在删除或替换共享部件之前，检查对象级别的集合以判断其他幻灯片或形状是否仍然引用它。

`add` 的重载会根据 XML 内容创建新的自定义 XML 部分；它们不接受已有的 `CustomXmlPart`。因此，共享关系最常在加载已包含此类部件的演示文稿时出现。

以下示例按 `ItemId` 审计演示文稿、幻灯片和形状级别的集合，并报告在多个位置被引用的部件：

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

在修改或删除由外部系统生成的演示文稿中的自定义 XML 数据之前进行此类审计非常有价值，因为同一元数据部件可能参与多个关系。

## **获取标签的值**

在 Slides 中，标签对应 `DocumentProperties::getKeywords()` 方法。以下示例展示如何使用 Aspose.Slides for PHP via Java 获取 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 的标签值：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $keywords = $presentation->getDocumentProperties()->getKeywords();
} finally {
    $presentation->dispose();
}
```

## **向演示文稿添加标签**

Aspose.Slides 允许向演示文稿添加标签。标签通常由两项组成：

- 自定义属性的名称，例如 `MyTag`；
- 自定义属性的值，例如 `My Tag Value`。

如果需要根据特定规则或属性对演示文稿进行分类，可以添加相应的标签。例如，若要对来自北美国家的演示文稿进行分类，可创建一个北美标签并将相应国家设为其值。

以下示例演示如何使用 Aspose.Slides for PHP via Java 向 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 添加标签：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $tags = $presentation->getCustomData()->getTags();
    $tags->set_Item("MyTag", "My Tag Value");
} finally {
    $presentation->dispose();
}
```

标签也可以为 [Slide](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slide/) 设置：

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getCustomData()->getTags()->set_Item("tag", "value");
} finally {
    $presentation->dispose();
}
```

或为单个 [Shape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/autoshape/) 设置：

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

### **限制**

通过 `getCustomData()->getTags()` 集合添加的标签仅存储在 PowerPoint 文件中。导出为 PDF 时，它们 **不会** 转移到 PDF 标签结构。因此，作为标签分配的自定义标识符无法从带标签的 PDF 中检索。

**解决方案**：可以将自定义标识符存储在对象的 **Alt Text** 中（例如 `$shape->setAlternativeText("MyId")`）。导出为 PDF 后，Alt Text 可能会出现在 PDF 标签结构中。

## **常见问题**

**我可以一次性删除演示文稿、幻灯片或形状中的所有标签吗？**

可以。[标签集合](https://reference.aspose.com/slides/zh/php-java/aspose.slides/tagcollection/) 支持 [clear](https://reference.aspose.com/slides/zh/php-java/aspose.slides/tagcollection/#clear) 操作，一次性删除所有键值对。

**如何在不遍历整个集合的情况下，仅通过名称删除单个标签？**

对[标签集合](https://reference.aspose.com/slides/zh/php-java/aspose.slides/tagcollection/)使用 [remove(name)](https://reference.aspose.com/slides/zh/php-java/aspose.slides/tagcollection/#remove) 即可根据键删除标签。

**如何获取完整的标签名称列表以进行分析或过滤？**

使用 [getNamesOfTags](https://reference.aspose.com/slides/zh/php-java/aspose.slides/tagcollection/#getNamesOfTags) 方法，它会返回所有标签名称的数组。

**如何查找所有自定义 XML 部分，无论它们存储在何处？**

使用 [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#getAllCustomXmlParts) 检索演示文稿中的全部自定义 XML 部分。

**在更新自定义 XML 部分时，应使用 `getXmlAsString`/`setXmlAsString` 还是 `getXmlData`/`setXmlData`？**

当应用程序处理 UTF-8 XML 文本时使用 `getXmlAsString` 和 `setXmlAsString`。当 XML 已以字节数组形式存在或二进制处理更方便时，使用 `getXmlData` 和 `setXmlData`。两种表示方式都指向同一自定义 XML 部分的内容。