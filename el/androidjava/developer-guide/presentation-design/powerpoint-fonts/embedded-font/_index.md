---
title: Ενσωμάτωση γραμματοσειρών σε παρουσιάσεις στο Android
linktitle: Ενσωμάτωση γραμματοσειράς
type: docs
weight: 40
url: /el/androidjava/embedded-font/
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
- presentation
- Android
- Java
- Aspose.Slides
description: "Ενσωματώστε γραμματοσειρές TrueType σε παρουσιάσεις PowerPoint και OpenDocument με το Aspose.Slides για Android μέσω Java, διασφαλίζοντας ακριβή απόδοση σε όλες τις πλατφόρμες."
---
## **Εισαγωγή**

**Ενσωματωμένες γραμματοσειρές στο PowerPoint** είναι χρήσιμες όταν θέλετε η παρουσίασή σας να εμφανίζεται σωστά σε οποιοδήποτε σύστημα ή συσκευή. Αν χρησιμοποιήσατε γραμματοσειρά τρίτου μέρους ή μη τυπική επειδή ήσασταν δημιουργικοί στη δουλειά σας, τότε έχετε ακόμη περισσότερους λόγους για να ενσωματώσετε τη γραμματοσειρά σας. Διαφορετικά (χωρίς ενσωματωμένες γραμματοσειρές), το κείμενο ή οι αριθμοί στις διαφάνειες, η διάταξη, το στυλ κ.λπ. μπορεί να αλλάξουν ή να μετατραπούν σε συγκεχυμένα ορθογώνια.

Οι κλάσεις [FontsManager](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/FontsManager), [FontData](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fontdata/) και [Compress](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/compress/) και οι διεπαφές τους περιέχουν τις περισσότερες ιδιότητες και μεθόδους που χρειάζεστε για να εργαστείτε με ενσωματωμένες γραμματοσειρές σε παρουσιάσεις PowerPoint.

## **Λήψη και κατάργηση ενσωματωμένων γραμματοσειρών**

Η Aspose.Slides παρέχει τη μέθοδο [getEmbeddedFonts](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) (που εκτίθεται από την κλάση [FontsManager](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/FontsManager)) ώστε να μπορείτε να λάβετε (ή να ανακαλύψετε) τις γραμματοσειρές που έχουν ενσωματωθεί σε μια παρουσίαση. Για την αφαίρεση γραμματοσειρών, χρησιμοποιείται η μέθοδος [removeEmbeddedFont](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) (που εκτίθεται από την ίδια κλάση).

Αυτός ο κώδικας Java σας δείχνει πώς να λάβετε και να αφαιρέσετε ενσωματωμένες γραμματοσειρές από μια παρουσίαση:

```java
// Δημιουργεί ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
Presentation pres = new Presentation("EmbeddedFonts.pptx");
try {
    // Αποδίδει μια διαφάνεια που περιέχει ένα πλαίσιο κειμένου που χρησιμοποιεί την ενσωματωμένη "FunSized"
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

    // Αποθηκεύει την εικόνα στο δίσκο σε μορφή JPEG
    try {
        slideImage.save("picture1_out.jpg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }

    IFontsManager fontsManager = pres.getFontsManager();

    // Λαμβάνει όλες τις ενσωματωμένες γραμματοσειρές
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    // Βρίσκει τη γραμματοσειρά "Calibri"
    IFontData calibriEmbeddedFont = null;
    for (int i = 0; i < embeddedFonts.length; i++) {
        System.out.println(""+ embeddedFonts[i].getFontName());
        if ("Calibri".equals(embeddedFonts[i].getFontName())) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }

    // Καταργεί τη γραμματοσειρά "Calibri"
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);

    // Renders the presentation; "Calibri" font is replaced with an existing one
     slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

     // Αποθηκεύει την εικόνα στο δίσκο σε μορφή JPEG
     try {
         slideImage.save("picture2_out.jpg", ImageFormat.Jpeg);
     } finally {
         if (slideImage != null) slideImage.dispose();
     }

    // Αποθηκεύει την παρουσίαση χωρίς την ενσωματωμένη γραμματοσειρά "Calibri" στο δίσκο
    pres.save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Προσθήκη ενσωματωμένων γραμματοσειρών**

Χρησιμοποιώντας την απαρίθμηση [EmbedFontCharacters](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/embedfontcharacters/) καθώς και τις δύο υπερφορτωμένες εκδόσεις της μεθόδου [addEmbeddedFont](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-), μπορείτε να επιλέξετε τον προτιμώμενο (ενσωμάτωσης) κανόνα για την ενσωμάτωση των γραμματοσειρών σε μια παρουσίαση. Αυτός ο κώδικας Java σας δείχνει πώς να ενσωματώσετε και να προσθέσετε γραμματοσειρές σε μια παρουσίαση:

```java
// Φορτώνει την παρουσίαση
Presentation pres = new Presentation("Fonts.pptx");
try {
    IFontData[] allFonts = pres.getFontsManager().getFonts();
    IFontData[] embeddedFonts = pres.getFontsManager().getEmbeddedFonts();

    for (IFontData font : allFonts)
    {
        boolean embeddedFontsContainsFont = false;
        for (int i = 0; i < embeddedFonts.length; i++)
        {
            if (embeddedFonts[i].equals(font))
            {
                embeddedFontsContainsFont = true;
                break;
            }
        }
        if (!embeddedFontsContainsFont)
        {
            pres.getFontsManager().addEmbeddedFont(font, EmbedFontCharacters.All);

            embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
        }
    }

    // Αποθηκεύει την παρουσίαση στο δίσκο
    pres.save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Συμπίεση ενσωματωμένων γραμματοσειρών**

Για να μπορείτε να συμπιέσετε τις γραμματοσειρές που έχουν ενσωματωθεί σε μια παρουσίαση και να μειώσετε το μέγεθος του αρχείου, η Aspose.Slides παρέχει τη μέθοδο [compressEmbeddedFonts](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) (που εκτίθεται από την κλάση [Compress](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/compress/)).

Αυτός ο κώδικας Java σας δείχνει πώς να συμπιέσετε τις ενσωματωμένες γραμματοσειρές PowerPoint:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Πώς μπορώ να διαπιστώ ότι μια συγκεκριμένη γραμματοσειρά στην παρουσίαση θα αντικατασταθεί κατά τη διαδικασία απόδοσης παρά το ότι έχει ενσωματωθεί;**

Ελέγξτε τις [πληροφορίες υποκατάστασης](/slides/el/androidjava/font-substitution/) στον διαχειριστή γραμματοσειρών και τους [κανόνες υποκατάστασης/εφεδρείας](/slides/el/androidjava/fallback-font/): εάν η γραμματοσειρά δεν είναι διαθέσιμη ή περιορίζεται, θα χρησιμοποιηθεί μια εφεδρική.

**Αξίζει να ενσωματώσω τις «συστημικές» γραμματοσειρές όπως Arial/Calibri;**

Συνήθως όχι — είναι σχεδόν πάντα διαθέσιμες. Ωστόσο, για πλήρη φορητότητα σε «λεπτά» περιβάλλοντα (Docker, ένας διακομιστής Linux χωρίς προεγκατεστημένες γραμματοσειρές), η ενσωμάτωση των συστημικών γραμματοσειρών μπορεί να εξαλείψει τον κίνδυνο απροσδόκητων υποκαταστάσεων.