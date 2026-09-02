---
title: Digitale handtekeningen toevoegen aan presentaties in .NET
linktitle: Digitale handtekening
type: docs
weight: 10
url: /nl/net/digital-signature-in-powerpoint/
keywords:
- digitale handtekening
- digitaal certificaat
- certificaatautoriteit
- PFX certificaat
- PKCS#12
- handtekening valideren
- PowerPoint
- PPTX
- presentatiebeveiliging
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u bestaande PPTX-presentaties kunt ondertekenen met PFX-certificaten en Aspose.Slides voor .NET kunt gebruiken om digitale handtekeningen te valideren of te verwijderen."
---
## **Overzicht**

Een digitale handtekening helpt de ontvanger te bepalen wie een presentatie heeft ondertekend en of de ondertekende inhoud is gewijzigd. Drie verwante beveiligingsconcepten zijn hier belangrijk:

- Een **digitaal certificaat** is een elektronische legitimatie die een identiteit koppelt aan een openbare sleutel. Een vertrouwde certificaatautoriteit (CA) kan een certificaat uitgeven, of een organisatie kan een zelfondertekend certificaat gebruiken voor interne workflows.
- Een **digitale handtekening** wordt gemaakt van de presentatie-inhoud en de privésleutel van de certificaathouder. De openbare sleutel van het certificaat kan vervolgens worden gebruikt om de handtekening te verifiëren. Een handtekening levert bewijs van oorsprong en integriteit; ze versleutelt de presentatie niet.
- **Wachtwoordbeveiliging** bepaalt of een gebruiker een presentatie kan openen of wijzigen. Het is los van digitale ondertekening en wordt beschreven in [Wachtwoordbeveiligde presentaties](/slides/nl/net/password-protected-presentation/).

PowerPoint biedt de opdracht **Add a Digital Signature** onder **File > Info > Protect Presentation**.

![PowerPoint‑menu ‘Protect Presentation’ met ‘Add a Digital Signature’ gemarkeerd](add-digital-signature-in-powerpoint.png)

Na het openen van een ondertekende presentatie kan PowerPoint een handtekeningstatus‑melding weergeven.

![PowerPoint‑melding die aangeeft dat de presentatie geldige handtekeningen bevat](digital-signature-status-in-powerpoint.png)

Aspose.Slides maakt handtekeningen toegankelijk via [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentation/digitalsignatures/), een [IDigitalSignatureCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/idigitalsignaturecollection/) waarvan de items [IDigitalSignature](https://reference.aspose.com/slides/nl/net/aspose.slides/idigitalsignature/) implementeren. Een presentatie kan meerdere handtekeningen bevatten.

## **Begrijp PFX‑certificaten en wachtwoorden**

Een PFX‑bestand, ook bekend als een PKCS#12‑bestand en meestal met de extensie `.pfx` of `.p12`, kan een X.509‑certificaat, de bijbehorende privésleutel en de certificaatketen bevatten. De privésleutel maakt het mogelijk voor de houder een handtekening te creëren. Een certificaat zonder toegankelijke privésleutel kan niet worden gebruikt om een presentatie te ondertekenen.

Het PFX‑wachtwoord beschermt het certificaatpakket en de privésleutel. Het is **geen** wachtwoord om de presentatie te openen of te bewerken. Plaats PFX‑bestanden of hun wachtwoorden niet in source control. In productie dient de toegang tot het certificaatbestand beperkt te worden en dient het wachtwoord uit een geheime opslag of een andere beveiligde configuratiebron te worden gehaald. De onderstaande voorbeelden gebruiken een omgevingsvariabele alleen om te voorkomen dat het wachtwoord in de code wordt ingebed.

## **Een digitale handtekening toevoegen aan een presentatie**

Om een echte presentatie‑workflow te ondertekenen, laad een bestaand PPTX‑bestand, maak een [DigitalSignature](https://reference.aspose.com/slides/nl/net/aspose.slides/digitalsignature/) aan vanuit een PFX‑certificaat en het bijbehorende wachtwoord, voeg de handtekening toe aan de collectie van de presentatie, en sla het op als een PPTX‑bestand.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

var certificatePassword = Environment.GetEnvironmentVariable("PFX_PASSWORD")
    ?? throw new InvalidOperationException("Set the PFX_PASSWORD environment variable.");

using var presentation = new Presentation("InputPresentation.pptx");

var signature = new DigitalSignature("signing-certificate.pfx", certificatePassword)
{
    Comments = "Approved for release."
};

presentation.DigitalSignatures.Add(signature);
presentation.Save("InputPresentation-signed.pptx", SaveFormat.Pptx);
```

Het opslaan van het resultaat onder een nieuwe naam behoudt het niet‑ondertekende bronbestand. De waarde van [DigitalSignature.Comments](https://reference.aspose.com/slides/nl/net/aspose.slides/digitalsignature/comments/) beschrijft het doel van de handtekening; het is geen beveiligingscontrole.

## **Digitale handtekeningen valideren**

Wanneer u een ondertekend PPTX‑bestand laadt, inspecteer elk item in [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentation/digitalsignatures/). De eigenschap [IDigitalSignature.IsValid](https://reference.aspose.com/slides/nl/net/aspose.slides/idigitalsignature/isvalid/) geeft aan of de ingebedde handtekening geldig is voor de huidige presentatie‑inhoud.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("InputPresentation-signed.pptx");

var signatureCount = presentation.DigitalSignatures.Count;

if (signatureCount == 0)
{
    Console.WriteLine("The presentation does not contain digital signatures.");
}
else
{
    var allSignaturesAreValid = true;

    foreach (var signature in presentation.DigitalSignatures)
    {
        var signatureStatus = signature.IsValid ? "VALID" : "INVALID";
        var signerName = signature.Certificate.SubjectName.Name;

        Console.WriteLine(
            $"{signerName}, {signature.SignTime:yyyy-MM-dd HH:mm:ss} -- {signatureStatus}");

        allSignaturesAreValid &= signature.IsValid;
    }

    Console.WriteLine(allSignaturesAreValid
        ? "All embedded signatures are valid for the current presentation."
        : "At least one embedded signature is invalid.");
}
```

Een ongeldig resultaat betekent meestal dat de ondertekende presentatietekst of handtekeninggegevens na ondertekening zijn gewijzigd, of dat het bestand beschadigd is. Het verwijderen van alle handtekeningen levert een niet‑ondertekende presentatie op, dus alleen de geldigheid van items controleren is niet voldoende: een beveiligingsgevoelige workflow moet ook verifiëren dat het verwachte aantal handtekeningen en de verwachte ondertekeners aanwezig zijn.

Dit geldigheidsresultaat mag niet worden beschouwd als een volledige beslissing over certificaatvertrouwen. Afhankelijk van uw beveiligingsbeleid moet uw applicatie mogelijk ook de X.509‑certificaatketen opbouwen en valideren, de geldigheidsdatums en de intrekkingsstatus van het certificaat controleren, het verwachte onderwerp of vingerafdruk bevestigen, het sleutelgebruik verifiëren en een vertrouwde tijdstempel evalueren. De waarde van [IDigitalSignature.SignTime](https://reference.aspose.com/slides/nl/net/aspose.slides/idigitalsignature/signtime/) alleen is geen bewijs van een vertrouwde tijdstempel‑autoriteit.

## **Digitale handtekeningen verwijderen**

Het verwijderen van handtekeningen wijzigt de beveiligingsstatus van de presentatie. Het volgende voorbeeld laadt een ondertekend PPTX‑bestand, verwijdert alle handtekeningen met [IDigitalSignatureCollection.Clear](https://reference.aspose.com/slides/nl/net/aspose.slides/idigitalsignaturecollection/clear/), en slaat een niet‑ondertekende kopie op.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("InputPresentation-signed.pptx");

presentation.DigitalSignatures.Clear();
presentation.Save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
```

Om slechts één handtekening te verwijderen, roep u [IDigitalSignatureCollection.RemoveAt](https://reference.aspose.com/slides/nl/net/aspose.slides/idigitalsignaturecollection/removeat/) aan met de nul‑gebaseerde index. Sla op in een nieuw bestand, tenzij het overschrijven van het ondertekende origineel een expliciet onderdeel van uw workflow is.

## **Bewerkings‑ en formaatoverwegingen**

- Een handtekening maakt een presentatie niet alleen‑lezen. Gebruikers en applicaties kunnen het bestand nog steeds bewerken, maar wijzigingen in ondertekende inhoud maken de bestaande handtekening normaal gesproken ongeldig.
- Voltooi alle beoogde bewerkingen vóór het ondertekenen. Als een presentatie moet worden gewijzigd, sla dan de herziene presentatie op en onderteken die revisie opnieuw.
- Houd de uiteindelijke output in PPTX‑formaat. Het converteren van een ondertekende presentatie naar een ander formaat draagt de oorspronkelijke PPTX‑handtekening niet over als een geldige handtekening voor het geconverteerde bestand.
- Beschouw de privésleutel van het certificaat als gevoelig. Iedereen die de privésleutel en het wachtwoord verkrijgt, kan mogelijk handtekeningen maken die lijken te komen van die certificaathouder.
- Bewaar de niet‑ondertekende bron of een andere gecontroleerde kopie wanneer uw document‑bewaringsbeleid dit vereist.

## **Veelgestelde vragen**

**Versleutelt een digitale handtekening de presentatie?**

Nee. Een digitale handtekening levert bewijs over oorsprong en integriteit, maar de presentatietekst blijft leesbaar tenzij afzonderlijke versleuteling wordt toegepast. Gebruik [wachtwoordbeveiliging](/slides/nl/net/password-protected-presentation/) wanneer de toegang tot de inhoud moet worden beperkt.

**Is het PFX‑wachtwoord hetzelfde als een presentatiewachtwoord?**

Nee. Het PFX‑wachtwoord ontgrendelt de privésleutel die in het certificaatpakket is opgeslagen. Het regelt niet wie het PPTX‑bestand kan openen of bewerken.

**Kan ik een zelfondertekend certificaat gebruiken?**

Technisch kan een zelfondertekend certificaat worden gebruikt wanneer het een toegankelijke privésleutel bevat. Ontvangers zullen het echter niet automatisch vertrouwen, tenzij dat certificaat expliciet is toegevoegd aan hun vertrouwde omgeving. Publieke of cross‑organisatieworkflows gebruiken doorgaans een certificaat dat is uitgegeven door een vertrouwde CA.

**Wat maakt een handtekening ongeldig?**

Het wijzigen van ondertekende presentatietekst of de handtekeninggegevens na ondertekening kan de handtekening ongeldig maken. Bestandscorruptie kan ook de validatie laten falen. Als alle handtekeningen worden verwijderd, is de presentatie niet ondertekend in plaats van een bestand dat een ongeldige handtekening bevat.

**Betekent een geldige handtekening dat ik de ondertekenaar moet vertrouwen?**

Niet op zichzelf. De integriteit van de handtekening en het vertrouwen in de ondertekenaar zijn afzonderlijke beslissingen. Een productie‑validatiebeleid moet ook de certificaatketen, geldigheidsperiode, intrekkingsstatus, verwachte identiteit, sleutelgebruik en eventuele vereisten voor een vertrouwde tijdstempel controleren.

**Wat gebeurt er wanneer het certificaat verloopt?**

Het verlopen van een certificaat verandert de bytes van de presentatie niet, maar heeft wel invloed op de beoordeling van certificaatvertrouwen. Of een handtekening acceptabel blijft, hangt af van uw beleid en of een geldige vertrouwde tijdstempel aantoont dat de ondertekening heeft plaatsgevonden terwijl het certificaat geldig was. Vertrouw niet alleen op de weergegeven ondertekeningstijd als een vertrouwde tijdstempel.

**Kan een ondertekende presentatie nog steeds worden bewerkt?**

Ja. Ondertekenen vergrendelt het bestand niet. Het bewerken van ondertekende inhoud maakt de bestaande handtekening meestal ongeldig, dus voltooi de presentatie eerst en onderteken de definitieve revisie.

**Kan een presentatie meer dan één handtekening bevatten?**

Ja. Voeg elke handtekening toe aan [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentation/digitalsignatures/) vóór het opslaan. Tijdens validatie inspecteert u elke handtekening en bevestigt u dat alle vereiste ondertekenaars aanwezig zijn.

**Welke presentatiestructuren ondersteunen deze bewerkingen?**

Aspose.Slides ondersteunt de hier beschreven digitale‑handtekeningbewerkingen alleen voor PPTX. PPT‑ en OpenDocument‑presentatieformaten worden niet ondersteund door deze API‑workflow.

**Kan ik een handtekening verwijderen zonder de dia's te beïnvloeden?**

Ja. U kunt één handtekening verwijderen of de volledige collectie wissen en vervolgens de presentatie opslaan. De inhoud van de dia's blijft beschikbaar, maar het opgeslagen bestand bevat niet langer het bewijs van de verwijderde handtekening.