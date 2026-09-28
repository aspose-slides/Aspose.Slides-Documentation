---
title: Απαιτήσεις επιπέδου εμπιστοσύνης
type: docs
weight: 190
url: /el/net/declaration/
keywords:
- επίπεδο εμπιστοσύνης
- Άδεια πλήρους εμπιστοσύνης
- μερική εμπιστοσύνη
- Μεσαία Εμπιστοσύνη
- ασφάλεια πρόσβασης κώδικα
- ASP.NET
- .NET Framework
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Ποιο επίπεδο εμπιστοσύνης της ασφάλειας πρόσβασης κώδικα χρειάζεται το Aspose.Slides for .NET: πλήρης εμπιστοσύνη στο .NET Framework και καμία ρύθμιση εμπιστοσύνης σε .NET 6 και μεταγενέστερα."
---
## **Επισκόπηση**

Τα επίπεδα εμπιστοσύνης του Code access security (CAS) υπάρχουν μόνο στο .NET Framework. Αυτό το άρθρο εξηγεί τι σημαίνουν για το Aspose.Slides for .NET: η βιβλιοθήκη απαιτεί πλήρη εμπιστοσύνη στο .NET Framework, ενώ σε .NET 6 και μεταγενέστερα δεν υπάρχει επίπεδο εμπιστοσύνης προς ρύθμιση.

## **.NET Framework**

Το Aspose.Slides απαιτεί πλήρη εμπιστοσύνη στο .NET Framework. Δεν εκτελείται υπό μερική εμπιστοσύνη, όπως μια εφαρμογή ASP.NET διαμορφωμένη για Μεσαία Εμπιστοσύνη (`<trust level="Medium" />`): η δημιουργία ενός αντικειμένου [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) αποτυγχάνει με `SecurityException`.

Η Microsoft δεν θεωρεί πλέον τη μερική εμπιστοσύνη του ASP.NET ως τρόπο απομόνωσης εφαρμογών μεταξύ τους και προτείνει την εκτέλεση των εφαρμογών σε ξεχωριστές δεξαμενές εφαρμογών. Δείτε το άρθρο [ASP.NET Partial Trust does not guarantee application isolation](https://support.microsoft.com/en-us/servicing/dotnetframework/troubleshooting/asp-net-partial-trust-does-not-guarantee-application-isolation).

## **.NET 6 and Later**

Το Code access security δεν είναι διαθέσιμο σε .NET 6 και μεταγενέστερα, έτσι δεν υπάρχει επίπεδο εμπιστοσύνης προς χορήγηση. Το Aspose.Slides εκτελείται με τα δικαιώματα του λογαριασμού που εκτελεί την εφαρμογή σας. Για να περιορίσετε τι μπορεί να προσπελάσει μια εφαρμογή, η Microsoft προτείνει όρια λειτουργικού συστήματος, όπως λογαριασμούς χρηστών, containers ή εικονικές μηχανές. Δείτε το [Code access security (CAS)](https://learn.microsoft.com/en-us/dotnet/core/porting/net-framework-tech-unavailable#code-access-security-cas).

## **FAQ**

**Μπορώ να χρησιμοποιήσω το Aspose.Slides με πάροχο φιλοξενίας που εκτελεί εφαρμογές ASP.NET σε Μεσαία Εμπιστοσύνη;**

Όχι σε Μεσαία Εμπιστοσύνη. Στο .NET Framework, η εφαρμογή που χρησιμοποιεί το Aspose.Slides πρέπει να εκτελείται με πλήρη εμπιστοσύνη.