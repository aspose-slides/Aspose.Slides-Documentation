---
title: یکپارچه‌سازی با JasperServer
type: docs
weight: 45
url: /fa/jasperreports/integration-with-jasperserver/
description: "صادرکننده‌های Aspose.Slides برای JasperReports را به سرور JasperReports اضافه کنید: جارها را کپی کنید، صادرکننده PowerPoint را ثبت کنید و نگاشت قلم‌ها و لایسنس را تنظیم کنید."
---
## **کپی کردن جارها**

هر دو جار — *aspose.slides.jasperreports.library-xx.x.jar* و *aspose.slides.jasperreports.server-xx.x.jar* — را به **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\lib** کپی کنید. آنها را از همان زیرپوشه‌ی پوشه *lib* دانلود گرفته‌اید: پوشه‌ای که نسخه JasperReportsی که سرور شما اجرا می‌کند را پوشش می‌دهد. برای بازه‌های نسخه، به [Installing Aspose.Slides for JasperReports](/slides/fa/jasperreports/installing-aspose-slides-for-jasperreports/) مراجعه کنید.

## **ثبت صادرات‌کننده**

ابزارهای صادرات‌کننده جدید را به فایل پیکربندی **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\flows\viewReportBeans.xml** اضافه کنید. کلاس `ASPptReportExporter` در جار سرور قرار دارد؛ همان جار همچنین شامل `ASPptxReportExporter`، `ASPdfReportExporter` و `ASHtmlReportExporter` است.

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
    <!-- این ورودی را به exporterConfigMap اضافه کنید -->
    <entry key="ppt" value-ref="pptExporterConfiguration"/>
</util:map>
```

## **تنظیم نگاشت قلم‌ها و لایسنس**

Bean `pptExportParameters` را که صادرات‌کننده به آن ارجاع می‌دهد، در **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\applicationContext.xml** تعریف کنید. ویژگی `fontMap` آن نام‌های قلم استفاده‌شده در گزارش‌ها را به قلم‌هایی که در ارائه نوشته می‌شوند، نگاشت می‌کند و ویژگی `licenseFile` مسیر فایل لایسنس شما را تنظیم می‌نماید.

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
هر کلید `fontMap` را دقیقاً همان‌طور که نام قلم در گزارش آمده است، شامل حروف بزرگ و کوچک، بنویسید: کلید `sansserif` قلم پیش‌فرض JasperReports، `SansSerif` را جایگزین نمی‌کند. هر مقدار باید قلمی باشد که Java در سرور پیدا می‌کند، در غیر این صورت صادرات‌کننده آن ورودی را نادیده می‌گیرد. برای مثال، در ویندوز Java قلم `Courier New` را می‌یابد اما `Courier` را نه. به [Map fonts](/slides/fa/jasperreports/ppt-pptx-pdf-and-html-export/#map-fonts) مراجعه کنید.
{{% /alert %}}