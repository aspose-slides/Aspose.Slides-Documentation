---
title: 在演示文稿幻灯片上调整形状大小
type: docs
weight: 110
url: /zh/java/re-sizing-shapes-on-slide/
keywords:
- 调整形状大小
- 改变形状尺寸
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java，轻松在 PowerPoint 和 OpenDocument 幻灯片上调整形状大小——自动化幻灯片布局调整，提高工作效率。"
---
## **概述**

Aspose.Slides for Java 客户最常问的问题之一是如何调整形状大小，以便在更改幻灯片尺寸时，数据不会被裁剪。本文简短的技术文章展示了如何实现这一点。

## **调整形状大小**

为防止幻灯片尺寸更改时形状位置错位，请更新每个形状的位置和尺寸，使其符合新的幻灯片布局。

```java
import com.aspose.slides.*;

// 加载演示文稿文件。
Presentation presentation = new Presentation("sample.ppt");
try {
    // 获取原始幻灯片尺寸。
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // 更改幻灯片尺寸且不缩放现有形状。
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // 获取新的幻灯片尺寸。
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // 调整每张幻灯片上形状的大小和位置。
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            
            // 缩放形状大小。
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // 缩放形状位置。
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" %}} 

表格无需特殊处理：设置表格的宽度和高度会按比例重新缩放其列和行，因此再次缩放行高和列宽会导致比例被应用两次。

{{% /alert %}} 

上述代码仅更改幻灯片上的形状。母版幻灯片和布局幻灯片保有各自的形状，因此在希望整个演示文稿遵循新幻灯片尺寸时，也需要对它们进行缩放：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    // 获取原始幻灯片尺寸。
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // 更改幻灯片尺寸且不缩放现有形状。
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.getSlideSize().setOrientation(SlideOrientation.Portrait);

    // 获取新的幻灯片尺寸。
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    for (IMasterSlide master : presentation.getMasters()) {
        for (IShape shape : master.getShapes()) {
            // 缩放形状大小。
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // 缩放形状位置。
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            for (IShape shape : layoutSlide.getShapes()) {
                // 缩放形状大小。
                shape.setHeight(shape.getHeight() * heightRatio);
                shape.setWidth(shape.getWidth() * widthRatio);

                // 缩放形状位置。
                shape.setY(shape.getY() * heightRatio);
                shape.setX(shape.getX() * widthRatio);
            }
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            // 缩放形状大小。
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // 缩放形状位置。
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **常见问题**

### 为什么在调整幻灯片大小后形状会变形或被裁剪？

在调整幻灯片大小时，形状会保持原始位置和尺寸，除非显式更改缩放比例。这可能导致内容被裁剪或形状错位。

### 提供的代码适用于所有形状类型吗？

是的。设置高度和宽度同样适用于文本框、图像、图表和表格。

### 调整幻灯片大小时如何调整表格？

按与其他形状相同的方式缩放表格形状本身。其行和列会按比例跟随调节，随后不要再次单独缩放它们。

### 这套调整方法适用于母版幻灯片和布局幻灯片吗？

是的，但您还应遍历[Masters](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#getMasters--)和[Layout slides](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#getLayoutSlides--)并对它们的形状应用相同的缩放逻辑，以确保整个演示文稿的一致性。

### 我可以在调整大小的同时更改幻灯片的方向（纵向/横向）吗？

可以。您可以使用[presentation.getSlideSize().setOrientation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/islidesize/#setOrientation-int-)来更改方向。请确保相应地设置缩放逻辑，以保持布局不变。

### 幻灯片尺寸有最大限制吗？

Aspose.Slides 支持自定义尺寸，但非常大的尺寸可能会影响性能或与某些 PowerPoint 版本的兼容性。

### 如何防止固定宽高比的形状被拉伸变形？

在缩放之前，可以检查形状的`getAspectRatioLocked`方法。如果已锁定，请按比例调整宽度或高度，而不是单独缩放它们。