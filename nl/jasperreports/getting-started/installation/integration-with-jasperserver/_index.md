---
title: Integratie met JasperServer
type: docs
weight: 45
url: /nl/jasperreports/integration-with-jasperserver/
description: "Voeg de Aspose.Slides for JasperReports exporters toe aan JasperReports Server: kopieer de jars, registreer de PowerPoint-exporter en stel de lettertype-mapping en de licentie in."
---
## **Kopieer de jars**

Kopieer beide jars — *aspose.slides.jasperreports.library-xx.x.jar* en *aspose.slides.jasperreports.server-xx.x.jar* — naar **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\lib**. Haal ze uit dezelfde submap van de download‑*lib* map: die waarin de JasperReports‑versie staat die uw server gebruikt. Zie [Installing Aspose.Slides for JasperReports](/slides/nl/jasperreports/installing-aspose-slides-for-jasperreports/) voor de versiebereiken.

## **Registreer de exporter**

Voeg de nieuwe exporter‑beans toe aan het configuratiebestand **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\flows\viewReportBeans.xml**. De klasse `ASPptReportExporter` bevindt zich in de server‑jar; dezelfde jar bevat ook `ASPptxReportExporter`, `ASPdfReportExporter` en `ASHtmlReportExporter`.

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
    <!-- voeg dit item toe aan exporterConfigMap -->
    <entry key="ppt" value-ref="pptExporterConfiguration"/>
</util:map>
```

## **Stel lettertype‑mapping en de licentie in**

Definieer de bean `pptExportParameters` waarnaar de exporter verwijst in **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\applicationContext.xml**. Zijn eigenschap `fontMap` koppelt de lettertypenamen die in rapporten worden gebruikt aan de lettertypen die in de presentatie worden geschreven, en zijn eigenschap `licenseFile` stelt het pad naar uw licentiebestand in.

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
Schrijf elke `fontMap`‑sleutel exact zoals het rapport het lettertype noemt, inclusief hoofdlettergebruik: een `sansserif`‑sleutel vervangt niet het standaardlettertype van JasperReports, `SansSerif`. Elke waarde moet een lettertype zijn dat Java op de server vindt, anders negeren de exporters de invoer. Op Windows vindt Java bijvoorbeeld `Courier New` maar niet `Courier`. Zie [Map fonts](/slides/nl/jasperreports/ppt-pptx-pdf-and-html-export/#map-fonts).
{{% /alert %}}