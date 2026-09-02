---
title: Python에서 PowerPoint 글꼴 사용자 지정
linktitle: 맞춤 글꼴
type: docs
weight: 20
url: /ko/python-net/custom-font/
keywords:
- 글꼴
- 맞춤 글꼴
- 외부 글꼴
- 글꼴 로드
- 글꼴 관리
- 글꼴 폴더
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: ".NET을 통해 Python용 Aspose.Slides로 PowerPoint 슬라이드에 맞춤 글꼴을 포함하여 프레젠테이션을 언제든지 선명하고 일관되게 유지합니다."
---
## **개요**

Aspose.Slides for Python을 사용하면 런타임에 사용자 정의 글꼴을 제공하여 필요 글꼴이 호스트 시스템에 설치되어 있지 않아도 프레젠테이션이 올바르게 렌더링됩니다. PDF나 이미지로 내보낼 때 글꼴 폴더 또는 메모리 내 글꼴 데이터를 제공하여 텍스트 레이아웃, 글리프 메트릭 및 타이포그래피를 유지할 수 있습니다. 이를 통해 서버‑사이드 렌더링이 다양한 환경에서 예측 가능해지고, OS 수준의 글꼴 의존성이 제거되며, 원치 않는 폰트 대체나 레이아웃 재배치를 방지할 수 있습니다. 이 문서에서는 글꼴 소스를 등록하는 방법을 보여줍니다.

프레젠테이션 테마는 개별 쓰기 시스템마다 다른 글꼴 패밀리를 참조할 수 있습니다. 이러한 매핑은 글꼴 이름만 저장하고 글꼴 파일을 설치하거나 로드하지는 않습니다. 매핑을 관리하려면 [Script-Specific Theme Fonts](/slides/ko/python-net/script-specific-font-mappings/)를 확인하고, 아래 로드 옵션을 사용하여 참조된 글꼴을 일관된 렌더링을 위해 사용할 수 있도록 하세요.

Aspose.Slides는 [FontsLoader](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontsloader/) 클래스의 `load_external_font` 및 `load_external_fonts` 메서드를 통해 다음과 같은 글꼴을 로드할 수 있습니다.

- TrueType(.ttf) 및 TrueType Collection(.ttc) 글꼴. 자세히 보려면 [TrueType](https://en.wikipedia.org/wiki/TrueType)를 참고하십시오.
- OpenType(.otf) 글꼴. 자세히 보려면 [OpenType](https://en.wikipedia.org/wiki/OpenType)를 참고하십시오.

## **사용자 정의 글꼴 로드**

Aspose.Slides를 사용하면 시스템에 설치하지 않은 프레젠테이션에 사용된 글꼴을 로드할 수 있습니다. 이는 PDF, 이미지 및 기타 지원 형식과 같은 내보내기 결과에 영향을 주어, 다양한 환경에서 문서가 일관된 모습을 유지하도록 합니다. 글꼴은 사용자 정의 디렉터리에서 로드됩니다.

1. 글꼴 파일이 포함된 하나 이상의 폴더를 지정합니다.  
2. 정적 메서드 [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontsloader/load_external_fonts/)를 호출하여 해당 폴더의 글꼴을 로드합니다.  
3. 프레젠테이션을 로드하고 렌더링/내보내기합니다.  
4. [FontsLoader.clear_cache](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontsloader/clear_cache/)를 호출하여 글꼴 캐시를 정리합니다.

다음 코드 예제는 글꼴 로드 과정을 보여줍니다:

```py
import aspose.slides as slides

# 사용자 정의 글꼴 파일이 들어 있는 폴더를 정의합니다.
font_folders = ["fonts", "external_fonts"]

# 지정된 폴더에서 사용자 정의 글꼴을 로드합니다.
slides.FontsLoader.load_external_fonts(font_folders)

with slides.Presentation("sample.pptx") as presentation:
    # 로드된 글꼴을 사용하여 프레젠테이션을 렌더링/내보냅니다 (예: PDF, 이미지 또는 기타 형식).
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)

# 작업이 끝난 후 글꼴 캐시를 정리합니다.
slides.FontsLoader.clear_cache()
```

{{% alert color="info" title="Note" %}}
[FontsLoader.load_external_fonts](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontsloader/load_external_fonts/)는 글꼴 검색 경로에 추가 폴더를 포함하지만, 글꼴 초기화 순서는 변경하지 않습니다.  
글꼴은 다음 순서대로 초기화됩니다:

1. 기본 운영 체제 글꼴 경로.  
1. [FontsLoader](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontsloader/)를 통해 로드된 경로.  
{{%/alert %}}

## **사용자 정의 글꼴 폴더 가져오기**

Aspose.Slides는 `get_font_folders` 메서드를 제공하여 글꼴 폴더를 반환합니다. 이 메서드는 `load_external_fonts`로 추가된 폴더와 시스템 글꼴 폴더 모두를 반환합니다.

다음 Python 코드가 `get_font_folders` 사용 방법을 보여줍니다:

```python
import aspose.slides as slides

# 이 호출은 글꼴 파일이 확인되는 폴더를 반환합니다.
# 여기에는 load_external_fonts 메서드로 추가된 폴더와 시스템 글꼴 폴더가 포함됩니다.
font_folders = slides.FontsLoader.get_font_folders()
```

## **프레젠테이션에 사용자 정의 글꼴 지정**

Aspose.Slides는 `document_level_font_sources` 속성을 제공하여 프레젠테이션에 사용할 외부 글꼴을 지정할 수 있습니다.

다음 Python 예제가 `document_level_font_sources` 사용 방법을 보여줍니다:

```python
import aspose.slides as slides

with open("CustomFont1.ttf", "br") as font1_stream:
    font1_data = font1_stream.read()
    
with open("CustomFont2.ttf", "br") as font2_stream:
    font2_data = font2_stream.read()

load_options = slides.LoadOptions()
load_options.document_level_font_sources.font_folders = ["assets\\fonts", "global\\fonts"] 
load_options.document_level_font_sources.memory_fonts = [font1_data, font2_data]

with slides.Presentation("Fonts.pptx", load_options) as presentation:
    # ...
    # 프레젠테이션 작업.
    # CustomFont1, CustomFont2 및 assets\fonts와 global\fonts 폴더(및 하위 폴더)의 글꼴이 프레젠테이션에서 사용할 수 있습니다.
    # ...
    print(len(presentation.slides))
```

## **바이너리 데이터에서 외부 글꼴 로드**

Aspose.Slides는 `load_external_font` 메서드를 제공하여 바이너리 데이터에서 외부 글꼴을 로드합니다.

다음 Python 예제는 바이트 배열에서 글꼴을 로드하는 방법을 시연합니다:

```python
import aspose.slides as slides

def read_all_bytes(file_path):
    with open(file_path, "rb") as file_stream:
        file_data = file_stream.read()
    return file_data

# 바이트 배열에서 외부 글꼴을 로드합니다.
slides.FontsLoader.load_external_font(read_all_bytes("ARIALN.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNBI.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNI.TTF"))

try:
    with slides.Presentation() as presentation:
        # 외부 글꼴은 이 프레젠테이션 인스턴스가 존재하는 동안 사용할 수 있습니다.
        print("processing")
finally:
    slides.FontsLoader.clear_cache()
```

## **FAQ**

### 사용자 정의 글꼴이 모든 형식(PDF, PNG, SVG, HTML)으로의 내보내기에 영향을 줍니까?

예. 연결된 글꼴은 모든 내보내기 형식에서 렌더러에 의해 사용됩니다.

### 사용자 정의 글꼴이 결과 PPTX에 자동으로 포함됩니까?

아니요. 렌더링을 위해 글꼴을 등록하는 것은 PPTX에 포함시키는 것과 다릅니다. 프레젠테이션 파일에 글꼴을 포함하려면 명시적인 [embedding features](/slides/ko/python-net/embedded-font/)를 사용해야 합니다.

### 사용자 정의 글꼴에 특정 글리프가 없을 때 대체 동작을 제어할 수 있습니까?

예. [font substitution](/slides/ko/python-net/font-substitution/), [replacement rules](/slides/ko/python-net/font-replacement/), [fallback sets](/slides/ko/python-net/fallback-font/)을 구성하여 요청된 글리프가 없을 경우 어떤 글꼴을 사용할지 정확히 정의할 수 있습니다.

### Linux/Docker 컨테이너에서 시스템 전체에 설치하지 않고 글꼴을 사용할 수 있습니까?

예. 자체 글꼴 폴더를 지정하거나 바이트 배열에서 글꼴을 로드하면 컨테이너 이미지의 시스템 글꼴 디렉터리에 대한 의존성을 제거할 수 있습니다.

### 라이선스 측면에서 제한 없이 사용자 정의 글꼴을 포함할 수 있습니까?

글꼴 라이선스 준수는 사용자 책임입니다. 라이선스 조건은 다양하며, 일부는 포함이나 상업적 사용을 금지합니다. 결과물을 배포하기 전에 반드시 해당 글꼴의 EULA를 검토하십시오.