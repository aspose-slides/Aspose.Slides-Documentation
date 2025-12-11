---
title: Конвертация ODP в PPTX на Android
linktitle: ODP в PPTX
type: docs
weight: 10
url: /ru/androidjava/convert-odp-to-pptx/
keywords:
- конвертировать OpenDocument
- конвертировать презентацию
- конвертировать слайд
- конвертировать ODP
- OpenDocument в PPTX
- ODP в PPTX
- сохранить ODP как PPTX
- экспортировать ODP в PPTX
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Конвертировать ODP в PPTX с помощью Aspose.Slides для Android. Чистые примеры кода на Java, советы по пакетной обработке и результаты высокого качества — PowerPoint не требуется."
---

## **Конвертация ODP в презентацию PPTX/PPT**
Aspose.Slides for Android via Java предоставляет класс [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation), который представляет файл презентации. Класс [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) теперь также может получать доступ к ODP через конструктор [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#Presentation-java.lang.String-), когда объект создаётся. В следующем примере показано, как преобразовать презентацию ODP в презентацию PPTX.
```java
// Откройте файл ODP
Presentation pres = new Presentation("AccessOpenDoc.odp");
try {}
// Сохранение презентации ODP в формат PPTX
    pres.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Рабочий пример**
Вы можете посетить [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) веб-приложение, которое построено с использованием **Aspose.Slides API**. Приложение демонстрирует, как можно реализовать конвертацию ODP в PPTX с помощью Aspose.Slides API.

## **FAQ**

**Нужно ли устанавливать Microsoft PowerPoint или LibreOffice для конвертации ODP в PPTX?**

Нет. Aspose.Slides работает автономно и не требует сторонних приложений для чтения или записи ODP/PPTX.

**Сохраняются ли мастер‑слайды, макеты и темы при конвертации?**

Да. Библиотека использует полную модель объектной структуры презентации и сохраняет структуру, включая мастер‑слайды и макеты, поэтому дизайн остаётся корректным после конвертации.

**Можно ли конвертировать защищённые паролем файлы ODP?**

Да. Aspose.Slides поддерживает обнаружение защиты, открытие и работу с [защищённые презентации](/slides/ru/androidjava/password-protected-presentation/) (включая ODP), когда вы предоставляете пароль, а также настройку шифрования и доступ к свойствам документа.

**Подходит ли Aspose.Slides для облачных или REST‑ориентированных сервисов конвертации?**

Да. Вы можете использовать локальную библиотеку в своём бэкенде или [Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/) (REST API); оба варианта поддерживают конвертацию ODP → PPTX.