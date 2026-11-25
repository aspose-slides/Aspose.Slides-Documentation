---
title: Ogranicz edycję prezentacji za pomocą blokad kształtów w .NET
linktitle: Ogranicz edycję prezentacji
type: docs
weight: 70
url: /pl/net/applying-protection-to-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak blokować i odblokowywać kształty w prezentacjach PPTX przy użyciu Aspose.Slides dla .NET, aby ograniczyć wybór, przemieszczanie, zmianę rozmiaru i grupowanie."
---
## **Tło**

Typowym zastosowaniem Aspose.Slides dla .NET jest tworzenie, aktualizowanie i zapisywanie prezentacji PowerPoint (PPTX) w ramach zautomatyzowanego przepływu pracy. Gdy użytkownicy otrzymują te prezentacje, ograniczenie zmian kształtów może pomóc zachować zamierzony układ i treść.

Ten artykuł wyjaśnia, jak kształty są organizowane na slajdach oraz jak zastosować i usunąć blokady kształtów w prezentacji PPTX. Te blokady pozwalają ograniczyć określone operacje edycyjne dla pojedynczych kształtów.

## **Budowa slajdu**

Slajd prezentacji składa się z elementów takich jak autokształty, tabele, obiekty OLE, grupowane kształty, ramki obrazu, ramki wideo, łączniki i inne elementy wykorzystywane do budowy prezentacji. W Aspose.Slides dla .NET każdy element na slajdzie jest reprezentowany przez obiekt implementujący interfejs [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) lub dziedziczący po klasie, która go implementuje.

Różne typy kształtów udostępniają różne opcje blokowania. Interfejs [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) jest podstawowym interfejsem dla blokad kształtów. Aspose.Slides dla .NET oferuje następujące interfejsy blokad:

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) blokuje autokształty.  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) blokuje kształty łączników.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) blokuje obiekty graficzne.  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) blokuje grupowane kształty.  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) blokuje ramki obrazu.  

Aby zastosować blokady w całej [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), przeiteruj slajdy i ustaw odpowiednie blokady dla każdego obsługiwanego kształtu.

## **Zastosowanie i usunięcie ochrony**

Kompatybilne edytory prezentacji używają blokad kształtów do ograniczania poszczególnych operacji edycyjnych. Szyfrowanie pliku i ochrona zapisu na poziomie dokumentu to odrębne [presentation protection settings](/slides/pl/net/password-protected-presentation/).

### **Zastosowanie ochrony do kształtów PPTX**

Aspose.Slides dla .NET udostępnia interfejs [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) do pracy z kształtami na slajdzie.

Przykład ustawia [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/), [PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/) i [SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) na `true` dla autokształtów, a analogiczne blokady dla grupowanych kształtów, łączników i ramek obrazu. Łączniki używają [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) do przemieszczania; grupy dodatkowo używają [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) do ograniczenia grupowania.

Przykład ładuje istniejącą prezentację PPTX, sprawdza kształty w kolekcji kształtów każdego slajdu i zapisuje kopię z zastosowanymi ograniczeniami. Kształty spoza czterech obsługiwanych typów pozostają niezmienione. Pętla nie przeszukuje kształtów podrzędnych znajdujących się wewnątrz grupy.

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

Aby usunąć blokadę kształtu, ustaw jej wartość na `false`. Poniższy przykład ładuje prezentację z blokadami kształtów i usuwa ograniczenia wyboru, przemieszczania i zmiany rozmiaru za pomocą [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) oraz [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/). Usuwa także [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) i zapisuje kopię prezentacji. Inne ustawienia blokad pozostają niezmienione.

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

### **Zachowanie przycięcia obrazu**

Umieść zdjęcie o nazwie `photo.jpg` w katalogu roboczym. Przykład przycina 12 % od lewej i 8 % od prawej, a następnie ustawia [CropLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/croplocked/) na ramce obrazu. Flaga ta uniemożliwia dalsze przycinanie i zachowuje istniejące przycięcie.

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var photoBytes = File.ReadAllBytes("photo.jpg");
var photo = presentation.Images.AddImage(photoBytes);

var pictureFrame = shapes.AddPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo);
pictureFrame.PictureFormat.CropLeft = 12;
pictureFrame.PictureFormat.CropRight = 8;
pictureFrame.PictureFrameLock.AspectRatioLocked = false;
pictureFrame.PictureFrameLock.CropLocked = true;

presentation.Save("PictureLocked.pptx", SaveFormat.Pptx);
```

`PictureLocked.pptx` zapisuje blokadę przycięcia jako `true`. W PowerPoint polecenie **Crop** jest wyłączone, gdy zdjęcie jest zaznaczone.

### **Utrzymanie diagramu w grupie**

Przykład grupuje prostokąt i strzałkę, a następnie ustawia [UngroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/ungroupinglocked/) na samej grupie, aby utrzymać elementy diagramu razem. Inne edycje, takie jak przemieszczanie grupy czy zmiana wypełnienia komponentu, pozostają dostępne.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var groupShape = shapes.AddGroupShape();
groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 70, 90, 50);
groupShape.Shapes.AddAutoShape(ShapeType.RightArrow, 190, 80, 60, 30);
groupShape.GroupShapeLock.UngroupingLocked = true;

presentation.Save("DiagramLocked.pptx", SaveFormat.Pptx);
```

`DiagramLocked.pptx` zapisuje blokadę rozgrupowania jako `true`. W PowerPoint polecenie **Ungroup** jest wyłączone, gdy cały diagram jest zaznaczony.

### **Raportowanie istniejących blokad kształtów**

Aby przejrzeć szablon, otwórz go i odczytaj obiekt blokady dla każdego kształtu. [NoLocks](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/nolocks/) jest `true`, gdy wszystkie flagi tego obiektu są wyłączone, oraz `false`, gdy przynajmniej jedna jest włączona. Grupa i jej elementy potomne mają osobne obiekty blokad, więc należy sprawdzać elementy potomne nawet wtedy, gdy grupa nie ma blokad.

Przykład sprawdza ruch autokształtów, ramek obrazu i grup, przycinanie obrazów oraz rozgrupowanie grup. Raportuje rozpoznane flagi i oznacza typy kształtów, których nie analizuje.

```cs
using System;
using System.Collections.Generic;
using Aspose.Slides;

using var presentation = new Presentation("Sample.pptx");
foreach (var slide in presentation.Slides)
{
    Inspect(slide.Shapes, slide.SlideNumber, "");
}

static void Inspect(IShapeCollection shapes, int slideNumber, string prefix)
{
    foreach (var shape in shapes)
    {
        var path = prefix + shape.Name;
        var label = $"Slide {slideNumber} | {path} | {shape.GetType().Name}";
        var flags = new List<string>();
        IBaseShapeLock shapeLock;

        switch (shape)
        {
            case IGroupShape group:
                shapeLock = group.ShapeLock;
                if (group.ShapeLock.UngroupingLocked) flags.Add("UngroupingLocked");
                if (group.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            case IPictureFrame picture:
                shapeLock = picture.ShapeLock;
                if (picture.ShapeLock.CropLocked) flags.Add("CropLocked");
                if (picture.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            case IAutoShape autoShape:
                shapeLock = autoShape.ShapeLock;
                if (autoShape.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            default:
                Console.WriteLine($"{label} | Uninspected");
                continue;
        }

        if (!shapeLock.NoLocks)
        {
            var restrictions = flags.Count > 0 ? string.Join(", ", flags) : "Active flag not identified";
            Console.WriteLine($"{label} | {restrictions}");
        }

        if (shape is IGroupShape parent)
            Inspect(parent.Shapes, slideNumber, path + "/");
    }
}
```

Załóżmy, że slajd 1 pliku `Sample.pptx` zawiera grupę o nazwie `Layout` z blokadą rozgrupowania, obraz o nazwie `Photo` wewnątrz niej z blokadą przycięcia oraz prostokąt o nazwie `Free` bez blokad. Raport pomija `Free` i wypisuje dwa następujące wiersze:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Raport odczytuje zapisane flagi edycji na poziomie kształtu bez ich zmieniania i bez zapisywania prezentacji. Ochrona zapisu na poziomie dokumentu to odrębne ustawienie, a egzekucja każdej flagi zależy od edytora.

### **Podsumowanie**

Aspose.Slides dla .NET pozwala ograniczyć określone operacje edycyjne na pojedynczych kształtach lub zastosować te same ograniczenia na wielu slajdach. Wybierz blokady wspierane przez dany typ kształtu i ustaw ich wartości na `false`, gdy potrzebujesz usunąć te ograniczenia.

## **FAQ**

**Czy mogę łączyć blokady kształtów i ochronę hasłem w tej samej prezentacji?**

Tak. Blokady kształtów ograniczają konkretne operacje edycyjne, natomiast [password protection](/slides/pl/net/password-protected-presentation/) może ograniczyć otwieranie lub modyfikowanie prezentacji. Można używać obu w jednym pliku.

**Czy mogę ograniczyć edycję na konkretnych slajdach bez wpływu na inne?**

Tak. Zastosuj blokady tylko do kształtów na wybranych slajdach. Nie zmieni to ustawień blokad na pozostałych slajdach.

**Jak mogę zastosować blokady do pojedynczych kształtów wewnątrz grupy?**

Iteruj kolekcję [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) grupy i zastosuj odpowiednie blokady do każdego kształtu podrzędnego. Powtórz to dla wszystkich zagnieżdżonych grup, postępując zgodnie z przeglądem w przykładzie raportowania.