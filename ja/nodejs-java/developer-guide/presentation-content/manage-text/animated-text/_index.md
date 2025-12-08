---
title: アニメーションテキスト
type: docs
weight: 60
url: /ja/nodejs-java/animated-text/
keywords: "PowerPoint のアニメーションテキスト"
description: "Java を使用した PowerPoint のアニメーションテキスト"
---

## **段落へのアニメーション効果の追加**

[**addEffect()**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Sequence#addEffect-aspose.slides.IParagraph-int-int-int-) メソッドを [**Sequence**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Sequence) と [**Sequence**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Sequence) クラスに追加しました。このメソッドを使用すると、単一の段落にアニメーション効果を追加できます。次のサンプルコードは、単一の段落にアニメーション効果を追加する方法を示しています:
```javascript
var presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // エフェクトを追加する段落を選択
    var autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    // 選択した段落に Fly アニメーションエフェクトを追加
    var effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Left, aspose.slides.EffectTriggerType.OnClick);
    presentation.save("AnimationEffectinParagraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **段落内のアニメーション効果の取得**

段落に追加されたアニメーション効果を取得したい場合があります。たとえば、別の段落やシェイプに同じ効果を適用したいシナリオです。

Aspose.Slides for Node.js via Java を使用すると、テキストフレーム（シェイプ）内に含まれる段落に適用されたすべてのアニメーション効果を取得できます。次のサンプルコードは、段落内のアニメーション効果を取得する方法を示しています:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    var autoShape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    for (let i = 0; i < autoShape.getTextFrame().getParagraphs().getCount(); i++) {
        let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(i);
        var effects = sequence.getEffectsByParagraph(paragraph);
        if (effects.length > 0) {
            console.log("Paragraph \"" + paragraph.getText() + "\" has " + effects[0].getType() + " effect.");
        }
    }
} finally {
    pres.dispose();
}
```


## **FAQ**

**テキストアニメーションはスライドトランジションとどう違い、組み合わせは可能ですか？**

テキストアニメーションはスライド上のオブジェクトの動作を時間軸で制御し、[transitions](/slides/ja/nodejs-java/slide-transition/) はスライド間の切り替え方法を制御します。両者は独立していますが同時に使用でき、再生順序はアニメーションタイムラインとトランジション設定で決まります。

**テキストアニメーションは PDF や画像へのエクスポート時に保持されますか？**

保持されません。PDF やラスタ画像は静的なので、スライドの単一状態しか表示されません。動きを保持したい場合は [video](/slides/ja/nodejs-java/convert-powerpoint-to-video/) または [HTML](/slides/ja/nodejs-java/export-to-html5/) でエクスポートしてください。

**テキストアニメーションはレイアウトやスライドマスターでも機能しますか？**

レイアウト/マスターオブジェクトに適用された効果はスライドに継承されますが、タイミングやスライドレベルのアニメーションとの相互作用は最終的なスライド上のシーケンスに依存します。