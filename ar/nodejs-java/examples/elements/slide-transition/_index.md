---
title: انتقال الشريحة
type: docs
weight: 110
url: /ar/nodejs-java/examples/elements/slide-transition/
keywords:
- مثال على الكود
- انتقال الشريحة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "إتقان انتقالات الشرائح في Aspose.Slides for Node.js: أضف، خصّص، ونظم التأثيرات والمدة مع أمثلة لعرضيات PPT و PPTX و ODP."
---
توضح هذه المقالة تطبيق تأثيرات الانتقال بين الشرائح والوقت باستخدام **Aspose.Slides for Node.js via Java**.

## **إضافة انتقال شريحة**

تطبيق تأثير انتقال تلاشي على الشريحة الأولى.

```js
function addSlideTransition() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // تطبيق انتقال تلاشي.
        slide.getSlideShowTransition().setType(aspose.slides.TransitionType.Fade);

        presentation.save("slide_transition.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **الوصول إلى انتقال شريحة**

قراءة نوع الانتقال المعين حاليًا إلى شريحة.

```js
function accessSlideTransition() {
    let presentation = new aspose.slides.Presentation("slide_transition.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // الوصول إلى نوع الانتقال.
        let type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **إزالة انتقال شريحة**

إزالة أي تأثير انتقال عن طريق ضبط النوع على `None`.

```js
function removeSlideTransition() {
    let presentation = new aspose.slides.Presentation("slide_transition.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // إزالة الانتقال بتعيين لا شيء.
        slide.getSlideShowTransition().setType(aspose.slides.TransitionType.None);

        presentation.save("slide_transition_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **تعيين مدة الانتقال**

حدد المدة التي تُعرض فيها الشريحة قبل الانتقال تلقائيًا.

```js
function setTransitionDuration() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setAdvanceOnClick(true);
        slide.getSlideShowTransition().setAdvanceAfterTime(2000); // بالملي ثانية.

        presentation.save("slide_transition_duration.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```