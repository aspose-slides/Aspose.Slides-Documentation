---
title: 幻灯片大小
type: docs
weight: 70
url: /zh/net/slide-size/
keywords: "设置幻灯片，编辑幻灯片大小，PowerPoint 演示文稿，自定义幻灯片大小，解决幻灯片问题，C#，Csharp，.NET，Aspose.Slides"
descriptions: "在 C# 或 .NET 中设置和编辑 PowerPoint 的幻灯片大小或纵横比"
---

## PowerPoint 演示文稿中的幻灯片大小

Aspose.Slides for .NET 允许您在 PowerPoint 演示文稿中更改幻灯片大小或纵横比。如果您计划打印演示文稿或在屏幕上显示其幻灯片，您必须注意其幻灯片大小或纵横比。

这些是最常见的幻灯片大小和纵横比：

- **标准（4:3 纵横比）**

  如果您的演示文稿要在相对较旧的设备或屏幕上显示或查看，您可能希望使用此设置。

- **宽屏（16:9 纵横比）**

  如果您的演示文稿将在现代投影仪或显示器上看到，您可能希望使用此设置。

您不能在单个演示文稿中使用多个幻灯片大小设置。当您为演示文稿选择幻灯片大小时，该幻灯片大小设置将应用于演示文稿中的所有幻灯片。

如果您希望为演示文稿使用特殊的幻灯片大小，我们强烈建议您尽早进行。理想情况下，您应该在开始时指定首选幻灯片，也就是在设置演示文稿时——在添加任何内容之前。这样，您可以避免因幻灯片大小的（未来）更改而导致的复杂情况。

{{% alert color="primary" %}} 

 当您使用 Aspose.Slides 创建演示文稿时，演示文稿中的所有幻灯片会自动获得标准大小或 4:3 纵横比。

{{% /alert %}} 

## 在演示文稿中更改幻灯片大小

 此示例代码向您展示如何在 C# 中使用 Aspose.Slides 更改演示文稿中的幻灯片大小：

```c#
using (Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
}
```

## 在演示文稿中指定自定义幻灯片大小

如果您发现常见的幻灯片大小（4:3 和 16:9）不适合您的工作，您可以选择使用特定或独特的幻灯片大小。例如，如果您计划根据自定义页面布局从演示文稿打印全尺寸幻灯片，或者如果您打算在某些屏幕类型上显示您的演示文稿，则使用自定义大小设置可能会给您带来好处。

此示例代码向您展示如何使用 Aspose.Slides for .NET 在 C# 中为演示文稿指定自定义幻灯片大小：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // A4 纸张大小
    pres.Save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
}
```

## 更改演示文稿中幻灯片大小时处理问题

在您更改演示文稿的幻灯片大小后，幻灯片的内容（图像或对象等）可能会变形。默认情况下，对象会自动调整大小以适应新的幻灯片大小。但是，在更改演示文稿的幻灯片大小时，您可以指定一个设置，以确定 Aspose.Slides 如何处理幻灯片上的内容。

根据您的意图，您可以使用以下任何设置：

- `DoNotScale`

  如果您不希望幻灯片上的对象调整大小，请使用此设置。

- `EnsureFit`

  如果您希望缩放到较小的幻灯片大小并需要 Aspose.Slides 将幻灯片的对象缩小以确保它们全部适合幻灯片（这样，您就可以避免丢失内容），请使用此设置。

- `Maximize`

  如果您希望缩放到较大的幻灯片大小，并需要 Aspose.Slides 将幻灯片的对象放大以使其与新的幻灯片大小成比例，请使用此设置。

此示例代码向您展示如何在更改演示文稿的幻灯片大小时使用 `Maximize` 设置：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```