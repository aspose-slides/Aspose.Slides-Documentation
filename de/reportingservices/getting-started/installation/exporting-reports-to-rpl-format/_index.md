---  
title: Berichte im RPL-Format exportieren  
type: docs  
weight: 110  
url: /reportingservices/exporting-reports-to-rpl-format/  
---  

﻿  

{{% alert color="primary" %}}  

Aspose.Slides verwendet Berichte im RPL (Report Processing Language)-Format zur Darstellung. Diese Seite zeigt, wie man Berichte im RPL-Format exportiert.  

{{% /alert %}}  

In vielen Szenarien müssen Kunden die Berichte, die Probleme zur Behebung enthalten, mit dem Aspose-Team teilen. Wenn die geteilten Berichte im RDL-Format vorliegen, wird auch der Datensatz oder das Schema geteilt, um uns zu ermöglichen, das Problem zu reproduzieren. Manchmal reicht es nicht aus, den RDL-Bericht zusammen mit dem Datensatz zu teilen, um das Problem vollständig zu lösen. In solchen Fällen empfehlen wir, die Berichte im RPL-Format zu exportieren und die RPL-Datei für die Berichterstattung mit uns zu teilen. Die RPL-Datei enthält auch den verwendeten Datensatz. Auf diese Weise wird der Export nach RPL einfacher, und sie kann sofort mit uns geteilt werden.  

Führen Sie die folgenden Schritte aus:  

1. Kopiere Aspose.ReportingServices.Debug.Rpl.dll in das Bin-Verzeichnis der Reporting-Services (normalerweise unter c:\Program Files\Microsoft SQL Server\MSRS10_50.SQL2008R2\Reporting Services\ReportServer\bin).  

{{% alert color="primary" %}}  

Aspose.ReportingServices.Debug.Rpl.dll ist in den neuesten Versionen von Aspose.Slides für Reporting Services erhältlich, die von der [Releases-Seite](https://releases.aspose.com/slides/reportingservices/) heruntergeladen werden kann.  

{{% /alert %}}  

2. Fügen Sie diese Erweiterung zum **<Render>**-Tag der **rsreportserver.config**-Datei hinzu (normalerweise unter c:\Program Files\Microsoft SQL Server\MSRS10_50.SQL2008R2\Reporting Services\ReportServer\rsreportserver.config)  

``` xml  

//Fügen Sie dieses Tag zum <Render>-Element hinzu  

<Extension Name="ASRPLDEBUG" Type="Aspose.Slides.ReportingServices.DebugRplRenderer,Aspose.ReportingServices.Debug.Rpl" >  
</Extension>  

```  

3. Geben Sie den Pfad zu den resultierenden RPL-Dateien an, indem Sie das Path-Element ändern.  

4. Gewähren Sie Aspose.ReportingServices.Debug.Rpl.dll die Berechtigungen, indem Sie C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rssrvpolicy.config öffnen und dies als letzten Punkt im zweitäußeren **<CodeGroup>**-Element hinzufügen (das sollte **<CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="Diese Code-Gruppe gewährt MyComputer Code-Ausführungsberechtigungen. ">** sein):  

``` xml  

<CodeGroup>  
...  
<CodeGroup>  
...  
<!--Hier starten.-->  
<CodeGroup class="UnionCodeGroup"  
version="1"  
PermissionSetName="FullTrust"  
Name="Aspose.Rpl_Debug_for_Reporting_Services"  
Description="Code-Gruppe für meine Aspose.Rpl.Debug-Rendering-Erweiterung">  
<IMembershipCondition class="StrongNameMembershipCondition" version="1" PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001006b80fcda1455ae4cf3919835348890372b899f004785c4254480f2278db2867313aedbf0224038beff12cb44da0493dcfadaef543dce262358ae3f6e383bfd9466d1b59828a5c1ff4097ec0ef4a087bd7090c2a0de710ffa2d2f045e0626f40a32d63c9bde1fc9538d478a1caac9155563a103b275e646a728e711057308dbe3" />  
</CodeGroup>  
<!--Hier enden.-->  
</CodeGroup>  
</CodeGroup>  

```  

5. Starten Sie die Reporting-Services neu. Sie sollten die Option Aspose.Rpl im Exportmenü finden.  

Die Option "Rpl-Export" sollte im Exportfenster erscheinen. Sie müssen den Bericht im RPL-Format exportieren und die RPL-Datei teilen.  