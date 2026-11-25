---
title: Ogranicz edycję prezentacji za pomocą blokad kształtów w PHP
linktitle: Ogranicz edycję prezentacji
type: docs
weight: 60
url: /pl/php-java/applying-protection-to-presentation/
keywords:
- zapobiegać edycji
- chronić przed edycją
- blokada kształtu
- blokada pozycji
- blokada wyboru
- blokada zmiany rozmiaru
- blokada grupowania
- PowerPoint
- PPTX
- prezentacja
- PHP
- Aspose.Slides
description: "Dowiedz się, jak blokować i odblokowywać kształty w prezentacjach PPTX przy użyciu Aspose.Slides for PHP via Java, aby ograniczyć wybór, przemieszczanie, zmianę rozmiaru i grupowanie."
---
## **Przegląd**

Typowym zastosowaniem Aspose.Slides for PHP via Java jest tworzenie, aktualizowanie i zapisywanie prezentacji PowerPoint (PPTX) w ramach zautomatyzowanego przepływu pracy. Kiedy użytkownicy otrzymują te prezentacje, ograniczenie zmian kształtów może pomóc zachować zamierzony układ i treść.

Ten artykuł wyjaśnia, jak kształty są organizowane na slajdach oraz jak zastosować i usunąć blokady kształtów w prezentacji PPTX. Te blokady pozwalają ograniczyć określone operacje edycji na poszczególnych kształtach.

## **Kompozycja slajdu**

Slajd prezentacji składa się z elementów takich jak autokształty, tabele, obiekty OLE, grupowane kształty, ramki obrazów, ramki wideo, łączniki i inne elementy używane do budowy prezentacji. W Aspose.Slides for PHP via Java każdy element na slajdzie jest reprezentowany przez obiekt dziedziczący po klasie [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/).

Różne typy kształtów udostępniają różne opcje blokowania. Klasa [BaseShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/) jest klasą bazową dla blokad kształtów. Aspose.Slides for PHP via Java dostarcza następujące klasy blokad:

- [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/) blokuje autokształty.  
- [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) blokuje kształty łączników.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) blokuje obiekty graficzne.  
- [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/) blokuje grupowane kształty.  
- [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) blokuje ramki obrazów.  

Aby zastosować blokady w całej [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), przeiteruj slajdy i ustaw odpowiednie blokady dla każdego obsługiwanego kształtu.

## **Zastosowanie i usunięcie ochrony**

Kompatybilne edytory prezentacji używają blokad kształtów do ograniczania poszczególnych operacji edycji. Szyfrowanie plików i ochrona zapisu na poziomie dokumentu są oddzielnymi [presentation protection settings](/slides/pl/php-java/password-protected-presentation/).

### **Zastosowanie ochrony do kształtów PPTX**

Aspose.Slides for PHP via Java udostępnia klasę [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) do pracy z kształtami na slajdzie.

Przykład wywołuje [setSelectLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setPositionLocked) i [setSizeLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSizeLocked) z wartością `true` dla autokształtów, z równoważnymi blokadami dla grupowanych kształtów, łączników i ramek obrazów. Łączniki używają [setPositionMove](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/#setPositionMove) do ruchu; grupy również używają [setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) aby ograniczyć grupowanie.

Przykład wczytuje istniejącą prezentację PPTX, sprawdza kształty w kolekcji kształtów każdego slajdu i zapisuje kopię z zastosowanymi ograniczeniami. Kształty spoza czterech obsługiwanych typów pozostają niezmienione. Pętla nie przegląda kształtów podrzędnych wewnątrz grupy.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        foreach ($slide->getShapes()->toArray() as $shape) {
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setGroupingLocked(true);
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionMove(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            }
        }
    }

    $presentation->save("ProtectedSample.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Usunięcie ochrony**

Aby usunąć blokadę kształtu, ustaw jej wartość na `false`. Poniższy przykład wczytuje prezentację z blokadami kształtów i usuwa ograniczenia wyboru, ruchu i zmiany rozmiaru za pomocą [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/), oraz [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/). Usuwa również ograniczenie grupowania, przekazując `false` do [GroupShapeLock::setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) i zapisuje kopię prezentacji. Pozostałe ustawienia blokad pozostają niezmienione.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("ProtectedSample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        foreach ($slide->getShapes()->toArray() as $shape) {
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setGroupingLocked(false);
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionMove(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            }
        }
    }

    $presentation->save("RemovedProtectionSample.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Zachowanie przycięcia obrazu**

Umieść zdjęcie o nazwie `photo.jpg` w katalogu roboczym. Przykład przycina 12 % od lewej i 8 % od prawej, a następnie wywołuje [setCropLocked](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/#setCropLocked) na blokadzie ramki obrazu. Przekazanie `true` ogranicza dalsze przycinanie i zachowuje istniejące przycięcie.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    $image = Images::fromFile("photo.jpg");
    try {
        $photo = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $pictureFrame = $shapes->addPictureFrame(ShapeType::Rectangle, 20, 30, 270, 160, $photo);
    $pictureFrame->getPictureFormat()->setCropLeft(12);
    $pictureFrame->getPictureFormat()->setCropRight(8);

    $pictureFrameLock = $pictureFrame->getPictureFrameLock();
    $pictureFrameLock->setAspectRatioLocked(false);
    $pictureFrameLock->setCropLocked(true);

    $presentation->save("PictureLocked.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`PictureLocked.pptx` przechowuje blokadę przycięcia jako `true`. W programie PowerPoint polecenie **Crop** jest wyłączone, gdy zdjęcie jest zaznaczone.

### **Utrzymanie diagramu w grupie**

Przykład grupuje prostokąt i strzałkę, a następnie wywołuje [setUngroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setUngroupingLocked) na blokadzie grupy, aby utrzymać elementy diagramu razem. Inne edycje, takie jak przemieszczanie grupy czy zmiana wypełnienia komponentu, pozostają dostępne.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    
    $groupShape = $shapes->addGroupShape();
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 70, 90, 50);
    $groupShape->getShapes()->addAutoShape(ShapeType::RightArrow, 190, 80, 60, 30);
    $groupShape->getGroupShapeLock()->setUngroupingLocked(true);

    $presentation->save("DiagramLocked.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`DiagramLocked.pptx` przechowuje blokadę rozgrupowania jako `true`. W PowerPoint polecenie **Ungroup** jest wyłączone, gdy cały diagram jest zaznaczony.

### **Raport istniejących blokad kształtów**

Aby przejrzeć szablon, otwórz go i odczytaj obiekt blokady dla każdego kształtu. Metoda [getNoLocks](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/#getNoLocks) zwraca `true`, gdy wszystkie flagi w tym obiekcie są wyłączone i `false`, gdy przynajmniej jedna jest włączona. Grupa i jej elementy potomne mają oddzielne obiekty blokad, więc sprawdzaj potomków nawet gdy grupa nie ma blokad.

Ten przykład sprawdza ruch dla autokształtów, ramek obrazów i grup. Sprawdza również przycięcie dla obrazów oraz rozgrupowanie dla grup. Raport wymienia rozpoznane włączone flagi i oznacza typy kształtów, których nie sprawdza.

```php
use aspose\slides\Presentation;

function reportShapeLocks($shapes, $slideNumber, $prefix = "") {
    foreach ($shapes->toArray() as $shape) {
        $path = $prefix . java_values($shape->getName());
        $type = java_values($shape->getClass()->getSimpleName());
        $label = "Slide $slideNumber | $path | $type";
        $flags = [];
        $isGroup = java_instanceof($shape, java("com.aspose.slides.IGroupShape"));

        if ($isGroup) {
            $lock = $shape->getGroupShapeLock();
            if (java_values($lock->getUngroupingLocked())) {
                $flags[] = "UngroupingLocked";
            }
        } elseif (java_instanceof($shape, java("com.aspose.slides.IPictureFrame"))) {
            $lock = $shape->getPictureFrameLock();
            if (java_values($lock->getCropLocked())) {
                $flags[] = "CropLocked";
            }
        } elseif (java_instanceof($shape, java("com.aspose.slides.IAutoShape"))) {
            $lock = $shape->getAutoShapeLock();
        } else {
            echo "$label | Uninspected", PHP_EOL;
            continue;
        }

        if (java_values($lock->getPositionLocked())) {
            $flags[] = "PositionLocked";
        }
        if (!java_values($lock->getNoLocks())) {
            $restrictions = $flags ? implode(", ", $flags) : "Active flag not identified";
            echo "$label | $restrictions", PHP_EOL;
        }

        if ($isGroup) {
            reportShapeLocks($shape->getShapes(), $slideNumber, $path . "/");
        }
    }
}

$presentation = new Presentation("Sample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        reportShapeLocks($slide->getShapes(), java_values($slide->getSlideNumber()));
    }
} finally {
    $presentation->dispose();
}
```

Załóżmy, że slajd 1 w `Sample.pptx` zawiera grupę o nazwie `Layout` z zablokowanym rozgrupowaniem, obraz o nazwie `Photo` wewnątrz niej z zablokowanym przycięciem oraz odblokowany prostokąt o nazwie `Free`. Raport pomija `Free` i wypisuje te dwie linie:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Raport odczytuje zapisane flagi edycji na poziomie kształtu bez ich zmieniania ani zapisywania prezentacji. Ochrona zapisu na poziomie dokumentu jest oddzielnym ustawieniem, a egzekwowanie każdej flagi zależy od edytora.

## **Podsumowanie**

Aspose.Slides for PHP via Java umożliwia ograniczenie konkretnych operacji edycji na pojedynczych kształtach lub zastosowanie tych samych ograniczeń na wszystkich slajdach. Wybierz blokady obsługiwane przez dany typ kształtu i ustaw ich wartości na `false`, gdy potrzebujesz usunąć te ograniczenia.

## **FAQ**

**Czy mogę łączyć blokady kształtów i ochronę hasłem w tej samej prezentacji?**

Tak. Blokady kształtów ograniczają konkretne operacje edycji, podczas gdy [password protection](/slides/pl/php-java/password-protected-presentation/) może ograniczyć otwieranie lub modyfikowanie prezentacji. Możesz używać obu w tym samym pliku.

**Czy mogę ograniczyć edycję na konkretnych slajdach bez wpływu na inne?**

Tak. Zastosuj blokady wyłącznie do kształtów na wybranych slajdach. Nie zmienia to ustawień blokad na pozostałych slajdach.

**Jak mogę zastosować blokady do poszczególnych kształtów wewnątrz grupy?**

Iteruj przez kolekcję zwróconą przez metodę [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) grupy i zastosuj odpowiednie blokady do każdego kształtu podrzędnego. Powtórz to dla wszelkich zagnieżdżonych grup, postępując zgodnie z przebiegiem opisanym w przykładzie raportu.