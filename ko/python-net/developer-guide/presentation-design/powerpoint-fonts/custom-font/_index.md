---
title: Python에서 PowerPoint 글꼴 사용자 지정
linktitle: 사용자 지정 글꼴
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
description: "Aspose.Slides for Python을 통해 .NET으로 PowerPoint 슬라이드에 사용자 지정 글꼴을 삽입하여 프레젠테이션을 모든 장치에서 선명하고 일관되게 유지합니다."
---
## **Overview**

Aspose.Slides for Python을 사용하면 런타임에 사용자 지정 글꼴을 제공할 수 있어, 필요한 글꼴이 호스트 시스템에 설치되어 있지 않더라도 프레젠테이션이 올바르게 렌더링됩니다. PDF 또는 이미지로 내보낼 때 글꼴 폴더나 메모리 상의 글꼴 데이터를 제공하여 텍스트 레이아웃, 글리프 메트릭 및 타이포그래피를 유지할 수 있습니다. 이를 통해 서버 측 렌더링이 다양한 환경에서 예측 가능해지고, OS 수준의 글꼴 종속성이 제거되며, 원치 않는 폰트 대체나 레이아웃 재배치를 방지할 수 있습니다. 이 문서에서는 글꼴 소스를 등록하는 방법을 보여줍니다.

Aspose.Slides는 [FontsLoader](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontsloader/) 클래스의 `load_external_font` 및 `load_external_fonts` 메서드를 사용하여 다음과 같은 글꼴을 로드할 수 있습니다.

- TrueType(.ttf) 및 TrueType Collection(.ttc) 글꼴. 자세히 보기 [TrueType](https://en.wikipedia.org/wiki/TrueType).
- OpenType(.otf) 글꼴. 자세히 보기 [OpenType](https://en.wikipedia.org/wiki/OpenType).

## **Load Custom Fonts**

Aspose.Slides를 사용하면 시스템에 설치하지 않고도 프레젠테이션에 사용되는 글꼴을 로드할 수 있습니다. 이는 PDF, 이미지 및 기타 지원 형식과 같은 내보내기 결과에 영향을 미쳐, 다양한 환경에서 일관된 문서가 생성됩니다. 글꼴은 사용자 지정 디렉터리에서 로드됩니다.

1. 글꼴 파일이 들어 있는 하나 이상의 폴더를 지정합니다.
2. 해당 폴더에서 글꼴을 로드하기 위해 정적 [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontsloader/load_external_fonts/) 메서드를 호출합니다.
3. 프레젠테이션을 로드하고 렌더링/내보냅니다.
4. [FontsLoader.clear_cache](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontsloader/clear_cache/)를 호출하여 글꼴 캐시를 지웁니다.

다음 코드 예제는 글꼴 로드 과정을 보여 줍니다:

```py
import aspose.slides as slides

# 사용자 지정 글꼴 파일이 포함된 폴더를 정의합니다.
font_folders = [ external_font_folder1, external_font_folder2 ]

# 지정된 폴더에서 사용자 지정 글꼴을 로드합니다.
slides.FontsLoader.load_external_fonts(font_folders)

with slides.Presentation("sample.pptx") as presentation:
    # 로드된 글꼴을 사용하여 프레젠테이션을 렌더링/내보냅니다 (예: PDF, 이미지 또는 기타 형식).
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)

# 작업이 완료된 후 글꼴 캐시를 지웁니다.
slides.FontsLoader.clear_cache()
```

{{% alert color="info" title="Note" %}}
[FontsLoader.load_external_fonts](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontsloader/load_external_fonts/)은 글꼴 검색 경로에 추가 폴더를 포함하지만, 글꼴 초기화 순서는 변경하지 않습니다.  
글꼴은 다음 순서대로 초기화됩니다:

1. 기본 운영 체제 글꼴 경로.
1. [FontsLoader](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontsloader/)를 통해 로드된 경로.
{{%/alert %}}

## **Get the Custom Fonts Folder**

Aspose.Slides는 `get_font_folders` 메서드를 제공하여 글꼴 폴더를 가져올 수 있습니다. 이 메서드는 `load_external_fonts`를 통해 추가된 폴더와 시스템 글꼴 폴더를 모두 반환합니다.

다음 파이썬 코드는 `get_font_folders` 사용 방법을 보여 줍니다:

```python
import aspose.slides as slides

# 이 호출은 글꼴 파일을 확인하는 폴더들을 반환합니다.
# 여기에는 load_external_fonts 메서드를 통해 추가된 폴더와 시스템 글꼴 폴더가 포함됩니다.
font_folders = slides.FontsLoader.get_font_folders()
```

## **Specify Custom Fonts for a Presentation**

Aspose.Slides는 `document_level_font_sources` 속성을 제공하여 프레젠테이션에 사용할 외부 글꼴을 지정할 수 있게 합니다.

다음 파이썬 예제는 `document_level_font_sources` 사용 방법을 보여 줍니다:

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
    # 프레젠테이션 작업을 수행합니다.
    # CustomFont1, CustomFont2 및 assets\fonts와 global\fonts 폴더(및 하위 폴더)의 글꼴이 프레젠테이션에서 사용할 수 있습니다.
    # ...
    print(len(presentation.slides))
```

## **Load External Fonts from Binary Data**

Aspose.Slides는 `load_external_font` 메서드를 제공하여 바이너리 데이터에서 외부 글꼴을 로드할 수 있습니다.

다음 파이썬 예제는 바이트 배열에서 글꼴을 로드하는 방법을 시연합니다:

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

**Do custom fonts affect export to all formats (PDF, PNG, SVG, HTML)?**  
Yes. Connected fonts are used by the renderer across all export formats.

**Are custom fonts automatically embedded into the resulting PPTX?**  
No. Registering a font for rendering is not the same as embedding it into a PPTX. If you need the font carried inside the presentation file, you must use the explicit [embedding features](/slides/ko/python-net/embedded-font/).

**Can I control fallback behavior when a custom font lacks certain glyphs?**  
Yes. Configure [font substitution](/slides/ko/python-net/font-substitution/), [replacement rules](/slides/ko/python-net/font-replacement/), and [fallback sets](/slides/ko/python-net/fallback-font/) to define exactly which font is used when the requested glyph is missing.

**Can I use fonts in Linux/Docker containers without installing them system-wide?**  
Yes. Point to your own font folders or load fonts from byte arrays. This removes any dependency on system font directories in the container image.

**What about licensing—can I embed any custom font without restrictions?**  
You are responsible for font licensing compliance. Terms vary; some licenses prohibit embedding or commercial use. Always review the font’s EULA before distributing outputs.