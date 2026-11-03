---
title: 管理 Android 上的簡報占位符
linktitle: 管理占位符
type: docs
weight: 10
url: /zh-hant/androidjava/manage-placeholder/
keywords:
- 占位符
- 文字占位符
- 影像占位符
- 圖表占位符
- 內容占位符
- 提示文字
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Android（透過 Java）檢查與編輯文字、圖片、圖表與內容占位符，並理解占位符的繼承關係。"
---
## **概述**

占位符是一種形狀，用於在簡報範本中為特定類型的內容保留位置。常見的範例有標題、內文、圖片、圖表以及通用內容占位符。與普通形狀不同，占位符可以從版面投影片或母片繼承其位置、大小、格式和其他設定。

Aspose.Slides 透過 [IShape.getPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) 方法公開占位符資訊。該方法會傳回 [IPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) 物件，若為普通形狀則傳回 `null`。使用 [IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) 可判斷占位符預計容納何種內容。

即使已知占位符類型，形狀介面仍然重要：

- 空的文字、圖片、圖表或內容占位符通常以 [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) 表示。
- 已填充的圖片占位符可以以 [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/) 表示。
- 已填充的圖表占位符可以以 [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/) 表示。
- 內容占位符可以含有多種內容。請同時檢查 [IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) 與執行時的形狀介面，而不要假設每個占位符都是 [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/)。

{{% alert color="warning" title="警告" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) 描述占位符的角色；它不保證形狀的執行時類型。存取文字、圖片、圖表、表格或媒體特定成員前，務必先進行類型檢查。
{{% /alert %}}

## **了解占位符繼承**

占位符形成層級結構：

1. 母片投影片定義可重複使用的樣式，並在某些情況下定義母片層級的占位符。
2. 版面投影片定義供一個或多個普通投影片使用的佈局，且可從母片繼承。
3. 普通投影片包含該投影片的占位符，並可從其版面繼承。

呼叫 [IShape.getBasePlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) 可向上移動一層層級。投影片占位符通常傳回其版面占位符；版面占位符則可傳回其母片占位符。若形狀沒有基底占位符，則方法傳回 `null`。

以下範例列出第一張投影片上的占位符，並報告其基底占位符：

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

編輯普通投影片上的占位符會為該投影片建立或變更本機覆寫。編輯相關的版面或母片則可能影響所有仍繼承該設定的投影片。普通本機形狀沒有基底占位符，僅因佔據相同座標並不會開始繼承。

## **移除占位符狀態**

在調整範本時，使用 [IShape.removePlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#removePlaceholder--) 可將既有物件保留為普通形狀。其 [getPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getPlaceholder--) 方法會傳回 `null`，但形狀仍保留在投影片的集合中。相較之下，[IShapeCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) 會將形狀從該集合中刪除。

以下範例需要一個至少包含一張投影片且第一張投影片上有非空文字占位符的 `template.pptx`。使用從版面或母片繼承格式的占位符，以觀察移除關聯的效果。範例會檢查相同形狀仍然存在，再於該普通形狀上再次呼叫此方法，最後儲存結果。

{{% alert color="warning" title="警告" %}}
移除占位符狀態不會自動保留繼承的外觀設定。下面的範例刻意保持這些設定不變，因而輸出可能看起來不同。若位置與大小完全繼承，呼叫後可能會得到座標與尺寸皆為零的形狀，雖然仍在集合中，但會變得不可見。
{{% /alert %}}

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    boolean found = false;

    for (int index = 0; index < slide.getShapes().size(); index++) {
        IShape candidate = slide.getShapes().get_Item(index);
        if (!(candidate instanceof IAutoShape)) {
            continue;
        }

        IAutoShape shape = (IAutoShape) candidate;
        ITextFrame textFrame = shape.getTextFrame();
        if (shape.getPlaceholder() == null ||
            textFrame == null ||
            textFrame.getText() == null ||
            textFrame.getText().isEmpty()) {
            continue;
        }

        int shapeCount = slide.getShapes().size();
        shape.removePlaceholder();

        System.out.println("Placeholder removed: " + (shape.getPlaceholder() == null));
        System.out.println("Same shape retained: " + (slide.getShapes().get_Item(index) == shape));
        System.out.println("Shape count unchanged: " + (slide.getShapes().size() == shapeCount));

        // 在普通形狀上呼叫此方法不會有任何影響。
        shape.removePlaceholder();
        found = true;
        break;
    }

    if (found) {
        presentation.save("placeholder-status-removed.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("No nonempty text placeholder was found on the first slide.");
    }
} finally {
    presentation.dispose();
}
```

對於匹配的占位符，三項檢查皆會印出 `true`。文字仍保留，但移除占位符關係後，繼承的定位、大小、旋轉、字型、段落對齊、文字框邊距、垂直錨點、填色與線條設定都可能改變。例如，繼承的標題格式可能退回普通文字格式。請參閱 [投影片佈局](/slides/zh-hant/androidjava/slide-layout/) 以取得更多版面資訊。

為了保持預期的外觀，請在呼叫前取得解析後的位置、大小與旋轉，並將所需的有效格式值複製到單獨的變數。可透過 [IPortionFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/#getEffective--)、[IParagraphFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getEffective--)、[ITextFrameFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getEffective--)、[IFillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getEffective--) 以及 [ILineFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getEffective--) 取得這些值。不要僅依賴有效格式物件，因為在關係移除後其文字格式值可能會變更。之後請明確將捕獲的值套用至普通形狀，包括字型族、大小、樣式、顏色、段落設定、文字框設定、填色與線條等。

繼承的形狀幾何亦可能需要透過 [IGeometryShape.setShapeType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setShapeType-int-) 明確指定。對於矩形文字占位符，意味著要設定 [ShapeType.Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapetype/#Rectangle)；僅還原填色與線條可能無法恢復可見的矩形。具有額外效果或更複雜格式的範本亦需同樣處理這些設定。

## **變更占位符內的文字**

標題、置中標題、副標題、內文與文字占位符通常支援文字。使用前請先確認是否為 [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/)，再呼叫其 [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) 方法。

以下範例會更新第一張投影片上的第一個標題占位符，並儲存結果：

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

此模式避免將圖片、圖表、表格或媒體占位符強制轉型為 [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/)。同時也以用途辨識占位符，而非依賴易碎的形狀索引。

## **在版面設定提示文字**

提示文字是設計時在空的占位符中顯示的說明，例如 *Click to add title*。請在版面占位符上設定自訂提示文字，而不是透過普通投影片的形狀集合去取得。可透過 [ISlide.getLayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) 取得版面，並遍歷 [ILayoutSlide.getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/) 回傳的集合。

以下範例會變更第一張投影片使用之版面的標題與副標題提示文字：

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

提示文字不是普通投影片內容。它僅供在 PowerPoint 等編輯應用程式的空占位符使用。使用者或程式提供真實內容後，提示文字即不再顯示。變更提示文字也不會取代已使用該版面的投影片上現有的文字。

## **更新圖片占位符**

有兩種情況需要處理：

- 若圖片占位符已被填充且以 [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/) 表示，請透過 [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) 與 [ISlidesPicture.setImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/) 取代圖像。
- 若仍是空的占位符，請使用 [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/) 在占位符座標加入圖片框，並移除空的占位符。

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

對於空的占位符所建立的取代物是一個本機圖片框，而非新占位符，因為 [IShape.getPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) 並未提供設定子。它保留了保留的位置，但不再繼承占位符專屬的行為。如需保留占位符關係，請先在 PowerPoint 中建立並填充占位符，然後再以 Aspose.Slides 更新產生的 [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/)。

欲了解影像透明度、裁切及其他圖片特定效果，請參閱 [管理圖片框架](/slides/zh-hant/androidjava/picture-frame/)。這些操作屬於圖片框或圖片填充，而非占位符的中繼資料。

## **處理圖表與內容占位符**

已填充的圖表占位符可以以 [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/) 表示。以下範例同時依據占位符類型與執行時介面找到此圖表，變更其標題，並儲存檔案：

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

一般內容占位符通常具有 [PlaceholderType.Object](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/)。在 PowerPoint 中，它會作為多種內容類型的啟動器，包括圖表、表格、圖示、圖片與媒體。填充後，請檢查實際的形狀介面以了解其內容。特定版面也可能暴露 [PlaceholderType.Chart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/)、[PlaceholderType.Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/)、[PlaceholderType.Picture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/)、[PlaceholderType.Media](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/) 或 [PlaceholderType.Diagram](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/)。

Aspose.Slides 不會僅透過變更 [IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) 就將空的 [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) 占位符轉換為 [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/)；類型無法透過介面變更。若要以程式方式填充空的圖表或內容區域，請在占位符座標加入所需物件，然後移除空的占位符。以下範例示範如何為圖表執行此操作：

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

新增的圖表是一個普通本機圖表。它佔據占位符的區域，但不會繼承版面占位符的設定。若需替換其類別、系列或工作簿資料，請參考專門的 [圖表管理文章](/slides/zh-hant/androidjava/powerpoint-charts/)。

## **完整範例：更新文字或影像內容**

以下端對端範例會開啟範本，於第一張投影片搜尋標題或圖片占位符，檢查占位符與形狀類型，更新相應內容，最後儲存輸出。此範例刻意避免假設形狀索引或將每個占位符皆強制轉型為相同介面。

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

## **FAQ**

**什麼是基底占位符？**

基底占位符是指版面或母片上對應的形狀，其他占位符會從它繼承設定。使用 [IShape.getBasePlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) 取得它。普通本機形狀會傳回 `null`，因為它不屬於占位符層級。

**我可以透過編輯版面占位符來變更所有投影片的標題嗎？**

您可以透過版面變更繼承的格式或提示文字，但現有的標題內容儲存在普通投影片上。若要在整份簡報中取代實際的標題文字，必須遍歷投影片並更新每個標題占位符。

**如何管理日期、投影片編號、頁首與頁尾占位符？**

請在相應的投影片、版面、母片、備註或講義範圍使用頁首與頁尾管理器。參閱 [管理簡報頁首與頁尾](/slides/zh-hant/androidjava/presentation-header-and-footer/) 取得完整範例。