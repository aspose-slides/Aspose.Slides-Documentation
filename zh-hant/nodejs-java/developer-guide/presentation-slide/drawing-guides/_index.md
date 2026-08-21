---
title: 在 JavaScript 中管理簡報的繪圖參考線
linktitle: 繪圖參考線
type: docs
weight: 85
url: /zh-hant/nodejs-java/drawing-guides/
keywords:
- 繪圖參考線
- 水平參考線
- 垂直參考線
- 對齊參考線
- 投影片檢視
- 母片投影片
- 版面投影片
- 備註母片
- 講義母片
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 在 PowerPoint 簡報中新增、存取與清除水平與垂直繪圖參考線。"
---
## **概觀**

繪圖參考線是可調整的水平與垂直線條，可協助使用者在 PowerPoint 中編輯簡報時持續對齊形狀。當應用程式產生簡報，稍後需要手動精細調整時，它特別有用：應用程式可儲存相同的對齊輔助，作者在新增或移動內容時應遵循這些輔助。

繪圖參考線是編輯輔助工具，而非投影片內容。它們不會出現在投影片放映或渲染輸出中。Aspose.Slides for Node.js via Java 透過 [DrawingGuidesCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/drawingguidescollection/) 類別公開它們。參考線由 [DrawingGuide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/drawingguide/) 表示，具備方向、位置和顏色。

位置以點 (points) 為單位，從相關投影片或母片的左上角測量。垂直參考線使用水平座標，通常在 0 到投影片寬度之間。水平參考線使用垂直座標，通常在 0 到投影片高度之間。

## **將參考線新增至投影片檢視**

使用 [CommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) 來管理在編輯普通投影片時顯示的參考線。呼叫 [DrawingGuidesCollection.add](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/drawingguidescollection/#add)，傳入 [Orientation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/orientation/) 值與點為單位的位置。

以下範例在投影片中心右側新增一條垂直參考線，並在其下方新增一條水平參考線：

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideSize = presentation.getSlideSize().getSize();
    const guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(slides.Orientation.Vertical, slideSize.getWidth() / 2 + 12.5);
    guides.add(slides.Orientation.Horizontal, slideSize.getHeight() / 2 + 12.5);

    presentation.save("drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **存取繪圖參考線**

[DrawingGuidesCollection.getCount](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/drawingguidescollection/#getCount) 與 [DrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/drawingguidescollection/#get_Item) 方法提供對現有參考線的存取。[DrawingGuide.getOrientation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/drawingguide/#getOrientation)、[DrawingGuide.getPosition](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/drawingguide/#getPosition) 與 [DrawingGuide.getColor](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/drawingguide/#getColor) 方法返回的值亦可透過對應的設定子方法進行變更。

以下範例讀取先前建立之簡報的投影片檢視參考線：

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("drawing-guides.pptx");
try {
    const guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    for (let index = 0; index < guides.getCount(); index++) {
        const guide = guides.get_Item(index);
        console.log("Guide " + index + ": orientation = " + guide.getOrientation() + ", position = " + guide.getPosition() + ", color = " + guide.getColor());
    }
} finally {
    presentation.dispose();
}
```

## **將參考線新增至母片與版面投影片**

投影片母片及其每個版面投影片皆可擁有各自的繪圖參考線集合。對於母片使用 [MasterSlide.getDrawingGuides](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/masterslide/#getDrawingGuides)，對於版面投影片使用 [LayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/layoutslide/#getDrawingGuides)。

以下範例在第一個母片投影片新增一條垂直參考線，並在第一個版面投影片新增一條水平參考線：

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideSize = presentation.getSlideSize().getSize();
    const masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    const layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(slides.Orientation.Vertical, slideSize.getWidth() / 2 - 20);
    layoutGuides.add(slides.Orientation.Horizontal, slideSize.getHeight() / 2 + 20);

    presentation.save("master-layout-drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **將參考線新增至備註與講義母片**

備註母片與講義母片也支援繪圖參考線。使用 [MasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/masternotesslide/#getDrawingGuides) 與 [MasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/masterhandoutslide/#getDrawingGuides) 以存取它們的集合。如果簡報未包含這些母片之一，`MasterNotesSlideManager.setDefaultMasterNotesSlide` 或 `MasterHandoutSlideManager.setDefaultMasterHandoutSlide` 會建立預設母片並回傳它。

以下範例在備註母片新增一條水平參考線，並在講義母片新增一條垂直參考線：

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const notesSize = presentation.getNotesSize().getSize();
    const notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    const handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(slides.Orientation.Horizontal, notesSize.getHeight() / 2 + 50);
    handoutMaster.getDrawingGuides().add(slides.Orientation.Vertical, notesSize.getWidth() / 2 - 50);

    presentation.save("notes-handout-drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **清除繪圖參考線**

呼叫 [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/drawingguidescollection/#clear) 可移除特定集合中的所有參考線。清除單一集合不會影響其他範圍中儲存的參考線。

以下範例在不建立缺少母片的情況下，清除投影片檢視參考線以及投影片母片、版面投影片、備註母片與講義母片上的所有參考線：

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation-with-guides.pptx");
try {
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear();

    for (let index = 0; index < presentation.getMasters().size(); index++) {
        presentation.getMasters().get_Item(index).getDrawingGuides().clear();
    }

    for (let index = 0; index < presentation.getLayoutSlides().size(); index++) {
        presentation.getLayoutSlides().get_Item(index).getDrawingGuides().clear();
    }

    const notesMaster = presentation.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster !== null) {
        notesMaster.getDrawingGuides().clear();
    }

    const handoutMaster = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();
    if (handoutMaster !== null) {
        handoutMaster.getDrawingGuides().clear();
    }

    presentation.save("presentation-without-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常見問題**

**繪圖參考線會出現在投影片放映或匯出圖像中嗎？**

不會。繪圖參考線是用於編輯的對齊輔助，並不會作為簡報內容呈現。

**可以直接將繪圖參考線新增至個別普通投影片嗎？**

普通投影片的編輯參考線儲存在簡報的投影片檢視屬性中。投影片母片、版面投影片、備註母片與講義母片各自有獨立的參考線集合。

**參考線位置使用哪種單位？**

位置以點（points）為單位，1 英吋等於 72 點。垂直位置以左邊緣為測量起點，水平位置以上邊緣為測量起點。

**清除繪圖參考線會移除圖形或變更投影片內容嗎？**

不會。 [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/drawingguidescollection/#clear) 方法僅會移除所選集合中的參考線。圖形及其他投影片內容保持不變。