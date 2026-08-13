---
title: デモのセットアップ
type: docs
weight: 70
url: /ja/jasperreports/demos-setup/
---
Aspose.Slides for JasperReports が提供するすべてのデモは、変更された標準デモです。すべてのデモを JasperReports のデモフォルダーにコピーした方がよいです:
...\jasperreports-x.x.x\demo\samples\

レポートをビルドおよびエクスポートするには、標準のコマンドシーケンスを使用します:

- ant javac
- ant compile
- ant fill
- ant ppt

{{% alert color="info" %}} 
テストデータベースで HSQLDB を実行し、レポートにデータを入力することを忘れないでください。また、aspose-slides-xx.x-jasperreports.zip の \lib\JasperReports X.X.X - X.X.X フォルダーから aspose.slides.jasperreports.library-xx.x.jar を &#60;InstallDir&#62;\lib ディレクトリにコピーしてください。
{{% /alert %}} 

チャートを除くほとんどのデモはすでにプレゼンテーションが生成されているため、すべての「ant」手順をスキップしてすぐに結果を確認できます。