---
title: Personalizar gráficos 3D en presentaciones usando C++
linktitle: Gráfico 3D
type: docs
url: /es/cpp/3d-chart/
keywords:
- gráfico 3D
- rotación
- profundidad
- PowerPoint
- presentación
- С++
- Aspose.Slides
description: "Aprenda a crear y personalizar gráficos 3D en Aspose.Slides para C++, con compatibilidad para archivos PPT y PPTX—mejore sus presentaciones hoy."
---

## **Establecer las propiedades RotationX, RotationY y DepthPercents de un gráfico 3D**
Aspose.Slides for C++ ofrece una API sencilla para establecer estas propiedades. El siguiente artículo le ayudará a configurar diferentes propiedades como Rotación X, Rotación Y, **DepthPercents** etc. El código de ejemplo aplica la configuración de las propiedades mencionadas.

1. Crear una instancia de la clase [Presentación](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Acceder a la primera diapositiva.
1. Agregar un gráfico con datos predeterminados.
1. Establecer las propiedades Rotation3D.
1. Guardar la presentación modificada en un archivo PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagePropertiesCharts-ManagePropertiesCharts.cpp" >}}

## **Preguntas frecuentes**

**¿Qué tipos de gráfico admiten el modo 3D en Aspose.Slides?**

Aspose.Slides admite variantes 3D de gráficos de columnas, incluidos Column 3D, Clustered Column 3D, Stacked Column 3D y 100% Stacked Column 3D, junto con tipos 3D relacionados expuestos a través del enumerado [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/). Para obtener una lista exacta y actualizada, consulte los miembros de [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) en la referencia de la API de la versión instalada.

**¿Puedo obtener una imagen rasterizada de un gráfico 3D para un informe o la web?**

Sí. Puede exportar un gráfico a una imagen mediante la [API de gráfico](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) o [renderizar toda la diapositiva](/slides/es/cpp/convert-powerpoint-to-png/) a formatos como PNG o JPEG. Esto es útil cuando necesita una vista previa pixel perfecta o desea incrustar el gráfico en documentos, paneles de control o páginas web sin requerir PowerPoint.

**¿Qué tan eficiente es crear y renderizar gráficos 3D grandes?**

El rendimiento depende del volumen de datos y la complejidad visual. Para obtener los mejores resultados, mantenga los efectos 3D al mínimo, evite texturas pesadas en las paredes y áreas de trazado, limite la cantidad de puntos de datos por serie cuando sea posible y renderice a una salida de tamaño adecuado (resolución y dimensiones) para que coincida con la pantalla o los requisitos de impresión objetivo.