---
title: "Python via Java에서 PowerPoint 프레젠테이션을 Markdown으로 변환"
linktitle: "PowerPoint를 Markdown으로"
type: docs
weight: 140
url: /ko/python-java/convert-powerpoint-to-markdown/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPTX 변환
- PowerPoint를 MD로
- 프레젠테이션을 MD로
- 슬라이드를 MD로
- PPT를 MD로
- PPTX를 MD로
- PowerPoint를 Markdown으로 저장
- 프레젠테이션을 Markdown으로 저장
- 슬라이드를 Markdown으로 저장
- PPT를 MD로 저장
- PPTX를 MD로 저장
- PPT를 MD로 내보내기
- PPTX를 MD로 내보내기
- Markdown 이미지 내보내기
- CDN 이미지 링크
- PowerPoint
- 프레젠테이션
- Markdown
- Python
- Java
- Aspose.Slides
description: "Python via Java에서 PPT 및 PPTX 프레젠테이션을 Markdown으로 변환하고, 내보낸 비트맵, 메타파일 및 SVG 이미지가 저장되고 참조되는 위치를 제어합니다."
---
## **개요**

Aspose.Slides for Python via Java는 PPT 및 PPTX 프레젠테이션을 Markdown으로 변환하여 문서화, 정적 사이트, 콘텐츠 마이그레이션 및 버전 제어 워크플로에 사용할 수 있습니다. Markdown 스타일을 선택하고 슬라이드 콘텐츠가 렌더링되는 방식을 제어하며, 내보낸 이미지가 저장되는 위치와 생성된 Markdown이 이를 어떻게 참조할지 결정할 수 있습니다.

기본적으로 Markdown 내보내기는 텍스트 전용 출력을 사용합니다. 시각적 콘텐츠를 내보내려면 [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/markdownsaveoptions/#setExportType) 메서드로 [MarkdownExportType] 열거형의 `Sequential` 또는 `Visual` 값 중 하나를 설정합니다. `Sequential`은 슬라이드 항목을 별도로 순서대로 렌더링하고, `Visual`은 그룹화된 항목을 함께 유지하여 시각적 관계를 보존합니다. `TextOnly` 값은 이미지 리소스를 출력하지 않으므로 해당 모드에서는 이미지 저장 콜백이 호출되지 않습니다.

## **프레젠테이션을 Markdown으로 변환**

소스 파일을 [Presentation] 클래스로 로드한 후, [Presentation.save] 메서드를 호출하여 [SaveFormat] 열거형의 `Md` 값을 전달합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.md", SaveFormat.Md)
finally:
    presentation.dispose()
```

각 예제는 현재 작업 디렉터리에서 `presentation.pptx` 파일을 읽습니다. 예제를 실행하기 전에 Aspose.Slides for Python via Java와 호환되는 Java 런타임을 설치하세요. Python 프로세스당 JVM을 한 번 시작합니다.

## **Markdown 형식 선택**

[MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/ko/python-java/aspose.slides/markdownsaveoptions/#setFlavor) 메서드는 출력에 사용되는 Markdown 사양을 제어합니다. [Flavor] 열거형에는 CommonMark, GitHub Flavored Markdown 및 기타 지원되는 변형이 포함됩니다.

다음 예제는 프레젠테이션을 CommonMark 형식으로 내보냅니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Flavor, MarkdownSaveOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setFlavor(Flavor.CommonMark)

    presentation.save("presentation.md", SaveFormat.Md, options)
finally:
    presentation.dispose()
```

## **기본 로컬 저장 동작을 사용하여 이미지 내보내기**

[MarkdownSaveOptions] 클래스는 로컬에 저장되는 이미지를 구성하기 위해 두 가지 메서드를 제공합니다:

- [setBasePath] 메서드는 Markdown 문서와 그 리소스의 기본 디렉터리를 지정합니다.
- [setImagesSaveFolderName] 메서드는 이미지 하위 디렉터리를 지정합니다. 기본값은 `Images` 입니다.

다음 예제는 시각적 콘텐츠를 렌더링하고, 이미지를 `output/assets`에 저장하며, Markdown 문서에 상대 이미지 참조를 생성합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import MarkdownExportType, MarkdownSaveOptions, Presentation, SaveFormat

output_directory = Path("output")
output_directory.mkdir(parents=True, exist_ok=True)

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setExportType(MarkdownExportType.Visual)
    options.setBasePath(str(output_directory))
    options.setImagesSaveFolderName("assets")

    markdown_path = output_directory / "presentation.md"
    presentation.save(str(markdown_path), SaveFormat.Md, options)
finally:
    presentation.dispose()
```

사용자 정의 이미지 저장 핸들러가 `False`를 반환할 경우, 이 동작이 대체 경로로 사용됩니다.

## **이미지 저장 및 Markdown 링크 사용자 지정**

Markdown 내보내기 중에 생성되는 비SVG 비트맵 및 메타파일 리소스에 대한 콜백을 등록하려면 [MarkdownSaveOptions.setImageSaving] 메서드를 사용합니다. 이 메서드의 `MarkdownImageSavingHandler` 콜백은 이미지 객체, 해당 [ImageFormat] 값, 그리고 하나의 요소를 가진 `String[]` 파라미터 형태의 생성된 Markdown 링크를 전달받습니다. 제공된 형식으로 이미지를 저장하거나 업로드하고, `link[0]`을 Markdown 출력에 표시되어야 할 참조로 교체합니다.

SVG 형식으로 출력되는 리소스는 별도로 처리됩니다. [MarkdownSaveOptions.setSvgImageSaving] 메서드로 콜백을 등록합니다. 이 메서드의 `MarkdownSvgImageSavingHandler` 콜백은 [SvgImage] 객체와 하나의 요소를 가진 `String[] link` 파라미터를 전달받습니다. SVG는 `ImageFormat` 인수가 없으므로, 대신 [SvgImage.getSvgData] 메서드에서 XML 데이터를 기록하거나 업로드합니다. 내보내기 모드와 시각적 그룹화에 따라 소스 프레젠테이션의 SVG가 래스터화되거나 다른 콘텐츠와 결합될 수 있으며, 결과적인 비SVG 리소스가 이미지 저장 콜백에 전달됩니다. 모든 내보낸 시각 리소스에 대해 사용자 지정 처리가 필요하면 두 콜백을 모두 등록하십시오.

핸들러의 반환 값에 따라 이미지 처리 주체가 결정됩니다:

- 핸들러가 이미지를 저장, 업로드, 변환 또는 기타 방식으로 처리하고 `link[0]`에 유효한 값을 지정한 후 `True`를 반환합니다. Aspose.Slides는 해당 값을 Markdown 문서에 기록하고 기본 로컬 저장을 수행하지 않습니다.
- `False`를 반환하면 Aspose.Slides가 이미지를 로컬에 저장하고 [MarkdownSaveOptions.setBasePath] 및 [MarkdownSaveOptions.setImagesSaveFolderName]에 설정된 값에 따라 링크를 생성합니다.

{{% alert color="danger" title="Important" %}}
`True`를 반환하는 핸들러는 이미지에 대한 책임을 집니다. 유효하고 비어 있지 않은 링크를 지정하지 않고 `True`를 반환하면 `InvalidOperationException`이 발생하여 내보내기가 실패합니다.
{{% /alert %}}

Python에서는 `jpype.JProxy`를 사용해 이러한 콜백을 등록하고, Java 콜백 인터페이스의 `invoke` 메서드를 구현합니다. `link` 인자는 변경 가능한 Java 문자열 배열이며, 처리 전에 `link[0]`을 Python 문자열로 변환하고, 교체할 URL을 다시 `link[0]`에 할당합니다.

### **CDN 원본 디렉터리에 이미지 저장 및 외부 URL 사용**

다음 예제는 `cdn-origin/presentations/quarterly-report`를 마운트되거나 동기화된 CDN 원본 디렉터리로 간주합니다. 각 핸들러는 생성된 파일명을 추출하고 해당 사용자 정의 디렉터리에 이미지를 저장한 뒤, 생성된 로컬 참조를 공개 CDN URL로 교체합니다. 샘플 자체는 네트워크 업로드를 수행하지 않으며, 디렉터리가 CDN 원본으로 마운트되거나 파일이 CDN에 게시된 후에만 URL이 유효해집니다. 객체 저장소를 사용하는 경우, 파일 시스템 쓰기를 스토리지 SDK의 업로드 작업으로 교체하고 업로드가 성공한 후에만 `link[0]`을 할당합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from urllib.parse import quote
from asposeslides.api import MarkdownExportType, MarkdownSaveOptions, Presentation, SaveFormat

output_directory = Path("output")
public_base_url = "https://cdn.example.com/presentations/quarterly-report"
storage_directory = Path("cdn-origin", "presentations", "quarterly-report")
output_directory.mkdir(parents=True, exist_ok=True)
storage_directory.mkdir(parents=True, exist_ok=True)

def get_file_name(generated_link):
    normalized_link = str(generated_link).replace("\\", "/")
    return normalized_link.rsplit("/", 1)[-1]

def save_image(image, image_format, link):
    if image.getWidth() < 128 or image.getHeight() < 128:
        return False

    file_name = get_file_name(link[0])
    storage_path = storage_directory / file_name
    image.save(str(storage_path), image_format)
    encoded_file_name = quote(file_name, safe="")
    link[0] = public_base_url + "/" + encoded_file_name
    return True

def save_svg(svg_image, link):
    file_name = get_file_name(link[0])
    storage_path = storage_directory / file_name
    svg_data = svg_image.getSvgData()
    try:
        storage_path.write_bytes(bytes(svg_data))
    except OSError as error:
        print(f"Could not save the SVG image: {error}")
        return False

    encoded_file_name = quote(file_name, safe="")
    link[0] = public_base_url + "/" + encoded_file_name
    return True

image_handler = jpype.JProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler", dict(invoke=save_image))
svg_handler = jpype.JProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler", dict(invoke=save_svg))

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setExportType(MarkdownExportType.Visual)
    options.setBasePath(str(output_directory))
    options.setImagesSaveFolderName("fallback-images")
    options.setImageSaving(image_handler)
    options.setSvgImageSaving(svg_handler)

    markdown_path = output_directory / "presentation.md"
    presentation.save(str(markdown_path), SaveFormat.Md, options)
finally:
    presentation.dispose()
```

비트맵 핸들러는 의도적으로 128 × 128 픽셀보다 작은 이미지는 `False`를 반환하므로, Aspose.Slides는 이러한 이미지를 기본 동작으로 `output/fallback-images`에 저장합니다. 더 큰 비트맵 및 메타파일 리소스와 SVG 리소스는 사용자 정의 코드가 처리합니다. 예를 들어, `fallback-images/image1.png`와 같은 로컬 참조는 `https://cdn.example.com/presentations/quarterly-report/image1.png`가 됩니다. 핸들러는 파일을 쓸 때만 운영 체제 경로를 사용하고, Markdown에 기록되는 링크는 슬래시(`/`)와 URL 인코딩된 파일 이름을 사용합니다. 상대 링크를 만들 때도 동일한 규칙을 적용해 `/`를 사용하고, 플랫폼 별 디렉터리 구분자는 사용하지 않습니다.

## **FAQ**

**하나의 핸들러가 래스터 이미지와 SVG 이미지를 모두 처리할 수 있나요?**

아니요. 래스터 이미지와 메타파일 리소스는 [MarkdownSaveOptions.setImageSaving]을 사용하고, SVG로 출력되는 리소스는 [MarkdownSaveOptions.setSvgImageSaving]을 사용하십시오. 전자는 이미지 객체와 [ImageFormat] 값을 제공하고, 후자는 [SvgImage] 객체와 SVG 데이터를 읽을 수 있는 [SvgImage.getSvgData] 메서드를 제공합니다. 내보내기 중에 래스터화된 소스 SVG는 이미지 저장 콜백으로 처리됩니다.

**이미지 저장 핸들러가 `False`를 반환하면 어떻게 되나요?**

Aspose.Slides는 기본 로컬 저장 동작을 사용합니다. 이미지 위치와 생성된 참조는 [MarkdownSaveOptions.setBasePath] 및 [MarkdownSaveOptions.setImagesSaveFolderName]에 설정된 값에 의해 제어됩니다.

**핸들러가 이미지를 로컬에 저장하지 않고 URL만 제공할 수 있나요?**

예. 핸들러는 이미지를 객체 저장소에 업로드하거나 다른 서비스에 전달하고, 결과 URL을 `link[0]`에 할당한 뒤 `True`를 반환할 수 있습니다. 핸들러가 직접 처리를 완료해야 하며, `True`를 반환하면 기본 로컬 저장이 방지됩니다.

**왜 Markdown 내보내기에서 핸들러가 `InvalidOperationException`을 발생시키나요?**

핸들러가 `True`를 반환했지만 유효한 링크를 제공하지 않을 때 이 예외가 발생합니다. `True`를 반환하기 전에 Markdown에 기록될 상대 경로나 외부 URL을 할당하십시오.

**이미지 링크에 어떤 경로 구분자를 사용해야 하나요?**

Markdown 링크와 URL에서는 슬래시(`/`)를 사용하십시오. 파일 시스템 경로를 다룰 때는 `pathlib.Path`를 사용하고, Markdown 참조는 별도로 구성하거나 정규화하십시오.

**Markdown 내보내기 중에 하이퍼링크가 보존되나요?**

예. 텍스트 [hyperlinks](/slides/ko/python-java/manage-hyperlinks/)는 표준 Markdown 링크로 보존됩니다. 슬라이드 [transitions](/slides/ko/python-java/slide-transition/)와 [animations](/slides/ko/python-java/powerpoint-animation/)는 변환되지 않습니다.

**프레젠테이션을 병렬로 Markdown으로 변환할 수 있나요?**

다른 프레젠테이션 파일을 병렬로 처리할 수 있지만, 스레드 간에 동일한 [Presentation] 인스턴스를 공유하면 안 됩니다. [멀티스레딩 가이드라인](/slides/ko/python-java/multithreading/)을 따르고 파일당 별도 인스턴스를 사용하십시오.