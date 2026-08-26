---
title: Presentaties met schrijfbescherming in C++
linktitle: Schrijfbescherming
type: docs
weight: 25
url: /nl/cpp/write-protected-presentation/
keywords:
- schrijfbescherming
- schrijfbescherming PowerPoint
- wachtwoord om te wijzigen
- beperken van presentatiebewerking
- schrijfbescherming verwijderen
- validatie wijzigingswachtwoord
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Instellen, detecteren, valideren en verwijderen van schrijfbeschermingswachtwoorden in PowerPoint PPT- en PPTX-presentaties met Aspose.Slides voor C++."
---
## **Inleiding**

Een wachtwoord voor schrijfbescherming beperkt de wijziging van een presentatie, maar versleutelt de inhoud niet. Gebruikers kunnen een schrijfbeschermde presentatie laden en bekijken zonder het wachtwoord. Afhankelijk van de applicatie kunnen ze ook de inhoud bewerken en opslaan onder een andere naam, dus schrijfbescherming mag niet worden beschouwd als een vertrouwelijkheidsmechanisme.

Een openingswachtwoord dient een ander doel: het versleutelt de presentatie en is vereist om de inhoud te laden. Om een presentatie te versleutelen of een openingswachtwoord te valideren, zie [Password-Protect Presentations](/slides/nl/cpp/password-protected-presentation/).

De werkstromen in dit artikel zijn van toepassing op zowel PPT- als PPTX-presentaties. De voorbeelden gebruiken PPTX‑bestanden; bij het opslaan als PPT, gebruik de extensie `.ppt` en het bijbehorende PPT‑opslagformaat.

## **Schrijfbescherming instellen op een presentatie**

Gebruik [IProtectionManager::SetWriteProtection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iprotectionmanager/setwriteprotection/) om een wachtwoord toe te wijzen voor het wijzigen van een presentatie. Het opslaan van de presentatie bewaart de beschermingsinstelling.

Het volgende voorbeeld stelt schrijfbescherming in op een PPTX‑presentatie:

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

## **Laden van een schrijfbeschermde presentatie**

Omdat schrijfbescherming de inhoud van de presentatie niet versleutelt, is er geen wachtwoord nodig om de presentatie te laden. Het wachtwoord is alleen relevant bij het valideren van de autorisatie om de beschermde presentatie te wijzigen.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"write-protected-pres.pptx");

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());
```

Geef geen schrijfbeschermingswachtwoord door aan [LoadOptions::set_Password](https://reference.aspose.com/slides/nl/cpp/aspose.slides/loadoptions/set_password/). Die eigenschap accepteert een openingswachtwoord voor versleutelde inhoud. Als een presentatie beide beschermingssoorten heeft, lever dan het openingswachtwoord om deze te laden en behandel het schrijfbeschermingswachtwoord apart.

## **Schrijfbescherming verwijderen van een presentatie**

Gebruik [IProtectionManager::RemoveWriteProtection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iprotectionmanager/removewriteprotection/) om de wijzigingsrestrictie te verwijderen, en sla vervolgens de presentatie op.

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

## **Controleren of een presentatie schrijfbeschermd is**

Om een bestand te inspecteren zonder een volledige [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)-instantie te maken, roep je [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) aan en inspecteer je [IPresentationInfo::get_IsWriteProtected](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentationinfo/get_iswriteprotected/). De eigenschap maakt gebruik van [NullableBool](https://reference.aspose.com/slides/nl/cpp/aspose.slides/nullablebool/) en retourneert `NullableBool::True` wanneer schrijfbescherming wordt gedetecteerd.

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

De stream‑overload van [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) levert dezelfde informatie voor een presentatie die als stream wordt aangeleverd.

## **Een schrijfbeschermingswachtwoord valideren**

Gebruik [IPresentationInfo::CheckWriteProtection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentationinfo/checkwriteprotection/) om een wijzigingswachtwoord te valideren zonder de volledige presentatie te laden. Controleer eerst [IPresentationInfo::get_IsWriteProtected](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentationinfo/get_iswriteprotected/) zodat de applicatie alleen een wachtwoord vraagt of valideert wanneer schrijfbescherming aanwezig is.

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

[IPresentationInfo::CheckWriteProtection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentationinfo/checkwriteprotection/) valideert alleen het schrijfbeschermingswachtwoord. Het valideert geen openingswachtwoord en bepaalt niet of versleutelde inhoud geladen kan worden. Omgekeerd valideert [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentationinfo/checkpassword/) alleen een openingswachtwoord. Als een volledige presentatie al geladen is, biedt [IProtectionManager::CheckWriteProtection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iprotectionmanager/checkwriteprotection/) de equivalente schrijfbeschermingscontrole via zijn beschermingsmanager.

In productie‑applicaties moeten wachtwoorden niet worden gelogd of opgenomen in diagnostische berichten. Vermijd onnodige herhaalde validatie‑pogingen en bewaar wachtwoorden in het geheugen alleen zolang als nodig is.

{{% alert color="info" title="Zie ook" %}}
- [Presentaties beveiligen met wachtwoord](/slides/nl/cpp/password-protected-presentation/)
- [Alleen-lezen presentaties](/slides/nl/cpp/read-only-presentation/)
- [Digitale handtekening in PowerPoint](/slides/nl/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Veelgestelde vragen**

**Versleutelt schrijfbescherming een presentatie?**

Nee. Het beperkt de wijziging, maar laat de inhoud van de presentatie beschikbaar voor laden en bekijken.

**Is het schrijfbeschermingswachtwoord vereist om een presentatie te openen?**

Nee. Alleen een openingswachtwoord is vereist om versleutelde presentatiedata te laden.

**Kan een presentatie zowel een openingswachtwoord als een schrijfbeschermingswachtwoord hebben?**

Ja. Geef het openingswachtwoord via de laadopties op om de versleutelde presentatie te openen, en valideer het schrijfbeschermingswachtwoord apart wanneer wijzigingsautorisatie vereist is.