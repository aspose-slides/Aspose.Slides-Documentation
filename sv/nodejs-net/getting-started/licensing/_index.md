---
title: Licensiering
description: "Aspose.Slides för Node.js via .NET erbjuder olika köpalternativ eller en gratis provperiod och en 30-dagars temporär licens för utvärdering enligt licens- och prenumerationspolicyer."
type: docs
weight: 80
url: /sv/nodejs-net/licensing/
---
Ibland kan ett praktiskt tillvägagångssätt behövas för att uppnå de bästa utvärderingsresultaten. Av den anledningen erbjuder Aspose.Slides olika köpalternativ samt en gratis provperiod och en 30‑dagars temporär licens för utvärdering.

{{% alert color="primary" %}}

Observera att det finns ett antal generella policies och rutiner som guidar dig i hur du utvärderar, licensierar korrekt och köper våra produkter. Du hittar dem i sektionen ["Köppolicyer och FAQ"](https://purchase.aspose.com/policies).

{{% /alert %}}

## **Utvärdera Aspose.Slides**
Du kan enkelt ladda ner Aspose.Slides för utvärdering. Utvärderingspaketet är detsamma som det köpta paketet. Utvärderingsversionen blir licensierad så snart du lägger till några kodrader för att applicera licensen. 

## **Begränsning i utvärderingsversionen**
Utvärderingsversionen av Aspose.Slides (utan specificerad licens) erbjuder hela produktens funktionalitet, men den infogar ett utvärderingsvattenstämpel högst upp i dokumentet vid öppning och sparning. Du är också begränsad till en bild när du extraherar text från presentationsbilder.

{{% alert color="primary" %}} 

Om du vill testa Aspose.Slides utan begränsningarna i utvärderingsversionen kan du begära en **30‑dagars temporär licens**. Se [Hur får jag en temporär licens?](https://purchase.aspose.com/temporary-license) för mer information.

{{% /alert %}} 

## **Om licensen**
Du kan enkelt ladda ner en utvärderingsversion av Aspose.Slides för Node.js via .NET från dess [nedladdningssida](https://releases.aspose.com/slides/sv/nodejs-net/). Utvärderingsversionen erbjuder absolut **samma funktioner** som den licensierade versionen av Aspose.Slides. Dessutom blir utvärderingsversionen licensierad så snart du köper en licens och lägger till ett par kodrader för att applicera licensen.

Licensen är en rentext‑XML‑fil som innehåller detaljer såsom produktnamn, antal utvecklare den är licensierad för, prenumerationsutgångsdatum med mera. Filen är digitalt signerad, så ändra inte filen. Även ett oavsiktligt extra radbryt i filens innehåll gör den ogiltig.

För att undvika begränsningarna som är förknippade med utvärderingsversionen måste du sätta en licens innan du använder **Aspose.Slides**. Du behöver bara sätta licensen en gång per applikation eller process.

## Purchased License

Efter köp måste du applicera licensfilen eller strömmen. 

{{% alert color="primary" %}}

Du måste sätta licensen:
* endast en gång per applikationsdomän
* innan du använder några andra Aspose.Slides‑klasser

{{% /alert %}}

{{% alert color="primary" %}}

Du hittar prisinformation på sidan [“Pricing Information”](https://purchase.aspose.com/pricing/slides/sv/family).

{{% /alert %}}

### **Ställa in en licens i Aspose.Slides för Node.js via .NET**

Licenser kan appliceras från följande platser:

* Explicit sökväg
* Ström
* Som en Metered‑licens – en ny licensieringsmekanism

{{% alert color="primary" %}}

Använd **setLicense**‑metoden för att licensiera en komponent.

Även om flera anrop till **setLicense** inte är skadliga är de en resursslöseri (processor).

{{% /alert %}}

{{% alert color="warning" %}}

Nya licenser kan aktivera Aspose.Slides endast med version 21.4 eller senare. Tidigare versioner använder ett annat licenssystem och känner inte igen dessa licenser.

{{% /alert %}}

#### **Applicera en licens med en fil**

Detta kodexempel används för att sätta en licensfil:

**Node.js**

```javascript
// Importera Aspose.Slides-modulen för PowerPoint-filhantering
const asposeSlides = require('aspose.slides.via.net');

// Denna funktion konfigurerar Aspose.Slides-biblioteket med en licens
function setupAsposeSlidesLicense() {
	
    // Initiera License-klassen från Aspose.Slides-modulen
    var license = new asposeSlides.License();
    
    // Applicera licensen från en fil
    // Ersätt "your_license_file.lic" med sökvägen till din faktiska licensfil
    license.setLicense("your_license_file.lic");
}

// Kör funktionen för att konfigurera licensen för Aspose.Slides
setupAsposeSlidesLicense();
```
{{% alert color="primary" %}}

När du anropar setLicense‑metoden ska licensnamnet vara samma som ditt licensfilnamn. Till exempel kan du ändra licensfilens namn till "Aspose.Slides.lic.xml". Därefter måste du i koden skicka det nya licensnamnet (Aspose.Slides.lic.xml) till setLicense‑metoden.

{{% /alert %}}