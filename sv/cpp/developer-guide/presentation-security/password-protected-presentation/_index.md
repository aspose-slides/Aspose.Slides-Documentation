---
title: Säkra presentationer med lösenord i C++
linktitle: Lösenordsskydd
type: docs
weight: 20
url: /sv/cpp/password-protected-presentation/
keywords:
- låsa PowerPoint
- låsa presentation
- låsa upp PowerPoint
- låsa upp presentation
- skydda PowerPoint
- skydda presentation
- ange lösenord
- lägga till lösenord
- kryptera PowerPoint
- kryptera presentation
- dekryptera PowerPoint
- dekryptera presentation
- skrivskydd
- PowerPoint-säkerhet
- presentationssäkerhet
- ta bort lösenord
- ta bort skydd
- ta bort kryptering
- inaktivera lösenord
- inaktivera skydd
- ta bort skrivskydd
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Lär dig hur du enkelt låser och låser upp lösenordsskyddade PowerPoint- och OpenDocument-presentationer med Aspose.Slides för C++. Säkerställ dina presentationer."
---
## **Introduktion**

När du lösenordsskyddar en presentation innebär det att du anger ett lösenord som upprätthåller vissa begränsningar för presentationen. För att ta bort begränringarna måste lösenordet anges. En lösenordsskyddad presentation betraktas som en låst presentation.

Vanligtvis kan du ställa in ett lösenord för att upprätthålla dessa begränsningar på en presentation:

- **Modifiering**

  Om du vill att endast vissa användare ska kunna ändra din presentation kan du ställa in en modifieringsbegränsning. Begränsningen hindrar personer från att modifiera, förändra eller kopiera saker i din presentation (såvida de inte anger lösenordet).

  Men i det här fallet kan en användare, även utan lösenord, ändå komma åt ditt dokument och öppna det. I detta skrivskyddade läge kan användaren se innehållet eller saker—hyperlänkar, animationer, effekter och andra—i din presentation, men de kan inte kopiera objekt eller spara presentationen.

- **Öppning**

  Om du vill att endast vissa användare ska kunna öppna din presentation kan du ställa in en öppningsbegränsning. Begränsningen hindrar personer från att ens se innehållet i din presentation (såvida de inte anger lösenordet).

  Tekniskt sett förhindrar öppningsbegränsningen även att användare kan modifiera dina presentationer: När personer inte kan öppna en presentation kan de inte modifiera eller göra ändringar i den.

  **Observera** att när du lösenordsskyddar en presentation för att förhindra öppning blir presentationsfilen krypterad.

## **Hur du lösenordsskyddar en presentation online**

1. Gå till vår sida [**Aspose.Slides Lock**](https://products.aspose.app/slides/sv/lock).

   ![todo:image_alt_text](slides-lock.png)

2. Klicka på **Släpp eller ladda upp dina filer**.

3. Välj den fil du vill lösenordsskydda på din dator.

4. Ange ditt föredragna lösenord för redigeringsskydd; Ange ditt föredragna lösenord för visningsskydd.

5. Om du vill att användare ska se din presentation som den slutgiltiga kopian, markera kryssrutan **Mark as final**.

6. Klicka på **PROTECT NOW.**

7. Klicka på **DOWNLOAD NOW.**

## **Lösenordsskydd för presentationer i Aspose.Slides**

**Stödda format**

Aspose.Slides stöder lösenordsskydd, kryptering och liknande operationer för presentationer i följande format:

- PPTX och PPT – Microsoft PowerPoint-presentation
- ODP – OpenDocument-presentation
- OTP – OpenDocument-presentationmall

**Stödda operationer**

Aspose.Slides låter dig använda lösenordsskydd på presentationer för att förhindra modifieringar på följande sätt:

- Kryptera en presentation
- Ställa in skrivskydd för en presentation

**Övriga operationer**

Aspose.Slides låter dig utföra andra uppgifter som involverar lösenordsskydd och kryptering på följande sätt:

- Dekryptera en presentation; öppna en krypterad presentation
- Ta bort kryptering; inaktivera lösenordsskydd
- Ta bort skrivskydd från en presentation
- Hämta egenskaperna för en krypterad presentation
- Kontrollera om en presentation är krypterad
- Kontrollera om en presentation är lösenordsskyddad.

## **Kryptera en presentation**

Du kan kryptera en presentation genom att ange ett lösenord. För att sedan modifiera den låsta presentationen måste en användare ange lösenordet.

För att kryptera eller lösenordsskydda en presentation måste du använda encrypt‑metoden (från [ProtectionManager](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.protection_manager)) för att ange ett lösenord för presentationen. Du skickar lösenordet till encrypt‑metoden och använder save‑metoden för att spara den nu krypterade presentationen.

Det här exempelprogrammet visar hur du krypterar en presentation:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **Ställ in skrivskydd för en presentation**

Du kan lägga till en markering som säger “Do not modify” i en presentation. På så sätt kan du tala om för användarna att du inte vill att de ska göra ändringar i presentationen.

**Obs** att processen för skrivskydd inte krypterar presentationen. Därför kan användare—om de vill—modifiera presentationen, men för att spara ändringarna måste de skapa en presentation med ett annat namn.

För att ställa in ett skrivskydd måste du använda setWriteProtection‑metoden. Detta exempelprogram visar hur du ställer in skrivskydd för en presentation:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"123123");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **Läs in en krypterad presentation**

Aspose.Slides låter dig läsa in en krypterad fil genom att ange dess lösenord. För att dekryptera en presentation måste du anropa [RemoveEncryption](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d)-metoden utan parametrar. Du måste sedan ange rätt lösenord för att läsa in presentationen.

Det här exempelprogrammet visar hur du dekrypterar en presentation:

``` cpp
#include <DOM/LoadOptions.h>
using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

// arbeta med avkrypterad presentation
```

## **Ta bort kryptering från en presentation**

Du kan ta bort krypteringen eller lösenordsskyddet på en presentation. På så sätt kan användare få åtkomst till eller modifiera presentationen utan begränsningar.

För att ta bort kryptering eller lösenordsskydd måste du anropa [RemoveEncryption](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d)-metoden. Detta exempelprogram visar hur du tar bort krypteringen från en presentation:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **Ta bort skrivskydd från en presentation**

Du kan använda Aspose.Slides för att ta bort skrivskyddet som används på en presentationsfil. På så sätt kan användare modifiera som de vill—utan varningar när de utför sådana åtgärder.

Du kan ta bort skrivskyddet från en presentation genom att använda [RemoveWriteProtection](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.protection_manager#a9f9e6de5983965157dac0f270a0a9e50)-metoden. Detta exempelprogram visar hur du tar bort skrivskyddet från en presentation:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **Hämta egenskaper för en krypterad presentation**

Vanligtvis har användare svårt att hämta dokumentegenskaperna för en krypterad eller lösenordsskyddad presentation. Aspose.Slides tillhandahåller dock en mekanism som gör att du kan lösenordsskydda en presentation samtidigt som du behåller åtkomsten till dess dokumentegenskaper.

**Obs:** Som standard, när Aspose.Slides krypterar en presentation, är presentationens dokumentegenskaper också lösenordsskyddade. Om du behöver göra dokumentegenskaperna tillgängliga även efter kryptering, låter Aspose.Slides dig göra just det.

Om du vill att användarna ska behålla möjligheten att komma åt egenskaperna för en krypterad presentation, skicka `false` till `set_EncryptDocumentProperties`‑metoden i [IProtectionManager](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iprotectionmanager/). Detta exempelprogram visar hur du krypterar en presentation samtidigt som du ger användarna åtkomst till dess dokumentegenskaper:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->set_EncryptDocumentProperties(false);
presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Läs endast dokumentegenskaper från en krypterad presentation**

För att inspektera metadata för en krypterad presentation utan att läsa in dess bilder eller annat innehåll, skapa ett [LoadOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides/loadoptions/)-objekt och sätt [set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/sv/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/)-metoden till `true`. I detta läge ignorerar Aspose.Slides lösenordet och läser endast de dokumentegenskaper som är offentligt tillgängliga.

Följande kodexempel läser inbyggda och anpassade dokumentegenskaper via [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentation/get_documentproperties/):

``` cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);
auto documentProperties = presentation->get_DocumentProperties();

// Read built-in document properties.
auto title = documentProperties->get_Title();
auto author = documentProperties->get_Author();
Console::WriteLine(String(u"Title: ") + title);
Console::WriteLine(String(u"Author: ") + author);

// Read custom document properties.
int customPropertyCount = documentProperties->get_CountOfCustomProperties();

for (int propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++)
{
    auto propertyName = documentProperties->GetCustomPropertyName(propertyIndex);
    auto propertyValue = documentProperties->idx_get(propertyName);
    auto propertyValueText = ObjectExt::ToString(propertyValue);

    Console::WriteLine(propertyName + u": " + propertyValueText);
}

presentation->Dispose();
```

Detta arbetsflöde fungerar endast när dokumentegenskaperna lämnades okrypterade (offentliga) när presentationen krypterades. Om dokumentegenskaperna är krypterade, kommer inställning av `LoadOptions::set_OnlyLoadDocumentProperties` till `true` att orsaka ett undantag eftersom lösenordet ignoreras i detta läge. För att komma åt krypterade dokumentegenskaper eller läsa in hela presentationen, inklusive dess bilder och annat innehåll, ange rätt lösenord med `LoadOptions::set_Password` i [LoadOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides/loadoptions/).

## **Kontrollera om en presentation är lösenordsskyddad**

Innan du läser in en presentation kan du vilja kontrollera och bekräfta att presentationen inte är skyddad med ett lösenord. På så sätt undviker du fel och liknande problem som uppstår när en lösenordsskyddad presentation läses in utan dess lösenord.

Denna C++‑kod visar hur du undersöker en presentation för att se om den är lösenordsskyddad (utan att läsa in själva presentationen):

```c++
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"example.pptx");
System::Console::WriteLine(System::String(u"The presentation is password protected: ") +
                           presentationInfo->get_IsPasswordProtected());
```

## **Kontrollera om en presentation är krypterad**

Aspose.Slides låter dig kontrollera om en presentation är krypterad. För att utföra detta kan du använda [get_IsEncrypted()](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.protection_manager#ad88b984e44b378f335317ded49b34e68)-metoden, som returnerar `true` om presentationen är krypterad eller `false` om den inte är krypterad.

Detta exempelprogram visar hur du kontrollerar om en presentation är krypterad:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
```

## **Kontrollera om en presentation är skrivskyddad**

Aspose.Slides låter dig kontrollera om en presentation är skrivskyddad. För att utföra detta kan du använda [get_IsWriteProtected()](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.protection_manager#a0b4a82c0f7b3a32ca5762c5fcc8844a2)-metoden, som returnerar `true` om presentationen är skrivskyddad eller `false` om den inte är skrivskyddad.

Detta exempelprogram visar hur du kontrollerar om en presentation är skrivskyddad:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsWriteProtected();
```

## **Verifiera om presentationslösenord har använts**

Du kanske vill kontrollera och bekräfta att ett specifikt lösenord har använts för att skydda ett presentationsdokument. Aspose.Slides erbjuder möjligheten att validera ett lösenord.

Detta exempelprogram visar hur du validerar ett lösenord:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");

// kontrollera om "pass" matchar
bool isWriteProtected = pres->get_ProtectionManager()->CheckWriteProtection(u"my_password");
```

Den returnerar `true` om presentationen har krypterats med det angivna lösenordet. Annars returnerar den `false`.

{{% alert color="info" title="Se också" %}} 
- [Digital Signature in PowerPoint](/slides/sv/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Vilka krypteringsmetoder stöds av Aspose.Slides?**

Aspose.Slides stöder moderna krypteringsmetoder, inklusive AES-baserade algoritmer, vilket säkerställer en hög datasäkerhetsnivå för dina presentationer.

**Vad händer om ett felaktigt lösenord anges när du försöker öppna en presentation?**

Ett undantag kastas om ett felaktigt lösenord används, vilket varnar dig om att åtkomst till presentationen nekas. Detta hjälper till att förhindra obehörig åtkomst och skyddar presentationsinnehållet.

**Finns det några prestandapåverkan när du arbetar med lösenordsskyddade presentationer?**

Krypterings- och dekrypteringsprocessen kan innebära en liten extra belastning under öppnings- och sparningsoperationer. I de flesta fall är denna prestandapåverkan minimal och påverkar inte märkbart den totala bearbetningstiden för dina presentationsuppgifter.