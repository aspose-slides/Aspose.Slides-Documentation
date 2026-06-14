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
description: "使用 Aspose.Slides for Android 透過 Java 快速將 PowerPoint 簡報轉換為高品質 PNG 圖像，確保結果精確且自動化。"
---
## **概述**

本文說明如何使用 Aspose.Slides 將 PowerPoint 簡報轉換為 PNG 圖像。它展示了如何載入 PPT、PPTX 和 ODP 等格式的簡報檔案，將投影片渲染為圖像，並以 PNG 格式儲存結果。

本文亦示範了如何透過設定比例值或指定目標寬度與高度來自訂產生的 PNG 圖像。

## **將 PowerPoint 轉換為 PNG**

請依照以下步驟：

1. 實例化 Presentation 類別。
2. 從 ISlide 介面的 Presentation.getSlides() 集合中取得投影片物件。
3. 使用 ISlide.getImage() 方法取得每張投影片的縮圖。
4. 使用 IImage.save(String formatName, int imageFormat) 方法將投影片縮圖儲存為 PNG 格式。

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

如果您想取得特定比例的 PNG 檔案，可以設定 `desiredX` 與 `desiredY` 的數值，這會決定產生縮圖的尺寸。

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

如果您想取得特定大小的 PNG 檔案，可以為 `ImageSize` 傳入您偏好的 `width` 和 `height` 參數。

以下程式碼示範在指定圖像大小的情況下將 PowerPoint 轉換為 PNG：

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

**如何僅匯出特定形狀（例如圖表或圖片）而非整張投影片？**

Aspose.Slides 支援[產生單一形狀的縮圖](/slides/zh-hant/androidjava/create-shape-thumbnails/)，您可以將形狀渲染為 PNG 圖像。

**伺服器上是否支援平行轉換？**

是的，但請勿在多執行緒之間共用單一 presentation 實例。每個執行緒或程序應使用獨立的實例。使用[不要共享](/slides/zh-hant/androidjava/multithreading/)的方式。

**匯出 PNG 時試用版的限制是什麼？**

評估模式會在輸出圖像上加入浮水印，並在授權啟用前施加[其他限制](/slides/zh-hant/androidjava/licensing/)。