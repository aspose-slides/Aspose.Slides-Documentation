---
title: Anpassung der Rendering-Ergebnisse durch Erweiterung von Aspose.Slides für RS
type: docs
weight: 10
url: /reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/
---

{{% alert color="primary" %}} 

Diese Seite beschreibt, wie man eine Erweiterung für Aspose.Slides für RS erstellt.

- [Eine Erweiterungsassembly erstellen](/slides/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/).
- [Die Erweiterung integrieren](/slides/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/).

{{% /alert %}} 

Die Funktion der benutzerdefinierten Erweiterung bietet Ihnen die Möglichkeit, während des Berichtsexports zusätzliche Elemente hinzuzufügen oder vorhandene Elemente zu aktualisieren.
## **Wie man eine Erweiterungsassembly erstellt**
1. Erstellen Sie ein .NET-Projekt und fügen Sie einen Verweis auf Aspose.Slides.ReportingServices.dll hinzu.
1. Fügen Sie eine Klasse hinzu und erben Sie von Aspose.Slides.ReportingServices.Extension.RenderingExtensionBase.
1. Überschreiben Sie die virtuellen Methoden der Klasse, um benutzerdefinierte Funktionalität hinzuzufügen.
### **Beispiel**
Angenommen, wir möchten eine Notiz mit etwas Text, einem Logo und den Firmennamen für jeden mit Aspose.Slides für RS exportierten Bericht hinzufügen.

Zu diesem Zweck fügen wir die folgende Klasse hinzu:

``` xml

 public class DemoRenderingExtension : Aspose.Slides.ReportingServices.Extension.RenderingExtensionBase

{

public override void PostProcessSlide(Aspose.Slides.ReportingServices.Extension.Slide slide)

{

//Fügen Sie der ersten Folie eine Notiz hinzu

if (this.CurrentSlideIndex == 0)

{

TextFormat textFormat = new TextFormat("Arial", 25);

textFormat.Bold = true;

slide.AddNote("Dies ist die Demo der Rendering-Erweiterung für Aspose.Slides für ReportingServices",

textFormat);

}

//Logo auf jeder Folie in der unteren rechten Ecke anzeigen

using (Stream imageStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("TestSlidesRenderingExtension.aspose.slides-for-ssrs-logo.jpg"))

{

slide.AddImage(imageStream, new RectangleF(slide.Size.Width - 20, slide.Size.Height - 20, 15, 15));

}

base.PostProcessSlide(slide);

}


public override void PostProcessTextBox(Aspose.Slides.ReportingServices.Extension.TextBox textBox)

{

//Fügen Sie (TM) zu jeder Erwähnung des Firmennamens im Bericht hinzu

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

Bauen Sie es und Sie erhalten die Erweiterungsassembly. Wir sind bereit, die Erweiterung zu integrieren.

{{% /alert %}} 

[Visual Studio-Projekt von RenderingExtensionDemo.zip](attachments/10289195/10452998.zip)
### **Die Erweiterung integrieren**
Angenommen, Ihre Assembly heißt **TestSlidesRenderingExtension.dll**:

- Kopieren Sie die Assembly in das **bin**-Verzeichnis von ReportingService neben Aspose.Slides.ReportingServices.dll. (Zum Beispiel: c:\Program Files\Microsoft SQL Server\MSRS10_50\Reporting Services\ReportServer\bin)
- Gewähren Sie Ihrer Assembly die Berechtigung FullTrust, indem Sie die folgende CodeGroup zu **rssrvpolicy.config** hinzufügen:

``` xml

 <CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Nothing">

<IMembershipCondition class="AllMembershipCondition" version="1" /> 

... 

<CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="Diese Codegruppe gewährt MyComputer-Code Ausführungsberechtigung.">

<IMembershipCondition class="ZoneMembershipCondition" version="1" Zone="MyComputer" /> 

... 

<CodeGroup class="UnionCodeGroup" version="1" PermissionSetName="FullTrust" Name="Aspose.Slides_Extension" Description="Diese Codegruppe gewährt Vollzugriff auf die Aspose.Slides für Reporting Services Rendering-Erweiterung.">

<IMembershipCondition	class="UrlMembershipCondition"	version="1" Url="c:\Program Files\Microsoft SQL Server\MSRS10_50\Reporting Services\ReportServer\bin\TestSlidesRenderingExtension.dll" />

</CodeGroup>

</CodeGroup>

</CodeGroup>

```

Aktualisieren Sie die Konfigurationsabschnitte der Aspose.Slides-Rendering-Erweiterung in **rsreportserver.config**, um Ihre Erweiterung einzuschließen.

``` xml

 <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices">

<Configuration>

<Extension>TestSlidesRenderingExtension.DemoRenderingExtension, TestSlidesRenderingExtension</Extension>

</Configuration>

</Extension>

```

Wenn Sie die Erweiterung für jeden von Aspose.Slides unterstützten Ausgabetyp verwenden möchten, fügen Sie die gleiche Konfiguration zu den Erweiterungen mit den Namen ASPPTX, ASPPT, ASPPS, ASPPSX hinzu.
Der Inhalt des Extension-Tags ist ein assembly-qualified Name des Typs. (Siehe <https://docs.microsoft.com/en-us/dotnet/api/system.type.assemblyqualifiedname>)

Jetzt starten Sie die Reporting Services neu und exportieren den Bericht. Sie erhalten etwas wie [diese Präsentation](attachments/10289195/10452997.pptx) aus dem Company Sales SQL2008R2-Bericht der Adventureworks-Beispiele.