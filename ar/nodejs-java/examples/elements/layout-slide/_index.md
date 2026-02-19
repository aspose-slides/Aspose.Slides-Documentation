---
title: شريحة تخطيط
type: docs
weight: 20
url: /ar/nodejs-java/examples/elements/layout-slide/
keywords:
- مثال على الكود
- شريحة تخطيط
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تحكم في شرائح التخطيط في Aspose.Slides لـ Node.js: اختر، طبّق، وخصّص تخطيطات الشرائح، العناصر النائبة، والرؤوس الرئيسية مع أمثلة لعروض PPT، PPTX، وODP."
---
توضح هذه المقالة كيفية العمل مع **شرائح التخطيط** في Aspose.Slides لـ Node.js عبر Java. تُعرّف شريحة التخطيط التصميم والتنسيق الموروث من قبل الشرائح العادية. يمكنك إضافة شرائح التخطيط، الوصول إليها، استنساخها، وإزالتها، بالإضافة إلى تنظيف الشرائح غير المستخدمة لتقليل حجم العرض.

## **إضافة شريحة تخطيط**

يمكنك إنشاء شريحة تخطيط مخصصة لتحديد تنسيق يمكن إعادة استخدامه.

```js
function addLayoutSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let masterSlide = presentation.getMasters().get_Item(0);

        // إنشاء شريحة تخطيط بنوع تخطيط فارغ واسم مخصص.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().add(masterSlide, layoutType, "Main layout");

        presentation.save("layout_slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **ملاحظة 1:** تعمل شرائح التخطيط كقوالب للشرائح الفردية. يمكنك تعريف العناصر المشتركة مرة واحدة وإعادة استخدامها عبر العديد من الشرائح.

> 💡 **ملاحظة 2:** عندما تضيف أشكالًا أو نصًا إلى شريحة التخطيط، ستعرض جميع الشرائح المستندة إلى ذلك التخطيط هذا المحتوى المشترك تلقائيًا.
> تُظهر لقطة الشاشة أدناه شريحتين، كل منهما يرث صندوق نص من شريحة التخطيط نفسها.

![شرائح ترث محتوى التخطيط](layout-slide-result.png)

## **الوصول إلى شريحة تخطيط**

يمكن الوصول إلى شرائح التخطيط عبر الفهرس أو بنوع التخطيط (مثل `Blank`، `Title`، `SectionHeader`، إلخ).

```js
function accessLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // الوصول إلى شريحة تخطيط بواسطة الفهرس.
        let firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // الوصول إلى شريحة تخطيط بواسطة النوع.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
    } finally {
        presentation.dispose();
    }
}
```

## **إزالة شريحة تخطيط**

يمكنك إزالة شريحة تخطيط محددة إذا لم تعد بحاجة إليها.

```js
function removeLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // الحصول على شريحة تخطيط بواسطة النوع وإزالتها.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Custom);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
        presentation.getLayoutSlides().remove(layoutSlide);

        presentation.save("layout_slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **إزالة شرائح التخطيط غير المستخدمة**

لتقليل حجم العرض، قد ترغب في إزالة شرائح التخطيط التي لا تُستخدم من قبل أي شرائح عادية.

```js
function removeUnusedLayoutSlides() {
    let presentation = new aspose.slides.Presentation();
    try {
        // يقوم تلقائيًا بإزالة جميع شرائح التخطيط التي لا يشير إليها أي شريحة.
        presentation.getLayoutSlides().removeUnused();

        presentation.save("unused_layout_slides_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **استنساخ شريحة تخطيط**

يمكنك تكرار شريحة التخطيط باستخدام طريقة `addClone`.

```js
function cloneLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // الحصول على شريحة تخطيط موجودة بواسطة النوع.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Title);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);

        // استنساخ شريحة التخطيط إلى نهاية مجموعة شرائح التخطيط.
        let clonedLayoutSlide = presentation.getLayoutSlides().addClone(layoutSlide);

        presentation.save("layout_slide_cloned.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **الملخص:** شرائح التخطيط هي أدوات قوية لإدارة تنسيق متسق عبر الشرائح. يتيح Aspose.Slides التحكم الكامل في إنشاء وإدارة وتحسين شرائح التخطيط.