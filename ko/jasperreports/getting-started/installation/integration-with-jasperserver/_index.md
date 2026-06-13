---
title: JasperServer와 통합
type: docs
weight: 45
url: /ko/jasperreports/integration-with-jasperserver/
---
{{% alert color="primary" %}} 

Aspose.Slides for JasperReports를 JasperServer와 통합하려면 몇 가지 추가 단계가 필요하고 JasperServer 구성 파일을 업데이트해야 합니다. 이 문서에서는 방법을 설명합니다.

{{% /alert %}} 

1. 새로운 내보내기 속성을 **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\flows\viewReportBeans.xml** 구성 파일에 추가합니다.

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
    <!-- exporterConfigMap에 이 항목을 추가합니다 -->
    <entry key="ppt" value-ref="pptExporterConfiguration"/>
</util:map>
```

2. **aspose.slides.jasperreports.jar** 파일을 **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\lib** 로 복사합니다.
3. 글꼴 매핑 기능을 사용하려면 아래와 같이 **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\applicationContext.xml** 을 업데이트합니다.

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