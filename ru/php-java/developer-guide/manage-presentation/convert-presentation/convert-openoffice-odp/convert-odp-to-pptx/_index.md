---
title: Конвертировать ODP в PPTX в PHP
linktitle: ODP в PPTX
type: docs
weight: 10
url: /ru/php-java/convert-odp-to-pptx/
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
- PHP
- Aspose.Slides
description: "Преобразуйте ODP в PPTX с помощью Aspose.Slides для PHP через Java. Чистые примеры кода, советы по пакетной обработке и высококачественные результаты — PowerPoint не требуется."
---

## **Преобразование ODP в презентацию PPTX/PPT**
Aspose.Slides for PHP via Java предлагает класс [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation), который представляет файл презентации. Класс [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) теперь также может работать с ODP через конструктор [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#Presentation-java.lang.String-) при создании объекта. Ниже приведён пример, показывающий, как преобразовать презентацию ODP в презентацию PPTX.
```php
// Открыть файл ODP
  $pres = new Presentation("AccessOpenDoc.odp");
  try {
  } finally {
  }
  # Сохранение презентации ODP в формате PPTX
  $pres->save("AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```


## **Рабочий пример**
Вы можете посетить веб‑приложение [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/), построенное на **Aspose.Slides API**. Приложение демонстрирует, как реализовать конвертацию ODP в PPTX с помощью Aspose.Slides API.

## **FAQ**

**Нужно ли устанавливать Microsoft PowerPoint или LibreOffice для конвертации ODP в PPTX?**

Нет. Aspose.Slides работает автономно и не требует сторонних приложений для чтения или записи ODP/PPTX.

**Сохраняются ли мастер‑слайды, макеты и темы при конвертации?**

Да. Библиотека использует полную модель объекта презентации и сохраняет структуру, включая мастер‑слайды и макеты, поэтому дизайн остаётся корректным после конвертации.

**Можно ли конвертировать защищённые паролем файлы ODP?**

Да. Aspose.Slides поддерживает обнаружение защиты, открытие и работу с [protected presentations](/slides/ru/php-java/password-protected-presentation/) (включая ODP), если предоставить пароль, а также настройку шифрования и доступ к свойствам документа.

**Подходит ли Aspose.Slides для облачных или REST‑ориентированных сервисов конвертации?**

Да. Вы можете использовать локальную библиотеку в собственном бекенде или [Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/) (REST API); оба варианта поддерживают конвертацию ODP → PPTX.