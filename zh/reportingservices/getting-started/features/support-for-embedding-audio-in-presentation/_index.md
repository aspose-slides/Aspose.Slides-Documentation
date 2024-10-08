---  
title: 在演示文稿中嵌入音频的支持  
type: docs  
weight: 90  
url: /reportingservices/support-for-embedding-audio-in-presentation/  
---  

{{% alert color="primary" %}}  

Microsoft SQL Server Reporting Services 没有内置的能力将带有嵌入音频的报告导出到 PowerPoint 演示文稿中。从 4.10 版本开始，Aspose.Slides for Reporting Services 支持在导出的演示文稿中嵌入音频。  

{{% /alert %}}  

为了在幻灯片中嵌入音频，请在报告中添加一个文本框，文本内容为：  

``` xml  

 <asposeObject type="audio" url="file://c:\MyVideos\intro.wav" playMode="Auto" volume="Loud" cover="file://c:\MyVideos\introCover.jpg"/>  

```  

它适用于 SQL Server 2008 及更高版本。该功能仅支持 PPTX 导出。  