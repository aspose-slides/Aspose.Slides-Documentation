---
title: Verwalten von Präsentationsformen in .NET
linktitle: Formmanipulation
type: docs
weight: 40
url: /de/net/shape-manipulations/
keywords:
- PowerPoint-Form
- Präsentationsform
- Form auf Folie
- Form finden
- Form duplizieren
- Form entfernen
- Form ausblenden
- Reihenfolge von Formen ändern
- Interop-Shape-ID abrufen
- Alternative Text für Form
- Layoutformate für Formen
- Form als SVG
- Form in SVG
- Form ausrichten
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Formen in Aspose.Slides für .NET erstellen, bearbeiten und optimieren und leistungsstarke PowerPoint‑Präsentationen bereitstellen."
---

## **Eine Form auf einer Folie finden**
Dieses Thema beschreibt eine einfache Methode, die es Entwicklern erleichtert, eine bestimmte Form auf einer Folie zu finden, ohne deren interne Id zu verwenden. Es ist wichtig zu wissen, dass PowerPoint‑Präsentationsdateien keine Möglichkeit bieten, Formen auf einer Folie zu identifizieren, außer über eine interne eindeutige Id. Es ist für Entwickler häufig schwierig, eine Form anhand ihrer internen eindeutigen Id zu finden. Alle zur Folie hinzugefügten Formen besitzen einen Alt‑Text. Wir empfehlen Entwicklern, den Alternativtext zu verwenden, um eine bestimmte Form zu finden. Sie können MS PowerPoint nutzen, um den Alternativtext für Objekte festzulegen, die Sie zukünftig ändern möchten.

Nachdem Sie den Alternativtext einer gewünschten Form festgelegt haben, können Sie die Präsentation mit Aspose.Slides for .NET öffnen und durch alle zu einer Folie hinzugefügten Formen iterieren. Bei jeder Iteration können Sie den Alternativtext der Form prüfen, und die Form mit dem passenden Alternativtext ist die gesuchte Form. Um diese Technik besser zu demonstrieren, haben wir eine Methode, [FindShape](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/findshape/#findshape_1) erstellt, die das Auffinden einer bestimmten Form auf einer Folie übernimmt und anschließend die Form zurückgibt.
```c#
public static void Run()
{
    // Instanziieren einer Presentation-Klasse, die die Präsentationsdatei darstellt
    using (Presentation p = new Presentation("FindingShapeInSlide.pptx"))
    {

        ISlide slide = p.Slides[0];
        // Alternativtext der zu findenden Form
        IShape shape = FindShape(slide, "Shape1");
        if (shape != null)
        {
            Console.WriteLine("Shape Name: " + shape.Name);
        }
    }
}
        
// Methodenimplementierung zum Finden einer Form in einer Folie über deren Alternativtext
public static IShape FindShape(ISlide slide, string alttext)
{
    // Durchlaufen aller Formen innerhalb der Folie
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        // Wenn der Alternativtext der Folie mit dem gesuchten übereinstimmt dann
        // Form zurückgeben
        if (slide.Shapes[i].AlternativeText.CompareTo(alttext) == 0)
            return slide.Shapes[i];
    }
    return null;
}
```


## **Eine Form duplizieren**
Um eine Form auf einer Folie mit Aspose.Slides for .NET zu duplizieren:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)‑Klasse.
1. Holen Sie die Referenz einer Folie anhand ihres Index.
1. Greifen Sie auf die Formsammlung der Quellfolie zu.
1. Fügen Sie der Präsentation eine neue Folie hinzu.
1. Duplizieren Sie Formen aus der Formsammlung der Quellfolie in die neue Folie.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Das nachstehende Beispiel fügt einer Folie eine Gruppierungsform hinzu.
```c#
// Instanziieren der Presentation-Klasse
using (Presentation srcPres = new Presentation("Source Frame.pptx"))
{
	IShapeCollection sourceShapes = srcPres.Slides[0].Shapes;
	ILayoutSlide blankLayout = srcPres.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
	ISlide destSlide = srcPres.Slides.AddEmptySlide(blankLayout);
	IShapeCollection destShapes = destSlide.Shapes;
	destShapes.AddClone(sourceShapes[1], 50, 150 + sourceShapes[0].Height);
	destShapes.AddClone(sourceShapes[2]);                 
	destShapes.InsertClone(0, sourceShapes[0], 50, 150);

	// Schreiben der PPTX-Datei auf die Festplatte
	srcPres.Save("CloneShape_out.pptx", SaveFormat.Pptx);
}
```


## **Eine Form entfernen**
Aspose.Slides for .NET ermöglicht Entwicklern das Entfernen beliebiger Formen. Um eine Form von einer Folie zu entfernen, führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der `Presentation`‑Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Suchen Sie die Form mit dem entsprechenden AlternativeText.
1. Entfernen Sie die Form.
1. Speichern Sie die Datei auf dem Datenträger.
```c#
// Presentation-Objekt erstellen
Presentation pres = new Presentation();

// Erste Folie abrufen
ISlide sld = pres.Slides[0];

// Autoform vom Typ Rechteck hinzufügen
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
String alttext = "User Defined";
int iCount = sld.Shapes.Count;
for (int i = 0; i < iCount; i++)
{
    AutoShape ashp = (AutoShape)sld.Shapes[0];
    if (String.Compare(ashp.AlternativeText, alttext, StringComparison.Ordinal) == 0)
    {
        sld.Shapes.Remove(ashp);
    }
}

// Präsentation auf Festplatte speichern
pres.Save("RemoveShape_out.pptx", SaveFormat.Pptx);
```


## **Eine Form ausblenden**
Aspose.Slides for .NET ermöglicht Entwicklern das Ausblenden beliebiger Formen. Um die Form von einer Folie auszublenden, führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der `Presentation`‑Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Suchen Sie die Form mit dem entsprechenden AlternativeText.
1. Blenden Sie die Form aus.
1. Speichern Sie die Datei auf dem Datenträger.
```c#
// Präsentationsklasse instanziieren, die die PPTX darstellt
Presentation pres = new Presentation();

// Erste Folie abrufen
ISlide sld = pres.Slides[0];

// Autoform vom Typ Rechteck hinzufügen
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
String alttext = "User Defined";
int iCount = sld.Shapes.Count;
for (int i = 0; i < iCount; i++)
{
	AutoShape ashp = (AutoShape)sld.Shapes[i];
	if (String.Compare(ashp.AlternativeText, alttext, StringComparison.Ordinal) == 0)
	{
		ashp.Hidden = true;
	}
}

// Präsentation auf Festplatte speichern
pres.Save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
```


## **Reihenfolge von Formen ändern**
Aspose.Slides for .NET ermöglicht Entwicklern das Neuordnen von Formen. Durch das Neuordnen wird festgelegt, welche Form im Vordergrund und welche im Hintergrund liegt. Um die Reihenfolge von Formen auf einer Folie zu ändern, führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der `Presentation`‑Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie eine Form hinzu.
1. Fügen Sie im Textfeld der Form einen Text hinzu.
1. Fügen Sie eine weitere Form mit denselben Koordinaten hinzu.
1. Ordnen Sie die Formen neu.
1. Speichern Sie die Datei auf dem Datenträger.
```c#
Presentation presentation1 = new Presentation("HelloWorld.pptx");
ISlide slide = presentation1.Slides[0];
IAutoShape shp3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 365, 400, 150);
shp3.FillFormat.FillType = FillType.NoFill;
shp3.AddTextFrame(" ");

ITextFrame txtFrame = shp3.TextFrame;
IParagraph para = txtFrame.Paragraphs[0];
IPortion portion = para.Portions[0];
portion.Text="Watermark Text Watermark Text Watermark Text";
shp3 = slide.Shapes.AddAutoShape(ShapeType.Triangle, 200, 365, 400, 150);
slide.Shapes.Reorder(2, shp3);
presentation1.Save( "Reshape_out.pptx", SaveFormat.Pptx);
```


## **Interop‑Shape‑ID abrufen**
Aspose.Slides for .NET ermöglicht Entwicklern das Abrufen einer eindeutigen Shape‑Kennung im Folien‑Umfang im Gegensatz zur UniqueId‑Eigenschaft, die eine eindeutige Kennung im Präsentations‑Umfang liefert. Die Property OfficeInteropShapeId wurde den IShape‑Schnittstellen und der Shape‑Klasse hinzugefügt. Der von der OfficeInteropShapeId‑Property zurückgegebene Wert entspricht der Id des Microsoft.Office.Interop.PowerPoint.Shape‑Objekts. Unten ist ein Beispielcode angegeben.
```c#
public static void Run()
{
	using (Presentation presentation = new Presentation("Presentation.pptx"))
	{
		// Einzigartige Shape-Kennung im Folienumfang ermitteln
		long officeInteropShapeId = presentation.Slides[0].Shapes[0].OfficeInteropShapeId;
	}
}
```


## **Alternativtext für eine Form festlegen**
Aspose.Slides for .NET ermöglicht Entwicklern das Festlegen von AlternateText für beliebige Formen.

Formen in einer Präsentation können anhand des AlternativeText‑ oder Shape‑Name‑Eigenschaft unterschieden werden.

Die AlternativeText‑Eigenschaft kann sowohl mit Aspose.Slides als auch mit Microsoft PowerPoint gelesen oder gesetzt werden.

Durch die Verwendung dieser Eigenschaft können Sie eine Form kennzeichnen und verschiedene Vorgänge wie das Entfernen einer Form, das Ausblenden einer Form oder das Neuordnen von Formen auf einer Folie durchführen.

Um den AlternateText einer Form festzulegen, führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der `Presentation`‑Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie eine beliebige Form zur Folie hinzu.
1. Arbeiten Sie mit der neu hinzugefügten Form.
1. Durchlaufen Sie die Formen, um eine bestimmte Form zu finden.
1. Setzen Sie den AlternativeText.
1. Speichern Sie die Datei auf dem Datenträger.
```c#
// Presentation-Klasse instanziieren, die die PPTX darstellt
Presentation pres = new Presentation();

// Erste Folie abrufen
ISlide sld = pres.Slides[0];

// Autoform vom Typ Rechteck hinzufügen
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
shp2.FillFormat.FillType = FillType.Solid;
shp2.FillFormat.SolidFillColor.Color = Color.Gray;

for (int i = 0; i < sld.Shapes.Count; i++)
{
    var shape = sld.Shapes[i] as AutoShape;
    if (shape != null)
    {
        AutoShape ashp = shape;
        ashp.AlternativeText = "User Defined";
    }
}

// Präsentation auf Festplatte speichern
pres.Save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
```


## **Layout‑Formate für eine Form abrufen**
Aspose.Slides for .NET bietet eine einfache API zum Abrufen von Layout‑Formaten für eine Form. Dieser Artikel zeigt, wie Sie Layout‑Formate zugreifen können.

Unten ist ein Beispielcode angegeben.
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
	foreach (ILayoutSlide layoutSlide in pres.LayoutSlides)
	{
		IFillFormat[] fillFormats = layoutSlide.Shapes.Select(shape => shape.FillFormat).ToArray();
		ILineFormat[] lineFormats = layoutSlide.Shapes.Select(shape => shape.LineFormat).ToArray();
	}
}
```


## **Eine Form als SVG rendern**
Jetzt unterstützt Aspose.Slides for .NET das Rendern einer Form als SVG. Die Methode WriteAsSvg (und ihre Überladung) wurde der Shape‑Klasse und dem IShape‑Interface hinzugefügt. Diese Methode ermöglicht das Speichern des Inhalts einer Form als SVG‑Datei. Das nachstehende Code‑Snippet zeigt, wie man die Form einer Folie in eine SVG‑Datei exportiert.
```c#
public static void Run()
{
	string outSvgFileName = "SingleShape.svg";
	using (Presentation pres = new Presentation("TestExportShapeToSvg.pptx"))
	{
		using (Stream stream = new FileStream(outSvgFileName, FileMode.Create, FileAccess.Write))
		{
			pres.Slides[0].Shapes[0].WriteAsSvg(stream);
		}
	}
}
```


## **Eine Form ausrichten**
Über die überladene Methode [SlidesUtil.AlignShape()](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/methods/alignshapes/index) können Sie

* Formen relativ zu den Folienrändern ausrichten. Siehe Beispiel 1.
* Formen relativ zueinander ausrichten. Siehe Beispiel 2.

Die Aufzählung [ShapesAlignmentType](https://reference.aspose.com/slides/net/aspose.slides/shapesalignmenttype) definiert die verfügbaren Ausrichtungsoptionen.

**Beispiel 1**

Dieser C#‑Code zeigt, wie man Formen mit den Indizes 1, 2 und 4 entlang des oberen Randes einer Folie ausrichtet:
Der nachstehende Quellcode richtet die Formen mit den Indizes 1, 2 und 4 am oberen Rand der Folie aus.
``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
     ISlide slide = pres.Slides[0];
     IShape shape1 = slide.Shapes[1];
     IShape shape2 = slide.Shapes[2];
     IShape shape3 = slide.Shapes[4];
     SlideUtil.AlignShapes(ShapesAlignmentType.AlignTop, true, pres.Slides[0], new int[]
     {
          slide.Shapes.IndexOf(shape1),
          slide.Shapes.IndexOf(shape2),
          slide.Shapes.IndexOf(shape3)
     });
}
```


**Beispiel 2**

Dieser C#‑Code zeigt, wie man eine gesamte Formsammlung relativ zur untersten Form in der Sammlung ausrichtet:
``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
    SlideUtil.AlignShapes(ShapesAlignmentType.AlignBottom, false, pres.Slides[0].Shapes);
}
```


## **Spiegelungs‑Eigenschaften**
In Aspose.Slides bietet die Klasse [ShapeFrame](https://reference.aspose.com/slides/net/aspose.slides.shapeframe/) Kontrolle über die horizontale und vertikale Spiegelung von Formen über die Eigenschaften `FlipH` und `FlipV`. Beide Eigenschaften haben den Typ [NullableBool](https://reference.aspose.com/slides/net/aspose.slides.nullablebool/), wobei `True` eine Spiegelung, `False` keine Spiegelung und `NotDefined` das Standardverhalten bedeutet. Diese Werte sind über das [Frame](https://reference.aspose.com/slides/net/aspose.slides.ishape/frame/) einer Form zugänglich.

Um die Spiegelungseinstellungen zu ändern, wird eine neue [ShapeFrame](https://reference.aspose.com/slides/net/aspose.slides.shapeframe/)‑Instanz mit der aktuellen Position und Größe der Form sowie den gewünschten `FlipH`‑ und `FlipV`‑Werten und dem Rotationswinkel erstellt. Durch Zuweisung dieser Instanz zum [Frame](https://reference.aspose.com/slides/net/aspose.slides.ishape/frame/) der Form und dem anschließenden Speichern der Präsentation werden die Spiegelungs‑Transformationen angewendet und in die Ausgabedatei übernommen.

Angenommen, wir haben eine Datei sample.pptx, in der die erste Folie eine einzelne Form mit den Standard‑Spiegelungseinstellungen enthält, wie unten gezeigt.

![The shape to be flipped](shape_to_be_flipped.png)

Das folgende Code‑Beispiel ermittelt die aktuellen Spiegelungseigenschaften der Form und spiegelt sie sowohl horizontal als auch vertikal.
```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];

    // Die horizontale Spiegelungseigenschaft der Form abrufen.
    NullableBool horizontalFlip = shape.Frame.FlipH;
    Console.WriteLine($"Horizontal flip: {horizontalFlip}");

    // Die vertikale Spiegelungseigenschaft der Form abrufen.
    NullableBool verticalFlip = shape.Frame.FlipV;
    Console.WriteLine($"Vertical flip: {verticalFlip}");

    float x = shape.Frame.X;
    float y = shape.Frame.Y;
    float width = shape.Frame.Width;
    float height = shape.Frame.Height;
    NullableBool flipH = NullableBool.True; // Horizontal spiegeln.
    NullableBool flipV = NullableBool.True; // Vertikal spiegeln.
    float rotation = shape.Frame.Rotation;

    shape.Frame = new ShapeFrame(x, y, width, height, flipH, flipV, rotation);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Kann ich Formen (Vereinigung/Überschneidung/Subtraktion) auf einer Folie wie in einem Desktop‑Editor kombinieren?**

Es gibt keine integrierte API für Boolesche Operationen. Sie können dies annähern, indem Sie die gewünschte Kontur selbst erstellen – z. B. die resultierende Geometrie über [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides.geometrypath/) berechnen und eine neue Form mit dieser Kontur erzeugen, optional die Originalformen entfernen.

**Wie kann ich die Stapelreihenfolge (Z‑Order) steuern, sodass eine Form immer "oben" bleibt?**

Ändern Sie die Einfüge‑/Verschiebe‑Reihenfolge innerhalb der [shapes](https://reference.aspose.com/slides/net/aspose.slides.baseslide/shapes/)‑Sammlung der Folie. Für vorhersehbare Ergebnisse sollten Sie den Z‑Order nach allen anderen Folienänderungen abschließen.

**Kann ich eine Form "sperren", um zu verhindern, dass Benutzer sie in PowerPoint bearbeiten?**

Ja. Setzen Sie die [shape-level protection flags](/slides/de/net/applying-protection-to-presentation/) (z. B. Auswahl, Verschiebung, Größenänderung, Textbearbeitung sperren). Bei Bedarf können Sie die Einschränkungen auf dem Master‑ oder Layout‑Folientyp spiegeln. Beachten Sie, dass dies ein UI‑basierter Schutz ist und keine Sicherheitsfunktion darstellt; für stärkeren Schutz kombinieren Sie ihn mit dateibasierten Einschränkungen wie [Empfehlungen für schreibgeschützten Zugriff oder Passwörter](/slides/de/net/password-protected-presentation/).