---
title: Formmanipulationen
type: docs
weight: 40
url: /de/net/shape-manipulations/
keywords: "PowerPoint-Form, Form auf Folie, Form finden, Form klonen, Form entfernen, Form ausblenden, Formreihenfolge ändern, Interop Shape-ID abrufen, Form-Alternativtext, Form-Layoutformate, Form als SVG, Form ausrichten, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "PowerPoint-Formen in C# oder .NET manipulieren"
---

## **Shape in Folie finden**
Dieser Abschnitt beschreibt eine einfache Technik, um Entwicklern das Auffinden einer bestimmten Form auf einer Folie zu erleichtern, ohne deren interne Id zu verwenden. Es ist wichtig zu wissen, dass PowerPoint-Präsentationsdateien keine Möglichkeit bieten, Formen auf einer Folie zu identifizieren, außer über eine interne eindeutige Id. Es ist für Entwickler oft schwierig, eine Form über ihre interne eindeutige Id zu finden. Allen Formen, die zu den Folien hinzugefügt werden, ist ein Alternativtext zugeordnet. Wir empfehlen Entwicklern, den Alternativtext zum Auffinden einer bestimmten Form zu verwenden. Sie können MS PowerPoint nutzen, um den Alternativtext für Objekte festzulegen, die Sie in Zukunft ändern möchten.

Nachdem Sie den Alternativtext einer gewünschten Form festgelegt haben, können Sie die Präsentation mit Aspose.Slides für .NET öffnen und durch alle zu einer Folie hinzugefügten Formen iterieren. Bei jeder Iteration können Sie den Alternativtext der Form prüfen; die Form mit dem passenden Alternativtext ist die von Ihnen gesuchte Form. Um diese Technik anschaulicher zu demonstrieren, haben wir eine Methode, [FindShape](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/findshape/#findshape_1) erstellt, die das Auffinden einer bestimmten Form in einer Folie übernimmt und dann einfach diese Form zurückgibt.
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
        
// Methodenimplementierung zum Finden einer Form in einer Folie anhand ihres Alternativtexts
public static IShape FindShape(ISlide slide, string alttext)
{
    // Durchlaufen aller Formen in der Folie
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        // Wenn der Alternativtext der Folie mit dem gesuchten übereinstimmt, dann
        // Rückgabe der Form
        if (slide.Shapes[i].AlternativeText.CompareTo(alttext) == 0)
            return slide.Shapes[i];
    }
    return null;
}
```




## **Shape klonen**
Um eine Form zu einer Folie mit Aspose.Slides für .NET zu klonen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
2. Rufen Sie die Referenz einer Folie über deren Index ab.
3. Greifen Sie auf die Shape‑Sammlung der Quellfolie zu.
4. Fügen Sie der Präsentation eine neue Folie hinzu.
5. Klonen Sie Formen aus der Shape‑Sammlung der Quellfolie in die neue Folie.
6. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Das Beispiel unten fügt einer Folie eine Gruppierung von Formen hinzu.
```c#
 // Presentation-Klasse instanziieren
using (Presentation srcPres = new Presentation("Source Frame.pptx"))
{
	IShapeCollection sourceShapes = srcPres.Slides[0].Shapes;
	ILayoutSlide blankLayout = srcPres.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
	ISlide destSlide = srcPres.Slides.AddEmptySlide(blankLayout);
	IShapeCollection destShapes = destSlide.Shapes;
	destShapes.AddClone(sourceShapes[1], 50, 150 + sourceShapes[0].Height);
	destShapes.AddClone(sourceShapes[2]);                 
	destShapes.InsertClone(0, sourceShapes[0], 50, 150);

	// PPTX-Datei auf die Festplatte schreiben
	srcPres.Save("CloneShape_out.pptx", SaveFormat.Pptx);
}
```




## **Shape entfernen**
Aspose.Slides für .NET ermöglicht es Entwicklern, jede Form zu entfernen. So entfernen Sie eine Form von einer beliebigen Folie:

1. Erstellen Sie eine Instanz der `Presentation`‑Klasse.
2. Greifen Sie auf die erste Folie zu.
3. Suchen Sie die Form mit dem gewünschten AlternativeText.
4. Entfernen Sie die Form.
5. Speichern Sie die Datei auf dem Datenträger.
```c#
// Presentation-Objekt erstellen
Presentation pres = new Presentation();

// Erste Folie abrufen
ISlide sld = pres.Slides[0];

// AutoShape vom Typ Rechteck hinzufügen
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




## **Shape ausblenden**
Aspose.Slides für .NET ermöglicht es Entwicklern, jede Form auszublenden. So blenden Sie eine Form auf einer Folie aus:

1. Erstellen Sie eine Instanz der `Presentation`‑Klasse.
2. Greifen Sie auf die erste Folie zu.
3. Suchen Sie die Form mit dem gewünschten AlternativeText.
4. Blenden Sie die Form aus.
5. Speichern Sie die Datei auf dem Datenträger.
```c#
// Präsentationsklasse instanziieren, die die PPTX darstellt
Presentation pres = new Presentation();

// Erste Folie abrufen
ISlide sld = pres.Slides[0];

// AutoShape vom Typ Rechteck hinzufügen
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




## **Reihenfolge von Shapes ändern**
Aspose.Slides für .NET ermöglicht es Entwicklern, die Reihenfolge von Shapes zu ändern. Durch das Neuanordnen wird festgelegt, welche Form im Vordergrund bzw. im Hintergrund liegt. So ändern Sie die Reihenfolge einer Form auf einer Folie:

1. Erstellen Sie eine Instanz der `Presentation`‑Klasse.
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie eine Form hinzu.
4. Fügen Sie Text in den Text‑Frame der Form ein.
5. Fügen Sie eine weitere Form mit denselben Koordinaten hinzu.
6. Ordnen Sie die Formen neu an.
7. Speichern Sie die Datei auf dem Datenträger.
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



## **Interop Shape ID abrufen**
Aspose.Slides für .NET ermöglicht es Entwicklern, eine eindeutige Shape‑Kennung im Folien‑Umfang abzurufen, im Gegensatz zur UniqueId‑Eigenschaft, die eine eindeutige Kennung im Präsentations‑Umfang liefert. Die Eigenschaft OfficeInteropShapeId wurde zu den IShape‑Schnittstellen und der Shape‑Klasse hinzugefügt. Der von OfficeInteropShapeId zurückgegebene Wert entspricht dem Id‑Wert des Microsoft.Office.Interop.PowerPoint.Shape‑Objekts. Im Folgenden finden Sie einen Beispielcode.
```c#
public static void Run()
{
	using (Presentation presentation = new Presentation("Presentation.pptx"))
	{
		// Abrufen der eindeutigen Shape-Kennung im Folienbereich
		long officeInteropShapeId = presentation.Slides[0].Shapes[0].OfficeInteropShapeId;
	}
}
```




## **Alternative Text für Shape festlegen**
Aspose.Slides für .NET ermöglicht es Entwicklern, das AlternateText einer beliebigen Form zu setzen. 
Formen in einer Präsentation können über das Property AlternativeText oder den Shape‑Namen unterschieden werden. 
Das Property AlternativeText kann sowohl mit Aspose.Slides als auch mit Microsoft PowerPoint gelesen oder gesetzt werden. 
Durch dieses Property können Sie eine Form kennzeichnen und verschiedene Vorgänge ausführen, wie das Entfernen einer Form, das Ausblenden einer Form oder das Neuanordnen von Formen auf einer Folie.
So setzen Sie das AlternateText einer Form:

1. Erstellen Sie eine Instanz der `Presentation`‑Klasse.
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie der Folie eine beliebige Form hinzu.
4. Arbeiten Sie mit der neu hinzugefügten Form.
5. Durchlaufen Sie die Formen, um die gesuchte Form zu finden.
6. Setzen Sie das AlternativeText.
7. Speichern Sie die Datei auf dem Datenträger.
```c#
// Instanziieren der Presentation-Klasse, die die PPTX repräsentiert
Presentation pres = new Presentation();

// Erste Folie abrufen
ISlide sld = pres.Slides[0];

// AutoShape vom Typ Rechteck hinzufügen
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





## **Layoutformate für Shape abrufen**
Aspose.Slides für .NET bietet eine einfache API zum Zugriff auf Layoutformate einer Form. Dieser Artikel zeigt, wie Sie Layoutformate abrufen können.

Untenstehend finden Sie Beispielcode.
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


## **Shape als SVG rendern**
Jetzt unterstützt Aspose.Slides für .NET das Rendern einer Form als SVG. Die Methode WriteAsSvg (und ihre Überladung) wurde zur Shape‑Klasse und zur IShape‑Schnittstelle hinzugefügt. Diese Methode ermöglicht das Speichern des Inhalts einer Form als SVG‑Datei. Der nachfolgende Code‑Auszug zeigt, wie Sie die Form einer Folie in eine SVG‑Datei exportieren.
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


## **Shape ausrichten**

Über die überladene Methode [SlidesUtil.AlignShape()](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/methods/alignshapes/index) können Sie

* Shapes relativ zu den Rändern einer Folie ausrichten. Siehe Beispiel 1.
* Shapes relativ zueinander ausrichten. Siehe Beispiel 2.

Der Enumerations‑Typ [ShapesAlignmentType](https://reference.aspose.com/slides/net/aspose.slides/shapesalignmenttype) definiert die verfügbaren Ausrichtungsoptionen.

**Beispiel 1**

Dieser C#‑Code zeigt, wie Sie die Shapes mit den Indizes 1, 2 und 4 entlang der oberen Folienkante ausrichten:
Der Quellcode unten richtet die Shapes mit den Indizes 1, 2 und 4 am oberen Rand der Folie aus. 
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

Dieser C#‑Code zeigt, wie Sie eine gesamte Sammlung von Shapes relativ zur untersten Shape in der Sammlung ausrichten:
``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
    SlideUtil.AlignShapes(ShapesAlignmentType.AlignBottom, false, pres.Slides[0].Shapes);
}
```


## **Flip‑Eigenschaften**

In Aspose.Slides stellt die Klasse [ShapeFrame](https://reference.aspose.com/slides/net/aspose.slides/shapeframe/) die Kontrolle über horizontales und vertikales Spiegeln von Shapes über die Eigenschaften `FlipH` und `FlipV` bereit. Beide Eigenschaften sind vom Typ [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) und können den Wert `True` für ein Spiegeln, `False` für kein Spiegeln oder `NotDefined` für das Standardverhalten annehmen. Diese Werte sind über den [Frame](https://reference.aspose.com/slides/net/aspose.slides/ishape/frame/) einer Form zugänglich.

Um die Flip‑Einstellungen zu ändern, wird eine neue [ShapeFrame](https://reference.aspose.com/slides/net/aspose.slides/shapeframe/)‑Instanz mit der aktuellen Position und Größe der Form, den gewünschten Werten für `FlipH` und `FlipV` sowie dem Drehwinkel erstellt. Durch Zuweisung dieser Instanz zum [Frame](https://reference.aspose.com/slides/net/aspose.slides/ishape/frame/) der Form und anschließendem Speichern der Präsentation werden die Spiegel‑Transformationen angewendet und in die Ausgabedatei übernommen.

Angenommen, wir haben eine Datei sample.pptx, in der die erste Folie eine einzige Form mit den Standard‑Flip‑Einstellungen enthält, wie unten gezeigt.

![The shape to be flipped](shape_to_be_flipped.png)

Der folgende Beispielcode liest die aktuellen Flip‑Eigenschaften der Form aus und spiegelt sie sowohl horizontal als auch vertikal.
```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];

    // Den horizontalen Flip-Eigenschaft der Form abrufen.
    NullableBool horizontalFlip = shape.Frame.FlipH;
    Console.WriteLine($"Horizontal flip: {horizontalFlip}");

    // Den vertikalen Flip-Eigenschaft der Form abrufen.
    NullableBool verticalFlip = shape.Frame.FlipV;
    Console.WriteLine($"Vertical flip: {verticalFlip}");

    float x = shape.Frame.X;
    float y = shape.Frame.Y;
    float width = shape.Frame.Width;
    float height = shape.Frame.Height;
    NullableBool flipH = NullableBool.True; // Horizontal flippen.
    NullableBool flipV = NullableBool.True; // Vertikal flippen.
    float rotation = shape.Frame.Rotation;

    shape.Frame = new ShapeFrame(x, y, width, height, flipH, flipV, rotation);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


Das Ergebnis:

![The flipped shape](flipped_shape.png)

## **FAQ**

**Kann ich Shapes (Vereinigung/Schnitt/Unterschied) auf einer Folie kombinieren wie in einem Desktop‑Editor?**

Es gibt keine integrierte Boolean‑Operations‑API. Sie können dies annähern, indem Sie die gewünschte Kontur selbst erzeugen – z. B. die resultierende Geometrie über [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) berechnen und eine neue Form mit dieser Kontur erstellen, optional die Originale entfernen.

**Wie kann ich die Stapelreihenfolge (z‑Order) steuern, sodass eine Form immer „oben“ bleibt?**

Ändern Sie die Einfüge‑/Verschiebe‑Reihenfolge innerhalb der [shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/)‑Sammlung der Folie. Für vorhersehbare Ergebnisse sollten Sie die z‑Order nach allen anderen Folienänderungen finalisieren.

**Kann ich eine Form „sperren“, um zu verhindern, dass Benutzer sie in PowerPoint bearbeiten?**

Ja. Setzen Sie [shape‑level protection flags](/slides/de/net/applying-protection-to-presentation/) (z. B. Auswahl, Bewegung, Größenänderung, Textbearbeitung sperren). Bei Bedarf können Sie die Einschränkungen auf dem Master oder Layout spiegeln. Beachten Sie, dass dies ein UI‑Schutz ist und keine Sicherheitsfunktion; für stärkeren Schutz kombinieren Sie ihn mit Dateischutz‑Optionen wie [empfohlenen schreibgeschützten Dateien oder Passwörtern](/slides/de/net/password-protected-presentation/).