---
title: スライドトランジション
type: docs
weight: 110
url: /ja/php-java/examples/elements/slide-transition/
keywords:
- スライドトランジション
- スライドトランジションの追加
- スライドトランジションにアクセス
- スライドトランジションの削除
- トランジション期間
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides を使用して PHP でスライドトランジションを制御し、タイプ、速度、サウンド、タイミングを選択して PPT、PPTX、ODP のプレゼンテーションを洗練させます。"
---
**Aspose.Slides for PHP via Java** を使用したスライドのトランジション効果とタイミングの適用を示します。

## **スライド トランジションを追加**
最初のスライドにフェード トランジション効果を適用します。

```php
function addSlideTransition() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // フェード トランジションを適用します。

        $presentation->save("slide_transition.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **スライド トランジションにアクセス**
スライドに割り当てられたトランジション タイプを読み取ります。

```php
function accessSlideTransition() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // トランジションのタイプにアクセスします。
        $type = $slide->getSlideShowTransition()->getType();
    } finally {
        $presentation->dispose();
    }
}
```

## **スライド トランジションを削除**
タイプを `None` に設定して、すべてのトランジション効果をクリアします。

```php
function removeSlideTransition() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // none に設定してトランジションを削除します。
        $slide->getSlideShowTransition()->setType(TransitionType::None);

        $presentation->save("slide_transition_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **トランジションの期間を設定**
スライドが自動的に次へ進むまでの表示時間を指定します。

```php
function setTransitionDuration() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getSlideShowTransition()->setAdvanceOnClick(true);
        $slide->getSlideShowTransition()->setAdvanceAfterTime(2000); // ミリ秒単位です。

        $presentation->save("slide_transition_duration.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```