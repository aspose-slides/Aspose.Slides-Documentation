---
title: Ενσωμάτωση με JasperServer
type: docs
weight: 45
url: /el/jasperreports/integration-with-jasperserver/
description: "Προσθέστε τους εξαγωγείς Aspose.Slides για JasperReports στον διακομιστή JasperReports: αντιγράψτε τα αρχεία JAR, καταχωρίστε τον εξαγωγέα PowerPoint και ορίστε την αντιστοίχιση γραμματοσειρών και την άδεια."
---
## **Αντιγράψτε τα αρχεία JAR**

Αντιγράψτε και τα δύο αρχεία JAR — *aspose.slides.jasperreports.library-xx.x.jar* και *aspose.slides.jasperreports.server-xx.x.jar* — στο **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\lib**. Πάρτε τα από τον ίδιο υποφάκελο του φακέλου *lib* της λήψης: αυτόν που ταιριάζει με την έκδοση JasperReports που χρησιμοποιεί ο διακομιστής σας. Δείτε [Installing Aspose.Slides for JasperReports](/slides/el/jasperreports/installing-aspose-slides-for-jasperreports/) για τα όρια εκδόσεων.

## **Καταχωρίστε τον εξαγωγέα**

Προσθέστε τα νέα beans εξαγωγέα στο αρχείο ρυθμίσεων **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\flows\viewReportBeans.xml**. Η κλάση `ASPptReportExporter` βρίσκεται στο αρχείο JAR του διακομιστή· το ίδιο αρχείο JAR περιέχει επίσης `ASPptxReportExporter`, `ASPdfReportExporter` και `ASHtmlReportExporter`.

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
    <!-- προσθέστε αυτή την καταχώρηση στο exporterConfigMap -->
    <entry key="ppt" value-ref="pptExporterConfiguration"/>
</util:map>
```

## **Ορίστε την αντιστοίχιση γραμματοσειρών και την άδεια**

Ορίστε το bean `pptExportParameters` στο οποίο αναφέρεται ο εξαγωγέας στο **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\applicationContext.xml**. Η ιδιότητα `fontMap` του αντιστοιχίζει τα ονόματα γραμματοσειρών που χρησιμοποιούνται στις αναφορές στις γραμματοσειρές που γράφονται στην παρουσίαση, ενώ η ιδιότητα `licenseFile` ορίζει τη διαδρομή προς το αρχείο άδειας σας.

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
Γράψτε κάθε κλειδί `fontMap` ακριβώς όπως το αναφέρει η αναφορά για τη γραμματοσειρά, συμπεριλαμβανομένης της διάκρισης πεζών-κεφαλαίων: ένα κλειδί `sansserif` δεν αντικαθιστά τη προεπιλεγμένη γραμματοσειρά του JasperReports, `SansSerif`. Κάθε τιμή πρέπει να είναι μια γραμματοσειρά που η Java βρίσκει στον διακομιστή, αλλιώς οι εξαγωγείς αγνοούν την καταχώριση. Σε Windows, για παράδειγμα, η Java βρίσκει το `Courier New` αλλά όχι το `Courier`. Δείτε [Map fonts](/slides/el/jasperreports/ppt-pptx-pdf-and-html-export/#map-fonts).
{{% /alert %}}