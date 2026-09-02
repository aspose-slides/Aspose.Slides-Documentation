---
title: 在 Java 中檢索與更新簡報資訊
linktitle: 簡報資訊
type: docs
weight: 30
url: /zh-hant/java/examine-presentation/
keywords:
- 簡報格式
- 簡報屬性
- 文件屬性
- 取得屬性
- 讀取屬性
- 變更屬性
- 修改屬性
- 更新屬性
- 檢查 PPTX
- 檢查 PPT
- 檢查 ODP
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "使用 Java 探索 PowerPoint 與 OpenDocument 簡報中的投影片、架構與中繼資料，以獲得更快速的洞見與更智慧的內容稽核。"
---
## **概覽**

本文說明如何在 Aspose.Slides 中檢查投影片檔案資訊。它解釋了如何在不載入完整檔案的情況下判斷投影片的目前格式、讀取其文件屬性，並在需要時更新這些屬性。

這些範例基於 [PresentationInfo](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentationinfo/) 與 [DocumentProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/documentproperties/) API，展示了處理投影片中繼資料的典型操作。

## **檢查投影片格式**

在處理投影片之前，您可能想先了解該投影片目前是以何種格式（PPT、PPTX、ODP 等）儲存。

您可以在不載入投影片的情況下檢查其格式。請參考以下 Java 程式碼：

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **取得投影片屬性**

以下 Java 程式碼示範如何取得投影片屬性（投影片的相關資訊）：

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// …
```

您可能想查看 [DocumentProperties 類別下的屬性](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/documentproperties/#DocumentProperties--)。

## **更新投影片屬性**

Aspose.Slides 提供了 [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) 方法，可讓您修改投影片屬性。

假設我們有一個 PowerPoint 投影片，其文件屬性如下所示。

![PowerPoint 投影片的原始文件屬性](input_properties.png)

以下程式碼範例示範如何編輯部分投影片屬性：

```java
import com.aspose.slides.*;
import java.util.Date;

String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

變更文件屬性的結果如下所示。

![PowerPoint 投影片的變更後文件屬性](output_properties.png)

## **有用的連結**

若需取得有關投影片及其安全屬性的更多資訊，以下連結可能對您有幫助：

- [保護投影片密碼](/slides/zh-hant/java/password-protected-presentation/)
- [保護投影片寫入](/slides/zh-hant/java/write-protected-presentation/)

## **常見問題**

**如何檢查字型是否已嵌入以及哪些字型已嵌入？**

在投影片層級查詢 [embedded-font 資訊](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--)，然後將這些條目與 [實際在內容中使用的字型集合](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fontsmanager/#getFonts--) 進行比對，即可判斷哪些字型對於呈現是關鍵的。

**如何快速判斷檔案是否包含隱藏投影片以及有多少張？**

遍歷 [投影片集合](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slidecollection/)，檢查每張投影片的 [可見性旗標](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slide/#getHidden--) 即可。

**我能偵測是否使用自訂投影片尺寸與方向，且是否與預設不同嗎？**

可以。將目前的 [投影片尺寸](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#getSlideSize--) 與方向與標準預設值進行比對；這有助於預測列印與匯出的行為。

**有沒有快速方法檢查圖表是否引用外部資料來源？**

可以。遍歷所有 [圖表](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/chart/)，檢查其 [資料來源](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/chartdata/#getDataSourceType--)，並註明資料是內部還是連結型式，亦包括任何斷開的連結。

**如何評估可能導致渲染或 PDF 匯出緩慢的「沉重」投影片？**

對每張投影片，統計物件數量並留意大型影像、透明度、陰影、動畫與多媒體等；依此賦予大致的複雜度分數，以標示可能的效能瓶頸。