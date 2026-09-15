---
title: Excel डेटा को PowerPoint प्रस्तुतियों में एकीकृत करें
linktitle: Excel एकीकरण
type: docs
weight: 330
url: /hi/python-java/excel-integration/
keywords:
- एक्सेल
- वर्कबुक
- Excel पढ़ें
- Excel को एकीकृत करें
- डेटा स्रोत
- मेल मर्ज
- तालिका आयात करें
- Excel को PowerPoint में
- PowerPoint
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java में ExcelDataWorkbook API का उपयोग करके Excel वर्कबुक से डेटा पढ़ें। शीट और सेल लोड करें और मानों का उपयोग करके डेटा‑चालित PowerPoint प्रस्तुतियाँ बनाएँ।"
---
## **परिचय**

PowerPoint प्रस्तुतियाँ जानकारी को प्रदर्शित और संवाद करने का एक शक्तिशाली तरीका हैं। इन्हें अक्सर Excel वर्कबुक के साथ उपयोग किया जाता है, जहाँ Excel संरचित डेटा का उत्कृष्ट स्रोत है और PowerPoint उस डेटा को दर्शकों के लिए दृश्य रूप में प्रस्तुत करने में उत्कृष्ट है।

Excel और PowerPoint को मिलाकर कई व्यावहारिक परिदृश्य होते हैं: मेल मर्ज, डेटा तालिकाएँ भरना, प्रत्येक डेटा रिकॉर्ड के लिए एक स्लाइड उत्पन्न करना (बैच स्लाइड जेनरेशन), प्रशिक्षण सामग्री बनाना, और कई Excel रिपोर्ट को एक ही प्रस्तुति में एकत्रित करना, आदि।

अब तक, Aspose.Slides API के साथ ऐसी सुविधाएँ लागू करने के लिए Aspose.Cells जैसे तृतीय‑पक्ष समाधान पर निर्भर रहना पड़ता था। जबकि ये उपकरण मजबूत हैं, वे केवल बुनियादी डेटा इंटीग्रेशन कार्यक्षमता की आवश्यकता वाले उपयोगकर्ताओं के लिए अत्यधिक जटिल और महंगे हो सकते हैं।

## **कैसे काम करता है**

Excel डेटा के साथ काम को आसान और सुव्यवस्थित बनाने के लिए, Aspose.Slides ने नई क्लासें पेश की हैं जो Excel वर्कबुक से डेटा पढ़ती हैं और प्रस्तुति में सामग्री आयात करती हैं। यह सुविधा API उपयोगकर्ताओं को Excel को डेटा स्रोत के रूप में उपयोग करते हुए प्रस्तुति वर्कफ़्लो में नई संभावनाएँ खोलती है।

नई कार्यक्षमता सामान्य‑उद्देश्य डेटा एक्सेस के लिए डिज़ाइन की गई है और Presentation Document Object Model (DOM) में एकीकृत नहीं है। इसका अर्थ है कि *यह Excel फ़ाइलों को संपादित या सहेजने की अनुमति नहीं देता* — इसका एकमात्र उद्देश्य वर्कबुक खोलना और उसकी सामग्री के माध्यम से नेविगेट करके सेल डेटा प्राप्त करना है।

इस सुविधा के केंद्र में नई [ExcelDataWorkbook](https://reference.aspose.com/slides/hi/python-java/aspose.slides/exceldataworkbook/) क्लास है। यह क्लास आपको स्थानीय फ़ाइल या स्ट्रीम से Excel वर्कबुक लोड करने की अनुमति देती है। लोड होने के बाद, यह कई ओवरलोड वाले [ExcelDataWorkbook.getCell](https://reference.aspose.com/slides/hi/python-java/aspose.slides/exceldataworkbook/#getCell) मेथड प्रदान करता है, जिसका उपयोग आप सेल को उनके स्थान (जैसे पंक्ति और स्तंभ इंडेक्स या नामित रेंज) द्वारा प्राप्त करने के लिए कर सकते हैं।

प्रत्येक कॉल [ExcelDataWorkbook.getCell](https://reference.aspose.com/slides/hi/python-java/aspose.slides/exceldataworkbook/#getCell) एक [ExcelDataCell](https://reference.aspose.com/slides/hi/python-java/aspose.slides/exceldatacell/) ऑब्जेक्ट लौटाता है। यह ऑब्जेक्ट Excel वर्कबुक में एकल सेल का प्रतिनिधित्व करता है और आपको उसके मान तक सरल और सहज तरीके से पहुंच प्रदान करता है।

#### **एक्सेल चार्ट आयात करें**

कार्यात्मकता का अगला चरण है [ExcelWorkbookImporter](https://reference.aspose.com/slides/hi/python-java/aspose.slides/excelworkbookimporter/) क्लास। यह यूटिलिटी क्लास Excel वर्कबुक से सामग्री को प्रस्तुति में आयात करने की सुविधा देती है। यह कई ओवरलोड वाले [ExcelWorkbookImporter.addChartFromWorkbook](https://reference.aspose.com/slides/hi/python-java/aspose.slides/excelworkbookimporter/#addChartFromWorkbook) मेथड प्रदान करती है, जो निर्दिष्ट Excel वर्कबुक से चयनित चार्ट को प्राप्त करके निर्दिष्ट समन्वयों पर दिए गए शेप कलेक्शन के अंत में जोड़ने में मदद करता है।

#### **एक्सेल तालिका आयात करें**

[ExcelWorkbookImporter](https://reference.aspose.com/slides/hi/python-java/aspose.slides/excelworkbookimporter/) क्लास में कई ओवरलोड वाले [ExcelWorkbookImporter.addTableFromWorkbook](https://reference.aspose.com/slides/hi/python-java/aspose.slides/excelworkbookimporter/#addTableFromWorkbook) मेथड भी होते हैं। ये मेथड आपको निर्दिष्ट वर्कशीट से एक विशेष सेल रेंज आयात करके उसे निर्दिष्ट समन्वयों पर दिए गए शेप कलेक्शन के अंत में तालिका के रूप में जोड़ने की अनुमति देते हैं।

संक्षेप में, यह एक हल्का और सीधा API है Excel डेटा पढ़ने के लिए — बिल्कुल वही जो कई डेवलपर्स को पूरे स्प्रेडशीट प्रोसेसिंग लाइब्रेरी के ओवरहेड के बिना चाहिए।

## **चलो कोड लिखें**

### **मेल मर्ज परिदृश्य उदाहरण**

निम्न उदाहरण में हम एक सरल मेल मर्ज परिदृश्य को लागू करेंगे, जहाँ Excel वर्कबुक में संग्रहीत डेटा के आधार पर कई प्रस्तुतियाँ उत्पन्न की जाएँगी।

शुरू करने के लिए हमें दो चीज़ों की आवश्यकता है:

1. डेटा वाला Excel वर्कबुक

![Excel डेटा उदाहरण](example1_image0.png)

2. PowerPoint प्रस्तुति टेम्प्लेट

![PowerPoint टेम्प्लेट उदाहरण](example1_image1.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, Presentation, SaveFormat

    # कर्मचारी डेटा के साथ Excel वर्कबुक लोड करें।
    workbook = ExcelDataWorkbook("TemplateData.xlsx")
    worksheet_index = 0

    # प्रस्तुति टेम्प्लेट लोड करें।
    template_presentation = Presentation("PresentationTemplate.pptx")

    try:
        # Excel पंक्तियों पर लूप करें (पंति 0 पर हेडर को छोड़कर)।
        for row_index in range(1, 5):

            # प्रत्येक employee रिकॉर्ड के लिए एक प्रस्तुति बनाएं।
            employee_presentation = Presentation()

            try:
                # डिफ़ॉल्ट खाली स्लाइड को हटाएँ।
                employee_presentation.getSlides().removeAt(0)

                # टेम्प्लेट स्लाइड को प्रस्तुति में क्लोन करें।
                slide = employee_presentation.getSlides().addClone(template_presentation.getSlides().get_Item(0))

                # लक्षित आकार से पैराग्राफ प्राप्त करें (मान लिया गया है कि आकार इंडेक्स 1 उपयोग किया गया है)।
                paragraphs = slide.getShapes().get_Item(1).getTextFrame().getParagraphs()

                # प्लेसहोल्डर को Excel डेटा से बदलें।
                employee_name = str(workbook.getCell(worksheet_index, row_index, 0).getValue())
                name_portion = paragraphs.get_Item(0).getPortions().get_Item(0)
                name_portion.setText(str(name_portion.getText()).replace("{{EmployeeName}}", employee_name))

                department = str(workbook.getCell(worksheet_index, row_index, 1).getValue())
                department_portion = paragraphs.get_Item(1).getPortions().get_Item(0)
                department_portion.setText(str(department_portion.getText()).replace("{{Department}}", department))

                years_of_service = str(workbook.getCell(worksheet_index, row_index, 2).getValue())
                years_portion = paragraphs.get_Item(2).getPortions().get_Item(0)
                years_portion.setText(str(years_portion.getText()).replace("{{YearsOfService}}", years_of_service))

                # व्यक्तिगत प्रस्तुति को एक अलग फ़ाइल में सहेजें।
                employee_presentation.save(f"{employee_name} Report.pptx", SaveFormat.Pptx)
            finally:
                employee_presentation.dispose()
    finally:
        template_presentation.dispose()
```

![परिणाम](example1_image2.png)

### **Excel तालिका उदाहरण**

दूसरे उदाहरण में हम बस Excel तालिका से डेटा कॉपी करके उसे PowerPoint स्लाइड पर अधिक दृश्यात्मक रूप में प्रदर्शित करेंगे।

इस उदाहरण में हम पहले उदाहरण में उपयोग किए गए वही Excel वर्कबुक का उपयोग करेंगे, जिसमें एक सरल कर्मचारी तालिका है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, Presentation, SaveFormat

# कर्मचारी डेटा वाले Excel वर्कबुक को लोड करें।
workbook = ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# PowerPoint प्रस्तुति बनाएँ।
presentation = Presentation()

try:
    # पहली स्लाइड में टेबल आकार जोड़ें।
    column_widths = jpype.JArray(jpype.JDouble)([200, 200, 200])
    row_heights = jpype.JArray(jpype.JDouble)([30, 30, 30, 30, 30])
    table = presentation.getSlides().get_Item(0).getShapes().addTable(50, 200, column_widths, row_heights)

    # Excel वर्कबुक से डेटा के साथ PowerPoint टेबल को भरें।
    for row_index in range(5):
        for column_index in range(3):
            cell_value = str(workbook.getCell(worksheet_index, row_index, column_index).getValue())
            table.getColumns().get_Item(column_index).get_Item(row_index).getTextFrame().setText(cell_value)

    # परिणामस्वरूप प्रस्तुति को फ़ाइल में सहेजें।
    presentation.save("Table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![परिणाम](example2_image0.png)

### **एक्सेल चार्ट आयात उदाहरण**

इस उदाहरण में हम पिछले उदाहरण में उपयोग किए गए Excel वर्कबुक की पहली वर्कशीट से एक चार्ट आयात करेंगे। परिणामस्वरूप प्रस्तुति में चार्ट बाहरी वर्कबुक से जुड़ा होगा।

पहले, हम कर्मचारी तालिका के आधार पर Excel वर्कबुक में एक पाई चार्ट जोड़ते हैं।

![Excel चार्ट उदाहरण](example3_image0.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelWorkbookImporter, Presentation, SaveFormat

# PowerPoint प्रस्तुति बनाएँ।
presentation = Presentation()
try:
    # पहली स्लाइड का shapes संग्रह प्राप्त करें।
    shapes = presentation.getSlides().get_Item(0).getShapes()

    # वर्कबुक की पहली शीट से "Chart 1" नामक चार्ट आयात करें और इसे shapes संग्रह में जोड़ें।
    ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", False)

    # परिणामस्वरूप प्रस्तुति को फ़ाइल में सहेजें।
    presentation.save("Chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![परिणाम](example3_image1.png)

### **सभी Excel चार्ट आयात उदाहरण**

कल्पना करें कि आपके पास कई चार्ट वाले एक Excel वर्कबुक है और आपको उन्हें सभी प्रस्तुति में आयात करने की आवश्यकता है। प्रत्येक चार्ट को एक नई स्लाइड पर रखा जाना चाहिए।

निम्न कोड स्रोत Excel फ़ाइल की सभी वर्कशीटों में क्रमबद्ध होकर प्रत्येक वर्कशीट से चार्ट निकालता है और प्रत्येक चार्ट को एक खाली स्लाइड लेआउट का उपयोग करके अलग‑अलग स्लाइड में जोड़ता है। परिणामस्वरूप प्रस्तुति में केवल चार्ट डेटा एंबेड किया जाएगा, पूरी वर्कबुक नहीं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, ExcelWorkbookImporter, Presentation, SaveFormat, SlideLayoutType

# कर्मचारी डेटा वाले Excel वर्कबुक को लोड करें।
workbook = ExcelDataWorkbook("ExcelWithCharts.xlsx")

# PowerPoint प्रस्तुति बनाएँ।
presentation = Presentation()
try:
    # खाली स्लाइड लेआउट प्राप्त करें।
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    # डिफ़ॉल्ट स्लाइड हटाएँ ताकि परिणाम में प्रत्येक चार्ट के लिए एक स्लाइड हो।
    presentation.getSlides().removeAt(0)

    # Excel वर्कबुक में मौजूद सभी वर्कशीटों के नाम प्राप्त करें।
    worksheet_names = workbook.getWorksheetNames()

    for name in worksheet_names:
        # वर्कशीट के लिए चार्ट इंडेक्स को चार्ट नामों से मैप करने वाला नक्शा प्राप्त करें।
        worksheet_charts = workbook.getChartsFromWorksheet(name)

        for chart in worksheet_charts:
            # खाली लेआउट का उपयोग करके एक स्लाइड जोड़ें।
            slide = presentation.getSlides().addEmptySlide(blank_layout)

            # निर्दिष्ट चार्ट को Excel वर्कबुक से स्लाइड के shapes संग्रह में आयात करें।
            ExcelWorkbookImporter.addChartFromWorkbook(slide.getShapes(), 10, 10, workbook, name, chart.getKey(), False)

    # परिणामस्वरूप प्रस्तुति को फ़ाइल में सहेजें।
    presentation.save("Charts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **एक्सेल तालिका आयात उदाहरण**

इस उदाहरण में हम एक स्वरूपित तालिका को सीधे Excel वर्कशीट से PowerPoint प्रस्तुति में आयात करते हैं।

स्रोत Excel वर्कशीट में कर्मचारी डेटा वाली एक स्वरूपित तालिका मौजूद है:

![Excel तालिका उदाहरण](example4_image0.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelWorkbookImporter, Presentation, SaveFormat

# PowerPoint प्रस्तुति बनाएँ।
presentation = Presentation()
try:
    # पहली स्लाइड और उसके shapes संग्रह प्राप्त करें।
    slide = presentation.getSlides().get_Item(0)
    shapes = slide.getShapes()

    # वर्कबुक की पहली शीट से टेबल आयात करें और इसे shapes संग्रह में जोड़ें।
    ExcelWorkbookImporter.addTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5")

    # परिणामस्वरूप प्रस्तुति को फ़ाइल में सहेजें।
    presentation.save("FormattedTable.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![परिणाम](example4_image1.png)

## **सारांश**

यह तंत्र, जो सीधे Aspose.Slides में उपलब्ध है, Excel डेटा और प्रस्तुतियों को एक ही स्थान पर जोड़ता है। यह आपको Excel तालिकाओं के रूप में डेटा के साथ दृश्यात्मक चार्ट वाली स्लाइड बनाने की अनुमति देता है—बिना किसी अतिरिक्त लाइब्रेरी या जटिल इंटीग्रेशन के।