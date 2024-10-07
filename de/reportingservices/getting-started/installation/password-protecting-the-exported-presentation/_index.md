---
title: Passwortschutz für die exportierte Präsentation
type: docs
weight: 90
url: /reportingservices/password-protecting-the-exported-presentation/
---

{{% alert color="primary" %}} 

Das Passwortschützen einer Präsentation verhindert unbefugte Nutzung und Zugriff. Der Passwortschutz ist nützlich, wenn Sie Berichte erstellen, die sensible Daten oder Details enthalten, die nur einige Personen in Ihrer Organisation sehen sollten.

Dieser Artikel zeigt Ihnen, wie Sie Ihre Reporting Services- oder Visual Studio-Umgebung aktualisieren, um Präsentationen mit Passwortschutz zu speichern.

{{% /alert %}} 
## **Hinzufügen von Passwortschutz für exportierte Präsentationen in einer Reporting Services-Umgebung**
Um die Änderungen hier anzuwenden, müssen Sie Dateien im Verzeichnis ändern, in dem Microsoft SQL Server Reporting Services installiert ist.
### **Schritt 1. Suchen Sie das Verzeichnis der Reporting Server-Installation.**
Das Stammverzeichnis für Microsoft SQL Server befindet sich normalerweise unter C:\Program Files\Microsoft SQL Server.

{{% alert color="primary" %}} 

Für x64-Bit-Systeme ist die x86-Instanz von SQL Server unter C:\Program Files (x86)\Microsoft SQL Server\ installiert.

{{% /alert %}} 

Microsoft SQL Server 2005 und 2008: Es können mehrere Instanzen von Microsoft SQL Server auf dem Computer konfiguriert sein. Jede belegt ein anderes MSSQL.x-Unterverzeichnis, z. B. MSSQL.1, MSSQL.2 usw. Finden Sie das richtige C:\Program Files\Microsoft SQL Server\MSSQL.x\Reporting Services\ReportServer-Verzeichnis, bevor Sie mit den folgenden Schritten fortfahren.

Alle unten verwendeten Pfade beziehen sich auf das Installationsverzeichnis von Microsoft SQL Server Reporting Services als <Instance>.
### **Schritt 2. Fügen Sie den Code zum Hinzufügen von Passwörtern zu exportierten Präsentationen hinzu**
Ersetzen Sie die vorhandenen Aspose.Slides für Reporting Services Rendering-Extensions in der **rsreportserver.config**-Datei. Öffnen Sie dazu die C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rsreportserver.config-Datei.

Suchen Sie die direkt darunter aufgeführten Rendering-Optionen und ersetzen Sie diese durch den Code im folgenden Abschnitt.
#### **Finden Sie Aspose.Slides für Reporting Service Rendering-Optionen**
**<Render>**

``` xml

   ...

  <!--Hier beginnen.-->


  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

<!--Hier enden.-->

</Render>

```
#### **Ersetzungscode**
**<Render>**

``` xml

   ...

  <!--Hier beginnen.-->


  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >

  <Configuration>				 		

	<Password>111</Password>

  </Configuration>			



 </Extension>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >

  <Configuration>				 		

	<Password>111</Password>

  </Configuration>			



 </Extension>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >

  <Configuration>				 		

	<Password>111</Password>

  </Configuration>			



 </Extension>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >

  <Configuration>				 		

	<Password>111</Password>

  </Configuration>			



 </Extension>

  <!--Hier enden.-->

</Render>

```
### **Hinzufügen von Passwortschutz für exportierte Präsentationen in Visual Studio**
Um die Änderungen hier anzuwenden, müssen Sie die Datei ändern, in der der Microsoft Visual Studio Report Designer installiert ist.
### **Schritt 1. Öffnen Sie das Visual Studio-Verzeichnis.**
- Um mit dem Visual Studio 2005 Report Designer zu integrieren, öffnen Sie das Verzeichnis C:\Program Files\Microsoft Visual Studio 8\Common7\IDE\PrivateAssemblies.
- Um mit dem Visual Studio 2008 Report Designer zu integrieren, öffnen Sie das Verzeichnis C:\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies.
### **Schritt 2. Fügen Sie den Code zum Hinzufügen von Passwörtern zu exportierten Präsentationen hinzu.**
Ersetzen Sie die vorhandenen Aspose.Slides für Reporting Services Rendering-Extensions in der **rsreportserver.config**-Datei. Öffnen Sie dazu die C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\ RSReportDesigner.config-Datei (wobei **<Version>** “8” für Visual Studio 2005 oder “9.0” für Visual Studio 2008 ist) und fügen Sie diese Zeilen im **<Render>**-Element hinzu. Ersetzen Sie sie dann durch den Code im nächsten Codeabschnitt.
#### **Finden Sie Aspose.Slides für Reporting Service Rendering-Optionen**
**<Render>**

``` xml

   ...

  <!--Hier beginnen.-->


  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

<!--Hier enden.-->

</Render>

```
#### **Ersetzungscode**
**<Render>**

``` xml

   ...

  <!--Hier beginnen.-->


  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >

  <Configuration>				 		

	<Password>111</Password>

  </Configuration>			



 </Extension>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >

  <Configuration>				 		

	<Password>111</Password>

  </Configuration>			



 </Extension>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >

  <Configuration>				 		

	<Password>111</Password>

  </Configuration>			



 </Extension>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >

  <Configuration>				 		

	<Password>111</Password>

  </Configuration>			



 </Extension>

  <!--Hier enden.-->

</Render>

```