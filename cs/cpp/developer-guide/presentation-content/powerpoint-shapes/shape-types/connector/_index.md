---
title: Správa konektorů v prezentacích pomocí C++
linktitle: Konektor
type: docs
weight: 10
url: /cs/cpp/connector/
keywords:
- konektor
- typ konektoru
- bod konektoru
- čára konektoru
- úhel konektoru
- propojit tvary
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Umožněte aplikacím v C++ kreslit, propojit a automaticky směrovat čáry v snímcích PowerPointu – získejte plnou kontrolu nad přímými, loketními a zakřivenými konektory."
---
## **Úvod**

Konektor PowerPoint je speciální čára, která spojuje dva tvary a zůstává k tvarům připojen i při jejich přesunu nebo převedení na daném snímku.  

Konektory jsou typicky připojeny k *připojovacím bodům* (zelené body), které jsou ve výchozím nastavení k dispozici na všech tvarech. Připojovací body se zobrazí, když se k nim kurzor přiblíží.  

*Úpravné body* (oranžové body), které existují pouze u některých konektorů, slouží k úpravě pozic a tvarů konektorů.  

## **Typy konektorů**

V PowerPointu můžete použít rovné, loketní (úhlové) a zakřivené konektory.  

Aspose.Slides poskytuje tyto konektory:

| Konektor                      | Obrázek                                                        | Počet úpravných bodů |
| ------------------------------ | ------------------------------------------------------------ | -------------------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                    |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                    |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                    |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                    |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                    |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                    |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                    |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                    |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                    |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                    |

## **Propojení tvarů pomocí konektorů**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation/) .
1. Získejte referenci na snímek podle jeho indexu.
1. Přidejte na snímek dva [AutoShape](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.auto_shape) pomocí metody `AddAutoShape`, kterou poskytuje objekt `Shapes`.
1. Přidejte konektor pomocí metody `AddConnector`, kterou poskytuje objekt `Shapes`, a definujte typ konektoru.
1. Propojte tvary pomocí konektoru. 
1. Zavolejte metodu `Reroute` pro použití nejkratší cesty spojení.
1. Uložte prezentaci. 

This C++ code shows you how to add a connector (a bent connector) between two shapes (an ellipse and rectangle):

```c++
// Cesta k adresáři dokumentů.
	const String outPath = u"../out/ConnectShapesUsingConnectors_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Načte požadovanou prezentaci
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Přistupuje k prvnímu snímku
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Přistupuje ke kolekci tvarů pro konkrétní snímek
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Přidá eliptický autoshape
	SharedPtr<IAutoShape> ellipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);

	// Přidá obdélníkový autoshape
	SharedPtr<IAutoShape> rect = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);

	// Přidá tvar konektoru do kolekce tvarů snímku
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector2, 0, 0, 10, 10);

	// Propojí tvary pomocí konektoru
	connector->set_StartShapeConnectedTo ( ellipse);
	connector->set_EndShapeConnectedTo (rect);

	// Zavolá Reroute, který nastaví automatickou nejkratší cestu mezi tvary
	connector->Reroute();
	
	// Uloží prezentaci
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert title="NOTE"  color="warning"   %}} 

`connector->Reroute` metoda přesměruje konektor a přinutí jej zvolit nejkratší možnou cestu mezi tvary. Aby dosáhla svého cíle, může metoda změnit body `StartShapeConnectionSiteIndex` a `EndShapeConnectionSiteIndex`. 

{{% /alert %}} 

## **Určení připojovacího bodu**

Pokud chcete, aby konektor propojil dva tvary pomocí konkrétních bodů na tvarech, musíte specifikovat požadované připojovací body tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation/) .
1. Získejte referenci na snímek podle jeho indexu.
1. Přidejte na snímek dva [AutoShape](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.auto_shape) pomocí metody `AddAutoShape`, kterou poskytuje objekt `Shapes`.
1. Přidejte konektor pomocí metody `AddConnector`, kterou poskytuje objekt `Shapes`, a definujte typ konektoru.
1. Propojte tvary pomocí konektoru. 
1. Nastavte požadované připojovací body na tvarech. 
1. Uložte prezentaci.

This C++ code demonstrates an operation where a preferred connection dot is specified:

```c++
	// Cesta k adresáři dokumentů.
	const String outPath = u"../out/ConnectShapeUsingConnectionSite_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Načte požadovanou prezentaci
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Přistupuje k prvnímu snímku
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Přistupuje ke kolekci tvarů pro konkrétní snímek
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Přidá eliptický autoshape
	SharedPtr<IAutoShape> ellipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);

	// Přidá obdélníkový autoshape
	SharedPtr<IAutoShape> rect = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 200, 100, 100);

	// Přidá tvar konektoru do kolekce tvarů snímku
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector3, 0, 0, 10, 10);

	// Propojí tvary pomocí konektoru
	connector->set_StartShapeConnectedTo(ellipse);
	connector->set_EndShapeConnectedTo(rect);


	// Nastaví preferovaný index připojovacího bodu na tvaru Elipsy
	int wantedIndex = 6;

	// Kontroluje, zda je preferovaný index menší než maximální počet míst
	if (ellipse->get_ConnectionSiteCount() > wantedIndex)
	{
		// Nastaví preferovaný připojovací bod na eliptickém autoshape
		connector->set_StartShapeConnectionSiteIndex ( wantedIndex);
	}

	// Uloží prezentaci
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Úprava bodu konektoru**

Můžete upravit existující konektor pomocí jeho úpravných bodů. Pouze konektory s úpravnými body mohou být tímto způsobem měněny. Viz tabulka pod **[Typy konektorů.](/slides/cs/cpp/connector/#types-of-connectors)** 

### **Jednoduchý případ**

Zvažte případ, kdy konektor mezi dvěma tvary (A a B) prochází třetím tvarem (C):

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

Abychom třetí tvar obešli nebo obešli, můžeme konektor upravit tak, že jeho svislou čáru posuneme doleva tímto způsobem:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```c++
auto adj2 = connector->get_Adjustments()->idx_get(1);
adj2->set_RawValue(adj2->get_RawValue() + 10000);
```

### **Komplexní případy** 

Pro provedení složitějších úprav musíte vzít v úvahu následující:

* Úprava bodu konektoru je úzce spojena s vzorcem, který vypočítává a určuje jeho polohu. Změny umístění bodu tak mohou změnit tvar konektoru.  
* Úpravné body konektoru jsou definovány v přísném pořadí v poli. Úpravné body jsou číslovány od počátečního bodu konektoru po koncový bod.  
* Hodnoty úpravných bodů vyjadřují procento šířky/výšky tvaru konektoru.  
  * Tvar je omezen počátečními a koncovými body konektoru vynásobenými 1000.  
  * První bod, druhý bod a třetí bod definují procento ze šířky, procento z výšky a opět procento ze šířky.  
* Pro výpočty určující souřadnice úpravných bodů konektoru musíte brát v úvahu rotaci konektoru a jeho odraz. **Poznámka**: úhel rotace všech konektorů zobrazených pod **[Typy konektorů](/slides/cs/cpp/connector/#types-of-connectors)** je 0.

#### **Případ 1**

Zvažte případ, kdy dva objekty textového rámečku jsou propojeny konektorem:

![connector-shape-complex](connector-shape-complex.png)

Code:

```c++
// Vytvoří instanci třídy prezentace, která reprezentuje soubor PPTX
auto pres = System::MakeObject<Presentation>();
// Získá první snímek v prezentaci
auto slide = pres->get_Slides()->idx_get(0);
// Získá tvary z prvního snímku
auto shapes = slide->get_Shapes();
// Přidá tvary, které budou propojeny pomocí konektoru
auto shapeFrom = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 60.0f, 25.0f);
shapeFrom->get_TextFrame()->set_Text(u"From");
auto shapeTo = shapes->AddAutoShape(ShapeType::Rectangle, 500.0f, 100.0f, 60.0f, 25.0f);
shapeTo->get_TextFrame()->set_Text(u"To");
// Přidá konektor
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20.0f, 20.0f, 400.0f, 300.0f);
auto lineFormat = connector->get_LineFormat();
// Určuje směr konektoru
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
// Určuje tloušťku čáry konektoru
lineFormat->set_Width(3);
// Určuje barvu konektoru
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(Aspose::Slides::FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Crimson());

// Propojí tvary pomocí konektoru
connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_StartShapeConnectionSiteIndex(3);
connector->set_EndShapeConnectedTo(shapeTo);
connector->set_EndShapeConnectionSiteIndex(2);

// Získá úpravy bodů pro konektor
auto adjustments = connector->get_Adjustments();
auto adjValue_0 = adjustments->idx_get(0);
auto adjValue_1 = adjustments->idx_get(1);
```

**Úprava**

Můžeme změnit hodnoty úpravných bodů konektoru zvýšením odpovídajících procent šířky a výšky o 20 % a 200 %:

```c++
// Mění hodnoty úpravných bodů
adjValue_0->set_RawValue(adjValue_0->get_RawValue() + 20000);
adjValue_1->set_RawValue(adjValue_1->get_RawValue() + 200000);
```

Výsledek:

![connector-adjusted-1](connector-adjusted-1.png)

Pro definování modelu, který nám umožní určit souřadnice a tvar jednotlivých částí konektoru, vytvořme tvar, který odpovídá horizontální složce konektoru v bodě connector.Adjustments[0]:

```c++
// Nakreslete svislou komponentu konektoru
float x = connector->get_X() + connector->get_Width() * adjValue_0->get_RawValue() / 100000;
float y = connector->get_Y();
float height = connector->get_Height() * adjValue_1->get_RawValue() / 100000;
shapes->AddAutoShape(ShapeType::Rectangle, x, y, 0.0f, height);
```

Výsledek:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Případ 2**

V **Případě 1** jsme ukázali jednoduchou operaci úpravy konektoru pomocí základních principů. V běžných situacích je nutné zohlednit rotaci konektoru a jeho zobrazení (které jsou nastaveny pomocí connector.Rotation, connector.Frame.FlipH a connector.Frame.FlipV). Nyní předvedeme postup.

Nejprve přidejme na snímek nový objekt textového rámečku (**To 1**) (pro potřeby spojení) a vytvořme nový (zelený) konektor, který jej propojí s již vytvořenými objekty.

```c++
// Vytvoří nový objekt vazby
auto shapeTo_1 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 400.0f, 60.0f, 25.0f);
shapeTo_1->get_TextFrame()->set_Text(u"To 1");
// Vytvoří nový konektor
connector = shapes->AddConnector(ShapeType::BentConnector4, 20.0f, 20.0f, 400.0f, 300.0f);
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
lineFormat->set_Width(3);
lineFillFormat->set_FillType(Aspose::Slides::FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_MediumAquamarine());
// Propojí objekty pomocí nově vytvořeného konektoru
connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_StartShapeConnectionSiteIndex(2);
connector->set_EndShapeConnectedTo(shapeTo_1);
connector->set_EndShapeConnectionSiteIndex(3);
// Získá úpravy bodů konektoru
adjValue_0 = adjustments->idx_get(0);
adjValue_1 = adjustments->idx_get(1);
// Mění hodnoty úpravných bodů
adjValue_0->set_RawValue(adjValue_0->get_RawValue() + 20000);
adjValue_1->set_RawValue(adjValue_1->get_RawValue() + 200000);
```

Výsledek:

![connector-adjusted-3](connector-adjusted-3.png)

Druhou částí vytvoříme tvar, který bude odpovídat horizontální součásti konektoru procházející novým úpravným bodem connector.Adjustments[0]. Použijeme hodnoty z dat konektoru pro connector.Rotation, connector.Frame.FlipH a connector.Frame.FlipV a aplikujeme běžný vzorec pro převod souřadnic při rotaci kolem daného bodu x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

V našem případě je úhel rotace objektu 90 stupňů a konektor je zobrazen vertikálně, takže odpovídající kód je:

```c++

```

Výsledek:

![connector-adjusted-4](connector-adjusted-4.png)

Ukázali jsme výpočty zahrnující jednoduché úpravy i složité úpravy bodů (úpravy bodů s úhly rotace). S využitím získaných znalostí můžete vytvořit vlastní model (nebo napsat kód) pro získání objektu `GraphicsPath` nebo dokonce nastavit hodnoty úpravných bodů konektoru na základě konkrétních souřadnic snímku.

## **Zjištění úhlu čar konektoru**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation/) .
1. Získejte referenci na snímek podle jeho indexu.
1. Získejte přístup k tvaru čáry konektoru.
1. Použijte šířku a výšku čáry, výšku a šířku rámce tvaru k výpočtu úhlu.

This C++ code demonstrates an operation in which we calculated the angle for a connector line shape:

```c++
void ConnectorLineAngle()
{

	// Cesta k adresáři dokumentů.
	const String outPath = u"../out/ConnectorLineAngle_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Načte požadovanou prezentaci
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Přistupuje k prvnímu snímku
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	for (int i = 0; i < slide->get_Shapes()->get_Count(); i++)
	{
		double dir = 0.0;
		// Přistupuje ke kolekci tvarů snímků
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

## **FAQ**

**Jak zjistit, zda lze konektor „přilepit“ k určitému tvaru?**

Zkontrolujte, zda tvar poskytuje [připojovací místa](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shape/get_connectionsitecount/). Pokud žádná nejsou nebo je jejich počet nulový, přilepení není možné; v takovém případě použijte volné koncové body a umístěte je ručně. Je rozumné zkontrolovat počet míst před připojením.

**Co se stane s konektorem, pokud smažu jeden ze spojených tvarů?**

Jeho konce se odpojí; konektor zůstane na snímku jako obyčejná čára s volnými počátečními/koncovými body. Můžete jej buď smazat, nebo přepojit spojení a v případě potřeby [přesměrovat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/connector/reroute/).

**Zůstávají vazby konektoru zachovány při kopírování snímku do jiné prezentace?**

Obecně ano, pokud jsou kopírovány i cílové tvary. Pokud je snímek vložen do jiného souboru bez připojených tvarů, konce se stanou volnými a budete je muset znovu připojit.