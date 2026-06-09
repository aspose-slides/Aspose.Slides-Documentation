---
title: Εξαγωγή Αναφορών σε μορφή RPL
type: docs
weight: 110
url: /el/reportingservices/exporting-reports-to-rpl-format/
---

{{% alert color="primary" %}} 
Aspose.Slides χρησιμοποιεί αναφορές σε μορφή RPL (Report Processing Language) για απόδοση. Αυτή η σελίδα δείχνει πώς να εξάγετε αναφορές στη μορφή RPL.
{{% /alert %}} 

Σε πολλές περιπτώσεις, οι πελάτες πρέπει να μοιράζονται τις αναφορές που περιέχουν προβλήματα για επίλυση με το προσωπικό της Aspose. Όταν οι μοιραζόμενες αναφορές είναι σε μορφή RDL, το σύνολο δεδομένων ή το σχήμα μοιράζονται επίσης ώστε να μπορούμε να επαναλάβουμε το πρόβλημα. Μερικές φορές, ακόμη και η κοινοποίηση της αναφοράς RDL μαζί με το σύνολο δεδομένων δεν είναι επαρκής για την πλήρη επίλυση του ζητήματος. Σε τέτοιες περιπτώσεις, συνιστούμε να εξάγετε τις αναφορές σε μορφή RPL και να μοιράζεστε το αρχείο RPL για αναφορά μαζί μας. Το αρχείο RPL περιλαμβάνει επίσης το σύνολο δεδομένων που χρησιμοποιήθηκε. Με αυτόν τον τρόπο, η εξαγωγή σε RPL γίνεται πιο εύκολη και μπορεί να μοιραστεί αμέσως μαζί μας.

Ακολουθήστε τα παρακάτω βήματα:

1. Αντιγράψτε το Aspose.ReportingServices.Debug.Rpl.dll στον κατάλογο bin των Reporting Services (συνήθως στο c:\Program Files\Microsoft SQL Server\MSRS10_50.SQL2008R2\Reporting Services\ReportServer\bin).

{{% alert color="primary" %}} 
Το Aspose.ReportingServices.Debug.Rpl.dll είναι διαθέσιμο στις πιο πρόσφατες εκδόσεις του Aspose.Slides for Reporting Services, που μπορούν να ληφθούν από τη [Σελίδα Εκδόσεων](https://releases.aspose.com/slides/el/reportingservices/).
{{% /alert %}} 

2. Προσθέστε αυτή την επέκταση στην ετικέτα **<Render>** του αρχείου **rsreportserver.config** (συνήθως στο c:\Program Files\Microsoft SQL Server\MSRS10_50.SQL2008R2\Reporting Services\ReportServer\rsreportserver.config)

``` xml



//Προσθέστε αυτή την ετικέτα στο στοιχείο <Render> 


   <Extension Name="ASRPLDEBUG" Type="Aspose.Slides.ReportingServices.DebugRplRenderer,Aspose.ReportingServices.Debug.Rpl" >

	  </Extension>


```

3. Καθορίστε τη διαδρομή των παραγόμενων αρχείων RPL τροποποιώντας το στοιχείο path.

4. Δώστε στο Aspose.ReportingServices.Debug.Rpl.dll δικαιώματα εκτέλεσης με τον εξής τρόπο: ανοίξτε το C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rssrvpolicy.config και προσθέστε αυτό ως το τελευταίο στοιχείο στο δεύτερο προς το εξωτερικό στοιχείο **<CodeGroup>** (που θα πρέπει να είναι **<CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission. ">** ) :

``` xml



<CodeGroup>

  ...

  <CodeGroup>

    ...

    <!--Ξεκινήστε εδώ.-->

				<CodeGroup class="UnionCodeGroup"

					version="1"

					PermissionSetName="FullTrust"

					Name="Aspose.Rpl_Debug_for_Reporting_Services"

					Description="Code group for my Aspose.Rpl.Debug rendering extension">

			<IMembershipCondition class="StrongNameMembershipCondition" version="1" PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001006b80fcda1455ae4cf3919835348890372b899f004785c4254480f2278db2867313aedbf0224038beff12cb44da0493dcfadaef543dce262358ae3f6e383bfd9466d1b59828a5c1ff4097ec0ef4a087bd7090c2a0de710ffa2d2f045e0626f40a32d63c9bde1fc9538d478a1caac9155563a103b275e646a728e711057308dbe3" />

				</CodeGroup>

    <!--Τελειώστε εδώ.-->

  </CodeGroup>

</CodeGroup>


```

5. Επανεκκινήστε τις Reporting Services. Θα πρέπει να βρείτε την επιλογή Aspose.Rpl στο μενού Εξαγωγής.

Η επιλογή "Rpl export" θα πρέπει να εμφανίζεται στον πίνακα εξαγωγής. Πρέπει να εξάγετε την αναφορά σε RPL και να μοιραστείτε το αρχείο RPL.