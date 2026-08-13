---
title: Aspose.Slides for .NET 6 크로스 플랫폼 (ZIP 패키지)
type: docs
weight: 237
url: /ko/net/slides-for-net-6-cross-platform-zip-package/
aliases:
  - /net/slides-for-net-6-cross-platform/
keywords:
- 크로스 플랫폼
- .NET 6
- GLIBC
- csproj
- 대상 경로
- 종속 라이브러리
- Aspose.Slides.dll
- System.Drawing.Common
- 이름 충돌
- 외부 별칭
- CS0433
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET 6을 사용하여 Windows, Linux 및 macOS에서 C# 크로스 플랫폼 앱을 빌드하고 PowerPoint PPT, PPTX 및 ODP 파일을 생성, 편집 및 변환합니다."
---
## **개요**

이 문서는 ZIP 패키지에서 .NET 6 크로스 플랫폼용 Aspose.Slides를 사용하는 방법을 설명합니다. 패키지를 다운로드하고 `net6.0/crossplatform` 폴더에서 파일을 풀어 `Aspose.Slides.dll`에 대한 참조를 추가하며, 필수 종속 라이브러리가 애플리케이션 출력 디렉터리로 복사되도록 프로젝트 파일을 구성하는 방법을 설명합니다.

또한 크로스 플랫폼 패키지의 내용물, 즉 메인 Aspose.Slides .NET 어셈블리와 Windows, Linux, macOS용 플랫폼 별 그래픽 서브시스템 라이브러리를 소개합니다.

{{% alert title="Note" color="info" %}}

Aspose.Slides for .NET 6 Cross-Platform은 [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)에서도 사용할 수 있습니다.

{{% /alert %}}

## **ZIP 패키지에서 크로스 플랫폼 Aspose.Slides 사용하기**

1. 최신 Aspose.Slides의 ZIP 패키지를 [Release Page](https://releases.aspose.com/slides/ko/net/)에서 다운로드합니다. 

2. *Aspose.Slides.zip\Aspose.Slides\net6.0\crossplatform* 에서 파일을 풀어 프로젝트에서 종속성으로 사용할 폴더에 배치합니다.

3. Aspose.Slides.dll에 대한 참조를 추가합니다.

   ![add-project-reference-visual-studio](add-project-reference-visual-studio.png)

   우리 예제(아래)에서는 라이브러리가 프로젝트 폴더의 다음 경로에 위치합니다: *ConsoleApp\libs\Aspose.Slides\net6.0\crossplatform\...*

   ![browse-console-app](browse-console-app.jpg)

4. 남은 파일(Aspose.Slides가 의존하는 파일)을 csproj 프로젝트 파일에 다음과 같이 지시하여 출력 디렉터리에 배치합니다:

```xml
<ItemGroup>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\aspose.slides.drawing.capi_vc14x64.dll">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>aspose.slides.drawing.capi_vc14x64.dll</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\aspose.slides.drawing.capi_vc14x86.dll">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>aspose.slides.drawing.capi_vc14x86.dll</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\Aspose.Slides.xml">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>Aspose.Slides.xml</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_appleclang_x86_64.dylib">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>libaspose.slides.drawing.capi_appleclang_x86_64.dylib</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_appleclang_arm64.dylib">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>libaspose.slides.drawing.capi_appleclang_arm64.dylib</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so</TargetPath>
   </None>

</ItemGroup>
```

5. `TargetPath`에 주의하십시오. 

   기본적으로 `<CopyToOutputDirectory>`는 파일을 상대 경로를 유지한 채 복사하지만, 우리는 종속 라이브러리가 출력이 생성되는 동일한 폴더(Aspose.Slides.dll 위치)로 이동하도록 해야 합니다.

## **참고 사항**

### **독점 그래픽 서브시스템**

Aspose.Slides cross-platform은 다음과 같은 라이브러리 모음입니다:

| Aspose.Slides.dll                                          | Aspose.Slides 모든 로직을 담당하는 메인 .NET 어셈블리                 |
| ---------------------------------------------------------- | -------------------------------------------------------------------------- |
| aspose.slides.drawing.capi_vc14x64.dll                     | 종속성: Windows x64용 그래픽 서브시스템 구현                  |
| aspose.slides.drawing.capi_vc14x86.dll                     | 종속성: Windows x64용 그래픽 서브시스템 구현                  |
| libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so | 종속성: Linux용 그래픽 서브시스템 구현 (x86/x64)          |
| libaspose.slides.drawing.capi_appleclang_x86_64.dylib      | 종속성: macOS AMD64(x86-64/x64)용 그래픽 서브시스템 구현 |
| libaspose.slides.drawing.capi_appleclang_arm64.dylib       | 종속성: macOS ARM64(AArch64)용 그래픽 서브시스템 구현    |

Aspose.Slides.dll은 실행 중인 시스템이 요구하는 라이브러리를 사용합니다. 이러한 라이브러리는 일반적으로 파일 시스템에서 Aspose.Slides.dll과 동일한 위치에 있습니다.

### **ZIP 패키지 구조**

ZIP 패키지는 다음과 같은 폴더 구조를 포함합니다:

  Aspose.Slides

  ├─── net6.0

  │  ├─── crossplatform

  │  └─── default

  ├─── net20

  ├─── net462

  └─── netstandard2.0

* 각 폴더에는 해당 .NET 버전에 대한 어셈블리가 포함됩니다. net6.0에는 default와 crossplatform 두 가지 버전이 있습니다. 후자는 크로스 플랫폼 Aspose.Slides.dll 및 모든 종속성을 포함합니다. 이 폴더의 풀어낸 내용은 크로스 플랫폼 개발 및 기타 Aspose.Slides 사용 사례에서 프로젝트의 종속성 추가로 사용할 수 있습니다.

## **관련 항목**

- [시스템 요구 사항](/slides/ko/net/system-requirements/)