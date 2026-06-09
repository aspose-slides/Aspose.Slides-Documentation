---
title: "Απόδοση παρουσιάσεων με εναλλακτικές γραμματοσειρές σε Android"
linktitle: "Απόδοση παρουσιάσεων"
type: docs
weight: 30
url: /el/androidjava/render-presentation-with-fallback-font/
keywords:
- εναλλακτική γραμματοσειρά
- απόδοση PowerPoint
- απόδοση παρουσίασης
- απόδοση διαφάνειας
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Απόδοση παρουσιάσεων με εναλλακτικές γραμματοσειρές στο Aspose.Slides για Android – διατηρήστε το κείμενο συνεπές μεταξύ PPT, PPTX και ODP με βήμα‑βήμα παραδείγματα κώδικα Java."
---
## **Επισκόπηση**

Aspose.Slides σας επιτρέπει να αποδίδετε παρουσιάσεις χρησιμοποιώντας κανόνες εναλλακτικής γραμματοσειράς. Αυτό το άρθρο δείχνει πώς να δημιουργήσετε μια συλλογή κανόνων εναλλακτικής γραμματοσειράς, να τροποποιήσετε τους κανόνες αφαιρώντας ή προσθέτοντας εναλλακτικές γραμματοσειρές, και να αναθέσετε τη συλλογή χρησιμοποιώντας τη μέθοδο `FontsManager.setFontFallBackRulesCollection`.

Μόλις η συλλογή κανόνων εναλλακτικής γραμματοσειράς ανατεθεί στο `FontsManager` της παρουσίασης, οι κανόνες εφαρμόζονται κατά τις λειτουργίες όπως η αποθήκευση, η απόδοση και η μετατροπή της παρουσίασης. Το παράδειγμα επιδεικνύει πώς να χρησιμοποιήσετε τους ρυθμισμένους κανόνες κατά την απόδοση μιας μικρογραφίας διαφάνειας και την αποθήκευση της ως εικόνα PNG.

## **Απόδοση διαφάνειας με κανόνες εναλλακτικής γραμματοσειράς**

Το παρακάτω παράδειγμα περιλαμβάνει τα εξής βήματα:

1. Δημιουργούμε [δημιουργία συλλογής κανόνων εναλλακτικής γραμματοσειράς](/slides/el/androidjava/create-fallback-fonts-collection/).
1. [Αφαίρεση](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) ενός κανόνα εναλλακτικής γραμματοσειράς και [addFallBackFonts](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) σε άλλο κανόνα.
1. Ορίστε τη συλλογή κανόνων στο [getFontsManager](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) μέθοδο.
1. Με [Presentation.save](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) μέθοδο μπορούμε να αποθηκεύσουμε την παρουσίαση στην ίδια μορφή ή σε άλλη. Αφού η συλλογή κανόνων εναλλακτικής γραμματοσειράς οριστεί στο [FontsManager](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/FontsManager), αυτοί οι κανόνες εφαρμόζονται σε όλες τις λειτουργίες της παρουσίασης: αποθήκευση, απόδοση, μετατροπή κ.λπ.

```java
// Δημιουργία νέας παρουσίασης μιας συλλογής κανόνων
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// δημιουργία ενός αριθμού κανόνων
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // Προσπάθεια αφαίρεσης της εναλλακτικής γραμματοσειράς "Tahoma" από τους φορτωμένους κανόνες
    fallBackRule.remove("Tahoma");

    // Και ενημέρωση των κανόνων για το καθορισμένο εύρος
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000))
        fallBackRule.addFallBackFonts("Verdana");
}

// Μπορούμε επίσης να αφαιρέσουμε τυχόν υπάρχουσες κανόνες από τη λίστα
if (rulesList.size() > 0)
    rulesList.remove(rulesList.get_Item(0));

Presentation pres = new Presentation("input.pptx");
try {
    // Ανάθεση της προετοιμασμένης λίστας κανόνων για χρήση
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // Απόδοση μικρογραφίας χρησιμοποιώντας τη συλλογή κανόνων που αρχικοποιήθηκε και αποθήκευση σε JPEG
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   // Αποθήκευση της εικόνας στο δίσκο σε μορφή JPEG
   try {
         slideImage.save("Slide_0.jpg", ImageFormat.Jpeg);
   } finally {
        if (slideImage != null) slideImage.dispose();
   }
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 
Διαβάστε περισσότερα σχετικά με [Μετατροπή PPT και PPTX σε JPG σε Android](/slides/el/androidjava/convert-powerpoint-to-jpg/).
{{% /alert %}}