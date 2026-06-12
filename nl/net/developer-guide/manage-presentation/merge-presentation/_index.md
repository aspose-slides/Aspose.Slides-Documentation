---
title: Efficiënt presentaties samenvoegen in .NET
linktitle: Presentaties samenvoegen
type: docs
weight: 40
url: /nl/net/merge-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Voeg moeiteloos PowerPoint (PPT, PPTX) en OpenDocument (ODP) presentaties samen met Aspose.Slides voor .NET, waardoor uw workflow wordt gestroomlijnd."
---
## **Overzicht**

Aspose.Slides stelt u in staat presentaties te combineren door dia's van de ene presentatie te clonen naar een andere. Dit artikel legt uit hoe u volledige presentaties of geselecteerde dia's kunt samenvoegen, een slide‑master of een specifieke lay‑out tijdens het samenvoegen kunt gebruiken, presentaties met verschillende dia‑groottes kunt verwerken en samengevoegde dia's kunt toevoegen aan een presentatiesectie. Het behandelt tevens praktische aandachtspunten met betrekking tot samengevoegde inhoud, inclusief sprekersnotities, opmerkingen, wachtwoord‑beveiligde bronbestanden en thread‑gebruik.

## **Optimaliseer uw presentatiesamenvoeging**

Met [Aspose.Slides for .NET](https://products.aspose.com/slides/nl/net/), combineert u moeiteloos PowerPoint‑presentaties terwijl stijlen, lay‑outs en alle elementen behouden blijven. In tegenstelling tot andere tools voegt Aspose.Slides presentaties samen zonder concessies aan kwaliteit of verlies van gegevens. Voeg volledige presentaties, specifieke dia's en zelfs verschillende bestandsformaten (PPT naar PPTX, enz.) samen.

### **Samenvoegingsfuncties**

- **Volledige presentatiesamenvoeging:** Alle dia's samenvoegen tot één bestand.  
- **Specifieke dia‑samenvoeging:** Geselecteerde dia's kiezen en combineren.  
- **Cross‑formaat samenvoeging:** Presentaties van verschillende formaten integreren, met behoud van integriteit.

{{% alert title="Tip" color="primary" %}}  
Zoekt u een snelle en **gratis online tool** om **PowerPoint‑presentaties** samen te voegen? Probeer de [**Aspose PowerPoint Merger**](https://products.aspose.app/slides/nl/merger).  

- **PowerPoint‑bestanden eenvoudig samenvoegen**: Combineer meerdere **PPT, PPTX, ODP**‑presentaties tot één bestand.  
- **Ondersteunt verschillende formaten**: Samenvoegen van **PPT naar PPTX**, **PPTX naar ODP**, en meer.  
- **Geen installatie vereist**: Werkt direct in uw browser, snel en veilig.  

[![PowerPoint‑bestanden online samenvoegen](slides-merger.png)](https://products.aspose.app/slides/nl/merger)  

Begin vandaag nog met het samenvoegen van uw PowerPoint‑bestanden met de **gratis Aspose‑online‑tool**!  
{{% /alert %}}

## **Presentatiesamenvoeging**

Wanneer u een [presentatie naar een andere samenvoegt](https://products.aspose.com/slides/nl/net/merger/ppt/), combineert u feitelijk hun dia's in één presentatie om één bestand te verkrijgen. 

{{% alert title="Info" color="info" %}}  
De meeste presentatiesoftware (PowerPoint of OpenOffice) beschikt niet over functies die gebruikers in staat stellen presentaties op deze manier te combineren.  

[**Aspose.Slides for .NET**](https://products.aspose.com/slides/nl/net/) maakt echter verschillende manieren van samenvoegen mogelijk. U kunt presentaties samenvoegen met al hun vormen, stijlen, teksten, opmaak, opmerkingen, animaties, enz., zonder zich zorgen te maken over kwaliteit of gegevensverlies.  

**Zie ook**  

[Clone Slides](https://docs.aspose.com/slides/nl/net/cloning-commenting-and-manipulating-slides/#cloning-commentingandmanipulatingslides-cloningslides)*.*  
{{% /alert %}}

### **Wat kan worden samengevoegd**

Met Aspose.Slides kunt u:

* volledige presentaties. Alle dia's uit de presentaties komen in één presentatie terecht  
* specifieke dia's. Geselecteerde dia's komen in één presentatie terecht  
* presentaties in één formaat (PPT naar PPT, PPTX naar PPTX, enz.) en in verschillende formaten (PPT naar PPTX, PPTX naar ODP, enz.) naar elkaar toe.  

{{% alert title="Opmerking" color="warning" %}}  
Naast presentaties maakt Aspose.Slides het mogelijk andere bestanden samen te voegen:

* [Afbeeldingen](https://products.aspose.com/slides/nl/net/merger/image-to-image/), zoals [JPG naar JPG](https://products.aspose.com/slides/nl/net/merger/jpg-to-jpg/) of [PNG naar PNG](https://products.aspose.com/slides/nl/net/merger/png-to-png/)  
* Documenten, zoals [PDF naar PDF](https://products.aspose.com/slides/nl/net/merger/pdf-to-pdf/) of [HTML naar HTML](https://products.aspose.com/slides/nl/net/merger/html-to-html/)  
* En twee verschillende bestanden, zoals [afbeelding naar PDF](https://products.aspose.com/slides/nl/net/merger/image-to-pdf/), [JPG naar PDF](https://products.aspose.com/slides/nl/net/merger/jpg-to-pdf/) of [TIFF naar PDF](https://products.aspose.com/slides/nl/net/merger/tiff-to-pdf/).  
{{% /alert %}}

### **Samenvoegingsopties**

U kunt opties toepassen die bepalen of

* elke dia in de uitvoerpresentatie een unieke stijl behoudt  
* een specifieke stijl wordt gebruikt voor alle dia's in de uitvoerpresentatie.  

Om presentaties samen te voegen, biedt Aspose.Slides [AddClone](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection/methods/addclone)‑methoden (van de [ISlideCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection)‑interface). Er bestaan verschillende implementaties van de `AddClone`‑methoden die de parameters van het samenvoegproces definiëren. Elk Presentation‑object heeft een [Slides](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/properties/slides)‑collectie, zodat u een `AddClone`‑methode kunt aanroepen op de presentatie waarin u dia's wilt samenvoegen.  

De `AddClone`‑methode retourneert een `ISlide`‑object, een kloon van de bron‑dia. De dia's in de uitvoerpresentatie zijn simpelweg een kopie van de bron‑dia’s. Daarom kunt u de resulterende dia’s wijzigen (bijvoorbeeld stijlen, opmaakopties of lay‑outs toepassen) zonder dat de bronpresentaties worden beïnvloed.  

## **Presentaties samenvoegen** 

Aspose.Slides biedt de [**AddClone (ISlide)**](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection/methods/addclone)‑methode waarmee u dia's combineert terwijl de dia's hun lay‑outs en stijlen behouden (standaardparameters).  

Deze C#‑code toont hoe u presentaties samenvoegt:

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

## **Presentaties samenvoegen met een slide‑master**

Aspose.Slides biedt de [**AddClone (ISlide, IMasterSlide, Boolean)**](https://reference.aspose.com/slides/nl/net/aspose.slides.islidecollection/addclone/methods/2)‑methode waarmee u dia's combineert terwijl u een slide‑master‑presentatiesjabloon toepast. Op die manier kunt u, indien nodig, de stijl van de dia's in de uitvoerpresentatie wijzigen.  

Deze C#‑code demonstreert de beschreven bewerking:

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide, pres2.Masters[0], allowCloneMissingLayout: true);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

{{% alert title="Opmerking" color="warning" %}}  
De slide‑lay‑out voor de slide‑master wordt automatisch bepaald. Wanneer er geen passende lay‑out kan worden gevonden en de `allowCloneMissingLayout`‑boolean‑parameter van de `AddClone`‑methode op true staat, wordt de lay‑out van de bron‑dia gebruikt. Anders wordt een [PptxEditException](https://reference.aspose.com/slides/nl/net/aspose.slides/pptxeditexception) gegooid.  
{{% /alert %}}

Wilt u dat de dia's in de uitvoerpresentatie een andere lay‑out hebben, gebruik dan de [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/nl/net/aspose.slides.islidecollection/addclone/methods/1)‑methode bij het samenvoegen.  

## **Specifieke dia's uit presentaties samenvoegen**

Het samenvoegen van specifieke dia's uit meerdere presentaties is handig voor het maken van op maat gemaakte slide‑decks. Aspose.Slides for .NET stelt u in staat alleen de dia's te selecteren en te importeren die u nodig heeft. De API behoudt de opmaak, lay‑out en het ontwerp van de oorspronkelijke dia's.  

De volgende C#‑code maakt een nieuwe presentatie, voegt titeldia's uit twee andere presentaties toe en slaat het resultaat op in een bestand:

```cs
using (Presentation presentation = new Presentation())
using (Presentation presentation1 = new Presentation("presentation1.pptx"))
using (Presentation presentation2 = new Presentation("presentation2.pptx"))
{
    presentation.Slides.RemoveAt(0);

    ISlide slide1 = GetTitleSlide(presentation1);

    if (slide1 != null)
        presentation.Slides.AddClone(slide1);

    ISlide slide2 = GetTitleSlide(presentation2);

    if (slide2 != null)
        presentation.Slides.AddClone(slide2);

    presentation.Save("combined.pptx", SaveFormat.Pptx);
}
```
```cs
static ISlide GetTitleSlide(IPresentation presentation)
{
    foreach (ISlide slide in presentation.Slides)
    {
        if (slide.LayoutSlide.LayoutType == SlideLayoutType.Title)
        {
            return slide;
        }
    }
    return null;
}
```

## **Presentaties samenvoegen met een slide‑lay‑out**

Deze C#‑code laat zien hoe u dia's uit presentaties combineert terwijl u uw gewenste slide‑lay‑out toepast om één uitvoerpresentatie te verkrijgen:

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide, pres2.LayoutSlides[0]);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

## **Presentaties samenvoegen met verschillende dia‑groottes**

{{% alert title="Opmerking" color="warning" %}}  
U kunt geen presentaties met verschillende dia‑groottes samenvoegen.  
{{% /alert %}}

Om 2 presentaties met verschillende dia‑groottes te combineren, moet u één van de presentaties aanpassen zodat de grootte overeenkomt met die van de andere presentatie.  

Deze voorbeeldcode demonstreert de beschreven bewerking:

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
   pres2 = new Presentation("pres2.pptx"))
{
   pres2.SlideSize.SetSize(pres1.SlideSize.Size.Width, pres1.SlideSize.Size.Height, SlideSizeScaleType.EnsureFit);
 
   foreach (ISlide slide in pres2.Slides)
   {
       pres1.Slides.AddClone(slide);
   }
 
   pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

## **Dia's samenvoegen in een presentatiesectie**

Deze C#‑code toont hoe u een specifieke dia kunt samenvoegen met een sectie in een presentatie:

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    for (var index = 0; index < pres2.Slides.Count; index++)
    {
        ISlide slide = pres2.Slides[index];
        pres1.Slides.AddClone(slide, pres1.Sections[0]);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

De dia wordt aan het einde van de sectie toegevoegd.  

{{% alert title="Tip" color="primary" %}}  
Aspose biedt een [GRATIS Collage‑webapp](https://products.aspose.app/slides/nl/collage). Met deze online service kunt u [JPG naar JPG](https://products.aspose.app/slides/nl/collage/jpg) of PNG‑naar‑PNG‑afbeeldingen samenvoegen, [fotogrijen](https://products.aspose.app/slides/nl/collage/photo-grid) maken, enzovoort.  
{{% /alert %}}

## **FAQ**

**Worden sprekersnotities behouden tijdens het samenvoegen?**  

Ja. Bij het klonen van dia's neemt Aspose.Slides alle dia‑elementen over, inclusief notities, opmaak en animaties.  

**Worden opmerkingen en hun auteurs overgenomen?**  

Opmerkingen, als onderdeel van de dia‑inhoud, worden met de dia gekopieerd. Auteur‑labels van opmerkingen blijven bewaard als opmerking‑objecten in de resulterende presentatie.  

**Wat gebeurt er als de bronpresentatie met een wachtwoord is beveiligd?**  

Deze moet [worden geopend met het wachtwoord](/slides/nl/net/password-protected-presentation/) via [LoadOptions.Password](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/password/); na het laden kunnen die dia's veilig worden gekloond naar een onbeveiligd doelbestand (of ook naar een beveiligd bestand).  

**Hoe thread‑veilig is de samenvoegbewerking?**  

Gebruik dezelfde [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑instantie niet vanuit [meerdere threads](/slides/nl/net/multithreading/). De aanbevolen regel is “één document — één thread”; verschillende bestanden kunnen parallel in afzonderlijke threads worden verwerkt.  