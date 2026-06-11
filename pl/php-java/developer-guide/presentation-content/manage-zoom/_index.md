---
title: Zarządzaj zoomem prezentacji w PHP
linktitle: Zarządzaj zoomem
type: docs
weight: 60
url: /pl/php-java/manage-zoom/
keywords:
- zoom
- ramka zoom
- zoom slajdu
- zoom sekcji
- zoom podsumowania
- dodaj zoom
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Utwórz i dostosuj Zoom za pomocą Aspose.Slides for PHP via Java — przeskakuj między sekcjami, dodawaj miniatury i przejścia w prezentacjach PPT, PPTX i ODP."
---
## **Wstęp**

Zoomy w PowerPoint umożliwiają szybkie przejście do i z określonych slajdów, sekcji i fragmentów prezentacji. Podczas prezentacji ta możliwość szybkiej nawigacji po zawartości może okazać się bardzo przydatna. 

![overview_image](overview.png)

* Aby podsumować całą prezentację na jednym slajdzie, użyj [Podsumowanie Zoom](#Summary-Zoom).
* Aby wyświetlić wybrane slajdy, użyj [Zoom slajdu](#Slide-Zoom).
* Aby wyświetlić jedną sekcję, użyj [Zoom sekcji](#Section-Zoom).

## **Zoom slajdu**
Zoom slajdu może uczynić Twoją prezentację bardziej dynamiczną, pozwalając na swobodne przechodzenie między slajdami w dowolnej kolejności bez przerywania jej przebiegu. Zoomy slajdów są świetne w krótkich prezentacjach bez wielu sekcji, ale możesz ich używać w różnych scenariuszach prezentacji.

Zoomy slajdów pomagają zagłębić się w wiele informacji, jednocześnie dając wrażenie pracy na jednej płaszczyźnie. 

![overview_image](slidezoomsel.png)

Dla obiektów zoomu slajdu Aspose.Slides udostępnia wyliczenie [ZoomImageType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/zoomimagetype/), klasę [ZoomFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/zoomframe/) oraz niektóre metody w ramach klasy [ShapeCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/).

### **Tworzenie ramek zoomu**

Możesz dodać ramkę zoomu na slajdzie w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).
2. Utwórz nowe slajdy, które zamierzasz połączyć z ramkami zoomu. 
3. Dodaj tekst identyfikacyjny i tło do utworzonych slajdów.
4. Dodaj ramki zoomu (zawierające odwołania do utworzonych slajdów) do pierwszego slajdu.
5. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod PHP pokazuje, jak stworzyć ramkę zoomu na slajdzie:

```php
  $pres = new Presentation();
  try {
    # Dodaje nowe slajdy do prezentacji
    $slide2 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide3 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # Tworzy tło dla drugiego slajdu
    $slide2->getBackground()->setType(BackgroundType::OwnBackground);
    $slide2->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide2->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # Tworzy pole tekstowe dla drugiego slajdu
    $autoshape = $slide2->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # Tworzy tło dla trzeciego slajdu
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # Tworzy pole tekstowe dla trzeciego slajdu
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Trird Slide");
    # Dodaje obiekty ZoomFrame
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 250, 200, $slide2);
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(200, 250, 250, 200, $slide3);
    # Zapisuje prezentację
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **Tworzenie ramek zoomu z własnymi obrazami**
Z wykorzystaniem Aspose.Slides for PHP via Java możesz utworzyć ramkę zoomu z innym podglądem slajdu w następujący sposób:
1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).
2. Utwórz nowy slajd, do którego zamierzasz połączyć ramkę zoomu. 
3. Dodaj tekst identyfikacyjny i tło do slajdu.
4. Utwórz obiekt [PPImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ppimage/) przez dodanie obrazu do kolekcji Images powiązanej z obiektem [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/), który zostanie użyty do wypełnienia ramki.
5. Dodaj ramki zoomu (zawierające odwołanie do utworzonego slajdu) do pierwszego slajdu.
6. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod PHP pokazuje, jak stworzyć ramkę zoomu z innym obrazem:

```php
  $pres = new Presentation();
  try {
    # Dodaje nowy slajd do prezentacji
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # Tworzy tło dla drugiego slajdu
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # Tworzy pole tekstowe dla trzeciego slajdu
    $autoshape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # Tworzy nowy obraz dla obiektu zoom
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Dodaje obiekt ZoomFrame
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 300, 200, $slide, $picture);
    # Zapisuje prezentację
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **Formatowanie ramek zoomu**
W poprzednich sekcjach pokazaliśmy, jak tworzyć proste ramki zoomu. Aby stworzyć bardziej złożone ramki zoomu, musisz zmienić formatowanie prostej ramki. Istnieje kilka opcji formatowania, które możesz zastosować do ramki zoomu. 

Możesz kontrolować formatowanie ramki zoomu na slajdzie w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).
2. Utwórz nowe slajdy, do których zamierzasz połączyć ramkę zoomu. 
3. Dodaj tekst identyfikacyjny i tło do utworzonych slajdów.
4. Dodaj ramki zoomu (zawierające odwołania do utworzonych slajdów) do pierwszego slajdu.
5. Utwórz obiekt [PPImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ppimage/) przez dodanie obrazu do kolekcji Images powiązanej z obiektem [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/), który zostanie użyty do wypełnienia ramki.
6. Ustaw własny obraz dla pierwszego obiektu ramki zoomu.
7. Zmień format linii dla drugiego obiektu ramki zoomu.
8. Usuń tło z obrazu drugiego obiektu ramki zoomu.
5. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod PHP pokazuje, jak zmienić formatowanie ramki zoomu na slajdzie:

```php
  $pres = new Presentation();
  try {
    # Dodaje nowe slajdy do prezentacji
    $slide2 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide3 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # Tworzy tło dla drugiego slajdu
    $slide2->getBackground()->setType(BackgroundType::OwnBackground);
    $slide2->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide2->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # Tworzy pole tekstowe dla drugiego slajdu
    $autoshape = $slide2->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # Tworzy tło dla trzeciego slajdu
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # Tworzy pole tekstowe dla trzeciego slajdu
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Trird Slide");
    # Dodaje obiekty ZoomFrame
    $zoomFrame1 = $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 250, 200, $slide2);
    $zoomFrame2 = $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(200, 250, 250, 200, $slide3);
    # Tworzy nowy obraz dla obiektu zoom
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Ustawia własny obraz dla obiektu zoomFrame1
    $zoomFrame1->setImage($picture);
    # Ustawia format ramki zoom dla obiektu zoomFrame2
    $zoomFrame2->getLineFormat()->setWidth(5);
    $zoomFrame2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $zoomFrame2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->pink);
    $zoomFrame2->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    # Ustawienie: Nie pokazuj tła dla obiektu zoomFrame2
    $zoomFrame2->setShowBackground(false);
    # Zapisuje prezentację
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Zoom sekcji**

Zoom sekcji to odnośnik do sekcji w Twojej prezentacji. Możesz używać zoomów sekcji, aby wracać do sekcji, które chcesz szczególnie podkreślić. Albo używać ich, aby pokazać, jak poszczególne fragmenty Twojej prezentacji są ze sobą powiązane. 

![overview_image](seczoomsel.png)

Dla obiektów zoomu sekcji Aspose.Slides udostępnia klasę [SectionZoomFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sectionzoomframe/) oraz niektóre metody w ramach klasy [ShapeCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/).

### **Tworzenie ramek zoomu sekcji**

Możesz dodać ramkę zoomu sekcji do slajdu w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).
2. Utwórz nowy slajd. 
3. Dodaj tło identyfikacyjne do utworzonego slajdu.
4. Utwórz nową sekcję, do której zamierzasz połączyć ramkę zoomu. 
5. Dodaj ramkę zoomu sekcji (zawierającą odwołania do utworzonej sekcji) do pierwszego slajdu.
6. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod PHP pokazuje, jak stworzyć ramkę zoomu na slajdzie:

```php
  $pres = new Presentation();
  try {
    # Dodaje nowy slajd do prezentacji
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Dodaje nową sekcję do prezentacji
    $pres->getSections()->addSection("Section 1", $slide);
    # Dodaje obiekt SectionZoomFrame
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1));
    # Zapisuje prezentację
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **Tworzenie ramek zoomu sekcji z własnymi obrazami**

Korzystając z Aspose.Slides for PHP via Java, możesz utworzyć ramkę zoomu sekcji z innym podglądem slajdu w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).
2. Utwórz nowy slajd.
3. Dodaj tło identyfikacyjne do utworzonego slajdu.
4. Utwórz nową sekcję, do której zamierzasz połączyć ramkę zoomu. 
5. Utwórz obiekt [PPImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ppimage/) przez dodanie obrazu do kolekcji Images powiązanej z obiektem [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/), który zostanie użyty do wypełnienia ramki.
5. Dodaj ramkę zoomu sekcji (zawierającą odwołanie do utworzonej sekcji) do pierwszego slajdu.
6. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod PHP pokazuje, jak stworzyć ramkę zoomu z innym obrazem:

```php
  $pres = new Presentation();
  try {
    # Dodaje nowy slajd do prezentacji
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Dodaje nową sekcję do prezentacji
    $pres->getSections()->addSection("Section 1", $slide);
    # Tworzy nowy obraz dla obiektu zoom
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Dodaje obiekt SectionZoomFrame
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1), $picture);
    # Zapisuje prezentację
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **Formatowanie ramek zoomu sekcji**

Aby tworzyć bardziej skomplikowane ramki zoomu sekcji, musisz zmienić formatowanie prostej ramki. Istnieje kilka opcji formatowania, które możesz zastosować do ramki zoomu sekcji. 

Możesz kontrolować formatowanie ramki zoomu sekcji na slajdzie w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).
2. Utwórz nowy slajd.
3. Dodaj tło identyfikacyjne do utworzonego slajdu.
4. Utwórz nową sekcję, do której zamierzasz połączyć ramkę zoomu. 
5. Dodaj ramkę zoomu sekcji (zawierającą odwołania do utworzonej sekcji) do pierwszego slajdu.
6. Zmień rozmiar i pozycję utworzonego obiektu zoomu sekcji.
7. Utwórz obiekt [PPImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ppimage/) przez dodanie obrazu do kolekcji Images powiązanej z obiektem [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/), który zostanie użyty do wypełnienia ramki.
8. Ustaw własny obraz dla utworzonego obiektu ramki zoomu sekcji.
9. Ustaw możliwość *powrotu do oryginalnego slajdu z połączonej sekcji*. 
10. Usuń tło z obrazu obiektu ramki zoomu sekcji.
11. Zmień format linii dla drugiego obiektu ramki zoomu.
12. Zmień czas trwania przejścia.
13. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod PHP pokazuje, jak zmienić formatowanie ramki zoomu sekcji:

```php
  $pres = new Presentation();
  try {
    # Dodaje nowy slajd do prezentacji
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Dodaje nową sekcję do prezentacji
    $pres->getSections()->addSection("Section 1", $slide);
    # Dodaje obiekt SectionZoomFrame
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1));
    # Formatowanie dla SectionZoomFrame
    $sectionZoomFrame->setX(100);
    $sectionZoomFrame->setY(300);
    $sectionZoomFrame->setWidth(100);
    $sectionZoomFrame->setHeight(75);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $sectionZoomFrame->setImage($picture);
    $sectionZoomFrame->setReturnToParent(true);
    $sectionZoomFrame->setShowBackground(false);
    $sectionZoomFrame->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $sectionZoomFrame->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $sectionZoomFrame->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $sectionZoomFrame->getLineFormat()->setWidth(2.5);
    $sectionZoomFrame->setTransitionDuration(1.5);
    # Zapisuje prezentację
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Podsumowanie Zoom**

Podsumowanie Zoom to rodzaj strony docelowej, na której wszystkie elementy Twojej prezentacji są wyświetlane jednocześnie. Podczas prezentacji możesz używać zoomu, aby przechodzić z jednego miejsca w prezentacji do drugiego w dowolnej kolejności. Możesz być kreatywny, przeskakiwać do przodu lub wracać do fragmentów pokazu bez przerywania jego płynności.

![overview_image](sumzoomsel.png)

Dla obiektów podsumowania Zoom Aspose.Slides udostępnia klasy [SummaryZoomFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/summaryzoomsection/) oraz [SummaryZoomSectionCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/summaryzoomsectioncollection/) i niektóre metody w ramach klasy [ShapeCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/).

### **Tworzenie podsumowania Zoom**

Możesz dodać ramkę podsumowania Zoom do slajdu w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).
2. Utwórz nowe slajdy z tłem identyfikacyjnym i nowymi sekcjami dla utworzonych slajdów.
3. Dodaj ramkę podsumowania Zoom do pierwszego slajdu.
4. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod PHP pokazuje, jak stworzyć ramkę podsumowania Zoom na slajdzie:

```php
  $pres = new Presentation();
  try {
    # Dodaje nowy slajd do prezentacji
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Dodaje nową sekcję do prezentacji
    $pres->getSections()->addSection("Section 1", $slide);
    # Dodaje nowy slajd do prezentacji
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Dodaje nową sekcję do prezentacji
    $pres->getSections()->addSection("Section 2", $slide);
    # Dodaje nowy slajd do prezentacji
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Dodaje nową sekcję do prezentacji
    $pres->getSections()->addSection("Section 3", $slide);
    # Dodaje nowy slajd do prezentacji
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->green);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Dodaje nową sekcję do prezentacji
    $pres->getSections()->addSection("Section 4", $slide);
    # Dodaje obiekt SummaryZoomFrame
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # Zapisuje prezentację
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Dodawanie i usuwanie sekcji podsumowania Zoom**

Wszystkie sekcje w ramce podsumowania Zoom są reprezentowane przez obiekty [SummaryZoomSection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/summaryzoomsection/), które są przechowywane w obiekcie [SummaryZoomSectionCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/summaryzoomsectioncollection/). Możesz dodawać lub usuwać sekcję podsumowania Zoom za pomocą klasy [SummaryZoomSectionCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/summaryzoomsectioncollection/) w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).
2. Utwórz nowe slajdy z tłem identyfikacyjnym i nowymi sekcjami dla utworzonych slajdów.
3. Dodaj ramkę podsumowania Zoom do pierwszego slajdu.
4. Dodaj nowy slajd i sekcję do prezentacji.
5. Dodaj utworzoną sekcję do ramki podsumowania Zoom.
6. Usuń pierwszą sekcję z ramki podsumowania Zoom.
7. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod PHP pokazuje, jak dodawać i usuwać sekcje w ramce podsumowania Zoom:

```php
  $pres = new Presentation();
  try {
    # Dodaje nowy slajd do prezentacji
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Dodaje nową sekcję do prezentacji
    $pres->getSections()->addSection("Section 1", $slide);
    # Dodaje nowy slajd do prezentacji
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Dodaje nową sekcję do prezentacji
    $pres->getSections()->addSection("Section 2", $slide);
    # Dodaje obiekt SummaryZoomFrame
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # Dodaje nowy slajd do prezentacji
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Dodaje nową sekcję do prezentacji
    $section3 = $pres->getSections()->addSection("Section 3", $slide);
    # Dodaje sekcję do Summary Zoom
    $summaryZoomFrame->getSummaryZoomCollection()->addSummaryZoomSection($section3);
    # Usuwa sekcję z Summary Zoom
    $summaryZoomFrame->getSummaryZoomCollection()->removeSummaryZoomSection($pres->getSections()->get_Item(1));
    # Zapisuje prezentację
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Formatowanie sekcji podsumowania Zoom**

Aby tworzyć bardziej złożone obiekty sekcji podsumowania Zoom, musisz zmienić formatowanie prostej ramki. Istnieje kilka opcji formatowania, które możesz zastosować do obiektu sekcji podsumowania Zoom. 

Możesz kontrolować formatowanie obiektu sekcji podsumowania Zoom w ramce podsumowania Zoom w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).
2. Utwórz nowe slajdy z tłem identyfikacyjnym i nowymi sekcjami dla utworzonych slajdów.
3. Dodaj ramkę podsumowania Zoom do pierwszego slajdu.
4. Pobierz obiekt sekcji podsumowania Zoom dla pierwszego obiektu z `SummaryZoomSectionCollection`.
7. Utwórz obiekt [PPImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ppimage/) przez dodanie obrazu do kolekcji images powiązanej z obiektem [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/), który zostanie użyty do wypełnienia ramki.
8. Ustaw własny obraz dla utworzonego obiektu ramki zoomu sekcji.
9. Ustaw możliwość *powrotu do oryginalnego slajdu z połączonej sekcji*. 
11. Zmień format linii dla drugiego obiektu ramki zoomu.
12. Zmień czas trwania przejścia.
13. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod PHP pokazuje, jak zmienić formatowanie obiektu sekcji podsumowania Zoom:

```php
  $pres = new Presentation();
  try {
    # Dodaje nowy slajd do prezentacji
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Dodaje nową sekcję do prezentacji
    $pres->getSections()->addSection("Section 1", $slide);
    # Dodaje nowy slajd do prezentacji
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Dodaje nową sekcję do prezentacji
    $pres->getSections()->addSection("Section 2", $slide);
    # Dodaje obiekt SummaryZoomFrame
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # Pobiera pierwszy obiekt SummaryZoomSection
    $summarySection = $summaryZoomFrame->getSummaryZoomCollection()->get_Item(0);
    # Formatowanie obiektu SummaryZoomSection
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($picture);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $summarySection->setImage($picture);
    $summarySection->setReturnToParent(false);
    $summarySection->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $summarySection->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->black);
    $summarySection->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $summarySection->getLineFormat()->setWidth(1.5);
    $summarySection->setTransitionDuration(1.5);
    # Zapisuje prezentację
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Czy mogę kontrolować powrót do slajdu „nadrzędnego” po wyświetleniu docelowego?**

Tak. Ramka [Zoom](https://reference.aspose.com/slides/pl/php-java/aspose.slides/zoomframe/) lub [section](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sectionzoomframe/) ma zachowanie `ReturnToParent`, które po włączeniu odsyła widzów z powrotem do slajdu początkowego po odwiedzeniu treści docelowej.

**Czy mogę dostosować „szybkość” lub czas trwania przejścia Zoom?**

Tak. Zoom obsługuje ustawienie `TransitionDuration`, dzięki czemu możesz kontrolować, jak długo trwa animacja skoku.

**Czy istnieją limity liczby obiektów Zoom, które prezentacja może zawierać?**

Nie ma twardo określonego limitu API w dokumentacji. Praktyczne ograniczenia zależą od ogólnej złożoności prezentacji i wydajności odtwarzacza. Możesz dodać wiele ramek Zoom, ale warto zwrócić uwagę na rozmiar pliku i czas renderowania.