---
title: Integracja z JasperServer
type: docs
weight: 45
url: /pl/jasperreports/integration-with-jasperserver/
description: "Dodaj eksportery Aspose.Slides for JasperReports do JasperReports Server: skopiuj pliki JAR, zarejestruj eksporter PowerPoint i ustaw mapowanie czcionek oraz licencję."
---
## **Skopiuj pliki JAR**

Skopiuj oba pliki JAR — *aspose.slides.jasperreports.library-xx.x.jar* i *aspose.slides.jasperreports.server-xx.x.jar* — do **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\lib**. Pobierz je z tego samego podfolderu folderu *lib* pobranego pakietu: tego, który odpowiada wersji JasperReports używanej przez serwer. Zobacz [Installing Aspose.Slides for JasperReports](/slides/pl/jasperreports/installing-aspose-slides-for-jasperreports/) aby poznać zakresy wersji.

## **Zarejestruj eksporter**

Dodaj nowe bean‑y eksportera do pliku konfiguracyjnego **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\flows\viewReportBeans.xml**. Klasa `ASPptReportExporter` znajduje się w pliku JAR serwera; ten sam plik JAR zawiera również `ASPptxReportExporter`, `ASPdfReportExporter` i `ASHtmlReportExporter`.

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
    <!-- dodaj ten wpis do exporterConfigMap -->
    <entry key="ppt" value-ref="pptExporterConfiguration"/>
</util:map>
```

## **Ustaw mapowanie czcionek i licencję**

Zdefiniuj bean `pptExportParameters`, do którego odwołuje się eksporter, w pliku **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\applicationContext.xml**. Jego właściwość `fontMap` mapuje nazwy czcionek używanych w raportach na czcionki zapisywane w prezentacji, a właściwość `licenseFile` określa ścieżkę do Twojego pliku licencji.

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
Zapisz każdy klucz `fontMap` dokładnie tak, jak raport określa czcionkę, uwzględniając wielkość liter: klucz `sansserif` nie zastępuje domyślnej czcionki JasperReports, `SansSerif`. Każda wartość musi być czcionką, którą Java znajduje na serwerze, w przeciwnym razie eksportery zignorują wpis. Na Windowsie, na przykład, Java znajduje `Courier New`, ale nie `Courier`. Zobacz [Map fonts](/slides/pl/jasperreports/ppt-pptx-pdf-and-html-export/#map-fonts).
{{% /alert %}}