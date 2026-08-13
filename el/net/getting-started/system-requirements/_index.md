---
title: Απαιτήσεις Συστήματος
type: docs
weight: 60
url: /el/net/system-requirements/
keywords:
- απαιτήσεις συστήματος
- λειτουργικό σύστημα
- εγκατάσταση
- εξαρτήσεις
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Ανακαλύψτε τις απαιτήσεις συστήματος του Aspose.Slides για .NET. Εξασφαλίστε αβίακη υποστήριξη PowerPoint και OpenDocument στα Windows, Linux και macOS."
---
## **Εισαγωγή**

Το Aspose.Slides for .NET δεν απαιτεί την εγκατάσταση του Microsoft PowerPoint, καθώς το Aspose.Slides είναι μια ανεξάρτητη μηχανή δημιουργίας, μετατροπής, διάταξης σελίδων και απόδοσης εγγράφων Microsoft PowerPoint.

## **Υποστηριζόμενα Συστήματα Λειτουργίας**

Το Aspose.Slides for .NET υποστηρίζει οποιοδήποτε 32‑bit ή 64‑bit σύστημα όπου είναι εγκατεστημένο το .NET ή το Mono framework, συμπεριλαμβανομένων (αλλά όχι περιοριστικά) των:

### **Windows**

- Microsoft Windows 2000 Server ( x64, x86)
- Microsoft Windows 2003 Server ( x64, x86)
- Microsoft Windows 2022 Server
- Microsoft Windows Vista ( x64, x86)
- Microsoft Windows XP ( x64, x86)
- Microsoft Windows 7 ( x64, x86)
- Microsoft Windows 8, 8.1 ( x64, x86)
- Microsoft Windows 10 ( x64, x86)
- Microsoft Windows 11 ( x64, x86)
- Microsoft Azure

### **Linux**

- Linux (Ubuntu, OpenSUSE, CentOS, Alpine και άλλα)

### **Mac**

- Mac OS X

## **Υποστηριζόμενα Πλαίσια**

Το Aspose.Slides for .NET υποστηρίζει τα .NET και Mono frameworks:

### **.NET Frameworks**

- .NET Framework 2.0
- .NET Framework 3.5
- .NET Framework 4.0
- .NET Framework 4.0_ClientProfile
- .NET Framework 4.5.0
- .NET Framework 4.5.1
- .NET Framework 4.5.2
- .NET Framework 4.6.0
- .NET Framework 4.6.2
- .NET Framework 4.5.0
- .NET Framework 4.5.1
- .NET Framework 4.6.0
- .NET Framework 4.6.2
- .NET Framework 4.7
- .NET Framework 4.7.2
- .NET 5
- .NET 6
- .NET 7
- .NET 8
- .NET 9
- .NET Core
- COM Interop support (COM, C++, VBScript)

### **Mono Framework**

- Υποστήριξη MONO σε πλατφόρμες MAC και Linux

## **Περιβάλλοντα Ανάπτυξης**

Το Aspose.Slides for .NET μπορεί να χρησιμοποιηθεί για ανάπτυξη εφαρμογών σε οποιοδήποτε περιβάλλον στοχεύει την .NET πλατφόρμα, αλλά τα παρακάτω περιβάλλοντα υποστηρίζονται ρητά:

- Microsoft Visual Studio 2005
- Microsoft Visual Studio 2008
- Microsoft Visual Studio 2010
- Microsoft Visual Studio 2012
- Microsoft Visual Studio 2013
- Microsoft Visual Studio 2015
- Microsoft Visual Studio 2017
- Microsoft Visual Studio 2019
- Microsoft Visual Studio 2022

## **Κύριες Εκδόσεις του Aspose.Slides**

Προς το παρόν υπάρχουν δύο κύριες εκδόσεις του Aspose.Slides — Aspose.Slides.NET και Aspose.Slides.NET6.CrossPlatform.

### **[Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**

Αυτή είναι η κύρια έκδοση του προϊόντος. Χρησιμοποιεί τη standard .NET μηχανή γραφικών.
- Σε μη‑Windows πλατφόρμες, ίσως χρειαστεί να εγκαταστήσετε τη βιβλιοθήκη `libgdiplus` και τις εξαρτήσεις της.
- Πριν από την έκδοση Aspose.Slides 25.3, για μη‑Windows πλατφόρμες, ήταν απαραίτητο να χρησιμοποιηθεί το .NET Standard 2.0 DLL από το πακέτο ZIP του Aspose.Slides.
- Από την έκδοση Aspose.Slides 25.3, το πακέτο NuGet μπορεί να χρησιμοποιηθεί άμεσα ακόμη και σε μη‑Windows συστήματα.
- Όταν εκτελείται σε μη‑Windows συστήματα, η εφαρμογή σας πρέπει να περιλαμβάνει τη ακόλουθη γραμμή κατά την εκκίνηση:
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```
- **Από την έκδοση 25.3, μπορείτε να χρησιμοποιήσετε αυτό το πακέτο σε πλατφόρμες που υποστηρίζουν .NET, όπως Linux aarch64 (ARM64).**

#### **Επιπλέον Πακέτα για Linux Alpine**

Κατά την εκτέλεση του Aspose.Slides for .NET σε κοντέινερ Alpine Linux, η εγκατάσταση μόνο του `libgdiplus` μπορεί να μην είναι επαρκής. Τα κοντέινερ Alpine συνήθως δεν περιλαμβάνουν γραμματοσειρές από προεπιλογή. Εάν δεν υπάρχουν γραμματοσειρές, οι λειτουργίες απόδοσης ή μετατροπής μπορεί να αποτύχουν με σφάλμα παρόμοιο με:

```text
System.ArgumentException: Font '?' cannot be found
```
Για χρήση του Aspose.Slides σε Alpine, εγκαταστήστε το `libgdiplus` μαζί τουλάχιστον με ένα πακέτο γραμματοσειρών.

**Option 1: DejaVu Fonts**

Η συνιστώμενη επιλογή είναι η εγκατάσταση του πακέτου ttf-dejavu:

```
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

Το πακέτο `ttf-dejavu` εγκαθιστά αυτόματα τις απαιτούμενες εξαρτήσεις γραμματοσειρών, όπως `fontconfig`, `encodings`, `mkfontscale` και `mkfontdir`. Δεν απαιτούνται πρόσθετα πακέτα γραμματοσειρών για τις περισσότερες περιπτώσεις.

**Option 2: Microsoft Core Fonts**

Εάν οι παρουσιάσεις σας χρησιμοποιούν γραμματοσειρές της Microsoft, όπως Arial, Times New Roman, Courier New ή Verdana, εγκαταστήστε τα Microsoft Core Fonts αντί αυτού:

```
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

Χρησιμοποιήστε αυτήν την επιλογή μόνο όταν οι επεξεργαζόμενες παρουσιάσεις απαιτούν γραμματοσειρές Microsoft. Για τις περισσότερες περιπτώσεις, η εγκατάσταση του `ttf-dejavu` είναι πιο απλή και αξιόπιστη.

**Additional requirements for globalization**

Για να ενεργοποιήσετε σωστή υποστήριξη παγκοσμιοποίησης σε Alpine, εγκαταστήστε το πακέτο `icu-libs` και απενεργοποιήστε τη λειτουργία invariant:

```dockerfile
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk --no-cache add icu-libs
```

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**

Αυτή είναι η έκδοση του Aspose.Slides που χρησιμοποιεί μια προσαρμοσμένη cross‑platform μηχανή γραφικών, η οποία αναπτύχθηκε από την ομάδα του Aspose.Slides.  
Σε μη‑Windows πλατφόρμες, η βιβλιοθήκη `fontconfig` μπορεί να είναι απαραίτητη.

**Supported Platforms**
- *Windows*: x86, x86_64  
- *Linux*: x86_64, ARM64 (aarch64)
- *macOS*: x86_64, ARM64 (aarch64)

**Unsupported Platforms**
- *Windows 11 ARM* (ARM64) — *Δεν εξετάζεται επί του παρόντος*

{{%  alert  title="Notes"  color="info"  %}}  
Για Linux x64, απαιτείται GLIBC 2.23+· Για Linux ARM64, απαιτείται GLIBC 2.39+. Συστήματα όπως CentOS 7 (GLIBC 2.14) δεν υποστηρίζονται. Εάν χρειάζεται να τρέξετε το Aspose.Slides σε CentOS 7 ή άλλα μη συμβατά συστήματα (π.χ., Alpine), χρησιμοποιήστε το τυπικό πακέτο: [Aspose.Slides for .NET](https://nuget.org/packages/Aspose.Slides.NET).  
{{% /alert %}} 

## **FAQ**

### Πρέπει να είναι εγκατεστημένο το Microsoft PowerPoint για μετατροπές και απόδοση;

Όχι, το PowerPoint δεν απαιτείται· το Aspose.Slides είναι μια αυτόνομη μηχανή για [creating](/slides/el/net/create-presentation/), τροποποίηση, [converting](/slides/el/net/convert-presentation/) και [rendering](/slides/el/net/convert-powerpoint-to-png/) παρουσιάσεων.

### Ποιες γραμματοσειρές απαιτούνται για σωστή απόδοση;

Οι γραμματοσειρές που χρησιμοποιούνται στην παρουσίαση, ή κατάλληλες εναλλακτικές, πρέπει να είναι διαθέσιμες στο λειτουργικό σύστημα. Σε Linux και macOS, εγκαταστήστε κοινά πακέτα γραμματοσειρών για να εξασφαλίσετε συνεπή απόδοση.

Για κοντέινερ Alpine Linux, εγκαταστήστε τουλάχιστον ένα πακέτο γραμματοσειρών εκτός του `libgdiplus`. Η ελάχιστη συνιστώμενη ρύθμιση είναι `libgdiplus` με `ttf-dejavu`. Εάν απαιτούνται γραμματοσειρές Microsoft όπως Arial, Times New Roman, Courier New ή Verdana, χρησιμοποιήστε το `msttcorefonts-installer` μαζί με το `fontconfig`.

### Γιατί μια προσαρμοσμένη γραμματοσειρά εμφανίζεται ως fallback ή κείμενο που λείπει σε Linux;

Εάν το αρχείο γραμματοσειράς έχει ασυνεπείς ή κατεστραμμένες καταχωρήσεις στον πίνακα ονομάτων, η στοίβα αντιστοίχισης γραμματοσειρών του Linux (FreeType/fontconfig) μπορεί να επιλέξει μη έγκυρη εγγραφή, με αποτέλεσμα η γραμματοσειρά να μην επιλυθεί. Η χρήση μιας έκδοσης γραμματοσειράς με διορθωμένες εγγραφές ονομάτων ή η εγκατάσταση μιας συνεπής εναλλακτικής λύνει το πρόβλημα.