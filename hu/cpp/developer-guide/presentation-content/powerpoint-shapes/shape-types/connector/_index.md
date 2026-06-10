---
title: "Csatlakozók kezelése bemutatókban C++ használatával"
linktitle: "Csatlakozó"
type: docs
weight: 10
url: /hu/cpp/connector/
keywords:
- "csatlakozó"
- "csatlakozó típus"
- "csatlakozó pont"
- "csatlakozó vonal"
- "csatlakozó szög"
- "alakzatok összekapcsolása"
- "PowerPoint"
- "bemutató"
- "C++"
- "Aspose.Slides"
description: "Lehetővé teszi C++ alkalmazások számára, hogy vonalakat rajzoljanak, összekapcsoljanak és automatikusan útvonalat tervezzenek a PowerPoint diákon – teljes irányítást biztosít a egyenes, könyök és íves csatlakozók felett."
---
## **Bevezetés**

A PowerPoint csatlakozó egy speciális vonal, amely két alakzatot kapcsol össze, és a alakzatokhoz kapcsolva marad akkor is, ha azok elmozdulnak vagy újra pozícionálásra kerülnek egy adott dián. 

A csatlakozók általában *kapcsolódási pontokhoz* (zöld pontok) csatlakoznak, amelyek alapértelmezés szerint minden alakzaton jelen vannak. A kapcsolódási pontok megjelennek, amikor a kurzor közel kerül hozzájuk.

*Állítópontok* (narancssárga pontok), amelyek csak bizonyos csatlakozókon léteznek, a csatlakozók pozíciójának és alakjának módosítására szolgálnak.

## **A Csatlakozók Típusai**

A PowerPointban egyenes, könyök (szögelt) és íves csatlakozókat használhat. 

Az Aspose.Slides a következő csatlakozókat biztosítja:

| Csatlakozó                      | Kép                                                        | Állítópontok száma |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                           |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                           |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                           |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                           |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                           |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                           |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                           |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                           |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                           |

## **Alakzatok Kapcsolása Csatlakozókkal**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation/) osztályból.  
1. Szerezze meg egy dia hivatkozását az indexe alapján.  
1. Adjon hozzá két [AutoShape](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.auto_shape) objektumot a diára a `Shapes` objektum által biztosított `AddAutoShape` metódussal.  
1. Adjon hozzá egy csatlakozót a `Shapes` objektum `AddConnector` metódusával, meghatározva a csatlakozó típusát.  
1. Kösse össze az alakzatokat a csatlakozóval.  
1. Hívja meg a `Reroute` metódust a legrövidebb kapcsolat útvonal alkalmazásához.  
1. Mentse a bemutatót.  

Ez a C++ kód bemutatja, hogyan adhat hozzá egy csatlakozót (egy hajlított csatlakozót) két alakzat (egy ellipszis és egy téglalap) között:

```c++
// A dokumentumok könyvtárának útvonala.
	const String outPath = u"../out/ConnectShapesUsingConnectors_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Betölti a kívánt bemutatót
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Eléri az első diát
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Hozzáfér egy adott dia alakzatgyűjteményéhez
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Hozzáad egy Ellipse automatikus alakzatot
	SharedPtr<IAutoShape> ellipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);

	// Hozzáad egy Rectangle automatikus alakzatot
	SharedPtr<IAutoShape> rect = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);

	// Hozzáad egy csatlakozó alakzatot a dia alakzatgyűjteményéhez
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector2, 0, 0, 10, 10);

	// Összekapcsolja az alakzatokat a csatlakozóval
	connector->set_StartShapeConnectedTo ( ellipse);
	connector->set_EndShapeConnectedTo (rect);

	// Meghívja a reroute-ot, amely beállítja az automatikus legrövidebb útvonalat az alakzatok között
	connector->Reroute();
	
	// Elmenti a bemutatót
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert title="NOTE"  color="warning"   %}} 
`connector->Reroute` metódus újraútvonalazza a csatlakozót, és a két alakzat közötti legrövidebb lehetséges útvonalat kényszeríti. Ennek eléréséhez a metódus módosíthatja a `StartShapeConnectionSiteIndex` és `EndShapeConnectionSiteIndex` pontokat. 
{{% /alert %}} 

## **Kapcsolódási Pont Megadása**

Ha azt szeretné, hogy egy csatlakozó két alakzatot összekapcsoljon a alakzatokon lévő konkrét pontok használatával, a kívánt kapcsolódási pontokat a következő módon kell megadni:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation/) osztályból.  
1. Szerezze meg egy dia hivatkozását az indexe alapján.  
1. Adjon hozzá két [AutoShape](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.auto_shape) objektumot a diára a `Shapes` objektum által biztosított `AddAutoShape` metódussal.  
1. Adjon hozzá egy csatlakozót a `Shapes` objektum `AddConnector` metódusával, meghatározva a csatlakozó típusát.  
1. Kösse össze az alakzatokat a csatlakozóval.  
1. Állítsa be a kívánt kapcsolódási pontokat az alakzatokon.  
1. Mentse a bemutatót.  

Ez a C++ kód egy műveletet mutat be, ahol egy előnyben részesített kapcsolódási pont van megadva:

```c++
	// A dokumentumok könyvtárának útvonala.
	const String outPath = u"../out/ConnectShapeUsingConnectionSite_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Betölti a kívánt bemutatót
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Eléri az első diát
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Hozzáfér egy adott dia alakzatgyűjteményéhez
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Hozzáad egy Ellipse automatikus alakzatot
	SharedPtr<IAutoShape> ellipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);

	// Hozzáad egy Rectangle automatikus alakzatot
	SharedPtr<IAutoShape> rect = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 200, 100, 100);

	// Hozzáad egy csatlakozó alakzatot a dia alakzatgyűjteményéhez
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector3, 0, 0, 10, 10);

	// Összekapcsolja az alakzatokat a csatlakozóval
	connector->set_StartShapeConnectedTo(ellipse);
	connector->set_EndShapeConnectedTo(rect);


	// Beállítja a kívánt kapcsolódási pont indexet az Ellipse alakzaton
	int wantedIndex = 6;

	// Ellenőrzi, hogy a kívánt index kisebb-e a maximális helyindex számnál
	if (ellipse->get_ConnectionSiteCount() > wantedIndex)
	{
		// Beállítja a kívánt kapcsolódási pontot az Ellipse automatikus alakzaton
		connector->set_StartShapeConnectionSiteIndex ( wantedIndex);
	}

	// Elmenti a bemutatót
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Csatlakozó Pontjának Módosítása**

Meglévő csatlakozót a hozzá tartozó állítópontok segítségével módosíthat. Csak azok a csatlakozók módosíthatók így, amelyek rendelkeznek állítópontokkal. Lásd a táblázatot a **[A Csatlakozók Típusai](/slides/hu/cpp/connector/#types-of-connectors)** alatt. 

### **Egyszerű Eset**

Tekintsünk egy esetet, ahol egy csatlakozó két alakzat (A és B) között áthalad egy harmadik alakzaton (C):

![connector-obstruction](connector-obstruction.png)

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

A harmadik alakzat elkerülése vagy megkerülése érdekében a csatlakozót úgy állíthatjuk, hogy a függőleges vonalát balra mozdítjuk:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```c++
auto adj2 = connector->get_Adjustments()->idx_get(1);
adj2->set_RawValue(adj2->get_RawValue() + 10000);
```

### **Összetett Esetek** 

Összetettebb módosítások elvégzéséhez az alábbiakat kell figyelembe venni:

* Egy csatlakozó állítható pontja szorosan összefügg egy olyan képlettel, amely kiszámítja és meghatározza a pozícióját. Így a pont helyzetének megváltoztatása a csatlakozó alakját is módosíthatja.  
* A csatlakozó állítópontjai szigorú sorrendben vannak definiálva egy tömbben. Az állítópontok számozása a csatlakozó kezdőpontjától a végéig tart.  
* Az állítópont értékek a csatlakozó alakzat szélességének/magasságának százalékát tükrözik.  
  * Az alakzat a csatlakozó kezdő- és végpontjainak 1000-szeresével határolt.  
  * Az első pont, a második pont és a harmadik pont sorban a szélesség, a magasság és újra a szélesség százalékát határozza meg.  
* A csatlakozó állítópontjainak koordinátáit meghatározó számításoknál figyelembe kell venni a csatlakozó forgatását és tükrözését. **Megjegyzés**: a **[A Csatlakozók Típusai](/slides/hu/cpp/connector/#types-of-connectors)** alatt látható összes csatlakozó forgatási szöge 0.  

#### **Eset 1**

Tekintsünk egy esetet, ahol két szövegkeret objektumot egy csatlakozó köt össze:

![connector-shape-complex](connector-shape-complex.png)

```c++
// PPTX fájlt képviselő bemutatóosztályt példányosít
auto pres = System::MakeObject<Presentation>();
// A bemutató első diáját lekéri
auto slide = pres->get_Slides()->idx_get(0);
// Alakzatokat kap az első diáról
auto shapes = slide->get_Shapes();
// Alakzatokat ad hozzá, amelyeket egy csatlakozóval fog összekapcsolni
auto shapeFrom = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 60.0f, 25.0f);
shapeFrom->get_TextFrame()->set_Text(u"From");
auto shapeTo = shapes->AddAutoShape(ShapeType::Rectangle, 500.0f, 100.0f, 60.0f, 25.0f);
shapeTo->get_TextFrame()->set_Text(u"To");
// Hozzáad egy csatlakozót
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20.0f, 20.0f, 400.0f, 300.0f);
auto lineFormat = connector->get_LineFormat();
// Megadja a csatlakozó irányát
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
// Megadja a csatlakozó vonalának vastagságát
lineFormat->set_Width(3);
// Megadja a csatlakozó színét
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(Aspose::Slides::FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Crimson());

// Kapcsolja össze az alakzatokat a csatlakozóval
connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_StartShapeConnectionSiteIndex(3);
connector->set_EndShapeConnectedTo(shapeTo);
connector->set_EndShapeConnectionSiteIndex(2);

// Lekéri a csatlakozó állítópontjait
auto adjustments = connector->get_Adjustments();
auto adjValue_0 = adjustments->idx_get(0);
auto adjValue_1 = adjustments->idx_get(1);
```

**Adjustment**

Megváltoztathatjuk a csatlakozó állítópont értékeit, ha a megfelelő szélesség- és magasság százalékát rendre 20%-kal és 200%-kal növeljük:

```c++
// Módosítja az állítópontok értékeit
adjValue_0->set_RawValue(adjValue_0->get_RawValue() + 20000);
adjValue_1->set_RawValue(adjValue_1->get_RawValue() + 200000);
```

Az eredmény:

![connector-adjusted-1](connector-adjusted-1.png)

Annak a modellnek a meghatározásához, amely lehetővé teszi a csatlakozó egyes részeinek koordinátáinak és alakjának meghatározását, hozzunk létre egy alakzatot, amely a csatlakozó vízszintes komponensének felel meg a connector.Adjustments[0] pontnál:

```c++
// Kirajzolja a csatlakozó függőleges komponensét
float x = connector->get_X() + connector->get_Width() * adjValue_0->get_RawValue() / 100000;
float y = connector->get_Y();
float height = connector->get_Height() * adjValue_1->get_RawValue() / 100000;
shapes->AddAutoShape(ShapeType::Rectangle, x, y, 0.0f, height);
```

Az eredmény:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Eset 2**

**Eset 1**-ben egyszerű csatlakozóállítási műveletet mutattunk be alapelvek segítségével. Normál helyzetekben figyelembe kell venni a csatlakozó forgatását és megjelenítését (amelyeket a connector.Rotation, connector.Frame.FlipH és connector.Frame.FlipV állít be). Most bemutatjuk a folyamatot.

Először adjunk egy új szövegkeret objektumot (**To 1**) a diához (kapcsolódási célból), és hozzunk létre egy új (zöld) csatlakozót, amely összeköti azt a már létrehozott objektumokkal.

```c++
// Új kötési objektumot hoz létre
auto shapeTo_1 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 400.0f, 60.0f, 25.0f);
shapeTo_1->get_TextFrame()->set_Text(u"To 1");
// Új csatlakozót hoz létre
connector = shapes->AddConnector(ShapeType::BentConnector4, 20.0f, 20.0f, 400.0f, 300.0f);
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
lineFormat->set_Width(3);
lineFillFormat->set_FillType(Aspose::Slides::FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_MediumAquamarine());
// Az újonnan létrehozott csatlakozóval összekapcsolja az objektumokat
connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_StartShapeConnectionSiteIndex(2);
connector->set_EndShapeConnectedTo(shapeTo_1);
connector->set_EndShapeConnectionSiteIndex(3);
// Lekéri a csatlakozó állítópontjait
adjValue_0 = adjustments->idx_get(0);
adjValue_1 = adjustments->idx_get(1);
// Módosítja az állítópontok értékeit
adjValue_0->set_RawValue(adjValue_0->get_RawValue() + 20000);
adjValue_1->set_RawValue(adjValue_1->get_RawValue() + 200000);
```

Az eredmény:

![connector-adjusted-3](connector-adjusted-3.png)

Másodszor hozzunk létre egy alakzatot, amely a csatlakozó vízszintes komponensének felel meg, amely áthalad az új csatlakozó connector.Adjustments[0] állítópontján. Felhasználjuk a connector.Rotation, connector.Frame.FlipH és connector.Frame.FlipV értékeket, és alkalmazzuk a népszerű koordináta‑konverziós képletet egy adott x0 pont körüli forgatáshoz:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

Mi esetünkben az objektum forgatási szöge 90 fok, és a csatlakozó függőlegesen jelenik meg, ezért ez a megfelelő kód:

```c++

```

Az eredmény:

![connector-adjusted-4](connector-adjusted-4.png)

Bemutattuk a egyszerű módosításokat és az összetett állítópontokat (forgatási szögekkel rendelkező állítópontok) érintő számításokat. A megszerzett tudás segítségével saját modellt fejleszthet (vagy kódot írhat), amely `GraphicsPath` objektumot ad, vagy akár a csatlakozó állítópont értékeit konkrét dia‑koordináták alapján állítja be.

## **A Csatlakozó Vonalak Szögének Meghatározása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation/) osztályból.  
1. Szerezze meg egy dia hivatkozását az indexe alapján.  
1. Hozzáférés a csatlakozó vonal alakzathoz.  
1. A vonal szélességét, magasságát, az alakzat keret magasságát és szélességét használja a szög kiszámításához.  

Ez a C++ kód egy olyan műveletet mutat be, ahol a csatlakozó vonal alakzat szögét számoltuk ki:

```c++
void ConnectorLineAngle()
{

	// A dokumentumok könyvtárának útvonala.
	const String outPath = u"../out/ConnectorLineAngle_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Betölti a kívánt bemutatót
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Eléri az első diát
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	for (int i = 0; i < slide->get_Shapes()->get_Count(); i++)
	{
		double dir = 0.0;
		// Eléri a diák alakzatgyűjteményét
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

## **GYIK**

**Hogyan tudom megállapítani, hogy egy csatlakozó „ragasztható‑e” egy adott alakzatra?**

Ellenőrizze, hogy az alakzat rendelkezik-e [kapcsolódási pontokkal](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shape/get_connectionsitecount/). Ha nincsenek, vagy a számuk nulla, a ragasztás nem lehetséges; ilyen esetben használjon szabad végpontokat, és helyezze el őket kézzel. Érdemes a pontok számát ellenőrizni a csatlakoztatás előtt.

**Mi történik egy csatlakozóval, ha törlöm a csatlakoztatott alakzatok egyikét?**

A végei leválnak; a csatlakozó a dián egy szabad kezdő‑ és végpontú vonalként marad. Törölheti, vagy újra hozzárendelheti a kapcsolatokat, és szükség esetén [újratervezi](https://reference.aspose.com/slides/hu/cpp/aspose.slides/connector/reroute/).

**Megmaradnak a csatlakozó kötődések, ha egy diát átmásolok egy másik bemutatóba?**

Általában igen, amennyiben a célalakzatok is másolásra kerülnek. Ha a dia egy másik fájlba kerül beillesztésre a csatlakoztatott alakzatok nélkül, a végek szabadok lesznek, és újra kell csatlakoztatni őket.