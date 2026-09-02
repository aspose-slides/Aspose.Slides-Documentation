---
title: Presentaties beveiligen met wachtwoorden in .NET
linktitle: Wachtwoordbeveiliging
type: docs
weight: 20
url: /nl/net/password-protected-presentation/
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
- schrijfbeveiliging
- PowerPoint-beveiliging
- presentatiebeveiliging
- wachtwoord verwijderen
- beveiliging verwijderen
- versleuteling verwijderen
- wachtwoord uitschakelen
- beveiliging uitschakelen
- schrijfbeveiliging verwijderen
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u moeiteloos wachtwoord-beveiligde PowerPoint- en OpenDocument-presentaties kunt vergrendelen en ontgrendelen met Aspose.Slides voor .NET. Beveilig uw presentaties."
---
## **Inleiding**

Wanneer je een presentatie met een wachtwoord beveiligt, stel je een wachtwoord in dat bepaalde beperkingen oplegt aan de presentatie. Om deze beperkingen te verwijderen, moet het wachtwoord worden ingevoerd. Een met wachtwoord beveiligde presentatie wordt beschouwd als een vergrendelde presentatie.

Normaal kun je een wachtwoord instellen om deze beperkingen op een presentatie af te dwingen:

- **Wijziging**

Als je wilt dat alleen bepaalde gebruikers je presentatie mogen wijzigen, kun je een wijzigingsbeperking instellen. Deze beperking voorkomt dat mensen elementen in je presentatie wijzigen, aanpassen of kopiëren tenzij ze het wachtwoord invoeren. 

Echter, zelfs zonder het wachtwoord kan een gebruiker nog steeds toegang krijgen tot en je document openen. In deze alleen‑lezen modus kan de gebruiker de inhoud bekijken—waaronder hyperlinks, animaties, effecten en andere elementen—in je presentatie, maar hij/zij kan geen items kopiëren of de presentatie opslaan.

- **Openen**

Als je wilt dat alleen bepaalde gebruikers je presentatie mogen openen, kun je een openingsbeperking instellen. Deze beperking voorkomt dat mensen zelfs de inhoud van je presentatie kunnen bekijken tenzij ze het wachtwoord invoeren.

Technisch gezien voorkomt de openingsbeperking ook dat gebruikers je presentaties wijzigen—als mensen een presentatie niet kunnen openen, kunnen ze deze niet wijzigen of er wijzigingen in aanbrengen.

**Opmerking:** Wanneer je een presentatie met een wachtwoord beveiligt om openen te voorkomen, wordt het presentatiebestand versleuteld.

## **Wachtwoordbeveiliging in Aspose.Slides**

**Ondersteunde formaten**

Aspose.Slides ondersteunt wachtwoordbeveiliging, versleuteling en soortgelijke bewerkingen voor presentaties in de volgende formaten:

- PPTX en PPT – Microsoft PowerPoint‑presentaties
- ODP – OpenDocument‑presentaties
- OTP – OpenDocument‑presentatiesjablonen

**Ondersteunde bewerkingen**

Aspose.Slides stelt je in staat om wachtwoordbeveiliging te gebruiken op presentaties om wijzigingen te voorkomen op de volgende manieren:

- Een presentatie versleutelen
- Schrijfbeveiliging instellen op een presentatie

**Andere bewerkingen**

Aspose.Slides stelt je in staat om aanvullende taken met betrekking tot wachtwoordbeveiliging en versleuteling uit te voeren op de volgende manieren:

- Een presentatie ontsleutelen; een versleutelde presentatie openen
- Versleuteling verwijderen; wachtwoordbeveiliging uitschakelen
- Schrijfbeveiliging van een presentatie verwijderen
- De eigenschappen van een versleutelde presentatie ophalen
- Controleren of een presentatie wachtwoordbeveiligd is voordat deze wordt geladen
- Controleren of een presentatie versleuteld is
- Controleren of een presentatie wachtwoordbeveiligd is

## **Bescherm een presentatie met een wachtwoord**

Je kunt een presentatie versleutelen door een wachtwoord in te stellen. Om vervolgens de vergrendelde presentatie te wijzigen, moet een gebruiker het wachtwoord invoeren.

Om een presentatie te versleutelen (of met een wachtwoord te beveiligen), gebruik je de `Encrypt`‑methode van [ProtectionManager](https://reference.aspose.com/slides/nl/net/aspose.slides/protectionmanager) om een wachtwoord in te stellen. Geef het wachtwoord door aan de `Encrypt`‑methode en gebruik vervolgens de `Save`‑methode om de nu versleutelde presentatie op te slaan.

Deze voorbeeldcode laat zien hoe je een presentatie versleutelt:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```

## **Schrijfbeveiliging instellen op een presentatie** 

Je kunt een markering toevoegen met de tekst "Niet wijzigen" aan een presentatie. Dit informeert gebruikers dat je niet wilt dat ze wijzigingen aanbrengen in de presentatie.

**Opmerking:** Het proces van schrijfbeveiliging versleutelt de presentatie niet. Daarom kunnen gebruikers—indien ze willen—de presentatie wijzigen, maar om de wijzigingen op te slaan moeten ze deze onder een andere naam bewaren.

Om schrijfbeveiliging in te stellen, gebruik je de `SetWriteProtection`‑methode. Deze voorbeeldcode laat zien hoe je schrijfbeveiliging op een presentatie instelt:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```

## **Versleutelde presentatie laden**

Aspose.Slides stelt je in staat om een versleutelde presentatie te laden door het juiste wachtwoord door te geven. Deze voorbeeldcode laat zien hoe je een versleutelde presentatie laadt:

```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    // Werk met de ontsleutelde presentatie.
}
```

## **Versleuteling van een presentatie verwijderen**

Je kunt versleuteling of wachtwoordbeveiliging van een presentatie verwijderen, waardoor gebruikers er zonder beperkingen toegang toe hebben of deze kunnen aanpassen.

Om versleuteling of wachtwoordbeveiliging te verwijderen, roep je de [RemoveEncryption](https://reference.aspose.com/slides/nl/net/aspose.slides/protectionmanager/methods/removeencryption)‑methode aan. Deze voorbeeldcode laat zien hoe je versleuteling van een presentatie verwijdert:

```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```

## **Schrijfbeveiliging van een presentatie verwijderen**

Je kunt met Aspose.Slides de schrijfbeveiliging van een presentiebestand verwijderen. Op deze manier kunnen gebruikers het aanpassen zoals ze willen—en ze ontvangen geen waarschuwingen bij dergelijke handelingen.

Je kunt de schrijfbeveiliging verwijderen door de [RemoveWriteProtection](https://reference.aspose.com/slides/nl/net/aspose.slides/protectionmanager/methods/removewriteprotection)‑methode te gebruiken. Deze voorbeeldcode laat zien hoe je de schrijfbeveiliging van een presentatie verwijdert:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```

## **Eigenschappen van een versleutelde presentatie ophalen**

Normaal hebben gebruikers moeite om de documenteigenschappen van een versleutelde of met wachtwoord beveiligde presentatie op te halen. Aspose.Slides biedt echter een mechanisme waarmee je een presentatie kunt beveiligen met een wachtwoord en toch gebruikers de mogelijkheid geeft haar eigenschappen te benaderen.

**Opmerking:** Standaard worden wanneer Aspose.Slides een presentatie versleutelt, de documenteigenschappen van de presentatie ook met een wachtwoord beveiligd. Als je de documenteigenschappen ook na versleuteling toegankelijk wilt maken, biedt Aspose.Slides je die mogelijkheid.

Als je wilt dat gebruikers de mogelijkheid behouden om de eigenschappen van een versleutelde presentatie te benaderen, stel je de `EncryptDocumentProperties`‑eigenschap van [IProtectionManager](https://reference.aspose.com/slides/nl/net/aspose.slides/iprotectionmanager/) in op `false`. Deze voorbeeldcode laat zien hoe je een presentatie versleutelt en tegelijk gebruikers toegang geeft tot de documenteigenschappen:

```c#
using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.EncryptDocumentProperties = false;
presentation.ProtectionManager.Encrypt("123123");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **Alleen documenteigenschappen laden van een versleutelde presentatie**

Om de metadata van een versleutelde presentatie te inspecteren zonder de dia's of andere inhoud te laden, maak je een [LoadOptions](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/)‑object aan en stel je [OnlyLoadDocumentProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) in op `true`. In deze modus negeert Aspose.Slides het wachtwoord en laadt alleen de documenteigenschappen die openbaar toegankelijk zijn.

De volgende codevoorbeeld leest ingebouwde en aangepaste documenteigenschappen via [IPresentation.DocumentProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentation/documentproperties/):

```c#
var loadOptions = new LoadOptions
{
    OnlyLoadDocumentProperties = true
};

using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);
var documentProperties = presentation.DocumentProperties;

// Read built-in document properties.
Console.WriteLine("Title: " + documentProperties.Title);
Console.WriteLine("Author: " + documentProperties.Author);

// Read custom document properties.
var customPropertyCount = documentProperties.CountOfCustomProperties;

for (var propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++)
{
    var propertyName = documentProperties.GetCustomPropertyName(propertyIndex);
    var propertyValue = documentProperties[propertyName];

    Console.WriteLine(propertyName + ": " + propertyValue);
}
```

Deze workflow werkt alleen wanneer de documenteigenschappen onversleuteld (openbaar) zijn gelaten bij het versleutelen van de presentatie. Als de documenteigenschappen versleuteld zijn, veroorzaakt het instellen van `OnlyLoadDocumentProperties` op `true` een uitzondering omdat het wachtwoord in deze modus wordt genegeerd. Om versleutelde documenteigenschappen te benaderen of de volledige presentatie te laden, inclusief de dia's en andere inhoud, geef je de correcte `Password`‑waarde op in [LoadOptions](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/).

## **Controleren of een presentatie wachtwoordbeveiligd is**

Voordat je een presentatie laadt, wil je misschien controleren of deze niet met een wachtwoord beveiligd is. Dit helpt je fouten en soortgelijke problemen te voorkomen die ontstaan wanneer een wachtwoordbeveiligde presentatie wordt geladen zonder het juiste wachtwoord.

Deze C#‑code laat zien hoe je een presentatie kunt onderzoeken om te zien of deze wachtwoordbeveiligd is zonder deze daadwerkelijk te laden:

```c#
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("The presentation is password protected: " + presentationInfo.IsPasswordProtected);
```

## **Controleren of een presentatie versleuteld is**

Aspose.Slides maakt het mogelijk om te controleren of een presentatie versleuteld is. Hiervoor kun je de eigenschap [IsEncrypted](https://reference.aspose.com/slides/nl/net/aspose.slides/protectionmanager/properties/isencrypted) gebruiken, die `true` retourneert als de presentatie versleuteld is en `false` als dat niet zo is.

Deze voorbeeldcode laat zien hoe je kunt controleren of een presentatie versleuteld is:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```

## **Controleren of een presentatie schrijfbeveiligd is**

Aspose.Slides maakt het mogelijk om te controleren of een presentatie schrijfbeveiligd is. Hiervoor kun je de eigenschap [IsWriteProtected](https://reference.aspose.com/slides/nl/net/aspose.slides/protectionmanager/properties/iswriteprotected) gebruiken, die `true` retourneert als de presentatie schrijfbeveiligd is en `false` als dat niet zo is.

Deze voorbeeldcode laat zien hoe je kunt controleren of een presentatie schrijfbeveiligd is:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```

## **Controleren van wachtwoordgebruik in een presentatie**

Je wilt misschien controleren en bevestigen dat een specifiek wachtwoord is gebruikt om een presentatiedocument te beveiligen. Aspose.Slides biedt de mogelijkheid om een wachtwoord te valideren.

Deze voorbeeldcode laat zien hoe je een wachtwoord valideert:

```c#
using (IPresentation presentation = new Presentation("pres.pptx"))
{
    // Controleer of het wachtwoord overeenkomt.
    bool isWriteProtected = presentation.ProtectionManager.CheckWriteProtection("my_password");
}
```

Deze code geeft `true` terug als de presentatie met het opgegeven wachtwoord is versleuteld; anders geeft ze `false` terug.

{{% alert color="primary" title="Zie ook" %}} 
- [Digitale handtekening in PowerPoint](/slides/nl/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Presentatie online beveiligen met een wachtwoord**

1. Ga naar onze pagina [**Aspose.Slides Lock**](https://products.aspose.app/slides/nl/lock). 
1. Klik op **Sleep of upload je bestanden**.
1. Selecteer het bestand dat je op je computer wilt beveiligen met een wachtwoord. 
1. Voer je gewenste wachtwoord in voor bewerkingsbeveiliging en je gewenste wachtwoord voor weergavebeveiliging.
1. Als je wilt dat gebruikers je presentatie zien als de definitieve versie, vink dan het selectievakje **Mark as final** aan.
1. Klik op **PROTECT NOW.** 
1. Klik op **DOWNLOAD NOW.**

![PowerPoint‑presentaties beveiligen met wachtwoord](slides-lock.png)

## **Veelgestelde vragen**

**Welke encryptiemethoden ondersteunt Aspose.Slides?**

Aspose.Slides ondersteunt moderne encryptiemethoden, waaronder AES‑gebaseerde algoritmen, waardoor een hoog niveau van gegevensbeveiliging voor je presentaties wordt gewaarborgd.

**Wat gebeurt er als er een onjuist wachtwoord wordt ingevoerd bij het proberen te openen van een presentatie?**

Er wordt een uitzondering gegenereerd als een onjuist wachtwoord wordt gebruikt, waardoor je wordt gewaarschuwd dat de toegang tot de presentatie wordt geweigerd. Dit helpt ongeautoriseerde toegang te voorkomen en beschermt de inhoud van de presentatie.

**Zijn er prestatie‑implicaties bij het werken met wachtwoordbeveiligde presentaties?**

Het versleutelings‑ en ontsleutelingsproces kan een kleine extra belasting veroorzaken tijdens het openen en opslaan. In de meeste gevallen is deze prestatie‑impact minimaal en heeft het weinig invloed op de totale verwerkingstijd van je presentatietaken.