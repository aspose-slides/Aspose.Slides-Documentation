---
title: 보안
type: docs
weight: 160
url: /ko/net/security/
keywords:
- 보안
- 종속성
- 제3자 구성 요소
- NuGet
- 취약점 스캔
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET이 프레젠테이션을 처리하는 방식, 각 대상 프레임워크에 대해 의존하는 NuGet 패키지 및 포함하는 제3자 구성 요소를 검토합니다."
---
## **Aspose.Slides 보안**

Aspose는 제품 개발 시 모범 사례를 적용합니다.

* Aspose.Slides for .NET은 프레젠테이션을 조작하고 다른 형식으로 변환하는데 사용됩니다. 프레젠테이션 내의 스크립트를 실행하지 않습니다. Aspose.Slides는 프레젠테이션 구조를 구문 분석하고 최종 사용자의 코드가 객체 모델을 편리하게 조작할 수 있도록 합니다.
* Aspose.Slides는 원격 코드를 실행하지 않고 문서를 구문 분석하고 해석하는 라이브러리로 동작합니다. 모든 Aspose 제품은 사용자의 컴퓨터에서 실행됩니다. Aspose에 데이터를 전송하지 않습니다. 유일한 예외는 [metered license](https://purchase.aspose.com/faqs/licensing/metered)이며, 이를 사용하는 경우 API 사용 정보만 처리됩니다.
* Aspose 구성 요소는 일반 애플리케이션과 동일한 사용자 컨텍스트에서 실행됩니다. 따라서 Aspose 구성 요소가 중요한 시스템 리소스에 위험을 초래하지 않습니다. 또한 Aspose 구성 요소가 문서를 열 때 매크로가 자동으로 실행되지 않습니다.
* Microsoft Office 패키지와 관련된 위험은 Aspose 구성 요소에 적용되지 않으며, 따라서 Aspose 제품은 매우 안전합니다.

## **NuGet 종속성**

Aspose.Slides for .NET은 Microsoft가 NuGet에 게시하는 패키지에 의존합니다. 종속성은 패키지 및 대상 프레임워크에 따라 다릅니다.

| 패키지 | 대상 프레임워크 | 종속성 |
|---|---|---|
| Aspose.Slides.NET | `net462` | System.Text.Json |
| Aspose.Slides.NET | `net6.0` | System.Drawing.Common, System.Security.Cryptography.Xml |
| Aspose.Slides.NET | `netstandard2.0` | System.Drawing.Common, System.Security.Cryptography.Xml, System.Text.Encoding.CodePages, System.Text.Json |
| Aspose.Slides.NET6.CrossPlatform | `net6.0` | System.Security.Cryptography.Xml |

NuGet의 [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) 및 [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) 페이지에 있는 **Dependencies** 섹션은 각 릴리스에 대한 각 종속성의 최소 버전을 나열합니다.

프로젝트에 Aspose.Slides를 추가하면 NuGet이 이러한 패키지의 종속성도 복원합니다. 전이적 종속성을 포함하여 프로젝트가 복원하는 모든 패키지를 나열하려면 프로젝트 폴더에서 다음 명령을 실행하십시오:

```bash
dotnet list package --include-transitive
```

알려진 취약점에 대해 동일한 패키지 세트를 확인하려면 다음을 실행하십시오:

```bash
dotnet list package --vulnerable --include-transitive
```

NuGet 패키지를 감사하는 다른 방법은 [Auditing package dependencies for security vulnerabilities](https://learn.microsoft.com/en-us/nuget/concepts/auditing-packages)를 참조하십시오.

## **타사 구성 요소**

Aspose.Slides에는 타사 오픈 소스 구성 요소의 코드가 포함되어 있습니다. 이들은 별도의 NuGet 패키지가 아니라 제품의 일부이므로 NuGet 종속성만 읽는 도구에서는 표시되지 않습니다. 두 패키지 모두 구성 요소와 해당 라이선스를 나열한 *thirdpartylicenses.Aspose.Slides.for.NET.pdf* 파일을 포함합니다:

| 구성 요소 | 공지에 명시된 라이선스 |
|---|---|
| DotNetZip | Microsoft Public License (Ms-PL) |
| ANTLR | BSD License |
| sfntly | Apache License 2.0 |
| Skia | BSD-style license |
| HarfBuzz | "Old MIT" license |
| Boost | Boost Software License 1.0 |
| Double Conversion | BSD-style license |
| ICU (International Components for Unicode) | Unicode copyright and terms of use |

## **FAQ**

**Aspose 코드의 취약점을 모니터링하는 시스템은 무엇입니까?**

우리는 모든 Aspose.Slides 릴리스에 대해 정적 코드 분석을 수행합니다. Aspose.Slides 코드가 OWASP Top 10을 통과한다는 보안 보고서를 제공할 수 있습니다.

**Aspose.Slides는 외부 패키지를 사용합니까?**

예. [NuGet Dependencies](#nuget-dependencies)에 나열된 Microsoft NuGet 패키지에 의존하며, [Third-Party Components](#third-party-components)에 나열된 타사 구성 요소도 포함합니다. 보안 검토 시 두 항목 모두 포함하고, `dotnet list package --vulnerable --include-transitive` 명령을 사용하여 프로젝트가 복원하는 NuGet 패키지를 확인하십시오.