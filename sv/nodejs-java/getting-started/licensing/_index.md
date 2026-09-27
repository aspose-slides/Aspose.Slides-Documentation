---
title: Licensiering
type: docs
weight: 80
url: /sv/nodejs-java/licensing/
keywords:
- licens
- temporär licens
- ange licens
- använda licens
- validera licens
- licensfil
- utvärderingsversion
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Applicera, hantera och felsöka licenser i Aspose.Slides för Node.js. Säkerställ oavbruten åtkomst till alla funktioner med vår steg-för-steg-licensguide."
---
## **Introduktion**

Ibland kan en praktisk metod behövas för att uppnå bästa utvärderingsresultat. Av den anledningen erbjuder Aspose.Slides olika köpalternativ samt en gratis provperiod och en 30‑dagars temporär licens för utvärdering.

{{% alert color="info" title="Note" %}}
Observera att det finns ett antal allmänna policyer och praxis som vägleder dig kring hur du utvärderar, licensierar korrekt och köper våra produkter. Du kan hitta dem i avsnittet ["Köppolicyer och FAQ"](https://purchase.aspose.com/policies).
{{% /alert %}}

## **Utvärdera Aspose.Slides**
Du kan enkelt ladda ner Aspose.Slides för utvärdering. Utvärderingspaketet är detsamma som det köpta paketet. Utvärderingsversionen blir helt enkelt licensierad efter att du har lagt till några kodrader för att applicera licensen. 

## **Begränsningar i utvärderingsversionen**
Utvärderingsversionen av Aspose.Slides (utan specificerad licens) erbjuder hela produktens funktionalitet, med två begränsningar:

* Den lägger till en utvärderingsvattenstämpel textbox på varje bild i varje presentation den sparar.
* Text som är längre än fem tecken som din kod läser från en presentation trunkeras till de första fem tecknen, följt av `... text has been truncated due to evaluation version limitation.` Text med fem tecken eller färre returneras oförändrad, och text som din kod skriver sparas i sin helhet.

{{% alert color="info" title="Note" %}}
Om du vill testa Aspose.Slides utan begränsningarna i utvärderingsversionen kan du begära en **30‑dagars temporär licens**. Se [Hur får man en temporär licens?](https://purchase.aspose.com/temporary-license) för mer information.
{{% /alert %}}

## **Om licensen**
Du kan enkelt ladda ner en utvärderingsversion av Aspose.Slides för Node.js via Java från dess [nedladdningssida](https://releases.aspose.com/slides/nodejs-java/). Utvärderingsversionen har samma funktioner som den licensierade versionen, med begränsningarna beskrivna ovan. Dessutom blir utvärderingsversionen licensierad efter att du köpt en licens och lagt till några kodrader för att applicera licensen.

Licensen är en klartext‑XML‑fil som innehåller detaljer såsom produktnamn, antal utvecklare den är licensierad för, prenumerationsutgångsdatum med mera. Filen är digitalt signerad, så ändra inte filen. Även ett oavsiktligt extra radbrytning i filens innehåll gör den ogiltig.

För att undvika begränsningarna som är förknippade med utvärderingsversionen måste du ange en licens innan du använder **Aspose.Slides**. Du behöver bara ange licensen en gång per applikation eller process.

{{% alert color="info" title="Note" %}}
Du kanske vill se [Metered Licensing](/slides/sv/nodejs-java/metered-licensing/).
{{% /alert %}}

## **Köpt licens**
Efter köp måste du applicera licensfilen eller strömmen. 

{{% alert color="info" title="Note" %}}
Du måste ange licensen:
* endast en gång per process
* innan du använder någon annan Aspose.Slides‑klass
{{% /alert %}}

{{% alert color="info" title="Note" %}}
Du kan hitta prisinformation på sidan ["Prisuppgifter"](https://purchase.aspose.com/pricing/slides/family).
{{% /alert %}}

### **Inställning av licens i Aspose.Slides för Node.js via Java**
Licenser kan appliceras från följande platser:

* Explicit sökväg
* Ström
* Som en Metered License – en ny licensmekanism

{{% alert color="info" title="Note" %}}
Använd metoden **setLicense** för att licensiera en komponent.

Även om flera anrop till **setLicense** inte är skadliga, är de ett slöseri med resurser (processor).
{{% /alert %}}

#### **Applicera en licens med en fil**
Det här kodsnutten används för att ange en licensfil:

**Node.js**

```javascript
const asposeSlides = require("aspose.slides.via.java");

const license = new asposeSlides.License();
license.setLicense("Aspose.Slides.lic");
console.log("The license was applied.");

// Aspose.Slides körs i en Java-virtuell maskin som håller Node.js igång, så avsluta processen explicit.
process.exit(0);
```

När du anropar setLicense‑metoden ska licensnamnet vara detsamma som ditt licensfilnamn. Till exempel kan du ändra licensfilens namn till "Aspose.Slides.lic.xml". Därefter måste du i din kod skicka det nya licensnamnet (Aspose.Slides.lic.xml) till setLicense‑metoden. Om filen saknas eller inte innehåller en giltig licens, kastar [setLicense](https://reference.aspose.com/slides/nodejs-java/aspose.slides/license/setlicense/) ett undantag som avslutar skriptet med ett fel.

#### **Applicera en licens från en ström**
För att applicera en licens från en ström, skicka [License](https://reference.aspose.com/slides/nodejs-java/aspose.slides/license/)‑objektet och en läsbar ström till den statiska metoden [setLicenseFromStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/license/setlicense/). Strömmen läses asynkront, och callbacken får ett fel om strömmen inte innehåller en giltig licens:

**Node.js**

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");

const license = new asposeSlides.License();
const readStream = fs.createReadStream("Aspose.Slides.lic");
asposeSlides.License.setLicenseFromStream(license, readStream, function (error) {
    if (error) {
        console.error("The license was not applied:", error.message);
    } else {
        console.log("The license was applied.");
    }

    // Aspose.Slides körs i en Java-virtuell maskin som håller Node.js igång, så avsluta processen explicit.
    process.exit(0);
});
```

Licensen appliceras när hela strömmen har lästs, precis innan callbacken körs, så starta annat Aspose.Slides‑arbete från callbacken.

Båda exemplen anropar `process.exit(0)` när de är färdiga, eftersom Java‑virtuell maskin som kör Aspose.Slides håller Node.js igång. I en applikation fortsätt med din Aspose.Slides‑kod i stället för att avsluta processen.

## **FAQ**

### Kan jag applicera licensen i en helt offline-miljö (ingen internetåtkomst)?
Ja. Licensvalidering utförs lokalt med licensfilen; ingen internetanslutning krävs.

### Vad händer när ettårsabonnemanget löper ut? Kommer biblioteket att sluta fungera?
Nej. Licensen är evig: du kan fortsätta använda versioner som släppts innan ditt abonnemangs slutdatum; du kommer bara inte att vara behörig att använda nyare releaser utan förnyelse.