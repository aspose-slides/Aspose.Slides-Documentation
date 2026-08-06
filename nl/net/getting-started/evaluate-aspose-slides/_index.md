---
title: Evalueer Aspose.Slides
type: docs
weight: 120
url: /nl/net/evaluate-aspose-slides/
keywords:
- evalueer Aspose.Slides
- Aspose.Slides evaluatie
- evaluatieversie
- volledige functionaliteit
- evaluatiewatermerk
- Aspose.Slides aanschaffen
- beperking
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Evalueer Aspose.Slides voor .NET en ontdek API-functies voor PowerPoint (PPT, PPTX) en OpenDocument (ODP) presentaties — start uw gratis proefversie."
---
## **Aspose.Slides Evaluatie**

U kunt eenvoudig Aspose.Slides downloaden voor evaluatie. Het evaluatie‑pakket is hetzelfde als het gekochte pakket. De evaluatieversie wordt gewoonlijk gelicenseerd zodra u enkele regels code toevoegt om de licentie toe te passen. 

De evaluatieversie van Aspose.Slides (zonder opgegeven licentie) biedt de volledige functionaliteit van het product, maar voegt een evaluatiewatermerk toe aan de bovenkant van het document bij openen en opslaan. Bovendien bent u beperkt tot één dia bij het extraheren van tekst uit presentatiedia’s.


![todo:image_alt_text](evaluate-aspose-slides_1.png)

{{% alert color="primary" %}} 
Als u Aspose.Slides wilt testen zonder de beperkingen van de evaluatieversie, kunt u een **30‑daagse tijdelijke licentie** aanvragen. Raadpleeg [Hoe vraag je een tijdelijke licentie aan?](https://purchase.aspose.com/temporary-license) voor meer informatie.
{{% /alert %}}

## **Installeer het evaluatiepakket**

```bash
dotnet add package Aspose.Slides.NET
```

## **Licentie toepassen**

Dit zijn de “enkele regels code” die het evaluatiepakket omzetten in een gelicentieerde versie. Pas de licentie één keer toe bij het opstarten van de applicatie, vóórdat een `Presentation`‑object wordt aangemaakt — een eerder geconstrueerde presentatie behoudt het evaluatiewatermerk.

```csharp
using Aspose.Slides;

var license = new License();
license.SetLicense("Aspose.Slides.NET.lic");
```

`SetLicense` accepteert ook een `Stream`, wat de betere optie is wanneer de licentie als een ingebedde bron wordt meegeleverd in plaats van als een bestand op de schijf. Als het pad onjuist is of het bestand is verlopen, wordt er een uitzondering gegooid, zodat fouten direct bij het opstarten zichtbaar zijn in plaats van stilletjes terug te vallen op de evaluatiemodus.

Zodra de licentie is toegepast, verdwijnt het watermerk en wordt de limiet van één dia voor teksextractie opgeheven.

## **FAQ**

### Kan ik meerdere presentaties parallel testen op verschillende threads in de evaluatiemodus?

Ja. U kunt verschillende documenten parallel verwerken; u mag niet hetzelfde presentatie‑object delen [over threads](/slides/nl/net/multithreading/). De evaluatiemodus beïnvloedt dit niet.

### Moet ik Microsoft PowerPoint installeren om de bibliotheek te evalueren op een server of in CI?

Nee. Aspose.Slides is een zelfstandige engine en vereist geen geïnstalleerde PowerPoint, zowel voor evaluatie als productie.

### Kan ik de conversie van PPT/PPTX naar PDF en afbeeldingen volledig testen in de evaluatiemodus?

Ja. De [converters](/slides/nl/net/convert-presentation/) werken; de uitvoer bevat een watermerk.

### Kan ik een tijdelijke licentie gebruiken voor load‑testing zonder watermerk?

Ja. Een 30‑daagse tijdelijke licentie verwijdert de beperkingen van de evaluatiemodus en maakt testen zonder watermerk mogelijk.