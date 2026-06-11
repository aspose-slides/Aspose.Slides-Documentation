---
title: Zapobieganie edycjom prezentacji przy użyciu blokad kształtów w .NET
linktitle: Zapobieganie edycjom prezentacji
type: docs
weight: 70
url: /pl/net/applying-protection-to-presentation/
keywords:
- zapobiegać edycjom
- chronić przed edycją
- blokada kształtu
- blokada położenia
- blokada wyboru
- blokada rozmiaru
- blokada grupowania
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak Aspose.Slides dla .NET blokuje i odblokowuje kształty w plikach PPT, PPTX i ODP, zabezpieczając prezentacje, jednocześnie umożliwiając kontrolowaną edycję."
---
## **Tło**

Częstym zastosowaniem Aspose.Slides jest tworzenie, aktualizowanie i zapisywanie prezentacji Microsoft PowerPoint (PPTX) w ramach zautomatyzowanego przepływu pracy. Użytkownicy aplikacji wykorzystujących Aspose.Slides w ten sposób mają dostęp do wygenerowanych prezentacji, więc ochronę przed edycją stanowi powszechny problem. Ważne jest, aby automatycznie generowane prezentacje zachowały pierwotne formatowanie i zawartość.

W tym artykule wyjaśniono, jak zbudowane są prezentacje i slajdy oraz jak Aspose.Slides dla .NET może zastosować ochronę prezentacji i później ją usunąć. Dostarcza on programistom sposób kontrolowania sposobu użycia prezentacji generowanych przez ich aplikacje.

## **Budowa slajdu**

Slajd prezentacji składa się z komponentów, takich jak autoshapes, tabele, obiekty OLE, grupowane kształty, ramki obrazów, ramki wideo, łączniki i inne elementy używane do tworzenia prezentacji. W Aspose.Slides dla .NET każdy element na slajdzie jest reprezentowany przez obiekt implementujący interfejs [IShape](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/) lub dziedziczący po klasie, która to robi.

Struktura PPTX jest złożona, więc w przeciwieństwie do PPT, gdzie można używać ogólnego blokowania dla wszystkich typów kształtów, różne typy kształtów wymagają różnych blokad. Interfejs [IBaseShapeLock](https://reference.aspose.com/slides/pl/net/aspose.slides/ibaseshapelock/) jest ogólną klasą blokującą dla PPTX. W Aspose.Slides dla .NET obsługiwane są następujące typy blokad dla PPTX:

- [IAutoShapeLock](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshapelock/) blokuje autoshapes.  
- [IConnectorLock](https://reference.aspose.com/slides/pl/net/aspose.slides/iconnectorlock/) blokuje kształty łączników.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/pl/net/aspose.slides/igraphicalobjectlock/) blokuje obiekty graficzne.  
- [IGroupShapeLock](https://reference.aspose.com/slides/pl/net/aspose.slides/igroupshapelock/) blokuje grupowane kształty.  
- [IPictureFrameLock](https://reference.aspose.com/slides/pl/net/aspose.slides/ipictureframelock/) blokuje ramki obrazów.  

Każda akcja wykonana na wszystkich obiektach kształtów w obiekcie [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) jest stosowana do całej prezentacji.

## **Zastosowanie i usunięcie ochrony**

Zastosowanie ochrony zapewnia, że prezentacja nie może być edytowana. Jest to przydatna technika ochrony zawartości prezentacji.

### **Zastosowanie ochrony do kształtów PPTX**

Aspose.Slides dla .NET udostępnia interfejs [IShape](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/) do pracy z kształtami na slajdzie.

Jak wspomniano wcześniej, każda klasa kształtu ma powiązaną klasę blokady kształtu w celu ochrony. Ten artykuł koncentruje się na blokadach NoSelect, NoMove i NoResize. Blokady te zapewniają, że kształty nie mogą być wybierane (przez kliknięcia myszy lub inne metody zaznaczania) oraz że nie mogą być przemieszczane ani zmieniane ich rozmiary.

Przykład kodu poniżej stosuje ochronę do wszystkich typów kształtów w prezentacji.

```cs
// Utwórz klasę Presentation, która reprezentuje plik PPTX.
using Presentation presentation = new Presentation("Sample.pptx");

// Przeglądanie wszystkich slajdów w prezentacji.
foreach (ISlide slide in presentation.Slides)
{
    // Iterowanie po wszystkich kształtach na slajdzie.
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = true;
            autoShape.ShapeLock.SelectLocked = true;
            autoShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = true;
            groupShape.ShapeLock.PositionLocked = true;
            groupShape.ShapeLock.SelectLocked = true;
            groupShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = true;
            connectorShape.ShapeLock.SelectLocked = true;
            connectorShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = true;
            pictureFrame.ShapeLock.SelectLocked = true;
            pictureFrame.ShapeLock.SizeLocked = true;
        }
    }
}

// Zapisywanie pliku prezentacji.
presentation.Save("ProtectedSample.pptx", SaveFormat.Pptx);
```

### **Usunięcie ochrony**

Aby odblokować kształt, ustaw wartość zastosowanej blokady na `false`. Poniższy przykład kodu pokazuje, jak odblokować kształty w zablokowanej prezentacji.

```cs
// Utwórz klasę Presentation, która reprezentuje plik PPTX.
using Presentation presentation = new Presentation("ProtectedSample.pptx");

// Przeglądanie wszystkich slajdów w prezentacji.
foreach (ISlide slide in presentation.Slides)
{
    // Przeglądanie wszystkich kształtów na slajdzie.
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = false;
            autoShape.ShapeLock.SelectLocked = false;
            autoShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = false;
            groupShape.ShapeLock.PositionLocked = false;
            groupShape.ShapeLock.SelectLocked = false;
            groupShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = false;
            connectorShape.ShapeLock.SelectLocked = false;
            connectorShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = false;
            pictureFrame.ShapeLock.SelectLocked = false;
            pictureFrame.ShapeLock.SizeLocked = false;
        }
    }
}

// Zapisywanie pliku prezentacji.
presentation.Save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
```

### **Wnioski**

Aspose.Slides oferuje kilka opcji ochrony kształtów w prezentacji. Możesz zablokować pojedynczy kształt lub iterować po wszystkich kształtach w prezentacji i zablokować każdy z nich, aby skutecznie zabezpieczyć cały plik. Ochronę można usunąć, ustawiając wartość blokady na `false`.

## **FAQ**

**Czy mogę łączyć blokady kształtów i ochronę hasłem w tej samej prezentacji?**

Tak. Blokady ograniczają edycję obiektów wewnątrz pliku, podczas gdy [password protection](/slides/pl/net/password-protected-presentation/) kontroluje dostęp do otwierania i/lub zapisywania zmian. Te mechanizmy uzupełniają się i działają razem.

**Czy mogę ograniczyć edycję na konkretnych slajdach bez wpływu na inne?**

Tak. Zastosuj blokady do kształtów na wybranych slajdach; pozostałe slajdy pozostaną edytowalne.

**Czy blokady kształtów dotyczą grupowanych obiektów i łączników?**

Tak. Obsługiwane są dedykowane typy blokad dla grup, łączników, obiektów graficznych i innych rodzajów kształtów.