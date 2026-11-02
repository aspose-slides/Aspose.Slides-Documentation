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
- رابط تشعبي نصي
- رابط تشعبي للشرائح
- رابط تشعبي لل形
- رابط تشعبي للصورة
- رابط تشعبي للفيديو
- رابط تشعبي قابل للتعديل
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إضافة وتنسيق وتحديث وإزالة الروابط التشعبية في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides لـ PHP عبر Java، باستخدام أمثلة PHP."
---
## **مقدمة**

يوفر الرابط التشعبي اتصالًا بين محتوى العرض التقديمي وموقع ويب أو موقع داخل العرض التقديمي. في PowerPoint، تُستخدم الروابط التشعبية عادةً لغرضين:

* فتح موقع ويب من نص أو شكل أو إطار وسائط.
* الانتقال إلى شريحة أخرى، على سبيل المثال من جدول المحتويات.

يتيح لك Aspose.Slides for PHP عبر Java إضافة هذه الروابط، والتحكم في مظهرها وصوتها، وتحديث خصائصها، وإزالتها. توضح الأمثلة أدناه كيفية العمل مع الروابط التشعبية على العناصر الفردية وكيفية الوصول إلى الروابط التشعبية على مستوى العرض التقديمي أو الشريحة أو إطار النص. تفترض أن جسر PHP/Java ومغلف Aspose.Slides PHP مُهيّئان. تُربط أعضاء API الذين لا يمتلكون صفحة مرجعية PHP بواجهة برمجة التطبيقات الأساسية في Java.

{{% alert color="info" title="Note" %}}
يمكنك أيضًا تعديل العروض التقديمية باستخدام [محرر Aspose PowerPoint المجاني على الإنترنت](https://products.aspose.app/slides/editor).
{{% /alert %}} 

## **إضافة روابط URL**

يمكنك تعيين عنوان URL لموقع ويب إلى نص أو شكل أو إطار وسائط. العنصر الذي تُعيّن إليه الرابط التشعبي يحدد مساحة النقر: فقرة النص تربط النص المحدد، بينما الشكل أو الإطار يربط كائن الشريحة.

للعروض التي تحتوي على روابط تشعبية نسبية، راجع [إدارة قاعدة الرابط التشعبي](/slides/ar/php-java/presentation-properties/#manage-the-hyperlink-base) لقراءة القاعدة، تعديلها أو مسحها على مستوى المستند.

### **إضافة روابط URL إلى النص**

لربط النص بموقع ويب، مرّر كائن [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/) إلى طريقة [setHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/sethyperlinkclick/) الخاصة بفقرة النص، كما هو موضح أدناه. يصبح فقط ذلك الجزء من النص قابلًا للنقر.

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

لجعل شكل أو إطار قابل للنقر، استدعِ طريقته [setHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/shape/sethyperlinkclick/). ينتمي الرابط التشعبي إلى الكائن نفسه وليس إلى فقرة نص داخلها.

ينطبق النهج نفسه على إطارات الصور والصوت والفيديو: عيّن الرابط التشعبي للإطار واستدعِ [setTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settooltip/) إذا لزم الأمر.

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

تتيح الروابط التشعبية الداخلية للقراء الانتقال من جدول المحتويات إلى شريحة محددة. يستخدم المثال التالي [setInternalHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/setinternalhyperlinkclick/) لربط نص "Page 2" في الشريحة الأولى بالشريحة الثانية.

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

تحدّد طريقة [setColorSource](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setcolorsource/) في كائن [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/) ما إذا كان الرابط التشعبي سيستخدم لون الروابط التشعبية في العرض التقديمي أو تنسيق فقرة النص. لتطبيق لون نص مخصص، اختر [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkcolorsource/) واضبط لون تعبئة الفقرة. تم تقديم هذه الميزة في PowerPoint 2019؛ الإصدارات الأقدم لا تطبق هذا الإعداد.

المثال التالي يضيف رابطين تشعبيين نصيين إلى نفس الشريحة. يستخدم الأول تعبئة نص حمراء، بينما يحتفظ الثاني باللون الافتراضي للرابط التشعبي.

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

يمكن للرابط التشعبي تشغيل صوت عند التنشيط أو إيقاف صوت يُشغل بالفعل. استخدم الطرق التالية لتكوين هذه السلوكيات:

- [Hyperlink::setSound](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setsound/) يحدد الصوت المرتبط بالرابط التشعبي.
- [Hyperlink::setStopSoundOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setstopsoundonclick/) يتحكم فيما إذا كان تنشيط الرابط التشعبي يوقف الصوت السابق.

#### **إضافة صوت للرابط التشعبي**

المثال التالي يحمل الملف `sampleaudio.wav` ويربطه بزر في الشريحة الأولى. النقر على الزر يشغل الصوت وينتقل إلى الشريحة التالية. الشكل الثاني في تلك الشريحة يوقف الصوت السابق عند النقر، دون تنفيذ إجراء تنقل.

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

#### **استخراج صوت للرابط التشعبي**

المثال التالي يفتح العرض التقديمي الذي تم إنشاؤه أعلاه ويقرأ صوت الرابط التشعبي للشكل الأول إلى الذاكرة عبر [getSound](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getsound/) و [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/audio/getbinarydata/).

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

### **تلميحات الأدوات وإعدادات التفاعل**

يمكنك استدعاء طرق [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/) التالية بعد تعيين رابط تشعبي إلى نص أو شكل:

- [setTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settooltip/) يحدد النص الذي يمكن للمشاهد عرضه كتلميح للرابط.
- [setTargetFrame](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settargetframe/) يحدد إطار الهدف داخل مجموعة إطارات HTML الأصلية، إن كان ذلك مناسبًا.
- [setHistory](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/sethistory/) يتحكم فيما إذا كان تنشيط الرابط يضيف وجهته إلى قائمة الروابط المشاهدة.
- [setHighlightClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/sethighlightclick/) يتحكم فيما إذا كان يتم تمييز الرابط عند النقر.

## **إزالة الروابط التشعبية من العروض التقديمية**

استخدم [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) لجمع حاويات الروابط التشعبية، بما في ذلك روابط فقرات النص، قبل تعديلها. يزيل المثال التالي كلا نوعي التنشيط من الشريحة الأولى. لإزالة نوع واحد فقط، استدعِ فقط [removeHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) أو [removeHyperlinkMouseOver](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/); إزالة إجراء النقر لا يزيل نظيره عند تمرير الفأرة.

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

لإزالة غير مشروطة، يزيل [removeAllHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) كلا نوعي التنشيط في النطاق المحدد في استدعاء واحد. للتنظيف الانتقائي وتغطية الماسترز، التخطيطات، والملاحظات، راجع [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **إنشاء جرد شامل للروابط التشعبية**

قبل توزيع عرض تقديمي، قم بجرد إجراءات التفاعل الخاصة به بالإضافة إلى روابط الويب. تُعيد [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) كائنات [IHyperlinkContainer](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/)، وليس قائمة مسطحة من سلاسل URL. افحص كلًا من [getHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) و [getHyperlinkMouseOver](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) على كل حاوية. هما مستقلان: يمكن لنفس الحاوية أن تعرض كلا الإجراءين، لذلك يحتاج التقرير الكامل إلى صفين كحد أقصى لكل حاوية.

قد يؤدي فحص الروابط التشعبية على مستوى الشكل فقط إلى فقدان الروابط المرتبطة بفقرات النص. استعلم عن النطاق المناسب بدلاً من ذلك، واحتفظ بالحاويات العائدة حتى تتمكن لاحقًا من تحديث أو إزالة إجراءاتها.

### **الاستعلام عن نطاقات العرض، الشريحة، وإطار النص**

تتوفر فئة [HyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/) عبر [Presentation::getHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/gethyperlinkqueries/)، [IBaseSlide::getHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--)، و[TextFrame::getHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/gethyperlinkqueries/). يدعم كل نطاق نفس الاستعلامات:

- [getHyperlinkClicks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/gethyperlinkclicks/) يُعيد الحاويات التي تحتوي على إجراء نقرة.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/gethyperlinkmouseovers/) يُعيد الحاويات التي تحتوي على إجراء تمرير الفأرة.
- [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) يُعيد الحاويات التي تحتوي على أي من الإجراءين أو كلاهما.

المثال التالي يُنشئ الملف `hyperlink-audit-input.pptx` مع رابط نقر خارجي، رابط تمرير ملف، تنقل داخلي بين الشرائح، رابط تمرير نص، وإجراء ماكرو. لا ينفّذ أيًا من هذه الإجراءات. تعمل الاستعلامات الثلاثة نفسها في كل نطاق؛ الأعداد تصف الحاويات، وليس مجموعات الإجراءات. يستبعد نطاق إطار النص الروابط الخاصة بالشكل المحيط.

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

في هذا المثال، تُبلغ استعلامات العرض والشريحة عن ثلاث حاويات نقر، حاويتين لتمرير الفأرة، وثلاث حاويات مع أيٍ من الإجراءين. يُبلغ استعلام إطار النص عن حاوية واحدة في كل فئة.

### **تصنيف الإجراءات والوجهات**

استخدم [Hyperlink::getActionType](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getactiontype/) لتفسير إجراء قبل تفسير جهته. تغطي قيم [HyperlinkActionType](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkactiontype/) أكثر من مجرد تنقل ويب:

| Values | معنى للتدقيق |
| --- | --- |
| `Hyperlink` | رابط تشعبي خارجي؛ افحص عنوان URL ومخططه. |
| `JumpSpecificSlide` | تنقل داخلي إلى شريحة معينة. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | تنقل مدمج في عرض الشرائح، يُحل في سياق عرض الشرائح. |
| `JumpEndShow`, `StartCustomSlideShow` | إنهاء العرض الحالي أو بدء عرض مخصص. |
| `StartMacro` | تنفيذ ماكرو. |
| `StartProgram` | تشغيل برنامج. |
| `OpenFile`, `OpenPresentation` | فتح ملف أو عرض تقديمي آخر؛ راجع ذلك بشكل منفصل عن عناوين URL للويب. |
| `StartStopMedia` | بدء أو إيقاف تشغيل الوسائط. |
| `NoAction`, `Unknown` | لا يوجد إجراء تنقل، أو إجراء غير معروف يتطلب مراجعة. |

اقرأ الوجهات الخارجية من [getExternalUrl](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getexternalurl/) والوجهات الداخلية المحددة من [getTargetSlide](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/gettargetslide/). قد لا تحتوي الإجراءات الداخلية والأوامر المدمجة على URL خارجي؛ عدم وجود URL لا يعني أن الحاوية لا تحتوي على إجراء. احتفظ بالقيمة التي تُعيدها [getExternalUrlOriginal](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) عندما تختلف عن URL المُطبع، وضمن تلميح الأدوات المسترجع من [getTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/gettooltip/) إذا كان متوفرًا.

### **تقرير، تنقية، والتحقق من الروابط التشعبية**

المثال التالي بلغة PHP يقرأ عرضًا تقديميًا موجودًا (استخدم الملف الذي تم إنشاؤه أعلاه)، يكتب `hyperlink-audit.json`, يطبق سياسة, يحفظ `hyperlink-sanitized.pptx`, ثم يفتحها مرة أخرى للتحقق من كلا نوعي التنشيط مرة أخرى. يجمع الحاويات قبل تعديلها ويستخدم مساواة المراجع لتجنب معالجة نفس الحاوية مرتين. تغطي استعلامات العرض الشرائح العادية؛ لإنشاء جرد على مستوى الحزمة، يستعلم أيضًا صراحةً عن الماسترز, التخطيطات, الملاحظات, وماستر الملاحظات وكتيب التوزيع عندما تكون موجودة.

يقوم التقرير بتسجيل فهرس شريحة يبدأ من واحد و[getSlideId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideId--) حيثما يتوفر. توفر [ISlideComponent::getSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islidecomponent/#getSlide--) الشريحة المالكة للحاويات المدعومة. لا تحتوي الماسترز, التخطيطات, والملاحظات على فهرس شريحة عادي ويتم تحديدها وفق نطاقها. تُوسم حاويات الشكل وحاويات تنسيق فقرات النص بشكل منفصل؛ تحتفظ الأنواع الأخرى من الحاويات باسم نوعها في وقت التشغيل. يحصل كل حاوية على معرف محلي في التقرير لتتمكن من ربط الإجراءين. يخزن التقرير أنواع الإجراءات كقواعد عددية معرفة في تعداد PHP.

تسمح هذه السياسة التطبيقية المقيدة عمداً فقط بعناوين URL مطلقة عبر HTTPS وأهداف شرائح داخلية صالحة. ترفض الماكروهات, البرامج, إجراءات الملفات, إجراءات عرض الشرائح الأخرى, الإجراءات غير المعروفة, وأنواع عناوين URL الأخرى. هذه الرفض هي قرارات سياسة, وليس حكم أمان من Aspose.Slides. لا يضمن HTTPS وحده الثقة: أضف قوائم السماح للمضيف وفحوصات أخرى لتطبيقك. تُفحص كل من عناوين URL الخارجية الأصلية والمُطبعّة. يجرى المثال تدقيق البيانات الوصفية دون اتباع الروابط أو تشغيل الإجراءات.

للتصحيح, يدعم [getHyperlinkManager](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) الحاوية [setExternalHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/), [removeHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/), و[removeHyperlinkMouseOver](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/). هنا, تُستبدل روابط النقر الخارجية المحظورة بصفحة هبوط HTTPS ثابتة; تُزال النقرات الأخرى المحظورة وإجراءات تمرير الفأرة المحظورة بشكل مستقل. اضبط `$replaceExternalClicks` على `false` لإزالة جميع انتهاكات السياسة بدلاً من ذلك. اختر صفحة بديلة مملوكة للتطبيق قبل النشر.

تستخدم علامة تصدير التقرير سياسة مراجعة PDF محافظة: تُعلّم إجراءات تمرير الفأرة وأي شيء بخلاف رابط خارجي أو قفزة شريحة محددة على أنه محتمل أن لا يُدعم. هي تلميح مراجعة, ليست اختبار قدرة أو ضمان أن الروابط غير المُعلّمة ستبقى بعد التصدير. قد تحافظ تصديرات PDF وHTML المدعومة ([PDF](/slides/ar/php-java/convert-powerpoint-to-pdf/) و[HTML](/slides/ar/php-java/convert-powerpoint-to-html/)) على الروابط التشعبية, اعتمادًا على الإجراء, خيارات التصدير, والمستعرض. لا يمكن للصور النقطية ([images](/slides/ar/php-java/convert-powerpoint-to-png/)) والفيديو ([video](/slides/ar/php-java/convert-powerpoint-to-video/)) الحفاظ على الروابط التفاعلية; علّم كل إجراء عند التدقيق لتلك المخرجات.

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

مع الإدخال الذي تم إنشاؤه أعلاه, يحتوي التقرير على خمس صفوف إجراءات. تُزيل روابط تمرير الفأرة للملف وإجراء النقر للماكرو, بينما تبقى روابط HTTPS وتنقل الشرائح الداخلية. تُظهر عملية التحقق صفر إجراءات محظورة. يُظهر الإدخال الذي يحتوي على رابط نقر خارجي محظور فرع الاستبدال. تحتفظ الحاوية التي لديها نقر مسموح وتمريرة فأرة محظورة بإجراء النقر.

يختلف هذا التنظيف الانتقائي عن [removeAllHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/), الذي يزيل كلا نوعي التنشيط في النطاق المحدد بغض النظر عن السياسة. تتحقق عملية التحقق هنا من إجراءات الروابط التشعبية فقط; لا تُزيل مشاريع VBA المضمنة, كائنات OLE, أو محتوى نشط آخر, ولا تُصادق على ملف PDF أو HTML مُصدّر.

## **الأسئلة المتكررة**

**كيف يمكنني الربط بقسم أو شريحته الأولى؟**

تُجمع الأقسام في PowerPoint الشرائح, لكن الرابط التشعبي الداخلي يستهدف شريحة فردية. لإنشاء تنقل إلى قسم, اربط بالشريحة الأولى في ذلك القسم.

**هل يمكنني إرفاق رابط تشعبي بعناصر الشريحة الرئيسية ليعمل على جميع الشرائح؟**

نعم. تدعم عناصر الشريحة الرئيسية وتخطيطها الروابط التشعبية. تكون الروابط على هذه العناصر متاحة أثناء عرض الشرائح على الشرائح التي تستخدم الشريحة الرئيسية أو التخطيط المقابل.

**هل سيتم الحفاظ على الروابط التشعبية عند التصدير إلى PDF أو HTML أو الصور أو الفيديو؟**

قد تحافظ تصديرات PDF وHTML المدعومة على الروابط التشعبية; لا يمكن للصور النقطية والفيديو ذلك. راجع اعتبارات التصدير في [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).