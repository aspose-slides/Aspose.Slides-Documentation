---
title: Converteer PowerPoint naar PDF in Node.js via .NET
linktitle: PowerPoint naar PDF
type: docs
weight: 30
url: /nl/nodejs-net/convert-powerpoint-to-pdf/
keywords:
- PowerPoint naar PDF
- PowerPoint naar PDF converteren
- PPTX naar PDF
- PPT naar PDF
- ODP naar PDF
- presentatie opslaan als PDF
- PDF/A
- PdfOptions
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Converteer PPTX-, PPT- en ODP-presentaties naar PDF in JavaScript met Aspose.Slides for Node.js via .NET, en maak archiverings-PDF/A-bestanden met PdfOptions."
---
## **Overzicht**

Aspose.Slides for Node.js via .NET converteert PowerPoint- en OpenDocument-presentaties naar PDF zonder Microsoft PowerPoint. Elke zichtbare dia wordt één PDF-pagina van dezelfde afmeting als de dia, en de tekst blijft selecteerbaar en doorzoekbaar. Dit artikel toont de standaardconversie en een conversie naar PDF/A met [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/).

De voorbeelden gaan uit van een presentatie met de naam `sample.pptx` in de projectmap die je hebt ingesteld in [Installation](/slides/nl/nodejs-net/installation/). Elke PowerPoint-presentatie voldoet. Sla elk voorbeeld op als een `.js`-bestand in de projectmap en voer het uit vanuit die map met `node`.

{{% alert color="info" title="Opmerking" %}}
Aspose.Slides for Node.js via .NET heeft geen eigen API-referentie. Het spiegelt de Aspose.Slides for .NET API met camelCase-namen, dus de API-links in dit artikel verwijzen naar de bijbehorende klassen en leden in de [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/).
{{% /alert %}}

## **Een presentatie naar PDF converteren**

Om een presentatie naar PDF te converteren, volg deze stappen:

1. Open de presentatie door het pad door te geven aan de constructor van [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/). Dezelfde code werkt voor PPTX-, PPT- en ODP-bestanden.
1. Roep de [save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/)‑methode aan met het uitvoerpad en `SaveFormat.Pdf`.
1. Roep `dispose` aan in een `finally`-blok om de .NET-bronnen die de presentatie ondersteunen vrij te geven.

```javascript
const { Presentation, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    presentation.save("sample.pdf", SaveFormat.Pdf);
    console.log("Saved sample.pdf");
} finally {
    presentation.dispose();
}
```

Het script schrijft `sample.pdf` naar de projectmap. De conversie gebruikt de standaardinstellingen: elke dia die niet verborgen is, wordt een pagina, in volgorde van de dia’s. Zonder licentie wordt op elke pagina ook een evaluatiewatermerk weergegeven; zie [Licensing](/slides/nl/nodejs-net/licensing/).

## **Een presentatie naar PDF/A converteren**

Om de output te bepalen, geef je een [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)-object door als het derde argument van `save`. Het volgende voorbeeld stelt de eigenschap [compliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/compliance/) in op `PdfCompliance.PdfA2b`, waardoor een PDF/A-2b-bestand wordt gemaakt. PDF/A is de ISO-norm voor langdurige archivering: onder andere vereist het dat elk lettertype dat het document gebruikt, wordt ingebed in het bestand.

```javascript
const { Presentation, SaveFormat, PdfOptions, PdfCompliance } = require("aspose.slides.via.net");

const pdfOptions = new PdfOptions();
pdfOptions.compliance = PdfCompliance.PdfA2b;

const presentation = new Presentation("sample.pptx");
try {
    presentation.save("sample-pdfa.pdf", SaveFormat.Pdf, pdfOptions);
    console.log("Saved sample-pdfa.pdf");
} finally {
    presentation.dispose();
}
```

Het script schrijft `sample-pdfa.pdf` met dezelfde pagina’s als de standaardconversie. Om te bevestigen dat een bestand aan de norm voldoet, controleer het met een PDF/A-validator zoals [veraPDF](https://verapdf.org/). Andere [PdfCompliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfcompliance/)-waarden selecteren andere standaarden, zoals `PdfA1b`, `PdfA2a` of `PdfUa` voor toegankelijkheid.

## **FAQ**

**Hoe kan ik verborgen dia’s opnemen in de PDF?**

Verborgen dia’s worden standaard overgeslagen. Stel de eigenschap [showHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) van `PdfOptions` in op `true` en geef de opties door aan `save`.

**Kan ik de PDF beveiligen met een wachtwoord?**

Ja. Stel de eigenschap [password](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/password/) van `PdfOptions` in voordat je `save` aanroept. PDF-lezers vragen dan om dat wachtwoord voordat ze het bestand openen.

**Kan ik alleen bepaalde dia’s converteren?**

Ja. Geef een array met dia-posities door als het vierde argument van `save`. Posities beginnen bij 1, en het derde argument kan `null` zijn als je geen opties nodig hebt: `presentation.save("selected.pdf", SaveFormat.Pdf, null, [1, 3])` schrijft een PDF met de eerste en derde dia.

**Waarom ziet de tekst er anders uit wanneer ik converteer op Linux?**

Aspose.Slides kan alleen lettertypen gebruiken die geïnstalleerd zijn op de machine die de conversie uitvoert. Wanneer een presentatie een lettertype gebruikt dat ontbreekt, zoals Calibri op een typische Linux-server, gebruikt Aspose.Slides een geïnstalleerd lettertype als vervanging, wat de weergave van de tekst en waar regels breken kan veranderen. Installeer de lettertypen die uw presentaties gebruiken om hetzelfde resultaat als op Windows te krijgen.

**Kan ik de PDF als een Buffer krijgen in plaats van als bestand?**

Ja. `presentation.saveToBuffer(SaveFormat.Pdf)` retourneert de PDF als een Node.js `Buffer`, wat handig is wanneer je het resultaat in een HTTP-respons stuurt. Het accepteert ook `PdfOptions` als tweede argument.