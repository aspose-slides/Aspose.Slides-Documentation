---
title: Licensing
type: docs
weight: 50
url: /jasperreports/licensing/
description: "Learn what the evaluation version of Aspose.Slides for JasperReports adds to exported files, and how to apply a license in JasperReports and JasperReports Server."
---

{{% alert color="info" title="Note" %}}

Aspose.Slides for JasperReports is available as a free, time-unlimited evaluation from the [download page](https://releases.aspose.com/slides/jasperreport/). The evaluation and licensed versions of the product are the same download.

When you are happy with the evaluation, [buy a license](https://purchase.aspose.com/pricing/slides/jasperreports/). Make sure you understand and agree to the subscription terms.

The license is available for download from the order page after the order has been paid for. The license is a clear text, digitally signed XML file which contains information such as the client name, the purchased product and the license type. Do not modify the content of the license file in any way: doing so invalidates the license.

Download the license to your computer and copy it to the appropriate folder (for example your application folder or **JasperReports\lib**).
{{% /alert %}}

## **Evaluation Version Limitation**
The evaluation version of Aspose.Slides for JasperReports (without a license specified) exports every page of the report, but it places an evaluation watermark at the center of each slide or page, in all four output formats (PPT, PPTX, PDF and HTML), as shown in the figure below. See [Evaluate Aspose.Slides](/slides/jasperreports/evaluate-aspose-slides/) for details.

![The evaluation watermark at the center of an exported slide](evaluation_watermark.png)

## **Applying a License**
There are several ways to apply a license, depending on whether you're working on JasperReports, or JasperServer.

### **Applying a License for JasperReports**
Call the `setLicense` method of the `License` class with a stream that reads the license file, as in Aspose.Slides for Java:

```java
import java.io.FileInputStream;

import com.aspose.slides.jasperreports.License;

public class ApplyLicense {
    public static void main(String[] args) {
        try {
            // Create a stream object containing the license file.
            FileInputStream fstream = new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");

            // Instantiate the License class.
            License license = new License();

            // Set the license through the stream object.
            license.setLicense(fstream);
        } catch (Exception ex) {
            System.out.println(ex.toString());
        }
    }
}
```

Or, pass the path of the license file to the exporter in the `ASExporterParameters.PPT_LICENSE` parameter. In this fragment, `jasperPrint` is a filled report, as in [Your first export](/slides/jasperreports/#your-first-export):

```java
ASPptExporter exporter = new ASPptExporter();
exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "report.ppt");
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **Applying a License on JasperServer**
Set the `licenseFile` property of the `pptExportParameters` bean in *applicationContext.xml* to the path of the license file, as shown in [Integration with JasperServer](/slides/jasperreports/integration-with-jasperserver/#set-font-mapping-and-the-license).
