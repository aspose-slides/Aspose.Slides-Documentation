---
title: Beheer connectoren in presentaties met C++
linktitle: Connector
type: docs
weight: 10
url: /nl/cpp/connector/
keywords:
- connector
- type connector
- connectorpunt
- connectorlijn
- connectorhoek
- vormen verbinden
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Geef C++‑apps de mogelijkheid om lijnen te tekenen, te verbinden en automatisch te routeren in PowerPoint‑dia’s—krijg volledige controle over rechte, elleboog‑ en gebogen connectoren."
---
## **Introductie**

Een PowerPoint‑connector is een speciale lijn die twee vormen met elkaar verbindt of koppelt en gekoppeld blijft aan de vormen, zelfs wanneer ze worden verplaatst of opnieuw gepositioneerd op een bepaalde dia.  

Connectoren zijn meestal verbonden met *verbindingpuntjes* (groene puntjes), die standaard op alle vormen aanwezig zijn. Verbindingpuntjes verschijnen wanneer de cursor er dicht bij komt.

*Aanpassingspunten* (oranje puntjes), die alleen op bepaalde connectoren bestaan, worden gebruikt om de positie en vorm van connectoren aan te passen.

## **Soorten connectoren**

In PowerPoint kun je rechte, elleboog (hoekige) en gebogen connectoren gebruiken.  

Aspose.Slides biedt deze connectoren:

| Connector                      | Afbeelding                                                    | Aantal aanpassingspunten |
| ------------------------------ | ------------------------------------------------------------ | ------------------------ |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                        |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                        |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                        |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                        |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                        |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                        |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                        |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                        |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                        |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                        |

## **Vormen verbinden met connectoren**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation/) klasse aan.  
1. Haal een referentie naar een dia op via de index.  
1. Voeg twee [AutoShape](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.auto_shape) toe aan de dia met behulp van de `AddAutoShape`‑methode van het `Shapes`‑object.  
1. Voeg een connector toe met de `AddConnector`‑methode van het `Shapes`‑object door het type connector op te geven.  
1. Verbind de vormen met de connector.  
1. Roep de `Reroute`‑methode aan om het kortste verbindingspad toe te passen.  
1. Sla de presentatie op.  

Deze C++‑code laat zien hoe je een connector (een gebogen connector) tussen twee vormen (een ellips en een rechthoek) toevoegt:

```c++
 // Het pad naar de documentenmap.
	const String outPath = u"../out/ConnectShapesUsingConnectors_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Laadt de gewenste presentatie
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Toegang tot de eerste dia
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Toegang tot de vormverzameling voor een specifieke dia
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Voegt een ellips‑autosvorm toe
	SharedPtr<IAutoShape> ellipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);

	// Voegt een rechthoek‑autosvorm toe
	SharedPtr<IAutoShape> rect = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);

	// Voegt een connector‑vorm toe aan de vormverzameling van de dia
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector2, 0, 0, 10, 10);

	// Verbindt de vormen met de connector
	connector->set_StartShapeConnectedTo ( ellipse);
	connector->set_EndShapeConnectedTo (rect);

	// Roept reroute aan, die het automatische kortste pad tussen vormen instelt
	connector->Reroute();
	
	// Slaat de presentatie op
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert title="NOTE"  color="warning"   %}} 

De `connector->Reroute`‑methode herrouteert een connector en dwingt deze om het kortst mogelijke pad tussen vormen te volgen. Om dit te bereiken kan de methode de punten `StartShapeConnectionSiteIndex` en `EndShapeConnectionSiteIndex` wijzigen. 

{{% /alert %}} 

## **Een verbindingstipje specificeren**

Als je wilt dat een connector twee vormen verbindt via specifieke puntjes op de vormen, moet je de gewenste verbindingstippunten op deze manier opgeven:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation/) klasse aan.  
1. Haal een referentie naar een dia op via de index.  
1. Voeg twee [AutoShape](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.auto_shape) toe aan de dia met behulp van de `AddAutoShape`‑methode van het `Shapes`‑object.  
1. Voeg een connector toe met de `AddConnector`‑methode van het `Shapes`‑object door het type connector op te geven.  
1. Verbind de vormen met de connector.  
1. Stel je favoriete verbindingstippunten in op de vormen.  
1. Sla de presentatie op.  

Deze C++‑code toont een bewerking waarbij een voorkeursverbindingstipje wordt gespecificeerd:

```c++
	// Het pad naar de documentenmap.
	const String outPath = u"../out/ConnectShapeUsingConnectionSite_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Laadt de gewenste presentatie
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Toegang tot de eerste dia
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Toegang tot de vormverzameling voor een specifieke dia
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Voeg een ellips‑autosvorm toe
	SharedPtr<IAutoShape> ellipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);

	// Voeg een rechthoek‑autosvorm toe
	SharedPtr<IAutoShape> rect = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 200, 100, 100);

	// Voegt een connector‑vorm toe aan de vormverzameling van de dia
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector3, 0, 0, 10, 10);

	// Verbindt de vormen met de connector
	connector->set_StartShapeConnectedTo(ellipse);
	connector->set_EndShapeConnectedTo(rect);


	// Stelt het gewenste verbindingstipindex in op de ellips‑vorm
	int wantedIndex = 6;

	// Controleert of het gewenste index kleiner is dan het maximale aantal verbindingstoegangen
	if (ellipse->get_ConnectionSiteCount() > wantedIndex)
	{
		// Stelt het gewenste verbindingstip in op de ellips‑autosvorm
		connector->set_StartShapeConnectionSiteIndex ( wantedIndex);
	}

	// Slaat de presentatie op
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Een connectorpunt aanpassen**

Je kunt een bestaande connector aanpassen via zijn aanpassingspunten. Alleen connectoren met aanpassingspunten kunnen op deze manier worden gewijzigd. Zie de tabel onder **[Soorten connectoren.](/slides/nl/cpp/connector/#types-of-connectors)** 

### **Eenvoudig geval**

Beschouw een geval waarin een connector tussen twee vormen (A en B) door een derde vorm (C) loopt:

![connector-obstruction](connector-obstruction.png)

Code:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shapes = slide->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 300.0f, 150.0f, 150.0f, 75.0f);
auto shapeFrom = shapes->AddAutoShape(ShapeType::Rectangle, 500.0f, 400.0f, 100.0f, 50.0f);
auto shapeTo = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 70.0f, 30.0f);

auto connector = shapes->AddConnector(ShapeType::BentConnector5, 20.0f, 20.0f, 400.0f, 300.0f);

auto lineFormat = connector->get_LineFormat();
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());

connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_EndShapeConnectedTo(shapeTo);
connector->set_StartShapeConnectionSiteIndex(2);
```

Om de derde vorm te vermijden of te omzeilen, kunnen we de connector aanpassen door de verticale lijn naar links te verplaatsen op deze manier:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```c++
auto adj2 = connector->get_Adjustments()->idx_get(1);
adj2->set_RawValue(adj2->get_RawValue() + 10000);
```

### **Complexe gevallen** 

Om meer gecompliceerde aanpassingen uit te voeren, moet je rekening houden met het volgende:

* Het aanpasbare punt van een connector is nauw verbonden met een formule die zijn positie berekent en bepaalt. Wijzigingen in de locatie van het punt kunnen de vorm van de connector wijzigen.  
* De aanpassingspunten van een connector worden in een vaste volgorde in een array gedefinieerd. De aanpassingspunten worden genummerd van het startpunt van de connector tot het eindpunt.  
* De waarden van aanpassingspunten geven het percentage van de breedte/hoogte van de connectorvorm weer.  
  * De vorm wordt begrensd door de start‑ en eindpunten van de connector vermenigvuldigd met 1000.  
  * Het eerste punt, tweede punt en derde punt geven respectievelijk het percentage van de breedte, het percentage van de hoogte en opnieuw het percentage van de breedte weer.  
* Voor berekeningen die de coördinaten van de aanpassingspunten van een connector bepalen, moet je rekening houden met de rotatie en de reflectie van de connector. **Opmerking** dat de rotatiehoek voor alle connectoren die worden getoond onder **[Soorten connectoren](/slides/nl/cpp/connector/#types-of-connectors)** 0 is.  

#### **Case 1**

Beschouw een geval waarin twee tekstkaderobjecten via een connector met elkaar verbonden zijn:

![connector-shape-complex](connector-shape-complex.png)

Code:

```c++
// Instantieert een presentatieklasse die een PPTX-bestand vertegenwoordigt
auto pres = System::MakeObject<Presentation>();
// Haalt de eerste dia uit de presentatie
auto slide = pres->get_Slides()->idx_get(0);
// Verkrijgt de vormen van de eerste dia
auto shapes = slide->get_Shapes();
// Voegt vormen toe die via een connector worden gekoppeld
auto shapeFrom = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 60.0f, 25.0f);
shapeFrom->get_TextFrame()->set_Text(u"From");
auto shapeTo = shapes->AddAutoShape(ShapeType::Rectangle, 500.0f, 100.0f, 60.0f, 25.0f);
shapeTo->get_TextFrame()->set_Text(u"To");
// Voegt een connector toe
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20.0f, 20.0f, 400.0f, 300.0f);
auto lineFormat = connector->get_LineFormat();
// Specificeert de richting van de connector
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
// Specificeert de dikte van de connectorlijn
lineFormat->set_Width(3);
// Specificeert de kleur van de connector
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(Aspose::Slides::FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Crimson());

// Verbindt de vormen met de connector
connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_StartShapeConnectionSiteIndex(3);
connector->set_EndShapeConnectedTo(shapeTo);
connector->set_EndShapeConnectionSiteIndex(2);

// Verkrijgt de aanpassingspunten van de connector
auto adjustments = connector->get_Adjustments();
auto adjValue_0 = adjustments->idx_get(0);
auto adjValue_1 = adjustments->idx_get(1);
```

**Aanpassing**

We kunnen de waarden van de aanpassingspunten van de connector wijzigen door respectievelijk het bijbehorende percentage van de breedte en hoogte met 20 % en 200 % te verhogen:

```c++
// Wijzigt de waarden van de aanpassingspunten
adjValue_0->set_RawValue(adjValue_0->get_RawValue() + 20000);
adjValue_1->set_RawValue(adjValue_1->get_RawValue() + 200000);
```

Het resultaat:

![connector-adjusted-1](connector-adjusted-1.png)

Om een model te definiëren waarmee we de coördinaten en de vorm van individuele onderdelen van de connector kunnen bepalen, maken we een vorm die overeenkomt met de horizontale component van de connector op het punt `connector.Adjustments[0]`:

```c++
// Teken de verticale component van de connector
float x = connector->get_X() + connector->get_Width() * adjValue_0->get_RawValue() / 100000;
float y = connector->get_Y();
float height = connector->get_Height() * adjValue_1->get_RawValue() / 100000;
shapes->AddAutoShape(ShapeType::Rectangle, x, y, 0.0f, height);
```

Het resultaat:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Case 2**

In **Geval 1** hebben we een eenvoudige connectoraanpassing getoond met behulp van basisprincipes. In normale situaties moet je rekening houden met de rotatie van de connector en de weergave daarvan (die worden ingesteld via `connector.Rotation`, `connector.Frame.FlipH` en `connector.Frame.FlipV`). We zullen nu het proces demonstreren.

Eerst voegen we een nieuw tekstkaderobject (**To 1**) toe aan de dia (voor verbindingsdoeleinden) en maken we een nieuwe (groene) connector die het verbindt met de objecten die we al hebben aangemaakt.

```c++
// Maakt een nieuw bindingobject
auto shapeTo_1 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 400.0f, 60.0f, 25.0f);
shapeTo_1->get_TextFrame()->set_Text(u"To 1");
// Maakt een nieuwe connector
connector = shapes->AddConnector(ShapeType::BentConnector4, 20.0f, 20.0f, 400.0f, 300.0f);
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
lineFormat->set_Width(3);
lineFillFormat->set_FillType(Aspose::Slides::FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_MediumAquamarine());
// Verbindt objecten met de recent aangemaakte connector
connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_StartShapeConnectionSiteIndex(2);
connector->set_EndShapeConnectedTo(shapeTo_1);
connector->set_EndShapeConnectionSiteIndex(3);
// Haalt de aanpassingspunten van de connector op
adjValue_0 = adjustments->idx_get(0);
adjValue_1 = adjustments->idx_get(1);
// Wijzigt de waarden van de aanpassingspunten
adjValue_0->set_RawValue(adjValue_0->get_RawValue() + 20000);
adjValue_1->set_RawValue(adjValue_1->get_RawValue() + 200000);
```

Het resultaat:

![connector-adjusted-3](connector-adjusted-3.png)

Vervolgens maken we een vorm die overeenkomt met de horizontale component van de connector die door het nieuwe aanpassingspunt `connector.Adjustments[0]` loopt. We gebruiken de waarden uit de connectorgegevens voor `connector.Rotation`, `connector.Frame.FlipH` en `connector.Frame.FlipV` en passen de bekende formule voor coördinatenconversie bij rotatie rond een gegeven punt x0 toe:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

In ons geval is de rotatiehoek van het object 90 graden en wordt de connector verticaal weergegeven, dus dit is de bijbehorende code:

```c++

```

Het resultaat:

![connector-adjusted-4](connector-adjusted-4.png)

We hebben berekeningen gedemonstreerd met eenvoudige aanpassingen en complexe aanpassingspunten (aanpassingspunten met rotatiehoeken). Met de verworven kennis kun je je eigen model ontwikkelen (of code schrijven) om een `GraphicsPath`‑object te verkrijgen of zelfs de aanpassingspuntwaarden van een connector in te stellen op basis van specifieke dia‑coördinaten.

## **De hoek van connectorlijnen bepalen**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation/) klasse aan.  
1. Haal een referentie naar een dia op via de index.  
1. Toegang tot de connectorlijnvorm.  
1. Gebruik de breedte, hoogte, vormframe‑hoogte en vormframe‑breedte om de hoek te berekenen.  

Deze C++‑code toont een bewerking waarbij we de hoek van een connectorlijnvorm hebben berekend:

```c++
void ConnectorLineAngle()
{

	// Het pad naar de documentenmap.
	const String outPath = u"../out/ConnectorLineAngle_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Laadt de gewenste presentatie
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Haalt de eerste dia op
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	for (int i = 0; i < slide->get_Shapes()->get_Count(); i++)
	{
		double dir = 0.0;
		// Toegang tot de vormverzameling van de dia's
		System::SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(i);

		if (System::ObjectExt::Is<AutoShape>(shape))
		{
			SharedPtr<AutoShape> aShape = ExplicitCast<Aspose::Slides::AutoShape>(shape);
			if (aShape->get_ShapeType() == ShapeType::Line)
			{
				//				dir = getDirection(aShape->get_Width(), aShape->get_Height(), Convert::ToBoolean(aShape->get_Frame()->get_FlipH()), Convert::ToBoolean(aShape->get_Frame()->get_FlipV()));
				dir = getDirection(aShape->get_Width(), aShape->get_Height(), aShape->get_Frame()->get_FlipH(), aShape->get_Frame()->get_FlipV());

			}
		}

		else if (System::ObjectExt::Is<Connector>(shape))
		{
				SharedPtr<Connector> aShape = ExplicitCast<Aspose::Slides::Connector>(shape);
				//				dir = getDirection(aShape->get_Width(), aShape->get_Height(), Convert::ToBoolean(aShape->get_Frame()->get_FlipH()), Convert::ToBoolean(aShape->get_Frame()->get_FlipV()));
				dir = getDirection(aShape->get_Width(), aShape->get_Height(), aShape->get_Frame()->get_FlipH(),aShape->get_Frame()->get_FlipV());
		}

		Console::WriteLine(dir);
	
	}


}
//double ConnectorLineAngle::getDirection(float w, float h, NullableBool flipH, NullableBool flipV)
double getDirection(float w, float h, Aspose::Slides::NullableBool flipH, Aspose::Slides::NullableBool flipV)
{
	float endLineX = w;

	if (flipH == NullableBool::True)
		endLineX= endLineX * -1;
	else
		endLineX=endLineX *  1;
	//float endLineX = w * (flipH ? -1 : 1);
	float endLineY = h;
	if (flipV == NullableBool::True)
		endLineY = endLineY * -1;
	else
		endLineY = endLineY *  1;
	//	float endLineY = h * (flipV ? -1 : 1);
	float endYAxisX = 0;
	float endYAxisY = h;
	double angle = (Math::Atan2(endYAxisY, endYAxisX) - Math::Atan2(endLineY, endLineX));
	if (angle < 0) angle += 2 * Math::PI;
	return angle * 180.0 / Math::PI;
}
```

## **FAQ**

**Hoe kan ik zien of een connector op een bepaalde vorm kan worden 'geplakt'?**

Controleer of de vorm [verbindingstoegangen](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shape/get_connectionsitecount/) exposeert. Als er geen of een aantal van nul is, is plakken niet beschikbaar; in dat geval gebruik je vrije eindpunten en positioneer je ze handmatig. Het is verstandig om het aantal toegangen te controleren vóór het koppelen.

**Wat gebeurt er met een connector als ik een van de gekoppelde vormen verwijder?**

De uiteinden worden losgekoppeld; de connector blijft op de dia staan als een gewone lijn met vrije start/eind. Je kunt hem verwijderen of de verbindingen opnieuw toewijzen en, indien nodig, [reroute](https://reference.aspose.com/slides/nl/cpp/aspose.slides/connector/reroute/).

**Worden connectorverbindingen behouden bij het kopiëren van een dia naar een andere presentatie?**

Over het algemeen ja, mits de doelvormen ook worden gekopieerd. Als de dia in een ander bestand wordt ingevoegd zonder de gekoppelde vormen, worden de uiteinden vrij en moet je ze opnieuw koppelen.