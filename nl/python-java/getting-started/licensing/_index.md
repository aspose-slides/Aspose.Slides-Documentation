---
title: Licenties
type: docs
weight: 80
url: /nl/python-java/licensing/
keywords:
- Aspose.Slides
- Python
- Java
- licentiebestand
- tijdelijke licentie
- metered licensering
- evaluatiebeperkingen
description: "Pas een bestands-, byte-gebaseerde of metered licentie toe in Aspose.Slides voor Python via Java en verwijder evaluatiebeperkingen uit uw toepassingen."
---
## **Overzicht**

Aspose.Slides for Python via Java kan worden uitgevoerd in evaluatiemodus of met een licentie. In evaluatiemodus voegt het een evaluatiewatermerk‑tekstvak toe aan elke dia van elke presentatie die het opslaat en verkort het tekst die uw code uit presentaties leest. Dit artikel legt uit hoe u een licentie vanuit een bestand of bytes toepast en hoe u meter‑licenties configureert.

Voor aankoopopties, zie [Prijsinformatie](https://purchase.aspose.com/pricing/slides/nl/family). Voor algemene licentie‑ en aankoopvragen, zie [Aankoopbeleid en FAQ](https://purchase.aspose.com/policies).

Voor evaluatiebeperkingen en hoe u een tijdelijke licentie kunt aanvragen, zie [Evalueer Aspose.Slides](/slides/nl/python-java/evaluate-aspose-slides/). Pas een tijdelijke licentie toe op dezelfde manier als een aangekochte licentiebestand.

## **Over de licentie**

Een licentiebestand bevat informatie zoals de productnaam, het aantal gelicentieerde ontwikkelaars en de vervaldatum van het abonnement. Het bestand is digitaal ondertekende XML.

{{% alert color="warning" title="Warning" %}}
Bewerk het licentiebestand niet. Zelfs een extra regeleinde kan de digitale handtekening ongeldig maken.
{{% /alert %}}

Pas de licentie één keer per applicatie of proces toe, vóór het maken van presentaties of het uitvoeren van andere Aspose.Slides‑bewerkingen. Voor een licentiebestand gebruikt u de [License](https://reference.aspose.com/slides/nl/python-java/aspose.slides/license/)‑klasse. Metered‑licensering gebruikt een publiek‑ en privésleutelpaar in plaats van een licentiebestand.

## **Licentie toepassen**

De volgende voorbeelden gaan ervan uit dat Aspose.Slides for Python via Java en de benodigde componenten geïnstalleerd zijn. Elk voorbeeld is een zelfstandig script dat de JVM start, de API importeert en een licentie toepast. In uw applicatie voert u uw presentatie‑bewerkingen uit na het toepassen van de licentie en sluit u de JVM pas af zodra al het Aspose.Slides‑werk voltooid is.

### **Licentie toepassen vanuit een bestand**

Geef het pad naar het licentiebestand op aan [License.setLicense](https://reference.aspose.com/slides/nl/python-java/aspose.slides/license/#setLicense). Vervang `Aspose.Slides.lic` door het pad naar uw licentiebestand.

```python
from pathlib import Path

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import License

    license_path = Path("Aspose.Slides.lic")
    if license_path.is_file():
        license = License()
        license.setLicense(str(license_path))
        print("Licensed:", license.isLicensed())
        # Voer hier presentatie‑bewerkingen uit, vóór het afsluiten van de JVM.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

Gebruik de exacte bestandsnaam, inclusief extensie. Bijvoorbeeld, als het bestand `Aspose.Slides.lic.xml` heet, voeg dan `.xml` toe aan het pad. Een absoluut pad voorkomt onduidelijkheid over de werkmap van de applicatie.

Het voorbeeld gebruikt [License.isLicensed](https://reference.aspose.com/slides/nl/python-java/aspose.slides/license/#isLicensed) om te controleren of de licentie is toegepast.

### **Licentie toepassen vanuit bytes**

Gebruik [License.setLicenseFromBytes](https://reference.aspose.com/slides/nl/python-java/aspose.slides/license/#setLicenseFromBytes) wanneer de licentie beschikbaar is als Python‑bytes. Het volgende voorbeeld leest het bestand in binaire modus en sluit het voordat de licentie wordt toegepast.

```python
from pathlib import Path

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import License

    license_path = Path("Aspose.Slides.lic")
    if license_path.is_file():
        with license_path.open("rb") as license_file:
            license_data = license_file.read()

        license = License()
        license.setLicenseFromBytes(license_data)
        print("Licensed:", license.isLicensed())
        # Voer hier presentatie‑bewerkingen uit, vóór het afsluiten van de JVM.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

Houd de oorspronkelijke bytes ongewijzigd. Decodeer, formateer of wijzig de licentie‑inhoud op geen enkele manier vóór het toepassen.

## **Metered licentie toepassen**

Metered‑licensering factureert u op basis van API‑gebruik. Nadat u een metered‑licentie hebt verkregen, past u de publieke en private sleutels toe met [Metered.setMeteredKey](https://reference.aspose.com/slides/nl/python-java/aspose.slides/metered/#setMeteredKey). Initialiseert u het [Metered](https://reference.aspose.com/slides/nl/python-java/aspose.slides/metered/)‑object en past u de sleutels één keer toe bij het opstarten van de applicatie.

Het volgende voorbeeld leest de sleutels uit de omgevingvariabelen `ASPOSE_METERED_PUBLIC_KEY` en `ASPOSE_METERED_PRIVATE_KEY`. Stel beide variabelen in vóór het uitvoeren van het script.

```python
import os

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import Metered

    public_key = os.environ.get("ASPOSE_METERED_PUBLIC_KEY")
    private_key = os.environ.get("ASPOSE_METERED_PRIVATE_KEY")

    if public_key and private_key:
        metered = Metered()
        metered.setMeteredKey(public_key, private_key)
        # Voer hier presentatie-bewerkingen uit, vóór het afsluiten van de JVM.
    else:
        print("Set both metered licensing environment variables before running this example.")
finally:
    jpype.shutdownJVM()
```

{{% alert color="info" title="Note" %}}
Metered‑licensering vereist een internetverbinding om de sleutels te valideren en het gebruik te rapporteren. Houd de privésleutel buiten de broncode en logbestanden. Zie de [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered) voor details over connectiviteit en facturering.
{{% /alert %}}

## **FAQ**

**Moet ik na het aanschaffen van een licentie een ander pakket installeren?**

Nee. Pas de licentie toe op hetzelfde pakket dat u voor de evaluatie gebruikte.

**Moet ik voor elke presentatie een licentie toepassen?**

Nee. Pas deze één keer toe tijdens het opstarten van de applicatie, vóór het aanmaken of laden van presentaties.

**Kan ik het licentiebestand hernoemen?**

Ja. Gebruik de exacte nieuwe bestandsnaam in uw code en laat de bestandinhoud ongewijzigd.

**Kan ik een tijdelijke licentie gebruiken met het voorbeeld op basis van bytes?**

Ja. Lees het tijdelijke licentiebestand als bytes en pas het op dezelfde manier toe als een aangekochte licentie.