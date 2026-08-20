---
title: C++에서 PPT를 PPTX로 변환
linktitle: PPT를 PPTX로
type: docs
weight: 20
url: /ko/cpp/convert-ppt-to-pptx/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPT를 PPTX로
- PPT를 PPTX로 저장
- PPT를 PPTX로 내보내기
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides를 사용하여 C++에서 레거시 PPT 파일을 PPTX로 변환합니다. 단일 파일 및 배치 변환, 오류 처리, 정밀도 주석에 대한 C++ 예제가 포함됩니다."
---
## **개요**

PPT는 레거시 이진 PowerPoint 형식이며, PPTX는 최신 Open XML 형식입니다. Aspose.Slides for C++는 Microsoft PowerPoint 없이 PPT 파일을 로드하고 PPTX로 저장할 수 있습니다. 이 문서는 파일 하나 또는 파일 디렉터리를 변환하는 방법을 보여 주며, 변환 후 확인해야 할 사항을 설명합니다.

## **PPT 파일을 PPTX로 변환**

원본 파일을 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스로 로드한 다음, [Presentation::Save](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/save/)에 [SaveFormat::Pptx](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/saveformat/)를 전달하여 호출합니다. 더 이상 필요하지 않을 때 프레젠테이션을 Dispose하여 리소스를 해제합니다.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// 레거시 PPT 프레젠테이션을 로드합니다.
auto presentation = System::MakeObject<Presentation>(u"presentation.ppt");

// 프레젠테이션을 PPTX 형식으로 저장합니다.
presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

파일 확장자는 출력 형식을 자동으로 선택하지 않으며, [SaveFormat::Pptx](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/saveformat/) 인수가 이를 지정합니다. 원본 PPT 파일을 유지해야 하는 경우 입력 경로와 출력 경로를 다르게 설정하십시오.

## **여러 PPT 파일 변환**

다음 예제는 한 디렉터리의 모든 `.ppt` 파일을 변환합니다. 각 파일은 독립적으로 처리되므로 하나의 변환 실패가 배치의 나머지를 중단시키지 않습니다.

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

프로덕션 작업에서는 전체 예외를 로그에 기록하고, 기존 출력 파일을 덮어쓸지 여부를 결정하며, 실패한 파일 이름을 재시도 또는 검토 큐에 기록하십시오. 손상된 파일, 필수 비밀번호 없이 연 암호 보호 파일, 접근할 수 없는 경로 및 지원되지 않는 콘텐츠는 모두 변환 실패를 일으킬 수 있습니다. 암호화된 파일을 로드하려면 [Password-Protected Presentations](/cpp/password-protected-presentation/)을 참조하십시오.

## **정밀도 및 레거시 기능**

변환은 일반적으로 슬라이드, 마스터, 레이아웃, 텍스트, 도형, 이미지, 표 및 차트를 보존합니다. 그러나 PPT와 PPTX는 모든 기능을 정확히 같은 방식으로 표현하지 않습니다. PPTX에 해당하는 것이 없거나 라이브러리에서 지원되지 않는 레거시 기능은 정규화되거나, 생략되거나, 다르게 표시될 수 있습니다.

변환된 파일에 애니메이션, 전환, 포함되거나 연결된 OLE 개체, ActiveX 컨트롤, 포함된 미디어, 일반적이지 않은 폰트 또는 VBA 매크로가 포함된 경우 확인하십시오. 일반 PPTX 파일은 매크로가 활성화된 형식이 아니므로 VBA를 유지해야 할 경우 적절한 매크로 활성화 워크플로를 사용하십시오. 또한 변환된 프레젠테이션이 열리거나 렌더링될 환경에 필요한 폰트와 외부 리소스가 존재하는지도 확인하십시오.

중요한 문서의 경우, 생성된 PPTX를 프로그래밍 방식으로 다시 열어 핵심 슬라이드 수와 내용을 검사한 뒤, 의도한 뷰어에서 외观 및 슬라이드 쇼 동작을 비교하십시오. 성공적인 [Presentation::Save](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/save/) 호출을 모든 레거시 기능이 정확히 PPTX로 표현된다는 증거로 삼지 마십시오.

## **PPTX를 사용해야 할 때**

프레젠테이션을 최신 PowerPoint 버전에서 편집하거나, Open XML 패키지를 사용하는 시스템과 교환하거나, 레거시 이진 PPT보다 검토 및 복구가 쉬운 형식으로 저장하려면 PPTX를 사용하십시오. 변환된 프레젠테이션이 정밀도 검사를 통과할 때까지 원본 PPT를 보관용 또는 롤백 사본으로 유지하십시오.

PDF, HTML, 이미지, XPS 또는 다른 출력 형식이 필요하다면, 모든 대상이 편집 가능한 PowerPoint 기능을 보존한다고 가정하지 말고 [Convert Presentations to Multiple Formats](/cpp/convert-presentation/)에 있는 형식별 지침을 이용하십시오.

## **온라인 변환기**

가끔 파일을 변환하거나 빠르게 비교하려면 [online PPT to PPTX converter](https://products.aspose.app/slides/ko/conversion/ppt-to-pptx)를 사용할 수 있습니다. 반복 가능한 변환, 배치 처리 또는 애플리케이션 수준 오류 처리를 위해서는 C++ API를 사용하십시오.

## **관련 문서**

- [C++에서 프레젠테이션 저장](/cpp/save-presentation/)
- [지원 파일 형식](/cpp/supported-file-formats/)
- [C++에서 프레젠테이션 열기](/cpp/open-presentation/)

## **FAQ**

**Microsoft PowerPoint 없이 PPT를 PPTX로 변환할 수 있나요?**

예. Aspose.Slides for C++는 Microsoft PowerPoint가 없어도 프레젠테이션 파일을 로드하고 저장합니다.

**PPT를 PPTX로 변환하면 모든 콘텐츠가 정확히 보존되나요?**

일반적인 프레젠테이션 콘텐츠는 보존되지만, 모든 레거시 또는 지원되지 않는 기능에 대해 정확한 정밀도가 보장되지는 않습니다. 매크로, OLE 또는 ActiveX 개체, 미디어, 특수 애니메이션 또는 일반적이지 않은 폰트가 포함된 경우 생성된 파일을 검토하십시오.

**암호 보호된 PPT 파일을 변환할 수 있나요?**

예, 파일을 로드할 때 올바른 비밀번호를 제공하면 가능합니다. 비밀번호가 없거나 틀리면 로드 작업이 실패합니다.

**변환 후 PPT 파일을 삭제해야 하나요?**

중요한 뷰어와 워크플로에서 PPTX를 확인할 때까지 원본을 보관하십시오. 레거시 기능이 다르게 변환될 경우 롤백 사본을 제공합니다.