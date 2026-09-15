---
title: 외부에 링크된 이미지를 사용하여 프레젠테이션을 HTML로 내보내기
type: docs
weight: 100
url: /ko/python-java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- PowerPoint 내보내기
- OpenDocument 내보내기
- 프레젠테이션 내보내기
- 슬라이드 내보내기
- PPT 내보내기
- PPTX 내보내기
- ODP 내보내기
- PowerPoint를 HTML로 변환
- OpenDocument를 HTML로 변환
- 프레젠테이션을 HTML로 변환
- 슬라이드를 HTML로 변환
- PPT를 HTML로 변환
- PPTX를 HTML로 변환
- ODP를 HTML로 변환
- 링크된 이미지
- 외부에 링크된 이미지
- 링크된 리소스
- 외부 리소스
- 파이썬
- Java
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Python에서 PowerPoint 및 OpenDocument 프레젠테이션을 HTML로 내보내며, 이미지와 기타 리소스를 외부 링크 파일로 저장합니다."
---
## **개요**

기본적으로 Aspose.Slides는 프레젠테이션을 단일 HTML 파일로 내보냅니다. 이미지 및 기타 리소스는 일반적으로 Base64 데이터로 HTML에 직접 기록됩니다. 하나의 휴대 가능한 파일이 필요할 때는 편리하지만, 웹사이트, CMS 또는 서버 측 변환 파이프라인에 항상 최적의 형식은 아닙니다.

외부 링크 리소스를 사용하려는 경우:

- HTML 문서의 크기를 줄이기;
- 브라우저나 CDN에서 이미지, 폰트, 오디오, 비디오를 별도로 캐시하기;
- 내보낸 후 생성된 리소스를 검사, 교체, 압축 또는 후처리하기;
- 웹 애플리케이션이 기대하는 출력 구조에 가깝게 유지하기.

일반적인 HTML 변환 워크플로우에 대해서는 [Convert PowerPoint Presentations to HTML](/slides/ko/python-java/convert-powerpoint-to-html/)를 참조하십시오. 이 문서는 내보내기의 리소스 연결 부분에 중점을 둡니다.

## **링크된 리소스 내보내기 작동 방식**

`ILinkEmbedController`는 애플리케이션이 리소스별로 데이터를 HTML에 삽입할지 외부에 저장하고 링크를 쓸지 결정하도록 합니다.

이 인터페이스에는 세 가지 메서드가 있습니다:

- `ILinkEmbedController.getObjectStoringLocation`은 리소스를 링크할지 임베드할지를 결정합니다.
- `ILinkEmbedController.getUrl`은 생성된 HTML 또는 다른 링크된 리소스에 기록될 URL을 반환합니다.
- `ILinkEmbedController.saveExternal`은 링크된 리소스 데이터를 디스크 또는 다른 저장 대상에 씁니다.

파일 시스템 경로와 브라우저 URL은 별개의 문제입니다. 예를 들어, 아래 샘플은 리소스 파일을 디스크의 `html-output/assets`에 기록하고, HTML에는 `assets/resource-1.svg`와 같은 상대 URL을 포함합니다. 브라우저는 링크가 포함된 파일을 기준으로 해당 URL을 해석합니다. 따라서 `presentation.html`에서 SVG 파일로의 링크는 `assets/resource-1.svg`를 사용하고, 그 SVG 파일이 같은 `assets` 폴더에 저장된 이미지로 연결될 때는 `resource-4.jpg`를 사용합니다.

## **링크된 리소스로 HTML 내보내기**

다음 Python 예제는 출력 디렉터리를 생성하고 HTML 파일을 그곳에 저장하며, 링크된 리소스를 `assets` 하위 디렉터리에 저장합니다. 컨트롤러는 Aspose.Slides가 제공하거나 안전한 파일 확장자를 추론할 수 있는 경우 일반 이미지, 폰트, 오디오, 비디오 및 CSS 리소스를 링크합니다. 인식되지 않은 리소스는 그대로 임베드됩니다.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, LinkEmbedDecision, Presentation, SVGOptions, SaveFormat, SlideImageFormat


class ExternalResourceController:
    EXTENSIONS_BY_CONTENT_TYPE = {
        "image/jpeg": ".jpg",
        "image/png": ".png",
        "image/gif": ".gif",
        "image/bmp": ".bmp",
        "image/svg+xml": ".svg",
        "image/tiff": ".tiff",
        "image/x-emf": ".emf",
        "image/x-wmf": ".wmf",
        "font/woff": ".woff",
        "font/woff2": ".woff2",
        "font/ttf": ".ttf",
        "application/font-woff": ".woff",
        "application/vnd.ms-fontobject": ".eot",
        "application/x-font-ttf": ".ttf",
        "text/css": ".css",
        "audio/mpeg": ".mp3",
        "audio/mp4": ".m4a",
        "audio/wav": ".wav",
        "video/mp4": ".mp4",
        "video/webm": ".webm",
    }

    def __init__(self, asset_directory, asset_url_prefix):
        self.asset_directory = asset_directory
        normalized_prefix = asset_url_prefix.replace("\\", "/") if asset_url_prefix else ""
        self.asset_url_prefix = normalized_prefix.rstrip("/") + "/" if normalized_prefix else ""
        self.file_names_by_resource_id = {}

    def getObjectStoringLocation(self, resource_id, entity_data, semantic_name, content_type, recommended_extension):
        extension = self.resolve_extension(content_type, recommended_extension)
        if extension is None:
            return LinkEmbedDecision.Embed

        self.file_names_by_resource_id[resource_id] = f"resource-{resource_id}{extension}"
        return LinkEmbedDecision.Link

    def getUrl(self, resource_id, referrer):
        file_name = self.file_names_by_resource_id.get(resource_id)
        if file_name is None:
            return None
        if referrer in self.file_names_by_resource_id:
            return file_name
        return self.asset_url_prefix + file_name

    def saveExternal(self, resource_id, entity_data):
        file_name = self.file_names_by_resource_id.get(resource_id)
        if file_name is None:
            print(f"Resource {resource_id} was not registered for external storage.")
            return
        if entity_data is None or len(entity_data) == 0:
            print(f"Resource {resource_id} contains no data and cannot be saved.")
            return

        try:
            self.asset_directory.mkdir(parents=True, exist_ok=True)
            file_path = self.asset_directory / file_name
            resource_data = bytes(entity_data)
            file_path.write_bytes(resource_data)
        except OSError as error:
            print(f"Failed to save external resource {resource_id}: {error}")

    @classmethod
    def resolve_extension(cls, content_type, recommended_extension):
        content_type = str(content_type) if content_type is not None else ""
        mapped_extension = cls.EXTENSIONS_BY_CONTENT_TYPE.get(content_type)
        if mapped_extension is not None:
            return mapped_extension
        if not content_type.lower().startswith(("image/", "font/", "audio/", "video/")):
            return None
        if recommended_extension is None:
            return None
        extension_characters = str(recommended_extension).strip().lstrip(".")
        if not extension_characters or not extension_characters.isalnum():
            return None
        return "." + extension_characters.lower()


input_file_path = Path("presentation.pptx")
output_directory = Path("html-output")
asset_directory_name = "assets"
asset_directory = output_directory / asset_directory_name

output_directory.mkdir(parents=True, exist_ok=True)
asset_directory.mkdir(parents=True, exist_ok=True)

asset_url_prefix = asset_directory_name + "/"
controller = ExternalResourceController(asset_directory, asset_url_prefix)
controller_proxy = jpype.JProxy("com.aspose.slides.ILinkEmbedController", inst=controller)
svg_options = SVGOptions(controller_proxy)
slide_image_format = SlideImageFormat.svg(svg_options)

html_options = HtmlOptions(controller_proxy)
html_formatter = HtmlFormatter.createDocumentFormatter("", False)
html_options.setHtmlFormatter(html_formatter)
html_options.setSlideImageFormat(slide_image_format)

presentation = Presentation(str(input_file_path))
try:
    html_file_path = output_directory / "presentation.html"
    presentation.save(str(html_file_path), SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

내보낸 후 출력 폴더는 다음과 같은 구조를 가집니다:

```text
html-output/
  presentation.html
  assets/
    resource-1.svg
    resource-2.svg
    resource-3.svg
    resource-4.jpg
    resource-5.png
```

정확한 파일은 프레젠테이션 내용 및 내보내기 옵션에 따라 달라집니다. 예를 들어 래스터 이미지는 일반적으로 JPEG 또는 PNG로 내보내집니다. Aspose.Slides는 파일 크기나 적합성을 고려해 원본 프레젠테이션과 다른 이미지 코덱을 선택할 수 있습니다. 투명도가 있는 이미지는 PNG로 내보내집니다.

## **배포용 URL 선택**

샘플은 상대 URL 접두사 `assets/`를 사용합니다. `presentation.html`이 `html-output/presentation.html`에서 열리면 브라우저는 `html-output/assets/resource-1.svg`를 로드합니다.

하나의 링크된 리소스가 다른 링크된 리소스를 참조할 때, 샘플은 `ILinkEmbedController.getUrl`의 `referrer` 매개변수를 사용하고 파일 이름만 반환합니다. 예를 들어 `resource-1.svg`와 `resource-4.jpg`가 모두 `assets` 폴더에 있을 경우, SVG 파일은 `resource-4.jpg`를 참조해야 하며 `assets/resource-4.jpg`를 참조하지 않아야 합니다.

파일이 다른 위치에 배포될 경우 다른 URL 접두사를 사용하십시오:

- HTML 파일 옆에 자산 디렉터리가 있을 때 `assets/` 사용.
- 자산 디렉터리가 HTML 파일보다 한 단계 위에 있을 때 `../assets/` 사용.
- 파일이 CDN이나 정적 파일 서버에 업로드될 때 `https://cdn.example.com/presentations/job-123/assets/` 사용.

`ILinkEmbedController.getUrl`이 반환하는 URL은 `ILinkEmbedController.saveExternal`이 작성한 파일의 최종 배포 위치와 일치해야 합니다. 서버 애플리케이션에서는 각 변환 작업마다 고유한 출력 디렉터리 또는 객체 저장소 접두사를 사용하여 다른 내보내기의 파일이 덮어쓰이는 것을 방지하십시오.

## **대신 임베드해야 할 경우**

임베드된 Base64 HTML은 출력이 하나의 파일이어야 할 때 여전히 유용합니다(예: 이메일 첨부 파일, 오프라인 미리보기, 별도의 자산 폴더 없이 이동되는 문서). 링크된 리소스는 HTML이 웹 애플리케이션을 통해 제공되거나 CMS에 저장되거나 빌드 파이프라인에서 최적화되거나 브라우저가 HTML과 독립적으로 캐시할 때 더 적합합니다.

## **FAQ**

**이미지만 외부화하고 다른 리소스는 임베드된 상태로 유지할 수 있나요?**

예. `ILinkEmbedController.getObjectStoringLocation`에서 별도 파일로 저장하고 싶은 콘텐츠 유형에 대해서만 [LinkEmbedDecision.Link](https://reference.aspose.com/slides/ko/python-java/aspose.slides/linkembeddecision/#Link)을 반환하고, 나머지는 [LinkEmbedDecision.Embed](https://reference.aspose.com/slides/ko/python-java/aspose.slides/linkembeddecision/#Embed)으로 반환합니다.

**내보낸 이미지 확장자가 원본 프레젠테이션과 다른 이유는 무엇인가요?**

Aspose.Slides는 HTML 내보내기 중 래스터 이미지를 재인코딩하여 크기나 브라우저 호환성을 개선할 수 있습니다. 예를 들어 원본 파일의 이미지는 렌더링 결과에 따라 JPEG 또는 PNG로 기록될 수 있습니다.

**HTML 파일을 이동한 후에도 상대 URL이 작동하나요?**

상대 URL은 동일한 상대 폴더 구조가 유지될 때만 작동합니다. HTML이 `assets/resource-1.png`를 참조한다면 `assets` 폴더는 HTML 파일 옆에 있어야 하며, 다른 URL 접두사를 생성하지 않은 경우에는 이동 시 함께 옮겨야 합니다.

**서버 애플리케이션이 동일한 출력 폴더를 재사용해도 되나요?**

아니요. 각 변환 작업마다 고유한 출력 디렉터리 또는 저장 접두사를 사용하십시오. 이렇게 하면 파일 이름 충돌을 방지하고 한 내보내기가 다른 내보내기의 리소스를 덮어쓰는 일을 방지할 수 있습니다.