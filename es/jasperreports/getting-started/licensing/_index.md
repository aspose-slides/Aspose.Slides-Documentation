---
title: Licencias
type: docs
weight: 50
url: /jasperreports/licensing/
---

{{% alert color="primary" %}} 

Aspose.Slides para JasperReports está disponible como una evaluación gratuita e ilimitada en el tiempo desde la [página de descargas](https://downloads.aspose.com/slides/jasperreport). La evaluación y las versiones con licencia del producto son la misma descarga.

Cuando estés contento con la evaluación, [compra una licencia](https://purchase.aspose.com/buy). Asegúrate de entender y aceptar los términos de suscripción.

La licencia está disponible para su descarga desde la página de pedido una vez que el pedido ha sido pagado. La licencia es un archivo XML en texto claro, firmado digitalmente, que contiene información como el nombre del cliente, el producto comprado y el tipo de licencia. No modifiques el contenido del archivo de licencia de ninguna manera: hacerlo invalida la licencia.

Descarga la licencia a tu computadora y cópiala en la carpeta adecuada (por ejemplo, tu carpeta de aplicación o **JasperReports\lib**).

## **Limitación de la Versión de Evaluación**
La versión de evaluación de Aspose.Slides (sin una licencia especificada) proporciona la funcionalidad completa del producto, pero (cuando guardas tus presentaciones) inyecta una marca de agua de evaluación en el centro de cada diapositiva, como se muestra en la figura a continuación:

![todo:image_alt_text](evaluation_watermark.png) 

## **Aplicar una Licencia**
Hay varias formas de aplicar una licencia, dependiendo de si estás trabajando en JasperReports o JasperServer.

### **Aplicar una Licencia para JasperReports**
Usa una llamada directa al método setLicense similar a Aspose.Slides para Java.

```java
import com.aspose.slides.jasperreports.License;

..... 

try {
    //Crea un objeto de flujo que contenga el archivo de licencia
    FileInputStream fstream=new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");
	
    //Instancia la clase License
    License license = new License();
	
    //Establece la licencia a través del objeto de flujo
    license.setLicense(fstream);
} catch(Exception ex) {
    System.out.println(ex.toString());
}
```

O, establece el parámetro del exportador en el código.

```java
ASPptExporter exporter = new ASPptExporter (); 
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **Aplicar una Licencia en JasperServer**
Establece el parámetro del exportador en el applicationContext.xml.

``` xml
<bean id="asExportParametersBean" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="licenseFile" value="C:/jasperserver-3.0/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```