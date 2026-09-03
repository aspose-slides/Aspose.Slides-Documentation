---
title: Python으로 프레젠테이션에 폰트 임베드
linktitle: 임베디드 폰트
type: docs
weight: 40
url: /ko/python-net/embedded-font/
keywords:
- 폰트 추가
- 폰트 임베드
- 폰트 임베딩
- 임베디드 폰트 가져오기
- 임베디드 폰트 추가
- 임베디드 폰트 제거
- 임베디드 폰트 압축
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint에서 임베디드 폰트를 관리합니다. Python을 사용해 폰트를 추가, 가져오고, 제거 및 압축하여 텍스트 모양을 유지하고 파일 크기를 줄입니다."
---
## **소개**

임베디드 폰트는 폰트 데이터를 PowerPoint 프레젠테이션에 저장합니다. 뷰어가 임베디드 폰트를 지원하면 대상 시스템에 해당 폰트가 설치되어 있지 않더라도 해당 폰트를 사용하여 텍스트를 표시할 수 있습니다. 이는 줄 바꿈, 텍스트 간격, 슬라이드 레이아웃을 유지하는 데 도움이 됩니다.

Aspose.Slides for Python via .NET는 [fonts_manager](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/fonts_manager/) 속성을 통해 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 객체에서 임베디드 폰트를 검색, 추가 및 제거할 수 있게 해줍니다. 프레젠테이션에서 사용되지 않는 문자를 제거하여 임베디드 폰트 데이터의 크기를 줄일 수도 있습니다.

아래 예제는 PPTX 파일을 대상으로 합니다. 폰트를 임베드하기 전에 해당 폰트 데이터가 Aspose.Slides에서 사용할 수 있고 라이선스가 임베드를 허용하는지 확인하십시오.

## **임베디드 폰트 가져오기 및 제거**

[get_embedded_fonts](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontsmanager/get_embedded_fonts/)을 사용하여 프레젠테이션에 저장된 폰트를 나열합니다. 하나를 제거하려면 해당 목록에서 폰트를 [remove_embedded_font](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontsmanager/remove_embedded_font/)에 전달한 후 프레젠테이션을 저장합니다.

다음 예제는 `EmbeddedFonts.pptx`에 포함된 임베디드 폰트를 나열하고 Calibri가 있으면 제거합니다:
```python
import aspose.slides as slides

with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    embedded_fonts = fonts_manager.get_embedded_fonts()

    for font in embedded_fonts:
        print(font.font_name)

    font_to_remove = next((font for font in embedded_fonts if font.font_name.casefold() == "calibri"), None)
    if font_to_remove is not None:
        fonts_manager.remove_embedded_font(font_to_remove)
        presentation.save("WithoutEmbeddedCalibri.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Calibri is not embedded. No output file was created.")
```

임베디드 폰트를 제거하면 저장된 폰트 데이터가 삭제되지만 텍스트에 할당된 폰트는 변경되지 않습니다. 대상 시스템에 해당 폰트가 설치되어 있으면 텍스트가 계속 사용할 수 있습니다. 그렇지 않으면 렌더링에 [font substitution](/slides/ko/python-net/font-substitution/)이 필요할 수 있으며, 이는 레이아웃에 영향을 줄 수 있습니다.

## **폰트 데이터 및 임베드 권한 검사**

[FontsManager](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontsmanager/) 클래스를 사용하여 폰트를 임베드하기 전에 검사합니다. 프레젠테이션에서 사용된 폰트를 가져오려면 [get_fonts](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontsmanager/get_fonts/)을 호출합니다. 각 폰트에 대해 [FontData](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontdata/) 객체와 필요한 [FontStyleType](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontstyletype/) 값을 [get_font_bytes](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontsmanager/get_font_bytes/)에 전달합니다. 메서드는 해당 폰트 스타일에 대한 바이너리 데이터를 반환하거나, 요청된 폰트 또는 스타일을 사용할 수 없을 때 `None`을 반환합니다. `None` 결과를 [get_font_embedding_level](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontsmanager/get_font_embedding_level/)에 전달하면 안 됩니다. 이 메서드는 바이트 배열을 필요로 합니다.

[EmbeddingLevel](https://reference.aspose.com/slides/ko/python-net/aspose.slides/embeddinglevel/)은 폰트에 저장된 임베드 제한을 보고하는 플래그 열거형입니다:

- `INSTALLABLE`은 폰트 라이선스에 따라 다른 시스템에 임베드 및 영구 설치를 허용합니다.
- `RESTRICTED`는 사용 권한 플래그가 `RESTRICTED`만 있을 경우, 폰트의 법적 소유자로부터 허가를 받지 않으면 임베드를 금지합니다.
- `PREVIEW_PRINT`는 보기 및 인쇄를 위한 일시적 사용을 허용합니다; 해당 폰트를 포함한 문서는 읽기 전용이어야 합니다.
- `EDITABLE`는 일시적 사용을 허용하고 문서를 편집 및 저장할 수 있게 합니다.
- `NO_SUBSETTING`은 글리프의 일부만 임베드하는 것을 금지하는 추가 제한입니다. 이 플래그가 있으면 모든 문자를 임베드합니다.
- `BITMAP_ONLY`은 비트맵 스트라이크만 임베드하도록 허용하고, 아웃라인 데이터를 임베드하지 못하도록 하는 추가 제한입니다. 폰트에 비트맵 스트라이크가 없으면 임베드할 수 없습니다.

첫 번째 네 값은 사용 권한을 설명하고, `NO_SUBSETTING` 및 `BITMAP_ONLY`는 이들과 결합될 수 있습니다. 비트 연산으로 수정자를 확인하십시오. `INSTALLABLE`이 0이므로 사용 권한 비트를 마스크하고 결과를 `INSTALLABLE`과 비교합니다. 현재 폰트는 최대 하나의 사용 권한 비트만 설정해야 합니다. 하나 이상 설정된 오래된 폰트와 호환성을 위해 아래 도우미는 가장 제한이 낮은 권한을 선택합니다: `EDITABLE`, 다음은 `PREVIEW_PRINT`, 그 다음은 `RESTRICTED`.

다음 예제는 `get_fonts`가 반환하는 각 폰트에 대해 일반, 굵게, 이탤릭, 굵게 이탤릭 데이터가 있는지 감사합니다. 사용 불가능한 스타일, 제한된 폰트, 비트맵 전용 폰트, 미리 보기 및 인쇄만 가능한 폰트(출력이 편집 가능하기 때문에), 이미 임베드된 폰트는 건너뜁니다. 사용 가능한 스타일 중에 `NO_SUBSETTING`이 있으면 해당 폰트 패밀리의 모든 문자를 임베드합니다.
```python
import aspose.slides as slides


def get_usage_permission(level):
    permission_mask = slides.EmbeddingLevel.RESTRICTED | slides.EmbeddingLevel.PREVIEW_PRINT | slides.EmbeddingLevel.EDITABLE
    permissions = level & permission_mask

    if permissions & slides.EmbeddingLevel.EDITABLE:
        return slides.EmbeddingLevel.EDITABLE

    if permissions & slides.EmbeddingLevel.PREVIEW_PRINT:
        return slides.EmbeddingLevel.PREVIEW_PRINT

    if permissions & slides.EmbeddingLevel.RESTRICTED:
        return slides.EmbeddingLevel.RESTRICTED

    return slides.EmbeddingLevel.INSTALLABLE


with slides.Presentation("Fonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    font_styles = [slides.FontStyleType.REGULAR, slides.FontStyleType.BOLD, slides.FontStyleType.ITALIC, slides.FontStyleType.BOLD | slides.FontStyleType.ITALIC]

    embedded_font_names = {font.font_name.casefold() for font in fonts_manager.get_embedded_fonts()}

    embedding_plan = []
    for font in fonts_manager.get_fonts():
        if font.font_name.casefold() in embedded_font_names:
            print(f"{font.font_name}: already embedded.")
            continue

        has_available_data = False
        all_available_styles_can_be_embedded = True
        preview_print_only = False
        requires_full_font = False

        for font_style in font_styles:
            font_bytes = fonts_manager.get_font_bytes(font, font_style)
            if font_bytes is None:
                print(f"{font.font_name} ({font_style}): font data is unavailable.")
                continue

            has_available_data = True
            embedding_level = fonts_manager.get_font_embedding_level(font_bytes, font.font_name)
            usage_permission = get_usage_permission(embedding_level)
            no_subsetting = bool(embedding_level & slides.EmbeddingLevel.NO_SUBSETTING)
            bitmap_only = bool(embedding_level & slides.EmbeddingLevel.BITMAP_ONLY)

            requires_full_font |= no_subsetting
            preview_print_only |= usage_permission == slides.EmbeddingLevel.PREVIEW_PRINT
            all_available_styles_can_be_embedded &= usage_permission != slides.EmbeddingLevel.RESTRICTED and not bitmap_only

            print(f"{font.font_name} ({font_style}): {embedding_level}.")

        if not has_available_data:
            print(f"{font.font_name}: skipped because no requested style is available.")
        elif not all_available_styles_can_be_embedded:
            print(f"{font.font_name}: skipped because at least one available style does not permit outline embedding.")
        elif preview_print_only:
            print(f"{font.font_name}: skipped because this example produces an editable presentation.")
        else:
            rule = slides.export.EmbedFontCharacters.ALL if requires_full_font else slides.export.EmbedFontCharacters.ONLY_USED
            embedding_plan.append((font, rule))

    for font, rule in embedding_plan:
        fonts_manager.add_embedded_font(font, rule)

    presentation.save("WithAuditedFonts.pptx", slides.export.SaveFormat.PPTX)
```

이 검사는 각 폰트 파일에 인코딩된 제한을 보고합니다. 이는 라이선스를 부여하거나, 폰트를 합법적으로 확보했음을 증명하거나, 임베드된 복사본을 배포하기 전에 폰트 라이선스 계약을 확인하는 것을 대체하지 않습니다.

## **임베디드 폰트 추가**

[add_embedded_font](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontsmanager/add_embedded_font/)을 사용하여 폰트를 임베드합니다. 이 메서드의 오버로드는 [FontData](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontdata/) 객체 또는 폰트 데이터를 포함하는 바이트 배열을 허용합니다. [EmbedFontCharacters](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/embedfontcharacters/) 열거형은 포함할 문자를 제어합니다:

- [ALL](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/embedfontcharacters/)은 폰트의 모든 문자를 임베드합니다. 받는 사람이 프레젠테이션을 편집하고 새 텍스트를 입력해야 할 경우 이 옵션을 사용합니다.
- [ONLY_USED](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/embedfontcharacters/)은 프레젠테이션에서 사용된 문자만 임베드하여 파일 크기를 줄입니다. 주로 보기용으로 사용되는 최종 프레젠테이션의 경우 이 옵션을 선택합니다.

다음 예제는 [get_fonts](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontsmanager/get_fonts/)를 사용하여 `Fonts.pptx`에 사용된 폰트를 가져오고 아직 임베드되지 않은 폰트를 임베드합니다. 추가할 폰트는 코드를 실행하는 머신에 있어야 합니다. 기존에 임베드된 폰트는 현재 문자 집합을 유지합니다.
```python
import aspose.slides as slides

with slides.Presentation("Fonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    all_fonts = fonts_manager.get_fonts()
    embedded_fonts = fonts_manager.get_embedded_fonts()
    embedded_names = {font.font_name.casefold() for font in embedded_fonts}

    for font in all_fonts:
        normalized_name = font.font_name.casefold()
        if normalized_name not in embedded_names:
            fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)
            embedded_names.add(normalized_name)

    presentation.save("WithEmbeddedFonts.pptx", slides.export.SaveFormat.PPTX)
```

## **임베디드 폰트 압축**

[compress_embedded_fonts](https://reference.aspose.com/slides/ko/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/)은 사용되지 않은 문자를 제거하여 임베디드 폰트 데이터를 줄입니다. 이미 임베드된 폰트에 대해 작동하므로 크기 감소는 프레젠테이션에 포함된 사용되지 않은 폰트 데이터 양에 따라 달라집니다.

다음 예제는 `EmbeddedFonts.pptx`의 폰트를 압축하고 결과를 별도 파일로 저장합니다:
```python
import aspose.slides as slides

with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("CompressedEmbeddedFonts.pptx", slides.export.SaveFormat.PPTX)
```

받는 사람이 나중에 텍스트를 추가해야 할 수 있으면 원본 파일을 보관하십시오. 압축 중에 제거된 문자는 원래 모든 문자를 임베드했더라도 임베디드 폰트에서 더 이상 사용할 수 없습니다.

## **FAQ**

**렌더링 중에 임베디드 폰트가 여전히 대체되는지 어떻게 확인할 수 있나요?**

[get_substitutions](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontsmanager/get_substitutions/)을 사용하여 프레젠테이션을 렌더링하는 환경에서 Aspose.Slides가 교체할 폰트를 확인하십시오. 또한 [font substitution](/slides/ko/python-net/font-substitution/) 설정과 [font fallback](/slides/ko/python-net/fallback-font/) 규칙을 확인하세요. 폰트 대체는 누락된 문자를 처리하므로, 임베드한 폰트 자체에 포함되지 않은 문자는 해결되지 않습니다.

**Arial 및 Calibri와 같은 일반 폰트를 임베드해야 할까요?**

대상 환경에 따라 결정하십시오. 필요한 폰트가 프레젠테이션을 열거나 렌더링하는 모든 머신에 이미 설치되어 있다면 임베드가 불필요한 파일 크기를 증가시킬 수 있습니다. 받는 사람이나 서버에 해당 폰트가 없을 경우, 라이선스가 허용한다면 임베드하여 의도된 모양을 유지하는 데 도움이 될 수 있습니다.