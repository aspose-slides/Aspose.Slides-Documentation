---
title: Βελτιστοποίηση Διαχείρισης Εικόνων σε Παρουσιάσεις σε .NET
linktitle: Διαχείριση Εικόνων
type: docs
weight: 10
url: /el/net/image/
keywords:
- προσθήκη εικόνας
- προσθήκη φωτογραφίας
- προσθήκη bitmap
- αντικατάσταση εικόνας
- αντικατάσταση εικόνας
- από το διαδίκτυο
- υπόβαθρο
- προσθήκη PNG
- προσθήκη JPG
- προσθήκη SVG
- προσθήκη EMF
- προσθήκη WMF
- προσθήκη TIFF
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Απλοποιήστε τη διαχείριση εικόνων στο PowerPoint και το OpenDocument με το Aspose.Slides για .NET, βελτιώνοντας την απόδοση και αυτοματοποιώντας τη ροή εργασίας σας."
---
## **Εισαγωγή**

Οι εικόνες κάνουν τις παρουσιάσεις πιο ελκυστικές και ενδιαφέρουσες. Στο Microsoft PowerPoint, μπορείτε να εισάγετε εικόνες από αρχείο, το διαδίκτυο ή άλλες τοποθεσίες στις διαφάνειες. Ομοίως, το Aspose.Slides σάς επιτρέπει να προσθέτετε εικόνες στις διαφάνειες των παρουσιάσεών σας μέσω διαφορετικών διαδικασιών.

{{% alert  title="Tip" color="primary" %}} 

Η Aspose παρέχει δωρεάν μετατροπείς—[JPEG σε PowerPoint](https://products.aspose.app/slides/el/import/jpg-to-ppt) και [PNG σε PowerPoint](https://products.aspose.app/slides/el/import/png-to-ppt)—που επιτρέπουν στους χρήστες να δημιουργούν παρουσιάσεις γρήγορα από εικόνες. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Αν θέλετε να προσθέσετε μια εικόνα ως αντικείμενο πλαισίου — ειδικά αν σκοπεύετε να χρησιμοποιήσετε τις τυπικές επιλογές μορφοποίησης για να αλλάξετε το μέγεθός της, να προσθέσετε εφέ κλπ — δείτε [Καρέ Εικόνας](https://docs.aspose.com/slides/el/net/picture-frame/). 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Μπορείτε να χειριστείτε λειτουργίες εισόδου/εξόδου που αφορούν εικόνες και παρουσιάσεις PowerPoint για να μετατρέψετε μια εικόνα από μια μορφή σε άλλη. Δείτε αυτές τις σελίδες: μετατροπή [εικόνα σε JPG](https://products.aspose.com/slides/el/net/conversion/image-to-jpg/); μετατροπή [JPG σε εικόνα](https://products.aspose.com/slides/el/net/conversion/jpg-to-image/); μετατροπή [JPG σε PNG](https://products.aspose.com/slides/el/net/conversion/jpg-to-png/), μετατροπή [PNG σε JPG](https://products.aspose.com/slides/el/net/conversion/png-to-jpg/); μετατροπή [PNG σε SVG](https://products.aspose.com/slides/el/net/conversion/png-to-svg/), μετατροπή [SVG σε PNG](https://products.aspose.com/slides/el/net/conversion/svg-to-png/).

{{% /alert %}}

Το Aspose.Slides υποστηρίζει λειτουργίες με εικόνες σε αυτές τις δημοφιλείς μορφές: JPEG, PNG, BMP, GIF και άλλα. 

## **Προσθήκη Εικόνων αποθηκευμένων Τοπικά στις Διαφάνειες**

Μπορείτε να προσθέσετε μία ή πολλές εικόνες από τον υπολογιστή σας σε μια διαφάνεια μιας παρουσίασης. Αυτός ο κώδικας παραδείγματος σε C# δείχνει πώς να προσθέσετε μια εικόνα σε μια διαφάνεια:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Προσθήκη Εικόνων από το Διαδίκτυο στις Διαφάνειες**

Αν η εικόνα που θέλετε να προσθέσετε σε μια διαφάνεια δεν είναι διαθέσιμη στον υπολογιστή σας, μπορείτε να προσθέσετε την εικόνα απευθείας από το διαδίκτυο. 

Αυτός ο κώδικας παραδείγματος δείχνει πώς να προσθέσετε μια εικόνα από το διαδίκτυο σε μια διαφάνεια σε C#:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] imageData;
    using (WebClient webClient = new WebClient()) 
    {
        imageData = webClient.DownloadData(new Uri("[REPLACE WITH URL]"));
    }
    
    IPPImage image = pres.Images.AddImage(imageData);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Προσθήκη Εικόνων σε Master Διαφάνειας**

Το master διαφάνειας είναι η κύρια διαφάνεια που αποθηκεύει και ελέγχει πληροφορίες (θέμα, διάταξη κλπ.) για όλες τις διαφάνειες που ανήκουν σε αυτό. Έτσι, όταν προσθέσετε μια εικόνα σε ένα master διαφάνειας, αυτή η εικόνα εμφανίζεται σε κάθε διαφάνεια κάτω από το συγκεκριμένο master. 

Αυτός ο κώδικας παραδείγματος σε C# δείχνει πώς να προσθέσετε μια εικόνα σε ένα master διαφάνειας:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IMasterSlide masterSlide = slide.LayoutSlide.MasterSlide;
    
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    masterSlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Προσθήκη Εικόνων ως Υπόβαθρο Διαφάνειας**

Μπορείτε να αποφασίσετε να χρησιμοποιήσετε μια εικόνα ως υπόβαθρο για μια συγκεκριμένη διαφάνεια ή για πολλές διαφάνειες. Σε αυτή την περίπτωση, πρέπει να δείτε *[Ορισμός Εικόνων ως Υπόβαθρα για Διαφάνειες](https://docs.aspose.com/slides/el/net/presentation-background/#setting-images-as-background-for-slides)*.

## **Προσθήκη SVG σε Παρουσιάσεις**

Μπορείτε να προσθέσετε ή να ενσωματώσετε οποιαδήποτε εικόνα σε μια παρουσίαση χρησιμοποιώντας τη μέθοδο [AddPictureFrame](https://reference.aspose.com/slides/el/net/aspose.slides/ishapecollection/methods/addpictureframe) που ανήκει στη διεπαφή [IShapeCollection](https://reference.aspose.com/slides/el/net/aspose.slides/ishapecollection).

Για να δημιουργήσετε ένα αντικείμενο εικόνας βασισμένο σε SVG, μπορείτε να το κάνετε ως εξής:

1. Δημιουργήστε αντικείμενο SvgImage για να το εισάγετε στο ImageShapeCollection
2. Δημιουργήστε αντικείμενο PPImage από το ISvgImage
3. Δημιουργήτε αντικείμενο PictureFrame χρησιμοποιώντας τη διεπαφή IPPImage

Αυτός ο κώδικας παραδείγματος δείχνει πώς να υλοποιήσετε τα παραπάνω βήματα για να προσθέσετε μια εικόνα SVG σε μια παρουσίαση:
``` csharp 
// Η διαδρομή προς το φάκελο εγγράφων
string dataDir = @"D:\Documents\";

// Όνομα αρχικού αρχείου SVG
string svgFileName = dataDir + "sample.svg";

// Όνομα αρχικού αρχείου παρουσίασης
string outPptxPath = dataDir + "presentation.pptx";

// Δημιουργία νέας παρουσίασης
using (var p = new Presentation())
{
    // Ανάγνωση περιεχομένου αρχείου SVG
    string svgContent = File.ReadAllText(svgFileName);

    // Δημιουργία αντικειμένου SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // Δημιουργία αντικειμένου PPImage
    IPPImage ppImage = p.Images.AddImage(svgImage);

    // Δημιουργεί νέο PictureFrame 
    p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 200, 100, ppImage.Width, ppImage.Height, ppImage);

    // Αποθήκευση παρουσίασης σε μορφή PPTX
    p.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **Μετατροπή SVG σε Σύνολο Σχημάτων**

Η μετατροπή SVG σε σύνολο σχημάτων του Aspose.Slides είναι παρόμοια με τη λειτουργικότητα του PowerPoint που χρησιμοποιείται για εργασία με εικόνες SVG:

![PowerPoint Popup Menu](img_01_01.png)

Η λειτουργικότητα παρέχεται από μία από τις υπερφορτώσεις της μεθόδου [AddGroupShape](https://reference.aspose.com/slides/el/net/aspose.slides.ishapecollection/addgroupshape/methods/1) της διεπαφής [IShapeCollection](https://reference.aspose.com/slides/el/net/aspose.slides/ishapecollection) που δέχεται ένα αντικείμενο [ISvgImage](https://reference.aspose.com/slides/el/net/aspose.slides/isvgimage) ως πρώτο όρισμα.

Αυτός ο κώδικας παραδείγματος δείχνει πώς να χρησιμοποιήσετε τη περιγραφόμενη μέθοδο για να μετατρέψετε ένα αρχείο SVG σε σύνολο σχημάτων:

``` csharp 
// Η διαδρομή προς το φάκελο εγγράφων
string dataDir = @"D:\Documents\";

// Όνομα αρχικού αρχείου SVG
string svgFileName = dataDir + "sample.svg";

// Όνομα αρχείου εξόδου παρουσίασης
string outPptxPath = dataDir + "presentation.pptx";

// Δημιουργία νέας παρουσίασης
using (IPresentation presentation = new Presentation())
{
    // Ανάγνωση περιεχομένου αρχείου SVG
    string svgContent = File.ReadAllText(svgFileName);

    // Δημιουργία αντικειμένου SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // Λήψη μεγέθους διαφάνειας
    SizeF slideSize = presentation.SlideSize.Size;

    // Μετατροπή εικόνας SVG σε ομάδα σχημάτων κλιμακώνοντάς την στο μέγεθος της διαφάνειας
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // Αποθήκευση παρουσίασης σε μορφή PPTX
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **Προσθήκη Εικόνων ως EMF σε Διαφάνειες**

Το Aspose.Slides για .NET σας επιτρέπει να δημιουργήσετε εικόνες EMF από φύλλα Excel και να προσθέσετε τις εικόνες ως EMF σε διαφάνειες με το Aspose.Cells.  

Αυτός ο κώδικας παραδείγματος δείχνει πώς να εκτελέσετε την περιγραφείσα εργασία:

``` csharp 
using (Workbook book = new Workbook(dataDir + "chart.xlsx"))
{
    Worksheet sheet = book.Worksheets[0];
    ImageOrPrintOptions options = new ImageOrPrintOptions();
    options.HorizontalResolution = 200;
    options.VerticalResolution = 200;
    options.ImageFormat = System.Drawing.Imaging.ImageFormat.Emf;

    //Αποθήκευση του βιβλίου εργασίας σε ροή
    SheetRender sr = new SheetRender(sheet, options);
    using (Presentation pres = new Presentation())
    {
        pres.Slides.RemoveAt(0);

        String EmfSheetName = "";
        for (int j = 0; j < sr.PageCount; j++)
        {
            EmfSheetName = dataDir + "test" + sheet.Name + " Page" + (j + 1) + ".out.emf";
            sr.ToImage(j, EmfSheetName);

            var bytes = File.ReadAllBytes(EmfSheetName);
            var emfImage = pres.Images.AddImage(bytes);
            ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(SlideLayoutType.Blank));
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, pres.SlideSize.Size.Width, pres.SlideSize.Size.Height, emfImage);
        }

        pres.Save(dataDir + "Saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
```

## **Αντικατάσταση Εικόνων στη Συλλογή Εικόνων**

Το Aspose.Slides σάς επιτρέπει να αντικαταστήσετε εικόνες που είναι αποθηκευμένες στη συλλογή εικόνων μιας παρουσίασης (συμπεριλαμβανομένων αυτών που χρησιμοποιούνται από σχήματα διαφάνειας). Αυτή η ενότητα δείχνει διάφορες προσεγγίσεις για την ενημέρωση των εικόνων στη συλλογή. Το API παρέχει απλές μεθόδους για την αντικατάσταση μιας εικόνας χρησιμοποιώντας ακατέργαστα δεδομένα byte, μια παρουσία [IImage](https://reference.aspose.com/slides/el/net/aspose.slides/iimage/) ή άλλη εικόνα που υπάρχει ήδη στη συλλογή.

Ακολουθήστε τα παρακάτω βήματα:

1. Φορτώστε το αρχείο παρουσίασης που περιέχει εικόνες χρησιμοποιώντας την κλάση [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
2. Φορτώστε μια νέα εικόνα από αρχείο σε έναν πίνακα byte.
3. Αντικαταστήστε την εικόνα-στόχο με τη νέα εικόνα χρησιμοποιώντας τον πίνακα byte.
4. Στη δεύτερη προσέγγιση, φορτώστε την εικόνα σε ένα αντικείμενο [IImage](https://reference.aspose.com/slides/el/net/aspose.slides/iimage/) και αντικαταστήστε την εικόνα-στόχο με αυτό το αντικείμενο.
5. Στην τρίτη προσέγγιση, αντικαταστήστε την εικόνα-στόχο με μια εικόνα που υπάρχει ήδη στη συλλογή εικόνων της παρουσίασης.
6. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```cs
// Δημιουργία αντικειμένου της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using Presentation presentation = new Presentation("sample.pptx");

// Ο πρώτος τρόπος.
byte[] imageData = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(imageData);

// Ο δεύτερος τρόπος.
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

// Ο τρίτος τρόπος.
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

// Αποθήκευση της παρουσίασης σε αρχείο.
presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert title="Info" color="info" %}}

Χρησιμοποιώντας το δωρεάν μετατροπέα Aspose FREE [Κείμενο σε GIF](https://products.aspose.app/slides/el/text-to-gif), μπορείτε εύκολα να δημιουργήσετε κινούμενα κείμενα, GIF από κείμενα κ.λπ. 

{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Παραμένει η αρχική ανάλυση της εικόνας μετά την εισαγωγή;**

Ναι. Τα αρχικά pixel διατηρούνται, αλλά η τελική εμφάνιση εξαρτάται από το πώς η [εικόνα](/slides/el/net/picture-frame/) κλιμακώνεται στη διαφάνεια και τυχόν συμπίεση που εφαρμόζεται κατά την αποθήκευση.

**Ποιος είναι ο καλύτερος τρόπος για να αντικαταστήσετε το ίδιο λογότυπο σε δεκάδες διαφάνειες ταυτόχρονα;**

Τοποθετήστε το λογότυπο στη master διαφάνεια ή σε μια διάταξη και αντικαταστήστε το στη συλλογή εικόνων της παρουσίασης — οι ενημερώσεις θα διαχυθούν σε όλα τα στοιχεία που χρησιμοποιούν αυτόν τον πόρο.

**Μπορεί ένα εισαχθέν SVG να μετατραπεί σε επεξεργάσιμα σχήματα;**

Ναι. Μπορείτε να μετατρέψετε ένα SVG σε ομάδα σχημάτων, μετά τα άτομα μέρη γίνονται επεξεργάσιμα με τις τυπικές ιδιότητες σχήματος.

**Πώς μπορώ να ορίσω μια εικόνα ως υπόβαθρο για πολλές διαφάνειες ταυτόχρονα;**

[Ορίστε την εικόνα ως υπόβαθρο](/slides/el/net/presentation-background/) στη master διαφάνεια ή στην αντίστοιχη διάταξη — οποιεσδήποτε διαφάνειες χρησιμοποιούν αυτό το master/διάταξη θα κληρονομήσουν το υπόβαθρο.

**Πώς μπορώ να αποτρέψω την παρουσίαση από το να «φουσκώνει» σε μέγεθος λόγω πολλών εικόνων;**

Ξαναχρησιμοποιήστε έναν μοναδικό πόρο εικόνας αντί για διπλότυπα, επιλέξτε λογικές αναλύσεις, εφαρμόστε συμπίεση κατά την αποθήκευση και διατηρήστε τα επαναλαμβανόμενα γραφικά στο master όπου είναι κατάλληλο.