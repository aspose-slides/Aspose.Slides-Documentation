---
title: Personalizza le tabelle dei dati dei grafici nelle presentazioni usando C++
linktitle: Tabella dati
type: docs
url: /it/cpp/chart-data-table/
keywords:
- dati del grafico
- tabella dei dati
- proprietà del carattere
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Personalizza i caratteri, i bordi e le chiavi della legenda delle tabelle dei dati dei grafici nelle presentazioni PowerPoint usando Aspose.Slides per C++."
---
## **Panoramica**

Aspose.Slides per C++ consente di visualizzare la tabella dei dati di un grafico e di personalizzare la formattazione del testo, i bordi e le chiavi della legenda. Questo articolo spiega come abilitare la tabella, formattare il suo testo, controllare ciascun tipo di bordo e mostrare o nascondere le chiavi della legenda. Gli esempi salvano i grafici configurati nei file PPTX.

## **Imposta le proprietà del carattere**

Per visualizzare la tabella dei dati di un grafico, passa `true` a [IChart::set_HasDataTable](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichart/set_hasdatatable/). Usa [IChart::get_ChartDataTable](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichart/get_chartdatatable/) per accedere alla tabella e configurarne la formattazione del testo.

1. Carica la presentazione usando la classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
1. Aggiungi un grafico a colonne raggruppate alla prima diapositiva.
1. Abilita la tabella dei dati del grafico.
1. Abilita il testo in grassetto con [IBasePortionFormat::set_FontBold](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibaseportionformat/set_fontbold/) e passa `20` a [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibaseportionformat/set_fontheight/) per un testo da 20 punti.
1. Salva la presentazione modificata.

L'esempio seguente richiede `test.pptx` nella directory di lavoro con almeno una diapositiva. Aggiunge un grafico con dati predefiniti nella posizione (50, 50), con una larghezza di 600 punti e un’altezza di 400 punti. Il file `output.pptx` salvato contiene il grafico con la tabella dei dati abilitata e le impostazioni del carattere specificate applicate.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"test.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);

auto portionFormat = chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat();
portionFormat->set_FontBold(NullableBool::True);
portionFormat->set_FontHeight(20.0f);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Personalizza i bordi della tabella dei dati**

Abilita la tabella con [IChart::set_HasDataTable](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichart/set_hasdatatable/) e accedila tramite [IChart::get_ChartDataTable](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichart/get_chartdatatable/). È possibile controllare tre tipi di bordi in modo indipendente:

- [IDataTable::set_HasBorderHorizontal](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/idatatable/set_hasborderhorizontal/) controlla i bordi orizzontali delle celle.
- [IDataTable::set_HasBorderVertical](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/idatatable/set_hasbordervertical/) controlla i bordi verticali delle celle.
- [IDataTable::set_HasBorderOutline](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/idatatable/set_hasborderoutline/) controlla il bordo esterno della tabella.

Passa `true` a ciascun setter per visualizzare i bordi o `false` per nasconderli. L'esempio seguente crea un grafico a colonne raggruppate con dati predefiniti, visualizza i bordi orizzontali e il bordo esterno e nasconde i bordi verticali. Non richiede alcun file di input. La posizione e le dimensioni del grafico sono specificate in punti.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);

auto dataTable = chart->get_ChartDataTable();
dataTable->set_HasBorderHorizontal(true);
dataTable->set_HasBorderVertical(false);
dataTable->set_HasBorderOutline(true);

presentation->Save(u"data-table-borders.pptx", SaveFormat::Pptx);
```

Il confronto qui sotto utilizza gli stessi dati del grafico e le stesse impostazioni della chiave della legenda in tutti e quattro i casi. Partendo da tutti i bordi abilitati, ogni variante rimuove solo un tipo di bordo. La variante in basso a sinistra corrisponde alle impostazioni dei bordi dell'esempio.

![Tabelle dei dati del grafico con tutti i bordi abilitati, senza bordi orizzontali, senza bordi verticali e senza bordo esterno](data-table-borders.png)

## **Mostra o nascondi le chiavi della legenda**

Le chiavi della legenda sono piccoli marcatori colorati accanto ai nomi delle serie nella tabella dei dati. Aiutano i lettori a associare ogni riga della tabella a una serie del grafico. Passa `true` a [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/idatatable/set_showlegendkey/) per mostrare questi marcatori o `false` per nasconderli.

La legenda separata del grafico è controllata da [IChart::set_HasLegend](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichart/set_haslegend/). Queste impostazioni sono indipendenti: nascondere la legenda separata non nasconde le chiavi nella tabella dei dati, e nascondere le chiavi della tabella non nasconde la legenda separata.

L'esempio seguente crea un grafico con dati predefiniti, abilita la sua tabella dei dati e mostra le chiavi della legenda al suo interno nascondendo la legenda separata. Tutti i bordi della tabella sono esplicitamente abilitati. Non è necessaria alcuna presentazione di input. Per nascondere solo le chiavi della tabella, passa `false` a [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/idatatable/set_showlegendkey/).

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);
chart->set_HasLegend(false);

auto dataTable = chart->get_ChartDataTable();
dataTable->set_HasBorderHorizontal(true);
dataTable->set_HasBorderVertical(true);
dataTable->set_HasBorderOutline(true);
dataTable->set_ShowLegendKey(true);

presentation->Save(u"data-table-legend-keys.pptx", SaveFormat::Pptx);
```

Il confronto qui sotto mostra la stessa tabella con le chiavi della legenda abilitate e disabilitate. Tutti i bordi rimangono abilitati e la legenda separata del grafico è nascosta in entrambi i casi.

![Tabelle dei dati del grafico con chiavi della legenda mostrate a sinistra e nascoste a destra](data-table-legend-keys.png)

## **FAQ**

**Posso mostrare le chiavi della legenda nella tabella dei dati di un grafico?**

Sì. Passa `true` a [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/idatatable/set_showlegendkey/) per visualizzare le chiavi della legenda o `false` per nasconderle.

**La tabella dei dati verrà mantenuta quando si esporta la presentazione in PDF, HTML o immagini?**

Sì. Aspose.Slides rende il grafico e la sua tabella dei dati visualizzata come parte della diapositiva durante l'esportazione in [PDF](/slides/it/cpp/convert-powerpoint-to-pdf/), [HTML](/slides/it/cpp/convert-powerpoint-to-html/) o [immagini](/slides/it/cpp/convert-powerpoint-to-png/).

**Posso lavorare con le tabelle dei dati nei grafici caricati da un modello?**

Sì. Per un grafico caricato da una presentazione o modello esistente, usa [IChart::get_HasDataTable](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichart/get_hasdatatable/) per verificare se la sua tabella dei dati è visualizzata e [IChart::set_HasDataTable](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichart/set_hasdatatable/) per modificarne la visibilità.

**Come posso trovare i grafici che hanno la tabella dei dati abilitata?**

Itera attraverso le forme di ogni diapositiva, identifica i grafici e controlla il risultato di [IChart::get_HasDataTable](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichart/get_hasdatatable/). Un valore `true` indica che la tabella dei dati è abilitata.