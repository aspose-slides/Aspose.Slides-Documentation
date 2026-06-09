---
title: Sunumda Ses Gömme Desteği
type: docs
weight: 90
url: /tr/reportingservices/support-for-embedding-audio-in-presentation/
---
{{% alert color="primary" %}} 
Microsoft SQL Server Reporting Services raporları, yerleşik sesli PowerPoint sunumlarına dışa aktarma yeteneğine sahip değildir. Aspose.Slides for Reporting Services 4.10 ve sonraki sürümler, dışa aktarılan sunum içinde ses eklemeyi destekler. 
{{% /alert %}} 
Sesin slaytlara yerleştirilmesi için, rapora aşağıdaki metni içeren bir metin kutusu ekleyin: 

``` xml

 <asposeObject type="audio" url="file://c:\MyVideos\intro.wav" playMode="Auto" volume="Loud" cover="file://c:\MyVideos\introCover.jpg"/>

```

Bu özellik SQL Server 2008 ve üzeri sürümler için çalışır. Özellik yalnızca PPTX dışa aktarımında desteklenir.