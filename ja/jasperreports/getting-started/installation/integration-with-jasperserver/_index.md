---
title: JasperServerとの統合
type: docs
weight: 45
url: /ja/jasperreports/integration-with-jasperserver/
---

{{% alert color="primary" %}} 

Aspose.Slides for JasperReportsをJasperServerと統合するには、いくつかの追加手順を行い、JasperServerの設定ファイルを更新する必要があります。この記事では、その方法を説明します。

{{% /alert %}} 

1. **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\flows\viewReportBeans.xml**設定ファイルに新しいエクスポータプロパティを追加します。

``` xml
<bean id="reportPptExporter" class="com.aspose.slides.jasperreports.ASPptReportExporter" parent="baseReportExporter">
    <property name="exportParameters" ref="pptExportParameters"/>
    <property name="setResponseContentLength" value="true"/>
</bean> 

<bean id="pptExporterConfiguration" class="com.jaspersoft.jasperserver.war.action.ExporterConfigurationBean">
    <property name="descriptionKey" value="Aspose.SlidesによるPowerPointプレゼンテーション"/>
    <property name="iconSrc" value="/images/ppt.png"/>
    <property name="parameterDialogName" value=""/>
    <property name="exportParameters" ref="pptExportParameters"/>
    <property name="currentExporter" ref="reportPptExporter"/>
</bean>

<util:map id="exporterConfigMap">
    <!-- exporterConfigMapにこのエントリを追加 -->
    <entry key="ppt" value-ref="pptExporterConfiguration"/>
</util:map>
```

2. **aspose.slides.jasperreports.jar**を**%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\lib**にコピーします。
3. フォントマッピング機能を使用するために、**%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\applicationContext.xml**を以下のように更新します。

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