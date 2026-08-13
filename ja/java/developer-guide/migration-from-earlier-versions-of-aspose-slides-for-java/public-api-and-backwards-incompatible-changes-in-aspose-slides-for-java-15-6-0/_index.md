---
title: "Aspose.Slides for Java 15.6.0 のパブリック API と後方互換性のない変更"
linktitle: "Aspose.Slides for Java 15.6.0"
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
description: "Aspose.Slides for Java のパブリック API の更新と破壊的変更を確認し、PowerPoint の PPT、PPTX、ODP プレゼンテーション ソリューションをスムーズに移行できるようにします。"
---
{{% alert color="info" %}} 

このページでは、Aspose.Slides for Java 15.6.0 APIで導入された、[追加](/slides/ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/)されたクラス、メソッド、プロパティなど、すべての新しい制限やその他の[変更](/slides/ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/)を一覧表示します。

{{% /alert %}} 
## **パブリック API の変更**
#### **com.aspose.slides.DataLabel コンストラクタのシグネチャが変更されました**
コンストラクタのシグネチャは DataLabel(com.aspose.slides.IChartSeries) から DataLabel(com.aspose.slides.IChartDataPoint) に変更されました。
#### **メンバー com.aspose.slides.IDocumentProperties.getCount()、.getPropertyName(int index)、.remove(String name)、.contains(String name) が非推奨としてマークされました。代わりに置き換えメソッドが導入されました**
IDocumentProperties.getCount()、IDocumentProperties.getPropertyName(int index)、.remove(string name)、.contains(string name) メソッドは非推奨となりました。代わりに IDocumentProperties.countOfCustomProperties()、IDocumentProperties.getCustomPropertyName(int index)、.removeCustomProperty(String name)、.containsCustomProperty(string name) メソッドが導入されました。
#### **メソッド com.aspose.slides.INotesSlideManager.removeNotesSlide() が追加されました**
com.aspose.slides.INotesSlideManager.RemoveNotesSlide() メソッドが、スライドのノートスライドを削除するために追加されました。
#### **メソッド com.aspose.slides.ISlide.getNotesSlideManager() が追加されました。メソッド ISlide.getNotesSlide() と ISlide.addNotesSlide() は非推奨となりました**
ISlide.getNotesSlide()、ISlide.addNotesSlide() メソッドは非推奨となりました。代わりに新しいメソッド ISlide.getNotesSlideManager() を使用してください。

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    INotesSlide notes;

    // notes = slide.addNotesSlide(); - 非推奨

    // notes = slide.getNotesSlide(); - 非推奨

    notes = slide.getNotesSlideManager().getNotesSlide();

    notes = slide.getNotesSlideManager().addNotesSlide();

    slide.getNotesSlideManager().removeNotesSlide();
} finally {
    if (pres != null) pres.dispose();
}
```
#### **メソッド getAppVersion() が com.aspose.slides.IDocumentProperties に追加されました**
com.aspose.slides.IDocumentProperties.getAppVersion() メソッドが、Microsoft PowerPoint が使用する内部バージョン番号を表す組み込みドキュメントプロパティを取得するために追加されました。
#### **メソッド remove() が com.aspose.slides.IComment に追加されました**
com.aspose.slides.IComment.remove() メソッドが、コレクションからコメントを削除するために追加されました。
#### **メソッド remove() が com.aspose.slides.ICommentAuthor に追加されました**
com.aspose.slides.ICommentAuthor.Remove メソッドが、コレクションからコメントの作成者を削除するために追加されました。
#### **メソッド clearCustomProperties() と clearBuiltInProperties() が com.aspose.slides.IDocumentProperties に追加されました**
com.aspose.slides.IDocumentProperties.clearCustomProperties() メソッドが、すべてのカスタムドキュメントプロパティを削除するために追加されました。
com.aspose.slides.IDocumentProperties.clearBuiltInProperties() メソッドが、すべての組み込みドキュメントプロパティ（Company、Subject、Author など）を削除し、デフォルト値に設定するために追加されました。
#### **メソッド getBlackWhiteMode()、setBlackWhiteMode(byte) が com.aspose.slides.IShape に追加されました**
これらのメソッドは、シェイプが白黒表示モードでどのように描画されるかを指定します。可能な値は com.aspose.slides.BlackWhiteMode クラスで定義されています。

|**Value** |**Meaning** |
| :- | :- |
|Color |通常のカラーで返します |
|Automatic |自動カラーで返します |
|Gray |グレーカラーで返します |
|LightGray |ライトグレーカラーで返します |
|InverseGray |逆グレーカラーで返します |
|GrayWhite |グレーとホワイトのカラーで返します |
|BlackGray |ブラックとグレーカラーで返します |
|BlackWhite |ブラックとホワイトのカラーで返します |
|Black |ブラックカラーのみで返します |
|White |ホワイトカラーで返します |
|Hidden |オブジェクトは描画されません |
#### **メソッド removeAt(int)、remove(ICommentAuthor) と clear() が com.aspose.slides.ICommentAuthorCollection に追加されました**
ICommentAuthorCollection.removeAt(int) メソッドは、指定されたインデックスで作成者を削除するために追加されました。 ICommentAuthorCollection.remove(ICommentAuthor) メソッドは、コレクションから指定された作成者を削除するために追加されました。 ICommentAuthorCollection.clear() メソッドは、コレクション内のすべての項目を削除するために追加されました。