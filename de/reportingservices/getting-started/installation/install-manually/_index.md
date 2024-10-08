---
title: Manuelle Installation
type: docs
weight: 30
url: /de/reportingservices/install-manually/
---

{{% alert color="primary" %}} 

Folge diesen Schritten nur, wenn du planst, Aspose.Slides für Reporting Services manuell zu installieren. In diesem Fall hast du das ZIP-Paket mit den Assemblierungsdateien heruntergeladen. 

{{% /alert %}} 

{{% alert title="Hinweis" color="warning" %}} 

**Aspose.Slides für Reporting Services** erfordert die Installation von **.NET Framework 3.5** auf der Host-Maschine. 

{{% /alert %}}

### **Manuelle Installation**
Diese Anweisungen zeigen dir, wie du Dateien im Verzeichnis, in dem Microsoft SQL Server Reporting Services installiert ist, kopieren und ändern kannst:

1. Finde das Installationsverzeichnis des Berichtservers.
   Das Stammverzeichnis für Microsoft SQL Server befindet sich normalerweise hier: ***C:\Program Files\Microsoft SQL Server***
   
   {{% alert color="primary" %}} 
   
   **Microsoft SQL Server 2005 und 2008**: Es könnte mehrere konfigurierte Microsoft SQL Server Instanzen auf der Maschine geben, die verschiedene MSSQL.x Unterverzeichnisse wie MSSQL.1, MSSQL.2 usw. belegen. Du musst das korrekte ***C:\Program Files\Microsoft SQL Server\MSSQL.x\Reporting Services\ReportServer*** Verzeichnis finden, bevor du mit dem nächsten Schritt fortfährst.
   
   {{% /alert %}} Alle unten verwendeten Pfade beziehen sich auf dieses Verzeichnis als <Instance>. 

2. Kopiere Aspose.Slides.ReportingServices.dll in den **C:\Program Files\Microsoft SQL Server\xxx\Reporting Services\ReportServer\bin** Ordner.
   Der **Aspose.Slides.ReportingServices.zip** Download enthält die **Aspose.Slides.ReportingServices.dll**. {{% alert color="primary" %}} 

In einigen Fällen, wenn du die DLL in das **ReportServer\bin** Verzeichnis kopierst, könnte sie zusammen mit den ausdrücklich zugewiesenen NTFS-Dateiberechtigungen kopiert werden. Die NTFS-Berechtigungen führen dazu, dass Microsoft SQL Server Reporting Services der Zugriff verweigert wird, wenn **Aspose.Slides.ReportingServices.dll** geladen wird. Wenn dies passiert, werden die neuen Exportformate nicht verfügbar. Überprüfe und bestätige, dass die richtigen NTFS-Berechtigungen vorhanden sind:

   1. Klicke mit der rechten Maustaste auf **Aspose.Slides.ReportingServices.dll**.
   1. Klicke auf **Eigenschaften** und wähle den Tab **Sicherheit**.
   1. Entferne alle explizit zugewiesenen NTFS-Berechtigungen und lasse nur vererbte Berechtigungen.

{{% /alert %}}

3. Registriere Aspose.Slides für Reporting Services als Rendering-Erweiterung: 
   1. Öffne *C:\Program
      Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rsreportserver.config*.
   1. Füge diese Zeilen zum <Render>-Element hinzu: 

**<Render>**

``` xml

   ...

  <!--Hier starten.-->

  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

  <!--Hier enden.-->

</Render>

``` 

4. Erteile Aspose.Slides für Reporting Services Berechtigungen zur Ausführung: 
   1. Öffne **C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rssrvpolicy.config**.
   1. Füge das Folgende als letzten Eintrag im zweitäußeren <CodeGroup>-Element hinzu (welches <CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="Diese Code-Gruppe gewährt MyComputer Code Ausführungsberechtigungen. "> sein sollte). 

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

        Description="Diese Code-Gruppe gewährt volles Vertrauen zur AS4SSRS Assembly.">

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

5. Überprüfe, ob Aspose.Slides für Reporting Services erfolgreich installiert wurde: 
   1. Öffne den Bericht-Manager und überprüfe die Liste der verfügbaren Exporttypen für einen Bericht. 

      {{% alert color="primary" %}} Du kannst den Bericht-Manager starten, indem du einen Browser (Microsoft Internet Explorer 6.0 oder höher) öffnest und die URL des Bericht-Managers in die Adresszeile eingibst (standardmäßig ist es http://<ComputerName>/Reports). 
   
      {{% /alert %}}

1. Wähle einen Bericht auf dem Server aus.
1. Öffne die Liste **Format auswählen**.
   Du solltest eine Liste der von Aspose.Slides für Reporting Services bereitgestellten Exportformate sehen. 
1. Wähle **PPT – PowerPoint-Präsentation über Aspose.Slides**. 

   **Aspose.Slides für Reporting Services erfolgreich installiert und neue Exportformate verfügbar.** 

![todo:image_alt_text](install-manually_1.png)

6. Klicke auf den **Exportieren**-Link.
   Der Bericht wird im gewählten Format generiert, an den Client gesendet und anschließend in einer geeigneten Anwendung geöffnet. In unserem Fall wurde der Bericht in Microsoft PowerPoint geöffnet. 

   **Ein PPT-Bericht, der von Aspose.Slides für Reporting Services generiert wurde.** 

![todo:image_alt_text](install-manually_2.png)

Du hast Aspose.Slides für Reporting Services erfolgreich installiert und einen Bericht als Microsoft PowerPoint-Präsentation generiert! 