---
title: Bestäm det ursprungliga presentationsformatet i Node.js
linktitle: Källformat
type: docs
weight: 35
url: /sv/nodejs-java/detect-presentation-source-format/
keywords:
- källformat
- detektera presentationsformat
- PowerPoint
- OpenDocument
- presentation
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "Läs det ursprungliga formatet för en inläst presentation i Node.js med Aspose.Slides för Node.js via Java, jämför identifierings-API:er och hantera filer, strömmar och äldre format."
---
## **Översikt**

Efter att ha laddat en presentation, anropa metoden [Presentation.getSourceFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#getSourceFormat) för att bestämma dess ursprungliga format. Använd den när efterföljande bearbetning beror på formatet som den aktuella instansen laddades från.

Källformatet skiljer sig från [SaveFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/saveformat/) som väljs för en utdatafil. Att spara till ett annat format ändrar inte källformatet för den befintliga instansen.

## **Läs källformatet för en fil**

Detta exempel kräver en befintlig fil `sample.pptx`. Det läser in filen och väljer en bearbetningspolicy för applikationen med hjälp av [Presentation.getSourceFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#getSourceFormat), snarare än filnamnet. Ändra inmatningssökvägen för att prova andra format. Exemplet skriver ut den valda policyn; ersätt meddelandena med din applikationslogik.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    switch (presentation.getSourceFormat()) {
        case aspose.SourceFormat.Ppt:
        case aspose.SourceFormat.Pps:
        case aspose.SourceFormat.Pot:
            console.log("Use the legacy PowerPoint processing policy.");
            break;
        case aspose.SourceFormat.Pptx:
            console.log("Use the standard PPTX processing policy.");
            break;
        default:
            console.log("Use the general policy for source format " + presentation.getSourceFormat() + ".");
            break;
    }
} finally {
    presentation.dispose();
}
```

## **Känn igen de stödda värdena**

Klassen [SourceFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sourceformat/) definierar heltalskonstanter som särskiljer följande presentationsformat. Nedanstående filändelser är konventionella och är inte en återuppbyggnad av det ursprungliga filnamnet.

| SourceFormat‑värde | Filändelse | Format |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint‑presentation 97–2003 |
| `Pptx` | `.pptx` | Office Open XML‑presentation |
| `Pptm` | `.pptm` | Makroaktiverad Office Open XML‑presentation |
| `Pps` | `.pps` | PowerPoint‑bildspel 97–2003 |
| `Ppsx` | `.ppsx` | Office Open XML‑bildspel |
| `Ppsm` | `.ppsm` | Makroaktiverat Office Open XML‑bildspel |
| `Pot` | `.pot` | PowerPoint‑mall 97–2003 |
| `Potx` | `.potx` | Office Open XML‑mall |
| `Potm` | `.potm` | Makroaktiverad Office Open XML‑mall |
| `Odp` | `.odp` | OpenDocument‑presentation |
| `Otp` | `.otp` | OpenDocument‑mall |
| `Fodp` | `.fodp` | Platt XML ODF‑presentation |
| `Xml` | `.xml` | PowerPoint‑XML‑presentation |

## **Läs källformatet för en ström**

Detta exempel kräver en befintlig fil `sample.pps`. Att läsa dess byte till ett minnesström modellerar indata som mottagits utan ett filnamn, till exempel ett databasinnehåll eller en uppladdad byte‑array. [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/)-konstruktorn tar endast emot strömmen.

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const buffer = fs.readFileSync("sample.pps");
const bytes = java.newArray("byte", Array.from(buffer));
const stream = java.newInstanceSync("java.io.ByteArrayInputStream", bytes);
try {
    const presentation = new aspose.Presentation(stream);
    try {
        console.log("Source format: " + presentation.getSourceFormat());
    } finally {
        presentation.dispose();
    }
} finally {
    stream.close();
}
```

PPT, PPS och POT använder samma underliggande binära format. Vid inläsning via filsökväg kan filändelsen hjälpa till att särskilja ett bildspel eller en mall. Utan ett filnamn kan äldre PPS‑ och POT‑innehåll rapporteras som `SourceFormat.Ppt`; PPS‑exemplet ovan skriver ut heltalsvärdet för `SourceFormat.Ppt`.

Om din applikation måste bevara skillnaden, behåll det ursprungliga filnamnet eller subtype‑metadata separat. En filändelse är en användbar ledtråd för dessa äldre subtyper, men bör inte vara det enda underlaget för att identifiera godtyckligt presentationsinnehåll.

## **Jämför identifiering före och efter inläsning**

Använd [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) och [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentationinfo/#getLoadFormat) när du behöver undersöka en fil innan hela presentationsobjektmodellen laddas. Använd [Presentation.getSourceFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#getSourceFormat) när instansen redan finns.

Detta exempel kräver `sample.pptx` och skriver ut de heltalsvärden som motsvarar `LoadFormat.Pptx` respektive `SourceFormat.Pptx`. I produktion bör du välja det API som passar ditt bearbetningsstadium; en redan inläst presentation behöver inte en andra inspektion enbart för att erhålla dess källformat.

```javascript
const aspose = require("aspose.slides.via.java");

const path = "sample.pptx";
const information = aspose.PresentationFactory.getInstance().getPresentationInfo(path);
console.log("Before loading: " + information.getLoadFormat());

const presentation = new aspose.Presentation(path);
try {
    console.log("After loading: " + presentation.getSourceFormat());
} finally {
    presentation.dispose();
}
```

Resultaten använder konstanter från olika klasser: [LoadFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/loadformat/) och [SourceFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sourceformat/). Jämför inte deras numeriska värden eller anta att varje format har identiska identifieringsresultat. PowerPoint XML kan rapporteras som `LoadFormat.Unknown` före inläsning och `SourceFormat.Xml` efter inläsning.

## **Håll käll- och utdataformat separata**

Detta exempel kräver `sample.pptx` och skriver `converted.odp`. Det skriver ut heltalsvärdet för `SourceFormat.Pptx` både före och efter att den ursprungliga instansen sparats. Endast den nya instansen som laddas från ODP‑utdata rapporterar `Odp`.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    console.log("Before saving: " + presentation.getSourceFormat());

    presentation.save("converted.odp", aspose.SaveFormat.Odp);
    console.log("After saving: " + presentation.getSourceFormat());

    const reopened = new aspose.Presentation("converted.odp");
    try {
        console.log("Reopened output: " + reopened.getSourceFormat());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

En presentation som skapas från grunden med `new Presentation()` rapporterar `SourceFormat.Pptx`. Den har ingen indatafil: detta är standardvärdet för en nyinstans, inte ett bevis på att en PPTX‑fil har lästs in. Spåra om din applikation skapade eller laddade instansen separat om den skillnaden är viktig.

## **Koppla ett källformat till en filändelse**

Följande exempel kräver `sample.pptx`. Det mappar varje för närvarande stödd [SourceFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sourceformat/)‑värde till en konventionell filändelse, utan att analysera indatafilens namn. Fallback‑logiken förhindrar att tyst tilldela en filändelse till ett okänt värde.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    let extension;
    switch (presentation.getSourceFormat()) {
        case aspose.SourceFormat.Ppt:
            extension = ".ppt";
            break;
        case aspose.SourceFormat.Pptx:
            extension = ".pptx";
            break;
        case aspose.SourceFormat.Pptm:
            extension = ".pptm";
            break;
        case aspose.SourceFormat.Pps:
            extension = ".pps";
            break;
        case aspose.SourceFormat.Ppsx:
            extension = ".ppsx";
            break;
        case aspose.SourceFormat.Ppsm:
            extension = ".ppsm";
            break;
        case aspose.SourceFormat.Pot:
            extension = ".pot";
            break;
        case aspose.SourceFormat.Potx:
            extension = ".potx";
            break;
        case aspose.SourceFormat.Potm:
            extension = ".potm";
            break;
        case aspose.SourceFormat.Odp:
            extension = ".odp";
            break;
        case aspose.SourceFormat.Otp:
            extension = ".otp";
            break;
        case aspose.SourceFormat.Fodp:
            extension = ".fodp";
            break;
        case aspose.SourceFormat.Xml:
            extension = ".xml";
            break;
        default:
            extension = null;
            break;
    }

    console.log(extension != null ? extension : "No extension mapping is available.");
} finally {
    presentation.dispose();
}
```

Denna mappning konverterar inte en fil eller återställer en äldre PPS/POT‑subtyp som gått förlorad under strömläsning. För faktiskt sparande, välj ett [SaveFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/saveformat/) explicit, eller använd konverteringen som visas i [Save Presentations in Their Original Format](/slides/sv/nodejs-java/save-presentation/#save-presentations-in-their-original-format).

## **Verifiera format genom att spara och öppna igen**

Detta självständiga exempel skapar en presentation och skriver tre filer i arbetskatalogen, och skriver över filer med samma namn. Det öppnar varje utdata både via sökväg och genom en minnesström. För PPTX och ODP rapporterar båda vägarna det sparade formatet. För PPS rapporterar inläsning via sökväg `Pps`, medan inläsning av samma byte utan filnamn rapporterar `Ppt`.

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.Presentation();
try {
    const formats = [aspose.SaveFormat.Pptx, aspose.SaveFormat.Odp, aspose.SaveFormat.Pps];
    const extensions = ["pptx", "odp", "pps"];

    for (let i = 0; i < formats.length; i++) {
        const path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        const fromFile = new aspose.Presentation(path);
        try {
            const buffer = fs.readFileSync(path);
            const bytes = java.newArray("byte", Array.from(buffer));
            const stream = java.newInstanceSync("java.io.ByteArrayInputStream", bytes);
            try {
                const fromStream = new aspose.Presentation(stream);
                try {
                    console.log(extensions[i] + ": file=" + fromFile.getSourceFormat() + ", stream=" + fromStream.getSourceFormat());
                } finally {
                    fromStream.dispose();
                }
            } finally {
                stream.close();
            }
        } finally {
            fromFile.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

Följande tabell sammanfattar identifieringen av källformat för presentationer med matchande filändelser. Namnen avser konstanter; JavaScript‑exemplen skriver ut deras heltalsvärden:

| Sparat format | SourceFormat från en filsökväg | SourceFormat från en namn‑lös ström |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respectively | Same as file path |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respectively | Same as file path |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respectively | Same as file path |
| ODP, OTP | `Odp`, `Otp` respectively | Same as file path |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

PPS/POT‑innehåll identifieras som `Ppt` för namn‑lösa strömmar. Tabellen beskriver formatidentifiering, inte bevarande av varje presentationsfunktion under konvertering.

## **FAQ**

**Ändras källformatet för en presentation som laddats från PPTX när den sparas till ODP?**

Nej. Den befintliga instansen rapporterar fortfarande `Pptx`. En instans som laddas från den sparade ODP‑filen rapporterar `Odp`.

**Kan en ström alltid särskilja en äldre presentation, ett bildspel och en mall?**

Nej. PPT, PPS och POT delar samma binära format. Behåll filnamn eller subtype‑metadata separat när den skillnaden krävs.

**Vilket API ska jag använda om presentationen redan är inläst?**

Läs [Presentation.getSourceFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#getSourceFormat). Använd [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) för inspektion innan inläsning.