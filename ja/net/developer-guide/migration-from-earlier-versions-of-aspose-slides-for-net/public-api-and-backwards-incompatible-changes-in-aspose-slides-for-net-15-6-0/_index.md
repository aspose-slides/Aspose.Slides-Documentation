---
title: "Aspose.Slides for .NET 15.6.0 のパブリック API と下位互換性のない変更"
linktitle: "Aspose.Slides for .NET 15.6.0"
type: docs
weight: 170
url: /ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/
keywords:
- 移行
- レガシーコード
- モダンコード
- レガシーアプローチ
- モダンアプローチ
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET のパブリック API の更新と破壊的変更を確認し、PowerPoint PPT、PPTX、ODP プレゼンテーション ソリューションをスムーズに移行できるようにします。"
---
{{% alert color="info" %}} 

このページでは、Aspose.Slides for .NET 15.6.0 APIで導入された、追加された[追加](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/)または[削除](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/)クラス、メソッド、プロパティ等、およびその他の変更を一覧表示します。

{{% /alert %}} 
## **パブリック API の変更**
#### **DataLabel コンストラクタのシグネチャが変更されました**
DataLabel のコンストラクタ シグネチャが変更されました:
以前: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
現在: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).

#### **メンバー IDocumentProperties.Count、.GetPropertyName(int index)、.Remove(string name)、.Contains(string name) が非推奨としてマークされ、その代替が導入されました。**
IDocumentProperties.Count プロパティと IDocumentProperties.GetPropertyName(int index)、.Remove(string name)、.Contains(string name) メソッドが非推奨としてマークされました。代わりに、IDocumentProperties.CountOfCustomProperties プロパティと IDocumentProperties.GetCustomPropertyName(int index)、.RemoveCustomProperty(string name)、.ContainsCustomProperty(string name) メソッドが追加されました。

#### **メソッド INotesSlideManager.RemoveNotesSlide() が追加されました**
スライドのノートスライドを削除するために、INotesSlideManager.RemoveNotesSlide() メソッドが追加されました。

#### **メソッド Remove が IComment に追加されました**
コレクションからコメントを削除するために、IComment.Remove メソッドが追加されました。

#### **メソッド Remove が ICommentAuthor に追加されました**
コレクションからコメントの作成者を削除するために、ICommentAuthor.Remove メソッドが追加されました。

#### **メソッド ClearCustomProperties と ClearBuiltInProperties が IDocumentProperties に追加されました**
IDocumentProperties.ClearCustomProperties メソッドが、すべてのカスタムドキュメントプロパティを削除するために追加されました。
IDocumentProperties.ClearBuiltInProperties メソッドが、すべての組み込みドキュメントプロパティ（Company、Subject、Author など）を削除し、デフォルト値に設定するために追加されました。

#### **メソッド RemoveAt、Remove、Clear が ICommentAuthorCollection に追加されました**
ICommentAuthorCollection.RemoveAt メソッドが、指定したインデックスで作成者を削除するために追加されました。
ICommentAuthorCollection.Remove メソッドが、コレクションから指定された作成者を削除するために追加されました。
ICommentAuthorCollection.Clear メソッドが、コレクション内のすべての項目を削除するために追加されました。

#### **プロパティ AppVersion が IDocumentProperties に追加されました**
IDocumentProperties.AppVersion プロパティが、Microsoft が開発時に使用する内部バージョン番号を表す組み込みドキュメントプロパティを取得できるように追加されました。

#### **プロパティ BlackWhiteMode が IShape と Shape に追加されました**
BlackWhiteMode プロパティが IShape と Shape に追加されました。

このプロパティは、形状が白黒表示モードでどのように描画されるかを指定します。

|**値** |**意味** |
| :- | :- |
|カラー|通常の色で描画|
|自動|自動的に色付けして描画|
|灰色|灰色で描画|
|ライトグレー|淡い灰色で描画|
|反転灰色|反転した灰色で描画|
|灰白|灰色と白色で描画|
|黒灰|黒色と灰色で描画|
|黒白|黒色と白色で描画|
|黒|黒色のみで描画|
|白|白色で描画|
|非表示|描画しない|
|未定義|プロパティが設定されていないことを意味します|

#### **プロパティ ISlide.NotesSlideManager が追加されました。プロパティ ISlide.NotesSlide とメソッド ISlide.AddNotesSlide() が非推奨としてマークされました。**
ISlide.NotesSlide および ISlide.AddNotesSlide() メンバーが非推奨としてマークされました。代わりに新しいプロパティ ISlide.NotesSlideManager を使用してください。

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("sample.pptx"))
{
    ISlide slide = pres.Slides[0];

    INotesSlide notes;

    // notes = slide.AddNotesSlide(); - 非推奨
    // notes = slide.NotesSlide; - 非推奨

    notes = slide.NotesSlideManager.NotesSlide;
    notes = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```