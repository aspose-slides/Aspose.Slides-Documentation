---
title: 在 Node.js 中調整簡報投影片的形狀大小
type: docs
weight: 130
url: /zh-hant/nodejs-java/resizing-shapes-on-slide/
aliases:
  - /nodejs-java/重新-調整-形狀-於-投影片上/
  - /zh-hant/nodejs-java/re-sizing-shapes-on-slide/
keywords:
- 調整形狀大小
- 變更形狀尺寸
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "輕鬆使用 Aspose.Slides for Node.js（透過 Java）調整 PowerPoint 與 OpenDocument 投影片上的形狀大小—自動化投影片版面調整，提高生產力。"
---
## **概覽**

當您變更簡報的投影片尺寸時，可能還需要調整形狀的大小與位置，以符合新的尺寸。本文章說明如何手動縮放形狀，以及如何處理投影片、母片與版面的表格。

## **調整形狀大小**

為了保留每個形狀的相對位置與大小，請將其水平座標與寬度乘以新投影片寬度與原始寬度的比例。再以相同方式將垂直座標與高度乘以相應的高度比例。

第一個範例會載入一個投影片不含表格的簡報，將投影片尺寸變更為 A4，並將結果儲存。它使用 [SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize) 搭配 [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesizescaletype/#DoNotScale)，使後續的迴圈負責縮放。這些比例是無單位的；形狀的位置與尺寸以點為單位測量。不同的寬度與高度比例會導致形狀變形，且變更形狀尺寸不會同步縮放字型大小。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("sample.pptx");
try {
    // 計算獨立的水平與垂直縮放比例。
    const originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(slides.SlideSizeType.A4Paper, slides.SlideSizeScaleType.DoNotScale);
    const targetSize = presentation.getSlideSize().getSize();
    const widthRatio = targetSize.getWidth() / originalSize.getWidth();
    const heightRatio = targetSize.getHeight() / originalSize.getHeight();

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            shape.setWidth(java.newFloat(shape.getWidth() * widthRatio));
            shape.setHeight(java.newFloat(shape.getHeight() * heightRatio));
            shape.setX(java.newFloat(shape.getX() * widthRatio));
            shape.setY(java.newFloat(shape.getY() * heightRatio));
        }
    }

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
表格需要單獨處理：必須依比例縮放其欄寬與列高，而非直接設定表格的整體寬度與高度。如果儲存格內容需要更多空間，列高可能會大於要求的高度。
{{% /alert %}}

第二個範例支援表格，並在儲存重新調整大小的簡報之前，處理母片與版面以及各個投影片上的形狀。它的輔助程式會針對每個 [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/)，透過 [Column.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/column/#setWidth) 來縮放欄寬，並以 [Row.setMinimalHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#setMinimalHeight) 來縮放最小列高。之後再縮放表格的位置，而不會單獨縮放其整體尺寸。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function resizeShapes(shapes, widthRatio, heightRatio) {
    for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
        const shape = shapes.get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
            const table = shape;
            // 表格尺寸受欄寬和列高控制。
            for (let columnIndex = 0; columnIndex < table.getColumns().size(); columnIndex++) {
                const column = table.getColumns().get_Item(columnIndex);
                column.setWidth(column.getWidth() * widthRatio);
            }

            for (let rowIndex = 0; rowIndex < table.getRows().size(); rowIndex++) {
                const row = table.getRows().get_Item(rowIndex);
                row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
            }
        }
        else {
            shape.setWidth(java.newFloat(shape.getWidth() * widthRatio));
            shape.setHeight(java.newFloat(shape.getHeight() * heightRatio));
        }

        shape.setX(java.newFloat(shape.getX() * widthRatio));
        shape.setY(java.newFloat(shape.getY() * heightRatio));
    }
}

const presentation = new slides.Presentation("sample.pptx");
try {
    // 計算獨立的水平與垂直縮放比例。
    const originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(slides.SlideSizeType.A4Paper, slides.SlideSizeScaleType.DoNotScale);
    const targetSize = presentation.getSlideSize().getSize();
    const widthRatio = targetSize.getWidth() / originalSize.getWidth();
    const heightRatio = targetSize.getHeight() / originalSize.getHeight();

    // 調整母片、版面以及各個投影片上定義的形狀大小。
    for (let masterIndex = 0; masterIndex < presentation.getMasters().size(); masterIndex++) {
        const master = presentation.getMasters().get_Item(masterIndex);
        resizeShapes(master.getShapes(), widthRatio, heightRatio);

        for (let layoutSlideIndex = 0; layoutSlideIndex < master.getLayoutSlides().size(); layoutSlideIndex++) {
            const layoutSlide = master.getLayoutSlides().get_Item(layoutSlideIndex);
            resizeShapes(layoutSlide.getShapes(), widthRatio, heightRatio);
        }
    }

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        resizeShapes(slide.getShapes(), widthRatio, heightRatio);
    }

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **常見問題**

**為什麼調整投影片尺寸後形狀會變形或被裁切？**

如果在變更投影片尺寸時未對形狀進行縮放，形狀會保留原始位置與尺寸，可能會超出投影片範圍。以不同的比例分別縮放寬度與高度也會導致形狀變形。

**提供的程式碼是否適用於所有形狀類型？**

第一個範例直接變更形狀的邊界，適用於不含表格的投影片。第二個範例則會單獨處理表格。請檢查產生的版面，尤其是文字與表格，因為這些範例不會縮放字型大小，且表格內容可能限制列高。

**在調整投影片尺寸時，如何重新調整表格大小？**

如第二個範例所示，先以寬度比例縮放欄寬、以高度比例縮放最小列高，最後再縮放表格的位置。

**此調整大小方式是否適用於母片與版面投影片？**

會的。第二個範例會遍歷 [Presentation.getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getMasters) 以及每個母片的 [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/#getLayoutSlides)，並對它們的形狀套用相同的重新調整大小邏輯。

**我可以在調整大小的同時變更投影片的方向（直向/橫向）嗎？**

可以。請在變更投影片尺寸後、讀取目標尺寸前，呼叫 [SlideSize.setOrientation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setOrientation)，以確保縮放係數反映最終的方向。

**設定投影片尺寸有沒有上限？**

您可以使用 [SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize) 來指定自訂的投影片尺寸。支援的尺寸也取決於簡報的格式以及開啟檔案的應用程式。

**如何避免具有固定長寬比的形狀變形？**

對寬度與高度使用相同的縮放係數。若要在新投影片尺寸內容納原始版面，可同時使用寬度與高度比例中較小者作為縮放係數，套用於所有尺寸與位置。這樣可保留比例，但可能在某一邊留下未使用的空間。