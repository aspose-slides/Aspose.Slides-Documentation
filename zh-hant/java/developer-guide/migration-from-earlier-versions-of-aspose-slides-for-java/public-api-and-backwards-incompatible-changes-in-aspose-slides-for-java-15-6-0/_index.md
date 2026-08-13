---
title: Aspose.Slides for Java 15.6.0 中的公共 API 與向後不相容變更
linktitle: Aspose.Slides for Java 15.6.0
type: docs
weight: 140
url: /zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
aliases:
  - /java/aspose-slides-for-java-15-6-0-release-notes/
keywords:
- 遷移
- 遺留程式碼
- 現代程式碼
- 遺留方法
- 現代方法
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "檢視 Aspose.Slides for Java 的公共 API 更新與破壞性變更，順利遷移您的 PowerPoint PPT、PPTX 與 ODP 簡報解決方案。"
---
{{% alert color="info" %}} 

此頁面列出所有在 Aspose.Slides for Java 15.6.0 API 中新增的 [added](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) 類別、方法、屬性等，以及任何新的限制和其他 [changes](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) 。

{{% /alert %}} 
## **Public API changes**
#### **com.aspose.slides.DataLabel constructor signature has been changed**
已將建構式簽章從 DataLabel(com.aspose.slides.IChartSeries) 更改為 DataLabel(com.aspose.slides.IChartDataPoint)。
#### **Members com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index)., .remove(String name), .contains(String name) have been marked as Deprecated; substitutions have been introduced instead**
IDocumentProperties.getCount()、IDocumentProperties.getPropertyName(int index)、、.remove(string name) 與 .contains(string name) 等方法已標記為 Deprecated。已改為使用 IDocumentProperties.countOfCustomProperties()、IDocumentProperties.getCustomPropertyName(int index) 、.removeCustomProperty(String name) 與 .containsCustomProperty(string name) 等新方法。
#### **Method com.aspose.slides.INotesSlideManager.removeNotesSlide() has been added**
已新增 Method com.aspose.slides.INotesSlideManager.RemoveNotesSlide() 以移除指定投影片的註解投影片。
#### **Method com.aspose.slides.ISlide.getNotesSlideManager() has been added. Methods ISlide.getNotesSlide() and ISlide.addNotesSlide() have been marked as Deprecated**
ISlide.getNotesSlide() 與 ISlide.addNotesSlide() 方法已標記為 Deprecated，請改用新方法 ISlide.getNotesSlideManager()。

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    INotesSlide notes;

    // notes = slide.addNotesSlide(); - 已棄用

    // notes = slide.getNotesSlide(); - 已棄用

    notes = slide.getNotesSlideManager().getNotesSlide();

    notes = slide.getNotesSlideManager().addNotesSlide();

    slide.getNotesSlideManager().removeNotesSlide();
} finally {
    if (pres != null) pres.dispose();
}
```
#### **Method getAppVersion() has been added to com.aspose.slides.IDocumentProperties**
已在 com.aspose.slides.IDocumentProperties 中新增 Method getAppVersion()，可取得內建文件屬性，其代表 Microsoft PowerPoint 使用的內部版本號。
#### **Method remove() has been added to com.aspose.slides.IComment**
已在 com.aspose.slides.IComment 中新增 Method remove()，用於從集合中移除註解。
#### **Method remove() has been added to com.aspose.slides.ICommentAuthor**
已在 com.aspose.slides.ICommentAuthor 中新增 Method Remove，以從集合中移除註解作者。
#### **Methods clearCustomProperties() and clearBuiltInProperties() have been added to com.aspose.slides.IDocumentProperties**
已在 com.aspose.slides.IDocumentProperties 中新增 Method clearCustomProperties()，可移除所有自訂文件屬性。  
已在 com.aspose.slides.IDocumentProperties 中新增 Method clearBuiltInProperties()，可移除並將所有內建文件屬性（Company、Subject、Author 等）重設為預設值。
#### **Methods getBlackWhiteMode(), setBlackWhiteMode(byte) have been added to com.aspose.slides.IShape**
已在 com.aspose.slides.IShape 中新增 Methods getBlackWhiteMode()、setBlackWhiteMode(byte)。這些方法指定形狀在黑白顯示模式下的渲染方式。可能的取值由 com.aspose.slides.BlackWhiteMode 類別定義。

|**值**|**說明**|
| :- | :- |
|Color |返回正常顏色 |
|Automatic |返回自動上色 |
|Gray |返回灰色 |
|LightGray |返回淡灰色 |
|InverseGray |返回相反灰色 |
|GrayWhite |返回灰白色 |
|BlackGray |返回黑灰色 |
|BlackWhite |返回黑白色 |
|Black |僅返回黑色 |
|White |返回白色 |
|Hidden |物件不進行渲染 |
#### **Methods removeAt(int), remove(ICommentAuthor) and clear() have been added to com.aspose.slides.ICommentAuthorCollection**
已在 com.aspose.slides.ICommentAuthorCollection 中新增 Method removeAt(int)，可依指定索引移除作者。  
已新增 Method remove(ICommentAuthor)，可從集合中移除指定作者。  
已新增 Method clear()，可清除集合中所有項目。