---
title: デモのセットアップ
type: docs
weight: 70
url: /jasperreports/demos-setup/
---


Aspose.Slides for JasperReportsに付属しているすべてのデモは、標準的なデモが変更されたものです。すべてのデモをJasperReportsのデモフォルダーにコピーすることをお勧めします：
...\jasperreports-x.x.x\demo\samples\

レポートを構築してエクスポートするために、標準のコマンドシーケンスを使用します：

- ant javac
- ant compile
- ant fill
- ant ppt

{{% alert color="primary" %}} 

レポートにデータを埋め込むために、テストデータベースでHSQLDBを実行するのを忘れないでください。そして、aspose-slides-xx.x-jasperreports.zipの\lib\JasperReports X.X.X - X.X.Xフォルダーからaspose.slides.jasperreports.library-xx.x.jarを&#60;InstallDir&#62;\libディレクトリにコピーしてください。

{{% /alert %}} 

ほとんどのデモ（チャートを除く）には、すでに生成されたプレゼンテーションがありますので、すべての「ant」ステップをスキップして、すぐに結果を確認できます。