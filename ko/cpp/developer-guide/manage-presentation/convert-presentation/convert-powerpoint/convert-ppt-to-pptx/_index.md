---
title: C++에서 PPT를 PPTX로 변환
linktitle: PPT to PPTX
type: docs
weight: 20
url: /ko/cpp/convert-ppt-to-pptx/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPT to PPTX
- PPT를 PPTX로 저장
- PPT를 PPTX로 내보내기
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides를 사용하여 C++에서 레거시 PPT 파일을 PPTX로 변환합니다. 단일 파일 및 배치 변환, 오류 처리, 충실도에 대한 참고 사항을 포함한 C++ 예제가 포함됩니다."
---
## **Overview**

PPT는 레거시 이진 PowerPoint 형식이며, PPTX는 최신 Open XML 형식입니다. Aspose.Slides for C++는 Microsoft PowerPoint 없이 PPT 파일을 로드하고 PPTX로 저장할 수 있습니다. 이 문서에서는 파일 하나 또는 디렉터리 전체를 변환하는 방법과 변환 후 확인해야 할 사항을 설명합니다.

## **Convert a PPT File to PPTX**

소스 파일을 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스로 로드한 다음, [Presentation::Save](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/save/) 메서드에 [SaveFormat::Pptx](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/saveformat/) 을 지정하여 저장합니다. 더 이상 필요하지 않을 때 프레젠테이션을 해제하여 리소스를 해제하십시오.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Load the legacy PPT presentation.
auto presentation = System::MakeObject<Presentation>(u"presentation.ppt");

// Save the presentation in PPTX format.
presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

파일 확장자만으로 출력 형식이 결정되지 않습니다; [SaveFormat::Pptx](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/saveformat/) 인수가 결정합니다. 원본 PPT 파일을 보존하려면 입력 및 출력 경로를 다르게 설정하십시오.

## **Convert Multiple PPT Files**

다음 예제는 하나의 디렉터리에서 모든 `.ppt` 파일을 변환합니다. 각 파일은 독립적으로 처리되므로 하나의 변환 실패가 전체 배치를 중단시키지 않습니다.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

String inputDirectory = u"input";
String outputDirectory = u"output";
Directory::CreateDirectory_(outputDirectory);

auto inputPaths = Directory::GetFiles(inputDirectory, u"*.ppt", SearchOption::TopDirectoryOnly);
for (const auto& inputPath : inputPaths)
{
    auto outputFileName = Path::GetFileNameWithoutExtension(inputPath) + u".pptx";
    auto outputPath = Path::Combine(outputDirectory, outputFileName);

    try
    {
        auto presentation = MakeObject<Presentation>(inputPath);
        presentation->Save(outputPath, SaveFormat::Pptx);
        presentation->Dispose();
        Console::WriteLine(String::Format(u"Converted: {0}", inputPath));
    }
    catch (Exception& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Failed: {0} ({1})", inputPath, exception->get_Message()));
    }
}
```

프로덕션 환경에서는 전체 예외를 로그에 기록하고, 기존 출력 파일을 덮어쓸지 여부를 결정하며, 실패한 파일 이름을 재시도 또는 검토 큐에 기록하십시오. 손상된 파일, 필수 비밀번호 없이 열려진 암호 보호 파일, 접근할 수 없는 경로, 지원되지 않는 콘텐츠 등은 변환 실패의 원인이 될 수 있습니다. 암호화된 파일 로드에 대해서는 [Password-Protected Presentations](/slides/ko/cpp/password-protected-presentation/) 을 참조하십시오.

## **Fidelity and Legacy Features**

변환은 일반적으로 슬라이드, 마스터, 레이아웃, 텍스트, 도형, 이미지, 표 및 차트를 보존합니다. 그러나 PPT와 PPTX는 모든 기능을 정확히 동일하게 표현하지는 않습니다. PPTX에 해당하는 것이 없거나 라이브러리에서 지원되지 않는 레거시 기능은 정규화되거나 생략되거나 다르게 표시될 수 있습니다.

변환된 파일에 애니메이션, 전환, 포함되거나 연결된 OLE 개체, ActiveX 컨트롤, 포함된 미디어, 비표준 글꼴 또는 VBA 매크로가 포함된 경우 확인하십시오. 일반 PPTX 파일은 매크로 사용 형식이 아니므로 VBA를 유지해야 할 경우 매크로 사용 워크플로를 사용하십시오. 또한 변환된 프레젠테이션이 열리거나 렌더링될 환경에 필요한 글꼴 및 외부 리소스가 포함되어 있는지도 확인하십시오.

중요 문서의 경우, 생성된 PPTX를 프로그래밍 방식으로 다시 열어 핵심 슬라이드 수와 내용을 검사하고, 의도된 뷰어에서 외관 및 슬라이드 쇼 동작을 비교하십시오. 성공적인 [Presentation::Save](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/save/) 호출이 모든 레거시 기능이 정확히 PPTX로 변환되었다는 증거로 간주되지 않도록 하십시오.

## **When to Use PPTX**

프레젠테이션을 최신 PowerPoint 버전에서 편집하거나, Open XML 패키지를 사용하는 시스템과 교환하거나, 레거시 바이너리 PPT보다 검토 및 복구가 쉬운 형식으로 저장하려는 경우 PPTX를 사용하십시오. 변환된 프레젠테이션이 충실도 검증을 통과할 때까지 원본 PPT를 보관하거나 롤백 사본으로 유지하십시오.

PDF, HTML, 이미지, XPS 또는 다른 출력 형식이 필요하면, 모든 대상이 편집 가능한 PowerPoint 기능을 보존한다고 가정하지 말고 [Convert Presentations to Multiple Formats](/slides/ko/cpp/convert-presentation/) 에 있는 형식별 가이드를 참고하십시오.

## **Online Converter**

가끔 파일을 변환하거나 빠르게 비교하려면 [online PPT to PPTX converter](https://products.aspose.app/slides/ko/conversion/ppt-to-pptx) 를 사용할 수 있습니다. 반복적인 변환, 배치 처리 또는 응용 수준 오류 처리가 필요한 경우 C++ API를 사용하십시오.

## **Related Articles**

- [Save Presentations in C++](/slides/ko/cpp/save-presentation/)
- [Supported File Formats](/slides/ko/cpp/supported-file-formats/)
- [Open Presentations in C++](/slides/ko/cpp/open-presentation/)

## **FAQ**

**Can I convert PPT to PPTX without Microsoft PowerPoint installed?**

예. Aspose.Slides for C++는 Microsoft PowerPoint 없이 프레젠테이션 파일을 로드하고 저장합니다.

**Will PPT-to-PPTX conversion preserve all content exactly?**

일반적인 프레젠테이션 콘텐츠는 보존하지만, 모든 레거시 또는 지원되지 않는 기능에 대해 정확한 충실도가 보장되지는 않습니다. 매크로, OLE 또는 ActiveX 개체, 미디어, 특수 애니메이션 또는 비표준 글꼴이 포함된 경우 생성된 파일을 검토하십시오.

**Can I convert a password-protected PPT file?**

예, 파일을 로드할 때 올바른 비밀번호를 제공하면 가능합니다. 비밀번호가 없거나 틀리면 로드 작업이 실패합니다.

**Should I delete the PPT file after conversion?**

원본을 확인하고 필요한 뷰어 및 워크플로에서 PPTX가 제대로 작동하는 것을 확인할 때까지 보관하십시오. 이렇게 하면 레거시 기능이 다르게 변환될 경우 롤백 복사본으로 사용할 수 있습니다.