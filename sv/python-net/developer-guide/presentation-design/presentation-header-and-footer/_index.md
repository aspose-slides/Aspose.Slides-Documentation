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
- presentation
- Python
- Aspose.Slides
description: "Använd Aspose.Slides for Python via .NET för att lägga till och anpassa rubriker och sidfötter i PowerPoint- och OpenDocument-presentationer för ett professionellt utseende."
---
## **Översikt**

Aspose.Slides for Python låter dig styra platshållare för rubriker och sidfot i hela en presentation med exakt omfattning. Sidfotens text, datum/tid och bildnummer på bilder hanteras på masternivå och kan tillämpas globalt eller justeras per bild. Rubriker stöds i anteckningar och utdelningar, där du kan växla synlighet och ange text för rubrik, sidfot, datum/tid och sidnummer via den dedikerade rubrik‑ och sidfot‑hanteraren på master‑anteckningsbilden eller enskilda anteckningsbilder. Denna artikel beskriver de viktigaste mönstren för att uppdatera dessa platshållare och sprida förändringar konsekvent i hela ditt bildspel.

## **Hantera rubrik‑ och sidfotstext**

I den här avsnittet kommer du att lära dig hur du hanterar rubrik‑ och sidfotinnehåll i en presentation — aktivera eller ändra sidfot, datum och tid samt bildnummer. Vi kommer kort att beskriva räckvidderna för att tillämpa dessa inställningar (hela presentationen, enskilda bilder och antecknings‑/utdelningsvyer) och visa hur du använder Aspose.Slides‑API:t för att uppdatera dem snabbt och konsekvent.

Kodexemplet nedan öppnar en presentation, aktiverar och sätter sidfotstexten, uppdaterar rubriktexten på master‑anteckningsbilden och sparar filen.

```py
import aspose.slides as slides

# Funktion för att ange rubriktexten.
def update_header_footer_text(master):
    for shape in master.shapes:
        if shape.placeholder is not None:
            if shape.placeholder.type == slides.PlaceholderType.HEADER:
                shape.text_frame.text = "Hi, there is a header"


# Läs in presentationen.
with slides.Presentation("sample.pptx") as presentation:
    # Ange sidfoten.
    presentation.header_footer_manager.set_all_footers_text("My Footer text")
    presentation.header_footer_manager.set_all_footers_visibility(True)

    # Kom åt och uppdatera rubriken.
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        update_header_footer_text(master_notes_slide)

    # Spara presentationen.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Hantera rubrik och sidfot på anteckningsbilder**

I det här avsnittet kommer du att lära dig hur du hanterar rubriker och sidfötter specifikt för anteckningsbilder i Aspose.Slides. Vi går igenom att aktivera relevanta platshållare, ange text för sidfötter, datum/tid och sidnummer, samt att tillämpa dessa förändringar konsekvent över antecknings‑mastern och enskilda anteckningssidor.

Följ stegen nedan:

1. Läs in en presentationsfil.  
1. Hämta master‑anteckningsbilden och dess [rubrik & sidfotshanterare](https://reference.aspose.com/slides/sv/python-net/aspose.slides/masternotesslideheaderfootermanager/).  
1. På master‑anteckningsbilden, aktivera synligheten för Header, Footer, Slide number och Date-time för mastern och alla underliggande anteckningsbilder.  
1. På master‑anteckningsbilden, sätt text för Header, Footer och Date-time för mastern och alla underliggande anteckningsbilder.  
1. Hämta anteckningsbilden för den första presentationsbilden och dess [rubrik & sidfotshanterare](https://reference.aspose.com/slides/sv/python-net/aspose.slides/notesslideheaderfootermanager/).  
1. För endast denna första anteckningsbild, säkerställ att Header, Footer, Slide number och Date-time är synliga (slå på de som är avstängda).  
1. För endast denna första anteckningsbild, sätt texten för Header, Footer och Date-time.  
1. Spara presentationen i PPTX-format.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        # Gör master‑anteckningsbilden och alla underliggande rubrik‑, sidfot‑, bildnummer‑ och datum/tids‑platshållare synliga.
        header_footer_manager.set_header_and_child_headers_visibility(True)
        header_footer_manager.set_footer_and_child_footers_visibility(True)
        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        # Ange text på master‑anteckningsbilden och alla underliggande rubrik‑, sidfot‑ och datum/tids‑platshållare.
        header_footer_manager.set_header_and_child_headers_text("Header text")
        header_footer_manager.set_footer_and_child_footers_text("Footer text")
        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    # Ändra rubrik‑, sidfot‑, bildnummer‑ och datum/tids‑inställningarna endast för den första anteckningsbilden.
    notesSlide = presentation.slides[0].notes_slide_manager.notes_slide
    if notesSlide is not None:
        header_footer_manager = notesSlide.header_footer_manager

        # Säkerställ att rubrik‑, sidfot‑, bildnummer‑ och datum/tids‑platshållarna är synliga.
        if not header_footer_manager.is_header_visible:
            header_footer_manager.set_header_visibility(True)

        if not header_footer_manager.is_footer_visible:
            header_footer_manager.set_footer_visibility(True)

        if not header_footer_manager.is_slide_number_visible:
            header_footer_manager.set_slide_number_visibility(True)

        if not header_footer_manager.is_date_time_visible:
            header_footer_manager.set_date_time_visibility(True)

        # Ange text på anteckningsbildens rubrik‑, sidfot‑ och datum/tids‑platshållare.
        header_footer_manager.set_header_text("New header text")
        header_footer_manager.set_footer_text("New footer text")
        header_footer_manager.set_date_time_text("New date and time text")

    # Spara presentationen.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kan jag lägga till en "header" på vanliga bilder?**

I PowerPoint finns "Header" endast för anteckningar och utdelningar; på vanliga bilder är de stödda elementen sidfot, datum/tid och bildnummer. I Aspose.Slides gäller samma begränsningar: header bara för Notes/Handout, och på bilder—Footer/DateTime/SlideNumber.

**Vad händer om layouten inte innehåller ett sidfotområde – kan jag "slå på" dess synlighet?**

Ja. Kontrollera synligheten via rubrik‑/sidfotshanteraren och aktivera den vid behov. Dessa API‑indikatorer och metoder är avsedda för fall då platshållaren saknas eller är dold.

**Hur får jag bildnumret att starta från ett annat värde än 1?**

Ange presentationens [first slide number](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/first_slide_number/); därefter beräknas alla siffror om. Till exempel kan du börja på 0 eller 10, och dölja numret på titelsidan.

**Vad händer med rubriker/sidfötter vid export till PDF/bilder/HTML?**

De renderas som vanliga textelement i presentationen. Det vill säga, om elementen är synliga på bilder/anteckningssidor kommer de också att visas i utdataformatet tillsammans med resten av innehållet.