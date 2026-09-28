---
title: Integration mit JasperServer
type: docs
weight: 45
url: /de/jasperreports/integration-with-jasperserver/
description: "Fügen Sie die Aspose.Slides für JasperReports-Exporter zu JasperReports Server hinzu: Kopieren Sie die JARs, registrieren Sie den PowerPoint-Exporter und legen Sie die Schriftartenzuordnung sowie die Lizenz fest."
---
## **JAR-Dateien kopieren**

Kopieren Sie beide JARs — *aspose.slides.jasperreports.library-xx.x.jar* und *aspose.slides.jasperreports.server-xx.x.jar* — nach **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\lib**. Nehmen Sie sie aus demselben Unterordner des *lib*-Ordners des Downloads: demjenigen, der zur JasperReports-Version passt, die Ihr Server verwendet. Siehe [Installation von Aspose.Slides für JasperReports](/slides/de/jasperreports/installing-aspose-slides-for-jasperreports/) für die Versionsbereiche.

## **Exporter registrieren**

Fügen Sie die neuen Exporter‑Beans zur Konfigurationsdatei **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\flows\viewReportBeans.xml** hinzu. Die Klasse `ASPptReportExporter` befindet sich im Server‑Jar; dasselbe Jar enthält außerdem `ASPptxReportExporter`, `ASPdfReportExporter` und `ASHtmlReportExporter`.

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
    <!-- Fügen Sie diesen Eintrag zu exporterConfigMap hinzu -->
    <entry key="ppt" value-ref="pptExporterConfiguration"/>
</util:map>
```

## **Schriftartenzuordnung und Lizenz festlegen**

Definieren Sie den Bean `pptExportParameters`, auf den der Exporter in **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\applicationContext.xml** verweist. Seine `fontMap`‑Eigenschaft ordnet die in Berichten verwendeten Schriftarten den Schriftarten zu, die in die Präsentation geschrieben werden, und die `licenseFile`‑Eigenschaft legt den Pfad zu Ihrer Lizenzdatei fest.

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
Schreiben Sie jeden `fontMap`‑Schlüssel exakt so, wie im Bericht der Schriftartname angegeben ist, einschließlich Groß‑ und Kleinschreibung: Ein Schlüssel `sansserif` ersetzt nicht die Standardschrift von JasperReports, `SansSerif`. Jeder Wert muss eine Schriftart sein, die Java auf dem Server findet, sonst ignorieren die Exporter den Eintrag. Unter Windows findet Java beispielsweise `Courier New`, aber nicht `Courier`. Siehe [Schriftarten zuordnen](/slides/de/jasperreports/ppt-pptx-pdf-and-html-export/#map-fonts).
{{% /alert %}}