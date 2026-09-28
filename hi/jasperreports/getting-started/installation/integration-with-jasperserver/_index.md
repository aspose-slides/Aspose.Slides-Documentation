---
title: JasperServer के साथ एकीकरण
type: docs
weight: 45
url: /hi/jasperreports/integration-with-jasperserver/
description: "Aspose.Slides for JasperReports निर्यातकों को JasperReports सर्वर में जोड़ें: जार कॉपी करें, PowerPoint निर्यातक पंजीकृत करें, और फ़ॉन्ट मैपिंग और लाइसेंस सेट करें।"
---
## **जार को कॉपी करें**

दोनों जार — *aspose.slides.jasperreports.library-xx.x.jar* और *aspose.slides.jasperreports.server-xx.x.jar* — **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\lib** में कॉपी करें। इन्हें डाउनलोड के *lib* फ़ोल्डर की उसी उपफ़ोल्डर से लें: वह जो आपके सर्वर द्वारा उपयोग किए जा रहे JasperReports संस्करण को कवर करता है। संस्करण रेंजों के लिए देखें [JasperReports के लिए Aspose.Slides स्थापित करना](/slides/hi/jasperreports/installing-aspose-slides-for-jasperreports/)।

## **एक्सपोर्टर को पंजीकृत करें**

नए एक्सपोर्टर बीन्स को **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\flows\viewReportBeans.xml** कॉन्फ़िग फ़ाइल में जोड़ें। `ASPptReportExporter` क्लास सर्वर जार में है; उसी जार में `ASPptxReportExporter`, `ASPdfReportExporter` और `ASHtmlReportExporter` भी मौजूद हैं।

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
    <!-- इस एंट्री को exporterConfigMap में जोड़ें -->
    <entry key="ppt" value-ref="pptExporterConfiguration"/>
</util:map>
```

## **फ़ॉन्ट मैपिंग और लाइसेंस सेट करें**

`pptExportParameters` बीन को परिभाषित करें, जिसका संदर्भ एक्सपोर्टर **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\applicationContext.xml** में करता है। इसका `fontMap` प्रॉपर्टी रिपोर्ट में उपयोग किए गए फ़ॉन्ट नामों को प्रस्तुति में लिखे जाने वाले फ़ॉन्ट से मैप करता है, और इसका `licenseFile` प्रॉपर्टी आपके लाइसेंस फ़ाइल का पथ सेट करता है।

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
प्रत्येक `fontMap` कुंजी को रिपोर्ट में फ़ॉन्ट के नाम के समान बिल्कुल लिखें, केस सहित: `sansserif` कुंजी JasperReports की डिफ़ॉल्ट फ़ॉन्ट `SansSerif` को प्रतिस्थापित नहीं करती। प्रत्येक मूल्य सर्वर पर Java द्वारा पाए जाने वाला फ़ॉन्ट होना चाहिए, अन्यथा एक्सपोर्टर उस प्रविष्टि को नजरअंदाज कर देंगे। उदाहरण के लिए, Windows पर Java `Courier New` को पाता है लेकिन `Courier` को नहीं। देखें [फ़ॉन्ट मैप करें](/slides/hi/jasperreports/ppt-pptx-pdf-and-html-export/#map-fonts)।
{{% /alert %}}