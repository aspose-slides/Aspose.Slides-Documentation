---
title: Limita le modifiche alla presentazione con i blocchi delle forme in C++
linktitle: Limita le modifiche alla presentazione
type: docs
weight: 10
url: /it/cpp/applying-protection-to-presentation/
keywords:
- impedire modifiche
- proteggere dalla modifica
- bloccare forma
- bloccare posizione
- bloccare selezione
- bloccare ridimensionamento
- bloccare raggruppamento
- PowerPoint
- PPTX
- presentazione
- C++
- Aspose.Slides
description: "Scopri come bloccare e sbloccare le forme nelle presentazioni PPTX con Aspose.Slides per C++ per limitare la selezione, lo spostamento, il ridimensionamento e il raggruppamento."
---
## **Contesto**

Un uso comune di Aspose.Slides per C++ è creare, aggiornare e salvare presentazioni PowerPoint (PPTX) come parte di un flusso di lavoro automatizzato. Quando gli utenti ricevono queste presentazioni, limitare le modifiche alle forme può aiutare a preservare il layout e il contenuto previsti.

Questo articolo spiega come le forme sono organizzate nelle diapositive e come applicare e rimuovere i blocchi delle forme in una presentazione PPTX. Questi blocchi consentono di limitare operazioni di modifica specifiche su singole forme.

## **Composizione di una diapositiva**

Una diapositiva di una presentazione è composta da componenti quali autoshape, tabelle, oggetti OLE, forme raggruppate, cornici immagine, cornici video, connettori e altri elementi utilizzati per creare una presentazione. In Aspose.Slides per C++, ogni elemento su una diapositiva è rappresentato da un oggetto che implementa l'interfaccia [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) o eredita da una classe che lo fa.

Tipi diversi di forme offrono opzioni di blocco differenti. L'interfaccia [IBaseShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/) è l'interfaccia di base per i blocchi delle forme. Aspose.Slides per C++ fornisce le seguenti interfacce di blocco:

- [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/) blocca le autoshape.
- [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) blocca le forme connettore.
- [IGraphicalObjectLock](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/) blocca gli oggetti grafici.
- [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/) blocca le forme raggruppate.
- [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) blocca le cornici immagine.

Per applicare i blocchi a una [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), iterare tra le sue diapositive e impostare i blocchi appropriati su ogni forma supportata.

## **Applicare e rimuovere la protezione**

I blocchi delle forme limitano operazioni come la selezione, lo spostamento e il ridimensionamento delle forme. Non rendono l'intera presentazione non modificabile.

### **Applicare la protezione alle forme PPTX**

Aspose.Slides per C++ fornisce l'interfaccia [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) per lavorare con le forme su una diapositiva.

L'esempio passa `true` a [set_SelectLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_selectlocked/), [set_PositionLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_positionlocked/) e [set_SizeLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_sizelocked/) per le autoshape, con blocchi equivalenti per le forme raggruppate, i connettori e le cornici immagine. I connettori usano [set_PositionMove](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/set_positionmove/) per lo spostamento; i gruppi usano anche [set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) per limitare il raggruppamento.

L'esempio carica una presentazione PPTX esistente, verifica le forme nella raccolta forme di ciascuna diapositiva e salva una copia con queste restrizioni applicate. Le forme al di fuori dei quattro tipi gestiti rimangono inalterate. Il ciclo non attraversa le forme figlio all'interno di un gruppo.

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

### **Rimuovere la protezione**

Per rimuovere un blocco di una forma, impostare il suo valore a `false`. Il seguente esempio carica una presentazione con blocchi delle forme e cancella le restrizioni di selezione, spostamento e ridimensionamento tramite [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) e [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/). Cancella anche [IGroupShapeLock::set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) e salva una copia della presentazione. Le altre impostazioni di blocco rimangono inalterate.

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

### **Conclusione**

Aspose.Slides per C++ permette di limitare operazioni di modifica specifiche su singole forme o di applicare le stesse restrizioni su più diapositive. Scegli i blocchi supportati da ciascun tipo di forma e imposta i loro valori a `false` quando è necessario rimuovere tali restrizioni.

## **FAQ**

**Posso combinare i blocchi delle forme e la protezione con password nella stessa presentazione?**

Sì. I blocchi delle forme limitano operazioni di modifica specifiche, mentre la [protezione con password](/slides/it/cpp/password-protected-presentation/) può limitare l'apertura o la modifica della presentazione. È possibile utilizzare entrambi nello stesso file.

**Posso limitare la modifica su diapositive specifiche senza influire su altre?**

Sì. Applica i blocchi solo alle forme delle diapositive selezionate. Questo non modifica le impostazioni di blocco delle altre diapositive.

**Come posso applicare i blocchi a singole forme all'interno di un gruppo?**

Itera attraverso la collezione restituita dal metodo [get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/get_shapes/) del gruppo e applica i blocchi appropriati a ciascuna forma figlia. Ripeti l'operazione per eventuali gruppi nidificati. Gli esempi sopra elaborano solo la collezione forme della diapositiva, quindi non impostano blocchi sui singoli membri del gruppo.