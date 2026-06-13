---
title: Aspose.Slides와 Google Slides 통합
linktitle: Google Slides
type: docs
weight: 50
url: /ko/net/integrating-aspose-slides-with-google-slides/
keywords:
- 클라우드 플랫폼
- 클라우드 통합
- Google Slides
- Google Drive
- Google API
- Google 서비스 계정
- SaaS 통합
- OAuth 2.0
- PPT를 PDF로
- PowerPoint 자동화
- 프레젠테이션 처리
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides를 Google Slides와 연결하여 프레젠테이션을 가져오고, 동기화하고, 변환하며, 워크플로를 자동화하고, PowerPoint와 OpenDocument를 하나의 파이프라인에서 유지합니다."
---
## **소개**

Aspose.Slides는 이제 [SaaS Integration API](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations)를 통해 Google Slides와 Google Drive와의 통합을 제공합니다. 이 통합을 통해 .NET 앱은 Google Slides 프레젠테이션을 변환, 편집, 다운로드 및 업로드할 수 있습니다.

## **Google Slides란?**
[Google Slides](https://workspace.google.com/products/slides/ko/)는 Google이 개발한 무료 웹 기반 프레젠테이션 소프트웨어입니다. 사용자는 Microsoft PowerPoint와 유사하게 온라인에서 슬라이드 프레젠테이션을 만들고, 편집하고, 공유할 수 있습니다. 실시간 협업, 클라우드 저장소를 지원하며 인터넷에 연결된 모든 장치에서 작동합니다.

## **Google API**
Aspose.Slides를 통해 Google Slides 프레젠테이션을 작업하기 시작하기 전에 Google API 프로젝트를 생성하고 [Google Cloud 프로젝트](https://developers.google.com/workspace/guides/create-project)를 만든 다음 원하는 API를 활성화해야 합니다.

그 후 Google API에 접근할 방법을 선택해야 합니다. [Aspose.Slides Google Integration](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations)은 Google API에 접근하는 두 가지 방식을 지원합니다.
- `Google Service Account`
- `OAuth 2.0` with user interaction via a browser.

### **Google 서비스 계정**
서비스 계정은 사용자와의 상호 작용 없이 애플리케이션이나 서버가 프로그래밍 방식으로 Google API에 접근하기 위해 사용하는 특수 Google 계정입니다. 주로 백엔드 시스템이나 자동화 작업에 사용됩니다. 서비스 계정은 JSON 키 파일을 사용해 인증되며 자체 이메일 주소를 가지고 있습니다. [Google Cloud IAM](https://cloud.google.com/iam/docs/overview)을 통해 특정 권한을 부여받을 수 있으며, Google Drive, Sheets, BigQuery와 같은 API와 함께 안전하고 자동화된 리소스 접근에 자주 활용됩니다.

### **OAuth 2.0**
다른 일반적인 Google API 접근 방식은 브라우저를 통한 사용자 상호 작용이 포함된 OAuth 2.0입니다. 이 흐름에서 사용자는 Google 로그인 페이지로 리디렉션돼 앱에 권한을 부여합니다. 승인이 완료되면 앱은 인증 코드를 받아 액세스 토큰 및 리프레시 토큰으로 교환합니다.

액세스 토큰은 Google API에 일시적인 접근을 허용하고, 리프레시 토큰은 저장해 두었다가 새로운 액세스 토큰을 얻는 데 재사용할 수 있어 사용자가 다시 로그인할 필요가 없습니다. 따라서 브라우저 상호 작용은 한 번만 필요하고 이후 API 호출은 완전히 자동화됩니다. 이 방법은 사용자의 동의 하에 Gmail, Calendar, Drive 등 사용자 데이터에 접근해야 하는 앱에 주로 사용됩니다.

## **코드 작성**
먼저 프로젝트에 [Aspose.Slides SaaS Integration NuGet 패키지](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations)를 추가하십시오:

```
dotnet add package Aspose.Slides.SaaSIntegrations
```

### **예제 1**
다음 예제에서는 Google Drive에서 Google Slides 프레젠테이션을 다운로드하고 로컬 디스크에 PDF 파일로 저장합니다. 서비스 계정 JSON 파일이 이미 다운로드되었다고 가정하고 Google Service Account를 사용해 인증합니다.

```csharp
// 외부에서 관리되는 HttpClient 생성
HttpClient httpClient = new HttpClient();

// 서비스 계정 JSON 파일을 사용하여 인증 공급자 생성
IGoogleAuthorizationProvider account = new GoogleServiceAccountAuthProvider(@"service_account_json_file.json", httpClient);

// 인증 공급자를 사용하여 Google Slides 통합 서비스를 초기화
GoogleSlidesIntegration googleSlidesIntegration = new GoogleSlidesIntegration(account, httpClient);

// 파일 ID로 Google Drive에서 프레젠테이션을 로드하여 Aspose.Slides IPresentation 인스턴스로 가져오기
using IPresentation pres = await googleSlidesIntegration.LoadPresentationAsync("1A2B3C4D5E6F7G8H9I0J");

// 필요에 따라 프레젠테이션 수정 (예: 두 번째 슬라이드 제거)
pres.Slides.RemoveAt(1);

// 프레젠테이션을 로컬에 PDF 파일로 저장
pres.Save(@"GoogleDriveDownload.pdf", SaveFormat.Pdf);
```

편의를 위해 Aspose.Slides SaaS Integration은 사용자가 사용할 수 있는 모든 파일을 나열하는 메서드를 제공합니다. 반환된 데이터에는 파일 이름, MIME 유형 및 파일 ID가 포함됩니다.

```csharp
// 제공된 서비스 계정에서 사용할 수 있는 파일 목록 가져오기
var availableFiles = await googleSlidesIntegration.GetDriveFileInfosAsync();

foreach (GoogleDriveFileInfo googleDriveFileInfo in availableFiles)
{
    Console.WriteLine($"File name: {googleDriveFileInfo.Name}, File ID: {googleDriveFileInfo.Id}, MIME type: {googleDriveFileInfo.MimeType}");
}
```

파일 ID를 찾는 또 다른 방법은 Google Slides 웹 앱에서 프레젠테이션을 열고 URL에서 확인하는 것입니다.

예를 들어, 다음 URL에서:

```
https://docs.google.com/presentation/d/1A2B3C4D5E6F7G8H9I0J/edit
```

파일 ID는 다음과 같습니다:

```
1A2B3C4D5E6F7G8H9I0J
```

## **예제 2**
다음 예제에서는 처음부터 PowerPoint 프레젠테이션을 만든 후 Google Slides 형식으로 Google Drive에 업로드합니다. 인증을 위해 OAuth 2.0을 사용합니다.

```csharp
// 외부에서 관리되는 HttpClient 생성
HttpClient httpClient = new HttpClient();

// 클라이언트 ID와 클라이언트 비밀을 사용하여 OAuth 인증 공급자 생성
IGoogleAuthorizationProvider account = new GoogleOAuthProvider("clientId", "clientSecret", httpClient);

// 인증 공급자를 사용하여 Google Slides 통합 서비스 초기화
GoogleSlidesIntegration googleSlidesIntegration = new GoogleSlidesIntegration(account, httpClient);

// Create a sample presentation
using (var presentation = new Presentation())
{
    var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    shape.TextFrame.Text = "Hello from Google Drive!";
    
    // 프레젠테이션을 Google Slides 형식으로 Google Drive 루트 폴더에 저장
    // Aspose.Slides에서 지원하는 다른 내보내기 형식도 선택할 수 있습니다
    var newFileId = await googleSlidesIntegration.SavePresentationAsync(presentation, "New presentation", GoogleSaveFormatType.GoogleSlides);
    Console.WriteLine($"Uploaded file ID: {newFileId}");
}
```

앱에서 이 인증 방식을 사용할 경우 `interaction with the browser is required`. 계정을 선택하고 Google Drive API에 대한 접근을 허용해야 합니다. 이 작업은 첫 실행 시에만 필요합니다.

### **예제 3**
다음 예제에서는 사전에 얻은 액세스 토큰을 사용합니다. `GoogleAccessTokenAuthProvider`는 기존 OAuth 2.0 액세스 토큰을 사용해 Google API 요청을 인증하는 `IGoogleAuthorizationProvider` 인터페이스 구현체입니다. OAuth 흐름을 시작하거나 관리하는 공급자와 달리, 이 클래스는 호출자가 유효한 액세스 토큰을 제공해야 합니다.

이 공급자는 액세스 토큰이 외부에서 획득된 시스템에 유용합니다—보통 프런트엔드 애플리케이션이나 다른 서비스가 토큰을 받아 백엔드에 전달하는 경우입니다. 토큰 갱신을 서버 측에서 관리하는 복잡성이나 동시 갱신 시 토큰 무효화 위험을 피할 수 있어 분산 환경에 특히 적합합니다.

이 예제는 파일을 교체하고 이름을 업데이트하면서 파일 ID를 유지하는 방법을 보여줍니다.

```csharp
// 요청을 위해 HTTP 클라이언트를 생성합니다
using HttpClient httpClient = new HttpClient();

// 액세스 토큰을 사용하여 Google Drive 인증을 설정합니다
GoogleAccessTokenAuthProvider accessTokenAuthProvider = new GoogleAccessTokenAuthProvider("access_token");

// 인증 및 HTTP 클라이언트를 사용하여 Google Slides/Drive와의 통합을 초기화합니다
GoogleSlidesIntegration googleSlidesIntegration =
    new GoogleSlidesIntegration(accessTokenAuthProvider, httpClient);

// Create a sample presentation using Aspose.Slides
using (var presentation = new Presentation())
{
    // 첫 번째 슬라이드에 사각형 모양을 추가하고 텍스트를 설정합니다
    var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    shape.TextFrame.Text = "Hello from Google Drive!";

    // 특정 품질 및 준수 설정을 사용하여 PDF 저장 옵션을 정의합니다
    ISaveOptions saveOptions = new PdfOptions()
    {
        JpegQuality = 50,
        Compliance = PdfCompliance.PdfA1b
    };

    // 파일 ID로 Google Drive에 기존 파일을 저장(교체)하고, 이름을 업데이트한 뒤 PDF로 내보냅니다
    await googleSlidesIntegration.SavePresentationToExistingFileAsync(
        presentation,
        "1A2B3C4D5E6F7G8H9I0J",            // Google Drive에 있는 기존 파일의 ID
        GoogleSaveFormatType.Pdf,         // 저장하려는 원하는 형식
        saveOptions,           
        "NewFileName.pdf"                 // 파일에 지정할 새 이름
    );
}
```

## **요약**
Aspose.Slides는 이제 추가 파일 형식을 지원하여 프레젠테이션을 만들고, 공유하고, 편집하는 클라우드 기반 워크플로우 자동화를 단순화합니다.

이 문서는 기본 기능을 다루었습니다. 하위 폴더에 파일을 저장하고, 기존 파일을 교체하며, Google Drive에 다양한 형식(예: PDF, PPTX, HTML 등)으로 내보낼 수 있습니다—Google Slides 프레젠테이션에만 제한되지 않습니다.

Aspose.Slides SaaS Integration은 프레젠테이션 SaaS 플랫폼에 대한 지원을 지속적으로 확대할 예정이니, 향후 업데이트를 확인하십시오.

## **FAQ**

**이 통합을 사용하려면 Google Workspace 계정이 필요합니까?**  
아니요. 무료 Google 계정 또는 Google Workspace 계정 중 어느 것이든 사용할 수 있습니다. 필요한 접근 권한은 Google Drive와 Slides에 대한 권한에 따라 달라집니다.

**어떤 인증 방식을 선택해야 할까요—Service Account 또는 OAuth 2.0?**  
사용자와의 상호 작용 없이 백엔드 또는 자동화 워크플로에선 **Service Account**를 사용하십시오.  
특정 사용자의 Google Slides 또는 Drive 파일에 사용자 동의 하에 접근해야 할 경우 **OAuth 2.0**을 사용하십시오.

**Google Slides가 아닌 다른 형식도 작업할 수 있나요?**  
예. Aspose.Slides는 프레젠테이션을 다양한 형식(PDF, PPTX, HTML 등)으로 저장한 후 Google Drive에 업로드할 수 있습니다.

**Google Slides 프레젠테이션의 파일 ID를 어떻게 얻을 수 있나요?**  
`GetDriveFileInfosAsync()` 메서드를 사용하거나 Google Slides 프레젠테이션 URL에서 복사하여 얻을 수 있습니다.

**통합이 Google Drive에서 기존 파일을 교체하는 것을 지원하나요?**  
예. `SavePresentationToExistingFileAsync` 메서드를 사용하면 파일 ID를 보존하면서 파일을 업데이트할 수 있습니다.

**OAuth 2.0을 사용할 때마다 브라우저 상호 작용이 필요합니까?**  
아니요. 브라우저 상호 작용은 최초 인증 시에만 필요합니다. 이후에는 저장된 리프레시 토큰을 사용해 자동으로 접근할 수 있습니다.