---
title: Personalizar leyendas de gráficos en presentaciones usando С++
linktitle: Leyenda del gráfico
type: docs
url: /es/cpp/chart-legend/
keywords:
- leyenda de gráfico
- posición de la leyenda
- tamaño de fuente
- PowerPoint
- presentación
- С++
- Aspose.Slides
description: "Personaliza las leyendas de los gráficos con Aspose.Slides para С++ para optimizar las presentaciones de PowerPoint con un formato de leyenda adaptado."
---

## **Posicionamiento de la leyenda**
Para establecer las propiedades de la leyenda, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
- Obtenga la referencia de la diapositiva.
- Agregue un gráfico a la diapositiva.
- Establezca las propiedades de la leyenda.
- Guarde la presentación como un archivo PPTX.

En el ejemplo a continuación, hemos establecido la posición y el tamaño de la leyenda del gráfico.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetlegendCustomOptions-SetlegendCustomOptions.cpp" >}}


## **Establecer el tamaño de fuente de una leyenda**
Aspose.Slides para C++ permite a los desarrolladores establecer el tamaño de fuente de la leyenda. Por favor, siga los pasos a continuación:

- Instancie la clase Presentation.
- Cree el gráfico predeterminado.
- Establezca el tamaño de fuente.
- Establezca el valor mínimo del eje.
- Establezca el valor máximo del eje.
- Guarde la presentación en disco.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfLegend-SettingFontSizeOfLegend.cpp" >}}




## **Establecer el tamaño de fuente de una leyenda individual**
Aspose.Slides para C++ permite a los desarrolladores establecer el tamaño de fuente de las entradas individuales de la leyenda. Por favor, siga los pasos a continuación:

- Instancie la clase Presentation.
- Cree el gráfico predeterminado.
- Acceda a la entrada de la leyenda.
- Establezca el tamaño de fuente.
- Establezca el valor mínimo del eje.
- Establezca el valor máximo del eje.
- Guarde la presentación en disco.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfIndividualLegend-SettingFontSizeOfIndividualLegend.cpp" >}}

## **Preguntas frecuentes**

**¿Puedo habilitar la leyenda para que el gráfico reserve espacio automáticamente en lugar de superponerse?**

Sí. Use el modo sin superposición ([set_Overlay(false)](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_overlay/)); en este caso, el área de trazado se reducirá para acomodar la leyenda.

**¿Puedo crear etiquetas de leyenda de varias líneas?**

Sí. Las etiquetas largas se ajustan automáticamente cuando el espacio es insuficiente; los saltos de línea forzados son compatibles mediante caracteres de nueva línea en el nombre de la serie.

**¿Cómo hago que la leyenda siga el esquema de colores del tema de la presentación?**

No establezca colores, rellenos o fuentes explícitos para la leyenda o su texto. Así heredarán del tema y se actualizarán correctamente cuando el diseño cambie.