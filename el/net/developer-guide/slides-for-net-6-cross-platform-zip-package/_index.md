---
title: Aspose.Slides για .NET 6 Διαπλατφόρμα (Πακέτο ZIP)
type: docs
weight: 237
url: /el/net/slides-for-net-6-cross-platform-zip-package/
keywords:
- διαπλατφόρμα
- .NET 6
- GLIBC
- csproj
- διαδρομή προορισμού
- εξαρτημένη βιβλιοθήκη
- Aspose.Slides.dll
- System.Drawing.Common
- σύγκρουση ονομάτων
- εξωτερικό ψευδώνυμο
- CS0433
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Χρησιμοποιήστε το Aspose.Slides για .NET 6 για τη δημιουργία διαπλατφόρμας εφαρμογών C# σε Windows, Linux και macOS που δημιουργούν, επεξεργάζονται και μετατρέπουν αρχεία PowerPoint PPT, PPTX και ODP."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να χρησιμοποιήσετε το Aspose.Slides για .NET 6 Cross-Platform από ένα πακέτο ZIP. Περιγράφει πώς να κατεβάσετε το πακέτο, να αποσυμπιέσετε τα αρχεία από τον φάκελο `net6.0/crossplatform`, να προσθέσετε μια αναφορά στο `Aspose.Slides.dll` και να διαμορφώσετε το αρχείο του έργου ώστε οι απαιτούμενες εξαρτημένες βιβλιοθήκες να αντιγραφούν στον φάκελο εξόδου της εφαρμογής.

Το άρθρο περιγράφει επίσης το περιεχόμενο του πακέτου cross‑platform, συμπεριλαμβανομένου του κύριου assembly Aspose.Slides .NET και των βιβλιοθηκών υποσυστήματος γραφικών ειδικών για πλατφόρμα για Windows, Linux και macOS.

{{% alert title="Note" color="primary" %}}
Το Aspose.Slides για .NET 6 Cross‑Platform είναι επίσης διαθέσιμο από [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform).
{{% /alert %}}

## **Χρήση του Cross‑Platform Aspose.Slides από πακέτο ZIP**

1. Κατεβάστε το πακέτο ZIP της πιο πρόσφατης έκδοσης του Aspose.Slides από τη [σελίδα κυκλοφορίας](https://releases.aspose.com/slides/el/net/).

2. Αποσυμπιέστε τα αρχεία από *Aspose.Slides.zip\Aspose.Slides\net6.0\crossplatform* και τοποθετήστε τα στον φάκελο που θα χρησιμοποιηθεί για εξαρτήσεις στο έργο σας.

3. Προσθέστε μια αναφορά στο Aspose.Slides.dll.

   ![add-project-reference-visual-studio](add-project-reference-visual-studio.png)

   Στο παράδειγμά μας (παρακάτω), οι βιβλιοθήκες βρίσκονται στο φάκελο του έργου σύμφωνα με αυτή τη διαδρομή: *ConsoleApp\libs\Aspose.Slides\net6.0\crossplatform\...*

   ![browse-console-app](browse-console-app.jpg)

4. Τοποθετήστε τα υπόλοιπα αρχεία (από τα οποία εξαρτάται το Aspose.Slides) στον φάκελο εξόδου προσθέτοντας οδηγίες στο αρχείο έργου csproj με αυτόν τον τρόπο:

```xml
<ItemGroup>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\aspose.slides.drawing.capi_vc14x64.dll">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>aspose.slides.drawing.capi_vc14x64.dll</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\aspose.slides.drawing.capi_vc14x86.dll">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>aspose.slides.drawing.capi_vc14x86.dll</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\Aspose.Slides.xml">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>Aspose.Slides.xml</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_appleclang_x86_64.dylib">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>libaspose.slides.drawing.capi_appleclang_x86_64.dylib</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_appleclang_arm64.dylib">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>libaspose.slides.drawing.capi_appleclang_arm64.dylib</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so</TargetPath>
   </None>

</ItemGroup>
```

5. Δώστε προσοχή στο `TargetPath`.

   Από προεπιλογή, το `<CopyToOutputDirectory>` αντιγράφει τα αρχεία διατηρώντας τη σχετική τους διαδρομή, αλλά χρειάζεται οι εξαρτημένες βιβλιοθήκες να μεταφερθούν στον ίδιο φάκελο όπου δημιουργείται η έξοδος (θέση Aspose.Slides.dll).

## **Σημειώσεις**

### **Ιδιοκτησιακό Σύστημα Γραφικών**

| Aspose.Slides.dll                                          | Κύριο .NET Assembly Υπεύθυνο για Όλη τη Λογική του Aspose.Slides |
| ---------------------------------------------------------- | ----------------------------------------------------------------- |
| aspose.slides.drawing.capi_vc14x64.dll                     | Εξάρτηση: υλοποίηση συστήματος γραφικών για Win x64                |
| aspose.slides.drawing.capi_vc14x86.dll                     | Εξάρτηση: υλοποίηση συστήματος γραφικών για Win x64                |
| libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so | Εξάρτηση: υλοποίηση συστήματος γραφικών για Linux (x86/x64)      |
| libaspose.slides.drawing.capi_appleclang_x86_64.dylib      | Εξάρτηση: υλοποίηση συστήματος γραφικών για macOS AMD64 (x86-64/x64) |
| libaspose.slides.drawing.capi_appleclang_arm64.dylib       | Εξάρτηση: υλοποίηση συστήματος γραφικών για macOS ARM64 (AArch64) |

Το Aspose.Slides.dll χρησιμοποιεί τη βιβλιοθήκη που απαιτεί το σύστημα στο οποίο εκτελείται. Οι βιβλιοθήκες συνήθως βρίσκονται στην ίδια θέση με το Aspose.Slides.dll σε οποιοδήποτε σύστημα αρχείων.

### **Δομή Πακέτου ZIP**

Το πακέτο ZIP περιέχει την ακόλουθη δομή φακέλων:

  Aspose.Slides

  ├─── net6.0

  │  ├─── crossplatform

  │  └─── default

  ├─── net20

  ├─── net462

  └─── netstandard2.0

* Κάθε φάκελος περιέχει assemblies για την αντίστοιχη έκδοση .NET. Υπάρχουν δύο εκδόσεις για net6.0: default και crossplatform. Η δεύτερη περιέχει το cross‑platform Aspose.Slides.dll και όλες τις εξαρτήσεις του. Τα αποσυμπιεσμένα περιεχόμενα αυτού του φακέλου μπορούν να χρησιμοποιηθούν ως προσθήκη εξαρτήσεων σε ένα έργο για ανάπτυξη cross‑platform και άλλες περιπτώσεις χρήσης του Aspose.Slides.

## **Δείτε επίσης**

- [Απαιτήσεις Συστήματος](/slides/el/net/system-requirements/)