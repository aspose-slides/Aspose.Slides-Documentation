---
title: Soporte para la incorporación de audio en presentaciones
type: docs
weight: 90
url: /es/reportingservices/support-for-embedding-audio-in-presentation/
---

{{% alert color="primary" %}} 

Microsoft SQL Server Reporting Services no tiene capacidades integradas para exportar informes con audio incorporado a presentaciones de PowerPoint. Aspose.Slides para Reporting Services 4.10 y versiones posteriores admiten la incorporación de audio dentro de la presentación exportada. 

{{% /alert %}} 

Para incorporar audio a las diapositivas, por favor añade al informe un cuadro de texto con el siguiente texto: 

``` xml

 <asposeObject type="audio" url="file://c:\MyVideos\intro.wav" playMode="Auto" volume="Loud" cover="file://c:\MyVideos\introCover.jpg"/>

```

Funciona para la versión de SQL Server 2008 y posteriores. La función solo es compatible con la exportación a PPTX.