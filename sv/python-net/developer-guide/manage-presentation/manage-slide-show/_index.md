---
title: Hantera bildspel i Python
linktitle: Bildspel
type: docs
weight: 90
url: /sv/python-net/manage-slide-show/
keywords:
- visningstyp
- presenterad av talare
- bläddrad av individ
- bläddrad i kiosk
- visningsalternativ
- loopa kontinuerligt
- visa utan berättarröst
- visa utan animation
- penfärg
- visa bilder
- anpassad visning
- avancera bilder
- manuellt
- använda tidsinställningar
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Lär dig hur du hanterar bildspel i Aspose.Slides för Python via .NET. Kontrollera bildövergångar, tidsinställningar och mer i PPT, PPTX och ODP-format med lätthet."
---
## **Introduktion**

I Microsoft PowerPoint är **Slide Show**-inställningarna ett viktigt verktyg för att förbereda och leverera professionella presentationer. En av de viktigaste funktionerna i detta avsnitt är **Set Up Show**, som låter dig anpassa din presentation till specifika förhållanden och målgrupper, vilket säkerställer flexibilitet och bekvämlighet. Med den här funktionen kan du välja visningstyp (t.ex. presented by a speaker, browsed by an individual eller browsed at a kiosk), aktivera eller inaktivera loopning, välja specifika bilder att visa och använda tidsinställningar. Detta steg i förberedelsen är avgörande för att göra din presentation mer effektiv och professionell.

`slide_show_settings` är en egenskap i klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) av typen [SlideShowSettings](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slideshowsettings/), som låter dig hantera bildspelsinställningarna i en PowerPoint-presentation. I den här artikeln kommer vi att utforska hur du använder denna egenskap för att konfigurera och kontrollera olika aspekter av bildspelsinställningarna. 

## **Välj visningstyp**

`SlideShowSettings.slide_show_type` definierar typen av bildspel, som kan vara en instans av följande klasser: [PresentedBySpeaker](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/sv/python-net/aspose.slides/browsedbyindividual/), eller [BrowsedAtKiosk](https://reference.aspose.com/slides/sv/python-net/aspose.slides/browsedatkiosk/). Genom att använda denna egenskap kan du anpassa presentationen för olika användningsscenario, såsom automatiska kiosker eller manuella presentationer.

Kodexemplet nedan skapar en ny presentation och sätter visningstypen till "Browsed by an individual" utan att visa rullningslisten.

```py
with slides.Presentation() as presentation:

    show_type = slides.BrowsedByIndividual()
    show_type.show_scrollbar = False

    presentation.slide_show_settings.slide_show_type = show_type

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Aktivera visningsalternativ**

`SlideShowSettings.loop` bestämmer om bildspelet ska upprepas i en slinga tills det stoppas manuellt. Detta är användbart för automatiska presentationer som behöver köras kontinuerligt. `SlideShowSettings.show_narration` bestämmer om röstberättelser ska spelas upp under bildspelet. Det är användbart för automatiska presentationer som innehåller röstinstruktioner för publiken. `SlideShowSettings.show_animation` bestämmer om animationer som lagts till bildobjekt ska spelas upp. Detta är användbart för att ge hela den visuella effekten av presentationen.

Följande kodexempel skapar en ny presentation och loopar bildspelet.

```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.loop = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Välj bilder att visa**

`SlideShowSettings.slides`-egenskapen låter dig välja ett intervall av bilder som ska visas under presentationen. Detta är användbart när du bara vill visa en del av presentationen istället för alla bilder. Följande kodexempel skapar en ny presentation och sätter bildintervallet till att visas från bild `2` till `9`.

```py
with slides.Presentation() as presentation:
    
    slide_range = slides.SlidesRange()
    slide_range.start = 2
    slide_range.end = 9

    presentation.slide_show_settings.slides = slide_range

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Använd förskjutning av bilder**

`SlideShowSettings.use_timings`-egenskapen låter dig aktivera eller inaktivera användning av förinställda tidsinställningar för varje bild. Detta är användbart för automatiskt visande av bilder med fördefinierade visningstider. Kodexemplet nedan skapar en ny presentation och inaktiverar användning av tidsinställningar.

```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.use_timings = False

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Visa mediakontroller**

`SlideShowSettings.show_media_controls`-egenskapen bestämmer om mediakontroller (såsom spela, pausa och stoppa) ska visas under bildspelet när multimediainnehåll (t.ex. video eller ljud) spelas upp. Detta är användbart när du vill ge presentatören kontroll över medieuppspelning under presentationen.

Följande kodexempel skapar en ny presentation och aktiverar visning av mediakontroller.

```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.show_media_controls = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kan jag spara en presentation så att den öppnas direkt i bildspelsläge?**

Ja. Spara filen som PPSX eller PPSM; dessa format startar direkt i bildspel när de öppnas i PowerPoint. I Aspose.Slides, välj motsvarande spara format [under export](/slides/sv/python-net/save-presentation/).

**Kan jag utesluta enskilda bilder från visningen utan att ta bort dem från filen?**

Ja. Markera en bild som [hidden](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slide/hidden/). Dolda bilder finns kvar i presentationen men visas inte under bildspelet.

**Kan Aspose.Slides spela upp ett bildspel eller kontrollera en livepresentation på skärmen?**

Nej. Aspose.Slides redigerar, analyserar och konverterar presentationsfiler; den faktiska uppspelningen hanteras av ett visningsprogram som PowerPoint.