---
title: 在 Android 上管理演示文稿中的标签和自定义数据
linktitle: 标签和自定义数据
type: docs
weight: 300
url: /zh/androidjava/managing-tags-and-custom-data
keywords:
- 文档属性
- 标签
- 自定义数据
- 自定义 XML
- 自定义 XML 部分
- XML 元数据
- ItemId
- 添加标签
- 成对值
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Android via Java 在 PowerPoint 演示文稿中管理标签和自定义 XML 数据，包括添加、读取、更新、审计和删除自定义 XML 部分。"
---
## **概述**

本文说明了 Aspose.Slides 如何在 PowerPoint 演示文稿中使用标签和自定义数据。演示文稿特定的数据可以存储为标签或自定义 XML 部分。标签是简单的键值字符串对，而自定义 XML 部分可以存储结构化的元数据和应用程序特定的 XML 负载。

Aspose.Slides 提供了在演示文稿、幻灯片和形状级别添加、读取、更新、审计和删除自定义 XML 部分的 API。自定义 XML 部分对于需要在演示文稿中存储如文档管理标识、工作流状态、合规元数据、模板绑定数据或其他结构化应用数据的集成非常有用。

## **演示文件中的数据存储**

PPTX 文件（扩展名为 `.pptx`）采用 PresentationML 格式存储，是 Office Open XML 规范的一部分。Office Open XML 定义了用于存储演示内容及相关数据的包结构和关系。

一个演示文稿包含通过关系连接的多个部件。例如，幻灯片部件包含单个幻灯片的内容，并可以通过 ISO/IEC 29500 定义的显式关系链接到其他部件。

自定义数据可以存储为标签（[ITagCollection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ITagCollection)）或自定义 XML 部分（[ICustomXmlPartCollection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ICustomXmlPartCollection)）。两者均通过 [`ICustomData`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ICustomData/) 接口访问。

{{% alert color="info" %}}
标签存储简单的字符串键值对。自定义 XML 部分存储结构化的 XML 数据，可与演示文稿、幻灯片或形状关联。
{{% /alert %}}

## **使用自定义 XML 部分**

[`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ICustomData#getCustomXmlParts--) 方法返回与特定演示对象关联的自定义 XML 部分集合。例如：

- `presentation.getCustomData().getCustomXmlParts()` 包含与演示本身关联的自定义 XML 部分。
- `slide.getCustomData().getCustomXmlParts()` 包含与特定幻灯片关联的自定义 XML 部分。
- `shape.getCustomData().getCustomXmlParts()` 包含与特定形状关联的自定义 XML 部分。

在需要检查演示文稿中所有自定义 XML 部分（无论其关联对象）的情况下，请使用 [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--)。

### **向演示添加自定义 XML 部分**

使用 [`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) 向自定义 XML 部分集合添加 XML 数据。XML 必须有效且非空。

以下示例将结构化元数据添加到演示级自定义数据集合：

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

    // add 自动分配标识符。仅在需要时设置特定的 UUID。
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`add` 方法也可以接受字节数组或输入流形式的 XML，这在 XML 内容已以二进制形式可用时非常有用。

### **向幻灯片或形状添加自定义 XML 部分**

自定义 XML 数据可以关联到特定幻灯片或形状，而不是整个演示文稿。当元数据仅描述单个对象（如模板键、外部记录标识或绑定信息）时，这很有用。

以下示例向一个幻灯片添加一个自定义 XML 部分，向一个形状添加另一个自定义 XML 部分：

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

添加部件的层级决定了哪个对象的 `getCustomData().getCustomXmlParts()` 集合包含对该部件的关系。演示级数据适用于文档范围的元数据，幻灯片级数据适用于特定幻灯片的信息，形状级数据适用于单个形状的元数据。

### **列出并审计所有自定义 XML 部分**

使用 [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) 检索演示文稿中的所有自定义 XML 部分。每个 [`ICustomXmlPart`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ICustomXmlPart/) 都会公开其标识符、XML 内容以及关联的命名空间模式。

以下示例列出所有自定义 XML 部分及其命名空间模式：

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

[`ICustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ICustomXmlPart#getNamespaceSchemas--) 返回与该自定义 XML 部分关联的 XML 模式。审计包含外部系统生成 XML 的演示文稿时，此信息非常有价值。

### **读取和更新 XML 内容及 ItemId**

使用 [`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ICustomXmlPart#getXmlAsString--) 和 [`setXmlAsString()`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) 以 UTF-8 字符串形式处理 XML，或使用 [`getXmlData()`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ICustomXmlPart#getXmlData--) 和 [`setXmlData()`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) 处理原始 XML 字节。

[`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ICustomXmlPart#getItemId--) 方法返回在 Office Open XML 文档中标识该自定义 XML 部件的 UUID。需要新标识符时，可使用 [`setItemId()`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-)。

以下示例更新 XML 内容并更改标识符：

```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.util.UUID;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ICustomXmlPart customXmlPart = presentation.getAllCustomXmlParts()[0];

    // 读取当前 XML 为文本。
    String currentXmlContent = customXmlPart.getXmlAsString();
    System.out.println(currentXmlContent);

    // 将 XML 更新为 UTF-8 字符串。
    customXmlPart.setXmlAsString(
        "<metadata xmlns=\"urn:example:metadata\">" +
            "<documentId>DOC-1001</documentId>" +
            "<workflowState>Approved</workflowState>" +
        "</metadata>");

    // getXmlData 提供相同的 XML 内容，以原始字节形式。
    byte[] customXmlData = customXmlPart.getXmlData();
    System.out.println(new String(customXmlData, StandardCharsets.UTF_8));

    // 在集成需要时替换标识符。
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

调用 `setXmlAsString` 或 `setXmlData` 时，请提供有效且非空的 XML。根据应用主要处理字符串还是字节数据选择相应的表示方式。

### **删除自定义 XML 部分**

Aspose.Slides 提供多种方式删除自定义 XML 数据：

- [`ICustomXmlPart.remove`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ICustomXmlPart#remove--) 从演示文稿中删除该自定义 XML 部分。
- [`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-) 从自定义 XML 部分集合中删除指定部件。
- [`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ICustomXmlPartCollection#removeAt-int--) 删除集合中指定索引处的部件。
- [`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ICustomXmlPartCollection#clear--) 删除特定集合中的所有部件。

以下示例按引用删除一个演示级自定义 XML 部分：

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

如果已经拥有 `ICustomXmlPart` 实例并希望直接从演示文稿中删除该部件，而不是针对特定集合操作，请调用 `customXmlPart.remove()`。

也可以按索引删除项目：

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **清除集合中的所有自定义 XML 部分**

当需要删除与特定演示对象关联的全部自定义 XML 部分时，请使用 `clear`。

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

`clear` 只影响所选集合。例如，清除幻灯片的集合并不会清除演示级或形状级集合。

若要删除演示文稿中的所有自定义 XML 部分，可遍历 `getAllCustomXmlParts()` 并逐一删除：

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

### **处理链接或共享的自定义 XML 部分**

在 Office Open XML 演示文稿中，同一个自定义 XML 部分可以被多个演示对象引用。例如，同一文件可能包含多个幻灯片或形状指向同一底层自定义 XML 部分的关系。

共享部件应视为拥有多个引用的单一数据对象：

- 使用 `setXmlAsString`、`setXmlData` 或 `setItemId` 更新时，会修改底层自定义 XML 部分，因而所有引用该部件的对象都会看到更改。
- `getItemId()` 可用于在审计对象级集合时识别相同的自定义 XML 部件。
- 从特定 `getCustomXmlParts()` 集合中删除部件，只会从该集合中移除。若需在演示文稿中彻底删除该部件，请使用 `ICustomXmlPart.remove()`。
- 在删除或替换共享部件之前，请检查对象级集合，以确定是否还有其他幻灯片或形状引用它。

`add` 重载会从 XML 内容创建新自定义 XML 部件，不接受已有的 `ICustomXmlPart`。因此，通常在加载已包含共享关系的演示文稿时会遇到此类情况。

以下示例按 `ItemId` 审计演示、幻灯片和形状级集合，并报告被多个位置引用的部件：

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

此类审计在修改或删除由外部系统生成的演示文稿中的自定义 XML 数据之前非常有用，因为相同的元数据部件可能参与多个关系。

## **获取标签的值**

在 Slides 中，标签对应 `IDocumentProperties.getKeywords()` 方法。以下示例代码展示了如何使用 Aspose.Slides for Android via Java 获取 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/Presentation) 的标签值：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    String keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **向演示添加标签**

Aspose.Slides 允许向演示文稿添加标签。标签通常由两部分组成：

- 自定义属性的名称，例如 `MyTag`；
- 自定义属性的值，例如 `My Tag Value`。

如果需要根据特定规则或属性对演示文稿进行分类，可以添加相应的标签。例如，要对来自北美国家的演示文稿进行分类，可创建一个北美标签并将相关国家设为其值。

以下示例代码演示如何使用 Aspose.Slides for Android via Java 向 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/Presentation) 添加标签：

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

标签也可以为 [Slide](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ISlide) 设置：

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

或为单个 [Shape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IAutoShape) 设置：

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

### **限制**

通过 `getCustomData().getTags()` 集合添加的标签仅存储在 PowerPoint 文件中。导出为 PDF 时，它们 **不会** 转移到 PDF 的标签结构中。因此，作为标签分配的自定义标识符无法从带标签的 PDF 中检索。

**变通方法**：可以将自定义标识符存储在对象的 **Alt Text** 中（例如 `shape.setAlternativeText("MyId")`）。导出为 PDF 后，Alt Text 可能会出现在 PDF 的标签结构中。

## **常见问题**

**我可以一次性删除演示、幻灯片或形状中的所有标签吗？**

可以。[tag collection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/tagcollection/) 支持 [clear](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/tagcollection/#clear--) 操作，一次性删除所有键值对。

**如何仅凭标签名称删除单个标签，而无需遍历整个集合？**

对 [tag collection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/tagcollection/) 使用 [remove(name)](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/tagcollection/#remove-java.lang.String-) 即可按键删除标签。

**如何获取完整的标签名称列表以进行分析或过滤？**

使用 [getNamesOfTags](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/tagcollection/#getNamesOfTags--) 可返回所有标签名称的数组。

**如何查找所有自定义 XML 部分，无论它们存储在哪里？**

使用 [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) 可检索演示文稿中的全部自定义 XML 部分。

**在更新自定义 XML 部分时，我应该使用 `getXmlAsString`/`setXmlAsString` 还是 `getXmlData`/`setXmlData`？**

当应用主要处理 UTF-8 XML 文本时，使用 `getXmlAsString` 和 `setXmlAsString`。当 XML 已以字节数组形式存在或二进制处理更方便时，使用 `getXmlData` 和 `setXmlData`。两种表示方式都指向同一自定义 XML 部分的内容。