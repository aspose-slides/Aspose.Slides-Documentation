---
title: Proteggi le presentazioni da scrittura in C++
linktitle: Protezione da scrittura
type: docs
weight: 25
url: /it/cpp/write-protected-presentation/
keywords:
- protezione da scrittura
- protezione da scrittura PowerPoint
- password per modificare
- limitare la modifica della presentazione
- rimuovere la protezione da scrittura
- convalidare la password di modifica
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Imposta, rileva, convalida e rimuovi le password di protezione da scrittura nelle presentazioni PowerPoint PPT e PPTX usando Aspose.Slides per C++."
---
## **Introduzione**

Una password di protezione dalla scrittura limita la modifica di una presentazione ma non cripta il suo contenuto. Gli utenti possono caricare e visualizzare una presentazione protetta dalla scrittura senza la password. A seconda dell'applicazione, potrebbero anche essere in grado di modificare il contenuto e salvarlo con un nome diverso, quindi la protezione dalla scrittura non deve essere considerata un meccanismo di riservatezza.

Una password di apertura ha uno scopo diverso: cripta la presentazione ed è necessaria per caricare il suo contenuto. Per crittografare una presentazione o convalidare una password di apertura, vedere [Presentazioni protette da password](/slides/it/cpp/password-protected-presentation/).

I flussi di lavoro in questo articolo si applicano sia alle presentazioni PPT sia a quelle PPTX. Gli esempi usano file PPTX; quando si salva in PPT, utilizzare l'estensione `.ppt` e il relativo formato di salvataggio PPT.

## **Imposta la protezione dalla scrittura su una presentazione**

Utilizzare [IProtectionManager::SetWriteProtection](https://reference.aspose.com/slides/it/cpp/aspose.slides/iprotectionmanager/setwriteprotection/) per assegnare una password alla modifica di una presentazione. Il salvataggio della presentazione mantiene l'impostazione di protezione.

Il seguente esempio imposta la protezione dalla scrittura su una presentazione PPTX:

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"modify_password");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **Carica una presentazione protetta dalla scrittura**

Poiché la protezione dalla scrittura non cripta il contenuto della presentazione, non è necessaria alcuna password per caricare la presentazione. La password è rilevante solo quando si convalida l'autorizzazione a modificare la presentazione protetta.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"write-protected-pres.pptx");

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());
```

Non passare una password di protezione dalla scrittura a [LoadOptions::set_Password](https://reference.aspose.com/slides/it/cpp/aspose.slides/loadoptions/set_password/). Tale proprietà accetta una password di apertura per contenuti criptati. Se una presentazione ha entrambi i tipi di protezione, fornire la password di apertura per caricarla e gestire separatamente la password di protezione dalla scrittura.

## **Rimuovi la protezione dalla scrittura da una presentazione**

Utilizzare [IProtectionManager::RemoveWriteProtection](https://reference.aspose.com/slides/it/cpp/aspose.slides/iprotectionmanager/removewriteprotection/) per rimuovere la restrizione di modifica, quindi salvare la presentazione.

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"write-protected-pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **Verifica se una presentazione è protetta dalla scrittura**

Per ispezionare un file senza creare un'istanza completa di [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/), chiamare [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) e verificare [IPresentationInfo::get_IsWriteProtected](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentationinfo/get_iswriteprotected/). La proprietà utilizza [NullableBool](https://reference.aspose.com/slides/it/cpp/aspose.slides/nullablebool/) e restituisce `NullableBool::True` quando viene rilevata la protezione dalla scrittura.

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/NullableBool.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"write-protected-pres.pptx");

if (presentationInfo->get_IsWriteProtected() == NullableBool::True)
{
    Console::WriteLine(u"The presentation is write protected.");
}
else
{
    Console::WriteLine(u"Write protection was not detected.");
}
```

La sovraccarica stream di [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) fornisce le stesse informazioni per una presentazione fornita come flusso.

## **Convalida una password di protezione dalla scrittura**

Utilizzare [IPresentationInfo::CheckWriteProtection](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentationinfo/checkwriteprotection/) per convalidare una password di modifica senza caricare l'intera presentazione. Verificare prima [IPresentationInfo::get_IsWriteProtected](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentationinfo/get_iswriteprotected/) in modo che l'applicazione richieda o convalidi una password solo quando è presente la protezione dalla scrittura.

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/NullableBool.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"write-protected-pres.pptx");

if (presentationInfo->get_IsWriteProtected() != NullableBool::True)
{
    Console::WriteLine(u"The presentation is not write protected.");
}
else if (presentationInfo->CheckWriteProtection(u"modify_password"))
{
    Console::WriteLine(u"The write-protection password is correct.");
}
else
{
    Console::WriteLine(u"The write-protection password is incorrect.");
}
```

[IPresentationInfo::CheckWriteProtection](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentationinfo/checkwriteprotection/) convalida solo la password di protezione dalla scrittura. Non convalida una password di apertura né determina se il contenuto criptato può essere caricato. Al contrario, [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentationinfo/checkpassword/) convalida solo una password di apertura. Se una presentazione completa è già stata caricata, [IProtectionManager::CheckWriteProtection](https://reference.aspose.com/slides/it/cpp/aspose.slides/iprotectionmanager/checkwriteprotection/) fornisce il controllo di protezione dalla scrittura equivalente tramite il suo gestore di protezione.

Nelle applicazioni in produzione, non registrare le password né includerle nei messaggi diagnostici. Evitare tentativi di convalida ripetuti e non necessari, e conservare le password in memoria solo per il tempo strettamente necessario.

{{% alert color="info" title="Vedi anche" %}}
- [Presentazioni protette da password](/slides/it/cpp/password-protected-presentation/)
- [Presentazioni in sola lettura](/slides/it/cpp/read-only-presentation/)
- [Firma digitale in PowerPoint](/slides/it/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**La protezione dalla scrittura cripta una presentazione?**

No. Restringe la modifica ma lascia il contenuto della presentazione disponibile per il caricamento e la visualizzazione.

**La password di protezione dalla scrittura è necessaria per aprire una presentazione?**

No. È necessaria solo una password di apertura per caricare il contenuto della presentazione crittografata.

**Una presentazione può avere sia una password di apertura sia una password di protezione dalla scrittura?**

Sì. Fornire la password di apertura attraverso le opzioni di caricamento per aprire la presentazione crittografata e convalidare separatamente la password di protezione dalla scrittura quando è necessaria l'autorizzazione alla modifica.