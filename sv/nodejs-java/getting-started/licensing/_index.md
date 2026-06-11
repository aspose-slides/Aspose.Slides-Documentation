---
title: Licensiering
type: docs
weight: 80
url: /sv/nodejs-java/licensing/
keywords:
- licens
- tillfällig licens
- ange licens
- använd licens
- validera licens
- licensfil
- utvärderingsversion
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Applicera, hantera och felsöka licenser i Aspose.Slides för Node.js. Säkerställ oavbruten åtkomst till alla funktioner med vår steg-for-steg guide för licensiering."
---
## **Introduktion**

Ibland kan en praktisk metod behövas för att uppnå bästa utvärderingsresultat. Av den anledningen erbjuder Aspose.Slides olika köpalternativ samt en gratis provperiod och en 30‑dagars tillfällig licens för utvärdering.

{{% alert color="primary" %}}
Observera att det finns ett antal allmänna policys och praxis som guidar dig i hur du utvärderar, licensierar korrekt och köper våra produkter. Du kan hitta dem i avsnittet ["Köppolicys och FAQ"](https://purchase.aspose.com/policies).
{{% /alert %}}

## **Utvärdera Aspose.Slides**
Du kan enkelt ladda ner Aspose.Slides för utvärdering. Utvärderingspaketet är identiskt med det köpta paketet. Utvärderingsversionen blir licensierad så snart du lägger till några kodrader för att aktivera licensen. 

## **Begränsningar i utvärderingsversionen**
Utvärderingsversionen av Aspose.Slides (utan angiven licens) erbjuder hela produktens funktionalitet, men den placerar ett utvärderingsvattenstämpel högst upp i dokumentet vid öppning och sparning. Du är också begränsad till en bild när du extraherar text från presentationsbilder.

{{% alert color="primary" %}} 
Om du vill testa Aspose.Slides utan begränsningarna i utvärderingsversionen kan du begära en **30‑dagars tillfällig licens**. Se gärna [Hur får jag en tillfällig licens?](https://purchase.aspose.com/temporary-license) för mer information.
{{% /alert %}} 

## **Om licensen**
Du kan enkelt ladda ner en utvärderingsversion av Aspose.Slides för Node.js via Java från dess [nedladdningssida](https://releases.aspose.com/slides/sv/nodejs-java/). Utvärderingsversionen erbjuder exakt **samma funktioner** som den licensierade versionen av Aspose.Slides. Dessutom blir utvärderingsversionen licensierad så snart du köper en licens och lägger till ett par kodrader för att aktivera licensen.

Licensen är en ren-text XML‑fil som innehåller uppgifter såsom produktnamn, antal utvecklare den är licensierad för, abonnemangets utgångsdatum med mera. Filen är digitalt signerad, så den får inte ändras. Även ett oavsiktligt extra radbryt i filens innehåll gör den ogiltig.

För att undvika begränsningarna i utvärderingsversionen måste du ange en licens innan du använder **Aspose.Slides**. Du behöver bara ange licensen en gång per applikation eller process.

{{% alert color="primary" %}} 
Du kanske vill titta på [Metered Licensing](https://docs.aspose.com/slides/sv/nodejs-java/metered-licensing/).
{{% /alert %}} 

## **Köpt licens**

Efter köpet måste du tillämpa licensfilen eller strömmen. 

{{% alert color="primary" %}}
Du måste ange licensen:
* endast en gång per applikationsdomän
* innan du använder någon annan Aspose.Slides‑klass
{{% /alert %}}

{{% alert color="primary" %}}
Du kan hitta prisinformation på sidan [“Pricing Information”](https://purchase.aspose.com/pricing/slides/sv/family).
{{% /alert %}}

### **Ange en licens i Aspose.Slides för Node.js via Java**

Licenser kan tillämpas från följande platser:

* Explicit sökväg
* Ström
* Som en Metered‑licens – en ny licensieringsmekanism

{{% alert color="primary" %}}
Använd metoden **setLicense** för att licensiera en komponent.

Även om flera anrop av **setLicense** inte är skadliga, är de ett onödigt resursutnyttjande (processor).
{{% /alert %}}

{{% alert color="warning" %}}
Nya licenser kan endast aktivera Aspose.Slides med version 21.4 eller senare. Äldre versioner använder ett annat licenssystem och kommer inte att känna igen dessa licenser.
{{% /alert %}}

#### **Tillämpa en licens med en fil**

Denna kodsnutt används för att ange en licensfil:

**Node.js**

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var license = new aspose.slides.License();
license.setLicense("Aspose.Slides.lic");
```

När du anropar setLicense‑metoden ska licensnamnet vara detsamma som ditt licensfilnamn. Till exempel kan du byta licensfilens namn till "Aspose.Slides.lic.xml". Därefter måste du i din kod skicka det nya licensnamnet (Aspose.Slides.lic.xml) till setLicense‑metoden.

#### **Tillämpa en licens från en ström**

Denna kodsnutt används för att tillämpa en licens från en ström:

**Node.js**

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var license = new aspose.slides.License();

var fs = require("fs");

var readStream = fs.createReadStream("Aspose.Slides.lic");

license.setLicense(readStream, function(err, list) {
    if(err) { 
        console.error(err); return; 
    }});
```

## **Vanliga frågor**

**Kan jag tillämpa licensen i en helt offline-miljö (ingen internetåtkomst)?**

Ja. Licensvalidering sker lokalt med licensfilen; ingen internetanslutning krävs.

**Vad händer när ettårsprenumerationen löper ut? Slutar biblioteket att fungera?**

Nej. Licensen är evig: du kan fortsätta använda versioner som släppts innan ditt abonnemangs slutdatum; du får dock inte använda nyare versioner utan att förnya.