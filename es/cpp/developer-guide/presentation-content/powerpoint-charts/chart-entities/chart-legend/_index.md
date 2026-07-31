---
title: Personalizar leyendas de gráficos en presentaciones usando C++
linktitle: Leyenda del gráfico
type: docs
url: /es/cpp/chart-legend/
keywords:
- leyenda de gráfico
- posición de la leyenda
- tamaño de fuente
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Personaliza las leyendas de los gráficos con Aspose.Slides para C++ y optimiza las presentaciones de PowerPoint con un formato de leyenda a medida."
---
## **Descripción general**

Aspose.Slides ofrece opciones para personalizar las leyendas de los gráficos en presentaciones de PowerPoint. Este artículo muestra cómo posicionar y dimensionar una leyenda, establecer el tamaño de fuente para toda la leyenda y aplicar formato a una entrada individual de la leyenda.

También cubre varios comportamientos relacionados en las preguntas frecuentes, incluido el uso del modo sin superposición para que el área del gráfico deje espacio a la leyenda, permitir que etiquetas largas de la leyenda se ajusten o usen saltos de línea, y permitir que el formato de la leyenda herede del tema de la presentación cuando no se apliquen ajustes explícitos de texto y relleno.

## **Posicionamiento de la leyenda**
Para establecer las propiedades de la leyenda, siga los pasos a continuación:

- Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/).
- Obtener la referencia de la diapositiva.
- Añadir un gráfico a la diapositiva.
- Configurar las propiedades de la leyenda.
- Guardar la presentación como archivo PPTX.

En el ejemplo que se muestra a continuación, hemos establecido la posición y el tamaño de la leyenda del gráfico.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetlegendCustomOptions-SetlegendCustomOptions.cpp" >}}

## **Establecer el tamaño de fuente de una leyenda**
Aspose.Slides for C++ permite a los desarrolladores establecer el tamaño de fuente de la leyenda. Siga los pasos a continuación:

- Instanciar la clase Presentation.
- Crear el gráfico predeterminado.
- Establecer el tamaño de fuente.
- Establecer el valor mínimo del eje.
- Establecer el valor máximo del eje.
- Guardar la presentación en disco.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfLegend-SettingFontSizeOfLegend.cpp" >}}

## **Establecer el tamaño de fuente de una entrada individual de la leyenda**
Aspose.Slides for C++ permite a los desarrolladores establecer el tamaño de fuente de entradas individuales de la leyenda. Siga los pasos a continuación:

- Instanciar la clase Presentation.
- Crear el gráfico predeterminado.
- Acceder a la entrada de la leyenda.
- Establecer el tamaño de fuente.
- Establecer el valor mínimo del eje.
- Establecer el valor máximo del eje.
- Guardar la presentación en disco.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfIndividualLegend-SettingFontSizeOfIndividualLegend.cpp" >}}

## **Preguntas frecuentes**

**¿Puedo activar la leyenda para que el gráfico reserve espacio automáticamente en lugar de superponerse?**

Sí. Utilice el modo sin superposición ([set_Overlay(false)](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/legend/set_overlay/)); en este caso, el área del gráfico se reducirá para acomodar la leyenda.

**¿Puedo crear etiquetas de leyenda de varias líneas?**

Sí. Las etiquetas largas se ajustan automáticamente cuando el espacio es insuficiente; los saltos de línea obligatorios se admiten mediante caracteres de nueva línea en el nombre de la serie.

**¿Cómo hago que la leyenda siga el esquema de colores del tema de la presentación?**

No establezca colores/rellenos/fuentes explícitos para la leyenda o su texto. De este modo heredarán del tema y se actualizarán correctamente cuando cambie el diseño.