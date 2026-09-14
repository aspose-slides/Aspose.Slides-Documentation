---
title: Hantera presentationens rubriker och sidfötter i Python via Java
linktitle: Rubrik och Sidfot
type: docs
weight: 140
url: /sv/python-java/presentation-header-and-footer/
keywords:
- rubrik
- rubriktext
- sidfot
- sidfottext
- ange rubrik
- ange sidfot
- utdelning
- anteckningar
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Lär dig hur du hanterar sidfot-, datum‑tid‑, bildnummer‑ och rubrik‑platshållare på bilder, anteckningssidor och utdelningar med Aspose.Slides för Python via Java."
---
## **Översikt**

PowerPoint använder olika rubrik- och sidfotplatshållare beroende på sidtyp. Aspose.Slides för Python via Java låter dig styra texten och synligheten för dessa platshållare via rubrik-/sidfot‑hanterarklasser.

Tillgängliga platshållare beror på omfånget:

| Omfång | Rubrik | Sidfot | Datum/tid | Bild/sidnummer |
|---|---|---|---|---|
| Vanlig bild | Nej | Ja | Ja | Ja |
| Anteckningsmaster | Ja | Ja | Ja | Ja |
| Anteckningsbild | Ja | Ja | Ja | Ja |
| Utdelningsmaster | Ja | Ja | Ja | Ja |

En vanlig presentationsbild har ingen rubrikplatshållare. Rubriker är tillgängliga på anteckningssidor och utdelningar. För vanliga bilder, använd sidfot-, datum/tid‑ och bildnumrerings‑platshållare i stället.

Omfånget för en ändring beror på vilken hanterare du använder. Klassen [SlideHeaderFooterManager](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slideheaderfootermanager/) styr en vanlig bild. Klassen [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/sv/python-java/aspose.slides/notesslideheaderfootermanager/) styr en anteckningsbild. Master‑ och layout‑hanterare kan också sprida inställningar till beroende bilder, medan klassen [MasterHandoutSlideHeaderFooterManager](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masterhandoutslideheaderfootermanager/) styr utdelnings‑mastern.

## **Ställ in sidfot, datum/tid och bildnummer på vanliga bilder**

För vanliga bilder är det grundläggande arbetsflödet att komma åt varje bilds rubrik-/sidfot‑hanterare, ange sidfot‑ och datum/tid‑text, aktivera de erforderliga platshållarna och spara presentationen. Bildnummer genereras av presentationen, så du behöver bara styra deras synlighet.

Använd [setFooterText](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterText) och [setDateTimeText](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeText) för att ange text, och använd [setFooterVisibility](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility), [setDateTimeVisibility](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility) samt [setSlideNumberVisibility](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility) för att visa motsvarande platshållare.

Följande helomfattande exempel tillämpar samma sidfot, datum/tid‑text och bildnumreringens synlighet på alla vanliga bilder:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        header_footer_manager = slide.getHeaderFooterManager()

        header_footer_manager.setFooterText("Company Confidential")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_slide_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Om du bara behöver uppdatera en bild, nå den bilden direkt via metoden [getSlides](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getSlides) i stället för att iterera genom hela samlingen.

## **Ställ in rubriker och sidfötter på anteckningsmastern**

Anteckningsmastern definierar gemensamt format och platshållarbeteende för anteckningssidor. Använd klassen [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masternotesslideheaderfootermanager/) när du bara vill ändra anteckningsmastern själv.

Följande exempel anger rubrik, sidfot och datum/tid‑text på anteckningsmastern och gör alla stödda platshållare synliga på den mastern:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_notes_slide = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderText("Notes header")
        header_footer_manager.setHeaderVisibility(True)

        header_footer_manager.setFooterText("Notes footer")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`getMasterNotesSlide`‑metoden returnerar `None` när presentationen inte innehåller en anteckningsmaster.

## **Tillämpa anteckningsmasterinställningar på underordnade anteckningsbilder**

En anteckningsmaster kan tillämpa rubrik‑ och sidfotinställningar på sig själv och på alla beroende anteckningsbilder. Använd de dedikerade spridningsmetoderna på [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masternotesslideheaderfootermanager/) när samma inställningar ska tillämpas över hela anteckningshierarkin.

Till exempel uppdaterar [setHeaderAndChildHeadersText](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersText) och [setHeaderAndChildHeadersVisibility](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility) anteckningsmasterns rubrik och alla underordnade rubriker. Motsvarande metoder finns för sidfötter, datum/tid och bildnummer.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_notes_slide = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderAndChildHeadersText("Notes header")
        header_footer_manager.setHeaderAndChildHeadersVisibility(True)

        header_footer_manager.setFooterAndChildFootersText("Notes footer")
        header_footer_manager.setFooterAndChildFootersVisibility(True)

        header_footer_manager.setDateTimeAndChildDateTimesText("Date and time text")
        header_footer_manager.setDateTimeAndChildDateTimesVisibility(True)

        header_footer_manager.setSlideNumberAndChildSlideNumbersVisibility(True)

    presentation.save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Spridningsmetoderna som används ovan är [setFooterAndChildFootersText](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersText), [setFooterAndChildFootersVisibility](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility), [setDateTimeAndChildDateTimesText](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText), [setDateTimeAndChildDateTimesVisibility](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility) och [setSlideNumberAndChildSlideNumbersVisibility](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility).

## **Ställ in rubriker och sidfötter på en enskild anteckningsbild**

En anteckningsbild hör till en specifik vanlig bild. Använd dess [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/sv/python-java/aspose.slides/notesslideheaderfootermanager/) klass när du bara vill anpassa den specifika anteckningssidan.

Metoden [addNotesSlide](https://reference.aspose.com/slides/sv/python-java/aspose.slides/notesslidemanager/#addNotesSlide) returnerar anteckningsbilden för den aktuella bilden och skapar en om den inte redan finns. Följande exempel konfigurerar anteckningssidan som är kopplad till den första presentationsbilden:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    header_footer_manager = notes_slide.getHeaderFooterManager()

    header_footer_manager.setHeaderText("Header for the first notes page")
    header_footer_manager.setHeaderVisibility(True)

    header_footer_manager.setFooterText("Footer for the first notes page")
    header_footer_manager.setFooterVisibility(True)

    header_footer_manager.setDateTimeText("Date and time text")
    header_footer_manager.setDateTimeVisibility(True)

    header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Om du först sprider inställningarna från anteckningsmastern och sedan ändrar en enskild anteckningsbild, låter de senare per‑bild‑inställningarna dig anpassa den anteckningssidan självständigt.

## **Ställ in rubriker och sidfötter på utdelnings‑mastern**

Utdelningssidor använder utdelnings‑mastern för deras rubrik-, sidfot-, datum/tid- och sidnumrerings‑platshållare. Till skillnad från anteckningssidor hanteras utdelningsinställningar via utdelnings‑mastern snarare än genom enskilda utdelningsbilder.

Använd metoden `getMasterHandoutSlide` för att komma åt utdelnings‑mastern. Om den saknas, anropa `setDefaultMasterHandoutSlide` för att skapa standard‑utdelnings‑mastern.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_handout_slide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide()

    if master_handout_slide is None:
        master_handout_slide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide()

    if master_handout_slide is not None:
        header_footer_manager = master_handout_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderText("Handout header")
        header_footer_manager.setHeaderVisibility(True)

        header_footer_manager.setFooterText("Handout footer")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_handout_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Förstå omfång och arv**

Välj den rubrik-/sidfot‑hanterare som matchar det omfång du vill ändra:

- [SlideHeaderFooterManager](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slideheaderfootermanager/) ändrar sidfot-, datum/tid- och bildnummerinställningar för en vanlig bild.
- [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/sv/python-java/aspose.slides/layoutslideheaderfootermanager/) styr en layout‑bild och kan sprida stödjade inställningar till beroende bilder.
- [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masterslideheaderfootermanager/) styr en vanlig bild‑master och kan sprida stödjade inställningar till beroende bilder.
- [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masternotesslideheaderfootermanager/) styr anteckningsmastern och kan sprida inställningar till alla beroende anteckningsbilder.
- [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/sv/python-java/aspose.slides/notesslideheaderfootermanager/) ändrar en anteckningsbild och stöder en rubrik‑platshållare utöver sidfot, datum/tid och bildnummer.
- [MasterHandoutSlideHeaderFooterManager](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masterhandoutslideheaderfootermanager/) ändrar utdelnings‑mastern och stöder alla fyra platshållartyper.

Använd spridning från en master‑ eller layout‑hanterare när samma inställning ska gälla genom hela dess hierarki. Använd en enskild bild‑ eller antecknings‑bild‑hanterare när du behöver en lokal inställning för en sida.

## **FAQ**

**Kan jag lägga till en rubrik på en vanlig bild?**

Nej. PowerPoint definierar ingen rubrik‑platshållare för vanliga bilder. På vanliga bilder använder du sidfot-, datum/tid‑ och bildnummer‑platshållare. Rubrik‑platshållare finns på anteckningssidor och utdelningar.

**Vad händer om en sidfot-, datum/tid- eller bildnummer‑platshållare inte är synlig?**

Använd motsvarande rubrik-/sidfot‑hanterare för att kontrollera dess synlighet och aktivera den vid behov. Till exempel rapporterar [isFooterVisible](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseslideheaderfootermanager/#isFooterVisible) huruvida en sidfot‑platshållare finns, och [setFooterVisibility](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility) ändrar dess synlighet.

**Hur startar jag bildnumreringen från ett värde annat än 1?**

Anropa presentationens [setFirstSlideNumber](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#setFirstSlideNumber) metod. Bildnummer‑platshållarna använder sedan den uppdaterade numreringssekvensen.

**Vad händer med rubriker och sidfötter vid export till PDF, bilder eller HTML?**

Synliga rubrik- och sidfotelement renderas tillsammans med resten av presentationsinnehållet i det exporterade formatet. Deras utseende beror på vilken sidtyp som exporteras och de motsvarande inställningarna för platshållarens synlighet.