---
title: C++에서 PowerPoint 프레젠테이션을 Markdown으로 변환
linktitle: PowerPoint를 Markdown으로
type: docs
weight: 140
url: /ko/cpp/convert-powerpoint-to-markdown/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPTX 변환
- PowerPoint를 MD로
- 프레젠테이션을 MD로
- 슬라이드를 MD로
- PPT를 MD로
- PPTX를 MD로
- PowerPoint를 Markdown으로 저장
- 프레젠테이션을 Markdown으로 저장
- 슬라이드를 Markdown으로 저장
- PPT를 MD로 저장
- PPTX를 MD로 저장
- PPT를 MD로 내보내기
- PPTX를 MD로 내보내기
- PowerPoint
- 프레젠테이션
- Markdown
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 슬라이드(PPT, PPTX)를 깔끔한 Markdown으로 변환하고, 문서화를 자동화하며 서식을 유지합니다."
---
## **소개**

Aspose.Slides를 사용하면 PowerPoint 프레젠테이션을 Markdown으로 변환할 수 있으며, 이는 문서 작업 흐름, 정적 사이트 생성, 콘텐츠 마이그레이션 및 버전 관리된 텍스트 게시에 유용합니다. API는 PPT 및 PPTX 프레젠테이션을 MD 파일로 직접 내보내는 것을 지원하며, 결과 Markdown 문서에서 슬라이드 내용이 어떻게 표시될지 제어하는 추가 옵션을 제공합니다.

프레젠테이션을 일반 Markdown으로 내보낼 수 있고, CommonMark 및 GitHub Flavored Markdown과 같은 여러 Markdown 변형 중에서 선택할 수 있으며, 내보내기 중 이미지 처리 방식을 구성할 수 있습니다. 시각적 콘텐츠가 포함된 프레젠테이션의 경우, Aspose.Slides는 이미지를 별도 폴더에 저장하고 생성된 Markdown 파일에서 해당 이미지를 참조하도록 할 수 있습니다.

{{% alert color="warning" %}} 

PowerPoint를 Markdown으로 내보낼 때 기본적으로 **이미지 없이** 내보냅니다. 이미지가 포함된 PowerPoint 문서를 내보내려면 `SaveOptions::MarkdownExportType::Visual)`를 설정하고, Markdown 문서에서 참조되는 이미지가 저장될 `BasePath`도 지정해야 합니다.

{{% /alert %}} 

## **PowerPoint를 Markdown으로 변환**

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스를 인스턴스화하여 프레젠테이션 객체를 나타냅니다.  
2. [Save ](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/save/#presentationsavesystemsharedptrexportxamlixamloptions-method) 메서드를 사용하여 객체를 markdown 파일로 저장합니다.

다음 C++ 코드는 PowerPoint를 markdown으로 변환하는 방법을 보여줍니다:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.md", SaveFormat::Md);
```

## **PowerPoint를 다양한 Markdown 변형으로 변환**

Aspose.Slides를 사용하면 PowerPoint를 기본 구문을 포함한 markdown, CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab 및 기타 17개의 markdown 변형으로 변환할 수 있습니다.

다음 C++ 코드는 PowerPoint를 CommonMark로 변환하는 방법을 보여줍니다: 

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_Flavor(Aspose::Slides::DOM::Export::Markdown::SaveOptions::Flavor::CommonMark);
pres->Save(u"pres.md", Aspose::Slides::Export::SaveFormat::Md, opt);
```

지원되는 23개의 markdown 변형은 [MarkdownSaveOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) 클래스의 [Flavor 열거형](https://reference.aspose.com/slides/ko/cpp/aspose.slides.dom.export.markdown.saveoptions/flavor/)에 나열되어 있습니다.

## **이미지가 포함된 프레젠테이션을 Markdown으로 변환**

[MarkdownSaveOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) 클래스는 결과 markdown 파일에 사용할 수 있는 속성 및 열거형을 제공합니다. 예를 들어 [MarkdownExportType](https://reference.aspose.com/slides/ko/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) 열거형은 이미지가 렌더링되거나 처리되는 방식을 결정하는 `Sequential`, `TextOnly`, `Visual` 값으로 설정할 수 있습니다.

### **이미지를 순차적으로 변환**

결과 markdown에서 이미지가 하나씩 순차적으로 표시되길 원한다면 sequential 옵션을 선택해야 합니다. 다음 C++ 코드는 이미지가 포함된 프레젠테이션을 markdown으로 변환하는 방법을 보여줍니다:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<MarkdownSaveOptions> markdownSaveOptions = System::MakeObject<MarkdownSaveOptions>();

markdownSaveOptions->set_ShowHiddenSlides(true);
markdownSaveOptions->set_ShowSlideNumber(true);
markdownSaveOptions->set_Flavor(Flavor::Github);
markdownSaveOptions->set_ExportType(MarkdownExportType::Sequential);
markdownSaveOptions->set_NewLineType(NewLineType::Windows);

pres->Save(u"doc.md", System::MakeArray<int32_t>({1, 2, 3, 4, 5, 6, 7, 8, 9}), SaveFormat::Md, markdownSaveOptions);
```

### **이미지를 시각적으로 변환**

결과 markdown에서 이미지가 함께 표시되길 원한다면 visual 옵션을 선택해야 합니다. 이 경우, 이미지는 애플리케이션 현재 디렉터리에 저장되며 (markdown 문서에서 상대 경로가 생성됩니다), 또는 원하는 경로와 폴더 이름을 지정할 수 있습니다.

다음 C++ 코드는 해당 작업을 보여줍니다: 

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
const System::String outPath = u"x:\\documents";
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_ExportType(Aspose::Slides::DOM::Export::Markdown::SaveOptions::MarkdownExportType::Visual);
opt->set_ImagesSaveFolderName(u"md-images");
opt->set_BasePath(outPath);
pres->Save(System::IO::Path::Combine(outPath, u"pres.md"), Aspose::Slides::Export::SaveFormat::Md, opt);
```

## **FAQ**

**하이퍼링크가 Markdown으로 내보낼 때 유지되나요?**

예. 텍스트 [hyperlinks](/slides/ko/cpp/manage-hyperlinks/)는 표준 Markdown 링크로 보존됩니다. 슬라이드 [transitions](/slides/ko/cpp/slide-transition/) 및 [animations](/slides/ko/cpp/powerpoint-animation/)는 변환되지 않습니다.

**다중 스레드로 실행하여 변환 속도를 높일 수 있나요?**

파일 단위로 병렬 처리할 수 있지만, 스레드 간에 동일한 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 인스턴스를 [공유하지](/slides/ko/cpp/multithreading/) 않아야 합니다. 파일당 별도의 인스턴스나 프로세스를 사용하여 경쟁을 피하세요.

**이미지는 어떻게 처리되나요—어디에 저장되며 경로는 상대 경로인가요?**

[Images](/slides/ko/cpp/image/)는 전용 폴더에 내보내지며, Markdown 파일은 기본적으로 상대 경로로 이미지를 참조합니다. 기본 출력 경로와 에셋 폴더 이름을 구성하여 예측 가능한 저장소 구조를 유지할 수 있습니다.