---
title: Προσαρμογή Σχημάτων Παρουσίασης σε .NET
linktitle: Προσαρμοσμένο Σχήμα
type: docs
weight: 20
url: /el/net/custom-shape/
keywords:
- προσαρμοσμένο σχήμα
- προσθήκη σχήματος
- δημιουργία σχήματος
- αλλαγή σχήματος
- γεωμετρία σχήματος
- μονοπάτι γεωμετρίας
- σημεία μονοπατιού
- σημεία επεξεργασίας
- προσθήκη σημείου
- αφαίρεση σημείου
- λειτουργία επεξεργασίας
- καμπυλωτή γωνία
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Δημιουργία και προσαρμογή σχημάτων σε παρουσιάσεις PowerPoint με το Aspose.Slides για .NET: μονοπάτια γεωμετρίας, καμπυλωτές γωνίες, σύνθετα σχήματα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσαρμόζετε τα σχήματα παρουσίασης στο Aspose.Slides επεξεργάζοντας τη γεωμετρία του σχήματος μέσω σημείων επεξεργασίας και μονοπατιών γεωμετρίας. Δείχνει πώς να εργάζεστε με [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) και [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) για να τροποποιήσετε υπάρχοντα σχήματα, να εκτελέσετε βασικές λειτουργίες επεξεργασίας μονοπατιών, να προσθέσετε ή να αφαιρέσετε σημεία και να εφαρμόσετε την ενημερωμένη γεωμετρία σε ένα σχήμα.

Επίσης δείχνει πώς να δημιουργείτε προσαρμοσμένα και σύνθετα σχήματα, να κατασκευάσετε σχήματα με κυρτές γωνίες, να καθορίσετε αν η γεωμετρία ενός σχήματος είναι κλειστή και να χρησιμοποιήσετε τη κληρονομική μετατροπή μεταξύ [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) και [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) για επιπρόσθετα σενάρια προσαρμογής γεωμετρίας.

## **Αλλαγή Σχήματος Χρησιμοποιώντας Σημεία Επεξεργασίας**

Στο PowerPoint, μπορείτε να χρησιμοποιήσετε **Edit Points** για να τροποποιήσετε ένα τετράγωνο:

* Μετακινήστε μια γωνία προς το εσωτερικό ή το εξωτερικό.
* Ρυθμίστε την κυρτότητα σε ένα σημείο.
* Προσθέστε νέα σημεία.

Η επεξεργασία σημείων σας επιτρέπει να τροποποιήσετε το περίγραμμα ενός σχήματος ή να χρησιμοποιήσετε ένα υπάρχον σχήμα ως βάση για ένα νέο.

## **Συμβουλές Επεξεργασίας Σχήματος**

![overview_image](custom_shape_0.png)

Κατά την επεξεργασία σχημάτων PowerPoint, κρατήστε αυτές τις έννοιες στο μυαλό:

* Ένα σχήμα (ή το μονοπάτι του) μπορεί να είναι είτε κλειστό είτε ανοικτό.
* Το μονοπάτι ενός σχήματος αποτελείται από σημεία αγκύρωσης συνδεδεμένα με τμήματα.
* Ένα τμήμα μπορεί να είναι ευθύ ή καμπυλωτό. Τα σημεία αγκύρωσης και τα χειριστήρια ελέγχου καθορίζουν το σχήμα του.
* Τα σημεία αγκύρωσης υπάρχουν ως γωνιακά σημεία, ευθύγραμμα σημεία ή λείες (smooth) σημεία:
  * Σε ένα γωνιακό σημείο, τα διπλότυπα τμήματα μπορούν να συναντηθούν σε γωνία.
  * Σε ένα λείο σημείο, τα δύο χειριστήρια ελέγχου είναι ευθυγραμμισμένα και ισαπέχουν από το σημείο αγκύρωσης.
  * Σε ένα ευθύ σημείο, τα δύο χειριστήρια ελέγχου είναι ευθυγραμμισμένα αλλά μπορούν να έχουν διαφορετικές αποστάσεις από το σημείο αγκύρωσης.
* Η μετακίνηση των σημείων αγκύρωσης ή η ρύθμιση των χειριστηρίων τους αλλάζει το περίγραμμα του σχήματος.

Για να επεξεργαστείτε τα σχήματα PowerPoint μέσω σημείων επεξεργασίας, το **Aspose.Slides** παρέχει την κλάση [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) και τη διεπαφή [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/).

* Ένα [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) αντικείμενο αντιπροσωπεύει ένα μονοπάτι γεωμετρίας του αντικειμένου [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/).
* Για να ανακτήσετε το [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) από το αντικείμενο [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/), μπορείτε να χρησιμοποιήσετε τη μέθοδο [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/).
* Για να ορίσετε το [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) για ένα σχήμα, μπορείτε να χρησιμοποιήσετε τις μεθόδους: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) για σχήματα με ένα μόνο μονοπάτι και [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) για σχήματα με πολλαπλά μονοπάτια.
* Για να προσθέσετε τμήματα, μπορείτε να χρησιμοποιήσετε τις μεθόδους κάτω από [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/).
* Χρησιμοποιώντας τις ιδιότητες [IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/stroke/) και [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/), μπορείτε να ορίσετε την εμφάνιση ενός μονοπατιού γεωμετρίας.
* Χρησιμοποιώντας την ιδιότητα [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/), μπορείτε να ανακτήσετε το μονοπάτι γεωμετρίας ενός [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape/) ως έναν πίνακα τμημάτων μονοπατιού.
* Σε παλαιότερες εκδόσεις που υποστηρίζουν τις παρακάτω μεθόδους μετατροπής, μπορείτε να μετατρέψετε το [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) σε [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath).
* Χρησιμοποιήστε τις μεθόδους [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/) και [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) (από την κλάση [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/)) για να μετατρέψετε μεταξύ [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) και [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath).

## **Απλές Λειτουργίες Επεξεργασίας**

Χρησιμοποιήστε τις ακόλουθες μεθόδους για να επεξεργαστείτε ένα μονοπάτι γεωμετρίας. Οι υπερφορτώσεις που δέχονται έναν δείκτη εισάγουν ένα τμήμα στη μηδενική θέση του πίνακα τμημάτων του μονοπατιού.

| Λειτουργία | Μέθοδος |
| --- | --- |
| Προσθήκη ή εισαγωγή ευθείας γραμμής. | [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) |
| Προσθήκη ή εισαγωγή κυρτής Bézier καμπύλης τρίτου βαθμού με δύο σημεία ελέγχου και ένα τελικό σημείο. | [GeometryPath.CubicBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/cubicbezierto/) |
| Προσθήκη ή εισαγωγή τετραγωνικής Bézier καμπύλης με ένα σημείο ελέγχου και ένα τελικό σημείο. | [GeometryPath.QuadraticBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/quadraticbezierto/) |
| Προσθήκη ελλειπτικής τόξας με τις καθορισμένες διαστάσεις και γωνίες σε μοίρες. | [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) |
| Κλείσιμο του τρέχοντος σχήματος συνδέοντας το τελικό του σημείο με το αρχικό. | [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) |
| Ορισμός του αρχικού σημείου ενός σχήματος. | [GeometryPath.MoveTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/moveto/) |
| Αφαίρεση τμήματος σε δείκτη μηδενικής βάσης. | [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/) |

## **Προσθήκη Προσαρμοσμένων Σημείων σε Σχήμα**

Αυτό το παράδειγμα εισάγει δύο σημεία σε ένα ορθογώνιο σχήμα χρησιμοποιώντας [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) και εφαρμόζει το επεξεργασμένο μονοπάτι με [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/). Οι συντεταγμένες είναι τοπικές στο σχήμα: και τα δύο νέα σημεία βρίσκονται στο κέντρο του, 100 σημεία από αριστερά και 50 σημεία από πάνω. Οι δείκτες τμημάτων 1 και 4 τα τοποθετούν στα άνω και κάτω άκρα, τραβώντας αυτά τα άκρα προς το εσωτερικό.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

var geometryPath = shape.GetGeometryPaths()[0];
geometryPath.LineTo(100, 50, 1);
geometryPath.LineTo(100, 50, 4);

shape.SetGeometryPath(geometryPath);
```

![example1_image](custom_shape_1.png)

## **Αφαίρεση Σημείων από Σχήμα**

Αυτό το παράδειγμα αλλάζει το περίγραμμα μιας καρδιάς αφαιρώντας το τμήμα στη θέση δείκτη 2 με [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/). Η εφαρμογή του τροποποιημένου μονοπατιού με [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) ενημερώνει το περίγραμμα του σχήματος.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Heart, 100, 100, 300, 300);

var path = shape.GetGeometryPaths()[0];
path.RemoveAt(2);

shape.SetGeometryPath(path);
```
![example2_image](custom_shape_2.png)

## **Δημιουργία Προσαρμοσμένου Σχήματος**

Αυτό το παράδειγμα δημιουργεί ένα πεντάπλευρο αστέρι με [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/). Εναλλασσόμενες εξωτερικές και εσωτερικές ακτίνες 100 και 50 σημεία καθορίζουν τις άκρες και τις υποβάθμισης· βήμα 72 μοιρών χωρίζει ομοιόμορφα τις πέντε άκρες. Το μονοπάτι κλείνει με [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) και εφαρμόζεται σε ένα ορθογώνιο σχήμα με [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/), αντικαθιστώντας το περίγραμμά του.

```csharp
using System;
using System.Collections.Generic;
using System.Drawing;
using Aspose.Slides;

var points = new List<PointF>();

var outerRadius = 100f;
var innerRadius = 50f;
var angleStep = 72;

for (var angle = -90; angle < 270; angle += angleStep)
{
    var radians = angle * (Math.PI / 180f);
    var x = outerRadius * Math.Cos(radians);
    var y = outerRadius * Math.Sin(radians);
    points.Add(new PointF((float)x + outerRadius, (float)y + outerRadius));

    radians = Math.PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math.Cos(radians);
    y = innerRadius * Math.Sin(radians);
    points.Add(new PointF((float)x + outerRadius, (float)y + outerRadius));
}

var starPath = new GeometryPath();
starPath.MoveTo(points[0]);

for (var i = 1; i < points.Count; i++)
{
    starPath.LineTo(points[i]);
}

starPath.CloseFigure();

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
shape.SetGeometryPath(starPath);
```
![example3_image](custom_shape_3.png)

## **Δημιουργία Σύνθετου Προσαρμοσμένου Σχήματος**

Αυτό το παράδειγμα ορίζει δύο κλειστά [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) αντικείμενα για το άνω και το κάτω τρίτο ενός σχήματος. Η εφαρμογή και των δύο μονοπατιών με [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) δημιουργεί ένα ενιαίο σύνθετο σχήμα με ένα κενό στο μέσο τρίτο.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

var topPath = new GeometryPath();
topPath.MoveTo(0, 0);
topPath.LineTo(shape.Width, 0);
topPath.LineTo(shape.Width, shape.Height / 3);
topPath.LineTo(0, shape.Height / 3);
topPath.CloseFigure();

var bottomPath = new GeometryPath();
bottomPath.MoveTo(shape.Height / 3 * 2);
bottomPath.LineTo(shape.Width, shape.Height / 3 * 2);
bottomPath.LineTo(shape.Width, shape.Height);
bottomPath.LineTo(0, shape.Height);
bottomPath.CloseFigure();

shape.SetGeometryPaths(new GeometryPath[] { topPath, bottomPath });
```
![example4_image](custom_shape_4.png)

## **Δημιουργία Προσαρμοσμένου Σχήματος με Καμπυλωτές Γωνίες**

Αυτό το παράδειγμα συνδυάζει ευθείες ενότητες με [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) για να δημιουργήσει σχήμα με εσωτερικά καμπυλωτές γωνίες. Το μέγεθος κάθε γωνίας ορίζει το πλάτος και το ύψος του τόξου σε σημεία, και το σκαντζόχορδο -90 μοιρών σχεδιάζει ένα αντερόφιλο τέταρτο έλλειψο. Το ολοκληρωμένο μονοπάτι εφαρμόζεται με [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/), και η παρουσίαση αποθηκεύεται σε μορφή PPTX.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var shapeX = 20f;
var shapeY = 20f;
var shapeWidth = 300f;
var shapeHeight = 200f;

var leftTopSize = 50f;
var rightTopSize = 20f;
var rightBottomSize = 40f;
var leftBottomSize = 10f;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var topLeft = new PointF(leftTopSize, 0);
var topRight = new PointF(shapeWidth - rightTopSize, 0);
var rightBottom = new PointF(shapeWidth, shapeHeight - rightBottomSize);
var bottomLeft = new PointF(leftBottomSize, shapeHeight);
var leftTop = new PointF(0, leftTopSize);

var geometryPath = new GeometryPath();
geometryPath.MoveTo(topLeft);
geometryPath.LineTo(topRight);
geometryPath.ArcTo(rightTopSize, rightTopSize, 180, -90);
geometryPath.LineTo(rightBottom);
geometryPath.ArcTo(rightBottomSize, rightBottomSize, -90, -90);
geometryPath.LineTo(bottomLeft);
geometryPath.ArcTo(leftBottomSize, leftBottomSize, 0, -90);
geometryPath.LineTo(leftTop);
geometryPath.ArcTo(leftTopSize, leftTopSize, 90, -90);
geometryPath.CloseFigure();

var shape = slide.Shapes.AddAutoShape(ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);
shape.SetGeometryPath(geometryPath);

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Έλεγχος Εάν η Γεωμετρία Σχήματος Είναι Κλειστή**

Ο παρακάτω βοηθός ελέγχει εάν κάθε μη κενό μονοπάτι γεωμετρίας τελειώνει με τμήμα κλεισίματος. Διαβάζει το [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) και συγκρίνει την τελική εντολή του τμήματος [IPathSegment.PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/) με το [PathCommandType.Close](https://reference.aspose.com/slides/net/aspose.slides/pathcommandtype/). Επιστρέφει false όταν δεν υπάρχουν μη κενά μονοπάτια. Αυτό ελέγχει την τελική εντολή κάθε μονοπατιού· δεν επιθεωρεί κάθε υποσχήμα μέσα σε ένα μονοπάτι. Το παράδειγμα εμφανίζει `True` για ένα ορθογώνιο.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
Console.WriteLine(IsGeometryClosed(shape));

bool IsGeometryClosed(IGeometryShape geometryShape)
{
    var hasNonemptyPath = false;

    foreach (var geometryPath in geometryShape.GetGeometryPaths())
    {
        var segments = geometryPath.PathData;
        if (segments.Length == 0)
        {
            continue;
        }

        hasNonemptyPath = true;
        var lastSegment = segments[segments.Length - 1];
        if (lastSegment.PathCommand != PathCommandType.Close)
        {
            return false;
        }
    }

    return hasNonemptyPath;
}
```

## **Εξαγωγή και Επιθεώρηση Στοιχείων Σχήματος**

Χρησιμοποιήστε το [IGeometryShape.CreateShapeElements](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/createshapeelements/) για να επιθεωρήσετε ένα υπάρχον σχήμα ως στοιχεία που περιέχουν σημεία μονοπατιού και τύπους σημείων. Μετατρέψτε κάθε [IShapeElement](https://reference.aspose.com/slides/net/aspose.slides/ishapeelement/) σε [ShapeElement](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/) για να διαβάσετε τα arrays [PathPoints](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathpoints/) και [PathTypes](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathtypes/). Αυτή η αναπαράσταση είναι χρήσιμη για ανάλυση περιγράμματος ή για περάσμα γεωμετρίας σε προσαρμοσμένα εργαλεία σχεδίασης.

Το παράδειγμα ανοίγει μια παρουσίαση, βρίσκει το πρώτο σχήμα γεωμετρίας απευθείας στην πρώτη διαφάνεια και εκτυπώνει τα τμήματα του μονοπατιού του. Χρησιμοποιήστε μια παρουσίαση που περιέχει σχήμα με ευθείες και καμπυλωτές ενότητες για να δείτε και τις δύο μορφές εξόδου. Δεν αναζητά μέσα σε ομάδες.

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

var shape = slide.Shapes.OfType<IGeometryShape>().FirstOrDefault();
if (shape == null)
{
    Console.WriteLine("No geometry shape found on the first slide.");
    return;
}

foreach (IShapeElement element in shape.CreateShapeElements())
{
    var shapeElement = (ShapeElement)element;
    var points = shapeElement.PathPoints;
    var types = shapeElement.PathTypes;
    Console.WriteLine("Shape element:");

    for (var i = 0; i < points.Length; i++)
    {
        var pointType = types[i] & 0x07; // Διατηρήστε τον τύπο τμήματος, εξαιρώντας τις σημαίες.
        switch (pointType)
        {
            case 0:
                Console.WriteLine($"Start figure at {points[i]}");
                break;
            case 1:
                Console.WriteLine($"Line to {points[i]}");
                break;
            case 3:
                Console.WriteLine($"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}");
                i += 2; // Consume both control points and the endpoint.
                break;
        }

        if ((types[i] & 0x80) != 0)
        {
            Console.WriteLine("Close subpath back to its starting point.");
        }
    }
}
```

Οι πίνακες αντιστοιχούν κατά δείκτη: `points[i]` είναι ένα σημείο και `types[i]` περιγράφει τον ρόλο του. Ο τύπος `0` ξεκινά μια φιγούρα, και ο τύπος `1` σχεδιάζει γραμμή από το προηγούμενο σημείο στο τρέχον. Ένα τμήμα κύβικού Bézier ξεκινά από το προηγούμενο τελικό σημείο και χρησιμοποιεί τρεις διαδοχικές καταχωρήσεις τύπου `3`: δύο σημεία ελέγχου ακολουθούμενα από το νέο τελικό σημείο. Ο βρόχος καταναλώνει αυτές τις τρεις καταχωρήσεις μαζί και ελέγχει το τελικό σημείο για κλείσιμο.

Οι τύποι σημείων περιέχουν επίσης σημαίες. Κάντε mask με `0x07` για να προσδιορίσετε τον τύπο τμήματος και ελέγξτε το `0x80` ξεχωριστά για να ανιχνεύσετε κλειστό υπο-μονοπάτι. Για παράδειγμα, το `129` (`0x81`) σημαίνει τελικό σημείο γραμμής που κλείνει υπο-μονοπάτι, και το `131` (`0x83`) σημαίνει τελικό σημείο Bézier που κλείνει ένα. Η σύγκριση της ακατέργαστης τιμής μόνο με `1` ή `3` θα χάσει αυτές τις περιπτώσεις. Άλλες σημαίες, όπως η διακεκομμένη (`0x10`) και το σύμβολο (`0x20`), δεν αλλάζουν τον βασικό τύπο τμήματος.

**Συντεταγμένες και μετασχηματισμοί.** Τα σημεία μετρώνται σε points (1/72 ίντσα), με το X να αυξάνεται προς τα δεξιά και το Y προς τα κάτω. Για ένα μη ομαδοποιημένο σχήμα, οι εξαγόμενες συντεταγμένες περιλαμβάνουν ήδη τη θέση του [X](https://reference.aspose.com/slides/net/aspose.slides/shape/x/) και [Y](https://reference.aspose.com/slides/net/aspose.slides/shape/y/) και αντικατοπτρίζουν το τρέχον πλάτος και ύψος. Για παράδειγμα, ένα αχαλίνδωμα ορθογώνιο στο `(100, 200)` με μέγεθος `120 × 80` έχει όρια περιγράμματος `(100, 200)`–`(220, 280)`. Μην προσθέτετε ξανά τη θέση του σχήματος. Αφαιρέστε το X και Y του για να λάβετε συντεταγμένες σχετικές με το μη περιστραμμένο πλαίσιο του.

Οι εξαγόμενα σημεία δεν εφαρμόζουν την [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) ή τις οριζόντιες και κάθετες αναστροφές του σχήματος. Για να αναπαραγάγετε το εμφανιζόμενο περίγραμμα, εφαρμόστε αυτούς τους μετασχηματισμούς γύρω από το κέντρο του σχήματος. Για ομαδοποιημένα σχήματα, λάβετε επίσης υπόψη τη χαρτογράφηση συντεταγμένων της ομάδας και τους μετασχηματισμούς· μην υποθέτετε ότι τα εξαγόμενα σημεία είναι οι τελικές συντεταγμένες διαφάνειας ή ότι πρέπει να εφαρμόσετε μετάφραση ή κλίμακα δύο φορές αν ήδη αντανακλούνται στο πλαίσιο του παιδιού.

**Επιθεώρηση έναντι επεξεργασίας.** Οι εξαγόμενοι πίνακες περιγράφουν το περίγραμμα· η αλλαγή τους δεν ενημερώνει το αρχικό σχήμα. Επιλέξτε αυτή τη μέθοδο όταν η ανάλυση ή ο κώδικας σχεδίασης χρειάζονται πίνακες σημείων/τύπων. Χρησιμοποιήστε το [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) όταν χρειάζεστε εντολές γεωμετρίας στο τοπικό σύστημα συντεταγμένων του σχήματος ή θέλετε να επεξεργαστείτε τη γεωμετρία του. Εφαρμόστε επεξεργασμένα μονοπάτια μέσω του [SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) ή του [SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/).

## **Μετατροπή GeometryPath σε GraphicsPath (System.Drawing.Drawing2D)**

Το ακόλουθο παράδειγμα απαιτεί μια κληρονομική συναρμολόγηση Aspose.Slides for .NET που υποστηρίζει το [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/), όπως η έκδοση 25.10, και ένα περιβάλλον Windows με `System.Drawing.Common`. Οι μέθοδοι μετατροπής αφαιρέθηκαν στην [version 25.11](https://releases.aspose.com/slides/net/release-notes/2025/aspose-slides-for-net-25-11-release-notes/).

Αυτό το παράδειγμα συνδυάζει ένα ορθογώνιο περίγραμμα με κείμενο μετατρεπόμενο σε γεωμετρία. Η [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) του περιγράμματος ορίζεται ώστε να απενεργοποιεί το γέμισμα. Ένα [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) αποθηκεύει το περίγραμμα του κειμένου, το οποίο το [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) μετατρέπει σε γεμάτο μονοπάτι γεωμετρίας. Η εφαρμογή και των δύο μονοπατιών με το [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) παράγει ένα ενιαίο σχήμα που περιέχει το ορθογώνιο και το κείμενο. Για μετατροπή στην αντίθετη κατεύθυνση, χρησιμοποιήστε το [ShapeUtil.GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/).

```csharp
using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose.Slides;
using Aspose.Slides.Util;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

var originalPath = shape.GetGeometryPaths()[0];
originalPath.FillMode = PathFillModeType.None;

using var graphicsPath = new GraphicsPath();
using var fontFamily = new FontFamily("Arial");
using var stringFormat = StringFormat.GenericDefault;

graphicsPath.AddString("Text in shape", fontFamily, (int)FontStyle.Bold, 40, new PointF(10, 10), stringFormat);

var textPath = ShapeUtil.GraphicsPathToGeometryPath(graphicsPath);
textPath.FillMode = PathFillModeType.Normal;

shape.SetGeometryPaths(new[] { originalPath, textPath });
```
![example5_image](custom_shape_5.png)

## **Συχνές Ερωτήσεις**

**Τι θα συμβεί με το γέμισμα και το περίγραμμα μετά την αντικατάσταση της γεωμετρίας;**

Το στυλ παραμένει στο σχήμα· μόνο το περίγραμμα αλλάζει. Το γέμισμα και το περίγραμμα εφαρμόζονται αυτόματα στη νέα γεωμετρία.

**Πώς μπορώ να περιστρέψω σωστά ένα προσαρμοσμένο σχήμα μαζί με τη γεωμετρία του;**

Χρησιμοποιήστε την ιδιότητα [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) του σχήματος· η γεωμετρία περιστρέφεται μαζί με το σχήμα επειδή είναι δεσμευμένη στο δικό του σύστημα συντεταγμένων.

**Μπορώ να μετατρέψω ένα προσαρμοσμένο σχήμα σε εικόνα για να «κλειδώσω» το αποτέλεσμα;**

Ναι. Εξάγετε την απαιτούμενη περιοχή [slide](/slides/el/net/convert-powerpoint-to-png/) ή το [shape](/slides/el/net/create-shape-thumbnails/) σε μορφή raster· αυτό απλουστεύει την περαιτέρω εργασία με σύνθετες γεωμετρίες.