---
title: Python에서 외부 링크된 이미지를 사용하여 프레젠테이션을 HTML로 내보내기
linktitle: 외부 링크된 이미지를 사용하여 프레젠테이션을 HTML로 내보내기
type: docs
weight: 100
url: /ko/python-net/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- PowerPoint 내보내기
- OpenDocument 내보내기
- 프레젠테이션 내보내기
- 슬라이드 내보내기
- PPT 내보내기
- PPTX 내보내기
- ODP 내보내기
- PowerPoint를 HTML로
- OpenDocument를 HTML로
- 프레젠테이션을 HTML로
- 슬라이드를 HTML로
- PPT를 HTML로
- PPTX를 HTML로
- ODP를 HTML로
- 링크된 이미지
- 외부 링크된 이미지
- 링크된 리소스
- 외부 리소스
- Python
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Python에서 PowerPoint 및 OpenDocument 프레젠테이션을 HTML로 내보내며 이미지가 외부 링크 파일로 저장됩니다."
---
## **개요**

기본적으로 Aspose.Slides는 프레젠테이션을 자체 포함된 HTML 파일로 내보냅니다. 이미지와 기타 리소스는 일반적으로 Base64 데이터 형태로 HTML에 직접 기록됩니다. 이는 하나의 휴대용 파일이 필요할 때 편리하지만, 웹사이트, CMS 또는 서버‑사이드 변환 파이프라인에 항상 최적의 형식은 아닙니다.

다음과 같은 경우 외부 연결된 이미지를 사용하십시오.

- HTML 문서 크기를 줄이기 위해;
- 브라우저나 CDN에서 이미지를 별도로 캐시하기 위해;
- 내보낸 후 이미지 검토, 교체, 압축 또는 후처리를 수행하기 위해;
- 웹 애플리케이션이 기대하는 구조에 더 가깝게 출력 구조를 유지하기 위해.

전체 HTML 변환 워크플로우는 [PowerPoint 프레젠테이션을 HTML로 변환](/slides/ko/python-net/convert-powerpoint-to-html/)을 참조하십시오. 이 문서는 내보내기에서 이미지 연결 부분에 집중합니다.

## **링크된 이미지 내보내기 작동 방식**

.NET 및 Java에서 [ILinkEmbedController](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/ilinkembedcontroller/)은 리소스를 임베드할지 링크할지를 결정하는 콜백 인터페이스를 나타냅니다. .NET을 통해 Python을 사용할 경우, 현재 Python 클래스가 이 .NET 콜백 인터페이스를 직접 구현할 수 없으므로 실용적인 워크플로우는 다음과 같습니다.

1. [HtmlOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/htmloptions/)을 사용해 프레젠테이션을 HTML로 내보냅니다.  
2. [SlideImageFormat](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/slideimageformat/)과 [SVGOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/svgoptions/)를 사용해 슬라이드를 HTML에서 SVG로 표현합니다.  
3. HTML `data:` URL에 포함된 Base64 이미지 데이터를 별도 파일로 이동합니다.  
4. 원래 `data:` URL을 `assets/resource-1.jpg`와 같은 상대 링크로 교체합니다.

파일 시스템 경로와 브라우저 URL은 별개의 문제입니다. 예를 들어 아래 샘플은 디스크의 `html-output/assets`에 이미지 파일을 쓰고, HTML에는 `assets/resource-1.jpg`와 같은 상대 URL을 포함합니다. 브라우저는 링크가 포함된 HTML 파일을 기준으로 해당 URL을 해석합니다.

## **링크된 이미지를 포함한 HTML 내보내기**

다음 Python 예제는 출력 디렉터리를 생성하고, HTML 파일을 저장하며, 추출된 이미지를 `assets` 하위 디렉터리에 저장하고, Base64 이미지 URL을 상대 링크로 재작성합니다. 예제는 Aspose.Slides가 안전한 파일 확장자를 제공할 때 일반적인 Base64 이미지 형식을 추출합니다. 인식되지 않은 Data URL은 계속 임베드됩니다.

```python
import base64
import os
import re

import aspose.slides as slides
import aspose.slides.export as slides_export


EXTENSIONS_BY_CONTENT_TYPE = {
    "image/jpeg": ".jpg",
    "image/png": ".png",
    "image/gif": ".gif",
    "image/bmp": ".bmp",
    "image/svg+xml": ".svg",
    "image/tiff": ".tiff",
    "image/x-emf": ".emf",
    "image/x-wmf": ".wmf",
}

DATA_URI_PATTERN = re.compile(
    r"data:(?P<content_type>[-\w.+]+/[-\w.+]+);base64,(?P<data>[A-Za-z0-9+/=\r\n]+)"
)


def export_presentation_to_html_with_linked_images(
    input_file_path,
    output_directory,
    asset_directory_name="assets",
):
    asset_directory = os.path.join(output_directory, asset_directory_name)

    os.makedirs(output_directory, exist_ok=True)
    os.makedirs(asset_directory, exist_ok=True)

    html_options = slides_export.HtmlOptions()
    html_options.html_formatter = slides_export.HtmlFormatter.create_document_formatter("", False)
    html_options.slide_image_format = slides_export.SlideImageFormat.svg(
        slides_export.SVGOptions()
    )

    html_file_path = os.path.join(output_directory, "presentation.html")

    with slides.Presentation(input_file_path) as presentation:
        presentation.save(html_file_path, slides_export.SaveFormat.HTML, html_options)

    externalize_base64_images(html_file_path, asset_directory, asset_directory_name)


def externalize_base64_images(html_file_path, asset_directory, asset_directory_name):
    with open(html_file_path, "r", encoding="utf-8-sig") as html_file:
        html_content = html_file.read()

    saved_resource_names = {}
    resource_index = 1

    def replace_data_uri(match):
        nonlocal resource_index

        data_uri = match.group(0)
        if data_uri in saved_resource_names:
            return saved_resource_names[data_uri]

        content_type = match.group("content_type").lower()
        extension = EXTENSIONS_BY_CONTENT_TYPE.get(content_type)
        if extension is None:
            return data_uri

        encoded_data = match.group("data")
        image_data = base64.b64decode(encoded_data)
        if len(image_data) == 0:
            return data_uri

        file_name = f"resource-{resource_index}{extension}"
        resource_index += 1

        file_path = os.path.join(asset_directory, file_name)
        with open(file_path, "wb") as image_file:
            image_file.write(image_data)

        linked_url = f"{asset_directory_name}/{file_name}"
        saved_resource_names[data_uri] = linked_url
        return linked_url

    updated_html_content = DATA_URI_PATTERN.sub(replace_data_uri, html_content)

    with open(html_file_path, "w", encoding="utf-8", newline="\n") as html_file:
        html_file.write(updated_html_content)


input_file_path = "presentation.pptx"
output_directory = "html-output"

export_presentation_to_html_with_linked_images(input_file_path, output_directory)
```

내보내기 후 출력 폴더는 다음과 같은 구조를 가질 수 있습니다.

```text
html-output/
  presentation.html
  assets/
    resource-1.jpg
    resource-2.png
```

정확한 파일 구성은 프레젠테이션 내용 및 내보내기 옵션에 따라 달라집니다. 예를 들어 래스터 이미지는 일반적으로 JPEG 또는 PNG로 내보내집니다. Aspose.Slides는 더 작거나 적합한 파일을 만들기 위해 원본 프레젠테이션에서 사용된 코덱과 다른 코덱을 선택할 수 있습니다. 투명도가 포함된 이미지는 PNG로 내보내집니다.

## **배포를 위한 URL 선택**

샘플은 상대 URL 접두사 `assets/`를 사용합니다. `presentation.html` 파일을 `html-output/presentation.html`에서 열면 브라우저는 `html-output/assets/resource-1.jpg`를 로드합니다.

파일을 다른 위치에 배포할 경우 자산 디렉터리 이름을 바꾸거나 생성된 링크를 재작성하십시오.

- HTML 파일과 같은 디렉터리에 자산 디렉터리가 있을 때는 `assets/`를 사용합니다.  
- HTML 파일이 한 단계 위에 있을 때는 `../assets/`를 사용합니다.  
- 파일을 CDN이나 정적 파일 서버에 업로드할 때는 `https://cdn.example.com/presentations/job-123/assets/`와 같은 절대 URL을 사용합니다.

서버 애플리케이션에서는 각 변환 작업마다 고유한 출력 디렉터리 또는 객체 저장소 접두사를 사용하여 다른 내보내기의 파일을 덮어쓰는 일을 방지하십시오.

## **대신 임베드(삽입)할 경우**

단일 파일이어야 하는 경우—예를 들어 이메일 첨부 파일, 오프라인 미리보기, 또는 별도 자산 폴더 없이 이동될 문서—에는 Base64 임베드 HTML이 여전히 유용합니다. 웹 애플리케이션이 HTML을 제공하거나, CMS에 저장하거나, 빌드 파이프라인에서 최적화하거나, 브라우저가 HTML과 독립적으로 캐시해야 하는 경우에는 링크된 이미지가 더 적합합니다.

## **자주 묻는 질문**

**이미지만 외부화하고 다른 리소스는 임베드된 상태로 유지할 수 있나요?**

네. 샘플은 `EXTENSIONS_BY_CONTENT_TYPE`에 나열된 `image/*` Base64 데이터 URL만 추출합니다. 다른 데이터 URL은 그대로 임베드됩니다.

**내보낸 이미지 확장자가 원본 프레젠테이션과 다른 이유는 무엇인가요?**

Aspose.Slides는 HTML 내보내기 과정에서 래스터 이미지를 다시 인코딩하여 용량을 줄이거나 브라우저 호환성을 높일 수 있습니다. 예를 들어 원본 파일의 이미지는 결과에 따라 JPEG 또는 PNG로 저장될 수 있습니다.

**HTML 파일을 이동한 후에도 상대 URL이 작동하나요?**

상대 URL은 동일한 상대 폴더 구조가 유지될 때만 작동합니다. HTML이 `assets/resource-1.png`를 참조한다면 `assets` 폴더는 HTML 파일과 같은 위치에 있어야 합니다. 다른 URL 접두사를 사용하려면 이를 새로 생성해야 합니다.

**서버 애플리케이션이 동일한 출력 폴더를 재사용해도 되나요?**

아니요. 각 변환 작업마다 고유한 출력 디렉터리 또는 저장소 접두사를 사용하십시오. 이렇게 하면 파일 이름 충돌을 방지하고 하나의 내보내기가 다른 내보내기의 리소스를 덮어쓰는 일을 방지할 수 있습니다.