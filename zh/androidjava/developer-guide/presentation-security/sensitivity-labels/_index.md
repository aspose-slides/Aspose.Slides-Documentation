---
title: 管理 Android 上 PowerPoint 演示文稿的敏感度标签
linktitle: 敏感度标签
type: docs
weight: 50
url: /zh/androidjava/sensitivity-labels/
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
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 在 PowerPoint PPTX 演示文稿中读取、添加、更新、删除和迁移 Microsoft Purview 敏感度标签。"
---
## **概述**

Microsoft Purview 敏感度标签帮助组织对文档进行分类和治理。在自动化演示文稿处理期间，应用程序可能需要保留现有标签、应用策略选择的标签、更新其状态，或迁移由旧版 Microsoft Information Protection（MIP）工作流写入的标签元数据。

Aspose.Slides for Android via Java 通过 [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides.ipresentation/#getSensitivityLabels--) 提供现代敏感度标签元数据。此方法返回一个 [ISensitivityLabelCollection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides.isensitivitylabelcollection/)，可在保存为 PPTX 之前进行检查和修改。

{{% alert color="primary" title="Note" %}}
敏感度标签标识符和策略信息由您的 Microsoft Purview 配置定义。在添加或迁移元数据之前，请在您的环境中验证标签可用性和策略要求。[ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides.isensitivitylabel/#getContentMarkTypes--) 的值描述与标签关联的内容标记；它们本身不会向幻灯片添加可见文本或形状。
{{% /alert %}}

## **了解敏感度标签属性**

每个 [ISensitivityLabel](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides.isensitivitylabel/) 包含以下元数据：

| 方法 | 用途 |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides.isensitivitylabel/#getId--) 和 [ISensitivityLabel.setId](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides.isensitivitylabel/#setId-java.lang.String-) | 获取或设置 Purview 策略中的敏感度标签标识符。 |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides.isensitivitylabel/#getSiteId--) 和 [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides.isensitivitylabel/#setSiteId-java.util.UUID-) | 获取或设置与标签策略关联的网站标识符。 |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides.isensitivitylabel/#isEnabled--) 和 [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides.isensitivitylabel/#setEnabled-boolean-) | 获取或设置标签是否已启用。 |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides.isensitivitylabel/#isRemoved--) 和 [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides.isensitivitylabel/#setRemoved-boolean-) | 获取或设置标签是否已被移除。当必须在元数据中保留移除状态时，将该值设为 `true`。 |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides.isensitivitylabel/#getAssignmentMethodType--) 和 [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides.isensitivitylabel/#setAssignmentMethodType-int-) | 获取或设置标签是自动应用还是通过用户决策应用。 |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides.isensitivitylabel/#getContentMarkTypes--) | 获取与标签关联的内容标记类型。 |

[SensitivityLabelAssignmentType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides.sensitivitylabelassignmenttype/) 类定义了标签的分配方式：

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides.sensitivitylabelassignmenttype/) 表示默认或自动应用的标签。
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides.sensitivitylabelassignmenttype/) 表示通过用户决策应用的标签，包括手动、推荐和强制标签。

[SensitivityLabelContentType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides.sensitivitylabelcontenttype/) 类定义了标签关联的标记：

| 值 | 含义 |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides.sensitivitylabelcontenttype/) | 标签是默认或自动应用的。 |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides.sensitivitylabelcontenttype/) | 与标签关联的标记为页眉内容。 |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides.sensitivitylabelcontenttype/) | 与标签关联的标记为页脚内容。 |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides.sensitivitylabelcontenttype/) | 与标签关联的标记为水印内容。 |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides.sensitivitylabelcontenttype/) | 与标签关联的标记为加密保护。 |

一个标签可以关联多种标记类型。

## **列出现有敏感度标签**

通过 [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides.ipresentation/#getSensitivityLabels--) 读取现代标签集合并遍历它。以下示例列出每个标签存储的所有属性和内容标记：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    for (ISensitivityLabel sensitivityLabel : sensitivityLabels) {
        System.out.println("Label ID: " + sensitivityLabel.getId());
        System.out.println("Site ID: " + sensitivityLabel.getSiteId());
        System.out.println("Enabled: " + sensitivityLabel.isEnabled());
        System.out.println("Removed: " + sensitivityLabel.isRemoved());
        System.out.println("Assignment method: " + sensitivityLabel.getAssignmentMethodType());

        for (Integer contentMarkType : sensitivityLabel.getContentMarkTypes()) {
            System.out.println("Content marking: " + contentMarkType);
        }
    }
} finally {
    presentation.dispose();
}
```

## **添加带内容标记的敏感度标签**

使用 [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides.isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) 并提供标签标识符、站点标识符、启用状态以及分配方式。方法返回新的 [ISensitivityLabel](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides.isensitivitylabel/)，随后通过 [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides.isensitivitylabel/#getContentMarkTypes--) 返回的列表添加所需的标记值。

以下示例添加一个手动选择、关联页脚和水印标记的标签，然后将结果保存为 PPTX：

```java
import com.aspose.slides.*;
import java.util.UUID;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    String labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    UUID siteIdentifier = UUID.fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    boolean isEnabled = true;
    int assignmentMethod = SensitivityLabelAssignmentType.Privileged;

    ISensitivityLabel sensitivityLabel = sensitivityLabels.add(
            labelIdentifier,
            siteIdentifier,
            isEnabled,
            assignmentMethod);

    sensitivityLabel.getContentMarkTypes().addItem(SensitivityLabelContentType.Footer);
    sensitivityLabel.getContentMarkTypes().addItem(SensitivityLabelContentType.Watermark);

    presentation.save("presentation_with_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **更新敏感度标签**

[ISensitivityLabel](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides.isensitivitylabel/) 的值均可读写，除 [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides.isensitivitylabel/#getContentMarkTypes--) 返回的列表需通过列表操作进行修改外。定位到所需标签后，可更新其标识符、站点标识符、启用状态、分配方式、移除状态以及内容标记类型。保存演示文稿以持久化更改。

以下示例更新第一个标签的启用状态和分配方式：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    if (sensitivityLabels.getCount() > 0) {
        ISensitivityLabel sensitivityLabel = sensitivityLabels.get_Item(0);
        sensitivityLabel.setEnabled(true);
        sensitivityLabel.setAssignmentMethodType(SensitivityLabelAssignmentType.Privileged);
    }

    presentation.save("presentation_with_updated_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **将敏感度标签标记为已移除**

若要保留标签已被移除的事实，找到该标签并调用 [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides.isensitivitylabel/#setRemoved-boolean-) 并传入 `true`。这会保留标签条目并记录其已移除状态。如果需要从现代集合中删除条目，可使用 [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides.isensitivitylabelcollection/#removeAt-int-)；使用 [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides.isensitivitylabelcollection/#clear--) 可删除所有条目。

以下示例将特定标签标记为已移除并保存更新后的演示文稿：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();
    String targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";

    for (ISensitivityLabel sensitivityLabel : sensitivityLabels) {
        boolean isTargetLabel = sensitivityLabel.getId().equalsIgnoreCase(targetLabelIdentifier);

        if (isTargetLabel) {
            sensitivityLabel.setRemoved(true);
            break;
        }
    }

    presentation.save("presentation_with_removed_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **读取并迁移旧版 MIP 敏感度标签**

旧版基于 MIP 的工作流可能将敏感度标签元数据存储在自定义文档属性中，而不是现代标签集合中。使用 [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides.idocumentproperties/#getSensitivityLabels--) 读取该元数据。该方法解析旧版自定义属性并返回一个 [ISensitivityLabel](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides.isensitivitylabel/) 对象数组。

要迁移元数据，使用 [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides.isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-) 将每个返回的标签添加到现代 [ISensitivityLabelCollection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides.isensitivitylabelcollection/)。由于添加重复的标签标识符会抛出异常，示例在复制每个标签之前会检查目标集合。您还可以添加进一步的验证，以确认每个旧标签在当前 Purview 策略中仍然有效。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation_with_legacy_labels.pptx");
try {
    ISensitivityLabel[] legacySensitivityLabels = presentation.getDocumentProperties().getSensitivityLabels();
    ISensitivityLabelCollection modernSensitivityLabels = presentation.getSensitivityLabels();

    for (ISensitivityLabel legacySensitivityLabel : legacySensitivityLabels) {
        boolean labelAlreadyExists = false;

        for (ISensitivityLabel modernSensitivityLabel : modernSensitivityLabels) {
            labelAlreadyExists = modernSensitivityLabel.getId().equalsIgnoreCase(
                    legacySensitivityLabel.getId());

            if (labelAlreadyExists) {
                break;
            }
        }

        if (!labelAlreadyExists) {
            modernSensitivityLabels.add(legacySensitivityLabel);
        }
    }

    presentation.save("presentation_with_modern_labels.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

迁移会将解析后的标签对象复制到现代集合中。它不需要清除所有自定义文档属性，因此与文档无关的元数据保持完整。使用 [IPresentation.save](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides.ipresentation/#save-java.lang.String-int-) 并指定 [SaveFormat.Pptx](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides.saveformat/) 将现代标签元数据写入 PPTX 文件。

## **常见问题**

**添加内容标记类型会在幻灯片上创建可见的页眉、页脚或水印吗？**

不会。通过 [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides.isensitivitylabel/#getContentMarkTypes--) 返回的列表所添加的值仅描述与敏感度标签关联的标记，它们不会在演示文稿中创建可见的文本或形状。如果工作流需要渲染这些标记，需要单独添加相应的幻灯片内容。

**将标签标记为已移除与从集合中删除它有什么区别？**

调用 [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides.isensitivitylabel/#setRemoved-boolean-) 并传入 `true` 会保留标签条目并记录其已移除状态。调用 [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides.isensitivitylabelcollection/#removeAt-int-) 会从现代集合中删除该条目。请选择符合组织元数据保留要求的操作。

**演示文稿可以同时包含旧版 MIP 元数据和现代敏感度标签吗？**

可以。旧版标签可以保留在自定义文档属性中，而现代标签则通过 [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides.ipresentation/#getSensitivityLabels--) 获取。使用 [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides.idocumentproperties/#getSensitivityLabels--) 读取旧版元数据，并仅迁移那些在现代集合中尚不存在的有效标签。

**当相同标识符的标签被多次添加会发生什么？**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides.isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) 在集合已包含相同标识符的标签时会抛出异常。添加或迁移标签前，请先检查 [ISensitivityLabel.getId](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides.isensitivitylabel/#getId--) 返回的现有值。

**应使用哪种输出格式来保留已更新的敏感度标签？**

如前例所示，使用 [IPresentation.save](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides.ipresentation/#save-java.lang.String-int-) 并指定 [SaveFormat.Pptx](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides.saveformat/) 将演示文稿保存为 PPTX，以保留更新后的敏感度标签。