---
title: Säkra presentationer med lösenord i C++
linktitle: Lösenordsskydd
type: docs
weight: 20
url: /sv/cpp/password-protected-presentation/
keywords:
- Låsa PowerPoint
- Låsa presentation
- Låsa upp PowerPoint
- Låsa upp presentation
- Skydda PowerPoint
- Skydda presentation
- Ange lösenord
- Lägg till lösenord
- Kryptera PowerPoint
- Kryptera presentation
- Dekryptera PowerPoint
- Dekryptera presentation
- Skrivskydd
- PowerPoint-säkerhet
- Presentationssäkerhet
- Ta bort lösenord
- Ta bort skydd
- Ta bort kryptering
- Inaktivera lösenord
- Inaktivera skydd
- Ta bort skrivskydd
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Lär dig hur du enkelt låser och låser upp lösenordsskyddade PowerPoint- och OpenDocument-presentationer med Aspose.Slides för C++. Säkerställ dina presentationer."
---
## **Introduktion**

När du lösenordsskyddar en presentation betyder det att du anger ett lösenord som tillämpar vissa begränsningar på presentationen. För att ta bort begränsningarna måste lösenordet anges. En lösenordsskyddad presentation anses vara en låst presentation.

Vanligtvis kan du ange ett lösenord för att tillämpa dessa begränsningar på en presentation:

- **Modifiering**

  Om du bara vill att vissa användare ska kunna ändra din presentation kan du ställa in en ändringsbegränsning. Begränsningen här hindrar personer från att modifiera, ändra eller kopiera saker i din presentation (såvida de inte anger lösenordet). 

  Dock, i detta fall kommer en användare även utan lösenord att kunna komma åt ditt dokument och öppna det. I detta skrivskyddade läge kan användaren se innehållet eller saker—hyperlänkar, animationer, effekter och andra—i din presentation, men de kan inte kopiera objekt eller spara presentationen. 

- **Öppning**

  Om du bara vill att vissa användare ska kunna öppna din presentation kan du ställa in en öppningsbegränsning. Begränsningen här hindrar personer från ens att visa innehållet i din presentation (såvida de inte anger lösenordet).

  Tekniskt förhindrar öppningsbegränsningen även att användare modifierar dina presentationer: När personer inte kan öppna en presentation kan de inte göra ändringar i den. 
  
  **Obs** att när du lösenordsskyddar en presentation för att förhindra öppning blir presentationsfilen krypterad.

## **Hur du lösenordsskyddar en presentation online**

1. Gå till vår [**Aspose.Slides Lock**](https://products.aspose.app/slides/sv/lock) sida. 

   ![todo:image_alt_text](slides-lock.png)

2. Klicka på **Drop or upload your files**.

3. Välj den fil du vill lösenordsskydda på din dator. 

4. Ange ditt föredragna lösenord för redigeringsskydd; ange ditt föredragna lösenord för visningsskydd. 

5. Om du vill att användare ska se din presentation som den slutgiltiga kopian, markera kryssrutan **Mark as final**.

6. Klicka på **PROTECT NOW.** 

7. Klicka på **DOWNLOAD NOW.**

## **Lösenordsskydd för presentationer i Aspose.Slides**
**Stödda format**

Aspose.Slides stödjer lösenordsskydd, kryptering och liknande operationer för presentationer i följande format: 

- PPTX and PPT - Microsoft PowerPoint Presentation 
- ODP - OpenDocument Presentation 
- OTP -  OpenDocument Presentation Template 

**Stödda operationer**

Aspose.Slides låter dig använda lösenordsskydd på presentationer för att förhindra modifieringar på följande sätt:

- Kryptera en presentation
- Ställa in skrivskydd för en presentation

**Andra operationer**

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

Den här exempel­koden visar hur du krypterar en presentation:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **Ställ in skrivskydd för en presentation** 

Du kan lägga till en markering som säger ”Do not modify” i en presentation. På så sätt kan du berätta för användare att du inte vill att de ska göra ändringar i presentationen.  

**Obs** att skrivskyddsprocessen inte krypterar presentationen. Därför kan användare—om de verkligen vill—modifiera presentationen, men för att spara ändringarna måste de skapa en presentation med ett annat namn. 

För att ställa in skrivskydd måste du använda metoden setWriteProtection. Den här exempel­koden visar hur du sätter ett skrivskydd på en presentation:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"123123");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **Läs in en krypterad presentation**

Aspose.Slides låter dig läsa in en krypterad fil genom att ange dess lösenord. För att dekryptera en presentation måste du anropa metoden [RemoveEncryption](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) utan parametrar. Därefter måste du ange rätt lösenord för att läsa in presentationen. 

Den här exempel­koden visar hur du dekrypterar en presentation: 

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

// arbeta med avkrypterad presentation
```

## **Ta bort kryptering från en presentation**

Du kan ta bort krypteringen eller lösenordsskyddet på en presentation. På så sätt kan användare komma åt eller modifiera presentationen utan begränsningar. 

För att ta bort kryptering eller lösenordsskydd måste du anropa metoden [RemoveEncryption](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d). Den här exempel­koden visar hur du tar bort kryptering från en presentation:

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **Ta bort skrivskydd från en presentation**

Du kan använda Aspose.Slides för att ta bort skrivskyddet som använts på en presentationsfil. På så sätt kan användare modifiera fritt—och de får inga varningar när de utför sådana åtgärder.

Du kan ta bort skrivskyddet från en presentation genom att använda metoden [RemoveWriteProtection](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.protection_manager#a9f9e6de5983965157dac0f270a0a9e50). Den här exempel­koden visar hur du tar bort skrivskyddet från en presentation:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **Hämta egenskaperna för en krypterad presentation**

Vanligtvis har användare svårt att hämta dokumentegenskaperna för en krypterad eller lösenordsskyddad presentation. Aspose.Slides erbjuder dock en mekanism som låter dig lösenordsskydda en presentation samtidigt som du behåller möjligheten för användare att komma åt presentationens egenskaper.

**Obs** att när Aspose.Slides krypterar en presentation blir presentationens dokumentegenskaper också lösenordsskyddade som standard. Men om du behöver göra presentationens egenskaper tillgängliga (även efter att presentationen har krypterats) så låter Aspose.Slides dig göra just det. 

Om du vill att användare ska behålla möjligheten att komma åt egenskaperna för en presentation du har krypterat kan du skicka `true` till metoden [set_EncryptDocumentProperties()](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.protection_manager#a67e041b432552969d106f72fa7fe5a1d). Den här exempel­koden visar hur du krypterar en presentation samtidigt som du ger användare möjlighet att komma åt dess dokumentegenskaper:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->set_EncryptDocumentProperties(true);
presentation->get_ProtectionManager()->Encrypt(u"123123");
```

## **Kontrollera om en presentation är lösenordsskyddad**

Innan du läser in en presentation kanske du vill kontrollera och bekräfta att presentationen inte är skyddad med ett lösenord. På så sätt undviker du fel och liknande problem som uppstår när en lösenordsskyddad presentation läses in utan sitt lösenord.

Den här C++‑koden visar hur du undersöker en presentation för att se om den är lösenordsskyddad (utan att läsa in presentationen själv):

```c++
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"example.pptx");
System::Console::WriteLine(System::String(u"The presentation is password protected: ") +
                           presentationInfo->get_IsPasswordProtected());
```

## **Kontrollera om en presentation är krypterad**

Aspose.Slides låter dig kontrollera om en presentation är krypterad. För att utföra detta kan du använda metoden [get_IsEncrypted()](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.protection_manager#ad88b984e44b378f335317ded49b34e68), som returnerar `true` om presentationen är krypterad eller `false` om den inte är krypterad. 

Den här exempel­koden visar hur du kontrollerar om en presentation är krypterad:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
```

## **Kontrollera om en presentation är skrivskyddad**

Aspose.Slides låter dig kontrollera om en presentation är skrivskyddad. För att utföra detta kan du använda metoden [get_IsWriteProtected()](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.protection_manager#a0b4a82c0f7b3a32ca5762c5fcc8844a2), som returnerar `true` om presentationen är skrivskyddad eller `false` om den inte är skrivskyddad. 

Den här exempel­koden visar hur du kontrollerar om en presentation är skrivskyddad:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsWriteProtected();
```

## **Verifiera användning av presentationslösenord**

Du kanske vill kontrollera och bekräfta att ett specifikt lösenord har använts för att skydda ett presentationsdokument. Aspose.Slides tillhandahåller möjligheten att validera ett lösenord. 

Den här exempel­koden visar hur du validerar ett lösenord:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

// kontrollera om "pass" stämmer med
bool isWriteProtected = pres->get_ProtectionManager()->CheckWriteProtection(u"my_password");
```

Den returnerar `true` om presentationen har krypterats med det angivna lösenordet. Annars returnerar den `false`. 

{{% alert color="primary" title="Se även" %}} 
- [Digital Signature in PowerPoint](/slides/sv/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Vilka krypteringsmetoder stöds av Aspose.Slides?**

Aspose.Slides stödjer moderna krypteringsmetoder, inklusive AES‑baserade algoritmer, vilket säkerställer en hög nivå av datasäkerhet för dina presentationer.

**Vad händer om ett felaktigt lösenord anges när man försöker öppna en presentation?**

Ett undantag kastas om ett felaktigt lösenord används, vilket varnar dig om att åtkomst till presentationen nekas. Detta hjälper till att förhindra obehörig åtkomst och skyddar presentationsinnehållet.

**Finns det några prestandapåverkan när man arbetar med lösenordsskyddade presentationer?**

Krypterings‑ och dekrypteringsprocessen kan medföra en liten extra belastning vid öppnings‑ och spara‑operationer. I de flesta fall är denna prestandapåverkan minimal och påverkar inte avsevärt den totala bearbetningstiden för dina presentationsuppgifter.