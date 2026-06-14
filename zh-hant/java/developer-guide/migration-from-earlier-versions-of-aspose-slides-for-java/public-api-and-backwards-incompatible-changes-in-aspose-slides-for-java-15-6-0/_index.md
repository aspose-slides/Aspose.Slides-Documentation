---
title: Aspose.Slides for Java 15.6.0 的公共 API 以及向後不相容的變更
linktitle: Aspose.Slides for Java 15.6.0
type: docs
weight: 140
url: /zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
keywords:
- 遷移
- 舊版程式碼
- 現代程式碼
- 舊版方法
- 現代方法
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "檢視 Aspose.Slides for Java 的公共 API 更新與重大變更，以順利遷移您的 PowerPoint PPT、PPTX 與 ODP 簡報解決方案。"
---
{{% alert color="primary" %}} 
此頁面列出所有[新增](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) 類別、方法、屬性等，以及任何新限制和其他[變更](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/)，這些皆隨 Aspose.Slides for Java 15.6.0 API 引入。
{{% /alert %}} 
## **公共 API 變更**
#### **com.aspose.slides.DataLabel 建構函式簽名已變更**
建構函式的簽名已從 DataLabel(com.aspose.slides.IChartSeries) 變更為 DataLabel(com.aspose.slides.IChartDataPoint)。
#### **成員 com.aspose.slides.IDocumentProperties.getCount()、.getPropertyName(int index) 、.remove(String name) 、.contains(String name) 已標記為已棄用；已引入替代方案**
IDocumentProperties.getCount()、IDocumentProperties.getPropertyName(int index) 、.remove(string name) 、.contains(string name) 方法已標記為已棄用。已引入 IDocumentProperties.countOfCustomProperties()、IDocumentProperties.getCustomPropertyName(int index) 、.removeCustomProperty(String name) 、.containsCustomProperty(string name) 方法作為替代。
#### **已新增方法 com.aspose.slides.INotesSlideManager.removeNotesSlide()**
已新增 com.aspose.slides.INotesSlideManager.RemoveNotesSlide() 方法，用於移除某個投影片的註解投影片。
#### **已新增方法 com.aspose.slides.ISlide.getNotesSlideManager()。Methods ISlide.getNotesSlide() 與 ISlide.addNotesSlide() 已標記為已棄用**
ISlide.getNotesSlide() 與 ISlide.addNotesSlide() 方法已標記為已棄用。請改用新的 ISlide.getNotesSlideManager() 方法。

``` java

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.addNotesSlide(); - 已棄用

// notes = slide.getNotesSlide(); - 已棄用

notes = slide.getNotesSlideManager().getNotesSlide();

notes = slide.getNotesSlideManager().addNotesSlide();

slide.getNotesSlideManager().removeNotesSlide();

```
#### **已在 com.aspose.slides.IDocumentProperties 中新增方法 getAppVersion()**
已新增 com.aspose.slides.IDocumentProperties.getAppVersion() 方法，以取得內建文件屬性，該屬性代表 Microsoft PowerPoint 使用的內部版本號。
#### **已在 com.aspose.slides.IComment 中新增方法 remove()**
已新增 com.aspose.slides.IComment.remove() 方法，用於從集合中移除評論。
#### **已在 com.aspose.slides.ICommentAuthor 中新增方法 remove()**
已新增 ICommentAuthor.Remove 方法，用於從集合中移除評論作者。
#### **已在 com.aspose.slides.IDocumentProperties 中新增方法 clearCustomProperties() 與 clearBuiltInProperties()**
已新增 com.aspose.slides.IDocumentProperties.clearCustomProperties() 方法，用於移除所有自訂文件屬性。  
已新增 com.aspose.slides.IDocumentProperties.clearBuiltInProperties() 方法，用於移除並將所有內建文件屬性（公司、主題、作者等）設定為預設值。
#### **已在 com.aspose.slides.IShape 中新增方法 getBlackWhiteMode()、setBlackWhiteMode(byte)**
已在 com.aspose.slides.IShape 中新增 getBlackWhiteMode()、setBlackWhiteMode(byte) 方法。  
這些方法指定形狀在黑白顯示模式下的呈現方式。可能的值在 com.aspose.slides.BlackWhiteMode 類別中定義。

|**值**|**說明**|
| :- | :- |
|Color|返回正常顏色的呈現|
|Automatic|返回自動著色的呈現|
|Gray|返回灰色的呈現|
|LightGray|返回淡灰色的呈現|
|InverseGray|返回反向灰色的呈現|
|GrayWhite|返回灰白色的呈現|
|BlackGray|返回黑灰色的呈現|
|BlackWhite|返回黑白色的呈現|
|Black|僅返回黑色的呈現|
|White|返回白色的呈現|
|Hidden|物件不會被呈現|
#### **已在 com.aspose.slides.ICommentAuthorCollection 中新增方法 removeAt(int)、remove(ICommentAuthor) 與 clear()**
已新增 ICommentAuthorCollection.removeAt(int) 方法，以依指定索引移除作者。已新增 ICommentAuthorCollection.remove(ICommentAuthor) 方法，以從集合中移除指定作者。已新增 ICommentAuthorCollection.clear() 方法，以移除集合中的所有項目。