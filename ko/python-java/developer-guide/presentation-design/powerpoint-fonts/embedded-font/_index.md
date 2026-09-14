---
title: Python via Java를 사용한 프레젠테이션에 글꼴 임베드
linktitle: 임베디드 글꼴
type: docs
weight: 40
url: /ko/python-java/embedded-font/
keywords:
- 글꼴 추가
- 글꼴 임베드
- 글꼴 임베딩
- 임베드된 글꼴 가져오기
- 임베드된 글꼴 추가
- 임베드된 글꼴 제거
- 임베드된 글꼴 압축
- PowerPoint
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Python via Java용 Aspose.Slides로 PowerPoint에서 임베드된 글꼴을 관리합니다. 글꼴을 추가, 검색, 제거 및 압축하여 텍스트 모양을 유지하고 파일 크기를 줄입니다."
---
## **소개**

임베디드 글꼴은 폰트 데이터를 PowerPoint 프레젠테이션 내부에 저장합니다. 뷰어가 임베디드 글꼴을 지원하면 대상 시스템에 해당 글꼴이 설치되어 있지 않더라도 해당 글꼴을 사용하여 텍스트를 표시할 수 있습니다. 이는 줄바꿈, 텍스트 간격 및 슬라이드 레이아웃을 유지하는 데 도움이 됩니다.

Aspose.Slides for Python via Java를 사용하면 [Presentation.getFontsManager](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getFontsManager) 가 반환하는 [FontsManager](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontsmanager/) 클래스를 통해 임베디드 글꼴을 검색, 추가 및 제거할 수 있습니다. 또한 프레젠테이션에서 사용하지 않는 문자를 제거하여 임베디드 글꼴 데이터의 크기를 줄일 수 있습니다.

아래 예제는 PPTX 파일을 대상으로 합니다. 글꼴을 임베드하기 전에 해당 글꼴 데이터가 Aspose.Slides에서 사용할 수 있으며 라이선스가 임베드를 허용하는지 확인하십시오.

## **임베디드 글꼴 가져오기 및 제거**

[ getEmbeddedFonts](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) 를 사용하여 프레젠테이션에 저장된 글꼴을 나열합니다. 하나를 제거하려면 해당 목록에서 글꼴을 선택하여 [removeEmbeddedFont](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontsmanager/#removeEmbeddedFont) 에 전달한 다음 프레젠테이션을 저장합니다.

다음 예제는 `EmbeddedFonts.pptx`에 포함된 임베디드 글꼴을 나열하고 Calibri가 존재하면 제거합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("EmbeddedFonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    embedded_fonts = fonts_manager.getEmbeddedFonts()

    for font in embedded_fonts:
        print(font.getFontName())

    font_to_remove = None
    for font in embedded_fonts:
        if str(font.getFontName()).casefold() == "calibri":
            font_to_remove = font
            break

    if font_to_remove is not None:
        fonts_manager.removeEmbeddedFont(font_to_remove)
        presentation.save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx)
    else:
        print("Calibri is not embedded. No output file was created.")
finally:
    presentation.dispose()
```

임베디드 글꼴을 제거하면 저장된 글꼴 데이터가 삭제되지만 텍스트에 할당된 글꼴 자체는 변경되지 않습니다. 대상 시스템에 해당 글꼴이 설치되어 있으면 텍스트는 여전히 그 글꼴을 사용할 수 있습니다. 그렇지 않으면 렌더링 시 글꼴 대체가 발생할 수 있으며, 이는 레이아웃에 영향을 줄 수 있습니다.

## **글꼴 데이터 및 임베드 권한 검사**

[FontsManager](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontsmanager/) 클래스를 사용하여 글꼴을 임베드하기 전에 검사할 수 있습니다. [FontsManager.getFonts](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontsmanager/#getFonts) 를 호출하여 프레젠테이션에서 사용되는 글꼴을 가져옵니다. 각 글꼴에 대해 [FontData](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontdata/) 객체와 필요한 [FontStyleType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontstyletype/) 값을 전달하여 [FontsManager.getFontBytes](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontsmanager/#getFontBytes) 를 호출합니다. 이 메서드는 해당 글꼴 스타일에 대한 바이너리 데이터를 반환하거나, 요청한 글꼴 또는 스타일이 없을 경우 `None` 을 반환합니다. `None` 결과를 [FontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel) 에 전달하면 안 됩니다. 해당 메서드는 바이트 배열을 요구하기 때문입니다.

[EmbeddingLevel](https://reference.aspose.com/slides/ko/python-java/aspose.slides/embeddinglevel/) 은 글꼴에 저장된 임베드 제한을 보고하는 플래그 열거형입니다:

- `Installable`은 임베드 및 다른 시스템에 영구 설치를 허용하되, 글꼴 라이선스에 따라 제한됩니다.
- `Restricted`는 유일한 사용 권한 플래그가 있을 경우 글꼴 소유자의 허가 없이는 임베드를 금지합니다.
- `PreviewPrint`는 보기 및 인쇄용으로 일시적인 사용을 허용합니다; 해당 글꼴이 포함된 문서는 읽기 전용이어야 합니다.
- `Editable`은 일시적인 사용을 허용하고 문서를 편집 및 저장할 수 있게 합니다.
- `NoSubsetting`은 추가 제한으로, 글리프의 일부만 임베드하는 것을 금지합니다. 이 플래그가 있으면 모든 문자를 임베드해야 합니다.
- `BitmapOnly`는 추가 제한으로, 아웃라인 데이터가 아닌 비트맵 스트라이크만 임베드할 수 있습니다. 글꼴에 비트맵 스트라이크가 없으면 임베드할 수 없습니다.

앞의 네 값은 사용 권한을 설명하고, `NoSubsetting`과 `BitmapOnly`는 이들과 결합될 수 있습니다. 비트 연산을 사용해 수정자를 확인하십시오. `Installable`은 0이므로 사용 권한 비트를 마스크하고 결과를 `Installable`과 비교해야 플래그로 검사하는 대신 올바르게 판단할 수 있습니다. 현재 글꼴은 최대 하나의 사용 권한 비트를 설정합니다. 여러 비트를 설정한 오래된 글꼴과의 호환성을 위해 아래 도우미는 가장 제한이 낮은 권한을 선택합니다: `Editable`, 다음으로 `PreviewPrint`, 마지막으로 `Restricted`.

다음 예제는 `getFonts` 로 반환된 모든 글꼴에 대해 일반, 굵게, 기울임 및 굵게 기울임 스타일 데이터를 검사합니다. 사용할 수 없는 스타일, 제한된 글꼴, 비트맵 전용 글꼴, 미리 보기 및 인쇄 전용 글꼴(출력이 편집 가능하게 유지됨), 이미 임베드된 글꼴은 건너뜁니다. 사용 가능한 스타일 중 `NoSubsetting` 플래그가 있으면 해당 글꼴 패밀리의 모든 문자를 임베드합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedFontCharacters, EmbeddingLevel, FontStyleType, Presentation, SaveFormat

def get_usage_permission(level):
    permission_mask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable
    permissions = level & permission_mask

    if permissions & EmbeddingLevel.Editable:
        return EmbeddingLevel.Editable

    if permissions & EmbeddingLevel.PreviewPrint:
        return EmbeddingLevel.PreviewPrint

    if permissions & EmbeddingLevel.Restricted:
        return EmbeddingLevel.Restricted

    return EmbeddingLevel.Installable

presentation = Presentation("Fonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    font_styles = [
        FontStyleType.Regular,
        FontStyleType.Bold,
        FontStyleType.Italic,
        FontStyleType.Bold | FontStyleType.Italic,
    ]

    embedded_font_names = {str(embedded_font.getFontName()).casefold() for embedded_font in fonts_manager.getEmbeddedFonts()}

    fonts_to_embed = []
    embedding_rules = []
    for font in fonts_manager.getFonts():
        font_name = str(font.getFontName())
        if font_name.casefold() in embedded_font_names:
            print(f"{font_name}: already embedded.")
            continue

        has_available_data = False
        all_available_styles_can_be_embedded = True
        preview_print_only = False
        requires_full_font = False

        for font_style in font_styles:
            font_bytes = fonts_manager.getFontBytes(font, font_style)
            if font_bytes is None:
                print(f"{font_name} ({font_style}): font data is unavailable.")
                continue

            has_available_data = True
            embedding_level = fonts_manager.getFontEmbeddingLevel(font_bytes, font.getFontName())
            usage_permission = get_usage_permission(embedding_level)
            no_subsetting = bool(embedding_level & EmbeddingLevel.NoSubsetting)
            bitmap_only = bool(embedding_level & EmbeddingLevel.BitmapOnly)

            requires_full_font = requires_full_font or no_subsetting
            preview_print_only = preview_print_only or usage_permission == EmbeddingLevel.PreviewPrint
            usage_permits_embedding = usage_permission != EmbeddingLevel.Restricted and not bitmap_only
            all_available_styles_can_be_embedded = all_available_styles_can_be_embedded and usage_permits_embedding

            print(f"{font_name} ({font_style}): {embedding_level}.")

        if not has_available_data:
            print(f"{font_name}: skipped because no requested style is available.")
        elif not all_available_styles_can_be_embedded:
            print(f"{font_name}: skipped because at least one available style does not permit outline embedding.")
        elif preview_print_only:
            print(f"{font_name}: skipped because this example produces an editable presentation.")
        else:
            rule = EmbedFontCharacters.All if requires_full_font else EmbedFontCharacters.OnlyUsed
            fonts_to_embed.append(font)
            embedding_rules.append(rule)

    for font, rule in zip(fonts_to_embed, embedding_rules):
        fonts_manager.addEmbeddedFont(font, rule)

    presentation.save("WithAuditedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

이 검사는 각 글꼴 파일에 인코딩된 제한을 보고합니다. 라이선스를 부여하거나 글꼴을 합법적으로 획득했음을 입증하거나, 임베드된 복사본을 배포하기 전에 글꼴 라이선스 계약을 확인하는 절차를 대체하지는 않습니다.

## **임베디드 글꼴 추가**

[addEmbeddedFont](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontsmanager/#addEmbeddedFont) 를 사용하여 글꼴을 임베드합니다. 이 메서드의 오버로드는 [FontData](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontdata/) 객체 또는 글꼴 데이터를 포함하는 바이트 배열을 허용합니다. [EmbedFontCharacters](https://reference.aspose.com/slides/ko/python-java/aspose.slides/embedfontcharacters/) 열거형은 포함할 문자를 제어합니다:

- [All](https://reference.aspose.com/slides/ko/python-java/aspose.slides/embedfontcharacters/) 은 글꼴의 모든 문자를 임베드합니다. 수신자가 프레젠테이션을 편집하고 새 텍스트를 입력해야 하는 경우 이 옵션을 사용하십시오.
- [OnlyUsed](https://reference.aspose.com/slides/ko/python-java/aspose.slides/embedfontcharacters/) 은 프레젠테이션에 사용된 문자만 임베드하여 파일 크기를 줄입니다. 주로 보기용으로 제공되는 최종 프레젠테이션에 이 옵션을 선택하십시오.

다음 예제는 `Fonts.pptx` 에서 사용된 글꼴을 [getFonts](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontsmanager/#getFonts) 로 가져와 아직 임베드되지 않은 글꼴을 임베드합니다. 추가할 글꼴은 코드를 실행하는 머신에 있어야 합니다. 기존에 임베드된 글꼴은 현재 문자 집합을 유지합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedFontCharacters, Presentation, SaveFormat

presentation = Presentation("Fonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    all_fonts = fonts_manager.getFonts()
    embedded_fonts = fonts_manager.getEmbeddedFonts()
    embedded_font_names = {str(embedded_font.getFontName()).casefold() for embedded_font in embedded_fonts}

    for font in all_fonts:
        font_name = str(font.getFontName()).casefold()
        if font_name not in embedded_font_names:
            fonts_manager.addEmbeddedFont(font, EmbedFontCharacters.All)
            embedded_font_names.add(font_name)

    presentation.save("WithEmbeddedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **임베디드 글꼴 압축**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/ko/python-java/aspose.slides/compress/#compressEmbeddedFonts) 은 사용되지 않는 문자를 제거하여 임베디드 글꼴 데이터를 압축합니다. 이미 임베드된 글꼴에 대해 작동하므로, 압축 효과는 프레젠테이션에 포함된 사용되지 않은 글꼴 데이터 양에 따라 달라집니다.

다음 예제는 `EmbeddedFonts.pptx` 의 글꼴을 압축하고 결과를 별도의 파일로 저장합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("EmbeddedFonts.pptx")
try:
    Compress.compressEmbeddedFonts(presentation)
    presentation.save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

수신자가 나중에 텍스트를 추가해야 할 가능성이 있는 경우 원본 파일을 보관하십시오. 압축 과정에서 제거된 문자는 임베드된 글꼴에서 더 이상 사용할 수 없으며, 처음에 모든 문자를 임베드했더라도 마찬가지입니다.

## **FAQ**

**렌더링 중에 임베디드 글꼴이 여전히 대체되는지 어떻게 확인할 수 있나요?**

프레젠테이션을 렌더링하는 환경에서 [getSubstitutions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontsmanager/#getSubstitutions) 를 호출하여 Aspose.Slides가 교체할 글꼴을 확인하십시오. 또한 글꼴 대체 설정 및 글꼴 폴백 규칙을 점검하십시오. 폴백은 누락된 문자를 처리하므로, 글꼴 자체에 없는 문자는 임베드하더라도 해결되지 않습니다.

**Arial이나 Calibri와 같은 일반적인 글꼴을 임베드해야 할까요?**

대상 환경을 기준으로 결정하십시오. 필요 글꼴이 프레젠테이션을 여는 모든 머신에 이미 존재한다면 임베드가 불필요한 파일 크기를 증가시킬 수 있습니다. 수신자나 서버에 해당 글꼴이 없을 가능성이 있다면, 라이선스가 허용하는 범위 내에서 임베드하면 의도한 표시를 유지하는 데 도움이 됩니다.