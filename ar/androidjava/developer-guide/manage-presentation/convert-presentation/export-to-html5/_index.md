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
description: "تصدير عروض PowerPoint و OpenDocument إلى HTML5 متجاوب باستخدام Aspose.Slides لأجهزة Android عبر Java. الحفاظ على التنسيق، والتحريكات، والتفاعل."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل عروض PowerPoint التقديمية إلى HTML5 باستخدام Aspose.Slides. وتغطي تصدير HTML5 الأساسي دون امتدادات ويب أو تبعيات إضافية، بالإضافة إلى خيارات التحكم في تحريك الأشكال وانتقالات الشرائح. كما تعرض العملية القياسية لتصدير PowerPoint إلى HTML، وتوضح كيفية إنشاء مخرجات HTML5 في وضع عرض الشرائح، وتظهر كيفية تضمين التعليقات في المستند المُصدَّر عبر تكوين تخطيطها.

## **تصدير PowerPoint إلى HTML5**

يوضح هذا الكود بلغة Java كيفية تصدير عرض تقديمي إلى HTML5 دون امتدادات ويب أو تبعيات:

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

قد ترغب في تحديد إعدادات تحريك الأشكال وانتقالات الشرائح بهذه الطريقة:

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

يوضح هذا الكود بلغة Java العملية القياسية لتصدير PowerPoint إلى HTML:

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

{{% alert title="Note" color="warning" %}} 
عند استخدام هذه الطريقة لتصدير PowerPoint إلى HTML، وبسبب عرض SVG، لن تتمكن من تطبيق الأنماط أو تحريك العناصر المحددة. 
{{% /alert %}}

## **تصدير PowerPoint إلى عرض شرائح HTML5**

يسمح لك **Aspose.Slides** بتحويل عرض PowerPoint التقديمي إلى مستند HTML5 يتم عرض الشرائح فيه في وضع عرض الشرائح. في هذه الحالة، عند فتح ملف HTML5 الناتج في المتصفح، سترى العرض التقديمي في وضع عرض الشرائح على صفحة ويب.

يوضح هذا الكود بلغة Java عملية تصدير PowerPoint إلى عرض شرائح HTML5:

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

## **تحويل عرض تقديمي إلى مستند HTML5 مع التعليقات**

التعليقات في PowerPoint هي أداة تتيح للمستخدمين ترك ملاحظات أو ملاحظات حول شرائح العرض التقديمي. وهي مفيدة بشكل خاص في المشاريع التعاونية، حيث يمكن للعديد من الأشخاص إضافة اقتراحاتهم أو ملاحظاتهم إلى عناصر شريحة معينة دون تعديل المحتوى الرئيسي. كل تعليق يظهر اسم المؤلف، مما يسهل تتبع من قام بترك الملاحظة.

لنفترض أن لدينا عرض PowerPoint التالي محفوظًا في ملف "sample.pptx".

![تعليقين على شريحة العرض التقديمي](two_comments_pptx.png)

عند تحويل عرض PowerPoint إلى مستند HTML5، يمكنك بسهولة تحديد ما إذا كنت تريد تضمين التعليقات من العرض في المستند الناتج. للقيام بذلك، يلزم تمرير معلمات عرض التعليقات إلى طريقة `setSlidesLayoutOptions` في فئة [Html5Options](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/html5options/).

يوضح المثال البرمجي التالي كيفية تحويل عرض تقديمي إلى مستند HTML5 مع عرض التعليقات إلى يمين الشرائح.
```java
import com.aspose.slides.*;

NotesCommentsLayoutingOptions layoutingOptions = new NotesCommentsLayoutingOptions();
layoutingOptions.setCommentsPosition(CommentsPositions.Right);

Html5Options html5Options = new Html5Options();
html5Options.setSlidesLayoutOptions(layoutingOptions);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

يتم عرض مستند "output.html" في الصورة أدناه.

![التعليقات في مستند HTML5 الناتج](two_comments_html5.png)

## **الأسئلة الشائعة**

### هل يمكنني التحكم فيما إذا كانت تحريكات الكائنات وانتقالات الشرائح ستعمل في HTML5؟
نعم، يوفر HTML5 خيارات منفصلة لتمكين أو تعطيل [تحريكات الأشكال](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) و[انتقالات الشرائح](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).

### هل يتم دعم مخرجات التعليقات، وأين يمكن وضعها بالنسبة للشرائح؟
نعم، يمكن إضافة التعليقات في HTML5 وتحديد موضعها (على سبيل المثال، إلى يمين الشريحة) عبر [إعدادات التخطيط](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) للملاحظات والتعليقات.

### هل يمكنني تخطي الروابط التي تستدعي JavaScript لأسباب أمنية أو متعلقة بسياسة المحتوى (CSP)؟
نعم، هناك [إعداد](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) يسمح بتخطي الروابط ذات استدعاءات JavaScript أثناء الحفظ. يساعد ذلك في الامتثال لسياسات الأمان الصارمة.