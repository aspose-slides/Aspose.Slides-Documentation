---
title: Zarządzanie Zoomem prezentacji w JavaScript
linktitle: Zarządzaj Zoomem
type: docs
weight: 60
url: /pl/nodejs-java/manage-zoom/
keywords:
- zoom
- ramka zoom
- zoom slajdu
- zoom sekcji
- zoom podsumowujący
- dodaj zoom
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Twórz i dostosowuj Zoom za pomocą Aspose.Slides dla Node.js — przeskakuj między sekcjami, dodawaj miniatury i przejścia w prezentacjach PPT, PPTX i ODP."
---
## **Wprowadzenie**

Zoomy w PowerPoint pozwalają przeskakiwać do i z określonych slajdów, sekcji oraz fragmentów prezentacji. Podczas prowadzenia prezentacji ta możliwość szybkiej nawigacji po zawartości może okazać się bardzo przydatna. 

![overview_image](overview.png)

* Aby podsumować całą prezentację na jednym slajdzie, użyj [Zoom podsumowujący](#Summary-Zoom).
* Aby wyświetlić tylko wybrane slajdy, użyj [Zoom slajdu](#Slide-Zoom).
* Aby wyświetlić tylko jedną sekcję, użyj [Zoom sekcji](#Section-Zoom).

## **Zoom slajdu**

Zoom slajdu może uczynić Twoją prezentację bardziej dynamiczną, pozwalając swobodnie nawigować pomiędzy slajdami w dowolnej kolejności, nie przerywając przepływu prezentacji. Zoomy slajdów są świetne w krótkich prezentacjach bez wielu sekcji, ale możesz ich używać w różnych scenariuszach prezentacji.

Zoomy slajdów pomagają zagłębiać się w wiele informacji, jednocześnie dając wrażenie pracy na jednym płótnie. 

![overview_image](slidezoomsel.png)

Dla obiektów zoom slajdu Aspose.Slides udostępnia wyliczenie [ZoomImageType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ZoomImageType), klasę [ZoomFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ZoomFrame) oraz niektóre metody w klasie [ShapeCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ShapeCollection).

### **Tworzenie ramek Zoom**

Możesz dodać ramkę zoom na slajdzie w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
2. Utwórz nowe slajdy, do których zamierzasz połączyć ramki zoom. 
3. Dodaj tekst identyfikacyjny i tło do utworzonych slajdów.
4. Dodaj ramki zoom (zawierające odwołania do utworzonych slajdów) do pierwszego slajdu.
5. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod JavaScript pokazuje, jak utworzyć ramkę zoom na slajdzie:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Dodaje nowe slajdy do prezentacji
    var slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    var slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // Tworzy tło dla drugiego slajdu
    slide2.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // Tworzy pole tekstowe dla drugiego slajdu
    var autoshape = slide2.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // Tworzy tło dla trzeciego slajdu
    slide3.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "darkGray"));
    // Tworzy pole tekstowe dla trzeciego slajdu
    autoshape = slide3.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");
    // Dodaje obiekty ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);
    // Zapisuje prezentację
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Tworzenie ramek Zoom z własnymi obrazami**

Korzystając z Aspose.Slides dla Node.js via Java, możesz utworzyć ramkę zoom z innym podglądem slajdu w następujący sposób:
1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
2. Utwórz nowy slajd, do którego zamierzasz połączyć ramkę zoom. 
3. Dodaj tekst identyfikacyjny i tło do slajdu.
4. Utwórz obiekt [PPImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/PPImage), dodając obraz do kolekcji Images powiązanej z obiektem [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation), który zostanie użyty do wypełnienia ramki.
5. Dodaj ramki zoom (zawierające odwołanie do utworzonego slajdu) do pierwszego slajdu.
6. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod JavaScript pokazuje, jak utworzyć ramkę zoom z innym obrazem:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Dodaje nowy slajd do prezentacji
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // Tworzy tło dla drugiego slajdu
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // Tworzy pole tekstowe dla trzeciego slajdu
    var autoshape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // Tworzy nowy obraz dla obiektu zoom
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Dodaje obiekt ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);
    // Zapisuje prezentację
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Formatowanie ramek Zoom**

W poprzednich sekcjach pokazaliśmy, jak utworzyć proste ramki zoom. Aby stworzyć bardziej skomplikowane ramki zoom, musisz zmienić formatowanie prostej ramki. Istnieje kilka opcji formatowania, które możesz zastosować do ramki zoom. 

Możesz kontrolować formatowanie ramki zoom na slajdzie w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
2. Utwórz nowe slajdy, do których zamierzasz połączyć ramkę zoom. 
3. Dodaj tekst identyfikacyjny i tło do utworzonych slajdów.
4. Dodaj ramki zoom (zawierające odwołania do utworzonych slajdów) do pierwszego slajdu.
5. Utwórz obiekt [PPImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/PPImage), dodając obraz do kolekcji Images powiązanej z obiektem [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation), który zostanie użyty do wypełnienia ramki.
6. Ustaw własny obraz dla pierwszego obiektu ramki zoom.
7. Zmień format linii dla drugiego obiektu ramki zoom.
8. Usuń tło z obrazu drugiego obiektu ramki zoom.
5. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod JavaScript pokazuje, jak zmienić formatowanie ramki zoom na slajdzie:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Dodaje nowe slajdy do prezentacji
    var slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    var slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // Tworzy tło dla drugiego slajdu
    slide2.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // Tworzy pole tekstowe dla drugiego slajdu
    var autoshape = slide2.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // Tworzy tło dla trzeciego slajdu
    slide3.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "darkGray"));
    // Tworzy pole tekstowe dla trzeciego slajdu
    autoshape = slide3.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");
    // Dodaje obiekty ZoomFrame
    var zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    var zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);
    // Tworzy nowy obraz dla obiektu zoom
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Ustawia własny obraz dla obiektu zoomFrame1
    zoomFrame1.setImage(picture);
    // Ustawia format ramki zoom dla obiektu zoomFrame2
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "pink"));
    zoomFrame2.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    // Ustawienie, aby nie wyświetlać tła dla obiektu zoomFrame2
    zoomFrame2.setShowBackground(false);
    // Zapisuje prezentację
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Zoom sekcji**

Zoom sekcji jest odnośnikiem do sekcji w Twojej prezentacji. Możesz używać zoomów sekcji, aby wrócić do sekcji, które chcesz szczególnie podkreślić. Albo możesz ich używać, aby uwidocznić, jak poszczególne fragmenty Twojej prezentacji współgrają ze sobą. 

![overview_image](seczoomsel.png)

Dla obiektów zoom sekcji Aspose.Slides udostępnia klasę [SectionZoomFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SectionZoomFrame) oraz niektóre metody w klasie [ShapeCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ShapeCollection).

### **Tworzenie ramek Zoom sekcji**

Możesz dodać ramkę zoom sekcji do slajdu w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
2. Utwórz nowy slajd. 
3. Dodaj tło identyfikacyjne do utworzonego slajdu.
4. Utwórz nową sekcję, do której zamierzasz połączyć ramkę zoom. 
5. Dodaj ramkę zoom sekcji (zawierającą odwołania do utworzonej sekcji) do pierwszego slajdu.
6. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod JavaScript pokazuje, jak utworzyć ramkę zoom na slajdzie:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Dodaje nowy slajd do prezentacji
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Dodaje nową sekcję do prezentacji
    pres.getSections().addSection("Section 1", slide);
    // Dodaje obiekt SectionZoomFrame
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));
    // Zapisuje prezentację
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Tworzenie ramek Zoom sekcji z własnymi obrazami**

Korzystając z Aspose.Slides dla Node.js via Java, możesz utworzyć ramkę zoom sekcji z innym podglądem slajdu w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
2. Utwórz nowy slajd.
3. Dodaj tło identyfikacyjne do utworzonego slajdu.
4. Utwórz nową sekcję, do której zamierzasz połączyć ramkę zoom. 
5. Utwórz obiekt [PPImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/PPImage), dodając obraz do kolekcji Images powiązanej z obiektem [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation), który zostanie użyty do wypełnienia ramki.
5. Dodaj ramkę zoom sekcji (zawierającą odwołanie do utworzonej sekcji) do pierwszego slajdu.
6. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod JavaScript pokazuje, jak utworzyć ramkę zoom z innym obrazem:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Dodaje nowy slajd do prezentacji
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Dodaje nową sekcję do prezentacji
    pres.getSections().addSection("Section 1", slide);
    // Tworzy nowy obraz dla obiektu zoom
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Dodaje obiekt SectionZoomFrame
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);
    // Zapisuje prezentację
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Formatowanie ramek Zoom sekcji**

Aby utworzyć bardziej skomplikowane ramki zoom sekcji, musisz zmienić formatowanie prostej ramki. Istnieje kilka opcji formatowania, które możesz zastosować do ramki zoom sekcji. 

Możesz kontrolować formatowanie ramki zoom sekcji na slajdzie w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
2. Utwórz nowy slajd.
3. Dodaj tło identyfikacyjne do utworzonego slajdu.
4. Utwórz nową sekcję, do której zamierzasz połączyć ramkę zoom. 
5. Dodaj ramkę zoom sekcji (zawierającą odwołania do utworzonej sekcji) do pierwszego slajdu.
6. Zmień rozmiar i położenie utworzonego obiektu zoom sekcji.
7. Utwórz obiekt [PPImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/PPImage), dodając obraz do kolekcji Images powiązanej z obiektem [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation), który zostanie użyty do wypełnienia ramki.
8. Ustaw własny obraz dla utworzonego obiektu ramki zoom sekcji.
9. Ustaw możliwość *powrotu do oryginalnego slajdu z powiązanej sekcji*. 
10. Usuń tło z obrazu obiektu ramki zoom sekcji.
11. Zmień format linii dla drugiego obiektu ramki zoom.
12. Zmień czas trwania przejścia.
13. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod JavaScript pokazuje, jak zmienić formatowanie ramki zoom sekcji:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Dodaje nowy slajd do prezentacji
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Dodaje nową sekcję do prezentacji
    pres.getSections().addSection("Section 1", slide);
    // Dodaje obiekt SectionZoomFrame
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));
    // Formatowanie dla SectionZoomFrame
    sectionZoomFrame.setX(100);
    sectionZoomFrame.setY(300);
    sectionZoomFrame.setWidth(100);
    sectionZoomFrame.setHeight(75);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    sectionZoomFrame.setImage(picture);
    sectionZoomFrame.setReturnToParent(true);
    sectionZoomFrame.setShowBackground(false);
    sectionZoomFrame.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    sectionZoomFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    sectionZoomFrame.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    sectionZoomFrame.getLineFormat().setWidth(2.5);
    sectionZoomFrame.setTransitionDuration(1.5);
    // Zapisuje prezentację
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Zoom podsumowujący**

Zoom podsumowujący jest jak strona docelowa, na której wszystkie elementy prezentacji są wyświetlane jednocześnie. Podczas prezentacji możesz używać zoomu, aby przechodzić z jednego miejsca w prezentacji do drugiego w dowolnej kolejności. Możesz być kreatywny, przeskakiwać do przodu lub wracać do fragmentów pokazu bez przerywania płynności prezentacji.

![overview_image](sumzoomsel.png)

Dla obiektów zoom podsumowującego Aspose.Slides udostępnia klasy [SummaryZoomFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SummaryZoomFrame), [SummaryZoomSection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SummaryZoomSection) oraz [SummaryZoomSectionCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SummaryZoomSectionCollection) i niektóre metody w klasie [ShapeCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ShapeCollection).

### **Tworzenie Zoom podsumowującego**

Możesz dodać ramkę zoom podsumowującego do slajdu w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
2. Utwórz nowe slajdy z tłem identyfikacyjnym i nowymi sekcjami dla utworzonych slajdów.
3. Dodaj ramkę zoom podsumowującego do pierwszego slajdu.
4. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod JavaScript pokazuje, jak utworzyć ramkę zoom podsumowującego na slajdzie:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Dodaje nowy slajd do prezentacji
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Dodaje nową sekcję do prezentacji
    pres.getSections().addSection("Section 1", slide);
    // Dodaje nowy slajd do prezentacji
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Dodaje nową sekcję do prezentacji
    pres.getSections().addSection("Section 2", slide);
    // Dodaje nowy slajd do prezentacji
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "magenta"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Dodaje nową sekcję do prezentacji
    pres.getSections().addSection("Section 3", slide);
    // Dodaje nowy slajd do prezentacji
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "green"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Dodaje nową sekcję do prezentacji
    pres.getSections().addSection("Section 4", slide);
    // Dodaje obiekt SummaryZoomFrame
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // Zapisuje prezentację
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Dodawanie i usuwanie sekcji Zoom podsumowującego**

Wszystkie sekcje w ramce zoom podsumowującego są reprezentowane przez obiekty [SummaryZoomSection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SummaryZoomSection), przechowywane w obiekcie [SummaryZoomSectionCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SummaryZoomSectionCollection). Możesz dodać lub usunąć obiekt sekcji zoom podsumowującego poprzez klasę [SummaryZoomSectionCollection] w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
2. Utwórz nowe slajdy z tłem identyfikacyjnym i nowymi sekcjami dla utworzonych slajdów.
3. Dodaj ramkę zoom podsumowującego do pierwszego slajdu.
4. Dodaj nowy slajd i sekcję do prezentacji.
5. Dodaj utworzoną sekcję do ramki zoom podsumowującego.
6. Usuń pierwszą sekcję z ramki zoom podsumowującego.
7. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod JavaScript pokazuje, jak dodawać i usuwać sekcje w ramce zoom podsumowującego:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Dodaje nowy slajd do prezentacji
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Dodaje nową sekcję do prezentacji
    pres.getSections().addSection("Section 1", slide);
    // Dodaje nowy slajd do prezentacji
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Dodaje nową sekcję do prezentacji
    pres.getSections().addSection("Section 2", slide);
    // Dodaje obiekt SummaryZoomFrame
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // Dodaje nowy slajd do prezentacji
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "magenta"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Dodaje nową sekcję do prezentacji
    var section3 = pres.getSections().addSection("Section 3", slide);
    // Dodaje sekcję do Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);
    // Usuwa sekcję z Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));
    // Zapisuje prezentację
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Formatowanie sekcji Zoom podsumowującego**

Aby utworzyć bardziej skomplikowane obiekty sekcji zoom podsumowującego, musisz zmienić formatowanie prostej ramki. Istnieje kilka opcji formatowania, które możesz zastosować do obiektu sekcji zoom podsumowującego. 

Możesz kontrolować formatowanie obiektu sekcji zoom podsumowującego w ramce zoom podsumowującego w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
2. Utwórz nowe slajdy z tłem identyfikacyjnym i nowymi sekcjami dla utworzonych slajdów.
3. Dodaj ramkę zoom podsumowującego do pierwszego slajdu.
4. Pobierz obiekt sekcji zoom podsumowującego dla pierwszego elementu z `ISummaryZoomSectionCollection`.
7. Utwórz obiekt [PPImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/PPImage), dodając obraz do kolekcji images powiązanej z obiektem [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation), który zostanie użyty do wypełnienia ramki.
8. Ustaw własny obraz dla utworzonego obiektu ramki zoom sekcji.
9. Ustaw możliwość *powrotu do oryginalnego slajdu z powiązanej sekcji*. 
11. Zmień format linii dla drugiego obiektu ramki zoom.
12. Zmień czas trwania przejścia.
13. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod JavaScript pokazuje, jak zmienić formatowanie obiektu sekcji zoom podsumowującego:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Dodaje nowy slajd do prezentacji
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Dodaje nową sekcję do prezentacji
    pres.getSections().addSection("Section 1", slide);
    // Dodaje nowy slajd do prezentacji
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Dodaje nową sekcję do prezentacji
    pres.getSections().addSection("Section 2", slide);
    // Dodaje obiekt SummaryZoomFrame
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // Pobiera pierwszy obiekt SummaryZoomSection
    var summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);
    // Formatowanie obiektu SummaryZoomSection
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(picture);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    summarySection.setImage(picture);
    summarySection.setReturnToParent(false);
    summarySection.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    summarySection.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "black"));
    summarySection.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    summarySection.getLineFormat().setWidth(1.5);
    summarySection.setTransitionDuration(1.5);
    // Zapisuje prezentację
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Czy mogę kontrolować powrót do slajdu „nadrzędnego” po wyświetleniu docelowego?**

Tak. Obiekt [Zoom frame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/zoomframe/) lub [section](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sectionzoomframe/) posiada metodę `setReturnToParent`, która po włączeniu odsyła widza z powrotem do slajdu źródłowego po odwiedzeniu docelowej treści.

**Czy mogę dostosować „szybkość” lub czas trwania przejścia Zoom?**

Tak. Zoom udostępnia metodę `setTransitionDuration`, dzięki której możesz kontrolować, jak długo trwa animacja przeskoku.

**Czy istnieją ograniczenia dotyczące liczby obiektów Zoom, które może zawierać prezentacja?**

Nie ma sztywno określonego limitu API w dokumentacji. Ograniczenia praktyczne zależą od złożoności całej prezentacji oraz wydajności odtwarzacza. Możesz dodać wiele ramek Zoom, ale warto zwrócić uwagę na rozmiar pliku i czas renderowania.