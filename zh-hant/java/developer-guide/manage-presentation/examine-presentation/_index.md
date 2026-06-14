---
title: 使用 Java 取得與更新簡報資訊
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
description: "使用 Java 探索 PowerPoint 與 OpenDocument 簡報中的投影片、結構與中繼資料，以更快速的洞察與更智慧的內容稽核。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中檢查簡報資訊。它說明如何在不載入整個檔案的情況下判斷簡報的目前格式、讀取其文件屬性，並在需要時更新這些屬性。

範例是基於 [PresentationInfo](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentationinfo/) 與 [DocumentProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/documentproperties/) API，示範處理簡報中介資料的典型操作。

## **檢查簡報格式**

在處理簡報之前，您可能想先了解該簡報目前的格式（PPT、PPTX、ODP 等）。

您可以在不載入簡報的情況下檢查其格式。請參考以下 Java 程式碼：

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **取得簡報屬性**

以下 Java 程式碼示範如何取得簡報屬性（簡報的相關資訊）：

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// .. 
```

您可能想查看 [DocumentProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/documentproperties/#DocumentProperties--) 類別下的屬性。

## **更新簡報屬性**

Aspose.Slides 提供了 [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) 方法，可讓您變更簡報屬性。

假設我們有一個 PowerPoint 簡報，其文件屬性如下所示。

![PowerPoint 簡報的原始文件屬性](input_properties.png)

以下程式碼示範如何編輯部分簡報屬性：

```java
String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

變更文件屬性的結果如下所示。

![PowerPoint 簡報的變更後文件屬性](output_properties.png)

## **實用連結**

若需取得有關簡報及其安全屬性的更多資訊，以下連結可能對您有幫助：

- [檢查簡報是否已加密](https://docs.aspose.com/slides/zh-hant/java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [檢查簡報是否受寫入保護（唯讀）](https://docs.aspose.com/slides/zh-hant/java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [載入前檢查簡報是否受密碼保護](https://docs.aspose.com/slides/zh-hant/java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [確認用於保護簡報的密碼](https://docs.aspose.com/slides/zh-hant/java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **常見問題**

**如何檢查字型是否已嵌入以及哪些字型已嵌入？**

請在簡報層級查找 [embedded-font information](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--)，然後將這些條目與 [fonts actually used across content](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fontsmanager/#getFonts--) 的字型集合進行比較，以辨識哪些字型對於呈現至關重要。

**如何快速判斷檔案中是否有隱藏投影片以及有多少張？**

遍歷 [slide collection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slidecollection/)，檢查每張投影片的 [visibility flag](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slide/#getHidden--)。

**我可以偵測是否使用自訂投影片大小與方向，且是否與預設值不同嗎？**

可以。將目前的 [slide size](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#getSlideSize--) 與方向與標準預設值比較；此作法有助於預測列印與匯出的行為。

**是否有快速方式檢查圖表是否引用外部資料來源？**

可以。遍歷所有 [charts](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/chart/)，檢查其 [data source](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/chartdata/#getDataSourceType--)，並註明資料是內部還是基於連結，包括任何失效的連結。

**如何評估可能降低渲染或 PDF 匯出速度的「大型」投影片？**

對每張投影片，統計物件數量並查找大型圖片、透明度、陰影、動畫與多媒體；根據這些因素給予大致的複雜度分數，以標記潛在的效能熱點。