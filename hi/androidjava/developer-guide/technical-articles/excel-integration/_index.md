---
title: Excel डेटा को PowerPoint प्रस्तुतियों में एकीकृत करें
linktitle: Excel एकीकरण
type: docs
weight: 330
url: /hi/androidjava/excel-integration/
keywords:
- Excel
- वर्कबुक
- Excel पढ़ें
- Excel एकीकृत करें
- डेटा स्रोत
- मेल मर्ज
- तालिका आयात करें
- Excel को PowerPoint में
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides में ExcelDataWorkbook API का उपयोग करके Excel वर्कबुक से डेटा पढ़ें। शीट्स और सेल्स लोड करें और मानों का उपयोग करके डेटा‑आधारित PowerPoint प्रस्तुतियों को जनरेट करें।"
---
## **परिचय**

PowerPoint प्रस्तुतियाँ जानकारी को प्रदर्शित करने और संवाद करने का एक शक्तिशाली तरीका हैं। इन्हें अक्सर Excel वर्कबुक के साथ उपयोग किया जाता है, जहाँ Excel संरचित डेटा का उत्कृष्ट स्रोत है और PowerPoint उस डेटा को दर्शकों के लिए दृश्यात्मक बनाता है।

कई व्यावहारिक परिदृश्य हैं जहाँ Excel और PowerPoint को मिलाना आवश्यक है: मेल मर्ज, डेटा तालिकाओं को भरना, प्रत्येक डेटा रिकॉर्ड के लिए एक स्लाइड बनाना (बैच स्लाइड जेनरेशन), प्रशिक्षण सामग्री बनाना, और कई Excel रिपोर्टों को एकल प्रस्तुति में समेकित करना, आदि।

अब तक, Aspose.Slides API के साथ ऐसी सुविधाएँ लागू करने के लिए Aspose.Cells जैसे थर्ड‑पार्टी समाधान पर निर्भर रहना पड़ता था। यद्यपि ये उपकरण मजबूत हैं, वे केवल बुनियादी डेटा एकीकरण कार्यक्षमता की आवश्यकता रखने वाले उपयोगकर्ताओं के लिए अत्यधिक जटिल और महंगे हो सकते हैं।

## **यह कैसे काम करता है**

Excel डेटा के साथ काम को आसान और सुगम बनाने के लिए, Aspose.Slides ने Excel वर्कबुक से डेटा पढ़ने और प्रस्तुति में सामग्री आयात करने के लिए नई कक्षाएँ प्रस्तुत की हैं। यह सुविधा API उपयोगकर्ताओं के लिए नई शक्तिशाली संभावनाएँ खोलती है जो अपने प्रस्तुति कार्यप्रवाह में Excel को डेटा स्रोत के रूप में उपयोग करना चाहते हैं।

यह नई कार्यक्षमता सामान्य‑उद्देश्य डेटा पहुंच के लिए डिज़ाइन की गई है और Presentation Document Object Model (DOM) में एकीकृत नहीं है। इसका अर्थ है *यह Excel फ़ाइलों को संपादित या सहेजने की अनुमति नहीं देता* — इसका एकमात्र उद्देश्य वर्कबुक को खोलना और उनकी सामग्री के माध्यम से नेविगेट करके सेल डेटा प्राप्त करना है।

इस सुविधा के केंद्र में नई [ExcelDataWorkbook](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/exceldataworkbook/) कक्षा है। यह कक्षा स्थानीय फ़ाइल या स्ट्रीम से Excel वर्कबुक लोड करने की अनुमति देती है। लोड होने के बाद, यह [getCell](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/exceldataworkbook/#getCell-int-int-int-) मेथड के कई ओवरलोड प्रदान करती है, जिसका उपयोग आप सेल की स्थिति (जैसे पंक्ति और स्तंभ सूचकांक या नामांकित रेंज) द्वारा विशिष्ट सेल प्राप्त करने के लिए कर सकते हैं।

[getCell](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/exceldataworkbook/#getCell-int-int-int-) की प्रत्येक कॉल [ExcelDataCell](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/exceldatacell/) कक्षा का एक उदाहरण लौटाती है। यह वस्तु Excel वर्कबुक में एकल सेल का प्रतिनिधित्व करती है और आपको उसकी मान तक सरल और सहज तरीके से पहुँच प्रदान करती है।

#### **Excel चार्ट आयात करें**

फ़ंक्शनैलिटी का विस्तार करने का अगला कदम [ExcelWorkbookImporter](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/excelworkbookimporter/) कक्षा है। यह उपयोगिता कक्षा Excel वर्कबुक से प्रस्तुति में सामग्री आयात करने की कार्यक्षमता प्रदान करती है। इसमें [addChartFromWorkbook](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/excelworkbookimporter/#addChartFromWorkbook-com.aspose.slides.IShapeCollection-float-float-com.aspose.slides.IExcelDataWorkbook-java.lang.String-int-boolean-) मेथड के कई ओवरलोड शामिल हैं, जो निर्दिष्ट Excel वर्कबुक से चुने गए चार्ट को पुनः प्राप्त करने और निर्दिष्ट गुणांकों पर दिए गए शेप संग्रह के अंत में जोड़ने में मदद करते हैं।

संक्षेप में, यह Excel डेटा पढ़ने के लिए एक हल्का और सीधा API है — बिल्कुल वही जो कई डेवलपरों को पूरे स्प्रेडशीट प्रोसेसिंग लाइब्रेरी के ओवरहेड के बिना चाहिए।

## **आइए कोड लिखें**

### **मेल मर्ज परिदृश्य उदाहरण**

निम्न उदाहरण में, हम Excel वर्कबुक में संग्रहीत डेटा के आधार पर कई प्रस्तुतियों को उत्पन्न करके एक सरल मेल मर्ज परिदृश्य को लागू करेंगे।

शुरू करने के लिए, हमें दो चीज़ों की आवश्यकता है:
1. डेटा वाले Excel वर्कबुक

![Excel डेटा उदाहरण](example1_image0.png)

2. PowerPoint प्रस्तुति टेम्पलेट

![PowerPoint टेम्पलेट उदाहरण](example1_image1.png)

```java
// कर्मचारी डेटा के साथ Excel वर्कबुक लोड करें।
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// प्रस्तुति टेम्पलेट लोड करें।
Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

try {
    // Excel पंक्तियों के माध्यम से लूप करें (पंक्ति 0 पर हेडर को छोड़कर)।
    for (int rowIndex = 1; rowIndex <= 4; rowIndex++) {

        // प्रत्येक कर्मचारी रिकॉर्ड के लिए नई प्रस्तुति बनाएं।
        Presentation employeePresentation = new Presentation();

        try {
            // डिफ़ॉल्ट खाली स्लाइड हटाएँ।
            employeePresentation.getSlides().removeAt(0);

            // टेम्पलेट स्लाइड को नई प्रस्तुति में क्लोन करें।
            ISlide slide = employeePresentation.getSlides().addClone(templatePresentation.getSlides().get_Item(0));

            // लक्ष्य शैप से पैराग्राफ प्राप्त करें (मान लिया गया है कि शैप सूचकांक 1 उपयोग किया गया है)।
            IParagraphCollection paragraphs = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame().getParagraphs();

            // प्लेसहोल्डर को Excel डेटा से बदलें।
            String employeeName = workbook.getCell(worksheetIndex, rowIndex, 0).getValue().toString();
            IPortion namePortion = paragraphs.get_Item(0).getPortions().get_Item(0);
            namePortion.setText(namePortion.getText().replace("{{EmployeeName}}", employeeName));

            String department = workbook.getCell(worksheetIndex, rowIndex, 1).getValue().toString();
            IPortion departmentPortion = paragraphs.get_Item(1).getPortions().get_Item(0);
            departmentPortion.setText(departmentPortion.getText().replace("{{Department}}", department));

            String yearsOfService = workbook.getCell(worksheetIndex, rowIndex, 2).getValue().toString();
            IPortion yearsPortion = paragraphs.get_Item(2).getPortions().get_Item(0);
            yearsPortion.setText(yearsPortion.getText().replace("{{YearsOfService}}", yearsOfService));

            // व्यक्तिगत प्रस्तुति को अलग फ़ाइल में सहेजें।
            employeePresentation.save(String.format("%s Report.pptx", employeeName), SaveFormat.Pptx);
        } finally {
            employeePresentation.dispose();
        }
    }
} finally {
    templatePresentation.dispose();
}
```

![परिणाम](example1_image2.png)

### **Excel तालिका उदाहरण**

दूसरे उदाहरण में, हम सरलता से Excel तालिका से डेटा कॉपी करते हैं और उसे PowerPoint स्लाइड पर अधिक दृश्यात्मक रूप से आकर्षक फ़ॉर्मेट में प्रदर्शित करते हैं।

इस उदाहरण में, हम पहले उदाहरण की वही Excel वर्कबुक पुनः उपयोग करते हैं, जिसमें एक सरल कर्मचारी तालिका है।

```java
// कर्मचारी डेटा वाली Excel वर्कबुक लोड करें।
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// एक नई PowerPoint प्रस्तुति बनाएं।
Presentation presentation = new Presentation();

try {
    // पहले स्लाइड में एक तालिका आकृति जोड़ें।
    ITable table = presentation.getSlides().get_Item(0).getShapes().addTable(
            50, 200,
            new double[]{200, 200, 200},
            new double[]{30, 30, 30, 30, 30}
    );

    // Excel वर्कबुक से डेटा से PowerPoint तालिका भरें।
    for (int rowIndex = 0; rowIndex < 5; rowIndex++) {
        for (int columnIndex = 0; columnIndex < 3; columnIndex++) {
            String cellValue = workbook.getCell(worksheetIndex, rowIndex, columnIndex).getValue().toString();
            table.getColumns().get_Item(columnIndex).get_Item(rowIndex).getTextFrame().setText(cellValue);
        }
    }

    // परिणामी प्रस्तुति को फ़ाइल में सहेजें।
    presentation.save("Table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![परिणाम](example2_image0.png)

### **Excel चार्ट आयात उदाहरण**

इस उदाहरण में, हम पिछले उदाहरण में उपयोग की गई Excel वर्कबुक के प्रथम कार्यपत्रक से एक चार्ट आयात करते हैं। परिणामस्वरूप प्रस्तुति में वह चार्ट बाहरी वर्कबुक से लिंक होगा।

पहले, हम कर्मचारियों की तालिका के आधार पर Excel वर्कबुक में एक पाई चार्ट जोड़ते हैं।

![Excel चार्ट उदाहरण](example3_image0.png)

```java
// नई PowerPoint प्रस्तुति बनाएं।
Presentation presentation = new Presentation();
try {
    // पहले स्लाइड के आकृतियों का संग्रह प्राप्त करें।
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    // वर्कबुक की पहली शीट से नामित "Chart 1" चार्ट आयात करें और इसे आकृतियों के संग्रह में जोड़ें।
    ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // परिणामी प्रस्तुति को फ़ाइल में सहेजें।
    presentation.save("Chart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![परिणाम](example3_image1.png)

### **सभी Excel चार्ट आयात उदाहरण**

कल्पना करें कि आपके पास चार्ट्स से भरपूर एक Excel वर्कबुक है और आपको उन्हें सभी को प्रस्तुति में आयात करना है। प्रत्येक चार्ट को एक नई स्लाइड पर रखा जाना चाहिए।

निम्न कोड स्रोत Excel फ़ाइल में सभी कार्यपत्रकों के माध्यम से इटरैट करता है, प्रत्येक कार्यपत्रक से चार्ट निकालता है, और प्रत्येक चार्ट को एक खाली स्लाइड लेआउट का उपयोग करके अलग स्लाइड में जोड़ता है। परिणामस्वरूप प्रस्तुति में केवल चार्ट डेटा एम्बेड किया जाएगा, पूर्ण वर्कबुक नहीं।

```java
// कर्मचारी डेटा वाली Excel वर्कबुक लोड करें।
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// एक नई PowerPoint प्रस्तुति बनाएं।
Presentation presentation = new Presentation();
try {
    // खाली स्लाइड लेआउट प्राप्त करें।
    ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // Excel वर्कबुक में शामिल सभी कार्यपत्रकों के नाम प्राप्त करें।
    List<String> worksheetNames = workbook.getWorksheetNames();

    for (String name : worksheetNames) {
        // कार्यपत्रक के लिए चार्ट अनुक्रमांक को चार्ट नामों से मिलाने वाला मानचित्र प्राप्त करें।
        Dictionary<Integer, String> worksheetCharts = workbook.getChartsFromWorksheet(name);

        for (KeyValuePair<Integer, String> chart : worksheetCharts) {
            // खाली लेआउट का उपयोग करके नई स्लाइड जोड़ें।
            ISlide slide = presentation.getSlides().addEmptySlide(blankLayout);

            // निर्दिष्ट चार्ट को Excel वर्कबुक से स्लाइड की आकृतियों संग्रह में आयात करें।
            ExcelWorkbookImporter.addChartFromWorkbook(
                    slide.getShapes(), 10, 10, workbook, name, chart.getKey(), false);
        }
    }

    // परिणामी प्रस्तुति को फ़ाइल में सहेजें।
    presentation.save("Charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **सारांश**

यह तंत्र, जो सीधे Aspose.Slides में उपलब्ध है, Excel डेटा और प्रस्तुतियों के साथ एक ही जगह काम करने को संयोजित करता है। यह आपको दृश्यात्मक चार्ट और Excel तालिकाओं के रूप में प्रस्तुत डेटा के साथ स्लाइड बनाने की अनुमति देता है - बिना किसी अतिरिक्त लाइब्रेरी या जटिल एकीकरण के।