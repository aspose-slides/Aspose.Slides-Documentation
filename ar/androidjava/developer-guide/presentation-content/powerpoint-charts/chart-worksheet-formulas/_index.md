---
title: تطبيق صيغ ورقة عمل المخطط في العروض التقديمية على نظام Android
linktitle: صيغ ورقة العمل
type: docs
weight: 70
url: /ar/androidjava/chart-worksheet-formulas/
keywords:
- مخطط جدول بيانات
- ورقة عمل المخطط
- صيغة المخطط
- صيغة ورقة العمل
- صيغة جدول البيانات
- مصنف بيانات المخطط
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
- Android
- Java
- Aspose.Slides
description: "تطبيق صيغ بنمط Excel في Aspose.Slides لنظام Android عبر ورق عمل المخطط بلغة Java، إعادة حساب القيم، واستخدام النتائج في مخططات PowerPoint."
---
## **نظرة عامة**

عادةً ما تخزن مخططات PowerPoint بيانات المصدر في ورقة عمل مدمجة. في Aspose.Slides لنظام Android عبر Java، يمكنك الوصول إلى تلك الورقة من خلال مصنف بيانات المخطط، كتابة قيم الإدخال، تعيين صيغ للخلايا، حساب الصيغ المدعومة، واستخدام الخلايا المحسوبة كبيانات للمخطط.

تشرح هذه المقالة سير عمل الصيغ بالكامل: إنشاء مخطط، تعبئة ورقة العمل الخاصة به، تعيين صيغ بنمط A1 أو بنمط R1C1، إعادة حسابها، قراءة القيم المحسوبة، ربط تلك الخلايا بسلسلة مخطط، وحفظ العرض. كما تصف بنية الصيغة المدعومة، مجموعة الدوال المدمجة، القيم المخزنة مؤقتًا، الصيغ غير المدعومة، وأخطاء الجداول.

## **ورقة عمل المخططات والصيغ**

تحتوي ورقة عمل المخطط على الفئات وأسماء السلاسل والقيم المستخدمة في المخطط. في PowerPoint، يمكنك فحص الورقة بفتح محرر بيانات المخطط:

![مخطط PowerPoint مع ورقة العمل المدمجة مفتوحة، يعرض الفئات وبيانات السلاسل](chart-worksheet-formulas_1.png)

في Aspose.Slides، تُعرض الورقة عبر الواجهة [IChartDataWorkbook](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdataworkbook/). استخدم [IChartDataCell.setFormula](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) لصيغ بنمط A1 و[IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) لصيغ بنمط R1C1. بعد تعديل خلايا الإدخال أو الصيغ، استدعِ [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) لإعادة حساب الصيغ المدعومة وتحديث قيم الخلايا المقابلة.

لا يزال الخلية المحسوبة تعرض نتيجتها عبر [IChartDataCell.getValue](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdatacell/#getValue--). هذا مهم عندما تحتاج إلى فحص نتيجة الصيغة في الكود أو استخدام الخلية كنقطة بيانات للمخطط.

## **إنشاء مخطط وحساب صيغ ورقة العمل**

المثال التالي يوضح سير عمل من البداية إلى النهاية. إنه ينشئ مخطط أعمدة مجموعات، يمسح البيانات التجريبية، يكتب قيم الإيرادات والمصروفات ربع السنوية، يحسب الربح باستخدام الصيغ، يقرأ النتائج، يستخدم الخلايا المحسوبة كقيم للمخطط، ويحفظ العرض.

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

تشير نقاط بيانات المخطط إلى `D2:D4`، لذلك يستخدم المخطط قيم الربح المحسوبة. لا توجد دعوة منفصلة لتحديث المخطط في هذا سير العمل: أعد حساب المصنف أولاً، ثم استخدم أو احفظ بيانات المخطط التي تشير إلى الخلايا المحسوبة.

## **استخدام صيغ بنمط A1**

يُعرّف ترميز A1 الأعمدة بالحروف والصفوف بالأرقام. عيّن التعبيرات بنمط A1 عبر [IChartDataCell.setFormula](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-).

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

الأشكال الشائعة للمرجع بنمط A1 هي:

| المرجع | نسبي | مطلق | مختلط |
|---|---|---|---|
| خلية | `A2` | `$A$2` | `A$2`, `$A2` |
| صف | `2:2` | `$2:$2` | — |
| عمود | `A:A` | `$A:$A` | — |
| نطاق | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

يمكن أن تتغير المراجع النسبية عند نقل الصيغة أو نسخها بواسطة تطبيق الجداول. المراجع المطلقة تحافظ على كلا الإحداثين ثابتين، بينما المراجع المختلطة تثبت إما الصف أو العمود فقط.

## **استخدام صيغ بنمط R1C1**

يُعرّف ترميز R1C1 كلًّا من الصفوف والأعمدة رقميًا. المراجع النسبية تستخدم إزاحات داخل أقواس مربعة. عيّن هذا الترميز عبر [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-).

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

الأشكال الشائعة للمرجع بنمط R1C1 هي:

| المرجع | نسبي | مطلق | مختلط |
|---|---|---|---|
| خلية | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| صف | `R[2]` | `R2` | — |
| عمود | `C[3]` | `C3` | — |
| نطاق | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

على سبيل المثال، في الخلية `D2`، `RC[-2]` يعني الخلية في نفس الصف عمودين إلى اليسار (`B2`).

## **ثوابت الصيغ وعواملها**

يدعم مقيم الصيغ المدمج القيم المنطقية، القيم الرقمية، السلاسل النصية، قيم الأخطاء في الجداول، عوامل حسابية، وعوامل مقارنة.

### **الثوابت والأنواع النصية**

| النوع | أمثلة | ملاحظات |
|---|---|---|
| منطقي | `TRUE`, `FALSE` | يمكن استخدامها مباشرة في تعبيرات منطقية مثل `A2=TRUE`. |
| رقمي | `1`, `0.5`, `.3`, `1E-2` | تدعم الصيغة العادية والعلمية. |
| نص | `"abc"`, `"2/3/2020 12:00"` | توضع السلاسل النصية داخل علامات اقتباس مزدوجة داخل الصيغة. |
| نتيجة خطأ | `#DIV/0!`, `#N/A`, `#REF!` | قد تُقيم صيغة صالحة إلى قيمة خطأ في الجدول بدلًا من نتيجة عادية. |

يستخدم هذا المثال عدة أنواع من الثوابت:

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

### **عوامل حسابية**

| العامل | المعنى | المثال |
|---|---|---|
| `+` | الجمع أو علامة زائد أحادية | `2+3` |
| `-` | الطرح أو سالب أحادي | `2-3`, `-3` |
| `*` | الضرب | `2*3` |
| `/` | القسمة | `2/3` |
| `%` | النسبة المئوية | `30%` |
| `^` | القوة | `2^3` |

استخدم الأقواس لتوضيح ترتيب التقييم، مثال `(A2+B2)*C2`.

### **عوامل مقارنة**

تُعيد تعبيرات المقارنة قيمًا منطقية.

| العامل | المعنى | المثال |
|---|---|---|
| `=` | يساوي | `A2=3` |
| `<>` | لا يساوي | `A2<>3` |
| `>` | أكبر من | `A2>3` |
| `>=` | أكبر من أو يساوي | `A2>=3` |
| `<` | أقل من | `A2<3` |
| `<=` | أقل من أو يساوي | `A2<=3` |

## **الدوال المعرفة مسبقًا المدعومة**

يتضمن Aspose.Slides مقيم صيغ مدمج لورق عمل المخططات، لكنه ليس محرك حساب Excel كامل. مجموعة الدوال الموثقة محدودة إلى الدوال أدناه. لا تفترض أن أي دالة Excel عشوائية يمكن إعادة حسابها عبر [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--).

| الدالة | الغرض أو الشكل المدعوم | المثال |
|---|---|---|
| `ABS` | القيمة المطلقة | `ABS(A2)` |
| `AVERAGE` | المتوسط الحسابي | `AVERAGE(B2:B5)` |
| `CEILING` | تقريب الرقم للأعلى إلى أقرب مضاعف | `CEILING(A2,5)` |
| `CHOOSE` | اختيار قيمة حسب الفهرس | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | دمج قيم نصية | `CONCAT(A2,B2)` |
| `CONCATENATE` | دمج قيم نصية | `CONCATENATE(A2," ",B2)` |
| `DATE` | إنشاء قيمة تاريخ باستخدام نظام 1900 | `DATE(2026,8,19)` |
| `DAYS` | إرجاع عدد الأيام بين تاريخين | `DAYS(B2,A2)` |
| `FIND` | البحث عن قيمة نصية داخل أخرى | `FIND("-",A2)` |
| `FINDB` | بحث نصي على أساس البايت | `FINDB("a",A2)` |
| `IF` | نتيجة شرطية | `IF(A2>0,A2,0)` |
| `INDEX` | شكل مرجعي | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | شكل متجه | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | شكل متجه | `MATCH(A2,B2:B5,0)` |
| `MAX` | القيمة العظمى | `MAX(B2:B5)` |
| `SUM` | جمع القيم | `SUM(B2:B5)` |
| `VLOOKUP` | بحث عمودي | `VLOOKUP(A2,B2:D10,3,FALSE)` |

القيود الموضحة في الجدول مهمة: `INDEX` موثقة في الشكل المرجعي، بينما `LOOKUP` و`MATCH` موثقة في أشكالهما المتجهية. `DATE` يستخدم نظام تاريخ 1900. يجب اعتبار الدوال غير المدرجة هنا غير مدعومة من قبل مقيم الصيغ في Aspose.Slides ما لم توثق بشكل منفصل.

## **إعادة الحساب والقيم المخزنة مؤقتًا**

تخزن ملفات الجداول عادةً كلًا من الصيغة وآخر قيمة محسوبة لها. لذلك يمكن لـ Aspose.Slides قراءة قيمة مخزنة مؤقتًا من خلال [IChartDataCell.getValue](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdatacell/#getValue--) عند تحميل العرض إذا لم يتم تغيير بيانات المخطط ذات الصلة.

بعد تعديل خلايا الإدخال أو الصيغ، لا تعتمد على نتيجة مخزنة قديمة. استدعِ [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) قبل قراءة القيم المحسوبة أو حفظ بيانات المخطط التي تعتمد عليها.

بالنسبة للصيغ خارج المجموعة المدعومة، قد لا يتمكن Aspose.Slides من تحليل الصيغة أو تحديد تبعياتها. إذا تم تعديل المصنف، لا يمكن الاعتماد على القيمة المخزنة السابقة. في هذه الحالة، قد يرفع قراءة قيمة خلية ذات بيانات غير مدعومة استثناءً من نوع [CellUnsupportedDataException](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/cellunsupporteddataexception/).

إذا كان مخططك يعتمد على دوال Excel لا يحسبها Aspose.Slides، احسب تلك الصيغ باستخدام محرك جداول يدعمها واكتب القيم الناتجة مرة أخرى إلى مصنف المخطط. لا تستبدل الصيغ غير المدعومة بقيم تخمين.

## **معالجة أخطاء الصيغ**

هناك نوعان مختلفان من المشكلات يجب التفريق بينها.

يمكن أن تكون الصيغة صالحة لكنها تُنتج نتيجة خطأ في الجدول مثل `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, أو `#VALUE!`. في هذه الحالة، يكون رمز الخطأ نتيجة للخلية ويمكن إرجاعه عبر [IChartDataCell.getValue](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdatacell/#getValue--).

يمكن أيضًا أن تفشل الصيغة أثناء التحليل أو المرجع أو الاعتماد أو مستوى البيانات المدعومة. يوفر Aspose.Slides استثناءات خاصة بالجداول لهذه الحالات: [CellInvalidFormulaException](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/cellcircularreferenceexception/), و[CellUnsupportedDataException](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/cellunsupporteddataexception/).

عند استقبال الصيغ من القوالب أو إدخال المستخدم، عالج هذه الاستثناءات حول إعادة الحساب والوصول إلى القيمة:

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

تم تصميم دعم الصيغ في أوراق عمل المخططات لجزء محدد من حسابات الجداول، وليس لتوافق كامل مع Excel. ضع هذه القيود في الاعتبار عند تصميم سير عمل تقارير:

- استخدم فقط الثوابت والعوامل والمراجع والدوال الموثقة عندما تحتاج إلى أن يعيد Aspose.Slides حساب الصيغ.
- أعد الحساب بعد تعديل الخلايا التي تعتمد عليها نتائج الصيغ.
- اعتبر القيم المخزنة مؤقتًا من العروض المحمَّلة لقطات سريعة، وليس بديلاً عن إعادة الحساب بعد التعديلات.
- اختبر الصيغ من القوالب الحالية قبل الاعتماد على قيمها المحسوبة، خاصةً إذا استخدمت دوالًا خارج القائمة الموثقة.
- بالنسبة للصيغ التي تتطلب محرك حساب جداول كامل، احسبها خارجيًا ثم حدّث مصنف المخطط بالقيم الناتجة.

## **الأسئلة المتكررة**

**ما الفرق بين [IChartDataCell.setFormula](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) و[IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-)?**

[IChartDataCell.setFormula](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) يخزن تعبيرًا بنمط A1 مثل `B2-C2`. [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) يخزن تعبيرًا بنمط R1C1 مثل `RC[-2]-RC[-1]`. استخدم الترميز الذي يتناسب مع طريقة إنشاء أو نسخ الصيغ لديك.

**هل أحتاج إلى قراءة الخلية نفسها أم قيمتها بعد الحساب؟**

[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-java.lang.String-) يعيد كائنًا من نوع [IChartDataCell](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdatacell/). للحصول على النتيجة المحسوبة، استدعِ طريقة [IChartDataCell.getValue](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdatacell/#getValue--) للخلية بعد إعادة الحساب.

**متى يجب استدعاء [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--)?**

استدعِ [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) بعد تعديل قيم الإدخال أو الصيغ وقبل الاعتماد على النتائج المحسوبة. هذا يحدث تحديث قيم الصيغ التي يدعمها المقيم المدمج.

**هل يدعم Aspose.Slides كل دوال Excel؟**

لا. يدعم المقيم المدمج مجموعة موثقة من الدوال فقط. لا ينبغي افتراض أن الدوال خارج هذه المجموعة ستُعاد حسابها بشكل صحيح. إذا كان مطلوبًا توافق كامل مع صيغ Excel، نفّذ الحساب باستخدام محرك جداول مناسب واكتب القيم النهائية إلى مصنف المخطط.

**ماذا يحدث إذا كان العرض المحمَّل يحتوي على صيغة غير مدعومة؟**

إذا لم تتغير بيانات المخطط، قد يظل المصنف يحتوي على قيمة مخزنة مسبقًا. بعد تعديل البيانات ذات الصلة، قد لا تكون هذه القيمة المخزنة صالحة. محاولة الوصول إلى خلية لا يمكن معالجة صيغتها قد ترفع استثناءً من نوع [CellUnsupportedDataException](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/cellunsupporteddataexception/).

**هل قيم أخطاء الصيغ هي نفسها استثناءات Java؟**

لا. نتيجة مثل `#DIV/0!` هي قيمة جدول ينتجها حساب صالح. الاستثناءات مثل [CellInvalidFormulaException](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/cellinvalidformulaexception/) أو [CellCircularReferenceException](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/cellcircularreferenceexception/) تشير إلى أن الصيغة لا يمكن معالجتها بشكل طبيعي.

**هل يتم تحديث المخطط تلقائيًا عندما تتغير خلية الصيغة؟**

يمكن لسلسلة المخطط الإشارة إلى خلايا المصنف. أعد حساب المصنف أولاً، ثم احفظ أو عرض العرض. إذا كانت نقاط بيانات المخطط تشير إلى الخلايا المحسوبة، سيستخدم المخطط القيم المحدثة؛ لا يلزم أسلوب تحديث منفصل للمخطط في هذا سير العمل.

**هل يمكن للمخططات استخدام مصنف Excel خارجي؟**

نعم، يمكن تكوين بيانات المخطط لاستخدام مصنف خارجي عبر واجهة برمجة بيانات المخطط. ومع ذلك، فإن سير عمل حساب الصيغ الموصوف في هذه المقالة يخص مصنف بيانات المخطط ومجموعة الصيغ التي يقيمها Aspose.Slides. لا تفترض أن [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) توفر حسابًا كاملاً لأي صيغ في ملف XLSX خارجي.

**هل يمكنني استخدام صيغ تشير إلى ورقة عمل أو مصنف آخر؟**

قد توجد مراجع بنمط Excel في مصنفات المخططات، لكن تقييم الصيغ محدود بالمفسر ومجموعة الدوال المدعومة. إذا كان المرجع عبر أوراق أو ملفات ضروريًا، تحقق من صلاحية الصيغة مع نسخة Aspose.Slides التي تستخدمها. بالنسبة لسير العمل الذي يتطلب توافقًا واسعًا مع مراجع Excel، احسب المصنف خارجيًا واكتب القيم المستخرجة مرة أخرى إلى بيانات المخطط.

**هل يجب أن تبدأ سلاسل الصيغ بـ `=`؟**

أمثلة واجهة Aspose.Slides تُعيّن تعبيرات مثل `B2-C2` أو `SUM(B2:B5)` دون علامة `=` في البداية. استخدام هذا الشكل يبقي الصيغ المتولدة متوافقة مع أمثلة الـ API الموثقة.