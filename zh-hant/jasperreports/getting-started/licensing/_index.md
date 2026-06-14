---
title: 授權
type: docs
weight: 50
url: /zh-hant/jasperreports/licensing/
---
{{% alert color="primary" %}} 

Aspose.Slides for JasperReports 可於 [下載頁面](https://downloads.aspose.com/slides/zh-hant/jasperreport) 取得無時間限制的免費評估版。評估版與授權版使用相同的下載檔。

當您對評估版感到滿意時，請 [購買授權](https://purchase.aspose.com/buy)。請確保您已了解並同意訂閱條款。

授權檔可在訂單付款完成後於訂單頁面下載。授權檔為純文字、經數位簽章的 XML 檔，內含客戶名稱、購買的產品與授權類型等資訊。切勿以任何方式修改授權檔內容：修改將導致授權失效。

將授權檔下載至您的電腦，並複製到適當的資料夾（例如您的應用程式資料夾或 **JasperReports\lib**）。

## **評估版限制**
Aspose.Slides 的評估版（未指定授權）提供完整的產品功能，但在儲存簡報時，會在每張投影片的中央插入如以下圖示的評估水印：

![todo:image_alt_text](evaluation_watermark.png) 

## **應用授權**
根據您使用的是 JasperReports 或 JasperServer，有多種方式可套用授權。

### **在 JasperReports 中套用授權**
使用類似 Aspose.Slides for Java 的直接 setLicense 方法呼叫。

```java
import com.aspose.slides.jasperreports.License;

..... 

try {
    //建立一個包含授權檔的串流物件
    FileInputStream fstream=new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");
	
    //實例化 License 類別
    License license = new License();
	
    //透過串流物件設定授權
    license.setLicense(fstream);
} catch(Exception ex) {
    System.out.println(ex.toString());
}
```

或在程式碼中設定匯出參數。

```java
ASPptExporter exporter = new ASPptExporter (); 
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **在 JasperServer 中套用授權**
在 applicationContext.xml 中設定匯出參數。

``` xml
<bean id="asExportParametersBean" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="licenseFile" value="C:/jasperserver-3.0/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```