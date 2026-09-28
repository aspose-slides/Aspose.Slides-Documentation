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
description: ".NET 새 프로젝트에서 Aspose.Slides를 사용한 첫 프레젠테이션을 저장하기까지의 단계: 요구 사항을 확인하고, 패키지를 설치하고, 첫 프로그램을 실행하고, 일반 작업을 계속합니다."
---
## **개요**

아래 네 단계를 순서대로 진행하십시오. 각 단계는 수행할 작업을 명시하고 자세한 내용이 있는 기사에 링크합니다. 평가, 라이선스 및 지원은 단계 이후에 다룹니다.

## **1단계: 시스템 요구 사항 확인**

Aspose.Slides for .NET은 Windows, Linux 및 macOS에서 실행됩니다. [System Requirements](/slides/ko/net/system-requirements/)에 각 패키지가 지원하는 운영 체제와 .NET 버전, Linux에 추가로 필요한 라이브러리가 나와 있습니다.

## **2단계: 패키지 설치**

Aspose.Slides for .NET은 동일한 클래스를 제공하는 두 개의 NuGet 패키지로 배포됩니다. 프로젝트에 하나를 추가하십시오:

- Windows: `dotnet add package Aspose.Slides.NET`
- Linux 및 macOS: `dotnet add package Aspose.Slides.NET6.CrossPlatform`. Linux에서는 먼저 `fontconfig` 라이브러리를 설치합니다.
- Alpine Linux 및 glibc 버전이 2.23 미만(x64) 또는 2.39 미만(ARM64)인 Linux 시스템: `libgdiplus` 라이브러리를 설치한 후 Aspose.Slides.NET 사용.

[Installation](/slides/ko/net/installation/)에 Linux 명령, Linux에서 Aspose.Slides.NET에 필요한 추가 시작 설정 및 Visual Studio용 단계가 설명되어 있습니다.

## **3단계: 첫 프레젠테이션 만들기**

[Aspose.Slides for .NET 홈페이지의 빠른 시작](/slides/ko/net/#your-first-presentation)은 전체 콘솔 프로그램 예시입니다. 슬라이드에 텍스트 상자를 추가하고 프레젠테이션을 PPTX 파일로 저장합니다. [Create Presentations](/slides/ko/net/create-presentation/)에서는 동일한 단계를 더 자세히 설명하고 기존 프레젠테이션을 열어 다른 형식으로 저장하는 방법을 보여줍니다.

## **4단계: 일반 작업 계속하기**

- [프레젠테이션 열기](/slides/ko/net/open-presentation/)
- [프레젠테이션 저장](/slides/ko/net/save-presentation/)
- [프레젠테이션을 PDF로 변환](/slides/ko/net/convert-powerpoint-to-pdf/)
- [슬라이드를 이미지로 렌더링](/slides/ko/net/convert-slide/)
- [프레젠테이션 텍스트 편집](/slides/ko/net/manage-text/)
- [슬라이드 요소별 예제](/slides/ko/net/examples/)

## **평가 및 라이선스**

라이선스가 없으면 Aspose.Slides는 평가 모드로 동작합니다. 저장하는 모든 슬라이드에 워터마크가 추가되고 프레젠테이션에서 읽은 텍스트가 잘립니다.

- [Aspose.Slides 평가](/slides/ko/net/evaluate-aspose-slides/)에서는 평가 제한 사항과 임시 라이선스 요청 방법을 설명합니다.
- [Licensing](/slides/ko/net/licensing/)에서는 파일, 스트림 또는 임베디드 리소스로 라이선스를 적용하는 방법을 보여줍니다.
- [Metered Licensing](/slides/ko/net/metered-licensing/)에서는 사용량 기반 과금 라이선스를 다룹니다.
- [Supported File Formats](/slides/ko/net/supported-file-formats/)에는 Aspose.Slides가 로드·저장할 수 있는 형식이 나와 있습니다.

## **도움받기**

[Product Support](/slides/ko/net/product-support/)에서는 [무료 지원 포럼](https://forum.aspose.com/c/slides/ko/11)에서 질문하는 방법과 문제를 보고할 때 포함해야 할 내용을 설명합니다.

## **FAQ**

**Microsoft PowerPoint를 설치해야 하나요?**

아니요. Aspose.Slides는 자체적으로 프레젠테이션 파일을 읽고 쓰며 PowerPoint를 사용하지 않으므로 서버 및 Linux에서도 실행됩니다.

**.NET Framework 애플리케이션에 어떤 패키지를 사용해야 하나요?**

Aspose.Slides.NET을 사용하십시오. 이 패키지는 .NET Framework 4.6.2 이상, .NET 6 이상, .NET Standard 2.0을 위한 빌드를 포함합니다. Aspose.Slides.NET6.CrossPlatform은 .NET 6 이상이 필요합니다.