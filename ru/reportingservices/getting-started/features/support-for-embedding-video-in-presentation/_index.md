---
title: Поддержка встраивания видео в презентацию
type: docs
weight: 80
url: /ru/reportingservices/support-for-embedding-video-in-presentation/
---

{{% alert color="primary" %}} 

Службы отчетности Microsoft SQL Server не имеют встроенных возможностей для экспорта отчетов с встраиваемым видео в презентации PowerPoint. Aspose.Slides для Служб отчетности версии 4.10 и выше поддерживают встраивание видео в презентацию. 

{{% /alert %}} 

Чтобы встроить видео в слайды, добавьте в отчет текстовое поле с текстом: 

``` xml

 <asposeObject type="video" url="file://c:\MyVideos\intro.wmv" playMode="Auto" vlume="Loud" cover="file://c:\MyVideos\introCover.jpg"/>

```

Это работает для версии SQL Server 2008 и выше. Функция поддерживается только для экспорта в формат PPTX. 
