---
title: Integrazione con JasperServer
type: docs
weight: 45
url: /it/jasperreports/integration-with-jasperserver/
---
{{% alert color="primary" %}} 

Per integrare Aspose.Slides per JasperReports con JasperServer, è necessario eseguire diversi passaggi aggiuntivi e aggiornare i file di configurazione di JasperServer. Questo articolo spiega come.

{{% /alert %}} 

1. Aggiungere le nuove proprietà dell'esportatore al file di configurazione **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\flows\viewReportBeans.xml**.

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
    <!-- aggiungi questa voce a exporterConfigMap -->
    <entry key="ppt" value-ref="pptExporterConfiguration"/>
</util:map>
```

2. Copiare **aspose.slides.jasperreports.jar** in **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\lib**.
3. Per utilizzare la funzionalità di mapping dei font, aggiornare **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\applicationContext.xml** come mostrato di seguito.

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