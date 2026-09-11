---
title: Python을 통한 Java에서 PowerPoint 글꼴 사용자 지정
linktitle: 사용자 정의 글꼴
type: docs
weight: 20
url: /ko/python-java/custom-font/
keywords:
- 글꼴
- 사용자 정의 글꼴
- 외부 글꼴
- 글꼴 로드
- 글꼴 관리
- 글꼴 폴더
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Python을 위한 Aspose.Slides를 사용해 Java를 통해 PowerPoint 슬라이드의 글꼴을 사용자 지정하여 프레젠테이션을 모든 디바이스에서 선명하고 일관되게 유지하십시오."
---
## **개요**

Aspose.Slides는 운영 체제에 설치하지 않고도 프레젠테이션에서 사용자 정의 글꼴을 사용할 수 있도록 합니다. 사용자 정의 폴더에서 글꼴을 로드하거나, 문서 수준 글꼴 소스를 통해 특정 프레젠테이션에 대해 글꼴을 제공하거나, 이진 데이터에서 직접 외부 글꼴을 로드할 수 있습니다.

로드된 글꼴은 프레젠테이션을 렌더링하거나 PDF, 이미지 및 기타 지원 형식으로 내보낼 때 사용됩니다. 이를 통해 다양한 환경에서 프레젠테이션 출력이 일관되게 유지됩니다. 이 문서에서는 Aspose.Slides에서 사용하는 글꼴 폴더를 확인하는 방법과 외부 글꼴 사용 후 글꼴 캐시를 지우는 방법도 설명합니다.

렌더링을 위한 사용자 정의 글꼴 등록은 PPTX 파일에 글꼴을 삽입하는 것과 별개입니다. 글꼴을 프레젠테이션 자체에 저장해야 하는 경우, 글꼴 삽입 기능을 명시적으로 사용하십시오.

프레젠테이션 테마는 개별 쓰기 시스템에 대해 서로 다른 글꼴 패밀리를 참조할 수 있습니다. 이러한 매핑은 글꼴 이름을 저장하지만 글꼴 파일을 설치하거나 로드하지는 않습니다. 매핑을 관리하려면 [Script-Specific Theme Fonts](/slides/ko/python-java/script-specific-font-mappings/)를 참고하고, 아래 로딩 옵션을 사용하여 참조된 글꼴을 일관된 렌더링을 위해 사용할 수 있게 하십시오.

{{% alert color="info" title="Note" %}}
Aspose.Slides는 다음 메서드인 [loadExternalFonts](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontsloader/#loadExternalFonts) 를 사용하여 이러한 글꼴을 로드할 수 있습니다:

* TrueType (.ttf) 및 TrueType Collection (.ttc) 글꼴. 자세한 내용은 [TrueType](https://en.wikipedia.org/wiki/TrueType)을 참조하십시오.
* OpenType (.otf) 글꼴. 자세한 내용은 [OpenType](https://en.wikipedia.org/wiki/OpenType)을 참조하십시오.
{{% /alert %}}

## **사용자 정의 글꼴 로드**

Aspose.Slides는 시스템에 설치하지 않고도 프레젠테이션에서 사용되는 글꼴을 로드할 수 있도록 합니다. 이는 PDF, 이미지 및 기타 지원 형식과 같은 내보내기 결과가 환경에 따라 일관되게 보이도록 영향을 줍니다. 글꼴은 사용자 정의 디렉터리에서 로드됩니다.

1. 글꼴 파일이 포함된 하나 이상의 폴더를 지정합니다.
2. 정적 [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontsloader/#loadExternalFonts) 메서드를 호출하여 해당 폴더에서 글꼴을 로드합니다.
3. 프레젠테이션을 로드하고 렌더링/내보냅니다.
4. [FontsLoader.clearCache](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontsloader/#clearCache)를 호출하여 글꼴 캐시를 지웁니다.

다음 코드 예제는 글꼴 로드 과정을 보여 줍니다:

```python
from jpype import JArray, JString
from asposeslides.api import FontsLoader, Presentation, SaveFormat

# 사용자 정의 글꼴 파일이 들어 있는 폴더를 정의합니다.
font_folders = JArray(JString)(["assets/fonts", "global/fonts"])

# 지정된 폴더에서 사용자 정의 글꼴을 로드합니다.
FontsLoader.loadExternalFonts(font_folders)

presentation = None
try:
    presentation = Presentation("sample.pptx")

    # 로드된 글꼴을 사용하여 프레젠테이션을 렌더링/내보냅니다.
    presentation.save("output.pdf", SaveFormat.Pdf)
finally:
    if presentation is not None:
        presentation.dispose()

    # 작업이 끝난 후 글꼴 캐시를 지웁니다.
    FontsLoader.clearCache()
```

{{% alert color="info" title="Note" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontsloader/#loadExternalFonts) 는 글꼴 검색 경로에 추가 폴더를 추가하지만, 글꼴 초기화 순서는 변경하지 않습니다.
글꼴은 다음 순서대로 초기화됩니다:

1. 기본 운영 체제 글꼴 경로.
1. [FontsLoader](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontsloader/) 를 통해 로드된 경로.
{{%/alert %}}

## **사용자 정의 글꼴 폴더 가져오기**
Aspose.Slides는 [getFontFolders](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontsloader/#getFontFolders) 메서드를 제공하여 글꼴 폴더를 찾을 수 있게 합니다. 이 메서드는 [loadExternalFonts](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontsloader/#loadExternalFonts) 로 추가된 폴더와 시스템 글꼴 폴더를 반환합니다.

다음 Python 코드는 [getFontFolders](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontsloader/#getFontFolders) 사용 방법을 보여 줍니다:

```python
from asposeslides.api import FontsLoader

# loadExternalFonts를 통해 추가된 폴더와 시스템 글꼴 폴더를 가져옵니다.
font_folders = FontsLoader.getFontFolders()
```

## **프레젠테이션에 사용되는 사용자 정의 글꼴 지정**
Aspose.Slides는 [getDocumentLevelFontSources](https://reference.aspose.com/slides/ko/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources) 메서드를 제공하여 프레젠테이션과 함께 사용할 외부 글꼴을 지정할 수 있게 합니다.

다음 Python 코드는 [getDocumentLevelFontSources](https://reference.aspose.com/slides/ko/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources) 사용 방법을 보여 줍니다:

```python
from pathlib import Path
from jpype import JArray, JByte, JString
from asposeslides.api import LoadOptions, Presentation

memory_font_primary = Path("customfonts/CustomFont1.ttf").read_bytes()
memory_font_secondary = Path("customfonts/CustomFont2.ttf").read_bytes()

load_options = LoadOptions()
font_folders = JArray(JString)(["assets/fonts", "global/fonts"])
memory_fonts = JArray(JByte, 2)([memory_font_primary, memory_font_secondary])
load_options.getDocumentLevelFontSources().setFontFolders(font_folders)
load_options.getDocumentLevelFontSources().setMemoryFonts(memory_fonts)

presentation = Presentation("MyPresentation.pptx", load_options)
try:
    # 프레젠테이션 작업.
    # CustomFont1, CustomFont2, 및 assets/fonts와 global/fonts에 있는 글꼴
    # 그리고 그 하위 폴더도 프레젠테이션에서 사용할 수 있습니다.
    pass
finally:
    presentation.dispose()
```

## **외부에서 글꼴 관리**

Aspose.Slides는 [loadExternalFont](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontsloader/#loadExternalFont) 메서드를 제공하여 이진 데이터에서 외부 글꼴을 로드할 수 있게 합니다.

다음 Python 코드는 바이트 배열을 이용한 글꼴 로드 과정을 보여 줍니다:

```python
from pathlib import Path
from jpype import JArray, JByte
from asposeslides.api import FontsLoader, Presentation

font_data = Path("ARIALN.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))
font_data = Path("ARIALNBI.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))
font_data = Path("ARIALNI.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))

try:
    presentation = Presentation()
    try:
        # 프레젠테이션 수명 동안 외부 글꼴이 로드됩니다.
        pass
    finally:
        presentation.dispose()
finally:
    FontsLoader.clearCache()
```

## **자주 묻는 질문**

**사용자 정의 글꼴이 모든 형식(PDF, PNG, SVG, HTML)으로의 내보내기에 영향을 줍니까?**

예. 연결된 글꼴은 모든 내보내기 형식에서 렌더러에 의해 사용됩니다.

**사용자 정의 글꼴이 결과 PPTX에 자동으로 삽입됩니까?**

아니요. 렌더링을 위해 글꼴을 등록하는 것은 PPTX에 삽입하는 것과 동일하지 않습니다. 프레젠테이션 파일에 글꼴을 포함해야 하는 경우, 명시적인 [embedding features](/slides/ko/python-java/embedded-font/)를 사용해야 합니다.

**사용자 정의 글꼴에 특정 글리프가 없을 때 대체 동작을 제어할 수 있나요?**

예. 요청된 글리프가 없을 때 어떤 글꼴을 사용할지 정확히 정의하려면 [font substitution](/slides/ko/python-java/font-substitution/), [replacement rules](/slides/ko/python-java/font-replacement/), [fallback sets](/slides/ko/python-java/fallback-font/)를 구성하십시오.

**Linux/Docker 컨테이너에서 시스템 전체에 설치하지 않고 글꼴을 사용할 수 있나요?**

예. 자체 글꼴 폴더를 지정하거나 바이트 배열에서 글꼴을 로드하십시오. 이렇게 하면 컨테이너 이미지에서 시스템 글꼴 디렉터리에 대한 의존성이 없어집니다.

**라이선스는 어떻게 되나요—제한 없이 어떤 사용자 정의 글꼴이든 삽입할 수 있나요?**

글꼴 라이선스 준수는 사용자 책임입니다. 조건은 다를 수 있으며, 일부 라이선스는 삽입이나 상업적 사용을 금지합니다. 출력물을 배포하기 전에 항상 글꼴의 EULA를 검토하십시오.