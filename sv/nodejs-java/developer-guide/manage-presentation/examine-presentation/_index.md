---
title: Hämta och uppdatera presentationsinformation i JavaScript
linktitle: Presentationsinformation
type: docs
weight: 30
url: /sv/nodejs-java/examine-presentation/
keywords:
- presentationsformat
- presentationsegenskaper
- dokumentegenskaper
- hämta egenskaper
- läsa egenskaper
- ändra egenskaper
- modifiera egenskaper
- uppdatera egenskaper
- granska PPTX
- granska PPT
- granska ODP
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Utforska bilder, struktur och metadata i PowerPoint- och OpenDocument-presentationer med JavaScript för snabbare insikter och smartare innehållsgranskningar."
---
## **Översikt**

Den här artikeln visar hur man inspekterar presentationsinformation i Aspose.Slides. Den förklarar hur man bestämmer en presentations aktuella format utan att ladda hela filen, läser dess dokumentegenskaper och uppdaterar dessa egenskaper vid behov.

Exemplen är baserade på API:erna [PresentationInfo](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentationinfo/) och [DocumentProperties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/documentproperties/) och demonstrerar typiska operationer för att arbeta med presentationsmetadata.

## **Kontrollera ett presentationsformat**

Innan du arbetar med en presentation kan du vilja ta reda på vilket format (PPT, PPTX, ODP och andra) presentationen för närvarande har.

Du kan kontrollera en presentations format utan att ladda presentationen. Se den här JavaScript-koden:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
console.log(info.getLoadFormat());// PPTX
var info2 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
console.log(info2.getLoadFormat());// PPT
var info3 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.odp");
console.log(info3.getLoadFormat());// ODP
```

## **Hämta presentationsegenskaper**

Denna JavaScript-kod visar hur du hämtar presentationsegenskaper (information om presentationen):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
var props = info.readDocumentProperties();
console.log(props.getCreatedTime());
console.log(props.getSubject());
console.log(props.getTitle());
// ..
```

Du kanske vill se [egenskaperna under DocumentProperties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/documentproperties/#DocumentProperties--) klassen.

## **Uppdatera presentationsegenskaper**

Aspose.Slides tillhandahåller metoden [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) som gör att du kan göra ändringar i presentationsegenskaper.

Låt oss säga att vi har en PowerPoint-presentation med dokumentegenskaperna som visas nedan.

![Originala dokumentegenskaper för PowerPoint-presentationen](input_properties.png)

Detta kodexempel visar hur du redigerar vissa presentationsegenskaper:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let fileName = "sample.pptx";

let info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(fileName);

let properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

Resultaten av att ändra dokumentegenskaperna visas nedan.

![Ändrade dokumentegenskaper för PowerPoint-presentationen](output_properties.png)

## **Användbara länkar**

För att få mer information om en presentation och dess säkerhetsattribut kan du finna dessa länkar användbara:

- [Lösenordsskydda presentationer](/slides/sv/nodejs-java/password-protected-presentation/)
- [Skrivskydda presentationer](/slides/sv/nodejs-java/write-protected-presentation/)

## **Vanliga frågor**

**Hur kan jag kontrollera om teckensnitt är inbäddade och vilka de är?**

Leta efter [information om inbäddade teckensnitt](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) på presentationsnivå, jämför sedan dessa poster med mängden [teckensnitt som faktiskt används i innehållet](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsmanager/getfonts/) för att identifiera vilka teckensnitt som är kritiska för rendering.

**Hur kan jag snabbt avgöra om filen har dolda bilder och hur många?**

Iterera genom [bildsamlingen](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slidecollection/) och inspektera varje bilds [synlighetsflagga](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slide/gethidden/).

**Kan jag upptäcka om anpassad bildstorlek och orientering används, och om de skiljer sig från standardinställningarna?**

Ja. Jämför den aktuella [bildstorleken](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/getslidesize/) och orienteringen med standardinställningarna; detta hjälper dig att förutse beteendet vid utskrift och export.

**Finns det ett snabbt sätt att se om diagram refererar till externa datakällor?**

Ja. Gå igenom alla [diagram](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chart/), kontrollera deras [datakälla](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdata/getdatasourcetype/), och notera om datan är intern eller länkbaserad, inklusive eventuella brutna länkar.

**Hur kan jag bedöma “tunga” bilder som kan sakta ner rendering eller PDF-export?**

För varje bild räknar du antalet objekt och letar efter stora bilder, transparens, skuggor, animationer och multimedia; tilldela ett grovt komplexitetspoäng för att markera potentiella prestandaproblem.