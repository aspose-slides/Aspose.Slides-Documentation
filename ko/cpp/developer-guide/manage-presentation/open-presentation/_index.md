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
description: "Aspose.Slides for C++를 사용하여 PowerPoint(.pptx, .ppt) 및 OpenDocument(.odp) 프레젠테이션을 손쉽게 엽니다—빠르고 신뢰할 수 있으며 완전한 기능을 제공합니다."
---
## **소개**

처음부터 PowerPoint 프레젠테이션을 만드는 것뿐만 아니라, Aspose.Slides는 기존 프레젠테이션을 열 수도 있습니다. 프레젠테이션을 로드한 후에는 해당 정보를 가져오고, 슬라이드 내용을 편집하고, 새 슬라이드를 추가하고, 기존 슬라이드를 제거하는 등 다양한 작업을 수행할 수 있습니다.

## **프레젠테이션 열기**

기존 프레젠테이션을 열려면, [프레젠테이션](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스를 인스턴스화하고 파일 경로를 생성자에 전달합니다.

다음 C++ 예제는 프레젠테이션을 열고 슬라이드 수를 가져오는 방법을 보여줍니다:

```cpp
// Presentation 클래스를 인스턴스화하고 파일 경로를 생성자에 전달합니다.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// 프레젠테이션의 총 슬라이드 수를 출력합니다.
Console::WriteLine(presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **비밀번호로 보호된 프레젠테이션 열기**

비밀번호로 보호된 프레젠테이션을 열어야 할 경우, [LoadOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides/loadoptions/) 클래스의 [set_Password](https://reference.aspose.com/slides/ko/cpp/aspose.slides/loadoptions/set_password/) 메서드에 비밀번호를 전달하여 복호화하고 로드합니다. 다음 C++ 코드는 이 작업을 보여줍니다:

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto presentation = MakeObject<Presentation>(u"Sample.pptx", loadOptions);
    
// 복호화된 프레젠테이션에 대한 작업을 수행합니다.

presentation->Dispose();
```

## **대용량 프레젠테이션 열기**

Aspose.Slides는 대용량 프레젠테이션을 로드하는 데 도움이 되는 옵션을 제공합니다—특히 [LoadOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides/loadoptions/) 클래스의 [get_BlobManagementOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) 메서드.

다음 C++ 코드는 대용량 프레젠테이션(예: 2GB)을 로드하는 방법을 보여줍니다:

```cpp
auto filePath = u"LargePresentation.pptx";

auto loadOptions = MakeObject<LoadOptions>();
// KeepLocked 동작을 선택합니다—프레젠테이션 파일이 인스턴스 수명 동안 잠긴 상태로 유지됩니다
// Presentation 인스턴스이지만, 메모리에 로드되거나 임시 파일로 복사될 필요는 없습니다.
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
loadOptions->get_BlobManagementOptions()->set_IsTemporaryFilesAllowed(true);
loadOptions->get_BlobManagementOptions()->set_MaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

auto presentation = MakeObject<Presentation>(filePath, loadOptions);

// 대용량 프레젠테이션이 로드되었으며, 메모리 사용량이 낮은 상태로 사용할 수 있습니다.

// 프레젠테이션을 수정합니다.
presentation->get_Slide(0)->set_Name(u"Large presentation");

// 프레젠테이션을 다른 파일에 저장합니다. 이 작업 동안 메모리 사용량이 낮게 유지됩니다.
presentation->Save(u"LargePresentation-copy.pptx", SaveFormat::Pptx);

// 이렇게 하지 마세요! 파일이 프레젠테이션 객체가 해제될 때까지 잠겨 있기 때문에 I/O 예외가 발생합니다.
File::Delete(filePath);

presentation->Dispose();

// 여기서는 수행해도 됩니다. 원본 파일이 이제 프레젠테이션 객체에 의해 잠겨 있지 않습니다.
File::Delete(filePath);
```

{{% alert color="info" title="Info" %}}
스트림을 사용할 때 특정 제한을 우회하기 위해 Aspose.Slides가 스트림의 내용을 복사할 수 있습니다. 스트림에서 대용량 프레젠테이션을 로드하면 프레젠테이션이 복사되어 로드 속도가 느려질 수 있습니다. 따라서 대용량 프레젠테이션을 로드해야 할 경우, 스트림보다 프레젠테이션 파일 경로를 사용하는 것을 강력히 권장합니다.

대용량 객체(비디오, 오디오, 고해상도 이미지 등)를 포함하는 프레젠테이션을 만들 때는 [BLOB 관리](/slides/ko/cpp/manage-blob/)를 사용하여 메모리 사용량을 줄일 수 있습니다.
{{%/alert %}}

## **외부 리소스 제어**

Aspose.Slides는 외부 리소스를 관리할 수 있는 [IResourceLoadingCallback](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iresourceloadingcallback/) 인터페이스를 제공합니다. 다음 C++ 코드는 `IResourceLoadingCallback` 인터페이스를 사용하는 방법을 보여줍니다:

```cpp
class ImageLoadingHandler : public IResourceLoadingCallback
{
public:
    ResourceLoadingAction ResourceLoading(SharedPtr<IResourceLoadingArgs> args) override
    {
        if (args->get_OriginalUri().EndsWith(u".jpg"))
        {
            try
            {
                // 대체 이미지를 로드합니다.
                auto imageData = File::ReadAllBytes(u"aspose-logo.jpg");
                args->SetData(imageData);
                return ResourceLoadingAction::UserProvided;
            }
            catch (Exception&)
            {
                return ResourceLoadingAction::Skip;
            }
        }
        else if (args->get_OriginalUri().EndsWith(u".png"))
        {
            // 대체 URL을 설정합니다.
            args->set_Uri(u"http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }

        // 다른 모든 이미지를 건너뜁니다.
        return ResourceLoadingAction::Skip;
    }
};
```

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_ResourceLoadingCallback(MakeObject<ImageLoadingHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx", loadOptions);
```

## **내장 바이너리 객체 없이 프레젠테이션 로드**

PowerPoint 프레젠테이션은 다음과 같은 유형의 내장 바이너리 객체를 포함할 수 있습니다:

- VBA 프로젝트 ([IPresentation::get_VbaProject](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentation/get_vbaproject/)를 통해 접근 가능);
- OLE 객체 내장 데이터 ([IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/)를 통해 접근 가능);
- ActiveX 컨트롤 바이너리 데이터 ([IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/ko/cpp/aspose.slides/icontrol/get_activexcontrolbinary/)를 통해 접근 가능).

[ILoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iloadoptions/set_deleteembeddedbinaryobjects/) 메서드를 사용하면 내장 바이너리 객체가 전혀 없는 상태로 프레젠테이션을 로드할 수 있습니다.

이 메서드는 잠재적으로 악성인 바이너리 내용을 제거하는 데 유용합니다. 다음 C++ 코드는 내장 바이너리 내용이 전혀 없는 프레젠테이션을 로드하는 방법을 보여줍니다:

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_DeleteEmbeddedBinaryObjects(true);

auto presentation = MakeObject<Presentation>(u"malware.ppt", loadOptions);

// 프레젠테이션에 대한 작업을 수행합니다.

presentation->Dispose();
```

## **FAQ**

**파일이 손상되어 열 수 없다는 것을 어떻게 알 수 있나요?**

로드 중에 구문 분석/포맷 검증 예외가 발생합니다. 이러한 오류는 종종 잘못된 ZIP 구조나 손상된 PowerPoint 레코드를 언급합니다.

**열 때 필수 글꼴이 없으면 어떻게 되나요?**

파일은 열리지만, 이후 [렌더링/내보내기](/slides/ko/cpp/convert-presentation/) 시 글꼴이 대체될 수 있습니다. 런타임 환경에 [글꼴 대체 구성](/slides/ko/cpp/font-substitution/) 또는 [필요한 글꼴 추가](/slides/ko/cpp/custom-font/)를 하면 됩니다.

**열 때 내장 미디어(비디오/오디오)는 어떻게 되나요?**

미디어는 프레젠테이션 리소스로 사용 가능하게 됩니다. 외부 경로를 통해 미디어가 참조되는 경우, 해당 경로가 환경에서 접근 가능하도록 해야 합니다; 그렇지 않으면 [렌더링/내보내기](/slides/ko/cpp/convert-presentation/) 시 미디어가 누락될 수 있습니다.