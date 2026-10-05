---
title: تحويل العروض إلى HTML5 باستخدام JavaScript
linktitle: العرض إلى HTML5
type: docs
weight: 40
url: /ar/nodejs-java/export-to-html5/
keywords:
- PowerPoint إلى HTML5
- OpenDocument إلى HTML5
- العرض إلى HTML5
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
- Node.js
- JavaScript
- Aspose.Slides
description: "تصدير عروض PowerPoint وOpenDocument إلى HTML5 مستجيب باستخدام Aspose.Slides لـ Node.js. الحفاظ على التنسيق والرسوم المتحركة والتفاعلية."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل عروض PowerPoint إلى HTML5 باستخدام Aspose.Slides لـ Node.js عبر Java. وتغطي التصدير الأساسي، والتحكم في رسومات الشكل المتحركة وانتقالات الشرائح، وتخطيط التعليقات. كما تقارن ناتج HTML5 مع ناتج SVG المستخدم في تصدير HTML القياسي.

## **تصدير PowerPoint إلى HTML5**

يقوم المثال التالي بتحميل عرض تقديمي من دليل العمل وحفظه بصيغة HTML5. يستخدم إعدادات التصدير الافتراضية؛ المثال التالي يوضح كيفية التحكم في تشغيل الرسوم المتحركة بشكل صريح. استبدل مسار الإدخال بالمسار الخاص بالعرض التقديمي الخاص بك.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres.html", aspose.slides.SaveFormat.Html5);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
بالإضافة إلى مستند HTML، يكتب التصدير ملفات CSS و JavaScript الداعمة لتصميم الشرائح والرسوم المتحركة والتأثيرات والتنقل. احتفظ بهذه الملفات مع مستند HTML عند نقل أو نشر الناتج. كما يقوم الصفحة المولدة بتحميل jQuery و Anime.js من شبكات CDN العامة؛ بدونها لا يعمل تنقل الشرائح والرسوم المتحركة.
{{% /alert %}}

للتصدير دون تشغيل رسومات الشكل المتحركة أو انتقالات الشرائح، مرّر `false` إلى [setAnimateShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) و[setAnimateTransitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-) في [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/). هذه الإعدادات مستقلة، لذا يمكنك تمكين أحدها بينما تعطل الآخر. يصدّر المثال العرض التقديمي مع تعطيل نوعي الرسوم المتحركة في الصفحة المولدة.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setAnimateShapes(false);
html5Options.setAnimateTransitions(false);

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **تصدير PowerPoint إلى HTML**

يستخدم تصدير HTML القياسي نهجًا مختلفًا في العرض: يتم تمثيل محتوى الشريحة بـ SVG داخل صفحة HTML. يقوم المثال التالي بتحويل عرض تقديمي إلى مستند HTML باستخدام هذا النهج في العرض.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres.html", aspose.slides.SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

يسلط التنسيق المبسط أدناه الضوء على هيكل الصفحة المولدة. عنصر SVG يحتوي على محتوى الشريحة المرسوم؛ نص العنصر النائب يمثل ذلك المحتوى وليس إخراجًا حرفيًا من التصدير.

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
التصدير القائم على SVG لا يُظهر أشكال PowerPoint كعناصر HTML منفردة. استخدم تصدير HTML5 عندما تحتاج إلى خيارات رسومات الشكل المتحركة وانتقالات الشرائح الموضحة في هذه المقالة.
{{% /alert %}}

## **تصدير PowerPoint إلى عرض شرائح HTML5**

يُنتج تصدير HTML5 صفحة لعرض وتنقل شرائح العرض التقديمي في المتصفح. يُمكّن هذا المثال كلً من [setAnimateShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) و[setAnimateTransitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-) حتى يتمكن عرض الشرائح المُصدّر من تشغيل التأثيرات من العرض التقديمي الأصلي.

استخدم عرضًا تقديميًا يحتوي بالفعل على رسومات شكل متحركة وانتقالات شرائح لرؤية تأثير هذه الإعدادات. تمكينها لا يضيف تأثيرات جديدة إلى الشرائح التي لا تحتوي على أي منها. بعد التصدير، افتح مستند HTML5 المُولد في متصفح مع توفر ملفاته الداعمة.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setAnimateShapes(true);
html5Options.setAnimateTransitions(true);

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("HTML5-slide-view.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **تحويل عرض تقديمي إلى مستند HTML5 مع تعليقات**

يمكنك تضمين تعليقات الشرائح الموجودة في ناتج HTML5 بحيث يمكن للقراء رؤية الملاحظات بجانب محتوى الشريحة. يتوقع المثال في هذا القسم أن يحتوي العرض التقديمي المصدر على تعليقات، كما هو موضح أدناه. يصدر تلك التعليقات؛ لا ينشئ تعليقات جديدة.

![تعليقان على شريحة العرض التقديمي](two_comments_pptx.png)

مرّر كائن [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notescommentslayoutingoptions/) إلى طريقة [setSlidesLayoutOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setSlidesLayoutOptions-aspose.slides.ISlidesLayoutOptions-) في [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/). استخدم [setCommentsPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-) لاختيار `Right` من تعداد [CommentsPositions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentspositions/) لتحديد وضع التعليقات إلى يمين كل شريحة.

يصدّر المثال التالي العرض التقديمي إلى HTML5 مع تخطيط التعليقات هذا. العرض التقديمي بدون تعليقات لن يحتوي على نص تعليق لعرضه.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);

const html5Options = new aspose.slides.Html5Options();
html5Options.setSlidesLayoutOptions(layoutOptions);

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

تظهر الصورة أدناه مستند HTML5 المُصدر مع عرض التعليقات بجانب الشريحة.

![التعليقات في مستند HTML5 الناتج](two_comments_html5.png)

## **استبعاد الروابط التشعبية JavaScript أثناء التصدير**

افترض أن `hyperlinks.pptx` يحتوي على نص مرتبط بهدف `javascript:alert('Hello')` ورابط عادي `https://example.com/`. لاستبعاد الرابط التشعبي JavaScript أثناء التصدير، مرّر `true` إلى [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-). القيمة الافتراضية هي `false`، لذا لا يتم تصفية هذه الروابط إلا إذا مكنت الخيار.

يقوم المثال التالي بتحميل العرض التقديمي من دليل العمل ويصدّره باستخدام [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setSkipJavaScriptLinks(true);

const presentation = new aspose.slides.Presentation("hyperlinks.pptx");
try {
    presentation.save("filtered-html5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

يحذف الملف المُصدّر رابط JavaScript التشعبي مع الحفاظ على نصه والرابط HTTPS العادي. يبقى العرض التقديمي الأصلي دون تغيير.

يقوم هذا الخيار بفلترة روابط JavaScript التشعبية؛ ولا يزيل جميع النصوص البرمجية أو المحتوى النشط الآخر، ولا يضمن الامتثال لتوجيه سياسات الأمان (CSP). على سبيل المثال، لا يزال ناتج HTML5 يتضمن نصوصًا للانتقال بين الشرائح والرسوم المتحركة.

## **الأسئلة الشائعة**

**هل يمكنني التحكم فيما إذا كانت رسوميات الكائنات وانتقالات الشرائح ستُشغَّل في HTML5؟**

نعم، يوفر تصدير HTML5 خيارات منفصلة لتمكين أو تعطيل [shape animations](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) و[slide transitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-).

**هل تدعم التعليقات، وأين يمكن وضعها بالنسبة للشريحة؟**

نعم، يمكن تضمين التعليقات الموجودة في ناتج HTML5 وتحديد موضعها (على سبيل المثال، إلى يمين الشريحة) عبر [layout settings](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setSlidesLayoutOptions-aspose.slides.ISlidesLayoutOptions-).

**هل يمكنني تخطي الروابط التي تستدعي JavaScript لأسباب أمنية أو لتوافق مع CSP؟**

نعم، يتيح لك إعداد [setSkipJavaScriptLinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) تخطي الروابط التشعبية التي تحتوي على استدعاءات JavaScript أثناء الحفظ. القيمة الافتراضية هي `false`. راجع [استبعاد الروابط التشعبية JavaScript أثناء التصدير](/slides/ar/nodejs-java/export-to-html5/#exclude-javascript-hyperlinks-during-export) للحصول على مثال لتصدير HTML5 ونطاق الفلتر. هذا الإعداد لا يزيل JavaScript المستخدم من قبل عارض HTML5 للتنقل والرسوم المتحركة.