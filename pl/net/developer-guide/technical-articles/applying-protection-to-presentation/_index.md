---
title: Ogranicz edycję prezentacji przy użyciu blokad kształtów w .NET
linktitle: Ogranicz edycję prezentacji
type: docs
weight: 70
url: /pl/net/applying-protection-to-presentation/
keywords:
- zapobiegać edycji
- chronić przed edycją
- zablokuj kształt
- zablokuj pozycję
- zablokuj wybór
- zablokuj zmianę rozmiaru
- zablokuj grupowanie
- PowerPoint
- PPTX
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak blokować i odblokowywać kształty w prezentacjach PPTX za pomocą Aspose.Slides dla .NET, aby ograniczyć wybór, przemieszczanie, zmianę rozmiaru i grupowanie."
---
## **Tło**

Typowym zastosowaniem Aspose.Slides for .NET jest tworzenie, aktualizacja i zapisywanie prezentacji PowerPoint (PPTX) w ramach zautomatyzowanego przepływu pracy. Gdy użytkownicy otrzymują te prezentacje, ograniczenie zmian kształtów może pomóc zachować zamierzony układ i zawartość.

Ten artykuł wyjaśnia, jak kształty są organizowane na slajdach oraz jak zastosować i usunąć blokady kształtów w prezentacji PPTX. Te blokady umożliwiają ograniczenie konkretnych operacji edycji na poszczególnych kształtach.

## **Kompozycja slajdu**

Slajd prezentacji składa się z elementów takich jak autokształty, tabele, obiekty OLE, grupowane kształty, ramki obrazu, ramki wideo, łącza i inne elementy używane do budowy prezentacji. W Aspose.Slides for .NET każdy element na slajdzie jest reprezentowany przez obiekt, który implementuje interfejs [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) lub dziedziczy z klasy, która to robi.

Różne typy kształtów udostępniają różne opcje blokowania. Interfejs [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) jest podstawowym interfejsem dla blokad kształtów. Aspose.Slides for .NET udostępnia następujące interfejsy blokad:

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) blokuje autokształty.  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) blokuje kształty łączników.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) blokuje obiekty graficzne.  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) blokuje grupowane kształty.  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) blokuje ramki obrazu.  

Aby zastosować blokady w całej [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), przeiteruj jej slajdy i ustaw odpowiednie blokady na każdym obsługiwanym kształcie.

## **Zastosowanie i usunięcie ochrony**

Blokady kształtów ograniczają operacje takie jak wybieranie, przenoszenie i zmiana rozmiaru kształtów. Nie sprawiają, że cała prezentacja jest nieedytowalna.

### **Zastosowanie ochrony do kształtów PPTX**

Aspose.Slides for .NET udostępnia interfejs [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) do pracy z kształtami na slajdzie.

Przykład ustawia [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/), [PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/) i [SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) na `true` dla autokształtów, z równoważnymi blokadami dla grupowanych kształtów, łączników i ramek obrazu. Łączniki używają [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) do przemieszczania; grupy również używają [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) aby ograniczyć grupowanie.

Przykład ładuje istniejącą prezentację PPTX, sprawdza kształty w kolekcji kształtów każdego slajdu i zapisuje kopię z zastosowanymi ograniczeniami. Kształty nie należące do czterech obsługiwanych typów pozostają niezmienione. Pętla nie przegląda kształtów podrzędnych wewnątrz grupy.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
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

presentation.Save("ProtectedSample.pptx", SaveFormat.Pptx);
```

### **Usunięcie ochrony**

Aby usunąć blokadę kształtu, ustaw jej wartość na `false`. Poniższy przykład ładuje prezentację z blokadami kształtów i usuwa ograniczenia wyboru, przemieszczania i zmiany rozmiaru za pomocą [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) oraz [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/). Usuwa również [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) i zapisuje kopię prezentacji. Inne ustawienia blokad pozostają niezmienione.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ProtectedSample.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
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

presentation.Save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
```

### **Podsumowanie**

Aspose.Slides for .NET umożliwia ograniczenie konkretnych operacji edycji na pojedynczych kształtach lub zastosowanie tych samych ograniczeń na wielu slajdach. Wybierz blokady obsługiwane przez dany typ kształtu i ustaw ich wartości na `false`, gdy potrzebujesz usunąć te ograniczenia.

## **FAQ**

**Czy mogę połączyć blokady kształtów i ochronę hasłem w tej samej prezentacji?**

Tak. Blokady kształtów ograniczają określone operacje edycji, podczas gdy [password protection](/slides/pl/net/password-protected-presentation/) może ograniczyć otwieranie lub modyfikację prezentacji. Możesz używać obu w tym samym pliku.

**Czy mogę ograniczyć edycję na konkretnych slajdach, nie wpływając na inne?**

Tak. Zastosuj blokady tylko do kształtów na wybranych slajdach. Nie zmieni to ustawień blokad na innych slajdach.

**Jak mogę zastosować blokady do poszczególnych kształtów wewnątrz grupy?**

Iteruj przez kolekcję [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) grupy i zastosuj odpowiednie blokady do każdego kształtu podrzędnego. Powtórz to dla wszystkich zagnieżdżonych grup. Powyższe przykłady przetwarzają tylko kolekcję kształtów slajdu, więc nie ustawiają blokad na poszczególnych elementach grupy.