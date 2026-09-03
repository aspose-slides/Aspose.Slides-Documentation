---
title: Обработка предупреждений презентаций в C++
type: docs
weight: 70
url: /ru/cpp/presentation-warnings/
aliases:
- /cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- обратный вызов предупреждения
- политика предупреждений
- потеря данных
- повреждение источника
- проблема совместимости
- замена шрифтов
- цифровая подпись
- загрузка презентации
- отображение презентации
- конвертация презентации
- сохранение презентации
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "Узнайте, как собирать, классифицировать и реагировать на предупреждения при загрузке, отображении, конвертации и сохранении презентаций с помощью Aspose.Slides для C++."
---
## **Обзор**

Aspose.Slides может сообщать о восстанавливаемых проблемах во время загрузки, рендеринга, конвертации или сохранения презентации. Примерами являются повреждённые исходные записи, контент, который нельзя сохранить, замена шрифтов и ограничения целевого формата. Обратный вызов предупреждения позволяет приложению фиксировать эти условия и решать, может ли текущая операция продолжиться.

Реализуйте интерфейс [IWarningCallback](https://reference.aspose.com/slides/ru/cpp/aspose.slides.warnings/iwarningcallback/) и изучите методы [IWarningInfo::get_WarningType](https://reference.aspose.com/slides/ru/cpp/aspose.slides.warnings/iwarninginfo/get_warningtype/) и [IWarningInfo::get_Description](https://reference.aspose.com/slides/ru/cpp/aspose.slides.warnings/iwarninginfo/get_description/), предоставляемые через [IWarningInfo](https://reference.aspose.com/slides/ru/cpp/aspose.slides.warnings/iwarninginfo/). Верните [ReturnAction::Continue](https://reference.aspose.com/slides/ru/cpp/aspose.slides.warnings/returnaction/), чтобы принять предупреждение, или `ReturnAction::Abort`, чтобы остановить операцию.

Используйте [LoadOptions::set_WarningCallback](https://reference.aspose.com/slides/ru/cpp/aspose.slides/loadoptions/set_warningcallback/) для предупреждений, возникающих при открытии презентации. Классы параметров рендеринга и экспорта наследуют [SaveOptions::set_WarningCallback](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/saveoptions/set_warningcallback/), который получает предупреждения от рендеринга слайдов, конвертации и сохранения. Поскольку само предупреждение не указывает, какая операция приложения его вызвала, привязывайте каждый экземпляр обратного вызова к этапу операции при построении объединённого отчёта.

## **Предупреждения и исключения**

Предупреждение описывает состояние, из которого Aspose.Slides может восстановиться, если обратный вызов вернёт `ReturnAction::Continue`. Исключение означает, что запрошенная операция не может завершиться нормально; исключения не преобразуются в предупреждения и не могут обрабатываться политикой предупреждений.

Возврат `ReturnAction::Abort` просит диспетчер предупреждений завершить текущую операцию, вызвав исключение. Публичное исключение зависит от операции и формата презентации. Например, при загрузке может возникнуть [PptxReadException](https://reference.aspose.com/slides/ru/cpp/aspose.slides/pptxreadexception/) или [PptReadException](https://reference.aspose.com/slides/ru/cpp/aspose.slides/pptreadexception/), а при сохранении или экспорте — [PptxException](https://reference.aspose.com/slides/ru/cpp/aspose.slides/pptxexception/). Обрабатывайте исключение на границе операции и используйте отчёт о предупреждениях, чтобы определить, была ли причина завершения вызвана политикой приложения, а не полагаться лишь на один тип исключения или сообщение. Обратный вызов фиксирует предупреждение перед возвратом `ReturnAction::Abort`, обеспечивая доступность причины для приложения.

## **Категории предупреждений**

Перечисление [WarningType](https://reference.aspose.com/slides/ru/cpp/aspose.slides.warnings/warningtype/) предоставляет следующие категории:

| Тип предупреждения | Смысл | Типичная политика |
| --- | --- | --- |
| `SourceFileCorruption` | Исходная презентация содержит повреждения, которые могут сделать документ, сохранённый в оригинальном формате, непригодным. | Прервать. |
| `DataLoss` | Текст, диаграммы, изображения или другие данные могут отсутствовать после загрузки или сохранения. | Прервать. |
| `MajorFormattingLoss` | Презентация может потерять важное форматирование. | Прервать в режиме строгой проверки; в остальных случаях фиксировать и продолжать. |
| `MinorFormattingLoss` | Может возникнуть небольшое различие в форматировании. | Записывать для диагностики и продолжать. |
| `CompatibilityIssue` | Результат может не открываться или работать корректно в некоторых приложениях или старых версиях. | Журналировать и продолжать, если совместимость не является обязательной. |
| `UnexpectedContent` | Исходный документ содержит неподдерживаемый или нераспознанный контент, влияние которого может быть неизвестно. | Записывать и продолжать, либо рассматривать как ошибку в строгой политике. |

Категория должна определять политику. Сохраняйте описание предупреждения для диагностики, но не полагайтесь на его формулировку в логике приложения, поскольку текст сообщения может различаться между сценариями предупреждений и версиями продукта.

## **Сбор и классификация предупреждений**

В следующем примере используется один отчёт уровня приложения для всего конвейера обработки. Отдельный экземпляр обратного вызова помечает предупреждения, возникшие при загрузке, рендеринге, конвертации в PDF и сохранении PPTX. Политика прекращает работу при повреждении исходного файла или потере данных, при необходимости прекращает при крупной потере форматирования и продолжает при остальных предупреждениях.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/PptxOptions.h>
#include <Export/RenderingOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <Warnings/IWarningCallback.h>
#include <Warnings/IWarningInfo.h>
#include <Warnings/ReturnAction.h>
#include <Warnings/WarningType.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/scope_guard.h>
#include <system/smart_ptr.h>
#include <system/string.h>
#include <memory>
#include <vector>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Warnings;
using namespace System;

struct WarningEntry
{
    String Stage;
    WarningType Type;
    String Description;
};

class WarningReport
{
public:
    const std::vector<WarningEntry>& GetEntries() const
    {
        return entries;
    }

    void Add(const String& stage, const SharedPtr<IWarningInfo>& warning)
    {
        entries.push_back({stage, warning->get_WarningType(), warning->get_Description()});
    }

private:
    std::vector<WarningEntry> entries;
};

class WarningPolicy
{
public:
    explicit WarningPolicy(bool abortOnMajorFormattingLoss)
        : abortOnMajorFormattingLoss(abortOnMajorFormattingLoss)
    {
    }

    ReturnAction GetAction(WarningType warningType) const
    {
        if (warningType == WarningType::SourceFileCorruption || warningType == WarningType::DataLoss)
        {
            return ReturnAction::Abort;
        }

        if (warningType == WarningType::MajorFormattingLoss && abortOnMajorFormattingLoss)
        {
            return ReturnAction::Abort;
        }

        return ReturnAction::Continue;
    }

private:
    bool abortOnMajorFormattingLoss;
};

class ReportingWarningCallback : public IWarningCallback
{
public:
    ReportingWarningCallback(const String& stage, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
        : stage(stage), report(report), policy(policy)
    {
    }

    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override
    {
        report->Add(stage, warning);
        return policy.GetAction(warning->get_WarningType());
    }

private:
    String stage;
    std::shared_ptr<WarningReport> report;
    WarningPolicy policy;
};

class PresentationWarningExample
{
public:
    static void Run()
    {
        auto report = std::make_shared<WarningReport>();
        auto policy = WarningPolicy(true);
        auto completed = ProcessPresentation(u"input.pptx", report, policy);

        Console::WriteLine(completed ? u"Processing completed." : u"Processing stopped.");

        for (const auto& entry : report->GetEntries())
        {
            Console::WriteLine(u"[{0}] {1}: {2}", entry.Stage, entry.Type, entry.Description);
        }
    }

private:
    static bool ProcessPresentation(const String& inputPath, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto loadOptions = MakeObject<LoadOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Loading", report, policy);
            loadOptions->set_WarningCallback(callback);

            auto presentation = MakeObject<Presentation>(inputPath, loadOptions);
            auto cleanup = MakeScopeGuard([&presentation] { presentation->Dispose(); });

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
        catch (Exception& exception)
        {
            Console::WriteLine(u"Loading stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool RenderFirstSlide(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            if (presentation->get_Slides()->get_Count() == 0)
            {
                Console::WriteLine(u"Rendering stopped: the presentation has no slides.");
                return false;
            }

            auto options = MakeObject<RenderingOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Rendering", report, policy);
            options->set_WarningCallback(callback);

            auto image = presentation->get_Slide(0)->GetImage(options);
            auto cleanup = MakeScopeGuard([&image] { image->Dispose(); });
            image->Save(u"slide-1.png", ImageFormat::Png);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Rendering stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool ConvertToPdf(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto options = MakeObject<PdfOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Conversion", report, policy);
            options->set_WarningCallback(callback);

            presentation->Save(u"converted.pdf", SaveFormat::Pdf, options);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Conversion stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool SaveValidatedCopy(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto options = MakeObject<PptxOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Saving", report, policy);
            options->set_WarningCallback(callback);

            presentation->Save(u"validated-output.pptx", SaveFormat::Pptx, options);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Saving stopped: {0}", exception->get_Message());
            return false;
        }
    }
};

PresentationWarningExample::Run();
```

Установите `abortOnMajorFormattingLoss` в `false`, когда крупные различия в форматировании приемлемы. Проблемы совместимости, небольшие потери форматирования и неожиданный контент всё равно сохраняются в отчёте, даже если операция продолжается. Расширьте `WarningPolicy::GetAction`, если приложению необходимо отклонять любую из этих категорий.

## **Типичные сценарии предупреждений**

Предупреждения могут возникать на разных этапах рабочего процесса:

- **Электронные подписи:** Подписанная презентация может вызвать предупреждение при загрузке о том, что её подпись будет потеряна в процессе обработки. Aspose.Slides сообщает об этом состоянии `DataLoss` через [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/ru/cpp/aspose.slides.warnings/ipresentationsignedwarninginfo/). Обратный вызов на этапе загрузки позволяет приложению отклонить файл или явно принять зафиксированную потерю.
- **Замена шрифтов:** Недоступный шрифт может быть заменён во время рендеринга или экспорта слайда. Предупреждения о замене шрифтов сообщаются как `DataLoss`, поэтому строгая политика выше прерывает работу, даже если приложение считает замену визуально приемлемой. Чтобы наблюдать это поведение, используйте входную презентацию, содержащую текст шрифтом, недоступным во время выполнения. Описание предупреждения указывает замену; настройте необходимые шрифты или [правила замены шрифтов](/slides/ru/cpp/font-substitution/) перед повторной попыткой.
- **Неподдерживаемый или неожиданный контент:** Загрузчик может столкнуться с записями презентации или функциями, которые он не распознаёт. Такие предупреждения могут использовать `UnexpectedContent` или более строгую категорию, если известны повреждения данных или форматирования.
- **Совместимость форматов:** Сохранение в другой формат презентации может опустить функции или привести к результату, который ведёт себя иначе в некоторых приложениях. Например, сохранение презентации с более чем восемью горизонтальными или вертикальными направляющими черчения в устаревший PPT приводит к `CompatibilityIssue`. Обратный вызов на этапе сохранения может зафиксировать потерю и продолжить, либо отклонить её, если необходимо сохранить все направляющие.
- **Поведение при загрузке:** Параметры загрузки и устаревшее поведение могут также вызывать предупреждения. Например, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/ru/cpp/aspose.slides.warnings/iobsoletepreslockingbehaviorwarninginfo/) идентифицирует использование устаревшего поведения блокировки презентации как `CompatibilityIssue`.

Предупреждения зависят от исходного документа, целевого формата, операции и версии Aspose.Slides. Не следует предполагать, что каждый файл генерирует предупреждение или что сценарий всегда относится к единственной категории.

## **Безопасное управление прерванными операциями**

Когда обратный вызов возвращает `ReturnAction::Abort`, не используйте объект, который не удалось загрузить, и не полагайтесь на то, что вывод рендеринга или сохранения завершён. Операция может завершиться после создания выходного файла, но до завершения записи.

Сохраняйте проверенные результаты в отдельный путь, например `validated-output.pptx`. Заменяйте существующую презентацию только после успешного завершения операции, когда отчёт о предупреждениях соответствует политике приложения, и выходной файл можно открыть и проверить. Это предотвращает перезапись корректного исходного файла частичным или отклонённым результатом.

Пустой отчёт о предупреждениях не гарантирует, что все функции исходного файла сохранены. Выполните любые дополнительные проверки контента и визуальные проверки, требуемые приложением. Смотрите также [Открытие презентаций](/slides/ru/cpp/open-presentation/) и [Сохранение презентаций](/slides/ru/cpp/save-presentation/).

## **FAQ**

**Может ли обратный вызов предупреждения обработать каждую ошибку Aspose.Slides?**

Нет. Он обрабатывает восстанавливаемые состояния, сообщаемые как предупреждения. Исключения, возникающие независимо от обратного вызова, должны обрабатываться приложением вокруг вызовов загрузки, рендеринга, конвертации или сохранения.

**Гарантирует ли возврат `ReturnAction::Continue` идентичный результат?**

Нет. Он лишь позволяет продолжить обработку. Сообщённое состояние всё равно может вызвать различия в данных, форматировании или совместимости, поэтому следует просмотреть собранные типы и описания предупреждений.

**Как приложение может определить, какая операция вызвала предупреждение?**

Создайте экземпляр обратного вызова для каждой операции и храните определённый приложением этап совместно с типом предупреждения и его описанием, как показано в примере.