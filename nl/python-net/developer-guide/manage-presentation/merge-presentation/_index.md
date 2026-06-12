---
title: Presentaties efficiënt samenvoegen met Python
linktitle: Presentaties samenvoegen
type: docs
weight: 40
url: /nl/python-net/merge-presentation/
keywords:
- PowerPoint samenvoegen
- presentaties samenvoegen
- dia's samenvoegen
- PPT samenvoegen
- PPTX samenvoegen
- ODP samenvoegen
- PowerPoint combineren
- presentaties combineren
- dia's combineren
- PPT combineren
- PPTX combineren
- ODP combineren
- Python
- Aspose.Slides
description: "Moeiteloos PowerPoint (PPT, PPTX) en OpenDocument (ODP) presentaties samenvoegen met Aspose.Slides voor Python via .NET, waardoor uw workflow wordt gestroomlijnd."
---
## **Overzicht**

Aspose.Slides stelt u in staat om presentaties te combineren door dia's van de ene presentatie te klonen naar een andere. Dit artikel legt uit hoe u volledige presentaties of geselecteerde dia's kunt samenvoegen, een slide‑master of een specifieke lay‑out tijdens het samenvoegen kunt gebruiken, presentaties met verschillende dia‑groottes kunt verwerken, en samengevoegde dia’s aan een presentatiesectie kunt toevoegen. Het behandelt ook praktische opmerkingen met betrekking tot samengevoegde inhoud, inclusief aantekeningen voor sprekers, opmerkingen, met wachtwoord beveiligde bronbestanden en thread‑gebruik.

## **Optimaliseer het samenvoegen van presentaties**

Met [Aspose.Slides for Python](https://products.aspose.com/slides/nl/python-net/) kunt u PowerPoint‑presentaties naadloos combineren, terwijl stijlen, lay‑outs en alle elementen behouden blijven. In tegenstelling tot andere tools voegt Aspose.Slides presentaties samen zonder kwaliteitsverlies of gegevensverlies. Voeg volledige decks, specifieke dia's of zelfs verschillende bestandsformaten (bijv. PPT naar PPTX) samen.

### **Samenvoegfuncties**

- **Volledige presentatie‑samenvoeging:** Alle dia’s in één bestand samenvoegen.  
- **Specifieke dia‑samenvoeging:** Geselecteerde dia’s kiezen en combineren.  
- **Cross‑format samenvoeging:** Presentaties van verschillende formaten integreren, met behoud van integriteit.

## **Presentatie samenvoegen**

Wanneer u de ene presentatie in een andere samenvoegt, combineert u effectief hun dia’s tot één presentatie om één bestand te produceren. De meeste presentatiesoftware — zoals PowerPoint of OpenOffice — biedt geen functionaliteit die u in staat stelt presentaties op deze manier te combineren.

Echter, [Aspose.Slides for Python](https://products.aspose.com/slides/nl/python-net/) maakt het mogelijk presentaties op meerdere manieren samen te voegen. U kunt presentaties samenvoegen met al hun vormen, stijlen, tekst, opmaak, opmerkingen en animaties, zonder kwaliteits- of gegevensverlies.

**Zie ook**

[Clone PowerPoint Slides in Python](/slides/nl/python-net/clone-slides/)

### **Wat kan er worden samengevoegd**

Met Aspose.Slides kunt u het volgende samenvoegen:

- Volledige presentaties: alle dia’s van de bron‑decks worden gecombineerd tot één presentatie.  
- Specifieke dia’s: alleen de geselecteerde dia’s worden gecombineerd tot één presentatie.  
- Presentaties van hetzelfde formaat (bijv. PPT→PPT, PPTX→PPTX) of over verschillende formaten (bijv. PPT→PPTX, PPTX→ODP).

### **Samenvoegopties**

U kunt bepalen of:  
- Elke dia in de uitvoerpresentatie haar oorspronkelijke stijl behoudt, of  
- Een enkele stijl wordt toegepast op alle dia’s in de uitvoerpresentatie.

Om presentaties samen te voegen, biedt Aspose.Slides de [add_clone](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidecollection/add_clone/)‑methoden op de [SlideCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidecollection/)‑klasse. Deze method‑overloads bepalen hoe de samenvoeging wordt uitgevoerd. Elk [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑object exposeert een [slides](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/slides/nl/)‑collectie, zodat u `add_clone` aanroept op de slide‑collectie van de bestemmingspresentatie.

De `add_clone`‑methode retourneert een `Slide` — een kloon van de bron‑slide. Dia’s in de uitvoerpresentatie zijn kopieën van de originelen, zodat u de resulterende dia’s (bijvoorbeeld stijlen, opmaak of lay‑outs toepassen) kunt wijzigen zonder de bronpresentaties te beïnvloeden.

## **Presentaties samenvoegen** 

Aspose.Slides biedt de [add_clone(ISlide)](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide)‑methode, waarmee u dia’s kunt combineren terwijl hun lay‑outs en stijlen behouden blijven (met standaard‑parameters).

De volgende Python‑voorbeeld laat zien hoe u presentaties kunt samenvoegen:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide)
        presentation1.save("combined.pptx", slides.export.SaveFormat.PPTX)
```

## **Presentaties samenvoegen met een slide‑master**

Aspose.Slides biedt de [add_clone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide-asposeslidesimasterslide-bool)‑methode, waarmee u dia’s kunt samenvoegen terwijl u een slide‑master van een sjabloon toepast. Op deze manier kunt u de dia’s in de uitvoerpresentatie, indien nodig, opnieuw stijlen.

De volgende Python‑voorbeeld demonstreert deze bewerking:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.masters[0], True)
        presentation1.save("combined_with_master.pptx", slides.export.SaveFormat.PPTX) 
```

{{% alert title="Note" color="warning" %}}
De geschikte lay‑out onder de gespecificeerde slide‑master wordt automatisch bepaald. Als er geen passende lay‑out wordt gevonden en de `allow_clone_missing_layout`‑boolean‑parameter van de `add_clone`‑methode is ingesteld op `True`, wordt de lay‑out van de bron‑slide gebruikt. Anders wordt een [PptxEditException](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pptxeditexception/) opgegooid.
{{% /alert %}}

Om een andere slide‑lay‑out toe te passen op dia’s in de uitvoerpresentatie, gebruikt u de [add_clone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide-asposeslidesilayoutslide)‑methode bij het samenvoegen.

## **Specifieke dia's uit presentaties samenvoegen**

Het samenvoegen van specifieke dia’s uit meerdere presentaties is handig bij het maken van op maat gemaakte dia‑decks. Aspose.Slides laat u alleen de dia’s selecteren en importeren die u nodig hebt, terwijl de originele opmaak, lay‑out en ontwerp behouden blijven.

De volgende Python‑voorbeeld maakt een nieuwe presentatie, voegt titel‑dia’s toe uit twee andere presentaties en slaat het resultaat op in een bestand:

```py
def get_title_slide(pres):
    for slide in pres.slides:
        if slide.layout_slide.layout_type == slides.SlideLayoutType.TITLE:
            return slide
    return None


with slides.Presentation() as presentation, \
        slides.Presentation("presentation1.pptx") as presentation1, \
        slides.Presentation("presentation2.pptx") as presentation2:
    presentation.slides.remove_at(0)

    slide1 = get_title_slide(presentation1)
    if slide1 is not None:
        presentation.slides.add_clone(slide1)

    slide2 = get_title_slide(presentation2)
    if slide2 is not None:
        presentation.slides.add_clone(slide2)

    presentation.save("combined.pptx", slides.export.SaveFormat.PPTX)
```

## **Presentaties samenvoegen met een slide‑lay‑out**

De volgende Python‑voorbeeld toont hoe u dia’s uit meerdere presentaties kunt samenvoegen terwijl u een specifieke slide‑lay‑out toepast om één enkele uitvoerpresentatie te produceren:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.layout_slides[0])
        presentation1.save("combined_with_layout.pptx", slides.export.SaveFormat.PPTX) 
```

## **Presentaties samenvoegen met verschillende dia‑groottes**

{{% alert title="Note" color="warning" %}}
U kunt geen presentaties met verschillende dia‑groottes direct samenvoegen.
{{% /alert %}}

Om twee presentaties met verschillende dia‑groottes samen te voegen, moet u eerst één presentatie aanpassen zodat haar dia‑grootte overeenkomt met die van de andere.

De volgende voorbeeldcode demonstreert dit proces:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    slide_size = presentation1.slide_size.size
    with slides.Presentation("presentation2.pptx") as presentation2:
        presentation2.slide_size.set_size(slide_size.width, slide_size.height, slides.SlideSizeScaleType.ENSURE_FIT)
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide)
        presentation1.save("combined_size.pptx", slides.export.SaveFormat.PPTX) 
```

## **Dia's samenvoegen in een presentatiesectie**

De volgende Python‑voorbeeld laat zien hoe u een specifieke dia kunt samenvoegen in een sectie van een presentatie:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.sections[0])
        presentation1.save("combined_sections.pptx", slides.export.SaveFormat.PPTX) 
```

De dia wordt aan het einde van de sectie toegevoegd. 

{{% alert title="Tip" color="primary" %}}
Zoekt u een snelle en **gratis online tool** om **PowerPoint‑presentaties samen te voegen**? Probeer de [**Aspose PowerPoint Merger**](https://products.aspose.app/slides/nl/merger).

- **PowerPoint‑bestanden gemakkelijk samenvoegen**: Combineer meerdere **PPT, PPTX, ODP**‑presentaties tot één bestand.  
- **Ondersteunt verschillende formaten**: Voeg **PPT naar PPTX**, **PPTX naar ODP**, en meer samen.  
- **Geen installatie vereist**: Werkt direct in uw browser, snel en veilig.  

[![Dia’s online samenvoegen](slides-merger.png)](https://products.aspose.app/slides/nl/merger)  

Begin vandaag nog met het samenvoegen van uw PowerPoint‑bestanden met de **gratis online tool van Aspose**!  
{{% /alert %}}

{{% alert title="Tip" color="primary" %}}
Aspose biedt een [GRATIS Collage‑webapp](https://products.aspose.app/slides/nl/collage). Met deze online service kunt u [JPG naar JPG](https://products.aspose.app/slides/nl/collage/jpg) of PNG naar PNG afbeeldingen samenvoegen, [fotogalerijen](https://products.aspose.app/slides/nl/collage/photo-grid) maken, enzovoort. 
{{% /alert %}}

## **Veelgestelde vragen**

**Worden aantekeningen voor de spreker bewaard tijdens het samenvoegen?**

Ja. Bij het klonen van dia’s draagt Aspose.Slides alle dia‑elementen over, inclusief aantekeningen, opmaak en animaties.

**Worden opmerkingen en hun auteurs overgedragen?**

Opmerkingen, als onderdeel van de dia‑inhoud, worden gekopieerd met de dia. Auteur‑labels van opmerkingen blijven behouden als opmerkingobjecten in de resulterende presentatie.

**Wat als de bronpresentatie met wachtwoord is beveiligd?**

Deze moet worden [geopend met het wachtwoord](/slides/nl/python-net/password-protected-presentation/) via [LoadOptions.password](https://reference.aspose.com/slides/nl/python-net/aspose.slides/loadoptions/password/); na het laden kunnen die dia’s veilig worden gekloond naar een onbeveiligd doelbestand (of ook naar een beveiligd bestand).

**Hoe thread‑safe is de samenvoegoperatie?**

Gebruik niet dezelfde [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑instantie vanuit [meerdere threads](/slides/nl/python-net/multithreading/). De aanbevolen regel is “één document — één thread”; verschillende bestanden kunnen parallel worden verwerkt in aparte threads.