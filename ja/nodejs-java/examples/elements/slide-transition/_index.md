---
title: スライド トランジション
type: docs
weight: 110
url: /ja/nodejs-java/examples/elements/slide-transition/
keywords:
- コード例
- スライド トランジション
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js におけるスライド トランジションをマスターし、PPT、PPTX、ODP プレゼンテーションの例とともに、効果と期間の追加、カスタマイズ、シーケンスを行います。"
---
この記事では、**Aspose.Slides for Node.js via Java** を使用したスライドのトランジション効果とタイミングの適用方法を示します。

## **スライド トランジションの追加**

最初のスライドにフェード トランジション効果を適用します。

```js
function addSlideTransition() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // フェード トランジションを適用します。
        slide.getSlideShowTransition().setType(aspose.slides.TransitionType.Fade);

        presentation.save("slide_transition.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **スライド トランジションへのアクセス**

スライドに現在割り当てられているトランジションの種類を読み取ります。

```js
function accessSlideTransition() {
    let presentation = new aspose.slides.Presentation("slide_transition.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // トランジションの種類にアクセスします。
        let type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **スライド トランジションの削除**

タイプを `None` に設定して、すべてのトランジション効果をクリアします。

```js
function removeSlideTransition() {
    let presentation = new aspose.slides.Presentation("slide_transition.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // none を設定してトランジションを削除します。
        slide.getSlideShowTransition().setType(aspose.slides.TransitionType.None);

        presentation.save("slide_transition_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **トランジションの期間を設定**

スライドが自動的に次に進むまでの表示時間を指定します。

```js
function setTransitionDuration() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setAdvanceOnClick(true);
        slide.getSlideShowTransition().setAdvanceAfterTime(2000); // ミリ秒単位です。

        presentation.save("slide_transition_duration.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```