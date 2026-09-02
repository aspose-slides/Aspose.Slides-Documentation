---
title: Kloon presentatieslides in C++
linktitle: Slides klonen
type: docs
weight: 40
url: /nl/cpp/clone-slides/
keywords:
- slide klonen
- slide kopiëren
- slide opslaan
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Dupliceer PowerPoint-slides snel met Aspose.Slides voor C++. Volg onze duidelijke code-voorbeelden om PPT-creatie in enkele seconden te automatiseren en handmatig werk te elimineren."
---
## **Inleiding**

Cloning is het proces waarbij een exacte kopie of replica van iets wordt gemaakt. Aspose.Slides for C++ maakt het ook mogelijk om een kopie of kloon van een slide te maken en die gekloonde slide vervolgens in de huidige of een andere geopende presentatie in te voegen. Het klonen van een slide creëert een nieuwe slide die door ontwikkelaars kan worden aangepast zonder de oorspronkelijke slide te wijzigen. Er zijn verschillende manieren om een slide te klonen:

- Een kloon aan het einde binnen een presentatie.
- Een kloon op een andere positie binnen een presentatie.
- Een kloon aan het einde in een andere presentatie.
- Een kloon op een andere positie in een andere presentatie.
- Een kloon op een specifieke positie in een andere presentatie.

In Aspose.Slides voor C++ (een verzameling van [ISlide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islide/) objecten) die door het [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) object wordt blootgesteld, biedt de [AddClone](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/addclone/) en [InsertClone](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/insertclone/) methode om de bovenstaande soorten slide‑clonering uit te voeren

## **Een slide kloon aan het einde van een presentatie**
If you want to clone a slide and then use it within the same presentation file at the end of the existing slides, use the [AddClone](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/addclone/) method according to the steps listed below:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse.
1. Instantieer de [ISlideCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/) klasse door te verwijzen naar de Slides‑verzameling die door het [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) object wordt blootgesteld.
1. Roep de [AddClone](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/addclone/) methode aan die wordt blootgesteld door het [ISlideCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/) object en geef de te klonen slide als parameter door aan de [AddClone](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/addclone/) methode.
1. Schrijf het gewijzigde presentatie‑bestand.

In the example given below, we have cloned a slide (lying at the first position – zero index – of the presentation) to the end of the presentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cpp" >}}


## **Een slide kloon naar een andere positie binnen een presentatie**
If you want to clone a slide and then use it within the same presentation file but at a different position, use the [InsertClone](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/insertclone/) method:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse.
1. Instantieer de klasse door te verwijzen naar de **Slides**‑verzameling die door het [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) object wordt blootgesteld.
1. Roep de [InsertClone](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/insertclone/) methode aan die door het [ISlideCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/) object wordt blootgesteld en geef de te klonen slide samen met de index voor de nieuwe positie door als parameter aan de [InsertClone](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/insertclone/) methode.
1. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

In the example given below, we have cloned a slide (lying at the zero index – position 1 – of the presentation) to index 1 – Position 2 – of the presentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithInSamePresentation-CloneWithInSamePresentation.cpp" >}}

## **Een slide kloon aan het einde van een andere presentatie**
If you need to clone a slide from one presentation and use it in another presentation file, at the end of the existing slides:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse aan die de presentatie bevat waarvan de slide gekloond zal worden.
1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse aan die de bestemmingspresentatie bevat waaraan de slide zal worden toegevoegd.
1. Instantieer de [ISlideCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/) klasse door te verwijzen naar de **Slides**‑verzameling die door het Presentation‑object van de bestemmingspresentatie wordt blootgesteld.
1. Roep de [AddClone](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/addclone/) methode aan die door het [ISlideCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/) object wordt blootgesteld en geef de slide uit de bronpresentatie door als parameter aan de [AddClone](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/addclone/) methode.
1. Schrijf het gewijzigde bestemmingspresentatie‑bestand.

In the example given below, we have cloned a slide (from the first index of the source presentation) to the end of the destination presentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Een slide kloon naar een andere positie in een andere presentatie**
If you need to clone a slide from one presentation and use it in another presentation file, at a specific position:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse aan die de bronpresentatie bevat waarvan de slide gekloond zal worden.
1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse aan die de presentatie bevat waaraan de slide zal worden toegevoegd.
1. Instantieer de [ISlideCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/) klasse door te verwijzen naar de Slides‑verzameling die door het Presentation‑object van de bestemmingspresentatie wordt blootgesteld.
1. Roep de [InsertClone](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/insertclone/) methode aan die door het [ISlideCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/) object wordt blootgesteld en geef de slide uit de bronpresentatie samen met de gewenste positie door als parameter aan de [InsertClone](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/insertclone/) methode.
1. Schrijf het gewijzigde bestemmingspresentatie‑bestand.

In the example given below, we have cloned a slide (from the zero index of the source presentation) to index 1 (position 2) of the destination presentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}
## **Een slide kloon op een specifieke positie in een andere presentatie**
If you need to clone a slide with master slide from one presentation from and use it in another presentation , you need to clone the desired master slide from source presentation to destination presentation first. Then you need to use that master slide for cloning slide with master slide. The **AddClone(ISlide, IMasterSlide)** expects master slide from destination presentation rather than from source presentation. In order to clone the slide with master, please follow the steps below:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse aan die de bronpresentatie bevat waarvan de slide gekloond zal worden.
1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse aan die de bestemmingspresentatie bevat waaraan de slide zal worden gekloond.
1. Toegang tot de te klonen slide samen met de masterslide.
1. Instantieer de [IMasterSlideCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasterslidecollection/) klasse door te verwijzen naar de Masters‑verzameling die door het [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) object van de bestemmingspresentatie wordt blootgesteld.
1. Roep de [AddClone](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/addclone/) methode aan die door het [IMasterSlideCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasterslidecollection/) object wordt blootgesteld en geef de master uit de bron‑PPTX die gekloond moet worden door als parameter aan de [AddClone](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/addclone/) methode.
1. Instantieer de [ISlideCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/) klasse door de referentie naar de Slides‑verzameling die door het [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) object van de bestemmingspresentatie wordt blootgesteld te zetten.
1. Roep de [AddClone](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/addclone/) methode aan die door het [ISlideCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/) object wordt blootgesteld en geef de slide uit de bronpresentatie die gekloond moet worden en de masterslide als parameter door aan de [AddClone](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/addclone/) methode.
1. Schrijf het gewijzigde bestemmingspresentatie‑bestand.

In the example given below, we have cloned a slide with master (lying at the zero index of the source presentation) to the end of the destination presentation using master from source slide.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithMaster-CloneToAnotherPresentationWithMaster.cpp" >}}
## **Een slide kloon aan het einde van een opgegeven sectie**
If you want to clone a slide and then use it within the same presentation file but at a different section, then use the [**AddClone()**](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/addclone/) method exposed by the [**ISlideCollection**](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/)interface. Aspose.Slides for C++ makes it possible to clone a slide from the first section and then insert that cloned slide to the second section of the same presentation.

The following code snippet shows you how to clone a slide and insert the cloned slide into a specified section.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.cpp" >}}

## **Zorg voor overeenkomende slide‑grootte**

When cloning slides into another presentation, make sure the destination presentation has the same slide size as the source. If the slide sizes differ, Aspose.Slides does not automatically rescale the cloned shapes—their original coordinates and dimensions are preserved, which may cause the content to appear misaligned or extend beyond the slide boundaries.

You can set the destination presentation's slide size to match the source before cloning the master and slide:

```cpp
auto sourceSize = sourcePresentation->get_SlideSize()->get_Size();

targetPresentation->get_SlideSize()->SetSize(
    sourceSize.get_Width(), sourceSize.get_Height(), SlideSizeScaleType::DoNotScale);
```

Doe dit voordat u de master en de slide kloont.

## **FAQ**

**Wordt de spreker-notities en beoordelingscommentaren gekloond?**

Ja. De notitiepagina en beoordelingscommentaren worden meegenomen in de kloon. Als u ze niet wilt, [verwijder ze](/slides/nl/cpp/presentation-notes/) na het invoegen.

**Hoe worden diagrammen en hun gegevensbronnen behandeld?**

Het diagramobject, de opmaak en de ingesloten gegevens worden gekopieerd. Als het diagram was gekoppeld aan een externe bron (bijv. een OLE‑ingesloten werkmap), blijft die koppeling behouden als een [OLE object](/slides/nl/cpp/manage-ole/). Controleer na het verplaatsen tussen bestanden of de gegevens beschikbaar zijn en hoe vernieuwing zich gedraagt.

**Kan ik de invoegpositie en secties voor de kloon bepalen?**

Ja. U kunt de kloon invoegen op een specifieke slide‑index en plaatsen in een gekozen [section](/slides/nl/cpp/slide-section/). Als de doelsectie nog niet bestaat, maak deze dan eerst aan en verplaats vervolgens de slide ernaar.