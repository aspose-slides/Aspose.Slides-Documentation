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
- καμπύλη γωνία
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε σχήματα σε παρουσιάσεις PowerPoint με Aspose.Slides για .NET: διαδρομές γεωμετρίας, καμπύλες γωνίες, σύνθετα σχήματα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσαρμόζετε τα σχήματα παρουσίασης στο Aspose.Slides επεξεργάζοντας τη γεωμετρία του σχήματος μέσω σημείων επεξεργασίας και διαδρομών γεωμετρίας. Δείχνει πώς να εργάζεστε με `GeometryPath` και `IGeometryPath` για να τροποποιήσετε υπάρχοντα σχήματα, να εκτελέσετε βασικές λειτουργίες επεξεργασίας διαδρομών, να προσθέσετε ή να αφαιρέσετε σημεία και να εφαρμόσετε την ενημερωμένη γεωμετρία πίσω σε ένα σχήμα.

Επίσης, παρουσιάζει πώς να δημιουργήσετε προσαρμοσμένα και σύνθετα σχήματα, να χτίσετε σχήματα με καμπύλες γωνίες, να καθορίσετε εάν μια γεωμετρία σχήματος είναι κλειστή και να μετατρέψετε μεταξύ `GeometryPath` και `GraphicsPath` για επιπλέον σενάρια προσαρμογής γεωμετρίας.

## **Αλλαγή σχήματος χρησιμοποιώντας σημεία επεξεργασίας**

Σκεφτείτε ένα τετράγωνο. Στο PowerPoint, χρησιμοποιώντας **σημεία επεξεργασίας**, μπορείτε
* μετακινήσετε την γωνία του τετραγώνου προς μέσα ή προς έξω
* ορίσετε την καμπυλότητα μιας γωνίας ή σημείου
* προσθέσετε νέα σημεία στο τετράγωνο
* να χειριστείτε τα σημεία στο τετράγωνο, κλπ.

Κατ' ουσίαν, μπορείτε να εκτελέσετε τις παραπάνω εργασίες σε οποιοδήποτε σχήμα. Χρησιμοποιώντας σημεία επεξεργασίας, μπορείτε να αλλάξετε ένα σχήμα ή να δημιουργήσετε νέο σχήμα από ένα υπάρχον σχήμα.

## **Συμβουλές επεξεργασίας σχήματος**

![overview_image](custom_shape_0.png)

Πριν ξεκινήσετε την επεξεργασία σχήματος PowerPoint μέσω σημείων επεξεργασίας, ίσως θέλετε να λάβετε υπόψη τα εξής σχετικά με τα σχήματα:
* Ένα σχήμα (ή η διαδρομή του) μπορεί να είναι είτε κλειστό είτε ανοικτό.
* Όλα τα σχήματα αποτελούνται από τουλάχιστον 2 άγκυρες σημείων που συνδέονται μεταξύ τους με γραμμές.
* Μια γραμμή είναι είτε ευθεία είτε καμπύλη. Τα άγκυρα σημεία καθορίζουν τη φύση της γραμμής.
* Τα άγκυρα σημεία υπάρχουν ως γωνιακά σημεία, ευθείες σημεία ή ομαλά σημεία:
  * Ένα γωνιακό σημείο είναι ένα σημείο όπου ενώνονται 2 ευθείες γραμμές σε γωνία.
  * Ένα ομαλό σημείο είναι ένα σημείο όπου υπάρχουν 2 λαβές σε μια ευθεία γραμμή και τα τμήματα της γραμμής ενώνονται σε ομαλή καμπύλη. Σε αυτή την περίπτωση, όλες οι λαβές είναι διαχωρισμένες από το άγκυρα σημείο με ίση απόσταση.
  * Ένα ευθύ σημείο είναι ένα σημείο όπου υπάρχουν 2 λαβές σε μια ευθεία γραμμή και τα τμήματα της γραμμής ενώνουν σε ομαλή καμπύλη. Σε αυτή την περίπτωση, οι λαβές δεν χρειάζεται να είναι διαχωρισμένες από το άγκυρα σημείο με ίση απόσταση.
* Με τη μετακίνηση ή την επεξεργασία των άγκυρων σημείων (που αλλάζουν τη γωνία των γραμμών), μπορείτε να αλλάξετε την εμφάνιση του σχήματος.

Για να επεξεργαστείτε σχήματα PowerPoint μέσω σημείων επεξεργασίας, το **Aspose.Slides** παρέχει την κλάση [**GeometryPath**](https://reference.aspose.com/slides/el/net/aspose.slides/geometrypath) και τη διεπαφή [**IGeometryPath**](https://reference.aspose.com/slides/el/net/aspose.slides/igeometrypath).

* Μια παρουσίαση του [GeometryPath](https://reference.aspose.com/slides/el/net/aspose.slides/geometrypath) αντιπροσωπεύει μια διαδρομή γεωμετρίας του αντικειμένου [IGeometryShape](https://reference.aspose.com/slides/el/net/aspose.slides/igeometryshape).
* Για να ανακτήσετε τη `GeometryPath` από την παρουσίαση `IGeometryShape`, μπορείτε να χρησιμοποιήσετε τη μέθοδο [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/el/net/aspose.slides/igeometryshape/methods/getgeometrypaths).
* Για να ορίσετε τη `GeometryPath` για ένα σχήμα, μπορείτε να χρησιμοποιήσετε τις ακόλουθες μεθόδους: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/el/net/aspose.slides/igeometryshape/methods/setgeometrypath) για *συμπαγή σχήματα* και [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/el/net/aspose.slides/igeometryshape/methods/setgeometrypaths) για *σύνθετα σχήματα*.
* Για να προσθέσετε τμήματα, μπορείτε να χρησιμοποιήσετε τις μεθόδους κάτω από το [IGeometryPath](https://reference.aspose.com/slides/el/net/aspose.slides/igeometrypath).
* Χρησιμοποιώντας τις ιδιότητες [IGeometryPath.Stroke](https://reference.aspose.com/slides/el/net/aspose.slides/igeometrypath/properties/stroke) και [IGeometryPath.FillMode](https://reference.aspose.com/slides/el/net/aspose.slides/igeometrypath/properties/fillmode), μπορείτε να ορίσετε την εμφάνιση μιας διαδρομής γεωμετρίας.
* Χρησιμοποιώντας την ιδιότητα [IGeometryPath.PathData](https://reference.aspose.com/slides/el/net/aspose.slides/igeometrypath/properties/pathdata), μπορείτε να ανακτήσετε τη διαδρομή γεωμετρίας ενός `GeometryShape` ως έναν πίνακα τμημάτων διαδρομής.
* Για να αποκτήσετε πρόσβαση σε επιπλέον επιλογές προσαρμογής γεωμετρίας σχήματος, μπορείτε να μετατρέψετε το [GeometryPath](https://reference.aspose.com/slides/el/net/aspose.slides/geometrypath) σε [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0).
* Χρησιμοποιήστε τις μεθόδους [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/el/net/aspose.slides.util/shapeutil/methods/geometrypathtographicspath) και [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/el/net/aspose.slides.util/shapeutil/methods/graphicspathtogeometrypath) (από την κλάση [ShapeUtil](https://reference.aspose.com/slides/el/net/aspose.slides.util/shapeutil)) για να μετατρέψετε το [GeometryPath](https://reference.aspose.com/slides/el/net/aspose.slides/geometrypath) σε [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) και αντίστροφα.

## **Απλές λειτουργίες επεξεργασίας**

Αυτός ο κώδικας C# δείχνει πώς να
**Προσθήκη γραμμής** στο τέλος μιας διαδρομής
``` csharp
void LineTo(PointF point);
void LineTo(float x, float y);
```
**Προσθήκη γραμμής** σε μια καθορισμένη θέση στη διαδρομή:
``` csharp    
void LineTo(PointF point, uint index);
void LineTo(float x, float y, uint index);
```
**Προσθήκη κυβικής καμπύλης Bezier** στο τέλος μιας διαδρομής:
``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**Προσθήκη κυβικής καμπύλης Bezier** στη καθορισμένη θέση στη διαδρομή:
``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint index);
```
**Προσθήκη τετραγωνικής καμπύλης Bezier** στο τέλος μιας διαδρομής:
``` csharp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```
**Προσθήκη τετραγωνικής καμπύλης Bezier** σε καθορισμένη θέση στη διαδρομή:
``` csharp
void QuadraticBezierTo(PointF point1, PointF point2, uint index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint index);
```
**Προσάρτηση δεδομένου τόξου** σε μια διαδρομή:
``` csharp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**Κλείσιμο του τρέχοντος σχήματος** της διαδρομής:
``` csharp
void CloseFigure();
```
**Ορισμός θέσης για το επόμενο σημείο**:
``` csharp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```
**Αφαίρεση τμήματος διαδρομής** σε συγκεκριμένο δείκτη:
``` csharp
void RemoveAt(int index);
```

## **Προσθήκη προσαρμοσμένων σημείων σε σχήμα**

1. Δημιουργήστε μια παρουσίαση της κλάσης [GeometryShape](https://reference.aspose.com/slides/el/net/aspose.slides/geometryshape) και ορίστε τον τύπο [ShapeType.Rectangle](https://reference.aspose.com/slides/el/net/aspose.slides/shapetype).
2. Αποκτήστε μια παρουσίαση της κλάσης [GeometryPath](https://reference.aspose.com/slides/el/net/aspose.slides/geometrypath) από το σχήμα.
3. Προσθέστε ένα νέο σημείο μεταξύ των δύο άνω σημείων στη διαδρομή.
4. Προσθέστε ένα νέο σημείο μεταξύ των δύο κάτω σημείων στη διαδρομή.
5. Εφαρμόστε τη διαδρομή στο σχήμα.

Αυτός ο κώδικας C# δείχνει πώς να προσθέσετε προσαρμοσμένα σημεία σε ένα σχήμα:
``` csharp
using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100) as GeometryShape;
    IGeometryPath geometryPath = shape.GetGeometryPaths()[0];

    geometryPath.LineTo(100, 50, 1);
    geometryPath.LineTo(100, 50, 4);
    shape.SetGeometryPath(geometryPath);
}
```

![example1_image](custom_shape_1.png)

## **Αφαίρεση σημείων από σχήμα**

1. Δημιουργήστε μια παρουσίαση της κλάσης [GeometryShape](https://reference.aspose.com/slides/el/net/aspose.slides/geometryshape) και ορίστε τον τύπο [ShapeType.Heart](https://reference.aspose.com/slides/el/net/aspose.slides/shapetype).
2. Αποκτήστε μια παρουσίαση της κλάσης [GeometryPath](https://reference.aspose.com/slides/el/net/aspose.slides/geometrypath) από το σχήμα.
3. Αφαιρέστε το τμήμα της διαδρομής.
4. Εφαρμόστε τη διαδρομή στο σχήμα.

Αυτός ο κώδικας C# δείχνει πώς να αφαιρέσετε σημεία από ένα σχήμα:
``` csharp
using (Presentation pres = new Presentation())
{
	GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Heart, 100, 100, 300, 300) as GeometryShape;

	IGeometryPath path = shape.GetGeometryPaths()[0];
	path.RemoveAt(2);
	shape.SetGeometryPath(path);
}
```

![example2_image](custom_shape_2.png)

## **Δημιουργία προσαρμοσμένου σχήματος**

1. Υπολογίστε τα σημεία για το σχήμα.
2. Δημιουργήστε μια παρουσίαση της κλάσης [GeometryPath](https://reference.aspose.com/slides/el/net/aspose.slides/geometrypath).
3. Γεμίστε τη διαδρομή με τα σημεία.
4. Δημιουργήστε μια παρουσίαση της κλάσης [GeometryShape](https://reference.aspose.com/slides/el/net/aspose.slides/geometryshape).
5. Εφαρμόστε τη διαδρομή στο σχήμα.

Αυτός ο κώδικας C# δείχνει πώς να δημιουργήσετε ένα προσαρμοσμένο σχήμα:
``` csharp
List<PointF> points = new List<PointF>();

float R = 100, r = 50;
int step = 72;

for (int angle = -90; angle < 270; angle += step)
{
    double radians = angle * (Math.PI / 180f);
    double x = R * Math.Cos(radians);
    double y = R * Math.Sin(radians);
    points.Add(new PointF((float)x + R, (float)y + R));

    radians = Math.PI * (angle + step / 2) / 180.0;
    x = r * Math.Cos(radians);
    y = r * Math.Sin(radians);
    points.Add(new PointF((float)x + R, (float)y + R));
}

GeometryPath starPath = new GeometryPath();
starPath.MoveTo(points[0]);

for (int i = 1; i < points.Count; i++)
{
    starPath.LineTo(points[i]);
}

starPath.CloseFigure();

using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, R * 2, R * 2) as GeometryShape;

    shape.SetGeometryPath(starPath);
}
```

![example3_image](custom_shape_3.png)

## **Δημιουργία σύνθετου προσαρμοσμένου σχήματος**

1. Δημιουργήστε μια παρουσίαση της κλάσης [GeometryShape](https://reference.aspose.com/slides/el/net/aspose.slides/geometryshape).
2. Δημιουργήστε την πρώτη παρουσίαση της κλάσης [GeometryPath](https://reference.aspose.com/slides/el/net/aspose.slides/geometrypath).
3. Δημιουργήστε τη δεύτερη παρουσίαση της κλάσης [GeometryPath](https://reference.aspose.com/slides/el/net/aspose.slides/geometrypath).
4. Εφαρμόστε τις διαδρομές στο σχήμα.

Αυτός ο κώδικας C# δείχνει πώς να δημιουργήσετε ένα σύνθετο προσαρμοσμένο σχήμα:
``` csharp
using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100) as GeometryShape;

    GeometryPath geometryPath0 = new GeometryPath();
    geometryPath0.MoveTo(0, 0);
    geometryPath0.LineTo(shape.Width, 0);
    geometryPath0.LineTo(shape.Width, shape.Height/3);
    geometryPath0.LineTo(0, shape.Height / 3);
    geometryPath0.CloseFigure();

    GeometryPath geometryPath1 = new GeometryPath();
    geometryPath1.MoveTo(0, shape.Height/3 * 2);
    geometryPath1.LineTo(shape.Width, shape.Height / 3 * 2);
    geometryPath1.LineTo(shape.Width, shape.Height);
    geometryPath1.LineTo(0, shape.Height);
    geometryPath1.CloseFigure();

    shape.SetGeometryPaths(new GeometryPath[] { geometryPath0, geometryPath1});
}
```

![example4_image](custom_shape_4.png)

## **Δημιουργία προσαρμοσμένου σχήματος με καμπύλες γωνίες**

Αυτός ο κώδικας C# δείχνει πώς να δημιουργήσετε ένα προσαρμοσμένο σχήμα με καμπύλες γωνίες (προς τα μέσα);
```c#
var shapeX = 20f;
var shapeY = 20f;
var shapeWidth = 300f;
var shapeHeight = 200f;

var leftTopSize = 50f;
var rightTopSize = 20f;
var rightBottomSize = 40f;
var leftBottomSize = 10f;

using (var presentation = new Presentation())
{
    var childShape = presentation.Slides[0].Shapes.AddAutoShape(
        ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    var geometryPath = new GeometryPath();

    var point1 = new PointF(leftTopSize, 0);
    var point2 = new PointF(shapeWidth - rightTopSize, 0);
    var point3 = new PointF(shapeWidth, shapeHeight - rightBottomSize);
    var point4 = new PointF(leftBottomSize, shapeHeight);
    var point5 = new PointF(0, leftTopSize);

    geometryPath.MoveTo(point1);
    geometryPath.LineTo(point2);
    geometryPath.ArcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.LineTo(point3);
    geometryPath.ArcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.LineTo(point4);
    geometryPath.ArcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.LineTo(point5);
    geometryPath.ArcTo(leftTopSize, leftTopSize, 90, -90);

    geometryPath.CloseFigure();

    childShape.SetGeometryPath(geometryPath);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Καθορισμός αν η γεωμετρία ενός σχήματος είναι κλειστή**

Ένα κλειστό σχήμα ορίζεται ως αυτό στο οποίο όλες οι πλευρές του συνδέονται, σχηματίζοντας ένα ενιαίο περίγραμμα χωρίς κενά. Ένα τέτοιο σχήμα μπορεί να είναι μια απλή γεωμετρική μορφή ή ένα σύνθετο προσαρμοσμένο περίγραμμα. Το παρακάτω παράδειγμα κώδικα δείχνει πώς να ελέγξετε αν η γεωμετρία ενός σχήματος είναι κλειστή:
```cs
bool IsGeometryClosed(IGeometryShape geometryShape)
{
    bool? isClosed = null;

    foreach (var geometryPath in geometryShape.GetGeometryPaths())
    {
        var dataLength = geometryPath.PathData.Length;
        if (dataLength == 0)
            continue;

        var lastSegment = geometryPath.PathData[dataLength - 1];
        isClosed = lastSegment.PathCommand == PathCommandType.Close;

        if (isClosed == false)
            return false;
    }
    
    return isClosed == true;
}
```

## **Μετατροπή GeometryPath σε GraphicsPath (System.Drawing.Drawing2D)**

1. Δημιουργήστε μια παρουσίαση της κλάσης [GeometryShape](https://reference.aspose.com/slides/el/net/aspose.slides/geometryshape).
2. Δημιουργήστε μια παρουσίαση της κλάσης [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) του namespace [System.Drawing.Drawing2D](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0).
3. Μετατρέψτε την παρουσίαση [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) σε παρουσίαση [GeometryPath](https://reference.aspose.com/slides/el/net/aspose.slides/geometrypath) χρησιμοποιώντας το [ShapeUtil](https://reference.aspose.com/slides/el/net/aspose.slides.util/shapeutil).
4. Εφαρμόστε τις διαδρομές στο σχήμα.

Αυτός ο κώδικας C#—μια υλοποίηση των παραπάνω βημάτων—δείχνει τη διαδικασία μετατροπής **GeometryPath** σε **GraphicsPath**:
``` csharp
using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 100) as GeometryShape;

    IGeometryPath originalPath = shape.GetGeometryPaths()[0];
    originalPath.FillMode = PathFillModeType.None;

    GraphicsPath gPath = new GraphicsPath();

    gPath.AddString("Text in shape", new FontFamily("Arial"), 1, 40, new PointF(10, 10), StringFormat.GenericDefault);

    IGeometryPath textPath = ShapeUtil.GraphicsPathToGeometryPath(gPath);
    textPath.FillMode = PathFillModeType.Normal;

    shape.SetGeometryPaths(new[] {originalPath, textPath}) ;
}
```

![example5_image](custom_shape_5.png)

## **FAQ**

**Τι θα συμβεί με το γέμισμα και το περίγραμμα μετά την αντικατάσταση της γεωμετρίας;**

Το στιλ παραμένει στο σχήμα· μόνο το περίγραμμα αλλάζει. Το γέμισμα και το περίγραμμα εφαρμόζονται αυτόματα στη νέα γεωμετρία.

**Πώς μπορώ να περιστρέψω σωστά ένα προσαρμοσμένο σχήμα μαζί με τη γεωμετρία του;**

Χρησιμοποιήστε την ιδιότητα [rotation](https://reference.aspose.com/slides/el/net/aspose.slides/shape/rotation/) του σχήματος· η γεωμετρία περιστρέφεται μαζί με το σχήμα επειδή είναι δεσμευμένη στο σύστημα συντεταγμένων του σχήματος.

**Μπορώ να μετατρέψω ένα προσαρμοσμένο σχήμα σε εικόνα για να "κλειδώσω" το αποτέλεσμα;**

Ναι. Εξάγετε την απαιτούμενη περιοχή της [διαφάνειας](/slides/el/net/convert-powerpoint-to-png/) ή του [σχήματος](/slides/el/net/create-shape-thumbnails/) σε μορφή raster· αυτό απλοποιεί την επεξεργασία πολύπλοκων γεωμετριών.