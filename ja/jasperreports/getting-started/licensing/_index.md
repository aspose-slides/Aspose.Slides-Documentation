---
title: ライセンス
type: docs
weight: 50
url: /ja/jasperreports/licensing/
description: "Aspose.Slides for JasperReports の評価版がエクスポートされたファイルに追加する内容と、JasperReports および JasperReports Server でライセンスを適用する方法を学びます。"
---
{{% alert color="info" title="Note" %}}

Aspose.Slides for JasperReports は、[download page](https://releases.aspose.com/slides/jasperreport/) から無料で期間無制限の評価版として入手できます。評価版とライセンス版は同一のダウンロードです。

評価版に満足したら、[buy a license](https://purchase.aspose.com/pricing/slides/jasperreports/) を実行してください。利用規約を理解し、同意したことを確認してください。

ライセンスは、注文が支払われた後の注文ページからダウンロードできます。ライセンスはプレーンテキストのデジタル署名された XML ファイルで、クライアント名、購入した製品、ライセンスの種類などの情報が含まれます。ライセンスファイルの内容をいかなる方法でも変更しないでください。変更するとライセンスが無効になります。

ライセンスをコンピューターにダウンロードし、適切なフォルダー（例: アプリケーション フォルダーまたは **JasperReports\lib**）にコピーしてください。
{{% /alert %}}

## **評価バージョンの制限**
ライセンスが指定されていない Aspose.Slides for JasperReports の評価版はレポートのすべてのページをエクスポートしますが、4 つの出力形式（PPT、PPTX、PDF、HTML）すべてで各スライドまたはページの中心に評価用透かしが入ります。以下の図をご参照ください。詳細は [Evaluate Aspose.Slides](/slides/ja/jasperreports/evaluate-aspose-slides/) をご覧ください。

![The evaluation watermark at the center of an exported slide](evaluation_watermark.png)

## **ライセンスの適用**
ライセンスの適用方法はいくつかあり、JasperReports で作業する場合と JasperServer で作業する場合で異なります。

### **JasperReports 用のライセンスの適用**
Java 用 Aspose.Slides と同様に、`License` クラスの `setLicense` メソッドにライセンス ファイルを読み込むストリームを渡して呼び出します。

```java
import java.io.FileInputStream;

import com.aspose.slides.jasperreports.License;

public class ApplyLicense {
    public static void main(String[] args) {
        try {
            // ライセンスファイルを含むストリームオブジェクトを作成します。
            FileInputStream fstream = new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");

            // License クラスのインスタンスを作成します。
            License license = new License();

            // ストリームオブジェクトを使用してライセンスを設定します。
            license.setLicense(fstream);
        } catch (Exception ex) {
            System.out.println(ex.toString());
        }
    }
}
```

または、エクスポーターに `ASExporterParameters.PPT_LICENSE` パラメータでライセンス ファイルのパスを渡します。このフラグメントでは、`jasperPrint` はレポートが埋め込まれた状態です（[Your first export](/slides/ja/jasperreports/#your-first-export) を参照）。

```java
ASPptExporter exporter = new ASPptExporter();
exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "report.ppt");
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **JasperServer でのライセンスの適用**
*applicationContext.xml* の `pptExportParameters` ビーンの `licenseFile` プロパティにライセンス ファイルへのパスを設定します。手順は [Integration with JasperServer](/slides/ja/jasperreports/integration-with-jasperserver/#set-font-mapping-and-the-license) をご覧ください。