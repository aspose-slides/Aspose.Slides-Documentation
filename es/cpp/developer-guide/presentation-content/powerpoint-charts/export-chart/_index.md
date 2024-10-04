---
title: Exportar Gráfico
type: docs
weight: 90
url: /es/cpp/export-chart/
keywords:
- gráfico
- imagen del gráfico
- extraer imagen del gráfico
- PowerPoint
- presentación
- C++
- Aspose.Slides para C++
description: "Obtén imágenes de gráficos de presentaciones de PowerPoint en C++"
---

## **Obtener Imagen del Gráfico**
Aspose.Slides para C++ proporciona soporte para extraer la imagen de un gráfico específico. A continuación se muestra un ejemplo de muestra.

```cpp
auto presentation = MakeObject<Presentation>(u"test.pptx");

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 0, 0, 500, 500);

auto image = chart->GetImage();
image->Save(u"image.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```