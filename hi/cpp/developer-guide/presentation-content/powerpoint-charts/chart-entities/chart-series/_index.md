---
title: C++ का उपयोग करके प्रस्तुतियों में चार्ट डेटा श्रृंखला प्रबंधित करें
linktitle: डेटा श्रृंखला
type: docs
url: /hi/cpp/chart-series/
keywords:
- चार्ट श्रृंखला
- श्रृंखला ओवरलैप
- श्रृंखला रंग
- श्रेणी रंग
- श्रृंखला नाम
- डेटा बिंदु
- श्रृंखला गैप
- पावरपॉइंट
- प्रस्तुति
- C++
- Aspose.Slides
description: "PowerPoint (PPT/PPTX) में C++ का उपयोग करके चार्ट श्रृंखला को प्रबंधित करना सीखें, व्यावहारिक कोड उदाहरण और सर्वोत्तम प्रथाओं के साथ अपने डेटा प्रस्तुतियों को बेहतर बनाएं।"
---
## **अवलोकन**

यह लेख Aspose.Slides में [ChartSeries](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/chartseries/) की भूमिका का विवरण देता है, और यह दर्शाता है कि प्रस्तुतियों के भीतर डेटा कैसे संरचित और दृश्य रूप में प्रदर्शित होता है। ये ऑब्जेक्ट्स बुनियादी तत्व प्रदान करते हैं जो चार्ट में व्यक्तिगत डेटा पॉइंट्स, श्रेणियों और रूपरेखा पैरामीटर को परिभाषित करते हैं। [ChartSeries](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/chartseries/) के साथ कार्य करके, डेवलपर्स अंतर्निहित डेटा स्रोतों को सहजता से एकीकृत कर सकते हैं और जानकारी के प्रदर्शन पर पूरी नियंत्रण बनाए रख सकते हैं, जिससे गतिशील, डेटा‑संचालित प्रस्तुतियां बनती हैं जो स्पष्ट रूप से अंतर्दृष्टि और विश्लेषण को संप्रेषित करती हैं।

एक श्रृंखला चार्ट में प्लॉट किए गए संख्याओं की पंक्ति या स्तम्भ होती है।

![chart-series-powerpoint](chart-series-powerpoint.png)

## **डेटा श्रृंखला ओवरलैप सेट करें**

आप [IChartSeries::get_Overlap()](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.charts.i_chart_series#a5ae56346bd11dc0a2264ff049a3e72bb) मेथड का उपयोग करके निर्धारित कर सकते हैं कि 2D चार्ट में बार और कॉलम कितनी हद तक ओवरलैप हों (सीमा: -100 से 100)। यह प्रॉपर्टी पैरेंट सीरीज़ ग्रुप की सभी श्रृंखलाओं पर लागू होती है: यह उपयुक्त ग्रुप प्रॉपर्टी का एक प्रोजेक्शन है।

अपनी इच्छित `Overlap` मान सेट करने के लिए `get_ParentSeriesGroup()::set_Overlap()` मेथड का उपयोग करें।

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) क्लास की इंस्टेंस बनाएं।
1. स्लाइड पर एक क्लस्टर्ड कॉलम चार्ट जोड़ें।
1. पहली चार्ट श्रृंखला तक पहुँचें।
1. चार्ट श्रृंखला के `ParentSeriesGroup` तक पहुँचें और श्रृंखला के लिए अपना इच्छित ओवरलैप मान सेट करें।
1. परिवर्तित प्रस्तुति को PPTX फ़ाइल में लिखें।

यह C++ कोड दिखाता है कि चार्ट श्रृंखला के ओवरलैप को कैसे सेट किया जाए:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// Adds chart
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
if (series->idx_get(0)->get_Overlap() == 0)
{
    // श्रृंखला ओवरलैप सेट करता है
    series->idx_get(0)->get_ParentSeriesGroup()->set_Overlap(-30);
}

// प्रस्तुति फ़ाइल को डिस्क पर लिखता है
presentation->Save(u"SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
```

## **डेटा श्रृंखला का रंग बदलें**

Aspose.Slides for C++ आपको इस प्रकार श्रृंखला का रंग बदलने की अनुमति देता है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) क्लास की इंस्टेंस बनाएं।
1. स्लाइड पर चार्ट जोड़ें।
1. उस श्रृंखला तक पहुँचें जिसका रंग आप बदलना चाहते हैं।
1. अपना इच्छित फ़िल टाइप और फ़िल कलर सेट करें।
1. परिवर्तित प्रस्तुति को सहेजें।

यह C++ कोड दिखाता है कि श्रृंखला का रंग कैसे बदला जाए:

```cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Pie, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(1);

point->set_Explosion(30);
point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **डेटा श्रृंखला श्रेणी का रंग बदलें**

Aspose.Slides for C++ आपको इस प्रकार श्रृंखला श्रेणी का रंग बदलने की अनुमति देता है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) क्लास की इंस्टेंस बनाएं।
1. स्लाइड पर चार्ट जोड़ें।
1. श्रृंखला श्रेणी तक पहुँचें जिसका रंग आप बदलना चाहते हैं।
1. अपना इच्छित फ़िल टाइप और फ़िल कलर सेट करें।
1. परिवर्तित प्रस्तुति को सहेजें।

यह कोड C++ में दिखाता है कि श्रृंखला श्रेणी का रंग कैसे बदला जाए:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0);

point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **डेटा श्रृंखला का नाम बदलें**

डिफ़ॉल्ट रूप से, एक चार्ट के लेजेंड नाम प्रत्येक कॉलम या पंक्ति के ऊपर स्थित सेल की सामग्री होते हैं।

हमारे उदाहरण (नमूना चित्र) में,  

* कॉलम हैं *Series 1, Series 2,* और *Series 3*;  
* पंक्तियाँ हैं *Category 1, Category 2, Category 3,* और *Category 4.*  

Aspose.Slides for C++ आपको चार्ट डेटा और लेजेंड में श्रृंखला नाम को अपडेट या बदलने की अनुमति देता है।

यह C++ कोड दिखाता है कि `ChartDataWorkbook` में श्रृंखला का नाम कैसे बदला जाए:

```cpp
auto pres = System::MakeObject<Presentation>();

auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);

auto seriesCell = chart->get_ChartData()->get_ChartDataWorkbook()->GetCell(0, 0, 1);
seriesCell->set_Value(ObjectExt::Box<String>(u"New name"));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

यह C++ कोड दिखाता है कि `Series` के माध्यम से लेजेंड में श्रृंखला नाम कैसे बदला जाए:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto name = series->get_Name();
name->get_AsCells()->idx_get(0)->set_Value(ObjectExt::Box<String>(u"New name"));
```

## **डेटा श्रृंखला फ़िल रंग सेट करें**

Aspose.Slides for C++ आपको प्लॉट क्षेत्र के भीतर चार्ट श्रृंखला के लिए ऑटोमैटिक फ़िल कलर इस प्रकार सेट करने की अनुमति देता है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) क्लास की इंस्टेंस बनाएं।
1. उसके इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
1. अपने इच्छित प्रकार के आधार पर डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें (नीचे के उदाहरण में, हमने `ChartType::ClusteredColumn` का उपयोग किया)।
1. चार्ट श्रृंखला तक पहुँचें और फ़िल कलर को Automatic सेट करें।
1. प्रस्तुति को PPTX फ़ाइल में सहेजें।

यह C++ कोड दिखाता है कि चार्ट श्रृंखला के लिए ऑटोमैटिक फ़िल कलर कैसे सेट किया जाए:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// एक क्लस्टर्ड कॉलम चार्ट बनाता है
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 50.0f, 600.0f, 400.0f);

// सीरीज़ फ़िल फ़ॉर्मेट को ऑटोमैटिक सेट करता है
for (const auto& series : chart->get_ChartData()->get_Series())
{
    series->GetAutomaticSeriesColor();
}

// प्रस्तुति फ़ाइल को डिस्क पर लिखता है
presentation->Save(u"AutoFillSeries_out.pptx", SaveFormat::Pptx);
```

## **डेटा श्रृंखला इनवर्ट फ़िल रंग सेट करें**

Aspose.Slides आपको प्लॉट क्षेत्र के भीतर चार्ट श्रृंखला के लिए इनवर्ट फ़िल कलर इस प्रकार सेट करने की अनुमति देता है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) क्लास की इंस्टेंस बनाएं।
1. उसके इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
1. अपने इच्छित प्रकार के आधार पर डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें (नीचे के उदाहरण में, हमने `ChartType::ClusteredColumn` का उपयोग किया)।
1. चार्ट श्रृंखला तक पहुँचें और फ़िल कलर को invert सेट करें।
1. प्रस्तुति को PPTX फ़ाइल में सहेजें।

यह C++ कोड संचालन को दर्शाता है:

```cpp
Color inverColor = Color::get_Red();
    
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

auto workBook = chart->get_ChartData()->get_ChartDataWorkbook();
auto chartData = chart->get_ChartData();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

// Adds new series and categories
chartData->get_Series()->Add(workBook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chartData->get_Categories()->Add(workBook->GetCell(0, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chartData->get_Categories()->Add(workBook->GetCell(0, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chartData->get_Categories()->Add(workBook->GetCell(0, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// Takes the first chart series and populates its series data.
auto series = chartData->get_Series()->idx_get(0);
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 1, 1, ObjectExt::Box<int32_t>(-20)));
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 2, 1, ObjectExt::Box<int32_t>(50)));
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 3, 1, ObjectExt::Box<int32_t>(-30)));
Color seriesColor = series->GetAutomaticSeriesColor();
series->set_InvertIfNegative(true);
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(seriesColor);
series->get_InvertedSolidFillColor()->set_Color(inverColor);
pres->Save(u"SetInvertFillColorChart_out.pptx", SaveFormat::Pptx);
```

## **चार्ट श्रृंखला के लिए इनवर्ट फ़िल कलर सेट करें**

Aspose.Slides आपको `IChartDataPoint::set_InvertIfNegative()` और `ChartDataPoint.set_InvertIfNegative()` मेथड्स के माध्यम से इनवर्ट सेट करने की अनुमति देता है। जब इनवर्ट सेट किया जाता है, तो डेटा पॉइंट नकारात्मक मान मिलने पर अपने रंगों को उलट देता है।

यह C++ कोड संचालन को दर्शाता है:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
chart->get_ChartData()->get_Series()->Clear();

auto workBook = chart->get_ChartData()->get_ChartDataWorkbook();
series->Add(workBook->GetCell(0, u"B1"), chart->get_Type());
auto dataPoints = series->idx_get(0)->get_DataPoints();
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B2", ObjectExt::Box<int32_t>(-5)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B3", ObjectExt::Box<int32_t>(3)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B4", ObjectExt::Box<int32_t>(-2)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B5", ObjectExt::Box<int32_t>(1)));

series->idx_get(0)->set_InvertIfNegative(false);

series->idx_get(0)->get_DataPoints()->idx_get(2)->set_InvertIfNegative(true);

pres->Save(u"out.pptx", SaveFormat::Pptx);
```

## **विशिष्ट डेटा पॉइंट मान साफ़ करें**

Aspose.Slides for C++ आपको एक विशिष्ट चार्ट श्रृंखला के लिए `DataPoints` डेटा को इस प्रकार साफ़ करने की अनुमति देता है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) क्लास की इंस्टेंस बनाएं।
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।
3. इंडेक्स के माध्यम से चार्ट का रेफ़रेंस प्राप्त करें।
4. सभी चार्ट `DataPoints` पर इटररेट करें और `XValue` तथा `YValue` को null सेट करें।
5. विशिष्ट चार्ट श्रृंखला के सभी `DataPoints` को साफ़ करें।
6. परिवर्तित प्रस्तुति को PPTX फ़ाइल में लिखें।

यह C++ कोड संचालन को दर्शाता है:

```cpp
auto pres = System::MakeObject<Presentation>(u"TestChart.pptx");
auto sl = pres->get_Slides()->idx_get(0);

auto chart = System::ExplicitCast<IChart>(sl->get_Shapes()->idx_get(0));
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();

for (const auto& dataPoint : dataPoints)
{
    dataPoint->get_XValue()->get_AsCell()->set_Value(nullptr);
    dataPoint->get_YValue()->get_AsCell()->set_Value(nullptr);
}

dataPoints->Clear();

pres->Save(u"ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat::Pptx);
```

## **डेटा श्रृंखला गैप चौड़ाई सेट करें**

Aspose.Slides for C++ आपको **`set_GapWidth()`** मेथड के माध्यम से श्रृंखला की गैप चौड़ाई इस प्रकार सेट करने की अनुमति देता है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) क्लास की इंस्टेंस बनाएं।
1. पहली स्लाइड तक पहुँचें।
1. डिफ़ॉल्ट डेटा के साथ चार्ट जोड़ें।
1. किसी भी चार्ट श्रृंखला तक पहुँचें।
1. `GapWidth` प्रॉपर्टी सेट करें।
1. परिवर्तित प्रस्तुति को PPTX फ़ाइल में लिखें।

यह कोड C++ में दिखाता है कि श्रृंखला की गैप चौड़ाई कैसे सेट की जाए:

```cpp
// खाली प्रस्तुति बनाता है 
auto presentation = System::MakeObject<Presentation>();

// प्रस्तुति की पहली स्लाइड तक पहुँचता है
auto slide = presentation->get_Slides()->idx_get(0);

// डिफ़ॉल्ट डेटा के साथ चार्ट जोड़ता है
auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 0.0f, 0.0f, 500.0f, 500.0f);

// चार्ट डेटा शीट का इंडेक्स सेट करता है
int32_t worksheetIndex = 0;

// चार्ट डेटा वर्कशीट प्राप्त करता है
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// श्रृंखलाएँ जोड़ता है
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 2, ObjectExt::Box<String>(u"Series 2")), chart->get_Type());

// श्रेणियाँ जोड़ता है
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// दूसरी चार्ट श्रृंखला लेता है
auto series = chart->get_ChartData()->get_Series()->idx_get(1);
auto dataPoints = series->get_DataPoints();

// श्रृंखला डेटा भरता है
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 1, ObjectExt::Box<int32_t>(20)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 1, ObjectExt::Box<int32_t>(50)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 1, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 2, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 2, ObjectExt::Box<int32_t>(10)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 2, ObjectExt::Box<int32_t>(60)));

// GapWidth मान सेट करता है
series->get_ParentSeriesGroup()->set_GapWidth(50);

// प्रस्तुति को डिस्क पर सहेजता है
presentation->Save(u"GapWidth_out.pptx", SaveFormat::Pptx);
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या एक एकल चार्ट में मौजूद श्रृंखलाओं की संख्या पर कोई सीमा है?**

Aspose.Slides द्वारा जोड़ी जाने वाली श्रृंखलाओं की संख्या पर कोई स्थायी सीमा नहीं लगाई गई है। व्यावहारिक सीमा चार्ट की पठनीयता और आपके एप्लिकेशन में उपलब्ध मेमोरी द्वारा निर्धारित होती है।

**यदि क्लस्टर के भीतर कॉलम बहुत नज़दीक या बहुत दूर हों तो क्या करें?**

उस श्रृंखला (या उसकी पैरेंट सीरीज़ ग्रुप) के लिए गैप चौड़ाई सेटिंग समायोजित करें। मान बढ़ाने से कॉलम के बीच की दूरी बढ़ती है, जबकि घटाने से वे एक दूसरे के अधिक नजदीक आ जाते हैं।