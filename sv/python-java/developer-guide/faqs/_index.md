---
title: "Vanliga frågor"
type: docs
weight: 340
url: /sv/python-java/faqs/
keywords:
- "Vanliga frågor"
- "presentationsformat"
- "minnesbristfel"
- "bildstorlek"
- "extrahera text"
- "styckestorlek"
- "tabellramar"
- "teckensnitt"
- "PowerPoint"
- "OpenDocument"
- "presentation"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Få svar på vanliga frågor om Aspose.Slides för Python via Java, inklusive filformat, minnesanvändning, bildstorlekar, text, tabeller, bilder och teckensnitt."
---
## **Översikt**

Denna FAQ täcker stödda filformat, minnesanvändning med stora presentationer, bildstorlekar och förhandsvisningar, textutdrag, tabellramar, bildplacering och teckensnittsskillnader när presentationer konverteras till PDF eller bilder.

## **FAQ**

### **Stödda filformat**

**Vilka filformat stöder Aspose.Slides för Python via Java?**

Se [Stödda filformat](/slides/sv/python-java/supported-file-formats/) för de stödda presentations-, dokument- och bildformaten samt deras import‑ och exportmöjligheter.

### **Undantag**

**Varför får jag ett minnesbristfel när jag läser in en stor presentation med bilder? Finns det någon filstorleksgräns?**

Det finns ingen enskild filstorleksgräns som förutsäger om en presentation får plats i minnet. Minnesbehoven beror på presentationsstrukturen, de dekomprimerade bilderna, effekter och de operationer du utför. Bilder kan uppta mycket mer minne än deras komprimerade storlek på disk.

Aspose.Slides för Python via Java använder Java‑motorn via JPype, så JVM‑heapen måste ha tillräckligt med utrymme för bearbetning. Tillgängligt RAM på systemet visar inte hur mycket minne JVM kan använda. Frigör presentationer med [Presentation.dispose](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#dispose) när du är klar med dem. För miljöinställningar, se [System Requirements](/slides/sv/python-java/system-requirements/) och [Installation](/slides/sv/python-java/installation/).

### **Arbeta med bilder**

**Kan jag ändra storleken på bilderna i en presentation?**

Ja. Använd [Presentation.getSlideSize](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getslidesize) för att hämta presentationens bildstorleksinställningar och sedan [SlideSize.setSize](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidesize/#setsize) för att ange dimensionerna och välja hur befintligt innehåll skalas.

**Kan bilder i samma presentation ha olika storlekar?**

Nej. Microsoft PowerPoint‑dokument definierar bildstorleken på presentationsnivå, så alla bilder delar samma dimensioner.

**Kan jag förhandsgranska en bild innan jag sparar presentationen?**

Ja. Rendera bilden till en bildfil och visa den i ditt program. Du behöver inte spara presentationen först.

### **Arbeta med text**

**Kan jag hämta all text från en presentation?**

Ja. Klassen [SlideUtil](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slideutil/) erbjuder metoder för att hämta text från presentationer och enskilda bilder.

**Varför är stycke storlekar olika på Windows och Linux?**

Styckedimensioner beror på de teckensnitt du använder för att rendera texten. Om ett teckensnitt saknas kan ett substitut ha andra teckenbredder och radavstånd, vilket förändrar radbrytning och styckedimensioner. Installera samma teckensnitt på båda systemen eller ladda samma teckensnittsfiler med [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsloader/#loadexternalfonts) innan du skapar eller läser in presentationer.

### **Formatering och bilder**

**Hur kan jag sätta färgen på en tabellram?**

Använd [Cell.getCellFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/cell/#getcellformat) för att komma åt varje cells ramformat och ange fyllnadsfärgen för de aktuella ramarna. För att ändra varje ram, behandla alla celler. För att bara ändra konturen på tabellen, uppdatera endast de yttre ramarna på cellerna längs dess kanter.

**Vilka enheter används för att placera och storleksbestämma bilder?**

Formkoordinater och dimensioner mäts i punkter. En tum motsvarar 72 punkter; dessa värden är inte pixelkoordinater.

### **Arbeta med typsnitt**

**Varför förändras typsnitt när jag konverterar en presentation till PDF eller bilder?**

De nödvändiga teckensnitten kan saknas på maskinen som utför konverteringen. Installera originalteckensnitten eller använd [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsloader/#loadexternalfonts) för att lägga till mappar som innehåller dem. Ladda externa teckensnitt innan du skapar eller öppnar presentationer.

Följande exempel registrerar en teckensnittsmapp. Byt ut sökvägen mot en befintlig mapp som innehåller dina teckensnittsfiler. Det förutsätter miljön som beskrivs i [Installation](/slides/sv/python-java/installation/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontsLoader

font_folders = jpype.JArray(jpype.JString)(["path_to_a_folder_with_fonts"])
FontsLoader.loadExternalFonts(font_folders)
```

Exemplet låter JVM fortsätta köras för efterföljande presentationsoperationer. För användning i notebookar och begränsningar av JVM‑livscykeln, se [Limitations and API Differences](/slides/sv/python-java/limitations-and-api-differences/).