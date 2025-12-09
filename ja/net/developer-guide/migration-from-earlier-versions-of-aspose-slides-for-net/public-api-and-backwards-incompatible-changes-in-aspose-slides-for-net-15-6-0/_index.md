---
title: Aspose.Slides for .NET 15.6.0 のパブリック API と互換性のない変更
linktitle: Aspose.Slides for .NET 15.6.0
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
description: "Aspose.Slides for .NET のパブリック API の更新と破壊的変更を確認し、PowerPoint の PPT、PPTX、ODP プレゼンテーション ソリューションをスムーズに移行できるようにします。"
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for .NET 15.6.0 APIで導入された、[追加済み](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/)または[削除済み](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/)クラス、メソッド、プロパティ等、およびその他の変更を一覧表示します。

{{% /alert %}} 
## **パブリック API の変更**
#### **DataLabel コンストラクターのシグネチャが変更されました**
DataLabel コンストラクターのシグネチャが変更されました:
以前: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
現在: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **メンバー IDocumentProperties.Count、.GetPropertyName(int index)、.Remove(string name)、.Contains(string name) が Obsolete としてマークされ、代替が導入されました。**
プロパティ IDocumentProperties.Count とメソッド IDocumentProperties.GetPropertyName(int index)、.Remove(string name)、.Contains(string name) は Obsolete としてマークされました。代わりに、プロパティ IDocumentProperties.CountOfCustomProperties とメソッド IDocumentProperties.GetCustomPropertyName(int index)、.RemoveCustomProperty(string name)、.ContainsCustomProperty(string name) が追加されました。
#### **メソッド INotesSlideManager.RemoveNotesSlide() が追加されました**
メソッド INotesSlideManager.RemoveNotesSlide() が追加され、スライドのノートスライドを削除できるようになりました。
#### **メソッド Remove が IComment に追加されました**
メソッド IComment.Remove が追加され、コレクションからコメントを削除できるようになりました。
#### **メソッド Remove が ICommentAuthor に追加されました**
メソッド ICommentAuthor.Remove が追加され、コレクションからコメントの作成者を削除できるようになりました。
#### **メソッド ClearCustomProperties と ClearBuiltInProperties が IDocumentProperties に追加されました**
メソッド IDocumentProperties.ClearCustomProperties が追加され、すべてのカスタムドキュメントプロパティを削除できます。  
メソッド IDocumentProperties.ClearBuiltInProperties が追加され、すべての組み込みドキュメントプロパティ（Company、Subject、Author など）を削除し、デフォルト値に設定できます。
#### **メソッド RemoveAt、Remove、Clear が ICommentAuthorCollection に追加されました**
メソッド ICommentAuthorCollection.RemoveAt が追加され、指定したインデックスの作成者を削除できます。  
メソッド ICommentAuthorCollection.Remove が追加され、コレクションから指定した作成者を削除できます。  
メソッド ICommentAuthorCollection.Clear が追加され、コレクション内のすべての項目を削除できます。
#### **プロパティ AppVersion が IDocumentProperties に追加されました**
プロパティ IDocumentProperties.AppVersion が追加され、Microsoft が開発中に使用する内部バージョン番号を表す組み込みドキュメントプロパティを取得できます。
#### **プロパティ BlackWhiteMode が IShape および Shape に追加されました**
プロパティ BlackWhiteMode が IShape と Shape に追加されました。

このプロパティは、黒白表示モードでシェイプがどのように描画されるかを指定します。

|**値** |**意味** |
| :- | :- |
|Color |通常のカラーで描画 |
|Automatic |自動カラーで描画 |
|Gray |グレーで描画 |
|LightGray |ライトグレーで描画 |
|InverseGray |逆グレーで描画 |
|GrayWhite |グレーと白で描画 |
|BlackGray |黒とグレーで描画 |
|BlackWhite |黒と白で描画 |
|Black |黒だけで描画 |
|White |白だけで描画 |
|Hidden |描画しない |
|NotDefined |プロパティが設定されていないことを意味します |
#### **プロパティ ISlide.NotesSlideManager が追加されました。プロパティ ISlide.NotesSlide とメソッド ISlide.AddNotesSlide() は Obsolete としてマークされました。**
ISlide.NotesSlide と ISlide.AddNotesSlide() のメンバーは Obsolete としてマークされました。代わりに新しいプロパティ ISlide.NotesSlideManager を使用してください。

```csharp
ISlide slide = ...;

INotesSlide notes;

// notes = slide.AddNotesSlide(); - 非推奨

// notes = slide.NotesSlide; - 非推奨

notes = slide.NotesSlideManager.NotesSlide;

notes = slide.NotesSlideManager.AddNotesSlide();

slide.NotesSlideManager.RemoveNotesSlide();
```