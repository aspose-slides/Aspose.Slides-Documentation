---
title: Ενσωμάτωση με JasperServer
type: docs
weight: 45
url: /el/jasperreports/integration-with-jasperserver/
---
{{% alert color="info" %}} 
Για την ενσωμάτωση του Aspose.Slides for JasperReports με το JasperServer, είναι απαραίτητο να γίνουν αρκετά πρόσθετα βήματα και να ενημερωθούν τα αρχεία ρυθμίσεων του JasperServer. Αυτό το άρθρο εξηγεί πώς.
{{% /alert %}} 

1. Προσθήκη νέων ιδιοτήτων εξαγωγέα στο αρχείο ρυθμίσεων **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\flows\viewReportBeans.xml**.
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

2. Αντιγραφή του **aspose.slides.jasperreports.jar** στο **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\lib**.
3. Για χρήση της λειτουργίας αντιστοίχισης γραμματοσειρών, ενημερώστε το **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\applicationContext.xml** όπως φαίνεται παρακάτω.
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