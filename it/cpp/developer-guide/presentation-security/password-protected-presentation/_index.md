---
title: Presentazioni protette da password in C++
linktitle: Protezione con password
type: docs
weight: 20
url: /it/cpp/password-protected-presentation/
keywords:
- presentazione protetta da password
- password di apertura
- cifrare PowerPoint
- decrittare PowerPoint
- convalidare la password della presentazione
- verificare la password della presentazione
- aprire presentazione crittografata
- rimuovere la crittografia
- PowerPoint
- PPT
- PPTX
- presentazione
- C++
- Aspose.Slides
description: "Cifra, rileva, convalida, apri e decritta le presentazioni PowerPoint PPT e PPTX protette da password in C++ con Aspose.Slides."
---
## **Panoramica**

Una password di apertura crittografa una presentazione. La password corretta è necessaria per caricare e visualizzare il contenuto della presentazione, quindi questa protezione garantisce la riservatezza.

Una password di apertura è diversa da una password di protezione in scrittura. La protezione in scrittura limita le modifiche ma non crittografa il contenuto né impedisce il caricamento della presentazione. Per gestire le password per la modifica delle presentazioni, vedere [Proteggi le presentazioni in scrittura](/slides/it/cpp/write-protected-presentation/).

I flussi di lavoro di seguito si applicano sia alle presentazioni PPT che PPTX. Gli esempi utilizzano entrambi i formati dove il loro comportamento basato su file e su stream è importante.

## **Crittografa una presentazione con una password di apertura**

Usa [IProtectionManager::Encrypt](https://reference.aspose.com/slides/it/cpp/aspose.slides/iprotectionmanager/encrypt/) per assegnare una password di apertura. Quindi usa [IPresentation::Save](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentation/save/) per salvare la presentazione crittografata.

L'esempio seguente crittografa una presentazione PPTX:

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"open_password");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **Carica una presentazione crittografata**

Imposta [LoadOptions::set_Password](https://reference.aspose.com/slides/it/cpp/aspose.slides/loadoptions/set_password/) alla password di apertura e passa le opzioni a [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) durante il caricamento del file. Il caricamento fallisce quando è richiesta una password di apertura ma la password fornita è mancante o errata.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

// Lavorare con la presentazione decrittata.
```

## **Rimuovi la crittografia da una presentazione**

Carica la presentazione con la sua password di apertura, chiama [IProtectionManager::RemoveEncryption](https://reference.aspose.com/slides/it/cpp/aspose.slides/iprotectionmanager/removeencryption/), e salva il risultato. La presentazione salvata può quindi essere caricata senza password.

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **Convalida una password di apertura prima del caricamento**

Usa [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) per ottenere [IPresentationInfo](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentationinfo/) senza creare un'istanza completa della presentazione. Controlla [IPresentationInfo::get_IsPasswordProtected](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentationinfo/get_ispasswordprotected/) prima di richiedere o convalidare una password. Quando la protezione è presente, valida il valore fornito con [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentationinfo/checkpassword/).

### **Flusso di lavoro basato su percorso file**

L'esempio seguente convalida una password di apertura per un file PPTX, passa il valore convalidato a [LoadOptions::set_Password](https://reference.aspose.com/slides/it/cpp/aspose.slides/loadoptions/set_password/), e quindi carica la presentazione completa:

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

String filePath = u"protected-presentation.pptx";
String password = u"open_password";
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(filePath);

if (!presentationInfo->get_IsPasswordProtected())
{
    Console::WriteLine(u"The presentation does not have an opening password.");
}
else if (!presentationInfo->CheckPassword(password))
{
    Console::WriteLine(u"The opening password is incorrect.");
}
else
{
    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(password);
    auto presentation = MakeObject<Presentation>(filePath, loadOptions);

    Console::WriteLine(u"The presentation was validated and loaded successfully.");
}
```

### **Flusso di lavoro basato su stream**

La sovraccarico per stream di [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) fornisce lo stesso flusso di lavoro. Reimposta la posizione di uno stream ricercabile prima di caricare la presentazione completa da quello stream.

L'esempio seguente utilizza un file PPT:

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

String password = u"open_password";
auto presentationStream = File::OpenRead(u"protected-presentation.ppt");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(presentationStream);

if (!presentationInfo->get_IsPasswordProtected())
{
    Console::WriteLine(u"The presentation does not have an opening password.");
}
else if (!presentationInfo->CheckPassword(password))
{
    Console::WriteLine(u"The opening password is incorrect.");
}
else
{
    presentationStream->set_Position(0);

    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(password);
    auto presentation = MakeObject<Presentation>(presentationStream, loadOptions);

    Console::WriteLine(u"The presentation was validated and loaded successfully.");
}
```

### **Valori di ritorno di CheckPassword**

[IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentationinfo/checkpassword/) restituisce `true` solo quando la presentazione ha una password di apertura e la password fornita è corretta. Restituisce `false` in ciascuno di questi casi:

- La password è errata.
- La presentazione non ha una password di apertura.
- La password fornita è nulla o vuota.

Il comportamento è lo stesso per le presentazioni PPT e PPTX.

## **Verifica se una presentazione caricata è crittografata**

Dopo aver caricato una presentazione con la password corretta, ispeziona [IProtectionManager::get_IsEncrypted](https://reference.aspose.com/slides/it/cpp/aspose.slides/iprotectionmanager/get_isencrypted/) per confermare che la presentazione di origine fosse crittografata. Per individuare la protezione con password di apertura prima del caricamento, usa `IPresentationInfo::get_IsPasswordProtected` come mostrato sopra.

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");
auto presentation = MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
Console::WriteLine(isEncrypted ? u"The presentation is encrypted." : u"The presentation is not encrypted.");
```

## **Raccomandazioni sulla sicurezza**

{{% alert color="warning" title="Sicurezza" %}}
Non registrare le password di apertura né includerle nei messaggi diagnostici. Evita tentativi di convalida ripetuti non necessari, mantieni le password in memoria solo per il tempo necessario e riutilizza un risultato di convalida riuscito quando si carica immediatamente la presentazione.
{{% /alert %}}

## **Proteggi con password una presentazione online**

1. Apri l'applicazione [Aspose.Slides Lock](https://products.aspose.app/slides/it/lock).
1. Seleziona o carica la presentazione.
1. Inserisci una password per la protezione della visualizzazione.
1. Facoltativamente inserisci una password separata per la protezione della modifica.
1. Applica la protezione e scarica il file risultante.

{{% alert color="info" title="Vedi anche" %}}
- [Proteggi le presentazioni in scrittura](/slides/it/cpp/write-protected-presentation/)
- [Firma digitale in PowerPoint](/slides/it/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Qual è la differenza tra una password di apertura e una password di protezione in scrittura?**

Una password di apertura crittografa la presentazione ed è necessaria per caricare il suo contenuto. Una password di protezione in scrittura limita le modifiche senza crittografare il contenuto.

**Posso convalidare una password di apertura senza caricare tutte le diapositive?**

Sì. Ottieni le informazioni della presentazione, verifica se è presente la protezione con password di apertura e valida la password prima di creare un'istanza completa della presentazione.

**Il flusso di lavoro di controllo della password supporta sia PPT che PPTX?**

Sì. Il rilevamento e la convalida della password basati su percorso file e su stream si comportano allo stesso modo per le presentazioni PPT e PPTX.