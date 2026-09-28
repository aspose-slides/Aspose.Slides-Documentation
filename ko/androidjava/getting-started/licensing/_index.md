---
title: 라이선스
type: docs
weight: 90
url: /ko/androidjava/licensing/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java에서 라이선스를 적용하고 관리하며 문제를 해결합니다. 라이선스 가이드를 통해 전체 기능에 대한 지속적인 액세스를 보장하세요."
---
## **개요**

Aspose.Slides는 평가 모드 또는 유효한 라이선스로 사용할 수 있습니다. 평가 버전은 라이선스 버전과 동일한 기능을 제공하지만, 저장하는 각 프레젠테이션의 모든 슬라이드에 평가 워터마크를 추가하고 프레젠테이션에서 코딩으로 읽어오는 텍스트를 잘라냅니다.

이 문서는 Aspose.Slides에서 라이선스가 어떻게 작동하는지 및 라이브러리를 사용하기 전에 라이선스를 적용하는 방법을 설명합니다. 라이선스는 [License](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/) 클래스를 사용하여 파일, 스트림 또는 포함된 리소스에서 로드할 수 있습니다. 또한 라이선스가 올바르게 적용되었는지 확인하는 방법도 보여줍니다.

## **Aspose.Slides 평가**

{{% alert color="info" title="Note" %}}

**Aspose.Slides for Android via Java**의 평가 버전을 [download page](https://releases.aspose.com/slides/androidjava/)에서 다운로드할 수 있습니다. 평가 버전은 제품의 라이선스 버전과 동일한 기능을 제공합니다. 평가 패키지는 구매한 패키지와 동일합니다. 평가 버전은 라이선스를 적용하기 위해 몇 줄의 코드를 추가하면 라이선스가 적용된 상태가 됩니다.

**Aspose.Slides** 평가가 만족스러우면 [purchase a license](https://purchase.aspose.com/pricing/slides/android-java/)를 진행하십시오. 다양한 구독 유형을 확인하시기 바랍니다. 질문이 있으면 Aspose 영업팀에 문의하세요.

모든 Aspose 라이선스에는 구독 기간 내에 새로운 버전이나 수정 사항에 대한 무료 업그레이드 1년 구독이 포함됩니다. 라이선스가 있는 제품(또는 평가 버전) 사용자는 무료 무제한 기술 지원을 받을 수 있습니다.

{{% /alert %}} 

**평가 버전 제한 사항**

* 라이선스가 지정되지 않은 평가 버전은 전체 제품 기능을 제공하지만, 저장하는 각 프레젠테이션의 모든 슬라이드에 평가 워터마크 텍스트 상자를 추가합니다.
* 코드가 프레젠테이션에서 읽어오는 텍스트는 첫 몇 문자만 남기고 평가 제한에 대한 알림이 이어집니다. 코드가 쓰는 텍스트는 전체가 저장됩니다.

{{% alert color="info" title="Note" %}}

제한 없이 Aspose.Slides를 테스트하려면 **30일 임시 라이선스**를 요청할 수 있습니다. 자세한 내용은 [How to get a Temporary License](https://purchase.aspose.com/temporary-license) 페이지를 참조하십시오.

{{% /alert %}}

## **Aspose.Slides의 라이선스**

* 평가 버전은 라이선스를 구매하고 몇 줄의 코드를 추가하면 라이선스가 적용된 상태가 됩니다.
* 라이선스는 제품 이름, 라이선스가 적용된 개발자 수, 구독 만료일 등과 같은 세부 정보를 포함하는 텍스트 XML 파일입니다. 
* 라이선스 파일은 디지털 서명되어 있으므로 파일을 수정해서는 안 됩니다. 파일 내용에 한 줄이 추가되는 것조차도 무효화됩니다.
* Aspose.Slides for Android via Java은 일반적으로 다음 위치에서 라이선스를 찾습니다:
  * 명시적인 경로
  * Aspose.Slides.jar가 포함된 폴더
* 평가 버전과 관련된 제한을 피하려면 **Aspose.Slides**를 사용하기 전에 라이선스를 설정해야 합니다. 애플리케이션 또는 프로세스당 한 번만 라이선스를 설정하면 됩니다.

## **라이선스 적용**

라이선스는 **파일** 또는 **스트림**에서 로드할 수 있습니다.

{{% alert color="info" title="Note" %}}

Aspose.Slides는 라이선스 작업을 위해 [License](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/) 클래스를 제공합니다.

{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}

새 라이선스는 버전 21.4 이상에서만 Aspose.Slides를 활성화할 수 있습니다. 이전 버전은 다른 라이선스 시스템을 사용하며 이러한 라이선스를 인식하지 않습니다.

{{% /alert %}}

### **파일**

라이선스를 설정하는 가장 쉬운 방법은 라이선스 파일을 Aspose.Slides.jar가 포함된 폴더 또는 애플리케이션의 jar에 배치하는 것입니다.

{{% alert color="info" title="Note" %}}

Android에서는 라이브러리와 앱이 APK에 패키징되므로 라이브러리 JAR 파일이 포함된 폴더가 없으며 *Aspose.Slides.Android.via.Java.lic*와 같은 상대 경로는 앱 내 파일을 가리키지 않습니다. 라이선스 파일을 앱의 assets에 추가하고 [Stream from App Assets](#stream-from-app-assets)와 같이 스트림으로 로드하십시오.

{{% /alert %}}

다음 Java 코드는 라이선스 파일을 설정하는 방법을 보여줍니다:

``` java
// License 클래스를 인스턴스화합니다
com.aspose.slides.License license = new com.aspose.slides.License();

// 라이선스 파일 경로를 설정합니다
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```

{{% alert color="warning" title="Warning" %}}

다른 디렉터리에 라이선스 파일을 배치한 경우, [setLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) 메서드를 호출할 때 지정된 경로 끝에 있는 파일 이름이 라이선스 파일 이름과 동일해야 합니다.

예를 들어 라이선스 파일 이름을 *Aspose.Slides.Android.via.Java.lic.xml*로 변경할 수 있습니다. 그런 다음 코드에서 [setLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) 메서드에 *Aspose.Slides.Android.via.Java.lic.xml*로 끝나는 경로를 전달해야 합니다.

{{% /alert %}}

### **스트림**

스트림에서 라이선스를 로드할 수 있습니다. 다음 Java 코드는 스트림에서 라이선스를 적용하는 방법을 보여줍니다:

``` java
// License 클래스를 인스턴스화합니다
com.aspose.slides.License license = new com.aspose.slides.License();

// 스트림을 통해 라이선스를 설정합니다
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Android.via.Java.lic"));
```

### **앱 Assets에서 스트림**

Android 앱에서는 라이선스 파일을 앱 모듈의 *assets* 폴더(*app/src/main/assets*)에 넣어 APK에 포함되도록 합니다. [getAssets](https://developer.android.com/reference/android/content/Context#getAssets()) 메서드로 파일을 열고 스트림을 [setLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) 메서드에 전달합니다. 코드는 `Activity` 내부, 예를 들어 `onCreate` 메서드에서 Aspose.Slides를 사용하기 전에 실행됩니다:

```java
import android.util.Log;
import com.aspose.slides.License;
import java.io.IOException;
import java.io.InputStream;

License license = new License();
try (InputStream licenseStream = getAssets().open("Aspose.Slides.Android.via.Java.lic")) {
    license.setLicense(licenseStream);
} catch (IOException exception) {
    Log.e("Licensing", "Cannot read the license file from the app's assets.", exception);
}
```

[open](https://developer.android.com/reference/android/content/res/AssetManager#open(java.lang.String)) 메서드에 전달되는 파일 이름은 *assets* 폴더를 기준으로 한 상대 경로입니다. 파일이 없으면 코드가 오류를 기록하고 Aspose.Slides는 평가 모드로 유지됩니다. 라이선스가 적용되었는지 확인하려면 [Validating a License](#validating-a-license)를 참조하십시오.

## **라이선스 검증**

라이선스가 올바르게 설정되었는지 확인하려면 검증할 수 있습니다. 다음 Java 코드는 라이선스를 검증하는 방법을 보여줍니다:

```java
import com.aspose.slides.*;

License license = new License();
license.setLicense("Aspose.Slides.Android.via.Java.lic");

if (license.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **스레드 안전성**

{{% alert color="warning" title="Warning" %}}

[setLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) 메서드는 스레드에 안전하지 않습니다. 여러 스레드에서 동시에 호출해야 하는 경우 동기화 프리미티브(예: lock)를 사용하여 문제를 방지하십시오.

{{% /alert %}}

## **FAQ**

### 완전히 오프라인 환경(인터넷 연결 없음)에서 라이선스를 적용할 수 있나요?

네. 라이선스 검증은 라이선스 파일을 사용해 로컬에서 수행되므로 인터넷 연결이 필요하지 않습니다.

### 1년 구독이 만료되면 어떻게 되나요? 라이브러리가 작동을 멈추나요?

아니요. 라이선스는 영구적이며 구독 종료일 이전에 릴리스된 버전을 계속 사용할 수 있습니다. 다만, 구독을 갱신하지 않으면 최신 릴리스를 사용할 수 없습니다.