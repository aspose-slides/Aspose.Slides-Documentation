---
title: Licensiering
description: "Aspose.Slides för Python via Java erbjuder olika inköpsplaner eller en gratis provperiod och en 30-dagars tillfällig licens för utvärdering enligt licens- och prenumerationspolicyer."
type: docs
weight: 80
url: /sv/python-java/licensing/
---
Ibland kan en praktisk metod behövas för att uppnå de bästa utvärderingsresultaten. Av den anledningen erbjuder Aspose.Slides olika inköpsplaner samt en gratis provperiod och en 30-dagars tillfällig licens för utvärdering.

{{% alert color="primary" %}}
Observera att det finns ett antal allmänna policys och rutiner som guidar dig i hur du utvärderar, licensierar korrekt och köper våra produkter. Du kan hitta dem i avsnittet ["Inköpspolicyer och FAQ"](https://purchase.aspose.com/policies) .
{{% /alert %}}

## **Utvärdera Aspose.Slides**
Du kan enkelt ladda ner Aspose.Slides för utvärdering. Utvärderingspaketet är detsamma som det köpta paketet. Utvärderingsversionen blir helt enkelt licensierad när du lägger till några rader kod för att tillämpa licensen. 

## **Begränsning i utvärderingsversionen**
Utvärderingsversionen av Aspose.Slides (utan angiven licens) ger full produktfunktionalitet, men den lägger in ett utvärderingsvattenstämpel överst i dokumentet vid öppning och sparning. Du är också begränsad till en bild när du extraherar text från presentationsbilder.

{{% alert color="primary" %}} 
Om du vill testa Aspose.Slides utan begränsningarna i utvärderingsversionen kan du begära en **30‑dagars tillfällig licens**. Se [Hur får man en tillfällig licens?](https://purchase.aspose.com/temporary-license) för mer information.
{{% /alert %}} 

## **Om licensen**
Du kan enkelt ladda ner en utvärderingsversion av Aspose.Slides för Python via Java från dess [nedladdningssida](https://releases.aspose.com/slides/sv/python-java/). Utvärderingsversionen erbjuder absolut **samma funktioner** som den licensierade versionen av Aspose.Slides. Dessutom blir utvärderingsversionen helt enkelt licensierad när du köper en licens och lägger till ett par kodrader för att tillämpa licensen.

Licensen är en rentext‑XML‑fil som innehåller detaljer som produktnamn, antal utvecklare som den är licensierad för, prenumerationsutgångsdatum osv. Filen är digitalt signerad, så ändra den inte. Även ett oavsiktligt tillägg av ett extra radbrytning i filens innehåll kommer att göra den ogiltig.

För att undvika begränsningarna i samband med utvärderingsversionen måste du ange en licens innan du använder **Aspose.Slides**. Du behöver bara ange en licens en gång per applikation eller process.

## Köpt licens
Efter köp måste du tillämpa licensfilen eller strömmen. 

{{% alert color="primary" %}}
Du måste ange licensen:
* endast en gång per applikationsdomän
* innan du använder några andra Aspose.Slides‑klasser
{{% /alert %}}

{{% alert color="primary" %}}
Du kan hitta prisinformation på sidan ["Pricing Information"](https://purchase.aspose.com/pricing/slides/sv/family).
{{% /alert %}}

### **Ställa in en licens i Aspose.Slides för Python via Java**
Licenser kan tillämpas från följande platser:

* Explicit sökväg
* Ström
* Som en Metered-licens – en ny licensieringsmekanism

{{% alert color="primary" %}}
Använd **setLicense**‑metoden för att licensiera en komponent.

Även om flera anrop till **setLicense** inte är skadliga, är de ett slöseri med resurser (processor).
{{% /alert %}}

{{% alert color="warning" %}}
Nya licenser kan aktivera Aspose.Slides endast med version 21.4 eller senare. Tidigare versioner använder ett annat licenssystem och kommer inte att känna igen dessa licenser.
{{% /alert %}}

#### **Tillämpa en licens med en fil**
Denna kodsnutt används för att ange en licensfil:

**Python**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, License

license = License();
pres = Presentation()
license.setLicense("Aspose.Slides.lic");

jpype.shutdownJVM()
```

När du anropar setLicense‑metoden ska licensnamnet vara samma som ditt licensfilnamn. Till exempel kan du ändra licensfilens namn till "Aspose.Slides.lic.xml". Därefter måste du i din kod skicka det nya licensnamnet (Aspose.Slides.lic.xml) till setLicense‑metoden.

#### **Tillämpa en licens från bytes**
Denna kodsnutt används för att tillämpa en licens från bytes:

**Python**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, License

license = License();
input = open("Aspose.Slides.lic", mode="rb")
data = input.read()
pres = Presentation()
license.setLicenseFromBytes(data);

jpype.shutdownJVM()
```

#### Tillämpa Metered-licens
Aspose.Slides låter utvecklare tillämpa en metered‑nyckel. Detta är en ny licensieringsmekanism.

Den nya licensieringsmekanismen kommer att användas tillsammans med den befintliga licensmetoden. Kunder som vill faktureras baserat på användningen av API‑funktioner kan använda Metered‑licensiering.

Efter att ha genomfört alla nödvändiga steg för att erhålla denna licenstyp får du nycklarna, inte licensfilen. Denna metered‑nyckel kan tillämpas med hjälp av **Metered**‑klassen som speciellt införts för detta ändamål.

Följande kodexempel visar hur du anger offentliga och privata metered‑nycklar:

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, Metered, SaveFormat

# Skapa en instans av CAD Metered-klassen
metered = Metered();

# Använd set_metered_key-egenskapen och skicka offentliga och privata nycklar som parametrar
metered.setMeteredKey("*****", "*****");

# Hämta mängden metered data innan API-anrop
amountbefore = Metered.getConsumptionQuantity()

# Visa information
print("Amount Consumed Before: \" + amountbefore + \"" )

# Läs in dokumentet från disk.
pres = Presentation();

# Hämta sidantalet i dokumentet
print("Amount Consumed After: \" +  pres.getSlides().size()) + \"" )

# Spara som PDF
pres.save("out_pdf.pdf", SaveFormat.Pdf);

# Hämta mängden metered data efter API-anrop
amountafter = Metered.getConsumptionQuantity()

# Visa information
print("Amount Consumed After: \" + amountafter + \"" )

jpype.shutdownJVM()
```

{{% alert color="primary" %}}
Observera att du måste ha en stabil internetanslutning för korrekt användning av Metered‑licensen, eftersom Metered‑mekanismen kräver konstant interaktion med våra tjänster för korrekta beräkningar. För mer information, se avsnittet ["Metered Licensing FAQ"](https://purchase.aspose.com/faqs/licensing/metered).
{{% /alert %}}