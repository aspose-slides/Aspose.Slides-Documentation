---
title: Ogranicz edycję prezentacji za pomocą blokad kształtów w Pythonie
linktitle: Ogranicz edycję prezentacji
type: docs
weight: 60
url: /pl/python-java/applying-protection-to-presentation/
keywords:
- zapobieganie edycji
- ochrona przed edycją
- blokada kształtu
- blokada pozycji
- blokada wyboru
- blokada zmiany rozmiaru
- blokada grupowania
- PowerPoint
- PPTX
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Dowiedz się, jak blokować i odblokowywać kształty w prezentacjach PPTX przy użyciu Aspose.Slides for Python via Java, aby ograniczyć wybór, przemieszczanie, zmianę rozmiaru i grupowanie."
---
## **Tło**

Typowym zastosowaniem Aspose.Slides for Python via Java jest tworzenie, aktualizowanie i zapisywanie prezentacji PowerPoint (PPTX) jako część zautomatyzowanego procesu. Gdy użytkownicy otrzymują te prezentacje, ograniczenie zmian kształtów może pomóc zachować zamierzony układ i zawartość.

Ten artykuł wyjaśnia, jak kształty są organizowane na slajdach oraz jak zastosować i usunąć blokady kształtów w prezentacji PPTX. Blokady te pozwalają ograniczyć konkretne operacje edycji na poszczególnych kształtach.

## **Kompozycja slajdu**

Slajd prezentacji składa się z elementów takich jak autokształty, tabele, obiekty OLE, grupowane kształty, ramki obrazu, ramki wideo, łączniki i inne elementy używane do budowy prezentacji. W Aspose.Slides for Python via Java każdy element na slajdzie jest reprezentowany przez obiekt dziedziczący po klasie [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) .

Różne typy kształtów udostępniają różne opcje blokowania. Klasa [BaseShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/) jest klasą bazową dla blokad kształtów. Aspose.Slides for Python via Java udostępnia następujące klasy blokad:

- [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/) blokuje autokształty.  
- [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) blokuje kształty łączników.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/) blokuje obiekty graficzne.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/) blokuje grupowane kształty.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) blokuje ramki obrazu.  

Aby zastosować blokady w całej [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/), przeiteruj jej slajdy i ustaw odpowiednie blokady na każdym obsługiwanym kształcie.

## **Zastosowanie i usunięcie ochrony**

Kompatybilne edytory prezentacji używają blokad kształtów do ograniczania poszczególnych operacji edycji. Szyfrowanie pliku i ochrona przed zapisem na poziomie dokumentu są oddzielnymi [presentation protection settings](/slides/pl/python-java/password-protected-presentation/).

### **Zastosowanie ochrony do kształtów PPTX**

Aspose.Slides for Python via Java udostępnia klasę [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) do pracy z kształtami na slajdzie.

Przykład wywołuje [setSelectLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setPositionLocked) i [setSizeLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSizeLocked) z wartością `True` dla autokształtów, z odpowiednimi blokadami dla grupowanych kształtów, łączników i ramek obrazu. Łączniki używają [setPositionMove](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/#setPositionMove) do ruchu; grupy dodatkowo używają [setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) aby ograniczyć grupowanie.

Przykład wczytuje istniejącą prezentację PPTX, sprawdza kształty w kolekcji kształtów każdego slajdu i zapisuje kopię z zastosowanymi ograniczeniami. Kształty spoza czterech obsługiwanych typów pozostają niezmienione. Pętla nie przegląda kształtów podrzędnych wewnątrz grupy.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    for slide in presentation.getSlides():
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

    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Usunięcie ochrony**

Aby usunąć blokadę kształtu, ustaw jej wartość na `False`. Poniższy przykład wczytuje prezentację z blokadami kształtów i usuwa ograniczenia wyboru, ruchu i zmiany rozmiaru poprzez [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) i [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/). Usuwa również ograniczenie grupowania, przekazując `False` do [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) i zapisuje kopię prezentacji. Inne ustawienia blokad pozostają niezmienione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

presentation = Presentation("ProtectedSample.pptx")
try:
    for slide in presentation.getSlides():
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

    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Zachowanie przycięcia obrazu**

Umieść zdjęcie o nazwie `photo.jpg` w katalogu roboczym. Przykład przycina 12 % od lewej i 8 % od prawej, a następnie wywołuje [setCropLocked](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/#setCropLocked) z wartością `True`, aby zachować przycięcie.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()

    photo_bytes = Path("photo.jpg").read_bytes()
    photo = presentation.getImages().addImage(photo_bytes)
    
    picture_frame = shapes.addPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo)
    picture_frame.getPictureFormat().setCropLeft(12)
    picture_frame.getPictureFormat().setCropRight(8)

    picture_lock = picture_frame.getPictureFrameLock()
    picture_lock.setAspectRatioLocked(False)
    picture_lock.setCropLocked(True)

    presentation.save("PictureLocked.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

W pliku `PictureLocked.pptx` program PowerPoint wyłącza polecenie **Crop** po zaznaczeniu zdjęcia.

### **Utrzymanie diagramu w grupie**

Przykład grupuje prostokąt i strzałkę, a następnie wywołuje [setUngroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setUngroupingLocked) z wartością `True`, aby utrzymać dwa kształty razem. Nadal możesz przesuwać grupę lub zmieniać wypełnienie komponentu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()

    group = shapes.addGroupShape()
    group.getShapes().addAutoShape(ShapeType.Rectangle, 100, 70, 90, 50)
    group.getShapes().addAutoShape(ShapeType.RightArrow, 190, 80, 60, 30)
    group.getGroupShapeLock().setUngroupingLocked(True)

    presentation.save("DiagramLocked.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

W pliku `DiagramLocked.pptx` program PowerPoint wyłącza polecenie **Ungroup** po zaznaczeniu całego diagramu.

### **Raportowanie istniejących blokad kształtów**

Aby przejrzeć szablon, otwórz go i odczytaj obiekt blokady dla każdego kształtu. Metoda [getNoLocks](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/#getNoLocks) zwraca `True`, gdy wszystkie flagi w tym obiekcie są wyłączone, oraz `False`, gdy przynajmniej jedna jest włączona. Grupa i jej elementy potomne mają oddzielne obiekty blokad, więc należy sprawdzić elementy potomne nawet wtedy, gdy grupa nie ma blokad.

Przykład sprawdza ruch dla autokształtów, ramek obrazu i grup. Sprawdza także przycięcie dla obrazów oraz rozgrupowanie dla grup. Raport wymienia rozpoznane włączone flagi i oznacza typy kształtów, których nie analizuje.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, GroupShape, PictureFrame, Presentation


def inspect_shapes(shapes, slide_number, prefix=""):
    for shape in shapes:
        path = f"{prefix}{shape.getName()}"
        label = f"Slide {slide_number} | {path} | {shape.getClass().getSimpleName()}"
        flags = []

        if isinstance(shape, GroupShape):
            shape_lock = shape.getGroupShapeLock()
            if shape_lock.getUngroupingLocked():
                flags.append("UngroupingLocked")
        elif isinstance(shape, PictureFrame):
            shape_lock = shape.getPictureFrameLock()
            if shape_lock.getCropLocked():
                flags.append("CropLocked")
        elif isinstance(shape, AutoShape):
            shape_lock = shape.getAutoShapeLock()
        else:
            print(f"{label} | Uninspected")
            continue

        if shape_lock.getPositionLocked():
            flags.append("PositionLocked")
        if not shape_lock.getNoLocks():
            restrictions = ", ".join(flags) if flags else "Active flag not identified"
            print(f"{label} | {restrictions}")

        if isinstance(shape, GroupShape):
            inspect_shapes(shape.getShapes(), slide_number, f"{path}/")


presentation = Presentation("Sample.pptx")
try:
    for slide in presentation.getSlides():
        inspect_shapes(slide.getShapes(), slide.getSlideNumber())
finally:
    presentation.dispose()
```

Załóżmy, że slajd 1 pliku `Sample.pptx` zawiera grupę o nazwie `Layout` z zablokowanym rozgrupowaniem, obraz `Photo` wewnątrz niej z zablokowanym przycięciem oraz odblokowany prostokąt `Free`. Raport pomija `Free` i wypisuje te dwa wiersze:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Raport odczytuje zapisane flagi edycji na poziomie kształtu bez ich zmieniania lub zapisywania prezentacji. Ochrona przed zapisem na poziomie dokumentu jest oddzielnym ustawieniem, a egzekwowanie każdej flagi zależy od edytora.

### **Wniosek**

Aspose.Slides for Python via Java pozwala ograniczyć konkretne operacje edycji na poszczególnych kształtach lub zastosować te same ograniczenia na wielu slajdach. Wybierz blokady obsługiwane przez dany typ kształtu i ustaw ich wartości na `False`, gdy potrzebujesz usunąć te ograniczenia.

## **FAQ**

**Czy mogę łączyć blokady kształtów i ochronę hasłem w tej samej prezentacji?**

Tak. Blokady kształtów ograniczają konkretne operacje edycji, natomiast [password protection](/slides/pl/python-java/password-protected-presentation/) może ograniczyć otwieranie lub modyfikowanie prezentacji. Możesz używać obu w tym samym pliku.

**Czy mogę ograniczyć edycję na konkretnych slajdach bez wpływu na inne?**

Tak. Zastosuj blokady tylko do kształtów na wybranych slajdach. Nie zmieni to ustawień blokad na pozostałych slajdach.

**Jak mogę zastosować blokady do pojedynczych kształtów wewnątrz grupy?**

Iteruj po kolekcji zwróconej przez metodę grupy [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) i zastosuj odpowiednie blokady do każdego kształtu potomnego. Powtórz to dla wszelkich zagnieżdżonych grup, zgodnie z przebiegiem opisanym w przykładzie raportu.