---
title: Suporte para Incorporação de Vídeo em Apresentação
type: docs
weight: 80
url: /pt/reportingservices/support-for-embedding-video-in-presentation/
---
{{% alert color="primary" %}} 

O Microsoft SQL Server Reporting Services não possui recursos nativos para exportar relatórios com vídeo incorporado para apresentações do PowerPoint. O Aspose.Slides for Reporting Services 4.10 e versões posteriores suportam a incorporação de vídeo dentro da apresentação. 

{{% /alert %}} 

Para incorporar vídeo aos slides, adicione ao relatório uma caixa de texto com o seguinte conteúdo: 

``` xml

 <asposeObject type="video" url="file://c:\MyVideos\intro.wmv" playMode="Auto" vlume="Loud" cover="file://c:\MyVideos\introCover.jpg"/>

```


Ele funciona para a versão 2008 do SQL Server ou superior. O recurso é suportado apenas na exportação para PPTX.