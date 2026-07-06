---
title: PowerPoint प्रस्तुतियों में Excel डेटा को एकीकृत करें
linktitle: Excel एकीकरण
type: docs
weight: 330
url: /hi/net/excel-integration/
keywords:
- Excel
- कार्यपुस्तिका
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
description: "Aspose.Slides में ExcelDataWorkbook API का उपयोग करके Excel कार्यपुस्तिकाओं से डेटा पढ़ें। शीट और सेल लोड करें और मानों का उपयोग करके डेटा‑आधारित PowerPoint प्रस्तुतियों को बनाएं।"
---
## **परिचय**

PowerPoint प्रस्तुतियाँ जानकारी को प्रदर्शित करने और संप्रेषित करने का एक शक्तिशाली तरीका हैं। इन्हें अक्सर Excel कार्यपत्रकों के साथ उपयोग किया जाता है, जहाँ Excel संरचित डेटा का उत्कृष्ट स्रोत है और PowerPoint उस डेटा को दर्शकों के लिए दृश्य रूप में प्रस्तुत करने में उत्कृष्ट है।

Excel और PowerPoint को मिलाकर उपयोग करने के कई व्यावहारिक परिदृश्य हैं: मेल मर्ज, डेटा तालिकाएँ भरना, डेटा रिकॉर्ड प्रति एक स्लाइड बनाना (बैच स्लाइड जनरेशन), प्रशिक्षण सामग्री बनाना, और कई Excel रिपोर्टों को एक प्रस्तुति में समेकित करना, आदि।

अब तक, Aspose.Slides API के साथ ऐसी सुविधाएँ लागू करने के लिए Aspose.Cells जैसे तृतीय‑पक्ष समाधान पर निर्भर रहना पड़ता था। जबकि ये उपकरण मजबूत हैं, वे केवल बुनियादी डेटा एकीकरण कार्यक्षमता की आवश्यकता रखने वाले उपयोगकर्ताओं के लिए अत्यधिक जटिल और महंगे हो सकते हैं।

## **यह कैसे काम करता है**

Excel डेटा के साथ काम को आसान और सुगम बनाने के लिए, Aspose.Slides ने Excel कार्यपत्रकों से डेटा पढ़ने और प्रस्तुति में सामग्री आयात करने के लिए नई क्लासें पेश की हैं। यह सुविधा API उपयोगकर्ताओं के लिए नई शक्तिशाली संभावनाएँ खोलती है जो अपनी प्रस्तुति कार्यप्रवाह में Excel को डेटा स्रोत के रूप में उपयोग करना चाहते हैं।

नई कार्यक्षमता सामान्य उद्देश्य के डेटा एक्सेस के लिए डिज़ाइन की गई है और Presentation Document Object Model (DOM) में एकीकृत नहीं है। इसका अर्थ है *यह Excel फ़ाइलों को संपादित या सहेजने की अनुमति नहीं देता* — इसका एकल उद्देश्य कार्यपत्रकों को खोलना और उनकी सामग्री में नेविगेट करके सेल डेटा प्राप्त करना है।

इस सुविधा के मूल में नया [ExcelDataWorkbook](https://reference.aspose.com/slides/hi/net/aspose.slides.excel/exceldataworkbook/) क्लास है। यह क्लास आपको स्थानीय फ़ाइल या स्ट्रीम से Excel कार्यपुस्तिका लोड करने की अनुमति देता है। लोड करने के बाद, यह [GetCell](https://reference.aspose.com/slides/hi/net/aspose.slides.excel/exceldataworkbook/getcell/) मेथड के कई ओवरलोड प्रदान करता है, जिसे आप स्थिति (जैसे पंक्ति और स्तंभ सूचकांक या नामित रेंज) के आधार पर विशिष्ट सेल प्राप्त करने के लिए उपयोग कर सकते हैं।

हर बार [GetCell](https://reference.aspose.com/slides/hi/net/aspose.slides.excel/exceldataworkbook/getcell/) को कॉल करने पर [ExcelDataCell](https://reference.aspose.com/slides/hi/net/aspose.slides.excel/exceldatacell/) क्लास की एक इंस्टेंस लौटती है। यह ऑब्जेक्ट Excel कार्यपुस्तिका में एकल सेल का प्रतिनिधित्व करता है और आपको उसकी मान तक सरल और सहज तरीके से पहुँच प्रदान करता है।

#### **Excel चार्ट आयात करें**

कार्यशीलता को विस्तारित करने का अगला चरण [ExcelWorkbookImporter](https://reference.aspose.com/slides/hi/net/aspose.slides.import/excelworkbookimporter/) क्लास है। यह उपयोगिता क्लास Excel कार्यपुस्तिका से प्रस्तुति में सामग्री आयात करने की कार्यक्षमता प्रदान करती है। इसमें [AddChartFromWorkbook](https://reference.aspose.com/slides/hi/net/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/) मेथड के कई ओवरलोड शामिल हैं, जो आपको निर्दिष्ट Excel कार्यपुस्तिका से चयनित चार्ट प्राप्त करने और निर्दिष्ट निर्देशांक पर दिए गए शेप संग्रह के अंत में जोड़ने में मदद करते हैं।

#### **Excel तालिका आयात करें**

[ExcelWorkbookImporter](https://reference.aspose.com/slides/hi/net/aspose.slides.import/excelworkbookimporter/) क्लास में भी [AddTableFromWorkbook](https://reference.aspose.com/slides/hi/net/aspose.slides.import/excelworkbookimporter/addtablefromworkbook/) मेथड के कई ओवरलोड होते हैं। ये मेथड आपको एक निर्दिष्ट कार्यपत्रक से एक निर्दिष्ट सेल रेंज आयात करने और इसे निर्दिष्ट निर्देशांक पर दिए गए शेप संग्रह के अंत में तालिका के रूप में जोड़ने की अनुमति देते हैं।

संक्षेप में, यह Excel डेटा पढ़ने के लिए एक हल्का और सीधा API है — बिल्कुल वही जो कई डेवलपर्स को पूर्ण स्प्रेडशीट प्रोसेसिंग लाइब्रेरी के ओवरहेड के बिना चाहिए।

## **आइए कोड लिखें**

### **मेल मर्ज परिदृश्य उदाहरण**

निम्नलिखित उदाहरण में, हम एक सरल मेल मर्ज परिदृश्य को लागू करेंगे, जहाँ Excel कार्यपुस्तिका में संग्रहीत डेटा के आधार पर कई प्रस्तुतियाँ उत्पन्न की जाएँगी।

To get started, we need two things:
1. डेटा युक्त एक Excel कार्यपुस्तिका

![Excel डेटा उदाहरण](example1_image0.png)

2. PowerPoint प्रस्तुति टेम्पलेट

![PowerPoint टेम्पलेट उदाहरण](example1_image1.png)

```csharp
// कर्मचारी डेटा के साथ Excel कार्यपुस्तिका लोड करें.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// प्रस्तुति टेम्पलेट लोड करें.
using Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

// Excel पंक्तियों पर लूप चलाएँ (पंक्ति 0 पर हेडर को छोड़कर).
for (int rowIndex = 1; rowIndex <= 4; rowIndex++)
{
    // प्रत्येक कर्मचारी रिकॉर्ड के लिए नई प्रस्तुति बनाएं.
    using Presentation employeePresentation = new Presentation();

    // डिफॉल्ट खाली स्लाइड हटाएँ.
    employeePresentation.Slides.RemoveAt(0);

    // टेम्पलेट स्लाइड को नई प्रस्तुति में क्लोन करें.
    ISlide slide = employeePresentation.Slides.AddClone(templatePresentation.Slides[0]);

    // लक्ष्य आकृति से पैराग्राफ प्राप्त करें (मान लिया गया है कि आकृति सूचकांक 1 उपयोग किया गया है).
    IParagraphCollection paragraphs = (slide.Shapes[1] as IAutoShape).TextFrame.Paragraphs;

    // प्लेसहोल्डर को Excel डेटा से बदलें.
    string employeeName = workbook.GetCell(worksheetIndex, rowIndex, 0).Value.ToString();
    IPortion namePortion = paragraphs[0].Portions[0];
    namePortion.Text = namePortion.Text.Replace("{{EmployeeName}}", employeeName);

    string department = workbook.GetCell(worksheetIndex, rowIndex, 1).Value.ToString();
    IPortion departmentPortion = paragraphs[1].Portions[0];
    departmentPortion.Text = departmentPortion.Text.Replace("{{Department}}", department);

    string yearsOfService = workbook.GetCell(worksheetIndex, rowIndex, 2).Value.ToString();
    IPortion yearsPortion = paragraphs[2].Portions[0];
    yearsPortion.Text = yearsPortion.Text.Replace("{{YearsOfService}}", yearsOfService);

    // व्यक्तिगत प्रस्तुति को एक अलग फ़ाइल में सहेजें.
    employeePresentation.Save($"{employeeName} Report.pptx", SaveFormat.Pptx);
}
```

![परिणाम](example1_image2.png)

### **Excel तालिका उदाहरण**

दूसरे उदाहरण में, हम सरलता से Excel तालिका से डेटा कॉपी करते हैं और उसे PowerPoint स्लाइड पर अधिक दृश्यात्मक आकर्षक प्रारूप में प्रदर्शित करते हैं।

इस उदाहरण में, हम पहले उदाहरण की वही Excel कार्यपुस्तिका पुनः उपयोग करते हैं, जिसमें एक साधारण कर्मचारी तालिका शामिल है।

```csharp
// कर्मचारी डेटा वाली Excel कार्यपुस्तिका लोड करें.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// नई PowerPoint प्रस्तुति बनाएं.
using Presentation presentation = new Presentation();

// पहले स्लाइड में एक तालिका आकार जोड़ें.
ITable table = presentation.Slides[0].Shapes.AddTable(
    50, 200,
    new double[] { 200, 200, 200 },
    new double[] { 30, 30, 30, 30, 30 }
);

// Excel कार्यपुस्तिका से डेटा के साथ PowerPoint तालिका भरें.
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

इस उदाहरण में, हम पिछले उदाहरण में उपयोग की गई Excel कार्यपुस्तिका के पहले कार्यपत्रक से एक चार्ट आयात करते हैं। परिणामस्वरूप प्रस्तुति में चार्ट बाहरी कार्यपुस्तिका से लिंक होगा।

पहले, हम कर्मचारियों की तालिका के आधार पर Excel कार्यपुस्तिका में एक पाई चार्ट जोड़ते हैं।

![Excel चार्ट उदाहरण](example3_image0.png)

```csharp
// नई PowerPoint प्रस्तुति बनाएं.
using Presentation presentation = new Presentation();

// पहले स्लाइड के आकार संग्रह प्राप्त करें.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// कार्यपुस्तिका की पहली शीट से "Chart 1" नामक चार्ट आयात करें और इसे आकार संग्रह में जोड़ें.
ExcelWorkbookImporter.AddChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

// परिणामी प्रस्तुति को फ़ाइल में सहेजें.
presentation.Save("Chart.pptx", SaveFormat.Pptx);
```
![परिणाम](example3_image1.png)

### **सभी Excel चार्ट आयात उदाहरण**

कल्पना करें कि आपके पास चार्ट से भरी एक Excel कार्यपुस्तिका है और आपको सभी चार्ट को एक प्रस्तुति में आयात करना है। प्रत्येक चार्ट को एक नई स्लाइड पर रखा जाना चाहिए।

निम्नलिखित कोड स्रोत Excel फ़ाइल में सभी कार्यपत्रकों पर क्रमवार चलता है, प्रत्येक कार्यपत्रक से चार्ट निकालता है, और प्रत्येक चार्ट को एक खाली स्लाइड लेआउट का उपयोग करके अलग-अलग स्लाइड में जोड़ता है। परिणामस्वरूप प्रस्तुति में केवल चार्ट डेटा एम्बेड किया जाएगा, पूरी कार्यपुस्तिका नहीं।

```csharp
// कर्मचारी डेटा वाली Excel कार्यपुस्तिका लोड करें.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// नई PowerPoint प्रस्तुति बनाएं.
using Presentation presentation = new Presentation();

// रिक्त स्लाइड लेआउट प्राप्त करें.
ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

// Excel कार्यपुस्तिका में समाहित सभी कार्यपत्रकों के नाम प्राप्त करें.
IList<string> worksheetNames = workbook.GetWorksheetNames();

foreach (var name in worksheetNames)
{
    // कार्यपत्रक के लिए चार्ट क्रमांक को चार्ट नामों से मैप करने वाला शब्दकोश प्राप्त करें.
    IDictionary<int, string> worksheetCharts = workbook.GetChartsFromWorksheet(name);
    foreach (var chart in worksheetCharts)
    {
        // रिक्त लेआउट का उपयोग करके नया स्लाइड जोड़ें.
        ISlide slide = presentation.Slides.AddEmptySlide(blankLayout);

        // Excel कार्यपुस्तिका से निर्दिष्ट चार्ट को स्लाइड के आकार संग्रह में आयात करें.
        ExcelWorkbookImporter.AddChartFromWorkbook(slide.Shapes, 10, 10, workbook, name, chart.Key, false);
    }
}

// परिणामस्वरूप प्रस्तुति को फ़ाइल में सहेजें.
presentation.Save("Charts.pptx", SaveFormat.Pptx);
```

### **Excel तालिका आयात उदाहरण**

इस उदाहरण में, हम एक स्वरूपित तालिका को सीधे Excel कार्यपत्रक से PowerPoint प्रस्तुति में आयात करते हैं।

स्रोत Excel कार्यपत्रक में कर्मचारी डेटा वाली एक स्वरूपित तालिका है:

![Excel तालिका उदाहरण](example4_image0.png)

```csharp
// नई PowerPoint प्रस्तुति बनाएं.
using Presentation presentation = new Presentation();

// पहली स्लाइड के आकार संग्रह प्राप्त करें.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// कार्यपुस्तिका की पहली शीट से तालिका आयात करें और इसे आकार संग्रह में जोड़ें.
ExcelWorkbookImporter.AddTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5");

// परिणामी प्रस्तुति को फ़ाइल में सहेजें.
presentation.Save("FormattedTable.pptx", SaveFormat.Pptx);
```

![परिणाम](example4_image1.png)

## **सारांश**

यह तंत्र, जो सीधे Aspose.Slides में उपलब्ध है, Excel डेटा और प्रस्तुतियों को एक ही स्थान पर संयोजित करता है। यह आपको दृश्यात्मक चार्ट और Excel तालिकाओं के रूप में प्रस्तुत डेटा के साथ स्लाइड बनाने की अनुमति देता है - बिना किसी अतिरिक्त लाइब्रेरी या जटिल एकीकरण के।