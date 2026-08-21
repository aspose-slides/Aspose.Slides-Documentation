---
title: 在 Android 上管理簡報中的繪圖參考線
linktitle: 繪圖參考線
type: docs
weight: 85
url: /zh-hant/androidjava/drawing-guides/
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
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 在 PowerPoint 簡報中新增、存取與清除水平與垂直繪圖參考線。"
---
## **概觀**

繪圖參考線是可調整的水平與垂直線，可協助使用者在 PowerPoint 中編輯簡報時一致地對齊形狀。當應用程式產生的簡報稍後需要手動潤飾時，它特別有用：應用程式可以儲存相同的對齊輔助，作者在新增或移動內容時應遵循這些輔助。

繪圖參考線是編輯輔助工具，而非投影片內容。它們不會出現在投影片放映或呈現輸出中。Aspose.Slides for Android via Java 透過 [IDrawingGuidesCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idrawingguidescollection/) 介面公開它們。參考線由 [IDrawingGuide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idrawingguide/) 表示，並具備方向、位置與顏色。

位置以點 (points) 為單位，從相關投影片或母片的左上角測量。垂直參考線使用水平座標，通常介於零與投影片寬度之間。水平參考線使用垂直座標，通常介於零與投影片高度之間。

## **將參考線新增至投影片檢視**

使用 [ICommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/icommonslideviewproperties/#getDrawingGuides--) 來管理在編輯普通投影片時顯示的參考線。呼叫 [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idrawingguidescollection/#add-byte-float-) 並傳入 [Orientation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/orientation/) 值以及以點為單位的位置。

以下範例在投影片中心右側新增一條垂直參考線，並在其下方新增一條水平參考線：

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(Orientation.Vertical, slideSize.getWidth() / 2 + 12.5f);
    guides.add(Orientation.Horizontal, slideSize.getHeight() / 2 + 12.5f);

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **存取繪圖參考線**

透過 [IDrawingGuidesCollection.getCount](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idrawingguidescollection/#getCount--) 與 [IDrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idrawingguidescollection/#get_Item-int-) 方法即可存取現有的參考線。[IDrawingGuide.getOrientation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idrawingguide/#getOrientation--) 、[IDrawingGuide.getPosition](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idrawingguide/#getPosition--) 與 [IDrawingGuide.getColor](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idrawingguide/#getColor--) 方法會回傳可透過對應的設定子方法變更的值。

以下範例讀取上述建立的簡報中的投影片檢視參考線：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("drawing-guides.pptx");
try {
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    for (int index = 0; index < guides.getCount(); index++) {
        IDrawingGuide guide = guides.get_Item(index);
        System.out.println("Guide " + index + ": orientation = " + guide.getOrientation() + ", position = " + guide.getPosition() + ", color = " + guide.getColor());
    }
} finally {
    presentation.dispose();
}
```

## **將參考線新增至母片與版面投影片**

投影片母片及其每個版面投影片皆可擁有各自的繪圖參考線集合。對母片使用 [IMasterSlide.getDrawingGuides](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imasterslide/#getDrawingGuides--)，對版面投影片使用 [ILayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ilayoutslide/#getDrawingGuides--)。

以下範例在第一個母片上新增一條垂直參考線，並在第一個版面投影片上新增一條水平參考線：

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    IDrawingGuidesCollection layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(Orientation.Vertical, slideSize.getWidth() / 2 - 20);
    layoutGuides.add(Orientation.Horizontal, slideSize.getHeight() / 2 + 20);

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **將參考線新增至備註母片與講義母片**

備註母片與講義母片也支援繪圖參考線。使用 [IMasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imasternotesslide/#getDrawingGuides--) 與 [IMasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imasterhandoutslide/#getDrawingGuides--) 來存取它們的集合。如果簡報未包含其中任一母片，則可呼叫 [IMasterNotesSlideManager.setDefaultMasterNotesSlide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imasternotesslidemanager/#setDefaultMasterNotesSlide--) 或 [IMasterHandoutSlideManager.setDefaultMasterHandoutSlide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) 以建立預設母片並回傳它。

以下範例在備註母片上新增一條水平參考線，並在講義母片上新增一條垂直參考線：

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF notesSize = presentation.getNotesSize().getSize();
    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(Orientation.Horizontal, notesSize.getHeight() / 2 + 50);
    handoutMaster.getDrawingGuides().add(Orientation.Vertical, notesSize.getWidth() / 2 - 50);

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **清除繪圖參考線**

呼叫 [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idrawingguidescollection/#clear--) 可移除特定集合中的所有參考線。清除一個集合不會影響其他範圍中儲存的參考線。

以下範例在不建立缺少母片的情況下，清除投影片檢視參考線以及投影片母片、版面投影片、備註母片與講義母片上的所有參考線：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation-with-guides.pptx");
try {
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear();

    for (IMasterSlide masterSlide : presentation.getMasters()) {
        masterSlide.getDrawingGuides().clear();
    }

    for (ILayoutSlide layoutSlide : presentation.getLayoutSlides()) {
        layoutSlide.getDrawingGuides().clear();
    }

    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        notesMaster.getDrawingGuides().clear();
    }

    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();
    if (handoutMaster != null) {
        handoutMaster.getDrawingGuides().clear();
    }

    presentation.save("presentation-without-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**繪圖參考線會出現在投影片放映或匯出的影像中嗎？**

不會。繪圖參考線是供編輯使用的對齊輔助，並不會作為簡報內容呈現。

**是否可以直接將繪圖參考線新增至單一普通投影片？**

普通投影片的編輯參考線儲存在簡報的投影片檢視屬性中。投影片母片、版面投影片、備註母片與講義母片各有獨立的參考線集合。

**參考線位置使用哪種單位？**

位置以點 (points) 為單位，72 點等於一英吋。垂直位置以左邊緣為測量起點，水平位置以上邊緣為測量起點。

**清除繪圖參考線會移除形狀或變更投影片內容嗎？**

不會。[IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idrawingguidescollection/#clear--) 方法僅會移除所選集合中的參考線。形狀與其他投影片內容保持不變。