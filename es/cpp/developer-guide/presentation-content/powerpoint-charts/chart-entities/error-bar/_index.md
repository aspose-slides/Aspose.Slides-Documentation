---
title: Barra de Error
type: docs
url: /cpp/error-bar/
---

## **Agregar Barra de Error**
Aspose.Slides para C++ proporciona una API simple para gestionar los valores de las barras de error. El código de muestra se aplica al usar un tipo de valor personalizado. Para especificar un valor, utiliza la propiedad **ErrorBarCustomValues** de un punto de datos específico en la **DataPoints** colección de la serie:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Agrega un gráfico de burbujas en la diapositiva deseada.
1. Accede a la primera serie del gráfico y establece el formato de la barra de error X.
1. Accede a la primera serie del gráfico y establece el formato de la barra de error Y.
1. Estableciendo los valores y el formato de las barras.
1. Escribe la presentación modificada en un archivo PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddErrorBars-AddErrorBars.cpp" >}}


## **Agregar Barra de Error Personalizada**
Aspose.Slides para C++ proporciona una API simple para gestionar los valores de las barras de error personalizadas. El código de muestra se aplica cuando la propiedad **IErrorBarsFormat.ValueType** es igual a **Custom**. Para especificar un valor, utiliza la propiedad **ErrorBarCustomValues** de un punto de datos específico en la **DataPoints** colección de la serie:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Agrega un gráfico de burbujas en la diapositiva deseada.
1. Accede a la primera serie del gráfico y establece el formato de la barra de error X.
1. Accede a la primera serie del gráfico y establece el formato de la barra de error Y.
1. Accede a los puntos de datos individuales de la serie del gráfico y establece los valores de la Barra de Error para un punto de datos de serie individual.
1. Estableciendo los valores y el formato de las barras.
1. Escribe la presentación modificada en un archivo PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddCustomError-AddCustomError.cpp" >}}