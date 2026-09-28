---
title: 在 Java 中管理簡報投影片母片
linktitle: 投影片母片
type: docs
weight: 70
url: /zh-hant/java/slide-master/
keywords:
- 投影片母片
- 母片投影片
- PPT 母片投影片
- 多個母片投影片
- 比較母片投影片
- 背景
- 佔位符
- 複製母片投影片
- 拷貝母片投影片
- 重製母片投影片
- 未使用的母片投影片
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 中管理投影片母片：存取、編輯、複製、比較以及移除 PowerPoint 與 OpenDocument 簡報中的母片投影片。"
---
## **概觀**

**投影片母片** 定義一組投影片的共用設計設定。它可以包含共同的圖形、標誌、背景、文字樣式、主題設定以及頁尾設定。在 PowerPoint 中，編輯投影片母片是保持簡報一致性的常用方式，無需在每張投影片上重複相同的格式設定。

Aspose.Slides for Java 支援相同的模型。簡報可以包含一個或多個母片，且每個母片可以包含多個版面投影片。普通投影片通常不會直接參考母片；相反地，普通投影片使用版面投影片，而該版面投影片屬於某個母片。

層級結構為：

1. **投影片母片** - 定義共用的設計與主題。  
1. **版面投影片** - 定義特定的佔位符配置與版面層級的格式。  
1. **普通投影片** - 包含實際的簡報內容，使用一個版面投影片。

![母片、版面投影片與普通投影片的層級結構](slide-master_2.jpg)

在 Aspose.Slides 中，投影片母片由 [IMasterSlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imasterslide/) 介面表示。簡報中所有的母片可透過 [Presentation.getMasters](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#getMasters--) 集合取得，該集合實作 [IMasterSlideCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imasterslidecollection/)。

{{% alert color="info" title="Inheritance" %}}
當相同屬性在多個層級中被定義時，較具體的層級會取得優先權。例如，若母片與版面投影片皆定義了背景，則基於該版面的投影片會使用版面的背景。欲了解更多關於版面投影片的資訊，請參閱 [Apply or Change Slide Layouts](/slides/zh-hant/java/slide-layout/)。
{{% /alert %}}

## **存取投影片母片**

在 PowerPoint 中，您可以從 **檢視** > **投影片母片** 開啟投影片母片檢視。

![PowerPoint「檢視」索引標籤上的「投影片母片」指令](slide-master_3.jpg)

在 Aspose.Slides 中，使用 `getMasters()` 集合存取母片：

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

您也可以透過普通投影片的版面取得其使用的母片：

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

## **投影片母片的內容**

母片是一種類似投影片的物件。它實作 [IBaseSlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibaseslide/)，因此會公開許多普通投影片與版面投影片共用的屬性。母片專屬的成員請參閱 [IMasterSlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imasterslide/) API 頁面。

常用的母片成員包括：

| 成員 | 用途 |
| --- | --- |
| `getBackground()` | 設定母片層級的投影片背景。 |
| `getShapes()` | 儲存放置於母片上的圖形，例如標誌、圖片框與共用文字。 |
| `getLayoutSlides()` | 儲存屬於該母片的版面投影片。 |
| `getThemeManager()` | 提供存取母片主題 API 的功能。 |
| `getHeaderFooterManager()` | 控制母片及其子版面的頁首、頁尾、日期與投影片編號。 |
| `getDependingSlides()` | 取得依賴於該母片（透過其版面）的普通投影片。 |

## **在投影片母片中加入圖片**

將圖片加入母片後，會顯示於使用該母片版面的所有投影片上。此功能適用於標誌、水印、裝飾條及其他需要重複出現的視覺元素。

以下範例將標誌加入第一個母片：

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

欲了解更多關於圖片框的資訊，請參閱 [Picture Frame](/slides/zh-hant/java/picture-frame/)。

## **控制母片圖形的可見性**

使用 [IBaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibaseslide/#setShowMasterShapes-boolean-) 可隱藏繼承自母片的圖形（例如標誌或裝飾形狀），而不必從母片中刪除。對應的投影片使用 `false` 呼叫 [Slide.setShowMasterShapes](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slide/#setShowMasterShapes-boolean-)，而需要顯示圖形的投影片則保留 `true`。

以下自行完整的範例在母片上建立藍色裝飾條，並在兩張使用相同空白版面的投影片中分別顯示與隱藏該條帶。此範例不需要任何輸入簡報或圖片。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide layoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    layoutSlide.setShowMasterShapes(true);

    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();
    IAutoShape band = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
    Color bandColor = new Color(70, 130, 180);
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

範例使用新簡報預設提供的 **Blank** 版面，並移除初始投影片自行的佔位符。

### **選擇設定的範圍**

普通投影片透過 [ISlide.getLayoutSlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islide/#getLayoutSlide--) 與 [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilayoutslide/#getMasterSlide--) 取得其母片。將屬性設定於單一投影片，只會影響該投影片本身。將 `false` 傳遞給 [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/layoutslide/#setShowMasterShapes-boolean-)，會隱藏使用該共用版面的所有投影片的母片圖形，即使它們自己的設定為 `true`。若僅要在單一投影片上隱藏圖形，請變更該投影片的屬性，並保留共用版面不變。

此設定在母片本身上不支援可見性控制。對於母片，[getShowMasterShapes](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/masterslide/#getShowMasterShapes--) 永遠回傳 `false`，而將 `true` 傳遞給 [setShowMasterShapes](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/masterslide/#setShowMasterShapes-boolean-) 會拋出例外。請將此方法套用於普通投影片或版面。

### **區分圖形與背景**

| 操作 | 影響 |
| --- | --- |
| 隱藏母片圖形 | 在不刪除或變更投影片自身圖形的情況下，控制繼承自母片的圖形可見性。 |
| 變更投影片背景填色 | 變更背景顏色、漸層或圖片。母片圖形是獨立的形狀，仍可在背景上保持可見。請參閱 [Presentation Background](/slides/zh-hant/java/presentation-background/)。 |
| 從母片刪除圖形 | 移除共用來源圖形，之後任何使用該母片的投影片都將不再具有該圖形。 |

## **使用佔位符**

佔位符通常定義於版面投影片上。母片提供版面繼承的共用樣式與主題，而每個版面決定哪些佔位符可用以及它們的放置位置。

在 PowerPoint 中，佔位符指令可在投影片母片檢視中使用。

![PowerPoint 投影片母片檢視中的「插入佔位符」指令](slide-master_5.png)

要在 Aspose.Slides 中新增佔位符，請操作屬於母片的版面投影片：

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

您也可以格式化已存在於母片上的佔位符圖形。以下範例找出標題佔位符，並套用線性漸層填色：

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

![普通投影片繼承的已格式化標題佔位符](slide-master_8.png)

欲取得更多佔位符與文字格式選項，請參閱 [Set Prompt Text in Placeholder](/slides/zh-hant/java/manage-placeholder/) 與 [Text Formatting](/slides/zh-hant/java/text-formatting/)。

## **變更投影片母片背景**

母片背景會被版面與未覆寫背景的投影片繼承。以下範例為第一個母片設定單色背景：

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

相關主題請參閱 [Presentation Background](/slides/zh-hant/java/presentation-background/) 與 [Presentation Theme](/slides/zh-hant/java/presentation-theme/)。

## **將投影片母片複製至其他簡報**

使用 [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) 可將母片複製至其他簡報。複製後的母片即可由目標簡報的版面與投影片使用。

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

若需同時複製普通投影片及其母片，請參閱 [Clone Slides](/slides/zh-hant/java/clone-slides/)。

## **新增多個投影片母片**

簡報可以包含多個母片。這在不同章節需要不同品牌、頁面結構或主題設定時特別有用。

![PowerPoint 插入與管理母片的指令](slide-master_9.jpg)

以下範例會複製預設母片，為複製品設定不同背景，於該複製母片下建立版面，並依該版面新增投影片：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    Color sectionMasterBackgroundColor = Color.LIGHT_GRAY;

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

## **比較投影片母片**

母片可使用繼承自 [IBaseSlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibaseslide/) 的 `equals` 方法進行比較。比較會檢查結構與靜態內容，如圖形、文字、格式、動畫以及其他投影片設定。它不會比較唯一識別碼（例如投影片 ID）或動態佔位符值（例如目前日期）。

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

欲取得更多資訊，請參閱 [Compare Presentation Slides](/slides/zh-hant/java/compare-slides/)。

## **將投影片母片檢視設定為預設檢視**

使用 [ViewProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/viewproperties/) 上的 `setLastView` 方法，可控制 PowerPoint 首次開啟時的檢視模式。以下範例會在投影片母片檢視中開啟簡報：

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

更多檢視設定請參閱 [Save Presentation](/slides/zh-hant/java/save-presentation/)。

## **移除未使用的投影片母片**

有時簡報會保留不再被任何普通投影片使用的母片。移除未使用的母片可減少檔案大小並簡化模板維護。

使用 `removeUnused` 可從 `getMasters()` 集合中移除未使用的母片：

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

您也可以使用低程式碼的 [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) 方法：

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

## **常見問題集**

**投影片母片與版面投影片有何差異？**

投影片母片定義共用的設計設定，例如主題、背景、共用圖形與文字樣式。版面投影片屬於母片，定義特定的佔位符排列。普通投影片使用版面投影片，因此同時繼承版面與母片的設定。

**一個簡報可以包含多個投影片母片嗎？**

可以。簡報可以包含多個投影片母片。當不同章節需要不同的視覺系統或品牌時，請使用多個母片。

**應該將佔位符加入母片還是版面投影片？**

大多數情況下，應將佔位符加入版面投影片。將共用的視覺元素與共用格式放在母片上，然後在普通投影片將使用的版面上放置內容佔位符。

**我可以刪除仍在使用中的母片嗎？**

不能。已被依賴投影片使用的母片不能直接安全地刪除。請先將那些投影片移至其他母片的版面，或使用只會移除未被使用的母片的清除方法。