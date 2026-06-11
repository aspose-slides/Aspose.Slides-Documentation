---
title: Zarządzanie Zoomem prezentacji w Javie
linktitle: Zarządzaj Zoomem
type: docs
weight: 60
url: /pl/java/manage-zoom/
keywords:
- przybliżenie
- rama przybliżenia
- przybliżenie slajdu
- przybliżenie sekcji
- przybliżenie podsumowania
- dodaj przybliżenie
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Twórz i dostosowuj Zoom za pomocą Aspose.Slides dla Javy — przeskakuj między sekcjami, dodawaj miniatury i przejścia w prezentacjach PPT, PPTX i ODP."
---
## **Wprowadzenie**

Zoomy w PowerPoint umożliwiają przechodzenie do i z konkretnych slajdów, sekcji oraz fragmentów prezentacji. Podczas prezentacji ta możliwość szybkiej nawigacji po treści może okazać się bardzo przydatna. 

![overview_image](overview.png)

* Aby podsumować całą prezentację na jednym slajdzie, użyj [Podsumowania Zoom](#Summary-Zoom).
* Aby wyświetlić tylko wybrane slajdy, użyj [Zoom slajdu](#Slide-Zoom).
* Aby wyświetlić tylko jedną sekcję, użyj [Zoom sekcji](#Section-Zoom).

## **Zoom slajdu**
Zoom slajdu może uczynić twoją prezentację bardziej dynamiczną, pozwalając na swobodne przechodzenie między slajdami w dowolnej kolejności bez przerywania przepływu prezentacji. Zoomy slajdów są świetne dla krótkich prezentacji bez wielu sekcji, ale możesz je także wykorzystać w różnych scenariuszach prezentacji.

Zoomy slajdów pomagają zagłębić się w wiele informacji, jednocześnie dając wrażenie pracy na jednej płaszczyźnie. 

![overview_image](slidezoomsel.png)

Dla obiektów Zoom slajdu Aspose.Slides udostępnia wyliczenie [ZoomImageType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ZoomImageType), interfejs [IZoomFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IZoomFrame) oraz kilka metod w interfejsie [IShapeCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IShapeCollection).

### **Tworzenie ramek Zoom**

Możesz dodać ramkę zoom na slajdzie w następujący sposób:

1.	Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
2.	Utwórz nowe slajdy, do których zamierzasz połączyć ramki zoom.
3.	Dodaj tekst identyfikujący oraz tło do utworzonych slajdów.
4.	Dodaj ramki zoom (zawierające odwołania do utworzonych slajdów) do pierwszego slajdu.
5.	Zapisz zmodyfikowaną prezentację jako plik PPTX.

``` java
Presentation pres = new Presentation();
try {
    //Dodaje nowe slajdy do prezentacji
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Tworzy tło dla drugiego slajdu
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Tworzy pole tekstowe dla drugiego slajdu
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // Tworzy tło dla trzeciego slajdu
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // Tworzy pole tekstowe dla trzeciego slajdu
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //Dodaje obiekty ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // Zapisuje prezentację
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **Tworzenie ramek Zoom z własnymi obrazami**
Przy użyciu Aspose.Slides for Java możesz utworzyć ramkę zoom z innym podglądem slajdu w następujący sposób: 
1.	Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
2.	Utwórz nowy slajd, do którego zamierzasz połączyć ramkę zoom. 
3.	Dodaj tekst identyfikujący oraz tło do slajdu.
4.	Utwórz obiekt [IPPImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IPPImage) przez dodanie obrazu do kolekcji Images powiązanej z obiektem [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation), który zostanie użyty do wypełnienia ramki.
5.	Dodaj ramki zoom (zawierające odwołanie do utworzonego slajdu) do pierwszego slajdu.
6.	Zapisz zmodyfikowaną prezentację jako plik PPTX.

``` java
Presentation pres = new Presentation();
try {
    //Dodaje nowy slajd do prezentacji
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Tworzy tło dla drugiego slajdu
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Tworzy pole tekstowe dla trzeciego slajdu
    IAutoShape autoshape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // Tworzy nowy obraz dla obiektu zoom
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    //Dodaje obiekt ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);

    // Zapisuje prezentację
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **Formatowanie ramek Zoom**
W poprzednich sekcjach pokazaliśmy, jak utworzyć proste ramki zoom. Aby utworzyć bardziej złożone ramki zoom, należy zmienić formatowanie prostej ramki. Istnieje kilka opcji formatowania, które możesz zastosować do ramki zoom. 

Możesz kontrolować formatowanie ramki zoom na slajdzie w następujący sposób:

1.	Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
2.	Utwórz nowe slajdy, do których zamierzasz połączyć ramkę zoom. 
3.	Dodaj tekst identyfikujący oraz tło do utworzonych slajdów.
4.	Dodaj ramki zoom (zawierające odwołania do utworzonych slajdów) do pierwszego slajdu.
5.	Utwórz obiekt [IPPImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IPPImage) przez dodanie obrazu do kolekcji Images powiązanej z obiektem [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation), który zostanie użyty do wypełnienia ramki.
6.	Ustaw własny obraz dla pierwszego obiektu ramki zoom.
7.	Zmień format linii dla drugiego obiektu ramki zoom.
8.	Usuń tło z obrazu drugiego obiektu ramki zoom.
5.	Zapisz zmodyfikowaną prezentację jako plik PPTX.

``` java 
Presentation pres = new Presentation();
try {
    //Dodaje nowe slajdy do prezentacji
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Tworzy tło dla drugiego slajdu
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Tworzy pole tekstowe dla drugiego slajdu
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // Tworzy tło dla trzeciego slajdu
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // Tworzy pole tekstowe dla trzeciego slajdu
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //Dodaje obiekty ZoomFrame
    IZoomFrame zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // Tworzy nowy obraz dla obiektu zoom
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    // Ustawia własny obraz dla obiektu zoomFrame1
    zoomFrame1.setImage(picture);

    // Ustawia format ramki zoom dla obiektu zoomFrame2
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink);
    zoomFrame2.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    // Ustawienie nie wyświetla tła dla obiektu zoomFrame2
    zoomFrame2.setShowBackground(false);

    // Zapisuje prezentację
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zoom sekcji**

Zoom sekcji jest odnośnikiem do sekcji w twojej prezentacji. Możesz używać zoomów sekcji, aby wracać do sekcji, które chcesz szczególnie podkreślić. Albo możesz je wykorzystać, aby uwidocznić, jak poszczególne części twojej prezentacji są ze sobą powiązane. 

![overview_image](seczoomsel.png)

Dla obiektów Zoom sekcji Aspose.Slides udostępnia interfejs [ISectionZoomFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISectionZoomFrame) oraz kilka metod w interfejsie [IShapeCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IShapeCollection).

### **Tworzenie ramek Zoom sekcji**

Możesz dodać ramkę Zoom sekcji do slajdu w następujący sposób:

1.	Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
2.	Utwórz nowy slajd. 
3.	Dodaj tło identyfikacyjne do utworzonego slajdu.
4.	Utwórz nową sekcję, do której zamierzasz połączyć ramkę zoom. 
5.	Dodaj ramkę Zoom sekcji (zawierającą odwołania do utworzonej sekcji) do pierwszego slajdu.
6.	Zapisz zmodyfikowaną prezentację jako plik PPTX.

``` java
Presentation pres = new Presentation();
try {
    //Dodaje nowy slajd do prezentacji
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Dodaje nową sekcję do prezentacji
    pres.getSections().addSection("Section 1", slide);

    // Dodaje obiekt SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // Zapisuje prezentację
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **Tworzenie ramek Zoom sekcji z własnymi obrazami**

Używając Aspose.Slides for Java, możesz utworzyć ramkę Zoom sekcji z innym podglądem slajdu w następujący sposób: 

1.	Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
2.	Utwórz nowy slajd.
3.	Dodaj tło identyfikacyjne do utworzonego slajdu.
4.	Utwórz nową sekcję, do której zamierzasz połączyć ramkę zoom. 
5.	Utwórz obiekt [IPPImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IPPImage) przez dodanie obrazu do kolekcji Images powiązanej z obiektem [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation), który zostanie użyty do wypełnienia ramki.
5.	Dodaj ramkę Zoom sekcji (zawierającą odwołanie do utworzonej sekcji) do pierwszego slajdu.
6.	Zapisz zmodyfikowaną prezentację jako plik PPTX.

``` java 
Presentation pres = new Presentation();
try {
    //Dodaje nowy slajd do prezentacji
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Dodaje nową sekcję do prezentacji
    pres.getSections().addSection("Section 1", slide);

    // Tworzy nowy obraz dla obiektu zoom
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Dodaje obiekt SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);

    // Zapisuje prezentację
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **Formatowanie ramek Zoom sekcji**

Aby utworzyć bardziej złożone ramki Zoom sekcji, należy zmienić formatowanie prostej ramki. Istnieje kilka opcji formatowania, które możesz zastosować do ramki Zoom sekcji. 

Możesz kontrolować formatowanie ramki Zoom sekcji na slajdzie w następujący sposób:

1.	Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
2.	Utwórz nowy slajd.
3.	Dodaj tło identyfikacyjne do utworzonego slajdu.
4.	Utwórz nową sekcję, do której zamierzasz połączyć ramkę zoom. 
5.	Dodaj ramkę Zoom sekcji (zawierającą odwołania do utworzonej sekcji) do pierwszego slajdu.
6.	Zmień rozmiar i położenie utworzonego obiektu Zoom sekcji.
7.	Utwórz obiekt [IPPImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IPPImage) przez dodanie obrazu do kolekcji Images powiązanej z obiektem [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation), który zostanie użyty do wypełnienia ramki.
8.	Ustaw własny obraz dla utworzonego obiektu ramki Zoom sekcji.
9.	Ustaw możliwość *powrotu do pierwotnego slajdu z połączonej sekcji*. 
10.	Usuń tło z obrazu obiektu ramki Zoom sekcji.
11.	Zmień format linii dla drugiej ramki zoom.
12.	Zmień czas trwania przejścia.
13.	Zapisz zmodyfikowaną prezentację jako plik PPTX.

``` java
Presentation pres = new Presentation();
try {
    //Dodaje nowy slajd do prezentacji
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Dodaje nową sekcję do prezentacji
    pres.getSections().addSection("Section 1", slide);

    // Dodaje obiekt SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // Formatowanie dla SectionZoomFrame
    sectionZoomFrame.setX(100);
    sectionZoomFrame.setY(300);
    sectionZoomFrame.setWidth(100);
    sectionZoomFrame.setHeight(75);

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
         picture = pres.getImages().addImage(image);
     } finally {
        if (image != null) image.dispose();
     }
    sectionZoomFrame.setImage(picture);

    sectionZoomFrame.setReturnToParent(true);
    sectionZoomFrame.setShowBackground(false);

    sectionZoomFrame.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    sectionZoomFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.gray);
    sectionZoomFrame.getLineFormat().setDashStyle(LineDashStyle.DashDot);
    sectionZoomFrame.getLineFormat().setWidth(2.5f);

    sectionZoomFrame.setTransitionDuration(1.5f);

    // Zapisuje prezentację
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Zoom podsumowania**

Zoom podsumowania jest jak strona docelowa, na której jednocześnie wyświetlane są wszystkie elementy twojej prezentacji. Podczas prezentacji możesz używać zoomu, aby przeskakiwać między różnymi częściami prezentacji w dowolnej kolejności. Możesz być kreatywny, przeskakiwać do przodu lub wracać do wcześniejszych fragmentów bez przerywania płynności prezentacji.

![overview_image](sumzoomsel.png)

Dla obiektów Zoom podsumowania Aspose.Slides udostępnia interfejsy [ISummaryZoomFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISummaryZoomFrame), [ISummaryZoomSection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISummaryZoomSection) oraz [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISummaryZoomSectionCollection) i kilka metod w interfejsie [IShapeCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IShapeCollection).

### **Utworzenie Zoomu podsumowania**

Możesz dodać ramkę Zoom podsumowania do slajdu w następujący sposób:

1.	Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
2.	Utwórz nowe slajdy z tłem identyfikacyjnym i nowymi sekcjami dla utworzonych slajdów.
3.	Dodaj ramkę Zoom podsumowania do pierwszego slajdu.
4.	Zapisz zmodyfikowaną prezentację jako plik PPTX.

``` java 
Presentation pres = new Presentation();
try {
    //Dodaje nowy slajd do prezentacji
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Dodaje nową sekcję do prezentacji
    pres.getSections().addSection("Section 1", slide);

    //Dodaje nowy slajd do prezentacji
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Dodaje nową sekcję do prezentacji
    pres.getSections().addSection("Section 2", slide);

    //Dodaje nowy slajd do prezentacji
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Dodaje nową sekcję do prezentacji
    pres.getSections().addSection("Section 3", slide);

    //Dodaje nowy slajd do prezentacji
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Dodaje nową sekcję do prezentacji
    pres.getSections().addSection("Section 4", slide);

    // Dodaje obiekt SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // Zapisuje prezentację
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Dodawanie i usuwanie sekcji Zoom podsumowania**

Wszystkie sekcje w ramce Zoom podsumowania są reprezentowane przez obiekty [ISummaryZoomSection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISummaryZoomSection), które są przechowywane w obiekcie [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISummaryZoomSectionCollection). Możesz dodawać lub usuwać obiekty sekcji Zoom podsumowania za pomocą interfejsu [ISummaryZoomSectionCollection] w następujący sposób:

1.	Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
2.	Utwórz nowe slajdy z tłem identyfikacyjnym i nowymi sekcjami dla utworzonych slajdów.
3.	Dodaj ramkę Zoom podsumowania do pierwszego slajdu.
4.	Dodaj nowy slajd i sekcję do prezentacji.
5.	Dodaj utworzoną sekcję do ramki Zoom podsumowania.
6.	Usuń pierwszą sekcję z ramki Zoom podsumowania.
7.	Zapisz zmodyfikowaną prezentację jako plik PPTX.

``` java
Presentation pres = new Presentation();
try {
    //Dodaje nowy slajd do prezentacji
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Dodaje nową sekcję do prezentacji
    pres.getSections().addSection("Section 1", slide);

    //Dodaje nowy slajd do prezentacji
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Dodaje nową sekcję do prezentacji
    pres.getSections().addSection("Section 2", slide);

    // Dodaje obiekt SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    //Dodaje nowy slajd do prezentacji
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Dodaje nową sekcję do prezentacji
    ISection section3 = pres.getSections().addSection("Section 3", slide);

    // Dodaje sekcję do Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);

    // Usuwa sekcję z Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));

    // Zapisuje prezentację
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Formatowanie sekcji Zoom podsumowania**

Aby utworzyć bardziej złożone obiekty sekcji Zoom podsumowania, należy zmienić formatowanie prostej ramki. Istnieje kilka opcji formatowania, które możesz zastosować do obiektu sekcji Zoom podsumowania. 

Możesz kontrolować formatowanie obiektu sekcji Zoom podsumowania w ramce Zoom podsumowania w następujący sposób:

1.	Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
2.	Utwórz nowe slajdy z tłem identyfikacyjnym i nowymi sekcjami dla utworzonych slajdów.
3.	Dodaj ramkę Zoom podsumowania do pierwszego slajdu.
4.	Pobierz obiekt sekcji Zoom podsumowania dla pierwszego obiektu z `ISummaryZoomSectionCollection`.
7.	Utwórz obiekt [IPPImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IPPImage) przez dodanie obrazu do kolekcji images powiązanej z obiektem [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation), który zostanie użyty do wypełnienia ramki.
8.	Ustaw własny obraz dla utworzonego obiektu ramki Zoom sekcji.
9.	Ustaw możliwość *powrotu do pierwotnego slajdu z połączonej sekcji*. 
11.	Zmień format linii dla drugiego obiektu ramki zoom.
12.	Zmień czas trwania przejścia.
13.	Zapisz zmodyfikowaną prezentację jako plik PPTX.

``` java
Presentation pres = new Presentation();
try {
    //Dodaje nowy slajd do prezentacji
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Dodaje nową sekcję do prezentacji
    pres.getSections().addSection("Section 1", slide);

    //Dodaje nowy slajd do prezentacji
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Dodaje nową sekcję do prezentacji
    pres.getSections().addSection("Section 2", slide);

    // Dodaje obiekt SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // Pobiera pierwszy obiekt SummaryZoomSection
    ISummaryZoomSection summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);

    // Formatowanie obiektu SummaryZoomSection
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
    picture = pres.getImages().addImage(picture);
    } finally {
          if (image != null) image.dispose();
    }
    summarySection.setImage(picture);

    summarySection.setReturnToParent(false);

    summarySection.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    summarySection.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.black);
    summarySection.getLineFormat().setDashStyle(LineDashStyle.DashDot);
    summarySection.getLineFormat().setWidth(1.5f);

    summarySection.setTransitionDuration(1.5f);

    // Zapisuje prezentację
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Czy mogę kontrolować powrót do slajdu „nadrzędnego” po wyświetleniu celu?**

Tak. Ramka [Zoom](https://reference.aspose.com/slides/pl/java/com.aspose.slides/zoomframe/) lub [section](https://reference.aspose.com/slides/pl/java/com.aspose.slides/sectionzoomframe/) posiada zachowanie `ReturnToParent`, które po włączeniu odsyła widza z powrotem do slajdu źródłowego po odwiedzeniu treści docelowej.

**Czy mogę dostosować „prędkość” lub czas trwania przejścia Zoom?**

Tak. Zoom obsługuje ustawienie `TransitionDuration`, dzięki czemu możesz kontrolować, jak długo trwa animacja przeskoku.

**Czy istnieją ograniczenia liczby obiektów Zoom, które może zawierać prezentacja?**

Nie ma twardego limitu API udokumentowanego. Praktyczne ograniczenia zależą od ogólnej złożoności prezentacji oraz wydajności odtwarzacza. Możesz dodać wiele ramek Zoom, ale pamiętaj o rozmiarze pliku i czasie renderowania.