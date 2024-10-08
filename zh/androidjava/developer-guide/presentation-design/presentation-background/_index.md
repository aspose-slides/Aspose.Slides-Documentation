---
title: 演示文稿背景
type: docs
weight: 20
url: /androidjava/presentation-background/
keywords: "PowerPoint 背景, 在 Java 中设置背景"
description: "在 Java 中设置 PowerPoint 演示文稿的背景"
---

纯色、渐变色和图片通常用作幻灯片的背景图像。您可以为**普通幻灯片**（单个幻灯片）或**母版幻灯片**（一次多个幻灯片）设置背景

<img src="powerpoint-background.png" alt="powerpoint-background"  />

## **为普通幻灯片设置纯色背景**

Aspose.Slides 允许您为演示文稿中的特定幻灯片设置纯色背景（即使该演示文稿包含母版幻灯片）。背景的更改仅影响所选幻灯片。

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的一个实例。
2. 将幻灯片的 [BackgroundType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/backgroundtype/) 枚举设置为 `OwnBackground`。
3. 将幻灯片背景的 [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) 枚举设置为 `Solid`。
4. 使用 [SolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) 属性来为背景指定纯色，该属性由 [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/) 提供。
5. 保存修改后的演示文稿。

以下 Java 代码示例演示如何为普通幻灯片设置纯色（蓝色）背景：

```java
// 创建 Presentation 类的实例
Presentation pres = new Presentation("MasterBG.pptx");
try {
    // 将第一张 ISlide 的背景颜色设置为蓝色
    pres.getSlides().get_Item(0).getBackground().setType(BackgroundType.OwnBackground);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().setFillType(FillType.Solid);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    // 将演示文稿写入磁盘
    pres.save("ContentBG.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **为母版幻灯片设置纯色背景**

Aspose.Slides 允许您为演示文稿中的母版幻灯片设置纯色背景。母版幻灯片作为模板，包含并控制所有幻灯片的格式设置。因此，当您为母版幻灯片选择纯色作为背景时，该新背景将用于所有幻灯片。

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的一个实例。
2. 将母版幻灯片（`Masters`）的 [BackgroundType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/backgroundtype/) 枚举设置为 `OwnBackground`。
3. 将母版幻灯片背景的 [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) 枚举设置为 `Solid`。
4. 使用 [SolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) 属性来为背景指定纯色，该属性由 [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/) 提供。
5. 保存修改后的演示文稿。

以下 Java 代码示例演示如何为演示文稿中的母版幻灯片设置纯色（森林绿）背景：

```java
// 创建 Presentation 类的实例
Presentation pres = new Presentation();
try {
    // 将母版 ISlide 的背景颜色设置为森林绿
    pres.getMasters().get_Item(0).getBackground().setType(BackgroundType.OwnBackground);
    pres.getMasters().get_Item(0).getBackground().getFillFormat().setFillType(FillType.Solid);
    pres.getMasters().get_Item(0).getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    
    // 将演示文稿写入磁盘
    pres.save("MasterBG.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **为幻灯片设置渐变色背景**

渐变是一种基于颜色逐渐变化的图形效果。当将渐变色用作幻灯片的背景时，演示文稿看起来既艺术又专业。Aspose.Slides 允许您为演示文稿中的幻灯片设置渐变色背景。

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的一个实例。
2. 将幻灯片的 [BackgroundType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/backgroundtype/) 枚举设置为 `OwnBackground`。
3. 将母版幻灯片背景的 [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) 枚举设置为 `Gradient`。
4. 使用 [GradientFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/#getGradientFormat--) 属性来指定您首选的渐变设置，该属性由 [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/) 提供。
5. 保存修改后的演示文稿。

以下 Java 代码示例演示如何为幻灯片设置渐变色背景：

```java
// 创建 Presentation 类的实例
Presentation pres = new Presentation("MasterBG.pptx");
try {
    // 将渐变效果应用于背景
    pres.getSlides().get_Item(0).getBackground().setType(BackgroundType.OwnBackground);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().setFillType(FillType.Gradient);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().getGradientFormat().setTileFlip(TileFlip.FlipBoth);
    
    // 将演示文稿写入磁盘
    pres.save("ContentBG_Grad.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **为幻灯片设置图片背景**

除了纯色和渐变色之外，Aspose.Slides 还允许您在演示文稿的幻灯片背景中设置图片。

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的一个实例。
2. 将幻灯片的 [BackgroundType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/backgroundtype/) 枚举设置为 `OwnBackground`。
3. 将母版幻灯片背景的 [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) 枚举设置为 `Picture`。
4. 加载您想用作幻灯片背景的图像。
5. 将图像添加到演示文稿的图像集合中。
6. 使用 [PictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/#getPictureFillFormat--) 属性来设置图像为背景，该属性由 [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/) 提供。
7. 保存修改后的演示文稿。

以下 Java 代码示例演示如何将图像设置为幻灯片的背景：

```java
// 创建 Presentation 类的实例
Presentation pres = new Presentation();
try {
    // 设置背景图像条件
    pres.getSlides().get_Item(0).getBackground().setType(BackgroundType.OwnBackground);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().setFillType(FillType.Picture);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().getPictureFillFormat()
            .setPictureFillMode(PictureFillMode.Stretch);
    
    // 加载图像
    IPPImage imgx;
    IImage image = Images.fromFile("Desert.jpg");
    try {
        imgx = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // 将图像添加到演示文稿的图像集合中
    pres.getSlides().get_Item(0).getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(imgx);
    
    // 将演示文稿写入磁盘
    pres.save("ContentBG_Img.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **改变背景图像的透明度**

您可能希望调整幻灯片背景图像的透明度，以使幻灯片内容更加突出。以下 Java 代码示例演示如何更改幻灯片背景图像的透明度：

```java
int transparencyValue = 30; // 例如

// 获取图片转换操作的集合
IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// 查找带有固定百分比的透明度效果。
AlphaModulateFixed transparencyOperation = null;
for (IImageTransformOperation operation : imageTransform)
{
    if (operation instanceof AlphaModulateFixed)
    {
        transparencyOperation = (AlphaModulateFixed)operation;
        break;
    }
}

// 设置新的透明度值。
if (transparencyOperation == null)
{
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
}
else
{
    transparencyOperation.setAmount(100 - transparencyValue);
}
```

## **获取幻灯片背景的值**

Aspose.Slides 提供了 [IBackgroundEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibackgroundeffectivedata/) 接口，以允许您获取幻灯片背景的有效值。该接口包含有关有效 [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) 和有效 [EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--)) 的信息。

使用 [BaseSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/) 类中的 [Background](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getBackground--) 属性，您可以获取幻灯片背景的有效值。

以下 Java 代码示例演示如何获取幻灯片的有效背景值：

```java
// 创建 Presentation 类的实例
Presentation pres = new Presentation("SamplePresentation.pptx");
try {
    IBackgroundEffectiveData effBackground = pres.getSlides().get_Item(0).getBackground().getEffective();
    
    if (effBackground.getFillFormat().getFillType() == FillType.Solid)
        System.out.println("填充颜色: " + effBackground.getFillFormat().getSolidFillColor());
    else
        System.out.println("填充类型: " + effBackground.getFillFormat().getFillType());
} finally {
    if (pres != null) pres.dispose();
}
```