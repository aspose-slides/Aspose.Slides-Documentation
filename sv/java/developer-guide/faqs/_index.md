---
title: Vanliga frågor
type: docs
weight: 340
url: /sv/java/faqs/
keywords:
- FAQ
- presentationsformat
- minnesbristfel
- bildstorlek
- extrahera text
- hämta text
- styckestorlek
- formatera tabeller
- teckensnitt
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Få svar på vanliga frågor om Aspose.Slides för Java, inklusive stöd för PowerPoint och OpenDocument, installationsvägledning, licensinformation och felsökning."
---
## **Översikt**

Denna FAQ ger svar på vanliga frågor om Aspose.Slides. Den täcker stödda filformat, hantering av undantag vid arbete med stora presentationer, ändring av bildstorlekar, förhandsgranskning av bilder, hämtning av text från presentationer, formatering av tabellramar, placering av bilder och lösning av teckensnittrelaterade problem vid konvertering av presentationer till PDF eller bilder.

## **Stödda filformat**

**Q: Vilka filformat stöder Aspose.Slides för Java?**

**A**: Aspose.Slides för Java stöder de filformat som beskrivs i [Supported File Formats](/slides/sv/java/supported-file-formats/).

## **Undantag**

**Q: Jag får ett minnesutrymmesundantag när jag laddar en stor PPT‑fil med bilder. Finns det någon begränsning i Aspose.Slides vad gäller filstorlek?**

**A**: Det finns ingen specifik formel för att beräkna den presentationsstorlek som stöds av Aspose.Slides. Det bör finnas tillräckligt med utrymme för att rymma hela presentationsstrukturen och bilder i minnet. Normalt upptar bilder i minnet mer utrymme än på hårddisken, särskilt när bilder har ytterligare effekter.

Generellt kan Aspose.Slides för Java enkelt hantera presentationsfiler på omkring 300 MB på en server med 4 GB RAM.

## **Arbeta med bilder**

**Q: Kan jag ändra storleken på bilderna i en presentation?**

**A**: Du kan använda metoden `getSlideSize` som exponeras av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/) för att definiera storleken på bilderna i en presentation.

**Q: Finns det ett sätt att definiera bilder av olika storlek i en presentation?**

**A**: Eftersom storleken på bilder definieras på presentationsnivå i Microsoft PowerPoint‑dokument finns det inget sätt att göra detta.

**Q: Stöder Aspose.Slides för Java förhandsgranskning av en bild innan den sparas?**

**A**: Du kan rendera presentationsbilder till bilder och använda dessa bilder för att förhandsgranska dem.

## **Arbeta med text**

**Q: Är det möjligt att hämta all text från en presentation?**

**A**: Aspose.Slides för Java tillhandahåller klassen [SlideUtil](https://reference.aspose.com/slides/sv/java/com.aspose.slides/slideutil/) som erbjuder olika metoder för att hämta hela texten från presentationerna.

**Q: Varför är styckestorlekar olika på Windows‑ och Linux‑operativsystem?**

**A**: Beräkningen av styckestorlekar baseras på beräkningen av textstorleken som representerar det givna stycket. Textstorleksberäkningen baseras på metriken för det teckensnitt som anges i PowerPoint‑presentationen. Om det angivna teckensnittet saknas, ersätts det med det mest liknande teckensnittet, men detta teckensnitt har metriker som skiljer sig från de ursprungliga. Som ett resultat kommer beräkningen av styckestorlekar på olika system att ge olika resultat beroende på den installerade teckensnittssamlingen. För att uppnå samma resultat på olika operativsystem måste du installera samma teckensnitt på systemen eller ladda dem vid körning som [external fonts](/slides/sv/java/custom-font/).

## **Formatering och bilder**

**Q: Hur kan jag sätta färgen på en tabellram?**

**A**: Du kan ändra färgen på alla tabellramar eller bara ramen runt hela tabellen. För att ändra alla ramar, använd metoden `getCellFormat` från gränssnittet [ICell](https://reference.aspose.com/slides/sv/java/com.aspose.slides/icell/). För ramen runt hela tabellen bör du iterera celler och ändra färgen på de yttre ramarna.

**Q: Vilken enhet använder Aspose.Slides för Java för att placera bilder?**

**A**: Koordinaterna och storlekarna på alla former på bilderna mäts i punkter (72 dpi).

## **Arbeta med teckensnitt**

**Q: När man konverterar PPT till PDF eller bilder, varför är teckensnitten olika i resultatsidorna?**

**A**: Detta problem kan tyda på att teckensnitten som används i presentationen saknas i det operativsystem där koden kördes. Du bör installera teckensnitten på operativsystemet eller ladda dem som externa teckensnitt med hjälp av klassen [FontsLoader](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fontsloader/) som visas nedan:
```cs
var folders = new String[] { "path_to_a_folder_with_fonts" };
FontsLoader.loadExternalFonts(folders);
```