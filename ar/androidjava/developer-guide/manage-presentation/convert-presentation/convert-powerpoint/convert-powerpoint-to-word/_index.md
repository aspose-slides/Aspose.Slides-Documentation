---
title: تحويل عروض PowerPoint إلى مستندات Word على Android
linktitle: PowerPoint إلى Word
type: docs
weight: 110
url: /ar/androidjava/convert-powerpoint-to-word/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى Word
- العرض التقديمي إلى Word
- الشريحة إلى Word
- PPT إلى Word
- PPTX إلى Word
- PowerPoint إلى DOCX
- العرض التقديمي إلى DOCX
- الشريحة إلى DOCX
- PPT إلى DOCX
- PPTX إلى DOCX
- PowerPoint إلى DOC
- العرض التقديمي إلى DOC
- الشريحة إلى DOC
- PPT إلى DOC
- PPTX إلى DOC
- حفظ PPT كـ DOCX
- حفظ PPTX كـ DOCX
- تصدير PPT إلى DOCX
- تصدير PPTX إلى DOCX
- Android
- Java
- Aspose.Slides
description: "تحويل شرائح PowerPoint PPT و PPTX إلى مستندات Word قابلة للتعديل في Java باستخدام Aspose.Slides لنظام Android مع الحفاظ على التخطيط الدقيق والصور والتنسيق."
---

إذا كنت تخطط لاستخدام المحتوى النصي أو المعلومات من عرض تقديمي (PPT أو PPTX) بطرق جديدة، فقد تستفيد من تحويل العرض إلى Word (DOC أو DOCX). 

* مقارنةً بـ Microsoft PowerPoint، فإن تطبيق Microsoft Word مزوّد بأدوات أو وظائف أكثر للمحتوى. 
* بالإضافة إلى وظائف التحرير في Word، قد تستفيد أيضًا من ميزات التعاون، والطباعة، والمشاركة المحسّنة. 

{{% alert color="primary" %}} 

قد ترغب في تجربة [**محول العروض التقديمية إلى Word عبر الإنترنت**](https://products.aspose.app/slides/conversion/ppt-to-word) لمعرفة ما يمكنك اكتسابه من العمل بالمحتوى النصي للشرائح. 

{{% /alert %}} 

## **Aspose.Slides و Aspose.Words**

لتحويل ملف PowerPoint (PPTX أو PPT) إلى Word (DOCX أو DOCX)، تحتاج إلى كل من [Aspose.Slides for Android via Java](https://products.aspose.com/slides/androidjava/) و [Aspose.Words for Android via Java](https://products.aspose.com/words/androidjava/).

كواجهة برمجة تطبيقات مستقلة، يوفر [Aspose.Slides](https://products.aspose.app/slides) لـ java وظائف تتيح لك استخراج النصوص من العروض التقديمية. 

[Aspose.Words](https://docs.aspose.com/words/androidjava/) هي واجهة برمجة تطبيقات متقدمة لمعالجة المستندات تتيح للتطبيقات إنشاء، تعديل، تحويل، عرض، طباعة الملفات، والقيام بمهام أخرى مع المستندات دون الحاجة إلى استخدام Microsoft Word.

## **تحويل PowerPoint إلى Word**

1. تحميل مكتبات [Aspose.Slides for Android via Java](https://downloads.aspose.com/slides/java) و [Aspose.Words for Java](https://downloads.aspose.com/words/java). 
2. أضف *aspose-slides-x.x-jdk16.jar* و *aspose-words-x.x-jdk16.jar* إلى مسار الـ CLASSPATH الخاص بك. 
3. استخدم مقتطف الشفرة التالي لتحويل PowerPoint إلى Word: 
```java
Presentation pres = new Presentation("sample.pptx");

Document doc = new Document();
DocumentBuilder builder = new DocumentBuilder(doc);

for (ISlide slide : pres.getSlides()) {
    // ينشئ صورة الشريحة كمجموعة بايتات
    IImage image = slide.getImage(1, 1);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();
    image.save(imageStream, ImageFormat.Png);
    image.dispose();

    builder.insertImage(imageStream.toByteArray());

    // يدرج نصوص الشريحة
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


## **الأسئلة المتكررة**

**ما المكونات التي تحتاج إلى تثبيتها لتحويل عروض PowerPoint و OpenDocument إلى مستندات Word؟**

كل ما عليك هو إضافة الحزمة المناسبة لـ [Aspose.Slides for Android via Java](https://releases.aspose.com/slides/androidjava/) و [Aspose.Words for Android via Java](https://releases.aspose.com/words/androidjava/) إلى مشروعك. كلا المكتبتين تعملان كواجهات برمجة تطبيقات مستقلة، ولا يلزم تثبيت Microsoft Office. 

**هل يتم دعم جميع صيغ عروض PowerPoint و OpenDocument؟**

يدعم Aspose.Slides [جميع صيغ العروض التقديمية](/slides/ar/androidjava/supported-file-formats/)، بما في ذلك PPT و PPTX و ODP وغيرها من أنواع الملفات الشائعة. يضمن لك ذلك القدرة على العمل مع العروض التي تم إنشاؤها بإصدارات مختلفة من Microsoft PowerPoint.