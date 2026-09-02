---
title: تطبيق صيغ ورقة عمل المخطط في العروض التقديمية بلغة PHP
linktitle: صيغ ورقة العمل
type: docs
weight: 70
url: /ar/php-java/chart-worksheet-formulas/
keywords:
- مخطط جدول البيانات
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
- دالة مسبقة التعريف
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تطبيق صيغ مشابهة لإكسيل في Aspose.Slides للـ PHP عبر جداول عمل المخطط، إعادة حساب القيم، واستخدام النتائج في مخططات PowerPoint."
---
## **نظرة عامة**

عادةً ما تخزن المخططات في PowerPoint بيانات المصدر الخاصة بها في ورقة عمل مضمّنة. في Aspose.Slides للـ PHP عبر Java، يمكنك الوصول إلى تلك الورقة من خلال دفتر عمل بيانات المخطط، كتابة قيم الإدخال، تعيين صيغ للخلايا، حساب الصيغ المدعومة، واستخدام الخلايا المحسوبة كبيانات للمخطط.

تشرح هذه المقالة سير عمل الصيغ بالكامل: إنشاء مخطط، ملء ورقة عمله، تعيين صيغ بنمط A1 أو R1C1، إعادة حسابها، قراءة القيم المحسوبة، ربط تلك الخلايا بسلسلة مخطط، وحفظ العرض التقديمي. كما تصف بنية الصيغ المدعومة، مجموعة الدوال المدمجة، القيم المخزّنة مؤقتًا، الصيغ غير المدعومة، وأخطاء الجداول الخاصة.

## **أوراق عمل المخططات والصيغ**

تحتوي ورقة عمل المخطط على الفئات، أسماء السلاسل، والقيم المستخدمة من قبل المخطط. في PowerPoint، يمكنك فحص ورقة العمل بفتح محرر بيانات المخطط:

![مخطط PowerPoint مع ورقة عمله المضمّنة مفتوحة، تُظهر بيانات الفئات والسلاسل](chart-worksheet-formulas_1.png)

في Aspose.Slides، يتم عرض ورقة العمل عبر فئة [ChartDataWorkbook](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdataworkbook/). استخدم [ChartDataCell::setFormula](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdatacell/#setFormula) للصيغ بنمط A1 و[ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdatacell/#setR1C1Formula) للصيغ بنمط R1C1. بعد تعديل خلايا الإدخال أو الصيغ، استدعِ [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) لإعادة حساب الصيغ المدعومة وتحديث قيم الخلايا المقابلة.

لا تزال الخلية المحسوبة تعرض نتيجتها عبر [ChartDataCell::getValue](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdatacell/#getValue). وهذا مهم عندما تحتاج إلى فحص نتيجة الصيغة في الشيفرة أو استخدام الخلية كنقطة بيانات للمخطط.

## **إنشاء مخطط وحساب صيغ ورقة العمل**

يوضح المثال التالي سير عمل شامل من البداية إلى النهاية. فهو ينشئ مخطط أعمدة متجمع، يمسح البيانات التجريبية، يكتب قيم الإيرادات والنفقات ربع السنوية، يحسب الربح باستخدام صيغ، يقرأ النتائج، يستخدم الخلايا المحسوبة كقيم للمخطط، ويحفظ العرض التقديمي.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 350);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $workbook->clear($worksheetIndex);

    $category1 = $workbook->getCell($worksheetIndex, "A2", "Q1");
    $category2 = $workbook->getCell($worksheetIndex, "A3", "Q2");
    $category3 = $workbook->getCell($worksheetIndex, "A4", "Q3");

    $workbook->getCell($worksheetIndex, "B1", "Revenue");
    $workbook->getCell($worksheetIndex, "C1", "Expenses");
    $workbook->getCell($worksheetIndex, "D1", "Profit");

    $workbook->getCell($worksheetIndex, "B2")->setValue(120.0);
    $workbook->getCell($worksheetIndex, "C2")->setValue(80.0);
    $workbook->getCell($worksheetIndex, "B3")->setValue(150.0);
    $workbook->getCell($worksheetIndex, "C3")->setValue(95.0);
    $workbook->getCell($worksheetIndex, "B4")->setValue(135.0);
    $workbook->getCell($worksheetIndex, "C4")->setValue(110.0);

    $profit1 = $workbook->getCell($worksheetIndex, "D2");
    $profit2 = $workbook->getCell($worksheetIndex, "D3");
    $profit3 = $workbook->getCell($worksheetIndex, "D4");

    $profit1->setFormula("B2-C2");
    $profit2->setFormula("B3-C3");
    $profit3->setFormula("B4-C4");

    $workbook->calculateFormulas();

    $q1Profit = java_values($profit1->getValue()); // 40
    $q2Profit = java_values($profit2->getValue()); // 55
    $q3Profit = java_values($profit3->getValue()); // 25

    echo "Q1 profit: " . $q1Profit . PHP_EOL;
    echo "Q2 profit: " . $q2Profit . PHP_EOL;
    echo "Q3 profit: " . $q3Profit . PHP_EOL;

    $chart->getChartData()->getCategories()->add($category1);
    $chart->getChartData()->getCategories()->add($category2);
    $chart->getChartData()->getCategories()->add($category3);

    $profitSeries = $chart->getChartData()->getSeries()->add($workbook->getCell($worksheetIndex, "D1"), $chart->getType());
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit1);
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit2);
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit3);
    $profitSeries->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);

    $presentation->save("chart-formulas.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

تشير نقاط بيانات المخطط إلى `D2:D4`، لذا يستخدم المخطط قيم الربح المحسوبة. لا توجد دعوة منفصلة لتحديث المخطط في هذا سير العمل: أعد حساب دفتر العمل أولاً، ثم استخدم أو احفظ بيانات المخطط التي تشير إلى الخلايا المحسوبة.

## **استخدام صيغ بنمط A1**

يحدد ترميز A1 الأعمدة بالأحرف والصفوف بالأرقام. عيّن التعبيرات بنمط A1 عبر [ChartDataCell::setFormula](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdatacell/#setFormula).

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "C3")->setValue(10);
    $workbook->getCell(0, "F2")->setValue(2);
    $workbook->getCell(0, "G2")->setValue(3);
    $workbook->getCell(0, "H2")->setValue(4);

    $cell = $workbook->getCell(0, "A2");
    $cell->setFormula("C3+SUM(F2:H2)");

    $workbook->calculateFormulas();

    $value = java_values($cell->getValue()); // 19
} finally {
    $presentation->dispose();
}
```

الأشكال الشائعة للمرجع بنمط A1 هي:

| المرجع | نسبي | مطلق | مختلط |
|---|---|---|---|
| خلية | `A2` | `$A$2` | `A$2`, `$A2` |
| صف | `2:2` | `$2:$2` | — |
| عمود | `A:A` | `$A:$A` | — |
| نطاق | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

يمكن أن تتغير المراجع النسبية عندما يتم نقل الصيغة أو نسخها باستخدام تطبيق جدول البيانات. المراجع المطلقة تحافظ على كلا الإحداثيين ثابتين، بينما المراجع المختلطة تثبت إما الصف أو العمود فقط.

## **استخدام صيغ بنمط R1C1**

يحدد ترميز R1C1 كلًا من الصفوف والأعمدة رقميًا. تستخدم المراجع النسبية إزاحات بين قوسين مربعين. عيّن هذا الترميز عبر [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdatacell/#setR1C1Formula).

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "B2")->setValue(12);
    $workbook->getCell(0, "C2")->setValue(5);

    $cell = $workbook->getCell(0, "D2");
    $cell->setR1C1Formula("RC[-2]-RC[-1]");

    $workbook->calculateFormulas();

    $value = java_values($cell->getValue()); // 7
} finally {
    $presentation->dispose();
}
```

الأشكال الشائعة للمرجع بنمط R1C1 هي:

| المرجع | نسبي | مطلق | مختلط |
|---|---|---|---|
| خلية | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| صف | `R[2]` | `R2` | — |
| عمود | `C[3]` | `C3` | — |
| نطاق | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

على سبيل المثال، في الخلية `D2`، تعني `RC[-2]` الخلية في نفس الصف عمودين إلى اليسار (`B2`).

## **ثوابت الصيغة والعوامل**

يدعم مقيم الصيغ المدمج القيم المنطقية، القيم الرقمية، السلاسل النصية، قيم أخطاء الجداول، العوامل الحسابية، وعوامل المقارنة.

### **الثوابت والعدديات**

| النوع | أمثلة | ملاحظات |
|---|---|---|
| منطقي | `TRUE`, `FALSE` | يمكن استخدامها مباشرة في تعبيرات منطقية مثل `A2=TRUE`. |
| رقمي | `1`, `0.5`, `.3`, `1E-2` | تُدعم الصيغ العشرية والعلمية. |
| نصي | `"abc"`, `"2/3/2020 12:00"` | تُحاط القيم النصية بعلامات اقتباس مزدوجة داخل الصيغة. |
| نتيجة خطأ | `#DIV/0!`, `#N/A`, `#REF!` | يمكن أن تُقيّم صيغة صحيحة إلى قيمة خطأ جدولية بدلاً من نتيجة عادية. |

هذا المثال يستخدم عدة أنواع ثابتة:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "A2")->setValue(false);
    $workbook->getCell(0, "B2")->setFormula("A2=TRUE");
    $workbook->getCell(0, "C2")->setFormula("1+0.5");
    $workbook->getCell(0, "D2")->setFormula(".3*1E-2");
    $workbook->getCell(0, "E2")->setFormula("\"abc\"");
    $workbook->getCell(0, "F2")->setFormula("2/0");

    $workbook->calculateFormulas();

    $logicalValue = java_values($workbook->getCell(0, "B2")->getValue()); // خاطئ
    $numericValue = java_values($workbook->getCell(0, "C2")->getValue()); // 1.5
    $scientificValue = java_values($workbook->getCell(0, "D2")->getValue()); // 0.003
    $stringValue = java_values($workbook->getCell(0, "E2")->getValue()); // abc
    $errorValue = java_values($workbook->getCell(0, "F2")->getValue()); // #DIV/0!
} finally {
    $presentation->dispose();
}
```

### **العوامل الحسابية**

| العامل | المعنى | مثال |
|---|---|---|
| `+` | جمع أو إشارة موجبة أحادية | `2+3` |
| `-` | طرح أو نفي أحادي | `2-3`, `-3` |
| `*` | ضرب | `2*3` |
| `/` | قسمة | `2/3` |
| `%` | نسبة مئوية | `30%` |
| `^` | أس | `2^3` |

استخدم الأقواس لجعل ترتيب التقييم واضحًا، على سبيل المثال `(A2+B2)*C2`.

### **عوامل المقارنة**

تعيد تعبيرات المقارنة قيمًا منطقية.

| العامل | المعنى | مثال |
|---|---|---|
| `=` | مساوية لـ | `A2=3` |
| `<>` | غير مساوية لـ | `A2<>3` |
| `>` | أكبر من | `A2>3` |
| `>=` | أكبر من أو يساوي | `A2>=3` |
| `<` | أصغر من | `A2<3` |
| `<=` | أصغر من أو يساوي | `A2<=3` |

## **الدوال المسبقة التعريف المدعومة**

يتضمن Aspose.Slides مقيم صيغ مدمج لأوراق عمل المخططات، لكنه ليس محرك حساب Excel كامل. مجموعة الدوال الموثقة محدودة إلى الدوال أدناه. لا تفترض أن أي دالة Excel عشوائية يمكن إعادة حسابها عبر [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdataworkbook/#calculateFormulas).

| الدالة | الغرض أو الشكل المدعوم | مثال |
|---|---|---|
| `ABS` | القيمة المطلقة | `ABS(A2)` |
| `AVERAGE` | المتوسط الحسابي | `AVERAGE(B2:B5)` |
| `CEILING` | تقريب الرقم إلى الأعلى إلى مضاعف | `CEILING(A2,5)` |
| `CHOOSE` | اختيار قيمة بحسب الفهرس | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | دمج قيم نصية | `CONCAT(A2,B2)` |
| `CONCATENATE` | دمج قيم نصية | `CONCATENATE(A2," ",B2)` |
| `DATE` | إنشاء قيمة تاريخ باستخدام نظام تاريخ 1900 | `DATE(2026,8,19)` |
| `DAYS` | إرجاع عدد الأيام بين تاريخين | `DAYS(B2,A2)` |
| `FIND` | العثور على نص داخل نص آخر | `FIND("-",A2)` |
| `FINDB` | بحث نصي قائم على البايت | `FINDB("a",A2)` |
| `IF` | نتيجة شرطية | `IF(A2>0,A2,0)` |
| `INDEX` | شكل مرجع | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | شكل متجه | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | شكل متجه | `MATCH(A2,B2:B5,0)` |
| `MAX` | القيمة العظمى | `MAX(B2:B5)` |
| `SUM` | جمع القيم | `SUM(B2:B5)` |
| `VLOOKUP` | بحث عمودي | `VLOOKUP(A2,B2:D10,3,FALSE)` |

القيود الموضحة في الجدول ذات أهمية: يتم توثيق `INDEX` في شكل مرجع، بينما يتم توثيق `LOOKUP` و `MATCH` في شكل متجه. يستخدم `DATE` نظام تاريخ 1900. يجب اعتبار أي ميزات أو دوال غير مدرجة هنا غير مدعومة من قِبل مقيم صيغ Aspose.Slides إلا إذا تم توثيقها بشكل منفصل.

## **حساب الصيغ باستخدام ثقافة مفضلة**

تفسّر بعض دوال دفتر عمل المخطط النص وفق قواعد خاصة بالثقافة. هذا مهم بشكل خاص للدوال المصممة للغات تستخدم مجموعات أحرف مزدوجة البايت (DBCS). لحساب هذه الصيغ بشكل صحيح، أنشئ [LoadOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/loadoptions/)، عيّن الثقافة المفضلة عبر [SpreadsheetOptions::setPreferredCulture](https://reference.aspose.com/slides/ar/php-java/aspose.slides/spreadsheetoptions/#setPreferredCulture)، عيّن خيارات جدول البيانات عبر [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/loadoptions/#setSpreadsheetOptions)، ثم حمّل العرض التقديمي.

يختار المثال التالي الثقافة اليابانية، يفتح عرضًا تقديميًا باستخدام خيارات التحميل المكوّنة، ويستدعي [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) لكل دفتر عمل مخطط:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SpreadsheetOptions;

$japaneseCulture = new Java("java.util.Locale", "ja", "JP");

$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setPreferredCulture($japaneseCulture);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$chartClass = new JavaClass("com.aspose.slides.IChart");
$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, $chartClass)) {
                $shape->getChartData()->getChartDataWorkbook()->calculateFormulas();
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

تُعد الثقافة المفضلة جزءًا من تكوين تحميل العرض التقديمي، لذا حددها قبل إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/). استخدم الثقافة المتوافقة مع صيغ دفتر العمل؛ على سبيل المثال، استخدم `ja-JP` للصيغ التي يجب أن تتبع قواعد حساب DBCS اليابانية.

## **إعادة الحساب والقيم المخزنة مؤقتًا**

تخزن ملفات الجداول عادةً كلًا من الصيغة وقيمتها المحسوبة الأخيرة. يمكن لـ Aspose.Slides قراءة قيمة مخزنة مؤقتًا من [ChartDataCell::getValue](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdatacell/#getValue) عندما يتم تحميل العرض التقديمي ولم تتغير بيانات المخطط ذات الصلة.

بعد تعديل خلايا الإدخال أو الصيغ، لا تعتمد على نتيجة مخزنة قديمة. استدعِ [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) قبل قراءة القيم المحسوبة أو حفظ بيانات المخطط التي تعتمد عليها.

بالنسبة للصيغ خارج المجموعة المدعومة، قد لا يتمكن Aspose.Slides من تحليل الصيغة أو تحديد تبعياتها. إذا تم تعديل دفتر العمل، لا يمكن الاعتماد على القيمة المخزنة السابقة. في هذه الحالة، قد يؤدي قراءة قيمة خلية ذات بيانات غير مدعومة إلى رفع استثناء [CellUnsupportedDataException](https://reference.aspose.com/slides/ar/php-java/aspose.slides/cellunsupporteddataexception/).

إذا كان مخططك يعتمد على دوال Excel لا يقوم Aspose.Slides بتقييمها، احسب تلك الصيغ باستخدام محرك جدول بيانات يدعمها واكتب القيم الناتجة مرة أخرى إلى دفتر عمل المخطط. لا تستبدل الصيغ غير المدعومة بقيم مقدرة.

## **معالجة أخطاء الصيغ**

هناك نوعان مختلفان من المشكلات للتمييز بينهما.

* يمكن أن تكون الصيغة صالحة لكنها تُنتج نتيجة خطأ جدولية مثل `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, أو `#VALUE!`. في هذه الحالة، يكون رمز الخطأ نتيجة للخلية ويمكن إرجاعه عبر [ChartDataCell::getValue](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdatacell/#getValue).

* يمكن أن تفشل الصيغة أثناء التحليل أو الإشارة أو التبعيات أو مستوى البيانات المدعومة. يوفر Aspose.Slides استثناءات خاصة بالجداول لهذه الحالات: [CellInvalidFormulaException](https://reference.aspose.com/slides/ar/php-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/ar/php-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/ar/php-java/aspose.slides/cellcircularreferenceexception/), و[CellUnsupportedDataException](https://reference.aspose.com/slides/ar/php-java/aspose.slides/cellunsupporteddataexception/).

في PHP عبر Java، تُظهر استثناءات Java من خلال `JavaException`. عندما تأتي الصيغ من قوالب أو إدخال المستخدم، عالجها حول إعادة الحساب والوصول إلى القيمة. يُحدِّد الاستثناء Java المُبلغ عنه في تتبع المكدس الفشل الجدولي المحدد:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $cell = $workbook->getCell(0, "A2");
    $cell->setFormula("SUM(B2:B5)");

    try {
        $workbook->calculateFormulas();
        echo java_values($cell->getValue()) . PHP_EOL;
    } catch (JavaException $ex) {
        $ex->printStackTrace();
    }
} finally {
    $presentation->dispose();
}
```

## **القيود العملية**

دعم الصيغ في أوراق عمل المخططات مخصص لمجموعة محددة من حسابات الجداول، وليس لتوافق Excel الكامل. احتفظ بهذه القيود في الاعتبار عند تصميم سير عمل تقارير:

- استخدم فقط الثوابت، العوامل، المراجع، والدوال الموثقة عندما تحتاج إلى أن يعيد Aspose.Slides حساب الصيغ.
- أعد الحساب بعد تعديل الخلايا التي تعتمد عليها ناتج الصيغة.
- اعتبر القيم المخزنة مؤقتًا من العروض التقديمية المحمّلة لقطات، ولا تعتمد عليها كبديل لإعادة الحساب بعد التعديلات.
- اختبر الصيغ من القوالب الحالية قبل الاعتماد على قيمها المحسوبة، خاصةً إذا استخدمت دوالًا خارج القائمة الموثقة.
- بالنسبة للصيغ التي تحتاج إلى محرك حساب جداول كامل، احسبها خارجيًا ثم حدّث دفتر عمل المخطط بالقيم الناتجة.

## **الأسئلة المتكررة**

**ما الفرق بين [ChartDataCell::setFormula](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdatacell/#setFormula) و[ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdatacell/#setR1C1Formula)؟**

[ChartDataCell::setFormula](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdatacell/#setFormula) يخزن تعبيرًا بنمط A1 مثل `B2-C2`. [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdatacell/#setR1C1Formula) يخزن تعبيرًا بنمط R1C1 مثل `RC[-2]-RC[-1]`. استخدم الترميز الذي يتطابق أفضل مع طريقة توليدك أو نسخك للصيغ.

**هل يجب قراءة الخلية نفسها أم قيمتها بعد الحساب؟**

[ChartDataWorkbook::getCell](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdataworkbook/#getCell) يُرجع كائنًا من نوع [ChartDataCell](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdatacell/). للحصول على النتيجة المحسوبة، استدعِ طريقة [ChartDataCell::getValue](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdatacell/#getValue) لتلك الخلية بعد إعادة الحساب.

**متى يجب استدعاء [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdataworkbook/#calculateFormulas)؟**

استدعِ [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) بعد تعديل قيم الإدخال أو الصيغ وقبل الاعتماد على النتائج المحسوبة. هذا يُحدّث قيم الصيغ التي يدعمها المقيم المدمج.

**هل يدعم Aspose.Slides جميع دوال Excel؟**

لا. يدعم المقيم المدمج مجموعة محدودة موثقة من الدوال. لا يُفترض أن تُعاد حساب الدوال خارج هذه المجموعة بشكل صحيح. إذا كان مطلوبًا توافق كامل مع صيغ Excel، أجرِ الحساب باستخدام محرك جدول بيانات مناسب واكتب القيم النهائية إلى دفتر عمل المخطط.

**ماذا يحدث إذا احتوى عرض تقديمي محمّل على صيغة غير مدعومة؟**

إذا لم تتغير بيانات المخطط، قد يظل دفتر العمل يحتوي على قيمة مخزنة مسبقًا. بعد تعديل البيانات ذات الصلة، قد لا تكون تلك القيمة المخزنة صالحة. محاولة الوصول إلى خلية لا يمكن التعامل مع صيغتها قد تُثير استثناء [CellUnsupportedDataException](https://reference.aspose.com/slides/ar/php-java/aspose.slides/cellunsupporteddataexception/).

**هل قيم أخطاء الصيغ هي نفسها استثناءات PHP؟**

لا. النتيجة مثل `#DIV/0!` هي قيمة جدولية ناتجة عن حساب صالح. أما فشل معالجة الجداول مثل [CellInvalidFormulaException](https://reference.aspose.com/slides/ar/php-java/aspose.slides/cellinvalidformulaexception/) أو [CellCircularReferenceException](https://reference.aspose.com/slides/ar/php-java/aspose.slides/cellcircularreferenceexception/) فهي استثناءات Java تُظهر إلى PHP عبر `JavaException`.

**هل يُحدّث المخطط تلقائيًا عندما تتغير خلية الصيغة؟**

يمكن لسلسلة المخطط الإشارة إلى خلايا دفتر العمل. أعد حساب دفتر العمل أولاً، ثم احفظ أو عرِض العرض التقديمي. إذا أشارت نقاط بيانات المخطط إلى الخلايا المحسوبة، سيستخدم المخطط تلك القيم المحدثة؛ لا يلزم وجود طريقة تحديث منفصلة للمخطط في هذا سير العمل.

**هل يمكن للمخططات استخدام دفتر عمل Excel خارجي؟**

نعم، يمكن تكوين بيانات المخطط لاستخدام دفتر عمل خارجي عبر واجهة برمجة بيانات المخطط. ومع ذلك، فإن سير عمل حساب الصيغ الموصوف في هذه المقالة يتعلق بدفتر عمل بيانات المخطط ومجموعة الصيغ التي يقيمها Aspose.Slides. لا تفترض أن [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) يُعيد حساب جميع الصيغ في ملف XLSX خارجي بشكل كامل.

**هل يمكنني استخدام صيغ تُشير إلى ورقة عمل أو دفتر عمل آخر؟**

قد توجد مراجع بنمط Excel في دفاتر عمل المخططات، لكن تقييم الصيغ يقتصر على المحلل ومجموعة الدوال المدعومة. إذا كان المرجع عبر ورقة أو دفتر عمل أمرًا أساسيًا، تحقق من صحة الصيغة مع إصدار Aspose.Slides المستهدف. بالنسبة لسير العمل الذي يتطلب توافقًا واسعًا مع مراجع Excel، احسب دفتر العمل خارجيًا واكتب القيم المحلولة مرة أخرى إلى بيانات المخطط.

**هل يجب أن تبدأ سلاسل الصيغ بـ `=`؟**

تُعيّن أمثلة API في Aspose.Slides التعبيرات مثل `B2-C2` أو `SUM(B2:B5)` بدون `=` أوليًا. استخدام هذا الشكل يبقي الصيغ المولدة متوافقة مع أمثلة API الموثقة.