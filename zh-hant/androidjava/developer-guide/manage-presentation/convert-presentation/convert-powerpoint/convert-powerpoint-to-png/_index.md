---
title: 在 Android 上將 PowerPoint 投影片轉換為 PNG
linktitle: PowerPoint 轉 PNG
type: docs
weight: 30
url: /zh-hant/androidjava/convert-powerpoint-to-png/
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
- Android
- Java
- Aspose.Slides
description: 使用 Aspose.Slides for Android via Java 快速將 PowerPoint 簡報轉換為高品質 PNG 圖像，確保精確且自動化的結果。
---
## **概覽**

本文說明如何使用 Aspose.Slides for Android via Java 將簡報投影片轉換為 PNG 圖像。您可以載入 PPT、PPTX 與 ODP 等格式的簡報，將每張投影片渲染，並將其另存為單獨的 PNG 圖像。

以下範例示範以預設比例渲染、提升比例、以像素指定輸出尺寸，以及選擇漸層渲染樣式。

## **將 PowerPoint 轉換為 PNG**

使用 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 類別載入簡報，並透過 [Presentation.getSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) 集合存取其投影片。範例使用不帶參數的 [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage--) 來渲染每張投影片以建立縮圖。然後使用 [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) 搭配 [ImageFormat.Png](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imageformat/#Png) 將每張渲染後的投影片儲存為 PNG 圖像。

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
不帶參數的 [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage--) 多載以 0.2 的比例渲染。例如，尺寸為 720 × 540 點的投影片會產生 144 × 108 像素的縮圖。若要控制輸出尺寸，請使用帶比例因子或明確圖像大小的多載，如下所示。
{{% /alert %}}

## **使用自訂尺寸將 PowerPoint 轉換為 PNG**

將水平與垂直比例因子傳遞給 [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-float-float-) 以控制渲染尺寸。在此範例中，兩個因子皆為 2，故尺寸為 720 × 540 點的投影片會產生 1440 × 1080 像素的圖像。相同的比例因子會保留投影片的長寬比。每張圖像皆使用 [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) 以 PNG 格式儲存。

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

## **使用自訂大小將 PowerPoint 轉換為 PNG**

若要以像素指定輸出尺寸，請傳遞尺寸給 [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) 來取代比例因子。此範例將每張投影片渲染為 960 × 720 像素，並使用 [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) 儲存結果。請選擇與投影片長寬比相符的尺寸，以避免圖像被拉伸。

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Size imageSize = new Size(960, 720);

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

假設投影片包含漸層填色，但匯出的 PNG 中的過度顏色看起來較淡或與 PowerPoint 中的顯示不同。您可以使用由 [RenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/renderingoptions/) 繼承的 [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setGradientStyle-int-) 方法來選擇漸層的渲染方式。

下載 [gradient-styles.pptx](gradient-styles.pptx) 並將其放置於應用程式的工作目錄。其第一張投影片包含兩個線性漸層：上方由青色到橙色，下方由藍色到黃色。每個漸層有兩個停止點，分別在 0% 與 100%。

以下範例載入此簡報，並使用 [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) 以兩種模式渲染相同的第一張投影片。

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

以下影像顯示同一張投影片的輸出結果，每張影像皆包含兩個漸層：

| 預設 | PowerPointUI |
| --- | --- |
| ![使用預設渲染的青色至橙色與藍色至黃色漸層](gradient-Default.png) | ![使用 PowerPointUI 渲染的相同漸層](gradient-PowerPointUI.png) |

在此範例中，`Default` 產生較淡的中間色，而 `PowerPointUI` 產生較暗的中間色。差異取決於漸層的顏色與停止點。

若標準 Aspose.Slides 輸出符合需求，請選擇 `Default`。若您優先考慮與 PowerPoint 的外觀相匹配，請嘗試 `PowerPointUI`。將兩種輸出與您預期的結果比較；兩者皆未必是普遍最佳的選擇。

## **常見問題**

**如何匯出特定圖形（例如圖表或圖片）而非整張投影片？**

Aspose.Slides 支援[為個別圖形產生縮圖](/slides/zh-hant/androidjava/create-shape-thumbnails/)，讓您能將圖形渲染為 PNG 圖像。

**伺服器上是否支援平行轉換？**

是。每個執行緒或行程使用獨立的簡報實例；[不要在執行緒之間共享同一實例](/slides/zh-hant/androidjava/multithreading/)。

**匯出 PNG 時的評估版限制是什麼？**

評估模式會在輸出圖像上加上浮水印，並套用[其他限制](/slides/zh-hant/androidjava/licensing/)，直至套用授權為止。