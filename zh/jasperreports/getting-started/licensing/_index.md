---
title: 许可
type: docs
weight: 50
url: /jasperreports/licensing/
---

{{% alert color="primary" %}} 

Aspose.Slides for JasperReports 提供免费的无限期评估版本，您可以从 [下载页面](https://downloads.aspose.com/slides/jasperreport) 获取。评估版和许可版的产品下载是相同的。

当您对评估版本满意时，请 [购买许可证](https://purchase.aspose.com/buy)。确保您了解并同意订阅条款。

许可证在订单支付后可以从订单页面下载。许可证是一个明文的、数字签名的 XML 文件，包含客户名称、购买的产品和许可证类型等信息。请勿以任何方式修改许可证文件的内容：这样会使许可证无效。

将许可证下载到您的计算机，并复制到适当的文件夹（例如您的应用程序文件夹或 **JasperReports\lib**）。

## **评估版本限制**
Aspose.Slides 的评估版本（未指定许可证）提供了完整的产品功能，但（当您保存演示文稿时）会在每张幻灯片的中心注入一个评估水印，如下图所示：

![todo:image_alt_text](evaluation_watermark.png) 

## **应用许可证**
根据您是在使用 JasperReports 还是 JasperServer，应用许可证的方法有几种。

### **为 JasperReports 应用许可证**
使用直接的 setLicense 方法调用，类似于 Aspose.Slides for Java。

```java
import com.aspose.slides.jasperreports.License;

.....

try {
    // 创建一个包含许可证文件的流对象
    FileInputStream fstream=new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");
	
    // 实例化许可证类
    License license = new License();
	
    // 通过流对象设置许可证
    license.setLicense(fstream);
} catch(Exception ex) {
    System.out.println(ex.toString());
}
```

或者，在代码中设置导出参数。

```java
ASPptExporter exporter = new ASPptExporter (); 
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **在 JasperServer 上应用许可证**
在 applicationContext.xml 中设置导出参数。

``` xml
<bean id="asExportParametersBean" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="licenseFile" value="C:/jasperserver-3.0/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```