---
title: 製品概要
type: docs
weight: 10
url: /ja/jasperreports/product-overview/
---
![Aspose.Slides for JasperReports](product-overview_1.png)

## **Aspose.Slides for JasperReportsへようこそ！**

Aspose.Slides for JasperReports は、JasperReports から Microsoft PowerPoint プレゼンテーション (PPT) および Microsoft PowerPoint ショー (PPS) 形式へレポートを簡単にエクスポートする必要がある開発者向けに特別に設計・開発されたライブラリです。すべてのレポート機能は、最高の精度で Microsoft PowerPoint プレゼンテーションに変換されます。Aspose.Slides for JasperReports は JasperReports 5 以降をサポートしています。

## **製品の説明**
JasperReports と JasperServer には、レポートを Microsoft PowerPoint プレゼンテーションとしてエクスポートする組み込み機能がありませんが、Aspose.Slides for JasperReports を使用すると、次の 2 つの追加エクスポート形式が利用できます。

- PPT – Aspose.Slides による PowerPoint プレゼンテーション
- PPS – Aspose.Slides による PowerPoint ショー
- PPTX – Aspose.Slides による PowerPoint プレゼンテーション
- PPSX – Aspose.Slides による PowerPoint ショー

Aspose.Slides for JasperReports は内部で、当社の 100% 純粋な Java ライブラリである Aspose.Slides for Java と Aspose.Metafiles for Java を使用します。これらはサーバー側のプレゼンテーションとメタファイル処理のための世界クラスのライブラリです。

Aspose.Slides for JasperReports を使用すると、任意のレポートを PPT または PPS 形式でエクスポートできます。

### **出力例**
ASPptExporter クラスは ASAbstractExporter クラスを継承しているため、他の標準エクスポーターと同様に使用できます。この簡単な例は、典型的なコードと MS PowerPoint で表示されたレポートのスクリーンショットを示しています。詳細な例は、提供されているデモレポートで確認できます。

``` java
File sourceFile = new File(fileName); 
JasperPrint jasperPrint = (JasperPrint)JRLoader.loadObject(sourceFile);
File destFile = new File(sourceFile.getParent(), jasperPrint.getName() + ".ppt");
ASPptExporter exporter = new ASPptExporter();
exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, destFile.toString());
exporter.exportReport();
```

**JasperReports xmldatasource デモで生成されたプレゼンテーション** 

![JasperReportsで生成されたプレゼンテーション](product-overview_2.png)