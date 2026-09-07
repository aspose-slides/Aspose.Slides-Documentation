---
title: "Veelgestelde vragen"
type: docs
weight: 340
url: /nl/python-java/faqs/
keywords:
- "FAQ"
- "presentatieformat"
- "out-of-memory fout"
- "diaformaat"
- "tekst extraheren"
- "alineaformaat"
- "tabelranden"
- "lettertype"
- "PowerPoint"
- "OpenDocument"
- "presentatie"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Vind antwoorden op veelgestelde vragen over Aspose.Slides for Python via Java, inclusief bestandsformaten, geheugengebruik, diaformaten, tekst, tabellen, afbeeldingen en lettertypen."
---
## **Overzicht**

## **FAQ**

### **Ondersteunde bestandsformaten**

**Welke bestandsformaten ondersteunt Aspose.Slides for Python via Java?**

Zie [Ondersteunde bestandsformaten](/slides/nl/python-java/supported-file-formats/) voor de ondersteunde presentatie‑, document‑ en afbeeldingsformaten en hun import‑ en exportmogelijkheden.

### **Uitzonderingen**

**Waarom krijg ik een out-of-memory‑fout bij het laden van een grote presentatie met afbeeldingen? Is er een limiet voor de bestandsgrootte?**

Er bestaat geen enkele bestands‑groottegrens die voorspelt of een presentatie in het geheugen past. Het geheugen‑verbruik hangt af van de structuur van de presentatie, gedecomprimeerde afbeeldingen, effecten en de bewerkingen die je uitvoert. Afbeeldingen kunnen veel meer geheugen innemen dan hun gecomprimeerde bestandsgrootte.

Aspose.Slides for Python via Java gebruikt de Java‑engine via JPype, dus de JVM‑heap moet voldoende ruimte hebben voor de verwerking. De beschikbare systeem‑RAM alleen geeft niet aan hoeveel geheugen de JVM kan gebruiken. Maak presentaties vrij met [Presentation.dispose](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#dispose) wanneer je ze niet meer nodig hebt. Voor de omgeving‑configuratie, zie [Systeemvereisten](/slides/nl/python-java/system-requirements/) en [Installatie](/slides/nl/python-java/installation/).

### **Werken met dia's**

**Kan ik de afmeting van de dia's in een presentatie wijzigen?**

Ja. Gebruik [Presentation.getSlideSize](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getslidesize) om de dia‑afmetingsinstellingen van de presentatie op te halen, gebruik vervolgens [SlideSize.setSize](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidesize/#setsize) om de afmetingen in te stellen en te kiezen hoe bestaande inhoud wordt geschaald.

**Kunnen dia's in dezelfde presentatie verschillende afmetingen hebben?**

Nee. Microsoft PowerPoint‑documenten definiëren de dia‑grootte op presentatieniveau, waardoor alle dia's dezelfde afmetingen delen.

**Kan ik een dia vooraf bekijken voordat ik de presentatie opsla?**

Ja. Render de dia naar een afbeelding en toon die afbeelding in je applicatie. Je hoeft de presentatie niet eerst op te slaan.

### **Werken met tekst**

**Kan ik alle tekst uit een presentatie ophalen?**

Ja. De klasse [SlideUtil](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slideutil/) biedt methoden om tekst uit presentaties en individuele dia's op te halen.

**Waarom zijn alinea‑groottes verschillend onder Windows en Linux?**

De afmetingen van alinea’s hangen af van de metriek van de lettertypen die worden gebruikt om de tekst weer te geven. Als een lettertype ontbreekt, kan een vervangend lettertype andere teken‑breedtes en lijnhoogtes hebben, waardoor het regel‑omloop en de alinea‑afmetingen veranderen. Installeer dezelfde lettertypen op beide systemen of laad dezelfde lettertypebestanden met [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsloader/#loadexternalfonts) voordat je presentaties maakt of laadt.

### **Opmaak en afbeeldingen**

**Hoe kan ik de kleur van een tabelrand instellen?**

Gebruik [Cell.getCellFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/cell/#getcellformat) om de rand‑opmaak van elke cel op te halen en stel de vul‑kleur in voor de betreffende randen. Om elke rand te wijzigen, verwerk alle cellen. Om alleen de buitenrand van de tabel te wijzigen, werk alleen de naar buiten gerichte randen van de cellen langs de randen van de tabel bij.

**Welke eenheden worden gebruikt om afbeeldingen te positioneren en af te meten?**

Coördinaten en afmetingen van vormen worden gemeten in points. Eén inch is gelijk aan 72 points; dit zijn geen pixel‑coördinaten.

### **Werken met lettertypen**

**Waarom veranderen lettertypen wanneer ik een presentatie converteer naar PDF of afbeeldingen?**

De benodigde lettertypen kunnen ontbreken op de machine die de conversie uitvoert. Installeer de originele lettertypen of gebruik [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsloader/#loadexternalfonts) om mappen met deze lettertypen toe te voegen. Laad externe lettertypen voordat je presentaties maakt of opent.

Het volgende voorbeeld registreert een lettertype‑map. Vervang het pad door een bestaande map die jouw lettertypebestanden bevat. Het gaat ervan uit dat de omgeving zoals beschreven in [Installatie](/slides/nl/python-java/installation/) van toepassing is.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontsLoader

font_folders = jpype.JArray(jpype.JString)(["path_to_a_folder_with_fonts"])
FontsLoader.loadExternalFonts(font_folders)
```

Het voorbeeld houdt de JVM actief voor vervolg‑presentatie‑bewerkingen. Voor gebruik in notebooks en JVM‑levenscyclus‑beperkingen, zie [Beperkingen en API‑verschillen](/slides/nl/python-java/limitations-and-api-differences/).