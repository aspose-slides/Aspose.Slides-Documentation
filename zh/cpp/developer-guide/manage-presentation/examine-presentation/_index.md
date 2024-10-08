---
title: 检查演示文稿 - C++ PowerPoint API
linktitle: 检查演示文稿
type: docs
weight: 30
url: /cpp/examine-presentation/
keywords:
- PowerPoint
- 演示文稿
- 演示文稿格式
- 演示文稿属性
- 文档属性
- 获取属性
- 读取属性
- 更改属性
- 修改属性
- PPTX
- PPT
- C++
description: "在 C++ 中读取和修改 PowerPoint 演示文稿属性"
---

Aspose.Slides for C++ 允许您检查演示文稿以了解其属性并理解其行为。

{{% alert title="信息" color="info" %}}

[PresentationInfo](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation_info) 和 [DocumentProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.document_properties/) 类包含在此处操作中使用的属性和方法。

{{% /alert %}} 

## **检查演示文稿格式**

在处理演示文稿之前，您可能想要了解演示文稿目前处于什么格式（PPT、PPTX、ODP 等）。

您可以在不加载演示文稿的情况下检查演示文稿的格式。请查看以下 C++ 代码：

``` cpp
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

以下 C++ 代码向您展示如何获取演示文稿属性（关于演示文稿的信息）：

``` cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
auto props = info->ReadDocumentProperties();
Console::WriteLine(ObjectExt::ToString(props->get_CreatedTime()));
Console::WriteLine(props->get_Subject());
Console::WriteLine(props->get_Title());
// ..
```

## **更新演示文稿属性**

Aspose.Slides 提供了 [PresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentationinfo/updatedocumentproperties/) 方法，允许您更改演示文稿属性。

假设我们有一个 PowerPoint 演示文稿，其文档属性如下所示。

![PowerPoint 演示文稿的原始文档属性](input_properties.png)

此代码示例向您展示如何编辑一些演示文稿属性：

```cpp
auto fileName = u"sample.pptx";

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);

auto properties = info->ReadDocumentProperties();
properties->set_Title(u"我的标题");
properties->set_LastSavedTime(DateTime::get_Now());

info->UpdateDocumentProperties(properties);
info->WriteBindedPresentation(fileName);
```

更改文档属性的结果如下所示。

![PowerPoint 演示文稿的更改文档属性](output_properties.png)

## **有用的链接**

要获取有关演示文稿及其安全属性的更多信息，您可能会发现以下链接很有用：

- [检查演示文稿是否被加密](https://docs.aspose.com/slides/cpp/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [检查演示文稿是否为写保护（只读）](https://docs.aspose.com/slides/cpp/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [检查演示文稿在加载之前是否被密码保护](https://docs.aspose.com/slides/cpp/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [确认用于保护演示文稿的密码](https://docs.aspose.com/slides/cpp/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).