---
title: Aspose.Slides for Java 15.6.0 の公開 API と後方互換性のない変更
type: docs
weight: 140
url: /androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for Java 15.6.0 API で追加されたすべての [クラス](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/)、メソッド、プロパティ、新たに導入された制限およびその他の [変更](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) を一覧表示します。

{{% /alert %}} 
## **公開 API の変更**
#### **com.aspose.slides.DataLabel のコンストラクタシグネチャが変更されました**
コンストラクタのシグネチャは、DataLabel(com.aspose.slides.IChartSeries) から DataLabel(com.aspose.slides.IChartDataPoint) に変更されました。
#### **メンバー com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index), .remove(String name), .contains(String name) は非推奨としてマークされ、代替が導入されました**
メソッド IDocumentProperties.getCount(), IDocumentProperties.getPropertyName(int index), .remove(String name), .contains(String name) は非推奨としてマークされました。代わりに、メソッド IDocumentProperties.countOfCustomProperties(), IDocumentProperties.getCustomPropertyName(int index), .removeCustomProperty(String name), .containsCustomProperty(String name) が導入されました。
#### **メソッド com.aspose.slides.INotesSlideManager.removeNotesSlide() が追加されました**
メソッド com.aspose.slides.INotesSlideManager.RemoveNotesSlide() が、特定のスライドのノートスライドを削除するために追加されました。
#### **メソッド com.aspose.slides.ISlide.getNotesSlideManager() が追加されました。メソッド ISlide.getNotesSlide() と ISlide.addNotesSlide() は非推奨としてマークされました**
ISlide.getNotesSlide()、ISlide.addNotesSlide() メソッドは非推奨としてマークされました。代わりに新しいメソッド ISlide.getNotesSlideManager() を使用してください。

```java

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.addNotesSlide(); - 非推奨

// notes = slide.getNotesSlide(); - 非推奨

notes = slide.getNotesSlideManager().getNotesSlide();

notes = slide.getNotesSlideManager().addNotesSlide();

slide.getNotesSlideManager().removeNotesSlide();

```
#### **メソッド getAppVersion() が com.aspose.slides.IDocumentProperties に追加されました**
メソッド com.aspose.slides.IDocumentProperties.getAppVersion() が、Microsoft PowerPoint によって使用される内部バージョン番号を表すビルトイン文書プロパティを取得するために追加されました。
#### **メソッド remove() が com.aspose.slides.IComment に追加されました**
メソッド com.aspose.slides.IComment.remove() が、コレクションからコメントを削除するために追加されました。
#### **メソッド remove() が com.aspose.slides.ICommentAuthor に追加されました**
メソッド ICommentAuthor.Remove が、コレクションからコメントの著者を削除するために追加されました。
#### **メソッド clearCustomProperties() と clearBuiltInProperties() が com.aspose.slides.IDocumentProperties に追加されました**
メソッド com.aspose.slides.IDocumentProperties.clearCustomProperties() が、すべてのカスタム文書プロパティを削除するために追加されました。
メソッド com.aspose.slides.IDocumentProperties.clearBuiltInProperties() が、すべてのビルトイン文書プロパティ（会社、件名、著者など）のデフォルト値を削除および設定するために追加されました。
#### **メソッド getBlackWhiteMode() と setBlackWhiteMode(byte) が com.aspose.slides.IShape に追加されました**
メソッド getBlackWhiteMode() と setBlackWhiteMode(byte) が com.aspose.slides.IShape に追加されました。
これらのメソッドは、形状が白黒表示モードでどのようにレンダリングされるかを指定します。可能な値は、com.aspose.slides.BlackWhiteMode クラスに指定されています。

|**値** |**意味** |
| :- | :- |
|Color |通常の色付けで返される |
|Automatic |自動色付けで返される |
|Gray |灰色の色付けで返される |
|LightGray |薄い灰色の色付けで返される |
|InverseGray |逆の灰色の色付けで返される |
|GrayWhite |灰色と白の色付けで返される |
|BlackGray |黒と灰色の色付けで返される |
|BlackWhite |黒と白の色付けで返される |
|Black |黒の色付けのみで返される |
|White |白の色付けで返される |
|Hidden |オブジェクトはレンダリングされない |
#### **メソッド removeAt(int)、remove(ICommentAuthor) および clear() が com.aspose.slides.ICommentAuthorCollection に追加されました**
メソッド ICommentAuthorCollection.removeAt(int) が指定したインデックスによって著者を削除するために追加されました。メソッド ICommentAuthorCollection.remove(ICommentAuthor) が、指定された著者をコレクションから削除するために追加されました。メソッド ICommentAuthorCollection.clear() が、コレクションからすべてのアイテムを削除するために追加されました。