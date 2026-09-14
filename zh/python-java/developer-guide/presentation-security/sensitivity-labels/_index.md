---
title: 在 Python 中管理 PowerPoint 演示文稿的敏感度标签
linktitle: 敏感度标签
type: docs
weight: 50
url: /zh/python-java/sensitivity-labels/
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
description: "使用 Aspose.Slides for Python via Java，读取、添加、更新、删除并迁移 PowerPoint PPTX 演示文稿中的 Microsoft Purview 敏感度标签。"
---
## **概述**

Microsoft Purview 敏感度标签帮助组织对文档进行分类和治理。在自动化演示处理过程中，应用程序可能需要保留现有标签、应用策略选择的标签、更新其状态，或迁移由较旧的 Microsoft Information Protection（MIP）工作流写入的标签元数据。

Aspose.Slides 通过[Presentation.getSensitivityLabels](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getSensitivityLabels)公开现代敏感度标签元数据。此方法返回一个[SensitivityLabelCollection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sensitivitylabelcollection/)，可在将演示文稿保存为 PPTX 之前检查和修改。

{{% alert color="info" title="Note" %}}
敏感度标签标识符和策略信息由您的 Microsoft Purview 配置定义。在添加或迁移元数据之前，请在您的环境中验证标签可用性和策略要求。[SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) 的值描述了与标签关联的内容标记；它们本身不会向幻灯片添加可见的文本或形状。
{{% /alert %}}

## **了解敏感度标签属性**

每个[SensitivityLabel](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sensitivitylabel/)包含以下元数据：

| 方法 | 用途 |
| --- | --- |
| [getId](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sensitivitylabel/#getId) 和 [setId](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sensitivitylabel/#setId) | 获取或设置 Purview 策略中的敏感度标签标识符。 |
| [getSiteId](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sensitivitylabel/#getSiteId) 和 [setSiteId](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sensitivitylabel/#setSiteId) | 获取或设置与标签策略关联的站点。 |
| [isEnabled](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sensitivitylabel/#isEnabled) 和 [setEnabled](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sensitivitylabel/#setEnabled) | 获取或设置标签是否已启用。 |
| [isRemoved](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sensitivitylabel/#isRemoved) 和 [setRemoved](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sensitivitylabel/#setRemoved) | 获取或设置标签是否已被移除。当必须在元数据中保留移除状态时，将该值设为 `True`。 |
| [getAssignmentMethodType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) 和 [setAssignmentMethodType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | 获取或设置标签是自动应用还是通过用户决策应用。 |
| [getContentMarkTypes](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | 获取与标签关联的内容标记类型。 |

[SensitivityLabelAssignmentType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sensitivitylabelassignmenttype/) 类定义了标签的分配方式：

- [Standard](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sensitivitylabelassignmenttype/) 表示默认或自动应用的标签。
- [Privileged](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sensitivitylabelassignmenttype/) 表示通过用户决策应用的标签，包括手动应用、推荐和强制标签。

[SensitivityLabelContentType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sensitivitylabelcontenttype/) 类定义了与标签关联的标记：

| 值 | 含义 |
| --- | --- |
| [None](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sensitivitylabelcontenttype/) | 标签默认或自动应用。 |
| [Header](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sensitivitylabelcontenttype/) | 标签关联了页眉内容标记。 |
| [Footer](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sensitivitylabelcontenttype/) | 标签关联了页脚内容标记。 |
| [Watermark](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sensitivitylabelcontenttype/) | 标签关联了水印内容标记。 |
| [Encryption](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sensitivitylabelcontenttype/) | 标签关联了加密保护。 |

一个标签可以关联多种标记类型。

## **列出现有敏感度标签**

从[Presentation.getSensitivityLabels](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getSensitivityLabels)读取现代标签集合并枚举它。以下示例列出每个标签存储的所有属性和内容标记：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    for sensitivity_label in sensitivity_labels:
        print("Label ID:", sensitivity_label.getId())
        print("Site ID:", sensitivity_label.getSiteId())
        print("Enabled:", sensitivity_label.isEnabled())
        print("Removed:", sensitivity_label.isRemoved())
        print("Assignment method:", sensitivity_label.getAssignmentMethodType())

        for content_mark_type in sensitivity_label.getContentMarkTypes():
            print("Content marking:", content_mark_type)
finally:
    presentation.dispose()
```

## **添加带内容标记的敏感度标签**

使用[SensitivityLabelCollection.add](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sensitivitylabelcollection/#add)并提供标签标识符、站点标识符、启用状态和分配方式。方法返回新的[SensitivityLabel](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sensitivitylabel/)，随后通过[SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes)返回的列表添加所需的标记值。

以下示例添加一个手动选定的标签，关联页脚和水印标记，然后将结果保存为 PPTX：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SensitivityLabelAssignmentType, SensitivityLabelContentType
from java.util import UUID

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    label_identifier = "{11111111-2222-3333-4444-555555555555}"
    site_identifier = UUID.fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee")
    is_enabled = True
    assignment_method = SensitivityLabelAssignmentType.Privileged

    sensitivity_label = sensitivity_labels.add(label_identifier, site_identifier, is_enabled, assignment_method)

    sensitivity_label.getContentMarkTypes().addItem(jpype.JInt(SensitivityLabelContentType.Footer))
    sensitivity_label.getContentMarkTypes().addItem(jpype.JInt(SensitivityLabelContentType.Watermark))

    presentation.save("presentation_with_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **更新敏感度标签**

[SensitivityLabel](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sensitivitylabel/)的值均为读写，唯一例外是通过[SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes)返回的列表必须使用其列表操作进行修改。定位到所需标签后，您可以更新其标识符、站点标识符、启用状态、分配方式、移除状态以及内容标记类型。保存演示文稿以持久化更改。

以下示例更新第一个标签的启用状态和分配方式：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SensitivityLabelAssignmentType

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    if sensitivity_labels.getCount() > 0:
        sensitivity_label = sensitivity_labels.get_Item(0)
        sensitivity_label.setEnabled(True)
        sensitivity_label.setAssignmentMethodType(SensitivityLabelAssignmentType.Privileged)

    presentation.save("presentation_with_updated_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **将敏感度标签标记为已移除**

为保留标签已被移除的事实，找到该标签并使用 `True` 调用[SensitivityLabel.setRemoved](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sensitivitylabel/#setRemoved)。这会保留标签条目并记录其移除状态。如果需要从现代集合中删除条目，请使用[SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sensitivitylabelcollection/#removeAt)；使用[SensitivityLabelCollection.clear](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sensitivitylabelcollection/#clear)可以删除所有条目。

以下示例将特定标签标记为已移除并保存更新后的演示文稿：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()
    target_label_identifier = "{11111111-2222-3333-4444-555555555555}"

    for sensitivity_label in sensitivity_labels:
        is_target_label = str(sensitivity_label.getId()).casefold() == target_label_identifier.casefold()

        if is_target_label:
            sensitivity_label.setRemoved(True)
            break

    presentation.save("presentation_with_removed_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **读取并迁移旧版 MIP 敏感度标签**

较旧的基于 MIP 的工作流可能将敏感度标签元数据存储在自定义文档属性中，而不是现代标签集合中。使用[DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/zh/python-java/aspose.slides/documentproperties/#getSensitivityLabels)读取该元数据。该方法解析旧版自定义属性并返回一个[SensitivityLabel](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sensitivitylabel/)对象数组。

要迁移元数据，使用[SensitivityLabelCollection.add](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sensitivitylabelcollection/#add)将每个返回的标签添加到现代[SensitivityLabelCollection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sensitivitylabelcollection/)。由于添加重复的标签标识符会抛出异常，示例在复制每个标签之前会检查目标集合。您可以添加进一步的验证，以确认每个旧标签仍存在于当前的 Purview 策略中。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation_with_legacy_labels.pptx")
try:
    legacy_sensitivity_labels = presentation.getDocumentProperties().getSensitivityLabels()
    modern_sensitivity_labels = presentation.getSensitivityLabels()

    for legacy_sensitivity_label in legacy_sensitivity_labels:
        label_already_exists = False

        for modern_sensitivity_label in modern_sensitivity_labels:
            label_already_exists = str(modern_sensitivity_label.getId()).casefold() == str(legacy_sensitivity_label.getId()).casefold()

            if label_already_exists:
                break

        if not label_already_exists:
            modern_sensitivity_labels.add(legacy_sensitivity_label)

    presentation.save("presentation_with_modern_labels.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

迁移将解析后的标签对象复制到现代集合中。它不需要清除所有自定义文档属性，因此其他文档元数据保持完整。使用[Presentation.save](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#save)配合[SaveFormat.Pptx](https://reference.aspose.com/slides/zh/python-java/aspose.slides/saveformat/)将现代标签元数据写入 PPTX 文件。

## **常见问题**

**添加内容标记类型会在幻灯片上创建可见的页眉、页脚或水印吗？**

不会。通过[SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes)返回的列表添加的值仅描述与敏感度标签关联的标记。它们不会在演示文稿中创建可见的文本或形状。如果您的工作流必须呈现这些标记，需要单独添加相应的幻灯片内容。

**将标签标记为已移除与从集合中删除它有什么区别？**

使用`True`调用[SensitivityLabel.setRemoved](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sensitivitylabel/#setRemoved)会保留标签条目并记录其移除状态。调用[SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sensitivitylabelcollection/#removeAt)会从现代集合中删除该条目。请选择符合组织元数据保留要求的操作。

**演示文稿可以同时包含旧版 MIP 元数据和现代敏感度标签吗？**

可以。旧版标签可以保留在自定义文档属性中，而现代标签通过[Presentation.getSensitivityLabels](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getSensitivityLabels)获取。使用[DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/zh/python-java/aspose.slides/documentproperties/#getSensitivityLabels)读取旧版元数据，并仅迁移未在现代集合中出现的有效标签。

**当相同标识符的标签被多次添加会发生什么？**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sensitivitylabelcollection/#add)在集合已包含相同标识符的标签时会抛出异常。添加或迁移标签前，请通过[SensitivityLabel.getId](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sensitivitylabel/#getId)检查现有值。

**应使用哪种输出格式以保留更新后的敏感度标签？**

如上例所示，调用[Presentation.save](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#save)并使用[SaveFormat.Pptx](https://reference.aspose.com/slides/zh/python-java/aspose.slides/saveformat/)将演示文稿保存为 PPTX，即可保留更新后的敏感度标签。