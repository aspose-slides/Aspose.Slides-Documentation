---
title: Απόδοση Παρουσιάσεων με Εφεδρικές Γραμματοσειρές σε Java
linktitle: Απόδοση Παρουσιάσεων
type: docs
weight: 30
url: /el/java/render-presentation-with-fallback-font/
keywords:
- εφεδρική γραμματοσειρά
- απόδοση PowerPoint
- απόδοση παρουσίασης
- απόδοση διαφάνειας
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Απόδοση παρουσιάσεων με εφεδρικές γραμματοσειρές στο Aspose.Slides για Java – διατηρήστε το κείμενο συνεπές σε PPT, PPTX και ODP με βήμα-βήμα παραδείγματα κώδικα Java."
---
## **Επισκόπηση**

Το Aspose.Slides σας επιτρέπει να αποδίδετε παρουσιάσεις χρησιμοποιώντας κανόνες εφεδρικής γραμματοσειράς. Αυτό το άρθρο δείχνει πώς να δημιουργήσετε μια συλλογή κανόνων εφεδρικής γραμματοσειράς, να τροποποιήσετε τους κανόνες αφαιρώντας ή προσθέτοντας εφεδρικές γραμματοσειρές, και να εκχωρήσετε τη συλλογή χρησιμοποιώντας τη μέθοδο `FontsManager.setFontFallBackRulesCollection`.

Μόλις η συλλογή κανόνων εφεδρικής γραμματοσειράς εκχωρηθεί στον `FontsManager` της παρουσίασης, οι κανόνες εφαρμόζονται κατά τις λειτουργίες όπως η αποθήκευση, η απόδοση και η μετατροπή της παρουσίασης. Το παράδειγμα δείχνει πώς να χρησιμοποιήσετε τους ρυθμισμένους κανόνες κατά την απόδοση μιας μικρογραφίας διαφάνειας και την αποθήκευσή της ως εικόνα PNG.

## **Απόδοση μιας Διαφάνειας Χρησιμοποιώντας Κανόνες Εφεδρικής Γραμματοσειράς**

1. Δημιουργούμε [συλλογή κανόνων εφεδρικής γραμματοσειράς](/slides/el/java/create-fallback-fonts-collection/).
1. [Αφαιρέστε](https://reference.aspose.com/slides/el/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) έναν κανόνα εφεδρικής γραμματοσειράς και [addFallBackFonts](https://reference.aspose.com/slides/el/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) σε άλλο κανόνα.
1. Ορίστε τη συλλογή κανόνων στο [getFontsManager](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation#getFontsManager--) .[getFontFallBackRulesCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) μέθοδο.
1. Με τη μέθοδο [Presentation.save](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation#save-java.lang.String-int-) μπορούμε να αποθηκεύσουμε την παρουσίαση στην ίδια μορφή ή σε άλλη. Αφού η συλλογή κανόνων εφεδρικής γραμματοσειράς οριστεί στο [FontsManager](https://reference.aspose.com/slides/el/java/com.aspose.slides/FontsManager), αυτοί οι κανόνες εφαρμόζονται σε όλες τις ενέργειες πάνω στην παρουσίαση: αποθήκευση, απόδοση, μετατροπή κλπ.

```java
// Δημιουργία νέου αντικειμένου μιας συλλογής κανόνων
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// δημιουργία πολλών κανόνων
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // Προσπάθεια αφαίρεσης της εφεδρικής γραμματοσειράς "Tahoma" από τους φορτωμένους κανόνες
    fallBackRule.remove("Tahoma");

    // Και ενημέρωση των κανόνων για το καθορισμένο εύρος
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000))
        fallBackRule.addFallBackFonts("Verdana");
}

// Μπορούμε επίσης να αφαιρέσουμε τυχόν υπάρχοντες κανόνους από τη λίστα
if (rulesList.size() > 0)
    rulesList.remove(rulesList.get_Item(0));

Presentation pres = new Presentation("input.pptx");
try {
    // Ανάθεση προετοιμασμένης λίστας κανόνων για χρήση
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // Απόδοση μικρογραφίας χρησιμοποιώντας την αρχικοποιημένη συλλογή κανόνων και αποθήκευση σε JPEG
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
Διαβάστε περισσότερα για το πώς να [Μετατρέψετε PPT και PPTX σε JPG σε Java](/slides/el/java/convert-powerpoint-to-jpg/).
{{% /alert %}}