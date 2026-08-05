---
title: Formato de gráficos de presentación en C++
linktitle: Formateo de gráficos
type: docs
weight: 60
url: /es/cpp/chart-formatting/
keywords:
- formato de gráfico
- formateo de gráficos
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
description: "Aprenda a dar formato a los gráficos en Aspose.Slides para C++ y mejore su presentación de PowerPoint con un estilo profesional y llamativo."
---
## **Resumen**

Este artículo explica cómo dar formato a los gráficos en presentaciones de PowerPoint utilizando Aspose.Slides. Muestra cómo personalizar elementos clave del gráfico, como ejes, líneas de cuadrícula, títulos, leyendas, el área de trazado y los rellenos de paredes, para mejorar la apariencia y la legibilidad de los datos del gráfico.

También demuestra cómo establecer propiedades de fuente para el texto del gráfico, aplicar formatos numéricos predefinidos y personalizados a los datos del gráfico, y habilitar esquinas redondeadas para el área del gráfico. En conjunto, estos ejemplos muestran cómo controlar tanto el estilo visual como la presentación de datos de los gráficos en una presentación.

## **Formatear entidades de gráfico**
Aspose.Slides para C++ permite a los desarrolladores añadir gráficos personalizados a sus diapositivas desde cero. Este artículo explica cómo dar formato a diferentes entidades de gráfico, incluidas el eje de categorías y el eje de valores.

Aspose.Slides para C++ proporciona una API sencilla para gestionar distintas entidades de gráfico y darles formato mediante valores personalizados:

1. Crear una instancia de la **Presentation** class.
2. Obtener la referencia de una diapositiva mediante su índice.
3. Añadir un gráfico con datos predeterminados junto con cualquiera de los tipos deseados (en este ejemplo usaremos ChartType.LineWithMarkers).
4. Acceder al eje de valores del gráfico y establecer las siguientes propiedades:
   1. Configurar **Line format** para las líneas de cuadrícula principales del eje de valores
   2. Configurar **Line format** para las líneas de cuadrícula secundarias del eje de valores
   3. Configurar **Number Format** para el eje de valores
   4. Configurar **Min, Max, Major and Minor units** para el eje de valores
   5. Configurar **Text Properties** para los datos del eje de valores
   6. Configurar **Title** para el eje de valores
   7. Configurar **Line Format** para el eje de valores
5. Acceder al eje de categorías del gráfico y establecer las siguientes propiedades:
   1. Configurar **Line format** para las líneas de cuadrícula principales del eje de categorías
   2. Configurar **Line format** para las líneas de cuadrícula secundarias del eje de categorías
   3. Configurar **Text Properties** para los datos del eje de categorías
   4. Configurar **Title** para el eje de categorías
   5. Configurar **Label Positioning** para el eje de categorías
   6. Configurar **Rotation Angle** para las etiquetas del eje de categorías
6. Acceder a la leyenda del gráfico y establecer las **Text Properties** para ella
7. Mostrar leyendas del gráfico sin que se superpongan al gráfico
8. Acceder al **Secondary Value Axis** del gráfico y establecer las siguientes propiedades:
   1. Habilitar el **Value Axis** secundario
   2. Configurar **Line Format** para el eje de valores secundario
   3. Configurar **Number Format** para el eje de valores secundario
   4. Configurar **Min, Max, Major and Minor units** para el eje de valores secundario
9. Representar la primera serie del gráfico en el eje de valores secundario
10. Establecer el color de relleno de la pared trasera del gráfico
11. Establecer el color de relleno del área de trazado del gráfico
12. Guardar la presentación modificada en un archivo PPTX

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartEntities-ChartEntities.cpp" >}}

## **Establecer propiedades de fuente para un gráfico**
Aspose.Slides para C++ admite la definición de propiedades relacionadas con la fuente del gráfico. Siga los pasos a continuación para establecer las propiedades de fuente del gráfico.

- Instanciar un objeto de la clase Presentation.
- Añadir un gráfico en la diapositiva.
- Establecer la altura de la fuente.
- Guardar la presentación modificada.

A continuación se muestra un ejemplo.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FontPropertiesForChart-FontPropertiesForChart.cpp" >}}

## **Establecer propiedades de fuente para la tabla de datos del gráfico**
Aspose.Slides para C++ permite cambiar el color de las categorías en una serie de colores.

1. Instanciar un objeto de la clase Presentation.
2. Añadir un gráfico en la diapositiva.
3. establecer la tabla del gráfico.
4. Establecer la altura de la fuente.
5. Guardar la presentación modificada.

A continuación se muestra un ejemplo.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontPropertiesForChartDataTable-SettingFontPropertiesForChartDataTable.cpp" >}}

## **Establecer bordes redondeados en el área del gráfico**
Aspose.Slides para C++ admite la configuración del área del gráfico. Se han añadido las propiedades **IChart.HasRoundedCorners** y **Chart.HasRoundedCorners** en Aspose.Slides.

1. Instanciar un objeto de la clase Presentation.
2. Añadir un gráfico en la diapositiva.
3. Establecer el tipo y el color de relleno del gráfico
4. Establecer la propiedad de esquina redondeada a True.
5. Guardar la presentación modificada.

A continuación se muestra un ejemplo.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingChartAreaRoundedBorders-SettingChartAreaRoundedBorders.cpp" >}}

## **Establecer el formato numérico**
Aspose.Slides para C++ ofrece una API sencilla para gestionar el formato de datos del gráfico:

1. Crear una instancia de la [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) class.
2. Obtener la referencia de una diapositiva mediante su índice.
3. Añadir un gráfico con datos predeterminados junto con cualquiera de los tipos deseados (este ejemplo utiliza **ChartType.ClusteredColumn**).
4. Establecer el formato numérico predefinido a partir de los valores predefinidos disponibles.
5. Recorrer cada celda de datos del gráfico en cada serie y establecer el formato numérico de los datos del gráfico.
6. Guardar la presentación.
7. Establecer el formato numérico personalizado.
8. Recorrer las celdas de datos del gráfico dentro de cada serie y establecer un formato numérico diferente.
9. Guardar la presentación.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-NumberFormat-NumberFormat.cpp" >}}

| |**Los posibles valores de formato numérico predefinidos junto con su índice y que pueden usarse son los siguientes:**|
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
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

|||
| :- | :- |

## **FAQ**

**¿Puedo establecer rellenos semitransparentes para columnas/áreas manteniendo el contorno opaco?**

Sí. La transparencia del relleno y el contorno se configuran por separado. Esto es útil para mejorar la legibilidad de la cuadrícula y los datos en visualizaciones densas.

**¿Cómo puedo gestionar las etiquetas de datos cuando se solapan?**

Reduzca el tamaño de la fuente, desactive componentes de etiqueta no esenciales (por ejemplo, categorías), ajuste el desplazamiento/posición de la etiqueta, muestre etiquetas solo para los puntos seleccionados si es necesario, o cambie el formato a "valor + leyenda".

**¿Puedo aplicar rellenos degradados o de patrón a las series?**

Sí. Tanto los rellenos sólidos como los degradados/patrón suelen estar disponibles. En la práctica, use los degradados con moderación y evite combinaciones que reduzcan el contraste con la cuadrícula y el texto.