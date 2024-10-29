---
title: Formato de Gráficos
type: docs
weight: 60
url: /es/cpp/chart-formatting/
---



## **Formato de Entidades de Gráfico**
Aspose.Slides para C++ permite a los desarrolladores agregar gráficos personalizados a sus diapositivas desde cero. Este artículo explica cómo formatear diferentes entidades de gráfico, incluidas las categorías de gráfico y el eje de valores.

Aspose.Slides para C++ proporciona una API simple para gestionar diferentes entidades de gráfico y formatearlas utilizando valores personalizados:

1. Crear una instancia de la clase **Presentation**.
1. Obtener la referencia de una diapositiva por su índice.
1. Agregar un gráfico con datos predeterminados junto con cualquier tipo deseado (en este ejemplo utilizaremos ChartType.LineWithMarkers).
1. Acceder al Eje de Valores del gráfico y establecer las siguientes propiedades:
   1. Configurar el **formato de línea** para las líneas de la cuadrícula Mayor del Eje de Valores
   1. Configurar el **formato de línea** para las líneas de la cuadrícula Menor del Eje de Valores
   1. Configurar el **formato de número** para el Eje de Valores
   1. Configurar las **unidades Mínimas, Máximas, Mayores y Menores** para el Eje de Valores
   1. Configurar las **Propiedades de Texto** para los datos del Eje de Valores
   1. Configurar el **Título** para el Eje de Valores
   1. Configurar el **Formato de Línea** para el Eje de Valores
1. Acceder al Eje de Categoría del gráfico y establecer las siguientes propiedades:
   1. Configurar el **formato de línea** para las líneas de la cuadrícula Mayor del Eje de Categoría
   1. Configurar el **formato de línea** para las líneas de la cuadrícula Menor del Eje de Categoría
   1. Configurar las **Propiedades de Texto** para los datos del Eje de Categoría
   1. Configurar el **Título** para el Eje de Categoría
   1. Configurar la **Posición de la Etiqueta** para el Eje de Categoría
   1. Configurar el **Ángulo de Rotación** para las etiquetas del Eje de Categoría
1. Acceder a la Leyenda del gráfico y establecer las **Propiedades de Texto** para ellas
1. Mostrar las Leyendas del gráfico sin superponer el gráfico
1. Acceder al **Eje de Valores Secundario** del gráfico y establecer las siguientes propiedades:
   1. Habilitar el **Eje de Valores Secundario**
   1. Configurar el **Formato de Línea** para el Eje de Valores Secundario
   1. Configurar el **formato de número** para el Eje de Valores Secundario
   1. Configurar las **unidades Mínimas, Máximas, Mayores y Menores** para el Eje de Valores Secundario
1. Ahora dibujar la primera serie de gráficos en el Eje de Valores Secundario
1. Establecer el color de fondo del gráfico
1. Establecer el color de relleno del área de dibujo del gráfico
1. Escribir la presentación modificada en un archivo PPTX

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartEntities-ChartEntities.cpp" >}}

## **Configurar Propiedades de Fuente para el Gráfico**
Aspose.Slides para C++ proporciona soporte para configurar las propiedades relacionadas con la fuente para el gráfico. Siga los pasos a continuación para configurar las propiedades de la fuente para el gráfico.

- Instanciar un objeto de la clase Presentation.
- Agregar un gráfico en la diapositiva.
- Establecer la altura de la fuente.
- Guardar la presentación modificada.

Se proporciona un ejemplo de muestra a continuación.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FontPropertiesForChart-FontPropertiesForChart.cpp" >}}

## **Configurar Propiedades de Fuente para la Tabla de Datos del Gráfico**
Aspose.Slides para C++ proporciona soporte para cambiar el color de las categorías en un color de serie. 

1. Instanciar un objeto de la clase Presentation.
1. Agregar un gráfico en la diapositiva.
1. Configurar la tabla del gráfico.
1. Establecer la altura de la fuente.
1. Guardar la presentación modificada.

Se proporciona un ejemplo de muestra a continuación. 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontPropertiesForChartDataTable-SettingFontPropertiesForChartDataTable.cpp" >}}

## **Configurar Bordes Redondeados del Área del Gráfico**
Aspose.Slides para C++ proporciona soporte para configurar el área del gráfico. **IChart.HasRoundedCorners** y **Chart.HasRoundedCorners** se han añadido en Aspose.Slides. 

1. Instanciar un objeto de la clase Presentation.
1. Agregar un gráfico en la diapositiva.
1. Establecer el tipo de relleno y el color de relleno del gráfico
1. Establecer la propiedad de esquina redondeada en Verdadero.
1. Guardar la presentación modificada. 

Se proporciona un ejemplo de muestra a continuación. 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingChartAreaRoundedBorders-SettingChartAreaRoundedBorders.cpp" >}}

## **Configurar Números de Datos del Gráfico**
Aspose.Slides para C++ proporciona una API simple para gestionar el formato de los datos del gráfico:

1. Crear una instancia de la [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) clase.
1. Obtener la referencia de una diapositiva por su índice.
1. Agregar un gráfico con datos predeterminados junto con cualquiera de los tipos deseados (este ejemplo utiliza **ChartType.ClusteredColumn**).
1. Establecer el formato de número preestablecido de los posibles valores preestablecidos.
1. Recorrer la celda de datos del gráfico en cada serie de gráficos y establecer el formato de número de datos del gráfico.
1. Guardar la presentación.
1. Establecer el formato de número personalizado.
1. Recorrer la celda de datos del gráfico dentro de cada serie de gráficos y establecer un formato de número de datos del gráfico diferente.
1. Guardar la presentación.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-NumberFormat-NumberFormat.cpp" >}}

| |**Los posibles valores de formato de número preestablecidos junto con su índice preestablecido que se pueden usar se indican a continuación:**|
| :- | :- |

|**0**|General|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Rojo$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Rojo$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|d/m/aa|
|**15**|d-mmm-aa|
|**16**|d-mmm|
|**17**|mmm-aa|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|d/m/aa h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Rojo-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Rojo-#,##0.00|
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