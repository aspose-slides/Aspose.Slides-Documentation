---
title: プレゼンテーションに音声を埋め込むサポート
type: docs
weight: 90
url: /ja/reportingservices/support-for-embedding-audio-in-presentation/
---

{{% alert color="primary" %}} 

Microsoft SQL Server Reporting Servicesには、埋め込まれた音声付きのレポートをPowerPointプレゼンテーションにエクスポートするための組み込み機能はありません。Aspose.Slides for Reporting Services 4.10以降のバージョンは、エクスポートされたプレゼンテーション内に音声を埋め込むことをサポートしています。 

{{% /alert %}} 

スライドに音声を埋め込むには、レポートに次のテキストボックスを追加してください: 

``` xml

 <asposeObject type="audio" url="file://c:\MyVideos\intro.wav" playMode="Auto" volume="Loud" cover="file://c:\MyVideos\introCover.jpg"/>

```


SQL Server 2008以降のバージョンで動作します。この機能はPPTXエクスポートのみに対応しています。