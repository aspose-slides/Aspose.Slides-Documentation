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
description: "Aspose.Slides for .NET のパブリック API の更新と破壊的変更を確認し、PowerPoint の PPT、PPTX、ODP プレゼンテーション ソリューションをスムーズに移行できるようにします。"
---

{{% alert color="primary" %}} 
このページでは、Aspose.Slides for .NET 15.6.0 APIで導入された、[追加](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) または [削除](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) クラス、メソッド、プロパティ等、その他の変更をすべて一覧表示します。
{{% /alert %}} 
## **パブリック API の変更**
#### **DataLabel コンストラクタのシグネチャが変更されました**
DataLabel コンストラクタのシグネチャが変更されました：
was: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
now: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **メンバー IDocumentProperties.Count、.GetPropertyName(int index)、.Remove(string name)、.Contains(string name) が Obsolete とマークされ、代替が導入されました**
IDocumentProperties.Count プロパティと IDocumentProperties.GetPropertyName(int index)、.Remove(string name)、.Contains(string name) メソッドは Obsolete とマークされました。代わりに、IDocumentProperties.CountOfCustomProperties プロパティと IDocumentProperties.GetCustomPropertyName(int index)、.RemoveCustomProperty(string name)、.ContainsCustomProperty(string name) メソッドが追加されました。
#### **INotesSlideManager.RemoveNotesSlide() メソッドが追加されました**
INotesSlideManager.RemoveNotesSlide() メソッドは、スライドのノートスライドを削除するために追加されました。
#### **IComment に Remove メソッドが追加されました**
IComment.Remove メソッドは、コレクションからコメントを削除するために追加されました。
#### **ICommentAuthor に Remove メソッドが追加されました**
ICommentAuthor.Remove メソッドは、コレクションからコメントの作成者を削除するために追加されました。
#### **IDocumentProperties に ClearCustomProperties と ClearBuiltInProperties メソッドが追加されました**
IDocumentProperties.ClearCustomProperties メソッドは、すべてのカスタムドキュメントプロパティを削除するために追加されました。
IDocumentProperties.ClearBuiltInProperties メソッドは、すべての組み込みドキュメントプロパティ（Company、Subject、Author など）を削除し、デフォルト値を設定するために追加されました。
#### **ICommentAuthorCollection に RemoveAt、Remove、Clear メソッドが追加されました**
ICommentAuthorCollection.RemoveAt メソッドは、指定されたインデックスで作成者を削除するために追加されました。
ICommentAuthorCollection.Remove メソッドは、コレクションから指定された作成者を削除するために追加されました。
ICommentAuthorCollection.Clear メソッドは、コレクションからすべての項目を削除するために追加されました。
#### **IDocumentProperties に AppVersion プロパティが追加されました**
IDocumentProperties.AppVersion プロパティは、Microsoft が開発中に使用する内部バージョン番号を表す組み込みドキュメントプロパティを取得するために追加されました。
#### **IShape と Shape に BlackWhiteMode プロパティが追加されました**
IShape と Shape に BlackWhiteMode プロパティが追加されました。

このプロパティは、形状が白黒表示モードでどのようにレンダリングされるかを指定します。

|**Value**|**Meaning**|
| :- | :- |
|Color|通常の色でレンダリング|
|Automatic|自動的に色付けしてレンダリング|
|Gray|グレーでレンダリング|
|LightGray|薄いグレーでレンダリング|
|InverseGray|逆グレーでレンダリング|
|GrayWhite|グレーと白でレンダリング|
|BlackGray|黒とグレーでレンダリング|
|BlackWhite|黒と白でレンダリング|
|Black|黒のみでレンダリング|
|White|白でレンダリング|
|Hidden|レンダリングしない|
|NotDefined|プロパティが設定されていないことを意味します|
#### **ISlide.NotesSlideManager プロパティが追加されました。ISlide.NotesSlide プロパティと ISlide.AddNotesSlide() メソッドは Obsolete とマークされました。**
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