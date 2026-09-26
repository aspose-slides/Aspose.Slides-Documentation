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
- utvärderingsvattenstämpel
- köpa Aspose.Slides
- begränsning
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Utvärdera Aspose.Slides för .NET och utforska API‑funktioner för PowerPoint (PPT, PPTX) och OpenDocument (ODP) presentationer—starta din kostnadsfria provperiod."
---
## **Aspose.Slides-utvärdering**

Du kan ladda ner Aspose.Slides för utvärdering. Utvärderingspaketet är detsamma som det köpta paketet; det blir licensierat efter att du har lagt till några rader kod för att tillämpa licensen.

Utan licens erbjuder Aspose.Slides full funktionalitet i utvärderingsläge, med två begränsningar: det lägger till en vattenstämplings‑textruta på varje bild i varje presentation som sparas, och text som din kod läser från en presentation trunkeras till de första några tecknen, följt av ett meddelande om utvärderingsbegränsningen. Text som din kod skriver sparas i sin helhet.

![En bild med utvärderingsvattenstämpeln](evaluate-aspose-slides_1.png)

{{% alert color="info" title="Note" %}}

Om du vill testa Aspose.Slides utan begränsningar i utvärderingsversionen kan du begära en **30‑dagars temporär licens**. Se [Hur får du en temporär licens?](https://purchase.aspose.com/temporary-license) för mer information.

{{% /alert %}}

## **Installera utvärderingspaketet**

```bash
dotnet add package Aspose.Slides.NET
```

På Linux och macOS kan du istället använda paketet Aspose.Slides.NET6.CrossPlatform; se [Installation](/slides/sv/net/installation/).

## **Applicera en licens**

Detta är de ”några raderna kod” som gör om utvärderingspaketet till ett licensierat paket. Applicera licensen en gång vid applikationens start, innan något `Presentation`‑objekt skapas – en presentation som konstruerats tidigare behåller utvärderingsvattenstämpeln.

```csharp
using Aspose.Slides;

var license = new License();
license.SetLicense("Aspose.Slides.NET.lic");
```

`SetLicense` accepterar också en `Stream`, vilket är det bättre alternativet när licensen levereras som en inbäddad resurs snarare än en fil på disk. Om sökvägen är fel eller filen har gått ut kastas ett undantag, så fel visas omedelbart vid start istället för att tyst återgå till utvärderingsläge.

När licensen har applicerats bär sparade presentationer inte längre vattenstämpeln, och text läses i sin helhet.

## **FAQ**

### Kan jag testa flera presentationer parallellt i olika trådar i utvärderingsläge?

Ja. Du kan bearbeta olika dokument parallellt; du bör inte dela samma presentationsobjekt [across threads](/slides/sv/net/multithreading/). Utvärderingsläge påverkar inte detta.

### Måste jag installera Microsoft PowerPoint för att utvärdera biblioteket på en server eller i CI?

Nej. Aspose.Slides är en fristående motor och kräver inte att PowerPoint är installerat, varken för utvärdering eller produktion.

### Kan jag fullt ut testa konvertering av PPT/PPTX till PDF och bilder i utvärderingsläge?

Ja. [Konverternas](/slides/sv/net/convert-presentation/) funktion fungerar; resultatet kommer att innehålla en vattenstämpel.

### Kan jag använda en temporär licens för belastningstest utan vattenstämpel?

Ja. En 30‑dagars temporär licens tar bort begränsningarna i utvärderingsläget och möjliggör testning utan vattenstämpel.