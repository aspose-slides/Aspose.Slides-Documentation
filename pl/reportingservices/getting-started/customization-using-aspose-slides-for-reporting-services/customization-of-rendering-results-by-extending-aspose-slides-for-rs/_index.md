---
title: Dostosowywanie wyników renderowania poprzez rozszerzanie Aspose.Slides dla RS
type: docs
weight: 10
url: /pl/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/
---
{{% alert color="primary" %}}

Ta strona opisuje, jak stworzyć rozszerzenie dla Aspose.Slides for RS.

- [Utwórz zestaw rozszerzeń](/slides/pl/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/).
- [Integracja rozszerzenia](/slides/pl/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/).

{{% /alert %}}

Funkcja Custom Extension daje możliwość dodania dodatkowych elementów lub zaktualizowania istniejących elementów podczas eksportu raportu.
## **Jak utworzyć zestaw rozszerzeń**
1. Utwórz projekt .NET i dodaj odwołanie do Aspose.Slides.ReportingServices.dll.
1. Dodaj klasę i odziedzicz ją po Aspose.Slides.ReportingServices.Extension.RenderingExtensionBase.
1. Zastąp wirtualne metody klasy, aby dodać własną funkcjonalność.
### **Przykład**
Załóżmy, że chcemy dodać notatkę z tekstem, logo oraz zaktualizować nazwę firmy w każdym raporcie eksportowanym przy użyciu Aspose.Slides for RS.

W tym celu dodajemy następującą klasę:

``` xml

 public class DemoRenderingExtension : Aspose.Slides.ReportingServices.Extension.RenderingExtensionBase

{

public override void PostProcessSlide(Aspose.Slides.ReportingServices.Extension.Slide slide)

{

//Dodaj notatkę do pierwszego slajdu

if (this.CurrentSlideIndex == 0)

{

TextFormat textFormat = new TextFormat("Arial", 25);

textFormat.Bold = true;

slide.AddNote("This is the demo of Rendering Extension for Aspose.Slides for ReportingServices",

textFormat);

}

//Pokaż logo na każdym slajdzie w prawym dolnym rogu

using (Stream imageStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("TestSlidesRenderingExtension.aspose.slides-for-ssrs-logo.jpg"))

{

slide.AddImage(imageStream, new RectangleF(slide.Size.Width - 20, slide.Size.Height - 20, 15, 15));

}

base.PostProcessSlide(slide);

}


public override void PostProcessTextBox(Aspose.Slides.ReportingServices.Extension.TextBox textBox)

{

//Dodaj (TM) do każdego wystąpienia nazwy firmy w raporcie

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

Zbuduj ją, a otrzymasz zestaw rozszerzeń. Jesteśmy gotowi do integracji rozszerzenia.

{{% /alert %}}

[Projekt Visual Studio RenderingExtensionDemo.zip](attachments/10289195/10452998.zip)
### **Integracja rozszerzenia**
Załóżmy, że Twój zestaw nosi nazwę **TestSlidesRenderingExtension.dll**:

- Skopiuj zestaw do katalogu **bin** ReportingService obok Aspose.Slides.ReportingServices.dll. (Na przykład: c:\Program Files\Microsoft SQL Server\MSRS10_50\Reporting Services\ReportServer\bin)
- Przyznaj uprawnienie FullTrust swojemu zestawowi, dodając następującą grupę kodu do **rssrvpolicy.config**:

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

Zaktualizuj sekcje konfiguracji rozszerzenia renderowania Aspose.Slides w **rsreportserver.config**, aby uwzględnić Twoje rozszerzenie.

``` xml

 <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices">

<Configuration>

<Extension>TestSlidesRenderingExtension.DemoRenderingExtension, TestSlidesRenderingExtension</Extension>

</Configuration>

</Extension>

```

Jeśli chcesz używać rozszerzenia dla każdego typu wyjścia obsługiwanego przez Aspose.Slides, dodaj tę samą konfigurację do rozszerzeń o nazwach ASPPTX, ASPPT, ASPPS, ASPPSX.
Zawartość tagu Extension to nazwa typu w formacie assembly-qualified. (Zobacz <https://docs.microsoft.com/en-us/dotnet/api/system.type.assemblyqualifiedname>)

Teraz uruchom ponownie Reporting Services i wyeksportuj raport. Otrzymasz coś podobnego do [tej prezentacji](attachments/10289195/10452997.pptx) z raportu Company Sales SQL2008R2 próbek Adventureworks.