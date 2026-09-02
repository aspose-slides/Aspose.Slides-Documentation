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
- beveiliging van presentaties
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer hoe u bestaande PPTX-presentaties kunt ondertekenen met PFX-certificaten en Aspose.Slides voor Node.js via Java kunt gebruiken om digitale handtekeningen te valideren of te verwijderen."
---
## **Overzicht**

Een digitale handtekening helpt een ontvanger bepalen wie een presentatie heeft ondertekend en of de ondertekende inhoud is veranderd. Drie gerelateerde beveiligingsconcepten zijn hier belangrijk:

- Een **digitaal certificaat** is een elektronisch bewijs dat een identiteit koppelt aan een publieke sleutel. Een vertrouwde certificaatautoriteit (CA) kan een certificaat uitgeven, of een organisatie kan een zelfondertekend certificaat gebruiken voor interne workflows.
- Een **digitale handtekening** wordt gemaakt vanuit de presentatie‑inhoud en de privésleutel van de certificaathouder. De publieke sleutel van het certificaat kan vervolgens worden gebruikt om de handtekening te verifiëren. Een handtekening levert bewijs van oorsprong en integriteit; hij versleutelt de presentatie niet.
- **Wachtwoordbeveiliging** bepaalt of een gebruiker een presentatie kan openen of wijzigen. Dit staat los van digitale ondertekening en wordt beschreven in [Presentaties met wachtwoordbeveiliging](/slides/nl/nodejs-java/password-protected-presentation/).

PowerPoint biedt de opdracht **Add a Digital Signature** onder **File > Info > Protect Presentation**.

![PowerPoint Protect Presentation menu with Add a Digital Signature highlighted](add-digital-signature-in-powerpoint.png)

Nadat een ondertekende presentatie is geopend, kan PowerPoint een handtekening‑statusmelding tonen.

![PowerPoint notification stating that the presentation contains valid signatures](digital-signature-status-in-powerpoint.png)

Aspose.Slides maakt handtekeningen beschikbaar via [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--), die een [DigitalSignatureCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/digitalsignaturecollection/) retourneert met [DigitalSignature](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/digitalsignature/)‑objecten. Een presentatie kan meerdere handtekeningen bevatten.

## **Begrijp PFX‑certificaten en wachtwoorden**

Een PFX‑bestand, ook bekend als een PKCS#12‑bestand en meestal met de extensie `.pfx` of `.p12`, kan een X.509‑certificaat, de privésleutel en de certificaatketen bevatten. De privésleutel maakt het mogelijk voor de houder om een handtekening te creëren. Een certificaat zonder toegankelijke privésleutel kan niet worden gebruikt om een presentatie te ondertekenen.

Het PFX‑wachtwoord beschermt het certificaat‑pakket en de privésleutel. Het is **geen** wachtwoord om de presentatie te openen of te bewerken. Commit geen PFX‑bestanden of hun wachtwoorden naar broncodebeheer. In productie moet de toegang tot het certificaatbestand beperkt worden en moet het wachtwoord worden opgehaald uit een geheimen‑opslag of een andere beveiligde configuratiebron. De onderstaande voorbeelden gebruiken een omgevingsvariabele alleen om te vermijden dat het wachtwoord in de code wordt ingebed.

## **Een digitale handtekening aan een presentatie toevoegen**

Om een echte ondertekenings‑workflow te demonstreren, laad je een bestaand PPTX‑bestand, maak je een [DigitalSignature](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/digitalsignature/) aan vanuit een PFX‑certificaat en het wachtwoord, voeg je de handtekening toe aan de collectie van de presentatie, en sla je op naar een PPTX‑bestand.

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

Het resultaat onder een nieuwe naam opslaan behoudt het ongeondertekende bronbestand. De waarde die wordt ingesteld met [DigitalSignature.setComments](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/digitalsignature/) beschrijft het doel van de handtekening; het is geen beveiligings‑controle.

## **Digitale handtekeningen valideren**

Wanneer je een ondertekend PPTX‑bestand laadt, inspecteer je elk item dat wordt geretourneerd door [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--). De methode [DigitalSignature.isValid](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/digitalsignature/) geeft aan of de ingesloten handtekening geldig is voor de huidige presentatie‑inhoud.

Het volgende voorbeeld gebruikt ook de Node.js‑klasse `X509Certificate` om de subject‑naam uit elk ingebed certificaat te lezen.

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

Een ongeldige uitkomst betekent meestal dat de ondertekende presentatiewijziging of handtekeningsdata na ondertekening is aangepast, of dat het bestand beschadigd is. Het verwijderen van alle handtekeningen levert een ongeondertekende presentatie op, dus alleen de geldigheid van items controleren is niet genoeg: een beveiligingsgevoelige workflow moet ook verifiëren dat het verwachte aantal handtekeningen en de verwachte ondertekenaars aanwezig zijn.

Dit geldigheidsresultaat moet niet worden gezien als een definitieve certificaat‑vertrouwensbeslissing. Afhankelijk van je beveiligingsbeleid moet je mogelijk ook de X.509‑certificaatketen bouwen en valideren, de geldigheidsdatums en intrekkingsstatus van het certificaat controleren, het verwachte subject of vingerafdruk bevestigen, het sleutelgebruik verifiëren, en een vertrouwde timestamp evalueren. De waarde van [DigitalSignature.getSignTime](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/digitalsignature/) op zichzelf is geen bewijs van een vertrouwde tijdstempelautoriteit.

## **Digitale handtekeningen verwijderen**

Het verwijderen van handtekeningen verandert de beveiligingsstatus van de presentatie. Het volgende voorbeeld laadt een ondertekend PPTX‑bestand, verwijdert alle handtekeningen met [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/digitalsignaturecollection/clear/), en slaat een ongeondertekende kopie op.

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

Om slechts één handtekening te verwijderen, roep je [DigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/) aan met de nul‑gebaseerde index. Sla op naar een nieuw bestand tenzij het overschrijven van het ondertekende origineel expliciet deel van je workflow is.

## **Overwegingen bij bewerken en formaten**

- Een handtekening maakt een presentatie niet alleen‑lezbaar. Gebruikers en applicaties kunnen het bestand nog steeds bewerken, maar wijzigingen in de ondertekende inhoud maken de bestaande handtekening normaal gesproken ongeldig.
- Voltooi alle bewerkingen vóór het ondertekenen. Als een presentatie moet worden aangepast, sla je de herziene presentatie op en onderteken je die revisie opnieuw.
- Houd de uiteindelijke output in PPTX‑formaat. Het converteren van een ondertekende presentatie naar een ander formaat draagt de oorspronkelijke PPTX‑handtekening niet over als een geldige handtekening voor het geconverteerde bestand.
- Beschouw de privésleutel van het certificaat als gevoelig. Iedereen die de privésleutel en het wachtwoord verkrijgt, kan mogelijk handtekeningen aanmaken die lijken te komen van die certificaathouder.
- Bewaar het ongeondertekende bronbestand of een andere gecontroleerde kopie wanneer je document‑bewaarbeleid dit vereist.

## **FAQ**

**Versleutelt een digitale handtekening de presentatie?**

Nee. Een digitale handtekening levert bewijs over oorsprong en integriteit, maar de presentatie‑inhoud blijft leesbaar tenzij afzonderlijke versleuteling wordt toegepast. Gebruik [password protection](/slides/nl/nodejs-java/password-protected-presentation/) wanneer de toegang tot de inhoud beperkt moet worden.

**Is het PFX‑wachtwoord hetzelfde als het presentatiewachtwoord?**

Nee. Het PFX‑wachtwoord ontgrendelt de privésleutel die in het certificaatpakket is opgeslagen. Het regelt niet wie de PPTX‑file kan openen of bewerken.

**Kan ik een zelfondertekend certificaat gebruiken?**

Technisch kan een zelfondertekend certificaat worden gebruikt wanneer het een toegankelijke privésleutel bevat. Ontvangers vertrouwen het echter niet automatisch, tenzij dat certificaat expliciet is toegevoegd aan hun vertrouwde omgeving. Publieke of cross‑organisatieworkflows gebruiken meestal een certificaat dat is uitgegeven door een vertrouwde CA.

**Wat maakt een handtekening ongeldig?**

Het aanpassen van ondertekende presentatiewijziging of handtekeningsdata na ondertekening kan de handtekening ongeldig maken. Bestandsschade kan ook de validatie laten falen. Als alle handtekeningen worden verwijderd, is de presentatie ongeondertekend in plaats van een bestand met een ongeldige handtekening.

**Betekent een geldige handtekening dat ik de ondertekenaar moet vertrouwen?**

Niet op zich. Handtekeningintegriteit en ondertekenaar‑vertrouwen zijn aparte beslissingen. Een productie‑validatiebeleid moet tevens de certificaatketen, geldigheidsperiode, intrekkingsstatus, verwachte identiteit, sleutelgebruik en eventuele vereisten voor een vertrouwde timestamp controleren.

**Wat gebeurt er wanneer het certificaat verloopt?**

Het verlopen van een certificaat wijzigt de bytes van de presentatie niet, maar het beïnvloedt de beoordeling van certificatietrust. Of een handtekening acceptabel blijft, hangt af van je beleid en of een geldige vertrouwde timestamp aantoont dat ondertekening plaatsvond terwijl het certificaat geldig was. Vertrouw niet alleen op de weergegeven ondertekeningstijd als een vertrouwde timestamp.

**Kan een ondertekende presentatie nog bewerkt worden?**

Ja. Ondertekenen vergrendelt het bestand niet. Het bewerken van ondertekende inhoud maakt doorgaans de bestaande handtekening ongeldig, dus voltooi eerst de presentatie en onderteken vervolgens de definitieve revisie.

**Kan een presentatie meer dan één handtekening bevatten?**

Ja. Voeg elke handtekening toe aan de collectie die wordt geretourneerd door [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) voordat je opslaat. Tijdens validatie inspecteer je elke handtekening en bevestig je dat alle vereiste ondertekenaars aanwezig zijn.

**Welke presentatieformaten ondersteunen deze bewerkingen?**

Aspose.Slides ondersteunt de hier beschreven digitale‑handtekening‑bewerkingen alleen voor PPTX. PPT‑ en OpenDocument‑presentatieformaten worden niet ondersteund door deze API‑workflow.

**Kan ik een handtekening verwijderen zonder de dia’s te beïnvloeden?**

Ja. Je kunt één handtekening verwijderen of de volledige collectie wissen en vervolgens de presentatie opslaan. De dia‑inhoud blijft beschikbaar, maar het opgeslagen bestand bevat niet langer het verwijderde handtekening‑bewijs.