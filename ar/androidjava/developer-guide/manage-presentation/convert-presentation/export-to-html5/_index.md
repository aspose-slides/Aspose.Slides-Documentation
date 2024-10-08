---
title: تصدير إلى HTML5
type: docs
weight: 40
url: /ar/androidjava/export-to-html5/
keywords:
- PowerPoint إلى HTML
- الشرائح إلى HTML
- HTML5
- تصدير HTML
- تصدير العرض التقديمي
- تحويل العرض التقديمي
- تحويل الشرائح
- Java
- Aspose.Slides for Android via Java
description: "تصدير PowerPoint إلى HTML5 باستخدام Java"
---

{{% alert title="معلومات" color="info" %}}

في [Aspose.Slides 21.9](/slides/ar/androidjava/aspose-slides-for-java-21-9-release-notes/)، قمنا بتنفيذ دعم تصدير HTML5.

{{% /alert %}} 

تسمح لك عملية التصدير إلى HTML5 هنا بتحويل PowerPoint إلى HTML دون تمديدات ويب أو اعتمادات. بهذه الطريقة، باستخدام القوالب الخاصة بك، يمكنك تطبيق خيارات مرنة جدًا تحدد عملية التصدير ونتائج HTML وCSS وJavaScript وخصائص الرسوم المتحركة.

## **تصدير PowerPoint إلى HTML5**

يوضح هذا الكود في Java كيفية تصدير عرض تقديمي إلى HTML5 دون تمديدات ويب واعتمادات:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html5);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

في هذه الحالة، ستحصل على HTML نظيف.

{{% /alert %}}

قد ترغب في تحديد إعدادات لرسوم الأشكال وانتقالات الشرائح بهذه الطريقة:

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

يوضح هذا المثال في Java عملية تصدير PowerPoint القياسية إلى HTML:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
```

في هذه الحالة، يتم عرض محتوى العرض التقديمي من خلال SVG بشكل مثل هذا:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> هنا محتوى الشريحة </g>
     </svg>
</div>
</body>
```

{{% alert title="ملاحظة" color="warning" %}} 

عند استخدام هذه الطريقة لتصدير PowerPoint إلى HTML، بسبب عرض SVG، لن تتمكن من تطبيق الأنماط أو تحريك عناصر محددة.

{{% /alert %}}

## **تصدير PowerPoint إلى HTML5 عرض الشريحة**

**Aspose.Slides** يتيح لك تحويل عرض PowerPoint التقديمي إلى وثيقة HTML5 حيث يتم عرض الشرائح في وضع عرض الشريحة. في هذه الحالة، عند فتح ملف HTML5 الناتج في متصفح، سترى العرض التقديمي في وضع عرض الشريحة على صفحة ويب.

يوضح هذا الكود في Java عملية تصدير PowerPoint إلى HTML5 عرض الشريحة:

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

## تحويل عرض تقديمي إلى وثيقة HTML5 مع تعليقات

التعليقات في PowerPoint هي أداة تسمح للمستخدمين بترك ملاحظات أو تعليقات على شرائح العرض التقديمي. إنها مفيدة بشكل خاص في المشاريع التشاركية، حيث يمكن لعدة أشخاص إضافة اقتراحاتهم أو ملاحظاتهم على عناصر slide محددة دون تغيير المحتوى الرئيسي. كل تعليق يعرض اسم المؤلف، مما يسهل تتبع من ترك الملاحظة.

لنفترض أننا نمتلك العرض التقديمي التالي محفوظًا في ملف "sample.pptx".

![تعليقان على شريحة العرض التقديمي](two_comments_pptx.png)

عند تحويل عرض PowerPoint التقديمي إلى وثيقة HTML5، يمكنك تحديد بسهولة ما إذا كنت ترغب في تضمين التعليقات من العرض التقديمي في الوثيقة الناتجة. للقيام بذلك، تحتاج إلى تحديد معلمات العرض للتعليقات في طريقة `getNotesCommentsLayouting` الخاصة بفئة [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/) .

يوضح المثال التالي كيفية تحويل عرض تقديمي إلى وثيقة HTML5 مع عرض التعليقات إلى يمين الشرائح.
```java
Html5Options html5Options = new Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

تظهر وثيقة "output.html" في الصورة أدناه.

![التعليقات في وثيقة HTML5 الناتجة](two_comments_html5.png)