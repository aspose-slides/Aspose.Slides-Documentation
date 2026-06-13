---
title: Excel डेटा को PowerPoint प्रस्तुतियों में एकीकृत करें
linktitle: Excel एकीकरण
type: docs
weight: 330
url: /hi/nodejs-java/excel-integration/
keywords:
- एक्सेल
- कार्यपुस्तिका
- एक्सेल पढ़ें
- एक्सेल एकीकृत करें
- डेटा स्रोत
- मेल मर्ज
- तालिका आयात
- एक्सेल को PowerPoint में
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides के साथ JavaScript में एक्सेल कार्यपुस्तिकाओं से डेटा पढ़ें। शीट और सेल लोड करें और मानों का उपयोग करके डेटा-चालित PowerPoint प्रस्तुतियों का निर्माण करें।"
---
## **परिचय**

PowerPoint प्रस्तुतियाँ जानकारी को प्रदर्शित करने और संप्रेषित करने का एक शक्तिशाली तरीका हैं। इन्हें अक्सर Excel कार्यपुस्तिकाओं के साथ उपयोग किया जाता है, जहाँ Excel संरचित डेटा का उत्कृष्ट स्रोत है और PowerPoint दर्शकों के लिए उस डेटा को दृश्य रूप में प्रस्तुत करने में उत्कृष्ट है।

Excel और PowerPoint को मिलाकर उपयोग करने के कई व्यावहारिक परिदृश्य हैं: मेल मर्ज, डेटा तालिकाओं को भरना, प्रत्येक डेटा रिकॉर्ड के लिए एक स्लाइड बनाना (बैच स्लाइड जनरेशन), प्रशिक्षण सामग्री बनाना, और कई Excel रिपोर्टों को एक ही प्रस्तुति में समेकित करना, आदि।

अब तक, Aspose.Slides API के साथ इन सुविधाओं को लागू करने के लिए Aspose.Cells जैसे तृतीय‑पक्ष समाधान पर निर्भर रहना पड़ता था। जबकि ये उपकरण मजबूत हैं, वे केवल बुनियादी डेटा इंटीग्रेशन कार्यक्षमता की आवश्यकता वाले उपयोगकर्ताओं के लिए अत्यधिक जटिल और महंगे हो सकते हैं।

## **यह कैसे काम करता है**

Excel डेटा के साथ काम करना आसान और अधिक सुगम बनाने के लिए, Aspose.Slides ने Excel कार्यपुस्तिकाओं से डेटा पढ़ने और प्रस्तुति में सामग्री आयात करने के लिए नई कक्षाएँ प्रस्तुत की हैं। यह सुविधा API उपयोगकर्ताओं के लिए नई शक्तिशाली संभावनाएँ खोलती है जो अपने प्रस्तुति कार्यप्रवाह में डेटा स्रोत के रूप में Excel का उपयोग करना चाहते हैं।

नई कार्यक्षमता को सामान्य‑उद्देश्य डेटा एक्सेस के लिए डिज़ाइन किया गया है और यह Presentation Document Object Model (DOM) में एकीकृत नहीं है। इसका मतलब है *कि यह Excel फ़ाइलों को संपादित या सहेजने की अनुमति नहीं देता* — इसका एकमात्र उद्देश्य कार्यपुस्तिकाओं को खोलना और उनकी सामग्री के माध्यम से नेविगेट करके सेल डेटा प्राप्त करना है।

इस सुविधा के मूल में नई [ExcelDataWorkbook](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/exceldataworkbook/) कक्षा है। यह कक्षा आपको स्थानीय फ़ाइल या स्ट्रीम से Excel कार्यपुस्तिका लोड करने की अनुमति देती है। एक बार लोड हो जाने पर, यह [getCell](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/exceldataworkbook/#getCell) मेथड के कई ओवरलोड प्रदान करती है, जिसका उपयोग आप उनकी स्थिति (जैसे पंक्ति और स्तंभ संकेतांक या नामित रेंज) के आधार पर विशिष्ट सेल प्राप्त करने के लिए कर सकते हैं।

प्रत्येक बार जब आप [getCell](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/exceldataworkbook/#getCell) को कॉल करते हैं, तो यह [ExcelDataCell](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/exceldatacell/) कक्षा की एक इंस्टेंस लौटाता है। यह ऑब्जेक्ट Excel कार्यपुस्तिका में एकल सेल का प्रतिनिधित्व करता है और आपको उसके मान तक सरल और सहज तरीके से पहुँच प्रदान करता है।

#### **एक Excel चार्ट आयात करें**

कार्यात्मकता का विस्तार करने के अगले चरण में [ExcelWorkbookImporter](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/excelworkbookimporter/) कक्षा है। यह सहायक कक्षा Excel कार्यपुस्तिका से सामग्री को प्रस्तुति में आयात करने की कार्यक्षमता प्रदान करती है। इसमें [addChartFromWorkbook](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/excelworkbookimporter/#addChartFromWorkbook) मेथड के कई ओवरलोड शामिल हैं, जो आपको निर्दिष्ट Excel कार्यपुस्तिका से चयनित चार्ट प्राप्त करने और निर्दिष्ट निर्देशांक पर दिए गए शेप कलेक्शन के अंत में जोड़ने में सहायता करते हैं।

संक्षेप में, यह Excel डेटा पढ़ने के लिए एक हल्का और सीधा API है — वही जो कई डेवलपर्स को पूर्ण स्प्रेडशीट प्रोसेसिंग लाइब्रेरी के ओवरहेड के बिना चाहिए।

## **आइए कोड लिखें**

### **मेल मर्ज परिदृश्य उदाहरण**

निम्नलिखित उदाहरण में, हम एक सरल मेल मर्ज परिदृश्य को लागू करेंगे, जहाँ Excel कार्यपुस्तिका में संग्रहीत डेटा के आधार पर कई प्रस्तुतियाँ जनरेट की जाएँगी।

शुरू करने के लिए, हमें दो चीज़ों की आवश्यकता है:
1. डेटा युक्त एक Excel कार्यपुस्तिका

![Excel डेटा उदाहरण](example1_image0.png)

2. PowerPoint प्रस्तुति टेम्प्लेट

![PowerPoint टेम्पलेट उदाहरण](example1_image1.png)

```js
// कर्मचारी डेटा के साथ Excel कार्यपुस्तिका लोड करें।
let workbook = new aspose.slides.ExcelDataWorkbook("TemplateData.xlsx");
const worksheetIndex = 0;

// प्रस्तुति टेम्प्लेट लोड करें।
let templatePresentation = new aspose.slides.Presentation("PresentationTemplate.pptx");

try {
    // Excel पंक्तियों पर लूप करें (पंक्ति 0 पर हेडर को छोड़कर)।
    for (let rowIndex = 1; rowIndex <= 4; rowIndex++) {

        // प्रत्येक कर्मचारी रिकॉर्ड के लिए नई प्रस्तुति बनाएं।
        let employeePresentation = new aspose.slides.Presentation();

        try {
            // डिफ़ॉल्ट खाली स्लाइड हटाएँ।
            employeePresentation.getSlides().removeAt(0);

            // टेम्प्लेट स्लाइड को नई प्रस्तुति में क्लोन करें।
            let slide = employeePresentation.getSlides().addClone(templatePresentation.getSlides().get_Item(0));

            // लक्ष्य शीप से पैराग्राफ प्राप्त करें (मानते हैं कि शेप इंडेक्स 1 उपयोग किया गया है)।
            let paragraphs = slide.getShapes().get_Item(1).getTextFrame().getParagraphs();

            // प्लेसहोल्डर को Excel डेटा से बदलें।
            let employeeName = workbook.getCell(worksheetIndex, rowIndex, 0).getValue().toString();
            let namePortion = paragraphs.get_Item(0).getPortions().get_Item(0);
            namePortion.setText(namePortion.getText().replace("{{EmployeeName}}", employeeName));

            let department = workbook.getCell(worksheetIndex, rowIndex, 1).getValue().toString();
            let departmentPortion = paragraphs.get_Item(1).getPortions().get_Item(0);
            departmentPortion.setText(departmentPortion.getText().replace("{{Department}}", department));

            let yearsOfService = workbook.getCell(worksheetIndex, rowIndex, 2).getValue().toString();
            let yearsPortion = paragraphs.get_Item(2).getPortions().get_Item(0);
            yearsPortion.setText(yearsPortion.getText().replace("{{YearsOfService}}", yearsOfService));

            // व्यक्तिगत प्रस्तुति को एक अलग फ़ाइल में सहेजें।
            employeePresentation.save(`${employeeName} Report.pptx`, aspose.slides.SaveFormat.Pptx);
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

दूसरे उदाहरण में, हम केवल Excel तालिका से डेटा कॉपी करके इसे PowerPoint स्लाइड पर अधिक दृश्यात्मक रूप में प्रदर्शित करते हैं।

इस उदाहरण में, हम पहले उदाहरण की वही Excel कार्यपुस्तिका पुनः उपयोग करते हैं, जिसमें एक सरल कर्मचारी तालिका है।

```js
// कर्मचारी डेटा वाली Excel कार्यपुस्तिका लोड करें।
let workbook = new aspose.slides.ExcelDataWorkbook("TemplateData.xlsx");
const worksheetIndex = 0;

// नई PowerPoint प्रस्तुति बनाएं।
let presentation = new aspose.slides.Presentation();

try {
    // पहली स्लाइड में तालिका आकार जोड़ें।
    let table = presentation.getSlides().get_Item(0).getShapes().addTable(
            50, 200,
            java.newArray("double", [200, 200, 200]),
            java.newArray("double", [30, 30, 30, 30, 30])
    );

    // Excel कार्यपुस्तिका से डेटा के साथ PowerPoint तालिका भरें।
    for (let rowIndex = 0; rowIndex < 5; rowIndex++) {
        for (let columnIndex = 0; columnIndex < 3; columnIndex++) {
            let cellValue = workbook.getCell(worksheetIndex, rowIndex, columnIndex).getValue().toString();
            table.getColumns().get_Item(columnIndex).get_Item(rowIndex).getTextFrame().setText(cellValue);
        }
    }

    // परिणामस्वरूप प्रस्तुति को फ़ाइल में सहेजें।
    presentation.save("Table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![परिणाम](example2_image0.png)

### **Excel चार्ट आयात उदाहरण**

इस उदाहरण में, हम पिछले उदाहरण में उपयोग की गई Excel कार्यपुस्तिका की पहली कार्यपत्रिका से एक चार्ट आयात करते हैं। परिणामस्वरूप प्रस्तुति में चार्ट बाहरी कार्यपुस्तिका से जुड़ा रहेगा।

सबसे पहले, हम कर्मचारियों की तालिका के आधार पर Excel कार्यपुस्तिका में एक पाई चार्ट जोड़ते हैं।

![Excel चार्ट उदाहरण](example3_image0.png)

```js
// नई PowerPoint प्रस्तुति बनाएं।
let presentation = new aspose.slides.Presentation();
try {
    // पहली स्लाइड का शेप कलेक्शन प्राप्त करें।
    let shapes = presentation.getSlides().get_Item(0).getShapes();

    // कार्यपुस्तिका की पहली शीट से "Chart 1" नामक चार्ट आयात करें और उसे शेप कलेक्शन में जोड़ें।
    aspose.slides.ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // परिणामस्वरूप प्रस्तुति को फ़ाइल में सहेजें।
    presentation.save("Chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![परिणाम](example3_image1.png)

### **सभी Excel चार्ट आयात उदाहरण**

कल्पना करें कि आपके पास चार्ट से भरी हुई एक Excel कार्यपुस्तिका है और आपको सभी चार्ट को एक प्रस्तुति में आयात करना है। प्रत्येक चार्ट को एक नई स्लाइड पर रखा जाना चाहिए।

निम्नलिखित कोड स्रोत Excel फ़ाइल की सभी कार्यपत्रिकाओं पर क्रमबद्ध करता है, प्रत्येक कार्यपत्रिका से चार्ट निकालता है, और प्रत्येक चार्ट को एक खाली स्लाइड लेआउट का उपयोग करके अलग स्लाइड में जोड़ता है। परिणामी प्रस्तुति में केवल चार्ट डेटा एम्बेड होगा, पूरी कार्यपुस्तिका नहीं।

```js
// कर्मचारी डेटा वाली Excel कार्यपुस्तिका लोड करें।
let workbook = new aspose.slides.ExcelDataWorkbook("ExcelWithCharts.xlsx");

// नई PowerPoint प्रस्तुति बनाएं।
let presentation = new aspose.slides.Presentation();
try {
    // खाली स्लाइड लेआउट प्राप्त करें।
    let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);

    // Excel कार्यपुस्तिका में मौजूद सभी कार्यपत्रिकाओं के नाम प्राप्त करें।
    let worksheetNames = workbook.getWorksheetNames().iterator();

    while (worksheetNames.hasNext()) {
        let name = worksheetNames.next();
        // कार्यपत्रिका के लिए चार्ट सूचकांकों को चार्ट नामों से मानचित्रित करने वाला मैप प्राप्त करें।
        let worksheetCharts = workbook.getChartsFromWorksheet(name).iterator();

        while (worksheetCharts.hasNext()) {
            let chart = worksheetCharts.next();
            // खाली लेआउट का उपयोग कर नई स्लाइड जोड़ें।
            let slide = presentation.getSlides().addEmptySlide(layoutSlide);

            // निर्दिष्ट चार्ट को Excel कार्यपुस्तिका से स्लाइड के शेप कलेक्शन में आयात करें।
            aspose.slides.ExcelWorkbookImporter.addChartFromWorkbook(
                    slide.getShapes(), 10, 10, workbook, name, chart.getKey(), false);
        }
    }

    // परिणामी प्रस्तुति को फ़ाइल में सहेजें।
    presentation.save("Charts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **सारांश**

यह तंत्र, जो सीधे Aspose.Slides में उपलब्ध है, Excel डेटा और प्रस्तुतियों के साथ काम करने को एक ही स्थान पर संयोजित करता है। यह आपको दृश्यात्मक चार्ट और Excel तालिकाओं के रूप में प्रस्तुत डेटा के साथ स्लाइड बनाने की अनुमति देता है - बिना किसी अतिरिक्त लाइब्रेरी या जटिल इंटीग्रेशन के।