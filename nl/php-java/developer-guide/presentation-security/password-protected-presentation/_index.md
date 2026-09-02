---
title: Presentaties beveiligen met wachtwoorden in PHP
linktitle: Wachtwoordbeveiliging
type: docs
weight: 20
url: /nl/php-java/password-protected-presentation/
keywords:
- PowerPoint vergrendelen
- presentatie vergrendelen
- PowerPoint ontgrendelen
- presentatie ontgrendelen
- PowerPoint beveiligen
- presentatie beveiligen
- wachtwoord instellen
- wachtwoord toevoegen
- PowerPoint versleutelen
- presentatie versleutelen
- PowerPoint ontsleutelen
- presentatie ontsleutelen
- schrijfbescherming
- PowerPoint-beveiliging
- presentatiebeveiliging
- wachtwoord verwijderen
- beveiliging verwijderen
- versleuteling verwijderen
- wachtwoord uitschakelen
- beveiliging uitschakelen
- schrijfbescherming verwijderen
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Leer hoe u moeiteloos wachtwoordbeveiligde PowerPoint- en OpenDocument-presentaties kunt vergrendelen en ontgrendelen met Aspose.Slides voor PHP. Beveilig uw presentaties."
---
## **Introductie**

Wanneer je een presentatie met een wachtwoord beveiligt, stel je een wachtwoord in dat bepaalde beperkingen op de presentatie afdwingt. Om de beperkingen te verwijderen, moet het wachtwoord worden ingevoerd. Een met wachtwoord beveiligde presentatie wordt beschouwd als een vergrendelde presentatie.

Meestal kun je een wachtwoord instellen om deze beperkingen op een presentatie af te dwingen:

- **Wijziging**

  Als je wilt dat alleen bepaalde gebruikers jouw presentatie kunnen wijzigen, kun je een wijzigingsbeperking instellen. Deze beperking voorkomt dat mensen de presentatie wijzigen, aanpassen of kopiëren (tenzij ze het wachtwoord verstrekken).

  In dit geval kan een gebruiker echter, zelfs zonder wachtwoord, je document openen. In deze alleen-lezen modus kan de gebruiker de inhoud of elementen — hyperlinks, animaties, effecten en andere — in je presentatie bekijken, maar hij kan geen items kopiëren of de presentatie opslaan.

- **Openen**

  Als je wilt dat alleen bepaalde gebruikers je presentatie kunnen openen, kun je een openingsbeperking instellen. Deze beperking voorkomt dat mensen de inhoud van je presentatie bekijken (tenzij ze het wachtwoord verstrekken).

  Technisch gezien voorkomt de openingsbeperking ook dat gebruikers jouw presentaties wijzigen: wanneer mensen een presentatie niet kunnen openen, kunnen ze deze niet aanpassen of wijzigen.  

  **Opmerking** dat wanneer je een presentatie met een wachtwoord beveiligt om openen te voorkomen, het presentatiebestand wordt versleuteld.

## **Hoe je een presentatie online met een wachtwoord kunt beveiligen**

1. Ga naar onze [**Aspose.Slides Lock**](https://products.aspose.app/slides/nl/lock) pagina. 

   ![todo:image_alt_text](slides-lock.png)

2. Klik op **Drop or upload your files**.

3. Selecteer het bestand dat je wilt beveiligen op je computer. 

4. Voer je gewenste wachtwoord in voor bewerkingsbeveiliging; voer je gewenste wachtwoord in voor weergavebeveiliging. 

5. Als je wilt dat gebruikers je presentatie zien als de definitieve kopie, vink dan het selectievakje **Mark as final** aan.

6. Klik op **PROTECT NOW.** 

7. Klik op **DOWNLOAD NOW.**

## **Wachtwoordbeveiliging voor presentaties in Aspose.Slides**
**Ondersteunde formaten**

Aspose.Slides ondersteunt wachtwoordbeveiliging, versleuteling en vergelijkbare bewerkingen voor presentaties in de volgende formaten: 

- PPTX en PPT – Microsoft PowerPoint Presentation 
- ODP – OpenDocument Presentation 
- OTP – OpenDocument Presentation Template 

**Ondersteunde bewerkingen**

Aspose.Slides stelt je in staat om wachtwoordbeveiliging op presentaties toe te passen om wijzigingen te voorkomen op de volgende manieren:

- Een presentatie versleutelen
- Een schrijfbescherming instellen voor een presentatie

**Andere bewerkingen**

Aspose.Slides stelt je in staat om andere taken met betrekking tot wachtwoordbeveiliging en versleuteling uit te voeren op de volgende manieren:

- Een presentatie ontsleutelen; een versleutelde presentatie openen
- Versleuteling verwijderen; wachtwoordbeveiliging uitschakelen
- Schrijfbescherming van een presentatie verwijderen
- De eigenschappen van een versleutelde presentatie ophalen
- Controleren of een presentatie versleuteld is
- Controleren of een presentatie met een wachtwoord is beveiligd.

## **Een presentatie versleutelen**

Je kunt een presentatie versleutelen door een wachtwoord in te stellen. Om vervolgens de vergrendelde presentatie te wijzigen, moet een gebruiker het wachtwoord invoeren. 

Om een presentatie te versleutelen of met een wachtwoord te beveiligen, moet je de encryptiemethode gebruiken (van [ProtectionManager](https://reference.aspose.com/slides/nl/php-java/aspose.slides/protectionmanager/)) om een wachtwoord voor de presentatie in te stellen. Je geeft het wachtwoord door aan de encryptiemethode en gebruikt de save‑methode om de nu versleutelde presentatie op te slaan.

Deze voorbeeldcode laat zien hoe je een presentatie versleutelt:

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

## **Schrijfbescherming instellen voor een presentatie**

Je kunt een markering toevoegen met de tekst “Do not modify” aan een presentatie. Op deze manier kun je gebruikers laten weten dat je niet wilt dat ze wijzigingen aanbrengen in de presentatie.  

**Opmerking** dat het proces van schrijfbescherming de presentatie niet versleutelt. Daarom kunnen gebruikers – als ze dat willen – de presentatie wijzigen, maar om de wijzigingen op te slaan moeten ze een presentatie met een andere naam aanmaken. 

Om een schrijfbescherming in te stellen, moet je de [setWriteProtection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/protectionmanager/#setWriteProtection)‑methode gebruiken. Deze voorbeeldcode laat zien hoe je een schrijfbescherming voor een presentatie instelt:

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

## **Een versleutelde presentatie laden**

Aspose.Slides stelt je in staat om een versleuteld bestand te laden door het wachtwoord te verstrekken. Om een presentatie te ontsleutelen, moet je de [removeEncryption](https://reference.aspose.com/slides/nl/php-java/aspose.slides/protectionmanager/#removeEncryption)‑methode zonder parameters aanroepen. Vervolgens moet je het juiste wachtwoord invoeren om de presentatie te laden.

Deze voorbeeldcode laat zien hoe je een presentatie ontsleutelt: 

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("123123");
  $presentation = new Presentation("pres.pptx", $loadOptions);
  try {
    # werken met ontsleutelde presentatie
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Versleuteling van een presentatie verwijderen**

Je kunt de versleuteling of wachtwoordbeveiliging van een presentatie verwijderen. Op deze manier kunnen gebruikers de presentatie zonder beperkingen benaderen of wijzigen. 

Om versleuteling of wachtwoordbeveiliging te verwijderen, moet je de [removeEncryption](https://reference.aspose.com/slides/nl/php-java/aspose.slides/protectionmanager/#removeEncryption)‑methode aanroepen. Deze voorbeeldcode laat zien hoe je versleuteling van een presentatie verwijdert:

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

## **Schrijfbescherming van een presentatie verwijderen**

Je kunt Aspose.Slides gebruiken om de schrijfbescherming van een presentatiebestand te verwijderen. Op deze manier kunnen gebruikers wijzigen zoals ze willen — en krijgen ze geen waarschuwingen bij het uitvoeren van dergelijke handelingen.

Je kunt de schrijfbescherming van een presentatie verwijderen met de [removeWriteProtection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/protectionmanager/#removeWriteProtection)‑methode. Deze voorbeeldcode laat zien hoe je de schrijfbescherming van een presentatie verwijdert:

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

## **Eigenschappen van een versleutelde presentatie ophalen**

Gebruikers hebben vaak moeite om de documenteigenschappen van een versleutelde of met een wachtwoord beveiligde presentatie op te halen. Aspose.Slides biedt echter een mechanisme waarmee je een presentatie kunt beveiligen met een wachtwoord en toch de mogelijkheid behoudt voor gebruikers om de eigenschappen te benaderen.

**Opmerking:** Standaard, wanneer Aspose.Slides een presentatie versleutelt, worden de documenteigenschappen van de presentatie ook met een wachtwoord beveiligd. Als je wilt dat de documenteigenschappen toegankelijk blijven, zelfs na versleuteling, biedt Aspose.Slides je die mogelijkheid.

Als je wilt dat gebruikers de eigenschappen van een versleutelde presentatie kunnen blijven benaderen, geef dan `false` door aan [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties). Deze voorbeeldcode laat zien hoe je een presentatie versleutelt terwijl je gebruikers toch toegang geeft tot de documenteigenschappen:

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

## **Alleen documenteigenschappen laden van een versleutelde presentatie**

Om de metadata van een versleutelde presentatie te inspecteren zonder de dia's of andere inhoud te laden, maak je een [LoadOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/loadoptions/)‑object aan en geef je `true` door aan [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties). In deze modus negeert Aspose.Slides het wachtwoord en laadt alleen de publiek toegankelijke documenteigenschappen.

De volgende code‑voorbeeld leest ingebouwde en aangepaste documenteigenschappen via [Presentation::getDocumentProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#getDocumentProperties):

```php
$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $documentProperties = $presentation->getDocumentProperties();

    # Lees ingebouwde documenteigenschappen.
    echo("Title: " . $documentProperties->getTitle() . "\n");
    echo("Author: " . $documentProperties->getAuthor() . "\n");

    # Lees aangepaste documenteigenschappen.
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

Deze workflow werkt alleen wanneer de documenteigenschappen onversleuteld (publiek) zijn gelaten tijdens het versleutelen van de presentatie. Als de documenteigenschappen versleuteld zijn, leidt het doorgeven van `true` aan [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) tot een uitzondering omdat het wachtwoord in deze modus wordt genegeerd. Om versleutelde documenteigenschappen te benaderen of de volledige presentatie, inclusief dia's en andere inhoud, te laden, geef je het juiste wachtwoord door aan [LoadOptions::setPassword](https://reference.aspose.com/slides/nl/php-java/aspose.slides/loadoptions/#setPassword).

## **Controleren of een presentatie met een wachtwoord is beveiligd**

Voordat je een presentatie laadt, wil je misschien controleren of de presentatie niet met een wachtwoord is beveiligd. Op deze manier kun je fouten en soortgelijke problemen voorkomen die ontstaan wanneer een met wachtwoord beveiligde presentatie zonder wachtwoord wordt geladen.

Deze PHP‑code laat zien hoe je een presentatie kunt onderzoeken om te zien of deze met een wachtwoord is beveiligd (zonder de presentatie zelf te laden):

```php
  $presentationInfo = PresentationFactory->getInstance()->getPresentationInfo("example.pptx");
  echo("The presentation is password protected: " . $presentationInfo->isPasswordProtected());

```

## **Controleren of een presentatie versleuteld is**

Aspose.Slides maakt het mogelijk om te controleren of een presentatie versleuteld is. Om deze taak uit te voeren, kun je de [isEncrypted](https://reference.aspose.com/slides/nl/php-java/aspose.slides/protectionmanager/#isEncrypted)‑methode gebruiken, die `true` retourneert als de presentatie versleuteld is of `false` als de presentatie niet versleuteld is.

Deze voorbeeldcode laat zien hoe je controleert of een presentatie versleuteld is:

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

## **Controleren of een presentatie schrijfbeschermd is**

Aspose.Slides maakt het mogelijk om te controleren of een presentatie schrijfbeschermd is. Om deze taak uit te voeren, kun je de [isWriteProtected](https://reference.aspose.com/slides/nl/php-java/aspose.slides/protectionmanager/#isWriteProtected)‑methode gebruiken, die `true` retourneert als de presentatie versleuteld is of `false` als de presentatie niet versleuteld is.

Deze voorbeeldcode laat zien hoe je controleert of een presentatie schrijfbeschermd is:

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

## **Valideren of bevestigen dat een specifiek wachtwoord is gebruikt**

Je wilt mogelijk controleren en bevestigen dat een specifiek wachtwoord is gebruikt om een presentatiedocument te beveiligen. Aspose.Slides biedt de mogelijkheid om een wachtwoord te valideren. 

Deze voorbeeldcode laat zien hoe je een wachtwoord valideert:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    # controleer of "pass" overeenkomt met
    $isWriteProtected = $presentation->getProtectionManager()->checkWriteProtection("my_password");
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

Hij retourneert `true` als de presentatie is versleuteld met het opgegeven wachtwoord. Anders retourneert hij `false`. 

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/nl/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Welke versleutelingsmethoden ondersteunt Aspose.Slides?**

Aspose.Slides ondersteunt moderne versleutelingsmethoden, waaronder AES‑gebaseerde algoritmen, waardoor een hoog niveau van gegevensbeveiliging voor je presentaties wordt gegarandeerd.

**Wat gebeurt er als een onjuist wachtwoord wordt ingevoerd bij het proberen te openen van een presentatie?**

Er wordt een uitzondering gegooid wanneer een onjuist wachtwoord wordt gebruikt, waarmee je wordt gewaarschuwd dat de toegang tot de presentatie wordt geweigerd. Dit helpt ongeautoriseerde toegang te voorkomen en beschermt de inhoud van de presentatie.

**Zijn er prestatie‑implicaties bij het werken met met wachtwoord beveiligde presentaties?**

Het versleutelings‑ en ontsleutelingsproces kan een lichte extra belasting veroorzaken tijdens open‑ en opslaan‑handelingen. In de meeste gevallen is deze impact minimaal en heeft het geen significante invloed op de totale verwerkingstijd van je presentatietaken.