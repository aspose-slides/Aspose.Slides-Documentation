---
title: Απαιτήσεις Συστήματος
type: docs
weight: 15
url: /el/reportingservices/system-requirements/
keywords:
- απαιτήσεις συστήματος
- SQL Server Reporting Services
- SSRS
- Power BI Report Server
- .NET Framework 3.5
- Aspose.Slides for Reporting Services
description: "Ελέγξτε ποιους διακομιστές αναφορών, εκδόσεις και ποια έκδοση του .NET Framework χρειάζεται το Aspose.Slides for Reporting Services πριν το εγκαταστήσετε."
---
## **Επισκόπηση**

Το Aspose.Slides for Reporting Services εκτελείται μέσα στον διακομιστή αναφορών ως επέκταση απόδοσης. Αυτή η σελίδα παραθέτει τι χρειάζεται το μηχάνημα του διακομιστή αναφορών πριν το [εγκαταστήσετε](/slides/el/reportingservices/installing-aspose-slides-for-reporting-services/). Το Microsoft PowerPoint και το Microsoft Office δεν απαιτούνται.

## **Υποστηριζόμενοι διακομιστές αναφορών**

- Microsoft SQL Server 2005 Υπηρεσίες αναφορών
- Microsoft SQL Server 2008 και 2008 R2 Υπηρεσίες αναφορών
- Microsoft SQL Server 2012 Υπηρεσίες αναφορών
- Microsoft SQL Server 2014 Υπηρεσίες αναφορών
- Microsoft SQL Server 2016 Υπηρεσίες αναφορών
- Microsoft SQL Server 2017 Υπηρεσίες αναφορών
- Microsoft SQL Server 2019 Υπηρεσίες αναφορών
- Power BI Report Server, για σελιδοποιημένες (RDL) αναφορές

Υποστηρίζονται και οι 32-bit και οι 64-bit διακομιστές αναφορών. Το SQL Server 2005 χρησιμοποιεί τη δική του έκδοση της επέκτασης· όλες οι μεταγενέστερες εκδόσεις και το Power BI Report Server χρησιμοποιούν την ίδια έκδοση. Το [Εγκατάσταση χειροκίνητα](/slides/el/reportingservices/install-manually/) δείχνει ποιο αρχείο πρέπει να αντιγράψετε.

Εάν η έκδοση του διακομιστή αναφορών σας δεν βρίσκεται σε αυτή τη λίστα, ρωτήστε στο [δωρεάν φόρουμ υποστήριξης](https://forum.aspose.com/c/slides/el/11) πριν την εγκατάσταση.

## **Εκδόσεις διακομιστή αναφορών**

Για το SQL Server 2016 Reporting Services και μεταγενέστερα καθώς και για το Power BI Report Server, η Microsoft υποστηρίζει τις επεκτάσεις απόδοσης στις εκδόσεις Enterprise, Standard, Developer και Evaluation· οι εκδόσεις Web και Express δεν τις υποστηρίζουν. Δείτε το [Reporting Services features supported by editions](https://learn.microsoft.com/en-us/sql/reporting-services/reporting-services-features-supported-by-the-editions-of-sql-server). Ο εγκαταστάτης MSI παραλείπει τις εκδόσεις Express του SQL Server 2016 και παλαιότερες.

## **.NET Framework**

.NET Framework 3.5 πρέπει να εγκατασταθεί στο μηχάνημα του διακομιστή αναφορών. Τα assemblies της επέκτασης είναι δομημένα για το runtime του .NET Framework 2.0, και ο εγκαταστάτης MSI τερματίζει με μήνυμα εάν λείπει το .NET Framework 3.5. Σε Windows Server, προσθέστε τις **.NET Framework 3.5 Features** στον Οδηγό Προσθήκης Ρόλων και Χαρακτηριστικών· δείτε το [Install .NET Framework 3.5 on Windows](https://learn.microsoft.com/en-us/dotnet/framework/install/dotnet-35-windows).

## **Δικαιώματα**

Η εγκατάσταση της επέκτασης τροποποιεί αρχεία στον φάκελο του διακομιστή αναφορών, γι’ αυτό και οι δύο μέθοδοι εγκατάστασης απαιτούν δικαιώματα τοπικού διαχειριστή. Εάν ξεκινήσετε τον εγκαταστάτη MSI χωρίς αυτά, προσφέρει να επανεκκινήσει με προνόμια διαχειριστή.

## **Συχνές ερωτήσεις**

**Χρειάζομαι το Microsoft PowerPoint στον διακομιστή αναφορών;**

Όχι. Η επέκταση δημιουργεί τις παρουσιάσεις από μόνη της· ούτε το PowerPoint ούτε το Microsoft Office πρέπει να εγκατασταθούν.

**Μπορώ να εγκαταστήσω την επέκταση σε έκδοση Express;**

Όχι. Οι εκδόσεις Express δεν υποστηρίζουν επεκτάσεις απόδοσης. Ο εγκαταστάτης MSI κρύβει τις εκδόσεις Express του SQL Server 2016 και παλαιότερες· σε μεταγενέστερες εκδόσεις, μην επιλέξετε μια έκδοση Express.

**Ποια μορφές προσθέτει η επέκταση στη λίστα εξαγωγής;**

PPT, PPS, PPTX, PPSX, ODP και XPS. Δείτε το [Supported File Formats](/slides/el/reportingservices/supported-file-formats/).