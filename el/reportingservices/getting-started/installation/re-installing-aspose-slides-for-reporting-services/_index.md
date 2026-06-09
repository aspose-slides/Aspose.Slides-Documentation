---
title: Επαναεγκατάσταση Aspose.Slides για Reporting Services
type: docs
weight: 40
url: /el/reportingservices/re-installing-aspose-slides-for-reporting-services/
---
{{% alert color="primary" %}} 

Αυτό το άρθρο περιγράφει τη διόρθωση για μια κατάσταση στην οποία το Aspose.Slides for Reporting Services είναι ήδη εγκατεστημένο, αλλά για οποιονδήποτε λόγο πρέπει να επανεγκατασταθεί.

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

**Aspose.Slides for Reporting Services** απαιτεί την εγκατάσταση του **.NET Framework 3.5** στον κεντρικό υπολογιστή. 

{{% /alert %}}

## **Βήματα επανεγκατάστασης του Aspose.Slides for Reporting Services**
Το πιο σημαντικό είναι η πλήρης αφαίρεση των προηγούμενων εγκαταστάσεων του Aspose.Slides for Reporting Services. Αν και το πρόγραμμα εγκατάστασης MSI μπορεί να εκτελέσει με επιτυχία τις απαραίτητες ενέργειες για την απεγκατάσταση και, κατά συνέπεια, επανεγκατάσταση του Aspose.Slides for Reporting Services αυτόματα, πρέπει να ακολουθηθούν τα παρακάτω βήματα:

1. Απεγκαταστήστε το Aspose.Slides for Reporting Services χρησιμοποιώντας το πρόγραμμα εγκατάστασης MSI. 

2. Εντοπίστε τον φάκελο εγκατάστασης του Aspose.Slides for Reporting Services, ο οποίος συνήθως βρίσκεται στο:

   **OS Root Drive\Program Files\Aspose\Aspose.Slides for Reporting Services** 

3.  Εάν ο εγκαταστάτης MSI δεν έχει διαγράψει τον φάκελο “Aspose.Slides for Reporting Services” κατά την απεγκατάσταση του Aspose.Slides for Reporting Services, διαγράψτε το φάκελο. 

4. Εντοπίστε το δυαδικό αρχείο **Aspose.Slides.ReportingServices.dll** στον φάκελο “bin” κάθε παρουσίας του SQL Server Reporting Service. Για παράδειγμα, εάν υπάρχει μια παρουσία Microsoft SQL Server 2008 με όνομα “MSSQLSERVER”, ο αντίστοιχος φάκελος “bin” του Reporting Service πιθανότατα βρίσκεται στο: 

   **OS Root Drive\Program Files\Microsoft SQL Server\MSRS10.MSSQLSERVER\Reporting Services\ReportServer\bin** 

5. Εάν ο εγκαταστάτης MSI δεν έχει διαγράψει το δυαδικό αρχείο Aspose.Slides.ReportingServices.dll από τον παραπάνω φάκελο κατά την απεγκατάσταση του Aspose.Slides for Reporting Services, διαγράψτε το αρχείο τώρα.

6. Εντοπίστε το αρχείο **rsreportserver.config** για κάθε παρουσία SSRS. Για παράδειγμα, εάν υπάρχει μια παρουσία Reporting Service “**MSRS10.MSSQLSERVER**”, το αρχείο **rsreportserver.config** θα βρίσκεται σε αυτόν το φάκελο:

   **MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

7. Ανοίξτε το αρχείο **rsreportserver.config** σε οποιονδήποτε επεξεργαστή και βρείτε τις γραμμές που δημιουργήθηκαν για την προσθήκη των επεκτάσεων μορφής PowerPoint κατά την εγκατάσταση του Aspose.Slides for Reporting Services. 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>



```

**Step** **8:** Εάν ο εγκαταστάτης MSI δεν έχει αφαιρέσει αυτές τις γραμμές κατά την απεγκατάσταση του Aspose.Slides for Reporting Services, διαγράψτε τις γραμμές από το αρχείο **rsreportserver.config** τώρα.

**Step** **9:** Εντοπίστε το αρχείο **rssrvpolicy.config** για κάθε παρουσία SSRS. Για παράδειγμα, εάν υπάρχει μια παρουσία Reporting Service “MSRS10.MSSQLSERVER”, το αρχείο **rssrvpolicy.config** θα βρίσκεται σε αυτόν το φάκελο:

**MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

**Step** **10:** Ανοίξτε το αρχείο **rssrvpolicy.config** σε οποιονδήποτε επεξεργαστή και βρείτε τις γραμμές που δημιουργήθηκαν για την παροχή δικαιωμάτων εκτέλεσης στο Aspose.Slides for Reporting Services κατά την εγκατάσταση του Aspose.Slides for Reporting Services. 

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

**Step** **11:** Εάν ο εγκαταστάτης MSI δεν έχει αφαιρέσει τις παραπάνω γραμμές κατά την απεγκατάσταση του προϊόντος, αφαιρέστε αυτές τις γραμμές από το αρχείο **rssrvpolicy.config** τώρα. 

**Step** **12:** Εάν το Aspose.Slides for Reporting Services είχε εγκατασταθεί επίσης με το Microsoft Visual Studio για ανάπτυξη RDL αναφορών και εξαγωγή σε μορφές PowerPoint στο περιβάλλον του Microsoft Visual Studio, το δυαδικό αρχείο Aspose.Slides.ReportingServices.dll και τα αρχεία διαμόρφωσης (**rsreportserver.config** και **rssrvpolicy.config**) σε περίπτωση Microsoft Visual Studio 2008 πρέπει να βρίσκονται στο: 

**OS Root Drive\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies** 

**Step** **13:** Εάν ο εγκαταστάτης MSI δεν έχει διαγράψει το δυαδικό αρχείο **Aspose.Slides.ReportingServices.dll**, διαγράψτε το. Επιπλέον, εάν δεν έχει ενημερώσει τα αρχεία **rsreportserver.config** και **rssrvpolicy.config** ώστε να αφαιρέσει τις επεκτάσεις μορφής PowerPoint και τα δικαιώματα εκτέλεσης κώδικα αντίστοιχα, πρέπει να τα αφαιρέσετε χειροκίνητα με τον ίδιο τρόπο που κάνατε με τα αρχεία στα προηγούμενα βήματα. 

**Step** **14:** Ήρθε η ώρα να επανεγκαταστήσετε το Aspose.Slides for Reporting Services. Χρησιμοποιήστε το πρόγραμμα εγκατάστασης MSI για αυτόματη εγκατάσταση ή κάντε το χειροκίνητα.