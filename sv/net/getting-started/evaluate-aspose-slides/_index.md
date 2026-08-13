---
title: Utvärdera Aspose.Slides
type: docs
weight: 120
url: /sv/net/evaluate-aspose-slides/
keywords:
- utvärdera Aspose.Slides
- Aspose.Slides-utvärdering
- utvärderingsversion
- full funktionalitet
- utvärderingsvattenmärke
- köpa Aspose.Slides
- begränsning
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Utvärdera Aspose.Slides för .NET och utforska API-funktioner för PowerPoint (PPT, PPTX) och OpenDocument (ODP)-presentationer - starta din kostnadsfria provperiod."
---
## **Aspose.Slides-utvärdering**

Du kan enkelt ladda ner Aspose.Slides för utvärdering. Utvärderingspaketet är detsamma som det köpta paketet. Utvärderingsversionen blir helt enkelt licensierad när du lägger till några rader kod för att tillämpa licensen. 

Utvärderingsversionen av Aspose.Slides (utan angiven licens) erbjuder full produktfunktionalitet, men den lägger in ett utvärderingsvattenmärke högst upp i dokumentet vid öppning och sparning. Du är också begränsad till en bild när du extraherar text från presentationsbilder.

![todo:image_alt_text](evaluate-aspose-slides_1.png)

{{% alert color="info" %}} 
Om du vill testa Aspose.Slides utan begränsningarna i utvärderingsversionen kan du begära en **30 dagars tillfällig licens**. Se [Hur får du en tillfällig licens?](https://purchase.aspose.com/temporary-license) för mer information.
{{% /alert %}}

## **Installera utvärderingspaketet**

```bash
dotnet add package Aspose.Slides.NET
```

## **Tillämpa en licens**

Det här är de ”några rader kod” som förvandlar utvärderingspaketet till ett licensierat. Tillämpa licensen en gång vid applikationens start, innan något `Presentation`‑objekt skapas – en presentation som konstruerats tidigare behåller utvärderingsvattenmärket.

```csharp
using Aspose.Slides;

var license = new License();
license.SetLicense("Aspose.Slides.NET.lic");
```

`SetLicense` accepterar också en `Stream`, vilket är det bättre alternativet när licensen levereras som en inbäddad resurs snarare än en fil på disken. Om sökvägen är fel eller filen har gått ut kastas ett undantag, så fel visas omedelbart vid start istället för att tyst återgå till utvärderingsläge.

När licensen har tillämpats försvinner vattenmärket och begränsningen för textutdragning från en enda bild tas bort.

## **Vanliga frågor**

### Kan du testa flera presentationer parallellt över olika trådar i utvärderingsläge?

Ja. Du kan bearbeta olika dokument parallellt; du bör inte dela samma presentationsobjekt [över trådar](/slides/sv/net/multithreading/). Utvärderingsläget påverkar inte detta.

### Behöver jag installera Microsoft PowerPoint för att utvärdera biblioteket på en server eller i CI?

Nej. Aspose.Slides är en fristående motor och kräver inte att PowerPoint är installerat, varken för utvärdering eller produktion.

### Kan jag fullständigt testa konvertering av PPT/PPTX till PDF och bilder i utvärderingsläge?

Ja. [konverterarna](/slides/sv/net/convert-presentation/) fungerar; utdata kommer att innehålla ett vattenmärke.

### Kan jag använda en tillfällig licens för belastningstestning utan vattenmärke?

Ja. En 30‑dagars tillfällig licens tar bort begränsningarna i utvärderingsläget och möjliggör test utan vattenmärke.