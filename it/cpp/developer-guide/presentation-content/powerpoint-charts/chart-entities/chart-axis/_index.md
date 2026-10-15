---
title: Personalizza gli assi del grafico nelle presentazioni usando C++
linktitle: Asse del grafico
type: docs
url: /it/cpp/chart-axis/
keywords:
- asse del grafico
- asse verticale
- asse orizzontale
- personalizzare asse
- manipolare asse
- gestire asse
- proprietà dell'asse
- valore massimo
- valore minimo
- linea dell'asse
- formato data
- titolo dell'asse
- posizione dell'asse
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Scopri come utilizzare Aspose.Slides per C++ per personalizzare gli assi dei grafici nelle presentazioni PowerPoint per report e visualizzazioni."
---
## **Panoramica**

Questo articolo spiega come personalizzare gli assi dei grafici con Aspose.Slides per C++. Copre i valori degli assi calcolati, lo scambio di righe e colonne del grafico, la visibilità degli assi, gli intervalli delle etichette di categoria e dei segni di tacca, le categorie e la formattazione delle date, la rotazione del titolo, il posizionamento dell'asse, le unità di visualizzazione e la scala logaritmica.

## **Ottieni i valori massimi sull'asse verticale nei grafici**

Crea una [Presentazione](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) e aggiungi un grafico a aree con dati predefiniti. Chiama [ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/validatechartlayout/) prima di leggere i valori degli assi calcolati in modo che il layout del grafico sia aggiornato.

Leggi [get_ActualMaxValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmaxvalue/) e [get_ActualMinValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminvalue/) per i limiti dell'asse, e [get_ActualMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunit/) e [get_ActualMinorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunit/) per gli intervalli delle tacche. [get_ActualMajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunitscale/) e [get_ActualMinorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunitscale/) forniscono le scale unità di tempo, rilevanti per gli assi di tipo data. L'esempio memorizza questi valori in variabili locali e salva il grafico.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Area, 100, 100, 500, 350);
chart->ValidateChartLayout();

auto maxValue = chart->get_Axes()->get_VerticalAxis()->get_ActualMaxValue();
auto minValue = chart->get_Axes()->get_VerticalAxis()->get_ActualMinValue();

auto majorUnit = chart->get_Axes()->get_VerticalAxis()->get_ActualMajorUnit();
auto minorUnit = chart->get_Axes()->get_VerticalAxis()->get_ActualMinorUnit();

auto majorUnitScale = chart->get_Axes()->get_VerticalAxis()->get_ActualMajorUnitScale();
auto minorUnitScale = chart->get_Axes()->get_VerticalAxis()->get_ActualMinorUnitScale();

presentation->Save(u"AxisValues_out.pptx", SaveFormat::Pptx);
```

## **Scambia i dati tra gli assi**

Usa [SwitchRowColumn](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/switchrowcolumn/) per scambiare i ruoli di serie e categorie nei dati del grafico. Ogni precedente categoria diventa una serie, e ogni precedente serie diventa una categoria. Questo modifica il modo in cui i dati sono raggruppati; non scambia gli assi orizzontali e verticali. L'esempio utilizza [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/setrange/) per collegare i dati predefiniti a `Sheet1!A1:D5`, includendo la riga di intestazione e la colonna delle categorie, prima di scambiare righe e colonne. Salva un grafico con quattro serie e tre categorie.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartData.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100, 100, 400, 300);

chart->get_ChartData()->SetRange(u"Sheet1!A1:D5");
chart->get_ChartData()->SwitchRowColumn();

presentation->Save(u"SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
```

## **Inverti l'ordine di tracciamento di un asse**

Usa [set_IsPlotOrderReversed](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isplotorderreversed/) per invertire un asse di categoria o di valore. Per esempio, un grafico a barre orizzontali può mostrare le fasi di un progetto dall'alto verso il basso nello stesso ordine del foglio di lavoro: Pianificazione, Sviluppo, Test. Invertire un asse modifica la direzione di tracciamento; non ordina né riorganizza i dati della cartella di lavoro. In confronto, [SwitchRowColumn](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/switchrowcolumn/) scambia i ruoli di serie e categorie.

L'esempio seguente crea un grafico a barre orizzontali con tre fasi e una serie. Salva una presentazione con tre diapositive: ordine normale, categorie invertite e valori invertiti. Ogni copia utilizza lo stesso set di dati, e solo un asse è invertito in ciascuna copia.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/CrossesType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredBar, 50, 40, 620, 320);
chart->set_HasLegend(false);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::ClusteredBar);
auto stages = std::array<System::String, 3>{u"Planning", u"Development", u"Testing"};
auto values = std::array<int, 3>{10, 30, 20};
for (auto i = 0; i < stages.size(); i++)
{
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(stages[i]));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);
    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(values[i]));
    series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
}

// Diapositiva 2: visualizza la prima categoria in alto.
auto categorySlide = presentation->get_Slides()->AddClone(slide);
auto categoryChart = System::ExplicitCast<IChart>(categorySlide->get_Shape(0));
categoryChart->get_Axes()->get_VerticalAxis()->set_IsPlotOrderReversed(true);
// Mantieni l'asse dei valori orizzontale in basso.
categoryChart->get_Axes()->get_VerticalAxis()->set_CrossType(CrossesType::Maximum);

// Diapositiva 3: inverte solo la scala numerica orizzontale.
auto valueSlide = presentation->get_Slides()->AddClone(slide);
auto valueChart = System::ExplicitCast<IChart>(valueSlide->get_Shape(0));
valueChart->get_Axes()->get_HorizontalAxis()->set_IsPlotOrderReversed(true);

presentation->Save(u"ReversedAxes.pptx", SaveFormat::Pptx);
```

Invertire un asse può anche spostare l'asse perpendicolare sul lato opposto del tracciato. [set_CrossType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/) controlla dove l'altro asse incrocia l'asse configurato. Nella diapositiva 2, impostandolo su `Maximum` sull'asse di categoria invertito mantiene l'asse dei valori orizzontale in basso. Per un punto di incrocio specifico, usa [set_CrossAt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crossat/). Controlla le impostazioni di incrocio quando cambi direzione, specialmente se il grafico ha già un punto di incrocio personalizzato. Chiama `set_IsPlotOrderReversed` con `false` per ripristinare la direzione di tracciamento normale; le impostazioni di incrocio sono separate.

| Ordine normale (diapositiva 1) | Categorie invertite (diapositiva 2) | Valori invertiti (diapositiva 3) |
| --- | --- | --- |
| ![Grafico a barre orizzontali con ordine normale di asse di categoria e valore](axis-order-normal.png) | ![Grafico a barre orizzontali con categorie visualizzate dall'alto verso il basso](axis-order-categories-reversed.png) | ![Grafico a barre orizzontali con asse dei valori invertito e zero a destra](axis-order-values-reversed.png) |
| Le categorie vanno dal basso verso l'alto; i valori aumentano da sinistra a destra. | Pianificazione, Sviluppo e Test vanno dall'alto verso il basso. I valori e l'ordine delle righe del foglio di lavoro rimangono invariati. | Le categorie mantengono il loro ordine normale; i valori aumentano da destra a sinistra. L'asse di categoria incrocia a zero a destra. |

## **Disattiva l'asse verticale per i grafici a linee**

Usa [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/) con `false` sull'asse verticale per nasconderlo. L'esempio crea un grafico a linee con dati predefiniti e lo salva con l'asse verticale nascosto.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 100, 100, 400, 300);
chart->get_Axes()->get_VerticalAxis()->set_IsVisible(false);

presentation->Save(u"HiddenVerticalAxis.pptx", SaveFormat::Pptx);
```

## **Disattiva l'asse orizzontale per i grafici a linee**

Usa [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/) con `false` sull'asse orizzontale per nasconderlo. L'esempio crea un grafico a linee con dati predefiniti e lo salva con l'asse orizzontale nascosto.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 100, 100, 400, 300);
chart->get_Axes()->get_HorizontalAxis()->set_IsVisible(false);

presentation->Save(u"HiddenHorizontalAxis.pptx", SaveFormat::Pptx);
```

## **Modifica un asse di categoria**

Usa [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) per scegliere un asse di categoria data o testo. Questo esempio richiede `ExistingChart.pptx`, con un grafico come prima forma nella prima diapositiva e celle di categoria contenenti valori data Excel numerici. Cambia l'asse orizzontale in un asse data. Chiamando [set_IsAutomaticMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isautomaticmajorunit/) con `false`, [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunit/) con `1` e [set_MajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunitscale/) con mesi, posiziona le tacche principali a intervalli di un mese.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/TimeUnitType.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"ExistingChart.pptx");
auto slide = presentation->get_Slide(0);

auto chart = System::ExplicitCast<IChart>(slide->get_Shape(0));
chart->get_Axes()->get_HorizontalAxis()->set_CategoryAxisType(CategoryAxisType::Date);
chart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticMajorUnit(false);
chart->get_Axes()->get_HorizontalAxis()->set_MajorUnit(1);
chart->get_Axes()->get_HorizontalAxis()->set_MajorUnitScale(TimeUnitType::Months);

presentation->Save(u"ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
```

## **Controlla gli intervalli delle etichette dell'asse di categoria**

Quando un grafico ha molte categorie, riduci il numero di etichette dell'asse visibili senza rimuovere categorie o punti dati. Usa [set_IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomaticticklabelspacing/) con `false`, poi usa [set_TickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_ticklabelspacing/) con l'intervallo di categoria desiderato. Per le categorie di testo nel loro ordine normale, il conteggio inizia dalla prima categoria:

| Intervallo | Etichette visualizzate nell'esempio |
| --- | --- |
| `1` | Categoria 1, Categoria 2, Categoria 3, ... Categoria 24 |
| `2` | Categoria 1, Categoria 3, Categoria 5, ... Categoria 23 |
| `3` | Categoria 1, Categoria 4, Categoria 7, ... Categoria 22 |

Un intervallo di `3` visualizza ogni terza etichetta, lasciando nascoste due etichette tra quelle visualizzate. Non rimuove le colonne corrispondenti. La spaziatura automatica sceglie un intervallo basato sullo spazio disponibile; non visualizza necessariamente ogni etichetta.

I segni di tacca hanno controlli separati. Usa [set_IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomatictickmarksspacing/) con `false` e usa [set_TickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_tickmarksspacing/) per impostare il loro intervallo. Per esempio, `1` mantiene un segno di tacca a ogni intervallo di categoria mentre le etichette appaiono solo ogni terza categoria. Usa [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majortickmark/) con uno stile visibile così da poter vedere il risultato. Ripristinare qualsiasi proprietà di spaziatura automatica a `true` permette al grafico di scegliere nuovamente quell'intervallo.

L'esempio autonomo seguente crea 24 categorie e una serie, poi salva tre diapositive in `CategoryAxisIntervals.pptx`: spaziatura automatica, spaziatura manuale delle etichette con segni di tacca indipendenti e spaziatura automatica ripristinata. Le due copie mantengono i dati originali del grafico. Non è necessaria una presentazione di input. Il testo dell'etichetta orizzontale rende evidente la differenza di densità.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/TickMarkType.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartTextBlockFormat.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <system/object_ext.h>
#include <DOM/ISlideCollection.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

chart->set_HasLegend(false);
chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::ClusteredColumn);
for (auto i = 0; i < 24; i++)
{
    auto categoryName = System::String::Format(u"Category {0}", i + 1);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(categoryName));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);
    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(10 + i % 6 * 5));
    series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
}

auto axis = chart->get_Axes()->get_HorizontalAxis();
axis->set_CategoryAxisType(CategoryAxisType::Text);
axis->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(0);
axis->get_TextFormat()->get_PortionFormat()->set_FontHeight(12);
axis->set_MajorTickMark(TickMarkType::Outside);
axis->set_IsAutomaticTickLabelSpacing(true);
axis->set_IsAutomaticTickMarksSpacing(true);

// Slide 2: show every third label, but keep a tick mark for every category.
auto manualSlide = presentation->get_Slides()->AddClone(slide);
auto manualChart = System::ExplicitCast<IChart>(manualSlide->get_Shape(0));
auto manualAxis = manualChart->get_Axes()->get_HorizontalAxis();
manualAxis->set_IsAutomaticTickLabelSpacing(false);
manualAxis->set_TickLabelSpacing(3);
manualAxis->set_IsAutomaticTickMarksSpacing(false);
manualAxis->set_TickMarksSpacing(1);

// Slide 3: let the chart choose both intervals again.
auto restoredSlide = presentation->get_Slides()->AddClone(manualSlide);
auto restoredChart = System::ExplicitCast<IChart>(restoredSlide->get_Shape(0));
restoredChart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticTickLabelSpacing(true);
restoredChart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticTickMarksSpacing(true);

presentation->Save(u"CategoryAxisIntervals.pptx", SaveFormat::Pptx);
```

**Spaziatura automatica (diapositiva 1):** In questa resa, viene visualizzata ogni seconda etichetta di categoria e avvolta su due righe. Il risultato automatico può variare in base alla dimensione del grafico, ai caratteri e al renderer.

![Spaziatura automatica delle etichette di categoria con tutte le 24 colonne visibili](category-axis-automatic.png)

**Spaziatura manuale (diapositiva 2):** Viene visualizzata ogni terza etichetta su una sola riga, mentre i segni di tacca rimangono a ogni intervallo di categoria. Tutte le 24 colonne, incluse quelle senza etichette, rimangono visibili con gli stessi valori. La diapositiva 3 ripristina l'aspetto automatico mostrato sopra.

![Intervallo di etichette di categoria manuale di tre con tutte le 24 colonne visibili](category-axis-manual.png)

### **Scegli l'asse e l'intervallo corretti**

Usa questo intervallo conteggio-categoria per un asse di categoria testuale, come l'asse di categoria di un grafico a colonne, linee, aree o barre. In un grafico a colonne è l'asse orizzontale. In un grafico a barre orizzontali, l'asse di categoria è verticale, quindi applica queste impostazioni a [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/). La spaziatura dei segni di tacca si applica anche a un asse di serie nei grafici che ne hanno uno.

Non utilizzare la spaziatura delle etichette di categoria per impostare la scala numerica di un asse di valore. Su un asse di valore, [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majorunit/) specifica una differenza di valori: per esempio, un'unità principale di `10` produce tacche a 0, 10, 20, ecc. quando l'asse parte da zero. Un intervallo di etichetta di categoria di `3` conta invece le posizioni di categoria, indipendentemente dai valori dei dati. I grafici a dispersione e a bolle usano assi di valore invece di un asse di categoria testuale. Per un asse data, usa unità principali basate sul tempo e scale come descritto in [Change a Category Axis](#change-a-category-axis).

## **Imposta il formato data per i valori dell'asse di categoria**

L'esempio sostituisce i dati predefiniti del grafico con quattro valori annuali. Le date sono memorizzate come numeri seriali OLE Automation nel primo foglio di lavoro (indice `0`). Usa [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) per selezionare un asse data, disabilita la formattazione collegata alla fonte con [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isnumberformatlinkedtosource/), e assegna `yyyy` con [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_numberformat/) così le etichette di categoria mostrano l'anno a quattro cifre indipendentemente dalla formattazione della cella.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <system/object_ext.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 50, 50, 450, 300);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Line);
for (auto i = 0; i < 4; i++)
{
    auto date = System::DateTime(2015 + i, 1, 1);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(date.ToOADate()));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(i + 1));
    series->get_DataPoints()->AddDataPointForLineSeries(valueCell);
}

chart->get_Axes()->get_HorizontalAxis()->set_CategoryAxisType(CategoryAxisType::Date);
chart->get_Axes()->get_HorizontalAxis()->set_IsNumberFormatLinkedToSource(false);
chart->get_Axes()->get_HorizontalAxis()->set_NumberFormat(u"yyyy");

presentation->Save(u"DateAxisFormat.pptx", SaveFormat::Pptx);
```

## **Imposta un angolo di rotazione per il titolo dell'asse del grafico**

Abilita il titolo dell'asse verticale con [set_HasTitle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_hastitle/), fornisci il testo del titolo e usa [set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/icharttextblockformat/set_rotationangle/) per ruotare il titolo. L'angolo è misurato in gradi; questo esempio salva un grafico a colonne con il titolo dell'asse dei valori ruotato di 90 gradi.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartTextBlockFormat.h>
#include <DOM/Chart/IChartTitle.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
chart->get_Axes()->get_VerticalAxis()->set_HasTitle(true);
chart->get_Axes()->get_VerticalAxis()->get_Title()->AddTextFrameForOverriding(u"Value");
chart->get_Axes()->get_VerticalAxis()->get_Title()->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(90);

presentation->Save(u"RotatedAxisTitle.pptx", SaveFormat::Pptx);
```

## **Imposta la posizione dell'asse su un asse di categoria o valore**

Usa [set_AxisBetweenCategories](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_axisbetweencategories/) per controllare se l'asse di valore incrocia l'asse di categoria tra le categorie o sui segni di tacca della categoria. Questa proprietà si applica agli assi di categoria. L'esempio lo imposta su `true` sull'asse di categoria orizzontale di un grafico a colonne e salva il risultato.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
chart->get_Axes()->get_HorizontalAxis()->set_AxisBetweenCategories(true);

presentation->Save(u"AxisBetweenCategories.pptx", SaveFormat::Pptx);
```

## **Imposta l'unità di visualizzazione su un asse di valore del grafico**

Usa [set_DisplayUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_displayunit/) per scalare le etichette su un asse di valore senza modificare i dati sottostanti. Con [DisplayUnitType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/displayunittype/) impostato su `Millions`, un valore di 60 000 000 viene visualizzato come 60. L'esempio crea un grafico a colonne e applica l'unità di visualizzazione milioni al suo asse verticale.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/DisplayUnitType.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Millions);

presentation->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **Configura un asse di valore logaritmico**

Un asse di valore logaritmico è utile quando i valori positivi coprono diversi ordini di grandezza. Per esempio, un servizio potrebbe ricevere 10, 100, 1 000, 10 000 e 100 000 richieste in cinque periodi. Su una scala lineare, i valori più piccoli appaiono vicini tra loro vicino allo zero. Una scala logaritmica rende più facile confrontare la loro crescita relativa: distanze uguali rappresentano rapporti uguali anziché differenze uguali.

Chiama [set_IsLogarithmic](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_islogarithmic/) con `true` sull'asse di valore e usa [set_LogBase](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_logbase/) per scegliere la base. Questo modifica il modo in cui i valori esistenti sono visualizzati; non cambia i dati né aggiunge una linea di tendenza logaritmica. Una linea di tendenza rappresenta una relazione di adattamento nei dati ed è una funzionalità separata.

### **Scegli l'asse di valore e la base**

Per un grafico a linee o a colonne, l'asse di valore è [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/). Per un grafico a barre orizzontali, è [get_HorizontalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_horizontalaxis/). I grafici a dispersione e a bolle hanno due assi di valore, quindi scegli l'asse orizzontale per i valori X, l'asse verticale per i valori Y, o entrambi. Non applicare la scala logaritmica a un asse di categoria.

La base logaritmica predefinita è `10`. Per i grafici PPTX, usa una base da `2` a `1000`, inclusive; sono supportate anche basi frazionarie come `2.5`. Con base `10`, le potenze successive come 10, 100, 1 000 e 10 000 sono equidistanti.

### **Confronta la scala lineare e quella logaritmica**

L'esempio autonomo seguente crea un grafico a linee con i cinque conteggi di richieste nella prima diapositiva, poi clona quella diapositiva e abilita un asse di valore logaritmico in base 10 nella seconda. Entrambe le diapositive mantengono gli stessi dati.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 30, 40, 660, 200);

chart->set_HasLegend(false);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Line);
auto values = std::array<double, 5>{10, 100, 1000, 10000, 100000};

for (auto i = 0; i < values.size(); i++)
{
    auto categoryName = System::String::Format(u"Period {0}", i + 1);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(categoryName));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(values[i]));
    series->get_DataPoints()->AddDataPointForLineSeries(valueCell);
}

// Keep the first slide linear and change only the copy's value-axis scale.
auto logarithmicSlide = presentation->get_Slides()->AddClone(slide);
auto logarithmicChart = System::ExplicitCast<IChart>(logarithmicSlide->get_Shape(0));
auto valueAxis = logarithmicChart->get_Axes()->get_VerticalAxis();
valueAxis->set_IsLogarithmic(true);
valueAxis->set_LogBase(10);

presentation->Save(u"LogarithmicAxis.pptx", SaveFormat::Pptx);
```

**Scala lineare (diapositiva 1):** Distanze verticali uguali rappresentano differenze uguali nei conteggi delle richieste. Il valore più grande domina il grafico, rendendo difficile distinguere i valori più piccoli.

![Grafico a linee in PowerPoint che mostra cinque conteggi di richieste su un asse di valore lineare](value-axis-linear.png)

**Scala logaritmica (diapositiva 2):** Distanze verticali uguali rappresentano rapporti uguali. Ogni periodo ha dieci volte più richieste del precedente, quindi i punti formano una linea crescente retta sulla scala in base 10. Le etichette dell'asse mostrano ancora i conteggi originali delle richieste.

![Gli stessi cinque conteggi di richieste in PowerPoint su un asse di valore logaritmico in base 10](value-axis-logarithmic.png)

### **Gestisci valori zero e negativi**

Una scala logaritmica può visualizzare solo valori strettamente positivi. Controlla i dati prima di abilitarla. Se i valori zero o negativi sono significativi, mantieni una scala lineare o mostrali separatamente. Se escludere tali valori è appropriato per l'analisi, spiega l'omissione. Non sostituirli silenziosamente con numeri piccoli positivi, poiché ciò cambia il significato dei dati. Qualsiasi valore minimo o massimo configurato manualmente per un asse logaritmico deve essere anch'esso positivo.

## **FAQ**

**Come impostare il valore al quale un asse incrocia l'altro (incrocio degli assi)?**

Usa [set_CrossType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/) per selezionare il comportamento di incrocio. Per specificare un valore numerico di incrocio, usa [set_CrossAt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crossat/). Queste impostazioni ti consentono di spostare l'incrocio dell'asse a una linea di base adeguata.

**Come posso posizionare le etichette delle tacche rispetto all'asse?**

Usa [set_TickLabelPosition](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_ticklabelposition/) con un valore da [TickLabelPositionType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ticklabelpositiontype/): `Low`, `High`, `NextTo` o `None`. Per controllare le tacche stesse, usa [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majortickmark/) o [set_MinorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_minortickmark/); questi sono separati dal posizionamento delle etichette.