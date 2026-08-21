---
title: تطبيق صيغ ورقة عمل المخططات في العروض التقديمية على Android
linktitle: صيغ ورقة العمل
type: docs
weight: 70
url: /ar/androidjava/chart-worksheet-formulas/
keywords:
- جدول بيانات المخطط
- ورقة عمل المخطط
- صيغة المخطط
- صيغة ورقة العمل
- صيغة جدول البيانات
- دفتر عمل بيانات المخطط
- حساب الصيغة
- الثقافة المفضلة
- صيغة مخصصة للثقافة
- DBCS
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
description: "تطبيق صيغ بنمط Excel في Aspose.Slides لنظام Android عبر أوراق عمل المخططات المكتوبة بجافا، وإعادة حساب القيم واستخدام النتائج في مخططات PowerPoint."
---
## **نظرة عامة**

عادةً ما تخزن مخططات PowerPoint بيانات المصدر الخاصة بها في ورقة عمل مدمجة. في Aspose.Slides لنظام Android عبر Java، يمكنك الوصول إلى تلك الورقة عبر دفتر عمل بيانات المخطط، كتابة القيم المدخلة، تعيين الصيغ في الخلايا، حساب الصيغ المدعومة، واستخدام الخلايا المحسوبة كبيانات للمخطط.

تشرح هذه المقالة سير عمل الصيغة الكامل: إنشاء مخطط، تعبئة ورقة عمله، تعيين صيغ بنمط A1 أو R1C1، إعادة حسابها، قراءة القيم المحسوبة، ربط تلك الخلايا بسلسلة مخطط، وحفظ العرض. كما تصف بنية الصيغة المدعومة، مجموعة الدوال المدمجة، القيم المخزنة مؤقتًا، الصيغ غير المدعومة، وأخطاء الجداول.

## **أوراق عمل المخططات والصيغ**

تحتوي ورقة عمل المخطط على الفئات، أسماء السلاسل، والقيم المستخدمة بواسطة المخطط. في PowerPoint، يمكنك فحص ورقة العمل بفتح محرر بيانات المخطط:

![مخطط PowerPoint مع ورقة العمل المدمجة مفتوحة، تظهر بيانات الفئات والسلاسل](chart-worksheet-formulas_1.png)

في Aspose.Slides، يتم كشف ورقة العمل عبر الواجهة [IChartDataWorkbook](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdataworkbook/). استخدم [IChartDataCell.setFormula](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) لصيغ نمط A1 و[IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) لصيغ نمط R1C1. بعد تعديل خلايا الإدخال أو الصيغ، استدعِ [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) لإعادة حساب الصيغ المدعومة وتحديث قيم الخلايا المقابلة.

لا يزال الخلية المحسوبة تُظهر نتيجتها عبر [IChartDataCell.getValue](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdatacell/#getValue--). هذا مهم عندما تحتاج إلى فحص نتيجة الصيغة في الشيفرة أو استخدام الخلية كنقطة بيانات للمخطط.

## **إنشاء مخطط وحساب صيغ ورقة العمل**

يُظهر المثال التالي سير عمل من البداية إلى النهاية. يقوم بإنشاء مخطط عمودي مجمع، مسح البيانات التجريبية، كتابة قيم الإيرادات والنفقات ربع السنوية، حساب الربح باستخدام الصيغ، قراءة النتائج، استخدام الخلايا المحسوبة كقيم للمخطط، وحفظ العرض.

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

تشير نقاط بيانات المخطط إلى `D2:D4`، لذا يستخدم المخطط قيم الربح المحسوبة. لا توجد استدعاء منفصل لتحديث المخطط في هذا سير العمل: أعد حساب دفتر العمل أولاً، ثم استخدم أو احفظ بيانات المخطط التي تشير إلى الخلايا المحسوبة.

## **استخدام صيغ نمط A1**

تُحدد صيغة A1 الأعمدة بالأحرف والصفوف بالأرقام. عيّن تعبيرات نمط A1 عبر [IChartDataCell.setFormula](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-).

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

| المرجع | النسبي | المطلق | المختلط |
|---|---|---|---|
| خلية | `A2` | `$A$2` | `A$2`, `$A2` |
| صف | `2:2` | `$2:$2` | — |
| عمود | `A:A` | `$A:$A` | — |
| نطاق | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

يمكن أن تتغير المراجع النسبية عندما يتم نقل الصيغة أو نسخها بواسطة تطبيق الجدول. المراجع المطلقه تبقي كلا الإحداثيين ثابتين، بينما المراجع المختلطة تثبت فقط صفًا أو عمودًا.

## **استخدام صيغ نمط R1C1**

تحدد صيغة R1C1 كلًا من الصفوف والأعمدة عدديًا. المراجع النسبية تستخدم إزاحات داخل أقواس مربعة. عيّن هذه البنية عبر [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-).

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

| المرجع | النسبي | المطلق | المختلط |
|---|---|---|---|
| خلية | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| صف | `R[2]` | `R2` | — |
| عمود | `C[3]` | `C3` | — |
| نطاق | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

على سبيل المثال، في الخلية `D2`، `RC[-2]` تعني الخلية في نفس الصف عمودين إلى اليسار (`B2`).

## **ثوابت الصيغة والعوامل**

يدعم مُقيم الصيغ المدمج القيم المنطقية، القيم العددية، السلاسل النصية، قيم أخطاء الجداول، العوامل الحسابية، وعوامل المقارنة.

### **الثوابت والقيّم الحرفية**

| النوع | أمثلة | ملاحظات |
|---|---|---|
| منطقي | `TRUE`, `FALSE` | يمكن استخدامها مباشرة في تعبيرات منطقية مثل `A2=TRUE`. |
| رقمي | `1`, `0.5`, `.3`, `1E-2` | يتم دعم الصيغة العادية والعلمية. |
| نصي | `"abc"`, `"2/3/2020 12:00"` | تُحاط القيم النصية بعلامات اقتباس مزدوجة داخل الصيغة. |
| نتيجة خطأ | `#DIV/0!`, `#N/A`, `#REF!` | يمكن أن تُقيم صيغة صحيحة إلى قيمة خطأ في الجدول بدلًا من نتيجة عادية. |

هذا المثال يستخدم عدة أنواع من الثوابت:

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
| `+` | الإضافة أو علامة الجمع الأحادي | `2+3` |
| `-` | الطرح أو الإشارة السالبة | `2-3`, `-3` |
| `*` | الضرب | `2*3` |
| `/` | القسمة | `2/3` |
| `%` | النسبة المئوية | `30%` |
| `^` | الأس | `2^3` |

استخدم الأقواس لتحديد ترتيب التقييم صراحةً، على سبيل المثال `(A2+B2)*C2`.

### **عوامل المقارنة**

التعبيرات المقارنة تُعيد قيمًا منطقية.

| العامل | المعنى | مثال |
|---|---|---|
| `=` | يساوي | `A2=3` |
| `<>` | ليس مساوٍ | `A2<>3` |
| `>` | أكبر من | `A2>3` |
| `>=` | أكبر من أو يساوي | `A2>=3` |
| `<` | أصغر من | `A2<3` |
| `<=` | أصغر من أو يساوي | `A2<=3` |

## **الدوال المعرفة مسبقًا المدعومة**

يتضمن Aspose.Slides مُقيم صيغ مدمج لأوراق عمل المخططات، لكنه ليس محرك حساب Excel كامل. مجموعة الدوال الموثقة محدودة إلى الدوال أدناه. لا تفترض أن أي دالة Excel عشوائية يمكن إعادة حسابها عبر [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--).

| الدالة | الغرض أو الشكل المدعوم | مثال |
|---|---|---|
| `ABS` | القيمة المطلقة | `ABS(A2)` |
| `AVERAGE` | المتوسط الحسابي | `AVERAGE(B2:B5)` |
| `CEILING` | تقريب الرقم للأعلى إلى أقرب مضاعف | `CEILING(A2,5)` |
| `CHOOSE` | اختيار قيمة حسب الفهرس | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | دمج قيم نصية | `CONCAT(A2,B2)` |
| `CONCATENATE` | دمج قيم نصية | `CONCATENATE(A2," ",B2)` |
| `DATE` | إنشاء قيمة تاريخ باستخدام نظام تاريخ 1900 | `DATE(2026,8,19)` |
| `DAYS` | إرجاع عدد الأيام بين تاريخين | `DAYS(B2,A2)` |
| `FIND` | بحث عن قيمة نصية داخل أخرى | `FIND("-",A2)` |
| `FINDB` | بحث نصي على أساس البايت | `FINDB("a",A2)` |
| `IF` | نتيجة شرطية | `IF(A2>0,A2,0)` |
| `INDEX` | نموذج مرجعي | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | نموذج متجه | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | نموذج متجه | `MATCH(A2,B2:B5,0)` |
| `MAX` | القيمة القصوى | `MAX(B2:B5)` |
| `SUM` | مجموع القيم | `SUM(B2:B5)` |
| `VLOOKUP` | بحث عمودي | `VLOOKUP(A2,B2:D10,3,FALSE)` |

القيود الموضحة في الجدول هامة: `INDEX` موثَّق في شكل مرجعي، بينما `LOOKUP` و`MATCH` موثَّقان في شكلهما المتجه. `DATE` يستخدم نظام تاريخ 1900. يجب التعامل مع الميزات والدوال غير المذكورة هنا كغير مدعومة من قبل مُقيم صيغ Aspose.Slides ما لم يتم توثيقها بصورة منفصلة.

## **حساب الصيغ باستخدام ثقافة مفضلة**

بعض دوال دفتر عمل المخطط تفسّر النص وفق قواعد ثقافية محددة. هذا مهم خصوصًا للدوال المخصصة للغات التي تستخدم مجموعة أحرف مزدوجة البايت (DBCS). لحساب هذه الصيغ بشكل صحيح، أنشئ [LoadOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/loadoptions/)، اضبط الثقافة المفضلة عبر [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/spreadsheetoptions/#setPreferredCulture-java.util.Locale-)، عيّن خيارات الجدول عبر [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-)، ثم حمّل العرض.

```java
import com.aspose.slides.*;
import java.util.Locale;

Locale japaneseCulture = Locale.forLanguageTag("ja-JP");

ISpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setPreferredCulture(japaneseCulture);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                IChart chart = (IChart) shape;
                chart.getChartData().getChartDataWorkbook().calculateFormulas();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

المثال التالي يختار الثقافة اليابانية، يفتح عرضًا باستخدام خيارات التحميل المكوَّنة، ويستدعي [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) لكل دفتر عمل مخطط:

الثقافة المفضلة هي جزء من تكوين تحميل العرض، لذا حددها قبل إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/). استخدم الثقافة المتوقعة من قبل صيغ دفتر العمل؛ على سبيل المثال، استخدم `ja-JP` للصيغ التي يجب أن تتبع قواعد حساب DBCS اليابانية.

## **إعادة الحساب والقيم المخزنة مؤقتًا**

غالبًا ما تخزن ملفات الجداول كلًا من الصيغة وقيمتها المحسوبة الأخيرة. لذلك يمكن لـ Aspose.Slides قراءة قيمة مخزنة مؤقتًا من [IChartDataCell.getValue](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdatacell/#getValue--) عند تحميل عرض ولم يتم تغيير بيانات المخطط ذات الصلة.

بعد تعديل خلايا الإدخال أو الصيغ، لا تعتمد على نتيجة مخزنة قديمة. استدعِ [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) قبل قراءة القيم المحسوبة أو حفظ بيانات المخطط التي تعتمد عليها.

بالنسبة للصيغ خارج النطاق المدعوم، قد لا يتمكن Aspose.Slides من تحليل الصيغة أو تحديد تبعياتها. إذا تم تعديل دفتر العمل، لا يمكن اعتبار القيمة المخزنة السابقة موثوقة. في تلك الحالة، قد يؤدي قراءة قيمة خلية ذات بيانات غير مدعومة إلى رفع استثناء [CellUnsupportedDataException](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/cellunsupporteddataexception/).

إذا كان مخططك يعتمد على دوال Excel لا يقوم Aspose.Slides بتقييمها، احسب تلك الصيغ باستخدام محرك جداول يدعمها واكتب القيم الناتجة مرة أخرى إلى دفتر عمل المخطط. لا تستبدل الصيغ غير المدعومة بقيم تخمين.

## **معالجة أخطاء الصيغة**

هناك نوعان مختلفان من المشكلات يجب التمييز بينها.

يمكن أن تكون الصيغة صحيحة لكنها تنتج نتيجة خطأ في الجدول مثل `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, أو `#VALUE!`. في هذه الحالة، يكون رمز الخطأ نتيجة خلية ويمكن إرجاعه عبر [IChartDataCell.getValue](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdatacell/#getValue--).

يمكن أن تفشل الصيغة أيضًا أثناء التحليل أو الإشارة أو التبعية أو على مستوى البيانات المدعومة. يوفر Aspose.Slides استثناءات خاصة بالجداول لهذه الحالات: [CellInvalidFormulaException](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/cellcircularreferenceexception/), و[CellUnsupportedDataException](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/cellunsupporteddataexception/).

عند جلب الصيغ من القوالب أو مدخلات المستخدم، عالج هذه الاستثناءات حول إعادة الحساب والوصول إلى القيم:

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

دعم الصيغ في أوراق عمل المخططات مخصص لمجموعة محدودة من حسابات الجداول، وليس لتوافق كامل مع Excel. ضع هذه القيود في الاعتبار عند تصميم سير عمل تقارير:

- استخدم فقط الثوابت، العوامل، المراجع، والدوال الموثقة عندما تحتاج إلى أن يقوم Aspose.Slides بإعادة حساب الصيغ.
- أعد الحساب بعد تعديل الخلايا التي تعتمد نتائج الصيغة عليها.
- اعتبر القيم المخزنة مؤقتًا من العروض المحمَّلة لقطات سريعة، وليس بديلاً عن إعادة الحساب بعد التعديلات.
- اختبر الصيغ من القوالب الموجودة قبل الاعتماد على قيمها المحسوبة، خصوصًا إذا استخدمت دوالًا خارج القائمة الموثقة.
- بالنسبة للصيغ التي تتطلب محرك حساب جداول كامل، احسبها خارجيًا ثم حدّث دفتر عمل المخطط بالقيم الناتجة.

## **الأسئلة المتكررة**

**ما الفرق بين [IChartDataCell.setFormula](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) و[IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-)?**

[IChartDataCell.setFormula] يخزن تعبيرًا بنمط A1 مثل `B2-C2`. [IChartDataCell.setR1C1Formula] يخزن تعبيرًا بنمط R1C1 مثل `RC[-2]-RC[-1]`. استخدم الصيغة التي تتطابق أفضل مع طريقة إنشاء الصيغ أو نسخها.

**هل أحتاج إلى قراءة الخلية نفسها أم قيمتها بعد الحساب؟**

[IChartDataWorkbook.getCell] يُعيد كائنًا من النوع [IChartDataCell]. للحصول على النتيجة المحسوبة، استدعِ طريقة [IChartDataCell.getValue] لتلك الخلية بعد إعادة الحساب.

**متى يجب استدعاء [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--)?**

استدعِ [IChartDataWorkbook.calculateFormulas] بعد تعديل القيم المدخلة أو الصيغ وقبل الاعتماد على النتائج المحسوبة. هذا يُحدّث قيم الصيغ التي يدعمها المُقيم المدمج.

**هل يدعم Aspose.Slides كل دالة من Excel؟**

لا. يدعم المُقيم المدمج مجموعة جزئية موثقة من الدوال. لا ينبغي اعتبار الدوال خارج تلك المجموعة قابلة لإعادة الحساب بشكل صحيح. إذا كانت هناك حاجة لتوافق كامل مع صيغ Excel، يجب إجراء الحساب باستخدام محرك جداول مناسب وكتابة القيم النهائية إلى دفتر عمل المخطط.

**ماذا يحدث إذا احتوى عرض محمَّل على صيغة غير مدعومة؟**

إذا لم تتغير بيانات المخطط، قد لا يزال دفتر العمل يحتوي على قيمة مخزنة مسبقًا. بعد تعديل البيانات ذات الصلة، قد لا تكون تلك القيمة المخزنة صالحة. محاولة قراءة خلية بصيغة غير مدعومة قد تُثير استثناء [CellUnsupportedDataException].

**هل قيم أخطاء الصيغة هي نفسها استثناءات Java؟**

لا. النتيجة مثل `#DIV/0!` هي قيمة جدول تنتج عن حساب صالح. الاستثناءات مثل [CellInvalidFormulaException] أو [CellCircularReferenceException] تشير إلى أن الصيغة لا يمكن معالجتها بصورة طبيعية.

**هل يتم تحديث المخطط تلقائيًا عند تغير خلية صيغية؟**

يمكن لسلسلة المخطط الإشارة إلى خلايا دفتر العمل. أعد حساب دفتر العمل أولاً، ثم احفظ أو صَدِر العرض. إذا أشارت نقاط بيانات المخطط إلى الخلايا المحسوبة، يستخدم المخطط تلك القيم المحدثة؛ لا يلزم استدعاء منفصل لتحديث المخطط.

**هل يمكن للمخططات استخدام دفتر عمل Excel خارجي؟**

نعم، يمكن تكوين بيانات المخطط لاستخدام دفتر عمل خارجي عبر واجهة برمجة بيانات المخطط. ومع ذلك، يختص سير عمل حساب الصيغ الموصوف في هذه المقالة بدفتر عمل بيانات المخطط ومجموعة الصيغ التي يُقيمها Aspose.Slides. لا تفترض أن [IChartDataWorkbook.calculateFormulas] يوفر إعادة حساب كاملة لأي صيغ في ملف XLSX خارجي.

**هل يمكنني استخدام صيغ تشير إلى ورقة عمل أو دفتر عمل آخر؟**

قد توجد مراجع بأسلوب Excel في دفاتر عمل المخططات، لكن تقييم الصيغ محدود بالمُحلل ومجموعة الدوال المدعومة. إذا كان المرجع عبر ورقة أو دفتر عمل ضروريًا، تحقق من صحة الصيغة مع إصدار Aspose.Slides المستهدف. بالنسبة للعمليات التي تتطلب توافقًا واسعًا مع مراجع Excel، احسب دفتر العمل خارجيًا واكتب القيم المحلولة مرة أخرى إلى بيانات المخطط.

**هل يجب أن تبدأ سلاسل الصيغ بـ `=`؟**

أمثلة API في Aspose.Slides تعيين تعبيرات مثل `B2-C2` أو `SUM(B2:B5)` دون `=`. استخدام هذا الشكل يحافظ على توافق الصيغ المولدة مع أمثلة API الموثقة.