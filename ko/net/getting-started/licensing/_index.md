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
description: "Aspose.Slides for .NET에서 라이선스를 적용하고, 관리하며, 문제를 해결합니다. 단계별 라이선스 가이드를 통해 전체 기능에 중단 없는 액세스를 보장합니다."
---
## **개요**

Aspose.Slides는 평가 모드 또는 유효한 라이선스로 사용할 수 있습니다. 평가 버전은 정식 버전과 동일한 기능을 제공하지만, 저장하는 각 프레젠테이션의 모든 슬라이드에 평가 워터마크를 추가하고 프레젠테이션에서 코드가 읽는 텍스트를 잘라냅니다.

이 문서는 Aspose.Slides에서 라이선스가 어떻게 작동하는지와 라이브러리를 사용하기 전에 라이선스를 적용하는 방법을 설명합니다. 라이선스는 `License` 클래스를 사용하여 파일, 스트림 또는 임베디드 리소스에서 로드할 수 있습니다. 또한 라이선스가 올바르게 적용되었는지 확인하는 방법도 보여줍니다.

## **Aspose.Slides 평가**

{{% alert color="info" title="Note" %}}
**Aspose.Slides for .NET**의 평가 버전을 [NuGet 다운로드 페이지](https://www.nuget.org/packages/Aspose.Slides.NET/)에서 다운로드할 수 있습니다. 평가 버전은 제품의 정식 버전과 동일한 기능을 제공합니다. 평가 패키지는 구매한 패키지와 동일합니다. 평가 버전은 몇 줄의 코드를 추가하여 라이선스를 적용하면 정식 라이선스로 전환됩니다.

**Aspose.Slides** 평가가 만족스러우면 [라이선스 구매](https://purchase.aspose.com/pricing/slides/ko/net/)를 진행할 수 있습니다. 다양한 구독 유형을 확인하시기 바랍니다. 문의 사항이 있으면 Aspose 영업팀에 연락하십시오.

모든 Aspose 라이선스에는 구독 기간 내에 새 버전이나 수정 사항에 대한 무료 업그레이드가 포함된 1년 구독이 제공됩니다. 정식 제품이든 평가 버전이든 무료 및 무제한 기술 지원을 받을 수 있습니다.
{{% /alert %}} 

**평가 버전 제한 사항**

* 라이선스가 지정되지 않은 평가 버전은 전체 제품 기능을 제공하지만, 저장하는 각 프레젠테이션의 모든 슬라이드에 평가 워터마크 텍스트 상자를 추가합니다.
* 코드가 프레젠테이션에서 읽는 텍스트는 앞부분 몇 문자만 남기고 평가 제한 알림이 뒤에 붙도록 잘려서 반환됩니다. 코드가 쓰는 텍스트는 전체가 저장됩니다.

{{% alert color="info" title="Note" %}}
제한 없이 Aspose.Slides를 테스트하려면 **30일 임시 라이선스**를 신청할 수 있습니다. 자세한 내용은 [임시 라이선스 획득 방법](https://purchase.aspose.com/temporary-license) 페이지를 참조하십시오.
{{% /alert %}}

## **Aspose.Slides 라이선스**
* 평가 버전은 라이선스를 구매하고 몇 줄의 코드를 추가하면 정식 라이선스로 전환됩니다.
* 라이선스는 제품 이름, 라이선스 대상 개발자 수, 구독 만료 날짜 등과 같은 세부 정보를 포함하는 일반 텍스트 XML 파일입니다. 
* 라이선스 파일은 디지털 서명되어 있으므로 파일을 수정해서는 안 됩니다. 파일 내용에 불필요한 줄 바꿈을 추가하는 것만으로도 라이선스가 무효화됩니다.
* Aspose.Slides for .NET은 일반적으로 다음 위치에서 라이선스를 찾습니다:
  * 명시적인 경로
  * 구성 요소 DLL이 포함된 폴더(Aspose.Slides에 포함)
  * 구성 요소 DLL을 호출한 어셈블리가 있는 폴더(Aspose.Slides에 포함)
  * 엔트리 어셈블리(귀하의 .exe)가 있는 폴더
  * 구성 요소 DLL을 호출한 어셈블리의 임베디드 리소스(Aspose.Slides에 포함)
* 평가 버전과 관련된 제한을 피하려면 Aspose.Slides를 사용하기 전에 라이선스를 설정해야 합니다. 애플리케이션 또는 프로세스당 한 번만 라이선스를 설정하면 됩니다.

{{% alert color="info" title="Note" %}}
[Metered Licensing](/slides/ko/net/metered-licensing/)을 확인해 보세요.
{{% /alert %}} 

## **라이선스 적용**
라이선스는 **파일**, **스트림**, 또는 **임베디드 리소스**에서 로드할 수 있습니다. 

{{% alert color="info" title="Note" %}}
Aspose.Slides는 라이선스 작업을 위해 [License](https://reference.aspose.com/slides/ko/net/aspose.slides/license) 클래스를 제공합니다.
{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}
새 라이선스는 버전 21.4 이상에서만 Aspose.Slides를 활성화할 수 있습니다. 이전 버전은 다른 라이선스 시스템을 사용하므로 이 라이선스를 인식하지 못합니다.
{{% /alert %}}

### **파일**
가장 간단한 라이선스 설정 방법은 라이선스 파일을 구성 요소 DLL이 포함된 폴더에 두고 파일 이름만 지정하는 것입니다.

다음 C# 코드는 라이선스 파일을 설정하는 방법을 보여줍니다:

``` csharp
// License 클래스를 인스턴스화합니다 
Aspose.Slides.License license = new Aspose.Slides.License();

// 라이선스 파일 경로를 설정합니다
license.SetLicense("Aspose.Slides.lic");
```

{{% alert color="warning" title="Warning" %}}
라이선스 파일을 다른 디렉터리에 두는 경우, [SetLicense](https://reference.aspose.com/slides/ko/net/aspose.slides/license/setlicense/#setlicense_1) 메서드를 호출할 때 지정한 경로 끝의 파일 이름이 실제 라이선스 파일 이름과 동일해야 합니다.

예를 들어 라이선스 파일 이름을 *Aspose.Slides.lic.xml* 로 변경한 경우, 코드에서 [SetLicense](https://reference.aspose.com/slides/ko/net/aspose.slides/license/setlicense/#setlicense_1) 메서드에 *Aspose.Slides.lic.xml* 로 끝나는 경로를 전달해야 합니다.
{{% /alert %}}

### **스트림**
스트림에서 라이선스를 로드할 수 있습니다. 다음 C# 코드는 스트림에서 라이선스를 적용하는 방법을 보여줍니다:

``` csharp
// License 클래스를 인스턴스화합니다
Aspose.Slides.License license = new Aspose.Slides.License();

// 라이선스 파일을 스트림으로 엽니다
using FileStream licenseStream = File.OpenRead("Aspose.Slides.lic");

// 스트림을 통해 라이선스를 설정합니다
license.SetLicense(licenseStream);
```

### **임베디드 리소스**
구성 요소 DLL을 호출하는 어셈블리 중 하나에 라이선스를 임베디드 리소스로 추가하여 애플리케이션과 함께 패키징할 수 있습니다.

다음은 라이선스 파일을 임베디드 리소스로 추가하는 단계입니다:

1. Visual Studio에서 **File** > **Add Existing Item** > **Add** 순으로 라이선스(.lic) 파일을 프로젝트에 추가합니다.  
2. **Solution Explorer**에서 해당 파일을 선택합니다.  
3. **Properties** 창에서 **Build Action**을 **Embedded Resource**로 설정합니다.  
4. 어셈블리에 임베디드된 라이선스에 접근하려면 프로젝트에 라이선스 파일을 임베디드 리소스로 추가하고, `SetLicense` 메서드에 라이선스 파일 이름을 전달합니다.  

`License` 클래스는 임베디드 리소스에서 라이선스 파일을 자동으로 찾습니다. Microsoft .NET Framework의 `System.Reflection.Assembly` 클래스의 `GetExecutingAssembly`와 `GetManifestResourceStream` 메서드를 직접 호출할 필요가 없습니다.

다음 C# 코드는 임베디드 리소스로 라이선스를 설정하는 방법을 보여줍니다:

``` csharp
// License 클래스를 인스턴스화합니다
Aspose.Slides.License license = new Aspose.Slides.License();

// 어셈블리에 임베드된 라이선스 파일 이름을 전달합니다
license.SetLicense("Aspose.Slides.lic");
```

## **라이선스 검증**

라이선스가 올바르게 설정되었는지 확인하려면 검증할 수 있습니다. 다음 C# 코드는 라이선스를 검증하는 방법을 보여줍니다:

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

{{% alert color="warning" title="Warning" %}}
`license.SetLicense` 메서드는 스레드 안전하지 않습니다. 여러 스레드에서 동시에 호출해야 할 경우, 잠금과 같은 동기화 프리미티브를 사용하여 문제를 방지하십시오.
{{% /alert %}}

## **FAQ**

### 라이선스를 완전히 오프라인 환경(인터넷 연결 없음)에서 적용할 수 있나요?

예. 라이선스 검증은 로컬의 라이선스 파일을 사용해 수행되므로 인터넷 연결이 필요하지 않습니다.

### 1년 구독이 만료되면 어떻게 되나요? 라이브러리가 작동을 멈추나요?

아니오. 라이선스는 영구적이며, 구독 종료일 이전에 릴리스된 버전은 계속 사용할 수 있습니다. 다만 구독을 갱신하지 않으면 최신 릴리스를 이용할 수 없습니다.