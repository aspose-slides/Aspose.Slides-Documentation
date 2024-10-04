---
title: Personalizando la Leyenda de la Extensión de Renderizado de PowerPoint
type: docs
weight: 60
url: /reportingservices/customizing-powerpoint-rendering-extension-caption/
---

{{% alert color="primary" %}} 

Este artículo te muestra cómo personalizar las leyendas de las opciones de renderizado de Aspose.Slides para Reporting Services. 

{{% /alert %}} 
## **Ejemplo**
Al instalar Aspose.Slides para Reporting Services, se añaden 4 opciones de exportación adicionales en el menú desplegable de opciones de exportación:

![todo:image_alt_text](customizing-powerpoint-rendering-extension-caption_1.png)
## **Cómo modificar el texto de las leyendas**
Las leyendas predeterminadas de estas extensiones se pueden cambiar sobrescribiendo los nombres predeterminados. Estos pasos te muestran cómo cambiar la leyenda de “ **PPT – PowerPoint** **Presentation via** **Aspose.Slides** ” a “ **PowerPoint 97 – 2003 format(PPT)** ”. 

**Paso 1:** Localiza el archivo **rsreportserver.config** que generalmente se encuentra en este directorio: 

**OS Root Drive\Program Files\Microsoft SQL Server\MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

**Paso** **2:** Encuentra estas líneas en el archivo rsreportserver.config: 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

``` 

**Paso** **3:** Reemplaza el parámetro de extensión con esto: 

**<Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices">**

``` xml

         <OverrideNames>

          <Name Language="es-ES">PowerPoint 97 - 2003 Format(PPT)</Name>

        </OverrideNames>

</Extension>

``` 

Las opciones de exportación ahora aparecerán así: 

![todo:image_alt_text](customizing-powerpoint-rendering-extension-caption_2.png)