---
title: حل عملي لتغيير حجم المخطط في PPTX
type: docs
weight: 40
url: /ar/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- تغيير حجم المخطط
- مخطط إكسل
- كائن OLE
- تضمين المخطط
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "إصلاح تغيير حجم المخطط غير المتوقع في PPTX عند استخدام كائنات OLE المضمنة من Excel مع Aspose.Slides for Java. تعلم طريقتين مع التعليمات البرمجية للحفاظ على الأحجام متسقة."
---

## **الخلفية**

تمت ملاحظة أن الرسوم البيانية لبرنامج Excel المدمجة ككائنات OLE في عرض تقديمي لـ PowerPoint عبر مكوّنات Aspose يتم تغيير حجمها إلى مقياس غير محدد بعد تفعيلها الأول. يتسبب هذا السلوك في فرق بصري واضح في العرض بين الحالة قبل التفعيل والحالة بعد التفعيل للرسوم البيانية. قامت فريق Aspose بالتحقق من المشكلة بتفصيل ووجد حلاً. تصف هذه المقالة أسباب المشكلة والإصلاح المقابل.

في [المقال السابق](/slides/ar/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)، شرحنا كيفية إنشاء رسم بياني لبرنامج Excel باستخدام Aspose.Cells for Java وتضمينه في عرض تقديمي لـ PowerPoint باستخدام Aspose.Slides for Java. لمعالجة [مشكلة معاينة الكائن](/slides/ar/java/object-preview-issue-when-adding-oleobjectframe/)، قمنا بتعيين صورة الرسم البياني إلى إطار كائن OLE الخاص بالرسم. في العرض الناتج، عندما تنقر مزدوجًا على إطار كائن OLE الذي يعرض صورة الرسم، يتم تفعيل رسم Excel. يمكن للمستخدمين النهائيين إجراء أي تغييرات مرغوبة في مصنف Excel الأساسي ثم العودة إلى الشريحة المقابلة بالنقر خارج المصنف المفعل. يتغير حجم إطار كائن OLE عندما يعود المستخدم إلى الشريحة، ويتفاوت عامل تغيير الحجم اعتمادًا على الأحجام الأصلية لكل من إطار كائن OLE ومصنف Excel المدمج.

## **سبب تغيير الحجم**

نظرًا لأن مصنف Excel له حجم نافذة خاص به، فهو يحاول الحفاظ على حجمه الأصلي عند التفعيل الأول. ومع ذلك، فإن إطار كائن OLE له حجمه الخاص. وفقًا لمايكروسوفت، عند تفعيل مصنف Excel، يتفاوض Excel وPowerPoint على الحجم ويحافظان على النسب الصحيحة كجزء من عملية التضمين. بناءً على الاختلافات بين حجم نافذة Excel وحجم أو موضع إطار كائن OLE، يحدث تغيير في الحجم.

## **حل عملي**

هناك سيناريوهان ممكنان لإنشاء عروض تقديمية PowerPoint باستخدام Aspose.Slides for Java.

**السيناريو 1:** إنشاء عرض تقديمي استنادًا إلى قالب موجود.

**السيناريو 2:** إنشاء عرض تقديمي من الصفر.

الحل الذي نقدمه هنا ينطبق على كلا السيناريوهين. أساس جميع نهج الحل هو نفسه: **يجب أن يتطابق حجم نافذة كائن OLE المدمج مع إطار كائن OLE في شريحة PowerPoint**. سنناقش الآن النهجين لهذا الحل.

## **النهج الأول**

في هذا النهج، سنتعلم كيفية تعيين حجم نافذة مصنف Excel المدمج بحيث يتطابق مع حجم إطار كائن OLE في شريحة PowerPoint.

**السيناريو 1**

لنفترض أننا عرّفنا قالبًا ونريد إنشاء عروض تقديمية استنادًا إليه. افترض وجود شكل في الفهرس 2 في القالب نرغب في وضع إطار OLE يحتوي على مصنف Excel مدمج فيه. في هذا السيناريو، حجم إطار كائن OLE معرف مسبقًا—يتطابق مع حجم الشكل في الفهرس 2 في القالب. كل ما نحتاج إلى فعله هو تعيين حجم نافذة المصنف مساويًا لحجم ذلك الشكل. يقدّم المقتطف البرمجي التالي هذا الغرض:
```java
// تعيين عرض نافذة المصنف بالبوصة (مقسومًا على 576 لأن PowerPoint يستخدم 576 بكسل لكل بوصة).
workbook.getSettings().setWindowWidthInch(slide.getShapes().get_Item(2).getWidth() / 72f);
 
// تعيين ارتفاع نافذة المصنف بالبوصة.
workbook.getSettings().setWindowHeightInch(slide.getShapes().get_Item(2).getHeight() / 72f);
 
// حفظ المصنف إلى تدفق الذاكرة.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// إنشاء إطار كائن OLE مع بيانات Excel المدمجة.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```


**السيناريو 2**

لنفترض أننا نريد إنشاء عرض تقديمي من الصفر وتضمين إطار كائن OLE بأي حجم مع مصنف Excel مدمج. في المقتطف البرمجي التالي، نقوم بإنشاء إطار كائن OLE بارتفاع 4 بوصات وعرض 9.5 بوصة عند x = 0.5 بوصة و y = 1 بوصة على الشريحة. ثم نعيّن نافذة مصنف Excel إلى نفس الحجم — ارتفاع 4 بوصات وعرض 9.5 بوصة.
```java
// الارتفاع المطلوب.
int desiredHeight = 288; // 4 بوصة (4 * 72)
 
// العرض المطلوب.
int desiredWidth = 684; // 9.5 بوصة (9.5 * 72)
 
// تعريف حجم المخطط باستخدام نافذة.
chart.setSizeWithWindow(true);
 
// تعيين عرض نافذة المصنف بالبوصة (مقسومًا على 576 لأن PowerPoint يستخدم 576 بكسل لكل بوصة).
workbook.getSettings().setWindowWidthInch(desiredHeight / 72f);
 
// تعيين ارتفاع نافذة المصنف بالبوصة.
workbook.getSettings().setWindowHeightInch(desiredWidth / 72f);
 
// حفظ المصنف إلى تدفق الذاكرة.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// إنشاء إطار كائن OLE مع بيانات Excel المدمجة.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    288,
    576,
    desiredWidth,
    desiredHeight,
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```


## **النهج الثاني**

في هذا النهج، سنتعلم كيفية تعيين حجم الرسم البياني في مصنف Excel المدمج ليتطابق مع حجم إطار كائن OLE في شريحة PowerPoint. هذا النهج مفيد عندما يكون حجم الرسم البياني معروفًا مسبقًا ولن يتغير.

**السيناريو 1**

لنفترض أننا عرّفنا قالبًا ونريد إنشاء عروض تقديمية استنادًا إليه. افترض وجود شكل في الفهرس 2 في القالب نعتزم وضع إطار OLE يحتوي على مصنف Excel مدمج فيه. في هذا السيناريو، حجم إطار OLE معرف مسبقًا—يتطابق مع حجم الشكل في الفهرس 2 في القالب. كل ما نحتاج إلى فعله هو تعيين حجم الرسم البياني في المصنف مساويًا لحجم ذلك الشكل. يقدّم المقتطف البرمجي التالي هذا الغرض:
```java
// تحديد حجم المخطط بدون نافذة.
chart.setSizeWithWindow(false);
 
// تحديد عرض المخطط بالبكسل (اضرب في 96 لأن Excel يستخدم 96 بكسل لكل بوصة).
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 72f) * 96f));
 
// تحديد ارتفاع المخطط بالبكسل.
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 72f) * 96f));
 
// تحديد حجم الطباعة للمخطط.
chart.setPrintSize(PrintSizeType.CUSTOM);
 
// حفظ المصنف إلى تدفق الذاكرة.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// إنشاء إطار كائن OLE مع بيانات Excel المدمجة.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```


**السيناريو 2**:

لنفترض أننا نريد إنشاء عرض تقديمي من الصفر وتضمين إطار كائن OLE بأي حجم مع مصنف Excel مدمج. في المقتطف البرمجي التالي، ننشئ إطار كائن OLE بارتفاع 4 بوصات وعرض 9.5 بوصة على الشريحة عند x = 0.5 بوصة و y = 1 بوصة. كما نعيّن حجم الرسم البياني المقابل إلى نفس الأبعاد: ارتفاع 4 بوصات وعرض 9.5 بوصة.
```java
// الارتفاع المطلوب.
int desiredHeight = 288; // 4 بوصة (4 * 72)
 
// العرض المطلوب.
int desiredWidth = 684; // 9.5 بوصة (9.5 * 72)
 
// تعريف حجم المخطط بدون نافذة.
chart.setSizeWithWindow(false);
 
// تعيين عرض المخطط بالبكسل (اضرب في 96 لأن Excel يستخدم 96 بكسل لكل بوصة).
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 576f) * 96f));
 
// تعيين ارتفاع المخطط بالبكسل.
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 576f) * 96f));
 
// حفظ المصنف إلى تدفق الذاكرة.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// إنشاء إطار كائن OLE مع بيانات Excel المدمجة.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    288,
    576,
    desiredWidth,
    desiredHeight,
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```


## **الخلاصة**

هناك نهجان لإصلاح مشكلة تغيير حجم الرسم البياني. يعتمد اختيار النهج على المتطلبات وحالة الاستخدام. كلا النهجين يعملان بنفس الطريقة سواء تم إنشاء العروض من قالب أو تم إنشاؤها من الصفر. بالإضافة إلى ذلك، لا توجد حدود لحجم إطار كائن OLE في هذا الحل.

## **الأسئلة المتكررة**

**لماذا يتغير حجم الرسم البياني المدمج من Excel بعد تفعيله في PowerPoint؟**

يحدث هذا لأن Excel يحاول استعادة حجم النافذة الأصلي عند التفعيل الأول، في حين أن إطار كائن OLE في PowerPoint له أبعاده الخاصة. يتفاوض PowerPoint وExcel على الحجم للحفاظ على نسبة العرض إلى الارتفاع، مما قد يسبب تغيير الحجم.

**هل يمكن منع هذه المشكلة تمامًا؟**

نعم. من خلال مطابقة حجم نافذة مصنف Excel أو حجم الرسم البياني مع حجم إطار كائن OLE قبل التضمين، يمكنك الحفاظ على اتساق أحجام الرسوم البيانية.

**أي نهج يجب أن أختار، تعيين حجم نافذة المصنف أم تعيين حجم الرسم البياني؟**

استخدم **النهج 1 (حجم النافذة)** إذا كنت ترغب في الحفاظ على نسبة أبعاد المصنف وربما السماح بإعادة الحجم لاحقًا.  
استخدم **النهج 2 (حجم الرسم البياني)** إذا كانت أبعاد الرسم ثابتة ولن تتغير بعد التضمين.

**هل ستعمل هذه الأساليب مع العروض المستندة إلى القالب والعروض الجديدة على حد سواء؟**

نعم. كلا النهجين يعملان بنفس الطريقة للعروض التي تم إنشاؤها من القوالب ومن الصفر.

**هل هناك حد لحجم إطار كائن OLE؟**

لا. يمكنك تعيين إطار OLE إلى أي حجم طالما أنه يتناسب مع حجم المصنف أو الرسم البياني.

**هل يمكنني استخدام هذه الأساليب مع رسوم بيانية تم إنشاؤها في برامج جدول بيانات أخرى؟**

الأمثلة مخصصة لرسوم Excel التي تم إنشاؤها باستخدام Aspose.Cells، ولكن المبادئ تنطبق على برامج جدول بيانات أخرى تدعم OLE بشرط أن تدعم خيارات حجم مماثلة.

## **الأقسام ذات الصلة**

- [إنشاء رسومات Excel وتضمينها ككائنات OLE في العروض التقديمية](/slides/ar/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [تحديث كائنات OLE تلقائيًا باستخدام إضافة PowerPoint](/slides/ar/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)