---
title: Beheer presentatievormen in C++
linktitle: Vormmanipulatie
type: docs
weight: 40
url: /nl/cpp/shape-manipulations/
keywords:
- PowerPoint-vorm
- presentatie-vorm
- vorm op dia
- vorm zoeken
- vorm klonen
- vorm verwijderen
- vorm verbergen
- vormvolgorde wijzigen
- interop-vorm-ID ophalen
- alternatieve tekst van vorm
- lay-outformaten van vorm
- vorm als SVG
- vorm naar SVG
- vorm uitlijnen
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe u vormen kunt maken, bewerken en optimaliseren in Aspose.Slides voor C++ en lever hoogwaardige PowerPoint-presentaties."
---
## **Overzicht**

Dit artikel legt uit hoe u met vormen in presentaties werkt met Aspose.Slides. Het laat zien hoe u een vorm op een dia vindt, kloont, verwijdert, verbergt, de volgorde wijzigt, de Interop‑vorm‑ID verkrijgt en alternatieve tekst instelt voor identificatie en verdere verwerking.

Het behandelt ook hoe u lay‑outformaten voor vormen benadert, een vorm rendert als SVG, vormen op een dia uitlijnt en flip‑eigenschappen gebruikt voor horizontale en verticale spiegeling. Daarnaast bevat het artikel een korte FAQ over het combineren van vormen, stapelvolgorde en het vergrendelen van vormen.

## **Zoek een vorm op een dia**
Dit onderwerp beschrijft een eenvoudige techniek om het voor ontwikkelaars makkelijker te maken een specifieke vorm op een dia te vinden zonder de interne Id te gebruiken. Het is belangrijk te weten dat PowerPoint‑presentatiebestanden geen manier hebben om vormen op een dia te identificeren, behalve via een interne unieke Id. Het blijkt moeilijk voor ontwikkelaars om een vorm te vinden met behulp van de interne unieke Id. Alle toegevoegde vormen hebben een Alt‑tekst. Wij raden ontwikkelaars aan alternatieve tekst te gebruiken om een specifieke vorm te vinden. U kunt MS PowerPoint gebruiken om de alternatieve tekst voor objecten te definiëren die u later wilt wijzigen.

Nadat u de alternatieve tekst van een gewenste vorm heeft ingesteld, kunt u die presentatie openen met Aspose.Slides voor C++ en over alle vormen op een dia itereren. Tijdens elke iteratie kunt u de alternatieve tekst van de vorm controleren; de vorm met overeenkomende alternatieve tekst is dan de gewenste vorm. Om deze techniek beter te demonstreren, hebben we een methode, [FindShape](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.util.slide_util#ad6ecc982512ef758ea4d5d28672db71f) gemaakt die het mogelijk maakt een specifieke vorm op een dia te vinden en vervolgens eenvoudig die vorm retourneert.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FindShapeInSlide-FindShapeInSlide.cpp" >}}

## **Kloon een vorm**
Om een vorm te klonen naar een dia met Aspose.Slides voor C++:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation).
2. Haal de referentie van een dia op via de index.
3. Benader de vormverzameling van de bron‑dia.
4. Voeg een nieuwe dia toe aan de presentatie.
5. Kloon vormen van de bron‑dia‑verzameling naar de nieuwe dia.
6. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Het voorbeeld hieronder voegt een groepsvorm toe aan een dia.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneShapes-CloneShapes.cpp" >}}

## **Verwijder een vorm**
Aspose.Slides voor C++ stelt ontwikkelaars in staat elke vorm te verwijderen. Volg de onderstaande stappen om de vorm van een dia te verwijderen:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation).
2. Benader de eerste dia.
3. Zoek de vorm met specifieke AlternativeText.
4. Verwijder de vorm.
5. Sla het bestand op naar schijf.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveShape-RemoveShape.cpp" >}}

## **Verberg een vorm**
Aspose.Slides voor C++ stelt ontwikkelaars in staat elke vorm te verbergen. Volg de onderstaande stappen om de vorm van een dia te verbergen:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation).
2. Benader de eerste dia.
3. Zoek de vorm met specifieke AlternativeText.
4. Verberg de vorm.
5. Sla het bestand op naar schijf.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-Hidingshapes-Hidingshapes.cpp" >}}

## **Wijzig de volgorde van vormen**
Aspose.Slides voor C++ stelt ontwikkelaars in staat de volgorde van vormen te wijzigen. Het herschikken van een vorm geeft aan welke vorm vóór of achter een andere staat. Volg de onderstaande stappen om de volgorde van vormen op een dia te wijzigen:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation).
2. Benader de eerste dia.
3. Voeg een vorm toe.
4. Voeg enige tekst toe in het tekstframe van de vorm.
5. Voeg een tweede vorm toe met dezelfde coördinaten.
6. Herschik de vormen.
7. Sla het bestand op naar schijf.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeShapeOrder-ChangeShapeOrder.cpp" >}}

## **Haal de Interop‑vorm‑ID op**
Aspose.Slides voor C++ stelt ontwikkelaars in staat een unieke vormidentificatie binnen de dia‑scope te verkrijgen, in tegenstelling tot de UniqueId‑eigenschap die een unieke identificatie binnen de presentatie‑scope biedt. Eigenschap OfficeInteropShapeId werd toegevoegd aan de IShape‑interfaces en de Shape‑klasse. De waarde die door de OfficeInteropShapeId‑eigenschap wordt geretourneerd, komt overeen met de Id‑waarde van het Microsoft.Office.Interop.PowerPoint.Shape‑object. Hieronder staat de voorbeeldcode.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-InterlopShapeID-InterlopShapeID.cpp" >}}

## **Stel de AlternativeText‑eigenschap in**
Aspose.Slides voor C++ stelt ontwikkelaars in staat de AlternativeText van elke vorm in te stellen. Volg de onderstaande stappen om de AlternativeText van een vorm in te stellen:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation).
2. Benader de eerste dia.
3. Voeg een willekeurige vorm toe aan de dia.
4. Voer enige bewerkingen uit op de nieuw toegevoegde vorm.
5. Loop door de vormen om een vorm te vinden.
6. Stel de AlternativeText in.
7. Sla het bestand op naar schijf.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAlternativeText-SetAlternativeText.cpp" >}}

## **Benader lay‑outformaten voor een vorm**
Aspose.Slides voor C++ stelt ontwikkelaars in staat om lay‑outformaten voor een vorm te benaderen. Dit artikel toont hoe u de eigenschappen **FillFormat** en **LineFormat** voor een vorm kunt benaderen.

Hieronder staat de voorbeeldcode.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AccessLayoutFormats-AccessLayoutFormats.cpp" >}}

## **Render een vorm als SVG**
Nu ondersteunt Aspose.Slides voor C++ het renderen van een vorm als SVG. De methode WriteAsSvg (en de overload) is toegevoegd aan de Shape‑klasse en de IShape‑interface. Deze methode maakt het mogelijk de inhoud van een vorm op te slaan als een SVG‑bestand. De code‑fragment hieronder laat zien hoe u de vorm van een dia exporteert naar een SVG‑bestand.

``` cpp
String outSvgFileName = u"SingleShape.svg";

auto pres = System::MakeObject<Presentation>(u"TestExportShapeToSvg.pptx");

auto stream = System::MakeObject<FileStream>(outSvgFileName, FileMode::Create, FileAccess::Write);
pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0)->WriteAsSvg(stream);
```

## **Uitlijning van vormen**
Aspose.Slides maakt het mogelijk vormen uit te lijnen ten opzichte van de dia‑marges of ten opzichte van elkaar. Hiervoor is een overload van de methode [SlidesUtil.AlignShapes()](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.util.slide_util#a2263709efa423c11706e57b21014d3ab) toegevoegd. De enumeratie [ShapesAlignmentType](https://reference.aspose.com/slides/nl/cpp/namespace/aspose.slides#aeb3015a196294029a0ee1f545bc5887f) definieert de mogelijke uitlijningsopties.

**Example 1**

De broncode hieronder lijnt vormen met indexen 1, 2 en 4 uit langs de bovenrand van de dia.

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"example.pptx");

SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
SharedPtr<IShape> shape1 = slide->get_Shapes()->idx_get(1);
SharedPtr<IShape> shape2 = slide->get_Shapes()->idx_get(2);
SharedPtr<IShape> shape3 = slide->get_Shapes()->idx_get(4);
SlideUtil::AlignShapes(ShapesAlignmentType::AlignTop, true, pres->get_Slides()->idx_get(0), 
System::MakeArray<int32_t>(
    {
        slide->get_Shapes()->IndexOf(shape1),
        slide->get_Shapes()->IndexOf(shape2),
        slide->get_Shapes()->IndexOf(shape3)
    }));
```

**Example 2**

Het voorbeeld hieronder toont hoe de volledige collectie vormen uitgelijnd kan worden ten opzichte van de laagste vorm in de collectie.

``` cpp
SharedPtr<Presentation> pres = MakeObject<Presentation>(u"example.pptx");
SlideUtil::AlignShapes(ShapesAlignmentType::AlignBottom, false, pres->get_Slides()->idx_get(0)->get_Shapes());
```

## **Flip‑eigenschappen**

In Aspose.Slides biedt de klasse [ShapeFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shapeframe/) controle over horizontale en verticale spiegeling van vormen via de eigenschappen `flipH` en `flipV`. Beide eigenschappen zijn van het type [NullableBool](https://reference.aspose.com/slides/nl/cpp/aspose.slides/nullablebool/), waarmee waarden `True` een flip aangeven, `False` geen flip, of `NotDefined` voor het standaardgedrag. Deze waarden zijn toegankelijk via het [Frame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/get_frame/) van een vorm.

Om de flip‑instellingen te wijzigen, wordt een nieuw [ShapeFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shapeframe/)‑object gecreëerd met de huidige positie en grootte van de vorm, de gewenste waarden voor `flipH` en `flipV`, en de rotatie‑hoek. Door dit object toe te wijzen aan het [Frame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/get_frame/) van de vorm en de presentatie op te slaan, worden de spiegeltransformaties toegepast en weggeschreven naar het uitvoerbestand.

Stel dat we een bestand sample.pptx hebben waarin de eerste dia één vorm bevat met standaard flip‑instellingen, zoals hieronder weergegeven.

![De vorm die moet worden gespiegeld](shape_to_be_flipped.png)

De onderstaande code‑voorbeeld haalt de huidige flip‑eigenschappen van de vorm op en spiegelt deze zowel horizontaal als verticaal.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);

// Haal de horizontale flip-eigenschap van de vorm op.
auto horizontalFlip = shape->get_Frame()->get_FlipH();
Console::WriteLine(u"Horizontal flip: " + ObjectExt::ToString(horizontalFlip));

// Haal de verticale flip-eigenschap van de vorm op.
auto verticalFlip = shape->get_Frame()->get_FlipV();
Console::WriteLine(u"Vertical flip: " + ObjectExt::ToString(verticalFlip));

auto x = shape->get_Frame()->get_X();
auto y = shape->get_Frame()->get_Y();
auto width = shape->get_Frame()->get_Width();
auto height = shape->get_Frame()->get_Height();
auto flipH = NullableBool::True; // Flip horizontaal.
auto flipV = NullableBool::True; // Flip horizontaal.
auto rotation = shape->get_Frame()->get_Rotation();

shape->set_Frame(MakeObject<ShapeFrame>(x, y, width, height, flipH, flipV, rotation));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De gespiegeld vorm](flipped_shape.png)

## **FAQ**

**Kan ik vormen combineren (union/intersect/subtract) op een dia zoals in een desktop‑editor?**

Er is geen ingebouwde Boolean‑operatie‑API. U kunt het benaderen door zelf de gewenste omtrek te construeren—bijvoorbeeld de resulterende geometrie berekenen (via [GeometryPath](https://reference.aspose.com/slides/nl/cpp/aspose.slides/geometrypath/)) en een nieuwe vorm met die contour maken, eventueel de originele vormen verwijderen.

**Hoe kan ik de stapelvolgorde (z‑order) regelen zodat een vorm altijd “bovenop” blijft?**

Wijzig de invoeg‑/verplaatsvolgorde binnen de [shapes](https://reference.aspose.com/slides/nl/cpp/aspose.slides/baseslide/get_shapes/)‑collectie van de dia. Voor voorspelbare resultaten, finaliseer de z‑order na alle andere dia‑aanpassingen.

**Kan ik een vorm vergrendelen om te voorkomen dat gebruikers deze in PowerPoint kunnen bewerken?**

Ja. Stel [vorm‑specifieke beschermingsvlaggen](/slides/nl/cpp/applying-protection-to-presentation/) in (bijv. vergrendel selectie, verplaatsing, grootte wijzigen, tekstbewerking). Indien nodig kunt u de beperkingen op de master‑ of lay‑out repliceren. Merk op dat dit bescherming op UI‑niveau is, geen veiligheid‑functie; voor sterkere bescherming combineert u dit met bestands‑niveau restricties zoals [aanbevelingen voor alleen‑lezen of wachtwoorden](/slides/nl/cpp/password-protected-presentation/).