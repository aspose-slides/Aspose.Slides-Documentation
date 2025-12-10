---
title: Personalizar barras de error en gráficos de presentación usando С++
linktitle: Barra de error
type: docs
url: /es/cpp/error-bar/
keywords:
- barra de error
- valor personalizado
- PowerPoint
- presentación
- С++
- Aspose.Slides
description: "Aprenda a agregar y personalizar barras de error en gráficas con Aspose.Slides para С++ — optimice la visualización de datos en presentaciones de PowerPoint."
---

## **Agregar barras de error**
Aspose.Slides for C++ proporciona una API sencilla para gestionar los valores de las barras de error. El código de ejemplo se aplica cuando se utiliza un tipo de valor personalizado. Para especificar un valor, use la propiedad **ErrorBarCustomValues** de un punto de datos específico en la colección **DataPoints** de la serie:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Añada un gráfico de burbujas en la diapositiva deseada.
1. Acceda a la primera serie del gráfico y establezca el formato de la barra de error X.
1. Acceda a la primera serie del gráfico y establezca el formato de la barra de error Y.
1. Establezca los valores y el formato de las barras.
1. Guarde la presentación modificada en un archivo PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddErrorBars-AddErrorBars.cpp" >}}

## **Agregar barras de error personalizadas**
Aspose.Slides for C++ proporciona una API sencilla para gestionar los valores personalizados de las barras de error. El código de ejemplo se aplica cuando la propiedad **IErrorBarsFormat.ValueType** es igual a **Custom**. Para especificar un valor, use la propiedad **ErrorBarCustomValues** de un punto de datos específico en la colección **DataPoints** de la serie:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Añada un gráfico de burbujas en la diapositiva deseada.
1. Acceda a la primera serie del gráfico y establezca el formato de la barra de error X.
1. Acceda a la primera serie del gráfico y establezca el formato de la barra de error Y.
1. Acceda a los puntos de datos individuales de la serie del gráfico y establezca los valores de la barra de error para un punto de datos individual.
1. Establezca los valores y el formato de las barras.
1. Guarde la presentación modificada en un archivo PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddCustomError-AddCustomError.cpp" >}}

## **Preguntas frecuentes**

**¿Qué ocurre con las barras de error al exportar una presentación a PDF o imágenes?**

Se renderizan como parte del gráfico y se conservan durante la conversión junto con el resto del formato del gráfico, siempre que se utilice una versión o renderizador compatible.

**¿Se pueden combinar las barras de error con marcadores y etiquetas de datos?**

Sí. Las barras de error son un elemento separado y son compatibles con marcadores y etiquetas de datos; si los elementos se superponen, puede ser necesario ajustar el formato.

**¿Dónde puedo encontrar la lista de propiedades y enums para trabajar con barras de error en la API?**

En la referencia de la API: la clase [ErrorBarsFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/errorbarsformat/) y los enums relacionados [ErrorBarType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/errorbartype/) y [ErrorBarValueType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/errorbarvaluetype/).