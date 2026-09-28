---
title: 與 JasperServer 的整合
type: docs
weight: 45
url: /zh-hant/jasperreports/integration-with-jasperserver/
description: "將 Aspose.Slides for JasperReports 匯出程式加入 JasperReports Server：複製 jar 檔案、註冊 PowerPoint 匯出程式，並設定字體對映與授權。"
---
## **複製 jar 檔案**

將兩個 jar — *aspose.slides.jasperreports.library-xx.x.jar* 和 *aspose.slides.jasperreports.server-xx.x.jar* — 複製到 **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\lib**。從下載的 *lib* 資料夾的相同子資料夾取得它們：即對應您伺服器執行的 JasperReports 版本的子資料夾。請參閱[安裝 Aspose.Slides for JasperReports](/slides/zh-hant/jasperreports/installing-aspose-slides-for-jasperreports/)的版本範圍。

## **註冊匯出程式**

將新的匯出程式 bean 新增至 **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\flows\viewReportBeans.xml** 設定檔。`ASPptReportExporter` 類別位於伺服器 jar 中；同一個 jar 也包含 `ASPptxReportExporter`、`ASPdfReportExporter` 和 `ASHtmlReportExporter`。

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
    <!-- 將此項目新增至 exporterConfigMap -->
    <entry key="ppt" value-ref="pptExporterConfiguration"/>
</util:map>
```

## **設定字體對映與授權**

在 **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\applicationContext.xml** 中定義匯出程式所參照的 `pptExportParameters` bean。其 `fontMap` 屬性將報表中使用的字體名稱對映到寫入簡報的字體，`licenseFile` 屬性則設定您的授權檔案路徑。

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
請將每個 `fontMap` 鍵完全照報表中字體名稱的大小寫寫入：`sansserif` 鍵不會取代 JasperReports 的預設字體 `SansSerif`。每個值必須是 Java 在伺服器上能夠找到的字體，否則匯出程式會忽略該條目。例如在 Windows 上，Java 能找到 `Courier New` 但找不到 `Courier`。請參閱[對映字體](/slides/zh-hant/jasperreports/ppt-pptx-pdf-and-html-export/#map-fonts)。
{{% /alert %}}