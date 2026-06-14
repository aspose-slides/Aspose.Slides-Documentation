---
title: 投影片轉場
type: docs
weight: 110
url: /zh-hant/php-java/examples/elements/slide-transition/
keywords:
- 投影片轉場
- 新增投影片轉場
- 取得投影片轉場
- 移除投影片轉場
- 轉場持續時間
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "在 PHP 中使用 Aspose.Slides 控制投影片轉場：選擇類型、速度、音效與時間，以完善 PPT、PPTX 與 ODP 簡報。"
---
示範如何使用 **Aspose.Slides for PHP via Java** 套用投影片轉場效果與時間設定。

## **新增投影片轉場**

將淡入轉場效果套用至第一張投影片。

```php
function addSlideTransition() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 套用淡入轉場.
        $slide->getSlideShowTransition()->setType(TransitionType::Fade);

        $presentation->save("slide_transition.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **取得投影片轉場**

讀取指派給投影片的轉場類型。

```php
function accessSlideTransition() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 取得轉場類型.
        $type = $slide->getSlideShowTransition()->getType();
    } finally {
        $presentation->dispose();
    }
}
```

## **移除投影片轉場**

將類型設為 `None` 以清除所有轉場效果。

```php
function removeSlideTransition() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 移除轉場，將類型設為無.
        $slide->getSlideShowTransition()->setType(TransitionType::None);

        $presentation->save("slide_transition_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **設定轉場持續時間**

指定投影片在自動前進前顯示的持續時間。

```php
function setTransitionDuration() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getSlideShowTransition()->setAdvanceOnClick(true);
        $slide->getSlideShowTransition()->setAdvanceAfterTime(2000); // 以毫秒為單位.

        $presentation->save("slide_transition_duration.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```