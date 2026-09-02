---
title: Διαχείριση Συνδέσμων σε Παρουσιάσεις με C++
linktitle: Σύνδεσμος
type: docs
weight: 10
url: /el/cpp/connector/
keywords:
- σύνδεσμος
- τύπος συνδέσμου
- σημείο συνδέσμου
- γραμμή συνδέσμου
- γωνία συνδέσμου
- σημείο σύνδεσης
- σημείο προσαρμογής
- σύνδεση σχημάτων
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε, να προσαρτάτε, να επαναδρομολογείτε, να ρυθμίζετε και να εξετάζετε ευθείες, λυγισμένες και καμπυλωτές συνδέσμους PowerPoint με το Aspose.Slides για C++."
---
## **Επισκόπηση**

Ένας σύνδεσμος είναι μία γραμμή που μπορεί να παραμείνει προσαρτημένη σε δύο σχήματα όταν κάποιο από τα σχήματα μετακινείται. Τα άκρα του προσαρτώνται σε σημεία σύνδεσης, που απεικονίζονται με πράσινα σημεία στο PowerPoint. Ορισμένοι λυγισμένοι και καμπυλωτοί σύνδεσμοι εκθέτουν επίσης σημεία προσαρμογής, που απεικονίζονται με πορτοκαλί σημεία, και ελέγχουν τη θέση των επιμέρους τμημάτων του συνδέσμου.

Aspose.Slides αντιπροσωπεύει τους συνδέσμους μέσω της διεπαφής [IConnector](https://reference.aspose.com/slides/el/cpp/aspose.slides/iconnector/) . Μπορείτε να τους δημιουργήσετε, να προσαρτήσετε τα άκρα τους σε σχήματα, να επιλέξετε σημεία σύνδεσης, να τα επαναδρομολογήσετε και να τροποποιήσετε τη γεωμετρία των συνδέσμων που διαθέτουν σημεία προσαρμογής.

## **Τύποι Συνδέσμων**

Η απαρίθμηση [ShapeType](https://reference.aspose.com/slides/el/cpp/aspose.slides/shapetype/) περιλαμβάνει προεπιλογές ευθύ, λυγισμένου και καμπυλωτού συνδέσμου. Ο παρακάτω πίνακας δείχνει τις διαθέσιμες γεωμετρίες συνδέσμων και τον αριθμό σημείων προσαρμογής που ορίζονται από κάθε προεπιλογή.

| Συνδέτης | Image | Αριθμός σημείων προσαρμογής |
|---|---|---|
| `ShapeType::Line` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType::StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType::BentConnector2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType::BentConnector3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType::BentConnector4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType::BentConnector5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType::CurvedConnector2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType::CurvedConnector3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType::CurvedConnector4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType::CurvedConnector5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

Ο αριθμός και το νόημα των σημείων προσαρμογής αποτελούν μέρος της επιλεγμένης προεπιλογής συνδέσμου. Μην υποθέτετε ότι δύο διαφορετικοί τύποι συνδέσμου εκθέτουν την ίδια διάταξη συλλογής.

## **Συνδέστε Δύο Σχήματα**

Χρησιμοποιήστε [IShapeCollection::AddConnector](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishapecollection/addconnector/) για να προσθέσετε έναν σύνδεσμο και καλέστε [IConnector::set_StartShapeConnectedTo](https://reference.aspose.com/slides/el/cpp/aspose.slides/iconnector/set_startshapeconnectedto/) και [IConnector::set_EndShapeConnectedTo](https://reference.aspose.com/slides/el/cpp/aspose.slides/iconnector/set_endshapeconnectedto/) για να προσαρτήσετε τα άκρα του. Αφού προσαρτηθούν και τα δύο άκρα, το [IConnector::Reroute](https://reference.aspose.com/slides/el/cpp/aspose.slides/iconnector/reroute/) επιλέγει μια σύντομη διαδρομή μεταξύ των σχημάτων.

Το παρακάτω παράδειγμα συνδέει μια έλλειψη και ένα ορθογώνιο με έναν λυγισμένο σύνδεσμο:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IConnector.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

auto ellipse = shapes->AddAutoShape(ShapeType::Ellipse, 40, 80, 120, 80);
auto rectangle = shapes->AddAutoShape(ShapeType::Rectangle, 320, 240, 140, 80);
auto connector = shapes->AddConnector(ShapeType::BentConnector2, 0, 0, 10, 10);

connector->set_StartShapeConnectedTo(ellipse);
connector->set_EndShapeConnectedTo(rectangle);
connector->Reroute();

presentation->Save(u"connected-shapes.pptx", SaveFormat::Pptx);
```

{{% alert color="warning" title="Warning" %}}
Η κλήση του `IConnector::Reroute` μπορεί να αλλάξει τις τιμές των [IConnector::set_StartShapeConnectionSiteIndex](https://reference.aspose.com/slides/el/cpp/aspose.slides/iconnector/set_startshapeconnectionsiteindex/) και [IConnector::set_EndShapeConnectionSiteIndex](https://reference.aspose.com/slides/el/cpp/aspose.slides/iconnector/set_endshapeconnectionsiteindex/). Ορίστε συγκεκριμένα σημεία σύνδεσης μετά την επαναδρομολόγηση εάν αυτά τα σημεία πρέπει να παραμείνουν σταθερά.
{{% /alert %}}

## **Επιλέξτε Σημείο Σύνδεσης**

Κάθε συνδεδεμένο σχήμα αναφέρει τον αριθμό των σημείων του μέσω του [IShape::get_ConnectionSiteCount](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/get_connectionsitecount/). Επαληθεύστε έναν προτιμώμενο δείκτη μηδενικής βάσης πριν τον αναθέσετε σε άκρο συνδέσμου· οι αριθμοί σημείων διαφέρουν ανά γεωμετρία σχήματος.

Αυτό το παράδειγμα προσαρτά το σύνδεσμο σε ένα συγκεκριμένο σημείο της έλλειψης όταν αυτό το σημείο υπάρχει:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IConnector.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

auto ellipse = shapes->AddAutoShape(ShapeType::Ellipse, 40, 80, 120, 80);
auto rectangle = shapes->AddAutoShape(ShapeType::Rectangle, 320, 240, 140, 80);
auto connector = shapes->AddConnector(ShapeType::BentConnector3, 0, 0, 10, 10);

connector->set_StartShapeConnectedTo(ellipse);
connector->set_EndShapeConnectedTo(rectangle);

int32_t preferredSiteIndex = 2;
if (preferredSiteIndex < ellipse->get_ConnectionSiteCount())
{
    connector->set_StartShapeConnectionSiteIndex(preferredSiteIndex);
}
else
{
    Console::WriteLine(u"The ellipse has only {0} connection sites.", ellipse->get_ConnectionSiteCount());
}

presentation->Save(u"specific-connection-site.pptx", SaveFormat::Pptx);
```

## **Ρυθμίστε Σημείο Συνδέσμου**

Οι σύνδεσμοι με σημεία προσαρμογής τα εκθέτουν μέσω του [IGeometryShape::get_Adjustments](https://reference.aspose.com/slides/el/cpp/aspose.slides/igeometryshape/get_adjustments/). Εξετάστε κάθε [IAdjustValue](https://reference.aspose.com/slides/el/cpp/aspose.slides/iadjustvalue/) και ελέγξτε τον [IAdjustValue::get_Type](https://reference.aspose.com/slides/el/cpp/aspose.slides/iadjustvalue/get_type/) πριν αλλάξετε την [IAdjustValue::set_RawValue](https://reference.aspose.com/slides/el/cpp/aspose.slides/iadjustvalue/set_rawvalue/). Οι γενικοί κανόνες για την ταυτοποίηση προεπιλογών προσαρμογών σχήματος περιγράφονται στις [Shape Manipulation](/slides/el/cpp/shape-manipulations/).

Ο αριθμός, η σειρά, το νόημα και το έγκυρο εύρος τιμών των προσαρμογών συνδέσμου εξαρτώνται από την προεπιλογή του συνδέσμου. Ο τύπος που επιστρέφεται από `IAdjustValue::get_Type` είναι μόνο για ανάγνωση, ενώ η ακατέργαστη τιμή είναι εγγράψιμη. Η μέθοδος μόνο για ανάγνωση [IAdjustValue::get_Name](https://reference.aspose.com/slides/el/cpp/aspose.slides/iadjustvalue/get_name/) παρέχει πρόσθετη ταυτοποίηση όταν ένας σύνδεσμος περιέχει περισσότερες από μία προσαρμογές του ίδιου σημασιολογικού τύπου.

### **Διαδρομή Γύρω από Εμπόδιο**

Στην παρακάτω διάταξη, ένας σύνδεσμος `ShapeType::BentConnector5` μεταξύ δύο σχημάτων περνά από ένα τρίτο σχήμα:

![connector-obstruction](connector-obstruction.png)

Αυτός ο κώδικας δημιουργεί τον εμποδισμένο σύνδεσμο:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IConnector.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

shapes->AddAutoShape(ShapeType::Rectangle, 300, 150, 150, 75);
auto sourceShape = shapes->AddAutoShape(ShapeType::Rectangle, 500, 400, 100, 50);
auto targetShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 100, 70, 30);
auto connector = shapes->AddConnector(ShapeType::BentConnector5, 20, 20, 400, 300);

auto lineFormat = connector->get_LineFormat();
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
connector->set_StartShapeConnectedTo(sourceShape);
connector->set_EndShapeConnectedTo(targetShape);
connector->set_StartShapeConnectionSiteIndex(2);

presentation->Save(u"connector-obstruction.pptx", SaveFormat::Pptx);
```

Η μετακίνηση του κάθετου λυγισμού αλλάζει τη διαδρομή ώστε ο σύνδεσμος να παρακάμπτει το εμπόδιο:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Αντί να υποθέτετε ότι η θέση `1` στη συλλογή αντιπροσωπεύει πάντα τον κάθετο λυγισμό, το παράδειγμα αυτό ψάχνει για `ShapeAdjustmentType::ConnectorBendPositionY` και το αλλάζει μόνο όταν υπάρχει ο αναμενόμενος σημασιολογικός τύπος:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IConnector.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

shapes->AddAutoShape(ShapeType::Rectangle, 300, 150, 150, 75);
auto sourceShape = shapes->AddAutoShape(ShapeType::Rectangle, 500, 400, 100, 50);
auto targetShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 100, 70, 30);
auto connector = shapes->AddConnector(ShapeType::BentConnector5, 20, 20, 400, 300);

auto lineFormat = connector->get_LineFormat();
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
connector->set_StartShapeConnectedTo(sourceShape);
connector->set_EndShapeConnectedTo(targetShape);
connector->set_StartShapeConnectionSiteIndex(2);

SharedPtr<IAdjustValue> verticalBend;
auto adjustments = connector->get_Adjustments();
for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
{
    auto adjustment = adjustments->idx_get(adjustmentIndex);
    Console::WriteLine(u"{0}: type = {1}, raw value = {2}", adjustment->get_Name(), static_cast<int32_t>(adjustment->get_Type()), adjustment->get_RawValue());
    if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionY)
    {
        verticalBend = adjustment;
        break;
    }
}

if (verticalBend == nullptr)
{
    Console::WriteLine(u"The connector does not expose a vertical bend adjustment.");
}
else
{
    verticalBend->set_RawValue(60000);
    presentation->Save(u"connector-obstruction-fixed.pptx", SaveFormat::Pptx);
}
```

Ένας `ShapeType::BentConnector5` έχει δύο προσαρμογές `ShapeAdjustmentType::ConnectorBendPositionX` και μία `ShapeAdjustmentType::ConnectorBendPositionY`. Εάν ο τύπος που χρειάζεστε εμφανίζεται περισσότερες φορές, εξετάστε το `IAdjustValue::get_Name` και τη γνωστή γεωμετρία της προεπιλογής πριν επιλέξετε ένα. Εάν μια προσαρμογή επιστρέφει `ShapeAdjustmentType::Custom`, θεωρήστε ότι το νόημα και το εύρος της είναι ειδικά για την προεπιλογή και μην το αλλάξετε μέχρι να γνωρίζετε τη σύμβαση.

## **Συσχέτιση Τιμών Προσαρμογής με τη Γεωμετρία του Συνδέσμου**

Για λυγισμένους συνδέσμους, οι τιμές προσαρμογής μπορούν να χρησιμοποιηθούν για την εκτίμηση των θέσεων των επιμέρους τμημάτων. Αυτοί οι υπολογισμοί είναι ειδικοί για την προεπιλογή του συνδέσμου:

- Το `ShapeType::BentConnector4` συνήθως εκθέτει μία προσαρμογή `ShapeAdjustmentType::ConnectorBendPositionX` και μία `ShapeAdjustmentType::ConnectorBendPositionY`.
- Για αυτές τις θέσεις λυγισμού, η έκφραση `RawValue / 100000.0f` δίνει το κλάσμα του πλάτους ή του ύψους του πλαισίου του συνδέσμου που χρησιμοποιείται στα παραδείγματα παρακάτω.
- Ένα πλαίσιο συνδέσμου μπορεί να περιστραφεί ή να αντιστραφεί, επομένως οι συντεταγμένες του πλαισίου πρέπει να μετατραπούν πριν συγκριθούν με τις συντεταγμένες της διαφάνειας.

Τα παρακάτω παραδείγματα χρησιμοποιούν το `IAdjustValue::get_Type` για την αρχική ταυτοποίηση των προσαρμογών. Δεν θεωρούν τις θέσεις στη συλλογή ως φορατό αναγνωριστικό.

### **Μη Περιστρεφόμενος Σύνδεσμος**

Η αρχική διάταξη περιέχει δύο σχήματα κειμένου συνδεδεμένα με έναν `ShapeType::BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

Αυτό το παράδειγμα εξετάζει το σύνδεσμο και λαμβάνει τις οριζόντιες και κατακόρυφες προσαρμογές λυγισμού:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IConnector.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

auto sourceShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
sourceShape->get_TextFrame()->set_Text(u"From");
auto targetShape = shapes->AddAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
targetShape->get_TextFrame()->set_Text(u"To");
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20, 20, 400, 300);

auto lineFormat = connector->get_LineFormat();
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_Crimson());
lineFormat->set_Width(3);
connector->set_StartShapeConnectedTo(sourceShape);
connector->set_StartShapeConnectionSiteIndex(3);
connector->set_EndShapeConnectedTo(targetShape);
connector->set_EndShapeConnectionSiteIndex(2);

auto adjustments = connector->get_Adjustments();
for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
{
    auto adjustment = adjustments->idx_get(adjustmentIndex);
    Console::WriteLine(u"{0}: type = {1}, raw value = {2}", adjustment->get_Name(), static_cast<int32_t>(adjustment->get_Type()), adjustment->get_RawValue());
}
```

Για να αλλάξετε και τα δύο λυγίσματα, εντοπίστε κάθε αναμενόμενο τύπο και τροποποιήστε τις τιμές μόνο αφού βρεθούν και τα δύο:

```cpp
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IConnector.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

auto sourceShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
auto targetShape = shapes->AddAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
connector->set_StartShapeConnectedTo(sourceShape);
connector->set_StartShapeConnectionSiteIndex(3);
connector->set_EndShapeConnectedTo(targetShape);
connector->set_EndShapeConnectionSiteIndex(2);

SharedPtr<IAdjustValue> horizontalBend;
SharedPtr<IAdjustValue> verticalBend;
auto adjustments = connector->get_Adjustments();
for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
{
    auto adjustment = adjustments->idx_get(adjustmentIndex);
    if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend == nullptr || verticalBend == nullptr)
{
    Console::WriteLine(u"The connector does not expose the expected bend adjustments.");
}
else
{
    horizontalBend->set_RawValue(horizontalBend->get_RawValue() + 20000);
    verticalBend->set_RawValue(verticalBend->get_RawValue() + 200000);
    presentation->Save(u"connector-adjusted.pptx", SaveFormat::Pptx);
}
```

Το αποτέλεσμα είναι ένας σύνδεσμος των οποίων τα οριζόντια και κατακόρυφα τμήματα έχουν μετακινηθεί:

![connector-adjusted-1](connector-adjusted-1.png)

Μόλις γνωστοποιηθούν οι σημασιολογικοί τύποι, οι τιμές τους μπορούν να μετατραπούν σε συντεταγμένες πλαισίου συνδέσμου. Το παράδειγμα αυτό σχεδιάζει ένα λεπτό ορθογώνιο πάνω από το κάθετο τμήμα που ελέγχεται από τις δύο προσαρμογές λυγισμού:

```cpp
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IConnector.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

auto sourceShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
auto targetShape = shapes->AddAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
connector->set_StartShapeConnectedTo(sourceShape);
connector->set_StartShapeConnectionSiteIndex(3);
connector->set_EndShapeConnectedTo(targetShape);
connector->set_EndShapeConnectionSiteIndex(2);

SharedPtr<IAdjustValue> horizontalBend;
SharedPtr<IAdjustValue> verticalBend;
auto adjustments = connector->get_Adjustments();
for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
{
    auto adjustment = adjustments->idx_get(adjustmentIndex);
    if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend == nullptr || verticalBend == nullptr)
{
    Console::WriteLine(u"The connector does not expose the expected bend adjustments.");
}
else
{
    float x = connector->get_X() + connector->get_Width() * horizontalBend->get_RawValue() / 100000.0f;
    float y = connector->get_Y();
    float height = connector->get_Height() * verticalBend->get_RawValue() / 100000.0f;
    shapes->AddAutoShape(ShapeType::Rectangle, x, y, 1, height);
    presentation->Save(u"connector-segment-guide.pptx", SaveFormat::Pptx);
}
```

Το σχήμα οδηγού σηματοδοτεί το υπολογισμένο τμήμα:

![connector-adjusted-2](connector-adjusted-2.png)

### **Περιστρεφόμενος ή Αντεστραμμένος Σύνδεσμος**

Όταν η ίδια γεωμετρία συνδέσμου προσανατολίζεται κατακόρυφα, οι τιμές του [IShape::get_Frame](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/get_frame/), [IShapeFrame::get_FlipH](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishapeframe/get_fliph/) και [IShapeFrame::get_FlipV](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishapeframe/get_flipv/) επηρεάζουν τη μετατροπή από συντεταγμένες πλαισίου συνδέσμου σε συντεταγμένες διαφάνειας.

Αυτό το παράδειγμα δημιουργεί και ρυθμίζει τον κατακόρυφα προσανατολισμένο σύνδεσμο:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IConnector.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

auto sourceShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
sourceShape->get_TextFrame()->set_Text(u"From");
auto targetShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
targetShape->get_TextFrame()->set_Text(u"To 1");
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20, 20, 400, 300);

auto lineFormat = connector->get_LineFormat();
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_MediumAquamarine());
lineFormat->set_Width(3);
connector->set_StartShapeConnectedTo(sourceShape);
connector->set_StartShapeConnectionSiteIndex(2);
connector->set_EndShapeConnectedTo(targetShape);
connector->set_EndShapeConnectionSiteIndex(3);

auto adjustments = connector->get_Adjustments();
for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
{
    auto adjustment = adjustments->idx_get(adjustmentIndex);
    if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionX)
    {
        adjustment->set_RawValue(adjustment->get_RawValue() + 20000);
    }
    else if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionY)
    {
        adjustment->set_RawValue(adjustment->get_RawValue() + 200000);
    }
}

presentation->Save(u"vertical-connector-adjusted.pptx", SaveFormat::Pptx);
```

Ο προσαρμοσμένος σύνδεσμος εμφανίζεται κατακόρυφα μεταξύ των σχημάτων:

![connector-adjusted-3](connector-adjusted-3.png)

Για αυθαίρετη γωνία περιστροφής `alpha`, περιστρέψτε ένα σημείο πλαισίου συνδέσμου `(x, y)` γύρω από το κέντρο του πλαισίου `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Ο παρακάτω κώδικας χειρίζεται τον προσανατολισμό 90 μοιρών που χρησιμοποιείται σε αυτό το παράδειγμα και σχεδιάζει έναν κόκκινο οδηγό πάνω από το αντίστοιχο τμήμα του συνδέσμου:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IConnector.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IShapeFrame.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

auto sourceShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
auto targetShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
connector->set_StartShapeConnectedTo(sourceShape);
connector->set_StartShapeConnectionSiteIndex(2);
connector->set_EndShapeConnectedTo(targetShape);
connector->set_EndShapeConnectionSiteIndex(3);

SharedPtr<IAdjustValue> horizontalBend;
SharedPtr<IAdjustValue> verticalBend;
auto adjustments = connector->get_Adjustments();
for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
{
    auto adjustment = adjustments->idx_get(adjustmentIndex);
    if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend == nullptr || verticalBend == nullptr)
{
    Console::WriteLine(u"The connector does not expose the expected bend adjustments.");
}
else
{
    horizontalBend->set_RawValue(horizontalBend->get_RawValue() + 20000);
    verticalBend->set_RawValue(verticalBend->get_RawValue() + 200000);

    float x = connector->get_X();
    float y = connector->get_Y();
    auto frame = connector->get_Frame();
    if (frame->get_FlipH() == NullableBool::True)
    {
        x += connector->get_Width();
    }
    if (frame->get_FlipV() == NullableBool::True)
    {
        y += connector->get_Height();
    }

    x += connector->get_Width() * horizontalBend->get_RawValue() / 100000.0f;
    float rotatedX = frame->get_CenterX() - y + frame->get_CenterY();
    float rotatedY = x - frame->get_CenterX() + frame->get_CenterY();
    float segmentWidth = connector->get_Height() * verticalBend->get_RawValue() / 100000.0f;
    auto guide = shapes->AddAutoShape(ShapeType::Rectangle, rotatedX, rotatedY, segmentWidth, 1);
    auto guideLineFillFormat = guide->get_LineFormat()->get_FillFormat();
    guideLineFillFormat->set_FillType(FillType::Solid);
    guideLineFillFormat->get_SolidFillColor()->set_Color(Color::get_Red());

    presentation->Save(u"rotated-connector-segment-guide.pptx", SaveFormat::Pptx);
}
```

Ο κόκκινος οδηγός σηματοδοτεί το υπολογισμένο τμήμα μετά τον μετασχηματισμό των συντεταγμένων:

![connector-adjusted-4](connector-adjusted-4.png)

Αυτοί οι τύποι περιγράφουν τις προεπιλογές που χρησιμοποιούνται στα παραδείγματα, όχι ένα καθολικό μοντέλο συνδέσμου. Επαληθεύστε τους τύπους προσαρμογής, τον προσανατολισμό πλαισίου και τα εύρη τιμών πριν εφαρμόσετε τον ίδιο υπολογισμό σε διαφορετική προεπιλογή.

## **Βρείτε Γωνία Κατεύθυνσης Συνδέσμου**

Η κατεύθυνση ενός ευθύ συνδέσμου μπορεί να υπολογιστεί από το πλάτος και το ύψος του, με εφαρμοσμένες οριζόντιες και κατακόρυφες αντιστροφές. Το παρακάτω παράδειγμα αναφέρει τη γωνία δεξιόστροφα από τον θετικό οριζόντιο άξονα στις συντεταγμένες της διαφάνειας:

```cpp
#include <DOM/IConnector.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IShapeFrame.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/math.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto connector = slide->get_Shapes()->AddConnector(ShapeType::StraightConnector1, 100, 100, 200, 100);
auto frame = connector->get_Frame();

bool flipH = frame->get_FlipH() == NullableBool::True;
bool flipV = frame->get_FlipV() == NullableBool::True;
float deltaX = connector->get_Width() * (flipH ? -1 : 1);
float deltaY = connector->get_Height() * (flipV ? -1 : 1);
double angle = Math::Atan2(deltaY, deltaX) * 180.0 / Math::PI;

if (angle < 0)
{
    angle += 360;
}

Console::WriteLine(u"Connector direction: {0:F2} degrees", angle);
```

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να καταλάβω αν ένας σύνδεσμος μπορεί να προσαρτηθεί σε ένα σχήμα;**

Ελέγξτε την τιμή `IShape::get_ConnectionSiteCount` του σχήματος. Ένας θετικός αριθμός σημαίνει ότι το σχήμα εκθέτει σημεία σύνδεσης. Επαληθεύστε τον επιλεγμένο δείκτη σημείου πριν τον αναθέσετε σε άκρο συνδέσμου.

**Μπορώ να ταυτοποιήσω μια προσαρμογή συνδέσμου με το δείκτη της συλλογής;**

Ένας δείκτης έχει νόημα μόνο για μια γνωστή προεπιλογή συνδέσμου και τη διάταξη της συλλογής. Ελέγξτε το `IAdjustValue::get_Type` πριν τροποποιήσετε μια τιμή και χρησιμοποιήστε το `IAdjustValue::get_Name` ως πρόσθετη πληροφορία όταν ο ίδιος σημασιολογικός τύπος εμφανίζεται περισσότερες φορές.

**Τι συμβαίνει όταν ένα συνδεδεμένο σχήμα διαγραφεί;**

Το αντίστοιχο άκρο του συνδέσμου αποσυνδέεται. Ο σύνδεσμος παραμένει στη διαφάνεια και μπορεί να διαγραφεί, να τοποθετηθεί ως ελεύθερη γραμμή ή να προσαρτηθεί σε άλλο σχήμα.

**Διατηρούνται οι συνδέσεις όταν αντιγράψετε μια διαφάνεια;**

Οι συνδέσεις διατηρούνται γενικά όταν τα συνδεδεμένα σχήματα αντιγράφονται μαζί με τη διαφάνεια. Εάν ένας σύνδεσμος αντιγραφεί χωρίς ένα από τα σχήματα-στόχους, το επηρεασμένο άκρο πρέπει να προσαρτηθεί εκ νέου.