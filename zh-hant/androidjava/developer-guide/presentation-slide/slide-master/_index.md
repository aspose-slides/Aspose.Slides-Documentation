---
title: 在 Android 上管理簡報投影片主版
linktitle: 投影片主版
type: docs
weight: 70
url: /zh-hant/androidjava/slide-master/
keywords:
- 投影片主版
- 主版投影片
- PPT 主版投影片
- 多個主版投影片
- 比較主版投影片
- 背景
- 佔位符
- 複製主版投影片
- 拷貝主版投影片
- 重複主版投影片
- 未使用的主版投影片
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Android via Java 中管理投影片主版：存取、編輯、複製、比較及移除 PowerPoint 與 OpenDocument 簡報中的主版投影片。"
---
## **概觀**

**slide master** 定義一組投影片的共享設計設定。它可以包含共用圖形、標誌、背景、文字樣式、主題設定和頁腳設定。在 PowerPoint 中，編輯 slide master 是保持簡報一致性的常用方式，無需在每張投影片上重複相同的格式設定。

Aspose.Slides for Android via Java 支援相同的模型。一個簡報可以包含一個或多個 master slide，而每個 master slide 可以包含多個 layout slide。普通投影片通常不會直接參照 master slide。而是普通投影片使用 layout slide，該 layout slide 屬於一個 master slide。

層級結構如下：

1. **Slide master** - 定義共享的設計與主題。
1. **Layout slide** - 定義 placeholder 以及版面層級格式的特定排列。
1. **Normal slide** - 包含實際的簡報內容，並使用一個 layout slide。

![master slide、layout slide 與 normal slide 的層級結構](slide-master_2.jpg)

在 Aspose.Slides 中，slide master 以 [IMasterSlide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imasterslide/) 介面表示。簡報中所有的 master slide 可透過 [Presentation.getMasters](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#getMasters--) 集合取得，該集合實作 [IMasterSlideCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imasterslidecollection/)。欲取得完整的 Android via Java API，請參閱 [com.aspose.slides API reference](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/)。

{{% alert color="info" title="Inheritance" %}}
當同一屬性在多個層級中都被定義時，以較具體的層級為準。例如，若 master slide 與 layout slide 都定義了背景，基於該 layout 的投影片會使用 layout 背景。欲取得更多有關 layout slide 的資訊，請參閱 [Apply or Change Slide Layouts](/slides/zh-hant/androidjava/slide-layout/)。
{{% /alert %}}

## **存取 Slide Masters**

在 PowerPoint 中，您可以從 **View** > **Slide Master** 開啟 Slide Master 檢視。

![The Slide Master command on the PowerPoint View tab](slide-master_3.jpg)

在 Aspose.Slides 中，使用 `getMasters()` 集合來存取 master slide：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
    int masterSlideCount = presentation.getMasters().size();
    int firstMasterLayoutSlideCount = firstMasterSlide.getLayoutSlides().size();

    System.out.println("Master slides: " + masterSlideCount);
    System.out.println("Layouts in the first master: " + firstMasterLayoutSlideCount);
} finally {
    presentation.dispose();
}
```

您也可以透過其 layout 取得普通投影片所使用的 master slide：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = slide.getLayoutSlide();
    IMasterSlide masterSlide = layoutSlide.getMasterSlide();
    String masterSlideName = masterSlide.getName();

    System.out.println(masterSlideName);
} finally {
    presentation.dispose();
}
```

## **Slide Master 內的內容**

master slide 是類似投影片的物件。它實作 [IBaseSlide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibaseslide/)，因此會公開許多普通投影片與 layout slide 所使用的相同投影片屬性。

常用的 master slide 成員包括：

| 成員 | 目的 |
| --- | --- |
| `getBackground()` | 設定 master 級別的投影片背景。 |
| `getShapes()` | 儲存放置於 master 上的圖形，例如標誌、圖片框與共享文字。 |
| `getLayoutSlides()` | 儲存屬於該 master 的 layout slide。 |
| `getThemeManager()` | 提供存取 master 主題 API 的功能。 |
| `getHeaderFooterManager()` | 控制 master 及其子 layout 的頁首、頁腳、日期與投影片編號。 |
| `getDependingSlides()` | 回傳透過 layout 依賴於該 master 的普通投影片。 |

## **將影像新增至 Slide Master**

當您將影像新增至 master slide 時，使用該 master 之 layout 的投影片都會顯示該影像。這對於標誌、浮水印、裝飾帶及其他重複的視覺元素相當有用。

以下範例將標誌新增至第一個 master slide：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    IImage logo = Images.fromFile("logo.png");

    try {
        IPPImage logoImage = presentation.getImages().addImage(logo);

        masterSlide.getShapes().addPictureFrame(
                ShapeType.Rectangle,
                20,
                20,
                80,
                80,
                logoImage);
    } finally {
        logo.dispose();
    }

    presentation.save("presentation-with-logo.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

欲取得更多有關圖片框的資訊，請參閱 [Picture Frame](/slides/zh-hant/androidjava/picture-frame/)。

## **控制 Master 圖形的可見性**

使用 [IBaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibaseslide/#setShowMasterShapes-boolean-) 來隱藏繼承自 master 的圖形，例如標誌或裝飾形狀，而無需從 master 中刪除它們。對於應該省略這些圖形的投影片，將 `false` 傳遞給 [Slide.setShowMasterShapes](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slide/#setShowMasterShapes-boolean-)；對於應該顯示它們的投影片，則保持 `true`。

以下獨立範例在 master 上建立藍色裝飾帶，並建立兩張使用相同空白 layout 的投影片。該帶在第一張投影片可見，第二張則隱藏。無需提供輸入簡報或影像。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide layoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    layoutSlide.setShowMasterShapes(true);

    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();
    IAutoShape band = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
    int bandColor = Color.rgb(70, 130, 180);
    band.getFillFormat().setFillType(FillType.Solid);
    band.getFillFormat().getSolidFillColor().setColor(bandColor);
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    ISlide visibleSlide = presentation.getSlides().get_Item(0);
    visibleSlide.setLayoutSlide(layoutSlide);
    visibleSlide.getShapes().clear();

    ISlide hiddenSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    visibleSlide.setShowMasterShapes(true);
    hiddenSlide.setShowMasterShapes(false);

    presentation.save("master-graphics.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

此範例使用新簡報所提供的 **Blank** layout，並移除初始投影片的自有 placeholder。

### **設定範圍的選擇**

普通投影片透過 [ISlide.getLayoutSlide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islide/#getLayoutSlide--) 與 [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ilayoutslide/#getMasterSlide--) 使用其 master。對單一投影片設定屬性僅會影響該投影片。將 `false` 傳遞給 [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/layoutslide/#setShowMasterShapes-boolean-) 會隱藏使用該共享 layout 的所有投影片的 master 圖形，即使它們各自的設定為 `true`。若只想在單一投影片隱藏圖形，請變更該投影片的屬性而不更動共享 layout。

此設定在 master slide 本身並不支援可見性控制。在 master 上，[getShowMasterShapes](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/masterslide/#getShowMasterShapes--) 永遠回傳 `false`，將 `true` 傳遞給 [setShowMasterShapes](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/masterslide/#setShowMasterShapes-boolean-) 會拋出例外。請改在普通投影片或 layout 上套用。

### **區分圖形與背景**

| 操作 | 效果 |
| --- | --- |
| 隱藏 master 圖形 | 在不刪除圖形或變更投影片自身圖形的情況下，控制繼承的 master 圖形可見性。 |
| 變更投影片背景填充 | 變更背景顏色、漸層或影像。Master 圖形是獨立的形狀，可在該背景上保持可見。請參閱 [Presentation Background](/slides/zh-hant/androidjava/presentation-background/)。 |
| 從 master 刪除形狀 | 移除共用來源形狀，所有使用該 master 的投影片將不再可用。 |

## **處理 Placeholder**

Placeholder 通常定義於 layout slide。master slide 提供這些 layout 繼承的共享樣式與主題，而每個 layout 決定可用的 placeholder 以及其放置位置。

在 PowerPoint 中，Placeholder 指令可於 Slide Master 檢視中使用。

![The Insert Placeholder command in PowerPoint Slide Master view](slide-master_5.png)

要使用 Aspose.Slides 新增 Placeholder，請處理屬於該 master 的 layout slide：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide blankLayoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);

    if (blankLayoutSlide == null) {
        blankLayoutSlide = masterSlide.getLayoutSlides().add(SlideLayoutType.Blank, "Blank");
    }

    blankLayoutSlide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80);

    presentation.getSlides().addEmptySlide(blankLayoutSlide);
    presentation.save("presentation-with-placeholder.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

您也可以格式化已存在於 master slide 上的 placeholder 形狀。以下範例尋找標題 placeholder 並套用線性漸層填充：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    IAutoShape titlePlaceholder = null;

    for (IShape shape : masterSlide.getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;

            if (autoShape.getPlaceholder() != null &&
                    autoShape.getPlaceholder().getType() == PlaceholderType.Title) {
                titlePlaceholder = autoShape;
                break;
            }
        }
    }

    if (titlePlaceholder != null) {
        Color redGradientColor = new Color(255, 0, 0);
        Color purpleGradientColor = new Color(128, 0, 128);

        titlePlaceholder.getFillFormat().setFillType(FillType.Gradient);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0f, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0f, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Formatted title placeholder inherited by normal slides](slide-master_8.png)

欲取得更多 placeholder 與文字格式設定選項，請參閱 [Set Prompt Text in Placeholder](/slides/zh-hant/androidjava/manage-placeholder/) 與 [Text Formatting](/slides/zh-hant/androidjava/text-formatting/).

## **變更 Slide Master 背景**

master 背景會被未覆寫的 layout 與投影片繼承。以下範例為第一個 master slide 設定純色背景：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    Color masterBackgroundColor = Color.GREEN;

    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

相關主題請參閱 [Presentation Background](/slides/zh-hant/androidjava/presentation-background/) 和 [Presentation Theme](/slides/zh-hant/androidjava/presentation-theme/)。

## **將 Slide Master 複製至其他簡報**

使用 [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) 將 master slide 複製到另一個簡報。複製後的 master 可由目標簡報中的 layout 與投影片使用。

```java
import com.aspose.slides.*;

Presentation sourcePresentation = new Presentation("source.pptx");
Presentation destinationPresentation = new Presentation("destination.pptx");
try {
    IMasterSlide sourceMasterSlide = sourcePresentation.getMasters().get_Item(0);
    IMasterSlide clonedMasterSlide = destinationPresentation.getMasters().addClone(sourceMasterSlide);

    destinationPresentation.save("destination-with-master.pptx", SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
    destinationPresentation.dispose();
}
```

如果需要同時複製包含其 master 的普通投影片，請參閱 [Clone Slides](/slides/zh-hant/androidjava/clone-slides/)。

## **新增多個 Slide Master**

簡報可以包含多個 master slide。當不同章節需要不同品牌、頁面結構或主題設定時，這非常有用。

![PowerPoint commands for inserting and managing master slides](slide-master_9.jpg)

以下範例複製預設 master，為複本設定不同的背景，在該複製 master 下建立 layout，並新增基於該 layout 的投影片：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    Color sectionMasterBackgroundColor = Color.GRAY;

    sectionMasterSlide.getBackground().setType(BackgroundType.OwnBackground);
    sectionMasterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    sectionMasterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(sectionMasterBackgroundColor);

    ILayoutSlide sourceBlankLayout = defaultMasterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    if (sourceBlankLayout == null) {
        sourceBlankLayout = defaultMasterSlide.getLayoutSlides().get_Item(0);
    }

    ILayoutSlide sectionBlankLayout = sectionMasterSlide.getLayoutSlides().addClone(sourceBlankLayout);

    presentation.getSlides().addEmptySlide(sectionBlankLayout);
    presentation.save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **比較 Slide Master**

可以使用從 [IBaseSlide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibaseslide/) 繼承的 `equals` 方法比較 master slide。比較會檢查結構與靜態內容，如形狀、文字、格式、動畫與其他投影片設定。它不會比較唯一識別碼（如投影片 ID）或動態 placeholder 值（如當前日期）。

```java
import com.aspose.slides.*;

Presentation firstPresentation = new Presentation("first.pptx");
Presentation secondPresentation = new Presentation("second.pptx");
try {
    int firstPresentationMasterCount = firstPresentation.getMasters().size();
    int secondPresentationMasterCount = secondPresentation.getMasters().size();

    for (int firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++) {
        for (int secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++) {
            IMasterSlide firstMasterSlide = firstPresentation.getMasters().get_Item(firstMasterIndex);
            IMasterSlide secondMasterSlide = secondPresentation.getMasters().get_Item(secondMasterIndex);
            boolean areMasterSlidesEqual = firstMasterSlide.equals(secondMasterSlide);

            if (areMasterSlidesEqual) {
                System.out.printf(
                        "first.pptx master #%d equals second.pptx master #%d%n",
                        firstMasterIndex,
                        secondMasterIndex);
            }
        }
    }
} finally {
    firstPresentation.dispose();
    secondPresentation.dispose();
}
```

欲取得更多資訊，請參閱 [Compare Presentation Slides](/slides/zh-hant/androidjava/compare-slides/)。

## **將 Slide Master 檢視設為預設檢視**

使用 [ViewProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/viewproperties/) 上的 `setLastView` 方法可控制 PowerPoint 首次開啟的檢視。以下範例在 Slide Master 檢視中開啟簡報：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

更多檢視設定請參閱 [Save Presentation](/slides/zh-hant/androidjava/save-presentation/)。

## **移除未使用的 Master Slide**

簡報有時會包含已不被任何普通投影片使用的 master slide。移除未使用的 master 可減少檔案大小並簡化樣板維護。

使用 `removeUnused` 從 `getMasters()` 集合中移除未使用的 master：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

您也可以使用低程式碼的 [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) 方法：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**什麼是 slide master 與 layout slide 的差異？**

slide master 定義共享的設計設定，如主題、背景、共用圖形與文字樣式。layout slide 隸屬於 master，定義 placeholder 的具體排列。普通投影片使用 layout slide，因而同時繼承 layout 與 master 的設定。

**一個簡報可以包含多個 slide master 嗎？**

可以。簡報可以包含多個 slide master。當不同章節需要不同的視覺系統或品牌時，請使用多個 master。

**應該將 placeholder 加到 master slide 還是 layout slide？**

大多數情況下，應將 placeholder 加到 layout slide。將共享的視覺元素與格式放在 master slide，上述的內容 placeholder 則放在普通投影片將使用的 layout 中。

**我可以刪除仍被使用的 master slide 嗎？**

不能。仍有相依投影片的 master slide 無法直接安全刪除。請先將這些投影片移至其他 master 的 layout，或使用僅移除未被使用的 master 的清理方法。