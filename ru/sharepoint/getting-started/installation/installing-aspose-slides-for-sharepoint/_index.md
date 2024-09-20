---
title: Установка Aspose.Slides для SharePoint
type: docs
weight: 10
url: /sharepoint/installing-aspose-slides-for-sharepoint/
---

{{% alert color="primary" %}} 

Aspose.Slides для SharePoint загружается в виде архива Aspose.Slides.SharePoint.zip. Архив содержит: 

- **Aspose.Slides.SharePoint.wsp**: Файл решения SharePoint. Aspose.Slides для SharePoint упакован в решение SharePoint для облегчения активации и деактивации по всей серверной ферме.
- **Aspose_LicenseAgreement.rtf**: Лицензионное соглашение конечного пользователя.
- **Setup.exe**: Программа установки.
- **Setup.exe.config**: Файл конфигурации установки.

{{% /alert %}} 
## **Процесс установки**
Перед запуском установки программа установки проверяет, что:

- Установлены WSS 3.0 или MOSS 2007.
- У пользователя есть разрешение на установку решений SharePoint.
- База данных SharePoint работает.
- Служба администрирования WSS запущена.
- Служба таймера WSS запущена.

Службы администрирования и таймера WSS необходимы, потому что некоторые действия установки зависят от задания таймера для распространения на все серверы в серверной ферме.
### **Запуск установки**
Чтобы установить Aspose.Slides для SharePoint: 

1. Распакуйте Aspose.Slides.SharePoint.zip на локальный диск на сервере MOSS 7.0 или WSS 3.0.
2. Запустите setup.exe и следуйте инструкциям на экране.
   Программа установки выполняет следующие действия: 
   1. Проверяет prerequisites для установки. Установка не продолжится, если любая проверка не выполнена. 

      **Запуск проверки системы** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_1.png)




3. Отображает Лицензионное соглашение конечного пользователя. Вы должны принять соглашение, чтобы продолжить. 

   **EULA** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_2.png)




4. Отображает выбор целевых развертываний. Выберите веб-приложения и коллекции сайтов, для которых функция должна быть активирована. 

   **Выбор целевых развертываний** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_3.png)




5. Развертывает функцию на серверной ферме. 

   **Индикатор прогресса установки** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_4.png)




6. Активирует Aspose.Slides для выбранных коллекций сайтов и настраивает их родительские веб-приложения.
7. Отображает список веб-приложений и коллекций сайтов, для которых функция была развернута и активирована. 

   **Успешная установка** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_5.png)