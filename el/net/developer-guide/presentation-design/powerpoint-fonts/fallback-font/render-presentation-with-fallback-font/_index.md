---
title: Απόδοση Παρουσιάσεων με Εφεδρικές Γραμματοσειρές σε .NET
linktitle: Απόδοση Παρουσιάσεων
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
description: "Απόδοση παρουσιάσεων με εφεδρικές γραμματοσειρές στο Aspose.Slides για .NET – διατηρήστε το κείμενο συνεπές σε PPT, PPTX και ODP με βήμα-βήμα δείγματα κώδικα C#."
---
## **Επισκόπηση**

Το Aspose.Slides σας επιτρέπει να αποδίδετε παρουσιάσεις χρησιμοποιώντας κανόνες εφεδρικής γραμματοσειράς. Αυτό το άρθρο δείχνει πώς να δημιουργήσετε μια συλλογή κανόνων εφεδρικής γραμματοσειράς, να τροποποιήσετε τους κανόνες αφαιρώντας ή προσθέτοντας εφεδρικές γραμματοσειρές, και να εκχωρήσετε τη συλλογή στην ιδιότητα `FontsManager.FontFallBackRulesCollection`.

Μόλις η συλλογή κανόνων εφεδρικής γραμματοσειράς εκχωρηθεί στο `FontsManager` της παρουσίασης, οι κανόνες εφαρμόζονται κατά τις λειτουργίες όπως η αποθήκευση, η απόδοση και η μετατροπή της παρουσίασης. Το παράδειγμα δείχνει πώς να χρησιμοποιήσετε τους διαμορφωμένους κανόνες κατά την απόδοση ενός μικρογραφικού διαφάνειας και την αποθήκευσή του ως εικόνα PNG.

## **Απόδοση Διαφάνειας με Χρήση Κανόνων Εφεδρικής Γραμματοσειράς**

1. Διενεργούμε [συλλογή κανόνων εφεδρικής γραμματοσειράς](/slides/el/net/create-fallback-fonts-collection/).
1. Χρησιμοποιήστε τη μέθοδο [Remove()](https://reference.aspose.com/slides/el/net/aspose.slides/fontfallbackrule/methods/remove) για να αφαιρέσετε έναν κανόνα εφεδρικής γραμματοσειράς και τη μέθοδο [AddFallBackFonts()](https://reference.aspose.com/slides/el/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) για να προσθέσετε εφεδρικές γραμματοσειρές σε έναν άλλο κανόνα.
1. Ορίστε τη συλλογή κανόνων στην ιδιότητα [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/el/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection).
1. Με τη μέθοδο [Presentation.Save()](https://reference.aspose.com/slides/el/net/aspose.slides.presentation/save/methods/4) μπορούμε να αποθηκεύσουμε την παρουσίαση στην ίδια μορφή ή σε άλλη. Αφού η συλλογή κανόνων εφεδρικής γραμματοσειράς οριστεί στο FontsManager, αυτοί οι κανόνες εφαρμόζονται σε όλες τις λειτουργίες της παρουσίασης: αποθήκευση, απόδοση, μετατροπή κ.ά.

```c#
 // Δημιουργία νέας εμφάνισης μιας συλλογής κανόνων
 IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

 // Δημιουργία αριθμού κανόνων
 rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
 //rulesList.Add(new FontFallBackRule(...));

 foreach (IFontFallBackRule fallBackRule in rulesList)
 {
     //Προσπάθεια αφαίρεσης της εφεδρικής γραμματοσειράς "Tahoma" από τους φορτωμένους κανόνες
     fallBackRule.Remove("Tahoma");

     //Και ενημέρωση των κανόνων για το καθορισμένο εύρος
     if ((fallBackRule.RangeEndIndex >= 0x4000) && (fallBackRule.RangeStartIndex < 0x5000))
         fallBackRule.AddFallBackFonts("Verdana");
 }

 //Μπορούμε επίσης να αφαιρέσουμε τυχόν υπάρχοντες κανόνες από τη λίστα
 if (rulesList.Count > 0)
     rulesList.Remove(rulesList[0]);

 using (Presentation pres = new Presentation("input.pptx"))
 {
     //Ανάθεση προετοιμασμένης λίστας κανόνων για χρήση
     pres.FontsManager.FontFallBackRulesCollection = rulesList;

     //Απόδοση μικρογραφίας με χρήση της αρχικοποιημένης συλλογής κανόνων και αποθήκευση σε PNG
     using (IImage image = pres.Slides[0].GetImage(1f, 1f))
     {
         image.Save("Slide_0.png", ImageFormat.Png);
     }
 }
```

{{% alert color="primary" %}} 
Διαβάστε περισσότερα για [Αποθήκευση και Μετατροπή στην Παρουσίαση](/slides/el/net/convert-powerpoint-to-png/).
{{% /alert %}}