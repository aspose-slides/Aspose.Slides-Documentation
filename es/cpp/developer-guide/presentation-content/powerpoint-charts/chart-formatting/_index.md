---
title: Formato de gráficos de presentación en C++
linktitle: Formato de gráficos
type: docs
weight: 60
url: /es/cpp/chart-formatting/
keywords:
- formato de gráfico
- formato de gráfico
- entidad de gráfico
- propiedades de gráfico
- configuraciones de gráfico
- opciones de gráfico
- propiedades de fuente
- borde redondeado
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Aprenda a formatear gráficos en Aspose.Slides para C++ y mejore su presentación de PowerPoint con un estilo profesional y llamativo."
---

## **Formatear entidades de gráfico**
Aspose.Slides para C++ permite a los desarrolladores agregar gráficos personalizados a sus diapositivas desde cero. Este artículo explica cómo formatear diferentes entidades de gráfico, incluidas la categoría del gráfico y el eje de valores.

1. Crear una instancia de la clase **Presentation**.
1. Obtener la referencia de una diapositiva por su índice.
1. Agregar un gráfico con datos predeterminados junto con cualquiera de los tipos deseados (en este ejemplo usaremos ChartType.LineWithMarkers).
1. Acceder al eje de valores del gráfico y establecer las siguientes propiedades:
   1. Establecer **Line format** para las líneas de cuadrícula principales del eje de valores
   1. Establecer **Line format** para las líneas de cuadrícula secundarias del eje de valores
   1. Establecer **Number Format** para el eje de valores
   1. Establecer **Min, Max, Major and Minor units** para el eje de valores
   1. Establecer **Text Properties** para los datos del eje de valores
   1. Establecer **Title** para el eje de valores
   1. Establecer **Line Format** para el eje de valores
1. Acceder al eje de categoría del gráfico y establecer las siguientes propiedades:
   1. Establecer **Line format** para las líneas de cuadrícula principales del eje de categoría
   1. Establecer **Line format** para las líneas de cuadrícula secundarias del eje de categoría
   1. Establecer **Text Properties** para los datos del eje de categoría
   1. Establecer **Title** para el eje de categoría
   1. Establecer **Label Positioning** para el eje de categoría
   1. Establecer **Rotation Angle** para las etiquetas del eje de categoría
1. Acceder a la leyenda del gráfico y establecer **Text Properties** para ella
1. Mostrar leyendas del gráfico sin que se superpongan al gráfico
1. Acceder al **Secondary Value Axis** del gráfico y establecer las siguientes propiedades:
   1. Habilitar el **Value Axis** secundario
   1. Establecer **Line Format** para el **Value Axis** secundario
   1. Establecer **Number Format** para el **Value Axis** secundario
   1. Establecer **Min, Max, Major and Minor units** para el **Value Axis** secundario
1. Ahora trazar la primera serie del gráfico en el **Value Axis** secundario
1. Establecer el color de relleno de la pared trasera del gráfico
1. Establecer el color de relleno del área de trazado del gráfico
1. Guardar la presentación modificada en un archivo PPTX

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartEntities-ChartEntities.cpp" >}}

## **Establecer propiedades de fuente para un gráfico**
Aspose.Slides para C++ proporciona soporte para establecer las propiedades relacionadas con la fuente del gráfico. Siga los pasos a continuación para establecer las propiedades de fuente para el gráfico.

- Instanciar el objeto de la clase **Presentation**.
- Agregar un gráfico en la diapositiva.
- Establecer la altura de la fuente.
- Guardar la presentación modificada.

A continuación se muestra un ejemplo de muestra.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FontPropertiesForChart-FontPropertiesForChart.cpp" >}}

## **Establecer propiedades de fuente para la tabla de datos de un gráfico**
Aspose.Slides para C++ proporciona soporte para cambiar el color de categorías en un color de serie.

1. Instanciar el objeto de la clase **Presentation**.
1. Agregar un gráfico en la diapositiva.
1. Establecer la tabla del gráfico.
1. Establecer la altura de la fuente.
1. Guardar la presentación modificada.

A continuación se muestra un ejemplo de muestra.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontPropertiesForChartDataTable-SettingFontPropertiesForChartDataTable.cpp" >}}

## **Establecer bordes redondeados del área del gráfico**
Aspose.Slides para C++ proporciona soporte para establecer el área del gráfico. Se han añadido las propiedades **IChart.HasRoundedCorners** y **Chart.HasRoundedCorners** en Aspose.Slides.

1. Instanciar el objeto de la clase **Presentation**.
1. Agregar un gráfico en la diapositiva.
1. Establecer el tipo de relleno y el color de relleno del gráfico
1. Establecer la propiedad de esquina redondeada en True.
1. Guardar la presentación modificada.

A continuación se muestra un ejemplo de muestra.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingChartAreaRoundedBorders-SettingChartAreaRoundedBorders.cpp" >}}

## **Establecer el formato numérico**
Aspose.Slides para C++ proporciona una API simple para gestionar el formato de datos del gráfico:

1. Crear una instancia de la clase [Presentación](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtener la referencia de una diapositiva por su índice.
1. Agregar un gráfico con datos predeterminados junto con cualquiera de los tipos deseados (este ejemplo usa **ChartType.ClusteredColumn**).
1. Establecer el formato numérico predefinido a partir de los valores predefinidos posibles.
1. Recorrer la celda de datos del gráfico en cada serie del gráfico y establecer el formato numérico de los datos del gráfico.
1. Guardar la presentación.
1. Establecer el formato numérico personalizado.
1. Recorrer la celda de datos del gráfico dentro de cada serie del gráfico y establecer un formato numérico diferente para los datos del gráfico.
1. Guardar la presentación.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-NumberFormat-NumberFormat.cpp" >}}

| |**Los posibles valores de formato numérico predefinidos junto con su índice predefinido que pueden usarse se muestran a continuación:**|
| :- | :- |
|**0**|General|
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h :mm:ss|
|**47**|[mm:ss.0](http://mmss.0/)|
|**48**|##0.0E+00|
|**49**|@|
|||
| :- | :- |

## **FAQ**

**¿Puedo establecer rellenos semitransparentes para columnas/áreas manteniendo el borde opaco?**

Sí. La transparencia del relleno y el contorno se configuran por separado. Esto es útil para mejorar la legibilidad de la cuadrícula y los datos en visualizaciones densas.

**¿Cómo puedo manejar las etiquetas de datos cuando se superponen?**

Reduzca el tamaño de la fuente, desactive los componentes de etiqueta no esenciales (por ejemplo, categorías), establezca el desplazamiento/posición de la etiqueta, muestre etiquetas solo para los puntos seleccionados si es necesario, o cambie el formato a "valor + leyenda".

**¿Puedo aplicar rellenos degradados o de patrón a las series?**

Sí. Tanto los rellenos sólidos como los degradados/patrón suelen estar disponibles. En la práctica, use degradados con moderación y evite combinaciones que reduzcan el contraste con la cuadrícula y el texto.