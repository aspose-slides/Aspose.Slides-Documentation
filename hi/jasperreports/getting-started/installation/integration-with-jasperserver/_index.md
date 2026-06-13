---
title: JasperServer के साथ एकीकरण
type: docs
weight: 45
url: /hi/jasperreports/integration-with-jasperserver/
---
{{% alert color="primary" %}} 
Aspose.Slides for JasperReports को JasperServer के साथ एकीकृत करने के लिए, कई अतिरिक्त कदम उठाने और JasperServer कॉन्फ़िग फ़ाइलों को अपडेट करने की आवश्यकता है। यह लेख बताता है कि कैसे।
{{% /alert %}} 

1. नई exporter प्रॉपर्टीज़ को **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\flows\viewReportBeans.xml** कॉन्फ़िग फ़ाइल में जोड़ें।

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
    <!-- इस प्रविष्टि को exporterConfigMap में जोड़ें -->
    <entry key="ppt" value-ref="pptExporterConfiguration"/>
</util:map>
```

2. **aspose.slides.jasperreports.jar** को **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\lib** में कॉपी करें।

3. फ़ॉन्ट मैपिंग फीचर का उपयोग करने के लिए, नीचे दिखाए अनुसार **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\applicationContext.xml** को अपडेट करें।

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