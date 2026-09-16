---
title: إدارة روابط العرض التقديمي في PHP
linktitle: إدارة الروابط التشعبية
type: docs
weight: 20
url: /ar/php-java/manage-hyperlinks/
keywords:
- إضافة URL
- إضافة رابط تشعبي
- إنشاء رابط تشعبي
- تنسيق رابط تشعبي
- إزالة رابط تشعبي
- تحديث رابط تشعبي
- رابط تشعبي للنص
- رابط تشعبي للشريحة
- رابط تشعبي للشكل
- رابط تشعبي للصورة
- رابط تشعبي للفيديو
- رابط تشعبي قابل للتغيير
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "أضف، نمّق، حدّث، وأزل الروابط التشعبية في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides for PHP عبر Java، مع أمثلة PHP."
---
## **مقدمة**

يُربط الارتباط التشعبي محتوى العرض التقديمي بموقع ويب أو بموقع داخل العرض التقديمي نفسه. في PowerPoint، يخدم الارتباط التشعبي غرضين شائعين:

* فتح موقع ويب من النص أو الشكل أو إطار الوسائط.
* الانتقال إلى شريحة أخرى، على سبيل المثال من جدول المحتويات.

يتيح Aspose.Slides for PHP via Java إضافة هذه الروابط، والتحكم في مظهرها وصوتها، وتحديث خصائصها، وإزالتها. توضح الأمثلة أدناه كيفية العمل مع الروابط التشعبية على العناصر الفردية وكيفية الوصول إلى الروابط على مستوى العرض أو الشريحة أو إطار النص. تفترض أن جسر PHP/Java ومغلف Aspose.Slides PHP تم تهيئتهما. الأعضاء في API الذين لا يملكون صفحة مرجع PHP يربطون إلى API Java الأساسي.

{{% alert color="info" title="ملاحظة" %}}
يمكنك أيضًا تعديل العروض التقديمية باستخدام [محرر Aspose PowerPoint المجاني عبر الإنترنت](https://products.aspose.app/slides/ar/editor).
{{% /alert %}} 

## **إضافة روابط URL تشعبية**

يمكنك تعيين عنوان موقع ويب إلى نص أو شكل أو إطار وسائط. العنصر الذي تُعيّن إليه الارتباط التشعبي يحدد مساحة النقر: جزء النص يربط النص المحدد، بينما الشكل أو الإطار يربط كائن الشريحة.

### **إضافة روابط URL إلى النص**

لربط نص بموقع ويب، مرّر كائن [Hyperlink](https://reference.aspose.com/slides/ar/php-java/aspose.slides/hyperlink/) إلى طريقة [setHyperlinkClick](https://reference.aspose.com/slides/ar/php-java/aspose.slides/portionformat/sethyperlinkclick/) لجزء النص، كما هو موضح أدناه. يصبح ذلك الجزء من النص قابلًا للنقر فقط.

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $textShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
    $textShape->addTextFrame("Aspose: File Format APIs");
    $portionFormat = $textShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat->getHyperlinkClick()->setTooltip("Explore Aspose file format APIs");
    $portionFormat->setFontHeight(32);

    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **إضافة روابط URL إلى الأشكال وإطارات الوسائط**

لجعل الشكل أو الإطار قابلًا للنقر، نادِ طريقة [setHyperlinkClick](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/sethyperlinkclick/) الخاصة به. ينتمي الارتباط التشعبي إلى الكائن نفسه وليس إلى جزء نص داخله.

ينطبق نفس النهج على إطارات الصورة والصوت والفيديو: عيّن الارتباط التشعبي إلى الإطار ونادِ [setTooltip](https://reference.aspose.com/slides/ar/php-java/aspose.slides/hyperlink/settooltip/) إذا لزم الأمر.

المثال التالي يجعل مستطيلًا قابلًا للنقر:

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50);

    $shape->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $shape->getHyperlinkClick()->setTooltip("Explore Aspose file format APIs");

    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **استخدام الروابط التشعبية لإنشاء جدول محتويات**

تتيح الروابط التشعبية الداخلية للقارئ القفز من جدول المحتويات إلى شريحة محددة. يستخدم المثال التالي طريقة [setInternalHyperlinkClick](https://reference.aspose.com/slides/ar/php-java/aspose.slides/hyperlinkmanager/setinternalhyperlinkclick/) لربط نص “Page 2” في الشريحة الأولى بالشريحة الثانية.

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $secondSlide = $presentation->getSlides()->addEmptySlide($firstSlide->getLayoutSlide());

    $tableOfContents = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 300, 100);
    $tableOfContents->getFillFormat()->setFillType(FillType::NoFill);
    $tableOfContents->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $tableOfContents->getTextFrame()->getParagraphs()->clear();

    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $paragraph->setText("Title of slide 2 .......... ");

    $linkPortion = new Portion();
    $linkPortion->setText("Page 2");
    $linkPortion->getPortionFormat()->getHyperlinkManager()->setInternalHyperlinkClick($secondSlide);

    $paragraph->getPortions()->add($linkPortion);
    $tableOfContents->getTextFrame()->getParagraphs()->add($paragraph);

    $presentation->save("link_to_slide.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تنسيق الروابط التشعبية**

### **اللون**

تحدّد طريقة [setColorSource](https://reference.aspose.com/slides/ar/php-java/aspose.slides/hyperlink/setcolorsource/) لكائن [Hyperlink](https://reference.aspose.com/slides/ar/php-java/aspose.slides/hyperlink/) ما إذا كان الارتباط التشعبي يستخدم لون الارتباط التشعبي للعرض التقديمي أو تنسيق جزء النص. لتطبيق لون نص مخصص، اختر [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/hyperlinkcolorsource/) واضبط لون تعبئة الجزء. تم تقديم هذه الميزة في PowerPoint 2019؛ الإصدارات الأقدم لا تطبق هذا الإعداد.

المثال التالي يضيف رابطين نصيين إلى نفس الشريحة. الأول يستخدم تعبئة نص حمراء، بينما الثاني يحتفظ باللون الافتراضي للارتباط التشعبي.

```php
use aspose\slides\FillType;
use aspose\slides\Hyperlink;
use aspose\slides\HyperlinkColorSource;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $coloredShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 450, 50, false);
    $coloredShape->addTextFrame("This hyperlink uses a custom color.");
    $coloredPortionFormat = $coloredShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $coloredPortionFormat->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $coloredPortionFormat->getHyperlinkClick()->setColorSource(HyperlinkColorSource::PortionFormat);
    $coloredPortionFormat->getFillFormat()->setFillType(FillType::Solid);
    $coloredPortionFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $defaultShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 450, 50, false);
    $defaultShape->addTextFrame("This hyperlink uses the default color.");
    $defaultShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

    $presentation->save("presentation-out-hyperlink.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```
### **الصوت**

يمكن للارتباط التشعبي تشغيل صوت عند تفعيلها أو إيقاف صوت قيد التشغيل بالفعل. استخدم الطرق التالية لتكوين هذه السلوكيات:

- [Hyperlink::setSound](https://reference.aspose.com/slides/ar/php-java/aspose.slides/hyperlink/setsound/) يحدد الصوت المرتبط بالارتباط التشعبي.
- [Hyperlink::setStopSoundOnClick](https://reference.aspose.com/slides/ar/php-java/aspose.slides/hyperlink/setstopsoundonclick/) يتحكم فيما إذا كان تفعيل الارتباط التشعبي يوقف الصوت السابق.

#### **إضافة صوت للارتباط التشعبي**

المثال التالي يحمل الملف `sampleaudio.wav` ويربطه بزر في الشريحة الأولى. النقر على الزر يشغل الصوت وينتقل إلى الشريحة التالية. الشكل الثاني في تلك الشريحة يوقف الصوت السابق عند النقر، دون تنفيذ عملية انتقال.

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $audioFile = new Java("java.io.File", "sampleaudio.wav");
    $audioPath = $audioFile->toPath();
    $audioData = java("java.nio.file.Files")->readAllBytes($audioPath);
    $hyperlinkSound = $presentation->getAudios()->addAudio($audioData);

    $firstSlide = $presentation->getSlides()->get_Item(0);

    $playButton = $firstSlide->getShapes()->addAutoShape(ShapeType::SoundButton, 100, 100, 100, 50);
    $playButton->setHyperlinkClick(Hyperlink::getNextSlide());

    if (!java_values($playButton->getHyperlinkClick()->getStopSoundOnClick()) && java_is_null($playButton->getHyperlinkClick()->getSound()))
    {
        $playButton->getHyperlinkClick()->setSound($hyperlinkSound);
    }

    $secondSlide = $presentation->getSlides()->addEmptySlide($firstSlide->getLayoutSlide());

    $stopButton = $secondSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 100, 50);
    $stopButton->setHyperlinkClick(Hyperlink::getNoAction());

    $stopButton->getHyperlinkClick()->setStopSoundOnClick(true);

    $presentation->save("hyperlink-sound.pptx", SaveFormat::Pptx);
} catch (JavaException $exception) {
    echo "Unable to read the audio file: " . $exception->getMessage() . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

#### **استخراج صوت الارتباط التشعبي**

المثال التالي يفتح العرض التقديمي المُنشأ أعلاه ويقرأ صوت الارتباط التشعبي للشكل الأول إلى الذاكرة عبر [getSound](https://reference.aspose.com/slides/ar/php-java/aspose.slides/hyperlink/getsound/) و[getBinaryData](https://reference.aspose.com/slides/ar/php-java/aspose.slides/audio/getbinarydata/).

```php
use aspose\slides\Presentation;

$presentation = new Presentation("hyperlink-sound.pptx");
try {
    if (java_values($presentation->getSlides()->size()) > 0 && java_values($presentation->getSlides()->get_Item(0)->getShapes()->size()) > 0) {
        $hyperlink = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getHyperlinkClick();
        $sound = java_is_null($hyperlink) ? null : $hyperlink->getSound();
        if (!java_is_null($sound)) {
            $audioData = $sound->getBinaryData();
            echo "Extracted " . strlen(java_values($audioData)) . " bytes of hyperlink audio." . PHP_EOL;
        } else {
            echo "The first shape has no hyperlink sound." . PHP_EOL;
        }
    } else {
        echo "The presentation has no first slide or shape to inspect." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **التلميح وإعدادات التفاعل**

يمكنك نداء طرق [Hyperlink](https://reference.aspose.com/slides/ar/php-java/aspose.slides/hyperlink/) التالية بعد تعيين رابط تشعبي إلى نص أو شكل:

- [setTooltip](https://reference.aspose.com/slides/ar/php-java/aspose.slides/hyperlink/settooltip/) يحدد النص الذي يمكن للمستعرض عرضه كتلميح للارتباط.
- [setTargetFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/hyperlink/settargetframe/) يحدد إطار الهدف داخل مجموعة إطارات HTML الأم، إذا كان ذلك مناسبًا.
- [setHistory](https://reference.aspose.com/slides/ar/php-java/aspose.slides/hyperlink/sethistory/) يتحكم فيما إذا كان تفعيل الارتباط يضيف هدفه إلى قائمة الروابط المشاهدة.
- [setHighlightClick](https://reference.aspose.com/slides/ar/php-java/aspose.slides/hyperlink/sethighlightclick/) يتحكم فيما إذا كان يتم تمييز الارتباط التشعبي عند النقر.

## **إزالة الروابط التشعبية من العروض التقديمية**

استخدم [getAnyHyperlinks](https://reference.aspose.com/slides/ar/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) لجمع حاويات الروابط، بما في ذلك روابط أجزاء النص، قبل تعديلها. يزيل المثال التالي كلا نوعي التفعيل من الشريحة الأولى. لإزالة نوع واحد فقط، نادِ فقط [removeHyperlinkClick](https://reference.aspose.com/slides/ar/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) أو [removeHyperlinkMouseOver](https://reference.aspose.com/slides/ar/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/)؛ إزالة إجراء النقر لا يزيل نظيره عند مرور الفأرة.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    if (java_values($presentation->getSlides()->size()) > 0) {
        $containers = [];
        foreach ($presentation->getSlides()->get_Item(0)->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
            $containers[] = $container;
        }
        foreach ($containers as $container) {
            $container->getHyperlinkManager()->removeHyperlinkClick();
            $container->getHyperlinkManager()->removeHyperlinkMouseOver();
        }
        $presentation->save("pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
    } else {
        echo "The presentation has no slides to process." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

للإزالة غير المشروطة، تقوم الطريقة [removeAllHyperlinks](https://reference.aspose.com/slides/ar/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) بحذف كلا نوعي التفعيل في النطاق المحدد في نداء واحد. للتنظيف الانتقائي وتغطية الماسترز والتصميمات والملاحظات، راجع القسم [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **بناء جرد كامل للروابط التشعبية**

قبل توزيع العرض التقديمي، قم بجرد الإجراءات التفاعلية بالإضافة إلى الروابط الويب. تُعيد طريقة [getAnyHyperlinks](https://reference.aspose.com/slides/ar/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) كائنات [IHyperlinkContainer](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ihyperlinkcontainer/)، وليس قائمة مسطحة من سلاسل URL. افحص كل من [getHyperlinkClick](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) و[getHyperlinkMouseOver](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) على كل حاوية. هما مستقلان: يمكن لنفس الحاوية أن تكشف عن كلا الإجراءين، لذا يحتاج التقرير الكامل إلى صفين كحد أقصى لكل حاوية.

قد يفتقد الفحص على مستوى الشكل الروابط المرفقة بأجزاء النص. استعلم النطاق المناسب بدلاً من ذلك، واحتفظ بالحاويات المعادة لتتمكن لاحقًا من تحديثها أو إزالتها.

### **استعلام نطاقات العرض، الشريحة، وإطار النص**

تتوفر الفئة [HyperlinkQueries](https://reference.aspose.com/slides/ar/php-java/aspose.slides/hyperlinkqueries/) من خلال [Presentation::getHyperlinkQueries](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/gethyperlinkqueries/)، [IBaseSlide::getHyperlinkQueries](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--)، و[TextFrame::getHyperlinkQueries](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/gethyperlinkqueries/). يدعم كل نطاق نفس الاستعلامات:

- [getHyperlinkClicks](https://reference.aspose.com/slides/ar/php-java/aspose.slides/hyperlinkqueries/gethyperlinkclicks/) يعيد الحاويات ذات إجراء النقر.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/ar/php-java/aspose.slides/hyperlinkqueries/gethyperlinkmouseovers/) يعيد الحاويات ذات إجراء مرور الفأرة.
- [getAnyHyperlinks](https://reference.aspose.com/slides/ar/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) يعيد الحاويات التي تمتلك أحد الإجراءين أو كليهما.

المثال التالي ينشئ الملف `hyperlink-audit-input.pptx` بوجود رابط خارجي للنقر، ورابط ملف عند مرور الفأرة، وتنقل داخلي إلى شريحة، ورابط نص عند مرور الفأرة، وإجراء ماكرو. لا يُنفّذ أيًا من هذه الإجراءات. تعمل الاستعلامات الثلاثة نفسها في كل نطاق؛ الأعداد تشير إلى الحاويات، وليس إلى مجموع الإجراءات. يستثني نطاق إطار النص الروابط الخاصة بالشكل المُحاط.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function printQueryCounts($scope, $queries) {
    $clickCount = java_values($queries->getHyperlinkClicks()->size());
    $mouseOverCount = java_values($queries->getHyperlinkMouseOvers()->size());
    $anyCount = java_values($queries->getAnyHyperlinks()->size());
    echo "$scope: click=$clickCount, mouse-over=$mouseOverCount, any=$anyCount" . PHP_EOL;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $destination = $presentation->getSlides()->addEmptySlide($slide->getLayoutSlide());
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 60);
    $shape->getTextFrame()->setText("Click the text to go to slide 2");
    $shape->getHyperlinkManager()->setExternalHyperlinkClick("https://example.com/");
    $shape->getHyperlinkClick()->setTooltip("Public website");
    $shape->getHyperlinkManager()->setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    $portionFormat = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat->getHyperlinkManager()->setInternalHyperlinkClick($destination);
    $portionFormat->getHyperlinkManager()->setExternalHyperlinkMouseOver("https://example.com/help");
    $macroButton = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 120, 200, 60);
    $macroButton->getHyperlinkManager()->setMacroHyperlinkClick("ReviewPresentation");

    printQueryCounts("Presentation", $presentation->getHyperlinkQueries());
    printQueryCounts("Slide 1", $slide->getHyperlinkQueries());
    printQueryCounts("Text frame", $shape->getTextFrame()->getHyperlinkQueries());
    $presentation->save("hyperlink-audit-input.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

في هذا المثال، تُبلغ استعلامات العرض والشريحة عن ثلاث حاويات للنقر، وحاويتين لمرور الفأرة، وثلاث حاويات إما من هذين الإجراءين. يُبلغ استعلام إطار النص عن حاوية واحدة في كل فئة.

### **تصنيف الإجراءات والوجهات**

استخدم [Hyperlink::getActionType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/hyperlink/getactiontype/) لتفسير الإجراء قبل تفسير وجهته. تغطي قيم [HyperlinkActionType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/hyperlinkactiontype/) أكثر من مجرد تنقل ويب:

| القيم | المعنى للتدقيق |
| --- | --- |
| `Hyperlink` | ارتباط تشعبي خارجي؛ افحص URL ومخططه. |
| `JumpSpecificSlide` | تنقل داخلي إلى شريحة معينة. |
| `JumpFirstSlide` | `JumpPreviousSlide` | `JumpNextSlide` | `JumpLastSlide` | `JumpLastViewedSlide` | تنقل مدمج في عرض الشرائح، يُفسّر في سياق عرض الشرائح. |
| `JumpEndShow` | `StartCustomSlideShow` | إنهاء العرض الحالي أو بدء عرض مخصص. |
| `StartMacro` | تنفيذ ماكرو. |
| `StartProgram` | تشغيل برنامج. |
| `OpenFile` | `OpenPresentation` | فتح ملف أو عرض تقديمي آخر؛ راجعه منفصلًا عن عناوين URL الويب. |
| `StartStopMedia` | بدء أو إيقاف تشغيل وسائط. |
| `NoAction` | `Unknown` | لا توجد إجراءات تنقل، أو إجراء غير معروف يتطلب مراجعة. |

اقرأ الوجهات الخارجية من خلال [getExternalUrl](https://reference.aspose.com/slides/ar/php-java/aspose.slides/hyperlink/getexternalurl/) والوجهات الداخلية المحددة من خلال [getTargetSlide](https://reference.aspose.com/slides/ar/php-java/aspose.slides/hyperlink/gettargetslide/). قد لا تحتوي الإجراءات الداخلية والأوامر المدمجة على URL خارجي؛ URL الفارغ لا يعني أن الحاوية لا تمتلك إجراءً. احتفظ بالقيمة التي تُعيدها [getExternalUrlOriginal](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) عندما تختلف عن URL المُحدث، وأدرج التلميح التي تُعيده [getTooltip](https://reference.aspose.com/slides/ar/php-java/aspose.slides/hyperlink/gettooltip/) إذا توفّر.

### **إعداد تقرير، تنظيف، والتحقق من الروابط التشعبية**

الكود PHP التالي يقرأ عرضًا تقديميًا موجودًا (استخدم الملف المُنشأ أعلاه)، يكتب `hyperlink-audit.json`، يطبق سياسة، يحفظ `hyperlink-sanitized.pptx`، ثم يفتحه مرة أخرى للتحقق من كلا نوعي التفعيل مرة أخرى. يجمع الحاويات قبل تعديلها ويستخدم مساواة المرجع لتجنب معالجة الحاوية نفسها مرتين. تغطي استعلامات العرض الشرائح العادية؛ لجرد شامل على مستوى الحزمة، يستعلم أيضًا صراحةً عن الماسترز، التصميمات، الملاحظات، والماستر الخاص بالملاحظات والملصقات إذا وجدت.

يسجل التقرير فهرس الشرائح بدءًا من الواحد و[ getSlideId](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibaseslide/#getSlideId--) حيثما كان متوفرًا. يوفّر [ISlideComponent::getSlide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islidecomponent/#getSlide--) الشريحة المالكة للحاويات المدعومة. لا تمتلك الماسترز، التصميمات، والملاحظات فهرس شريحة عادي وتُحدّد بنطاقها. تُصنّف حاويات الشكل وحاويات تنسيق جزء النص بشكل منفصل؛ الأنواع الأخرى تحتفظ باسم نوعها في وقت التشغيل. يحصل كل حاوية على معرف محلي في التقرير لربط إجراءيها. يُخزّن التقرير أنواع الإجراءات كالقيم العددية المعرفة في تعداد PHP.

تسمح هذه السياسة التطبيقية الصارمة فقط بعناوين HTTPS المطلقة والهدف الداخلي للشرائح الصالحة. تُرفض الماكروهات، البرامج، إجراءات الملفات، الإجراءات المدمجة في عرض الشرائح، الإجراءات غير المعروفة، ومخططات URL الأخرى. هذه الرفضات هي قرارات سياسة، وليس حكم أمان من Aspose.Slides. HTTPS وحده لا يضمن الثقة: أضف قوائم بيضاء للمضيف وفحوصات أخرى لتطبيقك. يتم فحص كل من URL الأصلية والـ URL المُحدّثة. يجرى التدقيق على البيانات الوصفية دون اتباع الروابط أو تشغيل الإجراءات.

للإصلاح، تدعم طريقة حاوية [getHyperlinkManager](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) [setExternalHyperlinkClick](https://reference.aspose.com/slides/ar/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/)، [removeHyperlinkClick](https://reference.aspose.com/slides/ar/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/)، و[removeHyperlinkMouseOver](https://reference.aspose.com/slides/ar/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/). هنا، تُستبدل الروابط الخارجية غير المسموح بها بصفحة هبوط HTTPS ثابتة؛ تُزال باقي الروابط غير المسموح بها بشكل مستقل. اضبط المتغيّر `$replaceExternalClicks` إلى `false` لإزالة جميع الانتهاكات بدلاً من الاستبدال. اختر صفحة استبدال تملكها تطبيقك قبل النشر.

يستخدم علم تصدير التقرير سياسة مراجعة PDF متحفظة: يُعلّق إجراءات مرور الفأرة وأي شيء غير الرابط الخارجي أو الانتقال إلى شريحة معينة كغير مدعوم محتمل. هذا مجرد تلميح مراجعة، وليس اختبار قدرة أو ضمان بقاء الروابط غير المعلمة في عملية التصدير. قد تحتفظ تصديرات PDF وHTML المدعومة بالروابط حسب الإجراء، خيارات التصدير، والمستعرض. لا يمكن للصور النقطية والفيديو الاحتفاظ بالروابط التفاعلية؛ علّق كل إجراء عند التدقيق لتلك المخرجات.

```php
use aspose\slides\HyperlinkActionType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

class HyperlinkAudit {
    public function slideIndex($presentation, $slide) {
        if (java_is_null($slide)) return null;
        for ($index = 0; $index < java_values($presentation->getSlides()->size()); $index++) {
            if (java_values($presentation->getSlides()->get_Item($index)->equals($slide))) return $index + 1;
        }
        return null;
    }

    public function isHttps($value) {
        if ($value === null || $value === '') return false;
        $parts = parse_url($value);
        return $parts !== false && isset($parts['scheme'], $parts['host']) && strcasecmp($parts['scheme'], 'https') === 0 && $parts['host'] !== '';
    }

    public function policyViolation($link) {
        if (java_is_null($link)) return null;
        $action = java_values($link->getActionType());
        if ($action === HyperlinkActionType::JumpSpecificSlide) {
            return java_is_null($link->getTargetSlide()) ? 'Missing target slide' : null;
        }
        if ($action !== HyperlinkActionType::Hyperlink) return 'Action is not allowed';
        if (!$this->isHttps(java_values($link->getExternalUrl()))) return 'Normalized URL is not absolute HTTPS';
        $original = java_values($link->getExternalUrlOriginal());
        if ($original !== null && $original !== '' && !$this->isHttps($original)) return 'Original URL is not absolute HTTPS';
        return null;
    }

    public function addScope(&$found, $slide) {
        if (!java_is_null($slide)) {
            foreach ($slide->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
                $found[] = $container;
            }
        }
    }

    public function collectContainers($presentation) {
        $found = [];
        foreach ($presentation->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
            $found[] = $container;
        }
        $masters = $presentation->getMasters();
        for ($index = 0; $index < java_values($masters->size()); $index++) {
            $this->addScope($found, $masters->get_Item($index));
        }
        $layouts = $presentation->getLayoutSlides();
        for ($index = 0; $index < java_values($layouts->size()); $index++) {
            $this->addScope($found, $layouts->get_Item($index));
        }
        $slides = $presentation->getSlides();
        for ($index = 0; $index < java_values($slides->size()); $index++) {
            $this->addScope($found, $slides->get_Item($index)->getNotesSlideManager()->getNotesSlide());
        }
        $this->addScope($found, $presentation->getMasterNotesSlideManager()->getMasterNotesSlide());
        $this->addScope($found, $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide());
        $seen = new Java('java.util.IdentityHashMap');
        $unique = [];
        foreach ($found as $container) {
            if (!java_values($seen->containsKey($container))) {
                $seen->put($container, true);
                $unique[] = $container;
            }
        }
        return $unique;
    }

    public function addRow(&$rows, $presentation, $link, $activation, $container, $containerId) {
        if (java_is_null($link)) return;
        $ownerSlide = java_instanceof($container, java('com.aspose.slides.ISlideComponent')) ? $container->getSlide() : null;
        $targetSlide = $link->getTargetSlide();
        $violation = $this->policyViolation($link);
        $ownerType = java_instanceof($container, java('com.aspose.slides.IShape')) ? 'Shape' : (java_instanceof($container, java('com.aspose.slides.IPortionFormat')) ? 'Text portion' : java_values($container->getClass()->getSimpleName()));
        $action = java_values($link->getActionType());
        $ordinaryAction = $action === HyperlinkActionType::Hyperlink || $action === HyperlinkActionType::JumpSpecificSlide;
        $externalUrl = java_values($link->getExternalUrl());
        $originalUrl = java_values($link->getExternalUrlOriginal());
        $rows[] = [
            'ContainerId' => $containerId,
            'SlideIndex' => $this->slideIndex($presentation, $ownerSlide),
            'SlideId' => java_is_null($ownerSlide) ? null : java_values($ownerSlide->getSlideId()),
            'Scope' => java_is_null($ownerSlide) ? null : java_values($ownerSlide->getClass()->getSimpleName()),
            'OwnerType' => $ownerType,
            'Activation' => $activation,
            'ActionType' => $action,
            'ExternalUrl' => $externalUrl,
            'TargetSlideIndex' => $this->slideIndex($presentation, $targetSlide),
            'TargetSlideId' => java_is_null($targetSlide) ? null : java_values($targetSlide->getSlideId()),
            'Tooltip' => java_values($link->getTooltip()),
            'OriginalExternalUrl' => $originalUrl === $externalUrl ? null : $originalUrl,
            'PotentiallyUnsafe' => $violation !== null,
            'PolicyViolation' => $violation,
            'TargetExport' => 'PDF',
            'PotentiallyUnsupportedByExport' => $activation === 'mouse-over' || !$ordinaryAction
        ];
    }
}

$replaceExternalClicks = true;
$replacementUrl = 'https://example.com/blocked-link';
$audit = new HyperlinkAudit();
$presentation = new Presentation('hyperlink-audit-input.pptx');
try {
    $containers = $audit->collectContainers($presentation);
    $rows = [];
    foreach ($containers as $index => $container) {
        $audit->addRow($rows, $presentation, $container->getHyperlinkClick(), 'click', $container, $index + 1);
        $audit->addRow($rows, $presentation, $container->getHyperlinkMouseOver(), 'mouse-over', $container, $index + 1);
    }
    $json = json_encode($rows, JSON_PRETTY_PRINT | JSON_UNESCAPED_SLASHES);
    if ($json === false) {
        echo 'Unable to encode the audit report: ' . json_last_error_msg() . PHP_EOL;
    } elseif (file_put_contents('hyperlink-audit.json', $json . PHP_EOL) === false) {
        echo 'Unable to write the audit report.' . PHP_EOL;
    } else {
        foreach ($containers as $container) {
            $click = $container->getHyperlinkClick();
            if ($audit->policyViolation($click) !== null) {
                if ($replaceExternalClicks && java_values($click->getActionType()) === HyperlinkActionType::Hyperlink) {
                    $container->getHyperlinkManager()->setExternalHyperlinkClick($replacementUrl);
                } else {
                    $container->getHyperlinkManager()->removeHyperlinkClick();
                }
            }
            if ($audit->policyViolation($container->getHyperlinkMouseOver()) !== null) {
                $container->getHyperlinkManager()->removeHyperlinkMouseOver();
            }
        }
        $presentation->save('hyperlink-sanitized.pptx', SaveFormat::Pptx);

        $reopened = new Presentation('hyperlink-sanitized.pptx');
        try {
            $remainingContainers = $audit->collectContainers($reopened);
            $violations = 0;
            foreach ($remainingContainers as $container) {
                if ($audit->policyViolation($container->getHyperlinkClick()) !== null) $violations++;
                if ($audit->policyViolation($container->getHyperlinkMouseOver()) !== null) $violations++;
            }
            echo 'Audit rows: ' . count($rows) . '; prohibited actions after reopening: ' . $violations . PHP_EOL;
            if ($violations !== 0) {
                echo 'Verification failed: do not distribute the saved presentation.' . PHP_EOL;
            }
        } finally {
            $reopened->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

مع الإدخال المُنشأ أعلاه، يحتوي التقرير على خمس صفوف إجراءات. يُزال رابط ملف مرور الفأرة والماكرو عند النقر، بينما تبقى الروابط HTTPS والتنقل الداخلي إلى الشرائح. تُظهر عملية التحقق عدم وجود إجراءات محظورة. يُظهر إدخال يحتوي على رابط خارجي غير مسموح به أيضًا فرع الاستبدال. يظل حاوية بضغط مسموح ومرور فأرة غير مسموح به مع فعل النقر الخاص به.

هذا التنظيف الانتقائي يختلف عن [removeAllHyperlinks](https://reference.aspose.com/slides/ar/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/)، الذي يزيل كلا النوعين من التفعيل في النطاق المختار بغض النظر عن السياسة. تتحقق عملية التحقق هنا من إجراءات الروابط التشعبية فقط؛ لا تُزيل مشاريع VBA المدمجة، كائنات OLE، أو أي محتوى نشط آخر، ولا تتحقق من ملف PDF أو HTML المصدر.

## **الأسئلة المتكررة**

**كيف يمكنني الربط إلى قسم أو شريحته الأولى؟**

تقسم الأقسام في PowerPoint الشرائح إلى مجموعات، لكن الارتباط التشعبي الداخلي يستهدف شريحة واحدة. لإنشاء تنقل إلى قسم، اربط إلى الشريحة الأولى في ذلك القسم.

**هل يمكنني إرفاق رابط تشعبي لعناصر الشريحة الرئيسية بحيث يعمل على جميع الشرائح؟**

نعم. تدعم عناصر الشريحة الرئيسية وتخطيطاتها الروابط التشعبية. تكون الروابط على هذه العناصر متاحة خلال عرض الشرائح على الشرائح التي تستخدم الماستر أو التخطيط المقابل.

**هل سيتم الحفاظ على الروابط التشعبية عند التصدير إلى PDF أو HTML أو الصور أو الفيديو؟**

قد تحتفظ تصديرات PDF وHTML المدعومة بالروابط؛ لا يمكن للصور النقطية والفيديو ذلك. راجع اعتبارات التصدير في القسم [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).