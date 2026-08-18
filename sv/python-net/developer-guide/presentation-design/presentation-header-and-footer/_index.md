---
title: Hantera presentationens rubriker och sidfötter med Python
linktitle: Rubrik och sidfot
type: docs
weight: 140
url: /sv/python-net/presentation-header-and-footer/
keywords:
- rubrik
- rubriktext
- sidfot
- sidfotstext
- sätt rubrik
- sätt sidfot
- utdelning
- anteckningar
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Lär dig hur du hanterar sidfot, datum/tid, bildnummer och rubrikplatshållare på bilder, anteckningssidor och utdelningar med Aspose.Slides för Python via .NET."
---
## **Översikt**

PowerPoint använder olika rubrik- och sidfotplatshållare beroende på sidtyp. Aspose.Slides för Python via .NET låter dig styra texten och synligheten för dessa platshållare via rubrik-/sidfot‑hanterarklasser.

| Omfång | Rubrik | Sidfot | Datum/tid | Bild-/sidnummer |
|---|---|---|---|---|
| Vanlig bild | Nej | Ja | Ja | Ja |
| Anteckningsmall | Ja | Ja | Ja | Ja |
| Anteckningsbild | Ja | Ja | Ja | Ja |
| Utdelningsmall | Ja | Ja | Ja | Ja |

En vanlig presentationsbild har ingen rubrikplatshållare. Rubriker är tillgängliga på anteckningssidor och utdelningar. För vanliga bilder, använd sidfot-, datum/tid- och bild‑/sidnummer‑platshållare istället.

Omfånget för en ändring beror på vilken hanterare du använder. Klassen [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slideheaderfootermanager/) styr en enskild vanlig bild. Klassen [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/python-net/aspose.slides/notesslideheaderfootermanager/) styr en enskild anteckningsbild. Master‑ och layout‑hanterare kan också sprida inställningar till beroende bilder, medan klassen [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/python-net/aspose.slides/masterhandoutslideheaderfootermanager/) styr utdelnings‑mastern.

## **Ange sidfot, datum/tid och bildnummer på vanliga bilder**

För vanliga bilder är det grundläggande arbetsflödet att komma åt varje bilds rubrik-/sidfot‑hanterare, ange sidfot‑ och datum/tid‑texten, aktivera de nödvändiga platshållarna och spara presentationen. Bildnummer genereras av presentationen, så du behöver bara kontrollera deras synlighet.

Använd [`set_footer_text`](https://reference.aspose.com/slides/sv/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_text/) och [`set_date_time_text`](https://reference.aspose.com/slides/sv/python-net/aspose.slides/baseslideheaderfootermanager/set_date_time_text/) för att ange text, och använd [`set_footer_visibility`](https://reference.aspose.com/slides/sv/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_visibility/), [`set_date_time_visibility`](https://reference.aspose.com/slides/sv/python-net/aspose.slides/baseslideheaderfootermanager/set_date_time_visibility/), och [`set_slide_number_visibility`](https://reference.aspose.com/slides/sv/python-net/aspose.slides/baseslideheaderfootermanager/set_slide_number_visibility/) för att visa motsvarande platshållare.

Följande end‑to‑end‑exempel tillämpar samma sidfot, datum/tid‑text och bildnummer‑synlighet på alla vanliga bilder:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        header_footer_manager = slide.header_footer_manager

        header_footer_manager.set_footer_text("Company Confidential")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_slide_footers.pptx", slides.export.SaveFormat.PPTX)
```

Om du bara behöver uppdatera en bild, komma åt den bilden direkt via samlingen [`slides`](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/slides/sv/) istället för att iterera igenom hela samlingen.

## **Ange rubriker och sidfötter på anteckningsmallen**

Anteckningsmallen definierar gemensamt format och platshållarbeteende för anteckningssidor. Använd klassen [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/python-net/aspose.slides/masternotesslideheaderfootermanager/) när du vill ändra endast anteckningsmallen i sig.

Följande exempel anger rubrik, sidfot och datum/tid‑text på anteckningsmallen och gör alla stödda platshållare synliga på den mallen:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        header_footer_manager.set_header_text("Notes header")
        header_footer_manager.set_header_visibility(True)

        header_footer_manager.set_footer_text("Notes footer")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_notes_master_footers.pptx", slides.export.SaveFormat.PPTX)
```

En presentation kan sakna en anteckningsmall, så kontrollera det returnerade värdet för `None` innan du ändrar det.

## **Tillämpa inställningar för anteckningsmallen på underordnade anteckningsbilder**

En anteckningsmall kan tillämpa rubrik‑ och sidfotinställningar på sig själv och på alla beroende anteckningsbilder. Använd de specifika spridningsmetoderna på [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/python-net/aspose.slides/masternotesslideheaderfootermanager/) när samma inställningar ska tillämpas i hela anteckningshierarkin.

Till exempel uppdaterar [`set_header_and_child_headers_text`](https://reference.aspose.com/slides/sv/python-net/aspose.slides/masternotesslideheaderfootermanager/set_header_and_child_headers_text/) och [`set_header_and_child_headers_visibility`](https://reference.aspose.com/slides/sv/python-net/aspose.slides/masternotesslideheaderfootermanager/set_header_and_child_headers_visibility/) anteckningsmallens rubrik och alla underordnade rubriker. Äquivalenta metoder finns för sidfötter, datum/tid och bildnummer.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        header_footer_manager.set_header_and_child_headers_text("Notes header")
        header_footer_manager.set_header_and_child_headers_visibility(True)

        header_footer_manager.set_footer_and_child_footers_text("Notes footer")
        header_footer_manager.set_footer_and_child_footers_visibility(True)

        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)

    presentation.save("presentation_with_child_notes_footers.pptx", slides.export.SaveFormat.PPTX)
```

Spridningsmetoderna som användes ovan är [`set_footer_and_child_footers_text`](https://reference.aspose.com/slides/sv/python-net/aspose.slides/masternotesslideheaderfootermanager/set_footer_and_child_footers_text/), [`set_footer_and_child_footers_visibility`](https://reference.aspose.com/slides/sv/python-net/aspose.slides/masternotesslideheaderfootermanager/set_footer_and_child_footers_visibility/), [`set_date_time_and_child_date_times_text`](https://reference.aspose.com/slides/sv/python-net/aspose.slides/masternotesslideheaderfootermanager/set_date_time_and_child_date_times_text/), [`set_date_time_and_child_date_times_visibility`](https://reference.aspose.com/slides/sv/python-net/aspose.slides/masternotesslideheaderfootermanager/set_date_time_and_child_date_times_visibility/), och [`set_slide_number_and_child_slide_numbers_visibility`](https://reference.aspose.com/slides/sv/python-net/aspose.slides/masternotesslideheaderfootermanager/set_slide_number_and_child_slide_numbers_visibility/).

## **Ange rubriker och sidfötter på en enskild anteckningsbild**

En anteckningsbild hör till en specifik vanlig bild. Använd dess klass [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/python-net/aspose.slides/notesslideheaderfootermanager/) när du vill anpassa endast den anteckningssidan.

[`add_notes_slide`](https://reference.aspose.com/slides/sv/python-net/aspose.slides/notesslidemanager/add_notes_slide/)‑metoden returnerar anteckningsbilden för den aktuella bilden och skapar en om den inte redan finns. Följande exempel konfigurerar anteckningssidan som är kopplad till den första presentationsbilden:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    notes_slide = presentation.slides[0].notes_slide_manager.add_notes_slide()
    header_footer_manager = notes_slide.header_footer_manager

    header_footer_manager.set_header_text("Header for the first notes page")
    header_footer_manager.set_header_visibility(True)

    header_footer_manager.set_footer_text("Footer for the first notes page")
    header_footer_manager.set_footer_visibility(True)

    header_footer_manager.set_date_time_text("Date and time text")
    header_footer_manager.set_date_time_visibility(True)

    header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_custom_notes_footers.pptx", slides.export.SaveFormat.PPTX)
```

Om du först sprider inställningar från anteckningsmallen och sedan ändrar en enskild anteckningsbild, låter de senare per‑bild‑inställningarna dig anpassa den anteckningssidan oberoende.

## **Ange rubriker och sidfötter på utdelningsmallen**

Utdelningssidor använder utdelnings‑mastern för sina rubrik‑, sidfot‑, datum/tid‑ och sidnummer‑platshållare. Till skillnad från anteckningssidor hanteras utdelningsinställningar via utdelnings‑mastern snarare än via enskilda utdelningsbilder.

Använd egenskapen [`master_handout_slide`](https://reference.aspose.com/slides/sv/python-net/aspose.slides/imasterhandoutslidemanager/master_handout_slide/) för att komma åt utdelnings‑mastern. Om den inte finns, anropa [`set_default_master_handout_slide`](https://reference.aspose.com/slides/sv/python-net/aspose.slides/imasterhandoutslidemanager/set_default_master_handout_slide/) för att skapa standard‑utdelnings‑mastern.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_handout_slide = presentation.master_handout_slide_manager.master_handout_slide

    if master_handout_slide is None:
        presentation.master_handout_slide_manager.set_default_master_handout_slide()
        master_handout_slide = presentation.master_handout_slide_manager.master_handout_slide

    if master_handout_slide is not None:
        header_footer_manager = master_handout_slide.header_footer_manager

        header_footer_manager.set_header_text("Handout header")
        header_footer_manager.set_header_visibility(True)

        header_footer_manager.set_footer_text("Handout footer")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_handout_footers.pptx", slides.export.SaveFormat.PPTX)
```

## **Förstå omfång och arv**

Välj den rubrik-/sidfot‑hanterare som matchar det omfång du vill ändra:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slideheaderfootermanager/) ändrar sidfot-, datum/tid- och bildnummer‑inställningar för en vanlig bild.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/python-net/aspose.slides/layoutslideheaderfootermanager/) styr en layout‑bild och kan sprida stödda inställningar till beroende bilder.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/python-net/aspose.slides/masterslideheaderfootermanager/) styr en vanlig bild‑master och kan sprida stödda inställningar till beroende bilder.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/python-net/aspose.slides/masternotesslideheaderfootermanager/) styr anteckningsmallen och kan sprida inställningar till alla beroende anteckningsbilder.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/python-net/aspose.slides/notesslideheaderfootermanager/) ändrar en anteckningsbild och stöder en rubrik‑platshållare utöver sidfot, datum/tid och bildnummer.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/python-net/aspose.slides/masterhandoutslideheaderfootermanager/) ändrar utdelnings‑mastern och stöder alla fyra platshållartyper.

Använd spridning från en master‑ eller layout‑hanterare när samma inställning ska gälla i hela dess hierarki. Använd en enskild bild‑ eller antecknings‑bild‑hanterare när du behöver en lokal inställning för en sida.

## **FAQ**

**Kan jag lägga till en rubrik på en vanlig bild?**

Nej. PowerPoint definierar ingen rubrikplatshållare för vanliga bilder. På vanliga bilder använder du sidfot-, datum/tid- och bildnummer‑platshållare. Rubrikplatshållare finns på anteckningssidor och utdelningar.

**Vad händer om en sidfot-, datum/tid- eller bildnummer‑platshållare inte är synlig?**

Använd den motsvarande rubrik-/sidfot‑hanteraren för att kontrollera dess synlighet och aktivera den vid behov. Till exempel rapporterar [`is_footer_visible`](https://reference.aspose.com/slides/sv/python-net/aspose.slides/baseslideheaderfootermanager/is_footer_visible/) om en sidfot‑platshållare finns, och [`set_footer_visibility`](https://reference.aspose.com/slides/sv/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_visibility/) ändrar dess synlighet.

**Hur startar jag bildnumrering från ett annat värde än 1?**

Ställ in presentationens egenskap [`first_slide_number`](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/first_slide_number/). Bildnummer‑platshållarna använder då den uppdaterade nummersekvensen.

**Vad händer med rubriker och sidfötter vid export till PDF, bilder eller HTML?**

Synliga rubrik‑ och sidfotelement renderas tillsammans med resten av presentationsinnehållet i det exporterade formatet. Deras utseende beror på vilken sidtyp som exporteras och de motsvarande inställningarna för platshållarsynlighet.