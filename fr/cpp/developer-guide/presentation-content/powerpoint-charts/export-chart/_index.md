---
title: Exporter un graphique
type: docs
weight: 90
url: /fr/cpp/export-chart/
keywords:
- graphique
- image de graphique
- extraire image de graphique
- PowerPoint
- présentation
- C++
- Aspose.Slides pour C++
description: "Obtenez des images de graphiques à partir de présentations PowerPoint en C++"
---

## **Obtenir l'image du graphique**
Aspose.Slides pour C++ prend en charge l'extraction de l'image d'un graphique spécifique. Un exemple de code est donné ci-dessous.

```cpp
auto presentation = MakeObject<Presentation>(u"test.pptx");

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 0, 0, 500, 500);

auto image = chart->GetImage();
image->Save(u"image.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```