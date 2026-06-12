---
title: Personalizzazione dei risultati di rendering estendendo Aspose.Slides per RS
type: docs
weight: 10
url: /it/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/
---
{{% alert color="primary" %}} 

Questa pagina descrive come creare un'estensione per Aspose.Slides per RS.

- [Crea un Assembly di estensione](/slides/it/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/).
- [Integrare l'estensione](/slides/it/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/).

{{% /alert %}} 

La funzionalità di Estensione Personalizzata ti consente di aggiungere elementi extra o aggiornare gli elementi esistenti durante l'esportazione del report.
## **Come creare un Assembly di estensione**
1. Crea un progetto .NET e aggiungi un riferimento a Aspose.Slides.ReportingServices.dll.
2. Aggiungi una classe e falle ereditare da Aspose.Slides.ReportingServices.Extension.RenderingExtensionBase.
3. Sovrascrivi i metodi virtuali della classe per aggiungere funzionalità personalizzate.
### **Esempio**
Supponiamo di voler aggiungere una nota con del testo, un logo e aggiornare il nome dell'azienda per ogni report esportato con Aspose.Slides per RS.

A tale scopo aggiungiamo la seguente classe:

``` xml

 public class DemoRenderingExtension : Aspose.Slides.ReportingServices.Extension.RenderingExtensionBase

{

public override void PostProcessSlide(Aspose.Slides.ReportingServices.Extension.Slide slide)

{

//Aggiungi nota alla prima diapositiva

if (this.CurrentSlideIndex == 0)

{

TextFormat textFormat = new TextFormat("Arial", 25);

textFormat.Bold = true;

slide.AddNote("This is the demo of Rendering Extension for Aspose.Slides for ReportingServices",

textFormat);

}

//Mostra logo su ogni diapositiva nell'angolo in basso a destra

using (Stream imageStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("TestSlidesRenderingExtension.aspose.slides-for-ssrs-logo.jpg"))

{

slide.AddImage(imageStream, new RectangleF(slide.Size.Width - 20, slide.Size.Height - 20, 15, 15));

}

base.PostProcessSlide(slide);

}


public override void PostProcessTextBox(Aspose.Slides.ReportingServices.Extension.TextBox textBox)

{

//Aggiungi (TM) a ogni occorrenza del nome dell'azienda nel report

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

Compila e otterrai l'assembly dell'estensione. Siamo pronti per integrare l'estensione.

{{% /alert %}} 

[Progetto Visual Studio di RenderingExtensionDemo.zip](attachments/10289195/10452998.zip)
### **Integrare l'estensione**
Supponiamo che il tuo assembly si chiami **TestSlidesRenderingExtension.dll**:

- Copia l'assembly nella directory **bin** di ReportingService accanto a Aspose.Slides.ReportingServices.dll. (Ad esempio: c:\Program Files\Microsoft SQL Server\MSRS10_50\Reporting Services\ReportServer\bin)
- Concedi il permesso FullTrust al tuo assembly aggiungendo il seguente CodeGroup a **rssrvpolicy.config**:

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

Aggiorna le sezioni di configurazione dell'estensione di rendering Aspose.Slides in **rsreportserver.config** per includere la tua estensione.

``` xml

 <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices">

<Configuration>

<Extension>TestSlidesRenderingExtension.DemoRenderingExtension, TestSlidesRenderingExtension</Extension>

</Configuration>

</Extension>

```

Se desideri utilizzare l'estensione per ogni tipo di output supportato da Aspose.Slides, aggiungi la stessa configurazione alle estensioni con i nomi ASPPTX, ASPPT, ASPPS, ASPPSX.
Il contenuto del tag Extension è un nome completo dell'assembly del tipo. (Vedi <https://docs.microsoft.com/en-us/dotnet/api/system.type.assemblyqualifiedname>)

Ora riavvia Reporting Services ed esporta il report. Otterrai qualcosa di simile a [questa presentazione](attachments/10289195/10452997.pptx) dal report Company Sales SQL2008R2 dei campioni Adventureworks.