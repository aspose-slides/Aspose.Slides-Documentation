---
title: 支援在簡報中嵌入音訊
type: docs
weight: 90
url: /zh-hant/reportingservices/support-for-embedding-audio-in-presentation/
---
{{% alert color="primary" %}}

Microsoft SQL Server Reporting Services 沒有內建將含嵌入音訊的報表匯出為 PowerPoint 簡報的功能。 Aspose.Slides for Reporting Services 4.10 及之後的版本支援在匯出的簡報中嵌入音訊。

{{% /alert %}}

若要將音訊嵌入投影片，請在報表中放置一個文字方塊，內容為：

``` xml

 <asposeObject type="audio" url="file://c:\MyVideos\intro.wav" playMode="Auto" volume="Loud" cover="file://c:\MyVideos\introCover.jpg"/>

```

此功能適用於 SQL Server 2008 及以上版本。此功能僅在 PPTX 匯出時受支援。