---
title: アニメーションテキスト
type: docs
weight: 60
url: /androidjava/animated-text/
keywords: "PowerPointのアニメーションテキスト"
description: "Javaを使用したPowerPointのアニメーションテキスト"
---

## 段落にアニメーション効果を追加する

我々は、[**addEffect()**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-)メソッドを[**Sequence**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Sequence)および[**ISequence**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISequence)クラスに追加しました。このメソッドを使用することで、単一の段落にアニメーション効果を追加することができます。このサンプルコードは、単一の段落にアニメーション効果を追加する方法を示しています：

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // 効果を追加する段落を選択
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 選択した段落にFlyアニメーション効果を追加
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().
            addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## 段落におけるアニメーション効果の取得

段落に追加されたアニメーション効果を確認することを決定するかもしれません。例えば、一つのシナリオでは、他の段落や図形にその効果を適用する予定があるため、段落のアニメーション効果を取得したいと思うかもしれません。

Aspose.Slides for Android via Javaでは、テキストフレーム（図形）に含まれる段落に適用されたすべてのアニメーション効果を取得できます。このサンプルコードは、段落におけるアニメーション効果を取得する方法を示しています：

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    IAutoShape autoShape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs())
    {
        IEffect[] effects = sequence.getEffectsByParagraph(paragraph);

        if (effects.length > 0)
            System.out.println("段落 \"" + paragraph.getText() + "\" は " + effects[0].getType() + " 効果を持っています。");
    }
} finally {
    pres.dispose();
}
```