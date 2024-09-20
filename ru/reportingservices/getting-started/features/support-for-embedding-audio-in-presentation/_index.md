---
title: Поддержка встраивания аудио в презентацию
type: docs
weight: 90
url: /reportingservices/support-for-embedding-audio-in-presentation/
---

{{% alert color="primary" %}} 

Microsoft SQL Server Reporting Services не имеет встроенных возможностей для экспорта отчетов с встраиванием аудио в презентации PowerPoint. Aspose.Slides для Reporting Services с версии 4.10 и выше поддерживают встраивание аудио в экспортированную презентацию.

{{% /alert %}} 

Чтобы встроить аудио в слайды, пожалуйста, добавьте в отчет текстовое поле с текстом: 

``` xml

 <asposeObject type="audio" url="file://c:\MyVideos\intro.wav" playMode="Auto" volume="Loud" cover="file://c:\MyVideos\introCover.jpg"/>

```


Это работает для версии SQL Server 2008 и выше. Функция поддерживается только для экспорта в формате PPTX.