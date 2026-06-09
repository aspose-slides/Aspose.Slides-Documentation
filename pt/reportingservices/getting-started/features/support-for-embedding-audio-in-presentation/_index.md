---
title: Suporte para Incorporação de Áudio em Apresentação
type: docs
weight: 90
url: /pt/reportingservices/support-for-embedding-audio-in-presentation/
---
{{% alert color="primary" %}} 

O Microsoft SQL Server Reporting Services não possui recursos integrados para exportar relatórios com áudio incorporado para apresentações do PowerPoint. Aspose.Slides para Reporting Services nas versões 4.10 e posteriores suportam a incorporação de áudio em apresentações exportadas. 

{{% /alert %}} 

Para incorporar áudio aos slides, adicione ao relatório uma caixa de texto com o seguinte conteúdo: 

``` xml

 <asposeObject type="audio" url="file://c:\MyVideos\intro.wav" playMode="Auto" volume="Loud" cover="file://c:\MyVideos\introCover.jpg"/>

```


Ele funciona nas versões 2008 ou superiores do SQL Server. O recurso é suportado apenas para exportação PPTX.