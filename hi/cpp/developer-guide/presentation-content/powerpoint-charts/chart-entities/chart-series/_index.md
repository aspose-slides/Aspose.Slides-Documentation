---
title: C++ का उपयोग करके प्रस्तुतियों में चार्ट डेटा सीरीज़ प्रबंधित करें
linktitle: डेटा सीरीज़
type: docs
url: /hi/cpp/chart-series/
keywords:
- चार्ट सीरीज़
- सीरीज़ ओवरलैप
- सीरीज़ रंग
- श्रेणी रंग
- सीरीज़ नाम
- डेटा पॉइंट
- सीरीज़ गैप
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "PowerPoint (PPT/PPTX) के लिए C++ में चार्ट सीरीज़ को प्रबंधित करने के तरीकों को व्यावहारिक कोड उदाहरणों और सर्वोत्तम प्रथाओं के साथ सीखें, जिससे आपके डेटा प्रस्तुतियों में सुधार हो सके।"
---
## **अवलोकन**

यह लेख Aspose.Slides में [ChartSeries](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/chartseries/) की भूमिका का वर्णन करता है, जिसमें प्रस्तुतियों में डेटा कैसे संरचित और दृश्यीकृत किया जाता है, इस पर केंद्रित है। ये ऑब्जेक्ट चार्ट में व्यक्तिगत डेटा पॉइंट सेट, श्रेणियां और दिखावट पैरामीटर परिभाषित करने वाले मूलभूत तत्व प्रदान करते हैं। [ChartSeries](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/chartseries/) के साथ काम करके, डेवलपर अंतर्निहित डेटा स्रोतों को सहजता से एकीकृत कर सकते हैं और जानकारी के प्रदर्शित होने पर पूर्ण नियंत्रण रख सकते हैं, जिससे गतिशील, डेटा-चालित प्रस्तुतियां बनती हैं जो अंतर्दृष्टि और विश्लेषण को स्पष्ट रूप से संप्रेषित करती हैं।

एक सीरीज़ वह पंक्ति या कॉलम है जिसमें संख्याएँ चार्ट में प्लॉट की जाती हैं।

![chart-series-powerpoint](chart-series-powerpoint.png)

## **डेटा सीरीज़ ओवरलैप सेट करें**

[IChartSeries::get_Overlap()](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.charts.i_chart_series#a5ae56346bd11dc0a2264ff049a3e72bb) मेथड के साथ आप 2D चार्ट में बार और कॉलम कितनी ओवरलैप होंगी, इसे निर्दिष्ट कर सकते हैं (रेंज: -100 से 100)। यह प्रॉपर्टी पैरेंट सीरीज़ ग्रुप की सभी सीरीज़ पर लागू होती है: यह उपयुक्त ग्रुप प्रॉपर्टी का प्रोजेक्शन है।

`get_ParentSeriesGroup()::set_Overlap()` मेथड का उपयोग करके `Overlap` के लिए अपना इच्छित मान सेट करें।

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) क्लास का एक इंस्टेंस बनाएं।
1. स्लाइड पर एक क्लस्टर्ड कॉलम चार्ट जोड़ें।
1. पहली चार्ट सीरीज़ तक पहुंचें।
1. चार्ट सीरीज़ की `ParentSeriesGroup` तक पहुंचें और सीरीज़ के लिए अपना इच्छित ओवरलैप मान सेट करें। 
1. संशोधित प्रस्तुति को PPTX फ़ाइल में लिखें।

यह C++ कोड दिखाता है कि चार्ट सीरीज़ के लिए ओवरलैप कैसे सेट किया जाता है:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// चार्ट जोड़ता है
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
if (series->idx_get(0)->get_Overlap() == 0)
{
    // सीरीज़ ओवरलैप सेट करता है
    series->idx_get(0)->get_ParentSeriesGroup()->set_Overlap(-30);
}

// प्रेजेंटेशन फ़ाइल को डिस्क पर लिखता है
presentation->Save(u"SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
```

## **डेटा सीरीज़ रंग बदलें**

Aspose.Slides for C++ आपको एक सीरीज़ का रंग बदलने का तरीका प्रदान करता है:

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) क्लास का एक इंस्टेंस बनाएं।
1. स्लाइड पर चार्ट जोड़ें।
1. उस सीरीज़ तक पहुंचें जिसका रंग आप बदलना चाहते हैं। 
1. अपनी पसंदीदा फ़िल टाइप और फ़िल रंग सेट करें।
1. संशोधित प्रस्तुति को सहेजें।

यह C++ कोड दिखाता है कि सीरीज़ का रंग कैसे बदला जाता है:

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

## **डेटा सीरीज़ श्रेणी का रंग बदलें**

Aspose.Slides for C++ आपको एक सीरीज़ श्रेणी का रंग बदलने का तरीका प्रदान करता है:

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) क्लास का एक इंस्टेंस बनाएं।
1. स्लाइड पर चार्ट जोड़ें।
1. उस सीरीज़ श्रेणी तक पहुंचें जिसका रंग आप बदलना चाहते हैं।
1. अपनी पसंदीदा फ़िल टाइप और फ़िल रंग सेट करें।
1. संशोधित प्रस्तुति को सहेजें।

यह C++ कोड दिखाता है कि सीरीज़ श्रेणी का रंग कैसे बदला जाता है:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0);

point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **डेटा सीरीज़ का नाम बदलें** 

डिफ़ॉल्ट रूप से, चार्ट के लेजेंड नाम प्रत्येक कॉलम या पंक्ति के ऊपर स्थित सेल्स की सामग्री होते हैं। 

हमारे उदाहरण (नमूना चित्र) में,

* कॉलम *Series 1, Series 2,* और *Series 3* हैं;
* पंक्तियां *Category 1, Category 2, Category 3,* और *Category 4* हैं। 

Aspose.Slides for C++ आपको चार्ट डेटा और लेजेंड में एक सीरीज़ का नाम अपडेट या बदलने की अनुमति देता है। 

यह C++ कोड दिखाता है कि `ChartDataWorkbook` में चार्ट डेटा के अंदर सीरीज़ का नाम कैसे बदला जाता है:

```cpp
auto pres = System::MakeObject<Presentation>();

auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);

auto seriesCell = chart->get_ChartData()->get_ChartDataWorkbook()->GetCell(0, 0, 1);
seriesCell->set_Value(ObjectExt::Box<String>(u"New name"));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

यह C++ कोड दिखाता है कि `Series` के माध्यम से लेजेंड में सीरीज़ का नाम कैसे बदला जाता है:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto name = series->get_Name();
name->get_AsCells()->idx_get(0)->set_Value(ObjectExt::Box<String>(u"New name"));
```

## **डेटा सीरीज़ फ़िल रंग सेट करें**

Aspose.Slides for C++ आपको प्लॉट एरिया के अंदर चार्ट सीरीज़ के लिए ऑटोमैटिक फ़िल रंग सेट करने का तरीका प्रदान करता है:

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) क्लास का एक इंस्टेंस बनाएं।
1. उसके इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
1. अपनी पसंदीदा प्रकार के आधार पर डिफ़ॉल्ट डेटा के साथ चार्ट जोड़ें (नीचे के उदाहरण में हमने `ChartType::ClusteredColumn` का उपयोग किया)।
1. चार्ट सीरीज़ तक पहुंचें और फ़िल रंग को Automatic पर सेट करें।
1. प्रस्तुति को PPTX फ़ाइल में सहेजें।

यह C++ कोड दिखाता है कि चार्ट सीरीज़ के लिए ऑटोमैटिक फ़िल रंग कैसे सेट किया जाता है:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// क्लस्टर्ड कॉलम चार्ट बनाता है
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 50.0f, 600.0f, 400.0f);

// सीरीज़ फ़िल फ़ॉर्मेट को ऑटोमैटिक सेट करता है
for (const auto& series : chart->get_ChartData()->get_Series())
{
    series->GetAutomaticSeriesColor();
}

// प्रेजेंटेशन फ़ाइल को डिस्क पर लिखता है
presentation->Save(u"AutoFillSeries_out.pptx", SaveFormat::Pptx);
```

## **डेटा सीरीज़ उलटा फ़िल रंग सेट करें**

Aspose.Slides आपको प्लॉट एरिया के अंदर चार्ट सीरीज़ के लिए उलटा फ़िल रंग सेट करने का तरीका प्रदान करता है:

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) क्लास का एक इंस्टेंस बनाएं।
1. उसके इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
1. अपनी पसंदीदा प्रकार के आधार पर डिफ़ॉल्ट डेटा के साथ चार्ट जोड़ें (नीचे के उदाहरण में हमने `ChartType::ClusteredColumn` का उपयोग किया)।
1. चार्ट सीरीज़ तक पहुंचें और फ़िल रंग को invert पर सेट करें।
1. प्रस्तुति को PPTX फ़ाइल में सहेजें।

यह C++ कोड इस ऑपरेशन को प्रदर्शित करता है:

```cpp
Color inverColor = Color::get_Red();
    
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

auto workBook = chart->get_ChartData()->get_ChartDataWorkbook();
auto chartData = chart->get_ChartData();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

// नई सीरीज़ और श्रेणियां जोड़ता है
chartData->get_Series()->Add(workBook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chartData->get_Categories()->Add(workBook->GetCell(0, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chartData->get_Categories()->Add(workBook->GetCell(0, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chartData->get_Categories()->Add(workBook->GetCell(0, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// पहली चार्ट सीरीज़ लेता है और उसकी सीरीज़ डेटा भरता है।
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

## **चार्ट सीरीज़ के लिए उलटा फ़िल रंग सेट करें**

Aspose.Slides आपको `IChartDataPoint::set_InvertIfNegative()` और `ChartDataPoint.set_InvertIfNegative()` मेथड्स के माध्यम से उलटा सेट करने की अनुमति देता है। जब इन मेथड्स का उपयोग करके उलटा सेट किया जाता है, तो डेटा पॉइंट नकारात्मक मान मिलने पर अपने रंग उलट लेता है। 

यह C++ कोड इस ऑपरेशन को दर्शाता है:

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

Aspose.Slides for C++ आपको इस तरह से किसी विशिष्ट चार्ट सीरीज़ के `DataPoints` डेटा को साफ़ करने की अनुमति देता है:

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) क्लास का एक इंस्टेंस बनाएं।
2. उसके इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
3. उसके इंडेक्स द्वारा चार्ट का रेफ़रेंस प्राप्त करें।
4. सभी चार्ट `DataPoints` को इटररेट करें और `XValue` तथा `YValue` को null सेट करें।
5. विशिष्ट चार्ट सीरीज़ के लिए सभी `DataPoints` को साफ़ करें।
6. संशोधित प्रस्तुति को PPTX फ़ाइल में लिखें।

यह C++ कोड इस ऑपरेशन को दर्शाता है:

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

## **डेटा सीरीज़ गैप चौड़ाई सेट करें**

Aspose.Slides for C++ आपको **`set_GapWidth()`** मेथड के माध्यम से एक सीरीज़ की गैप चौड़ाई सेट करने का तरीका प्रदान करता है:

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) क्लास का एक इंस्टेंस बनाएं।
1. पहली स्लाइड तक पहुंचें।
1. डिफ़ॉल्ट डेटा के साथ चार्ट जोड़ें।
1. किसी भी चार्ट सीरीज़ तक पहुंचें।
1. `GapWidth` प्रॉपर्टी सेट करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल में लिखें।

यह C++ कोड दिखाता है कि सीरीज़ की गैप चौड़ाई कैसे सेट की जाती है:

```cpp
// खाली प्रस्तुति बनाता है
auto presentation = System::MakeObject<Presentation>();

// प्रस्तुति की पहली स्लाइड तक पहुंचता है
auto slide = presentation->get_Slides()->idx_get(0);

// डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ता है
auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 0.0f, 0.0f, 500.0f, 500.0f);

// चार्ट डेटा शीट का इंडेक्स सेट करता है
int32_t worksheetIndex = 0;

// चार्ट डेटा वर्कशीट प्राप्त करता है
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// सीरीज़ जोड़ता है
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 2, ObjectExt::Box<String>(u"Series 2")), chart->get_Type());

// श्रेणियां जोड़ता है
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// दूसरी चार्ट सीरीज़ लेता है
auto series = chart->get_ChartData()->get_Series()->idx_get(1);
auto dataPoints = series->get_DataPoints();

// सीरीज़ डेटा को भरता है
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

**क्या एकल चार्ट में बहुत अधिक सीरीज़ रखने की कोई सीमा है?**

Aspose.Slides सीरीज़ की संख्या पर कोई निर्धारित सीमा नहीं लगाता। व्यावहारिक सीमा चार्ट की पढ़ने योग्यता और आपके एप्लिकेशन की उपलब्ध मेमोरी पर निर्भर करती है।

**यदि क्लस्टर के भीतर कॉलम बहुत निकट या बहुत दूर हैं तो क्या करें?**

उस सीरीज़ (या उसके पैरेंट सीरीज़ ग्रुप) की गैप चौड़ाई सेटिंग को समायोजित करें। मान बढ़ाने से कॉलम के बीच की दूरी बढ़ेगी, जबकि घटाने से वे एक-दूसरे के करीब आ जाएंगे।