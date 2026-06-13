---
title: 자주 묻는 질문
type: docs
weight: 110
url: /ko/reportingservices/frequently-asked-questions/
---
{{% alert color="primary" %}} 

이 페이지는 다음에 대한 자주 묻는 질문을 모아놓았습니다:

- [지원되는 파일 형식](#Supported-File-Formats).
- [Power BI Reporting 서비스 지원](#Support-for-Power-BI-Reporting-services).
- [설치](#Installation).
- [내보내기 구성](#Export-Configuration).

{{% /alert %}} 
### **지원되는 파일 형식**
#### **Q: Aspose.Slides for Reporting Services를 사용하여 보고서를 어떤 형식으로 내보낼 수 있습니까?**
**A**: Aspose.Slides for Reporting Services를 사용하면 PPT, PPS, PPTX, PPSX, XPS 또는 RPL 형식으로 모든 보고서를 내보낼 수 있습니다.
### **Power BI Reporting 서비스 지원**
#### **Q: Aspose.Slides for Reporting Services가 Power BI를 지원합니까?**
**A**: 예. Aspose.Slides for Reporting Services는 Power BI에서 페이지 매김 보고서(RDL)를 내보내는 것을 지원합니다.
### **설치**
#### **Q: 설치 프로그램이 시작되지 않습니다. 수동 설치가 원하는 결과를 얻지 못합니다.**
**A** : 시스템에 .NET Framework 3.5가 설치되어 있는지 확인하십시오.
#### **Q: Aspose.Slides for Reporting Services 설치 후 내보내기 옵션이 없습니다.**
**A**: rssrvpolicy.config에 있는 CodeGroup 중 하나가 제대로 작동하지 않으면 구성 파일 파서가 해당 그룹의 마지막 섹션을 건너뛸 수 있습니다. 따라서 Aspose.Slides for Reporting Services와 연결된 모든 CodeGroup을 Aspose.Slides for Reporting Services CodeGroups를 포함하는 블록의 상단으로 이동하십시오.
#### **Q: 파일 또는 어셈블리 Aspose.Slides.ReportingServices를 로드할 수 없습니다 (실행 권한을 획득할 수 없음 \ HRESULT 예외: 0x80131418).**
**A**: 오류 코드 (0x80131418)는 dll 모듈에 충분한 권한이 없음을 나타냅니다. 이는 다른 컴퓨터에서 가져온 경우 .dll 파일에 대한 전체 액세스가 차단되는 보안 기능 때문일 수 있습니다. 해결 방법은 dll 파일의 속성 창을 열고 '보안' 패널에서 '차단 해제' 버튼을 클릭하는 것입니다.
#### **Q: 라이선스 'Aspose.Slides.Reporting.Services.lic'를 찾을 수 없습니다.**
**A**: 라이선스 파일은 dll 옆이나 Program Files(x86)\Aspose\Slides\ 디렉터리에 있어야 합니다.
### **내보내기 구성**
#### **Q: 내보낸 보고서에서 하이퍼링크 색상을 어떻게 변경합니까?**
**A**: rsreportserver.config에 있는 각 Aspose.Slides for Reporting Services 렌더링 확장에는 자체 구성이 있습니다. 하이퍼링크 색상을 변경하려면 <HyperlinkColor> 섹션에 원하는 값을 설정하십시오.
#### **Q: 내보낸 프레젠테이션에서 표의 텍스트가 수직으로 늘어납니다.**
**A**: 이는 문서를 읽기 쉽게 만들기 위해 수행됩니다. 보고서에 표시되는 대로 표의 텍스트를 표시하려면 rsreportserver.config 구성 파일에서 Aspose.Slides for Reporting Services 확장을 "Normal"로 설정하십시오.