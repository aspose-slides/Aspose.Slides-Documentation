---
title: Aspose.Slides for SharePoint 설치
type: docs
weight: 10
url: /ko/sharepoint/installing-aspose-slides-for-sharepoint/
description: "SharePoint 팜에 Aspose.Slides for SharePoint를 설치합니다: SharePoint 버전에 맞는 설치 프로그램을 선택하고, 시스템 검사를 실행한 뒤 솔루션을 배포하고 활성화합니다."
---
## **패키지 내용**

Aspose.Slides for SharePoint는 ZIP 아카이브 형태로 [다운로드 페이지](https://releases.aspose.com/slides/sharepoint/)에서 다운로드됩니다. 이 아카이브에는 지원되는 각 SharePoint 버전에 대해 하나의 SharePoint 솔루션 패키지(WSP)와 하나의 설치 프로그램이 포함됩니다.

| SharePoint 버전 | 설치 프로그램 | 솔루션 패키지 |
| :- | :- | :- |
| SharePoint 2007 | Setup2007.exe | Aspose.Slides.SharePoint2007.wsp |
| SharePoint 2010 | Setup2010.exe | Aspose.Slides.SharePoint2010.wsp |
| SharePoint Server 2013 | Setup2013.exe | Aspose.Slides.SharePoint2013.wsp |
| SharePoint Server 2016 | Setup2016.exe | Aspose.Slides.SharePoint2016.wsp |
| SharePoint Server 2019 | Setup2019.exe | Aspose.Slides.SharePoint2019.wsp |

각 설치 프로그램 옆에는 구성 파일이 있습니다(예: *Setup2019.exe.config*), 이 파일은 설치되는 솔루션 패키지의 이름을 지정합니다. *License* 폴더에는 최종 사용자 사용권 계약 및 제3자 라이선스 고지에 대한 링크가 포함되어 있습니다.

Aspose.Slides for SharePoint는 SharePoint 솔루션으로 패키징되며, SharePoint가 서버 팜 전체에 배포합니다. 그 기능은 사이트 컬렉션별로 활성화하거나 비활성화됩니다.

## **설치 절차**

설치하기 전에 설치 프로그램은 시스템 검사를 실행합니다. 다음을 확인합니다:

- SharePoint가 서버에 설치되어 있습니다.
- 현재 사용자에게 SharePoint 솔루션을 설치하고 배포할 권한이 있습니다.
- SharePoint Administration 서비스가 시작되어 있습니다.
- SharePoint Timer 서비스가 시작되어 있습니다.
- 구성 파일에 지정된 솔루션 패키지가 존재합니다.

Administration 및 Timer 서비스가 필요한 이유는 일부 설치 작업이 타이머 작업으로 실행되어 솔루션을 팜의 모든 서버에 전파하기 때문입니다.

### **설치 실행**

Aspose.Slides for SharePoint를 설치하려면:

1. SharePoint 팜의 서버에 있는 로컬 드라이브로 ZIP 아카이브를 압축 해제합니다.
2. SharePoint 버전과 일치하는 설치 프로그램을 실행하고(위 표 참조) 화면의 지침을 따릅니다. 설치 프로그램은:
   1. 시스템 검사를 수행합니다. 검사 중 하나라도 실패하면 설치가 진행되지 않습니다.

      **시스템 검사 실행**

      ![설치 프로그램의 시스템 검사 화면](installing-aspose-slides-for-sharepoint_1.png)

   2. 최종 사용자 라이선스 계약을 표시합니다. 계속하려면 이를 수락해야 합니다.

      **라이선스 계약**

      ![설치 프로그램의 라이선스 계약 화면](installing-aspose-slides-for-sharepoint_2.png)

   3. 배포 대상을 표시합니다. 기능을 활성화할 웹 응용 프로그램 및 사이트 컬렉션을 선택합니다.

      **배포 대상 선택**

      ![설치 프로그램의 사이트 컬렉션 배포 대상 화면](installing-aspose-slides-for-sharepoint_3.png)

   4. 솔루션을 팜에 배포합니다.

      **설치 진행 상황**

      ![설치 프로그램의 설치 진행 화면](installing-aspose-slides-for-sharepoint_4.png)

   5. 선택한 사이트 컬렉션에서 Aspose.Slides for SharePoint를 활성화합니다.
   6. 솔루션이 배포되고 활성화된 웹 응용 프로그램 및 사이트 컬렉션을 나열합니다.

      **설치 성공**

      ![설치 프로그램의 설치 완료 화면](installing-aspose-slides-for-sharepoint_5.png)

{{% alert color="info" title="Note" %}}
스크린샷은 SharePoint 2007에서 촬영되었습니다. 이후 버전의 설치 프로그램도 동일한 화면을 진행합니다.
{{% /alert %}}

같은 버전의 Aspose.Slides for SharePoint가 이미 설치된 경우, 설치 프로그램은 복구 또는 제거를 제안합니다. 다른 버전이 설치된 경우에는 업그레이드 또는 제거를 제안합니다.

설치 후, 선택한 사이트 컬렉션의 문서 라이브러리 파일 메뉴에 **Convert via Aspose.Slides** 항목이 나타납니다(SharePoint 2007에서는 **Convert with Aspose.Slides**). 첫 프레젠테이션을 변환하려면 [Microsoft PowerPoint 문서를 다른 형식으로 변환](/slides/ko/sharepoint/converting-microsoft-powerpoint-documents-into-other-formats/)을 참조하십시오. 솔루션이 팜에 추가하는 내용은 [배포 및 활성화](/slides/ko/sharepoint/deployment-and-activation/)에 설명되어 있습니다.

## **자주 묻는 질문**

**어떤 설치 프로그램을 실행해야 하나요?**

SharePoint 버전과 일치하는 이름의 설치 프로그램을 실행합니다. 예를 들어, SharePoint Server 2016 팜에서는 *Setup2016.exe*를 실행합니다. 각 설치 프로그램은 해당 솔루션 패키지만 설치합니다.

**라이선스 버전을 위한 별도의 다운로드가 필요합니까?**

아니요. 라이선스 솔루션을 설치할 때까지 동일한 패키지를 평가판 모드로 사용할 수 있습니다; [Aspose.Slides for SharePoint 라이선스 설치](/slides/ko/sharepoint/installing-aspose-slides-for-sharepoint-license/)를 참조하십시오.

**제품을 어떻게 제거합니까?**

같은 설치 프로그램을 다시 실행하고 **Remove**를 선택합니다; [Aspose.Slides for SharePoint 제거](/slides/ko/sharepoint/uninstalling-aspose-slides-for-sharepoint/)를 참조하십시오.