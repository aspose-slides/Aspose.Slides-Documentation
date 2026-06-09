---
title: Ενσωμάτωση με JasperServer
type: docs
weight: 45
url: /el/jasperreports/integration-with-jasperserver/
---
{{% alert color="primary" %}} 
Για να ενσωματώσετε το Aspose.Slides for JasperReports με το JasperServer, είναι απαραίτητο να κάνετε μερικά επιπλέον βήματα και να ενημερώσετε τα αρχεία διαμόρφωσης του JasperServer. Αυτό το άρθρο εξηγεί πώς.
{{% /alert %}} 
1. Προσθέστε νέες ιδιότητες εξαγωγέα στο **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\flows\viewReportBeans.xml** αρχείο διαμόρφωσης.

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
    <!-- προσθέστε αυτήν την καταχώρηση στο exporterConfigMap -->
    <entry key="ppt" value-ref="pptExporterConfiguration"/>
</util:map>
```

2. Αντιγράψτε το **aspose.slides.jasperreports.jar** στο **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\lib**.
3. Για να χρησιμοποιήσετε τη λειτουργία αντιστοίχησης γραμματοσειρών, ενημερώστε το **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\applicationContext.xml** όπως παρακάτω.

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