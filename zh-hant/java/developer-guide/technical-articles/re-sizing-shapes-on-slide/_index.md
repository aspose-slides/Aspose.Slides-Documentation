---
title: 在 Java 中調整簡報投影片的形狀大小
type: docs
weight: 130
url: /zh-hant/java/resizing-shapes-on-slide/
aliases:
  - /zh-hant/java/re-sizing-shapes-on-slide/
  /java/re-sizing-shapes-on-slide/
keywords:
- 調整形狀大小
- 更改形狀尺寸
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 輕鬆調整 PowerPoint 與 OpenDocument 投影片上的形狀大小——自動化投影片版面調整，提高工作效率。"
---
## **概觀**

當您變更簡報的投影片大小時，可能也需要調整形狀的大小並重新定位，以符合新的尺寸。本文說明如何手動縮放形狀，以及如何在投影片、母片與佈局中處理表格。

## **調整形狀大小**

為了保留每個形狀相對的位置與大小，將其水平座標與寬度乘以新投影片寬度與原始寬度的比例。對其垂直座標與高度套用相應的高度比例。

第一個範例載入一個投影片中不含表格的簡報，將投影片大小變更為 A4，並儲存結果。它使用[SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-int-int-) 搭配[SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/java/com.aspose.slides/slidesizescaletype/#DoNotScale) 以便讓隨後的迴圈控制縮放。比例是無單位的；形狀的位置與尺寸以點為單位。不同的寬度與高度比例會造成形狀失真，且變更形狀的尺寸不會縮放其字型大小。

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    // 計算水平與垂直的獨立縮放比例。
    Dimension2D originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    Dimension2D targetSize = presentation.getSlideSize().getSize();
    float widthRatio = (float) (targetSize.getWidth() / originalSize.getWidth());
    float heightRatio = (float) (targetSize.getHeight() / originalSize.getHeight());

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            shape.setWidth(shape.getWidth() * widthRatio);
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
            shape.setY(shape.getY() * heightRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
表格需要單獨處理：以縮放其欄寬和列高取代直接指定表格的整體寬度與高度。如果儲存格內容需要更多空間，列高可能會維持大於要求的大小。
{{% /alert %}}

第二個範例支援表格，並在儲存已調整大小的簡報之前，處理母片、佈局以及各個投影片上的形狀。它的輔助程式會針對每個[ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) 透過[IColumn.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icolumn/#setWidth-double-) 縮放欄寬，並以[IRow.setMinimalHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#setMinimalHeight-double-) 縮放最小列高。接著會縮放表格的位置，但不會單獨縮放其整體尺寸。

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

class ShapeResizer {
    void resizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio) {
        for (IShape shape : shapes) {
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                // 表格尺寸受欄寬與列高控制。
                for (IColumn column : table.getColumns()) {
                    column.setWidth(column.getWidth() * widthRatio);
                }

                for (IRow row : table.getRows()) {
                    row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
                }
            }
            else {
                shape.setWidth(shape.getWidth() * widthRatio);
                shape.setHeight(shape.getHeight() * heightRatio);
            }

            shape.setX(shape.getX() * widthRatio);
            shape.setY(shape.getY() * heightRatio);
        }
    }
}

Presentation presentation = new Presentation("sample.pptx");
try {
    // 計算水平與垂直的獨立縮放比例。
    Dimension2D originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    Dimension2D targetSize = presentation.getSlideSize().getSize();
    float widthRatio = (float) (targetSize.getWidth() / originalSize.getWidth());
    float heightRatio = (float) (targetSize.getHeight() / originalSize.getHeight());

    ShapeResizer resizer = new ShapeResizer();

    // 調整在母片、版面與個別投影片上定義的形狀大小。
    for (IMasterSlide master : presentation.getMasters()) {
        resizer.resizeShapes(master.getShapes(), widthRatio, heightRatio);

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            resizer.resizeShapes(layoutSlide.getShapes(), widthRatio, heightRatio);
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        resizer.resizeShapes(slide.getShapes(), widthRatio, heightRatio);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **常見問題**

**為何在調整投影片大小後形狀會失真或被截斷？**

如果在變更投影片大小時未對形狀進行縮放，形狀會保持原始的位置與尺寸，可能會超出投影片範圍。使用不同的寬度與高度比例進行縮放也會導致形狀失真。

**提供的程式碼是否適用於所有形狀類型？**

第一個範例直接變更形狀的邊界，適用於不含表格的投影片。第二個範例則單獨處理表格。請檢查產生的版面配置，尤其是文字與表格，因為這些範例不會縮放字型大小，且表格內容可能限制列高。

**在調整投影片時，如何重新調整表格大小？**

如第二個範例所示，先以寬度比例縮放欄寬、以高度比例縮放最小列高，最後再縮放表格的位置。

**此調整大小也適用於母片與版面投影片嗎？**

會的。第二個範例會遍歷[Presentation.getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--)以及每個母片的[IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/#getLayoutSlides--)，並對它們的形狀套用相同的調整大小邏輯。

**我可以在調整大小的同時變更投影片方向（直向/橫向）嗎？**

可以。於變更投影片大小後、讀取目標尺寸前，呼叫[SlideSize.setOrientation](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setOrientation-int-)，如此縮放係數會以最終的方向為基礎。

**我可以設定的投影片大小有上限嗎？**

您可以使用[SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-float-float-int-) 指定自訂的投影片尺寸。支援的尺寸亦受簡報格式以及開啟檔案的應用程式限制。

**如何防止具有固定長寬比的形狀變形？**

對寬度與高度使用相同的縮放係數。若要在新投影片尺寸內保留原始版面，請以寬度與高度比例中較小的那個作為兩者及位置的縮放係數。這樣可維持比例，但可能在某一側留下未使用的空間。