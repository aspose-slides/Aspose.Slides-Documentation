---
title: 导出到 XAML
type: docs
weight: 30
url: /zh/cpp/export-to-xaml/

---

# 导出演示文稿到 XAML

{{% alert color="primary" %}} 

在 [Aspose.Slides 21.6](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-21-6-release-notes/) 中，我们实现了对 XAML 导出的支持。您现在可以将演示文稿导出为 XAML。 

{{% /alert %}} 

# 关于 XAML

XAML 是一种描述性编程语言，可让您构建或编写应用程序的用户界面，尤其是那些使用 WPF（Windows Presentation Foundation）、UWP（通用 Windows 平台）和 Xamarin 表单的应用程序。  

XAML 是一种基于 XML 的语言，是 Microsoft 描述 GUI 的变体。您很可能会使用设计器来处理 XAML 文件，但您仍然可以编写和编辑您的 GUI。 

## 使用默认选项导出演示文稿到 XAML

以下 C++ 代码向您展示了如何使用默认设置将演示文稿导出为 XAML：

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(System::MakeObject<XamlOptions>());
```

## 使用自定义选项导出演示文稿到 XAML

您可以从 [IXamlOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xaml.i_xaml_options) 接口中选择控制导出过程的选项，并决定 Aspose.Slides 如何将您的演示文稿导出为 XAML。 

例如，如果您希望 Aspose.Slides 在导出到 XAML 时添加演示文稿中的隐藏幻灯片，可以将 true 传递给 [set_ExportHiddenSlides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xaml.i_xaml_options#a94c59a06cc2163b17e6fa2fe817c0313) 方法。请参见以下示例 C++ 代码： 

``` cpp
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(xamlOptions);
```