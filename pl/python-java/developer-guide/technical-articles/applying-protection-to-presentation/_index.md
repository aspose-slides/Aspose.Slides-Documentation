---
title: Zapobiegaj edycji prezentacji przy użyciu blokad kształtów
linktitle: Zapobiegaj edycji prezentacji
type: docs
weight: 60
url: /pl/python-java/applying-protection-to-presentation/
keywords:
- zapobiegaj edycji
- ochrona przed edycją
- zablokuj kształt
- zablokuj pozycję
- zablokuj zaznaczanie
- zablokuj rozmiar
- zablokuj grupowanie
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Dowiedz się, jak Aspose.Slides for Python via Java blokuje lub odblokowuje kształty w plikach PPT, PPTX i ODP, zabezpieczając prezentacje przy jednoczesnym umożliwieniu kontrolowanych edycji i szybszego dostarczania."
---
## **Tło**

Częstym zastosowaniem Aspose.Slides jest tworzenie, aktualizowanie i zapisywanie prezentacji Microsoft PowerPoint (PPTX) w ramach zautomatyzowanego przepływu pracy. Użytkownicy aplikacji wykorzystujących Aspose.Slides w ten sposób mają dostęp do wygenerowanych prezentacji, więc ochrona ich przed edycją jest powszechnym problemem. Ważne jest, aby automatycznie generowane prezentacje zachowywały pierwotne formatowanie i treść.

Ten artykuł wyjaśnia, jak zbudowane są prezentacje i slajdy oraz jak Aspose.Slides for Python via Java może zastosować ochronę do prezentacji i później ją usunąć. Dostarcza programistom sposób kontrolowania, w jaki sposób prezentacje generowane przez ich aplikacje są używane.

## **Skład slajdu**

Slajd prezentacji składa się z elementów takich jak autokształty, tabele, obiekty OLE, grupowane kształty, ramki obrazu, ramki wideo, łączniki i inne elementy używane do budowy prezentacji. W Aspose.Slides for Python via Java każdy element na slajdzie jest reprezentowany przez obiekt dziedziczący po klasie [Shape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/) .

Struktura pliku PPTX jest skomplikowana, dlatego w przeciwieństwie do PPT, gdzie można użyć ogólnej blokady dla wszystkich typów kształtów, różne typy kształtów wymagają różnych blokad. Klasa [BaseShapeLock](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseshapelock/) jest ogólną klasą blokującą dla PPTX. Następujące typy blokad są obsługiwane w Aspose.Slides for Python via Java dla PPTX:

- [AutoShapeLock](https://reference.aspose.com/slides/pl/python-java/aspose.slides/autoshapelock/) blokuje autokształty.  
- [ConnectorLock](https://reference.aspose.com/slides/pl/python-java/aspose.slides/connectorlock/) blokuje kształty łączników.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/pl/python-java/aspose.slides/graphicalobjectlock/) blokuje obiekty graficzne.  
- [GroupShapeLock](https://reference.aspose.com/slides/pl/python-java/aspose.slides/groupshapelock/) blokuje grupowane kształty.  
- [PictureFrameLock](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pictureframelock/) blokuje ramki obrazu.  

Każde działanie wykonane na wszystkich obiektach kształtów w obiekcie [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) jest stosowane do całej prezentacji.

## **Zastosowanie i usunięcie ochrony**

Zastosowanie ochrony zapewnia, że prezentacja nie może być edytowana. Jest to przydatna technika ochrony zawartości prezentacji.

### **Zastosuj ochronę do kształtów PPTX**

Aspose.Slides for Python via Java udostępnia klasę [Shape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/) do pracy z kształtami na slajdzie.

Jak wspomniano wcześniej, każda klasa kształtu ma powiązaną klasę blokady kształtu służącą do ochrony. Ten artykuł koncentruje się na blokadach NoSelect, NoMove i NoResize. Blokady te zapewniają, że kształty nie mogą być zaznaczane (za pomocą kliknięć myszy lub innych metod zaznaczania) oraz że nie mogą być przenoszone ani zmieniane rozmiarowo.

Poniższy przykład kodu stosuje ochronę do wszystkich typów kształtów w prezentacji.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

# Utwórz instancję klasy Presentation, która reprezentuje plik PPTX.
presentation = Presentation("Sample.pptx")
try:
    # Przejdź po wszystkich slajdach w prezentacji.
    for slide in presentation.getSlides():
        # Przejdź po wszystkich kształtach na slajdzie.
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                auto_shape_lock = shape.getShapeLock()
                auto_shape_lock.setPositionLocked(True)
                auto_shape_lock.setSelectLocked(True)
                auto_shape_lock.setSizeLocked(True)
            elif isinstance(shape, GroupShape):
                group_shape_lock = shape.getShapeLock()
                group_shape_lock.setGroupingLocked(True)
                group_shape_lock.setPositionLocked(True)
                group_shape_lock.setSelectLocked(True)
                group_shape_lock.setSizeLocked(True)
            elif isinstance(shape, Connector):
                connector_shape_lock = shape.getShapeLock()
                connector_shape_lock.setPositionMove(True)
                connector_shape_lock.setSelectLocked(True)
                connector_shape_lock.setSizeLocked(True)
            elif isinstance(shape, PictureFrame):
                picture_frame_lock = shape.getShapeLock()
                picture_frame_lock.setPositionLocked(True)
                picture_frame_lock.setSelectLocked(True)
                picture_frame_lock.setSizeLocked(True)

    # Zapisz plik prezentacji.
    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Usuń ochronę**

Aby odblokować kształt, ustaw wartość zastosowanej blokady na `False`. Poniższy przykład kodu pokazuje, jak odblokować kształty w zablokowanej prezentacji.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

# Utwórz instancję klasy Presentation, która reprezentuje plik PPTX.
presentation = Presentation("ProtectedSample.pptx")
try:
    # Przejdź po wszystkich slajdach w prezentacji.
    for slide in presentation.getSlides():
        # Przejdź po wszystkich kształtach na slajdzie.
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                auto_shape_lock = shape.getShapeLock()
                auto_shape_lock.setPositionLocked(False)
                auto_shape_lock.setSelectLocked(False)
                auto_shape_lock.setSizeLocked(False)
            elif isinstance(shape, GroupShape):
                group_shape_lock = shape.getShapeLock()
                group_shape_lock.setGroupingLocked(False)
                group_shape_lock.setPositionLocked(False)
                group_shape_lock.setSelectLocked(False)
                group_shape_lock.setSizeLocked(False)
            elif isinstance(shape, Connector):
                connector_shape_lock = shape.getShapeLock()
                connector_shape_lock.setPositionMove(False)
                connector_shape_lock.setSelectLocked(False)
                connector_shape_lock.setSizeLocked(False)
            elif isinstance(shape, PictureFrame):
                picture_frame_lock = shape.getShapeLock()
                picture_frame_lock.setPositionLocked(False)
                picture_frame_lock.setSelectLocked(False)
                picture_frame_lock.setSizeLocked(False)

    # Zapisz plik prezentacji.
    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Podsumowanie**

Aspose.Slides oferuje kilka opcji ochrony kształtów w prezentacji. Można zablokować pojedynczy kształt lub przeiterować wszystkie kształty w prezentacji i zablokować każdy z nich, aby skutecznie zabezpieczyć cały plik. Ochronę można usunąć, ustawiając wartość blokady na `False`.

## **FAQ**

**Czy mogę połączyć blokady kształtów i ochronę hasłem w tej samej prezentacji?**

Tak. Blokady ograniczają edycję obiektów wewnątrz pliku, podczas gdy [ochrona hasłem](/slides/pl/python-java/password-protected-presentation/) kontroluje dostęp do otwierania i/lub zapisywania zmian. Mechanizmy te uzupełniają się nawzajem i współdziałają.

**Czy mogę ograniczyć edycję na konkretnych slajdach bez wpływu na inne?**

Tak. Zastosuj blokady do kształtów na wybranych slajdach; pozostałe slajdy pozostaną edytowalne.

**Czy blokady kształtów dotyczą obiektów grupowanych i łączników?**

Tak. Dedykowane typy blokad są obsługiwane dla grup, łączników, obiektów graficznych i innych rodzajów kształtów.