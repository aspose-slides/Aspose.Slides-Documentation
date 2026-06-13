---
title: चार्ट
type: docs
weight: 60
url: /hi/cpp/examples/elements/chart/
keywords:
- कोड उदाहरण
- चार्ट
- पॉवरपॉइंट
- ऑपनडॉक्युमेंट
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ चार्ट को महारत हासिल करें: बनाएं, स्वरूपित करें, डेटा बाइंड करें, और C++ उदाहरणों के साथ PPT, PPTX और ODP में चार्ट निर्यात करें।"
---
विभिन्न चार्ट प्रकारों को जोड़ने, एक्सेस करने, हटाने और अपडेट करने के उदाहरण **Aspose.Slides for C++** के साथ। नीचे दिए गए स्निपेट्स बुनियादी चार्ट संचालन को दर्शाते हैं।

## **एक चार्ट जोड़ें**

यह मेथड पहले स्लाइड में एक साधारण एरिया चार्ट जोड़ता है।

```cpp
static void AddChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // पहले स्लाइड में एक साधारण एरिया चार्ट जोड़ें।
    auto chart = slide->get_Shapes()->AddChart(ChartType::Area, 50, 50, 400, 300);

    presentation->Dispose();
}
```

## **एक चार्ट को एक्सेस करें**

एक चार्ट बनाने के बाद, आप इसे शेड संग्रह के माध्यम से पुनः प्राप्त कर सकते हैं।

```cpp
static void AccessChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 50, 50, 400, 300);

    // स्लाइड पर पहला चार्ट एक्सेस करें।
    auto firstChart = SharedPtr<IChart>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IChart>(shape))
        {
            firstChart = ExplicitCast<IChart>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **एक चार्ट हटाएँ**

निम्नलिखित कोड एक स्लाइड से चार्ट को हटाता है।

```cpp
static void RemoveChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 300);

    // चार्ट हटाएँ।
    slide->get_Shapes()->Remove(chart);

    presentation->Dispose();
}
```

## **चार्ट डेटा अपडेट करें**

आप शीर्षक जैसे चार्ट प्रॉपर्टीज़ को बदल सकते हैं।

```cpp
static void UpdateChartData()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 50, 50, 400, 300);

    // चार्ट शीर्षक बदलें।
    chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sales Report");

    presentation->Dispose();
}
```