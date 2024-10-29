---
title: 製品概要
type: docs
weight: 10
url: /ja/jasperreports/product-overview/
---

{{% alert color="primary" %}} 

![todo:image_alt_text](product-overview_1.png)

## **Aspose.Slides for JasperReports ドキュメントへようこそ！**
Aspose.Slides for JasperReports は、JasperReports から Microsoft PowerPoint プレゼンテーション (PPT) および Microsoft PowerPoint ショー (PPS) 形式にレポートを簡単にエクスポートする必要がある開発者のために特別に設計および開発されたライブラリです。すべてのレポート機能は、Microsoft PowerPoint プレゼンテーションに高い精度で変換されます。Aspose.Slides for JasperReports は、JasperReports 5+をサポートしています。

{{% /alert %}} 

## **製品説明**
JasperReports および JasperServer には、レポートを Microsoft PowerPoint プレゼンテーションとしてエクスポートするための組み込み機能はありませんが、Aspose.Slides for JasperReports は、次の 2 つの追加エクスポート形式へのアクセスを提供します：

- PPT – Aspose.SlidesによるPowerPointプレゼンテーション
- PPS - Aspose.SlidesによるPowerPointショー
- PPTX – Aspose.SlidesによるPowerPointプレゼンテーション
- PPSX - Aspose.SlidesによるPowerPointショー

Aspose.Slides for JasperReports は、内部的に私たちの100%純粋なJavaライブラリであるAspose.Slides for JavaとAspose.Metafiles for Javaを使用しており、サーバーサイドのプレゼンテーションやメタファイル処理のための世界クラスのライブラリです。

Aspose.Slides for JasperReports を使用すると、任意のレポートを PPT または PPS 形式でエクスポートできます。

### **出力例**
ASPptExporter クラスは ASAbstractExporter クラスを拡張しており、他の標準エクスポーターと同様に使用できます。この短い例は、MS PowerPoint で表示されるレポートの典型的なコードとスクリーンショットを示しています。詳細な例は、提供されたデモレポートに見つかります。

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

![todo:image_alt_text](product-overview_2.png)