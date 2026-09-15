---
title: Обработка предупреждений презентаций в Python через Java
type: docs
weight: 90
url: /ru/python-java/presentation-warnings/
aliases:
- /python-java/получение-колбэков-предупреждений-для-замены-шрифтов-в-aspose-slides/
keywords:
- колбэк предупреждений
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
- Python
- Java
- Aspose.Slides
description: "Узнайте, как собирать, классифицировать и обрабатывать предупреждения при загрузке, рендеринге, конвертации и сохранении презентаций с Aspose.Slides для Python через Java."
---
## **Обзор**

Aspose.Slides может сообщать о восстанавливаемых проблемах во время загрузки, рендеринга, конвертации или сохранения презентации. Примеры включают повреждённые исходные записи, контент, который нельзя сохранить, замену шрифтов и ограничения целевого формата. Колбэк предупреждений позволяет приложению записывать эти условия и решать, может ли текущая операция продолжиться.

Реализуйте интерфейс `IWarningCallback` через `jpype.JProxy` и изучите значения `getWarningType` и `getDescription`, предоставляемые через `IWarningInfo`. Верните [ReturnAction.Continue](https://reference.aspose.com/slides/ru/python-java/aspose.slides/returnaction/#Continue) чтобы принять предупреждение или [ReturnAction.Abort](https://reference.aspose.com/slides/ru/python-java/aspose.slides/returnaction/#Abort) чтобы остановить операцию.

Используйте [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/ru/python-java/aspose.slides/loadoptions/#setWarningCallback) для предупреждений, возникающих при открытии презентации. Классы параметров рендеринга и экспорта наследуют [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/ru/python-java/aspose.slides/saveoptions/#setWarningCallback), который получает предупреждения от рендеринга слайдов, конвертации и сохранения. Поскольку само предупреждение не указывает операцию приложения, связывайте каждый экземпляр колбэка с этапом операции при построении объединённого отчёта.

## **Предупреждения и исключения**

Предупреждение описывает условие, от которого Aspose.Slides может восстановиться, если колбэк вернёт `ReturnAction.Continue`. Исключение означает, что запрошенная операция не может завершиться нормально; исключения не преобразуются в предупреждения и не могут обрабатываться политикой предупреждений.

Возврат `ReturnAction.Abort` просит диспетчера предупреждений завершить текущую операцию, вызвав исключение. Публичное исключение зависит от операции и формата презентации. Например, при загрузке может возникнуть [PptxReadException](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pptxreadexception/) или [PptReadException](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pptreadexception/), а при сохранении или экспорте — [PptxException](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pptxexception/). Обрабатывайте исключение на границе операции и используйте отчёт о предупреждениях, чтобы определить, привела ли политика приложения к завершению, вместо того чтобы полагаться на один тип исключения или сообщение. Колбэк записывает предупреждение перед возвратом `ReturnAction.Abort`, обеспечивая доступность причины для приложения.

## **Категории предупреждений**

Класс [WarningType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/warningtype/) предоставляет целочисленные константы для следующих категорий:

| Тип предупреждения | Значение | Типичная политика |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/ru/python-java/aspose.slides/warningtype/#SourceFileCorruption) | Исходная презентация содержит повреждения, которые могут сделать документ, сохранённый в его оригинальном формате, непригодным. | Прервать. |
| [DataLoss](https://reference.aspose.com/slides/ru/python-java/aspose.slides/warningtype/#DataLoss) | Текст, диаграммы, изображения или другие данные могут отсутствовать после загрузки или сохранения. | Прервать. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/ru/python-java/aspose.slides/warningtype/#MajorFormattingLoss) | Презентация может потерять важное форматирование. | Прервать в режиме строгой проверки; в остальных случаях записать и продолжить. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/ru/python-java/aspose.slides/warningtype/#MinorFormattingLoss) | Может возникнуть ограниченное различие в форматировании. | Записать для диагностики и продолжить. |
| [CompatibilityIssue](https://reference.aspose.com/slides/ru/python-java/aspose.slides/warningtype/#CompatibilityIssue) | Результат может не открываться или работать корректно в некоторых приложениях или старых версиях. | Вести журнал и продолжать, если совместимость не обязательна. |
| [UnexpectedContent](https://reference.aspose.com/slides/ru/python-java/aspose.slides/warningtype/#UnexpectedContent) | Исходник содержит неподдерживаемый или нераспознанный контент, влияние которого может быть неизвестно. | Записать и продолжить, либо рассматривать как ошибку в строгой политике. |

Категория должна определять решение политики. Сохраняйте значение, возвращаемое `getDescription`, для диагностики, но не полагайтесь на его формулировку в логике приложения, поскольку текст сообщения может различаться между сценариями предупреждений и версиями продукта.

## **Сбор и классификация предупреждений**

Следующий пример использует один отчёт уровня приложения для всего конвейера обработки. Отдельный экземпляр колбэка помечает предупреждения от загрузки, рендеринга, конвертации в PDF и сохранения PPTX. Политика прерывает работу при повреждении источника или потере данных, опционально прерывает при серьёзной потере форматирования и продолжает для остальных предупреждений.

```python
import sys
from dataclasses import dataclass
from enum import Enum

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, LoadOptions, PdfOptions, PptxOptions, Presentation, RenderingOptions, ReturnAction, SaveFormat, WarningType


class OperationStage(Enum):
    Loading = "Loading"
    Rendering = "Rendering"
    Conversion = "Conversion"
    Saving = "Saving"


@dataclass(frozen=True)
class WarningEntry:
    stage: OperationStage
    type: int
    description: str


class WarningReport:
    def __init__(self):
        self._entries = []

    def get_entries(self):
        return tuple(self._entries)

    def add(self, stage, warning):
        entry = WarningEntry(stage, warning.getWarningType(), str(warning.getDescription()))
        self._entries.append(entry)


class WarningPolicy:
    def __init__(self, abort_on_major_formatting_loss):
        self.abort_on_major_formatting_loss = abort_on_major_formatting_loss

    def get_action(self, warning_type):
        if warning_type in (WarningType.SourceFileCorruption, WarningType.DataLoss):
            return ReturnAction.Abort
        if warning_type == WarningType.MajorFormattingLoss and self.abort_on_major_formatting_loss:
            return ReturnAction.Abort
        return ReturnAction.Continue


class ReportingWarningCallback:
    def __init__(self, stage, report, policy):
        self.stage = stage
        self.report = report
        self.policy = policy

    def warning(self, warning):
        self.report.add(self.stage, warning)
        return self.policy.get_action(warning.getWarningType())


def process_presentation(input_path, report, policy):
    try:
        load_options = LoadOptions()
        handler = ReportingWarningCallback(OperationStage.Loading, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        load_options.setWarningCallback(callback)
        presentation = Presentation(input_path, load_options)
        try:
            if not render_first_slide(presentation, report, policy):
                return False
            if not convert_to_pdf(presentation, report, policy):
                return False
            return save_validated_copy(presentation, report, policy)
        finally:
            presentation.dispose()
    except Exception as exception:
        print(f"Loading stopped: {exception}", file=sys.stderr)
        return False


def render_first_slide(presentation, report, policy):
    if presentation.getSlides().size() == 0:
        print("Rendering stopped: the presentation has no slides.", file=sys.stderr)
        return False
    try:
        options = RenderingOptions()
        handler = ReportingWarningCallback(OperationStage.Rendering, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        image = presentation.getSlides().get_Item(0).getImage(options)
        try:
            image.save("slide-1.png", ImageFormat.Png)
            return True
        finally:
            image.dispose()
    except Exception as exception:
        print(f"Rendering stopped: {exception}", file=sys.stderr)
        return False


def convert_to_pdf(presentation, report, policy):
    try:
        options = PdfOptions()
        handler = ReportingWarningCallback(OperationStage.Conversion, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        presentation.save("converted.pdf", SaveFormat.Pdf, options)
        return True
    except Exception as exception:
        print(f"Conversion stopped: {exception}", file=sys.stderr)
        return False


def save_validated_copy(presentation, report, policy):
    try:
        options = PptxOptions()
        handler = ReportingWarningCallback(OperationStage.Saving, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        presentation.save("validated-output.pptx", SaveFormat.Pptx, options)
        return True
    except Exception as exception:
        print(f"Saving stopped: {exception}", file=sys.stderr)
        return False


def warning_type_name(warning_type):
    names = {
        WarningType.SourceFileCorruption: "SourceFileCorruption",
        WarningType.DataLoss: "DataLoss",
        WarningType.MajorFormattingLoss: "MajorFormattingLoss",
        WarningType.MinorFormattingLoss: "MinorFormattingLoss",
        WarningType.CompatibilityIssue: "CompatibilityIssue",
        WarningType.UnexpectedContent: "UnexpectedContent",
    }
    return names.get(warning_type, f"Unknown ({warning_type})")


report = WarningReport()
policy = WarningPolicy(True)
completed = process_presentation("input.pptx", report, policy)

print("Processing completed." if completed else "Processing stopped.")
for entry in report.get_entries():
    type_name = warning_type_name(entry.type)
    print(f"[{entry.stage.value}] {type_name}: {entry.description}")
```

Передайте `False` для `abort_on_major_formatting_loss` при создании `WarningPolicy`, если серьёзные различия в форматировании приемлемы. Проблемы совместимости, небольшая потеря форматирования и неожиданное содержание всё равно сохраняются в отчёте, даже если операция продолжается. Расширьте `WarningPolicy.get_action`, если приложение должно отклонять любую из этих категорий.

## **Распространённые сценарии предупреждений**

Предупреждения могут появляться на разных этапах рабочего процесса:

- **Электронные подписи:** Подписанная презентация может вызвать предупреждение при загрузке, что её подпись будет потеряна во время обработки. Aspose.Slides сообщает об этом условии `DataLoss` через `IPresentationSignedWarningInfo`. Колбэк на этапе загрузки позволяет приложению отклонить файл или явно принять сообщённую потерю.
- **Замена шрифтов:** Недоступный шрифт может быть заменён во время рендеринга слайда или экспорта. Предупреждения о замене шрифтов сообщаются как `DataLoss`, поэтому строгая политика выше прерывает процесс, даже если приложение считает замену визуально приемлемой. Чтобы увидеть это поведение, используйте презентацию с текстом в шрифте, недоступном в среде выполнения. Описание предупреждения указывает замену; настройте необходимые шрифты или [font substitution rules](/slides/ru/python-java/font-substitution/) перед новой попыткой.
- **Неподдерживаемый или неожиданный контент:** Загрузчик может встретить записи презентации или функции, которые он не распознаёт. Такие предупреждения могут использовать `UnexpectedContent` или более серьёзную категорию, если известны потери данных или форматирования.
- **Совместимость формата:** Сохранение в другой формат презентации может опустить функции или привести к результату, который ведёт себя по‑другому в некоторых приложениях. Например, сохранение презентации с более чем восемью горизонтальными или вертикальными направляющими в устаревший PPT приводит к `CompatibilityIssue`. Колбэк на этапе сохранения может записать потерю и продолжить, либо отклонить её, если требуется сохранить все направляющие.
- **Поведение загрузки:** Параметры загрузки и устаревшее поведение могут также вызывать предупреждения. Например, `IObsoletePresLockingBehaviorWarningInfo` идентифицирует использование устаревшего поведения блокировки презентации как `CompatibilityIssue`.

Предупреждения зависят от исходного документа, целевого формата, операции и версии Aspose.Slides. Не следует считать, что каждый файл генерирует предупреждение или что сценарий всегда относится к единственной категории.

## **Безопасное обработка прерванных операций**

Когда колбэк возвращает `ReturnAction.Abort`, не используйте объект, который не загрузился, и не предполагайте, что вывод рендеринга или сохранения завершён. Операция может завершиться после создания выходного файла, но до его завершения.

Сохраняйте проверенные результаты в отдельный путь, например `validated-output.pptx`. Заменяйте существующую презентацию только после успешного завершения операции, когда отчёт о предупреждениях удовлетворяет политике приложения и файл можно открыть и проверить. Это предотвращает перезапись корректного исходного файла частичным или отклонённым результатом.

Пустой отчёт о предупреждениях не гарантирует, что все исходные функции сохранены. Выполните любые дополнительные проверки содержимого и визуальные проверки, требуемые приложением. Смотрите также [Open Presentations](/slides/ru/python-java/open-presentation/) и [Save Presentations](/slides/ru/python-java/save-presentation/).

## **FAQ**

**Может ли колбэк предупреждений обрабатывать каждую ошибку Aspose.Slides?**

Нет. Он обрабатывает восстанавливаемые условия, сообщаемые как предупреждения. Исключения, возникающие независимо от колбэка, должны обрабатываться приложением вокруг вызова загрузки, рендеринга, конвертации или сохранения.

**Гарантирует ли возврат `ReturnAction.Continue` идентичный вывод?**

Нет. Он только позволяет продолжить обработку. Сообщённое условие всё равно может вызвать различия в данных, форматировании или совместимости, поэтому необходимо проанализировать собранные типы и описания предупреждений.

**Как приложение может определить операцию, которая сформировала предупреждение?**

Создайте отдельный экземпляр колбэка для каждой операции и храните определённый приложением этап вместе со значениями, возвращаемыми `getWarningType` и `getDescription`, как показано в примере.