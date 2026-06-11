---
title: Hantera presentationsformer i .NET
linktitle: Formmanipulering
type: docs
weight: 40
url: /sv/net/shape-manipulations/
keywords:
- PowerPoint-form
- presentationsform
- form på bild
- hitta form
- klona form
- ta bort form
- dölj form
- ändra formordning
- hämta Interop-form-ID
- alternativ text för form
- formlayoutformat
- form som SVG
- form till SVG
- justera form
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig att skapa, redigera och optimera former i Aspose.Slides för .NET och leverera högpresterande PowerPoint-presentationer."
---
## **Översikt**

Den här artikeln förklarar hur man arbetar med former i presentationer med Aspose.Slides. Den visar hur man hittar en form på en bild, klonar den, tar bort den, döljer den, ändrar dess ordning, får dess Interop-form-ID och anger alternativ text för identifiering och vidare bearbetning.

Den täcker också hur man får åtkomst till layoutformat för former, renderar en form som SVG, justerar former på en bild och använder vändningsegenskaper för horisontell och vertikal spegling. Dessutom innehåller artikeln en kort FAQ om formkombination, staplingsordning och låsning av former.

## **Hitta en form på en bild**
Det här ämnet beskriver en enkel teknik för att göra det enklare för utvecklare att hitta en specifik form på en bild utan att använda dess interna Id. Det är viktigt att veta att PowerPoint-presentationer inte har något sätt att identifiera former på en bild förutom ett internt unikt Id. Det verkar vara svårt för utvecklare att hitta en form med dess interna unika Id. Alla former som läggs till på bilderna har någon Alt‑text. Vi föreslår att utvecklare använder alternativ text för att hitta en specifik form. Du kan använda MS PowerPoint för att definiera den alternativa texten för objekt som du planerar att ändra i framtiden.

Efter att ha angett den alternativa texten för en önskad form kan du öppna presentationen med Aspose.Slides for .NET och iterera genom alla former som lagts till på en bild. Under varje iteration kan du kontrollera formens alternativa text och den form vars alternativa text matchar är den du söker. För att demonstrera denna teknik på ett bättre sätt har vi skapat en metod, [FindShape](https://reference.aspose.com/slides/sv/net/aspose.slides.util/slideutil/findshape/#findshape_1) som gör tricket att hitta en specifik form på en bild och sedan helt enkelt returnerar den formen.

```c#
public static void Run()
{
    // Skapa en Presentation-klass som representerar presentationsfilen
    using (Presentation p = new Presentation("FindingShapeInSlide.pptx"))
    {

        ISlide slide = p.Slides[0];
        // Alternativ text för den form som ska hittas
        IShape shape = FindShape(slide, "Shape1");
        if (shape != null)
        {
            Console.WriteLine("Shape Name: " + shape.Name);
        }
    }
}
        
// Metodimplementation för att hitta en form i en bild med dess alternativa text
public static IShape FindShape(ISlide slide, string alttext)
{
    // Itererar genom alla former i bilden
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        // Om den alternativa texten i bilden matchar den som krävs så
        // Returnera formen
        if (slide.Shapes[i].AlternativeText.CompareTo(alttext) == 0)
            return slide.Shapes[i];
    }
    return null;
}
```

## **Klona en form**
För att klona en form till en bild med Aspose.Slides for .NET:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
2. Hämta referensen till en bild genom att använda dess index.
3. Åtkomst till källbildens formsamling.
4. Lägg till en ny bild i presentationen.
5. Klona former från källbildens formsamling till den nya bilden.
6. Spara den ändrade presentationen som en PPTX‑fil.

Exemplet nedan lägger till en gruppform på en bild.

```c#
// Instansiera Presentation-klass
using (Presentation srcPres = new Presentation("Source Frame.pptx"))
{
	IShapeCollection sourceShapes = srcPres.Slides[0].Shapes;
	ILayoutSlide blankLayout = srcPres.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
	ISlide destSlide = srcPres.Slides.AddEmptySlide(blankLayout);
	IShapeCollection destShapes = destSlide.Shapes;
	destShapes.AddClone(sourceShapes[1], 50, 150 + sourceShapes[0].Height);
	destShapes.AddClone(sourceShapes[2]);                 
	destShapes.InsertClone(0, sourceShapes[0], 50, 150);

	// Skriv PPTX-filen till disk
	srcPres.Save("CloneShape_out.pptx", SaveFormat.Pptx);
}
```

## **Ta bort en form**
Aspose.Slides for .NET låter utvecklare ta bort valfri form. För att ta bort formen från en bild, följ stegen nedan:

1. Skapa en instans av klassen `Presentation`.
2. Åtkomst till den första bilden.
3. Hitta formen med specifik AlternativeText.
4. Ta bort formen.
5. Spara filen till disk.

```c#
// Skapa Presentation-objekt
Presentation pres = new Presentation();

// Hämta den första bilden
ISlide sld = pres.Slides[0];

// Lägg till autoshape av rektangeltyp
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

// Spara presentationen till disk
pres.Save("RemoveShape_out.pptx", SaveFormat.Pptx);
```

## **Dölj en form**
Aspose.Slides for .NET låter utvecklare dölja valfri form. För att dölja formen på en bild, följ stegen nedan:

1. Skapa en instans av klassen `Presentation`.
2. Åtkomst till den första bilden.
3. Hitta formen med specifik AlternativeText.
4. Dölj formen.
5. Spara filen till disk.

```c#
// Instansiera Presentation-klass som representerar PPTX-filen
Presentation pres = new Presentation();

// Hämta den första bilden
ISlide sld = pres.Slides[0];

// Lägg till autoshape av rektangeltyp
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

// Spara presentationen till disk
pres.Save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
```

## **Ändra formens ordning**
Aspose.Slides for .NET låter utvecklare ändra ordningen på former. Att ändra ordning på en form anger vilken form som är längst fram eller längst bak. För att ändra ordningen på en form på en bild, följ stegen nedan:

1. Skapa en instans av klassen `Presentation`.
2. Åtkomst till den första bilden.
3. Lägg till en form.
4. Lägg till lite text i formens textram.
5. Lägg till en annan form med samma koordinater.
6. Ändra ordningen på formerna.
7. Spara filen till disk.

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

## **Hämta Interop-formens ID**
Aspose.Slides for .NET låter utvecklare hämta en unik formidentifierare i bildnivå i motsats till UniqueId‑egenskapen, som ger ett unikt identifierare på presentationsnivå. Egenskapen OfficeInteropShapeId har lagts till IShape‑gränssnitten och Shape‑klassen. Värdet som returneras av OfficeInteropShapeId‑egenskapen motsvarar Id‑värdet för Microsoft.Office.Interop.PowerPoint.Shape‑objektet. Nedan ges ett exempel på kod.

```c#
public static void Run()
{
	using (Presentation presentation = new Presentation("Presentation.pptx"))
	{
		// Hämtar unikt formidentifierare i bildomfång
		long officeInteropShapeId = presentation.Slides[0].Shapes[0].OfficeInteropShapeId;
	}
}
```

## **Ange alternativ text för en form**
Aspose.Slides for .NET låter utvecklare ange AlternateText för vilken form som helst. 
Former i en presentation kan särskiljas med egenskapen AlternativeText eller formens namn. 
AlternativeText‑egenskapen kan läsas eller skrivas med Aspose.Slides såväl som Microsoft PowerPoint. 
Genom att använda denna egenskap kan du märka en form och utföra olika operationer som att ta bort en form, 
dölja en form eller ändra ordningen på former på en bild. 
För att ange AlternateText för en form, följ stegen nedan:

1. Skapa en instans av klassen `Presentation`.
2. Åtkomst till den första bilden.
3. Lägg till någon form på bilden.
4. Utför någon åtgärd med den nyligen tillagda formen.
5. Iterera genom formerna för att hitta en form.
6. Ange AlternativeText.
7. Spara filen till disk.

```c#
// Instansiera Presentation-klass som representerar PPTX-filen
Presentation pres = new Presentation();

// Hämta den första bilden
ISlide sld = pres.Slides[0];

// Lägg till autoshape av rektangeltyp
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

// Spara presentationen till disk
pres.Save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
```

## **Få åtkomst till layoutformat för en form**
Aspose.Slides for .NET erbjuder ett enkelt API för att få åtkomst till layoutformat för en form. Denna artikel visar hur du kan nå layoutformat.

Nedan ges exempel på kod.

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

## **Rendera en form som SVG**
Nu stödjer Aspose.Slides for .NET rendering av en form som SVG. Metoden WriteAsSvg (och dess överlagring) har lagts till i Shape‑klassen och IShape‑gränssnittet. Denna metod tillåter att spara formens innehåll som en SVG‑fil. Kodsnutten nedan visar hur man exporterar en bilds form till en SVG‑fil.

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

## **Justera en form**
Genom den överlagrade metoden [SlidesUtil.AlignShape()](https://reference.aspose.com/slides/sv/net/aspose.slides.util/slideutil/methods/alignshapes/index) kan du 

* justera former relativt till bildens marginaler. Se Exempel 1. 
* justera former relativt till varandra. Se Exempel 2. 

Enumen [ShapesAlignmentType](https://reference.aspose.com/slides/sv/net/aspose.slides/shapesalignmenttype) definierar de tillgängliga justeringsalternativen.

**Exempel 1**

Den här C#‑koden visar hur du justerar former med index 1,2 och 4 längs den övre kanten på en bild:
Källkoden nedan justerar former med index 1,2 och 4 längs bildens överkant.

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

**Exempel 2**

Den här C#‑koden visar hur du justerar en hel samling former relativt till den nedersta formen i samlingen:

``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
    SlideUtil.AlignShapes(ShapesAlignmentType.AlignBottom, false, pres.Slides[0].Shapes);
}
```

## **Vändningsegenskaper**
I Aspose.Slides ger klassen [ShapeFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/shapeframe/) kontroll över horisontell och vertikal spegling av former via dess egenskaper `FlipH` och `FlipV`. Båda egenskaperna är av typen [NullableBool](https://reference.aspose.com/slides/sv/net/aspose.slides/nullablebool/), vilket tillåter värdena `True` för att ange en spegling, `False` för ingen spegling, eller `NotDefined` för att använda standardbeteende. Dessa värden är åtkomliga via en forms [Frame](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/frame/). 

För att ändra vändningsinställningarna konstrueras en ny [ShapeFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/shapeframe/)-instans med formens aktuella position och storlek, önskade värden för `FlipH` och `FlipV` samt rotationsvinkeln. Genom att tilldela denna instans till formens [Frame](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/frame/) och spara presentationen appliceras spegeleffekterna och skrivs till utdatafilen.

Anta att vi har en fil sample.pptx där den första bilden innehåller en enda form med standardinställningarna för spegling, som visas nedan.

![Formen som ska speglas](shape_to_be_flipped.png)

```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];

    // Hämta den horisontella vändningsegenskapen för formen.
    NullableBool horizontalFlip = shape.Frame.FlipH;
    Console.WriteLine($"Horizontal flip: {horizontalFlip}");

    // Hämta den vertikala vändningsegenskapen för formen.
    NullableBool verticalFlip = shape.Frame.FlipV;
    Console.WriteLine($"Vertical flip: {verticalFlip}");

    float x = shape.Frame.X;
    float y = shape.Frame.Y;
    float width = shape.Frame.Width;
    float height = shape.Frame.Height;
    NullableBool flipH = NullableBool.True; // Vänd horisontellt.
    NullableBool flipV = NullableBool.True; // Vänd vertikalt.
    float rotation = shape.Frame.Rotation;

    shape.Frame = new ShapeFrame(x, y, width, height, flipH, flipV, rotation);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

Följande kodexempel hämtar formens aktuella vändningsegenskaper och speglar den både horisontellt och vertikalt.

Resultatet:

![Den speglade formen](flipped_shape.png)

## **FAQ**

**Kan jag kombinera former (union/intersect/subtract) på en bild som i en skrivbordsredigerare?**

Det finns inget inbyggt API för booleska operationer. Du kan approximera det genom att själv konstruera den önskade konturen—t.ex. beräkna den resulterande geometrin (via [GeometryPath](https://reference.aspose.com/slides/sv/net/aspose.slides/geometrypath/)) och skapa en ny form med den konturen, eventuellt ta bort de ursprungliga.

**Hur kan jag kontrollera staplingsordningen (z-order) så att en form alltid förblir "överst"?**

Ändra infognings‑/flyttningsordningen i bildens [shapes](https://reference.aspose.com/slides/sv/net/aspose.slides/baseslide/shapes/)-samling. För förutsägbara resultat, slutför z‑ordningen efter alla andra bildändringar.

**Kan jag "låsa" en form för att förhindra att användare redigerar den i PowerPoint?**

Ja. Ställ in [formnivåns skyddsvflags](/slides/sv/net/applying-protection-to-presentation/) (t.ex. lås val, flytt, storleksändring, textredigering). Vid behov speglas restriktionerna på master- eller layoutnivå. Observera att detta är skydd på UI‑nivå, inte en säkerhetsfunktion; för starkare skydd kombinera med filnivårestriktioner som [rekommendationer för skrivskydd eller lösenord](/slides/sv/net/password-protected-presentation/).