---
title: "Διαχείριση Σχημάτων Παρουσίασης σε .NET"
linktitle: "Διαχείριση Σχημάτων"
type: docs
weight: 40
url: /el/net/shape-manipulations/
keywords:
- "Σχήμα PowerPoint"
- "Σχήμα παρουσίασης"
- "Σχήμα σε διαφάνεια"
- "Εύρεση σχήματος"
- "Κλωνοποίηση σχήματος"
- "Αφαίρεση σχήματος"
- "Απόκρυψη σχήματος"
- "Αλλαγή σειράς σχήματος"
- "Λήψη Interop ID σχήματος"
- "Εναλλακτικό κείμενο σχήματος"
- "Μορφές διάταξης σχήματος"
- "Σχήμα ως SVG"
- "Μετατροπή σχήματος σε SVG"
- "Στοίχιση σχήματος"
- "PowerPoint"
- "Παρουσίαση"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Μάθετε να δημιουργείτε, επεξεργάζεστε και βελτιστοποιείτε σχήματα στο Aspose.Slides για .NET και να παραδίδετε υψηλών επιδόσεων παρουσιάσεις PowerPoint."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με σχήματα σε παρουσιάσεις χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να βρείτε ένα σχήμα σε μια διαφάνεια, να το κλωνοποιήσετε, να το αφαιρέσετε, να το κρύψετε, να αλλάξετε τη σειρά του, να λάβετε το Interop ID του σχήματος και να ορίσετε εναλλακτικό κείμενο για αναγνώριση και περαιτέρω επεξεργασία.

Επιπλέον καλύπτει πώς να έχετε πρόσβαση σε μορφές διάταξης για σχήματα, να αποδώσετε ένα σχήμα ως SVG, να ευθυγραμμίσετε σχήματα σε μια διαφάνεια και να χρησιμοποιήσετε ιδιότητες περιστροφής για οριζόντια και κάθετη κατοπτρισμό. Επιπλέον, το άρθρο περιλαμβάνει μια σύντομη ενότητα FAQ σχετικά με τον συνδυασμό σχημάτων, τη σειρά στοιβάγματος και το κλείδωμα των σχημάτων.

## **Εντοπισμός Σχήματος σε Διαφάνεια**
Αυτό το θέμα θα περιγράψει μια απλή τεχνική για να διευκολύνει τους προγραμματιστές στον εντοπισμό ενός συγκεκριμένου σχήματος σε μια διαφάνεια χωρίς τη χρήση του εσωτερικού του Id. Είναι σημαντικό να γνωρίζουμε ότι τα αρχεία παρουσίασης PowerPoint δεν διαθέτουν καμία μέθοδο για την αναγνώριση των σχημάτων σε μια διαφάνεια εκτός από ένα εσωτερικό μοναδικό Id. Φαίνεται δύσκολο για τους προγραμματιστές να βρουν ένα σχήμα χρησιμοποιώντας το εσωτερικό μοναδικό του Id. Όλα τα σχήματα που προστίθενται στις διαφάνειες έχουν κάποιο εναλλακτικό κείμενο (Alt Text). Προτείνουμε στους προγραμματιστές να χρησιμοποιούν εναλλακτικό κείμενο για τον εντοπισμό ενός συγκεκριμένου σχήματος. Μπορείτε να χρησιμοποιήσετε το MS PowerPoint για να ορίσετε το εναλλακτικό κείμενο για αντικείμενα που σχεδιάζετε να αλλάξετε στο μέλλον.

Αφού ορίσετε το εναλλακτικό κείμενο για οποιοδήποτε επιθυμητό σχήμα, μπορείτε στη συνέχεια να ανοίξετε την παρουσίαση χρησιμοποιώντας το Aspose.Slides για .NET και να διαπεράσετε όλα τα σχήματα που έχουν προστεθεί σε μια διαφάνεια. Σε κάθε επανάληψη, μπορείτε να ελέγξετε το εναλλακτικό κείμενο του σχήματος και το σχήμα με το αντίστοιχο εναλλακτικό κείμενο θα είναι το σχήμα που χρειάζεστε. Για να επιδείξουμε αυτήν την τεχνική καλύτερα, δημιουργήσαμε μια μέθοδο, [FindShape](https://reference.aspose.com/slides/el/net/aspose.slides.util/slideutil/findshape/#findshape_1) που εκτελεί την ενέργεια εύρεσης ενός συγκεκριμένου σχήματος σε μια διαφάνεια και επιστρέφει απλώς αυτό το σχήμα.

```c#
public static void Run()
{
    // Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει το αρχείο παρουσίασης
    using (Presentation p = new Presentation("FindingShapeInSlide.pptx"))
    {

        ISlide slide = p.Slides[0];
        // Εναλλακτικό κείμενο του σχήματος που πρέπει να βρεθεί
        IShape shape = FindShape(slide, "Shape1");
        if (shape != null)
        {
            Console.WriteLine("Shape Name: " + shape.Name);
        }
    }
}
        
// Υλοποίηση μεθόδου για την εύρεση σχήματος σε διαφάνεια με χρήση του εναλλακτικού κειμένου
public static IShape FindShape(ISlide slide, string alttext)
{
    // Επανάληψη σε όλα τα σχήματα μέσα στη διαφάνεια
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        // Αν το εναλλακτικό κείμενο της διαφάνειας ταιριάζει με το απαιτούμενο
        // Επιστροφή του σχήματος
        if (slide.Shapes[i].AlternativeText.CompareTo(alttext) == 0)
            return slide.Shapes[i];
    }
    return null;
}
```

## **Αντιγραφή Σχήματος**
Για την κλωνοποίηση ενός σχήματος σε μια διαφάνεια χρησιμοποιώντας το Aspose.Slides για .NET:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
2. Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το δείκτη της.
3. Προσπελάστε τη συλλογή σχημάτων της πηγής διαφάνειας.
4. Προσθέστε νέα διαφάνεια στην παρουσίαση.
5. Κλωνοποιήστε τα σχήματα από τη συλλογή σχημάτων της πηγής διαφάνειας στη νέα διαφάνεια.
6. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Το παρακάτω παράδειγμα προσθέτει ένα ομαδικό σχήμα σε μια διαφάνεια.

```c#
// Δημιουργία αντικειμένου Presentation
using (Presentation srcPres = new Presentation("Source Frame.pptx"))
{
	IShapeCollection sourceShapes = srcPres.Slides[0].Shapes;
	ILayoutSlide blankLayout = srcPres.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
	ISlide destSlide = srcPres.Slides.AddEmptySlide(blankLayout);
	IShapeCollection destShapes = destSlide.Shapes;
	destShapes.AddClone(sourceShapes[1], 50, 150 + sourceShapes[0].Height);
	destShapes.AddClone(sourceShapes[2]);                 
	destShapes.InsertClone(0, sourceShapes[0], 50, 150);

	// Αποθήκευση αρχείου PPTX στον δίσκο
	srcPres.Save("CloneShape_out.pptx", SaveFormat.Pptx);
}
```

## **Αφαίρεση Σχήματος**
Aspose.Slides για .NET επιτρέπει στους προγραμματιστές να αφαιρούν οποιοδήποτε σχήμα. Για να αφαιρέσετε το σχήμα από οποιαδήποτε διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης `Presentation`.
2. Προσπελάστε την πρώτη διαφάνεια.
3. Βρείτε το σχήμα με συγκεκριμένο AlternativeText.
4. Αφαιρέστε το σχήμα.
5. Αποθηκεύστε το αρχείο στον δίσκο.

```c#
 // Δημιουργία αντικειμένου Presentation
 Presentation pres = new Presentation();

 // Λήψη της πρώτης διαφάνειας
 ISlide sld = pres.Slides[0];

 // Προσθήκη αυτόματης μορφής τύπου ορθογώνιο
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

 // Αποθήκευση παρουσίασης στον δίσκο
 pres.Save("RemoveShape_out.pptx", SaveFormat.Pptx);
```

## **Απόκρυψη Σχήματος**
Aspose.Slides για .NET επιτρέπει στους προγραμματιστές να κρύβουν οποιοδήποτε σχήμα. Για να κρύψετε το σχήμα από οποιαδήποτε διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης `Presentation`.
2. Προσπελάστε την πρώτη διαφάνεια.
3. Βρείτε το σχήμα με συγκεκριμένο AlternativeText.
4. Κρύψτε το σχήμα.
5. Αποθηκεύστε το αρχείο στον δίσκο.

```c#
// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει το αρχείο PPTX
Presentation pres = new Presentation();

// Λήψη της πρώτης διαφάνειας
ISlide sld = pres.Slides[0];

// Προσθήκη αυτόματης μορφής τύπου ορθογώνιο
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

// Αποθήκευση παρουσίασης στον δίσκο
pres.Save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
```

## **Αλλαγή Σειράς Σχήματος**
Aspose.Slides για .NET επιτρέπει στους προγραμματιστές να αλλάζουν τη σειρά των σχημάτων. Η αλλαγή σειράς καθορίζει ποιο σχήμα είναι μπροστά ή ποιο είναι πίσω. Για να αλλάξετε τη σειρά ενός σχήματος σε οποιαδήποτε διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης `Presentation`.
2. Προσπελάστε την πρώτη διαφάνεια.
3. Προσθέστε ένα σχήμα.
4. Προσθέστε κάποιο κείμενο στο πλαίσιο κειμένου του σχήματος.
5. Προσθέστε ακόμη ένα σχήμα με τις ίδιες συντεταγμένες.
6. Αλλάξτε τη σειρά των σχημάτων.
7. Αποθηκεύστε το αρχείο στον δίσκο.

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

## **Ανάκτηση του Interop Shape ID**
Aspose.Slides για .NET επιτρέπει στους προγραμματιστές να λάβουν ένα μοναδικό αναγνωριστικό σχήματος σε επίπεδο διαφάνειας, σε αντίθεση με την ιδιότητα UniqueId, η οποία παρέχει μοναδικό αναγνωριστικό σε επίπεδο παρουσίασης. Η ιδιότητα OfficeInteropShapeId προστέθηκε στις διεπαφές IShape και στην κλάση Shape αντίστοιχα. Η τιμή που επιστρέφεται από την ιδιότητα OfficeInteropShapeId αντιστοιχεί στην τιμή του Id του αντικειμένου Microsoft.Office.Interop.PowerPoint.Shape. Παρακάτω δίνεται ένα δείγμα κώδικα.

```c#
public static void Run()
{
	using (Presentation presentation = new Presentation("Presentation.pptx"))
	{
		// Λήψη μοναδικού αναγνωριστικού σχήματος σε επίπεδο διαφάνειας
		long officeInteropShapeId = presentation.Slides[0].Shapes[0].OfficeInteropShapeId;
	}
}
```

## **Ορισμός Εναλλακτικού Κειμένου για Σχήμα**
Aspose.Slides για .NET επιτρέπει στους προγραμματιστές να ορίσουν το AlternateText οποιουδήποτε σχήματος.
Τα σχήματα σε μια παρουσίαση μπορούν να διακρίνονται από την ιδιότητα AlternativeText ή το όνομα σχήματος (Shape Name).
Η ιδιότητα AlternativeText μπορεί να διαβαστεί ή να οριστεί χρησιμοποιώντας το Aspose.Slides καθώς και το Microsoft PowerPoint.
Με τη χρήση αυτής της ιδιότητας, μπορείτε να ετικετοποιήσετε ένα σχήμα και να εκτελέσετε διάφορες ενέργειες όπως αφαίρεση, απόκρυψη ή αλλαγή σειράς των σχημάτων στην διαφάνεια.
Για να ορίσετε το AlternateText ενός σχήματος, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης `Presentation`.
2. Προσπελάστε την πρώτη διαφάνεια.
3. Προσθέστε οποιοδήποτε σχήμα στη διαφάνεια.
4. Εκτελέστε κάποιες εργασίες με το πρόσφατα προστιθέμενο σχήμα.
5. Διασχίστε τα σχήματα για να βρείτε ένα σχήμα.
6. Ορίστε το AlternativeText.
7. Αποθηκεύστε το αρχείο στον δίσκο.

```c#
// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει το αρχείο PPTX
Presentation pres = new Presentation();

// Λήψη της πρώτης διαφάνειας
ISlide sld = pres.Slides[0];

// Προσθήκη αυτόματης μορφής τύπου ορθογώνιο
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

// Αποθήκευση παρουσίασης στον δίσκο
pres.Save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
```

## **Πρόσβαση σε Μορφές Διάταξης για Σχήμα**
Το Aspose.Slides για .NET παρέχει ένα απλό API για την πρόσβαση σε μορφές διάταξης ενός σχήματος. Αυτό το άρθρο δείχνει πώς μπορείτε να έχετε πρόσβαση σε μορφές διάταξης.

Παρακάτω δίνεται ένα δείγμα κώδικα.

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

## **Απόδοση Σχήματος ως SVG**
Τώρα το Aspose.Slides για .NET υποστηρίζει την απόδοση ενός σχήματος ως SVG. Η μέθοδος WriteAsSvg (και η υπερφόρτωσή της) προστέθηκε στην κλάση Shape και στη διεπαφή IShape. Αυτή η μέθοδος επιτρέπει την αποθήκευση του περιεχομένου του σχήματος ως αρχείο SVG. Το παρακάτω απόσπασμα κώδικα δείχνει πώς να εξάγετε το σχήμα μιας διαφάνειας σε αρχείο SVG.

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

## **Στοίχιση Σχήματος**

Μέσω της υπερφορτωμένης μεθόδου [SlidesUtil.AlignShape()](https://reference.aspose.com/slides/el/net/aspose.slides.util/slideutil/methods/alignshapes/index), μπορείτε

* να στοιχίσετε σχήματα σχετικά με τα περιθώρια μιας διαφάνειας. Δείτε το Παράδειγμα 1.
* να στοιχίσετε σχήματα μεταξύ τους. Δείτε το Παράδειγμα 2.

Η αρίθμηση [ShapesAlignmentType](https://reference.aspose.com/slides/el/net/aspose.slides/shapesalignmenttype) ορίζει τις διαθέσιμες επιλογές στοίχισης.

**Παράδειγμα 1**

Αυτός ο κώδικας C# δείχνει πώς να στοιχίσετε σχήματα με δείκτες 1,2 και 4 κατά μήκος του άνω ορίου μιας διαφάνειας:
Ο κώδικας παρακάτω στοιχίζει σχήματα με δείκτες 1,2 και 4 κατά μήκος του άνω ορίου της διαφάνειας.

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

**Παράδειγμα 2**

Αυτός ο κώδικας C# δείχνει πώς να στοιχίσετε ολόκληρη τη συλλογή σχημάτων σχετικά με το κάτω σχήμα της συλλογής:

``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
    SlideUtil.AlignShapes(ShapesAlignmentType.AlignBottom, false, pres.Slides[0].Shapes);
}
```

## **Ιδιότητες Αναστροφής**

Στο Aspose.Slides, η κλάση [ShapeFrame](https://reference.aspose.com/slides/el/net/aspose.slides/shapeframe/) παρέχει έλεγχο για οριζόντια και κάθετη κατοπτριστική αναστροφή των σχημάτων μέσω των ιδιοτήτων `FlipH` και `FlipV`. Και οι δύο ιδιότητες είναι τύπου [NullableBool](https://reference.aspose.com/slides/el/net/aspose.slides/nullablebool/), επιτρέποντας τις τιμές `True` για αναστροφή, `False` για χωρίς αναστροφή, ή `NotDefined` για χρήση της προεπιλεγμένης συμπεριφοράς. Αυτές οι τιμές είναι προσβάσιμες από το [Frame](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/frame/) ενός σχήματος.

Για να τροποποιήσετε τις ρυθμίσεις αναστροφής, δημιουργείται μια νέα παρουσία της κλάσης [ShapeFrame](https://reference.aspose.com/slides/el/net/aspose.slides/shapeframe/) με τη τρέχουσα θέση και μέγεθος του σχήματος, τις επιθυμητές τιμές για `FlipH` και `FlipV`, και την γωνία περιστροφής. Η ανάθεση αυτής της παρουσίασης στο [Frame](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/frame/) του σχήματος και η αποθήκευση της παρουσίασης εφαρμόζουν τις μετασχηματισμούς κατοπτρισμού και τα αποθηκεύουν στο αρχείο εξόδου.

Ας υποθέσουμε ότι έχουμε ένα αρχείο sample.pptx όπου η πρώτη διαφάνεια περιέχει ένα μόνο σχήμα με προεπιλεγμένες ρυθμίσεις αναστροφής, όπως φαίνεται παρακάτω.

![Το σχήμα που θα αντιστραφεί](shape_to_be_flipped.png)

Το παρακάτω παράδειγμα κώδικα ανακτά τις τρέχουσες ιδιότητες αναστροφής του σχήματος και το αντιστρέφει οριζόντια και κάθετα.

```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];

    // Ανάκτηση της οριζόντιας ιδιότητας αντιστροφής του σχήματος.
    NullableBool horizontalFlip = shape.Frame.FlipH;
    Console.WriteLine($"Horizontal flip: {horizontalFlip}");

    // Ανάκτηση της κάθετης ιδιότητας αντιστροφής του σχήματος.
    NullableBool verticalFlip = shape.Frame.FlipV;
    Console.WriteLine($"Vertical flip: {verticalFlip}");

    float x = shape.Frame.X;
    float y = shape.Frame.Y;
    float width = shape.Frame.Width;
    float height = shape.Frame.Height;
    NullableBool flipH = NullableBool.True; // Αντιστροφή οριζόντια.
    NullableBool flipV = NullableBool.True; // Αντιστροφή κάθετη.
    float rotation = shape.Frame.Rotation;

    shape.Frame = new ShapeFrame(x, y, width, height, flipH, flipV, rotation);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Το αντιστραμμένο σχήμα](flipped_shape.png)

## **Συχνές Ερωτήσεις**

**Μπορώ να συνδυάσω σχήματα (ένωση/τομή/αφαίρεση) σε μια διαφάνεια όπως σε έναν επεξεργαστή επιφάνειας εργασίας;**

Δεν υπάρχει ενσωματωμένο API για λογικές (Boolean) λειτουργίες. Μπορείτε να προσεγγίσετε το αποτέλεσμα κατασκευάζοντας μόνοι σας το επιθυμητό περίγραμμα — π.χ., υπολογίζοντας τη γεωμετρία που προκύπτει (μέσω του [GeometryPath](https://reference.aspose.com/slides/el/net/aspose.slides/geometrypath/)) και δημιουργώντας ένα νέο σχήμα με αυτό το περίγραμμα, προαιρετικά αφαιρώντας τα αρχικά.

**Πώς μπορώ να ελέγξω τη σειρά στοιβάγματος (z-order) ώστε ένα σχήμα να παραμένει πάντα «στην κορυφή»;**

Αλλάξτε τη σειρά εισαγωγής/μετακίνησης εντός της συλλογής [shapes](https://reference.aspose.com/slides/el/net/aspose.slides/baseslide/shapes/) της διαφάνειας. Για προβλεπόμενα αποτελέσματα, ορίστε definitively τη σειρά z-order μετά από όλες τις άλλες τροποποιήσεις της διαφάνειας.

**Μπορώ να «κλειδώσω» ένα σχήμα ώστε να αποτρέψω τους χρήστες από το να το επεξεργαστούν στο PowerPoint;**

Ναι. Ορίστε τις [σημαίες προστασίας επιπέδου σχήματος](/slides/el/net/applying-protection-to-presentation/) (π.χ., κλείδωμα επιλογής, κίνησης, αλλαγής μεγέθους, επεξεργασίας κειμένου). Αν χρειάζεται, εφαρμόστε περιορισμούς στον κύριο ή στο layout. Σημειώστε ότι αυτή είναι προστασία σε επίπεδο διεπαφής χρήστη, όχι χαρακτηριστικό ασφαλείας· για πιο ισχυρή προστασία, συνδυάστε με περιορισμούς σε επίπεδο αρχείου όπως [συστάσεις μόνο για ανάγνωση ή κωδικοί πρόσβασης](/slides/el/net/password-protected-presentation/).