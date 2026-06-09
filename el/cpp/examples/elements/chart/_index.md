---
title: Διάγραμμα
type: docs
weight: 60
url: /el/cpp/examples/elements/chart/
keywords:
- παράδειγμα κώδικα
- διάγραμμα
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Κατακτήστε τα διαγράμματα με Aspose.Slides for C++: δημιουργήστε, μορφοποιήστε, συνδέστε δεδομένα και εξάγετε διαγράμματα σε PPT, PPTX και ODP με παραδείγματα C++."
---
Παραδείγματα για προσθήκη, πρόσβαση, αφαίρεση και ενημέρωση διαφορετικών τύπων διαγραμμάτων με **Aspose.Slides for C++**. Τα παρακάτω αποσπάσματα επιδεικνύουν βασικές λειτουργίες διαγραμμάτων.

## **Προσθήκη Διαγράμματος**

Αυτή η μέθοδος προσθέτει ένα απλό διάγραμμα περιοχής στην πρώτη διαφάνεια.

```cpp
static void AddChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Προσθέτει ένα απλό διάγραμμα περιοχής στην πρώτη διαφάνεια.
    auto chart = slide->get_Shapes()->AddChart(ChartType::Area, 50, 50, 400, 300);

    presentation->Dispose();
}
```

## **Πρόσβαση σε Διάγραμμα**

Μετά τη δημιουργία ενός διαγράμματος, μπορείτε να το ανακτήσετε μέσω της συλλογής σχήματος.

```cpp
static void AccessChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 50, 50, 400, 300);

    // Πρόσβαση στο πρώτο διάγραμμα στη διαφάνεια.
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

## **Αφαίρεση Διαγράμματος**

Ο παρακάτω κώδικας αφαιρεί ένα διάγραμμα από μια διαφάνεια.

```cpp
static void RemoveChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 300);

    // Αφαιρέστε το διάγραμμα.
    slide->get_Shapes()->Remove(chart);

    presentation->Dispose();
}
```

## **Ενημέρωση Δεδομένων Διαγράμματος**

Μπορείτε να αλλάξετε τις ιδιότητες του διαγράμματος, όπως ο τίτλος.

```cpp
static void UpdateChartData()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 50, 50, 400, 300);

    // Αλλάξτε τον τίτλο του διαγράμματος.
    chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sales Report");

    presentation->Dispose();
}
```