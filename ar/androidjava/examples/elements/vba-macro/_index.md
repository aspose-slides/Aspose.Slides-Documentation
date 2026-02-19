---
title: ماكرو VBA
type: docs
weight: 150
url: /ar/androidjava/examples/elements/vba-macro/
keywords:
- مثال على الكود
- VBA
- ماكرو
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "قم بأتمتة العروض التقديمية باستخدام Aspose.Slides لنظام Android: أنشئ، وشغّل، واستورد، واحمِ ماكروات VBA في صيغ PPT و PPTX و ODP باستخدام أمثلة Java واضحة."
---
توضح هذه المقالة كيفية إضافة، والوصول إلى، وحذف وحدات ماكرو VBA باستخدام **Aspose.Slides for Android via Java**.

## **إضافة وحدة ماكرو VBA**

إنشاء عرض تقديمي يحتوي على مشروع VBA ووحدة ماكرو بسيطة.

```java
static void addVbaMacro() {
    Presentation presentation = new Presentation();
    try {
        presentation.setVbaProject(new VbaProject());

        IVbaModule module = presentation.getVbaProject().getModules().addEmptyModule("Module");
        module.setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");
    } finally {
        presentation.dispose();
    }
}
```

## **الوصول إلى وحدة ماكرو VBA**

استرجاع الوحدة الأولى من مشروع VBA.

```java
static void accessVbaMacro() {
    Presentation presentation = new Presentation();
    try {
        presentation.setVbaProject(new VbaProject());

        IVbaModule module = presentation.getVbaProject().getModules().addEmptyModule("Module");
        module.setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

        IVbaModule firstModule = presentation.getVbaProject().getModules().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **إزالة وحدة ماكرو VBA**

حذف وحدة من مشروع VBA.

```java
static void removeVbaMacro() {
    Presentation presentation = new Presentation();
    try {
        presentation.setVbaProject(new VbaProject());

        IVbaModule module = presentation.getVbaProject().getModules().addEmptyModule("Module");
        module.setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

        presentation.getVbaProject().getModules().remove(module);
    } finally {
        presentation.dispose();
    }
}
```