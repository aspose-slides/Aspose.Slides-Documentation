---
title: 与 JasperServer 的集成
type: docs
weight: 45
url: /zh/jasperreports/integration-with-jasperserver/
description: "将 Aspose.Slides for JasperReports 导出器添加到 JasperReports Server：复制 JAR 包，注册 PowerPoint 导出器，并设置字体映射和许可证。"
---
## **复制 JAR 包**

复制两个 JAR 包——*aspose.slides.jasperreports.library-xx.x.jar* 和 *aspose.slides.jasperreports.server-xx.x.jar*——到 **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\lib**。从下载的 *lib* 文件夹的同一子文件夹中获取它们：该子文件夹对应您服务器运行的 JasperReports 版本。有关版本范围，请参阅 [安装 Aspose.Slides for JasperReports](/slides/zh/jasperreports/installing-aspose-slides-for-jasperreports/)。

## **注册导出器**

将新的导出器 bean 添加到 **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\flows\viewReportBeans.xml** 配置文件中。`ASPptReportExporter` 类位于服务器 JAR 包中；同一个 JAR 还包含 `ASPptxReportExporter`、`ASPdfReportExporter` 和 `ASHtmlReportExporter`。

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
    <!-- 将此条目添加到 exporterConfigMap -->
    <entry key="ppt" value-ref="pptExporterConfiguration"/>
</util:map>
```

## **设置字体映射和许可证**

在 **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\applicationContext.xml** 中定义导出器所引用的 `pptExportParameters` bean。其 `fontMap` 属性将报表中使用的字体名称映射到写入演示文稿的字体，而 `licenseFile` 属性则设置许可证文件的路径。

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
`fontMap` 的每个键必须完全按照报表中指定的字体名称编写，包括大小写：`sansserif` 键不会替代 JasperReports 默认的字体 `SansSerif`。每个值必须是 Java 在服务器上能够找到的字体，否则导出器将忽略该条目。例如，在 Windows 上，Java 能找到 `Courier New`，但找不到 `Courier`。请参阅 [映射字体](/slides/zh/jasperreports/ppt-pptx-pdf-and-html-export/#map-fonts)。
{{% /alert %}}