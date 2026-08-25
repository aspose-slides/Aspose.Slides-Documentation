---
title: Digitale handtekeningen toevoegen aan presentaties in PHP
linktitle: Digitale handtekening
type: docs
weight: 10
url: /nl/php-java/digital-signature-in-powerpoint/
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
- PHP
- Aspose.Slides
description: "Leer hoe u bestaande PPTX-presentaties kunt ondertekenen met PFX-certificaten en Aspose.Slides voor PHP via Java kunt gebruiken om digitale handtekeningen te valideren of te verwijderen."
---
## **Overzicht**

Een digitale handtekening helpt een ontvanger bepalen wie een presentatie heeft ondertekend en of de ondertekende inhoud is gewijzigd. Drie verwante beveiligingsconcepten zijn hier belangrijk:

- Een **digitaal certificaat** is een elektronisch bewijs dat een identiteit koppelt aan een openbare sleutel. Een vertrouwde certificaatautoriteit (CA) kan een certificaat uitgeven, of een organisatie kan een zelfondertekend certificaat gebruiken voor interne workflows.
- Een **digitale handtekening** wordt gemaakt op basis van de presentatie‑inhoud en de privésleutel van de certificaathouder. De openbare sleutel van het certificaat kan vervolgens worden gebruikt om de handtekening te verifiëren. Een handtekening levert bewijs van oorsprong en integriteit; het versleutelt de presentatie niet.
- **Wachtwoordbescherming** bepaalt of een gebruiker een presentatie kan openen of wijzigen. Het staat los van digitale ondertekening en wordt beschreven in [Wachtwoordbeveiligde presentaties](/slides/nl/php-java/password-protected-presentation/).

PowerPoint biedt de opdracht **Add a Digital Signature** onder **File > Info > Protect Presentation**.

![PowerPoint‑menu Bescherming presentatie met Voeg een digitale handtekening toe gemarkeerd](add-digital-signature-in-powerpoint.png)

Na het openen van een ondertekende presentatie kan PowerPoint een melding over de handtekeningstatus weergeven.

![PowerPoint‑melding die aangeeft dat de presentatie geldige handtekeningen bevat](digital-signature-status-in-powerpoint.png)

Aspose.Slides stelt handtekeningen beschikbaar via [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#getDigitalSignatures), die een [DigitalSignatureCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/digitalsignaturecollection/) retourneert, waarvan de items worden weergegeven door [DigitalSignature](https://reference.aspose.com/slides/nl/php-java/aspose.slides/digitalsignature/)‑objecten. Een presentatie kan meerdere handtekeningen bevatten.

## **Begrijp PFX‑certificaten en wachtwoorden**

Een PFX‑bestand, ook wel een PKCS#12‑bestand genoemd en doorgaans met de extensie `.pfx` of `.p12`, kan een X.509‑certificaat, de privésleutel en de certificaatketen bevatten. De privésleutel maakt het mogelijk voor de houder om een handtekening te creëren. Een certificaat zonder een toegankelijke privésleutel kan niet worden gebruikt om een presentatie te ondertekenen.

Het PFX‑wachtwoord beschermt het certificaat‑pakket en de privésleutel. Het is **niet** een wachtwoord om de presentatie te openen of te bewerken. Commit geen PFX‑bestanden of hun wachtwoorden naar source control. In productie moet de toegang tot het certificaatbestand worden beperkt en moet het wachtwoord worden verkregen uit een geheime opslag of een andere beveiligde configuratiebron. De voorbeelden hieronder gebruiken alleen een omgevingsvariabele om te voorkomen dat het wachtwoord in de code wordt ingebed.

## **Een digitale handtekening toevoegen aan een presentatie**

Om een werkelijke ondertekeningsworkflow te demonstreren, laad een bestaande PPTX‑file, maak een [DigitalSignature](https://reference.aspose.com/slides/nl/php-java/aspose.slides/digitalsignature/) aan vanuit een PFX‑certificaat en het bijbehorende wachtwoord, voeg de handtekening toe aan de collectie van de presentatie, en sla op als een PPTX‑file.

```php
$certificatePassword = getenv("PFX_PASSWORD");
if ($certificatePassword === false || $certificatePassword === "") {
    throw new RuntimeException("Set the PFX_PASSWORD environment variable.");
}

$presentation = new Presentation("InputPresentation.pptx");
try {
    $signature = new DigitalSignature("signing-certificate.pfx", $certificatePassword);
    $signature->setComments("Approved for release.");

    $presentation->getDigitalSignatures()->add($signature);
    $presentation->save("InputPresentation-signed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het opslaan van het resultaat onder een nieuwe naam behoudt de niet‑ondertekende bronfile. De waarde die wordt ingesteld via [DigitalSignature::setComments](https://reference.aspose.com/slides/nl/php-java/aspose.slides/digitalsignature/setcomments/) beschrijft het doel van de handtekening; het is geen beveiligingsmaatregel.

## **Digitale handtekeningen valideren**

Wanneer je een ondertekende PPTX‑file laadt, inspecteer elk item dat wordt geretourneerd door [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#getDigitalSignatures). De methode [DigitalSignature::isValid](https://reference.aspose.com/slides/nl/php-java/aspose.slides/digitalsignature/isvalid/) geeft aan of de ingebedde handtekening geldig is voor de huidige presentatie‑inhoud.

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $signatures = $presentation->getDigitalSignatures();
    $signatureCount = java_values($signatures->size());

    if ($signatureCount === 0) {
        echo "The presentation does not contain digital signatures." . PHP_EOL;
    } else {
        $allSignaturesAreValid = true;
        $signTimeFormat = new Java("java.text.SimpleDateFormat", "yyyy-MM-dd HH:mm:ss");
        $certificateFactoryClass = new JavaClass("java.security.cert.CertificateFactory");
        $certificateFactory = $certificateFactoryClass->getInstance("X.509");

        for ($index = 0; $index < $signatureCount; $index++) {
            $signature = $signatures->get_Item($index);
            $signatureIsValid = java_values($signature->isValid());
            $signatureStatus = $signatureIsValid ? "VALID" : "INVALID";
            $formattedSignTime = java_values($signTimeFormat->format($signature->getSignTime()));

            $certificateData = $signature->getCertificate();
            $certificateStream = new Java("java.io.ByteArrayInputStream", $certificateData);
            try {
                $certificate = $certificateFactory->generateCertificate($certificateStream);
                $signerName = java_values($certificate->getSubjectX500Principal()->getName());
            } finally {
                $certificateStream->close();
            }

            echo $signerName . ", " . $formattedSignTime . " -- " . $signatureStatus . PHP_EOL;

            $allSignaturesAreValid = $allSignaturesAreValid && $signatureIsValid;
        }

        if ($allSignaturesAreValid) {
            echo "All embedded signatures are valid for the current presentation." . PHP_EOL;
        } else {
            echo "At least one embedded signature is invalid." . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

Een ongeldige uitkomst betekent meestal dat de ondertekende presentatiewijzigingen of de handtekeninggegevens na het ondertekenen zijn aangepast, of dat het bestand beschadigd is. Het verwijderen van alle handtekeningen resulteert in een niet‑ondertekende presentatie, dus alleen de geldigheid van items controleren is niet voldoende: een beveiligingsgevoelige workflow moet tevens verifiëren dat het verwachte aantal handtekeningen en de verwachte ondertekenaars aanwezig zijn.

Dit geldigheidsresultaat mag niet worden behandeld als een volledige beslissing over certificaatvertrouwen. Afhankelijk van uw beveiligingsbeleid moet uw toepassing mogelijk ook de X.509‑certificaatketen bouwen en valideren, de geldigheidsdatums en intrekstatus van het certificaat controleren, het verwachte onderwerp of de thumbprint bevestigen, sleutelgebruik verifiëren en een vertrouwde tijdstempel evalueren. De waarde van [DigitalSignature::getSignTime](https://reference.aspose.com/slides/nl/php-java/aspose.slides/digitalsignature/getsigntime/) op zichzelf is geen bewijs van een vertrouwde tijdstempel‑autoriteit.

## **Digitale handtekeningen verwijderen**

Het verwijderen van handtekeningen wijzigt de beveiligingsstatus van de presentatie. Het onderstaande voorbeeld laadt een ondertekende PPTX‑file, verwijdert alle handtekeningen met [DigitalSignatureCollection::clear](https://reference.aspose.com/slides/nl/php-java/aspose.slides/digitalsignaturecollection/clear/), en slaat een niet‑ondertekende kopie op.

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $presentation->getDigitalSignatures()->clear();
    $presentation->save("InputPresentation-unsigned.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Om slechts één handtekening te verwijderen, roep [DigitalSignatureCollection::removeAt](https://reference.aspose.com/slides/nl/php-java/aspose.slides/digitalsignaturecollection/removeat/) aan met de nul‑gebaseerde index. Sla op in een nieuw bestand tenzij het overschrijven van het ondertekende origineel een expliciet onderdeel is van uw workflow.

## **Bewerkings‑ en opmaakoverwegingen**

- Een handtekening maakt een presentatie niet alleen‑lezen. Gebruikers en applicaties kunnen het bestand nog steeds bewerken, maar wijzigingen in ondertekende inhoud maken doorgaans de bestaande handtekening ongeldig.
- Voltooi alle bewerkingen vóór het ondertekenen. Als een presentatie moet worden aangepast, sla de gewijzigde presentatie dan op en onderteken die revisie opnieuw.
- Houd de uiteindelijke output in PPTX‑formaat. Het converteren van een ondertekende presentatie naar een ander formaat draagt de oorspronkelijke PPTX‑handtekening niet over als een geldige handtekening voor het geconverteerde bestand.
- Beschouw de privésleutel van het certificaat als gevoelig. Iedereen die de privésleutel en het bijbehorende wachtwoord verkrijgt, kan handtekeningen maken die lijken te komen van die certificaathouder.
- Bewaar de niet‑ondertekende bron of een andere gecontroleerde kopie wanneer uw document‑retentiebeleid dit vereist.

## **Veelgestelde vragen**

**Versleutelt een digitale handtekening de presentatie?**

Nee. Een digitale handtekening levert bewijs over oorsprong en integriteit, maar de presentatie‑inhoud blijft leesbaar tenzij er aparte versleuteling wordt toegepast. Gebruik [Wachtwoordbeveiligde presentaties](/slides/nl/php-java/password-protected-presentation/) wanneer de toegang tot de inhoud moet worden beperkt.

**Is het PFX‑wachtwoord hetzelfde als een presentatiewachtwoord?**

Nee. Het PFX‑wachtwoord ontgrendelt de privésleutel die in het certificaat‑pakket is opgeslagen. Het regelt niet wie de PPTX‑file kan openen of bewerken.

**Kan ik een zelfondertekend certificaat gebruiken?**

Technisch kan een zelfondertekend certificaat worden gebruikt wanneer het een toegankelijke privésleutel bevat. Ontvangers vertrouwen het echter niet automatisch, tenzij dat certificaat expliciet is toegevoegd aan hun vertrouwde omgeving. Publieke of cross‑organisatie workflows gebruiken meestal een certificaat dat is uitgegeven door een vertrouwde CA.

**Wat maakt een handtekening ongeldig?**

Het wijzigen van ondertekende presentatiewijzigingen of de handtekeninggegevens na ondertekening kan de handtekening ongeldig maken. Bestands‑corruptie kan eveneens de validatie doen falen. Als alle handtekeningen worden verwijderd, is de presentatie niet‑ondertekend in plaats van een bestand met een ongeldige handtekening.

**Betekent een geldige handtekening dat ik de ondertekenaar moet vertrouwen?**

Niet automatisch. Handtekeningintegriteit en vertrouwen in de ondertekenaar zijn afzonderlijke beslissingen. Een productie‑validatie‑beleid moet ook de certificaatketen, geldigheidsperiode, intrekstatus, verwachte identiteit, sleutelgebruik en eventuele vereisten voor een vertrouwde tijdstempel controleren.

**Wat gebeurt er wanneer het certificaat verloopt?**

Het verlopen van het certificaat wijzigt de bytes van de presentatie niet, maar het beïnvloedt de beoordeling van certificaatvertrouwen. Of een handtekening acceptabel blijft, hangt af van uw beleid en van of een geldige, vertrouwde tijdstempel bewijst dat ondertekening plaatsvond terwijl het certificaat nog geldig was. Vertrouw niet uitsluitend op de weergegeven ondertekenings‑tijd als een vertrouwde tijdstempel.

**Kan een ondertekende presentatie nog steeds worden bewerkt?**

Ja. Ondertekenen vergrendelt het bestand niet. Het bewerken van ondertekende inhoud maakt doorgaans de bestaande handtekening ongeldig, dus voltooi eerst de presentatie en onderteken daarna de definitieve revisie.

**Kan een presentatie meer dan één handtekening bevatten?**

Ja. Voeg elke handtekening toe aan de collectie die wordt geretourneerd door [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#getDigitalSignatures) voordat u opslaat. Tijdens validatie inspecteert u elke handtekening en bevestigt u dat alle vereiste ondertekenaars aanwezig zijn.

**Welke presentatiesystemen ondersteunen deze bewerkingen?**

Aspose.Slides ondersteunt de hier beschreven digitale‑handtekening‑bewerkingen alleen voor PPTX. PPT‑ en OpenDocument‑presentatieformaten worden niet ondersteund door deze API‑workflow.

**Kan ik een handtekening verwijderen zonder de dia's te beïnvloeden?**

Ja. U kunt één handtekening verwijderen of de volledige collectie wissen en vervolgens de presentatie opslaan. De inhoud van de dia's blijft beschikbaar, maar het opgeslagen bestand bevat geen bewijs meer van de verwijderde handtekening.