---
title: Customization of Rendering Results by Extending Aspose.Slides for RS
type: docs
weight: 10
url: /reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/
---

{{% alert color="primary" %}} 

This page describes how to create extension for Aspose.Slides for RS.

- [Create an Extension Assembly](/slides/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs-html/).
- [Integrating the Extension](/slides/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs-html/).

{{% /alert %}} 

The Custom Extension feature gives you the option to add extra elements or update existing elements during report export.
### **How to Create an Extension Assembly**
1. Create a .NET project and add areference to Aspose.Slides.ReportingServices.dll.
1. Add a class and inherit it from Aspose.Slides.ReportingServices.Extension.RenderingExtensionBase.
1. Override the class' virtual methods to add custom functionality.
#### **Example**
Suppose we want to add a note with some text, a logo and update the company name for every report exported with Aspose.Slides for RS.

For that purpose we add the following class:

``` xml

 public class DemoRenderingExtension : Aspose.Slides.ReportingServices.Extension.RenderingExtensionBase

{

public override void PostProcessSlide(Aspose.Slides.ReportingServices.Extension.Slide slide)

{

//Add note to the first slide

if (this.CurrentSlideIndex == 0)

{

TextFormat textFormat = new TextFormat("Arial", 25);

textFormat.Bold = true;

slide.AddNote("This is the demo of Rendering Extension for Aspose.Slides for ReportingServices",

textFormat);

}

//Show logo on every slide in bottom right corner

using (Stream imageStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("TestSlidesRenderingExtension.aspose.slides-for-ssrs-logo.jpg"))

{

slide.AddImage(imageStream, new RectangleF(slide.Size.Width - 20, slide.Size.Height - 20, 15, 15));

}

base.PostProcessSlide(slide);

}


public override void PostProcessTextBox(Aspose.Slides.ReportingServices.Extension.TextBox textBox)

{

//Add (TM) to any mention of company name in report

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

Build it and you will get extension assembly. We are ready to integrate the extension.

{{% /alert %}} 

[Visual studio project of RenderingExtensionDemo.zip](attachments/10289195/10452998.zip)
#### **Integrating the Extension**
Suppose that your assembly is called **TestSlidesRenderingExtension.dll**:

- Copy the assembly to the ReportingService **bin** directory next to the Aspose.Slides.ReportingServices.dll. (For example: c:\Program Files\Microsoft SQL Server\MSRS10_50\Reporting Services\ReportServer\bin)
- Grant FullTrust permission to your assembly by adding the following CodeGroup to **rssrvpolicy.config**:

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

Update the Aspose.Slides rendering extension config sections of **rsreportserver.config** to include your extension.

``` xml

 <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices">

<Configuration>

<Extension>TestSlidesRenderingExtension.DemoRenderingExtension, TestSlidesRenderingExtension</Extension>

</Configuration>

</Extension>

```

If you want to use the extension for every output type supported by Aspose.Slides, add the same config to extensions with the names ASPPTX, ASPPT, ASPPS, ASPPSX.
The content of the Extension tag is an assembly-qualified name of the type. (See <http://msdn.microsoft.com/en-us/library/system.type.assemblyqualifiedname.aspx>)

Now restart Reporting Services and export the report. You get something like [this presentation](attachments/10289195/10452997.pptx) from the Company Sales SQL2008R2 report of the Adventureworks samples.
