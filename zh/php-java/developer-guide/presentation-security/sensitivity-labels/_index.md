---
title: 在 PHP 中管理 PowerPoint 演示文稿的敏感度标签
linktitle: 敏感度标签
type: docs
weight: 50
url: /zh/php-java/sensitivity-labels/
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
- PHP
- Aspose.Slides
description: "在 PHP 中读取、添加、更新、删除并迁移 PowerPoint PPTX 演示文稿中的 Microsoft Purview 敏感度标签。"
---
## **概述**

Microsoft Purview 敏感度标签帮助组织对文档进行分类和治理。在自动化的演示文稿处理期间，应用程序可能需要保留现有标签、应用策略选定的标签、更新其状态，或迁移由较旧的 Microsoft Information Protection（MIP）工作流写入的标签元数据。

Aspose.Slides for PHP via Java 通过 [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#getSensitivityLabels) 公开现代敏感度标签元数据。此方法返回一个 [SensitivityLabelCollection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sensitivitylabelcollection/) ，可以在演示文稿保存为 PPTX 之前检查和修改。

{{% alert color="primary" title="Note" %}}
敏感度标签标识符和策略信息由您的 Microsoft Purview 配置定义。请在添加或迁移元数据之前，在您的环境中验证标签可用性和策略要求。`SensitivityLabel::getContentMarkTypes` 的值描述了与标签关联的内容标记；它们本身不会向幻灯片添加可见的文字或形状。
{{% /alert %}}

## **理解敏感度标签属性**

每个 [SensitivityLabel](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sensitivitylabel/) 包含以下元数据：

| 方法 | 用途 |
| --- | --- |
| [SensitivityLabel::getId](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sensitivitylabel/#getId) 和 [SensitivityLabel::setId](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sensitivitylabel/#setId) | 获取或设置 Purview 策略中的敏感度标签标识符。 |
| [SensitivityLabel::getSiteId](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sensitivitylabel/#getSiteId) 和 [SensitivityLabel::setSiteId](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sensitivitylabel/#setSiteId) | 获取或设置与标签策略关联的网站。 |
| [SensitivityLabel::isEnabled](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sensitivitylabel/#isEnabled) 和 [SensitivityLabel::setEnabled](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sensitivitylabel/#setEnabled) | 获取或设置标签是否已启用。 |
| [SensitivityLabel::isRemoved](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sensitivitylabel/#isRemoved) 和 [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sensitivitylabel/#setRemoved) | 获取或设置标签是否已被移除。当必须在元数据中保留移除状态时，将该值设为 `true`。 |
| [SensitivityLabel::getAssignmentMethodType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) 和 [SensitivityLabel::setAssignmentMethodType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | 获取或设置标签是自动应用还是通过用户决定应用。 |
| [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | 获取与标签关联的内容标记类型。 |

[SensitivityLabelAssignmentType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sensitivitylabelassignmenttype/) 类定义了标签的分配方式：

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sensitivitylabelassignmenttype/) 表示默认或自动应用的标签。
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sensitivitylabelassignmenttype/) 表示通过用户决定应用的标签，包括手动应用、推荐和强制标签。

[SensitivityLabelContentType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sensitivitylabelcontenttype/) 类定义了与标签关联的标记：

| 值 | 含义 |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sensitivitylabelcontenttype/) | 标签默认或自动应用。 |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sensitivitylabelcontenttype/) | 标签关联了页眉内容标记。 |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sensitivitylabelcontenttype/) | 标签关联了页脚内容标记。 |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sensitivitylabelcontenttype/) | 标签关联了水印内容标记。 |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sensitivitylabelcontenttype/) | 标签关联了加密保护。 |

一个标签可以关联多种标记类型。

## **列出现有敏感度标签**

读取 [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#getSensitivityLabels) 返回的现代标签集合并遍历它。以下示例列出每个标签存储的所有属性和内容标记：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();
    $sensitivityLabelCount = java_values($sensitivityLabels->getCount());

    for ($labelIndex = 0; $labelIndex < $sensitivityLabelCount; $labelIndex++) {
        $sensitivityLabel = $sensitivityLabels->get_Item($labelIndex);

        echo "Label ID: " . java_values($sensitivityLabel->getId()) . PHP_EOL;
        echo "Site ID: " . java_values($sensitivityLabel->getSiteId()->toString()) . PHP_EOL;
        echo "Enabled: " . (java_values($sensitivityLabel->isEnabled()) ? "true" : "false") . PHP_EOL;
        echo "Removed: " . (java_values($sensitivityLabel->isRemoved()) ? "true" : "false") . PHP_EOL;
        echo "Assignment method: " . java_values($sensitivityLabel->getAssignmentMethodType()) . PHP_EOL;

        $contentMarkIterator = $sensitivityLabel->getContentMarkTypes()->iterator();
        while (java_values($contentMarkIterator->hasNext())) {
            $contentMarkType = java_values($contentMarkIterator->next());
            echo "Content marking: " . $contentMarkType . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **添加带内容标记的敏感度标签**

使用 [SensitivityLabelCollection::add](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sensitivitylabelcollection/#add) 并提供标签标识符、站点标识符、启用状态和分配方式。方法返回新的 [SensitivityLabel](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sensitivitylabel/) 后，使用 [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) 返回的列表添加所需的标记值。

以下示例添加一个手动选择的标签，并关联页脚和水印标记，然后将结果另存为 PPTX：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();

    $labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    $UUID = new JavaClass("java.util.UUID");
    $siteIdentifier = $UUID->fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    $isEnabled = true;
    $assignmentMethod = SensitivityLabelAssignmentType::Privileged;

    $sensitivityLabel = $sensitivityLabels->add(
        $labelIdentifier,
        $siteIdentifier,
        $isEnabled,
        $assignmentMethod
    );

    $contentMarkTypes = $sensitivityLabel->getContentMarkTypes();
    $contentMarkTypes->addItem(SensitivityLabelContentType::Footer);
    $contentMarkTypes->addItem(SensitivityLabelContentType::Watermark);

    $presentation->save("presentation_with_label.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **更新敏感度标签**

[SensitivityLabel](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sensitivitylabel/) 的属性均为读写，唯一例外是通过 [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) 返回的列表只能通过其列表操作进行修改。定位到所需标签后，可更新其标识符、站点标识符、启用状态、分配方式、移除状态以及内容标记类型。保存演示文稿以持久化更改。

以下示例更新第一个标签的启用状态和分配方式：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();
    $sensitivityLabelCount = java_values($sensitivityLabels->getCount());

    if ($sensitivityLabelCount > 0) {
        $sensitivityLabel = $sensitivityLabels->get_Item(0);
        $sensitivityLabel->setEnabled(true);
        $sensitivityLabel->setAssignmentMethodType(SensitivityLabelAssignmentType::Privileged);
    }

    $presentation->save("presentation_with_updated_label.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **将敏感度标签标记为已移除**

若要保留标签已被移除的事实，找到该标签并调用 [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sensitivitylabel/#setRemoved) 并传入 `true`。这会保留标签条目并记录其已移除状态。如果需要从现代集合中删除条目，请使用 [SensitivityLabelCollection::removeAt](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sensitivitylabelcollection/#removeAt)；使用 [SensitivityLabelCollection::clear](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sensitivitylabelcollection/#clear) 可删除所有条目。

以下示例将特定标签标记为已移除并保存更新后的演示文稿：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();
    $targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    $sensitivityLabelCount = java_values($sensitivityLabels->getCount());

    for ($labelIndex = 0; $labelIndex < $sensitivityLabelCount; $labelIndex++) {
        $sensitivityLabel = $sensitivityLabels->get_Item($labelIndex);
        $labelIdentifier = java_values($sensitivityLabel->getId());
        $isTargetLabel = strcasecmp($labelIdentifier, $targetLabelIdentifier) === 0;

        if ($isTargetLabel) {
            $sensitivityLabel->setRemoved(true);
            break;
        }
    }

    $presentation->save("presentation_with_removed_label.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **读取并迁移遗留 MIP 敏感度标签**

较旧的基于 MIP 的工作流可能会将敏感度标签元数据存储在自定义文档属性中，而不是现代标签集合中。使用 [DocumentProperties::getSensitivityLabels](https://reference.aspose.com/slides/zh/php-java/aspose.slides/documentproperties/#getSensitivityLabels) 读取这些元数据。该方法解析遗留的自定义属性并返回一个 Java 数组，其中包含 [SensitivityLabel](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sensitivitylabel/) 对象。

要迁移元数据，使用 [SensitivityLabelCollection::add](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sensitivitylabelcollection/#add) 将每个返回的标签添加到现代 [SensitivityLabelCollection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sensitivitylabelcollection/) 中。由于添加重复的标签标识符会抛出异常，示例在复制每个标签之前会检查目标集合。您可以加入进一步的验证，以确认每个遗留标签仍然存在于当前的 Purview 策略中。

```php
$presentation = new Presentation("presentation_with_legacy_labels.pptx");
try {
    $legacySensitivityLabels = $presentation->getDocumentProperties()->getSensitivityLabels();
    $modernSensitivityLabels = $presentation->getSensitivityLabels();

    $Array = new JavaClass("java.lang.reflect.Array");
    $legacyLabelCount = java_values($Array->getLength($legacySensitivityLabels));

    for ($legacyLabelIndex = 0; $legacyLabelIndex < $legacyLabelCount; $legacyLabelIndex++) {
        $legacySensitivityLabel = $legacySensitivityLabels[$legacyLabelIndex];
        $legacyLabelIdentifier = java_values($legacySensitivityLabel->getId());
        $labelAlreadyExists = false;
        $modernLabelCount = java_values($modernSensitivityLabels->getCount());

        for ($modernLabelIndex = 0; $modernLabelIndex < $modernLabelCount; $modernLabelIndex++) {
            $modernSensitivityLabel = $modernSensitivityLabels->get_Item($modernLabelIndex);
            $modernLabelIdentifier = java_values($modernSensitivityLabel->getId());
            $labelAlreadyExists = strcasecmp(
                $modernLabelIdentifier,
                $legacyLabelIdentifier
            ) === 0;

            if ($labelAlreadyExists) {
                break;
            }
        }

        if (!$labelAlreadyExists) {
            $modernSensitivityLabels->add($legacySensitivityLabel);
        }
    }

    $presentation->save("presentation_with_modern_labels.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

迁移操作会将解析后的标签对象复制到现代集合中。它不需要清除所有自定义文档属性，因此不相关的文档元数据保持完整。使用 [Presentation::save](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#save) 并结合 [SaveFormat::Pptx](https://reference.aspose.com/slides/zh/php-java/aspose.slides/saveformat/) 将现代标签元数据写入 PPTX 文件。

## **常见问题**

**添加内容标记类型会在幻灯片上创建可见的页眉、页脚或水印吗？**

不会。通过 [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) 返回的列表中添加的值仅描述与敏感度标签关联的标记。它们不会在演示文稿中创建可见的文字或形状。如果您的工作流必须呈现这些标记，请单独添加相应的幻灯片内容。

**将标签标记为已移除与从集合中删除它有什么区别？**

调用 [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sensitivitylabel/#setRemoved) 并传入 `true` 会保留标签条目并记录其已移除状态。调用 [SensitivityLabelCollection::removeAt](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sensitivitylabelcollection/#removeAt) 会从现代集合中删除该条目。请选择符合组织元数据保留要求的操作。

**演示文稿可以同时包含遗留 MIP 元数据和现代敏感度标签吗？**

可以。遗留标签可以保留在自定义文档属性中，而现代标签则通过 [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#getSensitivityLabels) 可用。使用 [DocumentProperties::getSensitivityLabels](https://reference.aspose.com/slides/zh/php-java/aspose.slides/documentproperties/#getSensitivityLabels) 读取遗留元数据，并仅迁移那些在现代集合中尚未存在的有效标签。

**当同一标识符的标签被多次添加会发生什么？**

[SensitivityLabelCollection::add](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sensitivitylabelcollection/#add) 会在集合已包含相同标识符的标签时抛出异常。添加或迁移标签前，请先检查通过 [SensitivityLabel::getId](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sensitivitylabel/#getId) 返回的现有值。

**应使用哪种输出格式来保留已更新的敏感度标签？**

如上例所示，使用 [Presentation::save](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#save) 并指定 [SaveFormat::Pptx](https://reference.aspose.com/slides/zh/php-java/aspose.slides/saveformat/) 将演示文稿保存为 PPTX，即可保留更新后的敏感度标签。