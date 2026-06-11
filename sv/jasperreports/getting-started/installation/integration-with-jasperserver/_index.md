---
title: Integration med JasperServer
type: docs
weight: 45
url: /sv/jasperreports/integration-with-jasperserver/
---
{{% alert color="primary" %}} 

För att integrera Aspose.Slides för JasperReports med JasperServer måste du utföra flera ytterligare steg och uppdatera JasperServer-konfigurationsfilerna. Denna artikel förklarar hur.

{{% /alert %}} 

1. Lägg till nya exportegenskaper i **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\flows\viewReportBeans.xml**-konfigurationsfilen.

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
    <!-- lägg till detta element i exporterConfigMap -->
    <entry key="ppt" value-ref="pptExporterConfiguration"/>
</util:map>
```

2. Kopiera **aspose.slides.jasperreports.jar** till **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\lib**.
3. För att använda teckensnittsmappningsfunktionen, uppdatera **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\applicationContext.xml** enligt nedan.

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