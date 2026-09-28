---
title: 신뢰 수준 요구 사항
type: docs
weight: 190
url: /ko/net/declaration/
keywords:
- 신뢰 수준
- 전체 신뢰 권한
- 부분 신뢰
- Medium Trust
- 코드 액세스 보안
- ASP.NET
- .NET Framework
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET이 필요로 하는 코드 액세스 보안 신뢰 수준: .NET Framework에서는 전체 신뢰, .NET 6 이후에서는 신뢰 설정이 없습니다."
---
## **개요**

코드 액세스 보안(CAS) 신뢰 수준은 .NET Framework에만 존재합니다. 이 문서에서는 Aspose.Slides for .NET에 대한 의미를 설명합니다. 라이브러리는 .NET Framework에서 전체 신뢰가 필요하며, .NET 6 이후에서는 구성할 신뢰 수준이 없습니다.

## **.NET Framework**

Aspose.Slides는 .NET Framework에서 전체 신뢰가 필요합니다. Medium Trust(`<trust level="Medium" />`)와 같이 부분 신뢰 환경에서는 실행되지 않으며, [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 객체를 생성할 때 `SecurityException`이 발생합니다.

Microsoft는 더 이상 ASP.NET 부분 신뢰를 애플리케이션 간 격리를 위한 방법으로 취급하지 않으며, 대신 별도의 애플리케이션 풀에서 실행할 것을 권장합니다. 자세히 보기: [ASP.NET Partial Trust는 애플리케이션 격리를 보장하지 않습니다](https://support.microsoft.com/en-us/servicing/dotnetframework/troubleshooting/asp-net-partial-trust-does-not-guarantee-application-isolation).

## **.NET 6 및 이후 버전**

코드 액세스 보안은 .NET 6 및 이후 버전에서 사용할 수 없으므로 부여할 신뢰 수준이 없습니다. Aspose.Slides는 애플리케이션을 실행하는 계정의 권한으로 실행됩니다. 애플리케이션이 액세스할 수 있는 범위를 제한하려면 Microsoft는 사용자 계정, 컨테이너 또는 가상 머신과 같은 운영 체제 경계를 사용할 것을 권장합니다. 자세히 보기: [코드 액세스 보안(CAS)](https://learn.microsoft.com/en-us/dotnet/core/porting/net-framework-tech-unavailable#code-access-security-cas).

## **FAQ**

**Aspose.Slides를 Medium Trust에서 ASP.NET 애플리케이션을 실행하는 호스팅 제공업체와 함께 사용할 수 있나요?**

Medium Trust에서는 사용할 수 없습니다. .NET Framework에서 Aspose.Slides를 사용하는 애플리케이션은 전체 신뢰로 실행되어야 합니다.