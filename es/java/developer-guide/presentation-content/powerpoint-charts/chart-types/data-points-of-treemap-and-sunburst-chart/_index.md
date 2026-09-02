---
title: Personalizar puntos de datos en gráficos Treemap y Sunburst en Java
linktitle: Puntos de datos en gráficos Treemap y Sunburst
type: docs
url: /es/java/data-points-of-treemap-and-sunburst-chart/
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
- Java
- Aspose.Slides
description: "Aprenda a crear datos jerárquicos y personalizar niveles, etiquetas y colores en gráficos Treemap y Sunburst con Aspose.Slides para Java."
---
## **Visión general**

Los gráficos Treemap y Sunburst muestran el mismo tipo de datos jerárquicos, pero utilizan disposiciones diferentes. Un Treemap dibuja la jerarquía como rectángulos anidados cuyas áreas representan los valores de hoja. Un Sunburst la dibuja como anillos concéntricos: los grupos de nivel superior están cerca del centro y las categorías de hoja están en el anillo exterior.

En Aspose.Slides for Java, cada valor numérico es un [IChartDataPoint](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartdatapoint/). Su método [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) proporciona acceso a la hoja y a sus grupos padre. Este artículo explica esa asignación y muestra cómo crear y dar formato a ambos tipos de gráfico a partir de los mismos datos de ejemplo.

![Un gráfico Treemap con ramas Consumer y Business](treemap-hierarchy.png)

![Un gráfico Sunburst con la misma jerarquía Consumer y Business](sunburst-hierarchy.png)

## **Comprender categorías, puntos de datos y niveles**

El ejemplo utilizado a continuación tiene tres niveles de categoría y una serie numérica:

| Sucursal | Rama | Hoja | Ingresos |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Cada fila crea una categoría de hoja y un punto de datos. Los niveles de agrupación de categoría describen la ruta desde esa hoja hasta sus padres. Para la primera fila, la ruta es `Consumer > Computers > Laptops`.

Los índices devueltos por [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) se cuentan desde la hoja hacia arriba:

| Índice `getDataPointLevels()` | Nivel lógico | Representación Treemap | Representación Sunburst |
| ---: | --- | --- | --- |
| `0` | Hoja | Rectángulo de valor | Segmento del anillo exterior |
| `1` | Rama | Rectángulo o encabezado padre | Segmento del anillo medio |
| `2` | Sucursal | Rectángulo o encabezado de nivel superior | Segmento del anillo interior |

Este orden es el mismo para ambos tipos de gráfico aunque sus disposiciones visuales difieran. Un segmento padre se comparte entre varias hojas. Para darle formato, use el nivel correspondiente del primer punto de datos en ese grupo. Por ejemplo, la rama `Consumer` comienza con el punto `Laptops`, mientras que la rama `Software` comienza con el punto `Licenses`. Mantener referencias a esos puntos es más claro y seguro que usar expresiones no explicadas como `dataPoints.get_Item(0)` o `dataPoints.get_Item(6)`.

## **Crear y personalizar ambos tipos de gráfico**

El siguiente ejemplo completo crea un Treemap en la primera diapositiva y un Sunburst en la segunda diapositiva. Construye la jerarquía, muestra el valor de `Tablets`, aplica colores fijos a niveles seleccionados, da formato a una etiqueta de rama y guarda la presentación.

```java
Presentation presentation = new Presentation();
try {
    final int worksheetIndex = 0;
    final int leafLevelIndex = 0;
    final int stemLevelIndex = 1;
    final int branchLevelIndex = 2;

    String[] branchNames = {
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    };
    String[] stemNames = {
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    };
    String[] leafNames = {
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    };
    double[] revenues = {12, 8, 15, 6, 10, 7, 11, 14};
    int dataPointCount = leafNames.length;

    int[] chartTypes = {ChartType.Treemap, ChartType.Sunburst};
    int chartCount = chartTypes.length;
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);

    for (int chartIndex = 0; chartIndex < chartCount; chartIndex++) {
        int chartType = chartTypes[chartIndex];
        ISlide slide;

        if (chartIndex == 0) {
            slide = presentation.getSlides().get_Item(0);
        } else {
            slide = presentation.getSlides().addEmptySlide(layoutSlide);
        }

        IChart chart = slide.getShapes().addChart(chartType, 40, 40, 640, 440);
        chart.setTitle(false);
        chart.setLegend(false);

        IChartData chartData = chart.getChartData();
        chartData.getCategories().clear();
        chartData.getSeries().clear();

        IChartDataWorkbook workbook = chartData.getChartDataWorkbook();
        workbook.clear(worksheetIndex);

        // Añadir las categorías de hoja. Un elemento de agrupación se establece solo cuando comienza un nuevo grupo;
        // las categorías siguientes permanecen en ese grupo hasta que se establezca otro elemento.
        for (int dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            int rowIndex = dataIndex + 1;
            String leafName = leafNames[dataIndex];
            IChartDataCell categoryCell = workbook.getCell(worksheetIndex, rowIndex, 2, leafName);
            IChartCategory category = chartData.getCategories().add(categoryCell);

            String stemName = stemNames[dataIndex];
            boolean startsNewStem = dataIndex == 0;
            if (dataIndex > 0) {
                String previousStemName = stemNames[dataIndex - 1];
                startsNewStem = !stemName.equals(previousStemName);
            }
            if (startsNewStem) {
                category.getGroupingLevels().setGroupingItem(stemLevelIndex, stemName);
            }

            String branchName = branchNames[dataIndex];
            boolean startsNewBranch = dataIndex == 0;
            if (dataIndex > 0) {
                String previousBranchName = branchNames[dataIndex - 1];
                startsNewBranch = !branchName.equals(previousBranchName);
            }
            if (startsNewBranch) {
                category.getGroupingLevels().setGroupingItem(branchLevelIndex, branchName);
            }
        }

        IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Revenue");
        IChartSeries series = chartData.getSeries().add(seriesNameCell, chartType);
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);

        IChartDataPoint laptopsDataPoint = null;
        IChartDataPoint tabletsDataPoint = null;
        IChartDataPoint licensesDataPoint = null;

        for (int dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            int rowIndex = dataIndex + 1;
            String leafName = leafNames[dataIndex];
            double revenue = revenues[dataIndex];
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, rowIndex, 3, revenue);
            IChartDataPoint dataPoint;

            if (chartType == ChartType.Treemap) {
                dataPoint = series.getDataPoints().addDataPointForTreemapSeries(valueCell);
            } else {
                dataPoint = series.getDataPoints().addDataPointForSunburstSeries(valueCell);
            }

            if ("Laptops".equals(leafName)) {
                laptopsDataPoint = dataPoint;
            } else if ("Tablets".equals(leafName)) {
                tabletsDataPoint = dataPoint;
            } else if ("Licenses".equals(leafName)) {
                licensesDataPoint = dataPoint;
            }
        }

        // Mostrar la categoría y el valor en la hoja Tablets.
        IChartDataPointLevel tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        IDataLabelFormat tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // Dar formato a la rama Consumer a través de la primera hoja de esa rama.
        IChartDataPointLevel consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        IFillFormat consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        Color consumerBranchColor = new Color(31, 78, 121);
        consumerBranchFill.setFillType(FillType.Solid);
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        IDataLabelFormat consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        IFillFormat consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        consumerLabelTextFill.setFillType(FillType.Solid);
        consumerLabelTextFill.getSolidFillColor().setColor(Color.WHITE);

        // Dar formato al tallo Software a través de la primera hoja de ese tallo.
        IChartDataPointLevel softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        IFillFormat softwareStemFill = softwareStemLevel.getFormat().getFill();
        Color softwareStemColor = new Color(112, 173, 71);
        softwareStemFill.setFillType(FillType.Solid);
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // ParentLabelLayout afecta a las etiquetas de los padres en Treemap; Sunburst utiliza segmentos de anillo.
        if (chartType == ChartType.Treemap) {
            series.setParentLabelLayout(ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Las celdas de categoría y las celdas de valor utilizan la misma fila de hoja de cálculo, por lo que sus posiciones en la colección permanecen alineadas. Cuando trabaje con un gráfico existente en lugar de crear uno, inspeccione primero las filas de categoría y almacene referencias con nombre a los puntos de datos y niveles que pretende formatear.

## **Comportamiento y consideraciones prácticas**

### **Diferencias entre Treemap y Sunburst**

- Un Treemap usa el área para comunicar el valor y rectángulos anidados para comunicar la jerarquía. El método [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) controla cómo aparecen las etiquetas de los padres en este tipo de gráfico.
- Un Sunburst usa el ángulo para comunicar el valor y la profundidad del anillo para comunicar la jerarquía. [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) no controla sus etiquetas de anillo.
- Ambos tipos de gráfico utilizan los mismos niveles de agrupación de categoría y el mismo orden hoja‑a‑padre devuelto por [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--), por lo que el código de generación de datos y de formato de niveles puede compartirse.
- Los valores de los padres se calculan a partir de sus hojas descendientes. No añada puntos numéricos separados para ramas o tallos.

### **Ordenación y orden de segmentos**

El motor de disposición del gráfico determina la ubicación final de los rectángulos y los segmentos del anillo. Agrupe filas de categoría relacionadas antes de añadirlas, pero no dependa de una posición de rectángulo o ángulo de inicio específicos. Si la secuencia tiene significado, inclúyala en las etiquetas o use un tipo de gráfico con un eje de categoría explícito.

### **Tema y colores fijos**

Los niveles de gráfico no formateados heredan colores del tema de la presentación. El ejemplo usa rellenos RGB explícitos para obtener una salida predecible. Si el gráfico debe seguir los cambios de tema, utilice colores de esquema en lugar de valores RGB fijos y evite sobrescribir cada nivel. También verifique el contraste de la etiqueta después de cambiar el relleno de una rama o tallo.

### **Etiquetas y espacio disponible**

PowerPoint puede ocultar o truncar etiquetas cuando un segmento es demasiado pequeño. Aumentar el tamaño del gráfico, acortar los nombres de categoría o mostrar menos campos de etiqueta suele producir un resultado más claro. Una etiqueta puede combinar el nombre de la categoría, el nombre de la serie y el valor mediante [IDataLabelFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/idatalabelformat/), pero habilitar todos los campos a menudo dificulta la lectura de los gráficos jerárquicos.

### **Exportación y renderizado**

Guardar en PPTX mantiene el gráfico editable. Cuando Aspose.Slides renderiza la presentación a PDF o a una imagen, los rellenos y ajustes de etiqueta compatibles se renderizan con el gráfico. La sustitución de fuentes y pequeñas diferencias en el espacio de disposición disponible pueden cambiar el ajuste de líneas o la visibilidad de la etiqueta, así que instale las fuentes requeridas y verifique los destinos de exportación importantes.

## **Preguntas frecuentes**

**¿Por qué al cambiar un nivel padre afecta a varias hojas?**

Una rama o tallo es un segmento visual compartido. Su [IChartDataPointLevel](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartdatapointlevel/) puede alcanzarse a través de una hoja descendiente, pero el formato pertenece al segmento padre compartido y no solo a esa hoja.

**¿Por qué falta una etiqueta de datos?**

Primero habilite los campos requeridos en el objeto [IDataLabelFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/idatalabelformat/) de la etiqueta. Luego compruebe que el segmento tenga suficiente espacio. El diseño de etiquetas de padre en Treemap, las dimensiones del gráfico, la longitud de la etiqueta, el tamaño de la fuente y el número de campos habilitados influyen en si una etiqueta puede mostrarse.

**¿Puedo establecer el orden o las coordenadas exactas de los segmentos?**

Puede controlar el orden de las filas de origen y mantener cada grupo contiguo, pero no puede asignar rectángulos exactos de Treemap ni ángulos exactos de Sunburst. El motor de disposición del gráfico los calcula a partir de la jerarquía, los valores y el espacio disponible.

**¿Por qué los colores cambian tras modificar el tema de la presentación?**

Los rellenos basados en el tema están diseñados para seguir la paleta de la presentación. Aplique colores RGB explícitos a los niveles que deben permanecer fijos, o mantenga colores de esquema cuando prefiera adaptarse a un nuevo tema.

**¿Se preservará el formato personalizado en exportaciones a PDF e imagen?**

Sí, los rellenos de gráfico y ajustes de etiqueta compatibles se incluyen durante el renderizado. Para obtener resultados consistentes entre sistemas, haga que las fuentes necesarias estén disponibles y pruebe el tamaño final de exportación, ya que el ajuste de etiquetas depende de la disposición.

## **Ver también**

- [Crear gráficos Treemap](/slides/es/java/create-chart/#create-tree-map-charts)
- [Crear gráficos Sunburst](/slides/es/java/create-chart/#create-sunburst-charts)
- [Exportar gráficos de presentación](/slides/es/java/export-chart/)
- [Administrar temas de presentación](/slides/es/java/presentation-theme/)