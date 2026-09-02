---
title: Presentaties met wachtwoord beveiligen in C++
linktitle: Wachtwoordbeveiliging
type: docs
weight: 20
url: /nl/cpp/password-protected-presentation/
keywords:
- wachtwoord-beveiligde presentatie
- openingswachtwoord
- PowerPoint versleutelen
- PowerPoint ontsleutelen
- presentatiewachtwoord valideren
- presentatiewachtwoord controleren
- versleutelde presentatie openen
- versleuteling verwijderen
- PowerPoint
- PPT
- PPTX
- presentatie
- C++
- Aspose.Slides
description: "Versleutel, detecteer, valideer, open en ontsleutel wachtwoord-beveiligde PowerPoint PPT- en PPTX-presentaties in C++ met Aspose.Slides."
---
## **Overzicht**

Een openingswachtwoord versleutelt een presentatie. Het juiste wachtwoord is vereist om de presentatie-inhoud te laden en te bekijken, waardoor deze bescherming vertrouwelijkheid biedt.

Een openingswachtwoord verschilt van een schrijfbeveiligingswachtwoord. Schrijfbeveiliging beperkt wijzigingen, maar versleutelt de inhoud niet en verhindert niet dat de presentatie geladen wordt. Zie voor het beheren van wachtwoorden voor het aanpassen van presentaties [Write-Protect Presentations](/slides/nl/cpp/write-protected-presentation/).

De onderstaande werkstromen zijn van toepassing op zowel PPT‑ als PPTX‑presentaties. De voorbeelden gebruiken beide formaten wanneer het gedrag op basis van bestand of stream van belang is.

## **Een presentatie versleutelen met een openingswachtwoord**

Gebruik [IProtectionManager::Encrypt](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iprotectionmanager/encrypt/) om een openingswachtwoord toe te wijzen. Gebruik vervolgens [IPresentation::Save](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentation/save/) om de versleutelde presentatie op te slaan.

Het volgende voorbeeld versleutelt een PPTX‑presentatie:

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

## **Een versleutelde presentatie laden**

Stel [LoadOptions::set_Password](https://reference.aspose.com/slides/nl/cpp/aspose.slides/loadoptions/set_password/) in op het openingswachtwoord en geef de opties door aan [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) bij het laden van het bestand. Het laden mislukt wanneer een openingswachtwoord vereist is maar het opgegeven wachtwoord ontbreekt of onjuist is.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

// Werk met de ontsleutelde presentatie.
```

## **Versleuteling van een presentatie verwijderen**

Laad de presentatie met het bijbehorende openingswachtwoord, roep [IProtectionManager::RemoveEncryption](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iprotectionmanager/removeencryption/) aan en sla het resultaat op. De opgeslagen presentatie kan vervolgens zonder wachtwoord worden geladen.

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

## **Een openingswachtwoord valideren vóór het laden**

Gebruik [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) om [IPresentationInfo](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentationinfo/) te verkrijgen zonder een volledige presentatietoestand te maken. Controleer [IPresentationInfo::get_IsPasswordProtected](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentationinfo/get_ispasswordprotected/) voordat u een wachtwoord opvraagt of valideert. Wanneer bescherming aanwezig is, valideer dan de opgegeven waarde met [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentationinfo/checkpassword/).

### **Werkstroom op bestandspad**

Het volgende voorbeeld valideert een openingswachtwoord voor een PPTX‑bestand, geeft de gevalideerde waarde door aan [LoadOptions::set_Password](https://reference.aspose.com/slides/nl/cpp/aspose.slides/loadoptions/set_password/) en laadt vervolgens de volledige presentatie:

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

### **Werkstroom met stream**

De stream‑overload van [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) biedt dezelfde werkstroom. Reset de positie van een seek‑bare stream vóór het laden van de volledige presentatie vanuit die stream.

Het volgende voorbeeld gebruikt een PPT‑bestand:

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

### **Returnwaarden van CheckPassword**

[IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentationinfo/checkpassword/) retourneert `true` alleen wanneer de presentatie een openingswachtwoord heeft en het opgegeven wachtwoord correct is. Het retourneert `false` in elk van de volgende gevallen:

- Het wachtwoord is onjuist.
- De presentatie heeft geen openingswachtwoord.
- Het opgegeven wachtwoord is null of leeg.

Het gedrag is hetzelfde voor PPT‑ en PPTX‑presentaties.

## **Controleren of een geladen presentatie versleuteld is**

Na het laden van een presentatie met het juiste wachtwoord, inspecteer [IProtectionManager::get_IsEncrypted](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iprotectionmanager/get_isencrypted/) om te bevestigen dat de bronpresentatie versleuteld was. Om openings‑wachtwoordbescherming vóór het laden te detecteren, gebruik `IPresentationInfo::get_IsPasswordProtected` zoals hierboven getoond.

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

## **Beveiligingsaanbevelingen**

{{% alert color="warning" title="Beveiliging" %}}
Log geen openingswachtwoorden en neem ze niet op in diagnostische berichten. Vermijd onnodige herhaalde validatie‑pogingen, bewaar wachtwoorden alleen zo lang als nodig in het geheugen, en hergebruik een geslaagde validatieresultaat bij het direct laden van de presentatie.
{{% /alert %}}

## **Een presentatie online met wachtwoord beveiligen**

1. Open de applicatie [Aspose.Slides Lock](https://products.aspose.app/slides/nl/lock).
2. Selecteer of upload de presentatie.
3. Voer een wachtwoord in voor weergave‑bescherming.
4. Voer eventueel een apart wachtwoord in voor bewerkings‑bescherming.
5. Pas de bescherming toe en download het resulterende bestand.

{{% alert color="info" title="Zie ook" %}}
- [Write-Protect Presentations](/slides/nl/cpp/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/nl/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Wat is het verschil tussen een openingswachtwoord en een schrijfbeveiligingswachtwoord?**

Een openingswachtwoord versleutelt de presentatie en is vereist om de inhoud te laden. Een schrijfbeveiligingswachtwoord beperkt wijzigingen zonder de inhoud te versleutelen.

**Kan ik een openingswachtwoord valideren zonder alle dia's te laden?**

Ja. Verkrijg presentatiesinformatie, controleer of er bescherming via een openingswachtwoord aanwezig is, en valideer het wachtwoord voordat u een volledige presentatietoestand creëert.

**Ondersteunen de workflow‑processen voor wachtwoordcontrole zowel PPT als PPTX?**

Ja. Werkstromen op basis van bestandspad en stream voor het detecteren en valideren van wachtwoorden gedragen zich gelijk voor PPT‑ en PPTX‑presentaties.