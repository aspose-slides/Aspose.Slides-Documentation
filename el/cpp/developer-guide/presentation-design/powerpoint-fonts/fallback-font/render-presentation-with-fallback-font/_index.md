---
title: Απόδοση παρουσιάσεων με εφεδρικές γραμματοσειρές σε C++
linktitle: Απόδοση παρουσιάσεων
type: docs
weight: 30
url: /el/cpp/render-presentation-with-fallback-font/
keywords:
- εφεδρική γραμματοσειρά
- απόδοση PowerPoint
- απόδοση παρουσίασης
- απόδοση διαφάνειας
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Απόδοση παρουσιάσεων με εφεδρικές γραμματοσειρές στο Aspose.Slides για C++ – διατηρήστε το κείμενο συνεπές σε PPT, PPTX και ODP με βήμα-βήμα δείγματα κώδικα C++."
---
## **Επισκόπηση**

Το Aspose.Slides σας επιτρέπει να αποδίδετε παρουσιάσεις χρησιμοποιώντας κανόνες εφεδρικών γραμματοσειρών. Αυτό το άρθρο δείχνει πώς να δημιουργήσετε μια συλλογή κανόνων εφεδρικών γραμματοσειρών, να τροποποιήσετε τους κανόνες της αφαιρώντας ή προσθέτοντας εφεδρικές γραμματοσειρές, και να αναθέσετε τη συλλογή χρησιμοποιώντας τη μέθοδο `FontsManager::set_FontFallBackRulesCollection`.

Μόλις η συλλογή κανόνων εφεδρικών γραμματοσειρών ανατεθεί στο `FontsManager` της παρουσίασης, οι κανόνες εφαρμόζονται κατά τις λειτουργίες όπως η αποθήκευση, η απόδοση και η μετατροπή της παρουσίασης. Το παράδειγμα δείχνει πώς να χρησιμοποιήσετε τους ρυθμισμένους κανόνες κατά την απόδοση μιας μικρογραφίας διαφάνειας και την αποθήκευσή της ως εικόνα PNG.

## **Απόδοση διαφάνειας χρησιμοποιώντας κανόνες εφεδρικών γραμματοσειρών**

Το παρακάτω παράδειγμα περιλαμβάνει τα εξής βήματα:

1. Δημιουργούμε [συλλογή κανόνων εφεδρικών γραμματοσειρών](/slides/el/cpp/create-fallback-fonts-collection/).
1. Καταργούμε [Remove()](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontfallbackrule/remove/) έναν κανόνα εφεδρικής γραμματοσειράς και [AddFallBackFonts()](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/) σε έναν άλλο κανόνα.
1. Περάστε τη συλλογή κανόνων στη μέθοδο [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/).
1. Με τη μέθοδο [Presentation::Save()](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/save/) μπορούμε να αποθηκεύσουμε την παρουσίαση στην ίδια μορφή ή να την αποθηκεύσουμε σε άλλη. Αφού η συλλογή κανόνων εφεδρικών γραμματοσειρών έχει ρυθμιστεί στο FontsManager, αυτοί οι κανόνες εφαρμόζονται κατά οποιεσδήποτε λειτουργίες στην παρουσίαση: αποθήκευση, απόδοση, μετατροπή κ.λπ.

``` cpp
// Δημιουργήστε νέο στιγμιότυπο μιας συλλογής κανόνων
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// Δημιουργήστε έναν αριθμό κανόνων
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// Προσπάθεια αφαίρεσης της εφεδρικής γραμματοσειράς "Tahoma" από τους φορτωμένους κανόνες
	fallBackRule->Remove(u"Tahoma");

	// Και ενημέρωση των κανόνων για το καθορισμένο εύρος
	if ((fallBackRule->get_RangeEndIndex() >= static_cast<uint32_t>(0x4000)) && 
		(fallBackRule->get_RangeStartIndex() < static_cast<uint32_t>(0x5000)))
	{
		fallBackRule->AddFallBackFonts(u"Verdana");
	}
}

// Επίσης, μπορούμε να αφαιρέσουμε τυχόν υπάρχοντες κανόνες από τη λίστα
if (rulesList->get_Count() > 0)
{
	rulesList->Remove(rulesList->idx_get(0));
}

auto pres = System::MakeObject<Presentation>(u"input.pptx");
// Ανάθεση μιας προετοιμασμένης λίστας κανόνων για χρήση
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// Απόδοση μικρογραφίας χρησιμοποιώντας την αρχικοποιημένη συλλογή κανόνων και αποθήκευση σε PNG
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", ImageFormat::Png);
image->Dispose();

pres->Dispose();
```


{{% alert color="primary" %}} 
Διαβάστε περισσότερα σχετικά με το πώς να [Μετατρέψετε διαφάνειες PowerPoint σε PNG σε C++](/slides/el/cpp/convert-powerpoint-to-png/).
{{% /alert %}}