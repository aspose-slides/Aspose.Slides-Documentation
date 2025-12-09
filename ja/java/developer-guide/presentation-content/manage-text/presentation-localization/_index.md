---
title: Java でプレゼンテーションのローカリゼーションを自動化
linktitle: プレゼンテーションのローカリゼーション
type: docs
weight: 100
url: /ja/java/presentation-localization/
keywords:
- 言語の変更
- スペルチェック
- 言語 ID
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Java と Aspose.Slides を使用して、PowerPoint および OpenDocument のスライドローカリゼーションを自動化し、実践的なコードサンプルとヒントでグローバル展開を迅速化します。"
---

## **プレゼンテーションとシェイプのテキストの言語を変更する**
- [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
- Index を使用してスライドの参照を取得します。
- スライドに [Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeType#Rectangle) タイプの [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) を追加します。
- TextFrame にテキストを追加します。
- テキストに対して [Setting Language Id](https://reference.aspose.com/slides/java/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) を設定します。
- プレゼンテーションを PPTX ファイルとして保存します。

上記手順の実装例は以下のサンプルで示されています。
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

いいえ。Aspose.Slides の [Language ID](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) はスペルチェックや文法校正のための言語情報を保持しますが、テキスト内容を翻訳したり変更したりしません。これは PowerPoint が校正用に理解するメタデータです。

**言語 ID はレンダリング時のハイフネーションや改行に影響しますか？**

Aspose.Slides では、[language ID](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) は校正用です。ハイフネーションの品質や改行は主に、[proper fonts](/slides/ja/java/powerpoint-fonts/) の有無や、書記体系のレイアウト/改行設定に依存します。正しいレンダリングを確保するには、必要なフォントを利用可能にし、[font substitution rules](/slides/ja/java/font-substitution/) を設定するか、またはプレゼンテーションに [embed fonts](/slides/ja/java/embedded-font/) を埋め込んでください。

**単一の段落内で異なる言語を設定できますか？**

はい。[Language ID](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) はテキストの部分レベルで適用されるため、単一の段落内で複数の言語を混在させ、個別の校正設定を持たせることができます。