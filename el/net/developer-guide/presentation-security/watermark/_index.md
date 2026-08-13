---
title: Προσθήκη υδατογραφημάτων σε παρουσιάσεις .NET
linktitle: Υδατογράφημα
type: docs
weight: 40
url: /el/net/watermark/
keywords:
- υδατογράφημα
- υδατογράφημα κειμένου
- υδατογράφημα εικόνας
- προσθήκη υδατογραφήματος
- αλλαγή υδατογραφήματος
- αφαίρεση υδατογραφήματος
- διαγραφή υδατογραφήματος
- προσθήκη υδατογραφήματος σε PPT
- προσθήκη υδατογραφήματος σε PPTX
- προσθήκη υδατογραφήματος σε ODP
- αφαίρεση υδατογραφήματος από PPT
- αφαίρεση υδατογραφήματος από PPTX
- αφαίρεση υδατογραφήματος από ODP
- διαγραφή υδατογραφήματος από PPT
- διαγραφή υδατογραφήματος από PPTX
- διαγραφή υδατογραφήματος από ODP
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Διαχειριστείτε υδατογραφήματα κειμένου και εικόνας σε παρουσιάσεις PowerPoint και OpenDocument σε .NET για να υποδείξετε ένα πρόχειρο, εμπιστευτικές πληροφορίες, πνευματικά δικαιώματα και άλλα."
---
## **Εισαγωγή**

**Μία υδατογράφημα** σε μια παρουσίαση είναι μια σήμανση κειμένου ή εικόνας που χρησιμοποιείται σε μια διαφάνεια ή σε όλες τις διαφάνειες της παρουσίασης. Συνήθως, ένα υδατογράφημα χρησιμοποιείται για να υποδείξει ότι η παρουσίαση είναι πρόχειρη (π.χ., υδατογράφημα "Πρόχειρο"), ότι περιέχει εμπιστευτικές πληροφορίες (π.χ., υδατογράφημα "Εμπιστευτικό"), για να καθορίσει σε ποια εταιρεία ανήκει (π.χ., υδατογράφημα "Επωνυμία Εταιρείας"), για να ταυτοποιήσει τον συντάκτη της παρουσίασης κ.λπ. Ένα υδατογράφημα βοηθά στην αποτροπή παραβιάσεων πνευματικών δικαιωμάτων, υποδεικνύοντας ότι η παρουσίαση δεν πρέπει να αντιγραφεί. Τα υδατογραφήματα χρησιμοποιούνται τόσο σε μορφές παρουσίασης PowerPoint όσο και σε μορφές OpenDocument. Στο Aspose.Slides, μπορείτε να προσθέσετε υδατογράφημα σε αρχεία PowerPoint PPT, PPTX και OpenDocument ODP.

Στο [**Aspose.Slides**](https://products.aspose.com/slides/el/net/), υπάρχουν διάφοροι τρόποι για να δημιουργήσετε υδατογραφήματα σε έγγραφα PowerPoint ή OpenDocument και να τροποποιήσετε το σχέδιο και τη συμπεριφορά τους. Το κοινό στοιχείο είναι ότι για την προσθήκη κειμενικών υδατογραφημάτων, πρέπει να χρησιμοποιήσετε τη διεπαφή [ITextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/), ενώ για την προσθήκη υδατογραφημάτων εικόνας, χρησιμοποιήστε την κλάση [PictureFrame](https://reference.aspose.com/slides/el/net/aspose.slides/pictureframe/) ή γεμίστε ένα σχήμα υδατογραφήματος με εικόνα. Το `PictureFrame` υλοποιεί τη διεπαφή [IShape](https://reference.aspose.com/slides/el/net/aspose.slides/ishape), επιτρέπουν σας να χρησιμοποιήσετε όλες τις ευέλικτες ρυθμίσεις του αντικειμένου σχήματος. Δεδομένου ότι το `ITextFrame` δεν είναι σχήμα και οι ρυθμίσεις του είναι περιορισμένες, περιβάλλεται σε ένα αντικείμενο [IShape](https://reference.aspose.com/slides/el/net/aspose.slides/ishape).

Υπάρχουν δύο τρόποι εφαρμογής ενός υδατογραφήματος: σε μία ενιαία διαφάνεια ή σε όλες τις διαφάνειες της παρουσίασης. Το Slide Master χρησιμοποιείται για να εφαρμόσει ένα υδατογράφημα σε όλες τις διαφάνειες — το υδατογράφημα προστίθεται στο Slide Master, σχεδιάζεται πλήρως εκεί, και εφαρμόζεται σε όλες τις διαφάνειες χωρίς να επηρεάζεται η δυνατότητα τροποποίησης του υδατογραφήματος σε μεμονωμένες διαφάνειες.

Τα υδατγραφήματα συνήθως θεωρούνται μη διαθέσιμα για επεξεργασία από άλλους χρήστες. Για να αποτρέψετε την επεξεργασία του υδατογραφήματος (ή μάλλον του γονικού σχήματος του), το Aspose.Slides προσφέρει λειτουργικότητα κλειδώματος σχήματος. Ένα συγκεκριμένο σχήμα μπορεί να κλειδωθεί σε κανονική διαφάνεια ή σε Slide Master. Όταν το σχήμα του υδατογραφήματος κλειδωθεί στο Slide Master, θα είναι κλειδωμένο σε όλες τις διαφάνειες της παρουσίασης.

Μπορείτε να ορίσετε ένα όνομα για το υδατογράφημα ώστε στο μέλλον, αν θέλετε να το διαγράψετε, να το εντοπίζετε στα σχήματα της διαφάνειας με βάση το όνομα.

Μπορείτε να σχεδιάσετε το υδατογράφημα με οποιονδήποτε τρόπο· ωστόσο, συνήθως υπάρχουν κοινά χαρακτηριστικά στα υδατογραφήματα, όπως κεντρική ευθυγράμμιση, περιστροφή, θέση μπροστά κ.λπ. Θα εξετάσουμε πώς να τα χρησιμοποιήσετε στα παρακάτω παραδείγματα.

## **Υδατογράφημα Κειμένου**

### **Προσθήκη Υδατογραφήματος Κειμένου σε Διαφάνεια**

Για να προσθέσετε υδατογράφημα κειμένου σε PPT, PPTX ή ODP, μπορείτε πρώτα να προσθέσετε ένα σχήμα στη διαφάνεια, στη συνέχεια να προσθέσετε ένα πλαίσιο κειμένου σε αυτό το σχήμα. Το πλαίσιο κειμένου αντιπροσωπεύεται από τη διεπαφή [ITextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe). Αυτός ο τύπος δεν κληρονομεί από το [IShape](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/), το οποίο διαθέτει ένα ευρύ σύνολο ιδιοτήτων για την ευέλικτη τοποθέτηση του υδατογραφήματος. Συνεπώς, το αντικείμενο [ITextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe) περιβάλλεται σε ένα αντικείμενο [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/). Για να προσθέσετε κείμενο υδατογραφήματος στο σχήμα, χρησιμοποιήστε τη μέθοδο [AddTextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/methods/addtextframe) όπως φαίνεται παρακάτω.

```cs
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// Προσθήκη του υδατογραφήματος στη διαφάνεια.
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="info" title="Δείτε επίσης" %}} 
- [Πώς να χρησιμοποιήσετε την κλάση TextFrame?](/slides/el/net/text-formatting/)
{{% /alert %}}

### **Προσθήκη Υδατογραφήματος Κειμένου σε Παρουσίαση**

Αν θέλετε να προσθέσετε υδατογράφημα κειμένου σε ολόκληρη την παρουσίαση (δηλαδή σε όλες τις διαφάνειες ταυτόχρονα), προσθέστε το στο [MasterSlide](https://reference.aspose.com/slides/el/net/aspose.slides/masterslide/). Το υπόλοιπο της λογικής είναι το ίδιο όπως κατά την προσθήκη υδατογραφήματος σε μία διαφάνεια — δημιουργήστε ένα αντικείμενο [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) και στη συνέχεια προσθέστε το υδατογράφημα σε αυτό χρησιμοποιώντας τη μέθοδο [AddTextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/methods/addtextframe).

```cs
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.Masters[0];

// Προσθήκη του υδατογραφήματος στη μητρική διαφάνεια.
IAutoShape watermarkShape = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="info" title="Δείτε επίσης" %}} 
- [Πώς να χρησιμοποιήσετε το Slide Master?](/slides/el/net/slide-master/)
{{% /alert %}}

### **Ορισμός Διαφάνειας Σχήματος Υδατογραφήματος**

Από προεπιλογή, το ορθογώνιο σχήμα μορφοποιείται με χρώματα γεμίσματος και γραμμής. Αυτό σημαίνει ότι όταν προστίθεται το υδατογράφημα, ενδέχεται να εμφανίζεται με σταθερό φόντο ή περιθώριο που μπορεί να αποσπά την προσοχή από το περιεχόμενο της διαφάνειας. Για να διασφαλίσετε ότι το υδατογράφημα παραμένει διακριτικό και δεν επηρεάζει το οπτικό σχεδιασμό της παρουσίασης, μπορείτε να κάνετε το σχήμα πλήρως διαφανές.

Οι ακόλουθες γραμμές κώδικα καθιστούν το σχήμα διαφανές αφαιρώντας τόσο το γέμισμα όσο και τα χρώματα περιγράμματος:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.FillFormat.FillType = FillType.NoFill;
watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
```

### **Ορισμός Γραμματοσειράς για Υδατογράφημα Κειμένου**

Πριν εφαρμόσετε το υδατογράφημα κειμένου στη διαφάνειά σας, είναι σημαντικό να προσαρμόσετε την εμφάνισή του ώστε να εναρμονίζεται με το συνολικό σχεδιασμό. Μπορείτε να αλλάξετε τον τύπο και το μέγεθος της γραμματοσειράς για να διασφαλίσετε ότι το υδατογράφημα είναι ευανάγνωστο και αισθητικά ευχάριστο. Η προσαρμογή της γραμματοσειράς μπορεί επίσης να βοηθήσει στην ενίσχυση της ταυτότητας της μάρκας ή απλώς στην αντιστοίχηση με το στυλ της παρουσίασης.

Το παρακάτω απόσπασμα κώδικα δείχνει πώς να ρυθμίσετε τις ιδιότητες γραμματοσειράς του υδατογραφήματος επιλέγοντας μια συγκεκριμένη λατινική γραμματοσειρά και ορίζοντας το κατάλληλο ύψος γραμματοσειράς:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame("CONFIDENTIAL");

IPortionFormat textFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
textFormat.LatinFont = new FontData("Arial");
textFormat.FontHeight = 50;
```

### **Ορισμός Χρώματος Κειμένου Υδατογραφήματος**

Πριν εφαρμόσετε το υδατογράφημά σας, είναι ουσιώδες να διασφαλίσετε ότι το χρώμα του κειμένου έχει οριστεί σωστά ώστε να συνδυάζεται καλά με το περιεχόμενο της διαφάνειας χωρίς να το κυριαρχεί. Η ρύθμιση της διαφάνειας του χρώματος (α) μαζί με τα συστατικά κόκκινο, πράσινο και μπλε σας επιτρέπει να δημιουργήσετε ένα διακριτικό, ημιδιαφανές υδατογράφημα που είναι ορατό αλλά μη ενοχλητικό. Αυτή η προσέγγιση βοηθά στη διατήρηση της εστίασης στην κύρια παρουσίασή σας, προστατεύοντας ταυτόχρονα το περιεχόμενό σας.

Για να ορίσετε το χρώμα του κειμένου του υδατογραφήματος, χρησιμοποιήστε τον παρακάτω κώδικα:

```cs
using System.Drawing;
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame("CONFIDENTIAL");

int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat;
fillFormat.FillType = FillType.Solid;
fillFormat.SolidFillColor.Color = Color.FromArgb(alpha, red, green, blue);
```

### **Κεντράρισμα Υδατογραφήματος Κειμένου**

Το σωστό κεντράρισμα του κειμενικού υδατογραφήματος μπορεί να ενισχύσει σημαντικά την αισθητική της παρουσίασής σας, εξασφαλίζοντας ότι το υδατογράφημα είναι συμμετρικά κατατοπισμένο, ανεξάρτητα από τις διαστάσεις της διαφάνειας. Αυτή η προσέγγιση όχι μόνο δίνει στις διαφάνειές σας επαγγελματική εμφάνιση αλλά και διασφαλίζει ότι το υδατογράφημα δεν επηρεάζει το κύριο περιεχόμενο της διαφάνειας.

Το παρακάτω απόσπασμα κώδικα δείχνει πώς να υπολογίσετε τη κεντρική θέση μιας διαφάνειας και να τοποθετήσετε το κείμενο υδατογραφήματος ανάλογα:

```cs
using System.Drawing;
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

SizeF slideSize = presentation.SlideSize.Size;

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = (slideSize.Width - watermarkWidth) / 2;
float watermarkY = (slideSize.Height - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.Shapes.AddAutoShape(
    ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

Η παρακάτω εικόνα δείχνει το τελικό αποτέλεσμα.

![Το κείμενο υδατογράφημα](text_watermark.png)

## **Υδατογράφημα Εικόνας**

### **Προσθήκη Υδατογραφήματος Εικόνας σε Παρουσίαση**

Σε πολλές περιπτώσεις, ένα υδατογράφημα εικόνας μπορεί να παρέχει ένα μοναδικό στοιχείο branding ή μια πιο ελκυστική οπτικά εναλλακτική λύση σε ένα κειμενικό υδατογράφημα. Πριν προσθέσετε το υδατογράφημα, βεβαιωθείτε ότι το αρχείο εικόνας είναι διαθέσιμο (π.χ., PNG για διαφάνεια). Το παρακάτω παράδειγμα δείχνει πώς να φορτώσετε μια εικόνα από το σύστημα αρχείων σας, να την προσθέσετε στην παρουσίαση και στη συνέχεια να τη χρησιμοποιήσετε ως υδατογράφημα χρησιμοποιώντας τις ιδιότητες γεμίσματος του σχήματος.

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

using FileStream imageStream = File.OpenRead("watermark.png");
IPPImage image = presentation.Images.AddImage(imageStream);

watermarkShape.FillFormat.FillType = FillType.Picture;
watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;
watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
```

## **Κλείδωμα Υδατογραφήματος από Επεξεργασία**

Αν είναι απαραίτητο να αποτρέψετε την επεξεργασία ενός υδατογραφήματος, χρησιμοποιήστε την ιδιότητα [IAutoShape.ShapeLock](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/properties/shapelock) στο σχήμα. Με αυτήν την ιδιότητα, μπορείτε να προστατέψετε το σχήμα από την επιλογή, αλλαγή μεγέθους, μετακίνηση, ομαδοποίηση με άλλα στοιχεία, κλείδωμα του κειμένου από επεξεργασία και πολλά άλλα:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

// Κλείδωμα του σχήματος υδατογραφήματος από τροποποίηση.
watermarkShape.ShapeLock.SelectLocked = true;
watermarkShape.ShapeLock.SizeLocked = true;
watermarkShape.ShapeLock.TextLocked = true;
watermarkShape.ShapeLock.PositionLocked = true;
watermarkShape.ShapeLock.GroupingLocked = true;
```

## **Μεταφορά Υδατογραφήματος μπροστά**

Στο Aspose.Slides, η σειρά Z των σχημάτων μπορεί να οριστεί μέσω της μεθόδου [IShapeCollection.Reorder](https://reference.aspose.com/slides/el/net/aspose.slides/ishapecollection/reorder/#reorder). Για να το κάνετε αυτό, πρέπει να καλέσετε αυτή τη μέθοδο από τη λίστα διαφανειών της παρουσίασης και να περάσετε την αναφορά του σχήματος και τον αριθμό σειράς του στη μέθοδο. Με αυτόν τον τρόπο, είναι δυνατόν να φέρετε ένα σχήμα μπροστά ή να το στείλετε πίσω της διαφάνειας. Αυτή η δυνατότητα είναι ιδιαίτερα χρήσιμη αν χρειάζεται να τοποθετήσετε ένα υδατογράφημα μπροστά από την παρουσίαση:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

int shapeCount = slide.Shapes.Count;
slide.Shapes.Reorder(shapeCount - 1, watermarkShape);
```

## **Ορισμός Περιστροφής Υδατογραφήματος**

Η ρύθμιση της περιστροφής του υδατογραφήματος σας μπορεί να ενισχύσει σημαντικά την οπτική επίδραση και τη διακριτικότητα της παρουσίασής σας. Ένα διαγώνιο υδατογράφημα, για παράδειγμα, μπορεί να είναι λιγότερο ενοχλητικό ενώ παρέχει ισχυρή προστασία έναντι μη εξουσιοδοτημένης χρήσης. Το παρακάτω παράδειγμα υπολογίζει τη σωστή γωνία βάσει των διαστάσεων της διαφάνειας ώστε το υδατογράφημα να τοποθετηθεί διαγώνια στην διαφάνεια. Αυτή η δυναμική μέτρηση διασφαλίζει ότι το υδατογράφημα παραμένει αποτελεσματικό ανεξαρτήτως μεγέθους των διαφανειών.

```cs
using System.Drawing;
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

SizeF slideSize = presentation.SlideSize.Size;

double diagonalAngle = Math.Atan((slideSize.Height / slideSize.Width)) * 180 / Math.PI;

watermarkShape.Rotation = (float)diagonalAngle;
```

## **Ορισμός Ονόματος για Υδατογράφημα**

Το Aspose.Slides σας επιτρέπει να ορίσετε το όνομα ενός σχήματος. Χρησιμοποιώντας το όνομα του σχήματος, μπορείτε να το προσπελάσετε στο μέλλον για να το τροποποιήσετε ή να το διαγράψετε. Για να ορίσετε το όνομα του σχήματος του υδατογραφήματος, αντιστοιχίστε το στην ιδιότητα [IAutoShape.Name](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/properties/name):

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.Name = "watermark";
```

## **Διαγραφή Υδατογραφήματος**

Για να διαγράψετε το σχήμα του υδατογραφήματος, χρησιμοποιήστε την ιδιότητα [IAutoShape.Name](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/properties/name) για να το εντοπίσετε στα σχήματα της διαφάνειας. Στη συνέχεια, περάστε το σχήμα του υδατογραφήματος στη μέθοδο [IShapeCollection.Remove](https://reference.aspose.com/slides/el/net/aspose.slides/ishapecollection/remove/):

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

List<IShape> slideShapes = slide.Shapes.ToList();
foreach (IShape shape in slideShapes)
{
    if (string.Compare(shape.Name, "watermark", StringComparison.Ordinal) == 0)
    {
        slide.Shapes.Remove(shape);
    }
}
```

## **Ζωντανό Παράδειγμα**

Μπορείτε να ρίξετε μια ματιά στα **δωρεάν** εργαλεία Aspose.Slides [Add Watermark](https://products.aspose.app/slides/el/watermark) και [Remove Watermark](https://products.aspose.app/slides/el/watermark/remove-watermark) διαδικτυακά.

![Διαδικτυακά εργαλεία για προσθήκη και αφαίρεση υδατογραφημάτων](online_tools.png)

## **Συχνές Ερωτήσεις**

### Τι είναι ένα υδατογράφημα και γιατί πρέπει να το χρησιμοποιήσω;

Ένα υδατογράφημα είναι μια επικάλυψη κειμένου ή εικόνας που εφαρμόζεται στις διαφάνειες και βοηθά στην προστασία της πνευματικής ιδιοκτησίας, στην ενίσχυση της αναγνώρισης της μάρκας ή στην αποτροπή μη εξουσιοδοτημένης χρήσης παρουσιάσεων.

### Μπορώ να προσθέσω υδατογράφημα σε όλες τις διαφάνειες μιας παρουσίασης;

Ναι, το Aspose.Slides σας επιτρέπει να προσθέσετε προγραμματιστικά ένα υδατογράφημα σε κάθε διαφάνεια της παρουσίασης. Μπορείτε να διατρέξετε όλες τις διαφάνειες και να εφαρμόσετε τις ρυθμίσεις του υδατογραφήματος ξεχωριστά.

### Πώς μπορώ να ρυθμίσω τη διαφάνεια του υδατογραφήματος;

Μπορείτε να ρυθμίσετε τη διαφάνεια του υδατογραφήματος τροποποιώντας τις ρυθμίσεις γεμίσματος ([FillFormat](https://reference.aspose.com/slides/el/net/aspose.slides/shape/fillformat/)) του σχήματος. Αυτό εξασφαλίζει ότι το υδατογράφημα είναι διακριτικό και δεν αποσπά την προσοχή από το περιεχόμενο της διαφάνειας.

### Ποιοι τύποι εικόνας υποστηρίζονται για υδατογραφήματα;

Το Aspose.Slides υποστηρίζει διάφορους τύπους εικόνας όπως PNG, JPEG, GIF, BMP, SVG και άλλα.

### Μπορώ να προσαρμόσω τη γραμματοσειρά και το στυλ ενός κειμενικού υδατογραφήματος;

Ναι, μπορείτε να επιλέξετε οποιαδήποτε γραμματοσειρά, μέγεθος και στυλ ώστε να ταιριάζει με το σχεδιασμό της παρουσίασής σας και να διατηρεί τη συνοχή της μάρκας.

### Πώς αλλάζω τη θέση ή τον προσανατολισμό ενός υδατογραφήματος;

Μπορείτε να ρυθμίσετε τη θέση και τον προσανατολισμό του υδατογραφήματος προγραμματιστικά τροποποιώντας τις συντεταγμένες, το μέγεθος και τις ιδιότητες περιστροφής του σχήματος.