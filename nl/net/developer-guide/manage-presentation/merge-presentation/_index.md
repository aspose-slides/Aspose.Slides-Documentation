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
description: "Moeiteloos PowerPoint (PPT, PPTX) en OpenDocument (ODP) presentaties samenvoegen met Aspose.Slides voor .NET, waardoor je workflow wordt gestroomlijnd."
---
## **Overzicht**

Aspose.Slides stelt je in staat om presentaties te samenvoegen door dia's van de ene presentatie te klonen naar een andere. Dit artikel legt uit hoe je volledige presentaties of geselecteerde dia's kunt samenvoegen, een slide‑master of een specifieke lay-out tijdens het samenvoegen kunt gebruiken, presentaties met verschillende dia‑groottes kunt verwerken, en samengevoegde dia's aan een presentatiesectie kunt toevoegen. Het behandelt ook praktische opmerkingen met betrekking tot samengevoegde inhoud, zoals spreker‑notities, opmerkingen, met wachtwoord beveiligde bronbestanden en thread‑gebruik.

## **Optimaliseer het Samenvoegen van Presentaties**

Met [Aspose.Slides voor .NET](https://products.aspose.com/slides/nl/net/) kun je PowerPoint‑presentaties moeiteloos combineren terwijl stijlen, lay-outs en alle elementen behouden blijven. In tegenstelling tot andere tools voegt Aspose.Slides presentaties samen zonder kwaliteitsverlies of gegevensverlies. Voeg volledige presentaties, specifieke dia's en zelfs verschillende bestandsformaten (PPT naar PPTX, enz.) samen.

### **Samenvoeg‑functies**

- **Volledige Presentatie‑Samenvoeging:** Verzamel alle dia's in één bestand.
- **Specifieke Dia‑Samenvoeging:** Kies en combineer geselecteerde dia's.
- **Cross‑Formaat Samenvoeging:** Integreer presentaties van verschillende formaten, behoud de integriteit.

{{% alert title="Tip" color="info" %}}  

Op zoek naar een snelle en **gratis online tool** om **PowerPoint‑presentaties** samen te voegen? Probeer de [**Aspose PowerPoint Merger**](https://products.aspose.app/slides/nl/merger).  

- **PowerPoint‑bestanden eenvoudig samenvoegen**: Combineer meerdere **PPT, PPTX, ODP**‑presentaties in één bestand.  
- **Ondersteunt verschillende formaten**: Voeg **PPT naar PPTX**, **PPTX naar ODP**, en meer samen.  
- **Geen installatie nodig**: Werkt direct in je browser, snel en veilig.  

[![Merge PowerPoint Files Online](slides-merger.png)](https://products.aspose.app/slides/nl/merger)  

Begin vandaag nog met het samenvoegen van je PowerPoint‑bestanden met de **gratis Aspose‑online‑tool**!  

{{% /alert %}}

## **Presentatie‑Samenvoeging**

Wanneer je een presentatie [naar een andere samenvoegt](https://products.aspose.com/slides/nl/net/merger/ppt/), combineer je feitelijk hun dia's in één presentatie om één bestand te verkrijgen. 

{{% alert title="Info" color="info" %}}

De meeste presentatietoepassingen (PowerPoint of OpenOffice) missen functies die gebruikers toestaan presentaties op deze manier te combineren. 

[Aspose.Slides voor .NET](https://products.aspose.com/slides/nl/net/) maakt echter wel verschillende manieren van samenvoegen mogelijk. Je kunt presentaties samenvoegen met al hun vormen, stijlen, teksten, opmaak, opmerkingen, animaties, enz., zonder je zorgen te maken over kwaliteits- of gegevensverlies. 

**Zie ook**

[Clone Slides](https://docs.aspose.com/slides/nl/net/cloning-commenting-and-manipulating-slides/#cloning-commentingandmanipulatingslides-cloningslides)*.* 

{{% /alert %}}

### **Wat Kan Samengevoegd Worden**

Met Aspose.Slides kun je samenvoegen 

* volledige presentaties. Alle dia's uit de presentaties eindigen in één presentatie  
* specifieke dia's. Geselecteerde dia's eindigen in één presentatie  
* presentaties in één formaat (PPT naar PPT, PPTX naar PPTX, enz.) en in verschillende formaten (PPT naar PPTX, PPTX naar ODP, enz.) naar elkaar toe. 

{{% alert title="Opmerking" color="warning" %}} 

Naast presentaties maakt Aspose.Slides het mogelijk om andere bestanden samen te voegen:

* [Afbeeldingen](https://products.aspose.com/slides/nl/net/merger/image-to-image/), zoals [JPG naar JPG](https://products.aspose.com/slides/nl/net/merger/jpg-to-jpg/) of [PNG naar PNG](https://products.aspose.com/slides/nl/net/merger/png-to-png/)  
* Documenten, zoals [PDF naar PDF](https://products.aspose.com/slides/nl/net/merger/pdf-to-pdf/) of [HTML naar HTML](https://products.aspose.com/slides/nl/net/merger/html-to-html/)  
* En twee verschillende bestanden, zoals [afbeelding naar PDF](https://products.aspose.com/slides/nl/net/merger/image-to-pdf/), [JPG naar PDF](https://products.aspose.com/slides/nl/net/merger/jpg-to-pdf/) of [TIFF naar PDF](https://products.aspose.com/slides/nl/net/merger/tiff-to-pdf/). 

{{% /alert %}}

### **Samenvoeg‑opties**

Je kunt opties toepassen die bepalen of

* elke dia in de uitvoerpresentatie een unieke stijl behoudt  
* een specifieke stijl wordt gebruikt voor alle dia's in de uitvoerpresentatie. 

Om presentaties samen te voegen, biedt Aspose.Slides [AddClone](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection/methods/addclone)‑methoden (van de [ISlideCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection)‑interface). Er zijn verschillende implementaties van de `AddClone`‑methoden die de parameters van het samenvoegproces definiëren. Elk Presentation‑object heeft een [Slides](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/properties/slides)‑collectie, zodat je een `AddClone`‑methode kunt aanroepen vanuit de presentatie waarin je dia's wilt samenvoegen. 

De `AddClone`‑methode retourneert een `ISlide`‑object, een kloon van de bron‑dia. De dia's in de uitvoerpresentatie zijn simpelweg een kopie van de dia's uit de bron. Daarom kun je de resulterende dia's wijzigen (bijvoorbeeld stijlen, opmaakopties of lay-outs toepassen) zonder je zorgen te maken over de bron‑presentaties. 

## **Presentaties Samenvoegen** 

Aspose.Slides biedt de [**AddClone (ISlide)**](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection/methods/addclone)‑methode waarmee je dia's kunt combineren terwijl de dia's hun lay-outs en stijlen behouden (standaardparameters). 

Deze C#‑code laat zien hoe je presentaties samenvoegt:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Presentaties Samenvoegen met een Slide Master**

Aspose.Slides biedt de [**AddClone (ISlide, IMasterSlide, Boolean)**](https://reference.aspose.com/slides/nl/net/aspose.slides.islidecollection/addclone/methods/2)‑methode waarmee je dia's kunt combineren terwijl een slide‑master‑sjabloon wordt toegepast. Zo kun je, indien nodig, de stijl van de dia's in de uitvoerpresentatie wijzigen. 

Deze C#‑code demonstreert de beschreven bewerking:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

De slide‑lay-out voor de slide‑master wordt automatisch bepaald. Wanneer een geschikte lay-out niet kan worden bepaald, wordt – als de `allowCloneMissingLayout`‑booleanparameter van de `AddClone`‑methode op true staat – de lay-out van de bron‑dia gebruikt. Anders wordt er een [PptxEditException](https://reference.aspose.com/slides/nl/net/aspose.slides/pptxeditexception) gegooid. 

{{% /alert %}}

Wil je dat de dia's in de uitvoerpresentatie een andere slide‑lay-out hebben, gebruik dan de [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/nl/net/aspose.slides.islidecollection/addclone/methods/1)‑methode tijdens het samenvoegen. 

## **Specifieke Dia's uit Presentaties Samenvoegen**

Het samenvoegen van specifieke dia's uit meerdere presentaties is handig voor het maken van aangepaste presentatiesets. Aspose.Slides voor .NET stelt je in staat alleen de dia's te selecteren en te importeren die je nodig hebt. De API behoudt de opmaak, lay-out en het ontwerp van de originele dia's.

De volgende C#‑code maakt een nieuwe presentatie, voegt titel‑dia's van twee andere presentaties toe, en slaat het resultaat op in een bestand:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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
```cs
using Aspose.Slides;

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

## **Presentaties Samenvoegen met een Slide Layout**

Deze C#‑code laat zien hoe je dia's uit presentaties combineert terwijl je de gewenste slide‑lay-out toepast om één uitvoerpresentatie te verkrijgen:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Presentaties Samenvoegen met Verschillende Dia‑Groottes**

{{% alert title="Opmerking" color="warning" %}} 

Het samenvoegen van presentaties met verschillende dia‑groottes veroorzaakt geen fout, maar de samengevoegde dia's nemen de dia‑grootte van de doelpresentatie over terwijl hun vormen hun oorspronkelijke positie en grootte behouden; daardoor kan inhoud verkeerd gepositioneerd of buiten de dia‑grenzen terechtkomen. 

{{% /alert %}}

Om 2 presentaties met verschillende dia‑groottes samen te voegen en de inhoud correct te laten uitlijnen, pas je één van de presentaties aan zodat deze dezelfde grootte heeft als de andere. 

Deze voorbeeldcode demonstreert de beschreven bewerking:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Dia's Samenvoegen naar een Presentatiesectie**

Deze C#‑code laat zien hoe je een specifieke dia naar een sectie in een presentatie samenvoegt:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

{{% alert title="Tip" color="info" %}}

Aspose biedt een [GRATIS Collage‑webapp](https://products.aspose.app/slides/nl/collage). Met deze online service kun je [JPG naar JPG](https://products.aspose.app/slides/nl/collage/jpg) of PNG naar PNG‑afbeeldingen samenvoegen, [fotogalerijen](https://products.aspose.app/slides/nl/collage/photo-grid) maken, enzovoort. 

{{% /alert %}}

## **FAQ**

### Worden spreker‑notities behouden tijdens het samenvoegen?

Ja. Bij het klonen van dia's neemt Aspose.Slides alle dia‑elementen over, inclusief notities, opmaak en animaties.

### Worden opmerkingen en hun auteurs overgebracht?

Opmerkingen, als onderdeel van de dia‑inhoud, worden meegekopieerd. De labels van de auteurs van opmerkingen blijven behouden als opmerking‑objecten in de resulterende presentatie.

### Wat als de bronpresentatie met een wachtwoord beveiligd is?

Deze moet worden [geopend met het wachtwoord](/slides/nl/net/password-protected-presentation/) via [LoadOptions.Password](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/password/); na het laden kunnen die dia's veilig worden gekloond naar een onbeveiligd doelbestand (of ook naar een beveiligd bestand).

### Hoe thread‑veilig is de samenvoeg‑operatie?

Gebruik dezelfde [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑instantie niet vanuit [meerdere threads](/slides/nl/net/multithreading/). De aanbevolen regel is “één document — één thread”; verschillende bestanden kunnen parallel in afzonderlijke threads worden verwerkt.