---
title: إدارة عناصر النائب في العرض التقديمي على Android
linktitle: إدارة العناصر النائبة
type: docs
weight: 10
url: /ar/androidjava/manage-placeholder/
keywords:
- عنصر نائب
- عنصر نائب نصي
- عنصر نائب صورة
- عنصر نائب رسم بياني
- نص المطالبة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إدارة العناصر النائبة بسهولة في Aspose.Slides لأندرويد عبر جافا: استبدال النص، تخصيص نصوص المطالبة وتعيين شفافية الصورة في PowerPoint و OpenDocument."
---

## **تغيير النص في عنصر نائب**
باستخدام [Aspose.Slides for Android via Java](/slides/ar/androidjava/)، يمكنك العثور على العناصر النائبة وتعديلها على الشرائح في العروض التقديمية. يتيح لك Aspose.Slides إجراء تغييرات على النص داخل عنصر نائب.

**المتطلبات المسبقة**: تحتاج إلى عرض تقديمي يحتوي على عنصر نائب. يمكنك إنشاء مثل هذا العرض باستخدام تطبيق Microsoft PowerPoint القياسي.

هذه هي الطريقة التي تستخدم بها Aspose.Slides لاستبدال النص في العنصر النائب في ذلك العرض التقديمي:

1. إنشاء كائن من فئة [`Presentation`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) وتمرير العرض التقديمي كوسيطة.
2. احصل على مرجع الشريحة عبر فهرستها.
3. تكرار عبر الأشكال للعثور على العنصر النائب.
4. تحويل نوع شكل العنصر النائب إلى [`AutoShape`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape) وتغيير النص باستخدام [`TextFrame`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) المرتبط بـ [`AutoShape`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape).
5. احفظ العرض التقديمي المعدل.

This Java code shows how to change the text in a placeholder:
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

    // يحفظ العرض التقديمي على القرص
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تعيين نص المطالبة في عنصر نائب**
تحتوي المخططات القياسية والمُنشأة مسبقًا على نصوص مطالبة عنصر نائب مثل ***انقر لإضافة عنوان*** أو ***انقر لإضافة عنوان فرعي***. باستخدام Aspose.Slides، يمكنك إدراج نصوص المطالبة المفضلة لديك في مخططات العناصر النائبة.

يعرض لك هذا الشيفرة Java كيفية تعيين نص المطالبة في عنصر نائب:
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    for (IShape shape : slide.getSlide().getShapes()) // يتنقل عبر الشريحة
    {
        if (shape.getPlaceholder() != null && shape instanceof AutoShape)
        {
            String text = "";
            if (shape.getPlaceholder().getType() == PlaceholderType.CenteredTitle) // يُظهر PowerPoint "انقر لإضافة عنوان" 
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
يتيح لك Aspose.Slides ضبط شفافة الصورة الخلفية في عنصر نائب نصي. من خلال تعديل شفافية الصورة داخل هذا الإطار، يمكنك إبراز النص أو الصورة (اعتمادًا على ألوان النص والصورة).

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


## **الأسئلة المتكررة**
**ما هو العنصر النائب الأساسي، وكيف يختلف عن الشكل المحلي على الشريحة؟**

العنصر النائب الأساسي هو الشكل الأصلي الموجود في تخطيط أو القالب الذي يرث منه شكل الشريحة — النوع، الموضع، وبعض التنسيقات تأتي منه. الشكل المحلي هو مستقل؛ إذا لم يكن هناك عنصر نائب أساسي، لا يتم تطبيق الوراثة.

**كيف يمكنني تحديث جميع العناوين أو التسميات عبر عرض تقديمي دون التكرار على كل شريحة؟**

حرر العنصر النائب المقابل في التخطيط أو القالب. الشرائح التي تعتمد على تلك التخطيطات/القالب ستورث التغيير تلقائيًا.

**كيف أتحكم في عناصر النائب القياسية للرأس/التذييل — التاريخ والوقت، رقم الشريحة، ونص التذييل؟**

استخدم مديرات HeaderFooter في النطاق المناسب (الشرائح العادية، التخطيطات، القالب، الملاحظات/النشرات) لتفعيل أو إلغاء تفعيل تلك العناصر النائبة وتحديد محتواها.