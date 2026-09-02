---
title: 在 JavaScript 中管理 PowerPoint 演示文稿的敏感度标签
linktitle: 敏感度标签
type: docs
weight: 50
url: /zh/nodejs-java/sensitivity-labels/
keywords:
- 敏感度标签
- Microsoft Purview
- Microsoft Information Protection
- MIP 元数据
- 内容标记
- 信息保护
- 文档治理
- PowerPoint
- PPTX
- 演示文稿安全
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 在 PowerPoint PPTX 演示文稿中读取、添加、更新、删除和迁移 Microsoft Purview 敏感度标签。"
---
## **概述**

Microsoft Purview 敏感度标签帮助组织对文档进行分类和治理。 在自动化演示文稿处理期间，应用程序可能需要保留现有标签、应用策略选择的标签、更新其状态或迁移旧版 Microsoft Information Protection (MIP) 工作流写入的标签元数据。

Aspose.Slides for Node.js via Java 通过 [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#getSensitivityLabels) 公开现代敏感度标签元数据。 此方法返回一个 [SensitivityLabelCollection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sensitivitylabelcollection/)，可以在将演示文稿保存为 PPTX 之前检查并修改。

{{% alert color="primary" title="注意" %}}

敏感度标签标识符和策略信息由您的 Microsoft Purview 配置定义。 在添加或迁移元数据之前，请在您的环境中验证标签可用性和策略要求。 [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) 值描述与标签关联的内容标记；它们本身不会向幻灯片添加可见的文本或形状。

{{% /alert %}}

## **了解敏感度标签属性**

每个 [SensitivityLabel](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sensitivitylabel/) 包含以下元数据：

| 方法 | 用途 |
| --- | --- |
| [SensitivityLabel.getId](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sensitivitylabel/#getId) 和 [SensitivityLabel.setId](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sensitivitylabel/#setId) | 获取或设置 Purview 策略中的敏感度标签标识符。 |
| [SensitivityLabel.getSiteId](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sensitivitylabel/#getSiteId) 和 [SensitivityLabel.setSiteId](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sensitivitylabel/#setSiteId) | 获取或设置与标签策略关联的站点。 |
| [SensitivityLabel.isEnabled](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sensitivitylabel/#isEnabled) 和 [SensitivityLabel.setEnabled](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sensitivitylabel/#setEnabled) | 获取或设置标签是否已启用。 |
| [SensitivityLabel.isRemoved](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sensitivitylabel/#isRemoved) 和 [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) | 获取或设置标签是否已被移除。 当需要在元数据中保留移除状态时，将该值设为 `true`。 |
| [SensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) 和 [SensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | 获取或设置标签是自动应用还是通过用户决策应用。 |
| [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | 获取与标签关联的内容标记类型。 |

[SensitivityLabelAssignmentType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) 类定义了标签的分配方式：

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) 表示默认或自动应用的标签。
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) 表示通过用户决策应用的标签，包括手动应用、推荐和强制标签。

[SensitivityLabelContentType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) 类定义了标签关联的标记：

| 值 | 含义 |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | 标签是默认或自动应用的。 |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | 与标签关联的标记是页眉内容标记。 |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | 与标签关联的标记是页脚内容标记。 |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | 与标签关联的标记是水印内容标记。 |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | 与标签关联的标记是加密保护。 |

多个标记类型可以关联到同一个标签。

## **列出现有敏感度标签**

从 [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#getSensitivityLabels) 读取现代标签集合并枚举它。 以下示例列出每个标签存储的所有属性和内容标记：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const labelCount = sensitivityLabels.getCount();

    for (let labelIndex = 0; labelIndex < labelCount; labelIndex++) {
        const sensitivityLabel = sensitivityLabels.get_Item(labelIndex);
        const labelIdentifier = sensitivityLabel.getId();
        const siteIdentifier = sensitivityLabel.getSiteId();
        const isEnabled = sensitivityLabel.isEnabled();
        const isRemoved = sensitivityLabel.isRemoved();
        const assignmentMethod = sensitivityLabel.getAssignmentMethodType();

        console.log("Label ID: " + labelIdentifier);
        console.log("Site ID: " + siteIdentifier);
        console.log("Enabled: " + isEnabled);
        console.log("Removed: " + isRemoved);
        console.log("Assignment method: " + assignmentMethod);

        const contentMarkTypes = sensitivityLabel.getContentMarkTypes();
        const contentMarkCount = contentMarkTypes.size();

        for (let contentMarkIndex = 0; contentMarkIndex < contentMarkCount; contentMarkIndex++) {
            const contentMarkType = contentMarkTypes.get_Item(contentMarkIndex);
            console.log("Content marking: " + contentMarkType);
        }
    }
} finally {
    presentation.dispose();
}
```

## **添加带内容标记的敏感度标签**

使用 [SensitivityLabelCollection.add](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sensitivitylabelcollection/#add) 添加标签标识符、站点标识符、启用状态和分配方式。 方法返回新的 [SensitivityLabel](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sensitivitylabel/)，随后通过 [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) 返回的列表添加所需的标记值。

以下示例添加一个手动选择的标签，并关联页脚和水印标记，然后将结果保存为 PPTX：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();

    const labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    const siteIdentifier = java.callStaticMethodSync(
        "java.util.UUID",
        "fromString",
        "aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    const isEnabled = true;
    const assignmentMethod = aspose.slides.SensitivityLabelAssignmentType.Privileged;

    const sensitivityLabel = sensitivityLabels.add(
        labelIdentifier,
        siteIdentifier,
        isEnabled,
        assignmentMethod);

    const contentMarkTypes = sensitivityLabel.getContentMarkTypes();
    contentMarkTypes.addItem(aspose.slides.SensitivityLabelContentType.Footer);
    contentMarkTypes.addItem(aspose.slides.SensitivityLabelContentType.Watermark);

    presentation.save("presentation_with_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **更新敏感度标签**

[SensitivityLabel](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sensitivitylabel/) 的值均为可读写，唯一例外是通过其列表操作修改的 [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) 返回的列表。 定位到所需标签后，您可以更新其标识符、站点标识符、启用状态、分配方式、移除状态和内容标记类型。 保存演示文稿以持久化更改。

以下示例更新第一个标签的启用状态和分配方式：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const labelCount = sensitivityLabels.getCount();

    if (labelCount > 0) {
        const sensitivityLabel = sensitivityLabels.get_Item(0);
        sensitivityLabel.setEnabled(true);
        sensitivityLabel.setAssignmentMethodType(
            aspose.slides.SensitivityLabelAssignmentType.Privileged);
    }

    presentation.save("presentation_with_updated_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **将敏感度标签标记为已移除**

若需保留标签已被移除的事实，找到该标签并使用 `true` 调用 [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved)。 这会在记录其移除状态的同时保留标签条目。 若需从现代集合中删除条目，请使用 [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sensitivitylabelcollection/#removeAt)； 使用 [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sensitivitylabelcollection/#clear) 可删除所有条目。

以下示例将特定标签标记为已移除并保存更新后的演示文稿：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    const labelCount = sensitivityLabels.getCount();

    for (let labelIndex = 0; labelIndex < labelCount; labelIndex++) {
        const sensitivityLabel = sensitivityLabels.get_Item(labelIndex);
        const labelIdentifier = sensitivityLabel.getId();
        const isTargetLabel = labelIdentifier.toLowerCase() === targetLabelIdentifier.toLowerCase();

        if (isTargetLabel) {
            sensitivityLabel.setRemoved(true);
            break;
        }
    }

    presentation.save("presentation_with_removed_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **读取并迁移旧版 MIP 敏感度标签**

旧的基于 MIP 的工作流可能会将敏感度标签元数据存储在自定义文档属性中，而不是现代标签集合中。 使用 [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/documentproperties/#getSensitivityLabels) 读取这些元数据。 该方法解析旧版自定义属性并返回 [SensitivityLabel](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sensitivitylabel/) 对象数组。

要迁移元数据，请通过 [SensitivityLabelCollection.add](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sensitivitylabelcollection/#add) 将每个返回的标签添加到现代 [SensitivityLabelCollection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sensitivitylabelcollection/)。 由于添加重复的标签标识符会抛出异常，示例在复制每个标签之前会检查目标集合。 您可以添加进一步的验证，以确认每个旧标签仍然存在于当前的 Purview 策略中。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation_with_legacy_labels.pptx");
try {
    const legacySensitivityLabels = presentation.getDocumentProperties().getSensitivityLabels();
    const modernSensitivityLabels = presentation.getSensitivityLabels();

    for (let legacyLabelIndex = 0; legacyLabelIndex < legacySensitivityLabels.length; legacyLabelIndex++) {
        const legacySensitivityLabel = legacySensitivityLabels[legacyLabelIndex];
        const legacyLabelIdentifier = legacySensitivityLabel.getId();
        const modernLabelCount = modernSensitivityLabels.getCount();
        let labelAlreadyExists = false;

        for (let modernLabelIndex = 0; modernLabelIndex < modernLabelCount; modernLabelIndex++) {
            const modernSensitivityLabel = modernSensitivityLabels.get_Item(modernLabelIndex);
            const modernLabelIdentifier = modernSensitivityLabel.getId();

            labelAlreadyExists =
                modernLabelIdentifier.toLowerCase() === legacyLabelIdentifier.toLowerCase();

            if (labelAlreadyExists) {
                break;
            }
        }

        if (!labelAlreadyExists) {
            modernSensitivityLabels.add(legacySensitivityLabel);
        }
    }

    presentation.save("presentation_with_modern_labels.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

迁移会将解析后的标签对象复制到现代集合中。 它不需要清除所有自定义文档属性，因此无关的文档元数据保持完整。 使用 [Presentation.save](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#save) 并指定 [SaveFormat.Pptx](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/saveformat/) 将现代标签元数据写入 PPTX 文件。

## **常见问题**

**添加内容标记类型会在幻灯片上创建可见的页眉、页脚或水印吗？**

不会。 通过 [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) 返回的列表添加的值仅描述与敏感度标签关联的标记。 它们不会在演示文稿中创建可见的文本或形状。 若工作流需要呈现这些标记，请单独添加相应的幻灯片内容。

**将标签标记为已移除与从集合中删除它有什么区别？**

使用 `true` 调用 [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) 会保留标签条目并记录其移除状态。 使用 [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sensitivitylabelcollection/#removeAt) 会将条目从现代集合中删除。 根据组织的元数据保留要求选择相应操作。

**演示文稿可以同时包含旧版 MIP 元数据和现代敏感度标签吗？**

可以。 旧版标签可以保留在自定义文档属性中，而现代标签可通过 [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#getSensitivityLabels) 获得。 使用 [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/documentproperties/#getSensitivityLabels) 读取旧版元数据，仅迁移那些尚未出现在现代集合中的有效标签。

**当使用相同标识符的标签多次添加时会发生什么？**

当集合已包含具有相同标识符的标签时，调用 [SensitivityLabelCollection.add](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sensitivitylabelcollection/#add) 会抛出异常。 在添加或迁移标签之前，请检查 [SensitivityLabel.getId](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sensitivitylabel/#getId) 返回的现有值。

**应使用哪种输出格式来保留已更新的敏感度标签？**

如上例所示，使用 [Presentation.save](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#save) 并指定 [SaveFormat.Pptx](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/saveformat/) 将演示文稿保存为 PPTX。