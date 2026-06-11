---
title: Åtkomst till bilder i presentationer med Python
linktitle: Åtkomst till bild
type: docs
weight: 20
url: /sv/python-net/access-slide-in-presentation/
keywords:
- åtkomst till bild
- bildindex
- bild-id
- bildposition
- ändra position
- bildegenskaper
- bildnummer
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Lär dig hur du får åtkomst till och hanterar bilder i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Python via .NET. Öka produktiviteten med kodexempel."
---
## **Översikt**

Denna artikel förklarar hur du får åtkomst till specifika bilder i en PowerPoint‑presentation med Aspose.Slides för Python. Den visar hur du öppnar en presentation, refererar till bilder efter index eller unikt ID och läser grundläggande bildinformation som behövs för navigering i filen. Med dessa tekniker kan du på ett pålitligt sätt hitta den exakta bilden du vill granska eller bearbeta.

## **Få åtkomst till en bild efter index**

Bilder i en presentation indexeras efter position med start från 0. Den första bilden har index 0, den andra bilden har index 1 och så vidare.

Klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) (som representerar en presentationsfil) exponerar bilder via en [SlideCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slidecollection/) av [Slide](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slide/)-objekt.

Följande Python‑kod visar hur du får åtkomst till en bild efter dess index:

```python
import aspose.slides as slides

# Skapa en Presentation som representerar en presentationsfil.
with slides.Presentation("sample.pptx") as presentation:
    # Hämta en bild efter dess index.
    slide = presentation.slides[0]
```

## **Få åtkomst till en bild efter ID**

Varje bild i en presentation har ett unikt ID kopplat till sig. Du kan använda metoden [get_slide_by_id](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/get_slide_by_id/) (exponerad av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)) för att rikta in dig på det ID‑t.

Följande Python‑kod visar hur du anger ett giltigt bild‑ID och får åtkomst till den bilden via metoden [get_slide_by_id](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/get_slide_by_id/):

```python
import aspose.slides as slides

# Skapa en Presentation som representerar en presentationsfil.
with slides.Presentation("sample.pptx") as presentation:
    # Hämta ett bild-ID.
    id = presentation.slides[0].slide_id
    # Åtkomst till bilden via dess ID.
    slide = presentation.get_slide_by_id(id)
```

## **Ändra en bilds position**

Aspose.Slides låter dig ändra en bilds position. Till exempel kan du göra så att den första bilden blir den andra.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
1. Hämta en referens till den bild vars position du vill ändra genom dess index.
1. Ange en ny position för bilden via egenskapen [slide_number](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slide/slide_number/).
1. Spara den modifierade presentationen.

Följande Python‑kod flyttar bilden på position 1 till position 2:

```python
import aspose.slides as slides

# Instansiera ett Presentation-objekt som representerar en presentationsfil.
with slides.Presentation("sample.pptx") as presentation:
    # Hämta bilden vars position ska ändras.
    slide = presentation.slides[0]
    # Ange den nya positionen för bilden.
    slide.slide_number = 2
    # Spara den modifierade presentationen.
    presentation.save("slide_number.pptx", slides.export.SaveFormat.PPTX)
```

Den första bilden blir den andra; den andra bilden blir den första. När du ändrar en bilds position justeras de andra bilderna automatiskt.

## **Ställ in bildnumret**

Genom att använda egenskapen [first_slide_number](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/first_slide_number/) (exponerad av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)) kan du ange ett nytt nummer för den första bilden i en presentation. Denna operation får de andra bildnumren att omräknas.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
1. Ange bildnumret.
1. Spara den modifierade presentationen.

Följande Python‑kod demonstrerar en operation där det första bildnumret sätts till 10:

```python
import aspose.slides as slides

# Instansiera ett Presentation-objekt som representerar en presentationsfil.
with slides.Presentation("sample.pptx") as presentation:
    # Ange bildnumret.
    presentation.first_slide_number = 10
    # Spara den modifierade presentationen.
    presentation.save("first_slide_number.pptx", slides.export.SaveFormat.PPTX)
```

Om du föredrar att hoppa över den första bilden kan du börja numrera från den andra bilden (och dölja numret på den första bilden) så här:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)

    # Ange numret för den första bilden i presentationen.
    presentation.first_slide_number = 0

    # Visa bildnummer för alla bilder.
    presentation.header_footer_manager.set_all_slide_numbers_visibility(True)

    # Dölj bildnumret på den första bilden.
    presentation.slides[0].header_footer_manager.set_slide_number_visibility(False)

    # Spara den modifierade presentationen.
    presentation.save("first_slide_number.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Matchar bildnumret som en användare ser samlingens nollbaserade index?**

Numret som visas på en bild kan börja på ett godtyckligt värde (t.ex. 10) och behöver inte matcha indexet; relationen styrs av presentationens inställning för [first slide number](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/first_slide_number/).

**Påverkar dolda bilder indexeringen?**

Ja. En dold bild finns kvar i samlingen och räknas med i indexeringen; "hidden" avser visning, inte dess position i samlingen.

**Ändras en bilds index när andra bilder läggs till eller tas bort?**

Ja. Indexen speglar alltid den aktuella ordningen i bilderna och omräknas vid infogning, borttagning och flyttoperationer.