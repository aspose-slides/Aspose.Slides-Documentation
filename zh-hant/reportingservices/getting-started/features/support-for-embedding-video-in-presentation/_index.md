---
title: 支援在簡報中嵌入影片
type: docs
weight: 80
url: /zh-hant/reportingservices/support-for-embedding-video-in-presentation/
---
{{% alert color="primary" %}} 
Microsoft SQL Server Reporting Services 不具備內建的功能，可將含嵌入影片的報表匯出為 PowerPoint 簡報。 Aspose.Slides for Reporting Services 4.10 及之後的版本支援在簡報中嵌入影片。 
{{% /alert %}} 
若要將影片嵌入投影片，請在報表中加入包含以下文字的文字方塊： 
``` xml

 <asposeObject type="video" url="file://c:\MyVideos\intro.wmv" playMode="Auto" vlume="Loud" cover="file://c:\MyVideos\introCover.jpg"/>

```
此功能適用於 SQL Server 2008 版及更新版本。此功能僅支援 PPTX 匯出。