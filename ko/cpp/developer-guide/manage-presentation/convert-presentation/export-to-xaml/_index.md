---
title: C++에서 프레젠테이션을 XAML로 내보내기
linktitle: 프레젠테이션을 XAML로
type: docs
weight: 30
url: /ko/cpp/export-to-xaml/
keywords:
- PowerPoint 내보내기
- OpenDocument 내보내기
- 프레젠테이션 내보내기
- PowerPoint 변환
- OpenDocument 변환
- 프레젠테이션 변환
- PowerPoint를 XAML로
- OpenDocument를 XAML로
- 프레젠테이션을 XAML로
- PPT를 XAML로
- PPTX를 XAML로
- ODP를 XAML로
- PPT를 XAML 형식으로 저장
- PPTX를 XAML 형식으로 저장
- ODP를 XAML 형식으로 저장
- PPT를 XAML로 내보내기
- PPTX를 XAML로 내보내기
- ODP를 XAML로 내보내기
- C++
- Aspose.Slides
description: "Aspose.Slides를 사용하여 C++에서 PowerPoint 및 OpenDocument 슬라이드를 XAML로 변환합니다—빠르고 Office가 필요 없는 솔루션으로 레이아웃을 그대로 유지합니다."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션을 XAML로 내보내는 방법을 설명합니다. XAML에 대한 간략한 소개를 포함하고, 기본 설정으로 프레젠테이션을 XAML로 저장하는 방법을 보여주며, [XamlOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export.xaml/xamloptions/)을 통해 내보내기를 사용자 지정하는 방법을 시연합니다(숨겨진 슬라이드 내보내기 포함). 또한 폰트 대체, XAML 스택 호환성, 숨겨진 슬라이드 내보내기 동작과 관련된 일반적인 질문 몇 가지에 답합니다.

## **XAML 소개**

XAML은 WPF(Windows Presentation Foundation), UWP(Universal Windows Platform), Xamarin.Forms와 같은 프레임워크에서 사용자 인터페이스를 설명하기 위해 사용되는 XML 기반 마크업 언어입니다.

시각적 디자이너에서 XAML 파일을 작업하거나 마크업을 직접 작성·수정할 수 있습니다.

## **기본 옵션으로 프레젠테이션을 XAML로 내보내기**

다음 C++ 예제는 기본 설정으로 프레젠테이션을 XAML로 내보내는 방법을 보여줍니다:

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/XamlOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto xamlOptions = System::MakeObject<XamlOptions>();
presentation->Save(xamlOptions);
```

기본적으로 내보낸 슬라이드는 프로세스의 현재 작업 디렉터리([Directory::GetCurrentDirectory](https://reference.aspose.com/slides/ko/cpp/system.io/directory/getcurrentdirectory/)가 반환하는) `pres` 하위 폴더에 저장됩니다. 폴더는 자동으로 생성되며, 필요한 이미지도 해당 폴더에 저장됩니다.

출력 폴더 이름은 소스 파일명의 확장자를 제외한 이름에서 가져옵니다. `pres.pptx`의 경우 출력 파일은 `pres/Slide_1.xaml`, `pres/Slide_2.xaml` 등으로 이름이 지정됩니다. 입력 프레젠테이션에 절대 경로를 전달하더라도, 출력 폴더는 현재 작업 디렉터리를 기준으로 생성되며 입력 파일이 있는 위치와는 별개입니다.

## **사용자 지정 옵션으로 프레젠테이션을 XAML로 내보내기**

Aspose.Slides가 프레젠테이션을 XAML로 내보내는 방식을 제어하려면 [IXamlOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export.xaml/ixamloptions/) 인터페이스를 사용합니다.

출력을 사용자 지정 위치에 저장하려면 [IXamlOutputSaver](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export.xaml/ixamloutputsaver/)를 구현하고 해당 구현 인스턴스를 [XamlOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export.xaml/xamloptions/)의 [set_OutputSaver](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export.xaml/xamloptions/set_outputsaver/) 메서드에 전달합니다.

XAML 출력에 숨겨진 슬라이드를 포함하려면, 다음 C++ 예제와 같이 [set_ExportHiddenSlides](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) 메서드에 `true`를 전달합니다:

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/XamlOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);
presentation->Save(xamlOptions);
```

## **생성된 모든 XAML 아티팩트 캡처**

XAML 내보내기는 각 내보낸 슬라이드마다 XAML 문서와 별도의 이미지 및 지원 리소스를 생성할 수 있습니다. 기본 파일 시스템 저장 대신 이러한 아티팩트를 받으려면 사용자 정의 [IXamlOutputSaver](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export.xaml/ixamloutputsaver/)를 [XamlOptions::set_OutputSaver](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export.xaml/xamloptions/set_outputsaver/)에 전달합니다. XAML 옵션을 받는 [Presentation::Save](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/save/) 오버로드를 사용하여 내보내기를 시작합니다.

### **콜백 수명 주기 이해**

내보내기 프로그램은 생성된 각 아티팩트에 대해 [IXamlOutputSaver::Save](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export.xaml/ixamloutputsaver/save/)를 개별적으로 호출합니다:

- `path`는 아티팩트를 식별하며 상대 디렉터리를 포함할 수 있습니다. XAML이 리소스를 상대 경로로 참조할 수 있으므로 이 정보를 유지하세요.
- `data`는 아티팩트의 바이트를 포함합니다. 이미지 및 기타 바이너리 리소스는 텍스트로 디코딩해서는 안 됩니다.
- 저장자는 반환하기 전에 데이터를 유지하거나 영구 저장할 책임이 있습니다. 예제에서는 각 바이트 배열을 애플리케이션이 소유한 메모리로 복사합니다.
- 프레젠테이션 저장 작업이 반환되고 모든 콜백이 성공적으로 완료될 때만 내보내기가 성공한 것으로 간주합니다. 저장 오류를 무시하거나 관찰되지 않은 백그라운드 쓰기를 시작하지 마십시오. 지속성이 이후에 발생한다면 해당 단계가 성공한 후에 전체 성공을 보고합니다.

[XamlOptions::set_ExportHiddenSlides](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/)는 사용자 지정 저장자에도 적용됩니다. 기본값 `false`는 숨겨진 슬라이드 XAML 문서를 제외합니다. `true`로 설정하면 해당 문서와 내보내기에 필요한 모든 리소스가 포함됩니다. 리소스 개수는 프레젠테이션에 따라 다르므로 슬라이드당 하나의 콜백 또는 고정된 콜백 순서를 가정하지 마십시오.

### **메모리로 내보내고 아티팩트 검사**

이 완전한 예제는 `pres.pptx`를 로드하고, 모든 아티팩트를 [Dictionary<String, ArrayPtr<uint8_t>>](https://reference.aspose.com/slides/ko/cpp/system.collections.generic/dictionary/)에 수집한 뒤 이름, 유형 및 바이트 수를 출력합니다. 제공된 이름을 정확히 보존합니다. 중복 이름은 아티팩트를 조용히 덮어쓰는 대신 수집에 실패하게 합니다.

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/IXamlOutputSaver.h>
#include <Export/Xaml/XamlOptions.h>
#include <system/array.h>
#include <system/collections/dictionary.h>
#include <system/console.h>
#include <system/string_comparer.h>
#include <system/io/path.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;
using namespace System::Text;

class InMemoryXamlExample
{
    class MemoryXamlSaver : public IXamlOutputSaver
    {
    public:
        using ArtifactDictionary = Dictionary<String, ArrayPtr<uint8_t>>;
        SharedPtr<ArtifactDictionary> Artifacts = MakeObject<ArtifactDictionary>(StringComparer::get_Ordinal());

        void Save(String path, ArrayPtr<uint8_t> data) override
        {
            auto retainedData = data->Clone();
            Artifacts->Add(path, retainedData);
        }
    };

public:
    static void Run()
    {
        auto saver = MakeObject<MemoryXamlSaver>();
        auto presentation = MakeObject<Presentation>(u"pres.pptx");
        auto options = MakeObject<XamlOptions>();
        options->set_OutputSaver(saver);
        options->set_ExportHiddenSlides(true);
        presentation->Save(options);

        auto inspectXamlText = false;
        for (const auto& artifact : saver->Artifacts)
        {
            auto extension = Path::GetExtension(artifact.get_Key()).ToLowerInvariant();
            auto isXaml = extension == u".xaml";
            auto isImage = extension == u".png" || extension == u".jpg" || extension == u".jpeg" || extension == u".gif" || extension == u".bmp" || extension == u".tif" || extension == u".tiff" || extension == u".svg";
            String kind = isXaml ? u"slide XAML" : isImage ? u"image" : u"supporting resource";
            Console::WriteLine(u"{0}: {1} bytes ({2})", artifact.get_Key(), artifact.get_Value()->get_Length(), kind);

            // XAML만 디코드하고, 텍스트 검사가 필요할 때만 디코드합니다.
            if (isXaml && inspectXamlText)
            {
                auto markup = Encoding::get_UTF8()->GetString(artifact.get_Value());
                Console::WriteLine(markup);
            }
        }
    }
};
```

`InMemoryXamlExample::Run`을 애플리케이션에서 호출하십시오. 확장자 검사는 검사에 유용하므로 익숙하지 않은 리소스 타입을 포함한 모든 아티팩트를 유지하십시오. 저장하거나 전송할 때 바이트를 변경하지 마십시오. 텍스트 처리가 필요한 XAML에만 UTF-8 인코딩을 사용하여 [Encoding::GetString](https://reference.aspose.com/slides/ko/cpp/system.text/encoding/getstring/)을 활용합니다.

### **수집된 아티팩트를 ZIP 아카이브에 패키징**

이 독립적인 예제는 내보내기를 수집하고 이름을 검증한 뒤 원본 바이트를 ZIP 아카이브에 기록합니다. 고유한 아카이브 이름을 사용해 동시에 진행되는 내보내기 작업을 구분합니다. ZIP 항목은 슬래시('/')를 사용하고 상대 디렉터리를 유지합니다. 정규화 후 충돌하거나 위험한 이름은 기록 전에 전체 패키지를 거부합니다.

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/IXamlOutputSaver.h>
#include <Export/Xaml/XamlOptions.h>
#include <system/array.h>
#include <system/collections/dictionary.h>
#include <system/console.h>
#include <system/string_comparer.h>
#include <system/guid.h>
#include <system/io/file_access.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/io/path.h>
#include <zip/zip_file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;
using namespace Aspose::Zip;

class ZipXamlExample
{
    class CollectedXamlSaver : public IXamlOutputSaver
    {
    public:
        using ArtifactDictionary = Dictionary<String, ArrayPtr<uint8_t>>;
        SharedPtr<ArtifactDictionary> Artifacts = MakeObject<ArtifactDictionary>(StringComparer::get_Ordinal());

        void Save(String path, ArrayPtr<uint8_t> data) override
        {
            auto retainedData = data->Clone();
            Artifacts->Add(path, retainedData);
        }
    };

public:
    static void Run()
    {
        auto saver = MakeObject<CollectedXamlSaver>();
        auto presentation = MakeObject<Presentation>(u"pres.pptx");
        auto options = MakeObject<XamlOptions>();
        options->set_OutputSaver(saver);
        options->set_ExportHiddenSlides(false);
        presentation->Save(options);

        auto entries = MakeObject<Dictionary<String, ArrayPtr<uint8_t>>>(StringComparer::get_OrdinalIgnoreCase());
        for (const auto& artifact : saver->Artifacts)
        {
            auto entryName = artifact.get_Key().Replace(u'\\', u'/');
            auto segments = entryName.Split(u'/');
            auto unsafeName = entryName.StartsWith(u"/", StringComparison::Ordinal) || entryName.Contains(u":");
            for (const auto& segment : segments)
            {
                unsafeName |= String::IsNullOrWhiteSpace(segment) || segment == u"." || segment == u"..";
            }

            if (unsafeName || entries->ContainsKey(entryName))
            {
                Console::WriteLine(u"Export rejected: unsafe or duplicate artifact name: {0}", artifact.get_Key());
                return;
            }
            entries->Add(entryName, artifact.get_Value());
        }

        auto jobId = Guid::NewGuid();
        auto archivePath = u"xaml-" + jobId.ToString(u"N") + u".zip";
        auto archive = MakeObject<ZipFile>();
        for (const auto& artifact : entries)
        {
            auto fileName = Path::GetFileName(artifact.get_Key());
            auto directoryName = Path::GetDirectoryName(artifact.get_Key()).Replace(u'\\', u'/');
            archive->AddEntry(fileName, directoryName, artifact.get_Value());
        }

        auto output = MakeObject<FileStream>(archivePath, FileMode::CreateNew, FileAccess::Write);
        archive->Save(output);
        output->Close();
        archive->Dispose();

        // Save 메서드는 ZIP 디렉터리를 마무리합니다; 성공을 보고하기 전에 파일을 닫습니다.
        Console::WriteLine(u"Saved {0} artifacts to {1}", entries->get_Count(), archivePath);
    }
};
```

`ZipXamlExample::Run`을 애플리케이션에서 호출하십시오. 예제는 C++ 런타임의 `Aspose::Zip::ZipFile`을 사용해 로컬 아카이브 하나를 작성하며, 내보내기 프로그램 자체는 개별 XAML이나 이미지 파일을 쓰지 않습니다. 원격 저장소의 경우 수집된 바이트 배열을 업로드하도록 아카이브 작성 단계를 교체하십시오. 내보내기 작업 식별자와 전체 상대 아티팩트 이름을 블롭 키로 사용하거나, 작업 식별자, 상대 이름 및 바이너리 데이터를 데이터베이스 행에 저장하세요. 모든 업로드가 완료되거나 데이터베이스 트랜잭션이 커밋된 후에 작업을 게시합니다. 지속성이 실패하면 부분 출력물을 정리합니다.

대형 프레젠테이션의 경우, 사용자 지정 저장자를 사용해 각 아티팩트를 애플리케이션 저장소에 직접 영구 저장하면 전체 내보내기의 추가 복사본을 메모리에 유지할 필요가 없습니다. 내보내기 프로그램은 여전히 저장자를 호출하기 전에 모든 생성된 아티팩트를 메모리에 수집합니다. 내보내기 프로그램 입장에서 각 콜백을 동기식으로 유지하고, 대상이 바이트를 수락한 후에만 반환하며, 오류가 호출자에게 전달되도록 합니다.

### **리소스 이름 보존 및 참조 검증**

- 대상이 요구할 경우 경로 구분자를 정규화하되, 상대 디렉터리는 유지합니다. 모든 생성된 이름이 고유하고 리소스 참조가 유효함이 보장되지 않는 경우에는 [Path::GetFileName](https://reference.aspose.com/slides/ko/cpp/system.io/path/getfilename/)만 사용하지 마십시오.
- 대상별 이름 검증을 적용합니다. 개별 파일을 쓸 때는 루트 경로나 경로 탐색 세그먼트를 거부하고, [Path::GetFullPath](https://reference.aspose.com/slides/ko/cpp/system.io/path/getfullpath/)를 사용해 대상을 해결한 뒤, 디렉터리 구분자를 포함한 포함 여부 검사를 통해 지정된 내보내기 디렉터리 아래에 있는지 확인합니다. 쓰기를 리다이렉트할 수 있는 심볼릭 링크가 없는 애플리케이션 관리 디렉터리를 사용하십시오.
- 각 내보내기 작업마다 별도의 저장자와 저장 네임스페이스를 사용합니다. 구분자 정규화 후와 대상의 대소문자 구분 규칙에 따라 충돌을 감지합니다.
- 게시 전에 각 XAML 문서를 XML로 파싱하고 이미지 `Source` 또는 `ImageSource` 속성과 같은 파일 기반 리소스 참조를 검사합니다. 각 상대 URI를 해당 XAML 아티팩트 디렉터리를 기준으로 해결하고, 결과 저장 이름을 정규화한 뒤, 해당 사전 키, ZIP 항목 또는 저장 객체가 존재하는지 확인합니다. 외부 URI와 XAML 마크업 표현식은 상대 파일 이름과 별도로 처리합니다.

예를 들어, `pres/Slide_1.xaml`이 `images/image1.png`를 참조한다면, 저장된 리소스는 `pres/images/image1.png`로 존재해야 합니다. `image1.png`만 보관하면 해당 관계가 깨집니다. 객체 저장소의 경우 작업 접두사 아래에 동일한 레이아웃을 보존하고 해당 리소스 URL을 XAML 소비자가 액세스할 수 있도록 합니다. 완료된 ZIP을 다시 열어 항목 이름과 리소스 바이트를 확인하고, 대상 XAML 환경에서 대표 슬라이드를 로드해 이미지가 올바르게 해석되는지 확인합니다.

## **FAQ**

**원본 폰트가 머신에 없을 경우 예측 가능한 폰트를 보장하려면 어떻게 해야 하나요?**

[XamlOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export.xaml/xamloptions/)에서 [set_DefaultRegularFont](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/)을 사용하십시오 — 원본 폰트가 없을 때 내보내기 중 대체 폰트로 사용됩니다. 이는 생성된 XAML이 대체 폰트를 참조한다거나 해당 폰트가 대상 머신에 존재한다는 것을 보장하지 않습니다. XAML이 참조하는 폰트가 표시되는 환경에 존재하도록 하세요.

**내보낸 XAML이 WPF 전용인가요, 아니면 다른 XAML 스택에서도 사용할 수 있나요?**

Aspose.Slides는 공개 API를 통해 WPF XAML을 내보냅니다. UWP·Xamarin.Forms 등 다른 XAML 스택과의 호환성은 보장되지 않으며, 대상 환경에서 생성된 마크업을 테스트해야 합니다.

**숨겨진 슬라이드가 지원되나요, 기본적으로 내보내지 않으려면 어떻게 해야 하나요?**

기본적으로 숨겨진 슬라이드는 포함되지 않습니다. [XamlOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export.xaml/xamloptions/)의 [set_ExportHiddenSlides](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/)를 통해 이 동작을 제어할 수 있습니다—내보낼 필요가 없으면 비활성화 상태로 유지하십시오.