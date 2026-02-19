---
title: SmartArt
type: docs
weight: 140
url: /ar/androidjava/examples/elements/smart-art/
keywords:
- مثال على الكود
- SmartArt
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "العمل مع SmartArt في Aspose.Slides for Android: إنشاء، تحرير، تحويل، وتنسيق المخططات باستخدام Java لعروض PowerPoint وOpenDocument التقديمية."
---
توضح هذه المقالة كيفية إضافة رسومات SmartArt، والوصول إليها، وإزالتها، وتغيير التخطيطات باستخدام **Aspose.Slides for Android via Java**.

## **إضافة SmartArt**

إدراج رسم SmartArt باستخدام أحد التخطيطات المدمجة.

```java
static void addSmartArt() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISmartArt smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);
    } finally {
        presentation.dispose();
    }
}
```

## **الوصول إلى SmartArt**

استرجاع أول كائن SmartArt في الشريحة.

```java
static void accessSmartArt() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISmartArt smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

        ISmartArt firstSmartArt = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ISmartArt) {
                firstSmartArt = (ISmartArt) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **إزالة SmartArt**

حذف شكل SmartArt من الشريحة.

```java
static void removeSmartArt() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISmartArt smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

        slide.getShapes().remove(smartArt);
    } finally {
        presentation.dispose();
    }
}
```

## **تغيير تخطيط SmartArt**

تحديث نوع التخطيط لرسم SmartArt الموجود.

```java
static void changeSmartArtLayout() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISmartArt smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);
        smartArt.setLayout(SmartArtLayoutType.VerticalPictureList);
    } finally {
        presentation.dispose();
    }
}
```