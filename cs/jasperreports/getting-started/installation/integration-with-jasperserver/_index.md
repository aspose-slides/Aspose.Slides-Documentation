---
title: Integrace s JasperServer
type: docs
weight: 45
url: /cs/jasperreports/integration-with-jasperserver/
---
{{% alert color="primary" %}} 

Chcete-li integrovat Aspose.Slides pro JasperReports s JasperServer, je nutné provést několik dalších kroků a aktualizovat konfigurační soubory JasperServer. Tento článek vysvětluje, jak na to.

{{% /alert %}} 

1. Přidejte nové vlastnosti exportéru do konfiguračního souboru **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\flows\viewReportBeans.xml**.

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
    <!-- přidejte tento záznam do exporterConfigMap -->
    <entry key="ppt" value-ref="pptExporterConfiguration"/>
</util:map>
```

2. Zkopírujte **aspose.slides.jasperreports.jar** do **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\lib**.
3. Chcete-li použít funkci mapování písem, aktualizujte **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\applicationContext.xml** níže uvedeným způsobem.

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