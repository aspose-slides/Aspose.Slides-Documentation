---
title: تصدير إلى HTML5
type: docs
weight: 40
url: /ar/php-java/export-to-html5/
keywords:
- PowerPoint إلى HTML
- الشرائح إلى HTML
- HTML5
- تصدير HTML
- تصدير العرض التقديمي
- تحويل العرض التقديمي
- تحويل الشرائح
- PHP
- Aspose.Slides for PHP via Java
description: "تصدير PowerPoint إلى HTML5 في PHP"
---

{{% alert title="معلومات" color="info" %}}

في [Aspose.Slides 21.9](/slides/ar/php-java/aspose-slides-for-java-21-9-release-notes/)، قمنا بتنفيذ دعم تصدير HTML5.

{{% /alert %}} 

عملية التصدير إلى HTML5 هنا تسمح لك بتحويل PowerPoint إلى HTML بدون ملحقات أو اعتمادات ويب. بهذه الطريقة، باستخدام قوالبك الخاصة، يمكنك تطبيق خيارات مرنة جدًا تحدد عملية التصدير ونتيجة HTML وCSS وJavaScript وخصائص الرسوم المتحركة.

## **تصدير PowerPoint إلى HTML5**

هذا الكود بلغة PHP يوضح كيفية تصدير عرض تقديمي إلى HTML5 بدون ملحقات وعلاقات ويب:

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

في هذه الحالة، تحصل على HTML نظيف.

{{% /alert %}}

قد ترغب في تحديد إعدادات لرسوم الشكل ورسوم انتقال الشرائح بهذه الطريقة:

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

هذا الكود Java يوضح عملية PowerPoint إلى HTML القياسية:

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

في هذه الحالة، يتم عرض محتوى العرض التقديمي من خلال SVG في شكل مثل هذا:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> محتوى الشريحة هنا </g>
     </svg>
</div>
</body>
```php

```

{{% alert title="ملاحظة" color="warning" %}} 

عند استخدام هذه الطريقة لتصدير PowerPoint إلى HTML، بسبب عرض SVG، لن تتمكن من تطبيق الأنماط أو تحريك عناصر معينة.

{{% /alert %}}

## **تصدير PowerPoint إلى عرض شرائح HTML5**

**Aspose.Slides** يتيح لك تحويل عرض PowerPoint إلى وثيقة HTML5 يتم فيها تقديم الشرائح في وضع عرض الشرائح. في هذه الحالة، عندما تفتح ملف HTML5 الناتج في متصفح، ترى العرض التقديمي في وضع عرض الشرائح على صفحة ويب.

هذا الكود بلغة PHP يوضح عملية تصدير PowerPoint إلى عرض شرائح HTML5:

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

## تحويل عرض تقديمي إلى وثيقة HTML5 مع تعليقات

التعليقات في PowerPoint هي أداة تسمح للمستخدمين بترك ملاحظات أو تعليقات على الشرائح. إنها مفيدة بشكل خاص في المشاريع التعاونية، حيث يمكن لعدة أشخاص إضافة اقتراحاتهم أو ملاحظاتهم على عناصر الشرائح المحددة دون تغيير المحتوى الرئيسي. كل تعليق يظهر اسم المؤلف، مما يسهل تتبع من ترك الملاحظة.

لنقل أن لدينا عرض PowerPoint التالي محفوظ في ملف "sample.pptx".

![تعليقان على شريحة العرض التقديمي](two_comments_pptx.png)

عند تحويل عرض PowerPoint إلى وثيقة HTML5، يمكنك بسهولة تحديد ما إذا كنت تريد تضمين التعليقات من العرض التقديمي في وثيقة الناتج. للقيام بذلك، تحتاج إلى تحديد معلمات العرض للتعليقات في طريقة `getNotesCommentsLayouting` من فئة `Html5Options`.

مثال الكود التالي يقوم بتحويل عرض تقديمي إلى وثيقة HTML5 مع التعليقات المعروضة على اليمين من الشرائح.
```php
$html5Options = new Html5Options();
$html5Options->getNotesCommentsLayouting()->setCommentsPosition(CommentsPositions::Right);

$presentation = new Presentation("sample.pptx");
$presentation->save("output.html", SaveFormat::Html5, $html5Options);
$presentation->dispose();
```

تم عرض وثيقة "output.html" في الصورة أدناه.

![التعليقات في وثيقة HTML5 الناتجة](two_comments_html5.png)