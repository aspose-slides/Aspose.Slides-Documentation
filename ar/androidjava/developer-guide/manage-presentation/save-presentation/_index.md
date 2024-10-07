---
title: حفظ العرض التقديمي
type: docs
weight: 80
url: /androidjava/save-presentation/
---

## **نظرة عامة**
{{% alert color="primary" %}} 

[فتح العرض التقديمي](/slides/androidjava/open-presentation/) وصف كيفية استخدام فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) لفتح عرض تقديمي. تشرح هذه المقالة كيفية إنشاء وحفظ العروض التقديمية.

{{% /alert %}} 

فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) تحمل محتوى العرض التقديمي. سواءً كنت تقوم بإنشاء عرض تقديمي من الصفر أو تعديل عرض موجود، عندما تنتهي، ستحتاج إلى حفظ العرض التقديمي. باستخدام Aspose.Slides لنظام Android عبر Java، يمكن حفظه كـ **ملف** أو **تدفق**. تشرح هذه المقالة كيفية حفظ العرض التقديمي بطرق مختلفة:

## **حفظ العرض التقديمي كملف**
قم بحفظ عرض تقديمي كملف عن طريق استدعاء طريقة [**Save**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) لفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation). ببساطة قم بتمرير اسم الملف و[**SaveFormat**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SaveFormat) إلى طريقة [**Save**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-).

تظهر الأمثلة التالية كيفية حفظ عرض تقديمي باستخدام Aspose.Slides لنظام Android عبر Java.

```java
// إنشاء كائن Presentation يمثل ملف PPT
Presentation pres = new Presentation();
try {
    // ...قم بعمل بعض العمل هنا...
    
    // احفظ عرضك التقديمي كملف
    pres.save("demoPass.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    if(pres != null) pres.dispose();
}
```

## **حفظ العرض التقديمي في تدفق**
من الممكن حفظ عرض تقديمي في تدفق عن طريق تمرير تدفق الإخراج إلى طريقة [**Save**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.io.OutputStream-int-) لفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation). هناك العديد من أنواع التدفقات التي يمكن حفظ العرض التقديمي بها. في المثال أدناه، قمنا بإنشاء ملف Presentation جديد، وأضفنا نصًا في شكل وحفظنا العرض التقديمي في التدفق.

```java
// إنشاء كائن Presentation يمثل ملف PPT
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 200, 200);

    // إضافة نص إلى الشكل
    shape.getTextFrame().setText("هذه التجربة توضح كيفية إنشاء ملف PowerPoint وحفظه في تدفق.");

    OutputStream os = new FileOutputStream("Save_As_Stream_out.pptx");

    pres.save(os, com.aspose.slides.SaveFormat.Pptx);

    os.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **حفظ العرض التقديمي مع نوع العرض المحدد مسبقًا**
توفر Aspose.Slides لنظام Android عبر Java وسيلة لتعيين نوع العرض للعروض التقديمية المنتجة عند فتحها في PowerPoint من خلال فئة [ViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties). يتم استخدام خاصية [**setLastView**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties#setLastView-int-) لتعيين نوع العرض باستخدام تعداد [**ViewType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewType).

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

## **حفظ العروض التقديمية في تنسيق Office Open XML الصارم**
يتيح لك Aspose.Slides حفظ العرض التقديمي في تنسيق Office Open XML الصارم. لهذا الغرض، يوفر فئة [**PptxOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxoptions) حيث يمكنك تعيين خاصية Conformance أثناء حفظ ملف العرض التقديمي. إذا قمت بتعيين قيمتها إلى [**Conformance.Iso29500_2008_Strict**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Conformance#Iso29500_2008_Strict)، فإن ملف العرض التقديمي الناتج سيتم حفظه في تنسيق Open XML الصارم.

الكود النموذجي التالي ينشئ عرضًا تقديميًا ويحفظه في تنسيق Office Open XML الصارم. عند استدعاء طريقة [**Save**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) للعرض التقديمي، يتم تمرير كائن [**PptxOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxoptions) إليه مع تعيين خاصية Conformance على [**Conformance.Iso29500_2008_Strict**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Conformance#Iso29500_2008_Strict).

```java
// إنشاء كائن Presentation يمثل ملف PPT
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);
    
    // أضف شكلًا تلقائيًا من نوع خط
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // تعيين خيارات الحفظ لتنسيق Office Open XML الصارم
    PptxOptions options = new PptxOptions();
    options.setConformance(Conformance.Iso29500_2008_Strict);
    
    // احفظ عرضك التقديمي كملف
    pres.save("demoPass.pptx", SaveFormat.Pptx, options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **حفظ العروض التقديمية في تنسيق Office Open XML في وضع Zip64**

ملف Office Open XML هو أرشيف ZIP له حد قدره 4 جيجابايت (2^32 بايت) على الحجم غير المضغوط للملف، حجم الملف المضغوط، والحجم الكلي للأرشيف، بالإضافة إلى حد قدره 65,535 (2^16-1) ملف في الأرشيف. تزيد ملحقات تنسيق ZIP64 من الحدود إلى 2^64.

تسمح خاصية [**IPptxOptions.Zip64Mode**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zip64mode/) الجديدة لك باختيار متى يتم استخدام ملحقات تنسيق ZIP64 للملف Office Open XML المحفوظ.

توفر هذه الخاصية الأوضاع التالية:

- [Zip64Mode.IfNecessary](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zip64mode/#IfNecessary) تعني أن ملحقات تنسيق ZIP64 سيتم استخدامها فقط إذا كان العرض التقديمي يقع خارج الحدود المذكورة أعلاه. هذا هو الوضع الافتراضي.
- [Zip64Mode.Never](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zip64mode/#Never) تعني أنه لن يتم استخدام ملحقات تنسيق ZIP64.
- [Zip64Mode.Always](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zip64mode/#Always) تعني أنه سيتم دائمًا استخدام ملحقات تنسيق ZIP64.

يوضح الكود التالي كيفية حفظ العرض التقديمي في تنسيق PPTX مع ملحقات تنسيق ZIP64:

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

سوف يؤدي الحفظ في وضع Zip64Mode.Never إلى إلقاء [PptxException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxexception/) إذا لم يكن بالإمكان حفظ العرض التقديمي في تنسيق ZIP32.

{{% /alert %}}

## **تحديثات تقدم الحفظ للنسبة المئوية**
تمت إضافة واجهة [**IProgressCallback**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProgressCallback) إلى واجهة [**ISaveOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISaveOptions) والفئة المجردة [**SaveOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SaveOptions). تمثل واجهة [**IProgressCallback**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProgressCallback) كائن رد الاتصال لتحديثات تقدم الحفظ في النسبة المئوية.  

توضح مقتطفات الكود التالية كيف تستخدم واجهة [IProgressCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProgressCallback):

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
        System.out.println(progress + "% الملف تم تحويله");
    }
}
```

{{% alert title="معلومات" color="info" %}}

باستخدام واجهتها البرمجية الخاصة، طورت Aspose تطبيق [مقسم PowerPoint مجاني](https://products.aspose.app/slides/splitter) يسمح للمستخدمين بفتح عروضهم التقديمية إلى ملفات متعددة. أساسًا، يقوم التطبيق بحفظ الشرائح المحددة من عرض تقديمي معين كملفات PowerPoint جديدة (PPTX أو PPT). 

{{% /alert %}}