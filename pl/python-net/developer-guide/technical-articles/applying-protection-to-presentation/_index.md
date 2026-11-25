---
title: Ogranicz edycję prezentacji przy użyciu blokad kształtów w Pythonie
linktitle: Ogranicz edycję prezentacji
type: docs
weight: 70
url: /pl/python-net/applying-protection-to-presentation/
keywords:
- zapobiegać edycji
- chronić przed edycją
- zablokować kształt
- zablokować pozycję
- zablokować zaznaczanie
- zablokować zmianę rozmiaru
- zablokować grupowanie
- PowerPoint
- PPTX
- prezentacja
- Python
- Aspose.Slides
description: "Dowiedz się, jak blokować i odblokowywać kształty w prezentacjach PPTX przy użyciu Aspose.Slides for Python via .NET, aby ograniczyć zaznaczanie, przemieszczanie, zmianę rozmiaru i grupowanie."
---
## **Tło**

Typowym zastosowaniem Aspose.Slides for Python via .NET jest tworzenie, aktualizowanie i zapisywanie prezentacji PowerPoint (PPTX) w ramach zautomatyzowanego przepływu pracy. Gdy użytkownicy otrzymują te prezentacje, ograniczenie zmian kształtów może pomóc zachować zamierzony układ i zawartość.

Ten artykuł wyjaśnia, jak kształty są organizowane na slajdach oraz jak zastosować i usunąć blokady kształtów w prezentacji PPTX. Te blokady umożliwiają ograniczenie konkretnych operacji edycji na poszczególnych kształtach.

## **Kompozycja slajdu**

Slajd prezentacji składa się z elementów takich jak autokształty, tabele, obiekty OLE, grupowane kształty, ramki obrazów, ramki wideo, łączniki oraz inne elementy używane do budowy prezentacji. W Aspose.Slides for Python via .NET każdy element na slajdzie jest reprezentowany przez obiekt dziedziczący po klasie [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/).

Różne typy kształtów udostępniają różne opcje blokowania. Klasa [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) jest klasą bazową dla blokad kształtów. Aspose.Slides for Python via .NET zapewnia następujące klasy blokad:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) blokuje autokształty.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) blokuje kształty łączników.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) blokuje obiekty graficzne.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) blokuje grupowane kształty.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) blokuje ramki obrazów.  

Aby zastosować blokady w całej [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), iteruj przez jej slajdy i ustaw odpowiednie blokady na każdym obsługiwanym kształcie.

## **Zastosowanie i usunięcie ochrony**

Zgodne edytory prezentacji używają blokad kształtów, aby ograniczyć poszczególne operacje edycji. Szyfrowanie plików i ochrona przed zapisem na poziomie dokumentu są odrębnymi [ustawieniami ochrony prezentacji](/slides/pl/python-net/password-protected-presentation/).

### **Zastosowanie ochrony do kształtów PPTX**

Aspose.Slides for Python via .NET udostępnia klasę [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/), aby pracować z kształtami na slajdzie.

W przykładzie ustawiono [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/), [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/) i [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) na `True` dla autokształtów, z równoważnymi blokadami dla grupowanych kształtów, łączników i ramek obrazów. Łączniki używają [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) do przemieszczania; grupy także używają [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) aby ograniczyć grupowanie.

Przykład ładuje istniejącą prezentację PPTX, sprawdza kształty w kolekcji kształtów każdego slajdu i zapisuje kopię z zastosowanymi ograniczeniami. Kształty spoza czterech obsługiwanych typów pozostają niezmienione. Pętla nie przegląda kształtów podrzędnych wewnątrz grupy.

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.GroupShape):
                shape.shape_lock.grouping_locked = True
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.Connector):
                shape.shape_lock.position_move = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.PictureFrame):
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True

    presentation.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```

### **Usunięcie ochrony**

Aby usunąć blokadę kształtu, ustaw jej wartość na `False`. Poniższy przykład ładuje prezentację z blokadami kształtów i usuwa ograniczenia zaznaczania, przemieszczania i zmiany rozmiaru za pomocą [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/), oraz [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/). Czyści także [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) i zapisuje kopię prezentacji. Inne ustawienia blokad pozostają niezmienione.

```python
import aspose.slides as slides

with slides.Presentation("ProtectedSample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.GroupShape):
                shape.shape_lock.grouping_locked = False
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.Connector):
                shape.shape_lock.position_move = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.PictureFrame):
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False

    presentation.save("RemovedProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```

### **Zachowanie przycięcia obrazu**

Umieść zdjęcie o nazwie `photo.jpg` w katalogu roboczym. Przykład przycina 12 % z lewej i 8 % z prawej, a następnie ustawia [crop_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/crop_locked/) na ramce obrazu. Ta flaga ogranicza dalsze przycinanie i zachowuje istniejące przycięcie.

```python
from pathlib import Path

import aspose.slides as slides

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes

    photo_bytes = Path("photo.jpg").read_bytes()
    photo = presentation.images.add_image(photo_bytes)

    picture_frame = shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 30, 270, 160, photo)
    picture_frame.picture_format.crop_left = 12
    picture_frame.picture_format.crop_right = 8
    picture_frame.shape_lock.aspect_ratio_locked = False
    picture_frame.shape_lock.crop_locked = True

    presentation.save("PictureLocked.pptx", slides.export.SaveFormat.PPTX)
```

`PictureLocked.pptx` zapisuje blokadę przycięcia jako `True`. W programie PowerPoint polecenie **Crop** jest wyłączone, gdy zdjęcie jest zaznaczone.

### **Utrzymanie diagramu w grupie**

Przykład grupuje prostokąt i strzałkę, a następnie ustawia [ungrouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/ungrouping_locked/) na samej grupie, aby utrzymać elementy diagramu razem. Inne edycje, takie jak przemieszczanie grupy czy zmiana wypełnienia elementu, pozostają dostępne.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes
    
    group_shape = shapes.add_group_shape()
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 70, 90, 50)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RIGHT_ARROW, 190, 80, 60, 30)
    group_shape.shape_lock.ungrouping_locked = True

    presentation.save("DiagramLocked.pptx", slides.export.SaveFormat.PPTX)
```

`DiagramLocked.pptx` zapisuje blokadę rozgrupowania jako `True`. W programie PowerPoint polecenie **Ungroup** jest wyłączone, gdy cały diagram jest zaznaczony.

### **Raportowanie istniejących blokad kształtów**

Aby przejrzeć szablon, otwórz go i odczytaj obiekt blokady dla każdego kształtu. [no_locks](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/no_locks/) jest `True`, gdy wszystkie flagi w tym obiekcie są wyłączone i `False`, gdy przynajmniej jedna jest włączona. Grupa i jej elementy mają osobne obiekty blokad, więc należy sprawdzić elementy podrzędne, nawet gdy grupa nie ma blokad.

Ten przykład sprawdza przemieszczanie autokształtów, ramek obrazów i grup, przycinanie obrazów oraz rozgrupowywanie grup. Raportuje rozpoznane flagi i oznacza typy kształtów, których nie sprawdza.

```python
import aspose.slides as slides


def inspect_shapes(shapes, slide_number, prefix=""):
    for shape in shapes:
        path = prefix + shape.name
        label = f"Slide {slide_number} | {path} | {type(shape).__name__}"
        if not isinstance(shape, (slides.GroupShape, slides.PictureFrame, slides.AutoShape)):
            print(f"{label} | Uninspected")
            continue

        shape_lock = shape.shape_lock
        if not shape_lock.no_locks:
            flags = []
            if isinstance(shape, slides.GroupShape) and shape_lock.ungrouping_locked:
                flags.append("ungrouping_locked")
            if isinstance(shape, slides.PictureFrame) and shape_lock.crop_locked:
                flags.append("crop_locked")
            if shape_lock.position_locked:
                flags.append("position_locked")
            restrictions = ", ".join(flags) if flags else "Active flag not identified"
            print(f"{label} | {restrictions}")

        if isinstance(shape, slides.GroupShape):
            inspect_shapes(shape.shapes, slide_number, path + "/")


with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        inspect_shapes(slide.shapes, slide.slide_number)
```

Załóżmy, że slajd 1 z `Sample.pptx` zawiera grupę o nazwie `Layout` z zablokowanym rozgrupowywaniem, obraz o nazwie `Photo` wewnątrz niej z zablokowanym przycięciem oraz odblokowany prostokąt o nazwie `Free`. Raport pomija `Free` i wypisuje te dwie linie:

```text
Slide 1 | Layout | GroupShape | ungrouping_locked
Slide 1 | Layout/Photo | PictureFrame | crop_locked
```

Raport odczytuje zapisane flagi edycji na poziomie kształtu bez ich zmieniania ani zapisywania prezentacji. Ochrona zapisu na poziomie dokumentu jest odrębnym ustawieniem, a egzekwowanie każdej flagi zależy od edytora.

### **Wnioski**

Aspose.Slides for Python via .NET pozwala ograniczyć konkretne operacje edycji na poszczególnych kształtach lub zastosować te same ograniczenia na wszystkich slajdach. Wybierz blokady obsługiwane przez dany typ kształtu i ustaw ich wartości na `False`, gdy potrzebujesz usunąć te ograniczenia.

## **FAQ**

**Czy mogę połączyć blokady kształtów i ochronę hasłem w tej samej prezentacji?**

Tak. Blokady kształtów ograniczają konkretne operacje edycji, podczas gdy [ochroną hasłem](/slides/pl/python-net/password-protected-presentation/) może ograniczać otwieranie lub modyfikację prezentacji. Można używać obu w tym samym pliku.

**Czy mogę ograniczyć edycję na konkretnych slajdach bez wpływu na inne?**

Tak. Zastosuj blokady tylko do kształtów na wybranych slajdach. Nie zmienia to ustawień blokad na innych slajdach.

**Jak mogę zastosować blokady do pojedynczych kształtów wewnątrz grupy?**

Iteruj przez kolekcję [kształty](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) grupy i zastosuj odpowiednie blokady do każdego kształtu podrzędnego. Powtórz to dla wszelkich zagnieżdżonych grup, postępując zgodnie z przeglądem w przykładzie raportującym.