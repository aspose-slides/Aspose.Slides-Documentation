---
title: Βελτιστοποίηση Διαχείρισης Εικόνων σε Παρουσιάσεις σε .NET
linktitle: Διαχείριση Εικόνων
type: docs
weight: 10
url: /el/net/image/
keywords:
- προσθήκη εικόνας
- προσθήκη εικόνας
- αντικατάσταση εικόνας
- συλλογή εικόνων
- πλαίσιο εικόνας
- συνδεδεμένη εικόνα
- φόντο
- προσθήκη PNG
- προσθήκη JPG
- προσθήκη SVG
- SVG σε σχήματα
- εξωτερικοί πόροι SVG
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε, επαναχρησιμοποιείτε, συνδέετε, αντικαθιστάτε και διαχειρίζεστε raster και SVG εικόνες σε παρουσιάσεις PowerPoint και OpenDocument με το Aspose.Slides για .NET."
---
## **Εισαγωγή**

Aspose.Slides for .NET παρέχει διάφορους τρόπους εργασίας με εικόνες, και ο καθένας εξυπηρετεί διαφορετικό σκοπό. Μπορείτε να αποθηκεύσετε μια εικόνα σε μια παρουσίαση, να την εμφανίσετε σε ένα πλαίσιο εικόνας, να τη χρησιμοποιήσετε ως φόντο διαφάνειας, να συνδέσετε με εξωτερική εικόνα, να αντικαταστήσετε ένα κοινόχρηστο πόρο εικόνας, ή να μετατρέψετε το περιεχόμενο SVG σε επεξεργάσιμα σχήματα.

Αυτό το άρθρο επικεντρώνεται στους πόρους εικόνας και στον τρόπο χρήσης τους σε όλη την παρουσίαση. Για περικοπή, διαφάνεια, εφέ, τέντωμα και άλλες μορφοποιήσεις που εφαρμόζονται σε ένα μεμονωμένο πλαίσιο εικόνας, δείτε [Πλαίσιο Εικόνας](/slides/el/net/picture-frame/).

## **Κατανόηση του Μοντέλου Εικόνας**

Οι παρακάτω έννοιες API σχετίζονται στενά αλλά δεν είναι εναλλάξιμες:

- Η [presentation image collection](https://reference.aspose.com/slides/el/net/aspose.slides/iimagecollection/) αποθηκεύει πόρους εικόνας που χρησιμοποιούνται στην παρουσίαση. Χρησιμοποιήστε το [ImageCollection.AddImage](https://reference.aspose.com/slides/el/net/aspose.slides/imagecollection/addimage/) για να προσθέσετε δεδομένα εικόνας και να λάβετε έναν πόρο [IPPImage](https://reference.aspose.com/slides/el/net/aspose.slides/ippimage/).
- Ένα [picture frame](https://reference.aspose.com/slides/el/net/aspose.slides/ipictureframe/) είναι ένα σχήμα που εμφανίζει μια εικόνα σε μια διαφάνεια, διάταξη ή κύριο πρότυπο. Χρησιμοποιήστε το [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/el/net/aspose.slides/ishapecollection/addpictureframe/) για να τοποθετήσετε έναν πόρο εικόνας σε μια διαφάνεια.
- Ένα φόντο διαφάνειας χρησιμοποιεί μια εικόνα ως μέρος της γέμισης της διαφάνειας και όχι ως σχήμα. Επομένως δεν συμπεριφέρεται όπως ένα picture frame.
- [IPPImage.ReplaceImage](https://reference.aspose.com/slides/el/net/aspose.slides/ippimage/replaceimage/) αντικαθιστά έναν πόρο εικόνας. Εάν πολλά στοιχεία της παρουσίασης χρησιμοποιούν αυτόν τον πόρο, όλα θα χρησιμοποιούν την αντικατάσταση.
- Η μετατροπή ενός SVG σε σχήματα δημιουργεί επεξεργάσιμα σχήματα διαφάνειας. Μετά τη μετατροπή, το περιεχόμενο δεν διαχειρίζεται πια ως ένας πόρος εικόνας.

Έτσι, μια τυπική ροή εργασίας είναι: προσθέστε δεδομένα εικόνας στη συλλογή εικόνων, λάβετε ένα [IPPImage](https://reference.aspose.com/slides/el/net/aspose.slides/ippimage/), και στη συνέχεια χρησιμοποιήστε αυτόν τον πόρο σε ένα ή περισσότερα picture frames ή γέμιση.

## **Προσθήκη Ενσωματωμένης Εικόνας**

Για να εισάγετε μια τοπική εικόνα, διαβάστε το αρχείο, προσθέστε τα δεδομένα του στη συλλογή εικόνων και δημιουργήστε ένα picture frame που χρησιμοποιεί το επιστρεφόμενο `IPPImage`.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

Η εικόνα που προστίθεται με αυτόν τον τρόπο είναι ενσωματωμένη στην παρουσίαση, οπότε το παραγόμενο αρχείο δεν εξαρτάται από τη διαθεσιμότητα του αρχικού αρχείου εικόνας.

### **Προσθήκη Εικόνας από το Διαδίκτυο**

Όταν μια εικόνα είναι διαθέσιμη μέσω HTTP ή HTTPS, κατεβάστε τα byte της με το `HttpClient`, προσθέστε τα στη συλλογή εικόνων της παρουσίασης, και χρησιμοποιήστε τον επιστρεφόμενο πόρο εικόνας με τον ίδιο τρόπο όπως μια τοπική εικόνα.

```csharp
using System;
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;

var imageUri = new Uri("https://example.com/image.png");
using var httpClient = new HttpClient();
var imageData = await httpClient.GetByteArrayAsync(imageUri);

using var presentation = new Presentation();

var image = presentation.Images.AddImage(imageData);
var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

presentation.Save("presentation-from-web.pptx", SaveFormat.Pptx);
```

Σε μακροχρόνιες εφαρμογές, επαναχρησιμοποιήστε το `HttpClient` αντί να δημιουργείτε νέο στιγμιότυπο για κάθε αίτηση. Επίσης, επαληθεύστε απομακρυσμένα URLs, το μέγεθος των απαντήσεων και τους τύπους περιεχομένου όταν η πηγή δεν είναι αξιόπιστη.

## **Επαναχρησιμοποίηση Εικόνων σε Διαφάνειες**

Εάν η ίδια εικόνα χρειάζεται περισσότερες φορές, προσθέστε τη μία φορά στην παρουσίαση και επαναχρησιμοποιήστε το επιστρεφόμενο [IPPImage](https://reference.aspose.com/slides/el/net/aspose.slides/ippimage/) κατά τη δημιουργία επιπλέον picture frames. Αυτό αποφεύγει τη συνεχόμενη φόρτωση των ίδιων δεδομένων πηγής και κάνει τη σχέση μεταξύ του κοινόχρηστου πόρου εικόνας και των χρήσεων του σαφής.

Για γραφικά που πρέπει να εμφανίζονται αυτόματα σε πολλές διαφάνειες, όπως το λογότυπο μιας εταιρείας, σκεφτείτε να τοποθετήσετε το picture frame σε ένα [slide master](/slides/el/net/slide-master/) ή διάταξη αντί να προσθέσετε ισοδύναμο σχήμα σε κάθε διαφάνεια.

## **Χρήση Εικόνας ως Φόντο Διαφάνειας**

Μια εικόνα φόντου αντιστοιχίζεται στη γέμιση της διαφάνειας· δεν προστίθεται ως σχήμα picture-frame. Αυτό είναι χρήσιμο όταν η εικόνα πρέπει να καλύπτει το φόντο της διαφάνειας και δεν πρέπει να χειρίζεται ως κανονικό αντικείμενο διαφάνειας.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("background.jpg");
var image = presentation.Images.AddImage(imageData);
slide.Background.Type = BackgroundType.OwnBackground;
slide.Background.FillFormat.FillType = FillType.Picture;
slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
slide.Background.FillFormat.PictureFillFormat.Picture.Image = image;

presentation.Save("background-image.pptx", SaveFormat.Pptx);
```

Για επιπλέον επιλογές φόντου, συμπεριλαμβανομένων φόντων master και διάταξης, δείτε [Φόντο Παρουσίασης](/slides/el/net/presentation-background/).

## **Ενσωματωμένες Εικόνες και Συνδεδεμένες Εικόνες**

Οι ενσωματωμένες και οι συνδεδεμένες εικόνες έχουν διαφορετικές ανταλλαγές φορητότητας και μεγέθους αρχείου:

- **Ενσωματωμένη εικόνα:** τα δεδομένα εικόνας αποθηκεύονται μέσα στην παρουσίαση. Η παρουσίαση είναι αυτόνομη, αλλά το μέγεθος του αρχείου περιλαμβάνει τα δεδομένα εικόνας.
- **Συνδεδεμένη εικόνα:** η παρουσίαση αποθηκεύει ένα μονοπάτι ή URL σε εξωτερική εικόνα. Αυτό μπορεί να μειώσει το μέγεθος της παρουσίασης, αλλά ο εξωτερικός πόρος πρέπει να παραμένει προσβάσιμος όταν η παρουσίαση ανοίγει ή αποδίδεται.

Μια συνδεδεμένη εικόνα μπορεί να δημιουργηθεί αναθέτοντας το εξωτερικό μονοπάτι ή URL μέσω του [ISlidesPicture.LinkPathLong](https://reference.aspose.com/slides/el/net/aspose.slides/islidespicture/linkpathlong/) αντί να ενσωματώνετε τα δεδομένα εικόνας.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, null);
pictureFrame.PictureFormat.Picture.LinkPathLong = "https://example.com/image.png";

presentation.Save("linked-image.pptx", SaveFormat.Pptx);
```

Χρησιμοποιείτε συνδεδεμένες εικόνες μόνο όταν το περιβάλλον ανάπτυξης μπορεί αξιόπιστα να προσπελάσει τον εξωτερικό πόρο. Για παρουσιάσεις που πρέπει να λειτουργούν εκτός σύνδεσης ή να μετακινούνται μεταξύ συστημάτων, οι ενσωματωμένες εικόνες είναι συνήθως πιο ασφαλείς.

## **Εργασία με SVG Εικόνες**

Το SVG είναι διανυσματική μορφή, επομένως μπορεί να είναι χρήσιμο για εικονίδια, διαγράμματα και άλλα γραφικά που πρέπει να κλιμακώνονται χωρίς την ίδια απώλεια λεπτομέρειας όπως οι raster εικόνες. Το Aspose.Slides υποστηρίζει SVG τόσο ως πόρο εικόνας όσο και ως πηγή για επεξεργάσιμα σχήματα διαφάνειας.

### **Προσθήκη SVG ως Εικόνα**

Δημιουργήστε ένα [SvgImage](https://reference.aspose.com/slides/el/net/aspose.slides/svgimage/), προσθέστε το στη συλλογή εικόνων και τοποθετήστε τον παραγόμενο πόρο εικόνας σε ένα picture frame.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = File.ReadAllText("icon.svg");
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();

var image = presentation.Images.AddImage(svgImage);
var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image);

presentation.Save("svg-image.pptx", SaveFormat.Pptx);
```

### **Αρχεία SVG με Εξωτερικούς Πόρους**

Ένα SVG μπορεί να αναφέρεται σε εξωτερικές εικόνες, φύλλα στυλ ή γραμματοσειρές. Για αυτές τις περιπτώσεις, το [SvgImage](https://reference.aspose.com/slides/el/net/aspose.slides/svgimage/) παρέχει κατασκευαστές που δέχονται έναν [IExternalResourceResolver](https://reference.aspose.com/slides/el/net/aspose.slides.import/iexternalresourceresolver/) και μια βασική URI. Ο resolver μπορεί να χαρτογραφήσει μια σχετική URI σε μια επιτρεπτή απόλυτη URI και να επιστρέψει ένα stream για τον ζητούμενο πόρο.

Ο resolver καθιστά διαθέσιμους τους εξωτερικούς πόρους ενώ το Aspose.Slides επεξεργάζεται το SVG, αλλά δεν ξαναγράφει το SVG σε αυτόνομα έγγραφο. Εάν το SVG πρέπει να παραμείνει φορητό, ενσωματώστε τους απαιτούμενους πόρους μέσα στο ίδιο το SVG, για παράδειγμα χρησιμοποιώντας `data:` URI για συνδεδεμένες εικόνες.

Όταν τα αρχεία SVG προέρχονται από μη αξιόπιστες πηγές, περιορίστε τα σχήματα, τις τοποθεσίες αρχείων και τους κεντρικούς υπολογιστές που ο resolver μπορεί να προσπελάσει. Οι δικτυακοί resolvers θα πρέπει επίσης να εφαρμόζουν χρονικά όρια, όρια μεγέθους απάντησης και επικύρωση περιεχομένου.

### **Μετατροπή SVG σε Επεξεργάσιμα Σχήματα**

Το Aspose.Slides μπορεί να μετατρέψει ένα SVG σε μια ομάδα επεξεργάσιμων σχημάτων διαφάνειας, παρόμοια με την αντίστοιχη εντολή του PowerPoint.

![PowerPoint Popup Menu](img_01_01.png)

Χρησιμοποιήστε την υπερφόρτωση του [IShapeCollection.AddGroupShape](https://reference.aspose.com/slides/el/net/aspose.slides/ishapecollection/addgroupshape/) που δέχεται ένα [ISvgImage](https://reference.aspose.com/slides/el/net/aspose.slides/isvgimage/) για να πραγματοποιήσετε τη μετατροπή.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = File.ReadAllText("diagram.svg");
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var slide = presentation.Slides[0];
slide.Shapes.AddGroupShape(svgImage, 0, 0, slideSize.Width, slideSize.Height);

presentation.Save("editable-svg-shapes.pptx", SaveFormat.Pptx);
```

Χρησιμοποιήστε τη μετατροπή SVG-σε-σχήματα όταν τα μεμονωμένα διανυσματικά στοιχεία χρειάζεται να επεξεργαστούν ως σχήματα PowerPoint. Εάν το SVG χρειάζεται μόνο να εμφανίζεται, η παραμονή του ως εικόνα είναι πιο απλή και αποφεύγει τη δημιουργία πολλών ξεχωριστών σχημάτων.

## **Αντικατάσταση Υπάρχοντος Πόρου Εικόνας**

Χρησιμοποιήστε το [IPPImage.ReplaceImage](https://reference.aspose.com/slides/el/net/aspose.slides/ippimage/replaceimage/) όταν θέλετε να αντικαταστήσετε έναν υπάρχοντα πόρο εικόνας. Αυτό είναι ιδιαίτερα χρήσιμο για κοινόχρηστα γραφικά όπως λογότυπα.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var imageToReplace = presentation.Images[0];
imageToReplace.ReplaceImage(File.ReadAllBytes("new-logo.png"));

presentation.Save("output.pptx", SaveFormat.Pptx);
```

Εάν πολλά picture frames, φόντα, master ή διατάξεις χρησιμοποιούν τον ίδιο πόρο εικόνας, η αντικατάσταση του πόρου ενημερώνει όλες αυτές τις χρήσεις. Εάν πρέπει να αλλάξει μόνο ένα picture frame, αναθέστε μια διαφορετική εικόνα σε εκείνο το frame αντί να αντικαταστήσετε τον κοινόχρηστο πόρο.

Το `ReplaceImage` παρέχει επίσης υπερφορτώσεις που δέχονται ένα [IImage](https://reference.aspose.com/slides/el/net/aspose.slides/iimage/) ή άλλο [IPPImage](https://reference.aspose.com/slides/el/net/aspose.slides/ippimage/).

## **Πρακτικές Οδηγίες Διαχείρισης Εικόνων**

### **Έλεγχος Μεγέθους Παρουσίασης**

Οι μεγάλες raster εικόνες μπορούν να κάνουν μια παρουσίαση περιττά μεγάλη. Χρησιμοποιήστε πηγαίες εικόνες με διαστάσεις κατάλληλες για το προοριζόμενο μέγεθος εμφάνισης, επαναχρησιμοποιήστε κοινόχρηστους πόρους εικόνας όπου είναι δυνατόν, και αποφύγετε την ενσωμάτωση επαναλαμβανόμενων αντιγράφων του ίδιου γραφικού υψηλής ανάλυσης.

Για raster εικόνες που έχουν ήδη τοποθετηθεί σε picture frames, το [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/el/net/aspose.slides/ipicturefillformat/compressimage/) μπορεί να μειώσει τα δεδομένα εικόνας ανάλογα με την επιλεγμένη ανάλυση και τις ρυθμίσεις περικοπής. Αυτό είναι επεξεργασία picture-frame και όχι διαχείριση συλλογής εικόνων, επομένως δείτε το [Picture Frame](/slides/el/net/picture-frame/) για σχετικές λειτουργίες μορφοποίησης.

### **Επιλογή Μεταξύ Ενσωματωμένου και Συνδεδεμένου Περιεχομένου**

Η ενσωμάτωση καθιστά την παρουσίαση φορητή επειδή όλα τα απαιτούμενα δεδομένα εικόνας μεταφέρονται με το αρχείο. Η σύνδεση μπορεί να μειώσει το μέγεθος του αρχείου, αλλά εισάγει εξωτερική εξάρτηση. Χρησιμοποιήστε συνδέσμους μόνο όταν αυτή η εξάρτηση είναι αποδεκτή και σταθερή.

### **Επανάληψη Κοινής Επωνυμίας**

Για επαναλαμβανόμενα λογότυπα, υδατογραφήματα ή διακοσμητικά γραφικά, χρησιμοποιήστε έναν πόρο εικόνας και επαναχρησιμοποιήστε τον. Εάν το γραφικό ανήκει στο σχεδιασμό της παρουσίασης και όχι στο περιεχόμενο των διαφανειών, τοποθετήστε το σε ένα master ή διάταξη ώστε να κληρονομείται από τις κατάλληλες διαφάνειες.

### **Διατήρηση Φορητότητας Πόρων SVG**

Ένα αυτόνομο SVG είναι πιο εύκολο να μεταφερθεί και να αποδοθεί σταθερά από ένα SVG που εξαρτάται από εξωτερικά αρχεία ή δικτυακούς πόρους. Όταν είναι δυνατόν, ενσωματώστε τους απαιτούμενους πόρους πριν την εισαγωγή του SVG. Μετατρέψτε το SVG σε σχήματα μόνο όταν τα μεμονωμένα διανυσματικά στοιχεία χρειάζονται επεξεργασία.

### **Χρήση του Σύγχρονου Cross-Platform Image API**

Για νέο κώδικα .NET, χρησιμοποιήστε τα APIs Aspose.Slides [IImage](https://reference.aspose.com/slides/el/net/aspose.slides/iimage/) και [Images](https://reference.aspose.com/slides/el/net/aspose.slides/images/) αντί να βασιστείτε στο `System.Drawing.Image` ή το `Bitmap`. Δείτε το [Modern API](/slides/el/net/modern-api/) για οδηγίες μετανάστευσης.

Τα WMF και EMF απαιτούν ειδική προσοχή. Όταν αυτές οι μορφές περνούν μέσω ενός [IImage](https://reference.aspose.com/slides/el/net/aspose.slides/iimage/), το [ImageCollection.AddImage](https://reference.aspose.com/slides/el/net/aspose.slides/imagecollection/addimage/) μετατρέπει το μετααρχείο σε αναπαράσταση raster PNG πριν από την εισαγωγή. Εάν η διατήρηση των δεδομένων του μετααρχείου είναι σημαντική, χρησιμοποιήστε μια υπερφόρτωση [ImageCollection.AddImage](https://reference.aspose.com/slides/el/net/aspose.slides/imagecollection/addimage/) βασισμένη σε stream. Η δημιουργία περιεχομένου EMF από υπολογιστικά φύλλα ή άλλα προϊόντα είναι μια ξεχωριστή διαδικασία ενσωμάτωσης και βρίσκεται εκτός του πεδίου του παρόντος άρθρου.

## **Συχνές Ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ της συλλογής εικόνων και ενός picture frame;**

Η συλλογή εικόνων αποθηκεύει επαναχρησιμοποιήσιμους πόρους εικόνας. Ένα picture frame είναι ένα σχήμα διαφάνειας που εμφανίζει έναν από αυτούς τους πόρους και παρέχει μορφοποίηση ειδική για εικόνες όπως περικοπή και εφέ.

**Ποιος είναι ο καλύτερος τρόπος για να αντικαταστήσετε το ίδιο λογότυπο παντού;**

Εάν το λογότυπο είναι ήδη κοινόχρηστο ως ένας πόρος εικόνας, αντικαταστήστε αυτόν τον πόρο με το [IPPImage.ReplaceImage](https://reference.aspose.com/slides/el/net/aspose.slides/ippimage/replaceimage/). Για επωνυμία σε όλη την παρουσίαση, η τοποθέτηση του λογότυπου σε master ή διάταξη μπορεί επίσης να μειώσει το διπλό περιεχόμενο των διαφανειών.

**Γιατί μια συνδεδεμένη εικόνα εξαφανίζεται σε έναν άλλο υπολογιστή;**

Μια συνδεδεμένη εικόνα εξαρτάται από το εξωτερικό της αρχείο ή URL. Εάν αυτός ο πόρος δεν μπορεί να προσεγγιστεί από τον άλλο υπολογιστή, η συνδεδεμένη εικόνα μπορεί να μην είναι διαθέσιμη. Ενσωματώστε την εικόνα όταν η παρουσίαση πρέπει να είναι αυτόνομη.

**Μπορεί ένα εισαχθέν SVG να επεξεργαστεί ως σχήματα PowerPoint;**

Ναι. Μετατρέψτε το SVG με το [IShapeCollection.AddGroupShape](https://reference.aspose.com/slides/el/net/aspose.slides/ishapecollection/addgroupshape/); η προκύπτουσα ομάδα περιέχει επεξεργάσιμα σχήματα διαφάνειας αντί για μία εικόνα SVG.

**Πώς μπορώ να διατηρήσω τις παρουσιάσεις με πολλές εικόνες μικρότερες;**

Επαναχρησιμοποιήστε κοινόχρηστους πόρους εικόνας, αποφύγετε τις περιττά μεγάλες raster πηγές, συμπιέστε κατάλληλες raster εικόνες όταν είναι αναγκαίο, διατηρήστε την επαναλαμβανόμενη επωνυμία σε master ή διατάξεις, και χρησιμοποιήστε συνδεδεμένες εικόνες μόνο όταν μια εξωτερική εξάρτηση είναι αποδεκτή.