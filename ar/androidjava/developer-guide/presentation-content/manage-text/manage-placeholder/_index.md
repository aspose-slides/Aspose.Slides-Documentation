---
title: إدارة العناصر النائبة
type: docs
weight: 10
url: /androidjava/manage-placeholder/
description: تغيير النص في عنصر نائب في شرائح PowerPoint باستخدام Java. تعيين نص التحفيز في عنصر نائب في شرائح PowerPoint باستخدام Java.
---

## **تغيير النص في العنصر النائب**
باستخدام [Aspose.Slides for Android via Java](/slides/androidjava/)، يمكنك العثور على العناصر النائبة وتعديلها في الشرائح في العروض التقديمية. تتيح لك Aspose.Slides إجراء التغييرات على النص في عنصر نائب.

**الشرط الأساسي**: تحتاج إلى عرض تقديمي يحتوي على عنصر نائب. يمكنك إنشاء عرض تقديمي كهذا في تطبيق Microsoft PowerPoint القياسي.

هذه هي الطريقة التي تستخدم بها Aspose.Slides لاستبدال النص في العنصر النائب في ذلك العرض التقديمي:

1. أنشئ كائنًا من فئة [`Presentation`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) ومرر العرض التقديمي كمعامل.
2. احصل على مرجع الشريحة من خلال فهرسها.
3. قم بالتمرير عبر الأشكال للعثور على العنصر النائب.
4. قم بتحويل شكل العنصر النائب إلى [`AutoShape`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape) وقم بتغيير النص باستخدام [`TextFrame`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) المرتبط بـ [`AutoShape`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape).
5. احفظ العرض التقديمي المعدل.

هذا الكود بلغة Java يوضح كيفية تغيير النص في عنصر نائب:

```java
// ينشئ كائن Presentation
Presentation pres = new Presentation("ReplacingText.pptx");
try {

    // يصل إلى الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // يتجول في الأشكال للعثور على العنصر النائب
    for (IShape shp : sld.getShapes()) 
    {
        if (shp.getPlaceholder() != null) {
            // يغير النص في كل عنصر نائب
            ((IAutoShape) shp).getTextFrame().setText("هذا هو العنصر النائب");
        }
    }

    // يحفظ العرض التقديمي على القرص
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعيين نص التحفيز في العنصر النائب**
تحتوي التخطيطات القياسية والمعدة مسبقًا على نصوص تحفيز للعنصر النائب مثل ***اضغط لإضافة عنوان*** أو ***اضغط لإضافة عنوان فرعي***. باستخدام Aspose.Slides، يمكنك إدخال نصوص التحفيز المفضلة لديك في تخطيطات العناصر النائبة.

هذا الكود بلغة Java يوضح لك كيفية تعيين نص التحفيز في عنصر نائب:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    for (IShape shape : slide.getSlide().getShapes()) // يتجول في الشريحة
    {
        if (shape.getPlaceholder() != null && shape instanceof AutoShape)
        {
            String text = "";
            if (shape.getPlaceholder().getType() == PlaceholderType.CenteredTitle) // تعرض PowerPoint "اضغط لإضافة عنوان" 
            {
                text = "إضافة عنوان";
            }
            else if (shape.getPlaceholder().getType() == PlaceholderType.Subtitle) // يضيف العنوان الفرعي
            {
                text = "إضافة عنوان فرعي";
            }

            ((IAutoShape)shape).getTextFrame().setText(text);
            System.out.println("عنصر نائب بالنص: " + text);
        }
    }

    pres.save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعيين شفافية صورة العنصر النائب**

تتيح لك Aspose.Slides تعيين شفافية الصورة الخلفية في عنصر نائب نصي. من خلال ضبط شفافية الصورة في مثل هذا الإطار، يمكنك جعل النص أو الصورة بارزًا (اعتمادًا على ألوان النص والصورة).

هذا الكود بلغة Java يوضح لك كيفية تعيين الشفافية لخلفية صورة (داخل شكل):

```java
Presentation presentation = new Presentation("example.pptx");

IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

IImageTransformOperationCollection operationCollection = shape.getFillFormat().getPictureFillFormat().getPicture().getImageTransform();
for (int i = 0; i < operationCollection.size(); i++)
{
    if(operationCollection.get_Item(i) instanceof AlphaModulateFixed)
    {
        AlphaModulateFixed alphaModulate = (AlphaModulateFixed)operationCollection.get_Item(i);
        float currentValue = 100 - alphaModulate.getAmount();
        System.out.println("قيمة الشفافية الحالية: " + currentValue);

        int alphaValue = 40;
        alphaModulate.setAmount(100 - alphaValue);
    }
}

presentation.save("example_out.pptx", SaveFormat.Pptx);
```