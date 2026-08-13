---
title: Licencias
type: docs
weight: 50
url: /es/jasperreports/licensing/
---
{{% alert color="info" %}} 

Aspose.Slides for JasperReports está disponible como una evaluación gratuita ilimitada de tiempo desde la [página de descargas](https://downloads.aspose.com/slides/es/jasperreport). La versión de evaluación y la versión con licencia del producto se descargan desde el mismo enlace.

Cuando esté satisfecho con la evaluación, [comprar una licencia](https://purchase.aspose.com/buy). Asegúrese de comprender y aceptar los términos de suscripción.

La licencia está disponible para su descarga desde la página del pedido una vez que el pedido haya sido pagado. La licencia es un archivo XML en texto claro, firmado digitalmente, que contiene información como el nombre del cliente, el producto adquirido y el tipo de licencia. No modifique el contenido del archivo de licencia de ninguna manera: hacerlo invalida la licencia.

Descargue la licencia en su ordenador y cópiela en la carpeta adecuada (por ejemplo, la carpeta de su aplicación o **JasperReports\lib**).
{{% /alert %}}

## **Limitación de la versión de evaluación**
La versión de evaluación de Aspose.Slides (sin una licencia especificada) proporciona toda la funcionalidad del producto, pero (cuando guarda sus presentaciones) inserta una marca de agua de evaluación en el centro de cada diapositiva, como se muestra en la figura a continuación:

![todo:image_alt_text](evaluation_watermark.png) 

## **Aplicar una licencia**
Hay varias formas de aplicar una licencia, dependiendo de si está trabajando en JasperReports o en JasperServer.

### **Aplicar una licencia para JasperReports**
Utilice una llamada directa al método setLicense similar a Aspose.Slides for Java.

```java
import com.aspose.slides.jasperreports.License;

..... 

try {
    //Crear un objeto de flujo que contiene el archivo de licencia
    FileInputStream fstream=new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");
	
    //Instanciar la clase License
    License license = new License();
	
    //Establecer la licencia mediante el objeto de flujo
    license.setLicense(fstream);
} catch(Exception ex) {
    System.out.println(ex.toString());
}
```

O, establezca el parámetro exporter en el código.

```java
ASPptExporter exporter = new ASPptExporter (); 
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **Aplicar una licencia en JasperServer**
Establezca el parámetro exporter en el archivo applicationContext.xml.

``` xml
<bean id="asExportParametersBean" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="licenseFile" value="C:/jasperserver-3.0/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```