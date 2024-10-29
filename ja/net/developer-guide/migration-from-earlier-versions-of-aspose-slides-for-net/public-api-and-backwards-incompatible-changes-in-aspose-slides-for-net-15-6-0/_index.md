---
title: .NET用Aspose.Slides 15.6.0のパブリックAPIと後方互換性のない変更
type: docs
weight: 170
url: /ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for .NET 15.6.0 APIで追加されたすべての[追加された](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/)または[削除された](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/)クラス、メソッド、プロパティなど、他の変更をリストします。

{{% /alert %}} 
## **パブリックAPIの変更**
#### **DataLabelコンストラクターのシグネチャが変更されました**
DataLabelコンストラクターのシグネチャが変更されました：
以前: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
現在: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **メンバーIDocumentProperties.Count、.GetPropertyName(int index)、.Remove(string name)、.Contains(string name)が非推奨としてマークされ、代わりにその代替策が導入されました。**
プロパティIDocumentProperties.CountおよびメソッドIDocumentProperties.GetPropertyName(int index)、.Remove(string name)、.Contains(string name)が非推奨としてマークされました。代わりにプロパティIDocumentProperties.CountOfCustomPropertiesおよびメソッドIDocumentProperties.GetCustomPropertyName(int index)、.RemoveCustomProperty(string name)、.ContainsCustomProperty(string name)が追加されました。
#### **メソッドINotesSlideManager.RemoveNotesSlide()が追加されました**
メソッドINotesSlideManager.RemoveNotesSlide()が、特定のスライドのノートスライドを削除するために追加されました。
#### **メソッドRemoveがICommentに追加されました**
メソッドIComment.Removeが、コレクションからコメントを削除するために追加されました。
#### **メソッドRemoveがICommentAuthorに追加されました**
メソッドICommentAuthor.Removeが、コレクションからコメントの著者を削除するために追加されました。
#### **メソッドClearCustomPropertiesおよびClearBuiltInPropertiesがIDocumentPropertiesに追加されました**
メソッドIDocumentProperties.ClearCustomPropertiesが、すべてのカスタム文書プロパティを削除するために追加されました。
メソッドIDocumentProperties.ClearBuiltInPropertiesが、すべての組み込み文書プロパティ（会社、主題、著者など）に対して削除およびデフォルト値の設定を行うために追加されました。
#### **メソッドRemoveAt、RemoveおよびClearがICommentAuthorCollectionに追加されました**
メソッドICommentAuthorCollection.RemoveAtが、指定されたインデックスによって著者を削除するために追加されました。
メソッドICommentAuthorCollection.Removeが、指定された著者をコレクションから削除するために追加されました。
メソッドICommentAuthorCollection.Clearが、コレクションからすべてのアイテムを削除するために追加されました。
#### **プロパティAppVersionがIDocumentPropertiesに追加されました**
プロパティIDocumentProperties.AppVersionが、Microsoftが開発中に使用する内部バージョン番号を表す組み込み文書プロパティを取得するために追加されました。
#### **プロパティBlackWhiteModeがIShapeおよびShapeに追加されました**
プロパティBlackWhiteModeがIShapeおよびShapeに追加されました。

このプロパティは、図形が白黒表示モードでどのようにレンダリングされるかを指定します。

|**値** |**意味** |
| :- | :- |
|Color |通常の色付けでレンダリング |
|Automatic |自動色付けでレンダリング |
|Gray |灰色の色付けでレンダリング |
|LightGray |薄い灰色の色付けでレンダリング |
|InverseGray |逆灰色の色付けでレンダリング |
|GrayWhite |灰色と白の色付けでレンダリング |
|BlackGray |黒と灰色の色付けでレンダリング |
|BlackWhite |黒と白の色付けでレンダリング |
|Black |黒の色付けのみでレンダリング |
|White |白の色付けでレンダリング |
|Hidden |レンダリングしない |
|NotDefined|プロパティが設定されていないことを意味する|
#### **プロパティISlide.NotesSlideManagerが追加されました。プロパティISlide.NotesSlideおよびメソッドISlide.AddNotesSlide()が非推奨としてマークされました。**
ISlide.NotesSlide、ISlide.AddNotesSlide()メンバーが非推奨としてマークされました。代わりに新しいプロパティISlide.NotesSlideManagerを使用してください。

``` csharp

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.AddNotesSlide(); - 非推奨

// notes = slide.NotesSlide; - 非推奨

notes = slide.NotesSlideManager.NotesSlide;

notes = slide.NotesSlideManager.AddNotesSlide();

slide.NotesSlideManager.RemoveNotesSlide();

``` 