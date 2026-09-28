---
title: การบูรณาการกับ JasperServer
type: docs
weight: 45
url: /th/jasperreports/integration-with-jasperserver/
description: "เพิ่มตัวส่งออก Aspose.Slides สำหรับ JasperReports ไปยัง JasperReports Server: คัดลอกไฟล์ jar, ลงทะเบียนตัวส่งออก PowerPoint, และตั้งค่าการแมปฟอนต์และใบอนุญาต."
---
## **คัดลอกไฟล์ jar**

คัดลอกไฟล์ jar ทั้งสองไฟล์ — *aspose.slides.jasperreports.library-xx.x.jar* และ *aspose.slides.jasperreports.server-xx.x.jar* — ไปยัง **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\lib**. นำไฟล์เหล่านี้จากโฟลเดอร์ย่อยเดียวกันของโฟลเดอร์ *lib* ในไฟล์ดาวน์โหลด: โฟลเดอร์ที่ตรงกับเวอร์ชัน JasperReports ที่เซิร์ฟเวอร์ของคุณใช้งาน. ดู [การติดตั้ง Aspose.Slides สำหรับ JasperReports](/slides/th/jasperreports/installing-aspose-slides-for-jasperreports/) เพื่อดูช่วงเวอร์ชัน.

## **ลงทะเบียนตัวส่งออก**

เพิ่ม beans ตัวส่งออกใหม่ไปยังไฟล์กำหนดค่า **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\flows\viewReportBeans.xml**. คลาส `ASPptReportExporter` อยู่ในไฟล์ jar ของเซิร์ฟเวอร์; ไฟล์ jar เดียวกันยังมี `ASPptxReportExporter`, `ASPdfReportExporter` และ `ASHtmlReportExporter`.

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

## **ตั้งค่าการแมปฟอนต์และใบอนุญาต**

กำหนด bean `pptExportParameters` ที่ตัวส่งออกอ้างอิงใน **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\applicationContext.xml**. คุณสมบัติ `fontMap` ของมันจะแมปชื่อฟอนต์ที่ใช้ในรายงานไปยังฟอนต์ที่เขียนลงในงานนำเสนอ, และคุณสมบัติ `licenseFile` ของมันตั้งค่าพาธไปยังไฟล์ใบอนุญาตของคุณ.

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
เขียนคีย์ `fontMap` แต่ละรายการให้ตรงกับชื่อฟอนต์ในรายงานอย่างแม่นยำ รวมถึงรูปแบบตัวอักษร: คีย์ `sansserif` ไม่ได้แทนที่ฟอนต์เริ่มต้นของ JasperReports คือ `SansSerif`. ค่าแต่ละค่าต้องเป็นฟอนต์ที่ Java พบบนเซิร์ฟเวอร์, ไม่เช่นนั้นตัวส่งออกจะละเว้นรายการนั้น. บน Windows, ตัวอย่างเช่น, Java พบ `Courier New` แต่ไม่พบ `Courier`. ดู [แมปฟอนต์](/slides/th/jasperreports/ppt-pptx-pdf-and-html-export/#map-fonts).
{{% /alert %}}