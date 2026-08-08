---
title: Licencias
type: docs
weight: 50
url: /es/jasperreports/licensing/
---
{{% alert color="primary" %}} 

Aspose.Slides para JasperReports está disponible como una evaluación gratuita e ilimitada de tiempo desde la [página de descarga](https://downloads.aspose.com/slides/es/jasperreport). La versión de evaluación y la versión licenciada del producto se descargan desde el mismo enlace.

Cuando estés satisfecho con la evaluación, [compra una licencia](https://purchase.aspose.com/buy). Asegúrate de comprender y aceptar los términos de suscripción.

La licencia está disponible para su descarga en la página del pedido una vez que el pedido haya sido pagado. La licencia es un archivo XML de texto claro, firmado digitalmente, que contiene información como el nombre del cliente, el producto adquirido y el tipo de licencia. No modifiques el contenido del archivo de licencia de ninguna manera: hacerlo invalida la licencia.

Descarga la licencia a tu equipo y cópiala en la carpeta adecuada (por ejemplo, la carpeta de tu aplicación o **JasperReports\lib**).
{{% /alert %}}

## **Limitación de la versión de evaluación**
La versión de evaluación de Aspose.Slides (sin una licencia especificada) ofrece la funcionalidad completa del producto, pero (al guardar tus presentaciones) inserta una marca de agua de evaluación en el centro de cada diapositiva, como se muestra en la figura a continuación:

![todo:image_alt_text](evaluation_watermark.png) 

## **Aplicar una licencia**
Hay varias formas de aplicar una licencia, dependiendo de si trabajas con JasperReports o con JasperServer.

### **Aplicar una licencia para JasperReports**
Utiliza una llamada directa al método setLicense similar a Aspose.Slides para Java.

```java
import com.aspose.slides.jasperreports.License;

..... 

try {
    //Crear un objeto de flujo que contenga el archivo de licencia
    FileInputStream fstream=new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");
	
    //Instanciar la clase License
    License license = new License();
	
    //Establecer la licencia a través del objeto de flujo
    license.setLicense(fstream);
} catch(Exception ex) {
    System.out.println(ex.toString());
}
```

O establece el parámetro del exportador en el código.

```java
ASPptExporter exporter = new ASPptExporter (); 
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **Aplicar una licencia en JasperServer**
Establece el parámetro del exportador en applicationContext.xml.

``` xml
<bean id="asExportParametersBean" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="licenseFile" value="C:/jasperserver-3.0/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```