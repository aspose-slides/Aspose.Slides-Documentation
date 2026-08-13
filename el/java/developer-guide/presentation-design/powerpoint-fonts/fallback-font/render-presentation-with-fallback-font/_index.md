---
title: Απόδοση παρουσιάσεων με εφεδρικές γραμματοσειρές σε Java
linktitle: Απόδοση παρουσιάσεων
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
description: "Απόδοση παρουσιάσεων με εφεδρικές γραμματοσειρές στο Aspose.Slides για Java – διατηρήστε το κείμενο συνεπές σε PPT, PPTX και ODP με βήμα-βήμα δείγματα κώδικα Java."
---
## **Επισκόπηση**

Aspose.Slides σας επιτρέπει να αποδίδετε παρουσιάσεις χρησιμοποιώντας κανόνες εφεδρικών γραμματοσειρών. Αυτό το άρθρο δείχνει πώς να δημιουργήσετε μια συλλογή κανόνων εφεδρικών γραμματοσειρών, να τροποποιήσετε τους κανόνες αφαιρώντας ή προσθέτοντας εφεδρικές γραμματοσειρές, και να αναθέσετε τη συλλογή χρησιμοποιώντας τη μέθοδο `FontsManager.setFontFallBackRulesCollection`.

Μόλις η συλλογή κανόνων εφεδρικών γραμματοσειρών ανατεθεί στο `FontsManager` της παρουσίασης, οι κανόνες εφαρμόζονται κατά λειτουργίες όπως η αποθήκευση, η απόδοση και η μετατροπή της παρουσίασης. Το παράδειγμα επιδεικνύει πώς να χρησιμοποιήσετε τους ρυθμισμένους κανόνες κατά την απόδοση μιας μικρογραφίας διαφάνειας και την αποθήκευσή της ως εικόνα JPEG.

## **Απόδοση διαφάνειας χρησιμοποιώντας κανόνες εφεδρικών γραμματοσειρών**

Το παρακάτω παράδειγμα περιλαμβάνει τα εξής βήματα:

1. Δημιουργούμε [create fallback font rules collection](/slides/el/java/create-fallback-fonts-collection/).
2. [Remove] έναν κανόνα εφεδρικής γραμματοσειράς και [addFallBackFonts] σε έναν άλλο κανόνα.
3. Ορίστε τη συλλογή κανόνων στο [getFontsManager]... [getFontFallBackRulesCollection] μέθοδο.
4. Με τη μέθοδο [Presentation.save] μπορούμε να αποθηκεύσουμε την παρουσίαση στην ίδια μορφή ή να την αποθηκεύσουμε σε άλλη. Αφού η συλλογή κανόνων εφεδρικών γραμματοσειρών οριστεί στο [FontsManager], αυτοί οι κανόνες εφαρμόζονται κατά οποιεσδήποτε λειτουργίες στην παρουσίαση: αποθήκευση, απόδοση, μετατροπή κ.λπ.

```java
import com.aspose.slides.*;

// Δημιουργία νέου αντικειμένου συλλογής κανόνων
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// δημιουργία αρκετών κανόνων
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    //Προσπάθεια αφαίρεσης της εφεδρικής γραμματοσειράς "Tahoma" από τους φορτωμένους κανόνες
    fallBackRule.remove("Tahoma");

    //Και ενημέρωση των κανόνων για το συγκεκριμένο εύρος
    if ((fallBackRule.getRangeEndIndex() >= 0x400) && (fallBackRule.getRangeStartIndex() < 0x500))
        fallBackRule.addFallBackFonts("Verdana");
}

//Μπορούμε επίσης να αφαιρέσουμε υπάρχοντες κανόνες από τη λίστα, διατηρώντας τουλάχιστον έναν κανόνα για απόδοση
if (rulesList.size() > 1)
    rulesList.remove(rulesList.get_Item(1));

Presentation pres = new Presentation("input.pptx");
try {
    //Ανάθεση μιας προετοιμασμένης λίστας κανόνων για χρήση
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    //Απόδοση μικρογραφίας χρησιμοποιώντας τη συλλογή αρχικοποιημένων κανόνων και αποθήκευση σε JPEG
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
Διαβάστε περισσότερα σχετικά με το πώς να [Convert PPT and PPTX to JPG in Java](/slides/el/java/convert-powerpoint-to-jpg/).
{{% /alert %}}