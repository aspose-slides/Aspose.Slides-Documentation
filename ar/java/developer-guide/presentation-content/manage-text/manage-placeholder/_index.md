---
title: إدارة عناصر العرض التقديمي في Java
linktitle: إدارة العناصر النائبة
type: docs
weight: 10
url: /ar/java/manage-placeholder/
keywords:
- عنصر نائب
- عنصر نائب نصي
- عنصر نائب صورة
- عنصر نائب مخطط
- نص توجيه
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "إدارة العناصر النائبة في Aspose.Slides for Java بسهولة: استبدال النص، تخصيص التوجيهات، وضبط شفافية الصورة في PowerPoint وOpenDocument."
---

## **تغيير النص في العنصر النائب**
باستخدام [Aspose.Slides for Java](/slides/ar/java/)، يمكنك العثور على العناصر النائبة وتعديلها في الشرائح داخل العروض التقديمية. يتيح لك Aspose.Slides إجراء تغييرات على النص داخل عنصر نائب.

**المتطلبات المسبقة**: تحتاج إلى عرض تقديمي يحتوي على عنصر نائب. يمكنك إنشاء مثل هذا العرض التقديمي باستخدام تطبيق Microsoft PowerPoint القياسي.

هذه هي الطريقة التي تستخدم بها Aspose.Slides لاستبدال النص في العنصر النائب في ذلك العرض التقديمي:

1. إنشاء كائن من الفئة [`Presentation`](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) وتمرير العرض التقديمي كمعامل.
2. احصل على مرجع الشريحة عبر فهرستها.
3. قم بالتكرار عبر الأشكال للعثور على العنصر النائب.
4. حوّل نوع شكل العنصر النائب إلى [`AutoShape`](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape) ثم غيّر النص باستخدام [`TextFrame`](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame) المرتبط بـ[`AutoShape`](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape).
5. احفظ العرض التقديمي المعدل.

يعرض هذا الكود Java كيفية تغيير النص في العنصر النائب:
```java
// إنشاء كائن من فئة Presentation
Presentation pres = new Presentation("ReplacingText.pptx");
try {

    // الوصول إلى الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // التكرار عبر الأشكال للعثور على العنصر النائب
    for (IShape shp : sld.getShapes()) 
    {
        if (shp.getPlaceholder() != null) {
            // تغيير النص في كل عنصر نائب
            ((IAutoShape) shp).getTextFrame().setText("This is Placeholder");
        }
    }

    // حفظ العرض التقديمي إلى القرص
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تعيين نص التلميح في العنصر النائب**
تحتوي القوالب القياسية والمسبقة الإنشاء على نصوص تلميح للعنصر النائب مثل ***انقر لإضافة عنوان*** أو ***انقر لإضافة عنوان فرعي***. باستخدام Aspose.Slides، يمكنك إدراج نصوص التلميح المفضلة لديك في تخطيطات العنصر النائب.

يعرض هذا الكود Java كيفية تعيين نص التلميح في العنصر النائب:
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
يتيح لك Aspose.Slides ضبط شفافية الصورة الخلفية في عنصر نائب نصي. من خلال تعديل شفافية الصورة داخل هذا الإطار، يمكنك إظهار النص أو الصورة بشكل بارز (اعتمادًا على ألوان النص والصورة).

يعرض هذا الكود Java كيفية ضبط الشفافية لخلفية الصورة (داخل الشكل):
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
العنصر النائب الأساسي هو الشكل الأصلي الموجود في التخطيط أو القالب الرئيسي الذي يرث منه شكل الشريحة — النوع، الموضع، وبعض التنسيقات تأتي منه. الشكل المحلي مستقل؛ إذا لم يكن هناك عنصر نائب أساسي، لا يتم تطبيق الوراثة.

**كيف يمكنني تحديث جميع العناوين أو الشروح عبر العرض التقديمي دون التكرار على كل شريحة؟**  
قم بتحرير العنصر النائب المقابل في التخطيط أو القالب الرئيسي. ستورّث الشرائح المستندة إلى تلك التخطيطات أو القالب هذا التغيير تلقائيًا.

**كيف يمكنني التحكم في العناصر النائبة القياسية للترويسة/التذييل — التاريخ والوقت، رقم الشريحة، ونص التذييل؟**  
استخدم مديري HeaderFooter في النطاق المناسب (الشرائح العادية، التخطيطات، القالب الرئيسي، الملاحظات/الكتيبات) لتفعيل أو إلغاء تفعيل هذه العناصر النائبة وتعيين محتواها.