---
title: Vanliga frågor
type: docs
weight: 340
url: /sv/python-net/faq/
keywords:
- Vanliga frågor
- presentationsformat
- minnesfel
- bildstorlek
- extrahera text
- hämta text
- styckestorlek
- formatera tabeller
- teckensnitt
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Få svar på vanliga frågor om Aspose.Slides för Python via .NET, som täcker stöd för PowerPoint och OpenDocument, installationsvägledning, licensiering och felsökning."
---
## **Översikt**

Denna FAQ ger svar på vanliga frågor om Aspose.Slides. Den täcker stödde filformat, hantering av undantag vid arbete med stora presentationer, ändring av bildstorlekar, förhandsgranskning av bilder, hämtning av text från presentationer, formatering av tabellramar, placering av bilder och lösning av teckensnittsrelaterade problem vid konvertering av presentationer till PDF eller bilder.

## **Stödda filformat**

**Q: Vilka filformat stöder Aspose.Slides för Python via .NET?**

**A**: Aspose.Slides för Python via .NET stöder de filformat som beskrivs i [Supported File Formats](/slides/sv/python-net/supported-file-formats/).

## **Undantag**

**Q: Jag får ett minnesutrymmesundantag när jag laddar en stor PPT-fil med bilder. Finns det någon begränsning i Aspose.Slides avseende filstorlek?**

**A**: Det finns ingen specifik formel för att beräkna den presentationstorlek som stöds av Aspose.Slides. Det bör finnas tillräckligt med utrymme för att rymma hela presentationsstrukturen och bilderna i minnet. Normalt upptar bilder i minnet mer utrymme än på hårddisken, särskilt när bilder har ytterligare effekter.

Generellt kan Aspose.Slides för Python via .NET enkelt hantera presentationsfiler på omkring 300 MB på en server med 4 GB RAM.

## **Arbeta med bilder**

**Q: Kan jag ändra storleken på bilderna i en presentation?**

**A**: Du kan använda egenskapen `slide_size` som exponeras av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) för att definiera storleken på bilderna i en presentation.

**Q: Finns det ett sätt att definiera bilder av olika storlek i en presentation?**

**A**: Eftersom storleken på bilder definieras på presentationsnivå i Microsoft PowerPoint-dokument finns det inget sätt att göra detta.

**Q: Stöder Aspose.Slides för Python via .NET förhandsgranskning av en bild innan den sparas?**

**A**: Du kan rendera presentationsbilderna till bilder och använda dessa bilder för att förhandsgranska bilderna.

## **Arbeta med text**

**Q: Är det möjligt att hämta all text från en presentation?**

**A**: Aspose.Slides för Python via .NET tillhandahåller klassen [SlideUtil](https://reference.aspose.com/slides/sv/python-net/aspose.slides.util/slideutil/) under namnutrymmet `aspose.slides.util` som erbjuder olika metoder för att hämta all text från presentationerna.

**Q: Varför är stycke‑storlekar olika på Windows- och Linux‑operativsystem?**

**A**: Beräkningen av stycke‑storlekar baseras på beräkningen av textstorleken som representerar det givna stycket. Textstorleksberäkningen bygger på metrikken för det teckensnitt som anges i PowerPoint‑presentationen. Om det angivna teckensnittet saknas ersätts det med det mest liknande teckensnittet, men detta teckensnitt har metrik som skiljer sig från originalet. Som ett resultat kommer beräkningen av stycke‑storlekar i olika system att ge olika resultat beroende på vilka teckensnitt som är installerade. För att uppnå samma resultat på olika operativsystem måste du installera samma teckensnitt på systemen eller ladda dem vid körning som [external fonts](/slides/sv/python-net/custom-font/).

## **Formatering och bilder**

**Q: Hur kan jag ange färgen på en tabellram?**

**A**: Du kan ändra färgen på alla tabellramar eller bara ramen runt hela tabellen. För att ändra alla ramar, använd egenskapen `cell_format` från klassen [Cell](https://reference.aspose.com/slides/sv/python-net/aspose.slides/cell/). För ramen runt hela tabellen bör du iterera över celler och ändra färgen på de yttre ramarna.

**Q: Vilken måttenhet använder Aspose.Slides för Python via .NET för att placera bilder?**

**A**: Koordinaterna och storlekarna för alla former på bilderna mäts i punkt (72 dpi).

## **Arbeta med teckensnitt**

**Q: När man konverterar PPT till PDF eller bilder, varför är teckensnitten olika i de resulterande dokumenten?**

**A**: Detta problem kan indikera att teckensnitten som används i presentationen saknas i operativsystemet där koden kördes. Du bör installera teckensnitten i operativsystemet eller ladda dem som externa teckensnitt med hjälp av klassen [FontsLoader](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontsloader/) som visas nedan:
```cs
folders = [ "path_to_a_folder_with_fonts" ]
aspose.slides.FontsLoader.load_external_fonts(folders)
```