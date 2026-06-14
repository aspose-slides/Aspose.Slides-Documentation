---
title: Tích hợp với JasperServer
type: docs
weight: 45
url: /vi/jasperreports/integration-with-jasperserver/
---
{{% alert color="primary" %}} 

Để tích hợp Aspose.Slides cho JasperReports với JasperServer, cần thực hiện một số bước bổ sung và cập nhật các tệp cấu hình JasperServer. Bài viết này giải thích cách thực hiện.

{{% /alert %}} 

1. Thêm các thuộc tính xuất khẩu mới vào tệp cấu hình **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\flows\viewReportBeans.xml**.

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
    <!-- thêm mục này vào exporterConfigMap -->
    <entry key="ppt" value-ref="pptExporterConfiguration"/>
</util:map>
```

2. Sao chép **aspose.slides.jasperreports.jar** tới **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\lib**.
3. Để sử dụng tính năng ánh xạ phông chữ, cập nhật **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\applicationContext.xml** như dưới đây.

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