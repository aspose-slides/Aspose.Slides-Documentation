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
- PFX-certificaat
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

Een digitale handtekening helpt een ontvanger bepalen wie een presentatie heeft ondertekend en of de ondertekende inhoud is gewijzigd. Drie gerelateerde beveiligingsconcepten zijn hier belangrijk:

- Een **digitaal certificaat** is een elektronische referentie die een identiteit koppelt aan een publieke sleutel. Een vertrouwde certificaatautoriteit (CA) kan een certificaat uitgeven, of een organisatie kan een zelfondertekend certificaat gebruiken voor interne processen.
- Een **digitale handtekening** wordt gemaakt van de presentatiewaarde en de privésleutel van de certificaathouder. De publieke sleutel van het certificaat kan vervolgens worden gebruikt om de handtekening te verifiëren. Een handtekening biedt bewijs van herkomst en integriteit; het versleutelt de presentatie niet.
- **Wachtwoordbeveiliging** bepaalt of een gebruiker een presentatie kan openen of wijzigen. Het staat los van digitale ondertekening en wordt beschreven in [Password-Protected Presentations](/php-java/password-protected-presentation/).

PowerPoint biedt de opdracht **Add a Digital Signature** onder **File > Info > Protect Presentation**.

![PowerPoint Protect Presentation menu with Add a Digital Signature highlighted](add-digital-signature-in-powerpoint.png)

Na het openen van een ondertekende presentatie kan PowerPoint een melding over de handtekeningstatus weergeven.

![PowerPoint notification stating that the presentation contains valid signatures](digital-signature-status-in-powerpoint.png)

Aspose.Slides maakt handtekeningen beschikbaar via [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#getDigitalSignatures), die een [DigitalSignatureCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/digitalsignaturecollection/) teruggeeft waarvan de items worden vertegenwoordigd door [DigitalSignature](https://reference.aspose.com/slides/nl/php-java/aspose.slides/digitalsignature/)‑objecten. Een presentatie kan meerdere handtekeningen bevatten.

## **Begrijp PFX‑certificaten en wachtwoorden**

Een PFX‑bestand, ook bekend als een PKCS#12‑bestand en meestal met de extensie `.pfx` of `.p12`, kan een X.509‑certificaat, de privésleutel en de certificaatketen bevatten. De privésleutel stelt de houder in staat een handtekening te maken. Een certificaat zonder toegankelijke privésleutel kan niet worden gebruikt om een presentatie te ondertekenen.

Het PFX‑wachtwoord beschermt het certificaatpakket en de privésleutel. Het is **geen** wachtwoord om de presentatie te openen of te bewerken. Voeg PFX‑bestanden of hun wachtwoorden niet toe aan source control. In productie moet de toegang tot het certificaatbestand worden beperkt en moet het wachtwoord uit een geheime opslag of een andere beveiligde configuratiebron worden opgehaald. De onderstaande voorbeelden gebruiken een omgevingsvariabele alleen om te vermijden dat het wachtwoord in code wordt ingebed.

## **Een digitale handtekening aan een presentatie toevoegen**

Om een echte ondertekeningsworkflow te demonstreren, laad een bestaande PPTX‑bestand, maak een [DigitalSignature](https://reference.aspose.com/slides/nl/php-java/aspose.slides/digitalsignature/) aan vanuit een PFX‑certificaat en het bijbehorende wachtwoord, voeg de handtekening toe aan de collectie van de presentatie en sla op als een PPTX‑bestand.

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

Het opslaan onder een nieuwe naam behoudt het niet‑ondertekende bronbestand. De waarde ingesteld via [DigitalSignature::setComments](https://reference.aspose.com/slides/nl/php-java/aspose.slides/digitalsignature/setcomments/) beschrijft het doel van de handtekening; het is geen beveiligingscontrole.

## **Digitale handtekeningen valideren**

Wanneer je een ondertekende PPTX‑bestand laadt, inspecteer elk item dat wordt geretourneerd door [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#getDigitalSignatures). De methode [DigitalSignature::isValid](https://reference.aspose.com/slides/nl/php-java/aspose.slides/digitalsignature/isvalid/) geeft aan of de ingebedde handtekening geldig is voor de huidige presentatiewaarde.

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

Een ongeldig resultaat betekent vaak dat de ondertekende presentatiewaarde of de handtekeninggegevens na ondertekening zijn gewijzigd, of dat het bestand beschadigd is. Het verwijderen van alle handtekeningen levert een niet‑ondertekende presentatie op, dus alleen de geldigheid van items controleren is niet voldoende: een beveiligingsgevoelige workflow moet ook verifiëren dat het verwachte aantal handtekeningen en de verwachte ondertekenaars aanwezig zijn.

Dit geldigheidsresultaat moet niet worden beschouwd als een volledige certificaat‑vertrouwensbeslissing. Afhankelijk van je beveiligingsbeleid moet je applicatie mogelijk ook de X.509‑certificaatketen opbouwen en valideren, de geldigheidsdatums en intrekkingsstatus van het certificaat controleren, de verwachte subject‑ of thumbprint bevestigen, sleutelgebruik verifiëren en een vertrouwde timestamp evalueren. De waarde van [DigitalSignature::getSignTime](https://reference.aspose.com/slides/nl/php-java/aspose.slides/digitalsignature/getsigntime/) op zich is geen bewijs van een vertrouwde timestamp‑autoriteit.

## **Digitale handtekeningen verwijderen**

Het verwijderen van handtekeningen wijzigt de beveiligingsstatus van de presentatie. Het volgende voorbeeld laadt een ondertekende PPTX‑bestand, verwijdert alle handtekeningen met [DigitalSignatureCollection::clear](https://reference.aspose.com/slides/nl/php-java/aspose.slides/digitalsignaturecollection/clear/), en slaat een niet‑ondertekende kopie op.

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $presentation->getDigitalSignatures()->clear();
    $presentation->save("InputPresentation-unsigned.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Om slechts één handtekening te verwijderen, roep [DigitalSignatureCollection::removeAt](https://reference.aspose.com/slides/nl/php-java/aspose.slides/digitalsignaturecollection/removeat/) aan met de nul‑gebaseerde index. Sla op onder een nieuw bestand tenzij het overschrijven van het ondertekende origineel expliciet deel uitmaakt van je workflow.

## **Bewerkings‑ en formaatoverwegingen**

- Een handtekening maakt een presentatie niet alleen‑lezen. Gebruikers en applicaties kunnen het bestand nog steeds bewerken, maar wijzigingen in ondertekende inhoud maken normaal gesproken de bestaande handtekening ongeldig.
- Voltooi alle bewerkingen vóór ondertekening. Als een presentatie moet worden gewijzigd, sla dan de herziene versie op en onderteken die revisie opnieuw.
- Houd de uiteindelijke uitvoer in PPTX‑formaat. Het converteren van een ondertekende presentatie naar een ander formaat draagt de oorspronkelijke PPTX‑handtekening niet over als een geldige handtekening voor het geconverteerde bestand.
- Beschouw de privésleutel van het certificaat als gevoelig. Iedereen die de privésleutel en het wachtwoord verkrijgt, kan handtekeningen maken die lijken te komen van die certificaathouder.
- Bewaar de niet‑ondertekende bron of een andere gecontroleerde kopie wanneer je document‑retentiebeleid dit vereist.

## **FAQ**

**Versleutelt een digitale handtekening de presentatie?**

Nee. Een digitale handtekening levert bewijs over herkomst en integriteit, maar de inhoud van de presentatie blijft leesbaar tenzij afzonderlijke encryptie wordt toegepast. Gebruik [password protection](/php-java/password-protected-presentation/) wanneer de toegang tot de inhoud beperkt moet worden.

**Is het PFX‑wachtwoord hetzelfde als een presentatiewachtwoord?**

Nee. Het PFX‑wachtwoord ontsluit de privésleutel die in het certificaatpakket is opgeslagen. Het bepaalt niet wie de PPTX‑file kan openen of bewerken.

**Kan ik een zelfondertekend certificaat gebruiken?**

Technisch kan een zelfondertekend certificaat worden gebruikt wanneer het een toegankelijke privésleutel bevat. Ontvangers zullen het echter niet automatisch vertrouwen, tenzij dat certificaat expliciet is toegevoegd aan hun vertrouwde omgeving. Publieke of cross‑organisatieworkflows gebruiken doorgaans een certificaat uitgegeven door een vertrouwde CA.

**Wat maakt een handtekening ongeldig?**

Het wijzigen van ondertekende presentatiewaarde of de handtekeninggegevens na ondertekening kan de handtekening ongeldig maken. Beschadiging van het bestand kan eveneens leiden tot een mislukte validatie. Als alle handtekeningen worden verwijderd, is de presentatie niet‑ondertekend in plaats van een bestand met een ongeldige handtekening.

**Betekent een geldige handtekening dat ik de ondertekenaar moet vertrouwen?**

Niet op zichzelf. Integriteit van de handtekening en vertrouwen in de ondertekenaar zijn afzonderlijke beslissingen. Een productieve validatie‑policy moet ook de certificaatketen, geldigheidsperiode, intrekkingsstatus, verwachte identiteit, sleutelgebruik en eventuele vereisten voor een vertrouwde timestamp controleren.

**Wat gebeurt er wanneer het certificaat verloopt?**

Het verlopen van een certificaat verandert de bytes van de presentatie niet, maar het beïnvloedt de beoordeling van certificaat‑vertrouwen. Of een handtekening acceptabel blijft, hangt af van je beleid en of een geldige vertrouwde timestamp aantoont dat ondertekening plaatsvond terwijl het certificaat nog geldig was. Vertrouw niet uitsluitend op de weergegeven ondertekenings‑tijd als een vertrouwde timestamp.

**Kan een ondertekende presentatie nog bewerkt worden?**

Ja. Ondertekenen vergrendelt het bestand niet. Het bewerken van ondertekende inhoud maakt doorgaans de bestaande handtekening ongeldig, dus voltooi de presentatie eerst en onderteken de definitieve revisie.

**Kan een presentatie meer dan één handtekening bevatten?**

Ja. Voeg elke handtekening toe aan de collectie die wordt geretourneerd door [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#getDigitalSignatures) vóór het opslaan. Tijdens validatie inspecteer je elke handtekening en bevestig je dat alle vereiste ondertekenaars aanwezig zijn.

**Welke presentatieformaten ondersteunen deze bewerkingen?**

Aspose.Slides ondersteunt de hier beschreven digitale‑handtekening‑bewerkingen alleen voor PPTX. PPT‑ en OpenDocument‑presentatieformaten worden niet ondersteund door deze API‑workflow.

**Kan ik een handtekening verwijderen zonder de dia's te beïnvloeden?**

Ja. Je kunt één handtekening verwijderen of de hele collectie leegmaken en vervolgens de presentatie opslaan. De dia‑inhoud blijft beschikbaar, maar het opgeslagen bestand bevat daarna niet meer het verwijderde handtekening‑bewijs.