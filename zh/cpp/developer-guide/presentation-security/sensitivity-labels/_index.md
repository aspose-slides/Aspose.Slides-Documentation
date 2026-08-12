---
title: 在 C++ 中管理 PowerPoint 演示文稿的敏感度标签
linktitle: 敏感度标签
type: docs
weight: 50
url: /zh/cpp/sensitivity-labels/
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
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 在 PowerPoint PPTX 演示文稿中读取、添加、更新、移除和迁移 Microsoft Purview 敏感度标签。"
---
## **概述**

Microsoft Purview 敏感度标签帮助组织对文档进行分类和治理。在自动化演示处理期间，应用程序可能需要保留现有标签、应用由策略选择的标签、更新其状态，或迁移较旧的 Microsoft Information Protection（MIP）工作流写入的标签元数据。

Aspose.Slides 通过 [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) 公开现代敏感度标签元数据。此方法返回一个 [ISensitivityLabelCollection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isensitivitylabelcollection/)，可在将演示文稿保存为 PPTX 之前检查和修改。

{{% alert color="primary" title="Note" %}}
敏感度标签标识符和策略信息由您的 Microsoft Purview 配置定义。在添加或迁移元数据之前，请在您的环境中验证标签可用性和策略要求。[ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) 的值描述了与标签关联的内容标记；它们本身并不会向幻灯片添加可见的文本或形状。
{{% /alert %}}

## **了解敏感度标签属性**

每个 [ISensitivityLabel](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isensitivitylabel/) 包含以下元数据：

| 访问器 | 目的 |
| --- | --- |
| [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isensitivitylabel/get_id/), [ISensitivityLabel::set_Id](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isensitivitylabel/set_id/) | 在 Purview 策略中标识敏感度标签。 |
| [ISensitivityLabel::get_SiteId](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isensitivitylabel/get_siteid/), [ISensitivityLabel::set_SiteId](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isensitivitylabel/set_siteid/) | 标识与标签策略关联的站点。 |
| [ISensitivityLabel::get_IsEnabled](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isensitivitylabel/get_isenabled/), [ISensitivityLabel::set_IsEnabled](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isensitivitylabel/set_isenabled/) | 指示标签是否已启用。 |
| [ISensitivityLabel::get_IsRemoved](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isensitivitylabel/get_isremoved/), [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isensitivitylabel/set_isremoved/) | 指示标签已被移除。当必须在元数据中保留移除状态时，将值设为 `true`。 |
| [ISensitivityLabel::get_AssignmentMethodType](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isensitivitylabel/get_assignmentmethodtype/), [ISensitivityLabel::set_AssignmentMethodType](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isensitivitylabel/set_assignmentmethodtype/) | 指定标签是自动应用还是通过用户决策应用的。 |
| [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) | 列出与标签关联的内容标记类型。 |

枚举 [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/zh/cpp/aspose.slides/sensitivitylabelassignmenttype/) 描述了标签的分配方式：

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/zh/cpp/aspose.slides/sensitivitylabelassignmenttype/) 表示默认或自动应用的标签。
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/zh/cpp/aspose.slides/sensitivitylabelassignmenttype/) 表示通过用户决策应用的标签，包括手动应用、推荐和强制标签。

枚举 [SensitivityLabelContentType](https://reference.aspose.com/slides/zh/cpp/aspose.slides/sensitivitylabelcontenttype/) 确定与标签关联的标记：

| 值 | 含义 |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/zh/cpp/aspose.slides/sensitivitylabelcontenttype/) | 标签是默认或自动应用的。 |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/zh/cpp/aspose.slides/sensitivitylabelcontenttype/) | 标签关联了页眉内容标记。 |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/zh/cpp/aspose.slides/sensitivitylabelcontenttype/) | 标签关联了页脚内容标记。 |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/zh/cpp/aspose.slides/sensitivitylabelcontenttype/) | 标签关联了水印内容标记。 |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/zh/cpp/aspose.slides/sensitivitylabelcontenttype/) | 标签关联了加密保护。 |

一个标签可以关联多种标记类型。

## **列出现有敏感度标签**

从 [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) 读取现代标签集合并遍历它。以下示例列出每个标签存储的所有属性和内容标记：

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <DOM/SensitivityLabelAssignmentType.h>
#include <DOM/SensitivityLabelContentType.h>
#include <system/collections/ilist.h>
#include <system/console.h>
#include <system/guid.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Presentation;
using System::Console;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();

for (auto&& sensitivityLabel : sensitivityLabels)
{
    auto labelIdentifier = sensitivityLabel->get_Id();
    auto siteIdentifier = sensitivityLabel->get_SiteId();
    auto isEnabled = sensitivityLabel->get_IsEnabled();
    auto isRemoved = sensitivityLabel->get_IsRemoved();
    auto assignmentMethod = sensitivityLabel->get_AssignmentMethodType();

    Console::WriteLine(u"Label ID: {0}", labelIdentifier);
    Console::WriteLine(u"Site ID: {0}", siteIdentifier);
    Console::WriteLine(u"Enabled: {0}", isEnabled);
    Console::WriteLine(u"Removed: {0}", isRemoved);
    Console::WriteLine(u"Assignment method: {0}", assignmentMethod);

    for (auto contentMarkType : sensitivityLabel->get_ContentMarkTypes())
    {
        Console::WriteLine(u"Content marking: {0}", contentMarkType);
    }
}

presentation->Dispose();
```

## **添加带内容标记的敏感度标签**

使用 [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isensitivitylabelcollection/add/) 并提供标签标识符、站点标识符、启用状态和分配方式。方法返回新的 [ISensitivityLabel](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isensitivitylabel/ ) 后，通过 [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) 添加所需的标记值。

以下示例添加一个手动选择的标签，并关联页脚和水印标记，然后将结果保存为 PPTX：

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <DOM/SensitivityLabelAssignmentType.h>
#include <DOM/SensitivityLabelContentType.h>
#include <Export/SaveFormat.h>
#include <system/collections/ilist.h>
#include <system/guid.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::SensitivityLabelAssignmentType;
using Aspose::Slides::SensitivityLabelContentType;
using Aspose::Slides::Export::SaveFormat;
using System::Guid;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();

auto labelIdentifier = u"{11111111-2222-3333-4444-555555555555}";
auto siteIdentifier = Guid::Parse(u"{aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee}");
bool isEnabled = true;
auto assignmentMethod = SensitivityLabelAssignmentType::Privileged;

auto sensitivityLabel = sensitivityLabels->Add(
    labelIdentifier,
    siteIdentifier,
    isEnabled,
    assignmentMethod);

sensitivityLabel->get_ContentMarkTypes()->Add(SensitivityLabelContentType::Footer);
sensitivityLabel->get_ContentMarkTypes()->Add(SensitivityLabelContentType::Watermark);

presentation->Save(u"presentation_with_label.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **更新敏感度标签**

[ISensitivityLabel] 的值可通过其 getter 和 setter 方法读写，唯一例外是由 [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) 返回的集合需通过列表操作进行修改。定位到所需标签后，您可以更新其标识符、站点标识符、启用状态、分配方式、移除状态以及内容标记类型。保存演示文稿以持久化更改。

以下示例更新第一个标签的启用状态和分配方式：

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <DOM/SensitivityLabelAssignmentType.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::SensitivityLabelAssignmentType;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();
int labelCount = sensitivityLabels->get_Count();

if (labelCount > 0)
{
    auto sensitivityLabel = sensitivityLabels->idx_get(0);
    sensitivityLabel->set_IsEnabled(true);
    sensitivityLabel->set_AssignmentMethodType(SensitivityLabelAssignmentType::Privileged);
}

presentation->Save(u"presentation_with_updated_label.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **将敏感度标签标记为已移除**

要保留标签已被移除的事实，找到该标签并使用 `true` 调用 [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isensitivitylabel/set_isremoved/)。这会保留标签条目并记录其移除状态。如果需要从现代集合中删除条目，请使用 [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isensitivitylabelcollection/removeat/)；使用 [ISensitivityLabelCollection::Clear](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isensitivitylabelcollection/clear/) 可删除所有条目。

以下示例将特定标签标记为已移除并保存更新后的演示文稿：

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::String;
using System::StringComparison;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();
auto targetLabelIdentifier = u"{11111111-2222-3333-4444-555555555555}";

for (auto&& sensitivityLabel : sensitivityLabels)
{
    auto labelIdentifier = sensitivityLabel->get_Id();
    bool isTargetLabel = String::Equals(
        labelIdentifier,
        targetLabelIdentifier,
        StringComparison::OrdinalIgnoreCase);

    if (isTargetLabel)
    {
        sensitivityLabel->set_IsRemoved(true);
        break;
    }
}

presentation->Save(u"presentation_with_removed_label.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **读取并迁移旧版 MIP 敏感度标签**

较旧的基于 MIP 的工作流可能将敏感度标签元数据存储在自定义文档属性中，而不是现代标签集合。使用 [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/zh/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/) 读取这些元数据。该方法解析旧版自定义属性并返回 [ISensitivityLabel](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isensitivitylabel/) 对象数组。

要迁移元数据，使用 [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isensitivitylabelcollection/add/) 将每个返回的标签添加到现代 [ISensitivityLabelCollection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isensitivitylabelcollection/)。由于添加重复的标签标识符会引发异常，示例在复制每个标签之前会检查目标集合。您可以添加进一步的验证，以确认每个旧标签仍在当前的 Purview 策略中。

```cpp
#include <DOM/Presentation.h>
#include <DOM/IDocumentProperties.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::String;
using System::StringComparison;

auto presentation = MakeObject<Presentation>(u"presentation_with_legacy_labels.pptx");
auto documentProperties = presentation->get_DocumentProperties();
auto legacySensitivityLabels = documentProperties->GetSensitivityLabels();
auto modernSensitivityLabels = presentation->get_SensitivityLabels();

for (auto&& legacySensitivityLabel : legacySensitivityLabels)
{
    bool labelAlreadyExists = false;
    auto legacyLabelIdentifier = legacySensitivityLabel->get_Id();

    for (auto&& modernSensitivityLabel : modernSensitivityLabels)
    {
        auto modernLabelIdentifier = modernSensitivityLabel->get_Id();
        labelAlreadyExists = String::Equals(
            modernLabelIdentifier,
            legacyLabelIdentifier,
            StringComparison::OrdinalIgnoreCase);

        if (labelAlreadyExists)
        {
            break;
        }
    }

    if (!labelAlreadyExists)
    {
        modernSensitivityLabels->Add(legacySensitivityLabel);
    }
}

presentation->Save(u"presentation_with_modern_labels.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

迁移将解析后的标签对象复制到现代集合中。它不需要清除所有自定义文档属性，因此无关的文档元数据保持完整。使用带有 [SaveFormat::Pptx](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/saveformat/) 的 [IPresentation::Save](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentation/save/) 将现代标签元数据写入 PPTX 文件。

## **常见问题**

**添加内容标记类型会在幻灯片上创建可见的页眉、页脚或水印吗？**

不会。通过 [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) 添加的值描述了与敏感度标签关联的标记。它们不会在演示文稿中创建可见的文本或形状。如果您的工作流必须呈现这些标记，请单独添加相应的幻灯片内容。

**将标签标记为已移除与从集合中删除它有什么区别？**

调用 [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isensitivitylabel/set_isremoved/) 并传入 `true` 会保留标签条目并记录其移除状态。调用 [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isensitivitylabelcollection/removeat/) 会从现代集合中删除该条目。请选择符合您组织元数据保留要求的操作。

**演示文稿可以同时包含旧版 MIP 元数据和现代敏感度标签吗？**

可以。旧版标签可以保留在自定义文档属性中，同时通过 [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) 获取现代标签。使用 [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/zh/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/) 读取旧版元数据，并仅迁移未在现代集合中出现的有效标签。

**当具有相同标识符的标签被多次添加会发生什么？**

[ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isensitivitylabelcollection/add/) 在集合已包含具有相同标识符的标签时会抛出参数异常。添加或迁移标签前，请检查现有的 [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isensitivitylabel/get_id/) 值。

**应使用哪种输出格式来保留已更新的敏感度标签？**

如上例所示，使用 [IPresentation::Save](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentation/save/) 并传入 [SaveFormat::Pptx](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/saveformat/) 将演示文稿保存为 PPTX，以保留已更新的敏感度标签。