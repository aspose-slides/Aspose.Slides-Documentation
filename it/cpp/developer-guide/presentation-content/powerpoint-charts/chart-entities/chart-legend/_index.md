---
title: Personalizza le legende dei grafici nelle presentazioni usando C++
linktitle: Legenda del grafico
type: docs
url: /it/cpp/chart-legend/
keywords:
- legenda del grafico
- posizione della legenda
- dimensione del carattere
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Personalizza le legende dei grafici con Aspose.Slides per C++ per ottimizzare le presentazioni PowerPoint con formattazione della legenda su misura."
---
## **Panoramica**

Aspose.Slides for C++ fornisce opzioni per personalizzare le legende dei grafici nelle presentazioni PowerPoint. Questo articolo mostra come posizionare e dimensionare una legenda, impostare la dimensione del carattere per l'intera legenda, formattare una voce della legenda individuale e nascondere o ripristinare le voci selezionate.

Le FAQ coprono comportamenti correlati, inclusa la riservazione di spazio per la legenda, la visualizzazione di etichette multilinea e l'ereditarietà della formattazione dal tema della presentazione.

## **Posizionamento della Legenda**

Utilizza i metodi [set_X](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_x/), [set_Y](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_y/), [set_Width](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_width/) e [set_Height](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_height/) della legenda per specificare la sua posizione e dimensione come frazioni delle dimensioni del grafico.

Questo esempio crea una presentazione e aggiunge un grafico a colonne raggruppate con dati predefiniti alla prima diapositiva. Dividendo gli offset e le dimensioni desiderate della legenda per la larghezza e l'altezza del grafico, si ottengono valori relativi: la legenda è spostata di 50 punti dal vertice superiore sinistro del grafico e ha dimensioni di 100 per 100 punti.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 500, 500);

// Esprimi la posizione e le dimensioni della legenda rispetto al grafico.
chart->get_Legend()->set_X(50 / chart->get_Width());
chart->get_Legend()->set_Y(50 / chart->get_Height());
chart->get_Legend()->set_Width(100 / chart->get_Width());
chart->get_Legend()->set_Height(100 / chart->get_Height());

presentation->Save(u"legend_position.pptx", SaveFormat::Pptx);
```

## **Imposta la Dimensione del Carattere di una Legenda**

Utilizza [get_TextFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/get_textformat/) della legenda per accedere alla formattazione del testo e usa [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) per impostare la dimensione del carattere in punti.

Questo esempio crea un grafico con dati predefiniti e imposta il testo della legenda a 20 punti. Disabilita inoltre i limiti automatici per l'asse verticale e imposta il suo intervallo da -5 a 10.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

chart->get_Legend()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20);
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMinValue(false);
chart->get_Axes()->get_VerticalAxis()->set_MinValue(-5);
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMaxValue(false);
chart->get_Axes()->get_VerticalAxis()->set_MaxValue(10);

presentation->Save(u"legend_font_size.pptx", SaveFormat::Pptx);
```

## **Imposta la Dimensione del Carattere di una Voce della Legenda Individuale**

Utilizza la collezione restituita dal metodo [get_Entries](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/get_entries/) della legenda per accedere alla formattazione di una voce specifica. Gli indici delle voci sono basati su zero, quindi l'indice `1` si riferisce alla seconda voce.

Questo esempio crea un grafico a colonne raggruppate i cui dati predefiniti includono almeno due serie. Formatta la seconda voce della legenda con testo grassetto, corsivo e blu da 20 punti.

```cpp
#include <system/shared_ptr.h>
#include <drawing/color.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/ILegendEntryCollection.h>
#include <DOM/Chart/ILegendEntryProperties.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/NullableBool.h>
#include <DOM/IFillFormat.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
auto textFormat = chart->get_Legend()->get_Entries()->idx_get(1)->get_TextFormat();

textFormat->get_PortionFormat()->set_FontBold(NullableBool::True);
textFormat->get_PortionFormat()->set_FontHeight(20);
textFormat->get_PortionFormat()->set_FontItalic(NullableBool::True);
textFormat->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
textFormat->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());

presentation->Save(u"legend_entry_format.pptx", SaveFormat::Pptx);
```

## **Nascondi Voci della Legenda Individuali**

Per escludere una serie ausiliaria dalla legenda mantenendo i suoi dati visibili, chiama [ILegendEntryProperties::set_Hide](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ilegendentryproperties/set_hide/) con `true` tramite [IChartSeries::get_RelatedLegendEntry](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_relatedlegendentry/). Questo nasconde solo la voce della legenda selezionata; non rimuove la serie o i suoi punti dati. Chiamare [IChart::set_HasLegend](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_haslegend/) con `false`, al contrario, nasconde l'intera legenda.

L'esempio seguente crea un grafico a colonne raggruppate con più serie usando dati predefiniti. Nasconde la voce della legenda della seconda serie (indice `1`) e salva la presentazione. Successivamente ripristina la voce chiamando `set_Hide` con `false` e salva una seconda copia. Le colonne rimangono visibili in entrambi i file.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/ILegendEntryProperties.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
chart->set_HasLegend(true);

auto legendEntry = chart->get_ChartData()->get_Series()->idx_get(1)->get_RelatedLegendEntry();

legendEntry->set_Hide(true);
presentation->Save(u"hidden_legend_entry.pptx", SaveFormat::Pptx);

// Ripristina la stessa voce senza cambiare i dati del grafico.
legendEntry->set_Hide(false);
presentation->Save(u"restored_legend_entry.pptx", SaveFormat::Pptx);
```

Il confronto sotto mostra lo stesso grafico con tutte le voci visibili e con la seconda voce nascosta. Le colonne della seconda serie rimangono inalterate.

![Confronto di un grafico con tutte le voci della legenda visibili e con la Serie 2 nascosta dalla legenda; tutte le colonne rimangono visibili.](hide-legend-entry.png)

Nei grafici a colonne, barre e linee, le voci della legenda identificano le serie. Nei grafici a torta, identificano i punti dati individuali (fette), quindi utilizza [IChartDataPoint::get_RelatedLegendEntry](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_relatedlegendentry/) sulla fetta selezionata. L'API documenta questo metodo per punti dati per i tipi di grafico `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` e `BarOfPie`. Non presumere che si applichi ai grafici a ciambella, che non sono inclusi in quell'elenco.

## **FAQ**

**Posso fare in modo che il grafico riservi spazio per la legenda invece di sovrapporla?**

Sì. Chiama [set_Overlay](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_overlay/) con `false` per riservare spazio per la legenda invece di permettere che si sovrapponga all'area del grafico.

**Posso creare etichette della legenda multilinea?**

Sì. Le etichette lunghe possono andare a capo quando la larghezza disponibile è insufficiente. Puoi anche usare caratteri di nuova riga nei nomi delle serie per richiedere interruzioni di riga.

**Come posso fare in modo che la legenda segua lo schema di colori del tema della presentazione?**

Lascia le colore, i riempimenti e i caratteri della legenda non impostati in modo che possano ereditare la formattazione del tema. La formattazione esplicita sovrascrive le impostazioni corrispondenti del tema.