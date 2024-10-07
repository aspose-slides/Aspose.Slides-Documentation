---
title: إدارة العنصر النائب
type: docs
weight: 10
url: /java/manage-placeholder/
description: تغيير النص في عنصر نائب في شرائح PowerPoint باستخدام Java. تعيين نص التوجيه في عنصر نائب في شرائح PowerPoint باستخدام Java.
---

## **تغيير النص في العنصر النائب**
باستخدام [Aspose.Slides for Java](/slides/java/)، يمكنك العثور على العناصر النائبة وتعديلها في الشرائح في العروض التقديمية. يتيح لك Aspose.Slides إجراء تغييرات على النص في العنصر النائب.

**المتطلبات المسبقة**: تحتاج إلى عرض تقديمي يحتوي على عنصر نائب. يمكنك إنشاء مثل هذا العرض التقديمي في تطبيق Microsoft PowerPoint القياسي.

هذا هو كيفية استخدام Aspose.Slides لاستبدال النص في العنصر النائب في ذلك العرض التقديمي:

1. قم بتهيئة فئة [`Presentation`](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) ومرر العرض التقديمي كوسيط.
2. احصل على مرجع الشريحة من خلال فهرسها.
3. قم بالتكرار عبر الأشكال للعثور على العنصر النائب.
4. قم بتحويل شكل العنصر النائب إلى [`AutoShape`](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape) وغيّر النص باستخدام [`TextFrame`](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame) المرتبط بـ [`AutoShape`](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape).
5. احفظ العرض التقديمي المعدل.

هذا هو كود Java الذي يوضح كيفية تغيير النص في العنصر النائب:

```java
// يقوم بتهيئة فئة Presentation
Presentation pres = new Presentation("ReplacingText.pptx");
try {

    // يصل إلى الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // يتكرر عبر الأشكال للعثور على العنصر النائب
    for (IShape shp : sld.getShapes()) 
    {
        if (shp.getPlaceholder() != null) {
            // يغيّر النص في كل عنصر نائب
            ((IAutoShape) shp).getTextFrame().setText("هذا هو العنصر النائب");
        }
    }

    // يحفظ العرض التقديمي على القرص
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعيين نص التوجيه في العنصر النائب**
تحتوي التخطيطات القياسية والمعدة مسبقًا على نصوص توجيه للعنصر النائب مثل ***انقر لإضافة عنوان*** أو ***انقر لإضافة عنوان فرعي***. باستخدام Aspose.Slides، يمكنك إدراج نصوص التوجيه المفضلة لديك في تخطيطات العناصر النائبة.

هذا هو كود Java الذي يوضح لك كيفية تعيين نص التوجيه في العنصر النائب:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    for (IShape shape : slide.getSlide().getShapes()) // يتكرر عبر الشريحة
    {
        if (shape.getPlaceholder() != null && shape instanceof AutoShape)
        {
            String text = "";
            if (shape.getPlaceholder().getType() == PlaceholderType.CenteredTitle) // يعرض PowerPoint "انقر لإضافة عنوان" 
            {
                text = "أضف عنوان";
            }
            else if (shape.getPlaceholder().getType() == PlaceholderType.Subtitle) // يضيف العنوان الفرعي
            {
                text = "أضف عنوان فرعي";
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

يتيح لك Aspose.Slides تعيين شفافية الخلفية للصورة في عنصر نائب نصي. من خلال ضبط شفافية الصورة في مثل هذا الإطار، يمكنك جعل النص أو الصورة بارزة (اعتمادًا على ألوان النص والصورة).

هذا هو كود Java الذي يوضح لك كيفية تعيين الشفافية لخلفية الصورة (داخل شكل):

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