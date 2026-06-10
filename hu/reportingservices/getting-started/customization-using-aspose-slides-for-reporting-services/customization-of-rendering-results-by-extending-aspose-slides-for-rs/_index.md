---
title: Az Aspose.Slides for RS kiterjesztésével a renderelési eredmények testreszabása
type: docs
weight: 10
url: /hu/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/
---
{{% alert color="primary" %}} 
Ez az oldal leírja, hogyan lehet kiterjesztést létrehozni az Aspose.Slides for RS-hez.

- [Kiterjesztés-összeállítás létrehozása](/slides/hu/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/).
- [A kiterjesztés integrálása](/slides/hu/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/).

{{% /alert %}} 

Az Egyéni kiterjesztés funkció lehetővé teszi, hogy extra elemeket adjon hozzá vagy frissítse a meglévő elemeket a jelentés exportálása során.
## **Hogyan hozzunk létre egy kiterjesztés-összeállítást**
1. Hozzon létre egy .NET projektet, és adjon hozzá egy hivatkozást az Aspose.Slides.ReportingServices.dll-re.
1. Adjon hozzá egy osztályt, amely örökli az Aspose.Slides.ReportingServices.Extension.RenderingExtensionBase osztályt.
1. Üldözze felül az osztály virtuális metódusait a saját funkciók hozzáadásához.
### **Példa**
Tegyük fel, hogy egy megjegyzést szeretnénk hozzáadni szöveggel, egy logóval, és frissíteni a cég nevét minden, az Aspose.Slides for RS-sel exportált jelentésnél.

Ehhez a következő osztályt adjuk hozzá:

``` xml

 public class DemoRenderingExtension : Aspose.Slides.ReportingServices.Extension.RenderingExtensionBase

{

public override void PostProcessSlide(Aspose.Slides.ReportingServices.Extension.Slide slide)

{

//Adj megjegyzést az első diához

if (this.CurrentSlideIndex == 0)

{

TextFormat textFormat = new TextFormat("Arial", 25);

textFormat.Bold = true;

slide.AddNote("This is the demo of Rendering Extension for Aspose.Slides for ReportingServices",

textFormat);

}

//Mutassa a logót minden dián a jobb alsó sarokban

using (Stream imageStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("TestSlidesRenderingExtension.aspose.slides-for-ssrs-logo.jpg"))

{

slide.AddImage(imageStream, new RectangleF(slide.Size.Width - 20, slide.Size.Height - 20, 15, 15));

}

base.PostProcessSlide(slide);

}


public override void PostProcessTextBox(Aspose.Slides.ReportingServices.Extension.TextBox textBox)

{

//Adj (TM) jelzést a cég nevének minden előfordulásához a jelentésben

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
Építse fel, és megkapja a kiterjesztés-összeállítást. Készen állunk a kiterjesztés integrálására.
{{% /alert %}} 

[Visual studio projekt a RenderingExtensionDemo.zip-hez](attachments/10289195/10452998.zip)
### **A kiterjesztés integrálása**
Tegyük fel, hogy az összeállítása **TestSlidesRenderingExtension.dll** névre hallgat:

- Másolja az összeállítást a ReportingService **bin** könyvtárába, az Aspose.Slides.ReportingServices.dll mellett. (Például: c:\Program Files\Microsoft SQL Server\MSRS10_50\Reporting Services\ReportServer\bin)
- Adjon FullTrust jogosultságot az összeállításnak a következő CodeGroup hozzáadásával a **rssrvpolicy.config** fájlhoz:

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

Frissítse az Aspose.Slides renderelő kiterjesztés konfigurációs szakaszait a **rsreportserver.config** fájlban, hogy tartalmazza a kiterjesztést.

``` xml

 <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices">

<Configuration>

<Extension>TestSlidesRenderingExtension.DemoRenderingExtension, TestSlidesRenderingExtension</Extension>

</Configuration>

</Extension>

```

Ha a kiterjesztést az Aspose.Slides által támogatott minden kimenettípusnál használni szeretné, adja hozzá ugyanazt a konfigurációt az ASPPTX, ASPPT, ASPPS és ASPPSX nevű kiterjesztésekhez.
A Extension címke tartalma a típus assembly-qualified neve. (Lásd <https://docs.microsoft.com/en-us/dotnet/api/system.type.assemblyqualifiedname>)

Most indítsa újra a Reporting Services szolgáltatást, és exportálja a jelentést. Olyasmit kap, mint [ez a prezentáció](attachments/10289195/10452997.pptx) a Company Sales SQL2008R2 jelentésből az Adventureworks mintákból.