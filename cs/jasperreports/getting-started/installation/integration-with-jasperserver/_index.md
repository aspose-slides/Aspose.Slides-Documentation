---
title: Integrace s JasperServer
type: docs
weight: 45
url: /cs/jasperreports/integration-with-jasperserver/
description: "Přidejte exportéry Aspose.Slides pro JasperReports do JasperReports Server: zkopírujte soubory JAR, zaregistrujte exportér PowerPoint a nastavte mapování písem a licenci."
---
## **Zkopírujte soubory JAR**

Zkopírujte oba soubory JAR — *aspose.slides.jasperreports.library-xx.x.jar* a *aspose.slides.jasperreports.server-xx.x.jar* — do **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\lib**. Použijte je ze stejné podsložky ve složce *lib* staženého balíčku: té, která odpovídá verzi JasperReports, kterou váš server používá. Viz [Instalace Aspose.Slides pro JasperReports](/slides/cs/jasperreports/installing-aspose-slides-for-jasperreports/) pro rozsahy verzí.

## **Zaregistrujte exportér**

Přidejte nové bean‑y exportéru do konfiguračního souboru **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\flows\viewReportBeans.xml**. Třída `ASPptReportExporter` je v serverovém JARu; stejný JAR také obsahuje `ASPptxReportExporter`, `ASPdfReportExporter` a `ASHtmlReportExporter`.

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
    <!-- přidejte tuto položku do exporterConfigMap -->
    <entry key="ppt" value-ref="pptExporterConfiguration"/>
</util:map>
```

## **Nastavte mapování písem a licenci**

Definujte bean `pptExportParameters`, na který exportér odkazuje v **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\applicationContext.xml**. Jeho vlastnost `fontMap` mapuje názvy písem použité ve zprávách na písma zapisovaná do prezentace a jeho vlastnost `licenseFile` určuje cestu k vašemu licenčnímu souboru.

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

{{% alert color="warning" title="Upozornění" %}}
Zapište každý klíč `fontMap` přesně tak, jak se font jmenuje ve zprávě, včetně velkých a malých písmen: klíč `sansserif` nenahrazuje výchozí font JasperReports `SansSerif`. Každá hodnota musí být font, který Java najde na serveru, jinak exportéry položku ignorují. Ve Windows například Java najde `Courier New`, ale ne `Courier`. Viz [Mapování písem](/slides/cs/jasperreports/ppt-pptx-pdf-and-html-export/#map-fonts).
{{% /alert %}}