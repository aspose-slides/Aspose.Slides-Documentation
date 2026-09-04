---
title: Licensering
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
description: "Pas een licentie toe vanuit een bestand, bytes of metered licentie in Aspose.Slides voor Python via Java en verwijder evaluatiebeperkingen uit je applicaties."
---
## **Overzicht**

Aspose.Slides for Python via Java kan in evaluatiemodus of met een licentie uitgevoerd worden. Dit artikel legt uit hoe je een licentie toepast vanaf een bestand of bytes en hoe je metered licensering configureert.

Voor aankoopopties, zie [Prijsinformatie](https://purchase.aspose.com/pricing/slides/nl/family). Voor algemene licentie‑ en aankoopvragen, zie [Aankoopbeleid en FAQ](https://purchase.aspose.com/policies).

Voor beperkingen tijdens evaluatie en hoe je een tijdelijke licentie kunt aanvragen, zie [Evalueer Aspose.Slides](/slides/nl/python-java/evaluate-aspose-slides/). Pas een tijdelijke licentie toe op dezelfde manier als een aangeschafte licentiebestand.

## **Over de licentie**

Een licentiebestand bevat informatie zoals de productnaam, het aantal gelicentieerde ontwikkelaars en de vervaldatum van het abonnement. Het bestand is een digitaal ondertekende XML.

{{% alert color="warning" title="Warning" %}}
Bewerk het licentiebestand niet. Zelfs een extra regeleinde kan de digitale handtekening ongeldig maken.
{{% /alert %}}

Pas de licentie één keer per applicatie of proces toe, vóór het aanmaken van presentaties of het uitvoeren van andere Aspose.Slides‑bewerkingen. Voor een licentiebestand gebruik je de klasse [License](https://reference.aspose.com/slides/nl/python-java/aspose.slides/license/). Metered licensering gebruikt een publiek‑ en privé‑sleutelpaar in plaats van een licentiebestand.

## **Licentie toepassen**

De volgende voorbeelden gaan ervan uit dat Aspose.Slides for Python via Java en de vereiste componenten geïnstalleerd zijn. Elk voorbeeld is een zelfstandig script dat de JVM start, de API importeert en een licentie toepast. Voer in je applicatie je presentatie‑activiteiten uit nadat de licentie is toegepast en sluit de JVM pas af wanneer al het Aspose.Slides‑werk voltooid is.

### **Licentie toepassen vanuit een bestand**

Geef het pad naar het licentiebestand door aan [License.setLicense](https://reference.aspose.com/slides/nl/python-java/aspose.slides/license/#setLicense). Vervang `Aspose.Slides.lic` door het pad naar je licentiebestand.

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
        # Voer hier presentatiewerkzaamheden uit, voordat de JVM wordt afgesloten.
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
        # Voer hier presentatiewerkzaamheden uit, voordat de JVM wordt afgesloten.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

Bewaar de originele bytes ongewijzigd. Decodeer, herformatteer of wijzig de licentie‑inhoud op geen enkele manier voordat je deze toepast.

## **Metered‑licentie toepassen**

Metered licensering factureert je op basis van API‑gebruik. Nadat je een metered licentie hebt verkregen, pas je de publieke en private sleutels toe met [Metered.setMeteredKey](https://reference.aspose.com/slides/nl/python-java/aspose.slides/metered/#setMeteredKey). Initialiseert je een [Metered](https://reference.aspose.com/slides/nl/python-java/aspose.slides/metered/) object en pas je de sleutels één keer toe bij het opstarten van de applicatie.

Het volgende voorbeeld leest de sleutels uit de omgevingsvariabelen `ASPOSE_METERED_PUBLIC_KEY` en `ASPOSE_METERED_PRIVATE_KEY`. Stel beide variabelen in voordat je het script uitvoert.

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
        # Voer hier presentatiewerkzaamheden uit, voordat de JVM wordt afgesloten.
    else:
        print("Set both metered licensing environment variables before running this example.")
finally:
    jpype.shutdownJVM()
```

{{% alert color="info" title="Note" %}}
Metered licensering vereist een internetverbinding om de sleutels te valideren en het gebruik te rapporteren. Houd de private sleutel buiten de broncode en logs. Zie de [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered) voor details over verbinding en facturering.
{{% /alert %}}

## **Veelgestelde vragen**

**Moet ik na het aanschaffen van een licentie een ander pakket installeren?**

Nee. Pas de licentie toe op hetzelfde pakket dat je tijdens de evaluatie hebt gebruikt.

**Moet ik voor elke presentatie een licentie toepassen?**

Nee. Pas deze één keer toe tijdens de opstart van de applicatie, vóór het maken of laden van presentaties.

**Kan ik het licentiebestand hernoemen?**

Ja. Gebruik de exacte nieuwe bestandsnaam in je code en laat de bestandsinhoud ongewijzigd.

**Kan ik een tijdelijke licentie gebruiken met het voorbeeld gebaseerd op bytes?**

Ja. Lees het tijdelijke licentiebestand in als bytes en pas het toe op dezelfde manier als een aangeschafte licentie.