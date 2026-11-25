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
description: "Crea grafici 3D nelle presentazioni PowerPoint con Aspose.Slides per C++. Regola rotazione, proporzioni dell'altezza, profondità del grafico e spaziatura tra le serie con esempi C++."
---
## **Panoramica**

Aspose.Slides per C++ consente di personalizzare la visualizzazione di un grafico 3D tramite [IChart::get_Rotation3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_rotation3d/). Questo articolo dimostra come regolare la rotazione, le proporzioni dell'altezza, la profondità, gli assi a angolo retto e la spaziatura tra le serie, quindi salvare la presentazione in formato PPTX.

## **Imposta la Rotazione e la Profondità di un Grafico 3D**

L'esempio seguente crea una [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) e utilizza [IShapeCollection::AddChart](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addchart/) per aggiungere un grafico a colonne 3D impilate alla sua prima diapositiva. Sostituisce le serie e le categorie predefinite con due serie contenenti tre valori ciascuna. L'indice del foglio di lavoro `0` identifica il primo foglio dati del grafico; la riga `0` contiene i nomi delle serie e la colonna `0` contiene le etichette delle categorie.

I metodi [set_RotationX](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationx/) e [set_RotationY](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationy/) impostano la rotazione del grafico a 40 e 270 gradi, rispettivamente. [set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) imposta la sua profondità al 150% della larghezza, mentre [set_RightAngleAxes](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rightangleaxes/) abilita gli assi a angolo retto anziché la prospettiva. La presentazione risultante contiene il grafico popolato con queste impostazioni di visualizzazione 3D.

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

## **Applica un Riempimento Immagine alla Superficie di un Grafico 3D**

È possibile riempire in modo indipendente la [side wall](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_sidewall/), la [back wall](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_backwall/) e il [floor](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_floor/) di un grafico 3D. Imposta il [fill type](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) della superficie su `Picture` e assegna un'immagine. Per adattare una copia dell'immagine alla superficie, imposta sia la [picture fill mode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/) sia il [picture type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartwall/set_picturetype/) della superficie su `Stretch`.

Salva [arrow.png](arrow.png) nella directory di lavoro. L'esempio ruota il grafico e aumenta il valore massimo sull'asse verticale in modo che il pavimento sia visibile tra le colonne. Quindi clona la diapositiva due volte e applica la freccia a una superficie diversa in ciascuna diapositiva. Tutti e tre i grafici mantengono gli stessi dati, angolo di visualizzazione e sfondo.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartWall.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/Chart/IRotation3D.h>
#include <DOM/Chart/PictureType.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/shared_ptr.h>
#include <initializer_list>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 20, 30, 680, 480);
chart->get_Rotation3D()->set_RightAngleAxes(true);
chart->get_Rotation3D()->set_RotationX(40);
chart->get_Rotation3D()->set_RotationY(30);

auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
verticalAxis->set_IsAutomaticMaxValue(false);
verticalAxis->set_MaxValue(24);

auto backSlide = presentation->get_Slides()->AddClone(slide);
auto floorSlide = presentation->get_Slides()->AddClone(slide);
auto backChart = ExplicitCast<IChart>(backSlide->get_Shape(0));
auto floorChart = ExplicitCast<IChart>(floorSlide->get_Shape(0));

auto imageBytes = IO::File::ReadAllBytes(u"arrow.png");
auto arrow = presentation->get_Images()->AddImage(imageBytes);

for (const auto& surface : { chart->get_SideWall(), backChart->get_BackWall(), floorChart->get_Floor() })
{
    auto fill = surface->get_Format()->get_Fill();
    fill->set_FillType(FillType::Picture);
    auto pictureFill = fill->get_PictureFillFormat();
    pictureFill->get_Picture()->set_Image(arrow);
    pictureFill->set_PictureFillMode(PictureFillMode::Stretch);
    surface->set_PictureType(PictureType::Stretch);
}

presentation->Save(u"chart-surfaces.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Microsoft PowerPoint mostra le tre diapositive come segue.

| Parete laterale | Parete posteriore | Pavimento |
| --- | --- | --- |
| ![Freccia che punta nel grafico lungo la parete laterale](side-wall.png) | ![Freccia che punta a destra lungo la parete posteriore](back-wall.png) | ![Freccia che punta a destra lungo il pavimento tra le colonne](floor.png) |

## **Regola le Proporzioni dell'Altezza di un Grafico 3D**

Usa [IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/) per impostare l'altezza di un grafico 3D come percentuale della sua larghezza. Questo modifica le proporzioni della scena 3D senza ridimensionare l'oggetto grafico sulla diapositiva.

L'esempio seguente crea un grafico [Column3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) con i dati predefiniti: tre serie e quattro categorie. Salva tre presentazioni con proporzioni di altezza del 50%, 100% e 200%. La posizione, larghezza e altezza del grafico rimangono fisse. I dati, la rotazione, la profondità, la spaziatura delle serie e la formattazione sono identici in tutti e tre i file; cambia solo la percentuale di altezza.

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

Le immagini seguenti dell'esempio .NET equivalente sono state esportate con Microsoft PowerPoint e illustrano le stesse impostazioni di altezza. Una percentuale più piccola produce una scena più piatta, mentre una percentuale più grande produce una scena più alta all'interno dello stesso oggetto grafico. PowerPoint potrebbe anche regolare gli intervalli dei tick dell'asse e la posizione delle etichette per adattare la scena.

| Altezza: 50% | Altezza: 100% | Altezza: 200% |
| --- | --- | --- |
| ![Grafico a colonne 3D con altezza impostata al 50 percento della larghezza](height_percent_50.png) | ![Grafico a colonne 3D con altezza impostata al 100 percento della larghezza](height_percent_100.png) | ![Grafico a colonne 3D con altezza impostata al 200 percento della larghezza](height_percent_200.png) |

Questi metodi controllano diversi aspetti del grafico:

| Metodo | Effetto |
| --- | --- |
| [IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/) | Altezza della scena 3D come percentuale della sua larghezza. |
| [IShape::set_Height](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_height/) | Altezza dell'oggetto grafico sulla diapositiva, in punti. |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | Profondità della scena 3D come percentuale della sua larghezza. |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | Spaziatura tra le serie lungo l'asse di profondità, come percentuale della larghezza del marcatore. |

L'impostazione dell'altezza influisce su grafici a colonne e barre 3D, incluse le varianti cilindro, cono e piramide, nonché su grafici 3D a linee, aree, torta e superficie. Il confronto sopra utilizza il tipo verificato `Column3D`. L'impostazione non modifica l'aspetto di un grafico 2D `ClusteredColumn` o di un grafico `BubbleWith3D`; questi nomi sono membri dell'enumerazione [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/). Per altre impostazioni dell'aspetto del grafico, vedere [Chart Formatting](/slides/it/cpp/chart-formatting/).

## **Regola lo Spazio Tra le Serie**

Usa [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) per controllare la distanza tra le serie di dati lungo l'asse di profondità di un grafico 3D, espressa come percentuale della larghezza del marcatore. Usa valori da **0 a 500**, inclusi: `0` rimuove lo spazio, mentre valori più alti aumentano la spaziatura. Con una profondità di grafico fissa, aumentare lo spazio rende i marcatori più sottili lungo l'asse di profondità.

Accedi al gruppo attraverso [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/). L'impostazione si applica a tutte le serie in quel gruppo, non solo alla serie usata per accedervi. [IChartSeries::get_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_gapdepth/) restituisce l'impostazione del gruppo genitore.

Questa impostazione influisce su grafici a colonne e barre 3D, incluse le varianti cilindro, cono e piramide, nonché su grafici 3D a linee e aree. L'aspetto dipende dal fatto che le serie siano disposte in profondità, raggruppate o impilate. Per un chiaro confronto degli spazi tra serie separate, usa `ChartType::Column3D` dell'enumerazione [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/).

Questi metodi controllano diversi aspetti del grafico:

| Metodo | Effetto |
| --- | --- |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | Spaziatura tra le serie lungo l'asse di profondità, come percentuale della larghezza del marcatore. |
| [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) | Spaziatura tra i raggruppamenti adiacenti di barre o colonne, come percentuale della larghezza della barra o della colonna. |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | Profondità complessiva del grafico, come percentuale della larghezza del grafico. |

L'esempio autonomo seguente utilizza i dati predefiniti del grafico, che contengono tre serie e quattro categorie. Salva due presentazioni con dati, rotazione, larghezza dello spazio e profondità del grafico identici; cambia solo la profondità dello spazio.

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

Le immagini seguenti dell'esempio .NET equivalente sono state esportate con Microsoft PowerPoint e illustrano le stesse impostazioni di profondità dello spazio.

| Profondità spazio: 0% | Profondità spazio: 500% |
| --- | --- |
| ![Grafico a colonne 3D senza spazio tra le serie lungo l'asse di profondità](gap_depth_0.png) | ![Grafico a colonne 3D con uno spazio del 500 percento tra le serie lungo l'asse di profondità](gap_depth_500.png) |

## **Cambia il Tipo di Serie 3D e la Forma della Barra**

In un grafico a cilindri raggruppati, la prima serie inizia con barre cilindriche. L'esempio legge [IChartSeries::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_type/) e [IChartSeries::get_Bar3DShape](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_bar3dshape/) prima e dopo ogni modifica.

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

| Cambia alla prima serie | `get_Type` | `get_Bar3DShape` |
| --- | --- | --- |
| Crea il grafico | `ClusteredCylinder` | `Cylinder` |
| Chiama [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_type/) con `ClusteredCone` | `ClusteredCone` | `Cone` |
| Chiama [set_Bar3DShape](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_bar3dshape/) con `Box` | `ClusteredColumn3D` | `Box` |

Impostare la forma su `Box` cambia anche il tipo di serie in `ClusteredColumn3D`. Se il tuo codice ramifica in base al tipo di serie, chiama `series->get_Type()` dopo aver cambiato la forma. Un valore memorizzato prima della modifica selezionerebbe ancora il ramo `ClusteredCone`.

![Confronto PowerPoint che mostra la prima serie come cilindri, coni e colonne rettangolari da sinistra a destra](series-shapes.png)

## **FAQ**

**Quali tipi di grafico supportano la modalità 3D in Aspose.Slides?**

Aspose.Slides supporta varianti 3D dei grafici a colonne, incluse Column 3D, Clustered Column 3D, Stacked Column 3D e 100% Stacked Column 3D, insieme ai tipi 3D correlati esposti tramite l'enumerazione [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/). Per un elenco esatto e aggiornato, controlla i membri di [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) nella documentazione API della tua versione installata.

**Posso ottenere un'immagine raster di un grafico 3D per un report o il web?**

Sì. Puoi esportare un grafico in un'immagine con [Shape::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) o [renderizzare l'intera diapositiva](/slides/it/cpp/convert-powerpoint-to-png/) in formati come PNG o JPEG. Questo è utile quando hai bisogno di un'anteprima raster o vuoi incorporare il grafico in documenti, dashboard o pagine web senza richiedere PowerPoint.

**Qual è la performance nella creazione e nel rendering di grandi grafici 3D?**

Le prestazioni dipendono dal volume dei dati e dalla complessità visiva. Per i migliori risultati, mantieni gli effetti 3D al minimo, evita texture pesanti su pareti e aree di tracciato, limita il numero di punti dati per serie quando possibile e renderizza a una risoluzione e dimensioni adeguate al dispositivo di destinazione o alle esigenze di stampa.