---
title: Обработка предупреждений презентации на Android
type: docs
weight: 90
url: /ru/androidjava/presentation-warnings/
aliases:
- /androidjava/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
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
- Android
- Java
- Aspose.Slides
description: "Узнайте, как собирать, классифицировать и обрабатывать предупреждения при загрузке, рендеринге, конвертации и сохранении презентаций с помощью Aspose.Slides для Android на Java."
---
## **Обзор**

Aspose.Slides может сообщать о восстанавливаемых проблемах во время загрузки, рендеринга, конвертации или сохранения презентации. Примеры включают повреждённые исходные записи, содержимое, которое невозможно сохранить, замену шрифтов и ограничения целевого формата. Обратный вызов предупреждения позволяет приложению зафиксировать эти условия и решить, может ли текущая операция продолжиться.

Реализуйте интерфейс [IWarningCallback](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iwarningcallback/) и изучите значения, возвращаемые через [IWarningInfo](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iwarninginfo/): [getWarningType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iwarninginfo/#getWarningType--) и [getDescription](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iwarninginfo/#getDescription--). Верните [ReturnAction.Continue](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/returnaction/#Continue), чтобы принять предупреждение, или [ReturnAction.Abort](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/returnaction/#Abort), чтобы остановить операцию.

Используйте [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/loadoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) для предупреждений, возникших при открытии презентации. Классы параметров рендеринга и экспорта наследуют [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-), который получает предупреждения при рендеринге слайдов, конвертации и сохранении. Поскольку само предупреждение не указывает, какая операция была выполнена, привяжите каждый экземпляр обратного вызова к этапу операции при формировании объединённого отчёта.

## **Предупреждения и исключения**

Предупреждение описывает условие, из которого Aspose.Slides может восстановиться, если обратный вызов вернёт `ReturnAction.Continue`. Исключение означает, что запрошенная операция не может завершиться нормально; исключения не преобразуются в предупреждения и не могут быть обработаны политикой предупреждений.

Возврат `ReturnAction.Abort` просит диспетчер предупреждений завершить текущую операцию, вызвав исключение. Публичное исключение зависит от операции и формата презентации. Например, при загрузке может возникнуть [PptxReadException](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/pptxreadexception/) или [PptReadException](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/pptreadexception/), а при сохранении или экспорте — [PptxException](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/pptxexception/). Обрабатывайте исключение на границе операции и используйте отчёт о предупреждениях, чтобы определить, была ли причина завершения вызвана политикой приложения, а не одним типом исключения или сообщением. Обратный вызов фиксирует предупреждение перед возвратом `ReturnAction.Abort`, обеспечивая доступность причины для приложения.

## **Категории предупреждений**

Класс [WarningType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/warningtype/) предоставляет целочисленные константы для следующих категорий:

| Тип предупреждения | Значение | Типичная политика |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/warningtype/#SourceFileCorruption) | Исходная презентация содержит повреждения, которые могут сделать документ, сохранённый в исходном формате, непригодным. | Прервать. |
| [DataLoss](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/warningtype/#DataLoss) | После загрузки или сохранения могут отсутствовать текст, диаграммы, изображения или другие данные. | Прервать. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/warningtype/#MajorFormattingLoss) | Презентация может потерять важное форматирование. | Прервать в режиме строгой валидации; иначе фиксировать и продолжать. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/warningtype/#MinorFormattingLoss) | Может возникнуть ограниченное различие в форматировании. | Фиксировать для диагностики и продолжать. |
| [CompatibilityIssue](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/warningtype/#CompatibilityIssue) | Результат может не открываться или работать некорректно в некоторых приложениях или более старых версиях. | Записывать в журнал и продолжать, если совместимость не обязательна. |
| [UnexpectedContent](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/warningtype/#UnexpectedContent) | Исходный файл содержит неподдерживаемое или нераспознанное содержимое, влияние которого может быть неизвестно. | Фиксировать и продолжать, либо рассматривать как ошибку при строгой политике. |

Категория должна определять решение политики. Сохраняйте значение, возвращаемое [getDescription](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iwarninginfo/#getDescription--), для диагностики, но не полагайтесь на формулировку сообщения в логике приложения, так как текст может различаться между сценариями предупреждений и версиями продукта.

## **Сбор и классификация предупреждений**

В следующем примере используется один отчёт уровня приложения для всей конвейерной обработки. Отдельный экземпляр обратного вызова маркирует предупреждения от загрузки, рендеринга, конвертации в PDF и сохранения в PPTX. Политика прерывает работу при повреждении исходного файла или потере данных, опционально прерывает при серьёзной потере форматирования и продолжает при остальных предупреждениях.

Поместите `input.pptx` в доступный для записи каталог приложения и передайте этот каталог в `PresentationWarningExample.run`. Пример сохраняет результаты в том же каталоге. Запускайте обработку презентации в фоне, чтобы пользовательский интерфейс Android оставался отзывчивым.

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
import java.io.File;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class PresentationWarningExample {
    public static void run(File dataDirectory) {
        WarningReport report = new WarningReport();
        WarningPolicy policy = new WarningPolicy(true);
        File inputFile = new File(dataDirectory, "input.pptx");
        boolean completed = processPresentation(inputFile.getAbsolutePath(), dataDirectory, report, policy);

        System.out.println(completed ? "Processing completed." : "Processing stopped.");

        for (WarningEntry entry : report.getEntries()) {
            String typeName = warningTypeName(entry.type);
            System.out.println("[" + entry.stage + "] " + typeName + ": " + entry.description);
        }
    }

    private static boolean processPresentation(String inputPath, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            LoadOptions loadOptions = new LoadOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Loading, report, policy);
            loadOptions.setWarningCallback(callback);

            Presentation presentation = new Presentation(inputPath, loadOptions);
            try {
                if (!renderFirstSlide(presentation, dataDirectory, report, policy)) {
                    return false;
                }

                if (!convertToPdf(presentation, dataDirectory, report, policy)) {
                    return false;
                }

                return saveValidatedCopy(presentation, dataDirectory, report, policy);
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

    private static boolean renderFirstSlide(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
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
                File outputFile = new File(dataDirectory, "slide-1.png");
                image.save(outputFile.getAbsolutePath(), ImageFormat.Png);
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

    private static boolean convertToPdf(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            PdfOptions options = new PdfOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Conversion, report, policy);
            options.setWarningCallback(callback);

            File outputFile = new File(dataDirectory, "converted.pdf");
            presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Conversion stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean saveValidatedCopy(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            PptxOptions options = new PptxOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Saving, report, policy);
            options.setWarningCallback(callback);

            File outputFile = new File(dataDirectory, "validated-output.pptx");
            presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx, options);
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

Передавайте `false` параметру `abortOnMajorFormattingLoss` при создании `WarningPolicy`, если крупные различия в форматировании допускаются. Проблемы совместимости, небольшая потеря форматирования и неожиданное содержимое всё равно сохраняются в отчёте, даже когда операция продолжается. При необходимости расширьте `WarningPolicy.getAction`, если приложение должно отклонять любые из этих категорий.

## **Распространённые сценарии предупреждений**

Предупреждения могут появляться на разных этапах рабочего процесса:

- **Цифровые подписи:** При загрузке подписанной презентации может возникнуть предупреждение, что подпись будет утеряна во время обработки. Aspose.Slides сообщает об этом как о `DataLoss` через [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentationsignedwarninginfo/). Обратный вызов на этапе загрузки позволяет приложению отклонить файл или явно принять сообщённую потерю.
- **Замена шрифтов:** Недоступный шрифт может быть заменён во время рендеринга слайда или экспорта. Предупреждения о замене шрифтов сообщаются как `DataLoss`, поэтому строгая политика выше прерывает процесс, даже если замена визуально приемлема. Чтобы наблюдать такое поведение, используйте презентацию с текстом в шрифте, отсутствующем в среде выполнения. Описание предупреждения указывает замену; настройте нужные шрифты или [правила замены шрифтов](/slides/ru/androidjava/font-substitution/) перед повторной попыткой.
- **Неподдерживаемое или неожиданное содержимое:** Загрузчик может встретить записи презентации или функции, которые он не распознаёт. Такие предупреждения могут использовать `UnexpectedContent` или более серьёзную категорию, если известны потери данных или форматирования.
- **Совместимость формата:** Сохранение в другой формат презентации может опустить функции или дать результат, который работает иначе в некоторых приложениях. Например, сохранение презентации с более чем восемью горизонтальными или вертикальными направляющими в устаревший PPT сообщает `CompatibilityIssue`. Обратный вызов на этапе сохранения может зафиксировать потерю и продолжить, либо отклонить её, если требуется сохранить все направляющие.
- **Поведение загрузки:** Параметры загрузки и устаревшее поведение могут также генерировать предупреждения. Например, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) идентифицирует использование устаревшего механизма блокировки презентации как `CompatibilityIssue`.

Предупреждения зависят от исходного документа, целевого формата, операции и версии Aspose.Slides. Не следует считать, что каждый файл генерирует предупреждение или что сценарий всегда относится к одной категории.

## **Безопасная обработка прерванных операций**

Когда обратный вызов возвращает `ReturnAction.Abort`, не используйте объект, который не был загружен, и не предполагаете, что вывод рендеринга или сохранения завершён. Операция может завершиться после создания выходного файла, но до его полного завершения.

Сохраняйте проверенные результаты в отдельный путь, например `validated-output.pptx`. Заменяйте существующую презентацию только после успешного завершения операции, когда отчёт о предупреждениях удовлетворяет политике приложения и файл можно открыть и проверить. Это предотвращает перезапись корректного исходного файла частичным или отклонённым результатом.

Пустой отчёт о предупреждениях не гарантирует сохранение всех функций исходного файла. Выполняйте любые дополнительные проверки содержимого и визуального соответствия, требуемые приложением. См. также [Open Presentations](/slides/ru/androidjava/open-presentation/) и [Save Presentations](/slides/ru/androidjava/save-presentation/).

## **FAQ**

**Можно ли обработать каждую ошибку Aspose.Slides с помощью обратного вызова предупреждения?**

Нет. Он обрабатывает только восстанавливаемые условия, сообщаемые как предупреждения. Исключения, возникающие независимо от обратного вызова, должны обрабатываться приложением вокруг вызова загрузки, рендеринга, конвертации или сохранения.

**Гарантирует ли возврат `ReturnAction.Continue` идентичный вывод?**

Нет. Он лишь позволяет продолжить обработку. Сообщённое условие всё равно может привести к различиям в данных, форматировании или совместимости, поэтому необходимо просмотреть собранные типы и описания предупреждений.

**Как приложению определить, какая операция вызвала предупреждение?**

Создайте отдельный экземпляр обратного вызова для каждой операции и храните определённый приложением этап вместе со значениями, возвращаемыми [getWarningType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iwarninginfo/#getWarningType--) и [getDescription](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iwarninginfo/#getDescription--), как показано в примере.