---
title: إدارة العناصر النائبة في العروض التقديمية على Android
linktitle: إدارة العناصر النائبة
type: docs
weight: 10
url: /ar/androidjava/manage-placeholder/
keywords:
- عنصر نائب
- عنصر نائب نصي
- عنصر نائب صورة
- عنصر نائب مخطط
- نص إرشادي
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "قم بإدارة العناصر النائبة في Aspose.Slides لأجهزة Android عبر Java بسهولة: استبدال النص، تخصيص الإرشادات وتعيين شفافية الصورة في PowerPoint وOpenDocument."
---

## **تغيير النص في العنصر النائب**
باستخدام [Aspose.Slides for Android via Java](/slides/ar/androidjava/)، يمكنك العثور على العناصر النائبة وتعديلها في الشرائح داخل العروض التقديمية. يتيح لك Aspose.Slides إجراء تغييرات على النص داخل العنصر النائب.

**Prerequisite**: تحتاج إلى عرض تقديمي يحتوي على عنصر نائب. يمكنك إنشاء مثل هذا العرض في تطبيق Microsoft PowerPoint القياسي.

هذه هي الطريقة التي تستخدم بها Aspose.Slides لاستبدال النص في العنصر النائب في ذلك العرض:

1. إنشاء كائن من الفئة [`Presentation`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) وتمرير اسم العرض كمعامل.
2. الحصول على مرجع الشريحة عبر فهرسها.
3. التجوال عبر الأشكال للعثور على العنصر النائب.
4. تحويل شكل العنصر النائب إلى [`AutoShape`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape) وتغيير النص باستخدام [`TextFrame`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) المرتبط بـ[`AutoShape`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape).
5. حفظ العرض المعدل.

يظهر هذا الكود Java كيفية تغيير النص في العنصر النائب:
```java
// ينشئ كائنًا من فئة Presentation
Presentation pres = new Presentation("ReplacingText.pptx");
try {

    // يصل إلى الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // يتنقل عبر الأشكال للعثور على العنصر النائب
    for (IShape shp : sld.getShapes()) 
    {
        if (shp.getPlaceholder() != null) {
            // يغيّر النص في كل عنصر نائب
            ((IAutoShape) shp).getTextFrame().setText("This is Placeholder");
        }
    }

    // يحفظ العرض التقديمي إلى القرص
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تعيين نص إرشادي في العنصر النائب**
تحتوي القوالب القياسية والمسبقة الإنشاء على نصوص إرشادية للعناصر النائبة مثل ***Click to add a title*** أو ***Click to add a subtitle***. باستخدام Aspose.Slides، يمكنك إدراج النصوص الإرشادية المفضلة لديك في تخطيطات العناصر النائبة.

يظهر هذا الكود Java كيفية تعيين النص الإرشادي في العنصر النائب:
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    for (IShape shape : slide.getSlide().getShapes()) // يتنقل عبر الشريحة
    {
        if (shape.getPlaceholder() != null && shape instanceof AutoShape)
        {
            String text = "";
            if (shape.getPlaceholder().getType() == PlaceholderType.CenteredTitle) // يعرض PowerPoint "انقر لإضافة عنوان"
            {
                text = "Add Title";
            }
            else if (shape.getPlaceholder().getType() == PlaceholderType.Subtitle) // يضيف عنوانًا فرعيًا
            {
                text = "Add Subtitle";
            }

            ((IAutoShape)shape).getTextFrame().setText(text);
            System.out.println("Placeholder with text: " + text);
        }
    }

    pres.save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تعيين شفافية صورة العنصر النائب**

يسمح لك Aspose.Slides بتعيين شفافية صورة الخلفية في عنصر نائب نصي. من خلال تعديل شفافية الصورة داخل هذا الإطار، يمكنك إبراز النص أو الصورة (حسب ألوان النص والصورة).

يظهر هذا الكود Java كيفية تعيين الشفافية لخلفية الصورة (داخل شكل):
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
        System.out.println("Current transparency value: " + currentValue);

        int alphaValue = 40;
        alphaModulate.setAmount(100 - alphaValue);
    }
}

presentation.save("example_out.pptx", SaveFormat.Pptx);
```


## **FAQ**

**ما هو العنصر النائب الأساسي، وكيف يختلف عن الشكل المحلي على الشريحة؟**

العنصر النائب الأساسي هو الشكل الأصلي الموجود في القالب أو الرئيس الذي يرث منه شكل الشريحة—النوع، الموقع، وبعض التنسيقات تأتي منه. الشكل المحلي يكون مستقلاً؛ إذا لم يكن هناك عنصر نائب أساسي، لا يتم تطبيق الوراثة.

**كيف يمكنني تحديث جميع العناوين أو الشروح عبر عرض تقديمي دون التجوال عبر كل شريحة؟**

قم بتحرير العنصر النائب المقابل على القالب أو الرئيس. الشرائح التي تعتمد على تلك القوالب/الرئيس ستورث التغيير تلقائيًا.

**كيف أتحكم في العناصر النائبة القياسية للترويسة/التذييل—التاريخ والوقت، رقم الشريحة، ونص التذييل؟**

استخدم مديري HeaderFooter في النطاق المناسب (الشرائح العادية، القوالب، الرئيس، الملاحظات/النشرات) لتفعيل أو إيقاف تلك العناصر النائبة وتحديد محتواها.