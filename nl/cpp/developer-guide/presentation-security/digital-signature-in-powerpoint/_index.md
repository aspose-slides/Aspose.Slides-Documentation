---
title: Digitale handtekeningen toevoegen aan presentaties in C++
linktitle: Digitale handtekening
type: docs
weight: 10
url: /nl/cpp/digital-signature-in-powerpoint/
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
- C++
- Aspose.Slides
description: "Leer hoe u bestaande PPTX-presentaties kunt ondertekenen met PFX-certificaten en Aspose.Slides voor C++ kunt gebruiken om digitale handtekeningen te valideren of te verwijderen."
---
## **Overzicht**

Een digitale handtekening helpt een ontvanger bepalen wie een presentatie heeft ondertekend en of de ondertekende inhoud is gewijzigd. Drie verwante beveiligingsconcepten zijn hier belangrijk:

- Een **digitaal certificaat** is een elektronisch bewijs dat een identiteit koppelt aan een publieke sleutel. Een vertrouwde certificaatautoriteit (CA) kan een certificaat uitgeven, of een organisatie kan een zelfondertekend certificaat gebruiken voor interne workflows.
- Een **digitale handtekening** wordt gemaakt op basis van de presentatie‑inhoud en de privésleutel van de certificaathouder. De openbare sleutel van het certificaat kan vervolgens worden gebruikt om de handtekening te verifiëren. Een handtekening levert bewijs van herkomst en integriteit; ze versleutelt de presentatie niet.
- **Wachtwoordbeveiliging** bepaalt of een gebruiker een presentatie kan openen of wijzigen. Het staat los van digitale ondertekening en wordt beschreven in [Wachtwoordbeschermde presentaties](/slides/nl/cpp/password-protected-presentation/).

PowerPoint biedt de opdracht **Add a Digital Signature** onder **File > Info > Protect Presentation**.

![PowerPoint‑menu Bescherming van de presentatie met Toevoegen van een digitale handtekening gemarkeerd](add-digital-signature-in-powerpoint.png)

Na het openen van een ondertekende presentatie kan PowerPoint een melding over de handtekeningstatus weergeven.

![PowerPoint‑melding dat de presentatie geldige handtekeningen bevat](digital-signature-status-in-powerpoint.png)

Aspose.Slides maakt handtekeningen beschikbaar via [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentation/get_digitalsignatures/), dat een [IDigitalSignatureCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/idigitalsignaturecollection/) retourneert waarvan de items de interface [IDigitalSignature](https://reference.aspose.com/slides/nl/cpp/aspose.slides/idigitalsignature/) implementeren. Een presentatie kan meerdere handtekeningen bevatten.

## **Begrijpen van PFX‑certificaten en wachtwoorden**

Een PFX‑bestand, ook bekend als een PKCS#12‑bestand en meestal met de extensie `.pfx` of `.p12`, kan een X.509‑certificaat, de bijbehorende privésleutel en de certificaatketen bevatten. De privésleutel maakt het mogelijk voor de houder om een handtekening te maken. Een certificaat zonder toegankelijke privésleutel kan niet worden gebruikt om een presentatie te ondertekenen.

Het PFX‑wachtwoord beschermt het certificaatpakket en de privésleutel. Het is **geen** wachtwoord om de presentatie te openen of te bewerken. Commit geen PFX‑bestanden of hun wachtwoorden naar source‑control. In productie, beperk de toegang tot het certificaatbestand en haal het wachtwoord uit een geheime opslag of een andere beveiligde configuratiebron. De onderstaande voorbeelden gebruiken een omgevingsvariabele uitsluitend om te voorkomen dat het wachtwoord in de code wordt ingebed.

## **Een digitale handtekening aan een presentatie toevoegen**

Om een echte onderteken‑workflow te demonstreren, laad een bestaande PPTX‑file, maak een [DigitalSignature](https://reference.aspose.com/slides/nl/cpp/aspose.slides/digitalsignature/) aan vanuit een PFX‑certificaat en het bijbehorende wachtwoord, voeg de handtekening toe aan de collectie van de presentatie, en sla op als een PPTX‑bestand.

```cpp
auto certificatePassword = Environment::GetEnvironmentVariable(u"PFX_PASSWORD");
if (certificatePassword.IsNullOrEmpty())
{
    throw InvalidOperationException(u"Set the PFX_PASSWORD environment variable.");
}

auto presentation = MakeObject<Presentation>(u"InputPresentation.pptx");

auto signature = MakeObject<DigitalSignature>(u"signing-certificate.pfx", certificatePassword);
signature->set_Comments(u"Approved for release.");

presentation->get_DigitalSignatures()->Add(signature);
presentation->Save(u"InputPresentation-signed.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat onder een nieuwe naam opslaan behoudt het niet‑ondertekende bronbestand. De waarde van [IDigitalSignature::set_Comments](https://reference.aspose.com/slides/nl/cpp/aspose.slides/idigitalsignature/set_comments/) beschrijft het doel van de handtekening; het is geen beveiligingsmaatregel.

## **Digitale handtekeningen valideren**

Wanneer je een ondertekende PPTX‑file laadt, inspecteer elk item dat wordt geretourneerd door [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentation/get_digitalsignatures/). De methode [IDigitalSignature::get_IsValid](https://reference.aspose.com/slides/nl/cpp/aspose.slides/idigitalsignature/get_isvalid/) geeft aan of de ingebedde handtekening geldig is voor de huidige presentatie‑inhoud.

```cpp
auto presentation = MakeObject<Presentation>(u"InputPresentation-signed.pptx");

auto signatureCount = presentation->get_DigitalSignatures()->get_Count();

if (signatureCount == 0)
{
    Console::WriteLine(u"The presentation does not contain digital signatures.");
}
else
{
    bool allSignaturesAreValid = true;

    for (int signatureIndex = 0; signatureIndex < signatureCount; ++signatureIndex)
    {
        auto signature = presentation->get_DigitalSignature(signatureIndex);
        auto signatureIsValid = signature->get_IsValid();
        auto signatureStatus = signatureIsValid ? u"VALID" : u"INVALID";
        auto signerName = signature->get_Certificate()->get_SubjectName()->get_Name();
        auto signingTime = signature->get_SignTime().ToString(u"yyyy-MM-dd HH:mm:ss");

        Console::WriteLine(u"{0}, {1} -- {2}", signerName, signingTime, signatureStatus);

        allSignaturesAreValid = allSignaturesAreValid && signatureIsValid;
    }

    if (allSignaturesAreValid)
    {
        Console::WriteLine(u"All embedded signatures are valid for the current presentation.");
    }
    else
    {
        Console::WriteLine(u"At least one embedded signature is invalid.");
    }
}

presentation->Dispose();
```

Een ongeldig resultaat betekent meestal dat de ondertekende presentatie‑inhoud of handtekeninggegevens na het ondertekenen zijn gewijzigd, of dat het bestand beschadigd is. Het verwijderen van elke handtekening levert een niet‑ondertekende presentatie op, dus alleen de geldigheid van items controleren is niet voldoende: een beveiligings‑gevoelige workflow moet ook verifiëren dat het verwachte aantal handtekeningen en de verwachte ondertekenaars aanwezig zijn.

Dit geldigheidsresultaat mag niet worden gezien als een definitieve vertrouwensbeslissing over het certificaat. Afhankelijk van je beveiligingsbeleid kan je applicatie ook de X.509‑certificaatketen moeten opbouwen en valideren, de geldigheidsdatums en intrekkingsstatus controleren, het verwachte onderwerp of vingerafdruk bevestigen, het sleutelgebruik verifiëren, en een vertrouwde tijdstempel evalueren. De waarde van [IDigitalSignature::get_SignTime](https://reference.aspose.com/slides/nl/cpp/aspose.slides/idigitalsignature/get_signtime/) alleen is geen bewijs van een vertrouwde tijdstempel‑autoriteit.

## **Digitale handtekeningen verwijderen**

Het verwijderen van handtekeningen verandert de beveiligingsstatus van de presentatie. Het volgende voorbeeld laadt een ondertekende PPTX‑file, verwijdert alle handtekeningen met [IDigitalSignatureCollection::Clear](https://reference.aspose.com/slides/nl/cpp/aspose.slides/idigitalsignaturecollection/clear/), en slaat een niet‑ondertekende kopie op.

```cpp
auto presentation = MakeObject<Presentation>(u"InputPresentation-signed.pptx");

presentation->get_DigitalSignatures()->Clear();
presentation->Save(u"InputPresentation-unsigned.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Om slechts één handtekening te verwijderen, roep [IDigitalSignatureCollection::RemoveAt](https://reference.aspose.com/slides/nl/cpp/aspose.slides/idigitalsignaturecollection/removeat/) aan met de nul‑gebaseerde index. Sla op onder een nieuw bestand tenzij het overschrijven van het ondertekende origineel een expliciet onderdeel van je workflow is.

## **Bewerkings‑ en formatoverwegingen**

- Een handtekening maakt een presentatie niet alleen‑lezen. Gebruikers en applicaties kunnen het bestand nog steeds bewerken, maar wijzigingen aan ondertekende inhoud maken de bestaande handtekening doorgaans ongeldig.
- Voltooi alle gewenste bewerkingen vóór het ondertekenen. Als een presentatie moet worden aangepast, sla de herziene versie op en onderteken die revisie opnieuw.
- Houd het eindresultaat in PPTX‑formaat. Het converteren van een ondertekende presentatie naar een ander formaat draagt de oorspronkelijke PPTX‑handtekening niet over als een geldige handtekening voor het geconverteerde bestand.
- Beschouw de privésleutel van het certificaat als gevoelig. Iedereen die de privésleutel en het wachtwoord verkrijgt, kan mogelijk handtekeningen maken die lijken te komen van die certificaathouder.
- Bewaar de niet‑ondertekende bron of een andere gecontroleerde kopie wanneer je document‑bewaarbeleid dit vereist.

## **FAQ**

**Versleutelt een digitale handtekening de presentatie?**

Nee. Een digitale handtekening levert bewijs over herkomst en integriteit, maar de inhoud van de presentatie blijft leesbaar tenzij afzonderlijke versleuteling wordt toegepast. Gebruik [Wachtwoordbeschermde presentaties](/slides/nl/cpp/password-protected-presentation/) wanneer de toegang tot de inhoud beperkt moet worden.

**Is het PFX‑wachtwoord hetzelfde als een presentatiewachtwoord?**

Nee. Het PFX‑wachtwoord ontgrendelt de privésleutel die in het certificaatpakket is opgeslagen. Het bepaalt niet wie het PPTX‑bestand kan openen of bewerken.

**Kan ik een zelfondertekend certificaat gebruiken?**

Technisch kan een zelfondertekend certificaat worden gebruikt wanneer het een toegankelijke privésleutel bevat. Ontvangers zullen het echter niet automatisch vertrouwen, tenzij dat certificaat expliciet aan hun vertrouwde omgeving is toegevoegd. Publieke of cross‑organisatie‑workflows gebruiken doorgaans een certificaat uitgegeven door een vertrouwde CA.

**Wat maakt een handtekening ongeldig?**

Het wijzigen van de ondertekende presentatie‑inhoud of de handtekeninggegevens na het ondertekenen kan de handtekening ongeldig maken. Bestandscorruptie kan ook leiden tot een mislukte validatie. Als alle handtekeningen worden verwijderd, is de presentatie niet ondertekend in plaats van dat het een bestand met een ongeldige handtekening is.

**Betekent een geldige handtekening dat ik de ondertekenaar moet vertrouwen?**

Niet op zichzelf. Integriteit van de handtekening en vertrouwen in de ondertekenaar zijn aparte besluiten. Een productie‑validatiebeleid moet ook de certificaatketen, geldigheidsperiode, intrekkingsstatus, verwachte identiteit, sleutelgebruik en eventuele vereisten voor een vertrouwde tijdstempel controleren.

**Wat gebeurt er wanneer het certificaat verloopt?**

Het verlopen van het certificaat verandert de bytes van de presentatie niet, maar beïnvloedt de evaluatie van certificaat‑vertrouwen. Of een handtekening acceptabel blijft, hangt af van je beleid en of een geldige vertrouwde tijdstempel aantoont dat de ondertekening plaatsvond terwijl het certificaat nog geldig was. Vertrouw niet alleen op de weergegeven ondertekeningsdatum als een vertrouwde tijdstempel.

**Kan een ondertekende presentatie nog steeds worden bewerkt?**

Ja. Ondertekenen vergrendelt het bestand niet. Het bewerken van ondertekende inhoud maakt de bestaande handtekening meestal ongeldig, dus rond de presentatie eerst af en onderteken de definitieve revisie.

**Kan een presentatie meer dan één handtekening bevatten?**

Ja. Voeg elke handtekening toe aan de collectie die wordt geretourneerd door [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentation/get_digitalsignatures/) voordat je opslaat. Tijdens validatie inspecteer je elke handtekening en bevestig je dat alle vereiste ondertekenaars aanwezig zijn.

**Welke presentatieformaten ondersteunen deze bewerkingen?**

Aspose.Slides ondersteunt de hier beschreven digitale‑handtekeningbewerkingen uitsluitend voor PPTX. PPT‑ en OpenDocument‑presentatieformaten worden niet ondersteund door deze API‑workflow.

**Kan ik een handtekening verwijderen zonder de dia's te beïnvloeden?**

Ja. Je kunt één handtekening verwijderen of de gehele collectie wissen en vervolgens de presentatie opslaan. De inhoud van de dia's blijft behouden, maar het opgeslagen bestand bevat geen bewijs meer van de verwijderde handtekening.