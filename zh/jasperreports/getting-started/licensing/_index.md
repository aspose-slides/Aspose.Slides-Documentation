---
title: 授权
type: docs
weight: 50
url: /zh/jasperreports/licensing/
description: "了解 Aspose.Slides for JasperReports 评估版在导出文件中添加了哪些内容，以及如何在 JasperReports 和 JasperReports Server 中应用许可证。"
---
{{% alert color="info" title="Note" %}}

Aspose.Slides for JasperReports 可在[下载页面](https://releases.aspose.com/slides/zh/jasperreport/)免费、无限期试用。试用版和正式授权版使用相同的下载文件。

当您对试用满意时，[购买许可证](https://purchase.aspose.com/pricing/slides/zh/jasperreports/)。请确保您已阅读并同意订阅条款。

许可证可在订单付款后从订单页面下载。许可证是一个纯文本、已数字签名的 XML 文件，其中包含客户名称、购买的产品和许可证类型等信息。切勿以任何方式修改许可证文件的内容：修改后许可证将失效。

将许可证下载到本地电脑后复制到相应文件夹（例如您的应用程序文件夹或 **JasperReports\lib**）。
{{% /alert %}}

## **评估版本限制**
Aspose.Slides for JasperReports 的评估版本（未指定许可证）在导出报告的每一页时，会在每张幻灯片或页面的中心添加评估水印，支持四种输出格式（PPT、PPTX、PDF 和 HTML），如下图所示。有关详细信息，请参阅[评估 Aspose.Slides](/slides/zh/jasperreports/evaluate-aspose-slides/)。

![导出幻灯片中心的评估水印](evaluation_watermark.png)

## **应用许可证**
根据您使用的是 JasperReports 还是 JasperServer，有多种方式可以应用许可证。

### **为 JasperReports 应用许可证**
调用 `License` 类的 `setLicense` 方法，并传入读取许可证文件的流，方式与 Aspose.Slides for Java 相同：

```java
import java.io.FileInputStream;

import com.aspose.slides.jasperreports.License;

public class ApplyLicense {
    public static void main(String[] args) {
        try {
            // 创建包含许可证文件的流对象。
            FileInputStream fstream = new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");

            // 实例化 License 类。
            License license = new License();

            // 通过流对象设置许可证。
            license.setLicense(fstream);
        } catch (Exception ex) {
            System.out.println(ex.toString());
        }
    }
}
```

或者，在 `ASExporterParameters.PPT_LICENSE` 参数中传入许可证文件的路径。在此片段中，`jasperPrint` 为已填充的报告，详情请参见[您的首次导出](/slides/zh/jasperreports/#your-first-export)：

```java
ASPptExporter exporter = new ASPptExporter();
exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "report.ppt");
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **在 JasperServer 上应用许可证**
在 *applicationContext.xml* 中的 `pptExportParameters` bean 上设置 `licenseFile` 属性为许可证文件的路径，示例请参见[与 JasperServer 的集成](/slides/zh/jasperreports/integration-with-jasperserver/#set-font-mapping-and-the-license)。