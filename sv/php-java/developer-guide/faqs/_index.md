---
title: Vanliga frågor
type: docs
weight: 340
url: /sv/php-java/faqs/
keywords:
- Vanliga frågor
- presentationsformat
- minnesfel
- bildstorlek
- extrahera text
- hämta text
- styckestorlek
- formatering av tabeller
- teckensnitt
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Få svar på vanliga frågor om Aspose.Slides för PHP via Java, inklusive stöd för PowerPoint och OpenDocument, installationsvägledning, licensiering och felsökning."
---
## **Översikt**

Den här FAQ:n innehåller svar på vanliga frågor om Aspose.Slides. Den täcker stödda filformat, hur man hanterar undantag vid arbete med stora presentationer, ändring av bildstorlekar, förhandsgranskning av bilder, hämtning av text från presentationer, formatering av tabellramar, placering av bilder samt lösning av teckensnittsrelaterade problem när presentationer konverteras till PDF eller bilder.

## **Stödda filformat**

**Q: Vilka filformat stöder Aspose.Slides för PHP via Java?**

**A**: Aspose.Slides för PHP via Java stöder de filformat som beskrivs i [Stödda filformat](/slides/sv/php-java/supported-file-formats/).

## **Undantag**

**Q: Jag får ett undantag för otillräckligt minne när jag laddar en stor PPT‑fil med bilder. Finns det någon begränsning i Aspose.Slides när det gäller filstorlek?**

**A**: Det finns ingen specifik formel för att beräkna den presentationsstorlek som stöds av Aspose.Slides. Det bör finnas tillräckligt med utrymme för att rymma hela presentationsstrukturen och bilderna i minnet. Vanligtvis tar bilder i minnet mer utrymme än på hårddisken, särskilt när bilder har ytterligare effekter.

Generellt kan Aspose.Slides för PHP via Java enkelt hantera presentationsfiler på omkring 300 MB på en server med 4 GB RAM.

## **Arbeta med bilder**

**Q: Kan jag ändra storleken på bilderna i en presentation?**

**A**: Du kan använda metoden `getSlideSize` som exponeras av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) för att definiera storleken på bilderna i en presentation.

**Q: Finns det ett sätt att definiera bilder med olika storlek i en presentation?**

**A**: Eftersom storleken på bilder definieras på presentationsnivå i Microsoft PowerPoint‑dokument, finns det inget sätt att göra detta.

**Q: Stöder Aspose.Slides för PHP via Java förhandsgranskning av en bild innan den sparas?**

**A**: Du kan rendera presentationsbilderna till bilder och använda dessa bilder för att förhandsgranska bilderna.

## **Arbeta med text**

**Q: Är det möjligt att hämta all text från en presentation?**

**A**: Aspose.Slides för PHP via Java tillhandahåller klassen [SlideUtil](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slideutil/) som erbjuder olika metoder för att hämta hela texten från presentationerna.

**Q: Varför är stycke‑storlekar olika på Windows‑ och Linux‑operativsystem?**

**A**: Beräkningen av styckestorlekar baseras på beräkningen av textstorleken som representerar det aktuella stycket. Textstorleksberäkningen baseras på måtten för det teckensnitt som anges i PowerPoint‑presentationen. Om det angivna teckensnittet saknas ersätts det med det mest liknande teckensnittet, men detta teckensnitt har mått som skiljer sig från de ursprungliga. Därför kommer beräkningen av styckestorlekar i olika system att ge olika resultat beroende på vilka teckensnitt som är installerade. För att uppnå samma resultat på olika operativsystem måste du installera samma teckensnitt på systemen eller ladda dem vid körning som [externa teckensnitt](/slides/sv/php-java/custom-font/).

## **Formatering och bilder**

**Q: Hur kan jag sätta färgen på en tabellram?**

**A**: Du kan ändra färgen på alla tabellramar eller bara ramen runt hela tabellen. För att ändra alla ramar, använd metoden `getCellFormat` från klassen [Cell](https://reference.aspose.com/slides/sv/php-java/aspose.slides/cell/). För ramen runt hela tabellen bör du iterera över celler och ändra färgen på de yttre ramarna.

**Q: Vilken måttenhet använder Aspose.Slides för PHP via Java för att placera bilder?**

**A**: Koordinaterna och storlekarna för alla former på bilderna mäts i punkter (72 dpi).

## **Arbeta med teckensnitt**

**Q: När man konverterar PPT till PDF eller bilder, varför är teckensnitten olika i de resulterande dokumenten?**

**A**: Det här problemet kan indikera att de teckensnitt som används i presentationen saknas i det operativsystem där koden kördes. Du bör installera teckensnitten i operativsystemet eller ladda dem som externa teckensnitt med hjälp av klassen [FontsLoader](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontsloader/) enligt illustrationen nedan:
```php
$folders = ["path_to_a_folder_with_fonts"];
FontsLoader::loadExternalFonts($folders);
```