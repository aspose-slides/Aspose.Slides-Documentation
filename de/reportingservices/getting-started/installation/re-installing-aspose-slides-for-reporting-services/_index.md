---
title: Aspose.Slides für Reporting Services neu installieren
type: docs
weight: 40
url: /reportingservices/re-installing-aspose-slides-for-reporting-services/
---

{{% alert color="primary" %}} 

Dieser Artikel beschreibt die Lösung für eine Situation, in der Aspose.Slides für Reporting Services bereits installiert ist, aber aus irgendwelchem Grund neu installiert werden muss.

{{% /alert %}} 

{{% alert title="Hinweis" color="warning" %}} 

**Aspose.Slides für Reporting Services** erfordert die Installation von **.NET Framework 3.5** auf der Hostmaschine. 

{{% /alert %}}

## **Schritte zur Neuinstallation von Aspose.Slides für Reporting Services**
Das Wichtigste ist die vollständige Entfernung der vorherigen Installationen von Aspose.Slides für Reporting Services. Obwohl der MSI-Installer die erforderlichen Aktionen zum Deinstallieren und somit zur automatischen Neuinstallation von Aspose.Slides für Reporting Services erfolgreich ausführen kann, müssen folgende Schritte befolgt werden:

1. Deinstallieren Sie Aspose.Slides für Reporting Services mit dem MSI-Installer. 

2. Suchen Sie das Installationsverzeichnis von Aspose.Slides für Reporting Services, das sich normalerweise unter befindet:

   **OS Root Drive\Program Files\Aspose\Aspose.Slides für Reporting Services** 

3.  Wenn der MSI-Installer das Verzeichnis "Aspose.Slides für Reporting Services" nicht entfernt hat, als er Aspose.Slides für Reporting Services deinstallierte, löschen Sie den Ordner. 

4. Suchen Sie die **Aspose.Slides.ReportingServices.dll** Binary im Verzeichnis "bin" jeder Instanz von SQL Server Reporting Services. Zum Beispiel, wenn es eine Microsoft SQL Server 2008 Instanz “MSSQLSERVER” gibt, wird das entsprechende "bin"-Verzeichnis der Reporting Services wahrscheinlich unter sein:

   **OS Root Drive\Program Files\Microsoft SQL Server\MSRS10.MSSQLSERVER\Reporting Services\ReportServer\bin** 

5. Wenn der MSI-Installer die Aspose.Slides.ReportingServices.dll Binary-Datei aus dem obigen Verzeichnis nicht entfernt hat, als er Aspose.Slides für Reporting Services deinstallierte, löschen Sie die Datei jetzt.

6. Suchen Sie die **rsreportserver.config** Datei für jede SSRS-Instanz. Zum Beispiel, wenn es eine Reporting Service-Instanz “ **MSRS10.MSSQLSERVER** ” gibt, wird die **rsreportserver.config** Datei in diesem Verzeichnis sein:

   **MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

7. Öffnen Sie die **rsreportserver.config** Datei in einem beliebigen Editor und finden Sie die Zeilen, die erstellt wurden, um PowerPoint-Format-Erweiterungen während der Installation von Aspose.Slides für Reporting Services hinzuzufügen. 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

``` 

** Schritt ** **8:** Wenn der MSI-Installer diese Zeilen nicht entfernt hat, als er Aspose.Slides für Reporting Services deinstallierte, löschen Sie die Zeilen jetzt aus der **rsreportserver.config** Datei.

**Schritt** **9:** Suchen Sie die **rssrvpolicy.config** Datei für jede SSRS-Instanz. Zum Beispiel, wenn es eine Reporting Service-Instanz “ MSRS10.MSSQLSERVER ” gibt, wird die **rssrvpolicy.config** Datei in diesem Verzeichnis sein:

**MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

**Schritt** **10:** Öffnen Sie die **rssrvpolicy.config** Datei in einem beliebigen Editor und suchen Sie die Zeilen, die erstellt wurden, um Ausführungsberechtigungen für Aspose.Slides für Reporting Services während der Installation von Aspose.Slides für Reporting Services zu gewähren. 

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

        Description="Diese Code-Gruppe gewährt volles Vertrauen auf die AS4SSRS-DLL.">

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

**Schritt** **11:** Wenn der MSI-Installer die obigen Zeilen beim Deinstallieren des Produkts nicht entfernt hat, entfernen Sie diese Zeilen jetzt aus der **rssrvpolicy.config** Datei. 

**Schritt** **12:** Wenn Aspose.Slides für Reporting Services auch mit Microsoft Visual Studio für die Entwicklung von RDL-Berichten und den Export in PowerPoint-Formate innerhalb der Microsoft Visual Studio-Umgebung installiert wurde, sollten die Binary-Datei Aspose.Slides.ReportingServices.dll und die Konfigurationsdateien ( **rsreportserver.config** und **rssrvpolicy.config** ) im Fall von Microsoft Visual Studio 2008 sein: 

**OS Root Drive\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies** 

**Schritt** **13:** Wenn der MSI-Installer die **Aspose.Slides.ReportingServices.dll** Binary nicht entfernt hat, löschen Sie sie. Darüber hinaus, wenn er die **rsreportserver.config** und **rssrvpolicy.config** Dateien nicht aktualisiert hat, um PowerPoint-Format-Erweiterungen und Ausführungsberechtigungen respectively zu entfernen, müssen Sie sie manuell auf die gleiche Weise entfernen, wie Sie es mit den Dateien in den vorherigen Schritten getan haben. 

**Schritt** **14:** Es ist an der Zeit, Aspose.Slides für Reporting Services neu zu installieren. Verwenden Sie den MSI-Installer für die automatische Installation oder führen Sie es manuell durch.