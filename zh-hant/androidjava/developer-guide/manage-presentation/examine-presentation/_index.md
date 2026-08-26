---
title: 在 Android 上檢索與更新簡報資訊
linktitle: 簡報資訊
type: docs
weight: 30
url: /zh-hant/androidjava/examine-presentation/
keywords:
- 簡報格式
- 簡報屬性
- 文件屬性
- 取得屬性
- 讀取屬性
- 更改屬性
- 修改屬性
- 更新屬性
- 檢視 PPTX
- 檢視 PPT
- 檢視 ODP
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Java 探索 PowerPoint 與 OpenDocument 簡報中的投影片、結構與中繼資料，以獲得更快速的洞見與更智慧的內容稽核。"
---
## **概述**

本文說明如何在 Aspose.Slides 中檢查簡報資訊。它解釋了如何在不載入完整檔案的情況下判斷簡報的目前格式、讀取其文件屬性，並在需要時更新這些屬性。

範例基於 [PresentationInfo](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentationinfo/) 與 [DocumentProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/documentproperties/) API，展示了處理簡報中繼資料的常見操作。

## **檢查簡報格式**

在處理簡報之前，您可能想了解目前簡報的格式（PPT、PPTX、ODP 等）。

您可以在不載入簡報的情況下檢查其格式。請參考以下 Java 程式碼：

```java
import com.aspose.slides.*;

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
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// 省略
```

您也可以參閱 [DocumentProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/documentproperties/#DocumentProperties--) 類別下的屬性。

## **更新簡報屬性**

Aspose.Slides 提供了 [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) 方法，可用於變更簡報屬性。

假設我們有一個 PowerPoint 簡報，其文件屬性如下所示。

![PowerPoint 簡報的原始文件屬性](input_properties.png)

以下程式碼示範如何編輯部份簡報屬性：

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

![PowerPoint 簡報的變更後文件屬性](output_properties.png)

## **相關連結**

若要取得有關簡報及其安全屬性的更多資訊，以下連結可能對您有幫助：

- [Password-Protect Presentations](/slides/zh-hant/androidjava/password-protected-presentation/)
- [Write-Protect Presentations](/slides/zh-hant/androidjava/write-protected-presentation/)

## **常見問題**

**如何檢查是否已嵌入字型以及嵌入的是哪些字型？**

在簡報層級尋找 [embedded-font information](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--)，然後將其與 [實際使用的字型集合](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fontsmanager/#getFonts--) 進行比對，即可找出對渲染關鍵的字型。

**如何快速判斷檔案是否有隱藏投影片，以及隱藏了多少張？**

遍歷 [slide collection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slidecollection/)，檢查每張投影片的 [visibility flag](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slide/#getHidden--)。

**我能偵測是否使用了自訂投影片尺寸與方向，且是否與預設值不同嗎？**

可以。將目前的 [slide size](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#getSlideSize--) 與方向與標準預設值做比較；此資訊有助於預測列印與匯出的行為。

**是否有快速方式查看圖表是否參考外部資料來源？**

可以。遍歷所有 [charts](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/chart/)，檢查其 [data source](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/chartdata/#getDataSourceType--)，並判斷資料是內部還是連結方式，包括是否有斷開的連結。

**如何評估可能導致渲染或 PDF 匯出變慢的「重量」投影片？**

對每張投影片統計物件數量，留意大型影像、透明度、陰影、動畫與多媒體等；給予大致的複雜度分數，以標示可能的效能瓶頸。