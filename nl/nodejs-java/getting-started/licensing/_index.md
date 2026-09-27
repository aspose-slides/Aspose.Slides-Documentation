---
title: Licenties
type: docs
weight: 80
url: /nl/nodejs-java/licensing/
keywords:
- licentie
- tijdelijke licentie
- licentie instellen
- licentie gebruiken
- licentie valideren
- licentiebestand
- evaluatieversie
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Licenties toepassen, beheren en problemen oplossen in Aspose.Slides voor Node.js. Zorg voor ononderbroken toegang tot alle functionaliteiten met onze stapsgewijze handleiding voor licentiëring."
---
## **Introductie**

Soms is voor de beste evaluatieresultaten een hands‑on aanpak nodig. Om die reden biedt Aspose.Slides verschillende aankoopplannen en ook een gratis proefversie en een tijdelijke licentie van 30 dagen voor evaluatie.

{{% alert color="info" title="Note" %}}
Let op dat er een aantal algemene beleidsregels en praktijken zijn die u begeleiden bij het evalueren, correct licenseren en aankopen van onze producten. U kunt ze vinden in de [Aankoopbeleid en FAQ](https://purchase.aspose.com/policies) sectie.
{{% /alert %}}

## **Evalueren Aspose.Slides**
U kunt eenvoudig Aspose.Slides downloaden voor evaluatie. Het evaluatie‑pakket is identiek aan het gekochte pakket. De evaluatieversie wordt gewoon een gelicentieerde versie zodra u een paar regels code toevoegt om de licentie toe te passen.

## **Beperking van de evaluatieversie**
De evaluatieversie van Aspose.Slides (zonder opgegeven licentie) biedt de volledige functionaliteit van het product, met twee beperkingen:

* Het voegt een evaluatiewatermerk‑tekstvak toe aan elke dia van elke presentatie die het opslaat.
* Tekst langer dan vijf tekens die uw code uit een presentatie leest, wordt afgekapt tot de eerste vijf tekens, gevolgd door `... text has been truncated due to evaluation version limitation.` Tekst van vijf tekens of minder wordt ongewijzigd geretourneerd, en tekst die uw code schrijft, wordt volledig opgeslagen.

{{% alert color="info" title="Note" %}}
Als u Aspose.Slides wilt testen zonder de beperkingen van de evaluatieversie, kunt u een **30 Day Temporary License** aanvragen. Raadpleeg [Hoe vraag ik een tijdelijke licentie aan?](https://purchase.aspose.com/temporary-license) voor meer informatie.
{{% /alert %}}

## **Over de licentie**
U kunt eenvoudig een evaluatieversie van Aspose.Slides voor Node.js via Java downloaden vanaf de [downloadpagina](https://releases.aspose.com/slides/nodejs-java/). De evaluatieversie heeft dezelfde functionaliteit als de gelicentieerde versie, met de hierboven beschreven beperkingen. Bovendien wordt de evaluatieversie gewoon gelicentieerd zodra u een licentie aanschaft en een paar regels code toevoegt om de licentie toe te passen.

De licentie is een platte‑tekst XML‑bestand dat details bevat zoals de productnaam, het aantal ontwikkelaars waarvoor het gelicentieerd is, de vervaldatum van het abonnement, enzovoort. Het bestand is digitaal ondertekend, dus wijzig het bestand niet. Zelfs een onbedoelde extra regeleinde in de inhoud van het bestand maakt het ongeldig.

Om de beperkingen van de evaluatieversie te vermijden, moet u een licentie instellen voordat u **Aspose.Slides** gebruikt. U hoeft de licentie slechts één keer per applicatie of proces in te stellen.

{{% alert color="info" title="Note" %}}
U wilt misschien [Metered Licensing](/slides/nl/nodejs-java/metered-licensing/) zien.
{{% /alert %}}

## **Aangeschafte licentie**
Na aankoop moet u het licentiebestand of de stream toepassen.

{{% alert color="info" title="Note" %}}
U moet de licentie instellen:
* slechts één keer per proces
* voordat u andere Aspose.Slides‑klassen gebruikt
{{% /alert %}}

{{% alert color="info" title="Note" %}}
U kunt prijsinformatie vinden op de [Prijzinformatie](https://purchase.aspose.com/pricing/slides/family) pagina.
{{% /alert %}}

### **Instellen van een licentie in Aspose.Slides voor Node.js via Java**
Licenties kunnen worden toegepast vanaf de volgende locaties:

* Expliciet pad
* Stream
* Als een Metered License – een nieuw licentiemechanisme

{{% alert color="info" title="Note" %}}
Gebruik de **setLicense**‑methode om een component te licenseren.

Hoewel meerdere oproepen naar **setLicense** niet schadelijk zijn, vormen ze wel een verspilling van resources (processor).
{{% /alert %}}

#### **Licentie toepassen met een bestand**
Dit codefragment wordt gebruikt om een licentiebestand in te stellen:

**Node.js**

```javascript
const asposeSlides = require("aspose.slides.via.java");

const license = new asposeSlides.License();
license.setLicense("Aspose.Slides.lic");
console.log("The license was applied.");

// Aspose.Slides draait in een Java virtual machine die Node.js actief houdt, dus beëindig het proces expliciet.
process.exit(0);
```

Bij het aanroepen van de setLicense‑methode moet de licentienaam gelijk zijn aan die van uw licentiebestand. U kunt bijvoorbeeld de bestandsnaam van het licentiebestand wijzigen in "Aspose.Slides.lic.xml". Vervolgens moet u in uw code de nieuwe licentienaam (Aspose.Slides.lic.xml) doorgeven aan de setLicense‑methode. Als het bestand ontbreekt of geen geldige licentie bevat, werpt [setLicense](https://reference.aspose.com/slides/nodejs-java/aspose.slides/license/setlicense/) een uitzondering die het script met een fout beëindigt.

#### **Licentie toepassen vanuit een stream**
Om een licentie vanuit een stream toe te passen, geeft u het [License](https://reference.aspose.com/slides/nodejs-java/aspose.slides/license/)‑object en een leesbare stream door aan de statische [setLicenseFromStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/license/setlicense/)‑methode. De stream wordt asynchroon gelezen, en de callback ontvangt een fout als de stream geen geldige licentie bevat:

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

    // Aspose.Slides draait in een Java virtual machine die Node.js actief houdt, dus beëindig het proces expliciet.
    process.exit(0);
});
```

De licentie wordt toegepast zodra de volledige stream is gelezen, net voordat de callback wordt uitgevoerd, dus start ander Aspose.Slides‑werk vanaf de callback.

Beide voorbeelden roepen `process.exit(0)` aan wanneer ze klaar zijn, omdat de Java‑virtual‑machine die Aspose.Slides uitvoert Node.js actief houdt. In een applicatie gaat u door met uw Aspose.Slides‑code in plaats van het proces te beëindigen.

## **FAQ**

### Kan ik de licentie toepassen in een volledig offline omgeving (geen internettoegang)?
Ja. Licentievalidatie wordt lokaal uitgevoerd met behulp van het licentiebestand; er is geen internetverbinding vereist.

### Wat gebeurt er nadat het eenjarig abonnement verloopt? Zal de bibliotheek stoppen met werken?
Nee. De licentie is eeuwigdurend: u kunt blijven werken met versies die vóór de einddatum van uw abonnement zijn uitgebracht; u kunt echter geen nieuwere releases gebruiken zonder te verlengen.