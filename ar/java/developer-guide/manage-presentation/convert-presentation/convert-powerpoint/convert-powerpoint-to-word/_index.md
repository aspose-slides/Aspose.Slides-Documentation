---
title: تحويل PowerPoint إلى Word
type: docs
weight: 110
url: /ar/java/convert-powerpoint-to-word/
keywords: "تحويل PowerPoint, PPT, PPTX, عرض, Word, DOCX, DOC, PPTX إلى DOCX, PPT إلى DOC, PPTX إلى DOC, PPT إلى DOCX, Java, java, Aspose.Slides"
description: "تحويل عرض PowerPoint إلى Word باستخدام Java"
---

إذا كنت تخطط لاستخدام محتوى نصي أو معلومات من عرض تقديمي (PPT أو PPTX) بطرق جديدة، فقد تستفيد من تحويل العرض إلى Word (DOC أو DOCX).

* عند مقارنته بـ Microsoft PowerPoint، فإن تطبيق Microsoft Word مزود بأدوات أو ميزات أفضل للمحتوى.
* بالإضافة إلى وظائف التحرير في Word، يمكنك أيضًا الاستفادة من ميزات التعاون المعززة والطباعة والمشاركة.

{{% alert color="primary" %}} 

قد ترغب في تجربة [**محول العرض إلى Word عبر الإنترنت**](https://products.aspose.app/slides/conversion/ppt-to-word) لترى ما يمكنك الاستفادة منه من خلال العمل مع المحتوى النصي من الشرائح.

{{% /alert %}} 

## **Aspose.Slides و Aspose.Words**

لتحويل ملف PowerPoint (PPTX أو PPT) إلى Word (DOCX أو DOCX)، تحتاج إلى كل من [Aspose.Slides لـ Java](https://products.aspose.com/slides/java/) و [Aspose.Words لـ Java](https://products.aspose.com/words/java/).

كمكتبة API مستقلة، يوفر [Aspose.Slides](https://products.aspose.app/slides) لـ Java وظائف تسمح لك باستخراج النصوص من العروض التقديمية.

[Aspose.Words](https://docs.aspose.com/words/java/) هو API متقدم لمعالجة الوثائق يتيح للتطبيقات إنشاء وتعديل وتحويل وعرض وطباعة الملفات، وأداء مهام أخرى مع الوثائق دون استخدام Microsoft Word.

## **تحويل PowerPoint إلى Word**

1. قم بتنزيل مكتبات [Aspose.Slides لـ Java](https://downloads.aspose.com/slides/java) و [Aspose.Words لـ Java](https://downloads.aspose.com/words/java).
2. أضف *aspose-slides-x.x-jdk16.jar* و *aspose-words-x.x-jdk16.jar* إلى مسار CLASSPATH الخاص بك.
3. استخدم جزء الكود التالي لتحويل PowerPoint إلى Word:

```java
Presentation pres = new Presentation("sample.pptx");

Document doc = new Document();
DocumentBuilder builder = new DocumentBuilder(doc);

for (ISlide slide : pres.getSlides()) {
    // generates a slide image as a byte array stream
    IImage image = slide.getImage(1, 1);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();
    image.save(imageStream, ImageFormat.Png);
    image.dispose();

    builder.insertImage(imageStream.toByteArray());

    // inserts slide's texts
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