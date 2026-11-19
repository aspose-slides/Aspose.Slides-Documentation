---
title: Personalizza i grafici 3D nelle presentazioni usando C++
linktitle: Grafico 3D
type: docs
url: /it/cpp/3d-chart/
keywords:
- grafico 3D
- rotazione
- profondità
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Crea grafici 3D nelle presentazioni PowerPoint con Aspose.Slides per C++. Regola rotazione, proporzioni di altezza, profondità del grafico e spaziatura tra le serie con esempi C++."
---
## **Panoramica**

Aspose.Slides per C++ consente di personalizzare la visualizzazione di un grafico 3D tramite [IChart::get_Rotation3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_rotation3d/). Questo articolo mostra come regolare rotazione, proporzioni di altezza, profondità, assi a angolo retto e spaziatura tra le serie, quindi salvare la presentazione in formato PPTX.

## **Impostare la rotazione e la profondità di un grafico 3D**

L’esempio seguente crea una [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) e utilizza [IShapeCollection::AddChart](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addchart/) per aggiungere un grafico a colonne 3D impilate alla sua prima diapositiva. Sostituisce le serie e le categorie predefinite con due serie contenenti tre valori ciascuna. L’indice del foglio di lavoro `0` identifica il primo foglio di dati del grafico; la riga `0` contiene i nomi delle serie e la colonna `0` contiene le etichette delle categorie.

I metodi [set_RotationX](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationx/) e [set_RotationY](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationy/) impostano la rotazione del grafico a 40 e 270 gradi, rispettivamente. [set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) ne imposta la profondità al 150 % della larghezza, mentre [set_RightAngleAxes](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rightangleaxes/) abilita gli assi a angolo retto invece della prospettiva. La presentazione risultante contiene il grafico popolato con queste impostazioni di visualizzazione 3D.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IRotation3D.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn3D, 0, 0, 500, 500);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheetIndex = 0;

double values[2][3] = { { 20, 50, 30 }, { 30, 10, 60 } };

for (auto categoryIndex = 0; categoryIndex < 3; categoryIndex++)
{
    auto categoryName = String::Format(u"Category {0}", categoryIndex + 1);
    auto categoryCell = workbook->GetCell(worksheetIndex, categoryIndex + 1, 0, ObjectExt::Box(categoryName));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);
}

for (auto seriesIndex = 0; seriesIndex < 2; seriesIndex++)
{
    auto seriesName = String::Format(u"Series {0}", seriesIndex + 1);
    auto seriesCell = workbook->GetCell(worksheetIndex, 0, seriesIndex + 1, ObjectExt::Box(seriesName));
    auto series = chart->get_ChartData()->get_Series()->Add(seriesCell, chart->get_Type());

    for (auto categoryIndex = 0; categoryIndex < 3; categoryIndex++)
    {
        auto valueCell = workbook->GetCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, ObjectExt::Box(values[seriesIndex][categoryIndex]));
        series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
    }
}

chart->get_Rotation3D()->set_RightAngleAxes(true);
chart->get_Rotation3D()->set_RotationX(40);
chart->get_Rotation3D()->set_RotationY(270);
chart->get_Rotation3D()->set_DepthPercents(150);

presentation->Save(u"Rotation3D_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Regolare le proporzioni di altezza di un grafico 3D**

Utilizzare [IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/) per impostare l’altezza di un grafico 3D come percentuale della sua larghezza. Questo modifica le proporzioni della scena 3D senza ridimensionare l’oggetto grafico nella diapositiva.

L’esempio seguente crea un grafico [Column3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) con i dati predefiniti: tre serie e quattro categorie. Salva tre presentazioni con proporzioni di altezza del 50 %, 100 % e 200 %. La posizione, la larghezza e l’altezza del grafico rimangono fisse. I dati, la rotazione, la profondità, la spaziatura delle serie e la formattazione sono identici in tutti e tre i file; varia solo la percentuale di altezza.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/Chart/IRotation3D.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <cstdint>
#include <initializer_list>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 40, 30, 620, 460);
chart->get_Rotation3D()->set_RotationX(20);
chart->get_Rotation3D()->set_RotationY(30);
chart->get_Rotation3D()->set_RightAngleAxes(true);
chart->get_Rotation3D()->set_DepthPercents(100);
chart->get_ChartData()->get_Series()->idx_get(0)->get_ParentSeriesGroup()->set_GapDepth(150);

for (uint16_t heightPercent : { 50, 100, 200 })
{
    chart->get_Rotation3D()->set_HeightPercents(heightPercent);
    auto fileName = String::Format(u"chart_height_{0}.pptx", heightPercent);
    presentation->Save(fileName, SaveFormat::Pptx);
}
presentation->Dispose();
```

Le immagini seguenti, tratte dall’esempio .NET equivalente, sono state esportate con Microsoft PowerPoint e illustrano le stesse impostazioni di altezza. Una percentuale più piccola produce una scena più piatta, mentre una percentuale più grande genera una scena più alta all’interno dello stesso oggetto grafico. PowerPoint può anche regolare gli intervalli delle tacche degli assi e la disposizione delle etichette per adattarsi alla scena.

| Altezza: 50 % | Altezza: 100 % | Altezza: 200 % |
| --- | --- | --- |
| ![Grafico a colonne 3D con altezza impostata al 50 percento della sua larghezza](height_percent_50.png) | ![Grafico a colonne 3D con altezza impostata al 100 percento della sua larghezza](height_percent_100.png) | ![Grafico a colonne 3D con altezza impostata al 200 percento della sua larghezza](height_percent_200.png) |

Questi metodi controllano aspetti diversi del grafico:

| Metodo | Effetto |
| --- | --- |
| [IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/) | Altezza della scena 3D come percentuale della sua larghezza. |
| [IShape::set_Height](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_height/) | Altezza dell’oggetto grafico nella diapositiva, in punti. |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | Profondità della scena 3D come percentuale della sua larghezza. |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | Spaziatura tra le serie lungo l’asse di profondità, come percentuale della larghezza del marcatore. |

L’impostazione di altezza influisce sui grafici a colonne e a barre 3D, comprese le varianti cilindro, cono e piramide, nonché sui grafici a linee, aree, torta e superficie 3D. Il confronto sopra utilizza il tipo verificato `Column3D`. L’impostazione non modifica l’aspetto di un grafico 2D `ClusteredColumn` o di un grafico `BubbleWith3D`; questi nomi sono membri dell’enumerazione [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/). Per altre impostazioni di aspetto del grafico, consultare [Chart Formatting](/slides/it/cpp/chart-formatting/).

## **Regolare lo spazio tra le serie**

Utilizzare [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) per controllare la distanza tra le serie di dati lungo l’asse di profondità di un grafico 3D, espressa come percentuale della larghezza del marcatore. Utilizzare valori da **0 a 500**, inclusi: `0` elimina lo spazio, mentre valori più alti aumentano la spaziatura. Con una profondità del grafico fissa, aumentare lo spazio rende i marcatori più sottili lungo l’asse di profondità.

Accedere al gruppo tramite [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/). L’impostazione si applica a tutte le serie in quel gruppo, non solo alla serie usata per accedervi. [IChartSeries::get_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_gapdepth/) restituisce l’impostazione del gruppo padre.

Questa impostazione influisce sui grafici a colonne e a barre 3D, comprese le loro varianti cilindro, cono e piramide, nonché sui grafici a linee e a aree 3D. L’aspetto dipende dal fatto che le serie siano disposte in profondità, raggruppate o impilate. Per un confronto chiaro degli spazi tra serie separate, utilizzare `ChartType::Column3D` dell’enumerazione [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/).

Questi metodi controllano aspetti diversi del grafico:

| Metodo | Effetto |
| --- | --- |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | Spaziatura tra le serie lungo l’asse di profondità, come percentuale della larghezza del marcatore. |
| [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) | Spaziatura tra i cluster di barre o colonne adiacenti, come percentuale della larghezza della barra o della colonna. |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | Profondità complessiva del grafico, come percentuale della larghezza del grafico. |

L’esempio autonomo seguente utilizza i dati di default del grafico, che contengono tre serie e quattro categorie. Salva due presentazioni con dati, rotazione, larghezza dello spazio e profondità del grafico identici; varia solo la profondità dello spazio.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IRotation3D.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <cstdint>
#include <initializer_list>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 40, 30, 620, 230);

chart->get_Rotation3D()->set_RotationX(20);
chart->get_Rotation3D()->set_RotationY(30);
chart->get_Rotation3D()->set_DepthPercents(100);

auto series = chart->get_ChartData()->get_Series()->idx_get(0);
auto group = series->get_ParentSeriesGroup();
group->set_GapWidth(150);

for (uint16_t gapDepth : { 0, 500 })
{
    group->set_GapDepth(gapDepth);

    auto fileName = String::Format(u"series_gap_depth_{0}.pptx", gapDepth);
    presentation->Save(fileName, SaveFormat::Pptx);
}
presentation->Dispose();
```

Le immagini seguenti, tratte dall’esempio .NET equivalente, sono state esportate con Microsoft PowerPoint e illustrano le stesse impostazioni di profondità dello spazio.

| Profondità spazio: 0 % | Profondità spazio: 500 % |
| --- | --- |
| ![Grafico a colonne 3D senza spazio tra le serie lungo l’asse di profondità](gap_depth_0.png) | ![Grafico a colonne 3D con uno spazio del 500 percento tra le serie lungo l’asse di profondità](gap_depth_500.png) |

## **Modificare il tipo di serie 3D e la forma della barra**

In un grafico cilindro raggruppato, la prima serie inizia con barre cilindriche. L’esempio legge [IChartSeries::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_type/) e [IChartSeries::get_Bar3DShape](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_bar3dshape/) prima e dopo ogni modifica.

```cpp
#include <DOM/Chart/ChartShapeType.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/enum.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredCylinder, 20, 20, 500, 300);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto printSeries = [&series]()
{
    auto type = Enum<ChartType>::GetName(series->get_Type());
    auto shape = Enum<ChartShapeType>::GetName(series->get_Bar3DShape());
    Console::WriteLine(u"{0} | {1}", type, shape);
};

printSeries();

series->set_Type(ChartType::ClusteredCone);
printSeries();

series->set_Bar3DShape(ChartShapeType::Box);
printSeries();

presentation->Save(u"series_shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

| Modifica alla prima serie | `get_Type` | `get_Bar3DShape` |
| --- | --- | --- |
| Creazione del grafico | `ClusteredCylinder` | `Cylinder` |
| Chiamata a [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_type/) con `ClusteredCone` | `ClusteredCone` | `Cone` |
| Chiamata a [set_Bar3DShape](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_bar3dshape/) con `Box` | `ClusteredColumn3D` | `Box` |

Impostare la forma su `Box` cambia anche il tipo di serie in `ClusteredColumn3D`. Se il codice esegue rami in base al tipo di serie, chiamare `series->get_Type()` dopo aver cambiato la forma. Un valore memorizzato prima della modifica selezionerebbe ancora il ramo `ClusteredCone`.

![Confronto PowerPoint che mostra la prima serie come cilindri, coni e colonne rettangolari da sinistra a destra](series-shapes.png)

## **FAQ**

**Quali tipi di grafico supportano la modalità 3D in Aspose.Slides?**

Aspose.Slides supporta le varianti 3D dei grafici a colonne, inclusi Column 3D, Clustered Column 3D, Stacked Column 3D e 100 % Stacked Column 3D, insieme ai relativi tipi 3D esposti tramite l’enumerazione [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/). Per un elenco preciso e aggiornato, controllare i membri di [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) nella documentazione API della versione installata.

**Posso ottenere un’immagine raster di un grafico 3D per un report o il web?**

Sì. È possibile esportare un grafico in un’immagine con [Shape::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) o [renderizzare l’intera diapositiva](/slides/it/cpp/convert-powerpoint-to-png/) in formati come PNG o JPEG. Questo è utile quando serve un’anteprima raster o si desidera incorporare il grafico in documenti, dashboard o pagine web senza richiedere PowerPoint.

**Qual è l’efficienza nella creazione e nel rendering di grandi grafici 3D?**

Le prestazioni dipendono dal volume dei dati e dalla complessità visiva. Per ottenere i migliori risultati, mantenere gli effetti 3D al minimo, evitare texture pesanti su pareti e aree di tracciato, limitare il numero di punti dati per serie laddove possibile e renderizzare a una risoluzione e dimensioni adeguate al dispositivo di visualizzazione o di stampa previsto.