---
title: Licenties
description: "Pas een licentiebestand toe op Aspose.Slides voor Node.js via .NET, bekijk de beperkingen van de evaluatieversie, en verkrijg een gratis tijdelijke licentie van 30 dagen voor testdoeleinden."
type: docs
weight: 80
url: /nl/nodejs-net/licensing/
---
## **Overzicht**

Aspose.Slides for Node.js via .NET is één npm‑pakket voor zowel evaluatie als productie. Zonder licentie draait het in evaluatiemodus. Nadat u een licentie hebt gekocht, of een gratis tijdelijke licentie van 30 dagen hebt verkregen, past u deze toe met een paar regels code, en gelden de evaluatiebeperkingen niet meer.

{{% alert color="info" title="Note" %}}
Algemene richtlijnen over hoe u Aspose‑producten kunt evalueren, licenseren en aanschaffen, vindt u in [Purchase Policies and FAQ](https://purchase.aspose.com/policies). De prijzen staan vermeld op de pagina [Pricing Information](https://purchase.aspose.com/pricing/slides/nl/family).
{{% /alert %}}

## **Beperkingen van de evaluatieversie**

De evaluatieversie biedt de volledige functionaliteit van het product, met twee beperkingen:

- **Watermerk.** Elke dia van elke presentatie die u opslaat krijgt een evaluatiewatermerk: een vergrendeld tekstvak in het midden van de dia met de tekst "Evaluation only." Hetzelfde watermerk wordt toegepast op PDF-, XPS- en HTML‑exporten en op dia‑afbeeldingen.
- **Afgekapt tekst.** Tekst die uw code terugleest uit een tekstframe, alinea of deel wordt teruggebracht tot de eerste vijf tekens, gevolgd door de melding "... text has been truncated due to evaluation version limitation." Markdown‑ en HTML5‑exporten worden op dezelfde manier afgekapt. De tekst die uw code schrijft, wordt volledig opgeslagen.

[Evaluate Aspose.Slides](/slides/nl/nodejs-net/evaluate-aspose-slides/) beschrijft beide beperkingen in detail en bevat een script dat ze laat zien.

{{% alert color="success" title="Tip" %}}
Om Aspose.Slides te testen zonder de evaluatiebeperkingen, vraag een gratis **30‑daagse tijdelijke licentie** aan. Zie [How to get a Temporary License?](https://purchase.aspose.com/temporary-license) voor meer details.
{{% /alert %}}

## **Over de licentie**

De licentie is een platte‑tekst XML‑bestand dat gegevens bevat zoals de productnaam, het aantal ontwikkelaars waarvoor het is gelicentieerd, en de vervaldatum van het abonnement. Het bestand is digitaal ondertekend, dus wijzig het niet: zelfs een extra regeleinde dat per ongeluk wordt toegevoegd maakt het ongeldig.

## **Licentie toepassen**

Pas de licentie toe met de `setLicense`‑methode van de `License`‑klasse. Roep deze één keer per proces aan, voordat u een `Presentation`‑object maakt. Een tweede oproep schaadt niets, maar leidt tot dubbel werk.

Het volgende script past een licentie toe vanuit een bestand met de naam `Aspose.Slides.lic`. Vervang de naam door de naam of het volledige pad van uw licentiebestand; het bestand mag elke willekeurige naam hebben.

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { License } = asposeSlides;

const license = new License();
try {
    license.setLicense("Aspose.Slides.lic");
    console.log("License applied.");
} catch (error) {
    console.log("License not applied:", error.message);
}
```

Een bestandsnaam of relatieve pad wordt opgezocht ten opzichte van de huidige map, de map van waaruit u `node` uitvoert. Bewaar het licentiebestand in uw projectmap en voer uw scripts vanaf daar uit, of geef het volledige pad op.

Als het bestand niet gevonden kan worden, of geen geldige licentie is, genereert `setLicense` een fout, en blijft Aspose.Slides in evaluatiemodus. Het script vangt de fout op en geeft het bijbehorende bericht weer. Bij een ontbrekend bestand begint het bericht met `License "Aspose.Slides.lic" doesn't exist or access is restricted.` en somt het elke locatie op die werd doorzocht.

In dit pakket wordt een licentie uitsluitend vanuit een bestand toegepast. `License` accepteert geen stream, en het pakket biedt geen meter‑licensering aan. Voor de klasse die het pakket omsluit, zie [License](https://reference.aspose.com/slides/nl/net/aspose.slides/license/) in de Aspose.Slides for .NET API‑referentie.