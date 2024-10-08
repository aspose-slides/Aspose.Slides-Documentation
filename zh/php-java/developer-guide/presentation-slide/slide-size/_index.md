---
title: 幻灯片大小
type: docs
weight: 70
url: /php-java/slide-size/

---

## PowerPoint 演示文稿中的幻灯片大小

Aspose.Slides for PHP via Java 允许您更改 PowerPoint 演示文稿中的幻灯片大小或纵横比。如果您计划打印演示文稿或在屏幕上显示其幻灯片，则必须注意其幻灯片大小或纵横比。

以下是最常见的幻灯片大小和纵横比：

- **标准（4:3 纵横比）**

  如果您的演示文稿打算在相对较旧的设备或屏幕上展示或查看，您可能想使用此设置。

- **宽屏（16:9 纵横比）**

  如果您的演示文稿将在现代投影仪或显示器上查看，您可能想使用此设置。

您不能在单个演示文稿中使用多个幻灯片大小设置。当您为演示文稿选择幻灯片大小时，该幻灯片大小设置将应用于演示文稿中的所有幻灯片。

如果您希望为演示文稿使用特定的幻灯片大小，我们强烈建议您尽早进行设置。理想情况下，您应该在开始时指定您首选的幻灯片大小，即在您刚开始设置演示文稿时——在您添加任何内容之前。这样，您可以避免因（未来）对幻灯片大小的更改而导致的复杂性。

{{% alert color="primary" %}} 

 当您使用 Aspose.Slides 创建演示文稿时，演示文稿中的所有幻灯片都会自动获得标准大小或 4:3 纵横比。

{{% /alert %}} 

## 在演示文稿中更改幻灯片大小 

 此示例代码展示了如何使用 Aspose.Slides 在演示文稿中更改幻灯片大小：

```php
  $pres = new Presentation("pres-4x3-aspect-ratio.pptx");
  try {
    $pres->getSlideSize()->setSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
    $pres->save("pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## 在演示文稿中指定自定义幻灯片大小

如果您发现常见的幻灯片大小（4:3 和 16:9）不适合您的工作，您可以选择使用特定或独特的幻灯片大小。例如，如果您计划根据自定义页面布局打印全尺寸幻灯片，或者如果您打算在某些屏幕类型上显示演示文稿，那么您很可能会从为演示文稿使用自定义大小设置中受益。

此示例代码展示了如何使用 Aspose.Slides for PHP via Java 为演示文稿指定自定义幻灯片大小：

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->getSlideSize()->setSize(780, 540, SlideSizeScaleType::DoNotScale);// A4 纸张大小

    $pres->save("pres-a4-slide-size.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## 更改演示文稿中幻灯片大小时处理问题

在您为演示文稿更改幻灯片大小后，幻灯片的内容（例如图像或对象）可能会变形。默认情况下，对象会自动调整大小以适应新的幻灯片大小。然而，在更改演示文稿的幻灯片大小时，您可以指定一个设置，以确定 Aspose.Slides 如何处理幻灯片上的内容。

根据您的意图，您可以使用以下设置之一：

- `DoNotScale`

  如果您不希望幻灯片上的对象被调整大小，请使用此设置。

- `EnsureFit`

  如果您希望缩小至较小的幻灯片大小，并且您需要 Aspose.Slides 将幻灯片的对象缩小以确保它们都适合幻灯片（这样，您可以避免丢失内容），请使用此设置。

- `Maximize`

  如果您希望缩放到较大的幻灯片大小，并且您需要 Aspose.Slides 将幻灯片的对象放大以使其与新的幻灯片大小成比例，请使用此设置。

此示例代码展示了如何在更改演示文稿的幻灯片大小时使用 `Maximize` 设置：

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->getSlideSize()->setSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```