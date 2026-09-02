---
title: 检索并更新 C++ 中的演示文稿信息
linktitle: 演示文稿信息
type: docs
weight: 30
url: /zh/cpp/examine-presentation/
keywords:
- 演示文稿格式
- 演示文稿属性
- 文档属性
- 获取属性
- 读取属性
- 更改属性
- 修改属性
- 更新属性
- 检查 PPTX
- 检查 PPT
- 检查 ODP
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "使用 C++ 探索 PowerPoint 和 OpenDocument 演示文稿中的幻灯片、结构和元数据，以获得更快的洞察和更智能的内容审计。"
---
## **概述**

Aspose.Slides 能够识别演示文稿的格式并读取文档元数据，而无需创建完整的演示文稿对象模型。当您需要对文件进行分类、构建清单或在决定是否加载和处理演示文稿内容之前检查属性时，这非常有用。

本文演示了如何通过 [PresentationFactory](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentationfactory/) 和 [IPresentationInfo](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentationinfo/) 进行轻量级检查，以及通过 [IDocumentProperties](https://reference.aspose.com/slides/zh/cpp/aspose.slides/idocumentproperties/) 进行有针对性的更新。

## **检查演示文稿格式**

使用 [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) 在不创建 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 实例的情况下检查文件。[IPresentationInfo::get_LoadFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentationinfo/get_loadformat/) 方法会报告检测到的格式，例如 PPTX、PPT 或 ODP。

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <LoadFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto fileNames = MakeArray<String>({u"pres.pptx", u"pres.ppt", u"pres.odp"});

for (const auto& fileName : fileNames)
{
    auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);
    Console::WriteLine(String::Format(u"{0}: {1}", fileName, ObjectExt::ToString(presentationInfo->get_LoadFormat())));
}
```

## **构建轻量级演示文稿清单**

当您处理大量演示文稿文件时，可能需要一个紧凑的清单用于验证、索引或文档管理系统。在这种情况下，使用 [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) 获取一个 [IPresentationInfo](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentationinfo/) 对象，然后调用 [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) 读取文档元数据。这种方式既不会创建 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 实例，也无需遍历完整的演示文稿对象模型。

[IDocumentProperties](https://reference.aspose.com/slides/zh/cpp/aspose.slides/idocumentproperties/) 暴露的扩展属性提供以下清单值：

| 方法 | 清单值 |
| --- | --- |
| [get_Slides](https://reference.aspose.com/slides/zh/cpp/aspose.slides/idocumentproperties/get_slides/) | 幻灯片总数。 |
| [get_HiddenSlides](https://reference.aspose.com/slides/zh/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) | 隐藏幻灯片的数量。 |
| [get_Notes](https://reference.aspose.com/slides/zh/cpp/aspose.slides/idocumentproperties/get_notes/) | 包含批注的幻灯片数量。 |
| [get_Paragraphs](https://reference.aspose.com/slides/zh/cpp/aspose.slides/idocumentproperties/get_paragraphs/) | 段落总数（若有）。 |
| [get_Words](https://reference.aspose.com/slides/zh/cpp/aspose.slides/idocumentproperties/get_words/) | 单词总数。 |
| [get_MultimediaClips](https://reference.aspose.com/slides/zh/cpp/aspose.slides/idocumentproperties/get_multimediaclips/) | 音频和视频剪辑的总数。 |

以下示例在不创建 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 对象的情况下读取这些值并打印紧凑的清单。它还将 [IDocumentProperties::get_HeadingPairs](https://reference.aspose.com/slides/zh/cpp/aspose.slides/idocumentproperties/get_headingpairs/) 与 [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/zh/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) 结合使用，以显示字体、主题和幻灯片标题等内容组。

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IHeadingPair.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <LoadFormat.h>
#include <system/console.h>
#include <system/io/path.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto filePath = String(u"sample.pptx");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(filePath);
auto documentProperties = presentationInfo->ReadDocumentProperties();

Console::WriteLine(String::Format(u"File: {0}", Path::GetFileName(filePath)));
Console::WriteLine(String::Format(u"Format: {0}", ObjectExt::ToString(presentationInfo->get_LoadFormat())));
Console::WriteLine(String::Format(u"Title: {0}", documentProperties->get_Title()));
Console::WriteLine(String::Format(u"Author: {0}", documentProperties->get_Author()));
Console::WriteLine(u"Statistics:");
Console::WriteLine(String::Format(u"  Slides: {0}", documentProperties->get_Slides()));
Console::WriteLine(String::Format(u"  Hidden slides: {0}", documentProperties->get_HiddenSlides()));
Console::WriteLine(String::Format(u"  Slides with notes: {0}", documentProperties->get_Notes()));
Console::WriteLine(String::Format(u"  Paragraphs: {0}", documentProperties->get_Paragraphs()));
Console::WriteLine(String::Format(u"  Words: {0}", documentProperties->get_Words()));
Console::WriteLine(String::Format(u"  Multimedia clips: {0}", documentProperties->get_MultimediaClips()));

auto headingPairs = documentProperties->get_HeadingPairs();
auto titlesOfParts = documentProperties->get_TitlesOfParts();
auto partIndex = 0;

if (headingPairs == nullptr || titlesOfParts == nullptr || headingPairs->get_Length() == 0 || titlesOfParts->get_Length() == 0)
{
    Console::WriteLine(u"Content groups: not available");
}
else
{
    Console::WriteLine(u"Content groups:");

    for (const auto& headingPair : headingPairs)
    {
        auto partCount = headingPair->get_Count();
        Console::WriteLine(String::Format(u"  {0} ({1})", headingPair->get_Name(), partCount));

        for (auto partOffset = 0; partOffset < partCount && partIndex < titlesOfParts->get_Length(); partOffset++)
        {
            Console::WriteLine(String::Format(u"    - {0}", titlesOfParts[partIndex]));
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts->get_Length())
    {
        Console::WriteLine(u"  Other parts:");

        while (partIndex < titlesOfParts->get_Length())
        {
            Console::WriteLine(String::Format(u"    - {0}", titlesOfParts[partIndex]));
            partIndex++;
        }
    }
}
```

每个 [IHeadingPair](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iheadingpair/) 通过 [IHeadingPair::get_Name](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iheadingpair/get_name/) 提供组名，通过 [IHeadingPair::get_Count](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iheadingpair/get_count/) 提供该组中项目的数量。[IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/zh/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) 返回一个平坦、已排序的数组，因此需要按每个标题对指定的连续标题数量进行消费。

### **存储的元数据和格式限制**

由 [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) 返回的清单属性反映源文档中可用的元数据。Aspose.Slides 并不会加载并遍历演示文稿对象模型来重新计算这些值。缺失的属性会以默认值表示，如果最后一次保存文件的应用程序未更新其文档属性，则存储的值可能已过时。

- **PPTX：** 该格式提供幻灯片、批注、隐藏幻灯片、段落、单词和多媒体计数等扩展文档属性，以及标题对和部件标题。可用性取决于文档生成器写入了哪些属性。
- **PPT：** 二进制格式可以存储相应的文档摘要属性。如果属性缺失或未被文档生成器刷新，Aspose.Slides 将返回其存储或默认值，而不是根据幻灯片重新计算。
- **ODP：** OpenDocument 元数据提供一般文档统计信息，如页面、段落和单词计数，但这些值并不映射到每个 PowerPoint 特定的扩展属性。隐藏幻灯片、批注幻灯片、多媒体、标题对和部件标题的元数据可能不可用，清单属性可能返回默认值。不要将零值或空数组视为对应内容不存在的权威证明。

在进行清单和初步检查时使用轻量级元数据方法。当结果必须反映内存中的更改或需要验证实际演示文稿内容时，请加载演示文稿并检查其实时对象模型。

## **更新演示文稿属性**

通过 [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) 返回的属性同样可以在不创建 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 实例的情况下进行更改。使用 [IPresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentationinfo/updatedocumentproperties/) 应用更改，然后通过 [IPresentationInfo::WriteBindedPresentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentationinfo/writebindedpresentation/) 将绑定的演示文稿写回。

以下图片显示了原始文档属性。

![PowerPoint 演示文稿的原始文档属性](input_properties.png)

以下示例更改标题和最后保存时间并将结果写入新文件：

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/date_time.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto sourceFile = String(u"sample.pptx");
auto outputFile = String(u"sample_with_updated_properties.pptx");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(sourceFile);
auto documentProperties = presentationInfo->ReadDocumentProperties();

documentProperties->set_Title(u"Quarterly sales report");
documentProperties->set_LastSavedTime(DateTime::get_UtcNow());

presentationInfo->UpdateDocumentProperties(documentProperties);
presentationInfo->WriteBindedPresentation(outputFile);
```

以下图片显示了更改后的文档属性。

![PowerPoint 演示文稿的更改后文档属性](output_properties.png)

## **有用链接**

有关相关安全检查和保护设置，请参阅以下文章：

- [Password-Protect Presentations](/slides/zh/cpp/password-protected-presentation/)
- [Write-Protect Presentations](/slides/zh/cpp/write-protected-presentation/)

## **常见问题**

**如何检查字体是否已嵌入以及具体哪些字体？**

加载演示文稿并使用 [Presentation::get_FontsManager](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/get_fontsmanager/)。调用 [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fontsmanager/getembeddedfonts/) 获取嵌入的字体，调用 [FontsManager::GetFonts](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fontsmanager/getfonts/) 获取演示文稿使用的字体。将两者结果进行比较，即可找出渲染所需但未嵌入的字体。

**如何快速判断文件是否包含隐藏幻灯片以及数量？**

当存储的文档元数据足够时，读取通过 [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) 与 [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) 获得的 [IDocumentProperties::get_HiddenSlides](https://reference.aspose.com/slides/zh/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) 即可。这适用于轻量级清单。如果演示文稿在内存中已被修改，存储的元数据可能缺失或已过时，或需要验证实时值，则遍历 [Presentation::get_Slides](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/get_slides/) 并检查每个幻灯片的 [Slide::get_Hidden](https://reference.aspose.com/slides/zh/cpp/aspose.slides/slide/get_hidden/) 方法。

**我能否检测是否使用了自定义幻灯片尺寸和方向，以及它们是否与默认值不同？**

可以。加载演示文稿并读取 [Presentation::get_SlideSize](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/get_slidesize/)。检查 [ISlideSize::get_Type](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islidesize/get_type/)、[ISlideSize::get_Size](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islidesize/get_size/) 和 [ISlideSize::get_Orientation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islidesize/get_orientation/) ，将当前设置与预设的默认尺寸和方向进行比较。

**有没有快速方法查看图表是否引用外部数据源？**

有。定位每个 [Chart](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/chart/) 并检查其 [ChartData::get_DataSourceType](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/chartdata/get_datasourcetype/)。对于外部工作簿，读取 [ChartData::get_ExternalWorkbookPath](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) 即可。数据源类型和路径可识别外部引用，但是否可用需另行资源检查。

**如何评估可能导致渲染或 PDF 导出变慢的“重量”幻灯片？**

没有单一的复杂度属性。遍历 [Presentation::get_Slides](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/get_slides/) 并检查每个幻灯片的 [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibaseslide/get_shapes/) 集合。使用形状计数以及大型图片、效果、动画或多媒体的存在作为筛选信号，并在将幻灯片确定为性能瓶颈前进行代表性渲染或导出性能测量。