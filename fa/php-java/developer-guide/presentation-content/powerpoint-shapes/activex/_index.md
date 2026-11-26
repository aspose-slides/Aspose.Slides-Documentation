---
title: "مدیریت کنترل‌های ActiveX در ارائه‌ها با استفاده از PHP"
linktitle: "ActiveX"
type: docs
weight: 80
url: /fa/php-java/activex/
keywords:
- ActiveX
- کنترل ActiveX
- مدیریت ActiveX
- افزودن ActiveX
- تغییر ActiveX
- پخش‌کننده رسانه
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "ویرایش جعبه‌های متن و دکمه‌های ActiveX، به‌روزرسانی پیش‌نمایش کنترل‌ها، و استفاده مجدد از کنترل Windows Media Player در ارائه‌های PowerPoint با Aspose.Slides برای PHP از طریق Java."
---
## **معرفی**

کنترل‌های ActiveX عناصر تعاملی مانند جعبه‌های متن، دکمه‌های فرمان و پخش‌کننده‌های رسانه‌ای را به یک اسلاید PowerPoint می‌دهند. Aspose.Slides برای PHP از طریق Java کنترل‌های یک اسلاید را از طریق [BaseSlide::getControls](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getControls) فراهم می‌کند. از این مجموعه برای ویرایش یک کنترل، جابه‌جا کردن آن در اسلاید یا حذف آن استفاده کنید.

## **لیست کنترل‌های ActiveX و ویژگی‌های ذخیره‌شده آن‌ها**

برای بررسی یک قالب ناشناخته، آن را برای خواندن باز کنید و از طریق کنترل‌های هر اسلاید عبور کنید. مثال شماره اسلاید، نام کنترل، [getClassId](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getClassId)، و هر جفت کلید‑مقدار در [getProperties](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getProperties) را گزارش می‌دهد. ارائه را بدون فعال‌سازی کنترل‌ها، فراخوانی رویدادها یا ماکروها، تغییر مقادیر یا ذخیره‌سازی فایل می‌خواند.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("ActiveX.pptm");
try {
    $slides = $presentation->getSlides();
    for ($i = 0; $i < java_values($slides->size()); $i++) {
        $controls = $slides->get_Item($i)->getControls();
        for ($j = 0; $j < java_values($controls->size()); $j++) {
            $control = $controls->get_Item($j);
            printf("Slide %d | %s | %s\n", $i + 1, $control->getName(), $control->getClassId());
            $properties = $control->getProperties();
            if (java_is_null($properties)) {
                echo "  Properties unavailable\n";
                continue;
            }
            if (java_values($properties->getCount()) === 0) {
                echo "  []\n";
                continue;
            }
            $names = $properties->getNamesOfProperties()->iterator();
            while (java_values($names->hasNext())) {
                $name = $names->next();
                printf("  %s = %s\n", $name, $properties->get_Item($name));
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

خروجی انتخاب‌شده از `ActiveX.pptm` یک جعبه متن و یک دکمه فرمان را نشان می‌دهد.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

یک مجموعه ویژگی خالی به شکل `[]` نمایش داده می‌شود. برای کنترل‌هایی که ذخیره‌سازی باینری استفاده می‌کنند، [getProperties](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getProperties) می‌تواند `null` برگرداند که به صورت `Properties unavailable` نشان داده می‌شود. اگر فقط به نام‌ها نیاز دارید، پس از بررسی مقدار null از [getNamesOfProperties](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) استفاده کنید. گزارش ویژگی‌های موجود در ارائه را فهرست می‌کند. یک کنترل ممکن است در زمان اجرا ویژگی‌های اضافی داشته باشد.

## **تغییر کنترل‌های ActiveX**

این مثال یک ارائه با ماکرو فعال انتظار دارد که در اسلاید اول یک جعبه متن به نام `TextBox1` و یک دکمه فرمان به نام `CommandButton1` داشته باشد. از [control properties collection](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/) برای تغییر مقدار جعبه متن و عنوان دکمه استفاده می‌کند. هر کنترل همچنین یک پیش‌نمایش ثابت دارد که PowerPoint می‌تواند قبل از فعال‌سازی آن نمایش دهد. برای هر کنترل یک فایل PNG ارائه دهید که متن و ظاهر به‌روز شده را نشان می‌دهد. مثال این تصاویر را از طریق [Control::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getSubstitutePictureFormat) اختصاص می‌دهد.

مثال هر کنترل در اسلاید اول را 100 نقطه به سمت پایین حرکت می‌دهد با تنظیم قاب آن با [Control::setFrame](https://reference.aspose.com/slides/php-java/aspose.slides/control/#setFrame). ارائه ویرایش‌شده را در فرمت PPTM ذخیره می‌کند، سپس با استفاده از [ControlCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/controlcollection/#clear) یک نسخه دوم بدون هیچ‌یک از کنترل‌های ActiveX آن اسلاید ذخیره می‌کند.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeFrame;

$presentation = new Presentation("ActiveX.pptm");
try {
    $controls = $presentation->getSlides()->get_Item(0)->getControls();
    $textBox = null;
    $button = null;
    for ($j = 0; $j < java_values($controls->size()); $j++) {
        $control = $controls->get_Item($j);
        $name = (string) $control->getName();
        if ($name === "TextBox1") {
            $textBox = $control;
        } elseif ($name === "CommandButton1") {
            $button = $control;
        }
    }
    if ($textBox === null || $button === null || java_is_null($textBox->getProperties()) || java_is_null($button->getProperties())) {
        echo "The first slide must contain both named controls with editable properties.\n";
        return;
    }

    foreach ([[$textBox, "text-box-preview.png"], [$button, "button-preview.png"]] as [$control, $path]) {
        $image = Images::fromFile($path);
        try {
            $preview = $presentation->getImages()->addImage($image);
            $control->getSubstitutePictureFormat()->getPicture()->setImage($preview);
        } finally {
            $image->dispose();
        }
    }
    $textBox->getProperties()->set_Item("Value", "Changed text");
    $button->getProperties()->set_Item("Caption", "Show message");

    for ($j = 0; $j < java_values($controls->size()); $j++) {
        $control = $controls->get_Item($j);
        $frame = $control->getFrame();
        $newY = java_values($frame->getY()) + 100;
        $moved = new ShapeFrame($frame->getX(), $newY, $frame->getWidth(), $frame->getHeight(), $frame->getFlipH(), $frame->getFlipV(), $frame->getRotation());
        $control->setFrame($moved);
    }
    $presentation->save("edited-controls.pptm", SaveFormat::Pptm);

    $controls->clear();
    $presentation->save("removed-controls.pptm", SaveFormat::Pptm);
} finally {
    $presentation->dispose();
}
```

## **اضافه کردن یک کنترل Media Player ActiveX**

برای استفاده مجدد از یک کنترل Windows Media Player پیکربندی‌شده، با قالبی شروع کنید که اسلاید اول آن شامل یک پخش‌کننده به نام `WindowsMediaPlayer1` باشد. [SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/#addClone) کل اسلاید را به یک ارائه جدید کپی می‌کند. مثال `URL` پخش‌کننده را در [properties collection](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/) تنظیم می‌کند و اسلاید کپی‌شده را به‌عنوان تنها اسلاید خروجی ذخیره می‌نماید. ویدیو به‌صورت خارجی باقی می‌ماند، بنابراین مسیری را انتخاب کنید که پخش‌کننده در حین پخش به آن دسترسی داشته باشد.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$template = new Presentation("template.pptx");
try {
    $presentation = new Presentation();
    try {
        $slides = $presentation->getSlides();
        $sourceSlide = $template->getSlides()->get_Item(0);
        $slide = $slides->addClone($sourceSlide);
        $player = null;
        $controls = $slide->getControls();
        for ($j = 0; $j < java_values($controls->size()); $j++) {
            $control = $controls->get_Item($j);
            if ((string) $control->getName() === "WindowsMediaPlayer1") {
                $player = $control;
                break;
            }
        }
        if ($player === null || java_is_null($player->getProperties())) {
            echo "The template slide must contain a named media player with editable properties.\n";
            return;
        }
        $player->getProperties()->set_Item("URL", "Wildlife.mp4");
        $slides->removeAt(0);
        $presentation->save("linked-video.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
} finally {
    $template->dispose();
}
```

## **سوالات متداول**

**آیا Aspose.Slides می‌تواند کنترل‌های ActiveX را بدون اجرا حفظ کند؟**

بله. Aspose.Slides می‌تواند کنترل‌ها را بخواند و ذخیره کند، از جمله ویژگی‌ها و موقعیت‌های آن‌ها، بدون اینکه آن‌ها را فعال کند.

**کنترل‌های ActiveX چگونه با اشیاء OLE متفاوت هستند؟**

کنترل‌های ActiveX به کاربر امکان تعامل با اسلاید را می‌دهند، برای مثال با وارد کردن متن یا کلیک کردن یک دکمه. یک [شیء OLE](/slides/fa/php-java/manage-ole/) اجازه می‌دهد اسلاید محتوایی را که توسط برنامه دیگری مدیریت می‌شود، مانند یک کاربرگ Excel، در خود داشته یا به آن پیوند دهد.

**آیا رویدادهای ActiveX پس از ذخیره ارائه با Aspose.Slides هنوز ماکروهای VBA را فعال می‌کنند؟**

ارائه را در قالب ماکرو فعال مانند PPTM ذخیره کنید تا پروژه VBA آن حفظ شود. PowerPoint برای Windows می‌تواند هندلرهای رویداد موجود را اجرا کند زمانی که تنظیمات امنیتی آن اجازه استفاده از هر دو کنترل ActiveX و ماکروها را می‌دهد.