---
title: تصدير إلى HTML5
type: docs
weight: 40
url: /ar/java/export-to-html5/
keywords:
- PowerPoint إلى HTML
- الشرائح إلى HTML
- HTML5
- تصدير HTML
- تصدير العرض التقديمي
- تحويل العرض التقديمي
- تحويل الشرائح
- Java
- Aspose.Slides لـ Java
description: "تصدير PowerPoint إلى HTML5 في Java"
---

{{% alert title="معلومات" color="info" %}}

في [Aspose.Slides 21.9](/slides/ar/java/aspose-slides-for-java-21-9-release-notes/)، قمنا بتنفيذ دعم لتصدير HTML5.

{{% /alert %}} 

تسمح لك عملية التصدير إلى HTML5 هنا بتحويل PowerPoint إلى HTML بدون إضافات ويب أو تبعيات. بهذه الطريقة، باستخدام قوالبك الخاصة، يمكنك تطبيق خيارات مرنة جدًا تحدد عملية التصدير ونتائج HTML وCSS وJavaScript وخصائص الرسوم المتحركة.

## **تصدير PowerPoint إلى HTML5**

يوضح هذا الكود بلغة Java كيفية تصدير عرض تقديمي إلى HTML5 بدون إضافات ويب أو تبعيات:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html5);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

في هذه الحالة، تحصل على HTML نظيف. 

{{% /alert %}}

قد ترغب في تحديد إعدادات لرسوم الأشكال والانتقالات بين الشرائح بهذه الطريقة:

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

توضح هذه الشيفرة في Java عملية تصدير PowerPoint القياسية إلى HTML:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
```

في هذه الحالة، يتم عرض محتوى العرض من خلال SVG في شكل مشابه لما يلي:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> يتم عرض محتوى الشريحة هنا </g>
     </svg>
</div>
</body>
```

{{% alert title="ملاحظة" color="warning" %}} 

عند استخدام هذه الطريقة لتصدير PowerPoint إلى HTML، بسبب العرض من خلال SVG، لن تتمكن من تطبيق الأنماط أو تحريك عناصر معينة. 

{{% /alert %}}

## **تصدير PowerPoint إلى عرض شرائح HTML5**

تتيح لك **Aspose.Slides** تحويل عرض تقديمي PowerPoint إلى مستند HTML5 حيث يتم عرض الشرائح في وضع عرض الشرائح. في هذه الحالة، عند فتح ملف HTML5 الناتج في المتصفح، ترى العرض في وضع عرض الشرائح على صفحة الويب. 

يوضح هذا الكود بلغة Java عملية تصدير PowerPoint إلى عرض شرائح HTML5:

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

## تحويل عرض تقديمي إلى مستند HTML5 مع التعليقات

تعتبر التعليقات في PowerPoint أداة تمكن المستخدمين من ترك ملاحظات أو تعليقات على الشرائح. إنها مفيدة بشكل خاص في المشاريع التعاونية، حيث يمكن لعدة أشخاص إضافة اقتراحاتهم أو ملاحظاتهم على عناصر شريحة معينة دون تغيير المحتوى الرئيسي. تُظهر كل تعليق اسم المؤلف، مما يسهل تتبع من قام بترك الملاحظة.

لنفترض أن لدينا عرض تقديمي PowerPoint محفوظ في ملف "sample.pptx".

![تعليقان على شريحة العرض](two_comments_pptx.png)

عند تحويل عرض تقديمي PowerPoint إلى مستند HTML5، يمكنك بسهولة تحديد ما إذا كنت ترغب في تضمين التعليقات من العرض في مستند الإخراج. للقيام بذلك، تحتاج إلى تحديد معلمات العرض للتعليقات في طريقة `getNotesCommentsLayouting` لفئة [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/) .

يوضح المثال التالي كيفية تحويل عرض تقديمي إلى مستند HTML5 مع عرض التعليقات على يمين الشرائح.
```java
Html5Options html5Options = new Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

يظهر مستند "output.html" في الصورة أدناه.

![التعليقات في مستند HTML5 الناتج](two_comments_html5.png)