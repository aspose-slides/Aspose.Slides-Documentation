---
title: Ogranicz edycję prezentacji za pomocą blokad kształtów na Androidzie
linktitle: Ogranicz edycję prezentacji
type: docs
weight: 60
url: /pl/androidjava/applying-protection-to-presentation/
keywords:
- zapobieganie edycji
- ochrona przed edycją
- zablokuj kształt
- zablokuj pozycję
- zablokuj wybór
- zablokuj zmianę rozmiaru
- zablokuj grupowanie
- PowerPoint
- PPTX
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Dowiedz się, jak blokować i odblokowywać kształty w prezentacjach PPTX za pomocą Aspose.Slides for Android via Java, aby ograniczyć wybór, przemieszczanie, zmianę rozmiaru i grupowanie."
---
## **Przegląd**

Typowym zastosowaniem Aspose.Slides for Android via Java jest tworzenie, aktualizowanie i zapisywanie prezentacji PowerPoint (PPTX) jako część zautomatyzowanego przepływu pracy. Gdy użytkownicy otrzymują te prezentacje, ograniczenie zmian kształtów może pomóc zachować zamierzony układ i treść.

Ten artykuł wyjaśnia, jak kształty są organizowane na slajdach oraz jak zastosować i usunąć blokady kształtów w prezentacji PPTX. Te blokady pozwalają ograniczyć określone operacje edycyjne na pojedynczych kształtach.

## **Budowa slajdu**

Prezentacja składa się z elementów takich jak autoshapes, tabele, obiekty OLE, grupowane kształty, ramki obrazów, ramki wideo, łączniki i inne elementy używane do budowy prezentacji. W Aspose.Slides for Android via Java każdy element na slajdzie jest reprezentowany przez obiekt implementujący interfejs [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) lub dziedziczący po klasie, która to robi.

Różne typy kształtów udostępniają różne opcje blokowania. Interfejs [IBaseShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/) jest podstawowym interfejsem dla blokad kształtów. Aspose.Slides for Android via Java udostępnia następujące interfejsy blokad:

- [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/) blokuje autoshapes.  
- [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) blokuje łączniki.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) blokuje obiekty graficzne.  
- [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/) blokuje grupowane kształty.  
- [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) blokuje ramki obrazów.  

Aby zastosować blokady w całej [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/), przeiteruj slajdy i ustaw odpowiednie blokady na każdym obsługiwanym kształcie.

## **Zastosowanie i usunięcie ochrony**

Blokady kształtów ograniczają operacje takie jak wybieranie, przenoszenie i zmiana rozmiaru kształtów. Nie sprawiają, że cała prezentacja staje się nieedytowalna.

### **Zastosuj ochronę do kształtów PPTX**

Aspose.Slides for Android via Java udostępnia interfejs [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) do pracy z kształtami na slajdzie.

Przykład wywołuje [setSelectLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-), [setPositionLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-) i [setSizeLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) z wartością `true` dla autoshapes, oraz równoważne blokady dla grupowanych kształtów, łączników i ramek obrazów. Łączniki używają [setPositionMove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) do przemieszczania; grupy dodatkowo używają [setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) aby ograniczyć grupowanie.

Przykład ładuje istniejącą prezentację PPTX, sprawdza kształty w kolekcji kształtów każdego slajdu i zapisuje kopię z zastosowanymi ograniczeniami. Kształty spoza czterech obsługiwanych typów pozostają niezmienione. Pętla nie przegląda kształtów podrzędnych wewnątrz grupy.

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

Aby usunąć blokadę kształtu, ustaw jej wartość na `false`. Poniższy przykład ładuje prezentację z blokadami kształtów i usuwa ograniczenia wyboru, przemieszczania i zmiany rozmiaru poprzez [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) i [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/). Usuwa także ograniczenie grupowania, przekazując `false` do [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) i zapisuje kopię prezentacji. Inne ustawienia blokad pozostają niezmienione.

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

### **Wniosek**

Aspose.Slides for Android via Java umożliwia ograniczenie konkretnych operacji edycyjnych na poszczególnych kształtach lub zastosowanie tych samych ograniczeń na wszystkich slajdach. Wybierz blokady obsługiwane przez dany typ kształtu i ustaw ich wartości na `false`, gdy potrzebujesz usunąć te ograniczenia.

## **FAQ**

**Czy mogę połączyć blokady kształtów i ochronę hasłem w jednej prezentacji?**

Tak. Blokady kształtów ograniczają konkretne operacje edycyjne, podczas gdy [password protection](/slides/pl/androidjava/password-protected-presentation/) może ograniczyć otwieranie lub modyfikowanie prezentacji. Można używać obu w tym samym pliku.

**Czy mogę ograniczyć edycję na konkretnych slajdach bez wpływu na inne?**

Tak. Zastosuj blokady tylko do kształtów na wybranych slajdach. Nie zmieni to ustawień blokad na pozostałych slajdach.

**Jak mogę zastosować blokady do poszczególnych kształtów wewnątrz grupy?**

Iteruj kolekcję zwróconą przez metodę [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) grupy i zastosuj odpowiednie blokady do każdego kształtu podrzędnego. Powtórz to dla wszelkich zagnieżdżonych grup. Powyższe przykłady przetwarzają tylko kolekcję kształtów slajdu, więc nie ustawiają blokad na pojedynczych elementach grupy.