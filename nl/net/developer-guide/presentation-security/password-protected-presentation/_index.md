---
title: Beveilig presentaties met wachtwoorden in .NET
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
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u moeiteloos PowerPoint- en OpenDocument-presentaties met wachtwoordbeveiliging kunt vergrendelen en ontgrendelen met Aspose.Slides voor .NET. Beveilig uw presentaties."
---
## **Inleiding**

Wanneer u een presentatie met een wachtwoord beveiligt, betekent dat dat u een wachtwoord instelt dat bepaalde beperkingen op de presentatie afdwingt. Om deze beperkingen te verwijderen, moet het wachtwoord worden ingevoerd. Een met een wachtwoord beschermde presentatie wordt beschouwd als een vergrendelde presentatie.

Meestal kunt u een wachtwoord instellen om deze beperkingen op een presentatie af te dwingen:

- **Wijziging**

Als u alleen bepaalde gebruikers uw presentatie wilt laten wijzigen, kunt u een wijzigingsbeperking instellen. Deze beperking voorkomt dat personen elementen in uw presentatie wijzigen, aanpassen of kopiëren tenzij ze het wachtwoord invoeren.  

Echter, zelfs zonder het wachtwoord kan een gebruiker uw document nog steeds openen en benaderen. In deze alleen‑lezen‑modus kan de gebruiker de inhoud bekijken — inclusief hyperlinks, animaties, effecten en andere elementen — in uw presentatie, maar hij kan geen items kopiëren of de presentatie opslaan.

- **Openen**

Als u alleen bepaalde gebruikers uw presentatie wilt laten openen, kunt u een openingsbeperking instellen. Deze beperking voorkomt dat mensen zelfs de inhoud van uw presentatie kunnen bekijken tenzij ze het wachtwoord invoeren.  

Technisch gezien voorkomt de openingsbeperking ook dat gebruikers uw presentaties wijzigen — als mensen een presentatie niet kunnen openen, kunnen ze deze niet wijzigen of er veranderingen in aanbrengen.

**Opmerking:** Wanneer u een presentatie met een wachtwoord beveiligt om openen te voorkomen, wordt het presentatiebestand versleuteld.

## **Wachtwoordbeveiliging in Aspose.Slides**

**Ondersteunde formaten**

Aspose.Slides ondersteunt wachtwoordbeveiliging, versleuteling en soortgelijke bewerkingen voor presentaties in de volgende formaten:

- PPTX and PPT – Microsoft PowerPoint Presentaties
- ODP – OpenDocument Presentaties
- OTP – OpenDocument Presentatie Sjablonen

**Ondersteunde bewerkingen**

Aspose.Slides maakt het mogelijk om wachtwoordbeveiliging te gebruiken op presentaties om wijzigingen te voorkomen op de volgende manieren:

- Een presentatie versleutelen
- Schrijfbescherming instellen op een presentatie

**Andere bewerkingen**

Aspose.Slides maakt het mogelijk om extra taken met betrekking tot wachtwoordbeveiliging en versleuteling uit te voeren op de volgende manieren:

- Een presentatie ontsleutelen; een versleutelde presentatie openen
- Versleuteling verwijderen; wachtwoordbeveiliging uitschakelen
- Schrijfbescherming van een presentatie verwijderen
- De eigenschappen van een versleutelde presentatie ophalen
- Controleren of een presentatie met een wachtwoord is beveiligd vóór het laden
- Controleren of een presentatie versleuteld is
- Controleren of een presentatie met een wachtwoord is beveiligd

## **Een presentatie met een wachtwoord beveiligen**

U kunt een presentatie versleutelen door een wachtwoord in te stellen. Om vervolgens de vergrendelde presentatie te wijzigen, moet een gebruiker het wachtwoord opgeven.

Om een presentatie te versleutelen (of met een wachtwoord te beveiligen), gebruikt u de `Encrypt`-methode van [ProtectionManager](https://reference.aspose.com/slides/nl/net/aspose.slides/protectionmanager) om een wachtwoord in te stellen. Geef het wachtwoord door aan de `Encrypt`-methode en gebruik vervolgens de `Save`-methode om de nu versleutelde presentatie op te slaan.

Deze voorbeeldcode laat zien hoe u een presentatie kunt versleutelen:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```

## **Schrijfbescherming instellen op een presentatie** 

U kunt een markering "Niet wijzigen" aan een presentatie toevoegen. Dit informeert gebruikers dat u niet wilt dat ze veranderingen aan de presentatie aanbrengen.

**Opmerking:** Het proces van schrijfbescherming versleutelt de presentatie niet. Daarom kunnen gebruikers — als ze willen — de presentatie wijzigen, maar om de wijzigingen op te slaan moeten ze deze onder een andere naam bewaren.

Om schrijfbescherming in te stellen, gebruikt u de `SetWriteProtection`-methode. Deze voorbeeldcode laat zien hoe u schrijfbescherming op een presentatie instelt:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```

## **Een versleutelde presentatie laden**

Aspose.Slides maakt het mogelijk om een versleutelde presentatie te laden door het juiste wachtwoord te geven. Deze voorbeeldcode laat zien hoe u een versleutelde presentatie kunt laden:

```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    // Werk met de ontsleutelde presentatie.
}
```

## **Versleuteling van een presentatie verwijderen**

U kunt versleuteling of wachtwoordbeveiliging van een presentatie verwijderen, waardoor gebruikers er zonder beperkingen toegang toe hebben of deze kunnen wijzigen.

Om versleuteling of wachtwoordbeveiliging te verwijderen, roept u de [RemoveEncryption](https://reference.aspose.com/slides/nl/net/aspose.slides/protectionmanager/methods/removeencryption)-methode aan. Deze voorbeeldcode laat zien hoe u versleuteling van een presentatie kunt verwijderen:

```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```

## **Schrijfbescherming van een presentatie verwijderen**

U kunt Aspose.Slides gebruiken om de schrijfbescherming van een presentatiedocument te verwijderen. Op deze manier kunnen gebruikers het naar wens wijzigen — en ze ontvangen geen waarschuwingen bij het uitvoeren van dergelijke handelingen.

U kunt de schrijfbescherming verwijderen met de [RemoveWriteProtection](https://reference.aspose.com/slides/nl/net/aspose.slides/protectionmanager/methods/removewriteprotection)-methode. Deze voorbeeldcode laat zien hoe u de schrijfbescherming van een presentatie verwijdert:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```

## **Eigenschappen van een versleutelde presentatie ophalen**

Meestal hebben gebruikers moeite om de documenteigenschappen van een versleutelde of met een wachtwoord beveiligde presentatie op te halen. Aspose.Slides biedt echter een mechanisme waarmee u een presentatie met een wachtwoord kunt beveiligen en toch de mogelijkheid behoudt dat gebruikers de eigenschappen kunnen benaderen.

**Opmerking:** Standaard, wanneer Aspose.Slides een presentatie versleutelt, zijn de documenteigenschappen van de presentatie ook met een wachtwoord beveiligd. Als u de documenteigenschappen toegankelijk wilt maken, zelfs na versleuteling, biedt Aspose.Slides u precies die mogelijkheid.

Als u wilt dat gebruikers de mogelijkheid behouden om de eigenschappen van een versleutelde presentatie te benaderen, kunt u de [EncryptDocumentProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/protectionmanager/properties/encryptdocumentproperties)-eigenschap op `true` zetten. Deze voorbeeldcode laat zien hoe u een presentatie kunt versleutelen en toch gebruikers toegang geeft tot de documenteigenschappen:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.EncryptDocumentProperties = true;
    presentation.ProtectionManager.Encrypt("123123");
}
```

## **Controleren of een presentatie met een wachtwoord is beveiligd**

Voordat u een presentatie laadt, wilt u wellicht controleren of deze niet met een wachtwoord is beveiligd. Dit helpt fouten en soortgelijke problemen te voorkomen die ontstaan wanneer een met een wachtwoord beveiligde presentatie wordt geladen zonder het juiste wachtwoord.

Deze C#-code laat zien hoe u een presentatie kunt onderzoeken om te zien of deze met een wachtwoord is beveiligd zonder deze daadwerkelijk te laden:

```c#
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("The presentation is password protected: " + presentationInfo.IsPasswordProtected);
```

## **Controleren of een presentatie versleuteld is**

Aspose.Slides maakt het mogelijk om te controleren of een presentatie versleuteld is. Hiervoor kunt u de [IsEncrypted](https://reference.aspose.com/slides/nl/net/aspose.slides/protectionmanager/properties/isencrypted)-eigenschap gebruiken, die `true` teruggeeft als de presentatie versleuteld is of `false` als dat niet het geval is.

Deze voorbeeldcode laat zien hoe u kunt controleren of een presentatie versleuteld is:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```

## **Controleren of een presentatie schrijfbeschermd is**

Aspose.Slides maakt het mogelijk om te controleren of een presentatie schrijfbeschermd is. Hiervoor kunt u de [IsWriteProtected](https://reference.aspose.com/slides/nl/net/aspose.slides/protectionmanager/properties/iswriteprotected)-eigenschap gebruiken, die `true` teruggeeft als de presentatie schrijfbeschermd is of `false` als dat niet het geval is.

Deze voorbeeldcode laat zien hoe u kunt controleren of een presentatie schrijfbeschermd is:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```

## **Controleren of een presentatiewachtwoord is gebruikt**

U wilt misschien controleren en bevestigen dat een specifiek wachtwoord is gebruikt om een presentatiedocument te beveiligen. Aspose.Slides biedt de mogelijkheid om een wachtwoord te valideren.

Deze voorbeeldcode laat zien hoe u een wachtwoord kunt valideren:

```c#
using (IPresentation presentation = new Presentation("pres.pptx"))
{
    // Controleer of het wachtwoord overeenkomt.
    bool isWriteProtected = presentation.ProtectionManager.CheckWriteProtection("my_password");
}
```

Het geeft `true` terug als de presentatie is versleuteld met het opgegeven wachtwoord; anders geeft het `false` terug.

{{% alert color="primary" title="Zie ook" %}} 
- [Digital Signature in PowerPoint](/slides/nl/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Presentatie online met wachtwoord beveiligen**

1. Ga naar onze [**Aspose.Slides Lock**](https://products.aspose.app/slides/nl/lock) pagina.  
1. Klik op **Sleep of upload uw bestanden**.  
1. Selecteer het bestand dat u wilt beveiligen met een wachtwoord op uw computer.  
1. Voer uw gewenste wachtwoord in voor bewerkingsbeveiliging en uw gewenste wachtwoord voor weergavebeveiliging.  
1. Als u wilt dat gebruikers uw presentatie zien als de definitieve versie, vink dan het selectievakje **Mark as final** aan.  
1. Klik op **PROTECT NOW.**  
1. Klik op **DOWNLOAD NOW.**

![Password protect PowerPoint presentations](slides-lock.png)

## **FAQ**

**Welke encryptiemethoden ondersteunt Aspose.Slides?**

Aspose.Slides ondersteunt moderne encryptiemethoden, waaronder AES‑gebaseerde algoritmen, wat een hoog niveau van databeveiliging voor uw presentaties garandeert.

**Wat gebeurt er als een onjuist wachtwoord wordt ingevoerd bij het proberen een presentatie te openen?**

Er wordt een uitzondering gegenereerd als een onjuist wachtwoord wordt gebruikt, waardoor u wordt gewaarschuwd dat de toegang tot de presentatie is geweigerd. Dit helpt onbevoegde toegang te voorkomen en beschermt de inhoud van de presentatie.

**Zijn er prestatiegevolgen bij het werken met met een wachtwoord beveiligde presentaties?**

Het versleutel‑ en ontsleutelproces kan een kleine overhead introduceren tijdens open‑ en opslaanacties. In de meeste gevallen is deze prestatie‑impact minimaal en heeft het geen significante invloed op de algehele verwerkingstijd van uw presentatie‑taken.