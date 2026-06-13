---
title: "Excel डेटा को PowerPoint प्रस्तुतियों में एकीकृत करें"
linktitle: "Excel एकीकरण"
type: docs
weight: 330
url: /hi/cpp/excel-integration/
keywords:
- "Excel"
- "वर्कबुक"
- "Excel पढ़ें"
- "Excel एकीकृत करें"
- "डेटा स्रोत"
- "मेल मर्ज"
- "टेबल आयात करें"
- "Excel को PowerPoint में"
- "PowerPoint"
- "प्रस्तुति"
- "C++"
- "Aspose.Slides"
description: "Aspose.Slides में ExcelDataWorkbook API का उपयोग करके Excel वर्कबुक से डेटा पढ़ें। शीट और सेल लोड करें और मानों का उपयोग करके डेटा-प्रवाहित PowerPoint प्रस्तुतियों को उत्पन्न करें।"
---
## **परिचय**

PowerPoint प्रस्तुतियां जानकारी को प्रदर्शित करने और संवाद करने का एक शक्तिशाली तरीका हैं। इन्हें अक्सर Excel वर्कबुक के साथ मिलाकर उपयोग किया जाता है, जहाँ Excel संरचित डेटा का उत्कृष्ट स्रोत है और PowerPoint उस डेटा को दर्शकों के सामने विज़ुअलाइज़ करने में कुशल है।

Excel और PowerPoint को संयोजित करने के कई व्यावहारिक परिदृश्य हैं: मेल मर्ज, डेटा टेबल भरना, प्रत्येक डेटा रिकॉर्ड के लिए एक स्लाइड बनाना (बैच स्लाइड जनरेशन), प्रशिक्षण सामग्री बनाना, और कई Excel रिपोर्टों को एक ही प्रस्तुति में सम्मिलित करना, आदि।

अब तक, Aspose.Slides API के साथ ऐसी सुविधाओं को लागू करने के लिए Aspose.Cells जैसी तृतीय‑ पक्ष समाधान पर निर्भर रहना पड़ता था। जबकि ये उपकरण मजबूत हैं, वे केवल बुनियादी डेटा इंटीग्रेशन कार्यक्षमता की आवश्यकता वाले उपयोगकर्ताओं के लिए अत्यधिक जटिल और महंगे हो सकते हैं।

## **यह कैसे काम करता है**

Excel डेटा के साथ काम करने को आसान और अधिक सुव्यवस्थित बनाने के लिए, Aspose.Slides ने Excel वर्कबुक से डेटा पढ़ने और प्रस्तुति में सामग्री आयात करने के लिए नई क्लासेस पेश की हैं। यह सुविधा API उपयोगकर्ताओं को अपनी प्रस्तुति कार्यप्रवाह में डेटा स्रोत के रूप में Excel का उपयोग करने के लिए शक्तिशाली नई संभावनाएं प्रदान करती है।

नई कार्यक्षमता सामान्य‑उद्देश्य डेटा अभिगम के लिए डिज़ाइन की गई है और Presentation Document Object Model (DOM) में एकीकृत नहीं है। इसका अर्थ है *यह Excel फ़ाइलों को संपादित या सहेजने की अनुमति नहीं देता* — इसका एकमात्र उद्देश्य वर्कबुक खोलना और उसकी सामग्री के माध्यम से नेविगेट करके सेल डेटा प्राप्त करना है।

इस सुविधा के केंद्र में नई [ExcelDataWorkbook](https://reference.aspose.com/slides/hi/cpp/aspose.slides.excel/exceldataworkbook/) क्लास है। यह क्लास आपको स्थानीय फ़ाइल या स्ट्रीम से Excel वर्कबुक लोड करने की अनुमति देती है। लोड होने के बाद, यह कई ओवरलोडेड [GetCell](https://reference.aspose.com/slides/hi/cpp/aspose.slides.excel/exceldataworkbook/getcell/) मेथड प्रदान करती है, जिन्हें आप सेल की स्थिति (जैसे, पंक्ति और कॉलम सूचकांक या नामित रेंज) द्वारा विशिष्ट सेल प्राप्त करने के लिए उपयोग कर सकते हैं।

हर कॉल पर [GetCell](https://reference.aspose.com/slides/hi/cpp/aspose.slides.excel/exceldataworkbook/getcell/) एक [ExcelDataCell](https://reference.aspose.com/slides/hi/cpp/aspose.slides.excel/exceldatacell/) क्लास का उदाहरण लौटाता है। यह ऑब्जेक्ट Excel वर्कबुक में एकल सेल को दर्शाता है और आपको उसकी मान तक सरल और सहज तरीके से पहुंच प्रदान करता है।

#### **एक्सेल चार्ट आयात करें**

फ़ंक्शनैलिटी को आगे बढ़ाने के लिए अगला कदम [ExcelWorkbookImporter](https://reference.aspose.com/slides/hi/cpp/aspose.slides.import/excelworkbookimporter/) क्लास है। यह उपयोगिता क्लास Excel वर्कबुक से सामग्री को प्रस्तुति में आयात करने की सुविधा प्रदान करती है। इसमें कई ओवरलोडेड [AddChartFromWorkbook](https://reference.aspose.com/slides/hi/cpp/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/) मेथड शामिल हैं, जो निर्दिष्ट Excel वर्कबुक से चयनित चार्ट को प्राप्त करके निर्दिष्ट निर्देशांक पर दिए गए शेप कलेक्शन के अंत में जोड़ते हैं।

संक्षेप में, यह Excel डेटा पढ़ने के लिए एक हल्का और सीधा API है — बिल्कुल वही जो कई डेवलपर्स को पूर्ण स्प्रेडशीट प्रोसेसिंग लाइब्रेरी के ओवरहेड के बिना चाहिए।

## **आइए कोड लिखें**

### **मेल मर्ज परिदृश्य उदाहरण**

निम्न उदाहरण में, हम एक सरल मेल मर्ज परिदृश्य को लागू करेंगे, जहाँ Excel वर्कबुक में संग्रहीत डेटा के आधार पर कई प्रस्तुतियां उत्पन्न की जाएँगी।

शुरू करने के लिए हमें दो चीज़ों की आवश्यकता है:
1. डेटा वाले Excel वर्कबुक

![Excel डेटा उदाहरण](example1_image0.png)

2. PowerPoint प्रस्तुति टेम्पलेट

![PowerPoint टेम्पलेट उदाहरण](example1_image1.png)

```cpp
// कर्मचारी डेटा के साथ Excel वर्कबुक लोड करें।
auto workbook = MakeObject<ExcelDataWorkbook>(u"TemplateData.xlsx");
auto worksheetIndex = 0;

// प्रस्तुति टेम्पलेट लोड करें।
auto templatePresentation = MakeObject<Presentation>(u"PresentationTemplate.pptx");

    // Excel पंक्तियों पर घुमाव करें (पंक्ति 0 में हेडर को छोड़कर)।
for (auto rowIndex = 1; rowIndex <= 4; rowIndex++) {

    // प्रत्येक कर्मचारी रिकॉर्ड के लिए नई प्रस्तुति बनाएं।
    auto employeePresentation = MakeObject<Presentation>();

    // डिफ़ॉल्ट खाली स्लाइड हटाएँ।
    employeePresentation->get_Slides()->RemoveAt(0);

    // टेम्पलेट स्लाइड को नई प्रस्तुति में क्लोन करें।
    auto slide = employeePresentation->get_Slides()->AddClone(templatePresentation->get_Slide(0));

    // लक्ष्य आकार से पैराग्राफ प्राप्त करें (मान लिया गया है कि आकार इंडेक्स 1 उपयोग किया जाता है)।
    auto paragraphs = ExplicitCast<IAutoShape>(slide->get_Shape(1))->get_TextFrame()->get_Paragraphs();

    // प्लेसहोल्डर को Excel डेटा से बदलें।
    auto employeeName = workbook->GetCell(worksheetIndex, rowIndex, 0)->get_Value()->ToString();
    auto namePortion = paragraphs->idx_get(0)->get_Portion(0);
    namePortion->set_Text(namePortion->get_Text().Replace(u"{{EmployeeName}}", employeeName));

    auto department = workbook->GetCell(worksheetIndex, rowIndex, 1)->get_Value()->ToString();
    auto departmentPortion = paragraphs->idx_get(1)->get_Portion(0);
    departmentPortion->set_Text(departmentPortion->get_Text().Replace(u"{{Department}}", department));

    auto yearsOfService = workbook->GetCell(worksheetIndex, rowIndex, 2)->get_Value()->ToString();
    auto yearsPortion = paragraphs->idx_get(2)->get_Portion(0);
    yearsPortion->set_Text(yearsPortion->get_Text().Replace(u"{{YearsOfService}}", yearsOfService));

    // व्यक्तिगत प्रस्तुति को अलग फ़ाइल में सहेजें।
    employeePresentation->Save(String::Format(u"{0} Report.pptx", employeeName), SaveFormat::Pptx);
    employeePresentation->Dispose();
}

templatePresentation->Dispose();
```

![परिणाम](example1_image2.png)

### **Excel टेबल उदाहरण**

दूसरे उदाहरण में, हम एक Excel टेबल से डेटा कॉपी करके उसे PowerPoint स्लाइड पर अधिक दृश्यात्मक रूप में प्रदर्शित करेंगे।

इस उदाहरण में, हम पहले उदाहरण के वही Excel वर्कबुक का पुनः उपयोग करते हैं, जिसमें एक सरल कर्मचारी टेबल है।

```cpp
// कर्मचारी डेटा युक्त Excel वर्कबुक लोड करें।
auto workbook = MakeObject<ExcelDataWorkbook>(u"TemplateData.xlsx");
auto worksheetIndex = 0;

// नई PowerPoint प्रस्तुति बनाएं।
auto presentation = MakeObject<Presentation>();

// पहली स्लाइड पर एक टेबल आकार जोड़ें।
auto table = presentation->get_Slide(0)->get_Shapes()->AddTable(
    50, 200,
    MakeArray<double>({200, 200, 200}),
    MakeArray<double>({30, 30, 30, 30, 30})
);

// Excel वर्कबुक से डेटा के साथ PowerPoint टेबल भरें।
for (auto rowIndex = 0; rowIndex < 5; rowIndex++) {
    for (auto columnIndex = 0; columnIndex < 3; columnIndex++) {
        auto cellValue = workbook->GetCell(worksheetIndex, rowIndex, columnIndex)->get_Value()->ToString();
        table->get_Column(columnIndex)->idx_get(rowIndex)->get_TextFrame()->set_Text(cellValue);
    }
}

// परिणामी प्रस्तुति को फ़ाइल में सहेजें।
presentation->Save(u"Table.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![परिणाम](example2_image0.png)

### **एक्सेल चार्ट आयात उदाहरण**

इस उदाहरण में, हम पिछले उदाहरण में उपयोग किए गए Excel वर्कबुक की पहले वर्कशीट से एक चार्ट आयात करेंगे। परिणामस्वरूप प्रस्तुति में चार्ट बाहरी वर्कबुक से लिंक रहेगा।

सबसे पहले, हम कर्मचारियों की टेबल के आधार पर Excel वर्कबुक में एक पाई चार्ट जोड़ते हैं।

![Excel चार्ट उदाहरण](example3_image0.png)

```cpp
// नई PowerPoint प्रस्तुति बनाएं।
auto presentation = MakeObject<Presentation>();

// पहली स्लाइड का आकार संग्रह प्राप्त करें।
auto shapes = presentation->get_Slide(0)->get_Shapes();

// वर्कबुक की पहली शीट से "Chart 1" नामक चार्ट आयात करें और इसे आकार संग्रह में जोड़ें।
ExcelWorkbookImporter::AddChartFromWorkbook(shapes, 10.0, 10.0, u"TemplateData.xlsx", u"Sheet1", u"Chart 1", false);

// परिणामी प्रस्तुति को फ़ाइल में सहेजें।
presentation->Save(u"Chart.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![परिणाम](example3_image1.png)

### **सभी Excel चार्ट आयात उदाहरण**

कल्पना करें कि आपके पास चार्ट्स से भरपूर एक Excel वर्कबुक है और आपको सभी चार्ट्स को प्रस्तुति में आयात करना है। प्रत्येक चार्ट को एक नई स्लाइड पर रखा जाना चाहिए।

निम्न कोड स्रोत Excel फ़ाइल की सभी वर्कशीट्स के माध्यम से इटररेट करता है, प्रत्येक वर्कशीट से चार्ट्स निकालता है, और प्रत्येक चार्ट को एक खाली स्लाइड लेआउट का उपयोग करके अलग स्लाइड में जोड़ता है। परिणामस्वरूप प्रस्तुति में केवल चार्ट डेटा एम्बेड होगा, पूरी वर्कबुक नहीं।

```cpp
// कर्मचारी डेटा युक्त Excel वर्कबुक लोड करें।
auto workbook = MakeObject<ExcelDataWorkbook>(u"ExcelWithCharts.xlsx");

// नई PowerPoint प्रस्तुति बनाएं।
auto presentation = MakeObject<Presentation>();

// खाली स्लाइड लेआउट प्राप्त करें।
auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

// Excel वर्कबुक में मौजूद सभी वर्कशीटों के नाम प्राप्त करें।
auto worksheetNames = workbook->GetWorksheetNames();

for (auto&& name : worksheetNames)
{
    // वर्कशीट के लिए चार्ट अनुक्रमणिका को चार्ट नामों से मैप करने वाला शब्दकोश प्राप्त करें।
    auto worksheetCharts = workbook->GetChartsFromWorksheet(name);

    for (auto&& chart : worksheetCharts)
    {
        // खाली लेआउट का उपयोग करके नई स्लाइड जोड़ें।
        auto slide = presentation->get_Slides()->AddEmptySlide(blankLayout);

        // निर्दिष्ट चार्ट को Excel वर्कबुक से स्लाइड के आकार संग्रह में आयात करें।
        ExcelWorkbookImporter::AddChartFromWorkbook(slide->get_Shapes(), 10.0, 10.0, workbook, name, chart.get_Key(), false);
    }
}

// परिणामस्वरूप प्रस्तुति को फ़ाइल में सहेजें।
presentation->Save(u"Charts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **सारांश**

यह तंत्र, जो सीधे Aspose.Slides में उपलब्ध है, Excel डेटा और प्रस्तुतियों के साथ काम करने को एक ही स्थान पर संयोजित करता है। यह आपको Excel टेबल के रूप में डेटा के साथ दृश्यात्मक चार्ट वाली स्लाइड्स बनाने की अनुमति देता है—बिना किसी अतिरिक्त लाइब्रेरी या जटिल एकीकरण के।