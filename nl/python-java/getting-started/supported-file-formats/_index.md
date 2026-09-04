---
title: Ondersteunde bestandsformaten
type: docs
weight: 30
url: /nl/python-java/supported-file-formats/
keywords:
- ondersteunde bestandsformaten
- presentatieformaten
- PowerPoint
- OpenDocument
- PPT
- PPTX
- ODP
- PDF
- HTML
- dia-afbeeldingen
- Python
- Aspose.Slides for Python via Java
description: "Ontdek de presentatie-, document-, web- en afbeeldingsformaten die Aspose.Slides for Python via Java kan laden, importeren, opslaan en exporteren."
---
## **Overzicht**

Aspose.Slides for Python via Java leest en schrijft PowerPoint- en OpenDocument‑presentaties. Het importeert ook PDF‑ en HTML‑inhoud in dia's en exporteert presentaties of individuele dia's naar document-, web- en afbeeldingsformaten.

De tabel hieronder onderscheidt het laden van presentaties van inhoudsimport en dia‑weergave. Voor een overzicht van bewerkings‑ en weergavemogelijkheden, zie [Functies Overzicht](/slides/nl/python-java/features-overview/).

## **Ondersteunde Microsoft PowerPoint‑versies**

- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003
- Microsoft PowerPoint 2007
- Microsoft PowerPoint 2010
- Microsoft PowerPoint 2013
- Microsoft PowerPoint 2016
- Microsoft PowerPoint 2019
- Microsoft PowerPoint voor Mac
- PowerPoint voor Microsoft 365 (voorheen Office 365)

## **Ondersteunde bestandsformaten**

De onderstaande tabel geeft de ondersteunde invoer‑ en uitvoerformaten weer. **Load / Import** omvat het openen van presentatiebestanden en het importeren van PDF‑ of HTML‑inhoud. **Save / Export** omvat het opslaan van presentaties en het renderen van dia's naar afbeeldingen. Een streepje betekent dat de overeenkomstige bewerking niet wordt ondersteund als presentatieconversie‑bewerking.

|**Formaat**|**Beschrijving**|**Laden / Importeren**|**Opslaan / Exporteren**|**Opmerkingen**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|PowerPoint 97-2003 presentatie|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[POT](https://docs.fileformat.com/presentation/pot/)|PowerPoint 97-2003 sjabloon|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPS](https://docs.fileformat.com/presentation/pps/)|PowerPoint 97-2003 diavoorstelling|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|PowerPoint presentatie|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[POTX](https://docs.fileformat.com/presentation/potx/)|PowerPoint sjabloon|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|PowerPoint diavoorstelling|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|PowerPoint macro‑ingeschakelde presentatie|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|PowerPoint macro‑ingeschakelde diavoorstelling|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[POTM](https://docs.fileformat.com/presentation/potm/)|PowerPoint macro‑ingeschakelde sjabloon|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[ODP](https://docs.fileformat.com/presentation/odp/)|OpenDocument‑presentatie|{{< emoticons/tick >}}|{{< emoticons/tick >}}|Verpakte OpenDocument‑indeling.|
|FODP|Vlakke XML OpenDocument‑presentatie|{{< emoticons/tick >}}|{{< emoticons/tick >}}|Slaat de presentatie op als één enkel XML‑document.|
|[OTP](https://docs.fileformat.com/presentation/otp/)|OpenDocument‑presentatiesjabloon|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[TIFF](https://docs.fileformat.com/image/tiff/)|Tagged Image File Format|—|{{< emoticons/tick >}}|Ondersteunt meerpagina‑output.|
|[EMF](https://docs.fileformat.com/image/emf/)|Enhanced Metafile|—|{{< emoticons/tick >}}|Exporteert individuele dia's als vectorafbeeldingen.|
|[PDF](https://docs.fileformat.com/pdf/)|Portable Document Format|Import|{{< emoticons/tick >}}|Importeert PDF‑pagina's als dia's; exporteert presentaties naar PDF.|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML Paper Specification|—|{{< emoticons/tick >}}|Documentuitvoer met vaste lay-out.|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|JPEG‑afbeelding|—|{{< emoticons/tick >}}|Renderen individuele dia's als rasterafbeeldingen.|
|[PNG](https://docs.fileformat.com/image/png/)|Portable Network Graphics|—|{{< emoticons/tick >}}|Renderen individuele dia's als rasterafbeeldingen.|
|[GIF](https://docs.fileformat.com/image/gif/)|Graphics Interchange Format|—|{{< emoticons/tick >}}|Afbeeldingsoutput.|
|[BMP](https://docs.fileformat.com/image/bmp/)|Bitmap‑afbeelding|—|{{< emoticons/tick >}}|Renderen individuele dia's als rasterafbeeldingen.|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Scalable Vector Graphics|—|{{< emoticons/tick >}}|Exporteert individuele dia's als vectorafbeeldingen.|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Small Web Format|—|{{< emoticons/tick >}}|Flash-output.|
|[HTML](https://docs.fileformat.com/web/html/)|Hypertext Markup Language|Import|{{< emoticons/tick >}}|Importeert HTML‑inhoud als dia's; ondersteunt export naar HTML en HTML5.|
|[XAML](https://docs.fileformat.com/web/xaml/)|Extensible Application Markup Language|—|{{< emoticons/tick >}}|Exporteert presentatiewaarde als XAML.|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|{{< emoticons/tick >}}|Exporteert presentatiewaarde naar Markdown.|
|[XML](https://docs.fileformat.com/web/xml/)|PowerPoint XML‑presentatie|—|{{< emoticons/tick >}}|PowerPoint‑specifieke XML‑output, niet willekeurige XML.|

## **Import‑ en exportopmerkingen**

- **PDF- en HTML-import:** Gebruik [SlideCollection.addFromPdf](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidecollection/#addfrompdf) of [SlideCollection.addFromHtml](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidecollection/#addfromhtml) om dia's van broninhoud te maken en ze aan een presentatie toe te voegen.
- **Presentatie‑output:** [SaveFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/saveformat/) geeft een lijst weer van de beschikbare presentatiesave‑formaten, inclusief afzonderlijke HTML‑ en HTML5‑exportopties.
- **Afbeeldings‑output:** Het exporteren van een dia naar een afbeelding levert een visuele weergave van die dia op. De invoerkolom beschrijft niet of een afbeelding in een presentatie kan worden ingevoegd.

## **FAQ**

**Kan ik een PPT‑presentatie converteren naar PPTX of ODP?**

Ja. PPT wordt ondersteund als invoerformaat, en zowel PPTX als ODP worden ondersteund als uitvoerformaten. De conversieresultaten hangen af van de functies die beschikbaar zijn in het doelformaat.

**Opent PDF‑ of HTML‑import de bron als een PowerPoint‑bestand?**

Nee. Import maakt dia's aan van PDF‑pagina's of HTML‑inhoud. U kunt de resulterende presentatie vervolgens opslaan in een ondersteund presentatiefomaat.

**Kan ik een geëxporteerde PNG‑ of SVG‑afbeelding laden als een bewerkbare presentatie?**

Nee. Deze exports geven alleen het uiterlijk van de dia weer. Bewaar de bronpresentatie wanneer u later de tekst, vormen, grafieken en andere objecten wilt bewerken.