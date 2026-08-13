---
title: Αλλαγή μεγέθους σχημάτων σε διαφάνειες παρουσίασης σε .NET
type: docs
weight: 130
url: /el/net/re-sizing-shapes-on-slide/
keywords:
- αλλαγή μεγέθους σχήματος
- μεταβολή μεγέθους σχήματος
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Απλοποιήστε την αλλαγή μεγέθους των σχημάτων σε διαφάνειες PowerPoint και OpenDocument με το Aspose.Slides για .NET—αυτοματοποιήστε τις προσαρμογές διάταξης διαφανειών και αυξήστε την παραγωγικότητα."
---
## **Επισκόπηση**

Ένα από τα πιο συχνά ερωτήματα των πελατών του Aspose.Slides για .NET είναι πώς να αλλάξουν το μέγεθος των σχημάτων έτσι ώστε, όταν αλλάξει το μέγεθος της διαφάνειας, τα δεδομένα να μην περικόπτονται. Αυτό το σύντομο τεχνικό άρθρο δείχνει πώς να το κάνετε.

## **Αλλαγή Μεγέθους Σχημάτων**

Για να αποφύγετε την κακή ευθυγράμμιση των σχημάτων όταν αλλάζει το μέγεθος της διαφάνειας, ενημερώστε τη θέση και τις διαστάσεις κάθε σχήματος ώστε να ταιριάζουν με τη νέα διάταξη της διαφάνειας.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Φορτώστε το αρχείο παρουσίασης.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Αποκτήστε το αρχικό μέγεθος της διαφάνειας.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // Αλλάξτε το μέγεθος της διαφάνειας χωρίς να κλιμακώσετε τα υπάρχοντα σχήματα.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // Αποκτήστε το νέο μέγεθος της διαφάνειας.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // Αλλάξτε το μέγεθος και τη θέση των σχημάτων σε κάθε διαφάνεια.
    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            // Κλιμακώστε το μέγεθος του σχήματος.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Κλιμακώστε τη θέση του σχήματος.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}}
Αν μια διαφάνεια περιέχει πίνακα, ο παραπάνω κώδικας δεν θα λειτουργήσει σωστά. Σε αυτήν την περίπτωση, πρέπει να αλλάξει το μέγεθος κάθε κελιού του πίνακα.
{{% /alert %}}

Χρησιμοποιήστε τον ακόλουθο κώδικα για να αλλάξετε το μέγεθος διαφανειών που περιέχουν πίνακες. Για πίνακες, κλιμακώστε τα ύψη των επιμέρους γραμμών και τα πλάτη των στηλών αντί του πλάτους και του ύψους του σχήματος — η εφαρμογή και των δύο θα κλιμακώσει τον πίνακα δύο φορές και θα τον μετακινήσει εκτός της διαφάνειας.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Αποκτήστε το αρχικό μέγεθος της διαφάνειας.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // Αλλάξτε το μέγεθος της διαφάνειας χωρίς να κλιμακώσετε τα υπάρχοντα σχήματα.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.SlideSize.Orientation = SlideOrienation.Portrait;

    // Αποκτήστε το νέο μέγεθος της διαφάνειας.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    foreach (IMasterSlide master in presentation.Masters)
    {
        foreach (IShape shape in master.Shapes)
        {
            // Κλιμακώστε το μέγεθος του σχήματος.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Κλιμακώστε τη θέση του σχήματος.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }

        foreach (ILayoutSlide layoutSlide in master.LayoutSlides)
        {
            foreach (IShape shape in layoutSlide.Shapes)
            {
                // Κλιμακώστε το μέγεθος του σχήματος.
                shape.Height *= heightRatio;
                shape.Width *= widthRatio;

                // Κλιμακώστε τη θέση του σχήματος.
                shape.Y *= heightRatio;
                shape.X *= widthRatio;
            }
        }
    }

    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            if (shape is ITable)
            {
                // Κλιμακώστε το μέγεθος του πίνακα μέσω των γραμμών και των στηλών του.
                ITable table = (ITable)shape;
                foreach (IRow row in table.Rows)
                {
                    row.MinimalHeight *= heightRatio;
                }
                foreach (IColumn column in table.Columns)
                {
                    column.Width *= widthRatio;
                }
            }
            else
            {
                // Κλιμακώστε το μέγεθος του σχήματος.
                shape.Height *= heightRatio;
                shape.Width *= widthRatio;
            }

            // Κλιμακώστε τη θέση του σχήματος.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Συχνές Ερωτήσεις**

### Γιατί τα σχήματα παραμορφώνονται ή αποκόπτονται μετά την αλλαγή μεγέθους μιας διαφάνειας;

Κατά την αλλαγή μεγέθους μιας διαφάνειας, τα σχήματα διατηρούν την αρχική τους θέση και μέγεθος εκτός αν η κλίμακα αλλάξει ρητά. Αυτό μπορεί να οδηγήσει σε περικομμένα περιεχόμενα ή σε σχήματα που δεν ευθυγραμμίζονται σωστά.

### Λειτουργεί ο παρεχόμενος κώδικας για όλους τους τύπους σχημάτων;

Το βασικό παράδειγμα λειτουργεί για τους περισσότερους τύπους σχημάτων (πλαίσια κειμένου, εικόνες, διαγράμματα κ.λπ.). Ωστόσο, για πίνακες, πρέπει να διαχειριστείτε ξεχωριστά τις γραμμές και τις στήλες, επειδή το ύψος και το πλάτος ενός πίνακα καθορίζονται από τις διαστάσεις των επιμέρους κελιών.

### Πώς αλλάζω το μέγεθος των πινάκων όταν αλλάζω το μέγεθος μιας διαφάνειας;

Πρέπει να περάσετε σε βρόχο όλες τις γραμμές και στήλες του πίνακα και να αλλάξετε το ύψος και το πλάτος τους αναλογικά, όπως φαίνεται στο δεύτερο παράδειγμα κώδικα.

### Θα λειτουργήσει αυτή η αλλαγή μεγέθους για τις κύριες διαφάνειες και τις διαφάνειες διάταξης;

Ναι, αλλά θα πρέπει επίσης να περάσετε σε βρόχο τα [Masters](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/masters/) και τα [LayoutSlides](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/layoutslides/) και να εφαρμόσετε την ίδια λογική κλιμάκωσης στα σχήματά τους για να εξασφαλίσετε συνέπεια σε όλη την παρουσίαση.

### Μπορώ να αλλάξω την προσανατολισμό μιας διαφάνειας (πορτραίτο/τοπίο) μαζί με την αλλαγή μεγέθους;

Ναι. Μπορείτε να ορίσετε το [presentation.SlideSize.Orientation](https://reference.aspose.com/slides/el/net/aspose.slides/islidesize/orientation/) για να αλλάξετε τον προσανατολισμό. Βεβαιωθείτε ότι ρυθμίζετε τη λογική κλιμάκωσης ανάλογα ώστε να διατηρείται η διάταξη.

### Υπάρχει όριο στο μέγεθος της διαφάνειας που μπορώ να ορίσω;

Το Aspose.Slides υποστηρίζει προσαρμοσμένα μεγέθη, αλλά πολύ μεγάλα μεγέθη μπορεί να επηρεάσουν την απόδοση ή τη συμβατότητα με ορισμένες εκδόσεις του PowerPoint.

### Πώς μπορώ να αποτρέψω τα σχήματα με σταθερή αναλογία διαστάσεων να παραμορφώνονται;

Μπορείτε να ελέγξετε την ιδιότητα `AspectRatioLocked` του σχήματος πριν από την κλιμάκωση. Αν είναι κλειδωμένη, προσαρμόστε το πλάτος ή το ύψος αναλογικά αντί να τα κλιμακώσετε ξεχωριστά.