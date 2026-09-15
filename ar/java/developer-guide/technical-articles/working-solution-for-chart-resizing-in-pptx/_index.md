---
title: حل عملي لتغيير حجم المخطط في PPTX
type: docs
weight: 40
url: /ar/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- تغيير حجم المخطط
- مخطط Excel
- كائن OLE
- تضمين المخطط
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "إصلاح تغيير حجم المخطط غير المتوقع في PPTX عند استخدام كائنات OLE لـ Excel المدمجة مع Aspose.Slides for Java. تعرّف على طريقتين مع الشيفرة للحفاظ على الأحجام متسقة."
---
## **الخلفية**

لوحظ أن مخططات Excel المدمجة ككائنات OLE في عرض تقديمي PowerPoint عبر مكونات Aspose يتم تغيير حجمها إلى مقياس غير محدد بعد تنشيطها الأول. هذا السلوك يتسبب في اختلاف بصري ملحوظ في العرض بين حالتي المخطط قبل وبعد التنشيط. قام فريق Aspose بالتحقيق في المشكلة بالتفصيل ووجد حلاً. تصف هذه المقالة أسباب المشكلة والإصلاح المقابل.

في [المقال السابق](/slides/ar/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)، شرحنا كيفية إنشاء مخطط Excel باستخدام Aspose.Cells for Java وتضمينه في عرض تقديمي PowerPoint باستخدام Aspose.Slides for Java. لمعالجة [مشكلة معاينة الكائن](/slides/ar/java/object-preview-issue-when-adding-oleobjectframe/)، قمنا بتعيين صورة المخطط إلى إطار كائن OLE الخاص بالمخطط. في العرض الناتج، عندما تنقر مزدوجاً على إطار كائن OLE الذي يعرض صورة المخطط، يتم تنشيط مخطط Excel. يمكن للمستخدمين النهائيين إجراء أي تغييرات مرغوبة في مصنف Excel الأساسي ثم العودة إلى الشريحة المقابلة بالنقر خارج المصنف النشط. يتغير حجم إطار كائن OLE عندما يعيد المستخدم إلى الشريحة، وعامل التحجيم يختلف اعتمادًا على الأحجام الأصلية لكل من إطار كائن OLE ومصنف Excel المدمج.

## **سبب التحجيم**

نظرًا لأن مصنف Excel له حجمه الخاص في النافذة، فإنه يحاول الحفاظ على حجمه الأصلي عند تنشيطه الأول. ومع ذلك، فإن إطار كائن OLE له حجمه الخاص. وفقًا لمايكروسوفت، عند تنشيط مصنف Excel، يتفاوض Excel وPowerPoint على الحجم ويحافظان على النسب الصحيحة كجزء من عملية الإدماج. اعتمادًا على الفروق بين حجم نافذة Excel وحجم أو موقع إطار كائن OLE، يحدث التحجيم.

## **الحل العملي**

هناك سيناريوهان محتملان لإنشاء عروض PowerPoint باستخدام Aspose.Slides for Java.  
**السيناريو 1:** إنشاء عرض تقديمي استنادًا إلى قالب موجود.  
**السيناريو 2:** إنشاء عرض تقديمي من الصفر.  
الحل الذي نقدمه هنا ينطبق على كلا السيناريوهين. أساس جميع منهجيات الحل هو نفسه: **يجب أن يكون حجم نافذة كائن OLE المدمج متطابقًا مع إطار كائن OLE في شريحة PowerPoint**. سنناقش الآن النهجين لهذا الحل.

## **النهج الأول**

في هذا النهج، سنتعلم كيفية ضبط حجم نافذة مصنف Excel المدمج بحيث يتطابق مع حجم إطار كائن OLE في شريحة PowerPoint.

**السيناريو 1**  
نفترض أننا قد عرّفنا قالبًا ونريد إنشاء عروض تقديمية استنادًا إليه. افترض وجود شكل في الفهرس 2 داخل القالب حيث نرغب في وضع إطار OLE يحتوي على مصنف Excel مدمج. في هذا السيناريو، يكون حجم إطار كائن OLE محددًا مسبقًا—يتطابق مع حجم الشكل في الفهرس 2 داخل القالب. كل ما نحتاجه هو ضبط حجم نافذة المصنف ليكون مساويًا لحجم ذلك الشكل. يخدم شفرة الكود التالية هذا الغرض:

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// ضبط عرض نافذة المصنف بالبوصة (مقسم على 72 لأن PowerPoint يستخدم 72 نقطة لكل بوصة).
workbook.getSettings().setWindowWidthInch(slide.getShapes().get_Item(2).getWidth() / 72f);
 
// ضبط ارتفاع نافذة المصنف بالبوصة.
workbook.getSettings().setWindowHeightInch(slide.getShapes().get_Item(2).getHeight() / 72f);
 
// حفظ المصنف إلى تدفق ذاكرة.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// إنشاء إطار كائن OLE مع بيانات Excel المدمجة.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    dataInfo);
```

**السيناريو 2**  
لنفترض أننا نريد إنشاء عرض تقديمي من الصفر وتضمين إطار OLE بأي حجم يحتوي على مصنف Excel مدمج. في شفرة الكود التالية، نقوم بإنشاء إطار OLE بارتفاع 4 بوصات وعرض 9.5 بوصة عند x = 0.5 بوصة وy = 1 بوصة على الشريحة. ثم نضبط نافذة مصنف Excel لتكون بنفس الحجم—ارتفاع 4 بوصات وعرض 9.5 بوصة.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// الارتفاع المطلوب.
int desiredHeight = 288; // 4 بوصة (4 * 72)
 
// العرض المطلوب.
int desiredWidth = 684; // 9.5 بوصة (9.5 * 72)
 
// تعريف حجم المخطط باستخدام النافذة.
chart.setSizeWithWindow(true);
 
// ضبط عرض نافذة المصنف بالبوصة (مقسم على 72 لأن PowerPoint يستخدم 72 نقطة لكل بوصة).
workbook.getSettings().setWindowWidthInch(desiredWidth / 72f);
 
// ضبط ارتفاع نافذة المصنف بالبوصة.
workbook.getSettings().setWindowHeightInch(desiredHeight / 72f);
 
// حفظ المصنف إلى تدفق ذاكرة.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// إنشاء إطار كائن OLE مع بيانات Excel المدمجة.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    36,  // x = 0.5 بوصة (0.5 * 72)
    72,  // y = 1 بوصة (1 * 72)
    desiredWidth,
    desiredHeight,
    dataInfo);
```

## **النهج الثاني**

في هذا النهج، سنتعلم كيفية ضبط حجم المخطط في مصنف Excel المدمج ليطابق حجم إطار OLE في شريحة PowerPoint. هذا النهج مفيد عندما يكون حجم المخطط معروفًا مسبقًا ولن يتغير.

**السيناريو 1**  
نفترض أننا قد عرّفنا قالبًا ونريد إنشاء عروض تقديمية استنادًا إليه. افترض وجود شكل في الفهرس 2 داخل القالب حيث نعتزم وضع إطار OLE يحتوي على مصنف Excel مدمج. في هذا السيناريو، يكون حجم إطار OLE محددًا مسبقًا—يتطابق مع حجم الشكل في الفهرس 2 داخل القالب. كل ما نحتاجه هو ضبط حجم المخطط في المصنف ليكون مساويًا لحجم ذلك الشكل. يخدم شفرة الكود التالية هذا الغرض:

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// تعريف حجم المخطط بدون نافذة.
chart.setSizeWithWindow(false);
 
// ضبط عرض المخطط بالبكسل (اضرب في 96 لأن Excel يستخدم 96 بكسل لكل بوصة).
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 72f) * 96f));
 
// ضبط ارتفاع المخطط بالبكسل.
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 72f) * 96f));
 
// تعريف حجم الطباعة للمخطط.
chart.setPrintSize(com.aspose.cells.PrintSizeType.CUSTOM);
 
// حفظ المصنف إلى تدفق ذاكرة.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// إنشاء إطار كائن OLE مع بيانات Excel المدمجة.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    dataInfo);
```

**السيناريو 2**:  
لنفترض أننا نريد إنشاء عرض تقديمي من الصفر وتضمين إطار OLE بأي حجم يحتوي على مصنف Excel مدمج. في شفرة الكود التالية، نقوم بإنشاء إطار OLE بارتفاع 4 بوصات وعرض 9.5 بوصة على الشريحة عند x = 0.5 بوصة وy = 1 بوصة. كما نضبط حجم المخطط المقابل ليكون بنفس الأبعاد: ارتفاع 4 بوصات وعرض 9.5 بوصة.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// الارتفاع المطلوب.
int desiredHeight = 288; // 4 بوصة (4 * 72)
 
// العرض المطلوب.
int desiredWidth = 684; // 9.5 بوصة (9.5 * 72)
 
// تعريف حجم المخطط بدون نافذة.
chart.setSizeWithWindow(false);
 
// تعيين عرض المخطط بالبكسل (مقسوم على 72 للحصول على البوصة، مضروبًا في 96 لأن Excel يستخدم 96 بكسل لكل بوصة).
chart.getChartObject().setWidth((int)((desiredWidth / 72f) * 96f));
 
// تعيين ارتفاع المخطط بالبكسل.
chart.getChartObject().setHeight((int)((desiredHeight / 72f) * 96f));
 
// حفظ المصنف إلى تدفق ذاكرة.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// إنشاء إطار كائن OLE مع بيانات Excel المدمجة.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    36,  // x = 0.5 بوصة (0.5 * 72)
    72,  // y = 1 بوصة (1 * 72)
    desiredWidth,
    desiredHeight,
    dataInfo);
```

## **الخلاصة**

هناك نهجان لحل مشكلة تغيير حجم المخطط. يعتمد اختيار النهج على المتطلبات وحالة الاستخدام. كلا النهجين يعملان بنفس الطريقة سواء تم إنشاء العروض من قالب أو من الصفر. أيضًا، لا يوجد حد لحجم إطار كائن OLE في هذا الحل.

## **الأسئلة المتكررة**

### لماذا يتغير حجم مخطط Excel المدمج بعد تنشيطه في PowerPoint؟

يحدث ذلك لأن Excel يحاول استعادة حجم النافذة الأصلي عند تنشيطه الأول، بينما يمتلك إطار OLE في PowerPoint أبعاده الخاصة. يتفاوض PowerPoint وExcel على الحجم للحفاظ على نسبة الأبعاد، مما قد يسبب التحجيم.

### هل من الممكن منع هذه المشكلة تمامًا؟

نعم. من خلال مطابقة حجم نافذة مصنف Excel أو حجم المخطط مع حجم إطار OLE قبل الإدماج، يمكنك الحفاظ على أبعاد المخطط ثابتة.

### أي نهج يجب أن أختار، ضبط حجم نافذة المصنف أم ضبط حجم المخطط؟

استخدم **Approach 1 (window size)** إذا كنت تريد الحفاظ على نسبة أبعاد المصنف وربما السماح بإعادة التحجيم لاحقًا.  
استخدم **Approach 2 (chart size)** إذا كانت أبعاد المخطط ثابتة ولن تتغير بعد الإدماج.

### هل ستعمل هذه الأساليب مع العروض المستندة إلى القوالب والعروض الجديدة على حد سواء؟

نعم. كلا النهجين يعملان بنفس الطريقة للعروض التي تم إنشاؤها من القوالب أو من الصفر.

### هل هناك حد لحجم إطار OLE؟

لا. يمكنك ضبط إطار OLE على أي حجم طالما أنه يتناسب بشكل مناسب مع حجم المصنف أو المخطط.

### هل يمكنني استخدام هذه الأساليب مع المخططات التي تم إنشاؤها في برامج جداول بيانات أخرى؟

تم تصميم الأمثلة لمخططات Excel التي تم إنشاؤها باستخدام Aspose.Cells، ولكن المبادئ تنطبق على برامج جداول البيانات المتوافقة مع OLE الأخرى طالما أنها تدعم خيارات التحجيم المشابهة.

## **الأقسام ذات الصلة**

- [إنشاء مخططات Excel وتضمينها ككائنات OLE في العروض التقديمية](/slides/ar/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)