---
title: Integration with JasperServer
type: docs
weight: 50
url: /jasperreports/integration-with-jasperserver/
---

{{% alert color="primary" %}} 

To integrate Aspose.Slides for JasperReports with JasperServer, it is necessary to take several additional steps and update the JasperServer config files. This article explains how.

{{% /alert %}} 

1. Add new exporter properties to the **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\flows\viewReportBeans.xml** config file.

```

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

    <!-- add this entry to exporterConfigMap -->

    <entry key="ppt" value-ref="pptExporterConfiguration"/>

</util:map>



```

1. Copy **aspose.slides.jasperreports.jar** to **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\lib**.
1. To use the font mapping feature, update **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\applicationContext.xml** as below.

```

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
