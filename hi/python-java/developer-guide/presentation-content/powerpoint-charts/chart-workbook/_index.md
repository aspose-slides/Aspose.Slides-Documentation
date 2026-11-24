---
title: Python via Java का उपयोग करके प्रस्तुतियों में चार्ट वर्कबुक का प्रबंधन
linktitle: चार्ट वर्कबुक
type: docs
weight: 70
url: /hi/python-java/chart-workbook/
keywords:
- चार्ट वर्कबुक
- चार्ट डेटा
- वर्कबुक सेल
- डेटा लेबल
- वर्कशीट
- डेटा स्रोत
- बाहरी वर्कबुक
- बाहरी डेटा
- चार्ट कैश
- वर्कबुक पुनर्प्राप्ति
- PowerPoint
- प्रेजेंटेशन
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java की खोज करें: PowerPoint और OpenDocument फॉर्मेट में चार्ट वर्कबुक को आसानी से प्रबंधित करें ताकि आपके प्रेजेंटेशन डेटा को सुव्यवस्थित किया जा सके।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट वर्कबुक के साथ काम करने के तरीके को समझाता है। यह वर्कबुक स्ट्रीम के माध्यम से चार्ट डेटा को पढ़ने और लिखने, वर्कबुक कोशिकाओं को चार्ट डेटा लेबल के रूप में उपयोग करने, वर्कशीट संग्रहों तक पहुंचने, और चार्ट मूल्यों के लिए डेटा स्रोत प्रकार निर्धारित करने को दर्शाता है।

यह बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में उपयोग करने को भी कवर करता है। उदाहरण दिखाते हैं कि कैसे बाहरी वर्कबुक बनाया और सौंपा जाए, चार्ट से लिंक्ड बाहरी वर्कबुक का पथ प्राप्त किया जाए, और वर्कबुक उपलब्ध होने पर चार्ट डेटा संपादित किया जाए।

गुम डेटा वाले वर्कबुक कोशिकाओं के लिए, अंतर के लिए देखें [Control the Display of Empty Cells](/slides/hi/python-java/chart-series/) जिसमें खाली कोशिका और शून्य के बीच अंतर और उपलब्ध डिस्प्ले मोड की लाइन-चार्ट तुलना शामिल है।

## **छिपी पंक्तियों और स्तंभों से डेटा शामिल करें**

[Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setPlotVisibleCellsOnly) का उपयोग करके यह नियंत्रित किया जाता है कि क्या चार्ट छिपी वर्कशीट पंक्तियों और स्तंभों से डेटा प्लॉट करता है। केवल दृश्यमान कोशिकाओं को प्लॉट करने के लिए इसे `True` रखें, या दृश्यमान और छिपी दोनों कोशिकाओं को शामिल करने के लिए `False` रखें। यह सेटिंग चार्ट प्लॉटिंग को नियंत्रित करती है; यह वर्कशीट पंक्तियों या स्तंभों को छिपाती या प्रदर्शित नहीं करती।

[सैंपल प्रेजेंटेशन](hidden-source-data.pptx) में पहली स्लाइड की पहली आकृति के रूप में एक कॉलम चार्ट है। एंबेडेड वर्कशीट, `Sheet1`, में निम्न स्रोत रेंज, `A1:C4` है। पंक्ति 3 और स्तंभ C छिपे हुए हैं, लेकिन उनकी कोशिकाओं में अभी भी मान हैं।

| कार्यपत्र पंक्ति | A: माह | B: खुदरा | C: थोक (छिपा स्तंभ) |
| --- | --- | --- | --- |
| 2 | जनवरी | 10 | 30 |
| 3 (छिपी पंक्ति) | फ़रवरी | 40 | 60 |
| 4 | मार्च | 20 | 50 |

[ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) के माध्यम से स्रोत कोशिकाओं तक पहुंचें और [ChartDataCell.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#isHidden) को पढ़कर उनकी छिपी स्थिति जांचें। यह विधि स्थिति को बदले बिना रिपोर्ट करती है। इस फ़ाइल में, B2 दृश्यमान है, B3 छिपी पंक्ति में है, और C2 छिपे स्तंभ में है; उदाहरण क्रमशः `False`, `True`, और `True` प्रिंट करता है।

इस उदाहरण के लिए, प्लॉटिंग सेटिंग बदलने के बाद चार्ट डेटा रीफ़्रेश करें: एंबेडेड वर्कबुक को [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) से रखें और उसे [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream) से पुनः लोड करें। सभी कोशिकाओं को शामिल करने के लिए, छिपी फ़रवरी श्रेणी को भी शामिल करने हेतु [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) का उपयोग करें। केवल फ़्लैग बदलना इस नमूने के कैश्ड चार्ट डेटा और श्रेणी लेबल को रीफ़्रेश करने के लिए पर्याप्त नहीं है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("hidden-source-data.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        workbook = chart.getChartData().getChartDataWorkbook()
        print("B2 hidden:", workbook.getCell(0, "B2").isHidden())
        print("B3 hidden:", workbook.getCell(0, "B3").isHidden())
        print("C2 hidden:", workbook.getCell(0, "C2").isHidden())

        workbook_data = chart.getChartData().readWorkbookStream()
        for visible_only in (True, False):
            chart.setPlotVisibleCellsOnly(visible_only)

            # एंबेडेड वर्कबुक से चार्ट डेटा को रीफ़्रेश करें।
            chart.getChartData().writeWorkbookStream(workbook_data)
            if not visible_only:
                # छिपी श्रेणियों सहित पूर्ण स्रोत रेंज को पुनर्स्थापित करें।
                chart.getChartData().setRange("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

उदाहरण दो संस्करणों में प्रेजेंटेशन को सहेजता है: एक केवल दृश्यमान खुदरा मानों (10 और 20) के साथ, और दूसरा सभी छह मानों के साथ। नीचे की छवियां दो प्लॉटिंग मोड को दर्शाती हैं। पंक्ति 3 और स्तंभ C दोनों एंबेडेड वर्कबुक में छिपे रहते हैं।

| केवल दृश्यमान कोशिकाएं (`True`) | सभी कोशिकाएं (`False`) |
| --- | --- |
| ![केवल दृश्यमान कोशिकाएं: जनवरी और मार्च के लिए खुदरा मान 10 और 20।](hidden_cells_True.png) | ![सभी कोशिकाएं: जनवरी, फ़रवरी और मार्च के लिए खुदरा और थोक मान।](hidden_cells_False.png) |

एक मान वाला छिपा सेल खाली सेल से अलग होता है। [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) नियंत्रित करता है कि गुम मान कैसे दिखाए जाएँ; यह छिपे स्रोत डेटा को शामिल या बाहर नहीं करता। उदाहरण के लिए देखें [Control the Display of Empty Cells](/slides/hi/python-java/chart-series/#control-the-display-of-empty-cells)।

## **चार्ट के डेटा रेंज को प्राप्त करें**

मौजूदा प्रेजेंटेशन में वर्कबुक डेटा को अपडेट करने से पहले, स्रोत रेंजों की जाँच करें ताकि यह पहचाना जा सके कि प्रत्येक चार्ट कौन सी वर्कशीट कोशिकाओं का उपयोग करता है। [ChartData.getRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getRange) विधि वर्तमान डेटा रेंज को वर्कशीट-योग्य फ़ॉर्मूला के रूप में लौटाती है, जैसे `Sheet1!$A$1:$D$5`। यहाँ `Sheet1` वर्कशीट का नाम है, `!` इसे सेल रेंज से अलग करता है, और `$A$1:$D$5` कोशिकाएँ A1 से D5 तक (समावेशी) दर्शाता है। डॉलर चिह्न निरपेक्ष पंक्ति और स्तंभ संदर्भ दर्शाते हैं।

यह विधि चार्ट या उसकी वर्कबुक को बदले बिना वर्तमान रेंज पढ़ती है। यदि चार्ट डेटा स्रोत के रूप में वर्कबुक का उपयोग नहीं करता, तो यह `InvalidOperationException` फेंकता है। अधिक जानकारी के लिए देखें [ChartData API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/)।

यह उदाहरण एक प्रेजेंटेशन खोलता है और प्रत्येक स्लाइड पर सीधे आकृतियों को चार्ट के लिए जाँचता है। यह प्रत्येक चार्ट का नाम और स्रोत रेंज प्रिंट करता है। यदि कोई चार्ट वर्कबुक का उपयोग नहीं करता, तो यह एक संदेश प्रिंट करता है और अगले चार्ट पर जारी रखता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

InvalidOperationException = jpype.JClass("com.aspose.slides.exceptions.InvalidOperationException")

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, Chart):
                try:
                    data_range = shape.getChartData().getRange()
                    print(f"{shape.getName()}: {data_range}")
                except InvalidOperationException:
                    print(f"{shape.getName()}: The chart does not use a workbook as its data source.")
finally:
    presentation.dispose()
```

## **वर्कबुक से चार्ट डेटा पढ़ें और लिखें**

Aspose.Slides for Python via Java द्वारा प्रदान किए गए [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) और [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream) मेथड आपको चार्ट डेटा वर्कबुक (जिसमें Aspose.Cells के साथ संपादित चार्ट डेटा होता है) को पढ़ने और लिखने की अनुमति देते हैं। **नोट** कि चार्ट डेटा को उसी प्रकार व्यवस्थित किया जाना चाहिए या स्रोत के समान संरचना रखनी चाहिए।

यह उदाहरण पहली स्लाइड की पहली आकृति पर एक चार्ट वाले प्रेजेंटेशन का उपयोग करता है। यह एंबेडेड वर्कबुक को बाइट एरे में पढ़ता है, मौजूदा श्रृंखलाएँ और श्रेणियाँ साफ़ करता है, और वही वर्कबुक वापस लिखता है। परिवर्तन मेमोरी में रहते हैं; उदाहरण प्रेजेंटेशन को सहेजता नहीं है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        workbook_data = chart_data.readWorkbookStream()

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

### **वर्कबुक संशोधन के बाद चार्ट लेआउट मान्य करें**

जब आप एंबेडेड वर्कबुक को संशोधित वर्कबुक से बदलते हैं, तो चार्ट अपनी मूल श्रृंखला और श्रेणी संग्रह रखता है। यह असंगतता [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) को इंडेक्स-आउट-ऑफ़-रेंज त्रुटि के साथ असफल कर सकती है। अद्यतन वर्कबुक को चार्ट में लिखने से पहले मौजूदा श्रृंखलाएँ और श्रेणियाँ साफ़ करें। यह उदाहरण पहली स्लाइड की पहली आकृति पर स्थित एक चार्ट का उपयोग करता है। टिप्पणी दर्शाती है कि जहाँ वर्कबुक संपादन होना चाहिए; runnable उदाहरण मूल वर्कबुक को वापस लिखता है और मेमोरी में लेआउट को मान्य करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        workbook_data = chart_data.readWorkbookStream()

        # यहाँ वर्कबुक बाइट्स को संशोधित करें, उदाहरण के लिए, Aspose.Cells का उपयोग करके।

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
        chart.validateChartLayout()
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

संग्रहों को साफ़ करने से वर्कबुक लिखे जाने से पहले पुराने डेटा संदर्भ हट जाते हैं। अद्यतन वर्कबुक के लिए आवश्यक किसी भी श्रृंखला और श्रेणी मैपिंग को पुनः बनाएँ इससे पहले कि आप चार्ट का उपयोग करें।

## **श्रेणी लेबल को कैसे संग्रहित करें चुनें**

लेबल जोड़ने से पहले खाली श्रेणी संग्रह पर [ChartCategoryCollection.setUseCells](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategorycollection/#setUseCells) को कॉल करें। जब लेबल वर्कबुक डेटा को संदर्भित करते हैं या तालिका जैसे वर्षों द्वारा समूहित तिमाहियों की पदानुक्रम बनाते हैं, तो वर्कशीट कोशिकाओं का उपयोग करें। एकल स्तर के लेबल जिन्हें कोशिका संदर्भों की आवश्यकता नहीं है, उनके लिए स्ट्रिंग लिटरल का उपयोग करें। यह सेटिंग केवल श्रेणियों पर लागू होती है। नीचे दोनों चार्ट अपने संख्यात्मक श्रृंखला मानों के लिए वर्कशीट कोशिकाओं का उपयोग करते हैं।

उदाहरण दो कॉलम चार्ट बनाता है और प्रत्येक के लिए संग्रह मोड के बाद `Q1 Q2 Q3 Q4` प्रिंट करता है। वर्कशीट-समर्थित लेबल के लिए, [ChartCategory.getAsCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategory/#getAsCell) आधारभूत कोशिका लौटाता है और [ChartDataCell.getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#getValue) उसका लेबल पढ़ता है। लिटरल लेबल के लिए, [ChartCategory.getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategory/#getValue) सीधे स्ट्रिंग लौटाता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()
    
    for use_cells in (True, False):
        x = 20 if use_cells else 360
        chart = shapes.addChart(ChartType.ClusteredColumn, x, 20, 320, 250)
        chart_data = chart.getChartData()
        chart_data.getSeries().clear()
        categories = chart_data.getCategories()
        categories.clear()
        categories.setUseCells(use_cells)

        workbook = chart_data.getChartDataWorkbook()
        series_name = workbook.getCell(0, 0, 1, "Sales")
        series = chart_data.getSeries().add(series_name, chart.getType())
        for row in range(1, 5):
            label = f"Q{row}"
            if use_cells:
                label_cell = workbook.getCell(0, row, 0, label)
                categories.add(label_cell)
            else:
                categories.add(label)

            value_cell = workbook.getCell(0, row, 1, jpype.JInt(row * 10))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

        stored_in_cells = categories.getUseCells()
        labels = []
        for category in categories:
            value = category.getAsCell().getValue() if stored_in_cells else category.getValue()
            labels.append(str(value))
        print(f"UseCells = {stored_in_cells}:", *labels)

    presentation.save("category-labels.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **वर्कबुक कोशिकाओं के लिए कस्टम नंबर फ़ॉर्मेट सेट करें**

[ChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setCustomNumberFormat) का उपयोग करके आप नियंत्रित कर सकते हैं कि चार्ट के एंबेडेड वर्कबुक में संख्यात्मक मान कैसे प्रदर्शित हों। उदाहरण के लिए, एक रिपोर्ट को परिवर्तन दर को चार दशमलव स्थानों के साथ प्रतिशत के रूप में और गुणांक को पाँच दशमलव स्थानों के साथ प्रदर्शित करने की आवश्यकता हो सकती है। दोनों मानों को संख्यात्मक रखें ताकि वे गणनाओं और चार्ट प्लॉटिंग के लिए उपलब्ध रहें।

एक नंबर फ़ॉर्मेट प्रदर्शन को बदलता है, न कि संग्रहीत मान को। फ़ॉर्मेट `0.0000%` `0.125` को `12.5000%` के रूप में दिखाता है; यह संग्रहीत संख्या को `12.5` से नहीं बदलता। इसी तरह, `0.00000` `0.1234567` को `0.12346` दिखाता है बिना संग्रहीत मान को गोल किए। यदि कस्टम फ़ॉर्मेट एक खाली स्ट्रिंग (`""`) है, तो [getPresetNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#getPresetNumberFormat) द्वारा लौटाया गया फ़ॉर्मेट उपयोग किया जाता है।

निम्न उदाहरण एक कॉलम चार्ट बनाता है और उसके कोशिकाओं तक [getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) के माध्यम से पहुँचता है। वर्कशीट 0 में, B2 में परिवर्तन दर और C2 में गुणांक है। दोनों कोशिकाएँ चार्ट मान प्रदान करती हैं। उदाहरण स्रोत फ़ॉर्मेट से जुड़े मान लेबल को भी सक्षम करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 270, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 20, 620, 210)
    chart.setTitle(False)

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00")
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)
    chart.getAxes().getVerticalAxis().setMinValue(0)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    category_cell = workbook.getCell(0, "A2", "Sample")
    chart.getChartData().getCategories().add(category_cell)

    percentage_cell = workbook.getCell(0, "B2", jpype.JDouble(0.125))
    percentage_cell.setCustomNumberFormat("0.0000%")
    percentage_name = workbook.getCell(0, "B1", "Conversion rate")
    percentage_series = chart.getChartData().getSeries().add(percentage_name, chart.getType())
    percentage_series.getDataPoints().addDataPointForBarSeries(percentage_cell)

    precision_cell = workbook.getCell(0, "C2", jpype.JDouble(0.1234567))
    precision_cell.setCustomNumberFormat("0.00000")
    precision_name = workbook.getCell(0, "C1", "Coefficient")
    precision_series = chart.getChartData().getSeries().add(precision_name, chart.getType())
    precision_series.getDataPoints().addDataPointForBarSeries(precision_cell)

    for series in chart.getChartData().getSeries():
        label_format = series.getDataPoints().get_Item(0).getLabel().getDataLabelFormat()
        label_format.setShowValue(True)
        label_format.setNumberFormatLinkedToSource(True)

    presentation.save("CustomCellFormats.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

वर्कबुक कोशिका फ़ॉर्मेट चार्ट अक्षों या डेटा लेबल पर सीधे सेट किए गए फ़ॉर्मेट से अलग होते हैं। इस उदाहरण में, प्रत्येक लेबल अपना स्रोत सेल का मान दिखाता है क्योंकि [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) `True` पर सेट है, और स्रोत नंबर फ़ॉर्मेट का अनुसरण करता है क्योंकि [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) `True` पर है। प्रेजेंटेशन को सहेजने और पुनः खोलने के बाद, लेबल `12.5000%` और `0.12346` दर्शाते हैं, जैसा कि नीचे दिखाया गया है। ऊर्ध्वाधर अक्ष अपना स्वयं का नंबर फ़ॉर्मेट उपयोग करता है, जिसे [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) द्वारा `0.00` पर सेट किया गया है, और [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) `False` पर है।

डेटा लेबल को स्वतंत्र रूप से फ़ॉर्मेट करने के लिए, उसके स्रोत‑लिंक फ़्लैग को `False` सेट करें और [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormat) के साथ फ़ॉर्मेट असाइन करें। यह वर्कबुक कोशिका के फ़ॉर्मेट को नहीं बदलता। उदाहरण के लिए, `0.00` का स्वतंत्र लेबल फ़ॉर्मेट पहला मान `0.13` दिखाएगा, जबकि B2 अभी भी `12.5000%` दर्शाएगा। सीधे लेबल फ़ॉर्मेटिंग के लिए देखें [Chart Data Labels](/slides/hi/python-java/chart-data-label/#set-percentage-sign-with-chart-data-labels)।

निचे की छवि सहेजे हुए प्रेजेंटेशन को पुनः खोलने के बाद रेंडर की गई है:

![स्रोत‑से‑लिंक्ड लेबल दिखाते हुए कॉलम चार्ट जिसमें 12.5000% और 0.12346 तथा स्वतंत्र रूप से फ़ॉर्मेटेड संख्यात्मक अक्ष है।](custom-cell-formats.png)

## **चार्ट डेटा लेबल के रूप में वर्कबुक सेल सेट करें**

आप वर्कबुक कोशिकाओं के टेक्स्ट को चार्ट डेटा लेबल के रूप में उपयोग कर सकते हैं।

यह उदाहरण मौजूदा प्रेजेंटेशन की पहली स्लाइड पर एक बबल चार्ट डिफ़ॉल्ट डेटा के साथ जोड़ता है। यह वर्कशीट 0 में कोशिकाएँ A10:A12 का उपयोग पहले श्रृंखला के पहले तीन लेबल के लिए करता है, कोशिकाओं से लेबल सक्षम करता है, और अपडेटेड प्रेजेंटेशन को सहेजता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart2.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    label_values = ["Label 0 cell value", "Label 1 cell value", "Label 2 cell value"]
    
    chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, True)
    series = chart.getChartData().getSeries()
    data_labels = series.get_Item(0).getLabels()
    data_labels.getDefaultDataLabelFormat().setShowLabelValueFromCell(True)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(3):
        label_cell = workbook.getCell(0, f"A{10 + i}", label_values[i])
        data_labels.get_Item(i).setValueFromCell(label_cell)

    presentation.save("resultchart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **वर्कशीट का प्रबंधन करें**

[ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getWorksheets) मेथड चार्ट वर्कबुक में वर्कशीट तक पहुंच प्रदान करती है। यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक पाई चार्ट बनाता है और प्रत्येक वर्कशीट नाम को कंसोल पर प्रिंट करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 500)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(workbook.getWorksheets().size()):
        print(workbook.getWorksheets().get_Item(i).getName())
finally:
    presentation.dispose()
```

## **डेटा स्रोत प्रकार निर्धारित करें**

श्रृंखला बिंदु मानों को सीधे संख्यात्मक लिटरल के रूप में भी संग्रहीत किया जा सकता है। पूर्ण उदाहरण के लिए देखें [Set Series Values Using Numeric Literals](/slides/hi/python-java/chart-series/#set-series-values-using-numeric-literals) जिसमें उन्हें सहेजा और पढ़ा गया है। बिंदु मानों का स्रोत प्रकार चार्ट के आंतरिक या बाहरी वर्कबुक कॉन्फ़िगरेशन से अलग होता है; संख्यात्मक लिटरल का उपयोग करने से एंबेडेड वर्कबुक स्वयं नहीं हटती।

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक 3D कॉलम चार्ट बनाता है और दो श्रृंखला नाम विभिन्न डेटा स्रोतों का उपयोग करके सेट करता है। पहला नाम स्ट्रिंग लिटरल है; दूसरा वर्कशीट 0 के सेल C1 का उपयोग करता है। [DataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/) एन्हुमरेशन प्रत्येक नाम के लिए स्रोत चुनता है। उदाहरण अद्यतन श्रृंखला नामों के साथ प्रेजेंटेशन को सहेजता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, True)
    literal_name = chart.getChartData().getSeries().get_Item(0).getName()
    literal_name.setDataSourceType(DataSourceType.StringLiterals)
    literal_name.setData("LiteralString")
    cell_name = chart.getChartData().getSeries().get_Item(1).getName()
    name_cell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell")
    cell_name.setDataSourceType(DataSourceType.Worksheet)
    cell_name.setData(name_cell)
    
    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **असमर्थित एंबेडेड वर्कबुक फ़ॉर्मेट का पता लगाएँ**

Aspose.Slides उन Excel बाइनरी वर्कबुक (.xlsb) फ़ॉर्मेट को समर्थन नहीं देता जो कुछ चार्ट में एंबेडेड हो सकते हैं। आप [ChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/) पर [getEmbeddedWorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) मेथड को [WorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/workbooktype/) एन्हुमरेशन के साथ उपयोग करके असमर्थित फ़ॉर्मेट का पता लगा सकते हैं और उन चार्ट को छोड़ सकते हैं। यह उदाहरण मौजूदा प्रेजेंटेशन की पहली स्लाइड पर आकृतियों को जाँचता है, गैर‑चार्ट आकृतियों को छोड़ता है, और प्रत्येक .xlsb एंबेडेड वर्कबुक वाले चार्ट के लिए निदान संदेश प्रिंट करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartDataSourceType, Presentation, WorkbookType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, Chart):
            continue

        chart_data = shape.getChartData()

        is_internal_workbook = chart_data.getDataSourceType() == ChartDataSourceType.InternalWorkbook
        is_binary_macro = chart_data.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro

        if is_internal_workbook and is_binary_macro:
            print("Skipping a chart with an unsupported .xlsb workbook.")
            continue
        # समर्थित चार्ट वर्कबुक डेटा को यहाँ पढ़ें या संशोधित करें।
finally:
    presentation.dispose()
```

## **बाहरी वर्कबुक**

Aspose.Slides चार्ट के लिए डेटा स्रोत के रूप में बाहरी वर्कबुक का उपयोग समर्थन करता है।

### **एक बाहरी वर्कबुक बनाएँ**

[readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) और [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) का उपयोग करके एंबेडेड चार्ट वर्कबुक को फ़ाइल में निर्यात करें और चार्ट को उस बाहरी वर्कबुक से लिंक करें।

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक पाई चार्ट बनाता है और उसकी वर्कबुक निर्यात करता है। यह फ़ाइल लिखने को पूरा करता है फिर बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में असाइन करता है, और लिंक्ड प्रेजेंटेशन को सहेजता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600)
    workbook_path = Path("externalWorkbook1.xlsx").resolve()
    workbook_data = chart.getChartData().readWorkbookStream()
    Path(workbook_path).write_bytes(bytes(workbook_data))
    chart.getChartData().setExternalWorkbook(str(workbook_path))

    presentation.save("externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **एक बाहरी वर्कबुक सेट करें**

[setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) मेथड का उपयोग करके आप एक चार्ट को बाहरी वर्कबुक को उसके डेटा स्रोत के रूप में असाइन कर सकते हैं। यह मेथड पथ को अपडेट करने के लिए भी उपयोग किया जा सकता है यदि बाहरी वर्कबुक को स्थानांतरित किया गया हो।

जबकि आप रिमोट लोकेशन या संसाधनों में संग्रहीत वर्कबुक डेटा को संपादित नहीं कर सकते, आप ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में अभी भी उपयोग कर सकते हैं। यदि बाहरी वर्कबुक के लिए सापेक्ष पथ प्रदान किया जाता है, तो यह स्वचालित रूप से पूर्ण पथ में परिवर्तित हो जाता है।

यह उदाहरण एक बाहरी वर्कबुक का उपयोग करता है जिसकी वर्कशीट `Sheet1` में B1 में श्रृंखला नाम, A2:A4 में श्रेणी नाम और B2:B4 में संख्यात्मक मान हैं। उदाहरण एक पाई चार्ट बनाता है, वर्कबुक लिंक करता है, और [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) का उपयोग करके A1:B4 को एक श्रृंखला और तीन श्रेणियों के रूप में मैप करता है। यह लिंक्ड चार्ट के साथ प्रेजेंटेशन को सहेजता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    workbook_path = str(Path("externalWorkbook.xlsx").resolve())
    chart_data.setExternalWorkbook(workbook_path)
    chart_data.setRange("Sheet1!$A$1:$B$4")

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) का `updateChartData` पैरामीटर नियंत्रित करता है कि वर्कबुक लोड हो या नहीं।

* जब `updateChartData` `False` है, तो केवल वर्कबुक पथ अपडेट होता है। चार्ट डेटा लक्ष्य वर्कबुक से लोड या अपडेट नहीं होता, इसलिए वर्कबुक अनुपलब्ध हो भी सकती है।
* जब `updateChartData` `True` है, तो चार्ट डेटा लक्ष्य वर्कबुक से अपडेट होता है।

निम्न उदाहरण `updateChartData` को `False` पर सेट करके एक प्लेसहोल्डर URL असाइन करता है। यह पाई चार्ट के डिफ़ॉल्ट डेटा को बरकरार रखता है और अनुपलब्ध वर्कबुक को लोड किए बिना प्रेजेंटेशन को सहेजता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", False)

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **एक चार्ट के बाहरी डेटा स्रोत वर्कबुक पथ को प्राप्त करें**

किसी चार्ट से लिंक्ड वर्कबुक की पहचान करने के लिए, जाँचें कि क्या चार्ट बाहरी डेटा स्रोत का उपयोग करता है और उसका वर्कबुक पथ प्राप्त करें।

यह उदाहरण प्रेजेंटेशन की पहली स्लाइड पर पहले आकृति को जाँचता है जिसमें लिंक्ड बाहरी वर्कबुक है। यदि यह बाहरी वर्कबुक से लिंक्ड चार्ट है, तो उदाहरण कंसोल में [getExternalWorkbookPath](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) को प्रिंट करता है। फिर यह प्रेजेंटेशन की एक प्रतिलिपि सहेजता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartDataSourceType, Presentation, SaveFormat

presentation = Presentation("externalWorkbook.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        if chart_data.getDataSourceType() == ChartDataSourceType.ExternalWorkbook:
            print(chart_data.getExternalWorkbookPath())
        else:
            print("The chart does not use an external workbook.")
    else:
        print("The first shape is not a chart.")

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **चार्ट डेटा संपादित करें**

आप बाहरी वर्कबुक में डेटा को उसी तरह संपादित कर सकते हैं जैसा आप आंतरिक वर्कबुक की सामग्री बदलते हैं। जब कोई बाहरी वर्कबुक लोड नहीं हो पाती, तो एक अपवाद फेंका जाता है।

यह उदाहरण पहली स्लाइड की पहली आकृति पर एक चार्ट का उपयोग करता है जो पहुँच योग्य बाहरी वर्कबुक से लिंक्ड है। यह पहली श्रृंखला के पहले डेटा बिंदु के सेल‑बैक्ड मान को 100 पर सेट करता है और अपडेटेड प्रेजेंटेशन को सहेजता है। सेल मानों को संपादित करने से लिंक्ड बाहरी XLSX फ़ाइल अपडेट हो सकती है, इसलिए मूल वर्कबुक को संरक्षित रखने हेतु एक कॉपी का उपयोग करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        series = chart.getChartData().getSeries()
        if series.size() > 0 and series.get_Item(0).getDataPoints().size() > 0:
            value_cell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell()
            if value_cell is not None:
                value_cell.setValue(jpype.JInt(100))
                presentation.save("presentation_out.pptx", SaveFormat.Pptx)
            else:
                print("The first data point is not linked to a workbook cell.")
        else:
            print("The chart has no data points to edit.")
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

### **चार्ट कैश से वर्कबुक पुनर्प्राप्त करें**

यदि कोई चार्ट ऐसी बाहरी वर्कबुक का उपयोग करता है जो गायब या अनुपलब्ध है, तो Aspose.Slides प्रेजेंटेशन में कैश्ड डेटा से चार्ट वर्कबुक को पुनः बनाता है। [LoadOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/) बनाएं, [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions) को कॉल करें, और [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) को `True` सेट करें इससे पहले कि प्रेजेंटेशन खोला जाए।

निम्न Python उदाहरण पहली स्लाइड की पहली आकृति पर एक चार्ट के लिए वर्कबुक डेटा पुनर्प्राप्त करता है और जो एक अनुपलब्ध बाहरी वर्कबुक का संदर्भ देता है। यह पुनर्प्राप्त डेटा को [Chart.getChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getChartData) और [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) के माध्यम से एक्सेस करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, LoadOptions, Presentation, SpreadsheetOptions

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setRecoverWorkbookFromChartCache(True)

load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        recovered_workbook = chart.getChartData().getChartDataWorkbook()

        # यहाँ पुनर्प्राप्त वर्कबुक डेटा को पढ़ें या संशोधित करें।
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

यदि बाहरी वर्कबुक अनुपलब्ध है और पुनर्प्राप्ति अक्षम है, तो Aspose.Slides अपवाद फेंकता है। केवल तब पुनर्प्राप्ति सक्षम करें जब कैश्ड चार्ट डेटा का उपयोग एक स्वीकृत बैकअप के रूप में ठीक हो, क्योंकि कैश में बाहरी वर्कबुक में प्रेजेंटेशन के अंतिम अपडेट के बाद किए गए परिवर्तन शामिल नहीं हो सकते।

## **FAQ**

**क्या मैं यह निर्धारित कर सकता हूँ कि कोई विशिष्ट चार्ट बाहरी या एंबेडेड वर्कबुक से लिंक्ड है?**

हां। एक चार्ट के पास [डेटा स्रोत प्रकार](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType) और एक [बाहरी वर्कबुक पथ](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) होता है; यदि स्रोत बाहरी वर्कबुक है, तो आप पूर्ण पथ पढ़ कर यह सुनिश्चित कर सकते हैं कि बाहरी फ़ाइल उपयोग में है।

**क्या बाहरी वर्कबुक के सापेक्ष पथ समर्थित हैं, और वे कैसे संग्रहीत होते हैं?**

हां। यदि आप सापेक्ष पथ निर्दिष्ट करते हैं, तो यह स्वचालित रूप से पूर्ण पथ में परिवर्तित हो जाता है। प्रेजेंटेशन PPTX फ़ाइल में पूर्ण पथ संग्रहीत करता है, इसलिए वर्कबुक को स्थानांतरित करने पर लिंक को अपडेट करना पड़ सकता है।

**क्या मैं नेटवर्क संसाधनों/शेयरों पर स्थित वर्कबुक का उपयोग कर सकता हूँ?**

हां, ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। हालांकि, Aspose.Slides से रिमोट वर्कबुक को सीधे संपादित करना समर्थित नहीं है—वे केवल स्रोत के रूप में उपयोग की जा सकती हैं।

**क्या Aspose.Slides प्रेजेंटेशन सहेजते समय बाहरी XLSX को ओवरराइट करता है?**

प्रेजेंटेशन में एक [बाहरी फ़ाइल लिंक](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) संग्रहीत होता है। सेल‑बैक्ड चार्ट डेटा को संपादित करने से लिंक्ड स्थानीय XLSX फ़ाइल भी अपडेट हो सकती है। यदि मूल को अपरिवर्तित रखना है तो वर्कबुक की एक कॉपी का उपयोग करें।

**यदि बाहरी फ़ाइल पासवर्ड‑सुरक्षित है तो मैं क्या करूँ?**

Aspose.Slides लिंक करते समय पासवर्ड स्वीकार नहीं करता। सामान्य तरीका यह है कि पहले सुरक्षा हटाई जाए या एक डिक्रिप्टेड कॉपी (जैसे [Aspose.Cells](https://reference.aspose.com/cells/python-java/)) तैयार की जाए और उस कॉपी को लिंक किया जाए।

**क्या कई चार्ट एक ही बाहरी वर्कबुक का संदर्भ दे सकते हैं?**

हां। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल की ओर इशारा करते हैं, तो फ़ाइल को अपडेट करने से प्रत्येक चार्ट में अगली बार डेटा लोड होने पर परिवर्तन प्रतिबिंबित होते हैं।