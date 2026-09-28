---
title: Aspose.Slides for JasperReports のインストール
type: docs
weight: 40
url: /ja/jasperreports/installing-aspose-slides-for-jasperreports/
description: "JasperReports のバージョンに合った Aspose.Slides for JasperReports の JAR を選択し、JasperReports、Maven プロジェクト、または JasperReports Server に追加します。"
---
## **使用している JasperReports バージョンに合わせた JAR を選択してください**

Aspose.Slides for JasperReports は [download page](https://releases.aspose.com/slides/jasperreport/) から ZIP ファイルとして配布されています。その *lib* フォルダーには JasperReports のバージョンごとにサブフォルダーが用意されています。使用している JasperReports バージョンに対応するサブフォルダーから JAR を取得してください。

| JasperReports バージョン | *lib* のサブフォルダー |
| :- | :- |
| 3.7.2 to 5.5.1 | *JasperReports 3.7.2 - 5.5.1 (JDK 1.6)* |
| 5.5.2 to 6.4.0 | *JasperReports 5.5.2 - 6.4.0 (JDK 1.6)* |
| 6.5.0 to 6.16.0 | *JasperReports 6.5.0 - 6.16.0 (JDK 1.6)* |

JasperReports 6.17.0 以降（JasperReports 7 を含む）にはサブフォルダーがありません。*JasperReports 2.0.3 - 3.7.1 (JDK 1.4)* サブフォルダーには JAR がなく、Aspose.Slides for JasperReports 17.6 でこれらのバージョンのサポートが終了したことを示すメモだけが含まれています。

各サブフォルダーには 2 つの JAR が含まれます。名前に含まれる *xx.x* は製品バージョンです。

- *aspose.slides.jasperreports.library-xx.x.jar* には JasperReports Library 用エクスポーター（`ASPptExporter`、`ASPptxExporter`、`ASPdfExporter`、`ASHtmlExporter`）と `License` クラスが含まれます。
- *aspose.slides.jasperreports.server-xx.x.jar* には JasperReports Server 用エクスポートアクションが含まれます。この JAR はライブラリ JAR を基盤としているため、サーバーは同じサブフォルダーの 2 つの JAR を常に併せて使用する必要があります。

## **JAR を JasperReports またはアプリケーションに追加する**

該当するサブフォルダーから *aspose.slides.jasperreports.library-xx.x.jar* を JasperReports の *lib* フォルダーまたはアプリケーションのクラスパスにコピーします。これでアプリケーションからコード上でエクスポーターを作成できるようになります。

{{% alert color="info" title="注意" %}}
Linux では、JasperReports がレポートのフィルに fontconfig と少なくとも 1 つのインストール済みフォントを必要とします。フォントがない場合、"Error initializing graphic environment" というエラーでフィルに失敗します。
{{% /alert %}}

## **Maven プロジェクトにライブラリ JAR を追加する**

この JAR は ZIP に含まれており、Maven リポジトリから取得できません。Maven ビルドで使用するにはローカル Maven リポジトリにインストールします。バージョン 26.6 の場合、JAR があるフォルダーで次のコマンドを実行してください。

```bash
mvn install:install-file "-Dfile=aspose.slides.jasperreports.library-26.6.jar" "-DgroupId=com.aspose" "-DartifactId=aspose-slides-jasperreports" "-Dversion=26.6" "-Dpackaging=jar"
```

その後、*pom.xml* の依存関係に追加し、JAR のサブフォルダーが対応する JasperReports バージョンも指定します。

```xml
<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides-jasperreports</artifactId>
    <version>26.6</version>
</dependency>
```

groupId と artifactId はインストールコマンドで指定したものを使用してください。合わせるだけで問題ありません。JasperReports 6.16.0 を使用した完全なプロジェクトは [Your first export](/slides/ja/jasperreports/#your-first-export) にあります。

## **JAR を JasperReports Server に追加する**

該当するサブフォルダーから両方の JAR を JasperReports Server の Web アプリケーションの *WEB-INF/lib* フォルダーにコピーし、[Integration with JasperServer](/slides/ja/jasperreports/integration-with-jasperserver/) に記載の手順でエクスポーターを登録してください。