---
title: 以 .NET 取得與更新簡報資訊
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
- 檢視 PPTX
- 檢視 PPT
- 檢視 ODP
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 .NET 探索 PowerPoint 與 OpenDocument 簡報中的投影片、結構與中繼資料，以獲得更快速的洞見與更智慧的內容稽核。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中檢視簡報資訊。它解釋了如何在不載入完整檔案的情況下判斷簡報的目前格式、讀取其文件屬性，以及在需要時更新這些屬性。

範例基於 [PresentationInfo](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentationinfo/) 與 [DocumentProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/documentproperties/) API，展示了處理簡報中繼資料的典型操作。

## **檢查簡報格式**

在處理簡報之前，您可能想先了解目前簡報的格式（PPT、PPTX、ODP 等）為何。

您可以在不載入簡報的情況下檢查其格式。請參考以下 C# 程式碼：

```c#
using Aspose.Slides;

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
using Aspose.Slides;

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// 省略
```

您可能想查看 [DocumentProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/documentproperties/#properties) 類別下的屬性。

## **更新簡報屬性**

Aspose.Slides 提供了 [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentationinfo/methods/updatedocumentproperties) 方法，可讓您修改簡報屬性。

假設我們有一個 PowerPoint 簡報，其文件屬性如下所示。

![PowerPoint 簡報的原始文件屬性](input_properties.png)

以下程式碼示範如何編輯部分簡報屬性：

```c#
using Aspose.Slides;

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

## **實用連結**

若需要取得有關簡報及其安全屬性的更多資訊，您可能會發現以下連結很有幫助：

- [密碼保護簡報](/slides/zh-hant/net/password-protected-presentation/)
- [寫入保護簡報](/slides/zh-hant/net/write-protected-presentation/)

## **常見問題**

**我該如何檢查字型是否已嵌入以及是哪一些字型？**

在簡報層級尋找 [embedded-font information](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsmanager/getembeddedfonts/)，然後將這些項目與 [fonts actually used across content](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsmanager/getfonts/) 的字型集合比較，以辨識哪些字型對渲染是關鍵的。

**我該如何快速判斷檔案是否有隱藏投影片以及有多少張？**

遍歷 [slide collection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/slidecollection/)，檢查每張投影片的 [visibility flag](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/slide/hidden/)。

**我能偵測是否使用自訂投影片大小與方向，且它們是否與預設值不同嗎？**

可以。將目前的 [slide size](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/slidesize/) 與方向與標準預設值作比較；這有助於預測列印和匯出的行為。

**有沒有快速方法查看圖表是否參照外部資料來源？**

可以。遍歷所有 [charts](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/chart/)，檢查它們的 [data source](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/chartdata/datasourcetype/)，並註明資料是內部還是基於連結，包括任何損壞的連結。

**我該如何評估可能拖慢渲染或 PDF 匯出的「大型」投影片？**

對每張投影片，統計物件數量並檢查是否有大型影像、透明度、陰影、動畫與多媒體；再給予大致的複雜度分數，以標示潛在的效能瓶頸。