---
title: C++에서 원본 프레젠테이션 형식 결정
linktitle: 소스 형식
type: docs
weight: 35
url: /ko/cpp/detect-presentation-source-format/
keywords:
- 소스 형식
- 프레젠테이션 형식 감지
- PowerPoint
- OpenDocument
- 프레젠테이션
- PPT
- PPTX
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 C++에서 로드된 프레젠테이션의 원본 형식을 읽고, 감지 API를 비교하며, 파일, 스트림 및 레거시 형식을 처리합니다."
---
## **개요**

프레젠테이션을 로드한 후, [Presentation::get_SourceFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/get_sourceformat/)을 호출하여 원본 형식을 확인합니다. 이 메서드는 [IPresentation::get_SourceFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentation/get_sourceformat/)에서도 사용할 수 있습니다. 현재 인스턴스가 로드된 형식에 따라 이후 처리가 달라지는 경우에 사용합니다.

소스 형식은 출력 파일에 선택한 [SaveFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/saveformat/)과는 별개입니다. 다른 형식으로 저장해도 기존 인스턴스의 소스 형식은 변경되지 않습니다.

## **파일의 소스 형식 읽기**

이 예제는 기존 `sample.pptx` 파일이 필요합니다. 파일을 로드하고 파일 이름 대신 [Presentation::get_SourceFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/get_sourceformat/)을 사용해 애플리케이션 처리 정책을 선택합니다. 다른 형식을 시험하려면 입력 경로를 변경하십시오. 예제는 선택된 정책을 출력합니다; 메시지는 애플리케이션 로직에 맞게 교체하세요.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

switch (presentation->get_SourceFormat())
{
    case SourceFormat::Ppt:
    case SourceFormat::Pps:
    case SourceFormat::Pot:
        Console::WriteLine(u"Use the legacy PowerPoint processing policy.");
        break;
    case SourceFormat::Pptx:
        Console::WriteLine(u"Use the standard PPTX processing policy.");
        break;
    default:
        Console::WriteLine(String::Format(u"Use the general policy for {0}.", ObjectExt::ToString(presentation->get_SourceFormat())));
        break;
}
```

## **지원되는 값 확인**

[SourceFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/sourceformat/) 열거형은 다음 프레젠테이션 형식을 구분합니다. 아래 확장자는 원래 파일 이름을 재구성한 것이 아니라 일반적인 확장자입니다.

| SourceFormat 값 | 확장자 | 형식 |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 프레젠테이션 |
| `Pptx` | `.pptx` | Office Open XML 프레젠테이션 |
| `Pptm` | `.pptm` | 매크로 사용 Office Open XML 프레젠테이션 |
| `Pps` | `.pps` | PowerPoint 97–2003 슬라이드 쇼 |
| `Ppsx` | `.ppsx` | Office Open XML 슬라이드 쇼 |
| `Ppsm` | `.ppsm` | 매크로 사용 Office Open XML 슬라이드 쇼 |
| `Pot` | `.pot` | PowerPoint 97–2003 템플릿 |
| `Potx` | `.potx` | Office Open XML 템플릿 |
| `Potm` | `.potm` | 매크로 사용 Office Open XML 템플릿 |
| `Odp` | `.odp` | OpenDocument 프레젠테이션 |
| `Otp` | `.otp` | OpenDocument 프레젠테이션 템플릿 |
| `Fodp` | `.fodp` | Flat XML ODF 프레젠테이션 |
| `Xml` | `.xml` | PowerPoint XML 프레젠테이션 |

## **스트림의 소스 형식 읽기**

이 예제는 기존 `sample.pps` 파일이 필요합니다. 파일의 바이트를 메모리 스트림으로 읽어 파일 이름 없이 입력을 모델링합니다(예: 데이터베이스 값이나 업로드된 바이트 배열). [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 생성자는 스트림만 받습니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto bytes = File::ReadAllBytes(u"sample.pps");
auto stream = MakeObject<MemoryStream>(bytes);
auto presentation = MakeObject<Presentation>(stream);

Console::WriteLine(String::Format(u"Source format: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));
```

PPT, PPS 및 POT는 동일한 바이너리 형식을 공유합니다. 파일 경로로 로드할 때는 확장자를 통해 슬라이드 쇼나 템플릿을 구분할 수 있습니다. 파일 이름이 없으면 레거시 PPS와 POT 콘텐츠가 `SourceFormat::Ppt`로 보고될 수 있으며, 위의 PPS 예제도 `Ppt`를 반환합니다.

애플리케이션에서 이러한 구분을 유지해야 한다면 원본 파일 이름이나 서브타입 메타데이터를 별도로 보관하십시오. 확장자는 이러한 레거시 서브타입을 추정하는 데 유용하지만, 임의의 프레젠테이션 콘텐츠를 식별하는 유일한 근거가 되어서는 안 됩니다.

## **로드 전후 감지 비교**

전체 프레젠테이션 객체 모델을 로드하기 전에 파일을 검사하려면 [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentationfactory/getpresentationinfo/)와 [IPresentationInfo::get_LoadFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentationinfo/get_loadformat/)를 사용합니다. 인스턴스가 이미 존재한다면 [Presentation::get_SourceFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/get_sourceformat/)을 사용하십시오.

이 예제는 `sample.pptx`가 필요하며 두 검사 모두 `Pptx`를 출력합니다. 실제 환경에서는 처리 단계에 맞는 API를 선택하세요. 이미 로드된 프레젠테이션은 소스 형식을 얻기 위해 두 번째 검사가 필요하지 않습니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <DOM/PresentationFactory.h>
#include <DOM/IPresentationInfo.h>
#include <LoadFormat.h>

using namespace Aspose::Slides;
using namespace System;

auto path = String(u"sample.pptx");
auto information = PresentationFactory::get_Instance()->GetPresentationInfo(path);
Console::WriteLine(String::Format(u"Before loading: {0}", ObjectExt::ToString(information->get_LoadFormat())));

auto presentation = MakeObject<Presentation>(path);
Console::WriteLine(String::Format(u"After loading: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));
```

결과 열거형은 서로 다릅니다: [LoadFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/loadformat/)과 [SourceFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/sourceformat/). 숫자 값을 캐스팅해서 비교하거나 모든 형식이 동일한 감지 결과를 가진다고 가정하지 마십시오. PowerPoint XML은 로드 전에 `LoadFormat::Unknown`으로, 로드 후에는 `SourceFormat::Xml`으로 보고될 수 있습니다.

## **소스와 출력 형식 분리 유지**

이 예제는 `sample.pptx`를 입력으로 하고 `converted.odp`를 출력 파일로 작성합니다. 원본 인스턴스를 저장하기 전후 모두 `Pptx`를 출력합니다. ODP 출력에서 새로 로드된 인스턴스만 `Odp`를 보고합니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
Console::WriteLine(String::Format(u"Before saving: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));

presentation->Save(u"converted.odp", SaveFormat::Odp);
Console::WriteLine(String::Format(u"After saving: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));

auto reopened = MakeObject<Presentation>(u"converted.odp");
Console::WriteLine(String::Format(u"Reopened output: {0}", ObjectExt::ToString(reopened->get_SourceFormat())));
```

`MakeObject<Presentation>()`으로 처음부터 만든 프레젠테이션은 `SourceFormat::Pptx`를 보고합니다. 입력 파일이 없기 때문에 이것은 새로 만든 인스턴스의 기본값이며, PPTX 파일이 로드된 증거가 아닙니다. 구분이 필요하다면 인스턴스가 생성된 것인지 로드된 것인지 별도로 추적하십시오.

## **소스 형식을 확장자로 매핑**

다음 예제는 `sample.pptx`가 필요합니다. 현재 지원되는 모든 [SourceFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/sourceformat/) 값을 일반적인 확장자로 매핑하며, 입력 파일 이름을 파싱하지 않습니다. 인식되지 않은 값에 대해 조용히 확장자를 할당하는 것을 방지하기 위해 기본값을 사용합니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto extension = String::Empty;
switch (presentation->get_SourceFormat())
{
    case SourceFormat::Ppt:
        extension = u".ppt";
        break;
    case SourceFormat::Pptx:
        extension = u".pptx";
        break;
    case SourceFormat::Pptm:
        extension = u".pptm";
        break;
    case SourceFormat::Pps:
        extension = u".pps";
        break;
    case SourceFormat::Ppsx:
        extension = u".ppsx";
        break;
    case SourceFormat::Ppsm:
        extension = u".ppsm";
        break;
    case SourceFormat::Pot:
        extension = u".pot";
        break;
    case SourceFormat::Potx:
        extension = u".potx";
        break;
    case SourceFormat::Potm:
        extension = u".potm";
        break;
    case SourceFormat::Odp:
        extension = u".odp";
        break;
    case SourceFormat::Otp:
        extension = u".otp";
        break;
    case SourceFormat::Fodp:
        extension = u".fodp";
        break;
    case SourceFormat::Xml:
        extension = u".xml";
        break;
    default:
        break;
}

Console::WriteLine(extension.IsEmpty() ? u"No extension mapping is available." : extension);
```

이 매핑은 파일을 변환하거나 스트림 로드 중에 손실된 레거시 PPS/POT 서브타입을 복구하지 않습니다. 실제 저장 시에는 [SaveFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/saveformat/)을 명시적으로 선택하거나 [원본 형식으로 프레젠테이션 저장](/slides/ko/cpp/save-presentation/#save-presentations-in-their-original-format)에서 보여준 변환을 사용하십시오.

## **저장 및 재열기로 형식 확인**

이 독립 실행형 예제는 프레젠테이션을 생성하고 작업 디렉터리에 세 개의 파일을 작성합니다(동일한 이름의 파일을 덮어씀). 각 출력 파일을 경로와 메모리 스트림 모두로 다시 엽니다. PPTX와 ODP는 두 경로 모두 저장된 형식을 보고합니다. PPS는 경로로 로드할 때 `Pps`를, 파일 이름 없이 바이트만 로드할 때 `Ppt`를 보고합니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto formats = MakeArray<SaveFormat>({SaveFormat::Pptx, SaveFormat::Odp, SaveFormat::Pps});

for (auto format : formats)
{
    auto formatName = ObjectExt::ToString(format);
    auto path = String::Format(u"roundtrip.{0}", formatName.ToLowerInvariant());
    presentation->Save(path, format);

    auto fromFile = MakeObject<Presentation>(path);
    auto bytes = File::ReadAllBytes(path);
    auto stream = MakeObject<MemoryStream>(bytes);
    auto fromStream = MakeObject<Presentation>(stream);

    Console::WriteLine(String::Format(u"{0}: file={1}, stream={2}", formatName, ObjectExt::ToString(fromFile->get_SourceFormat()), ObjectExt::ToString(fromStream->get_SourceFormat())));
}
```

다음 표는 확장자가 일치하는 프레젠테이션에 대한 소스 형식 식별을 요약합니다:

| 저장 형식 | 파일 경로에서의 SourceFormat | 이름 없는 스트림에서의 SourceFormat |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | 각각 `Pptx`, `Pptm` | 파일 경로와 동일 |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | 각각 `Ppsx`, `Ppsm` | 파일 경로와 동일 |
| POT | `Pot` | `Ppt` |
| POTX, POTM | 각각 `Potx`, `Potm` | 파일 경로와 동일 |
| ODP, OTP | 각각 `Odp`, `Otp` | 파일 경로와 동일 |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

레거시 PPS/POT 콘텐츠는 이름 없는 스트림에서는 `Ppt`로 정규화됩니다. 이 표는 형식 식별에 관한 것이며, 변환 과정에서 모든 프레젠테이션 기능이 보존된다는 의미는 아닙니다.

## **FAQ**

**PPTX에서 로드한 프레젠테이션을 ODP로 저장하면 소스 형식이 변경됩니까?**

아니요. 기존 인스턴스는 여전히 `Pptx`를 보고합니다. 저장된 ODP 파일을 로드한 인스턴스는 `Odp`를 보고합니다.

**스트림만으로 레거시 프레젠테이션, 슬라이드 쇼, 템플릿을 구분할 수 있습니까?**

아니요. PPT, PPS, POT는 동일한 바이너리 형식을 공유합니다. 구분이 필요하면 파일 이름이나 서브타입 메타데이터를 별도로 유지하십시오.

**이미 로드된 프레젠테이션이라면 어떤 API를 사용해야 합니까?**

[Presentation::get_SourceFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/get_sourceformat/)을 사용하십시오. 로드 전에 검사가 필요하면 [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentationfactory/getpresentationinfo/)를 사용하세요.