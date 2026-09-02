---
title: 在 Java 中管理簡報的繪圖參考線
linktitle: 繪圖參考線
type: docs
weight: 85
url: /zh-hant/java/drawing-guides/
keywords:
- 繪圖參考線
- 水平參考線
- 垂直參考線
- 對齊參考線
- 投影片檢視
- 母片
- 版面投影片
- 備註母片
- 講義母片
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 在 PowerPoint 簡報中新增、存取與清除水平與垂直繪圖參考線。"
---
## **概覽**

繪圖參考線是可調整的水平與垂直線條，可協助使用者在 PowerPoint 中編輯簡報時一致對齊圖形。當應用程式產生的簡報稍後需要手動潤飾時，參考線特別有用：應用程式可以儲存相同的對齊輔助，作者在新增或移動內容時遵循這些輔助線。

繪圖參考線是編輯輔助工具，而非投影片內容。它們不會出現在投影片放映或渲染輸出中。Aspose.Slides for Java 透過 [IDrawingGuidesCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/idrawingguidescollection/) 介面公開它們。參考線以 [IDrawingGuide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/idrawingguide/) 表示，具有方向、位置與顏色。

位置以點 (points) 為單位，從相關投影片或母片的左上角測量。垂直參考線使用水平座標，通常介於 0 與投影片寬度之間。水平參考線使用垂直座標，通常介於 0 與投影片高度之間。

## **將參考線加入投影片檢視**

使用 [ICommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/icommonslideviewproperties/#getDrawingGuides--) 來管理在一般投影片編輯時顯示的參考線。呼叫 [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/idrawingguidescollection/#add-byte-float-)，傳入 [Orientation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/orientation/) 值與點數位置。

下列範例在投影片中心右側加入一條垂直參考線，並在其下方加入一條水平參考線：

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(Orientation.Vertical, (float) (slideSize.getWidth() / 2 + 12.5));
    guides.add(Orientation.Horizontal, (float) (slideSize.getHeight() / 2 + 12.5));

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **存取繪圖參考線**

[IDrawingGuidesCollection.getCount](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/idrawingguidescollection/#getCount--) 與 [IDrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/idrawingguidescollection/#get_Item-int-) 方法可取得現有參考線。[IDrawingGuide.getOrientation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/idrawingguide/#getOrientation--)、[IDrawingGuide.getPosition](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/idrawingguide/#getPosition--) 與 [IDrawingGuide.getColor](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/idrawingguide/#getColor--) 方法會回傳值，這些值也可以透過相應的設定子方法修改。

下列範例讀取先前建立的簡報中的投影片檢視參考線：

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

## **將參考線加入母片與版面投影片**

母片及其各版面投影片皆可擁有自己的繪圖參考線集合。對於母片使用 [IMasterSlide.getDrawingGuides](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imasterslide/#getDrawingGuides--)，對於版面投影片使用 [ILayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilayoutslide/#getDrawingGuides--)。

下列範例在第一張母片上加入一條垂直參考線，並在第一張版面投影片上加入一條水平參考線：

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    IDrawingGuidesCollection layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(Orientation.Vertical, (float) (slideSize.getWidth() / 2 - 20));
    layoutGuides.add(Orientation.Horizontal, (float) (slideSize.getHeight() / 2 + 20));

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **將參考線加入備註母片與講義母片**

備註母片與講義母片同樣支援繪圖參考線。使用 [IMasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imasternotesslide/#getDrawingGuides--) 與 [IMasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imasterhandoutslide/#getDrawingGuides--) 取得它們的集合。如果簡報不包含這些母片，則可呼叫 [IMasterNotesSlideManager.setDefaultMasterNotesSlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imasternotesslidemanager/#setDefaultMasterNotesSlide--) 或 [IMasterHandoutSlideManager.setDefaultMasterHandoutSlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) 產生預設母片並回傳。

下列範例在備註母片加入水平參考線，並在講義母片加入垂直參考線：

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D notesSize = presentation.getNotesSize().getSize();
    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(Orientation.Horizontal, (float) (notesSize.getHeight() / 2 + 50));
    handoutMaster.getDrawingGuides().add(Orientation.Vertical, (float) (notesSize.getWidth() / 2 - 50));

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **清除繪圖參考線**

呼叫 [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/idrawingguidescollection/#clear--) 可移除特定集合中的全部參考線。清除一個集合不會影響其他範圍中的參考線。

下列範例在不建立缺少的母片情況下，清除投影片檢視參考線以及母片、版面投影片、備註母片與講義母片上的全部參考線：

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

## **常見問題**

**繪圖參考線會出現在投影片放映或匯出圖像中嗎？**

不會。繪圖參考線僅是編輯時的對齊輔助，並不會作為簡報內容呈現。

**可以直接將繪圖參考線新增至單一普通投影片嗎？**

普通投影片的編輯參考線儲存在簡報的投影片檢視屬性中。母片、版面投影片、備註母片與講義母片各自擁有獨立的參考線集合。

**參考線的位置使用什麼單位？**

位置以點為單位，1 英吋等於 72 點。垂直位置以左邊緣為基準測量，水平位置以上邊緣為基準測量。

**清除繪圖參考線會移除圖形或變更投影片內容嗎？**

不會。[IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/idrawingguidescollection/#clear--) 只會移除所選集合中的參考線，圖形與其他投影片內容保持不變。