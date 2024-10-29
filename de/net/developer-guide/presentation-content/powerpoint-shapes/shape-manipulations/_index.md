---
title: Formenmanipulationen
type: docs
weight: 40
url: /de/net/shape-manipulations/
keywords: "PowerPoint-Form, Form auf Folie, Form finden, Form klonen, Form entfernen, Form ausblenden, Formreihenfolge ändern, Interop-Form-ID abrufen, alternative Formtexte, Layoutformate für Formen, Form als SVG, Form ausrichten, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Manipulieren Sie PowerPoint-Formen in C# oder .NET"
---

## **Form in Folie finden**
Dieses Thema beschreibt eine einfache Technik, um es Entwicklern zu erleichtern, eine bestimmte Form auf einer Folie zu finden, ohne deren interne ID zu verwenden. Es ist wichtig zu wissen, dass PowerPoint-Präsentationsdateien keine Möglichkeit haben, Formen auf einer Folie zu identifizieren, außer durch eine interne eindeutige ID. Es scheint für Entwickler schwierig zu sein, eine Form anhand ihrer internen eindeutigen ID zu finden. Alle Formen, die zu den Folien hinzugefügt werden, haben einen alternativen Text. Wir schlagen Entwicklern vor, alternativen Text zu verwenden, um eine bestimmte Form zu finden. Sie können MS PowerPoint verwenden, um den alternativen Text für Objekte festzulegen, die Sie in der Zukunft ändern möchten.

Nachdem Sie den alternativen Text einer gewünschten Form festgelegt haben, können Sie diese Präsentation mit Aspose.Slides für .NET öffnen und alle Formen durchlaufen, die einer Folie hinzugefügt wurden. Bei jeder Iteration können Sie den alternativen Text der Form überprüfen, und die Form mit dem übereinstimmenden alternativen Text wäre die von Ihnen benötigte Form. Um diese Technik besser zu demonstrieren, haben wir eine Methode, [FindShape](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/findshape/#findshape_1) erstellt, die den Trick durchführen kann, um eine spezifische Form in einer Folie zu finden und dann einfach diese Form zurückzugeben.

```c#
public static void Run()
{
    // Stellen Sie eine Präsentation-Klasse dar, die die Präsentationsdatei darstellt
    using (Presentation p = new Presentation("FindingShapeInSlide.pptx"))
    {

        ISlide slide = p.Slides[0];
        // Alternativtext der zu findenden Form
        IShape shape = FindShape(slide, "Shape1");
        if (shape != null)
        {
            Console.WriteLine("Formname: " + shape.Name);
        }
    }
}
        
// Methodenimplementierung, um eine Form in einer Folie anhand ihres alternativen Textes zu finden
public static IShape FindShape(ISlide slide, string alttext)
{
    // Durchlaufen aller Formen innerhalb der Folie
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        // Wenn der alternative Text der Folie mit dem benötigten übereinstimmt, dann
        // Geben Sie die Form zurück
        if (slide.Shapes[i].AlternativeText.CompareTo(alttext) == 0)
            return slide.Shapes[i];
    }
    return null;
}
```


## **Form klonen**
Um eine Form auf eine Folie mithilfe von Aspose.Slides für .NET zu klonen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Erhalten Sie die Referenz einer Folie, indem Sie deren Index verwenden.
3. Greifen Sie auf die Formsammlung der Quellfolie zu.
4. Fügen Sie der Präsentation eine neue Folie hinzu.
5. Klonen Sie Formen aus der Formsammlung der Quellfolie auf die neue Folie.
6. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

Das folgende Beispiel fügt eine Gruppierung von Formen zu einer Folie hinzu.

```c#
// Präsentationsklasse instanziieren
using (Presentation srcPres = new Presentation("Source Frame.pptx"))
{
	IShapeCollection sourceShapes = srcPres.Slides[0].Shapes;
	ILayoutSlide blankLayout = srcPres.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
	ISlide destSlide = srcPres.Slides.AddEmptySlide(blankLayout);
	IShapeCollection destShapes = destSlide.Shapes;
	destShapes.AddClone(sourceShapes[1], 50, 150 + sourceShapes[0].Height);
	destShapes.AddClone(sourceShapes[2]);                 
	destShapes.InsertClone(0, sourceShapes[0], 50, 150);

	// Schreiben Sie die PPTX-Datei auf die Festplatte
	srcPres.Save("CloneShape_out.pptx", SaveFormat.Pptx);
}
```


## **Form entfernen**
Aspose.Slides für .NET ermöglicht es Entwicklern, jede Form zu entfernen. Um die Form von einer Folie zu entfernen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der `Presentation` Klasse.
2. Greifen Sie auf die erste Folie zu.
3. Finden Sie die Form mit einem bestimmten Alternativtext.
4. Entfernen Sie die Form.
5. Speichern Sie die Datei auf der Festplatte.

```c#
// Präsentationsobjekt erstellen
Presentation pres = new Presentation();

// Holen Sie sich die erste Folie
ISlide sld = pres.Slides[0];

// Fügen Sie eine Autoform vom Rechtecktyp hinzu
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
String alttext = "Benutzerdefiniert";
int iCount = sld.Shapes.Count;
for (int i = 0; i < iCount; i++)
{
    AutoShape ashp = (AutoShape)sld.Shapes[0];
    if (String.Compare(ashp.AlternativeText, alttext, StringComparison.Ordinal) == 0)
    {
        sld.Shapes.Remove(ashp);
    }
}

// Speichern Sie die Präsentation auf der Festplatte
pres.Save("RemoveShape_out.pptx", SaveFormat.Pptx);
```


## **Form ausblenden**
Aspose.Slides für .NET ermöglicht es Entwicklern, jede Form auszublenden. Um die Form von einer Folie auszublenden, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der `Presentation` Klasse.
2. Greifen Sie auf die erste Folie zu.
3. Finden Sie die Form mit einem bestimmten Alternativtext.
4. Blenden Sie die Form aus.
5. Speichern Sie die Datei auf der Festplatte.

```c#
// Präsentationsklasse instanziieren, die die PPTX darstellt
Presentation pres = new Presentation();

// Holen Sie sich die erste Folie
ISlide sld = pres.Slides[0];

// Fügen Sie eine Autoform vom Rechtecktyp hinzu
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
String alttext = "Benutzerdefiniert";
int iCount = sld.Shapes.Count;
for (int i = 0; i < iCount; i++)
{
	AutoShape ashp = (AutoShape)sld.Shapes[i];
	if (String.Compare(ashp.AlternativeText, alttext, StringComparison.Ordinal) == 0)
	{
		ashp.Hidden = true;
	}
}

// Speichern Sie die Präsentation auf der Festplatte
pres.Save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
```


## **Formenreihenfolge ändern**
Aspose.Slides für .NET ermöglicht es Entwicklern, die Reihenfolge der Formen zu ändern. Das Ändern der Reihenfolge der Form gibt an, welche Form vorne oder welche Form hinten ist. Um die Form von einer Folie neu anzuordnen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der `Presentation` Klasse.
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie eine Form hinzu.
4. Fügen Sie etwas Text im Textfeld der Form hinzu.
5. Fügen Sie eine weitere Form mit denselben Koordinaten hinzu.
6. Ändern Sie die Reihenfolge der Form.
7. Speichern Sie die Datei auf der Festplatte.

```c#
Presentation presentation1 = new Presentation("HelloWorld.pptx");
ISlide slide = presentation1.Slides[0];
IAutoShape shp3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 365, 400, 150);
shp3.FillFormat.FillType = FillType.NoFill;
shp3.AddTextFrame(" ");

ITextFrame txtFrame = shp3.TextFrame;
IParagraph para = txtFrame.Paragraphs[0];
IPortion portion = para.Portions[0];
portion.Text="Wasserzeichen Text Wasserzeichen Text Wasserzeichen Text";
shp3 = slide.Shapes.AddAutoShape(ShapeType.Triangle, 200, 365, 400, 150);
slide.Shapes.Reorder(2, shp3);
presentation1.Save("Reshape_out.pptx", SaveFormat.Pptx);
```


## **Interop-Form-ID abrufen**
Aspose.Slides für .NET ermöglicht es Entwicklern, eine eindeutige Form-Identifikationsnummer im Folienkontext im Gegensatz zur UniqueId-Eigenschaft zu erhalten, die eine eindeutige Identifikationsnummer im Präsentationskontext ermöglicht. Die Eigenschaft OfficeInteropShapeId wurde zu den IShape-Schnittstellen und zur Shape-Klasse hinzugefügt. Der von der OfficeInteropShapeId-Eigenschaft zurückgegebene Wert entspricht dem Wert der ID des Microsoft.Office.Interop.PowerPoint.Shape-Objekts. Unten folgt ein Beispielcode.

```c#
public static void Run()
{
	using (Presentation presentation = new Presentation("Presentation.pptx"))
	{
		// Eindeutige Form-Identifikationsnummer im Folienkontext abrufen
		long officeInteropShapeId = presentation.Slides[0].Shapes[0].OfficeInteropShapeId;
	}
}
```


## **Alternativen Text für Form festlegen**
Aspose.Slides für .NET ermöglicht es Entwicklern, den Alternativtext für jede Form festzulegen.
Formen in einer Präsentation können durch den Alternativtext oder die Shape Name-Eigenschaft unterschieden werden.
Die Alternativtext-Eigenschaft kann sowohl von Aspose.Slides als auch von Microsoft PowerPoint gelesen oder festgelegt werden.
Durch die Verwendung dieser Eigenschaft können Sie eine Form taggen und verschiedene Operationen durchführen wie das Entfernen einer Form,
das Ausblenden einer Form oder das Neuordnen von Formen auf einer Folie.
Um den Alternativtext einer Form festzulegen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der `Presentation` Klasse.
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie eine beliebige Form zur Folie hinzu.
4. Arbeiten Sie mit der neu hinzugefügten Form.
5. Durchlaufen Sie die Formen, um eine Form zu finden.
6. Setzen Sie den Alternativtext.
7. Speichern Sie die Datei auf der Festplatte.

```c#
// Präsentationsklasse instanziieren, die die PPTX darstellt
Presentation pres = new Presentation();

// Holen Sie sich die erste Folie
ISlide sld = pres.Slides[0];

// Fügen Sie eine Autoform vom Rechtecktyp hinzu
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
        ashp.AlternativeText = "Benutzerdefiniert";
    }
}

// Speichern Sie die Präsentation auf der Festplatte
pres.Save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
```


## **Zugriff auf Layoutformate für Formen**
Aspose.Slides für .NET bietet eine einfache API, um auf die Layoutformate für eine Form zuzugreifen. Dieser Artikel demonstriert, wie Sie auf Layoutformate zugreifen können.

Der folgende Beispielcode ist gegeben.

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

## **Form als SVG rendern**
Jetzt unterstützt Aspose.Slides für .NET das Rendern einer Form als SVG. Die Methode WriteAsSvg (und ihre Überladung) wurde zur Shape-Klasse und IShape-Schnittstelle hinzugefügt. Diese Methode ermöglicht es, den Inhalt der Form als SVG-Datei zu speichern. Der folgende Code zeigt, wie Sie die Form einer Folie in eine SVG-Datei exportieren.

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

## Form ausrichten

Durch die überladene Methode [SlidesUtil.AlignShape()](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/methods/alignshapes/index) können Sie 

* Formen relativ zu den Rändern einer Folie ausrichten. Siehe Beispiel 1. 
* Formen relativ zueinander ausrichten. Siehe Beispiel 2. 

Die Enumeration [ShapesAlignmentType](https://reference.aspose.com/slides/net/aspose.slides/shapesalignmenttype) definiert die verfügbaren Anpassungsoptionen.

### Beispiel 1

Dieser C#-Code zeigt Ihnen, wie Sie die Formen mit den Indizes 1, 2 und 4 entlang der oberen Kante einer Folie ausrichten:
Der Quellcode unten richtet Formen mit den Indizes 1, 2 und 4 entlang der oberen Kante der Folie aus.

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

### Beispiel 2

Dieser C#-Code zeigt Ihnen, wie Sie eine gesamte Sammlung von Formen relativ zur unteren Form in der Sammlung ausrichten:

``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
    SlideUtil.AlignShapes(ShapesAlignmentType.AlignBottom, false, pres.Slides[0].Shapes);
}
```