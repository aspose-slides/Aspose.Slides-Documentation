---
title: 라이선스
type: docs
weight: 80
url: /ko/net/licensing/
keywords:
- 라이선스
- 임시 라이선스
- 라이선스 설정
- 라이선스 사용
- 라이선스 검증
- 라이선스 파일
- 평가 버전
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET에서 라이선스를 적용하고 관리하며 문제를 해결합니다. 단계별 라이선스 안내서를 통해 전체 기능을 중단 없이 사용할 수 있습니다."
---
## **개요**

Aspose.Slides는 평가 모드 또는 유효한 라이선스로 사용할 수 있습니다. 평가 버전은 라이선스 버전과 동일한 기능을 제공하지만 프레젠테이션을 열거나 저장할 때 평가 워터마크를 삽입하고 텍스트 추출을 한 슬라이드로 제한합니다.

이 문서에서는 Aspose.Slides의 라이선스 작동 방식과 라이브러리를 사용하기 전에 라이선스를 적용하는 방법을 설명합니다. 라이선스는 `License` 클래스를 사용하여 파일, 스트림 또는 임베디드 리소스에서 로드할 수 있습니다. 또한 라이선스가 올바르게 적용되었는지 검증하는 방법도 보여줍니다.

## **Aspose.Slides 평가**

{{% alert color="info" %}} 

**Aspose.Slides for NET**의 평가 버전을 [NuGet 다운로드 페이지](https://www.nuget.org/packages/Aspose.Slides.NET/)에서 다운로드할 수 있습니다. 평가 버전은 제품의 라이선스 버전과 동일한 기능을 제공합니다. 평가 패키지는 구매한 패키지와 동일합니다. 몇 줄의 코드를 추가하여 라이선스를 적용하면 평가 버전이 라이선스 버전으로 전환됩니다.

**Aspose.Slides** 평가에 만족하면 [라이선스를 구매](https://purchase.aspose.com/buy)할 수 있습니다. 다양한 구독 유형을 확인하시기 바랍니다. 질문이 있으면 Aspose 영업팀에 문의하십시오.

모든 Aspose 라이선스에는 구독 기간 내에 출시되는 새 버전이나 수정에 대한 무료 업그레이드가 포함된 1년 구독이 제공됩니다. 라이선스를 보유한 제품 사용자 및 평가 버전 사용자 모두 무제한 기술 지원을 무료로 받을 수 있습니다.

{{% /alert %}} 

**평가 버전 제한 사항**

* Aspose.Slides 평가 버전(라이선스 지정 없음)은 전체 제품 기능을 제공하지만, 열기 및 저장 시 문서 상단에 평가 워터마크를 삽입합니다.
* 프레젠테이션 슬라이드에서 텍스트를 추출할 때 한 슬라이드만 제한됩니다.

{{% alert color="info" %}} 

제한 없이 Aspose.Slides를 테스트하려면 **30일 임시 라이선스**를 요청할 수 있습니다. 자세한 내용은 [임시 라이선스 받는 방법](https://purchase.aspose.com/temporary-license) 페이지를 참조하십시오.

{{% /alert %}}

## **Aspose.Slides 라이선스**

* 평가 버전은 라이선스를 구매하고 몇 줄의 코드를 추가(라이선스 적용)하면 라이선스가 적용됩니다.
* 라이선스는 제품 이름, 라이선스 대상 개발자 수, 구독 만료 날짜 등과 같은 정보를 포함하는 일반 텍스트 XML 파일입니다.
* 라이선스 파일은 디지털 서명되어 있으므로 수정해서는 안 됩니다. 파일 내용에 실수로 줄 바꿈을 추가해도 무효가 됩니다.
* Aspose.Slides for .NET은 일반적으로 다음 위치에서 라이선스를 찾습니다:
  * 명시적인 경로
  * 구성 요소의 dll이 포함된 폴더(Aspose.Slides에 포함됨)
  * 구성 요소 dll을 호출한 어셈블리가 포함된 폴더(Aspose.Slides에 포함됨)
  * 엔트리 어셈블리(귀하의 .exe)가 포함된 폴더
  * 구성 요소 dll을 호출한 어셈블리의 임베디드 리소스(Aspose.Slides에 포함됨).
* 평가 버전과 관련된 제한을 피하려면 Aspose.Slides를 사용하기 전에 라이선스를 설정해야 합니다. 애플리케이션 또는 프로세스당 한 번만 라이선스를 설정하면 됩니다.

{{% alert color="info" %}} 

[Metered Licensing](https://docs.aspose.com/slides/ko/net/metered-licensing/)을 확인하시기 바랍니다.

{{% /alert %}} 


## **라이선스 적용**
라이선스는 **파일**, **스트림** 또는 **임베디드 리소스**에서 로드할 수 있습니다. 

{{% alert color="info" %}}

Aspose.Slides는 라이선스 작업을 위해 [License](https://reference.aspose.com/slides/ko/net/aspose.slides/license) 클래스를 제공합니다.

{{% /alert %}} 

{{% alert color="warning" %}} 

새 라이선스는 버전 21.4 이상에서만 Aspose.Slides를 활성화할 수 있습니다. 이전 버전은 다른 라이선스 시스템을 사용하므로 이러한 라이선스를 인식하지 못합니다.

{{% /alert %}}

### **파일**
라이선스를 설정하는 가장 쉬운 방법은 라이선스 파일을 구성 요소의 DLL이 포함된 폴더(Aspose.Slides에 포함)와 같은 폴더에 배치하고 경로 없이 파일 이름만 지정하는 것입니다.

This C# code shows you how to set a license file:

``` csharp
// License 클래스를 인스턴스화합니다 
Aspose.Slides.License license = new Aspose.Slides.License();

// 라이선스 파일 경로를 설정합니다
license.SetLicense("Aspose.Slides.lic");
```

{{% alert color="warning" %}} 

라이선스 파일을 다른 디렉터리에 배치한 경우, [SetLicense](https://reference.aspose.com/slides/ko/net/aspose.slides/license/setlicense/#setlicense_1) 메서드를 호출할 때 지정된 명시적인 경로 끝에 있는 라이선스 파일 이름이 실제 라이선스 파일과 동일해야 합니다.

예를 들어 라이선스 파일 이름을 *Aspose.Slides.lic.xml*으로 변경할 수 있습니다. 그런 다음 코드에서 파일 경로(끝이 *Aspose.Slides.lic.xml*인)를 [SetLicense](https://reference.aspose.com/slides/ko/net/aspose.slides/license/setlicense/#setlicense_1) 메서드에 전달해야 합니다.

{{% /alert %}}

### **스트림**
스트림에서 라이선스를 로드할 수 있습니다. This C# code shows you how to apply a license from a stream:

``` csharp
// License 클래스를 인스턴스화합니다
Aspose.Slides.License license = new Aspose.Slides.License();

// 라이선스 파일을 스트림으로 엽니다
using FileStream licenseStream = File.OpenRead("Aspose.Slides.lic");

// 스트림을 통해 라이선스를 설정합니다
license.SetLicense(licenseStream);
```

### **임베디드 리소스**
라이선스를 애플리케이션에 포함시켜(분실 방지) 구성 요소 DLL을 호출하는 어셈블리 중 하나에 임베디드 리소스로 추가할 수 있습니다(Aspose.Slides에 포함). 

This is how you add a license file as an embedded resource:

1. Visual Studio에서 라이선스(.lic) 파일을 프로젝트에 추가합니다: **File** > **Add Existing Item** > **Add** 순서대로 진행합니다. 
2. **Solution Explorer**에서 파일을 선택합니다.
3. **Properties** 창에서 **Build Action**을 **Embedded Resource**로 설정합니다.
4. 어셈블리에 포함된 라이선스에 접근하려면 라이선스 파일을 임베디드 리소스로 프로젝트에 추가한 후 `SetLicense` 메서드에 파일 이름을 전달합니다. 

`License` 클래스는 임베디드 리소스에서 라이선스 파일을 자동으로 찾습니다. Microsoft .NET Framework에서 `System.Reflection.Assembly` 클래스의 `GetExecutingAssembly` 및 `GetManifestResourceStream` 메서드를 호출할 필요가 없습니다.

``` csharp
// License 클래스를 인스턴스화합니다
Aspose.Slides.License license = new Aspose.Slides.License();

// 어셈블리에 포함된 라이선스 파일 이름을 전달합니다
license.SetLicense("Aspose.Slides.lic");
```

## **라이선스 검증**

라이선스가 올바르게 설정되었는지 확인하려면 검증할 수 있습니다. This C# code shows you how to validate a license:

```c#
Aspose.Slides.License license = new Aspose.Slides.License();

license.SetLicense("Aspose.Slides.lic");

if (license.IsLicensed())
{
    Console.WriteLine("License is good!");
    Console.Read();
}
```

## **스레드 안전성**

{{% alert title="Note" color="warning" %}} 

[license.SetLicense](https://reference.aspose.com/slides/ko/net/aspose.slides/license/setlicense/) 메서드는 스레드에 안전하지 않습니다. 이 메서드를 여러 스레드에서 동시에 호출해야 하는 경우, 잠금과 같은 동기화 프리미티브를 사용하여 문제를 방지하는 것이 좋습니다. 

{{% /alert %}}

## **FAQ**

### 완전히 오프라인 환경(인터넷 연결 없음)에서도 라이선스를 적용할 수 있습니까?

예. 라이선스 검증은 라이선스 파일을 사용해 로컬에서 수행되므로 인터넷 연결이 필요하지 않습니다.

### 1년 구독이 만료되면 어떻게 됩니까? 라이브러리가 작동을 멈추나요?

아니요. 라이선스는 영구적이며, 구독 종료일 이전에 릴리스된 버전은 계속 사용할 수 있습니다. 단, 최신 릴리스를 사용하려면 구독을 갱신해야 합니다.