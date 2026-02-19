---
title: Graphique
type: docs
weight: 60
url: /fr/cpp/examples/elements/chart/
keywords:
- exemple de code
- graphique
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Maîtrisez les graphiques avec Aspose.Slides for C++ : créez, formatez, liez des données et exportez des graphiques aux formats PPT, PPTX et ODP avec des exemples C++."
---
Exemples d'ajout, d'accès, de suppression et de mise à jour de différents types de graphiques avec **Aspose.Slides for C++**. Les extraits ci‑dessous démontrent les opérations de base sur les graphiques.

## **Ajouter un graphique**

Cette méthode ajoute un graphique en aires simple à la première diapositive.

```cpp
static void AddChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Ajouter un graphique en aires simple à la première diapositive.
    auto chart = slide->get_Shapes()->AddChart(ChartType::Area, 50, 50, 400, 300);

    presentation->Dispose();
}
```

## **Accéder à un graphique**

Après avoir créé un graphique, vous pouvez le récupérer via la collection de formes.

```cpp
static void AccessChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 50, 50, 400, 300);

    // Accéder au premier graphique de la diapositive.
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

## **Supprimer un graphique**

Le code suivant supprime un graphique d'une diapositive.

```cpp
static void RemoveChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 300);

    // Supprimer le graphique.
    slide->get_Shapes()->Remove(chart);

    presentation->Dispose();
}
```

## **Mettre à jour les données du graphique**

Vous pouvez modifier les propriétés du graphique, telles que le titre.

```cpp
static void UpdateChartData()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 50, 50, 400, 300);

    // Modifier le titre du graphique.
    chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sales Report");

    presentation->Dispose();
}
```