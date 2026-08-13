---
title: JasperServer との統合
type: docs
weight: 45
url: /ja/jasperreports/integration-with-jasperserver/
---
{{% alert color="info" %}} 

Aspose.Slides for JasperReports を JasperServer と統合するには、いくつかの追加手順を実行し、JasperServer の設定ファイルを更新する必要があります。本記事ではその方法を説明します。

{{% /alert %}} 

1. **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\flows\viewReportBeans.xml** 設定ファイルに新しいエクスポーター プロパティを追加します。

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
    <!-- exporterConfigMap にこのエントリを追加します -->
    <entry key="ppt" value-ref="pptExporterConfiguration"/>
</util:map>
```

2. **aspose.slides.jasperreports.jar** を **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\lib** にコピーします。
3. フォント マッピング機能を使用するには、以下のように **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\applicationContext.xml** を更新します。

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