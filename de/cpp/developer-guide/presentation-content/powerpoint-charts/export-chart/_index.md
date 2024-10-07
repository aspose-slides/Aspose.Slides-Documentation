---
title: Diagramm exportieren
type: docs
weight: 90
url: /cpp/export-chart/
keywords:
- diagramm
- diagramm bild
- diagramm bild extrahieren
- PowerPoint
- präsentation
- C++
- Aspose.Slides für C++
description: "Diagrammbilder aus PowerPoint-Präsentationen in C++ abrufen"
---

## **Diagrammbild abrufen**
Aspose.Slides für C++ bietet Unterstützung zum Extrahieren von Bildern eines bestimmten Diagramms. Unten ist ein Beispiel angegeben.

```cpp
auto präsentation = MakeObject<Presentation>(u"test.pptx");

auto folie = präsentation->get_Slide(0);
auto diagramm = folie->get_Shapes()->AddChart(ChartType::ClusteredColumn, 0, 0, 500, 500);

auto bild = diagramm->GetImage();
bild->Save(u"bild.png", ImageFormat::Png);
bild->Dispose();

präsentation->Dispose();
```