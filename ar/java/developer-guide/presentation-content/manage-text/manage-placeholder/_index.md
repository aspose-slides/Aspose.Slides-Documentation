---
title: إدارة عناصر النائب في العروض التقديمية باستخدام Java
linktitle: إدارة العناصر النائبة
type: docs
weight: 10
url: /ar/java/manage-placeholder/
keywords:
- عنصر نائب
- عنصر نائب نصي
- عنصر نائب صورة
- عنصر نائب مخطط
- نص المطالبة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "إدارة العناصر النائبة بسهولة في Aspose.Slides for Java: استبدال النص، تخصيص المطالبات وتعيين شفافية الصورة في PowerPoint وOpenDocument."
---

## **تغيير النص في العنصر النائب**
باستخدام [Aspose.Slides for Java](/slides/ar/java/)، يمكنك العثور على العناصر النائبة وتعديلها على الشرائح في العروض التقديمية. يتيح لك Aspose.Slides إجراء تغييرات على النص في العنصر النائب.

**المتطلبات المسبقة**: تحتاج إلى عرض تقديمي يحتوي على عنصر نائب. يمكنك إنشاء مثل هذا العرض التقديمي في تطبيق Microsoft PowerPoint القياسي.

هذه هي الطريقة التي تستخدم بها Aspose.Slides لاستبدال النص في العنصر النائب في ذلك العرض التقديمي:

1. إنشاء كائن من فئة [`Presentation`](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation). وتمرير العرض التقديمي كمعامل.
2. احصل على مرجع الشريحة من خلال فهرسها.
3. التكرار عبر الأشكال للعثور على العنصر النائب.
4. تحويل نوع شكل العنصر النائب إلى [`AutoShape`](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape) وتغيير النص باستخدام [`TextFrame`](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame) المرتبط بـ[`AutoShape`](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape).
5. احفظ العرض التقديمي المعدل.

يعرض هذا الكود بلغة Java كيفية تغيير النص في العنصر النائب:
```java
// ينشئ كائنًا من فئة Presentation
Presentation pres = new Presentation("ReplacingText.pptx");
try {

    // يصل إلى الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // يتكرر عبر الأشكال للعثور على العنصر النائب
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


## **تعيين نص المطالبة في العنصر النائب**
تحتوي التخطيطات القياسية والمسبقة الإنشاء على نصوص مطالبة في العناصر النائبة مثل ***انقر لإضافة عنوان*** أو ***انقر لإضافة عنوان فرعي***. باستخدام Aspose.Slides، يمكنك إدراج نصوص المطالبة المفضلة لديك في تخطيطات العناصر النائبة.

يعرض هذا الكود بلغة Java كيفية تعيين نص المطالبة في عنصر نائب:
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
يتيح لك Aspose.Slides تعيين شفافية صورة الخلفية في عنصر نائب نصي. من خلال ضبط شفافية الصورة داخل هذا الإطار، يمكنك إبراز النص أو الصورة (اعتمادًا على ألوان النص والصورة).

يعرض هذا الكود بلغة Java كيفية تعيين الشفافية لخلفية الصورة (داخل شكل):
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
**ما هو العنصر النائب الأساسي، وكيف يختلف عن الشكل المحلي في الشريحة؟**  
العنصر النائب الأساسي هو الشكل الأصلي في تخطيط أو ماستر التي يرث منها شكل الشريحة — النوع، الموضع، وبعض التنسيقات تأتي منه. الشكل المحلي مستقل؛ إذا لم يكن هناك عنصر نائب أساسي، لا يتم تطبيق الوراثة.

**كيف يمكنني تحديث جميع العناوين أو التوضيحات عبر العرض التقديمي دون التكرار على كل شريحة؟**  
قم بتحرير العنصر النائب المقابل في التخطيط أو الماستر. الشرائح المستندة إلى تلك التخطيطات/الماستر ستورث التغيير تلقائيًا.

**كيف يمكنني التحكم في العناصر النائبة الافتراضية للترويسة/التذييل — التاريخ والوقت، رقم الشريحة، ونص التذييل؟**  
استخدم مديري HeaderFooter في النطاق المناسب (الشرائح العادية، التخطيطات، الماستر، الملاحظات/النشرات) لتشغيل أو إيقاف تلك العناصر النائبة وتعيين محتواها.