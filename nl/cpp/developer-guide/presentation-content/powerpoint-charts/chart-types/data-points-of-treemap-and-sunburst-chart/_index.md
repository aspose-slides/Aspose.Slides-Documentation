---
title: Gegevenspunten aanpassen in Treemap- en Sunburst-diagrammen met C++
linktitle: Gegevenspunten in Treemap- en Sunburst-diagrammen
type: docs
url: /nl/cpp/data-points-of-treemap-and-sunburst-chart/
keywords:
- treemap-diagram
- sunburst-diagram
- gegevenspunt
- labelkleur
- takkleur
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe u gegevenspunten beheert in treemap- en sunburst-diagrammen met Aspose.Slides voor C++, compatibel met PowerPoint-formaten."
---
## **Inleiding**

Naast andere typen PowerPoint‑diagrammen zijn er twee “hiërarchische” typen – **Treemap** en **Sunburst**‑diagram (ook bekend als Sunburst‑grafiek, Sunburst‑diagram, Radiale grafiek, Radiale diagram of Multi‑level taartdiagram). Deze diagrammen tonen hiërarchische gegevens die zijn georganiseerd als een boom – van bladeren tot de top van de tak. Bladeren worden gedefinieerd door de gegevenspunten van de serie, en elk volgend geneste groepeeringsniveau wordt gedefinieerd door de bijbehorende categorie. Aspose.Slides for C++ maakt het mogelijk om gegevenspunten van een Sunburst‑diagram en een Treemap in C++ te formatteren.

Hier is een Sunburst‑diagram, waarin de gegevens in de kolom Series1 de bladknopen definiëren, terwijl de andere kolommen hiërarchische gegevenspunten definiëren:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Laten we beginnen met het toevoegen van een nieuw Sunburst‑diagram aan de presentatie:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Sunburst, 100.0f, 100.0f, 450.0f, 400.0f);
// ...
```

{{% alert color="primary" title="Zie ook" %}} 
- [**Sunburst-diagram maken**](/slides/nl/cpp/create-chart/#create-sunburst-chart)
{{% /alert %}}

Als er een behoefte is om gegevenspunten van het diagram te formatteren, moeten we het volgende gebruiken:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/), 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatapointlevel/) klassen en [**IChartDataPoint::get_DataPointLevels()**](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) methode bieden toegang tot het formatteren van gegevenspunten van Treemap‑ en Sunburst‑diagrammen.  
[IChartDataPointLevelsManager](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/) wordt gebruikt om multi‑level categorieën te benaderen – het vertegenwoordigt de container van [IChartDataPointLevel](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatapointlevel/)‑objecten.  
In principe is het een wrapper voor [IChartCategoryLevelsManager](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartcategorylevelsmanager/) met eigenschappen die specifiek zijn voor gegevenspunten.  
De klasse [**IChartDataPointLevel**](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatapointlevel/) heeft twee methoden: [**get_Format()**](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatapointlevel/get_format/) en [**get_Label()**](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatapointlevel/get_label/) die toegang geven tot de respectieve instellingen.

## **Waarde van een datapunt tonen**
Toon de waarde van datapunt “Leaf 4”:

``` cpp
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();
dataPoints->idx_get(3)->get_DataPointLevels()->idx_get(0)->get_Label()->get_DataLabelFormat()->set_ShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Een datapuntlabel en -kleur instellen**
Stel het datalabel van “Branch 1” in zodat het de serienaam (“Series1”) toont in plaats van de categorienaam. Stel vervolgens de tekstkleur in op geel:

``` cpp
auto branch1Label = dataPoints->idx_get(0)->get_DataPointLevels()->idx_get(2)->get_Label();
branch1Label->get_DataLabelFormat()->set_ShowCategoryName(false);
branch1Label->get_DataLabelFormat()->set_ShowSeriesName(true);

branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Kleur van een datapunt‑tak instellen**
Wijzig de kleur van tak “Stem 4”:

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

## **Veelgestelde vragen**

**Kan ik de volgorde (sortering) van segmenten in Sunburst/Treemap wijzigen?**

Nee. PowerPoint sorteert segmenten automatisch (meestal op aflopende waarden, met de klok mee). Aspose.Slides spiegelt dit gedrag: je kunt de volgorde niet rechtstreeks wijzigen; je moet dit bereiken door de gegevens vooraf te verwerken.

**Hoe beïnvloedt het presentatiethema de kleuren van segmenten en labels?**

Diagramkleuren erven het [thema/palet](/slides/nl/cpp/presentation-theme/) van de presentatie, tenzij je expliciet vullingen/lettertypen instelt. Voor consistente resultaten, zet vaste vullingen en tekstopmaak vast op de benodigde niveaus.

**Zal exporteren naar PDF/PNG aangepaste takkleuren en labelinstellingen behouden?**

Ja. Bij het exporteren van de presentatie worden de diagraminstellingen (vullingen, labels) behouden in de uitvoerformaten, omdat Aspose.Slides rendert met de toegepaste diagramopmaak.

**Kan ik de werkelijke coördinaten van een label/element berekenen voor aangepaste overlay plaatsing bovenop het diagram?**

Ja. Nadat de diagramlay-out is gevalideerd, zijn de werkelijke X‑ en Y‑coördinaten beschikbaar voor elementen (bijvoorbeeld een [DataLabel](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/datalabel/)), wat helpt bij het nauwkeurig positioneren van overlays.