---
title: 幻灯片大小
type: docs
weight: 70
url: /zh/java/slide-size/

---

## PowerPoint 演示文稿中的幻灯片尺寸

Aspose.Slides for Java 允许您更改 PowerPoint 演示文稿中的幻灯片大小或纵横比。如果您计划打印演示文稿或在屏幕上显示其幻灯片，您必须关注其幻灯片大小或纵横比。

以下是最常见的幻灯片尺寸和纵横比：

- **标准 (4:3 纵横比)**

  如果您的演示文稿将在相对较旧的设备或屏幕上显示或查看，您可能希望使用此设置。

- **宽屏 (16:9 纵横比)** 

  如果您的演示文稿将在现代投影仪或显示器上查看，您可能希望使用此设置。

您不能在单个演示文稿中使用多个幻灯片尺寸设置。当您为演示文稿选择幻灯片尺寸时，该幻灯片尺寸设置会应用于演示文稿中的所有幻灯片。

如果您希望在演示文稿中使用特定的幻灯片尺寸，我们强烈建议您尽早这样做。理想情况下，您应该在开始时就指定您偏好的幻灯片尺寸，即在您刚开始设置演示文稿时——在您向演示文稿添加任何内容之前。这样，您可以避免因将来更改幻灯片大小而导致的复杂问题。

{{% alert color="primary" %}} 

 当您使用 Aspose.Slides 创建演示文稿时，演示文稿中的所有幻灯片会自动获得标准大小或 4:3 纵横比。

{{% /alert %}} 

## 在演示文稿中更改幻灯片大小

以下示例代码向您展示如何使用 Aspose.Slides 在 Java 中更改演示文稿的幻灯片大小：

```java
Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## 在演示文稿中指定自定义幻灯片尺寸

如果您发现常见的幻灯片尺寸（4:3 和 16:9）不适合您的工作，您可以决定使用特定或独特的幻灯片尺寸。例如，如果您计划在自定义页面布局中打印全尺寸幻灯片，或者如果您打算在某些类型的屏幕上显示演示文稿，您可能会从为演示文稿使用自定义尺寸设置中获益。

以下示例代码向您展示如何使用 Aspose.Slides for Java 为演示文稿指定自定义幻灯片尺寸：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // A4 纸张尺寸
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## 更改演示文稿中幻灯片大小时处理问题

在您为演示文稿更改幻灯片大小后，幻灯片的内容（例如图像或对象）可能会变得畸形。默认情况下，对象会自动调整大小以适应新的幻灯片大小。然而，在更改演示文稿的幻灯片大小时，您可以指定一个设置来决定 Aspose.Slides 如何处理幻灯片上的内容。

根据您的意图，您可以使用以下设置之一：

- `DoNotScale`

  如果您不希望幻灯片上的对象被调整大小，请使用此设置。

- `EnsureFit`

  如果您想缩放到较小的幻灯片大小，并需要 Aspose.Slides 将幻灯片的对象缩小以确保它们都适合幻灯片（通过这种方式，您可以避免丢失内容），请使用此设置。

- `Maximize`

  如果您想缩放到较大的幻灯片大小，并需要 Aspose.Slides 放大幻灯片的对象以使它们与新的幻灯片大小成比例，请使用此设置。

以下示例代码向您展示如何在更改演示文稿的幻灯片大小时使用 `Maximize` 设置：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```