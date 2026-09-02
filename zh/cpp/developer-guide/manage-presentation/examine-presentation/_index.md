---
title: 在 C++ 中检索和更新演示文稿信息
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
description: "使用 C++ 探索 PowerPoint 和 OpenDocument 演示文稿中的幻灯片、结构和元数据，以获得更快速的洞察和更智能的内容审计。"
---
## **概述**

本文展示了如何在 Aspose.Slides 中检查演示文稿信息。它说明了如何在不加载完整文件的情况下确定演示文稿的当前格式、读取其文档属性以及在需要时更新这些属性。

示例基于 [PresentationInfo](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentationinfo/) 和 [DocumentProperties](https://reference.aspose.com/slides/zh/cpp/aspose.slides/documentproperties/) API，并演示了处理演示文稿元数据的典型操作。

## **检查演示文稿格式**

在处理演示文稿之前，您可能想了解当前演示文稿的格式（PPT、PPTX、ODP 等）。

您可以在不加载演示文稿的情况下检查其格式。请参阅以下 C++ 代码：

``` cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
// PPTX
Console::WriteLine(ObjectExt::ToString(info->get_LoadFormat()));

auto info2 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.ppt");
// PPT
Console::WriteLine(ObjectExt::ToString(info2->get_LoadFormat()));

auto info3 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.odp");
// ODP
Console::WriteLine(ObjectExt::ToString(info3->get_LoadFormat()));
```

## **获取演示文稿属性**

以下 C++ 代码展示了如何获取演示文稿属性（有关演示文稿的信息）：

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
auto props = info->ReadDocumentProperties();
Console::WriteLine(ObjectExt::ToString(props->get_CreatedTime()));
Console::WriteLine(props->get_Subject());
Console::WriteLine(props->get_Title());
// .. 
```

## **更新演示文稿属性**

Aspose.Slides 提供了 [PresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentationinfo/updatedocumentproperties/) 方法，允许您修改演示文稿属性。

假设我们有一个 PowerPoint 演示文稿，其文档属性如下所示。

![PowerPoint 演示文稿的原始文档属性](input_properties.png)

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/date_time.h>
using namespace Aspose::Slides;
using namespace System;

auto fileName = u"sample.pptx";

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);

auto properties = info->ReadDocumentProperties();
properties->set_Title(u"My title");
properties->set_LastSavedTime(DateTime::get_Now());

info->UpdateDocumentProperties(properties);
info->WriteBindedPresentation(fileName);
```

更改文档属性后的结果如下所示。

![PowerPoint 演示文稿的更改后文档属性](output_properties.png)

## **有用链接**

要获取有关演示文稿及其安全属性的更多信息，您可能会发现以下链接有用：

- [密码保护演示文稿](/slides/zh/cpp/password-protected-presentation/)
- [写保护演示文稿](/slides/zh/cpp/write-protected-presentation/)

## **常见问题**

**如何检查是否嵌入了字体以及具体是哪一些字体？**

在演示文稿层面查找 [embedded-font information](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fontsmanager/getembeddedfonts/)，然后将这些条目与 [fonts actually used across content](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fontsmanager/getfonts/) 的集合进行比较，以识别哪些字体对渲染至关重要。

**如何快速判断文件是否包含隐藏幻灯片以及数量？**

遍历 [slide collection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/slidecollection/)，检查每个幻灯片的 [visibility flag](https://reference.aspose.com/slides/zh/cpp/aspose.slides/slide/get_hidden/)。

**我能检测是否使用了自定义幻灯片尺寸和方向，以及它们是否与默认值不同吗？**

可以。将当前的 [slide size and orientation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/get_slidesize/) 与标准预设进行比较；这有助于预测打印和导出的行为。

**是否有快速方法查看图表是否引用外部数据源？**

可以。遍历所有 [charts](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/chart/)，检查它们的 [data source](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/chartdata/get_datasourcetype/)，并记录数据是内部的还是基于链接的，包括任何损坏的链接。

**我该如何评估可能导致渲染或 PDF 导出变慢的“重量”幻灯片？**

对于每张幻灯片，统计对象数量并查找大尺寸图像、透明度、阴影、动画和多媒体；给出一个大致的复杂度评分，以标记潜在的性能瓶颈。