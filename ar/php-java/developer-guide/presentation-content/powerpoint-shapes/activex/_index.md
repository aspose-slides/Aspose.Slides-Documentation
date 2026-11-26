---
title: إدارة عناصر التحكم ActiveX في العروض التقديمية باستخدام PHP
linktitle: ActiveX
type: docs
weight: 80
url: /ar/php-java/activex/
keywords:
- ActiveX
- عنصر تحكم ActiveX
- إدارة ActiveX
- إضافة ActiveX
- تعديل ActiveX
- مشغل وسائط
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تحرير مربعات النص وأزرار ActiveX، وتحديث معاينات عناصر التحكم، وإعادة استخدام عنصر تحكم Windows Media Player في عروض PowerPoint التقديمية باستخدام Aspose.Slides للـ PHP عبر Java."
---
## **المقدمة**

تمنح عناصر التحكم ActiveX شريحة PowerPoint عناصر تفاعلية مثل مربعي النص وأزرار الأوامر ومشغلات الوسائط. تتيح Aspose.Slides for PHP عبر Java وصول عناصر التحكم في الشريحة من خلال [BaseSlide::getControls](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getControls). استخدم هذا التجميع لتحرير عنصر تحكم أو تحريكه على الشريحة أو إزالته.

## **قائمة عناصر التحكم ActiveX وخصائصها المخزنة**

لتفحص قالب غير مألوف، افتحه للقراءة وتكرّر عبر عناصر التحكم في كل شريحة. التقرير المثال يعرض رقم الشريحة، اسم عنصر التحكم، [getClassId](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getClassId)، وكل زوج مفتاح‑قيمة في [getProperties](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getProperties). يقرأ العرض التقديمي دون تفعيل عناصر التحكم أو استدعاء الأحداث أو الماكرو أو تغيير القيم أو حفظ الملف.

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

يعرض الناتج المختار من `ActiveX.pptm` مربع نص وزر أمر.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

تظهر مجموعة الخصائص الفارغة كـ `[]`. بالنسبة لعناصر التحكم التي تستخدم التخزين الثنائي، يمكن أن تُعيد [getProperties](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getProperties) قيمة `null`، وتُعرض كـ `Properties unavailable`. إذا كنت تحتاج فقط إلى الأسماء، استخدم [getNamesOfProperties](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) بعد فحص الـ `null`. يسرد التقرير الخصائص المتوفرة من العرض التقديمي. قد يدعم عنصر التحكم خصائص إضافية في وقت التشغيل.

## **تعديل عناصر التحكم ActiveX**

يتوقع المثال عرضًا تقديميًا مُمكّنًا للماكرو يحتوي على مربع نص يُدعى `TextBox1` وزر أمر يُدعى `CommandButton1` في الشريحة الأولى. يستخدم [control properties collection](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/) لتغيير قيمة مربع النص وعنوان الزر. كل عنصر تحكم لديه أيضًا معاينة ثابتة يمكن لـ PowerPoint عرضها قبل التفعيل. زوّد كل عنصر PNG يُظهر النص والمظهر المحدّث. يَعيّن المثال هذه الصور عبر [Control::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getSubstitutePictureFormat).

يُنقل المثال كل عنصر تحكم في الشريحة الأولى إلى الأسفل بمقدار 100 نقطة عن طريق ضبط إطاره باستخدام [Control::setFrame](https://reference.aspose.com/slides/php-java/aspose.slides/control/#setFrame). يحفظ العرض المُحرّر بتنسيق PPTM، ثم يستخدم [ControlCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/controlcollection/#clear) لحفظ نسخة ثانية بإزالة جميع عناصر التحكم ActiveX من تلك الشريحة.

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

## **إضافة عنصر تحكم ActiveX مشغل وسائط**

لإعادة استخدام مشغل Windows Media Player مُكوّن، ابدأ بقالب يحتوي الشريحة الأولى على مشغل يُدعى `WindowsMediaPlayer1`. ينسخ [SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/#addClone) الشريحة بالكامل إلى عرض تقديمي جديد. يحدد المثال عنوان `URL` للمشغل في [properties collection](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/) ويحفظ الشريحة المستنسخة كالشريحة الوحيدة في النتيجة. يبقى الفيديو خارجيًا، لذا اختر مسارًا يمكن للمشغل الوصول إليه أثناء التشغيل.

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

## **الأسئلة المتكررة**

**هل يمكن لـ Aspose.Slides حفظ عناصر التحكم ActiveX دون تشغيلها؟**

نعم. يمكن لـ Aspose.Slides قراءة وحفظ عناصر التحكم، بما في ذلك خصائصها ومواقعها، دون تفعيلها.

**كيف تختلف عناصر التحكم ActiveX عن كائنات OLE؟**

تسمح عناصر التحكم ActiveX للمستخدمين بالتفاعل مع الشريحة، مثل إدخال نص أو النقر على زر. يتيح [كائن OLE](/slides/ar/php-java/manage-ole/) للشريحة احتواء أو ربط محتوى تُديره تطبيقات أخرى، مثل ورقة عمل Excel.

**هل ستظل أحداث ActiveX تُطلق ماكرو VBA بعد أن أحفظ عرضًا تقديميًا باستخدام Aspose.Slides؟**

احفظ العرض التقديمي بتنسيق يدعم الماكرو مثل PPTM للاحتفاظ بمشروع VBA الخاص به. يمكن لـ PowerPoint لنظام Windows تشغيل معالجات الأحداث الحالية عندما تسمح إعدادات الأمان بتمكين كل من عناصر التحكم ActiveX والماكرو.