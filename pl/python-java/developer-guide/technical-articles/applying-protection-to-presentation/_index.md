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
- blokada zaznaczania
- blokada zmiany rozmiaru
- blokada grupowania
- PowerPoint
- PPTX
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Dowiedz się, jak blokować i odblokowywać kształty w prezentacjach PPTX przy użyciu Aspose.Slides for Python via Java, aby ograniczyć zaznaczanie, przemieszczanie, zmianę rozmiaru i grupowanie."
---
## **Tło**

Typowym zastosowaniem Aspose.Slides for Python via Java jest tworzenie, aktualizowanie i zapisywanie prezentacji PowerPoint (PPTX) w ramach zautomatyzowanego przepływu pracy. Gdy użytkownicy otrzymują te prezentacje, ograniczenie zmian w kształtach może pomóc zachować zamierzony układ i zawartość.

Ten artykuł wyjaśnia, jak kształty są organizowane na slajdach oraz jak zastosować i usunąć blokady kształtów w prezentacji PPTX. Te blokady umożliwiają ograniczenie konkretnych operacji edycji na poszczególnych kształtach.

## **Kompozycja slajdu**

Slajd prezentacji składa się z komponentów takich jak autokształty, tabele, obiekty OLE, grupowane kształty, ramki obrazu, ramki wideo, łącza i inne elementy używane do budowy prezentacji. W Aspose.Slides for Python via Java każdy element na slajdzie jest reprezentowany przez obiekt dziedziczący po klasie [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) .

Różne typy kształtów udostępniają różne opcje blokowania. Klasa [BaseShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/) jest klasą bazową dla blokad kształtów. Aspose.Slides for Python via Java udostępnia następujące klasy blokad:

- [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/) blokuje autokształty.  
- [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) blokuje łącza.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/) blokuje obiekty graficzne.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/) blokuje grupowane kształty.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) blokuje ramki obrazu.  

Aby zastosować blokady w całej [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/), iteruj po jej slajdach i ustaw odpowiednie blokady na każdym obsługiwanym kształcie.

## **Zastosowanie i usunięcie ochrony**

Blokady kształtów ograniczają operacje takie jak zaznaczanie, przemieszczanie i zmiana rozmiaru kształtów. Nie sprawiają, że cała prezentacja jest nieedytowalna.

### **Zastosowanie ochrony do kształtów PPTX**

Aspose.Slides for Python via Java udostępnia klasę [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) , aby pracować z kształtami na slajdzie.

Przykład wywołuje [setSelectLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setPositionLocked) i [setSizeLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSizeLocked) z wartością `True` dla autokształtów, oraz równoważne blokady dla grupowanych kształtów, łączy i ramek obrazu. Łącza używają [setPositionMove](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/#setPositionMove) do przemieszczania; grupy także używają [setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked), aby ograniczyć grupowanie.

Przykład ładuje istniejącą prezentację PPTX, sprawdza kształty w kolekcji kształtów każdego slajdu i zapisuje kopię z zastosowanymi ograniczeniami. Kształty spoza czterech obsługiwanych typów pozostają niezmienione. Pętla nie przegląda kształtów potomnych wewnątrz grupy.

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

Aby usunąć blokadę kształtu, ustaw jej wartość na `False`. Poniższy przykład ładuje prezentację z blokadami kształtów i usuwa ograniczenia zaznaczania, przemieszczania i zmiany rozmiaru za pomocą [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) i [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/). Usuwa także ograniczenie grupowania, przekazując `False` do [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked), i zapisuje kopię prezentacji. Inne ustawienia blokad pozostają niezmienione.

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

### **Podsumowanie**

Aspose.Slides for Python via Java pozwala ograniczyć określone operacje edycji na pojedynczych kształtach lub zastosować te same ograniczenia na wielu slajdach. Wybierz blokady obsługiwane przez dany typ kształtu i ustaw ich wartości na `False`, gdy potrzebujesz usunąć te ograniczenia.

## **FAQ**

**Czy mogę łączyć blokady kształtów i ochronę hasłem w tej samej prezentacji?**

Tak. Blokady kształtów ograniczają określone operacje edycji, podczas gdy [ochrona hasłem](/slides/pl/python-java/password-protected-presentation/) może ograniczyć otwieranie lub modyfikowanie prezentacji. Możesz używać obu w tym samym pliku.

**Czy mogę ograniczyć edycję na konkretnych slajdach bez wpływu na inne?**

Tak. Zastosuj blokady tylko do kształtów na wybranych slajdach. Nie zmieni to ustawień blokad na innych slajdach.

**Jak mogę zastosować blokady do pojedynczych kształtów wewnątrz grupy?**

Iteruj po kolekcji zwróconej przez metodę [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) grupy i zastosuj odpowiednie blokady do każdego kształtu podrzędnego. Powtórz to dla wszelkich zagnieżdżonych grup. Powyższe przykłady przetwarzają tylko kolekcję kształtów slajdu, więc nie ustawiają blokad na poszczególnych elementach grupy.