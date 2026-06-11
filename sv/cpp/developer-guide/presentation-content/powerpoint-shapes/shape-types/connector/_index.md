---
title: Hantera anslutare i presentationer med C++
linktitle: Anslutare
type: docs
weight: 10
url: /sv/cpp/connector/
keywords:
- anslutare
- anslutartyp
- anslutningspunkt
- anslutningslinje
- anslutningsvinkel
- koppla former
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Ge C++-program möjligheten att rita, ansluta och automatiskt rikta linjer i PowerPoint-bilder—få full kontroll över raka, krokiga och böjda anslutare."
---
## **Introduktion**

En PowerPoint‑anslutare är en speciell linje som kopplar samman två former och förblir fäst vid formerna även när de flyttas eller omplaceras på en given bild. 

Anslutare är vanligtvis anslutna till *anslutningspunkter* (gröna punkter), som finns på alla former som standard. Anslutningspunkter visas när en markör kommer nära dem.

*Justera‑punkter* (orange punkter), som endast finns på vissa anslutare, används för att ändra anslutarnas positioner och former.

## **Typer av anslutare**

I PowerPoint kan du använda raka, armbågs‑ (vinklade) och böjda anslutare. 

Aspose.Slides tillhandahåller dessa anslutare:

| Connector                      | Image                                                        | Antal justeringspunkter |
| ------------------------------ | ------------------------------------------------------------ | ----------------------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                       |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                       |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                       |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                       |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                       |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                       |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                       |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                       |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                       |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                       |

## **Koppla former med anslutare**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation/).
1. Hämta en bilds referens via dess index.
1. Lägg till två [AutoShape](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.auto_shape) på bilden med metoden `AddAutoShape` som exponeras av `Shapes`‑objektet.
1. Lägg till en anslutare med metoden `AddConnector` som exponeras av `Shapes`‑objektet genom att definiera anslutartypen.
1. Koppla ihop formerna med anslutaren. 
1. Anropa metoden `Reroute` för att tillämpa den kortaste anslutningsvägen.
1. Spara presentationen. 

Denna C++‑kod visar hur du lägger till en anslutare (en böjd anslutare) mellan två former (en ellips och en rektangel):

```c++
// Sökvägen till dokumentkatalogen.
	const String outPath = u"../out/ConnectShapesUsingConnectors_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Laddar den önskade presentationen
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Hämtar den första bilden
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Hämtar samlingen av former för en specifik bild
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Lägger till en Ellipse-autoshape
	SharedPtr<IAutoShape> ellipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);

	// Lägger till en Rectangle-autoshape
	SharedPtr<IAutoShape> rect = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);

	// Lägger till en anslutningsform i bildens formsamling
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector2, 0, 0, 10, 10);

	// Kopplar ihop formerna med anslutaren
	connector->set_StartShapeConnectedTo ( ellipse);
	connector->set_EndShapeConnectedTo (rect);

	// Anropar Reroute som sätter den automatiska kortaste vägen mellan formerna
	connector->Reroute();
	
	// Sparar presentationen
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert title="NOTE"  color="warning"   %}} 

`connector->Reroute`‑metoden omdirigerar en anslutare och tvingar den att ta den kortaste möjliga vägen mellan formerna. För att uppnå detta kan metoden ändra punkterna `StartShapeConnectionSiteIndex` och `EndShapeConnectionSiteIndex`. 

{{% /alert %}} 

## **Specificera en anslutningspunkt**

Om du vill att en anslutare ska länka två former med specifika punkter på formerna måste du ange dina föredragna anslutningspunkter på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation/).
1. Hämta en bilds referens via dess index.
1. Lägg till två [AutoShape](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.auto_shape) på bilden med metoden `AddAutoShape` som exponeras av `Shapes`‑objektet.
1. Lägg till en anslutare med metoden `AddConnector` som exponeras av `Shapes`‑objektet genom att definiera anslutartypen.
1. Koppla ihop formerna med anslutaren. 
1. Ange dina föredragna anslutningspunkter på formerna. 
1. Spara presentationen.

```c++
	// Sökvägen till dokumentkatalogen.
	const String outPath = u"../out/ConnectShapeUsingConnectionSite_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Laddar den önskade presentationen
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Hämtar den första bilden
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Hämtar samlingen av former för en specifik bild
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Lägg till en Ellipse-autoshape
	SharedPtr<IAutoShape> ellipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);

	// Lägg till en Rectangle-autoshape
	SharedPtr<IAutoShape> rect = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 200, 100, 100);

	// Lägger till en anslutningsform i bildens formsamling
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector3, 0, 0, 10, 10);

	// Kopplar ihop formerna med anslutaren
	connector->set_StartShapeConnectedTo(ellipse);
	connector->set_EndShapeConnectedTo(rect);


	// Ställer in föredragen anslutningspunktindex på Ellipse‑formen
	int wantedIndex = 6;

	// Kontrollerar om den föredragna indexen är mindre än det maximala antalet anslutningsställen
	if (ellipse->get_ConnectionSiteCount() > wantedIndex)
	{
		// Ställer in den föredragna anslutningspunkten på Ellipse‑autoshapen
		connector->set_StartShapeConnectionSiteIndex ( wantedIndex);
	}

	// Sparar presentationen
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Justera en anslutarpunkt**

Du kan justera en befintlig anslutare via dess justeringspunkter. Endast anslutare med justeringspunkter kan ändras på detta sätt. Se tabellen under **[Typer av anslutare.](/slides/sv/cpp/connector/#types-of-connectors)** 

### **Enkelt fall**

Tänk på ett fall där en anslutare mellan två former (A och B) passerar genom en tredje form (C):

![connector-obstruction](connector-obstruction.png)

Kod:

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

För att undvika eller gå runt den tredje formen kan vi justera anslutaren genom att flytta dess vertikala linje åt vänster på följande sätt:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```c++
auto adj2 = connector->get_Adjustments()->idx_get(1);
adj2->set_RawValue(adj2->get_RawValue() + 10000);
```

### **Komplexa fall** 

För att utföra mer komplicerade justeringar måste du ta hänsyn till följande:

* En anslutares justerbara punkt är starkt kopplad till en formel som beräknar och bestämmer dess position. Så en förändring av punktens plats kan ändra anslutarens form.
* En anslutares justeringspunkter definieras i en strikt ordning i en array. Justeringspunkterna numreras från anslutarens startpunkt till dess slutpunkt.
* Värdena för justeringspunkterna speglar procentandelen av en anslutningsforms bredd/höjd. 
  * Formen avgränsas av anslutarens start- och slutpunkter multiplicerade med 1000. 
  * Den första punkten, den andra punkten och den tredje punkten definierar procentandelen från bredden, procentandelen från höjden och procentandelen från bredden (igen) respektive.
* För beräkningar som bestämmer koordinaterna för en anslutares justeringspunkter måste du ta hänsyn till anslutarens rotation och dess reflektion. **Obs!** att rotationsvinkeln för alla anslutare som visas under **[Typer av anslutare](/slides/sv/cpp/connector/#types-of-connectors)** är 0.

#### **Fall 1**

Tänk på ett fall där två textramobjekt är länkade tillsammans via en anslutare:

![connector-shape-complex](connector-shape-complex.png)

Kod:

```c++
// Instansierar en presentationsklass som representerar en PPTX‑fil
auto pres = System::MakeObject<Presentation>();
// Hämtar den första bilden i presentationen
auto slide = pres->get_Slides()->idx_get(0);
// Hämtar former från den första bilden
auto shapes = slide->get_Shapes();
// Lägger till former som kommer att förenas via en anslutare
auto shapeFrom = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 60.0f, 25.0f);
shapeFrom->get_TextFrame()->set_Text(u"From");
auto shapeTo = shapes->AddAutoShape(ShapeType::Rectangle, 500.0f, 100.0f, 60.0f, 25.0f);
shapeTo->get_TextFrame()->set_Text(u"To");
// Lägger till en anslutare
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20.0f, 20.0f, 400.0f, 300.0f);
auto lineFormat = connector->get_LineFormat();
// Anger anslutarnas riktning
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
// Anger tjockleken på anslutningslinjen
lineFormat->set_Width(3);
// Anger anslutarnas färg
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(Aspose::Slides::FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Crimson());

// Kopplar ihop formerna med anslutaren
connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_StartShapeConnectionSiteIndex(3);
connector->set_EndShapeConnectedTo(shapeTo);
connector->set_EndShapeConnectionSiteIndex(2);

// Hämtar justeringspunkter för anslutaren
auto adjustments = connector->get_Adjustments();
auto adjValue_0 = adjustments->idx_get(0);
auto adjValue_1 = adjustments->idx_get(1);
```

**Justering**

Vi kan ändra anslutarens justeringspunktvärden genom att öka den motsvarande bredd- och höjdprocentandelen med 20 % respektive 200 %:

```c++
// Ändrar värdena för justeringspunkterna
adjValue_0->set_RawValue(adjValue_0->get_RawValue() + 20000);
adjValue_1->set_RawValue(adjValue_1->get_RawValue() + 200000);
```

Resultatet:

![connector-adjusted-1](connector-adjusted-1.png)

För att definiera en modell som låter oss bestämma koordinaterna och formen för enskilda delar av anslutaren, skapa en form som motsvarar den horisontella komponenten av anslutaren vid punkten connector.Adjustments[0]:

```c++
// Rita den vertikala komponenten av anslutaren
float x = connector->get_X() + connector->get_Width() * adjValue_0->get_RawValue() / 100000;
float y = connector->get_Y();
float height = connector->get_Height() * adjValue_1->get_RawValue() / 100000;
shapes->AddAutoShape(ShapeType::Rectangle, x, y, 0.0f, height);
```

Resultatet:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Fall 2**

I **Fall 1** demonstrerade vi en enkel anslutarjusteringsoperation med grundläggande principer. I vanliga situationer måste du ta hänsyn till anslutarens rotation och dess visning (som sätts av connector.Rotation, connector.Frame.FlipH och connector.Frame.FlipV). Vi kommer nu att demonstrera processen.

Först, låt oss lägga till ett nytt textramobjekt (**To 1**) på bilden (för anslutningsändamål) och skapa en ny (grön) anslutare som kopplar den till objekten vi redan skapat.

```c++
// Skapar ett nytt bindningsobjekt
auto shapeTo_1 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 400.0f, 60.0f, 25.0f);
shapeTo_1->get_TextFrame()->set_Text(u"To 1");
// Skapar en ny anslutare
connector = shapes->AddConnector(ShapeType::BentConnector4, 20.0f, 20.0f, 400.0f, 300.0f);
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
lineFormat->set_Width(3);
lineFillFormat->set_FillType(Aspose::Slides::FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_MediumAquamarine());
// Ansluter objekt med den nyss skapade anslutaren
connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_StartShapeConnectionSiteIndex(2);
connector->set_EndShapeConnectedTo(shapeTo_1);
connector->set_EndShapeConnectionSiteIndex(3);
// Hämtar justeringspunkter för anslutaren
adjValue_0 = adjustments->idx_get(0);
adjValue_1 = adjustments->idx_get(1);
// Ändrar värdena för justeringspunkterna
adjValue_0->set_RawValue(adjValue_0->get_RawValue() + 20000);
adjValue_1->set_RawValue(adjValue_1->get_RawValue() + 200000);
```

Resultatet:

![connector-adjusted-3](connector-adjusted-3.png)

Sedan, låt oss skapa en form som motsvarar den horisontella komponenten av anslutaren som passerar genom den nya anslutarens justeringspunkt connector.Adjustments[0]. Vi kommer att använda värdena från anslutardatan för connector.Rotation, connector.Frame.FlipH och connector.Frame.FlipV och tillämpa den vanliga koordinatomräkningsformeln för rotation runt en given punkt x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

I vårt fall är objektets rotationsvinkel 90 grader och anslutaren visas vertikalt, så detta är motsvarande kod:

```c++

```

Resultatet:

![connector-adjusted-4](connector-adjusted-4.png)

Vi demonstrerade beräkningar som involverar enkla justeringar och komplicerade justeringspunkter (justeringspunkter med rotationsvinklar). Med den kunskap du har fått kan du utveckla din egen modell (eller skriva kod) för att få ett `GraphicsPath`‑objekt eller till och med sätta en anslutares justeringspunktvärden baserat på specifika bildkoordinater.

## **Hitta vinkeln för anslutarlinjer**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation/).
1. Hämta en bilds referens via dess index.
1. Kom åt anslutningslinjens form.
1. Använd linjens bredd, höjd, formramens höjd och formramens bredd för att beräkna vinkeln.

```c++
void ConnectorLineAngle()
{

	// Sökvägen till dokumentkatalogen.
	const String outPath = u"../out/ConnectorLineAngle_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Laddar den önskade presentationen
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Hämtar den första bilden
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	for (int i = 0; i < slide->get_Shapes()->get_Count(); i++)
	{
		double dir = 0.0;
		// Hämtar formsamlingen för bilderna
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
	//float endLineY = h * (flipV ? -1 : 1);
	float endYAxisX = 0;
	float endYAxisY = h;
	double angle = (Math::Atan2(endYAxisY, endYAxisX) - Math::Atan2(endLineY, endLineX));
	if (angle < 0) angle += 2 * Math::PI;
	return angle * 180.0 / Math::PI;
}
```

## **Vanliga frågor**

**Hur kan jag avgöra om en anslutare kan "limmas" på en specifik form?**

Kontrollera att formen exponerar [anslutningsställen](https://reference.aspose.com/slides/sv/cpp/aspose.slides/shape/get_connectionsitecount/). Om det inte finns några eller om antalet är noll, är limning inte tillgänglig; i så fall använder du fria ändpunkter och placerar dem manuellt. Det är klokt att kontrollera antalet ställen innan du fäster.

**Vad händer med en anslutare om jag tar bort en av de anslutna formerna?**

Dess ändar kommer att lossna; anslutaren blir kvar på bilden som en vanlig linje med fria start- och slutpunkter. Du kan antingen ta bort den eller omdefiniera anslutningarna och, om så behövs, [omdirigera](https://reference.aspose.com/slides/sv/cpp/aspose.slides/connector/reroute/).

**Behålls anslutningsbindningar när en bild kopieras till en annan presentation?**

Vanligtvis ja, förutsatt att de målade formerna också kopieras. Om bilden infogas i en annan fil utan de anslutna formerna blir ändarna fria och du måste fästa dem igen.