---
title: Skrivskydda presentationer i C++
linktitle: Skrivskydd
type: docs
weight: 25
url: /sv/cpp/write-protected-presentation/
keywords:
- skrivskydd
- skrivskydd PowerPoint
- lösenord för att ändra
- begränsa redigering av presentation
- ta bort skrivskydd
- validera ändringslösenord
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Ställ in, upptäck, validera och ta bort skrivskyddslösenord i PowerPoint PPT- och PPTX-presentationer med Aspose.Slides för C++."
---
## **Introduktion**

Ett skrivskyddslösenord begränsar ändring av en presentation men krypterar inte dess innehåll. Användare kan läsa in och visa en skrivskyddad presentation utan lösenordet. Beroende på applikationen kan de även kunna redigera innehållet och spara det under ett annat namn, så skrivskydd bör inte betraktas som en sekretessmekanism.

Ett öppningslösenord har ett annat syfte: det krypterar presentationen och krävs för att läsa in dess innehåll. För att kryptera en presentation eller validera ett öppningslösenord, se [Lösenordsskydda presentationer](/slides/sv/cpp/password-protected-presentation/).

Arbetsflödena i den här artikeln gäller både PPT- och PPTX-presentationer. Exemplen använder PPTX-filer; vid sparning till PPT, använd filändelsen `.ppt` och motsvarande PPT-sparformat.

## **Ställ in skrivskydd på en presentation**

Använd [IProtectionManager::SetWriteProtection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iprotectionmanager/setwriteprotection/) för att tilldela ett lösenord för att ändra en presentation. Att spara presentationen bevarar skyddsinställningen.

Följande exempel sätter skrivskydd på en PPTX-presentation:

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

## **Läs in en skrivskyddad presentation**

Eftersom skrivskydd inte krypterar presentationsinnehållet krävs inget lösenord för att läsa in presentationen. Lösenordet är endast relevant när auktorisation för att ändra den skyddade presentationen ska valideras.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"write-protected-pres.pptx");

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());
```

Skicka inte ett skrivskyddslösenord till [LoadOptions::set_Password](https://reference.aspose.com/slides/sv/cpp/aspose.slides/loadoptions/set_password/). Den egenskapen accepterar ett öppningslösenord för krypterat innehåll. Om en presentation har båda skyddstyperna, ange öppningslösenordet för att läsa in den och hantera skrivskyddslösenordet separat.

## **Ta bort skrivskydd från en presentation**

Använd [IProtectionManager::RemoveWriteProtection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iprotectionmanager/removewriteprotection/) för att ta bort begränsningen för ändring, spara sedan presentationen.

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

## **Kontrollera om en presentation är skrivskyddad**

För att inspektera en fil utan att skapa en komplett [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)‑instans, anropa [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) och inspektera [IPresentationInfo::get_IsWriteProtected](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentationinfo/get_iswriteprotected/). Egenskapen använder [NullableBool](https://reference.aspose.com/slides/sv/cpp/aspose.slides/nullablebool/) och returnerar `NullableBool::True` när skrivskydd upptäcks.

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

Ström‑överladdningen av [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) ger samma information för en presentation som tillhandahålls som en ström.

## **Validera ett skrivskyddslösenord**

Använd [IPresentationInfo::CheckWriteProtection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentationinfo/checkwriteprotection/) för att validera ett ändringslösenord utan att läsa in den kompletta presentationen. Kontrollera först [IPresentationInfo::get_IsWriteProtected](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentationinfo/get_iswriteprotected/) så att applikationen begär eller validerar ett lösenord endast när skrivskydd finns.

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

[IPresentationInfo::CheckWriteProtection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentationinfo/checkwriteprotection/) validerar endast skrivskyddslösenordet. Det validerar inte ett öppningslösenord eller avgör om krypterat innehåll kan läsas in. Omvänt validerar [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentationinfo/checkpassword/) endast ett öppningslösenord. Om en komplett presentation redan har lästs in, ger [IProtectionManager::CheckWriteProtection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iprotectionmanager/checkwriteprotection/) motsvarande skrivskyddskontroll via sin skyddshanterare.

I produktionsapplikationer, logga inte lösenord eller inkludera dem i diagnostikmeddelanden. Undvik onödiga upprepade valideringsförsök och behåll lösenord i minnet endast så länge som behövs.

{{% alert color="info" title="Se även" %}}
- [Lösenordsskydda presentationer](/slides/sv/cpp/password-protected-presentation/)
- [Endast läsbara presentationer](/slides/sv/cpp/read-only-presentation/)
- [Digital signatur i PowerPoint](/slides/sv/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Vanliga frågor**

**Krypterar skrivskydd en presentation?**

Nej. Det begränsar ändring men lämnar presentationsinnehållet tillgängligt för inläsning och visning.

**Krävs skrivskyddslösenordet för att öppna en presentation?**

Nej. Endast ett öppningslösenord krävs för att ladda krypterat presentationsinnehåll.

**Kan en presentation ha både ett öppningslösenord och ett skrivskyddslösenord?**

Ja. Ange öppningslösenordet via load‑alternativen för att öppna den krypterade presentationen och validera skrivskyddslösenordet separat när åtkomst för ändring krävs.