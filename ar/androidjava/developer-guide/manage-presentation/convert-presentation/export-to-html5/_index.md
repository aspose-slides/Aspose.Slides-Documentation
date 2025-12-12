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
description: "تصدير عروض PowerPoint و OpenDocument التقديمية إلى HTML5 مستجيب باستخدام Aspose.Slides لنظام Android عبر Java. الحفاظ على التنسيق والرسوم المتحركة والتفاعلية."
---

{{% alert title="Info" color="info" %}}

في [Aspose.Slides 21.9](/slides/ar/androidjava/aspose-slides-for-java-21-9-release-notes/)، أضفنا دعمًا لتصدير HTML5.

{{% /alert %}} 

تتيح لك عملية التصدير إلى HTML5 هنا تحويل PowerPoint إلى HTML بدون ملحقات ويب أو تبعيات. بهذه الطريقة، باستخدام القوالب الخاصة بك، يمكنك تطبيق خيارات مرنة جدًا تُعرّف عملية التصدير والـ HTML و CSS و JavaScript وسمات الرسوم المتحركة الناتجة. 

## **Export PowerPoint to HTML5**

يعرض هذا الكود بلغة Java كيفية تصدير عرض تقديمي إلى HTML5 بدون ملحقات ويب وتبعيات:
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

قد ترغب في تحديد إعدادات رسوم متحركة للأشكال وانتقالات الشرائح بهذه الطريقة:
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


## **Export PowerPoint to HTML**

يعرض هذا الكود بلغة Java عملية PowerPoint القياسية إلى HTML:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
```


في هذه الحالة يتم عرض محتوى العرض التقديمي عبر SVG على الشكل التالي:
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

عند استخدامك لهذه الطريقة لتصدير PowerPoint إلى HTML، بسبب عرض SVG، لن تتمكن من تطبيق الأنماط أو تحريك عناصر معينة. 

{{% /alert %}}

## **Export PowerPoint to HTML5 Slide View**

**Aspose.Slides** يتيح لك تحويل عرض PowerPoint إلى مستند HTML5 تُعرض فيه الشرائح في وضع عرض الشرائح. في هذه الحالة، عند فتح ملف HTML5 الناتج في المتصفح، ترى العرض التقديمي في وضع عرض الشرائح على صفحة الويب. 

يعرض هذا الكود بلغة Java عملية تصدير PowerPoint إلى عرض شرائح HTML5:
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


## **Convert a Presentation to an HTML5 Document with Comments**

تعليقات PowerPoint هي أداة تتيح للمستخدمين ترك ملاحظات أو ملاحظات على شرائح العرض. وهي مفيدة بشكل خاص في المشاريع التعاونية، حيث يمكن لعدة أشخاص إضافة اقتراحاتهم أو ملاحظاتهم إلى عناصر شريحة معينة دون تعديل المحتوى الرئيسي. كل تعليق يُظهر اسم المؤلف، مما يسهل تتبع من ترك الملاحظة.

لنفترض أن لدينا عرض PowerPoint التالي محفوظًا في الملف "sample.pptx".

![تعليقان على شريحة العرض التقديمي](two_comments_pptx.png)

عند تحويل عرض PowerPoint إلى مستند HTML5، يمكنك بسهولة تحديد ما إذا كنت تريد تضمين التعليقات من العرض في المستند الناتج. للقيام بذلك، تحتاج إلى تحديد معلمات عرض التعليقات في طريقة `getNotesCommentsLayouting` من الفئة [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/).

المثال التالي يوضح تحويل عرض تقديمي إلى مستند HTML5 مع عرض التعليقات إلى يمين الشرائح.
```java
Html5Options html5Options = new Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```


يظهر مستند "output.html" في الصورة أدناه.

![التعليقات في مستند HTML5 الناتج](two_comments_html5.png)

## **FAQ**

**هل يمكنني التحكم فيما إذا كانت رسوم تحريك الكائنات وانتقالات الشرائح ستعمل في HTML5؟**

نعم، يوفر HTML5 خيارات منفصلة لتمكين أو تعطيل [shape animations](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) و [slide transitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).

**هل يتم دعم إخراج التعليقات، وأين يمكن وضعها بالنسبة للشرائح؟**

نعم، يمكن إضافة التعليقات في HTML5 وتحديد موقعها (مثلاً إلى يمين الشريحة) عبر [layout settings](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) للملاحظات والتعليقات.

**هل يمكنني تخطي الروابط التي تستدعي JavaScript لأسباب أمنية أو سياسات CSP؟**

نعم، هناك [setting](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) يسمح بتخطي الروابط التي تحتوي على استدعاءات JavaScript أثناء الحفظ. يساعد ذلك في الالتزام بسياسات الأمان الصارمة.