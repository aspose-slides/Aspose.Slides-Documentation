---
title: Integration med JasperServer
type: docs
weight: 45
url: /sv/jasperreports/integration-with-jasperserver/
description: "Lägg till Aspose.Slides för JasperReports-exportörer i JasperReports Server: kopiera jar-filerna, registrera PowerPoint-exportören och ställ in teckenkartläggning samt licensen."
---
## **Kopiera jar-filerna**

Kopiera båda jar-filerna — *aspose.slides.jasperreports.library-xx.x.jar* och *aspose.slides.jasperreports.server-xx.x.jar* — till **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\lib**. Hämta dem från samma undermapp i nedladdningens *lib*-mapp: den som motsvarar den JasperReports-version som din server kör. Se [Installing Aspose.Slides for JasperReports](/slides/sv/jasperreports/installing-aspose-slides-for-jasperreports/) för versionsintervallen.

## **Registrera exportören**

Lägg till de nya exportör-beanarna i konfigurationsfilen **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\flows\viewReportBeans.xml**. Klassen `ASPptReportExporter` finns i server-jar-filen; samma jar-fil innehåller också `ASPptxReportExporter`, `ASPdfReportExporter` och `ASHtmlReportExporter`.

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

## **Ställ in teckenkartläggning och licensen**

Definiera bean `pptExportParameters` som exportören refererar till i **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\applicationContext.xml**. Dess egenskap `fontMap` mappar teckensnittens namn som används i rapporterna till de teckensnitt som skrivs till presentationen, och egenskapen `licenseFile` anger sökvägen till din licensfil.

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
Skriv varje `fontMap`-nyckel exakt som rapporten namnger teckensnittet, inklusive skiftläge: en `sansserif`-nyckel ersätter inte JasperReports standardteckensnitt, `SansSerif`. Varje värde måste vara ett teckensnitt som Java hittar på servern, annars ignorerar exportörerna posten. På Windows hittar Java till exempel `Courier New` men inte `Courier`. Se [Map fonts](/slides/sv/jasperreports/ppt-pptx-pdf-and-html-export/#map-fonts).
{{% /alert %}}