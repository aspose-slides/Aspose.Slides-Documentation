---
title: 在 Android 上將 ODP 轉換為 PPTX
linktitle: ODP 轉換為 PPTX
type: docs
weight: 10
url: /zh-hant/androidjava/convert-odp-to-pptx/
keywords:
- 轉換 OpenDocument
- 轉換簡報
- 轉換投影片
- 轉換 ODP
- OpenDocument 轉換為 PPTX
- ODP 轉換為 PPTX
- 將 ODP 儲存為 PPTX
- 匯出 ODP 為 PPTX
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 將 ODP 轉換為 PPTX。提供乾淨的 Java 程式碼範例、批次技巧與高品質結果—無需 PowerPoint。"
---
## **概述**

本文說明如何使用 Aspose.Slides 將 ODP 簡報轉換為 PPTX 格式。

## **將 ODP 轉換為 PPTX/PPT 簡報**
Aspose.Slides for Android via Java 提供代表簡報檔案的 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別。現在，[Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別在建立物件時也可以透過 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation#Presentation-java.lang.String-) 建構函式存取 ODP。以下範例說明如何將 ODP 簡報轉換為 PPTX 簡報。

```java
// 開啟 ODP 檔案
Presentation pres = new Presentation("AccessOpenDoc.odp");
try {}
// 將 ODP 簡報儲存為 PPTX 格式
    pres.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **即時範例**
您可以造訪以 **Aspose.Slides API** 建置的 [**Aspose.Slides Conversion**](https://products.aspose.app/slides/zh-hant/conversion/) 網頁應用程式。此應用程式示範如何使用 Aspose.Slides API 實作 ODP 轉換為 PPTX。

## **常見問題**

**我需要安裝 Microsoft PowerPoint 或 LibreOffice 來將 ODP 轉換為 PPTX 嗎？**

不需要。Aspose.Slides 可獨立運作，無需第三方應用程式即可讀寫 ODP/PPTX。

**轉換過程中會保留母片、版面配置與佈景主題嗎？**

會。函式庫使用完整的簡報物件模型，保留結構，包括母片與版面配置，確保轉換後的設計仍保持正確。

**我可以轉換受密碼保護的 ODP 檔案嗎？**

可以。Aspose.Slides 支援偵測保護，並在提供密碼後開啟與處理[受保護的簡報](/slides/zh-hant/androidjava/password-protected-presentation/)（包括 ODP），同時可設定加密與存取文件屬性。

**Aspose.Slides 適合用於雲端或基於 REST 的轉換服務嗎？**

可以。您可以在自有後端使用本機函式庫，或使用 [Aspose.Slides Cloud](https://products.aspose.cloud/slides/zh-hant/family/)（REST API）；兩種方式皆支援 ODP→PPTX 轉換。