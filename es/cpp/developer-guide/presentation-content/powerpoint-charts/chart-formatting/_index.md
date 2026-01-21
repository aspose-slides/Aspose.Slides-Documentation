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
  - propiedades del gráfico
  - configuración del gráfico
  - opciones del gráfico
  - propiedades de fuente
  - borde redondeado
  - PowerPoint
  - presentación
  - C++
  - Aspose.Slides
description: "Aprende a formatear gráficos en Aspose.Slides para C++ y mejora tu presentación de PowerPoint con un estilo profesional y llamativo."
---

## **Entidades de gráfico de formato**
Aspose.Slides for C++ permite a los desarrolladores añadir gráficos personalizados a sus diapositivas desde cero. Este artículo explica cómo dar formato a distintas entidades de gráfico, incluidas la categoría y el eje de valores del gráfico.

Aspose.Slides for C++ proporciona una API sencilla para gestionar distintas entidades de gráfico y formatearlas con valores personalizados:

1. Cree una instancia de la **Presentation** clase.
1. Obtenga la referencia de una diapositiva mediante su índice.
1. Añada un gráfico con datos predeterminados junto con cualquiera de los tipos deseados (en este ejemplo utilizaremos ChartType.LineWithMarkers).
1. Acceda al eje de valores del gráfico y establezca las siguientes propiedades:
   1. Establecer **Line format** para las líneas de cuadrícula mayores del eje de valores
   1. Establecer **Line format** para las líneas de cuadrícula menores del eje de valores
   1. Establecer **Number Format** para el eje de valores
   1. Establecer **Min, Max, Major and Minor units** para el eje de valores
   1. Establecer **Text Properties** para los datos del eje de valores
   1. Establecer **Title** para el eje de valores
   1. Establecer **Line Format** para el eje de valores
1. Acceda al eje de categorías del gráfico y establezca las siguientes propiedades:
   1. Establecer **Line format** para las líneas de cuadrícula mayores del eje de categorías
   1. Establecer **Line format** para las líneas de cuadrícula menores del eje de categorías
   1. Establecer **Text Properties** para los datos del eje de categorías
   1. Establecer **Title** para el eje de categorías
   1. Establecer **Label Positioning** para el eje de categorías
   1. Establecer **Rotation Angle** para las etiquetas del eje de categorías
1. Acceda a la leyenda del gráfico y establezca las **Text Properties** para ella
1. Mostrar las leyendas del gráfico sin que se superpongan al gráfico
1. Acceda al **Secondary Value Axis** del gráfico y establezca las siguientes propiedades:
   1. Habilitar el **Value Axis** secundario
   1. Establecer **Line Format** para el **Value Axis** secundario
   1. Establecer **Number Format** para el **Value Axis** secundario
   1. Establecer **Min, Max, Major and Minor units** para el **Value Axis** secundario
1. Ahora trace la primera serie del gráfico en el **Value Axis** secundario
1. Establezca el fondo del gráfico con color de relleno
1. Establezca el color de relleno del área de trazado del gráfico
1. Guarde la presentación modificada en un archivo PPTX

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartEntities-ChartEntities.cpp" >}}

## **Establecer propiedades de fuente para un gráfico**
Aspose.Slides for C++ ofrece soporte para establecer las propiedades relacionadas con la fuente del gráfico. Siga los pasos a continuación para configurar las propiedades de fuente del gráfico.

- Instanciar un objeto de la clase Presentation.
- Añadir un gráfico en la diapositiva.
- Establecer la altura de la fuente.
- Guardar la presentación modificada.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FontPropertiesForChart-FontPropertiesForChart.cpp" >}}

## **Establecer propiedades de fuente para la tabla de datos de un gráfico**
Aspose.Slides for C++ ofrece soporte para cambiar el color de las categorías en el color de una serie.

1. Instanciar un objeto de la clase Presentation.
1. Añadir un gráfico en la diapositiva.
1. Establecer la tabla del gráfico.
1. Establecer la altura de la fuente.
1. Guardar la presentación modificada.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontPropertiesForChartDataTable-SettingFontPropertiesForChartDataTable.cpp" >}}

## **Establecer bordes redondeados del área del gráfico**
Aspose.Slides for C++ ofrece soporte para establecer el área del gráfico. **IChart.HasRoundedCorners** y **Chart.HasRoundedCorners** se han añadido en Aspose.Slides.

1. Instanciar un objeto de la clase Presentation.
1. Añadir un gráfico en la diapositiva.
1. Establecer el tipo de relleno y el color de relleno del gráfico
1. Establecer la propiedad de esquina redondeada en True.
1. Guardar la presentación modificada.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingChartAreaRoundedBorders-SettingChartAreaRoundedBorders.cpp" >}}

## **Establecer el formato numérico**
Aspose.Slides for C++ proporciona una API sencilla para gestionar el formato de datos del gráfico:

1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) clase.
1. Obtenga la referencia de una diapositiva mediante su índice.
1. Añada un gráfico con datos predeterminados junto con cualquiera de los tipos deseados (este ejemplo usa **ChartType.ClusteredColumn**).
1. Establezca el formato numérico predefinido a partir de los valores predefinidos posibles.
1. Recorra cada celda de datos del gráfico en cada serie y establezca el formato numérico de los datos del gráfico.
1. Guarde la presentación.
1. Establezca el formato numérico personalizado.
1. Recorra cada celda de datos del gráfico en cada serie y establezca un formato numérico de datos diferente.
1. Guarde la presentación.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-NumberFormat-NumberFormat.cpp" >}}

| |**Los posibles valores de formato numérico predefinidos junto con su índice predefinido y que pueden usarse se muestran a continuación:**|
| :- | :- |
|**0**|General|
| :- | :- |
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
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|
|||
| :- | :- |

## **Preguntas frecuentes**

**¿Puedo establecer rellenos semitransparentes para columnas/áreas manteniendo el borde opaco?**

Sí. La transparencia del relleno y el contorno se configuran por separado. Esto es útil para mejorar la legibilidad de la cuadrícula y los datos en visualizaciones densas.

**¿Cómo puedo gestionar las etiquetas de datos cuando se superponen?**

Reduzca el tamaño de la fuente, desactive componentes de etiqueta no esenciales (por ejemplo, categorías), ajuste el desplazamiento/posición de la etiqueta, muestre etiquetas sólo para los puntos seleccionados si es necesario, o cambie el formato a "valor + leyenda".

**¿Puedo aplicar rellenos de degradado o patrón a las series?**

Sí. Tanto los rellenos sólidos como los de degradado/patrón suelen estar disponibles. En la práctica, utilice degradados con moderación y evite combinaciones que reduzcan el contraste con la cuadrícula y el texto.