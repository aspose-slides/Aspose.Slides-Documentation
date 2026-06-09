---
title: Integração com JasperServer
type: docs
weight: 45
url: /pt/jasperreports/integration-with-jasperserver/
---
{{% alert color="primary" %}} 

Para integrar Aspose.Slides for JasperReports ao JasperServer, é necessário executar várias etapas adicionais e atualizar os arquivos de configuração do JasperServer. Este artigo explica como.

{{% /alert %}} 

1. Adicione novas propriedades de exportação ao arquivo de configuração **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\flows\viewReportBeans.xml**.

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
    <!-- adicione esta entrada ao exporterConfigMap -->
    <entry key="ppt" value-ref="pptExporterConfiguration"/>
</util:map>
```

2. Copie **aspose.slides.jasperreports.jar** para **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\lib**.

3. Para usar o recurso de mapeamento de fontes, atualize **%INTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\applicationContext.xml** conforme abaixo.

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