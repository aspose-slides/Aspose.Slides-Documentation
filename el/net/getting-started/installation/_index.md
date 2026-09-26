---
title: Εγκατάσταση
type: docs
weight: 70
url: /el/net/installation/
keywords:
- Εγκατάσταση Aspose.Slides
- Λήψη Aspose.Slides
- Χρήση Aspose.Slides
- Εγκατάσταση Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Εγκαταστήστε το Aspose.Slides για .NET από το NuGet στα Windows, Linux και macOS: επιλέξτε μεταξύ των δύο πακέτων, προσθέστε ένα με τη .NET CLI ή το Visual Studio και εγκαταστήστε τα προαπαιτούμενα του Linux."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσθέσετε το Aspose.Slides for .NET σε ένα έργο σε Windows, Linux και macOS. Το Aspose.Slides διανέμεται μέσω NuGet. Μπορείτε να το προσθέσετε με τη .NET CLI σε οποιοδήποτε λειτουργικό σύστημα ή με το NuGet Package Manager ή το Package Manager Console στο Visual Studio στα Windows. Το άρθρο επίσης εξηγεί ποιο από τα δύο πακέτα NuGet να επιλέξετε και τι χρειάζεται επιπλέον το Linux.

Πριν από την εγκατάσταση, ελέγξτε τα υποστηριζόμενα λειτουργικά συστήματα, τις υλοποιήσεις .NET και τις πρόσθετες εξαρτήσεις στο [Απαιτήσεις Συστήματος](/slides/el/net/system-requirements/).

## **Επιλογή Πακέτου**

Το Aspose.Slides for .NET δημοσιεύεται ως δύο πακέτα NuGet. Και τα δύο παρέχουν τα ίδια namespaces και κλάσεις του Aspose.Slides, έτσι ο κώδικάς σας δεν αλλάζει όταν αλλάζετε μεταξύ τους· μόνο η αναφορά του πακέτου και οι απαιτήσεις πλατφόρμας διαφέρουν.

| Πακέτο | Χρησιμοποιήστε το για | Επιπρόσθετες απαιτήσεις |
|---|---|---|
| [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) | Windows και εφαρμογές .NET Framework | Σε Linux και macOS: η βιβλιοθήκη `libgdiplus` και η επιλογή `System.Drawing.EnableUnixSupport` ενεργοποιημένη στην έναρξη της εφαρμογής |
| [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) | .NET 6 ή νεότερο σε Windows, Linux και macOS | Σε Linux: η βιβλιοθήκη `fontconfig`, εφόσον δεν είναι ήδη εγκατεστημένη |

Αν δεν είστε σίγουροι, χρησιμοποιήστε το Aspose.Slides.NET στα Windows και το Aspose.Slides.NET6.CrossPlatform σε Linux και macOS. Σε Alpine Linux και σε συστήματα Linux των οποίων η glibc είναι παλαιότερη από 2.23 (x64) ή 2.39 (ARM64), χρησιμοποιήστε το Aspose.Slides.NET. Το [Απαιτήσεις Συστήματος](/slides/el/net/system-requirements/) καταγράφει τις υποστηριζόμενες πλατφόρμες κάθε πακέτου.

## **Εγκατάσταση με τη .NET CLI**

Αυτά τα βήματα λειτουργούν σε Windows, Linux και macOS με .NET SDK 6 ή νεότερο. Δημιουργήστε μια εφαρμογή κονσόλας:

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

Στη συνέχεια προσθέστε το πακέτο για την πλατφόρμα σας. Προσθέστε μόνο ένα από τα δύο πακέτα σε ένα έργο.

- Σε Windows: `dotnet add package Aspose.Slides.NET`
- Σε Linux και macOS: `dotnet add package Aspose.Slides.NET6.CrossPlatform` (σε Linux, εγκαταστήστε πρώτα το προαπαιτούμενο· δείτε [Linux](#linux))

Για να ελέγξετε ότι το πακέτο λειτουργεί, αντικαταστήστε το περιεχόμενο του *Program.cs* με το πρώτο παράδειγμα στο [Δημιουργία Παρουσιάσεων](/slides/el/net/create-presentation/) και εκτελέστε `dotnet run`. Αποθηκεύει το *hello.pptx* στον φάκελο του έργου.

## **Windows**

### **Μέθοδος 1: Εγκατάσταση ή Ενημέρωση Aspose.Slides από το NuGet Package Manager**

1. Ανοίξτε το Microsoft Visual Studio.
2. Δημιουργήστε μια εφαρμογή κονσόλας ή ανοίξτε ένα υπάρχον έργο.
3. Στο **Solution Explorer**, κάντε δεξί κλικ στο έργο και επιλέξτε **Manage NuGet Packages** (ή πηγαίνετε στο **Project** > **Manage NuGet Packages**).
4. Στην ενότητα **Browse**, αναζητήστε το *Aspose.Slides*.
{{% image img="installation_1.png" alt="Aspose.Slides Installation from NuGet Package Manager - 1" %}}
5. Κάντε κλικ στο **Aspose.Slides.NET** και έπειτα στο **Install**.
   * Αν έχετε ήδη εγκαταστήσει το Aspose.Slides και θέλετε να το ενημερώσετε, κάντε κλικ στο **Update**.

Το πακέτο κατεβάζεται και γίνεται αναφορά στο έργο σας.

### **Μέθοδος 2: Εγκατάσταση ή Ενημέρωση Aspose.Slides μέσω του Package Manager Console**

Αυτή είναι η διαδικασία για να αναφέρετε το [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) πακέτο μέσω του Package Manager Console:

1. Ανοίξτε το Microsoft Visual Studio.
2. Δημιουργήστε μια εφαρμογή κονσόλας ή ανοίξτε ένα υπάρχον έργο.
3. Πηγαίνετε στο **Tools** > **NuGet Package Manager** > **Package Manager Console**.
![Opening the Package Manager Console](installation_2.png)
4. Εκτελέστε αυτή την εντολή: `Install-Package Aspose.Slides.NET`
![Running the Install-Package command](installation_3.png)
Η πιο πρόσφατη έκδοση εγκαθίσταται στο έργο σας.

Το μήνυμα **Installing Aspose.Slides.NET** εμφανίζεται κοντά στο κάτω μέρος του παραθύρου.
![Installation progress in the Package Manager Console](installation_4.png)

Όταν ολοκληρωθεί η λήψη, εμφανίζονται μηνύματα επιβεβαίωσης. Το πακέτο διανέμεται υπό το [Aspose EULA](https://about.aspose.com/legal/eula).
![Installation confirmation messages](installation_5.png)

Το Aspose.Slides έχει τώρα προστεθεί στο έργο σας και γίνεται αναφορά.
![Aspose.Slides referenced in the project](installation_6.png)

Για να ενημερώσετε το πακέτο, εκτελέστε `Update-Package Aspose.Slides.NET` στο Package Manager Console.

## **Linux**

Χρησιμοποιήστε τα παραπάνω βήματα .NET CLI. Επιλέξτε το πακέτο και εγκαταστήστε το προαπαιτούμενο με τον διαχειριστή πακέτων της διανομής σας. Σε Debian και Ubuntu:

- **Aspose.Slides.NET6.CrossPlatform**: εγκαταστήστε το `fontconfig`.

  ```bash
  sudo apt-get update && sudo apt-get install -y libfontconfig1
  dotnet add package Aspose.Slides.NET6.CrossPlatform
  ```

- **Aspose.Slides.NET**: εγκαταστήστε το `libgdiplus` και ενεργοποιήστε την υποστήριξη Unix για το System.Drawing πριν η εφαρμογή σας χρησιμοποιήσει το Aspose.Slides.

  ```bash
  sudo apt-get update && sudo apt-get install -y libgdiplus
  dotnet add package Aspose.Slides.NET
  ```

Προσθέστε αυτή τη δήλωση στην αρχή της εφαρμογής σας, πριν από οποιαδήποτε κλήση Aspose.Slides. Σε ένα *Program.cs* με δηλώσεις κορυφαίου επιπέδου, τοποθετήστε το μετά τις οδηγίες `using`:

```c#
  System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
  ```

Χρησιμοποιήστε αυτό το πακέτο σε Alpine Linux και σε συστήματα των οποίων η glibc είναι πολύ παλιά για το Aspose.Slides.NET6.CrossPlatform.

Οι γραμματοσειρές που χρησιμοποιούνται στις παρουσιάσεις σας, ή κατάλληλες εναλλακτικές, πρέπει να είναι εγκατεστημένες στο σύστημα για σωστή απόδοση του κειμένου. Το [Απαιτήσεις Συστήματος](/slides/el/net/system-requirements/) περιγράφει τα πακέτα που χρειάζεται το Aspose.Slides.NET σε Alpine Linux, συμπεριλαμβανομένων των γραμματοσειρών.

## **macOS**

Χρησιμοποιήστε τα παραπάνω βήματα .NET CLI με το πακέτο **Aspose.Slides.NET6.CrossPlatform**, το οποίο υποστηρίζει τόσο υπολογιστές Intel (x86_64) όσο και Apple silicon (ARM64) Macs:

```bash
dotnet add package Aspose.Slides.NET6.CrossPlatform
```

## **FAQ**

**Υπάρχει δωρεάν έκδοση ή περιορισμός δοκιμής;**

Ναι. Χωρίς άδεια, το Aspose.Slides λειτουργεί σε λειτουργία αξιολόγησης: προσθέτει υδατογράφημα αξιολόγησης σε κάθε διαφάνεια που αποθηκεύει και περικοπεί το κείμενο που διαβάζεται από τις παρουσιάσεις. Για να αφαιρέσετε αυτούς τους περιορισμούς, εφαρμόστε μια έγκυρη [άδεια](/slides/el/net/licensing/).