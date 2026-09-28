---
title: Aspose.Slides for JasperReports
second_title: Aspose.Slides for JasperReports
type: docs
weight: 70
url: /ja/jasperreports/
keywords:
- ドキュメント
- JasperReports
- JasperReports Server
- レポートエクスポート
- PowerPoint
- PPT
- PPTX
- Java
- Aspose.Slides
description: "ここから開始してください：Aspose.Slides for JasperReports をインストールし、最初のレポートを PowerPoint にエクスポートし、エクスポート、JasperReports Server との統合、およびサポートに関するガイドを見つけてください。"
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for JasperReports" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for JasperReports は JasperReports Library と JasperReports Server に PowerPoint エクスポーターを追加し、Java アプリケーションやレポートサーバーが Microsoft PowerPoint を使用せずに記入済みレポートをプレゼンテーションとして保存できるようにします。

記入済みレポートを PPT および PPTX（ページごとに 1 スライド）にエクスポートし、さらに PDF と HTML にもエクスポートできます。

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>はじめに</b></p>
<hr>
<p>はじめに</p>
<ul>
<li><a href="/slides/ja/jasperreports/installing-aspose-slides-for-jasperreports/">インストール</a></li>
<li><a href="/slides/ja/jasperreports/product-overview/">製品概要</a></li>
<li><a href="/slides/ja/jasperreports/system-requirements/">システム要件</a></li>
<li><a href="/slides/ja/jasperreports/getting-started/">開始ガイド</a></li>
</ul>
<p>評価</p>
<ul>
<li><a href="/slides/ja/jasperreports/supported-file-formats/">サポートされているファイル形式</a></li>
<li><a href="/slides/ja/jasperreports/evaluate-aspose-slides/">トライアルの制限</a></li>
<li><a href="/slides/ja/jasperreports/licensing/">ライセンス</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Slides で構築</b></p>
<hr>
<p>エクスポート</p>
<ul>
<li><a href="/slides/ja/jasperreports/ppt-pptx-pdf-and-html-export/">PPT、PPTX、PDF、HTML へエクスポート</a></li>
<li><a href="/slides/ja/jasperreports/ppt-pptx-pdf-and-html-export/#map-fonts">フォントのマッピング</a></li>
<li><a href="/slides/ja/jasperreports/integration-with-jasperserver/">JasperReports Server との統合</a></li>
</ul>
<p>例</p>
<ul>
<li><a href="/slides/ja/jasperreports/demos-setup/">デモプロジェクト</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>リファレンス&amp;サポート</b></p>
<hr>
<p>リファレンス</p>
<ul>
<li><a href="https://releases.aspose.com/slides/jasperreport/release-notes/">リリースノート</a></li>
<li><a href="https://releases.aspose.com/slides/jasperreport/">ダウンロード</a></li>
</ul>
<p>サポート</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">無料サポートフォーラム</a></li>
<li><a href="https://helpdesk.aspose.com/">有料サポートヘルプデスク</a></li>
</ul>
</div>
</div>

------

## **初めてのエクスポート**

これらの手順は 1 行のレポートをコンパイルし、データを埋め込み、Maven Central から取得した JasperReports 6.16.0 を使用して PPTX にエクスポートします。JDK 11 以降と Apache Maven が必要です。

1. [ダウンロードページ](https://releases.aspose.com/slides/jasperreport/)から ZIP をダウンロードし、展開します。*lib* フォルダーには JasperReports のバージョン範囲ごとにサブフォルダーがあり、各フォルダーにその範囲用の JAR が格納されています。JasperReports 6.16.0 用には、*lib/JasperReports 6.5.0 - 6.16.0 (JDK 1.6)/aspose.slides.jasperreports.library-26.6.jar* を空のプロジェクトフォルダーにコピーします。

2. JAR は ZIP に同梱されており Maven リポジトリから取得できないため、ローカル Maven リポジトリにインストールします。プロジェクトフォルダーで以下のコマンドを実行してください:

```bash
mvn install:install-file "-Dfile=aspose.slides.jasperreports.library-26.6.jar" "-DgroupId=com.aspose" "-DartifactId=aspose-slides-jasperreports" "-Dversion=26.6" "-Dpackaging=jar"
```

3. この *pom.xml* をプロジェクトフォルダーに保存します。これにより JasperReports 6.16.0 とインストールした JAR が追加され、実行するクラスが指定されます。JasperReports 6.16.0 は Maven Central に存在しないパッチが当てられた iText ビルドを宣言しているため、ファイルからは除外されています。Aspose のエクスポーターはそれを必要としません。

```xml
<project xmlns="http://maven.apache.org/POM/4.0.0">
    <modelVersion>4.0.0</modelVersion>
    <groupId>com.example</groupId>
    <artifactId>hello-jasper-export</artifactId>
    <version>1.0</version>

    <properties>
        <maven.compiler.release>11</maven.compiler.release>
        <project.build.sourceEncoding>UTF-8</project.build.sourceEncoding>
        <exec.mainClass>HelloExport</exec.mainClass>
    </properties>

    <dependencies>
        <dependency>
            <groupId>net.sf.jasperreports</groupId>
            <artifactId>jasperreports</artifactId>
            <version>6.16.0</version>
            <exclusions>
                <exclusion>
                    <groupId>com.lowagie</groupId>
                    <artifactId>itext</artifactId>
                </exclusion>
            </exclusions>
        </dependency>
        <dependency>
            <groupId>com.aspose</groupId>
            <artifactId>aspose-slides-jasperreports</artifactId>
            <version>26.6</version>
        </dependency>
    </dependencies>

    <build>
        <plugins>
            <plugin>
                <groupId>org.apache.maven.plugins</groupId>
                <artifactId>maven-compiler-plugin</artifactId>
                <version>3.15.0</version>
            </plugin>
        </plugins>
    </build>
</project>
```

4. このレポートデザインを *hello.jrxml* としてプロジェクトフォルダーに保存します。タイトルバンドに 1 行のテキストを出力します：

```xml
<?xml version="1.0" encoding="UTF-8"?>
<jasperReport xmlns="http://jasperreports.sourceforge.net/jasperreports"
        xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
        xsi:schemaLocation="http://jasperreports.sourceforge.net/jasperreports http://jasperreports.sourceforge.net/xsd/jasperreport.xsd"
        name="Hello" pageWidth="595" pageHeight="842" columnWidth="555"
        leftMargin="20" rightMargin="20" topMargin="20" bottomMargin="20">
    <title>
        <band height="50">
            <staticText>
                <reportElement x="0" y="0" width="555" height="40"/>
                <textElement>
                    <font size="24"/>
                </textElement>
                <text><![CDATA[Hello from JasperReports!]]></text>
            </staticText>
        </band>
    </title>
</jasperReport>
```

5. このコードを *src/main/java/HelloExport.java* として保存します。デザインをコンパイルし、空のレコードを 1 件で埋め、`ASPptxExporter` を使用して結果をエクスポートします：

```java
import java.util.HashMap;

import com.aspose.slides.jasperreports.ASPptxExporter;
import net.sf.jasperreports.engine.JREmptyDataSource;
import net.sf.jasperreports.engine.JRExporterParameter;
import net.sf.jasperreports.engine.JasperCompileManager;
import net.sf.jasperreports.engine.JasperFillManager;
import net.sf.jasperreports.engine.JasperPrint;
import net.sf.jasperreports.engine.JasperReport;

public class HelloExport {
    public static void main(String[] args) throws Exception {
        // レポートデザインをコンパイルし、空のレコードを1件で埋めます。
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // 埋め込まれたレポートをPPTXにエクスポートします。
        ASPptxExporter exporter = new ASPptxExporter();
        exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
        exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "hello.pptx");
        exporter.exportReport();
    }
}
```

6. プロジェクトフォルダーで以下のコマンドを実行します:

```bash
mvn compile exec:java
```

プログラムは *hello.pptx* をプロジェクトフォルダーに保存し、レポートのテキストを含むスライドが 1 枚作成されます。コンパイラはコードが非推奨 API を使用していることを指摘します。エクスポーターは `JRExporterParameter` で入出力を受け取り、最新の `setExporterInput` や `setExporterOutput` 設定は受け付けません。Linux では fontconfig と少なくとも 1 つのフォントをインストールする必要があり、これがないとレポートのフィリングに失敗します。ライセンスがない場合、各スライドの中央に評価用の透かしが入ります — 詳細は [ライセンス](/slides/ja/jasperreports/licensing/) を参照してください。PPT、PDF、HTML へのエクスポートについては、[PPT、PPTX、PDF および HTML エクスポート](/slides/ja/jasperreports/ppt-pptx-pdf-and-html-export/) をご覧ください。