---
title: ライセンス
type: docs
weight: 50
url: /ja/jasperreports/licensing/
---
{{% alert color="info" %}} 

Aspose.Slides for JasperReports は、[ダウンロードページ](https://downloads.aspose.com/slides/ja/jasperreport)から無期限の無料評価版として利用できます。製品の評価版とライセンス版は同じダウンロードです。

評価に満足したら、[ライセンスを購入](https://purchase.aspose.com/buy)してください。サブスクリプション条件を理解し、同意したことを確認してください。

ライセンスは、注文が支払われた後、注文ページからダウンロードできます。ライセンスはクリーンテキストのデジタル署名されたXMLファイルで、クライアント名、購入製品、ライセンス種別などの情報が含まれます。ライセンスファイルの内容は一切変更しないでください。変更するとライセンスは無効になります。

ライセンスをコンピュータにダウンロードし、適切なフォルダー（例: アプリケーションフォルダーや **JasperReports\lib**）にコピーしてください。
{{% /alert %}}

## **評価版の制限**
評価版の Aspose.Slides（ライセンスが指定されていない）は、製品の全機能を提供しますが、プレゼンテーションを保存する際に、以下の図のように各スライドの中央に評価用の透かしが挿入されます。

![todo:image_alt_text](evaluation_watermark.png) 

## **ライセンスの適用**
JasperReports で作業するか JasperServer で作業するかに応じて、ライセンスを適用する方法はいくつかあります。

### **JasperReports 用のライセンス適用**
Aspose.Slides for Java と同様に、直接 setLicense メソッドを呼び出します。

```java
import com.aspose.slides.jasperreports.License;

..... 

try {
    //ライセンスファイルを含むストリームオブジェクトを作成します
    FileInputStream fstream=new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");
	
    //License クラスのインスタンスを作成します
    License license = new License();
	
    //ストリームオブジェクトを通じてライセンスを設定します
    license.setLicense(fstream);
} catch(Exception ex) {
    System.out.println(ex.toString());
}
```

あるいは、コード内で exporter パラメーターを設定します。

```java
ASPptExporter exporter = new ASPptExporter (); 
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **JasperServer でのライセンス適用**
applicationContext.xml で exporter パラメーターを設定します。

``` xml
<bean id="asExportParametersBean" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="licenseFile" value="C:/jasperserver-3.0/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```