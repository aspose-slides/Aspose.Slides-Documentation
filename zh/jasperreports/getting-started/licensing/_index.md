---
title: 授权
type: docs
weight: 50
url: /zh/jasperreports/licensing/
---
{{% alert color="info" %}} 

Aspose.Slides for JasperReports 可从[下载页面](https://downloads.aspose.com/slides/zh/jasperreport)免费无限时长评估。评估版和授权版使用相同的下载链接。

评估满意后，[购买许可证](https://purchase.aspose.com/buy)。请确保您已了解并同意订阅条款。

许可证可在订单付款后从订单页面下载。许可证是一个明文的、经过数字签名的 XML 文件，包含客户端名称、购买的产品以及许可证类型等信息。请不要以任何方式修改许可证文件的内容：这样会使许可证失效。

将许可证下载到电脑并复制到相应文件夹（例如您的应用程序文件夹或 **JasperReports\lib**）。 
{{% /alert %}}

## **评估版限制**
Aspose.Slides 的评估版（未指定许可证）提供完整的产品功能，但在保存演示文稿时，会在每张幻灯片的中心插入评估水印，如下图所示：

![todo:image_alt_text](evaluation_watermark.png) 

## **应用许可证**
根据您是使用 JasperReports 还是 JasperServer，有多种应用许可证的方法。

### **在 JasperReports 中应用许可证**
使用类似于 Aspose.Slides for Java 的直接 setLicense 方法调用。

```java
import com.aspose.slides.jasperreports.License;

..... 

try {
    //创建包含许可证文件的流对象
    FileInputStream fstream=new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");
	
    //实例化 License 类
    License license = new License();
	
    //通过流对象设置许可证
    license.setLicense(fstream);
} catch(Exception ex) {
    System.out.println(ex.toString());
}
```

或者，在代码中设置导出器参数。

```java
ASPptExporter exporter = new ASPptExporter (); 
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **在 JasperServer 上应用许可证**
在 applicationContext.xml 中设置导出器参数。

``` xml
<bean id="asExportParametersBean" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="licenseFile" value="C:/jasperserver-3.0/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```