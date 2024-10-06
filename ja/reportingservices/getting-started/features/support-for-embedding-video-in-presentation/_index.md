---
title: プレゼンテーションにビデオを埋め込むためのサポート
type: docs
weight: 80
url: /ja/reportingservices/support-for-embedding-video-in-presentation/
---

{{% alert color="primary" %}} 

Microsoft SQL Server Reporting Services には、ビデオを埋め込んだレポートを PowerPoint プレゼンテーションにエクスポートするための組み込み機能がありません。Aspose.Slides for Reporting Services 4.10 以降のバージョンでは、プレゼンテーション内にビデオを埋め込むことをサポートしています。 

{{% /alert %}} 

スライドにビデオを埋め込むためには、レポートに次のテキストを含むテキストボックスを追加してください：

``` xml

 <asposeObject type="video" url="file://c:\MyVideos\intro.wmv" playMode="Auto" vlume="Loud" cover="file://c:\MyVideos\introCover.jpg"/>

```


これは SQL Server バージョン 2008 以降で機能します。この機能は PPTX エクスポートにのみ対応しています。