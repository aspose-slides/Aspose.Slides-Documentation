---
title: Integração com JasperServer
type: docs
weight: 45
url: /pt/jasperreports/integration-with-jasperserver/
description: "Adicione os exportadores do Aspose.Slides for JasperReports ao JasperReports Server: copie os jars, registre o exportador PowerPoint e configure o mapeamento de fontes e a licença."
---
## **Copiar os jars**

Copie ambos os jars — *aspose.slides.jasperreports.library-xx.x.jar* e *aspose.slides.jasperreports.server-xx.x.jar* — para **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\lib**. Pegue‑os da mesma subpasta da pasta *lib* do download: a que corresponde à versão do JasperReports que seu servidor está executando. Consulte [Installing Aspose.Slides for JasperReports](/slides/pt/jasperreports/installing-aspose-slides-for-jasperreports/) para as faixas de versão.

## **Registrar o exportador**

Adicione os novos beans do exportador ao arquivo de configuração **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\flows\viewReportBeans.xml**. A classe `ASPptReportExporter` está no jar do servidor; o mesmo jar também contém `ASPptxReportExporter`, `ASPdfReportExporter` e `ASHtmlReportExporter`.

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

## **Definir mapeamento de fontes e a licença**

Defina o bean `pptExportParameters` ao qual o exportador se refere em **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\applicationContext.xml**. Sua propriedade `fontMap` mapeia os nomes das fontes usados nos relatórios para as fontes gravadas na apresentação, e sua propriedade `licenseFile` define o caminho para o seu arquivo de licença.

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

{{% alert color="warning" title="Aviso" %}}
Escreva cada chave `fontMap` exatamente como os nomes da fonte nos relatórios, incluindo maiúsculas e minúsculas: uma chave `sansserif` não substitui a fonte padrão do JasperReports, `SansSerif`. Cada valor deve ser uma fonte que o Java encontre no servidor, caso contrário os exportadores ignoram a entrada. No Windows, por exemplo, o Java encontra `Courier New` mas não `Courier`. Consulte [Map fonts](/slides/pt/jasperreports/ppt-pptx-pdf-and-html-export/#map-fonts).
{{% /alert %}}