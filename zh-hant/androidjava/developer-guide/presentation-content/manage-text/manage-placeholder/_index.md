---
title: 管理 Android 上的簡報佔位符
linktitle: 管理佔位符
type: docs
weight: 10
url: /zh-hant/androidjava/manage-placeholder/
keywords:
- 佔位符
- 文字佔位符
- 圖片佔位符
- 圖表佔位符
- 內容佔位符
- 提示文字
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Android via Java 檢查與編輯文字、圖片、圖表與內容佔位符，並了解佔位符繼承關係。"
---
## **概覽**

佔位符是一種形狀，用於在簡報範本中為特定類型的內容保留位置。常見的例子包括標題、內文、圖片、圖表以及通用內容佔位符。與普通形狀不同，佔位符可以從版面投影片或母片繼承其位置、大小、格式以及其他設定。

Aspose.Slides 透過 [IShape.getPlaceholder](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/) 方法公開佔位符資訊。此方法會回傳 [IPlaceholder](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/placeholder/) 物件，對於普通形狀則回傳 `null`。使用 [IPlaceholder.getType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/placeholder/) 可判斷佔位符預計包含的內容。

形狀介面在了解佔位符類型後仍然重要：

- 空的文字、圖片、圖表或內容佔位符通常以 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/) 表示。
- 已填入圖片的佔位符可以以 [IPictureFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipictureframe/) 表示。
- 已填入圖表的佔位符可以以 [IChart](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichart/) 表示。
- 內容佔位符可以容納多種內容。請同時檢查 [IPlaceholder.getType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/placeholder/) 與執行時的形狀介面，而不要假設每個佔位符都是 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/)。

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/placeholder/) 只描述佔位符的角色；它無法保證形狀的執行時類型。存取文字、圖片、圖表、表格或媒體相關成員之前，務必先進行類型檢查。
{{% /alert %}}

## **了解佔位符繼承**

佔位符形成階層結構：

1. 母片定義可重複使用的樣式，且在某些情況下包含母片層級的佔位符。
2. 版面投影片定義一或多張普通投影片使用的版面配置，且可以繼承自母片。
3. 普通投影片包含該投影片的佔位符，並可繼承自其版面。

呼叫 [IShape.getBasePlaceholder](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/) 可往上移動一層階層。投影片佔位符通常回傳其版面佔位符；版面佔位符則可回傳其母片佔位符。當形狀沒有基礎佔位符時，此方法會回傳 `null`。

以下範例會列出第一張投影片的佔位符，並回報它們的基礎佔位符：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        String typeName = shape.getClass().getSimpleName();
        String slidePlaceholderMessage = "Slide placeholder: " + placeholderType + "; shape interface: " + typeName;
        System.out.println(slidePlaceholderMessage);

        IShape layoutPlaceholder = shape.getBasePlaceholder();
        if (layoutPlaceholder != null) {
            IPlaceholder layoutPlaceholderInfo = layoutPlaceholder.getPlaceholder();
            Byte layoutPlaceholderType = layoutPlaceholderInfo == null ? null : layoutPlaceholderInfo.getType();
            String layoutPlaceholderMessage = "  Layout placeholder: " + layoutPlaceholderType;
            System.out.println(layoutPlaceholderMessage);

            IShape masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            if (masterPlaceholder != null) {
                IPlaceholder masterPlaceholderInfo = masterPlaceholder.getPlaceholder();
                Byte masterPlaceholderType = masterPlaceholderInfo == null ? null : masterPlaceholderInfo.getType();
                String masterPlaceholderMessage = "  Master placeholder: " + masterPlaceholderType;
                System.out.println(masterPlaceholderMessage);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

在普通投影片上編輯佔位符會為該投影片建立或變更本機覆寫。編輯相關的版面或母片則會影響所有仍繼承該設定的投影片。本機普通形狀沒有基礎佔位符，僅因佔據相同座標不會開始繼承。

## **變更佔位符文字**

標題、置中標題、副標題、內文與文字佔位符通常支援文字。使用其 [getTextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/) 方法前，請先確認是否為 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/)。

以下範例會更新第一張投影片的第一個標題佔位符，並儲存結果：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape titleShape = null;

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAutoShape)) {
            continue;
        }

        IAutoShape autoShape = (IAutoShape) shape;
        IPlaceholder placeholder = autoShape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) {
            titleShape = autoShape;
            break;
        }
    }

    if (titleShape == null) {
        throw new IllegalStateException("The first slide does not contain a title placeholder.");
    }

    titleShape.getTextFrame().setText("Quarterly Business Review");
    presentation.save("title-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

此模式避免將圖片、圖表、表格或媒體佔位符強制轉型為 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/)。此外，它會依用途辨識佔位符，而非依賴不穩定的形狀索引。

## **在版面設定提示文字**

提示文字是顯示在空佔位符中的設計時指示，例如 *Click to add title*。請在版面佔位符上設定自訂提示文字，而不是透過普通投影片的形狀集合取得。可透過 [ISlide.getLayoutSlide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islide/) 存取版面，並迭代 [ILayoutSlide.getShapes](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibaseslide/) 回傳的集合。

以下範例會變更第一張投影片所使用版面的標題與副標題提示文字：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ILayoutSlide layoutSlide = presentation.getSlides().get_Item(0).getLayoutSlide();

    for (IShape shape : layoutSlide.getShapes()) {
        if (!(shape instanceof IAutoShape)) {
            continue;
        }

        IAutoShape autoShape = (IAutoShape) shape;
        IPlaceholder placeholder = autoShape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();

        if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) {
            autoShape.getTextFrame().setText("Enter a concise slide title");
        } else if (placeholderType == PlaceholderType.Subtitle) {
            autoShape.getTextFrame().setText("Enter a subtitle or reporting period");
        }
    }

    presentation.save("custom-placeholder-prompts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

提示文字不是普通投影片內容。它僅供在 PowerPoint 等編輯應用程式中用於空佔位符。當使用者或程式提供實際內容後，提示文字即不再顯示。變更提示文字也不會取代使用該版面的投影片上現有的文字。

## **更新圖片佔位符**

需要處理的情況有兩種：

- 如果圖片佔位符已填入且以 [IPictureFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipictureframe/) 表示，請透過 [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipicturefillformat/) 和 [ISlidesPicture.setImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islidespicture/) 取代圖片。
- 如果仍是空佔位符，請使用 [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishapecollection/) 在佔位符座標新增圖片框，並移除空佔位符。

以下範例同時支援兩種情況，並儲存簡報：

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation("picture-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape picturePlaceholder = null;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() == PlaceholderType.Picture) {
            picturePlaceholder = shape;
            break;
        }
    }

    if (picturePlaceholder == null) {
        throw new IllegalStateException("The first slide does not contain a picture placeholder.");
    }

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("replacement.png")) {
        image = presentation.getImages().addImage(imageStream);
    }

    if (picturePlaceholder instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) picturePlaceholder;
        pictureFrame.getPictureFormat().getPicture().setImage(image);
    } else {
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, picturePlaceholder.getX(), picturePlaceholder.getY(), picturePlaceholder.getWidth(), picturePlaceholder.getHeight(), image);
        slide.getShapes().remove(picturePlaceholder);
    }

    presentation.save("picture-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

對空佔位符所建立的取代物會是本機圖片框，而非新佔位符，因為 [IShape.getPlaceholder](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/) 未提供設定子。它會保留保留的位置，但不再繼承佔位符特有的行為。如果必須保留佔位符關係，請先在 PowerPoint 中預先建立並填入佔位符，然後再使用 Aspose.Slides 更新產生的 [IPictureFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipictureframe/)。

有關影像透明度、裁切及其他圖片特定效果，請參閱 [Manage Picture Frames](/slides/zh-hant/androidjava/picture-frame/)。這些操作屬於圖片框或圖片填充，而非佔位符的中繼資料。

## **使用圖表與內容佔位符**

已填入的圖表佔位符可以以 [IChart](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichart/) 表示。以下範例同時以佔位符類型與執行時介面找出此類圖表，變更其標題，並儲存檔案：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart placeholderChart = null;

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) {
            continue;
        }

        IChart chart = (IChart) shape;
        IPlaceholder placeholder = chart.getPlaceholder();
        if (placeholder != null && placeholder.getType() == PlaceholderType.Chart) {
            placeholderChart = chart;
            break;
        }
    }

    if (placeholderChart == null) {
        throw new IllegalStateException("The first slide does not contain a populated chart placeholder.");
    }

    placeholderChart.setTitle(true);
    placeholderChart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    presentation.save("chart-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

一般內容佔位符通常具有 [PlaceholderType.Object](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/placeholdertype/)。在 PowerPoint 中，它充當多種內容類型的啟動器，包含圖表、表格、圖示、圖片與媒體。填入後，請檢查實際的形狀介面以了解其包含的內容。特化的版面也可能暴露 [PlaceholderType.Chart](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/placeholdertype/)、[PlaceholderType.Table](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/placeholdertype/)、[PlaceholderType.Picture](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/placeholdertype/)、[PlaceholderType.Media](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/placeholdertype/)、或 [PlaceholderType.Diagram](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/placeholdertype/)。

Aspose.Slides 不會僅透過變更 [IPlaceholder.getType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/placeholder/) 就將空的 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/) 佔位符轉換為 [IChart](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichart/)；類型無法透過介面變更。若要以程式方式填入空的圖表或內容區域，請在佔位符座標加入所需的物件，然後移除空佔位符。以下範例示範如何對圖表執行此操作：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("content-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape targetPlaceholder = null;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        if (placeholderType == PlaceholderType.Chart || placeholderType == PlaceholderType.Object) {
            targetPlaceholder = shape;
            break;
        }
    }

    if (targetPlaceholder == null) {
        throw new IllegalStateException("The first slide does not contain a chart or content placeholder.");
    }

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, targetPlaceholder.getX(), targetPlaceholder.getY(), targetPlaceholder.getWidth(), targetPlaceholder.getHeight());
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    slide.getShapes().remove(targetPlaceholder);
    presentation.save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

新增的圖表是一個普通的本機圖表。它佔據佔位符的區域，但不會繼承自版面佔位符。當需要取代其類別、系列或活頁簿資料時，請使用專門的 [chart management articles](/slides/zh-hant/androidjava/powerpoint-charts/)。

## **完整範例：更新文字或影像內容**

以下端對端範例會開啟範本、搜尋第一張投影片的標題或圖片佔位符、檢查佔位符與形狀類型、更新相應的內容，並儲存輸出。此範例刻意避免假設形狀索引或將所有佔位符強制轉型為相同介面。

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    boolean updated = false;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();

        if ((placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) && shape instanceof IAutoShape) {
            IAutoShape titleShape = (IAutoShape) shape;
            titleShape.getTextFrame().setText("Quarterly Business Review");
            updated = true;
            break;
        }

        if (placeholderType == PlaceholderType.Picture) {
            IPPImage image;
            try (FileInputStream imageStream = new FileInputStream("replacement.png")) {
                image = presentation.getImages().addImage(imageStream);
            }

            if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                pictureFrame.getPictureFormat().getPicture().setImage(image);
            } else {
                slide.getShapes().addPictureFrame(ShapeType.Rectangle, shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), image);
                slide.getShapes().remove(shape);
            }

            updated = true;
            break;
        }
    }

    if (!updated) {
        throw new IllegalStateException("No supported title or picture placeholder was found on the first slide.");
    }

    presentation.save("placeholder-content-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常見問題**

**什麼是基礎佔位符？**

基礎佔位符是指版面或母片上對應的形狀，其他佔位符會從它繼承。使用 [IShape.getBasePlaceholder](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/) 取得它。普通本機形狀會回傳 `null`，因為它不屬於佔位符階層。

**我可以透過編輯版面佔位符來變更所有投影片的標題嗎？**

雖然可以透過版面變更繼承的格式或提示文字，但現有的標題內容儲存在普通投影片上。若要在整個簡報中取代實際的標題文字，必須遍歷投影片並更新每個標題佔位符。

**如何管理日期、投影片編號、頁眉與頁腳佔位符？**

請在適當的投影片、版面、母片、備註或講義範圍使用頁眉與頁腳管理員。完整範例請參閱 [Manage Presentation Header and Footer](/slides/zh-hant/androidjava/presentation-header-and-footer/)。