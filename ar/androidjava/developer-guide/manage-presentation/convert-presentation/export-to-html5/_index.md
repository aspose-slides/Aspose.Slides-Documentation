---
title: تحويل العروض التقديمية إلى HTML5 على Android
linktitle: العرض التقديمي إلى HTML5
type: docs
weight: 40
url: /ar/androidjava/export-to-html5/
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
- Android
- Java
- Aspose.Slides
description: "تصدير عروض PowerPoint و OpenDocument إلى HTML5 متجاوب باستخدام Aspose.Slides لأندرويد عبر Java. الحفاظ على التنسيق والرسوم المتحركة والتفاعلية."
---

Aspose.Slides يدعم تصدير HTML5. عملية التصدير إلى HTML5 هنا تتيح لك تحويل PowerPoint إلى HTML بدون امتدادات ويب أو تبعيات. بهذه الطريقة، باستخدام القوالب الخاصة بك، يمكنك تطبيق خيارات مرنة جدًا تُعرِّف عملية التصدير ونتيجة HTML وCSS وJavaScript وخصائص الرسوم المتحركة.

## **تصدير PowerPoint إلى HTML5**

هذا الكود Java يوضح كيفية تصدير عرض تقديمي إلى HTML5 بدون امتدادات ويب وتبعيات:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html5);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" %}} 
في هذه الحالة ستحصل على HTML نظيف. 
{{% /alert %}}

قد ترغب في تحديد إعدادات لرسوم متحركة الأشكال وانتقالات الشرائح بهذه الطريقة:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    Html5Options html5Options = new Html5Options();
    html5Options.setAnimateShapes(false);
    html5Options.setAnimateTransitions(false);
    
    pres.save("pres5.html", SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تصدير PowerPoint إلى HTML**

هذا الكود Java يُظهر عملية PowerPoint إلى HTML القياسية:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
```


في هذه الحالة يتم عرض محتوى العرض عبر SVG بالشكل التالي:
```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```


{{% alert title="Note" color="warning" %}} 
عند استخدامك لهذه الطريقة لتصدير PowerPoint إلى HTML، بسبب عرض SVG، لن تكون قادرًا على تطبيق الأنماط أو تحريك عناصر محددة. 
{{% /alert %}}

## **تصدير PowerPoint إلى عرض شرائح HTML5**

**Aspose.Slides** يتيح لك تحويل عرض تقديمي PowerPoint إلى مستند HTML5 تُعرض فيه الشرائح في وضع عرض الشرائح. في هذه الحالة، عند فتح ملف HTML5 الناتج في المتصفح، ترى العرض في وضع عرض الشرائح على صفحة ويب.

هذا الكود Java يوضح عملية تصدير PowerPoint إلى عرض شرائح HTML5:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    Html5Options html5Options = new Html5Options();
    html5Options.setAnimateShapes(true);
    html5Options.setAnimateTransitions(true);

    pres.save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تحويل عرض تقديمي إلى مستند HTML5 مع التعليقات**

التعليقات في PowerPoint هي أداة تسمح للمستخدمين بترك ملاحظات أو ملاحظات على شرائح العرض. هي مفيدة بشكل خاص في المشاريع التعاونية، حيث يمكن لعدة أشخاص إضافة اقتراحاتهم أو ملاحظاتهم إلى عناصر شريحة معينة دون تعديل المحتوى الرئيسي. كل تعليق يظهر اسم المؤلف، مما يسهل تتبع من ترك الملاحظة.

لنفترض أن لدينا عرض تقديمي PowerPoint محفوظ في الملف "sample.pptx".

![تعليقين على شريحة العرض](two_comments_pptx.png)

عند تحويل عرض تقديمي PowerPoint إلى مستند HTML5، يمكنك بسهولة تحديد ما إذا كنت تريد تضمين التعليقات من العرض في المستند الناتج. للقيام بذلك، يجب تحديد معلمات عرض التعليقات في طريقة `getNotesCommentsLayouting` من فئة [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides.html5options/) .

الكود التالي يحول عرضًا تقديميًا إلى مستند HTML5 مع عرض التعليقات إلى يمين الشرائح.
```java
Html5Options html5Options = new Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```


مستند "output.html" موضح في الصورة أدناه.

![التعليقات في مستند HTML5 الناتج](two_comments_html5.png)

## **FAQ**

**هل يمكنني التحكم فيما إذا كانت رسوميات الكائنات وانتقالات الشرائح ستعمل في HTML5؟**

نعم، يوفر HTML5 خيارات منفصلة لتمكين أو تعطيل [shape animations](https://reference.aspose.com/slides/androidjava/com.aspose.slides.html5options/#setAnimateShapes-boolean-) و[slide transitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides.html5options/#setAnimateTransitions-boolean-).

**هل دعم إخراج التعليقات متوفر، وأين يمكن وضعها بالنسبة للشفرة؟**

نعم، يمكن إضافة التعليقات في HTML5 وتحديد موقعها (على سبيل المثال، إلى يمين الشريحة) من خلال [layout settings](https://reference.aspose.com/slides/androidjava/com.aspose.slides.html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) للملاحظات والتعليقات.

**هل يمكنني تخطي الروابط التي تستدعي JavaScript لأسباب أمنية أو متعلقة بـ CSP؟**

نعم، هناك [setting](https://reference.aspose.com/slides/androidjava/com.aspose.slides.saveoptions/#setSkipJavaScriptLinks-boolean-) يتيح لك تخطي الروابط التي تحتوي على استدعاءات JavaScript أثناء الحفظ. هذا يساعد على الامتثال لسياسات الأمان الصارمة.