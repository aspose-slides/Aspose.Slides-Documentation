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
description: "使用 C++ 探索 PowerPoint 和 OpenDocument 演示文稿中的幻灯片、结构和元数据，以获取更快速的洞察和更智能的内容审计。"
---

Aspose.Slides for C++ 允许您检查演示文稿，以了解其属性并理解其行为。 

{{% alert title="Info" color="info" %}}
这里使用的操作所涉及的属性和方法位于 [PresentationInfo](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation_info) 和 [DocumentProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.document_properties/) 类中。 
{{% /alert %}} 

## **Check a Presentation Format**

在处理演示文稿之前，您可能想了解当前演示文稿的格式（PPT、PPTX、ODP 等）。 

您可以在不加载演示文稿的情况下检查其格式。请参见以下 C++ 代码：
``` cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
// PPTX 文件
Console::WriteLine(ObjectExt::ToString(info->get_LoadFormat()));

auto info2 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.ppt");
// PPT 文件
Console::WriteLine(ObjectExt::ToString(info2->get_LoadFormat()));

auto info3 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.odp");
// ODP 文件
Console::WriteLine(ObjectExt::ToString(info3->get_LoadFormat()));
```


## **Get Presentation Properties**

以下 C++ 代码演示如何获取演示文稿属性（即有关演示文稿的信息）：
``` cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
auto props = info->ReadDocumentProperties();
Console::WriteLine(ObjectExt::ToString(props->get_CreatedTime()));
Console::WriteLine(props->get_Subject());
Console::WriteLine(props->get_Title());
// ..
```


## **Update Presentation Properties**

Aspose.Slides 提供了 [PresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentationinfo/updatedocumentproperties/) 方法，允许您修改演示文稿属性。 

假设我们有一个 PowerPoint 演示文稿，其文档属性如下所示。 

![Original document properties of the PowerPoint presentation](input_properties.png)

以下代码示例展示如何编辑部分演示文稿属性：
```cpp
auto fileName = u"sample.pptx";

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);

auto properties = info->ReadDocumentProperties();
properties->set_Title(u"My title");
properties->set_LastSavedTime(DateTime::get_Now());

info->UpdateDocumentProperties(properties);
info->WriteBindedPresentation(fileName);
```


更改文档属性后的结果如下所示。 

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Useful Links**

欲获取有关演示文稿及其安全属性的更多信息，您可能会发现以下链接有用：

- [Checking whether a Presentation is Encrypted](https://docs.aspose.com/slides/cpp/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)（检查演示文稿是否已加密）
- [Checking whether a Presentation is Write Protected (read-only)](https://docs.aspose.com/slides/cpp/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)（检查演示文稿是否受写保护（只读））
- [Checking whether a Presentation is Password Protected Before Loading it](https://docs.aspose.com/slides/cpp/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)（在加载之前检查演示文稿是否受密码保护）
- [Confirming the Password Used to Protect a Presentation](https://docs.aspose.com/slides/cpp/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation)（确认用于保护演示文稿的密码）

## **FAQ**

**How can I check whether fonts are embedded and which ones they are?**  
如何检查字体是否已嵌入以及具体有哪些？  

在演示文稿级别查找 [embedded-font information](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/getembeddedfonts/)，然后将这些条目与 [fonts actually used across content](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/getfonts/) 的集合进行比较，以确定哪些字体对渲染至关重要。  

**How can I quickly tell if the file has hidden slides and how many?**  
如何快速判断文件中是否包含隐藏幻灯片以及数量？  

遍历 [slide collection](https://reference.aspose.com/slides/cpp/aspose.slides/slidecollection/) 并检查每个幻灯片的 [visibility flag](https://reference.aspose.com/slides/cpp/aspose.slides/slide/get_hidden/)。  

**Can I detect whether custom slide size and orientation are used, and whether they differ from the defaults?**  
我能否检测是否使用了自定义幻灯片尺寸和方向，以及它们是否与默认设置不同？  

可以。将当前的 [slide size and orientation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slidesize/) 与标准预设进行比较；这有助于预测打印和导出时的行为。  

**Is there a quick way to see if charts reference external data sources?**  
有没有快速方法查看图表是否引用外部数据源？  

可以。遍历所有 [charts](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/)，检查它们的 [data source](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_datasourcetype/)，并标记数据是内部的还是基于链接的，包括任何失效的链接。  

**How can I assess 'heavy' slides that may slow rendering or PDF export?**  
如何评估可能导致渲染或 PDF 导出变慢的“沉重”幻灯片？  

对于每张幻灯片，统计对象数量并查找大型图像、透明度、阴影、动画和多媒体；给出一个大致的复杂度评分，以标记潜在的性能热点。