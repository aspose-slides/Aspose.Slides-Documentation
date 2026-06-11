---
title: Säkra presentationer med lösenord i PHP
linktitle: Lösenordsskydd
type: docs
weight: 20
url: /sv/php-java/password-protected-presentation/
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
- PHP
- Aspose.Slides
description: Lär dig hur du enkelt låser och låser upp lösenordsskyddade PowerPoint- och OpenDocument-presentationer med Aspose.Slides för PHP. Säkra dina presentationer.
---
## **Introduktion**

När du lösenordsskyddar en presentation betyder det att du ställer in ett lösenord som verkställer vissa begränsningar för presentationen. För att ta bort begränsningarna måste lösenordet anges. En lösenordsskyddad presentation betraktas som en låst presentation.

Vanligtvis kan du ange ett lösenord för att verkställa dessa begränsningar på en presentation:

- **Modifiering**

  Om du vill att endast vissa användare ska kunna ändra din presentation kan du ställa in en ändringsbegränsning. Begränsningen hindrar människor från att modifiera, ändra eller kopiera saker i din presentation (såvida de inte anger lösenordet). 

  Dock, i detta fall, kan en användare även utan lösenord komma åt ditt dokument och öppna det. I detta skrivskyddade läge kan användaren visa innehållet eller objekt—hyperlänkar, animationer, effekter och annat—i din presentation, men de kan inte kopiera objekt eller spara presentationen. 

- **Öppning**

  Om du vill att endast vissa användare ska kunna öppna din presentation kan du ställa in en öppningsbegränsning. Begränsningen hindrar människor från ens att se innehållet i din presentation (såvida de inte anger lösenordet).

  Teknisk sett hindrar öppningsbegränsningen även användare från att modifiera dina presentationer: När personer inte kan öppna en presentation kan de inte göra ändringar i den. 

**Obs!** att när du lösenordsskyddar en presentation för att hindra öppning blir presentationsfilen krypterad.

## **Hur man lösenordsskyddar en presentation online**

1. Gå till vår [**Aspose.Slides Lock**](https://products.aspose.app/slides/sv/lock)-sida. 

   ![todo:image_alt_text](slides-lock.png)

2. Klicka på **Släpp eller ladda upp dina filer**.

3. Välj den fil du vill lösenordsskydda på din dator. 

4. Ange ditt önskade lösenord för redigering; ange ditt önskade lösenord för visning. 

5. Om du vill att användare ska se din presentation som den slutgiltiga kopian, markera kryssrutan **Mark as final**.

6. Klicka på **PROTECT NOW.** 

7. Klicka på **DOWNLOAD NOW.**

## **Lösenordsskydd för presentationer i Aspose.Slides**
**Stödda format**

Aspose.Slides stödjer lösenordsskydd, kryptering och liknande operationer för presentationer i följande format: 

- PPTX and PPT - Microsoft PowerPoint-presentation 
- ODP - OpenDocument-presentation 
- OTP - OpenDocument-presentationmall 

**Stödda operationer**

Aspose.Slides låter dig använda lösenordsskydd på presentationer för att förhindra ändringar på följande sätt:

- Kryptera en presentation
- Sätta ett skrivskydd på en presentation

**Övriga operationer**

Aspose.Slides låter dig utföra andra uppgifter relaterade till lösenordsskydd och kryptering på följande sätt:

- Dekryptera en presentation; öppna en krypterad presentation
- Ta bort kryptering; inaktivera lösenordsskydd
- Ta bort skrivskydd från en presentation
- Hämta egenskaperna för en krypterad presentation
- Kontrollera om en presentation är krypterad
- Kontrollera om en presentation är lösenordsskyddad.

## **Kryptera en presentation**

Du kan kryptera en presentation genom att ange ett lösenord. För att sedan ändra den låsta presentationen måste en användare ange lösenordet. 

För att kryptera eller lösenordsskydda en presentation måste du använda encrypt‑metoden (från [ProtectionManager](https://reference.aspose.com/slides/sv/php-java/aspose.slides/protectionmanager/)) för att ange ett lösenord för presentationen. Du skickar lösenordet till encrypt‑metoden och använder save‑metoden för att spara den nu krypterade presentationen.

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->encrypt("123123");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Sätt skrivskydd på en presentation**

Du kan lägga till en märkning som säger ”Do not modify” på en presentation. På så sätt kan du informera användarna om att du inte vill att de ska göra ändringar i presentationen.  

**Obs!** att skrivskyddsprocessen inte krypterar presentationen. Därför kan användare—om de faktiskt vill—modifiera presentationen, men för att spara ändringarna måste de skapa en presentation med ett annat namn. 

För att sätta ett skrivskydd måste du använda metoden [setWriteProtection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/protectionmanager/#setWriteProtection). Detta exempel visar hur du sätter ett skrivskydd på en presentation:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->setWriteProtection("123123");
    $presentation->save("write-protected-pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Läs in en krypterad presentation**

Aspose.Slides låter dig läsa in en krypterad fil genom att ange dess lösenord. För att dekryptera en presentation måste du anropa metoden [removeEncryption](https://reference.aspose.com/slides/sv/php-java/aspose.slides/protectionmanager/#removeEncryption) utan parametrar. Du måste sedan ange rätt lösenord för att läsa in presentationen.

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("123123");
  $presentation = new Presentation("pres.pptx", $loadOptions);
  try {
    # arbeta med dekrypterad presentation
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Ta bort kryptering från en presentation**

Du kan ta bort kryptering eller lösenordsskydd på en presentation. På så sätt kan användare få åtkomst till eller modifiera presentationen utan begränsningar. 

För att ta bort kryptering eller lösenordsskydd måste du anropa metoden [removeEncryption](https://reference.aspose.com/slides/sv/php-java/aspose.slides/protectionmanager/#removeEncryption). Detta exempel visar hur du tar bort kryptering från en presentation:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("123123");
  $presentation = new Presentation("pres.pptx", $loadOptions);
  try {
    $presentation->getProtectionManager()->removeEncryption();
    $presentation->save("encryption-removed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Ta bort skrivskydd från en presentation**

Du kan använda Aspose.Slides för att ta bort skrivskyddet som används på en presentationsfil. På så sätt kan användare modifiera som de vill—och de får inga varningar när de utför sådana uppgifter.

Du kan ta bort skrivskyddet från en presentation genom att använda metoden [removeWriteProtection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/protectionmanager/#removeWriteProtection). Detta exempel visar hur du tar bort skrivskyddet från en presentation:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->removeWriteProtection();
    $presentation->save("write-protection-removed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Hämta egenskaperna för en krypterad presentation**

Vanligtvis har användare svårt att hämta dokumentegenskaperna för en krypterad eller lösenordsskyddad presentation. Aspose.Slides erbjuder dock en mekanism som låter dig lösenordsskydda en presentation samtidigt som du behåller möjligheten för användare att komma åt egenskaperna för den presentationen.

**Obs!** att när Aspose.Slides krypterar en presentation blir presentationens dokumentegenskaper också lösenordsskyddade som standard. Men om du behöver göra presentationens egenskaper åtkomliga (även efter att presentationen har krypterats) så tillåter Aspose.Slides dig att göra just det.

Om du vill att användare ska behålla möjligheten att komma åt egenskaperna för en presentation du har krypterat kan du använda metoden [encryptDocumentProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/protectionmanager/#getEncryptDocumentProperties) med värdet `true`. Detta exempel visar hur du krypterar en presentation samtidigt som du ger användare möjlighet att komma åt dess dokumentegenskaper:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->setEncryptDocumentProperties(true);
    $presentation->getProtectionManager()->encrypt("123123");
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Kontrollera om en presentation är lösenordsskyddad**

Innan du läser in en presentation kanske du vill kontrollera och bekräfta att presentationen inte har skyddats med ett lösenord. På så sätt undviker du fel och liknande problem som uppstår när en lösenordsskyddad presentation läses in utan sitt lösenord.

Denna PHP‑kod visar hur du undersöker en presentation för att se om den är lösenordsskyddad (utan att läsa in presentationen själv):

```php
  $presentationInfo = PresentationFactory->getInstance()->getPresentationInfo("example.pptx");
  echo("The presentation is password protected: " . $presentationInfo->isPasswordProtected());

```

## **Kontrollera om en presentation är krypterad**

Aspose.Slides låter dig kontrollera om en presentation är krypterad. För att utföra denna uppgift kan du använda metoden [isEncrypted](https://reference.aspose.com/slides/sv/php-java/aspose.slides/protectionmanager/#isEncrypted), som returnerar `true` om presentationen är krypterad eller `false` om den inte är krypterad.

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $isEncrypted = $presentation->getProtectionManager()->isEncrypted();
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Kontrollera om en presentation är skrivskyddad**

Aspose.Slides låter dig kontrollera om en presentation är skrivskyddad. För att utföra denna uppgift kan du använda metoden [isWriteProtected](https://reference.aspose.com/slides/sv/php-java/aspose.slides/protectionmanager/#isWriteProtected), som returnerar `true` om presentationen är skrivskyddad eller `false` om den inte är skrivskyddad.

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $isEncrypted = $presentation->getProtectionManager()->isWriteProtected();
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Validera eller bekräfta att ett specifikt lösenord har använts**

Du kanske vill kontrollera och bekräfta att ett specifikt lösenord har använts för att skydda ett presentationsdokument. Aspose.Slides tillhandahåller medel för att validera ett lösenord. 

Denna exempelkod visar hur du validerar ett lösenord:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    # kontrollera om "pass" matchar
    $isWriteProtected = $presentation->getProtectionManager()->checkWriteProtection("my_password");
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

Den returnerar `true` om presentationen har krypterats med det angivna lösenordet. Annars returnerar den `false`. 

{{% alert color="primary" title="Se även" %}} 
- [Digital Signature in PowerPoint](/slides/sv/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Vilka krypteringsmetoder stöds av Aspose.Slides?**

Aspose.Slides stödjer moderna krypteringsmetoder, inklusive AES‑baserade algoritmer, vilket säkerställer en hög nivå av datasäkerhet för dina presentationer.

**Vad händer om ett felaktigt lösenord anges när man försöker öppna en presentation?**

Ett undantag kastas om ett felaktigt lösenord används, vilket varnar dig om att åtkomst till presentationen nekas. Detta hjälper till att förhindra obehörig åtkomst och skyddar presentationens innehåll.

**Finns det några prestandapåverkan när man arbetar med lösenordsskyddade presentationer?**

Krypterings- och dekrypteringsprocessen kan medföra en liten extra belastning vid öppnings‑ och sparningsoperationer. I de flesta fall är denna prestandapåverkan minimal och påverkar inte nämnvärt den totala bearbetningstiden för dina presentationsuppgifter.