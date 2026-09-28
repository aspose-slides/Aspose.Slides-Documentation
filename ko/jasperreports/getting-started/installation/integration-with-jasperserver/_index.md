---
title: JasperServer와 통합
type: docs
weight: 45
url: /ko/jasperreports/integration-with-jasperserver/
description: "Aspose.Slides for JasperReports 내보내기를 JasperReports Server에 추가합니다: JAR 파일을 복사하고, PowerPoint 내보내기를 등록하며, 글꼴 매핑 및 라이선스를 설정합니다."
---
## **JAR 파일 복사**

두 개의 JAR 파일 — *aspose.slides.jasperreports.library-xx.x.jar* 및 *aspose.slides.jasperreports.server-xx.x.jar* — 를 **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\lib**에 복사합니다. 다운로드의 *lib* 폴더에 있는 동일한 하위 폴더에서 가져오세요. 서버가 실행하는 JasperReports 버전에 해당하는 폴더입니다. 버전 범위에 대해서는 [Installing Aspose.Slides for JasperReports](/slides/ko/jasperreports/installing-aspose-slides-for-jasperreports/)를 참고하십시오.

## **수출기 등록**

새로운 수출기 Bean을 **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\flows\viewReportBeans.xml** 구성 파일에 추가합니다. `ASPptReportExporter` 클래스는 서버 JAR에 포함되어 있으며, 동일한 JAR에는 `ASPptxReportExporter`, `ASPdfReportExporter` 및 `ASHtmlReportExporter`도 포함되어 있습니다.

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
    <!-- exporterConfigMap에 이 항목을 추가 -->
    <entry key="ppt" value-ref="pptExporterConfiguration"/>
</util:map>
```

## **글꼴 매핑 및 라이선스 설정**

`pptExportParameters` Bean을 **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\applicationContext.xml**에서 정의합니다. 이 Bean의 `fontMap` 속성은 보고서에서 사용된 글꼴 이름을 프레젠테이션에 기록되는 글꼴에 매핑하고, `licenseFile` 속성은 라이선스 파일의 경로를 설정합니다.

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
`fontMap` 키를 보고서에서 글꼴을 지정한 이름 그대로, 대소문자까지 정확히 작성하십시오. `sansserif` 키는 JasperReports의 기본 글꼴인 `SansSerif`를 대체하지 않습니다. 각 값은 서버에서 Java가 찾을 수 있는 글꼴이어야 하며, 그렇지 않으면 수출기가 해당 항목을 무시합니다. 예를 들어 Windows에서는 Java가 `Courier New`는 찾지만 `Courier`는 찾지 못합니다. 자세한 내용은 [Map fonts](/slides/ko/jasperreports/ppt-pptx-pdf-and-html-export/#map-fonts)를 참조하세요.
{{% /alert %}}