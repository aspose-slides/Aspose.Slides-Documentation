---
title: 支持在演示文稿中嵌入视频
type: docs
weight: 80
url: /zh/reportingservices/support-for-embedding-video-in-presentation/
---

{{% alert color="primary" %}} 

Microsoft SQL Server Reporting Services 没有内置的能力将嵌入视频的报告导出到 PowerPoint 演示文稿中。从 Aspose.Slides for Reporting Services 4.10 版本开始支持在演示文稿中嵌入视频。 

{{% /alert %}} 

要在幻灯片中嵌入视频，请在报告中放置一个文本框，文本内容为：

``` xml

 <asposeObject type="video" url="file://c:\MyVideos\intro.wmv" playMode="Auto" vlume="Loud" cover="file://c:\MyVideos\introCover.jpg"/>

```


它适用于 2008 及更高版本的 SQL Server。该功能仅支持 PPTX 导出。