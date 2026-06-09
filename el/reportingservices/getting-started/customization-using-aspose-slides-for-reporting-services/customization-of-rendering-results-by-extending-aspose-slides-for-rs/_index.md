---
title: Προσαρμογή των αποτελεσμάτων απόδοσης με την επέκταση του Aspose.Slides για RS
type: docs
weight: 10
url: /el/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/
---
{{% alert color="primary" %}} 
Αυτή η σελίδα περιγράφει πώς να δημιουργήσετε επέκταση για το Aspose.Slides for RS.

- [Δημιουργία assembly επέκτασης](/slides/el/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/).
- [Ενσωμάτωση της επέκτασης](/slides/el/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/).

{{% /alert %}} 

Η λειτουργία Custom Extension σας δίνει τη δυνατότητα να προσθέσετε επιπλέον στοιχεία ή να ενημερώσετε υπάρχοντα στοιχεία κατά την εξαγωγή της αναφοράς.
## **Πώς να δημιουργήσετε ένα Assembly επέκτασης**
1. Δημιουργήστε ένα έργο .NET και προσθέστε μια αναφορά στο Aspose.Slides.ReportingServices.dll.
1. Προσθέστε μια κλάση και κληρονομήστε την από την Aspose.Slides.ReportingServices.Extension.RenderingExtensionBase.
1. Παρακάμψτε τις εικονικές μεθόδους της κλάσης για να προσθέσετε προσαρμοσμένη λειτουργικότητα.
### **Παράδειγμα**
Ας υποθέσουμε ότι θέλουμε να προσθέσουμε μία σημείωση με κείμενο, ένα λογότυπο και να ενημερώσουμε το όνομα της εταιρείας για κάθε αναφορά που εξάγεται με το Aspose.Slides for RS.

Για το σκοπό αυτό προσθέτουμε την ακόλουθη κλάση:

``` xml

 public class DemoRenderingExtension : Aspose.Slides.ReportingServices.Extension.RenderingExtensionBase

{

public override void PostProcessSlide(Aspose.Slides.ReportingServices.Extension.Slide slide)

{

//Προσθέστε σημείωση στην πρώτη διαφάνεια

if (this.CurrentSlideIndex == 0)

{

TextFormat textFormat = new TextFormat("Arial", 25);

textFormat.Bold = true;

slide.AddNote("This is the demo of Rendering Extension for Aspose.Slides for ReportingServices",

textFormat);

}

//Εμφανίστε το λογότυπο σε κάθε διαφάνεια στην κάτω δεξιά γωνία

using (Stream imageStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("TestSlidesRenderingExtension.aspose.slides-for-ssrs-logo.jpg"))

{

slide.AddImage(imageStream, new RectangleF(slide.Size.Width - 20, slide.Size.Height - 20, 15, 15));

}

base.PostProcessSlide(slide);

}


public override void PostProcessTextBox(Aspose.Slides.ReportingServices.Extension.TextBox textBox)

{

//Προσθέστε (TM) σε κάθε αναφορά του ονόματος της εταιρείας στην αναφορά

string companyName = "Adventure Works";

if (textBox.Text.Contains(companyName))

{

textBox.Text = textBox.Text.Replace(companyName, companyName + "™");

}

base.PostProcessTextBox(textBox);

}

}
```

{{% alert color="primary" %}} 
Δομήστε το και θα λάβετε το assembly της επέκτασης. Είμαστε έτοιμοι να ενσωματώσουμε την επέκταση.
{{% /alert %}} 

[Έργο Visual Studio του RenderingExtensionDemo.zip](attachments/10289195/10452998.zip)
### **Ενσωμάτωση της επέκτασης**
Ας υποθέσουμε ότι το assembly σας ονομάζεται **TestSlidesRenderingExtension.dll**:

- Αντιγράψτε το assembly στον φάκελο **bin** του ReportingService δίπλα στο Aspose.Slides.ReportingServices.dll. (Για παράδειγμα: c:\Program Files\Microsoft SQL Server\MSRS10_50\Reporting Services\ReportServer\bin)
- Χορηγήστε δικαίωμα FullTrust στο assembly σας προσθέτοντας την ακόλουθη CodeGroup στο **rssrvpolicy.config**:

``` xml

 <CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Nothing">

<IMembershipCondition class="AllMembershipCondition" version="1" />

...

<CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission. ">

<IMembershipCondition class="ZoneMembershipCondition" version="1" Zone="MyComputer" />

...

<CodeGroup class="UnionCodeGroup" version="1" PermissionSetName="FullTrust" Name="Aspose.Slides_Extension" Description="This code group grants full trust to the Aspose.Slides for Reporting Services Rendering extension.">

<IMembershipCondition	class="UrlMembershipCondition"	version="1" Url="c:\Program Files\Microsoft SQL Server\MSRS10_50\Reporting Services\ReportServer\bin\TestSlidesRenderingExtension.dll" />

</CodeGroup>

</CodeGroup>

</CodeGroup>

```

Ενημερώστε τις ενότητες ρυθμίσεων επέκτασης απόδοσης του Aspose.Slides στο **rsreportserver.config** ώστε να περιλαμβάνουν την επέκτασή σας.

``` xml

 <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices">

<Configuration>

<Extension>TestSlidesRenderingExtension.DemoRenderingExtension, TestSlidesRenderingExtension</Extension>

</Configuration>

</Extension>

```

Αν θέλετε να χρησιμοποιήσετε την επέκταση για κάθε τύπο εξόδου που υποστηρίζεται από το Aspose.Slides, προσθέστε την ίδια ρύθμιση στις επεκτάσεις με τα ονόματα ASPPTX, ASPPT, ASPPS, ASPPSX.
Το περιεχόμενο της ετικέτας Extension είναι ένα όνομα τύπου με πλήρη διαδρομή assembly. (Δείτε <https://docs.microsoft.com/en-us/dotnet/api/system.type.assemblyqualifiedname>)

Τώρα επανεκκινήστε το Reporting Services και εξάγετε την αναφορά. Θα λάβετε κάτι όπως [αυτή η παρουσίαση](attachments/10289195/10452997.pptx) από την αναφορά Company Sales SQL2008R2 των δειγμάτων Adventureworks.