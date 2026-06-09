---
title: Αποδόση Παρουσιάσεων με Εφεδρικές Γραμματοσειρές σε JavaScript
linktitle: Αποδόση Παρουσιάσεων
type: docs
weight: 30
url: /el/nodejs-java/render-presentation-with-fallback-font/
keywords:
- εφεδρική γραμματοσειρά
- απόδοση PowerPoint
- απόδοση παρουσίασης
- απόδοση διαφάνειας
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Αποδόση παρουσιάσεων με εφεδρικές γραμματοσειρές στο Aspose.Slides για Node.js – διατηρήστε το κείμενο συνεπές μεταξύ PPT, PPTX και ODP με βήμα-βήμα παραδείγματα κώδικα JavaScript."
---
## **Επισκόπηση**

Το Aspose.Slides σάς επιτρέπει να αποδίδετε παρουσιάσεις χρησιμοποιώντας κανόνες εφεδρικής γραμματοσειράς. Αυτό το άρθρο δείχνει πώς να δημιουργήσετε μια συλλογή κανόνων εφεδρικής γραμματοσειράς, να τροποποιήσετε τους κανόνες αφαιρώντας ή προσθέτοντας εφεδρικές γραμματοσειρές, και να εκχωρήσετε τη συλλογή χρησιμοποιώντας τη μέθοδο `FontsManager.setFontFallBackRulesCollection`.

Μόλις η συλλογή κανόνων εφεδρικής γραμματοσειράς εκχωρηθεί στον `FontsManager` της παρουσίασης, οι κανόνες εφαρμόζονται κατά τις λειτουργίες όπως η αποθήκευση, η απόδοση και η μετατροπή της παρουσίασης. Το παράδειγμα δείχνει πώς να χρησιμοποιήσετε τους ρυθμισμένους κανόνες κατά την απόδοση μιας μικρογραφίας διαφάνειας και την αποθήκευσή της ως εικόνα PNG.

## **Απόδοση Διαφάνειας Χρησιμοποιώντας Κανόνες Εφεδρικής Γραμματοσειράς**

Το παρακάτω παράδειγμα περιλαμβάνει τα εξής βήματα:

1. Δημιουργούμε [συλλογή κανόνων εφεδρικής γραμματοσειράς](/slides/el/nodejs-java/create-fallback-fonts-collection/).
1. [Αφαίρεση](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) ενός κανόνα εφεδρικής γραμματοσειράς και [addFallBackFonts](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) σε άλλο κανόνα.
1. Ορίστε τη συλλογή κανόνων στο [getFontsManager](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/FontsManager#getFontFallBackRulesCollection--) μέθοδο.
1. Με τη μέθοδο [Presentation.save](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) μπορούμε να αποθηκεύσουμε την παρουσίαση στην ίδια μορφή ή σε άλλη μορφή. Αφού η συλλογή κανόνων εφεδρικής γραμματοσειράς οριστεί στο [FontsManager](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/FontsManager), αυτοί οι κανόνες εφαρμόζονται κατά οποιεσδήποτε λειτουργίες στην παρουσίαση: αποθήκευση, απόδοση, μετατροπή κ.λπ.

```javascript
// Δημιουργία νέου αντικειμένου συλλογής κανόνων
var rulesList = new aspose.slides.FontFallBackRulesCollection();
// δημιουργία αριθμού κανόνων
rulesList.add(new aspose.slides.FontFallBackRule(0x400, 0x4ff, "Times New Roman"));
for (let i = 0; i < rulesList.size(); i++) {
    let fallBackRule = rulesList.get_Item(0);
    // Προσπάθεια αφαίρεσης της εφεδρικής γραμματοσειράς "Tahoma" από τους φορτωμένους κανόνες
    fallBackRule.remove("Tahoma");
    // Και ενημέρωση των κανόνων για το καθορισμένο εύρος
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000)) {
        fallBackRule.addFallBackFonts("Verdana");
    }
}
// Επίσης μπορούμε να αφαιρέσουμε τυχόν υπάρχοντες κανόνες από τη λίστα
if (rulesList.size() > 0) {
    rulesList.remove(rulesList.get_Item(0));
}
var pres = new aspose.slides.Presentation("input.pptx");
try {
    // Ανάθεση μιας προετοιμασμένης λίστας κανόνων για χρήση
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);
    // Απόδοση μικρογραφίας με χρήση της αρχικοποιημένης συλλογής κανόνων και αποθήκευση σε JPEG
    var slideImage = pres.getSlides().get_Item(0).getImage(1.0, 1.0);
    // Αποθήκευση της εικόνας στο δίσκο σε μορφή JPEG
    try {
        slideImage.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 
Διαβάστε περισσότερα σχετικά με το πώς να [Μετατρέψτε PPT και PPTX σε JPG σε JavaScript](/slides/el/nodejs-java/convert-powerpoint-to-jpg/).
{{% /alert %}}