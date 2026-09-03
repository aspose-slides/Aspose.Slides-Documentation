---
title: Обработка предупреждений презентации в PHP
type: docs
weight: 90
url: /ru/php-java/presentation-warnings/
aliases:
- /php-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
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
- преобразование презентации
- сохранение презентации
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "Узнайте, как собирать, классифицировать и реагировать на предупреждения при загрузке, рендеринге, конвертации и сохранении презентаций с помощью Aspose.Slides для PHP через Java."
---
## **Обзор**

Aspose.Slides может сообщать о восстанавливаемых проблемах во время загрузки, рендеринга, преобразования или сохранения презентации. Примерами являются повреждённые исходные записи, содержимое, которое невозможно сохранить, замена шрифтов и ограничения целевого формата. Callback предупреждений позволяет приложению фиксировать эти условия и решать, может ли текущая операция продолжиться.

Создайте класс PHP с публичным методом `warning` и откройте его через PHP Java Bridge как Java‑интерфейс [IWarningCallback](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iwarningcallback/) с использованием `java_closure`. Изучите значения, поставляемые через [IWarningInfo](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iwarninginfo/), используя [getWarningType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iwarninginfo/#getWarningType--) и [getDescription](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iwarninginfo/#getDescription--). Верните [ReturnAction::Continue](https://reference.aspose.com/slides/ru/php-java/aspose.slides/returnaction/#Continue), чтобы принять предупреждение, или [ReturnAction::Abort](https://reference.aspose.com/slides/ru/php-java/aspose.slides/returnaction/#Abort), чтобы остановить операцию.

Используйте [LoadOptions::setWarningCallback](https://reference.aspose.com/slides/ru/php-java/aspose.slides/loadoptions/#setWarningCallback) для предупреждений, возникающих при открытии презентации. Классы параметров рендеринга и экспорта наследуют [SaveOptions::setWarningCallback](https://reference.aspose.com/slides/ru/php-java/aspose.slides/saveoptions/#setWarningCallback), получающие предупреждения от рендеринга слайдов, преобразования и сохранения. Поскольку само предупреждение не идентифицирует операцию приложения, привязывайте каждый экземпляр callback к этапу операции при построении объединённого отчёта.

## **Предупреждения и исключения**

Исключения Java доступны в PHP через PHP Java Bridge; перехватывайте их на границе операции, как показано в примере ниже. Ссылки на Java‑интерфейсы в этой статье описывают контракт callback, используемый мостом.

Предупреждение описывает состояние, из которого Aspose.Slides может восстановиться, если callback возвращает `ReturnAction::Continue`. Исключение означает, что запрошенная операция не может завершиться нормально; исключения не преобразуются в предупреждения и не могут обрабатываться политикой предупреждений.

Возврат `ReturnAction::Abort` просит диспетчер предупреждений завершить текущую операцию, вызвав исключение. Публичное исключение зависит от операции и формата презентации. Например, при загрузке может возникнуть [PptxReadException](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pptxreadexception/) или [PptReadException](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pptreadexception/), а при сохранении или экспорте — [PptxException](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pptxexception/). Обрабатывайте исключение на границе операции и используйте отчёт о предупреждениях, чтобы определить, вызвано ли завершение политикой приложения, вместо того чтобы полагаться на один тип исключения или сообщение. Callback фиксирует предупреждение перед возвратом `ReturnAction::Abort`, гарантируя, что причина остаётся доступной приложению.

## **Категории предупреждений**

Класс [WarningType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/warningtype/) предоставляет целочисленные константы для следующих категорий:

| Тип предупреждения | Смысл | Типичная политика |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/ru/php-java/aspose.slides/warningtype/#SourceFileCorruption) | Исходная презентация содержит повреждения, которые могут сделать документ, сохранённый в оригинальном формате, непригодным. | Прервать. |
| [DataLoss](https://reference.aspose.com/slides/ru/php-java/aspose.slides/warningtype/#DataLoss) | Текст, диаграммы, изображения или другие данные могут отсутствовать после загрузки или сохранения. | Прервать. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/ru/php-java/aspose.slides/warningtype/#MajorFormattingLoss) | Презентация может потерять важное форматирование. | Прервать в режиме строгой валидации; иначе фиксировать и продолжать. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/ru/php-java/aspose.slides/warningtype/#MinorFormattingLoss) | Может возникнуть ограниченное различие в форматировании. | Фиксировать для диагностики и продолжать. |
| [CompatibilityIssue](https://reference.aspose.com/slides/ru/php-java/aspose.slides/warningtype/#CompatibilityIssue) | Результат может не открываться или работать корректно в некоторых приложениях или старых версиях. | Записывать в журнал и продолжать, если совместимость не является обязательной. |
| [UnexpectedContent](https://reference.aspose.com/slides/ru/php-java/aspose.slides/warningtype/#UnexpectedContent) | Исходный файл содержит неподдерживаемый или неизвестный контент, влияние которого может быть неизвестно. | Фиксировать и продолжать, либо рассматривать как ошибку при строгой политике. |

Категория должна определять решение политики. Сохраняйте значение, возвращаемое [getDescription](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iwarninginfo/#getDescription--), для диагностики, но не полагайтесь на его формулировку в логике приложения, так как текст сообщения может различаться между сценариями предупреждений и версиями продукта.

## **Сбор и классификация предупреждений**

Следующий пример использует единственный отчёт уровня приложения для всего конвейера обработки. Отдельный экземпляр callback помечает предупреждения от загрузки, рендеринга, конвертации в PDF и сохранения PPTX. Политика прерывает процесс при повреждении исходных данных или их потере, опционально прерывает при серьёзной потере форматирования и продолжает для остальных предупреждений. Callback преобразует значения предупреждений в нативные PHP‑значения с помощью `java_values` перед их фиксацией и сравнением.

```php
use aspose\slides\ImageFormat;
use aspose\slides\LoadOptions;
use aspose\slides\PdfOptions;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;
use aspose\slides\ReturnAction;
use aspose\slides\SaveFormat;
use aspose\slides\WarningType;

class WarningReport {
    private $entries = [];

    public function getEntries() {
        return $this->entries;
    }

    public function add($stage, $type, $description) {
        $this->entries[] = [
            "stage" => $stage,
            "type" => $type,
            "description" => $description
        ];
    }
}

class WarningPolicy {
    private $abortOnMajorFormattingLoss;

    public function __construct($abortOnMajorFormattingLoss) {
        $this->abortOnMajorFormattingLoss = $abortOnMajorFormattingLoss;
    }

    public function getAction($warningType) {
        if ($warningType === WarningType::SourceFileCorruption || $warningType === WarningType::DataLoss) {
            return ReturnAction::Abort;
        }

        if ($warningType === WarningType::MajorFormattingLoss && $this->abortOnMajorFormattingLoss) {
            return ReturnAction::Abort;
        }

        return ReturnAction::Continue;
    }
}

class ReportingWarningCallback {
    private $stage;
    private $report;
    private $policy;

    public function __construct($stage, WarningReport $report, WarningPolicy $policy) {
        $this->stage = $stage;
        $this->report = $report;
        $this->policy = $policy;
    }

    public function warning($warning) {
        $type = (int) java_values($warning->getWarningType());
        $description = (string) java_values($warning->getDescription());
        $this->report->add($this->stage, $type, $description);
        return $this->policy->getAction($type);
    }
}

function createWarningCallback($stage, WarningReport $report, WarningPolicy $policy) {
    $handler = new ReportingWarningCallback($stage, $report, $policy);
    $warningInterface = java("com.aspose.slides.IWarningCallback");
    return java_closure($handler, null, $warningInterface);
}

function processPresentation($inputPath, WarningReport $report, WarningPolicy $policy) {
    try {
        $loadOptions = new LoadOptions();
        $callback = createWarningCallback("Loading", $report, $policy);
        $loadOptions->setWarningCallback($callback);

        $presentation = new Presentation($inputPath, $loadOptions);
        try {
            if (!renderFirstSlide($presentation, $report, $policy)) {
                return false;
            }

            if (!convertToPdf($presentation, $report, $policy)) {
                return false;
            }

            return saveValidatedCopy($presentation, $report, $policy);
        } finally {
            $presentation->dispose();
        }
    } catch (Throwable $exception) {
        echo "Loading stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function renderFirstSlide($presentation, WarningReport $report, WarningPolicy $policy) {
    if ((int) java_values($presentation->getSlides()->size()) === 0) {
        echo "Rendering stopped: the presentation has no slides." . PHP_EOL;
        return false;
    }

    try {
        $options = new RenderingOptions();
        $callback = createWarningCallback("Rendering", $report, $policy);
        $options->setWarningCallback($callback);

        $image = $presentation->getSlides()->get_Item(0)->getImage($options);
        try {
            $image->save("slide-1.png", ImageFormat::Png);
            return true;
        } finally {
            $image->dispose();
        }
    } catch (Throwable $exception) {
        echo "Rendering stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function convertToPdf($presentation, WarningReport $report, WarningPolicy $policy) {
    try {
        $options = new PdfOptions();
        $callback = createWarningCallback("Conversion", $report, $policy);
        $options->setWarningCallback($callback);

        $presentation->save("converted.pdf", SaveFormat::Pdf, $options);
        return true;
    } catch (Throwable $exception) {
        echo "Conversion stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function saveValidatedCopy($presentation, WarningReport $report, WarningPolicy $policy) {
    try {
        $options = new PptxOptions();
        $callback = createWarningCallback("Saving", $report, $policy);
        $options->setWarningCallback($callback);

        $presentation->save("validated-output.pptx", SaveFormat::Pptx, $options);
        return true;
    } catch (Throwable $exception) {
        echo "Saving stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function warningTypeName($warningType) {
    switch ($warningType) {
        case WarningType::SourceFileCorruption:
            return "SourceFileCorruption";
        case WarningType::DataLoss:
            return "DataLoss";
        case WarningType::MajorFormattingLoss:
            return "MajorFormattingLoss";
        case WarningType::MinorFormattingLoss:
            return "MinorFormattingLoss";
        case WarningType::CompatibilityIssue:
            return "CompatibilityIssue";
        case WarningType::UnexpectedContent:
            return "UnexpectedContent";
        default:
            return "Unknown (" . $warningType . ")";
    }
}

$report = new WarningReport();
$policy = new WarningPolicy(true);
$completed = processPresentation("input.pptx", $report, $policy);

echo ($completed ? "Processing completed." : "Processing stopped.") . PHP_EOL;

foreach ($report->getEntries() as $entry) {
    $typeName = warningTypeName($entry["type"]);
    echo "[" . $entry["stage"] . "] " . $typeName . ": " . $entry["description"] . PHP_EOL;
}
```

Передайте `false` параметру `abortOnMajorFormattingLoss` при создании `WarningPolicy`, если серьёзные различия в форматировании приемлемы. Проблемы совместимости, небольшая потеря форматирования и неожиданный контент всё равно сохраняются в отчёте, даже если операция продолжается. Расширьте `WarningPolicy::getAction`, если приложение должно отклонять любую из этих категорий.

## **Распространённые сценарии предупреждений**

Предупреждения могут возникать на разных этапах рабочего процесса:

- **Электронные подписи:** Подписанная презентация может вызвать предупреждение при загрузке о том, что её подпись будет утрачена в процессе. Aspose.Slides сообщает об этом состоянии `DataLoss` через [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipresentationsignedwarninginfo/). Callback на этапе загрузки позволяет приложению отклонить файл или явно принять сообщённую потерю.
- **Замена шрифтов:** Недоступный шрифт может быть заменён во время рендеринга или экспорта слайда. Предупреждения о замене шрифтов сообщаются как `DataLoss`, поэтому строгая политика выше прерывает процесс, даже если приложение считает конкретную замену визуально приемлемой. Чтобы увидеть это поведение, используйте входную презентацию, содержащую текст шрифтом, недоступным в среде выполнения. Описание предупреждения указывает замену; настройте необходимые шрифты или [правила замены шрифтов](/slides/ru/php-java/font-substitution/) перед повторной попыткой.
- **Неподдерживаемый или неожиданный контент:** Загрузчик может столкнуться с записями презентации или функциями, которые он не распознаёт. Такие предупреждения могут использовать `UnexpectedContent` или более серьёзную категорию, если известны потери данных или форматирования.
- **Совместимость форматов:** Сохранение в другой формат презентации может исключать функции или создавать результат, который работает иначе в некоторых приложениях. Например, сохранение презентации с более чем восемью горизонтальными или вертикальными направляющими в устаревший PPT вызывает `CompatibilityIssue`. Callback на этапе сохранения может зафиксировать потерю и продолжить, либо отклонить её, если требуется сохранение всех направляющих.
- **Поведение при загрузке:** Параметры загрузки и устаревшее поведение также могут вызывать предупреждения. Например, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) определяет использование устаревшего механизма блокировки презентации как `CompatibilityIssue`.

Предупреждения зависят от исходного документа, целевого формата, операции и версии Aspose.Slides. Не следует полагать, что каждый файл генерирует предупреждение или что сценарий всегда относится к одной категории.

## **Безопасная обработка прерванных операций**

Когда callback возвращает `ReturnAction::Abort`, не используйте объект, который не загрузился, и не предполагайте, что вывод рендеринга или сохранения завершён. Операция может завершиться после создания выходного файла, но до его окончания.

Сохраните проверенные результаты в отдельный путь, например `validated-output.pptx`. Заменяйте существующую презентацию только после успешного завершения операции, когда отчёт о предупреждениях соответствует политике приложения, и выходной файл можно открыть и проверить. Это предотвращает перезапись корректного исходного файла частичным или отклонённым результатом.

Пустой отчёт о предупреждениях не гарантирует, что все исходные функции сохранены. Выполняйте любые дополнительные проверки содержимого и визуального соответствия, требуемые приложением. См. также [Open Presentations](/slides/ru/php-java/open-presentation/) и [Save Presentations](/slides/ru/php-java/save-presentation/).

## **ЧаВо**

**Может ли callback предупреждений обрабатывать каждую ошибку Aspose.Slides?**

Нет. Он обрабатывает восстанавливаемые условия, сообщаемые как предупреждения. Исключения, возникающие независимо от callback, должны обрабатываться приложением вокруг вызовов загрузки, рендеринга, преобразования или сохранения.

**Гарантирует ли возврат `ReturnAction::Continue` идентичный вывод?**

Нет. Он лишь разрешает продолжить обработку. Сообщённое состояние всё равно может вызвать различия в данных, форматировании или совместимости, поэтому необходимо просмотреть собранные типы и описания предупреждений.

**Как приложению определить операцию, создавшую предупреждение?**

Создайте экземпляр callback для каждой операции и сохраняйте определённый приложением этап вместе со значениями, возвращаемыми [getWarningType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iwarninginfo/#getWarningType--) и [getDescription](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iwarninginfo/#getDescription--), как показано в примере.