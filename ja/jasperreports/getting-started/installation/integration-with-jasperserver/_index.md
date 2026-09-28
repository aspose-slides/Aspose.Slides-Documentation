---
title: JasperServer との統合
type: docs
weight: 45
url: /ja/jasperreports/integration-with-jasperserver/
description: "Aspose.Slides for JasperReports エクスポーターを JasperReports Server に追加します：JAR をコピーし、PowerPoint エクスポーターを登録し、フォントマッピングとライセンスを設定します。"
---
## **JAR ファイルをコピーする**

両方の JAR をコピーします — *aspose.slides.jasperreports.library-xx.x.jar* と *aspose.slides.jasperreports.server-xx.x.jar* — **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\lib** に。ダウンロードの *lib* フォルダー内の同じサブフォルダーから取得してください。サーバーが実行している JasperReports バージョンに対応するものです。バージョン範囲については [Installing Aspose.Slides for JasperReports](/slides/ja/jasperreports/installing-aspose-slides-for-jasperreports/) を参照してください。

## **エクスポーターを登録する**

新しいエクスポーター Bean を **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\flows\viewReportBeans.xml** 設定ファイルに追加します。`ASPptReportExporter` クラスはサーバー JAR に含まれています。同じ JAR には `ASPptxReportExporter`、`ASPdfReportExporter`、`ASHtmlReportExporter` も含まれています。

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
    <!-- このエントリを exporterConfigMap に追加します -->
    <entry key="ppt" value-ref="pptExporterConfiguration"/>
</util:map>
```

## **フォントマッピングとライセンスの設定**

`pptExportParameters` Bean を **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\applicationContext.xml** でエクスポーターが参照するように定義します。その `fontMap` プロパティはレポートで使用されるフォント名をプレゼンテーションに書き込まれるフォントにマッピングし、`licenseFile` プロパティはライセンスファイルへのパスを設定します。

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
`fontMap` の各キーは、レポートがフォントを指定する名前と同じように、大文字小文字を含めて正確に記述してください。`sansserif` キーは JasperReports のデフォルトフォント `SansSerif` を置き換えません。各値はサーバー上で Java が認識できるフォントである必要があり、そうでなければエクスポーターはエントリを無視します。たとえば Windows では、Java は `Courier New` は認識しますが `Courier` は認識しません。[Map fonts](/slides/ja/jasperreports/ppt-pptx-pdf-and-html-export/#map-fonts) を参照してください。
{{% /alert %}}