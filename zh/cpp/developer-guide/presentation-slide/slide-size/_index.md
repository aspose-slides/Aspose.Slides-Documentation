---
title: 幻灯片尺寸
type: docs
weight: 70
url: /cpp/slide-size/

---

## PowerPoint 演示文稿中的幻灯片尺寸

Aspose.Slides for C++ 允许您在 PowerPoint 演示文稿中更改幻灯片尺寸或纵横比。如果您计划打印演示文稿或在屏幕上显示其幻灯片，您必须注意其幻灯片尺寸或纵横比。

以下是最常见的幻灯片尺寸和纵横比：

- **标准（4:3 纵横比）**

  如果您的演示文稿将在相对较旧的设备或屏幕上显示或查看，您可能希望使用此设置。

- **宽屏（16:9 纵横比）**

  如果您的演示文稿将在现代投影仪或显示屏上查看，您可能希望使用此设置。

您不能在同一演示文稿中使用多个幻灯片尺寸设置。当您为演示文稿选择幻灯片尺寸时，该幻灯片尺寸设置将应用于演示文稿中的所有幻灯片。

如果您希望为您的演示文稿使用特定的幻灯片尺寸，我们强烈建议您尽早进行设置。理想情况下，您应该在开始时指定您首选的幻灯片，即在您刚开始设置演示文稿时——在您向演示文稿添加任何内容之前。这样，您可以避免因（将来的）幻灯片尺寸更改而导致的复杂情况。

{{% alert color="primary" %}} 

 当您使用 Aspose.Slides 创建演示文稿时，演示文稿中的所有幻灯片将自动获得标准尺寸或 4:3 纵横比。

{{% /alert %}} 

## 在演示文稿中更改幻灯片尺寸

以下示例代码演示了如何在 C++ 中使用 Aspose.Slides 更改演示文稿中的幻灯片尺寸：

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```

## 在演示文稿中指定自定义幻灯片尺寸

如果您发现常见的幻灯片尺寸（4:3 和 16:9）不适合您的工作，您可以决定使用特定或独特的幻灯片尺寸。例如，如果您计划根据自定义页面布局打印您的演示文稿的全尺寸幻灯片，或者如果您打算在某些屏幕类型上显示您的演示文稿，您很可能会受益于为您的演示文稿使用自定义大小设置。

以下示例代码演示了如何使用 Aspose.Slides for C++ 为演示文稿指定自定义幻灯片尺寸：

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// A4纸张尺寸
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```

## 更改演示文稿中幻灯片尺寸时处理问题

在您更改演示文稿的幻灯片尺寸后，幻灯片的内容（例如图像或对象）可能会变得扭曲。默认情况下，对象会自动调整大小以适应新的幻灯片尺寸。然而，在更改演示文稿的幻灯片尺寸时，您可以指定一个设置来决定 Aspose.Slides 如何处理幻灯片上的内容。

根据您的意图，您可以使用以下任一设置：

- `DoNotScale`

  如果您不希望幻灯片上的对象被调整大小，请使用此设置。

- `EnsureFit`

  如果您希望缩放到较小的幻灯片尺寸，并且希望 Aspose.Slides 将幻灯片的对象缩小以确保它们都适合幻灯片（这样，您就避免了丢失内容），请使用此设置。

- `Maximize`

  如果您希望缩放到较大的幻灯片尺寸，并且希望 Aspose.Slides 将幻灯片的对象放大，使其与新的幻灯片尺寸成比例，请使用此设置。

以下示例代码演示了在更改演示文稿的幻灯片尺寸时如何使用 `Maximize` 设置：

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```