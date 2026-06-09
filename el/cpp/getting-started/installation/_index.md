---
title: Εγκατάσταση
type: docs
weight: 70
url: /el/cpp/installation/
keywords:
- εγκατάσταση Aspose.Slides
- λήψη Aspose.Slides
- χρήση Aspose.Slides
- Εγκατάσταση Aspose.Slides
- Windows
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Μάθετε πώς να εγκαταστήσετε γρήγορα το Aspose.Slides για C++. Οδηγός βήμα προς βήμα, απαιτήσεις συστήματος και παραδείγματα κώδικα — ξεκινήστε να εργάζεστε με παρουσιάσεις PowerPoint σήμερα!"
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εγκαταστήσετε το Aspose.Slides στα Windows. Επικεντρώνεται στην εγκατάσταση μέσω NuGet και δείχνει πώς να προσθέσετε τη βιβλιοθήκη σε ένα έργο Visual Studio είτε μέσω του NuGet Package Manager είτε μέσω της Package Manager Console στα Windows. Περιγράφει επίσης πώς να ενημερώσετε το πακέτο και να εγκαταστήσετε προεκδόσεις όταν χρειάζεται.

## **Windows**
Το NuGet παρέχει την πιο εύκολη διαδρομή για λήψη και εγκατάσταση των Aspose API για C++ σε υπολογιστές.

### **Επιλογή 1: Εγκατάσταση ή ενημέρωση Aspose.Slides για C++ από τον NuGet Package Manager**

1. Ανοίξτε το Microsoft Visual Studio.  
2. Δημιουργήστε μια απλή εφαρμογή console. Ή μπορείτε να ανοίξετε το προτιμώμενο έργο σας.  
3. Μεταβείτε στο **Tools** > **NuGet package manager**.  
4. Κάτω από **Browse**, πληκτρολογήστε *Aspose.Slides.Cpp* στο πεδίο κειμένου.  

![todo:image_alt_text](installation_1.png)

3. Κάντε κλικ στην έκδοση που χρειάζεστε **Aspose.Slides.Cpp** και στη συνέχεια κλικ **Install**.  
   * Αν θέλετε να ενημερώσετε το Aspose.Slides—που σημαίνει ότι το έχετε ήδη εγκατεστημένο—κάντε κλικ **Update** αντί για αυτό.  

Το επιλεγμένο API κατεβαίνει και προστίθεται ως αναφορά στο έργο σας.

### **Επιλογή 2: Εγκατάσταση ή ενημέρωση Aspose.Slides μέσω της Package Manager Console**

Για να αναφερθείτε στο [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.Cpp/) χρησιμοποιώντας την κονσόλα διαχειριστή πακέτων, κάντε τα εξής:

1. Ανοίξτε τη λύση/το έργο σας στο Visual Studio.

1. Μεταβείτε στο **Tools** > **NuGet Package Manager** > **Package Manager Console**.  

   Η κονσόλα Package Manager ανοίγει.  

![todo:image_alt_text](installation_2.png)

4. Πληκτρολογήστε αυτήν την εντολή: `Install-Package Aspose.Slides.Cpp`  
> Αν θέλετε να εγκαταστήσετε την έκδοση x86, χρησιμοποιήστε το πακέτο Aspose.Slides.Cpp.x86: `Install-Package Aspose.Slides.Cpp.x86`

5. Πατήστε το πλήκτρο Enter.

   Η πιο πρόσφατη πλήρης έκδοση εγκαθίσταται στην εφαρμογή σας.  

   * Εναλλακτικά, μπορείτε να προσθέσετε το κατάληξη `-prerelease` στην εντολή για να υποδείξετε ότι πρέπει επίσης να εγκατασταθεί η πιο πρόσφατη έκδοση (συμπεριλαμβανομένων των hotfix).

![todo:image_alt_text](installation_3.png)

Μόλις ολοκληρωθεί η λήψη, θα πρέπει να δείτε κάποιες μηνύματα επιβεβαίωσης.  

![todo:image_alt_text](installation_4.png)

Αν δεν γνωρίζετε το [Aspose EULA](https://about.aspose.com/legal/eula), ίσως θελήσετε να διαβάσετε την άδεια που αναφέρεται στο URL.

Στην Package Manager Console, μπορείτε να εκτελέσετε την εντολή `Update-Package Aspose.Slides.Cpp` για να ελέγξετε αν υπάρχουν ενημερώσεις για το πακέτο Aspose.Slides. Οι ενημερώσεις (αν βρεθούν) εγκαθίστανται αυτόματα. Μπορείτε επίσης να χρησιμοποιήσετε την κατάληξη `-prerelease` για να ενημερώσετε την πιο πρόσφατη έκδοση.

### **Χρήση φακέλων Include και lib**
1. [Download](https://downloads.aspose.com/slides/el/cpp) την πιο πρόσφατη έκδοση του Aspose.Slides για C++.  
1. Αποσυμπιέστε το φάκελο στο περιβάλλον παραγωγής.  
1. Για χρήση του Aspose.Slides για C++, αναφέρετε τους φακέλους Include και lib στο έργο σας.

## **FAQ**

**Υπάρχει δωρεάν έκδοση ή περιορισμός δοκιμής;**

Ναι, από προεπιλογή το Aspose.Slides λειτουργεί σε λειτουργία αξιολόγησης, η οποία προσθέτει υδατογραφήματα και μπορεί να έχει άλλους περιορισμούς. Για να αφαιρέσετε τους περιορισμούς, πρέπει να εφαρμόσετε μια έγκυρη [license](/slides/el/cpp/licensing/).