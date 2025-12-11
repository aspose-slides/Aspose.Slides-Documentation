---
title: AndroidでPowerPointテキストをアニメーション化
linktitle: アニメーションテキスト
type: docs
weight: 60
url: /ja/androidjava/animated-text/
keywords:
- アニメーションテキスト
- テキストアニメーション
- アニメーション段落
- 段落アニメーション
- アニメーション効果
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して、PowerPoint と OpenDocument のプレゼンテーションで動的なアニメーションテキストを作成し、わかりやすく最適化された Java コード例をご提供します。"
---

## **段落へのアニメーション効果の追加**

私たちは、[**addEffect()**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) メソッドを [**Sequence**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Sequence) と [**ISequence**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISequence) クラスに追加しました。このメソッドを使用すると、単一の段落にアニメーション効果を追加できます。このサンプルコードは、単一の段落にアニメーション効果を追加する方法を示しています:
```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // エフェクトを追加する段落を選択
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 選択された段落に Fly アニメーション効果を追加
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().
            addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **段落のアニメーション効果を取得**

段落に追加されたアニメーション効果を確認したい場合があります。たとえば、あるシナリオでは、別の段落やシェイプに同じ効果を適用したいので、段落内のアニメーション効果を取得したいことがあります。

Aspose.Slides for Android via Java を使用すると、テキストフレーム（シェイプ）内に含まれる段落に適用されたすべてのアニメーション効果を取得できます。このサンプルコードは、段落のアニメーション効果を取得する方法を示しています:
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    IAutoShape autoShape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs())
    {
        IEffect[] effects = sequence.getEffectsByParagraph(paragraph);

        if (effects.length > 0)
            System.out.println("Paragraph \"" + paragraph.getText() + "\" has " + effects[0].getType() + " effect.");
    }
} finally {
    pres.dispose();
}
```


## **FAQ**

**テキストアニメーションはスライド遷移とどのように違い、組み合わせて使用できますか？**

テキストアニメーションはスライド上のオブジェクトの動作を時間軸で制御し、[transitions](/slides/ja/androidjava/slide-transition/) はスライド間の切り替え方法を制御します。両者は独立しており、同時に使用できます。再生順序はアニメーションタイムラインと遷移設定によって決まります。

**テキストアニメーションは PDF や画像にエクスポートすると保持されますか？**

保持されません。PDF やラスタ画像は静的なため、スライドの単一状態しか表示されません。動きを残したい場合は、[video](/slides/ja/androidjava/convert-powerpoint-to-video/) または [HTML](/slides/ja/androidjava/export-to-html5/) 形式でエクスポートしてください。

**テキストアニメーションはレイアウトやスライドマスターでも機能しますか？**

レイアウト／マスターオブジェクトに適用された効果はスライドに継承されますが、タイミングやスライドレベルのアニメーションとの相互作用は最終的なスライド上のシーケンスに依存します。