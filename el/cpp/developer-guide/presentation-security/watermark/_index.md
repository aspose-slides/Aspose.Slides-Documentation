---
title: "Προσθήκη υδατογραφημάτων σε παρουσιάσεις με C++"
linktitle: "Υδατογράφημα"
type: docs
weight: 40
url: /el/cpp/watermark/
keywords:
- υδατογράφημα
- υδατογράφημα κειμένου
- υδατογράφημα εικόνας
- πρόσθεση υδατογραφήματος
- αλλαγή υδατογράφηματος
- αφαίρεση υδατογράφηματος
- διαγραφή υδατογράφηματος
- πρόσθεση υδατογράφηματος σε PPT
- πρόσθεση υδατογράφηματος σε PPTX
- πρόσθεση υδατογράφηματος σε ODP
- αφαίρεση υδατογράφηματος από PPT
- αφαίρεση υδατογράφηματος από PPTX
- αφαίρεση υδατογράφηματος από ODP
- διαγραφή υδατογράφηματος από PPT
- διαγραφή υδατογράφηματος από PPTX
- διαγραφή υδατογράφηματος από ODP
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Διαχειριστείτε υδατογραφήματα κειμένου και εικόνας σε παρουσιάσεις PowerPoint και OpenDocument με C++ για να υποδείξετε πρόχειρη έκδοση, εμπιστευτικές πληροφορίες, πνευματικά δικαιώματα και άλλα."
---
## **Εισαγωγή**

**Ένα υδατογράφημα** σε μια παρουσίαση είναι μια σήμανση κειμένου ή εικόνας που χρησιμοποιείται σε μια διαφάνεια ή σε όλες τις διαφάνειες της παρουσίασης. Συνήθως, το υδατογράφημα χρησιμοποιείται για να υποδείξει ότι η παρουσίαση είναι πρόχειρη (π.χ., υδατογράφημα «Πρόχειρο»), ότι περιέχει εμπιστευτικές πληροφορίες (π.χ., υδατογράφημα «Εμπιστευτικό»), για να προσδιορίσει σε ποια εταιρεία ανήκει (π.χ., υδατογράφημα «Όνομα Εταιρείας»), για να ταυτοποιήσει τον συγγραφέα της παρουσίασης κ.λπ. Ένα υδατογράφημα βοηθά στην αποφυγή παραβίασης πνευματικών δικαιωμάτων, υποδεικνύοντας ότι η παρουσίαση δεν πρέπει να αντιγραφεί. Τα υδατογραφήματα χρησιμοποιούνται τόσο σε μορφές PowerPoint όσο και σε OpenOffice. Στο Aspose.Slides, μπορείτε να προσθέσετε υδατογράφημα σε αρχεία PowerPoint PPT, PPTX και OpenOffice ODP.

Στο [**Aspose.Slides**](https://products.aspose.com/slides/el/cpp/), υπάρχουν διάφοροι τρόποι για να δημιουργήσετε υδατογραφήματα σε έγγραφα PowerPoint ή OpenOffice και να τροποποιήσετε το σχεδιασμό και τη συμπεριφορά τους. Το κοινό σημείο είναι ότι για την προσθήκη υδατογραφημάτων κειμένου πρέπει να χρησιμοποιήσετε τη διεπαφή [ITextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/), ενώ για την προσθήκη υδατογραφημάτων εικόνας, τη κλάση [PictureFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/pictureframe/) ή να γεμίσετε ένα σχήμα υδατογραφήματος με εικόνα. Η `PictureFrame` υλοποιεί τη διεπαφή [IShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/), επιτρέποντάς σας να χρησιμοποιήσετε όλες τις ευέλικτες ρυθμίσεις του αντικειμένου σχήματος. Δεδομένου ότι το `ITextFrame` δεν είναι σχήμα και οι ρυθμίσεις του είναι περιορισμένες, τυλίγεται σε ένα αντικείμενο [IShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/).

Υπάρχουν δύο τρόποι εφαρμογής ενός υδατογραφήματος: σε μία διαφάνεια ή σε όλες τις διαφάνειες της παρουσίασης. Ο Slide Master χρησιμοποιείται για να εφαρμόσει υδατογράφημα σε όλες τις διαφάνειες — το υδατογράφημα προστίθεται στον Slide Master, σχεδιάζεται πλήρως εκεί και εφαρμόζεται σε όλες τις διαφάνειες χωρίς να επηρεάζει την άδεια τροποποίησης του υδατογραφήματος σε μεμονωμένες διαφάνειες.

Ένα υδατογράφημα θεωρείται συνήθως μη διαχειρίσιμο από άλλους χρήστες. Για να αποτραπεί η επεξεργασία του υδατογραφήματος (ή, καλύτερα, του γονικού του σχήματος), το Aspose.Slides παρέχει λειτουργία κλειδώματος σχήματος. Ένα συγκεκριμένο σχήμα μπορεί να κλειδωθεί σε κανονική διαφάνεια ή σε Slide Master. Όταν το σχήμα του υδατογραφήματος κλειδωθεί στο Slide Master, θα είναι κλειδωμένο σε όλες τις διαφάνειες της παρουσίασης.

Μπορείτε να ορίσετε ένα όνομα για το υδατογράφημα, ώστε στο μέλλον, αν θέλετε να το διαγράψετε, να το βρείτε στις διαφάνειες ανά όνομα.

Μπορείτε να σχεδιάσετε το υδατογράφημα με όποιον τρόπο θέλετε· όμως συνήθως υπάρχουν κοινά χαρακτηριστικά, όπως κεντρική στοίχιση, περιστροφή, θέση εμπρός κ.λπ. Θα εξετάσουμε πώς να τα χρησιμοποιήσετε στα παραδείγματα παρακάτω.

## **Υδατογράφημα κειμένου**

### **Προσθήκη υδατογραφήματος κειμένου σε διαφάνεια**

Για να προσθέσετε ένα υδατογράφημα κειμένου σε PPT, PPTX ή ODP, μπορείτε πρώτα να προσθέσετε ένα σχήμα στη διαφάνεια, μετά ένα πλαίσιο κειμένου σε αυτό το σχήμα. Το πλαίσιο κειμένου αντιπροσωπεύεται από τη διεπαφή [ITextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/). Αυτός ο τύπος δεν κληρονομεί από το [IShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/), το οποίο παρέχει ένα ευρύ σύνολο ιδιοτήτων για την ευέλικτη τοποθέτηση του υδατογραφήματος. Συνεπώς, το αντικείμενο [ITextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/) τυλίγεται σε ένα αντικείμενο [IAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/). Για να προσθέσετε κείμενο υδατογραφήματος στο σχήμα, χρησιμοποιήστε τη μέθοδο [AddTextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/addtextframe/) όπως φαίνεται παρακάτω.

```cpp
auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="primary" title="Δείτε επίσης" %}} 
- [Πώς να χρησιμοποιήσετε την κλάση TextFrame](/slides/el/cpp/text-formatting/)
{{% /alert %}}

### **Προσθήκη υδατογραφήματος κειμένου σε παρουσίαση**

Αν θέλετε να προσθέσετε υδατογράφημα κειμένου σε ολόκληρη την παρουσίαση (δηλαδή σε όλες τις διαφάνειες ταυτόχρονα), προσθέστε το στο [MasterSlide](https://reference.aspose.com/slides/el/cpp/aspose.slides/masterslide/). Η υπόλοιπη λογική είναι ίδια με αυτή της προσθήκης υδατογραφήματος σε μία διαφάνεια — δημιουργήστε ένα αντικείμενο [IAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/) και, στη συνέχεια, προσθέστε το υδατογράφημα χρησιμοποιώντας τη μέθοδο [AddTextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/addtextframe/).

```cpp
auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);

auto watermarkShape = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="primary" title="Δείτε επίσης" %}} 
- [Πώς να χρησιμοποιήσετε το Slide Master](/slides/el/cpp/slide-master/)
{{% /alert %}}

### **Ορισμός διαφάνειας σχήματος υδατογραφήματος**

Από προεπιλογή, το ορθογώνιο σχήμα μορφοποιείται με χρώματα γεμίσματος και περιγράμματος. Οι παρακάτω γραμμές κώδικα κάνουν το σχήμα διαφανές.

```cpp
watermarkShape->get_FillFormat()->set_FillType(FillType::NoFill);
watermarkShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
```

### **Ορισμός γραμματοσειράς για υδατογράφημα κειμένου**

Μπορείτε να αλλάξετε τη γραμματοσειρά του κειμένου υδατογραφήματος όπως φαίνεται παρακάτω.

```cpp
auto textFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat();
textFormat->set_LatinFont(MakeObject<FontData>(u"Arial"));
textFormat->set_FontHeight(50);
```

### **Ορισμός χρώματος κειμένου υδατογραφήματος**

Για να ορίσετε το χρώμα του κειμένου υδατογραφήματος, χρησιμοποιήστε αυτόν τον κώδικα:

```cpp
auto alpha = 150, red = 200, green = 200, blue = 200;

auto fillFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Solid);
fillFormat->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, red, green, blue));
```

### **Κεντράρισμα υδατογραφήματος κειμένου**

Είναι δυνατόν να κεντράρετε το υδατογράφημα σε μια διαφάνεια, και για αυτό μπορείτε να κάνετε τα εξής:

```cpp
auto slideSize = presentation->get_SlideSize()->get_Size();

auto watermarkWidth = 400;
auto watermarkHeight = 40;
auto watermarkX = (slideSize.get_Width() - watermarkWidth) / 2;
auto watermarkY = (slideSize.get_Height() - watermarkHeight) / 2;

auto watermarkShape = slide->get_Shapes()->AddAutoShape(
    ShapeType::Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);
```

Η παρακάτω εικόνα δείχνει το τελικό αποτέλεσμα.

![Το υδατογράφημα κειμένου](text_watermark.png)

## **Υδατογράφημα εικόνας**

### **Προσθήκη υδατογραφήματος εικόνας σε παρουσίαση**

Για να προσθέσετε υδατογράφημα εικόνας σε διαφάνεια παρουσίασης, μπορείτε να ακολουθήσετε τα εξής:

```cpp
auto imageStream = File::ReadAllBytes(u"watermark.png");
auto image = presentation->get_Images()->AddImage(imageStream);

watermarkShape->get_FillFormat()->set_FillType(FillType::Picture);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
```

## **Κλείδωμα υδατογράφηματος από επεξεργασία**

Αν χρειάζεται να αποτρέψετε την επεξεργασία ενός υδατογραφήματος, χρησιμοποιήστε τη μέθοδο [IAutoShape::get_AutoShapeLock](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/get_autoshapelock/) στο σχήμα. Με αυτήν την ιδιότητα, μπορείτε να προστατεύσετε το σχήμα από επιλογή, αλλαγή μεγέθους, μετακίνηση, ομαδοποίηση με άλλα στοιχεία, κλείδωμα του κειμένου του από επεξεργασία και πολλά άλλα:

```cpp
// Κλείδωμα του σχήματος υδατογραφήματος από τροποποίηση
watermarkShape->get_AutoShapeLock()->set_SelectLocked(true);
watermarkShape->get_AutoShapeLock()->SizeLocked(true);
watermarkShape->get_AutoShapeLock()->TextLocked(true);
watermarkShape->get_AutoShapeLock()->PositionLocked(true);
watermarkShape->get_AutoShapeLock()->GroupingLocked(true);
```

## **Μεταφορά υδατογράφηματος μπροστά**

Στο Aspose.Slides, η σειρά Z των σχημάτων μπορεί να οριστεί μέσω της μεθόδου [IShapeCollection::Reorder](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishapecollection/reorder/). Για να το κάνετε αυτό, πρέπει να καλέσετε τη μέθοδο από τη λίστα διαφανειών της παρουσίασης και να περάσετε την αναφορά του σχήματος καθώς και τον αριθμό σειράς του. Με αυτόν τον τρόπο, μπορείτε να φέρετε ένα σχήμα μπροστά ή να το στείλετε στο πίσω μέρος της διαφάνειας. Η δυνατότητα αυτή είναι ιδιαίτερα χρήσιμη όταν θέλετε να τοποθετήσετε ένα υδατογράφημα μπροστά από την παρουσίαση:

```cpp
auto shapeCount = slide->get_Shapes()->get_Count();
slide->get_Shapes()->Reorder(shapeCount - 1, watermarkShape);
```

## **Ρύθμιση περιστροφής υδατογράφηματος**

Ακολουθεί ένα παράδειγμα κώδικα για το πώς να ρυθμίσετε την περιστροφή του υδατογραφήματος ώστε να τοποθετηθεί διαγώνια στην διαφάνεια:

```cpp
auto diagonalAngle = Math::Atan((slideSize.get_Height() / slideSize.get_Width())) * 180 / Math::PI;

watermarkShape->set_Rotation((float)diagonalAngle);
```

## **Ορισμός ονόματος για υδατογράφημα**

Το Aspose.Slides σας επιτρέπει να ορίσετε το όνομα ενός σχήματος. Χρησιμοποιώντας το όνομα του σχήματος, μπορείτε μελλοντικά να το προσπελάσετε για τροποποίηση ή διαγραφή. Για να ορίσετε το όνομα του σχήματος υδατογραφήματος, αναθέστε το στη μέθοδο [IAutoShape::set_Name](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/set_name/):

```cpp
watermarkShape->set_Name(u"watermark");
```

## **Αφαίρεση υδατογράφηματος**

Για να αφαιρέσετε το σχήμα υδατογραφήματος, χρησιμοποιήστε τη μέθοδο [IAutoShape::get_Name](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/get_name/) ώστε να το βρείτε στα σχήματα της διαφάνειας. Στη συνέχεια, περάστε το σχήμα υδατογραφήματος στη μέθοδο [IShapeCollection::Remove](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishapecollection/remove/):

```cpp
auto slideShapes = slide->get_Shapes()->ToArray();
for(auto shape : slideShapes)
{
    if (String::Compare(shape->get_Name(), u"watermark", StringComparison::Ordinal) == 0)
    {
        slide->get_Shapes()->Remove(watermarkShape);
    }
}
```

## **Ζωντανό παράδειγμα**

Μπορείτε να δοκιμάσετε τα δωρεάν διαδικτυακά εργαλεία **Aspose.Slides** : [Add Watermark](https://products.aspose.app/slides/el/watermark) και [Remove Watermark](https://products.aspose.app/slides/el/watermark/remove-watermark).

![Διαδικτυακά εργαλεία για προσθήκη και αφαίρεση υδατογραφημάτων](online_tools.png)

## **Συχνές Ερωτήσεις**

**Τι είναι το υδατογράφημα και γιατί να το χρησιμοποιήσω;**

Το υδατογράφημα είναι μια επικάλυψη κειμένου ή εικόνας που εφαρμόζεται στις διαφάνειες και βοηθά στην προστασία της πνευματικής ιδιοκτησίας, στην ενίσχυση της αναγνωρισιμότητας της μάρκας ή στην αποτροπή μη εξουσιοδοτημένης χρήσης των παρουσιάσεων.

**Μπορώ να προσθέσω υδατογράφημα σε όλες τις διαφάνειες μιας παρουσίασης;**

Ναι, το Aspose.Slides επιτρέπει τον προγραμματισμό προσθήκης υδατογραφήματος σε κάθε διαφάνεια μιας παρουσίασης. Μπορείτε να επαναλάβετε τη διαδικασία για όλες τις διαφάνειες και να εφαρμόσετε τις ρυθμίσεις υδατογραφήματος ξεχωριστά.

**Πώς μπορώ να ρυθμίσω τη διαφάνεια του υδατογράφηματος;**

Μπορείτε να ρυθμίσετε τη διαφάνεια του υδατογράφηματος τροποποιώντας τις ρυθμίσεις γεμίσματος ([FillFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/shape/get_fillformat/)) του σχήματος. Έτσι το υδατογράφημα παραμένει διακριτικό και δεν αποσπά την προσοχή από το περιεχόμενο της διαφάνειας.

**Ποιες μορφές εικόνας υποστηρίζονται για υδατογραφήματα;**

Το Aspose.Slides υποστηρίζει διάφορες μορφές εικόνας όπως PNG, JPEG, GIF, BMP, SVG και άλλες.

**Μπορώ να προσαρμόσω τη γραμματοσειρά και το στυλ ενός υδατογραφήματος κειμένου;**

Ναι, μπορείτε να επιλέξετε οποιαδήποτε γραμματοσειρά, μέγεθος και στυλ ώστε να ταιριάζει με το σχεδιασμό της παρουσίασής σας και να διατηρεί τη συνοχή της μάρκας.

**Πώς αλλάζω τη θέση ή τον προσανατολισμό ενός υδατογράφηματος;**

Μπορείτε να προσαρμόσετε τη θέση και τον προσανατολισμό του υδατογράφηματος προγραμματιστικά τροποποιώντας τις συντεταγμένες, το μέγεθος και τις ιδιότητες περιστροφής του σχήματος.