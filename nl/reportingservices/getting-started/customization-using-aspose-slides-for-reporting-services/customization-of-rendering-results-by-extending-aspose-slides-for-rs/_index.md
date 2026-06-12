---
title: Aanpassing van renderresultaten door Aspose.Slides voor RS uit te breiden
type: docs
weight: 10
url: /nl/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/
---
{{% alert color="primary" %}} 

Deze pagina beschrijft hoe je een extensie maakt voor Aspose.Slides voor RS.

- [Create an Extension Assembly](/slides/nl/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/).
- [Integrating the Extension](/slides/nl/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/).

{{% /alert %}} 

De functie Aangepaste Extensie biedt je de mogelijkheid om extra elementen toe te voegen of bestaande elementen bij te werken tijdens het exporteren van rapporten.
## **How to Create an Extension Assembly**
1. Maak een .NET‑project aan en voeg een referentie toe aan Aspose.Slides.ReportingServices.dll.
2. Voeg een klasse toe en erf daarvan van Aspose.Slides.ReportingServices.Extension.RenderingExtensionBase.
3. Overschrijf de virtuele methoden van de klasse om aangepaste functionaliteit toe te voegen.
### **Example**
Stel dat we een notitie met wat tekst, een logo en de bedrijfsnaam voor elk rapport dat met Aspose.Slides voor RS wordt geëxporteerd, willen toevoegen.

Voor dat doel voegen we de volgende klasse toe:

``` xml
 public class DemoRenderingExtension : Aspose.Slides.ReportingServices.Extension.RenderingExtensionBase

{

public override void PostProcessSlide(Aspose.Slides.ReportingServices.Extension.Slide slide)

{

//Voeg een notitie toe aan de eerste dia

if (this.CurrentSlideIndex == 0)

{

TextFormat textFormat = new TextFormat("Arial", 25);

textFormat.Bold = true;

slide.AddNote("This is the demo of Rendering Extension for Aspose.Slides for ReportingServices",

textFormat);

}

//Toon logo op elke dia in de rechteronderhoek

using (Stream imageStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("TestSlidesRenderingExtension.aspose.slides-for-ssrs-logo.jpg"))

{

slide.AddImage(imageStream, new RectangleF(slide.Size.Width - 20, slide.Size.Height - 20, 15, 15));

}

base.PostProcessSlide(slide);

}


public override void PostProcessTextBox(Aspose.Slides.ReportingServices.Extension.TextBox textBox)

{

//Voeg (TM) toe aan elke vermelding van de bedrijfsnaam in het rapport

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

Bouw deze en je krijgt een extensie‑assembly. We zijn klaar om de extensie te integreren.

{{% /alert %}} 

[Visual studio project of RenderingExtensionDemo.zip](attachments/10289195/10452998.zip)
### **Integrating the Extension**
Stel dat je assembly **TestSlidesRenderingExtension.dll** heet:

- Kopieer de assembly naar de ReportingService **bin**‑map naast Aspose.Slides.ReportingServices.dll. (Bijvoorbeeld: c:\Program Files\Microsoft SQL Server\MSRS10_50\Reporting Services\ReportServer\bin)
- Verleen FullTrust‑machtigingen aan je assembly door de volgende CodeGroup toe te voegen aan **rssrvpolicy.config**:

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

Werk de Aspose.Slides‑rendering‑extensie‑configuratiesecties van **rsreportserver.config** bij om je extensie op te nemen.

``` xml

 <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices">

<Configuration>

<Extension>TestSlidesRenderingExtension.DemoRenderingExtension, TestSlidesRenderingExtension</Extension>

</Configuration>

</Extension>

```

Als je de extensie voor elk door Aspose.Slides ondersteund outputtype wilt gebruiken, voeg dan dezelfde configuratie toe aan extensies met de namen ASPPTX, ASPPT, ASPPS, ASPPSX.  
De inhoud van de Extension‑tag is een assembly‑gekwalificeerde naam van het type. (Zie <https://docs.microsoft.com/en-us/dotnet/api/system.type.assemblyqualifiedname>)

Herstart nu Reporting Services en exporteer het rapport. Je krijgt iets als [this presentation](attachments/10289195/10452997.pptx) van het Company Sales SQL2008R2‑rapport van de Adventureworks‑samples.