---
title: Android でプレゼンテーション ローカリゼーションを自動化
linktitle: プレゼンテーション ローカリゼーション
type: docs
weight: 100
url: /ja/androidjava/presentation-localization/
keywords:
- 言語変更
- スペルチェック
- 言語 ID
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Android 用 Aspose.Slides を使用した Java で、PowerPoint と OpenDocument スライドのローカリゼーションを自動化し、実用的なコードサンプルとヒントでグローバル展開を迅速化します。"
---

## **プレゼンテーションとシェイプテキストの言語を変更する**
- [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- スライドに [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) の [Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType#Rectangle) タイプを追加します。
- TextFrame にテキストを追加します。
- [Setting Language Id](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) をテキストに設定します。
- プレゼンテーションを PPTX ファイルとして書き出します。

上記の手順の実装は、以下のサンプルで示されています。
```java
Presentation pres = new Presentation("test.pptx");
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("Text to apply spellcheck language");

    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**言語 ID は自動テキスト翻訳をトリガーしますか？**

いいえ。Aspose.Slides の [Language ID](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) はスペルチェックと文法校正のための言語を保存しますが、テキストの内容を翻訳したり変更したりはしません。これは PowerPoint が校正用に理解するメタデータです。

**言語 ID はレンダリング時のハイフネーションや改行に影響しますか？**

Aspose.Slides では、[language ID](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) は校正用です。ハイフネーションの品質や改行は主に [proper fonts](/slides/ja/androidjava/powerpoint-fonts/) の利用可能性と、書記体系のレイアウト/改行設定に依存します。正しいレンダリングを確保するには、必要なフォントを利用可能にし、[font substitution rules](/slides/ja/androidjava/font-substitution/) を構成するか、またはプレゼンテーションに [embed fonts](/slides/ja/androidjava/embedded-font/) を埋め込みます。

**単一の段落内で異なる言語を設定できますか？**

はい。[Language ID](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) はテキスト部分レベルで適用されるため、単一の段落内で複数の言語を混在させ、個別の校正設定を使用できます。