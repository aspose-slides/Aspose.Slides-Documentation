---
title: PowerPoint प्रस्तुतियों में Excel डेटा एकीकृत करें
linktitle: Excel एकीकरण
type: docs
weight: 330
url: /hi/net/excel-integration/
aliases:
  - /net/developer-guide/technical-articles/excel-integration/
keywords:
- Excel
- वर्कबुक
- Excel पढ़ें
- Excel एकीकृत करें
- डेटा स्रोत
- मेल मर्ज
- टेबल आयात
- Excel को PowerPoint में
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides में ExcelDataWorkbook API का उपयोग करके Excel वर्कबुक से डेटा पढ़ें। शीट्स और सेल्स लोड करें और मानों का उपयोग करके डेटा‑चालित PowerPoint प्रस्तुतियों का निर्माण करें।"
---
## **परिचय**

PowerPoint प्रस्तुतियाँ जानकारी प्रदर्शित करने और संप्रेषित करने का एक प्रभावी तरीका हैं। इन्हें अक्सर Excel वर्कबुक के साथ उपयोग किया जाता है, जहाँ Excel संरचित डेटा का उत्कृष्ट स्रोत बनता है और PowerPoint दर्शकों के लिए उस डेटा को विज़ुअलाइज़ करने में उत्कृष्ट होता है।

Excel और PowerPoint को मिलाकर उपयोग करने के कई व्यावहारिक परिदृश्य हैं: मेल मर्ज, डेटा टेबल्स को भरना, प्रत्येक डेटा रिकॉर्ड के लिए एक स्लाइड बनाना (बैच स्लाइड जनरेशन), प्रशिक्षण सामग्री बनाना, और कई Excel रिपोर्ट्स को एक ही प्रस्तुति में मिलाना, आदि।

अब तक, Aspose.Slides API के साथ ऐसी सुविधाएँ लागू करने के लिए Aspose.Cells जैसी तृतीय‑पक्षीय समाधान पर निर्भर होना पड़ता था। जबकि ये उपकरण मजबूत हैं, वे केवल बुनियादी डेटा इंटीग्रेशन कार्यक्षमता चाहिए वाले उपयोगकर्ताओं के लिए अत्यधिक जटिल और महंगे हो सकते हैं।

## **यह कैसे काम करता है**

Excel डेटा को अधिक सरल और सहज बनाने के लिए, Aspose.Slides ने Excel वर्कबुक से डेटा पढ़ने और प्रस्तुति में सामग्री आयात करने के नए क्लासेस पेश किए हैं। यह फीचर API उपयोगकर्ताओं को अपने प्रस्तुति वर्कफ़्लो में डेटा स्रोत के रूप में Excel का उपयोग करने के नए शक्तिशाली अवसर प्रदान करता है।

नया कार्यक्षमता सामान्य‑उद्देश्य डेटा पहुंच के लिए डिज़ाइन किया गया है और Presentation Document Object Model (DOM) में एकीकृत नहीं है। इसका मतलब है *यह Excel फ़ाइलों को संपादित या सहेजने की अनुमति नहीं देता* — इसका एकमात्र उद्देश्य वर्कबुक खोलना और उसकी सामग्री को पार करके सेल डेटा को प्राप्त करना है।

इस फ़ीचर के केंद्र में नया [ExcelDataWorkbook](https://reference.aspose.com/slides/hi/net/aspose.slides.excel/exceldataworkbook/) क्लास है। यह क्लास आपको स्थानीय फ़ाइल या स्ट्रीम से Excel वर्कबुक लोड करने की अनुमति देता है। लोड होने के बाद यह [GetCell](https://reference.aspose.com/slides/hi/net/aspose.slides.excel/exceldataworkbook/getcell/) मेथड के कई ओवरलोड प्रदान करता है, जिनका उपयोग आप पंक्ति‑कॉलम सूचकांक या नामित रेंज के आधार पर विशिष्ट सेल्स प्राप्त करने के लिए कर सकते हैं।

प्रत्येक कॉल पर [GetCell](https://reference.aspose.com/slides/hi/net/aspose.slides.excel/exceldataworkbook/getcell/) एक [ExcelDataCell](https://reference.aspose.com/slides/hi/net/aspose.slides.excel/exceldatacell/) का इंस्टेंस लौटाता है। यह ऑब्जेक्ट Excel वर्कबुक में एकल सेल का प्रतिनिधित्व करता है और आपको उसकी मान तक सरल और सहज तरीके से पहुँच देता है।

#### **एक्सेल चार्ट आयात करें**

फ़ंक्शनैलिटी को विस्तारित करने का अगला कदम है [ExcelWorkbookImporter](https://reference.aspose.com/slides/hi/net/aspose.slides.import/excelworkbookimporter/) क्लास। यह यूटिलिटी क्लास Excel वर्कबुक से सामग्री को प्रस्तुति में आयात करने की सुविधा प्रदान करती है। इसमें [AddChartFromWorkbook](https://reference.aspose.com/slides/hi/net/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/) मेथड के कई ओवरलोड हैं, जो आपको निर्दिष्ट Excel वर्कबुक से चयनित चार्ट प्राप्त करके बताए गए कोऑर्डिनेट्स पर दी गई शैप कलेक्शन के अंत में जोड़ने में मदद करते हैं।

#### **एक्सेल टेबल आयात करें**

[ExcelWorkbookImporter](https://reference.aspose.com/slides/hi/net/aspose.slides.import/excelworkbookimporter/) क्लास में [AddTableFromWorkbook](https://reference.aspose.com/slides/hi/net/aspose.slides.import/excelworkbookimporter/addtablefromworkbook/) मेथड के भी कई ओवरलोड शामिल हैं। ये मेथड आपको निर्दिष्ट वर्कशीट से निर्दिष्ट सेल रेंज को एक टेबल के रूप में दी गई शैप कलेक्शन के अंत में बताए गए कोऑर्डिनेट्स पर जोड़ने की अनुमति देते हैं।

संक्षेप में, यह Excel डेटा को पढ़ने के लिए एक हल्का और सीधा API है — वही जो कई डेवलपर्स को पूरी स्प्रेडशीट प्रोसेसिंग लाइब्रेरी के ओवरहेड के बिना चाहिए।

## **आइए कोड लिखें**

### **मेल मर्ज परिदृश्य उदाहरण**

निम्न उदाहरण में हम एक सरल मेल मर्ज परिदृश्य को लागू करेंगे, जहाँ Excel वर्कबुक में संग्रहित डेटा के आधार पर कई प्रस्तुतियाँ उत्पन्न की जाएँगी।

शुरू करने के लिए हमें दो चीज़ों की आवश्यकता है:
1. डेटा युक्त Excel वर्कबुक

![Excel data example](example1_image0.png)

2. PowerPoint प्रस्तुति टेम्प्लेट

![PowerPoint template example](example1_image1.png)

```csharp
// कर्मचारी डेटा के साथ Excel वर्कबुक लोड करें।
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// प्रस्तुति टेम्प्लेट लोड करें।
using Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

// Excel पंक्तियों पर लूप करें (पंक्ति 0 में हेडर को छोड़कर).
for (int rowIndex = 1; rowIndex <= 4; rowIndex++)
{
    // प्रत्येक कर्मचारी रिकॉर्ड के लिए नई प्रस्तुति बनाएं।
    using Presentation employeePresentation = new Presentation();

    // डिफ़ॉल्ट खाली स्लाइड हटाएं।
    employeePresentation.Slides.RemoveAt(0);

    // टेम्प्लेट स्लाइड को नई प्रस्तुति में क्लोन करें।
    ISlide slide = employeePresentation.Slides.AddClone(templatePresentation.Slides[0]);

    // टारगेट शैप से पैराग्राफ प्राप्त करें (मान लिया गया है कि शैप इंडेक्स 1 उपयोग में है).
    IParagraphCollection paragraphs = (slide.Shapes[1] as IAutoShape).TextFrame.Paragraphs;

    // प्लेसहोल्डर्स को Excel डेटा से बदलें.
    string employeeName = workbook.GetCell(worksheetIndex, rowIndex, 0).Value.ToString();
    IPortion namePortion = paragraphs[0].Portions[0];
    namePortion.Text = namePortion.Text.Replace("{{EmployeeName}}", employeeName);

    string department = workbook.GetCell(worksheetIndex, rowIndex, 1).Value.ToString();
    IPortion departmentPortion = paragraphs[1].Portions[0];
    departmentPortion.Text = departmentPortion.Text.Replace("{{Department}}", department);

    string yearsOfService = workbook.GetCell(worksheetIndex, rowIndex, 2).Value.ToString();
    IPortion yearsPortion = paragraphs[2].Portions[0];
    yearsPortion.Text = yearsPortion.Text.Replace("{{YearsOfService}}", yearsOfService);

    // व्यक्तिगत प्रस्तुति को अलग फ़ाइल में सहेजें.
    employeePresentation.Save($"{employeeName} Report.pptx", SaveFormat.Pptx);
}
```

![परिणाम](example1_image2.png)

### **Excel टेबल उदाहरण**

दूसरे उदाहरण में हम केवल Excel टेबल से डेटा कॉपी करके उसे PowerPoint स्लाइड पर अधिक दृश्यात्मक रूप में प्रदर्शित करेंगे।

इस उदाहरण में हम पहले उदाहरण की वही Excel वर्कबुक उपयोग करते हैं, जिसमें एक सरल कर्मचारी टेबल है।

```csharp
// कर्मचारी डेटा वाले Excel वर्कबुक को लोड करें।
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// एक नई PowerPoint प्रस्तुति बनाएं।
using Presentation presentation = new Presentation();

// पहली स्लाइड में एक टेबल शेप जोड़ें.
ITable table = presentation.Slides[0].Shapes.AddTable(
    50, 200,
    new double[] { 200, 200, 200 },
    new double[] { 30, 30, 30, 30, 30 }
);

// Excel वर्कबुक से डेटा का उपयोग करके PowerPoint टेबल को भरें.
for (int rowIndex = 0; rowIndex < 5; rowIndex++)
{
    for (int columnIndex = 0; columnIndex < 3; columnIndex++)
    {
        string cellValue = workbook.GetCell(worksheetIndex, rowIndex, columnIndex).Value.ToString();
        table[columnIndex, rowIndex].TextFrame.Text = cellValue;
    }
}

// परिणामी प्रस्तुति को फ़ाइल में सहेजें.
presentation.Save("Table.pptx", SaveFormat.Pptx);
```

![परिणाम](example2_image0.png)

### **Excel चार्ट आयात उदाहरण**

इस उदाहरण में हम पिछले उदाहरण में उपयोग की गई Excel वर्कबुक की पहली वर्कशीट से एक चार्ट आयात करेंगे। चार्ट उत्पन्न प्रस्तुति में बाहरी वर्कबुक से लिंक करेगा।

पहले, हम कर्मचारियों की टेबल के आधार पर Excel वर्कबुक में एक पाई चार्ट जोड़ते हैं।

![Excel Chart example](example3_image0.png)

```csharp
// एक नई PowerPoint प्रस्तुति बनाएं.
using Presentation presentation = new Presentation();

// पहली स्लाइड के shapes कलेक्शन को प्राप्त करें.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// वर्कबुक की पहली शीट से "Chart 1" नामक चार्ट आयात करें और इसे shapes कलेक्शन में जोड़ें.
ExcelWorkbookImporter.AddChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

// परिणामी प्रस्तुति को फ़ाइल में सहेजें.
presentation.Save("Chart.pptx", SaveFormat.Pptx);
```
![परिणाम](example3_image1.png)

### **सभी Excel चार्ट आयात उदाहरण**

कल्पना करें आपके पास एक Excel वर्कबुक में कई चार्ट्स हैं और आपको उन्हें सभी को एक प्रस्तुति में आयात करना है। प्रत्येक चार्ट को एक नई स्लाइड पर रखा जाना चाहिए।

निम्न कोड स्रोत Excel फ़ाइल की सभी वर्कशीट्स पर इटरेट करता है, प्रत्येक वर्कशीट से चार्ट्स निकालता है, और प्रत्येक चार्ट को एक अलग स्लाइड में खाली स्लाइड लेआउट का उपयोग करके जोड़ता है। परिणामी प्रस्तुति में केवल चार्ट डेटा एंबेड किया जाएगा, पूरी वर्कबुक नहीं।

```csharp
// कर्मचारी डेटा वाली Excel वर्कबुक लोड करें।
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// एक नई PowerPoint प्रस्तुति बनाएं.
using Presentation presentation = new Presentation();

// ब्लैंक स्लाइड लेआउट प्राप्त करें.
ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

// Excel वर्कबुक में शामिल सभी वर्कशीट्स के नाम प्राप्त करें.
IList<string> worksheetNames = workbook.GetWorksheetNames();

foreach (var name in worksheetNames)
{
    // वर्कशीट के लिए चार्ट इंडेक्स को चार्ट नामों से मैप करने वाला शब्दकोश प्राप्त करें.
    IDictionary<int, string> worksheetCharts = workbook.GetChartsFromWorksheet(name);
    foreach (var chart in worksheetCharts)
    {
        // ब्लैंक लेआउट का उपयोग करके एक नई स्लाइड जोड़ें.
        ISlide slide = presentation.Slides.AddEmptySlide(blankLayout);

        // निर्दिष्ट चार्ट को Excel वर्कबुक से स्लाइड के शैप्स कलेक्शन में आयात करें.
        ExcelWorkbookImporter.AddChartFromWorkbook(slide.Shapes, 10, 10, workbook, name, chart.Key, false);
    }
}

// परिणामी प्रस्तुति को फ़ाइल में सहेजें.
presentation.Save("Charts.pptx", SaveFormat.Pptx);
```

### **एक्सेल टेबल आयात उदाहरण**

इस उदाहरण में हम एक फॉर्मेटेड टेबल को सीधे Excel वर्कशीट से PowerPoint प्रस्तुति में आयात करते हैं।

स्रोत Excel वर्कशीट में कर्मचारियों के डेटा के साथ एक फॉर्मेटेड टेबल है:

![Excel Table example](example4_image0.png)

```csharp
// एक नई PowerPoint प्रस्तुति बनाएं.
using Presentation presentation = new Presentation();

// पहली स्लाइड के shapes कलेक्शन को प्राप्त करें.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// वर्कबुक की पहली शीट से टेबल आयात करें और इसे shapes कलेक्शन में जोड़ें.
ExcelWorkbookImporter.AddTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5");

// परिणामी प्रस्तुति को फ़ाइल में सहेजें.
presentation.Save("FormattedTable.pptx", SaveFormat.Pptx);
```

![परिणाम](example4_image1.png)

## **सारांश**

यह तंत्र, जो सीधे Aspose.Slides में उपलब्ध है, Excel डेटा और प्रस्तुतियों को एक ही स्थान पर काम करने की सुविधा देता है। यह आपको विज़ुअल चार्ट्स और Excel टेबल्स के रूप में डेटा प्रस्तुत करते हुए स्लाइड्स बनाने की अनुमति देता है — बिना किसी अतिरिक्त लाइब्रेरी या जटिल इंटीग्रेशन के।