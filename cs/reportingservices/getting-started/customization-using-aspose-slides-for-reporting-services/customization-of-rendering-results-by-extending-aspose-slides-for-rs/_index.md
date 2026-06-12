---
title: Přizpůsobení výsledků vykreslování rozšířením Aspose.Slides pro RS
type: docs
weight: 10
url: /cs/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/
---
{{% alert color="primary" %}} 

Tato stránka popisuje, jak vytvořit rozšíření pro Aspose.Slides pro RS.

- [Vytvořit sestavu rozšíření](/slides/cs/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/).
- [Integrace rozšíření](/slides/cs/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/).

{{% /alert %}} 

Funkce Vlastní rozšíření vám dává možnost přidat další prvky nebo aktualizovat existující prvky během exportu reportu.
## **Jak vytvořit sestavu rozšíření**
1. Vytvořte projekt .NET a přidejte odkaz na Aspose.Slides.ReportingServices.dll.
1. Přidejte třídu a zdědte ji z Aspose.Slides.ReportingServices.Extension.RenderingExtensionBase.
1. Přepište virtuální metody třídy, abyste přidali vlastní funkčnost.
### **Příklad**
Předpokládejme, že chceme přidat poznámku s nějakým textem, logo a aktualizovat název společnosti pro každý report exportovaný pomocí Aspose.Slides pro RS.

Za tímto účelem přidáme následující třídu:

``` xml

 public class DemoRenderingExtension : Aspose.Slides.ReportingServices.Extension.RenderingExtensionBase

{

public override void PostProcessSlide(Aspose.Slides.ReportingServices.Extension.Slide slide)

{

//Přidejte poznámku na první snímek

if (this.CurrentSlideIndex == 0)

{

TextFormat textFormat = new TextFormat("Arial", 25);

textFormat.Bold = true;

slide.AddNote("This is the demo of Rendering Extension for Aspose.Slides for ReportingServices",

textFormat);

}

//Zobrazte logo na každém snímku v pravém dolním rohu

using (Stream imageStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("TestSlidesRenderingExtension.aspose.slides-for-ssrs-logo.jpg"))

{

slide.AddImage(imageStream, new RectangleF(slide.Size.Width - 20, slide.Size.Height - 20, 15, 15));

}

base.PostProcessSlide(slide);

}


public override void PostProcessTextBox(Aspose.Slides.ReportingServices.Extension.TextBox textBox)

{

//Přidejte (TM) k jakémukoli výskytu názvu společnosti v reportu

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

Sestavte jej a získáte sestavu rozšíření. Jsme připraveni integrovat rozšíření.

{{% /alert %}} 

[Projekt Visual Studio RenderingExtensionDemo.zip](attachments/10289195/10452998.zip)
### **Integrace rozšíření**
Předpokládejme, že vaše sestava se jmenuje **TestSlidesRenderingExtension.dll**:

- Zkopírujte sestavu do adresáře **bin** Reporting Services vedle Aspose.Slides.ReportingServices.dll. (Například: c:\Program Files\Microsoft SQL Server\MSRS10_50\Reporting Services\ReportServer\bin)
- Udělte sestavě oprávnění FullTrust přidáním následující CodeGroup do **rssrvpolicy.config**:

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

Aktualizujte konfigurační sekce rozšíření vykreslování Aspose.Slides v **rsreportserver.config**, aby zahrnovaly vaše rozšíření.

``` xml

 <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices">

<Configuration>

<Extension>TestSlidesRenderingExtension.DemoRenderingExtension, TestSlidesRenderingExtension</Extension>

</Configuration>

</Extension>

```

Pokud chcete použít rozšíření pro každý typ výstupu podporovaný Aspose.Slides, přidejte stejnou konfiguraci do rozšíření s názvy ASPPTX, ASPPT, ASPPS, ASPPSX.
Obsah značky Extension je název typu s úplným názvem sestavy. (Viz <https://docs.microsoft.com/en-us/dotnet/api/system.type.assemblyqualifiedname>)

Nyní restartujte Reporting Services a exportujte report. Získáte něco jako [tuto prezentaci](attachments/10289195/10452997.pptx) z reportu Company Sales SQL2008R2 ze vzorků Adventureworks.