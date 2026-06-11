---
title: Zapobiegaj edycjom prezentacji za pomocą blokad kształtów w Pythonie
linktitle: Zapobiegaj edycjom prezentacji
type: docs
weight: 70
url: /pl/python-net/applying-protection-to-presentation/
keywords:
- zapobieganie edycjom
- ochrona przed edycją
- blokada kształtu
- blokada pozycji
- blokada zaznaczania
- blokada rozmiaru
- blokada grupowania
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Dowiedz się, jak Aspose.Slides for Python via .NET blokuje lub odblokowuje kształty w plikach PPT, PPTX i ODP, zabezpieczając prezentacje, jednocześnie umożliwiając kontrolowane edycje i szybsze dostarczanie."
---
## **Tło**

Typowym zastosowaniem Aspose.Slides jest tworzenie, aktualizacja i zapisywanie prezentacji Microsoft PowerPoint (PPTX) w ramach zautomatyzowanego przepływu pracy. Użytkownicy aplikacji wykorzystujących Aspose.Slides w ten sposób mają dostęp do wygenerowanych prezentacji, dlatego ochrona ich przed edycją jest powszechnym zagadnieniem. Ważne jest, aby automatycznie generowane prezentacje zachowały pierwotne formatowanie i treść.

Ten artykuł wyjaśnia, jak zbudowane są prezentacje i slajdy oraz jak Aspose.Slides for Python może zastosować ochronę do prezentacji i później ją usunąć. Dostarcza programistom sposób na kontrolowanie sposobu wykorzystywania prezentacji generowanych przez ich aplikacje.

## **Budowa slajdu**

Slajd prezentacji składa się z komponentów, takich jak autokształty, tabele, obiekty OLE, grupowane kształty, ramki obrazów, ramki wideo, łączniki i inne elementy używane do tworzenia prezentacji. W Aspose.Slides for Python każdy element na slajdzie jest reprezentowany przez obiekt dziedziczący po klasie [Shape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/).

Struktura pliku PPTX jest złożona, dlatego w przeciwieństwie do PPT, gdzie można użyć ogólnego blokowania dla wszystkich typów kształtów, różne typy kształtów wymagają różnych blokad. Klasa [BaseShapeLock](https://reference.aspose.com/slides/pl/python-net/aspose.slides/baseshapelock/) jest ogólną klasą blokującą dla PPTX. W Aspose.Slides for Python dla PPTX obsługiwane są następujące typy blokad:

- [AutoShapeLock](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshapelock/) blokuje autokształty.  
- [ConnectorLock](https://reference.aspose.com/slides/pl/python-net/aspose.slides/connectorlock/) blokuje kształty łączników.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/pl/python-net/aspose.slides/graphicalobjectlock/) blokuje obiekty graficzne.  
- [GroupShapeLock](https://reference.aspose.com/slides/pl/python-net/aspose.slides/groupshapelock/) blokuje grupowane kształty.  
- [PictureFrameLock](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pictureframelock/) blokuje ramki obrazów.  

Każda akcja wykonana na wszystkich obiektach kształtów w obiekcie [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) jest stosowana do całej prezentacji.

## **Zastosowanie i usunięcie ochrony**

Zastosowanie ochrony zapewnia, że prezentacja nie może być edytowana. Jest to przydatna technika ochrony treści prezentacji.

### **Zastosowanie ochrony do kształtów PPTX**

Aspose.Slides for Python udostępnia klasę [Shape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/) do pracy z kształtami na slajdzie.

Jak wspomniano wcześniej, każda klasa kształtu ma powiązaną klasę blokady kształtu służącą do ochrony. W tym artykule skupiamy się na blokadach NoSelect, NoMove i NoResize. Blokady te zapewniają, że kształty nie mogą być zaznaczane (za pomocą kliknięć myszy lub innych metod zaznaczania) oraz nie mogą być przemieszczane ani zmieniane rozmiarowo.

Poniższy przykład kodu stosuje ochronę do wszystkich typów kształtów w prezentacji.

```py
import aspose.slides as slides

# Utwórz instancję klasy Presentation reprezentującej plik PPTX.
with slides.Presentation("Sample.pptx") as presentation:
    # Przeglądanie wszystkich slajdów w prezentacji.
    for slide in presentation.slides:
        # Przeglądanie wszystkich kształtów na slajdzie.
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.GroupShape:
                shape.shape_lock.grouping_locked = True
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.Connector:
                shape.shape_lock.position_move = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.PictureFrame:
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
    # Zapisanie pliku prezentacji.
    presentation.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```

### **Usunięcie ochrony**

Aby odblokować kształt, ustaw wartość zastosowanej blokady na `False`. Poniższy przykład kodu pokazuje, jak odblokować kształty w zablokowanej prezentacji.

```py
import aspose.slides as slides

# Utwórz instancję klasy Presentation, która reprezentuje plik PPTX.
with slides.Presentation("ProtectedSample.pptx") as presentation:
    # Przeglądanie wszystkich slajdów w prezentacji.
    for slide in presentation.slides:
        # Przeglądanie wszystkich kształtów na slajdzie.
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.GroupShape:
                shape.shape_lock.grouping_locked = False
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.Connector:
                shape.shape_lock.position_move = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.PictureFrame:
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
    # Zapisanie pliku prezentacji.
    presentation.save("RemovedProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```

### **Wnioski**

Aspose.Slides oferuje kilka opcji ochrony kształtów w prezentacji. Możesz zablokować pojedynczy kształt lub przejść przez wszystkie kształty w prezentacji i zablokować każdy z nich, aby skutecznie zabezpieczyć cały plik. Ochronę można usunąć, ustawiając wartość blokady na `False`.

## **FAQ**

**Czy mogę łączyć blokady kształtów i ochronę hasłem w tej samej prezentacji?**

Tak. Blokady ograniczają edycję obiektów w pliku, podczas gdy [password protection](/slides/pl/python-net/password-protected-presentation/) kontroluje dostęp do otwierania i/lub zapisywania zmian. Mechanizmy te uzupełniają się nawzajem i działają razem.

**Czy mogę ograniczyć edycję na konkretnych slajdach bez wpływu na pozostałe?**

Tak. Zastosuj blokady do kształtów na wybranych slajdach; pozostałe slajdy pozostaną edytowalne.

**Czy blokady kształtów dotyczą grupowanych obiektów i łączników?**

Tak. Dedykowane typy blokad są obsługiwane dla grup, łączników, obiektów graficznych i innych rodzajów kształtów.