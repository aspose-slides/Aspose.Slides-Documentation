---
title: 배포 및 활성화
type: docs
weight: 20
url: /ko/sharepoint/deployment-and-activation/
---
## **배포**
배포 중, Aspose.Slides for SharePoint:

- **Aspose.Slides.SharePoint.dll** 파일을 전역 어셈블리 캐시(Global Assembly Cache)에 설치하고 **web.config** 파일에 SafeControl 항목을 추가합니다.
- 기능 매니페스트 및 기타 필요한 파일들을 적절한 디렉터리에 설치합니다.
- 기능을 SharePoint 데이터베이스에 등록하고 기능 범위에서 활성화할 수 있도록 합니다.
## **활성화**
Aspose.Slides for SharePoint는 사이트(사이트 컬렉션) 수준 기능으로 패키징되어 있으며 사이트 컬렉션에서 활성화하거나 비활성화할 수 있습니다. 활성화 시, 해당 기능은 사이트 컬렉션의 상위 웹 응용 프로그램 가상 디렉터리에 몇 가지 변경을 수행합니다. 이 기능은:

- 변환 설정 페이지를 sitemap 파일에 추가합니다.
- 필요한 리소스 파일을 가상 디렉터리의 App_GlobalResources 폴더에 복사합니다.