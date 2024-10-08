---
title: Manuelle Integration mit Visual Studio 2005 oder 2008 Berichtsdesigner
type: docs
weight: 50
url: /de/reportingservices/integrating-manually-with-visual-studio-2005-or-2008-report-designer/
---

{{% alert color="primary" %}} 

Dieser Artikel zeigt Ihnen, wie Sie Aspose.Slides für Reporting Services manuell mit Visual Studio integrieren. 

{{% /alert %}} 

{{% alert title="Hinweis" color="warning" %}} 

**Aspose.Slides für Reporting Services** erfordert die Installation von **.NET Framework 3.5** auf dem Host-System. 

{{% /alert %}}

## **Integration von Aspose.Slides für Reporting Services mit Visual Studio**
Wir empfehlen Ihnen, den MSI-Installer zu verwenden, um Aspose.Slides für Reporting Services zu installieren, da er alle erforderlichen Installationsaufgaben und Konfigurationsprozesse automatisch durchführt. Sollte die Installation mit dem MSI-Installer fehlschlagen, verwenden Sie bitte die Anleitung hier. 

Dieser Artikel zeigt Ihnen auch, wie Sie Aspose.Slides für Reporting Services auf einem Computer mit Business Intelligence Development Studio installieren. Dies ermöglicht es Ihnen, Berichte im Microsoft PowerPoint-Format zur Designzeit aus dem Microsoft Visual Studio 2005 oder 2008 Berichtsdesigner zu exportieren. 

1. Kopieren Sie Aspose.Slides.ReportingServices.dll in das Visual Studio-Verzeichnis.

   - Um sich mit dem Visual Studio 2005 Berichtsdesigner zu integrieren, kopieren Sie **Aspose.Slides.ReportingServices.dll** in das Verzeichnis **C:\Program Files\Microsoft Visual Studio 8\Common7\IDE\PrivateAssemblies**.
   - Um sich mit dem Visual Studio 2008 Berichtsdesigner zu integrieren, kopieren Sie **Aspose.Slides.ReportingServices.dll** in das Verzeichnis **C:\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies**.
2. Registrieren Sie Aspose.Slides für Reporting Services als Rendering-Erweiterung. 

3. Öffnen Sie **C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\RSReportDesigner.config** (wo <Version> „8“ für Visual Studio 2005 oder „9.0“ für Visual Studio 2008 ist) und fügen Sie diese Zeilen in das <Render>-Element ein: 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>



```

4. Geben Sie Aspose.Slides für Reporting Services die Berechtigung zum Ausführen. 
   1. Öffnen Sie **C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\RSPreviewPolicy.config** (wo <Version> „8“ für Visual Studio 2005 oder „9.0“ für Visual Studio 2008 ist).
   1. Fügen Sie diese Zeile als letzten Punkt im zweitäußersten <CodeGroup>-Element hinzu (das sollte <CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="Diese Codegruppe erlaubt meinem Computer die Ausführung von Code."> sein) 

**<CodeGroup>**

``` xml


...

  <CodeGroup>

    ...

    <!--Hier starten.-->

    <CodeGroup

        class="UnionCodeGroup"

        version="1"

        PermissionSetName="FullTrust"

        Name="Aspose.Slides_for_Reporting_Services"

        Description="Diese Codegruppe gewährt vollstes Vertrauen zur AS4SSRS-DLL.">

        <IMembershipCondition

            class="StrongNameMembershipCondition"

            version="1"

            PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001005542e

            99cecd28842dad186257b2c7b6ae9b5947e51e0b17b4ac6d8cecd3e01c4d20658c5e4ea1b9a6c8f854b2

            d796c4fde740dac65e834167758cff283eed1be5c9a812022b015a902e0b97d4e95569eb8c0971834744

            e633d9cb4c4a6d8eda03c12f486e13a1a0cb1aa101ad94943236384cbbf5c679944b994de9546e493bf" />

    </CodeGroup>

    <!--Hier enden.-->

  </CodeGroup>

</CodeGroup>


```

5. Überprüfen Sie, ob Aspose.Slides für Reporting Services erfolgreich installiert wurde. 
6. Führen Sie den Microsoft Visual Studio 2005 oder 2008 Berichtsdesigner aus oder starten Sie ihn neu. Sie sollten neue Formate in der Liste der Exportformate bemerken.

**Neue Exportformate erscheinen im Berichtsdesigner.** 

![todo:image_alt_text](integrating-manually-with-visual-studio-2005-or-2008-report-designer_1.png)