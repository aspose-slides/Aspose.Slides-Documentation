---
title: 管理 .NET 中 PowerPoint 演示文稿的敏感度标签
linktitle: 敏感度标签
type: docs
weight: 50
url: /zh/net/sensitivity-labels/
keywords:
- 敏感度标签
- Microsoft Purview
- Microsoft 信息保护
- MIP 元数据
- 内容标记
- 信息保护
- 文档治理
- PowerPoint
- PPTX
- 演示文稿安全
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 PowerPoint PPTX 演示文稿中读取、添加、更新、移除和迁移 Microsoft Purview 敏感度标签。"
---
## **概述**

Microsoft Purview 敏感度标签帮助组织对文档进行分类和治理。在自动化的演示处理过程中，应用程序可能需要保留现有标签、应用策略选定的标签、更新其状态，或迁移由旧版 Microsoft Information Protection（MIP）工作流写入的标签元数据。

Aspose.Slides 通过 [Presentation.SensitivityLabels](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/sensitivitylabels/) 提供现代敏感度标签元数据。此属性返回一个 [ISensitivityLabelCollection](https://reference.aspose.com/slides/zh/net/aspose.slides/isensitivitylabelcollection/)，可在保存为 PPTX 之前进行检查和修改。

{{% alert color="info" title="Note" %}}
敏感度标签标识符和策略信息由您的 Microsoft Purview 配置定义。在添加或迁移元数据之前，请在您的环境中验证标签可用性和策略要求。[ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/zh/net/aspose.slides/isensitivitylabel/contentmarktypes/) 值描述与标签关联的内容标记；它们本身并不会在幻灯片上添加可见的文本或形状。
{{% /alert %}}

## **了解敏感度标签属性**

每个 [ISensitivityLabel](https://reference.aspose.com/slides/zh/net/aspose.slides/isensitivitylabel/) 包含以下元数据：

| 属性 | 用途 |
| --- | --- |
| [ISensitivityLabel.Id](https://reference.aspose.com/slides/zh/net/aspose.slides/isensitivitylabel/id/) | 标识 Purview 策略中的敏感度标签。 |
| [ISensitivityLabel.SiteId](https://reference.aspose.com/slides/zh/net/aspose.slides/isensitivitylabel/siteid/) | 标识与标签策略关联的站点。 |
| [ISensitivityLabel.IsEnabled](https://reference.aspose.com/slides/zh/net/aspose.slides/isensitivitylabel/isenabled/) | 指示标签是否已启用。 |
| [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/zh/net/aspose.slides/isensitivitylabel/isremoved/) | 指示标签已被移除。当必须在元数据中保留移除状态时，将此属性设为 `true`。 |
| [ISensitivityLabel.AssignmentMethodType](https://reference.aspose.com/slides/zh/net/aspose.slides/isensitivitylabel/assignmentmethodtype/) | 指定标签是自动应用还是通过用户决定应用。 |
| [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/zh/net/aspose.slides/isensitivitylabel/contentmarktypes/) | 列出与标签关联的内容标记类型。 |

[SensitivityLabelAssignmentType](https://reference.aspose.com/slides/zh/net/aspose.slides/sensitivitylabelassignmenttype/) 枚举描述标签的分配方式：

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/zh/net/aspose.slides/sensitivitylabelassignmenttype/) 表示默认或自动应用的标签。  
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/zh/net/aspose.slides/sensitivitylabelassignmenttype/) 表示通过用户决定应用的标签，包括手动、推荐和强制标签。

[SensitivityLabelContentType](https://reference.aspose.com/slides/zh/net/aspose.slides/sensitivitylabelcontenttype/) 枚举标识与标签关联的标记：

| 值 | 含义 |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/zh/net/aspose.slides/sensitivitylabelcontenttype/) | 标签默认或自动应用。 |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/zh/net/aspose.slides/sensitivitylabelcontenttype/) | 与标签关联的页眉内容标记。 |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/zh/net/aspose.slides/sensitivitylabelcontenttype/) | 与标签关联的页脚内容标记。 |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/zh/net/aspose.slides/sensitivitylabelcontenttype/) | 与标签关联的水印内容标记。 |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/zh/net/aspose.slides/sensitivitylabelcontenttype/) | 与标签关联的加密保护。 |

一个标签可以关联多种标记类型。

## **列出现有敏感度标签**

从 [Presentation.SensitivityLabels](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/sensitivitylabels/) 读取现代标签集合并遍历它。以下示例列出每个标签存储的所有属性和内容标记：

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

foreach (var sensitivityLabel in sensitivityLabels)
{
    Console.WriteLine("Label ID: " + sensitivityLabel.Id);
    Console.WriteLine("Site ID: " + sensitivityLabel.SiteId);
    Console.WriteLine("Enabled: " + sensitivityLabel.IsEnabled);
    Console.WriteLine("Removed: " + sensitivityLabel.IsRemoved);
    Console.WriteLine("Assignment method: " + sensitivityLabel.AssignmentMethodType);

    foreach (var contentMarkType in sensitivityLabel.ContentMarkTypes)
    {
        Console.WriteLine("Content marking: " + contentMarkType);
    }
}
```

## **添加带内容标记的敏感度标签**

使用 [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/zh/net/aspose.slides/isensitivitylabelcollection/add/) 并传入标签标识符、站点标识符、启用状态以及分配方式。方法返回新的 [ISensitivityLabel](https://reference.aspose.com/slides/zh/net/aspose.slides/isensitivitylabel/)，随后通过 [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/zh/net/aspose.slides/isensitivitylabel/contentmarktypes/) 添加所需的标记值。

以下示例添加一个手动选择的标签，并关联页脚和水印标记，随后将结果保存为 PPTX：

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

var labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
var siteIdentifier = Guid.Parse("{aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee}");
var isEnabled = true;
var assignmentMethod = SensitivityLabelAssignmentType.Privileged;

var sensitivityLabel = sensitivityLabels.Add(
    labelIdentifier,
    siteIdentifier,
    isEnabled,
    assignmentMethod);

sensitivityLabel.ContentMarkTypes.Add(SensitivityLabelContentType.Footer);
sensitivityLabel.ContentMarkTypes.Add(SensitivityLabelContentType.Watermark);

presentation.Save("presentation_with_label.pptx", SaveFormat.Pptx);
```

## **更新敏感度标签**

[ISensitivityLabel](https://reference.aspose.com/slides/zh/net/aspose.slides/isensitivitylabel/) 的属性均为可读写，唯一例外是通过其列表操作修改由 [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/zh/net/aspose.slides/isensitivitylabel/contentmarktypes/) 返回的集合。定位到所需标签后，可更新其标识符、站点标识符、启用状态、分配方式、移除状态以及内容标记类型。保存演示文稿以持久化更改。

以下示例更新第一个标签的启用状态和分配方式：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

if (sensitivityLabels.Count > 0)
{
    var sensitivityLabel = sensitivityLabels[0];
    sensitivityLabel.IsEnabled = true;
    sensitivityLabel.AssignmentMethodType = SensitivityLabelAssignmentType.Privileged;
}

presentation.Save("presentation_with_updated_label.pptx", SaveFormat.Pptx);
```

## **将敏感度标签标记为已移除**

为保留标签已被移除的事实，找到该标签并将 [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/zh/net/aspose.slides/isensitivitylabel/isremoved/) 设为 `true`。这会保留标签条目并记录其移除状态。如果需要从现代集合中删除条目，请使用 [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/zh/net/aspose.slides/isensitivitylabelcollection/removeat/)；使用 [ISensitivityLabelCollection.Clear](https://reference.aspose.com/slides/zh/net/aspose.slides/isensitivitylabelcollection/clear/) 可删除所有条目。

以下示例将特定标签标记为已移除并保存更新后的演示文稿：

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;
var targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";

foreach (var sensitivityLabel in sensitivityLabels)
{
    var isTargetLabel = string.Equals(
        sensitivityLabel.Id,
        targetLabelIdentifier,
        StringComparison.OrdinalIgnoreCase);

    if (isTargetLabel)
    {
        sensitivityLabel.IsRemoved = true;
        break;
    }
}

presentation.Save("presentation_with_removed_label.pptx", SaveFormat.Pptx);
```

## **读取并迁移旧版 MIP 敏感度标签**

旧版基于 MIP 的工作流可能将敏感度标签元数据存储在自定义文档属性中，而不是现代标签集合。使用 [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/zh/net/aspose.slides/idocumentproperties/getsensitivitylabels/) 读取这些元数据。该方法解析旧的自定义属性并返回一个 [ISensitivityLabel](https://reference.aspose.com/slides/zh/net/aspose.slides/isensitivitylabel/) 对象数组。

要迁移元数据，使用 [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/zh/net/aspose.slides/isensitivitylabelcollection/add/) 将每个返回的标签添加到现代 [ISensitivityLabelCollection](https://reference.aspose.com/slides/zh/net/aspose.slides/isensitivitylabelcollection/)。由于添加重复的标签标识符会抛出异常，示例在复制每个标签之前会检查目标集合。您可以进一步验证，以确认每个旧标签仍存在于当前的 Purview 策略中。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation_with_legacy_labels.pptx");
var legacySensitivityLabels = presentation.DocumentProperties.GetSensitivityLabels();
var modernSensitivityLabels = presentation.SensitivityLabels;

foreach (var legacySensitivityLabel in legacySensitivityLabels)
{
    var labelAlreadyExists = false;

    foreach (var modernSensitivityLabel in modernSensitivityLabels)
    {
        labelAlreadyExists = string.Equals(
            modernSensitivityLabel.Id,
            legacySensitivityLabel.Id,
            StringComparison.OrdinalIgnoreCase);

        if (labelAlreadyExists)
        {
            break;
        }
    }

    if (!labelAlreadyExists)
    {
        modernSensitivityLabels.Add(legacySensitivityLabel);
    }
}

presentation.Save("presentation_with_modern_labels.pptx", SaveFormat.Pptx);
```

迁移会将解析后的标签对象复制到现代集合中。它不需要清除所有自定义文档属性，因此不相关的文档元数据保持完整。使用 [IPresentation.Save](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentation/save/) 与 [SaveFormat.Pptx](https://reference.aspose.com/slides/zh/net/aspose.slides.export/saveformat/) 将现代标签元数据写入 PPTX 文件。

## **常见问题解答**

**添加内容标记类型会在幻灯片上创建可见的页眉、页脚或水印吗？**  
不会。通过 [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/zh/net/aspose.slides/isensitivitylabel/contentmarktypes/) 添加的值仅描述与敏感度标签关联的标记，它们不会在演示文稿中生成可见的文本或形状。如果工作流需要呈现这些标记，需要单独添加相应的幻灯片内容。

**将标签标记为已移除与从集合中删除有何区别？**  
将 [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/zh/net/aspose.slides/isensitivitylabel/isremoved/) 设为 `true` 会保留标签条目并记录其移除状态。调用 [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/zh/net/aspose.slides/isensitivitylabelcollection/removeat/) 则会从现代集合中删除该条目。请选择符合组织元数据保留要求的操作。

**演示文稿可以同时包含旧版 MIP 元数据和现代敏感度标签吗？**  
可以。旧版标签可以保留在自定义文档属性中，而现代标签通过 [Presentation.SensitivityLabels](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/sensitivitylabels/) 可用。使用 [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/zh/net/aspose.slides/idocumentproperties/getsensitivitylabels/) 读取旧元数据，并仅迁移未在现代集合中出现的有效标签。

**如果多次添加具有相同标识符的标签会发生什么？**  
[ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/zh/net/aspose.slides/isensitivitylabelcollection/add/) 在集合已包含相同标识符的标签时会抛出 `ArgumentException`。在添加或迁移标签之前，请检查现有的 [ISensitivityLabel.Id](https://reference.aspose.com/slides/zh/net/aspose.slides/isensitivitylabel/id/) 值。

**应使用哪种输出格式来保留更新后的敏感度标签？**  
如上例所示，调用 [IPresentation.Save](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentation/save/) 并指定 [SaveFormat.Pptx](https://reference.aspose.com/slides/zh/net/aspose.slides.export/saveformat/) 将演示文稿保存为 PPTX，即可保留更新后的敏感度标签。