---
title: Support for Embedding Video in Presentation
type: docs
weight: 80
url: /reportingservices/support-for-embedding-video-in-presentation/
---

{{% alert color="primary" %}} 

Microsoft SQL Server Reporting Services does not have built-in abilities to export reports with embedded video to PowerPoint presentations. Aspose.Slides for Reporting Services 4.10 and onward versions support embedding video inside presentation. 

{{% /alert %}} 

In order to embed video to slides please put to the report a text box with text: 

{{< highlight java >}}

 <asposeObject type="video" url="file://c:\MyVideos\intro.wmv" playMode="Auto" vlume="Loud" cover="file://c:\MyVideos\introCover.jpg"/>

{{< /highlight >}}


It works for SQL Server version 2008 and more. The feature is supported only for PPTX export. 
