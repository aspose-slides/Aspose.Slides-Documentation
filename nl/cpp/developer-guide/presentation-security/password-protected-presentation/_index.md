---
title: "Wachtwoordbeveiligde presentaties in C++"
linktitle: "Wachtwoordbeveiliging"
type: docs
weight: 20
url: /nl/cpp/password-protected-presentation/
keywords:
- wachtwoordbeveiligde presentatie
- openingswachtwoord
- PowerPoint versleutelen
- PowerPoint ontsleutelen
- presentatie wachtwoord valideren
- presentatie wachtwoord controleren
- versleutelde presentatie openen
- versleuteling verwijderen
- PowerPoint
- PPT
- PPTX
- presentatie
- C++
- Aspose.Slides
description: "Versleutel, detecteer, valideer, open en ontsleutel wachtwoordbeveiligde PowerPoint PPT- en PPTX-presentaties in C++ met Aspose.Slides."
---
## **Overzicht**

Een openingswachtwoord versleutelt een presentatie. Het juiste wachtwoord is vereist om de inhoud van de presentatie te laden en te bekijken, waardoor deze bescherming vertrouwelijkheid biedt.

Een openingswachtwoord verschilt van een schrijfbeschermingswachtwoord. Bescherming tegen schrijven beperkt bewerken, maar versleutelt de inhoud niet en verhindert niet dat de presentatie wordt geladen. Voor het beheren van wachtwoorden voor het aanpassen van presentaties, zie [Write-Protect Presentations](/slides/nl/cpp/write-protected-presentation/).

De onderstaande workflows zijn van toepassing op zowel PPT- als PPTX-presentaties. De voorbeelden gebruiken beide formaten waar hun gedrag op basis van bestand en op basis van stream belangrijk is.

## **Een Presentatie Versleutelen met een Openingswachtwoord**

Gebruik [IProtectionManager::Encrypt](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iprotectionmanager/encrypt/) om een openingswachtwoord toe te wijzen. Gebruik vervolgens [IPresentation::Save](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentation/save/) om de versleutelde presentatie op te slaan.

Het volgende voorbeeld versleutelt een PPTX-presentatie:

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

## **Documenteigenschappen Openbaar Houden**

Standaard neemt Aspose.Slides documenteigenschappen op in de versleuteling van de presentatie. [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/) regelt dit gedrag onafhankelijk van de versleuteling van de dia-inhoud. Geef `false` door aan deze methode voordat u [IProtectionManager::Encrypt](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iprotectionmanager/encrypt/) aanroept wanneer een indexerings-, classificatie-, zoek- of documentbeheersysteem metadata moet lezen zonder het openingswachtwoord.

Het volgende voorbeeld maakt een versleutelde PPTX-presentatie terwijl de ingebouwde documenteigenschappen openbaar blijven:

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

`false` doorgeven aan `set_EncryptDocumentProperties` maakt dia's, masters, lay-outs, vormen, media of andere presentatiewijzigingen niet openbaar. Het beïnvloedt alleen documenteigenschappen. Zie [Manage Presentation Properties](/slides/nl/cpp/presentation-properties/) om die eigenschappen te lezen zonder de versleutelde inhoud te laden.

## **Een Versleutelde Presentatie Laden**

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

## **Versleuteling van een Presentatie Verwijderen**

Laad de presentatie met het bijbehorende openingswachtwoord, roep [IProtectionManager::RemoveEncryption](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iprotectionmanager/removeencryption/) aan en sla het resultaat op. De opgeslagen presentatie kan daarna zonder wachtwoord worden geladen.

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

## **Een Openingswachtwoord Valideren vóór het Laden**

Gebruik [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) om [IPresentationInfo](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentationinfo/) te verkrijgen zonder een volledige presentatie‑instantie te maken. Controleer [IPresentationInfo::get_IsPasswordProtected](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentationinfo/get_ispasswordprotected/) voordat u een wachtwoord vraagt of valideert. Wanneer bescherming aanwezig is, valideer dan de opgegeven waarde met [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentationinfo/checkpassword/).

### **Bestandspad Workflow**

Het volgende voorbeeld valideert een openingswachtwoord voor een PPTX‑bestand, geeft de gevalideerde waarde door aan [LoadOptions::set_Password](https://reference.aspose.com/slides/nl/cpp/aspose.slides/loadoptions/set_password/), en laadt vervolgens de volledige presentatie:

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

### **Stream‑workflow**

De stream‑overload van [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) biedt dezelfde workflow. Reset de positie van een doorzoekbare stream voordat u de volledige presentatie uit die stream laadt.

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

### **CheckPassword Retourwaarden**

[IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentationinfo/checkpassword/) retourneert `true` alleen wanneer de presentatie een openingswachtwoord heeft en het opgegeven wachtwoord juist is. Het retourneert `false` in elk van de volgende gevallen:

- Het wachtwoord is onjuist.
- De presentatie heeft geen openingswachtwoord.
- Het opgegeven wachtwoord is null of leeg.

Het gedrag is hetzelfde voor PPT‑ en PPTX‑presentaties.

## **Controleren of een Geladen Presentatie Versleuteld Is**

Na het laden van een presentatie met het juiste wachtwoord, controleer [IProtectionManager::get_IsEncrypted](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iprotectionmanager/get_isencrypted/) om te bevestigen dat de bronpresentatie versleuteld was. Om bescherming met een openingswachtwoord te detecteren vóór het laden, gebruik `IPresentationInfo::get_IsPasswordProtected` zoals hierboven getoond.

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
Log geen openingswachtwoorden en neem ze niet op in diagnostische berichten. Vermijd onnodige herhaalde validatiepogingen, bewaar wachtwoorden alleen zo lang als nodig in het geheugen, en hergebruik een succesvolle validatieresultaat bij het direct laden van de presentatie.

Openbare documenteigenschappen kunnen namen van auteurs, titels, onderwerps, trefwoorden, bedrijfsinformatie, opmerkingen en aangepaste waarden onthullen, zelfs wanneer de inhoud van de presentatie versleuteld is. Versleutel gevoelige metadata samen met de presentatie. Het openbaar laten van eigenschappen moet een expliciete beslissing zijn, alleen wanneer systemen het bestand moeten indexeren, classificeren, doorzoeken of beheren zonder een openingswachtwoord.
{{% /alert %}}

## **Een Presentatie Online Beschermen met Wachtwoord**

1. Open de applicatie [Aspose.Slides Lock](https://products.aspose.app/slides/nl/lock).
1. Selecteer of upload de presentatie.
1. Voer een wachtwoord in voor weergavebescherming.
1. Voer optioneel een apart wachtwoord in voor bewerkingsbescherming.
1. Pas de bescherming toe en download het resulterende bestand.

{{% alert color="info" title="Zie ook" %}}
- [Write-Protect Presentations](/slides/nl/cpp/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/nl/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Wat is het verschil tussen een openingswachtwoord en een schrijfbeschermingswachtwoord?**

Een openingswachtwoord versleutelt de presentatie en is vereist om de inhoud te laden. Een schrijfbeschermingswachtwoord beperkt bewerken zonder de inhoud te versleutelen.

**Kan ik een openingswachtwoord valideren zonder alle dia's te laden?**

Ja. Verkrijg presentatiedetails, controleer of er een bescherming met een openingswachtwoord aanwezig is, en valideer het wachtwoord vóór het creëren van een volledige presentatiereeks.

**Kan een applicatie metadata lezen zonder het openingswachtwoord?**

Ja, maar alleen wanneer de presentatie is versleuteld met `set_EncryptDocumentProperties(false)`. De applicatie moet dan de ladingmodus alleen voor documenteigenschappen gebruiken zoals beschreven in [Manage Presentation Properties](/slides/nl/cpp/presentation-properties/).

**Ondersteunen de wachtwoord‑controles zowel PPT als PPTX?**

Ja. Detectie en validatie van wachtwoorden op basis van bestandspad en stream werken hetzelfde voor PPT‑ en PPTX‑presentaties.