---
title: 기능 개요
type: docs
weight: 20
url: /ko/python-net/features-overview/
keywords:
- 기능
- 지원되는 플랫폼
- 파일 형식
- 변환
- 렌더링
- 인쇄
- 포맷팅
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET: PowerPoint 및 OpenDocument 프레젠테이션을 효율적으로 만들고, 편집하고, 자동화하며, 변환할 수 있는 강력한 API."
---
## **지원되는 플랫폼**
Aspose.Slides for Python via .NET을 사용할 수 있는 플랫폼은 Windows x64 또는 x86와 Python 3.5 이상이 설치된 다양한 Linux 배포판입니다. 대상 Linux 플랫폼에 추가 요구 사항이 있습니다:
- GCC-6 런타임 라이브러리(또는 이후 버전)
- .NET Core Runtime의 종속성. .NET Core Runtime 자체를 설치할 필요는 없습니다
- Python 3.5‑3.7: `pymalloc` 빌드의 Python이 필요합니다. `--with-pymalloc` Python 빌드 옵션은 기본적으로 활성화됩니다. 일반적으로 `pymalloc` 빌드의 Python은 파일명에 `m` 접미사가 붙습니다.
- `libpython` 공유 Python 라이브러리. `--enable-shared` Python 빌드 옵션은 기본적으로 비활성화되어 있으며, 일부 Python 배포판에는 `libpython` 공유 라이브러리가 포함되지 않을 수 있습니다. 일부 Linux 플랫폼에서는 패키지 관리자를 통해 `libpython` 공유 라이브러리를 설치할 수 있습니다(예: `sudo apt-get install libpython3.7`). 일반적인 문제는 `libpython` 라이브러리가 표준 시스템 공유 라이브러리 위치와 다른 곳에 설치된다는 점입니다. 이 문제는 Python을 컴파일할 때 빌드 옵션으로 대체 라이브러리 경로를 지정하거나, 시스템 표준 위치에 `libpython` 라이브러리 파일에 대한 심볼릭 링크를 생성하여 해결할 수 있습니다. 일반적으로 `libpython` 공유 라이브러리 파일명은 Python 3.5‑3.7의 경우 `libpythonX.Ym.so.1.0`, Python 3.8 이후는 `libpythonX.Y.so.1.0` 형태입니다(예: `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

더 많은 플랫폼 지원이 필요하면 “twin brother” 제품인 Aspose.Slides for .NET 또는 Aspose.Slides for Java을 찾아보세요.

## **파일 형식 및 변환**
Aspose.Slides for Python via .NET은 대부분의 PowerPoint 문서 형식을 지원합니다. 또한 조직에서 널리 사용하고 서로 교환하는 인기 형식으로 내보낼 수 있습니다. 자세히 살펴보세요:

|**기능**|**설명**|
| :- | :- |
|[Microsoft PowerPoint (PPT)](/slides/ko/python-net/ppt-vs-pptx/)|Aspose.Slides for Python via .NET은 이 프레젠테이션 문서 형식에 대해 가장 빠른 처리를 제공합니다.|
|[PPT to PPTX conversion](/slides/ko/python-net/convert-ppt-to-pptx/)|Aspose.Slides for Python via .NET은 PPT를 PPTX로 변환하는 것을 지원합니다.|
|[Portable Document Format (PDF)](/slides/ko/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)|단일 메서드로 지원되는 모든 파일 형식을 Adobe Portable Document Format(PDF) 문서로 내보낼 수 있습니다.|
|[XML Parser Specification (XPS)](https://docs.aspose.com/slides/ko/python-net/convert-powerpoint-to-xps/)|단일 메서드로 지원되는 모든 파일 형식을 XML Parser Specification(XPS) 문서로 내보낼 수 있습니다.|
|[Tagged Image File Format (TIFF)](/slides/ko/python-net/convert-powerpoint-to-tiff/)|지원되는 모든 프레젠테이션 파일 형식을 Tagged Image File Format(TIFF)으로 내보낼 수 있습니다.|
|[PPTX To HTML Conversion](https://docs.aspose.com/slides/ko/python-net/convert-powerpoint-to-html/)|Aspose.Slides for Python via .NET은 PresentationEx를 HTML 형식으로 변환하는 것을 지원합니다.|

## **렌더링 및 인쇄**
Aspose.Slides for Python via .NET은 프레젠테이션 문서의 슬라이드를 다양한 그래픽 형식으로 고품질 렌더링하는 것을 지원합니다. 자세히 살펴보세요:

|**기능**|**설명**|
| :- | :- |
|.NET 지원 이미지 형식|Aspose.Slides for Python via .NET을 사용하면 TIFF, PNG, BMP, JPEG, GIF 및 메타파일과 같은 .NET이 지원하는 모든 그래픽 형식으로 프레젠테이션 슬라이드와 슬라이드 내 이미지를 렌더링할 수 있습니다.|
|SVG 형식|Aspose.Slides for Python via .NET은 스케일러블 벡터 그래픽(SVG) 형식으로 프레젠테이션 슬라이드를 내보내는 내장 메서드도 제공합니다.|
|프레젠테이션 인쇄|최신 버전의 Aspose.Slides for Python via .NET은 다양한 옵션을 제공하는 내장 인쇄 메서드를 제공합니다.|

## **콘텐츠 기능**
Aspose.Slides for Python via .NET을 사용하면 프레젠테이션 문서의 거의 모든 항목이나 콘텐츠에 접근, 수정 또는 생성할 수 있습니다. 자세히 살펴보세요:

|**기능**|**설명**|
| :- | :- |
|마스터 슬라이드|마스터 슬라이드는 일반 슬라이드의 레이아웃을 정의합니다. Aspose.Slides for Python via .NET을 사용하면 프레젠테이션 문서의 마스터 슬라이드에 접근하고 수정할 수 있습니다.|
|일반 슬라이드|Aspose.Slides for Python via .NET을 사용하면 다양한 유형의 새 슬라이드를 만들 수 있으며, 기존 슬라이드에도 접근하고 수정할 수 있습니다.|
|슬라이드 복제/복사|Aspose.Slides for Python via .NET이 제공하는 내장 메서드를 사용하면 프레젠테이션 내 기존 슬라이드를 복제하거나 복사할 수 있습니다. 복제·복사된 슬라이드를 한 프레젠테이션에서 다른 프레젠테이션으로도 사용할 수 있습니다. 슬라이드는 마스터 슬라이드의 레이아웃을 상속하므로 내장 복제 메서드는 복제 시 마스터도 자동으로 복사합니다.|
|슬라이드 섹션 관리|프레젠테이션 내부에 슬라이드를 다양한 섹션으로 조직하는 메서드|
|플레이스홀더 및 텍스트 홀더|슬라이드의 플레이스홀더와 텍스트 홀더에 접근할 수 있습니다. 또한 적절한 메서드를 사용해 텍스트 홀더가 있는 슬라이드를 처음부터 만들 수 있습니다.|
|머리글 및 바닥글|Aspose.Slides for Python via .NET은 슬라이드의 머리글/바닥글 처리을 지원합니다.|
|슬라이드 노트|Aspose.Slides for Python via .NET을 사용하면 슬라이드에 연결된 노트에 접근하고 수정할 수 있으며 새 노트를 추가할 수도 있습니다.|
|모양 찾기|모양에 연결된 대체 텍스트를 사용해 특정 모양을 찾을 수 있습니다.|
|배경|Aspose.Slides for Python via .NET을 사용하면 마스터 슬라이드 또는 일반 슬라이드에 연결된 배경을 작업할 수 있습니다.|
|텍스트 상자|텍스트 상자를 처음부터 생성할 수 있으며, 기존 텍스트 상자에 접근하고 원본 텍스트 형식을 유지하면서 텍스트를 수정할 수 있습니다.|
|사각형 모양|Aspose.Slides for Python via .NET을 사용해 사각형 모양을 생성하거나 수정할 수 있습니다.|
|폴리 라인 모양|Aspose.Slides for Python via .NET을 사용해 폴리 라인 모양을 생성하거나 수정할 수 있습니다.|
|타원형 모양|Aspose.Slides for Python via .NET을 사용해 타원형 모양을 생성하거나 수정할 수 있습니다.|
|그룹 모양|Aspose.Slides for Python via .NET은 그룹 모양을 지원합니다.|
|자동 모양|Aspose.Slides for Python via .NET은 자동 모양을 지원합니다.|
|SmartArt|Aspose.Slides for Python via .NET은 MS PowerPoint의 SmartArt 모양을 지원합니다.|
|차트|Aspose.Slides for Python via .NET은 PowerPoint의 MSO 차트를 지원합니다.|
|모양 직렬화|Aspose.Slides for Python via .NET은 많은 종류의 모양을 지원합니다. 지원되지 않는 모양이 있을 경우, 기존 슬라이드에서 해당 모양을 직렬화하는 방법을 사용해 직렬화할 수 있으며, 이렇게 얻은 모양을 필요에 따라 재사용할 수 있습니다.|
|그림 프레임|Aspose.Slides for Python via .NET을 사용해 그림 프레임 안의 이미지를 관리할 수 있습니다.|
|오디오 프레임|Aspose.Slides for Python via .NET을 사용해 슬라이드의 오디오 프레임에 오디오 파일을 링크하거나 임베드할 수 있습니다.|
|비디오 프레임|Aspose.Slides for Python via .NET을 사용해 비디오 프레임 안의 비디오 파일을 처리할 수 있으며, 링크 비디오와 임베드 비디오 모두를 지원합니다.|
|OLE 프레임|Aspose.Slides for Python via .NET을 사용해 OLE 프레임 안의 OLE 객체를 관리할 수 있습니다.|
|표|Aspose.Slides for Python via .NET은 슬라이드의 표를 지원합니다.|
|ActiveX 컨트롤|ActiveX 컨트롤을 지원합니다.|
|VBA 매크로|프레젠테이션 내부의 VBA 매크로 관리를 지원합니다.|
|텍스트 프레임|어떤 모양이든 해당 모양에 연결된 텍스트 프레임을 통해 텍스트에 접근할 수 있습니다.|
|텍스트 스캔|내장 스캔 메서드를 사용해 프레젠테이션 수준 또는 슬라이드 수준에서 텍스트를 스캔할 수 있습니다.|
|애니메이션|모양에 애니메이션을 적용할 수 있습니다.|
|슬라이드 쇼|Aspose.Slides for Python via .NET은 슬라이드 쇼와 슬라이드 전환을 지원합니다.|

## **포맷팅 기능**
Aspose.Slides for Python via .NET을 사용하면 프레젠테이션 슬라이드의 텍스트와 모양을 포맷팅할 수 있습니다. 자세히 살펴보세요:

|**기능**|**설명**|
| :- | :- |
|텍스트 포맷팅|<p>Aspose.Slides for Python via .NET에서 텍스트는 모양에 연결된 텍스트 프레임을 통해 관리됩니다. 따라서 텍스트 프레임에 연결된 단락과 구간을 사용해 텍스트를 포맷팅할 수 있습니다. 이러한 텍스트 요소는 Aspose.Slides for Python via .NET을 통해 포맷팅됩니다.</p><p>- 글꼴 종류</p><p>- 글꼴 크기</p><p>- 글꼴 색상</p><p>- 글꼴 음영</p><p>- 단락 정렬</p><p>- 단락 글머리표</p><p>- 단락 방향</p>|
|모양 포맷팅|<p>Aspose.Slides for Python via .NET에서 슬라이드의 기본 요소는 모양입니다. 다음 요소들을 Aspose.Slides for Python via .NET을 사용해 포맷팅할 수 있습니다:</p><p>- 위치</p><p>- 크기</p><p>- 선</p><p>- 채우기(패턴, 그라디언트, 단색 포함)</p><p>- 텍스트</p><p>- 이미지</p>|

## **FAQ**

**서버/PC에 Microsoft PowerPoint를 설치해야 라이브러리를 사용할 수 있나요?**

아니요. PowerPoint는 필요하지 않으며, Aspose.Slides는 프레젠테이션을 만들고, 편집하고, 변환하고, 렌더링하는 독립형 엔진입니다.

**멀티스레딩은 어떻게 작동하나요? 처리를 병렬화할 수 있나요?**

다른 스레드에서 서로 다른 문서를 처리하는 것은 안전합니다. 동일한 [presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 객체를 [여러 스레드](/slides/ko/python-net/multithreading/)가 동시에 사용해서는 안 됩니다.

**파일 암호 및 암호화가 지원되나요?**

네. [암호가 보호된 프레젠테이션](/slides/ko/python-net/password-protected-presentation/)을 열 수 있으며, 열기 및 쓰기 암호를 설정하거나 제거하고 보호 상태를 확인할 수 있습니다.

**Linux 컨테이너에서 폰트 패키지를 신경 써야 하나요?**

네. 일반적인 폰트 패키지를 설치하거나 애플리케이션에서 [폰트 디렉터리 지정](/slides/ko/python-net/custom-font/)을 명시적으로 지정하여 예기치 않은 대체를 방지하는 것이 좋습니다.

**평가 버전에는 제한이 있나요?**

[평가 모드](/slides/ko/python-net/licensing/)에서는 출력에 워터마크가 추가되고 특정 제한이 적용됩니다; 전체 기능 테스트를 위한 [30일 임시 라이선스](https://purchase.aspose.com/temporary-license/)를 이용할 수 있습니다.

**외부 형식(PDF/HTML → PPTX)을 프레젠테이션에 가져오는 것이 지원되나요?**

네. [PDF 페이지 및 HTML 콘텐츠](/slides/ko/python-net/import-presentation/)를 프레젠테이션에 추가해 슬라이드로 변환할 수 있습니다.