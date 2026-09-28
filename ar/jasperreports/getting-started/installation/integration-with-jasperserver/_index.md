---
title: "التكامل مع JasperServer"
type: docs
weight: 45
url: /ar/jasperreports/integration-with-jasperserver/
description: "أضف مُصدّري Aspose.Slides لـ JasperReports إلى خادم JasperReports: انسخ الحزم، سجّل مُصدّر PowerPoint، وحدد تعيين الخطوط والترخيص."
---
## **نسخ الحزم**

انسخ كل من الحزمتين — *aspose.slides.jasperreports.library-xx.x.jar* و *aspose.slides.jasperreports.server-xx.x.jar* — إلى **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\lib**. احصل عليهما من نفس المجلد الفرعي داخل مجلد *lib* الخاص بعملية التنزيل: الذي يتطابق مع إصدار JasperReports الذي يعمل به الخادم الخاص بك. راجع [Installing Aspose.Slides for JasperReports](/slides/ar/jasperreports/installing-aspose-slides-for-jasperreports/) لمعرفة نطاقات الإصدارات.

## **تسجيل المُصدِّر**

أضف كائنات المُصدِّر الجديدة إلى ملف التكوين **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\flows\viewReportBeans.xml**. الفئة `ASPptReportExporter` موجودة في حزمة الخادم؛ تحتوي نفس الحزمة أيضًا على `ASPptxReportExporter` و `ASPdfReportExporter` و `ASHtmlReportExporter`.

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
    <!-- أضف هذا الإدخال إلى exporterConfigMap -->
    <entry key="ppt" value-ref="pptExporterConfiguration"/>
</util:map>
```

## **ضبط تعيين الخطوط والترخيص**

عرّف كائن `pptExportParameters` الذي يشير إليه المُصدّر في **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\applicationContext.xml**. الخاصية `fontMap` تقوم بتعيين أسماء الخطوط المستخدمة في التقارير إلى الخطوط التي تُكتب في العرض التقديمي، وتحدد الخاصية `licenseFile` مسار ملف الترخيص الخاص بك.

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
اكتب كل مفتاح في `fontMap` بالضبط كما هو مذكور في تقارير الخط، بما في ذلك الحالة: المفتاح `sansserif` لا يستبدل الخط الافتراضي في JasperReports، وهو `SansSerif`. يجب أن تكون كل قيمة خطاً يمكن لـ Java العثور عليه على الخادم، وإلا سيتجاهل المُصدِّر هذا الإدخال. على نظام Windows، على سبيل المثال، Java يجد الخط `Courier New` لكن ليس `Courier`. راجع [Map fonts](/slides/ar/jasperreports/ppt-pptx-pdf-and-html-export/#map-fonts).
{{% /alert %}}