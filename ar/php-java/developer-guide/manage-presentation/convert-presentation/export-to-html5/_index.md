---
title: تحويل العروض التقديمية إلى HTML5 باستخدام PHP
linktitle: العرض التقديمي إلى HTML5
type: docs
weight: 40
url: /ar/php-java/export-to-html5/
keywords:
- PowerPoint إلى HTML5
- OpenDocument إلى HTML5
- العرض التقديمي إلى HTML5
- الشريحة إلى HTML5
- PPT إلى HTML5
- PPTX إلى HTML5
- ODP إلى HTML5
- حفظ PPT كـ HTML5
- حفظ PPTX كـ HTML5
- حفظ ODP كـ HTML5
- تصدير PPT إلى HTML5
- تصدير PPTX إلى HTML5
- تصدير ODP إلى HTML5
- PHP
- Aspose.Slides
description: "تصدير عروض PowerPoint و OpenDocument إلى HTML5 سريع الاستجابة باستخدام Aspose.Slides للـ PHP عبر Java. الحفاظ على التنسيق، والرسوم المتحركة، والتفاعلية."
---

يدعم Aspose.Slides تصدير HTML5. تسمح لك عملية التصدير إلى HTML5 هنا بتحويل PowerPoint إلى HTML دون ملحقات ويب أو تبعيات. بهذه الطريقة، باستخدام القوالب الخاصة بك، يمكنك تطبيق خيارات مرنة جدًا تحدد عملية التصدير والـ HTML و CSS و JavaScript وخصائص الرسوم المتحركة الناتجة. 

## **تصدير PowerPoint إلى HTML5**

يعرض هذا الشيفرة بلغة PHP كيفية تصدير عرض تقديمي إلى HTML5 دون ملحقات ويب أو تبعيات:
```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.html", SaveFormat::Html5);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="primary" %}} 
في هذه الحالة، ستحصل على HTML نظيف. 
{{% /alert %}}

قد ترغب في تحديد إعدادات لرسوميات الأشكال وانتقالات الشرائح بهذه الطريقة:
```php
  $pres = new Presentation("pres.pptx");
  try {
    $html5Options = new Html5Options();
    $html5Options->setAnimateShapes(false);
    $html5Options->setAnimateTransitions(false);
    $pres->save("pres5.html", SaveFormat::Html5, $html5Options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **تصدير PowerPoint إلى HTML**

يعرض هذا المثال إلى Java عملية التصدير القياسية من PowerPoint إلى HTML:
```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.html", SaveFormat::Html);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


في هذه الحالة، يتم عرض محتوى العرض التقديمي عبر SVG في شكل كهذا:
```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```php


{{% alert title="Note" color="warning" %}} 
عند استخدام هذه الطريقة لتصدير PowerPoint إلى HTML، وبسبب عرض الـ SVG، لن تتمكن من تطبيق الأنماط أو تحريك العناصر المحددة. 
{{% /alert %}}

## **تصدير PowerPoint إلى عرض الشرائح HTML5**

**Aspose.Slides** يسمح لك بتحويل عرض تقديمي PowerPoint إلى مستند HTML5 تُعرض فيه الشرائح في وضع عرض الشرائح. في هذه الحالة، عند فتح ملف HTML5 الناتج في متصفح، ترى العرض التقديمي في وضع عرض الشرائح على صفحة ويب. 

هذا الشيفرة PHP يوضح عملية تصدير PowerPoint إلى عرض الشرائح HTML5:
```php
  $pres = new Presentation("pres.pptx");
  try {
    $html5Options = new Html5Options();
    $html5Options->setAnimateShapes(true);
    $html5Options->setAnimateTransitions(true);
    $pres->save("HTML5-slide-view.html", SaveFormat::Html5, $html5Options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **تحويل العروض التقديمية إلى مستندات HTML5 مع التعليقات**

التعليقات في PowerPoint هي أداة تسمح للمستخدمين بترك ملاحظات أو ملاحظات على شرائح العرض التقديمي. تكون مفيدة بشكل خاص في المشاريع التعاونية، حيث يمكن لأكثر من شخص إضافة اقتراحاتهم أو ملاحظاتهم إلى عناصر شريحة معينة دون تعديل المحتوى الرئيسي. كل تعليق يُظهر اسم المؤلف، مما يسهل تتبع من ترك الملاحظة.

لنفترض أن لدينا العرض التقديمي التالي في ملف "sample.pptx".

![تعليقان على شريحة العرض التقديمي](two_comments_pptx.png)

عند تحويل عرض تقديمي PowerPoint إلى مستند HTML5، يمكنك بسهولة تحديد ما إذا كنت تريد تضمين التعليقات من العرض في المستند الناتج. للقيام بذلك، تحتاج إلى تحديد معلمات عرض التعليقات في طريقة `getNotesCommentsLayouting` من الفئة `Html5Options`.

مثال الشيفرة التالي يحول عرضًا تقديميًا إلى مستند HTML5 مع عرض التعليقات إلى يمين الشرائح.
```php
$html5Options = new Html5Options();
$html5Options->getNotesCommentsLayouting()->setCommentsPosition(CommentsPositions::Right);

$presentation = new Presentation("sample.pptx");
$presentation->save("output.html", SaveFormat::Html5, $html5Options);
$presentation->dispose();
```


المستند "output.html" موضح في الصورة أدناه.

![التعليقات في مستند HTML5 الناتج](two_comments_html5.png)

## **الأسئلة الشائعة**

**هل يمكنني التحكم فيما إذا كانت رسوميات الكائنات وانتقالات الشرائح ستعمل في HTML5؟**  
نعم، يوفر HTML5 خيارات منفصلة لتمكين أو تعطيل [رسوميات الأشكال](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/setanimateshapes/) و[انتقالات الشرائح](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/setanimatetransitions/).

**هل يتم دعم إخراج التعليقات، وأين يمكن وضعها بالنسبة إلى الشريحة؟**  
نعم، يمكن إضافة التعليقات في HTML5 وتحديد موقعها (على سبيل المثال، إلى يمين الشريحة) عبر [إعدادات التخطيط](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setSlidesLayoutOptions) للملاحظات والتعليقات.

**هل يمكنني تخطي الروابط التي تستدعي JavaScript لأسباب أمنية أو سياسة CSP؟**  
نعم، يوجد [إعداد](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) يتيح لك تخطي الروابط التشعبية التي تستدعي JavaScript أثناء الحفظ. هذا يساعد على الامتثال لسياسات الأمان الصارمة.