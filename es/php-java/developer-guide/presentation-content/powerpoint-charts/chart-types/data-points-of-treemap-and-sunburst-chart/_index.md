---
title: Personalizar puntos de datos en gráficos Treemap y Sunburst en PHP
linktitle: Puntos de datos en gráficos Treemap y Sunburst
type: docs
url: /es/php-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- gráfico treemap
- gráfico sunburst
- gráfico jerárquico
- punto de datos
- etiqueta de datos
- color de rama
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Aprenda a crear datos jerárquicos y a personalizar niveles, etiquetas y colores en gráficos Treemap y Sunburst con Aspose.Slides para PHP a través de Java."
---
## **Visión general**

Los gráficos de Treemap y Sunburst muestran el mismo tipo de datos jerárquicos, pero utilizan diseños diferentes. Un Treemap dibuja la jerarquía como rectángulos anidados cuyas áreas representan los valores de las hojas. Un Sunburst la representa como anillos concéntricos: los grupos de nivel superior están cerca del centro y las categorías hoja se encuentran en el anillo exterior.

En Aspose.Slides para PHP a través de Java, cada valor numérico es un [ChartDataPoint](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdatapoint/). Su método [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) proporciona acceso a la hoja y a sus grupos padre. Este artículo explica esa asignación y muestra cómo crear y formatear ambos tipos de gráfico a partir de los mismos datos de ejemplo.

![Un gráfico Treemap con ramas Consumer y Business](treemap-hierarchy.png)

![Un gráfico Sunburst con la misma jerarquía Consumer y Business](sunburst-hierarchy.png)

## **Comprender categorías, puntos de datos y niveles**

El ejemplo utilizado a continuación tiene tres niveles de categoría y una serie numérica:

| Rama | Eje | Hoja | Ingresos |
| --- | --- | --- | ---: |
| Consumidor | Ordenadores | Portátiles | 12 |
| Consumidor | Ordenadores | Sobremesas | 8 |
| Consumidor | Móviles | Teléfonos | 15 |
| Consumidor | Móviles | Tabletas | 6 |
| Empresarial | Servicios | Consultoría | 10 |
| Empresarial | Servicios | Soporte | 7 |
| Empresarial | Software | Licencias | 11 |
| Empresarial | Software | Suscripciones | 14 |

Cada fila crea una categoría hoja y un punto de datos. Los niveles de agrupación de categoría describen la ruta desde esa hoja hasta sus padres. Para la primera fila, la ruta es `Consumer > Computers > Laptops`.

Los índices devueltos por [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) se cuentan desde la hoja hacia arriba:

| índice `getDataPointLevels()` | Nivel lógico | Representación Treemap | Representación Sunburst |
| ---: | --- | --- | --- |
| `0` | Hoja | Rectángulo de valor | Segmento del anillo exterior |
| `1` | Eje | Rectángulo padre o encabezado | Segmento del anillo medio |
| `2` | Rama | Rectángulo de nivel superior o encabezado | Segmento del anillo interno |

Este orden es el mismo para ambos tipos de gráfico aunque sus disposiciones visuales difieran. Un segmento padre es compartido por varias hojas. Para formatearlo, utilice el nivel correspondiente del primer punto de datos en ese grupo. Por ejemplo, la rama `Consumer` comienza con el punto `Laptops`, mientras que el eje `Software` comienza con el punto `Licenses`. Mantener referencias a esos puntos es más claro y seguro que usar expresiones sin explicación como `$dataPoints->get_Item(0)` o `$dataPoints->get_Item(6)`.

## **Crear y personalizar ambos tipos de gráfico**

El siguiente ejemplo completo crea un Treemap en la primera diapositiva y un Sunburst en la segunda diapositiva. Construye la jerarquía, muestra el valor de `Tablets`, aplica colores fijos a niveles seleccionados, formatea una etiqueta de rama y guarda la presentación.

```php
$presentation = new Presentation();
try {
    $worksheetIndex = 0;
    $leafLevelIndex = 0;
    $stemLevelIndex = 1;
    $branchLevelIndex = 2;

    $branchNames = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ];
    $stemNames = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ];
    $leafNames = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ];
    $revenues = [12, 8, 15, 6, 10, 7, 11, 14];
    $dataPointCount = count($leafNames);

    $chartTypes = [ChartType::Treemap, ChartType::Sunburst];
    $chartCount = count($chartTypes);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);

    for ($chartIndex = 0; $chartIndex < $chartCount; $chartIndex++) {
        $chartType = $chartTypes[$chartIndex];

        if ($chartIndex === 0) {
            $slide = $presentation->getSlides()->get_Item(0);
        } else {
            $slide = $presentation->getSlides()->addEmptySlide($layoutSlide);
        }

        $chart = $slide->getShapes()->addChart($chartType, 40, 40, 640, 440);
        $chart->setTitle(false);
        $chart->setLegend(false);

        $chartData = $chart->getChartData();
        $chartData->getCategories()->clear();
        $chartData->getSeries()->clear();

        $workbook = $chartData->getChartDataWorkbook();
        $workbook->clear($worksheetIndex);

        // Añadir las categorías hoja. Un elemento de agrupación se establece solo cuando comienza un nuevo grupo;
        // las categorías siguientes permanecen en ese grupo hasta que se establezca otro elemento.
        for ($dataIndex = 0; $dataIndex < $dataPointCount; $dataIndex++) {
            $rowIndex = $dataIndex + 1;
            $leafName = $leafNames[$dataIndex];
            $categoryCell = $workbook->getCell($worksheetIndex, $rowIndex, 2, $leafName);
            $category = $chartData->getCategories()->add($categoryCell);

            $stemName = $stemNames[$dataIndex];
            $startsNewStem = $dataIndex === 0;
            if ($dataIndex > 0) {
                $previousStemName = $stemNames[$dataIndex - 1];
                $startsNewStem = $stemName !== $previousStemName;
            }
            if ($startsNewStem) {
                $category->getGroupingLevels()->setGroupingItem($stemLevelIndex, $stemName);
            }

            $branchName = $branchNames[$dataIndex];
            $startsNewBranch = $dataIndex === 0;
            if ($dataIndex > 0) {
                $previousBranchName = $branchNames[$dataIndex - 1];
                $startsNewBranch = $branchName !== $previousBranchName;
            }
            if ($startsNewBranch) {
                $category->getGroupingLevels()->setGroupingItem($branchLevelIndex, $branchName);
            }
        }

        $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 3, "Revenue");
        $series = $chartData->getSeries()->add($seriesNameCell, $chartType);
        $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);

        $laptopsDataPoint = null;
        $tabletsDataPoint = null;
        $licensesDataPoint = null;

        for ($dataIndex = 0; $dataIndex < $dataPointCount; $dataIndex++) {
            $rowIndex = $dataIndex + 1;
            $leafName = $leafNames[$dataIndex];
            $revenue = $revenues[$dataIndex];
            $valueCell = $workbook->getCell($worksheetIndex, $rowIndex, 3, $revenue);

            if ($chartType === ChartType::Treemap) {
                $dataPoint = $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
            } else {
                $dataPoint = $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
            }

            if ($leafName === "Laptops") {
                $laptopsDataPoint = $dataPoint;
            } elseif ($leafName === "Tablets") {
                $tabletsDataPoint = $dataPoint;
            } elseif ($leafName === "Licenses") {
                $licensesDataPoint = $dataPoint;
            }
        }

        // Mostrar la categoría y el valor en la hoja Tablets.
        $tabletsLeafLevel = $tabletsDataPoint->getDataPointLevels()->get_Item($leafLevelIndex);
        $tabletsLabelFormat = $tabletsLeafLevel->getLabel()->getDataLabelFormat();
        $tabletsLabelFormat->setShowCategoryName(true);
        $tabletsLabelFormat->setShowValue(true);
        $tabletsLabelFormat->setSeparator("\n");
        $tabletsLabelFormat->setNumberFormat('$0');

        // Formatear la rama Consumer a través de la primera hoja de esa rama.
        $consumerBranchLevel = $laptopsDataPoint->getDataPointLevels()->get_Item($branchLevelIndex);
        $consumerBranchFill = $consumerBranchLevel->getFormat()->getFill();
        $consumerBranchColor = new java("java.awt.Color", 31, 78, 121);
        $consumerBranchFill->setFillType(FillType::Solid);
        $consumerBranchFill->getSolidFillColor()->setColor($consumerBranchColor);

        $consumerLabelFormat = $consumerBranchLevel->getLabel()->getDataLabelFormat();
        $consumerLabelFormat->setShowCategoryName(true);
        $consumerLabelFormat->setShowSeriesName(false);
        $consumerLabelTextFill = $consumerLabelFormat->getTextFormat()->getPortionFormat()->getFillFormat();
        $white = java("java.awt.Color")->WHITE;
        $consumerLabelTextFill->setFillType(FillType::Solid);
        $consumerLabelTextFill->getSolidFillColor()->setColor($white);

        // Formatear el eje Software a través de la primera hoja de ese eje.
        $softwareStemLevel = $licensesDataPoint->getDataPointLevels()->get_Item($stemLevelIndex);
        $softwareStemFill = $softwareStemLevel->getFormat()->getFill();
        $softwareStemColor = new java("java.awt.Color", 112, 173, 71);
        $softwareStemFill->setFillType(FillType::Solid);
        $softwareStemFill->getSolidFillColor()->setColor($softwareStemColor);

        // ParentLabelLayout afecta las etiquetas de padre en Treemap; Sunburst usa segmentos de anillo.
        if ($chartType === ChartType::Treemap) {
            $series->setParentLabelLayout(ParentLabelLayoutType::Overlapping);
        }
    }

    $presentation->save("hierarchical-charts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Las celdas de categoría y las celdas de valor utilizan la misma fila de hoja de cálculo, por lo que sus posiciones en la colección permanecen alineadas. Cuando trabaje con un gráfico existente en lugar de crear uno nuevo, inspeccione primero las filas de categoría y almacene referencias nombradas a los puntos de datos y niveles que pretenda formatear.

## **Comportamiento y consideraciones prácticas**

### **Diferencias entre Treemap y Sunburst**

- Un Treemap utiliza el área para comunicar el valor y rectángulos anidados para comunicar la jerarquía. El método [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartseries/#setParentLabelLayout) controla cómo aparecen las etiquetas de los padres en este tipo de gráfico.
- Un Sunburst utiliza el ángulo para comunicar el valor y la profundidad del anillo para comunicar la jerarquía. [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartseries/#setParentLabelLayout) no controla sus etiquetas de anillo.
- Ambos tipos de gráfico usan los mismos niveles de agrupación de categoría y el mismo orden hoja‑padre devuelto por [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdatapoint/#getDataPointLevels), por lo que el código de construcción de datos y de formato de niveles puede compartirse.
- Los valores de los padres se calculan a partir de sus hojas descendientes. No añada puntos numéricos separados para ramas o ejes.

### **Ordenación y orden de segmentos**

El motor de diseño del gráfico determina la ubicación final de los rectángulos y segmentos de anillo. Agrupe filas de categoría relacionadas antes de añadirlas, pero no dependa de una posición de rectángulo o ángulo de inicio específicos. Si la secuencia tiene significado, inclúyala en las etiquetas o use un tipo de gráfico con un eje de categoría explícito.

### **Tema y colores fijos**

Los niveles de gráfico sin formato heredan colores del tema de la presentación. El ejemplo usa rellenos RGB explícitos para una salida predecible. Si el gráfico debe seguir los cambios de tema, use colores de esquema en lugar de valores RGB fijos y evite sobrescribir cada nivel. También compruebe el contraste de la etiqueta después de cambiar el relleno de una rama o eje.

### **Etiquetas y espacio disponible**

PowerPoint puede ocultar o truncar etiquetas cuando un segmento es demasiado pequeño. Incrementar el tamaño del gráfico, acortar los nombres de categoría o mostrar menos campos de etiqueta suele producir un resultado más claro. Una etiqueta puede combinar el nombre de la categoría, el nombre de la serie y el valor mediante [DataLabelFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/datalabelformat/), pero habilitar todos los campos a menudo dificulta la lectura de los gráficos jerárquicos.

### **Exportación y renderizado**

Guardar en PPTX mantiene el gráfico editable. Cuando Aspose.Slides renderiza la presentación a PDF o a una imagen, los rellenos y ajustes de etiqueta compatibles se renderizan con el gráfico. La sustitución de fuentes y pequeñas diferencias en el espacio de diseño disponible pueden cambiar el ajuste de línea o la visibilidad de la etiqueta, por lo que debe instalar las fuentes requeridas y verificar los destinos de exportación importantes.

## **FAQ**

**¿Por qué al cambiar un nivel padre afecta a varias hojas?**

Una rama o eje es un segmento visual compartido. Su [ChartDataPointLevel](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdatapointlevel/) puede alcanzarse a través de una hoja descendiente, pero el formato pertenece al segmento padre compartido y no solo a esa hoja.

**¿Por qué falta una etiqueta de datos?**

Primero active los campos necesarios en el objeto [DataLabelFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/datalabelformat/) de la etiqueta. Luego compruebe que el segmento disponga de suficiente espacio. El diseño de etiquetas padre en Treemap, las dimensiones del gráfico, la longitud de la etiqueta, el tamaño de fuente y el número de campos habilitados influyen en si la etiqueta puede mostrarse.

**¿Puedo establecer el orden exacto o las coordenadas de los segmentos?**

Puede controlar el orden de las filas de origen y mantener cada grupo contiguo, pero no puede asignar rectángulos exactos de Treemap ni ángulos exactos de Sunburst. El motor de diseño del gráfico los calcula a partir de la jerarquía, los valores y el espacio disponible.

**¿Por qué cambian los colores después de que el tema de la presentación se modifica?**

Los rellenos basados en temas están diseñados para seguir la paleta de la presentación. Aplique colores RGB explícitos a los niveles que deben permanecer fijos, o conserve los colores de esquema cuando se prefiera adaptarse a un nuevo tema.

**¿Se conservará el formato personalizado en exportaciones a PDF e imágenes?**

Sí, los rellenos de gráfico y configuraciones de etiqueta compatibles se incluyen durante el renderizado. Para obtener resultados consistentes en diferentes sistemas, haga que las fuentes requeridas estén disponibles y pruebe el tamaño final de la exportación, ya que el ajuste de etiquetas depende del diseño.

## **Ver también**

- [Crear gráficos Treemap](/slides/es/php-java/create-chart/#create-tree-map-charts)
- [Crear gráficos Sunburst](/slides/es/php-java/create-chart/#create-sunburst-charts)
- [Exportar gráficos de presentación](/slides/es/php-java/export-chart/)
- [Administrar temas de presentación](/slides/es/php-java/presentation-theme/)