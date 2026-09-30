---
title: Dostosowywanie legend wykresów w prezentacjach przy użyciu C++
linktitle: Legenda wykresu
type: docs
url: /pl/cpp/chart-legend/
keywords:
- legenda wykresu
- pozycja legendy
- rozmiar czcionki
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Dostosuj legendy wykresów za pomocą Aspose.Slides for C++, aby zoptymalizować prezentacje PowerPoint dzięki spersonalizowanemu formatowaniu legend."
---
## **Przegląd**

Aspose.Slides for C++ oferuje opcje dostosowywania legend wykresów w prezentacjach PowerPoint. Ten artykuł pokazuje, jak pozycjonować i zmieniać rozmiar legendy, ustawiać rozmiar czcionki dla całej legendy, formatować pojedynczy wpis legendy oraz ukrywać lub przywracać wybrane pozycje.

FAQ obejmuje powiązane zachowania, w tym rezerwowanie miejsca dla legendy, wyświetlanie etykiet wielowierszowych oraz dziedziczenie formatowania z motywu prezentacji.

## **Pozycjonowanie legendy**

Użyj metod legendy [set_X](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_x/), [set_Y](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_y/), [set_Width](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_width/), oraz [set_Height](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_height/), aby określić jej pozycję i rozmiar jako ułamki wymiarów wykresu.

Ten przykład tworzy prezentację i dodaje skumulowany wykres kolumnowy z danymi domyślnymi do pierwszego slajdu. Podzielenie żądanych przesunięć i wymiarów legendy przez szerokość i wysokość wykresu konwertuje je na wartości względne: legenda jest przesunięta o 50 punktów od lewego górnego rogu wykresu i ma rozmiar 100 × 100 punktów.

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

// Określ pozycję i rozmiar legendy względem wykresu.
chart->get_Legend()->set_X(50 / chart->get_Width());
chart->get_Legend()->set_Y(50 / chart->get_Height());
chart->get_Legend()->set_Width(100 / chart->get_Width());
chart->get_Legend()->set_Height(100 / chart->get_Height());

presentation->Save(u"legend_position.pptx", SaveFormat::Pptx);
```

## **Ustaw rozmiar czcionki legendy**

Użyj metody legendy [get_TextFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/get_textformat/) , aby uzyskać dostęp do formatowania tekstu, oraz [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) , aby ustawić rozmiar czcionki w punktach.

Ten przykład tworzy wykres z danymi domyślnymi i ustawia tekst legendy na 20 punktów. Ponadto wyłącza automatyczne granice osi pionowej i ustawia jej zakres od -5 do 10.

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

## **Ustaw rozmiar czcionki pojedynczego wpisu legendy**

Użyj kolekcji zwróconej przez metodę legendy [get_Entries](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/get_entries/) , aby uzyskać formatowanie konkretnego wpisu. Indeksy wpisów są zerowe, więc indeks `1` odnosi się do drugiego wpisu.

Ten przykład tworzy skumulowany wykres kolumnowy, którego dane domyślne zawierają co najmniej dwie serie. Formatuje drugi wpis legendy jako pogrubiony, kursywa i niebieski tekst o rozmiarze 20 punktów.

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

## **Ukryj pojedyncze wpisy legendy**

Aby wykluczyć pomocniczą serię z legendy, zachowując jednocześnie widoczne jej dane, wywołaj [ILegendEntryProperties::set_Hide](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ilegendentryproperties/set_hide/) z wartością `true` za pomocą [IChartSeries::get_RelatedLegendEntry](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_relatedlegendentry/). Ukryje to tylko wybrany wpis legendy; nie usuwa serii ani jej punktów danych. Natomiast wywołanie [IChart::set_HasLegend](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_haslegend/) z wartością `false` ukrywa całą legendę.

Poniższy przykład tworzy skumulowany wykres kolumnowy z wieloma seriami przy użyciu danych domyślnych. Ukrywa wpis legendy drugiej serii (indeks `1`) i zapisuje prezentację. Następnie przywraca wpis, wywołując `set_Hide` z wartością `false`, i zapisuje drugą kopię. Kolumny pozostają widoczne w obu plikach.

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

// Przywróć ten sam wpis bez zmiany danych wykresu.
legendEntry->set_Hide(false);
presentation->Save(u"restored_legend_entry.pptx", SaveFormat::Pptx);
```

Poniższe porównanie pokazuje ten sam wykres ze wszystkimi widocznymi wpisami legendy i z ukrytym drugim wpisem. Kolumny drugiej serii pozostają niezmienione.

![Porównanie wykresu ze wszystkimi widocznymi wpisami legendy i z ukrytym szeregiem 2 w legendzie; wszystkie kolumny pozostają widoczne.](hide-legend-entry.png)

W wykresach kolumnowych, słupkowych i liniowych wpisy legendy identyfikują serie. W wykresach kołowych identyfikują poszczególne punkty danych (kawałki), więc zamiast tego użyj [IChartDataPoint::get_RelatedLegendEntry](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_relatedlegendentry/) na wybranym kawałku. API dokumentuje tę metodę punktu danych dla typów wykresów `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` i `BarOfPie`. Nie zakładaj, że obowiązuje ona wykresy pierścieniowe, które nie są uwzględnione w tej liście.

## **FAQ**

**Czy mogę sprawić, aby wykres zarezerwował miejsce dla legendy zamiast nakładać ją?**

Tak. Wywołaj [set_Overlay](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_overlay/) z wartością `false`, aby zarezerwować miejsce dla legendy zamiast pozwalać jej nakładać się na obszar wykresu.

**Czy mogę tworzyć etykiety legendy wielowierszowe?**

Tak. Długie etykiety mogą się automatycznie zawijać, gdy dostępna szerokość jest niewystarczająca. Można również używać znaków nowej linii w nazwach serii, aby wymusić podziały linii.

**Jak sprawić, aby legenda stosowała schemat kolorów motywu prezentacji?**

Pozostaw kolory, wypełnienia i czcionki legendy nieustawione, aby mogła dziedziczyć formatowanie z motywu. Jawne formatowanie nadpisuje odpowiadające ustawienia motywu.