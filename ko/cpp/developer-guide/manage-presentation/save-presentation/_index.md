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
- 썸네일 새로 고침
- 저장 진행률
- C++
- Aspose.Slides
description: "Aspose.Slides를 사용하여 C++에서 프레젠테이션을 저장하는 방법을 알아보세요—레이아웃, 글꼴 및 효과를 보존하면서 PowerPoint 또는 OpenDocument로 내보낼 수 있습니다."
---
## **개요**

[Open Presentations in C++](/slides/ko/cpp/open-presentation/)에서는 프레젠테이션을 열기 위해 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스를 사용하는 방법을 설명했습니다. 이 문서는 프레젠테이션을 만들고 저장하는 방법을 설명합니다. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스는 프레젠테이션의 내용을 포함합니다. 처음부터 프레젠테이션을 만들든 기존 프레젠테이션을 수정하든 완료 후 저장해야 합니다. Aspose.Slides for C++를 사용하면 **파일**이나 **스트림**에 저장할 수 있습니다. 이 문서에서는 프레젠테이션을 저장하는 다양한 방법을 설명합니다.

## **파일에 프레젠테이션 저장**

프레젠테이션을 파일에 저장하려면 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 `Save` 메서드를 호출합니다. 메서드에 파일 이름과 저장 형식을 전달합니다. 다음 예제는 Aspose.Slides를 사용하여 프레젠테이션을 저장하는 방법을 보여줍니다.

```cpp
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
auto presentation = MakeObject<Presentation>();

// 여기서 작업을 수행합니다...

// 프레젠테이션을 파일에 저장합니다.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **스트림에 프레젠테이션 저장**

프레젠테이션을 스트림에 저장하려면 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 `Save` 메서드에 출력 스트림을 전달하면 됩니다. 프레젠테이션은 다양한 스트림 유형에 기록될 수 있습니다. 아래 예제에서는 새 프레젠테이션을 만들고 파일 스트림에 저장합니다.

```cpp
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
auto presentation = MakeObject<Presentation>();

auto fileStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

// 프레젠테이션을 스트림에 저장합니다.
presentation->Save(fileStream, SaveFormat::Pptx);

presentation->Dispose();
fileStream->Close();
```

## **미리 정의된 보기 유형으로 프레젠테이션 저장**

Aspose.Slides를 사용하면 생성된 프레젠테이션이 열릴 때 PowerPoint가 사용하는 초기 보기를 [ViewProperties](https://reference.aspose.com/slides/ko/cpp/aspose.slides/viewproperties/) 클래스를 통해 설정할 수 있습니다. [ViewType](https://reference.aspose.com/slides/ko/cpp/aspose.slides/viewtype/) 열거형의 값을 사용하여 [set_LastView](https://reference.aspose.com/slides/ko/cpp/aspose.slides/viewproperties/set_lastview/) 메서드를 호출합니다.

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);

presentation->Save(u"SlideMasterView.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Strict Office Open XML 형식으로 프레젠테이션 저장**

Aspose.Slides를 사용하면 프레젠테이션을 Strict Office Open XML 형식으로 저장할 수 있습니다. 저장 시 [PptxOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/pptxoptions/) 클래스를 사용하고 해당 클래스의 conformance 속성을 설정합니다. `Conformance.Iso29500_2008_Strict`를 설정하면 출력 파일이 Strict Office Open XML 형식으로 저장됩니다.

다음 예제는 프레젠테이션을 생성하고 Strict Office Open XML 형식으로 저장합니다.

```cpp
auto options = MakeObject<PptxOptions>();
options->set_Conformance(Conformance::Iso29500_2008_Strict);

// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
auto presentation = MakeObject<Presentation>();

// Strict Office Open XML 형식으로 프레젠테이션을 저장합니다.
presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Zip64 모드에서 Office Open XML 형식으로 프레젠테이션 저장**

Office Open XML 파일은 ZIP 아카이브이며 압축되지 않은 파일 크기, 압축된 파일 크기 및 전체 아카이브 크기에 4 GB(2^32 바이트) 제한을 두고 파일 수를 65 535(2^16‑1)개로 제한합니다. ZIP64 형식 확장은 이러한 제한을 2^64까지 확장합니다.

[IPptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/ipptxoptions/set_zip64mode/) 메서드를 사용하면 Office Open XML 파일을 저장할 때 ZIP64 형식 확장을 언제 사용할지 선택할 수 있습니다.

이 메서드는 다음 모드와 함께 사용할 수 있습니다:

- `IfNecessary`는 프레젠테이션이 위 제한을 초과할 경우에만 ZIP64 형식 확장을 사용합니다. 기본 모드입니다.
- `Never`는 ZIP64 형식 확장을 사용하지 않습니다.
- `Always`는 항상 ZIP64 형식 확장을 사용합니다.

다음 코드는 ZIP64 형식 확장을 활성화하여 PPTX로 프레젠테이션을 저장하는 방법을 보여줍니다:

```cpp
auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_Zip64Mode(Zip64Mode::Always);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}}
`Zip64Mode.Never`로 저장하면 프레젠테이션을 ZIP32 형식으로 저장할 수 없는 경우 [PptxException](https://reference.aspose.com/slides/ko/cpp/aspose.slides/pptxexception/)이 발생합니다.
{{% /alert %}}

## **썸네일을 새로 고치지 않고 프레젠테이션 저장**

[PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) 메서드는 PPTX로 저장할 때 썸네일 생성 방식을 제어합니다:

- `true`로 설정하면 저장 과정에서 썸네일이 새로 고쳐집니다. 기본값입니다.
- `false`로 설정하면 현재 썸네일이 그대로 유지됩니다. 프레젠테이션에 썸네일이 없으면 새로 생성되지 않습니다.

아래 코드에서는 썸네일을 새로 고치지 않고 PPTX로 프레젠테이션을 저장합니다.

```cpp
auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_RefreshThumbnail(false);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
이 옵션은 PPTX 형식으로 프레젠테이션을 저장하는 데 소요되는 시간을 줄이는 데 도움이 됩니다.
{{% /alert %}}

## **백분율로 저장 진행 상황 업데이트**

[IProgressCallback](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iprogresscallback/) 인터페이스는 [ISaveOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/isaveoptions/) 인터페이스와 추상 [SaveOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/saveoptions/) 클래스가 노출하는 `set_ProgressCallback` 메서드를 통해 사용됩니다. `set_ProgressCallback`에 [IProgressCallback](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iprogresscallback/) 구현을 지정하면 저장 진행률을 백분율로 받을 수 있습니다.

다음 코드는 `IProgressCallback`을 사용하는 방법을 보여줍니다.

```cpp
class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue)
    {
        // 여기에서 진행률 백분율 값을 사용합니다.
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};
```
```cpp
auto saveOptions = MakeObject<PdfOptions>();
saveOptions->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, saveOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Aspose는 자체 API를 사용하여 만든 [무료 PowerPoint Splitter 앱](https://products.aspose.app/slides/ko/splitter)을 제공하고 있습니다. 이 앱을 사용하면 선택한 슬라이드를 새로운 PPTX 또는 PPT 파일로 저장하여 프레젠테이션을 여러 파일로 나눌 수 있습니다.
{{% /alert %}}

## **FAQ**

**“빠른 저장”(증분 저장)이 지원되어 변경된 부분만 기록되나요?**

아닙니다. 저장할 때마다 전체 대상 파일이 새로 만들어지며, 증분 “빠른 저장”은 지원되지 않습니다.

**동일한 Presentation 인스턴스를 여러 스레드에서 동시에 저장해도 안전한가요?**

아닙니다. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 인스턴스는 **스레드 안전하지 않으므로** 한 스레드에서만 저장해야 합니다.

**저장 시 하이퍼링크와 외부 연결 파일은 어떻게 처리되나요?**

[Hyperlinks](/slides/ko/cpp/manage-hyperlinks/)는 그대로 유지됩니다. 외부 연결 파일(예: 상대 경로를 사용하는 비디오)은 자동으로 복사되지 않으므로, 참조된 경로가 그대로 접근 가능하도록 해야 합니다.

**문서 메타데이터(작성자, 제목, 회사, 날짜 등)를 설정/저장할 수 있나요?**

예. 표준 [문서 속성](/slides/ko/cpp/presentation-properties/)을 지원하며 저장 시 파일에 기록됩니다.