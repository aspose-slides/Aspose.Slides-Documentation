---
title: تحويل العروض التقديمية إلى HTML5 في Java
linktitle: العرض التقديمي إلى HTML5
type: docs
weight: 40
url: /ar/java/export-to-html5/
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
- Java
- Aspose.Slides
description: "تصدير عروض PowerPoint و OpenDocument إلى HTML5 متجاوب باستخدام Aspose.Slides for Java. الحفاظ على التنسيق والرسوم المتحركة والتفاعل."
---
## **نظرة عامة**

هذه المقالة تشرح كيفية تحويل عروض PowerPoint إلى HTML5 باستخدام Aspose.Slides for Java. تغطي التصدير الأساسي، والتحكم في رسوميات الأشكال الانتقالية والانتقالات بين الشرائح، وتنسيق التعليقات. كما تقارن مخرجات HTML5 بمخرجات SVG القياسية لتصدير HTML.

## **تصدير PowerPoint إلى HTML5**

يقوم المثال التالي بتحميل عرض تقديمي من دليل العمل ويحفظه بتنسيق HTML5. يستخدم إعدادات التصدير الافتراضية؛ المثال التالي يوضح كيفية التحكم في تشغيل الرسوم المتحركة بشكل صريح. استبدل مسار الإدخال بالمسار إلى عرضك التقديمي.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html5);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
إلى جانب مستند HTML، يكتب التصدير ملفات CSS وJavaScript الداعمة لتنسيق الشرائح والرسوم المتحركة والتأثيرات والملاحة. احتفظ بهذه الملفات مع مستند HTML عند نقل أو نشر النتيجة. كما يحمل الصفحة المُولدة مكتبة jQuery وAnime.js من شبكات CDN العامة؛ بدونها لا تعمل تنقل الشرائح والرسوم المتحركة.
{{% /alert %}}

للتصدير دون تشغيل رسوميات الشكل أو الانتقالات بين الشرائح، مرّر `false` إلى [setAnimateShapes](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) و[setAnimateTransitions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) في [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/). هذه الإعدادات مستقلة، لذا يمكنك تفعيل واحدة وتعطيل الأخرى. المثال يصدر العرض التقديمي مع تعطيل كلا النوعين من الرسوم المتحركة في الصفحة المُولدة.

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setAnimateShapes(false);
html5Options.setAnimateTransitions(false);

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres5.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **تصدير PowerPoint إلى HTML**

يستخدم تصدير HTML القياسي نهج عرض مختلف: يُمثل محتوى الشريحة بواسطة SVG داخل صفحة HTML. يقوم المثال التالي بتحويل عرض تقديمي إلى مستند HTML باستخدام هذا النهج.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

يظهر الترميز المبسط أدناه بنية الصفحة المُولدة. عنصر SVG يحتوي على محتوى الشريحة المُرسم؛ النص النائب يمثل ذلك المحتوى وليس مخرجات التصدير الحرفية.

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Warning" color="warning" %}}
تصدير SVG لا يكشف عن أشكال PowerPoint كعناصر HTML منفصلة. استخدم تصدير HTML5 عندما تحتاج إلى خيارات رسوميات الشكل وانتقالات الشرائح الموضحة في هذه المقالة.
{{% /alert %}}

## **تصدير PowerPoint إلى عرض شرائح HTML5**

يولد تصدير HTML5 صفحة لعرض وتنقل شرائح العرض التقديمي في المتصفح. يُمكّن هذا المثال كل من [setAnimateShapes](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) و[setAnimateTransitions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) لتتمكن عرض الشرائح المُصدّر من تشغيل التأثيرات من العرض الأصلي.

استخدم عرضًا تقديميًا يحتوي بالفعل على رسوميات الشكل وانتقالات الشرائح لرؤية تأثير هذه الإعدادات. تمكينها لا يضيف تأثيرات جديدة إلى الشرائح التي لا تحتوي على أي منها. بعد التصدير، افتح مستند HTML5 المُولّد في متصفح مع توفر الملفات الداعمة.

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setAnimateShapes(true);
html5Options.setAnimateTransitions(true);

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **تحويل عرض تقديمي إلى مستند HTML5 مع التعليقات**

يمكنك تضمين تعليقات الشرائح الموجودة في مخرجات HTML5 حتى يتمكن القارئ من رؤية الملاحظات بجانب محتوى الشريحة. المثال في هذا القسم يتوقع أن يحتوي العرض الأصلي على تعليقات، كما هو موضح أدناه. يقوم بتصدير تلك التعليقات؛ لا ينشئ تعليقات جديدة.

![تعليقان على شريحة العرض التقديمي](two_comments_pptx.png)

مرّر كائن [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/notescommentslayoutingoptions/) إلى طريقة [setSlidesLayoutOptions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) في [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/). استخدم [setCommentsPosition](https://reference.aspose.com/slides/java/com.aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-) لتحديد `Right` من تعداد [CommentsPositions](https://reference.aspose.com/slides/java/com.aspose.slides/commentspositions/) لتوضيح وضع التعليقات إلى يمين كل شريحة.

يقوم المثال التالي بتصدير العرض إلى HTML5 مع تخطيط التعليقات هذا. العرض التقديمي بدون تعليقات لن يحتوي على نص تعليق للعرض.

```java
import com.aspose.slides.*;

NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
layoutOptions.setCommentsPosition(CommentsPositions.Right);

Html5Options html5Options = new Html5Options();
html5Options.setSlidesLayoutOptions(layoutOptions);

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

الصورة أدناه توضح مستند HTML5 المُصدّر مع عرض التعليقات بجانب الشريحة.

![التعليقات في مستند HTML5 الناتج](two_comments_html5.png)

## **استبعاد الروابط التشعبية JavaScript أثناء التصدير**

افترض أن `hyperlinks.pptx` يحتوي على نص مرتبط بوجهة `javascript:alert('Hello')` ورابط عادي `https://example.com/`. لاستبعاد الرابط التشعبي JavaScript أثناء التصدير، مرّر `true` إلى [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-). الوضع الافتراضي هو `false`، لذا لا يتم تصفية هذه الروابط ما لم تمكّن الخيار.

يقوم المثال التالي بتحميل العرض التقديمي من دليل العمل وتصديره باستخدام [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/):

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setSkipJavaScriptLinks(true);

Presentation presentation = new Presentation("hyperlinks.pptx");
try {
    presentation.save("filtered-html5.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

يستثني الملف المُصدّر الرابط التشعبي JavaScript مع الإبقاء على نصه والرابط HTTPS العادي. يبقى العرض الأصلي دون تغيير.

يقوم هذا الخيار بتصفية الروابط التشعبية JavaScript؛ لكنه لا يزيل جميع السكريبتات أو المحتوى النشط الآخر، ولا يضمن الامتثال لـ CSP. على سبيل المثال، لا يزال مخرج HTML5 يتضمن سكريبتات لتنقل الشرائح والرسوم المتحركة.

## **الأسئلة الشائعة**

**هل يمكنني التحكم فيما إذا كانت رسوميات الكائنات وانتقالات الشرائح ستعمل في HTML5؟**

نعم، يوفر تصدير HTML5 خيارات منفصلة لتمكين أو تعطيل [رسوميات الشكل](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) و[انتقالات الشرائح](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).

**هل يتم دعم التعليقات، وأين يمكن وضعها بالنسبة للشريحة؟**

نعم، يمكن تضمين التعليقات الموجودة في مخرجات HTML5 وتحديد موضعها (مثلاً إلى يمين الشريحة) من خلال [إعدادات التخطيط](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) للملاحظات والتعليقات.

**هل يمكنني تخطي الروابط التي تستدعي JavaScript لأسباب أمنية أو بسبب CSP؟**

نعم، يتيح لك إعداد [setSkipJavaScriptLinks](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) تخطي الروابط التشعبية التي تحتوي على استدعاءات JavaScript أثناء الحفظ. الوضع الافتراضي هو `false`. راجع [استبعاد الروابط التشعبية JavaScript أثناء التصدير](/slides/ar/java/export-to-html5/#exclude-javascript-hyperlinks-during-export) للحصول على مثال لتصدير HTML5 ونطاق الفلتر. هذا الإعداد لا يزيل JavaScript المستخدم من قبل عارض HTML5 للتنقل والرسوم المتحركة.