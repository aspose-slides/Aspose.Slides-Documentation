---
title: C++에서 프레젠테이션 저장
linktitle: 프레젠테이션 저장
type: docs
weight: 80
url: /ko/cpp/save-presentation/
keywords:
- PowerPoint 저장
- OpenDocument 저장
- 프레젠테이션 저장
- 슬라이드 저장
- PPT 저장
- PPTX 저장
- ODP 저장
- 파일로 프레젠테이션
- 스트림으로 프레젠테이션
- 미리 정의된 보기 유형
- Strict Office Open XML 형식
- Zip64 모드
- 섬네일 새로 고침
- 저장 진행률
- C++
- Aspose.Slides
description: "Aspose.Slides를 사용하여 C++에서 프레젠테이션을 저장하는 방법을 알아보세요—레이아웃, 글꼴 및 효과를 유지하면서 PowerPoint 또는 OpenDocument로 내보낼 수 있습니다."
---
## **개요**

[C++에서 프레젠테이션 열기](/slides/ko/cpp/open-presentation/)는 프레젠테이션을 열기 위해 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스를 사용하는 방법을 설명했습니다. 이 문서에서는 프레젠테이션을 만들고 저장하는 방법을 설명합니다. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스는 프레젠테이션의 내용을 포함합니다. 처음부터 프레젠테이션을 만들든 기존 프레젠테이션을 수정하든 작업이 끝나면 저장해야 합니다. Aspose.Slides for C++를 사용하면 **파일**이나 **스트림**에 저장할 수 있습니다. 이 문서에서는 프레젠테이션을 저장하는 다양한 방법을 설명합니다.

## **파일에 프레젠테이션 저장**

[Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 `Save` 메서드를 호출하여 프레젠테이션을 파일에 저장합니다. 메서드에 파일 이름과 저장 형식을 전달합니다. 다음 예제는 Aspose.Slides를 사용하여 프레젠테이션을 저장하는 방법을 보여줍니다.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
auto presentation = MakeObject<Presentation>();

// 여기서 작업을 수행합니다...

// 프레젠테이션을 파일에 저장합니다.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **스트림에 프레젠테이션 저장**

[Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 `Save` 메서드에 출력 스트림을 전달하여 프레젠테이션을 스트림에 저장할 수 있습니다. 프레젠테이션은 다양한 스트림 유형에 기록될 수 있습니다. 아래 예제에서는 새 프레젠테이션을 생성하고 파일 스트림에 저장합니다.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
auto presentation = MakeObject<Presentation>();

auto fileStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

// Save the presentation to the stream.
presentation->Save(fileStream, SaveFormat::Pptx);

presentation->Dispose();
fileStream->Close();
```

## **미리 정의된 보기 유형으로 프레젠테이션 저장**

Aspose.Slides를 사용하면 생성된 프레젠테이션이 열릴 때 PowerPoint가 사용하는 초기 보기를 [ViewProperties](https://reference.aspose.com/slides/ko/cpp/aspose.slides/viewproperties/) 클래스를 통해 설정할 수 있습니다. [ViewType](https://reference.aspose.com/slides/ko/cpp/aspose.slides/viewtype/) 열거형의 값을 사용하여 [set_LastView](https://reference.aspose.com/slides/ko/cpp/aspose.slides/viewproperties/set_lastview/) 메서드를 호출합니다.

```cpp
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <ViewType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);

presentation->Save(u"SlideMasterView.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Strict Office Open XML 형식으로 프레젠테이션 저장**

Aspose.Slides를 사용하면 프레젠테이션을 Strict Office Open XML 형식으로 저장할 수 있습니다. 저장 시 [PptxOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/pptxoptions/) 클래스를 사용하고 해당 클래스의 conformance 속성을 설정합니다. `Conformance.Iso29500_2008_Strict`를 설정하면 출력 파일이 Strict Office Open XML 형식으로 저장됩니다.

아래 예제는 프레젠테이션을 생성하고 Strict Office Open XML 형식으로 저장합니다.

```cpp
#include <DOM/Presentation.h>
#include <Export/Conformance.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto options = MakeObject<PptxOptions>();
options->set_Conformance(Conformance::Iso29500_2008_Strict);

// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
auto presentation = MakeObject<Presentation>();

// Strict Office Open XML 형식으로 프레젠테이션을 저장합니다.
presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Zip64 모드에서 Office Open XML 형식으로 프레젠테이션 저장**

Office Open XML 파일은 ZIP 아카이브이며, 압축되지 않은 파일당 최대 4 GB(2^32 바이트), 압축된 파일당 최대 4 GB, 아카이브 전체 크기 4 GB 및 파일 수 65 535(2^16‑1) 제한을 가집니다. ZIP64 형식 확장자는 이러한 제한을 2^64까지 늘립니다.

[IPptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/ipptxoptions/set_zip64mode/) 메서드를 사용하면 Office Open XML 파일을 저장할 때 ZIP64 형식 확장을 사용할 시점을 선택할 수 있습니다.

이 메서드는 다음 모드와 함께 사용할 수 있습니다:

- `IfNecessary`는 프레젠테이션이 위 제한을 초과할 경우에만 ZIP64 형식 확장을 사용합니다. 기본 모드입니다.
- `Never`는 ZIP64 형식 확장을 사용하지 않습니다.
- `Always`는 항상 ZIP64 형식 확장을 사용합니다.

다음 코드는 ZIP64 형식 확장이 활성화된 상태로 PPTX 파일로 프레젠테이션을 저장하는 방법을 보여줍니다:

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <Export/Zip64Mode.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_Zip64Mode(Zip64Mode::Always);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}}
`Zip64Mode.Never`로 저장하면 프레젠테이션을 ZIP32 형식으로 저장할 수 없을 때 [PptxException](https://reference.aspose.com/slides/ko/cpp/aspose.slides/pptxexception/)이 발생합니다.
{{% /alert %}}

## **압축 수준을 사용하여 Office Open XML 형식으로 프레젠테이션 저장**

대용량 프레젠테이션을 다룰 때 압축 수준을 조절하여 파일 크기와 처리 시간을 균형 있게 맞출 수 있습니다. 요구 사항에 따라 더 빠른 처리 또는 더 작은 출력 파일을 선택할 수 있습니다.

Aspose.Slides는 [PptxOptions::set_CompressionLevel](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/pptxoptions/set_compressionlevel/) 메서드를 제공하며, 이를 통해 Office Open XML 형식으로 프레젠테이션을 저장할 때 사용할 압축 수준을 지정할 수 있습니다.

사용 가능한 압축 수준은 다음과 같습니다:

- **None**: 압축이 적용되지 않습니다. 파일이 원본 그대로 저장됩니다.
- **Level1:** 가장 빠른 압축이며 압축 비율이 가장 낮습니다.
- **Level2:** **Level1**보다 약간 더 나은 압축 비율을 가진 더 빠른 압축입니다.
- **Level3:** **Level2**보다 더 나은 압축을 제공하지만 처리 시간에 중간 정도 영향을 줍니다.
- **Level4:** **Level3**보다 더 나은 압축을 제공합니다.
- **Level5:** **Level4**보다 개선된 압축을 제공하지만 추가적인 처리 시간이 필요합니다.
- **Level6:** 표준 압축으로 처리 속도와 파일 크기 사이에 좋은 균형을 제공합니다. *기본 압축 수준*입니다.
- **Level7:** **Level6**보다 더 나은 압축을 제공하지만 처리 속도가 느립니다.
- **Level8:** **Level7**보다 더 나은 압축을 제공합니다.
- **Level9:** 최대 압축으로 가장 작은 파일 크기를 제공하지만 가장 긴 처리 시간이 소요됩니다.

다음 예제는 압축 없이 PPTX 파일로 프레젠테이션을 저장하는 방법을 보여줍니다:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Export::CompressionLevel;
using Aspose::Slides::Export::PptxOptions;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::MakeObject;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_CompressionLevel(CompressionLevel::None);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");
presentation->Save(u"Sample-out.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

다음 예제는 최대 압축을 사용하여 PPTX 파일로 프레젠테이션을 저장하는 방법을 보여줍니다:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Export::CompressionLevel;
using Aspose::Slides::Export::PptxOptions;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::MakeObject;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_CompressionLevel(CompressionLevel::Level9);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");
presentation->Save(u"Sample-level9.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

## **섬네일 새로 고침 없이 프레젠테이션 저장**

[PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) 메서드는 PPTX로 프레젠테이션을 저장할 때 섬네일 생성을 제어합니다:

- `true`로 설정하면 저장 중에 섬네일이 새로 고쳐집니다. 기본값입니다.
- `false`로 설정하면 현재 섬네일이 유지됩니다. 프레젠테이션에 섬네일이 없으면 생성되지 않습니다.

아래 코드에서는 섬네일을 새로 고치지 않고 PPTX로 프레젠테이션을 저장합니다.

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_RefreshThumbnail(false);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
이 옵션은 PPTX 형식으로 프레젠테이션을 저장하는 데 필요한 시간을 줄이는 데 도움이 됩니다.
{{% /alert %}}

## **백분율로 저장 진행 상황 업데이트**

[IProgressCallback](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iprogresscallback/) 인터페이스는 [ISaveOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/isaveoptions/) 인터페이스와 추상 [SaveOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/saveoptions/) 클래스가 제공하는 `set_ProgressCallback` 메서드를 통해 사용됩니다. `set_ProgressCallback`에 IProgressCallback 구현을 할당하면 저장 진행 상황을 백분율로 받을 수 있습니다.

다음 코드 스니펫은 `IProgressCallback`을 사용하는 방법을 보여줍니다:

```cpp
#include <IProgressCallback.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        // 여기에서 진행률 백분율 값을 사용합니다.
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};
```
```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <IProgressCallback.h>
#include <system/console.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// 위에서 정의한 진행률 콜백 클래스.
class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};

auto saveOptions = MakeObject<PdfOptions>();
saveOptions->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, saveOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Aspose는 자체 API를 사용하여 [무료 PowerPoint Splitter 앱](https://products.aspose.app/slides/ko/splitter)을 개발했습니다. 이 앱을 사용하면 선택한 슬라이드를 새 PPTX 또는 PPT 파일로 저장하여 프레젠테이션을 여러 파일로 분할할 수 있습니다.
{{% /alert %}}

## **FAQ**

**"빠른 저장"(증분 저장)이 지원되어 변경된 부분만 기록되나요?**

아니요. 저장 시마다 전체 대상 파일을 새로 만들며, 증분 '빠른 저장'은 지원되지 않습니다.

**여러 스레드에서 동일한 Presentation 인스턴스를 저장해도 스레드 안전한가요?**

아니요. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 인스턴스는 [스레드 안전하지 않습니다](/slides/ko/cpp/multithreading/); 단일 스레드에서 저장하십시오.

**저장 시 하이퍼링크와 외부 연결 파일은 어떻게 되나요?**

[Hyperlinks](/slides/ko/cpp/manage-hyperlinks/)는 보존됩니다. 외부 연결 파일(예: 상대 경로로 연결된 비디오)은 자동으로 복사되지 않으므로, 참조된 경로가 계속 접근 가능하도록 해야 합니다.

**문서 메타데이터(작성자, 제목, 회사, 날짜)를 설정/저장할 수 있나요?**

예. 표준 [문서 속성](/slides/ko/cpp/presentation-properties/)이 지원되며 저장 시 파일에 기록됩니다.