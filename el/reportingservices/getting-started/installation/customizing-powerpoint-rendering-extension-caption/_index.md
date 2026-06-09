---
title: Προσαρμογή Τίτλου Επέκτασης Απόδοσης PowerPoint
type: docs
weight: 60
url: /el/reportingservices/customizing-powerpoint-rendering-extension-caption/
---
{{% alert color="primary" %}} 

Αυτό το άρθρο δείχνει πώς να προσαρμόσετε τους τίτλους των επιλογών απόδοσης του Aspose.Slides για Reporting Services. 

{{% /alert %}} 
## **Παράδειγμα**
Κατά την εγκατάσταση του Aspose.Slides for Reporting Services, προστίθενται 4 επιπλέον επιλογές εξαγωγής στο αναπτυσσόμενο μενού των επιλογών εξαγωγής:

![todo:image_alt_text](customizing-powerpoint-rendering-extension-caption_1.png)
## **Πώς να τροποποιήσετε το κείμενο των τίτλων**
Οι προεπιλεγμένοι τίτλοι αυτών των επεκτάσεων μπορούν να αλλάξουν αντικαθιστώντας τα προεπιλεγμένα ονόματα. Αυτά τα βήματα δείχνουν πώς να αλλάξετε τον τίτλο από “ **PPT – PowerPoint** **Presentation via** **Aspose.Slides** ” σε “ **PowerPoint 97 – 2003 format(PPT)** ”. 

**Βήμα 1:** Εντοπίστε το αρχείο **rsreportserver.config** το οποίο συνήθως βρίσκεται σε αυτόν τον φάκελο: 

**OS Root Drive\Program Files\Microsoft SQL Server\MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

**Βήμα** **2:** Βρείτε αυτές τις γραμμές στο αρχείο rsreportserver.config: 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>



```

**Βήμα** **3:** Αντικαταστήστε την παράμετρο της επέκτασης με αυτήν: 

**<Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices">**

``` xml

         <OverrideNames>

          <Name Language="en-US">PowerPoint 97 - 2003 Format(PPT)</Name>

        </OverrideNames>

</Extension>



```

Οι επιλογές εξαγωγής θα εμφανίζονται πλέον ως εξής: 

![todo:image_alt_text](customizing-powerpoint-rendering-extension-caption_2.png)