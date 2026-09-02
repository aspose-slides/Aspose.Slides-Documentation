---
title: Digitale handtekeningen toevoegen aan presentaties in JavaScript
linktitle: Digitale handtekening
type: docs
weight: 10
url: /nl/nodejs-java/digital-signature-in-powerpoint/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer hoe u bestaande PPTX-presentaties kunt ondertekenen met PFX-certificaten en Aspose.Slides voor Node.js via Java kunt gebruiken om digitale handtekeningen te valideren of te verwijderen."
---
## **Overzicht**

Een digitale handtekening helpt een ontvanger te bepalen wie een presentatie heeft ondertekend en of de ondertekende inhoud is gewijzigd. Drie gerelateerde beveiligingsconcepten zijn hier van belang:

- Een **digitaal certificaat** is een elektronische referentie die een identiteit koppelt aan een publieke sleutel. Een vertrouwde certificaatautoriteit (CA) kan een certificaat uitgeven, of een organisatie kan een zelfondertekend certificaat gebruiken voor interne workflows.
- Een **digitale handtekening** wordt gemaakt op basis van de presentatiewerkzaamheden en de privésleutel van de certificaathouder. De publieke sleutel van het certificaat kan vervolgens worden gebruikt om de handtekening te verifiëren. Een handtekening biedt bewijs van herkomst en integriteit; het versleutelt de presentatie niet.
- **Wachtwoordbeveiliging** bepaalt of een gebruiker een presentatie kan openen of wijzigen. Het staat los van digitale ondertekening en wordt beschreven in [Wachtwoordbeveiligde presentaties](/nodejs-java/password-protected-presentation/).

PowerPoint biedt de opdracht **Add a Digital Signature** onder **File > Info > Protect Presentation**.

![PowerPoint-menu Protect Presentation met Add a Digital Signature gemarkeerd](add-digital-signature-in-powerpoint.png)

Nadat een ondertekende presentatie is geopend, kan PowerPoint een handtekeningstatusnotificatie weergeven.

![PowerPoint-notificatie die aangeeft dat de presentatie geldige handtekeningen bevat](digital-signature-status-in-powerpoint.png)

Aspose.Slides maakt handtekeningen beschikbaar via [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--), dat een [DigitalSignatureCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/digitalsignaturecollection/) retourneert met [DigitalSignature](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/digitalsignature/)‑objecten. Een presentatie kan meerdere handtekeningen bevatten.

## **Begrijp PFX‑certificaten en wachtwoorden**

Een PFX‑bestand, ook bekend als een PKCS#12‑bestand en meestal met de extensie `.pfx` of `.p12`, kan een X.509‑certificaat, de privésleutel en de certificaatketen bevatten. De privésleutel maakt het mogelijk voor de houder een handtekening te creëren. Een certificaat zonder toegankelijke privésleutel kan niet worden gebruikt om een presentatie te ondertekenen.

Het PFX‑wachtwoord beschermt het certificaatpakket en de privésleutel. Het is **geen** wachtwoord om de presentatie te openen of te bewerken. Commit geen PFX‑bestanden of hun wachtwoorden naar source control. In productie moet de toegang tot het certificaatbestand worden beperkt en moet het wachtwoord worden opgehaald uit een secret‑store of een andere beveiligde configuratiebron. De onderstaande voorbeelden gebruiken een omgevingsvariabele alleen om te voorkomen dat het wachtwoord in de code wordt ingebed.

## **Een digitale handtekening aan een presentatie toevoegen**

Om een echte presentatieworkflow te ondertekenen, laad een bestaand PPTX‑bestand, maak een [DigitalSignature](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/digitalsignature/) aan vanuit een PFX‑certificaat en het bijbehorende wachtwoord, voeg de handtekening toe aan de collectie van de presentatie en sla op als een PPTX‑bestand.

```javascript
const slides = require("aspose.slides.via.java");

const certificatePassword = process.env.PFX_PASSWORD;
if (!certificatePassword) {
    throw new Error("Set the PFX_PASSWORD environment variable.");
}

const presentation = new slides.Presentation("InputPresentation.pptx");
try {
    const signature = new slides.DigitalSignature("signing-certificate.pfx", certificatePassword);
    signature.setComments("Approved for release.");

    presentation.getDigitalSignatures().add(signature);
    presentation.save("InputPresentation-signed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat onder een andere naam opslaan behoudt het onondertekende bronbestand. De waarde die wordt ingesteld via [DigitalSignature.setComments](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/digitalsignature/) beschrijft het doel van de handtekening; het is geen beveiligingscontrole.

## **Digitale handtekeningen valideren**

Wanneer je een ondertekend PPTX‑bestand laadt, inspecteer je elk item dat wordt geretourneerd door [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--). De methode [DigitalSignature.isValid](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/digitalsignature/) geeft aan of de ingebedde handtekening geldig is voor de huidige presentatiewerkinhoud.

Het volgende voorbeeld maakt ook gebruik van de Node.js‑klasse `X509Certificate` om de subject‑naam van elk ingebed certificaat uit te lezen.

```javascript
const { X509Certificate } = require("node:crypto");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("InputPresentation-signed.pptx");
try {
    const signatures = presentation.getDigitalSignatures();
    const signatureCount = signatures.size();

    if (signatureCount === 0) {
        console.log("The presentation does not contain digital signatures.");
    } else {
        let allSignaturesAreValid = true;

        for (let index = 0; index < signatureCount; index++) {
            const signature = signatures.get_Item(index);
            const signatureIsValid = signature.isValid();
            const signatureStatus = signatureIsValid ? "VALID" : "INVALID";
            const signTime = signature.getSignTime().toString();

            const certificateData = signature.getCertificate();
            const certificate = new X509Certificate(Buffer.from(certificateData));
            const signerName = certificate.subject;

            console.log(`${signerName}, ${signTime} -- ${signatureStatus}`);

            allSignaturesAreValid = allSignaturesAreValid && signatureIsValid;
        }

        if (allSignaturesAreValid) {
            console.log("All embedded signatures are valid for the current presentation.");
        } else {
            console.log("At least one embedded signature is invalid.");
        }
    }
} finally {
    presentation.dispose();
}
```

Een ongeldig resultaat betekent meestal dat de ondertekende presentatiewerkinhoud of handtekeninggegevens zijn gewijzigd na ondertekening, of dat het bestand beschadigd is. Het verwijderen van alle handtekeningen levert een onondertekende presentatie op, dus alleen de geldigheid van items controleren is niet voldoende: een beveiligingsgevoelige workflow moet ook verifiëren dat het verwachte aantal handtekeningen en de verwachte ondertekenaars aanwezig zijn.

Dit geldigheidsresultaat mag niet worden beschouwd als een definitieve besluit over certificaatvertrouwen. Afhankelijk van je beveiligingsbeleid moet je applicatie mogelijk ook de X.509‑certificaatketen opbouwen en valideren, de geldigheidsdatums en intrekkingsstatus van het certificaat controleren, het verwachte subject of vingerafdruk bevestigen, het sleutelgebruik verifiëren en een vertrouwde tijdstempel evalueren. De waarde van [DigitalSignature.getSignTime](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/digitalsignature/) op zich is geen bewijs van een vertrouwde tijdstempel‑autoriteit.

## **Digitale handtekeningen verwijderen**

Het verwijderen van handtekeningen wijzigt de beveiligingsstatus van de presentatie. Het volgende voorbeeld laadt een ondertekend PPTX‑bestand, verwijdert alle handtekeningen met [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/digitalsignaturecollection/clear/), en slaat een onondertekende kopie op.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Om slechts één handtekening te verwijderen, roep je [DigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/) aan met de nulgebaseerde index. Sla op naar een nieuw bestand, tenzij het overschrijven van het ondertekende origineel een expliciet onderdeel van je workflow is.

## **Bewerkings‑ en formatoverwegingen**

- Een handtekening maakt een presentatie niet alleen‑lezen. Gebruikers en applicaties kunnen het bestand nog steeds bewerken, maar wijzigingen in de ondertekende inhoud maken doorgaans de bestaande handtekening ongeldig.
- Voltooi alle beoogde bewerkingen vóór ondertekening. Als een presentatie moet worden gewijzigd, sla de aangepaste presentatie op en onderteken die revisie opnieuw.
- Bewaar de uiteindelijke output in PPTX‑formaat. Het converteren van een ondertekende presentatie naar een ander formaat draagt de originele PPTX‑handtekening niet over als een geldige handtekening voor het geconverteerde bestand.
- Beschouw de privésleutel van het certificaat als gevoelig. Iedereen die de privésleutel en het wachtwoord verkrijgt, kan mogelijk handtekeningen maken die lijken te komen van die certificaathouder.
- Bewaar de onondertekende bron of een andere gecontroleerde kopie wanneer je document‑retentiebeleid dit vereist.

## **Veelgestelde vragen**

**Versleutelt een digitale handtekening de presentatie?**

Nee. Een digitale handtekening levert bewijs over oorsprong en integriteit, maar de presentatiewerkinhoud blijft leesbaar tenzij separaat versleuteld. Gebruik [wachtwoordbeveiliging](/nodejs-java/password-protected-presentation/) wanneer de toegang tot de inhoud moet worden beperkt.

**Is het PFX‑wachtwoord hetzelfde als een presentatiewachtwoord?**

Nee. Het PFX‑wachtwoord ontgrendelt de privésleutel die in het certificaatpakket is opgeslagen. Het bepaalt niet wie het PPTX‑bestand kan openen of bewerken.

**Kan ik een zelfondertekend certificaat gebruiken?**

Technisch kan een zelfondertekend certificaat worden gebruikt wanneer het een toegankelijke privésleutel bevat. Ontvangers zullen het echter niet automatisch vertrouwen, tenzij dat certificaat expliciet is toegevoegd aan hun vertrouwde omgeving. Publieke of cross‑organisatie workflows gebruiken doorgaans een certificaat dat is uitgegeven door een vertrouwde CA.

**Wat maakt een handtekening ongeldig?**

Het wijzigen van de ondertekende presentatiewerkinhoud of de handtekeninggegevens na ondertekening kan de handtekening ongeldig maken. Bestandsschade kan ook zorgen dat validatie faalt. Als alle handtekeningen worden verwijderd, is de presentatie onondertekend in plaats van een bestand dat een ongeldige handtekening bevat.

**Betekent een geldige handtekening dat ik de ondertekenaar moet vertrouwen?**

Niet op zichzelf. Handtekeningintegriteit en vertrouwen in de ondertekenaar zijn afzonderlijke beslissingen. Een productieve validatie‑policy moet ook de certificaatketen, geldigheidsperiode, intrekkingsstatus, verwachte identiteit, sleutelgebruik en eventuele vereisten voor een vertrouwde tijdstempel controleren.

**Wat gebeurt er wanneer het certificaat verloopt?**

Het verlopen van een certificaat verandert de bytes van de presentatie niet, maar beïnvloedt de evaluatie van certificaatvertrouwen. Of een handtekening acceptabel blijft, hangt af van je beleid en of een geldige vertrouwde tijdstempel aantoont dat de ondertekening heeft plaatsgevonden terwijl het certificaat geldig was. Vertrouw niet uitsluitend op de weergegeven ondertekeningstijd als een vertrouwde tijdstempel.

**Kan een ondertekende presentatie nog bewerkt worden?**

Ja. Ondertekenen vergrendelt het bestand niet. Het bewerken van ondertekende inhoud maakt over het algemeen de bestaande handtekening ongeldig, dus voltooi de presentatie eerst en onderteken de finale revisie.

**Kan een presentatie meer dan één handtekening bevatten?**

Ja. Voeg elke handtekening toe aan de collectie die wordt geretourneerd door [Presentation.getDigitalSignatures](/nodejs-java/password-protected-presentation/) voordat je opslaat. Tijdens validatie inspecteer je elke handtekening en bevestig je dat alle vereiste ondertekenaars aanwezig zijn.

**In welke presentatiesformaten worden deze bewerkingen ondersteund?**

Aspose.Slides ondersteunt de hier beschreven digitale‑handtekening‑bewerkingen alleen voor PPTX. PPT‑ en OpenDocument‑presentatieformaten worden niet ondersteund door deze API‑workflow.

**Kan ik een handtekening verwijderen zonder de dia’s te beïnvloeden?**

Ja. Je kunt één handtekening verwijderen of de hele collectie wissen en vervolgens de presentatie opslaan. De dia‑inhoud blijft beschikbaar, maar het opgeslagen bestand bevat niet langer het bewijs van de verwijderde handtekening.