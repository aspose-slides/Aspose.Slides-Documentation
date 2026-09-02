---
title: Personalizar puntos de datos en diagramas Treemap y Sunburst en .NET
linktitle: Puntos de datos en diagramas Treemap y Sunburst
type: docs
url: /es/net/data-points-of-treemap-and-sunburst-chart/
keywords:
- diagrama treemap
- diagrama sunburst
- diagrama jerárquico
- punto de datos
- etiqueta de datos
- color de rama
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aprenda a crear datos jerárquicos y a personalizar niveles, etiquetas y colores en diagramas Treemap y Sunburst con Aspose.Slides para .NET."
---
## **Visión general**

Los diagramas Treemap y Sunburst muestran el mismo tipo de datos jerárquicos, pero utilizan disposiciones diferentes. Un Treemap dibuja la jerarquía como rectángulos anidados cuyas áreas representan los valores de las hojas. Un Sunburst la representa como anillos concéntricos: los grupos de nivel superior están cerca del centro y las categorías hoja están en el anillo exterior.

En Aspose.Slides for .NET, cada valor numérico es un [IChartDataPoint](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartdatapoint/). Su colección [IChartDataPoint.DataPointLevels](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartdatapoint/datapointlevels/) proporciona acceso a la hoja y a sus grupos padre. Este artículo explica esa asignación y muestra cómo crear y dar formato a ambos tipos de diagramas a partir de los mismos datos de ejemplo.

![Un diagrama de Treemap con ramas Consumer y Business](treemap-hierarchy.png)

![Un diagrama de Sunburst con la misma jerarquía Consumer y Business](sunburst-hierarchy.png)

## **Entender categorías, puntos de datos y niveles**

El ejemplo utilizado a continuación tiene tres niveles de categoría y una serie numérica:

| Rama | Tronco | Hoja | Ingresos |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Cada fila crea una categoría hoja y un punto de datos. Los niveles de agrupación de categoría describen la ruta desde esa hoja hasta sus padres. Para la primera fila, la ruta es `Consumer > Computers > Laptops`.

Los índices en [IChartDataPoint.DataPointLevels](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartdatapoint/datapointlevels/) se cuentan desde la hoja hacia arriba:

| índice de `DataPointLevels` | Nivel lógico | Representación Treemap | Representación Sunburst |
| ---: | --- | --- | --- |
| `0` | Hoja | Rectángulo de valor | Segmento del anillo exterior |
| `1` | Tronco | Rectángulo o encabezado del padre | Segmento del anillo medio |
| `2` | Rama | Rectángulo o encabezado de nivel superior | Segmento del anillo interior |

Este orden es el mismo para ambos tipos de diagramas aunque sus disposiciones visuales difieran. Un segmento padre es compartido por varias hojas. Para formatearlo, utilice el nivel correspondiente del primer punto de datos del grupo. Por ejemplo, la rama `Consumer` comienza con el punto `Laptops`, mientras que el tronco `Software` comienza con el punto `Licenses`. Mantener referencias a esos puntos resulta más claro y seguro que usar expresiones sin explicación como `dataPoints[0]` o `dataPoints[6]`.

## **Crear y personalizar ambos tipos de diagramas**

El siguiente ejemplo completo crea un Treemap en la primera diapositiva y un Sunburst en la segunda diapositiva. Construye la jerarquía, muestra el valor de `Tablets`, aplica colores fijos a niveles seleccionados, da formato a una etiqueta de rama y guarda la presentación.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var treemapSlide = presentation.Slides[0];
AddHierarchyChart(treemapSlide, ChartType.Treemap);

var layoutSlide = presentation.LayoutSlides[0];
var sunburstSlide = presentation.Slides.AddEmptySlide(layoutSlide);
AddHierarchyChart(sunburstSlide, ChartType.Sunburst);

presentation.Save("hierarchical-charts.pptx", SaveFormat.Pptx);

static void AddHierarchyChart(ISlide slide, ChartType chartType)
{
    const int worksheetIndex = 0;
    const int leafLevelIndex = 0;
    const int stemLevelIndex = 1;
    const int branchLevelIndex = 2;

    var chart = slide.Shapes.AddChart(chartType, 40, 40, 640, 440);
    chart.HasTitle = false;
    chart.HasLegend = false;
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    var workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(worksheetIndex);

    // Añadir las categorías hoja. Un elemento de agrupación se establece solo cuando comienza un nuevo grupo;
    // las categorías siguientes permanecen en ese grupo hasta que se establezca otro elemento.
    var laptopsCategory = AddCategory(1, "Laptops");
    laptopsCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Computers");
    laptopsCategory.GroupingLevels.SetGroupingItem(branchLevelIndex, "Consumer");

    AddCategory(2, "Desktops");

    var phonesCategory = AddCategory(3, "Phones");
    phonesCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Mobile");

    AddCategory(4, "Tablets");

    var consultingCategory = AddCategory(5, "Consulting");
    consultingCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Services");
    consultingCategory.GroupingLevels.SetGroupingItem(branchLevelIndex, "Business");

    AddCategory(6, "Support");

    var licensesCategory = AddCategory(7, "Licenses");
    licensesCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Software");

    AddCategory(8, "Subscriptions");

    var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 3, "Revenue");
    var series = chart.ChartData.Series.Add(seriesNameCell, chartType);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;

    var laptopsDataPoint = AddDataPoint(1, 12);
    AddDataPoint(2, 8);
    AddDataPoint(3, 15);
    var tabletsDataPoint = AddDataPoint(4, 6);
    AddDataPoint(5, 10);
    AddDataPoint(6, 7);
    var licensesDataPoint = AddDataPoint(7, 11);
    AddDataPoint(8, 14);

    // Mostrar la categoría y el valor en la hoja Tablets.
    var tabletsLabelFormat = tabletsDataPoint.DataPointLevels[leafLevelIndex]
        .Label.DataLabelFormat;
    tabletsLabelFormat.ShowCategoryName = true;
    tabletsLabelFormat.ShowValue = true;
    tabletsLabelFormat.Separator = "\n";
    tabletsLabelFormat.NumberFormat = "$0";

    // Dar formato a la rama Consumer a través de la primera hoja de esa rama.
    var consumerBranchLevel = laptopsDataPoint.DataPointLevels[branchLevelIndex];
    var consumerBranchFill = consumerBranchLevel.Format.Fill;
    var consumerBranchColor = Color.FromArgb(31, 78, 121);
    SetSolidFill(consumerBranchFill, consumerBranchColor);

    var consumerLabelFormat = consumerBranchLevel.Label.DataLabelFormat;
    consumerLabelFormat.ShowCategoryName = true;
    consumerLabelFormat.ShowSeriesName = false;
    var consumerLabelTextFill = consumerLabelFormat.TextFormat.PortionFormat.FillFormat;
    SetSolidFill(consumerLabelTextFill, Color.White);

    // Dar formato al tronco Software a través de la primera hoja de ese tronco.
    var softwareStemLevel = licensesDataPoint.DataPointLevels[stemLevelIndex];
    var softwareStemFill = softwareStemLevel.Format.Fill;
    var softwareStemColor = Color.FromArgb(112, 173, 71);
    SetSolidFill(softwareStemFill, softwareStemColor);

    // ParentLabelLayout afecta a las etiquetas de los padres en Treemap; Sunburst utiliza segmentos de anillo.
    if (chartType == ChartType.Treemap)
    {
        series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;
    }

    IChartCategory AddCategory(int rowIndex, string leafName)
    {
        var categoryCell = workbook.GetCell(worksheetIndex, rowIndex, 2, leafName);
        return chart.ChartData.Categories.Add(categoryCell);
    }

    IChartDataPoint AddDataPoint(int rowIndex, double value)
    {
        var valueCell = workbook.GetCell(worksheetIndex, rowIndex, 3, value);

        if (chartType == ChartType.Treemap)
        {
            return series.DataPoints.AddDataPointForTreemapSeries(valueCell);
        }

        return series.DataPoints.AddDataPointForSunburstSeries(valueCell);
    }

    static void SetSolidFill(IFillFormat fillFormat, Color color)
    {
        fillFormat.FillType = FillType.Solid;
        fillFormat.SolidFillColor.Color = color;
    }
}
```

Las celdas de categoría y las celdas de valor utilizan la misma fila de la hoja de cálculo, por lo que sus posiciones en la colección permanecen alineadas. Cuando se trabaja con un diagrama existente en lugar de crear uno, inspeccione primero las filas de categoría y almacene referencias con nombre a los puntos de datos y niveles que pretende formatear.

## **Comportamiento y consideraciones prácticas**

### **Diferencias entre Treemap y Sunburst**

- Un Treemap usa el área para comunicar el valor y rectángulos anidados para comunicar la jerarquía. La propiedad [IChartSeries.ParentLabelLayout](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartseries/parentlabellayout/) controla cómo aparecen las etiquetas de los padres en este tipo de diagrama.
- Un Sunburst usa el ángulo para comunicar el valor y la profundidad del anillo para comunicar la jerarquía. [IChartSeries.ParentLabelLayout](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartseries/parentlabellayout/) no controla sus etiquetas de anillo.
- Ambos tipos de diagramas usan los mismos niveles de agrupación de categoría y el mismo orden hoja‑padre en `DataPointLevels`, por lo que el código de creación de datos y de formato de niveles puede compartirse.
- Los valores de los padres se calculan a partir de sus hojas descendientes. No añada puntos numéricos separados para ramas o troncos.

### **Ordenación y orden de los segmentos**

El motor de disposición del diagrama determina la colocación final de los rectángulos y los segmentos de anillo. Agrupe filas de categoría relacionadas antes de añadirlas, pero no dependa de una posición de rectángulo o ángulo de inicio específico. Si la secuencia tiene significado, inclúyala en las etiquetas o utilice un tipo de diagrama con eje de categoría explícito.

### **Tema y colores fijos**

Los niveles de diagrama sin formato heredan colores del tema de la presentación. El ejemplo utiliza rellenos RGB explícitos para obtener una salida predecible. Si el diagrama debe seguir los cambios de tema, use colores de esquema en lugar de valores RGB fijos y evite sobrescribir cada nivel. También verifique el contraste de la etiqueta tras modificar el relleno de una rama o tronco.

### **Etiquetas y espacio disponible**

PowerPoint puede ocultar o truncar etiquetas cuando un segmento es demasiado pequeño. Aumentar el tamaño del diagrama, acortar los nombres de categoría o mostrar menos campos de etiqueta suele producir un resultado más claro. Una etiqueta puede combinar el nombre de la categoría, el nombre de la serie y el valor mediante [IDataLabelFormat](https://reference.aspose.com/slides/es/net/aspose.slides.charts/idatalabelformat/), pero habilitar todos los campos a menudo dificulta la lectura de diagramas jerárquicos.

### **Exportación y renderizado**

Guardar en PPTX mantiene el diagrama editable. Cuando Aspose.Slides renderiza la presentación a PDF o a una imagen, los rellenos y ajustes de etiqueta compatibles se renderizan con el diagrama. La sustitución de fuentes y pequeñas diferencias en el espacio de disposición disponible pueden cambiar el ajuste de línea o la visibilidad de la etiqueta, por lo que debe instalar las fuentes requeridas y verificar los destinos de exportación importantes.

## **Preguntas frecuentes**

**¿Por qué al cambiar un nivel padre afecta a varias hojas?**

Una rama o tronco es un segmento visual compartido. Su [IChartDataPointLevel](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartdatapointlevel/) se puede alcanzar a través de una hoja descendiente, pero el formato pertenece al segmento padre compartido y no solo a esa hoja.

**¿Por qué falta una etiqueta de datos?**

Primero habilite los campos requeridos en el objeto [IDataLabelFormat](https://reference.aspose.com/slides/es/net/aspose.slides.charts/idatalabelformat/) de la etiqueta. Después compruebe que el segmento tenga suficiente espacio. El diseño de etiquetas de padres en Treemap, las dimensiones del diagrama, la longitud de la etiqueta, el tamaño de fuente y el número de campos habilitados influyen en si se puede mostrar una etiqueta.

**¿Puedo establecer el orden o las coordenadas exactas de los segmentos?**

Puede controlar el orden de las filas de origen y mantener cada grupo contiguo, pero no puede asignar rectángulos exactos de Treemap ni ángulos exactos de Sunburst. El motor de disposición del diagrama los calcula a partir de la jerarquía, los valores y el espacio disponible.

**¿Por qué cambian los colores después de modificar el tema de la presentación?**

Los rellenos basados en el tema están diseñados para seguir la paleta de la presentación. Aplique colores RGB explícitos a los niveles que deben permanecer fijos, o mantenga los colores de esquema cuando prefiera adaptarse a un nuevo tema.

**¿Se preservará el formato personalizado en exportaciones a PDF e imágenes?**

Sí, los rellenos y ajustes de etiqueta compatibles se incluyen durante el renderizado. Para obtener resultados consistentes entre sistemas, haga que las fuentes requeridas estén disponibles y pruebe el tamaño de exportación final, ya que el ajuste de etiquetas depende de la disposición.

## **Véase también**

- [Create Treemap charts](/slides/es/net/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/es/net/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/es/net/export-chart/)
- [Manage presentation themes](/slides/es/net/presentation-theme/)