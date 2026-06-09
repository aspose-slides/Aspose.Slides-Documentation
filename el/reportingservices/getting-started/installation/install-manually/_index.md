---
title: Χειροκίνητη Εγκατάσταση
type: docs
weight: 30
url: /el/reportingservices/install-manually/
---
{{% alert color="primary" %}} 
Ακολουθήστε αυτά τα βήματα μόνο εάν σκοπεύετε να εγκαταστήσετε το Aspose.Slides for Reporting Services χειροκίνητα. Σε αυτήν την περίπτωση, έχετε κατεβάσει το πακέτο ZIP που περιέχει τα αρχεία συναρμολόγησης. 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 
**Aspose.Slides for Reporting Services** απαιτεί την εγκατάσταση του **.NET Framework 3.5** στον κεντρικό υπολογιστή. 
{{% /alert %}}

### **Χειροκίνητη Εγκατάσταση**
Αυτές οι οδηγίες σας δείχνουν πώς να αντιγράψετε και να τροποποιήσετε αρχεία στον φάκελο όπου είναι εγκατεστημένο το Microsoft SQL Server Reporting Services: 

1. Εντοπίστε τον φάκελο εγκατάστασης του Report Server.  
   Ο ριζικός φάκελος για το Microsoft SQL Server βρίσκεται συνήθως εδώ: ***C:\Program Files\Microsoft SQL Server***
   
   {{% alert color="primary" %}} 
   
   **Microsoft SQL Server 2005 και 2008**: Μπορεί να υπάρχουν πολλές παραλλαγές Microsoft SQL Server ρυθμισμένες στον υπολογιστή και μπορεί να κατέχουν διαφορετικούς υποφακέλους MSSQL.x όπως MSSQL.1, MSSQL.2 κλπ. Πρέπει να βρείτε τον σωστό φάκελο ***C:\Program Files\Microsoft SQL Server\MSSQL.x\Reporting Services\ReportServer*** προτού συνεχίσετε στο επόμενο βήμα. 
   
   {{% /alert %}} Όλοι οι παρακάτω δρόμοι θα αναφέρονται σε αυτόν τον φάκελο ως <Instance>. 

2. Αντιγράψτε το Aspose.Slides.ReportingServices.dll στον φάκελο **C:\Program Files\Microsoft SQL Server\xxx\Reporting Services\ReportServer\bin**.  
   Το αρχείο λήψης **Aspose.Slides.ReportingServices.zip** περιέχει το **Aspose.Slides.ReportingServices.dll**. {{% alert color="primary" %}} 

   Σε ορισμένες περιπτώσεις, όταν αντιγράφετε το DLL στον φάκελο **ReportServer\bin**, μπορεί να αντιγραφεί μαζί με τις ρητές δικαιώματα αρχείου NTFS που του έχουν ανατεθεί. Τα δικαιώματα NTFS προκαλούν το Microsoft SQL Server Reporting Services να απορρίψει την πρόσβαση κατά τη φόρτωση του **Aspose.Slides.ReportingServices.dll**. Εάν συμβεί αυτό, οι νέες μορφές εξαγωγής δεν θα είναι διαθέσιμες. Ελέγξτε και επιβεβαιώστε ότι τα σωστά δικαιώματα NTFS είναι σε ισχύ :

   1. Κάντε δεξί κλικ στο **Aspose.Slides.ReportingServices.dll**.  
   1. Κάντε κλικ στο **Properties** και επιλέξτε την καρτέλα **Security**.  
   1. Αφαιρέστε τυχόν ρητά ανατεθειμένα δικαιώματα NTFS και διατηρήστε μόνο τα κληρονομημένα δικαιώματα.  

   {{% /alert %}}

3. Καταχωρίστε το Aspose.Slides for Reporting Services ως επέκταση απόδοσης:  
   1. Ανοίξτε το *C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rsreportserver.config*.  
   1. Προσθέστε αυτές τις γραμμές στο στοιχείο <Render>:  

**<Render>**

``` xml

   ...

  <!--Ξεκινήστε εδώ.-->

  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

  <!--Τελειώστε εδώ.-->

</Render>



```

4. Δώστε στο Aspose.Slides for Reporting Services δικαιώματα εκτέλεσης:  
   1. Ανοίξτε το **C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rssrvpolicy.config**.  
   1. Προσθέστε τα παρακάτω ως το τελευταίο στοιχείο στο δεύτερο προς το εξωτερικό στοιχείο <CodeGroup> (το οποίο πρέπει να είναι <CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission. ">).  

**<CodeGroup>**

``` xml



...

  <CodeGroup>

    ...

    <!--Ξεκινήστε εδώ.-->

    <CodeGroup

        class="UnionCodeGroup"

        version="1"

        PermissionSetName="FullTrust"

        Name="Aspose.Slides_for_Reporting_Services"

        Description="This code group grants full trust to the AS4SSRS assembly.">

        <IMembershipCondition

            class="StrongNameMembershipCondition"

            version="1"

            PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001005542e

            99cecd28842dad186257b2c7b6ae9b5947e51e0b17b4ac6d8cecd3e01c4d20658c5e4ea1b9a6c8f854b2

            d796c4fde740dac65e834167758cff283eed1be5c9a812022b015a902e0b97d4e95569eb8c0971834744

            e633d9cb4c4a6d8eda03c12f486e13a1a0cb1aa101ad94943236384cbbf5c679944b994de9546e493bf" />

    </CodeGroup>

    <!--Τελειώστε εδώ.-->

  </CodeGroup>

</CodeGroup>



```

5. Επαληθεύστε ότι το Aspose.Slides for Reporting Services εγκαταστάθηκε επιτυχώς:  
   1. Ανοίξτε το Report Manager και ελέγξτε τη λίστα των διαθέσιμων τύπων εξαγωγής για μια αναφορά.  
   
   {{% alert color="primary" %}} Μπορείτε να εκκινήσετε το Report Manager ανοίγοντας ένα πρόγραμμα περιήγησης (Microsoft Internet Explorer 6.0 ή νεότερο) και πληκτρολογώντας τη διεύθυνση URL του Report Manager στη γραμμή διευθύνσεων (κατ' προεπιλογή είναι http://< ComputerName >/Reports ).  
   
   {{% /alert %}}

   1. Επιλέξτε μια αναφορά στον διακομιστή.  
   1. Ανοίξτε τη λίστα **Select Format**.  
      Θα πρέπει να δείτε μια λίστα μορφών εξαγωγής που παρέχονται από το Aspose.Slides for Reporting Services.  
   1. Επιλέξτε **PPT – PowerPoint Presentation via Aspose.Slides**.  

   **Το Aspose.Slides for Reporting Services εγκαταστάθηκε επιτυχώς και οι νέες μορφές εξαγωγής είναι διαθέσιμες.**  

![todo:image_alt_text](install-manually_1.png)




6. Κάντε κλικ στον σύνδεσμο **Export**.  
   Η αναφορά δημιουργείται στην επιλεγμένη μορφή, αποστέλλεται στον πελάτη και στη συνέχεια ανοίγεται σε κατάλληλη εφαρμογή. Στην περίπτωσή μας, η αναφορά ανοίχθηκε στο Microsoft PowerPoint.  

   **Μία αναφορά PPT που δημιουργήθηκε από το Aspose.Slides for Reporting Services.**  

![todo:image_alt_text](install-manually_2.png)

Έχετε εγκαταστήσει επιτυχώς το Aspose.Slides for Reporting Services και δημιουργήσει μια αναφορά ως παρουσίαση Microsoft PowerPoint !