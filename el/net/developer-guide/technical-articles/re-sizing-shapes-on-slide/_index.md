---
title: "Αλλαγή Μεγέθους Σχημάτων σε Διαφάνειες Παρουσίασης στο .NET"
type: docs
weight: 130
url: /el/net/re-sizing-shapes-on-slide/
keywords:
- "αλλαγή μεγέθους σχήματος"
- "αλλαγή μεγέθους σχήματος"
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Απλώς αλλάξτε το μέγεθος των σχημάτων σε διαφάνειες PowerPoint και OpenDocument με το Aspose.Slides για .NET - αυτοματοποιήστε τις προσαρμογές διάταξης διαφανειών και αυξήστε την παραγωγικότητα."
---
## **Επισκόπηση**

Μία από τις πιο συχνές ερωτήσεις των πελατών του Aspose.Slides για .NET είναι πώς να αλλάξετε το μέγεθος των σχημάτων έτσι ώστε, όταν αλλάξει το μέγεθος της διαφάνειας, τα δεδομένα να μην αποκόπτονται. Αυτό το σύντομο τεχνικό άρθρο δείχνει πώς να το κάνετε.

## **Αλλαγή Μεγέθους Σχημάτων**

Για να αποτρέψετε τα σχήματα από το να καταστραφούν όταν αλλάξει το μέγεθος της διαφάνειας, ενημερώστε τη θέση και τις διαστάσεις κάθε σχήματος ώστε να ταιριάζουν με τη νέα διάταξη της διαφάνειας.

```c#
 // Load the presentation file.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Get the original slide size.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // Change the slide size without scaling existing shapes.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // Get the new slide size.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // Resize and reposition shapes on every slide.
    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            // Scale the shape size.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Scale the shape position.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}}
Εάν μια διαφάνεια περιέχει πίνακα, ο παραπάνω κώδικας δεν θα λειτουργήσει σωστά. Σε αυτή την περίπτωση, κάθε κελί του πίνακα πρέπει να επαναπροσαρμοστεί.
{{% /alert %}}

Χρησιμοποιήστε τον παρακάτω κώδικα στην πλευρά σας για να αλλάξετε το μέγεθος των διαφανειών που περιέχουν πίνακες. Για πίνακες, η ρύθμιση του πλάτους ή του ύψους είναι ειδική περίπτωση: πρέπει να προσαρμόσετε τα ύψη των επιμέρους γραμμών και τα πλάτη των στηλών για να αλλάξετε το συνολικό μέγεθος του πίνακα.

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Λάβετε το αρχικό μέγεθος της διαφάνειας.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // Αλλάξτε το μέγεθος της διαφάνειας χωρίς να κλιμακώνετε τα υπάρχοντα σχήματα.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.SlideSize.Orientation = SlideOrienation.Portrait;

    // Λάβετε το νέο μέγεθος της διαφάνειας.
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
            // Κλιμακώστε το μέγεθος του σχήματος.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Κλιμακώστε τη θέση του σχήματος.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;

            if (shape is ITable)
            {
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
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Συχνές ερωτήσεις**

**Γιατί τα σχήματα παραμορφώνονται ή αποκόπτονται μετά την αλλαγή μεγέθους μιας διαφάνειας;**

Κατά την αλλαγή μεγέθους μιας διαφάνειας, τα σχήματα διατηρούν τη αρχική τους θέση και μέγεθος εκτός εάν η κλίμακα αλλάξει ρητά. Αυτό μπορεί να οδηγήσει σε αποκοπή του περιεχομένου ή σε εκθήλωση των σχημάτων.

**Λειτουργεί ο παρεχόμενος κώδικας για όλους τους τύπους σχημάτων;**

Το βασικό παράδειγμα λειτουργεί για τους περισσότερους τύπους σχημάτων (πλαίσια κειμένου, εικόνες, διαγράμματα κ.λπ.). Ωστόσο, για πίνακες, πρέπει να διαχειριστείτε ξεχωριστά τις γραμμές και τις στήλες, επειδή το ύψος και το πλάτος ενός πίνακα καθορίζονται από τις διαστάσεις των επιμέρους κελιών.

**Πώς να αλλάξω το μέγεθος των πινάκων όταν αλλάζω το μέγεθος μιας διαφάνειας;**

Πρέπει να διατρέξετε όλες τις γραμμές και στήλες του πίνακα και να αλλάξετε το ύψος και το πλάτος τους ανάλογα, όπως φαίνεται στο δεύτερο παράδειγμα κώδικα.

**Θα λειτουργήσει αυτή η αλλαγή μεγέθους και για διαφάνειες προτύπου και διαφάνειες διάταξης;**

Ναι, αλλά θα πρέπει επίσης να διατρέξετε τις [Masters](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/masters/) και τις [LayoutSlides](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/layoutslides/) και να εφαρμόσετε την ίδια λογική κλιμάκωσης στα σχήματά τους ώστε να διασφαλιστεί η συνέπεια σε όλη την παρουσίαση.

**Μπορώ να αλλάξω τον προσανατολισμό μιας διαφάνειας (κάθετη/οριζόντια) μαζί με την αλλαγή μεγέθους;**

Ναι. Μπορείτε να ορίσετε το [presentation.SlideSize.Orientation](https://reference.aspose.com/slides/el/net/aspose.slides/islidesize/orientation/) για να αλλάξετε τον προσανατολισμό. Βεβαιωθείτε ότι έχετε ρυθμίσει τη λογική κλιμάκωσης αναλόγως ώστε να διατηρηθεί η διάταξη.

**Υπάρχει όριο στο μέγεθος της διαφάνειας που μπορώ να θέσω;**

Το Aspose.Slides υποστηρίζει προσαρμοσμένα μεγέθη, αλλά πολύ μεγάλα μεγέθη μπορεί να επηρεάσουν την απόδοση ή τη συμβατότητα με ορισμένες εκδόσεις του PowerPoint.

**Πώς μπορώ να αποτρέψω τα σχήματα με σταθερό λόγο διαστάσεων από το να παραμορφωθούν;**

Μπορείτε να ελέγξετε την ιδιότητα `AspectRatioLocked` του σχήματος πριν από την κλιμάκωση. Εάν είναι κλειδωμένη, προσαρμόστε το πλάτος ή το ύψος ανάλογα αντί να τα κλιμακώσετε ξεχωριστά.