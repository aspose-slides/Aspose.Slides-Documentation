---
title: การบูรณาการกับ JasperServer
type: docs
weight: 45
url: /th/jasperreports/integration-with-jasperserver/
---
{{% alert color="primary" %}} 

เพื่อผสานรวม Aspose.Slides for JasperReports กับ JasperServer จำเป็นต้องดำเนินการขั้นตอนเพิ่มเติมหลายขั้นตอนและอัปเดตไฟล์กำหนดค่า JasperServer บทความนี้อธิบายวิธีการทำ

{{% /alert %}} 

1. เพิ่มคุณสมบัติของ exporter ใหม่ในไฟล์กำหนดค่า **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\flows\viewReportBeans.xml** 

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
    <!-- เพิ่มรายการนี้ไปยัง exporterConfigMap -->
    <entry key="ppt" value-ref="pptExporterConfiguration"/>
</util:map>
```

2. คัดลอก **aspose.slides.jasperreports.jar** ไปยัง **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\lib**.

3. หากต้องการใช้คุณลักษณะการแมปฟอนต์ ให้ปรับปรุง **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\applicationContext.xml** ตามด้านล่าง

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