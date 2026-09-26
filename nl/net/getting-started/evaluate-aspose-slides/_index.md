---
title: Aspose.Slides evalueren
type: docs
weight: 120
url: /nl/net/evaluate-aspose-slides/
keywords:
- Aspose.Slides evalueren
- Aspose.Slides evaluatie
- evaluatieversie
- volle functionaliteit
- evaluatiewatermerk
- Aspose.Slides kopen
- beperking
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Evalueer Aspose.Slides voor .NET en verken API-functionaliteiten voor PowerPoint (PPT, PPTX) en OpenDocument (ODP) presentaties - start uw gratis proefperiode."
---
## **Aspose.Slides Evaluatie**

U kunt Aspose.Slides downloaden voor evaluatie. Het evaluatiepakket is hetzelfde als het aangeschafte pakket; het wordt gelicentieerd nadat u een paar regels code toevoegt om de licentie toe te passen.

Zonder licentie biedt Aspose.Slides zijn volledige functionaliteit in evaluatiemodus, met twee beperkingen: het voegt een evaluatiewatermerk‑tekstvak toe aan elke dia van elke presentatie die wordt opgeslagen, en tekst die uw code uit een presentatie leest, wordt afgekapt tot de eerste paar tekens, gevolgd door een melding over de evaluatie‑beperking. Tekst die uw code schrijft, wordt volledig opgeslagen.

![Een dia met het evaluatiewatermerk](evaluate-aspose-slides_1.png)

{{% alert color="info" title="Opmerking" %}}
Als u Aspose.Slides wilt testen zonder de beperkingen van de evaluatieversie, kunt u een **30‑daagse tijdelijke licentie** aanvragen. Raadpleeg [Hoe krijg ik een tijdelijke licentie?](https://purchase.aspose.com/temporary-license) voor meer informatie.
{{% /alert %}}

## **Installeer het evaluatiepakket**

```bash
dotnet add package Aspose.Slides.NET
```

Op Linux en macOS kunt u in plaats daarvan het Aspose.Slides.NET6.CrossPlatform‑pakket gebruiken; zie [Installatie](/slides/nl/net/installation/).

## **Licentie toepassen**

Dit zijn de “paar regels code” die het evaluatiepakket omzetten naar een gelicentieerde versie. Pas de licentie één keer toe bij het opstarten van de applicatie, vóórdat een `Presentation`‑object wordt aangemaakt — een eerder geconstrueerde presentatie behoudt het evaluatiewatermerk.

```csharp
using Aspose.Slides;

var license = new License();
license.SetLicense("Aspose.Slides.NET.lic");
```

`SetLicense` accepteert ook een `Stream`, wat de betere optie is wanneer de licentie wordt meegeleverd als een ingebedde resource in plaats van een bestand op schijf. Als het pad onjuist is of het bestand verlopen is, wordt een uitzondering gegooid, zodat fouten direct bij het opstarten zichtbaar zijn in plaats van stilletjes terug te vallen op de evaluatiemodus.

Zodra de licentie is toegepast, bevatten opgeslagen presentaties geen watermerk meer en wordt tekst volledig gelezen.

## **FAQ**

### Kan ik meerdere presentaties parallel testen over verschillende threads in evaluatiemodus?

Ja. U kunt verschillende documenten parallel verwerken; u moet hetzelfde presentatie‑object niet delen [over threads](/slides/nl/net/multithreading/). De evaluatiemodus heeft hier geen invloed op.

### Moet ik Microsoft PowerPoint installeren om de bibliotheek op een server of in CI te evalueren?

Nee. Aspose.Slides is een zelfstandige engine en vereist geen geïnstalleerde PowerPoint, zowel voor evaluatie als productie.

### Kan ik de volledige conversie van PPT/PPTX naar PDF en afbeeldingen testen in evaluatiemodus?

Ja. De [converters](/slides/nl/net/convert-presentation/) werken; de output bevat wel een watermerk.

### Kan ik een tijdelijke licentie gebruiken voor load‑testing zonder watermerk?

Ja. Een 30‑daagse tijdelijke licentie verwijdert de beperkingen van de evaluatiemodus en maakt testen zonder watermerk mogelijk.