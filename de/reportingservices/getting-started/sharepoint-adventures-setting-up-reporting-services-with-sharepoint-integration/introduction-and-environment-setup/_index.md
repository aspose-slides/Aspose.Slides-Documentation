---  
title: Einführung und Umgebungssetup  
type: docs  
weight: 10  
url: /de/reportingservices/introduction-and-environment-setup/  
---  
  
{{% alert color="primary" %}}  
  
Es gab in der Vergangenheit Anfragen zur Integration von Aspose.Slides für Reporting Services mit SharePoint. In diesem Artikel werden wir uns auf SharePoint 2010 konzentrieren. Es wird vorausgesetzt, dass bereits eine SharePoint Farm-Umgebung eingerichtet wurde. Die Beispiele, denen wir in diesem Artikel folgen werden, sind eine vollständige SharePoint Cloud, aber die Schritte sind ähnlich für einen SharePoint Foundation Server. Bevor wir fortfahren, beginnen wir mit einigen wichtigen Dokumentationen, die Sie als Referenz verwenden können:  
  
- [Überblick über die Integration von Reporting Services und SharePoint-Technologie](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb326358(v=sql.105))  
- [Konfigurieren von Reporting Services für die Integration mit SharePoint 2010](https://docs.microsoft.com/en-us/previous-versions/sql/)  
  
{{% /alert %}}  
#### **Umgebungssetup**  
Die Konfiguration, die wir haben werden, besteht aus **4 Servern**. Dazu gehören ein **Domänencontroller**, ein **SQL-Server**, ein **SharePoint-Server** und ein Server für **Reporting Services**. Sie können sich entscheiden, SharePoint und Reporting Services auf demselben Rechner zu haben.  