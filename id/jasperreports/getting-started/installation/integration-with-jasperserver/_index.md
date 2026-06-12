---
title: Integrasi dengan JasperServer
type: docs
weight: 45
url: /id/jasperreports/integration-with-jasperserver/
---
{{% alert color="primary" %}} 

Untuk mengintegrasikan Aspose.Slides for JasperReports dengan JasperServer, diperlukan beberapa langkah tambahan dan memperbarui file konfigurasi JasperServer. Artikel ini menjelaskan caranya.

{{% /alert %}} 

1. Tambahkan properti exporter baru ke file konfigurasi **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\flows\viewReportBeans.xml**.

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
    <!-- tambahkan entri ini ke exporterConfigMap -->
    <entry key="ppt" value-ref="pptExporterConfiguration"/>
</util:map>
```

2. Salin **aspose.slides.jasperreports.jar** ke **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\lib**.
3. Untuk menggunakan fitur pemetaan font, perbarui **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\applicationContext.xml** seperti di bawah ini.

``` xml
<bean id="pptExportParameters" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="fontMap">
        <util:map id="fontMap">
            <entry key="sansserif" value="Arial"/>
            <entry key="serif" value="Times New Roman"/>
            <entry key="monospaced" value="Courier"/>
        </util:map>
    </property>
    <property name="needAlterText" value="false"/>
    <property name="licenseFile" value="C:/jasperserver-XX/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```