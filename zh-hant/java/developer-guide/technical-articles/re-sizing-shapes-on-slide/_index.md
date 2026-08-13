---
title: 在簡報投影片上調整形狀大小
type: docs
weight: 110
url: /zh-hant/java/re-sizing-shapes-on-slide/
keywords:
- 調整形狀
- 變更形狀尺寸
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 輕鬆調整 PowerPoint 與 OpenDocument 投影片上的形狀大小——自動化投影片版面調整並提升工作效率。"
---
## **概述**

Aspose.Slides for Java 客戶最常見的問題之一是如何調整形狀大小，以便在投影片尺寸變更時，資料不會被裁剪。本文短篇技術說明將展示如何做到這點。

## **調整形狀大小**

為防止投影片尺寸變更時形狀錯位，請更新每個形狀的位置與尺寸，使其符合新的投影片布局。

```java
import com.aspose.slides.*;

// 載入簡報檔案。
Presentation presentation = new Presentation("sample.ppt");
try {
    // 取得原始投影片尺寸。
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // 在不縮放現有形狀的情況下變更投影片尺寸。
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // 取得新的投影片尺寸。
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // 調整每張投影片上形狀的大小與位置。
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            
            // 縮放形狀大小。
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // 縮放形狀位置。
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
表格不需要特別處理：設定表格的寬度和高度會按比例重新調整其列與欄，因此再次調整列高和欄寬會使比例套用兩次。
{{% /alert %}} 

上述程式碼僅變更投影片上的形狀。母片和版面配置投影片保有各自的形狀，因此當您希望整個簡報遵循新的投影片尺寸時，也須同時調整它們的形狀：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    // 取得原始投影片尺寸。
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // 在不縮放現有形狀的情況下變更投影片尺寸。
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.getSlideSize().setOrientation(SlideOrientation.Portrait);

    // 取得新的投影片尺寸。
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    for (IMasterSlide master : presentation.getMasters()) {
        for (IShape shape : master.getShapes()) {
            // 縮放形狀大小。
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // 縮放形狀位置。
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            for (IShape shape : layoutSlide.getShapes()) {
                // 縮放形狀大小。
                shape.setHeight(shape.getHeight() * heightRatio);
                shape.setWidth(shape.getWidth() * widthRatio);

                // 縮放形狀位置。
                shape.setY(shape.getY() * heightRatio);
                shape.setX(shape.getX() * widthRatio);
            }
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            // 縮放形狀大小。
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // 縮放形狀位置。
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

## **常見問題**

### 為什麼在調整投影片大小後形狀會變形或被裁剪？

在調整投影片時，除非明確變更縮放比例，形狀會保留原始位置和尺寸。這可能導致內容被裁剪或形狀錯位。

### 提供的程式碼是否適用於所有形狀類型？

是的。設定高度與寬度同樣適用於文字方塊、圖片、圖表與表格。

### 在調整投影片時，如何調整表格大小？

直接縮放表格形狀本身，與其他形狀相同。其列和欄會按比例自動調整，因此之後請勿再對它們進行縮放。

### 此調整方式是否適用於母片和版面配置投影片？

是的，但您還應遍歷 [Masters](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#getMasters--) 和 [Layout slides](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#getLayoutSlides--)，並對它們的形狀套用相同的縮放邏輯，以確保整個簡報的一致性。

### 我可以在調整大小的同時更改投影片的方向（直式/橫式）嗎？

是的。您可以使用 [presentation.getSlideSize().setOrientation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islidesize/#setOrientation-int-) 變更方向。請確保相應調整縮放邏輯以維持版面配置。

### 我可以設定的投影片大小是否有限制？

Aspose.Slides 支援自訂尺寸，但過大的尺寸可能影響效能或與某些 PowerPoint 版本的相容性。

### 如何防止固定長寬比的形狀變形？

在縮放之前，您可以檢查形狀的 `getAspectRatioLocked` 方法。若已鎖定長寬比，請按比例調整寬度或高度，而非單獨縮放。