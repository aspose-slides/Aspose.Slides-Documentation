---
title: Konvertera PPTX till PPT i C++
linktitle: PPTX till PPT
type: docs
weight: 21
url: /sv/cpp/convert-pptx-to-ppt/
keywords:
- konvertera PowerPoint
- konvertera presentation
- konvertera bild
- konvertera PPTX
- PPTX till PPT
- spara PPTX som PPT
- exportera PPTX till PPT
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Konvertera enkelt PPTX till PPT med Aspose.Slides för C++—säkerställ sömlös kompatibilitet med PowerPoint-format samtidigt som du behåller presentationens layout och kvalitet."
---
## **Översikt**

Denna artikel förklarar hur du konverterar en PowerPoint-presentation i PPTX-format till PPT-format med C++. Följande ämne behandlas.

- Konvertera PPTX till PPT i C++

## **Konvertera PPTX till PPT i C++**

För C++‑exempelkod för att konvertera PPTX till PPT, se avsnittet nedan, dvs. [Konvertera PPTX till PPT](#convert-pptx-to-ppt). Det laddar bara PPTX‑filen och sparar i PPT‑format. Genom att ange olika sparformat kan du också spara PPTX‑filen i många andra format som PDF, XPS, ODP, HTML etc. som diskuteras i dessa artiklar.

- [Konvertera PPTX till PDF i C++](/slides/sv/cpp/convert-powerpoint-to-pdf/)
- [Konvertera PPTX till XPS i C++](/slides/sv/cpp/convert-powerpoint-to-xps/)
- [Konvertera PPTX till HTML i C++](/slides/sv/cpp/convert-powerpoint-to-html/)
- [Konvertera PPTX till ODP i C++](/slides/sv/cpp/save-presentation/)
- [Konvertera PPTX till PNG i C++](/slides/sv/cpp/convert-powerpoint-to-png/)

## **Konvertera PPTX till PPT**
För att konvertera en PPTX till PPT, ange bara filnamnet och sparformatet till **Save**‑metoden i klassen [**Presentation**](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation/). C++‑kodexemplet nedan konverterar en Presentation från PPTX till PPT med standardalternativ.

```cpp
// Läs in PPTX-filen.
SharedPtr<Presentation> prs = MakeObject<Presentation>(u"sourceFile.pptx");

// Spara i PPT-format.
prs->Save(u"convertedFile.ppt", Aspose::Slides::Export::SaveFormat::Ppt);
```

## **Vanliga frågor**

**Kan alla PPTX‑effekter och funktioner bevaras när man sparar till det äldre PPT (97–2003)-formatet?**

Inte alltid. PPT‑formatet saknar vissa nyare funktioner (t.ex. vissa effekter, objekt och beteenden), så funktioner kan förenklas eller rasteriseras vid konvertering.

**Kan jag konvertera endast utvalda bilder till PPT istället för hela presentationen?**

Direkt sparande riktar sig mot hela presentationen. För att konvertera specifika bilder, skapa en ny presentation som bara innehåller de bilderna och spara den som PPT; alternativt använd en tjänst/API som stödjer konverteringsparametrar per bild.

**Stöds lösenordsskyddade presentationer?**

Ja. Du kan upptäcka om en fil är skyddad, öppna den med ett lösenord, och även [konfigurera skydds-/krypteringsinställningar](/slides/sv/cpp/password-protected-presentation/) för den sparade PPT‑filen.