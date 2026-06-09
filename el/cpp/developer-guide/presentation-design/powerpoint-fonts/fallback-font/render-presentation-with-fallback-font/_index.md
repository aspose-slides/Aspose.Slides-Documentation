---
title: Απόδοση παρουσιάσεων με εναλλακτικές γραμματοσειρές σε С++
linktitle: Απόδοση παρουσιάσεων
type: docs
weight: 30
url: /el/cpp/render-presentation-with-fallback-font/
keywords:
- εναλλακτική γραμματοσειρά
- απόδοση PowerPoint
- απόδοση παρουσίασης
- απόδοση διαφάνειας
- PowerPoint
- OpenDocument
- παρουσίαση
- С++
- Aspose.Slides
description: "Απόδοση παρουσιάσεων με εναλλακτικές γραμματοσειρές στο Aspose.Slides για С++ - διατηρήστε το κείμενο συνεπές μεταξύ PPT, PPTX και ODP με βήμα-βήμα παραδείγματα κώδικα σε С++."
---
## **Επισκόπηση**

Το Aspose.Slides σας επιτρέπει να αποδίδετε παρουσιάσεις χρησιμοποιώντας κανόνες εναλλακτικής γραμματοσειράς. Αυτό το άρθρο δείχνει πώς να δημιουργήσετε μια συλλογή κανόνων εναλλακτικής γραμματοσειράς, να τροποποιήσετε τους κανόνες αφαιρώντας ή προσθέτοντας εναλλακτικές γραμματοσειρές, και να αναθέσετε τη συλλογή χρησιμοποιώντας τη μέθοδο `FontsManager::set_FontFallBackRulesCollection`.

Μόλις η συλλογή κανόνων εναλλακτικής γραμματοσειράς εκχωρηθεί στο `FontsManager` της παρουσίασης, οι κανόνες εφαρμόζονται κατά τις λειτουργίες όπως η αποθήκευση, η απόδοση και η μετατροπή της παρουσίασης. Το παράδειγμα δείχνει πώς να χρησιμοποιήσετε τους ρυθμισμένους κανόνες κατά την απόδοση μιας μικρογραφίας διαφάνειας και την αποθήκευσή της ως εικόνα PNG.

## **Απόδοση διαφάνειας χρησιμοποιώντας κανόνες εναλλακτικής γραμματοσειράς**

Το παρακάτω παράδειγμα περιλαμβάνει τα εξής βήματα:

1. Δημιουργούμε [συλλογή κανόνων εναλλακτικής γραμματοσειράς](/slides/el/cpp/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontfallbackrule/remove/) έναν κανόνα εναλλακτικής γραμματοσειράς και [AddFallBackFonts()](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/) σε έναν άλλο κανόνα.
1. Περνάμε τη συλλογή κανόνων στη μέθοδο [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/el/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/).
1. Με τη μέθοδο [Presentation::Save()](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/save/) μπορούμε να αποθηκεύσουμε την παρουσίαση στην ίδια μορφή ή να τη σώσουμε σε άλλη. Αφού η συλλογή κανόνων εναλλακτικής γραμματοσειράς έχει οριστεί στο FontsManager, αυτοί οι κανόνες εφαρμόζονται σε οποιεσδήποτε λειτουργίες της παρουσίασης: αποθήκευση, απόδοση, μετατροπή κ.ά.

``` cpp
// Δημιουργία νέας στιγμής μιας συλλογής κανόνων
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// Δημιουργία ενός αριθμού κανόνων
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// Προσπάθεια αφαίρεσης της εναλλακτικής γραμματοσειράς "Tahoma" από τους φορτωμένους κανόνες
	fallBackRule->Remove(u"Tahoma");

	// Και ενημέρωση των κανόνων για το καθορισμένο εύρος
	if ((fallBackRule->get_RangeEndIndex() >= static_cast<uint32_t>(0x4000)) && 
		(fallBackRule->get_RangeStartIndex() < static_cast<uint32_t>(0x5000)))
	{
		fallBackRule->AddFallBackFonts(u"Verdana");
	}
}

// Επίσης μπορούμε να αφαιρέσουμε οποιονδήποτε υπάρχον κανόνα από τη λίστα
if (rulesList->get_Count() > 0)
{
	rulesList->Remove(rulesList->idx_get(0));
}

auto pres = System::MakeObject<Presentation>(u"input.pptx");
// Assigning a prepared rules list for using
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// Rendering of thumbnail with using of initialized rules collection and saving to PNG
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", ImageFormat::Png);
image->Dispose();

pres->Dispose();
```

{{% alert color="primary" %}} 
Διαβάστε περισσότερα για το πώς να [Μετατρέψετε διαφάνειες PowerPoint σε PNG σε C++](/slides/el/cpp/convert-powerpoint-to-png/).
{{% /alert %}}