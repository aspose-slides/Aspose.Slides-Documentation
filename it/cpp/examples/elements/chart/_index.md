---
title: Grafico
type: docs
weight: 60
url: /it/cpp/examples/elements/chart/
keywords:
- esempio di codice
- grafico
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Padroneggia i grafici con Aspose.Slides for C++: crea, formatta, collega dati ed esporta grafici in PPT, PPTX e ODP con esempi C++."
---
Esempi di aggiunta, accesso, rimozione e aggiornamento di diversi tipi di grafico con **Aspose.Slides for C++**. Il codice sottostante dimostra le operazioni di base sui grafici.

## **Aggiungi un grafico**

Questo metodo aggiunge un semplice grafico ad area alla prima diapositiva.

```cpp
static void AddChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Aggiungi un semplice grafico ad area alla prima diapositiva.
    auto chart = slide->get_Shapes()->AddChart(ChartType::Area, 50, 50, 400, 300);

    presentation->Dispose();
}
```

## **Accedi a un grafico**

Dopo aver creato un grafico, è possibile recuperarlo tramite la raccolta di forme.

```cpp
static void AccessChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 50, 50, 400, 300);

    // Accedi al primo grafico sulla diapositiva.
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

## **Rimuovi un grafico**

Il codice seguente rimuove un grafico da una diapositiva.

```cpp
static void RemoveChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 300);

    // Rimuovi il grafico.
    slide->get_Shapes()->Remove(chart);

    presentation->Dispose();
}
```

## **Aggiorna i dati del grafico**

È possibile modificare le proprietà del grafico, come il titolo.

```cpp
static void UpdateChartData()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 50, 50, 400, 300);

    // Cambia il titolo del grafico.
    chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sales Report");

    presentation->Dispose();
}
```