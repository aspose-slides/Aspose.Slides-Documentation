---
title: "Aspose.Slides for .NET 15.6.0 的公共 API 與向後不相容變更"
linktitle: "Aspose.Slides for .NET 15.6.0"
type: docs
weight: 170
url: /zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/
keywords:
- 遷移
- 舊版程式碼
- 現代程式碼
- 舊版方法
- 現代方法
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "檢視 Aspose.Slides for .NET 的公共 API 更新與破壞性變更，順利遷移您的 PowerPoint PPT、PPTX 與 ODP 簡報解決方案。"
---
{{% alert color="primary" %}} 

此頁面列出所有[已新增](/slides/zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/)或[已移除](/slides/zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/)的類別、方法、屬性等，及其他隨 Aspose.Slides for .NET 15.6.0 API 引入的變更。

{{% /alert %}} 
## **公共 API 變更**
#### **DataLabel 建構式簽章已變更**
DataLabel 建構式簽章已變更：
先前: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
現在: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint)。

#### **成員 IDocumentProperties.Count、.GetPropertyName(int index)、.Remove(string name)、.Contains(string name) 已被標記為過時，並已引入取代方案。**
屬性 IDocumentProperties.Count 以及方法 IDocumentProperties.GetPropertyName(int index)、.Remove(string name)、.Contains(string name) 已標記為過時。已新增屬性 IDocumentProperties.CountOfCustomProperties 以及方法 IDocumentProperties.GetCustomPropertyName(int index)、.RemoveCustomProperty(string name)、.ContainsCustomProperty(string name) 以取代之。

#### **已新增方法 INotesSlideManager.RemoveNotesSlide()**
已新增方法 INotesSlideManager.RemoveNotesSlide()，用於移除某投影片的備註投影片。

#### **已在 IComment 中新增 Remove 方法**
已新增 IComment.Remove 方法，用於從集合中移除評論。

#### **已在 ICommentAuthor 中新增 Remove 方法**
已新增 ICommentAuthor.Remove 方法，用於從集合中移除評論的作者。

#### **已在 IDocumentProperties 中新增 ClearCustomProperties 與 ClearBuiltInProperties 方法**
已新增 IDocumentProperties.ClearCustomProperties 方法，用於移除所有自訂文件屬性。
已新增 IDocumentProperties.ClearBuiltInProperties 方法，用於移除並將所有內建文件屬性（Company、Subject、Author 等）設定為預設值。

#### **已在 ICommentAuthorCollection 中新增 RemoveAt、Remove 與 Clear 方法**
已新增 ICommentAuthorCollection.RemoveAt 方法，用於依指定索引移除作者。
已新增 ICommentAuthorCollection.Remove 方法，用於從集合中移除指定的作者。
已新增 ICommentAuthorCollection.Clear 方法，用於從集合中移除所有項目。

#### **已在 IDocumentProperties 中新增 AppVersion 屬性**
已新增 IDocumentProperties.AppVersion 屬性，用於取得內建文件屬性，該屬性表示 Microsoft 在開發期間使用的內部版本號。

#### **已在 IShape 與 Shape 中新增 BlackWhiteMode 屬性**
已在 IShape 與 Shape 中新增 BlackWhiteMode 屬性。

此屬性指定形狀在黑白顯示模式下的呈現方式。

|**值**|**說明**|
| :- | :- |
|Color|以正常色彩呈現|
|Automatic|以自動色彩呈現|
|Gray|以灰色呈現|
|LightGray|以淡灰色呈現|
|InverseGray|以反向灰色呈現|
|GrayWhite|以灰白色呈現|
|BlackGray|以黑灰色呈現|
|BlackWhite|以黑白色呈現|
|Black|只以黑色呈現|
|White|以白色呈現|
|Hidden|不呈現|
|NotDefined|表示屬性未設定|

#### **已新增 ISlide.NotesSlideManager 屬性。 ISlide.NotesSlide 屬性與 ISlide.AddNotesSlide() 方法已被標記為過時。**
ISlide.NotesSlide 與 ISlide.AddNotesSlide() 成員已被標記為過時。請改用新屬性 ISlide.NotesSlideManager。

``` csharp

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.AddNotesSlide(); - 已過時

// notes = slide.NotesSlide; - 已過時

notes = slide.NotesSlideManager.NotesSlide;

notes = slide.NotesSlideManager.AddNotesSlide();

slide.NotesSlideManager.RemoveNotesSlide();

```