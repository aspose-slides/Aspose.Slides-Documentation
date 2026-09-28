---
title: Πακέτο διασταυρούμενης πλατφόρμας για .NET 6 και μεταγενέστερα
linktitle: Πακέτο διασταυρούμενης πλατφόρμας
type: docs
weight: 235
url: /el/net/net6/
keywords:
- Aspose.Slides.NET6.CrossPlatform
- διασταυρούμενη πλατφόρμα
- υποστήριξη .NET 6
- Linux
- macOS
- fontconfig
- libgdiplus
- System.Drawing.Common
- CS0433
- AWS Lambda
- .NET
- C#
- Aspose.Slides
description: "Μάθετε πότε να χρησιμοποιήσετε το πακέτο Aspose.Slides.NET6.CrossPlatform: γιατί υπάρχει, τις πλατφόρμες στις οποίες λειτουργεί και τι χρειάζεται σε Linux αντί για libgdiplus."
---
## **Εισαγωγή**

Το Aspose.Slides για .NET δημοσιεύεται ως δύο πακέτα NuGet. [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) σχεδιάζει διαφάνειες μέσω της βιβλιοθήκης System.Drawing.Common της Microsoft. [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) τις σχεδιάζει με τη δική του μηχανή γραφικών. Αυτό το άρθρο εξηγεί γιατί υπάρχει το δεύτερο πακέτο, πού εκτελείται, τι χρειάζεται σε Linux, και πώς συνυπάρχει με το System.Drawing.Common σε ένα έργο.

## **Γιατί ένα ξεχωριστό πακέτο**

Από το .NET 6 και μετά, η Microsoft υποστηρίζει το System.Drawing.Common [μόνο στα Windows](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only). Ως αποτέλεσμα, σε Linux το Aspose.Slides.NET χρειάζεται το διακόπτη `System.Drawing.EnableUnixSupport` επιπλέον της βιβλιοθήκης `libgdiplus`, και αποτυγχάνει αν το έργο αναφέρεται σε System.Drawing.Common έκδοση 7 ή νεότερη. [System Requirements](/slides/el/net/system-requirements/) περιγράφει αυτές τις προϋποθέσεις.

Το Aspose.Slides.NET6.CrossPlatform δεν χρησιμοποιεί το System.Drawing.Common ή το `libgdiplus`. Η μηχανή γραφικών του είναι μια εγγενής βιβλιοθήκη που περιέχεται στο πακέτο με μία κατασκευή για κάθε υποστηριζόμενη πλατφόρμα. Και τα δύο πακέτα παρέχουν τα ίδια namespaces και κλάσεις του Aspose.Slides, έτσι η εναλλαγή μεταξύ τους αλλάζει μόνο την αναφορά στο πακέτο, όχι τον κώδικά σας.

|  | Aspose.Slides.NET | Aspose.Slides.NET6.CrossPlatform |
|---|---|---|
| Γραφικά | System.Drawing.Common | Εγγενής μηχανή γραφικών που περιλαμβάνεται στο πακέτο |
| Πλαίσια-στόχοι | `net462`, `net6.0`, `netstandard2.0` | `net6.0` |
| Απαιτήσεις Linux | `libgdiplus` και ο διακόπτης `System.Drawing.EnableUnixSupport` | `fontconfig` |
| Alpine Linux | Υποστηρίζεται | Δεν υποστηρίζεται |

## **Υποστηριζόμενες Πλατφόρμες**

Το Aspose.Slides.NET6.CrossPlatform λειτουργεί με .NET 6 και νεότερες εκδόσεις στις ακόλουθες πλατφόρμες:

- **Windows**: x86 και x64. Η εγγενής βιβλιοθήκη χρησιμοποιεί το runtime του Microsoft Visual C++; δείτε [System Requirements](/slides/el/net/system-requirements/).
- **Linux**: x64 με glibc 2.23 ή νεότερη, και ARM64 με glibc 2.39 ή νεότερη.
- **macOS**: x64 (Intel) και ARM64 (Apple silicon).

Δεν εκτελείται σε Windows σε ARM64, σε Alpine Linux ή άλλες διανομές που χτίζονται πάνω σε musl αντί για glibc, ή σε διανομές με παλαιότερο glibc, όπως το CentOS 7. Χρησιμοποιήστε το Aspose.Slides.NET σε αυτά τα συστήματα.

## **Εγκατάσταση σε Linux**

Σε Linux, το πακέτο απαιτεί τη βιβλιοθήκη `fontconfig`, αλλά όχι το `libgdiplus`. Σε Debian και Ubuntu, εγκαταστήστε το `fontconfig` και έπειτα προσθέστε το πακέτο στο έργο σας:

```bash
sudo apt-get update && sudo apt-get install -y libfontconfig1
dotnet add package Aspose.Slides.NET6.CrossPlatform
```

Σε Debian και Ubuntu, το `libfontconfig1` εγκαθιστά επίσης τις γραμματοσειρές DejaVu, έτσι το κείμενο εμφανίζεται χωρίς πρόσθετα πακέτα γραμματοσειρών. Χωρίς το `fontconfig`, η δημιουργία μιας [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) αποτυγχάνει με `TypeInitializationException` του οποίου το εσωτερικό `DllNotFoundException` αναφέρει ότι το `libfontconfig.so.1` δεν μπορεί να ανοιχθεί. [System Requirements](/slides/el/net/system-requirements/) περιλαμβάνει ένα σύντομο πρόγραμμα που ελέγχει τη ρύθμιση.

## **Υποδομές Cloud και Container**

Επειδή δεν χρειάζεται το `libgdiplus`, το Aspose.Slides.NET6.CrossPlatform είναι το πακέτο που πρέπει να χρησιμοποιήσετε σε Linux hosts όπου δεν μπορείτε να εγκαταστήσετε το `libgdiplus`. Χρειάζεται ακόμα `fontconfig` και γραμματοσειρές, που ενδέχεται να λείπουν από ελάχιστες εικόνες βάσης. Η βασική εικόνα AWS Lambda για .NET 8, για παράδειγμα, δεν περιέχει κανένα από αυτά. Σε μια εικόνα container που χτίζεται πάνω σε αυτήν, εκτελέστε `dnf install -y fontconfig`, το οποίο εγκαθιστά επίσης τις γραμματοσειρές Noto Sans.

Για οδηγίες σχετικά με συγκεκριμένες πλατφόρμες cloud, δείτε [Aspose.Slides on Cloud Platforms](/slides/el/net/slides-on-cloud-platforms/).

## **Χρήση System.Drawing.Common στο ίδιο έργο (CS0433)**

Ένα έργο που χρησιμοποιεί το Aspose.Slides.NET6.CrossPlatform μπορεί επίσης να αναφέρει το System.Drawing.Common, άμεσα ή μέσω άλλου πακέτου. Η τρέχουσα έκδοση του Aspose.Slides δεν εκθέτει δημόσιους τύπους σε namespaces του `System`, έτσι οι δύο βιβλιοθήκες δεν συγκρούονται, και μπορείτε να εισάγετε τα namespaces `Aspose.Slides` και `System.Drawing` στο ίδιο αρχείο.

Αν ο μεταγλωττιστής αναφέρει σφάλμα CS0433 επειδή ένας τύπος όπως `Image` ή `Graphics` υπάρχει και στα Aspose.Slides και στο System.Drawing.Common, το έργο σας χρησιμοποιεί παλιότερη έκδοση του Aspose.Slides. Ενημερώστε το πακέτο στην πιο πρόσφατη έκδοση. Το Aspose.Slides επιστρέφει εικόνες ως αντικείμενα [IImage](https://reference.aspose.com/slides/el/net/aspose.slides/iimage/), που περιγράφονται στην [Modern API](/slides/el/net/modern-api/).

## **Συχνές ερωτήσεις**

**Χρειάζεται να αλλάξω τον κώδικά μου όταν μεταβώ από Aspose.Slides.NET σε Aspose.Slides.NET6.CrossPlatform;**

Όχι. Και τα δύο πακέτα παρέχουν τα ίδια namespaces και κλάσεις του Aspose.Slides, έτσι αντικαθιστάτε μόνο την αναφορά στο πακέτο. Το Aspose.Slides.NET6.CrossPlatform δεν χρειάζεται το διακόπτη `System.Drawing.EnableUnixSupport`. Προσθέστε μόνο ένα από τα δύο πακέτα σε ένα έργο.

**Μπορώ να χρησιμοποιήσω το Aspose.Slides.NET6.CrossPlatform σε έργο .NET Framework;**

Όχι. Το πακέτο στοχεύει μόνο .NET 6 και νεότερες εκδόσεις. Για .NET Framework 4.6.2 και μεταγενέστερες, χρησιμοποιήστε το Aspose.Slides.NET.