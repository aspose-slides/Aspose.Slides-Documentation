---
title: Verbinder in Präsentationen mit C++ verwalten
linktitle: Verbinder
type: docs
weight: 10
url: /de/cpp/connector/
keywords:
- Verbinder
- Verbinder-Typ
- Verbinder-Punkt
- Verbinder-Linie
- Verbinder-Winkel
- Formen verbinden
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Ermöglichen Sie C++-Anwendungen, Linien in PowerPoint-Folien zu zeichnen, zu verbinden und automatisch zu routen – erhalten Sie die vollständige Kontrolle über gerade, Ellenbogen- und gekrümmte Verbinder."
---

Ein PowerPoint-Connector ist eine spezielle Linie, die zwei Formen miteinander verbindet oder verknüpft und an den Formen befestigt bleibt, selbst wenn sie auf einer Folie verschoben oder neu positioniert werden. 

Connectoren werden typischerweise mit *Verbindungspunkten* (grüne Punkte) verbunden, die standardmäßig auf allen Formen vorhanden sind. Verbindungspunkte erscheinen, wenn der Mauszeiger ihnen nahekommt.

*Anpassungspunkte* (orange Punkte), die nur bei bestimmten Connectoren existieren, werden verwendet, um die Positionen und Formen von Connectoren zu ändern.

## **Typen von Connectoren**

In PowerPoint können Sie gerade, Ellenbogen‑ (gekrügt) und gekrümmte Connectoren verwenden. 

Aspose.Slides stellt diese Connectoren bereit:

| Connector                      | Bild                                                         | Anzahl der Anpassungspunkte |
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

## **Formen mit Connectoren verbinden**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) .
2. Holen Sie sich eine Referenz auf eine Folie über ihren Index.
3. Fügen Sie der Folie zwei [AutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.auto_shape) mithilfe der vom `Shapes`‑Objekt bereitgestellten Methode `AddAutoShape` hinzu.
4. Fügen Sie einen Connector mithilfe der vom `Shapes`‑Objekt bereitgestellten Methode `AddConnector` hinzu, indem Sie den Connector‑Typ festlegen.
5. Verbinden Sie die Formen mit dem Connector.
6. Rufen Sie die Methode `Reroute` auf, um den kürzesten Verbindungsweg anzuwenden.
7. Speichern Sie die Präsentation. 

Dieser C++‑Code zeigt, wie Sie einen Connector (einen gebogenen Connector) zwischen zwei Formen (einer Ellipse und einem Rechteck) hinzufügen:
```c++
// Der Pfad zum Dokumentenverzeichnis.
	const String outPath = u"../out/ConnectShapesUsingConnectors_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Lädt die gewünschte Präsentation.
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Greift auf die erste Folie zu.
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Greift auf die Formen‑Sammlung einer bestimmten Folie zu.
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Fügt eine Ellipse‑Autoform hinzu.
	SharedPtr<IAutoShape> ellipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);

	// Fügt eine Rechteck‑Autoform hinzu.
	SharedPtr<IAutoShape> rect = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);

	// Fügt eine Connectorshape zur Folien‑Formensammlung hinzu.
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector2, 0, 0, 10, 10);

	// Verbindet die Formen mithilfe des Connectors.
	connector->set_StartShapeConnectedTo ( ellipse);
	connector->set_EndShapeConnectedTo (rect);

	// Ruft Reroute auf, das den automatischen kürzesten Pfad zwischen den Formen festlegt.
	connector->Reroute();
	
	// Speichert die Präsentation.
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


{{%  alert title="HINWEIS"  color="warning"   %}} 

`connector->Reroute`‑Methode leitet einen Connector neu und zwingt ihn, den kürzesten möglichen Pfad zwischen Formen zu nehmen. Um dies zu erreichen, kann die Methode die Punkte `StartShapeConnectionSiteIndex` und `EndShapeConnectionSiteIndex` ändern. 

{{% /alert %}} 

## **Einen Verbindungspunkt angeben**

Wenn Sie einen Connector verwenden möchten, um zwei Formen über bestimmte Punkte auf den Formen zu verknüpfen, müssen Sie die gewünschten Verbindungspunkte wie folgt angeben:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) .
2. Holen Sie sich eine Referenz auf eine Folie über ihren Index.
3. Fügen Sie der Folie zwei  [AutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.auto_shape) mithilfe der vom `Shapes`‑Objekt bereitgestellten Methode `AddAutoShape` hinzu.
4. Fügen Sie einen Connector mithilfe der vom `Shapes`‑Objekt bereitgestellten Methode `AddConnector` hinzu, indem Sie den Connector‑Typ festlegen.
5. Verbinden Sie die Formen mit dem Connector. 
6. Setzen Sie Ihre bevorzugten Verbindungspunkte auf den Formen. 
7. Speichern Sie die Präsentation.

Dieser C++‑Code demonstriert eine Operation, bei der ein bevorzugter Verbindungspunkt angegeben wird:
```c++
	// Der Pfad zum Dokumentenverzeichnis.
	const String outPath = u"../out/ConnectShapeUsingConnectionSite_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Lädt die gewünschte Präsentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Greift auf die erste Folie zu
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Greift auf die Formensammlung einer bestimmten Folie zu
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Fügt eine Ellipse-Autoform hinzu
	SharedPtr<IAutoShape> ellipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);

	// Fügt eine Rechteck-Autoform hinzu
	SharedPtr<IAutoShape> rect = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 200, 100, 100);

	// Fügt eine Connector-Form zur Formensammlung der Folie hinzu
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector3, 0, 0, 10, 10);

	// Verbindet die Formen mittels des Connectors
	connector->set_StartShapeConnectedTo(ellipse);
	connector->set_EndShapeConnectedTo(rect);


	// Setzt den bevorzugten Verbindungs-Punkt-Index auf der Ellipse-Form
	int wantedIndex = 6;

	// Prüft, ob der bevorzugte Index kleiner ist als die maximale Site-Index-Anzahl
	if (ellipse->get_ConnectionSiteCount() > wantedIndex)
	{
		// Setzt den bevorzugten Verbindungs-Punkt auf der Ellipse-Autoform
		connector->set_StartShapeConnectionSiteIndex ( wantedIndex);
	}

	// Speichert die Präsentation
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Einen Connector‑Punkt anpassen**

Sie können einen bestehenden Connector über seine Anpassungspunkte anpassen. Nur Connectoren mit Anpassungspunkten können auf diese Weise geändert werden. Siehe die Tabelle unter **[Typen von Connectoren.](/slides/de/cpp/connector/#types-of-connectors)** 

### **Einfacher Fall**

Betrachten Sie einen Fall, bei dem ein Connector zwischen zwei Formen (A und B) durch eine dritte Form (C) führt:

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


Um die dritte Form zu umgehen, können wir den Connector anpassen, indem wir seine vertikale Linie nach links verschieben:

![connector-obstruction-fixed](connector-obstruction-fixed.png)
```c++
auto adj2 = connector->get_Adjustments()->idx_get(1);
adj2->set_RawValue(adj2->get_RawValue() + 10000);
```


### **Komplexe Fälle** 

Um kompliziertere Anpassungen durchzuführen, müssen Sie folgende Punkte berücksichtigen:

* Ein anpassbarer Punkt eines Connectors ist stark mit einer Formel verknüpft, die seine Position berechnet und bestimmt. Daher können Änderungen der Punktposition die Form des Connectors verändern.
* Die Anpassungspunkte eines Connectors werden in einem Array in einer festen Reihenfolge definiert. Die Anpassungspunkte sind vom Start‑ bis zum Endpunkt des Connectors nummeriert.
* Die Werte der Anpassungspunkte geben den Prozentsatz der Breite/Höhe der Connector‑Form an. 
  * Die Form ist durch die Start‑ und Endpunkte des Connectors multipliziert mit 1000 begrenzt. 
  * Der erste Punkt, der zweite Punkt und der dritte Punkt definieren jeweils den Prozentsatz der Breite, den Prozentsatz der Höhe und erneut den Prozentsatz der Breite. 
* Bei Berechnungen, die die Koordinaten der Anpassungspunkte eines Connectors bestimmen, müssen Sie die Drehung des Connectors und seine Spiegelung berücksichtigen. **Hinweis**: Der Drehwinkel aller unter **[Typen von Connectors](/slides/de/cpp/connector/#types-of-connectors)** gezeigten Connectoren beträgt 0.

#### **Fall 1**

Betrachten Sie einen Fall, bei dem zwei Textfeld‑Objekte über einen Connector miteinander verknüpft sind:

![connector-shape-complex](connector-shape-complex.png)

Code:
```c++
// Instanziiert eine Präsentationsklasse, die eine PPTX-Datei darstellt
auto pres = System::MakeObject<Presentation>();
// Ruft die erste Folie in der Präsentation ab
auto slide = pres->get_Slides()->idx_get(0);
// Holt die Formen von der ersten Folie
auto shapes = slide->get_Shapes();
// Fügt Formen hinzu, die über einen Connector verbunden werden
auto shapeFrom = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 60.0f, 25.0f);
shapeFrom->get_TextFrame()->set_Text(u"From");
auto shapeTo = shapes->AddAutoShape(ShapeType::Rectangle, 500.0f, 100.0f, 60.0f, 25.0f);
shapeTo->get_TextFrame()->set_Text(u"To");
// Fügt einen Connector hinzu
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20.0f, 20.0f, 400.0f, 300.0f);
auto lineFormat = connector->get_LineFormat();
// Gibt die Richtung des Connectors an
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
// Gibt die Dicke der Connector-Linie an
lineFormat->set_Width(3);
// Gibt die Farbe des Connectors an
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(Aspose::Slides::FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Crimson());

// Verknüpft die Formen mit dem Connector
connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_StartShapeConnectionSiteIndex(3);
connector->set_EndShapeConnectedTo(shapeTo);
connector->set_EndShapeConnectionSiteIndex(2);

// Holt die Anpassungspunkte für den Connector
auto adjustments = connector->get_Adjustments();
auto adjValue_0 = adjustments->idx_get(0);
auto adjValue_1 = adjustments->idx_get(1);
```


**Anpassung**

Wir können die Werte der Anpassungspunkte des Connectors ändern, indem wir den entsprechenden Breiten‑ bzw. Höhen‑Prozentsatz um 20 % bzw. 200 % erhöhen:
```c++
// Ändert die Werte der Anpassungspunkte
adjValue_0->set_RawValue(adjValue_0->get_RawValue() + 20000);
adjValue_1->set_RawValue(adjValue_1->get_RawValue() + 200000);
```


Das Ergebnis:

![connector-adjusted-1](connector-adjusted-1.png)

Um ein Modell zu definieren, mit dem wir die Koordinaten und die Form einzelner Teile des Connectors bestimmen können, erstellen wir eine Form, die der horizontalen Komponente des Connectors am Punkt `connector.Adjustments[0]` entspricht:
```c++
 // Zeichnet die vertikale Komponente des Connectors
 float x = connector->get_X() + connector->get_Width() * adjValue_0->get_RawValue() / 100000;
 float y = connector->get_Y();
 float height = connector->get_Height() * adjValue_1->get_RawValue() / 100000;
 shapes->AddAutoShape(ShapeType::Rectangle, x, y, 0.0f, height);
```


Das Ergebnis:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Fall 2**

In **Fall 1** haben wir eine einfache Connector‑Anpassungs‑Operation anhand grundlegender Prinzipien demonstriert. In normalen Situationen müssen Sie die Drehung des Connectors und seine Darstellung (die durch `connector.Rotation`, `connector.Frame.FlipH` und `connector.Frame.FlipV` festgelegt werden) berücksichtigen. Im Folgenden zeigen wir den Vorgang.

Zuerst fügen wir der Folie ein neues Textfeld‑Objekt (**To 1**) (zur Verbindung) hinzu und erstellen einen neuen (grünen) Connector, der es mit den bereits erstellten Objekten verbindet.
```c++
// Erstellt ein neues Bindungsobjekt
auto shapeTo_1 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 400.0f, 60.0f, 25.0f);
shapeTo_1->get_TextFrame()->set_Text(u"To 1");
// Erstellt einen neuen Connector
connector = shapes->AddConnector(ShapeType::BentConnector4, 20.0f, 20.0f, 400.0f, 300.0f);
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
lineFormat->set_Width(3);
lineFillFormat->set_FillType(Aspose::Slides::FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_MediumAquamarine());
// Verbindet Objekte mit dem neu erstellten Connector
connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_StartShapeConnectionSiteIndex(2);
connector->set_EndShapeConnectedTo(shapeTo_1);
connector->set_EndShapeConnectionSiteIndex(3);
// Holt die Anpassungspunkte des Connectors
adjValue_0 = adjustments->idx_get(0);
adjValue_1 = adjustments->idx_get(1);
// Ändert die Werte der Anpassungspunkte
adjValue_0->set_RawValue(adjValue_0->get_RawValue() + 20000);
adjValue_1->set_RawValue(adjValue_1->get_RawValue() + 200000);
```


Das Ergebnis:

![connector-adjusted-3](connector-adjusted-3.png)

Zweitens erstellen wir eine Form, die der horizontalen Komponente des Connectors entspricht, die durch den neuen Anpassungspunkt `connector.Adjustments[0]` verläuft. Wir verwenden die Werte aus den Connector‑Daten für `connector.Rotation`, `connector.Frame.FlipH` und `connector.Frame.FlipV` und wenden die gängige Koordinaten‑Umrechnungsformel für die Drehung um einen Punkt x0 an:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

In unserem Fall beträgt der Rotationswinkel des Objekts 90 Grad und der Connector wird vertikal angezeigt, sodass der entsprechende Code lautet:
```c++

```


Das Ergebnis:

![connector-adjusted-4](connector-adjusted-4.png)

Wir haben Berechnungen für einfache und komplexe Anpassungspunkte (mit Drehwinkeln) demonstriert. Mit dem erworbenen Wissen können Sie Ihr eigenes Modell entwickeln (oder Code schreiben), um ein `GraphicsPath`‑Objekt zu erhalten oder sogar die Werte der Anpassungspunkte eines Connectors anhand spezifischer Folien‑Koordinaten zu setzen.

## **Winkel von Connector‑Linien ermitteln**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) .
2. Holen Sie sich eine Referenz auf eine Folie über ihren Index.
3. Greifen Sie auf die Connector‑Linien‑Form zu.
4. Verwenden Sie die Linienbreite, Höhe, Formrahmen‑Höhe und Formrahmen‑Breite, um den Winkel zu berechnen.

Dieser C++‑Code demonstriert eine Operation, bei der wir den Winkel für eine Connector‑Linien‑Form berechnet haben:
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
		// Greift auf die Formensammlung der Folien zu
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

**Wie kann ich feststellen, ob ein Connector an einer bestimmten Form "geklebt" werden kann?**

Prüfen Sie, ob die Form [Verbindungspunkte](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_connectionsitecount/) bereitstellt. Wenn keine vorhanden sind oder die Anzahl Null beträgt, ist das Kleben nicht möglich; verwenden Sie in diesem Fall freie Endpunkte und positionieren Sie sie manuell. Es ist sinnvoll, die Anzahl der Punkte vor dem Anfügen zu prüfen.

**Was passiert mit einem Connector, wenn ich eine der verbundenen Formen lösche?**

Seine Enden werden getrennt; der Connector bleibt als gewöhnliche Linie mit freien Start‑/Endpunkten auf der Folie. Sie können ihn entweder löschen oder die Verbindungen neu zuweisen und bei Bedarf [rerouten](https://reference.aspose.com/slides/cpp/aspose.slides/connector/reroute/).

**Werden Connector‑Verbindungen beim Kopieren einer Folie in eine andere Präsentation erhalten?**

In der Regel ja, vorausgesetzt, die Ziel‑Formen werden ebenfalls kopiert. Wird die Folie in eine andere Datei eingefügt, ohne die verbundenen Formen, werden die Enden frei und Sie müssen sie erneut anhängen.