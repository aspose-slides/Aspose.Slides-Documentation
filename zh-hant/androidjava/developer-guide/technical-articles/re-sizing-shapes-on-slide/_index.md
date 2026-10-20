---
title: 在 Android 上重新調整簡報投影片中的形狀大小
type: docs
weight: 130
url: /zh-hant/androidjava/resizing-shapes-on-slide/
aliases:
  - /androidjava/re-sizing-shapes-on-slide/
keywords:
- 調整形狀大小
- 變更形狀尺寸
- PowerPoint
- OpenDocument
- 簡報
- Android
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java，輕鬆調整 PowerPoint 與 OpenDocument 投影片上的形狀大小—自動化投影片版面調整，提高工作效率。"
---
## **概覽**

當您變更簡報的投影片大小時，可能也需要調整其形狀的大小與位置，以符合新的尺寸。本篇文章說明如何手動縮放形狀，以及如何處理投影片、母片與版面配置上的表格。

## **調整形狀大小**

為了保留每個形狀的相對位置與大小，請將其水平座標與寬度乘以新投影片寬度與原始寬度的比例。再將相對的高度比例套用於其垂直座標與高度。

第一個範例載入一個投影片中不含表格的簡報，將投影片大小變更為 A4，並儲存結果。它使用 [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-int-int-) 搭配 [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesizescaletype/#DoNotScale) 以讓隨後的迴圈控制縮放。比例值無單位；形狀的位置與尺寸以點為單位測量。不同的寬度與高度比例會造成形狀變形，且變更形狀尺寸不會同步縮放其字型大小。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    // 計算獨立的水平與垂直縮放係數。
    float originalWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float originalHeight = (float) presentation.getSlideSize().getSize().getHeight();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    float widthRatio = (float) presentation.getSlideSize().getSize().getWidth() / originalWidth;
    float heightRatio = (float) presentation.getSlideSize().getSize().getHeight() / originalHeight;

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
表格需要單獨處理：依比例縮放其欄寬與列高，而不是直接設定表格的整體寬度與高度。如果儲存格內容需要更多空間，列高可能會保持大於設定值。
{{% /alert %}}

第二個範例支援表格，並在儲存調整大小後的簡報之前，處理母片與版面配置以及各個投影片上的形狀。其輔助程式會對每個 [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) 透過 [IColumn.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolumn/#setWidth-double-) 縮放欄寬，並以 [IRow.setMinimalHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#setMinimalHeight-double-) 縮放最小列高。接著僅縮放表格的位置，而不另行縮放其整體尺寸。

```java
import com.aspose.slides.*;

class ShapeResizer {
    void resizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio) {
        for (IShape shape : shapes) {
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                // 表格尺寸受欄寬和列高控制。
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
    float originalWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float originalHeight = (float) presentation.getSlideSize().getSize().getHeight();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    float widthRatio = (float) presentation.getSlideSize().getSize().getWidth() / originalWidth;
    float heightRatio = (float) presentation.getSlideSize().getSize().getHeight() / originalHeight;

    ShapeResizer resizer = new ShapeResizer();

    // 調整在母片、版面配置以及個別投影片上定義的形狀大小。
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

**為什麼形狀在調整投影片大小後會變形或被截斷？**

如果在變更投影片大小時未同時縮放形狀，形狀會保留原始的位置與尺寸，可能會超出投影片範圍。使用不同的寬度與高度比例進行縮放亦會導致形狀變形。

**提供的程式碼適用於所有形狀類型嗎？**

第一個範例直接變更形狀的邊界，適用於不含表格的投影片。第二個範例則分別處理表格。請檢查最終的版面配置，特別是文字與表格，因為這些範例不會縮放字型大小，且表格內容可能限制列高。

**在調整投影片大小時，我該如何調整表格？**

依照寬度比例縮放欄寬，依照高度比例縮放最小列高，然後如同第二個範例所示，縮放表格的位置。

**此調整大小也適用於母片與版面配置投影片嗎？**

會的。第二個範例會遍歷 [Presentation.getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) 以及每個母片的 [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/#getLayoutSlides--)，並對其形狀套用相同的調整大小邏輯。

**我可以在調整大小的同時變更投影片的方向（直向/橫向）嗎？**

可以。請在變更投影片大小後、讀取目標尺寸前呼叫 [SlideSize.setOrientation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setOrientation-int-)，如此縮放係數會反映最終的方向。

**可以設定的投影片尺寸有限制嗎？**

您可以使用 [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) 來指定自訂的投影片尺寸。支援的尺寸亦取決於簡報格式以及開啟檔案的應用程式。

**如何防止具有固定長寬比的形狀變形？**

對寬度與高度使用相同的縮放係數。若要將原始版面配置適配至新的投影片尺寸，可同時以寬度與高度比例較小者作為縮放係數，套用至尺寸與位置。此方法可維持比例，但可能在某一側留下未使用的空間。