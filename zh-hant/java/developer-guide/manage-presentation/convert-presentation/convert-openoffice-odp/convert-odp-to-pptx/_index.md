---
title: 將 ODP 轉換為 PPTX（Java）
linktitle: ODP 轉 PPTX
type: docs
weight: 10
url: /zh-hant/java/convert-odp-to-pptx/
keywords:
- 轉換 OpenDocument
- 轉換簡報
- 轉換投影片
- 轉換 ODP
- OpenDocument 轉 PPTX
- ODP 轉 PPTX
- 將 ODP 儲存為 PPTX
- 匯出 ODP 為 PPTX
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 將 ODP 轉換為 PPTX。乾淨的 Java 程式碼範例、批次技巧以及高品質結果——無需 PowerPoint。"
---
## **概觀**

這篇文章說明如何使用 Aspose.Slides 將 ODP 簡報轉換為 PPTX 格式。

## **將 ODP 轉換為 PPTX/PPT 簡報**
Aspose.Slides for Java 提供了 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別，代表簡報檔案。現在可以透過在建立物件時使用 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation#Presentation-java.lang.String-) 建構子直接存取 ODP。以下範例示範如何將 ODP 簡報轉換為 PPTX 簡報。

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
您可以造訪[**Aspose.Slides 轉換**](https://products.aspose.app/slides/zh-hant/conversion/) 網路應用程式，此應用程式是以**Aspose.Slides API**建置的。該應用程式示範了如何使用 Aspose.Slides API 實作 ODP 轉換為 PPTX。

## **常見問題**

**是否需要安裝 Microsoft PowerPoint 或 LibreOffice 才能將 ODP 轉換為 PPTX？**

不需要。Aspose.Slides 可單獨運作，無需第三方應用程式即可讀寫 ODP/PPTX。

**在轉換過程中，母片投影片、版面配置和佈景主題會被保留嗎？**

會。此函式庫使用完整的簡報物件模型，保留包括母片投影片和版面配置在內的結構，確保設計在轉換後仍保持正確。

**我可以轉換受密碼保護的 ODP 檔案嗎？**

可以。Aspose.Slides 支援偵測保護、在提供密碼時開啟並處理[受保護的簡報](/slides/zh-hant/java/password-protected-presentation/)（包含 ODP），同時也支援設定加密與存取文件屬性。

**Aspose.Slides 適合用於雲端或基於 REST 的轉換服務嗎？**

適合。您可以在自有後端使用本機函式庫，或使用[Aspose.Slides Cloud](https://products.aspose.cloud/slides/zh-hant/family/)（REST API）；兩種方式皆支援 ODP → PPTX 轉換。