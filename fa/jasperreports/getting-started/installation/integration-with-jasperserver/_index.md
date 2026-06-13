---
title: یکپارچه‌سازی با JasperServer
type: docs
weight: 45
url: /fa/jasperreports/integration-with-jasperserver/
---
{{% alert color="primary" %}} 

برای ادغام Aspose.Slides for JasperReports با JasperServer، لازم است چندین مرحلهٔ اضافی انجام داده و فایل‌های پیکربندی JasperServer را به‌روز کنید. این مقاله توضیح می‌دهد چگونه.

{{% /alert %}} 

1. خصوصیات جدید exporter را به فایل پیکربندی **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\flows\viewReportBeans.xml** اضافه کنید.

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
    <!-- این ورودی را به exporterConfigMap اضافه کنید -->
    <entry key="ppt" value-ref="pptExporterConfiguration"/>
</util:map>
```

2. فایل **aspose.slides.jasperreports.jar** را به **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\lib** کپی کنید.
3. برای استفاده از ویژگی نگاشت فونت، **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\applicationContext.xml** را همان‌طور که در زیر نشان داده شده به‌روز کنید.

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