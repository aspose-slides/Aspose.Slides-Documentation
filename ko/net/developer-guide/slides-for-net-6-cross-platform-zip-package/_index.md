---
title: Aspose.Slides for .NET 6 크로스 플랫폼 (ZIP 패키지)
type: docs
weight: 237
url: /ko/net/slides-for-net-6-cross-platform-zip-package/
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
- extern 별칭
- CS0433
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET 6을 사용하여 Windows, Linux, macOS에서 크로스 플랫폼 C# 애플리케이션을 구축하고 PowerPoint PPT, PPTX 및 ODP 파일을 생성, 편집 및 변환합니다."
---
## **개요**

이 문서에서는 ZIP 패키지에서 Aspose.Slides for .NET 6 Cross-Platform을 사용하는 방법을 설명합니다. 패키지를 다운로드하고, `net6.0/crossplatform` 폴더에서 파일을 풀어내고, `Aspose.Slides.dll`에 대한 참조를 추가하고, 필요한 종속 라이브러리가 애플리케이션 출력 디렉터리로 복사되도록 프로젝트 파일을 구성하는 방법을 설명합니다.

또한 이 문서는 메인 Aspose.Slides .NET 어셈블리와 Windows, Linux, macOS용 플랫폼별 그래픽 서브시스템 라이브러리를 포함한 크로스 플랫폼 패키지의 내용을 설명합니다.

{{% alert title="Note" color="primary" %}}
Aspose.Slides for .NET 6 Cross-Platform은 또한 [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)에서 사용할 수 있습니다.
{{% /alert %}}

## **ZIP 패키지에서 크로스 플랫폼 Aspose.Slides 사용**

1. 최신 Aspose.Slides의 ZIP 패키지를 [Release Page](https://releases.aspose.com/slides/ko/net/)에서 다운로드합니다. 

2. *Aspose.Slides.zip\Aspose.Slides\net6.0\crossplatform*에서 파일을 풀어내어 프로젝트에서 종속성으로 사용할 폴더에 배치합니다.

3. Aspose.Slides.dll에 대한 참조를 추가합니다.

   ![add-project-reference-visual-studio](add-project-reference-visual-studio.png)

   우리 예제(아래)에서는 라이브러리가 프로젝트 폴더의 다음 경로에 위치합니다: *ConsoleApp\libs\Aspose.Slides\net6.0\crossplatform\...*

   ![browse-console-app](browse-console-app.jpg)

4. 다음과 같이 csproj 프로젝트 파일에 지시문을 추가하여 나머지 파일(Aspose.Slides가 의존하는 파일)을 출력 디렉터리에 배치합니다:

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

   기본적으로 `<CopyToOutputDirectory>`는 파일을 상대 경로를 유지한 채 복사하지만, 종속 라이브러리를 출력이 생성되는 동일한 폴더(Aspose.Slides.dll 위치)로 이동시켜야 합니다.

## **참고 사항**

### **독점 그래픽 서브시스템**

| Aspose.Slides.dll                                          | Aspose.Slides 로직 전체를 담당하는 주요 .NET 어셈블리 |
| ---------------------------------------------------------- | ------------------------------------------------------ |
| aspose.slides.drawing.capi_vc14x64.dll                     | 종속성: Win x64용 그래픽 서브시스템 구현                |
| aspose.slides.drawing.capi_vc14x86.dll                     | 종속성: Win x64용 그래픽 서브시스템 구현                |
| libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so | 종속성: Linux용 그래픽 서브시스템 구현 (x86/x64)       |
| libaspose.slides.drawing.capi_appleclang_x86_64.dylib      | 종속성: macOS AMD64용 그래픽 서브시스템 구현 (x86-64/x64) |
| libaspose.slides.drawing.capi_appleclang_arm64.dylib       | 종속성: macOS ARM64용 그래픽 서브시스템 구현 (AArch64) |

Aspose.Slides.dll은 실행 중인 시스템이 요구하는 라이브러리를 사용합니다. 라이브러리는 일반적으로 Aspose.Slides.dll과 동일한 위치에 있습니다.

### **ZIP 패키지 구조**

ZIP 패키지는 다음과 같은 폴더 구조를 포함합니다:

  Aspose.Slides

  ├─── net6.0

  │  ├─── crossplatform

  │  └─── default

  ├─── net20

  ├─── net462

  └─── netstandard2.0

* 각 폴더에는 해당 .NET 버전에 맞는 어셈블리가 포함되어 있습니다. net6.0에는 두 가지 버전이 있습니다: default와 crossplatform. 후자는 크로스 플랫폼 Aspose.Slides.dll 및 모든 종속성을 포함합니다. 이 폴더의 압축 해제된 내용은 크로스 플랫폼 개발 및 기타 Aspose.Slides 사용 사례를 위한 프로젝트에 종속성으로 추가할 수 있습니다.

## **관련 항목**

- [시스템 요구 사항](/slides/ko/net/system-requirements/)