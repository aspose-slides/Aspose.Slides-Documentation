---
title: プレゼンテーションのローカリゼーション
type: docs
weight: 100
url: /ja/nodejs-java/presentation-localization/
---

## **プレゼンテーションとシェイプのテキストの言語を変更する**

- [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- スライドに[AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape)の[Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeType#Rectangle)タイプを追加します。
- TextFrameにテキストを追加します。
- テキストに[Setting Language Id](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BasePortionFormat#setLanguageId-java.lang.String-) を設定します。
- プレゼンテーションを PPTX ファイルとして書き出します。

上記手順の実装は以下の例で示されています。
```javascript
var pres = new aspose.slides.Presentation("test.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("Text to apply spellcheck language");
    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**言語IDは自動テキスト翻訳をトリガーしますか？**

いいえ。Aspose.Slides の[setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId)は、スペルチェックと文法校正のための言語を保存しますが、テキストの内容を翻訳したり変更したりはしません。これは PowerPoint が校正のために理解するメタデータです。

**言語IDはレンダリング時のハイフネーションや改行に影響しますか？**

Aspose.Slides では、[setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId)は校正用です。ハイフネーション品質と改行は主に[proper fonts](/slides/ja/nodejs-java/powerpoint-fonts/)とレイアウト／改行設定に依存します。正しいレンダリングを確保するには、必要なフォントを利用可能にし、[font substitution rules](/slides/ja/nodejs-java/font-substitution/) を構成し、または[embed fonts](/slides/ja/nodejs-java/embedded-font/) をプレゼンテーションに埋め込みます。

**単一段落内で異なる言語を設定できますか？**

はい。[setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) はテキスト部分レベルで適用されるため、単一段落内で複数言語を混在させ、個別の校正設定を使用できます。