---
title: Androidでのプレゼンテーションのローカリゼーションを自動化
linktitle: プレゼンテーション ローカリゼーション
type: docs
weight: 100
url: /ja/androidjava/presentation-localization/
keywords:
- 言語の変更
- スペルチェック
- 言語 ID
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用し、Java で PowerPoint および OpenDocument スライドのローカリゼーションを自動化します。実用的なコードサンプルとヒントを活用して、グローバル展開を迅速に行うことができます。"
---

## **プレゼンテーションとシェイプ テキストの言語を変更する**
- [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- スライドに [Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType#Rectangle) タイプの [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) を追加します。
- TextFrame にテキストを追加します。
- テキストに [Setting Language Id](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) を設定します。
- プレゼンテーションを PPTX ファイルとして書き出します。

上記の手順の実装例は以下に示します。
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

いいえ。[Language ID](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) は Aspose.Slides でスペルチェックと文法校正のための言語を保存しますが、テキスト内容を翻訳したり変更したりしません。PowerPoint が校正のために理解するメタデータです。

**言語 ID はレンダリング時のハイフネーションや改行に影響しますか？**

Aspose.Slides では、[language ID](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) は校正用です。ハイフネーションの品質や改行は主に [proper fonts](/slides/ja/androidjava/powerpoint-fonts/) と書字システムのレイアウト/改行設定に依存します。正しくレンダリングするには、必要なフォントを利用可能にし、[font substitution rules](/slides/ja/androidjava/font-substitution/) を構成し、またはプレゼンテーションに [embed fonts](/slides/ja/androidjava/embedded-font/) を埋め込んでください。

**単一の段落内で異なる言語を設定できますか？**

はい。[Language ID](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) はテキスト部分レベルで適用されるため、単一の段落に複数の言語を混在させ、異なる校正設定を持たせることができます。