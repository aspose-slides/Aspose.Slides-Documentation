---
title: JavaScriptでフォールバックフォントを使用したプレゼンテーションのレンダリング
linktitle: プレゼンテーションのレンダリング
type: docs
weight: 30
url: /ja/nodejs-java/render-presentation-with-fallback-font/
keywords:
- フォールバックフォント
- PowerPointのレンダリング
- プレゼンテーションのレンダリング
- スライドのレンダリング
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js でフォールバックフォントを使用してプレゼンテーションをレンダリングします – PPT、PPTX、ODP のテキストを一貫させるステップバイステップの JavaScript コードサンプル。"
---

以下の例では、これらの手順が含まれます:

1. [フォールバックフォント規則コレクションを作成](/slides/ja/nodejs-java/create-fallback-fonts-collection/)。
1. [Remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) フォールバックフォント規則を削除し、別の規則に[addFallBackFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) を追加します。
1. ルールコレクションを [getFontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager#getFontFallBackRulesCollection--) メソッドに設定します。
1. [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) メソッドを使用すると、プレゼンテーションを同じ形式で保存するか、別の形式で保存できます。フォールバックフォント規則コレクションが [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager) に設定されると、これらの規則はプレゼンテーションに対する保存、レンダリング、変換などのあらゆる操作中に適用されます。
```javascript
// ルールコレクションの新しいインスタンスを作成
var rulesList = new aspose.slides.FontFallBackRulesCollection();
// 複数のルールを作成
rulesList.add(new aspose.slides.FontFallBackRule(0x400, 0x4ff, "Times New Roman"));
for (let i = 0; i < rulesList.size(); i++) {
    let fallBackRule = rulesList.get_Item(0);
    // ロードされたルールからフォールバックフォント "Tahoma" を削除しようとしています
    fallBackRule.remove("Tahoma");
    // 指定された範囲のルールを更新します
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000)) {
        fallBackRule.addFallBackFonts("Verdana");
    }
}
// リストから既存のルールをすべて削除することもできます
if (rulesList.size() > 0) {
    rulesList.remove(rulesList.get_Item(0));
}
var pres = new aspose.slides.Presentation("input.pptx");
try {
    // 使用するために準備したルールリストを割り当てます
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);
    // 初期化されたルールコレクションを使用してサムネイルをレンダリングし、JPEGとして保存します
    var slideImage = pres.getSlides().get_Item(0).getImage(1.0, 1.0);
    // 画像を JPEG 形式でディスクに保存します
    try {
        slideImage.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" %}} 
[Convert PPT and PPTX to JPG in JavaScript](/slides/ja/nodejs-java/convert-powerpoint-to-jpg/) の詳細をご覧ください。
{{% /alert %}}