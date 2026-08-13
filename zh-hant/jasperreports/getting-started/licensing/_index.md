---
title: 授權
type: docs
weight: 50
url: /zh-hant/jasperreports/licensing/
---
{{% alert color="info" %}} 

Aspose.Slides for JasperReports 可從[下載頁面](https://downloads.aspose.com/slides/zh-hant/jasperreport)取得免費且無時間限制的評估版。評估版與授權版使用相同的下載檔案。

當您對評估滿意時，[購買授權](https://purchase.aspose.com/buy)。請確保您已了解並同意訂閱條款。

授權可於付款完成後從訂單頁面下載。授權是一個純文字、經數位簽章的 XML 檔案，內含客戶名稱、購買的產品以及授權類型等資訊。請勿以任何方式修改授權檔案內容：這會使授權失效。

將授權下載至您的電腦，並複製到合適的資料夾（例如您的應用程式資料夾或 **JasperReports\lib**）。
{{% /alert %}}

## **評估版限制**
Aspose.Slides 的評估版（未指定授權）提供完整的產品功能，但在儲存簡報時，會在每張投影片的中央加入評估水印，如下圖所示：

![todo:image_alt_text](evaluation_watermark.png) 

## **套用授權**
套用授權有多種方式，取決於您是使用 JasperReports 還是 JasperServer。

### **在 JasperReports 中套用授權**
使用類似 Aspose.Slides for Java 的直接 setLicense 方法呼叫。

```java
import com.aspose.slides.jasperreports.License;

..... 

try {
    //建立包含授權檔案的串流物件
    FileInputStream fstream=new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");
	
    //實例化 License 類別
    License license = new License();
	
    //透過串流物件設定授權
    license.setLicense(fstream);
} catch(Exception ex) {
    System.out.println(ex.toString());
}
```

或者，在程式碼中設定 exporter 參數。

```java
ASPptExporter exporter = new ASPptExporter (); 
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **在 JasperServer 上套用授權**
在 applicationContext.xml 中設定 exporter 參數。

```xml
<bean id="asExportParametersBean" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="licenseFile" value="C:/jasperserver-3.0/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```