---
title: "Απόδοση Παρουσιάσεων με Εφεδρικές Γραμματοσειρές σε .NET"
linktitle: "Απόδοση Παρουσιάσεων"
type: docs
weight: 30
url: /el/net/render-presentation-with-fallback-font/
keywords:
- εφεδρική γραμματοσειρά
- απόδοση PowerPoint
- απόδοση παρουσίασης
- απόδοση διαφάνειας
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Απόδοση παρουσιάσεων με εφεδρικές γραμματοσειρές στο Aspose.Slides για .NET – διατηρήστε το κείμενο συνεπές μεταξύ PPT, PPTX και ODP με βήμα προς βήμα δείγματα κώδικα C#."
---
## **Επισκόπηση**

Το Aspose.Slides σάς επιτρέπει να αποδίδετε παρουσιάσεις χρησιμοποιώντας κανόνες εφεδρικής γραμματοσειράς. Αυτό το άρθρο δείχνει πώς να δημιουργήσετε μια συλλογή κανόνων εφεδρικής γραμματοσειράς, να τροποποιήσετε τους κανόνες αφαιρώντας ή προσθέτοντας εφεδρικές γραμματοσειρές και να εκχωρήσετε τη συλλογή στην ιδιότητα `FontsManager.FontFallBackRulesCollection`.

Μόλις η συλλογή κανόνων εφεδρικής γραμματοσειράς εκχωρηθεί στο `FontsManager` της παρουσίασης, οι κανόνες εφαρμόζονται κατά λειτουργίες όπως η αποθήκευση, η απόδοση και η μετατροπή της παρουσίασης. Το παράδειγμα δείχνει πώς να χρησιμοποιήσετε τους ρυθμισμένους κανόνες κατά την απόδοση μιας μικρογραφίας διαφάνειας και την αποθήκευσή της ως εικόνα PNG.

## **Απόδοση Διαφάνειας Χρησιμοποιώντας Κανόνες Εφεδρικής Γραμματοσειράς**

Το παρακάτω παράδειγμα περιλαμβάνει τα παρακάτω βήματα:

1. Δημιουργούμε [συλλογή κανόνων εφεδρικής γραμματοσειράς](/slides/el/net/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/el/net/aspose.slides/fontfallbackrule/methods/remove) έναν κανόνα εφεδρικής γραμματοσειράς και [AddFallBackFonts()](https://reference.aspose.com/slides/el/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) σε έναν άλλο κανόνα.
1. Ορίστε τη συλλογή κανόνων στην ιδιότητα [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/el/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) ιδιότητα.
1. Με τη μέθοδο [Presentation.Save()](https://reference.aspose.com/slides/el/net/aspose.slides.presentation/save/methods/4) μπορούμε να αποθηκεύσουμε την παρουσίαση στην ίδια μορφή ή σε άλλη. Αφού η συλλογή κανόνων εφεδρικής γραμματοσειράς έχει οριστεί στο FontsManager, αυτοί οι κανόνες εφαρμόζονται σε οποιεσδήποτε λειτουργίες πάνω στην παρουσίαση: αποθήκευση, απόδοση, μετατροπή κ.ά.

```c#
using Aspose.Slides;

// Δημιουργία νέας συλλογής κανόνων
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// δημιουργία πολλαπλών κανόνων
rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.Add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

foreach (IFontFallBackRule fallBackRule in rulesList)
{
	//Προσπάθεια αφαίρεσης της εφεδρικής γραμματοσειράς "Tahoma" από τους φορτωμένους κανόνες
	fallBackRule.Remove("Tahoma");

	//Και ενημέρωση κανόνων για το καθορισμένο εύρος
	if ((fallBackRule.RangeEndIndex >= 0x400) && (fallBackRule.RangeStartIndex < 0x500))
		fallBackRule.AddFallBackFonts("Verdana");
}

//Also μπορούμε να αφαιρέσουμε τυχόν υπάρχοντες κανόνες από τη λίστα, διατηρώντας τουλάχιστον έναν κανόνα για απόδοση
if (rulesList.Count > 1)
	rulesList.Remove(rulesList[1]);

using (Presentation pres = new Presentation("input.pptx"))
{
    //Ανάθεση προετοιμασμένης λίστας κανόνων για χρήση
    pres.FontsManager.FontFallBackRulesCollection = rulesList;

    //Απόδοση μικρογραφίας χρησιμοποιώντας την αρχικοποιημένη συλλογή κανόνων και αποθήκευση ως PNG
    using (IImage image = pres.Slides[0].GetImage(1f, 1f))
    {
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

{{% alert color="info" %}} 
Διαβάστε περισσότερα για [Save and Convertion in Presentation](/slides/el/net/convert-powerpoint-to-png/).
{{% /alert %}}