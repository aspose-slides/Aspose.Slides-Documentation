---
title: Personalizar puntos de datos en gráficos Treemap y Sunburst en C++
linktitle: Puntos de datos en gráficos Treemap y Sunburst
type: docs
url: /es/cpp/data-points-of-treemap-and-sunburst-chart/
keywords:
- gráfico treemap
- gráfico sunburst
- gráfico jerárquico
- punto de datos
- etiqueta de datos
- color de rama
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Aprenda cómo crear datos jerárquicos y personalizar niveles, etiquetas y colores en gráficos Treemap y Sunburst con Aspose.Slides para C++."
---
## **Visión general**

Los gráficos Treemap y Sunburst muestran el mismo tipo de datos jerárquicos, pero utilizan diseños diferentes. Un Treemap dibuja la jerarquía como rectángulos anidados cuyo área representa los valores de hoja. Un Sunburst la dibuja como anillos concéntricos: los grupos de nivel superior están cerca del centro y las categorías de hoja están en el anillo exterior.

En Aspose.Slides for C++, cada valor numérico es un [IChartDataPoint](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichartdatapoint/). Su método [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) proporciona acceso a la hoja y a sus grupos padre. Este artículo explica esa asignación y muestra cómo crear y dar formato a ambos tipos de gráfico a partir de los mismos datos de muestra.

![Un gráfico Treemap con ramas Consumer y Business](treemap-hierarchy.png)

![Un gráfico Sunburst con la misma jerarquía Consumer y Business](sunburst-hierarchy.png)

## **Comprender categorías, puntos de datos y niveles**

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

Los índices devueltos por [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) se cuentan desde la hoja hacia arriba:

| `get_DataPointLevels()` index | Nivel lógico | Representación Treemap | Representación Sunburst |
| ---: | --- | --- | --- |
| `0` | Hoja | Rectángulo de valor | Segmento del anillo externo |
| `1` | Tronco | Rectángulo o encabezado padre | Segmento del anillo medio |
| `2` | Rama | Rectángulo o encabezado de nivel superior | Segmento del anillo interno |

Este orden es el mismo para ambos tipos de gráfico aunque sus disposiciones visuales difieran. Un segmento padre se comparte entre varias hojas. Para darle formato, use el nivel correspondiente del primer punto de datos en ese grupo. Por ejemplo, la rama `Consumer` comienza con el punto `Laptops`, mientras que el tronco `Software` comienza con el punto `Licenses`. Mantener referencias a esos puntos es más claro y seguro que usar expresiones no explicadas como `dataPoints->idx_get(0)` o `dataPoints->idx_get(6)`.

## **Crear y personalizar ambos tipos de gráfico**

El siguiente ejemplo completo crea un Treemap en la primera diapositiva y un Sunburst en la segunda diapositiva. Construye la jerarquía, muestra el valor de `Tablets`, aplica colores fijos a niveles seleccionados, da formato a una etiqueta de rama y guarda la presentación.

```cpp
auto presentation = MakeObject<Presentation>();

auto addHierarchyChart = [](SharedPtr<ISlide> slide, ChartType chartType)
{
    const int worksheetIndex = 0;
    const int leafLevelIndex = 0;
    const int stemLevelIndex = 1;
    const int branchLevelIndex = 2;

    auto chart = slide->get_Shapes()->AddChart(chartType, 40, 40, 640, 440);
    chart->set_HasTitle(false);
    chart->set_HasLegend(false);
    chart->get_ChartData()->get_Categories()->Clear();
    chart->get_ChartData()->get_Series()->Clear();

    auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
    workbook->Clear(worksheetIndex);

    auto addCategory = [&](int rowIndex, const String& leafName)
    {
        auto leafNameValue = ObjectExt::Box<String>(leafName);
        auto categoryCell = workbook->GetCell(worksheetIndex, rowIndex, 2, leafNameValue);
        return chart->get_ChartData()->get_Categories()->Add(categoryCell);
    };

    auto setGroupingItem = [](SharedPtr<IChartCategory> category, int levelIndex,
                              const String& groupName)
    {
        auto groupNameValue = ObjectExt::Box<String>(groupName);
        category->get_GroupingLevels()->SetGroupingItem(levelIndex, groupNameValue);
    };

    // Añadir las categorías hoja. Un elemento de agrupación se establece solo cuando comienza un nuevo grupo;
    // las categorías siguientes permanecen en ese grupo hasta que se establezca otro elemento.
    auto laptopsCategory = addCategory(1, u"Laptops");
    setGroupingItem(laptopsCategory, stemLevelIndex, u"Computers");
    setGroupingItem(laptopsCategory, branchLevelIndex, u"Consumer");

    addCategory(2, u"Desktops");

    auto phonesCategory = addCategory(3, u"Phones");
    setGroupingItem(phonesCategory, stemLevelIndex, u"Mobile");

    addCategory(4, u"Tablets");

    auto consultingCategory = addCategory(5, u"Consulting");
    setGroupingItem(consultingCategory, stemLevelIndex, u"Services");
    setGroupingItem(consultingCategory, branchLevelIndex, u"Business");

    addCategory(6, u"Support");

    auto licensesCategory = addCategory(7, u"Licenses");
    setGroupingItem(licensesCategory, stemLevelIndex, u"Software");

    addCategory(8, u"Subscriptions");

    auto seriesNameValue = ObjectExt::Box<String>(u"Revenue");
    auto seriesNameCell = workbook->GetCell(worksheetIndex, 0, 3, seriesNameValue);
    auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, chartType);
    series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowCategoryName(true);

    auto addDataPoint = [&](int rowIndex, double value)
    {
        auto valueObject = ObjectExt::Box<double>(value);
        auto valueCell = workbook->GetCell(worksheetIndex, rowIndex, 3, valueObject);

        if (chartType == ChartType::Treemap)
        {
            return series->get_DataPoints()->AddDataPointForTreemapSeries(valueCell);
        }

        return series->get_DataPoints()->AddDataPointForSunburstSeries(valueCell);
    };

    auto laptopsDataPoint = addDataPoint(1, 12);
    addDataPoint(2, 8);
    addDataPoint(3, 15);
    auto tabletsDataPoint = addDataPoint(4, 6);
    addDataPoint(5, 10);
    addDataPoint(6, 7);
    auto licensesDataPoint = addDataPoint(7, 11);
    addDataPoint(8, 14);

    auto setSolidFill = [](SharedPtr<IFillFormat> fillFormat, Color color)
    {
        fillFormat->set_FillType(FillType::Solid);
        fillFormat->get_SolidFillColor()->set_Color(color);
    };

    // Mostrar la categoría y el valor en la hoja Tablets.
    auto tabletsLeafLevel = tabletsDataPoint->get_DataPointLevels()->idx_get(leafLevelIndex);
    auto tabletsLabelFormat = tabletsLeafLevel->get_Label()->get_DataLabelFormat();
    tabletsLabelFormat->set_ShowCategoryName(true);
    tabletsLabelFormat->set_ShowValue(true);
    tabletsLabelFormat->set_Separator(u"\n");
    tabletsLabelFormat->set_NumberFormat(u"$0");

    // Dar formato a la rama Consumer a través de la primera hoja de esa rama.
    auto consumerBranchLevel = laptopsDataPoint->get_DataPointLevels()->idx_get(branchLevelIndex);
    auto consumerBranchFill = consumerBranchLevel->get_Format()->get_Fill();
    auto consumerBranchColor = Color::FromArgb(31, 78, 121);
    setSolidFill(consumerBranchFill, consumerBranchColor);

    auto consumerLabelFormat = consumerBranchLevel->get_Label()->get_DataLabelFormat();
    consumerLabelFormat->set_ShowCategoryName(true);
    consumerLabelFormat->set_ShowSeriesName(false);
    auto consumerLabelTextFill = consumerLabelFormat->get_TextFormat()
        - >get_PortionFormat()->get_FillFormat();
    setSolidFill(consumerLabelTextFill, Color::get_White());

    // Dar formato al tronco Software a través de la primera hoja de ese tronco.
    auto softwareStemLevel = licensesDataPoint->get_DataPointLevels()->idx_get(stemLevelIndex);
    auto softwareStemFill = softwareStemLevel->get_Format()->get_Fill();
    auto softwareStemColor = Color::FromArgb(112, 173, 71);
    setSolidFill(softwareStemFill, softwareStemColor);

    // ParentLabelLayout afecta a las etiquetas de los padres en Treemap; Sunburst utiliza segmentos de anillo.
    if (chartType == ChartType::Treemap)
    {
        series->set_ParentLabelLayout(ParentLabelLayoutType::Overlapping);
    }
};

auto treemapSlide = presentation->get_Slide(0);
addHierarchyChart(treemapSlide, ChartType::Treemap);

auto layoutSlide = presentation->get_LayoutSlide(0);
auto sunburstSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
addHierarchyChart(sunburstSlide, ChartType::Sunburst);

presentation->Save(u"hierarchical-charts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Las celdas de categoría y las celdas de valor utilizan la misma fila de hoja de cálculo, por lo que sus posiciones en la colección permanecen alineadas. Cuando trabaje con un gráfico existente en lugar de crear uno, inspeccione primero las filas de categoría y almacene referencias nombradas a los puntos de datos y niveles que pretenda formatear.

## **Comportamiento y consideraciones prácticas**

### **Diferencias entre Treemap y Sunburst**

- Un Treemap usa el área para comunicar el valor y rectángulos anidados para comunicar la jerarquía. El método [IChartSeries::get_ParentLabelLayout()](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichartseries/get_parentlabellayout/) controla cómo aparecen las etiquetas de los padres en este tipo de gráfico.
- Un Sunburst usa el ángulo para comunicar el valor y la profundidad del anillo para comunicar la jerarquía. [IChartSeries::get_ParentLabelLayout()](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichartseries/get_parentlabellayout/) no controla sus etiquetas de anillo.
- Ambos tipos de gráfico utilizan los mismos niveles de agrupación de categoría y el mismo orden hoja‑padre devuelto por [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/), por lo que el código de construcción de datos y de formato de niveles puede compartirse.
- Los valores de los padres se calculan a partir de sus hojas descendientes. No añada puntos numéricos separados para ramas o troncos.

### **Orden de clasificación y de segmentos**

El motor de disposición del gráfico determina la colocación final de los rectángulos y de los segmentos de anillo. Agrupe filas de categoría relacionadas antes de añadirlas, pero no confíe en una posición de rectángulo o ángulo de inicio específico. Si la secuencia tiene significado, inclúyala en las etiquetas o utilice un tipo de gráfico con eje de categoría explícito.

### **Tema y colores fijos**

Los niveles de gráfico sin formato heredan colores del tema de la presentación. El ejemplo usa rellenos RGB explícitos para obtener una salida predecible. Si el gráfico debe seguir los cambios de tema, utilice colores de esquema en lugar de valores RGB fijos y evite sobrescribir cada nivel. También compruebe el contraste de la etiqueta después de cambiar el relleno de una rama o tronco.

### **Etiquetas y espacio disponible**

PowerPoint puede ocultar o truncar etiquetas cuando un segmento es demasiado pequeño. Aumentar el tamaño del gráfico, acortar los nombres de categoría o mostrar menos campos de etiqueta suele producir un resultado más claro. Una etiqueta puede combinar el nombre de categoría, el nombre de la serie y el valor mediante [IDataLabelFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/idatalabelformat/), pero habilitar todos los campos a menudo dificulta la lectura de los gráficos jerárquicos.

### **Exportación y renderizado**

Guardar en PPTX mantiene el gráfico editable. Cuando Aspose.Slides renderiza la presentación a PDF o a una imagen, los rellenos y ajustes de etiqueta compatibles se renderizan con el gráfico. La sustitución de fuentes y pequeñas diferencias en el espacio de disposición disponible pueden cambiar el ajuste de línea o la visibilidad de la etiqueta, así que instale las fuentes requeridas y verifique los destinos de exportación importantes.

## **Preguntas frecuentes**

**¿Por qué al cambiar un nivel padre afecta a varias hojas?**

Una rama o tronco es un segmento visual compartido. Su [IChartDataPointLevel](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichartdatapointlevel/) puede alcanzarse a través de una hoja descendiente, pero el formato pertenece al segmento padre compartido y no solo a esa hoja.

**¿Por qué falta una etiqueta de datos?**

Primero habilite los campos requeridos en el objeto [IDataLabelFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/idatalabelformat/) de la etiqueta. Luego compruebe si el segmento tiene suficiente espacio. El diseño de etiquetas de padres en Treemap, las dimensiones del gráfico, la longitud de la etiqueta, el tamaño de la fuente y el número de campos habilitados influyen en si una etiqueta puede mostrarse.

**¿Puedo definir el orden exacto o las coordenadas de los segmentos?**

Puede controlar el orden de filas de origen y mantener cada grupo contiguo, pero no puede asignar rectángulos exactos de Treemap ni ángulos exactos de Sunburst. El motor de disposición del gráfico los calcula a partir de la jerarquía, los valores y el espacio disponible.

**¿Por qué cambian los colores después de modificar el tema de la presentación?**

Los rellenos basados en el tema están diseñados para seguir la paleta de la presentación. Aplique colores RGB explícitos a los niveles que deben permanecer fijos, o mantenga colores de esquema cuando prefiera adaptar el gráfico a un nuevo tema.

**¿Se conserva el formato personalizado en exportaciones a PDF e imágenes?**

Sí, los rellenos y ajustes de etiqueta compatibles se incluyen durante el renderizado. Para obtener resultados consistentes entre sistemas, haga disponibles las fuentes requeridas y pruebe el tamaño final de exportación, ya que el ajuste de etiquetas depende de la disposición.

## **Véase también**

- [Create Treemap charts](/slides/es/cpp/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/es/cpp/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/es/cpp/export-chart/)
- [Manage presentation themes](/slides/es/cpp/presentation-theme/)