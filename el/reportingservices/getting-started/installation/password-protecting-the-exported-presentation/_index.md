---
title: Προστασία με κωδικό πρόσβασης της εξαγόμενης παρουσίασης
type: docs
weight: 90
url: /el/reportingservices/password-protecting-the-exported-presentation/
---
{{% alert color="primary" %}} 

Η προστασία με κωδικό πρόσβασης μιας παρουσίασης αποτρέπει μη εξουσιοδοτημένη χρήση και πρόσβαση. Η προστασία με κωδικό πρόσβασης είναι χρήσιμη εάν δημιουργείτε αναφορές που περιέχουν ευαίσθητα δεδομένα ή λεπτομέρειες που θα πρέπει να βλέπουν μόνο ορισμένα άτομα στον οργανισμό σας.

Αυτό το άρθρο σας δείχνει πώς να ενημερώσετε το περιβάλλον Reporting Services ή Visual Studio ώστε να μπορείτε να αποθηκεύετε παρουσιάσεις με προστασία κωδικού πρόσβασης.

{{% /alert %}} 
## **Προσθήκη προστασίας κωδικού πρόσβασης σε εξαγόμενες παρουσιάσεις σε περιβάλλον Reporting Services**
Για την εφαρμογή των αλλαγών, πρέπει να τροποποιήσετε αρχεία στον φάκελο όπου είναι εγκατεστημένο το Microsoft SQL Server Reporting Services.
### **Βήμα 1. Εντοπίστε τον φάκελο εγκατάστασης του Reporting Server.**
Ο ριζικός φάκελος του Microsoft SQL Server είναι συνήθως C:\Program Files\Microsoft SQL Server.

{{% alert color="primary" %}} 

Για συστήματα 64‑bit, η εγκατάσταση x86 του SQL Server βρίσκεται στη διαδρομή C:\Program Files (x86)\Microsoft SQL Server\

{{% /alert %}} 

Microsoft SQL Server 2005 και 2008: Μπορεί να υπάρχουν πολλαπλές εγκαταστάσεις του Microsoft SQL Server στο μηχάνημα. Κάθε μία καταλαμβάνει διαφορετικό υποφάκελο MSSQL.x, π.χ. MSSQL.1, MSSQL.2 κ.λπ. Βρείτε τον σωστό φάκελο C:\Program Files\Microsoft SQL Server\MSSQL.x\Reporting Services\ReportServer πριν προχωρήσετε στα επόμενα βήματα.

Όλες οι διαδρομές που χρησιμοποιούνται παρακάτω αναφέρονται στον φάκελο εγκατάστασης του Microsoft SQL Server Reporting Services ως <Instance>.
### **Βήμα 2. Προσθέστε τον κώδικα για την προσθήκη κωδικών σε εξαγόμενες παρουσιάσεις**
Αντικαταστήστε τις υπάρχουσες επεκτάσεις απόδοσης Aspose.Slides για Reporting Services στο αρχείο **rsreportserver.config**. Για να το κάνετε αυτό, ανοίξτε το αρχείο C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rsreportserver.config.

Βρείτε τις επιλογές απόδοσης που εμφανίζονται αμέσως παρακάτω και αντικαταστήστε τις με τον κώδικα που ακολουθεί.

#### **Εύρεση επιλογών απόδοσης Aspose.Slides για Reporting Service**
**<Render>**

``` xml

   ...

  <!--Ξεκινήστε εδώ.-->


  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

<!--Τέλος εδώ.-->

</Render>
```
#### **Κώδικας αντικατάστασης**
**<Render>**

``` xml

   ...

  <!--Ξεκινήστε εδώ.-->



  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 		



	<Password>111</Password>

  </Configuration>			



 </Extension>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 		



	<Password>111</Password>

  </Configuration>			



 </Extension>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 		



	<Password>111</Password>

  </Configuration>			



 </Extension>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 		



	<Password>111</Password>

  </Configuration>			



 </Extension>

  <!--Τέλος εδώ.-->


</Render>
```
### **Προσθήκη προστασίας κωδικού πρόσβασης για εξαγόμενες παρουσιάσεις στο Visual Studio**
Για την εφαρμογή των αλλαγών, πρέπει να τροποποιήσετε το αρχείο όπου είναι εγκατεστημένος ο Microsoft Visual Studio Report Designer.
### **Βήμα 1. Ανοίξτε το φάκελο του Visual Studio.**
- Για ενσωμάτωση με το Visual Studio 2005 Report Designer, ανοίξτε τον φάκελο C:\Program Files\Microsoft Visual Studio 8\Common7\IDE\PrivateAssemblies.
- Για ενσωμάτωση με το Visual Studio 2008 Report Designer, ανοίξτε τον φάκελο C:\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies.
### **Βήμα 2. Προσθέστε τον κώδικα για την προσθήκη κωδικού σε εξαγόμενες παρουσιάσεις.**
Αντικαταστήστε τις υπάρχουσες επεκτάσεις απόδοσης Aspose.Slides για Reporting Services στο αρχείο **rsreportserver.config**. Για να το κάνετε αυτό, ανοίξτε το αρχείο C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\RSReportDesigner.config (όπου **<Version>** είναι “8” για το Visual Studio 2005 ή “9.0” για το Visual Studio 2008) και προσθέστε αυτές τις γραμμές στο στοιχείο **<Render>**. Στη συνέχεια, αντικαταστήστε τις με τον κώδικα στο επόμενο τμήμα κώδικα.

#### **Εύρεση επιλογών απόδοσης Aspose.Slides για Reporting Service**
**<Render>**

``` xml

   ...

  <!--Ξεκινήστε εδώ.-->


  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

<!--Τέλος εδώ.-->


</Render>

```
#### **Κώδικας αντικατάστασης**
**<Render>**

``` xml

   ...

  <!--Ξεκινήστε εδώ.-->



  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 		


	<Password>111</Password>

  </Configuration>			


 </Extension>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 		


	<Password>111</Password>

  </Configuration>			


 </Extension>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 		


	<Password>111</Password>

  </Configuration>			


 </Extension>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 		


	<Password>111</Password>

  </Configuration>			


 </Extension>

  <!--Τέλος εδώ.-->


</Render>
```