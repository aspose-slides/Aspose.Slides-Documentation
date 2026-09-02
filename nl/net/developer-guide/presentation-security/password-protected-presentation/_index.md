---
title: Presentaties beveiligen met een wachtwoord in .NET
linktitle: Wachtwoordbeveiliging
type: docs
weight: 20
url: /nl/net/password-protected-presentation/
keywords:
- wachtwoordbeveiligde presentatie
- openingswachtwoord
- PowerPoint versleutelen
- PowerPoint ontsleutelen
- presentatie wachtwoord valideren
- presentatie wachtwoord controleren
- versleutelde presentatie openen
- versleuteling verwijderen
- PowerPoint
- PPT
- PPTX
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Versleutel, detecteer, valideer, open en ontsleutel wachtwoordbeveiligde PowerPoint PPT- en PPTX-presentaties in C# met Aspose.Slides voor .NET."
---
## **Overzicht**

Een openingswachtwoord versleutelt een presentatie. Het juiste wachtwoord is vereist om de presentatie‑inhoud te laden en te bekijken, waardoor deze bescherming vertrouwelijkheid biedt.

Een openingswachtwoord verschilt van een schrijfbeschermingswachtwoord. Schrijfbescherming beperkt bewerking, maar versleutelt de inhoud niet en voorkomt niet dat de presentatie wordt geladen. Zie voor het beheren van wachtwoorden om presentaties te wijzigen [Write-Protect Presentations](/slides/nl/net/write-protected-presentation/).

De onderstaande werkwijzen gelden voor zowel PPT‑ als PPTX‑presentaties. De voorbeelden gebruiken beide formaten wanneer hun bestands‑ en stream‑gedrag van belang is.

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

## **Een versleutelde presentatie laden**

Stel [LoadOptions.Password](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/password/) in op het openingswachtwoord en geef de opties door aan [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) bij het laden van het bestand. Het laden mislukt wanneer een openingswachtwoord vereist is maar het opgegeven wachtwoord ontbreekt of onjuist is.

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

// Werk met de ontsleutelde presentatie.
```

## **Versleuteling van een presentatie verwijderen**

Laad de presentatie met zijn openingswachtwoord, roep [IProtectionManager.RemoveEncryption](https://reference.aspose.com/slides/nl/net/aspose.slides/iprotectionmanager/removeencryption/) aan en sla het resultaat op. De opgeslagen presentatie kan vervolgens zonder wachtwoord geladen worden.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

presentation.ProtectionManager.RemoveEncryption();
presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
```

## **Een openingswachtwoord valideren vóór het laden**

Gebruik [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentationfactory/getpresentationinfo/) om [IPresentationInfo](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentationinfo/) te verkrijgen zonder een volledig presentatie‑object te maken. Controleer [IPresentationInfo.IsPasswordProtected](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentationinfo/ispasswordprotected/) voordat je een wachtwoord vraagt of valideert. Wanneer bescherming aanwezig is, valideer dan de opgegeven waarde met [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentationinfo/checkpassword/).

### **Bestandspad‑workflow**

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

### **Stream‑workflow**

De stream‑overbelasting van [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentationfactory/getpresentationinfo/) biedt dezelfde werkwijze. Zet de positie van een seek‑bare stream terug voordat je de volledige presentatie vanuit die stream laadt.

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

[IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentationinfo/checkpassword/) retourneert `true` alleen wanneer de presentatie een openingswachtwoord heeft en het opgegeven wachtwoord correct is. Het retourneert `false` in elk van deze gevallen:

- Het wachtwoord is onjuist.
- De presentatie heeft geen openingswachtwoord.
- Het opgegeven wachtwoord is `null` of leeg.

Het gedrag is hetzelfde voor PPT‑ en PPTX‑presentaties.

## **Controleren of een geladen presentatie versleuteld is**

Na het laden van een presentatie met het juiste wachtwoord, inspecteer [IProtectionManager.IsEncrypted](https://reference.aspose.com/slides/nl/net/aspose.slides/iprotectionmanager/isencrypted/) om te bevestigen dat de bronpresentatie versleuteld was. Om bescherming met een openingswachtwoord vóór het laden te detecteren, gebruik `IPresentationInfo.IsPasswordProtected` zoals hierboven getoond.

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
Log geen openingswachtwoorden en voeg ze niet op in diagnostische berichten. Vermijd onnodige herhaalde validatie‑pogingen, houd wachtwoorden alleen in het geheugen zolang ze nodig zijn, en hergebruik een succesvolle validatieresultaat bij het onmiddellijk laden van de presentatie.
{{% /alert %}}

## **Een presentatie online met een wachtwoord beveiligen**

1. Open de applicatie [Aspose.Slides Lock](https://products.aspose.app/slides/nl/lock).
1. Selecteer of upload de presentatie.
1. Voer een wachtwoord in voor weergavebescherming.
1. Optioneel een apart wachtwoord invoeren voor bewerkingsbescherming.
1. Pas de bescherming toe en download het resulterende bestand.

{{% alert color="info" title="Zie ook" %}}
- [Write-Protect Presentations](/slides/nl/net/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/nl/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Wat is het verschil tussen een openingswachtwoord en een schrijfbeschermingswachtwoord?**

Een openingswachtwoord versleutelt de presentatie en is vereist om de inhoud te laden. Een schrijfbeschermingswachtwoord beperkt bewerking zonder de inhoud te versleutelen.

**Kan ik een openingswachtwoord valideren zonder alle dia’s te laden?**

Ja. Verkrijg presentatiesinformatie, controleer of bescherming met een openingswachtwoord aanwezig is, en valideer het wachtwoord voordat je een volledig presentatie‑object maakt.

**Ondersteunen de wachtwoord‑validatiewerkwijzen zowel PPT als PPTX?**

Ja. Het detecteren en valideren van wachtwoorden via bestandspad‑ en stream‑gebaseerde methoden werkt hetzelfde voor PPT‑ en PPTX‑presentaties.