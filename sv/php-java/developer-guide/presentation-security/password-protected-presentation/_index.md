---
title: Säkra presentationer med lösenord i PHP
linktitle: Lösenordsskydd
type: docs
weight: 20
url: /sv/php-java/password-protected-presentation/
keywords:
- lås PowerPoint
- lås presentation
- lås upp PowerPoint
- lås upp presentation
- skydda PowerPoint
- skydda presentation
- ange lösenord
- lägg till lösenord
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
description: "Lär dig hur du enkelt låser och låser upp lösenordsskyddade PowerPoint- och OpenDocument-presentationer med Aspose.Slides för PHP. Skydda dina presentationer."
---
## **Introduktion**

När du lösenordsskyddar en presentation betyder det att du sätter ett lösenord som inför vissa begränsningar för presentationen. För att ta bort begränsningarna måste lösenordet anges. En lösenordsskyddad presentation betraktas som en låst presentation.

Vanligtvis kan du ange ett lösenord för att verkställa dessa begränsningar för en presentation:

- **Modifiering**

  Om du vill att endast vissa användare ska modifiera din presentation kan du ange en modifieringsrestriktion. Restriktionen hindrar personer från att ändra, modifiera eller kopiera innehållet i din presentation (om de inte anger lösenordet).

  I detta fall kan en användare ändå komma åt ditt dokument och öppna det utan lösenordet. I skrivskyddat läge kan användaren visa innehållet – hyperlänkar, animationer, effekter och liknande – i presentationen, men de kan inte kopiera objekt eller spara presentationen.

- **Öppning**

  Om du vill att endast vissa användare ska kunna öppna din presentation kan du ange en öppningsrestriktion. Restriktionen hindrar personer från att ens se innehållet i din presentation (om de inte anger lösenordet).

  Tekniskt sett förhindrar öppningsrestriktionen även att användare modifierar dina presentationer: När personer inte kan öppna en presentation kan de inte göra ändringar i den.

  **Observera** att när du lösenordsskyddar en presentation för att förhindra öppning krypteras presentationsfilen.

## **Hur du lösenordsskyddar en presentation online**

1. Gå till vår [**Aspose.Slides Lock**](https://products.aspose.app/slides/sv/lock)-sida.

   ![todo:image_alt_text](slides-lock.png)

2. Klicka **Drop or upload your files**.

3. Välj den fil du vill lösenordsskydda på din dator.

4. Ange ditt föredragna lösenord för redigeringsskydd; ange ditt föredragna lösenord för visningsskydd.

5. Om du vill att användarna ska se din presentation som den slutgiltiga kopian, kryssa i kryssrutan **Mark as final**.

6. Klicka **PROTECT NOW.**

7. Klicka **DOWNLOAD NOW.**

## **Lösenordsskydd för presentationer i Aspose.Slides**
**Stödda format**

Aspose.Slides stöder lösenordsskydd, kryptering och liknande operationer för presentationer i följande format:

- PPTX och PPT – Microsoft PowerPoint Presentation
- ODP – OpenDocument Presentation
- OTP – OpenDocument Presentation Template

**Stödda operationer**

Aspose.Slides låter dig använda lösenordsskydd för att förhindra modifieringar på följande sätt:

- Kryptera en presentation
- Ange skrivskydd för en presentation

**Andra operationer**

Aspose.Slides låter dig utföra andra uppgifter relaterade till lösenordsskydd och kryptering på följande sätt:

- Dekryptera en presentation; öppna en krypterad presentation
- Ta bort kryptering; inaktivera lösenordsskydd
- Ta bort skrivskydd från en presentation
- Hämta egenskaperna för en krypterad presentation
- Kontrollera om en presentation är krypterad
- Kontrollera om en presentation är lösenordsskyddad.

## **Kryptera en presentation**

Du kan kryptera en presentation genom att ange ett lösenord. För att sedan modifiera den låsta presentationen måste en användare ange lösenordet.

För att kryptera eller lösenordsskydda en presentation använder du krypteringsmetoden (från [ProtectionManager](https://reference.aspose.com/slides/sv/php-java/aspose.slides/protectionmanager/)) för att sätta ett lösenord på presentationen. Du passerar lösenordet till krypteringsmetoden och använder spara‑metoden för att spara den nu krypterade presentationen.

Detta exempel visar hur du krypterar en presentation:

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

## **Ange skrivskydd för en presentation**

Du kan lägga till en märkning som säger ”Do not modify” i en presentation. På så sätt kan du tala om för användarna att du inte vill att de ska göra ändringar i presentationen.

**Observera** att skrivskyddsprocessen inte krypterar presentationen. Därför kan användare – om de så önskar – modifiera presentationen, men för att spara ändringarna måste de skapa en ny presentation med ett annat namn.

För att ange skrivskydd använder du metoden [setWriteProtection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/protectionmanager/#setWriteProtection). Detta exempel visar hur du sätter skrivskydd för en presentation:

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

Aspose.Slides låter dig läsa in en krypterad fil genom att ange dess lösenord. För att dekryptera en presentation måste du anropa metoden [removeEncryption](https://reference.aspose.com/slides/sv/php-java/aspose.slides/protectionmanager/#removeEncryption) utan parametrar. Du kommer sedan att bli ombedd att ange rätt lösenord för att läsa in presentationen.

Detta exempel visar hur du dekrypterar en presentation:

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

Du kan ta bort kryptering eller lösenordsskydd från en presentation. På så sätt kan användarna komma åt eller modifiera presentationen utan begränsningar.

För att ta bort kryptering eller lösenordsskydd anropar du metoden [removeEncryption](https://reference.aspose.com/slides/sv/php-java/aspose.slides/protectionmanager/#removeEncryption). Detta exempel visar hur du tar bort kryptering från en presentation:

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

Du kan använda Aspose.Slides för att ta bort skrivskyddet som använts på en presentationsfil. På så sätt kan användarna ändra fritt och får inga varningar när de utför sådana åtgärder.

Du tar bort skrivskyddet från en presentation med metoden [removeWriteProtection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/protectionmanager/#removeWriteProtection). Detta exempel visar hur du tar bort skrivskyddet från en presentation:

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

## **Hämta egenskaper för en krypterad presentation**

Vanligtvis har användare problem med att hämta dokumentegenskaperna för en krypterad eller lösenordsskyddad presentation. Aspose.Slides erbjuder en mekanism som låter dig lösenordsskydda en presentation samtidigt som användarna fortfarande kan komma åt dess egenskaper.

**Obs:** Som standard krypteras dokumentegenskaperna för en presentation när Aspose.Slides krypterar den. Om du vill göra dokumentegenskaperna tillgängliga även efter kryptering låter Aspose.Slides dig göra exakt det.

Om du vill att användarna ska behålla möjlighet att komma åt egenskaperna för en krypterad presentation, skicka `false` till [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties). Detta exempel visar hur du krypterar en presentation samtidigt som du fortfarande ger användarna åtkomst till dess dokumentegenskaper:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->setEncryptDocumentProperties(false);
    $presentation->getProtectionManager()->encrypt("123123");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Läs endast dokumentegenskaper från en krypterad presentation**

För att undersöka metadata för en krypterad presentation utan att ladda dess bildspel eller annat innehåll, skapa ett [LoadOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/loadoptions/)-objekt och skicka `true` till [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties). I detta läge ignorerar Aspose.Slides lösenordet och laddar endast de dokumentegenskaper som är offentligt tillgängliga.

Följande kodexempel läser inbyggda och anpassade dokumentegenskaper via [Presentation::getDocumentProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#getDocumentProperties):

```php
$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $documentProperties = $presentation->getDocumentProperties();

    # Läs inbyggda dokumentegenskaper.
    echo("Title: " . $documentProperties->getTitle() . "\n");
    echo("Author: " . $documentProperties->getAuthor() . "\n");

    # Läs anpassade dokumentegenskaper.
    $customPropertyCount = java_values($documentProperties->getCountOfCustomProperties());

    for ($propertyIndex = 0; $propertyIndex < $customPropertyCount; $propertyIndex++) {
        $propertyName = $documentProperties->getCustomPropertyName($propertyIndex);
        $propertyValue = java_values($documentProperties->get_Item($propertyName));

        echo($propertyName . ": " . $propertyValue . "\n");
    }
} finally {
    $presentation->dispose();
}
```

Detta arbetsflöde fungerar endast när dokumentegenskaperna lämnades okrypterade (offentliga) när presentationen krypterades. Om dokumentegenskaperna är krypterade medför att skicka `true` till [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) ett undantag eftersom lösenordet ignoreras i detta läge. För att komma åt krypterade dokumentegenskaper eller ladda hela presentationen, inklusive bildspel och annat innehåll, ange rätt lösenord via [LoadOptions::setPassword](https://reference.aspose.com/slides/sv/php-java/aspose.slides/loadoptions/#setPassword).

## **Kontrollera om en presentation är lösenordsskyddad**

Innan du laddar en presentation kan du vilja kontrollera och bekräfta att presentationen inte är skyddad med ett lösenord. På så sätt undviker du fel och liknande problem som uppstår när en lösenordsskyddad presentation laddas utan lösenord.

Denna PHP‑kod visar hur du undersöker en presentation för att se om den är lösenordsskyddad (utan att ladda själva presentationen):

```php
  $presentationInfo = PresentationFactory->getInstance()->getPresentationInfo("example.pptx");
  echo("The presentation is password protected: " . $presentationInfo->isPasswordProtected());

```

## **Kontrollera om en presentation är krypterad**

Aspose.Slides låter dig kontrollera om en presentation är krypterad. För att utföra detta använder du metoden [isEncrypted](https://reference.aspose.com/slides/sv/php-java/aspose.slides/protectionmanager/#isEncrypted), som returnerar `true` om presentationen är krypterad och `false` om den inte är det.

Detta exempel visar hur du kontrollerar om en presentation är krypterad:

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

Aspose.Slides låter dig kontrollera om en presentation är skrivskyddad. För att utföra detta använder du metoden [isWriteProtected](https://reference.aspose.com/slides/sv/php-java/aspose.slides/protectionmanager/#isWriteProtected), som returnerar `true` om presentationen är krypterad och `false` om den inte är det.

Detta exempel visar hur du kontrollerar om en presentation är skrivskyddad:

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

Du kanske vill kontrollera och bekräfta att ett specifikt lösenord har använts för att skydda ett presentationsdokument. Aspose.Slides tillhandahåller verktyg för att validera ett lösenord.

Detta exempel visar hur du validerar ett lösenord:

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

Det returnerar `true` om presentationen har krypterats med det angivna lösenordet. Annars returneras `false`.

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/sv/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Vilka krypteringsmetoder stöds av Aspose.Slides?**

Aspose.Slides stöder moderna krypteringsmetoder, inklusive AES‑baserade algoritmer, vilket säkerställer hög datasäkerhet för dina presentationer.

**Vad händer om ett felaktigt lösenord anges när man försöker öppna en presentation?**

Ett undantag kastas om ett felaktigt lösenord används, vilket meddelar att åtkomst till presentationen nekas. Detta hjälper till att förhindra obehörig åtkomst och skyddar presentationsinnehållet.

**Finns det prestandapåverkan när man arbetar med lösenordsskyddade presentationer?**

Krypterings‑ och dekrypteringsprocessen kan lägga till en liten belastning vid öppning och sparande. I de flesta fall är prestandapåverkan minimal och har ingen betydande inverkan på den totala bearbetningstiden för dina presentationsuppgifter.