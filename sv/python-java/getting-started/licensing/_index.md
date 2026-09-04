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
- meterad licensiering
- utvärderingsbegränsningar
description: "Applicera en licens från fil, byte-baserad eller meterad i Aspose.Slides för Python via Java och ta bort utvärderingsbegränsningar från dina applikationer."
---
## **Översikt**

Aspose.Slides för Python via Java kan köras i utvärderingsläge eller med en licens. Den här artikeln förklarar hur du applicerar en licens från en fil eller bytes och hur du konfigurerar meterad licensiering.

För köpalternativ, se [Pricing Information](https://purchase.aspose.com/pricing/slides/sv/family). För allmänna licens- och köpprocessfrågor, se [Purchase Policies and FAQ](https://purchase.aspose.com/policies).

För begränsningar i utvärderingsläget och hur du begär en tillfällig licens, se [Evaluate Aspose.Slides](/slides/sv/python-java/evaluate-aspose-slides/). Applicera en tillfällig licens på samma sätt som en köpt licensfil.

## **Om licensen**

En licensfil innehåller information som produktnamn, antalet licensierade utvecklare och prenumerationens utgångsdatum. Filen är digitalt signerad XML.

{{% alert color="warning" title="Warning" %}}

Redigera inte licensfilen. Även ett extra radbryt kan ogiltigförklara dess digitala signatur.

{{% /alert %}}

Applicera licensen en gång per applikation eller process, innan du skapar presentationer eller utför andra Aspose.Slides‑operationer. För en licensfil, använd klassen [License](https://reference.aspose.com/slides/sv/python-java/aspose.slides/license/) . Meterad licensiering använder ett offentligt och privat nyckelpar istället för en licensfil.

## **Applicera en licens**

Följande exempel förutsätter att Aspose.Slides för Python via Java och dess förutsättningar är installerade. Varje exempel är ett fristående skript som startar JVM, importerar API:et och applicerar en licens. I din applikation, utför dina presentationsoperationer efter att licensen har applicerats och stäng ner JVM först när allt Aspose.Slides‑arbete är slutfört.

### **Applicera en licens från en fil**

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
        # Utför presentationsoperationer här, innan JVM stängs av.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

Använd exakt filnamn, inklusive filändelsen. Till exempel, om filen heter `Aspose.Slides.lic.xml`, inkludera `.xml` i sökvägen. En absolut sökväg undviker tvetydighet om applikationens arbetskatalog.

Exemplet använder [License.isLicensed](https://reference.aspose.com/slides/sv/python-java/aspose.slides/license/#isLicensed) för att kontrollera om licensen har applicerats.

### **Applicera en licens från bytes**

Använd [License.setLicenseFromBytes](https://reference.aspose.com/slides/sv/python-java/aspose.slides/license/#setLicenseFromBytes) när licensen finns som Python‑bytes. Följande exempel läser filen i binärt läge och stänger den innan licensen appliceras.

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
        # Utför presentationsoperationer här, innan JVM stängs av.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

Behåll de ursprungliga bytena oförändrade. Avkoda, formatera om eller på annat sätt ändra inte licensinnehållet innan du applicerar det.

## **Applicera en meterad licens**

Meterad licensiering debiterar dig enligt API‑användning. Efter att ha erhållit en meterad licens, applicera dess offentliga och privata nycklar med [Metered.setMeteredKey](https://reference.aspose.com/slides/sv/python-java/aspose.slides/metered/#setMeteredKey). Initiera [Metered](https://reference.aspose.com/slides/sv/python-java/aspose.slides/metered/)‑objektet och applicera nycklarna en gång vid applikationsstart.

Följande exempel läser nycklarna från miljövariablerna `ASPOSE_METERED_PUBLIC_KEY` och `ASPOSE_METERED_PRIVATE_KEY`. Sätt båda variablerna innan du kör skriptet.

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
        # Utför presentationsoperationer här, innan JVM stängs av.
    else:
        print("Set both metered licensing environment variables before running this example.")
finally:
    jpype.shutdownJVM()
```

{{% alert color="info" title="Note" %}}

Meterad licensiering kräver en internetanslutning för att validera nycklarna och rapportera användning. Håll den privata nyckeln utanför källkoden och loggarna. Se [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered) för detaljer om anslutning och fakturering.

{{% /alert %}}

## **Vanliga frågor**

**Behöver jag installera ett annat paket efter att ha köpt en licens?**

Nej. Applicera licensen på samma paket som du använde för utvärdering.

**Ska jag applicera en licens för varje presentation?**

Nej. Applicera den en gång vid applikationsstart, innan du skapar eller laddar presentationer.

**Kan jag byta namn på licensfilen?**

Ja. Använd det exakta nya filnamnet i din kod och håll filinnehållet oförändrat.

**Kan jag använda en tillfällig licens med byte‑baserat exempel?**

Ja. Läs den tillfälliga licensfilen som bytes och applicera den på samma sätt som en köpt licens.