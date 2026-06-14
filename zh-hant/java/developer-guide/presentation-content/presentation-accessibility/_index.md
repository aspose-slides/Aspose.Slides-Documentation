---
title: 在 Java 中管理簡報無障礙性
linktitle: 簡報無障礙性
type: docs
weight: 30
url: /zh-hant/java/presentation-accessibility/
keywords:
- 簡報無障礙性
- 標記為裝飾
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "了解 Aspose.Slides for Java 如何協助自動執行 PPT、PPTX 與 ODP 檔案的簡報無障礙性檢查——提升螢幕朗讀器體驗並促進合規性。"
---
## **簡介**

簡報無障礙性確保使用輔助技術——例如螢幕朗讀器、點字顯示器或僅使用鍵盤導覽——的人員，能夠如同視覺正常、使用滑鼠的觀眾一般，理解並瀏覽您的投影片。良好做法著重於清晰的閱讀順序、對資訊性圖像提供具意義的替代文字、足夠的色彩對比、易讀的排版、具描述性的連結文字，且避免僅透過顏色或位置傳遞意義。從一開始即規劃無障礙，最終會得到更清晰的結構、更一致的視覺效果，以及能讓每位觀眾無需額外操作即可觀看的內容。

## **標記為裝飾**

「標記為裝飾」用於純粹裝飾性的視覺元素，使螢幕朗讀器跳過它們，降低雜訊並將焦點保留在有意義的內容上。將此標記套用於背景、花飾及間距物件——絕不可用於圖表、圖示或傳遞資訊的圖像。Aspose.Slides 會公開此旗標，以供偵測與驗證，實現自動化的無障礙檢查與清理。

![Mark as Decorative](mark_as_decorative.png)

以下程式碼範例顯示如何判斷形狀是否已標記為裝飾。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Is shape decorative: " + shape.isDecorative());
} finally {
    presentation.dispose();
}
```