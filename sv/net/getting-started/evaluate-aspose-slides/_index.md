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
- köp Aspose.Slides
- begränsning
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Utvärdera Aspose.Slides för .NET och utforska API-funktioner för PowerPoint (PPT, PPTX) och OpenDocument (ODP) presentationer - starta din kostnadsfria provperiod."
---
## **Aspose.Slides Utvärdering**

Du kan enkelt ladda ner Aspose.Slides för utvärdering. Utvärderingspaketet är detsamma som det köpta paketet. Utvärderingsversionen blir enkelt licensierad efter att du lagt till några rader kod för att tillämpa licensen. 

Utvärderingsversionen av Aspose.Slides (utan en angiven licens) ger full produktfunktionalitet, men den lägger in ett utvärderingsvattenmärke högst upp i dokumentet vid öppning och sparning. Du är också begränsad till en bild när du extraherar text från presentationsbilder.

![todo:image_alt_text](evaluate-aspose-slides_1.png)

{{% alert color="primary" %}} 

Om du vill testa Aspose.Slides utan begränsningar i utvärderingsversionen kan du begära en **30‑dagars tillfällig licens**. Läs mer på [Hur får man en tillfällig licens?](https://purchase.aspose.com/temporary-license) för mer information.

{{% /alert %}}

## **Installera Utvärderingspaketet**

```bash
dotnet add package Aspose.Slides.NET
```

## **Applicera en Licens**

Det här är de "några rader kod" som gör om utvärderingspaketet till ett licensierat. Applicera licensen en gång vid programstart, innan något `Presentation`‑objekt skapas — en presentation som skapats tidigare behåller utvärderingsvattenmärket.

```csharp
using Aspose.Slides;

var license = new License();
license.SetLicense("Aspose.Slides.NET.lic");
```

`SetLicense` accepterar även en `Stream`, vilket är det bättre alternativet när licensen levereras som en inbäddad resurs snarare än en fil på disk. Om sökvägen är fel eller filen har gått ut kastas ett undantag, så att fel uppstår omedelbart vid start snarare än att tyst återgå till utvärderingsläge.

När licensen har applicerats försvinner vattenmärket och begränsningen på en bild för textuttagning tas bort.

## **FAQ**

### Can I test multiple presentations in parallel across different threads in evaluation mode?

Ja. Du kan bearbeta olika dokument parallellt; du bör inte dela samma presentationsobjekt [across threads](/slides/sv/net/multithreading/). Utvärderingsläge påverkar inte detta.

### Do I need to install Microsoft PowerPoint to evaluate the library on a server or in CI?

Nej. Aspose.Slides är en fristående motor och kräver inte att PowerPoint är installerat, varken för utvärdering eller produktion.

### Can I fully test conversion of PPT/PPTX to PDF and images in evaluation mode?

Ja. [konverterare](/slides/sv/net/convert-presentation/) fungerar; resultatet kommer att innehålla ett vattenmärke.

### Can I use a temporary license for load testing without a watermark?

Ja. En 30‑dagars tillfällig licens tar bort begränsningar i utvärderingsläge och möjliggör testning utan vattenmärke.