---
title: PowerPoint प्रस्तुतियों में Excel डेटा को एकीकृत करें
linktitle: Excel एकीकरण
type: docs
weight: 330
url: /hi/net/excel-integration/
keywords:
- Excel
- वर्कबुक
- Excel पढ़ें
- Excel को एकीकृत करें
- डेटा स्रोत
- मेल मर्ज
- तालिका आयात करें
- Excel को PowerPoint में
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides में ExcelDataWorkbook API का उपयोग करके Excel वर्कबुक्स से डेटा पढ़ें। शीट्स और सेल्स को लोड करें और मानों का उपयोग करके डेटा-आधारित PowerPoint प्रस्तुतियों को जनरेट करें।"
---
## **परिचय**

PowerPoint प्रस्तुतियाँ जानकारी को प्रदर्शित करने और संप्रेषित करने का एक शक्तिशाली तरीका हैं। इन्हें अक्सर Excel वर्कबुक्स के साथ मिलाकर उपयोग किया जाता है, जहाँ Excel संरचित डेटा का उत्कृष्ट स्रोत है और PowerPoint दर्शकों के लिए उस डेटा को दृश्य रूप में प्रस्तुत करने में उत्कृष्ट है।

Excel और PowerPoint को मिलाकर उपयोग करने के कई व्यावहारिक परिदृश्य हैं: मेल मर्ज, डेटा तालिकाओं को भरना, प्रत्येक डेटा रिकॉर्ड के लिए एक स्लाइड जनरेट करना (बैच स्लाइड जनरेशन), प्रशिक्षण सामग्री बनाना, और कई Excel रिपोर्ट्स को एकल प्रस्तुति में समेकित करना, आदि।

अब तक, ऐसे फीचर्स को Aspose.Slides API के साथ लागू करने के लिए Aspose.Cells जैसे तृतीय-पक्ष समाधान पर निर्भर रहना पड़ता था। जबकि ये उपकरण मज़बूत हैं, वे केवल बुनियादी डेटा एकीकरण कार्यक्षमता की आवश्यकता रखने वाले उपयोगकर्ताओं के लिए अत्यधिक जटिल और महंगे हो सकते हैं।

## **यह कैसे काम करता है**

Excel डेटा के साथ काम करना आसान और सहज बनाने के लिए, Aspose.Slides ने Excel वर्कबुक से डेटा पढ़ने और प्रस्तुति में सामग्री आयात करने के लिए नई क्लासेज़ पेश की हैं। यह सुविधा API उपयोगकर्ताओं को अपनी प्रस्तुति वर्कफ़्लो में डेटा स्रोत के रूप में Excel का उपयोग करने के लिए नई शक्तिशाली संभावनाएँ खोलती है।

नई कार्यक्षमता सामान्य उद्देश्य डेटा पहुँच के लिए डिज़ाइन की गई है और Presentation Document Object Model (DOM) में एकीकृत नहीं है। इसका अर्थ है *यह Excel फ़ाइलों को संपादित या सेव नहीं कर सकती* — इसका एकमात्र उद्देश्य वर्कबुक को खोलना और उसकी सामग्री के माध्यम से नेविगेट करके सेल डेटा प्राप्त करना है।

इस सुविधा का मूल नया [ExcelDataWorkbook](https://reference.aspose.com/slides/hi/net/aspose.slides.excel/exceldataworkbook/) क्लास है। यह क्लास आपको स्थानीय फ़ाइल या स्ट्रीम से Excel वर्कबुक लोड करने की अनुमति देती है। लोड होने के बाद, यह कई ओवरलोड्स के साथ [GetCell](https://reference.aspose.com/slides/hi/net/aspose.slides.excel/exceldataworkbook/getcell/) मेथड प्रदान करता है, जिससे आप स्थिति (जैसे, पंक्ति और स्तंभ इंडेक्स या नामित रेंज) के आधार पर विशिष्ट सेल्स प्राप्त कर सकते हैं।

[GetCell](https://reference.aspose.com/slides/hi/net/aspose.slides.excel/exceldataworkbook/getcell/) के प्रत्येक कॉल से [ExcelDataCell](https://reference.aspose.com/slides/hi/net/aspose.slides.excel/exceldatacell/) क्लास का एक इंस्टेंस प्राप्त होता है। यह ऑब्जेक्ट Excel वर्कबुक में एकल सेल का प्रतिनिधित्व करता है और आपको उसके मान तक सरल और सहज तरीके से पहुंच प्रदान करता है।

#### **Excel चार्ट आयात करना**

फ़ंक्शनैलिटी को विस्तारित करने का अगला कदम [ExcelWorkbookImporter](https://reference.aspose.com/slides/hi/net/aspose.slides.import/excelworkbookimporter/) क्लास है। यह युटिलिटी क्लास Excel वर्कबुक से सामग्री को प्रस्तुति में आयात करने की सुविधा देती है। इसमें कई ओवरलोड्स वाले [AddChartFromWorkbook](https://reference.aspose.com/slides/hi/net/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/) मेथड शामिल हैं, जो निर्दिष्ट Excel वर्कबुक से चयनित चार्ट को प्राप्त करके दिए गए आकार संग्रह के अंत में निर्दिष्ट निर्देशांक पर जोड़ते हैं।

संक्षेप में, यह Excel डेटा पढ़ने के लिए एक हल्का और सरल API है — बिल्कुल वही जो कई डेवलपर्स को पूरी स्प्रेडशीट प्रोसेसिंग लाइब्रेरी के ओवरहेड के बिना चाहिए।

## **आइए कोड लिखें**

### **मेल मर्ज परिदृश्य उदाहरण**

नीचे दिए गए उदाहरण में, हम एक साधारण मेल मर्ज परिदृश्य को लागू करेंगे, जिसमें Excel वर्कबुक में संचित डेटा के आधार पर कई प्रस्तुतियाँ बनेंगे।

शुरू करने के लिए हमें दो चीज़ों की आवश्यकता है:
1. डेटा वाला Excel वर्कबुक

![Excel data example](example1_image0.png)

2. PowerPoint प्रस्तुति टेम्पलेट

![PowerPoint template example](example1_image1.png)

```csharp
// कर्मचारी डेटा वाले Excel वर्कबुक को लोड करें।
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// प्रस्तुति टेम्पलेट को लोड करें।
using Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

// Excel पंक्तियों (पंक्ति 0 पर हेडर को छोड़कर) के माध्यम से लूप करें।
for (int rowIndex = 1; rowIndex <= 4; rowIndex++)
{
    // प्रत्येक कर्मचारी रिकॉर्ड के लिए नई प्रस्तुति बनाएं।
    using Presentation employeePresentation = new Presentation();

    // डिफ़ॉल्ट खाली स्लाइड हटाएं।
    employeePresentation.Slides.RemoveAt(0);

    // टेम्पलेट स्लाइड को नई प्रस्तुति में क्लोन करें।
    ISlide slide = employeePresentation.Slides.AddClone(templatePresentation.Slides[0]);

    // लक्ष्य आकृति से पैराग्राफ प्राप्त करें (मान लेते हैं कि shape इंडेक्स 1 उपयोग किया गया है)।
    IParagraphCollection paragraphs = (slide.Shapes[1] as IAutoShape).TextFrame.Paragraphs;

    // प्लेसहोल्डरों को Excel के डेटा से बदलें।
    string employeeName = workbook.GetCell(worksheetIndex, rowIndex, 0).Value.ToString();
    IPortion namePortion = paragraphs[0].Portions[0];
    namePortion.Text = namePortion.Text.Replace("{{EmployeeName}}", employeeName);

    string department = workbook.GetCell(worksheetIndex, rowIndex, 1).Value.ToString();
    IPortion departmentPortion = paragraphs[1].Portions[0];
    departmentPortion.Text = departmentPortion.Text.Replace("{{Department}}", department);

    string yearsOfService = workbook.GetCell(worksheetIndex, rowIndex, 2).Value.ToString();
    IPortion yearsPortion = paragraphs[2].Portions[0];
    yearsPortion.Text = yearsPortion.Text.Replace("{{YearsOfService}}", yearsOfService);

    // व्यक्तिगत प्रस्तुति को अलग फ़ाइल में सहेजें।
    employeePresentation.Save($"{employeeName} Report.pptx", SaveFormat.Pptx);
}
```

![Result](example1_image2.png)

### **Excel तालिका उदाहरण**

दूसरे उदाहरण में, हम केवल Excel तालिका से डेटा कॉपी करके उसे PowerPoint स्लाइड पर अधिक दृश्य रूप में प्रदर्शित करेंगे।

इस उदाहरण में, हम पहले उदाहरण की वही Excel वर्कबुक का पुनः उपयोग करते हैं, जिसमें एक सरल कर्मचारी तालिका है।

```csharp
// कर्मचारी डेटा वाली Excel वर्कबुक को लोड करें।
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// नई PowerPoint प्रस्तुति बनाएं।
using Presentation presentation = new Presentation();

// पहली स्लाइड में एक तालिका आकृति जोड़ें।
ITable table = presentation.Slides[0].Shapes.AddTable(
    50, 200,
    new double[] { 200, 200, 200 },
    new double[] { 30, 30, 30, 30, 30 }
);

// Excel वर्कबुक से डेटा के साथ PowerPoint तालिका भरें।
for (int rowIndex = 0; rowIndex < 5; rowIndex++)
{
    for (int columnIndex = 0; columnIndex < 3; columnIndex++)
    {
        string cellValue = workbook.GetCell(worksheetIndex, rowIndex, columnIndex).Value.ToString();
        table[columnIndex, rowIndex].TextFrame.Text = cellValue;
    }
}

// परिणामी प्रस्तुति को फ़ाइल में सहेजें।
presentation.Save("Table.pptx", SaveFormat.Pptx);
```

![Result](example2_image0.png)

### **Excel चार्ट आयात उदाहरण**

इस उदाहरण में, हम पिछले उदाहरण में उपयोग की गई Excel वर्कबुक की पहली वर्कशीट से एक चार्ट आयात करेंगे। परिणामस्वरूप प्रस्तुति में चार्ट बाहरी वर्कबुक से जुड़ा रहेगा।

पहले, हम कर्मचारियों की तालिका के आधार पर Excel वर्कबुक में एक पाई चार्ट जोड़ते हैं।

![Excel Chart example](example3_image0.png)

```csharp
// नई PowerPoint प्रस्तुति बनाएं।
using Presentation presentation = new Presentation();

// पहली स्लाइड की आकृतियों का संग्रह प्राप्त करें।
IShapeCollection shapes = presentation.Slides[0].Shapes;

// वर्कबुक के पहले शीट से "Chart 1" नामक चार्ट आयात करें और इसे आकृतियों के संग्रह में जोड़ें।
ExcelWorkbookImporter.AddChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

// परिणामी प्रस्तुति को फ़ाइल में सहेजें।
presentation.Save("Chart.pptx", SaveFormat.Pptx);
```
![Result](example3_image1.png)

### **सभी Excel चार्ट आयात उदाहरण**

कल्पना करें कि आपके पास चार्ट्स से भरपूर एक Excel वर्कबुक है और आपको सभी चार्ट्स को प्रस्तुति में आयात करना है। प्रत्येक चार्ट को नई स्लाइड पर रखा जाना चाहिए।

नीचे दिया गया कोड स्रोत Excel फ़ाइल की सभी वर्कशीट्स पर इटरैट करता है, प्रत्येक वर्कशीट से चार्ट निकालता है, और प्रत्येक चार्ट को एक अलग स्लाइड में खाली स्लाइड लेआउट का उपयोग करके जोड़ता है। परिणामी प्रस्तुति में केवल चार्ट डेटा एंबेड होगा, पूरी वर्कबुक नहीं।

```csharp
// कर्मचारी डेटा वाली Excel वर्कबुक को लोड करें।
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// नई PowerPoint प्रस्तुति बनाएं।
using Presentation presentation = new Presentation();

// खाली स्लाइड लेआउट प्राप्त करें.
ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

// Excel वर्कबुक में शामिल सभी वर्कशीट्स के नाम प्राप्त करें.
IList<string> worksheetNames = workbook.GetWorksheetNames();

foreach (var name in worksheetNames)
{
    // वर्कशीट के लिए चार्ट इंडेक्स को चार्ट नामों से मैप करने वाला शब्दकोश प्राप्त करें.
    IDictionary<int, string> worksheetCharts = workbook.GetChartsFromWorksheet(name);
    foreach (var chart in worksheetCharts)
    {
        // खाली लेआउट का उपयोग करके नई स्लाइड जोड़ें.
        ISlide slide = presentation.Slides.AddEmptySlide(blankLayout);

        // निर्दिष्ट चार्ट को Excel वर्कबुक से स्लाइड की आकृतियों के संग्रह में आयात करें.
        ExcelWorkbookImporter.AddChartFromWorkbook(slide.Shapes, 10, 10, workbook, name, chart.Key, false);
    }
}

// परिणामी प्रस्तुति को फ़ाइल में सहेजें.
presentation.Save("Charts.pptx", SaveFormat.Pptx);
```

## **सारांश**

यह तंत्र, जो सीधे Aspose.Slides में उपलब्ध है, Excel डेटा और प्रस्तुतियों को एक ही स्थान पर मिलाता है। यह आपको दृश्य चार्ट और Excel तालिकाओं के रूप में डेटा के साथ स्लाइड बनाने की अनुमति देता है — बिना किसी अतिरिक्त लाइब्रेरी या जटिल एकीकरण के।