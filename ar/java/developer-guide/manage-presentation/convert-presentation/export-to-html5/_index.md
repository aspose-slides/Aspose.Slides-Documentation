---
title: تحويل العروض التقديمية إلى HTML5 في Java
linktitle: العرض التقديمي إلى HTML5
type: docs
weight: 40
url: /ar/java/export-to-html5/
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
- Java
- Aspose.Slides
description: "تصدير عروض PowerPoint و OpenDocument إلى HTML5 استجابي باستخدام Aspose.Slides للـ Java. الحفاظ على التنسيق، والرسوم المتحركة، والتفاعلية."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل عروض PowerPoint إلى HTML5 باستخدام Aspose.Slides. تغطي التصدير الأساسي إلى HTML5 دون ملحقات ويب أو تبعيات إضافية، بالإضافة إلى خيارات التحكم في رسوميات الأشكال وانتقالات الشرائح. كما تُظهر العملية القياسية لتصدير PowerPoint إلى HTML، وتوضح كيفية إنشاء مخرجات HTML5 في وضع عرض الشرائح، وتبرهن على كيفية تضمين التعليقات في المستند المُصدّر عن طريق تكوين تخطيطها.

## **تصدير PowerPoint إلى HTML5**

يظهر هذا الكود بلغة Java كيفية تصدير عرض تقديمي إلى HTML5 دون ملحقات ويب وتبعيات:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html5);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}}
في هذه الحالة، ستحصل على HTML نظيف.
{{% /alert %}}

قد ترغب في تحديد إعدادات رسوميات الأشكال وانتقالات الشرائح بهذه الطريقة:

```java
import com.aspose.slides.*;

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

يوضح هذا المثال بلغة Java العملية القياسية لتصدير PowerPoint إلى HTML:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
```

في هذه الحالة، يتم عرض محتوى العرض التقديمي عبر SVG على الشكل التالي:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="ملاحظة" color="warning" %}}
عند استخدام هذه الطريقة لتصدير PowerPoint إلى HTML، بسبب عرض SVG، لن تكون قادرًا على تطبيق الأنماط أو تحريك عناصر محددة.
{{% /alert %}}

## **تصدير PowerPoint إلى عرض شريحة HTML5**

**Aspose.Slides** يتيح لك تحويل عرض PowerPoint إلى مستند HTML5 يتم فيه عرض الشرائح في وضع عرض الشريحة. في هذه الحالة، عندما تفتح ملف HTML5 الناتج في المتصفح، ترى العرض التقديمي في وضع عرض الشريحة على صفحة الويب.

يظهر هذا الكود بلغة Java عملية تصدير PowerPoint إلى عرض شريحة HTML5:

```java
import com.aspose.slides.*;

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

## **تحويل العروض التقديمية إلى مستندات HTML5 مع التعليقات**

التعليقات في PowerPoint هي أداة تسمح للمستخدمين بترك ملاحظات أو ملاحظات على شرائح العرض. فهي مفيدة بشكل خاص في المشاريع التعاونية، حيث يمكن لأكثر من شخص إضافة اقتراحاته أو ملاحظاته إلى عناصر شريحة معينة دون تعديل المحتوى الرئيسي. كل تعليق يظهر اسم المؤلف، مما يسهل تتبع من ترك الملاحظة.

لنفترض أن لدينا عرض PowerPoint محفوظ في الملف "sample.pptx".

![تعليقان على شريحة العرض التقديمي](two_comments_pptx.png)

عند تحويل عرض PowerPoint إلى مستند HTML5، يمكنك بسهولة تحديد ما إذا كنت تريد تضمين التعليقات من العرض في المستند الناتج. للقيام بذلك، مرر معلمات عرض التعليقات إلى طريقة `setSlidesLayoutOptions` في فئة [Html5Options](https://reference.aspose.com/slides/ar/java/com.aspose.slides/html5options/) .

مثال الكود التالي يحول عرضًا إلى مستند HTML5 مع عرض التعليقات إلى يمين الشرائح.
```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();

NotesCommentsLayoutingOptions layoutingOptions = new NotesCommentsLayoutingOptions();
layoutingOptions.setCommentsPosition(CommentsPositions.Right);
html5Options.setSlidesLayoutOptions(layoutingOptions);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

المستند "output.html" معروض في الصورة أدناه.

![التعليقات في مستند HTML5 الناتج](two_comments_html5.png)

## **الأسئلة المتكررة**

### هل يمكنني التحكم فيما إذا كانت رسوميات الكائنات وانتقالات الشرائح ستعمل في HTML5؟

نعم، يوفر HTML5 خيارات منفصلة لتمكين أو تعطيل [رسوميات الأشكال](https://reference.aspose.com/slides/ar/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) و[انتقالات الشرائح](https://reference.aspose.com/slides/ar/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).

### هل تدعم مخرجات التعليقات، وأين يمكن وضعها بالنسبة إلى الشريحة؟

نعم، يمكن إضافة التعليقات في HTML5 وتحديد موقعها (مثلاً إلى يمين الشريحة) عبر [إعدادات التخطيط](https://reference.aspose.com/slides/ar/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) للملاحظات والتعليقات.

### هل يمكنني تخطي الروابط التي تستدعي JavaScript لأسباب أمنية أو بسبب سياسات CSP؟

نعم، هناك [إعداد](https://reference.aspose.com/slides/ar/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) يسمح لك بتخطي الروابط ذات استدعاءات JavaScript أثناء الحفظ. يساعد هذا في الامتثال للسياسات الأمنية الصارمة.