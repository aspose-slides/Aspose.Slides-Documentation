---
title: Licensiering
type: docs
weight: 80
url: /sv/python-java/licensing/
keywords:
- Aspose.Slides
- Python
- Java
- licensfil
- tillfällig licens
- mätbaserad licensiering
- utvärderingsbegränsningar
description: "Använd en licens från fil, byte-baserad eller mätbaserad i Aspose.Slides för Python via Java och ta bort utvärderingsbegränsningar från dina applikationer."
---
## **Översikt**

Aspose.Slides for Python via Java kan köras i utvärderingsläge eller med en licens. I utvärderingsläge lägger den till en vattenstämpel med text i varje bild i varje presentation den sparar och trunkerar text som din kod läser från presentationer. Den här artikeln förklarar hur du tillämpar en licens från en fil eller byte och hur du konfigurerar mätbaserad licensiering.

För köpalternativ, se [Pricing Information](https://purchase.aspose.com/pricing/slides/sv/family). För allmänna licens- och köpförfrågningar, se [Purchase Policies and FAQ](https://purchase.aspose.com/policies).

För begränsningar i utvärderingsläget och hur du begär en tillfällig licens, se [Evaluate Aspose.Slides](/slides/sv/python-java/evaluate-aspose-slides/). Använd en tillfällig licens på samma sätt som en köpt licensfil.

## **Om licensen**

En licensfil innehåller information såsom produktnamn, antalet licensierade utvecklare och prenumerationens utgångsdatum. Filen är ett digitalt signerat XML.

{{% alert color="warning" title="Warning" %}}
Redigera inte licensfilen. Även ett extra radbrytning kan ogiltigförklara dess digitala signatur.
{{% /alert %}}

Tillämpa licensen en gång per applikation eller process, innan du skapar presentationer eller utför andra Aspose.Slides‑operationer. För en licensfil, använd klassen [License](https://reference.aspose.com/slides/sv/python-java/aspose.slides/license/). Mätbaserad licensiering använder ett offentligt och privat nyckelpar istället för en licensfil.

## **Tillämpa en licens**

Följande exempel förutsätter att Aspose.Slides for Python via Java och dess förutsättningar är installerade. Varje exempel är ett fristående skript som startar JVM, importerar API:et och tillämpar en licens. I din applikation utför du dina presentationsoperationer efter att licensen har tillämpats och stänger ner JVM först när allt Aspose.Slides‑arbete är slutfört.

### **Tillämpa en licens från en fil**

Skicka licensfilens sökväg till [License.setLicense](https://reference.aspose.com/slides/sv/python-java/aspose.slides/license/#setLicense). Ersätt `Aspose.Slides.lic` med sökvägen till din licensfil.

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
        # Utför presentationsoperationer här, innan JVM stängs ner.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

Använd exakt filnamn, inklusive filändelsen. Till exempel, om filen heter `Aspose.Slides.lic.xml`, inkludera `.xml` i sökvägen. En absolut sökväg undviker tvetydighet kring applikationens arbetskatalog.

Exemplet använder [License.isLicensed](https://reference.aspose.com/slides/sv/python-java/aspose.slides/license/#isLicensed) för att kontrollera om licensen har tillämpats.

### **Tillämpa en licens från bytes**

Använd [License.setLicenseFromBytes](https://reference.aspose.com/slides/sv/python-java/aspose.slides/license/#setLicenseFromBytes) när licensen finns tillgänglig som Python‑byte. Följande exempel läser filen i binärt läge och stänger den innan licensen tillämpas.

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
        # Utför presentationsoperationer här, innan JVM stängs ner.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

Behåll de ursprungliga bytena oförändrade. Avkoda, omformatera eller på annat sätt modifiera inte licensinnehållet innan du tillämpar det.

## **Tillämpa en mätbaserad licens**

Mätbaserad licensiering debiterar dig enligt API‑användning. Efter att ha erhållit en mätlicens, tillämpa dess offentliga och privata nycklar med [Metered.setMeteredKey](https://reference.aspose.com/slides/sv/python-java/aspose.slides/metered/#setMeteredKey). Initiera [Metered](https://reference.aspose.com/slides/sv/python-java/aspose.slides/metered/)-objektet och tillämpa nycklarna en gång vid applikationens start.

Följande exempel läser nycklarna från miljövariablerna `ASPOSE_METERED_PUBLIC_KEY` och `ASPOSE_METERED_PRIVATE_KEY`. Ange båda variablerna innan du kör skriptet.

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
        # Utför presentationsoperationer här, innan JVM stängs ner.
    else:
        print("Set both metered licensing environment variables before running this example.")
finally:
    jpype.shutdownJVM()
```

{{% alert color="info" title="Note" %}}
Mätbaserad licensiering kräver en internetanslutning för att validera nycklarna och rapportera användning. håll den privata nyckeln utanför källkoden och loggar. Se [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered) för information om anslutning och fakturering.
{{% /alert %}}

## **FAQ**

**Behöver jag installera ett annat paket efter att ha köpt en licens?**

Nej. Tillämpa licensen på samma paket som du använde för utvärdering.

**Ska jag tillämpa en licens för varje presentation?**

Nej. Tillämpa den en gång under applikationens start, innan du skapar eller laddar presentationer.

**Kan jag byta namn på licensfilen?**

Ja. Använd det exakta nya filnamnet i din kod och behåll filens innehåll oförändrat.

**Kan jag använda en tillfällig licens med byte‑exemplet?**

Ja. Läs den tillfälliga licensfilen som byte och tillämpa den på samma sätt som en köpt licens.