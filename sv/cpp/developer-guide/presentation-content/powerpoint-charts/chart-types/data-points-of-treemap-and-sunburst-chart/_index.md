---
title: Anpassa datapunkter i Treemap- och Sunburst-diagram med С++
linktitle: Datapunkter i Treemap- och Sunburst-diagram
type: docs
url: /sv/cpp/data-points-of-treemap-and-sunburst-chart/
keywords:
- treemap-diagram
- sunburst-diagram
- datapunkt
- etikettfärg
- grenfärg
- PowerPoint
- presentation
- С++
- Aspose.Slides
description: "Lär dig hur du hanterar datapunkter i treemap- och sunburst-diagram med Aspose.Slides för С++, kompatibel med PowerPoint-format."
---
## **Introduktion**

Förutom andra typer av PowerPoint-diagram finns det två ”hierarkiska” typer – **Treemap** och **Sunburst**‑diagram (även känt som Sunburst‑graf, Sunburst‑diagram, radiellt diagram, radiell graf eller flernivå‑cirkeldiagram). Dessa diagram visar hierarkiska data organiserade som ett träd – från löv till grenens topp. Löv definieras av seriedatapunkterna, och varje efterföljande inbäddad gruppering definieras av motsvarande kategori. Aspose.Slides för C++ möjliggör formatering av datapunkter i Sunburst‑diagram och Treemap i C++.

Här är ett Sunburst‑diagram, där data i kolumnen Series1 definierar löv‑noderna, medan andra kolumner definierar hierarkiska datapunkter:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Låt oss börja med att lägga till ett nytt Sunburst‑diagram i presentationen:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Sunburst, 100.0f, 100.0f, 450.0f, 400.0f);
// ...
```

{{% alert color="primary" title="Se även" %}} 
- [**Skapa Sunburst‑diagram**](/slides/sv/cpp/create-chart/#create-sunburst-chart)
{{% /alert %}}

Om det finns ett behov av att formatera diagrammets datapunkter bör vi använda följande:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/), [**IChartDataPointLevel**](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartdatapointlevel/) classes and [**IChartDataPoint::get_DataPointLevels()**](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) method ger åtkomst till att formatera datapunkter i Treemap‑ och Sunburst‑diagram.

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/) används för att komma åt flernivåkategorier – den representerar behållaren för [**IChartDataPointLevel**](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartdatapointlevel/)‑objekt.

I princip är det ett omslag för [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartcategorylevelsmanager/) med egenskaper som är specifika för datapunkter.

[**IChartDataPointLevel**](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartdatapointlevel/)‑klassen har två metoder: [**get_Format()**](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartdatapointlevel/get_format/) och [**get_Label()**](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartdatapointlevel/get_label/) som ger åtkomst till motsvarande inställningar.

## **Visa ett datapunktvärde**

Visa värdet för datapunkten "Leaf 4":

``` cpp
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();
dataPoints->idx_get(3)->get_DataPointLevels()->idx_get(0)->get_Label()->get_DataLabelFormat()->set_ShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Ställ in en datapunktetikett och färg**

Ställ in datapunktetiketten för "Branch 1" så att den visar serienamnet ("Series1") istället för kategorinamnet. Ställ sedan in textfärgen till gul:

``` cpp
auto branch1Label = dataPoints->idx_get(0)->get_DataPointLevels()->idx_get(2)->get_Label();
branch1Label->get_DataLabelFormat()->set_ShowCategoryName(false);
branch1Label->get_DataLabelFormat()->set_ShowSeriesName(true);

branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Ställ in grenfärgen för datapunkten**

Ändra färgen på grenen "Stem 4":

``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Sunburst, 100.0f, 100.0f, 450.0f, 400.0f);
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();

auto stem4branch = dataPoints->idx_get(9)->get_DataPointLevels()->idx_get(1);
stem4branch->get_Format()->get_Fill()->set_FillType(FillType::Solid);
stem4branch->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **FAQ**

**Kan jag ändra ordningen (sorteringen) av segment i Sunburst/Treemap?**

Nej. PowerPoint sorterar segment automatiskt (vanligtvis efter fallande värden, medurs). Aspose.Slides speglar detta beteende: du kan inte ändra ordningen direkt; du måste göra det genom att förbehandla data.

**Hur påverkar presentationens tema färgerna på segment och etiketter?**

Diagrammets färger ärver presentationens [tema/palett](/slides/sv/cpp/presentation-theme/) om du inte explicit ställer in fyllningar/teckensnitt. För konsekventa resultat, lås fast solida fyllningar och textformatering på de nödvändiga nivåerna.

**Kommer export till PDF/PNG att bevara anpassade grenfärger och etikettsinställningar?**

Ja. Vid export av presentationen bevaras diagraminställningarna (fyllningar, etiketter) i de exporterade formaten eftersom Aspose.Slides renderar med diagrammets formatering applicerad.

**Kan jag beräkna de faktiska koordinaterna för en etikett/element för att placera en anpassad överläggning ovanpå diagrammet?**

Ja. Efter att diagramlayouten har validerats finns faktiska X- och Y-koordinater tillgängliga för element (till exempel en [DataLabel](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/datalabel/)), vilket underlättar exakt placering av överlägg.