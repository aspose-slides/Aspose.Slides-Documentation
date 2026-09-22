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
- 파일에 프레젠테이션
- 스트림에 프레젠테이션
- 미리 정의된 보기 유형
- Strict Office Open XML 형식
- Zip64 모드
- 썸네일 새로 고치기
- 저장 진행 상황
- C++
- Aspose.Slides
description: "C++에서 Aspose.Slides를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션을 파일 또는 스트림에 저장하고, PPTX 출력 및 진행 상황 보고를 구성합니다."
---
## **개요**

프레젠테이션을 만든 후 혹은 기존 프레젠테이션을 [열기](/slides/ko/cpp/open-presentation/) 하면, [Presentation::Save](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/save/) 메서드를 사용하여 결과를 기록합니다. C++용 Aspose.Slides는 PowerPoint, OpenDocument, PDF 및 기타 형식으로 프레젠테이션을 파일이나 스트림에 저장할 수 있습니다. 다음 섹션에서는 표준 저장 작업과 PPTX 출력에 사용할 수 있는 옵션을 다룹니다.

## **파일에 프레젠테이션 저장**

프레젠테이션을 파일에 저장하려면 출력 경로와 [SaveFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/saveformat/) 값을 [Presentation::Save](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/save/) 메서드에 전달합니다. 형식 값은 Aspose.Slides가 만드는 파일 유형을 결정합니다.

다음 예제는 프레젠테이션을 생성하고 PPTX 파일로 저장합니다:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

// 여기에서 프레젠테이션 내용을 추가하거나 수정합니다.

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **원본 형식으로 프레젠테이션 저장**

파일 및 스트림 감지 예제, 새로 만든 프레젠테이션의 동작, 원본과 출력 형식의 구분에 대해서는 [원본 프레젠테이션 형식 확인](/slides/ko/cpp/detect-presentation-source-format/)을 참조하십시오.

배치 처리 애플리케이션에서는 입력 형식을 미리 알 수 없는 경우가 많습니다. 파일을 로드한 후에는 [IPresentation::get_SourceFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentation/get_sourceformat/)으로 원본 형식을 읽습니다. 얻은 [SourceFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/sourceformat/) 값을 [SlideUtil::ToSaveFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides.util/slideutil/tosaveformat/)에 전달하여 해당 [SaveFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/saveformat/) 값을 얻은 다음, [Presentation::Save](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/save/)를 사용하여 수정된 프레젠테이션을 기록합니다.

다음 완전한 예제는 입력 디렉터리의 모든 파일을 처리하고, 제목을 업데이트한 뒤, 로드된 형식 그대로 출력 디렉터리에 저장합니다:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Util/SlideUtil.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Util;
using namespace System;
using namespace System::IO;

String inputDirectory = u"Input";
String outputDirectory = u"Output";

Directory::CreateDirectory_(outputDirectory);

auto inputPaths = Directory::GetFiles(inputDirectory);
for (const auto& inputPath : inputPaths)
{
    try
    {
        auto presentation = MakeObject<Presentation>(inputPath);

        auto sourceFormat = presentation->get_SourceFormat();
        auto saveFormat = SlideUtil::ToSaveFormat(sourceFormat);

        presentation->get_DocumentProperties()->set_Title(u"Processed by the batch application");

        auto outputPath = Path::Combine(outputDirectory, Path::GetFileName(inputPath));
        presentation->Save(outputPath, saveFormat);
        presentation->Dispose();
    }
    catch (ArgumentException& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Cannot map the source format of '{0}': {1}", inputPath, exception->get_Message()));
    }
    catch (Exception& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Cannot process '{0}': {1}", inputPath, exception->get_Message()));
    }
}
```

[SlideUtil::ToSaveFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides.util/slideutil/tosaveformat/)은 PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP, PowerPoint XML을 해당 프레젠테이션 저장 형식으로 매핑합니다. 이는 프레젠테이션 소스 형식만 매핑하며, PDF, HTML, TIFF, 이미지와 같은 내보내기 형식을 선택하기 위한 것이 아닙니다. 지원되지 않거나 잘못된 [SourceFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/sourceformat/) 값을 전달하면 [ArgumentException](https://reference.aspose.com/slides/ko/cpp/system/argumentexception/)이 발생합니다.

레거시 PPT, PPS, POT 파일은 동일한 이진 컨테이너를 사용합니다. 스트림에서 확장자 없이 이러한 프레젠테이션을 로드하면 PPS 또는 POT 파일이 PPT로 식별될 수 있습니다. 이러한 레거시 하위 유형을 보존해야 하는 경우 원본 파일명이나 형식 메타데이터를 별도로 유지하고, 출력 파일명 및 형식을 선택할 때 사용하십시오.

## **프레젠테이션을 스트림에 저장**

최종 파일 경로에 의존하지 않고 프레젠테이션을 기록하려면 쓰기 가능한 [Stream](https://reference.aspose.com/slides/ko/cpp/system.io/stream/)와 [SaveFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/saveformat/) 값을 [Presentation::Save](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/save/) 메서드에 전달합니다. 이 방법은 결과를 웹 서비스에서 반환하거나 데이터베이스에 저장하거나 메모리에서 처리해야 할 때 유용합니다.

다음 예제는 새 프레젠테이션을 파일 스트림에 저장합니다:

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

auto presentation = MakeObject<Presentation>();
auto outputStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

presentation->Save(outputStream, SaveFormat::Pptx);

outputStream->Close();
presentation->Dispose();
```

## **미리 정의된 보기 유형으로 프레젠테이션 저장**

PowerPoint가 저장된 프레젠테이션을 열 때 처음 표시할 보기를 지정할 수 있습니다. 저장하기 전에 [ViewProperties::set_LastView](https://reference.aspose.com/slides/ko/cpp/aspose.slides/viewproperties/set_lastview/)에 [ViewType](https://reference.aspose.com/slides/ko/cpp/aspose.slides/viewtype/) 값을 전달하십시오.

다음 예제는 슬라이드 마스터 보기를 초기 보기로 설정합니다:

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

Strict Office Open XML 프로파일을 준수하는 PPTX 파일을 만들려면 [PptxOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/pptxoptions/) 인스턴스를 만든 뒤 `Conformance::Iso29500_2008_Strict`와 함께 [PptxOptions::set_Conformance](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/pptxoptions/set_conformance/)를 호출합니다. 그런 다음 옵션을 [Presentation::Save](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/save/) 메서드에 전달합니다.

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

auto presentation = MakeObject<Presentation>();

presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Zip64 모드로 Office Open XML 형식으로 프레젠테이션 저장**

표준 ZIP 아카이브는 각 항목의 압축 및 비압축 크기, 전체 아카이브 크기 및 항목 수에 제한을 둡니다. PPTX 파일은 ZIP 아카이브이므로 매우 큰 프레젠테이션은 이러한 제한을 초과할 수 있습니다. ZIP64 확장은 적용 가능한 크기 및 항목 수 제한을 확장합니다.

[**PptxOptions::set_Zip64Mode**](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/pptxoptions/set_zip64mode/)를 사용하여 Aspose.Slides가 ZIP64 확장을 쓸지 제어합니다:

- `IfNecessary`는 프레젠테이션이 표준 ZIP 제한을 초과할 경우에만 ZIP64를 사용합니다. 기본 모드입니다.
- `Never`는 ZIP64 확장을 사용하지 않습니다.
- `Always`는 항상 ZIP64 확장을 씁니다.

다음 예제는 출력 프레젠테이션에 대해 ZIP64 확장을 항상 활성화합니다:

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <Export/Zip64Mode.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_Zip64Mode(Zip64Mode::Always);

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

{{% alert color="warning" title="Warning" %}}
`Zip64Mode`가 `Never`로 설정되고 프레젠테이션이 표준 ZIP 제한에 맞지 않을 경우, 저장 작업 중에 [PptxException](https://reference.aspose.com/slides/ko/cpp/aspose.slides/pptxexception/)이 발생합니다.
{{% /alert %}}

## **압축 레벨을 사용하여 Office Open XML 형식으로 프레젠테이션 저장**

PPTX 출력 시 [PptxOptions::set_CompressionLevel](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/pptxoptions/set_compressionlevel/)를 호출하여 저장 속도와 파일 크기의 균형을 맞출 수 있습니다. [CompressionLevel](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/compressionlevel/) 열거형은 다음 값을 제공합니다:

- `None`은 압축 없이 데이터를 저장합니다.
- `Level1`은 가장 빠른 압축과 가장 큰 압축 결과물을 제공합니다.
- `Level2`부터 `Level5`까지는 저장 속도보다 작은 출력 크기를 점점 선호합니다.
- `Level6`은 저장 속도와 파일 크기의 균형을 맞춥니다. 기본 레벨입니다.
- `Level7` 및 `Level8`은 저장 속도보다 작은 출력 크기를 더 선호합니다.
- `Level9`는 가장 강력한 압축을 제공하지만 가장 많은 처리 시간이 필요합니다.

다음 예제는 압축 없이 프레젠테이션을 저장합니다:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_CompressionLevel(CompressionLevel::None);

presentation->Save(u"OutputNoCompression.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

다음 예제는 최대 압축 레벨을 사용합니다:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_CompressionLevel(CompressionLevel::Level9);

presentation->Save(u"OutputMaximumCompression.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **썸네일을 새로 고치지 않고 프레젠테이션 저장**

프레젠테이션을 PPTX로 저장할 때 [PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/)가 문서 썸네일을 제어합니다:

- `true`는 저장 중에 썸네일을 다시 생성합니다. 기본값입니다.
- `false`는 기존 썸네일을 유지합니다. 프레젠테이션에 썸네일이 없을 경우 Aspose.Slides는 썸네일을 생성하지 않습니다.

다음 예제는 썸네일을 새로 고치지 않고 프레젠테이션을 저장합니다:

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_RefreshThumbnail(false);

presentation->Save(u"Output.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
썸네일 새로 고침을 비활성화하면 PPTX 파일 저장에 필요한 시간을 줄일 수 있습니다.
{{% /alert %}}

## **백분율로 저장 진행 상황 업데이트**

저장 작업을 모니터링하려면 [IProgressCallback](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iprogresscallback/) 인터페이스를 구현하고 구현체를 [ISaveOptions::set_ProgressCallback](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/isaveoptions/set_progresscallback/)에 전달합니다. Aspose.Slides는 내보내기 동안 진행 값을 사용하여 [IProgressCallback::Reporting](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iprogresscallback/reporting/)을 호출합니다.

다음 예제는 PDF 내보내기 진행 상황을 콘솔에 보고합니다:

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

class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        int progress = static_cast<int>(progressValue);
        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};

auto options = MakeObject<PdfOptions>();
options->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, options);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Aspose는 Aspose.Slides API로 만든 무료 [PowerPoint Splitter](https://products.aspose.app/slides/ko/splitter)를 제공합니다. 이 도구는 프레젠테이션에서 선택한 슬라이드를 별도의 PPT 또는 PPTX 파일로 저장합니다.
{{% /alert %}}

## **FAQ**

**Aspose.Slides가 증분 저장 또는 “빠른 저장”을 지원합니까?**

아니요. 각 저장 작업은 변경된 부분만 업데이트하는 것이 아니라 전체 출력 파일을 완전히 작성합니다.

**여러 스레드가 동일한 Presentation 인스턴스를 저장할 수 있나요?**

아니요. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 인스턴스는 [스레드 안전하지 않습니다](/slides/ko/cpp/multithreading/). 각 인스턴스는 한 번에 하나의 스레드에서만 액세스하고 저장해야 합니다.

**프레젠테이션을 저장할 때 하이퍼링크와 외부 연결 파일은 어떻게 처리되나요?**

[하이퍼링크](/slides/ko/cpp/manage-hyperlinks/)는 프레젠테이션에 그대로 남습니다. Aspose.Slides는 외부 연결 파일을 복사하지 않으므로, 저장된 프레젠테이션은 여전히 해당 위치에 접근할 수 있어야 합니다.

**작성자, 제목, 회사, 생성 날짜와 같은 문서 메타데이터를 저장할 수 있나요?**

네. 저장하기 전에 적절한 [문서 속성](/slides/ko/cpp/presentation-properties/)을 설정하면 Aspose.Slides가 이를 출력 파일에 기록합니다.