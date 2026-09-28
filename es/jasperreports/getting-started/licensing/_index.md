---
title: Licencias
type: docs
weight: 50
url: /es/jasperreports/licensing/
description: "Descubre qué añade la versión de evaluación de Aspose.Slides for JasperReports a los archivos exportados y cómo aplicar una licencia en JasperReports y JasperReports Server."
---
{{% alert color="info" title="Note" %}}

Aspose.Slides for JasperReports está disponible como una evaluación gratuita e ilimitada en el tiempo desde la [página de descarga](https://releases.aspose.com/slides/jasperreport/). La versión de evaluación y las versiones con licencia del producto son la misma descarga.

Cuando estés satisfecho con la evaluación, [compra una licencia](https://purchase.aspose.com/pricing/slides/jasperreports/). Asegúrate de comprender y aceptar los términos de suscripción.

La licencia está disponible para su descarga desde la página de pedido una vez que el pedido haya sido pagado. La licencia es un archivo XML de texto plano, firmado digitalmente, que contiene información como el nombre del cliente, el producto comprado y el tipo de licencia. No modifiques el contenido del archivo de licencia de ninguna manera: hacerlo invalida la licencia.

Descarga la licencia a tu ordenador y cópiala a la carpeta correspondiente (por ejemplo, la carpeta de tu aplicación o **JasperReports\lib**).
{{% /alert %}}

## **Limitación de la versión de evaluación**
La versión de evaluación de Aspose.Slides for JasperReports (sin una licencia especificada) exporta cada página del informe, pero coloca una marca de agua de evaluación en el centro de cada diapositiva o página, en los cuatro formatos de salida (PPT, PPTX, PDF y HTML), como se muestra en la figura siguiente. Consulta [Evaluar Aspose.Slides](/slides/es/jasperreports/evaluate-aspose-slides/) para más detalles.

![La marca de agua de evaluación en el centro de una diapositiva exportada](evaluation_watermark.png)

## **Aplicar una licencia**
Existen varias formas de aplicar una licencia, dependiendo de si trabajas con JasperReports o con JasperServer.

### **Aplicar una licencia para JasperReports**
Llama al método `setLicense` de la clase `License` con un flujo que lea el archivo de licencia, como en Aspose.Slides for Java:

```java
import java.io.FileInputStream;

import com.aspose.slides.jasperreports.License;

public class ApplyLicense {
    public static void main(String[] args) {
        try {
            // Crear un objeto de flujo que contenga el archivo de licencia.
            FileInputStream fstream = new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");

            // Instanciar la clase License.
            License license = new License();

            // Establecer la licencia a través del objeto de flujo.
            license.setLicense(fstream);
        } catch (Exception ex) {
            System.out.println(ex.toString());
        }
    }
}
```

O bien, pasa la ruta del archivo de licencia al exportador en el parámetro `ASExporterParameters.PPT_LICENSE`. En este fragmento, `jasperPrint` es un informe rellenado, como en [Tu primera exportación](/slides/es/jasperreports/#your-first-export):

```java
ASPptExporter exporter = new ASPptExporter();
exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "report.ppt");
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **Aplicar una licencia en JasperServer**
Establece la propiedad `licenseFile` del bean `pptExportParameters` en *applicationContext.xml* a la ruta del archivo de licencia, como se muestra en [Integración con JasperServer](/slides/es/jasperreports/integration-with-jasperserver/#set-font-mapping-and-the-license).