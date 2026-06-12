---
title: Efficiënt presentaties samenvoegen in C++
linktitle: Presentaties samenvoegen
type: docs
weight: 40
url: /nl/cpp/merge-presentation/
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
- C++
- Aspose.Slides
description: "Voeg moeiteloos PowerPoint-presentaties (PPT, PPTX) en OpenDocument-presentaties (ODP) samen met Aspose.Slides voor C++, waardoor uw workflow wordt vereenvoudigd."
---
## **Overzicht**

Aspose.Slides stelt u in staat presentaties te combineren door dia’s te klonen van de ene presentatie naar de andere. In dit artikel wordt uitgelegd hoe u volledige presentaties of geselecteerde dia’s kunt samenvoegen, een slide‑master of een specifieke lay‑out kunt gebruiken tijdens het samenvoegen, hoe u presentaties met verschillende dia‑formaten afhandelt en hoe u samengevoegde dia’s aan een presentatiesectie toevoegt. Het behandelt ook praktische opmerkingen met betrekking tot samengevoegde inhoud, inclusief sprekernotities, opmerkingen, wachtwoordbeveiligde bronbestanden en threadgebruik.

## **Presentatie samenvoegen**

Wanneer u de ene presentatie met de andere samenvoegt, combineert u effectief hun dia’s in één presentatie om één bestand te verkrijgen. 

{{% alert title="Info" color="info" %}}

De meeste presentatiesoftware (PowerPoint of OpenOffice) beschikt niet over functies waarmee gebruikers presentaties op deze manier kunnen combineren. 

[**Aspose.Slides for C++**](https://products.aspose.com/slides/nl/cpp/), maakt echter wel verschillende manieren van samenvoegen mogelijk. U kunt presentaties samenvoegen met al hun vormen, stijlen, teksten, opmaak, opmerkingen, animaties, enz., zonder u zorgen te maken over kwaliteits- of gegevensverlies. 

**Zie ook**

[Clone Slides](https://docs.aspose.com/slides/nl/cpp/clone-slides/)*.* 

{{% /alert %}}

### **Wat kan worden samengevoegd**

Met Aspose.Slides kunt u 

* volledige presentaties. Alle dia’s uit de presentaties komen in één presentatie terecht  
* specifieke dia’s. Geselecteerde dia’s komen in één presentatie terecht  
* presentaties in één formaat (PPT naar PPT, PPTX naar PPTX, enz.) en in verschillende formaten (PPT naar PPTX, PPTX naar ODP, enz.) naar elkaar toe. 

{{% alert title="Note" color="warning" %}} 

Naast presentaties maakt Aspose.Slides het mogelijk andere bestanden samen te voegen:

* [Afbeeldingen](https://products.aspose.com/slides/nl/cpp/merger/image-to-image/), zoals [JPG naar JPG](https://products.aspose.com/slides/nl/cpp/merger/jpg-to-jpg/) of [PNG naar PNG](https://products.aspose.com/slides/nl/cpp/merger/png-to-png/)  
* Documenten, zoals [PDF naar PDF](https://products.aspose.com/slides/nl/cpp/merger/pdf-to-pdf/) of [HTML naar HTML](https://products.aspose.com/slides/nl/cpp/merger/html-to-html/)  
* En twee verschillende bestanden, zoals [afbeelding naar PDF](https://products.aspose.com/slides/nl/cpp/merger/image-to-pdf/), [JPG naar PDF](https://products.aspose.com/slides/nl/cpp/merger/jpg-to-pdf/) of [TIFF naar PDF](https://products.aspose.com/slides/nl/cpp/merger/tiff-to-pdf/). 

{{% /alert %}}

### **Samenvoegopties**

U kunt opties toepassen die bepalen of

* elke dia in de resultaatpresentatie een unieke stijl behoudt  
* een specifieke stijl wordt gebruikt voor alle dia’s in de resultaatpresentatie. 

Om presentaties samen te voegen, biedt Aspose.Slides de [AddClone](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee)-methoden (van de [ISlideCollection](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_slide_collection)-interface). Er zijn verschillende implementaties van de `AddClone`‑methoden die de parameters van het samenvoegproces definiëren. Elk Presentation‑object heeft een [Slides](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c)-collectie, dus u kunt een `AddClone`‑methode aanroepen vanuit de presentatie waarin u dia’s wilt samenvoegen. 

De `AddClone`‑methode retourneert een `ISlide`‑object, dat een kloon van de bron‑dia is. De dia’s in een output‑presentatie zijn simpelweg een kopie van de dia’s uit de bron. Daarom kunt u de resulterende dia’s wijzigen (bijvoorbeeld stijlen, opmaakopties of lay‑outs toepassen) zonder dat de bronpresentaties worden beïnvloed. 

## **Presentaties samenvoegen** 

Aspose.Slides biedt de [**AddClone (ISlide)**](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee)-methode die u in staat stelt dia’s te combineren terwijl de dia’s hun lay‑outs en stijlen behouden (standaardparameters). 

Deze C++‑code laat zien hoe presentaties worden samengevoegd:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Presentaties samenvoegen met een slide‑master**

Aspose.Slides biedt de [**AddClone (ISlide, IMasterSlide, bool)**](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_slide_collection#a6b040e6b30f52ab4644fafdbc650b640)-methode die u in staat stelt dia’s te combineren met toepassing van een slide‑master‑presentatiesjabloon. Op deze manier kunt u, indien nodig, de stijl van de dia’s in de output‑presentatie wijzigen. 

Deze C++‑code demonstreert de beschreven bewerking:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_Masters()->idx_get(0), true);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 

De slide‑lay‑out voor de slide‑master wordt automatisch bepaald. Wanneer er geen passende lay‑out kan worden bepaald, wordt – indien de booleaanse parameter `allowCloneMissingLayout` van de `AddClone`‑methode op true staat – de lay‑out van de bron‑dia gebruikt. Anders wordt een [PptxEditException](https://reference.aspose.com/slides/nl/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d) gegooid. 

{{% /alert %}}

Wilt u dat de dia’s in de output‑presentatie een andere slide‑lay‑out hebben, gebruik dan de [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_slide_collection#a0ed5909b2d92555159007046760ff2f1)-methode tijdens het samenvoegen. 

## **Specifieke dia’s uit presentaties samenvoegen**

Het samenvoegen van specifieke dia’s uit meerdere presentaties is handig voor het maken van aangepaste dia‑sets. Aspose.Slides C++ stelt u in staat alleen de dia’s te selecteren en te importeren die u nodig heeft. De API behoudt de opmaak, lay‑out en het ontwerp van de oorspronkelijke dia’s.

De volgende C++‑code maakt een nieuwe presentatie, voegt titeldia’s toe uit twee andere presentaties en slaat het resultaat op in een bestand:

```cpp
SmartPtr<ISlide> GetTitleSlide(SmartPtr<IPresentation> presentation)
{
    for (auto&& slide : presentation->get_Slides())
    {
        if (slide->get_LayoutSlide()->get_LayoutType() == SlideLayoutType::Title)
        {
            return slide;
        }
    }
    return nullptr;
}
```
```cpp
auto presentation = MakeObject<Presentation>();
auto presentation1 = MakeObject<Presentation>(u"presentation1.pptx");
auto presentation2 = MakeObject<Presentation>(u"presentation2.pptx");

presentation->get_Slides()->RemoveAt(0);

auto slide1 = GetTitleSlide(presentation1);

if (slide1 != nullptr)
    presentation->get_Slides()->AddClone(slide1);

auto slide2 = GetTitleSlide(presentation2);

if (slide2 != nullptr)
    presentation->get_Slides()->AddClone(slide2);

presentation->Save(u"combined.pptx", SaveFormat::Pptx);

presentation2->Dispose();
presentation1->Dispose();
presentation->Dispose();
```

## **Presentaties samenvoegen met een slide‑lay‑out**

Deze C++‑code laat zien hoe u dia’s uit presentaties combineert met toepassing van uw gewenste slide‑lay‑out om één output‑presentatie te verkrijgen:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Presentaties samenvoegen met verschillende dia‑groottes**

{{% alert title="Note" color="warning" %}} 

U kunt geen presentaties met verschillende dia‑groottes samenvoegen. 

{{% /alert %}}

Om 2 presentaties met verschillende dia‑groottes samen te voegen, moet u één van de presentaties schalen zodat de grootte overeenkomt met die van de andere presentatie. 

Deze voorbeeldcode demonstreert de beschreven bewerking:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres1Size = pres1->get_SlideSize()->get_Size();

auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
pres2->get_SlideSize()->SetSize(pres1Size.get_Width(), pres1Size.get_Height(), SlideSizeScaleType::EnsureFit);

for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Dia’s samenvoegen naar een presentatiesectie**

Deze C++‑code laat zien hoe u een specifieke dia aan een sectie in een presentatie toevoegt:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (int32_t index = 0; index < pres2->get_Slides()->get_Count(); index++)
{
    auto slide = pres2->get_Slides()->idx_get(index);
    pres1->get_Slides()->AddClone(slide, pres1->get_Sections()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

De dia wordt aan het einde van de sectie toegevoegd. 

{{% alert title="Tip" color="primary" %}}

Aspose biedt een [GRATIS Collage‑webapp](https://products.aspose.app/slides/nl/collage). Met deze online service kunt u [JPG naar JPG](https://products.aspose.app/slides/nl/collage/jpg) of PNG naar PNG‑afbeeldingen samenvoegen, [fotogalerijen](https://products.aspose.app/slides/nl/collage/photo-grid) maken, enzovoort. 

{{% /alert %}}

## **FAQ**

**Worden sprekernotities behouden tijdens het samenvoegen?**

Ja. Bij het klonen van dia’s neemt Aspose.Slides alle dia‑elementen mee, inclusief notities, opmaak en animaties.

**Worden opmerkingen en hun auteurs overgedragen?**

Opmerkingen, als onderdeel van de dia‑inhoud, worden meegekopieerd. De auteurslabels van opmerkingen blijven behouden als opmerking‑objecten in de resulterende presentatie.

**Wat gebeurt er als de bron‑presentatie wachtwoordbeveiligd is?**

Deze moet worden [geopend met het wachtwoord](/slides/nl/cpp/password-protected-presentation/) via [LoadOptions::set_Password](https://reference.aspose.com/slides/nl/cpp/aspose.slides/loadoptions/set_password/); na het laden kunnen die dia’s veilig worden gekloond naar een onbeveiligd doelbestand (of ook naar een beveiligd bestand).

**Hoe thread‑veilig is de samenvoegbewerking?**

Gebruik dezelfde [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)-instantie niet vanuit [meerdere threads](/slides/nl/cpp/multithreading/). De aanbevolen regel is “één document — één thread”; verschillende bestanden kunnen parallel in afzonderlijke threads worden verwerkt.