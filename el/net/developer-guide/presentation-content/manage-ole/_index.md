---
title: Διαχείριση αντικειμένων OLE σε παρουσιάσεις σε .NET
linktitle: Διαχείριση OLE
type: docs
weight: 40
url: /el/net/manage-ole/
keywords:
- αντικείμενο OLE
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
description: "Βελτιστοποιήστε τη διαχείριση αντικειμένων OLE στο PowerPoint και στα αρχεία OpenDocument με το Aspose.Slides για .NET. Ενσωμάτωση, ενημέρωση και εξαγωγή του περιεχομένου OLE χωρίς προβλήματα."
---
## **Εισαγωγή**

{{% alert title="Info" color="info" %}}
OLE (Object Linking & Embedding) είναι τεχνολογία της Microsoft που επιτρέπει σε δεδομένα και αντικείμενα που δημιουργούνται σε μία εφαρμογή να τοποθετούνται σε άλλη εφαρμογή μέσω σύνδεσης ή ενσωμάτωσης. 
{{% /alert %}} 

Σκεφτείτε ένα γράφημα που δημιουργήθηκε στο MS Excel. Το γράφημα στη συνέχεια τοποθετείται μέσα σε μια διαφάνεια του PowerPoint. Αυτό το γράφημα του Excel θεωρείται αντικείμενο OLE. 

- Ένα αντικείμενο OLE μπορεί να εμφανίζεται ως εικονίδιο. Σε αυτήν την περίπτωση, όταν κάνετε διπλό κλικ στο εικονίδιο, το γράφημα ανοίγει στην σχετική εφαρμογή (Excel), ή σας ζητείται να επιλέξετε μια εφαρμογή για το άνοιγμα ή την επεξεργασία του αντικειμένου. 
- Ένα αντικείμενο OLE μπορεί να εμφανίζει το πραγματικό του περιεχόμενο, όπως τα δεδομένα ενός γραφήματος. Σε αυτήν την περίπτωση, το γράφημα ενεργοποιείται στο PowerPoint, φορτώνεται η διεπαφή του γραφήματος και μπορείτε να τροποποιήσετε τα δεδομένα του γραφήματος μέσα στο PowerPoint.

[Aspose.Slides for .NET](https://products.aspose.com/slides/el/net/) σας επιτρέπει να εισάγετε αντικείμενα OLE σε διαφάνειες ως πλαίσια αντικειμένων OLE ([OleObjectFrame](https://reference.aspose.com/slides/el/net/aspose.slides/oleobjectframe)).

## **Προσθήκη πλαισίων αντικειμένου OLE σε διαφάνειες**

Αν υποθέσουμε ότι έχετε ήδη δημιουργήσει ένα γράφημα στο Microsoft Excel και θέλετε να το ενσωματώσετε σε μια διαφάνεια ως πλαίσιο αντικειμένου OLE χρησιμοποιώντας το Aspose.Slides for .NET, μπορείτε να το κάνετε ως εξής:

1. Δημιουργήστε ένα αντίinstance της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
2. Λάβετε μια αναφορά στη διαφάνεια μέσω του δείκτη της.
3. Διαβάστε το αρχείο Excel ως πίνακα byte.
4. Προσθέστε το [OleObjectFrame](https://reference.aspose.com/slides/el/net/aspose.slides/oleobjectframe) στη διαφάνεια περιλαμβάνοντας τον πίνακα byte και άλλες πληροφορίες για το αντικείμενο OLE.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, προσθέσαμε ένα γράφημα από αρχείο Excel σε μια διαφάνεια ως [OleObjectFrame](https://reference.aspose.com/slides/el/net/aspose.slides/oleobjectframe) χρησιμοποιώντας το Aspose.Slides for .NET.  
**Σημείωση** ότι ο κατασκευαστής του [OleEmbeddedDataInfo](https://reference.aspose.com/slides/el/net/aspose.slides.dom.ole/oleembeddeddatainfo/) δέχεται μια επέκταση ενσωματωμένου αντικειμένου ως δεύτερη παράμετρο. Αυτή η επέκταση επιτρέπει στο PowerPoint να ερμηνεύσει σωστά τον τύπο του αρχείου και να επιλέξει τη σωστή εφαρμογή για το άνοιγμα του αντικειμένου OLE.

```csharp
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

### **Προσθήκη συνδεδεμένων πλαισίων αντικειμένου OLE**

Το Aspose.Slides for .NET σας επιτρέπει να προσθέσετε ένα [OleObjectFrame](https://reference.aspose.com/slides/el/net/aspose.slides/oleobjectframe) χωρίς ενσωμάτωση δεδομένων, αλλά μόνο με σύνδεσμο προς το αρχείο.

Αυτός ο κώδικας C# δείχνει πώς να προσθέσετε ένα [OleObjectFrame](https://reference.aspose.com/slides/el/net/aspose.slides/oleobjectframe) με ένα συνδεδεμένο αρχείο Excel σε μια διαφάνεια:

```csharp
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Προσθήκη πλαισίου αντικειμένου OLE με συνδεδεμένο αρχείο Excel.
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Πρόσβαση σε πλαίσια αντικειμένου OLE**

Εάν ένα αντικείμενο OLE είναι ήδη ενσωματωμένο σε μια διαφάνεια, μπορείτε εύκολα να το βρείτε ή να το προσπελάσετε ως εξής:

1. Φορτώστε μια παρουσίαση με το ενσωματωμένο αντικείμενο OLE δημιουργώντας ένα αντίinstance της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
2. Λάβετε την αναφορά της διαφάνειας χρησιμοποιώντας τον δείκτη της.
3. Πρόσβαση στο σχήμα [OleObjectFrame](https://reference.aspose.com/slides/el/net/aspose.slides/oleobjectframe). Στο παράδειγμά μας, χρησιμοποιήσαμε το προηγούμενο PPTX που έχει μόνο ένα σχήμα στην πρώτη διαφάνεια. Στη συνέχεια *cast* αυτό το αντικείμενο ως [IOleObjectFrame](https://reference.aspose.com/slides/el/net/aspose.slides/ioleobjectframe). Αυτό ήταν το επιθυμητό πλαίσιο αντικειμένου OLE για πρόσβαση.
4. Μόλις το πλαίσιο αντικειμένου OLE προσεγγιστεί, μπορείτε να εκτελέσετε οποιαδήποτε ενέργεια πάνω του.

Στο παρακάτω παράδειγμα, ένα πλαίσιο αντικειμένου OLE (ένα αντικείμενο γραφήματος Excel ενσωματωμένο σε διαφάνεια) και τα δεδομένα του αρχείου προσεγγίζονται.

```csharp
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Λάβετε το πρώτο σχήμα ως πλαίσιο αντικειμένου OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        // Αποκτήστε τα ενσωματωμένα δεδομένα αρχείου.
        byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

        // Λάβετε την επέκταση του ενσωματωμένου αρχείου.
        string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

        // ...
    }
}
```

### **Πρόσβαση σε ιδιότητες συνδεδεμένου πλαισίου αντικειμένου OLE**

Το Aspose.Slides σας επιτρέπει να προσπελάσετε τις ιδιότητες του συνδεδεμένου πλαισίου αντικειμένου OLE.

Αυτός ο κώδικας C# δείχνει πώς να ελέγξετε εάν ένα αντικείμενο OLE είναι συνδεδεμένο και στη συνέχεια να αποκτήσετε τη διαδρομή προς το συνδεδεμένο αρχείο:

```csharp
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

        // Εκτυπώστε τη σχετική διαδρομή του συνδεδεμένου αρχείου εάν υπάρχει.
        // Μόνο οι παρουσιάσεις PPT μπορούν να περιέχουν τη σχετική διαδρομή.
        if (!string.IsNullOrEmpty(oleFrame.LinkPathRelative))
        {
            Console.WriteLine("OLE object frame relative path: " + oleFrame.LinkPathRelative);
        }
    }
}
```

## **Αλλαγή δεδομένων αντικειμένου OLE**

{{% alert color="primary" %}} 
Σε αυτήν την ενότητα, το παρακάτω παράδειγμα κώδικα χρησιμοποιεί [Aspose.Cells for .NET](/cells/net/). 
{{% /alert %}}

Εάν ένα αντικείμενο OLE είναι ήδη ενσωματωμένο σε μια διαφάνεια, μπορείτε εύκολα να το προσπελάσετε και να τροποποιήσετε τα δεδομένα του ως εξής:

1. Φορτώστε μια παρουσίαση με το ενσωματωμένο αντικείμενο OLE δημιουργώντας ένα αντίinstance της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
2. Λάβετε την αναφορά της διαφάνειας μέσω του δείκτη της. 
3. Πρόσβαση στο σχήμα [OLEObjectFrame](https://reference.aspose.com/slides/el/net/aspose.slides/oleobjectframe). Στο παράδειγμά μας, χρησιμοποιήσαμε το προηγούμενο PPTX που έχει ένα σχήμα στην πρώτη διαφάνεια. Στη συνέχεια *cast* αυτό το αντικείμενο ως [IOleObjectFrame](https://reference.aspose.com/slides/el/net/aspose.slides/ioleobjectframe). Αυτό ήταν το επιθυμητό πλαίσιο αντικειμένου OLE για πρόσβαση.
4. Μόλις το πλαίσιο αντικειμένου OLE προσεγγιστεί, μπορείτε να εκτελέσετε οποιαδήποτε ενέργεια πάνω του.
5. Δημιουργήστε ένα αντικείμενο `Workbook` και προσπελάστε τα δεδομένα OLE.
6. Προσπελάστε το επιθυμητό `Worksheet` και επεξεργαστείτε τα δεδομένα.
7. Αποθηκεύστε το ενημερωμένο `Workbook` σε ροή.
8. Αλλάξτε τα δεδομένα του αντικειμένου OLE από τη ροή.

Στο παρακάτω παράδειγμα, ένα πλαίσιο αντικειμένου OLE (ένα αντικείμενο γραφήματος Excel ενσωματωμένο σε διαφάνεια) προσεγγίζεται και τα δεδομένα του αρχείου τροποποιούνται ώστε να ενημερωθούν τα δεδομένα του γραφήματος.

```csharp 
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
            Workbook workbook = new Workbook(oleStream);

            using (MemoryStream newOleStream = new MemoryStream())
            {
                // Τροποποιήστε τα δεδομένα του workbook.
                workbook.Worksheets[0].Cells[0, 4].PutValue("E");
                workbook.Worksheets[0].Cells[1, 4].PutValue(12);
                workbook.Worksheets[0].Cells[2, 4].PutValue(14);
                workbook.Worksheets[0].Cells[3, 4].PutValue(15);

                OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
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

## **Ενσωμάτωση άλλων τύπων αρχείων σε διαφάνειες**

Εκτός από γραφήματα Excel, το Aspose.Slides for .NET σας επιτρέπει να ενσωματώσετε άλλα είδη αρχείων σε διαφάνειες. Για παράδειγμα, μπορείτε να εισάγετε HTML, PDF και ZIP αρχεία ως αντικείμενα. Όταν ο χρήστης κάνει διπλό κλικ στο εισαχθέν αντικείμενο, αυτό ανοίγει αυτόματα στο σχετικό πρόγραμμα, ή του ζητείται να επιλέξει ένα κατάλληλο πρόγραμμα για το άνοιγμα.

Αυτός ο κώδικας C# δείχνει πώς να ενσωματώσετε HTML και ZIP σε μια διαφάνεια:

```c#
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

Κατά τη práci με παρουσιάσεις, μπορεί να χρειαστεί να αντικαταστήσετε παλιά αντικείμενα OLE με νέα ή να αντικαταστήσετε ένα μη υποστηριζόμενο αντικείμενο OLE με ένα υποστηριζόμενο. Το Aspose.Slides for .NET σας επιτρέπει να ορίσετε τον τύπο αρχείου για ένα ενσωματωμένο αντικείμενο, επιτρέποντάς σας να ενημερώσετε τα δεδομένα του πλαισίου OLE ή την επέκτασή του.

Αυτός ο κώδικας C# δείχνει πώς να ορίσετε τον τύπο αρχείου για ένα ενσωματωμένο αντικείμενο OLE σε `zip`:

```c#
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

## **Ορισμός εικονιδίων εικόνας και τίτλων για ενσωματωμένα αντικείμενα**

Μετά την ενσωμάτωση ενός αντικειμένου OLE, προστίθεται αυτόματα μια προεπισκόπηση που αποτελείται από εικόνα εικονιδίου. Αυτή η προεπισκόπηση είναι ό,τι βλέπουν οι χρήστες πριν προσπελάσουν ή ανοίξουν το αντικείμενο OLE. Εάν θέλετε να χρησιμοποιήσετε μια συγκεκριμένη εικόνα και κείμενο ως στοιχεία στην προεπισκόπηση, μπορείτε να ορίσετε την εικόνα εικονιδίου και τον τίτλο χρησιμοποιώντας το Aspose.Slides for .NET.

Αυτός ο κώδικας C# δείχνει πώς να ορίσετε την εικόνα εικονιδίου και τον τίτλο για ένα ενσωματωμένο αντικείμενο: 

```c#
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

## **Αποτροπή αλλαγής μεγέθους και θέσης πλαισίου αντικειμένου OLE**

Αφού προσθέσετε ένα συνδεδεμένο αντικείμενο OLE σε μια διαφάνεια παρουσίασης, όταν ανοίξετε την παρουσίαση στο PowerPoint, μπορεί να εμφανιστεί μήνυμα που σας ζητά να ενημερώσετε τους συνδέσμους. Πατώντας το κουμπί «Update Links» μπορεί να αλλάξει το μέγεθος και η θέση του πλαισίου αντικειμένου OLE, επειδή το PowerPoint ενημερώνει τα δεδομένα από το συνδεδεμένο αντικείμενο OLE και ανανεώνει την προεπισκόπηση. Για να αποτρέψετε το PowerPoint από το να ζητά ενημέρωση των δεδομένων του αντικειμένου, ορίστε την ιδιότητα `UpdateAutomatic` του διεπαφής [IOleObjectFrame](https://reference.aspose.com/slides/el/net/aspose.slides/ioleobjectframe/) σε `false`:

```cs
oleFrame.UpdateAutomatic = false;
```

## **Εξαγωγή ενσωματωμένων αρχείων**

Το Aspose.Slides for .NET σας επιτρέπει να εξάγετε τα αρχεία που είναι ενσωματωμένα σε διαφάνειες ως αντικείμενα OLE ως εξής:
1. Δημιουργήστε ένα αντίinstance της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) που περιέχει τα αντικείμενα OLE που σκοπεύετε να εξάγετε.
2. Περάστε από όλα τα σχήματα στην παρουσίαση και προσπελάστε τα σχήματα [OLEObjectFrame](https://reference.aspose.com/slides/el/net/aspose.slides/oleobjectframe).
3. Προσπελάστε τα δεδομένα των ενσωματωμένων αρχείων από τα πλαίσια αντικειμένου OLE και γράψτε τα στο δίσκο.

Αυτός ο κώδικας C# δείχνει πώς να εξαγάγετε αρχεία ενσωματωμένα σε μια διαφάνεια ως αντικείμενα OLE:

```c#
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

## **ΣΥΓΚΑΤΑΤΑΣΕΙΣ (FAQ)**

**Θα αποδοθεί το περιεχόμενο OLE κατά την εξαγωγή των διαφανειών σε PDF/εικόνες;**

Αυτό που είναι ορατό στη διαφάνεια αποδίδεται — το εικονίδιο/αντικαταστατική εικόνα (προεπισκόπηση). Το «ζωντανό» περιεχόμενο OLE δεν εκτελείται κατά τη διαδικασία αποτύπωσης. Αν είναι απαραίτητο, ορίστε τη δική σας εικόνα προεπισκόπησης ώστε να εξασφαλίσετε την αναμενόμενη εμφάνιση στο εξαχθέν PDF.

**Πώς μπορώ να κλειδώσω ένα αντικείμενο OLE σε διαφάνεια ώστε οι χρήστες να μην μπορούν να το μετακινήσουν/επεξεργαστούν στο PowerPoint;**

Κλειδώστε το σχήμα: το Aspose.Slides παρέχει [shape-level locks](/slides/el/net/applying-protection-to-presentation/). Αυτό δεν είναι κρυπτογράφηση, αλλά αποτρέπει αποτελεσματικά τυχαίες επεμβάσεις και μετακινήσεις.

**Γιατί ένα συνδεδεμένο αντικείμενο Excel «πηδά» ή αλλάζει μέγεθος όταν ανοίγω την παρουσίαση;**

Το PowerPoint μπορεί να ανανεώσει την προεπισκόπηση του συνδεδεμένου OLE. Για σταθερή εμφάνιση, ακολουθήστε τις πρακτικές του [Working Solution for Worksheet Resizing](/slides/el/net/working-solution-for-worksheet-resizing/) — είτε προσαρμόστε το πλαίσιο στην περιοχή, είτε κλιμακώστε την περιοχή σε σταθερό πλαίσιο και ορίστε μια κατάλληλη αντικαταστατική εικόνα.

**Θα διατηρηθούν οι σχετικές διαδρομές για συνδεδεμένα αντικείμενα OLE στη μορφή PPTX;**

Στο PPTX, οι πληροφορίες «σχετικής διαδρομής» δεν είναι διαθέσιμες — μόνο η πλήρης διαδρομή. Σχετικές διαδρομές υπάρχουν μόνο στην παλαιότερη μορφή PPT. Για φορητότητα, προτιμήστε αξιόπιστες απόλυτες διαδρομές/προσβάσιμες URI ή ενσωμάτωση.