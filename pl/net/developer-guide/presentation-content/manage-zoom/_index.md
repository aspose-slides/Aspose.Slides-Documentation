---
title: Zarządzanie powiększeniem prezentacji w .NET
linktitle: Zarządzaj powiększeniem
type: docs
weight: 60
url: /pl/net/manage-zoom/
keywords:
- powiększenie
- ramka powiększenia
- powiększenie slajdu
- powiększenie sekcji
- powiększenie podsumowujące
- dodaj powiększenie
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Twórz i dostosowuj Powiększenia przy użyciu Aspose.Slides dla .NET — przeskakuj między sekcjami, dodawaj miniatury i przejścia w prezentacjach PPT, PPTX i ODP."
---
## **Introduction**

Zoomy w programie PowerPoint umożliwiają przeskakiwanie do i z określonych slajdów, sekcji oraz fragmentów prezentacji. Podczas prezentacji ta możliwość szybkiej nawigacji po treści może okazać się bardzo przydatna. 

![overview_image](overview.png)

* Aby podsumować całą prezentację na jednym slajdzie, użyj [Summary Zoom](#Summary-Zoom).
* Aby wyświetlić tylko wybrane slajdy, użyj [Slide Zoom](#Slide-Zoom).
* Aby wyświetlić tylko jedną sekcję, użyj [Section Zoom](#Section-Zoom).

## **Slide Zoom**
Zoom slajdu może uczynić Twoją prezentację bardziej dynamiczną, umożliwiając swobodne przemieszczanie się pomiędzy slajdami w dowolnej kolejności bez przerywania przepływu prezentacji. Zoomy slajdów są świetne dla krótkich prezentacji bez wielu sekcji, ale możesz ich używać również w różnych scenariuszach prezentacji.

Zoomy slajdów pomagają zagłębić się w wiele fragmentów informacji, jednocześnie dając wrażenie pracy na jednej płaszczyźnie. 

![overview_image](slidezoomsel.png)

Dla obiektów zoomu slajdu Aspose.Slides udostępnia wyliczenie [ZoomImageType](https://reference.aspose.com/slides/pl/net/aspose.slides/zoomimagetype), interfejs [IZoomFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/izoomframe) oraz niektóre metody w interfejsie [IShapeCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapecollection).

### **Create Zoom Frames**

Możesz dodać ramkę zoomu na slajdzie w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
2. Utwórz nowe slajdy, do których zamierzasz podlinkować ramki zoomu. 
3. Dodaj tekst identyfikacyjny i tło do utworzonych slajdów.
4. Dodaj ramki zoomu (zawierające odwołania do utworzonych slajdów) do pierwszego slajdu.
5. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod C# pokazuje, jak utworzyć ramkę zoomu na slajdzie:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Dodaje nowe slajdy do prezentacji
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // Tworzy tło dla drugiego slajdu
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // Tworzy pole tekstowe dla drugiego slajdu
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // Tworzy tło dla trzeciego slajdu
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // Tworzy pole tekstowe dla trzeciego slajdu
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    //Dodaje obiekty ZoomFrame
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // Zapisuje prezentację
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **Create Zoom Frames with Custom Images**
Korzystając z Aspose.Slides for .NET, możesz utworzyć ramkę zoomu z innym obrazem podglądu slajdu w następujący sposób: 
1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
2. Utwórz nowy slajd, do którego zamierzasz podlinkować ramkę zoomu. 
3. Dodaj tekst identyfikacyjny i tło do slajdu.
4. Utwórz obiekt [IPPImage](https://reference.aspose.com/slides/pl/net/aspose.slides/ippimage) poprzez dodanie obrazu do kolekcji Images powiązanej z obiektem [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation), który będzie użyty do wypełnienia ramki.
5. Dodaj ramki zoomu (zawierające odwołanie do utworzonego slajdu) do pierwszego slajdu.
6. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod C# pokazuje, jak utworzyć ramkę zoomu z innym obrazem:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Dodaje nowy slajd do prezentacji
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // Tworzy tło dla drugiego slajdu
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // Tworzy pole tekstowe dla trzeciego slajdu
    IAutoShape autoshape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // Tworzy nowy obraz dla obiektu zoom
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    //Dodaje obiekt ZoomFrame
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 300, 200, slide, ppImage);

    // Zapisuje prezentację
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **Format Zoom Frames**
W poprzednich sekcjach pokazaliśmy, jak utworzyć proste ramki zoomu. Aby utworzyć bardziej złożone ramki zoomu, musisz zmienić formatowanie prostej ramki. Istnieje kilka opcji formatowania, które możesz zastosować do ramki zoomu. 

Możesz kontrolować formatowanie ramki zoomu na slajdzie w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
2. Utwórz nowe slajdy, do których zamierzasz podlinkować ramkę zoomu. 
3. Dodaj jakiś tekst identyfikacyjny i tło do utworzonych slajdów.
4. Dodaj ramki zoomu (zawierające odwołania do utworzonych slajdów) do pierwszego slajdu.
5. Utwórz obiekt [IPPImage](https://reference.aspose.com/slides/pl/net/aspose.slides/ippimage) poprzez dodanie obrazu do kolekcji Images powiązanej z obiektem [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation), który będzie użyty do wypełnienia ramki.
6. Ustaw własny obraz dla pierwszego obiektu ramki zoomu.
7. Zmień format linii dla drugiego obiektu ramki zoomu.
8. Usuń tło z obrazu drugiego obiektu ramki zoomu.
5. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod C# pokazuje, jak zmienić formatowanie ramki zoomu na slajdzie: 

``` csharp 
using (Presentation pres = new Presentation())
{
    //Dodaje nowe slajdy do prezentacji
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // Tworzy tło dla drugiego slajdu
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // Tworzy pole tekstowe dla drugiego slajdu
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // Tworzy tło dla trzeciego slajdu
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // Tworzy pole tekstowe dla trzeciego slajdu
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    //Dodaje obiekty ZoomFrame
    IZoomFrame zoomFrame1 = pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // Tworzy nowy obraz dla obiektu zoom
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Ustawia własny obraz dla obiektu zoomFrame1
    zoomFrame1.ZoomImage = ppImage;

    // Ustawia format ramki zoom dla obiektu zoomFrame2
    zoomFrame2.LineFormat.Width = 5;
    zoomFrame2.LineFormat.FillFormat.FillType = FillType.Solid;
    zoomFrame2.LineFormat.FillFormat.SolidFillColor.Color = Color.HotPink;
    zoomFrame2.LineFormat.DashStyle = LineDashStyle.DashDot;

    // Ustawienie: nie wyświetlaj tła dla obiektu zoomFrame2
    zoomFrame2.ShowBackground = false;

    // Zapisuje prezentację
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

## **Section Zoom**

Zoom sekcji to odnośnik do sekcji w Twojej prezentacji. Możesz używać zoomów sekcji, aby wracać do sekcji, które chcesz szczególnie podkreślić. Możesz też używać ich do zaznaczenia, jak poszczególne elementy Twojej prezentacji są ze sobą powiązane. 

![overview_image](seczoomsel.png)

Dla obiektów zoomu sekcji Aspose.Slides udostępnia interfejs [ISectionZoomFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/isectionzoomframe) oraz niektóre metody w interfejsie [IShapeCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapecollection).

### **Create Section Zoom Frames**

Możesz dodać ramkę zoomu sekcji do slajdu w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
2. Utwórz nowy slajd. 
3. Dodaj tło identyfikacyjne do utworzonego slajdu.
4. Utwórz nową sekcję, do której zamierzasz podlinkować ramkę zoomu. 
5. Dodaj ramkę zoomu sekcji (zawierającą odwołania do utworzonej sekcji) do pierwszego slajdu.
6. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod C# pokazuje, jak utworzyć ramkę zoomu na slajdzie:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Dodaje nowy slajd do prezentacji
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Dodaje nową sekcję do prezentacji
    pres.Sections.AddSection("Section 1", slide);

    // Dodaje obiekt SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // Zapisuje prezentację
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **Create Section Zoom Frames with Custom Images**

Korzystając z Aspose.Slides for .NET, możesz utworzyć ramkę zoomu sekcji z innym obrazem podglądu slajdu w następujący sposób: 

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
2. Utwórz nowy slajd.
3. Dodaj tło identyfikacyjne do utworzonego slajdu.
4. Utwórz nową sekcję, do której zamierzasz podlinkować ramkę zoomu. 
5. Utwórz obiekt [IPPImage](https://reference.aspose.com/slides/pl/net/aspose.slides/ippimage) poprzez dodanie obrazu do kolekcji Images powiązanej z obiektem [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation), który będzie użyty do wypełnienia ramki.
5. Dodaj ramkę zoomu sekcji (zawierającą odwołanie do utworzonej sekcji) do pierwszego slajdu.
6. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod C# pokazuje, jak utworzyć ramkę zoomu z innym obrazem:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Dodaje nowy slajd do prezentacji
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Dodaje nową sekcję do prezentacji
    pres.Sections.AddSection("Section 1", slide);

    // Tworzy nowy obraz dla obiektu zoom
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Dodaje obiekt SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1], ppImage);

    // Zapisuje prezentację
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **Format Section Zoom Frames**

Aby utworzyć bardziej złożone ramki zoomu sekcji, musisz zmienić formatowanie prostej ramki. Istnieje kilka opcji formatowania, które możesz zastosować do ramki zoomu sekcji. 

Możesz kontrolować formatowanie ramki zoomu sekcji na slajdzie w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
2. Utwórz nowy slajd.
3. Dodaj tło identyfikacyjne do utworzonego slajdu.
4. Utwórz nową sekcję, do której zamierzasz podlinkować ramkę zoomu. 
5. Dodaj ramkę zoomu sekcji (zawierającą odwołania do utworzonej sekcji) do pierwszego slajdu.
6. Zmień rozmiar i położenie utworzonego obiektu zoomu sekcji.
7. Utwórz obiekt [IPPImage](https://reference.aspose.com/slides/pl/net/aspose.slides/ippimage) poprzez dodanie obrazu do kolekcji Images powiązanej z obiektem [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation), który będzie użyty do wypełnienia ramki.
8. Ustaw własny obraz dla utworzonego obiektu ramki zoomu sekcji.
9. Ustaw możliwość *powrotu do oryginalnego slajdu z powiązanej sekcji*. 
10. Usuń tło z obrazu obiektu ramki zoomu sekcji.
11. Zmień format linii dla drugiego obiektu ramki zoomu.
12. Zmień czas trwania przejścia.
13. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod C# pokazuje, jak zmienić formatowanie ramki zoomu sekcji:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Dodaje nowy slajd do prezentacji
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Dodaje nową sekcję do prezentacji
    pres.Sections.AddSection("Section 1", slide);

    // Dodaje obiekt SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // Formatowanie dla SectionZoomFrame
    sectionZoomFrame.X = 100;
    sectionZoomFrame.Y = 300;
    sectionZoomFrame.Width = 100;
    sectionZoomFrame.Height = 75;

    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    sectionZoomFrame.ZoomImage = ppImage;

    sectionZoomFrame.ReturnToParent = true;
    sectionZoomFrame.ShowBackground = false;

    sectionZoomFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    sectionZoomFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Brown;
    sectionZoomFrame.LineFormat.DashStyle = LineDashStyle.DashDot;
    sectionZoomFrame.LineFormat.Width = 2.5f;

    sectionZoomFrame.TransitionDuration = 1.5f;

    // Zapisuje prezentację
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


## **Summary Zoom**

Zoom podsumowujący działa jak strona docelowa, na której jednocześnie wyświetlane są wszystkie elementy prezentacji. Podczas prezentacji możesz używać zoomu, aby przechodzić z jednego miejsca w prezentacji do innego w dowolnej kolejności. Możesz być kreatywny, przeskakiwać do przodu lub wracać do fragmentów pokazu bez przerywania jego płynności.

![overview_image](sumzoomsel.png)

Dla obiektów zoomu podsumowującego Aspose.Slides udostępnia interfejsy [ISummaryZoomFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/isummaryzoomframe), [ISummaryZoomFrameSection](https://reference.aspose.com/slides/pl/net/aspose.slides/isummaryzoomsection) oraz [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/isummaryzoomsectioncollection) oraz niektóre metody w interfejsie [IShapeCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapecollection).

### **Create a Summary Zoom**

Możesz dodać ramkę zoomu podsumowującego do slajdu w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
2. Utwórz nowe slajdy z tłem identyfikacyjnym i nowymi sekcjami dla utworzonych slajdów.
3. Dodaj ramkę zoomu podsumowującego do pierwszego slajdu.
4. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod C# pokazuje, jak utworzyć ramkę zoomu podsumowującego na slajdzie:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Dodaje nowy slajd do prezentacji
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Dodaje nową sekcję do prezentacji
    pres.Sections.AddSection("Section 1", slide);

    //Dodaje nowy slajd do prezentacji
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Dodaje nową sekcję do prezentacji
    pres.Sections.AddSection("Section 2", slide);

    //Dodaje nowy slajd do prezentacji
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Dodaje nową sekcję do prezentacji
    pres.Sections.AddSection("Section 3", slide);

    //Dodaje nowy slajd do prezentacji
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.DarkGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Dodaje nową sekcję do prezentacji
    pres.Sections.AddSection("Section 4", slide);

    // Dodaje obiekt SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // Zapisuje prezentację
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Add and Remove a Summary Zoom Section**

Wszystkie sekcje w ramce zoomu podsumowującego są reprezentowane przez obiekty [ISummaryZoomFrameSection](https://reference.aspose.com/slides/pl/net/aspose.slides/isummaryzoomsection), które są przechowywane w obiekcie [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/isummaryzoomsectioncollection). Możesz dodać lub usunąć obiekt sekcji zoomu podsumowującego za pośrednictwem interfejsu [ISummaryZoomSectionCollection] w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
2. Utwórz nowe slajdy z tłem identyfikacyjnym i nowymi sekcjami dla utworzonych slajdów.
3. Dodaj ramkę zoomu podsumowującego do pierwszego slajdu.
4. Dodaj nowy slajd i sekcję do prezentacji.
5. Dodaj utworzoną sekcję do ramki zoomu podsumowującego.
6. Usuń pierwszą sekcję z ramki zoomu podsumowującego.
7. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod C# pokazuje, jak dodać i usunąć sekcje w ramce zoomu podsumowującego:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Dodaje nowy slajd do prezentacji
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Dodaje nową sekcję do prezentacji
    pres.Sections.AddSection("Section 1", slide);

    //Dodaje nowy slajd do prezentacji
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Dodaje nową sekcję do prezentacji
    pres.Sections.AddSection("Section 2", slide);

    // Dodaje obiekt SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    //Dodaje nowy slajd do prezentacji
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Dodaje nową sekcję do prezentacji
    ISection section3 = pres.Sections.AddSection("Section 3", slide);

    // Dodaje sekcję do Summary Zoom
    summaryZoomFrame.SummaryZoomCollection.AddSummaryZoomSection(section3);

    // Usuwa sekcję z Summary Zoom
    summaryZoomFrame.SummaryZoomCollection.RemoveSummaryZoomSection(pres.Sections[1]);

    // Zapisuje prezentację
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Format Summary Zoom Sections**

Aby utworzyć bardziej złożone obiekty sekcji zoomu podsumowującego, musisz zmienić formatowanie prostej ramki. Istnieje kilka opcji formatowania, które możesz zastosować do obiektu sekcji zoomu podsumowującego. 

Możesz kontrolować formatowanie obiektu sekcji zoomu podsumowującego w ramce zoomu podsumowującego w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
2. Utwórz nowe slajdy z tłem identyfikacyjnym i nowymi sekcjami dla utworzonych slajdów.
3. Dodaj ramkę zoomu podsumowującego do pierwszego slajdu.
4. Pobierz obiekt sekcji zoomu podsumowującego dla pierwszego elementu z `ISummaryZoomSectionCollection`.
7. Utwórz obiekt [IPPImage](https://reference.aspose.com/slides/pl/net/aspose.slides/ippimage) poprzez dodanie obrazu do kolekcji images powiązanej z obiektem [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation), który będzie użyty do wypełnienia ramki.
8. Ustaw własny obraz dla utworzonego obiektu ramki zoomu sekcji.
9. Ustaw możliwość *powrotu do oryginalnego slajdu z powiązanej sekcji*. 
11. Zmień format linii dla drugiego obiektu ramki zoomu.
12. Zmień czas trwania przejścia.
13. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod C# pokazuje, jak zmienić formatowanie obiektu sekcji zoomu podsumowującego:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Dodaje nowy slajd do prezentacji
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Dodaje nową sekcję do prezentacji
    pres.Sections.AddSection("Section 1", slide);

    //Dodaje nowy slajd do prezentacji
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Dodaje nową sekcję do prezentacji
    pres.Sections.AddSection("Section 2", slide);

    // Dodaje obiekt SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // Pobiera pierwszy obiekt SummaryZoomSection
    ISummaryZoomSection summarySection = summaryZoomFrame.SummaryZoomCollection[0];

    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Formatowanie obiektu SummaryZoomSection
    summarySection.ZoomImage = ppImage;
    summarySection.ReturnToParent = false;

    summarySection.LineFormat.FillFormat.FillType = FillType.Solid;
    summarySection.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    summarySection.LineFormat.DashStyle = LineDashStyle.DashDot;
    summarySection.LineFormat.Width = 1.5f;

    summarySection.TransitionDuration = 1.5f;

    // Zapisuje prezentację
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Czy mogę kontrolować powrót do slajdu „rodzica” po wyświetleniu celu?**

Tak. [Zoom frame](https://reference.aspose.com/slides/pl/net/aspose.slides/zoomframe/) lub [section](https://reference.aspose.com/slides/pl/net/aspose.slides/sectionzoomframe/) posiada zachowanie `ReturnToParent`, które po włączeniu odsyła widzów z powrotem do slajdu pierwotnego po odwiedzeniu treści docelowej.

**Czy mogę dostosować „prędkość” lub czas trwania przejścia Zoom?**

Tak. Zoom obsługuje ustawienie `TransitionDuration`, dzięki czemu możesz kontrolować, jak długo trwa animacja przeskoku.

**Czy istnieją limity liczby obiektów Zoom, które może zawierać prezentacja?**

Nie ma udokumentowanego sztywnego limitu API. Praktyczne ograniczenia zależą od ogólnej złożoności prezentacji oraz wydajności odbiorcy. Można dodać wiele ramek Zoom, ale warto pamiętać o rozmiarze pliku i czasie renderowania.