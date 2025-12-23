---
title: تحويل العروض التقديمية إلى HTML5 باستخدام PHP
linktitle: العرض التقديمي إلى HTML5
type: docs
weight: 40
url: /ar/php-java/export-to-html5/
keywords:
- PowerPoint إلى HTML5
- OpenDocument إلى HTML5
- عرض تقديمي إلى HTML5
- شريحة إلى HTML5
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
description: "تصدير عروض PowerPoint وOpenDocument إلى HTML5 متجاوب باستخدام Aspose.Slides لـ PHP عبر Java. الحفاظ على التنسيق والرسوم المتحركة والتفاعلية."
---

{{% alert title="معلومات" color="info" %}}

في [Aspose.Slides 21.9](/slides/ar/php-java/aspose-slides-for-java-21-9-release-notes/)، قمنا بتنفيذ دعم تصدير HTML5.

{{% /alert %}} 

تسمح لك عملية التصدير إلى HTML5 هنا بتحويل PowerPoint إلى HTML بدون ملحقات ويب أو تبعيات. بهذه الطريقة، باستخدام القوالب الخاصة بك، يمكنك تطبيق خيارات مرنة للغاية تحدد عملية التصدير وملف HTML وCSS وJavaScript والسمات المتحركة الناتجة. 

## **تصدير PowerPoint إلى HTML5**

يُظهر هذا الكود PHP كيفية تصدير عرض تقديمي إلى HTML5 بدون ملحقات ويب وتبعيات:
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

قد ترغب في تحديد إعدادات للرسوم المتحركة للأشكال وانتقالات الشرائح بهذه الطريقة:
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

يوضح هذا الكود Java عملية التحويل القياسية من PowerPoint إلى HTML:
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


في هذه الحالة، يُعرض محتوى العرض التقديمي عبر SVG بالشكل التالي:
```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```php



{{% alert title="ملاحظة" color="warning" %}} 

عند استخدام هذه الطريقة لتصدير PowerPoint إلى HTML، بسبب عرض SVG، لن تتمكن من تطبيق الأنماط أو تحريك العناصر المحددة. 

{{% /alert %}}

## **تصدير PowerPoint إلى عرض شرائح HTML5**

**Aspose.Slides** يتيح لك تحويل عرض تقديمي PowerPoint إلى مستند HTML5 يتم فيه عرض الشرائح في وضع عرض الشرائح. في هذه الحالة، عند فتح ملف HTML5 الناتج في المتصفح، ستظهر العرض التقديمي في وضع عرض الشرائح على صفحة الويب. 

يوضح هذا الكود PHP عملية تصدير PowerPoint إلى عرض شرائح HTML5:
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

التعليقات في PowerPoint هي أداة تسمح للمستخدمين بترك ملاحظات أو ملاحظات على شرائح العرض. وهي مفيدة بشكل خاص في المشاريع التعاونية، حيث يمكن لعدة أشخاص إضافة اقتراحاتهم أو ملاحظاتهم إلى عناصر شريحة محددة دون تعديل المحتوى الرئيسي. تُظهر كل تعليق اسم المؤلف، مما يجعل من السهل تتبع من ترك الملاحظة.

لنفترض أن لدينا عرض تقديمي PowerPoint محفوظ في ملف "sample.pptx".

![Two comments on the presentation slide](two_comments_pptx.png)

عند تحويل عرض تقديمي PowerPoint إلى مستند HTML5، يمكنك بسهولة تحديد ما إذا كنت ستشمل التعليقات من العرض في المستند الناتج. للقيام بذلك، تحتاج إلى تحديد معلمات العرض للتعليقات في طريقة `getNotesCommentsLayouting` في فئة `Html5Options`.

المثال التالي يُظهر كيفية تحويل عرض تقديمي إلى مستند HTML5 مع عرض التعليقات إلى يمين الشرائح.
```php
$html5Options = new Html5Options();
$html5Options->getNotesCommentsLayouting()->setCommentsPosition(CommentsPositions::Right);

$presentation = new Presentation("sample.pptx");
$presentation->save("output.html", SaveFormat::Html5, $html5Options);
$presentation->dispose();
```


يظهر مستند "output.html" في الصورة أدناه.

![The comments in the output HTML5 document](two_comments_html5.png)

## **الأسئلة المتكررة**

**هل يمكنني التحكم فيما إذا كانت الرسوم المتحركة للكائنات وانتقالات الشرائح ستعمل في HTML5؟**

نعم، يوفر HTML5 خيارات منفصلة لتمكين أو تعطيل [shape animations](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/setanimateshapes/) و[slide transitions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/setanimatetransitions/).

**هل يدعم إخراج التعليقات، وأين يمكن وضعها بالنسبة للشرائح؟**

نعم، يمكن إضافة التعليقات في HTML5 وتحديد موضعها (مثلاً إلى يمين الشريحة) من خلال [layout settings](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setSlidesLayoutOptions) للملاحظات والتعليقات.

**هل يمكنني تخطي الروابط التي تستدعي JavaScript لأسباب أمنية أو سياسات CSP؟**

نعم، هناك [setting](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) يتيح لك تخطي الروابط التي تحتوي على استدعاءات JavaScript أثناء الحفظ. يساعد ذلك في الالتزام بسياسات الأمان الصارمة.