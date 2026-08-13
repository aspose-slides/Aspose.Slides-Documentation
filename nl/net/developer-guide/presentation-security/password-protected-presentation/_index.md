---
title: Beveilig presentaties met wachtwoorden in .NET
linktitle: Wachtwoordbescherming
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
- schrijfbescherming
- PowerPoint-beveiliging
- beveiliging van presentaties
- wachtwoord verwijderen
- bescherming verwijderen
- versleuteling verwijderen
- wachtwoord uitschakelen
- bescherming uitschakelen
- schrijfbescherming verwijderen
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u moeiteloos wachtwoordbeveiligde PowerPoint- en OpenDocument-presentaties kunt vergrendelen en ontgrendelen met Aspose.Slides voor .NET. Beveilig uw presentaties."
---
## **Inleiding**

Wanneer je een presentatie met een wachtwoord beveiligt, betekent dit dat je een wachtwoord instelt dat bepaalde beperkingen op de presentatie afdwingt. Om deze beperkingen te verwijderen, moet het wachtwoord worden ingevoerd. Een met een wachtwoord beveiligde presentatie wordt beschouwd als een vergrendelde presentatie.

Typisch kun je een wachtwoord instellen om deze beperkingen op een presentatie af te dwingen:

- **Modification**

Als je wilt dat alleen bepaalde gebruikers je presentatie kunnen wijzigen, kun je een wijzigingsbeperking instellen. Deze beperking voorkomt dat mensen elementen in je presentatie wijzigen, aanpassen of kopiëren tenzij ze het wachtwoord invoeren.  

Echter, zelfs zonder het wachtwoord kan een gebruiker je document wel openen en openen. In deze alleen‑lezen modus kan de gebruiker de inhoud—incl. hyperlinks, animaties, effecten en andere elementen—binnen je presentatie bekijken, maar kan hij geen items kopiëren of de presentatie opslaan.

- **Opening**

Als je wilt dat alleen bepaalde gebruikers je presentatie kunnen openen, kun je een openingsbeperking instellen. Deze beperking voorkomt dat mensen zelfs de inhoud van je presentatie kunnen bekijken tenzij ze het wachtwoord invoeren.  

Technisch gezien voorkomt de openingsbeperking ook dat gebruikers je presentaties wijzigen—als mensen een presentatie niet kunnen openen, kunnen ze deze niet wijzigen of aanpassen.

**Opmerking:** Wanneer je een presentatie met een wachtwoord beveiligt om openen te voorkomen, wordt het presentatiedossier versleuteld.

## **Wachtwoordbescherming in Aspose.Slides**

**Supported formats**

Aspose.Slides ondersteunt wachtwoordbescherming, versleuteling en soortgelijke bewerkingen voor presentaties in deze formaten:

- PPTX en PPT – Microsoft PowerPoint‑presentaties
- ODP – OpenDocument‑presentaties
- OTP – OpenDocument‑presentatiesjablonen

**Supported operations**

Aspose.Slides maakt het mogelijk om wachtwoordbescherming te gebruiken op presentaties om bewerkingen te voorkomen op de volgende manieren:

- Een presentatie versleutelen
- Schrijfbescherming instellen op een presentatie

**Other operations**

Aspose.Slides maakt het mogelijk om aanvullende taken uit te voeren die verband houden met wachtwoordbescherming en versleuteling op de volgende manieren:

- Een presentatie ontsleutelen; een versleutelde presentatie openen
- Versleuteling verwijderen; wachtwoordbescherming uitschakelen
- Schrijfbescherming van een presentatie verwijderen
- De eigenschappen van een versleutelde presentatie opvragen
- Controleren of een presentatie wachtwoordbeveiligd is voordat deze wordt geladen
- Controleren of een presentatie versleuteld is
- Controleren of een presentatie wachtwoordbeveiligd is

## **Een presentatie met een wachtwoord beveiligen**

Je kunt een presentatie versleutelen door een wachtwoord in te stellen. Om vervolgens de vergrendelde presentatie te wijzigen, moet een gebruiker het wachtwoord invoeren.

Om een presentatie te versleutelen (of met een wachtwoord te beveiligen), gebruik je de `Encrypt`‑methode van [ProtectionManager](https://reference.aspose.com/slides/nl/net/aspose.slides/protectionmanager) om een wachtwoord in te stellen. Geef het wachtwoord door aan de `Encrypt`‑methode en gebruik vervolgens de `Save`‑methode om de nu versleutelde presentatie op te slaan.

Deze voorbeeldcode laat zien hoe je een presentatie kunt versleutelen:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```

## **Schrijfbescherming instellen op een presentatie** 

Je kunt een markering toevoegen met de tekst "Do not modify" aan een presentatie. Dit informeert gebruikers dat je niet wilt dat ze wijzigingen aanbrengen in de presentatie.

**Opmerking:** Het proces van schrijfbescherming versleutelt de presentatie niet. Daarom kunnen gebruikers—indien ze dat willen—de presentatie wijzigen, maar om de wijzigingen op te slaan moeten ze deze onder een andere naam bewaren.

Om schrijfbescherming in te stellen, gebruik je de `SetWriteProtection`‑methode. Deze voorbeeldcode laat zien hoe je schrijfbescherming kunt toepassen op een presentatie:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```

## **Een versleutelde presentatie laden**

Aspose.Slides maakt het mogelijk om een versleutelde presentatie te laden door het juiste wachtwoord te verstrekken. Deze voorbeeldcode laat zien hoe je een versleutelde presentatie kunt laden:

```c#
using Aspose.Slides;

LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    // Werk met de ontsleutelde presentatie.
}
```

## **Versleuteling van een presentatie verwijderen**

Je kunt versleuteling of wachtwoordbeveiliging van een presentatie verwijderen, zodat gebruikers er zonder beperkingen toegang toe hebben of deze kunnen wijzigen.

Om versleuteling of wachtwoordbeveiliging te verwijderen, roep je de [RemoveEncryption](https://reference.aspose.com/slides/nl/net/aspose.slides/protectionmanager/methods/removeencryption)‑methode aan. Deze voorbeeldcode laat zien hoe je de versleuteling van een presentatie kunt verwijderen:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```

## **Schrijfbescherming van een presentatie verwijderen**

Je kunt met Aspose.Slides de schrijfbescherming van een presentatiedossier verwijderen. Zo kunnen gebruikers deze naar eigen inzicht wijzigen — en krijgen ze geen waarschuwingen meer bij het uitvoeren van dergelijke handelingen.

Je kunt de schrijfbescherming verwijderen met de [RemoveWriteProtection](https://reference.aspose.com/slides/nl/net/aspose.slides/protectionmanager/methods/removewriteprotection)‑methode. Deze voorbeeldcode laat zien hoe je de schrijfbescherming van een presentatie kunt verwijderen:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```

## **Eigenschappen van een versleutelde presentatie ophalen**

Gewoonlijk hebben gebruikers moeite om de documenteigenschappen van een versleutelde of met een wachtwoord beveiligde presentatie op te halen. Aspose.Slides biedt echter een mechanisme waarmee je een presentatie kunt beveiligen met een wachtwoord en toch de mogelijkheid voor gebruikers behoudt om de eigenschappen te benaderen.

**Opmerking:** Standaard worden, wanneer Aspose.Slides een presentatie versleutelt, de documenteigenschappen van de presentatie ook met een wachtwoord beveiligd. Als je de documenteigenschappen zelfs na versleuteling toegankelijk wilt maken, biedt Aspose.Slides precies die mogelijkheid.

Als je wilt dat gebruikers de mogelijkheid behouden om de eigenschappen van een versleutelde presentatie te raadplegen, stel je de `EncryptDocumentProperties`‑eigenschap van [IProtectionManager](https://reference.aspose.com/slides/nl/net/aspose.slides/iprotectionmanager/) in op `false`. Deze voorbeeldcode laat zien hoe je een presentatie kunt versleutelen terwijl je gebruikers toch toegang geeft tot de documenteigenschappen:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.EncryptDocumentProperties = false;
presentation.ProtectionManager.Encrypt("123123");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **Alleen documenteigenschappen laden van een versleutelde presentatie**

Om de metadata van een versleutelde presentatie te inspecteren zonder de dia's of andere inhoud te laden, maak je een [LoadOptions](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/)‑object aan en stel je [OnlyLoadDocumentProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) in op `true`. In deze modus negeert Aspose.Slides het wachtwoord en laadt alleen de publiek toegankelijke documenteigenschappen.

De volgende codevoorbeelden lezen ingebouwde en aangepaste documenteigenschappen via [IPresentation.DocumentProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentation/documentproperties/):

```c#
using Aspose.Slides;

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

Deze werkwijze werkt alleen wanneer de documenteigenschappen onversleuteld (openbaar) zijn gelaten toen de presentatie werd versleuteld. Als de documenteigenschappen versleuteld zijn, leidt het instellen van `OnlyLoadDocumentProperties` op `true` tot een uitzondering omdat het wachtwoord in deze modus wordt genegeerd. Om versleutelde documenteigenschappen te benaderen of de volledige presentatie, inclusief dia's en andere inhoud, te laden, geef je de juiste `Password`‑waarde op in [LoadOptions](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/).

## **Controleren of een presentatie wachtwoordbeveiligd is**

Voordat je een presentatie laadt, wil je wellicht controleren of deze niet met een wachtwoord is beveiligd. Dit helpt je fouten en soortgelijke problemen te voorkomen die ontstaan wanneer een wachtwoordbeveiligde presentatie wordt geladen zonder het juiste wachtwoord.

Deze C#‑code laat zien hoe je een presentatie kunt onderzoeken om te zien of deze met een wachtwoord beveiligt is zonder deze daadwerkelijk te laden:

```c#
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("The presentation is password protected: " + presentationInfo.IsPasswordProtected);
```

## **Controleren of een presentatie versleuteld is**

Aspose.Slides maakt het mogelijk om te controleren of een presentatie versleuteld is. Hiervoor kun je de [IsEncrypted](https://reference.aspose.com/slides/nl/net/aspose.slides/protectionmanager/properties/isencrypted)‑eigenschap gebruiken, die `true` retourneert als de presentatie versleuteld is en `false` als dit niet het geval is.

Deze voorbeeldcode laat zien hoe je kunt controleren of een presentatie versleuteld is:

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```

## **Controleren of een presentatie schrijfbeschermd is**

Aspose.Slides maakt het mogelijk om te controleren of een presentatie schrijfbeschermd is. Hiervoor kun je de [IsWriteProtected](https://reference.aspose.com/slides/nl/net/aspose.slides/protectionmanager/properties/iswriteprotected)‑eigenschap gebruiken, die `true` retourneert als de presentatie schrijfbeschermd is en `false` als dit niet het geval is.

Deze voorbeeldcode laat zien hoe je kunt controleren of een presentatie schrijfbeschermd is:

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```

## **Controleren of een presentatiewachtwoord wordt gebruikt**

Je wilt mogelijk controleren en bevestigen dat een specifiek wachtwoord is gebruikt om een presentatiedocument te beveiligen. Aspose.Slides biedt de mogelijkheid om een wachtwoord te valideren.

Deze voorbeeldcode laat zien hoe je een wachtwoord kunt valideren:

```c#
using Aspose.Slides;

using (IPresentation presentation = new Presentation("pres.pptx"))
{
    // Controleer of het wachtwoord overeenkomt.
    bool isWriteProtected = presentation.ProtectionManager.CheckWriteProtection("my_password");
}
```

Het retourneert `true` als de presentatie is versleuteld met het opgegeven wachtwoord; anders retourneert het `false`.

{{% alert color="info" title="Zie ook" %}} 
- [Digitale handtekening in PowerPoint](/slides/nl/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Een presentatie online met een wachtwoord beveiligen**

1. Ga naar onze [**Aspose.Slides Lock**](https://products.aspose.app/slides/nl/lock) pagina. 
1. Klik op **Sleep of upload uw bestanden**.
1. Selecteer het bestand dat je wilt beveiligen met een wachtwoord op je computer. 
1. Voer je gewenste wachtwoord in voor bewerkingsbescherming en je gewenste wachtwoord voor weergavebescherming.
1. Als je wilt dat gebruikers je presentatie zien als de definitieve versie, vink dan het selectievakje **Mark as final** aan.
1. Klik op **PROTECT NOW.** 
1. Klik op **DOWNLOAD NOW.**

![Wachtwoordbeveiliging van PowerPoint-presentaties](slides-lock.png)

## **Veelgestelde vragen**

**Welke versleutelingsmethoden ondersteunt Aspose.Slides?**

Aspose.Slides ondersteunt moderne versleutelingsmethoden, waaronder AES‑gebaseerde algoritmen, waardoor een hoog beveiligingsniveau voor je presentaties wordt gegarandeerd.

**Wat gebeurt er als een onjuist wachtwoord wordt ingevoerd bij het proberen te openen van een presentatie?**

Er wordt een uitzondering gegooid wanneer een onjuist wachtwoord wordt gebruikt, waardoor je wordt gewaarschuwd dat de toegang tot de presentatie wordt geweigerd. Dit helpt ongeautoriseerde toegang te voorkomen en beschermt de inhoud van de presentatie.

**Zijn er prestatie‑implicaties bij het werken met wachtwoordbeveiligde presentaties?**

Het versleutelings‑ en ontsleutelingsproces kan een lichte overhead veroorzaken tijdens het openen en opslaan. In de meeste gevallen is deze prestatie‑impact minimaal en heeft het geen significante invloed op de totale verwerkingstijd van je presentatie‑taken.