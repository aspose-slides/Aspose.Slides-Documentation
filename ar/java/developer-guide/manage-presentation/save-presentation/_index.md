---
title: حفظ العرض التقديمي
type: docs
weight: 80
url: /ar/java/save-presentation/
---

## **نظرة عامة**
{{% alert color="primary" %}} 

[فتح العرض التقديمي](/slides/ar/java/open-presentation/) يصف كيفية استخدام فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) لفتح عرض تقديمي. هذه المقالة تفسر كيفية إنشاء وحفظ العروض التقديمية.

{{% /alert %}} 

فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) تحتفظ بمحتوى العرض التقديمي. سواء كنت تقوم بإنشاء عرض تقديمي من الصفر أو تعديل واحد موجود، عندما تنتهي، سترغب في حفظ العرض التقديمي. مع Aspose.Slides لـ Java، يمكن حفظه كـ **ملف** أو **تدفق**. هذه المقالة تفسر كيفية حفظ العرض التقديمي بطرق مختلفة:

## **حفظ العرض التقديمي كملف**
احفظ العرض التقديمي كملف عن طريق استدعاء طريقة [**Save**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-) في فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation). فقط مرر اسم الملف و[**SaveFormat**](https://reference.aspose.com/slides/java/com.aspose.slides/SaveFormat) إلى طريقة [**Save**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-).

تظهر الأمثلة التالية كيفية حفظ العرض التقديمي باستخدام Aspose.Slides لـ Java.

```java
// إنشاء كائن Presentation يمثل ملف PPT
Presentation pres = new Presentation();
try {
    // ...قم ببعض العمل هنا...
    
    // احفظ العرض التقديمي كملف
    pres.save("demoPass.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    if(pres != null) pres.dispose();
}
```

## **حفظ العرض التقديمي كصورة**
من الممكن حفظ عرض تقديمي كصورة عن طريق تمرير دفق المخرج إلى طريقة [**Save**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.io.OutputStream-int-) في فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation). هناك العديد من أنواع التدفقات التي يمكن حفظ العرض التقديمي فيها. في المثال أدناه، أنشأنا ملف عرض تقديمي جديد، وأضفنا نصًا في شكل، وحفظنا العرض التقديمي إلى التدفق.

```java
// إنشاء كائن Presentation يمثل ملف PPT
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 200, 200);

    // إضافة نص إلى الشكل
    shape.getTextFrame().setText("تظهر هذه التجربة كيفية إنشاء ملف PowerPoint وحفظه في التدفق.");

    OutputStream os = new FileOutputStream("Save_As_Stream_out.pptx");

    pres.save(os, com.aspose.slides.SaveFormat.Pptx);

    os.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **حفظ العرض التقديمي مع نوع العرض المحدد مسبقًا**
توفر Aspose.Slides لـ Java إمكانية تعيين نوع العرض للعرض التقديمي الناتج عند فتحه في PowerPoint عبر فئة [ViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties). تُستخدم خاصية [**setLastView**](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties#setLastView-int-) لتعيين نوع العرض باستخدام المعداد [**ViewType**](https://reference.aspose.com/slides/java/com.aspose.slides/ViewType).

```java
// فتح ملف العرض التقديمي
Presentation pres = new Presentation();
try {
    // تعيين نوع العرض
    pres.getViewProperties().setLastView((byte) ViewType.SlideMasterView);
    
    // حفظ العرض التقديمي
    pres.save("newDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **حفظ العروض التقديمية في تنسيق XML مفتوح صارم**
يسمح لك Aspose.Slides بحفظ العرض التقديمي في تنسيق XML مفتوح صارم. لهذا الغرض، يوفر فئة [**PptxOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/pptxoptions) حيث يمكنك تعيين خاصية التوافق أثناء حفظ ملف العرض التقديمي. إذا قمت بتعيين قيمته إلى [**Conformance.Iso29500_2008_Strict**](https://reference.aspose.com/slides/java/com.aspose.slides/Conformance#Iso29500_2008_Strict)، فسيتم حفظ ملف العرض التقديمي الناتج في تنسيق XML مفتوح صارم.

الكود المصدري التالي ينشئ عرض تقديمي ويحفظه في تنسيق XML مفتوح صارم. عند استدعاء طريقة [**Save**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) للعروض التقديمية، يتم تمرير كائن [**PptxOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/pptxoptions) إليه مع تعيين خاصية التوافق إلى [**Conformance.Iso29500_2008_Strict**](https://reference.aspose.com/slides/java/com.aspose.slides/Conformance#Iso29500_2008_Strict).

```java
// إنشاء كائن Presentation يمثل ملف PPT
Presentation pres = new Presentation();
try {
    // احصل على الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);
    
    // إضافة شكل تلقائي من نوع خط
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // تعيين خيارات حفظ تنسيق XML مفتوح صارم
    PptxOptions options = new PptxOptions();
    options.setConformance(Conformance.Iso29500_2008_Strict);
    
    // احفظ العرض التقديمي كملف
    pres.save("demoPass.pptx", SaveFormat.Pptx, options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **حفظ العروض التقديمية بتنسيق XML مفتوح مع وضع ZIP64**

ملف XML مفتوح هو أرشيف ZIP له حد أقصى قدره 4 غيغابايت (2^32 بايت) على حجم الملف غير المضغوط وحجم الملف المضغوط، بالإضافة إلى حد يصل إلى 65,535 (2^16-1) ملف في الأرشيف. تزيد إضافات تنسيق ZIP64 من الحدود إلى 2^64.

تسمح لك خاصية [**IPptxOptions.Zip64Mode**](https://reference.aspose.com/slides/java/com.aspose.slides/zip64mode/) باختيار متى تستخدم إضافات تنسيق ZIP64 للملف XML المفتوح المحفوظ.

تقدم هذه الخاصية الأوضاع التالية:

- [Zip64Mode.IfNecessary](https://reference.aspose.com/slides/java/com.aspose.slides/zip64mode/#IfNecessary) تعني أن إضافات تنسيق ZIP64 ستستخدم فقط إذا كان العرض التقديمي يقع خارج القيود المذكورة أعلاه. هذه هي الوضع الافتراضي.
- [Zip64Mode.Never](https://reference.aspose.com/slides/java/com.aspose.slides/zip64mode/#Never) تعني أنه لن يتم استخدام إضافات تنسيق ZIP64. 
- [Zip64Mode.Always](https://reference.aspose.com/slides/java/com.aspose.slides/zip64mode/#Always) تعني أنه سيتم دائمًا استخدام إضافات تنسيق ZIP64.

يوضح الكود التالي كيفية حفظ العرض التقديمي بتنسيق PPTX مع إضافات تنسيق ZIP64:

```java
Presentation pres = new Presentation("Sample.pptx");
try {
    PptxOptions pptxOptions = new PptxOptions();
    pptxOptions.setZip64Mode(Zip64Mode.Always);
    
    pres.save("Sample-zip64.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="ملاحظة" color="warning" %}}

سيمرر في وضع Zip64Mode.Never [PptxException](https://reference.aspose.com/slides/java/com.aspose.slides/pptxexception/) إذا كان العرض التقديمي لا يمكن حفظه في تنسيق ZIP32.

{{% /alert %}}

## **تحديثات تقدم الحفظ بنسبة مئوية**
تمت إضافة واجهة [**IProgressCallback**](https://reference.aspose.com/slides/java/com.aspose.slides/IProgressCallback) إلى واجهة [**ISaveOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/ISaveOptions) والفئة المجردة [**SaveOptions** ](https://reference.aspose.com/slides/java/com.aspose.slides/SaveOptions). تمثل واجهة [**IProgressCallback**](https://reference.aspose.com/slides/java/com.aspose.slides/IProgressCallback) كائن استدعاء لتحديثات تقدم الحفظ بنسبة مئوية.  

توضح مقتطفات الكود التالية كيفية استخدام واجهة [IProgressCallback](https://reference.aspose.com/slides/java/com.aspose.slides/IProgressCallback):

```java
// فتح ملف العرض التقديمي
Presentation pres = new Presentation("ConvertToPDF.pptx");
try {
    ISaveOptions saveOptions = new PdfOptions();
    saveOptions.setProgressCallback((IProgressCallback) new ExportProgressHandler());
    pres.save("ConvertToPDF.pdf", SaveFormat.Pdf, saveOptions);
} finally {
    pres.dispose();
}
```
```java
class ExportProgressHandler implements IProgressCallback 
{
    public void reporting(double progressValue) 
	{
        // استخدم قيمة النسبة المئوية هنا
        int progress = Double.valueOf(progressValue).intValue();
        System.out.println(progress + "% تم تحويل الملف");
    }
}
```

{{% alert title="معلومات" color="info" %}}

باستخدام واجهته البرمجية الخاصة، طورت Aspose تطبيق [PowerPoint Splitter مجاني](https://products.aspose.app/slides/splitter) يسمح للمستخدمين بتقسيم عروضهم التقديمية إلى ملفات متعددة. أساساً، يقوم التطبيق بحفظ الشرائح المختارة من عرض تقديمي معين كملفات PowerPoint جديدة (PPTX أو PPT). 

{{% /alert %}}