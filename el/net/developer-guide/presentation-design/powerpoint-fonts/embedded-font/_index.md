---
title: Ενσωμάτωση γραμματοσειρών σε παρουσιάσεις σε .NET
linktitle: Ενσωμάτωση γραμματοσειράς
type: docs
weight: 40
url: /el/net/embedded-font/
keywords:
- προσθήκη γραμματοσειράς
- ενσωμάτωση γραμματοσειράς
- ενσωμάτωση γραμματοσειρών
- λήψη ενσωματωμένης γραμματοσειράς
- προσθήκη ενσωματωμένης γραμματοσειράς
- αφαίρεση ενσωματωμένης γραμματοσειράς
- συμπίεση ενσωματωμένης γραμματοσειράς
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Ενσωματώστε γραμματοσειρές TrueType σε παρουσιάσεις PowerPoint και OpenDocument με το Aspose.Slides για .NET, διασφαλίζοντας ακριβή απόδοση σε όλες τις πλατφόρμες."
---
## **Εισαγωγή**

**Η ενσωμάτωση γραμματοσειρών στο PowerPoint** εξασφαλίζει ότι η παρουσίασή σας διατηρεί την προβλεπόμενη εμφάνιση σε διάφορα συστήματα. Είτε χρησιμοποιείτε μοναδικές γραμματοσειρές για δημιουργικότητα είτε τυπικές, η ενσωμάτωση γραμματοσειρών αποτρέπει τη διαταραχή του κειμένου και της διάταξης.

Αν χρησιμοποιήσατε μια γραμματοσειρά τρίτου μέρους ή μη τυπική γραμματοσειρά επειδή ήσασταν δημιουργικοί στην εργασία σας, τότε έχετε ακόμη περισσότερους λόγους να την ενσωματώσετε. Διαφορετικά (χωρίς ενσωματωμένες γραμματοσειρές), τα κείμενα ή οι αριθμοί στις διαφάνειές σας, η διάταξη, η μορφοποίηση κ.λπ. μπορεί να αλλάξουν ή να μετατραπούν σε συγκεχυμένα ορθογώνια.

Χρησιμοποιήστε τις κλάσεις [FontsManager](https://reference.aspose.com/slides/el/net/aspose.slides/fontsmanager/), [FontData](https://reference.aspose.com/slides/el/net/aspose.slides/fontdata/), και [Compress](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/compress/) για να διαχειριστείτε τις ενσωματωμένες γραμματοσειρές.

## **Απόκτηση και Κατάργηση Ενσωματωμένων Γραμματοσειρών**

Ανακτήστε ή καταργήστε τις ενσωματωμένες γραμματοσειρές από μια παρουσίαση εύκολα με τις μεθόδους [GetEmbeddedFonts](https://reference.aspose.com/slides/el/net/aspose.slides/fontsmanager/getembeddedfonts) και [RemoveEmbeddedFont](https://reference.aspose.com/slides/el/net/aspose.slides/fontsmanager/removeembeddedfont).

Αυτός ο κώδικας C# σας δείχνει πώς να αποκτήσετε και να καταργήσετε τις ενσωματωμένες γραμματοσειρές από μια παρουσίαση:

```c#
using (Presentation presentation = new Presentation("EmbeddedFonts.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Απεικονίζει μια διαφάνεια που περιέχει ένα πλαίσιο κειμένου που χρησιμοποιεί την ενσωματωμένη "FunSized"
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture1_out.png", ImageFormat.Png);
    }

    IFontsManager fontsManager = presentation.FontsManager;

    IFontData[] embeddedFonts = fontsManager.GetEmbeddedFonts();

    // Βρίσκει τη γραμματοσειρά "Calibri"
    IFontData funSizedEmbeddedFont = Array.Find(embeddedFonts, delegate (IFontData data)
    {
        return data.FontName == "Calibri";
    });

    // Αφαιρεί τη γραμματοσειρά "Calibri"
    fontsManager.RemoveEmbeddedFont(funSizedEmbeddedFont);

    // Απεικονίζει την παρουσίαση· η γραμματοσειρά "Calibri" αντικαθίσταται με μια υπάρχουσα
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture2_out.png", ImageFormat.Png);
    }

    // Αποθηκεύει την παρουσίαση χωρίς την ενσωματωμένη γραμματοσειρά "Calibri" στο δίσκο
    presentation.Save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
}
```

## **Προσθήκη Ενσωματωμένων Γραμματοσειρών**

Χρησιμοποιώντας την απαρίθμηση [EmbedFontCharacters](https://reference.aspose.com/slides/el/net/aspose.slides.export/embedfontcharacters/) και τις δύο υπερφορτώσεις της μεθόδου [AddEmbeddedFont](https://reference.aspose.com/slides/el/net/aspose.slides/fontsmanager/addembeddedfont/), μπορείτε να επιλέξετε τον προτιμώμενο κανόνα (ενσωμάτωσης) για την ενσωμάτωση των γραμματοσειρών σε μια παρουσίαση. Αυτός ο κώδικας C# σας δείχνει πώς να ενσωματώσετε και να προσθέσετε γραμματοσειρές σε μια παρουσίαση:

```c#
// Φορτώνει την παρουσίαση
Presentation presentation = new Presentation("Fonts.pptx");

IFontData[] allFonts = presentation.FontsManager.GetFonts();
IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();
foreach (IFontData font in allFonts)
{
    if (!embeddedFonts.Contains(font))
    {
        presentation.FontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
    }
}

// Αποθηκεύει την παρουσίαση στο δίσκο
presentation.Save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
```

## **Συμπίεση Ενσωματωμένων Γραμματοσειρών**

Βελτιστοποιήστε το μέγεθος του αρχείου συμπιέζοντας τις ενσωματωμένες γραμματοσειρές χρησιμοποιώντας την [CompressEmbeddedFonts](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/compress/compressembeddedfonts/).

Παράδειγμα κώδικα για τη συμπίεση:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.CompressEmbeddedFonts(pres);
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να καταλάβω εάν μια συγκεκριμένη γραμματοσειρά στην παρουσίαση θα αντικατασταθεί κατά τη απόδοση παρά την ενσωμάτωση;**

Ελέγξτε τις [πληροφορίες αντικατάστασης](/slides/el/net/font-substitution/) στο διαχειριστή γραμματοσειρών και τους [κανόνες εναλλακτικού/αντικατάστασης](/slides/el/net/fallback-font/): εάν η γραμματοσειρά δεν είναι διαθέσιμη ή είναι περιορισμένη, θα χρησιμοποιηθεί εναλλακτική.

**Αξίζει να ενσωματώσετε τις «συστημικές» γραμματοσειρές όπως Arial/Calibri;**

Συνήθως όχι—είναι σχεδόν πάντα διαθέσιμες. Ωστόσο, για πλήρη φορητότητα σε «λεία» περιβάλλοντα (Docker, ένας διακομιστής Linux χωρίς προεγκατεστημένες γραμματοσειρές), η ενσωμάτωση συστημικών γραμματοσειρών μπορεί να εξαλείψει τον κίνδυνο μη αναμενόμενων αντικαταστάσεων.