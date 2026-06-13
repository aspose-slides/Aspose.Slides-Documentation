---
title: "انتقال اسلاید"
type: docs
weight: 110
url: /fa/php-java/examples/elements/slide-transition/
keywords:
  - "انتقال اسلاید"
  - "افزودن انتقال اسلاید"
  - "دسترسی به انتقال اسلاید"
  - "حذف انتقال اسلاید"
  - "مدت زمان انتقال"
  - "نمونه‌های کد"
  - "PowerPoint"
  - "OpenDocument"
  - "ارائه"
  - "PHP"
  - "Aspose.Slides"
description: "انتقال اسلایدها را در PHP با Aspose.Slides کنترل کنید: انواع، سرعت، صدا و زمان‌بندی را انتخاب کنید تا ارائه‌ها را در قالب‌های PPT، PPTX و ODP بهبود دهید."
---
نمایش اعمال اثرات و زمانبندی‌های انتقال اسلاید با **Aspose.Slides for PHP via Java**.

## **افزودن انتقال اسلاید**

یک اثر انتقال محو (fade) را بر روی اسلاید اول اعمال کنید.

```php
function addSlideTransition() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // یک انتقال محو اعمال کنید.
        $slide->getSlideShowTransition()->setType(TransitionType::Fade);

        $presentation->save("slide_transition.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **دسترسی به انتقال اسلاید**

نوع انتقال اختصاص داده شده به یک اسلاید را بخوانید.

```php
function accessSlideTransition() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // دسترسی به نوع انتقال.
        $type = $slide->getSlideShowTransition()->getType();
    } finally {
        $presentation->dispose();
    }
}
```

## **حذف انتقال اسلاید**

تمام اثرهای انتقال را با تنظیم نوع به `None` پاک کنید.

```php
function removeSlideTransition() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // حذف انتقال با تنظیم به None.
        $slide->getSlideShowTransition()->setType(TransitionType::None);

        $presentation->save("slide_transition_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **تنظیم مدت زمان انتقال**

مشخص کنید اسلاید چه مدت نمایش داده شود قبل از پیشروی خودکار.

```php
function setTransitionDuration() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getSlideShowTransition()->setAdvanceOnClick(true);
        $slide->getSlideShowTransition()->setAdvanceAfterTime(2000); // به میلی‌ثانیه.

        $presentation->save("slide_transition_duration.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```