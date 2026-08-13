---
title: Μετατροπή Παρουσιών PowerPoint σε Έγγραφα Word στο .NET
linktitle: PowerPoint σε Word
type: docs
weight: 110
url: /el/net/convert-powerpoint-to-word/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- μετατροπή διαφάνειας
- μετατροπή PPT
- μετατροπή PPTX
- PowerPoint σε Word
- παρουσίαση σε Word
- διαφάνεια σε Word
- PPT σε Word
- PPTX σε Word
- PowerPoint σε DOCX
- παρουσίαση σε DOCX
- διαφάνεια σε DOCX
- PPT σε DOCX
- PPTX σε DOCX
- PowerPoint σε DOC
- παρουσίαση σε DOC
- διαφάνεια σε DOC
- PPT σε DOC
- PPTX σε DOC
- αποθήκευση PPT ως DOCX
- αποθήκευση PPTX ως DOCX
- εξαγωγή PPT σε DOCX
- εξαγωγή PPTX σε DOCX
- .NET
- C#
- Aspose.Slides
description: "Μετατρέψτε διαφάνειες PowerPoint PPT και PPTX σε επεξεργάσιμα έγγραφα Word σε C# χρησιμοποιώντας το Aspose.Slides για .NET με ακριβή διάταξη, εικόνες και διατήρηση μορφοποίησης."
---
## **Επισκόπηση**

Αυτό το άρθρο παρέχει μια λύση για προγραμματιστές σχετικά με τη μετατροπή παρουσιάσεων PowerPoint και OpenDocument σε έγγραφα Word χρησιμοποιώντας το Aspose.Slides for .NET και το Aspose.Words for .NET. Ο οδηγός βήμα‑βήμα σας καθοδηγεί μέσα από κάθε στάδιο της διαδικασίας μετατροπής.

## **Μετατροπή Παρουσίασης σε Έγγραφο Word**

Ακολουθήστε τις παρακάτω οδηγίες για να μετατρέψετε μια παρουσίαση PowerPoint ή OpenDocument σε έγγραφο Word:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) και φορτώστε ένα αρχείο παρουσίασης.
2. Δημιουργήστε αντικείμενα των κλάσεων [Document](https://reference.aspose.com/words/net/aspose.words/document/) και [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/) για να δημιουργήσετε ένα έγγραφο Word.
3. Ορίστε το μέγεθος της σελίδας για το έγγραφο Word ώστε να ταιριάζει με αυτό της παρουσίασης χρησιμοποιώντας την ιδιότητα [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/).
4. Ορίστε τα περιθώρια στο έγγραφο Word χρησιμοποιώντας την ιδιότητα [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/).
5. Περιηγηθείτε σε όλες τις διαφάνειες της παρουσίασης χρησιμοποιώντας την ιδιότητα [Presentation.Slides](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/slides/el/).
    - Δημιουργήστε μια εικόνα διαφάνειας χρησιμοποιώντας τη μέθοδο `GetImage` από τη διεπαφή [ISlide](https://reference.aspose.com/slides/el/net/aspose.slides/islide/) και αποθηκεύστε την σε μια ροή μνήμης.
    - Προσθέστε την εικόνα διαφάνειας στο έγγραφο Word χρησιμοποιώντας τη μέθοδο `InsertImage` από την κλάση [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/).
6. Αποθηκεύστε το έγγραφο Word σε αρχείο.

Ας υποθέσουμε ότι έχουμε μια παρουσίαση "sample.pptx" που φαίνεται ως εξής:

![Παρουσίαση PowerPoint](PowerPoint.png)

Το παρακάτω παράδειγμα κώδικα C# δείχνει πώς να μετατρέψετε την παρουσίαση PowerPoint σε έγγραφο Word:

```cs
using Aspose.Slides;
using Aspose.Words;

// Φορτώστε ένα αρχείο παρουσίασης.
using var presentation = new Presentation("sample.pptx");

// Δημιουργήστε αντικείμενα Document και DocumentBuilder.
var document = new Document();
var builder = new DocumentBuilder(document);

// Ορίστε το μέγεθος της σελίδας στο έγγραφο Word.
var slideSize = presentation.SlideSize.Size;
builder.PageSetup.PageWidth = slideSize.Width;
builder.PageSetup.PageHeight = slideSize.Height;

// Ορίστε τα περιθώρια στο έγγραφο Word.
builder.PageSetup.LeftMargin = 0;
builder.PageSetup.RightMargin = 0;
builder.PageSetup.TopMargin = 0;
builder.PageSetup.BottomMargin = 0;

const float scaleX = 2, scaleY = 2;

// Περιηγηθείτε σε όλες τις διαφάνειες της παρουσίασης.
foreach (var slide in presentation.Slides)
{
    // Δημιουργήστε μια εικόνα διαφάνειας και αποθηκεύστε την σε ροή μνήμης.
    using var image = slide.GetImage(scaleX, scaleY);
    using var imageStream = new MemoryStream();
    image.Save(imageStream, ImageFormat.Png);

    // Προσθέστε την εικόνα διαφάνειας στο έγγραφο Word.
    imageStream.Seek(0, SeekOrigin.Begin);
    builder.InsertImage(imageStream.ToArray(), builder.PageSetup.PageWidth, builder.PageSetup.PageHeight);

    builder.InsertBreak(BreakType.PageBreak);
}

// Αποθηκεύστε το έγγραφο Word σε αρχείο.
document.Save("output.docx");
```

Το αποτέλεσμα:

![Έγγραφο Word](Word.png)

{{% alert color="info" %}} 

Δοκιμάστε τον [**Online PPT to Word Converter**](https://products.aspose.app/slides/el/conversion/ppt-to-word) μας για να δείτε τι μπορείτε να κερδίσετε μετατρέπειντας παρουσιάσεις PowerPoint και OpenDocument σε έγγραφα Word. 

{{% /alert %}}

## **Συχνές Ερωτήσεις**

### Ποια εξαρτήματα πρέπει να εγκατασταθούν για τη μετατροπή παρουσιάσεων PowerPoint και OpenDocument σε έγγραφα Word;

Απλώς χρειάζεται να προσθέσετε τα αντίστοιχα πακέτα NuGet για το [Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET) και το [Aspose.Words for .NET](https://www.nuget.org/packages/Aspose.Words/) στο έργο C# σας. Και οι δύο βιβλιοθήκες λειτουργούν ως ανεξάρτητα APIs, και δεν υπάρχει απαίτηση για εγκατάσταση του Microsoft Office.

### Υποστηρίζονται όλα τα μορφές παρουσιάσεων PowerPoint και OpenDocument;

Το Aspose.Slides for .NET [υποστηρίζει όλα τα μορφές παρουσίασης](/slides/el/net/supported-file-formats/), συμπεριλαμβανομένων των PPT, PPTX, ODP και άλλων κοινών τύπων αρχείων. Αυτό εξασφαλίζει ότι μπορείτε να εργαστείτε με παρουσιάσεις που δημιουργήθηκαν σε διάφορες εκδόσεις του Microsoft PowerPoint.