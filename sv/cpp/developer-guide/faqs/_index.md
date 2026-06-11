---
title: Vanliga frågor
type: docs
weight: 340
url: /sv/cpp/faqs/
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
- C++
- Aspose.Slides
description: "Få svar på vanliga frågor om Aspose.Slides för C++, som täcker stöd för PowerPoint och OpenDocument, installationsvägledning, licensiering och felsökning."
---
## **Översikt**

Denna FAQ ger svar på vanliga frågor om Aspose.Slides. Den täcker stöd för filformat, hantering av undantag vid arbete med stora presentationer, ändring av bildstorlekar, förhandsgranskning av slides, hämtning av text från presentationer, formatering av tabellramar, placering av bilder och lösning av teckensnittsrelaterade problem vid konvertering av presentationer till PDF eller bilder.

## **Filformat som stöds**

**Q: Vilka filformat stöder Aspose.Slides för C++?**

**A**: Aspose.Slides för C++ stödjer de filformat som beskrivs i [Supported File Formats](/slides/sv/cpp/supported-file-formats/).

## **Undantag**

**Q: Jag får ett out of memory‑undantag när jag laddar en stor PPT‑fil med bilder. Finns det en begränsning i Aspose.Slides när det gäller filstorlek?**

**A**: Det finns ingen specifik formel för att beräkna den presentationsstorlek som stöds av Aspose.Slides. Det bör finnas tillräckligt med utrymme för att rymma hela presentationsstrukturen och bilderna i minnet. Normalt tar bilder i minnet mer plats än på hårddisken, särskilt när bilder har ytterligare effekter.

Generellt kan Aspose.Slides för C++ enkelt hantera presentationsfiler på omkring 300 MB på en server med 4 GB RAM.

## **Arbeta med Slides**

**Q: Kan jag ändra storleken på slides i en presentation?**

**A**: Du kan använda metoden `get_SlideSize` som exponeras av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) för att definiera storleken på slides i en presentation.

**Q: Finns det ett sätt att definiera slides med olika storlek i en presentation?**

**A**: Eftersom storleken på slides definieras på presentationsnivå i Microsoft PowerPoint‑dokument finns det inget sätt att göra detta.

**Q: Stöder Aspose.Slides för C++ förhandsgranskning av en slide innan den sparas?**

**A**: Du kan rendera presentationsslides till bilder och använda dessa bilder för att förhandsgranska slides.

## **Arbeta med text**

**Q: Är det möjligt att hämta all text från en presentation?**

**A**: Aspose.Slides för C++ tillhandahåller klassen [SlideUtil](https://reference.aspose.com/slides/sv/cpp/aspose.slides.util/slideutil/) under namnområdet `Aspose::Slides::Util` som erbjuder olika metoder för att hämta hela texten från presentationerna.

**Q: Varför är stycke‑storlekar olika på Windows‑ och Linux‑operativsystem?**

**A**: Beräkningen av styckestorlekar baseras på beräkningen av textstorleken som representerar det aktuella stycket. Textstorleksberäkningen bygger på måtten för det teckensnitt som anges i PowerPoint‑presentationen. Om det angivna teckensnittet saknas ersätts det med det mest liknande teckensnittet, men detta teckensnitt har andra mått än de ursprungliga. Som ett resultat leder beräkningen av styckestorlekar i olika system till olika resultat beroende på vilka teckensnitt som är installerade. För att uppnå samma resultat på olika operativsystem måste du installera samma teckensnitt på systemen eller läsa in dem vid körning som [external fonts](/slides/sv/cpp/custom-font/).

## **Formatering och bilder**

**Q: Hur kan jag ange färgen på en tabellram?**

**A**: Du kan ändra färgen på alla tabellramar eller bara ramen runt hela tabellen. För att ändra alla ramar, använd metoden `get_CellFormat` från gränssnittet [ICell](https://reference.aspose.com/slides/sv/cpp/aspose.slides/icell/). För ramen runt hela tabellen bör du iterera över cellerna och ändra färgen på de yttre ramarna.

**Q: Vilken måttenhet använder Aspose.Slides för C++ för att placera bilder?**

**A**: Koordinaterna och storlekarna för alla former på slides mäts i punkter (72 dpi).

## **Arbeta med teckensnitt**

**Q: När PPT konverteras till PDF eller bilder, varför är teckensnitten olika i resultatdokumenten?**

**A**: Detta problem kan indikera att de teckensnitt som används i presentationen saknas i operativsystemet där koden kördes. Du bör installera teckensnitten i operativsystemet eller läsa in dem som externa teckensnitt med hjälp av klassen [FontsLoader](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsloader/) enligt nedan:
```cpp
auto folders = MakeObject<Array<String>>(1, "path_to_a_folder_with_fonts");
FontsLoader::LoadExternalFonts(folders);
```