---
title: Zarządzaj zoomem prezentacji w C++
linktitle: Zarządzaj zoomem
type: docs
weight: 60
url: /pl/cpp/manage-zoom/
keywords:
- zoom
- ramka zoom
- zoom slajdu
- zoom sekcji
- zoom podsumowania
- dodaj zoom
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Twórz i dostosowuj Zoom za pomocą Aspose.Slides dla C++ — przeskakuj między sekcjami, dodawaj miniatury i przejścia w prezentacjach PPT, PPTX i ODP."
---
## **Wprowadzenie**

Zoomy w programie PowerPoint pozwalają przeskakiwać do i z określonych slajdów, sekcji oraz fragmentów prezentacji. Podczas prezentacji ta możliwość szybkiej nawigacji po zawartości może okazać się bardzo przydatna. 

![overview_image](Overview.png)

* Aby podsumować całą prezentację na jednym slajdzie, użyj [Summary Zoom](#Summary-Zoom).
* Aby wyświetlić tylko wybrane slajdy, użyj [Slide Zoom](#Slide-Zoom).
* Aby wyświetlić tylko jedną sekcję, użyj [Section Zoom](#Section-Zoom).

## **Zoom slajdu**
Zoom slajdu może uczynić Twoją prezentację bardziej dynamiczną, umożliwiając swobodne poruszanie się pomiędzy slajdami w dowolnej kolejności bez przerywania przepływu prezentacji. Zoomy slajdów są świetne dla krótkich prezentacji bez wielu sekcji, ale można je również stosować w różnych scenariuszach prezentacji.

Zoomy slajdów pomagają zagłębiać się w wiele informacji, jednocześnie dając wrażenie pracy na jednym płótnie. 

![overview_image](slidezoomsel.png)

Dla obiektów zoom slajdu, Aspose.Slides udostępnia wyliczenie [ZoomImageType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/zoomimagetype/), interfejs [IZoomFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/izoomframe/) oraz niektóre metody w interfejsie [IShapeCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishapecollection/).

### **Utworzenie ramek Zoom**
Możesz dodać ramkę zoom na slajdzie w ten sposób:

1.	Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
2.	Utwórz nowe slajdy, do których zamierzasz podlinkować ramki zoom.
3.	Dodaj tekst identyfikacyjny i tło do utworzonych slajdów.
4.	Dodaj ramki zoom (zawierające odwołania do utworzonych slajdów) do pierwszego slajdu.
5.	Zapisz zmodyfikowaną prezentację jako plik PPTX.

``` cpp 
void SetSlideBackground(SharedPtr<ISlide> slide, Color color)
{
    slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
    slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(color);
    slide->get_Background()->set_Type(BackgroundType::OwnBackground);
}
```

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Dodaje nowe slajdy do prezentacji
auto slide2 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

// Tworzy tło dla drugiego slajdu
SetSlideBackground(slide2, Color::get_Cyan());

// Tworzy pole tekstowe dla drugiego slajdu
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// Tworzy tło dla trzeciego slajdu
SetSlideBackground(slide3, Color::get_DarkKhaki());

// Tworzy pole tekstowe dla trzeciego slajdu
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Trird Slide");

//Dodaje obiekty ZoomFrame
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
slide0->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// Zapisuje prezentację
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Utworzenie ramek Zoom z własnymi obrazami**
Z Aspose.Slides for C++ możesz utworzyć ramkę zoom z innym obrazem podglądu slajdu w następujący sposób: 
1.	Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
2.	Utwórz nowy slajd, do którego zamierzasz podlinkować ramkę zoom. 
3.	Dodaj tekst identyfikacyjny i tło do slajdu.
4.	Utwórz obiekt [IPPImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ippimage/) poprzez dodanie obrazu do kolekcji Images powiązanej z obiektem [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/), który będzie użyty do wypełnienia ramki.
5.	Dodaj ramki zoom (zawierające odwołanie do utworzonego slajdu) do pierwszego slajdu.
6.	Zapisz zmodyfikowaną prezentację jako plik PPTX.

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Dodaje nowy slajd do prezentacji
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

// Tworzy tło dla drugiego slajdu
SetSlideBackground(slide, Color::get_Cyan());

// Tworzy pole tekstowe dla trzeciego slajdu
auto autoshape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// Tworzy nowy obraz dla obiektu zoom
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

//Dodaje obiekt ZoomFrame
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, slide, image);

// Zapisuje prezentację
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Formatuj ramki Zoom**
W poprzednich sekcjach pokazaliśmy, jak utworzyć proste ramki zoom. Aby stworzyć bardziej skomplikowane ramki zoom, musisz zmienić formatowanie prostej ramki. Istnieje kilka opcji formatowania, które możesz zastosować do ramki zoom. 

Możesz kontrolować formatowanie ramki zoom na slajdzie w następujący sposób:

1.	Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
2.	Utwórz nowe slajdy, które chcesz podlinkować ramką zoom. 
3.	Dodaj trochę tekstu identyfikacyjnego i tło do utworzonych slajdów.
4.	Dodaj ramki zoom (zawierające odwołania do utworzonych slajdów) do pierwszego slajdu.
5.	Utwórz obiekt [IPPImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ippimage/) poprzez dodanie obrazu do kolekcji Images powiązanej z obiektem [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/), który będzie użyty do wypełnienia ramki.
6.	Ustaw własny obraz dla pierwszego obiektu ramki zoom.
7.	Zmień format linii dla drugiego obiektu ramki zoom.
8.	Usuń tło z obrazu drugiego obiektu ramki zoom.
9.	Zapisz zmodyfikowaną prezentację jako plik PPTX.

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide1 = pres->get_Slides()->idx_get(0);
//Dodaje nowe slajdy do prezentacji
auto slide2 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());

// Tworzy tło dla drugiego slajdu
SetSlideBackground(slide2, Color::get_Cyan());

// Tworzy pole tekstowe dla drugiego slajdu
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// Tworzy tło dla trzeciego slajdu
SetSlideBackground(slide3, Color::get_DarkKhaki());

// Tworzy pole tekstowe dla trzeciego slajdu
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Trird Slide");

//Dodaje obiekty ZoomFrame
auto zoomFrame1 = slide1->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
auto zoomFrame2 = slide1->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// Tworzy nowy obraz dla obiektu zoom
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
// Ustawia własny obraz dla obiektu zoomFrame1 object
zoomFrame1->set_Image(image);

// Ustawia format ramki zoom dla obiektu zoomFrame2 object
zoomFrame2->get_LineFormat()->set_Width(5);
zoomFrame2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
zoomFrame2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_HotPink());
zoomFrame2->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);

// Ustawienie: nie pokazuj tła dla obiektu zoomFrame2 object
zoomFrame2->set_ShowBackground(false);

// Zapisuje prezentację
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

## **Zoom sekcji**

Zoom sekcji to odnośnik do sekcji w Twojej prezentacji. Możesz używać zoomów sekcji, aby wracać do sekcji, które chcesz szczególnie podkreślić. Albo możesz używać ich, aby uwypuklić, jak poszczególne części prezentacji są ze sobą powiązane. 

![overview_image](seczoomsel.png)

Dla obiektów zoom sekcji, Aspose.Slides udostępnia interfejs [ISectionZoomFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isectionzoomframe/) oraz niektóre metody w interfejsie [IShapeCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishapecollection/).

### **Utworzenie ramek Zoom sekcji**

Możesz dodać ramkę zoom sekcji do slajdu w ten sposób:

1.	Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
2.	Utwórz nowy slajd. 
3.	Dodaj tło identyfikacyjne do utworzonego slajdu.
4.	Utwórz nową sekcję, do której zamierzasz podlinkować ramkę zoom. 
5.	Dodaj ramkę zoom sekcji (zawierającą odwołania do utworzonej sekcji) do pierwszego slajdu.
6.	Zapisz zmodyfikowaną prezentację jako plik PPTX.

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Dodaje nowy slajd do prezentacji
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Dodaje nową sekcję do prezentacji
pres->get_Sections()->AddSection(u"Section 1", slide);

// Dodaje obiekt SectionZoomFrame
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// Zapisuje prezentację
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```
### **Utworzenie ramek Zoom sekcji z własnymi obrazami**

Używając Aspose.Slides for C++, możesz utworzyć ramkę zoom sekcji z innym obrazem podglądu slajdu w następujący sposób: 

1.	Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
2.	Utwórz nowy slajd.
3.	Dodaj tło identyfikacyjne do utworzonego slajdu.
4.	Utwórz nową sekcję, do której zamierzasz podlinkować ramkę zoom. 
5.	Utwórz obiekt [IPPImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ippimage/) poprzez dodanie obrazu do kolekcji Images powiązanej z obiektem [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/), który będzie użyty do wypełnienia ramki.
6.	Dodaj ramkę zoom sekcji (zawierającą odwołanie do utworzonej sekcji) do pierwszego slajdu.
7.	Zapisz zmodyfikowaną prezentację jako plik PPTX.

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Dodaje nowy slajd do prezentacji
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Dodaje nową sekcję do prezentacji
pres->get_Sections()->AddSection(u"Section 1", slide);

// Tworzy nowy obraz dla obiektu zoom
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

// Dodaje obiekt SectionZoomFrame
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1), image);

// Zapisuje prezentację
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Formatuj ramki Zoom sekcji**

Aby stworzyć bardziej skomplikowane ramki zoom sekcji, musisz zmienić formatowanie prostej ramki. Istnieje kilka opcji formatowania, które możesz zastosować do ramki zoom sekcji. 

Możesz kontrolować formatowanie ramki zoom sekcji na slajdzie w następujący sposób:

1.	Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
2.	Utwórz nowy slajd.
3.	Dodaj tło identyfikacyjne do utworzonego slajdu.
4.	Utwórz nową sekcję, do której zamierzasz podlinkować ramkę zoom. 
5.	Dodaj ramkę zoom sekcji (zawierającą odwołania do utworzonej sekcji) do pierwszego slajdu.
6.	Zmień rozmiar i pozycję utworzonego obiektu zoom sekcji.
7.	Utwórz obiekt [IPPImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ippimage/) poprzez dodanie obrazu do kolekcji Images powiązanej z obiektem [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/), który będzie użyty do wypełnienia ramki.
8.	Ustaw własny obraz dla utworzonego obiektu ramki zoom sekcji.
9.	Ustaw możliwość *powrotu do pierwotnego slajdu z powiązanej sekcji*.
10.	Usuń tło z obrazu obiektu ramki zoom sekcji.
11.	Zmień format linii dla drugiego obiektu ramki zoom.
12.	Zmień czas trwania przejścia.
13.	Zapisz zmodyfikowaną prezentację jako plik PPTX.

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Dodaje nowy slajd do prezentacji
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Dodaje nową sekcję do prezentacji
pres->get_Sections()->AddSection(u"Section 1", slide);

// Dodaje obiekt SectionZoomFrame
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// Formatowanie dla SectionZoomFrame
sectionZoomFrame->set_X(100.0f);
sectionZoomFrame->set_Y(300.0f);
sectionZoomFrame->set_Width(100.0f);
sectionZoomFrame->set_Height(75.0f);

auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
sectionZoomFrame->set_Image(image);

sectionZoomFrame->set_ReturnToParent(true);
sectionZoomFrame->set_ShowBackground(false);

auto sectionZoomLineFormat = sectionZoomFrame->get_LineFormat();
sectionZoomLineFormat->get_FillFormat()->set_FillType(FillType::Solid);
sectionZoomLineFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Brown());
sectionZoomLineFormat->set_DashStyle(LineDashStyle::DashDot);
sectionZoomLineFormat->set_Width(2.5f);

sectionZoomFrame->set_TransitionDuration(1.5f);

// Zapisuje prezentację
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


## **Zoom podsumowania**

Zoom podsumowania jest jak strona docelowa, na której wszystkie elementy Twojej prezentacji są wyświetlane jednocześnie. Podczas prezentacji możesz używać zoomu, aby przechodzić z jednego miejsca w prezentacji do innego w dowolnej kolejności. Możesz być kreatywny, przeskakiwać do przodu lub wracać do fragmentów pokazu slajdów, nie przerywając płynności prezentacji.

![overview_image](sumzoomsel.png)

Dla obiektów zoom podsumowania, Aspose.Slides udostępnia interfejsy [ISummaryZoomFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isummaryzoomframe/), [ISummaryZoomSection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isummaryzoomsection/) oraz [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isummaryzoomsectioncollection/), oraz niektóre metody w interfejsie [IShapeCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishapecollection/).

### **Utworzenie zoomu podsumowania**

Możesz dodać ramkę zoom podsumowania do slajdu w ten sposób:

1.	Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
2.	Utwórz nowe slajdy z tłem identyfikacyjnym oraz nowe sekcje dla utworzonych slajdów.
3.	Dodaj ramkę zoom podsumowania do pierwszego slajdu.
4.	Zapisz zmodyfikowaną prezentację jako plik PPTX.

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

// Dodaje nowy slajd do prezentacji
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Dodaje nową sekcję do prezentacji
pres->get_Sections()->AddSection(u"Section 1", slide);

// Dodaje nowy slajd do prezentacji
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Dodaje nową sekcję do prezentacji
pres->get_Sections()->AddSection(u"Section 2", slide);

// Dodaje nowy slajd do prezentacji
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// Dodaje nową sekcję do prezentacji
pres->get_Sections()->AddSection(u"Section 3", slide);

// Dodaje nowy slajd do prezentacji
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_DarkGreen());

// Dodaje nową sekcję do prezentacji
pres->get_Sections()->AddSection(u"Section 4", slide);

// Dodaje obiekt SummaryZoomFrame
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// Zapisuje prezentację
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Dodaj i usuń sekcję zoom podsumowania**

Wszystkie sekcje w ramce zoom podsumowania są reprezentowane przez obiekty [ISummaryZoomSection], które są przechowywane w obiekcie [ISummaryZoomSectionCollection]. Możesz dodać lub usunąć obiekt sekcji zoom podsumowania poprzez interfejs [ISummaryZoomSectionCollection] w następujący sposób:

1.	Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
2.	Utwórz nowe slajdy z taniem identyfikacyjnym oraz nowe sekcje dla utworzonych slajdów.
3.	Dodaj ramkę zoom podsumowania do pierwszego slajdu.
4.	Dodaj nowy slajd i sekcję do prezentacji.
5.	Dodaj utworzoną sekcję do ramki zoom podsumowania.
6.	Usuń pierwszą sekcję z ramki zoom podsumowania.
7.	Zapisz zmodyfikowaną prezentację jako plik PPTX.

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Dodaje nowy slajd do prezentacji
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Dodaje nową sekcję do prezentacji
pres->get_Sections()->AddSection(u"Section 1", slide);

//Dodaje nowy slajd do prezentacji
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Dodaje nową sekcję do prezentacji
pres->get_Sections()->AddSection(u"Section 2", slide);

// Dodaje obiekt SummaryZoomFrame
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

//Dodaje nowy slajd do prezentacji
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// Dodaje nową sekcję do prezentacji
auto section3 = pres->get_Sections()->AddSection(u"Section 3", slide);

// Dodaje sekcję do Summary Zoom
summaryZoomFrame->get_SummaryZoomCollection()->AddSummaryZoomSection(section3);

// Usuwa sekcję z Summary Zoom
summaryZoomFrame->get_SummaryZoomCollection()->RemoveSummaryZoomSection(pres->get_Sections()->idx_get(1));

// Zapisuje prezentację
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Formatuj sekcje zoom podsumowania**

Możesz kontrolować formatowanie obiektu sekcji zoom podsumowania w ramce zoom podsumowania w następujący sposób:

1.	Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
2.	Utwórz nowe slajdy z tłem identyfikacyjnym oraz nowe sekcje dla utworzonych slajdów.
3.	Dodaj ramkę zoom podsumowania do pierwszego slajdu.
4.	Pobierz obiekt sekcji zoom podsumowania dla pierwszego obiektu z `ISummaryZoomSectionCollection`.
5.	Utwórz obiekt [IPPImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ippimage/) poprzez dodanie obrazu do kolekcji images powiązanej z obiektem [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/), który będzie użyty do wypełnienia ramki.
6.	Ustaw własny obraz dla utworzonego obiektu ramki zoom sekcji.
7.	Ustaw możliwość *powrotu do pierwotnego slajdu z powiązanej sekcji*.
8.	Zmień format linii dla drugiego obiektu ramki zoom.
9.	Zmień czas trwania przejścia.
10.	Zapisz zmodyfikowaną prezentację jako plik PPTX.

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Dodaje nowy slajd do prezentacji
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Dodaje nową sekcję do prezentacji
pres->get_Sections()->AddSection(u"Section 1", slide);

//Dodaje nowy slajd do prezentacji
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Dodaje nową sekcję do prezentacji
pres->get_Sections()->AddSection(u"Section 2", slide);

// Dodaje obiekt SummaryZoomFrame
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// Pobiera pierwszy obiekt SummaryZoomSection
auto summarySection = summaryZoomFrame->get_SummaryZoomCollection()->idx_get(0);

// Formatowanie obiektu SummaryZoomSection
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
summarySection->set_Image(image);

summarySection->set_ReturnToParent(false);

summarySection->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
summarySection->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
summarySection->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);
summarySection->get_LineFormat()->set_Width(1.5f);

summarySection->set_TransitionDuration(1.5f);

// Zapisuje prezentację
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Czy mogę kontrolować powrót do slajdu 'nadrzędnego' po wyświetleniu celu?**

Tak. [Zoom frame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/zoomframe/) lub [section](https://reference.aspose.com/slides/pl/cpp/aspose.slides/sectionzoomframe/) posiada metodę `set_ReturnToParent`, która odsyła widzów z powrotem do slajdu źródłowego po odwiedzeniu docelowej zawartości.

**Czy mogę dostosować 'prędkość' lub czas trwania przejścia Zoom?**

Tak. Zoom umożliwia ustawienie czasu trwania przejścia, dzięki czemu możesz kontrolować, jak długo trwa animacja przeskoku.

**Czy istnieją ograniczenia co do liczby obiektów Zoom, które może zawierać prezentacja?**

Nie ma udokumentowanego sztywnego limitu API. Praktyczne ograniczenia zależą od całkowitej złożoności prezentacji i wydajności podglądu. Możesz dodać wiele ramek Zoom, ale weź pod uwagę rozmiar pliku i czas renderowania.