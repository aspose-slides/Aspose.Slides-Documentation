---
title: ActiveX
type: docs
weight: 200
url: /ar/java/examples/elements/activex/
keywords:
- مثال على الكود
- ActiveX
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "اعرض أمثلة Aspose.Slides for Java لـ ActiveX: إدراج، تكوين، والتحكم في كائنات ActiveX في عروض PPT و PPTX مع كود Java واضح."
---
يُظهر هذا المقال كيفية إضافة، والوصول، وإزالة، وتكوين عناصر التحكم ActiveX في عرض تقديمي باستخدام **Aspose.Slides for Java**.

## **إضافة عنصر تحكم ActiveX**
إدراج عنصر تحكم ActiveX جديد وتعيين خصائصه اختيارياً.

```java
static void addActiveX() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // إضافة عنصر تحكم ActiveX جديد.
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        // تعيين بعض الخصائص اختيارياً.
        control.getProperties().add("Value", "Default text");

        presentation.save("add_activex.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **الوصول إلى عنصر تحكم ActiveX**
قراءة المعلومات من أول عنصر تحكم ActiveX في الشريحة.

```java
static void accessActiveX() {
    Presentation presentation = new Presentation("add_activex.pptm");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // الوصول إلى أول عنصر تحكم ActiveX.
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
حذف عنصر تحكم ActiveX موجود من الشريحة.

```java
public static void removeActiveX() {
    Presentation presentation = new Presentation("add_activex.pptm");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // إزالة أول عنصر تحكم ActiveX.
            slide.getControls().removeAt(0);
        }

        presentation.save("removed_activex.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **تعيين خصائص ActiveX**
إضافة عنصر تحكم وتكوين عدة خصائص لـ ActiveX.

```java
public static void setActiveXProperties() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // إضافة عنصر تحكم Windows Media Player وتكوين الخصائص.
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
        control.getProperties().set_Item("Caption", "Click Me");
        control.getProperties().set_Item("Enabled", "true");

        presentation.save("set_activex_props.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```