---
title: PPT、PPTX、PDF および HTML エクスポート
type: docs
weight: 20
url: /ja/jasperreports/ppt-pptx-pdf-and-html-export/
description: "Aspose.Slides for JasperReports のエクスポーターを選択して PPT、PPTX、PDF、または HTML 出力を行い、埋め込まれたレポートをエクスポートし、レポートのフォントをプレゼンテーションのフォントにマッピングします。"
---
## **エクスポーター**

Aspose.Slides for JasperReports は JasperReports に 4 つのエクスポーターを追加します。各エクスポーターは、埋め込まれたレポート（`JasperPrint`）を受け取り、レポートページをそれぞれ PPT と PPTX のスライド、PDF のページ、単一の HTML ファイル内の SVG 画像としてエクスポートします。

| 出力形式 | エクスポーター クラス |
| :- | :- |
| PPT (PowerPoint 97–2003) | `ASPptExporter` |
| PPTX | `ASPptxExporter` |
| PDF | `ASPdfExporter` |
| HTML | `ASHtmlExporter` |

これらのクラスはライブラリ JAR の `com.aspose.slides.jasperreports` パッケージにあり、Microsoft PowerPoint は使用しません。レポートと出力ファイルをエクスポーターに渡すには、`setParameter` と `JRExporterParameter` を使用します（JasperReports では非推奨とマークされています）。エクスポーターは新しい `setExporterInput` と `setExporterOutput` 設定を受け付けません。

## **4 つの形式すべてにレポートをエクスポートする**

以下のプログラムは、[Your first export](/slides/ja/jasperreports/#your-first-export) からのプロジェクトをベースにしています。`hello.jrxml` を一度だけコンパイルして埋め込み、埋め込まれたレポートを順に各エクスポーターに渡します。プロジェクト内に *src/main/java/ExportAllFormats.java* として保存してください。

```java
import java.util.HashMap;

import com.aspose.slides.jasperreports.ASAbstractExporter;
import com.aspose.slides.jasperreports.ASHtmlExporter;
import com.aspose.slides.jasperreports.ASPdfExporter;
import com.aspose.slides.jasperreports.ASPptExporter;
import com.aspose.slides.jasperreports.ASPptxExporter;
import net.sf.jasperreports.engine.JREmptyDataSource;
import net.sf.jasperreports.engine.JRException;
import net.sf.jasperreports.engine.JRExporterParameter;
import net.sf.jasperreports.engine.JasperCompileManager;
import net.sf.jasperreports.engine.JasperFillManager;
import net.sf.jasperreports.engine.JasperPrint;
import net.sf.jasperreports.engine.JasperReport;

public class ExportAllFormats {
    public static void main(String[] args) throws Exception {
        // レポートを一度コンパイルしてフィルします。
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // 同じ埋め込まれたレポートを各エクスポーターでエクスポートします。
        export(new ASPptExporter(), jasperPrint, "hello.ppt");
        export(new ASPptxExporter(), jasperPrint, "hello.pptx");
        export(new ASPdfExporter(), jasperPrint, "hello.pdf");
        export(new ASHtmlExporter(), jasperPrint, "hello.html");
    }

    private static void export(ASAbstractExporter exporter, JasperPrint jasperPrint, String outputFileName) throws JRException {
        exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
        exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, outputFileName);
        exporter.exportReport();
    }
}
```

プロジェクト フォルダーから実行します:

```bash
mvn compile exec:java "-Dexec.mainClass=ExportAllFormats"
```

プログラムは *hello.ppt*、*hello.pptx*、*hello.pdf*、*hello.html* をプロジェクト フォルダーに保存します。ヘルパー メソッドは 4 つのエクスポーターすべての基底クラスである `ASAbstractExporter` を受け取ります。ライセンスがない場合、すべての出力ファイルには評価用の透かしが付加されます — 詳細は [Evaluate Aspose.Slides](/slides/ja/jasperreports/evaluate-aspose-slides/) を参照してください。

![A report exported to a presentation without a license](ppt-pptx-pdf-and-html-export_1.png)

## **フォントのマッピング**

PPT と PPTX エクスポーターは、レポート デザインで指定されたフォント名を変更せずにプレゼンテーションに書き込みます。テキスト要素にフォントが指定されていない場合、JasperReports はデフォルト フォント `SansSerif` を使用しますが、これはインストールされたフォントではなく Java の論理フォント名です。そのような名前を置き換えるには、`ASExporterParameters.PPT_FONT_MAP` パラメータにレポートのフォント名からプレゼンテーションで使用したいフォント名へのマップを渡します。キーはレポート内のフォント名と完全に一致させる必要があり、大文字小文字も区別されます。各値はエクスポートを実行するマシン上で Java が見つけられるフォントでなければなりません。Java がフォントを見つけられないエントリはエクスポーターに無視されます。

同じプロジェクト内に *src/main/java/MapFonts.java* として保存してください。このプログラムは `SansSerif` を Arial に置き換えて *hello.jrxml* を PPTX にエクスポートします。

```java
import java.util.HashMap;
import java.util.Map;

import com.aspose.slides.jasperreports.ASExporterParameters;
import com.aspose.slides.jasperreports.ASPptxExporter;
import net.sf.jasperreports.engine.JREmptyDataSource;
import net.sf.jasperreports.engine.JRExporterParameter;
import net.sf.jasperreports.engine.JasperCompileManager;
import net.sf.jasperreports.engine.JasperFillManager;
import net.sf.jasperreports.engine.JasperPrint;
import net.sf.jasperreports.engine.JasperReport;

public class MapFonts {
    public static void main(String[] args) throws Exception {
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // レポートのフォント名をプレゼンテーションに書き込むフォント名にマッピングします。
        Map<String, String> fontMap = new HashMap<String, String>();
        fontMap.put("SansSerif", "Arial");

        ASPptxExporter exporter = new ASPptxExporter();
        exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
        exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "hello-arial.pptx");
        exporter.setParameter(ASExporterParameters.PPT_FONT_MAP, fontMap);
        exporter.exportReport();
    }
}
```

プロジェクト フォルダーから実行します:

```bash
mvn compile exec:java "-Dexec.mainClass=MapFonts"
```

保存された *hello-arial.pptx* では、レポートのテキストが `SansSerif` の代わりに Arial を使用しています。Java が Arial を見つけられないマシン（例: Arial がインストールされていない Linux システム）では、テキストは `SansSerif` のままです。JasperReports Server では、エクスポート パラメータ ビーンの `fontMap` プロパティを通じて同じマップを設定します — 詳細は [Integration with JasperServer](/slides/ja/jasperreports/integration-with-jasperserver/#set-font-mapping-and-the-license) を参照してください。