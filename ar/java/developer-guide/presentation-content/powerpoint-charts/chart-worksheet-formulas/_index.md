---
title: تطبيق صيغ ورقة عمل المخطط في العروض التقديمية بـ Java
linktitle: صيغ ورقة العمل
type: docs
weight: 70
url: /ar/java/chart-worksheet-formulas/
keywords:
- مخطط جدول بيانات
- ورقة عمل المخطط
- صيغة المخطط
- صيغة ورقة العمل
- صيغة جدول البيانات
- دفتر عمل بيانات المخطط
- حساب الصيغة
- ثابت منطقي
- ثابت عددي
- ثابت نصي
- ثابت خطأ
- عامل حسابي
- عامل مقارنة
- نمط A1
- نمط R1C1
- دالة معرفة مسبقًا
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تطبيق صيغ بنمط Excel في ورقات عمل مخططات Aspose.Slides for Java، إعادة حساب القيم، واستخدام النتائج في مخططات PowerPoint."
---
## **نظرة عامة**

عادةً ما تقوم مخططات PowerPoint بتخزين بيانات المصدر في ورقة عمل مضمّنة. في Aspose.Slides for Java، يمكنك الوصول إلى تلك الورقة عبر دفتر عمل بيانات المخطط، كتابة قيم الإدخال، تعيين صيغ إلى الخلايا، حساب الصيغ المدعومة، واستخدام الخلايا المحسوبة كبيانات مخطط.

تشرح هذه المقالة سير العمل الكامل للصيغ: إنشاء مخطط، تعبئة ورقة عمله، تعيين صيغ بنمط A1 أو R1C1، إعادة حسابها، قراءة القيم المحسوبة، ربط تلك الخلايا بسلسلة مخطط، وحفظ العرض التقديمي. كما تصف صyntax الصيغ المدعومة، مجموعة الدالات المدمجة، القيم المخزنة مؤقتًا، الصيغ غير المدعومة، وأخطاء جداول البيانات الخاصة.

## **ورقات عمل المخطط والصيغ**

تحتوي ورقة عمل المخطط على الفئات، أسماء السلاسل، والقيم المستخدمة في المخطط. في PowerPoint، يمكنك فحص الورقة بفتح محرر بيانات المخطط:

![مخطط PowerPoint مع الورقة المضمّنة المفتوحة، يظهر بيانات الفئات والسلاسل](chart-worksheet-formulas_1.png)

في Aspose.Slides، يتم كشف الورقة من خلال واجهة [IChartDataWorkbook](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdataworkbook/). استخدم [IChartDataCell.setFormula](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) لصيغ بنمط A1 و[IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) لصيغ بنمط R1C1. بعد تغيير خلايا الإدخال أو الصيغ، استدعِ [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) لإعادة حساب الصيغ المدعومة وتحديث قيم الخلايا المقابلة.

لا تزال الخلية المحسوبة تكشف عن نتيجتها عبر [IChartDataCell.getValue](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdatacell/#getValue--). هذا مهم عندما تحتاج إلى فحص نتيجة الصيغة في الكود أو استخدام الخلية كنقطة بيانات في المخطط.

## **إنشاء مخطط وحساب صيغ ورقة العمل**

المثال التالي يوضح سير عمل كامل. ينشئ مخطط عمودي تجميعي، يمسح البيانات التجريبية، يكتب قيم الإيرادات والنفقات ربع السنوية، يحسب الربح باستخدام صيغ، يقرأ النتائج، يستخدم الخلايا المحسوبة كقيم مخطط، ويحفظ العرض التقديمي.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 350);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    workbook.clear(worksheetIndex);

    IChartDataCell category1 = workbook.getCell(worksheetIndex, "A2", "Q1");
    IChartDataCell category2 = workbook.getCell(worksheetIndex, "A3", "Q2");
    IChartDataCell category3 = workbook.getCell(worksheetIndex, "A4", "Q3");

    workbook.getCell(worksheetIndex, "B1", "Revenue");
    workbook.getCell(worksheetIndex, "C1", "Expenses");
    workbook.getCell(worksheetIndex, "D1", "Profit");

    workbook.getCell(worksheetIndex, "B2").setValue(120.0);
    workbook.getCell(worksheetIndex, "C2").setValue(80.0);
    workbook.getCell(worksheetIndex, "B3").setValue(150.0);
    workbook.getCell(worksheetIndex, "C3").setValue(95.0);
    workbook.getCell(worksheetIndex, "B4").setValue(135.0);
    workbook.getCell(worksheetIndex, "C4").setValue(110.0);

    IChartDataCell profit1 = workbook.getCell(worksheetIndex, "D2");
    IChartDataCell profit2 = workbook.getCell(worksheetIndex, "D3");
    IChartDataCell profit3 = workbook.getCell(worksheetIndex, "D4");

    profit1.setFormula("B2-C2");
    profit2.setFormula("B3-C3");
    profit3.setFormula("B4-C4");

    workbook.calculateFormulas();

    double q1Profit = ((Number) profit1.getValue()).doubleValue(); // 40
    double q2Profit = ((Number) profit2.getValue()).doubleValue(); // 55
    double q3Profit = ((Number) profit3.getValue()).doubleValue(); // 25

    System.out.println("Q1 profit: " + q1Profit);
    System.out.println("Q2 profit: " + q2Profit);
    System.out.println("Q3 profit: " + q3Profit);

    chart.getChartData().getCategories().add(category1);
    chart.getChartData().getCategories().add(category2);
    chart.getChartData().getCategories().add(category3);

    IChartSeries profitSeries = chart.getChartData().getSeries().add(workbook.getCell(worksheetIndex, "D1"), chart.getType());
    profitSeries.getDataPoints().addDataPointForBarSeries(profit1);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit2);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit3);
    profitSeries.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("chart-formulas.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

تشير نقاط بيانات المخطط إلى `D2:D4`، لذا يستخدم المخطط قيم الربح المحسوبة. لا توجد استدعاءات منفصلة لتحديث المخطط في هذا سير العمل: أعد حساب دفتر العمل أولاً، ثم استخدم أو احفظ بيانات المخطط التي تشير إلى الخلايا المحسوبة.

## **استخدام صيغ بنمط A1**

تحدد توصية A1 الأعمدة بحروف والصفوف بأرقام. عيّن التعبيرات بنمط A1 عبر [IChartDataCell.setFormula](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "C3").setValue(10);
    workbook.getCell(0, "F2").setValue(2);
    workbook.getCell(0, "G2").setValue(3);
    workbook.getCell(0, "H2").setValue(4);

    IChartDataCell cell = workbook.getCell(0, "A2");
    cell.setFormula("C3+SUM(F2:H2)");

    workbook.calculateFormulas();

    Object value = cell.getValue(); // 19
} finally {
    presentation.dispose();
}
```

أشكال الإشارة الشائعة بنمط A1 هي:

| المرجع | نسبي | مطلق | مختلط |
|---|---|---|---|
| الخلية | `A2` | `$A$2` | `A$2`, `$A2` |
| الصف | `2:2` | `$2:$2` | — |
| العمود | `A:A` | `$A:$A` | — |
| النطاق | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

يمكن أن تتغير الإشارات النسبية عندما يتم نقل الصيغة أو نسخها بواسطة تطبيق جدول بيانات. الإشارات المطلقة تثبت كلا الإحداثين، بينما الإشارات المختلطة تثبت إما الصف أو العمود فقط.

## **استخدام صيغ بنمط R1C1**

تحدد توصية R1C1 كلا من الصفوف والأعمدة رقمياً. تستخدم الإشارات النسبية إزاحات داخل أقواس مربعة. عيّن هذه الصيغة عبر [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "B2").setValue(12);
    workbook.getCell(0, "C2").setValue(5);

    IChartDataCell cell = workbook.getCell(0, "D2");
    cell.setR1C1Formula("RC[-2]-RC[-1]");

    workbook.calculateFormulas();

    Object value = cell.getValue(); // 7
} finally {
    presentation.dispose();
}
```

أشكال الإشارة الشائعة بنمط R1C1 هي:

| المرجع | نسبي | مطلق | مختلط |
|---|---|---|---|
| الخلية | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| الصف | `R[2]` | `R2` | — |
| العمود | `C[3]` | `C3` | — |
| النطاق | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

على سبيل المثال، في الخلية `D2`، `RC[-2]` تعني الخلية في نفس الصف عمودين إلى اليسار (`B2`).

## **ثوابت الصيغ والعوامل**

يدعم مُقيم الصيغ المدمج القيم المنطقية، القيم العددية، السلاسل النصية، قيم أخطاء جداول البيانات، العوامل الحسابية، وعوامل المقارنة.

### **الثوابت والأنواع الحرفية**

| النوع | أمثلة | ملاحظات |
|---|---|---|
| منطقي | `TRUE`, `FALSE` | يمكن استخدامها مباشرة في تعبيرات منطقية مثل `A2=TRUE`. |
| رقمى | `1`, `0.5`, `.3`, `1E-2` | يتم دعم الصيغة العادية والعلمية. |
| نصى | `"abc"`, `"2/3/2020 12:00"` | تُحْتَوى السلاسل النصية داخل علامات اقتباس مزدوجة داخل الصيغة. |
| نتيجة خطأ | `#DIV/0!`, `#N/A`, `#REF!` | يمكن أن تُقيم الصيغة إلى قيمة خطأ في جدول البيانات بدلاً من نتيجة عادية. |

هذا المثال يستخدم عدة أنواع ثابتة:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "A2").setValue(false);
    workbook.getCell(0, "B2").setFormula("A2=TRUE");
    workbook.getCell(0, "C2").setFormula("1+0.5");
    workbook.getCell(0, "D2").setFormula(".3*1E-2");
    workbook.getCell(0, "E2").setFormula("\"abc\"");
    workbook.getCell(0, "F2").setFormula("2/0");

    workbook.calculateFormulas();

    Object logicalValue = workbook.getCell(0, "B2").getValue(); // خطأ
    Object numericValue = workbook.getCell(0, "C2").getValue(); // 1.5
    Object scientificValue = workbook.getCell(0, "D2").getValue(); // 0.003
    Object stringValue = workbook.getCell(0, "E2").getValue(); // abc
    Object errorValue = workbook.getCell(0, "F2").getValue(); // #DIV/0!
} finally {
    presentation.dispose();
}
```

### **العوامل الحسابية**

| العامل | المعنى | مثال |
|---|---|---|
| `+` | جمع أو علامة زائد أحادية | `2+3` |
| `-` | طرح أو نفي | `2-3`, `-3` |
| `*` | ضرب | `2*3` |
| `/` | قسمة | `2/3` |
| `%` | نسبة مئوية | `30%` |
| `^` | أس | `2^3` |

استخدم الأقواس لتحديد ترتيب التقييم صراحةً، مثل `(A2+B2)*C2`.

### **عوامل المقارنة**

تُعيد تعبيرات المقارنة قيماً منطقية.

| العامل | المعنى | مثال |
|---|---|---|
| `=` | مساواة | `A2=3` |
| `<>` | عدم مساواة | `A2<>3` |
| `>` | أكبر من | `A2>3` |
| `>=` | أكبر من أو مساوية | `A2>=3` |
| `<` | أصغر من | `A2<3` |
| `<=` | أصغر من أو مساوية | `A2<=3` |

## **الدالات المعرفة مسبقاً المدعومة**

يتضمن Aspose.Slides مُقيم صيغ مدمج لورقات عمل المخطط، لكنه ليس محرك حساب Excel كامل. مجموعة الدالات الموثقة محدودة إلى الدالات أدناه. لا تفترض أن أي دالة Excel عشوائية يمكن إعادة حسابها عبر [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--).

| الدالة | الغرض أو الصيغة المدعومة | مثال |
|---|---|---|
| `ABS` | القيمة المطلقة | `ABS(A2)` |
| `AVERAGE` | المتوسط الحسابي | `AVERAGE(B2:B5)` |
| `CEILING` | تقريب الرقم إلى أعلى مضاعف | `CEILING(A2,5)` |
| `CHOOSE` | اختيار قيمة حسب الفهرس | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | دمج قيم نصية | `CONCAT(A2,B2)` |
| `CONCATENATE` | دمج قيم نصية | `CONCATENATE(A2," ",B2)` |
| `DATE` | إنشاء قيمة تاريخ باستخدام نظام 1900 | `DATE(2026,8,19)` |
| `DAYS` | إرجاع عدد الأيام بين تاريخين | `DAYS(B2,A2)` |
| `FIND` | العثور على نص داخل نص آخر | `FIND("-",A2)` |
| `FINDB` | بحث نصي على مستوى البايت | `FINDB("a",A2)` |
| `IF` | نتيجة شرطية | `IF(A2>0,A2,0)` |
| `INDEX` | صيغة إشارة | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | صيغة متجهة | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | صيغة متجهة | `MATCH(A2,B2:B5,0)` |
| `MAX` | القيمة العظمى | `MAX(B2:B5)` |
| `SUM` | مجموع القيم | `SUM(B2:B5)` |
| `VLOOKUP` | بحث عمودي | `VLOOKUP(A2,B2:D10,3,FALSE)` |

القيود الموضحة في الجدول مهمة: `INDEX` موثقة في صيغة إشارة، بينما `LOOKUP` و`MATCH` موثقتان في صيغهما المتجهة. `DATE` يستخدم نظام التاريخ 1900. يجب اعتبار الدالات غير المذكورة غير مدعومة من قِبَل مُقيم الصيغ في Aspose.Slides ما لم تُوثق بشكل منفصل.

## **إعادة الحساب والقيم المخزنة مؤقتاً**

عادةً ما تخزن ملفات جداول البيانات كلًا من الصيغة والقيمة المحسوبة الأخيرة. لذلك يمكن لـ Aspose.Slides قراءة قيمة مخزنة مؤقتاً من خلال [IChartDataCell.getValue](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdatacell/#getValue--) عند تحميل العرض التقديمي ولم يتم تعديل بيانات المخطط ذات الصلة.

بعد تغيير خلايا الإدخال أو الصيغ، لا تعتمد على نتيجة مخزنة قديمة. استدعِ [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) قبل قراءة القيم المحسوبة أو حفظ بيانات المخطط التي تعتمد عليها.

بالنسبة للصيغ خارج المجموعة المدعومة، قد لا يتمكن Aspose.Slides من تحليل الصيغة أو تحديد تبعياتها. إذا تم تعديل دفتر العمل، لا يمكن الاعتماد على القيمة المخزنة السابقة. في تلك الحالة، قراءة قيمة خلية ذات بيانات غير مدعومة قد تُثير استثناء [CellUnsupportedDataException](https://reference.aspose.com/slides/ar/java/com.aspose.slides/cellunsupporteddataexception/).

إذا كان مخططك يعتمد على دالات Excel لا يُقيمها Aspose.Slides، احسب تلك الصيغ باستخدام محرك جداول بيانات يدعمها واكتب القيم الناتجة مرة أخرى إلى دفتر عمل المخطط. لا تستبدل الصيغ غير المدعومة بقيم مُتَخَمَّنة.

## **معالجة أخطاء الصيغ**

هناك نوعان مختلفان من المشكلات يجب التمييز بينهما.

يمكن أن تكون الصيغة صحيحة ولكن تُنتج نتيجة خطأ في جدول البيانات مثل `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, أو `#VALUE!`. في هذه الحالة، يُعتبر رمز الخطأ نتيجة خلية ويمكن إرجاعه عبر [IChartDataCell.getValue](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdatacell/#getValue--).

يمكن أيضاً أن تفشل الصيغة أثناء التحليل أو الإشارة أو التبعية أو مستوى البيانات المدعومة. يوفر Aspose.Slides استثناءات خاصة بجداول البيانات لهذه الحالات: [CellInvalidFormulaException](https://reference.aspose.com/slides/ar/java/com.aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/ar/java/com.aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/ar/java/com.aspose.slides/cellcircularreferenceexception/), و[CellUnsupportedDataException](https://reference.aspose.com/slides/ar/java/com.aspose.slides/cellunsupporteddataexception/).

عند جلب الصيغ من القوالب أو إدخال المستخدم، عالج هذه الاستثناءات حول إعادة الحساب والوصول إلى القيمة:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell cell = workbook.getCell(0, "A2");
    cell.setFormula("SUM(B2:B5)");

    try {
        workbook.calculateFormulas();
        System.out.println(cell.getValue());
    } catch (CellInvalidFormulaException ex) {
        System.err.println("Invalid formula: " + ex.getMessage());
    } catch (CellInvalidReferenceException ex) {
        System.err.println("Invalid cell reference: " + ex.getMessage());
    } catch (CellCircularReferenceException ex) {
        System.err.println("Circular reference: " + ex.getMessage());
    } catch (CellUnsupportedDataException ex) {
        System.err.println("Unsupported spreadsheet data: " + ex.getMessage());
    }
} finally {
    presentation.dispose();
}
```

## **القيود العملية**

دعم الصيغ في أوراق عمل المخطط مخصص لمجموعة محدودة من حسابات جداول البيانات، وليس لتوافق كامل مع Excel. ضع هذه القيود في اعتبارك عند تصميم سير عمل إبلاغ:

- استخدم فقط الثوابت، والعوامل، والإشارات، والدالات الموثقة عندما تحتاج إلى أن يعيد Aspose.Slides حساب الصيغ.
- أعد الحساب بعد تغيير الخلايا التي تعتمد عليها نتائج الصيغ.
- اعتبر القيم المخزنة مؤقتاً من العروض التقديمية المحملة لقطات، وليس كبديل لإعادة الحساب بعد التعديل.
- اختبر الصيغ من القوالب الموجودة قبل الاعتماد على قيمها المحسوبة، خاصة إذا استخدمت دالات خارج القائمة الموثقة.
- بالنسبة للصيغ التي تتطلب محرك حساب جداول بيانات كامل، احسبها خارجيًا ثم حدّث دفتر عمل المخطط بالقيم الناتجة.

## **الأسئلة المتكررة**

**ما الفرق بين [IChartDataCell.setFormula](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) و[IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-)?**

[IChartDataCell.setFormula](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) يخزن تعبيرًا بنمط A1 مثل `B2-C2`. [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) يخزن تعبيرًا بنمط R1C1 مثل `RC[-2]-RC[-1]`. استخدم النمط الذي يتناسب مع طريقة توليد أو نسخ الصيغ لديك.

**هل أحتاج إلى قراءة الخلية نفسها أم قيمتها بعد الحساب؟**

[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdataworkbook/#getCell-int-java.lang.String-) يُعيد كائنًا من نوع [IChartDataCell](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdatacell/). للحصول على النتيجة المحسوبة، استدعِ طريقة [IChartDataCell.getValue](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdatacell/#getValue--) للخلية بعد إعادة الحساب.

**متى يجب استدعاء [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--)?**

استدعِ [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) بعد تعديل قيم الإدخال أو الصيغ وقبل الاعتماد على النتائج المحسوبة. هذا يُحدّث قيم الصيغ التي يدعمها المُقيم المدمج.

**هل يدعم Aspose.Slides كل دالات Excel؟**

لا. يدعم المُقيم المدمج مجموعة موثقة من الدالات. لا ينبغي افتراض أن الدالات خارج هذه المجموعة ستُعاد حسابها بشكل صحيح. إذا كانت هناك حاجة إلى توافق كامل مع صيغ Excel، قم بإجراء الحساب باستخدام محرك جداول بيانات مناسب واكتب القيم النهائية إلى دفتر عمل المخطط.

**ماذا يحدث إذا كان العرض التقديمي المحمّل يحتوي على صيغة غير مدعومة؟**

إذا لم تتغير بيانات المخطط، قد يظل دفتر العمل يحتوي على قيمة مخزنة مسبقًا. بعد تعديل البيانات ذات الصلة، قد لا تكون هذه القيمة المخزنة صالحة. الوصول إلى خلية لا يمكن معالجة صيغتها قد يثير استثناء [CellUnsupportedDataException](https://reference.aspose.com/slides/ar/java/com.aspose.slides/cellunsupporteddataexception/).

**هل قيم أخطاء الصيغ هي نفسها استثناءات Java؟**

لا. النتيجة مثل `#DIV/0!` هي قيمة جدول بيانات تنتج عن حساب صالح. الاستثناءات مثل [CellInvalidFormulaException](https://reference.aspose.com/slides/ar/java/com.aspose.slides/cellinvalidformulaexception/) أو [CellCircularReferenceException](https://reference.aspose.com/slides/ar/java/com.aspose.slides/cellcircularreferenceexception/) تشير إلى أن الصيغة لا يمكن معالجتها بصورة طبيعية.

**هل يتم تحديث المخطط تلقائيًا عندما تتغير خلية الصيغة؟**

يمكن لسلسلة مخطط الإشارة إلى خلايا دفتر العمل. أعد حساب دفتر العمل أولًا، ثم احفظ أو شارِك العرض التقديمي. إذا كانت نقاط بيانات المخطط تشير إلى الخلايا المحسوبة، سيستخدم المخطط تلك القيم المحدثة؛ لا تحتاج إلى طريقة تحديث منفصلة للمخطط في هذا سير العمل.

**هل يمكن للمخططات استخدام دفتر عمل Excel خارجي؟**

نعم، يمكن تكوين بيانات المخطط لاستخدام دفتر عمل خارجي عبر واجهة برمجة بيانات المخطط. ومع ذلك، فإن سير عمل حساب الصيغ الموضح في هذه المقالة يخص دفتر عمل بيانات المخطط ومجموعة الصيغ التي يُقيّمها Aspose.Slides. لا تفترض أن [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) يوفر إعادة حساب كاملة لصيغ عشوائية في ملف XLSX خارجي.

**هل يمكنني استخدام صيغ تُشير إلى ورقة عمل أو دفتر عمل آخر؟**

قد توجد إشارات بنمط Excel في دفاتر عمل المخطط، لكن تقييم الصيغ يقتصر على المُحلل ومجموعة الدالات المدعومة. إذا كان الإشارة عبر ورقة أو ملف خارجي ضرورية، تحقق من صلاحية الصيغة الدقيقة مع إصدار Aspose.Slides المستهدف لديك. بالنسبة لسير العمل الذي يتطلب توافقًا واسعًا مع مراجع Excel، احسب دفتر العمل خارجيًا واكتب القيم المُست resolved مرة أخرى إلى بيانات المخطط.

**هل يجب أن تبدأ سلاسل الصيغ بـ `=`؟**

أمثلة API في Aspose.Slides تعيين تعبيرات مثل `B2-C2` أو `SUM(B2:B5)` دون علامة `=` مسبقة. استخدام هذا الشكل يُحافظ على توافق الصيغ المنشأة مع أمثلة API الموضحة.