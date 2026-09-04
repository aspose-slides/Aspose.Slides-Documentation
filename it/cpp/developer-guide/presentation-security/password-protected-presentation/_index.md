---
title: Presentazioni protette da password in C++
linktitle: Protezione con password
type: docs
weight: 20
url: /it/cpp/password-protected-presentation/
keywords:
- presentazione protetta da password
- password di apertura
- crittografare PowerPoint
- decrittografare PowerPoint
- convalidare password della presentazione
- verificare password della presentazione
- aprire presentazione crittografata
- rimuovere crittografia
- PowerPoint
- PPT
- PPTX
- presentazione
- C++
- Aspose.Slides
description: "Cifra, rileva, convalida, apri e decrittografa presentazioni PowerPoint PPT e PPTX protette da password in C++ con Aspose.Slides."
---
## **Panoramica**

Una password di apertura crittografa una presentazione. La password corretta è necessaria per caricare e visualizzare il contenuto della presentazione, quindi questa protezione fornisce riservatezza.

Una password di apertura è diversa da una password di protezione in scrittura. La protezione in scrittura limita le modifiche ma non cripta il contenuto né impedisce il caricamento della presentazione. Per gestire le password per la modifica delle presentazioni, vedere [Write-Protect Presentations](/slides/it/cpp/write-protected-presentation/).

I flussi di lavoro seguenti si applicano sia alle presentazioni PPT che PPTX. Gli esempi utilizzano entrambi i formati quando è importante il loro comportamento basato su file o su stream.

## **Crittografa una presentazione con una password di apertura**

Usa [IProtectionManager::Encrypt](https://reference.aspose.com/slides/it/cpp/aspose.slides/iprotectionmanager/encrypt/) per assegnare una password di apertura. Quindi usa [IPresentation::Save](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentation/save/) per salvare la presentazione crittografata.

Il seguente esempio cripta una presentazione PPTX:

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

## **Mantieni le proprietà del documento pubbliche**

Per impostazione predefinita, Aspose.Slides include le proprietà del documento nella crittografia della presentazione. [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/it/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/) controlla questo comportamento indipendentemente dalla crittografia del contenuto delle diapositive. Passa `false` a questo metodo prima di chiamare [IProtectionManager::Encrypt](https://reference.aspose.com/slides/it/cpp/aspose.slides/iprotectionmanager/encrypt/) quando un sistema di indicizzazione, classificazione, ricerca o gestione dei documenti deve leggere i metadati senza la password di apertura.

Il seguente esempio crea una presentazione PPTX crittografata lasciando pubbliche le sue proprietà di documento incorporate:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IProtectionManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto properties = presentation->get_DocumentProperties();
properties->set_Author(u"Contoso Knowledge Management");
properties->set_Title(u"Quarterly Product Roadmap");
properties->set_Keywords(u"roadmap, planning, internal");

presentation->get_Slide(0)->set_Name(u"Encrypted presentation content");
presentation->get_ProtectionManager()->set_EncryptDocumentProperties(false);
presentation->get_ProtectionManager()->Encrypt(u"open_password");
presentation->Save(u"public-properties-encrypted.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

Passare `false` a `set_EncryptDocumentProperties` non rende pubbliche diapositive, master, layout, forme, media o altro contenuto della presentazione. Influisce solo sulle proprietà del documento. Per leggere tali proprietà senza caricare il contenuto crittografato, vedere [Manage Presentation Properties](/slides/it/cpp/presentation-properties/).

## **Carica una presentazione crittografata**

Imposta [LoadOptions::set_Password](https://reference.aspose.com/slides/it/cpp/aspose.slides/loadoptions/set_password/) con la password di apertura e passa le opzioni a [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) durante il caricamento del file. Il caricamento fallisce quando è richiesta una password di apertura ma la password fornita è mancante o errata.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

// Lavora con la presentazione decrittografata.
```

## **Rimuovi la crittografia da una presentazione**

Carica la presentazione con la sua password di apertura, chiama [IProtectionManager::RemoveEncryption](https://reference.aspose.com/slides/it/cpp/aspose.slides/iprotectionmanager/removeencryption/) e salva il risultato. La presentazione salvata può quindi essere caricata senza password.

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

### **Flusso di lavoro con percorso file**

Il seguente esempio convalida una password di apertura per un file PPTX, passa il valore convalidato a [LoadOptions::set_Password](https://reference.aspose.com/slides/it/cpp/aspose.slides/loadoptions/set_password/), quindi carica la presentazione completa:

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

### **Flusso di lavoro con stream**

La sovraccarico stream di [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) fornisce lo stesso flusso di lavoro. Reimposta la posizione di uno stream ricercabile prima di caricare la presentazione completa da quello stream.

Il seguente esempio utilizza un file PPT:

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
- La password fornita è null o vuota.

Il comportamento è lo stesso per le presentazioni PPT e PPTX.

## **Verifica se una presentazione caricata è crittografata**

Dopo aver caricato una presentazione con la password corretta, controlla [IProtectionManager::get_IsEncrypted](https://reference.aspose.com/slides/it/cpp/aspose.slides/iprotectionmanager/get_isencrypted/) per confermare che la presentazione di origine fosse crittografata. Per rilevare la protezione con password di apertura prima del caricamento, usa `IPresentationInfo::get_IsPasswordProtected` come mostrato sopra.

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

## **Raccomandazioni di sicurezza**

{{% alert color="warning" title="Security" %}}
Non registrare le password di apertura né includerle nei messaggi diagnostici. Evita tentativi di convalida ripetuti non necessari, conserva le password in memoria solo per il tempo necessario e riutilizza il risultato di una convalida riuscita quando si carica immediatamente la presentazione.

Le proprietà pubbliche del documento possono rivelare nomi degli autori, titoli, argomenti, parole chiave, informazioni aziendali, commenti e valori personalizzati anche se il contenuto della presentazione è crittografato. Cripta i metadati sensibili insieme alla presentazione. Lasciare le proprietà pubbliche dovrebbe essere una decisione esplicita presa solo quando i sistemi devono indicizzare, classificare, cercare o gestire il file senza una password di apertura.
{{% /alert %}}

## **Proteggi con password una presentazione online**

1. Apri l'applicazione [Aspose.Slides Lock](https://products.aspose.app/slides/it/lock).
1. Seleziona o carica la presentazione.
1. Inserisci una password per la protezione della visualizzazione.
1. Facoltativamente inserisci una password separata per la protezione della modifica.
1. Applica la protezione e scarica il file risultante.

{{% alert color="info" title="See also" %}}
- [Presentazioni con protezione in scrittura](/slides/it/cpp/write-protected-presentation/)
- [Firma digitale in PowerPoint](/slides/it/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Qual è la differenza tra una password di apertura e una password di protezione in scrittura?**

Una password di apertura cripta la presentazione ed è necessaria per caricare il suo contenuto. Una password di protezione in scrittura limita la modifica senza criptare il contenuto.

**Posso convalidare una password di apertura senza caricare tutte le diapositive?**

Sì. Ottieni le informazioni della presentazione, verifica se è presente la protezione con password di apertura e valida la password prima di creare un'istanza completa della presentazione.

**Un'applicazione può leggere i metadati senza la password di apertura?**

Sì, ma solo quando la presentazione è stata criptata con `set_EncryptDocumentProperties(false)`. L'applicazione deve quindi utilizzare la modalità di caricamento solo per le proprietà del documento descritta in [Manage Presentation Properties](/slides/it/cpp/presentation-properties/).

**I flussi di lavoro di verifica della password supportano sia PPT che PPTX?**

Sì. Il rilevamento e la convalida della password basati su percorso file o su stream si comportano allo stesso modo per le presentazioni PPT e PPTX.