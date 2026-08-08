---
title: 许可
type: docs
weight: 50
url: /zh/jasperreports/licensing/
---
{{% alert color="primary" %}} 

Aspose.Slides for JasperReports 可从[下载页面](https://downloads.aspose.com/slides/zh/jasperreport) 免费无限期试用。产品的试用版和正式版下载相同。

当您对试用满意后，可[购买许可证](https://purchase.aspose.com/buy)。请确保您已了解并同意订阅条款。

许可证可在订单页面支付完成后下载。许可证是一个纯文本、经过数字签名的 XML 文件，包含客户名称、购买的产品和许可证类型等信息。请勿以任何方式修改许可证文件的内容：否则将使许可证失效。

将许可证下载到本地电脑后，复制到相应文件夹（例如您的应用程序文件夹或 **JasperReports\lib**）。
{{% /alert %}}

## **评估版限制**
Aspose.Slides 的评估版（未指定许可证）提供完整的产品功能，但在保存演示文稿时，会在每张幻灯片的中心注入评估水印，如下图所示：

![todo:image_alt_text](evaluation_watermark.png) 

## **应用许可证**
有多种方式可以应用许可证，取决于您是在使用 JasperReports 还是 JasperServer。

### **为 JasperReports 应用许可证**
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

或者，在代码中设置 exporter 参数。

```java
ASPptExporter exporter = new ASPptExporter (); 
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **在 JasperServer 上应用许可证**
在 applicationContext.xml 中设置 exporter 参数。

``` xml
<bean id="asExportParametersBean" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="licenseFile" value="C:/jasperserver-3.0/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```