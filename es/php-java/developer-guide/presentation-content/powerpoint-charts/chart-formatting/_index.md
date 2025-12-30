---
title: Formato de Gráficas de Presentación en PHP
linktitle: Formateo de Gráficas
type: docs
weight: 60
url: /es/php-java/chart-formatting/
keywords:
- formato de gráfica
- formateo de gráfica
- entidad de gráfica
- propiedades de gráfica
- ajustes de gráfica
- opciones de gráfica
- propiedades de fuente
- borde redondeado
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Aprenda a formatear gráficas en Aspose.Slides para PHP via Java y mejore su presentación PowerPoint con un estilo profesional y llamativo."
---

## **Entidades de Gráfica de Formato**
Aspose.Slides for PHP via Java permite a los desarrolladores añadir gráficas personalizadas a sus diapositivas desde cero. Este artículo explica cómo formatear diferentes entidades de gráfica, incluida la categoría de la gráfica y el eje de valores.

Aspose.Slides for PHP via Java proporciona una API simple para gestionar distintas entidades de gráfica y formatearlas con valores personalizados:

1. Cree una instancia de la clase [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenga la referencia a una diapositiva mediante su índice.
1. Añada una gráfica con datos por defecto junto con el tipo deseado (en este ejemplo usaremos ChartType::LineWithMarkers).
1. Acceda al eje de valores de la gráfica y establezca las siguientes propiedades:
   1. Configurar **formato de línea** para las líneas principales de la cuadrícula del eje de valores
   1. Configurar **formato de línea** para las líneas secundarias de la cuadrícula del eje de valores
   1. Configurar **formato numérico** para el eje de valores
   1. Configurar **mínimo, máximo, unidades principales y secundarias** para el eje de valores
   1. Configurar **propiedades de texto** para los datos del eje de valores
   1. Configurar **título** para el eje de valores
   1. Configurar **formato de línea** para el eje de valores
1. Acceda al eje de categorías de la gráfica y establezca las siguientes propiedades:
   1. Configurar **formato de línea** para las líneas principales de la cuadrícula del eje de categorías
   1. Configurar **formato de línea** para las líneas secundarias de la cuadrícula del eje de categorías
   1. Configurar **propiedades de texto** para los datos del eje de categorías
   1. Configurar **título** para el eje de categorías
   1. Configurar **posicionamiento de etiquetas** para el eje de categorías
   1. Configurar **ángulo de rotación** para las etiquetas del eje de categorías
1. Acceda a la leyenda de la gráfica y configure las **propiedades de texto** para ella.
1. Muestre las leyendas de la gráfica sin que se superpongan a la gráfica.
1. Acceda al **eje de valores secundario** de la gráfica y establezca las siguientes propiedades:
   1. Habilite el **eje de valores secundario**
   1. Configurar **formato de línea** para el eje de valores secundario
   1. Configurar **formato numérico** para el eje de valores secundario
   1. Configurar **mínimo, máximo, unidades principales y secundarias** para el eje de valores secundario
1. Ahora trace la primera serie de la gráfica en el eje de valores secundario.
1. Establezca el color de relleno de la pared posterior de la gráfica.
1. Establezca el color de relleno del área de trazado de la gráfica.
1. Guarde la presentación modificada en un archivo PPTX.
```php
  # Crear una instancia de la clase Presentation
  $pres = new Presentation();
  try {
    # Accediendo a la primera diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Añadiendo la gráfica de muestra
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 50, 50, 500, 400);
    # Estableciendo el título de la gráfica
    $chart->hasTitle();
    $chart->getChartTitle()->addTextFrameForOverriding("");
    $chartTitle = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $chartTitle->setText("Sample Chart");
    $chartTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chartTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $chartTitle->getPortionFormat()->setFontHeight(20);
    $chartTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $chartTitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Estableciendo el formato de líneas de cuadrícula principales para el eje de valores
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setDashStyle(LineDashStyle->DashDot);
    # Estableciendo el formato de líneas de cuadrícula menores para el eje de valores
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);
    # Estableciendo el formato numérico del eje de valores
    $chart->getAxes()->getVerticalAxis()->isNumberFormatLinkedToSource();
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Thousands);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.0%");
    # Estableciendo los valores máximo y mínimo de la gráfica
    $chart->getAxes()->getVerticalAxis()->isAutomaticMajorUnit();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMaxValue();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMinorUnit();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMinValue();
    $chart->getAxes()->getVerticalAxis()->setMaxValue(15.0);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-2.0);
    $chart->getAxes()->getVerticalAxis()->setMinorUnit(0.5);
    $chart->getAxes()->getVerticalAxis()->setMajorUnit(2.0);
    # Estableciendo las propiedades de texto del eje de valores
    $txtVal = $chart->getAxes()->getVerticalAxis()->getTextFormat()->getPortionFormat();
    $txtVal->setFontBold(NullableBool::True);
    $txtVal->setFontHeight(16);
    $txtVal->setFontItalic(NullableBool::True);
    $txtVal->getFillFormat()->setFillType(FillType::Solid);
    $txtVal->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->DarkGreen));
    $txtVal->setLatinFont(new FontData("Times New Roman"));
    # Estableciendo el título del eje de valores
    $chart->getAxes()->getVerticalAxis()->hasTitle();
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("");
    $valtitle = $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $valtitle->setText("Primary Axis");
    $valtitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $valtitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $valtitle->getPortionFormat()->setFontHeight(20);
    $valtitle->getPortionFormat()->setFontBold(NullableBool::True);
    $valtitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Estableciendo el formato de líneas de cuadrícula principales para el eje de categorías
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    # Estableciendo el formato de líneas de cuadrícula menores para el eje de categorías
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);
    # Estableciendo las propiedades de texto del eje de categorías
    $txtCat = $chart->getAxes()->getHorizontalAxis()->getTextFormat()->getPortionFormat();
    $txtCat->setFontBold(NullableBool::True);
    $txtCat->setFontHeight(16);
    $txtCat->setFontItalic(NullableBool::True);
    $txtCat->getFillFormat()->setFillType(FillType::Solid);
    $txtCat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $txtCat->setLatinFont(new FontData("Arial"));
    # Estableciendo el título de la categoría
    $chart->getAxes()->getHorizontalAxis()->hasTitle();
    $chart->getAxes()->getHorizontalAxis()->getTitle()->addTextFrameForOverriding("");
    $catTitle = $chart->getAxes()->getHorizontalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $catTitle->setText("Sample Category");
    $catTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $catTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $catTitle->getPortionFormat()->setFontHeight(20);
    $catTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $catTitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Estableciendo la posición de la etiqueta del eje de categorías
    $chart->getAxes()->getHorizontalAxis()->setTickLabelPosition(TickLabelPositionType::Low);
    # Estableciendo el ángulo de rotación de la etiqueta del eje de categorías
    $chart->getAxes()->getHorizontalAxis()->setTickLabelRotationAngle(45);
    # Estableciendo las propiedades de texto de las leyendas
    $txtleg = $chart->getLegend()->getTextFormat()->getPortionFormat();
    $txtleg->setFontBold(NullableBool::True);
    $txtleg->setFontHeight(16);
    $txtleg->setFontItalic(NullableBool::True);
    $txtleg->getFillFormat()->setFillType(FillType::Solid);
    $txtleg->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->DarkRed));
    # Configurar la visualización de leyendas sin superponer la gráfica
    $chart->getLegend()->setOverlay(true);
    # chart.ChartData.Series[0].PlotOnSecondAxis=true;
    $chart->getChartData()->getSeries()->get_Item(0)->setPlotOnSecondAxis(true);
    # Estableciendo el eje de valores secundario
    $chart->getAxes()->getSecondaryVerticalAxis()->isVisible();
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setStyle(LineStyle->ThickBetweenThin);
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setWidth(20);
    # Estableciendo el formato numérico del eje de valores secundario
    $chart->getAxes()->getSecondaryVerticalAxis()->isNumberFormatLinkedToSource();
    $chart->getAxes()->getSecondaryVerticalAxis()->setDisplayUnit(DisplayUnitType::Hundreds);
    $chart->getAxes()->getSecondaryVerticalAxis()->setNumberFormat("0.0%");
    # Estableciendo los valores máximo y mínimo de la gráfica
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMajorUnit();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMaxValue();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMinorUnit();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMinValue();
    $chart->getAxes()->getSecondaryVerticalAxis()->setMaxValue(20.0);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMinValue(-5.0);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMinorUnit(0.5);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMajorUnit(2.0);
    # Estableciendo el color de la pared trasera de la gráfica
    $chart->getBackWall()->setThickness(1);
    $chart->getBackWall()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getBackWall()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $chart->getFloor()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getFloor()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Estableciendo el color del área de trazado
    $chart->getPlotArea()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getPlotArea()->getFormat()->getFill()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->LightCyan));
    # Save Presentation
    $pres->save("FormattedChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Establecer Propiedades de Fuente para una Gráfica**
Aspose.Slides for PHP via Java admite la configuración de las propiedades relacionadas con la fuente en la gráfica. Siga los pasos a continuación para establecer las propiedades de fuente de la gráfica.

- Instancie el objeto de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Añada una gráfica a la diapositiva.
- Establezca la altura de la fuente.
- Guarde la presentación modificada.

A continuación se muestra un ejemplo de código.
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


## **Establecer el Formato Numérico**
Aspose.Slides for PHP via Java proporciona una API sencilla para gestionar el formato de datos de la gráfica:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Obtenga la referencia a una diapositiva mediante su índice.
1. Añada una gráfica con datos por defecto junto con el tipo deseado (este ejemplo usa **ChartType::ClusteredColumn**).
1. Establezca el formato numérico predefinido a partir de los valores predefinidos posibles.
1. Recorra cada celda de datos de la gráfica en cada serie y establezca el formato numérico de los datos de la gráfica.
1. Guarde la presentación.
1. Establezca un formato numérico personalizado.
1. Recorra las celdas de datos de la gráfica dentro de cada serie y establezca un formato numérico diferente para los datos.
1. Guarde la presentación.
```php
  # Crear una instancia de la clase Presentation
  $pres = new Presentation();
  try {
    # Acceder a la primera diapositiva de la presentación
    $slide = $pres->getSlides()->get_Item(0);
    # Añadir una gráfica de columnas agrupadas predeterminada
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 400);
    # Acceder a la colección de series de la gráfica
    $series = $chart->getChartData()->getSeries();
    # Recorrer cada serie de la gráfica
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


Los valores predefinidos de formato numérico posibles, junto con su índice predefinido, son los siguientes:

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

## **Establecer Bordes Redondeados del Área de la Gráfica**
Aspose.Slides for PHP via Java admite la configuración del área de la gráfica. Los métodos [**hasRoundedCorners**](https://reference.aspose.com/slides/php-java/aspose.slides/IChart#hasRoundedCorners--) y [**setRoundedCorners**](https://reference.aspose.com/slides/php-java/aspose.slides/IChart#setRoundedCorners-boolean-) se han añadido a la interfaz [IChart](https://reference.aspose.com/slides/php-java/aspose.slides/IChart) y a la clase [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/Chart).

1. Instancie el objeto de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Añada una gráfica a la diapositiva.
1. Establezca el tipo de relleno y el color de relleno de la gráfica.
1. Establezca la propiedad de esquinas redondeadas en **True**.
1. Guarde la presentación modificada.

A continuación se muestra un ejemplo de código.  
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


## **FAQ**

**¿Puedo establecer rellenos semitransparentes para columnas/áreas manteniendo el borde opaco?**

Sí. La transparencia del relleno y el contorno se configuran por separado. Esto es útil para mejorar la legibilidad de la cuadrícula y los datos en visualizaciones densas.

**¿Cómo puedo gestionar las etiquetas de datos cuando se solapan?**

Reduzca el tamaño de la fuente, desactive componentes de etiqueta no esenciales (por ejemplo, categorías), ajuste el desplazamiento/posición de la etiqueta, muestre etiquetas solo para puntos seleccionados si es necesario, o cambie el formato a “valor + leyenda”.

**¿Puedo aplicar rellenos degradados o con patrón a las series?**

Sí. Tanto los rellenos sólidos como los degradados/patrón suelen estar disponibles. En la práctica, use degradados con moderación y evite combinaciones que reduzcan el contraste con la cuadrícula y el texto.