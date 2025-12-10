---
title: Javaでプレゼンテーションのローカリゼーションを自動化
linktitle: プレゼンテーション ローカリゼーション
type: docs
weight: 100
url: /ja/java/presentation-localization/
keywords:
- 言語変更
- スペルチェック
- 言語ID
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides を使用し、実用的なコードサンプルとヒントで、Java における PowerPoint と OpenDocument スライドのローカリゼーションを自動化し、グローバル展開を迅速化します。"
---

## **プレゼンテーションとシェイプテキストの言語を変更する**
- [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- スライドに [Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeType#Rectangle) タイプの [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) を追加します。
- TextFrame にテキストを追加します。
- [Setting Language Id](https://reference.aspose.com/slides/java/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) をテキストに設定します。
- プレゼンテーションを書き出し、PPTX ファイルとして保存します。

上記の手順の実装例を以下に示します。
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


## **よくある質問**

**言語 ID は自動テキスト翻訳をトリガーしますか？**

いいえ。[Language ID](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) はスペルチェックや文法校正のための言語情報を保持しますが、テキストの内容を翻訳したり変更したりはしません。これは PowerPoint が校正用に理解するメタデータです。

**言語 ID はレンダリング時のハイフネーションや改行に影響しますか？**

Aspose.Slides では、language ID は校正用です。ハイフネーションの品質や行折り返しは主に [proper fonts](/slides/ja/java/powerpoint-fonts/) の有無や、書記体系用のレイアウト/改行設定に依存します。正しく表示させるには、必要なフォントを用意し、[font substitution rules](/slides/ja/java/font-substitution/) を設定するか、プレゼンテーションに [embed fonts](/slides/ja/java/embedded-font/) を埋め込んでください。

**単一の段落内で異なる言語を設定できますか？**

はい。[Language ID](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) はテキストの部分（portion）レベルで適用されるため、単一の段落内で複数の言語を混在させ、個別の校正設定を使用できます。