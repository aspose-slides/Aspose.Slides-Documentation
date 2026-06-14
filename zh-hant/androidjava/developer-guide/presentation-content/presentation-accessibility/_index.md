---
title: 在 Android 上管理簡報無障礙
linktitle: 簡報無障礙
type: docs
weight: 30
url: /zh-hant/androidjava/presentation-accessibility/
keywords:
- 簡報無障礙
- 標記為裝飾性
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "了解 Aspose.Slides for Android（透過 Java）如何協助自動化 PPT、PPTX 與 ODP 檔案的簡報無障礙檢查——提升螢幕閱讀器體驗並加強合規性。"
---
## **概覽**

簡報的無障礙設計可確保使用輔助技術（例如螢幕閱讀器、點字顯示器或僅鍵盤操作）的人士，能與視覺、使用滑鼠的觀眾同樣順利理解與瀏覽投影片。良好實踐聚焦於清晰的閱讀順序、對資訊性視覺的有意義替代文字、足夠的色彩對比、易讀的排版、具描述性的連結文字，且避免僅透過顏色或位置傳遞意義。從一開始即規劃無障礙，能產生更乾淨的結構、更一致的視覺效果，以及讓每位觀眾都不需使用變通方式即可取得內容。

## **標記為裝飾性**

標記為裝飾性用於純粹裝飾性的視覺元素，使螢幕閱讀器略過它們，減少雜訊並將焦點保留在有意義的內容上。將其套用於背景、裝飾圖案與間距元件——絕不可用於傳遞資訊的圖表、圖示或影像。Aspose.Slides 針對此旗標提供偵測與驗證功能，支援自動化的無障礙檢查與清理。

![Mark as Decorative](mark_as_decorative.png)

以下程式碼範例顯示如何判斷形狀是否已標記為裝飾性。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Is shape decorative: " + shape.isDecorative());
} finally {
    presentation.dispose();
}
```