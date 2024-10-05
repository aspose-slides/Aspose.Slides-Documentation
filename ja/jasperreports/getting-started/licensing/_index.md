---
title: ライセンス
type: docs
weight: 50
url: /jasperreports/licensing/
---

{{% alert color="primary" %}} 

Aspose.Slides for JasperReportsは、[ダウンロードページ](https://downloads.aspose.com/slides/jasperreport)から無制限の評価版として無料で提供されています。評価版とライセンス版は同じダウンロードです。

評価に満足したら、[ライセンスを購入](https://purchase.aspose.com/buy)してください。サブスクリプションの条件を理解し、同意していることを確認してください。

ライセンスは、注文が支払われた後に注文ページからダウンロードできます。ライセンスは、クライアント名、購入した製品、ライセンスタイプなどの情報を含む、デジタル署名されたXMLファイルです。ライセンスファイルの内容を変更しないでください。変更するとライセンスが無効になります。

ライセンスをコンピューターにダウンロードし、適切なフォルダー（たとえば、アプリケーションフォルダーまたは**JasperReports\lib**）にコピーしてください。

## **評価版の制限**
Aspose.Slidesの評価版（ライセンスが指定されていない）は、製品の全機能を提供しますが（プレゼンテーションを保存するとき）、下記の図に示すように各スライドの中央に評価用の透かしを挿入します：

![todo:image_alt_text](evaluation_watermark.png) 

## **ライセンスの適用**
ライセンスを適用する方法はいくつかあります。JasperReportsまたはJasperServerで作業しているかによって異なります。

### **JasperReportsのライセンスの適用**
Aspose.Slides for Javaと同様に、直接setLicenseメソッドを呼び出します。

```java
import com.aspose.slides.jasperreports.License;

..... 

try {
    //ライセンスファイルを含むストリームオブジェクトを作成
    FileInputStream fstream=new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");
	
    //Licenseクラスをインスタンス化
    License license = new License();
	
    //ストリームオブジェクトを通じてライセンスを設定
    license.setLicense(fstream);
} catch(Exception ex) {
    System.out.println(ex.toString());
}
```

または、コード内でエクスポーターパラメータを設定します。

```java
ASPptExporter exporter = new ASPptExporter (); 
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **JasperServerでのライセンスの適用**
applicationContext.xmlでエクスポーターパラメータを設定します。

``` xml
<bean id="asExportParametersBean" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="licenseFile" value="C:/jasperserver-3.0/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```