---
title: Обработка предупреждений презентаций в .NET
type: docs
weight: 120
url: /ru/net/presentation-warnings/
aliases:
- /net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- обратный вызов предупреждения
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
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как собирать, классифицировать и реагировать на предупреждения при загрузке, рендеринге, конвертации и сохранении презентаций с помощью Aspose.Slides для .NET."
---
## **Обзор**

Aspose.Slides может сообщать о восстанавливаемых проблемах во время загрузки, рендеринга, конвертации или сохранения презентации. Примеры включают повреждённые исходные записи, содержимое, которое невозможно сохранить, замену шрифтов и ограничения целевого формата. Обратный вызов предупреждения позволяет приложению фиксировать эти условия и решать, может ли текущая операция продолжаться.

Реализуйте интерфейс [IWarningCallback](https://reference.aspose.com/slides/ru/net/aspose.slides.warnings/iwarningcallback/) и изучите свойства [WarningType](https://reference.aspose.com/slides/ru/net/aspose.slides.warnings/iwarninginfo/warningtype/) и [Description](https://reference.aspose.com/slides/ru/net/aspose.slides.warnings/iwarninginfo/description/), предоставленные через [IWarningInfo](https://reference.aspose.com/slides/ru/net/aspose.slides.warnings/iwarninginfo/). Верните [ReturnAction.Continue](https://reference.aspose.com/slides/ru/net/aspose.slides.warnings/returnaction/) чтобы принять предупреждение или `ReturnAction.Abort`, чтобы остановить операцию.

Используйте [LoadOptions.WarningCallback](https://reference.aspose.com/slides/ru/net/aspose.slides/loadoptions/warningcallback/) для предупреждений, возникших при открытии презентации. Классы параметров рендеринга и экспорта наследуют [SaveOptions.WarningCallback](https://reference.aspose.com/slides/ru/net/aspose.slides.export/saveoptions/warningcallback/), который получает предупреждения от рендеринга слайдов, конвертации и сохранения. Поскольку само предупреждение не указывает, какая операция приложения вызвала его, связывайте каждый экземпляр обратного вызова со стадией операции при построении комбинированного отчёта.

## **Предупреждения и исключения**

Предупреждение описывает условие, из которого Aspose.Slides может восстановиться, если обратный вызов вернёт `ReturnAction.Continue`. Исключение значит, что запрошенная операция не может завершиться нормально; исключения не преобразуются в предупреждения и не могут быть обработаны политикой предупреждений.

Возврат `ReturnAction.Abort` просит диспетчера предупреждений завершить текущую операцию, вызвав исключение. Публичное исключение зависит от операции и формата презентации. Например, при загрузке может быть выброшено [PptxReadException](https://reference.aspose.com/slides/ru/net/aspose.slides/pptxreadexception/) или [PptReadException](https://reference.aspose.com/slides/ru/net/aspose.slides/pptreadexception/), а при сохранении или экспорте — [PptxException](https://reference.aspose.com/slides/ru/net/aspose.slides/pptxexception/). Обрабатывайте исключение на границе операции и используйте отчёт о предупреждениях, чтобы определить, привела ли политика приложения к завершению, а не полагайтесь лишь на тип или сообщение исключения. Обратный вызов фиксирует предупреждение перед возвратом `ReturnAction.Abort`, гарантируя, что причина остаётся доступной приложению.

## **Категории предупреждений**

Перечисление [WarningType](https://reference.aspose.com/slides/ru/net/aspose.slides.warnings/warningtype/) предоставляет следующие категории:

| Тип предупреждения | Смысл | Типовая политика |
| --- | --- | --- |
| `SourceFileCorruption` | Исходная презентация содержит повреждения, которые могут сделать документ, сохранённый в оригинальном формате, непригодным. | Прервать. |
| `DataLoss` | Текст, диаграммы, изображения или другие данные могут отсутствовать после загрузки или сохранения. | Прервать. |
| `MajorFormattingLoss` | Презентация может потерять важное форматирование. | Прервать в режиме строгой валидации; иначе фиксировать и продолжать. |
| `MinorFormattingLoss` | Может возникнуть ограниченное различие в форматировании. | Фиксировать для диагностики и продолжать. |
| `CompatibilityIssue` | Результат может не открываться или работать корректно в некоторых приложениях или старых версиях. | Записать в журнал и продолжать, если совместимость не обязательна. |
| `UnexpectedContent` | Исходный файл содержит неподдерживаемое или нераспознанное содержимое, эффект которого пока неизвестен. | Фиксировать и продолжать, или рассматривать как ошибку в строгой политике. |

Категория должна определять решение политики. Сохраняйте `Description` для диагностики, но не полагайтесь на её формулировку в логике приложения, так как текст сообщения может различаться между сценариями предупреждений и версиями продукта.

## **Сбор и классификация предупреждений**

Следующий пример использует один отчёт уровня приложения для всей цепочки обработки. Отдельный экземпляр обратного вызова помечает предупреждения, полученные при загрузке, рендеринге, конвертации в PDF и сохранении PPTX. Политика прерывает работу при повреждении источника или потере данных, при желании может прерывать при значительной потере форматирования и продолжать при остальных предупреждениях.

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;

internal static class PresentationWarningExample
{
    public static void Main()
    {
        var report = new WarningReport();
        var policy = new WarningPolicy(abortOnMajorFormattingLoss: true);
        var completed = ProcessPresentation("input.pptx", report, policy);

        Console.WriteLine(completed ? "Processing completed." : "Processing stopped.");

        foreach (var entry in report.Entries)
        {
            Console.WriteLine($"[{entry.Stage}] {entry.Type}: {entry.Description}");
        }
    }

    private static bool ProcessPresentation(string inputPath, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var loadOptions = new LoadOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Loading, report, policy)
            };

            using var presentation = new Presentation(inputPath, loadOptions);

            if (!RenderFirstSlide(presentation, report, policy))
            {
                return false;
            }

            if (!ConvertToPdf(presentation, report, policy))
            {
                return false;
            }

            return SaveValidatedCopy(presentation, report, policy);
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Loading stopped: {exception.Message}");
            return false;
        }
    }

    private static bool RenderFirstSlide(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new RenderingOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Rendering, report, policy)
            };

            using var image = presentation.Slides[0].GetImage(options);
            image.Save("slide-1.png", ImageFormat.Png);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Rendering stopped: {exception.Message}");
            return false;
        }
    }

    private static bool ConvertToPdf(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new PdfOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Conversion, report, policy)
            };

            presentation.Save("converted.pdf", SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Conversion stopped: {exception.Message}");
            return false;
        }
    }

    private static bool SaveValidatedCopy(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new PptxOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Saving, report, policy)
            };

            presentation.Save("validated-output.pptx", SaveFormat.Pptx, options);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Saving stopped: {exception.Message}");
            return false;
        }
    }

    private enum OperationStage
    {
        Loading,
        Rendering,
        Conversion,
        Saving
    }

    private sealed class WarningEntry
    {
        public WarningEntry(OperationStage stage, WarningType type, string description)
        {
            Stage = stage;
            Type = type;
            Description = description;
        }

        public OperationStage Stage { get; }

        public WarningType Type { get; }

        public string Description { get; }
    }

    private sealed class WarningReport
    {
        private readonly List<WarningEntry> _entries = new List<WarningEntry>();

        public IReadOnlyList<WarningEntry> Entries => _entries;

        public void Add(OperationStage stage, IWarningInfo warning)
        {
            _entries.Add(new WarningEntry(stage, warning.WarningType, warning.Description));
        }
    }

    private sealed class WarningPolicy
    {
        private readonly bool _abortOnMajorFormattingLoss;

        public WarningPolicy(bool abortOnMajorFormattingLoss)
        {
            _abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
        }

        public ReturnAction GetAction(WarningType warningType)
        {
            if (warningType == WarningType.SourceFileCorruption || warningType == WarningType.DataLoss)
            {
                return ReturnAction.Abort;
            }

            if (warningType == WarningType.MajorFormattingLoss && _abortOnMajorFormattingLoss)
            {
                return ReturnAction.Abort;
            }

            return ReturnAction.Continue;
        }
    }

    private sealed class ReportingWarningCallback : IWarningCallback
    {
        private readonly OperationStage _stage;
        private readonly WarningReport _report;
        private readonly WarningPolicy _policy;

        public ReportingWarningCallback(OperationStage stage, WarningReport report, WarningPolicy policy)
        {
            _stage = stage;
            _report = report;
            _policy = policy;
        }

        public ReturnAction Warning(IWarningInfo warning)
        {
            _report.Add(_stage, warning);
            return _policy.GetAction(warning.WarningType);
        }
    }
}
```

Установите `abortOnMajorFormattingLoss` в `false`, когда значительные различия в форматировании приемлемы. Проблемы совместимости, мелкая потеря форматирования и неожиданное содержимое по‑прежнему сохраняются в отчёте, даже если операция продолжается. Расширьте `WarningPolicy.GetAction`, если приложение должно отклонять любую из этих категорий.

## **Распространённые сценарии предупреждений**

Предупреждения могут появляться на разных этапах рабочего процесса:

- **Цифровые подписи:** Подписанная презентация может вызвать предупреждение при загрузке о том, что её подпись будет потеряна во время обработки. Aspose.Slides сообщает об этом условии `DataLoss` через [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/ru/net/aspose.slides.warnings/ipresentationsignedwarninginfo/). Обратный вызов на этапе загрузки позволяет приложению отклонить файл или явно принять сообщённую потерю.
- **Замена шрифтов:** Недоступный шрифт может быть заменён во время рендеринга или экспорта слайда. Предупреждения о замене шрифтов сообщаются как `DataLoss`, поэтому строгая политика выше прерывает работу, даже если приложение считает конкретную замену визуально приемлемой. Чтобы увидеть это поведение, используйте презентацию, содержащую текст шрифтом, недоступным в среде выполнения. Описание предупреждения указывает замену; настройте необходимые шрифты или [правила замены шрифтов](/slides/ru/net/font-substitution/) перед повторной попыткой.
- **Неподдерживаемое или неожиданное содержимое:** Загрузчик может встретить записи презентации или функции, которые он не распознаёт. Такие предупреждения могут использовать `UnexpectedContent` или более строгую категорию, если известны потери данных или форматирования.
- **Совместимость формата:** Сохранение в другой формат презентации может опустить функции или привести к результату, который ведёт себя иначе в некоторых приложениях. Например, сохранение презентации с более чем восемью горизонтальными или восемью вертикальными направляющими в устаревший PPT сообщает о `CompatibilityIssue`. Обратный вызов на этапе сохранения может зафиксировать потерю и продолжить, либо отклонить её, если необходимо сохранять все направляющие.
- **Поведение загрузки:** Параметры загрузки и устаревшее поведение также могут генерировать предупреждения. Например, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/ru/net/aspose.slides.warnings/iobsoletepreslockingbehaviorwarninginfo/) идентифицирует использование устаревшего механизма блокировки презентации как `CompatibilityIssue`.

Предупреждения зависят от исходного документа, целевого формата, операции и версии Aspose.Slides. Не следует считать, что каждый файл генерирует предупреждение или что сценарий всегда относится к единственной категории.

## **Безопасная обработка прерванных операций**

Когда обратный вызов возвращает `ReturnAction.Abort`, не используйте объект, который не удалось загрузить, и не предполагаете, что результат рендеринга или сохранения завершён. Операция может завершиться после создания файла вывода, но до его полного заполнения.

Сохраняйте проверенные результаты в отдельный путь, например `validated-output.pptx`. Заменяйте существующую презентацию только после успешного завершения операции, когда отчёт о предупреждениях удовлетворяет политике приложения, и вывод можно открыть и проверить. Это предотвращает перезапись корректного исходного файла частичным или отклонённым результатом.

Пустой отчёт о предупреждениях не гарантирует, что каждая исходная функция сохранена. Выполните любые дополнительные проверки содержимого и визуальные проверки, требуемые приложением. См. также [Open Presentations](/slides/ru/net/open-presentation/) и [Save Presentations](/slides/ru/net/save-presentation/).

## **FAQ**

**Можно ли обработать всеми ошибками Aspose.Slides через обратный вызов предупреждения?**

Нет. Он обрабатывает только восстанавливаемые условия, сообщаемые как предупреждения. Исключения, происходящие независимо от обратного вызова, должны обрабатываться приложением вокруг вызовов загрузки, рендеринга, конвертации или сохранения.

**Гарантирует ли возврат `ReturnAction.Continue` идентичный вывод?**

Нет. Он лишь позволяет продолжить обработку. Сообщённое условие всё равно может вызвать различия в данных, форматировании или совместимости, поэтому необходимо просмотреть типы и описания собранных предупреждений.

**Как приложению определить операцию, породившую предупреждение?**

Создайте отдельный экземпляр обратного вызова для каждой операции и сохраняйте определяемую приложением стадию вместе с `WarningType` и `Description`, как показано в примере.