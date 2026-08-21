---
title: تطبيق صيغ ورقة عمل المخطط في العروض التقديمية باستخدام Java
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
- دفتر بيانات المخطط
- حساب الصيغة
- الثقافة المفضلة
- صيغة خاصة بالثقافة
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
- Java
- Aspose.Slides
description: "تطبيق صيغ بنمط Excel في أوراق عمل مخططات Aspose.Slides للـ Java، إعادة حساب القيم، واستخدام النتائج في مخططات PowerPoint."
---
## **نظرة عامة**

عادةً ما تخزن مخططات PowerPoint بيانات المصدر الخاصة بها في ورقة عمل مدمجة. في Aspose.Slides for Java، يمكنك الوصول إلى تلك الورقة عبر دفتر بيانات المخطط، كتابة قيم الإدخال، إسناد صيغ إلى الخلايا، حساب الصيغ المدعومة، واستخدام الخلايا المحسوبة كبيانات للمخطط.

تشرح هذه المقالة سير عمل الصيغة بالكامل: إنشاء مخطط، ملء ورقة عمله، إسناد صيغ بنمط A1 أو R1C1، إعادة حسابها، قراءة القيم المحسوبة، ربط تلك الخلايا بسلسلة مخطط، وحفظ العرض التقديمي. كما توضح صyntax الصيغ المدعومة، مجموعة الدوال المدمجة، القيم المخزنة مؤقتاً، الصيغ غير المدعومة، والأخطاء الخاصة بجداول البيانات.

## **أوراق عمل المخططات والصيغ**

تحتوي ورقة عمل المخطط على الفئات، أسماء السلاسل، والقيم المستخدمة في المخطط. في PowerPoint، يمكنك فحص ورقة العمل بفتح محرر بيانات المخطط:

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

في Aspose.Slides، يتم إظهار ورقة العمل عبر واجهة [IChartDataWorkbook](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdataworkbook/). استخدم [IChartDataCell.setFormula](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) للصيغ بنمط A1 و[IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) للصيغ بنمط R1C1. بعد تعديل خلايا الإدخال أو الصيغ، استدعِ [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) لإعادة حساب الصيغ المدعومة وتحديث قيم الخلايا المقابلة.

ما زالت الخلية المحسوبة تعرض نتيجتها عبر [IChartDataCell.getValue](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdatacell/#getValue--). هذا مهم عندما تحتاج إلى فحص نتيجة الصيغة في الشيفرة أو استخدام الخلية كنقطة بيانات للمخطط.

## **إنشاء مخطط وحساب صيغ ورقة العمل**

يوضح المثال التالي سير عمل من البداية للنهاية. فهو يخلق مخطط عمود مجموعات، يمسح البيانات النموذجية، يكتب قيم الإيرادات والنفقات ربع السنوية، يحسب الربح باستخدام صيغ، يقرأ النتائج، يستخدم الخلايا المحسوبة كقيم للمخطط، ويحفظ العرض التقديمي.

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

تشير نقاط بيانات المخطط إلى `D2:D4`، لذا يستخدم المخطط قيم الربح المحسوبة. لا توجد دعوة منفصلة لتحديث المخطط في هذا التدفق: أعد حساب دفتر العمل أولاً، ثم استخدم أو احفظ بيانات المخطط التي تشير إلى الخلايا المحسوبة.

## **استخدام صيغ بنمط A1**

تحدد ترميز A1 الأعمدة بأحرف والصفوف بأرقام. أَسند التعبيرات بنمط A1 عبر [IChartDataCell.setFormula](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-).

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

| مرجع | نسبي | مطلق | مختلط |
|---|---|---|---|
| خلية | `A2` | `$A$2` | `A$2`, `$A2` |
| صف | `2:2` | `$2:$2` | — |
| عمود | `A:A` | `$A:$A` | — |
| نطاق | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

يمكن أن تتغير المراجع النسبية عندما تُنقل الصيغة أو تُنسخها تطبيقات جداول البيانات. المراجع المطلقة تثبت كلا الإحداثيين، بينما المراجع المختلطة تثبت إما الصف أو العمود فقط.

## **استخدام صيغ بنمط R1C1**

يحدد ترميز R1C1 كلًا من الصفوف والأعمدة رقميًا. المراجع النسبية تستخدم إزاحات داخل أقواس مربعة. أَسند هذا الترميز عبر [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-).

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

| مرجع | نسبي | مطلق | مختلط |
|---|---|---|---|
| خلية | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| صف | `R[2]` | `R2` | — |
| عمود | `C[3]` | `C3` | — |
| نطاق | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

على سبيل المثال، في الخلية `D2`، `RC[-2]` تعني الخلية في نفس الصف عمودين إلى اليسار (`B2`).

## **ثوابت الصيغة والعوامل**

يدعم مُقَيِّم الصيغ المدمج القيم المنطقية، القيم العددية، السلاسل النصية، قيم الأخطاء في جداول البيانات، عوامل الجمع والطرح، وعوامل المقارنة.

### **الثوابت والليترال**

| النوع | أمثلة | ملاحظات |
|---|---|---|
| منطقي | `TRUE`, `FALSE` | يمكن استخدامها مباشرة في تعبيرات منطقية مثل `A2=TRUE`. |
| عددي | `1`, `0.5`, `.3`, `1E-2` | يتم دعم الصيغة العادية والعلمية. |
| نص | `"abc"`, `"2/3/2020 12:00"` | تُحاط السلاسل النصية بعلامات اقتباس مزدوجة داخل الصيغة. |
| نتيجة خطأ | `#DIV/0!`, `#N/A`, `#REF!` | يمكن أن تُعيد صيغة صالحة قيمة خطأ من جدول البيانات بدلاً من نتيجة عادية. |

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

    Object logicalValue = workbook.getCell(0, "B2").getValue(); // false
    Object numericValue = workbook.getCell(0, "C2").getValue(); // 1.5
    Object scientificValue = workbook.getCell(0, "D2").getValue(); // 0.003
    Object stringValue = workbook.getCell(0, "E2").getValue(); // abc
    Object errorValue = workbook.getCell(0, "F2").getValue(); // #DIV/0!
} finally {
    presentation.dispose();
}
```

### **عوامل الجمع**

| العامل | المعنى | مثال |
|---|---|---|
| `+` | جمع أو علامة موجب أحادية | `2+3` |
| `-` | طرح أو سالب أحادي | `2-3`, `-3` |
| `*` | ضرب | `2*3` |
| `/` | قسمة | `2/3` |
| `%` | نسبة مئوية | `30%` |
| `^` | أس | `2^3` |

استخدم الأقواس لجعل ترتيب التقييم صريحًا، مثال `(A2+B2)*C2`.

### **عوامل المقارنة**

تُرجع تعبيرات المقارنة قيمًا منطقية.

| العامل | المعنى | مثال |
|---|---|---|
| `=` | مساواة | `A2=3` |
| `<>` | عدم مساواة | `A2<>3` |
| `>` | أكبر من | `A2>3` |
| `>=` | أكبر من أو يساوي | `A2>=3` |
| `<` | أصغر من | `A2<3` |
| `<=` | أصغر من أو يساوي | `A2<=3` |

## **الدالات المعرفة مسبقًا المدعومة**

يتضمن Aspose.Slides مُقَيِّم صيغ مدمج لأوراق عمل المخططات، لكنه ليس محرك حساب Excel كامل. مجموعة الدالات الموثقة محدودة إلى الدالات أدناه. لا تفترض أن أي دالة Excel عشوائية يمكن حسابها عبر [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--).

| دالة | الغرض أو الشكل المدعوم | مثال |
|---|---|---|
| `ABS` | القيمة المطلقة | `ABS(A2)` |
| `AVERAGE` | المتوسط الحسابي | `AVERAGE(B2:B5)` |
| `CEILING` | تقريب عدد إلى أعلى مضاعف | `CEILING(A2,5)` |
| `CHOOSE` | اختيار قيمة حسب الفهرس | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | دمج قيم نصية | `CONCAT(A2,B2)` |
| `CONCATENATE` | دمج قيم نصية | `CONCATENATE(A2," ",B2)` |
| `DATE` | إنشاء قيمة تاريخ باستخدام نظام 1900 | `DATE(2026,8,19)` |
| `DAYS` | إرجاع عدد الأيام بين تاريخين | `DAYS(B2,A2)` |
| `FIND` | العثور على نص داخل نص آخر | `FIND("-",A2)` |
| `FINDB` | بحث نص على أساس البايت | `FINDB("a",A2)` |
| `IF` | نتيجة شرطية | `IF(A2>0,A2,0)` |
| `INDEX` | شكل مرجع | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | شكل متجهي | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | شكل متجهي | `MATCH(A2,B2:B5,0)` |
| `MAX` | القيمة القصوى | `MAX(B2:B5)` |
| `SUM` | جمع القيم | `SUM(B2:B5)` |
| `VLOOKUP` | بحث عمودي | `VLOOKUP(A2,B2:D10,3,FALSE)` |

القيود الموضحة في الجدول هامة: `INDEX` موثقة في شكل مرجع، بينما `LOOKUP` و`MATCH` موثقتان في شكلهما المتجهي. `DATE` يستخدم نظام تاريخ 1900. يجب اعتبار أي ميزات أو دالات غير مدرجة هنا غير مدعومة من قبل مُقَيِّم الصيغ في Aspose.Slides ما لم يتم توثيقها بشكل منفصل.

## **حساب الصيغ مع ثقافة مفضلة**

بعض دالات دفتر عمل المخطط تفسّر النص وفق قواعد ثقافية محددة. هذا مهم خاصةً للدالات المخصصة للغات التي تستخدم مجموعات أحرف مزدوجة البايت (DBCS). لحساب هذه الصيغ بشكل صحيح، أنشئ [LoadOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/loadoptions/)، وحدد الثقافة المفضلة عبر [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/ar/java/com.aspose.slides/spreadsheetoptions/#setPreferredCulture-java.util.Locale-)، وعيّن خيارات جدول البيانات عبر [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-)، ثم حمّل العرض التقديمي.

المثال التالي يختار الثقافة اليابانية، يفتح عرضًا تقديميًا باستخدام خيارات التحميل المكوَّنة، ويدعو [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) لكل دفتر عمل مخطط:

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

تعد الثقافة المفضلة جزءًا من تكوين تحميل العرض، لذا يجب تحديدها قبل إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/). استخدم الثقافة المتوافقة مع صيغ دفتر العمل؛ على سبيل المثال، استخدم `ja-JP` للصيغ التي يجب أن تتبع قواعد حساب DBCS اليابانية.

## **إعادة الحساب والقيم المخزنة مؤقتًا**

عادةً ما تخزن ملفات جداول البيانات كلًا من الصيغة وقيمتها الأخيرة المحسوبة. يمكن لـ Aspose.Slides therefore قراءة قيمة مخزنة مؤقتًا من [IChartDataCell.getValue](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdatacell/#getValue--) عند تحميل العرض التقديمي ولم يتغير بيانات المخطط ذات الصلة.

بعد تعديل خلايا الإدخال أو الصيغ، لا تعتمد على نتيجة مخزنة قديمة. استدعِ [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) قبل قراءة القيم المحسوبة أو حفظ بيانات المخطط التي تعتمد عليها.

بالنسبة للصيغ خارج المجموعة المدعومة، قد لا يتمكن Aspose.Slides من تحليل الصيغة أو تحديد تبعياتها. إذا تم تعديل دفتر العمل، لا يمكن الاعتماد على القيمة المخزنة السابقة. في تلك الحالة، قد يؤدي قراءة قيمة خلية بصيغة غير مدعومة إلى رفع الاستثناء [CellUnsupportedDataException](https://reference.aspose.com/slides/ar/java/com.aspose.slides/cellunsupporteddataexception/).

إذا كان مخططك يعتمد على دالات Excel لا يحسبها Aspose.Slides، احسب تلك الصيغ باستخدام محرك جدول بيانات يدعمها واكتب القيم الناتجة مرة أخرى إلى دفتر عمل المخطط. لا تستبدل الصيغ غير المدعومة بقيم تخمينية.

## **معالجة أخطاء الصيغة**

هناك نوعان مختلفان من المشكلات يجب التمييز بينهما.

يمكن أن تكون الصيغة صالحة لكن تُنتج نتيجة خطأ جدول بيانات مثل `#DIV/0!`، `#N/A`، `#NAME?`، `#NULL!`، `#NUM!`، `#REF!` أو `#VALUE!`. في هذه الحالة، يعتبر رمز الخطأ نتيجة خلية ويمكن إرجاعه عبر [IChartDataCell.getValue](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdatacell/#getValue--).

يمكن أن تفشل الصيغة أيضًا أثناء التحليل، أو الإشارة، أو التبعية، أو على مستوى البيانات المدعومة. توفر Aspose.Slides استثناءات خاصة بجداول البيانات لهذه الحالات: [CellInvalidFormulaException](https://reference.aspose.com/slides/ar/java/com.aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/ar/java/com.aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/ar/java/com.aspose.slides/cellcircularreferenceexception/), و[CellUnsupportedDataException](https://reference.aspose.com/slides/ar/java/com.aspose.slides/cellunsupporteddataexception/).

عند استخراج الصيغ من القوالب أو مدخلات المستخدم، تعامل مع هذه الاستثناءات حول إعادة الحساب والوصول إلى القيم:

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

دعم الصيغ في أوراق عمل المخططات مخصص لمجموعة محددة من حسابات جداول البيانات، وليس لتوافق كامل مع Excel. ضع هذه القيود في الاعتبار عند تصميم سير عمل التقارير:

- استخدم فقط الثوابت، العوامل، المراجع، والدالات الموثقة عندما تحتاج إلى أن يعيد Aspose.Slides حساب الصيغ.
- أعد الحساب بعد تعديل الخلايا التي تعتمد عليها نتائج الصيغ.
- اعتبر القيم المخزنة مؤقتًا من العروض المحملة لقطات ثابتة، لا بديل لإعادة الحساب بعد التعديلات.
- اختبر الصيغ من القوالب الحالية قبل الاعتماد على قيمها المحسوبة، خاصةً إذا استخدمت دالات خارج القائمة الموثقة.
- بالنسبة للصيغ التي تتطلب محرك حساب جداول بيانات كامل، احسبها خارجيًا ثم حدّث دفتر عمل المخطط بالقيم الناتجة.

## **الأسئلة الشائعة**

**ما الفرق بين [IChartDataCell.setFormula](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) و[IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-)?**

[IChartDataCell.setFormula](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) يخزن تعبيرًا بنمط A1 مثل `B2-C2`. [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) يخزن تعبيرًا بنمط R1C1 مثل `RC[-2]-RC[-1]`. استخدم الترميز الذي يتوافق مع طريقة توليد أو نسخ الصيغ لديك.

**هل أحتاج إلى قراءة الخلية نفسها أم قيمتها بعد الحساب؟**

[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdataworkbook/#getCell-int-java.lang.String-) يُرجع كائنًا من نوع [IChartDataCell](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdatacell/). للحصول على النتيجة المحسوبة، استدعِ طريقة [IChartDataCell.getValue](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdatacell/#getValue--) للخلية بعد إعادة الحساب.

**متى يجب استدعاء [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--)?**

استدعِ [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) بعد تعديل قيم الإدخال أو الصيغ وقبل الاعتماد على النتائج المحسوبة. هذا يُحدّث قيم الصيغ التي يدعمها المُقَيِّم المدمج.

**هل يدعم Aspose.Slides كل دالة Excel؟**

لا. يدعم المُقَيِّم المدمج مجموعة موثقة من الدالات. لا يجب افتراض أن الدالات خارج هذه المجموعة ستحسب بشكل صحيح. إذا كانت تحتاج إلى توافق كامل مع صيغ Excel، قم بإجراء الحساب باستخدام محرك جداول بيانات مناسب واكتب القيم النهائية إلى دفتر عمل المخطط.

**ماذا يحدث إذا كان العرض التقديمي المحمل يحتوي على صيغة غير مدعومة؟**

إذا لم تتغير بيانات المخطط، قد يبقى دفتر العمل يحتوي على قيمة مخزنة مسبقًا. بعد تعديل البيانات المرتبطة، قد لا تكون تلك القيمة المخزنة صالحة. الوصول إلى خلية لا يمكن معالجة صيغتها قد يرفع الاستثناء [CellUnsupportedDataException](https://reference.aspose.com/slides/ar/java/com.aspose.slides/cellunsupporteddataexception/).

**هل قيم أخطاء الصيغة هي نفسها استثناءات Java؟**

لا. النتيجة مثل `#DIV/0!` هي قيمة جدول بيانات ناتجة عن حساب صالح. الاستثناءات مثل [CellInvalidFormulaException](https://reference.aspose.com/slides/ar/java/com.aspose.slides/cellinvalidformulaexception/) أو [CellCircularReferenceException](https://reference.aspose.com/slides/ar/java/com.aspose.slides/cellcircularreferenceexception/) تشير إلى أن الصيغة لا يمكن معالجتها بصورة طبيعية.

**هل يحدث تحديث تلقائي للمخطط عندما تتغير خلية الصيغة؟**

يمكن لسلسلة مخطط الإشارة إلى خلايا دفتر العمل. أعد حساب دفتر العمل أولاً، ثم احفظ أو عرض العرض التقديمي. إذا أشارت نقاط بيانات المخطط إلى الخلايا المحسوبة، يستخدم المخطط تلك القيم المحدثة؛ لا توجد طريقة منفصلة لتحديث المخطط مطلوبة في هذا التدفق.

**هل يمكن للمخططات استخدام دفتر عمل Excel خارجي؟**

نعم، يمكن تهيئة بيانات المخطط لاستخدام دفتر عمل خارجي عبر API بيانات المخطط. ومع ذلك، فإن سير عمل حساب الصيغ الموضح في هذه المقالة يختص بدفتر عمل بيانات المخطط ومجموعة الصيغ التي يقيّمها Aspose.Slides. لا تفترض أن [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) يوفر إعادة حساب كاملة لصيغ عشوائية في ملف XLSX خارجي.

**هل يمكنني استخدام صيغ تشير إلى ورقة عمل أو دفتر عمل آخر؟**

قد توجد مراجع بنمط Excel في دفاتر عمل المخططات، لكن تقييم الصيغ محدود بالمحلل المدعوم ومجموعة الدالات. إذا كان الإشارة إلى ورقة أخرى أو ملف خارجي ضروريًا، تحقق من صحة الصيغة الدقيقة مع الإصدار المستهدف من Aspose.Slides. بالنسبة لسير عمل يحتاج إلى توافق واسع مع مراجع Excel، احسب دفتر العمل خارجيًا واكتب القيم المحلولة مرة أخرى إلى بيانات المخطط.

**هل يجب أن تبدأ سلاسل الصيغ بـ `=`؟**

تُظهر أمثلة API في Aspose.Slides إسناد تعبيرات مثل `B2-C2` أو `SUM(B2:B5)` دون `=` تمهيدي. استخدام هذا الشكل يبقي الصيغ المولدة متسقة مع أمثلة API الموثقة.