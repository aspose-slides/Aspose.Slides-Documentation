---
title: تصدير إلى HTML5
type: docs
weight: 40
url: /ar/nodejs-java/export-to-html5/
keywords:
- PowerPoint إلى HTML
- الشرائح إلى HTML
- HTML5
- تصدير HTML
- تصدير عرض تقديمي
- تحويل عرض تقديمي
- تحويل الشرائح
- Java
- Aspose.Slides لـ Node.js عبر Java
description: "تصدير PowerPoint إلى HTML5 باستخدام JavaScript"
---

{{% alert title="معلومات" color="info" %}}

في [Aspose.Slides 21.9](/slides/ar/nodejs-java/aspose-slides-for-java-21-9-release-notes/)، قمنا بتنفيذ دعم التصدير إلى HTML5.

{{% /alert %}} 

تسمح لك عملية التصدير إلى HTML5 هنا بتحويل PowerPoint إلى HTML دون ملحقات ويب أو تبعيات. بهذه الطريقة، باستخدام القوالب الخاصة بك، يمكنك تطبيق خيارات مرنة للغاية تحدد عملية التصدير وHTML وCSS وJavaScript وسمات الرسوم المتحركة الناتجة.

## **تصدير PowerPoint إلى HTML5**

يظهر هذا الكود JavaScript كيفية تصدير عرض تقديمي إلى HTML5 دون ملحقات ويب وتبعيات:
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

في هذه الحالة، ستحصل على HTML نظيف. 

{{% /alert %}}

قد ترغب في تحديد إعدادات لرسوم متحركة الأشكال وانتقالات الشرائح بهذه الطريقة:
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


## **تصدير PowerPoint إلى HTML**

يوضح هذا الكود JavaScript العملية القياسية لتصدير PowerPoint إلى HTML:
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


في هذه الحالة، يتم عرض محتوى العرض التقديمي عبر SVG بالشكل التالي:
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

**Aspose.Slides** يتيح لك تحويل عرض تقديمي PowerPoint إلى مستند HTML5 يتم فيه عرض الشرائح في وضع عرض الشرائح. في هذه الحالة، عند فتح ملف HTML5 الناتج في المتصفح، ترى العرض التقديمي في وضع عرض الشرائح على صفحة ويب. 

يظهر هذا الكود JavaScript عملية تصدير PowerPoint إلى عرض شريحة HTML5:
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


## **تحويل عرض تقديمي إلى مستند HTML5 مع التعليقات**

التعليقات في PowerPoint هي أداة تسمح للمستخدمين بترك ملاحظات أو ملاحظات على شرائح العرض التقديمي. وهي مفيدة بشكل خاص في المشاريع التعاونية، حيث يمكن لأكثر من شخص إضافة اقتراحاتهم أو ملاحظاتهم إلى عناصر شريحة معينة دون تعديل المحتوى الرئيسي. كل تعليق يظهر اسم المؤلف، مما يسهل تتبع من ترك الملاحظة.

لنفترض أن لدينا عرض تقديمي PowerPoint محفوظ في الملف "sample.pptx".

![تعليقين على شريحة العرض التقديمي](two_comments_pptx.png)

عند تحويل عرض تقديمي PowerPoint إلى مستند HTML5، يمكنك بسهولة تحديد ما إذا كنت تريد تضمين التعليقات من العرض التقديمي في المستند الناتج. للقيام بذلك، تحتاج إلى تحديد معلمات عرض التعليقات في خاصية `notes_comments_layouting` من فئة [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/).

المثال التالي يوضح تحويل عرض تقديمي إلى مستند HTML5 مع عرض التعليقات إلى يمين الشرائح.
```javascript
let html5Options = new aspose.slides.Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(aspose.slides.CommentsPositions.Right);

let presentation = new aspose.slides.Presentation("sample.pptx");
presentation.save("output.html", aspose.slides.SaveFormat.Html5, html5Options);
presentation.dispose();
```


يتم عرض مستند "output.html" في الصورة أدناه.

![التعليقات في مستند HTML5 الناتج](two_comments_html5.png)

## **الأسئلة المتكررة**

**هل يمكنني التحكم فيما إذا كانت رسومات الكائنات وانتقالات الشرائح ستعمل في HTML5؟**

نعم، يوفر HTML5 خيارات منفصلة لتمكين أو تعطيل [رسومات الأشكال](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/setanimateshapes/) و[انتقالات الشرائح](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/setanimatetransitions/).

**هل يتم دعم إخراج التعليقات، وأين يمكن وضعها بالنسبة للشرائح؟**

نعم، يمكن إضافة التعليقات في HTML5 وتحديد موقعها (على سبيل المثال، إلى يمين الشريحة) من خلال [إعدادات التخطيط](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setNotesCommentsLayouting) للملاحظات والتعليقات.

**هل يمكنني تخطي الروابط التي تستدعي JavaScript لأسباب أمنية أو سياسات CSP؟**

نعم، هناك [إعداد](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) يسمح بتخطي الروابط التي تحتوي على استدعاءات JavaScript أثناء الحفظ. يساعد هذا في الامتثال للسياسات الأمنية الصارمة.