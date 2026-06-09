---
title: Ενσωμάτωση Γραμματοσειρών σε Παρουσιάσεις χρησιμοποιώντας Java
linktitle: Ενσωμάτωση Γραμματοσειράς
type: docs
weight: 40
url: /el/java/embedded-font/
keywords:
- προσθήκη γραμματοσειράς
- ενσωμάτωση γραμματοσειράς
- ενσωμάτωση γραμματοσειράς
- λήψη ενσωματωμένης γραμματοσειράς
- προσθήκη ενσωματωμένης γραμματοσειράς
- αφαίρεση ενσωματωμένης γραμματοσειράς
- συμπίεση ενσωματωμένης γραμματοσειράς
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Ενσωματώστε γραμματοσειρές TrueType σε παρουσιάσεις PowerPoint και OpenDocument με το Aspose.Slides για Java, διασφαλίζοντας ακριβή απόδοση σε όλες τις πλατφόρμες."
---
## **Εισαγωγή**

**Οι ενσωματωμένες γραμματοσειρές στο PowerPoint** είναι χρήσιμες όταν θέλετε η παρουσίασή σας να εμφανίζεται σωστά σε οποιοδήποτε σύστημα ή συσκευή. Αν χρησιμοποιήσατε μια γραμματοσειρά τρίτου μέρους ή μη τυπική επειδή ήσαστε δημιουργικοί στο έργο σας, τότε έχετε ακόμη περισσότερους λόγους να ενσωματώσετε τη γραμματοσειρά σας. Διαφορετικά (χωρίς ενσωματωμένες γραμματοσειρές), τα κείμενα ή οι αριθμοί στις διαφάνειές σας, η διάταξη, το στυλ κ.λπ. μπορεί να αλλάξουν ή να μετατραπούν σε συγχύσιμες ορθογώνιες περιοχές. 

Η κλάση [FontsManager](https://reference.aspose.com/slides/el/java/com.aspose.slides/FontsManager) κλάση [FontData](https://reference.aspose.com/slides/el/java/com.aspose.slides/fontdata/) κλάση [Compress](https://reference.aspose.com/slides/el/java/com.aspose.slides/compress/) και οι διεπαφές τους περιέχουν τις περισσότερες ιδιότητες και μεθόδους που χρειάζεστε για εργασία με ενσωματωμένες γραμματοσειρές σε παρουσιάσεις PowerPoint. 

## **Ανάκτηση και Αφαίρεση Ενσωματωμένων Γραμματοσειρών**

Το Aspose.Slides παρέχει τη μέθοδο [getEmbeddedFonts](https://reference.aspose.com/slides/el/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) (προβάλλεται από την κλάση [FontsManager](https://reference.aspose.com/slides/el/java/com.aspose.slides/FontsManager)) ώστε να μπορείτε να ανακτήσετε (ή να διαπιστώσετε) τις γραμματοσειρές που είναι ενσωματωμένες σε μια παρουσίαση. Για να αφαιρέσετε γραμματοσειρές, χρησιμοποιείται η μέθοδος [removeEmbeddedFont](https://reference.aspose.com/slides/el/java/com.aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) (προβάλλεται από την ίδια κλάση). 

Αυτός ο κώδικας Java δείχνει πώς να ανακτήσετε και να αφαιρέσετε ενσωματωμένες γραμματοσειρές από μια παρουσίαση:

```java
// Δημιουργεί ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
Presentation pres = new Presentation("EmbeddedFonts.pptx");
try {
    // Αποδίδει μία διαφάνεια που περιέχει πλαίσιο κειμένου που χρησιμοποιεί την ενσωματωμένη "FunSized"
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

    // Αποθηκεύει την εικόνα στο δίσκο μορφής JPEG
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

    // Αφαιρεί τη γραμματοσειρά "Calibri"
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);

    // Αποδίδει την παρουσίαση· η γραμματοσειρά "Calibri" αντικαθίσταται με μια υπάρχουσα
     slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

     // Αποθηκεύει την εικόνα στο δίσκο μορφής JPEG
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

## **Προσθήκη Ενσωματωμένων Γραμματοσειρών**

Χρησιμοποιώντας την απαρίθμηση [EmbedFontCharacters](https://reference.aspose.com/slides/el/java/com.aspose.slides/embedfontcharacters/) και δύο υπερφορτωμένες εκδοχές της μεθόδου [addEmbeddedFont](https://reference.aspose.com/slides/el/java/com.aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) μπορείτε να επιλέξετε τον προτιμητέο (ενσωματωτικό) κανόνα για την ενσωμάτωση των γραμματοσειρών σε μια παρουσίαση. Αυτός ο κώδικας Java δείχνει πώς να ενσωματώσετε και να προσθέσετε γραμματοσειρές σε μια παρουσίαση:

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

## **Συμπίεση Ενσωματωμένων Γραμματοσειρών**

Για να μπορείτε να συμπιέσετε τις γραμματοσειρές που είναι ενσωματωμένες σε μια παρουσίαση και να μειώσετε το μέγεθος του αρχείου, το Aspose.Slides παρέχει τη μέθοδο [compressEmbeddedFonts](https://reference.aspose.com/slides/el/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) (προβάλλεται από την κλάση [Compress](https://reference.aspose.com/slides/el/java/com.aspose.slides/compress/)). 

Αυτός ο κώδικας Java δείχνει πώς να συμπιέσετε ενσωματωμένες γραμματοσειρές PowerPoint:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Συχνές ερωτήσεις**

**Πώς μπορώ να καταλάβω αν μια συγκεκριμένη γραμματοσειρά στην παρουσίαση θα αντικατασταθεί κατά τη διάρκεια της απόδοσης παρά την ενσωμάτωση;**

Ελέγξτε τις [πληροφορίες αντικατάστασης](/slides/el/java/font-substitution/) στον διαχειριστή γραμματοσειρών και τους [κανόνες εναλλακτικού/αντικατάστασης](/slides/el/java/fallback-font/): εάν η γραμματοσειρά δεν είναι διαθέσιμη ή είναι περιορισμένη, θα χρησιμοποιηθεί μια εναλλακτική.

**Αξίζει να ενσωματώσετε τις "συστημικές" γραμματοσειρές όπως Arial/Calibri;**

Γενικά όχι—είναι σχεδόν πάντα διαθέσιμες. Ωστόσο, για πλήρη φορητότητα σε «λεπτά» περιβάλλοντα (Docker, ένας διακομιστής Linux χωρίς προεγκατεστημένες γραμματοσειρές), η ενσωμάτωση συστημικών γραμματοσειρών μπορεί να εξαφανίσει τον κίνδυνο απρόσμενων αντικαταστάσεων.