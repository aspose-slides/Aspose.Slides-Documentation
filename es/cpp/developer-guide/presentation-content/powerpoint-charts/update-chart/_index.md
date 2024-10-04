---
title: Actualizar Gráfico
type: docs
weight: 10
url: /es/cpp/update-chart/
---


## **Actualizar Gráfico**
Aspose.Slides para C++ ha proporcionado la API más simple para actualizar gráficos de la manera más fácil. Para actualizar un gráfico en una diapositiva:

- Abre una instancia de la clase Presentation que contenga el gráfico.
- Obtén la referencia de una diapositiva usando su índice.
- Recorre todas las formas para encontrar el gráfico deseado.
- Accede a la hoja de datos del gráfico.
- Modifica los datos de la serie del gráfico cambiando los valores de la serie.
- Agrega una nueva serie y completa los datos dentro de ella.
- Escribe la presentación modificada como un archivo PPTX.

Los ejemplos de código que siguen cómo actualizar un gráfico.


{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ExistingChart-ExistingChart.cpp" >}}