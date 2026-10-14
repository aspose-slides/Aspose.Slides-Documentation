---
title: 在 Java 中將 PowerPoint 投影片轉換為 PNG
linktitle: PowerPoint 轉 PNG
type: docs
weight: 30
url: /zh-hant/java/convert-powerpoint-to-png/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 轉換投影片
- 轉換 PPT
- 轉換 PPTX
- PowerPoint 轉 PNG
- 簡報轉 PNG
- 投影片轉 PNG
- PPT 轉 PNG
- PPTX 轉 PNG
- 將 PPT 儲存為 PNG
- 將 PPTX 儲存為 PNG
- 匯出 PPT 為 PNG
- 匯出 PPTX 為 PNG
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 快速將 PowerPoint 簡報轉換為高品質 PNG 圖像，確保精確且自動化的結果。"
---
## **概觀**

本篇文章說明如何使用 Aspose.Slides for Java 將簡報投影片轉換為 PNG 圖像。您可以載入 PPT、PPTX、ODP 等格式的簡報，將每張投影片呈現，並將其儲存為單獨的 PNG 圖像。

以下範例示範預設比例下的渲染、提高比例、以像素指定輸出尺寸，以及選擇漸層渲染樣式。

## **將 PowerPoint 轉換為 PNG**

使用 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 類別載入簡報，並透過 [Presentation.getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) 集合取得投影片。範例使用不帶參數的 [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage--) 來渲染每張投影片，以產生縮圖。接著呼叫 [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) 並傳入 [ImageFormat.Png](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/#Png) 將每張渲染後的投影片儲存為 PNG 圖像。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage();
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
未帶參數的 [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage--) 重載會以 0.2 的比例渲染。例如，尺寸為 720 × 540 點的投影片會產生 144 × 108 像素的縮圖。若要控制輸出尺寸，請使用帶比例因子或明確圖像大小的重載，如下所示。
{{% /alert %}}

## **將 PowerPoint 轉換為 PNG（自訂尺寸）**

將水平與垂直比例因子傳遞給 [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-float-float-) 以控制渲染尺寸。在此範例中，兩個因子皆為 2，因此尺寸為 720 × 540 點的投影片會產生 1440 × 1080 像素的圖像。相等的比例因子可保留投影片的長寬比。每張圖像皆使用 [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) 以 PNG 格式儲存。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    float scaleX = 2f;
    float scaleY = scaleX;

    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(scaleX, scaleY);
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **將 PowerPoint 轉換為 PNG（自訂大小）**

若要以像素指定輸出尺寸，請傳遞尺寸給 [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) 而非比例因子。此範例將每張投影片渲染為 960 × 720 像素，並使用 [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) 儲存結果。請選擇符合投影片長寬比的尺寸，以避免圖像被拉伸。

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Dimension imageSize = new Dimension(960, 720);

    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(imageSize);
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **選擇漸層渲染樣式**

假設投影片包含漸層填色，但匯出的 PNG 中的過渡顏色看起來較淡或與 PowerPoint 中的顯示不同。您可以使用由 [RenderingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/renderingoptions/) 繼承的 [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setGradientStyle-int-) 方法來選擇漸層的渲染方式。

下載 [gradient-styles.pptx](gradient-styles.pptx) 並將其放置於應用程式的工作目錄中。其第一張投影片包含兩個線性漸層：上方由青色至橙色，下方由藍色至黃色。每個漸層在 0% 與 100% 位置各有兩個色標。

以下範例載入此簡報，並使用 [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) 以兩種模式渲染相同的第一張投影片。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("gradient-styles.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int[] gradientStyles = { GradientStyle.Default, GradientStyle.PowerPointUI };
    for (int style : gradientStyles) {
        RenderingOptions options = new RenderingOptions();
        options.setGradientStyle(style);

        String styleName = style == GradientStyle.Default ? "Default" : "PowerPointUI";
        IImage image = slide.getImage(options, 1f, 1f);
        try {
            image.save("gradient-" + styleName + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

The images below show the output from the same slide, with both gradients in each image:

| Default | PowerPointUI |
| --- | --- |
| ![以預設方式渲染的青色至橙色與藍色至黃色漸層](gradient-Default.png) | ![相同的漸層以 PowerPointUI 方式渲染](gradient-PowerPointUI.png) |

在此範例中，`Default` 產生較淡的中間顏色，而 `PowerPointUI` 產生較深的中間顏色。差異取決於漸層中的顏色與色標。

當標準的 Aspose.Slides 輸出符合需求時，請選擇 `Default`。若您優先考慮與 PowerPoint 中的外觀一致，請嘗試 `PowerPointUI`。將兩種輸出與預期結果比較；兩種模式皆無絕對優劣。

## **常見問題**

**如何匯出特定形狀（例如圖表或圖片），而非整張投影片？**

Aspose.Slides 支援 [為單一形狀產生縮圖](/slides/zh-hant/java/create-shape-thumbnails/)，讓您能將形狀渲染為 PNG 圖像。

**伺服器上是否支援平行轉換？**

是。每個執行緒或程序使用獨立的簡報實例；[不要在執行緒之間共享同一實例](/slides/zh-hant/java/multithreading/)。

**在匯出 PNG 時，評估模式有哪些限制？**

評估模式會在輸出圖像上加上浮水印，並套用[其他限制](/slides/zh-hant/java/licensing/)，直到套用授權為止。