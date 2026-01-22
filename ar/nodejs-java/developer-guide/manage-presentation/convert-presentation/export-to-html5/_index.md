---
title: تحويل العروض التقديمية إلى HTML5 باستخدام JavaScript
linktitle: العرض التقديمي إلى HTML5
type: docs
weight: 40
url: /ar/nodejs-java/export-to-html5/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "تصدير عروض PowerPoint و OpenDocument إلى HTML5 متجاوب باستخدام Aspose.Slides لـ Node.js. الحفاظ على التنسيق، الرسوم المتحركة، والتفاعل."
---

Aspose.Slides يدعم تصدير HTML5. عملية التصدير إلى HTML5 هنا تتيح لك تحويل PowerPoint إلى HTML دون ملحقات أو تبعيات ويب. بهذه الطريقة، باستخدام القوالب الخاصة بك، يمكنك تطبيق خيارات مرنة جدًا تُحدِّد عملية التصدير ونتيجة HTML وCSS وJavaScript وخصائص الرسوم المتحركة.

## **Export PowerPoint to HTML5**

هذا الكود JavaScript يوضح كيفية تصدير عرض تقديمي إلى HTML5 دون ملحقات ويب وتبعيات:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.html", aspose.slides.SaveFormat.Html5);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" %}} 
في هذه الحالة ستحصل على HTML نظيف. 
{{% /alert %}}

قد ترغب في تحديد إعدادات للرسوم المتحركة للأشكال وانتقالات الشرائح بهذه الطريقة:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var html5Options = new aspose.slides.Html5Options();
    html5Options.setAnimateShapes(false);
    html5Options.setAnimateTransitions(false);
    pres.save("pres5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Export PowerPoint to HTML**

هذا الكود JavaScript يوضح عملية تحويل PowerPoint إلى HTML القياسية:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.html", aspose.slides.SaveFormat.Html);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


في هذه الحالة يتم عرض محتوى العرض التقديمي عبر SVG بالشكل التالي:
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
عند استخدامك لهذه الطريقة لتصدير PowerPoint إلى HTML، بسبب عرض SVG، لن تتمكن من تطبيق الأنماط أو تحريك عناصر محددة. 
{{% /alert %}}

## **Export PowerPoint to HTML5 Slide View**

**Aspose.Slides** يتيح لك تحويل عرض تقديمي PowerPoint إلى مستند HTML5 تُعرض فيه الشرائح في وضعية عرض الشرائح. في هذه الحالة، عندما تفتح ملف HTML5 الناتج في المتصفح، سترى العرض التقديمي في وضعية عرض الشرائح على صفحة الويب.

هذا الكود JavaScript يوضح عملية تصدير PowerPoint إلى عرض شرائح HTML5:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var html5Options = new aspose.slides.Html5Options();
    html5Options.setAnimateShapes(true);
    html5Options.setAnimateTransitions(true);
    pres.save("HTML5-slide-view.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Convert a Presentation to an HTML5 Document with Comments**

التعليقات في PowerPoint هي أداة تسمح للمستخدمين بترك ملاحظات أو ملاحظات على شرائح العرض. تكون مفيدة بشكل خاص في المشاريع التعاونية، حيث يمكن لعدة أشخاص إضافة اقتراحاتهم أو ملاحظاتهم إلى عناصر شريحة معينة دون تعديل المحتوى الرئيسي. كل تعليق يُظهر اسم المؤلف، مما يسهل تتبع من ترك الملاحظة.

لنفرض أن لدينا عرض تقديمي PowerPoint محفوظ في الملف "sample.pptx".

![Two comments on the presentation slide](two_comments_pptx.png)

عند تحويل عرض تقديمي PowerPoint إلى مستند HTML5، يمكنك بسهولة تحديد ما إذا كان سيتم تضمين التعليقات من العرض في المستند الناتج. للقيام بذلك، تحتاج إلى تحديد معلمات العرض للتعليقات في الخاصية `notes_comments_layouting` من فئة [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/).

المثال التالي يحول عرضًا تقديميًا إلى مستند HTML5 مع عرض التعليقات إلى يمين الشرائح.
```javascript
let html5Options = new aspose.slides.Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(aspose.slides.CommentsPositions.Right);

let presentation = new aspose.slides.Presentation("sample.pptx");
presentation.save("output.html", aspose.slides.SaveFormat.Html5, html5Options);
presentation.dispose();
```


المستند "output.html" موضح في الصورة أدناه.

![The comments in the output HTML5 document](two_comments_html5.png)

## **FAQ**

**Can I control whether object animations and slide transitions will play in HTML5?**

نعم، يوفر HTML5 خيارات منفصلة لتمكين أو تعطيل [shape animations](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/setanimateshapes/) و[slide transitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/setanimatetransitions/).

**Is the output of comments supported, and where can they be placed relative to the slide?**

نعم، يمكن إضافة التعليقات في HTML5 وتحديد موقعها (على سبيل المثال، إلى يمين الشريحة) عبر [layout settings](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setNotesCommentsLayouting) للملاحظات والتعليقات.

**Can I skip links that invoke JavaScript for security or CSP reasons?**

نعم، هناك [setting](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) يسمح بتخطي الروابط التي تستدعي JavaScript أثناء الحفظ. هذا يساعد في الامتثال لسياسات الأمان الصارمة.