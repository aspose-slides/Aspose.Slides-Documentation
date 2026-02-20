---
title: 幻灯片过渡
type: docs
weight: 110
url: /zh/php-java/examples/elements/slide-transition/
keywords:
- 幻灯片过渡
- 添加幻灯片过渡
- 访问幻灯片过渡
- 移除幻灯片过渡
- 过渡持续时间
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "在 PHP 中使用 Aspose.Slides 控制幻灯片过渡：选择类型、速度、声音和时间，以完善 PPT、PPTX 和 ODP 演示文稿。"
---
演示如何在 **Aspose.Slides for PHP via Java** 中应用幻灯片过渡效果和时间设置。

## **添加幻灯片过渡**

对第一张幻灯片应用淡入过渡效果。

```php
function addSlideTransition() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 应用淡入过渡。
        $slide->getSlideShowTransition()->setType(TransitionType::Fade);

        $presentation->save("slide_transition.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **获取幻灯片过渡**

读取分配给幻灯片的过渡类型。

```php
function accessSlideTransition() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 访问过渡类型。
        $type = $slide->getSlideShowTransition()->getType();
    } finally {
        $presentation->dispose();
    }
}
```

## **移除幻灯片过渡**

通过将类型设置为 `None` 来清除所有过渡效果。

```php
function removeSlideTransition() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 通过设置为 None 移除过渡。
        $slide->getSlideShowTransition()->setType(TransitionType::None);

        $presentation->save("slide_transition_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **设置过渡持续时间**

指定幻灯片在自动前进之前的显示时长。

```php
function setTransitionDuration() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getSlideShowTransition()->setAdvanceOnClick(true);
        $slide->getSlideShowTransition()->setAdvanceAfterTime(2000); // 以毫秒为单位。

        $presentation->save("slide_transition_duration.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```