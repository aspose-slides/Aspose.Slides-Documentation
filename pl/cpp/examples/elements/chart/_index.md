---
title: Wykres
type: docs
weight: 60
url: /pl/cpp/examples/elements/chart/
keywords:
- przykład kodu
- wykres
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Mistrzostwo w wykresach z Aspose.Slides dla C++: twórz, formatuj, powiązuj dane i eksportuj wykresy w formatach PPT, PPTX i ODP z przykładami w C++."
---
Przykłady dodawania, uzyskiwania dostępu, usuwania i aktualizowania różnych typów wykresów przy użyciu **Aspose.Slides for C++**. Poniższe fragmenty kodu demonstrują podstawowe operacje na wykresach.

## **Dodaj wykres**

Ta metoda dodaje prosty wykres powierzchniowy do pierwszego slajdu.

```cpp
static void AddChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Dodaj prosty wykres powierzchniowy do pierwszego slajdu.
    auto chart = slide->get_Shapes()->AddChart(ChartType::Area, 50, 50, 400, 300);

    presentation->Dispose();
}
```

## **Uzyskaj dostęp do wykresu**

Po utworzeniu wykresu możesz go pobrać z kolekcji kształtów.

```cpp
static void AccessChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 50, 50, 400, 300);

    // Uzyskaj dostęp do pierwszego wykresu na slajdzie.
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

## **Usuń wykres**

Poniższy kod usuwa wykres ze slajdu.

```cpp
static void RemoveChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 300);

    // Usuń wykres.
    slide->get_Shapes()->Remove(chart);

    presentation->Dispose();
}
```

## **Aktualizuj dane wykresu**

Możesz zmienić właściwości wykresu, takie jak tytuł.

```cpp
static void UpdateChartData()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 50, 50, 400, 300);

    // Zmień tytuł wykresu.
    chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sales Report");

    presentation->Dispose();
}
```