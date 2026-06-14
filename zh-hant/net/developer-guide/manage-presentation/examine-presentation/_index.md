---
title: 在 .NET 中檢索與更新簡報資訊
linktitle: 簡報資訊
type: docs
weight: 30
url: /zh-hant/net/examine-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "使用 .NET 探索 PowerPoint 與 OpenDocument 簡報中的投影片、結構與中繼資料，以獲得更快速的洞見與更智慧的內容稽核。"
---
## **概觀**

本文說明如何檢查 Aspose.Slides 中的簡報資訊。它解釋了如何在不載入完整檔案的情況下判斷簡報的目前格式、讀取其文件屬性，並在需要時更新這些屬性。

範例基於 [PresentationInfo](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentationinfo/) 與 [DocumentProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/documentproperties/) API，示範了處理簡報中繼資料的常見操作。

## **檢查簡報格式**

在處理簡報之前，您可能想了解目前簡報是以何種格式（PPT、PPTX、ODP 等）儲存。

您可以在不載入簡報的情況下檢查其格式。請參考以下 C# 程式碼：

```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP
```

## **取得簡報屬性**

以下 C# 程式碼示範如何取得簡報屬性（簡報的相關資訊）：

```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// 其它
```

您也可以查閱 [DocumentProperties 類別下的屬性](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/documentproperties/#properties)。

## **更新簡報屬性**

Aspose.Slides 提供 [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentationinfo/methods/updatedocumentproperties) 方法，讓您能變更簡報屬性。

假設我們有一個 PowerPoint 簡報，其文件屬性如下所示。

![PowerPoint 簡報的原始文件屬性](input_properties.png)

以下程式碼示範如何編輯部分簡報屬性：

```c#
string fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(fileName);

IDocumentProperties properties = info.ReadDocumentProperties();
properties.Title = "My title";
properties.LastSavedTime = DateTime.Now;

info.UpdateDocumentProperties(properties);
info.WriteBindedPresentation(fileName);
```

變更文件屬性的結果如下所示。

![PowerPoint 簡報的變更後文件屬性](output_properties.png)

## **有用的連結**

若需取得有關簡報及其安全屬性的更多資訊，以下連結可能會對您有幫助：

- [檢查簡報是否已加密](https://docs.aspose.com/slides/zh-hant/net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [檢查簡報是否受寫入保護（唯讀）](https://docs.aspose.com/slides/zh-hant/net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [在載入前檢查簡報是否受密碼保護](https://docs.aspose.com/slides/zh-hant/net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [確認用於保護簡報的密碼](https://docs.aspose.com/slides/zh-hant/net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **常見問題**

**如何檢查字型是否已嵌入以及是哪一些字型？**

請在簡報層級查找 [embedded-font 資訊](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsmanager/getembeddedfonts/)，再將其與 [實際使用的字型集合](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsmanager/getfonts/) 進行比對，以辨識哪些字型對於呈現是必要的。

**如何快速判斷檔案是否包含隱藏投影片以及有多少張？**

遍歷 [slide collection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/slidecollection/)，檢查每張投影片的 [visibility flag](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/slide/hidden/)。

**我可以偵測是否使用自訂投影片尺寸與方向，且其是否與預設值不同嗎？**

可以。比較目前的 [slide size](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/slidesize/) 與方向，與標準預設值做比對，這有助於預測列印與匯出的行為。

**有沒有快速的方法查看圖表是否引用外部資料來源？**

可以。遍歷所有 [charts](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/chart/)，檢查其 [data source](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/chartdata/datasourcetype/)，並註明資料是內部還是連結式的，包含任何失效的連結。

**如何評估可能導致渲染或 PDF 匯出緩慢的「重」投影片？**

對每張投影片統計物件數量，查找大型影像、透明度、陰影、動畫與多媒體，並給予粗略的複雜度分數，以標記潛在的效能熱點。