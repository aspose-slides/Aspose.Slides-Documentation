---
title: 調整投影片上的形狀大小
type: docs
weight: 110
url: /zh-hant/java/re-sizing-shapes-on-slide/
keywords:
- 調整形狀
- 變更形狀大小
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 輕鬆調整 PowerPoint 與 OpenDocument 投影片上的形狀大小——自動化投影片版面調整，提高工作效率。"
---
## **概述**

Aspose.Slides for Java 客戶最常問的問題之一是如何調整形狀大小，使得在投影片尺寸變更時，內容不會被截斷。本文簡短的技術說明將展示如何做到這一點。

## **調整形狀大小**

為了防止投影片尺寸變更時形狀錯位，請更新每個形狀的位置與尺寸，使其符合新的投影片版面配置。

```java
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
            
            // 縮放形狀尺寸。
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

{{% alert color="primary" %}} 
如果投影片中包含表格，上述程式碼將無法正確運作。在此情況下，必須調整表格中每個儲存格的大小。 
{{% /alert %}} 

使用以下程式碼在您的環境中調整包含表格的投影片。對於表格而言，設定寬度或高度是特殊情況：您必須調整各列高度和欄寬，以改變表格的整體大小。

```java
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
            // 縮放形狀尺寸。
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // 縮放形狀位置。
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            for (IShape shape : layoutSlide.getShapes()) {
                // 縮放形狀尺寸。
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
            // 縮放形狀尺寸。
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // 縮放形狀位置。
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                for (int i = 0; i < table.getRows().size(); i++) {
                    IRow row = table.getRows().get_Item(i);
                    row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
                }
                for (int j = 0; j < table.getColumns().size(); j++) {
                    IColumn column = table.getColumns().get_Item(j);
                    column.setWidth(column.getWidth() * widthRatio);
                }
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **常見問題**

**為什麼在調整投影片大小後形狀會變形或被截斷？**  

在調整投影片時，形狀會保留原始位置與尺寸，除非明確變更比例。這可能導致內容被裁切或形狀錯位。

**提供的程式碼適用於所有形狀類型嗎？**  

基本範例適用於大多數形狀類型（文字方塊、影像、圖表等）。然而，針對表格，需要分別處理列與欄，因為表格的高度與寬度是由各儲存格的尺寸決定的。

**在調整投影片時如何調整表格？**  

必須遍歷表格的所有列與欄，比例調整它們的高度與寬度，如第二段程式碼所示。

**此調整方法適用於母片投影片和版面配置投影片嗎？**  

是的，但您也應該遍歷[Masters](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#getMasters--)和[Layout slides](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#getLayoutSlides--)，對它們的形狀套用相同的比例邏輯，以確保整個簡報的一致性。

**我可以在調整大小的同時更改投影片方向（直式/橫式）嗎？**  

可以。您可以使用[presentation.getSlideSize().setOrientation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islidesize/#setOrientation-int-) 來變更方向。請確保相應調整比例邏輯，以保留版面配置。

**投影片大小有上限嗎？**  

Aspose.Slides 支援自訂尺寸，但過大的尺寸可能會影響效能或與某些 PowerPoint 版本的相容性。

**如何防止固定長寬比的形狀變形？**  

在縮放前，可檢查形狀的 `getAspectRatioLocked` 方法。如果被鎖定，請比例調整寬度或高度，而不是分別縮放它們。