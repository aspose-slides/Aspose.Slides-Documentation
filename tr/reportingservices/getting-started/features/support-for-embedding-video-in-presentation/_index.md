---
title: Sunumda Video Gömme Desteği
type: docs
weight: 80
url: /tr/reportingservices/support-for-embedding-video-in-presentation/
---
{{% alert color="primary" %}} 

Microsoft SQL Server Reporting Services, gömülü video içeren raporları PowerPoint sunumlarına dışa aktarma konusunda yerleşik yeteneklere sahip değildir. Aspose.Slides for Reporting Services 4.10 ve sonraki sürümler, sunum içinde video yerleştirmeyi destekler. 

{{% /alert %}} 

Videoyu slaytlara yerleştirmek için rapora şu metni içeren bir metin kutusu ekleyin: 

``` xml

 <asposeObject type="video" url="file://c:\MyVideos\intro.wmv" playMode="Auto" vlume="Loud" cover="file://c:\MyVideos\introCover.jpg"/>

```


SQL Server 2008 ve üzeri sürümler için çalışır. Bu özellik yalnızca PPTX dışa aktarımını destekler.