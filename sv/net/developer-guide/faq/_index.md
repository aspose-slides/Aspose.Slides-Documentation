---
title: "Vanliga frågor"
type: docs
weight: 340
url: /sv/net/faqs/
keywords:
- "Vanliga frågor"
- PowerPoint
- presentationsformat
- minnesbristfel
- bildstorlek
- extrahera text
- hämta text
- styckestorlek
- formatering av tabeller
- teckensnitt
- .NET
- C#
- Aspose.Slides
description: "Få svar på vanliga frågor om Aspose.Slides för .NET, som täcker stöd för PowerPoint och OpenDocument, installationsvägledning, licensiering och felsökning."
---
## **Översikt**

Denna FAQ ger svar på vanliga frågor om Aspose.Slides. Den täcker stöd för filformat, hantering av undantag vid arbete med stora presentationer, ändring av bildstorlekar, förhandsgranskning av bilder, hämtning av text från presentationer, formatering av tabellramar, placering av bilder samt lösning av teckensnittsrelaterade problem vid konvertering av presentationer till PDF eller bilder.

## **Stödda filformat**

**Q: Vilka filformat stöder Aspose.Slides för .NET?**

**A**: Aspose.Slides för .NET stöder de filformat som beskrivs i [Stödda filformat](/slides/sv/net/supported-file-formats/).

## **Undantag**

**Q: Jag får ett OutOfMemoryException när jag laddar en stor PPT-fil med bilder. Finns det någon begränsning i Aspose.Slides avseende filstorlek?**

**A**: Det finns ingen specifik formel för att beräkna den presentationsstorlek som Aspose.Slides stöder. Det bör finnas tillräckligt med minne för att rymma hela presentationsstrukturen och bilderna i minnet. Normalt tar bilder i minnet mer utrymme än på hårddisken, särskilt när bilder har ytterligare effekter.

Generellt kan Aspose.Slides för .NET enkelt hantera presentationsfiler på omkring 300 MB på en server med 4 GB RAM.

## **Arbeta med bilder**

**Q: Kan jag ändra storleken på bilderna i en presentation?**

**A**: Du kan använda egenskapen `SlideSize` som exponeras av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) för att definiera storleken på bilderna i en presentation.

**Q: Finns det ett sätt att definiera bilder med olika storlek i en presentation?**

**A**: Eftersom storleken på bilder definieras på presentationsnivå i Microsoft PowerPoint-dokument finns det inget sätt att göra detta.

**Q: Stöder Aspose.Slides för .NET förhandsgranskning av en bild innan den sparas?**

**A**: Du kan rendera presentationsbilderna till bilder och använda dessa bilder för att förhandsgranska dem.

## **Arbeta med text**

**Q: Är det möjligt att hämta all text från en presentation?**

**A**: Aspose.Slides för .NET tillhandahåller klassen [SlideUtil](https://reference.aspose.com/slides/sv/net/aspose.slides.util/slideutil/) i namnrymden `Aspose.Slides.Util` som erbjuder olika metoder för att hämta hela texten från presentationerna.

**Q: Varför är styckestorlekar olika på Windows- och Linux-operativsystem?**

**A**: Beräkningen av styckestorlekar baseras på beräkningen av textstorleken för det givna stycket. Textstorleksberäkningen bygger på metrikerna för det teckensnitt som specificerats i PowerPoint-presentationen. Om det specificerade teckensnittet saknas ersätts det med det mest liknande teckensnittet, men detta teckensnitt har metriker som skiljer sig från de ursprungliga. Därför leder beräkningen av styckestorlekar i olika system till olika resultat beroende på vilka teckensnitt som är installerade. För att uppnå samma resultat på olika operativsystem behöver du installera samma teckensnitt på systemen eller ladda dem vid körning som [externa teckensnitt](/slides/sv/net/custom-font/).

## **Formatering och bilder**

**Q: Hur kan jag ange färgen på en tabellram?**

**A**: Du kan ändra färgen på alla tabellramar eller bara ramen runt hela tabellen. För att ändra alla ramar, använd egenskapen `CellFormat` från gränssnittet [ICell](https://reference.aspose.com/slides/sv/net/aspose.slides/icell/). För ramen runt hela tabellen bör du iterera celler och ändra färgen på de yttre ramarna.

**Q: Vilken enhet använder Aspose.Slides för .NET för att placera bilder?**

**A**: Koordinaterna och storlekarna för alla former på bilderna mäts i punkter (72 dpi).

## **Arbeta med teckensnitt**

**Q: När man konverterar PPT till PDF eller bilder, varför är teckensnitten olika i resultatdokumenten?**

**A**: Detta problem kan tyda på att de teckensnitt som används i presentationen saknas på det operativsystem där koden kördes. Du bör installera teckensnitten på operativsystemet eller ladda dem som externa teckensnitt med hjälp av klassen [FontsLoader](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsloader/) som visas nedan:
```cs
var folders = new string[] { "path_to_a_folder_with_fonts" };
FontsLoader.LoadExternalFonts(folders);
```