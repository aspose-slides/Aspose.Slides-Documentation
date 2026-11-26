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
- διαδρομή γεωμετρίας
- σημεία διαδρομής
- σημεία επεξεργασίας
- προσθήκη σημείου
- αφαίρεση σημείου
- λειτουργία επεξεργασίας
- καμπυλωμένη γωνία
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε σχήματα σε παρουσιάσεις PowerPoint με το Aspose.Slides για .NET: διαδρομές γεωμετρίας, καμπυλωτές γωνίες, σύνθετα σχήματα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσαρμόσετε τα σχήματα παρουσίασης στο Aspose.Slides επεξεργαζόμενοι τη γεωμετρία του σχήματος μέσω σημείων επεξεργασίας και διαδρομών γεωμετρίας. Δείχνει πώς να εργαστείτε με [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) και [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) για να τροποποιήσετε υπάρχοντα σχήματα, να εκτελέσετε βασικές λειτουργίες επεξεργασίας διαδρομών, να προσθέσετε ή να αφαιρέσετε σημεία και να εφαρμόσετε την ενημερωμένη γεωμετρία πίσω σε ένα σχήμα.

Επίσης, παρουσιάζει πώς να δημιουργήσετε προσαρμοσμένα και σύνθετα σχήματα, να κατασκευάσετε σχήματα με καμπυλωμένες γωνίες, να καθορίσετε εάν μια γεωμετρία σχήματος είναι κλειστή και να χρησιμοποιήσετε τη παλαιά μετατροπή μεταξύ [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) και [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) για πρόσθετα σενάρια προσαρμογής γεωμετρίας.

## **Αλλαγή σχήματος χρησιμοποιώντας Σημεία Επεξεργασίας**

* Μετακινήστε μια γωνία προς το μέσα ή το έξω.
* Προσαρμόστε την καμπυλότητα σε ένα σημείο.
* Προσθέστε νέα σημεία.

Η επεξεργασία σημείων σας επιτρέπει να τροποποιήσετε το περιγράφημα ενός σχήματος ή να χρησιμοποιήσετε ένα υπάρχον σχήμα ως βάση για ένα νέο.

## **Συμβουλές επεξεργασίας σχήματος**

![overview_image](custom_shape_0.png)

Κατά την επεξεργασία σχημάτων PowerPoint, διατηρήστε αυτές τις έννοιες κατά νου:

* Ένα σχήμα (ή η διαδρομή του) μπορεί να είναι κλειστό ή ανοιχτό.
* Η διαδρομή ενός σχήματος αποτελείται από άγκυρες σημεία συνδεδεμένα με τμήματα.
* Ένα τμήμα μπορεί να είναι ευθύ ή καμπύλο. Τα άγκυρα σημεία και τα χειριστήρια ελέγχου καθορίζουν το σχήμα του.
* Τα άγκυρα σημεία υπάρχουν ως γωνιακά σημεία, ευθύγραμμα σημεία ή λείες (smooth) σημεία:
  * Σε ένα γωνιακό σημείο, τα παρακείμενα τμήματα μπορούν να συναντηθούν υπό γωνία.
  * Σε ένα λείο σημείο, τα δύο χειριστήρια ελέγχου είναι ευθυγραμμισμένα και ισαπέχουν από το άγκυρα σημείο.
  * Σε ένα ευθύγραμμο σημείο, τα δύο χειριστήρια ελέγχου είναι ευθυγραμμισμένα αλλά μπορούν να έχουν διαφορετικές αποστάσεις από το άγκυρα σημείο.
* Η μετακίνηση των άγκυρα σημείων ή η προσαρμογή των χειριστηρίων τους αλλάζει το περιγράφημα του σχήματος.

Για την επεξεργασία σχημάτων PowerPoint μέσω σημείων επεξεργασίας, το **Aspose.Slides** παρέχει την κλάση [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) και τη διεπαφή [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/).

* Μια παρουσίαση του [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) αντιπροσωπεύει μια διαδρομή γεωμετρίας του αντικειμένου [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/).
* Για την ανάκτηση του [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) από την παρουσίαση [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/), μπορείτε να χρησιμοποιήσετε τη μέθοδο [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/).
* Για τον ορισμό του [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) για ένα σχήμα, μπορείτε να χρησιμοποιήσετε τις μεθόδους: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) για σχήματα με μία μόνο διαδρομή και [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) για σχήματα με πολλαπλές διαδρομές.
* Για την προσθήκη τμημάτων, μπορείτε να χρησιμοποιήσετε τις μεθόδους του [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/).
* Χρησιμοποιώντας τις ιδιότητες [IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/stroke/) και [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/), μπορείτε να ορίσετε την εμφάνιση μιας διαδρομής γεωμετρίας.
* Χρησιμοποιώντας την ιδιότητα [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/), μπορείτε να ανακτήσετε τη διαδρομή γεωμετρίας ενός [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape/) ως πίνακα τμημάτων διαδρομής.
* Σε παλαιές εκδόσεις που υποστηρίζουν τις παρακάτω μεθόδους μετατροπής, μπορείτε να μετατρέψετε το [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) σε [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath).
* Χρησιμοποιήστε τις μεθόδους [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/) και [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) (Από την κλάση [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/)) για να μετατρέψετε μεταξύ [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) και [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath).

## **Απλές λειτουργίες επεξεργασίας**

Χρησιμοποιήστε τις παρακάτω μεθόδους για να επεξεργαστείτε μια διαδρομή γεωμετρίας. Οι υπερφορτώσεις που δέχονται δείκτη εισάγουν ένα τμήμα στη θέση μηδενικής βάσης στον πίνακα τμημάτων της διαδρομής.

| Λειτουργία | Μέθοδος |
| --- | --- |
| Προσθήκη ή εισαγωγή ευθείας γραμμής. | [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) |
| Προσθήκη ή εισαγωγή καμπύλης Bézier κυβικής με δύο σημεία ελέγχου και ένα σημείο λήξης. | [GeometryPath.CubicBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/cubicbezierto/) |
| Προσθήκη ή εισαγωγή τετραγωνικής Bézier καμπύλης με ένα σημείο ελέγχου και ένα σημείο λήξης. | [GeometryPath.QuadraticBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/quadraticbezierto/) |
| Προσθήκη ελλειπτικής τόξου με τις καθορισμένες διαστάσεις και γωνίες σε μοίρες. | [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) |
| Κλείσιμο του τρέχοντος σχήματος συνδέοντας το σημείο λήξης του με το σημείο έναρξης. | [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) |
| Ορισμός του σημείου έναρξης ενός σχήματος. | [GeometryPath.MoveTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/moveto/) |
| Αφαίρεση τμήματος σε δείκτη μηδενικής βάσης. | [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/) |

## **Προσθήκη προσαρμοσμένων σημείων σε σχήμα**

Αυτό το παράδειγμα εισάγει δύο σημεία σε ένα ορθογώνιο σχήμα χρησιμοποιώντας το [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) και εφαρμόζει τη μεταγλωττισμένη διαδρομή με το [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/). Οι συντεταγμένες είναι τοπικές στο σχήμα: και τα δύο νέα σημεία βρίσκονται στο κέντρο του, 100 σημεία από αριστερά και 50 σημεία από πάνω. Οι δείκτες τμημάτων 1 και 4 τα τοποθετούν στις πάνω και κάτω άκρες, τραβώντας αυτές τις άκρες προς τα μέσα.

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

## **Αφαίρεση σημείων από σχήμα**

Αυτό το παράδειγμα αλλάζει το περίγραμμα σχήματος καρδιάς αφαιρώντας το τμήμα στη μηδενική θέση δείκτη 2 με το [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/). Η εφαρμογή της τροποποιημένης διαδρομής με το [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) ενημερώνει το περίγραμμα του σχήματος.

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

## **Δημιουργία προσαρμοσμένου σχήματος**

Αυτό το παράδειγμα δημιουργεί ένα πεντάστημο αστέρι με τη χρήση του [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/). Εναλλασσόμενες εξωτερικές και εσωτερικές ακτίνες 100 και 50 σημεία ορίζουν τις άκρες και τις εσοχές· ένα βήμα 72 μοιρών τοποθετεί τις πέντε άκρα ομοιόμορφα. Η διαδρομή κλείνει με το [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) και εφαρμόζεται σε ένα ορθογώνιο σχήμα χρησιμοποιώντας το [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/), αντικαθιστώντας το περίγραμμά του.

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

## **Δημιουργία σύνθετου προσαρμοσμένου σχήματος**

Αυτό το παράδειγμα ορίζει δύο κλειστές αντικειμενικές [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) για το πάνω και το κάτω τρίτο ενός σχήματος. Η εφαρμογή και των δύο διαδρομών με το [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) δημιουργεί ένα ενιαίο σύνθετο σχήμα με ένα άνοιγμα κατά μήκος του μεσαίου τριτάτου.

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
bottomPath.MoveTo(0, shape.Height / 3 * 2);
bottomPath.LineTo(shape.Width, shape.Height / 3 * 2);
bottomPath.LineTo(shape.Width, shape.Height);
bottomPath.LineTo(0, shape.Height);
bottomPath.CloseFigure();

shape.SetGeometryPaths(new GeometryPath[] { topPath, bottomPath });
```
![example4_image](custom_shape_4.png)

## **Δημιουργία προσαρμοσμένου σχήματος με καμπύλες γωνίες**

Αυτό το παράδειγμα συνδυάζει ευθύγραμμα τμήματα με το [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) για να δημιουργήσει ένα σχήμα με εσωτερικά καμπυλωτές γωνίες. Το μέγεθος κάθε γωνίας ορίζει το πλάτος και το ύψος της τοξογραμμής σε σημεία, και η εκκίνηση -90 μοιρών σχεδιάζει ένα αντίστροφα φοράς ρολόι τέταρτο έλλειψα. Η ολοκληρωμένη διαδρομή εφαρμόζεται με το [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/), και η παρουσίαση αποθηκεύεται σε μορφή PPTX.

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
## **Εντοπισμός αν η γεωμετρία σχήματος είναι κλειστή**

Ο παρακάτω βοηθός ελέγχει αν κάθε μη κενή διαδρομή γεωμετρίας λήγει με τμήμα κλεισίματος. Διαβάζει το [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) και συγκρίνει την τελική εντολή του τμήματος [IPathSegment.PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/) με το [PathCommandType.Close](https://reference.aspose.com/slides/net/aspose.slides/pathcommandtype/). Επιστρέφει false όταν δεν υπάρχουν μη κενές διαδρομές. Αυτό ελέγχει την τελική εντολή κάθε διαδρομής· δεν εξετάζει κάθε υποσχήμα εντός της διαδρομής. Το παράδειγμα εκτυπώνει `True` για ένα ορθογώνιο.

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
## **Επιθεώρηση εντολών διαδρομής γεωμετρίας**

Κατεβάστε το [contour.pptx](contour.pptx) και τοποθετήστε το στον φάκελο εργασίας της εφαρμογής. Η πρώτη διαφάνεια περιέχει ένα σχήμα με άμεση άνω άκρη, μια καμπύλη Bézier κυβικής και μια άμεση άκρη κλεισίματος. Χρησιμοποιήστε το [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) για να διαβάσετε τις διαδρομές του. Κάθε διαδρομή παραθέτει τα τμήματά της με τη σειρά σχεδίασης στο [PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/). Η [PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/) κάθε τμήματος καθορίζει πώς να διαβάσετε το [SegmentData](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/segmentdata/).

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("contour.pptx");

var shape = (IGeometryShape)presentation.Slides[0].Shapes[0];
var paths = shape.GetGeometryPaths();

for (int i = 0; i < paths.Length; i++)
{
    var segments = paths[i].PathData;
    for (int j = 0; j < segments.Length; j++)
    {
        var command = segments[j].PathCommand;
        var data = segments[j].SegmentData;
        var detail = command switch
        {
            PathCommandType.MoveTo or PathCommandType.LineTo => $"destination=({data[0]}, {data[1]})",
            PathCommandType.CubicBezierTo => $"control1=({data[0]}, {data[1]}) control2=({data[2]}, {data[3]}) end=({data[4]}, {data[5]})",
            PathCommandType.Close => "no coordinates",
            _ => $"raw=[{string.Join(", ", data)}]"
        };
        Console.WriteLine($"Path {i}, segment {j}: {command} {detail}");
    }
}
```

Το σχήμα βρίσκεται στη θέση (200, 100) σημεία στη διαφάνεια. Τα αναφερόμενα σημεία είναι τοπικά στο σχήμα, με (0, 0) στην επάνω αριστερή γωνία του, το x να αυξάνεται προς τα δεξιά και το y προς τα κάτω. Το τμήμα κλεισίματος επιστρέφει στο αρχικό σημείο χωρίς επιπλέον συντεταγμένες.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```
![Σχήμα PowerPoint με άμεση άνω άκρη, κυρτή άκρη από την επάνω δεξιά προς την κάτω αριστερή, και άμεση αριστερή άκρη](contour.png)

## **Εξαγωγή και επιθεώρηση στοιχείων σχήματος**

Χρησιμοποιήστε το [IGeometryShape.CreateShapeElements](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/createshapeelements/) για να επιθεωρήσετε ένα υπάρχον σχήμα ως στοιχεία που περιέχουν σημεία διαδρομής και τύπους σημείων. Μετατρέψτε κάθε επιστρεφόμενο [IShapeElement](https://reference.aspose.com/slides/net/aspose.slides/ishapeelement/) σε [ShapeElement](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/) για να διαβάσετε τους πίνακες [PathPoints](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathpoints/) και [PathTypes](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathtypes/). Αυτή η αναπαράσταση είναι χρήσιμη για ανάλυση περιγραμμάτων ή για μετάδοση γεωμετρίας σε προσαρμοσμένα εργαλεία σχεδίασης.

Το παράδειγμα ανοίγει μια παρουσίαση, βρίσκει το πρώτο γεωμετρικό σχήμα απευθείας στην πρώτη διαφάνεια και εκτυπώνει τα τμήματα της διαδρομής του. Χρησιμοποιήστε μια παρουσίαση που περιέχει σχήμα με ευθεία και κυρτά τμήματα για να δείτε και τις δύο εξόδους. Δεν κάνει έρευνα εντός ομάδων.

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
        var pointType = types[i] & 0x07; // Διατήρηση του τύπου του τμήματος, εξαιρώντας τις σημαίες.
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
                i += 2; // Κατανάλωση και των δύο σημείων ελέγχου και του σημείου λήξης.
                break;
        }

        if ((types[i] & 0x80) != 0)
        {
            Console.WriteLine("Close subpath back to its starting point.");
        }
    }
}
```

Οι πίνακες αντιστοιχούν ανά δείκτη: `points[i]` είναι ένα σημείο και `types[i]` περιγράφει τον ρόλο του. Ο τύπος `0` ξεκινά ένα σχήμα, και ο τύπος `1` σχεδιάζει μια γραμμή από το προηγούμενο σημείο στο τρέχον. Ένα τμήμα Bézier κυβικής ξεκινά από το προηγούμενο σημείο λήξης και χρησιμοποιεί τρία διαδοχικά στοιχεία τύπου `3`: δύο σημεία ελέγχου ακολουθούμενα από το νέο σημείο λήξης. Ο βρόχος καταναλώνει αυτά τα τρία στοιχεία μαζί και ελέγχει το σημείο λήξης για κλείσιμο.

Οι τύποι σημείων περιέχουν επίσης σημαίες. Χρησιμοποιήστε τη μάσκα `0x07` για να προσδιορίσετε τον τύπο του τμήματος και δοκιμάστε το `0x80` ξεχωριστά για να εντοπίσετε ένα κλειστό υποδιαδρομή. Για παράδειγμα, το `129` (`0x81`) σημαίνει ένα άκρο γραμμής που κλείνει ένα υποδιαδρομή, και το `131` (`0x83`) σημαίνει ένα άκρο Bézier που κλείνει ένα τέτοιο. Η σύγκριση μόνο με τις τιμές `1` ή `3` θα χάσει αυτές τις περιπτώσεις. Άλλες σημαίες, όπως η παύλα (`0x10`) και ο δείκτης (`0x20`), δεν αλλάζουν τον βασικό τύπο του τμήματος.

**Συντεταγμένες και μετασχηματισμοί.** Τα σημεία μετρώνται σε points (1/72 ίντσα), με το X να αυξάνεται προς τα δεξιά και το Y προς τα κάτω. Για ένα μη ομαδοποιημένο σχήμα, οι εξαγόμενες συντεταγμένες περιλαμβάνουν ήδη τη θέση του [X](https://reference.aspose.com/slides/net/aspose.slides/shape/x/) και [Y](https://reference.aspose.com/slides/net/aspose.slides/shape/y/) και αντανακλούν το τρέχον πλάτος και ύψος του. Για παράδειγμα, ένα μη περιστρεφόμενο ορθογώνιο στο `(100, 200)` με μέγεθος `120 × 80` έχει όρια περιγράμματος `(100, 200)`–`(220, 280)`. Μην προσθέτετε ξανά τη θέση του σχήματος. Αφαιρέστε το X και Y του για να λάβετε συντεταγμένες σχετικά με το μη περιστρεφόμενο πλαίσιο του.

Τα εξαγόμενα σημεία δεν εφαρμόζουν την [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) του σχήματος ή τις οριζόντιες και κάθετες αντιστροφές. Για να αναπαραγάγετε το εμφανιζόμενο περίγραμμα, εφαρμόστε αυτούς τους μετασχηματισμούς γύρω από το κέντρο του σχήματος. Για ομαδοποιημένα σχήματα, λάβετε επίσης υπόψη τη χαρτογράφηση συντεταγμένων της ομάδας και τους μετασχηματισμούς· μην υποθέτετε ότι τα εξαγόμενα σημεία είναι οι τελικές συντεταγμένες της διαφάνειας ή εφαρμόστε μια μετάφραση ή κλίμακα δύο φορές εάν ήδη αντικατοπτρίζονται στο πλαίσιο του παιδιού.

**Επιθεώρηση έναντι επεξεργασίας.** Οι εξαγόμενοι πίνακες περιγράφουν το περίγραμμα· η αλλαγή τους δεν ενημερώνει το αρχικό σχήμα. Επιλέξτε αυτήν την προσέγγιση όταν η ανάλυση ή ο κώδικας σχεδίασης χρειάζεται πίνακες σημείου/τύπου. Χρησιμοποιήστε το [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) όταν χρειάζεστε εντολές γεωμετρίας στο τοπικό σύστημα συντεταγμένων του σχήματος ή θέλετε να επεξεργαστείτε τη γεωμετρία του. Εφαρμόστε τις επεξεργασμένες διαδρομές μέσω του [SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) ή του [SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/).

## **Μετατροπή GeometryPath σε GraphicsPath (System.Drawing.Drawing2D)**

Το παρακάτω παράδειγμα απαιτεί μια παλιά βιβλιοθήκη Aspose.Slides για .NET που υποστηρίζει το [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/), όπως η έκδοση 25.10, και ένα περιβάλλον Windows με `System.Drawing.Common`. Οι μέθοδοι μετατροπής αφαιρέθηκαν στην [version 25.11](https://releases.aspose.com/slides/net/release-notes/2025/aspose-slides-for-net-25-11-release-notes/).

Αυτό το παράδειγμα συνδυάζει ένα ορθογώνιο περίγραμμα με κείμενο μετατρεπόμενο σε γεωμετρία. Το [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) του περιγράμματος ορίζεται ώστε να απενεργοποιεί τη γέμιση. Ένα [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) αποθηκεύει το περίγραμμα του κειμένου, το οποίο το [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) μετατρέπει σε γεμάτη διαδρομή γεωμετρίας. Η εφαρμογή και των δύο διαδρομών με το [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) δημιουργεί ένα ενιαίο σχήμα που περιέχει το ορθογώνιο και το κείμενο. Για μετατροπή στην αντίθετη κατεύθυνση, χρησιμοποιήστε το [ShapeUtil.GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/).

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

## **Συχνές ερωτήσεις**

**Τι θα συμβεί στη γέμιση και το περίγραμμα μετά την αντικατάσταση της γεωμετρίας;**

Το στυλ παραμένει στο σχήμα· μόνο το περίγραμμα αλλάζει. Η γέμιση και το περίγραμμα εφαρμόζονται αυτόματα στη νέα γεωμετρία.

**Πώς να περιστρέψω σωστά ένα προσαρμοσμένο σχήμα μαζί με τη γεωμετρία του;**

Χρησιμοποιήστε την ιδιότητα [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) του σχήματος· η γεωμετρία περιστρέφεται με το σχήμα επειδή είναι δεσμευμένη στο δικό του σύστημα συντεταγμένων.

**Μπορώ να μετατρέψω ένα προσαρμοσμένο σχήμα σε εικόνα για να “κλειδώσω” το αποτέλεσμα;**

Ναι. Εξάγετε την απαιτούμενη περιοχή [slide](/slides/el/net/convert-powerpoint-to-png/) ή το ίδιο το [shape](/slides/el/net/create-shape-thumbnails/) σε μορφή raster· αυτό απλοποιεί την περαιτέρω εργασία με σύνθετες γεωμετρίες.