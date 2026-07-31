---
title: Aspose.Slides for Java 15.6.0 のパブリック API と後方互換性のない変更
linktitle: Aspose.Slides for Java 15.6.0
type: docs
weight: 140
url: /ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
aliases:
  - /java/aspose-slides-for-java-15-6-0-release-notes/
keywords:
  - 移行
  - レガシーコード
  - モダンコード
  - レガシーアプローチ
  - モダンアプローチ
  - PowerPoint
  - OpenDocument
  - プレゼンテーション
  - Java
  - Aspose.Slides
description: "Aspose.Slides for Java のパブリック API の更新と破壊的変更を確認し、PowerPoint PPT、PPTX、ODP プレゼンテーション ソリューションをスムーズに移行できるようにします。"
---
{{% alert color="primary" %}} 

このページでは、Aspose.Slides for Java 15.6.0 APIで導入された、すべての [added](/slides/ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) クラス、メソッド、プロパティ等、そして新しい制限やその他の [changes](/slides/ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) を一覧表示します。

{{% /alert %}} 
## **パブリック API の変更**
#### **com.aspose.slides.DataLabel コンストラクタのシグネチャが変更されました**
コンストラクタのシグネチャが `DataLabel(com.aspose.slides.IChartSeries)` から `DataLabel(com.aspose.slides.IChartDataPoint)` に変更されました。
#### **メンバー com.aspose.slides.IDocumentProperties.getCount()、.getPropertyName(int index).、.remove(String name)、.contains(String name) が非推奨としてマークされ、代替が導入されました**
`IDocumentProperties.getCount()`、`IDocumentProperties.getPropertyName(int index).`、`.remove(string name)`、`.contains(string name)` が非推奨となりました。代わりに `IDocumentProperties.countOfCustomProperties()`、`IDocumentProperties.getCustomPropertyName(int index).`、`.removeCustomProperty(String name)`、`.containsCustomProperty(string name)` が導入されました。
#### **メソッド com.aspose.slides.INotesSlideManager.removeNotesSlide() が追加されました**
`com.aspose.slides.INotesSlideManager.RemoveNotesSlide()` メソッドが追加され、スライドのノート スライドを削除できるようになりました。
#### **メソッド com.aspose.slides.ISlide.getNotesSlideManager() が追加されました。メソッド ISlide.getNotesSlide() と ISlide.addNotesSlide() が非推奨となりました**
`ISlide.getNotesSlide()`、`ISlide.addNotesSlide()` が非推奨となり、代わりに新しいメソッド `ISlide.getNotesSlideManager()` を使用してください。

``` java

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.addNotesSlide(); - 非推奨

// notes = slide.getNotesSlide(); - 非推奨

notes = slide.getNotesSlideManager().getNotesSlide();

notes = slide.getNotesSlideManager().addNotesSlide();

slide.getNotesSlideManager().removeNotesSlide();

```
#### **メソッド getAppVersion() が com.aspose.slides.IDocumentProperties に追加されました**
`com.aspose.slides.IDocumentProperties.getAppVersion()` メソッドが追加され、Microsoft PowerPoint が内部で使用するバージョン番号を表す組み込みドキュメント プロパティを取得できます。
#### **メソッド remove() が com.aspose.slides.IComment に追加されました**
`com.aspose.slides.IComment.remove()` メソッドが追加され、コレクションからコメントを削除できるようになりました。
#### **メソッド remove() が com.aspose.slides.ICommentAuthor に追加されました**
`ICommentAuthor.Remove` メソッドが追加され、コレクションからコメントの作成者を削除できるようになりました。
#### **メソッド clearCustomProperties() と clearBuiltInProperties() が com.aspose.slides.IDocumentProperties に追加されました**
`com.aspose.slides.IDocumentProperties.clearCustomProperties()` メソッドが追加され、すべてのカスタム ドキュメント プロパティを削除できます。  
`com.aspose.slides.IDocumentProperties.clearBuiltInProperties()` メソッドが追加され、すべての組み込みドキュメント プロパティ（Company、Subject、Author など）を削除し、既定値にリセットできます。
#### **メソッド getBlackWhiteMode()、setBlackWhiteMode(byte) が com.aspose.slides.IShape に追加されました**
`com.aspose.slides.IShape` に `getBlackWhiteMode()`、`setBlackWhiteMode(byte)` が追加されました。これらのメソッドは、形状が白黒表示モードでどのように描画されるかを指定します。可能な値は `com.aspose.slides.BlackWhiteMode` クラスで定義されています。

|**値**|**意味**|
| :- | :- |
|Color|通常の色で返す|
|Automatic|自動的な色で返す|
|Gray|グレイで返す|
|LightGray|薄いグレイで返す|
|InverseGray|逆グレイで返す|
|GrayWhite|グレイとホワイトで返す|
|BlackGray|ブラックとグレイで返す|
|BlackWhite|ブラックとホワイトで返す|
|Black|ブラックだけで返す|
|White|ホワイトだけで返す|
|Hidden|オブジェクトは描画されない|

#### **メソッド removeAt(int)、remove(ICommentAuthor) および clear() が com.aspose.slides.ICommentAuthorCollection に追加されました**
`ICommentAuthorCollection.removeAt(int)` が追加され、指定したインデックスの作成者を削除できます。  
`ICommentAuthorCollection.remove(ICommentAuthor)` が追加され、指定した作成者をコレクションから削除できます。  
`ICommentAuthorCollection.clear()` が追加され、コレクション内のすべての項目を削除できます。