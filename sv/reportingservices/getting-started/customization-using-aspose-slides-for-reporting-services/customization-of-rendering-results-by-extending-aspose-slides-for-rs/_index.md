---
title: Anpassning av renderingsresultat genom att utöka Aspose.Slides för RS
type: docs
weight: 10
url: /sv/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/
---
{{% alert color="primary" %}}

Den här sidan beskriver hur man skapar en extension för Aspose.Slides för RS.

- [Skapa en extensionsassembly](/slides/sv/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/).
- [Integrera extensionen](/slides/sv/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/).

{{% /alert %}}

Funktionen Custom Extension ger dig möjlighet att lägga till extra element eller uppdatera befintliga element under rapportexport.
## **Hur man skapar en extensionsassembly**
1. Skapa ett .NET‑projekt och lägg till en referens till Aspose.Slides.ReportingServices.dll.
1. Lägg till en klass och ärva den från Aspose.Slides.ReportingServices.Extension.RenderingExtensionBase.
1. Åsidosätt klassens virtuella metoder för att lägga till anpassad funktionalitet.
### **Exempel**
Anta att vi vill lägga till en anteckning med någon text, en logotyp och uppdatera företagsnamnet för varje rapport som exporteras med Aspose.Slides för RS.

För det ändamålet lägger vi till följande klass:

``` xml

 public class DemoRenderingExtension : Aspose.Slides.ReportingServices.Extension.RenderingExtensionBase

{

public override void PostProcessSlide(Aspose.Slides.ReportingServices.Extension.Slide slide)

{

//Lägg till anteckning på den första bilden

if (this.CurrentSlideIndex == 0)

{

TextFormat textFormat = new TextFormat("Arial", 25);

textFormat.Bold = true;

slide.AddNote("This is the demo of Rendering Extension for Aspose.Slides for ReportingServices",

textFormat);

}

//Visa logotyp på varje bild i nedre högra hörnet

using (Stream imageStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("TestSlidesRenderingExtension.aspose.slides-for-ssrs-logo.jpg"))

{

slide.AddImage(imageStream, new RectangleF(slide.Size.Width - 20, slide.Size.Height - 20, 15, 15));

}

base.PostProcessSlide(slide);

}


public override void PostProcessTextBox(Aspose.Slides.ReportingServices.Extension.TextBox textBox)

{

//Lägg till (TM) vid varje förekomst av företagsnamnet i rapporten

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

Bygg den så får du en extensionsassembly. Vi är redo att integrera extensionen.

{{% /alert %}}

[Visual studio‑projektet RenderingExtensionDemo.zip](attachments/10289195/10452998.zip)
### **Integrera extensionen**
Anta att din assembly heter **TestSlidesRenderingExtension.dll**:

- Kopiera assemblyn till ReportingService **bin**‑katalogen bredvid Aspose.Slides.ReportingServices.dll. (Till exempel: c:\Program Files\Microsoft SQL Server\MSRS10_50\Reporting Services\ReportServer\bin)
- Ge FullTrust‑behörighet till din assembly genom att lägga till följande CodeGroup i **rssrvpolicy.config**:

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

Uppdatera konfigurationssektionerna för Aspose.Slides rendering‑extension i **rsreportserver.config** för att inkludera din extension.

``` xml

 <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices">

<Configuration>

<Extension>TestSlidesRenderingExtension.DemoRenderingExtension, TestSlidesRenderingExtension</Extension>

</Configuration>

</Extension>

```

Om du vill använda extensionen för varje output‑typ som stöds av Aspose.Slides, lägg till samma konfiguration till extensioner med namnen ASPPTX, ASPPT, ASPPS, ASPPSX.
Innehållet i Extension‑taggen är ett assembly‑kvalificerat namn för typen. (Se <https://docs.microsoft.com/en-us/dotnet/api/system.type.assemblyqualifiedname>)

Starta om Reporting Services och exportera rapporten. Du får något liknande [denna presentation](attachments/10289195/10452997.pptx) från Company Sales SQL2008R2‑rapporten i Adventureworks‑exemplen.