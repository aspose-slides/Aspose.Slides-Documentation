---
title: Vanliga frågor
type: docs
weight: 340
url: /sv/nodejs-java/faqs/
keywords:
- Vanliga frågor
- presentationsformat
- minnesfel
- bildstorlek
- extrahera text
- återhämta text
- styckestorlek
- formatera tabeller
- teckensnitt
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Få svar på vanliga frågor om Aspose.Slides för Node.js via Java, som täcker stöd för PowerPoint och OpenDocument, installationsanvisningar, licensiering och felsökning."
---
## **Översikt**

Denna FAQ ger svar på vanliga frågor om Aspose.Slides. Den täcker stödda filformat, hantering av undantag vid arbete med stora presentationer, ändring av bildstorlekar, förhandsgranskning av bilder, hämtning av text från presentationer, formatering av tabellramar, placering av bilder och lösning av teckensnittsrelaterade problem vid konvertering av presentationer till PDF eller bilder.

## **Stödda filformat**

**Q:** Vilka filformat stöder Aspose.Slides för Node.js via Java?

**A:** Aspose.Slides för Node.js via Java stöder de filformat som beskrivs i [Stödda filformat](/slides/sv/nodejs-java/supported-file-formats/).

## **Undantag**

**Q:** Jag får ett minnesbristundantag när jag laddar en stor PPT-fil med bilder. Finns det någon begränsning i Aspose.Slides när det gäller filstorlek?

**A:** Det finns ingen specifik formel för att beräkna den presentationstorlek som stöds av Aspose.Slides. Det bör finnas tillräckligt med utrymme för att rymma hela presentationsstrukturen och bilderna i minnet. Normalt tar bilder i minnet mer plats än på hårddisken, särskilt när bilder har ytterligare effekter.

Generellt kan Aspose.Slides för Node.js via Java enkelt hantera presentationsfiler på omkring 300 MB på en server med 4 GB RAM.

## **Arbeta med bilder**

**Q:** Kan jag ändra storleken på bilderna i en presentation?

**A:** Du kan använda metoden `getSlideSize` som finns i klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/) för att definiera storleken på bilderna i en presentation.

**Q:** Finns det ett sätt att definiera bilder av olika storlek i en presentation?

**A:** Eftersom bildstorleken definieras på presentationsnivå i Microsoft PowerPoint-dokument finns det inget sätt att göra detta.

**Q:** Stöder Aspose.Slides för Node.js via Java förhandsgranskning av en bild innan den sparas?

**A:** Du kan rendera presentationsbilderna till bilder och använda dessa bilder för att förhandsgranska dem.

## **Arbeta med text**

**Q:** Är det möjligt att hämta all text från en presentation?

**A:** Aspose.Slides för Node.js via Java tillhandahåller klassen [SlideUtil](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slideutil/) som erbjuder olika metoder för att hämta all text från presentationerna.

**Q:** Varför är stycke­storlekar olika på Windows- och Linux‑operativsystem?

**A:** Beräkningen av stycke­storlekar baseras på beräkningen av textstorleken som representerar det aktuella stycket. Textstorleksberäkningen bygger på metriken för det teckensnitt som anges i PowerPoint-presentationen. Om det angivna teckensnittet saknas ersätts det med det mest liknande teckensnittet, men detta teckensnitt har andra mått än originalet. Därför leder beräkningen av stycke­storlekar i olika system till olika resultat beroende på vilka teckensnitt som är installerade. För att uppnå samma resultat på olika operativsystem måste du installera samma teckensnitt på systemen eller ladda dem vid körning som [externa teckensnitt](/slides/sv/nodejs-java/custom-font/).

## **Formatering och bilder**

**Q:** Hur kan jag ange färgen på en tabellram?

**A:** Du kan ändra färgen på alla tabellramar eller bara ramen runt hela tabellen. För att ändra alla ramar, använd metoden `getCellFormat` från klassen [Cell](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/cell/). För ramen runt hela tabellen bör du iterera igenom cellerna och ändra färgen på de yttre ramarna.

**Q:** Vilken måttenhet använder Aspose.Slides för Node.js via Java när bilder placeras?

**A:** Koordinaterna och storlekarna för alla former på bilderna mäts i punkter (72 dpi).

## **Arbeta med teckensnitt**

**Q:** När PPT konverteras till PDF eller bilder, varför är teckensnitten olika i utdokumenten?

**A:** Detta problem kan indikera att de teckensnitt som används i presentationen saknas i operativsystemet där koden kördes. Du bör installera teckensnitten i operativsystemet eller ladda dem som externa teckensnitt med hjälp av klassen [FontsLoader](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsloader/) som visas nedan:
```javascript
var folders = java.newArray("java.lang.String", ["path_to_a_folder_with_fonts"]));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", folders);
```