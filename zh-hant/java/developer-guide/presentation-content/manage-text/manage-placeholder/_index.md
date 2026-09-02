---
title: 管理 Java 中的簡報占位符
linktitle: 管理占位符
type: docs
weight: 10
url: /zh-hant/java/manage-placeholder/
keywords:
- 占位符
- 文字占位符
- 圖片占位符
- 圖表占位符
- 內容占位符
- 提示文字
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Java 檢查和編輯文字、圖片、圖表及內容占位符，並了解占位符的繼承關係。"
---
## **概觀**

占位符是一種形狀，用於在簡報範本中為特定類型的內容保留位置。常見的例子包括標題、正文、圖片、圖表以及一般用途的內容占位符。與普通形狀不同，占位符可以從版面投影片或母版投影片繼承其位置、大小、格式以及其他設定。

Aspose.Slides 透過 [IShape.getPlaceholder](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/) 方法公開占位符資訊。此方法會回傳 [IPlaceholder](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/placeholder/) 物件，若是一般形狀則回傳 `null`。使用 [IPlaceholder.getType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/placeholder/) 可判斷占位符預期容納的內容類型。

在得知占位符類型後，形狀介面仍然很重要：

- 空的文字、圖片、圖表或內容占位符通常以 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/) 表示。
- 已填入圖片的占位符可以用 [IPictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipictureframe/) 表示。
- 已填入圖表的占位符可以用 [IChart](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ichart/) 表示。
- 內容占位符可以包含多種內容。請同時檢查 [IPlaceholder.getType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/placeholder/) 與執行時的形狀介面，而不要假設每個占位符都是 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/)。

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/placeholder/) 描述了占位符的角色；它並不保證形狀的執行時類型。存取文字、圖片、圖表、表格或媒體相關成員之前，請務必先進行類型檢查。
{{% /alert %}}

## **了解占位符繼承**

占位符形成層級結構：

1. 母片投影片定義可重複使用的樣式，且在某些情況下會定義母片層級的占位符。
2. 版面投影片定義一或多張普通投影片所使用的排版，且可以從母片繼承。
3. 普通投影片包含該投影片的占位符，並且可以從其版面繼承。

呼叫 [IShape.getBasePlaceholder](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/) 可往上移動一層層級。投影片占位符通常會回傳其版面占位符；版面占位符則可回傳其母片占位符。若形狀沒有基礎占位符，則此方法會回傳 `null`。

以下範例列出第一張投影片上的占位符，並回報它們的基礎占位符：

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

在普通投影片上編輯占位符會為該投影片建立或變更本地覆寫。編輯相關的版面或母片則會影響所有仍繼承該設定的投影片。普通本地形狀沒有基礎占位符，僅因占據相同座標並不會開始繼承。

## **在占位符中變更文字**

標題、置中標題、副標題、正文與文字占位符通常支援文字。使用其 [getTextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/) 方法前，請先確認是 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/)。

此範例會更新第一張投影片上的第一個標題占位符，並儲存結果：

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

此模式避免將圖片、圖表、表格或媒體占位符轉型為 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/)。同時亦以用途識別占位符，而非依賴不穩定的形狀索引。

## **在版面設定提示文字**

提示文字是設計時顯示於空白占位符的說明，例如 *Click to add title*。請在版面占位符上設定自訂提示文字，而不是試圖透過普通投影片的形狀集合取得。可透過 [ISlide.getLayoutSlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islide/) 取得版面，並遍歷 [ILayoutSlide.getShapes](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibaseslide/) 回傳的集合。

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

提示文字並非普通投影片內容。它是供 PowerPoint 等編輯應用程式中的空白占位符使用。當使用者或程式提供真實內容後，提示文字便不再顯示。變更提示文字亦不會取代使用該版面的投影片上已存在的文字。

## **更新圖片占位符**

需要處理兩種情況：

- 若圖片占位符已被填入，且以 [IPictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipictureframe/) 表示，請透過 [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipicturefillformat/) 與 [ISlidesPicture.setImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islidespicture/) 置換圖像。
- 若仍是空的占位符，請使用 [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishapecollection/) 在占位符座標處新增圖片框，並刪除空的占位符。

以下範例同時支援這兩種情況，並儲存簡報：

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

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

    Path imagePath = Paths.get("replacement.png");
    byte[] imageBytes = Files.readAllBytes(imagePath);
    IPPImage image = presentation.getImages().addImage(imageBytes);

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

對於空的占位符所建立的取代物是本地的圖片框，而非新的占位符，因為 [IShape.getPlaceholder](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/) 沒有提供設定子。它保留了預留位置，但不再繼承占位符專屬行為。若必須保留占位符關係，請先在 PowerPoint 中準備並填入占位符，之後再使用 Aspose.Slides 更新產生的 [IPictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipictureframe/)。

有關圖像透明度、裁剪及其他圖片專屬效果，請參閱 [Manage Picture Frames](/slides/zh-hant/java/picture-frame/)。這些操作屬於圖片框或圖片填充，而非占位符的中繼資料。

## **使用圖表和內容占位符**

已填入的圖表占位符可以以 [IChart](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ichart/) 表示。此範例同時依據占位符類型與執行時介面尋找此圖表，變更其標題，並儲存檔案：

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

一般的內容占位符通常具有 [PlaceholderType.Object](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/placeholdertype/)。在 PowerPoint 中，它充當多種內容類型（如圖表、表格、圖示、圖片與媒體）的啟動器。填入後，請檢查實際的形狀介面以了解其內容。專屬版面也可能顯示 [PlaceholderType.Chart](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/placeholdertype/)、[PlaceholderType.Table](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/placeholdertype/)、[PlaceholderType.Picture](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/placeholdertype/)、[PlaceholderType.Media](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/placeholdertype/)、或 [PlaceholderType.Diagram](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/placeholdertype/)。

Aspose.Slides 並不會僅透過變更 [IPlaceholder.getType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/placeholder/) 就將空的 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/) 占位符轉換為 [IChart](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ichart/)；此類型無法透過介面變更。若要程式化填入空的圖表或內容區域，請在占位符座標處加入所需物件，然後移除空的占位符。以下範例示範如何對圖表執行此操作：

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

新增的圖表是一個普通的本地圖表。它佔據占位符的區域，但不會從版面占位符繼承。當需要取代其類別、序列或活頁簿資料時，請使用專屬的 [chart management articles](/slides/zh-hant/java/powerpoint-charts/)。

## **完整範例：更新文字或影像內容**

以下端對端範例會開啟範本、在第一張投影片尋找標題或圖片占位符、檢查占位符與形狀類型、更新相應的內容，並儲存輸出。此範例刻意避免假設形狀索引或將所有占位符轉型為相同介面。

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

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
            Path imagePath = Paths.get("replacement.png");
            byte[] imageBytes = Files.readAllBytes(imagePath);
            IPPImage image = presentation.getImages().addImage(imageBytes);

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

**什麼是基礎占位符？**

基礎占位符是版面或母片上對應的形狀，其他占位符會從它繼承。使用 [IShape.getBasePlaceholder](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/) 可取得它。普通的本地形狀會回傳 `null`，因為它不屬於占位符層級。

**我可以透過編輯版面占位符來變更所有投影片的標題嗎？**

您可以透過版面變更繼承的格式或提示文字，但現有的標題內容儲存在普通投影片上。若要在整份簡報中取代實際的標題文字，須遍歷投影片並更新每個標題占位符。

**我要如何管理日期、投影片編號、頁首與頁尾占位符？**

請在適當的投影片、版面、母片、備註頁或講義範圍內使用頁首與頁尾管理器。完整範例請參閱 [Manage Presentation Header and Footer](/slides/zh-hant/java/presentation-header-and-footer/)。