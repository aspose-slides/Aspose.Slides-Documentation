---
title: Zarządzanie zoomem prezentacji na Androidzie
linktitle: Zarządzaj Zoomem
type: docs
weight: 60
url: /pl/androidjava/manage-zoom/
keywords:
- zoom
- ramka zoom
- zoom slajdu
- zoom sekcji
- zoom podsumowania
- dodaj zoom
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Twórz i dostosowuj Zoom za pomocą Aspose.Slides dla Androida w Javie — przeskakuj między sekcjami, dodawaj miniatury i przejścia w prezentacjach PPT, PPTX i ODP."
---
## **Wprowadzenie**

Zoomy w programie PowerPoint umożliwiają przechodzenie do i z konkretnych slajdów, sekcji oraz fragmentów prezentacji. Podczas prezentacji ta możliwość szybkiej nawigacji po treści może okazać się bardzo przydatna. 

![overview_image](overview.png)

* Aby podsumować całą prezentację na jednym slajdzie, użyj [Podsumowanie Zoom](#Summary-Zoom).
* Aby wyświetlić tylko wybrane slajdy, użyj [Zoom slajdu](#Slide-Zoom).
* Aby wyświetlić tylko jedną sekcję, użyj [Zoom sekcji](#Section-Zoom).

## **Zoom slajdu**
Zoom slajdu może uczynić twoją prezentację bardziej dynamiczną, umożliwiając swobodne przeskakiwanie między slajdami w dowolnej kolejności bez przerywania płynności prezentacji. Zoomy slajdów są świetne w krótkich prezentacjach bez wielu sekcji, ale można je również wykorzystać w różnych scenariuszach prezentacji.

Zoomy slajdów pomagają zagłębić się w wiele informacji, jednocześnie sprawiając wrażenie pracy na jednej płaszczyźnie. 

![overview_image](slidezoomsel.png)

Dla obiektów zoom slajdu, Aspose.Slides udostępnia wyliczenie [ZoomImageType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ZoomImageType), interfejs [IZoomFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IZoomFrame) oraz niektóre metody w interfejsie [IShapeCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IShapeCollection).

### **Utworzenie ramek Zoom**
Możesz dodać ramkę zoom na slajdzie w następujący sposób:

1.	Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
2.	Utwórz nowe slajdy, do których zamierzasz powiązać ramki zoom.
3.	Dodaj tekst identyfikacyjny i tło do utworzonych slajdów.
4.	Dodaj ramki zoom (zawierające odwołania do utworzonych slajdów) do pierwszego slajdu.
5.	Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod Java pokazuje, jak utworzyć ramkę zoom na slajdzie:

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
### **Utworzenie ramek Zoom z własnymi obrazami**
Przy użyciu Aspose.Slides for Android via Java możesz utworzyć ramkę zoom z innym podglądem slajdu w następujący sposób:
1.	Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
2.	Utwórz nowy slajd, do którego zamierzasz powiązać ramkę zoom. 
3.	Dodaj tekst identyfikacyjny i tło do slajdu.
4.	Utwórz obiekt [IPPImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IPPImage) przez dodanie obrazu do kolekcji Images powiązanej z obiektem [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation), który zostanie użyty do wypełnienia ramki.
5.	Dodaj ramki zoom (zawierające odwołanie do utworzonego slajdu) do pierwszego slajdu.
6.	Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod Java pokazuje, jak utworzyć ramkę zoom z innym obrazem:

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
### **Formatuj ramki Zoom**
W poprzednich sekcjach pokazaliśmy, jak utworzyć proste ramki zoom. Aby utworzyć bardziej skomplikowane ramki zoom, musisz zmienić formatowanie prostej ramki. Istnieje kilka opcji formatowania, które możesz zastosować do ramki zoom. 

Możesz kontrolować formatowanie ramki zoom na slajdzie w następujący sposób:

1.	Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
2.	Utwórz nowe slajdy, do których zamierzasz powiązać ramkę zoom. 
3.	Dodaj pewien tekst identyfikacyjny i tło do utworzonych slajdów.
4.	Dodaj ramki zoom (zawierające odwołania do utworzonych slajdów) do pierwszego slajdu.
5.	Utwórz obiekt [IPPImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IPPImage) przez dodanie obrazu do kolekcji Images powiązanej z obiektem [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation), który zostanie użyty do wypełnienia ramki.
6.	Ustaw własny obraz dla pierwszej ramki zoom.
7.	Zmień format linii dla drugiej ramki zoom.
8.	Usuń tło z obrazu drugiej ramki zoom.
9.	Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod Java pokazuje, jak zmienić formatowanie ramki zoom na slajdzie: 

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

    // Ustawienie: nie wyświetlaj tła dla obiektu zoomFrame2
    zoomFrame2.setShowBackground(false);

    // Zapisuje prezentację
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zoom sekcji**

Zoom sekcji jest odnośnikiem do sekcji w twojej prezentacji. Możesz używać zoomów sekcji, aby wracać do sekcji, które chcesz szczególnie podkreślić. Możesz także używać ich, aby uwypuklić, jak pewne fragmenty twojej prezentacji ze sobą powiązane. 

![overview_image](seczoomsel.png)

Dla obiektów zoom sekcji, Aspose.Slides udostępnia interfejs [ISectionZoomFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISectionZoomFrame) oraz niektóre metody w interfejsie [IShapeCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IShapeCollection).

### **Utworzenie ramek Zoom sekcji**
Możesz dodać ramkę zoom sekcji do slajdu w następujący sposób:

1.	Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
2.	Utwórz nowy slajd. 
3.	Dodaj tło identyfikacyjne do utworzonego slajdu.
4.	Utwórz nową sekcję, do której zamierzasz powiązać ramkę zoom. 
5.	Dodaj ramkę zoom sekcji (zawierającą odwołania do utworzonej sekcji) do pierwszego slajdu.
6.	Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod Java pokazuje, jak utworzyć ramkę zoom na slajdzie:

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
### **Utworzenie ramek Zoom sekcji z własnymi obrazami**
Używając Aspose.Slides for Android via Java, możesz utworzyć ramkę zoom sekcji z innym podglądem slajdu w następujący sposób:

1.	Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
2.	Utwórz nowy slajd.
3.	Dodaj tło identyfikacyjne do utworzonego slajdu.
4.	Utwórz nową sekcję, do której zamierzasz powiązać ramkę zoom. 
5.	Utwórz obiekt [IPPImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IPPImage) przez dodanie obrazu do kolekcji Images powiązanej z obiektem [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation), który zostanie użyty do wypełnienia ramki.
5.	Dodaj ramkę zoom sekcji (zawierającą odwołanie do utworzonej sekcji) do pierwszego slajdu.
6.	Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod Java pokazuje, jak utworzyć ramkę zoom z innym obrazem:

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
### **Formatuj ramki Zoom sekcji**
Aby utworzyć bardziej skomplikowane ramki zoom sekcji, musisz zmienić formatowanie prostej ramki. Istnieje kilka opcji formatowania, które możesz zastosować do ramki zoom sekcji. 

Możesz kontrolować formatowanie ramki zoom sekcji na slajdzie w następujący sposób:

1.	Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
2.	Utwórz nowy slajd.
3.	Dodaj tło identyfikacyjne do utworzonego slajdu.
4.	Utwórz nową sekcję, do której zamierzasz powiązać ramkę zoom. 
5.	Dodaj ramkę zoom sekcji (zawierającą odwołania do utworzonej sekcji) do pierwszego slajdu.
6.	Zmień rozmiar i pozycję utworzonego obiektu zoom sekcji.
7.	Utwórz obiekt [IPPImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IPPImage) przez dodanie obrazu do kolekcji Images powiązanej z obiektem [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation), który zostanie użyty do wypełnienia ramki.
8.	Ustaw własny obraz dla utworzonego obiektu ramki zoom sekcji.
9.	Ustaw możliwość *powrotu do oryginalnego slajdu z powiązanej sekcji*.
10.	Usuń tło z obrazu obiektu ramki zoom sekcji.
11.	Zmień format linii dla drugiej ramki zoom.
12.	Zmień czas trwania przejścia.
13.	Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod Java pokazuje, jak zmienić formatowanie ramki zoom sekcji:

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


## **Zoom podsumowujący**

Zoom podsumowujący jest niczym strona docelowa, na której wszystkie elementy twojej prezentacji są wyświetlane jednocześnie. Podczas prezentacji możesz używać zoomu, aby przechodzić z jednego miejsca prezentacji do drugiego w dowolnej kolejności. Możesz być kreatywny, przeskakiwać do przodu lub wracać do fragmentów pokazu, nie przerywając płynności prezentacji.

![overview_image](sumzoomsel.png)

Dla obiektów zoom podsumowującego, Aspose.Slides udostępnia interfejsy [ISummaryZoomFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISummaryZoomFrame), [ISummaryZoomSection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISummaryZoomSection) oraz [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISummaryZoomSectionCollection), a także niektóre metody w interfejsie [IShapeCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IShapeCollection).

### **Utworzenie Zoom podsumowującego**
Możesz dodać ramkę podsumowującego zoomu do slajdu w następujący sposób:

1.	Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
2.	Utwórz nowe slajdy z tłem identyfikacyjnym i nowe sekcje dla utworzonych slajdów.
3.	Dodaj ramkę podsumowującego zoomu do pierwszego slajdu.
4.	Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod Java pokazuje, jak utworzyć ramkę podsumowującego zoomu na slajdzie:

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

### **Dodawanie i usuwanie sekcji Zoom podsumowującego**
Wszystkie sekcje w ramce podsumowującego zoomu są reprezentowane przez obiekty [ISummaryZoomSection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISummaryZoomSection), które są przechowywane w obiekcie [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISummaryZoomSectionCollection). Możesz dodawać lub usuwać obiekt sekcji podsumowującego zoomu za pośrednictwem interfejsu [ISummaryZoomSectionCollection] w następujący sposób:

1.	Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
2.	Utwórz nowe slajdy z tłem identyfikacyjnym i nowe sekcje dla utworzonych slajdów.
3.	Dodaj ramkę podsumowującego zoomu do pierwszego slajdu.
4.	Dodaj nowy slajd i sekcję do prezentacji.
5.	Dodaj utworzoną sekcję do ramki podsumowującego zoomu.
6.	Usuń pierwszą sekcję z ramki podsumowującego zoomu.
7.	Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod Java pokazuje, jak dodać i usunąć sekcje w ramce podsumowującego zoomu:

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

### **Formatuj sekcje Zoom podsumowującego**
Aby utworzyć bardziej skomplikowane obiekty sekcji podsumowującego zoomu, musisz zmienić formatowanie prostej ramki. Istnieje kilka opcji formatowania, które możesz zastosować do obiektu sekcji podsumowującego zoomu. 

Możesz kontrolować formatowanie obiektu sekcji podsumowującego zoomu w ramce podsumowującego zoomu w następujący sposób:

1.	Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
2.	Utwórz nowe slajdy z tłem identyfikacyjnym i nowe sekcje dla utworzonych slajdów.
3.	Dodaj ramkę podsumowującego zoomu do pierwszego slajdu.
4.	Pobierz obiekt sekcji podsumowującego zoomu dla pierwszego obiektu z `ISummaryZoomSectionCollection`.
7.	Utwórz obiekt [IPPImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IPPImage) przez dodanie obrazu do kolekcji images powiązanej z obiektem [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation), który zostanie użyty do wypełnienia ramki.
8.	Ustaw własny obraz dla utworzonego obiektu ramki sekcji zoom.
9.	Ustaw możliwość *powrotu do oryginalnego slajdu z powiązanej sekcji*.
11.	Zmień format linii dla drugiego obiektu ramki zoom.
12.	Zmień czas trwania przejścia.
13.	Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod Java pokazuje, jak zmienić formatowanie obiektu sekcji podsumowującego zoomu:

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

**Czy mogę kontrolować powrót do slajdu 'nadrzędnego' po wyświetleniu celu?**

Tak. [Ramka Zoom](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/zoomframe/) lub [sekcja](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/sectionzoomframe/) posiada zachowanie powrotu do slajdu nadrzędnego, które po włączeniu odsyła widzów z powrotem do slajdu początkowego po odwiedzeniu docelowej treści.

**Czy mogę dostosować 'prędkość' lub czas trwania przejścia Zoom?**

Tak. Zoom obsługuje ustawianie czasu trwania przejścia, dzięki czemu możesz kontrolować, jak długo trwa animacja przeskoku.

**Czy istnieją ograniczenia dotyczące liczby obiektów Zoom, które może zawierać prezentacja?**

Nie ma sztywno udokumentowanego limitu API. Ograniczenia praktyczne zależą od ogólnej złożoności prezentacji oraz wydajności odtwarzacza. Można dodać wiele ramek Zoom, ale warto zwrócić uwagę na rozmiar pliku i czas renderowania.