---
title: شريحة
type: docs
weight: 10
url: /ar/nodejs-java/examples/elements/slide/
keywords:
- مثال على الكود
- شريحة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "التحكم في الشرائح في Aspose.Slides لـ Node.js: إنشاء، استنساخ، إعادة ترتيب، تغيير الحجم، تعيين الخلفيات، وتطبيق الانتقالات لعروض PPT و PPTX و ODP."
---
يوفر هذا المقال سلسلة من الأمثلة التي توضح كيفية العمل مع الشرائح باستخدام **Aspose.Slides for Node.js via Java**. ستتعلم كيفية إضافة، الوصول، استنساخ، إعادة ترتيب، وإزالة الشرائح باستخدام الفئة `Presentation`.

يتضمن كل مثال أدناه شرحًا موجزًا يليه مقتطف شفرة في JavaScript.

## **إضافة شريحة**

لإضافة شريحة جديدة، يجب أولاً اختيار تخطيط. في هذا المثال، نستخدم تخطيط `Blank` ونضيف شريحة فارغة إلى العرض التقديمي.

```js
function addSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
        presentation.getSlides().addEmptySlide(layoutSlide);

        presentation.save("slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **ملاحظة:** كل تخطيط شريحة مستمد من شريحة رئيسية، التي تحدد التصميم العام وهيكل العناصر النائبة. الصورة أدناه توضح كيفية تنظيم الشرائح الرئيسية وتخطيطاتها المرتبطة في PowerPoint.

![العلاقة بين الشريحة الرئيسية والتخطيط](master-layout-slide.png)

## **الوصول إلى الشرائح حسب الفهرس**

يمكنك الوصول إلى الشرائح باستخدام فهرسها. هذا مفيد للتكرار عبر الشرائح أو تعديل شرائح محددة.

```js
function accessSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        // الوصول إلى شريحة حسب الفهرس.
        let firstSlide = presentation.getSlides().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **استنساخ شريحة**

يوضح هذا المثال كيفية استنساخ شريحة موجودة. تتم إضافة الشريحة المستنسخة تلقائيًا إلى نهاية مجموعة الشرائح.

```js
function cloneSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let firstSlide = presentation.getSlides().get_Item(0);
        let clonedSlide = presentation.getSlides().addClone(firstSlide);

        presentation.save("slide_cloned.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **إعادة ترتيب الشرائح**

يمكنك تغيير ترتيب الشرائح بنقل شريحة إلى فهرس جديد. في هذه الحالة، ننقل شريحة إلى المركز الأول.

```js
function reorderSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        // إعادة ترتيب الشرائح بنقل الشريحة الثانية إلى الموضع الأول.
        let secondSlide = presentation.getSlides().get_Item(1);
        presentation.getSlides().reorder(0, secondSlide);

        presentation.save("slide_reordered.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **إزالة شريحة**

لإزالة شريحة، ما عليك سوى الإشارة إليها واستدعاء `remove`. يضيف هذا المثال شريحة ثانية ثم يزيل الأصلية، تاركًا الشريحة الجديدة فقط.

```js
function removeSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        let firstSlide = presentation.getSlides().get_Item(0);
        presentation.getSlides().remove(firstSlide);

        presentation.save("slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```