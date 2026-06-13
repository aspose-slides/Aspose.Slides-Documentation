---
title: टेबल
type: docs
weight: 120
url: /hi/cpp/examples/elements/table/
keywords:
- कोड उदाहरण
- टेबल
- पावरपॉइंट
- ओपनडॉक्युमेंट
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ में टेबल के साथ काम करें: बनाएं, स्वरूपित करें, सेल मर्ज करें, शैली लागू करें, डेटा आयात करें, और C++ उदाहरणों के साथ PPT, PPTX, और ODP के लिए निर्यात करें।"
---
**Aspose.Slides for C++** का उपयोग करके टेबल जोड़ने, एक्सेस करने, हटाने और सेल मर्ज करने के उदाहरण।

## **टेबल जोड़ें**

दो पंक्तियों और दो स्तंभों वाली एक साधारण टेबल बनाएं।

```cpp
static void AddTable()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto widths = MakeArray<double>({ 80, 80 });
    auto heights = MakeArray<double>({ 30, 30 });
    auto table = slide->get_Shapes()->AddTable(50, 50, widths, heights);

    presentation->Dispose();
}
```

## **टेबल एक्सेस करें**

स्लाइड पर पहली टेबल शेप प्राप्त करें।

```cpp
static void AccessTable()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto widths = MakeArray<double>({ 80, 80 });
    auto heights = MakeArray<double>({ 30, 30 });
    auto table = slide->get_Shapes()->AddTable(50, 50, widths, heights);

    // स्लाइड पर पहली टेबल तक पहुंचें।
    auto firstTable = SharedPtr<ITable>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<ITable>(shape))
        {
            firstTable = ExplicitCast<ITable>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **टेबल हटाएं**

स्लाइड से टेबल को हटाएं।

```cpp
static void RemoveTable()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto widths = MakeArray<double>({ 80, 80 });
    auto heights = MakeArray<double>({ 30, 30 });
    auto table = slide->get_Shapes()->AddTable(50, 50, widths, heights);

    slide->get_Shapes()->Remove(table);

    presentation->Dispose();
}
```

## **टेबल सेल्स मर्ज करें**

टेबल के आस-पास के सेल्स को एकल सेल में मर्ज करें।

```cpp
static void MergeTableCells()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto widths = MakeArray<double>({ 80, 80 });
    auto heights = MakeArray<double>({ 30, 30 });
    auto table = slide->get_Shapes()->AddTable(50, 50, widths, heights);

    // सेल को मर्ज करें।
    table->MergeCells(table->idx_get(0, 0), table->idx_get(1, 1), false);

    presentation->Dispose();
}
```