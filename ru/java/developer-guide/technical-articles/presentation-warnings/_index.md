---
title: Обработка предупреждений презентаций в Java
type: docs
weight: 90
url: /ru/java/presentation-warnings/
aliases:
- /java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
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
- Java
- Aspose.Slides
description: "Узнайте, как собирать, классифицировать и обрабатывать предупреждения при загрузке, рендеринге, конвертации и сохранении презентаций с помощью Aspose.Slides для Java."
---
## **Обзор**

Aspose.Slides может сообщать о восстанавливаемых проблемах во время загрузки, рендеринга, конвертации или сохранения презентации. Примеры включают повреждённые исходные записи, контент, который невозможно сохранить, замену шрифтов и ограничения целевого формата. Обратный вызов предупреждения позволяет приложению фиксировать эти условия и решать, может ли текущая операция продолжиться.

Реализуйте интерфейс [IWarningCallback](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iwarningcallback/) и проверяйте значения, возвращаемые через [IWarningInfo](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iwarninginfo/), используя методы [getWarningType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iwarninginfo/#getWarningType--) и [getDescription](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iwarninginfo/#getDescription--). Верните [ReturnAction.Continue](https://reference.aspose.com/slides/ru/java/com.aspose.slides/returnaction/#Continue), чтобы принять предупреждение, или [ReturnAction.Abort](https://reference.aspose.com/slides/ru/java/com.aspose.slides/returnaction/#Abort), чтобы прервать операцию.

Используйте [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/ru/java/com.aspose.slides/loadoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) для предупреждений, возникающих при открытии презентации. Классы параметров рендеринга и экспорта наследуют [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/ru/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-), который получает предупреждения от рендеринга слайдов, конвертации и сохранения. Поскольку само предупреждение не указывает операцию приложения, связывайте каждый экземпляр обратного вызова с этапом операции при построении объединённого отчёта.

## **Предупреждения и исключения**

Предупреждение описывает условие, из которого Aspose.Slides может восстановиться, если обратный вызов вернёт `ReturnAction.Continue`. Исключение означает, что запрошенная операция не может завершиться нормально; исключения не преобразуются в предупреждения и не могут быть обработаны политикой предупреждений.

Возврат `ReturnAction.Abort` просит диспетчер предупреждений завершить текущую операцию, вызвав исключение. Публичное исключение зависит от операции и формата презентации. Например, при загрузке может возникнуть [PptxReadException](https://reference.aspose.com/slides/ru/java/com.aspose.slides/pptxreadexception/) или [PptReadException](https://reference.aspose.com/slides/ru/java/com.aspose.slides/pptreadexception/), тогда как при сохранении или экспорте может возникнуть [PptxException](https://reference.aspose.com/slides/ru/java/com.aspose.slides/pptxexception/). Обрабатывайте исключение на границе операции и используйте отчёт о предупреждениях для определения, была ли остановка вызвана политикой приложения, а не только типом исключения или его сообщением. Обратный вызов фиксирует предупреждение перед возвратом `ReturnAction.Abort`, обеспечивая доступность причины для приложения.

## **Категории предупреждений**

Класс [WarningType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/warningtype/) предоставляет целочисленные константы для следующих категорий:

| Тип предупреждения | Значение | Типичная политика |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/ru/java/com.aspose.slides/warningtype/#SourceFileCorruption) | Исходная презентация содержит повреждения, которые могут сделать документ, сохранённый в оригинальном формате, непригодным. | Прервать. |
| [DataLoss](https://reference.aspose.com/slides/ru/java/com.aspose.slides/warningtype/#DataLoss) | Текст, диаграммы, изображения или другие данные могут отсутствовать после загрузки или сохранения. | Прервать. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/ru/java/com.aspose.slides/warningtype/#MajorFormattingLoss) | Презентация может потерять важное форматирование. | Прервать в режиме строгой валидации; иначе фиксировать и продолжать. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/ru/java/com.aspose.slides/warningtype/#MinorFormattingLoss) | Может возникнуть ограниченное различие в форматировании. | Фиксировать для диагностики и продолжать. |
| [CompatibilityIssue](https://reference.aspose.com/slides/ru/java/com.aspose.slides/warningtype/#CompatibilityIssue) | Результат может не открываться или работать некорректно в некоторых приложениях или старых версиях. | Записывать в лог и продолжать, если совместимость не обязательна. |
| [UnexpectedContent](https://reference.aspose.com/slides/ru/java/com.aspose.slides/warningtype/#UnexpectedContent) | Исходный файл содержит неподдерживаемый или нераспознанный контент, влияние которого пока неизвестно. | Фиксировать и продолжать, либо рассматривать как ошибку в строгой политике. |

Категория должна определять решение политики. Сохраняйте значение, возвращаемое [getDescription](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iwarninginfo/#getDescription--), для диагностики, но не полагайтесь на его формулировку в логике приложения, так как текст сообщения может различаться между сценариями предупреждений и версиями продукта.

## **Сбор и классификация предупреждений**

Следующий пример использует один отчёт уровня приложения для полного конвейера обработки. Отдельный экземпляр обратного вызова помечает предупреждения из фаз загрузки, рендеринга, конвертации в PDF и сохранения PPTX. Политика прерывает работу при обнаружении повреждения источника или потери данных, при желании прерывает при серьёзной потере форматирования и продолжает при остальных предупреждениях.

```java
import com.aspose.slides.IImage;
import com.aspose.slides.IWarningCallback;
import com.aspose.slides.IWarningInfo;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.PdfOptions;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.RenderingOptions;
import com.aspose.slides.ReturnAction;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.WarningType;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

class PresentationWarningExample {
    public static void main(String[] args) {
        WarningReport report = new WarningReport();
        WarningPolicy policy = new WarningPolicy(true);
        boolean completed = processPresentation("input.pptx", report, policy);

        System.out.println(completed ? "Processing completed." : "Processing stopped.");

        for (WarningEntry entry : report.getEntries()) {
            String typeName = warningTypeName(entry.type);
            System.out.println("[" + entry.stage + "] " + typeName + ": " + entry.description);
        }
    }

    private static boolean processPresentation(String inputPath, WarningReport report, WarningPolicy policy) {
        try {
            LoadOptions loadOptions = new LoadOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Loading, report, policy);
            loadOptions.setWarningCallback(callback);

            Presentation presentation = new Presentation(inputPath, loadOptions);
            try {
                if (!renderFirstSlide(presentation, report, policy)) {
                    return false;
                }

                if (!convertToPdf(presentation, report, policy)) {
                    return false;
                }

                return saveValidatedCopy(presentation, report, policy);
            }
            finally {
                presentation.dispose();
            }
        }
        catch (Exception exception) {
            System.err.println("Loading stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean renderFirstSlide(Presentation presentation, WarningReport report, WarningPolicy policy) {
        if (presentation.getSlides().size() == 0) {
            System.err.println("Rendering stopped: the presentation has no slides.");
            return false;
        }

        try {
            RenderingOptions options = new RenderingOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Rendering, report, policy);
            options.setWarningCallback(callback);

            IImage image = presentation.getSlides().get_Item(0).getImage(options);
            try {
                image.save("slide-1.png", ImageFormat.Png);
                return true;
            }
            finally {
                image.dispose();
            }
        }
        catch (Exception exception) {
            System.err.println("Rendering stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean convertToPdf(Presentation presentation, WarningReport report, WarningPolicy policy) {
        try {
            PdfOptions options = new PdfOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Conversion, report, policy);
            options.setWarningCallback(callback);

            presentation.save("converted.pdf", SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Conversion stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean saveValidatedCopy(Presentation presentation, WarningReport report, WarningPolicy policy) {
        try {
            PptxOptions options = new PptxOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Saving, report, policy);
            options.setWarningCallback(callback);

            presentation.save("validated-output.pptx", SaveFormat.Pptx, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Saving stopped: " + exception.getMessage());
            return false;
        }
    }

    private static String warningTypeName(int warningType) {
        switch (warningType) {
            case WarningType.SourceFileCorruption:
                return "SourceFileCorruption";
            case WarningType.DataLoss:
                return "DataLoss";
            case WarningType.MajorFormattingLoss:
                return "MajorFormattingLoss";
            case WarningType.MinorFormattingLoss:
                return "MinorFormattingLoss";
            case WarningType.CompatibilityIssue:
                return "CompatibilityIssue";
            case WarningType.UnexpectedContent:
                return "UnexpectedContent";
            default:
                return "Unknown (" + warningType + ")";
        }
    }

    private enum OperationStage {
        Loading,
        Rendering,
        Conversion,
        Saving
    }

    private static final class WarningEntry {
        final OperationStage stage;
        final int type;
        final String description;

        WarningEntry(OperationStage stage, int type, String description) {
            this.stage = stage;
            this.type = type;
            this.description = description;
        }
    }

    private static final class WarningReport {
        private final List<WarningEntry> entries = new ArrayList<WarningEntry>();

        List<WarningEntry> getEntries() {
            return Collections.unmodifiableList(entries);
        }

        void add(OperationStage stage, IWarningInfo warning) {
            WarningEntry entry = new WarningEntry(stage, warning.getWarningType(), warning.getDescription());
            entries.add(entry);
        }
    }

    private static final class WarningPolicy {
        private final boolean abortOnMajorFormattingLoss;

        WarningPolicy(boolean abortOnMajorFormattingLoss) {
            this.abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
        }

        int getAction(int warningType) {
            if (warningType == WarningType.SourceFileCorruption || warningType == WarningType.DataLoss) {
                return ReturnAction.Abort;
            }

            if (warningType == WarningType.MajorFormattingLoss && abortOnMajorFormattingLoss) {
                return ReturnAction.Abort;
            }

            return ReturnAction.Continue;
        }
    }

    private static final class ReportingWarningCallback implements IWarningCallback {
        private final OperationStage stage;
        private final WarningReport report;
        private final WarningPolicy policy;

        ReportingWarningCallback(OperationStage stage, WarningReport report, WarningPolicy policy) {
            this.stage = stage;
            this.report = report;
            this.policy = policy;
        }

        @Override
        public int warning(IWarningInfo warning) {
            report.add(stage, warning);
            return policy.getAction(warning.getWarningType());
        }
    }
}
```

Передайте `false` для параметра `abortOnMajorFormattingLoss` при создании `WarningPolicy`, если серьёзные различия в форматировании приемлемы. Проблемы совместимости, небольшая потеря форматирования и неожиданный контент всё равно сохраняются в отчёте, даже если операция продолжается. Расширьте `WarningPolicy.getAction`, если приложение должно отклонять любые из этих категорий.

## **Распространённые сценарии предупреждений**

Предупреждения могут возникать на разных этапах рабочего процесса:

- **Цифровые подписи:** Подписанная презентация может вызвать предупреждение при загрузке о том, что её подпись будет потеряна в процессе. Aspose.Slides сообщает об этом условии `DataLoss` через [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipresentationsignedwarninginfo/). Обратный вызов на этапе загрузки позволяет приложению отклонить файл или явно принять сообщённую потерю.
- **Замена шрифтов:** Недоступный шрифт может быть заменён во время рендеринга слайда или экспорта. Предупреждения о замене шрифтов сообщаются как `DataLoss`, поэтому строгая политика выше прерывает работу, даже если приложение сочтет конкретную замену визуально приемлемой. Чтобы увидеть это поведение, используйте входную презентацию с текстом, написанным шрифтом, недоступным в среде выполнения. Описание предупреждения указывает замену; настройте требуемые шрифты или [правила замены шрифтов](/slides/ru/java/font-substitution/) перед повторной попыткой.
- **Неподдерживаемый или неожиданный контент:** Загрузчик может встретить записи презентации или функции, которые он не распознаёт. Такие предупреждения могут использовать `UnexpectedContent` или более тяжёлую категорию, когда известны потери данных или форматирования.
- **Совместимость формата:** Сохранение в другой формат презентации может опустить функции или дать результат, который ведёт себя иначе в некоторых приложениях. Например, сохранение презентации с более чем восемью горизонтальными или восемью вертикальными направляющими черчения в устаревший PPT приводит к `CompatibilityIssue`. Обратный вызов на этапе сохранения может зафиксировать потерю и продолжить, либо отклонить её, если требуется сохранение всех направляющих.
- **Поведение загрузки:** Параметры загрузки и устаревшее поведение также могут генерировать предупреждения. Например, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) определяет использование устаревшего поведения блокировки презентации как `CompatibilityIssue`.

Предупреждения зависят от исходного документа, целевого формата, операции и версии Aspose.Slides. Не следует предполагать, что каждый файл генерирует предупреждение или что сценарий всегда относится к единственной категории.

## **Безопасная обработка прерванных операций**

Когда обратный вызов возвращает `ReturnAction.Abort`, не используйте объект, который не удалось загрузить, и не полагайтесь на то, что вывод рендеринга или сохранения завершён. Операция может завершиться после создания выходного файла, но до его окончательной записи.

Сохраняйте проверенные результаты в отдельный путь, например `validated-output.pptx`. Заменяйте существующую презентацию только после успешного завершения операции, когда отчёт о предупреждениях удовлетворяет политике приложения, и файл может быть открыт и проверен. Это предотвращает перезапись валидного исходного файла частичным или отклонённым результатом.

Пустой отчёт о предупреждениях не гарантирует, что все исходные функции сохранены. Выполняйте любые дополнительные проверки содержимого и визуального отображения, требуемые приложением. См. также [Open Presentations](/slides/ru/java/open-presentation/) и [Save Presentations](/slides/ru/java/save-presentation/).

## **FAQ**

**Можно ли обработать все ошибки Aspose.Slides с помощью обратного вызова предупреждения?**

Нет. Он обрабатывает лишь восстанавливаемые условия, сообщаемые как предупреждения. Исключения, возникающие независимо от обратного вызова, необходимо обрабатывать в приложении вокруг вызова загрузки, рендеринга, конвертации или сохранения.

**Гарантирует ли возврат `ReturnAction.Continue` идентичный вывод?**

Нет. Он лишь разрешает продолжить обработку. Сообщённое условие всё равно может вызвать различия в данных, форматировании или совместимости, поэтому следует просмотреть собранные типы и описания предупреждений.

**Как приложению определить операцию, породившую предупреждение?**

Создайте отдельный экземпляр обратного вызова для каждой операции и сохраняйте определённый приложением этап вместе со значениями, возвращаемыми [getWarningType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iwarninginfo/#getWarningType--) и [getDescription](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iwarninginfo/#getDescription--), как показано в примере.