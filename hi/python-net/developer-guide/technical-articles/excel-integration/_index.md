---
title: PowerPoint प्रस्तुतियों में Excel डेटा एकीकृत करें
linktitle: Excel एकीकरण
type: docs
weight: 330
url: /hi/python-net/excel-integration/
keywords:
- Excel
- वर्कबुक
- Excel पढ़ें
- Excel एकीकृत करें
- डेटा स्रोत
- मेल मर्ज
- तालिका आयात करें
- PowerPoint में Excel
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides में ExcelDataWorkbook API का उपयोग करके Excel वर्कबुक से डेटा पढ़ें। शीट और सेल लोड करें और मानों का उपयोग करके डेटा‑चालित PowerPoint प्रस्तुतियों को जनरेट करें।"
---
## **परिचय**

PowerPoint प्रस्तुतियाँ जानकारी को प्रदर्शित करने और संप्रेषित करने का एक प्रभावी तरीका हैं। इन्हें अक्सर Excel वर्कबुक के साथ मिलाकर प्रयोग किया जाता है, जहाँ Excel संरचित डेटा का उत्कृष्ट स्रोत है और PowerPoint उस डेटा को दर्शकों के लिए दृश्यात्मक रूप से प्रस्तुत करने में उत्कृष्ट है।

Excel और PowerPoint को मिलाकर उपयोग करने के कई व्यावहारिक परिदृश्य हैं: मेल मर्ज, डेटा तालिकाएँ भरना, प्रत्येक डेटा रिकॉर्ड के लिए एक स्लाइड बनाना (बैच स्लाइड जनरेशन), प्रशिक्षण सामग्री बनाना, और कई Excel रिपोर्टों को एक ही प्रस्तुति में समेकित करना, आदि।

अब तक, Aspose.Slides API के साथ ऐसी सुविधाएँ लागू करने के लिए Aspose.Cells जैसी तृतीय‑पक्षीय समाधानों पर निर्भर रहना पड़ता था। जबकि ये उपकरण मजबूत हैं, वे केवल बुनियादी डेटा इंटीग्रेशन कार्यक्षमता की आवश्यकता वाले उपयोगकर्ताओं के लिए अत्यधिक जटिल और महंगे हो सकते हैं।

## **यह कैसे काम करता है**

Excel डेटा के साथ काम करना आसान और सुगम बनाने के लिए Aspose.Slides ने Excel वर्कबुक से डेटा पढ़ने और सामग्री को प्रस्तुति में आयात करने के लिए नई कक्षाएँ पेश की हैं। यह विशेषता API उपयोगकर्ताओं को उनकी प्रस्तुति कार्यप्रवाह में डेटा स्रोत के रूप में Excel का उपयोग करने के नए शक्तिशाली मार्ग खोलती है।

नयी कार्यक्षमता सामान्य‑उद्देश्य डेटा पहुँच के लिए डिज़ाइन की गई है और Presentation Document Object Model (DOM) में एकीकृत नहीं है। इसका मतलब है *यह Excel फ़ाइलों को संपादित या सहेजने की अनुमति नहीं देता* — इसका एकमात्र उद्देश्य वर्कबुक को खोलना और उसकी सामग्री में नेविगेट करके सेल डेटा प्राप्त करना है।

इस विशेषता के केंद्र में नई [ExcelDataWorkbook](https://reference.aspose.com/slides/hi/python-net/aspose.slides.excel/exceldataworkbook/) कक्षा है। यह कक्षा आपको स्थानीय फ़ाइल या स्ट्रीम से एक Excel वर्कबुक लोड करने की अनुमति देती है। लोड होने के बाद, यह कई ओवरलोडेड [get_cell](https://reference.aspose.com/slides/hi/python-net/aspose.slides.excel/exceldataworkbook/get_cell/) मेथड प्रदान करती है, जिन्हें आप उनकी स्थिति (जैसे पंक्ति और स्तंभ सूचकांक या नामित रेंज) के आधार पर विशिष्ट सेल प्राप्त करने के लिए उपयोग कर सकते हैं।

प्रत्येक बार [get_cell](https://reference.aspose.com/slides/hi/python-net/aspose.slides.excel/exceldataworkbook/get_cell/) को कॉल करने पर एक [ExcelDataCell](https://reference.aspose.com/slides/hi/python-net/aspose.slides.excel/exceldatacell/) कक्षा का उदाहरण मिलता है। यह ऑब्जेक्ट Excel वर्कबुक के एकल सेल का प्रतिनिधित्व करता है और आपको उसकी मान तक सरल और सहज तरीके से पहुँच प्रदान करता है।

#### **Excel चार्ट आयात करें**

इस कार्यक्षमता को विस्तारित करने का अगला कदम [ExcelWorkbookImporter](https://reference.aspose.com/slides/hi/python-net/aspose.slides.importing/excelworkbookimporter/) कक्षा है। यह उपयोगी कक्षा Excel वर्कबुक से सामग्री को प्रस्तुति में आयात करने की कार्यक्षमता प्रदान करती है। इसमें कई ओवरलोडेड [add_chart_from_workbook](https://reference.aspose.com/slides/hi/python-net/aspose.slides.importing/excelworkbookimporter/add_chart_from_workbook/) मेथड शामिल हैं, जो निर्दिष्ट Excel वर्कबुक से चयनित चार्ट को प्राप्त करके निर्दिष्ट निर्देशांक पर दिए गए शेप कलेक्शन के अंत में जोड़ते हैं।

संक्षेप में, यह Excel डेटा पढ़ने के लिए एक हल्का और सरल API है — वही जो कई डेवलपर्स को पूर्ण स्प्रेडशीट प्रोसेसिंग लाइब्रेरी की ओवरहेड के बिना चाहिए।

## **आइए कोड लिखें**

### **मेल मर्ज परिदृश्य उदाहरण**

निम्न उदाहरण में, हम एक सरल मेल मर्ज परिदृश्य को लागू करेंगे, जहाँ Excel वर्कबुक में संग्रहीत डेटा के आधार पर कई प्रस्तुतियाँ उत्पन्न की जाएँगी।

शुरू करने के लिए हमें दो चीज़ों की आवश्यकता है:
1. डेटा युक्त एक Excel वर्कबुक

![Excel डेटा उदाहरण](example1_image0.png)

2. PowerPoint प्रस्तुति टेम्पलेट

![PowerPoint टेम्पलेट उदाहरण](example1_image1.png)

```py
import aspose.slides as slides

# कर्मचारी डेटा के साथ Excel वर्कबुक लोड करें।
workbook = slides.excel.ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# प्रस्तुति टेम्पलेट लोड करें।
with slides.Presentation("PresentationTemplate.pptx") as template_presentation:

    # Excel पंक्तियों पर लूप करें (पंक्ति 0 में हेडर को छोड़कर)।
    for row_index in range(1, 5):

        # प्रत्येक कर्मचारी रिकॉर्ड के लिए नई प्रस्तुति बनाएं।
        with slides.Presentation() as employee_presentation:

            # डिफ़ॉल्ट खाली स्लाइड हटाएं।
            employee_presentation.slides.remove_at(0)

            # टेम्पलेट स्लाइड को नई प्रस्तुति में क्लोन करें।
            slide = employee_presentation.slides.add_clone(template_presentation.slides[0])

            # लक्ष्य शेप से पैराग्राफ प्राप्त करें (मान लिया गया है कि शेप इंडेक्स 1 उपयोग में है)।
            paragraphs = slide.shapes[1].text_frame.paragraphs

            # प्लेसहोल्डर को Excel के डेटा से बदलें।
            employee_name = workbook.get_cell(worksheet_index, row_index, 0).value
            name_portion = paragraphs[0].portions[0]
            name_portion.text = name_portion.text.replace("{{EmployeeName}}", employee_name)

            department = workbook.get_cell(worksheet_index, row_index, 1).value
            department_portion = paragraphs[1].portions[0]
            department_portion.text = department_portion.text.replace("{{Department}}", department)

            years_of_service = str(workbook.get_cell(worksheet_index, row_index, 2).value)
            years_portion = paragraphs[2].portions[0]
            years_portion.text = years_portion.text.replace("{{YearsOfService}}", years_of_service)

            # व्यक्तिगत प्रस्तुति को एक अलग फ़ाइल में सेव करें।
            employee_presentation.save(f"{employee_name} Report.pptx", slides.export.SaveFormat.PPTX)
```

![परिणाम](example1_image2.png)

### **Excel तालिका उदाहरण**

दूसरे उदाहरण में, हम केवल Excel तालिका से डेटा कॉपी कर उसे PowerPoint स्लाइड पर अधिक दृश्यात्मक रूप में प्रदर्शित करेंगे।

इस उदाहरण में, हम पहले उदाहरण की वही Excel वर्कबुक पुनः उपयोग करते हैं, जिसमें एक सरल कर्मचारी तालिका मौजूद है।

```py
# कर्मचारी डेटा वाली Excel वर्कबुक लोड करें।
workbook = slides.excel.ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# नई PowerPoint प्रस्तुति बनाएं।
with slides.Presentation() as presentation:

    # पहले स्लाइड में एक टेबल शेप जोड़ें।
    table = presentation.slides[0].shapes.add_table(
        50, 200,
        [200, 200, 200],
        [30, 30, 30, 30, 30]
    )

    # Excel वर्कबुक से डेटा के साथ PowerPoint टेबल भरें।
    for row_index in range(0, 5):
        for column_index in range(0, 3):
            cell_value = str(workbook.get_cell(worksheet_index, row_index, column_index).value)
            table.columns[column_index][row_index].text_frame.text = cell_value

    # परिणामस्वरूप प्रस्तुति को फ़ाइल में सहेजें।
    presentation.save("Table.pptx", slides.export.SaveFormat.PPTX)
```

![परिणाम](example2_image0.png)

### **Excel चार्ट आयात उदाहरण**

इस उदाहरण में, हम पिछले उदाहरण में उपयोग की गई Excel वर्कबुक की पहली शीट से एक चार्ट आयात करेंगे। परिणामी प्रस्तुति में चार्ट बाहरी वर्कबुक से लिंक रहेगा।

सबसे पहले, हम कर्मचारियों की तालिका के आधार पर Excel वर्कबुक में एक पाई चार्ट जोड़ते हैं।

![Excel चार्ट उदाहरण](example3_image0.png)

```py
# नई PowerPoint प्रस्तुति बनाएं।
with slides.Presentation() as presentation:
    # पहले स्लाइड के शेप संग्रह प्राप्त करें।
    shapes = presentation.slides[0].shapes

    # वर्कबुक की पहली शीट से "Chart 1" नामक चार्ट आयात करें और इसे शेप संग्रह में जोड़ें।
    slides.importing.ExcelWorkbookImporter.add_chart_from_workbook(
        shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", False)

    # परिणामी प्रस्तुति को फ़ाइल में सहेजें।
    presentation.save("Chart.pptx", slides.export.SaveFormat.PPTX)
```

![परिणाम](example3_image1.png)

### **सभी Excel चार्ट आयात उदाहरण**

कल्पना करें कि आपके पास एक Excel वर्कबुक है जिसमें कई चार्ट हैं और आपको उन्हें सभी को प्रस्तुति में आयात करना है। प्रत्येक चार्ट को एक नई स्लाइड पर रखा जाना चाहिए।

निम्न कोड स्रोत Excel फ़ाइल की सभी वर्कशीट्स के माध्यम से क्रमवार चलता है, प्रत्येक वर्कशीट से चार्ट निकालता है, और प्रत्येक चार्ट को एक खाली स्लाइड लेआउट का उपयोग करके अलग‑अलग स्लाइड में जोड़ता है। परिणामी प्रस्तुति में केवल चार्ट डेटा एम्बेड होगा, पूरी वर्कबुक नहीं।

```py
# कर्मचारी डेटा वाली Excel वर्कबुक लोड करें।
workbook = slides.excel.ExcelDataWorkbook("ExcelWithCharts.xlsx")

# नई PowerPoint प्रस्तुति बनाएं।
with slides.Presentation() as presentation:
    # खाली स्लाइड लेआउट प्राप्त करें।
    blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    # Excel वर्कबुक में शामिल सभी वर्कशीटों के नाम प्राप्त करें।
    worksheet_names = workbook.get_worksheet_names()

    for name in worksheet_names:
        # वर्कशीट के लिए चार्ट इंडेक्स को चार्ट नामों से मैप करने वाला शब्दकोश प्राप्त करें।
        worksheet_charts = workbook.get_charts_from_worksheet(name)
        
        for chart in worksheet_charts:
            # खाली लेआउट का उपयोग करके नई स्लाइड जोड़ें।
            slide = presentation.slides.add_empty_slide(blank_layout)

            # निर्दिष्ट चार्ट को Excel वर्कबुक से स्लाइड के शेप संग्रह में आयात करें।
            slides.importing.ExcelWorkbookImporter.add_chart_from_workbook(
                slide.shapes, 10, 10, workbook, name, chart.key, False)

    # परिणामस्वरूप प्रस्तुति को फ़ाइल में सहेजें।
    presentation.save("Charts.pptx", slides.export.SaveFormat.PPTX)
```

## **सारांश**

यह तंत्र, जो सीधे Aspose.Slides में उपलब्ध है, Excel डेटा और प्रस्तुतियों को एक ही स्थान पर संयोजित करता है। यह आपको दृश्यात्मक चार्ट और Excel तालिकाओं के रूप में प्रस्तुत डेटा के साथ स्लाइड बनाने की अनुमति देता है — बिना किसी अतिरिक्त लाइब्रेरी या जटिल एकीकरण के।