---
title: Integration mit JasperServer
type: docs
weight: 45
url: /jasperreports/integration-with-jasperserver/
---

{{% alert color="primary" %}} 

Um Aspose.Slides für JasperReports mit JasperServer zu integrieren, müssen mehrere zusätzliche Schritte unternommen und die JasperServer-Konfigurationsdateien aktualisiert werden. Dieser Artikel erklärt, wie das geht.

{{% /alert %}} 

1. Fügen Sie neue Exporteigenschaften zur **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\flows\viewReportBeans.xml** Konfigurationsdatei hinzu.

``` xml
<bean id="reportPptExporter" class="com.aspose.slides.jasperreports.ASPptReportExporter" parent="baseReportExporter">
    <property name="exportParameters" ref="pptExportParameters"/>
    <property name="setResponseContentLength" value="true"/>
</bean> 

<bean id="pptExporterConfiguration" class="com.jaspersoft.jasperserver.war.action.ExporterConfigurationBean">
    <property name="descriptionKey" value="PowerPoint-Präsentation über Aspose.Slides"/>
    <property name="iconSrc" value="/images/ppt.png"/>
    <property name="parameterDialogName" value=""/>
    <property name="exportParameters" ref="pptExportParameters"/>
    <property name="currentExporter" ref="reportPptExporter"/>
</bean>

<util:map id="exporterConfigMap">
    <!-- fügen Sie diesen Eintrag zu exporterConfigMap hinzu -->
    <entry key="ppt" value-ref="pptExporterConfiguration"/>
</util:map>
```

2. Kopieren Sie **aspose.slides.jasperreports.jar** nach **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\lib**.
3. Um die Schriftarten-Zuordnungsfunktion zu verwenden, aktualisieren Sie **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\applicationContext.xml** wie unten.

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