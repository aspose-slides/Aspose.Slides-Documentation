---
title: Конвертация ODP в PPTX на Python
linktitle: ODP в PPTX
type: docs
weight: 10
url: /ru/python-net/convert-odp-to-pptx/
keywords:
- конвертировать OpenDocument
- конвертировать ODP
- OpenDocument в PPTX
- ODP в PPTX
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Конвертировать ODP в PPTX с помощью Aspose.Slides for Python via .NET. Чистый пример кода, советы по пакетной обработке и высококачественные результаты — PowerPoint не требуется."
---

## **Экспорт ODP в PPTX**

Aspose.Slides for Python via .NET предлагает класс Presentation, который представляет файл презентации. [**Presentation**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) класс теперь также может получать доступ к ODP через конструктор Presentation при создании объекта. Следующий пример показывает, как преобразовать презентацию ODP в презентацию PPTX.
```py
# Импортировать модуль Aspose.Slides для Python через .NET
import aspose.slides as slides

# Открыть файл ODP
pres = slides.Presentation("AccessOpenDoc.odp")

# Сохранение презентации ODP в формат PPTX
pres.save("AccessOpenDoc_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Рабочий пример**

Вы можете посетить веб‑приложение [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/), построенное с использованием **Aspose.Slides API.** Приложение демонстрирует, как можно реализовать конвертацию ODP в PPTX с помощью Aspose.Slides API.

## **Часто задаваемые вопросы**

**Нужно ли устанавливать Microsoft PowerPoint или LibreOffice для конвертации ODP в PPTX?**

Нет. Aspose.Slides работает автономно и не требует сторонних приложений для чтения или записи ODP/PPTX.

**Сохраняются ли мастер‑слайды, макеты и темы при конвертации?**

Да. Библиотека использует полную объектную модель презентации и сохраняет структуру, включая мастер‑слайды и макеты, поэтому дизайн остаётся корректным после конвертации.

**Можно ли конвертировать защищённые паролем ODP‑файлы?**

Да. Aspose.Slides поддерживает определение защиты, открытие и работу с [защищённые презентации](/slides/ru/python-net/password-protected-presentation/) (включая ODP), когда вы предоставляете пароль, а также настройку шифрования и доступ к свойствам документа.

**Подходит ли Aspose.Slides для облачных или REST‑ориентированных сервисов конвертации?**

Да. Вы можете использовать локальную библиотеку в своем бэкенде или [Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/) (REST API); оба варианта поддерживают конвертацию ODP → PPTX.