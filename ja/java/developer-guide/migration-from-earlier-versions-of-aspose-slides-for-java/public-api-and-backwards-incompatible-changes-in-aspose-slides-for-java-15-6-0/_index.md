---
title: Aspose.Slides for Java 15.6.0の公開APIと後方互換性のない変更
type: docs
weight: 140
url: /ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for Java 15.6.0 APIで追加されたすべての[class](/slides/ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/)クラス、メソッド、プロパティなど、新しい制限およびその他の[changes](/slides/ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/)をリストします。

{{% /alert %}} 
## **公開APIの変更**
#### **com.aspose.slides.DataLabelのコンストラクタのシグネチャが変更されました**
コンストラクタのシグネチャがDataLabel(com.aspose.slides.IChartSeries)からDataLabel(com.aspose.slides.IChartDataPoint)に変更されました。
#### **メンバーcom.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index), .remove(String name), .contains(String name)が非推奨としてマークされ、代替が導入されました**
メソッドIDocumentProperties.getCount(), IDocumentProperties.getPropertyName(int index), .remove(string name), .contains(string name)が非推奨としてマークされました。代わりにIDocumentProperties.countOfCustomProperties(), IDocumentProperties.getCustomPropertyName(int index), .removeCustomProperty(String name), .containsCustomProperty(string name)が導入されました。
#### **メソッドcom.aspose.slides.INotesSlideManager.removeNotesSlide()が追加されました**
特定のスライドのノートスライドを削除するためのメソッドcom.aspose.slides.INotesSlideManager.RemoveNotesSlide()が追加されました。
#### **メソッドcom.aspose.slides.ISlide.getNotesSlideManager()が追加されました。メソッドISlide.getNotesSlide()とISlide.addNotesSlide()が非推奨としてマークされました**
ISlide.getNotesSlide()、ISlide.addNotesSlide()メソッドが非推奨としてマークされました。新しいメソッドISlide.getNotesSlideManager()を代わりに使用してください。

``` java

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.addNotesSlide(); - 非推奨

// notes = slide.getNotesSlide(); - 非推奨

notes = slide.getNotesSlideManager().getNotesSlide();

notes = slide.getNotesSlideManager().addNotesSlide();

slide.getNotesSlideManager().removeNotesSlide();

```
#### **メソッドgetAppVersion()がcom.aspose.slides.IDocumentPropertiesに追加されました**
組み込みのドキュメントプロパティを取得するためのメソッドcom.aspose.slides.IDocumentProperties.getAppVersion()が追加されました。このプロパティは、Microsoft PowerPointによって使用される内部バージョン番号を表します。
#### **メソッドremove()がcom.aspose.slides.ICommentに追加されました**
コレクションからコメントを削除するためのメソッドcom.aspose.slides.IComment.remove()が追加されました。
#### **メソッドremove()がcom.aspose.slides.ICommentAuthorに追加されました**
コレクションからコメントの著者を削除するためのメソッドICommentAuthor.Removeが追加されました。
#### **メソッドclearCustomProperties()およびclearBuiltInProperties()がcom.aspose.slides.IDocumentPropertiesに追加されました**
すべてのカスタムドキュメントプロパティを削除するためのメソッドcom.aspose.slides.IDocumentProperties.clearCustomProperties()が追加されました。
すべての組み込みドキュメントプロパティ（会社、件名、著者など）を削除し、デフォルト値を設定するためのメソッドcom.aspose.slides.IDocumentProperties.clearBuiltInProperties()が追加されました。
#### **メソッドgetBlackWhiteMode()、setBlackWhiteMode(byte)がcom.aspose.slides.IShapeに追加されました**
メソッドgetBlackWhiteMode()、setBlackWhiteMode(byte)がcom.aspose.slides.IShapeに追加されました。
これらのメソッドは、シェイプが白黒表示モードでどのようにレンダリングされるかを指定します。可能な値はcom.aspose.slides.BlackWhiteModeクラスで指定されています。

|**値** |**意味** |
| :- | :- |
|Color |通常の色付けで返す |
|Automatic |自動色付けで返す |
|Gray |灰色で返す |
|LightGray |薄灰色で返す |
|InverseGray |反転灰色で返す |
|GrayWhite |灰色と白色で返す |
|BlackGray |黒と灰色で返す |
|BlackWhite |黒と白で返す |
|Black |黒だけで返す |
|White |白で返す |
|Hidden |オブジェクトはレンダリングされません |
#### **メソッドremoveAt(int)、remove(ICommentAuthor)、およびclear()がcom.aspose.slides.ICommentAuthorCollectionに追加されました**
指定されたインデックスで著者を削除するためのメソッドICommentAuthorCollection.removeAt(int)が追加されました。指定された著者をコレクションから削除するためのメソッドICommentAuthorCollection.remove(ICommentAuthor)が追加されました。コレクションからすべてのアイテムを削除するためのメソッドICommentAuthorCollection.clear()が追加されました。