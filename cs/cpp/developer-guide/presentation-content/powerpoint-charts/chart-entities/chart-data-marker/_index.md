---
title: Správa ukazatelů dat grafu v prezentacích pomocí C++
linktitle: Ukazatel dat
type: docs
url: /cs/cpp/chart-data-marker/
keywords:
- graf
- datový bod
- ukazatel
- možnosti ukazatelů
- velikost ukazatele
- typ výplně
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Zjistěte, jak přizpůsobit ukazatele dat grafu v Aspose.Slides pro C++, zvýšit dopad prezentací v formátech PPT a PPTX pomocí přehledných příkladů kódu v C++."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s ukazateli dat v grafech v Aspose.Slides. Ukazuje, jak vytvořit graf, získat přístup k sérii a jejím datovým bodům, použít výplně obrázkem na ukazatele na úrovni datového bodu, upravit velikost ukazatele a uložit aktualizovanou prezentaci. Také uvádí, že standardní tvary ukazatelů jsou k dispozici prostřednictvím výčtu `MarkerStyleType` a že vzhled ukazatele je zachován při exportu grafů do rastrových formátů nebo SVG.

## **Nastavení ukazatelů grafu**
Aspose.Slides pro C++ poskytuje jednoduché rozhraní API pro automatické nastavení ukazatele řady grafu. V následující funkci získá každá řada grafu automaticky jiný výchozí symbol ukazatele.

Níže uvedený příklad kódu ukazuje, jak automaticky nastavit ukazatel řady grafu.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-DefaultMarkersInChart-DefaultMarkersInChart.cpp" >}}

## **Nastavení možností ukazatelů grafu**
Ukazatele lze nastavit na datových bodech grafu v konkrétní řadě. Pro nastavení možností ukazatelů grafu postupujte podle níže uvedených kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) .
- Vytvoření výchozího grafu.
- Nastavte obrázek.
- Získejte první řadu grafu.
- Přidejte nový datový bod.
- Uložte prezentaci na disk.

V níže uvedeném příkladu jsme nastavili možnosti ukazatelů grafu na úrovni datových bodů.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetMarkerOptions-SetMarkerOptions.cpp" >}}

## **Nastavení ukazatelů grafu na úrovni datových bodů řady**
Nyní lze ukazatele nastavit na datových bodech grafu v konkrétní řadě. Pro nastavení možností ukazatelů grafu postupujte podle níže uvedených kroků:

- Vytvořte instanci třídy Presentation.
- Vytvoření výchozího grafu.
- Nastavte obrázek.
- Získejte první řadu grafu.
- Přidejte nový datový bod.
- Uložte prezentaci na disk.

V níže uvedeném příkladu jsme nastavili možnosti ukazatelů grafu na úrovni datových bodů.

```cpp
const String outPath = u"../out/SetMarkerOptionsonSeries_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";
const String ImagePath2 = u"../templates/aspose - logo.jpg";

//Vytvořte instanci třídy Presentation, která představuje soubor PPTX
SharedPtr<Presentation> pres = MakeObject<Presentation>();

//Přístup k prvnímu snímku
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Přidání grafu s výchozími daty
SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::LineWithMarkers, 0, 0, 500, 500);

// Nastavení indexu listu s daty grafu
int defaultWorksheetIndex = 0;

// Získání listu s daty grafu
SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

// Odstranění výchozích generovaných řad a kategorií
chart->get_ChartData()->get_Series()->Clear();

// Nyní přidání nové řady
SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());

// Získání obrázku
SharedPtr<IImage> image = Images::FromFile(ImagePath);
SharedPtr<IImage> image2 = Images::FromFile(ImagePath2);

// Přidání obrázku do kolekce obrázků prezentace
SharedPtr<IPPImage> imgx1 = pres->get_Images()->AddImage(image);
SharedPtr<IPPImage> imgx2 = pres->get_Images()->AddImage(image2);

image->Dispose();
image2->Dispose();

// Přidání nového bodu (1:3) zde.
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

//Changing the chart series marker
series->get_Marker()->set_Size(15);

// Write the presentation file to disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
pres->Dispose();
```

## **Použití barvy na datové body**
Můžete použít barvu na datové body v grafu pomocí Aspose.Slides pro C++. Byly přidány třídy [**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/) a **[IChartDataPointLevel](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatapointlevel/)**, které umožňují přístup k vlastnostem úrovní datových bodů. Tento článek ukazuje, jak získat přístup a použít barvu na datové body v grafu.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddColorToDataPoints-AddColorToDataPoints.cpp" >}}

## **Často kladené otázky**

**Jaké tvary ukazatelů jsou k dispozici ihned?**

K dispozici jsou standardní tvary (kroužek, čtverec, diamant, trojúhelník atd.); seznam je definován výčtem [MarkerStyleType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/markerstyletype/). Pokud potřebujete nestandardní tvar, použijte ukazatel s výplní obrázkem, abyste napodobili vlastní vizuály.

**Zůstávají ukazatele zachovány při exportu grafu do obrázku nebo SVG?**

Ano. Při vykreslování grafů do [rasterových formátů](/slides/cs/cpp/convert-powerpoint-to-png/) nebo ukládání [tvarů jako SVG](/slides/cs/cpp/render-a-slide-as-an-svg-image/) si ukazatele zachovávají svůj vzhled a nastavení, včetně velikosti, výplně a obrysu.