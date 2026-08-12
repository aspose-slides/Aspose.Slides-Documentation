---
title: 在 Python 中管理 PowerPoint 演示文稿的敏感度标签
linktitle: 敏感度标签
type: docs
weight: 50
url: /zh/python-net/sensitivity-labels/
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
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 读取、添加、更新、移除和迁移 PowerPoint PPTX 演示文稿中的 Microsoft Purview 敏感度标签。"
---
## **概览**

Microsoft Purview 敏感度标签帮助组织对文档进行分类和治理。在自动化的演示处理过程中，应用程序可能需要保留现有标签、应用策略选择的标签、更新其状态，或迁移由较旧的 Microsoft Information Protection（MIP）工作流写入的标签元数据。

Aspose.Slides for Python via .NET 通过 [Presentation.sensitivity_labels](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/sensitivity_labels/) 暴露现代敏感度标签元数据。此属性返回一个 [SensitivityLabelCollection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/sensitivitylabelcollection/)，可在保存为 PPTX 之前进行检查和修改。

{{% alert color="primary" title="Note" %}}
敏感度标签标识符和策略信息由您的 Microsoft Purview 配置定义。在添加或迁移元数据之前，请在您的环境中验证标签的可用性和策略要求。[SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/zh/python-net/aspose.slides/sensitivitylabel/content_mark_types/) 值描述与标签关联的内容标记；它们本身并不会在幻灯片上添加可见的文本或形状。
{{% /alert %}}

## **了解敏感度标签属性**

每个 [SensitivityLabel](https://reference.aspose.com/slides/zh/python-net/aspose.slides/sensitivitylabel/) 包含以下元数据：

| 属性 | 用途 |
| --- | --- |
| [SensitivityLabel.id](https://reference.aspose.com/slides/zh/python-net/aspose.slides/sensitivitylabel/id/) | 标识 Purview 策略中的敏感度标签。 |
| [SensitivityLabel.site_id](https://reference.aspose.com/slides/zh/python-net/aspose.slides/sensitivitylabel/site_id/) | 标识与标签策略关联的网站。 |
| [SensitivityLabel.is_enabled](https://reference.aspose.com/slides/zh/python-net/aspose.slides/sensitivitylabel/is_enabled/) | 指示标签是否已启用。 |
| [SensitivityLabel.is_removed](https://reference.aspose.com/slides/zh/python-net/aspose.slides/sensitivitylabel/is_removed/) | 指示标签已被移除。当必须在元数据中保留移除状态时，将此属性设置为 `True`。 |
| [SensitivityLabel.assignment_method_type](https://reference.aspose.com/slides/zh/python-net/aspose.slides/sensitivitylabel/assignment_method_type/) | 指定标签是自动应用的还是通过用户决定应用的。 |
| [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/zh/python-net/aspose.slides/sensitivitylabel/content_mark_types/) | 列出与标签关联的内容标记类型。 |

[SensitivityLabelAssignmentType](https://reference.aspose.com/slides/zh/python-net/aspose.slides/sensitivitylabelassignmenttype/) 枚举描述标签的分配方式：

- [SensitivityLabelAssignmentType.STANDARD](https://reference.aspose.com/slides/zh/python-net/aspose.slides/sensitivitylabelassignmenttype/) 表示默认或自动应用的标签。
- [SensitivityLabelAssignmentType.PRIVILEGED](https://reference.aspose.com/slides/zh/python-net/aspose.slides/sensitivitylabelassignmenttype/) 表示通过用户决策应用的标签，包括手动应用、推荐和强制标签。

[SensitivityLabelContentType](https://reference.aspose.com/slides/zh/python-net/aspose.slides/sensitivitylabelcontenttype/) 枚举标识与标签关联的标记：

| 值 | 含义 |
| --- | --- |
| [SensitivityLabelContentType.NONE](https://reference.aspose.com/slides/zh/python-net/aspose.slides/sensitivitylabelcontenttype/) | 标签是默认或自动应用的。 |
| [SensitivityLabelContentType.HEADER](https://reference.aspose.com/slides/zh/python-net/aspose.slides/sensitivitylabelcontenttype/) | 标签关联了页眉内容标记。 |
| [SensitivityLabelContentType.FOOTER](https://reference.aspose.com/slides/zh/python-net/aspose.slides/sensitivitylabelcontenttype/) | 标签关联了页脚内容标记。 |
| [SensitivityLabelContentType.WATERMARK](https://reference.aspose.com/slides/zh/python-net/aspose.slides/sensitivitylabelcontenttype/) | 标签关联了水印内容标记。 |
| [SensitivityLabelContentType.ENCRYPTION](https://reference.aspose.com/slides/zh/python-net/aspose.slides/sensitivitylabelcontenttype/) | 标签关联了加密保护。 |

一个标签可以关联多种标记类型。

## **列出现有敏感度标签**

从 [Presentation.sensitivity_labels](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/sensitivity_labels/) 读取现代标签集合并遍历它。以下示例列出了每个标签存储的所有属性和内容标记：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    for sensitivity_label in sensitivity_labels:
        print("Label ID:", sensitivity_label.id)
        print("Site ID:", sensitivity_label.site_id)
        print("Enabled:", sensitivity_label.is_enabled)
        print("Removed:", sensitivity_label.is_removed)
        print("Assignment method:", sensitivity_label.assignment_method_type)

        for content_mark_type in sensitivity_label.content_mark_types:
            print("Content marking:", content_mark_type)
```

## **添加带内容标记的敏感度标签**

使用 [SensitivityLabelCollection.add](https://reference.aspose.com/slides/zh/python-net/aspose.slides/sensitivitylabelcollection/add/)，提供标签标识符、站点标识符、启用状态和分配方式。将站点标识符作为 Python `uuid.UUID` 对象传递。方法返回新的 [SensitivityLabel](https://reference.aspose.com/slides/zh/python-net/aspose.slides/sensitivitylabel/) 后，将所需的标记值追加到 [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/zh/python-net/aspose.slides/sensitivitylabel/content_mark_types/)。

以下示例添加一个手动选择的标签，并关联页脚和水印标记，然后将结果保存为 PPTX：

```python
import uuid
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    label_identifier = "{11111111-2222-3333-4444-555555555555}"
    site_identifier = uuid.UUID("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee")
    is_enabled = True
    assignment_method = slides.SensitivityLabelAssignmentType.PRIVILEGED

    sensitivity_label = sensitivity_labels.add(
        label_identifier,
        site_identifier,
        is_enabled,
        assignment_method
    )

    sensitivity_label.content_mark_types.append(slides.SensitivityLabelContentType.FOOTER)
    sensitivity_label.content_mark_types.append(slides.SensitivityLabelContentType.WATERMARK)

    presentation.save("presentation_with_label.pptx", slides.export.SaveFormat.PPTX)
```

## **更新敏感度标签**

[SensitivityLabel](https://reference.aspose.com/slides/zh/python-net/aspose.slides/sensitivitylabel/) 的属性可读写，唯一例外是通过 [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/zh/python-net/aspose.slides/sensitivitylabel/content_mark_types/) 返回的列表只能通过其列表操作进行修改。定位到所需标签后，您可以更新其标识符、站点标识符、启用状态、分配方式、移除状态以及内容标记类型。保存演示文稿以持久化更改。

以下示例更新第一个标签的启用状态和分配方式：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    if sensitivity_labels.count > 0:
        sensitivity_label = sensitivity_labels[0]
        sensitivity_label.is_enabled = True
        sensitivity_label.assignment_method_type = (
            slides.SensitivityLabelAssignmentType.PRIVILEGED
        )

    presentation.save("presentation_with_updated_label.pptx", slides.export.SaveFormat.PPTX)
```

## **将敏感度标签标记为已移除**

为了保留标签已被移除的事实，找到该标签并将 [SensitivityLabel.is_removed](https://reference.aspose.com/slides/zh/python-net/aspose.slides/sensitivitylabel/is_removed/) 设置为 `True`。这会保留标签条目并记录其移除状态。如果需要从现代集合中删除条目，请使用 [SensitivityLabelCollection.remove_at](https://reference.aspose.com/slides/zh/python-net/aspose.slides/sensitivitylabelcollection/remove_at/)；使用 [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/zh/python-net/aspose.slides/sensitivitylabelcollection/clear/) 可删除所有条目。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels
    target_label_identifier = "{11111111-2222-3333-4444-555555555555}"

    for sensitivity_label in sensitivity_labels:
        identifiers_match = (
            sensitivity_label.id.casefold() == target_label_identifier.casefold()
        )

        if identifiers_match:
            sensitivity_label.is_removed = True
            break

    presentation.save("presentation_with_removed_label.pptx", slides.export.SaveFormat.PPTX)
```

## **读取并迁移旧版 MIP 敏感度标签**

较旧的基于 MIP 的工作流可能将敏感度标签元数据存储在自定义文档属性中，而不是现代标签集合。使用 [DocumentProperties.get_sensitivity_labels](https://reference.aspose.com/slides/zh/python-net/aspose.slides/documentproperties/get_sensitivity_labels/) 读取这些元数据。该方法解析旧版自定义属性并返回 [SensitivityLabel](https://reference.aspose.com/slides/zh/python-net/aspose.slides/sensitivitylabel/) 对象。

要迁移元数据，使用 [SensitivityLabelCollection.add](https://reference.aspose.com/slides/zh/python-net/aspose.slides/sensitivitylabelcollection/add/) 将每个返回的标签添加到现代 [SensitivityLabelCollection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/sensitivitylabelcollection/)。由于添加重复的标签标识符会抛出异常，示例在复制每个标签之前先检查目标集合。您可以进一步验证，以确认每个旧标签仍在当前 Purview 策略中存在。

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_legacy_labels.pptx") as presentation:
    legacy_sensitivity_labels = (
        presentation.document_properties.get_sensitivity_labels()
    )
    modern_sensitivity_labels = presentation.sensitivity_labels

    for legacy_sensitivity_label in legacy_sensitivity_labels:
        label_already_exists = False

        for modern_sensitivity_label in modern_sensitivity_labels:
            label_already_exists = (
                modern_sensitivity_label.id.casefold()
                == legacy_sensitivity_label.id.casefold()
            )

            if label_already_exists:
                break

        if not label_already_exists:
            modern_sensitivity_labels.add(legacy_sensitivity_label)

    presentation.save("presentation_with_modern_labels.pptx", slides.export.SaveFormat.PPTX)
```

迁移过程将解析后的标签对象复制到现代集合中。此操作不需要清除所有自定义文档属性，因此无关的文档元数据保持完整。使用 [Presentation.save](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/save/) 与 [SaveFormat.PPTX](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/saveformat/) 将现代标签元数据写入 PPTX 文件。

## **常见问题**

**添加内容标记类型会在幻灯片上创建可见的页眉、页脚或水印吗？**

否。通过 [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/zh/python-net/aspose.slides/sensitivitylabel/content_mark_types/) 添加的值仅描述与敏感度标签关联的标记，它们不会在演示文稿中创建可见的文本或形状。如果工作流必须呈现这些标记，需要单独添加相应的幻灯片内容。

**将标签标记为已移除与从集合中删除它有何区别？**

将 [SensitivityLabel.is_removed](https://reference.aspose.com/slides/zh/python-net/aspose.slides/sensitivitylabel/is_removed/) 设置为 `True` 会保留标签条目并记录其移除状态。调用 [SensitivityLabelCollection.remove_at](https://reference.aspose.com/slides/zh/python-net/aspose.slides/sensitivitylabelcollection/remove_at/) 会从现代集合中删除该条目。请选择符合组织元数据保留要求的操作。

**演示文稿可以同时包含旧版 MIP 元数据和现代敏感度标签吗？**

可以。旧版标签可以保留在自定义文档属性中，而现代标签通过 [Presentation.sensitivity_labels](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/sensitivity_labels/) 可用。使用 [DocumentProperties.get_sensitivity_labels](https://reference.aspose.com/slides/zh/python-net/aspose.slides/documentproperties/get_sensitivity_labels/) 读取旧版元数据，并仅迁移那些尚未出现在现代集合中的有效标签。

**当使用相同标识符的标签多次添加时会发生什么？**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/zh/python-net/aspose.slides/sensitivitylabelcollection/add/) 在集合已包含相同标识符的标签时会抛出异常。添加或迁移标签前，请检查现有的 [SensitivityLabel.id](https://reference.aspose.com/slides/zh/python-net/aspose.slides/sensitivitylabel/id/) 值。

**应使用哪种输出格式来保留更新后的敏感度标签？**

使用 [Presentation.save](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/save/) 并指定 [SaveFormat.PPTX](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/saveformat/) 将演示文稿保存为 PPTX，以保留更新后的敏感度标签，如前面的示例所示。