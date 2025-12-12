---
title: "Преобразование ODP в PPTX на Android"
linktitle: "ODP в PPTX"
type: docs
weight: 10
url: /ru/androidjava/convert-odp-to-pptx/
keywords:
- "преобразовать OpenDocument"
- "преобразовать презентацию"
- "преобразовать слайд"
- "преобразовать ODP"
- "OpenDocument в PPTX"
- "ODP в PPTX"
- "сохранить ODP как PPTX"
- "экспортировать ODP в PPTX"
- "PowerPoint"
- "OpenDocument"
- "презентация"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Преобразование ODP в PPTX с помощью Aspose.Slides для Android. Чистые примеры кода на Java, советы по пакетной обработке и высококачественные результаты - PowerPoint не требуется."
---

## **Преобразовать ODP в презентацию PPTX/PPT**
Aspose.Slides for Android via Java предлагает класс [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation), представляющий файл презентации. Класс [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) теперь также может получать доступ к ODP через конструктор [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#Presentation-java.lang.String-) при создании объекта. Следующий пример показывает, как преобразовать презентацию ODP в презентацию PPTX.
```java
// Откройте файл ODP
Presentation pres = new Presentation("AccessOpenDoc.odp");
try {}
// Сохранение презентации ODP в формате PPTX
    pres.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Рабочий пример**
Вы можете посетить веб‑приложение [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/), которое построено с помощью **Aspose.Slides API.** Приложение демонстрирует, как преобразование ODP в PPTX может быть реализовано с помощью Aspose.Slides API.

## **Часто задаваемые вопросы**
**Нужно ли устанавливать Microsoft PowerPoint или LibreOffice для преобразования ODP в PPTX?**
Нет. Aspose.Slides работает автономно и не требует сторонних приложений для чтения или записи ODP/PPTX.

**Сохраняются ли мастер‑слайды, макеты и темы при преобразовании?**
Да. Библиотека использует полную объектную модель презентации и сохраняет структуру, включая мастер‑слайды и макеты, поэтому дизайн остается корректным после преобразования.

**Могу ли я преобразовать защищённые паролем файлы ODP?**
Да. Aspose.Slides поддерживает обнаружение защиты, открытие и работу с [защищённые презентации](/slides/ru/androidjava/password-protected-presentation/) (включая ODP), когда вы предоставляете пароль, а также настройку шифрования и доступ к свойствам документа.

**Подходит ли Aspose.Slides для облачных или REST‑ориентированных сервисов преобразования?**
Да. Вы можете использовать локальную библиотеку в собственном бэкенде или [Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/) (REST API); оба варианта поддерживают преобразование ODP → PPTX.