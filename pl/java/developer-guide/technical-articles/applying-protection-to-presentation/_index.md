---
title: Ogranicz edycję prezentacji za pomocą blokad kształtów w Javie
linktitle: Ogranicz edycję prezentacji
type: docs
weight: 60
url: /pl/java/applying-protection-to-presentation/
keywords:
- zapobiegać edycji
- chronić przed edycją
- blokada kształtu
- blokada pozycji
- blokada zaznaczania
- blokada zmiany rozmiaru
- blokada grupowania
- PowerPoint
- PPTX
- prezentacja
- Java
- Aspose.Slides
description: "Dowiedz się, jak blokować i odblokowywać kształty w prezentacjach PPTX przy użyciu Aspose.Slides dla Javy, aby ograniczyć zaznaczanie, przemieszczanie, zmianę rozmiaru i grupowanie."
---
## **Tło**

Częstym zastosowaniem Aspose.Slides for Java jest tworzenie, aktualizowanie i zapisywanie prezentacji PowerPoint (PPTX) w ramach zautomatyzowanego przepływu pracy. Gdy użytkownicy otrzymują te prezentacje, ograniczanie zmian kształtów może pomóc zachować zamierzony układ i zawartość.

Ten artykuł wyjaśnia, jak kształty są organizowane na slajdach oraz jak zastosować i usunąć blokady kształtów w prezentacji PPTX. Te blokady pozwalają ograniczyć określone operacje edycji na poszczególnych kształtach.

## **Skład slajdu**

Slajd prezentacji składa się z elementów takich jak autokształty, tabele, obiekty OLE, grupowane kształty, ramki obrazów, ramki wideo, łączniki i inne elementy używane do tworzenia prezentacji. W Aspose.Slides for Java każdy element na slajdzie jest reprezentowany przez obiekt implementujący interfejs [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) lub dziedziczący po klasie, która to robi.

Różne typy kształtów udostępniają różne opcje blokowania. Interfejs [IBaseShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/) jest podstawowym interfejsem dla blokad kształtów. Aspose.Slides for Java zapewnia następujące interfejsy blokad:

- [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/) blokuje autokształty.  
- [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) blokuje kształty łączników.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/) blokuje obiekty graficzne.  
- [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/) blokuje grupowane kształty.  
- [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) blokuje ramki obrazów.  

Aby zastosować blokady w całej [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/), iteruj po jej slajdach i ustaw odpowiednie blokady na każdym obsługiwanym kształcie.

## **Zastosowanie i usunięcie ochrony**

Blokady kształtów ograniczają operacje takie jak zaznaczanie, przenoszenie i zmiana rozmiaru kształtów. Nie uniemożliwiają one edycji całej prezentacji.

### **Zastosowanie ochrony do kształtów PPTX**

Aspose.Slides for Java udostępnia interfejs [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) do pracy z kształtami na slajdzie.

Przykład wywołuje [setSelectLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-), [setPositionLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-), oraz [setSizeLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) z wartością `true` dla autokształtów, oraz odpowiednie blokady dla grupowanych kształtów, łączników i ramek obrazów. Łączniki używają [setPositionMove](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) do przemieszczania; grupy używają także [setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) aby ograniczyć grupowanie.

Przykład ładuje istniejącą prezentację PPTX, sprawdza kształty w kolekcji kształtów każdego slajdu i zapisuje kopię z zastosowanymi restrykcjami. Kształty spoza czterech obsługiwanych typów pozostają niezmienione. Pętla nie przegląda kształtów podrzędnych wewnątrz grupy.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();
                autoShapeLock.setPositionLocked(true);
                autoShapeLock.setSelectLocked(true);
                autoShapeLock.setSizeLocked(true);
            } else if (shape instanceof IGroupShape) {
                IGroupShape groupShape = (IGroupShape) shape;
                IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();
                groupShapeLock.setGroupingLocked(true);
                groupShapeLock.setPositionLocked(true);
                groupShapeLock.setSelectLocked(true);
                groupShapeLock.setSizeLocked(true);
            } else if (shape instanceof IConnector) {
                IConnector connectorShape = (IConnector) shape;
                IConnectorLock connectorShapeLock = connectorShape.getShapeLock();
                connectorShapeLock.setPositionMove(true);
                connectorShapeLock.setSelectLocked(true);
                connectorShapeLock.setSizeLocked(true);
            } else if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();
                pictureFrameLock.setPositionLocked(true);
                pictureFrameLock.setSelectLocked(true);
                pictureFrameLock.setSizeLocked(true);
            }
        }
    }

    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Usunięcie ochrony**

Aby usunąć blokadę kształtu, ustaw jej wartość na `false`. Poniższy przykład ładuje prezentację z blokadami kształtów i usuwa ograniczenia wyboru, przemieszczania i zmiany rozmiaru poprzez [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/), i [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/). Usuwa także ograniczenie grupowania, przekazując `false` do [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) i zapisuje kopię prezentacji. Inne ustawienia blokad pozostają niezmienione.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ProtectedSample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();
                autoShapeLock.setPositionLocked(false);
                autoShapeLock.setSelectLocked(false);
                autoShapeLock.setSizeLocked(false);
            } else if (shape instanceof IGroupShape) {
                IGroupShape groupShape = (IGroupShape) shape;
                IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();
                groupShapeLock.setGroupingLocked(false);
                groupShapeLock.setPositionLocked(false);
                groupShapeLock.setSelectLocked(false);
                groupShapeLock.setSizeLocked(false);
            } else if (shape instanceof IConnector) {
                IConnector connectorShape = (IConnector) shape;
                IConnectorLock connectorShapeLock = connectorShape.getShapeLock();
                connectorShapeLock.setPositionMove(false);
                connectorShapeLock.setSelectLocked(false);
                connectorShapeLock.setSizeLocked(false);
            } else if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();
                pictureFrameLock.setPositionLocked(false);
                pictureFrameLock.setSelectLocked(false);
                pictureFrameLock.setSizeLocked(false);
            }
        }
    }

    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Wnioski**

Aspose.Slides for Java umożliwia ograniczenie konkretnych operacji edycji na poszczególnych kształtach lub zastosowanie tych samych ograniczeń na wszystkich slajdach. Wybierz blokady obsługiwane przez dany typ kształtu i ustaw ich wartości na `false`, gdy potrzebujesz usunąć te ograniczenia.

## **FAQ**

**Czy mogę połączyć blokady kształtów i ochronę hasłem w tej samej prezentacji?**

Tak. Blokady kształtów ograniczają określone operacje edycji, podczas gdy [ochrona hasłem](/slides/pl/java/password-protected-presentation/) może ograniczyć otwieranie lub modyfikowanie prezentacji. Można używać obu w tym samym pliku.

**Czy mogę ograniczyć edycję na konkretnych slajdach bez wpływu na inne?**

Tak. Zastosuj blokady tylko do kształtów na wybranych slajdach. Nie zmienia to ustawień blokad na innych slajdach.

**Jak mogę zastosować blokady do poszczególnych kształtów wewnątrz grupy?**

Iteruj po kolekcji zwróconej przez metodę [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) grupy i zastosuj odpowiednie blokady do każdego kształtu potomnego. Powtórz to dla wszelkich zagnieżdżonych grup. Powyższe przykłady przetwarzają tylko kolekcję kształtów slajdu, więc nie ustawiają blokad dla poszczególnych elementów grupy.