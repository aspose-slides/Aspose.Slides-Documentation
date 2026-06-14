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
## **概述**

本文說明如何使用 Aspose.Slides 將 PowerPoint 簡報轉換為 PNG 圖像。它展示了如何載入 PPT、PPTX 與 ODP 等格式的簡報檔案、將投影片渲染為圖像，並將結果以 PNG 格式儲存。

本文還示範了如何透過設定比例值或指定所需的寬度與高度，來自訂產生的 PNG 圖像。

## **將 PowerPoint 轉換為 PNG**

按照以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例。
2. 從 [Presentation.getSlides()](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation#getSlides--) 集合中取得 [ISlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISlide) 介面下的投影片物件。
3. 使用 [ISlide.getImage()](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISlide) 方法取得每張投影片的縮圖。
4. 使用 [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) 方法將投影片縮圖儲存為 PNG 格式。

以下 Java 程式碼示範如何將 PowerPoint 簡報轉換為 PNG：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage();
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **使用自訂尺寸將 PowerPoint 轉換為 PNG**

如果您希望取得特定比例的 PNG 檔案，可以設定 `desiredX` 與 `desiredY` 的值，這些值會決定產生之縮圖的尺寸。

以下 Java 程式碼示範上述操作：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    float scaleX = 2f;
    float scaleY = 2f;
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage(scaleX, scaleY);
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **使用自訂大小將 PowerPoint 轉換為 PNG**

如果您希望取得特定大小的 PNG 檔案，可以為 `ImageSize` 傳入您偏好的 `width` 與 `height` 參數。

以下程式碼示範在指定圖像大小的情況下，如何將 PowerPoint 轉換為 PNG：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Dimension size = new Dimension(960, 720);
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage(size);
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問題**

**我如何只匯出特定的圖形（例如圖表或圖片）而不是整張投影片？**

Aspose.Slides 支援[為單一圖形產生縮圖](/slides/zh-hant/java/create-shape-thumbnails/)；您可以將圖形渲染為 PNG 圖像。

**伺服器上是否支援平行轉換？**

可以，但請[不要共用](/slides/zh-hant/java/multithreading/) 同一個簡報執行個體於多執行緒之間。請為每個執行緒或程序使用獨立的執行個體。

**匯出 PNG 時，試用版有哪些限制？**

評估模式會在輸出圖像上加上浮水印，並在套用授權前套用[其他限制](/slides/zh-hant/java/licensing/)。