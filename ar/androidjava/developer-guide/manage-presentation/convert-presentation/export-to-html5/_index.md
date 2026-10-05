---
title: تحويل العروض إلى HTML5 على Android
linktitle: عرض تقديمي إلى HTML5
type: docs
weight: 40
url: /ar/androidjava/export-to-html5/
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
- Android
- Java
- Aspose.Slides
description: "تصدير عروض PowerPoint و OpenDocument إلى HTML5 متجاوب باستخدام Aspose.Slides لـ Android عبر Java. الحفاظ على التنسيق والرسوم المتحركة والتفاعل."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل عروض PowerPoint إلى HTML5 باستخدام Aspose.Slides لـ Android عبر Java. تغطي التصدير الأساسي، التحكم في رسومات الأشكال المتحركة وانتقالات الشرائح، وتخطيط التعليقات. كما تقارن مخرجات HTML5 مع المخرجات القائمة على SVG لتصدير HTML القياسي.

## **تصدير PowerPoint إلى HTML5**

المثال التالي يقوم بتحميل عرض تقديمي من دليل العمل ويحفظه بتنسيق HTML5. يستخدم إعدادات التصدير الافتراضية؛ المثال التالي يوضح كيفية التحكم في تشغيل الرسوم المتحركة صراحة. استبدل مسار الإدخال بالمسار إلى عرضك التقديمي.

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
بالإضافة إلى مستند HTML، يقوم التصدير بإنشاء ملفات CSS و JavaScript الداعمة لتنسيق الشرائح، الرسوم المتحركة، التأثيرات، والتنقل. احتفظ بهذه الملفات مع مستند HTML عند نقل أو نشر النتيجة. كما تقوم الصفحة المولدة بتحميل jQuery و Anime.js من شبكات CDN العامة؛ بدونها لا يعمل تنقل الشرائح ولا الرسوم المتحركة.
{{% /alert %}}

للتصدير دون تشغيل رسومات الأشكال المتحركة أو انتقالات الشرائح، مرّر `false` إلى [setAnimateShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) و[setAnimateTransitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) في [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/). هذه الإعدادات مستقلة، لذا يمكنك تمكين واحدة وتعطيل الأخرى. المثال يصدر العرض التقديمي مع تعطيل كلا نوعي الرسوم المتحركة في الصفحة المولدة.

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

يستخدم تصدير HTML القياسي نهجًا مختلفًا في العرض: محتوى الشريحة يُمثل بـ SVG داخل صفحة HTML. المثال التالي يحول عرضًا تقديميًا إلى مستند HTML باستخدام هذا النهج في العرض.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

يوضح العلامة المبسطة أدناه بنية الصفحة المولدة. عنصر SVG يحتوي على محتوى الشريحة المرسوم؛ نص العنصر النائب يمثل ذلك المحتوى وليس ناتج تصدير حرفيًا.

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
التصدير القائم على SVG لا يكشف عن أشكال PowerPoint كعناصر HTML منفصلة. استخدم تصدير HTML5 عندما تحتاج إلى خيارات رسومات الأشكال المتحركة وانتقالات الشرائح الموضحة في هذه المقالة.
{{% /alert %}}

## **تصدير PowerPoint إلى عرض شرائح HTML5**

يولد تصدير HTML5 صفحة لعرض وتنقل شرائح العرض التقديمي في المتصفح. يفعّل هذا المثال كلًا من [setAnimateShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) و[setAnimateTransitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) بحيث يمكن لعرض الشرائح المصدّر تشغيل التأثيرات من العرض المصدر.

استخدم عرضًا تقديميًا يحتوي مسبقًا على رسومات أ形 متحركة وانتقالات شرائح لتلاحظ تأثير هذه الإعدادات. تمكينها لا يضيف تأثيرات جديدة إلى الشرائح التي لا تحتوي على أي منها. بعد التصدير، افتح مستند HTML5 المولّد في متصفح مع توفر ملفاته المساندة.

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

يمكنك تضمين تعليقات الشرائح الحالية في مخرجات HTML5 بحيث يتمكن القراء من رؤية الملاحظات بجانب محتوى الشريحة. المثال في هذا القسم يفترض أن يحتوي العرض المصدر على تعليقات، كما هو موضح أدناه. يقوم بتصدير هذه التعليقات؛ ولا ينشئ تعليقات جديدة.

![تعليقين على شريحة العرض التقديمي](two_comments_pptx.png)

مرّر كائن [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notescommentslayoutingoptions/) إلى طريقة [setSlidesLayoutOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) في [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/). استخدم [setCommentsPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-) لتحديد `Right` من تعداد [CommentsPositions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/commentspositions/) لتضع التعليقات إلى يمين كل شريحة.

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

المثال التالي يصدر العرض التقديمي إلى HTML5 مع تخطيط التعليقات هذا. العرض بدون تعليقات لن يحتوي على نص تعليق للعرض.

![التعليقات في مستند HTML5 الناتج](two_comments_html5.png)

## **استبعاد الروابط JavaScript أثناء التصدير**

افترض أن ملف `hyperlinks.pptx` يحتوي على نص مرتبط بوجهة `javascript:alert('Hello')` ورابط عادي `https://example.com/`. لاستبعاد رابط JavaScript أثناء التصدير، مرّر `true` إلى [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-). القيمة الافتراضية هي `false`، لذا لن تُفلتر هذه الروابط ما لم تقم بتمكين الخيار.

المثال التالي يقوم بتحميل العرض التقديمي من دليل العمل ويصدّره باستخدام [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/):

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

الملف المصدّر يستبعد رابط JavaScript مع الحفاظ على نصه والرابط HTTPS العادي. العرض المصدر يبقى دون تغيير.

هذا الخيار يفلتر روابط JavaScript؛ ولا يزيل جميع السكريبتات أو المحتوى النشط الآخر، ولا يضمن التوافق مع CSP. على سبيل المثال، لا يزال مخرج HTML5 يتضمن سكريبتات لتنقل الشرائح والرسوم المتحركة.

## **الأسئلة المتكررة**

**هل يمكنني التحكم في ما إذا كانت رسوميات الكائنات وانتقالات الشرائح ستعمل في HTML5؟**

نعم، يوفّر تصدير HTML5 خيارات منفصلة لتمكين أو تعطيل [shape animations](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) و[slide transitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).

**هل يتم دعم التعليقات، وأين يمكن وضعها بالنسبة للشريحة؟**

نعم، يمكن تضمين التعليقات الموجودة في مخرجات HTML5 وتحديد موقعها (على سبيل المثال، إلى يمين الشريحة) عبر [layout settings](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) للملاحظات والتعليقات.

**هل يمكنني تخطي الروابط التي تستدعي JavaScript لأسباب أمنية أو متعلقة بـ CSP؟**

نعم، يتيح لك إعداد [setSkipJavaScriptLinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) تخطي الروابط التي تستدعي JavaScript أثناء الحفظ. القيمة الافتراضية هي `false`. راجع [Exclude JavaScript Hyperlinks During Export](/slides/ar/androidjava/export-to-html5/#exclude-javascript-hyperlinks-during-export) للحصول على مثال لتصدير HTML5 ونطاق الفلتر. هذا الإعداد لا يزيل JavaScript المستخدم من قبل عارض HTML5 للتنقل والرسوم المتحركة.