---
title: Интеграция с JasperServer
type: docs
weight: 45
url: /ru/jasperreports/integration-with-jasperserver/
description: "Добавьте экспортёры Aspose.Slides for JasperReports в JasperReports Server: скопируйте JAR‑файлы, зарегистрируйте экспортёр PowerPoint и настройте сопоставление шрифтов и лицензию."
---
## **Скопируйте JAR‑файлы**

Скопируйте оба JAR‑файла — *aspose.slides.jasperreports.library-xx.x.jar* и *aspose.slides.jasperreports.server-xx.x.jar* — в **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\lib**. Возьмите их из той же подпапки *lib* в загруженном архиве: из той, которая соответствует версии JasperReports, используемой вашим сервером. Смотрите [Installing Aspose.Slides for JasperReports](/slides/ru/jasperreports/installing-aspose-slides-for-jasperreports/) для диапазонов версий.

## **Зарегистрировать экспортёр**

Добавьте новые bean‑ы экспортера в конфигурационный файл **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\flows\viewReportBeans.xml**. Класс `ASPptReportExporter` находится в серверном JAR‑файле; тот же JAR также содержит `ASPptxReportExporter`, `ASPdfReportExporter` и `ASHtmlReportExporter`.

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
    <!-- добавьте эту запись в exporterConfigMap -->
    <entry key="ppt" value-ref="pptExporterConfiguration"/>
</util:map>
```

## **Настройка сопоставления шрифтов и лицензии**

Определите bean `pptExportParameters`, на который ссылается экспортёр, в файле **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\applicationContext.xml**. Его свойство `fontMap` сопоставляет имена шрифтов, используемых в отчётах, с шрифтами, записываемыми в презентацию, а свойство `licenseFile` задаёт путь к вашему файлу лицензии.

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
Указывайте каждый ключ `fontMap` точно так же, как в отчёте называется шрифт, включая регистр: ключ `sansserif` не заменит шрифт по умолчанию в JasperReports, `SansSerif`. Каждое значение должно быть шрифтом, который Java обнаруживает на сервере, иначе экспортеры игнорируют запись. Например, в Windows Java находит `Courier New`, но не `Courier`. См. [Map fonts](/slides/ru/jasperreports/ppt-pptx-pdf-and-html-export/#map-fonts).
{{% /alert %}}