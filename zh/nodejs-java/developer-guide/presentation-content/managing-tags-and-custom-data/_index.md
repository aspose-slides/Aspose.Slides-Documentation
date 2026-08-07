---
title: 使用 JavaScript 管理演示文稿中的标签和自定义数据
linktitle: 标签和自定义数据
type: docs
weight: 300
url: /zh/nodejs-java/managing-tags-and-custom-data/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Node.js via Java 在 PowerPoint 演示文稿中管理标签和自定义 XML 数据，包括添加、读取、更新、审计和移除自定义 XML 部分。"
---
## **概述**

本文说明 Aspose.Slides 如何在 PowerPoint 演示文稿中使用标签和自定义数据。演示文稿特定的数据可以存储为标签或自定义 XML 部分。标签是简单的键值字符串对，而自定义 XML 部分可以存储结构化的元数据和应用程序特定的 XML 负载。

Aspose.Slides 提供了在演示文稿、幻灯片和形状层级上添加、读取、更新、审计和移除自定义 XML 部分的 API。自定义 XML 部分对于存储文档管理标识符、工作流状态、合规性元数据、模板绑定数据或其他结构化应用数据等信息的集成非常有用。

## **演示文稿文件中的数据存储**

PPTX 文件——即扩展名为 `.pptx` 的文件——采用 PresentationML 格式存储，这是 Office Open XML 规范的一部分。Office Open XML 定义了用于存储演示文稿内容及关联数据的包结构和关系。

一个演示文稿由多个通过关系连接的部件组成。例如，幻灯片部件包含单个幻灯片的内容，并且可以通过 ISO/IEC 29500 定义的显式关系链接到其他部件。

自定义数据可以作为标签（[TagCollection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/tagcollection/)）或自定义 XML 部分（[CustomXmlPartCollection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/customxmlpartcollection/)）存储。两者均通过 [`CustomData`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/customdata/) 类访问。

{{% alert color="primary" %}}
标签存储简单的字符串键值对。自定义 XML 部分存储结构化的 XML 数据，并且可以关联到演示文稿、幻灯片或形状。
{{% /alert %}}

## **自定义 XML 部分的操作**

[`CustomData`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/customdata/) 的 `getCustomXmlParts()` 方法返回与特定演示文稿对象关联的自定义 XML 部分集合。例如：

- `presentation.getCustomData().getCustomXmlParts()` 包含与演示文稿本身关联的自定义 XML 部分。
- `slide.getCustomData().getCustomXmlParts()` 包含与特定幻灯片关联的自定义 XML 部分。
- `shape.getCustomData().getCustomXmlParts()` 包含与特定形状关联的自定义 XML 部分。

当需要检查演示文稿中所有自定义 XML 部分（无论关联到何处）时，请使用 [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/)。

### **向演示文稿添加自定义 XML 部分**

使用 [`CustomXmlPartCollection`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/customxmlpartcollection/) 的 `add` 方法将 XML 数据添加到自定义 XML 部分集合中。XML 必须是有效且非空的。

下面的示例向演示文稿级别的自定义数据集合添加结构化元数据：

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

    // add 自动分配标识符。仅在需要时设置特定的 UUID。
    const itemId = java.callStaticMethodSync("java.util.UUID", "randomUUID");
    customXmlPart.setItemId(itemId);

    presentation.save("presentation_with_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`add` 方法也可以接受字节数组形式的 XML，这在 XML 内容已经以二进制形式存在时非常有用。

### **向幻灯片或形状添加自定义 XML 部分**

自定义 XML 数据可以关联到特定的幻灯片或形状，而不是整个演示文稿。这在元数据仅描述单一对象（例如模板键、外部记录标识符或绑定信息）时非常有用。

下面的示例向一个幻灯片添加一个自定义 XML 部分，向一个形状添加另一个自定义 XML 部分：

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

添加部件的层级决定了哪个对象的 `getCustomData().getCustomXmlParts()` 集合包含对该部件的关系。演示文稿级别的数据适用于文档范围的元数据，幻灯片级别的数据适用于特定幻灯片的信息，形状级别的数据适用于绑定到单个形状的元数据。

### **列出并审计所有自定义 XML 部分**

使用 [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 从演示文稿中检索全部自定义 XML 部分。每个 [`CustomXmlPart`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/customxmlpart/) 都会公开其标识符、XML 内容以及关联的命名空间模式。

下面的示例列出所有自定义 XML 部分及其命名空间模式：

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

[`CustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/customxmlpart/) 返回与该自定义 XML 部分关联的 XML 模式。在审计包含外部系统生成的 XML 的演示文稿时，这些信息非常有价值。

### **读取并更新 XML 内容和 ItemId**

使用 [`CustomXmlPart`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/customxmlpart/) 的 `getXmlAsString()` 和 `setXmlAsString()` 以 UTF-8 字符串形式处理 XML，或使用 `getXmlData()` 和 `setXmlData()` 以原始字节形式处理 XML。

`getItemId()` 方法返回在 Office Open XML 文档中唯一标识该自定义 XML 部分的 UUID。需要新标识符时请使用 `setItemId()`。

下面的示例更新 XML 内容以及标识符：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlPart = presentation.getAllCustomXmlParts()[0];

    // 读取当前 XML 为文本。
    const currentXmlContent = customXmlPart.getXmlAsString();
    console.log(currentXmlContent);

    // 以 UTF-8 字符串更新 XML。
    customXmlPart.setXmlAsString(
        '<metadata xmlns="urn:example:metadata">' +
            '<documentId>DOC-1001</documentId>' +
            '<workflowState>Approved</workflowState>' +
        '</metadata>');

    // getXmlData 提供相同的 XML 内容，以原始字节形式。
    const customXmlData = customXmlPart.getXmlData();
    console.log(Buffer.from(customXmlData).toString("utf8"));

    // 在集成需要时替换标识符。
    const itemId = java.callStaticMethodSync("java.util.UUID", "randomUUID");
    customXmlPart.setItemId(itemId);

    presentation.save("updated_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

调用 `setXmlAsString` 或 `setXmlData` 时，请提供有效且非空的 XML。根据应用程序是主要处理字符串还是字节数据，选择相应的表示方式。

### **移除自定义 XML 部分**

Aspose.Slides 提供多种方式移除自定义 XML 数据：

- [`CustomXmlPart.remove`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/customxmlpart/) 从演示文稿中移除该自定义 XML 部分。
- [`CustomXmlPartCollection.remove`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/customxmlpartcollection/) 从自定义 XML 部分集合中移除特定部件。
- [`CustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/customxmlpartcollection/) 按集合索引移除部件。
- [`CustomXmlPartCollection.clear`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/customxmlpartcollection/) 清除特定集合中的所有部件。

下面的示例通过引用移除一个演示文稿级别的自定义 XML 部分：

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

如果已经拥有 `CustomXmlPart` 实例并希望直接从演示文稿中移除该部件，而不是针对特定集合进行操作，只需调用 `customXmlPart.remove()`。

也可以按索引移除项目：

```javascript
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **清除集合中的所有自定义 XML 部分**

当需要删除与特定演示文稿对象关联的全部自定义 XML 部分时，请使用 `clear`。

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

`clear` 仅影响所选集合。例如，清除幻灯片的集合不会影响演示文稿级别或形状级别的集合。

若要一次性移除演示文稿中的所有自定义 XML 部分，可遍历 `getAllCustomXmlParts()` 并逐一调用 `remove`：

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

### **处理链接或共享的自定义 XML 部分**

在 Office Open XML 演示文稿中，同一个自定义 XML 部分可以被多个演示文稿对象引用。例如，已有文件可能包含多个幻灯片或形状指向同一底层自定义 XML 部分的关系。

共享部件应视为同一数据对象的多个引用：

- 使用 `setXmlAsString`、`setXmlData` 或 `setItemId` 更新时，会修改底层自定义 XML 部分，从而在所有引用该部件的地方同步更改。
- `getItemId()` 可用于在审计对象级别集合时识别相同的自定义 XML 部分。
- 从特定 `getCustomXmlParts()` 集合中移除部件，只会从该集合中删除。若希望从整个演示文稿中删除该部件，请使用 `CustomXmlPart.remove()`。
- 在删除或替换共享部件之前，检查对象级别的集合，以确定是否还有其他幻灯片或形状引用它。

`add` 的重载只能从 XML 内容创建新的自定义 XML 部分，不接受已有的 `CustomXmlPart`。因此，共享关系最常在加载已经包含这些关系的演示文稿时出现。

下面的示例按 `ItemId` 审计演示文稿、幻灯片和形状级别的集合，并报告被多个位置引用的部件：

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

在对外部系统创建的演示文稿修改或删除自定义 XML 数据之前进行此类审计非常有用，因为同一元数据部件可能参与多个关系。

## **获取标签的值**

在 Slides 中，标签对应 `DocumentProperties.getKeywords()` 方法。以下示例演示如何使用 Aspose.Slides for Node.js via Java 获取 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 的标签值：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **向演示文稿添加标签**

Aspose.Slides 允许向演示文稿添加标签。标签通常由两项组成：

- 自定义属性的名称，例如 `MyTag`；
- 自定义属性的值，例如 `My Tag Value`。

如果需要根据特定规则或属性对演示文稿进行分类，可以添加相应的标签。例如，要对北美国家的演示文稿进行分类，可创建一个北美标签并将相应的国家名称设为其值。

以下示例展示如何使用 Aspose.Slides for Node.js via Java 向 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 添加标签：

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

标签也可以针对 [Slide](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slide/) 设置：

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

或者针对单个 [Shape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/) 设置：

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

### **限制**

通过 `getCustomData().getTags()` 集合添加的标签仅存储在 PowerPoint 文件中。导出为 PDF 时，这些标签 **不会** 转移到 PDF 的标签结构中。因此，作为标签分配的自定义标识符在 PDF 中无法检索。

**解决办法**：可以将自定义标识符存储在对象的 **Alt Text** 中（例如 `shape.setAlternativeText("MyId")`）。导出为 PDF 后，Alt Text 可能出现在 PDF 的标签结构中。

## **常见问题**

**是否可以一次性删除演示文稿、幻灯片或形状中的所有标签？**

可以。[tag collection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/tagcollection/) 支持 [clear](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/tagcollection/) 操作，可一次性删除全部键值对。

**如何在不遍历整个集合的情况下，仅通过名称删除单个标签？**

对 [tag collection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/tagcollection/) 使用 `remove(name)` 即可根据键删除标签。

**如何检索完整的标签名称列表以进行分析或过滤？**

使用 `getNamesOfTags()` 方法，可在 [tag collection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/tagcollection/) 上获得所有标签名称的数组。

**如何查找所有自定义 XML 部分，无论它们存储在哪里？**

使用 [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 可检索演示文稿中的全部自定义 XML 部分。

**在更新自定义 XML 部分时，我应该使用 `getXmlAsString`/`setXmlAsString` 还是 `getXmlData`/`setXmlData`？**

当应用程序主要处理 UTF-8 XML 文本时，使用 `getXmlAsString` 和 `setXmlAsString`。当 XML 已以字节数组形式存在或二进制处理更方便时，使用 `getXmlData` 和 `setXmlData`。两者均指向同一自定义 XML 部分的内容。