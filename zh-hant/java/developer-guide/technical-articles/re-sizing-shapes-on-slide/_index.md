---
title: 在 Java 中調整簡報投影片上的形狀大小
type: docs
weight: 130
url: /zh-hant/java/resizing-shapes-on-slide/
aliases:
  - /java/re-sizing-shapes-on-slide/
  - /zh-hant/java/re-sizing-shapes-on-slide/
keywords:
- 調整形狀大小
- 變更形狀尺寸
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 輕鬆調整 PowerPoint 與 OpenDocument 投影片上的形狀大小——自動化投影片版面調整，提高生產力。"
---
## **概觀**

當您更改簡報的投影片尺寸時，可能還需要調整及重新定位其形狀以符合新尺寸。本篇文章說明如何手動縮放形狀以及如何處理投影片、母片與版面配置中的表格。

## **調整形狀大小**

為了保留每個形狀的相對位置與大小，請將其水平座標與寬度乘以新投影片寬度與原始寬度的比例。再將對應的高度比例套用於其垂直座標與高度。

第一個範例載入一個投影片中不含表格的簡報，將投影片尺寸變更為 A4，並儲存結果。它使用 [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-int-int-) 搭配 [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/java/com.aspose.slides/slidesizescaletype/#DoNotScale) 以便後續迴圈自行控制縮放。這些比例是無單位的；形狀的位置與尺寸以點 (point) 為單位。不同的寬高比例可能會使形狀變形，且變更形狀尺寸不會同步縮放字型大小。

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    // 計算獨立的水平和垂直縮放係數。
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
表格需要單獨處理：請縮放其列寬與行高，而不是直接設定表格的整體寬度與高度。如果儲存格內容需要更多空間，行高可能會保持大於要求的尺寸。
{{% /alert %}}

第二個範例支援表格，並在儲存調整過尺寸的簡報之前，處理母片、版面配置以及各個投影片上的形狀。其輔助程式會針對每個 [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) 透過 [IColumn.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icolumn/#setWidth-double-) 縮放列寬，並使用 [IRow.setMinimalHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#setMinimalHeight-double-) 設定最小行高。之後會縮放表格的位置，而不會單獨縮放其整體尺寸。

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

class ShapeResizer {
    void resizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio) {
        for (IShape shape : shapes) {
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                // 表格的尺寸受欄寬與列高控制。
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
    // 計算獨立的水平與垂直縮放係數。
    Dimension2D originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    Dimension2D targetSize = presentation.getSlideSize().getSize();
    float widthRatio = (float) (targetSize.getWidth() / originalSize.getWidth());
    float heightRatio = (float) (targetSize.getHeight() / originalSize.getHeight());

    ShapeResizer resizer = new ShapeResizer();

    // 調整在母片、版面配置以及各個投影片上定義的形狀大小。
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

**為何在調整投影片大小後形狀會變形或被截斷？**

如果在變更投影片尺寸時未同步縮放形狀，形狀會維持原本的位置與尺寸，可能會超出投影片範圍。以不同的比例同時縮放寬度與高度也會導致形狀變形。

**提供的程式碼能適用於所有形狀類型嗎？**

第一個範例直接變更形狀的邊界，適用於不含表格的投影片。第二個範例則會單獨處理表格。請檢查最終的版面配置，尤其是文字與表格，因為這些範例不會縮放字型大小，且表格內容可能會限制行高。

**在調整投影片大小時，如何調整表格尺寸？**

如同第二個範例所示，先以寬度比例縮放列寬，並以高度比例設定最小行高，最後再縮放表格的位置。

**此調整方式能套用於母片與版面配置投影片嗎？**

會的。第二個範例會遍歷 [Presentation.getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) 以及每個母片的 [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/#getLayoutSlides--)，並對它們的形狀套用相同的調整邏輯。

**我可以在調整尺寸的同時更改投影片的方向（直式/橫式）嗎？**

可以。請在變更投影片尺寸後、讀取目標尺寸前，呼叫 [SlideSize.setOrientation](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setOrientation-int-)，以讓縮放比例反映最終的方向。

**我可以設定的投影片尺寸有上限嗎？**

您可以使用 [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-float-float-int-) 指定自訂的投影片尺寸。支援的尺寸亦取決於簡報格式以及用來開啟檔案的應用程式。

**如何防止具有固定長寬比的形狀被拉伸變形？**

對寬度與高度使用相同的縮放係數。若要讓原始版面在新投影片尺寸內保持完整，請同時以寬度與高度比例中較小的那一個作為縮放係數，套用於尺寸與位置。此方式可保留比例，但可能在某一側留下未使用的空間。