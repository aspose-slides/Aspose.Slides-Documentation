---
title: تحويل باوربوينت إلى وورد
type: docs
weight: 110
url: /androidjava/convert-powerpoint-to-word/
keywords: "تحويل باوربوينت، PPT، PPTX، عرض، وورد، DOCX، DOC، PPTX إلى DOCX، PPT إلى DOC، PPTX إلى DOC، PPT إلى DOCX، Java، java، Aspose.Slides"
description: "تحويل عرض باوربوينت إلى وورد في جافا"
---

إذا كنت تخطط لاستخدام محتوى نصي أو معلومات من عرض (PPT أو PPTX) بطرق جديدة، فقد تستفيد من تحويل العرض إلى وورد (DOC أو DOCX).

* عند المقارنة مع Microsoft PowerPoint، فإن تطبيق Microsoft Word مزود بشكل أفضل بالأدوات أو الوظائف الخاصة بالمحتوى.
* بالإضافة إلى وظائف التحرير في وورد، قد تستفيد أيضًا من ميزات التعاون المعززة، والطباعة، والمشاركة.

{{% alert color="primary" %}}

يمكنك تجربة [**محول العرض إلى وورد عبر الإنترنت**](https://products.aspose.app/slides/conversion/ppt-to-word) لترى ما يمكنك اكتسابه من العمل مع المحتوى النصي من الشرائح.

{{% /alert %}}

## **Aspose.Slides و Aspose.Words**

لتحويل ملف باوربوينت (PPTX أو PPT) إلى وورد (DOCX أو DOCX)، تحتاج إلى [Aspose.Slides for Android via Java](https://products.aspose.com/slides/androidjava/) و [Aspose.Words for Java](https://products.aspose.com/words/java/).

كواجهة برمجة تطبيقات مستقلة، يوفر [Aspose.Slides](https://products.aspose.app/slides) لجافا وظائف تسمح لك باستخراج النصوص من العروض.

[Aspose.Words](https://docs.aspose.com/words/java/) هو واجهة برمجة تطبيقات متقدمة لمعالجة المستندات تتيح للتطبيقات إنشاء، وتعديل، وتحويل، وعرض، وطباعة الملفات، وأداء مهام أخرى مع المستندات دون الاستفادة من Microsoft Word.

## **تحويل باوربوينت إلى وورد**

1. قم بتنزيل مكتبات [Aspose.Slides for Android via Java](https://downloads.aspose.com/slides/java) و [Aspose.Words for Java](https://downloads.aspose.com/words/java).
2. أضف *aspose-slides-x.x-jdk16.jar* و *aspose-words-x.x-jdk16.jar* إلى متغير CLASSPATH الخاص بك.
3. استخدم هذه الشيفرة لتحويل باوربوينت إلى وورد:

```java
Presentation pres = new Presentation("sample.pptx");

Document doc = new Document();
DocumentBuilder builder = new DocumentBuilder(doc);

for (ISlide slide : pres.getSlides()) {
    // يولد صورة شريحة كتيار مصفوفة بايت
    IImage image = slide.getImage(1, 1);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();
    image.save(imageStream, ImageFormat.Png);
    image.dispose();

    builder.insertImage(imageStream.toByteArray());

    // يدخل نصوص الشريحة
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof AutoShape) {
            builder.writeln(((AutoShape) shape).getTextFrame().getText());
        }
    }

    builder.insertBreak(BreakType.PAGE_BREAK);
}

doc.save("output.docx");
pres.dispose();
```