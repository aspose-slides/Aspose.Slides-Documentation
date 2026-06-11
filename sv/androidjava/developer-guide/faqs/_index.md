---
title: Vanliga frågor
type: docs
weight: 340
url: /sv/androidjava/faqs/
keywords:
- Vanliga frågor
- presentationsformat
- minnesbristfel
- bildstorlek
- extrahera text
- hämta text
- styckestorlek
- tabellformatering
- teckensnitt
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Få svar på vanliga frågor om Aspose.Slides för Android via Java, som täcker stöd för PowerPoint och OpenDocument, installationsvägledning, licensiering och felsökning."
---
## **Översikt**

Den här FAQ‑en ger svar på vanliga frågor om Aspose.Slides. Den täcker stödda filformat, hur man hanterar undantag vid arbete med stora presentationer, ändring av bildstorlekar, förhandsgranskning av bilder, hämtning av text från presentationer, formatering av tabellramar, placering av bilder samt lösning av teckensnittsrelaterade problem vid konvertering av presentationer till PDF eller bilder.

## **Filformat som stöds**

**Q: Vilka filformat stöder Aspose.Slides för Android via Java?**

**A**: Aspose.Slides för Android via Java stödjer de filformat som beskrivs i [Filformat som stöds](/slides/sv/androidjava/supported-file-formats/).

## **Undantag**

**Q: Jag får ett out of memory‑undantag när jag laddar en stor PPT‑fil med bilder. Finns det någon begränsning i Aspose.Slides angående filstorlek?**

**A**: Det finns ingen specifik formel för att beräkna den presentationsstorlek som stöds av Aspose.Slides. Det bör finnas tillräckligt med utrymme för att rymma hela presentationsstrukturen och bilderna i minnet. Vanligtvis tar bilder i minnet upp mer utrymme än på hårddisken, särskilt när bilder har ytterligare effekter.

Generellt kan Aspose.Slides för Android via Java enkelt hantera presentationsfiler på omkring 300 MB på en server med 4 GB RAM.

## **Arbeta med bilder**

**Q: Kan jag ändra storleken på bilderna i en presentation?**

**A**: Du kan använda metoden `getSlideSize` som exponeras av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/) för att definiera storleken på bilderna i en presentation.

**Q: Finns det ett sätt att definiera bilder av olika storlek i en presentation?**

**A**: Eftersom bildstorleken definieras på presentationsnivå i Microsoft PowerPoint‑dokument finns det inget sätt att göra detta.

**Q: Stöder Aspose.Slides för Android via Java förhandsgranskning av en bild innan den sparas?**

**A**: Du kan rendera presentationsbilder till bilder och använda dessa bilder för att förhandsgranska bilderna.

## **Arbeta med text**

**Q: Är det möjligt att hämta all text från en presentation?**

**A**: Aspose.Slides för Android via Java tillhandahåller klassen [SlideUtil](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/slideutil/) som erbjuder olika metoder för att hämta hela texten från presentationerna.

**Q: Varför är stycke­storlekar olika på PC och Android?**

**A**: Beräkningen av stycke­storlekar baseras på beräkningen av textstorleken som representerar det aktuella stycket. Textstorleksberäkningen bygger på de metriker för det teckensnitt som anges i PowerPoint‑presentationen. Om det angivna teckensnittet saknas ersätts det med det mest liknande teckensnittet, men detta teckensnitt har olika metriska värden än originalet. Som ett resultat leder beräkningen av stycke­storlekar i olika system till olika resultat beroende på vilka teckensnitt som är installerade. För att uppnå samma resultat på olika operativsystem måste du installera samma teckensnitt på systemen eller ladda dem vid körning som [externa teckensnitt](/slides/sv/androidjava/custom-font/).

## **Formatering och bilder**

**Q: Hur kan jag ange färgen på en tabellram?**

**A**: Du kan ändra färgen på alla tabellramar eller bara ramen runt hela tabellen. För att ändra alla ramar, använd metoden `getCellFormat` från gränssnittet [ICell](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/icell/). För ramen runt hela tabellen bör du iterera över celler och ändra färgen på de yttre ramarna.

**Q: Vilken måttenhet använder Aspose.Slides för Android via Java för att placera bilder?**

**A**: Koordinaterna och storlekarna på alla former på bilderna mäts i punkter (72 dpi).

## **Arbeta med teckensnitt**

**Q: När jag konverterar PPT till PDF eller bilder, varför är teckensnitten olika i utdata‑dokumenten?**

**A**: Detta problem kan indikera att de teckensnitt som används i presentationen saknas i operativsystemet där koden kördes. Du bör installera teckensnitten i operativsystemet eller ladda dem som externa teckensnitt med hjälp av klassen [FontsLoader](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fontsloader/) som visas nedan:
```java
String[] folders = new String[] { "path_to_a_folder_with_fonts" };
FontsLoader.loadExternalFonts(folders);
```