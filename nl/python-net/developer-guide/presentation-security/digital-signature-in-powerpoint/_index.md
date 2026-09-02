---
title: Digitale handtekeningen toevoegen aan presentaties in Python
linktitle: Digitale handtekening
type: docs
weight: 10
url: /nl/python-net/digital-signature-in-powerpoint/
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
- Python
- Aspose.Slides
description: "Leer hoe u bestaande PPTX-presentaties kunt ondertekenen met PFX-certificaten en Aspose.Slides voor Python via .NET kunt gebruiken om digitale handtekeningen te valideren of te verwijderen."
---
## **Overzicht**

Een digitale handtekening helpt een ontvanger bepalen wie een presentatie heeft ondertekend en of de ondertekende inhoud is gewijzigd. Drie gerelateerde beveiligingsconcepten zijn hier belangrijk:

- Een **digitaal certificaat** is een elektronisch bewijs dat een identiteit koppelt aan een openbare sleutel. Een vertrouwde certificaatautoriteit (CA) kan een certificaat uitgeven, of een organisatie kan een zelfondertekend certificaat gebruiken voor interne workflows.
- Een **digitale handtekening** wordt gecreëerd uit de presentatie‑inhoud en de privésleutel van de certificaathouder. De openbare sleutel van het certificaat kan vervolgens worden gebruikt om de handtekening te verifiëren. Een handtekening levert bewijs van herkomst en integriteit; zij versleutelt de presentatie niet.
- **Wachtwoordbeveiliging** bepaalt of een gebruiker een presentatie kan openen of wijzigen. Het staat los van digitale ondertekening en wordt beschreven in [Wachtwoordbeveiligde presentaties](/slides/nl/python-net/password-protected-presentation/).

PowerPoint biedt de opdracht **Add a Digital Signature** onder **File > Info > Protect Presentation**.

![PowerPoint‑menu Bescherm presentatie met Add a Digital Signature gemarkeerd](add-digital-signature-in-powerpoint.png)

Na het openen van een ondertekende presentatie kan PowerPoint een handtekening‑statusmelding weergeven.

![PowerPoint‑melding waarin staat dat de presentatie geldige handtekeningen bevat](digital-signature-status-in-powerpoint.png)

Aspose.Slides stelt handtekeningen beschikbaar via [Presentation.digital_signatures](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/digital_signatures/), een [DigitalSignatureCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/digitalsignaturecollection/) waarvan de items [DigitalSignature](https://reference.aspose.com/slides/nl/python-net/aspose.slides/digitalsignature/) objecten zijn. Een presentatie kan meerdere handtekeningen bevatten.

## **PFX‑certificaten en wachtwoorden begrijpen**

Een PFX‑bestand, ook wel een PKCS#12‑bestand genoemd en meestal met de extensie `.pfx` of `.p12`, kan een X.509‑certificaat, de privésleutel en de certificaatketen bevatten. De privésleutel is wat de houder in staat stelt een handtekening te maken. Een certificaat zonder toegankelijke privésleutel kan niet worden gebruikt om een presentatie te ondertekenen.

Het PFX‑wachtwoord beschermt het certificaatpakket en de privésleutel. Het is **niet** het wachtwoord om de presentatie te openen of te bewerken. Commit geen PFX‑bestanden of hun wachtwoorden naar broncodebeheer. In productie moet de toegang tot het certificaatbestand beperkt worden en moet het wachtwoord verkregen worden uit een geheimopslag of een andere beveiligde configuratiebron. De onderstaande voorbeelden gebruiken alleen een omgevingsvariabele om te voorkomen dat het wachtwoord in code wordt ingebed.

## **Een digitale handtekening toevoegen aan een presentatie**

Om een werkelijke presentatieworkflow te ondertekenen, laad een bestaand PPTX‑bestand, maak een [DigitalSignature](https://reference.aspose.com/slides/nl/python-net/aspose.slides/digitalsignature/) aan vanuit een PFX‑certificaat en het bijbehorende wachtwoord, voeg de handtekening toe aan de collectie van de presentatie en sla op als een PPTX‑bestand.

```python
import os
import aspose.slides as slides

certificate_password = os.environ.get("PFX_PASSWORD")
if certificate_password is None:
    raise RuntimeError("Set the PFX_PASSWORD environment variable.")

with slides.Presentation("InputPresentation.pptx") as presentation:
    signature = slides.DigitalSignature("signing-certificate.pfx", certificate_password)
    signature.comments = "Approved for release."

    presentation.digital_signatures.add(signature)
    presentation.save("InputPresentation-signed.pptx", slides.export.SaveFormat.PPTX)
```

Het opslaan van het resultaat onder een nieuwe naam behoudt het niet‑ondertekende bronbestand. De waarde van [DigitalSignature.comments](https://reference.aspose.com/slides/nl/python-net/aspose.slides/digitalsignature/comments/) beschrijft het doel van de handtekening; het is geen beveiligingsmaatregel.

## **Digitale handtekeningen valideren**

Wanneer je een ondertekend PPTX‑bestand laadt, inspecteer je elk item in [Presentation.digital_signatures](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/digital_signatures/). De eigenschap [DigitalSignature.is_valid](https://reference.aspose.com/slides/nl/python-net/aspose.slides/digitalsignature/is_valid/) geeft aan of de ingebedde handtekening geldig is voor de huidige presentatie‑inhoud.

```python
import hashlib
import aspose.slides as slides

with slides.Presentation("InputPresentation-signed.pptx") as presentation:
    signature_count = len(presentation.digital_signatures)

    if signature_count == 0:
        print("The presentation does not contain digital signatures.")
    else:
        all_signatures_are_valid = True

        for signature in presentation.digital_signatures:
            signature_status = "VALID" if signature.is_valid else "INVALID"
            certificate_fingerprint = hashlib.sha256(signature.certificate).hexdigest().upper()
            signing_time = signature.sign_time.strftime("%Y-%m-%d %H:%M:%S")

            print(
                f"Certificate SHA-256: {certificate_fingerprint}, "
                f"{signing_time} -- {signature_status}"
            )

            all_signatures_are_valid = (all_signatures_are_valid and signature.is_valid)

        if all_signatures_are_valid:
            print("All embedded signatures are valid for the current presentation.")
        else:
            print("At least one embedded signature is invalid.")
```

Een ongeldig resultaat betekent meestal dat de ondertekende presentatie‑inhoud of handtekeninggegevens zijn gewijzigd na ondertekening, of dat het bestand beschadigd is. Het verwijderen van alle handtekeningen levert een niet‑ondertekende presentatie op, dus alleen de geldigheid van de items controleren is niet voldoende: een beveiligingsgevoelige workflow moet ook verifiëren dat het verwachte aantal handtekeningen en de verwachte ondertekenaars aanwezig zijn.

De eigenschap [DigitalSignature.certificate](https://reference.aspose.com/slides/nl/python-net/aspose.slides/digitalsignature/certificate/) levert de certificaatgegevens als een byte‑array. Het voorbeeld berekent de SHA‑256‑vingerafdruk zodat een toepassing deze kan vergelijken met de vingerafdruk van een verwacht ondertekeningscertificaat.

Dit geldigheidsresultaat mag niet worden beschouwd als een volledige beslissing over certificaatvertrouwen. Afhankelijk van uw beveiligingsbeleid moet uw toepassing mogelijk ook de X.509‑certificaatketen opbouwen en valideren, de geldigheidsdata en intrekkingsstatus van het certificaat controleren, het verwachte onderwerp of de vingerafdruk bevestigen, het sleutelgebruik verifiëren en een vertrouwde tijdstempel evalueren. De waarde van [DigitalSignature.sign_time](https://reference.aspose.com/slides/nl/python-net/aspose.slides/digitalsignature/sign_time/) is op zichzelf geen bewijs van een vertrouwde tijdstempelautoriteit.

## **Digitale handtekeningen verwijderen**

Het verwijderen van handtekeningen wijzigt de beveiligingsstatus van de presentatie. Het volgende voorbeeld laadt een ondertekend PPTX‑bestand, verwijdert alle handtekeningen met [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/nl/python-net/aspose.slides/digitalsignaturecollection/clear/), en slaat een niet‑ondertekende kopie op.

```python
import aspose.slides as slides

with slides.Presentation("InputPresentation-signed.pptx") as presentation:
    presentation.digital_signatures.clear()
    presentation.save("InputPresentation-unsigned.pptx", slides.export.SaveFormat.PPTX)
```

Om slechts één handtekening te verwijderen, roep je [DigitalSignatureCollection.remove_at](https://reference.aspose.com/slides/nl/python-net/aspose.slides/digitalsignaturecollection/remove_at/) aan met de nul‑gebaseerde index. Sla op in een nieuw bestand, tenzij het overschrijven van het ondertekende origineel een expliciet onderdeel van uw workflow is.

## **Bewerkings‑ en formaatoverwegingen**

- Een handtekening maakt een presentatie niet alleen‑lezen. Gebruikers en toepassingen kunnen het bestand nog steeds bewerken, maar wijzigingen in ondertekende inhoud maken doorgaans de bestaande handtekening ongeldig.
- Voltooi alle beoogde bewerkingen voordat u ondertekent. Als een presentatie moet worden aangepast, sla dan de herziene presentatie op en onderteken die revisie opnieuw.
- Bewaar de uiteindelijke uitvoer in PPTX‑formaat. Het converteren van een ondertekende presentatie naar een ander formaat draagt de oorspronkelijke PPTX‑handtekening niet over als een geldige handtekening voor het geconverteerde bestand.
- Behandel de privésleutel van het certificaat als gevoelig. Iedereen die de privésleutel en het bijbehorende wachtwoord verkrijgt, kan mogelijk handtekeningen maken die lijken te komen van die certificaathouder.
- Bewaar de niet‑ondertekende bron of een andere gecontroleerde kopie wanneer uw document‑bewaarbeleid dit vereist.

## **FAQ**

**Versleutelt een digitale handtekening de presentatie?**

Nee. Een digitale handtekening levert bewijs over herkomst en integriteit, maar de presentatie‑inhoud blijft leesbaar tenzij er aparte versleuteling wordt toegepast. Gebruik [wachtwoordbeveiliging](/slides/nl/python-net/password-protected-presentation/) wanneer de toegang tot de inhoud beperkt moet worden.

**Is het PFX‑wachtwoord hetzelfde als het presentatiewachtwoord?**

Nee. Het PFX‑wachtwoord ontgrendelt de privésleutel die in het certificaatpakket is opgeslagen. Het bepaalt niet wie het PPTX‑bestand kan openen of bewerken.

**Kan ik een zelfondertekend certificaat gebruiken?**

Technisch gezien kan een zelfondertekend certificaat worden gebruikt wanneer het een toegankelijke privésleutel bevat. Ontvangers zullen het echter niet automatisch vertrouwen, tenzij dat certificaat expliciet is toegevoegd aan hun vertrouwde omgeving. Publieke of cross‑organisatie workflows gebruiken doorgaans een certificaat dat is uitgegeven door een vertrouwde CA.

**Wat maakt een handtekening ongeldig?**

Het wijzigen van ondertekende presentatie‑inhoud of de handtekeninggegevens na ondertekening kan de handtekening ongeldig maken. Bestandscorruptie kan ook leiden tot een mislukte validatie. Als alle handtekeningen worden verwijderd, is de presentatie niet ondertekend in plaats van een bestand met een ongeldige handtekening.

**Betekent een geldige handtekening dat ik de ondertekenaar moet vertrouwen?**

Niet op zich. Handtekeningintegriteit en vertrouwen in de ondertekenaar zijn afzonderlijke overwegingen. Een productieve validatie‑policy moet ook de certificaatketen, geldigheidsperiode, intrekkingsstatus, verwachte identiteit, sleutelgebruik en eventuele vereisten voor een vertrouwde tijdstempel controleren.

**Wat gebeurt er wanneer het certificaat verloopt?**

Het verlopen van een certificaat verandert de bytes van de presentatie niet, maar het beïnvloedt de evaluatie van het certificaatvertrouwen. Of een handtekening acceptabel blijft, hangt af van uw beleid en van of een geldige vertrouwde tijdstempel aantoont dat de ondertekening plaatsvond terwijl het certificaat geldig was. Vertrouw niet uitsluitend op de weergegeven ondertekenings‑tijd als een vertrouwde tijdstempel.

**Kan een ondertekende presentatie nog steeds worden bewerkt?**

Ja. Ondertekenen vergrendelt het bestand niet. Het bewerken van ondertekende inhoud maakt doorgaans de bestaande handtekening ongeldig, dus voltooi de presentatie eerst en onderteken de definitieve revisie.

**Kan een presentatie meer dan één handtekening bevatten?**

Ja. Voeg elke handtekening toe aan [Presentation.digital_signatures](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/digital_signatures/) vóór het opslaan. Tijdens validatie inspecteer je elke handtekening en bevestig je dat alle vereiste ondertekenaars aanwezig zijn.

**Welke presentatiefomaten ondersteunen deze bewerkingen?**

Aspose.Slides ondersteunt de hier beschreven digitale‑handtekeningbewerkingen alleen voor PPTX. PPT‑ en OpenDocument‑presentatieformaten worden niet ondersteund door deze API‑workflow.

**Kan ik een handtekening verwijderen zonder de dia's te beïnvloeden?**

Ja. Je kunt één handtekening verwijderen of de volledige collectie leegmaken en vervolgens de presentatie opslaan. De dia‑inhoud blijft beschikbaar, maar het opgeslagen bestand bevat de verwijderde handtekening‑bewijsmateriaal niet meer.