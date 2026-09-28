---
title: Integration with JasperServer
type: docs
weight: 45
url: /jasperreports/integration-with-jasperserver/
description: "Add the Aspose.Slides for JasperReports exporters to JasperReports Server: copy the jars, register the PowerPoint exporter, and set font mapping and the license."
---

## **Copy the jars**

Copy both jars — *aspose.slides.jasperreports.library-xx.x.jar* and *aspose.slides.jasperreports.server-xx.x.jar* — to **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\lib**. Take them from the same subfolder of the download's *lib* folder: the one that covers the JasperReports version your server runs. See [Installing Aspose.Slides for JasperReports](/slides/jasperreports/installing-aspose-slides-for-jasperreports/) for the version ranges.

## **Register the exporter**

Add the new exporter beans to the **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\flows\viewReportBeans.xml** config file. The `ASPptReportExporter` class is in the server jar; the same jar also has `ASPptxReportExporter`, `ASPdfReportExporter` and `ASHtmlReportExporter`.

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
    <!-- add this entry to exporterConfigMap -->
    <entry key="ppt" value-ref="pptExporterConfiguration"/>
</util:map>
```

## **Set font mapping and the license**

Define the `pptExportParameters` bean that the exporter refers to in **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\applicationContext.xml**. Its `fontMap` property maps the font names used in reports to the fonts written to the presentation, and its `licenseFile` property sets the path to your license file.

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

{{% alert color="warning" title="Warning" %}}
Write each `fontMap` key exactly as the report names the font, including case: a `sansserif` key does not replace JasperReports' default font, `SansSerif`. Each value must be a font that Java finds on the server, or the exporters ignore the entry. On Windows, for example, Java finds `Courier New` but not `Courier`. See [Map fonts](/slides/jasperreports/ppt-pptx-pdf-and-html-export/#map-fonts).
{{% /alert %}}
