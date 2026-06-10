---
title: Integráció a JasperServerrel
type: docs
weight: 45
url: /hu/jasperreports/integration-with-jasperserver/
---
{{% alert color="primary" %}} 

Az Aspose.Slides for JasperReports integrálásához a JasperServerrel több további lépésre van szükség, és frissíteni kell a JasperServer konfigurációs fájljait. Ez a cikk elmagyarázza, hogyan.

{{% /alert %}} 

1. Új exportáló tulajdonságokat adjon hozzá a **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\flows\viewReportBeans.xml** konfigurációs fájlhoz.

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
    <!-- adja hozzá ezt a bejegyzést az exporterConfigMap-hez -->
    <entry key="ppt" value-ref="pptExporterConfiguration"/>
</util:map>
```

2. Másolja a **aspose.slides.jasperreports.jar**-t a **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\lib** könyvtárba.
3. A betűtípusleképezés funkció használatához frissítse a **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\applicationContext.xml**-t az alábbiak szerint.

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