---
title: Χειροκίνητη Εγκατάσταση
type: docs
weight: 30
url: /el/reportingservices/install-manually/
keywords:
- χειροκίνητη εγκατάσταση
- rsreportserver.config
- rssrvpolicy.config
- SQL Server Reporting Services
- Power BI Report Server
- Aspose.Slides for Reporting Services
description: "Εγκαταστήστε το Aspose.Slides for Reporting Services με το χέρι από το πακέτο ZIP μόνο με DLLs: ποιο assembly να αντιγράψετε και τι να προσθέσετε στα αρχεία rsreportserver.config και rssrvpolicy.config."
---
## **Επισκόπηση**

Ακολουθήστε τα παρακάτω βήματα για να εγκαταστήσετε το Aspose.Slides for Reporting Services χωρίς το πρόγραμμα εγκατάστασης MSI, από το πακέτο ZIP *Aspose.Slides for Reporting Services XX.XX (DLLs Only)* στη [σελίδα λήψης](https://releases.aspose.com/slides/el/reportingservices/). Καταχωρούν τις ίδιες επεκτάσεις όπως ο [MSI installer](/slides/el/reportingservices/install-with-msi-installer/). Επαναλάβετε τα βήματα για κάθε παράδειγμα server αναφοράς.

Πριν ξεκινήσετε, ελέγξτε τις [απαιτήσεις συστήματος](/slides/el/reportingservices/system-requirements/). Χρειάζεστε δικαιώματα τοπικού διαχειριστή στον server αναφοράς.

## **Επιλογή του Assembly**

Το πακέτο ZIP περιέχει αρκετές εκδόσεις. Αντιγράψτε ακριβώς ένα *Aspose.Slides.ReportingServices.dll* στον server αναφοράς:

| Αρχείο στο πακέτο ZIP | Χρήση |
| :- | :- |
| *Bin\Universal\Aspose.Slides.ReportingServices.dll* | SQL Server 2008 και νεότερα Reporting Services, καθώς και Power BI Report Server |
| *Bin\SSRS2005\Aspose.Slides.ReportingServices.dll* | SQL Server 2005 Reporting Services |
| *Bin\ReportViewer2010\Aspose.Slides.ReportingServices.dll* | Δεν προορίζεται για server αναφοράς: εφαρμογές που εξάγουν από το στοιχείο ελέγχου ReportViewer 2010 ή 2012, δείτε [Χρήση του Aspose.Slides με ReportViewer 2010 και 2012](/slides/el/reportingservices/using-aspose-slides-with-reportviewer-2010-and-2012/) |
| *Bin\RplExport\Aspose.ReportingServices.Debug.Rpl.dll* | Προαιρετικό: αποθηκεύει αναφορές σε μορφή RPL για προβλήματα αναφορών, δείτε [Εξαγωγή Αναφορών σε Μορφή RPL](/slides/el/reportingservices/exporting-reports-to-rpl-format/) |

## **Εντοπισμός του Φακέλου του Server Αναφοράς**

Τα παρακάτω βήματα αναφέρονται στο φάκελο *ReportServer* του server αναφοράς, ο οποίος περιέχει τα *rsreportserver.config* και *rssrvpolicy.config*. Σε μια προεπιλεγμένη εγκατάσταση, είναι:

| Server Αναφοράς | Προεπιλεγμένος φάκελος *ReportServer* |
| :- | :- |
| SQL Server 2017 και νεότερα Reporting Services | `C:\Program Files\Microsoft SQL Server Reporting Services\SSRS\ReportServer` |
| Power BI Report Server | `C:\Program Files\Microsoft Power BI Report Server\PBIRS\ReportServer` |
| SQL Server 2016 και παλαιότερα Reporting Services | `C:\Program Files\Microsoft SQL Server\<instance folder>\Reporting Services\ReportServer`, όπου ο φάκελος του instance είναι, για παράδειγμα, `MSRS13.MSSQLSERVER` για SQL Server 2016 ή `MSSQL.x` για SQL Server 2005 |

Για περισσότερες θέσεις, δείτε το άρθρο της Microsoft [Αρχείο διαμόρφωσης RsReportServer.config](https://learn.microsoft.com/en-us/sql/reporting-services/report-server/rsreportserver-config-configuration-file).

## **Εγκατάσταση της Επέκτασης**

1. Αντιγράψτε το assembly που επιλέξατε στο υποφάκελο *bin* του φακέλου *ReportServer*.

   Το αντιγραμμένο αρχείο δεν πρέπει να έχει ρητά εκχωρημένα δικαιώματα NTFS, διαφορετικά ο server αναφοράς θα απορρίψει την πρόσβαση όταν φορτώσει το assembly και οι νέες μορφές εξαγωγής δεν θα εμφανιστούν. Κάντε δεξί κλικ στο αρχείο, επιλέξτε **Properties**, και στην καρτέλα **Security** αφαιρέστε τυχόν ρητά εκχωρημένα δικαιώματα, αφήνοντας μόνο τα κληρονομημένα. Εάν η καρτέλα **General** εμφανίζει επιλογή **Unblock**, επιλέξτε την.

2. Αποθηκεύστε ένα αντίγραφο του *rsreportserver.config* και, στη συνέχεια, ανοίξτε το αρχείο σε επεξεργαστή κειμένου. Προσθέστε αυτές τις καταχωρήσεις μέσα στο στοιχείο `<Render>`:

   ```xml
   <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASXPSS" Type="Aspose.Slides.ReportingServices.XpsRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASODP" Type="Aspose.Slides.ReportingServices.OdpRenderer,Aspose.Slides.ReportingServices"/>
   ```

   Κάθε καταχώρηση καταχωρεί μία μορφή εξαγωγής· το `Name` πρέπει να είναι μοναδικό μεταξύ των επεκτάσεων απόδοσης. Ο εγκαταστάτης MSI καταχωρεί τα ίδια έξι ονόματα και τύπους. Παραλείψτε μια καταχώρηση εάν δεν θέλετε τη μορφή της στη λίστα εξαγώσεων.

3. Αποθηκεύστε ένα αντίγραφο του *rssrvpolicy.config* και, στη συνέχεια, ανοίξτε το αρχείο σε επεξεργαστή κειμένου. Βρείτε την ομάδα κώδικα της οποίας η `Description` είναι "This code group grants MyComputer code Execution permission." και προσθέστε αυτήν την ομάδα κώδικα ως τελευταίο παιδί της:

   ```xml
   <CodeGroup class="UnionCodeGroup" version="1" PermissionSetName="FullTrust" Name="Aspose.Slides_for_Reporting_Services" Description="This code group grants full trust to the Aspose.Slides.ReportingServices.dll assembly.">
       <IMembershipCondition class="StrongNameMembershipCondition" version="1" PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001005542e99cecd28842dad186257b2c7b6ae9b5947e51e0b17b4ac6d8cecd3e01c4d20658c5e4ea1b9a6c8f854b2d796c4fde740dac65e834167758cff283eed1be5c9a812022b015a902e0b97d4e95569eb8c0971834744e633d9cb4c4a6d8eda03c12f486e13a1a0cb1aa101ad94943236384cbbf5c679944b994de9546e493bf"/>
   </CodeGroup>
   ```

   Το `PublicKeyBlob` είναι το δημόσιο κλειδί του assembly Aspose.Slides.ReportingServices. Κρατήστε το σε μία γραμμή.

4. Αποθηκεύστε και τα δύο αρχεία. Ο server αναφοράς διαβάζει ξανά τα αρχεία διαμόρφωσης κάθε φορά που αποθηκεύονται. Εάν κάποιο αρχείο περιέχει κακοδιαμορφωμένο XML, ο server αναφοράς το αγνοεί ή δεν ξεκινά, οπότε επαναφέρετε το αντίγραφο σας εάν κάτι πάει στραβά.

## **Έλεγχος της Εγκατάστασης**

Ανοίξτε μια σελιδοποιημένη αναφορά στην πύλη διαδικτύου (Report Manager σε SQL Server 2014 και παλαιότερα) και ανοίξτε τη λίστα **Export**. Τώρα περιλαμβάνει τις ακόλουθες μορφές:

- PPT - Παρουσίαση PowerPoint μέσω Aspose.Slides
- PPS - Παρουσίαση διαφανειών PowerPoint μέσω Aspose.Slides
- PPTX - Παρουσίαση PowerPoint 2007 μέσω Aspose.Slides
- PPSX - Παρουσίαση διαφανειών PowerPoint 2007 μέσω Aspose.Slides
- ODP - Παρουσίαση OpenDocument μέσω Aspose.Slides
- XPS - μέσω Aspose.Slides

Επιλέξτε μία από αυτές για να εξάγετε την αναφορά. Το αρχείο ανοίγει στην εφαρμογή που είναι συσχετισμένη με τη μορφή του.

![Μια αναφορά που εξάγεται σε PowerPoint από το Aspose.Slides for Reporting Services](install-manually_2.png)

Αν οι μορφές δεν εμφανιστούν, ελέγξτε τα δικαιώματα NTFS του αντιγραμμένου assembly. Χωρίς άδεια, τα εξαγόμενα αρχεία φέρουν υδατογράφημα αξιολόγησης· δείτε [Licensing](/slides/el/reportingservices/license-aspose-slides-for-reporting-services/).