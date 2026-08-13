---
title: "Απόδοση Παρουσιάσεων με Εφεδρικές Γραμματοσειρές στο Android"
linktitle: "Απόδοση Παρουσιάσεων"
type: docs
weight: 30
url: /el/androidjava/render-presentation-with-fallback-font/
keywords:
- εφεδρική γραμματοσειρά
- απόδοση PowerPoint
- απόδοση παρουσίασης
- απόδοση διαφάνειας
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Απόδοση παρουσιάσεων με εφεδρικές γραμματοσειρές στο Aspose.Slides για Android – διατηρήστε το κείμενο συνεπές σε PPT, PPTX και ODP με βήμα-βήμα παραδείγματα κώδικα Java."
---
## **Επισκόπηση**

Το Aspose.Slides σας επιτρέπει να αποδίδετε παρουσιάσεις χρησιμοποιώντας κανόνες εφεδρικής γραμματοσειράς. Αυτό το άρθρο δείχνει πώς να δημιουργήσετε μια συλλογή κανόνων εφεδρικής γραμματοσειράς, να τροποποιήσετε τους κανόνες αφαιρώντας ή προσθέτοντας εφεδρικές γραμματοσειρές, και να αναθέσετε τη συλλογή χρησιμοποιώντας τη μέθοδο `FontsManager.setFontFallBackRulesCollection`.

Μόλις η συλλογή κανόνων εφεδρικής γραμματοσειράς ανατεθεί στο `FontsManager` της παρουσίασης, οι κανόνες εφαρμόζονται κατά τις λειτουργίες όπως η αποθήκευση, η απόδοση και η μετατροπή της παρουσίασης. Το παράδειγμα δείχνει πώς να χρησιμοποιήσετε τους ρυθμισμένους κανόνες κατά την απόδοση μιας μικρογραφίας διαφάνειας και την αποθήκευσή της ως εικόνα JPEG.

## **Απόδοση διαφάνειας χρησιμοποιώντας κανόνες εφεδρικής γραμματοσειράς**

Το παρακάτω παράδειγμα περιλαμβάνει τα εξής βήματα:

1. Δημιουργούμε τη [συλλογή κανόνων εφεδρικής γραμματοσειράς](/slides/el/androidjava/create-fallback-fonts-collection/).
1. [Κατάργηση] ενός κανόνα εφεδρικής γραμματοσειράς και addFallBackFonts σε άλλο κανόνα.
1. Ορίστε τη συλλογή κανόνων στο [getFontsManager](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) μέθοδο.
1. Με τη [Presentation.save](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) μέθοδο μπορούμε να αποθηκεύσουμε την παρουσίαση στην ίδια μορφή ή σε διαφορετική. Αφού η συλλογή κανόνων εφεδρικής γραμματοσειράς έχει οριστεί στο [FontsManager](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/FontsManager), αυτοί οι κανόνες εφαρμόζονται σε όλες τις ενέργειες της παρουσίασης: αποθήκευση, απόδοση, μετατροπή κ.λπ.

```java
import com.aspose.slides.*;

// Δημιουργία νέου στιγμιοτύπου συλλογής κανόνων
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// create a number of rules
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    //Προσπάθεια αφαίρεσης της εφεδρικής γραμματοσειράς "Tahoma" από τους φορτωμένους κανόνες
    fallBackRule.remove("Tahoma");

    //Και ενημέρωση των κανόνων για το καθορισμένο εύρος
    if ((fallBackRule.getRangeEndIndex() >= 0x400) && (fallBackRule.getRangeStartIndex() < 0x500))
        fallBackRule.addFallBackFonts("Verdana");
}

//Επίσης μπορούμε να αφαιρέσουμε τυχόν υπάρχοντες κανόνες από τη λίστα, διατηρώντας τουλάχιστον έναν κανόνα για απόδοση
if (rulesList.size() > 1)
    rulesList.remove(rulesList.get_Item(1));

Presentation pres = new Presentation("input.pptx");
try {
    //Ανάθεση προετοιμασμένης λίστας κανόνων για χρήση
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    //Απόδοση μικρογραφίας χρησιμοποιώντας τη αρχικοποιημένη συλλογή κανόνων και αποθήκευση σε JPEG
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   //Αποθήκευση της εικόνας στο δίσκο σε μορφή JPEG
   try {
         slideImage.save("Slide_0.jpg", ImageFormat.Jpeg);
   } finally {
        if (slideImage != null) slideImage.dispose();
   }
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 
Διαβάστε περισσότερα σχετικά με [Μετατροπή PPT και PPTX σε JPG στο Android](/slides/el/androidjava/convert-powerpoint-to-jpg/).
{{% /alert %}}