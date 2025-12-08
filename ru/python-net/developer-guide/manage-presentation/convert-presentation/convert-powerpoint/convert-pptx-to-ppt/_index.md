---
title: Конвертировать PPTX в PPT на Python
linktitle: PPTX в PPT
type: docs
weight: 21
url: /ru/python-net/convert-pptx-to-ppt/
keywords:
- PPTX в PPT
- конвертировать PPTX в PPT
- конвертировать PowerPoint
- конвертировать презентацию
- Python
- Aspose.Slides
description: "Легко конвертировать PPTX в PPT с помощью Aspose.Slides for Python через .NET - обеспечьте беспроблемную совместимость с форматами PowerPoint, сохраняя макет и качество вашей презентации."
---

## **Обзор**

Aspose.Slides for Python позволяет конвертировать современные презентации PPTX в устаревший формат PPT полностью программно. Откройте PPTX и экспортируйте его как PPT, сохранив содержимое и макет презентации, делая результат совместимым со старыми версиями PowerPoint. Тот же рабочий процесс может создавать другие типы вывода — такие как PDF, XPS, ODP, HTML или изображения — поэтому его легко интегрировать в скрипты, конвейеры CI и пакетную обработку.

## **Конвертировать PPTX в PPT**

Чтобы конвертировать PPTX в PPT, просто передайте имя файла и формат сохранения методу [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). Приведённый ниже пример на Python конвертирует презентацию из PPTX в PPT, используя параметры по умолчанию.
```py
import aspose.slides as slides

# Создать экземпляр класса Presentation, представляющего файл PPTX.
presentation = slides.Presentation("presentation.pptx")

# Сохранить презентацию как файл PPT.
presentation.save("presentation.ppt", slides.export.SaveFormat.PPT)
```


## **FAQ**

**Все ли эффекты и функции PPTX сохраняются при сохранении в устаревший формат PPT (97–2003)?**

Не всегда. Формат PPT не поддерживает некоторые новые возможности (например, определённые эффекты, объекты и поведения), поэтому функции могут быть упрощены или растеризованы при конвертации.

**Можно ли конвертировать только выбранные слайды в PPT вместо всей презентации?**

Прямое сохранение ориентировано на всю презентацию. Чтобы конвертировать конкретные слайды, создайте новую презентацию, содержащую только эти слайды, и сохраните её как PPT; альтернативно используйте сервис/API, поддерживающий параметры конвертации по слайдам.

**Поддерживаются ли защищённые паролем презентации?**

Да. Вы можете определить, защищён ли файл, открыть его с паролем, а также [configure protection/encryption settings](/slides/ru/python-net/password-protected-presentation/) для сохраняемого PPT.

**См. также:**
- [Конвертировать PPT и PPTX в PDF на Python | Расширенные параметры](/slides/ru/python-net/convert-powerpoint-to-pdf/)
- [Конвертировать презентации PowerPoint в XPS на Python](/slides/ru/python-net/convert-powerpoint-to-xps/)
- [Конвертировать презентации PowerPoint в HTML на Python](/slides/ru/python-net/convert-powerpoint-to-html/)
- [Конвертировать слайды PowerPoint в PNG на Python](/slides/ru/python-net/convert-powerpoint-to-png/)