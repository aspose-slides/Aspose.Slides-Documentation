---
title: Обработка предупреждений презентаций в Node.js
type: docs
weight: 90
url: /ru/nodejs-java/presentation-warnings/
aliases:
- /nodejs-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- callback предупреждения
- политика предупреждений
- потеря данных
- повреждение источника
- проблема совместимости
- замена шрифтов
- цифровая подпись
- загрузка презентации
- рендеринг презентации
- конвертация презентации
- сохранение презентации
- PowerPoint
- OpenDocument
- JavaScript
- Node.js
- Aspose.Slides
description: "Узнайте, как собирать, классифицировать и реагировать на предупреждения при загрузке, рендеринге, конвертации и сохранении презентаций с помощью Aspose.Slides для Node.js через Java."
---
## **Обзор**

Aspose.Slides может сообщать о восстанавливаемых проблемах во время загрузки, рендеринга, конвертации или сохранения презентации. Примеры включают повреждённые исходные записи, контент, который невозможно сохранить, замену шрифтов и ограничения целевого формата. Обратный вызов предупреждений позволяет приложению фиксировать эти условия и решать, может ли текущая операция продолжиться.

Используйте `java.newProxy` для реализации [IWarningCallback](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iwarningcallback/) Java‑интерфейса в JavaScript и изучите значения, возвращаемые через [IWarningInfo](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iwarninginfo/), с помощью [getWarningType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iwarninginfo/#getWarningType--) и [getDescription](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iwarninginfo/#getDescription--). Верните [ReturnAction.Continue](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/returnaction/#Continue), чтобы принять предупреждение, или [ReturnAction.Abort](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/returnaction/#Abort), чтобы остановить операцию.

Используйте [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/loadoptions/#setWarningCallback) для предупреждений, возникающих при открытии презентации. Классы параметров рендеринга и экспорта наследуют [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/saveoptions/#setWarningCallback), который получает предупреждения от рендеринга слайдов, конвертации и сохранения. Поскольку само предупреждение не указывает, какая часть приложения его вызвала, привязывайте каждый экземпляр обратного вызова к конкретному этапу операции при построении комбинированного отчёта.

## **Предупреждения и исключения**

Предупреждение описывает условие, из которого Aspose.Slides может восстановиться, если обратный вызов вернёт `ReturnAction.Continue`. Исключение означает, что запрошенная операция не может завершиться нормально; исключения не преобразуются в предупреждения и не могут обрабатываться политикой предупреждений.

Возврат `ReturnAction.Abort` просит диспетчер предупреждений завершить текущую операцию, сгенерировав исключение. Публичный тип исключения зависит от операции и формата презентации. Например, при загрузке может возникнуть [PptxReadException](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pptxreadexception/) или [PptReadException](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pptreadexception/), а при сохранении или экспорте — [PptxException](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pptxexception/). Перехватывайте ошибку из Java‑моста на границе операции и используйте отчёт о предупреждениях, чтобы определить, привела ли политика приложения к завершению, а не полагаться только на тип исключения или его сообщение. Обратный вызов фиксирует предупреждение перед возвратом `ReturnAction.Abort`, обеспечивая доступность причины для приложения.

## **Категории предупреждений**

Класс [WarningType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/warningtype/) предоставляет целочисленные константы для следующих категорий:

| Тип предупреждения | Значение | Типичная политика |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/warningtype/#SourceFileCorruption) | Исходная презентация содержит повреждения, из‑за которых документ, сохранённый в оригинальном формате, может стать непригодным. | Прервать. |
| [DataLoss](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/warningtype/#DataLoss) | Текст, диаграммы, изображения или другие данные могут быть утеряны после загрузки или сохранения. | Прервать. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/warningtype/#MajorFormattingLoss) | Презентация может потерять важное форматирование. | Прервать в режиме строгой валидации; иначе записать и продолжить. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/warningtype/#MinorFormattingLoss) | Может возникнуть ограниченное отличие в форматировании. | Записать для диагностики и продолжить. |
| [CompatibilityIssue](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/warningtype/#CompatibilityIssue) | Результат может не открываться или работать некорректно в некоторых приложениях или старых версиях. | Журналировать и продолжать, если совместимость не является обязательной. |
| [UnexpectedContent](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/warningtype/#UnexpectedContent) | Исходный файл содержит неподдерживаемый или нераспознанный контент, воздействие которого пока неизвестно. | Записать и продолжить, либо считать ошибкой при строгой политике. |

Категория должна определять решение политики. Сохраняйте значение, возвращаемое [getDescription](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iwarninginfo/#getDescription--), для диагностики, но не полагайтесь на его формулировку в логике приложения, поскольку текст сообщения может различаться между сценариями предупреждений и версиями продукта.

## **Сбор и классификация предупреждений**

Следующий пример JavaScript использует один отчёт уровня приложения для всей цепочки обработки. Отдельный экземпляр обратного вызова маркирует предупреждения, полученные при загрузке, рендеринге, конвертации в PDF и сохранении в PPTX. Политика прерывает работу при повреждении источника или потере данных, опционально прерывает при серьёзной потере форматирования и продолжает для остальных предупреждений.

```javascript
const java = require("java");
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

class WarningPolicy {
    constructor(abortOnMajorFormattingLoss) {
        this.abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
    }

    getAction(warningType) {
        if (warningType === aspose.slides.WarningType.SourceFileCorruption || warningType === aspose.slides.WarningType.DataLoss) {
            return aspose.slides.ReturnAction.Abort;
        }

        if (warningType === aspose.slides.WarningType.MajorFormattingLoss && this.abortOnMajorFormattingLoss) {
            return aspose.slides.ReturnAction.Abort;
        }

        return aspose.slides.ReturnAction.Continue;
    }
}

function createReportingWarningCallback(stage, report, policy) {
    return java.newProxy("com.aspose.slides.IWarningCallback", {
        warning: function (warning) {
            const type = warning.getWarningType();
            const description = warning.getDescription();
            report.push({ stage, type, description });
            return policy.getAction(type);
        }
    });
}

function processPresentation(inputPath, report, policy) {
    try {
        const loadOptions = new aspose.slides.LoadOptions();
        const callback = createReportingWarningCallback("Loading", report, policy);
        loadOptions.setWarningCallback(callback);

        const presentation = new aspose.slides.Presentation(inputPath, loadOptions);
        try {
            if (!renderFirstSlide(presentation, report, policy)) {
                return false;
            }

            if (!convertToPdf(presentation, report, policy)) {
                return false;
            }

            return saveValidatedCopy(presentation, report, policy);
        } finally {
            presentation.dispose();
        }
    } catch (error) {
        console.error("Loading stopped: " + error.message);
        return false;
    }
}

function renderFirstSlide(presentation, report, policy) {
    if (presentation.getSlides().size() === 0) {
        console.error("Rendering stopped: the presentation has no slides.");
        return false;
    }

    try {
        const options = new aspose.slides.RenderingOptions();
        const callback = createReportingWarningCallback("Rendering", report, policy);
        options.setWarningCallback(callback);

        const image = presentation.getSlides().get_Item(0).getImage(options);
        try {
            image.save("slide-1.png", aspose.slides.ImageFormat.Png);
            return true;
        } finally {
            image.dispose();
        }
    } catch (error) {
        console.error("Rendering stopped: " + error.message);
        return false;
    }
}

function convertToPdf(presentation, report, policy) {
    try {
        const options = new aspose.slides.PdfOptions();
        const callback = createReportingWarningCallback("Conversion", report, policy);
        options.setWarningCallback(callback);

        presentation.save("converted.pdf", aspose.slides.SaveFormat.Pdf, options);
        return true;
    } catch (error) {
        console.error("Conversion stopped: " + error.message);
        return false;
    }
}

function saveValidatedCopy(presentation, report, policy) {
    try {
        const options = new aspose.slides.PptxOptions();
        const callback = createReportingWarningCallback("Saving", report, policy);
        options.setWarningCallback(callback);

        presentation.save("validated-output.pptx", aspose.slides.SaveFormat.Pptx, options);
        return true;
    } catch (error) {
        console.error("Saving stopped: " + error.message);
        return false;
    }
}

function warningTypeName(warningType) {
    switch (warningType) {
        case aspose.slides.WarningType.SourceFileCorruption:
            return "SourceFileCorruption";
        case aspose.slides.WarningType.DataLoss:
            return "DataLoss";
        case aspose.slides.WarningType.MajorFormattingLoss:
            return "MajorFormattingLoss";
        case aspose.slides.WarningType.MinorFormattingLoss:
            return "MinorFormattingLoss";
        case aspose.slides.WarningType.CompatibilityIssue:
            return "CompatibilityIssue";
        case aspose.slides.WarningType.UnexpectedContent:
            return "UnexpectedContent";
        default:
            return "Unknown (" + warningType + ")";
    }
}

const report = [];
const policy = new WarningPolicy(true);
const completed = processPresentation("input.pptx", report, policy);

console.log(completed ? "Processing completed." : "Processing stopped.");

for (const entry of report) {
    const typeName = warningTypeName(entry.type);
    console.log("[" + entry.stage + "] " + typeName + ": " + entry.description);
}
```

Передайте `false` для `abortOnMajorFormattingLoss` при создании `WarningPolicy`, если серьёзные различия в форматировании допустимы. Проблемы совместимости, небольшие потери форматирования и неожиданный контент всё равно сохраняются в отчёте, даже если операция продолжается. При необходимости отклонять любые из этих категорий расширьте `WarningPolicy.getAction`.

## **Распространённые сценарии предупреждений**

- **Digital signatures:** Подписанная презентация может вызвать предупреждение при загрузке, что её подпись будет утеряна в процессе обработки. Aspose.Slides сообщает об этом условии `DataLoss` через [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipresentationsignedwarninginfo/). Обратный вызов на этапе загрузки позволяет приложению отклонить файл или явно принять сообщённую потерю.
- **Font substitution:** Недоступный шрифт может быть заменён во время рендеринга или экспорта слайда. Предупреждения о замене шрифтов сообщаются как `DataLoss`, поэтому строгая политика выше прерывает процесс, даже если приложение считает замену визуально приемлемой. Чтобы увидеть это поведение, используйте презентацию с текстом, написанным шрифтом, отсутствующим в среде выполнения. Описание предупреждения указывает замену; настройте необходимые шрифты или [правила замены шрифтов](/slides/ru/nodejs-java/font-substitution/) перед повторной попыткой.
- **Unsupported or unexpected content:** Загрузчик может столкнуться с записями презентации или функциями, которые он не распознаёт. Такие предупреждения могут использовать `UnexpectedContent` или более строгую категорию, если известны потери данных или форматирования.
- **Format compatibility:** Сохранение в другой формат презентации может опустить функции или привести к результату, который ведёт себя иначе в некоторых приложениях. Например, сохранение презентации с более чем восемью горизонтальными или вертикальными направляющими черчения в устаревший PPT генерирует `CompatibilityIssue`. Обратный вызов на этапе сохранения может зафиксировать потерю и продолжить, либо отклонить её, если необходимо сохранить все направляющие.
- **Loading behavior:** Параметры загрузки и наследованное поведение могут также генерировать предупреждения. Например, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) идентифицирует использование устаревшего поведения блокировки презентации как `CompatibilityIssue`.

Предупреждения зависят от исходного документа, целевого формата, операции и версии Aspose.Slides. Не следует полагать, что каждый файл генерирует предупреждение или что сценарий всегда относится к одной категории.

## **Безопасная обработка прерванных операций**

Когда обратный вызов возвращает `ReturnAction.Abort`, не используйте объект, который не удалось загрузить, и не предполагайте, что результат рендеринга или сохранения завершён. Операция может завершиться после создания выходного файла, но до его полного завершения.

Сохраняйте проверенные результаты в отдельный путь, например `validated-output.pptx`. Заменяйте существующую презентацию только после успешного завершения операции, когда отчёт о предупреждениях соответствует политике приложения, и файл можно открыть и проверить. Это предотвращает перезапись корректного исходного файла частичным или отклонённым результатом.

Пустой отчёт о предупреждениях не гарантирует, что все исходные функции сохранены. Выполните любые дополнительные проверки содержимого и визуального отображения, требуемые приложением. См. также [Open Presentations](/slides/ru/nodejs-java/open-presentation/) и [Save Presentations](/slides/ru/nodejs-java/save-presentation/).

## **Вопросы и ответы**

**Может ли обратный вызов предупреждений обработать каждую ошибку Aspose.Slides?**

Нет. Он обрабатывает восстанавливаемые условия, сообщаемые как предупреждения. Исключения, возникающие независимо от обратного вызова, должны обрабатываться приложением вокруг вызова загрузки, рендеринга, конвертации или сохранения.

**Гарантирует ли возврат `ReturnAction.Continue` идентичный результат?**

Нет. Он лишь позволяет продолжить обработку. Сообщённое условие всё равно может привести к потерям данных, форматирования или различиям в совместимости, поэтому необходимо просматривать собранные типы предупреждений и их описания.

**Как приложению определить, какая операция вызвала предупреждение?**

Создайте отдельный экземпляр обратного вызова для каждой операции и храните определённый приложением этап вместе со значениями, возвращаемыми [getWarningType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iwarninginfo/#getWarningType--) и [getDescription](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iwarninginfo/#getDescription--), как показано в примере.