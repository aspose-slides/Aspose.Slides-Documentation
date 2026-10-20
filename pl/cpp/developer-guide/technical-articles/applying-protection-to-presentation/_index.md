---
title: Ogranicz edycję prezentacji za pomocą blokad kształtów w C++
linktitle: Ogranicz edycję prezentacji
type: docs
weight: 10
url: /pl/cpp/applying-protection-to-presentation/
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
- C++
- Aspose.Slides
description: "Dowiedz się, jak blokować i odblokowywać kształty w prezentacjach PPTX za pomocą Aspose.Slides dla C++, aby ograniczyć wybór, przemieszczanie, zmianę rozmiaru i grupowanie."
---
## **Tło**

Typowym zastosowaniem Aspose.Slides for C++ jest tworzenie, aktualizowanie i zapisywanie prezentacji PowerPoint (PPTX) jako część zautomatyzowanego przepływu pracy. Gdy użytkownicy otrzymują te prezentacje, ograniczenie zmian kształtów może pomóc zachować zamierzony układ i zawartość.

Ten artykuł wyjaśnia, jak kształty są organizowane na slajdach oraz jak zastosować i usunąć blokady kształtów w prezentacji PPTX. Te blokady pozwalają ograniczyć określone operacje edycji na poszczególnych kształtach.

## **Kompozycja slajdu**

Slajd prezentacji składa się z komponentów takich jak autokształty, tabele, obiekty OLE, grupowane kształty, ramki obrazu, ramki wideo, łączniki oraz inne elementy używane do budowy prezentacji. W Aspose.Slides for C++ każdy element na slajdzie jest reprezentowany przez obiekt implementujący interfejs [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) lub dziedziczący po klasie, która to robi.

Różne typy kształtów udostępniają różne opcje blokowania. Interfejs [IBaseShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/) jest podstawowym interfejsem dla blokad kształtów. Aspose.Slides for C++ udostępnia następujące interfejsy blokad:

- [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/) blokuje autokształty.
- [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) blokuje kształty łączników.
- [IGraphicalObjectLock](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/) blokuje obiekty graficzne.
- [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/) blokuje kształty grupowe.
- [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) blokuje ramki obrazu.

Aby zastosować blokady w całej [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), przeiteruj jej slajdy i ustaw odpowiednie blokady na każdym obsługiwanym kształcie.

## **Zastosowanie i usuwanie ochrony**

Blokady kształtów ograniczają operacje takie jak wybieranie, przemieszczanie i zmiana rozmiaru kształtów. Nie sprawiają, że cała prezentacja staje się nieedytowalna.

### **Zastosowanie ochrony do kształtów PPTX**

Aspose.Slides for C++ udostępnia interfejs [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/), aby pracować z kształtami na slajdzie.

Przykład przekazuje wartość `true` do metod [set_SelectLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_selectlocked/), [set_PositionLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_positionlocked/) i [set_SizeLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_sizelocked/) dla autokształtów, z odpowiednimi blokadami dla kształtów grupowych, łączników i ramek obrazu. Łączniki używają [set_PositionMove](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/set_positionmove/) do przemieszczania; grupy używają także [set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/), aby ograniczyć grupowanie.

Przykład ładuje istniejącą prezentację PPTX, sprawdza kształty w kolekcji kształtów każdego slajdu i zapisuje kopię z zastosowanymi ograniczeniami. Kształty poza czterema obsługiwanymi typami pozostają niezmienione. Pętla nie przechodzi przez kształty potomne wewnątrz grupy.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IAutoShapeLock.h>
#include <DOM/IConnector.h>
#include <DOM/IConnectorLock.h>
#include <DOM/IGroupShape.h>
#include <DOM/IGroupShapeLock.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : System::IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

            autoShapeLock->set_PositionLocked(true);
            autoShapeLock->set_SelectLocked(true);
            autoShapeLock->set_SizeLocked(true);
        }
        else if (ObjectExt::Is<IGroupShape>(shape))
        {
            auto groupShape = ExplicitCast<IGroupShape>(shape);
            auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

            groupShapeLock->set_GroupingLocked(true);
            groupShapeLock->set_PositionLocked(true);
            groupShapeLock->set_SelectLocked(true);
            groupShapeLock->set_SizeLocked(true);
        }
        else if (ObjectExt::Is<IConnector>(shape))
        {
            auto connectorShape = ExplicitCast<IConnector>(shape);
            auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());

            connectorShapeLock->set_PositionMove(true);
            connectorShapeLock->set_SelectLocked(true);
            connectorShapeLock->set_SizeLocked(true);
        }
        else if (ObjectExt::Is<IPictureFrame>(shape))
        {
            auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
            auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());

            pictureFrameLock->set_PositionLocked(true);
            pictureFrameLock->set_SelectLocked(true);
            pictureFrameLock->set_SizeLocked(true);
        }
    }
}

presentation->Save(u"ProtectedSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Usunięcie ochrony**

Aby usunąć blokadę kształtu, ustaw jej wartość na `false`. Poniższy przykład ładuje prezentację z blokadami kształtów i usuwa ograniczenia wyboru, przemieszczania i zmiany rozmiaru za pomocą [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/), i [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/). Usuwa także [IGroupShapeLock::set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) i zapisuje kopię prezentacji. Inne ustawienia blokad pozostają niezmienione.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IAutoShapeLock.h>
#include <DOM/IConnector.h>
#include <DOM/IConnectorLock.h>
#include <DOM/IGroupShape.h>
#include <DOM/IGroupShapeLock.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"ProtectedSample.pptx");

for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : System::IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

            autoShapeLock->set_PositionLocked(false);
            autoShapeLock->set_SelectLocked(false);
            autoShapeLock->set_SizeLocked(false);
        }
        else if (ObjectExt::Is<IGroupShape>(shape))
        {
            auto groupShape = ExplicitCast<IGroupShape>(shape);
            auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

            groupShapeLock->set_GroupingLocked(false);
            groupShapeLock->set_PositionLocked(false);
            groupShapeLock->set_SelectLocked(false);
            groupShapeLock->set_SizeLocked(false);
        }
        else if (ObjectExt::Is<IConnector>(shape))
        {
            auto connectorShape = ExplicitCast<IConnector>(shape);
            auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());

            connectorShapeLock->set_PositionMove(false);
            connectorShapeLock->set_SelectLocked(false);
            connectorShapeLock->set_SizeLocked(false);
        }
        else if (ObjectExt::Is<IPictureFrame>(shape))
        {
            auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
            auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());

            pictureFrameLock->set_PositionLocked(false);
            pictureFrameLock->set_SelectLocked(false);
            pictureFrameLock->set_SizeLocked(false);
        }
    }
}

presentation->Save(u"RemovedProtectionSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Wnioski**

Aspose.Slides for C++ pozwala ograniczyć określone operacje edycji na poszczególnych kształtach lub zastosować te same ograniczenia na wszystkich slajdach. Wybierz blokady obsługiwane przez dany typ kształtu i ustaw ich wartości na `false`, gdy potrzebujesz usunąć te ograniczenia.

## **FAQ**

**Czy mogę łączyć blokady kształtów i ochronę hasłem w tej samej prezentacji?**

Tak. Blokady kształtów ograniczają określone operacje edycji, podczas gdy [ochrona hasłem](/slides/pl/cpp/password-protected-presentation/) może ograniczyć otwieranie lub modyfikowanie prezentacji. Można używać obu w tym samym pliku.

**Czy mogę ograniczyć edycję na konkretnych slajdach bez wpływu na inne?**

Tak. Zastosuj blokady tylko do kształtów na wybranych slajdach. Nie zmienia to ustawień blokad na pozostałych slajdach.

**Jak mogę zastosować blokady do poszczególnych kształtów wewnątrz grupy?**

Iteruj po kolekcji zwróconej przez metodę [get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/get_shapes/) grupy i zastosuj odpowiednie blokady do każdego kształtu potomnego. Powtórz to dla wszystkich zagnieżdżonych grup. Powyższe przykłady przetwarzają tylko kolekcję kształtów slajdu, więc nie ustawiają blokad na poszczególnych elementach grupy.