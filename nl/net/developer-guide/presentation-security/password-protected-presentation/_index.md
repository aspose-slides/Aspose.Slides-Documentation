---
title: Wachtwoordbeveiliging van presentaties in .NET
linktitle: Wachtwoordbeveiliging
type: docs
weight: 20
url: /nl/net/password-protected-presentation/
keywords:
- wachtwoordbeveiligde presentatie
- openingswachtwoord
- PowerPoint versleutelen
- PowerPoint ontsleutelen
- presentatiewachtwoord valideren
- presentatiewachtwoord controleren
- versleutelde presentatie openen
- versleuteling verwijderen
- PowerPoint
- PPT
- PPTX
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Versleutel, detecteer, valideer, open en ontsleutel wachtwoordbeveiligde PowerPoint PPT- en PPTX‑presentaties in C# met Aspose.Slides voor .NET."
---
## **Overzicht**

Een openingswachtwoord versleutelt een presentatie. Het juiste wachtwoord is vereist om de presentatie‑inhoud te laden en te bekijken, dus deze bescherming biedt vertrouwelijkheid.

Een openingswachtwoord verschilt van een schrijfbeschermingswachtwoord. Schrijfbeveiliging beperkt wijzigen, maar versleutelt de inhoud niet en voorkomt niet dat de presentatie wordt geladen. Om wachtwoorden voor het wijzigen van presentaties te beheren, zie [Write-Protect Presentations](/slides/nl/net/write-protected-presentation/).

De onderstaande workflows zijn van toepassing op zowel PPT- als PPTX‑presentaties. De voorbeelden gebruiken beide formaten wanneer hun bestandsgebaseerde en streamgebaseerde gedrag belangrijk is.

## **Een presentatie versleutelen met een openingswachtwoord**

Gebruik [IProtectionManager.Encrypt](https://reference.aspose.com/slides/nl/net/aspose.slides/iprotectionmanager/encrypt/) om een openingswachtwoord toe te wijzen. Gebruik vervolgens [IPresentation.Save](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentation/save/) om de versleutelde presentatie op te slaan.

Het volgende voorbeeld versleutelt een PPTX‑presentatie:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **Documenteigenschappen openbaar houden**

Standaard omvat Aspose.Slides documenteigenschappen in de versleuteling van de presentatie. De eigenschap [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) regelt dit gedrag onafhankelijk van de versleuteling van de dia‑inhoud. Stel deze in op `false` voordat [IProtectionManager.Encrypt](https://reference.aspose.com/slides/nl/net/aspose.slides/iprotectionmanager/encrypt/) wordt aangeroepen wanneer een indexerings-, classificatie-, zoek‑ of documentbeheer‑systeem metadata moet lezen zonder het openingswachtwoord.

Het volgende voorbeeld maakt een versleutelde PPTX‑presentatie terwijl de ingebouwde documenteigenschappen openbaar blijven:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var properties = presentation.DocumentProperties;
properties.Author = "Contoso Knowledge Management";
properties.Title = "Quarterly Product Roadmap";
properties.Keywords = "roadmap, planning, internal";

presentation.Slides[0].Name = "Encrypted presentation content";
presentation.ProtectionManager.EncryptDocumentProperties = false;
presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("public-properties-encrypted.pptx", SaveFormat.Pptx);
```

Het instellen van `EncryptDocumentProperties` op `false` maakt de dia's, masters, lay‑outs, vormen, media of andere presentatie‑inhoud niet openbaar. Het beïnvloedt alleen de documenteigenschappen. Zie [Manage Presentation Properties](/slides/nl/net/presentation-properties/) om die eigenschappen te lezen zonder de versleutelde inhoud te laden.

## **Een versleutelde presentatie laden**

Stel [LoadOptions.Password](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/password/) in op het openingswachtwoord en geef de opties door aan [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) bij het laden van het bestand. Het laden mislukt wanneer een openingswachtwoord vereist is maar het opgegeven wachtwoord ontbreekt of onjuist is.

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

// Werk met de ontsleutelde presentatie.
```

## **Versleuteling van een presentatie verwijderen**

Laad de presentatie met het openingswachtwoord, roep [IProtectionManager.RemoveEncryption](https://reference.aspose.com/slides/nl/net/aspose.slides/iprotectionmanager/removeencryption/) aan en sla het resultaat op. De opgeslagen presentatie kan daarna zonder wachtwoord geladen worden.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

presentation.ProtectionManager.RemoveEncryption();
presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
```

## **Een openingswachtwoord valideren voordat het wordt geladen**

Gebruik [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentationfactory/getpresentationinfo/) om [IPresentationInfo](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentationinfo/) te verkrijgen zonder een volledige presentatie‑instantie te maken. Controleer [IPresentationInfo.IsPasswordProtected](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentationinfo/ispasswordprotected/) voordat u een wachtwoord opvraagt of valideert. Wanneer bescherming aanwezig is, valideer dan de opgegeven waarde met [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentationinfo/checkpassword/).

### **Werkstroom via bestands‑pad**

Het volgende voorbeeld valideert een openingswachtwoord voor een PPTX‑bestand, geeft de gevalideerde waarde door aan [LoadOptions.Password](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/password/), en laadt vervolgens de volledige presentatie:

```csharp
using System;
using Aspose.Slides;

var filePath = "protected-presentation.pptx";
var password = "open_password";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(filePath);

if (!presentationInfo.IsPasswordProtected)
{
    Console.WriteLine("The presentation does not have an opening password.");
}
else if (!presentationInfo.CheckPassword(password))
{
    Console.WriteLine("The opening password is incorrect.");
}
else
{
    var loadOptions = new LoadOptions { Password = password };
    using var presentation = new Presentation(filePath, loadOptions);

    Console.WriteLine("The presentation was validated and loaded successfully.");
}
```

### **Werkstroom via stream**

De stream‑overload van [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentationfactory/getpresentationinfo/) biedt dezelfde werkstroom. Reset de positie van een doorzoekbare stream voordat u de volledige presentatie uit die stream laadt.

Het volgende voorbeeld gebruikt een PPT‑bestand:

```csharp
using System;
using System.IO;
using Aspose.Slides;

var password = "open_password";
using var presentationStream = File.OpenRead("protected-presentation.ppt");
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(presentationStream);

if (!presentationInfo.IsPasswordProtected)
{
    Console.WriteLine("The presentation does not have an opening password.");
}
else if (!presentationInfo.CheckPassword(password))
{
    Console.WriteLine("The opening password is incorrect.");
}
else
{
    presentationStream.Position = 0;

    var loadOptions = new LoadOptions { Password = password };
    using var presentation = new Presentation(presentationStream, loadOptions);

    Console.WriteLine("The presentation was validated and loaded successfully.");
}
```

### **Teruggeefwaarden van CheckPassword**

[IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentationinfo/checkpassword/) geeft `true` alleen terug wanneer de presentatie een openingswachtwoord heeft en het opgegeven wachtwoord correct is. Het geeft `false` terug in elk van de volgende gevallen:

- Het wachtwoord is onjuist.
- De presentatie heeft geen openingswachtwoord.
- Het opgegeven wachtwoord is `null` of leeg.

Het gedrag is hetzelfde voor PPT‑ en PPTX‑presentaties.

## **Controleren of een geladen presentatie versleuteld is**

Nadat u een presentatie met het juiste wachtwoord hebt geladen, inspecteer [IProtectionManager.IsEncrypted](https://reference.aspose.com/slides/nl/net/aspose.slides/iprotectionmanager/isencrypted/) om te bevestigen dat de bronpresentatie versleuteld was. Om openings‑wachtwoordbescherming te detecteren vóór het laden, gebruik `IPresentationInfo.IsPasswordProtected` zoals hierboven weergegeven.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

var isEncrypted = presentation.ProtectionManager.IsEncrypted;
Console.WriteLine("The presentation is encrypted: " + isEncrypted);
```

## **Beveiligingsaanbevelingen**

{{% alert color="warning" title="Beveiliging" %}}
Log geen openingswachtwoorden en neem ze niet op in diagnostische berichten. Vermijd onnodige herhaalde validatie‑pogingen, bewaar wachtwoorden in het geheugen alleen zolang als nodig, en hergebruik een geslaagde validatie wanneer u de presentatie onmiddellijk laadt.

Openbare documenteigenschappen kunnen auteursnamen, titels, onderwerps, trefwoorden, bedrijfsinformatie, commentaren en aangepaste waarden onthullen, zelfs wanneer de presentatie‑inhoud versleuteld is. Versleutel gevoelige metadata samen met de presentatie. Het openbaar houden van eigenschappen moet een expliciete beslissing zijn, alleen genomen wanneer systemen het bestand moeten indexeren, classificeren, doorzoeken of beheren zonder een openingswachtwoord.
{{% /alert %}}

## **Een presentatie online met wachtwoord beveiligen**

1. Open de [Aspose.Slides Lock](https://products.aspose.app/slides/nl/lock) applicatie.
1. Selecteer of upload de presentatie.
1. Voer een wachtwoord in voor weergave‑bescherming.
1. Voer eventueel een apart wachtwoord in voor bewerkings‑bescherming.
1. Pas de bescherming toe en download het resulterende bestand.

{{% alert color="info" title="Zie ook" %}}
- [Write-Protect Presentations](/slides/nl/net/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/nl/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Wat is het verschil tussen een openingswachtwoord en een schrijfbeveiligingswachtwoord?**

Een openingswachtwoord versleutelt de presentatie en is vereist om de inhoud te laden. Een schrijfbeveiligingswachtwoord beperkt wijzigen zonder de inhoud te versleutelen.

**Kan ik een openingswachtwoord valideren zonder alle dia's te laden?**

Ja. Verkrijg presentatie‑informatie, controleer of er een openings‑wachtwoordbescherming aanwezig is, en valideer het wachtwoord voordat u een volledige presentatie‑instantie maakt.

**Kan een applicatie metadata lezen zonder het openingswachtwoord?**

Ja, maar alleen wanneer de presentatie is versleuteld met `EncryptDocumentProperties` ingesteld op `false`. De applicatie moet dan de alleen‑documenteigenschappen‑laadmodus gebruiken die wordt beschreven in [Manage Presentation Properties](/slides/nl/net/presentation-properties/).

**Ondersteunen de wachtwoord‑controles workflows zowel PPT als PPTX?**

Ja. Wachtwoorddetectie en -validatie via bestands‑pad en stream werken hetzelfde voor PPT‑ en PPTX‑presentaties.