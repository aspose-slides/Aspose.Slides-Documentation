---
title: Gestire i marcatori dei dati del grafico nelle presentazioni usando C++
linktitle: Marcatore Dati
type: docs
url: /it/cpp/chart-data-marker/
keywords:
- grafico
- punto dati
- marcatore
- opzioni del marcatore
- dimensione del marcatore
- tipo di riempimento
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Scopri come personalizzare i marcatori dei dati del grafico in Aspose.Slides per C++, aumentando l'impatto delle presentazioni nei formati PPT e PPTX con chiari esempi di codice C++."
---
## **Panoramica**

Questo articolo spiega come lavorare con i marcatori dei dati nei grafici in Aspose.Slides. Mostra come creare un grafico, accedere a una serie e ai suoi punti dati, applicare riempimenti immagine ai marcatori a livello di punto dati, regolare la dimensione del marcatore e salvare la presentazione aggiornata. Nota inoltre che le forme standard dei marcatori sono disponibili tramite l'enumerazione `MarkerStyleType` e che l'aspetto del marcatore viene conservato quando si esportano i grafici in formati raster o SVG.

## **Imposta i Marcatori del Grafico**
Aspose.Slides per C++ offre un'API semplice per impostare automaticamente il marcatore della serie del grafico. Nella funzionalità seguente, ogni serie del grafico otterrà automaticamente un simbolo di marcatore predefinito diverso.

L'esempio di codice sottostante mostra come impostare automaticamente il marcatore della serie del grafico.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-DefaultMarkersInChart-DefaultMarkersInChart.cpp" >}}

## **Imposta le Opzioni del Marcatore del Grafico**
I marcatori possono essere impostati sui punti dati del grafico all'interno di una serie specifica. Per impostare le opzioni del marcatore del grafico, segui i passaggi seguenti:

- Istanziare la classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) .
- Creare il grafico predefinito.
- Impostare l'immagine.
- Prendere la prima serie del grafico.
- Aggiungere un nuovo punto dati.
- Scrivere la presentazione su disco.

Nell'esempio mostrato di seguito, abbiamo impostato le opzioni del marcatore del grafico a livello dei punti dati.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetMarkerOptions-SetMarkerOptions.cpp" >}}

## **Imposta i Marcatori del Grafico a Livello del Punto Dati della Serie**
Ora, i marcatori possono essere impostati sui punti dati del grafico all'interno di una serie specifica. Per impostare le opzioni del marcatore del grafico, segui i passaggi seguenti:

- Istanziare la classe Presentation .
- Creare il grafico predefinito.
- Impostare l'immagine.
- Prendere la prima serie del grafico.
- Aggiungere un nuovo punto dati.
- Scrivere la presentazione su disco.

Nell'esempio mostrato di seguito, abbiamo impostato le opzioni del marcatore del grafico a livello dei punti dati.

```cpp
const String outPath = u"../out/SetMarkerOptionsonSeries_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";
const String ImagePath2 = u"../templates/aspose - logo.jpg";

//Istanziare la classe Presentation che rappresenta un file PPTX
SharedPtr<Presentation> pres = MakeObject<Presentation>();

//Accedere alla prima diapositiva
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Aggiungere un grafico con dati predefiniti
SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::LineWithMarkers, 0, 0, 500, 500);

// Impostare l'indice del foglio dati del grafico
int defaultWorksheetIndex = 0;

// Ottenere il foglio dati del grafico
SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

// Eliminare le serie e le categorie generate di default
chart->get_ChartData()->get_Series()->Clear();

// Ora, aggiungere una nuova serie
SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());

// Ottenere l'immagine
SharedPtr<IImage> image = Images::FromFile(ImagePath);
SharedPtr<IImage> image2 = Images::FromFile(ImagePath2);

// Aggiungere l'immagine alla collezione di immagini della presentazione
SharedPtr<IPPImage> imgx1 = pres->get_Images()->AddImage(image);
SharedPtr<IPPImage> imgx2 = pres->get_Images()->AddImage(image2);

image->Dispose();
image2->Dispose();

// Aggiungere un nuovo punto (1:3) lì.
SharedPtr<IChartDataPoint> point = series->get_DataPoints()->AddDataPointForLineSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(4.5)));
point->get_Marker()->get_Format()->get_Fill()->set_FillType(FillType::Picture);
point->get_Marker()->get_Format()->get_Fill()->get_PictureFillFormat()->get_Picture()->set_Image(imgx1);

point = series->get_DataPoints()->AddDataPointForLineSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(2.5)));
point->get_Marker()->get_Format()->get_Fill()->set_FillType(FillType::Picture);
point->get_Marker()->get_Format()->get_Fill()->get_PictureFillFormat()->get_Picture()->set_Image(imgx2);

point = series->get_DataPoints()->AddDataPointForLineSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(3.5)));
point->get_Marker()->get_Format()->get_Fill()->set_FillType(FillType::Picture);
point->get_Marker()->get_Format()->get_Fill()->get_PictureFillFormat()->get_Picture()->set_Image(imgx1);

point = series->get_DataPoints()->AddDataPointForLineSeries(fact->GetCell(defaultWorksheetIndex, 4, 1, ObjectExt::Box<double>(4.5)));
point->get_Marker()->get_Format()->get_Fill()->set_FillType(FillType::Picture);
point->get_Marker()->get_Format()->get_Fill()->get_PictureFillFormat()->get_Picture()->set_Image(imgx2);

// Changing the chart series marker
series->get_Marker()->set_Size(15);

// Write the presentation file to disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
pres->Dispose();
```

## **Applica un Colore ai Punti Dati**
Puoi applicare un colore ai punti dati nel grafico usando Aspose.Slides per C++. Le classi [**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/) e **[IChartDataPointLevel](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichartdatapointlevel/)** sono state aggiunte per accedere alle proprietà dei livelli dei punti dati. Questo articolo dimostra come accedere e applicare un colore ai punti dati in un grafico.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddColorToDataPoints-AddColorToDataPoints.cpp" >}}

## **FAQ**

**Quali forme di marcatore sono disponibili subito?**

Sono disponibili forme standard (cerchio, quadrato, diamante, triangolo, ecc.); l'elenco è definito dall'enumerazione [MarkerStyleType](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/markerstyletype/). Se ti serve una forma non standard, usa un marcatore con riempimento immagine per simulare elementi personalizzati.

**I marcatori vengono conservati quando si esporta un grafico in un'immagine o SVG?**

Sì. Quando si rendono i grafici in [formati raster](/slides/it/cpp/convert-powerpoint-to-png/) o si salvano [forme come SVG](/slides/it/cpp/render-a-slide-as-an-svg-image/), i marcatori mantengono il loro aspetto e le impostazioni, inclusi dimensione, riempimento e contorno.