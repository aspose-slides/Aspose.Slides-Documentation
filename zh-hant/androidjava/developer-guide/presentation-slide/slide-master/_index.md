---
title: 在 Android 上管理簡報投影片母片
linktitle: 投影片母片
type: docs
weight: 70
url: /zh-hant/androidjava/slide-master/
keywords:
- 投影片母片
- 母片投影片
- PPT 母片投影片
- 多個母片投影片
- 比較母片投影片
- 背景
- 占位元件
- 克隆母片投影片
- 複製母片投影片
- 重複母片投影片
- 未使用的母片投影片
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Android via Java 中管理投影片母片：存取、編輯、克隆、比較及移除 PowerPoint 與 OpenDocument 簡報中的母片投影片。"
---
## **概述**

**投影片母片** 定義一組投影片的共享設計設定。它可以包含共用圖形、標誌、背景、文字樣式、佈景主題設定以及頁腳設定。在 PowerPoint 中，編輯投影片母片是保持簡報一致性的常用方式，無需在每張投影片上重複相同的格式設定。

Aspose.Slides for Android via Java 支援相同的模型。簡報可以包含一個或多個母片，而每個母片可以包含多個版面投影片。一般投影片通常不會直接參考母片，而是使用版面投影片，該版面投影片屬於某個母片。

層級結構如下：

1. **投影片母片** - 定義共享的設計與佈景主題。
2. **版面投影片** - 定義占位元件的特定排列與版面層級的格式設定。
3. **一般投影片** - 包含實際的簡報內容，並使用一個版面投影片。

![母片、版面投影片與一般投影片的層級結構](slide-master_2.jpg)

在 Aspose.Slides 中，投影片母片由 [IMasterSlide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imasterslide/) 介面表示。簡報中所有的母片皆可透過 [Presentation.getMasters](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#getMasters--) 集合取得，該集合實作 [IMasterSlideCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imasterslidecollection/)。欲了解完整的 Android via Java API，請參閱 [com.aspose.slides API 參考文件](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/)。

{{% alert color="info" title="Inheritance" %}}
當相同屬性在多個層級中皆有定義時，較具體的層級會取得優先權。例如，若母片與版面投影片皆定義了背景，基於該版面的投影片會使用版面的背景。欲取得更多有關版面投影片的資訊，請參閱 [Apply or Change Slide Layouts](/slides/zh-hant/androidjava/slide-layout/)。
{{% /alert %}}

## **存取投影片母片**

在 PowerPoint 中，您可以從 **檢視** > **投影片母片** 開啟投影片母片檢視。

![PowerPoint 檢視索引標籤上的投影片母片指令](slide-master_3.jpg)

在 Aspose.Slides 中，使用 `getMasters()` 集合來存取母片：

```java
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

您也可以透過一般投影片的版面取得其使用的母片：

```java
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

母片是一種類似投影片的物件。它實作 [IBaseSlide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibaseslide/)，因此會公開許多與一般投影片與版面投影片相同的屬性。

常用的母片成員包括：

| 成員 | 用途 |
| --- | --- |
| `getBackground()` | 設定母片層級的投影片背景。 |
| `getShapes()` | 儲存放置於母片上的圖形，例如標誌、圖片框架及共享文字。 |
| `getLayoutSlides()` | 儲存屬於該母片的版面投影片。 |
| `getThemeManager()` | 提供存取母片佈景主題 API 的介面。 |
| `getHeaderFooterManager()` | 控制母片及其子版面的頁首、頁尾、日期與投影片編號。 |
| `getDependingSlides()` | 回傳透過版面依賴該母片的一般投影片。 |

## **向投影片母片新增圖片**

當您將圖片加入母片時，使用該母片版面的投影片皆會顯示該圖片。這對於加入標誌、浮水印、裝飾條紋及其他重複的視覺元素相當有用。

以下範例將標誌加入第一個母片：

```java
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

欲取得更多關於圖片框的資訊，請參閱 [Picture Frame](/slides/zh-hant/androidjava/picture-frame/)。

## **處理占位元件**

占位元件通常在版面投影片上定義。母片提供共享的樣式與佈景主題，讓這些版面繼承；每個版面決定哪些占位元件可用以及它們的放置位置。

在 PowerPoint 中，占位元件指令可在投影片母片檢視中使用。

![PowerPoint 投影片母片檢視中的「插入占位元件」指令](slide-master_5.png)

若要使用 Aspose.Slides 新增占位元件，請對屬於母片的版面投影片進行操作：

```java
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

您也可以格式化已存在於母片上的占位元件形狀。以下範例找出標題占位元件並套用線性漸層填色：

```java
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
        int redGradientColor = Color.valueOf(255, 0, 0).toArgb();
        int purpleGradientColor = Color.valueOf(128, 0, 128).toArgb();

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

![已格式化的標題占位元件由一般投影片繼承](slide-master_8.png)

欲取得更多占位元件與文字格式化選項，請參閱 [Set Prompt Text in Placeholder](/slides/zh-hant/androidjava/manage-placeholder/) 與 [Text Formatting](/slides/zh-hant/androidjava/text-formatting/)。

## **變更投影片母片背景**

母片背景會被未覆寫的版面與投影片繼承。以下範例為第一個母片設定純色背景：

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    int masterBackgroundColor = Color.GREEN;

    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

相關主題請參閱 [Presentation Background](/slides/zh-hant/androidjava/presentation-background/) 與 [Presentation Theme](/slides/zh-hant/androidjava/presentation-theme/)。

## **將投影片母片克隆至另一個簡報**

使用 [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) 便可將母片複製至另一個簡報。複製後的母片即可在目標簡報的版面與投影片中使用。

```java
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

若需同時克隆一般投影片及其母片，請參閱 [Clone Slides](/slides/zh-hant/androidjava/clone-slides/)。

## **加入多個投影片母片**

一個簡報可以包含多個母片。當不同章節需要不同的品牌、頁面結構或佈景主題設定時，這相當有用。

![PowerPoint 插入與管理母片的指令](slide-master_9.jpg)

以下範例會克隆預設母片、為克隆後的母片設定不同的背景、在該克隆母片下建立版面，並新增一張基於該版面的投影片：

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    int sectionMasterBackgroundColor = Color.GRAY;

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

母片可以使用從 [IBaseSlide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibaseslide/) 繼承的 `equals` 方法進行比較。比較會檢查結構與靜態內容，例如圖形、文字、格式、動畫及其他投影片設定。它不會比較唯一識別碼（如投影片 ID）或動態占位元件值（如目前日期）。

```java
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

## **將投影片母片檢視設定為預設檢視**

使用 [ViewProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/viewproperties/) 上的 `setLastView` 方法，可控制 PowerPoint 首次開啟的檢視。以下範例會在投影片母片檢視中開啟簡報：

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

欲取得更多檢視設定，請參閱 [Save Presentation](/slides/zh-hant/androidjava/save-presentation/)。

## **移除未使用的投影片母片**

簡報有時會包含已不再被任何一般投影片使用的母片。移除未使用的母片可減少檔案大小，並簡化範本維護。

使用 `removeUnused` 從 `getMasters()` 集合中移除未使用的母片：

```java
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
Presentation presentation = new Presentation("presentation.pptx");
try {
    Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**投影片母片與版面投影片有何差異？**  
投影片母片定義共享的設計設定，例如佈景主題、背景、共用圖形與文字樣式。版面投影片屬於母片，定義占位元件的特定排列。一般投影片使用版面投影片，因而同時繼承版面與母片的設定。

**一個簡報可以包含多個投影片母片嗎？**  
可以。簡報可以包含多個投影片母片。當不同章節需要不同的視覺系統或品牌時，請使用多個母片。

**應該在母片還是版面投影片上加入占位元件？**  
大多數情況下，應在版面投影片上加入占位元件。將共享的視覺元素與共享格式放在母片上，然後將內容占位元件放在一般投影片將使用的版面上。

**我可以刪除仍在使用中的母片嗎？**  
不能。具有相依投影片的母片無法直接安全刪除。必須先將那些投影片移動至其他母片下的版面，或使用僅移除未使用母片的清理方法。