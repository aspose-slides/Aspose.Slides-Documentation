---
title: Personalizar puntos de datos en gráficos Treemap y Sunburst usando JavaScript
linktitle: Puntos de datos en gráficos Treemap y Sunburst
type: docs
url: /es/nodejs-java/data-points-of-treemap-and-sunburst-chart/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda cómo crear datos jerárquicos y personalizar niveles, etiquetas y colores en los gráficos Treemap y Sunburst con Aspose.Slides para Node.js vía Java."
---
## **Visión general**

Los gráficos Treemap y Sunburst muestran el mismo tipo de datos jerárquicos, pero utilizan diferentes disposiciones. Un Treemap dibuja la jerarquía como rectángulos anidados cuyos áreas representan los valores de hoja. Un Sunburst la dibuja como anillos concéntricos: los grupos de nivel superior están cerca del centro y las categorías hoja están en el anillo exterior.

En Aspose.Slides for Node.js via Java, cada valor numérico es un [ChartDataPoint](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdatapoint/). Su método [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels) proporciona acceso a la hoja y a sus grupos padre. Este artículo explica esa asignación y muestra cómo crear y dar formato a ambos tipos de gráficos a partir de los mismos datos de muestra.

![Un gráfico de Treemap con ramas Consumer y Business](treemap-hierarchy.png)

![Un gráfico de Sunburst con la misma jerarquía Consumer y Business](sunburst-hierarchy.png)

## **Entender categorías, puntos de datos y niveles**

El ejemplo utilizado a continuación tiene tres niveles de categoría y una serie numérica:

| Rama | Eje | Hoja | Ingresos |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Cada fila crea una categoría hoja y un punto de datos. Los niveles de agrupación de la categoría describen la ruta desde esa hoja hasta sus padres. Para la primera fila, la ruta es `Consumer > Computers > Laptops`.

Los índices devueltos por [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels) se recorre de la hoja hacia arriba:

| Índice `getDataPointLevels()` | Nivel lógico | Representación de Treemap | Representación de Sunburst |
| ---: | --- | --- | --- |
| `0` | Hoja | Rectángulo de valor | Segmento del anillo exterior |
| `1` | Eje | Rectángulo o encabezado padre | Segmento del anillo medio |
| `2` | Rama | Rectángulo o encabezado de nivel superior | Segmento del anillo interno |

Este orden es el mismo para ambos tipos de gráficos aunque sus disposiciones visuales difieran. Un segmento padre se comparte entre varias hojas. Para formatearlo, use el nivel correspondiente del primer punto de datos de ese grupo. Por ejemplo, la rama `Consumer` comienza con el punto `Laptops`, mientras que el eje `Software` comienza con el punto `Licenses`. Mantener referencias a esos puntos es más claro y seguro que usar expresiones no explicadas como `dataPoints.get_Item(0)` o `dataPoints.get_Item(6)`.

## **Crear y personalizar ambos tipos de gráficos**

El siguiente ejemplo completo crea un Treemap en la primera diapositiva y un Sunburst en la segunda diapositiva. Construye la jerarquía, muestra el valor de `Tablets`, aplica colores fijos a niveles seleccionados, formatea una etiqueta de rama y guarda la presentación.

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const worksheetIndex = 0;
    const leafLevelIndex = 0;
    const stemLevelIndex = 1;
    const branchLevelIndex = 2;

    const branchNames = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ];
    const stemNames = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ];
    const leafNames = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ];
    const revenues = [12, 8, 15, 6, 10, 7, 11, 14];
    const dataPointCount = leafNames.length;

    const chartTypes = [
        aspose.slides.ChartType.Treemap,
        aspose.slides.ChartType.Sunburst
    ];
    const chartCount = chartTypes.length;
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);

    for (let chartIndex = 0; chartIndex < chartCount; chartIndex++) {
        const chartType = chartTypes[chartIndex];
        let slide;

        if (chartIndex === 0) {
            slide = presentation.getSlides().get_Item(0);
        } else {
            slide = presentation.getSlides().addEmptySlide(layoutSlide);
        }

        const chart = slide.getShapes().addChart(chartType, 40, 40, 640, 440);
        chart.setTitle(false);
        chart.setLegend(false);

        const chartData = chart.getChartData();
        chartData.getCategories().clear();
        chartData.getSeries().clear();

        const workbook = chartData.getChartDataWorkbook();
        workbook.clear(worksheetIndex);

        // Añadir las categorías hoja. Un elemento de agrupación se establece solo cuando comienza un nuevo grupo;
        // las categorías siguientes permanecen en ese grupo hasta que se establezca otro elemento.
        for (let dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            const rowIndex = dataIndex + 1;
            const leafName = leafNames[dataIndex];
            const categoryCell = workbook.getCell(worksheetIndex, rowIndex, 2, leafName);
            const category = chartData.getCategories().add(categoryCell);

            const stemName = stemNames[dataIndex];
            const startsNewStem = dataIndex === 0 || stemName !== stemNames[dataIndex - 1];
            if (startsNewStem) {
                category.getGroupingLevels().setGroupingItem(stemLevelIndex, stemName);
            }

            const branchName = branchNames[dataIndex];
            const startsNewBranch = dataIndex === 0 || branchName !== branchNames[dataIndex - 1];
            if (startsNewBranch) {
                category.getGroupingLevels().setGroupingItem(branchLevelIndex, branchName);
            }
        }

        const seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Revenue");
        const series = chartData.getSeries().add(seriesNameCell, chartType);
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);

        let laptopsDataPoint = null;
        let tabletsDataPoint = null;
        let licensesDataPoint = null;

        for (let dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            const rowIndex = dataIndex + 1;
            const leafName = leafNames[dataIndex];
            const revenue = revenues[dataIndex];
            const valueCell = workbook.getCell(worksheetIndex, rowIndex, 3, revenue);
            let dataPoint;

            if (chartType === aspose.slides.ChartType.Treemap) {
                dataPoint = series.getDataPoints().addDataPointForTreemapSeries(valueCell);
            } else {
                dataPoint = series.getDataPoints().addDataPointForSunburstSeries(valueCell);
            }

            if (leafName === "Laptops") {
                laptopsDataPoint = dataPoint;
            } else if (leafName === "Tablets") {
                tabletsDataPoint = dataPoint;
            } else if (leafName === "Licenses") {
                licensesDataPoint = dataPoint;
            }
        }

        // Mostrar la categoría y el valor en la hoja Tablets.
        const tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        const tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // Formatear la rama Consumer mediante la primera hoja de esa rama.
        const consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        const consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        const consumerBranchColor = java.newInstanceSync("java.awt.Color", 31, 78, 121);
        consumerBranchFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        const consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        const consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        const whiteColor = java.getStaticFieldValue("java.awt.Color", "WHITE");
        consumerLabelTextFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        consumerLabelTextFill.getSolidFillColor().setColor(whiteColor);

        // Formatear el eje Software mediante la primera hoja de ese eje.
        const softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        const softwareStemFill = softwareStemLevel.getFormat().getFill();
        const softwareStemColor = java.newInstanceSync("java.awt.Color", 112, 173, 71);
        softwareStemFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // ParentLabelLayout afecta a las etiquetas de los padres en Treemap; Sunburst usa segmentos de anillo.
        if (chartType === aspose.slides.ChartType.Treemap) {
            series.setParentLabelLayout(aspose.slides.ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Las celdas de categoría y las celdas de valor usan la misma fila de hoja de cálculo, de modo que sus posiciones en la colección permanecen alineadas. Cuando trabaje con un gráfico existente en lugar de crear uno, inspeccione primero las filas de categoría y almacene referencias con nombre a los puntos de datos y niveles que pretenda formatear.

## **Comportamiento y consideraciones prácticas**

### **Diferencias entre Treemap y Sunburst**

- Un Treemap utiliza el área para comunicar el valor y rectángulos anidados para comunicar la jerarquía. El método [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartseries/#setParentLabelLayout) controla cómo aparecen las etiquetas de los padres en este tipo de gráfico.
- Un Sunburst utiliza el ángulo para comunicar el valor y la profundidad del anillo para comunicar la jerarquía. [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartseries/#setParentLabelLayout) no controla sus etiquetas de anillo.
- Ambos tipos de gráficos usan los mismos niveles de agrupación de categorías y el mismo orden hoja‑a‑padre devuelto por [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels), por lo que el código de construcción de datos y de formato de niveles puede compartirse.
- Los valores de los padres se calculan a partir de sus hojas descendientes. No añada puntos numéricos separados para ramas o ejes.

### **Ordenamiento y orden de los segmentos**

El motor de disposición del gráfico determina la ubicación final de los rectángulos y segmentos de anillo. Agrupe filas de categoría relacionadas antes de añadirlas, pero no dependa de una posición de rectángulo o ángulo de inicio específicos. Si la secuencia tiene significado, inclúyala en las etiquetas o use un tipo de gráfico con eje de categoría explícito.

### **Tema y colores fijos**

Los niveles de gráfico sin formato heredan colores del tema de la presentación. El ejemplo usa rellenos RGB explícitos para obtener una salida predecible. Si el gráfico debe seguir los cambios de tema, use colores de esquema en lugar de valores RGB fijos y evite sobrescribir cada nivel. También compruebe el contraste de la etiqueta después de cambiar el relleno de una rama o eje.

### **Etiquetas y espacio disponible**

PowerPoint puede ocultar o truncar etiquetas cuando un segmento es demasiado pequeño. Incrementar el tamaño del gráfico, acortar los nombres de categoría o mostrar menos campos de etiqueta suele producir un resultado más claro. Una etiqueta puede combinar el nombre de la categoría, el nombre de la serie y el valor mediante [DataLabelFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/datalabelformat/), pero habilitar todos los campos a menudo dificulta la lectura de los gráficos jerárquicos.

### **Exportación y renderizado**

Guardar en PPTX mantiene el gráfico editable. Cuando Aspose.Slides renderiza la presentación a PDF o a una imagen, los rellenos y configuraciones de etiqueta compatibles se renderizan con el gráfico. La sustitución de fuentes y pequeñas diferencias en el espacio de disposición disponible pueden cambiar el ajuste de línea o la visibilidad de la etiqueta, por lo que debe instalar las fuentes requeridas y verificar los destinos de exportación importantes.

## **Preguntas frecuentes**

**¿Por qué al cambiar un nivel padre afecta a varias hojas?**

Una rama o eje es un segmento visual compartido. Su [ChartDataPointLevel](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdatapointlevel/) puede alcanzarse a través de una hoja descendiente, pero el formato pertenece al segmento padre compartido, no solo a esa hoja.

**¿Por qué falta una etiqueta de datos?**

Primero habilite los campos requeridos en el objeto [DataLabelFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/datalabelformat/) de la etiqueta. Luego compruebe si el segmento tiene suficiente espacio. El diseño de etiquetas de padres en Treemap, las dimensiones del gráfico, la longitud de la etiqueta, el tamaño de fuente y el número de campos habilitados influyen en si una etiqueta puede mostrarse.

**¿Puedo establecer el orden exacto o las coordenadas de los segmentos?**

Puede controlar el orden de las filas de origen y mantener cada grupo contiguo, pero no puede asignar rectángulos exactos de Treemap ni ángulos exactos de Sunburst. El motor de disposición del gráfico los calcula a partir de la jerarquía, los valores y el espacio disponible.

**¿Por qué los colores cambian después de modificar el tema de la presentación?**

Los rellenos basados en el tema están diseñados para seguir la paleta de la presentación. Aplique colores RGB explícitos a los niveles que deben permanecer fijos, o mantenga colores de esquema cuando prefiera adaptar el gráfico a un nuevo tema.

**¿Se preservará el formato personalizado en exportaciones a PDF e imagen?**

Sí, los rellenos de gráfico y la configuración de etiquetas compatibles se incluyen durante el renderizado. Para obtener resultados consistentes entre sistemas, haga que las fuentes necesarias estén disponibles y pruebe el tamaño final de la exportación, ya que el ajuste de etiquetas depende de la disposición.

## **Véase también**

- [Create Treemap charts](/slides/es/nodejs-java/create-chart/#creating-tree-map-charts)
- [Create Sunburst charts](/slides/es/nodejs-java/create-chart/#creating-sunburst-charts)
- [Export presentation charts](/slides/es/nodejs-java/export-chart/)
- [Manage presentation themes](/slides/es/nodejs-java/presentation-theme/)