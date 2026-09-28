---
title: 배포 및 활성화
type: docs
weight: 20
url: /ko/sharepoint/deployment-and-activation/
description: "Aspose.Slides for SharePoint 솔루션이 배포될 때 팜에 설치되는 내용과 사이트 컬렉션 기능이 활성화될 때 추가되는 내용."
---
## **배포**

배포 시, Aspose.Slides for SharePoint 솔루션은:

- 어셈블리를 전역 어셈블리 캐시(GAC)에 설치하고 **web.config** 파일에 SafeControl 항목을 추가합니다. SharePoint 2010 이상에서는 *Aspose.Slides.SharePoint2010.dll*, *Aspose.Slides.SharePoint2013.dll* 또는 *Aspose.Slides.SharePoint2016.dll* (SharePoint 2019 패키지는 *Aspose.Slides.SharePoint2016.dll*도 설치) 입니다. SharePoint 2007에서는 *Aspose.Slides.SharePointUI.dll*와 *Aspose.Slides.SharePoint.Deployment.dll*가 함께 설치됩니다.
- 변환 페이지와 해당 이미지 및 기타 지원 파일을 SharePoint 설치 폴더에 복사합니다.
- 기능을 설치하고 사이트 컬렉션에서 활성화할 수 있도록 합니다.

## **활성화**

Aspose.Slides for SharePoint는 사이트 컬렉션 기능으로 패키징되어 있으며 사이트 컬렉션에서 활성화하거나 비활성화할 수 있습니다. 사이트 컬렉션에서 활성화되면 기능은 다음을 추가합니다:

- SharePoint 2010 이상에서:
  - 문서 라이브러리 문서 메뉴에 **Convert via Aspose.Slides** 항목;
  - 선택한 문서를 변환하는 **Convert Slides** 버튼이 포함된 **Aspose Tools** 리본 탭;
  - PPT, PPTX, PPS 및 PPSX 파일 메뉴에 **View Slides** 항목.
- SharePoint 2007에서:
  - 문서 라이브러리 문서 메뉴에 **Convert with Aspose.Slides** 항목;
  - 문서 라이브러리 **Actions** 메뉴에 **Convert All with Aspose.Slides** 항목.

SharePoint 2007에서는 활성화 시 사이트 컬렉션의 상위 웹 애플리케이션 가상 디렉터리에도 변경이 적용됩니다. 이는 다음을 수행합니다:

- 변환 설정 페이지를 사이트맵 파일에 추가합니다.
- 필요한 리소스 파일을 가상 디렉터리의 App_GlobalResources 폴더에 복사합니다.

설정 프로그램은 [설치](/slides/ko/sharepoint/installing-aspose-slides-for-sharepoint/) 중에 선택한 사이트 컬렉션에 기능을 활성화합니다.