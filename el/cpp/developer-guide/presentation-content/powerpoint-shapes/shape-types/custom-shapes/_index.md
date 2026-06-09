---
title: "Προσαρμογή Σχημάτων Παρουσίασης σε C++"
linktitle: "Προσαρμοσμένο Σχήμα"
type: docs
weight: 20
url: /el/cpp/custom-shape/
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
- καμπυλωτή γωνία
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Δημιουργία και προσαρμογή σχημάτων σε παρουσιάσεις PowerPoint με Aspose.Slides για C++: διαδρομές γεωμετρίας, καμπυλωτές γωνίες, σύνθετα σχήματα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσαρμόζετε τα σχήματα παρουσίασης στο Aspose.Slides επεξεργάζοντας τη γεωμετρία του σχήματος μέσω σημείων επεξεργασίας και διαδρομών γεωμετρίας. Δείχνει πώς να εργάζεστε με `GeometryPath` και `IGeometryPath` για να τροποποιήσετε υπάρχοντα σχήματα, να εκτελέσετε βασικές λειτουργίες επεξεργασίας διαδρομής, να προσθέσετε ή να αφαιρέσετε σημεία και να εφαρμόσετε την ενημερωμένη γεωμετρία πίσω σε ένα σχήμα.

## **Αλλαγή σχήματος χρησιμοποιώντας σημεία επεξεργασίας**
Σκεφτείτε ένα τετράγωνο. Στο PowerPoint, χρησιμοποιώντας **edit points**, μπορείτε

* να μετακινήσετε τη γωνία του τετραγώνου προς μέσα ή προς έξω
* να ορίσετε την καμπυλότητα μιας γωνίας ή ενός σημείου
* να προσθέσετε νέα σημεία στο τετράγωνο
* να χειριστείτε τα σημεία στο τετράγωνο κ.λπ.

Βασικά, μπορείτε να εκτελέσετε τις περιγραφόμενες εργασίες σε οποιοδήποτε σχήμα. Χρησιμοποιώντας σημεία επεξεργασίας, μπορείτε να αλλάξετε ένα σχήμα ή να δημιουργήσετε ένα νέο σχήμα από ένα υπάρχον σχήμα.

## **Συμβουλές επεξεργασίας σχήματος**

![overview_image](custom_shape_0.png)

Πριν αρχίσετε να επεξεργάζεστε σχήματα PowerPoint μέσω σημείων επεξεργασίας, ίσως θελήσετε να λάβετε υπόψη τα παρακάτω στοιχεία σχετικά με τα σχήματα:

* Ένα σχήμα (ή η διαδρομή του) μπορεί να είναι είτε κλειστό είτε ανοιχτό.
* Όταν ένα σχήμα είναι κλειστό, δεν έχει αρχικό ή τελικό σημείο. Όταν ένα σχήμα είναι ανοιχτό, έχει ένα αρχικό και ένα τελικό σημείο. 
* Όλα τα σχήματα αποτελούνται από τουλάχιστον 2 σημεία αγκύρωσης που συνδέονται μεταξύ τους με γραμμές
* Μια γραμμή είναι είτε ευθεία είτε καμπυλωτή. Τα σημεία αγκύρωσης καθορίζουν τη φύση της γραμμής. 
* Τα σημεία αγκύρωσης υπάρχουν ως σημεία γωνίας, ευθείες σημεία ή λείες σημεία:
  * Ένα σημείο γωνίας είναι σημείο όπου 2 ευθείες γραμμές συναντιούνται σε γωνία. 
  * Ένα λείο σημείο είναι σημείο όπου 2 λαβές βρίσκονται σε ευθεία γραμμή και τα τμήματα της γραμμής ενώνονται σε λείο καμπύλο τόξο. Σε αυτήν την περίπτωση, όλες οι λαβές είναι χωρισμένες από το σημείο αγκύρωσης με ίση απόσταση. 
  * Ένα ευθύ σημείο είναι σημείο όπου 2 λαβές βρίσκονται σε ευθεία γραμμή και τα τμήματα της γραμμής ενώνονται σε λείο καμπύλο τόξο. Σε αυτήν την περίπτωση, οι λαβές δεν χρειάζεται να είναι χωρισμένες από το σημείο αγκύρωσης με ίση απόσταση. 
* Με τη μετακίνηση ή την επεξεργασία των σημείων αγκύρωσης (που αλλάζουν τη γωνία των γραμμών), μπορείτε να αλλάξετε την εμφάνιση ενός σχήματος. 

Για την επεξεργασία σχήματος PowerPoint μέσω σημείων επεξεργασίας, **Aspose.Slides** παρέχει την κλάση [**GeometryPath**](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.geometry_path) και το interface [**IGeometryPath**](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_geometry_path). 

* Μια παρουσία του [GeometryPath](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.geometry_path) αντιπροσωπεύει μια διαδρομή γεωμετρίας του αντικειμένου [IGeometryShape](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_geometry_shape). 
* Για να ανακτήσετε το `GeometryPath` από την παρουσία `IGeometryShape`, μπορείτε να χρησιμοποιήσετε τη μέθοδο [IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_geometry_shape#a91c25d805702d632c17db86ca3b279c1). 
* Για να ορίσετε το `GeometryPath` για ένα σχήμα, μπορείτε να χρησιμοποιήσετε αυτές τις μεθόδους: [IGeometryShape::SetGeometryPath()](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_geometry_shape#a350a80e5544519f5f840318f13ad7986) για *συμπαγή σχήματα* και [IGeometryShape::SetGeometryPaths()](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_geometry_shape#a4b3837a4e393693b3ceaa0928181b750) για *σύνθετα σχήματα*.
* Για να προσθέσετε τμήματα, μπορείτε να χρησιμοποιήσετε τις μεθόδους που ανήκουν στο [IGeometryPath](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_geometry_path). 
* Χρησιμοποιώντας τις μεθόδους [IGeometryPath::set_Stroke()](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_geometry_path#aa819370fbd22ef49387672b8fe2ed147) και [IGeometryPath::set_FillMode()](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_geometry_path#adf7a4e1a1a28b52a97bff0d5cad6f3d7), μπορείτε να ορίσετε την εμφάνιση μιας διαδρομής γεωμετρίας.
* Χρησιμοποιώντας τη μέθοδο [IGeometryPath::get_PathData()](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_geometry_path#a9b1e40e8db9d4dd95fa4784e95d73fca), μπορείτε να ανακτήσετε τη διαδρομή γεωμετρίας ενός `GeometryShape` ως έναν πίνακα τμημάτων διαδρομής. 
* Για πρόσβαση σε επιπλέον επιλογές προσαρμογής γεωμετρίας σχήματος, μπορείτε να μετατρέψετε το [GeometryPath](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.geometry_path) σε [GraphicsPath](https://reference.aspose.com/slides/el/cpp/class/system.drawing.drawing2_d.graphics_path)
* Χρησιμοποιήστε τις μεθόδους [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.util.shape_util#ab319f6b9578de90a4863c883690f7daf) και [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.util.shape_util#ab319f6b9578de90a4863c883690f7daf) (από την κλάση [ShapeUtil](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.util.shape_util)) για να μετατρέψετε το [GeometryPath](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.geometry_path) σε [GraphicsPath](https://reference.aspose.com/slides/el/cpp/class/system.drawing.drawing2_d.graphics_path) και αντίστροφα. 

## **Απλές λειτουργίες επεξεργασίας**

Αυτός ο κώδικας C++ δείχνει πώς να

**Προσθήκη γραμμής** στο τέλος μιας διαδρομής

``` cpp
void LineTo(PointF point);
void LineTo(float x, float y);
```
**Προσθήκη γραμμής** σε καθορισμένη θέση σε μια διαδρομή:

``` cpp    
void LineTo(PointF point, uint32_t index);
void LineTo(float x, float y, uint32_t index);
```
**Προσθήκη καμπύλης Bezier κυβικής** στο τέλος μιας διαδρομής:

``` cpp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**Προσθήκη καμπύλης Bezier κυβικής** στη συγκεκριμένη θέση σε μια διαδρομή:

``` cpp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint32_t index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint32_t index);
```
**Προσθήκη τετραγωνικής καμπύλης Bezier** στο τέλος μιας διαδρομής:

``` cpp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```
**Προσθήκη τετραγωνικής καμπύλης Bezier** σε καθορισμένη θέση σε μια διαδρομή:

``` cpp
void QuadraticBezierTo(PointF point1, PointF point2, uint32_t index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint32_t index);
```
**Προσάρτηση δεδομένου τόξου** σε μια διαδρομή:

``` cpp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**Κλείσιμο του τρέχοντος σχήματος** μιας διαδρομής:

``` cpp
void CloseFigure();
```
**Ορισμός θέσης για το επόμενο σημείο**:

``` cpp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```
**Αφαίρεση τμήματος διαδρομής** σε δεδομένο δείκτη:

``` cpp
void RemoveAt(int32_t index);
```

## **Προσθήκη προσαρμοσμένων σημείων σε σχήμα**
1. Δημιουργήστε μια παρουσία της κλάσης [GeometryShape](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.geometry_shape) και ορίστε τον τύπο [ShapeType.Rectangle](https://reference.aspose.com/slides/el/cpp/namespace/aspose.slides#abe1c0baea327186bde49ad44636bb8c5). 
2. Αποκτήστε μια παρουσία της κλάσης [GeometryPath](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.geometry_path) από το σχήμα. 
3. Προσθέστε ένα νέο σημείο μεταξύ των δύο άνω σημείων της διαδρομής. 
4. Προσθέστε ένα νέο σημείο μεταξύ των δύο κάτω σημείων της διαδρομής. 
5. Εφαρμόστε τη διαδρομή στο σχήμα.

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 200.0f, 100.0f));

SharedPtr<IGeometryPath> geometryPath = shape->GetGeometryPaths()->idx_get(0);

geometryPath->LineTo(100.0f, 50.0f, 1);
geometryPath->LineTo(100.0f, 50.0f, 4);
shape->SetGeometryPath(geometryPath);
```

![example1_image](custom_shape_1.png)

## **Αφαίρεση σημείων από σχήμα**

1. Δημιουργήστε μια παρουσία της κλάσης [GeometryShape](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.geometry_shape) και ορίστε τον τύπο [ShapeType.Heart](https://reference.aspose.com/slides/el/cpp/namespace/aspose.slides#abe1c0baea327186bde49ad44636bb8c5). 
2. Αποκτήστε μια παρουσία της κλάσης [GeometryPath](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.geometry_path) από το σχήμα. 
3. Αφαιρέστε το τμήμα της διαδρομής. 
4. Εφαρμόστε τη διαδρομή στο σχήμα.

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Heart, 100.0f, 100.0f, 300.0f, 300.0f));

SharedPtr<IGeometryPath> path = shape->GetGeometryPaths()->idx_get(0);
path->RemoveAt(2);
shape->SetGeometryPath(path);
```
![example2_image](custom_shape_2.png)

##  **Δημιουργία προσαρμοσμένου σχήματος**
1. Υπολογίστε τα σημεία για το σχήμα. 
2. Δημιουργήστε μια παρουσία της κλάσης [GeometryPath](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.geometry_path). 
3. Γεμίστε τη διαδρομή με τα σημεία. 
4. Δημιουργήστε μια παρουσία της κλάσης [GeometryShape](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.geometry_shape). 
5. Εφαρμόστε τη διαδρομή στο σχήμα.

``` cpp
SharedPtr<List<PointF>> points = System::MakeObject<List<PointF>>();

float R = 100.0f, r = 50.0f;
int32_t step = 72;

for (int32_t angle = -90; angle < 270; angle += step)
{
    double radians = angle * (Math::PI / 180.f);
    double x = outerRadius * Math::Cos(radians);
    double y = outerRadius * Math::Sin(radians);
    points->Add(PointF((float)x + outerRadius, (float)y + outerRadius));

    radians = Math::PI * (angle + step / 2) / 180.0;
    x = innerRadiusr * Math::Cos(radians);
    y = innerRadiusr * Math::Sin(radians);
    points->Add(PointF((float)x + outerRadius, (float)y + outerRadius));
}

SharedPtr<GeometryPath> starPath = System::MakeObject<GeometryPath>();
starPath->MoveTo(points->idx_get(0));

for (int32_t i = 1; i < points->get_Count(); i++)
{
    starPath->LineTo(points->idx_get(i));
}

starPath->CloseFigure();

SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, R * 2, R * 2));

shape->SetGeometryPath(starPath);
```
![example3_image](custom_shape_3.png)


## **Δημιουργία σύνθετου προσαρμοσμένου σχήματος**

  1. Δημιουργήστε μια παρουσία της κλάσης [GeometryShape](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.geometry_shape). 
  2. Δημιουργήστε την πρώτη παρουσία της κλάσης [GeometryPath](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.geometry_path). 
  3. Δημιουργήστε τη δεύτερη παρουσία της κλάσης [GeometryPath](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.geometry_path). 
  4. Εφαρμόστε τις διαδρομές στο σχήμα.

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 200.0f, 100.0f));

SharedPtr<IGeometryPath> geometryPath0 = System::MakeObject<GeometryPath>();
geometryPath0->MoveTo(0.0f, 0.0f);
geometryPath0->LineTo(shape->get_Width(), 0.0f);
geometryPath0->LineTo(shape->get_Width(), shape->get_Height() / 3);
geometryPath0->LineTo(0.0f, shape->get_Height() / 3);
geometryPath0->CloseFigure();

SharedPtr<IGeometryPath> geometryPath1 = System::MakeObject<GeometryPath>();
geometryPath1->MoveTo(0.0f, shape->get_Height() / 3 * 2);
geometryPath1->LineTo(shape->get_Width(), shape->get_Height() / 3 * 2);
geometryPath1->LineTo(shape->get_Width(), shape->get_Height());
geometryPath1->LineTo(0.0f, shape->get_Height());
geometryPath1->CloseFigure();

shape->SetGeometryPaths(System::MakeArray<SharedPtr<IGeometryPath>>({ geometryPath0, geometryPath1 }));
```
![example4_image](custom_shape_4.png)

## **Δημιουργία προσαρμοσμένου σχήματος με καμπυλωτές γωνίες**

Αυτός ο κώδικας C++ δείχνει πώς να δημιουργήσετε ένα προσαρμοσμένο σχήμα με καμπυλωτές γωνίες (προς τα μέσα);

```cpp
float shapeX = 20.f;
float shapeY = 20.f;
float shapeWidth = 300.f;
float shapeHeight = 200.f;

float leftTopSize = 50.f;
float rightTopSize = 20.f;
float rightBottomSize = 40.f;
float leftBottomSize = 10.f;

auto presentation = System::MakeObject<Presentation>();

auto childShape = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Custom, shapeX, shapeY, shapeWidth, shapeHeight);

auto geometryPath = System::MakeObject<GeometryPath>();

PointF point1(leftTopSize, 0.0f);
PointF point2(shapeWidth - rightTopSize, 0.0f);
PointF point3(shapeWidth, shapeHeight - rightBottomSize);
PointF point4(leftBottomSize, shapeHeight);
PointF point5(0.0f, leftTopSize);

geometryPath->MoveTo(point1);
geometryPath->LineTo(point2);
geometryPath->ArcTo(rightTopSize, rightTopSize, 180.0f, -90.0f);
geometryPath->LineTo(point3);
geometryPath->ArcTo(rightBottomSize, rightBottomSize, -90.0f, -90.0f);
geometryPath->LineTo(point4);
geometryPath->ArcTo(leftBottomSize, leftBottomSize, 0.0f, -90.0f);
geometryPath->LineTo(point5);
geometryPath->ArcTo(leftTopSize, leftTopSize, 90.0f, -90.0f);

geometryPath->CloseFigure();

childShape->SetGeometryPath(geometryPath);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Εντοπισμός αν η γεωμετρία σχήματος είναι κλειστή**

Ένα κλειστό σχήμα ορίζεται ως εκείνο του οποίου όλες οι πλευρές συνδέονται, σχηματίζοντας ένα ενιαίο σύνορο χωρίς κενά. Ένα τέτοιο σχήμα μπορεί να είναι μια απλή γεωμετρική μορφή ή μια σύνθετη προσαρμοσμένη περιγραφή. Το παρακάτω παράδειγμα κώδικα δείχνει πώς να ελέγξετε αν μια γεωμετρία σχήματος είναι κλειστή:

```cpp
bool IsGeometryClosed(SharedPtr<IGeometryShape> geometryShape)
{
    bool isClosed = false;

    for (auto&& geometryPath : geometryShape->GetGeometryPaths())
    {
        auto dataLength = geometryPath->get_PathData()->get_Length();
        if (dataLength == 0)
            continue;

        auto lastSegment = geometryPath->get_PathData()[dataLength - 1];
        isClosed = lastSegment->get_PathCommand() == PathCommandType::Close;

        if (!isClosed)
            return false;
    }

    return isClosed;
}
```

## **Μετατροπή GeometryPath σε GraphicsPath** 

1. Δημιουργήστε μια παρουσία της κλάσης [GeometryShape](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.geometry_shape). 
2. Δημιουργήστε μια παρουσία της κλάσης [GraphicsPath](https://reference.aspose.com/slides/el/cpp/class/system.drawing.drawing2_d.graphics_path) του ονόματος χώρου [System.Drawing.Drawing2D](https://reference.aspose.com/slides/el/cpp/namespace/system.drawing.drawing2_d). 
3. Μετατρέψτε την παρουσία του [GraphicsPath] σε παρουσία του [GeometryPath] χρησιμοποιώντας το [ShapeUtil](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.util.shape_util). 
4. Εφαρμόστε τις διαδρομές στο σχήμα.

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 100.0f));

SharedPtr<IGeometryPath> originalPath = shape->GetGeometryPaths()->idx_get(0);
originalPath->set_FillMode(PathFillModeType::None);

SharedPtr<Drawing2D::GraphicsPath> graphicsPath = System::MakeObject<Drawing2D::GraphicsPath>();
graphicsPath->AddString(u"Text in shape", System::MakeObject<FontFamily>(u"Arial"), 1, 40.0f, PointF(10.0f, 10.0f), StringFormat::get_GenericDefault());

SharedPtr<IGeometryPath> textPath = ShapeUtil::GraphicsPathToGeometryPath(graphicsPath);
textPath->set_FillMode(PathFillModeType::Normal);

shape->SetGeometryPaths(System::MakeArray<SharedPtr<IGeometryPath>>({ originalPath, textPath }));
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Τι θα συμβεί στο γέμισμα και το περίγραμμα μετά την αντικατάσταση της γεωμετρίας;**

Το στυλ παραμένει στο σχήμα· μόνο το περίγραμμα αλλάζει. Το γέμισμα και το περίγραμμα εφαρμόζονται αυτόματα στη νέα γεωμετρία.

**Πώς να περιστρέψω σωστά ένα προσαρμοσμένο σχήμα μαζί με τη γεωμετρία του;**

Χρησιμοποιήστε την ιδιότητα [rotation] του σχήματος· η γεωμετρία περιστρέφεται μαζί με το σχήμα επειδή είναι δεσμευμένη στο δικό του σύστημα συντεταγμένων.

**Μπορώ να μετατρέψω ένα προσαρμοσμένο σχήμα σε εικόνα για να «κλειδώσω» το αποτέλεσμα;**

Ναι. Εξαγάγετε την απαιτούμενη περιοχή [slide](/slides/el/cpp/convert-powerpoint-to-png/) ή το ίδιο το [shape](/slides/el/cpp/create-shape-thumbnails/) σε raster μορφή· αυτό απλοποιεί τη μετέπειτα εργασία με σύνθετες γεωμετρίες.