---
title: SharePoint용 Aspose.Slides 라이선스 제거
type: docs
weight: 20
url: /ko/sharepoint/uninstalling-aspose-slides-for-sharepoint-license/
---
라이선스를 제거하려면 서버 콘솔에서 아래 단계들을 사용하십시오.

1. Farm에서 라이선스 솔루션을 철회합니다:

``` xml

 stsadm.exe -o retractsolution -name Aspose.Slides.SharePoint.License.wsp -immediate

```

2. 철회를 즉시 완료하도록 관리 타이머 작업을 실행합니다:

``` xml

 stsadm.exe -o execadmsvcjobs

```

3. 철회가 완료될 때까지 기다립니다. 중앙 관리에서 **Central Administration**, **Operations**, **Solution Management** 아래에서 철회가 완료되었는지 확인할 수 있습니다.
4. SharePoint 솔루션 저장소에서 솔루션을 제거합니다:

``` xml

 stsadm.exe -o deletesolution -name Aspose.Slides.SharePoint.License.wsp

```