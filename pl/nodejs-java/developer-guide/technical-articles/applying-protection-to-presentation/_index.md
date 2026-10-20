---
title: Ogranicz edycję prezentacji przy użyciu blokad kształtów w Node.js
linktitle: Ogranicz edycję prezentacji
type: docs
weight: 60
url: /pl/nodejs-java/applying-protection-to-presentation/
keywords:
- zapobiegać edycji
- chronić przed edycją
- zablokować kształt
- zablokować pozycję
- zablokować wybór
- zablokować zmianę rozmiaru
- zablokować grupowanie
- PowerPoint
- PPTX
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dowiedz się, jak blokować i odblokowywać kształty w prezentacjach PPTX przy użyciu Aspose.Slides for Node.js via Java, aby ograniczyć wybór, przemieszczanie, zmianę rozmiaru i grupowanie."
---
## **Przegląd**

Typowym zastosowaniem Aspose.Slides for Node.js via Java jest tworzenie, aktualizacja i zapisywanie prezentacji PowerPoint (PPTX) w ramach zautomatyzowanego przepływu pracy. Gdy użytkownicy otrzymują te prezentacje, ograniczenie zmian kształtów może pomóc zachować zamierzony układ i treść.

Ten artykuł wyjaśnia, jak kształty są zorganizowane na slajdach oraz jak zastosować i usunąć blokady kształtów w prezentacji PPTX. Blokady te pozwalają ograniczyć określone operacje edycyjne na poszczególnych kształtach.

## **Kompozycja slajdu**

Slajd prezentacji składa się z elementów takich jak autokształty, tabele, obiekty OLE, grupowane kształty, ramki obrazu, ramki wideo, łącza oraz inne elementy używane do budowy prezentacji. W Aspose.Slides for Node.js via Java każdy element na slajdzie jest reprezentowany przez obiekt dziedziczący po klasie [Kształt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) .

Różne typy kształtów udostępniają różne opcje blokowania. Klasa [BaseShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/) jest klasą bazową dla blokad kształtów. Aspose.Slides for Node.js via Java udostępnia następujące klasy blokad:

- [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/) blokuje autokształty.  
- [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) blokuje kształty łączników.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) blokuje obiekty graficzne.  
- [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/) blokuje grupowane kształty.  
- [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) blokuje ramki obrazów.  

Aby zastosować blokady w całej [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/), iteruj po jej slajdach i ustaw odpowiednie blokady na każdym obsługiwanym kształcie.

## **Zastosowanie i usunięcie ochrony**

Blokady kształtów ograniczają operacje takie jak wybieranie, przemieszczanie i zmiana rozmiaru kształtów. Nie powodują, że cała prezentacja staje się nieedytowalna.

### **Zastosowanie ochrony do kształtów PPTX**

Aspose.Slides for Node.js via Java udostępnia klasę [Kształt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) do pracy z kształtami na slajdzie.

Przykład wywołuje [setSelectLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setPositionLocked) i [setSizeLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSizeLocked) z wartością `true` dla autokształtów, oraz równoważne blokady dla grupowanych kształtów, łączników i ramek obrazów. Łączniki używają [setPositionMove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/#setPositionMove) do przemieszczania; grupy również używają [setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked), aby ograniczyć grupowanie.

Przykład ładuje istniejącą prezentację PPTX, sprawdza kształty w kolekcji kształtów każdego slajdu i zapisuje kopię z zastosowanymi ograniczeniami. Kształty spoza czterech obsługiwanych typów pozostają niezmienione. Pętla nie przechodzi przez kształty potomne wewnątrz grupy.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const autoShapeLock = shape.getShapeLock();
                autoShapeLock.setPositionLocked(true);
                autoShapeLock.setSelectLocked(true);
                autoShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IGroupShape")) {
                const groupShapeLock = shape.getShapeLock();
                groupShapeLock.setGroupingLocked(true);
                groupShapeLock.setPositionLocked(true);
                groupShapeLock.setSelectLocked(true);
                groupShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IConnector")) {
                const connectorShapeLock = shape.getShapeLock();
                connectorShapeLock.setPositionMove(true);
                connectorShapeLock.setSelectLocked(true);
                connectorShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                const pictureFrameLock = shape.getShapeLock();
                pictureFrameLock.setPositionLocked(true);
                pictureFrameLock.setSelectLocked(true);
                pictureFrameLock.setSizeLocked(true);
            }
        }
    }

    presentation.save("ProtectedSample.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Usunięcie ochrony**

Aby usunąć blokadę kształtu, ustaw jej wartość na `false`. Poniższy przykład ładuje prezentację z blokadami kształtów i usuwa ograniczenia wyboru, przemieszczania i zmiany rozmiaru za pomocą [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) oraz [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/). Usuwa również ograniczenie grupowania, przekazując `false` do [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked), i zapisuje kopię prezentacji. Inne ustawienia blokad pozostają niezmienione.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("ProtectedSample.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const autoShapeLock = shape.getShapeLock();
                autoShapeLock.setPositionLocked(false);
                autoShapeLock.setSelectLocked(false);
                autoShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IGroupShape")) {
                const groupShapeLock = shape.getShapeLock();
                groupShapeLock.setGroupingLocked(false);
                groupShapeLock.setPositionLocked(false);
                groupShapeLock.setSelectLocked(false);
                groupShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IConnector")) {
                const connectorShapeLock = shape.getShapeLock();
                connectorShapeLock.setPositionMove(false);
                connectorShapeLock.setSelectLocked(false);
                connectorShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                const pictureFrameLock = shape.getShapeLock();
                pictureFrameLock.setPositionLocked(false);
                pictureFrameLock.setSelectLocked(false);
                pictureFrameLock.setSizeLocked(false);
            }
        }
    }

    presentation.save("RemovedProtectionSample.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Wniosek**

Aspose.Slides for Node.js via Java pozwala ograniczyć określone operacje edycyjne na poszczególnych kształtach lub zastosować te same ograniczenia w całych slajdach. Wybierz blokady obsługiwane przez każdy typ kształtu i ustaw ich wartości na `false`, gdy potrzebujesz usunąć te ograniczenia.

## **FAQ**

**Czy mogę łączyć blokady kształtów i ochronę hasłem w tej samej prezentacji?**

Tak. Blokady kształtów ograniczają określone operacje edycyjne, podczas gdy [ochrona hasłem](/slides/pl/nodejs-java/password-protected-presentation/) może ograniczyć otwieranie lub modyfikację prezentacji. Można używać obu w tym samym pliku.

**Czy mogę ograniczyć edycję na konkretnych slajdach bez wpływu na inne?**

Tak. Zastosuj blokady tylko do kształtów na wybranych slajdach. Nie zmienia to ustawień blokad na pozostałych slajdach.

**Jak mogę zastosować blokady do poszczególnych kształtów wewnątrz grupy?**

Iteruj po kolekcji zwróconej przez metodę [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) i zastosuj odpowiednie blokady do każdego kształtu potomnego. Powtórz to dla wszelkich zagnieżdżonych grup. Powyższe przykłady przetwarzają tylko kolekcję kształtów slajdu, więc nie ustawiają blokad na poszczególnych elementach grupy.