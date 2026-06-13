---
title: 간편하고 가벼운 배포
type: docs
weight: 50
url: /ko/reportingservices/easy-and-lightweight-deployment/
---
{{% alert color="primary" %}} 

Aspose.Slides for Reporting Services는 Microsoft SQL Server Reporting Services용 [렌더링 확장](http://msdn2.microsoft.com/en-us/library/ms154606.aspx)입니다. 
Aspose.Slides for Reporting Services는 다음 중 하나를 실행하는 컴퓨터에 설치할 수 있는 단일 MSI 설치 프로그램으로 제공됩니다: 

- Microsoft SQL Server 2005 Reporting Services (32비트 및 64비트)
- Microsoft SQL Server 2008 Reporting Services (32비트 및 64비트)

Aspose.Slides for Reporting Services는 하나의 .NET 어셈블리인 *Aspose.Slides* *.ReportingServices.dll* 로만 구성되어 있으며, 완전히 C#로 작성되고 CLS를 준수하고 안전한 관리 코드만 포함하고 있기 때문에 수동으로 배포하고 관리하기도 쉽습니다. 

{{% /alert %}} 

MSI 설치 프로그램과 ZIP 다운로드에는 Aspose.Slides for ReportingServices가 포함됩니다: 

- Bin\SSRS2005\Aspose.Slides.ReportingServices.dll – Microsoft SQL Server 2005 및 .NET Framework 2.0용으로 빌드됨 (x86 및 x64 사용)
- Bin\SSRS2008\Aspose.Slides.ReportingServices.dll – Microsoft SQL Server 2008 및 .NET Framework 2.0용으로 빌드됨 (x86 및 x64 사용)

설치 시, Aspose.Slides.ReportingServices.dll이 ReportServer\bin 디렉터리로 복사되고 구성 파일이 업데이트되어 Reporting Services가 새로운 렌더링 확장을 인식하게 됩니다. 이러한 단계는 Aspose.Slides for Reporting Services 설치 프로그램에 의해 수행되지만, 이 문서에서 자세히 설명하는 대로 수동으로 수행할 수도 있습니다. 

![todo:image_alt_text](easy-and-lightweight-deployment_1.png)

**그림**: Aspose.Slides.ReportingServices.dll이 **ReportServer\bin** 디렉터리로 복사됩니다.