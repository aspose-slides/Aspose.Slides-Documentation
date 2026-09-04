---
title: Lösenordsskydda presentationer i C++
linktitle: Lösenordsskydd
type: docs
weight: 20
url: /sv/cpp/password-protected-presentation/
keywords:
- lösenordsskyddad presentation
- öppningslösenord
- kryptera PowerPoint
- dekryptera PowerPoint
- validera presentationslösenord
- kontrollera presentationslösenord
- öppna krypterad presentation
- ta bort kryptering
- PowerPoint
- PPT
- PPTX
- presentation
- C++
- Aspose.Slides
description: "Kryptera, upptäcka, validera, öppna och dekryptera lösenordsskyddade PowerPoint PPT- och PPTX-presentationer i C++ med Aspose.Slides."
---
## **Översikt**

Ett öppningslösenord krypterar en presentation. Det korrekta lösenordet krävs för att läsa in och visa presentationens innehåll, så detta skydd ger konfidentialitet.

Ett öppningslösenord skiljer sig från ett skrivskyddslösenord. Skrivskydd begränsar modifiering men krypterar inte innehållet eller förhindrar att presentationen läses in. För att hantera lösenord för att ändra presentationer, se [Skrivskydda presentationer](/slides/sv/cpp/write-protected-presentation/).

Arbetsflödena nedan gäller både PPT- och PPTX-presentationer. Exemplen använder båda formaten där deras filbaserade och strömbaserade beteende är viktigt.

## **Kryptera en presentation med ett öppningslösenord**

Använd [IProtectionManager::Encrypt](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iprotectionmanager/encrypt/) för att tilldela ett öppningslösenord. Använd sedan [IPresentation::Save](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentation/save/) för att spara den krypterade presentationen.

Följande exempel krypterar en PPTX-presentation:

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

## **Behåll dokumentegenskaper offentliga**

Som standard inkluderar Aspose.Slides dokumentegenskaper i presentationskryptering. [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/) styr detta beteende oberoende av bildinnehållskryptering. Skicka `false` till denna metod innan du anropar [IProtectionManager::Encrypt](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iprotectionmanager/encrypt/) när ett indexerings-, klassificerings-, sök- eller dokumenthanteringssystem måste läsa metadata utan öppningslösenordet.

Följande exempel skapar en krypterad PPTX-presentation samtidigt som dess inbyggda dokumentegenskaper förblir offentliga:

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

Att skicka `false` till `set_EncryptDocumentProperties` gör inte bilder, masterbilder, layouter, former, media eller annat presentationsinnehåll offentligt. Det påverkar endast dokumentegenskaper. För att läsa dessa egenskaper utan att läsa in det krypterade innehållet, se [Hantera presentationsegenskaper](/slides/sv/cpp/presentation-properties/).

## **Läs in en krypterad presentation**

Ställ in [LoadOptions::set_Password](https://reference.aspose.com/slides/sv/cpp/aspose.slides/loadoptions/set_password/) till öppningslösenordet och skicka alternativen till [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) när filen läses in. Inläsning misslyckas när ett öppningslösenord krävs men det angivna lösenordet saknas eller är felaktigt.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

// Arbeta med den dekrypterade presentationen.
```

## **Ta bort kryptering från en presentation**

Läs in presentationen med dess öppningslösenord, anropa [IProtectionManager::RemoveEncryption](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iprotectionmanager/removeencryption/), och spara resultatet. Den sparade presentationen kan därefter läsas in utan lösenord.

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

## **Validera ett öppningslösenord innan inläsning**

Använd [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) för att erhålla [IPresentationInfo](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentationinfo/) utan att skapa en fullständig presentationsinstans. Kontrollera [IPresentationInfo::get_IsPasswordProtected](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentationinfo/get_ispasswordprotected/) innan du begär eller validerar ett lösenord. När skydd finns, validera det angivna värdet med [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentationinfo/checkpassword/).

### **Filvägsarbetsflöde**

Följande exempel validerar ett öppningslösenord för en PPTX-fil, skickar det validerade värdet till [LoadOptions::set_Password](https://reference.aspose.com/slides/sv/cpp/aspose.slides/loadoptions/set_password/), och läser sedan in den fullständiga presentationen:

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

### **Strömarbetsflöde**

Ström‑överkörningen av [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) ger samma arbetsflöde. Återställ positionen för en sökbar ström innan du läser in den fullständiga presentationen från den strömmen.

Följande exempel använder en PPT-fil:

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

### **CheckPassword‑returvärden**

[IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentationinfo/checkpassword/) returnerar `true` endast när presentationen har ett öppningslösenord och det angivna lösenordet är korrekt. Den returnerar `false` i vart och ett av följande fall:

- Lösenordet är felaktigt.
- Presentationen har inget öppningslösenord.
- Det angivna lösenordet är null eller tomt.

Beteendet är detsamma för PPT- och PPTX-presentationer.

## **Kontrollera om en inläst presentation är krypterad**

Efter att ha läst in en presentation med rätt lösenord, inspektera [IProtectionManager::get_IsEncrypted](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iprotectionmanager/get_isencrypted/) för att bekräfta att källpresentationen var krypterad. För att upptäcka öppningslösenordsskydd innan inläsning, använd `IPresentationInfo::get_IsPasswordProtected` som visat ovan.

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

## **Säkerhetsrekommendationer**

{{% alert color="warning" title="Säkerhet" %}}
Logga inte öppningslösenord eller inkludera dem i diagnostiska meddelanden. Undvik onödiga återupprepade valideringsförsök, behåll lösenord i minnet endast så länge som behövs, och återanvänd ett lyckat valideringsresultat när presentationen laddas omedelbart.

Offentliga dokumentegenskaper kan avslöja författarnamn, titlar, ämnen, nyckelord, företagsinformation, kommentarer och anpassade värden även om presentationsinnehållet är krypterat. Kryptera känslig metadata tillsammans med presentationen. Att lämna egenskaper offentliga bör vara ett explicit beslut som endast tas när system måste indexera, klassificera, söka eller hantera filen utan ett öppningslösenord.
{{% /alert %}}

## **Lösenordsskydda en presentation online**

1. Öppna applikationen [Aspose.Slides Lock](https://products.aspose.app/slides/sv/lock).
2. Välj eller ladda upp presentationen.
3. Ange ett lösenord för visningsskydd.
4. Ange eventuellt ett separat lösenord för redigeringsskydd.
5. Applicera skyddet och ladda ner den resulterande filen.

{{% alert color="info" title="Se också" %}}
- [Skrivskydda presentationer](/slides/sv/cpp/write-protected-presentation/)
- [Digital signatur i PowerPoint](/slides/sv/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Vad är skillnaden mellan ett öppningslösenord och ett skrivskyddslösenord?**

Ett öppningslösenord krypterar presentationen och krävs för att läsa in dess innehåll. Ett skrivskyddslösenord begränsar modifiering utan att kryptera innehållet.

**Kan jag validera ett öppningslösenord utan att läsa in alla bilder?**

Ja. Hämta presentationsinformation, kontrollera om öppningslösenordsskydd finns, och validera lösenordet innan en komplett presentationsinstans skapas.

**Kan en applikation läsa metadata utan öppningslösenordet?**

Ja, men endast när presentationen krypterades med `set_EncryptDocumentProperties(false)`. Applikationen måste då använda laddningsläget som endast läser dokumentegenskaper, beskrivet i [Hantera presentationsegenskaper](/slides/sv/cpp/presentation-properties/).

**Stöder lösenordskontrollarbetsflödena både PPT och PPTX?**

Ja. Filvägs- och strömbaserade lösenordssökning och -validering fungerar likadant för PPT- och PPTX-presentationer.