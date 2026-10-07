---
title: 시작하기
type: docs
weight: 10
url: /ko/net/getting-started/
keywords:
- 시작하기
- 시스템 요구 사항
- 설치
- 첫 프레젠테이션
- NuGet
- PPT 처리
- PPTX 처리
- ODP 처리
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "새 .NET 프로젝트에서 Aspose.Slides를 사용해 첫 번째 저장된 프레젠테이션까지의 과정: 요구 사항을 확인하고, 패키지를 설치하며, 첫 프로그램을 실행하고, 일반 작업을 계속합니다."
---
## **개요**

아래 네 단계 순서대로 진행하십시오. 각 단계는 수행할 작업을 명시하고 자세한 내용이 포함된 문서에 연결됩니다. 평가, 라이선스 및 지원은 단계 이후에 다룹니다.

## **단계 1: 시스템 요구 사항 확인**

[Aspose.Slides for .NET](https://products.aspose.com/slides/net/)는 Windows, Linux 및 macOS에서 실행됩니다. [시스템 요구 사항](/slides/ko/net/system-requirements/)에는 각 패키지가 지원하는 운영 체제와 .NET 버전, 그리고 Linux에서 추가로 필요한 라이브러리가 나열되어 있습니다.

## **단계 2: 패키지 설치**

Aspose.Slides for .NET는 NuGet을 통해 동일한 클래스를 제공하는 두 패키지로 배포됩니다. 그 중 하나를 프로젝트에 추가합니다:

- Windows에서: `dotnet add package Aspose.Slides.NET`
- Linux 및 macOS에서: `dotnet add package Aspose.Slides.NET6.CrossPlatform`. Linux에서는 먼저 `fontconfig` 라이브러리를 설치하십시오.
- Alpine Linux 및 glibc 버전이 2.23(x64) 또는 2.39(ARM64)보다 낮은 Linux 시스템에서는: `libgdiplus` 라이브러리를 설치한 상태에서 Aspose.Slides.NET을 사용합니다.

[설치](/slides/ko/net/installation/)에서는 Linux 명령어, Linux에서 Aspose.Slides.NET이 필요로 하는 추가 시작 설정, 그리고 Visual Studio용 단계들을 제공합니다.

## **단계 3: 첫 프레젠테이션 만들기**

[Aspose.Slides for .NET 홈페이지의 빠른 시작](/slides/ko/net/#your-first-presentation) 페이지는 전체 콘솔 프로그램 예제입니다: 슬라이드에 텍스트 상자를 추가하고 프레젠테이션을 PPTX 파일로 저장합니다. [프레젠테이션 만들기](/slides/ko/net/create-presentation/)에서는 동일한 단계를 더 자세히 설명하고 기존 프레젠테이션을 열어 다른 형식으로 저장하는 방법을 보여줍니다.

## **단계 4: 일반 작업 계속하기**

- [프레젠테이션 열기](/slides/ko/net/open-presentation/)
- [프레젠테이션 저장](/slides/ko/net/save-presentation/)
- [프레젠테이션을 PDF로 변환](/slides/ko/net/convert-powerpoint-to-pdf/)
- [슬라이드를 이미지로 렌더링](/slides/ko/net/convert-slide/)
- [프레젠테이션 텍스트 편집](/slides/ko/net/manage-text/)
- [슬라이드 요소별 예제](/slides/ko/net/examples/)

## **평가 및 라이선스**

라이선스가 없으면 Aspose.Slides는 평가 모드로 실행됩니다: 저장하는 모든 슬라이드에 워터마크를 추가하고 프레젠테이션에서 읽은 텍스트를 잘라냅니다.

- [Aspose.Slides 평가](/slides/ko/net/evaluate-aspose-slides/) 평가 제한 사항과 임시 라이선스를 요청하는 방법을 설명합니다.
- [라이선스](/slides/ko/net/licensing/) 파일, 스트림 또는 포함된 리소스에서 라이선스를 적용하는 방법을 보여줍니다.
- [사용량 기반 라이선스](/slides/ko/net/metered-licensing/) 사용량에 따라 청구되는 라이선스에 대해 다룹니다.
- [지원되는 파일 형식](/slides/ko/net/supported-file-formats/) Aspose.Slides가 로드하고 저장할 수 있는 형식을 나열합니다.

## **도움 받기**

[제품 지원](/slides/ko/net/product-support/)에서는 [무료 지원 포럼](https://forum.aspose.com/c/slides/11)에서 질문하는 방법과 문제를 보고할 때 포함해야 할 내용을 설명합니다.

## **FAQ**

**Microsoft PowerPoint를 설치해야 하나요?**

아니요. Aspose.Slides는 프레젠테이션 파일을 자체적으로 읽고 쓰며 PowerPoint를 사용하지 않으므로 서버 및 Linux에서도 실행됩니다.

**.NET Framework 애플리케이션에는 어떤 패키지를 사용해야 하나요?**

Aspose.Slides.NET. 여기에는 .NET Framework 4.6.2 이상, .NET 6 이상, .NET Standard 2.0용 빌드가 포함됩니다. Aspose.Slides.NET6.CrossPlatform은 .NET 6 이상이 필요합니다.