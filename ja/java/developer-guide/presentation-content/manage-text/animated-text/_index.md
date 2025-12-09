---
title: JavaでPowerPointテキストをアニメーション化
linktitle: アニメーションテキスト
type: docs
weight: 60
url: /ja/java/animated-text/
keywords:
- アニメーションテキスト
- テキストアニメーション
- アニメーション段落
- 段落アニメーション
- アニメーション効果
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint および OpenDocument のプレゼンテーションで動的なアニメーションテキストを作成し、わかりやすく最適化された Java コード例を提供します。"
---

## **段落にアニメーション効果を追加する**

We added the [**addEffect()**](https://reference.aspose.com/slides/java/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) method to the [**Sequence**](https://reference.aspose.com/slides/java/com.aspose.slides/Sequence) and [**ISequence**](https://reference.aspose.com/slides/java/com.aspose.slides/ISequence) classes. This method allows you to add animation effects to a single paragraph. This sample code shows you how to add an animation effect to a single paragraph:
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


## **段落のアニメーション効果を取得する**

You may decide to find out the animation effects added to a paragraph—for example, in one scenario, you want to get the animation effects in a paragraph because you plan to apply those effects to another paragraph or shape.

Aspose.Slides for Java allows you to get all the animation effects applied to paragraphs contained in a text frame (shape). This sample code shows you how to get the animation effects in a paragraph:
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

**テキストアニメーションはスライドトランジションとどのように異なり、組み合わせて使用できますか？**

Text animations control object behavior over time on a slide, while [トランジション](/slides/ja/java/slide-transition/) control how slides change. They’re independent and can be used together; playback order is governed by the animation timeline and the transition settings.

**テキストアニメーションは PDF や画像にエクスポートしたときに保持されますか？**

No. PDF and raster images are static, so you’ll see a single state of the slide without motion. To keep movement, use [ビデオ](/slides/ja/java/convert-powerpoint-to-video/) or [HTML](/slides/ja/java/export-to-html5/) export.

**テキストアニメーションはレイアウトやスライドマスターでも機能しますか？**

Effects applied to layout/master objects are inherited by slides, but their timing and interaction with slide-level animations depend on the final sequence on the slide.