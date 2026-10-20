---
title: Ogranicz edycję prezentacji przy użyciu blokad kształtów w Pythonie
linktitle: Ogranicz edycję prezentacji
type: docs
weight: 70
url: /pl/python-net/applying-protection-to-presentation/
keywords:
- zapobieganie edycjom
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
- Aspose.Slides
description: "Dowiedz się, jak blokować i odblokowywać kształty w prezentacjach PPTX przy użyciu Aspose.Slides for Python via .NET, aby ograniczyć zaznaczanie, przemieszczanie, zmianę rozmiaru i grupowanie."
---
## **Tło**

Typowym zastosowaniem Aspose.Slides for Python via .NET jest tworzenie, aktualizowanie i zapisywanie prezentacji PowerPoint (PPTX) w ramach zautomatyzowanego przepływu pracy. Gdy użytkownicy otrzymują te prezentacje, ograniczenie zmian kształtów może pomóc zachować zamierzony układ i treść.

Ten artykuł wyjaśnia, jak kształty są organizowane na slajdach oraz jak zastosować i usunąć blokady kształtów w prezentacji PPTX. Te blokady pozwalają ograniczyć określone operacje edycyjne na pojedynczych kształtach.

## **Kompozycja slajdu**

Slajd prezentacji składa się z elementów takich jak autokształty, tabele, obiekty OLE, grupowane kształty, ramki obrazów, ramki wideo, łączniki oraz inne elementy używane do tworzenia prezentacji. W Aspose.Slides for Python via .NET każdy element na slajdzie jest reprezentowany przez obiekt dziedziczący po klasie [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) .

Różne typy kształtów udostępniają różne opcje blokowania. Klasa [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) jest klasą bazową dla blokad kształtów. Aspose.Slides for Python via .NET udostępnia następujące klasy blokad:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) blokuje autokształty.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) blokuje kształty łączników.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) blokuje obiekty graficzne.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) blokuje grupowane kształty.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) blokuje ramki obrazów.  

Aby zastosować blokady w całej [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), przeglądnij jej slajdy i ustaw odpowiednie blokady na każdym obsługiwanym kształcie.

## **Zastosowanie i usunięcie ochrony**

Blokady kształtów ograniczają operacje takie jak zaznaczanie, przemieszczanie i zmienianie rozmiaru kształtów. Nie powodują, że cała prezentacja jest nieedytowalna.

### **Zastosowanie ochrony do kształtów PPTX**

Aspose.Slides for Python via .NET udostępnia klasę [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) do pracy z kształtami na slajdzie.

Przykład ustawia [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/), [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/) i [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) na `True` dla autokształtów, z równoważnymi blokadami dla grupowanych kształtów, łączników i ramek obrazów. Łączniki używają [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) do przemieszczania; grupy także używają [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) aby ograniczyć grupowanie.

Przykład ładuje istniejącą prezentację PPTX, sprawdza kształty w kolekcji kształtów każdego slajdu i zapisuje kopię z zastosowanymi ograniczeniami. Kształty spoza czterech obsługiwanych typów pozostają niezmienione. Pętla nie przegląda kształtów potomnych wewnątrz grupy.

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

Aby usunąć blokadę kształtu, ustaw jej wartość na `False`. Poniższy przykład ładuje prezentację z blokadami kształtów i usuwa ograniczenia zaznaczania, przemieszczania i zmiany rozmiaru za pomocą [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) oraz [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/). Usuwa także [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) i zapisuje kopię prezentacji. Inne ustawienia blokad pozostają niezmienione.

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

### **Podsumowanie**

Aspose.Slides for Python via .NET pozwala ograniczyć określone operacje edycyjne na pojedynczych kształtach lub zastosować te same ograniczenia w całej prezentacji. Wybierz blokady obsługiwane przez dany typ kształtu i ustaw ich wartości na `False`, gdy potrzebujesz usunąć te ograniczenia.

## **FAQ**

**Czy mogę połączyć blokady kształtów i ochronę hasłem w tej samej prezentacji?**

Tak. Blokady kształtów ograniczają określone operacje edycyjne, podczas gdy [ochrona hasłem](/slides/pl/python-net/password-protected-presentation/) może ograniczyć otwieranie lub modyfikację prezentacji. Można używać obu w tym samym pliku.

**Czy mogę ograniczyć edycję na konkretnych slajdach bez wpływu na inne?**

Tak. Zastosuj blokady tylko do kształtów na wybranych slajdach. Nie zmienia to ustawień blokad na innych slajdach.

**Jak mogę zastosować blokady do pojedynczych kształtów wewnątrz grupy?**

Iteruj przez kolekcję [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) grupy i zastosuj odpowiednie blokady do każdego kształtu potomnego. Powtórz to dla wszelkich zagnieżdżonych grup. Powyższe przykłady przetwarzają tylko kolekcję kształtów slajdu, więc nie ustawiają blokad na pojedynczych elementach grupy.