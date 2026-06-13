---
title: Excel डेटा को PowerPoint प्रस्तुतियों में एकीकृत करें
linktitle: Excel एकीकरण
type: docs
weight: 330
url: /hi/php-java/excel-integration/
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java का उपयोग करके Excel वर्कबुक से डेटा पढ़ें। शीट्स और सेल्स लोड करें और मानों का उपयोग करके डेटा‑आधारित PowerPoint प्रस्तुतियाँ बनाएं।"
---
## **परिचय**

PowerPoint प्रस्तुतियाँ जानकारी को दिखाने और संवाद करने का एक शक्तिशाली तरीका हैं। इन्हें अक्सर Excel वर्कबुक के साथ उपयोग किया जाता है, जहाँ Excel संरचित डेटा का उत्कृष्ट स्रोत बनता है और PowerPoint उस डेटा को दर्शकों के लिए दृश्यात्मक रूप से प्रस्तुत करने में उत्कृष्ट है।

कई व्यावहारिक परिदृश्य हैं जहाँ Excel और PowerPoint को जोड़ना आवश्यक होता है: मेल मर्ज, डेटा तालिकाओं को भरना, प्रत्येक डेटा रिकॉर्ड के लिए एक स्लाइड बनाना (बैच स्लाइड जेनरेशन), प्रशिक्षण सामग्री बनाना, और कई Excel रिपोर्टों को एक ही प्रस्तुति में समेकित करना, आदि।

अब तक, Aspose.Slides API के साथ ऐसी सुविधाएँ लागू करने के लिए Aspose.Cells जैसे तृतीय‑पक्ष समाधान पर निर्भर होना पड़ता था। जबकि ये उपकरण मजबूत हैं, वे केवल बुनियादी डेटा एकीकरण कार्यक्षमता की आवश्यकता रखने वाले उपयोगकर्ताओं के लिए अत्यधिक जटिल और महंगे हो सकते हैं।

## **यह कैसे काम करता है**

Excel डेटा के साथ काम को सरल और सहज बनाने के लिए, Aspose.Slides ने Excel वर्कबुक से डेटा पढ़ने और सामग्री को प्रस्तुति में आयात करने के लिए नई कक्षाएँ पेश की हैं। यह सुविधा API उपयोगकर्ताओं को प्रस्तुति कार्यप्रवाह में डेटा स्रोत के रूप में Excel का उपयोग करने के नए शक्तिशाली संभावनाएँ खोलती है।

नयी कार्यक्षमता सामान्य‑उद्देश्य डेटा पहुँच के लिए डिज़ाइन की गई है और Presentation Document Object Model (DOM) में एकीकृत नहीं है। इसका अर्थ है *यह Excel फ़ाइलों को संपादित या सहेजने की अनुमति नहीं देता* — इसका एकमात्र उद्देश्य वर्कबुक खोलना और उसकी सामग्री के माध्यम से सेल डेटा प्राप्त करना है।

इस सुविधा के केंद्र में नया [ExcelDataWorkbook](https://reference.aspose.com/slides/hi/php-java/aspose.slides/exceldataworkbook/) क्लास है। यह क्लास आपको स्थानीय फ़ाइल या स्ट्रीम से Excel वर्कबुक लोड करने की अनुमति देता है। लोड होने के बाद यह कई ओवरलोडेड [getCell](https://reference.aspose.com/slides/hi/php-java/aspose.slides/exceldataworkbook/#getCell) मेथड प्रदान करता है, जिनका उपयोग आप स्थिति (जैसे पंक्ति और स्तंभ सूचकांक या नामित रेंज) द्वारा विशिष्ट सेल प्राप्त करने के लिए कर सकते हैं।

प्रत्येक [getCell](https://reference.aspose.com/slides/hi/php-java/aspose.slides/exceldataworkbook/#getCell) कॉल [ExcelDataCell](https://reference.aspose.com/slides/hi/php-java/aspose.slides/exceldatacell/) क्लास का एक उदाहरण लौटाता है। यह ऑब्जेक्ट Excel वर्कबुक में एकल सेल का प्रतिनिधित्व करता है और आपको उसकी वैल्यू को सरल और सहज तरीके से एक्सेस करने देता है।

#### **Excel चार्ट आयात करें**

फ़ंक्शनलिटी का अगला कदम है [ExcelWorkbookImporter](https://reference.aspose.com/slides/hi/php-java/aspose.slides/excelworkbookimporter/) क्लास। यह उपयोगिता क्लास Excel वर्कबुक से सामग्री को प्रस्तुति में आयात करने की सुविधा देती है। इसमें कई ओवरलोडेड [addChartFromWorkbook](https://reference.aspose.com/slides/hi/php-java/aspose.slides/excelworkbookimporter/#addChartFromWorkbook) मेथड शामिल हैं, जो निर्दिष्ट Excel वर्कबुक से चयनित चार्ट को प्राप्त करके निर्दिष्ट निर्देशांक पर दी गई शैप कलेक्शन के अंत में जोड़ते हैं।

संक्षेप में, यह Excel डेटा को पढ़ने के लिए एक हल्का और सीधा API है — वही जो कई डेवलपर्स को पूर्ण स्प्रेडशीट प्रोसेसिंग लाइब्रेरी के ओवरहेड के बिना चाहिए।

## **आइए कोड लिखें**

### **मेल मर्ज परिदृश्य उदाहरण**

निम्नलिखित उदाहरण में हम Excel वर्कबुक में संग्रहीत डेटा के आधार पर कई प्रस्तुतियों को उत्पन्न करके एक सरल मेल मर्ज परिदृश्य को लागू करेंगे।

शुरू करने के लिए हमें दो चीज़ें चाहिए:
1. डेटा वाली एक Excel वर्कबुक

![Excel डेटा उदाहरण](example1_image0.png)

2. PowerPoint प्रस्तुति टेम्पलेट

![PowerPoint टेम्पलेट उदाहरण](example1_image1.png)

```php
// कर्मचारी डेटा के साथ Excel वर्कबुक लोड करें।
$workbook = new ExcelDataWorkbook("TemplateData.xlsx");
$worksheetIndex = 0;

// प्रस्तुति टेम्पलेट लोड करें।
$templatePresentation = new Presentation("PresentationTemplate.pptx");

try {
    // Excel पंक्तियों के माध्यम से लूप करें (पंक्ति 0 पर हेडर को छोड़कर)।
    for ($rowIndex = 1; $rowIndex <= 4; $rowIndex++) {

        // प्रत्येक कर्मचारी रिकॉर्ड के लिए नई प्रस्तुति बनाएं।
        $employeePresentation = new Presentation();

        try {
            // डिफ़ॉल्ट खाली स्लाइड हटाएँ।
            $employeePresentation->getSlides()->removeAt(0);

            // टेम्पलेट स्लाइड को नई प्रस्तुति में क्लोन करें।
            $slide = $employeePresentation->getSlides()->addClone($templatePresentation->getSlides()->get_Item(0));

            // लक्षित आकार से पैराग्राफ प्राप्त करें (मान लिया गया है कि आकार इंडेक्स 1 उपयोग किया गया है)।
            $paragraphs = $slide->getShapes()->get_Item(1)->getTextFrame()->getParagraphs();

            // प्लेसहोल्डर को Excel डेटा से बदलें।
            $employeeName = $workbook->getCell($worksheetIndex, $rowIndex, 0)->getValue()->toString();
            $namePortion = $paragraphs->get_Item(0)->getPortions()->get_Item(0);
            $namePortion->setText($namePortion->getText()->replace("{{EmployeeName}}", $employeeName));

            $department = $workbook->getCell($worksheetIndex, $rowIndex, 1)->getValue()->toString();
            $departmentPortion = $paragraphs->get_Item(1)->getPortions()->get_Item(0);
            $departmentPortion->setText($departmentPortion->getText()->replace("{{Department}}", $department));

            $yearsOfService = $workbook->getCell($worksheetIndex, $rowIndex, 2)->getValue()->toString();
            $yearsPortion = $paragraphs->get_Item(2)->getPortions()->get_Item(0);
            $yearsPortion->setText($yearsPortion->getText()->replace("{{YearsOfService}}", $yearsOfService));

            // व्यक्तिगत प्रस्तुति को एक अलग फ़ाइल में सहेजें।
            $employeePresentation->save(sprintf("%s Report.pptx", $employeeName), SaveFormat::Pptx);
        } finally {
            $employeePresentation->dispose();
        }
    }
} finally {
    $templatePresentation->dispose();
}
```

![परिणाम](example1_image2.png)

### **Excel तालिका उदाहरण**

दूसरे उदाहरण में हम एक Excel तालिका से डेटा कॉपी करके उसे PowerPoint स्लाइड पर अधिक दृश्यात्मक स्वरूप में प्रदर्शित करते हैं।

इस उदाहरण में हम पहले उदाहरण की वही Excel वर्कबुक पुन: उपयोग करते हैं, जिसमें एक सरल कर्मचारी तालिका मौजूद है।

```php
// कर्मचारी डेटा वाली Excel वर्कबुक लोड करें।
$workbook = new ExcelDataWorkbook("TemplateData.xlsx");
$worksheetIndex = 0;

// नई PowerPoint प्रस्तुति बनाएं।
$presentation = new Presentation();

try {
    // पहले स्लाइड में एक टेबल आकार जोड़ें।
    $table = $presentation->getSlides()->get_Item(0)->getShapes()->addTable(
            50, 200,
            array(200, 200, 200),
            array(30, 30, 30, 30, 30)
    );

    // Excel वर्कबुक से डेटा से PowerPoint टेबल भरें।
    for ($rowIndex = 0; $rowIndex < 5; $rowIndex++) {
        for ($columnIndex = 0; $columnIndex < 3; $columnIndex++) {
            $cellValue = $workbook->getCell($worksheetIndex, $rowIndex, $columnIndex)->getValue()->toString();
            $table->getColumns()->get_Item($columnIndex)->get_Item($rowIndex)->getTextFrame()->setText($cellValue);
        }
    }

    // परिणामस्वरूप प्रस्तुति को फ़ाइल में सहेजें।
    $presentation->save("Table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![परिणाम](example2_image0.png)

### **Excel चार्ट आयात उदाहरण**

इस उदाहरण में हम पिछले उदाहरण में उपयोग की गई Excel वर्कबुक की पहली शीट से एक चार्ट आयात करते हैं। परिणामी प्रस्तुति में चार्ट बाहरी वर्कबुक से जुड़ा रहेगा।

पहले, हम कर्मचारियों की तालिका के आधार पर Excel वर्कबुक में एक पाई चार्ट जोड़ते हैं।

![Excel चार्ट उदाहरण](example3_image0.png)

```php
// नई PowerPoint प्रस्तुति बनाएं।
$presentation = new Presentation();
try {
    // पहले स्लाइड के शैप्स कलेक्शन प्राप्त करें।
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    // वर्कबुक की पहली शीट से "Chart 1" नामक चार्ट आयात करें और उसे शैप्स कलेक्शन में जोड़ें।
    ExcelWorkbookImporter::addChartFromWorkbook($shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // परिणामस्वरूप प्रस्तुति को फ़ाइल में सहेजें।
    $presentation->save("Chart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![परिणाम](example3_image1.png)

### **सभी Excel चार्ट आयात उदाहरण**

कल्पना कीजिए आपके पास चार्ट से भरपूर एक Excel वर्कबुक है और आपको सभी चार्ट को प्रस्तुति में आयात करना है। प्रत्येक चार्ट को नई स्लाइड पर रखा जाना चाहिए।

निम्न कोड स्रोत Excel फ़ाइल की सभी वर्कशीट्स के माध्यम से इटररेट करता है, प्रत्येक शीट से चार्ट निकालता है, और प्रत्येक चार्ट को एक खाली स्लाइड लेआउट का उपयोग करके अलग स्लाइड में जोड़ता है। परिणामी प्रस्तुति में केवल चार्ट डेटा एम्बेड होगा, पूरी वर्कबुक नहीं।

```php
// कर्मचारी डेटा वाली Excel वर्कबुक लोड करें।
$workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// नई PowerPoint प्रस्तुति बनाएं।
$presentation = new Presentation();
try {
    // ब्लैंक स्लाइड लेआउट प्राप्त करें.
    $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    // Excel वर्कबुक में शामिल सभी वर्कशीटों के नाम प्राप्त करें.
    $worksheetNames = $workbook->getWorksheetNames()->iterator();

    while (java_values($worksheetNames->hasNext())) {
        $name = $worksheetNames->next();
        // वर्कशीट के लिए चार्ट इंडेक्स को चार्ट नामों से मैप करने वाला मानचित्र प्राप्त करें.
        $worksheetCharts = $workbook->getChartsFromWorksheet($name)->iterator();

        while (java_values($worksheetCharts->hasNext())) {
            $chart = $worksheetCharts->next();
            // ब्लैंक लेआउट का उपयोग करके नई स्लाइड जोड़ें.
            $slide = $presentation->getSlides()->addEmptySlide($blankLayout);

            // निर्दिष्ट चार्ट को Excel वर्कबुक से स्लाइड के शैप्स कलेक्शन में आयात करें.
            ExcelWorkbookImporter::addChartFromWorkbook(
                    $slide->getShapes(), 10, 10, $workbook, $name, $chart->getKey(), false);
        }
    }

    // परिणामी प्रस्तुति को फ़ाइल में सहेजें.
    $presentation->save("Charts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **सारांश**

यह तंत्र, जो सीधे Aspose.Slides में उपलब्ध है, Excel डेटा और प्रस्तुतियों के साथ काम करने को एक ही स्थान पर संयोजित करता है। यह आपको दृश्यात्मक चार्ट और Excel तालिकाओं के रूप में डेटा वाले स्लाइड बनाने की सुविधा देता है — बिना किसी अतिरिक्त लाइब्रेरी या जटिल एकीकरण के।