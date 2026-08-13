---
title: Διαχείριση αντικειμένων OLE σε παρουσιάσεις στο .NET
linktitle: Διαχείριση OLE
type: docs
weight: 40
url: /el/net/manage-ole/
keywords:
- αντικείμενο OLE
- Σύνδεση & Ενσωμάτωση αντικειμένων
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
description: "Βελτιστοποιήστε τη διαχείριση αντικειμένων OLE σε αρχεία PowerPoint και OpenDocument με τη χρήση Aspose.Slides for .NET. Ενσωματώστε, ενημερώστε και εξάγετε το περιεχόμενο OLE απρόσκοπτα."
---
## **Εισαγωγή**

{{% alert title="Info" color="info" %}}

OLE (Object Linking & Embedding) είναι μια τεχνολογία της Microsoft που επιτρέπει να τοποθετούνται δεδομένα και αντικείμενα που δημιουργήθηκαν σε μία εφαρμογή σε άλλη εφαρμογή μέσω σύνδεσης ή ενσωμάτωσης. 

{{% /alert %}} 

Θεωρήστε ένα γράφημα που δημιουργήθηκε στο MS Excel. Το γράφημα τοποθετείται μέσα σε μια διαφάνεια PowerPoint. Αυτό το γράφημα Excel θεωρείται αντικείμενο OLE. 

- Ένα αντικείμενο OLE μπορεί να εμφανίζεται ως εικονίδιο. Σε αυτήν την περίπτωση, όταν κάνετε διπλό κλικ στο εικονίδιο, το γράφημα ανοίγει στην αντίστοιχη εφαρμογή (Excel), ή σας ζητείται να επιλέξετε μια εφαρμογή για το άνοιγμα ή την επεξεργασία του αντικειμένου. 
- Ένα αντικείμενο OLE μπορεί να εμφανίζει το πραγματικό του περιεχόμενο, όπως τα στοιχεία ενός γραφήματος. Σε αυτήν την περίπτωση, το γράφημα ενεργοποιείται στο PowerPoint, το περιβάλλον γραφήματος φορτώνει και μπορείτε να τροποποιήσετε τα δεδομένα του γραφήματος μέσα στο PowerPoint.

[Aspose.Slides for .NET](https://products.aspose.com/slides/el/net/) σας επιτρέπει να προσθέσετε αντικείμενα OLE στις διαφάνειες ως πλαίσια αντικειμένων OLE ([OleObjectFrame](https://reference.aspose.com/slides/el/net/aspose.slides/oleobjectframe)).

## **Προσθήκη πλαισίων αντικειμένων OLE στις διαφάνειες**

Υποθέτοντας ότι έχετε ήδη δημιουργήσει ένα γράφημα στο Microsoft Excel και θέλετε να το ενσωματώσετε σε μια διαφάνεια ως πλαίσιο αντικειμένου OLE χρησιμοποιώντας Aspose.Slides for .NET, μπορείτε να το κάνετε ως εξής:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
2. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της.
3. Διαβάστε το αρχείο Excel ως πίνακα byte.
4. Προσθέστε το [OleObjectFrame](https://reference.aspose.com/slides/el/net/aspose.slides/oleobjectframe) στη διαφάνεια με τον πίνακα byte και άλλες πληροφορίες για το αντικείμενο OLE.
5. Γράψτε την τροποποιημένη παρουσία ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, προσθέσαμε ένα γράφημα από αρχείο Excel σε μια διαφάνεια ως [OleObjectFrame](https://reference.aspose.com/slides/el/net/aspose.slides/oleobjectframe) χρησιμοποιώντας Aspose.Slides for .NET.  
**Note** ότι ο κατασκευαστής [OleEmbeddedDataInfo](https://reference.aspose.com/slides/el/net/aspose.slides.dom.ole/oleembeddeddatainfo/) δέχεται μια επέκταση ενσωματωμένου αντικειμένου ως δεύτερο παράμετρο. Αυτή η επέκταση επιτρέπει στο PowerPoint να ερμηνεύει σωστά τον τύπο του αρχείου και να επιλέγει τη σωστή εφαρμογή για το άνοιγμα του αντικειμένου OLE.

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

    // Προσθήκη πλαισίου αντικειμένου OLE στη διαφάνεια.
    slide.Shapes.AddOleObjectFrame(0, 0, slideSize.Width, slideSize.Height, dataInfo);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

### **Προσθήκη συνδεδεμένων πλαισίων αντικειμένων OLE**

Aspose.Slides for .NET σας επιτρέπει να προσθέσετε ένα [OleObjectFrame](https://reference.aspose.com/slides/el/net/aspose.slides/oleobjectframe) χωρίς ενσωμάτωση δεδομένων, αλλά μόνο με σύνδεσμο προς το αρχείο.

Αυτός ο κώδικας C# δείχνει πώς να προσθέσετε ένα [OleObjectFrame](https://reference.aspose.com/slides/el/net/aspose.slides/oleobjectframe) με συνδεδεμένο αρχείο Excel σε μια διαφάνεια:

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

## **Πρόσβαση σε πλαίσια αντικειμένων OLE**

Εάν ένα αντικείμενο OLE είναι ήδη ενσωματωμένο σε μια διαφάνεια, μπορείτε εύκολα να το εντοπίσετε ή να το προσπελάσετε ως εξής:

1. Φορτώστε μια παρουσία με το ενσωματωμένο αντικείμενο OLE δημιουργώντας μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
2. Λάβετε την αναφορά της διαφάνειας χρησιμοποιώντας τον δείκτη της.
3. Προσπελάστε το σχήμα [OleObjectFrame](https://reference.aspose.com/slides/el/net/aspose.slides/oleobjectframe). Στο παράδειγμά μας, χρησιμοποιήσαμε το προηγουμένως δημιουργημένο PPTX που έχει μόνο ένα σχήμα στην πρώτη διαφάνεια. Στη συνέχεια *cast* το αντικείμενο ως [IOleObjectFrame](https://reference.aspose.com/slides/el/net/aspose.slides/ioleobjectframe). Αυτό ήταν το ζητούμενο πλαίσιο αντικειμένου OLE για πρόσβαση.
4. Μόλις προσεγγιστεί το πλαίσιο αντικειμένου OLE, μπορείτε να εκτελέσετε οποιαδήποτε λειτουργία σε αυτό.

Στο παρακάτω παράδειγμα, προσεγγίζεται ένα πλαίσιο αντικειμένου OLE (ένα αντικείμενο γραφήματος Excel ενσωματωμένο σε μια διαφάνεια) και τα δεδομένα του αρχείου του.

```csharp 
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Λάβετε το πρώτο σχήμα ως πλαίσιο αντικειμένου OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        // Λάβετε τα δεδομένα του ενσωματωμένου αρχείου.
        byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

        // Λάβετε την επέκταση του ενσωματωμένου αρχείου.
        string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

        // ...
    }
}
```

### **Πρόσβαση σε ιδιότητες συνδεδεμένου πλαισίου αντικειμένου OLE**

Aspose.Slides σας επιτρέπει να προβάλετε τις ιδιότητες του συνδεδεμένου πλαισίου αντικειμένου OLE.

Αυτός ο κώδικας C# δείχνει πώς να ελέγξετε αν ένα αντικείμενο OLE είναι συνδεδεμένο και στη συνέχεια να λάβετε τη διαδρομή του συνδεδεμένου αρχείου:

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
        // Εκτυπώστε τη πλήρη διαδρομή του συνδεδεμένου αρχείου.
        Console.WriteLine("OLE object frame is linked to: " + oleFrame.LinkPathLong);

        // Εκτυπώστε τη σχετική διαδρομή του συνδεδεμένου αρχείου αν υπάρχει.
        // Μόνο οι παρουσιάσεις PPT μπορούν να περιέχουν τη σχετική διαδρομή.
        if (!string.IsNullOrEmpty(oleFrame.LinkPathRelative))
        {
            Console.WriteLine("OLE object frame relative path: " + oleFrame.LinkPathRelative);
        }
    }
}
```

## **Αλλαγή δεδομένων αντικειμένου OLE**

{{% alert color="info" %}} 

Σε αυτήν την ενότητα, το παράδειγμα κώδικα παρακάτω χρησιμοποιεί [Aspose.Cells for .NET](/cells/net/).

{{% /alert %}}

Εάν ένα αντικείμενο OLE είναι ήδη ενσωματωμένο σε μια διαφάνεια, μπορείτε εύκολα να το προσεγγίσετε και να τροποποιήσετε τα δεδομένα του ως εξής:

1. Φορτώστε μια παρουσία με το ενσωματωμένο αντικείμενο OLE δημιουργώντας μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
2. Λάβετε την αναφορά της διαφάνειας μέσω του δείκτη της. 
3. Προσπελάστε το σχήμα [OLEObjectFrame](https://reference.aspose.com/slides/el/net/aspose.slides/oleobjectframe). Στο παράδειγμά μας, χρησιμοποιήσαμε το προηγουμένως δημιουργημένο PPTX που έχει ένα σχήμα στην πρώτη διαφάνεια. Στη συνέχεια *cast* το αντικείμενο ως [IOleObjectFrame](https://reference.aspose.com/slides/el/net/aspose.slides/ioleobjectframe). Αυτό ήταν το ζητούμενο πλαίσιο αντικειμένου OLE για πρόσβαση.
4. Μόλις προσεγγιστεί το πλαίσιο αντικειμένου OLE, μπορείτε να εκτελέσετε οποιαδήποτε λειτουργία σε αυτό.
5. Δημιουργήστε ένα αντικείμενο `Workbook` και προσπελάστε τα δεδομένα OLE.
6. Προσπελάστε το επιθυμητό `Worksheet` και τροποποιήστε τα δεδομένα.
7. Αποθηκεύστε το ενημερωμένο `Workbook` σε μία ροή.
8. Αλλάξτε τα δεδομένα του αντικειμένου OLE από τη ροή.

Στο παρακάτω παράδειγμα, προσεγγίζεται ένα πλαίσιο αντικειμένου OLE (ένα αντικείμενο γραφήματος Excel ενσωματωμένο σε μια διαφάνεια) και τα δεδομένα του αρχείου τροποποιούνται ώστε να ενημερωθούν τα δεδομένα του γραφήματος.

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
                // Τροποποίηση των δεδομένων του workbook.
                workbook.Worksheets[0].Cells[0, 4].PutValue("E");
                workbook.Worksheets[0].Cells[1, 4].PutValue(12);
                workbook.Worksheets[0].Cells[2, 4].PutValue(14);
                workbook.Worksheets[0].Cells[3, 4].PutValue(15);

                Aspose.Cells.OoxmlSaveOptions fileOptions = new Aspose.Cells.OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
                workbook.Save(newOleStream, fileOptions);

                // Αλλαγή των δεδομένων του αντικειμένου πλαισίου OLE.
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.ToArray(), oleFrame.EmbeddedData.EmbeddedFileExtension);
                oleFrame.SetEmbeddedData(newData);
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Ενσωμάτωση άλλων τύπων αρχείων σε διαφάνειες**

Εκτός από γραφήματα Excel, Aspose.Slides for .NET σας επιτρέπει να ενσωματώσετε άλλα είδη αρχείων σε διαφάνειες. Για παράδειγμα, μπορείτε να εισάγετε HTML, PDF και ZIP αρχεία ως αντικείμενα. Όταν ένας χρήστης κάνει διπλό κλικ στο εισαχθέν αντικείμενο, ανοίγει αυτόματα στο σχετικό πρόγραμμα ή του ζητείται να επιλέξει κατάλληλο πρόγραμμα για το άνοιγμα.

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

## **Ορισμός τύπων αρχείων για ενσωματωμένα αντικείμενα**

Κατά την εργασία με παρουσιάσεις, μπορεί να χρειαστεί να αντικαταστήσετε παλιά αντικείμενα OLE με νέα ή να αντικαταστήσετε ένα μη υποστηριζόμενο αντικείμενο OLE με ένα υποστηριζόμενο. Aspose.Slides for .NET σας επιτρέπει να ορίσετε τον τύπο αρχείου για ένα ενσωματωμένο αντικείμενο, επιτρέποντάς σας να ενημερώσετε τα δεδομένα πλαισίου OLE ή την επέκτασή του.

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

    // Αλλάξτε τον τύπο του αρχείου σε ZIP.
    oleFrame.SetEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Ορισμός εικόνων εικονιδίου και τίτλων για ενσωματωμένα αντικείμενα**

Μετά την ενσωμάτωση ενός αντικειμένου OLE, προστίθεται αυτόματα μια προεπισκόπηση που αποτελείται από εικόνα εικονιδίου. Αυτή η προεπισκόπηση είναι ό,τι βλέπουν οι χρήστες πριν προσεγγίσουν ή ανοίξουν το αντικείμενο OLE. Εάν θέλετε να χρησιμοποιήσετε συγκεκριμένη εικόνα και κείμενο ως στοιχεία στην προεπισκόπηση, μπορείτε να ορίσετε την εικόνα εικονιδίου και τον τίτλο χρησιμοποιώντας Aspose.Slides for .NET.

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

    // Ορίστε έναν τίτλο και την εικόνα για την προεπισκόπηση OLE.
    oleFrame.SubstitutePictureTitle = "My title";
    oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Αποτροπή αλλαγής μεγέθους και θέσης πλαισίου αντικειμένου OLE**

Αφού προσθέσετε ένα συνδεδεμένο αντικείμενο OLE σε μια διαφάνεια παρουσίασης, όταν ανοίγετε την παρουσίαση στο PowerPoint, μπορεί να εμφανιστεί μήνυμα που σας ζητά να ενημερώσετε τους συνδέσμους. Πατώντας το κουμπί «Update Links» μπορεί να αλλάξει το μέγεθος και η θέση του πλαισίου αντικειμένου OLE επειδή το PowerPoint ενημερώνει τα δεδομένα από το συνδεδεμένο αντικείμενο OLE και ανανεώνει την προεπισκόπηση. Για να αποτρέψετε το PowerPoint από το να ζητά την ενημέρωση των δεδομένων του αντικειμένου, ορίστε την ιδιότητα `UpdateAutomatic` του διεπαφής [IOleObjectFrame](https://reference.aspose.com/slides/el/net/aspose.slides/ioleobjectframe/) σε `false`:

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

## **Εξαγωγή ενσωματωμένων αρχείων**

Aspose.Slides for .NET σας επιτρέπει να εξάγετε τα αρχεία που είναι ενσωματωμένα σε διαφάνειες ως αντικείμενα OLE ως εξής:
1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) που περιέχει τα αντικείμενα OLE που θέλετε να εξαγάγετε.
2. Διαπεράστε όλα τα σχήματα στην παρουσία και προσπελάστε τα σχήματα [OLEObjectFrame](https://reference.aspose.com/slides/el/net/aspose.slides/oleobjectframe).
3. Προσπελάστε τα δεδομένα των ενσωματωμένων αρχείων από τα πλαίσια αντικειμένων OLE και γράψτε τα στο δίσκο.

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

## **Συχνές ερωτήσεις**

### Θα αποδοθεί το περιεχόμενο OLE κατά την εξαγωγή διαφανειών σε PDF/εικόνες;

Αυτό που είναι ορατό στη διαφάνεια αποδίδεται — το εικονίδιο/εικόνα προεπισκόπησης. Το «ζωντανό» περιεχόμενο OLE δεν εκτελείται κατά την απόδοση. Αν χρειάζεται, ορίστε τη δική σας εικόνα προεπισκόπησης για να διασφαλίσετε την αναμενόμενη εμφάνιση στο εξαγόμενο PDF.

### Πώς μπορώ να κλειδώσω ένα αντικείμενο OLE σε μια διαφάνεια ώστε οι χρήστες να μην μπορούν να το μετακινήσουν/επεξεργαστούν στο PowerPoint;

Κλειδώστε το σχήμα: το Aspose.Slides παρέχει [shape-level locks](/slides/el/net/applying-protection-to-presentation/). Αυτό δεν είναι κρυπτογράφηση, αλλά αποτρέπει αποτελεσματικά τυχαίες επεξεργασίες και μετακινήσεις.

### Γιατί ένα συνδεδεμένο αντικείμενο Excel «πηδά» ή αλλάζει μέγεθος όταν ανοίγω την παρουσίαση;

Το PowerPoint μπορεί να ανανεώσει την προεπισκόπηση του συνδεδεμένου OLE. Για σταθερή εμφάνιση, ακολουθήστε τις πρακτικές του [Working Solution for Worksheet Resizing](/slides/el/net/working-solution-for-worksheet-resizing/) — είτε προσαρμόστε το πλαίσιο στην περιοχή, είτε κλιμακώστε την περιοχή σε σταθερό πλαίσιο και ορίστε κατάλληλη εικόνα αντικατάστασης.

### Θα διατηρηθούν οι σχετικές διαδρομές για συνδεδεμένα αντικείμενα OLE στη μορφή PPTX;

Στο PPTX, οι πληροφορίες «σχετικής διαδρομής» δεν είναι διαθέσιμες — μόνο η πλήρης διαδρομή. Οι σχετικές διαδρομές βρίσκονται στην παλαιότερη μορφή PPT. Για φορητότητα, προτιμήστε αξιόπιστες απόλυτες διαδρομές/προσβάσιμα URI ή ενσωμάτωση.