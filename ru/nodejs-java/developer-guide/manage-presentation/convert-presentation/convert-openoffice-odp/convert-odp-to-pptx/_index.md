---
title: Конвертировать ODP в PPTX
type: docs
weight: 10
url: /ru/nodejs-java/convert-odp-to-pptx/
---

## **Конвертировать ODP в презентацию PPTX/PPT**
Aspose.Slides for Node.js via Java предлагает класс [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation), который представляет файл презентации. Класс [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) теперь также может получать доступ к ODP через конструктор [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#Presentation-java.lang.String-) при создании объекта. Следующий пример показывает, как преобразовать презентацию ODP в презентацию PPTX.
```javascript
// Открыть файл ODP
var pres = new aspose.slides.Presentation("AccessOpenDoc.odp");
// Сохранение презентации ODP в формат PPTX
pres.save("AccessOpenDoc_out.pptx", aspose.slides.SaveFormat.Pptx);
```


## **Рабочий пример**
Вы можете посетить [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) веб‑приложение, которое построено с использованием **Aspose.Slides API**. Приложение демонстрирует, как можно реализовать конвертацию ODP в PPTX с помощью Aspose.Slides API.

## **Часто задаваемые вопросы**

**Нужен ли мне Microsoft PowerPoint или LibreOffice для конвертации ODP в PPTX?**

Нет. Aspose.Slides работает автономно и не требует сторонних приложений для чтения или записи ODP/PPTX.

**Сохраняются ли master‑slides, макеты и темы при конвертации?**

Да. Библиотека использует полную модель объектов презентации и сохраняет структуру, включая master‑slides и макеты, поэтому дизайн остаётся корректным после конвертации.

**Могу ли я конвертировать защищённые паролем файлы ODP?**

Да. Aspose.Slides поддерживает обнаружение защиты, открытие и работу с [protected presentations](/slides/ru/nodejs-java/password-protected-presentation/) (включая ODP), когда вы предоставляете пароль, а также настройку шифрования и доступ к свойствам документа.

**Подходит ли Aspose.Slides для облачных или REST‑ориентированных сервисов конвертации?**

Да. Вы можете использовать локальную библиотеку в своём бэкенде или [Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/) (REST API); оба варианта поддерживают конвертацию ODP → PPTX.