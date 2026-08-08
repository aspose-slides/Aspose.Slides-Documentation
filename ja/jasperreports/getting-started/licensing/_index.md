---
title: ライセンス
type: docs
weight: 50
url: /ja/jasperreports/licensing/
---
{{% alert color="primary" %}} 

Aspose.Slides for JasperReports は、[ダウンロードページ](https://downloads.aspose.com/slides/ja/jasperreport) から無料で時間無制限の評価版として利用できます。評価版とライセンス版は同じダウンロードです。

評価に満足したら、[ライセンスを購入](https://purchase.aspose.com/buy)。サブスクリプション条件を理解し、同意したことを確認してください。

ライセンスは、注文が支払われた後の注文ページからダウンロードできます。ライセンスはプレーンテキストのデジタル署名された XML ファイルで、クライアント名、購入製品、ライセンスタイプなどの情報が含まれます。ライセンスファイルの内容をいかなる方法でも変更しないでください。変更するとライセンスが無効になります。

ライセンスをコンピューターにダウンロードし、適切なフォルダー（例: アプリケーションフォルダーまたは **JasperReports\lib**）にコピーしてください。
{{% /alert %}}

## **Evaluation Version Limitation**
ライセンスが指定されていない Aspose.Slides の評価版は、製品のすべての機能を提供しますが、プレゼンテーションを保存すると、各スライドの中央に以下の図のように評価用ウォーターマークが挿入されます。

![todo:image_alt_text](evaluation_watermark.png) 

## **Applying a License**
JasperReports で作業するか JasperServer で作業するかに応じて、ライセンスを適用する方法はいくつかあります。

### **JasperReports 用のライセンス適用**
Aspose.Slides for Java と同様に、直接 setLicense メソッドを呼び出します。

```java
import com.aspose.slides.jasperreports.License;

..... 

try {
    //ライセンスファイルを含むストリームオブジェクトを作成
    FileInputStream fstream=new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");
	
    //License クラスをインスタンス化
    License license = new License();
	
    //ストリームオブジェクトを使用してライセンスを設定
    license.setLicense(fstream);
} catch(Exception ex) {
    System.out.println(ex.toString());
}
```

または、コード内でエクスポーター パラメーターを設定します。

```java
ASPptExporter exporter = new ASPptExporter (); 
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **JasperServer でのライセンス適用**
applicationContext.xml でエクスポーター パラメーターを設定します。

``` xml
<bean id="asExportParametersBean" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="licenseFile" value="C:/jasperserver-3.0/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```