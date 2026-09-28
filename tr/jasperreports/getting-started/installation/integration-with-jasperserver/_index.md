---
title: JasperServer ile Entegrasyon
type: docs
weight: 45
url: /tr/jasperreports/integration-with-jasperserver/
description: "Aspose.Slides for JasperReports dışa aktarıcılarını JasperReports Server'a ekleyin: jar'ları kopyalayın, PowerPoint dışa aktarıcısını kaydedin ve yazı tipi eşlemesini ve lisansı ayarlayın."
---
## **Jar'ları Kopyala**

Her iki jar'ı — *aspose.slides.jasperreports.library-xx.x.jar* ve *aspose.slides.jasperreports.server-xx.x.jar* — **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\lib** konumuna kopyalayın. İndirme paketindeki *lib* klasörünün aynı alt klasöründen alın: sunucunuzun çalıştığı JasperReports sürümünü kapsayanı. Sürüm aralıkları için [Installing Aspose.Slides for JasperReports](/slides/tr/jasperreports/installing-aspose-slides-for-jasperreports/) sayfasına bakın.

## **Dışa Aktarıcıyı Kaydet**

Yeni dışa aktarıcı bean'lerini **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\flows\viewReportBeans.xml** yapılandırma dosyasına ekleyin. `ASPptReportExporter` sınıfı sunucu jar'ında bulunur; aynı jar ayrıca `ASPptxReportExporter`, `ASPdfReportExporter` ve `ASHtmlReportExporter` içerir.

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
    <!-- exporterConfigMap'e bu girişi ekle -->
    <entry key="ppt" value-ref="pptExporterConfiguration"/>
</util:map>
```

## **Yazı Tipi Eşlemesini ve Lisansı Ayarla**

`pptExportParameters` bean'ini **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\applicationContext.xml** içinde dışa aktarıcının başvurduğu şekilde tanımlayın. `fontMap` özelliği raporlarda kullanılan yazı tipi adlarını sunuma yazılan yazı tiplerine eşler ve `licenseFile` özelliği lisans dosyanızın yolunu belirler.

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
Her `fontMap` anahtarını, raporun yazı tipini adlandırdığı şekilde, büyük/küçük harf duyarlılığıyla tam olarak yazın: `sansserif` anahtarı JasperReports'ın varsayılan yazı tipi `SansSerif`'i değiştirmez. Her değer, Java'nın sunucuda bulabildiği bir yazı tipi olmalı; aksi takdirde dışa aktarıcılar girdiyi yok sayar. Örneğin Windows'ta Java `Courier New`'u bulur ama `Courier`'ı bulamaz. [Map fonts](/slides/tr/jasperreports/ppt-pptx-pdf-and-html-export/#map-fonts) bölümüne bakın.
{{% /alert %}}