---
title: アニメーションテキスト
type: docs
weight: 60
url: /java/animated-text/
keywords: "PowerPointのアニメーションテキスト"
description: "JavaによるPowerPointのアニメーションテキスト"
---

## 段落にアニメーション効果を追加する

[**addEffect()**](https://reference.aspose.com/slides/java/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) メソッドが [**Sequence**](https://reference.aspose.com/slides/java/com.aspose.slides/Sequence) および [**ISequence**](https://reference.aspose.com/slides/java/com.aspose.slides/ISequence) クラスに追加されました。このメソッドを使用すると、単一の段落にアニメーション効果を追加できます。このサンプルコードは、単一の段落にアニメーション効果を追加する方法を示しています：

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

## 段落のアニメーション効果を取得する

段落に追加されたアニメーション効果を調べることを決定する場合があります。たとえば、1つのシナリオでは、別の段落や図形にこれらの効果を適用する計画があるため、段落にあるアニメーション効果を取得したいと考えています。

Aspose.Slides for Javaでは、テキストフレーム（図形）に含まれる段落に適用されたすべてのアニメーション効果を取得できます。このサンプルコードは、段落のアニメーション効果を取得する方法を示しています：

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    IAutoShape autoShape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs())
    {
        IEffect[] effects = sequence.getEffectsByParagraph(paragraph);

        if (effects.length > 0)
            System.out.println("段落 \"" + paragraph.getText() + "\" には " + effects[0].getType() + " 効果があります。");
    }
} finally {
    pres.dispose();
}
```