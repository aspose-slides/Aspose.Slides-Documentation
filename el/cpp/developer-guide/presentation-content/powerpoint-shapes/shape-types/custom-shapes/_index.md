---
title: Προσαρμοσμός Σχημάτων Παρουσίασης σε C++
linktitle: Προσαρμοσμένο Σχήμα
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
description: "Δημιουργήστε και προσαρμόστε σχήματα σε παρουσιάσεις PowerPoint με το Aspose.Slides για C++: διαδρομές γεωμετρίας, καμπυλωτές γωνίες, σύνθετα σχήματα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσαρμόσετε τα σχήματα παρουσίασης στο Aspose.Slides επεξεργάζοντας τη γεωμετρία του σχήματος μέσω σημείων επεξεργασίας και διαδρομών γεωμετρίας. Δείχνει πώς να εργαστείτε με [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) και [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) για να τροποποιήσετε υπάρχοντα σχήματα, να εκτελέσετε βασικές λειτουργίες επεξεργασίας διαδρομής, να προσθέσετε ή να αφαιρέσετε σημεία, και να εφαρμόσετε την ενημερωμένη γεωμετρία πίσω σε ένα σχήμα.

Δείχνει επίσης πώς να δημιουργήσετε προσαρμοσμένα και σύνθετα σχήματα, να κατασκευάσετε σχήματα με καμπυλωτές γωνίες, και να καθορίσετε αν η γεωμετρία ενός σχήματος είναι κλειστή.

## **Αλλαγή Σχήματος Χρησιμοποιώντας Σημεία Επεξεργασίας**

Στο PowerPoint, μπορείτε να χρησιμοποιήσετε **Σημεία Επεξεργασίας** για να τροποποιήσετε ένα τετράγωνο:

* Μετακινήστε μια γωνία προς τα μέσα ή προς τα έξω.
* Ρυθμίστε την κυρτότητα σε ένα σημείο.
* Προσθέστε νέα σημεία.

Η επεξεργασία σημείων σας επιτρέπει να τροποποιήσετε το περίγραμμα ενός σχήματος ή να χρησιμοποιήσετε ένα υπάρχον σχήμα ως βάση για ένα νέο.

## **Συμβουλές Επεξεργασίας Σχήματος**

![overview_image](custom_shape_0.png)

Κατά την επεξεργασία σ shapes στο PowerPoint, διατηρήστε αυτά τα concepts στο μυαλό σας:

* Ένα σ shape (ή η διαδρομή του) μπορεί να είναι κλειστό ή ανοιχτό.
* Η διαδρομή ενός σ shape αποτελείται από σημεία αγκύρωσης (anchor points) συνδεδεμένα με τμήματα (segments).
* Ένα τμήμα μπορεί να είναι ευθείο ή καμπύλο. Τα σημεία αγκύρωσης και τα χειριστήρια ελέγχου (control handles) καθορίζουν το σχήμα του.
* Τα σημεία αγκύρωσης υπάρχουν ως σημεία γωνίας, ευθύγραμμα σημεία ή λείες (smooth) σημεία:
  * Σε σημείο γωνίας, τα υφιστάμενα τμήματα μπορούν να συναντηθούν με γωνία.
  * Σε λείο σημείο, τα δύο χειριστήρια ελέγχου είναι ευθυγραμμισμένα και εξίσου μακριά από το σημείο αγκύρωσης.
  * Σε ευθύγραμμο σημείο, τα δύο χειριστήρια ελέγχου είναι ευθυγραμμισμένα αλλά μπορεί να έχουν διαφορετικές αποστάσεις από το σημείο αγκύρωσης.
* Η μετακίνηση των σημείων αγκύρωσης ή η ρύθμιση των χειριστηρίων τους αλλάζει το περίγραμμα του σχήματος.

Για να επεξεργαστείτε σ shapes του PowerPoint μέσω σημείων επεξεργασίας, το **Aspose.Slides** παρέχει την κλάση [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) και τη διεπαφή [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/).

* Μια παρουσίαση του [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) αντιπροσωπεύει μια διαδρομή γεωμετρίας του αντικειμένου [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/).
* Για την ανάκτηση του [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) από την παρουσίαση του [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/), μπορείτε να χρησιμοποιήσετε τη μέθοδο [IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/).
* Για να ορίσετε το [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) για ένα σ shape, μπορείτε να χρησιμοποιήσετε αυτές τις μεθόδους: [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) για σ shapes με μία μόνο διαδρομή και [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) για σ shapes με πολλαπλές διαδρομές.
* Για να προσθέσετε τμήματα, μπορείτε να χρησιμοποιήσετε τις μεθόδους υπό το [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/).
* Χρησιμοποιώντας τις μεθόδους [IGeometryPath::set_Stroke](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_stroke/) και [IGeometryPath::set_FillMode](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_fillmode/), μπορείτε να ορίσετε την εμφάνιση μιας διαδρομής γεωμετρίας.
* Με τη μέθοδο [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/), μπορείτε να λάβετε τη διαδρομή γεωμετρίας ενός [GeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/geometryshape/) ως πίνακα τμημάτων διαδρομής.

## **Απλές Λειτουργίες Επεξεργασίας**

Χρησιμοποιήστε τις παρακάτω μεθόδους για να επεξεργαστείτε μια διαδρομή γεωμετρίας. Οι υπερφορτώσεις που δέχονται δείκτη (index) εισάγουν ένα τμήμα στη μηδενική θέση (zero‑based) του πίνακα τμημάτων της διαδρομής.

| Λειτουργία | Μέθοδος |
| --- | --- |
| Προσθήκη ή εισαγωγή ευθείου τμήματος. | [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) |
| Προσθήκη ή εισαγωγή κυρτίου Bézier καμπύλης κύβου με δύο σημεία ελέγχου και ένα σημείο τερματισμού. | [GeometryPath::CubicBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/cubicbezierto/) |
| Προσθήκη ή εισαγωγή τετραγωνικής Bézier καμπύλης με ένα σημείο ελέγχου και ένα σημείο τερματισμού. | [GeometryPath::QuadraticBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/quadraticbezierto/) |
| Προσθήκη ελλειπτικού τόξου με τις καθορισμένες διαστάσεις και γωνίες σε μοίρες. | [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) |
| Κλείσιμο του τρέχοντος σχήματος συνδέοντας το σημείο τερματισμού του με το αρχικό του σημείο. | [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) |
| Ορισμός του αρχικού σημείου ενός σχήματος. | [GeometryPath::MoveTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/moveto/) |
| Αφαίρεση τμήματος σε δείκτη μηδενικής βάσης. | [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/) |

## **Προσθήκη Προσαρμοσμένων Σημείων σε Σ Shape**

Αυτό το παράδειγμα εισάγει δύο σημεία σε ένα ορθογώνιο σ shape χρησιμοποιώντας [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) και εφαρμόζει τη μονωμένη διαδρομή με [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/). Οι συντεταγμένες είναι τοπικές στο σ shape: και τα δύο νέα σημεία βρίσκονται στο κέντρο του, 100 μονάδες από την αριστερά και 50 μονάδες από την κορυφή. Οι δείκτες τμημάτων 1 και 4 τα τοποθετούν στα άνω και κάτω άκρα, τραβώντας αυτά τα άκρα προς το εσωτερικό.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 200.0f, 100.0f);

auto geometryPath = shape->GetGeometryPaths()->idx_get(0);
geometryPath->LineTo(100.0f, 50.0f, 1);
geometryPath->LineTo(100.0f, 50.0f, 4);

shape->SetGeometryPath(geometryPath);
```

![example1_image](custom_shape_1.png)

## **Αφαίρεση Σημείων από Σ Shape**

Αυτό το παράδειγμα αλλάζει το περίγραμμα μιας καρδιάς αφαιρώντας το τμήμα με δείκτη μηδενικής βάσης 2 μέσω [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/). Η εφαρμογή της τροποποιημένης διαδρομής με [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) ενημερώνει το περίγραμμα του σ shape.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Heart, 100.0f, 100.0f, 300.0f, 300.0f);

auto path = shape->GetGeometryPaths()->idx_get(0);
path->RemoveAt(2);

shape->SetGeometryPath(path);
```
![example2_image](custom_shape_2.png)

## **Δημιουργία Προσαρμοσμένου Σ Shape**

Αυτό το παράδειγμα κατασκευάζει ένα πενταπλόσκοπο αστέρι με [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/). Εναλλασσόμενες εξωτερικές και εσωτερικές ακτίνες 100 και 50 μονάδες καθορίζουν τις άκρες και τις εσοχές· ένα βήμα 72 μοιρών διανέμει ίσα τα πέντε άκρα. Η διαδρομή κλείνει με το [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) και εφαρμόζεται σε ένα ορθογώνιο σ shape μέσω [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/), αντικαθιστώντας το περίγραμμά του.

```cpp
#include <DOM/GeometryPath.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/point_f.h>
#include <system/collections/list.h>
#include <system/math.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::Drawing;

auto points = System::MakeObject<List<PointF>>();

auto outerRadius = 100.0f;
auto innerRadius = 50.0f;
auto angleStep = 72;

for (auto angle = -90; angle < 270; angle += angleStep)
{
    auto radians = angle * (Math::PI / 180.f);
    auto x = outerRadius * Math::Cos(radians);
    auto y = outerRadius * Math::Sin(radians);
    points->Add(PointF((float)x + outerRadius, (float)y + outerRadius));

    radians = Math::PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math::Cos(radians);
    y = innerRadius * Math::Sin(radians);
    points->Add(PointF((float)x + outerRadius, (float)y + outerRadius));
}

auto starPath = System::MakeObject<GeometryPath>();
starPath->MoveTo(points->idx_get(0));

for (auto i = 1; i < points->get_Count(); i++)
{
    starPath->LineTo(points->idx_get(i));
}

starPath->CloseFigure();

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, outerRadius * 2, outerRadius * 2);
shape->SetGeometryPath(starPath);
```
![example3_image](custom_shape_3.png)

## **Δημιουργία Σύνθετου Προσαρμοσμένου Σ Shape**

Αυτό το παράδειγμα ορίζει δύο κλειστές διαδρομές [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) για το πάνω και το κάτω τρίτο ενός σ shape. Η εφαρμογή και των δύο διαδρομών με [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) δημιουργεί ένα ενιαίο σύνθετο σ shape με κενό στη μέση τρίτη περιοχή.

```cpp
#include <DOM/GeometryPath.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 200.0f, 100.0f);

auto topPath = System::MakeObject<GeometryPath>();
topPath->MoveTo(0.0f, 0.0f);
topPath->LineTo(shape->get_Width(), 0.0f);
topPath->LineTo(shape->get_Width(), shape->get_Height() / 3);
topPath->LineTo(0.0f, shape->get_Height() / 3);
topPath->CloseFigure();

auto bottomPath = System::MakeObject<GeometryPath>();
bottomPath->MoveTo(0.0f, shape->get_Height() / 3 * 2);
bottomPath->LineTo(shape->get_Width(), shape->get_Height() / 3 * 2);
bottomPath->LineTo(shape->get_Width(), shape->get_Height());
bottomPath->LineTo(0.0f, shape->get_Height());
bottomPath->CloseFigure();

auto paths = System::MakeArray<SharedPtr<IGeometryPath>>({ topPath, bottomPath });

shape->SetGeometryPaths(paths);
```
![example4_image](custom_shape_4.png)

## **Δημιουργία Προσαρμοσμένου Σ Shape με Καμπυλωτές Γωνίες**

Αυτό το παράδειγμα συνδυάζει ευθύγραμμα τμήματα με [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) για να δημιουργήσει σ shape με εσωτερικές καμπυλωτές γωνίες. Κάθε μέγεθος γωνίας ορίζει το πλάτος και το ύψος του τόξου σε μονάδες, και το σκέλος -90 μοιρών σχεδιάζει ένα αντίστροφα ρολόι τεταρτημόριο έλλειψης. Η τελική διαδρομή εφαρμόζεται με [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/), και η παρουσίαση αποθηκεύεται σε μορφή PPTX.

```cpp
#include <DOM/GeometryPath.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto shapeX = 20.f;
auto shapeY = 20.f;
auto shapeWidth = 300.f;
auto shapeHeight = 200.f;

auto leftTopSize = 50.f;
auto rightTopSize = 20.f;
auto rightBottomSize = 40.f;
auto leftBottomSize = 10.f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Custom, shapeX, shapeY, shapeWidth, shapeHeight);

auto topLeft = PointF(leftTopSize, 0.0f);
auto topRight = PointF(shapeWidth - rightTopSize, 0.0f);
auto rightBottom = PointF(shapeWidth, shapeHeight - rightBottomSize);
auto bottomLeft = PointF(leftBottomSize, shapeHeight);
auto leftTop = PointF(0.0f, leftTopSize);

auto geometryPath = System::MakeObject<GeometryPath>();
geometryPath->MoveTo(topLeft);
geometryPath->LineTo(topRight);
geometryPath->ArcTo(rightTopSize, rightTopSize, 180.0f, -90.0f);
geometryPath->LineTo(rightBottom);
geometryPath->ArcTo(rightBottomSize, rightBottomSize, -90.0f, -90.0f);
geometryPath->LineTo(bottomLeft);
geometryPath->ArcTo(leftBottomSize, leftBottomSize, 0.0f, -90.0f);
geometryPath->LineTo(leftTop);
geometryPath->ArcTo(leftTopSize, leftTopSize, 90.0f, -90.0f);
geometryPath->CloseFigure();

shape->SetGeometryPath(geometryPath);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Εντοπισμός Αν Το Geometry ενός Σ Shape Είναι Κλειστό**

Ο ακόλουθος βοηθός ελέγχει αν κάθε μη κενή διαδρομή γεωμετρίας λήγει με τμήμα κλεισίματος. Διαβάζει το [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) και συγκρίνει την τελική εντολή του τμήματος [IPathSegment::get_PathCommand](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_pathcommand/) με το [PathCommandType::Close](https://reference.aspose.com/slides/cpp/aspose.slides/pathcommandtype/). Επιστρέφει false όταν δεν υπάρχουν μη κενές διαδρομές. Ο έλεγχος αφορά την τελική εντολή κάθε διαδρομής· δεν εξετάζει κάθε υπο‑σχήμα μέσα στη διαδρομή. Το παράδειγμα εκτυπώνει `True` για ένα ορθογώνιο.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/ShapeType.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include <system/console.h>
#include <DOM/IPathSegment.h>
#include <DOM/PathCommandType.h>

using namespace Aspose::Slides;
using namespace System;

auto isGeometryClosed = [](SharedPtr<IGeometryShape> geometryShape)
{
    auto hasNonemptyPath = false;
    for (auto&& geometryPath : geometryShape->GetGeometryPaths())
    {
        auto segments = geometryPath->get_PathData();
        if (segments->get_Length() == 0)
        {
            continue;
        }

        hasNonemptyPath = true;
        auto lastSegment = segments->idx_get(segments->get_Length() - 1);
        if (lastSegment->get_PathCommand() != PathCommandType::Close)
        {
            return false;
        }
    }
    return hasNonemptyPath;
};

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
Console::WriteLine(isGeometryClosed(shape));
```

## **Επιθεώρηση Εντολών Διαδρομής Geometry**

Κατεβάστε το [contour.pptx](contour.pptx) και τοποθετήστε το στον κατάλογο εργασίας της εφαρμογής. Το πρώτο σ shape στην πρώτη διαφάνεια έχει μια ευθεία άνω άκρη, μια κυρτή Bézier καμπύλη, και μια ευθεία κλείσιμο άκρη. Χρησιμοποιήστε το [GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) για να διαβάσετε τις διαδρομές του. Για κάθε διαδρομή, το [get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) επιστρέφει τα τμήματα με σειρά σχεδίασης. Η εντολή που επιστρέφει το [get_PathCommand](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_pathcommand/) καθορίζει πώς να ερμηνευτούν οι τιμές που επιστρέφει το [get_SegmentData](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_segmentdata/).

```cpp
#include <DOM/IGeometryPath.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IPathSegment.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/PathCommandType.h>
#include <DOM/Presentation.h>
#include <system/array.h>
#include <system/console.h>
#include <system/enum.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"contour.pptx");

auto shape = ExplicitCast<IGeometryShape>(presentation->get_Slide(0)->get_Shape(0));
auto paths = shape->GetGeometryPaths();

for (auto i = 0; i < paths->get_Length(); ++i)
{
    auto segments = paths->idx_get(i)->get_PathData();
    for (auto j = 0; j < segments->get_Length(); ++j)
    {
        auto segment = segments->idx_get(j);
        auto command = segment->get_PathCommand();
        auto data = segment->get_SegmentData();
        String detail;
        switch (command)
        {
            case PathCommandType::MoveTo:
            case PathCommandType::LineTo:
                detail = String::Format(u"destination=({0}, {1})", data->idx_get(0), data->idx_get(1));
                break;
            case PathCommandType::CubicBezierTo:
                detail = String::Format(u"control1=({0}, {1}) control2=({2}, {3}) end=({4}, {5})", data);
                break;
            case PathCommandType::Close:
                detail = u"no coordinates";
                break;
            default:
            {
                auto values = MakeArray<String>(data->get_Length());
                for (auto k = 0; k < data->get_Length(); ++k)
                {
                    values->idx_set(k, String::Format(u"{0}", data->idx_get(k)));
                }
                detail = String::Format(u"raw=[{0}]", String::Join(u", ", values));
                break;
            }
        }
        Console::WriteLine(u"Path {0}, segment {1}: {2} {3}", i, j, Enum<PathCommandType>::GetName(command), detail);
    }
}
```

Το σ shape βρίσκεται στο (200, 100) μονάδες στη διαφάνεια. Τα σημεία που αναφέρονται είναι τοπικά στο σ shape, με το (0, 0) στην επάνω‑αριστερή γωνία, x αυξάνεται προς τα δεξιά, και y αυξάνεται προς τα κάτω. Το τμήμα κλεισίματος επιστρέφει στο αρχικό σημείο χωρίς επιπλέον συντεταγμένες.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **Εξαγωγή και Επιθεώρηση Στοιχείων Σ Shape**

Χρησιμοποιήστε το [IGeometryShape::CreateShapeElements](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/createshapeelements/) για να επιθεωρήσετε ένα υπάρχον σ shape ως στοιχεία που περιέχουν σημεία διαδρομής και τύπους σημείου. Μετατρέψτε κάθε [IShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/ishapeelement/) σε [ShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/) ώστε να διαβάσετε τους πίνακες που επιστρέφουν τα [get_PathPoints](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathpoints/) και [get_PathTypes](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathtypes/). Αυτή η αναπαράσταση είναι χρήσιμη για ανάλυση περιγραμμάτων ή για μεταβίβαση γεωμετρίας σε προσαρμοσμένα εργαλεία σχεδίασης.

Το παράδειγμα ανοίγει μια παρουσίαση, βρίσκει το πρώτο σ shape geometry απευθείας στην πρώτη διαφάνεια, και εκτυπώνει τα τμήματα της διαδρομής του. Χρησιμοποιήστε μια παρουσίαση που περιέχει σ shape με ευθείες και καμπυλωτές ακμές για να δείτε και τις δύο μορφές εξόδου. Δεν ψάχνει μέσα σε ομάδες.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/ShapeType.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include <system/console.h>
#include <DOM/IShapeElement.h>
#include <DOM/ShapeElement.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IGeometryShape> shape;
for (auto&& candidate : slide->get_Shapes())
{
    shape = AsCast<IGeometryShape>(candidate);
    if (shape != nullptr)
    {
        break;
    }
}
if (shape == nullptr)
{
    Console::WriteLine(u"No geometry shape found on the first slide.");
    return;
}

for (auto&& element : shape->CreateShapeElements())
{
    auto shapeElement = ExplicitCast<ShapeElement>(element);
    auto points = shapeElement->get_PathPoints();
    auto types = shapeElement->get_PathTypes();
    Console::WriteLine(u"Shape element:");

    for (auto i = 0; i < points->get_Length(); i++)
    {
        auto pointType = types[i] & 0x07; // Διατήρηση του τύπου τμήματος, εξαιρώντας τις σημαίες.
        switch (pointType)
        {
            case 0:
                Console::WriteLine(u"Start figure at {0}", points[i]);
                break;
            case 1:
                Console::WriteLine(u"Line to {0}", points[i]);
                break;
            case 3:
                Console::WriteLine(u"Cubic Bezier: controls {0}, {1}; end {2}", points[i], points[i + 1], points[i + 2]);
                i += 2; // Consume both control points and the endpoint.
                break;
        }
        if ((types[i] & 0x80) != 0)
        {
            Console::WriteLine(u"Close subpath back to its starting point.");
        }
    }
}
```

Οι πίνακες αντιστοιχούν ανά δείκτη: `points[i]` είναι ένα σημείο και `types[i]` περιγράφει τον ρόλο του. Ο τύπος `0` αρχίζει ένα σ figure, και ο τύπος `1` σχεδιάζει μια γραμμή από το προηγούμενο σημείο στο τρέχον σημείο. Ένα τμήμα κυρτής Bézier αρχίζει από το προηγούμενο τέλος και χρησιμοποιεί τρεις διαδοχικές καταχωρίσεις τύπου `3`: δύο σημεία ελέγχου ακολουθούμενα από το νέο σημείο τερματισμού. Ο βρόχος καταναλώνει αυτές τις τρεις εγγραφές μαζί και ελέγχει το σημείο τερματισμού για κλείσιμο.

Οι τύποι σημείων περιέχουν επίσης σημαίες. Μάσκα με `0x07` για να προσδιορίσετε τον τύπο τμήματος, και ελέγξτε το `0x80` ξεχωριστά για να εντοπίσετε κλειστό υπο‑μονοπάτι. Για παράδειγμα, `129` (`0x81`) σημαίνει σημείο άκρης γραμμής που κλείνει ένα υπο‑μονοπάτι, και `131` (`0x83`) σημαίνει σημείο άκρης Bézier που κλείνει ένα. Η σύγκριση της ωμής τιμής μόνο με `1` ή `3` θα χάσει αυτές τις περιπτώσεις. Άλλες σημαίες, όπως η παύλα (`0x10`) και ο δείκτης (`0x20`), δεν αλλάζουν τον βασικό τύπο τμήματος.

**Συντεταγμένες και μετασχηματισμοί.** Τα σημεία μετρώνται σε μονάδες (1/72 ίντσας), με X να αυξάνεται προς τα δεξιά και Y προς τα κάτω. Για ένα σ shape χωρίς ομαδοποίηση, οι εξαγόμενες συντεταγμένες περιλαμβάνουν ήδη τη θέση που επιστρέφει το [get_X](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_x/) και το [get_Y](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_y/) και αντανακλούν το τρέχον πλάτος και ύψος του. Π.χ., ένα μη περιστραμένο ορθογώνιο στο `(100, 200)` με μέγεθος `120 × 80` έχει όρια περιγράμματος `(100, 200)`–`(220, 280)`. Μην προσθέσετε ξανά τη θέση του σ shape. Αφαιρέστε το X και Y του για να αποκτήσετε συντεταγμένες σχετικές με το μη περιστραμένο πλαίσιο του.

Τα εξαγόμενα σημεία δεν εφαρμόζουν την περιστροφή που ορίζεται μέσω του [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) ή τις οριζόντιες και κάθετες αναστροφές. Για να αναπαράγετε το εμφανιζόμενο περίγραμμα, εφαρμόστε εκείνους τους μετασχηματισμούς γύρω από το κέντρο του σ shape. Για σ shapes σε ομάδες, λάβετε υπόψη τη χαρτογράφηση και τους μετασχηματισμούς συντεταγμένων της ομάδας· μην υποθέσετε ότι τα εξαγόμενα σημεία είναι οι τελικές συντεταγμένες της διαφάνειας ή ότι πρέπει να εφαρμόσετε ξανά μια μετάφραση ή κλίμακα αν ήδη περιλαμβάνονται στο πλαίσιο του παιδιού.

**Επιθεώρηση έναντι επεξεργασίας.** Οι εξαγόμενοι πίνακες περιγράφουν το περίγραμμα· η αλλαγή τους δεν ενημερώνει το αρχικό σ shape. Επιλέξτε αυτήν τη μέθοδο όταν η ανάλυση ή ο κώδικας σχεδίασης χρειάζεται πίνακες σημείου/τύπου. Χρησιμοποιήστε το [GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) όταν χρειάζεστε εντολές γεωμετρίας στο τοπικό σύστημα συντεταγμένων του σ shape ή θέλετε να επεξεργαστείτε τη γεωμετρία του. Εφαρμόστε τις επεξεργασμένες διαδρομές μέσω του [SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) ή του [SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/).

## **Μετατροπή GeometryPath σε GraphicsPath**

Το τρέχον δημόσιο API του Aspose.Slides για C++ δεν εκθέτει μετατροπές μεταξύ διαδρομών γεωμετρίας και διαδρομών γραφικών. Για την επιθεώρηση περιγράμματος, χρησιμοποιήστε στοιχεία σ shape όπως περιγράφηκε παραπάνω. Για την επεξεργασία σ shape, χρησιμοποιήστε διαδρομές γεωμετρίας και εφαρμόστε τις ενημερωμένες διαδρομές στο σ shape.

## **FAQ**

**Τι συμβαίνει στο γέμισμα και το περίγραμμα μετά την αντικατάσταση της γεωμετρίας;**

Το στυλ παραμένει στο σ shape· μόνο το περίγραμμα αλλάζει. Το γέμισμα και το περίγραμμα εφαρμόζονται αυτόματα στη νέα γεωμετρία.

**Πώς περιστρέφω σωστά ένα προσαρμοσμένο σ shape μαζί με τη γεωμετρία του;**

Χρησιμοποιήστε τη μέθοδο [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) του σ shape· η γεωμετρία περιστρέφεται μαζί με το σ shape επειδή είναι δεσμευμένη στο δικό του σύστημα συντεταγμένων.

**Μπορώ να μετατρέψω ένα προσαρμοσμένο σ shape σε εικόνα για να “κλειδώσω” το αποτέλεσμα;**

Ναι. Εξάγετε την απαιτούμενη περιοχή [slide](/slides/el/cpp/convert-powerpoint-to-png/) ή το ίδιο το [shape](/slides/el/cpp/shape-thumbnails/) σε μορφή raster· αυτό απλοποιεί περαιτέρω εργασία με πολύπλοκες γεωμετρίες.