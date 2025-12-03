---
title: تطبيق صيغ ورقة عمل المخطط في العروض التقديمية باستخدام Java
linktitle: صيغ ورقة العمل
type: docs
weight: 70
url: /ar/java/chart-worksheet-formulas/
keywords:
- جدول بيانات الرسم البياني
- ورقة عمل الرسم البياني
- صيغة الرسم البياني
- صيغة ورقة العمل
- صيغة جدول البيانات
- مصدر البيانات
- ثابت منطقي
- ثابت رقمي
- ثابت نصي
- ثابت خطأ
- ثابت حسابي
- عامل مقارنة
- نمط A1
- نمط R1C1
- دالة معرفة مسبقًا
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تطبيق صيغ بنمط Excel في Aspose.Slides لورقات عمل الرسوم البيانية لجافا وأتمتة التقارير عبر ملفات PPT و PPTX."
---

## **حول صيغة جدول البيانات للرسوم البيانية في العرض التقديمي**
**Chart spreadsheet** (أو ورقة عمل الرسم البياني) في العرض التقديمي هي مصدر البيانات للرسمة البيانية. يحتوي **Chart spreadsheet** على بيانات يتم تمثيلها على الرسم البياني بشكل مرئي. عندما تقوم بإنشاء رسم بياني في PowerPoint، يتم إنشاء ورقة العمل المرتبطة بهذا الرسم تلقائيًا أيضًا. يتم إنشاء ورقة عمل الرسم البياني لجميع أنواع الرسوم: مخطط خطي، مخطط شريطي، مخطط شمسية، مخطط دائري، إلخ. لعرض **Chart spreadsheet** في PowerPoint يجب النقر مزدوجًا على الرسم البياني:

![todo:image_alt_text](chart-worksheet-formulas_1.png)


يحتوي **Chart spreadsheet** على أسماء عناصر الرسم البياني (اسم الفئة: *Category1*، اسم السلسلة) وجدول ببيانات رقمية مناسبة لهذه الفئات والسلاسل. بشكل افتراضي، عند إنشاء رسم بياني جديد - يتم ضبط بيانات **Chart spreadsheet** بالبيانات الافتراضية. بعد ذلك يمكنك تعديل بيانات جدول البيانات في ورقة العمل يدويًا.

عادةً ما يمثل الرسم البياني بيانات معقدة (مثل المحللين الماليين أو المحللين العلميّين)، حيث تكون الخلايا محسوبة من القيم في خلايا أخرى أو من بيانات ديناميكية أخرى. حساب قيمة الخلية يدويًا وتثبيتها داخل الخلية يجعل تعديلها في المستقبل صعبًا. إذا غيرت قيمة خلية معينة، سيتطلب تحديث جميع الخلايا الاعتمدة عليها أيضًا. علاوةً على ذلك، قد تعتمد بيانات الجدول على بيانات جداول أخرى، مما يخلق مخطط بيانات عرض تقديمي معقد يحتاج إلى تحديث سهل ومرن.

**Chart spreadsheet formula** في العرض التقديمي هي تعبير لحساب وتحديث بيانات **Chart spreadsheet** تلقائيًا. تُعرّف صيغة جدول البيانات منطق حساب البيانات لخلية معينة أو مجموعة خلايا. صيغة جدول البيانات هي صيغة رياضية أو منطقية، تستخدم: مراجع خلايا، دوال رياضية، عوامل منطقية، عوامل حسابية، دوال تحويل، ثوابت نصية، إلخ. يُكتب تعريف الصيغة داخل خلية، وهذه الخلية لا تحتوي على قيمة بسيطة. تقوم صيغة جدول البيانات بحساب القيمة وإرجاعها، ثم تُعيّن هذه القيمة للخلية. صيغ **Chart spreadsheet** في العروض التقديمية هي في الواقع نفس صيغ Excel، وتدعم نفس الدوال الافتراضية والعوامل والثوابت لتطبيقها.

في [**Aspose.Slides**](https://products.aspose.com/slides/java/) يُمثّل جدول بيانات الرسم البياني باستخدام الطريقة 
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartData#getChartDataWorkbook--) للنوع
[**IChartDataWorkbook**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook). 
يمكن تعيين صيغة جدول البيانات وتغييرها باستخدام الطريقة 
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-). 
الوظائف التالية مدعومة للصيغ في Aspose.Slides:
- ثوابت منطقية
- ثوابت رقمية
- ثوابت نصية
- ثوابت خطأ
- عوامل حسابية
- عوامل مقارنة
- مراجع خلايا بنمط A1
- مراجع خلايا بنمط R1C1
- دوال معرفة مسبقًا

عادةً ما تخزن جداول البيانات قيم الصيغ المحسوبة الأخيرة. إذا لم تتغيّر بيانات الرسم البياني بعد تحميل العرض التقديمي - تُعيد طريقة [**IChartDataCell.getValue**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#getValue--) تلك القيم عند القراءة. ولكن إذا تم تعديل بيانات جدول البيانات، عند قراءة خاصية **ChartDataCell.Value** يتم إطلاق استثناء [**CellUnsupportedDataException**](https://reference.aspose.com/slides/java/com.aspose.slides/CellUnsupportedDataException) بالنسبة للصيغ غير المدعومة. ذلك لأن عندما يتم تحليل الصيغ بنجاح، تُحدد تبعيات الخلية وتُتحقق صحة القيم الأخيرة. أما إذا لم يمكن تحليل الصيغة، فلا يمكن ضمان صحة قيمة الخلية.

## **إضافة صيغة جدول البيانات للرسوم البيانية إلى العرض التقديمي**
أولاً، أضف رسمًا بيانيًا إلى الشريحة الأولى من عرض تقديمي جديد باستخدام 
[IShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addChart-int-float-float-float-float-). 
يتم إنشاء ورقة عمل الرسم تلقائيًا ويمكن الوصول إليها باستخدام الطريقة 
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartData#getChartDataWorkbook--) :
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 150, 150, 500, 300);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    // ...
} finally {
    if (pres != null) pres.dispose();
}
```


لنكتب بعض القيم في الخلايا باستخدام الخاصية 
[**IChartDataCell.setValue**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setValue-java.lang.Object-) 
لنوع **Object**، مما يعني أنه يمكنك تعيين أي قيمة للخاصية:
```java
workbook.getCell(0, "F2").setValue(-2.5);

workbook.getCell(0, "G3").setValue(6.3);

workbook.getCell(0, "H4").setValue(3);
```


الآن لكتابة صيغة في الخلية، يمكنك استخدام الطريقة 
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) :

*ملاحظة*: تُستخدم طريقة [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) لتعيين مراجع خلايا بنمط A1.  

لتعيين مرجع خلية [R1C1Formula](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#getR1C1Formula--)، يمكنك استخدام الطريقة [**IChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setR1C1Formula-java.lang.String-) :

ثم إذا حاولت قراءة القيم من الخلايا B2 و C2، سيتم حسابها:
```java
Object value1 = cell1.getValue(); // 7.8

Object value2 = cell2.getValue(); // 2.1
```


## **ثوابت منطقية**
يمكنك استخدام ثوابت منطقية مثل *FALSE* و *TRUE* في صيغ الخلايا:
```java
workbook.getCell(0, "A2").setValue(false);
IChartDataCell cell = workbook.getCell(0, "B2");
cell.setFormula("A2 = TRUE");
Object value = cell.getValue(); // القيمة تحتوي على قيمة منطقية "false"
```


## **ثوابت رقمية**
يمكن استخدام الأرقام في الصيغ العادية أو العلمية لإنشاء صيغة جدول بيانات الرسم البياني:
```java
workbook.getCell(0, "A2").setFormula("1 + 0.5");
workbook.getCell(0, "B2").setFormula(".3 * 1E-2");
```


## **ثوابت نصية**
الثابت النصي (أو الحرفي) هو قيمة محددة تُستخدم كما هي ولا تتغير. قد تكون الثوابت النصية: تواريخ، نصوص، أرقام، إلخ:
```java
workbook.getCell(0, "A2").setFormula("\"abc\"");
workbook.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```


## **ثوابت الأخطاء**
أحيانًا لا يمكن حساب النتيجة باستخدام الصيغة. في هذه الحالة يُظهر رمز الخطأ في الخلية بدلاً من قيمتها. لكل نوع من الأخطاء رمز محدد:
- #DIV/0! - تحاول الصيغة القسمة على الصفر.
- #GETTING_DATA - قد يظهر في الخلية بينما لا يزال يتم حساب قيمتها.
- #N/A - المعلومات مفقودة أو غير متوفرة. قد يكون السبب: الخلايا المستخدمة في الصيغة فارغة، وجود مساحة إضافية، أو أخطاء إملائية، إلخ.
- #NAME? - لا يمكن العثور على خلية معينة أو كائن صيغة آخر باسمه.
- #NULL! - قد يظهر عندما يكون هناك خطأ في الصيغة، مثل:  (,) أو استخدام مساحة بدلاً من النقطتين (:).
- #NUM! - قد يكون الرقم في الصيغة غير صالح، طويل جدًا أو قصير جدًا، إلخ.
- #REF! - إشارة خلية غير صالحة.
- #VALUE! - نوع قيمة غير متوقع. على سبيل المثال، قيمة نصية وضعت في خلية رقمية.
```java
IChartDataCell cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
Object value = cell.getValue(); // القيمة تحتوي على السلسلة "#DIV/0!"
```


## **عوامل حسابية**
يمكنك استخدام جميع عوامل الحساب في صيغ ورقة عمل الرسم البياني:

|**العامل**|**المعنى**|**مثال**|
| :- | :- | :- |
|+ (علامة الجمع)|جمع أو زائد أحادي|2 + 3|
|- (علامة الطرح)|طرح أو سالب أحادي|2 - 3<br>-3|
|* (نجمة)|ضرب|2 * 3|
|/ (علامة القسمة)|قسمة|2 / 3|
|% (علامة النسبة المئوية)|نسبة مئوية|30%|
|^ (الرمز caret)|أس|2 ^ 3|

*ملاحظة*: لتغيير ترتيب التقييم، ضع الجزء المراد حسابه أولاً بين أقواس.

## **عوامل المقارنة**
يمكنك مقارنة قيم الخلايا باستخدام عوامل المقارنة. عندما تتم مقارنتان قيمتين باستخدام هذه العوامل، تكون النتيجة قيمة منطقية إما *TRUE* أو FALSE:

|**العامل**|**المعنى**|**مثال**|
| :- | :- | :- |
|= (علامة المساواة)|يساوي|A2 = 3|
|<> (علامة عدم المساواة)|ليس مساويًا|A2 <> 3|
|> (علامة أكبر من)|أكبر من|A2 > 3|
|>= (علامة أكبر من أو يساوي)|أكبر من أو يساوي|A2 >= 3|
|< (علامة أصغر من)|أصغر من|A2 < 3|
|<= (علامة أصغر من أو يساوي)|أصغر من أو يساوي|A2 <= 3|

## **مراجع خلايا بنمط A1**
**A1-style cell references** تُستخدم في أوراق العمل التي يكون للعمود معرف حرفي (مثال "*A*") والصف معرف رقمي (مثال "*1*"). يمكن استخدام مراجع خلايا بنمط A1 بالطريقة التالية:

|**مرجع الخلية**|**مثال**|||
| :- | :- | :- | :- |
||مطلق|نسبي|مختلط|
|خلية|$A$2|A2|<p>A$2</p><p>$A2</p>|
|صف|$2:$2|2:2| - |
|عمود|$A:$A|A:A| - |
|نطاق|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

فيما يلي مثال على كيفية استخدام مرجع خلية بنمط A1 في صيغة:
```java
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```


## **مراجع خلايا بنمط R1C1**
**R1C1-style cell references** تُستخدم في أوراق العمل التي يكون لكل من الصف والعمود معرف رقمي. يمكن استخدام مراجع خلايا بنمط R1C1 بالطريقة التالية:

|**مرجع الخلية**|**مثال**|||
| :- | :- | :- | :- |
||مطلق|نسبي|مختلط|
|خلية|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|صف|R2|R[2]|-|
|عمود|C3|C[3]|-|
|نطاق|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

فيما يلي مثال على كيفية استخدام مرجع خلية بنمط R1C1 في صيغة:
```java
workbook.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```


## **دوال معرفة مسبقًا**
توجد دوال معرفة مسبقًا يمكن استخدامها في الصيغ لتبسيط تطبيقها. هذه الدوال تُجمل أكثر العمليات المستخدمة شيوعًا، مثل:
- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (1900 date system)
- DAYS
- FIND
- FINDB
- IF
- INDEX (reference form)
- LOOKUP (vector form)
- MATCH (vector form)
- MAX
- SUM
- VLOOKUP

## **الأسئلة المتكررة**

**هل يتم دعم ملفات Excel الخارجية كمصدر بيانات لرسم بياني يحتوي على صيغ؟**

نعم. يدعم Aspose.Slides دفاتر عمل خارجية كمصدر بيانات للرسوم البيانية، وهو ما يسمح لك باستخدام صيغ من ملف XLSX خارج العرض التقديمي.

**هل يمكن لصيغ الرسوم البيانية الإشارة إلى أوراق داخل نفس دفتر العمل باستخدام اسم الورقة؟**

نعم. تتبع الصيغ نموذج الإشارة القياسي في Excel، لذا يمكنك الإشارة إلى أوراق أخرى داخل نفس دفتر العمل أو دفتر عمل خارجي. بالنسبة للإشارات الخارجية، يجب تضمين المسار واسم دفتر العمل باستخدام صيغة Excel.