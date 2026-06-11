---
title: Zapobiegaj edycji prezentacji przy użyciu blokad kształtów
linktitle: Zapobiegaj edycji prezentacji
type: docs
weight: 60
url: /pl/java/applying-protection-to-presentation/
keywords:
- zapobiegaj edycjom
- ochrona przed edycją
- blokada kształtu
- blokada pozycji
- blokada wyboru
- blokada rozmiaru
- blokada grupowania
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Odkryj, jak Aspose.Slides for Java blokuje lub odblokowuje kształty w plikach PPT, PPTX i ODP, zabezpieczając prezentacje, jednocześnie umożliwiając kontrolowane edycje i szybsze dostarczanie."
---
## **Tło**

Typowym zastosowaniem Aspose.Slides jest tworzenie, aktualizowanie i zapisywanie prezentacji Microsoft PowerPoint (PPTX) w ramach zautomatyzowanego przepływu pracy. Użytkownicy aplikacji wykorzystujących Aspose.Slides w ten sposób mają dostęp do wygenerowanych prezentacji, więc ochrona ich przed edycją jest powszechnym problemem. Ważne jest, aby automatycznie generowane prezentacje zachowały swoje pierwotne formatowanie i zawartość.

Ten artykuł wyjaśnia, jak zbudowane są prezentacje i slajdy oraz jak Aspose.Slides for Java może zastosować ochronę do prezentacji i później ją usunąć. Dostarcza programistom sposób kontrolowania sposobu wykorzystania prezentacji generowanych przez ich aplikacje.

## **Kompozycja slajdu**

Slajd prezentacji składa się z elementów takich jak autokształty, tabele, obiekty OLE, grupowane kształty, ramki obrazu, ramki wideo, łączniki i inne elementy używane do budowy prezentacji. W Aspose.Slides for Java każdy element na slajdzie jest reprezentowany przez obiekt implementujący interfejs [IShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/) lub dziedziczący po klasie, która to robi.

Struktura pliku PPTX jest złożona, więc w przeciwieństwie do PPT, gdzie można używać uniwersalnej blokady dla wszystkich typów kształtów, różne typy kształtów wymagają różnych blokad. Interfejs [IBaseShapeLock](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibaseshapelock/) jest ogólną klasą blokującą dla PPTX. Następujące typy blokad są obsługiwane w Aspose.Slides for Java dla PPTX:

- [IAutoShapeLock](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshapelock/) blokuje autokształty.  
- [IConnectorLock](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iconnectorlock/) blokuje kształty łączników.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/pl/java/com.aspose.slides/igraphicalobjectlock/) blokuje obiekty graficzne.  
- [IGroupShapeLock](https://reference.aspose.com/slides/pl/java/com.aspose.slides/igroupshapelock/) blokuje grupowane kształty.  
- [IPictureFrameLock](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipictureframelock/) blokuje ramki obrazu.  

Każde działanie wykonane na wszystkich obiektach kształtów w obiekcie [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) jest stosowane do całej prezentacji.

## **Zastosowanie i usunięcie ochrony**

Zastosowanie ochrony zapewnia, że prezentacja nie może być edytowana. Jest to przydatna technika ochrony zawartości prezentacji.

### **Zastosuj ochronę do kształtów PPTX**

Aspose.Slides for Java udostępnia interfejs [IShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/) do pracy z kształtami na slajdzie.

Jak wspomniano wcześniej, każda klasa kształtu ma powiązaną klasę blokady kształtu służącą do ochrony. Ten artykuł koncentruje się na blokadach NoSelect, NoMove i NoResize. Blokady te zapewniają, że kształty nie mogą być wybierane (poprzez kliknięcia myszy lub inne metody zaznaczania) oraz że nie mogą być przemieszczane ani zmieniane rozmiarowo.

Poniższy przykład kodu stosuje ochronę do wszystkich typów kształtów w prezentacji.

```java
// Utwórz obiekt klasy Presentation reprezentujący plik PPTX.
Presentation presentation = new Presentation("Sample.pptx");

// Przeglądanie wszystkich slajdów w prezentacji.
for (ISlide slide : presentation.getSlides()) {

    // Przeglądanie wszystkich kształtów na slajdzie.
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAutoShape) {
            // Rzutowanie kształtu na autokształt i pobranie jego blokady kształtu.
            IAutoShape autoShape = (IAutoShape) shape;
            IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();

            autoShapeLock.setPositionLocked(true);
            autoShapeLock.setSelectLocked(true);
            autoShapeLock.setSizeLocked(true);
        } else if (shape instanceof IGroupShape) {
            // Rzutowanie kształtu na grupę kształtów i pobranie jej blokady kształtu.
            IGroupShape groupShape = (IGroupShape) shape;
            IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();

            groupShapeLock.setGroupingLocked(true);
            groupShapeLock.setPositionLocked(true);
            groupShapeLock.setSelectLocked(true);
            groupShapeLock.setSizeLocked(true);
        } else if (shape instanceof IConnector) {
            // Rzutowanie kształtu na łącznik i pobranie jego blokady kształtu.
            IConnector connectorShape = (IConnector) shape;
            IConnectorLock connectorShapeLock = connectorShape.getShapeLock();

            connectorShapeLock.setPositionMove(true);
            connectorShapeLock.setSelectLocked(true);
            connectorShapeLock.setSizeLocked(true);
        } else if (shape instanceof IPictureFrame) {
            // Rzutowanie kształtu na ramkę obrazu i pobranie jej blokady kształtu.
            IPictureFrame pictureFrame = (IPictureFrame) shape;
            IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();

            pictureFrameLock.setPositionLocked(true);
            pictureFrameLock.setSelectLocked(true);
            pictureFrameLock.setSizeLocked(true);
        }
    }
}

// Zapisywanie pliku prezentacji.
presentation.save("ProtectedSample.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Usuń ochronę**

Aby odblokować kształt, ustaw wartość zastosowanej blokady na `false`. Poniższy przykład kodu pokazuje, jak odblokować kształty w zablokowanej prezentacji.

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik PPTX.
Presentation presentation = new Presentation("ProtectedSample.pptx");

// Przeglądanie wszystkich slajdów w prezentacji.
for (ISlide slide : presentation.getSlides()) {

    // Przeglądanie wszystkich kształtów na slajdzie.
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAutoShape) {
            // Rzutowanie kształtu na autokształt i pobranie jego blokady kształtu.
            IAutoShape autoShape = (IAutoShape) shape;
            IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();

            autoShapeLock.setPositionLocked(false);
            autoShapeLock.setSelectLocked(false);
            autoShapeLock.setSizeLocked(false);
        } else if (shape instanceof IGroupShape) {
            // Rzutowanie kształtu na grupę kształtów i pobranie jej blokady kształtu.
            IGroupShape groupShape = (IGroupShape) shape;
            IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();

            groupShapeLock.setGroupingLocked(false);
            groupShapeLock.setPositionLocked(false);
            groupShapeLock.setSelectLocked(false);
            groupShapeLock.setSizeLocked(false);
        } else if (shape instanceof IConnector) {
            // Rzutowanie kształtu na łącznik i pobranie jego blokady kształtu.
            IConnector connectorShape = (IConnector) shape;
            IConnectorLock connectorShapeLock = connectorShape.getShapeLock();

            connectorShapeLock.setPositionMove(false);
            connectorShapeLock.setSelectLocked(false);
            connectorShapeLock.setSizeLocked(false);
        } else if (shape instanceof IPictureFrame) {
            // Rzutowanie kształtu na ramkę obrazu i pobranie jej blokady kształtu.
            IPictureFrame pictureFrame = (IPictureFrame) shape;
            IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();

            pictureFrameLock.setPositionLocked(false);
            pictureFrameLock.setSelectLocked(false);
            pictureFrameLock.setSizeLocked(false);
        }
    }
}

// Zapisywanie pliku prezentacji.
presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Podsumowanie**

Aspose.Slides oferuje kilka opcji ochrony kształtów w prezentacji. Możesz zablokować pojedynczy kształt lub przeiterować wszystkie kształty w prezentacji i zablokować każdy z nich, aby skutecznie zabezpieczyć cały plik. Ochronę możesz usunąć, ustawiając wartość blokady na `false`.

## **FAQ**

**Czy mogę łączyć blokady kształtów i ochronę hasłem w tej samej prezentacji?**

Tak. Blokady ograniczają edycję obiektów wewnątrz pliku, podczas gdy [ochrona hasłem](/slides/pl/java/password-protected-presentation/) kontroluje dostęp do otwierania i/lub zapisywania zmian. Mechanizmy te uzupełniają się nawzajem i współpracują.

**Czy mogę ograniczyć edycję na konkretnych slajdach bez wpływu na pozostałe?**

Tak. Zastosuj blokady do kształtów na wybranych slajdach; pozostałe slajdy pozostaną edytowalne.

**Czy blokady kształtów dotyczą grupowanych obiektów i łączników?**

Tak. Dedykowane typy blokad są obsługiwane dla grup, łączników, obiektów graficznych i innych rodzajów kształtów.