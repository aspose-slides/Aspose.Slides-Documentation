---
title: صيغ ورقة عمل الرسم البياني
type: docs
weight: 70
url: /ar/java/chart-worksheet-formulas/
keywords: "معادلات باوربوينت، صيغ جداول بيانات باوربوينت"
description: "معادلات باوربوينت وصيغ جداول البيانات"
---

## **حول صيغة جدول البيانات للرسم البياني في العرض التقديمي**
**جدول بيانات الرسم البياني** (أو ورقة العمل للرسم البياني) في العرض التقديمي هو مصدر البيانات للرسم البياني. يحتوي جدول البيانات على بيانات، يتم تمثيلها على الرسم البياني بطريقة جرافيكية. عند إنشاء رسم بياني في باوربوينت، يتم إنشاء ورقة العمل المرتبطة بهذا الرسم البياني تلقائيًا. يتم إنشاء ورقة العمل للرسم البياني لجميع أنواع الرسوم البيانية: الرسم البياني الخطي، الرسم البياني العمودي، رسم الخطوط الشمسية، الرسم البياني الدائري، إلخ. لرؤية جدول بيانات الرسم البياني في باوربوينت يجب عليك النقر المزدوج على الرسم البياني:

![todo:image_alt_text](chart-worksheet-formulas_1.png)

يحتوي جدول البيانات على أسماء عناصر الرسم البياني (اسم الفئة: *الفئة1*، اسم السلسلة) وجدول مع بيانات رقمية مناسبة لهذه الفئات والسلاسل. بشكل افتراضي، عند إنشاء رسم بياني جديد - يتم تعيين بيانات جدول البيانات بالبيانات الافتراضية. ثم يمكنك تغيير بيانات جدول البيانات في ورقة العمل يدويًا.

عادةً ما يمثل الرسم البياني بيانات معقدة (مثل المحللين الماليين، المحللين العلميين)، حيث تحتوي الخلايا على قيم يتم حسابها من القيم في خلايا أخرى أو من بيانات ديناميكية أخرى. إن حساب قيمة الخلية يدويًا وتكويدها بشكل ثابت في الخلية، يجعل من الصعب تغييرها في المستقبل. إذا قمت بتغيير قيمة خلية معينة، فسيتعين تحديث جميع الخلايا المعتمدة عليها أيضًا. علاوة على ذلك، قد تعتمد بيانات الجدول على بيانات من جداول أخرى، مما يخلق مخطط بيانات تقديمي معقد يحتاج إلى تحديث بطريقة سهلة ومرنة.

**صيغة جدول بيانات الرسم البياني** في العرض التقديمي هي تعبير لحساب وتحديث بيانات جدول بيانات الرسم البياني تلقائيًا. تحدد صيغة جدول البيانات منطق حساب البيانات لخلايا معينة أو مجموعة من الخلايا. صيغة جدول البيانات هي صيغة رياضية أو صيغة منطقية، تستخدم: مراجع الخلايا، الوظائف الرياضية، المشغلين المنطقيين، المشغلين الحسابيين، وظائف التحويل، ثوابت السلسلة، إلخ. يتم كتابة تعريف الصيغة في خلية، ولا تحتوي هذه الخلية على قيمة بسيطة. تقوم صيغة جدول البيانات بحساب القيمة وإرجاعها، ثم تُعين هذه القيمة إلى الخلية. صيغ جدول بيانات الرسم البياني في العروض التقديمية هي في الواقع نفسها كصيغ Excel، وتدعم نفس الوظائف الافتراضية، والمشغلين والثوابت لتنفيذها.

في [**Aspose.Slides**](https://products.aspose.com/slides/java/) يتم تمثيل جدول بيانات الرسم البياني باستخدام 
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartData#getChartDataWorkbook--)  طريقة من 
[**IChartDataWorkbook**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook) النوع. 
يمكن تعيين صيغة جدول البيانات وتغييرها باستخدام 
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-)  الطريقة. 
تدعم ض functionalities التالية للصيغ في Aspose.Slides:

- ثوابت منطقية
- ثوابت عددية
- ثوابت سلسلة
- ثوابت خطأ
- مشغلين حسابيين
- مشغلين مقارنة
- مراجع خلايا بأسلوب A1
- مراجع خلايا بأسلوب R1C1
- وظائف محددة مسبقًا

عادةً ما تخزن جداول البيانات آخر قيم تم حسابها للصيغ. إذا لم تتغير بيانات الرسم البياني بعد تحميل العرض التقديمي - فإن [**IChartDataCell.getValue**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#getValue--)  تعيد تلك القيم أثناء القراءة. ولكن، إذا تم تغيير بيانات جدول البيانات، عند قراءة خاصية **ChartDataCell.Value** ترمي  الاستثناء  [**CellUnsupportedDataException**](https://reference.aspose.com/slides/java/com.aspose.slides/CellUnsupportedDataException)  للصيغ غير المدعومة. هذا لأنه عندما يتم تحليل الصيغ بنجاح، يتم تحديد تبعيات الخلايا وتحديد صحة القيم الأخيرة. ولكن، إذا لم يكن بالإمكان تحليل الصيغة، فلا يمكن ضمان صحة قيمة الخلية.

## **إضافة صيغة جدول بيانات الرسم البياني إلى العرض التقديمي**
أولاً، أضف رسمًا بيانيًا إلى الشريحة الأولى من عرض تقديمي جديد باستخدام 
[IShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addChart-int-float-float-float-float-). 
تُنشئ ورقة العمل الخاصة بالرسم البياني تلقائيًا ويمكن الوصول إليها باستخدام 
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartData#getChartDataWorkbook--) الطريقة:



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

لنكتب بعض القيم في الخلايا باستخدام 
[**IChartDataCell.setValue**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setValue-java.lang.Object-) الخاصية 
من النوع **Object**، مما يعني أنه يمكنك تعيين أي قيمة للخاصية:

```java
workbook.getCell(0, "F2").setValue(-2.5);

workbook.getCell(0, "G3").setValue(6.3);

workbook.getCell(0, "H4").setValue(3);
```

الآن لكتابة صيغة إلى الخلية، يمكنك استخدام 
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) الطريقة:

*ملاحظة*: [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-)  تستخدم لتعيين مراجع خلايا بأسلوب A1. 

لتعيين مرجع خلية 
[R1C1Formula](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#getR1C1Formula--)، يمكنك استخدام 
[**IChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setR1C1Formula-java.lang.String-) الطريقة:

ثم إذا حاولت قراءة القيم من الخلايا B2 و C2، سيتم حسابها:

```java
Object value1 = cell1.getValue(); // 7.8

Object value2 = cell2.getValue(); // 2.1
```

## **الثوابت المنطقية**
يمكنك استخدام الثوابت المنطقية مثل *FALSE* و *TRUE* في صيغ الخلايا:

```java
workbook.getCell(0, "A2").setValue(false);
IChartDataCell cell = workbook.getCell(0, "B2");
cell.setFormula("A2 = TRUE");
Object value = cell.getValue(); // القيمة تحتوي على "false" المنطقية
```

## **الثوابت العددية**
يمكن استخدام الأرقام بصيغ عادية أو علمية لإنشاء صيغة جدول بيانات الرسم البياني:

```java
workbook.getCell(0, "A2").setFormula("1 + 0.5");
workbook.getCell(0, "B2").setFormula(".3 * 1E-2");
```

## **ثوابت السلسلة**
ثابت السلسلة (أو الثابت النصي) هو قيمة محددة تُستخدم كما هي ولا تتغير. قد تكون ثوابت السلسلة: تواريخ، نصوص، أرقام، إلخ:

```java
workbook.getCell(0, "A2").setFormula("\"abc\"");
workbook.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```

## **ثوابت الخطأ**
في بعض الأحيان، قد يكون من غير الممكن حساب النتيجة بواسطة الصيغة. في هذه الحالة، يظهر رمز الخطأ في الخلية بدلاً من قيمتها. كل نوع من أنواع الخطأ له رمز محدد:

- #DIV/0! - تحاول الصيغة القسمة على الصفر.
- #GETTING_DATA - قد يظهر في خلية، بينما لا تزال قيمتها قيد الحساب.
- #N/A - المعلومات مفقودة أو غير متاحة. يمكن أن تشمل بعض الأسباب: الخلايا المستخدمة في الصيغة فارغة، وجود حرف فراغ إضافي، أخطاء إملائية، إلخ.
- #NAME? - قد لا يمكن العثور على خلية معينة أو مكونات صيغة أخرى باسمها.
- #NULL! - قد يظهر عند وجود خطأ في الصيغة، مثل:  (,) أو حرف فراغ استخدم بدلاً من النقطتين (:).
- #NUM! - الرقم في الصيغة قد يكون غير صالح، طويل جدًا أو صغير جدًا، إلخ.
- #REF! - مرجع خلية غير صالح.
- #VALUE! - نوع القيمة غير متوقع. على سبيل المثال، قيمة نصية تم تعيينها إلى خلية عددية.

```java
IChartDataCell cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
Object value = cell.getValue(); // القيمة تحتوي على السلسلة "#DIV/0!"
```

## **المشغلون الحسابيون**
يمكنك استخدام جميع المشغلين الحسابيين في صيغ ورقة عمل الرسم البياني:

|**المشغل** |**المعنى** |**المثال**|
| :- | :- | :- |
|+ (علامة الجمع) |الجمع أو الجمع الأحادي|2 + 3|
|- (علامة الطرح) |الطرح أو السالب |2 - 3<br>-3|
|* (نجمة)|الضرب |2 * 3|
|/ (شرطة مائلة)|القسمة |2 / 3|
|% (علامة النسبة المئوية) |نسبة |30%|
|^ (علامة الأس) |الأس|2 ^ 3|

*ملاحظة*: لتغيير ترتيب التقييم، ضع جزءًا من الصيغة الذي سيتم حسابه أولاً بين قوسين.

## **المشغلون للمقارنة**
يمكنك مقارنة قيم الخلايا باستخدام مشغلين المقارنة. عند مقارنة قيمتين باستخدام هذه المشغلين، تكون النتيجة قيمة منطقية إما *TRUE* أو FALSE:

|**المشغل** |**المعنى** |**المعنى** |
| :- | :- | :- |
|= (علامة المساواة) |تساوي |A2 = 3|
|<> (علامة عدم المساواة) |لا تساوي|A2 <> 3|
|> (علامة أكبر من) |أكبر من|A2 > 3|
|>= (علامة أكبر من أو تساوي)|أكبر من أو يساوي|A2 >= 3|
|< (علامة أصغر من)|أصغر من|A2 < 3|
|<= (علامة أصغر من أو تساوي)|أصغر من أو يساوي|A2 <= 3|

## **مراجع خلايا بأسلوب A1**
**مراجع خلايا بأسلوب A1** تُستخدم في أوراق العمل، حيث تحتوي العمود على معرف حرف (مثل "*A*") والصف على معرف رقمي (مثل "*1*"). يمكن استخدام مراجع خلايا بأسلوب A1 بالطريقة التالية:

|**مرجع الخلية**|**المثال**|||
| :- | :- | :- | :- |
||مطلق |نسبي |مختلط|
|خلية |$A$2 |A2|<p>A$2</p><p>$A2</p>|
|صف |$2:$2 |2:2 |-|
|عمود |$A:$A |A:A |-|
|نطاق |$A$2:$C$4 |A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

إليك مثالاً حول كيفية استخدام مرجع خلية بأسلوب A1 في صيغة:

```java
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```

## **مراجع خلايا بأسلوب R1C1**
**مراجع خلايا بأسلوب R1C1** تُستخدم في أوراق العمل، حيث يحتوي كل من الصف والعمود على معرف رقمي. يمكن استخدام مراجع خلايا بأسلوب R1C1 بالطريقة التالية:

|**مرجع الخلية**|**المثال**|||
| :- | :- | :- | :- |
||مطلق |نسبي |مختلط|
|خلية |R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|صف |R2|R[2]|-|
|عمود |C3|C[3]|-|
|نطاق |R2C3:R5C7|R[2]C[3]:R[5]C[7] |R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


إليك مثالاً حول كيفية استخدام مرجع خلية بأسلوب R1C1 في صيغة:

```java
workbook.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```

## **وظائف محددة مسبقًا**
هناك وظائف محددة مسبقًا، التي يمكن استخدامها في الصيغ لتبسيط تنفيذها. encapsulate هذه الوظائف العمليات الأكثر استخدامًا، مثل: 

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (نظام تاريخ 1900)
- DAYS
- FIND
- FINDB
- IF
- INDEX (شكل مرجع)
- LOOKUP (شكل متجه)
- MATCH (شكل متجه)
- MAX
- SUM
- VLOOKUP