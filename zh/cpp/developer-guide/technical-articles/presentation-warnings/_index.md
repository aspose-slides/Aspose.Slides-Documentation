---
title: 处理 C++ 中的演示文稿警告
type: docs
weight: 70
url: /zh/cpp/presentation-warnings/
aliases:
- /cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- 警告回调
- 警告策略
- 数据丢失
- 源文件损坏
- 兼容性问题
- 字体替换
- 数字签名
- 演示文稿加载
- 演示文稿渲染
- 演示文稿转换
- 演示文稿保存
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "了解如何在使用 Aspose.Slides for C++ 加载、渲染、转换和保存演示文稿时收集、分类并处理警告。"
---
## **概述**

Aspose.Slides 在加载、渲染、转换或保存演示文稿时可能会报告可恢复的问题。示例包括损坏的源记录、无法保留的内容、字体替换以及目标格式的限制。警告回调让应用程序记录这些情况并决定当前操作是否可以继续。

实现[IWarningCallback](https://reference.aspose.com/slides/zh/cpp/aspose.slides.warnings/iwarningcallback/)接口并检查通过[IWarningInfo](https://reference.aspose.com/slides/zh/cpp/aspose.slides.warnings/iwarninginfo/)提供的[IWarningInfo::get_WarningType](https://reference.aspose.com/slides/zh/cpp/aspose.slides.warnings/iwarninginfo/get_warningtype/)和[IWarningInfo::get_Description](https://reference.aspose.com/slides/zh/cpp/aspose.slides.warnings/iwarninginfo/get_description/)方法。返回[ReturnAction::Continue](https://reference.aspose.com/slides/zh/cpp/aspose.slides.warnings/returnaction/)接受警告，或返回`ReturnAction::Abort`终止操作。

使用[LoadOptions::set_WarningCallback](https://reference.aspose.com/slides/zh/cpp/aspose.slides/loadoptions/set_warningcallback/)处理打开演示文稿时产生的警告。渲染和导出选项类继承自[SaveOptions::set_WarningCallback](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/saveoptions/set_warningcallback/)，该回调接收来自幻灯片渲染、转换和保存的警告。由于警告本身不标识具体的应用操作，构建综合报告时请将每个回调实例与操作阶段关联。

## **警告和异常**

警告描述的是当回调返回`ReturnAction::Continue`时 Aspose.Slides 能够恢复的情况。异常表示请求的操作无法正常完成；异常不会转换为警告，也无法通过警告策略处理。

返回`ReturnAction::Abort`会让警告分发器通过抛出异常终止当前操作。公开的异常类型取决于操作和演示文稿格式。例如，加载时可能出现[PptxReadException](https://reference.aspose.com/slides/zh/cpp/aspose.slides/pptxreadexception/)或[PptReadException](https://reference.aspose.com/slides/zh/cpp/aspose.slides/pptreadexception/)，而保存或导出时可能出现[PptxException](https://reference.aspose.com/slides/zh/cpp/aspose.slides/pptxexception/)。在操作边界捕获异常，并使用警告报告判断是否因为应用策略导致终止，而不是仅依据某个异常子类型或消息。回调在返回`ReturnAction::Abort`前记录警告，确保原因对应用程序可用。

## **警告类别**

[WarningType](https://reference.aspose.com/slides/zh/cpp/aspose.slides.warnings/warningtype/)枚举提供以下类别：

| 警告类型 | 含义 | 典型策略 |
| --- | --- | --- |
| `SourceFileCorruption` | 源演示文稿包含损坏，可能导致以原始格式保存的文档不可用。 | 中止。 |
| `DataLoss` | 加载或保存后可能缺少文本、图表、图像或其他数据。 | 中止。 |
| `MajorFormattingLoss` | 演示文稿可能失去重要的格式。 | 在严格验证模式下中止；否则记录并继续。 |
| `MinorFormattingLoss` | 可能出现有限的格式差异。 | 记录用于诊断并继续。 |
| `CompatibilityIssue` | 结果可能在某些应用或旧版本中无法打开或行为异常。 | 记录日志并继续，除非兼容性是强制要求。 |
| `UnexpectedContent` | 源包含不受支持或未识别的内容，其影响尚不确定。 | 记录并继续，或在严格策略下视为错误。 |

类别应驱动策略决策。存储警告描述用于诊断，但不要在业务逻辑中依赖其具体文字，因为不同警告场景和产品版本的消息文本可能会变化。

## **收集和分类警告**

下面的示例为完整的处理管线使用了一个应用级报告。分别的回调实例为加载、渲染、PDF 转换和 PPTX 保存标记警告。策略在源文件损坏或数据丢失时中止，可选在重大格式丢失时中止，其他警告则继续。

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

将`abortOnMajorFormattingLoss`设为`false`可以接受重大格式差异。兼容性问题、次要格式丢失和意外内容即使在操作继续时仍会保留在报告中。若应用必须拒绝这些类别中的任何一个，请扩展`WarningPolicy::GetAction`。

## **常见警告场景**

警告可能出现在工作流的不同阶段：

- **数字签名：** 已签名的演示文稿在加载时可能产生警告，提示其签名将在处理过程中丢失。Aspose.Slides 通过[IPresentationSignedWarningInfo](https://reference.aspose.com/slides/zh/cpp/aspose.slides.warnings/ipresentationsignedwarninginfo/)报告此`DataLoss`情况。加载阶段的回调可让应用程序拒绝该文件或明确接受报告的丢失。
- **字体替换：** 在渲染或导出幻灯片时，若缺少某个字体可能被替换。字体替换警告被报告为`DataLoss`，因此上述严格策略会中止，即使应用认为特定替代在视觉上可接受。要观察此行为，请使用包含运行时不可用字体的输入演示文稿。警告描述会标识替换的字体；在重试前配置所需字体或[字体替换规则](/slides/zh/cpp/font-substitution/)。
- **不受支持或意外的内容：** 加载器可能遇到无法识别的演示文稿记录或特性。此类警告可能使用`UnexpectedContent`，或在数据或格式已知受影响时使用更严重的类别。
- **格式兼容性：** 保存为其他演示文稿格式时可能遗漏特性，或导致结果在某些应用中表现不同。例如，将包含超过八条水平或垂直绘图指南的演示文稿保存为旧版 PPT 会报告`CompatibilityIssue`。保存阶段的回调可以记录此丢失并继续，或在必须保留所有指南时拒绝保存。
- **加载行为：** 加载选项和旧行为也可能产生警告。例如，[IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/zh/cpp/aspose.slides.warnings/iobsoletepreslockingbehaviorwarninginfo/)将使用已废弃的演示文稿锁定行为标识为`CompatibilityIssue`。

警告取决于源文档、目标格式、操作以及 Aspose.Slides 版本。不要假定每个文件都会产生警告，也不要认为某种场景始终映射到唯一类别。

## **安全处理已中止的操作**

当回调返回`ReturnAction::Abort`时，禁止使用加载失败的对象，也不要假设渲染或保存输出已完整。操作可能在创建输出文件后但在完成之前终止。

将已验证的结果保存到单独路径，如`validated-output.pptx`。仅在操作成功完成、警告报告符合应用策略且输出能够打开并检查后，才替换已有的演示文稿。这样可避免用部分或被拒绝的结果覆盖有效的源文件。

空的警告报告并不保证每个源特性都已保留。请执行应用程序所需的额外内容和视觉检查。另见[打开演示文稿](/slides/zh/cpp/open-presentation/)和[保存演示文稿](/slides/zh/cpp/save-presentation/)。

## **常见问题**

**警告回调能处理所有 Aspose.Slides 错误吗？**

不能。它只能处理以警告形式报告的可恢复情况。独立于回调的异常必须在加载、渲染、转换或保存调用的外层由应用程序处理。

**返回`ReturnAction::Continue`是否保证输出完全相同？**

不能。它仅允许继续处理。报告的情况仍可能导致数据、格式或兼容性差异，请检查收集到的警告类型和描述。

**应用程序如何识别产生警告的操作？**

为每个操作创建一个回调实例，并将应用自定义的阶段信息与警告类型和描述一起存储，如示例所示。