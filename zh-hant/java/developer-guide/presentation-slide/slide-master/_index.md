---
title: 在 Java 中管理簡報投影片母版
linktitle: 投影片母版
type: docs
weight: 70
url: /zh-hant/java/slide-master/
keywords:
- 投影片母版
- 母片
- PPT 母片
- 多個母片
- 比較母片
- 背景
- 佔位符
- 克隆母片
- 複製母片
- 重複母片
- 未使用的母片
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 中管理投影片母版：存取、編輯、克隆、比較與移除 PowerPoint 與 OpenDocument 簡報中的母片。"
---
## **概觀**

**slide master** 定義了一組投影片的共享設計設定。它可以包含共同的圖形、標誌、背景、文字樣式、佈景主題設定以及頁尾設定。在 PowerPoint 中，編輯 slide master 是在不必在每張投影片上重複相同格式的情況下，保持簡報一致性的常用方式。

Aspose.Slides for Java 支援相同的模型。簡報可以包含一個或多個 master slide，而每個 master slide 可以包含多個 layout slide。正常投影片通常不會直接參照 master slide。相反地，正常投影片會使用 layout slide，而該 layout slide 隸屬於某個 master slide。

層級結構如下：

1. **Slide master** - 定義共享的設計與佈景主題。
2. **Layout slide** - 定義佔位符的具體排列以及版面層級的格式設定。
3. **Normal slide** - 包含實際的簡報內容，並使用一個 layout slide。

![master slide、layout slide 與 normal slide 的層級結構](slide-master_2.jpg)

在 Aspose.Slides 中，slide master 由 [IMasterSlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imasterslide/) 介面表示。簡報中的所有 master slide 可透過 [Presentation.getMasters](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#getMasters--) 集合取得，該集合實作了 [IMasterSlideCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imasterslidecollection/)。

{{% alert color="info" title="Inheritance" %}}
當相同的屬性在多個層級皆被定義時，較具體的層級會優先。舉例來說，若 master slide 與 layout slide 皆定義了背景，基於該 layout 的投影片會使用 layout 背景。欲取得有關 layout slide 的更多資訊，請參閱 [Apply or Change Slide Layouts](/slides/zh-hant/java/slide-layout/)。
{{% /alert %}}

## **存取 Slide Master**

在 PowerPoint 中，您可以從 **View** > **Slide Master** 開啟 Slide Master 檢視。

![PowerPoint 檢視功能表中 Slide Master 指令](slide-master_3.jpg)

在 Aspose.Slides 中，使用 `getMasters()` 集合來存取 master slide：

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

您也可以透過其 layout 取得普通投影片所使用的 master slide：

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

## **Slide Master 包含的內容**

master slide 是類似投影片的物件。它實作了 [IBaseSlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibaseslide/)，因此會公開許多在 normal 與 layout slide 中使用的相同投影片屬性。Master 專屬的成員列於 [IMasterSlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imasterslide/) API 頁面上。

常用的 master slide 成員包括：

| 成員 | 目的 |
| --- | --- |
| `getBackground()` | 設定 master 層級投影片背景。 |
| `getShapes()` | 儲存放置在 master 上的形狀，例如標誌、圖片框與共享文字。 |
| `getLayoutSlides()` | 儲存屬於該 master 的 layout slide。 |
| `getThemeManager()` | 提供取得 master 主題 API 的介面。 |
| `getHeaderFooterManager()` | 控制 master 及其子 layout 的頁首、頁尾、日期與投影片編號。 |
| `getDependingSlides()` | 回傳透過其 layout 依賴該 master 的 normal 投影片。 |

## **在 Slide Master 中新增影像**

當您將影像加入 master slide 時，使用該 master 的 layout 的投影片皆會顯示該影像。這對於標誌、水印、裝飾條紋以及其他重複的視覺元素非常有用。

以下範例將標誌新增至第一個 master slide：

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

欲取得有關圖片框的更多資訊，請參閱 [Picture Frame](/slides/zh-hant/java/picture-frame/)。

## **處理 Placeholder**

Placeholder 通常在 layout slide 上定義。master slide 提供共享的樣式與主題，讓這些 layout 繼承；而每個 layout 決定哪些 placeholder 可用以及其放置位置。

在 PowerPoint 中，placeholder 指令可於 Slide Master 檢視中使用。

![PowerPoint Slide Master 檢視中的 Insert Placeholder 指令](slide-master_5.png)

若要使用 Aspose.Slides 新增 placeholder，請操作屬於該 master 的 layout slide：

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

您也可以格式化已存在於 master slide 上的 placeholder 形狀。以下範例尋找標題 placeholder 並套用線性漸層填色：

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
        Color redGradientColor = new Color(255, 0, 0);
        Color purpleGradientColor = new Color(128, 0, 128);

        titlePlaceholder.getFillFormat().setFillType(FillType.Gradient);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0f, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(255.0f, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![已格式化的標題 placeholder，普通投影片繼承自 master slide](slide-master_8.png)

欲取得更多 placeholder 與文字格式設定選項，請參閱 [Set Prompt Text in Placeholder](/slides/zh-hant/java/manage-placeholder/) 與 [Text Formatting](/slides/zh-hant/java/text-formatting/)。

## **變更 Slide Master 背景**

master 背景會被未覆寫的 layout 與投影片繼承。以下範例為第一個 master slide 設定純色背景：

```java
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

## **將 Slide Master 複製至其他簡報**

使用 [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) 將 master slide 複製至另一個簡報。複製後的 master 可供目標簡報中的 layout 與投影片使用。

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

若需同時複製包含其 master 的 normal 投影片，請參閱 [Clone Slides](/slides/zh-hant/java/clone-slides/)。

## **新增多個 Slide Master**

簡報可以包含多個 master slide。當不同章節需要不同的品牌識別、頁面結構或主題設定時，此功能相當有用。

![PowerPoint 插入與管理 master slide 的指令](slide-master_9.jpg)

以下範例會複製預設 master、為其副本設定不同的背景、在該複製 master 下建立 layout，並依據該 layout 新增投影片：

```java
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

## **比較 Slide Master**

可使用繼承自 [IBaseSlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibaseslide/) 的 `equals` 方法比較 master slide。比較會檢查結構與靜態內容，如形狀、文字、格式、動畫以及其他投影片設定。它不會比較唯一識別碼（例如 slide ID）或動態的 placeholder 值（例如當前日期）。

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

欲取得更多資訊，請參閱 [Compare Presentation Slides](/slides/zh-hant/java/compare-slides/)。

## **將 Slide Master 檢視設為預設檢視**

使用 [ViewProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/viewproperties/) 上的 `setLastView` 方法可控制 PowerPoint 首次開啟的檢視。以下範例在 Slide Master 檢視中開啟簡報：

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

更多檢視設定請參閱 [Save Presentation](/slides/zh-hant/java/save-presentation/)。

## **移除未使用的 Master Slide**

簡報有時會包含不再被任何 normal 投影片使用的 master slide。移除未使用的 master 可減少檔案大小並簡化範本維護。

使用 `removeUnused` 從 `getMasters()` 集合中移除未使用的 master：

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

也可以使用低碼的 [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) 方法：

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常見問題**

**Slide master 與 layout slide 的差異是什麼？**

slide master 定義共享的設計設定，例如主題、背景、共用圖形與文字樣式。layout slide 隸屬於某個 master slide，並規定 placeholder 的具體排列。normal 投影片使用 layout slide，因此同時繼承 layout 與 master 的設定。

**一個簡報可以包含多個 slide master 嗎？**

可以。簡報可以包含多個 slide master。當不同章節需要不同的視覺系統或品牌識別時，可使用多個 master。

**應該在 master slide 還是 layout slide 添加 placeholder？**

大多數情況下，應在 layout slide 添加 placeholder。將共享的視覺元素與格式放在 master slide，然後在 normal 投影片將使用的 layout 上放置內容 placeholder。

**我可以刪除仍在使用中的 master slide 嗎？**

不能。若 master slide 有相依的投影片，則不能直接安全地刪除。必須先將這些投影片移至其他 master 下的 layout，或使用只移除未被使用的 master 的清理方法。