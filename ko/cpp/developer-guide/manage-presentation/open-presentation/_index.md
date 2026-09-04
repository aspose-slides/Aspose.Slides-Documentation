---
title: C++에서 프레젠테이션 열기
linktitle: 프레젠테이션 열기
type: docs
weight: 20
url: /ko/cpp/open-presentation/
keywords:
- PowerPoint 열기
- OpenDocument 열기
- 프레젠테이션 열기
- PPTX 열기
- PPT 열기
- ODP 열기
- 프레젠테이션 로드
- PPTX 로드
- PPT 로드
- ODP 로드
- 보호된 프레젠테이션
- 대용량 프레젠테이션
- 외부 리소스
- 바이너리 객체
- C++
- Aspose.Slides
description: "C++에서 PowerPoint 및 OpenDocument 프레젠테이션을 열고, 열기 비밀번호를 제공하며, 리소스 로딩을 제어하고, Aspose.Slides for C++를 사용하여 메모리 사용량을 줄이는 방법을 배웁니다."
---
## **소개**

[Aspose.Slides for C++](https://products.aspose.com/slides/ko/cpp/)는 파일 및 스트림에서 PowerPoint 및 OpenDocument 프레젠테이션을 로드할 수 있습니다. 프레젠테이션을 로드한 후에는 구조를 검사하고, 슬라이드를 편집하고, 리소스를 관리하며, 원본 형식이나 다른 지원되는 형식으로 저장할 수 있습니다.

로드 동작은 [LoadOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides/loadoptions/) 클래스를 통해 사용자 지정할 수 있습니다. 예를 들어, 열기 비밀번호를 제공하거나, 큰 바이너리 객체를 메모리 밖에 보관하고, 외부 리소스를 제어하거나, 임베디드 바이너리 데이터를 생략할 수 있습니다.

## **프레젠테이션 열기**

기존 프레젠테이션을 열려면 파일 경로를 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 생성자에 전달합니다. 사용이 끝난 후 프레젠테이션을 Dispose하여 파일 핸들, 임시 데이터 및 기타 리소스가 즉시 해제되도록 합니다.

다음 C++ 예제는 프레젠테이션을 열고 슬라이드 수를 가져오는 방법을 보여줍니다:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **비밀번호가 보호된 프레젠테이션 열기**

열기 비밀번호는 프레젠테이션 내용을 암호화합니다. 전체 프레젠테이션을 로드하려면 올바른 비밀번호를 [LoadOptions::set_Password](https://reference.aspose.com/slides/ko/cpp/aspose.slides/loadoptions/set_password/)에 전달하고, 옵션을 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 생성자에 전달합니다. 비밀번호가 없거나 틀리면 로드가 실패합니다.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = MakeObject<Presentation>(u"encrypted-presentation.pptx", loadOptions);

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

비밀번호 감지, 검증 및 암호화 워크플로에 대해서는 [Password-Protect Presentations](/slides/ko/cpp/password-protected-presentation/)를 참조하세요. 암호화된 프레젠테이션이 공개 문서 속성과 함께 저장된 경우, 해당 속성은 비밀번호 없이도 읽을 수 있습니다. 자세한 내용은 [Manage Presentation Properties](/slides/ko/cpp/presentation-properties/)를 보세요.

## **대용량 프레젠테이션 열기**

[LoadOptions::get_BlobManagementOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/)는 이미지, 오디오, 비디오와 같은 대용량 바이너리 객체를 Aspose.Slides가 처리하는 방식을 제어합니다. 소스 파일을 잠금 유지하거나, 임시 파일을 허용하고, 메모리에 유지되는 BLOB 데이터 양을 제한할 수 있습니다.

다음 C++ 코드는 대용량 프레젠테이션(예: 2 GB)을 로드하는 예시를 보여줍니다:

```cpp
#include <DOM/ISlide.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IBlobManagementOptions.h>
#include <PresentationLockingBehavior.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

const String filePath = u"large-presentation.pptx";

auto loadOptions = MakeObject<LoadOptions>();
auto blobOptions = loadOptions->get_BlobManagementOptions();
blobOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobOptions->set_IsTemporaryFilesAllowed(true);
blobOptions->set_MaxBlobsBytesInMemory(10 * 1024 * 1024);

auto presentation = MakeObject<Presentation>(filePath, loadOptions);

presentation->get_Slide(0)->set_Name(u"Large presentation");
presentation->Save(u"large-presentation-copy.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
`PresentationLockingBehavior::KeepLocked`을 사용하면, 소스 파일이 `Presentation` 객체가 해제될 때까지 잠긴 상태로 유지됩니다. 해당 객체가 살아 있는 동안 소스 파일을 이동, 덮어쓰기 또는 삭제하지 않으세요.

Aspose.Slides는 로드 중에 입력 스트림의 내용을 복사할 수 있습니다. 큰 프레젠테이션의 경우 파일 경로가 일반적으로 스트림보다 더 효율적입니다. 추가 저장 및 메모리 관리 옵션은 [Manage BLOBs](/slides/ko/cpp/manage-blob/)를 참고하세요.
{{% /alert %}}

## **외부 리소스 제어**

[LoadOptions::set_ResourceLoadingCallback](https://reference.aspose.com/slides/ko/cpp/aspose.slides/loadoptions/set_resourceloadingcallback/)는 [IResourceLoadingCallback](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iresourceloadingcallback/) 구현을 받아들입니다. 콜백을 통해 교체 데이터를 제공하거나, 리소스를 리디렉션하거나, 기본 로더를 사용하거나, 리소스를 건너뛸 수 있습니다. 이는 프레젠테이션에 외부 이미지가 포함되어 있고 애플리케이션별 보안 또는 저장 규칙에 따라 해결해야 할 때 유용합니다.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IResourceLoadingArgs.h>
#include <IResourceLoadingCallback.h>
#include <ResourceLoadingAction.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

class ImageLoadingHandler : public IResourceLoadingCallback
{
public:
    ResourceLoadingAction ResourceLoading(SharedPtr<IResourceLoadingArgs> args) override
    {
        auto isJpeg = args->get_OriginalUri().EndsWith(u".jpg", StringComparison::OrdinalIgnoreCase);
        if (!isJpeg || !File::Exists(u"approved-image.jpg"))
        {
            return ResourceLoadingAction::Skip;
        }

        auto imageData = File::ReadAllBytes(u"approved-image.jpg");
        args->SetData(imageData);
        return ResourceLoadingAction::UserProvided;
    }
};

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_ResourceLoadingCallback(MakeObject<ImageLoadingHandler>());

auto presentation = MakeObject<Presentation>(u"presentation-with-external-images.pptx", loadOptions);
Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **임베디드 바이너리 객체 없이 프레젠테이션 로드**

프레젠테이션에 포함된 바이너리 데이터 중 애플리케이션에서 필요 없거나 보관하고 싶지 않은 경우가 있습니다. 예시:

- VBA 프로젝트는 [IPresentation::get_VbaProject](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentation/get_vbaproject/)를 통해 접근할 수 있습니다;
- 임베디드 OLE 데이터는 [IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/)를 통해 접근할 수 있습니다;
- ActiveX 컨트롤 데이터는 [IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/ko/cpp/aspose.slides/icontrol/get_activexcontrolbinary/)를 통해 접근할 수 있습니다.

로드 중에 이 바이너리 데이터를 제거하려면 [LoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/ko/cpp/aspose.slides/loadoptions/set_deleteembeddedbinaryobjects/)에 `true`를 전달합니다. 로드된 프레젠테이션을 저장하여 정화된 결과를 지속하십시오.

이 옵션은 원하지 않는 임베디드 페이로드 노출을 감소시키지만, 완전한 악성코드 탐지 또는 콘텐츠 정화 시스템은 아닙니다.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_DeleteEmbeddedBinaryObjects(true);

auto presentation = MakeObject<Presentation>(u"presentation-with-embedded-data.pptx", loadOptions);

presentation->Save(u"presentation-without-embedded-data.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **FAQ**

**파일이 손상되어 열 수 없는지 어떻게 알 수 있나요?**

Aspose.Slides는 로드 중에 구문 분석 또는 형식 예외를 발생시킵니다. 잘못된 비밀번호 오류와는 별도로 이 실패를 처리하여 애플리케이션이 원인을 정확히 보고할 수 있도록 합니다.

**필수 글꼴이 누락된 경우 어떻게 되나요?**

프레젠테이션은 계속 로드될 수 있지만, 렌더링 및 내보내기 시 글꼴이 대체될 수 있습니다. 출력 결과를 보다 예측 가능하게 만들려면 [글꼴 대체 구성](/slides/ko/cpp/font-substitution/)이나 [맞춤 글꼴 제공](/slides/ko/cpp/custom-font/)을 사용하십시오.

**프레젠테이션을 로드하면 임베디드 미디어도 로드되나요?**

임베디드 오디오와 비디오는 프레젠테이션 객체 모델을 통해 사용할 수 있게 됩니다. 외부 리소스는 구성된 리소스 로딩 동작에 따라 해결되며, 위치에 접근할 수 없을 경우 사용할 수 없을 수 있습니다.