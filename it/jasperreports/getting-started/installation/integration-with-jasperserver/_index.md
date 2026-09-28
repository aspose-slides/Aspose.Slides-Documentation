---
title: Integrazione con JasperServer
type: docs
weight: 45
url: /it/jasperreports/integration-with-jasperserver/
description: "Aggiungi gli esportatori Aspose.Slides per JasperReports a JasperReports Server: copia i jar, registra l'esportatore PowerPoint e imposta la mappatura dei font e la licenza."
---
## **Copia i jar**

Copia entrambi i jar — *aspose.slides.jasperreports.library-xx.x.jar* e *aspose.slides.jasperreports.server-xx.x.jar* — in **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\lib**. Prendili dalla stessa sottocartella della cartella *lib* del download: quella che corrisponde alla versione di JasperReports in uso sul tuo server. Consulta [Installing Aspose.Slides for JasperReports](/slides/it/jasperreports/installing-aspose-slides-for-jasperreports/) per gli intervalli di versione.

## **Registra l'esportatore**

Aggiungi i nuovi bean dell'esportatore al file di configurazione **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\flows\viewReportBeans.xml**. La classe `ASPptReportExporter` si trova nel jar del server; lo stesso jar contiene anche `ASPptxReportExporter`, `ASPdfReportExporter` e `ASHtmlReportExporter`.

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

## **Imposta la mappatura dei font e la licenza**

Definisci il bean `pptExportParameters` a cui l'esportatore fa riferimento in **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\applicationContext.xml**. La sua proprietà `fontMap` associa i nomi dei font usati nei report ai font scritti nella presentazione, e la proprietà `licenseFile` imposta il percorso al tuo file di licenza.

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
Scrivi ogni chiave `fontMap` esattamente come il report denominano il font, includendo il case: una chiave `sansserif` non sostituisce il font predefinito di JasperReports, `SansSerif`. Ogni valore deve essere un font che Java trova sul server, altrimenti gli esportatori ignorano la voce. Su Windows, per esempio, Java trova `Courier New` ma non `Courier`. Consulta [Map fonts](/slides/it/jasperreports/ppt-pptx-pdf-and-html-export/#map-fonts).
{{% /alert %}}