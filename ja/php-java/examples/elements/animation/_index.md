---
title: アニメーション
type: docs
weight: 100
url: /ja/php-java/examples/elements/animation/
keywords:
- アニメーション
- アニメーションの追加
- アニメーションへのアクセス
- アニメーションの削除
- アニメーションシーケンス
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides を使用した PHP のスライド アニメーションをマスターし、効果、タイミング、トリガーを追加、編集、削除して、PPT、PPTX、ODP で動的なプレゼンテーションを作成します。"
---
**Aspose.Slides for PHP via Java** を使用して、シンプルなアニメーションの作成とシーケンス管理の方法を示します。

## **アニメーションを追加**
長方形シェイプを作成し、クリックでトリガーされるフェードイン効果を適用します。

```php
function addAnimation() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

        // フェードイン効果。
        $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

        $presentation->save("animation.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **アニメーションにアクセス**
スライドタイムラインから最初のアニメーション効果を取得します。

```php
function accessAnimation() {
    $presentation = new Presentation("animation.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 最初のアニメーション効果にアクセスします。
        $effect = $slide->getTimeline()->getMainSequence()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **アニメーションを削除**
シーケンスからアニメーション効果を削除します。

```php
function removeAnimation() {
    $presentation = new Presentation("animation.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $effect = $slide->getTimeline()->getMainSequence()->get_Item(0);

        // エフェクトを削除します。
        $slide->getTimeline()->getMainSequence()->remove($effect);

        $presentation->save("animation_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **アニメーションのシーケンス**
複数の効果を追加し、アニメーションが発生する順序を実演します。

```php
function sequenceAnimations() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);
        $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 200, 50, 100, 100);

        $sequence = $slide->getTimeline()->getMainSequence();
        $sequence->addEffect($shape1, EffectType::Fly, EffectSubtype::Bottom, EffectTriggerType::OnClick);
        $sequence->addEffect($shape2, EffectType::Fly, EffectSubtype::Bottom, EffectTriggerType::OnClick);

        $presentation->save("animation_sequence.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```