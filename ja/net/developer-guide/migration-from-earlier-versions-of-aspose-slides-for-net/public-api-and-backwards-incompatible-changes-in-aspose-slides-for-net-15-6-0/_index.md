---
title: Aspose.Slides for .NET 15.6.0 のパブリック API と後方互換性のない変更
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
description: "Aspose.Slides for .NET のパブリック API の更新と破壊的変更を確認し、PowerPoint PPT、PPTX、ODP プレゼンテーション ソリューションをスムーズに移行できるようにします。"
---

{{% alert color="primary" %}} 

このページは、Aspose.Slides for .NET 15.6.0 APIで導入された、すべての[added](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/)または[removed](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/)クラス、メソッド、プロパティ等、およびその他の変更を一覧表示します。

{{% /alert %}} 
## **Public API Changes**
#### **DataLabel Constructor Signature Has Been Changed**
DataLabel のコンストラクタ シグネチャが変更されました:
以前: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
現在: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **Members IDocumentProperties.Count, .GetPropertyName(int index), .Remove(string name), .Contains(string name) Have Been Marked as Obsolete and Its Substitutions Have Been Introduced Instead.**
プロパティ IDocumentProperties.Count とメソッド IDocumentProperties.GetPropertyName(int index)、.Remove(string name)、.Contains(string name) は Obsolete とマークされました。代わりに、プロパティ IDocumentProperties.CountOfCustomProperties とメソッド IDocumentProperties.GetCustomPropertyName(int index)、.RemoveCustomProperty(string name)、.ContainsCustomProperty(string name) が追加されました。
#### **Method INotesSlideManager.RemoveNotesSlide() Has Been Added**
メソッド INotesSlideManager.RemoveNotesSlide() が追加され、スライドのノート スライドを削除できるようになりました。
#### **Method Remove Has Been Added to IComment**
IComment にメソッド Remove が追加され、コレクションからコメントを削除できるようになりました。
#### **Method Remove Has Been Added to ICommentAuthor**
ICommentAuthor にメソッド Remove が追加され、コレクションからコメントの作成者を削除できるようになりました。
#### **Methods ClearCustomProperties and ClearBuiltInProperties Have Been Added to IDocumentProperties**
IDocumentProperties にメソッド ClearCustomProperties が追加され、すべてのカスタム ドキュメント プロパティを削除できます。
IDocumentProperties にメソッド ClearBuiltInProperties が追加され、すべての組み込みドキュメント プロパティ（Company、Subject、Author など）を削除し、デフォルト値にリセットできます。
#### **Methods RemoveAt, Remove and Clear Have Been Added to ICommentAuthorCollection**
ICommentAuthorCollection にメソッド RemoveAt が追加され、指定したインデックスの作成者を削除できます。
ICommentAuthorCollection にメソッド Remove が追加され、コレクションから指定した作成者を削除できます。
ICommentAuthorCollection にメソッド Clear が追加され、コレクション内のすべての項目を削除できます。
#### **Property AppVersion Has Been Added to IDocumentProperties**
IDocumentProperties にプロパティ AppVersion が追加され、Microsoft が開発中に使用した内部バージョン番号を表す組み込みドキュメント プロパティを取得できます。
#### **Property BlackWhiteMode Has Been Added to IShape and to Shape**
IShape と Shape にプロパティ BlackWhiteMode が追加されました。

このプロパティは、形状が白黒表示モードでどのように描画されるかを指定します。

|**Value**|**Meaning**|
| :- | :- |
|Color|通常のカラーで描画|
|Automatic|自動カラーで描画|
|Gray|グレーで描画|
|LightGray|ライトグレーで描画|
|InverseGray|逆グレーで描画|
|GrayWhite|グレーとホワイトで描画|
|BlackGray|ブラックとグレーで描画|
|BlackWhite|ブラックとホワイトで描画|
|Black|ブラックのみで描画|
|White|ホワイトで描画|
|Hidden|描画しない|
|NotDefined|プロパティが設定されていないことを意味する|
#### **Рroperty ISlide.NotesSlideManager Has Been Added. Property ISlide.NotesSlide and Method ISlide.AddNotesSlide() Have Been Marked as Obsolete.**
ISlide.NotesSlide と ISlide.AddNotesSlide() のメンバーは Obsolete とマークされました。代わりに新しいプロパティ ISlide.NotesSlideManager を使用してください。

``` csharp

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.AddNotesSlide(); - obsolete

// notes = slide.NotesSlide; - obsolete

notes = slide.NotesSlideManager.NotesSlide;

notes = slide.NotesSlideManager.AddNotesSlide();

slide.NotesSlideManager.RemoveNotesSlide();

```