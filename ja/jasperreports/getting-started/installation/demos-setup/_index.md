---
title: デモのセットアップ
type: docs
weight: 70
url: /ja/jasperreports/demos-setup/
description: "Aspose.Slides for JasperReports のダウンロードからデモプロジェクトを設定し、使用するエクスポートクラスを変更し、Ant でビルドします。"
---
## **デモの概要**

Aspose.Slides for JasperReports のダウンロードに含まれる *samples* フォルダーには、8 つのデモ プロジェクト（*charts*、*fonts*、*images*、*landscape*、*shapes*、*subreport*、*text*、*xmldatasource*）があります。これらは標準の JasperReports デモで、レポートを PPT にエクスポートする `ppt` ビルドターゲットを追加するように変更されています。ダウンロード自体にはエクスポートされたプレゼンテーションは含まれておらず、デモをビルドすることで作成します。

## **ビルド前にエクスポートクラスを変更**

そのまま提供されているデモの Java コードは `com.aspose.slides.jasperreports.JRPptExporter` を使用していますが、このクラスは現在の JAR には含まれていないため、デモはコンパイルできません。デモのアプリケーション・クラス（例: *shapes* デモの *ShapesApp.java*）で `JRPptExporter` を同一パッケージにある PPT エクスポーター `ASPptExporter` に置き換えてください。*fonts* デモはパッケージ全体をインポートしているので、コード中のクラス名だけが変更されます。

デモでは、後の JasperReports バージョンで削除された `JExcelApiExporter` や `JRExporterParameter.FONT_MAP` といった JasperReports のクラスも使用しています。上記の変更により、デモは以下のようにコンパイルできます。

| JasperReports バージョン | コンパイルできるデモ |
| :- | :- |
| 5.5.1 | すべて |
| 5.5.2 and 6.4.0 | *charts*, *images*, *landscape*, *shapes* and *xmldatasource* |
| 6.16.0 | *charts* |

## **デモをビルドする**

各デモの *build.xml* は JasperReports プロジェクトのフォルダー構成を前提としています。デモフォルダーを基準に、*../../../build/classes* と *../../../lib* 内の JAR に対してコンパイルします。

1. デモフォルダーを JasperReports プロジェクトのフォルダー内にある *demo/samples* にコピーします。
2. *aspose.slides.jasperreports.library-xx.x.jar* を、ダウンロードの *lib* サブフォルダーから、使用している JasperReports バージョンに対応するものを JasperReports プロジェクトの *lib* フォルダーへコピーします。[Aspose.Slides for JasperReports のインストール](/slides/ja/jasperreports/installing-aspose-slides-for-jasperreports/) を参照してください。
3. 使用している JasperReports の JAR とそれが依存する JAR を同じ *lib* フォルダーに配置します。デモファイル以外は、*build.xml* がクラスパスに追加するのは *build/classes* と *lib* 配下の JAR のみで、*build/classes* には JasperReports をソースからコンパイルした後にのみ JasperReports のクラスが入ります。
4. *charts*、*subreport*、*text* デモは JasperReports の HSQLDB サンプルデータベース（`jdbc:hsqldb:hsql://localhost`）を読み込むため、ダウンロードの *samples/Readme.txt* に記載されている手順でまずサーバーを起動してください。他のデモはデータベースを必要としません。
5. デモフォルダー内で、アプリケーションをコンパイルし、レポートデザインをコンパイルしてフィルし、PPT にエクスポートします：

```bash
ant javac
ant compile
ant fill
ant ppt
```

`ppt` ターゲットは、フィルしたレポートと同じディレクトリーに、レポート名を付けたプレゼンテーション（例: *LandscapeReport.ppt*）を書き出します。

以下の 2 つのデモは上記の手順だけでは不十分です:

- *images* デモはエクスポート時に `http://jasperreports.sourceforge.net/jasperreports.png` から画像を 1 枚読み込みます。このアドレスは現在 HTTPS にリダイレクトされるため、*ImagesReport.jrxml* でアドレスを `https://` に変更しない限り `ppt` 手順でプレゼンテーションは生成されません。JasperReports 6.4.0 では、HTTPS 経由でも画像のエクスポートが失敗します。
- *xmldatasource* レポートは Arial フォントを使用します。システムに Arial がない場合、`ant fill` はフォントが "JVM で使用できません" と表示し、フィルされたレポートを生成しないため、`ant ppt` でエクスポートするものがなくなります。ビルドは成功したと報告されるので、各ステップの出力を確認してください。