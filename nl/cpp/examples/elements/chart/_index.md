---
title: Grafiek
type: docs
weight: 60
url: /nl/cpp/examples/elements/chart/
keywords:
- codevoorbeeld
- grafiek
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Beheers grafieken met Aspose.Slides for C++: maak, formatteer, koppel gegevens en exporteer grafieken in PPT, PPTX en ODP met C++-voorbeelden."
---
Voorbeelden voor het toevoegen, benaderen, verwijderen en bijwerken van verschillende grafiektype​n met **Aspose.Slides for C++**. De onderstaande fragmenten demonstreren basisgrafiekbewerkingen.

## **Grafiek toevoegen**

Deze methode voegt een eenvoudige gebiedsgrafiek toe aan de eerste dia.

```cpp
static void AddChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Voeg een eenvoudige vlakgrafiek toe aan de eerste dia.
    auto chart = slide->get_Shapes()->AddChart(ChartType::Area, 50, 50, 400, 300);

    presentation->Dispose();
}
```

## **Grafiek benaderen**

Nadat u een grafiek hebt gemaakt, kunt u deze ophalen via de vormcollectie.

```cpp
static void AccessChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 50, 50, 400, 300);

    // Toegang tot de eerste grafiek op de dia.
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

## **Grafiek verwijderen**

De onderstaande code verwijdert een grafiek van een dia.

```cpp
static void RemoveChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 300);

    // Verwijder de grafiek.
    slide->get_Shapes()->Remove(chart);

    presentation->Dispose();
}
```

## **Gegevens van grafiek bijwerken**

U kunt grafiekeigenschappen wijzigen, zoals de titel.

```cpp
static void UpdateChartData()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 50, 50, 400, 300);

    // Wijzig de grafiektitel.
    chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sales Report");

    presentation->Dispose();
}
```