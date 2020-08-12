---
title: Support for Embedding Audio in Presentation
type: docs
weight: 90
url: /reportingservices/support-for-embedding-audio-in-presentation/
---

{{% alert color="primary" %}} 

Microsoft SQL Server Reporting Services does not have built-in abilities to export reports with embedded audio to PowerPoint presentations. Aspose.Slides for Reporting Services 4.10 and onward versions support embedding audio inside exported presentation. 

{{% /alert %}} 

In order to embed audio to slides please put to the report a text box with text: 

```

 <asposeObject type="audio" url="file://c:\MyVideos\intro.wav" playMode="Auto" volume="Loud" cover="file://c:\MyVideos\introCover.jpg"/>

```


It works for SQL Server version 2008 and more. The feature is supported only for PPTX export. 
