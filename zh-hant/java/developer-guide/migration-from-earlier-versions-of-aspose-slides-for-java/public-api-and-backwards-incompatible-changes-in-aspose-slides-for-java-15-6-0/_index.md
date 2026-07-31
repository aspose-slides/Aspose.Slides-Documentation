---
title: 公開 API 與向後相容性不兼容變更（Aspose.Slides for Java 15.6.0）
linktitle: Aspose.Slides for Java 15.6.0
type: docs
weight: 140
url: /zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
aliases:
  - /java/aspose-slides-for-java-15-6-0-release-notes/
keywords:
- 遷移
- 傳統程式碼
- 現代程式碼
- 傳統方法
- 現代方法
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "檢視 Aspose.Slides for Java 的公開 API 更新與破壞性變更，協助您順利遷移 PowerPoint PPT、PPTX 與 ODP 簡報解決方案。"
---
{{% alert color="primary" %}}

此頁面列出所有[已新增](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) 類別、方法、屬性等，任何新的限制以及其他[變更](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) ，這些皆隨 Aspose.Slides for Java 15.6.0 API 引入。

{{% /alert %}}

## **公開 API 變更**
#### **com.aspose.slides.DataLabel 建構子簽名已變更**
建構子的簽名已從 DataLabel(com.aspose.slides.IChartSeries) 變更為 DataLabel(com.aspose.slides.IChartDataPoint)。

#### **成員 com.aspose.slides.IDocumentProperties.getCount()、.getPropertyName(int index) 、.remove(String name) 、.contains(String name) 已標記為已淘汰；已引入替代方案**
IDocumentProperties.getCount()、IDocumentProperties.getPropertyName(int index) 、.remove(string name) 、.contains(string name) 等方法已標記為已淘汰。已引入 IDocumentProperties.countOfCustomProperties()、IDocumentProperties.getCustomPropertyName(int index) 、.removeCustomProperty(String name) 、.containsCustomProperty(string name) 等取代方法。

#### **已新增方法 com.aspose.slides.INotesSlideManager.removeNotesSlide()**
已新增 com.aspose.slides.INotesSlideManager.RemoveNotesSlide() 方法，用於移除某投影片的備註投影片。

#### **已新增方法 com.aspose.slides.ISlide.getNotesSlideManager()。ISlide.getNotesSlide() 與 ISlide.addNotesSlide() 方法已標記為已淘汰**
ISlide.getNotesSlide()、ISlide.addNotesSlide() 方法已標記為已淘汰。請改用新的 ISlide.getNotesSlideManager() 方法。

``` java

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.addNotesSlide(); - 已棄用

// notes = slide.getNotesSlide(); - 已棄用

notes = slide.getNotesSlideManager().getNotesSlide();

notes = slide.getNotesSlideManager().addNotesSlide();

slide.getNotesSlideManager().removeNotesSlide();

```
#### **已在 com.aspose.slides.IDocumentProperties 中加入方法 getAppVersion()**
已在 com.aspose.slides.IDocumentProperties 加入 getAppVersion() 方法，以取得內建文件屬性，該屬性代表 Microsoft PowerPoint 使用的內部版本號。

#### **已在 com.aspose.slides.IComment 中加入方法 remove()**
已在 com.aspose.slides.IComment 加入 remove() 方法，用於從集合中移除評論。

#### **已在 com.aspose.slides.ICommentAuthor 中加入方法 remove()**
已在 ICommentAuthor 加入 Remove 方法，用於從集合中移除評論作者。

#### **已在 com.aspose.slides.IDocumentProperties 中加入方法 clearCustomProperties() 與 clearBuiltInProperties()**
已在 com.aspose.slides.IDocumentProperties 加入 clearCustomProperties() 方法，用於移除所有自訂文件屬性。
已在 com.aspose.slides.IDocumentProperties 加入 clearBuiltInProperties() 方法，用於移除並將所有內建文件屬性（Company、Subject、Author 等）設定為預設值。

#### **已在 com.aspose.slides.IShape 中加入方法 getBlackWhiteMode()、setBlackWhiteMode(byte)**
已在 com.aspose.slides.IShape 中加入 getBlackWhiteMode()、setBlackWhiteMode(byte) 方法。
這些方法指定形狀在黑白顯示模式下的呈現方式。可能的取值在 com.aspose.slides.BlackWhiteMode 類別中定義。

|**值**|**含義**|
| :- | :- |
|Color|以正常著色返回|
|Automatic|以自動著色返回|
|Gray|以灰色返回|
|LightGray|以淡灰色返回|
|InverseGray|以反向灰色返回|
|GrayWhite|以灰白色返回|
|BlackGray|以黑灰色返回|
|BlackWhite|以黑白色返回|
|Black|僅以黑色返回|
|White|以白色返回|
|Hidden|物件不會被呈現|

#### **已在 com.aspose.slides.ICommentAuthorCollection 中加入方法 removeAt(int)、remove(ICommentAuthor) 與 clear()**
已在 ICommentAuthorCollection 加入 removeAt(int) 方法，用於依指定索引移除作者。已加入 remove(ICommentAuthor) 方法，用於從集合中移除指定作者。已加入 clear() 方法，用於清除集合中所有項目。