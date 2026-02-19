---
title: ActiveX
type: docs
weight: 200
url: /ar/androidjava/examples/elements/activex/
keywords:
- مثال على الكود
- ActiveX
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "اطلع على أمثلة ActiveX في Aspose.Slides لـ Android: إدراج، تكوين، والتحكم في كائنات ActiveX في عروض PPT و PPTX باستخدام كود Java واضح."
---
يُظهر هذا المقال كيفية إضافة، الوصول، إزالة وتكوين عناصر التحكم ActiveX في عرض تقديمي باستخدام **Aspose.Slides for Android via Java**.

## **إضافة عنصر تحكم ActiveX**

أدخل عنصر تحكم ActiveX جديدًا ويمكنك اختيارياً تعيين خصائصه.

```java
static void addActiveX() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // أضف عنصر تحكم ActiveX جديد.
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        // قم بتعيين بعض الخصائص اختياريًا.
        control.getProperties().add("Value", "Default text");

        presentation.save("add_activex.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **الوصول إلى عنصر تحكم ActiveX**

اقرأ المعلومات من أول عنصر تحكم ActiveX على الشريحة.

```java
static void accessActiveX() {
    Presentation presentation = new Presentation("add_activex.pptm");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // الوصول إلى عنصر التحكم ActiveX الأول.
            IControl control = slide.getControls().get_Item(0);

            System.out.println("Control Name: " + control.getName());
            System.out.println("Value: " + control.getProperties().get_Item("Value"));
        }
    } finally {
        presentation.dispose();
    }
}
```

## **إزالة عنصر تحكم ActiveX**

احذف عنصر تحكم ActiveX موجودًا من الشريحة.

```java
public static void removeActiveX() {
    Presentation presentation = new Presentation("add_activex.pptm");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // إزالة عنصر التحكم ActiveX الأول.
            slide.getControls().removeAt(0);
        }

        presentation.save("removed_activex.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **تعيين خصائص ActiveX**

أضف عنصر تحكم وقم بتكوين عدة خصائص لـ ActiveX.

```java
public static void setActiveXProperties() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // أضف عنصر تحكم Windows Media Player وقم بتكوين الخصائص.
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
        control.getProperties().set_Item("Caption", "Click Me");
        control.getProperties().set_Item("Enabled", "true");

        presentation.save("set_activex_props.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```