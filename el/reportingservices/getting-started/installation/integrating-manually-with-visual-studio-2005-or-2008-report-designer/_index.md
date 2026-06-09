---
title: Χειροκίνητη ενσωμάτωση με το Visual Studio 2005 ή 2008 Report Designer
type: docs
weight: 50
url: /el/reportingservices/integrating-manually-with-visual-studio-2005-or-2008-report-designer/
---
{{% alert color="primary" %}} 
Αυτό το άρθρο σας δείχνει πώς να ενσωματώσετε το Aspose.Slides for Reporting Services χειροκίνητα με το Visual Studio. 
{{% /alert %}} 

{{% alert title="Σημείωση" color="warning" %}} 
**Aspose.Slides for Reporting Services** απαιτεί την εγκατάσταση του **.NET Framework 3.5** στον υπολογιστή-ξενιστή. 
{{% /alert %}}

## **Ενσωμάτωση Aspose.Slides for Reporting Services με το Visual Studio**
Σας συνιστούμε να χρησιμοποιήσετε το πρόγραμμα εγκατάστασης MSI για να εγκαταστήσετε το Aspose.Slides for Reporting Services, επειδή εκτελεί αυτόματα όλες τις απαραίτητες εργασίες εγκατάστασης και τις διαδικασίες διαμόρφωσης. Ωστόσο, εάν η εγκατάσταση με το πρόγραμμα MSI αποτύχει, χρησιμοποιήστε τον οδηγό εδώ. 

Το άρθρο αυτό σας δείχνει επίσης πώς να εγκαταστήσετε το Aspose.Slides for Reporting Services σε έναν υπολογιστή με το Business Intelligence Development Studio. Αυτό θα σας επιτρέψει να εξάγετε αναφορές σε μορφές Microsoft PowerPoint κατά το χρόνο σχεδιασμού από το Microsoft Visual Studio 2005 ή 2008 Report Designer. 

1. Αντιγράψτε το Aspose.Slides.ReportingServices.dll στο φάκελο του Visual Studio.

   - Για ενσωμάτωση με το Visual Studio 2005 Report Designer, αντιγράψτε **Aspose.Slides.ReportingServices.dll** στο φάκελο **C:\Program Files\Microsoft Visual Studio 8\Common7\IDE\PrivateAssemblies**. 
   - Για ενσωμάτωση με το Visual Studio 2008 Report Designer, αντιγράψτε **Aspose.Slides.ReportingServices.dll** στο φάκελο **C:\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies**. 
2. Καταχωρίστε το Aspose.Slides for Reporting Services ως επέκταση απόδοσης. 

3. Ανοίξτε **C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\RSReportDesigner.config** (όπου <Version> είναι “8” για το Visual Studio 2005 ή “9.0” για το Visual Studio 2008) και προσθέστε αυτές τις γραμμές στο στοιχείο <Render>: 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>



```

4. Δώστε στο Aspose.Slides for Reporting Services δικαιώματα εκτέλεσης. 
   1. Ανοίξτε **C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\RSPreviewPolicy.config** (όπου <Version> είναι “8” για το Visual Studio 2005 ή “9.0” για το Visual Studio 2008). 
   1. Προσθέστε αυτή τη γραμμή ως το τελευταίο στοιχείο στο δεύτερο εξωτερικό στοιχείο <CodeGroup> (το οποίο θα πρέπει να είναι <CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission.">) 

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

5. Επαληθεύστε ότι το Aspose.Slides for Reporting Services εγκαταστάθηκε επιτυχώς. 
6. Εκτελέστε ή επανεκκινήστε το Microsoft Visual Studio 2005 ή 2008 Report Designer. Θα πρέπει να παρατηρήσετε νέες μορφές στη λίστα των μορφών εξαγωγής.

**Νέες μορφές εξαγωγής εμφανίζονται στο Report Designer.** 

![todo:image_alt_text](integrating-manually-with-visual-studio-2005-or-2008-report-designer_1.png)