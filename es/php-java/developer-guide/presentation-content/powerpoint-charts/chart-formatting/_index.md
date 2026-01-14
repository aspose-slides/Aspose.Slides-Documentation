---
title: Formato de gráficos de presentación en PHP
linktitle: Formateado de gráficos
type: docs
weight: 60
url: /es/php-java/chart-formatting/
keywords:
  - formatear gráfico
  - formateo de gráfico
  - entidad de gráfico
  - propiedades del gráfico
  - configuración del gráfico
  - opciones del gráfico
  - propiedades de fuente
  - borde redondeado
  - PowerPoint
  - presentación
  - PHP
  - Aspose.Slides
description: "Aprenda a formatear gráficos en Aspose.Slides para PHP mediante Java y mejore su presentación de PowerPoint con un estilo profesional y llamativo."
---

## **Formatear entidades del gráfico**
Aspose.Slides for PHP via Java permite a los desarrolladores añadir gráficos personalizados a sus diapositivas desde cero. Este artículo explica cómo formatear diferentes entidades de gráfico, incluyendo el eje de categoría y el eje de valores.

Aspose.Slides for PHP via Java proporciona una API sencilla para gestionar diferentes entidades de gráfico y formatearlas utilizando valores personalizados:

1. Crear una instancia de la clase [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtener la referencia de una diapositiva por su índice.
3. Añadir un gráfico con datos predeterminados junto con cualquiera de los tipos deseados (en este ejemplo utilizaremos ChartType::LineWithMarkers).
4. Acceder al eje de valores del gráfico y establecer las siguientes propiedades:
   1. Configurar **Line format** para las líneas de cuadrícula principales del eje de valores.
   1. Configurar **Line format** para las líneas de cuadrícula menores del eje de valores.
   1. Configurar **Number Format** para el eje de valores.
   1. Configurar **Min, Max, Major and Minor units** para el eje de valores.
   1. Configurar **Text Properties** para los datos del eje de valores.
   1. Configurar **Title** para el eje de valores.
   1. Configurar **Line Format** para el eje de valores.
5. Acceder al eje de categoría del gráfico y establecer las siguientes propiedades:
   1. Configurar **Line format** para las líneas de cuadrícula principales del eje de categoría.
   1. Configurar **Line format** para las líneas de cuadrícula menores del eje de categoría.
   1. Configurar **Text Properties** para los datos del eje de categoría.
   1. Configurar **Title** para el eje de categoría.
   1. Configurar **Label Positioning** para el eje de categoría.
   1. Configurar **Rotation Angle** para las etiquetas del eje de categoría.
6. Acceder a la leyenda del gráfico y establecer **Text Properties** para ella.
7. Configurar la visualización de leyendas del gráfico sin que se superpongan al gráfico.
8. Acceder al **Secondary Value Axis** del gráfico y establecer las siguientes propiedades:
   1. Habilitar el **Value Axis** secundario.
   1. Configurar **Line Format** para el **Value Axis** secundario.
   1. Configurar **Number Format** para el **Value Axis** secundario.
   1. Configurar **Min, Max, Major and Minor units** para el **Value Axis** secundario.
9. Ahora trazar la primera serie del gráfico en el **Value Axis** secundario.
10. Establecer el color de relleno del fondo del gráfico.
11. Establecer el color de relleno del área de trazado del gráfico.
12. Guardar la presentación modificada en un archivo PPTX.
```php
  # Crear una instancia de la clase Presentation
  $pres = new Presentation();
  try {
    # Acceder a la primera diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Añadir el gráfico de ejemplo
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 50, 50, 500, 400);
    # Establecer el título del gráfico
    $chart->hasTitle();
    $chart->getChartTitle()->addTextFrameForOverriding("");
    $chartTitle = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $chartTitle->setText("Sample Chart");
    $chartTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chartTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $chartTitle->getPortionFormat()->setFontHeight(20);
    $chartTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $chartTitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Establecer el formato de las líneas de cuadrícula principales para el eje de valores
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setDashStyle(LineDashStyle->DashDot);
    # Establecer el formato de las líneas de cuadrícula menores para el eje de valores
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);
    # Establecer el formato numérico del eje de valores
    $chart->getAxes()->getVerticalAxis()->isNumberFormatLinkedToSource();
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Thousands);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.0%");
    # Establecer los valores máximo y mínimo del gráfico
    $chart->getAxes()->getVerticalAxis()->isAutomaticMajorUnit();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMaxValue();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMinorUnit();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMinValue();
    $chart->getAxes()->getVerticalAxis()->setMaxValue(15.0);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-2.0);
    $chart->getAxes()->getVerticalAxis()->setMinorUnit(0.5);
    $chart->getAxes()->getVerticalAxis()->setMajorUnit(2.0);
    # Establecer las propiedades de texto del eje de valores
    $txtVal = $chart->getAxes()->getVerticalAxis()->getTextFormat()->getPortionFormat();
    $txtVal->setFontBold(NullableBool::True);
    $txtVal->setFontHeight(16);
    $txtVal->setFontItalic(NullableBool::True);
    $txtVal->getFillFormat()->setFillType(FillType::Solid);
    $txtVal->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->DarkGreen));
    $txtVal->setLatinFont(new FontData("Times New Roman"));
    # Establecer el título del eje de valores
    $chart->getAxes()->getVerticalAxis()->hasTitle();
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("");
    $valtitle = $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $valtitle->setText("Primary Axis");
    $valtitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $valtitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $valtitle->getPortionFormat()->setFontHeight(20);
    $valtitle->getPortionFormat()->setFontBold(NullableBool::True);
    $valtitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Establecer el formato de las líneas de cuadrícula principales para el eje de categorías
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    # Establecer el formato de las líneas de cuadrícula menores para el eje de categorías
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);
    # Establecer las propiedades de texto del eje de categorías
    $txtCat = $chart->getAxes()->getHorizontalAxis()->getTextFormat()->getPortionFormat();
    $txtCat->setFontBold(NullableBool::True);
    $txtCat->setFontHeight(16);
    $txtCat->setFontItalic(NullableBool::True);
    $txtCat->getFillFormat()->setFillType(FillType::Solid);
    $txtCat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $txtCat->setLatinFont(new FontData("Arial"));
    # Establecer el título de la categoría
    $chart->getAxes()->getHorizontalAxis()->hasTitle();
    $chart->getAxes()->getHorizontalAxis()->getTitle()->addTextFrameForOverriding("");
    $catTitle = $chart->getAxes()->getHorizontalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $catTitle->setText("Sample Category");
    $catTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $catTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $catTitle->getPortionFormat()->setFontHeight(20);
    $catTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $catTitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Establecer la posición de la etiqueta del eje de categorías
    $chart->getAxes()->getHorizontalAxis()->setTickLabelPosition(TickLabelPositionType::Low);
    # Establecer el ángulo de rotación de la etiqueta del eje de categorías
    $chart->getAxes()->getHorizontalAxis()->setTickLabelRotationAngle(45);
    # Establecer las propiedades de texto de la leyenda
    $txtleg = $chart->getLegend()->getTextFormat()->getPortionFormat();
    $txtleg->setFontBold(NullableBool::True);
    $txtleg->setFontHeight(16);
    $txtleg->setFontItalic(NullableBool::True);
    $txtleg->getFillFormat()->setFillType(FillType::Solid);
    $txtleg->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->DarkRed));
    # Mostrar la leyenda del gráfico sin superponerse al gráfico
    $chart->getLegend()->setOverlay(true);
    # chart.ChartData.Series[0].PlotOnSecondAxis=true;
    $chart->getChartData()->getSeries()->get_Item(0)->setPlotOnSecondAxis(true);
    # Establecer el eje de valores secundario
    $chart->getAxes()->getSecondaryVerticalAxis()->isVisible();
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setStyle(LineStyle->ThickBetweenThin);
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setWidth(20);
    # Establecer el formato numérico del eje de valores secundario
    $chart->getAxes()->getSecondaryVerticalAxis()->isNumberFormatLinkedToSource();
    $chart->getAxes()->getSecondaryVerticalAxis()->setDisplayUnit(DisplayUnitType::Hundreds);
    $chart->getAxes()->getSecondaryVerticalAxis()->setNumberFormat("0.0%");
    # Establecer los valores máximo y mínimo del gráfico
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMajorUnit();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMaxValue();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMinorUnit();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMinValue();
    $chart->getAxes()->getSecondaryVerticalAxis()->setMaxValue(20.0);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMinValue(-5.0);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMinorUnit(0.5);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMajorUnit(2.0);
    # Establecer el color de la pared trasera del gráfico
    $chart->getBackWall()->setThickness(1);
    $chart->getBackWall()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getBackWall()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $chart->getFloor()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getFloor()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Establecer el color del área de trazado
    $chart->getPlotArea()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getPlotArea()->getFormat()->getFill()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->LightCyan));
    # Guardar la presentación
    $pres->save("FormattedChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Establecer propiedades de fuente para un gráfico**
Aspose.Slides for PHP via Java ofrece soporte para establecer las propiedades relacionadas con la fuente del gráfico. Por favor, siga los pasos a continuación para establecer las propiedades de fuente del gráfico.

- Instanciar un objeto de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Añadir un gráfico en la diapositiva.
- Establecer la altura de la fuente.
- Guardar la presentación modificada.

A continuación se muestra un ejemplo.
```php
  # Crear una instancia de la clase Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);
    $chart->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $pres->save("FontPropertiesForChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Establecer el formato numérico**
Aspose.Slides for PHP via Java proporciona una API sencilla para gestionar el formato de los datos del gráfico:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Obtener la referencia de una diapositiva por su índice.
1. Añadir un gráfico con datos predeterminados junto con cualquiera de los tipos deseados (este ejemplo utiliza **ChartType::ClusteredColumn**).
1. Establecer el formato numérico predefinido a partir de los valores predefinidos posibles.
1. Recorrer la celda de datos del gráfico en cada serie y establecer el formato numérico de los datos del gráfico.
1. Guardar la presentación.
1. Establecer el formato numérico personalizado.
1. Recorrer la celda de datos del gráfico en cada serie y establecer un formato numérico diferente para los datos del gráfico.
1. Guardar la presentación.
```php
  # Crear una instancia de la clase Presentation
  $pres = new Presentation();
  try {
    # Acceder a la primera diapositiva de la presentación
    $slide = $pres->getSlides()->get_Item(0);
    # Añadir un gráfico de columnas agrupadas predeterminado
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 400);
    # Acceder a la colección de series del gráfico
    $series = $chart->getChartData()->getSeries();
    # Recorrer cada serie del gráfico
    foreach($series as $ser) {
      # Recorrer cada celda de datos en la serie
      foreach($ser->getDataPoints() as $cell) {
        # Establecer el formato numérico
        $cell->getValue()->getAsCell()->setPresetNumberFormat(10);// 0.00%

      }
    }
    # Guardar la presentación
    $pres->save("PresetNumberFormat.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


Los posibles valores de formato numérico predefinidos, junto con su índice predefinido y que pueden usarse, se indican a continuación:

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
|**46**|h :mm:ss|
|**47**|[mm:ss.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

## **Establecer bordes redondeados del área del gráfico**
Aspose.Slides for PHP via Java ofrece soporte para establecer el área del gráfico. Los métodos [**hasRoundedCorners**](https://reference.aspose.com/slides/php-java/aspose.slides/chart/hasroundedcorners/) y [**setRoundedCorners**](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setroundedcorners/) se han añadido a la clase [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/Chart).

1. Instanciar un objeto de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Añadir un gráfico en la diapositiva.
1. Establecer el tipo de relleno y el color de relleno del gráfico.
1. Establecer la propiedad de esquina redondeada en True.
1. Guardar la presentación modificada.

A continuación se muestra un ejemplo de muestra.
```php
  # Crear una instancia de la clase Presentation
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 100, 600, 400);
    $chart->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getLineFormat()->setStyle(LineStyle->Single);
    $chart->setRoundedCorners(true);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Preguntas frecuentes**

**¿Puedo establecer rellenos semitransparentes para columnas/áreas manteniendo el contorno opaco?**

Sí. La transparencia del relleno y el contorno se configuran por separado. Esto es útil para mejorar la legibilidad de la cuadrícula y los datos en visualizaciones densas.

**¿Cómo puedo manejar las etiquetas de datos cuando se superponen?**

Reducir el tamaño de la fuente, desactivar componentes de etiqueta no esenciales (por ejemplo, categorías), establecer el desplazamiento/posición de la etiqueta, mostrar etiquetas sólo para los puntos seleccionados si es necesario, o cambiar el formato a "valor + leyenda".

**¿Puedo aplicar rellenos degradados o con patrón a las series?**

Sí. Tanto los rellenos sólidos como los degradados/patrón suelen estar disponibles. En la práctica, use los degradados con moderación y evite combinaciones que reduzcan el contraste con la cuadrícula y el texto.