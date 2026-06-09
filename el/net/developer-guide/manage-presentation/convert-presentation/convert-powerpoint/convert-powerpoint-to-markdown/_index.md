---
title: Μετατροπή Παρουσιών PowerPoint σε Markdown στο .NET
linktitle: PowerPoint σε Markdown
type: docs
weight: 140
url: /el/net/convert-powerpoint-to-markdown/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- μετατροπή διαφάνειας
- μετατροπή PPT
- μετατροπή PPTX
- PowerPoint σε MD
- παρουσίαση σε MD
- διαφάνεια σε MD
- PPT σε MD
- PPTX σε MD
- αποθήκευση PowerPoint ως Markdown
- αποθήκευση παρουσίασης ως Markdown
- αποθήκευση διαφάνειας ως Markdown
- αποθήκευση PPT ως MD
- αποθήκευση PPTX ως MD
- εξαγωγή PPT σε MD
- exportPPTX σε MD
- PowerPoint
- παρουσίαση
- Markdown
- .NET
- C#
- Aspose.Slides
description: "Μετατρέψτε τις διαφάνειες PowerPoint—PPT, PPTX—σε καθαρό Markdown με το Aspose.Slides για .NET, αυτοματοποιήστε την τεκμηρίωση και διατηρήστε τη μορφοποίηση."
---
## **Εισαγωγή**

Το Aspose.Slides σάς επιτρέπει να μετατρέπετε παρουσιάσεις PowerPoint σε Markdown, κάτι που μπορεί να είναι χρήσιμο για ροές εργασίας τεκμηρίωσης, δημιουργία στατικών ιστοσελίδων, μετανάστευση περιεχομένου και έκδοση κειμένου υπό έλεγχο εκδόσεων. Το API υποστηρίζει άμεση εξαγωγή από παρουσιάσεις PPT και PPTX σε αρχεία MD και παρέχει πρόσθετες επιλογές για τον έλεγχο του τρόπου με τον οποίο το περιεχόμενο των διαφανειών αντιπροσωπεύεται στο τελικό έγγραφο Markdown.

Μπορείτε να εξάγετε παρουσιάσεις ως απλό Markdown, να επιλέξετε από πολλαπλές γεύσεις Markdown όπως CommonMark και GitHub Flavored Markdown, και να διαμορφώσετε τον τρόπο διαχείρισης των εικόνων κατά την εξαγωγή. Για παρουσιάσεις που περιέχουν οπτικό περιεχόμενο, το Aspose.Slides επιτρέπει επίσης να αποθηκεύετε τις εικόνες σε ξεχωριστό φάκελο και να τις παραπέμπετε από το παραγόμενο αρχείο Markdown.

{{% alert color="warning" %}}
Η εξαγωγή PowerPoint‑to‑Markdown είναι **χωρίς εικόνες** εξ ορισμού. Εάν θέλετε να εξάγετε ένα έγγραφο PowerPoint που περιέχει εικόνες, πρέπει να ορίσετε `ExportType = MarkdownExportType.Visual` και να καθορίσετε το `BasePath`, όπου θα αποθηκευτούν οι εικόνες που αναφέρονται στο έγγραφο Markdown.
{{% /alert %}}

## **Μετατροπή PowerPoint σε Markdown**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) για να αντιπροσωπεύει ένα αντικείμενο παρουσίασης.  
2. Χρησιμοποιήστε τη [Αποθήκευση](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/methods/save) μέθοδο για να αποθηκεύσετε το αντικείμενο ως αρχείο markdown.

Αυτός ο κώδικας C# δείχνει πώς να μετατρέψετε το PowerPoint σε markdown:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md);
}
```

## **Μετατροπή PowerPoint σε Γεύση Markdown**

Το Aspose.Slides σάς επιτρέπει να μετατρέψετε το PowerPoint σε markdown (περιέχει βασική σύνταξη), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab και 17 άλλες γεύσεις markdown.

Αυτός ο κώδικας C# δείχνει πώς να μετατρέψετε το PowerPoint σε CommonMark:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md, new MarkdownSaveOptions
    {
        Flavor = Flavor.CommonMark
    });
}
```

Οι 23 υποστηριζόμενες γεύσεις markdown είναι [καταγραφμένες στην απαρίθμηση Flavor](https://reference.aspose.com/slides/el/net/aspose.slides.dom.export.markdown.saveoptions/flavor/) από την κλάση [MarkdownSaveOptions](https://reference.aspose.com/slides/el/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **Μετατροπή Παρουσίασης που Περιέχει Εικόνες σε Markdown**

Η κλάση [MarkdownSaveOptions](https://reference.aspose.com/slides/el/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) παρέχει ιδιότητες και απαριθμήσεις που σας επιτρέπουν να χρησιμοποιήσετε συγκεκριμένες επιλογές ή ρυθμίσεις για το τελικό αρχείο markdown. Η απαρίθμηση [MarkdownExportType](https://reference.aspose.com/slides/el/net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) μπορεί, για παράδειγμα, να οριστεί σε τιμές που καθορίζουν πώς θα αποτυπωθούν ή θα διαχειριστούν οι εικόνες: `Sequential`, `TextOnly`, `Visual`.

### **Μετατροπή Εικόνων Διαδοχικά**

Αν θέλετε οι εικόνες να εμφανίζονται μεμονωμένα η μία μετά την άλλη στο τελικό markdown, πρέπει να επιλέξετε τη διαδοχική επιλογή. Αυτός ο κώδικας C# δείχνει πώς να μετατρέψετε μια παρουσίαση που περιέχει εικόνες σε markdown:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions
    {
        ShowHiddenSlides = true,
        ShowSlideNumber = true,
        Flavor = Flavor.Github,
        ExportType = MarkdownExportType.Sequential,
        NewLineType = NewLineType.Windows
    };
    
    pres.Save("doc.md", new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, SaveFormat.Md, markdownSaveOptions);
}
```

### **Μετατροπή Εικόνων Οπτικά**

Αν θέλετε οι εικόνες να εμφανίζονται μαζί στο τελικό markdown, πρέπει να επιλέξετε την οπτική επιλογή. Σε αυτή την περίπτωση, οι εικόνες θα αποθηκευτούν στον τρέχοντα κατάλογο της εφαρμογής (και θα δημιουργηθεί μια σχετική διαδρομή για αυτές στο έγγραφο markdown), ή μπορείτε να καθορίσετε την προτιμώμενη διαδρομή και όνομα φακέλου.

Αυτός ο κώδικας C# επιδεικνύει τη λειτουργία:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    const string outPath = "c:\\documents";
    pres.Save(Path.Combine(outPath, "pres.md"), SaveFormat.Md, new MarkdownSaveOptions
    { 
        ExportType = MarkdownExportType.Visual,
        ImagesSaveFolderName = "md-images",
        BasePath = outPath
    });
}
```

## **Συχνές Ερωτήσεις**

**Τα υπερσυνδέσμους παραμένουν μετά την εξαγωγή σε Markdown;**

Ναι. Τα κείμενα [hyperlinks](/slides/el/net/manage-hyperlinks/) διατηρούνται ως τυπικοί σύνδεσμοι Markdown. Τα [transitions](/slides/el/net/slide-transition/) των διαφανειών και οι [animations](/slides/el/net/powerpoint-animation/) δεν μετατρέπονται.

**Μπορώ να επιταχύνω τη μετατροπή εκτελώντας την σε πολλαπλά νήματα;**

Μπορείτε να παράλληλοποιήσετε ανά αρχείο, αλλά [don’t share](/slides/el/net/multithreading/) την ίδια παρουσία [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) μεταξύ νημάτων. Χρησιμοποιήστε ξεχωριστές παρουσίες/διεργασίες ανά αρχείο για να αποφύγετε συγκρούσεις.

**Τι συμβαίνει με τις εικόνες—πού αποθηκεύονται και είναι οι διαδρομές σχετικές;**

Οι [Images](/slides/el/net/image/) εξάγονται σε έναν αποκλειστικό φάκελο, και το αρχείο Markdown τις παραπέμπει με σχετικές διαδρομές εξ ορισμού. Μπορείτε να διαμορφώσετε τη βασική διαδρομή εξόδου και το όνομα του φακέλου πόρων για να διατηρήσετε μια προβλέψιμη δομή αποθετηρίου.