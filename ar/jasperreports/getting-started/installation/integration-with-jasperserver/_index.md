---
title: التكامل مع JasperServer
type: docs
weight: 45
url: /ar/jasperreports/integration-with-jasperserver/
---

{{% alert color="primary" %}} 

لتكامل Aspose.Slides لـ JasperReports مع JasperServer، من الضروري اتخاذ عدة خطوات إضافية وتحديث ملفات تكوين JasperServer. يشرح هذا المقال كيفية القيام بذلك.

{{% /alert %}} 

1. أضف خصائص جديدة للمصدر إلى ملف التكوين **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\flows\viewReportBeans.xml**.

``` xml
<bean id="reportPptExporter" class="com.aspose.slides.jasperreports.ASPptReportExporter" parent="baseReportExporter">
    <property name="exportParameters" ref="pptExportParameters"/>
    <property name="setResponseContentLength" value="true"/>
</bean> 

<bean id="pptExporterConfiguration" class="com.jaspersoft.jasperserver.war.action.ExporterConfigurationBean">
    <property name="descriptionKey" value="عرض تقديمي PowerPoint عبر Aspose.Slides"/>
    <property name="iconSrc" value="/images/ppt.png"/>
    <property name="parameterDialogName" value=""/>
    <property name="exportParameters" ref="pptExportParameters"/>
    <property name="currentExporter" ref="reportPptExporter"/>
</bean>

<util:map id="exporterConfigMap">
    <!-- أضف هذه الإدخالات إلى exporterConfigMap -->
    <entry key="ppt" value-ref="pptExporterConfiguration"/>
</util:map>
```

2. انسخ **aspose.slides.jasperreports.jar** إلى **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\lib**.
3. لاستخدام ميزة تعيين الخطوط، قم بتحديث **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\applicationContext.xml** كما يلي.

``` xml
<bean id="pptExportParameters" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="fontMap">
        <util:map id="fontMap">
            <entry key="sansserif" value="Arial"/>
            <entry key="serif" value="Times New Roman"/>
            <entry key="monospaced" value="Courier"/>
        </util:map>
    </property>
    <property name="needAlterText" value="false"/>
    <property name="licenseFile" value="C:/jasperserver-XX/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```