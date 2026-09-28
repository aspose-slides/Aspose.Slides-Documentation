---
title: Integráció a JasperServerrel
type: docs
weight: 45
url: /hu/jasperreports/integration-with-jasperserver/
description: "Adja hozzá az Aspose.Slides for JasperReports exportálókat a JasperReports Serverhez: másolja a jar fájlokat, regisztrálja a PowerPoint exportálót, és állítsa be a betűtípus-leképezést és a licencet."
---
## **Másolja a jar fájlokat**

Másolja mindkét jar‑t — *aspose.slides.jasperreports.library-xx.x.jar* és *aspose.slides.jasperreports.server-xx.x.jar* — a **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\lib** könyvtárba. Vegye őket a letöltés *lib* mappájának ugyanabból az almappájából: abból, amely a JasperReports verzióját lefedi, amelyet a szervere futtat. Lásd a [Installing Aspose.Slides for JasperReports](/slides/hu/jasperreports/installing-aspose-slides-for-jasperreports/) oldalt a verziótartományokért.

## **Regisztrálja az exportálót**

Adja hozzá az új exportáló bean-eket a **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\flows\viewReportBeans.xml** konfigurációs fájlhoz. Az `ASPptReportExporter` osztály a szerver jar‑ban van; ugyanabban a jar‑ban megtalálhatók a `ASPptxReportExporter`, `ASPdfReportExporter` és `ASHtmlReportExporter` is.

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

## **Állítsa be a betűtípus‑leképezést és a licencet**

Határozza meg a `pptExportParameters` bean‑t, amelyre az exportáló a **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\applicationContext.xml**‑ben hivatkozik. A `fontMap` tulajdonság leképezi a jelentésekben használt betűtípus‑neveket a prezentációba írt betűtípusokra, a `licenseFile` tulajdonság pedig beállítja a licencfájl elérési útját.

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
Írja be minden `fontMap` kulcsot pontosan úgy, ahogy a jelentés a betűtípust nevezi, beleértve a kis- és nagybetűket: egy `sansserif` kulcs nem helyettesíti a JasperReports alapértelmezett betűtípusát, a `SansSerif`‑t. Minden értéknek olyan betűtípusnak kell lennie, amelyet a Java megtalál a szerveren, különben az exportálók figyelmen kívül hagyják a bejegyzést. Windows esetén például a Java megtalálja a `Courier New`‑t, de nem a `Courier`‑t. Lásd a [Map fonts](/slides/hu/jasperreports/ppt-pptx-pdf-and-html-export/#map-fonts) oldalt.
{{% /alert %}}