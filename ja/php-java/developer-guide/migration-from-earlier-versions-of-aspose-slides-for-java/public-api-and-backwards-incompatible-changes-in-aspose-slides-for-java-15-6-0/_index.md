---
title: Aspose.Slides for PHP via Java 15.6.0の公開APIおよび互換性のない変更
type: docs
weight: 140
url: /php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for PHP via Java 15.6.0 APIで追加されたすべての[クラス](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/)、メソッド、プロパティなど、新しい制限事項およびその他の[変更](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/)について一覧で示します。

{{% /alert %}} 
## **公開APIの変更**
#### **com.aspose.slides.DataLabelのコンストラクタシグネチャが変更されました**
コンストラクタのシグネチャがDataLabel(com.aspose.slides.IChartSeries)からDataLabel(com.aspose.slides.IChartDataPoint)に変更されました。
#### **メンバーcom.aspose.slides.IDocumentProperties.getCount()、.getPropertyName(int index)、.remove(String name)、.contains(String name)が非推奨としてマークされ、代わりに置き換えが導入されました**
メソッドIDocumentProperties.getCount()、IDocumentProperties.getPropertyName(int index)、.remove(string name)、.contains(string name)が非推奨としてマークされました。代わりに、メソッドIDocumentProperties.countOfCustomProperties()、IDocumentProperties.getCustomPropertyName(int index)、.removeCustomProperty(String name)、.containsCustomProperty(string name)が導入されました。
#### **メソッドcom.aspose.slides.INotesSlideManager.removeNotesSlide()が追加されました**
メソッドcom.aspose.slides.INotesSlideManager.RemoveNotesSlide()がいくつかのスライドのノートスライドを削除するために追加されました。
#### **メソッドcom.aspose.slides.ISlide.getNotesSlideManager()が追加されました。メソッドISlide.getNotesSlide()およびISlide.addNotesSlide()が非推奨としてマークされました**
ISlide.getNotesSlide()、ISlide.addNotesSlide()メソッドが非推奨としてマークされました。新しいメソッドISlide.getNotesSlideManager()を代わりに使用してください。

```php
  $slide = $$missing$;
  $notes;
  # notes = slide.addNotesSlide(); - 非推奨
  # notes = slide.getNotesSlide(); - 非推奨
  $notes = $slide->getNotesSlideManager()->getNotesSlide();
  $notes = $slide->getNotesSlideManager()->addNotesSlide();
  $slide->getNotesSlideManager()->removeNotesSlide();

```
#### **メソッドgetAppVersion()がcom.aspose.slides.IDocumentPropertiesに追加されました**
メソッドcom.aspose.slides.IDocumentProperties.getAppVersion()が、Microsoft PowerPointによって使用される内部バージョン番号を表す組み込みドキュメントプロパティを取得するために追加されました。
#### **メソッドremove()がcom.aspose.slides.ICommentに追加されました**
メソッドcom.aspose.slides.IComment.remove()が、コレクションからコメントを削除するために追加されました。
#### **メソッドremove()がcom.aspose.slides.ICommentAuthorに追加されました**
メソッドICommentAuthor.Removeが、コレクションからコメントの著者を削除するために追加されました。
#### **メソッドclearCustomProperties()およびclearBuiltInProperties()がcom.aspose.slides.IDocumentPropertiesに追加されました**
メソッドcom.aspose.slides.IDocumentProperties.clearCustomProperties()が、すべてのカスタムドキュメントプロパティを削除するために追加されました。
メソッドcom.aspose.slides.IDocumentProperties.clearBuiltInProperties()が、すべての組み込みドキュメントプロパティ（会社、件名、著者など）のデフォルト値を削除および設定するために追加されました。
#### **メソッドgetBlackWhiteMode()、setBlackWhiteMode(byte)がcom.aspose.slides.IShapeに追加されました**
メソッドgetBlackWhiteMode()、setBlackWhiteMode(byte)がcom.aspose.slides.IShapeに追加されました。
これらのメソッドは、形状が白黒表示モードでどのようにレンダリングされるかを指定します。可能な値はcom.aspose.slides.BlackWhiteModeクラスで指定されています。

|**値** |**意味** |
| :- | :- |
|Color |通常の色付けで返す |
|Automatic |自動色付けで返す |
|Gray |グレーで返す |
|LightGray |薄いグレーで返す |
|InverseGray |逆グレーで返す |
|GrayWhite |グレーと白で返す |
|BlackGray |黒とグレーで返す |
|BlackWhite |黒と白で返す |
|Black |黒のみで返す |
|White |白で返す |
|Hidden |オブジェクトはレンダリングされません |
#### **メソッドremoveAt(int)、remove(ICommentAuthor)、およびclear()がcom.aspose.slides.ICommentAuthorCollectionに追加されました**
メソッドICommentAuthorCollection.removeAt(int)が、指定されたインデックスによって著者を削除するために追加されました。メソッドICommentAuthorCollection.remove(ICommentAuthor)が、コレクションから指定された著者を削除するために追加されました。メソッドICommentAuthorCollection.clear()が、コレクションからすべてのアイテムを削除するために追加されました。