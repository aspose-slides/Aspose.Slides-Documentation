---
title: Конвертировать PowerPoint в PDF в Node.js через .NET
linktitle: PowerPoint в PDF
type: docs
weight: 30
url: /ru/nodejs-net/convert-powerpoint-to-pdf/
keywords:
- PowerPoint в PDF
- конвертировать PowerPoint в PDF
- PPTX в PDF
- PPT в PDF
- ODP в PDF
- сохранить презентацию как PDF
- PDF/A
- PdfOptions
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Конвертировать презентации PPTX, PPT и ODP в PDF в JavaScript с помощью Aspose.Slides для Node.js через .NET и создавать архивные файлы PDF/A с использованием PdfOptions."
---
## **Обзор**

Aspose.Slides for Node.js via .NET преобразует презентации PowerPoint и OpenDocument в PDF без Microsoft PowerPoint. Каждый видимый слайд становится одной страницей PDF того же размера, что и слайд, и текст остаётся выделяемым и поисковым. В этой статье показаны конвертация по умолчанию и конвертация в PDF/A с [PdfOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/pdfoptions/).

В примерах ожидается презентация с именем `sample.pptx` в папке проекта, которую вы создали согласно [Installation](/slides/ru/nodejs-net/installation/). Подойдёт любая презентация PowerPoint. Сохраните каждый пример как файл `.js` в папке проекта и запустите его из этой папки командой `node`.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET не имеет собственной справки по API. Он отражает API Aspose.Slides for .NET с именами в стиле camelCase, поэтому ссылки на API в этой статье ведут к соответствующим классам и членам в справке [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/ru/net/).
{{% /alert %}}

## **Конвертировать презентацию в PDF**

Чтобы конвертировать презентацию в PDF, выполните следующие действия:

1. Откройте презентацию, передав её путь конструктору [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/presentation/). Тот же код работает с файлами PPTX, PPT и ODP.
2. Вызовите метод [save](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/save/) с путём вывода и `SaveFormat.Pdf`.
3. Вызовите `dispose` в блоке `finally`, чтобы освободить ресурсы .NET, поддерживающие презентацию.

```javascript
const { Presentation, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    presentation.save("sample.pdf", SaveFormat.Pdf);
    console.log("Saved sample.pdf");
} finally {
    presentation.dispose();
}
```

Скрипт записывает `sample.pdf` в папку проекта. Конвертация использует настройки по умолчанию: каждый слайд, который не скрыт, становится страницей в порядке следования слайдов. Без лицензии на каждой странице также отображается водяной знак оценки; см. раздел [Licensing](/slides/ru/nodejs-net/licensing/).

## **Конвертировать презентацию в PDF/A**

Чтобы управлять выводом, передайте объект [PdfOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/pdfoptions/) в качестве третьего аргумента метода `save`. В следующем примере свойству [compliance](https://reference.aspose.com/slides/ru/net/aspose.slides.export/pdfoptions/compliance/) присваивается значение `PdfCompliance.PdfA2b`, что приводит к созданию файла PDF/A-2b. PDF/A — это стандарт ISO для долговременного архивирования: среди прочих требований он требует встраивание в файл всех шрифтов, используемых документом.

```javascript
const { Presentation, SaveFormat, PdfOptions, PdfCompliance } = require("aspose.slides.via.net");

const pdfOptions = new PdfOptions();
pdfOptions.compliance = PdfCompliance.PdfA2b;

const presentation = new Presentation("sample.pptx");
try {
    presentation.save("sample-pdfa.pdf", SaveFormat.Pdf, pdfOptions);
    console.log("Saved sample-pdfa.pdf");
} finally {
    presentation.dispose();
}
```

Скрипт записывает `sample-pdfa.pdf` с теми же страницами, что и при конвертации по умолчанию. Чтобы убедиться, что файл соответствует стандарту, проверьте его с помощью валидатора PDF/A, например [veraPDF](https://verapdf.org/). Другие значения [PdfCompliance](https://reference.aspose.com/slides/ru/net/aspose.slides.export/pdfcompliance/) выбирают другие стандарты, такие как `PdfA1b`, `PdfA2a` или `PdfUa` для доступности.

## **Часто задаваемые вопросы**

**Как включить скрытые слайды в PDF?**

Скрытые слайды по умолчанию пропускаются. Установите свойство `showHiddenSlides` объекта `PdfOptions` в значение `true` и передайте параметры в метод `save`.

**Могу ли я защитить PDF паролем?**

Да. Установите свойство `password` объекта `PdfOptions` перед вызовом `save`. Затем PDF‑просмотрщики запросят этот пароль перед открытием файла.

**Могу ли я конвертировать только некоторые слайды?**

Да. Передайте массив позиций слайдов в качестве четвёртого аргумента метода `save`. Позиции начинаются с 1, а третий аргумент может быть `null`, если параметры не нужны: `presentation.save("selected.pdf", SaveFormat.Pdf, null, [1, 3])` записывает PDF с первым и третьим слайдами.

**Почему текст выглядит иначе при конвертации в Linux?**

Aspose.Slides может использовать только шрифты, установленные на машине, где выполняется конвертация. Если в презентации используется шрифт, которого нет, например Calibri на типичном Linux‑сервере, Aspose.Slides заменит его установленным шрифтом, что может изменить внешний вид текста и переносы строк. Установите необходимые шрифты, используемые вашими презентациями, чтобы получить такой же результат, как на Windows.

**Можно ли получить PDF в виде Buffer вместо файла?**

Да. `presentation.saveToBuffer(SaveFormat.Pdf)` возвращает PDF в виде объекта Node.js `Buffer`, что удобно при отправке результата в HTTP‑ответе. Этот метод также принимает `PdfOptions` в качестве второго аргумента.