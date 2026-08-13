---
title: Προσθήκη υδατογραφημάτων σε παρουσιάσεις με C++
linktitle: Υδατογράφημα
type: docs
weight: 40
url: /el/cpp/watermark/
keywords:
- υδατογράφημα
- υδατογράφημα κειμένου
- υδατογράφημα εικόνας
- προσθήκη υδατογραφηματος σε PPT
- προσθήκη υδατογραφηματος σε PPTX
- προσθήκη υδατογραφηματος σε ODP
- αφαίρεση υδατογραφηματος από PPT
- αφαίρεση υδατογραφηματος από PPTX
- αφαίρεση υδατογραφηματος από ODP
- διαγραφή υδατογραφηματος από PPT
- διαγραφή υδατογραφηματος από PPTX
- διαγραφή υδατογραφηματος από ODP
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Διαχειριστείτε υδατογραφήματα κειμένου και εικόνας σε παρουσιάσεις PowerPoint και OpenDocument με C++ για να υποδείξετε ένα πρόχειρο, εμπιστευτικές πληροφορίες, πνευματικά δικαιώματα και άλλα."
---
## **Εισαγωγή**

**Ένα υδατογράφημα** σε μια παρουσίαση είναι σήμα κειμένου ή εικόνας που χρησιμοποιείται σε μια διαφάνεια ή σε όλες τις διαφάνειες της παρουσίασης. Συνήθως, ένα υδατογράφημα χρησιμοποιείται για να δείξει ότι η παρουσίαση είναι πρόχειρη (π.χ., υδατογράφημα «Πρόχειρο»), ότι περιέχει εμπιστευτικές πληροφορίες (π.χ., υδατογράφημα «Εμπιστευτικό»), για να προσδιορίσει σε ποια εταιρεία ανήκει (π.χ., υδατογράφημα «Όνομα Εταιρείας»), για να αναγνωρίσει τον συγγραφέα της παρουσίασης κ.λπ. Ένα υδατογράφημα βοηθά στην πρόληψη παραβίασης πνευματικών δικαιωμάτων, υποδεικνύοντας ότι η παρουσίαση δεν πρέπει να αντιγραφεί. Τα υδατογραφήματα χρησιμοποιούνται και στις μορφές παρουσίασης PowerPoint και OpenOffice. Στην Aspose.Slides, μπορείτε να προσθέσετε υδατογράφημα σε αρχεία PowerPoint PPT, PPTX και OpenOffice ODP.

Στην [**Aspose.Slides**](https://products.aspose.com/slides/el/cpp/), υπάρχουν διάφοροι τρόποι για να δημιουργήσετε υδατογράφημα σε έγγραφα PowerPoint ή OpenOffice και να τροποποιήσετε το σχεδιασμό και τη συμπεριφορά τους. Το κοινό σημείο είναι ότι για την προσθήκη κειμενικού υδατογραφηματος πρέπει να χρησιμοποιήσετε το περιβάλλον [ITextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/), ενώ για την προσθήκη εικόνας υδατογραφηματος, χρησιμοποιήστε την κλάση [PictureFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/pictureframe/) ή γεμίστε το σχήμα του υδατογραφηματος με εικόνα. Το `PictureFrame` υλοποιεί το περιβάλλον [IShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/) επιτρέποντάς σας να χρησιμοποιήσετε όλες τις ευέλικτες ρυθμίσεις του αντικειμένου σχήματος. Επειδή το `ITextFrame` δεν είναι σχήμα και οι ρυθμίσεις του είναι περιορισμένες, περιβάλλεται σε αντικείμενο [IShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/).

Υπάρχουν δύο τρόποι εφαρμογής ενός υδατογραφηματος: σε μία ενιαία διαφάνεια ή σε όλες τις διαφάνειες της παρουσίασης. Ο Δάσκαλος Διαφανειών (Slide Master) χρησιμοποιείται για να εφαρμόσει το υδατογράφημα σε όλες τις διαφάνειες — το υδατογράφημα προστίθεται στο Slide Master, σχεδιάζεται πλήρως εκεί, και εφαρμόζεται σε όλες τις διαφάνειες χωρίς να επηρεάζει την άδεια τροποποίησης του υδατογραφηματος σε μεμονωμένες διαφάνειες.

Ένα υδατογράφημα θεωρείται συνήθως μη επεξεργάσιμο από άλλους χρήστες. Για να αποτρέψετε την επεξεργασία του υδατογραφηματος (ή μάλλον του γονικού του σχήματος), η Aspose.Slides παρέχει λειτουργία κλειδώματος σχήματος. Ένα συγκεκριμένο σχήμα μπορεί να κλειδωθεί σε κανονική διαφάνεια ή σε Slide Master. Όταν το σχήμα του υδατογραφηματος κλειδωθεί στο Slide Master, κλειδώνεται σε όλες τις διαφάνειες της παρουσίασης.

Μπορείτε να ορίσετε ένα όνομα για το υδατογράφημα ώστε στο μέλλον, αν θέλετε να το διαγράψετε, να το βρείτε στις μορφές της διαφάνειας με βάση το όνομα.

Μπορείτε να σχεδιάσετε το υδατογράφημα με οποιονδήποτε τρόπο· ωστόσο, συνήθως υπάρχουν κοινά χαρακτηριστικά στα υδατογράφημα, όπως κεντρική στοίχιση, περιστροφή, θέση μπροστά κ.λπ. Θα εξετάσουμε πώς να τα χρησιμοποιήσετε στα παρακάτω παραδείγματα.

## **Υδατογράφημα Κειμένου**

### **Προσθήκη Υδατογραφηματος Κειμένου σε Διαφάνεια**

Για να προσθέσετε υδατογράφημα κειμένου σε PPT, PPTX ή ODP, μπορείτε πρώτα να προσθέσετε ένα σχήμα στη διαφάνεια, κατόπιν να προσθέσετε ένα πλαίσιο κειμένου σε αυτό το σχήμα. Το πλαίσιο κειμένου αντιπροσωπεύεται από το περιβάλλον [ITextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/). Αυτός ο τύπος δεν κληρονομεί από το [IShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/), που διαθέτει ευρύ σύνολο ιδιοτήτων για την ευέλικτη τοποθέτηση του υδατογραφηματος. Συνεπώς, το αντικείμενο [ITextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/) περιβάλλεται σε ένα αντικείμενο [IAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/). Για να προσθέσετε κείμενο υδατογραφηματος στο σχήμα, χρησιμοποιήστε τη μέθοδο [AddTextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/addtextframe/) όπως φαίνεται παρακάτω.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="info" title="Δείτε επίσης" %}} 
- [Πώς να χρησιμοποιήσετε την κλάση TextFrame](/slides/el/cpp/text-formatting/)
{{% /alert %}}

### **Προσθήκη Υδατογραφηματος Κειμένου σε Παρουσίαση**

Αν θέλετε να προσθέσετε υδατογράφημα κειμένου σε ολόκληρη την παρουσίαση (δηλαδή όλες τις διαφάνειες ταυτόχρονα), προσθέστε το στο [MasterSlide](https://reference.aspose.com/slides/el/cpp/aspose.slides/masterslide/). Το υπόλοιπο λογική είναι η ίδια όπως όταν προσθέτετε υδατογράφημα σε μία διαφάνεια — δημιουργήστε ένα αντικείμενο [IAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/) και στη συνέχεια προσθέστε το υδατογράφημα χρησιμοποιώντας τη μέθοδο [AddTextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/addtextframe/).

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);

auto watermarkShape = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="info" title="Δείτε επίσης" %}} 
- [Πώς να χρησιμοποιήσετε το Slide Master](/slides/el/cpp/slide-master/)
{{% /alert %}}

### **Ορισμός Διαφάνειας Σχήματος Υδατογραφηματος**

Από προεπιλογή, το σχήμα του ορθογωνίου μορφοποιείται με χρώματα γέμισης και γραμμής. Οι παρακάτω γραμμές κώδικα κάνουν το σχήμα διαυγές.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

watermarkShape->get_FillFormat()->set_FillType(FillType::NoFill);
watermarkShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
```

### **Ορισμός Γραμματοσειράς για Υδατογράφημα Κειμένου**

Μπορείτε να αλλάξετε τη γραμματοσειρά του υδατογραφηματος κειμένου όπως φαίνεται παρακάτω.

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(u"CONFIDENTIAL");

auto textFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat();
textFormat->set_LatinFont(MakeObject<FontData>(u"Arial"));
textFormat->set_FontHeight(50);
```

### **Ορισμός Χρώματος Κειμένου Υδατογραφηματος**

Για να ορίσετε το χρώμα του κειμένου του υδατογραφηματος, χρησιμοποιήστε τον ακόλουθο κώδικα:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(u"CONFIDENTIAL");

auto alpha = 150, red = 200, green = 200, blue = 200;

auto fillFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Solid);
fillFormat->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, red, green, blue));
```

### **Κεντράρισμα Υδατογραφηματος Κειμένου**

Είναι δυνατόν να κεντράρετε το υδατογράφημα σε μια διαφάνεια, και για αυτό μπορείτε να κάνετε το εξής:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto slideSize = presentation->get_SlideSize()->get_Size();

auto watermarkWidth = 400;
auto watermarkHeight = 40;
auto watermarkX = (slideSize.get_Width() - watermarkWidth) / 2;
auto watermarkY = (slideSize.get_Height() - watermarkHeight) / 2;

auto watermarkShape = slide->get_Shapes()->AddAutoShape(
    ShapeType::Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);
```

Η εικόνα παρακάτω δείχνει το τελικό αποτέλεσμα.

![Το υδατογράφημα κειμένου](text_watermark.png)

## **Υδατογράφημα Εικόνας**

### **Προσθήκη Υδατογραφηματος Εικόνας σε Παρουσίαση**

Για να προσθέσετε υδατογράφημα εικόνας σε διαφάνεια παρουσίασης, μπορείτε να ακολουθήσετε τα εξής:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

auto imageStream = File::ReadAllBytes(u"watermark.png");
auto image = presentation->get_Images()->AddImage(imageStream);

watermarkShape->get_FillFormat()->set_FillType(FillType::Picture);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
```

## **Κλείδωμα Υδατογραφηματος από Επεξεργασία**

Αν είναι απαραίτητο να αποτραπεί η επεξεργασία ενός υδατογραφηματος, χρησιμοποιήστε τη μέθοδο [IAutoShape::get_AutoShapeLock](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/get_autoshapelock/) στο σχήμα. Με αυτή την ιδιότητα, μπορείτε να προστατεύσετε το σχήμα από επιλογή, αλλαγή μεγέθους, επανατοποθέτηση, ομαδοποίηση με άλλα στοιχεία, κλείδωμα του κειμένου από επεξεργασία και πολλά άλλα:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IAutoShapeLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

// Κλείδωμα του σχήματος υδατογραφηματος από τροποποίηση
watermarkShape->get_AutoShapeLock()->set_SelectLocked(true);
watermarkShape->get_AutoShapeLock()->set_SizeLocked(true);
watermarkShape->get_AutoShapeLock()->set_TextLocked(true);
watermarkShape->get_AutoShapeLock()->set_PositionLocked(true);
watermarkShape->get_AutoShapeLock()->set_GroupingLocked(true);
```

## **Μεταφορά Υδατογραφηματος Μπροστά**

Στην Aspose.Slides, η σειρά Ζ (Z-order) των σχημάτων μπορεί να οριστεί μέσω της μεθόδου [IShapeCollection::Reorder](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishapecollection/reorder/). Για να το κάνετε αυτό, πρέπει να καλέσετε αυτή τη μέθοδο από τη λίστα διαφανειών της παρουσίασης και να περάσετε την αναφορά του σχήματος και τον αριθμό σειράς του στη μέθοδο. Με αυτόν τον τρόπο, είναι δυνατόν να φέρετε ένα σχήμα μπροστά ή να το στείλετε στο παρασκήνιο της διαφάνειας. Αυτή η δυνατότητα είναι ιδιαίτερα χρήσιμη εάν χρειάζεται να τοποθετήσετε το υδατογράφημα μπροστά από την παρουσίαση:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

auto shapeCount = slide->get_Shapes()->get_Count();
slide->get_Shapes()->Reorder(shapeCount - 1, watermarkShape);
```

## **Ορισμός Περιστροφής Υδατογραφηματος**

Ακολουθεί ένα παράδειγμα κώδικα για το πώς να ρυθμίσετε τη περιστροφή του υδατογραφηματος ώστε να τοποθετηθεί διαγώνια στην διαφάνεια:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/size_f.h>
#include <system/math.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto slideSize = presentation->get_SlideSize()->get_Size();

auto diagonalAngle = Math::Atan((slideSize.get_Height() / slideSize.get_Width())) * 180 / Math::PI;

watermarkShape->set_Rotation((float)diagonalAngle);
```

## **Ορισμός Ονόματος για Υδατογράφημα**

Η Aspose.Slides σας επιτρέπει να ορίσετε το όνομα ενός σχήματος. Χρησιμοποιώντας το όνομα του σχήματος, μπορείτε να το προσπελάσετε στο μέλλον για τροποποίηση ή διαγραφή. Για να ορίσετε το όνομα του σχήματος υδατογραφηματος, αναθέστε το στη μέθοδο [IAutoShape::set_Name](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/set_name/):

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

watermarkShape->set_Name(u"watermark");
```

## **Αφαίρεση Υδατογραφηματος**

Για να αφαιρέσετε το σχήμα υδατογραφηματος, χρησιμοποιήστε τη μέθοδο [IAutoShape::get_Name](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/get_name/) για να το βρείτε στα σχήματα της διαφάνειας. Στη συνέχεια, περάστε το σχήμα υδατογραφηματος στη μέθοδο [IShapeCollection::Remove](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishapecollection/remove/):

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation_with_watermark.pptx");
auto slide = presentation->get_Slide(0);

auto slideShapes = slide->get_Shapes()->ToArray();
for(auto shape : slideShapes)
{
    if (String::Compare(shape->get_Name(), u"watermark", StringComparison::Ordinal) == 0)
    {
        slide->get_Shapes()->Remove(shape);
    }
}
```

## **Ζωντανό Παράδειγμα**

Μπορείτε να δείτε τα δωρεάν εργαλεία online της **Aspose.Slides** [Add Watermark](https://products.aspose.app/slides/el/watermark) και [Remove Watermark](https://products.aspose.app/slides/el/watermark/remove-watermark).

![Online εργαλεία για προσθήκη και αφαίρεση υδατογραφημάτων](online_tools.png)

## **Συχνές Ερωτήσεις**

### Τι είναι ένα υδατογράφημα και γιατί πρέπει να το χρησιμοποιήσω;

Ένα υδατογράφημα είναι μια επικάλυψη κειμένου ή εικόνας που εφαρμόζεται σε διαφάνειες και βοηθά στην προστασία της πνευματικής ιδιοκτησίας, στην ενίσχυση της αναγνωρισιμότητας της μάρκας ή στην αποτροπή μη εξουσιοδοτημένης χρήσης των παρουσιάσεων.

### Μπορώ να προσθέσω υδατογράφημα σε όλες τις διαφάνειες μιας παρουσίασης;

Ναι, η Aspose.Slides σας επιτρέπει να προσθέσετε προγραμματιστικά υδατογράφημα σε κάθε διαφάνεια μιας παρουσίασης. Μπορείτε να διατρέξετε όλες τις διαφάνειες και να εφαρμόσετε τις ρυθμίσεις του υδατογραφηματος ξεχωριστά.

### Πώς μπορώ να ρυθμίσω τη διαφάνεια του υδατογραφηματος;

Μπορείτε να ρυθμίσετε τη διαφάνεια του υδατογραφηματος τροποποιώντας τις ρυθμίσεις γέμισης ([FillFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/shape/get_fillformat/)) του σχήματος. Αυτό εξασφαλίζει ότι το υδατογράφημα είναι διακριτικό και δεν αποσπά την προσοχή από το περιεχόμενο της διαφάνειας.

### Ποιες μορφές εικόνας υποστηρίζονται για υδατογραφήματα;

Η Aspose.Slides υποστηρίζει διάφορες μορφές εικόνας όπως PNG, JPEG, GIF, BMP, SVG και άλλες.

### Μπορώ να προσαρμόσω τη γραμματοσειρά και το στυλ ενός υδατογραφηματος κειμένου;

Ναι, μπορείτε να επιλέξετε οποιαδήποτε γραμματοσειρά, μέγεθος και στυλ ώστε να ταιριάζει στο σχεδιασμό της παρουσίασής σας και να διατηρεί τη συνοχή της μάρκας.

### Πώς αλλάζω τη θέση ή τον προσανατολισμό ενός υδατογραφηματος;

Μπορείτε να προσαρμόσετε τη θέση και τον προσανατολισμό του υδατογραφηματος προγραμματιστικά, τροποποιώντας τις συντεταγμένες, το μέγεθος και τις παραμέτρους περιστροφής του σχήματος.