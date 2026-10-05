---
title: Διαχείριση Αντικειμένων OLE σε Παρουσιάσεις στο .NET
linktitle: Διαχείριση OLE
type: docs
weight: 40
url: /el/net/manage-ole/
keywords:
- Αντικείμενο OLE
- Σύνδεση & Ενσωμάτωση Αντικειμένων
- προσθήκη OLE
- ενσωμάτωση OLE
- προσθήκη αντικειμένου
- ενσωμάτωση αντικειμένου
- προσθήκη αρχείου
- ενσωμάτωση αρχείου
- συνδεδεμένο αντικείμενο
- συνδεδεμένο αρχείο
- αλλαγή OLE
- εικονίδιο OLE
- τίτλος OLE
- εξαγωγή OLE
- εξαγωγή αντικειμένου
- εξαγωγή αρχείου
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Βελτιστοποιήστε τη διαχείριση αντικειμένων OLE σε αρχεία PowerPoint και OpenDocument με το Aspose.Slides για .NET. Ενσωματώστε, ενημερώστε και εξάγετε το περιεχόμενο OLE άψογα."
---
## **Εισαγωγή**

{{% alert color="info" title="Σημείωση" %}}

OLE (Object Linking & Embedding) είναι τεχνολογία της Microsoft που επιτρέπει τα δεδομένα και τα αντικείμενα που δημιουργούνται σε μια εφαρμογή να τοποθετούνται σε άλλη εφαρμογή μέσω σύνδεσης ή ενσωμάτωσης. 

{{% /alert %}} 

Θεωρήστε ένα διάγραμμα που δημιουργήθηκε στο MS Excel. Το διάγραμμα τοποθετείται στη συνέχεια σε μια διαφάνεια του PowerPoint. Αυτό το διάγραμμα Excel θεωρείται αντικείμενο OLE. 

- Ένα αντικείμενο OLE μπορεί να εμφανίζεται ως εικονίδιο. Σε αυτήν την περίπτωση, όταν κάνετε διπλό κλικ στο εικονίδιο, το διάγραμμα ανοίγει στην σχετική του εφαρμογή (Excel), ή σας ζητείται να επιλέξετε μια εφαρμογή για το άνοιγμα ή την επεξεργασία του αντικειμένου. 
- Ένα αντικείμενο OLE μπορεί να εμφανίζει το πραγματικό του περιεχόμενο, όπως τα περιεχόμενα ενός διαγράμματος. Σε αυτήν την περίπτωση, το διάγραμμα ενεργοποιείται στο PowerPoint, φορτώνεται η διεπαφή του διαγράμματος και μπορείτε να τροποποιήσετε τα δεδομένα του διαγράμματος εντός του PowerPoint.

[Aspose.Slides for .NET](https://products.aspose.com/slides/net/) σας επιτρέπει να εισάγετε OLE Objects σε διαφάνειες ως πλαίσια αντικειμένων OLE ([OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)).

## **Προσθήκη Πλαισίων Αντικειμένων OLE σε Διαφάνειες**

Υποθέτοντας ότι έχετε ήδη δημιουργήσει ένα διάγραμμα στο Microsoft Excel και θέλετε να το ενσωματώσετε σε μια διαφάνεια ως πλαίσιο αντικειμένου OLE χρησιμοποιώντας το Aspose.Slides for .NET, μπορείτε να το κάνετε ως εξής:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της.
3. Διαβάστε το αρχείο Excel ως πίνακα byte.
4. Προσθέστε το [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) στη διαφάνεια που περιέχει τον πίνακα byte και άλλες πληροφορίες για το αντικείμενο OLE.
5. Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, προσθέσαμε ένα διάγραμμα από αρχείο Excel σε μια διαφάνεια ως [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) χρησιμοποιώντας το Aspose.Slides για .NET.  
**Σημείωση** ότι ο κατασκευαστής [OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/) δέχεται μια επέκταση ενσωματώσιμου αντικειμένου ως δεύτερη παράμετρο. Αυτή η επέκταση επιτρέπει στο PowerPoint να ερμηνεύει σωστά τον τύπο αρχείου και να επιλέγει τη σωστή εφαρμογή για το άνοιγμα του αντικειμένου OLE.

```csharp 
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    SizeF slideSize = presentation.SlideSize.Size;
    ISlide slide = presentation.Slides[0];

    // Προετοιμασία δεδομένων για το αντικείμενο OLE.
    byte[] fileData = File.ReadAllBytes("book.xlsx");
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

    // Προσθήκη του πλαισίου αντικειμένου OLE στη διαφάνεια.
    slide.Shapes.AddOleObjectFrame(0, 0, slideSize.Width, slideSize.Height, dataInfo);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

### **Προσθήκη Συνδεδεμένων Πλαισίων OLE Object**

Το Aspose.Slides for .NET σας επιτρέπει να προσθέσετε ένα [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) χωρίς ενσωμάτωση δεδομένων, αλλά μόνο με σύνδεσμο προς το αρχείο.

Αυτός ο κώδικας C# δείχνει πώς να προσθέσετε ένα [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) με ένα συνδεδεμένο αρχείο Excel σε μια διαφάνεια:

```csharp 
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Προσθήκη πλαισίου αντικειμένου OLE με συνδεδεμένο αρχείο Excel.
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Πρόσβαση σε Πλαίσια Αντικειμένων OLE**

Αν ένα αντικείμενο OLE είναι ήδη ενσωματωμένο σε μια διαφάνεια, μπορείτε εύκολα να το βρείτε ή να το προσπελάσετε ως εξής:

1. Φορτώστε μια παρουσίαση με το ενσωματωμένο αντικείμενο OLE δημιουργώντας ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Λάβετε την αναφορά της διαφάνειας χρησιμοποιώντας το δείκτη της.
3. Πρόσβαση στο σχήμα [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe). Στο παράδειγμά μας, χρησιμοποιήσαμε το προηγούμενο δημιουργημένο PPTX που έχει μόνο ένα σχήμα στην πρώτη διαφάνεια. Στη συνέχεια *cast* (μετατρέπουμε) αυτό το αντικείμενο σε ένα [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe). Αυτό ήταν το επιθυμητό πλαίσιο αντικειμένου OLE που θέλουμε να προσεγγίσουμε.
4. Μόλις το πλαίσιο αντικειμένου OLE προσεγγιστεί, μπορείτε να εκτελέσετε οποιαδήποτε λειτουργία πάνω του.

Στο παρακάτω παράδειγμα, ένα πλαίσιο αντικειμένου OLE (ένα αντικείμενο διαγράμματος Excel ενσωματωμένο σε διαφάνεια) και τα δεδομένα του αρχείου του προσεγγίζονται.

```csharp 
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Λάβετε το πρώτο σχήμα ως πλαίσιο αντικειμένου OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        // Λάβετε τα ενσωματωμένα δεδομένα αρχείου.
        byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

        // Λάβετε την επέκταση του ενσωματωμένου αρχείου.
        string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

        // ...
    }
}
```

### **Πρόσβαση στις Ιδιότητες Συνδεδεμένου Πλαισίου OLE Object**

Το Aspose.Slides σας επιτρέπει να προσπελάσετε τις ιδιότητες συνδεδεμένου πλαισίου OLE αντικειμένου.

Αυτός ο κώδικας C# δείχνει πώς να ελέγξετε αν ένα αντικείμενο OLE είναι συνδεδεμένο και στη συνέχεια να αποκτήσετε τη διαδρομή του συνδεδεμένου αρχείου:

```csharp
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.ppt"))
{
    ISlide slide = presentation.Slides[0];

    // Λάβετε το πρώτο σχήμα ως πλαίσιο αντικειμένου OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    // Ελέγξτε αν το αντικείμενο OLE είναι συνδεδεμένο.
    if (oleFrame != null && oleFrame.IsObjectLink)
    {
        // Εκτυπώστε την πλήρη διαδρομή του συνδεδεμένου αρχείου.
        Console.WriteLine("OLE object frame is linked to: " + oleFrame.LinkPathLong);

        // Εκτυπώστε τη σχετική διαδρομή του συνδεδεμένου αρχείου εάν υπάρχει.
        // Μόνο οι παρουσιάσεις PPT μπορούν να περιέχουν τη σχετική διαδρομή.
        if (!string.IsNullOrEmpty(oleFrame.LinkPathRelative))
        {
            Console.WriteLine("OLE object frame relative path: " + oleFrame.LinkPathRelative);
        }
    }
}
```

## **Αλλαγή Δεδομένων Αντικειμένου OLE**

{{% alert color="info" title="Σημείωση" %}}

Σε αυτήν την ενότητα, το παρακάτω παράδειγμα κώδικα χρησιμοποιεί το [Aspose.Cells for .NET](https://docs.aspose.com/cells/net/).

{{% /alert %}}

Αν ένα αντικείμενο OLE είναι ήδη ενσωματωμένο σε μια διαφάνεια, μπορείτε εύκολα να προσεγγίσετε αυτό το αντικείμενο και να τροποποιήσετε τα δεδομένα του ως εξής:

1. Φορτώστε μια παρουσίαση με το ενσωματωμένο αντικείμενο OLE δημιουργώντας ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Λάβετε την αναφορά της διαφάνειας μέσω του δείκτη της. 
3. Πρόσβαση στο σχήμα [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe). Στο παράδειγμά μας, χρησιμοποιήσαμε το προηγούμενο δημιουργημένο PPTX που έχει ένα σχήμα στην πρώτη διαφάνεια. Στη συνέχεια *cast* (μετατρέπουμε) αυτό το αντικείμενο σε ένα [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe). Αυτό ήταν το επιθυμητό πλαίσιο αντικειμένου OLE που θέλουμε να προσεγγίσουμε.
4. Μόλις το πλαίσιο αντικειμένου OLE προσεγγιστεί, μπορείτε να εκτελέσετε οποιαδήποτε λειτουργία επάνω του.
5. Δημιουργήστε ένα αντικείμενο `Workbook` και προσεγγίστε τα δεδομένα OLE.
6. Προσεγγίστε το επιθυμητό `Worksheet` και τροποποιήστε τα δεδομένα.
7. Αποθηκεύστε το ενημερωμένο `Workbook` σε ροή.
8. Αλλάξτε τα δεδομένα του αντικειμένου OLE από τη ροή.

Στο παρακάτω παράδειγμα, ένα πλαίσιο αντικειμένου OLE (ένα αντικείμενο διαγράμματος Excel ενσωματωμένο σε διαφάνεια) προσεγγίζεται και τα δεδομένα του αρχείου του τροποποιούνται για την ενημέρωση των δεδομένων του διαγράμματος.

```csharp 
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Λάβετε το πρώτο σχήμα ως πλαίσιο αντικειμένου OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        using (MemoryStream oleStream = new MemoryStream(oleFrame.EmbeddedData.EmbeddedFileData))
        {
            // Διαβάστε τα δεδομένα του αντικειμένου OLE ως αντικείμενο Workbook.
            Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook(oleStream);

            using (MemoryStream newOleStream = new MemoryStream())
            {
                // Τροποποιήστε τα δεδομένα του βιβλίου εργασίας.
                workbook.Worksheets[0].Cells[0, 4].PutValue("E");
                workbook.Worksheets[0].Cells[1, 4].PutValue(12);
                workbook.Worksheets[0].Cells[2, 4].PutValue(14);
                workbook.Worksheets[0].Cells[3, 4].PutValue(15);

                Aspose.Cells.OoxmlSaveOptions fileOptions = new Aspose.Cells.OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
                workbook.Save(newOleStream, fileOptions);

                // Αλλάξτε τα δεδομένα του αντικειμένου πλαισίου OLE.
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.ToArray(), oleFrame.EmbeddedData.EmbeddedFileExtension);
                oleFrame.SetEmbeddedData(newData);
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Ενσωμάτωση Άλλων Τύπων Αρχείων σε Διαφάνειες**

Εκτός από διαγράμματα Excel, το Aspose.Slides for .NET σας επιτρέπει να ενσωματώσετε άλλα είδη αρχείων σε διαφάνειες. Για παράδειγμα, μπορείτε να εισάγετε αρχεία HTML, PDF και ZIP ως αντικείμενα. Όταν ένας χρήστης κάνει διπλό κλικ στο εισαχθέν αντικείμενο, ανοίγει αυτόματα στο αντίστοιχο πρόγραμμα, ή ο χρήστης ερωτάται να επιλέξει ένα κατάλληλο πρόγραμμα για το άνοιγμα του.

Αυτός ο κώδικας C# δείχνει πώς να ενσωματώσετε HTML και ZIP σε μια διαφάνεια:

```c#
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    byte[] htmlData = File.ReadAllBytes("sample.html");
    IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
    IOleObjectFrame htmlOleFrame = slide.Shapes.AddOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
    htmlOleFrame.IsObjectIcon = true;

    byte[] zipData = File.ReadAllBytes("sample.zip");
    IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
    IOleObjectFrame zipOleFrame = slide.Shapes.AddOleObjectFrame(150, 220, 50, 50, zipDataInfo);
    zipOleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Ορισμός Τύπων Αρχείων για Ενσωματωμένα Αντικείμενα**

Κατά την εργασία με παρουσιάσεις, μπορεί να χρειαστεί να αντικαταστήσετε παλιά αντικείμενα OLE με νέα ή να αντικαταστήσετε ένα μη υποστηριζόμενο αντικείμενο OLE με ένα υποστηριζόμενο. Το Aspose.Slides for .NET σας επιτρέπει να ορίσετε τον τύπο αρχείου για ένα ενσωματωμένο αντικείμενο, επιτρέποντάς σας να ενημερώσετε τα δεδομένα του πλαισίου OLE ή την επέκτασή του.

Αυτός ο κώδικας C# δείχνει πώς να ορίσετε τον τύπο αρχείου για ένα ενσωματωμένο αντικείμενο OLE σε `zip`:

```c#
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;
    byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

    Console.WriteLine($"Current embedded file extension is: {fileExtension}");

    // Αλλάξτε τον τύπο αρχείου σε ZIP.
    oleFrame.SetEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Ορισμός Εικόνων Εικονιδίων και Τίτλων για Ενσωματωμένα Αντικείμενα**

Μετά την ενσωμάτωση ενός αντικειμένου OLE, προστίθεται αυτόματα μια προεπισκόπηση που αποτελείται από εικόνα εικονιδίου. Αυτή η προεπισκόπηση είναι αυτό που βλέπουν οι χρήστες πριν προσπελάσουν ή ανοίξουν το αντικείμενο OLE. Εάν θέλετε να χρησιμοποιήσετε μια συγκεκριμένη εικόνα και κείμενο ως στοιχεία στην προεπισκόπηση, μπορείτε να ορίσετε την εικόνα εικονιδίου και τον τίτλο χρησιμοποιώντας το Aspose.Slides for .NET.

Αυτός ο κώδικας C# δείχνει πώς να ορίσετε την εικόνα εικονιδίου και τον τίτλο για ένα ενσωματωμένο αντικείμενο: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    // Προσθήκη εικόνας στους πόρους της παρουσίασης.
    byte[] imageData = File.ReadAllBytes("image.png");
    IPPImage oleImage = presentation.Images.AddImage(imageData);

    // Ορισμός τίτλου και εικόνας για την προεπισκόπηση OLE.
    oleFrame.SubstitutePictureTitle = "My title";
    oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Αποτροπή Αλλαγής Μεγέθους και Θέσης Πλαισίου OLE Object**

Αφού προσθέσετε ένα συνδεδεμένο αντικείμενο OLE σε μια διαφάνεια παρουσίασης, όταν ανοίξετε την παρουσίαση στο PowerPoint, μπορεί να εμφανιστεί μήνυμα που σας ζητά να ενημερώσετε τους συνδέσμους. Κάνοντας κλικ στο κουμπί «Update Links» (Ενημέρωση Συνδέσμων) ενδέχεται να αλλάξει το μέγεθος και η θέση του πλαισίου αντικειμένου OLE, επειδή το PowerPoint ενημερώνει τα δεδομένα από το συνδεδεμένο αντικείμενο OLE και ανανεώνει την προεπισκόπηση του αντικειμένου. Για να αποτρέψετε το PowerPoint από την προτροπή ενημέρωσης των δεδομένων του αντικειμένου, ορίστε την ιδιότητα `UpdateAutomatic` της διεπαφής [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/) σε `false`:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IOleObjectFrame oleFrame = (IOleObjectFrame)presentation.Slides[0].Shapes[0];

    // Διατηρήστε το μέγεθος και τη θέση του πλαισίου αντικειμένου OLE όταν το PowerPoint ενημερώνει τη σύνδεση.
    oleFrame.UpdateAutomatic = false;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Εξαγωγή Ενσωματωμένων Αρχείων**

Το Aspose.Slides for .NET σας επιτρέπει να εξάγετε τα αρχεία που είναι ενσωματωμένα σε διαφάνειες ως αντικείμενα OLE με τον εξής τρόπο:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) που περιέχει τα αντικείμενα OLE που σκοπεύετε να εξάγετε.
2. Επαναλάβετε (διασχίστε) όλα τα σχήματα στην παρουσίαση και προσεγγίστε τα σχήματα [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe).
3. Προσεγγίστε τα δεδομένα των ενσωματωμένων αρχείων από τα πλαίσια αντικειμένων OLE και γράψτε τα στον δίσκο.

Αυτός ο κώδικας C# δείχνει πώς να εξάγετε αρχεία ενσωματωμένα σε μια διαφάνεια ως αντικείμενα OLE:

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    for (int index = 0; index < slide.Shapes.Count; index++)
    {
        IShape shape = slide.Shapes[index];
        IOleObjectFrame oleFrame = shape as IOleObjectFrame;

        if (oleFrame != null)
        {
            byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;
            string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

            string filePath = $"OLE_object_{index}{fileExtension}";
            File.WriteAllBytes(filePath, fileData);
        }
    }
}
```

## **Συχνές Ερωτήσεις**

**Θα αποδοθεί το περιεχόμενο OLE κατά την εξαγωγή των διαφανειών σε PDF/εικόνες;**

Αυτό που είναι ορατό στη διαφάνεια αποδίδεται—το εικονίδιο/εικόνα αντικατάστασης (προεπισκόπηση). Το «ζωντανό» περιεχόμενο OLE δεν εκτελείται κατά την απόδοση. Εάν χρειάζεται, ορίστε τη δική σας εικόνα προεπισκόπης για να εξασφαλίσετε την αναμενόμενη εμφάνιση στο εξαχθέν PDF.

Για να διατηρήσετε επίσης το ενσωματωμένο αρχείο ως συνημμένο PDF, ορίστε το [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) σε `true`. Αυτή η επιλογή είναι απενεργοποιημένη εξ ορισμού. Για ένα παράδειγμα και οδηγίες ελέγχου του συνημμένου, δείτε [Preserve Embedded OLE Files as PDF Attachments](/slides/el/net/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Πώς μπορώ να κλειδώσω ένα αντικείμενο OLE σε μια διαφάνεια ώστε οι χρήστες να μην μπορούν να το μετακινήσουν/επεξεργαστούν στο PowerPoint;**

Κλειδώστε το σχήμα: Το Aspose.Slides παρέχει [shape-level locks](/slides/el/net/applying-protection-to-presentation/). Αυτό δεν είναι κρυπτογράφηση, αλλά εμποδίζει αποτελεσματικά τυχαίες επεμβάσεις και μετακινήσεις.

**Γιατί ένα συνδεδεμένο αντικείμενο Excel «πηδά» ή αλλάζει μέγεθος όταν ανοίγω την παρουσίαση;**

Το PowerPoint μπορεί να ανανεώσει την προεπισκόπηση του συνδεδεμένου OLE. Για σταθερή εμφάνιση, ακολουθήστε τις πρακτικές του [Working Solution for Worksheet Resizing](/slides/el/net/working-solution-for-worksheet-resizing/)—είτε να προσαρμόσετε το πλαίσιο στο εύρος, είτε να κλιμακώσετε το εύρος σε ένα σταθερό πλαίσιο και να ορίσετε κατάλληλη εικόνα αντικατάστασης.

**Θα διατηρηθούν οι σχετικές διαδρομές για συνδεδεμένα αντικείμενα OLE στη μορφή PPTX;**

Στο PPTX, οι πληροφορίες «σχετική διαδρομή» δεν είναι διαθέσιμες—υπάρχει μόνο η πλήρης διαδρομή. Οι σχετικές διαδρομές υπάρχουν μόνο στην παλαιότερη μορφή PPT. Για φορητότητα, προτιμήστε αξιόπιστες απόλυτες διαδρομές/προσβάσιμα URIs ή ενσωμάτωση.