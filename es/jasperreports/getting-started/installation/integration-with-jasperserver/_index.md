---
title: Integración con JasperServer
type: docs
weight: 45
url: /es/jasperreports/integration-with-jasperserver/
description: "Añada los exportadores de Aspose.Slides para JasperReports al servidor JasperReports: copie los JAR, registre el exportador PowerPoint y configure el mapeo de fuentes y la licencia."
---
## **Copiar los JAR**

Copie ambos JAR — *aspose.slides.jasperreports.library-xx.x.jar* y *aspose.slides.jasperreports.server-xx.x.jar* — en **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\lib**. Obténgalos de la misma subcarpeta del directorio *lib* de la descarga: la que corresponde a la versión de JasperReports que utiliza su servidor. Consulte [Instalando Aspose.Slides para JasperReports](/slides/es/jasperreports/installing-aspose-slides-for-jasperreports/) para conocer los rangos de versiones.

## **Registrar el exportador**

Añada los nuevos beans del exportador al archivo de configuración **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\flows\viewReportBeans.xml**. La clase `ASPptReportExporter` se encuentra en el JAR del servidor; el mismo JAR también contiene `ASPptxReportExporter`, `ASPdfReportExporter` y `ASHtmlReportExporter`.

``` xml
<bean id="reportPptExporter" class="com.aspose.slides.jasperreports.ASPptReportExporter" parent="baseReportExporter">
    <property name="exportParameters" ref="pptExportParameters"/>
    <property name="setResponseContentLength" value="true"/>
</bean>

<bean id="pptExporterConfiguration" class="com.jaspersoft.jasperserver.war.action.ExporterConfigurationBean">
    <property name="descriptionKey" value="PowerPoint Presentation via Aspose.Slides"/>
    <property name="iconSrc" value="/images/ppt.png"/>
    <property name="parameterDialogName" value=""/>
    <property name="exportParameters" ref="pptExportParameters"/>
    <property name="currentExporter" ref="reportPptExporter"/>
</bean>

<util:map id="exporterConfigMap">
    <!-- añada esta entrada a exporterConfigMap -->
    <entry key="ppt" value-ref="pptExporterConfiguration"/>
</util:map>
```

## **Establecer el mapeo de fuentes y la licencia**

Defina el bean `pptExportParameters` al que hace referencia el exportador en **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\applicationContext.xml**. Su propiedad `fontMap` asigna los nombres de fuente utilizados en los informes a las fuentes escritas en la presentación, y su propiedad `licenseFile` establece la ruta a su archivo de licencia.

``` xml
<bean id="pptExportParameters" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="fontMap">
        <util:map id="fontMap">
            <entry key="SansSerif" value="Arial"/>
            <entry key="Serif" value="Times New Roman"/>
            <entry key="Monospaced" value="Courier New"/>
        </util:map>
    </property>
    <property name="needAlterText" value="false"/>
    <property name="licenseFile" value="C:/jasperserver-XX/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```

{{% alert color="warning" title="Advertencia" %}}
Escriba cada clave `fontMap` exactamente como el informe nombra la fuente, incluyendo mayúsculas y minúsculas: una clave `sansserif` no sustituye la fuente predeterminada de JasperReports, `SansSerif`. Cada valor debe ser una fuente que Java encuentre en el servidor, de lo contrario los exportadores ignoran la entrada. En Windows, por ejemplo, Java encuentra `Courier New` pero no `Courier`. Consulte [Mapear fuentes](/slides/es/jasperreports/ppt-pptx-pdf-and-html-export/#map-fonts).
{{% /alert %}}