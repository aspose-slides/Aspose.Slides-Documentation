---
title: Μετατροπή Παρουσιάσεων PowerPoint σε Έγγραφα Word στο .NET
linktitle: PowerPoint προς Word
type: docs
weight: 110
url: /el/net/convert-powerpoint-to-word/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- μετατροπή διαφάνειας
- μετατροπή PPT
- μετατροπή PPTX
- PowerPoint προς Word
- παρουσίαση προς Word
- διαφάνεια προς Word
- PPT προς Word
- PPTX προς Word
- PowerPoint προς DOCX
- παρουσίαση προς DOCX
- διαφάνεια προς DOCX
- PPT προς DOCX
- PPTX προς DOCX
- PowerPoint προς DOC
- παρουσίαση προς DOC
- διαφάνεια προς DOC
- PPT προς DOC
- PPTX προς DOC
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

Αυτό το άρθρο παρέχει μια λύση για προγραμματιστές σχετικά με τη μετατροπή παρουσιάσεων PowerPoint και OpenDocument σε έγγραφα Word χρησιμοποιώντας το Aspose.Slides για .NET και το Aspose.Words για .NET. Ο οδηγός βήμα προς βήμα σας καθοδηγεί σε κάθε στάδιο της διαδικασίας μετατροπής.

## **Μετατροπή παρουσίασης σε έγγραφο Word**

Ακολουθήστε τις παρακάτω οδηγίες για να μετατρέψετε μια παρουσίαση PowerPoint ή OpenDocument σε έγγραφο Word:

1. Δημιουργήστε μια παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) και φορτώστε ένα αρχείο παρουσίασης.
2. Δημιουργήστε τις κλάσεις [Document](https://reference.aspose.com/words/net/aspose.words/document/) και [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/) για τη δημιουργία ενός εγγράφου Word.
3. Ορίστε το μέγεθος σελίδας του εγγράφου Word ώστε να ταιριάζει με αυτό της παρουσίασης χρησιμοποιώντας την ιδιότητα [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/).
4. Ορίστε τα περιθώρια στο έγγραφο Word χρησιμοποιώντας την ιδιότητα [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/).
5. Περιηγηθείτε σε όλες τις διαφάνειες της παρουσίασης χρησιμοποιώντας την ιδιότητα [Presentation.Slides](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/slides/el/).
   - Δημιουργήστε μια εικόνα διαφάνειας χρησιμοποιώντας τη μέθοδο `GetImage` από τη διεπαφή [ISlide](https://reference.aspose.com/slides/el/net/aspose.slides/islide/) και αποθηκεύστε την σε ροή μνήμης.
   - Προσθέστε την εικόνα της διαφάνειας στο έγγραφο Word χρησιμοποιώντας τη μέθοδο `InsertImage` από την κλάση [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/).
6. Αποθηκεύστε το έγγραφο Word σε ένα αρχείο.

Ας πούμε ότι έχουμε μια παρουσίαση "sample.pptx" που φαίνεται ως εξής:

![Παρουσίαση PowerPoint](PowerPoint.png)

Το παρακάτω παράδειγμα κώδικα C# δείχνει πώς να μετατρέψετε την παρουσίαση PowerPoint σε έγγραφο Word:

```cs
// Φόρτωση αρχείου παρουσίασης.
using var presentation = new Presentation("sample.pptx");

// Δημιουργία αντικειμένων Document και DocumentBuilder.
var document = new Document();
var builder = new DocumentBuilder(document);

// Ορισμός μεγέθους σελίδας στο έγγραφο Word.
var slideSize = presentation.SlideSize.Size;
builder.PageSetup.PageWidth = slideSize.Width;
builder.PageSetup.PageHeight = slideSize.Height;

// Ορισμός περιθωρίων στο έγγραφο Word.
builder.PageSetup.LeftMargin = 0;
builder.PageSetup.RightMargin = 0;
builder.PageSetup.TopMargin = 0;
builder.PageSetup.BottomMargin = 0;

const float scaleX = 2, scaleY = 2;

// Διαπέραση όλων των διαφανειών της παρουσίασης.
foreach (var slide in presentation.Slides)
{
    // Δημιουργία εικόνας διαφάνειας και αποθήκευση σε ροή μνήμης.
    using var image = slide.GetImage(scaleX, scaleY);
    using var imageStream = new MemoryStream();
    image.Save(imageStream, ImageFormat.Png);

    // Προσθήκη εικόνας διαφάνειας στο έγγραφο Word.
    imageStream.Seek(0, SeekOrigin.Begin);
    builder.InsertImage(imageStream.ToArray(), builder.PageSetup.PageWidth, builder.PageSetup.PageHeight);

    builder.InsertBreak(BreakType.PageBreak);
}

// Αποθήκευση του εγγράφου Word σε αρχείο.
document.Save("output.docx");
```

Το αποτέλεσμα:

![Έγγραφο Word](Word.png)

{{% alert color="primary" %}} 

Δοκιμάστε το **Online PPT to Word Converter**(https://products.aspose.app/slides/el/conversion/ppt-to-word) για να δείτε τι μπορείτε να κερδίσετε από τη μετατροπή παρουσιάσεων PowerPoint και OpenDocument σε έγγραφα Word. 

{{% /alert %}}

## **Συχνές ερωτήσεις**

**Τι συστατικά χρειάζεται να εγκατασταθούν για τη μετατροπή παρουσιάσεων PowerPoint και OpenDocument σε έγγραφα Word;**

Απλά χρειάζεται να προσθέσετε τα αντίστοιχα πακέτα NuGet για το [Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET) και το [Aspose.Words for .NET](https://www.nuget.org/packages/Aspose.Words/) στο έργο C# σας. Και οι δύο βιβλιοθήκες λειτουργούν ως αυτόνομες API και δεν απαιτείται η εγκατάσταση του Microsoft Office.

**Υποστηρίζονται όλες οι μορφές παρουσιάσεων PowerPoint και OpenDocument;**

Το Aspose.Slides για .NET [υποστηρίζει όλες τις μορφές παρουσιάσεων](/slides/el/net/supported-file-formats/), συμπεριλαμβανομένων των PPT, PPTX, ODP και άλλων κοινών τύπων αρχείων. Αυτό εξασφαλίζει ότι μπορείτε να εργάζεστε με παρουσιάσεις που δημιουργήθηκαν σε διάφορες εκδόσεις του Microsoft PowerPoint.