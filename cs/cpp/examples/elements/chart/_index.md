---
title: Graf
type: docs
weight: 60
url: /cs/cpp/examples/elements/chart/
keywords:
- ukázka kódu
- graf
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Ovládejte grafy pomocí Aspose.Slides pro C++: vytvářejte, formátujte, připojujte data a exportujte grafy do PPT, PPTX a ODP s příklady v C++."
---
Příklady přidávání, přístupu, odstraňování a aktualizace různých typů grafů pomocí **Aspose.Slides for C++**. Níže uvedené úryvky demonstrují základní operace s grafy.

## **Přidat graf**

Tato metoda přidá jednoduchý plošný graf na první snímek.

```cpp
static void AddChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Přidá jednoduchý plošný graf na první snímek.
    auto chart = slide->get_Shapes()->AddChart(ChartType::Area, 50, 50, 400, 300);

    presentation->Dispose();
}
```

## **Přístup k grafu**

Po vytvoření grafu jej můžete získat ze sbírky tvarů.

```cpp
static void AccessChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 50, 50, 400, 300);

    // Přístup k prvnímu grafu na snímku.
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

## **Odstranit graf**

Následující kód odstraní graf ze snímku.

```cpp
static void RemoveChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 300);

    // Odstraní graf.
    slide->get_Shapes()->Remove(chart);

    presentation->Dispose();
}
```

## **Aktualizovat data grafu**

Můžete změnit vlastnosti grafu, například název.

```cpp
static void UpdateChartData()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 50, 50, 400, 300);

    // Změní název grafu.
    chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sales Report");

    presentation->Dispose();
}
```