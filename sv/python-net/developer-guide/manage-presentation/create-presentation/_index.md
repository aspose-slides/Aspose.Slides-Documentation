---
title: Skapa presentationer i Python
linktitle: Skapa presentation
type: docs
weight: 10
url: /sv/python-net/create-presentation/
keywords:
- skapa presentation
- ny presentation
- skapa PPT
- ny PPT
- skapa PPTX
- ny PPTX
- skapa ODP
- ny ODP
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Skapa PowerPoint-presentationer i Python med Aspose.Slides—producera PPT-, PPTX- och ODP-filer, dra nytta av OpenDocument-stöd och spara dem programatiskt för pålitliga resultat."
---
## **Översikt**

Aspose.Slides for Python låter dig skapa en helt ny presentationsfil helt i kod. Denna artikel visar huvudarbetsflödet—att skapa ett [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)‑objekt, hämta den första bilden, injicera en enkel form och spara resultatet—så att du kan se hur lite konfiguration som krävs för att generera en presentation utan Microsoft Office. Eftersom samma API skriver PPT-, PPTX- och ODP‑filer kan du rikta dig både mot traditionella PowerPoint‑ och OpenDocument‑format från en enda kodbas. Aspose.Slides är lämplig för skrivbord-, webb- eller servermiljöer och ger din Python‑applikation en effektiv utgångspunkt för att lägga till rikare innehåll såsom text, bilder eller diagram när den första bilduppsättningen är på plats.

## **Skapa en presentation**

Att skapa en PowerPoint‑fil från början i Aspose.Slides for Python är lika enkelt som att instansiera klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/). Konstruktorn levererar automatiskt ett tomt paket med en enda bild, vilket ger dig en omedelbar yta för former, text, diagram eller annat innehåll som din applikation behöver. När du har ändrat den bilden—eller lagt till nya—kan du spara resultatet som PPTX, äldre PPT eller även OpenDocument‑format. Det korta kodexemplet nedan illustrerar detta arbetsflöde genom att lägga till en enkel form på den första bilden.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
1. Hämta en referens till bilden via dess index.
1. Lägg till ett [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/)‑objekt av typen `CLOUD` med metoden `add_auto_shape` som exponeras av samlingen `shapes`.
1. Lägg till text i auto‑formen.
1. Spara den ändrade presentationen som en PPTX‑fil.

I exemplet nedan läggs en molnform till på den första bilden i presentationen.

```py
import aspose.slides as slides

# Instansiera Presentation-klassen som representerar en presentationsfil.
with slides.Presentation() as presentation:
    # Hämta den första bilden.
    slide = presentation.slides[0]

    # Lägg till en auto-form av typen CLOUD.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Spara presentationen som en PPTX-fil.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

Resultatet:

![Den nya presentationen](new_presentation.png)

## **Vanliga frågor**

**Vilka format kan jag spara en ny presentation i?**

Du kan spara som [PPTX, PPT och ODP](/slides/sv/python-net/save-presentation/), och exportera till [PDF](/slides/sv/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/sv/python-net/convert-powerpoint-to-xps/), [HTML](/slides/sv/python-net/convert-powerpoint-to-html/), [SVG](/slides/sv/python-net/convert-powerpoint-to-png/) och [bilder](/slides/sv/python-net/convert-powerpoint-to-png/), bland annat.

**Kan jag starta från en mall (POTX/POTM) och spara som en vanlig PPTX?**

Ja. Ladda mallen och spara i önskat format; POTX/POTM/PPTM och liknande format [stöds](/slides/sv/python-net/supported-file-formats/).

**Hur styr jag bildstorlek/-förhållande när jag skapar en presentation?**

Ställ in [slide size](/slides/sv/python-net/slide-size/) (inklusive förinställningar som 4:3 och 16:9 eller egna dimensioner) och välj hur innehållet ska skalas.

**I vilka enheter mäts storlekar och koordinater?**

I punkter: 1 tum motsvarar 72 enheter.

**Hur hanterar jag mycket stora presentationer (med många mediafiler) för att minska minnesanvändning?**

Använd [BLOB management strategies](/slides/sv/python-net/manage-blob/), begränsa minneslagring genom att utnyttja temporära filer och föredra filbaserade arbetsflöden framför rena minnesströmmar.

**Kan jag skapa/spara presentationer parallellt?**

Du kan inte arbeta på samma [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)‑instans från [flera trådar](/slides/sv/python-net/multithreading/). Kör separata, isolerade instanser per tråd eller process.

**Hur tar jag bort provvattenstämpeln och begränsningarna?**

[Applicera en licens](/slides/sv/python-net/licensing/) en gång per process. Licens‑XML‑filen måste förbli oförändrad, och licensinställningen bör synkroniseras om flera trådar är inblandade.

**Kan jag digitalt signera PPTX‑filen jag skapar?**

Ja. [Digital signatures](/slides/sv/python-net/digital-signature-in-powerpoint/) (lägg till och verifiera) stöds för presentationer.

**Stöds makron (VBA) i skapade presentationer?**

Ja. Du kan [create/edit VBA projects](/slides/sv/python-net/presentation-via-vba/) och spara makro‑aktiverade filer som PPTM/PPSM.