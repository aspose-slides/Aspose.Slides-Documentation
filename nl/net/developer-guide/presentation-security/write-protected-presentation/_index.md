---
title: Schrijfbeveiligde presentaties in .NET
linktitle: Schrijfbeveiliging
type: docs
weight: 25
url: /nl/net/write-protected-presentation/
keywords:
- schrijfbeveiliging
- PowerPoint schrijfbeveiliging
- wachtwoord voor wijziging
- presentatie bewerken beperken
- schrijfbeveiliging verwijderen
- wijzigingswachtwoord valideren
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Instellen, detecteren, valideren en verwijderen van schrijfbeveiligingswachtwoorden in PowerPoint PPT- en PPTX-presentaties met Aspose.Slides voor .NET."
---
## **Inleiding**

Een wachtwoord voor schrijfbeveiliging beperkt de wijziging van een presentatie, maar versleutelt de inhoud niet. Gebruikers kunnen een schrijfbeveiligde presentatie laden en bekijken zonder het wachtwoord. Afhankelijk van de toepassing kunnen ze ook de inhoud bewerken en opslaan onder een andere naam, dus schrijfbeveiliging mag niet worden beschouwd als een vertrouwelijkheidsmechanisme.

Een openingswachtwoord dient een ander doel: het versleutelt de presentatie en is vereist om de inhoud te laden. Zie [Password-Protect Presentations](/slides/nl/net/password-protected-presentation/) om een presentatie te versleutelen of een openingswachtwoord te valideren.

De werkstromen in dit artikel zijn van toepassing op zowel PPT- als PPTX-presentaties. De voorbeelden gebruiken PPTX‑bestanden; bij het opslaan naar PPT gebruikt u de extensie `.ppt` en het overeenkomstige PPT‑opslaan‑formaat.

## **Schrijfbeveiliging instellen op een presentatie**

Gebruik [IProtectionManager.SetWriteProtection](https://reference.aspose.com/slides/nl/net/aspose.slides/iprotectionmanager/setwriteprotection/) om een wachtwoord toe te wijzen voor het wijzigen van een presentatie. Het opslaan van de presentatie zorgt ervoor dat de beveiligingsinstelling wordt bewaard.

Het volgende voorbeeld stelt schrijfbeveiliging in op een PPTX‑presentatie:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.SetWriteProtection("modify_password");
presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
```

## **Schrijfbeveiligde presentatie laden**

Omdat schrijfbeveiliging de presentatiewaarde niet versleutelt, is er geen wachtwoord nodig om de presentatie te laden. Het wachtwoord is alleen relevant bij het valideren van de autorisatie om de beveiligde presentatie te wijzigen.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("write-protected-pres.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

Geef geen schrijfbeveiligingswachtwoord door aan [LoadOptions.Password](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/password/). Deze eigenschap accepteert een openingswachtwoord voor versleutelde inhoud. Als een presentatie beide beveiligingstypen heeft, geeft u het openingswachtwoord door om deze te laden en behandelt u het schrijfbeveiligingswachtwoord apart.

## **Schrijfbeveiliging van een presentatie verwijderen**

Gebruik [IProtectionManager.RemoveWriteProtection](https://reference.aspose.com/slides/nl/net/aspose.slides/iprotectionmanager/removewriteprotection/) om de wijzigingsbeperking te verwijderen, en sla vervolgens de presentatie op.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("write-protected-pres.pptx");

presentation.ProtectionManager.RemoveWriteProtection();
presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
```

## **Controleren of een presentatie schrijfbeveiligd is**

Om een bestand te inspecteren zonder een volledige [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) instantie te maken, roept u [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentationfactory/getpresentationinfo/) aan en inspecteert u [IPresentationInfo.IsWriteProtected](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentationinfo/iswriteprotected/). De eigenschap maakt gebruik van [NullableBool](https://reference.aspose.com/slides/nl/net/aspose.slides/nullablebool/) en retourneert `NullableBool.True` wanneer schrijfbeveiliging wordt gedetecteerd.

```csharp
using System;
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.IsWriteProtected == NullableBool.True)
{
    Console.WriteLine("The presentation is write protected.");
}
else
{
    Console.WriteLine("Write protection was not detected.");
}
```

De stream‑overload van [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentationfactory/getpresentationinfo/) levert dezelfde informatie voor een presentatie die als stream wordt aangeleverd.

## **Een schrijfbeveiligingswachtwoord valideren**

Gebruik [IPresentationInfo.CheckWriteProtection](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentationinfo/checkwriteprotection/) om een wijzigingswachtwoord te valideren zonder de volledige presentatie te laden. Controleer eerst [IPresentationInfo.IsWriteProtected](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentationinfo/iswriteprotected/) zodat de applicatie alleen een wachtwoord vraagt of valideert wanneer schrijfbeveiliging aanwezig is.

```csharp
using System;
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.IsWriteProtected != NullableBool.True)
{
    Console.WriteLine("The presentation is not write protected.");
}
else if (presentationInfo.CheckWriteProtection("modify_password"))
{
    Console.WriteLine("The write-protection password is correct.");
}
else
{
    Console.WriteLine("The write-protection password is incorrect.");
}
```

[IPresentationInfo.CheckWriteProtection](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentationinfo/checkwriteprotection/) valideert alleen het schrijfbeveiligingswachtwoord. Het valideert geen openingswachtwoord en bepaalt niet of versleutelde inhoud kan worden geladen. Omgekeerd valideert [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentationinfo/checkpassword/) alleen een openingswachtwoord. Als een volledige presentatie al is geladen, biedt [IProtectionManager.CheckWriteProtection](https://reference.aspose.com/slides/nl/net/aspose.slides/iprotectionmanager/checkwriteprotection/) de equivalente schrijfbeveiligingscontrole via de beschermingmanager.

Log in productie‑applicaties geen wachtwoorden en voeg ze niet toe aan diagnostische berichten. Vermijd onnodige herhaalde validatiepogingen en bewaar wachtwoorden in het geheugen alleen zolang als nodig.

{{% alert color="info" title="Zie ook" %}}
- [Presentaties met wachtwoordbeveiliging](/slides/nl/net/password-protected-presentation/)
- [Alleen-lezen presentaties](/slides/nl/net/read-only-presentation/)
- [Digitale handtekening in PowerPoint](/slides/nl/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Versleutelt schrijfbeveiliging een presentatie?**

Nee. Het beperkt de wijziging, maar laat de presentatiewaarde beschikbaar voor laden en bekijken.

**Is het schrijfbeveiligingswachtwoord vereist om een presentatie te openen?**

Nee. Alleen een openingswachtwoord is vereist om versleutelde presentatiewaarde te laden.

**Kan een presentatie zowel een openingswachtwoord als een schrijfbeveiligingswachtwoord hebben?**

Ja. Geef het openingswachtwoord via de laadopties op om de versleutelde presentatie te openen, en valideer het schrijfbeveiligingswachtwoord afzonderlijk wanneer autorisatie voor wijziging vereist is.