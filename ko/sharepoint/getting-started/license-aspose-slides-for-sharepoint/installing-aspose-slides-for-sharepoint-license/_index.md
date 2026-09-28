---
title: Aspose.Slides for SharePoint 라이선스 설치
type: docs
weight: 10
url: /ko/sharepoint/installing-aspose-slides-for-sharepoint-license/
description: "SharePoint 팜에 Aspose.Slides for SharePoint 라이선스를 설치합니다: 라이선스 솔루션을 솔루션 스토어에 추가하고 배포한 다음, 변환된 파일에 평가 워터마크가 더 이상 표시되지 않는지 확인합니다."
---
{{% alert color="info" title="Note" %}}

평가가 만족스럽다면 [라이선스를 구매](https://purchase.aspose.com/pricing/slides/sharepoint/)할 수 있습니다. 구매하기 전에 라이선스 구독 약관을 이해하고 동의했는지 확인하십시오. 주문이 결제되면 라이선스가 이메일로 발송됩니다.

라이선스는 일반 SharePoint 솔루션 패키지를 포함하는 ZIP 아카이브입니다. 아카이브에는 다음이 포함됩니다:

- Aspose.Slides.SharePoint.License.wsp – SharePoint 솔루션 패키지 파일입니다. 라이선스는 서버 팜 전체에 배포 및 회수를 쉽게 할 수 있도록 SharePoint 솔루션으로 패키징됩니다.
- readme.txt – 라이선스 설치 안내.

{{% /alert %}}

## **라이선스 배포**

라이선스 설치는 **stsadm.exe**를 통해 서버 콘솔에서 수행됩니다.

{{% alert color="info" title="Note" %}}

다음 섹션에서는 명확성을 위해 경로를 생략했습니다.

{{% /alert %}}

다음 단계에 따라 Aspose.Slides for SharePoint 라이선스를 배포하십시오:

1. stsadm을 실행하여 솔루션을 SharePoint 솔루션 스토어에 추가합니다:

   ```bat
   Stsadm.exe -o addsolution -filename Aspose.Slides.SharePoint.License.wsp
   ```

2. 솔루션을 팜의 모든 서버에 배포합니다:

   ```bat
   Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp -immediate -force
   ```

3. 관리 타이머 작업을 실행하여 배포를 즉시 완료합니다:

   ```bat
   Stsadm.exe -o execadmsvcjobs
   ```

`addsolution` 작업은 `-filename`에서 솔루션 파일 경로를 지정합니다; `deploysolution` 작업은 `-name`에서 이미 솔루션 스토어에 있는 솔루션 이름을 지정합니다.

{{% alert color="info" title="Note" %}}

배포 단계를 실행할 때 SharePoint 관리 서비스가 실행 중이 아니면 경고가 나타납니다. **stsadm.exe**는 이 서비스와 SharePoint 타이머 서비스에 의존하여 팜 전체에 솔루션 데이터를 복제합니다. 서버 팜에서 이러한 서비스가 실행되지 않는 경우 각 서버에 라이선스를 배포해야 할 수 있습니다.

{{% /alert %}}

{{% alert color="info" title="Note" %}}

SharePoint 2010 이상에서는 SharePoint Management Shell cmdlet인 `Add-SPSolution`, `Install-SPSolution`, `Start-SPAdminJob`이 각각 `addsolution`, `deploysolution`, `execadmsvcjobs` 작업에 해당합니다. 자세한 내용은 [Stsadm to Microsoft PowerShell mapping in SharePoint Server](https://learn.microsoft.com/en-us/sharepoint/technical-reference/stsadm-to-microsoft-powershell-mapping)를 참고하십시오.

{{% /alert %}}

## **라이선스 테스트**

라이선스가 올바르게 설치되었는지 테스트하려면 프레젠테이션을 새 형식으로 변환하십시오. 변환된 파일에 평가 워터마크가 없으면 라이선스가 활성화된 것입니다.