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
description: "Ανακαλύψτε τις απαιτήσεις συστήματος του Aspose.Slides για .NET. Διασφαλίστε αδιάλειπτη υποστήριξη PowerPoint και OpenDocument στα Windows, Linux και macOS."
---
## **Εισαγωγή**

Aspose.Slides for .NET δεν απαιτεί την εγκατάσταση του Microsoft PowerPoint, επειδή το Aspose.Slides είναι μια ανεξάρτητη μηχανή δημιουργίας, μετατροπής, διάταξης σελίδων και απόδοσης εγγράφων Microsoft PowerPoint.

## **Υποστηριζόμενα Λειτουργικά Συστήματα**

Aspose.Slides for .NET υποστηρίζει οποιοδήποτε 32‑bit ή 64‑bit λειτουργικό σύστημα όπου είναι εγκατεστημένο το .NET ή το Mono framework, συμπεριλαμβανομένων (αλλά όχι περιοριστικά) των παρακάτω:

### **Windows**

- Microsoft Windows 2000 Server (x64, x86)
- Microsoft Windows 2003 Server (x64, x86)
- Microsoft Windows 2022 Server
- Microsoft Windows Vista (x64, x86)
- Microsoft Windows XP (x64, x86)
- Microsoft Windows 7 (x64, x86)
- Microsoft Windows 8, 8.1 (x64, x86)
- Microsoft Windows 10 (x64, x86)
- Microsoft Windows 11 (x64, x86)
- Microsoft Azure

### **Linux**

- Linux (Ubuntu, OpenSUSE, CentOS, Alpine και άλλα)

### **Mac**

- Mac OS X

## **Υποστηριζόμενα Frameworks**

Aspose.Slides for .NET υποστηρίζει .NET και Mono frameworks:

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

- MONO Support in MAC and Linux platforms

## **Περιβάλλοντα Ανάπτυξης**

Aspose.Slides for .NET μπορεί να χρησιμοποιηθεί για ανάπτυξη εφαρμογών σε οποιοδήποτε περιβάλλον ανάπτυξης που στοχεύει την πλατφόρμα .NET, αλλά τα παρακάτω περιβάλλοντα υποστηρίζονται ρητά:

- Microsoft Visual Studio 2005
- Microsoft Visual Studio 2008
- Microsoft Visual Studio 2010
- Microsoft Visual Studio 2012
- Microsoft Visual Studio 2013
- Microsoft Visual Studio 2015
- Microsoft Visual Studio 2017
- Microsoft Visual Studio 2019
- Microsoft Visual Studio 2022

## **Κύρια Build του Aspose.Slides**

Προσωρινά, υπάρχουν δύο κύρια build του Aspose.Slides — Aspose.Slides.NET και Aspose.Slides.NET6.CrossPlatform.

### **[Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**

Αυτή είναι η κύρια έκδοση του προϊόντος. Χρησιμοποιεί τη στάνταρ .NET μηχανή γραφικών.
- Σε μη‑Windows πλατφόρμες, ίσως χρειαστεί να εγκαταστήσετε τη βιβλιοθήκη `libgdiplus` και τις εξαρτήσεις της.
- Πριν από την έκδοση Aspose.Slides 25.3, για μη‑Windows πλατφόρμες, ήταν απαραίτητο να χρησιμοποιηθεί το .NET Standard 2.0 DLL από το πακέτο ZIP του Aspose.Slides.
- Από την έκδοση Aspose.Slides 25.3, το πακέτο NuGet μπορεί να χρησιμοποιηθεί άμεσα ακόμη και σε μη‑Windows συστήματα.
- Κατά την εκτέλεση σε μη‑Windows συστήματα, η εφαρμογή σας πρέπει να περιλαμβάνει την ακόλουθη γραμμή κατά την εκκίνηση:
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```
- **Από την έκδοση 25.3, μπορείτε να χρησιμοποιήσετε αυτό το πακέτο σε πλατφόρμες που υποστηρίζουν .NET, όπως Linux aarch64 (ARM64).**

#### **Πρόσθετα Πακέτα για Linux Alpine**

Κατά την εκτέλεση του Aspose.Slides for .NET σε κοντέινερ Alpine Linux, η εγκατάσταση του `libgdiplus` μόνο ίσως να μην είναι επαρκής. Τα κοντέινερ Alpine συνήθως δεν περιλαμβάνουν γραμματοσειρές εξ ορισμού. Εάν δεν υπάρχουν γραμματοσειρές, οι λειτουργίες απόδοσης ή μετατροπής μπορεί να αποτύχουν με σφάλμα όπως το ακόλουθο:

```text
System.ArgumentException: Font '?' cannot be found
```
Για να χρησιμοποιήσετε το Aspose.Slides στο Alpine, εγκαταστήστε το `libgdiplus` μαζί με τουλάχιστον ένα πακέτο γραμματοσειρών.

**Επιλογή 1: Γραμματοσειρές DejaVu**

Η συνιστώμενη επιλογή είναι η εγκατάσταση του πακέτου ttf-dejavu:

```
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

Το πακέτο `ttf-dejavu` εγκαθιστά αυτόματα τις απαιτούμενες εξαρτήσεις γραμματοσειρών, όπως `fontconfig`, `encodings`, `mkfontscale` και `mkfontdir`. Δεν απαιτούνται πρόσθετα πακέτα γραμματοσειρών για τις περισσότερες χρήσεις.

**Επιλογή 2: Microsoft Core Fonts**

Αν οι παρουσιάσεις σας χρησιμοποιούν γραμματοσειρές Microsoft, όπως Arial, Times New Roman, Courier New ή Verdana, εγκαταστήστε τα Microsoft Core Fonts:

```
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

Χρησιμοποιήστε αυτή την επιλογή μόνο όταν οι επεξεργαζόμενες παρουσιάσεις απαιτούν γραμματοσειρές Microsoft. Για τις περισσότερες περιπτώσεις, η εγκατάσταση του `ttf-dejavu` είναι πιο απλή και αξιόπιστη.

**Πρόσθετες απαιτήσεις για παγκοσμιοποίηση**

Για τη σωστή υποστήριξη παγκοσμιοποίησης στο Alpine, εγκαταστήστε το πακέτο `icu-libs` και απενεργοποιήστε τη λειτουργία invariant:

```dockerfile
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk --no-cache add icu-libs
```

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**

Αυτή είναι η έκδοση του Aspose.Slides που χρησιμοποιεί μια προσαρμοσμένη μηχανή γραφικών πολλαπλών πλατφορμών, η οποία αναπτύχθηκε από την ομάδα του Aspose.Slides.  
Σε μη‑Windows πλατφόρμες, η βιβλιοθήκη `fontconfig` μπορεί να απαιτείται.

**Υποστηριζόμενες Πλατφόρμες**
- *Windows*: x86, x86_64  
- *Linux*: x86_64, ARM64 (aarch64)
- *macOS*: x86_64, ARM64 (aarch64)

**Μη Υποστηριζόμενες Πλατφόρμες**
- *Windows 11 ARM* (ARM64) — *Δεν εξετάζεται επί του παρόντος*

{{% alert title="Notes" color="primary" %}}  
Για Linux x64, απαιτείται GLIBC 2.23+· για Linux ARM64, απαιτείται GLIBC 2.39+. Συστήματα όπως CentOS 7 (GLIBC 2.14) δεν υποστηρίζονται. Εάν χρειάζεται να εκτελέσετε το Aspose.Slides σε CentOS 7 ή σε άλλα ασύμβατα συστήματα (π.χ., Alpine), χρησιμοποιήστε το τυπικό πακέτο: [Aspose.Slides for .NET](https://nuget.org/packages/Aspose.Slides.NET).  
{{% /alert %}} 

## **Συχνές Ερωτήσεις**

**Χρειάζεται να είναι εγκατεστημένο το Microsoft PowerPoint για μετατροπές και απόδοση;**

Όχι, δεν απαιτείται το PowerPoint· το Aspose.Slides είναι μια αυτόνομη μηχανή για [δημιουργία](/slides/el/net/create-presentation/), τροποποίηση, [μετατροπή](/slides/el/net/convert-presentation/) και [απόδοση](/slides/el/net/convert-powerpoint-to-png/) παρουσιάσεων.

**Ποιες γραμματοσειρές χρειάζονται για σωστή απόδοση;**

Οι γραμματοσειρές που χρησιμοποιούνται στην παρουσίαση ή κατάλληλες εναλλακτικές πρέπει να είναι διαθέσιμες στο λειτουργικό σύστημα. Σε Linux και macOS, εγκαταστήστε κοινά πακέτα γραμματοσειρών για να εξασφαλίσετε συνεπή απόδοση.

Για κοντέινερ Alpine Linux, εγκαταστήστε τουλάχιστον ένα πακέτο γραμματοσειρών εκτός του `libgdiplus`. Η ελάχιστη προτεινόμενη ρύθμιση είναι `libgdiplus` με `ttf-dejavu`. Εάν απαιτούνται γραμματοσειρές Microsoft όπως Arial, Times New Roman, Courier New ή Verdana, χρησιμοποιήστε `msttcorefonts-installer` μαζί με `fontconfig`.

**Γιατί μια προσαρμοσμένη γραμματοσειρά εμφανίζεται ως εφεδρική ή λείπει κείμενο σε Linux;**

Εάν το αρχείο γραμματοσειράς έχει ασυνεπείς ή κατεστραμμένες καταχωρήσεις στον πίνακα ονομάτων, η στοίβα αντιστοίχισης γραμματοσειρών του Linux (FreeType/fontconfig) μπορεί να επιλέξει μη έγκυρη εγγραφή, με αποτέλεσμα η γραμματοσειρά να μην αναγνωρίζεται. Η χρήση μιας έκδοσης γραμματοσειράς με διορθωμένες καταχωρήσεις ονομάτων ή η εγκατάσταση ενός συνεπούς αντικατάστατου λύνει το πρόβλημα.