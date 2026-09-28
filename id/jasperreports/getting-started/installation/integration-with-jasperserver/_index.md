---
title: Integrasi dengan JasperServer
type: docs
weight: 45
url: /id/jasperreports/integration-with-jasperserver/
description: "Tambahkan exporter Aspose.Slides untuk JasperReports ke JasperReports Server: salin jar, daftarkan exporter PowerPoint, dan atur pemetaan font serta lisensi."
---
## **Salin jar**

Salin kedua jar — *aspose.slides.jasperreports.library-xx.x.jar* dan *aspose.slides.jasperreports.server-xx.x.jar* — ke **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\lib**. Ambil mereka dari subfolder yang sama dalam folder *lib* yang diunduh: yang mencakup versi JasperReports yang dijalankan server Anda. Lihat [Menginstal Aspose.Slides untuk JasperReports](/slides/id/jasperreports/installing-aspose-slides-for-jasperreports/) untuk rentang versi.

## **Daftarkan exporter**

Tambahkan bean exporter baru ke file konfigurasi **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\flows\viewReportBeans.xml**. Kelas `ASPptReportExporter` berada di dalam jar server; jar yang sama juga berisi `ASPptxReportExporter`, `ASPdfReportExporter`, dan `ASHtmlReportExporter`.

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
    <!-- tambahkan entri ini ke exporterConfigMap -->
    <entry key="ppt" value-ref="pptExporterConfiguration"/>
</util:map>
```

## **Atur pemetaan font dan lisensi**

Definisikan bean `pptExportParameters` yang dirujuk exporter dalam **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\applicationContext.xml**. Properti `fontMap`‑nya memetakan nama font yang digunakan dalam laporan ke font yang ditulis ke presentasi, dan properti `licenseFile`‑nya menentukan jalur ke file lisensi Anda.

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
Tuliskan setiap kunci `fontMap` persis seperti nama font dalam laporan, termasuk huruf besar/kecil: kunci `sansserif` tidak menggantikan font default JasperReports, `SansSerif`. Setiap nilai harus berupa font yang dapat ditemukan Java di server, atau exporter akan mengabaikan entri tersebut. Pada Windows, misalnya, Java menemukan `Courier New` tetapi tidak `Courier`. Lihat [Pemetaan font](/slides/id/jasperreports/ppt-pptx-pdf-and-html-export/#map-fonts).
{{% /alert %}}