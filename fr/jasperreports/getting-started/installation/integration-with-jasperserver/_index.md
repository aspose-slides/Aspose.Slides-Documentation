---
title: Intégration avec JasperServer
type: docs
weight: 45
url: /fr/jasperreports/integration-with-jasperserver/
description: "Ajoutez les exportateurs Aspose.Slides pour JasperReports à JasperReports Server: copiez les jars, enregistrez l'exportateur PowerPoint, et définissez la correspondance des polices ainsi que la licence."
---
## **Copier les JAR**

Copiez les deux JAR — *aspose.slides.jasperreports.library-xx.x.jar* et *aspose.slides.jasperreports.server-xx.x.jar* — vers **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\lib**. Prenez-les dans le même sous-dossier du dossier *lib* du téléchargement: celui qui correspond à la version de JasperReports utilisée par votre serveur. Voir [Installer Aspose.Slides pour JasperReports](/slides/fr/jasperreports/installing-aspose-slides-for-jasperreports/) pour les plages de versions.

## **Enregistrer l'exportateur**

Ajoutez les nouveaux beans d'exportateur au fichier de configuration **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\flows\viewReportBeans.xml**. La classe `ASPptReportExporter` se trouve dans le JAR serveur; le même JAR contient également `ASPptxReportExporter`, `ASPdfReportExporter` et `ASHtmlReportExporter`.

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
    <!-- ajoutez cette entrée à exporterConfigMap -->
    <entry key="ppt" value-ref="pptExporterConfiguration"/>
</util:map>
```

## **Définir la correspondance des polices et la licence**

Définissez le bean `pptExportParameters` auquel l'exportateur fait référence dans **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\applicationContext.xml**. Sa propriété `fontMap` fait correspondre les noms de polices utilisés dans les rapports aux polices écrites dans la présentation, et sa propriété `licenseFile` indique le chemin vers votre fichier de licence.

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
Écrivez chaque clé `fontMap` exactement comme le rapport nomme la police, y compris la casse: une clé `sansserif` ne remplace pas la police par défaut de JasperReports, `SansSerif`. Chaque valeur doit être une police que Java trouve sur le serveur, sinon les exportateurs ignorent l'entrée. Sous Windows, par exemple, Java trouve `Courier New` mais pas `Courier`. Voir [Mapper les polices](/slides/fr/jasperreports/ppt-pptx-pdf-and-html-export/#map-fonts).
{{% /alert %}}