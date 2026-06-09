---
title: JasperServer ile Entegrasyon
type: docs
weight: 45
url: /tr/jasperreports/integration-with-jasperserver/
---
{{% alert color="primary" %}} 

Aspose.Slides for JasperReports'u JasperServer ile bütünleştirmek için birkaç ek adım atmak ve JasperServer yapılandırma dosyalarını güncellemek gerekir. Bu makale nasıl yapılacağını açıklar.

{{% /alert %}} 

1. Yeni dışa aktarıcı özelliklerini **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\flows\viewReportBeans.xml** yapılandırma dosyasına ekleyin.

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
    <!-- exporterConfigMap'e bu girişi ekleyin -->
    <entry key="ppt" value-ref="pptExporterConfiguration"/>
</util:map>
```

2. **aspose.slides.jasperreports.jar** dosyasını **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\lib** dizinine kopyalayın.
3. Yazı tipi eşleme özelliğini kullanmak için, **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\applicationContext.xml** dosyasını aşağıdaki gibi güncelleyin.

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