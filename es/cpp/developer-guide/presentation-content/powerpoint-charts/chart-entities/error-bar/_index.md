---
title: Personalizar barras de error en gráficos de presentación con C++
linktitle: Barra de error
type: docs
url: /es/cpp/error-bar/
keywords:
- barra de error
- valor personalizado
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Aprenda cómo añadir y personalizar barras de error en gráficos con Aspose.Slides para C++ — optimice las visualizaciones de datos en presentaciones de PowerPoint."
---
## **Resumen**

Este artículo explica cómo trabajar con barras de error en gráficos de presentaciones utilizando Aspose.Slides. Muestra cómo añadir barras de error a una serie de gráfico, configurar los ajustes de barra de error X e Y, y aplicar diferentes tipos de valores como fijo, porcentual y personalizado.

También demuestra cómo asignar valores de barra de error personalizados para puntos de datos individuales en una serie mediante la colección de puntos de datos correspondiente. Además, el artículo incluye notas breves sobre el comportamiento de las barras de error durante la exportación, su compatibilidad con marcadores y etiquetas de datos, y dónde encontrar las clases y enumeraciones de referencia de la API relacionadas.

## **Agregar barras de error**
Aspose.Slides for C++ proporciona una API sencilla para gestionar los valores de las barras de error. El código de ejemplo se aplica cuando se utiliza un tipo de valor personalizado. Para especificar un valor, use la propiedad **ErrorBarCustomValues** de un punto de datos concreto en la colección **DataPoints** de la serie:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/).
1. Añadir un gráfico de burbujas en la diapositiva deseada.
1. Acceder a la primera serie del gráfico y establecer el formato de barra de error X.
1. Acceder a la primera serie del gráfico y establecer el formato de barra de error Y.
1. Establecer los valores y el formato de las barras.
1. Guardar la presentación modificada en un archivo PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddErrorBars-AddErrorBars.cpp" >}}

## **Agregar barras de error personalizadas**
Aspose.Slides for C++ proporciona una API sencilla para gestionar valores de barras de error personalizados. El código de ejemplo se aplica cuando la propiedad **IErrorBarsFormat.ValueType** es igual a **Custom**. Para especificar un valor, use la propiedad **ErrorBarCustomValues** de un punto de datos concreto en la colección **DataPoints** de la serie:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/).
1. Añadir un gráfico de burbujas en la diapositiva deseada.
1. Acceder a la primera serie del gráfico y establecer el formato de barra de error X.
1. Acceder a la primera serie del gráfico y establecer el formato de barra de error Y.
1. Acceder a los puntos de datos individuales de la serie del gráfico y establecer los valores de la barra de error para un punto de datos específico.
1. Establecer los valores y el formato de las barras.
1. Guardar la presentación modificada en un archivo PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddCustomError-AddCustomError.cpp" >}}

## **Preguntas frecuentes**

**¿Qué ocurre con las barras de error al exportar una presentación a PDF o imágenes?**

Se renderizan como parte del gráfico y se conservan durante la conversión junto con el resto del formato del gráfico, siempre que se utilice una versión o motor compatible.

**¿Se pueden combinar las barras de error con marcadores y etiquetas de datos?**

Sí. Las barras de error son un elemento independiente y son compatibles con marcadores y etiquetas de datos; si los elementos se superponen, puede ser necesario ajustar el formato.

**¿Dónde puedo encontrar la lista de propiedades y enumeraciones para trabajar con barras de error en la API?**

En la referencia de la API: la clase [ErrorBarsFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/errorbarsformat/) y las enumeraciones relacionadas [ErrorBarType](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/errorbartype/) y [ErrorBarValueType](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/errorbarvaluetype/).