---
title: Soporte para la Incrustación de Video en Presentaciones
type: docs
weight: 80
url: /es/reportingservices/support-for-embedding-video-in-presentation/
---

{{% alert color="primary" %}} 

Microsoft SQL Server Reporting Services no tiene capacidades integradas para exportar informes con video incrustado a presentaciones de PowerPoint. Aspose.Slides para Reporting Services 4.10 y versiones posteriores admiten la incrustación de video dentro de la presentación. 

{{% /alert %}} 

Para incrustar video en las diapositivas, por favor, añade al informe un cuadro de texto con el siguiente texto: 

``` xml

 <asposeObject type="video" url="file://c:\MyVideos\intro.wmv" playMode="Auto" vlume="Loud" cover="file://c:\MyVideos\introCover.jpg"/>

```

Funciona para la versión 2008 de SQL Server y posteriores. La función es compatible solo con la exportación a PPTX.