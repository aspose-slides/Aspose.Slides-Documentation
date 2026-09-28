---
title: Развертывание и активация
type: docs
weight: 20
url: /ru/sharepoint/deployment-and-activation/
description: "Что решением Aspose.Slides for SharePoint устанавливается на ферму при развертывании и что добавляет его функция коллекции сайтов при активации."
---
## **Развертывание**

Во время развертывания решение Aspose.Slides for SharePoint:

- Устанавливает свою сборку в Global Assembly Cache и добавляет записи SafeControl для неё в файл **web.config**. На SharePoint 2010 и более поздних версиях это *Aspose.Slides.SharePoint2010.dll*, *Aspose.Slides.SharePoint2013.dll* или *Aspose.Slides.SharePoint2016.dll* (пакет SharePoint 2019 также устанавливает *Aspose.Slides.SharePoint2016.dll*). На SharePoint 2007 это *Aspose.Slides.SharePointUI.dll* вместе с *Aspose.Slides.SharePoint.Deployment.dll*.
- Копирует страницу конвертации, её изображения и другие вспомогательные файлы в папки установки SharePoint.
- Устанавливает функцию и делает её доступной для активации в коллекциях сайтов.

## **Активация**

Aspose.Slides for SharePoint упакован как функция коллекции сайтов и может быть активирован или деактивирован в коллекциях сайтов. Когда он активирован в коллекции сайтов, функция добавляет:

- На SharePoint 2010 и более поздних версиях:
  - элемент **Convert via Aspose.Slides** в меню документов в библиотеках документов;
  - вкладку ленты **Aspose Tools** с кнопкой **Convert Slides**, которая конвертирует выбранные документы;
  - элемент **View Slides** в меню файлов PPT, PPTX, PPS и PPSX.
- На SharePoint 2007:
  - элемент **Convert with Aspose.Slides** в меню документов в библиотеках документов;
  - элемент **Convert All with Aspose.Slides** в меню **Actions** библиотек документов.

На SharePoint 2007 активация также вносит изменения в виртуальный каталог родительского веб‑приложения коллекции сайтов. Она:

- Добавляет страницу настроек конвертации в файл карты сайта.
- Копирует необходимые файлы ресурсов в папку App_GlobalResources в виртуальном каталоге.

Программа установки активирует функцию в выбранных вами коллекциях сайтов во время [installation](/slides/ru/sharepoint/installing-aspose-slides-for-sharepoint/).