---
title: Connector
type: docs
weight: 10
url: /de/cpp/connector/
keywords: "Formen verbinden, Verbinder, PowerPoint Formen, PowerPoint Präsentation, C++, CPP, Aspose.Slides für C++"
description: "Verbinden Sie PowerPoint Formen in C++"
---

Ein PowerPoint-Verbinder ist eine spezielle Linie, die zwei Formen miteinander verbindet oder verknüpft und an den Formen bleibt, selbst wenn diese auf einer bestimmten Folie verschoben oder neu positioniert werden.

Verbinder sind typischerweise mit *Verbindungspunkten* (grüne Punkte) verbunden, die standardmäßig auf allen Formen existieren. Verbindungspunkte erscheinen, wenn der Cursor ihnen nahe kommt.

*Anpassungspunkte* (orange Punkte), die nur auf bestimmten Verbinder existieren, werden verwendet, um die Positionen und Formen der Verbinder zu ändern.

## **Arten von Verbindern**

In PowerPoint können Sie gerade, Winkel (gekrümmte) und gebogene Verbinder verwenden.

Aspose.Slides bietet diese Verbinder an:

| Verbinder                      | Bild                                                        | Anzahl der Anpassungspunkte |
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

## **Formen mit Verbindern verbinden**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) Klasse.
1. Holen Sie sich die Referenz einer Folie über ihren Index.
1. Fügen Sie zwei [AutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.auto_shape) zur Folie mit der `AddAutoShape` Methode hinzu, die vom `Shapes` Objekt bereitgestellt wird.
1. Fügen Sie einen Verbinder mit der `AddConnector` Methode hinzu, die vom `Shapes` Objekt bereitgestellt wird, indem Sie den Verbindungstyp definieren.
1. Verbinden Sie die Formen mit dem Verbinder.
1. Rufen Sie die Methode `Reroute` auf, um den kürzesten Verbindungsweg anzuwenden.
1. Speichern Sie die Präsentation.

Dieser C++-Code zeigt Ihnen, wie Sie einen Verbinder (einen gebogenen Verbinder) zwischen zwei Formen (einer Ellipse und einem Rechteck) hinzufügen:

```c++
// Der Pfad zum Dokumentenverzeichnis.
	const String outPath = u"../out/ConnectShapesUsingConnectors_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Lädt die gewünschte Präsentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Greift auf die erste Folie zu
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Greift auf die Formen-Sammlung für eine bestimmte Folie zu
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Fügt eine Ellipse Autoform hinzu
	SharedPtr<IAutoShape> ellipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);

	// Fügt eine Rechteck Autoform hinzu
	SharedPtr<IAutoShape> rect = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);

	// Fügt eine Verbinderform zur Folienform-Sammlung hinzu
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector2, 0, 0, 10, 10);

	// Verbindet die Formen mit dem Verbinder
	connector->set_StartShapeConnectedTo ( ellipse);
	connector->set_EndShapeConnectedTo (rect);

	// Ruft reroute auf, das den automatischen kürzesten Weg zwischen den Formen festlegt
	connector->Reroute();
	
	// Speichert die Präsentation
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert title="HINWEIS"  color="warning"   %}} 

Die Methode `connector->Reroute` ändert die Route eines Verbinders und zwingt ihn dazu, den kürzest möglichen Weg zwischen den Formen zu nehmen. Um dieses Ziel zu erreichen, kann die Methode die Punkte `StartShapeConnectionSiteIndex` und `EndShapeConnectionSiteIndex` ändern. 

{{% /alert %}} 

## **Verbindungspunkt angeben**

Wenn Sie möchten, dass ein Verbinder zwei Formen über bestimmte Punkte auf den Formen verknüpft, müssen Sie Ihre bevorzugten Verbindungspunkte folgendermaßen angeben:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) Klasse.
1. Holen Sie sich die Referenz einer Folie über ihren Index.
1. Fügen Sie zwei [AutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.auto_shape) zur Folie mit der `AddAutoShape` Methode hinzu, die vom `Shapes` Objekt bereitgestellt wird.
1. Fügen Sie einen Verbinder mit der `AddConnector` Methode hinzu, die vom `Shapes` Objekt bereitgestellt wird, indem Sie den Verbindungstyp definieren.
1. Verbinden Sie die Formen mit dem Verbinder.
1. Legen Sie Ihre bevorzugten Verbindungspunkte auf den Formen fest.
1. Speichern Sie die Präsentation.

Dieser C++-Code demonstriert einen Vorgang, bei dem ein bevorzugter Verbindungspunkt angegeben wird:

```c++
	// Der Pfad zum Dokumentenverzeichnis.
	const String outPath = u"../out/ConnectShapeUsingConnectionSite_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Lädt die gewünschte Präsentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Greift auf die erste Folie zu
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Greift auf die Formen-Sammlung für eine bestimmte Folie zu
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Fügt eine Ellipse Autoform hinzu
	SharedPtr<IAutoShape> ellipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);

	// Fügt eine Rechteck Autoform hinzu
	SharedPtr<IAutoShape> rect = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 200, 100, 100);

	// Fügt eine Verbinderform zur Folienform-Sammlung hinzu
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector3, 0, 0, 10, 10);

	// Verbindet die Formen mit dem Verbinder
	connector->set_StartShapeConnectedTo(ellipse);
	connector->set_EndShapeConnectedTo(rect);


	// Legt den bevorzugten Verbindungspunktindex auf der Ellipsenform fest
	int wantedIndex = 6;

	// Überprüft, ob der bevorzugte Index kleiner als die maximale Anzahl an Verbindungspunkten ist
	if (ellipse->get_ConnectionSiteCount() > wantedIndex)
	{
		// Legt den bevorzugten Verbindungspunkt auf der Ellipsen Autoform fest
		connector->set_StartShapeConnectionSiteIndex ( wantedIndex);
	}

	// Speichert die Präsentation
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Verbinder Punkt anpassen**

Sie können einen vorhandenen Verbinder über seine Anpassungspunkte anpassen. Nur Verbinder mit Anpassungspunkten können auf diese Weise geändert werden. Siehe die Tabelle unter **[Arten von Verbindern.](/slides/de/cpp/connector/#types-of-connectors)** 

#### **Einfacher Fall**

Betrachten Sie einen Fall, in dem ein Verbinder zwischen zwei Formen (A und B) durch eine dritte Form (C) verläuft:

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

Um die dritte Form zu vermeiden oder zu umgehen, können wir den Verbinder anpassen, indem wir seine vertikale Linie nach links verschieben:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```c++
auto adj2 = connector->get_Adjustments()->idx_get(1);
adj2->set_RawValue(adj2->get_RawValue() + 10000);
```

### **Komplexe Fälle** 

Um kompliziertere Anpassungen vorzunehmen, müssen Sie diese Dinge berücksichtigen:

* Ein einstellbarer Punkt eines Verbinders ist eng mit einer Formel verbunden, die seine Position berechnet und bestimmt. Änderungen am Standort des Punktes können die Form des Verbinders ändern.
* Die Anpassungspunkte eines Verbinders sind in einer strengen Reihenfolge in einem Array definiert. Die Anpassungspunkte sind von einem Startpunkt des Verbinders bis zu seinem Endpunkt nummeriert.
* Die Werte der Anpassungspunkte spiegeln den Prozentsatz der Breite/Höhe der Verbinderform wider.
  * Die Form wird durch die Start- und Endpunkte des Verbinders multipliziert mit 1000 begrenzt. 
  * Der erste Punkt, der zweite Punkt und der dritte Punkt definieren den Prozentsatz von der Breite, den Prozentsatz von der Höhe und den Prozentsatz von der Breite (noch einmal), jeweils.
* Für Berechnungen, die die Koordinaten der Anpassungspunkte eines Verbinders bestimmen, müssen Sie die Drehung und Reflexion des Verbinders berücksichtigen. **Hinweis**: Der Drehwinkel für alle in **[Arten von Verbindern](/slides/de/cpp/connector/#types-of-connectors)** gezeigten Verbinder beträgt 0.

#### **Fall 1**

Betrachten Sie einen Fall, in dem zwei Textrahmenobjekte durch einen Verbinder miteinander verbunden sind:

![connector-shape-complex](connector-shape-complex.png)

Code:

```c++
// Instanziiert eine Präsentationsklasse, die eine PPTX-Datei darstellt
auto pres = System::MakeObject<Presentation>();
// Holt sich die erste Folie in der Präsentation
auto slide = pres->get_Slides()->idx_get(0);
// Holt sich die Formen von der ersten Folie
auto shapes = slide->get_Shapes();
// Fügt Formen hinzu, die durch einen Verbinder verbunden werden
auto shapeFrom = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 60.0f, 25.0f);
shapeFrom->get_TextFrame()->set_Text(u"Von");
auto shapeTo = shapes->AddAutoShape(ShapeType::Rectangle, 500.0f, 100.0f, 60.0f, 25.0f);
shapeTo->get_TextFrame()->set_Text(u"Zu");
// Fügt einen Verbinder hinzu
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20.0f, 20.0f, 400.0f, 300.0f);
auto lineFormat = connector->get_LineFormat();
// Gibt die Richtung des Verbinders an
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
// Gibt die Dicke der Verbinderlinie an
lineFormat->set_Width(3);
// Gibt die Farbe des Verbinders an
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(Aspose::Slides::FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Crimson());

// Verbindet die Formen miteinander mit dem Verbinder
connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_StartShapeConnectionSiteIndex(3);
connector->set_EndShapeConnectedTo(shapeTo);
connector->set_EndShapeConnectionSiteIndex(2);

// Holt sich die Anpassungspunkte für den Verbinder
auto adjustments = connector->get_Adjustments();
auto adjValue_0 = adjustments->idx_get(0);
auto adjValue_1 = adjustments->idx_get(1);
```

**Anpassung**

Wir können die Werte der Anpassungspunkte des Verbinders ändern, indem wir den entsprechenden Breiten- und Höhenprozentsatz um 20 % bzw. 200 % erhöhen:

```c++
// Ändert die Werte der Anpassungspunkte
adjValue_0->set_RawValue(adjValue_0->get_RawValue() + 20000);
adjValue_1->set_RawValue(adjValue_1->get_RawValue() + 200000);
```

Das Ergebnis:

![connector-adjusted-1](connector-adjusted-1.png)

Um ein Modell zu definieren, das es uns ermöglicht, die Koordinaten und die Form der einzelnen Teile des Verbinders zu bestimmen, erstellen wir eine Form, die dem horizontalen Bestandteil des Verbinders am Punkt connector.Adjustments[0] entspricht:

```c++
// Zeichnet den vertikalen Bestandteil des Verbinders
float x = connector->get_X() + connector->get_Width() * adjValue_0->get_RawValue() / 100000;
float y = connector->get_Y();
float height = connector->get_Height() * adjValue_1->get_RawValue() / 100000;
shapes->AddAutoShape(ShapeType::Rectangle, x, y, 0.0f, height);
```

Das Ergebnis:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Fall 2**

In **Fall 1** haben wir eine einfache Anpassungsoperation eines Verbinders unter Verwendung grundlegender Prinzipien demonstriert. In normalen Situationen müssen Sie die Drehung des Verbinders und seine Anzeige (die durch `connector.Rotation`, `connector.Frame.FlipH` und `connector.Frame.FlipV` festgelegt werden) berücksichtigen. Wir werden jetzt den Prozess demonstrieren.

Zuerst fügen wir ein neues Textrahmenobjekt (**Zu 1**) zur Folie hinzu (zum Verknüpfen) und erstellen einen neuen (grünen) Verbinder, der es mit den bereits erstellten Objekten verbindet.

```c++
// Erstellt ein neues Bindungsobjekt
auto shapeTo_1 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 400.0f, 60.0f, 25.0f);
shapeTo_1->get_TextFrame()->set_Text(u"Zu 1");
// Erstellt einen neuen Verbinder
connector = shapes->AddConnector(ShapeType::BentConnector4, 20.0f, 20.0f, 400.0f, 300.0f);
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
lineFormat->set_Width(3);
lineFillFormat->set_FillType(Aspose::Slides::FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_MediumAquamarine());
// Verbindet die Objekte mit dem neu erstellten Verbinder
connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_StartShapeConnectionSiteIndex(2);
connector->set_EndShapeConnectedTo(shapeTo_1);
connector->set_EndShapeConnectionSiteIndex(3);
// Holt sich die Anpassungspunkte des Verbinders
adjValue_0 = adjustments->idx_get(0);
adjValue_1 = adjustments->idx_get(1);
// Ändert die Werte der Anpassungspunkte
adjValue_0->set_RawValue(adjValue_0->get_RawValue() + 20000);
adjValue_1->set_RawValue(adjValue_1->get_RawValue() + 200000);
```

Das Ergebnis:

![connector-adjusted-3](connector-adjusted-3.png)

Zweitens erstellen wir eine Form, die dem horizontalen Bestandteil des Verbinders entspricht, der durch den neuen Anpassungspunkt des Verbinders `connector.Adjustments[0]` verläuft. Wir werden die Werte aus den Verbinderdaten für `connector.Rotation`, `connector.Frame.FlipH` und `connector.Frame.FlipV` verwenden und die beliebte Formel zur Koordinatenumwandlung für eine Rotationsumgebung um einen bestimmten Punkt `x0` anwenden:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

In unserem Fall beträgt der Rotationswinkel des Objekts 90 Grad und der Verbinder wird vertikal angezeigt, sodass dies der entsprechende Code ist:

```c++

```

Das Ergebnis:

![connector-adjusted-4](connector-adjusted-4.png)

Wir haben Berechnungen durchgeführt, die einfache Anpassungen und komplizierte Anpassungspunkte (Anpassungspunkte mit Rotationswinkeln) betreffen. Mit dem erworbenen Wissen können Sie Ihr eigenes Modell entwickeln (oder einen Code schreiben), um ein `GraphicsPath`-Objekt zu erhalten oder sogar die Werte der Anpassungspunkte eines Verbinders basierend auf bestimmten Folienkoordinaten festzulegen.

## **Winkel von Verbinderdaten finden**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) Klasse.
1. Holen Sie sich die Referenz einer Folie über ihren Index.
1. Greifen Sie auf die Verbinderlinienform zu.
1. Verwenden Sie die Linienbreite, -höhe, -rahmhöhe und -rahmenbreite, um den Winkel zu berechnen.

Dieser C++-Code demonstriert einen Vorgang, bei dem wir den Winkel für eine Verbinderlinienform berechnet haben:

```c++
void ConnectorLineAngle()
{

	// Der Pfad zum Dokumentenverzeichnis.
	const String outPath = u"../out/ConnectorLineAngle_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Lädt die gewünschte Präsentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Greift auf die erste Folie zu
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	for (int i = 0; i < slide->get_Shapes()->get_Count(); i++)
	{
		double dir = 0.0;
		// Greift auf die Formen-Sammlung der Folien zu
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