---
title: Установка Aspose.Slides для SharePoint
type: docs
weight: 10
url: /ru/sharepoint/installing-aspose-slides-for-sharepoint/
description: "Установите Aspose.Slides for SharePoint в ферму SharePoint: выберите программу установки для вашей версии SharePoint, запустите проверку системы и разверните и активируйте решение."
---
## **Содержание пакета**

Aspose.Slides for SharePoint загружается со [download page](https://releases.aspose.com/slides/ru/sharepoint/) в виде ZIP‑архива. В архиве находятся один пакет решения SharePoint (WSP) и одна программа установки для каждой поддерживаемой версии SharePoint:

| Версия SharePoint | Программа установки | Пакет решения |
| :- | :- | :- |
| SharePoint 2007 | Setup2007.exe | Aspose.Slides.SharePoint2007.wsp |
| SharePoint 2010 | Setup2010.exe | Aspose.Slides.SharePoint2010.wsp |
| SharePoint Server 2013 | Setup2013.exe | Aspose.Slides.SharePoint2013.wsp |
| SharePoint Server 2016 | Setup2016.exe | Aspose.Slides.SharePoint2016.wsp |
| SharePoint Server 2019 | Setup2019.exe | Aspose.Slides.SharePoint2019.wsp |

Каждая программа установки имеет рядом конфигурационный файл (например, *Setup2019.exe.config*), в котором указано имя пакета решения, которое она устанавливает. Папка *License* содержит ссылку на пользовательское соглашение и уведомления о сторонних лицензиях.

Aspose.Slides for SharePoint упакован как решение SharePoint, которое развертывается по всей ферме серверов. Его функция затем активируется или деактивируется для каждой коллекции сайтов.

## **Процесс установки**

Перед установкой программа проверки системы проверяет:

- SharePoint установлен на сервере.
- У текущего пользователя есть права на установку и развертывание решений SharePoint.
- Служба администрирования SharePoint запущена.
- Служба таймера SharePoint запущена.
- Пакет решения, указанный в конфигурационном файле, присутствует.

Службы администрирования и таймера нужны, потому что некоторые действия установки выполняются как таймерные задания, распространяющие решение на все серверы фермы.

### **Запуск установки**

Чтобы установить Aspose.Slides for SharePoint:

1. Распакуйте ZIP‑архив на локальный диск сервера фермы SharePoint.
2. Запустите программу установки, соответствующую вашей версии SharePoint (см. таблицу выше), и следуйте инструкциям на экране. Программа установки:
   1. Выполняет проверку системы. Установка не продолжается, если какая‑либо проверка не прошла.

      **Выполнение проверки системы**

      ![Экран проверки системы программы установки](installing-aspose-slides-for-sharepoint_1.png)

   2. Отображает пользовательское соглашение. Его необходимо принять, чтобы продолжить.

      **Пользовательское соглашение**

      ![Экран пользовательского соглашения программы установки](installing-aspose-slides-for-sharepoint_2.png)

   3. Показывает цели развертывания. Выберите веб‑приложения и коллекции сайтов, для которых нужно активировать функцию.

      **Выбор целей развертывания**

      ![Экран выбора целей развертывания коллекций сайтов программы установки](installing-aspose-slides-for-sharepoint_3.png)

   4. Разворачивает решение в ферме.

      **Прогресс установки**

      ![Экран прогресса установки программы установки](installing-aspose-slides-for-sharepoint_4.png)

   5. Активирует Aspose.Slides for SharePoint в выбранных коллекциях сайтов.
   6. Показывает список веб‑приложений и коллекций сайтов, где решение было развернуто и активировано.

      **Успешная установка**

      ![Экран завершения установки программы установки](installing-aspose-slides-for-sharepoint_5.png)

{{% alert color="info" title="Note" %}}
Скриншоты сделаны в SharePoint 2007. Программы установки для более новых версий проходят те же экраны.
{{% /alert %}}

Если та же версия Aspose.Slides for SharePoint уже установлена, программа установки предложит её восстановить или удалить. Если установлена другая версия, будет предложено обновить или удалить её.

После установки в меню файлов библиотек документов выбранных коллекций сайтов появляется пункт **Convert via Aspose.Slides** (в SharePoint 2007 — **Convert with Aspose.Slides**). Чтобы конвертировать первую презентацию, см. [Converting Microsoft PowerPoint Documents into Other Formats](/slides/ru/sharepoint/converting-microsoft-powerpoint-documents-into-other-formats/). Что решение добавляет в ферму, описано в [Deployment and Activation](/slides/ru/sharepoint/deployment-and-activation/).

## **FAQ**

**Какую программу установки запустить?**

Ту, название которой соответствует вашей версии SharePoint. Например, запустите *Setup2016.exe* в ферме SharePoint Server 2016. Каждая программа установки ставит только свой собственный пакет решения.

**Нужна ли отдельная загрузка для лицензированной версии?**

Нет. Тот же пакет работает в режиме оценки, пока вы не установите лицензионное решение; см. [Installing Aspose.Slides for SharePoint License](/slides/ru/sharepoint/installing-aspose-slides-for-sharepoint-license/).

**Как удалить продукт?**

Снова запустите ту же программу установки и выберите **Remove**; см. [Uninstalling Aspose.Slides for SharePoint](/slides/ru/sharepoint/uninstalling-aspose-slides-for-sharepoint/).